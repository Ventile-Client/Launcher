using Guna.UI2.WinForms;
using Ionic.Zip;
using Microsoft.VisualBasic.FileIO;
using System;
using System.ComponentModel;
using System.IO;
using System.Management.Automation;
using System.Net;
using System.Threading.Tasks;
using VentileClient.Utils;

namespace VentileClient.LauncherUtils
{
    public static class VersionManager
    {
        static MainWindow MAIN = MainWindow.INSTANCE;

        public static async Task RegisterPackage(string version, string gameDir, Guna2Button sndr)
        {
            await Task.Run(() =>
            {
                try
                {
                    MAIN.versionLogger.Log("Registering Package: " + gameDir);
                    string manifestPath = Path.Combine(gameDir, "AppxManifest.xml");
                    if (File.Exists(manifestPath))
                    {
                        var ps = PowerShell.Create();
                        ps.AddScript("Add-AppxPackage -Register -ForceUpdateFromAnyVersion \"" + manifestPath + "\"");
                        ps.Invoke();
                        Notif.Toast("Version Manager", $"Switched Version: {version}");
                        MAIN.versionLogger.Log($"Registered Package: {gameDir}");
                    }
                    else
                    {
                        Notif.Toast("Version Manager", "There was an error switching the version!");
                        MAIN.versionLogger.Log("AppxManifest.xml didn't exist! | " + manifestPath, LogLevel.Error);
                    }
                }
                catch (Exception err)
                {
                    Notif.Toast("Version Manager", "There was an error switching the version!");
                    MAIN.versionLogger.Log(err);
                }

                MAIN.allowSelectVersion--;
                MAIN.allowClose--;
                sndr.Enabled = true;
            });
        }

        public static async void ImportPersona(bool isDefault)
        {
            if (isDefault)
            {
                Directory.CreateDirectory(@"C:\temp\VentileClient\Versions\.data\defaultPersona");
                FileSystem.CopyDirectory(MAIN.configCS.PersonaLoc, @"C:\temp\VentileClient\Versions\.data\defaultPersona", true);
            }

            if (Directory.Exists(MAIN.configCS.PersonaLoc))
            {
                foreach (DirectoryInfo folder in new DirectoryInfo(@"C:\temp\VentileClient\Versions").GetDirectories())
                {
                    if (!folder.Name.StartsWith("."))
                    {
                        await Task.Run(() =>
                        {
                            Directory.CreateDirectory(Path.Combine(folder.FullName, "data/skin_packs/persona"));
                            FileSystem.CopyDirectory(MAIN.configCS.PersonaLoc, Path.Combine(folder.FullName, "data/skin_packs/persona"), true);
                        });
                    }
                }
            }
        }

        public static async void RemovePersona()
        {
            if (!Directory.Exists(@"C:\temp\VentileClient\Versions\.data\defaultPersona")) return;
            foreach (DirectoryInfo folder in new DirectoryInfo(@"C:\temp\VentileClient\Versions").GetDirectories())
            {
                if (!folder.Name.StartsWith("."))
                {
                    await Task.Run(() =>
                    {
                        Directory.CreateDirectory(Path.Combine(folder.FullName, "data/skin_packs/persona"));
                        FileSystem.CopyDirectory(@"C:\temp\VentileClient\Versions\.data\defaultPersona", Path.Combine(folder.FullName, "data/skin_packs/persona"), true);
                    });
                }
            }
        }

        #region Version Switcher - Downloading
        public static async Task DownloadVersion(string version, Guna2Button sender)
        {
            await Task.Run(() =>
            {

                var ctrl = (Guna2ProgressBar)ControlManager.GetControl("bar|" + version, MAIN.versionsPanel);
                ctrl.Invoke(new Action(() =>
                {
                    ctrl.Visible = true;
                }));

                string link = @"https://github.com/" + MAIN.link_settings.repoOwner + "/" + MAIN.link_settings.versionsRepo + "/releases/download/" + version + @"/Minecraft-" + version + ".Appx";
                string path = @"C:\temp\VentileClient\Versions";
                string name = "Minecraft-" + version + ".Appx";
                using (var client = new WebClient())
                {
                    client.DownloadProgressChanged += new DownloadProgressChangedEventHandler((sndr, e) => VersionDownloadProgressChanged(e, version));
                    client.DownloadFileCompleted += new AsyncCompletedEventHandler((sndr, e) => VersionDownloadCompleted(version));

                    MAIN.versionLogger.Log("Started Downloading Version: " + version);

                    client.DownloadFileAsync(new Uri(link), Path.Combine(path, name));
                }
            });

        }

        private static async void VersionDownloadProgressChanged(DownloadProgressChangedEventArgs e, string version)
        {
            await Task.Run(() =>
            {
                var ctrl = (Guna2ProgressBar)ControlManager.GetControl("bar|" + version, MAIN.versionsPanel);
                double recieve = double.Parse(e.BytesReceived.ToString());
                double total = double.Parse(e.TotalBytesToReceive.ToString());
                double percent = recieve / total * 100;
                ctrl.Value = int.Parse(Math.Truncate(percent).ToString());
            });
        }

        private static void VersionDownloadCompleted(string version)
        {
            MAIN.versionLogger.Log("Downloaded version: " + version);
            var ctrl = (Guna2ProgressBar)ControlManager.GetControl("bar|" + version, MAIN.versionsPanel);
            ctrl.Maximum = int.MaxValue;
            ctrl.Value = 0;

            ExtractAppx(@"C:\temp\VentileClient\Versions\Minecraft-" + version + ".Appx", @"C:\temp\VentileClient\Versions", "Minecraft-" + version, version);
        }

        #endregion

        #region Version Switcher - Extracting

        private static void ExtractAppx(string AppxPath, string OutputPath, string dirName, string version)
        {
            if (!Directory.Exists(Path.Combine(OutputPath, dirName)))
            {
                Directory.CreateDirectory(Path.Combine(OutputPath, dirName));
                MAIN.versionLogger.Log("Created Directory: " + dirName + " in: " + OutputPath);
            }

            long FILE_SIZE = new long();
            long EXTRACTED_SIZE_TOTAL = new long();
            long COMPRESSED_SIZE = new long();

            ExtractFile(AppxPath, Path.Combine(OutputPath, dirName), version, dirName, FILE_SIZE, EXTRACTED_SIZE_TOTAL, COMPRESSED_SIZE);
        }

        private static async void ExtractFile(string AppxPath, string OutputPath, string version, string dirName, long FILE_SIZE, long EXTRACTED_SIZE_TOTAL, long COMPRESSED_SIZE)
        {
            await Task.Run(() =>
            {
                try
                {
                    MAIN.versionLogger.Log("Started to extract version: " + version);
                    var fileInfo = new FileInfo(AppxPath);
                    FILE_SIZE = fileInfo.Length;
                    using (var zipFile = ZipFile.Read(AppxPath))
                    {
                        EXTRACTED_SIZE_TOTAL = 0;
                        zipFile.ExtractProgress += new EventHandler<ExtractProgressEventArgs>((sndr, ee) => Zip_ExtractProgress(ee, version, COMPRESSED_SIZE, EXTRACTED_SIZE_TOTAL, FILE_SIZE));
                        foreach (ZipEntry entry in zipFile)
                        {
                            COMPRESSED_SIZE = entry.CompressedSize;
                            entry.Extract(OutputPath, ExtractExistingFileAction.OverwriteSilently);
                            EXTRACTED_SIZE_TOTAL += COMPRESSED_SIZE;
                        }
                    }

                    ExtractComplete(AppxPath, OutputPath, version, dirName);
                }
                catch (Exception err)
                {
                    Notif.Toast("Version Manager", "There was an error extracting!");
                    MAIN.versionLogger.Log(err);
                }
            });
        }

        private static void ExtractComplete(string AppxPath, string OutputPath, string version, string dirName)
        {
            var ctrl = (Guna2ProgressBar)ControlManager.GetControl("bar|" + version, MAIN.versionsPanel);
            ctrl.Value = int.MaxValue;
            ctrl.Visible = false;

            var ctrl2 = (Guna2Button)ControlManager.GetControl("download|" + version, MAIN.versionsPanel);
            ctrl2.Invoke(new Action(() =>
            {
                ctrl2.Enabled = true;
                ctrl2.Visible = false;
            }));

            ctrl2 = (Guna2Button)ControlManager.GetControl("select|" + version, MAIN.versionsPanel);
            ctrl2.Invoke(new Action(() =>
            {
                ctrl2.Enabled = true;
                ctrl2.Visible = true;
            }));

            ctrl2 = (Guna2Button)ControlManager.GetControl("uninstall|" + version, MAIN.versionsPanel);
            ctrl2.Invoke(new Action(() =>
            {
                ctrl2.Enabled = true;
                ctrl2.Visible = true;
            }));

            MAIN.versionLogger.Log("Extracted Appx: " + AppxPath + " to: " + OutputPath);

            try
            {
                File.Delete(Path.Combine(OutputPath, "AppxSignature.p7x"));
                File.Delete(AppxPath);
            }
            catch (Exception ex)
            {
                MAIN.versionLogger.Log(ex);
                Notif.Toast("Version Switcher", "There was an error...");
            }

            MAIN.allowClose--;
            ImportPersona(true);
        }

        private static void Zip_ExtractProgress(ExtractProgressEventArgs e, string version, long COMPRESSED_SIZE, long EXTRACTED_SIZE_TOTAL, long FILE_SIZE)
        {
            try
            {
                if (e.TotalBytesToTransfer > 0)
                {
                    long percent = e.BytesTransferred * int.MaxValue / e.TotalBytesToTransfer;

                    long totalPercent = ((int)percent * COMPRESSED_SIZE + EXTRACTED_SIZE_TOTAL * int.MaxValue) / FILE_SIZE;
                    if (totalPercent > int.MaxValue)
                        totalPercent = int.MaxValue;

                    var ctrl = (Guna2ProgressBar)ControlManager.GetControl("bar|" + version, MAIN.versionsPanel);
                    ctrl.Value = (int)totalPercent;
                }
            }
            catch (Exception ex)
            {
                MAIN.versionLogger.Log(ex, LogLevel.Information, LogLocation.Console);
            }
        }

        #endregion
    }
}
