using Guna.UI2.WinForms;
using Octokit;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using VentileClient.Utils;

namespace VentileClient.LauncherUtils
{
    public static class DataManager
    {
        static MainWindow MAIN = MainWindow.INSTANCE;

        static string MC_RESOURCE = MAIN.minecraftResourcePacks;
        static LinkSettings LINK_SETTINGS = MAIN.link_settings;

        public static void Home()
        {
            // Reset button locations for bug
            MAIN.launchMc.Location = new Point(169, 171);
            MAIN.selectDll.Location = new Point(169, 248);
            MAIN.inject.Location = new Point(357, 248);

            // Visible buttons on home screen
            if (!MAIN.configCS.CustomDLL)
            {
                MAIN.selectDll.Visible = false;
                MAIN.launchMc.Location = new Point(169, 198);
            }
            else
            {
                MAIN.selectDll.Visible = true;
                MAIN.selectDll.Location = new Point(235, 248);
                MAIN.launchMc.Location = new Point(169, 171);
            }

            if (MAIN.configCS.AutoInject)
            {
                MAIN.inject.Visible = false;
            }
            else
            {
                MAIN.inject.Visible = true;
                MAIN.inject.Location = new Point(260, 248);
                MAIN.launchMc.Location = new Point(169, 171);
            }

            if (MAIN.configCS.CustomDLL && !MAIN.configCS.AutoInject)
            {
                MAIN.selectDll.Location = new Point(169, 248);
                MAIN.inject.Location = new Point(357, 248);
                MAIN.launchMc.Location = new Point(169, 171);
            }
        }

        public static async void Cosmetics()
        {
            //Cape Load
            if (MAIN.cosmeticsCS.cBlack)
            {
                if (!File.Exists(Path.Combine(MC_RESOURCE, @"BlackVentileCape.zip")))
                {
                    await DownloadManager.Download(string.Format(@"https://github.com/" + LINK_SETTINGS.repoOwner + "/" + LINK_SETTINGS.downloadRepo + @"/blob/main/Cosmetics/{0}?raw=true", "BlackVentileCape.zip"), MC_RESOURCE, "BlackVentileCape.zip");
                    CosmeticManager.Add(CosmeticManager.PACK_INFO.ElementAt(0).Key);
                }
                MAIN.cBlack.Checked = true;


            }
            else if (MAIN.cosmeticsCS.cWhite)
            {
                if (!File.Exists(Path.Combine(MC_RESOURCE, @"WhiteVentileCape.zip")))
                {
                    await DownloadManager.Download(string.Format(@"https://github.com/" + LINK_SETTINGS.repoOwner + "/" + LINK_SETTINGS.downloadRepo + @"/blob/main/Cosmetics/{0}?raw=true", "WhiteVentileCape.zip"), MC_RESOURCE, "WhiteVentileCape.zip");
                    CosmeticManager.Add(CosmeticManager.PACK_INFO.ElementAt(1).Key);
                }
                MAIN.cWhite.Checked = true;

            }
            else if (MAIN.cosmeticsCS.cPink)
            {
                if (!File.Exists(Path.Combine(MC_RESOURCE, @"PinkVentileCape.zip")))
                {
                    await DownloadManager.Download(string.Format(@"https://github.com/" + LINK_SETTINGS.repoOwner + "/" + LINK_SETTINGS.downloadRepo + @"/blob/main/Cosmetics/{0}?raw=true", "PinkVentileCape.zip"), MC_RESOURCE, "PinkVentileCape.zip");
                    CosmeticManager.Add(CosmeticManager.PACK_INFO.ElementAt(2).Key);
                }
                MAIN.cPink.Checked = true;

            }
            else if (MAIN.cosmeticsCS.cBlue)
            {
                if (!File.Exists(Path.Combine(MC_RESOURCE, @"BlueVentileCape.zip")))
                {
                    await DownloadManager.Download(string.Format(@"https://github.com/" + LINK_SETTINGS.repoOwner + "/" + LINK_SETTINGS.downloadRepo + @"/blob/main/Cosmetics/{0}?raw=true", "BlueVentileCape.zip"), MC_RESOURCE, "BlueVentileCape.zip");
                    CosmeticManager.Add(CosmeticManager.PACK_INFO.ElementAt(3).Key);
                }
                MAIN.cBlue.Checked = true;

            }
            else if (MAIN.cosmeticsCS.cYellow)
            {
                if (!File.Exists(Path.Combine(MC_RESOURCE, @"YellowVentileCape.zip")))
                {
                    await DownloadManager.Download(string.Format(@"https://github.com/" + LINK_SETTINGS.repoOwner + "/" + LINK_SETTINGS.downloadRepo + @"/blob/main/Cosmetics/{0}?raw=true", "YellowVentileCape.zip"), MC_RESOURCE, "YellowVentileCape.zip");
                    CosmeticManager.Add(CosmeticManager.PACK_INFO.ElementAt(4).Key);
                }
                MAIN.cYellow.Checked = true;

            }
            else if (MAIN.cosmeticsCS.cRick)
            {
                if (!File.Exists(Path.Combine(MC_RESOURCE, @"RickVentileCape.zip")))
                {
                    await DownloadManager.Download(string.Format(@"https://github.com/" + LINK_SETTINGS.repoOwner + "/" + LINK_SETTINGS.downloadRepo + @"/blob/main/Cosmetics/{0}?raw=true", "RickVentileCape.zip"), MC_RESOURCE, "RickVentileCape.zip");
                    CosmeticManager.Add(CosmeticManager.PACK_INFO.ElementAt(5).Key);
                }
                MAIN.cRick.Checked = true;

            }

            //Mask Load
            if (MAIN.cosmeticsCS.mBlack)
            {
                if (!File.Exists(Path.Combine(MC_RESOURCE, @"BlackVentileMask.zip")))
                {
                    await DownloadManager.Download(string.Format(@"https://github.com/" + LINK_SETTINGS.repoOwner + "/" + LINK_SETTINGS.downloadRepo + @"/blob/main/Cosmetics/{0}?raw=true", "BlackVentileMask.zip"), MC_RESOURCE, "BlackVentileMask.zip");
                    CosmeticManager.Add(CosmeticManager.PACK_INFO.ElementAt(6).Key);
                }
                MAIN.mBlack.Checked = true;

            }
            else if (MAIN.cosmeticsCS.mWhite)
            {
                if (!File.Exists(Path.Combine(MC_RESOURCE, @"WhiteVentileMask.zip")))
                {
                    await DownloadManager.Download(string.Format(@"https://github.com/" + LINK_SETTINGS.repoOwner + "/" + LINK_SETTINGS.downloadRepo + @"/blob/main/Cosmetics/{0}?raw=true", "WhiteVentileMask.zip"), MC_RESOURCE, "WhiteVentileMask.zip");
                    CosmeticManager.Add(CosmeticManager.PACK_INFO.ElementAt(7).Key);
                }
                MAIN.mWhite.Checked = true;

            }
            else if (MAIN.cosmeticsCS.mPink)
            {
                if (!File.Exists(Path.Combine(MC_RESOURCE, @"PinkVentileMask.zip")))
                {
                    await DownloadManager.Download(string.Format(@"https://github.com/" + LINK_SETTINGS.repoOwner + "/" + LINK_SETTINGS.downloadRepo + @"/blob/main/Cosmetics/{0}?raw=true", "PinkVentileMask.zip"), MC_RESOURCE, "PinkVentileMask.zip");
                    CosmeticManager.Add(CosmeticManager.PACK_INFO.ElementAt(8).Key);
                }
                MAIN.mPink.Checked = true;

            }
            else if (MAIN.cosmeticsCS.mBlue)
            {
                if (!File.Exists(Path.Combine(MC_RESOURCE, @"BlueVentileMask.zip")))
                {
                    await DownloadManager.Download(string.Format(@"https://github.com/" + LINK_SETTINGS.repoOwner + "/" + LINK_SETTINGS.downloadRepo + @"/blob/main/Cosmetics/{0}?raw=true", "BlueVentileMask.zip"), MC_RESOURCE, "BlueVentileMask.zip");
                    CosmeticManager.Add(CosmeticManager.PACK_INFO.ElementAt(9).Key);
                }
                MAIN.mBlue.Checked = true;

            }
            else if (MAIN.cosmeticsCS.mYellow)
            {
                if (!File.Exists(Path.Combine(MC_RESOURCE, @"BlackVentileMask.zip")))
                {
                    await DownloadManager.Download(string.Format(@"https://github.com/" + LINK_SETTINGS.repoOwner + "/" + LINK_SETTINGS.downloadRepo + @"/blob/main/Cosmetics/{0}?raw=true", "YellowVentileMask.zip"), MC_RESOURCE, "YellowVentileMask.zip");
                    CosmeticManager.Add(CosmeticManager.PACK_INFO.ElementAt(10).Key);
                }
                MAIN.mYellow.Checked = true;

            }
            else if (MAIN.cosmeticsCS.mRick)
            {
                if (!File.Exists(Path.Combine(MC_RESOURCE, @"RickVentileMask.zip")))
                {
                    await DownloadManager.Download(string.Format(@"https://github.com/" + LINK_SETTINGS.repoOwner + "/" + LINK_SETTINGS.downloadRepo + @"/blob/main/Cosmetics/{0}?raw=true", "RickVentileMask.zip"), MC_RESOURCE, "RickVentileMask.zip");
                    CosmeticManager.Add(CosmeticManager.PACK_INFO.ElementAt(11).Key);
                }
                MAIN.mRick.Checked = true;

            }

            //Load Extras
            if (MAIN.cosmeticsCS.aGlowing)
            {
                if (!File.Exists(Path.Combine(MC_RESOURCE, @"GlowingVentileCape.zip")))
                {
                    await DownloadManager.Download(string.Format(@"https://github.com/" + LINK_SETTINGS.repoOwner + "/" + LINK_SETTINGS.downloadRepo + @"/blob/main/Cosmetics/{0}?raw=true", "GlowingVentileCape.zip"), MC_RESOURCE, "GlowingVentileCape.zip");
                    CosmeticManager.Add(CosmeticManager.PACK_INFO.ElementAt(12).Key);
                }
                MAIN.aGlowing.Checked = true;

            }
            else if (MAIN.cosmeticsCS.aSlide)
            {
                if (!File.Exists(Path.Combine(MC_RESOURCE, @"SlidingVentileCape.zip")))
                {
                    await DownloadManager.Download(string.Format(@"https://github.com/" + LINK_SETTINGS.repoOwner + "/" + LINK_SETTINGS.downloadRepo + @"/blob/main/Cosmetics/{0}?raw=true", "SlidingVentileCape.zip"), MC_RESOURCE, "SlidingVentileCape.zip");
                    CosmeticManager.Add(CosmeticManager.PACK_INFO.ElementAt(13).Key);
                }
                MAIN.aSlide.Checked = true;

            }
            else if (MAIN.cosmeticsCS.oWavy)
            {
                if (!File.Exists(Path.Combine(MC_RESOURCE, @"WavyVentile.zip")))
                {
                    await DownloadManager.Download(string.Format(@"https://github.com/" + LINK_SETTINGS.repoOwner + "/" + LINK_SETTINGS.downloadRepo + @"/blob/main/Cosmetics/{0}?raw=true", "WavyVentile.zip"), MC_RESOURCE, "WavyVentile.zip");
                    CosmeticManager.Add(CosmeticManager.PACK_INFO.ElementAt(14).Key);
                }
                MAIN.oWavy.Checked = true;

            }
            else if (MAIN.cosmeticsCS.oKagune)
            {
                if (!File.Exists(Path.Combine(MC_RESOURCE, @"KaguneVentile.zip")))
                {
                    await DownloadManager.Download(string.Format(@"https://github.com/" + LINK_SETTINGS.repoOwner + "/" + LINK_SETTINGS.downloadRepo + @"/blob/main/Cosmetics/{0}?raw=true", "KaguneVentile.zip"), MC_RESOURCE, "KaguneVentile.zip");
                    CosmeticManager.Add(CosmeticManager.PACK_INFO.ElementAt(15).Key);
                }
                MAIN.oKagune.Checked = true;

            }

            if (File.Exists(Path.Combine(MC_RESOURCE, @"CosmeticMixer.zip")))
            {
                File.Delete(Path.Combine(MC_RESOURCE, @"CosmeticMixer.zip"));
            }

            await DownloadManager.Download(string.Format(@"https://github.com/" + LINK_SETTINGS.repoOwner + "/" + LINK_SETTINGS.downloadRepo + @"/blob/main/Cosmetics/{0}?raw=true", "CosmeticMixer.zip"), MC_RESOURCE, "CosmeticMixer.zip");

            CosmeticManager.Remove("b6039dbe-c5f1-4544-afdb-dd4b9ed7d19e");
            CosmeticManager.Add("b6039dbe-c5f1-4544-afdb-dd4b9ed7d19e");
        }

        public static async void Version()
        {
            //Colors
            // Make the color variable smaller
            Color backColor = ColorTranslator.FromHtml(MAIN.themeCS.Background);
            Color accentColor = ColorTranslator.FromHtml(MAIN.themeCS.Accent);
            Color foreColor = ColorTranslator.FromHtml(MAIN.themeCS.Foreground);
            Color outlineColor = ColorTranslator.FromHtml(MAIN.themeCS.Outline);
            Color fadedColor = ColorTranslator.FromHtml(MAIN.themeCS.Faded);
            Color backColor2 = ColorTranslator.FromHtml(MAIN.themeCS.SecondBackground);

            //Settings
            int progressWidth = 410;
            int buttonWidth = 150;
            int spacing = 30;
            int topOffset = 15;
            int rightOffset = 42;
            int rightButtonOffset = 70;

            MAIN.versionsPanel.Controls.Clear();

            MAIN.versionsPanel.Size = MAIN.contentView.Size;
            MAIN.versionsPanel.Width = MAIN.contentView.Width + rightOffset;

            //contentView.Width = 644 + rightOffset;
            MAIN.versionsPanel.AutoScroll = true;

            if (!MAIN.internet) //Displays a tab that says you don't have internet
            {
                var lbl = new System.Windows.Forms.Label()
                {
                    AutoSize = true,
                    Text = "No Internet...",
                    Font = new Font("Segoe UI", 20.25f, FontStyle.Bold),
                    Location = new Point(5, topOffset),
                    ForeColor = foreColor
                };
                lbl.BringToFront();
                MAIN.versionsPanel.Controls.Add(lbl);

                var noInternet = new System.Windows.Forms.Label()
                {
                    AutoSize = true,
                    Text = "Cannot retrieve data!\n - A firewall isn't allowing the launcher to acess the internet\n - You don't have an internet connection\n - If a reason isn't listed here, ask for help or contact thedevs!",
                    Font = new Font("Segoe UI", 14.25f),
                    Location = new Point(9, spacing + topOffset * 2),
                    ForeColor = foreColor
                };
                noInternet.BringToFront();
                MAIN.versionsPanel.Controls.Add(noInternet);

                MAIN.contentView.SelectedTab = MAIN.versionsTab;

                return;

            }

            // Title Of Panel
            var label = new System.Windows.Forms.Label()
            {

                AutoSize = true,
                Text = "Version Selector",
                Font = new Font("Segoe UI", 20.25f, FontStyle.Bold),
                Location = new Point(5, 14),
                ForeColor = foreColor
            };
            label.BringToFront();

            MAIN.versionsPanel.Controls.Add(label);


            // New List of class Version
            var versions = new List<Version>();

            IReadOnlyList<Release> releases = await MAIN.github.Repository.Release.GetAll(LINK_SETTINGS.repoOwner, LINK_SETTINGS.versionsRepo); // Gets all releases from the VersionChanger repo

            foreach (Release release in releases) // Used to sort and add versions to the versions list
            {
                var v = new Version(release.TagName);
                versions.Add(v);
            }

            versions.Sort(new VersionSorter()); //Sorts the versions becus mc versions system is trash

            int index = 0; // Positive Index 
            for (int i = versions.Count - 1; i > -1; i--) // Backwards for loop to make versions go from Newest down to Oldest
            {
                index++;

                // Label for version
                var versionName = new System.Windows.Forms.Label()
                {
                    Name = "versionLabel" + i.ToString(),
                    Text = versions[i].ToString(),
                    Tag = versions[i].ToString(),
                    Font = new Font("Segoe UI", 14.25f),
                    AutoSize = true,
                    ForeColor = foreColor
                };
                versionName.Location = new Point(9, (versionName.Height + spacing) * index + topOffset);


                // Progress Bar for downloading/extracting progress
                var bar = new Guna2ProgressBar
                {
                    Name = "versionBar" + i.ToString(),
                    UseTransparentBackground = true,
                    Tag = "bar|" + versionName.Tag,
                    Height = versionName.Height - 5,
                    Width = progressWidth,
                    ForeColor = foreColor,
                    FillColor = backColor2,
                    ProgressBrushMode = Guna.UI2.WinForms.Enums.BrushMode.Gradient,
                    ProgressColor = accentColor,

                    ProgressColor2 = Color.FromArgb
                    (
                    accentColor.R - MAIN.progressBarGradientOffset > 0 ? accentColor.R - MAIN.progressBarGradientOffset :
                    accentColor.R + MAIN.progressBarGradientOffset < 255 ? accentColor.R + MAIN.progressBarGradientOffset : accentColor.R,

                    accentColor.R - MAIN.progressBarGradientOffset > 0 ? accentColor.R - MAIN.progressBarGradientOffset :
                    accentColor.R + MAIN.progressBarGradientOffset < 255 ? accentColor.R + MAIN.progressBarGradientOffset : accentColor.R,

                    accentColor.B - MAIN.progressBarGradientOffset > 0 ? accentColor.B - MAIN.progressBarGradientOffset :
                    accentColor.B + MAIN.progressBarGradientOffset < 255 ? accentColor.B + MAIN.progressBarGradientOffset : accentColor.B
                    ),

                    Location = new Point(versionName.Location.X + 15, versionName.Location.Y + 30),
                    Visible = false,
                    TabStop = false
                };
                Guna2ProgressBar.CheckForIllegalCrossThreadCalls = false;

                // Button to download appx from VersionChanger repo
                var download = new Guna2Button();
                download.Click += new EventHandler(DownloadVersion_Clicked);
                download.Name = "versionDownload" + i.ToString();
                download.Text = "Download";
                download.Tag = "download|" + versionName.Tag;
                download.Font = new Font("Segoe UI", 14.25f, FontStyle.Bold);
                download.Width = buttonWidth;
                download.Height = versionName.Height + 10;
                download.ForeColor = foreColor;
                download.FillColor = backColor2;
                download.CheckedState.FillColor = accentColor;
                download.Checked = false;
                download.UseTransparentBackground = true;
                download.Location = new Point(MAIN.versionsPanel.Width - download.Width - (rightButtonOffset), versionName.Location.Y);
                download.Animated = true;
                download.TabStop = false;
                Guna2Button.CheckForIllegalCrossThreadCalls = false;

                // Select the version
                var select = new Guna2Button();
                select.Click += new EventHandler(SelectVersion_Clicked);
                select.Name = "versionsSelect" + i.ToString();
                select.Text = "Select";
                select.Tag = "select|" + versionName.Tag;
                select.Font = new Font("Segoe UI", 14.25f, FontStyle.Bold);
                select.Width = buttonWidth;
                select.Height = versionName.Height + 10;
                select.ForeColor = foreColor;
                select.FillColor = backColor2;
                select.CheckedState.FillColor = accentColor;
                select.Checked = false;
                select.UseTransparentBackground = true;
                select.Location = new Point(MAIN.versionsPanel.Width - select.Width - (rightButtonOffset), versionName.Location.Y);
                select.Animated = true;
                select.TabStop = false;
                select.Visible = false;

                // Delete the version
                var uninstall = new Guna2Button();
                uninstall.Click += new EventHandler(UninstallVersion_Clicked);
                uninstall.Name = "versionUninstall" + i.ToString();
                uninstall.Text = "Uninstall";
                uninstall.Tag = "uninstall|" + versionName.Tag;
                uninstall.Font = new Font("Segoe UI", 14.25f, FontStyle.Bold);
                uninstall.Width = buttonWidth;
                uninstall.Height = versionName.Height + 10;
                uninstall.ForeColor = foreColor;
                uninstall.FillColor = backColor2;
                uninstall.CheckedState.FillColor = accentColor;
                uninstall.Checked = false;
                uninstall.UseTransparentBackground = true;
                uninstall.Location = new Point(MAIN.versionsPanel.Width - uninstall.Width * 2 - (10 + rightButtonOffset), versionName.Location.Y);
                uninstall.Animated = true;
                uninstall.TabStop = false;
                uninstall.Visible = false;

                // Add Buttons to stuff ykyk
                MAIN.versionsPanel.Controls.Add(versionName);
                MAIN.versionsPanel.Controls.Add(download);
                MAIN.versionsPanel.Controls.Add(bar);
                MAIN.versionsPanel.Controls.Add(select);
                MAIN.versionsPanel.Controls.Add(uninstall);
            }
            //Make there be a little extra space at the bottom of panel

            MAIN.versionsTab.Controls.Add(MAIN.versionsPanel);

            MAIN.versionsPanel.Size = new Size(MAIN.versionsPanel.Width, MAIN.versionsPanel.Height + topOffset * 2);
            // Refreshes The Currently Installed Versions
            RefreshVersionList(versions);
        }

        public static void Settings()
        {
            MAIN.hideWindow.Checked = false;
            MAIN.minWindow.Checked = false;
            MAIN.closeWindow.Checked = false;
            MAIN.openWindow.Checked = false;

            //Window State
            if (MAIN.configCS.WindowState == "hide")
            {
                MAIN.hideWindow.Checked = true;
            }
            else if (MAIN.configCS.WindowState == "minimize")
            {
                MAIN.minWindow.Checked = true;
            }
            else if (MAIN.configCS.WindowState == "close")
            {
                MAIN.closeWindow.Checked = true;
            }
            else
            {
                MAIN.openWindow.Checked = true;
            }

            //RPC
            if (MAIN.configCS.RichPresence)
            {
                MAIN.RpcToggle.Checked = true;
                MAIN.RpcToggle.Text = "On";
                MAIN.rpcLine.Text = MAIN.configCS.RpcText;
                MAIN.rpcLine.Visible = true;
            }
            else
            {
                MAIN.RpcToggle.Checked = false;
                MAIN.RpcToggle.Text = "Off";
                MAIN.rpcLine.Visible = false;
            }

            if (MAIN.configCS.RpcButton)
            {
                MAIN.buttonForRpc.Checked = true;
                MAIN.buttonForRpc.Visible = true;
                MAIN.rpcButtonText.Visible = true;
                MAIN.rpcButtonLink.Visible = true;
                MAIN.rpcButtonTextLabel.Visible = true;
                MAIN.rpcButtonLinkLabel.Visible = true;

                MAIN.rpcButtonLink.Text = MAIN.configCS.RpcButtonLink;
                MAIN.rpcButtonText.Text = MAIN.configCS.RpcButtonText;
            }
            else
            {
                MAIN.buttonForRpc.Visible = false;
                MAIN.rpcButtonText.Visible = false;
                MAIN.rpcButtonLink.Visible = false;
                MAIN.rpcButtonTextLabel.Visible = false;
                MAIN.rpcButtonLinkLabel.Visible = false;
            }

            //Dev DLL
            if (MAIN.configCS.CustomDLL)
            {
                MAIN.customDLLButton.Checked = true;
            }
            else
            {
                MAIN.customDLLButton.Checked = false;
            }

            //Inject Delay
            MAIN.injectDelay.Value = MAIN.configCS.InjectDelay;

            //Auto Inject
            if (MAIN.configCS.AutoInject)
            {
                MAIN.configCS.AutoInject = true;
                MAIN.autoInject.Checked = true;
                MAIN.autoInject.Text = "On";
            }
            else
            {
                MAIN.configCS.AutoInject = false;
                MAIN.autoInject.Checked = false;
                MAIN.autoInject.Text = "Off";
            }

            //Theme
            if (MAIN.themeCS.Theme == "dark")
            {
                MAIN.theme.Text = "Dark";
            }
            else
            {
                MAIN.theme.Text = "Light";
            }

            //Background Iamge
            if (MAIN.configCS.BackgroundImage)
            {
                MAIN.customImage.Checked = true;
                MAIN.customImage.Text = "On";
            }
            else
            {
                MAIN.customImage.Checked = false;
                MAIN.customImage.Text = "Off";
            }

            //Toasts
            if (MAIN.configCS.Toasts)
            {
                MAIN.toastsToggle.Checked = true;
                MAIN.toastsToggle.Text = "On";

                if (MAIN.configCS.ToastsLoc == "topRight")
                    MAIN.toastsSelector.SelectedItem = "Top Right";
                else if (MAIN.configCS.ToastsLoc == "bottomRight")
                    MAIN.toastsSelector.SelectedItem = "Bottom Right";
                else if (MAIN.configCS.ToastsLoc == "topLeft")
                    MAIN.toastsSelector.SelectedItem = "Top Left";
                else if (MAIN.configCS.ToastsLoc == "bottomLeft")
                    MAIN.toastsSelector.SelectedItem = "Bottom Left";

                MAIN.toastsSelector.Visible = true;
            }
            else
            {
                MAIN.toastsToggle.Checked = false;
                MAIN.toastsToggle.Text = "Off";
                MAIN.toastsSelector.Visible = false;
            }

            //Rounded Buttons
            if (MAIN.configCS.RoundedButtons)
            {
                MAIN.roundedToggle.Checked = true;
                MAIN.roundedToggle.Text = "On";
            }
            else
            {
                MAIN.roundedToggle.Checked = false;
                MAIN.roundedToggle.Text = "Off";
            }

            //Performance Mode
            if (MAIN.configCS.PerformanceMode)
            {
                MAIN.performanceModeToggle.Checked = true;
                MAIN.performanceModeToggle.Text = "On";
            }
            else
            {
                MAIN.performanceModeToggle.Checked = false;
                MAIN.performanceModeToggle.Text = "Off";
            }

            //Appearance Sliders
            int value = ColorTranslator.FromHtml(MAIN.themeCS.Background).R;

            MAIN.backgroundBrightnessSlider.Value = value;
            MAIN.backgroundBT.Text = value.ToString();

            value = ColorTranslator.FromHtml(MAIN.themeCS.Accent).R;
            MAIN.accentRedSlider.Value = value;
            MAIN.accentRT.Text = value.ToString();

            value = ColorTranslator.FromHtml(MAIN.themeCS.Accent).G;
            MAIN.accentGreenSlider.Value = value;
            MAIN.accentGT.Text = value.ToString();

            value = ColorTranslator.FromHtml(MAIN.themeCS.Accent).B;
            MAIN.accentBlueSlider.Value = value;
            MAIN.accentBT.Text = value.ToString();

            value = ColorTranslator.FromHtml(MAIN.themeCS.Outline).R;
            MAIN.outlineBrightnessSlider.Value = value;
            MAIN.outlineOT.Text = value.ToString();

            value = ColorTranslator.FromHtml(MAIN.themeCS.SecondBackground).R;
            MAIN.buttonBrightnessSlider.Value = value;
            MAIN.buttonBuT.Text = value.ToString();

            value = ColorTranslator.FromHtml(MAIN.themeCS.Foreground).R;
            MAIN.textBrightnessSlider.Value = value;
            MAIN.foreBT.Text = value.ToString();
        }

        public static void About()
        {
            MAIN.launcherVLabel.Text = MAIN.ventile_settings.launcherVersion;
            MAIN.clientVLabel.Text = MAIN.ventile_settings.clientVersion;
            MAIN.cosmeticsVLabel.Text = MAIN.ventile_settings.cosmeticsVersion;
        }

        public static async void DLLS()
        {
            MAIN.DefaultDLLSelector.Items.Clear();

            if (Directory.Exists(@"C:\temp\VentileClient\Dlls")) Directory.Delete(@"C:\temp\VentileClient\DLLS", true);

            Directory.CreateDirectory(@"C:\temp\VentileClient\Dlls");

            IReadOnlyList<RepositoryContent> contents = await MAIN.github.Repository.Content.GetAllContents(LINK_SETTINGS.repoOwner, LINK_SETTINGS.downloadRepo, @"Dlls\");

            foreach (RepositoryContent dll in contents)
            {
                if (dll.Type == "file" && dll.Name.EndsWith(".dll"))
                {
                    await DownloadManager.Download(dll.DownloadUrl, @"C:\temp\VentileClient\Dlls", dll.Name);

                    var item = new ToolStripMenuItem()
                    {
                        Tag = dll.Name,
                        Text = dll.Name
                    };

                    item.Click += Item_Click;
                    MAIN.DefaultDLLSelector.Items.Add(item);
                }
            }
        }

        private static void Item_Click(object sender, EventArgs e)
        {
            MAIN.selectedDLLName = (sender as ToolStripMenuItem).Tag.ToString();
            if (MAIN.configCS.CustomDLL)
            {
                MAIN.Toast("DLL", "Disable Custom DLL to use the default ones!");
            }
        }

        #region Version Clicked Events

        private static async void DownloadVersion_Clicked(object sender, EventArgs e)
        {
            MAIN.allowClose++;

            var sndr = sender as Guna2Button;
            string version = ((Guna2Button)sender).Tag.ToString().Substring(sndr.Text.Length + 1);
            sndr.Enabled = false;

            await MCDataManager.Backup();
            await VersionManager.DownloadVersion(version, sndr);
        }
        private static async void SelectVersion_Clicked(object sender, EventArgs e)
        {
            var sndr = sender as Guna2Button;
            sndr.Enabled = false;
            if (MAIN.allowSelectVersion != 0)
            {
                MAIN.Toast("Version Manager", "Sorry, you are already selecting a version!");
                return;
            }
            MAIN.allowClose++;
            MAIN.allowSelectVersion++;
            string version = ((Guna2Button)sender).Tag.ToString().Substring(((Guna2Button)sender).Text.Length + 1);
            string gameDir = @"C:\temp\VentileClient\Versions\Minecraft-" + version;
            if (!Directory.Exists(gameDir))
            {
                MAIN.Toast("Version Manager", "Sorry, there was an error!");
                return;
            }

            await VersionManager.RegisterPackage(gameDir, sndr);
        }
        private static async void UninstallVersion_Clicked(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                MAIN.allowClose++;
                var sndr = sender as Guna2Button;
                string version = ((Guna2Button)sender).Tag.ToString().Substring(sndr.Text.Length + 1);
                var ctrl2 = (Guna2Button)ControlManager.GetControl("select|" + version, MAIN.versionsPanel);
                ctrl2.Invoke(new Action(() =>
                {
                    ctrl2.Enabled = false;
                    ctrl2.Visible = true;
                }));

                ctrl2 = (Guna2Button)ControlManager.GetControl("uninstall|" + version, MAIN.versionsPanel);
                ctrl2.Invoke(new Action(() =>
                {
                    ctrl2.Enabled = false;
                    ctrl2.Visible = true;
                }));
                if (Directory.Exists(@"C:\temp\VentileClient\Versions\" + "Minecraft-" + version))
                    Directory.Delete(@"C:\temp\VentileClient\Versions\" + "Minecraft-" + version, true);

                ctrl2 = (Guna2Button)ControlManager.GetControl("download|" + version, MAIN.versionsPanel);
                ctrl2.Invoke(new Action(() =>
                {
                    ctrl2.Enabled = true;
                    ctrl2.Visible = true;
                }));

                ctrl2 = (Guna2Button)ControlManager.GetControl("select|" + version, MAIN.versionsPanel);
                ctrl2.Invoke(new Action(() =>
                {
                    ctrl2.Enabled = true;
                    ctrl2.Visible = false;
                }));

                ctrl2 = (Guna2Button)ControlManager.GetControl("uninstall|" + version, MAIN.versionsPanel);
                ctrl2.Invoke(new Action(() =>
                {
                    ctrl2.Enabled = true;
                    ctrl2.Visible = false;
                }));
                MAIN.allowClose--;
            });
        }

        #endregion

        #region Version Extras

        private static void RefreshVersionList(List<Version> versions)
        {
            foreach (Version version in versions)
            {
                string dirnameSub = version.ToString();
                if (Directory.Exists(@"C:\temp\VentileClient\Versions\Minecraft-" + dirnameSub))
                {
                    var bar = (Guna2ProgressBar)ControlManager.GetControl("bar|" + dirnameSub, MAIN.versionsPanel);
                    var download = (Guna2Button)ControlManager.GetControl("download|" + dirnameSub, MAIN.versionsPanel);
                    var uninstall = (Guna2Button)ControlManager.GetControl("uninstall|" + dirnameSub, MAIN.versionsPanel);
                    var select = (Guna2Button)ControlManager.GetControl("select|" + dirnameSub, MAIN.versionsPanel);

                    bar.Visible = false;
                    download.Visible = false;
                    uninstall.Visible = true;
                    select.Visible = true;
                }
            }
            MAIN.Refresh();
        }

        #endregion
    }
}
