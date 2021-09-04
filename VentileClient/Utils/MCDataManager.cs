using Guna.UI2.WinForms;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentileClient.JSON_Template_Classes;
using VentileClient.LauncherUtils;

namespace VentileClient.Utils
{
    public static class MCDataManager
    {
        static MainWindow MAIN = MainWindow.INSTANCE;

        public static async Task Backup(bool force = false)
        {
            if (MAIN.backingUp)
            {
                MAIN.versionLogger.Log("Already Backing Up!");
                return;
            }
            if (!force && MAIN.backedUp)
            {
                MAIN.versionLogger.Log("Wasn't Forced, didn't backup com.mojang");
                return;
            }
            MAIN.versionLogger.Log("Starting backing up minecraft data!");
            MAIN.backingUp = true;

            MAIN.Toast("Version Manager", "Backing up data...");

            string sourceDirName = Path.Combine(MAIN.minecraftResourcePacks, @"..");
            string destDirName = @"C:\temp\VentileClient\Versions\.data\com.mojang";

            if (!Directory.Exists(sourceDirName))
            {
                MAIN.Toast("Backup Error", "Sorry, please manually back up your com.mojang folder!");
                MAIN.versionLogger.Log("Directory didnt exist: " + sourceDirName);
                return;
            }

            try
            {
                await Task.Run(() =>
                {
                    if (Directory.Exists(destDirName)) Directory.Delete(destDirName, true);
                    FileSystem.CopyDirectory(sourceDirName, destDirName, true);
                    MAIN.versionLogger.Log("Backed up minecraft data!");
                    MAIN.Toast("Version Manager", "Finished backing up!");
                    MAIN.backedUp = true;
                    MAIN.backingUp = false;
                });
            }
            catch (Exception err)
            {
                MAIN.versionLogger.Log(err);
                MAIN.Toast("Backup Error", "Sorry, there was an error backing up!");
                MAIN.backedUp = true;
                MAIN.backingUp = false;
            }
        }
        public static async Task BackupAndRegister(string gameDir, Guna2Button sndr)
        {
            MAIN.versionLogger.Log("Starting backup and register");
            string sourceDirName = Path.Combine(MAIN.minecraftResourcePacks, @"..");
            string destDirName = @"C:\temp\VentileClient\Versions\.data\com.mojang";

            if (!Directory.Exists(sourceDirName))
            {
                MAIN.Toast("Backup Error", "Sorry, please manually back up your com.mojang folder!");
                MAIN.versionLogger.Log("Directory didn't exist! | " + sourceDirName);
                MAIN.backedUp = true;
                sndr.Enabled = true;
                return;
            }

            try
            {
                await Task.Run(async () =>
                {
                    if (Directory.Exists(destDirName)) Directory.Delete(destDirName, true);
                    FileSystem.CopyDirectory(sourceDirName, destDirName, true);
                    MAIN.backedUp = true;
                    MAIN.Toast("Version Manager", "Backup finished, changing version...");
                    await VersionManager.RegisterPackage(gameDir, sndr);
                });
            }
            catch (Exception err)
            {
                MAIN.versionLogger.Log(err);
                MAIN.Toast("Version Error", "Sorry, there was an error...");
                MAIN.backedUp = true;
                sndr.Enabled = true;
            }
        }
    }
}
