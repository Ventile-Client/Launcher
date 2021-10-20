using Guna.UI2.WinForms;
using System;
using System.IO;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Foundation;
using Windows.Management.Core;
using Windows.Management.Deployment;
namespace VentileClient.Utils
{
    public static class VersionManager3
    {
        static MainWindow MAIN = MainWindow.INSTANCE;
        static string MINECRAFT_NAME = "Microsoft.MinecraftUWP_8wekyb3d8bbwe";
        public static async Task ReRegisterPackage(string version, string gameDirectory, Guna2Button sndr)
        {
            await Task.Run(() =>
            {
                foreach (Package package in new PackageManager().FindPackages(MINECRAFT_NAME))
                {
                    string loc = PackagePath(package);
                    if (loc == gameDirectory)
                    {
                        MAIN.vLogger.Log($"Skipped Package Removal: {package.Id.FullName} : {loc}");
                        return;
                    }
                    //await RemovePackage(package);
                }
                MAIN.vLogger.Log($"Registering Package");
                string maniPath = Path.Combine(gameDirectory, "AppxManifest.xml");
                //await DeploymentProgressWrapper(new PackageManager().RegisterPackageAsync(new Uri(maniPath), null, DeploymentOptions.DevelopmentMode));
                MAIN.vLogger.Log($"Registered Package!");
                Notif.Toast("Version Manager", $"Switched Version: {version}");
                //await RestoreMCData();
                MAIN.allowSelectVersion--;
                MAIN.allowClose--;
                sndr.Enabled = true;
            });
        }

        public static async Task RemovePackage(Package package)
        {
            MAIN.vLogger.Log($"Removing Package: {package.Id.FullName}");
            if (package.IsDevelopmentMode)
            {
                MAIN.vLogger.Log($"Package is in development mode.");
                await DeploymentProgressWrapper(new PackageManager().RemovePackageAsync(package.Id.FullName, RemovalOptions.PreserveApplicationData));
            }
            else
            {
                await BackupMCData();
                await DeploymentProgressWrapper(new PackageManager().RemovePackageAsync(package.Id.FullName, 0));
            }
        }

        private static async Task BackupMCData()
        {
            await Task.Run(() =>
            {

                var data = ApplicationDataManager.CreateForPackageFamily(MINECRAFT_NAME);
                string toDir = @"C:\temp\VentileClient\Profiles\Default";
                if (Directory.Exists(toDir))
                {
                    Directory.Delete(toDir, true);
                }
                MAIN.vLogger.Log($"Moving Minecraft data to: {toDir}");
                Directory.Move(data.LocalFolder.Path, toDir);
            });
        }

        private static async Task RestoreMCData()
        {
            await Task.Run(() =>
            {
                if (!Directory.Exists(Path.Combine(@"C:\temp\VentileClient\Profiles\", (MAIN.configCS.DefaultProfile ?? "Default"))))
                    return;

                var data = ApplicationDataManager.CreateForPackageFamily(MINECRAFT_NAME);
                MAIN.vLogger.Log($"Creating Shortcut To Profile: {(MAIN.configCS.DefaultProfile ?? "Default")} in: {data.LocalFolder.Path}");
                Shortcuts.Create(Path.Combine(@"C:\temp\VentileClient\Profiles\", (MAIN.configCS.DefaultProfile ?? "Default")), Path.Combine(data.LocalFolder.Path, "games"), "com.mojang");
                MAIN.vLogger.Log($"Created Shortcut!");
            });
        }

        private static string PackagePath(Package pkg)
        {
            try
            {
                return pkg.InstalledLocation.Path;
            }
            catch (FileNotFoundException)
            {
                return "";
            }
        }

        private static async Task DeploymentProgressWrapper(IAsyncOperationWithProgress<DeploymentResult, DeploymentProgress> t)
        {
            TaskCompletionSource<int> src = new TaskCompletionSource<int>();
            t.Progress += (v, p) =>
            {
                MAIN.vLogger.Log($"Deployment progress: {p.state} {p.percentage}%");
            };
            t.Completed += (v, p) =>
            {
                if (p == AsyncStatus.Error)
                {
                    MAIN.vLogger.Log($"Deployment failed: {v.GetResults().ErrorText}");
                    src.SetException(new Exception($"Deployment failed: {v.GetResults().ErrorText}"));
                }
                else
                {
                    MAIN.vLogger.Log($"Deployment completed: {p}");
                    src.SetResult(1);
                }
            };
            await src.Task;
        }

    }
}
