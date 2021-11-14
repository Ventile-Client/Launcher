using Octokit;
using System;
using System.Collections.Generic;
using System.IO;
using VentileClient.JSON_Template_Classes;
using VentileClient.Utils;

namespace VentileClient
{
    public class UpdateCheck
    {
        public async void CheckForUpdate(ThemeTemplate themeCS, VentileSettings ventileSettings, LinkSettings link_settings, bool internet, GitHubClient github)
        {
            if (!internet || !GithubManager.HaveRequests())
            {
                MainWindow.INSTANCE.fadeIn.Start();
                return;
            }

            // POSSIBLE: Remove api requests to github
            IReadOnlyList<Release> releases = await github.Repository.Release.GetAll(MainWindow.INSTANCE.link_settings.repoOwner, MainWindow.INSTANCE.link_settings.downloadRepo); // Gets all releases from the VersionChanger repo

            if (!(releases.Count > 0))
            {
                MainWindow.INSTANCE.dLogger.Log("No releases Found!");
                MainWindow.INSTANCE.fadeIn.Start();
                return;
            }

            if (new Version(releases[0].TagName) > ventileSettings.launcherVersion)
            {
                await DownloadManager.DownloadAsync($"https://github.com/{link_settings.repoOwner}/{link_settings.downloadRepo}/releases/download/{releases[0].TagName}/Changelog.txt", @"C:\temp\VentileClient", "Changelog.txt");

                string[] latestChangelog = File.ReadAllLines(@"C:\temp\VentileClient\Changelog.txt");

                File.Delete(@"C:\temp\VentileClient\Changelog.txt");

                MainWindow.INSTANCE.Opacity = 0;

                var updatePrompt = new UpdatePrompt(MainWindow.INSTANCE);
                updatePrompt.UpdateVersionText(latestChangelog, releases[0].TagName, themeCS);
                updatePrompt.Opacity = 0;
                updatePrompt.Show();

                return;
            }

            MainWindow.INSTANCE.fadeIn.Start();
        }
    }
}
