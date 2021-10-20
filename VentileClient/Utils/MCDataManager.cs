﻿using Microsoft.VisualBasic.FileIO;
using System;
using System.IO;
using System.Management.Automation;
using System.Threading.Tasks;
using Windows.Management.Core;

namespace VentileClient.Utils
{
    public static class MCDataManager
    {
        static MainWindow MAIN = MainWindow.INSTANCE;

        static string MINECRAFT_NAME = "Microsoft.MinecraftUWP_8wekyb3d8bbwe";


        public static async Task SaveProfile(string ProfileName)
        {
            if (!Directory.Exists(MAIN.minecraftResourcePacks)) return;
            if (MAIN.savingProfile.Contains(ProfileName))
            {
                Notif.Toast("Profile Manager", "Already Saving Data to profile: " + ProfileName);
                MAIN.vLogger.Log("Already Saving Data to profile: " + ProfileName);
                return;
            }

            string sourceDirName = Path.Combine(MAIN.minecraftResourcePacks, "..");
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

            MAIN.vLogger.Log("Saving current Minecraft data to profile: " + ProfileName);
            MAIN.savingProfile.Add(ProfileName);

            try
            {
                await Task.Run(() =>
                {
                    if (Directory.Exists(destDirName))
                        Directory.Delete(destDirName, true);

                    Directory.CreateDirectory(destDirName);

                    FileSystem.CopyDirectory(sourceDirName, destDirName, true);

                    Notif.Toast("Profile Manager", $"Saved Minecraft Data to: {ProfileName}");
                    MAIN.vLogger.Log($"Saved Minecraft Data to profile: {ProfileName}");
                    MAIN.savingProfile.Remove(ProfileName);
                });
            }
            catch (Exception err)
            {
                Notif.Toast("Profile Manager", $"Sorry, there was an error saving to profile: \"{ProfileName}\"");
                MAIN.vLogger.Log(err);
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

            string shortcutPath = Path.Combine(MAIN.minecraftResourcePacks, @"..\..");
            string profilePath = $@"C:\temp\VentileClient\Versions\Profiles\{ProfileName}";

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
                    Directory.Delete(profilePath, true);
                    Shortcuts.DeleteHard(shortcutPath, "com.mojang");

                    Notif.Toast("Profile Manager", $"Deleted Profile: \"{ProfileName}\"");
                    MAIN.vLogger.Log($"Deleted Profile: {ProfileName}");
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

            string shortcutPath = Path.Combine(MAIN.minecraftResourcePacks, @"..\..");
            string gotoPath = $@"C:\temp\VentileClient\Versions\Profiles\{ProfileName}";

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
                    Shortcuts.UpdateHard(gotoPath, shortcutPath, "com.mojang");

                    Notif.Toast("Profile Manager", $"Loaded Profile: \"{ProfileName}\"");
                    MAIN.vLogger.Log("Imported Minecraft data!");
                });
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
                if (File.Exists(@"C:\temp\VentileClient\mcInfo.txt"))
                    File.Delete(@"C:\temp\VentileClient\mcInfo.txt");

                MAIN.vLogger.Log("Checking Install Location Of Minecraft");
                PowerShell.Create()
                    .AddScript(@"Get-AppxPackage Microsoft.MinecraftUWP >> C:\temp\VentileClient\mcInfo.txt")
                    .Invoke();
                foreach (var line in File.ReadAllLines(@"C:\temp\VentileClient\mcInfo.txt"))
                {
                    if (line.StartsWith("InstallLocation"))
                    {
                        string[] args = line.Split(new string[] { " : " }, StringSplitOptions.None);
                        for (int i = 0; i < args.Length; i++)
                        {
                            args[i] = args[i].Trim();

                            File.Delete(@"C:\temp\VentileClient\mcInfo.txt");
                        }
                        installLoc = args[args.Length - 1];
                        break;
                    }
                }
            });
            MAIN.vLogger.Log(installLoc);
            return installLoc;
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
