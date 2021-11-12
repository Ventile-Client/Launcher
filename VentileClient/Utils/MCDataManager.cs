using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VentileClient.LauncherUtils;
using Windows.Management.Core;

namespace VentileClient.Utils
{
    public static class MCDataManager
    {
        static MainWindow MAIN = MainWindow.INSTANCE;

        static string MINECRAFT_NAME = "Microsoft.MinecraftUWP_8wekyb3d8bbwe";


        public static async Task SaveProfile(string ProfileName, bool isOverwrite, bool showPopup = true)
        {
            
            Directory.CreateDirectory(@"C:\temp\VentileClient\Profiles");

            if (MAIN.savingProfile.Contains(ProfileName))
            {
                Notif.Toast("Profile Manager", "Already Saving Data to profile: " + ProfileName);
                MAIN.vLogger.Log("Already Saving Data to profile: " + ProfileName);
                return;
            }

            string sourceDirName = Path.Combine(MAIN.gamesFolder, "com.mojang");
            string destDirName = @"C:\temp\VentileClient\Profiles\" + ProfileName;

            if (!Directory.Exists(sourceDirName))
            {
                Notif.Toast("Profile Manager", "Sorry, I couldn't find your com.mojang folder!");
                MAIN.vLogger.Log("Directory didnt exist: " + sourceDirName);
                return;
            }

            if (Directory.GetFileSystemEntries(sourceDirName).Length == 0)
            {
                MAIN.vLogger.Log("Empty Directory: " + sourceDirName);
                return;
            }
           
            if (Directory.Exists(destDirName) && isOverwrite)
            {
                MAIN.vLogger.Log("Directory existed: " + sourceDirName);
                DialogResult result = DialogResult.Yes;
                if (showPopup)
                    result = MessageBox.Show("Are you sure you want to overwrite the profile: \"" + ProfileName + "\"?", "Overwrite " + ProfileName, MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    await Task.Run(() =>
                    {
                        MAIN.vLogger.Log("Overwriting profile: " + ProfileName);
                        Notif.Toast("Profile Manager", "Overwriting Data to Profile: " + ProfileName);

                        Directory.Delete(destDirName, true);

                        Directory.CreateDirectory(destDirName);

                        FileSystem.CopyDirectory(sourceDirName, destDirName, true);

                        DataManager.UpdateProfile(ProfileName, NewImage: Properties.Resources.GrassBlock);

                        Notif.Toast("Profile Manager", $"Saved Minecraft Data to: {ProfileName}");
                        MAIN.vLogger.Log($"Saved Minecraft Data to profile: {ProfileName}");
                    });
                }
                else
                {
                    MAIN.vLogger.Log("Canceled Overwrite for profile: " + ProfileName);
                }
                return;
            }


            Notif.Toast("Profile Manager", "Saving Data to Profile: " + ProfileName);
            MAIN.vLogger.Log("Saving current Minecraft data to profile: " + ProfileName);
            MAIN.savingProfile.Add(ProfileName);

            try
            {
                await Task.Run(() =>
                {
                    Directory.CreateDirectory(destDirName);

                    FileSystem.CopyDirectory(sourceDirName, destDirName, true);

                    if (File.Exists(Path.Combine(destDirName, "profileLogo.png")))
                        File.Delete(Path.Combine(destDirName, "profileLogo.png"));

                    DataManager.AddProfile(new DirectoryInfo(destDirName));
                Notif.Toast("Profile Manager", $"Saved Minecraft Data to: {ProfileName}");
                MAIN.vLogger.Log($"Saved Minecraft Data to profile: {ProfileName}");
                });

            }
            catch (Exception err)
            {
                Notif.Toast("Profile Manager", $"Sorry, there was an error saving to profile: \"{ProfileName}\"");
                MAIN.vLogger.Log(err);
            }
            finally
            {
                MAIN.savingProfile.Remove(ProfileName);
            }
        }

        public static async Task DeleteProfile(string ProfileName)
        {
            if (MAIN.savingProfile.Contains(ProfileName))
            {
                Notif.Toast("Profile Manager", "Already Deleting profile: " + ProfileName);
                MAIN.vLogger.Log("Already Deleting profile: " + ProfileName);
                return;
            }

            MAIN.vLogger.Log("Deleting profile: " + ProfileName);
            MAIN.savingProfile.Add(ProfileName);

            string shortcutPath = Path.Combine(MAIN.gamesFolder);
            string profilePath = $@"C:\temp\VentileClient\Profiles\{ProfileName}";

            if (!Directory.Exists(profilePath))
            {
                Notif.Toast("Profile Manager", "Sorry, I couldn't find your profile!");
                MAIN.vLogger.Log("Directory didnt exist: " + profilePath);
                return;
            }

            try
            {
                await Task.Run(() =>
                {
                    //Shortcuts.DeleteHard(shortcutPath, "com.mojang");
                    Directory.Delete(profilePath, true);
                });
                DataManager.RemoveProfile(ProfileName);

                Notif.Toast("Profile Manager", $"Deleted Profile: \"{ProfileName}\"");
                MAIN.vLogger.Log($"Deleted Profile: {ProfileName}");
            }
            catch (Exception err)
            {
                Notif.Toast("Profile Manager", $"Sorry, there was an error saving to profile: \"{ProfileName}\"");
                MAIN.vLogger.Log(err);
            }
            finally
            {
                MAIN.savingProfile.Remove(ProfileName);
            }
        }

        public static async Task ImportProfile(string ProfileName)
        {
            if (MAIN.importing)
            {
                Notif.Toast("Profile Manager", "Already Importing Profile!");
                MAIN.vLogger.Log("Already Importing!");
                return;
            }

            MAIN.vLogger.Log("Starting importing Minecraft data!");
            MAIN.configCS.DefaultProfile = ProfileName;
            MAIN.importing = true;


            string shortcutPath = MAIN.gamesFolder;
            string gotoPath = $@"C:\temp\VentileClient\Profiles\{ProfileName}";

            if (!Directory.Exists(gotoPath))
            {
                Notif.Toast("Profile Manager", $"Sorry, the profile \"{ProfileName}\" didn't exist!");
                MAIN.vLogger.Log("Directory didnt exist: " + gotoPath);
                return;
            }

            try
            {
                await Task.Run(() =>
                {
                    Shortcuts.CreateHard(gotoPath, shortcutPath, "com.mojang");
                });
                Notif.Toast("Profile Manager", $"Loaded Profile: \"{ProfileName}\"");
                MAIN.vLogger.Log("Imported Minecraft data!");
            }
            catch (Exception err)
            {
                Notif.Toast("Profile Manager", $"Sorry, there was an error loading profile: \"{ProfileName}\"");
                MAIN.vLogger.Log(err);
            }
            finally
            {
                MAIN.importing = false;
            }
        }

        public static async Task BackupRoamingState()
        {
            string sourceDirName = ApplicationDataManager.CreateForPackageFamily(MINECRAFT_NAME).RoamingFolder.Path;
            string destDirName = @"C:\temp\VentileClient\.data\RoamingState";

            if (MAIN.savingRoamingState)
            {
                MAIN.vLogger.Log("Already Backing up Roaming State");
                return;
            }

            if (!Directory.Exists(sourceDirName))
            {
                MAIN.vLogger.Log($"Directory didnt exist: {sourceDirName}");
                return;
            }

            if (Directory.GetFileSystemEntries(sourceDirName).Length == 0)
            {
                MAIN.vLogger.Log($"Empty Directory: {sourceDirName}");
                return;
            }

            MAIN.vLogger.Log("Backing up Roaming State");
            MAIN.savingRoamingState = true;

            try
            {
                await Task.Run(() =>
                {
                    if (Directory.Exists(destDirName))
                        Directory.Delete(destDirName, true);

                    Directory.CreateDirectory(destDirName);

                    FileSystem.CopyDirectory(sourceDirName, destDirName, true);

                    MAIN.vLogger.Log($"Backed up Roaming State");
                    MAIN.savingRoamingState = false;
                });
            }
            catch (Exception err)
            {
                MAIN.vLogger.Log(err);
                MAIN.savingRoamingState = false;

            }
        }

        public static async Task ImportRoamingState()
        {
            await Task.Run(() =>
            {
                var data = ApplicationDataManager.CreateForPackageFamily(MINECRAFT_NAME);

                if (!Directory.Exists(@"C:\temp\VentileClient\.data\RoamingState"))
                {
                    MAIN.vLogger.Log($"No Roaming State Backup");
                }

                FileSystem.CopyDirectory(@"C:\temp\VentileClient\.data\RoamingState", data.RoamingFolder.Path, true);
                MAIN.vLogger.Log($"Loaded Roaming State");
            });
        }

        public static async Task<string> MCInstallLoc()
        {
            string installLoc = "none";
            await Task.Run(() =>
            {
                MAIN.vLogger.Log("Checking Install Location Of Minecraft");
                using (var powerShell = PowerShell.Create())
                {
                    powerShell
                        .AddScript("Get-AppxPackage Microsoft.MinecraftUWP | Select -ExpandProperty InstallLocation")
                        .AddCommand("Out-String");
                    var psOutput = powerShell.Invoke();
                    var stringBuilder = new StringBuilder();
                    foreach (var pSObject in psOutput)
                        stringBuilder.AppendLine(pSObject.ToString());

                    installLoc = stringBuilder.ToString().Replace(Environment.NewLine, "");
                }
            });
            MAIN.vLogger.Log(installLoc);
            return installLoc;
        }


        public static async Task<Version> GetMCVersion()
        {
            string version = "none";
            await Task.Run(() =>
            {
                MAIN.vLogger.Log("Checking Version Of Minecraft");
                using (var powerShell = PowerShell.Create())
                {
                    powerShell
                        .AddScript("Get-AppxPackage Microsoft.MinecraftUWP | Select -ExpandProperty Version")
                        .AddCommand("Out-String");
                    var psOutput = powerShell.Invoke();
                    var stringBuilder = new StringBuilder();
                    foreach (var pSObject in psOutput)
                        stringBuilder.AppendLine(pSObject.ToString());

                    version = stringBuilder.ToString().Replace(Environment.NewLine, "");
                }
            });
            MAIN.vLogger.Log(version);
            return new Version(version);
        }

        public static async Task RestoreMCData()
        {
            await Task.Run(async () =>
            {
                var data = ApplicationDataManager.CreateForPackageFamily(MINECRAFT_NAME);

                if (!Directory.Exists(Path.Combine(@"C:\temp\VentileClient\Profiles\", MAIN.configCS.DefaultProfile ?? "Default")))
                {
                    Notif.Toast("MC Data", $"Sorry, I couldn't find the \"{MAIN.configCS.DefaultProfile ?? "Default"}\" profile!");
                    MAIN.vLogger.Log($"Profile Didnt Exist");
                    return;
                }

                Directory.CreateDirectory(Path.Combine(data.LocalFolder.Path, "games"));

                Shortcuts.CreateHard(Path.Combine(@"C:\temp\VentileClient\Profiles\", (MAIN.configCS.DefaultProfile ?? "Default")), Path.Combine(data.LocalFolder.Path, @"games\"), "com.mojang");
                MAIN.vLogger.Log($"Created Shortcut To Profile: {(MAIN.configCS.DefaultProfile ?? "Default")} in: {Path.Combine(data.LocalFolder.Path, @"games\")}");
                await ImportRoamingState();
            });
        }

    }
}
