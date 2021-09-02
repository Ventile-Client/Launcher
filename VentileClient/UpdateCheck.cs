using Octokit;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using VentileClient.JSON_Template_Classes;

namespace VentileClient
{
    public class UpdateCheck
    {
        #region Downloading Code

        public void Download(string link, string path, string name)
        {
            using (var Client = new WebClient())
            {
                if (path.EndsWith(@"\"))
                {
                    Client.DownloadFile(link, path + name);
                }
                else
                {
                    Client.DownloadFile(link, path + @"\" + name);
                }
            }
        }

        #endregion Downloading Code

        public async void CheckForUpdate(ThemeTemplate themeCS, VentileSettings ventileSettings, bool internet, GitHubClient github)
        {
            if (File.Exists(@"C:\temp\VentileClient\Version.txt"))
            {
                File.Delete(@"C:\temp\VentileClient\Version.txt");
            }

            if (File.Exists(@"C:\temp\VentileClient\Version.zip"))
            {
                File.Delete(@"C:\temp\VentileClient\Version.zip");
            }

            if (!internet) return;

            IReadOnlyList<Release> releases = await github.Repository.Release.GetAll(MainWindow.LINK_SETTINGS.repoOwner, MainWindow.LINK_SETTINGS.downloadRepo); // Gets all releases from the VersionChanger repo

            if (!(releases.Count > 0))
            {
                Debug.WriteLine("No releases Found!");
                MainWindow.INSTANCE.fadeIn.Start();
                return;
            }

            Download(string.Format(@"https://github.com/" + MainWindow.LINK_SETTINGS.repoOwner + "/" + MainWindow.LINK_SETTINGS.downloadRepo + "/releases/download/{0}/{1}", releases[0].TagName, "Changelog.txt"), @"C:\temp\VentileClient", "Changelog.txt");

            string[] changelog = File.ReadAllLines(@"C:\temp\VentileClient\Changelog.txt");

            File.Delete(@"C:\temp\VentileClient\Changelog.txt");

            if (releases[0].TagName != ventileSettings.launcherVersion && !ventileSettings.isBeta)
            {
                MainWindow.INSTANCE.Opacity = 0;

                var updatePrompt = new UpdatePrompt(MainWindow.INSTANCE);
                updatePrompt.UpdateVersionText(changelog, releases[0].TagName, themeCS);
                updatePrompt.Opacity = 0;
                updatePrompt.Show();

                return;
            }
            MainWindow.INSTANCE.fadeIn.Start();
        }
    }
}
