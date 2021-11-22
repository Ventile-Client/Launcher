using FontAwesome.Sharp;
using Guna.UI2.WinForms;
using Octokit;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using VentileClient.Classes;
using VentileClient.JSON_Template_Classes;
using VentileClient.Utils;

namespace VentileClient.LauncherUtils
{
    public static class DataManager
    {
        static MainWindow MAIN = MainWindow.INSTANCE;

        static string MC_RESOURCE = MAIN.minecraftResourcePacks;
        static LinkSettings LINK_SETTINGS = MAIN.link_settings;

        public static async void Home()
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

            MAIN.SelectDLLTooltip.SetToolTip(MAIN.selectDll, MAIN.configCS.DefaultDLL ?? "None...");
            MAIN.minecraftVersion.Text = await MCDataManager.GetMCVersion();

        }

        public static async void Cosmetics()
        {
            //Cape Load
            if (MAIN.cosmeticsCS.cBlack)
            {
                if (!File.Exists(Path.Combine(MC_RESOURCE, @"BlackVentileCape.zip")))
                {
                    await DownloadManager.DownloadAsync(string.Format(@"https://github.com/" + LINK_SETTINGS.repoOwner + "/" + LINK_SETTINGS.downloadRepo + @"/blob/main/Cosmetics/{0}?raw=true", "BlackVentileCape.zip"), MC_RESOURCE, "BlackVentileCape.zip");
                    CosmeticManager.Add(CosmeticManager.Pack.BlackCape);
                }
                MAIN.cBlack.Checked = true;
            }
            else if (MAIN.cosmeticsCS.cWhite)
            {
                if (!File.Exists(Path.Combine(MC_RESOURCE, @"WhiteVentileCape.zip")))
                {
                    await DownloadManager.DownloadAsync(string.Format(@"https://github.com/" + LINK_SETTINGS.repoOwner + "/" + LINK_SETTINGS.downloadRepo + @"/blob/main/Cosmetics/{0}?raw=true", "WhiteVentileCape.zip"), MC_RESOURCE, "WhiteVentileCape.zip");
                    CosmeticManager.Add(CosmeticManager.Pack.WhiteCape);
                }
                MAIN.cWhite.Checked = true;
            }
            else if (MAIN.cosmeticsCS.cPink)
            {
                if (!File.Exists(Path.Combine(MC_RESOURCE, @"PinkVentileCape.zip")))
                {
                    await DownloadManager.DownloadAsync(string.Format(@"https://github.com/" + LINK_SETTINGS.repoOwner + "/" + LINK_SETTINGS.downloadRepo + @"/blob/main/Cosmetics/{0}?raw=true", "PinkVentileCape.zip"), MC_RESOURCE, "PinkVentileCape.zip");
                    CosmeticManager.Add(CosmeticManager.Pack.PinkCape);
                }
                MAIN.cPink.Checked = true;
            }
            else if (MAIN.cosmeticsCS.cBlue)
            {
                if (!File.Exists(Path.Combine(MC_RESOURCE, @"BlueVentileCape.zip")))
                {
                    await DownloadManager.DownloadAsync(string.Format(@"https://github.com/" + LINK_SETTINGS.repoOwner + "/" + LINK_SETTINGS.downloadRepo + @"/blob/main/Cosmetics/{0}?raw=true", "BlueVentileCape.zip"), MC_RESOURCE, "BlueVentileCape.zip");
                    CosmeticManager.Add(CosmeticManager.Pack.BlueCape);
                }
                MAIN.cBlue.Checked = true;

            }
            else if (MAIN.cosmeticsCS.cYellow)
            {
                if (!File.Exists(Path.Combine(MC_RESOURCE, @"YellowVentileCape.zip")))
                {
                    await DownloadManager.DownloadAsync(string.Format(@"https://github.com/" + LINK_SETTINGS.repoOwner + "/" + LINK_SETTINGS.downloadRepo + @"/blob/main/Cosmetics/{0}?raw=true", "YellowVentileCape.zip"), MC_RESOURCE, "YellowVentileCape.zip");
                    CosmeticManager.Add(CosmeticManager.Pack.YellowCape);
                }
                MAIN.cYellow.Checked = true;
            }
            else if (MAIN.cosmeticsCS.cRick)
            {
                if (!File.Exists(Path.Combine(MC_RESOURCE, @"RickVentileCape.zip")))
                {
                    await DownloadManager.DownloadAsync(string.Format(@"https://github.com/" + LINK_SETTINGS.repoOwner + "/" + LINK_SETTINGS.downloadRepo + @"/blob/main/Cosmetics/{0}?raw=true", "RickVentileCape.zip"), MC_RESOURCE, "RickVentileCape.zip");
                    CosmeticManager.Add(CosmeticManager.Pack.RickCape);
                }
                MAIN.cRick.Checked = true;
            }

            //Mask Load
            if (MAIN.cosmeticsCS.mBlack)
            {
                if (!File.Exists(Path.Combine(MC_RESOURCE, @"BlackVentileMask.zip")))
                {
                    await DownloadManager.DownloadAsync(string.Format(@"https://github.com/" + LINK_SETTINGS.repoOwner + "/" + LINK_SETTINGS.downloadRepo + @"/blob/main/Cosmetics/{0}?raw=true", "BlackVentileMask.zip"), MC_RESOURCE, "BlackVentileMask.zip");
                    CosmeticManager.Add(CosmeticManager.Pack.BlackMask);
                }
                MAIN.mBlack.Checked = true;

            }
            else if (MAIN.cosmeticsCS.mWhite)
            {
                if (!File.Exists(Path.Combine(MC_RESOURCE, @"WhiteVentileMask.zip")))
                {
                    await DownloadManager.DownloadAsync(string.Format(@"https://github.com/" + LINK_SETTINGS.repoOwner + "/" + LINK_SETTINGS.downloadRepo + @"/blob/main/Cosmetics/{0}?raw=true", "WhiteVentileMask.zip"), MC_RESOURCE, "WhiteVentileMask.zip");
                    CosmeticManager.Add(CosmeticManager.Pack.WhiteMask);
                }
                MAIN.mWhite.Checked = true;

            }
            else if (MAIN.cosmeticsCS.mPink)
            {
                if (!File.Exists(Path.Combine(MC_RESOURCE, @"PinkVentileMask.zip")))
                {
                    await DownloadManager.DownloadAsync(string.Format(@"https://github.com/" + LINK_SETTINGS.repoOwner + "/" + LINK_SETTINGS.downloadRepo + @"/blob/main/Cosmetics/{0}?raw=true", "PinkVentileMask.zip"), MC_RESOURCE, "PinkVentileMask.zip");
                    CosmeticManager.Add(CosmeticManager.Pack.PinkMask);
                }
                MAIN.mPink.Checked = true;

            }
            else if (MAIN.cosmeticsCS.mBlue)
            {
                if (!File.Exists(Path.Combine(MC_RESOURCE, @"BlueVentileMask.zip")))
                {
                    await DownloadManager.DownloadAsync(string.Format(@"https://github.com/" + LINK_SETTINGS.repoOwner + "/" + LINK_SETTINGS.downloadRepo + @"/blob/main/Cosmetics/{0}?raw=true", "BlueVentileMask.zip"), MC_RESOURCE, "BlueVentileMask.zip");
                    CosmeticManager.Add(CosmeticManager.Pack.BlueMask);
                }
                MAIN.mBlue.Checked = true;

            }
            else if (MAIN.cosmeticsCS.mYellow)
            {
                if (!File.Exists(Path.Combine(MC_RESOURCE, @"BlackVentileMask.zip")))
                {
                    await DownloadManager.DownloadAsync(string.Format(@"https://github.com/" + LINK_SETTINGS.repoOwner + "/" + LINK_SETTINGS.downloadRepo + @"/blob/main/Cosmetics/{0}?raw=true", "YellowVentileMask.zip"), MC_RESOURCE, "YellowVentileMask.zip");
                    CosmeticManager.Add(CosmeticManager.Pack.YellowMask);
                }
                MAIN.mYellow.Checked = true;

            }
            else if (MAIN.cosmeticsCS.mRick)
            {
                if (!File.Exists(Path.Combine(MC_RESOURCE, @"RickVentileMask.zip")))
                {
                    await DownloadManager.DownloadAsync(string.Format(@"https://github.com/" + LINK_SETTINGS.repoOwner + "/" + LINK_SETTINGS.downloadRepo + @"/blob/main/Cosmetics/{0}?raw=true", "RickVentileMask.zip"), MC_RESOURCE, "RickVentileMask.zip");
                    CosmeticManager.Add(CosmeticManager.Pack.RickMask);
                }
                MAIN.mRick.Checked = true;

            }

            //Load Extras
            if (MAIN.cosmeticsCS.aGlowing)
            {
                if (!File.Exists(Path.Combine(MC_RESOURCE, @"GlowingVentileCape.zip")))
                {
                    await DownloadManager.DownloadAsync(string.Format(@"https://github.com/" + LINK_SETTINGS.repoOwner + "/" + LINK_SETTINGS.downloadRepo + @"/blob/main/Cosmetics/{0}?raw=true", "GlowingVentileCape.zip"), MC_RESOURCE, "GlowingVentileCape.zip");
                    CosmeticManager.Add(CosmeticManager.Pack.GlowingCape);
                }
                MAIN.aGlowing.Checked = true;

            }
            else if (MAIN.cosmeticsCS.aSlide)
            {
                if (!File.Exists(Path.Combine(MC_RESOURCE, @"SlidingVentileCape.zip")))
                {
                    await DownloadManager.DownloadAsync(string.Format(@"https://github.com/" + LINK_SETTINGS.repoOwner + "/" + LINK_SETTINGS.downloadRepo + @"/blob/main/Cosmetics/{0}?raw=true", "SlidingVentileCape.zip"), MC_RESOURCE, "SlidingVentileCape.zip");
                    CosmeticManager.Add(CosmeticManager.Pack.SlidingCape);
                }
                MAIN.aSlide.Checked = true;

            }
            else if (MAIN.cosmeticsCS.oWavy)
            {
                if (!File.Exists(Path.Combine(MC_RESOURCE, @"WavyVentile.zip")))
                {
                    await DownloadManager.DownloadAsync(string.Format(@"https://github.com/" + LINK_SETTINGS.repoOwner + "/" + LINK_SETTINGS.downloadRepo + @"/blob/main/Cosmetics/{0}?raw=true", "WavyVentile.zip"), MC_RESOURCE, "WavyVentile.zip");
                    CosmeticManager.Add(CosmeticManager.Pack.WavyOverlay);
                }
                MAIN.oWavy.Checked = true;

            }
            else if (MAIN.cosmeticsCS.oKagune)
            {
                if (!File.Exists(Path.Combine(MC_RESOURCE, @"KaguneVentile.zip")))
                {
                    await DownloadManager.DownloadAsync(string.Format(@"https://github.com/" + LINK_SETTINGS.repoOwner + "/" + LINK_SETTINGS.downloadRepo + @"/blob/main/Cosmetics/{0}?raw=true", "KaguneVentile.zip"), MC_RESOURCE, "KaguneVentile.zip");
                    CosmeticManager.Add(CosmeticManager.Pack.Kagune);
                }
                MAIN.oKagune.Checked = true;

            }

            try
            {
                if (File.Exists(Path.Combine(MC_RESOURCE, @"CosmeticMixer.zip")))
                {
                    File.Delete(Path.Combine(MC_RESOURCE, @"CosmeticMixer.zip"));
                }

                await DownloadManager.DownloadAsync(string.Format(@"https://github.com/" + LINK_SETTINGS.repoOwner + "/" + LINK_SETTINGS.downloadRepo + @"/blob/main/Cosmetics/{0}?raw=true", "CosmeticMixer.zip"), MC_RESOURCE, "CosmeticMixer.zip");
            }
            catch (Exception ex)
            {
                MAIN.dLogger.Log(ex);
            }

            CosmeticManager.Remove(CosmeticManager.Pack.CosmeticMixer);
            CosmeticManager.Add(CosmeticManager.Pack.CosmeticMixer);
        }

        //Settings
        static int PROGRESS_BAR_WIDTH = 410;
        static int BUTTON_WIDTH = 150;
        static int SPACING = 30;
        static int TOP_OFFSET = 15;
        static int RIGHT_PANEL_OFFSET = 42;
        static int RIGHT_BUTTON_OFFSET = 70;

        public static void Version(bool internetParam)
        {
            //Colors
            // Make the color variable smaller
            Color backColor = ColorTranslator.FromHtml(MAIN.themeCS.Background);
            Color accentColor = ColorTranslator.FromHtml(MAIN.themeCS.Accent);
            Color foreColor = ColorTranslator.FromHtml(MAIN.themeCS.Foreground);
            Color outlineColor = ColorTranslator.FromHtml(MAIN.themeCS.Outline);
            Color fadedColor = ColorTranslator.FromHtml(MAIN.themeCS.Faded);
            Color backColor2 = ColorTranslator.FromHtml(MAIN.themeCS.SecondBackground);

            MAIN.versionsTab.Controls.Clear();
            MAIN.versionsPanel.Controls.Clear();

            MAIN.versionsPanel.Size = MAIN.contentView.Size;
            MAIN.versionsPanel.Width = MAIN.contentView.Width + RIGHT_PANEL_OFFSET;

            MAIN.versionsPanel.AutoScroll = true;

            //Displays a tab that says you don't have internet
            if (!MAIN.internet || !internetParam)
            {
                var lbl = new System.Windows.Forms.Label()
                {
                    AutoSize = true,
                    Text = "No Internet...",
                    Font = new Font("Segoe UI", 20.25f, FontStyle.Bold),
                    Location = new Point(5, TOP_OFFSET),
                    ForeColor = foreColor
                };

                var noInternet = new System.Windows.Forms.Label()
                {
                    AutoSize = true,
                    Text = "Cannot retrieve data!\n - A firewall isn't allowing the launcher to access the internet\n - You don't have an internet connection\n - If a reason isn't listed here, ask for help or contact the devs!",
                    Font = new Font("Segoe UI", 14.25f),
                    Location = new Point(9, SPACING + TOP_OFFSET * 2),
                    ForeColor = foreColor
                };

                MAIN.versionsPanel.Controls.Add(lbl);
                lbl.BringToFront();

                MAIN.versionsPanel.Controls.Add(noInternet);
                noInternet.BringToFront();

                MAIN.versionsTab.Controls.Add(MAIN.versionsPanel);

                if (MAIN.cosmeticsButton.Checked)
                    MAIN.contentView.SelectedTab = MAIN.versionsTab;

                return;
            }

            //Displays a tab that says you dont have access to the github
            if (!MAIN.versionsRetrieved)
            {
                var lbl = new System.Windows.Forms.Label()
                {
                    AutoSize = true,
                    Text = "No Versions",
                    Font = new Font("Segoe UI", 20.25f, FontStyle.Bold),
                    Location = new Point(5, TOP_OFFSET),
                    ForeColor = foreColor
                };

                var noGithub = new System.Windows.Forms.Label()
                {
                    AutoSize = true,
                    Text = "Cannot retrieve data!\n - A firewall isn't allowing the launcher to access the internet\n - You don't have an internet connection\n - You ran out of Github requests\n - If a reason isn't listed here, ask for help or contact the devs!",
                    Font = new Font("Segoe UI", 14.25f),
                    Location = new Point(9, SPACING + TOP_OFFSET * 2),
                    ForeColor = foreColor
                };

                MAIN.versionsPanel.Controls.Add(lbl);
                lbl.BringToFront();

                MAIN.versionsPanel.Controls.Add(noGithub);
                noGithub.BringToFront();

                MAIN.versionsTab.Controls.Add(MAIN.versionsPanel);
                return;
            }


            // Title Of Panel
            var label = new System.Windows.Forms.Label()
            {
                AutoSize = true,
                Text = "Version Selector",
                Font = new Font("Segoe UI", 20.25f, FontStyle.Bold),
                Location = new Point(5, TOP_OFFSET),
                ForeColor = foreColor
            };
            label.BringToFront();

            MAIN.versionsPanel.Controls.Add(label);


            for (int i = 0; i < MAIN.versions.Count; i++) // Loop through all versions
            {
                // Label for version
                var versionName = new System.Windows.Forms.Label()
                {
                    Name = "versionLabel" + i.ToString(),
                    Text = MAIN.versions[i].ToString(),
                    Tag = MAIN.versions[i].ToString(),
                    Font = new Font("Segoe UI", 14.25f),
                    AutoSize = true,
                    ForeColor = foreColor
                };

                versionName.Location = new Point(9, (versionName.Height + SPACING) * (i + 1) + TOP_OFFSET);

                Guna2ProgressBar.CheckForIllegalCrossThreadCalls = false;

                // Progress Bar for downloading/extracting progress
                var bar = new Guna2ProgressBar
                {
                    Name = "versionBar" + i.ToString(),
                    UseTransparentBackground = true,
                    Tag = "bar|" + versionName.Tag,
                    Height = versionName.Height - 5,
                    Width = PROGRESS_BAR_WIDTH,
                    ForeColor = foreColor,
                    FillColor = backColor2,
                    ProgressBrushMode = Guna.UI2.WinForms.Enums.BrushMode.Gradient,
                    ProgressColor = accentColor,

                    ProgressColor2 = Color.FromArgb
                    (
                    accentColor.R - MAIN.progressBarGradientOffset > 0 ? accentColor.R - MAIN.progressBarGradientOffset :
                    accentColor.R + MAIN.progressBarGradientOffset <= 255 ? accentColor.R + MAIN.progressBarGradientOffset : accentColor.R,

                    accentColor.R - MAIN.progressBarGradientOffset > 0 ? accentColor.R - MAIN.progressBarGradientOffset :
                    accentColor.R + MAIN.progressBarGradientOffset <= 255 ? accentColor.R + MAIN.progressBarGradientOffset : accentColor.R,

                    accentColor.B - MAIN.progressBarGradientOffset > 0 ? accentColor.B - MAIN.progressBarGradientOffset :
                    accentColor.B + MAIN.progressBarGradientOffset <= 255 ? accentColor.B + MAIN.progressBarGradientOffset : accentColor.B
                    ),

                    Location = new Point(versionName.Location.X + 15, versionName.Location.Y + SPACING),
                    Visible = false,
                    TabStop = false
                };

                Guna2Button.CheckForIllegalCrossThreadCalls = false;

                // Button to download appx from VersionChanger repo
                var download = new Guna2Button()
                {
                    Name = "versionDownload" + i.ToString(),
                    Text = "Download",
                    Tag = "download|" + versionName.Tag,
                    Font = new Font("Segoe UI", 14.25f, FontStyle.Bold),
                    Width = BUTTON_WIDTH,
                    Height = versionName.Height + 10,
                    ForeColor = foreColor,
                    FillColor = backColor2,
                    CheckedState = { FillColor = accentColor },
                    Checked = false,
                    UseTransparentBackground = true,
                    Animated = true,
                    TabStop = false,
                    Cursor = Cursors.Hand
                };

                download.Click += new EventHandler(DownloadVersion_Clicked);
                download.Location = new Point(MAIN.versionsPanel.Width - download.Width - RIGHT_BUTTON_OFFSET, versionName.Location.Y);

                // Select the version
                var select = new Guna2Button()
                {
                    Name = "versionsSelect" + i.ToString(),
                    Text = "Select",
                    Tag = "select|" + versionName.Tag,
                    Font = new Font("Segoe UI", 14.25f, FontStyle.Bold),
                    Width = BUTTON_WIDTH,
                    Height = versionName.Height + 10,
                    ForeColor = foreColor,
                    FillColor = backColor2,
                    CheckedState = { FillColor = accentColor },
                    Checked = false,
                    UseTransparentBackground = true,
                    Animated = true,
                    TabStop = false,
                    Visible = false,
                    Cursor = Cursors.Hand
                };

                select.Click += new EventHandler(SelectVersion_Clicked);
                select.Location = new Point(MAIN.versionsPanel.Width - select.Width - RIGHT_BUTTON_OFFSET, versionName.Location.Y);

                // Delete the version
                var uninstall = new Guna2Button()
                {
                    Name = "versionUninstall" + i.ToString(),
                    Text = "Uninstall",
                    Tag = "uninstall|" + versionName.Tag,
                    Font = new Font("Segoe UI", 14.25f, FontStyle.Bold),
                    Width = BUTTON_WIDTH,
                    Height = versionName.Height + 10,
                    ForeColor = foreColor,
                    FillColor = backColor2,
                    CheckedState = { FillColor = accentColor },
                    Checked = false,
                    UseTransparentBackground = true,
                    Animated = true,
                    TabStop = false,
                    Cursor = Cursors.Hand,
                    Visible = false
                };

                uninstall.Click += new EventHandler(UninstallVersion_Clicked);
                uninstall.Location = new Point(MAIN.versionsPanel.Width - uninstall.Width * 2 - (10 + RIGHT_BUTTON_OFFSET), versionName.Location.Y);


                // Add Buttons to stuff ykyk
                MAIN.versionsPanel.Controls.Add(versionName);
                MAIN.versionsPanel.Controls.Add(bar);
                MAIN.versionsPanel.Controls.Add(download);
                MAIN.versionsPanel.Controls.Add(select);
                MAIN.versionsPanel.Controls.Add(uninstall);
            }
            //Make there be a little extra space at the bottom of panel

            MAIN.versionsTab.Controls.Add(MAIN.versionsPanel);

            MAIN.versionsPanel.Height = MAIN.contentView.Height - TOP_OFFSET;

            // Refreshes The Currently Installed Versions
            RefreshInstalledVersions(MAIN.versions);
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
                MAIN.RPCTextbox.Text = MAIN.configCS.RpcText;
                MAIN.RPCTextbox.Visible = true;
                MAIN.buttonForRpc.Visible = true;
            }
            else
            {
                MAIN.RpcToggle.Checked = false;
                MAIN.RpcToggle.Text = "Off";
                MAIN.RPCTextbox.Visible = false;
                MAIN.buttonForRpc.Visible = false;
            }

            if (MAIN.configCS.RpcButton)
            {
                MAIN.buttonForRpc.Checked = true;
                MAIN.RPCButtonLinkTextbox.Visible = true;
                MAIN.RPCButtonTextbox.Visible = true;

                MAIN.RPCButtonLinkTextbox.Text = MAIN.configCS.RpcButtonLink;
                MAIN.RPCButtonTextbox.Text = MAIN.configCS.RpcButtonText;
            }
            else
            {
                MAIN.RPCButtonLinkTextbox.Visible = false;
                MAIN.RPCButtonTextbox.Visible = false;
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
                MAIN.autoInject.Checked = true;
                MAIN.autoInject.Text = "On";
            }
            else
            {
                MAIN.autoInject.Checked = false;
                MAIN.autoInject.Text = "Off";
            }

            //Persona
            if (MAIN.configCS.Persona)
            {
                MAIN.personaLoc.Checked = true;
            }
            else
            {
                MAIN.personaLoc.Checked = false;
            }

            //Theme
            if (MAIN.themeCS.Theme == ThemeTemplate.theme.Dark)
                MAIN.theme.Text = "Dark";
            else
                MAIN.theme.Text = "Light";

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
            if (MAIN.configCS.Toasts == 0)
            {
                MAIN.toastsToggle.Checked = false;
                MAIN.toastsToggle.Text = "Off";

                MAIN.toastsSelector.Visible = false;
            }
            else if (MAIN.configCS.Toasts == 1)
            {
                MAIN.toastsToggle.Checked = true;
                MAIN.toastsToggle.Text = "Ventile Toast";

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
                MAIN.toastsToggle.Checked = true;
                MAIN.toastsToggle.Text = "Windows Toast";
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
            string beta = MAIN.ventile_settings.isBeta ? "Beta" : "";
            MAIN.launcherVLabel.Text = $"{beta} {MAIN.ventile_settings.launcherVersion}";
            MAIN.clientVLabel.Text = MAIN.ventile_settings.clientVersion?.ToString() ?? "N/A";
            MAIN.cosmeticsVLabel.Text = MAIN.ventile_settings.cosmeticsVersion.ToString();
        }

        public static async void GetDLLS()
        {
            MAIN.DefaultDLLSelector.Items.Clear();
            if (!GithubManager.HaveRequests())
            {
                var item = new ToolStripMenuItem()
                {
                    Text = "None"
                };

                MAIN.DefaultDLLSelector.Items.Add(item);
                return;
            }

            // POSSIBLE: Remove api requests to github
            IReadOnlyList<RepositoryContent> contents = await MAIN.github.Repository.Content.GetAllContents(LINK_SETTINGS.repoOwner, LINK_SETTINGS.downloadRepo, @"Dlls\");

            if (contents.Count < 1)
            {
                var item = new ToolStripMenuItem()
                {
                    Text = "None"
                };

                MAIN.DefaultDLLSelector.Items.Add(item);
                return;
            }

            if (Directory.Exists(@"C:\temp\VentileClient\Dlls")) Directory.Delete(@"C:\temp\VentileClient\DLLS", true);

            Directory.CreateDirectory(@"C:\temp\VentileClient\Dlls");


            foreach (RepositoryContent dll in contents)
            {
                if (dll.Type == "file" && dll.Name.ToLower().EndsWith(".dll"))
                {
                    await DownloadManager.DownloadAsync(dll.DownloadUrl, @"C:\temp\VentileClient\Dlls", dll.Name);

                    var item = new ToolStripMenuItem()
                    {
                        Tag = dll.Name,
                        Text = dll.Name
                    };

                    item.Click += DLL_Click;
                    MAIN.DefaultDLLSelector.Items.Add(item);
                }
            }
        }

        public static void AddProfile(DirectoryInfo dir)
        {
            // Make the color variable smaller
            Color backColor = ColorTranslator.FromHtml(MAIN.themeCS.Background);
            Color accentColor = ColorTranslator.FromHtml(MAIN.themeCS.Accent);
            Color foreColor = ColorTranslator.FromHtml(MAIN.themeCS.Foreground);
            Color outlineColor = ColorTranslator.FromHtml(MAIN.themeCS.Outline);
            Color fadedColor = ColorTranslator.FromHtml(MAIN.themeCS.Faded);
            Color backColor2 = ColorTranslator.FromHtml(MAIN.themeCS.SecondBackground);

            ProfileInfo info = new ProfileInfo() { Name = dir.Name, FullDirPath = dir.FullName };

            if (!File.Exists(Path.Combine(dir.FullName, "profileLogo.png")))
            {
                using (Bitmap btmp = new Bitmap(Properties.Resources.GrassBlock))
                {
                    MemoryStream m = new MemoryStream();
                    btmp.Save(m, ImageFormat.Png);
                    info.Image = Image.FromStream(m);

                }

                using (Bitmap btmp = (Bitmap)info.Image.Clone())
                {
                    btmp.Save(Path.Combine(dir.FullName, "profileLogo.png"), ImageFormat.Png);
                }
            }
            else
            {
                using (Bitmap btmp = new Bitmap(Path.Combine(dir.FullName, "profileLogo.png")))
                {
                    MemoryStream m = new MemoryStream();
                    btmp.Save(m, ImageFormat.Png);
                    info.Image = Image.FromStream(m);

                }
            }

            for (int i = 0; i < MAIN.packProfilesList.Controls.Count; i++)
            {
                if (MAIN.packProfilesList.Controls[i].GetType() != typeof(Guna2Button)) continue;

                if (MAIN.packProfilesList.Controls[i].Name == dir.Name) return;
            }

            var newButton = new Guna2Button()
            {
                Name = info.Name,
                Animated = true,
                ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton,

                FillColor = Color.FromArgb(((backColor.R + 10 <= 255) ? backColor.R + 10 : backColor.R - 10), ((backColor.G + 10 <= 255) ? backColor.G + 10 : backColor.G - 10), ((backColor.B + 10 <= 255) ? backColor.B + 10 : backColor.B - 10)),
                Font = new Font("Segoe UI", 11.25f, FontStyle.Bold),

                ForeColor = foreColor,
                Image = info.Image,
                ImageAlign = HorizontalAlignment.Right,
                ImageSize = new Size(20, 20),

                Margin = new Padding(10, 3, 10, 3),
                Size = new Size(263, 36),

                TabStop = false,

                Tag = info,
                Cursor = Cursors.Hand,

                Text = info.Name,
                TextAlign = HorizontalAlignment.Left,
                UseTransparentBackground = true
            };

            for (int i = 0; i < MAIN.packProfilesList.Controls.Count; i++)
            {
                if (MAIN.packProfilesList.Controls[i].GetType() != typeof(Guna2Button)) continue;

                if (MAIN.packProfilesList.Controls[i].Name != dir.Name) ((Guna2Button)MAIN.packProfilesList.Controls[i]).Checked = false;
            }

            newButton.Click += OnProfileSelect;

            MAIN.Invoke(new Action(() =>
            {
                MAIN.packProfilesList.Controls.Add(newButton);

                MAIN.profileIconPictureBox.Tag = info;
                MAIN.profileNameTextbox.Tag = info;
                MAIN.saveProfileButton.Tag = info;
                MAIN.saveProfileButton.Tag = info;
                MAIN.deleteProfileButton.Tag = info;

                MAIN.profileNameLabel.Text = info.Name;
                MAIN.profileNameTextbox.Text = info.Name;
                MAIN.profileIconPictureBox.Image = info.Image;
            }));
        }

        public static void UpdateProfile(string Name, Image NewImage = null, string NewName = null)
        {
            for (int i = 0; i < MAIN.packProfilesList.Controls.Count; i++)
            {
                if (MAIN.packProfilesList.Controls[i].GetType() != typeof(Guna2Button)) continue;

                if (MAIN.packProfilesList.Controls[i].Name == Name)
                {
                    ProfileInfo info = MAIN.packProfilesList.Controls[i].Tag as ProfileInfo;

                    if (NewImage != null)
                        info.Image = NewImage;

                    if (NewName != null)
                    {
                        string newPath = @"C:\temp\VentileClient\Profiles\" + NewName;
                        if (!Directory.Exists(newPath))
                            Directory.Move(@"C:\temp\VentileClient\Profiles\" + info.Name, newPath);

                        info.Name = NewName;

                    }

                    ((Guna2Button)MAIN.packProfilesList.Controls[i]).Tag = info;
                    ((Guna2Button)MAIN.packProfilesList.Controls[i]).Text = info.Name;
                    ((Guna2Button)MAIN.packProfilesList.Controls[i]).Image = info.Image;
                    ((Guna2Button)MAIN.packProfilesList.Controls[i]).Name = info.Name;

                    MAIN.profileIconPictureBox.Tag = info;
                    MAIN.profileNameTextbox.Tag = info;
                    MAIN.saveProfileButton.Tag = info;
                    MAIN.saveProfileButton.Tag = info;
                    MAIN.deleteProfileButton.Tag = info;

                    MAIN.profileNameLabel.Text = info.Name;
                    MAIN.profileNameTextbox.Text = info.Name;
                    MAIN.profileIconPictureBox.Image = info.Image;
                    return;
                }
            }
        }

        public static async void RemoveProfile(string name)
        {

            MAIN.profileIconPictureBox.Tag = null;
            MAIN.profileNameTextbox.Tag = null;
            MAIN.saveProfileButton.Tag = null;
            MAIN.saveProfileButton.Tag = null;
            MAIN.deleteProfileButton.Tag = null;

            MAIN.profileNameLabel.Text = "Profile Name";
            MAIN.profileNameTextbox.Text = null;
            MAIN.profileIconPictureBox.Image = null;


            for (int i = 0; i < MAIN.packProfilesList.Controls.Count; i++)
            {
                if (MAIN.packProfilesList.Controls[i].GetType() != typeof(Guna2Button)) continue;

                if (MAIN.packProfilesList.Controls[i].Name == name)
                {
                    MAIN.packProfilesList.Controls.RemoveAt(i);
                    break;
                }
            }

            await MCDataManager.DeleteProfile(name);
        }

        public static void GetProfiles()
        {
            Directory.CreateDirectory(@"C:\temp\VentileClient\Profiles");
            for (int i = 0; i < MAIN.packProfilesList.Controls.Count; i++)
            {
                if (MAIN.packProfilesList.Controls[i].GetType() != typeof(Guna2Button)) continue;

                MAIN.packProfilesList.Controls.RemoveAt(i);
                i--;
            }

            DirectoryInfo dirs = new DirectoryInfo(@"C:\temp\VentileClient\Profiles");

            foreach (DirectoryInfo dir in dirs.GetDirectories())
                AddProfile(dir);

            MAIN.deleteProfileButton.Enabled = false;
            MAIN.loadProfileButton.Enabled = false;

            MAIN.profileIconPictureBox.Tag = null;
            MAIN.profileNameTextbox.Tag = null;
            MAIN.saveProfileButton.Tag = null;
            MAIN.saveProfileButton.Tag = null;
            MAIN.deleteProfileButton.Tag = null;

            MAIN.profileNameLabel.Text = "Profile Name";
            MAIN.profileNameTextbox.Text = null;
            MAIN.profileIconPictureBox.Image = null;

            updateMaxScroll(MAIN.packProfileScrollBar, MAIN.packProfilesList);
        }

        private static void OnProfileSelect(object s, EventArgs e)
        {
            Guna2Button sender = (Guna2Button)s;

            if (!sender.Checked) // Profile was de-selected
            {
                MAIN.deleteProfileButton.Enabled = false;
                MAIN.loadProfileButton.Enabled = false;

                MAIN.profileIconPictureBox.Tag = null;
                MAIN.profileNameTextbox.Tag = null;
                MAIN.saveProfileButton.Tag = null;
                MAIN.saveProfileButton.Tag = null;
                MAIN.deleteProfileButton.Tag = null;

                MAIN.profileNameLabel.Text = "Profile Name";
                MAIN.profileNameTextbox.Text = null;
                MAIN.profileIconPictureBox.Image = null;
                return;
            }


            // Profile was selected
            ProfileInfo info = (ProfileInfo)sender.Tag;

            MAIN.deleteProfileButton.Enabled = !MAIN.savingProfile.Contains(info.Name) || !MAIN.importing;
            MAIN.loadProfileButton.Enabled = !MAIN.savingProfile.Contains(info.Name) || !MAIN.importing;

            foreach (Control profileBtn in MAIN.packProfilesList.Controls)
            {
                if (profileBtn.GetType() == typeof(Guna2Button) && (Guna2Button)profileBtn != sender)
                    ((Guna2Button)profileBtn).Checked = false;
            }

            MAIN.profileIconPictureBox.Tag = info;
            MAIN.profileNameTextbox.Tag = info;
            MAIN.saveProfileButton.Tag = info;
            MAIN.saveProfileButton.Tag = info;
            MAIN.deleteProfileButton.Tag = info;

            MAIN.profileNameLabel.Text = info.Name;
            MAIN.profileNameTextbox.Text = info.Name;
            MAIN.profileIconPictureBox.Image = info.Image;
        }


        public static void AddAlarm(Alarm alarm, bool ShouldUpdateAlarms = true, bool ShouldSort = true)
        {
            AddAlarm(alarm.Name, alarm.Message, alarm.Hour, alarm.Minute, alarm.IsRepeated, alarm.IsPM, alarm.CreationDate, ShouldUpdateAlarms, ShouldSort);
        }
        public static void AddAlarm(string Name, string Message, int Hour, int Minute, bool IsRepeated, bool IsPM, DateTime CreationDate = new DateTime(), bool ShouldUpdateAlarms = true, bool ShouldSort = true)
        {
            // Make the color variable smaller
            Color backColor = ColorTranslator.FromHtml(MAIN.themeCS.Background);
            Color accentColor = ColorTranslator.FromHtml(MAIN.themeCS.Accent);
            Color foreColor = ColorTranslator.FromHtml(MAIN.themeCS.Foreground);
            Color outlineColor = ColorTranslator.FromHtml(MAIN.themeCS.Outline);
            Color fadedColor = ColorTranslator.FromHtml(MAIN.themeCS.Faded);
            Color backColor2 = ColorTranslator.FromHtml(MAIN.themeCS.SecondBackground);

            Alarm alarmInfo = new Alarm(Hour, Minute, IsRepeated, IsPM, CreationDate, Name, Message);

            Image moonIcon = IconChar.Moon.ToBitmap(Color.DarkGray, 64);
            Image sunIcon = IconChar.Sun.ToBitmap(Color.FromArgb(249, 215, 28), 64);
            Image AlarmImage = (IsPM ? moonIcon : sunIcon);

            var newButton = new Guna2Button()
            {
                Name = Name,
                Animated = true,
                ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton,
                Image = AlarmImage,
                ImageOffset = new Point(0, 1),
                ImageAlign = HorizontalAlignment.Right,

                FillColor = Color.FromArgb(((backColor.R + 10 <= 255) ? backColor.R + 10 : backColor.R - 10), ((backColor.G + 10 <= 255) ? backColor.G + 10 : backColor.G - 10), ((backColor.B + 10 <= 255) ? backColor.B + 10 : backColor.B - 10)),
                Font = new Font("Segoe UI", 11.25f, FontStyle.Bold),

                ForeColor = foreColor,

                Margin = new Padding(10, 3, 10, 3),
                Size = new Size(263, 36),

                TabStop = false,

                Tag = alarmInfo,
                Cursor = Cursors.Hand,

                Text = Name + " | " + Hour.ToString() + ":" + (Minute < 10 ? "0" + Minute.ToString() : Minute.ToString()),
                TextAlign = HorizontalAlignment.Left,
                UseTransparentBackground = true
            };

            for (int i = 0; i < MAIN.alarmsList.Controls.Count; i++)
            {
                if (MAIN.alarmsList.Controls[i].GetType() != typeof(Guna2Button)) continue;

                ((Guna2Button)MAIN.alarmsList.Controls[i]).Checked = false;
            }

            if (ShouldUpdateAlarms)
                MAIN.configCS.Alarms.Add(alarmInfo);

            newButton.Click += OnAlarmSelect;

            MAIN.Invoke(new Action(() =>
            {
                MAIN.alarmsList.Controls.Add(newButton);

                MAIN.saveAlarm.Tag = alarmInfo;
                MAIN.deleteAlarm.Tag = alarmInfo;

                MAIN.alarmNameLabel.Tag = alarmInfo;
                MAIN.alarmMinutesSelector.Tag = alarmInfo;
                MAIN.alarmHoursSelector.Tag = alarmInfo;
                MAIN.alarmRepeatedToggle.Tag = alarmInfo;
                MAIN.AmPmToggle.Tag = alarmInfo;

                MAIN.alarmNameLabel.Text = alarmInfo.Name;
                MAIN.alarmNameTextbox.Text = alarmInfo.Name;
                MAIN.alarmMessageTextbox.Text = alarmInfo.Message;

            }));

            if (ShouldSort)
                SortAlarms();
        }

        public static void UpdateAlarm(string ID, int NewHour, int NewMinute, bool NewRepeated, bool isPM, string NewName = null, string NewMessage = null)
        {
            Image moonIcon = IconChar.Moon.ToBitmap(Color.DarkGray, 64);
            Image sunIcon = IconChar.Sun.ToBitmap(Color.FromArgb(249, 215, 28), 64);

            Image AlarmImage = (isPM ? moonIcon : sunIcon);

            for (int i = 0; i < MAIN.alarmsList.Controls.Count; i++)
            {
                if (MAIN.alarmsList.Controls[i].GetType() != typeof(Guna2Button)) continue;

                Alarm info = MAIN.alarmsList.Controls[i].Tag as Alarm;
                if (info.ID == ID)
                {
                    info.Name = NewName ?? info.Name;
                    info.Message = NewMessage ?? info.Message;
                    info.Hour = NewHour == 0 ? info.Hour : NewHour;
                    info.Minute = NewMinute;
                    info.IsRepeated = NewRepeated;
                    info.IsPM = isPM;


                    ((Guna2Button)MAIN.alarmsList.Controls[i]).Tag = info;
                    ((Guna2Button)MAIN.alarmsList.Controls[i]).Image = AlarmImage;
                    ((Guna2Button)MAIN.alarmsList.Controls[i]).Text = info.Name + " | " + info.Hour.ToString() + ":" + (info.Minute < 10 ? "0" + info.Minute.ToString() : info.Minute.ToString());
                    ((Guna2Button)MAIN.alarmsList.Controls[i]).Name = info.Name;

                    MAIN.saveAlarm.Tag = info;
                    MAIN.deleteAlarm.Tag = info;

                    MAIN.alarmNameLabel.Tag = info;
                    MAIN.alarmMinutesSelector.Tag = info;
                    MAIN.alarmHoursSelector.Tag = info;
                    MAIN.alarmRepeatedToggle.Tag = info;
                    MAIN.AmPmToggle.Tag = info;

                    MAIN.alarmNameTextbox.Text = info.Name;
                    MAIN.alarmMessageTextbox.Text = info.Message;
                    SortAlarms();
                    return;
                }
            }

        }

        public static void RemoveAlarm(Alarm alarm)
        {
            MAIN.saveAlarm.Tag = null;
            MAIN.deleteAlarm.Tag = null;

            MAIN.alarmNameLabel.Tag = null;
            MAIN.alarmMinutesSelector.Tag = null;
            MAIN.alarmHoursSelector.Tag = null;
            MAIN.alarmRepeatedToggle.Tag = null;
            MAIN.AmPmToggle.Tag = null;

            MAIN.alarmNameTextbox.Text = null;
            MAIN.alarmMessageTextbox.Text = null;

            MAIN.alarmNameLabel.Text = "Name";


            MAIN.configCS.Alarms.Remove(alarm);
            for (int i = 0; i < MAIN.alarmsList.Controls.Count; i++)
            {
                if (MAIN.alarmsList.Controls[i].GetType() != typeof(Guna2Button)) continue;
                Alarm alarmInfo = MAIN.alarmsList.Controls[i].Tag as Alarm;

                if (alarmInfo.ID == alarm.ID)
                {
                    MAIN.alarmsList.Controls.RemoveAt(i);

                    break;
                }
            }
        }

        public static void GetAlarms()
        {
            if (MAIN.configCS?.Alarms == null) return;
            foreach (Alarm alarm in MAIN.configCS.Alarms)
                AddAlarm(alarm, false, false);

            SortAlarms();

            MAIN.saveAlarm.Tag = null;
            MAIN.deleteAlarm.Tag = null;

            MAIN.alarmNameLabel.Tag = null;
            MAIN.alarmMinutesSelector.Tag = null;
            MAIN.alarmHoursSelector.Tag = null;
            MAIN.alarmRepeatedToggle.Tag = null;
            MAIN.AmPmToggle.Tag = null;

            MAIN.alarmNameLabel.Text = "Name";

            MAIN.alarmNameTextbox.Text = null;
            MAIN.alarmMessageTextbox.Text = null;

            updateMaxScroll(MAIN.alarmsScrollbar, MAIN.alarmsList);
        }

        private static void OnAlarmSelect(object s, EventArgs e)
        {
            Guna2Button sender = (Guna2Button)s;

            if (!sender.Checked) // Profile was de-selected
            {
                MAIN.saveAlarm.Tag = null;
                MAIN.deleteAlarm.Tag = null;

                MAIN.alarmNameLabel.Tag = null;
                MAIN.alarmMinutesSelector.Tag = null;
                MAIN.alarmHoursSelector.Tag = null;
                MAIN.alarmRepeatedToggle.Tag = null;
                MAIN.AmPmToggle.Tag = null;

                MAIN.alarmNameLabel.Text = "Name";
                DateTime currentTime = DateTime.Now;
                MAIN.alarmHoursSelector.Value = currentTime.Hour > 12 ? currentTime.Hour - 12 : currentTime.Hour;
                MAIN.alarmMinutesSelector.Value = currentTime.Minute;
                MAIN.alarmRepeatedToggle.Checked = false;
                MAIN.AmPmToggle.Checked = currentTime.ToString("tt", CultureInfo.InvariantCulture).ToLower() == "pm";

                MAIN.alarmNameTextbox.Text = null;
                MAIN.alarmMessageTextbox.Text = null;
                return;
            }


            // Profile was selected
            Alarm info = (Alarm)sender.Tag;

            foreach (Control alarmButton in MAIN.alarmsList.Controls)
            {
                if (alarmButton.GetType() == typeof(Guna2Button) && (Guna2Button)alarmButton != sender)
                    ((Guna2Button)alarmButton).Checked = false;
            }

            MAIN.saveAlarm.Tag = info;
            MAIN.deleteAlarm.Tag = info;

            MAIN.alarmNameLabel.Tag = info;
            MAIN.alarmHoursSelector.Tag = info;
            MAIN.alarmMinutesSelector.Tag = info;
            MAIN.alarmRepeatedToggle.Tag = info;
            MAIN.AmPmToggle.Tag = info;

            MAIN.alarmNameLabel.Text = info.Name;

            MAIN.alarmNameTextbox.Text = info.Name;
            MAIN.alarmMessageTextbox.Text = info.Message;
            MAIN.alarmHoursSelector.Value = info.Hour;
            MAIN.alarmMinutesSelector.Value = info.Minute;
            MAIN.alarmRepeatedToggle.Checked = info.IsRepeated;
            MAIN.AmPmToggle.Checked = info.IsPM;
        }

        public static void SortAlarms()
        {
            List<Guna2Button> sorted = MAIN.alarmsList.Controls.OfType<Guna2Button>().ToList();
            sorted.Sort(CompareButtonTimes);

            int newIndex = 1;
            foreach (Guna2Button button in sorted)
            {
                MAIN.alarmsList.Controls.SetChildIndex(button, newIndex);
                newIndex++;
            }
        }

        private static int CompareButtonTimes(Guna2Button x, Guna2Button y)
        {
            Alarm xInfo = x?.Tag as Alarm;
            Alarm yInfo = y?.Tag as Alarm;

            if (xInfo == null)
            {
                if (yInfo == null) return 0;
                else return -1;
            }
            else
            {
                if (yInfo == null) return 1;
                else
                {
                    if (xInfo.IsPM)
                    {
                        if (!yInfo.IsPM) return 1;

                        if (xInfo.Hour < yInfo.Hour)
                            return -1;
                        else if (xInfo.Hour > yInfo.Hour)
                            return 1;

                        if (xInfo.Minute < yInfo.Minute)
                            return -1;
                        else if (xInfo.Minute > yInfo.Minute)
                            return 1;

                        return 0;
                    }
                    else
                    {
                        if (yInfo.IsPM) return 1;

                        if (xInfo.Hour < yInfo.Hour)
                            return -1;
                        else if (xInfo.Hour > yInfo.Hour)
                            return 1;

                        if (xInfo.Minute < yInfo.Minute)
                            return -1;
                        else if (xInfo.Minute > yInfo.Minute)
                            return 1;

                        return 0;
                    }
                }
            }

        }

        private static void updateMaxScroll(Guna2VScrollBar scrollbar, FlowLayoutPanel panel)
        {
            var prevScrollAmount = panel.AutoScrollPosition;
            var tempControl = new System.Windows.Forms.Label() { };

            panel.Controls.Add(tempControl);

            panel.ScrollControlIntoView(tempControl);
            scrollbar.Maximum = panel.VerticalScroll.Value + 10;

            panel.Controls.Remove(tempControl);
            panel.AutoScrollPosition = prevScrollAmount;
        }

        public static async Task GetMCVersions(bool force)
        {
            if (MAIN.versionsRetrieved && !force) return;

            if (!GithubManager.HaveRequests()) return;

            // POSSIBLE: Remove api requests to github
            IReadOnlyList<Release> releases = await MAIN.github.Repository.Release.GetAll(MAIN.link_settings.repoOwner, MAIN.link_settings.versionsRepo); // Gets all releases from the VersionChanger repo

            foreach (Release release in releases) // Used to sort and add versions to the versions list
            {
                var v = new Version(release.TagName);
                MAIN.versions.Add(v);
            }

            MAIN.versions.Sort(new VersionSorter()); //Sorts the versions becus mc versions system is trash
            MAIN.versions.Reverse();
            MAIN.versionsRetrieved = true;
        }

        private static void DLL_Click(object sender, EventArgs e)
        {
            MAIN.selectedDLLName = (sender as ToolStripMenuItem).Tag.ToString();
            if (MAIN.configCS.CustomDLL)
                Notif.Toast("DLL", "Disable Custom DLL to use the built in ones!");
        }

        #region Version Clicked Events

        private static async void DownloadVersion_Clicked(object sender, EventArgs e)
        {
            MAIN.allowClose++;

            var sndr = sender as Guna2Button;

            string version = sndr.Tag.ToString().Substring(sndr.Text.Length + 1);
            sndr.Enabled = false;

            //Reset Positions Because of bug
            var label = (System.Windows.Forms.Label)ControlManager.GetControl(version, MAIN.versionsPanel);

            var progressBar = (Guna2ProgressBar)ControlManager.GetControl("bar|" + version, MAIN.versionsPanel);
            var downloadButton = (Guna2Button)ControlManager.GetControl("download|" + version, MAIN.versionsPanel);
            var uninstallButton = (Guna2Button)ControlManager.GetControl("uninstall|" + version, MAIN.versionsPanel);
            var selectButton = (Guna2Button)ControlManager.GetControl("select|" + version, MAIN.versionsPanel);

            progressBar.Location = new Point(progressBar.Location.X, label.Location.Y + SPACING);
            downloadButton.Location = new Point(downloadButton.Location.X, label.Location.Y);
            uninstallButton.Location = new Point(uninstallButton.Location.X, label.Location.Y);
            selectButton.Location = new Point(selectButton.Location.X, label.Location.Y);

            await VersionManager.DownloadVersion(version, sndr);
        }
        private static async void SelectVersion_Clicked(object sender, EventArgs e)
        {
            var sndr = sender as Guna2Button;

            string version = sndr.Tag.ToString().Substring(sndr.Text.Length + 1);

            //Reset Positions Because of bug
            var label = (System.Windows.Forms.Label)ControlManager.GetControl(version, MAIN.versionsPanel);

            var progressBar = (Guna2ProgressBar)ControlManager.GetControl("bar|" + version, MAIN.versionsPanel);
            var downloadButton = (Guna2Button)ControlManager.GetControl("download|" + version, MAIN.versionsPanel);
            var uninstallButton = (Guna2Button)ControlManager.GetControl("uninstall|" + version, MAIN.versionsPanel);
            var selectButton = (Guna2Button)ControlManager.GetControl("select|" + version, MAIN.versionsPanel);

            progressBar.Location = new Point(progressBar.Location.X, label.Location.Y + SPACING);
            downloadButton.Location = new Point(downloadButton.Location.X, label.Location.Y);
            uninstallButton.Location = new Point(uninstallButton.Location.X, label.Location.Y);
            selectButton.Location = new Point(selectButton.Location.X, label.Location.Y);

            if (MAIN.allowSelectVersion != 0)
            {
                Notif.Toast("Version Manager", "Sorry, you are already selecting a version!");
                return;
            }

            string gameDir = @"C:\temp\VentileClient\Versions\Minecraft-" + version;
            if (!Directory.Exists(gameDir))
            {
                Notif.Toast("Version Manager", "Sorry, there was an error!");
                return;
            }

            MAIN.allowClose++;
            MAIN.allowSelectVersion++;
            sndr.Enabled = false;

            await VersionManager.ReRegisterPackage(version, gameDir, sndr);
        }
        private static async void UninstallVersion_Clicked(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                MAIN.allowClose++;
                var sndr = sender as Guna2Button;
                string version = ((Guna2Button)sender).Tag.ToString().Substring(sndr.Text.Length + 1);

                var label = (System.Windows.Forms.Label)ControlManager.GetControl(version, MAIN.versionsPanel);

                var ctrl2 = (Guna2Button)ControlManager.GetControl("select|" + version, MAIN.versionsPanel);
                ctrl2.Invoke(new Action(() =>
                {
                    ctrl2.Enabled = false;
                    ctrl2.Visible = true;
                    ctrl2.Location = new Point(ctrl2.Location.X, label.Location.Y);
                }));

                ctrl2 = (Guna2Button)ControlManager.GetControl("uninstall|" + version, MAIN.versionsPanel);
                ctrl2.Invoke(new Action(() =>
                {
                    ctrl2.Enabled = false;
                    ctrl2.Visible = true;
                    ctrl2.Location = new Point(ctrl2.Location.X, label.Location.Y);
                }));

                if (Directory.Exists(@"C:\temp\VentileClient\Versions\" + "Minecraft-" + version))
                    Directory.Delete(@"C:\temp\VentileClient\Versions\" + "Minecraft-" + version, true);

                ctrl2 = (Guna2Button)ControlManager.GetControl("download|" + version, MAIN.versionsPanel);
                ctrl2.Invoke(new Action(() =>
                {
                    ctrl2.Enabled = true;
                    ctrl2.Visible = true;
                    ctrl2.Location = new Point(ctrl2.Location.X, label.Location.Y);
                }));

                ctrl2 = (Guna2Button)ControlManager.GetControl("select|" + version, MAIN.versionsPanel);
                ctrl2.Invoke(new Action(() =>
                {
                    ctrl2.Enabled = true;
                    ctrl2.Visible = false;
                    ctrl2.Location = new Point(ctrl2.Location.X, label.Location.Y);
                }));

                ctrl2 = (Guna2Button)ControlManager.GetControl("uninstall|" + version, MAIN.versionsPanel);
                ctrl2.Invoke(new Action(() =>
                {
                    ctrl2.Enabled = true;
                    ctrl2.Visible = false;
                    ctrl2.Location = new Point(ctrl2.Location.X, label.Location.Y);
                }));

                MAIN.allowClose--;
            });
        }

        #endregion

        #region Version Extras

        private static void RefreshInstalledVersions(List<Version> versions)
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