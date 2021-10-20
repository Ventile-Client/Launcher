﻿using Octokit;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using VentileClient.JSON_Template_Classes;
using VentileClient.Utils;

namespace VentileClient
{
    public class UpdateCheck
    {
        public async void CheckForUpdate(ThemeTemplate themeCS, VentileSettings ventileSettings, LinkSettings link_settings, bool internet, GitHubClient github)
        {
            if (File.Exists(@"C:\temp\VentileClient\Version.txt"))
            {
                File.Delete(@"C:\temp\VentileClient\Version.txt");
            }

            if (File.Exists(@"C:\temp\VentileClient\Version.zip"))
            {
                File.Delete(@"C:\temp\VentileClient\Version.zip");
            }

            if (!internet || !GithubManager.HaveRequests())
            {
                MainWindow.INSTANCE.fadeIn.Start();
                return;
            }

            IReadOnlyList<Release> releases = await github.Repository.Release.GetAll(MainWindow.INSTANCE.link_settings.repoOwner, MainWindow.INSTANCE.link_settings.downloadRepo); // Gets all releases from the VersionChanger repo

            if (!(releases.Count > 0))
            {
                Debug.WriteLine("No releases Found!");
                MainWindow.INSTANCE.fadeIn.Start();
                return;
            }

            if (releases[0].TagName != ventileSettings.launcherVersion && !ventileSettings.isBeta)
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
