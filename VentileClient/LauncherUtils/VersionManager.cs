using Guna.UI2.WinForms;
using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using VentileClient.JSON_Template_Classes;
using VentileClient.Utils;

namespace VentileClient.LauncherUtils
{
    public static class VersionManager
    {
        static MainWindow MAIN = MainWindow.INSTANCE;

        public static async Task RegisterPackage(string gameDir, Guna2Button sndr)
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
                        MAIN.Toast("Version Manager", $"Switched Version!");
                        MAIN.versionLogger.Log("Registered Package: " + gameDir);
                    }
                    else
                    {
                        MAIN.Toast("Version Manager", "There was an error switching the version!");
                        MAIN.versionLogger.Log("AppxManifest.xml didn't exist! | " + manifestPath, LogLevel.Error);
                    }
                }
                catch (Exception err)
                {
                    MAIN.Toast("Version Manager", "There was an error switching the version!");
                    MAIN.versionLogger.Log(err);
                }

                MAIN.allowSelectVersion--;
                MAIN.allowClose--;
                sndr.Enabled = true;
            });
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
                    client.DownloadProgressChanged += new DownloadProgressChangedEventHandler((sndr, e) => VersionDownloadProgressChanged(sndr, e, version));
                    client.DownloadFileCompleted += new AsyncCompletedEventHandler((sndr, e) => VersionDownloadCompleted(sndr, e, version));

                    MAIN.versionLogger.Log("Started Downloading Version: " + version);
                    var url = new Uri(link);

                    client.DownloadFileAsync(url, Path.Combine(path, name));
                }
            });

        }

        private static async void VersionDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e, string version)
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

        private static void VersionDownloadCompleted(object sender, AsyncCompletedEventArgs e, string version)
        {
            MAIN.versionLogger.Log("Downloaded version: " + version);
            var ctrl = (Guna2ProgressBar)ControlManager.GetControl("bar|" + version, MAIN.versionsPanel);
            ctrl.Maximum = int.MaxValue;
            ctrl.Value = 0;
            ExtractAppx(@"C:\temp\VentileClient\Versions\Minecraft-" + version + ".Appx", @"C:\temp\VentileClient\Versions", "Minecraft-" + version, version);
        }

        #endregion

        #region Version Switcher - Extracting

        //private BackgroundWorker _extractFile;
        private static long FILE_SIZE;
        private static long EXTRACTED_SIZE_TOTAL;
        private static long COMPRESSED_SIZE;

        private static async void ExtractAppx(string AppxPath, string OutputPath, string dirName, string version)
        {
            await Task.Run(() =>
            {
                if (!Directory.Exists(Path.Combine(OutputPath, dirName)))
                {
                    Directory.CreateDirectory(Path.Combine(OutputPath, dirName));
                    MAIN.versionLogger.Log("Created Directory: " + dirName + " in: " + OutputPath);
                }

                var _extractFile = new BackgroundWorker();
                _extractFile.DoWork += new DoWorkEventHandler((sndr, e) => ExtractFile_DoWork(_extractFile, e, AppxPath, Path.Combine(OutputPath, dirName), version, dirName));
                _extractFile.ProgressChanged += new ProgressChangedEventHandler((sndr, e) => ExtractFile_ProgressChanged(sndr, e, version));
                _extractFile.RunWorkerCompleted += new RunWorkerCompletedEventHandler((sndr, e) => ExtractFile_RunWorkerCompleted(version, AppxPath, OutputPath, dirName));
                _extractFile.WorkerReportsProgress = true;


                _extractFile.RunWorkerAsync();
            });
        }

        private static async void ExtractFile_DoWork(BackgroundWorker sender, DoWorkEventArgs e, string AppxPath, string OutputPath, string version, string dirName)
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
                        zipFile.ExtractProgress += new EventHandler<ExtractProgressEventArgs>((sndr, ee) => Zip_ExtractProgress(sender, ee));
                        foreach (ZipEntry entry in zipFile)
                        {
                            COMPRESSED_SIZE = entry.CompressedSize;
                            entry.Extract(OutputPath, ExtractExistingFileAction.OverwriteSilently);
                            EXTRACTED_SIZE_TOTAL += COMPRESSED_SIZE;
                        }
                    }
                }
                catch (Exception err)
                {
                    MAIN.Toast("Version Manager", "There was an error extracting!");
                    MAIN.versionLogger.Log(err);
                    //ExtractFile_RunWorkerCompleted(version, AppxPath, OutputPath, dirName);
                }
            });
        }

        private static async void ExtractFile_ProgressChanged(object sender, ProgressChangedEventArgs e, string version)
        {
            await Task.Run(() =>
            {
                long totalPercent = (e.ProgressPercentage * COMPRESSED_SIZE + EXTRACTED_SIZE_TOTAL * int.MaxValue) / FILE_SIZE;
                if (totalPercent > int.MaxValue)
                    totalPercent = int.MaxValue;
                var ctrl = (Guna2ProgressBar)ControlManager.GetControl("bar|" + version, MAIN.versionsPanel);
                ctrl.Value = (int)totalPercent;
            });
        }

        private static async void Zip_ExtractProgress(BackgroundWorker sender, ExtractProgressEventArgs e)
        {
            await Task.Run(() =>
            {
                try
                {
                    if (e.TotalBytesToTransfer > 0)
                    {
                        long percent = e.BytesTransferred * int.MaxValue / e.TotalBytesToTransfer;
                        sender.ReportProgress((int)percent);
                    }
                }
                catch (Exception ex)
                {
                    MAIN.versionLogger.Log(ex, LogLevel.Information, LogLocation.Console);
                }
            });
        }

        private static void ExtractFile_RunWorkerCompleted(string version, string AppxPath, string OutputPath, string dirName)
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

            MAIN.versionLogger.Log("Extracted Appx: " + AppxPath + " to: " + Path.Combine(OutputPath, dirName));

            try
            {
                File.Delete(Path.Combine(OutputPath, dirName, "AppxSignature.p7x"));
                File.Delete(AppxPath);
            }
            catch (Exception ex)
            {
                MAIN.versionLogger.Log(ex);
            }

            MAIN.allowClose--;
        }

        #endregion
    }
}
