using Guna.UI2.WinForms;
using Microsoft.VisualBasic.FileIO;
using System;
using System.IO;
using System.Threading.Tasks;
using VentileClient.LauncherUtils;

namespace VentileClient.Utils
{
    public static class MCDataManager
    {
        static MainWindow MAIN = MainWindow.INSTANCE;

        public static async Task SaveProfile(string ProfileName)
        {
            if (MAIN.savingProfile.Contains(ProfileName))
            {
                Notif.Toast("Profile Manager", "Already Saving Data to profile: " + ProfileName);
                MAIN.vLogger.Log("Already Saving Data to profile: " + ProfileName);
                return;
            }

            MAIN.vLogger.Log("Saving current Minecraft data to profile: " + ProfileName);
            MAIN.savingProfile.Add(ProfileName);

            string sourceDirName = Path.Combine(MAIN.minecraftResourcePacks, "..");
            string destDirName = @"C:\temp\VentileClient\Profiles\" + ProfileName;

            if (!Directory.Exists(sourceDirName))
            {
                Notif.Toast("Profile Manager", "Sorry, I couldn't find your com.mojang!");
                MAIN.vLogger.Log("Directory didnt exist: " + sourceDirName);
                return;
            }

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

            string profilePath = $@"C:\temp\VentileClient\Versions\Profiles\{(MAIN.configCS.DefaultProfile ?? "Default")}";

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

                    Notif.Toast("Profile Manager", $"Deleted Profile: \"{ProfileName}\"");
                    MAIN.vLogger.Log($"Deleted Profile: {ProfileName}");
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

        public static async Task ImportProfile()
        {
            if (MAIN.importing)
            {
                Notif.Toast("Profile Manager", "Already Importing Profile!");
                MAIN.vLogger.Log("Already Importing!");
                return;
            }
            MAIN.vLogger.Log("Starting importing Minecraft data!");
            MAIN.importing = true;

            string shortcutPath = Path.Combine(MAIN.minecraftResourcePacks, @"..");
            string gotoPath = $@"C:\temp\VentileClient\Versions\Profiles\{(MAIN.configCS.DefaultProfile ?? "Default")}";

            if (!Directory.Exists(gotoPath))
            {
                Notif.Toast("Profile Manager", $"Sorry, the profile \"{(MAIN.configCS.DefaultProfile ?? "Default")}\" didn't exist!");
                MAIN.vLogger.Log("Directory didnt exist: " + gotoPath);
                return;
            }

            try
            {
                await Task.Run(() =>
                {
                    Shortcuts.Create(gotoPath, shortcutPath, "com.mojang");

                    Notif.Toast("Profile Manager", $"Loaded Profile: \"{(MAIN.configCS.DefaultProfile ?? "Default")}\"");
                    MAIN.vLogger.Log("Imported Minecraft data!");
                    MAIN.importing = false;
                });
            }
            catch (Exception err)
            {
                Notif.Toast("Profile Manager", $"Sorry, there was an error loading profile: \"{(MAIN.configCS.DefaultProfile ?? "Default")}\"");
                MAIN.vLogger.Log(err);
                MAIN.importing = false;
            }
        }
    }
}
