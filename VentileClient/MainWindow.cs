using Guna.UI2.WinForms;
using Ionic.Zip;
using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json;
using Octokit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using VentileClient.JSON_Template_Classes;

namespace VentileClient
{
    public partial class MainWindow : Form
    {

        // Importing Public Functions from RPC.cs
        private readonly RPC _drpc = new RPC();

        // Rounded Form
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );


        /*     >>>>>>>>>>>>>>>> REMEMBER TO CHANGE "isBeta" IN VENTILE SETTINGS BEFORE RELEASE <<<<<<<<<<<<<<<<     */

        public static VentileSettings VENTILE_SETTINGS = new VentileSettings()
        {
            launcherVersion = "4.1.0",
            clientVersion = "N/A",
            cosmeticsVersion = "1.1.0",
            isBeta = true,
            changelog = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "../../../ReleaseData/Changelog.txt"))
        };

        public static LinkSettings LINK_SETTINGS = new LinkSettings()
        {
            discordInvite = @"https://discord.gg/T2QtgdrtAY",
            websiteLink = @"https://ventile-client.github.io/Web/",
            repoOwner = "Ventile-Client",
            versionsRepo = "VersionChanger",
            downloadRepo = "Download",
            githubProductHeader = "VentileClientLauncher"
        };

        /*     >>>>>>>>>>>>>>>> REMEMBER TO CHANGE "isBeta" IN VENTILE SETTINGS BEFORE RELEASE <<<<<<<<<<<<<<<<     */

        private GitHubClient _github = new GitHubClient(new ProductHeaderValue(LINK_SETTINGS.githubProductHeader)); // New Github Client

        //Loggers
        private Logger _defaultLogger = new Logger(@"C:\temp\VentileClient\Logs", "Default", true, LogLevel.Error, LogLevel.Information, LogLocation.ConsoleAndFile, LogLocation.ConsoleAndFile);
        private Logger _configLogger = new Logger(@"C:\temp\VentileClient\Logs", "Config", true, LogLevel.Error, LogLevel.Information, LogLocation.ConsoleAndFile, LogLocation.ConsoleAndFile);
        private Logger _versionLogger = new Logger(@"C:\temp\VentileClient\Logs", "Version", true, LogLevel.Error, LogLevel.Information, LogLocation.ConsoleAndFile, LogLocation.ConsoleAndFile);


        #region Extra Functions

        #region Downloading
        public void Download(string link, string path, string name)
        {
            Task.Run(() =>
            {
                try
                {
                    using (var client = new WebClient())
                    {
                        client.DownloadFile(link, Path.Combine(path, name));
                    }
                }
                catch
                {
                    _defaultLogger.Log($"Failed to download\n   Link: {link}\n   Path: {Path.Combine(path, name)}", LogLevel.Error);
                }
            });
        }
        #endregion

        #region InternetCheck
        [DllImport("wininet.dll")]
        private static extern bool InternetGetConnectedState(out int Description, int ReservedValue);

        public static bool OnlineCheck()
        {
            var request = (HttpWebRequest)WebRequest.Create("https://github.com/");
            request.Timeout = 15000;
            request.Method = "HEAD";
            try
            {
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    return response.StatusCode == HttpStatusCode.OK;
                }
            }
            catch (WebException)
            {
                return false;
            }
        }

        public static bool InternetCheck()
        {
            bool internetcheckone = InternetGetConnectedState(out int desc, 0);
            bool internetchecktwo = OnlineCheck();

            if (internetcheckone == true && internetchecktwo == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region Configurations

        private ConfigTemplate _configCS = new ConfigTemplate();
        private CosmeticsTemplate _cosmeticsCS = new CosmeticsTemplate();
        private ThemeTemplate _themeCS = new ThemeTemplate();
        private PresetColorsTemplate _presetCS = new PresetColorsTemplate();

        private void ReadPresetColors(string path)
        {
            try
            {
                string temp = File.ReadAllText(path);
                _presetCS = JsonConvert.DeserializeObject<PresetColorsTemplate>(temp);
                _configLogger.Log("Successfully read: " + Path.GetFileName(path));
            }
            catch (Exception ex)
            {
                this.Toast("Error", "There was an error :(");
                _configLogger.Log(ex);
            }
        }

        private async void WritePresetColors(string path)
        {
            await Task.Run(() =>
            {
                try
                {
                    var temp = new PresetColorsTemplate()
                    {
                        p1 = _presetCS.p1,
                        p2 = _presetCS.p2,
                        p3 = _presetCS.p3,
                        p4 = _presetCS.p4,
                        p5 = _presetCS.p5,
                        p6 = _presetCS.p6,
                        p7 = _presetCS.p7,
                        p8 = _presetCS.p8,
                    };

                    string json = JsonConvert.SerializeObject(temp, Formatting.Indented);
                    File.WriteAllText(path, json);
                    _configLogger.Log("Successfully wrote to: " + Path.GetFileName(path));
                }
                catch (Exception ex)
                {
                    this.Toast("Error", "There was an error :(");
                    _configLogger.Log(ex);
                }
            });
        }

        private void ReadConfig(string path)
        {
            try
            {
                string temp = File.ReadAllText(path);
                _configCS = JsonConvert.DeserializeObject<ConfigTemplate>(temp);
                _configLogger.Log("Successfully read: " + Path.GetFileName(path));
            }
            catch (Exception ex)
            {
                this.Toast("Error", "There was an error :(");
                _configLogger.Log(ex);
            }
        }

        private async void WriteConfig(string path)
        {
            await Task.Run(() =>
            {
                try
                {
                    var temp = new ConfigTemplate()
                    {
                        WindowState = _configCS.WindowState,
                        AutoInject = _configCS.AutoInject,
                        RichPresence = _configCS.RichPresence,
                        RpcText = _configCS.RpcText,
                        RpcButton = _configCS.RpcButton,
                        RpcButtonLink = _configCS.RpcButtonLink,
                        RpcButtonText = _configCS.RpcButtonText,
                        CustomDLL = _configCS.CustomDLL,
                        DefaultDLL = _configCS.DefaultDLL,
                        InjectDelay = _configCS.InjectDelay,
                        BackgroundImage = _configCS.BackgroundImage,
                        BackgroundImageLoc = _configCS.BackgroundImageLoc,
                        Toasts = _configCS.Toasts,
                        ToastsLoc = _configCS.ToastsLoc,
                        RoundedButtons = _configCS.RoundedButtons,
                        PerformanceMode = _configCS.PerformanceMode
                    };

                    string json = JsonConvert.SerializeObject(temp, Formatting.Indented);
                    File.WriteAllText(path, json);
                    _configLogger.Log("Successfully wrote to configurations");
                }
                catch (Exception ex)
                {
                    this.Toast("Error", "There was an error :(");
                    _configLogger.Log(ex);
                }
            });
        }

        private void ReadTheme(string path)
        {
            try
            {
                string temp = File.ReadAllText(path);
                _themeCS = JsonConvert.DeserializeObject<ThemeTemplate>(temp);
                _configLogger.Log("Successfully read: " + Path.GetFileName(path));
            }
            catch (Exception ex)
            {
                this.Toast("Error", "There was an error :(");
                _configLogger.Log(ex);
            }
        }

        private async void WriteTheme(string path)
        {
            await Task.Run(() =>
            {
                try
                {
                    var temp = new ThemeTemplate()
                    {
                        Theme = _themeCS.Theme,
                        Background = _themeCS.Background,
                        SecondBackground = _themeCS.SecondBackground,
                        Foreground = _themeCS.Foreground,
                        Accent = _themeCS.Accent,
                        Outline = _themeCS.Outline,
                        Faded = _themeCS.Faded
                    };

                    string json = JsonConvert.SerializeObject(temp, Formatting.Indented);
                    File.WriteAllText(path, json);
                    _configLogger.Log("Successfully wrote to: " + Path.GetFileName(path));
                }
                catch (Exception ex)
                {
                    this.Toast("Error", "There was an error :(");
                    _configLogger.Log(ex);
                }
            });
        }

        private void ReadCosmetics(string path)
        {
            try
            {
                string temp = File.ReadAllText(path);
                _cosmeticsCS = JsonConvert.DeserializeObject<CosmeticsTemplate>(temp);
                _configLogger.Log("Successfully read: " + Path.GetFileName(path));
            }
            catch (Exception ex)
            {
                this.Toast("Error", "There was an error :(");
                _configLogger.Log(ex);
            }
        }

        private async void WriteCosmetics(string path)
        {
            await Task.Run(() =>
            {
                try
                {
                    var temp = new CosmeticsTemplate()
                    {
                        cBlack = _cosmeticsCS.cBlack,
                        cWhite = _cosmeticsCS.cWhite,
                        cPink = _cosmeticsCS.cPink,
                        cBlue = _cosmeticsCS.cBlue,
                        cYellow = _cosmeticsCS.cYellow,
                        cRick = _cosmeticsCS.cRick,

                        mBlack = _cosmeticsCS.mBlack,
                        mWhite = _cosmeticsCS.mWhite,
                        mPink = _cosmeticsCS.mPink,
                        mBlue = _cosmeticsCS.mBlue,
                        mYellow = _cosmeticsCS.mYellow,
                        mRick = _cosmeticsCS.mRick,

                        aGlowing = _cosmeticsCS.aGlowing,
                        aSlide = _cosmeticsCS.aSlide,

                        oWavy = _cosmeticsCS.oWavy,
                        oKagune = _cosmeticsCS.oKagune,
                    };

                    string json = JsonConvert.SerializeObject(temp, Formatting.Indented);
                    File.WriteAllText(path, json);
                    _configLogger.Log("Successfully wrote to: " + Path.GetFileName(path));
                }
                catch (Exception ex)
                {
                    this.Toast("Error", "There was an error :(");
                    _configLogger.Log(ex);
                }
            });
        }
        #endregion

        #region Toasts
        public void Toast(string title, string msg)
        {
            var toast = new Toast();
            toast.ShowToast(title, msg, _configCS, _themeCS);
        }
        #endregion

        #region Controls
        private Control GetControl(string controlTag, Control parentCtrl)
        {
            foreach (Control c in parentCtrl.Controls)
            {
                if ((string)c.Tag == controlTag)
                    return c;
            }

            Debug.WriteLine($"Could not find a control with the specified tag: {controlTag}!");
            return null;
        }

        private List<Control> GetControlByType(Type type, Control parentCtrl)
        {
            var ctrls = new List<Control>();
            foreach (Control c in parentCtrl.Controls)
            {
                if (c.GetType() == type)
                {
                    ctrls.Add(c);
                }
            }
            return ctrls;
        }

        #endregion

        #region Other

        private void ChangeGlobalColors()
        {
            // Make the color variable smaller
            Color backColor = ColorTranslator.FromHtml(_themeCS.Background);
            Color accentColor = ColorTranslator.FromHtml(_themeCS.Accent);
            Color foreColor = ColorTranslator.FromHtml(_themeCS.Foreground);
            Color outlineColor = ColorTranslator.FromHtml(_themeCS.Outline);
            Color fadedColor = ColorTranslator.FromHtml(_themeCS.Faded);
            Color backColor2 = ColorTranslator.FromHtml(_themeCS.SecondBackground);

            //Sidebar
            sidebar.BackColor = backColor;
            dragBar.BackColor = backColor;
            version.BackColor = backColor;
            version.ForeColor = fadedColor;
            launcherTitle.ForeColor = foreColor;
            launcherTitle.BackColor = backColor;
            line.ForeColor = foreColor;
            line.BackColor = backColor;


            settingsTab.BackColor = backColor;

            TrayIconContextMenu.ForeColor = foreColor;
            TrayIconContextMenu.BackColor = backColor2;
            TrayIconContextMenu.RenderStyle.SelectionBackColor = accentColor;
            TrayIconContextMenu.RenderStyle.SelectionForeColor = foreColor;
            TrayIconContextMenu.RenderStyle.BorderColor = outlineColor;

            //Home Button
            homeButton.ForeColor = foreColor;
            if (backColor.R + 15 < 255)
                homeButton.CheckedState.FillColor = Color.FromArgb(130, backColor.R + 15, backColor.G + 15, backColor.B + 15);
            else
                homeButton.CheckedState.FillColor = Color.FromArgb(130, backColor.R - 15, backColor.G - 15, backColor.B - 15);

            if (backColor.R - 15 > 0)
                homeButton.HoverState.FillColor = Color.FromArgb(130, backColor.R - 15, backColor.G - 15, backColor.B - 15);
            else
                homeButton.HoverState.FillColor = Color.FromArgb(130, backColor.R + 15, backColor.G + 15, backColor.B + 15);

            homeButtonIcon.IconColor = accentColor;

            //Cosmetics Button
            cosmeticsButton.ForeColor = foreColor;
            if (backColor.R + 15 < 255)
                cosmeticsButton.CheckedState.FillColor = Color.FromArgb(130, backColor.R + 15, backColor.G + 15, backColor.B + 15);
            else
                cosmeticsButton.CheckedState.FillColor = Color.FromArgb(130, backColor.R - 15, backColor.G - 15, backColor.B - 15);

            if (backColor.R - 15 > 0)
                cosmeticsButton.HoverState.FillColor = Color.FromArgb(130, backColor.R - 15, backColor.G - 15, backColor.B - 15);
            else
                cosmeticsButton.HoverState.FillColor = Color.FromArgb(130, backColor.R + 15, backColor.G + 15, backColor.B + 15);

            cosmeticsButtonIcon.IconColor = accentColor;

            //Version Button
            versionButton.ForeColor = foreColor;
            if (backColor.R + 15 < 255)
                versionButton.CheckedState.FillColor = Color.FromArgb(130, backColor.R + 15, backColor.G + 15, backColor.B + 15);
            else
                versionButton.CheckedState.FillColor = Color.FromArgb(130, backColor.R - 15, backColor.G - 15, backColor.B - 15);

            if (backColor.R - 15 > 0)
                versionButton.HoverState.FillColor = Color.FromArgb(130, backColor.R - 15, backColor.G - 15, backColor.B - 15);
            else
                versionButton.HoverState.FillColor = Color.FromArgb(130, backColor.R + 15, backColor.G + 15, backColor.B + 15);

            versionButtonIcon.IconColor = accentColor;

            //Settings Button
            settingsButton.ForeColor = foreColor;
            if (backColor.R + 15 < 255)
                settingsButton.CheckedState.FillColor = Color.FromArgb(130, backColor.R + 15, backColor.G + 15, backColor.B + 15);
            else
                settingsButton.CheckedState.FillColor = Color.FromArgb(130, backColor.R - 15, backColor.G - 15, backColor.B - 15);

            if (backColor.R - 15 > 0)
                settingsButton.HoverState.FillColor = Color.FromArgb(130, backColor.R - 15, backColor.G - 15, backColor.B - 15);
            else
                settingsButton.HoverState.FillColor = Color.FromArgb(130, backColor.R + 15, backColor.G + 15, backColor.B + 15);

            settingsButtonIcon.IconColor = accentColor;

            //About Button
            aboutButton.ForeColor = foreColor;
            if (backColor.R + 15 < 255)
                aboutButton.CheckedState.FillColor = Color.FromArgb(130, backColor.R + 15, backColor.G + 15, backColor.B + 15);
            else
                aboutButton.CheckedState.FillColor = Color.FromArgb(130, backColor.R - 15, backColor.G - 15, backColor.B - 15);

            if (backColor.R - 15 > 0)
                aboutButton.HoverState.FillColor = Color.FromArgb(130, backColor.R - 15, backColor.G - 15, backColor.B - 15);
            else
                aboutButton.HoverState.FillColor = Color.FromArgb(130, backColor.R + 15, backColor.G + 15, backColor.B + 15);

            aboutButtonIcon.IconColor = accentColor;

            if (_configCS.PerformanceMode)
            {
                homeButton.Animated = false;
                cosmeticsButton.Animated = false;
                versionButton.Animated = false;
                settingsButton.Animated = false;
                aboutButton.Animated = false;
            }
            else
            {
                homeButton.Animated = true;
                cosmeticsButton.Animated = true;
                versionButton.Animated = true;
                settingsButton.Animated = true;
                aboutButton.Animated = true;
            }

            this.Refresh();
        }

        private void ChangeBackground()
        {
            if (_configCS.BackgroundImage)
            {
                homeTab.BackgroundImage = new Bitmap(_configCS.BackgroundImageLoc);
                cosmeticsTab.BackgroundImage = new Bitmap(_configCS.BackgroundImageLoc);
                settingsTab.BackgroundImage = new Bitmap(_configCS.BackgroundImageLoc);
                aboutTab.BackgroundImage = new Bitmap(_configCS.BackgroundImageLoc);
                return;
            }

            // Change background and logo
            if (_themeCS.Theme == "dark")
            {
                logo.Image = VentileClient.Properties.Resources.transparent_logo_white;
                homeTab.BackgroundImage = VentileClient.Properties.Resources.background;
                cosmeticsTab.BackgroundImage = VentileClient.Properties.Resources.background;
                settingsTab.BackgroundImage = VentileClient.Properties.Resources.background;
                aboutTab.BackgroundImage = VentileClient.Properties.Resources.background;
            }
            else if (_themeCS.Theme == "light")
            {
                logo.Image = VentileClient.Properties.Resources.transparent_logo_black;
                homeTab.BackgroundImage = VentileClient.Properties.Resources.background2;
                cosmeticsTab.BackgroundImage = VentileClient.Properties.Resources.background2;
                settingsTab.BackgroundImage = VentileClient.Properties.Resources.background2;
                aboutTab.BackgroundImage = VentileClient.Properties.Resources.background2;
            }
        }

        private void ReCheckInternet(object sender, EventArgs e)
        {
            internet = InternetGetConnectedState(out int desc, 0);
            _previousInternetState.Add(internet);
            if (internet && !_previousInternetState[_previousInternetState.Count - 2])
            {
                if (cosmeticsButton.Checked) contentView.SelectedTab = cosmeticsTab;
                else if (versionButton.Checked) contentView.SelectedTab = versionsTab;
                InitHome();
                InitCosmetics();
                ChangeVersionColors();
                this.Toast("Internet", "Connection found!");
            }
            else if (!internet && _previousInternetState[_previousInternetState.Count - 2])
            {
                VersionsPanel.Controls.Clear();
                //Colors
                // Make the color variable smaller
                Color backColor = ColorTranslator.FromHtml(_themeCS.Background);
                Color accentColor = ColorTranslator.FromHtml(_themeCS.Accent);
                Color foreColor = ColorTranslator.FromHtml(_themeCS.Foreground);
                Color outlineColor = ColorTranslator.FromHtml(_themeCS.Outline);
                Color fadedColor = ColorTranslator.FromHtml(_themeCS.Faded);
                Color backColor2 = ColorTranslator.FromHtml(_themeCS.SecondBackground);

                this.Toast("Internet", "Could not find a connection");

                var lbl = new System.Windows.Forms.Label()
                {
                    AutoSize = true,
                    Text = "No Internet...",
                    Font = new Font("Segoe UI", 20.25f, FontStyle.Bold),
                    Location = new Point(5, 14),
                    ForeColor = foreColor
                };
                lbl.BringToFront();
                VersionsPanel.Controls.Add(lbl);

                var noInternet = new System.Windows.Forms.Label()
                {
                    AutoSize = true,
                    Text = "Cannot retrieve data!\n - A firewall isn't allowing the launcher to acess the internet\n - You don't have an internet connection\n - If a reason isn't listed here, ask for help or contact the devs!",
                    Font = new Font("Segoe UI", 14.25f),
                    Location = new Point(9, 30 + 15 * 2),
                    ForeColor = foreColor
                };
                noInternet.BringToFront();
                VersionsPanel.Controls.Add(noInternet);

                var reChkInternet = new Guna2Button()
                {
                    Text = "Re-Check",
                    Font = new Font("Segoe UI", 9f, FontStyle.Bold),
                    Width = 100,
                    Height = 29,
                    ForeColor = foreColor,
                    FillColor = backColor2,
                    CheckedState = {
                        FillColor = accentColor
                    },
                    Checked = false,
                    UseTransparentBackground = true,
                    Location = new Point(9, 30 + 15 * 10),
                    Animated = true,
                    TabStop = false,
                    AutoRoundedCorners = true
                };
                reChkInternet.Click += new EventHandler(ReCheckInternet);
                reChkInternet.BringToFront();
                VersionsPanel.Controls.Add(reChkInternet);

                contentView.SelectedTab = versionsTab;
            }
        }

        #endregion

        #endregion

        public static MainWindow INSTANCE;

        public MainWindow()
        {
            InitializeComponent();

            INSTANCE = this;

            // Round the form window
            this.FormBorderStyle = FormBorderStyle.None;
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            // Get Current Theme
            ReadTheme(@"C:\temp\VentileClient\Presets\Theme.json");

            // Set the version's text
            version.Text = VENTILE_SETTINGS.launcherVersion;

            // Check for internet
            internet = InternetCheck();

            // Check for update
            if (!internet)
            {
                fadeIn.Start();
            }
            else
            {
                var updateCheck = new UpdateCheck();
                updateCheck.CheckForUpdate(_themeCS, VENTILE_SETTINGS, internet, _github);
            }
        }

        public bool internet;

        public string minecraftResourcePacks = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"Packages\Microsoft.MinecraftUWP_8wekyb3d8bbwe\LocalState\games\com.mojang\resource_packs");
        private ChangelogPrompt _currentChangelog;

        private void MainWindow_Load(object sender, EventArgs e)
        {
            ReadConfig(@"C:\temp\VentileClient\Presets\Config.json");
            if (!internet)
            {
                this.Toast("Internet", "You don't have an active wifi connection!");
            }
            if (!Directory.Exists(minecraftResourcePacks))
            {
                this.Toast("Resource Pack", "I couldn't find your resource packs, maybe start minecraft?");
            }

            ReadCosmetics(@"C:\temp\VentileClient\Presets\Cosmetics.json");
            ReadPresetColors(@"C:\temp\VentileClient\Presets\PresetColors.json");

            InitHome();
            ChangeGlobalColors();
            ChangeHomeColors();
            ChangeBackground();
            InitCosmetics();
            InitSettings();
            InitAbout();
        }

        #region Version Switcher

        #region Version Switcher - Init Stuff

        private int _progressBarGradientOffset = 40;
        private int _allowClose = 0;
        private int _allowSelectVersion = 0;
        private bool _backedUp = false;
        private void RefreshVersionList(List<Version> versions)
        {
            foreach (Version version in versions)
            {
                string dirnameSub = version.ToString();
                if (Directory.Exists(@"C:\temp\VentileClient\Versions\Minecraft-" + dirnameSub))
                {
                    var bar = (Guna2ProgressBar)GetControl("bar|" + dirnameSub, VersionsPanel);
                    var download = (Guna2Button)GetControl("download|" + dirnameSub, VersionsPanel);
                    var uninstall = (Guna2Button)GetControl("uninstall|" + dirnameSub, VersionsPanel);
                    var select = (Guna2Button)GetControl("select|" + dirnameSub, VersionsPanel);

                    bar.Visible = false;
                    download.Visible = false;
                    uninstall.Visible = true;
                    select.Visible = true;
                    this.Refresh();
                }
            }
            this.Refresh();
        }

        #endregion

        #region Version Switcher - Extras

        private void RegisterPackage(string gameDir, Guna2Button sndr)
        {
            try
            {
                _versionLogger.Log("Registering Package: " + gameDir);
                string manifestPath = Path.Combine(gameDir, "AppxManifest.xml");
                if (File.Exists(manifestPath))
                {
                    var ps = PowerShell.Create();
                    ps.AddScript("Add-AppxPackage -Register -ForceUpdateFromAnyVersion \"" + manifestPath + "\"");
                    ps.Invoke();
                    _versionLogger.Log("Registered Package: " + gameDir);
                }
                else
                {
                    this.Toast("Version Manager", "There was an error switching the version!");
                    _versionLogger.Log("AppxManifest.xml didn't exist! | " + manifestPath, LogLevel.Error);
                }
            }
            catch (Exception err)
            {
                _versionLogger.Log(err);
                this.Toast("Version Manager", "There was an error switching the version!");
            }

            _allowSelectVersion--;
            _allowClose--;
            sndr.Enabled = true;
        }

        #endregion

        #region MCData Management

        bool backingUp;
        private async Task BackupMCData(bool force = false)
        {
            if (backingUp)
            {
                _versionLogger.Log("Already Backing Up!");
                return;
            }
            if (!force && _backedUp)
            {
                _versionLogger.Log("Wasn't Forced, didn't backup com.mojang");
                return;
            }
            _versionLogger.Log("Starting backing up minecraft data!");
            backingUp = true;

            this.Toast("Version Manager", "Backing up data...");

            string sourceDirName = Path.Combine(minecraftResourcePacks, @"..");
            string destDirName = @"C:\temp\VentileClient\Versions\.data\com.mojang";

            if (!Directory.Exists(sourceDirName))
            {
                this.Toast("Backup Error", "Sorry, please manually back up your com.mojang folder!");
                _versionLogger.Log("Directory didnt exist: " + sourceDirName);
                return;
            }

            try
            {
                await Task.Run(() =>
                {
                    if (Directory.Exists(destDirName)) Directory.Delete(destDirName, true);
                    FileSystem.CopyDirectory(sourceDirName, destDirName, true);
                    _versionLogger.Log("Backed up minecraft data!");
                    this.Toast("Version Manager", "Finished backing up!");
                    _backedUp = true;
                    backingUp = false;
                });
            }
            catch (Exception err)
            {
                _versionLogger.Log(err);
                this.Toast("Backup Error", "Sorry, there was an error backing up!");
                _backedUp = true;
                backingUp = false;
            }
        }
        private async Task BackupDataAndRegister(string gameDir, Guna2Button sndr)
        {
            _versionLogger.Log("Starting backup and register");
            string sourceDirName = Path.Combine(minecraftResourcePacks, @"..");
            string destDirName = @"C:\temp\VentileClient\Versions\.data\com.mojang";

            if (!Directory.Exists(sourceDirName))
            {
                this.Toast("Backup Error", "Sorry, please manually back up your com.mojang folder!");
                _versionLogger.Log("Directory didn't exist! | " + sourceDirName);
                _backedUp = true;
                sndr.Enabled = true;
                return;
            }

            try
            {
                await Task.Run(() =>
                {
                    if (Directory.Exists(destDirName)) Directory.Delete(destDirName, true);
                    FileSystem.CopyDirectory(sourceDirName, destDirName, true);
                    _backedUp = true;
                    this.Toast("Version Manager", "Backup finished, changing version...");
                    RegisterPackage(gameDir, sndr);
                });
            }
            catch (Exception err)
            {
                _versionLogger.Log(err);
                this.Toast("Version Error", "Sorry, there was an error...");
                _backedUp = true;
                sndr.Enabled = true;
            }
        }

        #endregion

        #region Version Switcher - Button Clicks

        private async void DownloadVersion_Clicked(object sender, EventArgs e)
        {
            _allowClose++;

            var sndr = sender as Guna2Button;
            string version = ((Guna2Button)sender).Tag.ToString().Substring(sndr.Text.Length + 1);
            sndr.Enabled = false;

            await BackupMCData();
            await DownloadVersion(version, sndr);
        }
        private async void SelectVersion_Clicked(object sender, EventArgs e)
        {
            var sndr = sender as Guna2Button;
            sndr.Enabled = false;
            if (_allowSelectVersion != 0)
            {
                this.Toast("Version Manager", "Sorry, you are already selecting a version!");
                return;
            }
            _allowClose++;
            _allowSelectVersion++;
            string version = ((Guna2Button)sender).Tag.ToString().Substring(((Guna2Button)sender).Text.Length + 1);
            string gameDir = @"C:\temp\VentileClient\Versions\Minecraft-" + version;
            if (!Directory.Exists(gameDir))
            {
                this.Toast("Version Manager", "Sorry, there was an error!");
                return;
            }

            await BackupDataAndRegister(gameDir, sndr);
        }
        private async void UninstallVersion_Clicked(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                _allowClose++;
                var sndr = sender as Guna2Button;
                string version = ((Guna2Button)sender).Tag.ToString().Substring(sndr.Text.Length + 1);
                var ctrl2 = (Guna2Button)GetControl("select|" + version, VersionsPanel);
                ctrl2.Invoke(new Action(() =>
                {
                    ctrl2.Enabled = false;
                    ctrl2.Visible = true;
                }));

                ctrl2 = (Guna2Button)GetControl("uninstall|" + version, VersionsPanel);
                ctrl2.Invoke(new Action(() =>
                {
                    ctrl2.Enabled = false;
                    ctrl2.Visible = true;
                }));
                if (Directory.Exists(@"C:\temp\VentileClient\Versions\" + "Minecraft-" + version))
                    Directory.Delete(@"C:\temp\VentileClient\Versions\" + "Minecraft-" + version, true);

                ctrl2 = (Guna2Button)GetControl("download|" + version, VersionsPanel);
                ctrl2.Invoke(new Action(() =>
                {
                    ctrl2.Enabled = true;
                    ctrl2.Visible = true;
                }));

                ctrl2 = (Guna2Button)GetControl("select|" + version, VersionsPanel);
                ctrl2.Invoke(new Action(() =>
                {
                    ctrl2.Enabled = true;
                    ctrl2.Visible = false;
                }));

                ctrl2 = (Guna2Button)GetControl("uninstall|" + version, VersionsPanel);
                ctrl2.Invoke(new Action(() =>
                {
                    ctrl2.Enabled = true;
                    ctrl2.Visible = false;
                }));
                _allowClose--;
            });
        }

        #endregion

        #region Version Switcher - Downloading
        private async Task DownloadVersion(string version, Guna2Button sender)
        {
            await Task.Run(() =>
            {
                var ctrl = (Guna2ProgressBar)GetControl("bar|" + version, VersionsPanel);
                ctrl.Invoke(new Action(() =>
                {
                    ctrl.Visible = true;
                }));

                string link = @"https://github.com/" + LINK_SETTINGS.repoOwner + "/" + LINK_SETTINGS.versionsRepo + "/releases/download/" + version + @"/Minecraft-" + version + ".Appx";
                string path = @"C:\temp\VentileClient\Versions";
                string name = "Minecraft-" + version + ".Appx";
                using (var client = new WebClient())
                {
                    client.DownloadProgressChanged += new DownloadProgressChangedEventHandler((sndr, e) => VersionDownloadProgressChanged(sndr, e, version));
                    client.DownloadFileCompleted += new AsyncCompletedEventHandler((sndr, e) => VersionDownloadCompleted(sndr, e, version));

                    _versionLogger.Log("Started Downloading Version: " + version);
                    var url = new Uri(link);

                    client.DownloadFileAsync(url, Path.Combine(path, name));
                }
            });

        }

        private async void VersionDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e, string version)
        {
            await Task.Run(() =>
            {
                var ctrl = (Guna2ProgressBar)GetControl("bar|" + version, VersionsPanel);
                double recieve = double.Parse(e.BytesReceived.ToString());
                double total = double.Parse(e.TotalBytesToReceive.ToString());
                double percent = recieve / total * 100;
                ctrl.Value = int.Parse(Math.Truncate(percent).ToString());
            });
        }

        private void VersionDownloadCompleted(object sender, AsyncCompletedEventArgs e, string version)
        {
            _versionLogger.Log("Downloaded version: " + version);
            var ctrl = (Guna2ProgressBar)GetControl("bar|" + version, VersionsPanel);
            ctrl.Maximum = int.MaxValue;
            ctrl.Value = 0;
            ExtractAppx(@"C:\temp\VentileClient\Versions\Minecraft-" + version + ".Appx", @"C:\temp\VentileClient\Versions", "Minecraft-" + version, version);
        }

        #endregion

        #region Version Switcher - Extracting

        //private BackgroundWorker _extractFile;
        private long _fileSize;
        private long _extractedSizeTotal;
        private long _compressedSize;

        private async void ExtractAppx(string AppxPath, string OutputPath, string dirName, string version)
        {
            await Task.Run(() =>
            {
                if (!Directory.Exists(Path.Combine(OutputPath, dirName)))
                {
                    Directory.CreateDirectory(Path.Combine(OutputPath, dirName));
                    _versionLogger.Log("Created Directory: " + dirName + " in: " + OutputPath);
                }

                var _extractFile = new BackgroundWorker();
                _extractFile.DoWork += new DoWorkEventHandler((sndr, e) => ExtractFile_DoWork(_extractFile, e, AppxPath, Path.Combine(OutputPath, dirName), version, dirName));
                _extractFile.ProgressChanged += new ProgressChangedEventHandler((sndr, e) => ExtractFile_ProgressChanged(sndr, e, version));
                _extractFile.RunWorkerCompleted += new RunWorkerCompletedEventHandler((sndr, e) => ExtractFile_RunWorkerCompleted(version, AppxPath, OutputPath, dirName));
                _extractFile.WorkerReportsProgress = true;


                _extractFile.RunWorkerAsync();
            });
        }

        private async void ExtractFile_DoWork(BackgroundWorker sender, DoWorkEventArgs e, string AppxPath, string OutputPath, string version, string dirName)
        {
            await Task.Run(() =>
            {
                try
                {
                    _versionLogger.Log("Started to extract version: " + version);
                    var fileInfo = new FileInfo(AppxPath);
                    _fileSize = fileInfo.Length;
                    using (var zipFile = ZipFile.Read(AppxPath))
                    {
                        _extractedSizeTotal = 0;
                        zipFile.ExtractProgress += new EventHandler<ExtractProgressEventArgs>((sndr, ee) => Zip_ExtractProgress(sender, ee));
                        foreach (ZipEntry entry in zipFile)
                        {
                            _compressedSize = entry.CompressedSize;
                            entry.Extract(OutputPath, ExtractExistingFileAction.OverwriteSilently);
                            _extractedSizeTotal += _compressedSize;
                        }
                    }
                }
                catch (Exception err)
                {
                    this.Toast("Version Manager", "There was an error extracting!");
                    _versionLogger.Log(err);
                    //ExtractFile_RunWorkerCompleted(version, AppxPath, OutputPath, dirName);
                }
            });
        }

        private async void ExtractFile_ProgressChanged(object sender, ProgressChangedEventArgs e, string version)
        {
            await Task.Run(() =>
            {
                long totalPercent = (e.ProgressPercentage * _compressedSize + _extractedSizeTotal * int.MaxValue) / _fileSize;
                if (totalPercent > int.MaxValue)
                    totalPercent = int.MaxValue;
                var ctrl = (Guna2ProgressBar)GetControl("bar|" + version, VersionsPanel);
                ctrl.Value = (int)totalPercent;
            });
        }

        private async void Zip_ExtractProgress(BackgroundWorker sender, ExtractProgressEventArgs e)
        {
            await Task.Run(() =>
            {
                try
                {
                    if (e.TotalBytesToTransfer > 0)
                    {
                        long percent = e.BytesTransferred * int.MaxValue / e.TotalBytesToTransfer;
                        sender.ReportProgress((int)percent);
                    }
                }
                catch (Exception ex)
                {
                    _versionLogger.Log(ex, LogLevel.Information, LogLocation.Console);
                }
            });
        }

        private void ExtractFile_RunWorkerCompleted(string version, string AppxPath, string OutputPath, string dirName)
        {
            var ctrl = (Guna2ProgressBar)GetControl("bar|" + version, VersionsPanel);
            ctrl.Value = int.MaxValue;
            ctrl.Visible = false;

            var ctrl2 = (Guna2Button)GetControl("download|" + version, VersionsPanel);
            ctrl2.Invoke(new Action(() =>
            {
                ctrl2.Enabled = true;
                ctrl2.Visible = false;
            }));

            ctrl2 = (Guna2Button)GetControl("select|" + version, VersionsPanel);
            ctrl2.Invoke(new Action(() =>
            {
                ctrl2.Enabled = true;
                ctrl2.Visible = true;
            }));

            ctrl2 = (Guna2Button)GetControl("uninstall|" + version, VersionsPanel);
            ctrl2.Invoke(new Action(() =>
            {
                ctrl2.Enabled = true;
                ctrl2.Visible = true;
            }));

            _versionLogger.Log("Extracted Appx: " + AppxPath + " to: " + Path.Combine(OutputPath, dirName));

            try
            {
                File.Delete(Path.Combine(OutputPath, dirName, "AppxSignature.p7x"));
                File.Delete(AppxPath);
            }
            catch (Exception ex)
            {
                _versionLogger.Log(ex);
            }

            _allowClose--;
        }

        #endregion

        #endregion

        #region Timers
        private void fadeIn_Tick(object sender, EventArgs e)
        {
            if (Opacity == 1.0)
            {
                fadeIn.Stop();
            }
            Opacity += 0.04;
        }

        private bool _hidden = false;
        private bool _inGameTest = false;
        private List<bool> _previousInternetState = new List<bool>() { true };
        private void internetCheck_Tick(object sender, EventArgs e)
        {
            ReCheckInternet(sender, e); //sender and e mean nothing
        }

        private void TrayIcon_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) return;
            TrayIcon.Visible = false;
            this.Show();
            this.BringToFront();
        }

        private void TrayQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tick_Tick(object sender, EventArgs e)
        {
            if (_configCS.WindowState == "hide" && Process.GetProcessesByName("Minecraft.Windows").Length > 0 && !_hidden)
            {
                this.Hide();
                TrayIcon.Visible = true;
                this.Toast("Launcher", "Minimized to tray!");
                _hidden = true;
            }

            if (_configCS.WindowState == "hide" && !(Process.GetProcessesByName("Minecraft.Windows").Length > 0) && _hidden)
            {
                TrayIcon.Visible = false;
                this.Show();
                this.BringToFront();
                this.TopMost = true;
                this.TopMost = false;
                _hidden = false;
            }

            if (_configCS.WindowState == "minimize" && Process.GetProcessesByName("Minecraft.Windows").Length > 0 && !_hidden)
            {
                this.WindowState = FormWindowState.Minimized;
                _hidden = true;
            }

            if (_configCS.WindowState == "close" && Process.GetProcessesByName("Minecraft.Windows").Length > 0)
            {
                WriteTheme(@"C:\temp\VentileClient\Presets\Theme.json");
                WriteConfig(@"C:\temp\VentileClient\Presets\Config.json");
                _drpc.Deinitialize();
                Task.Delay(100);
                fadeOut.Start();
            }

            //RPC
            if (Process.GetProcessesByName("Minecraft.Windows").Length > 0 && !_inGameTest)
            {
                _inGameTest = true;
                _drpc.InGame();
            }
            else if (!(Process.GetProcessesByName("Minecraft.Windows").Length > 0) && _inGameTest)
            {
                _inGameTest = false;
                _drpc.Home();
            }
        }

        private void fadeOut_Tick(object sender, EventArgs e)
        {
            if (Opacity == 0.0)
            {
                fadeOut.Stop();
                this.Close();
            }
            Opacity -= 0.04;
        }
        #endregion

        #region Navigation

        private void ChangeVersionColors()
        {

            // Make the color variable smaller
            Color backColor = ColorTranslator.FromHtml(_themeCS.Background);
            Color accentColor = ColorTranslator.FromHtml(_themeCS.Accent);
            Color foreColor = ColorTranslator.FromHtml(_themeCS.Foreground);
            Color backColor2 = ColorTranslator.FromHtml(_themeCS.SecondBackground);

            List<Control> buttons = GetControlByType(typeof(Guna2Button), VersionsPanel);
            List<Control> progressBars = GetControlByType(typeof(Guna2ProgressBar), VersionsPanel);
            List<Control> labels = GetControlByType(typeof(System.Windows.Forms.Label), VersionsPanel);

            VersionsPanel.BackColor = backColor;


            foreach (Control b in buttons)
            {
                var button = b as Guna2Button;
                button.ForeColor = foreColor;
                button.FillColor = backColor2;
                button.CheckedState.FillColor = accentColor;
            }

            foreach (Control p in progressBars)
            {
                var progressBar = p as Guna2ProgressBar;
                progressBar.ForeColor = foreColor;
                progressBar.FillColor = backColor2;
                progressBar.ProgressColor = accentColor;
                int r = 0;
                int g = 0;
                int b = 0;

                if (accentColor.R - _progressBarGradientOffset > 0)
                    r = accentColor.R - _progressBarGradientOffset;
                else if (accentColor.R + _progressBarGradientOffset < 255)
                    r = accentColor.R + _progressBarGradientOffset;

                if (accentColor.G - _progressBarGradientOffset > 0)
                    g = accentColor.G - _progressBarGradientOffset;
                else if (accentColor.G + _progressBarGradientOffset < 255)
                    g = accentColor.G + _progressBarGradientOffset;

                if (accentColor.B - _progressBarGradientOffset > 0)
                    b = accentColor.B - _progressBarGradientOffset;
                else if (accentColor.B + _progressBarGradientOffset < 255)
                    b = accentColor.B + _progressBarGradientOffset;

                progressBar.ProgressColor2 = Color.FromArgb(r, g, b);
            }

            foreach (Control label in labels)
            {
                label.ForeColor = foreColor;
                label.BackColor = backColor;
            }
            this.Refresh();
        }

        private void homeButton_Click(object sender, EventArgs e)
        {
            ChangeHomeColors();
            if (contentView.SelectedTab == homeTab) return;

            var p = new Guna2Panel();
            if (!_configCS.PerformanceMode)
            {
                p.BackColor = ColorTranslator.FromHtml(_themeCS.Background);
                p.Size = VersionsPanel.Size;
                p.Location = new Point(165, 21);
                this.Controls.Add(p);
                p.BringToFront();
                sidebar.BringToFront();
                /*p.Visible = false;
                FadeEffectBetweenPages.ShowSync(p);*/
            }

            contentView.SelectedTab = homeTab;

            if (!_configCS.PerformanceMode)
            {
                p.Visible = true;
                FadeEffectBetweenPages.HideSync(p);
                this.Controls.Remove(p);
            }

            homeButton.Checked = true;
            cosmeticsButton.Checked = false;
            versionButton.Checked = false;
            settingsButton.Checked = false;
            aboutButton.Checked = false;
        }

        private void cosmeticsButton_Click(object sender, EventArgs e)
        {
            ChangeCosmeticColors();
            if (contentView.SelectedTab == cosmeticsTab) return;

            var p = new Guna2Panel();

            if (!_configCS.PerformanceMode)
            {
                p.BackColor = ColorTranslator.FromHtml(_themeCS.Background);
                p.Size = VersionsPanel.Size;
                p.Location = new Point(165, 21);
                this.Controls.Add(p);
                p.BringToFront();
                sidebar.BringToFront();
                /*p.Visible = false;
                FadeEffectBetweenPages.ShowSync(p);*/
            }

            if (!internet) contentView.SelectedTab = versionsTab;
            else contentView.SelectedTab = cosmeticsTab;

            this.Refresh();

            if (!_configCS.PerformanceMode)
            {
                p.Visible = true;
                FadeEffectBetweenPages.HideSync(p);
                this.Controls.Remove(p);
            }



            homeButton.Checked = false;
            cosmeticsButton.Checked = true;
            versionButton.Checked = false;
            settingsButton.Checked = false;
            aboutButton.Checked = false;
        }

        private void versionButton_Click(object sender, EventArgs e)
        {
            this.Toast("Version Manager", "Sorry this feature is too buggy! (It will be fixed)");
            return;
            ChangeVersionColors();
            if (contentView.SelectedTab == versionsTab) return;

            var p = new Guna2Panel();

            if (!_configCS.PerformanceMode)
            {
                p.BackColor = ColorTranslator.FromHtml(_themeCS.Background);
                p.Size = VersionsPanel.Size;
                p.Location = new Point(165, 21);
                this.Controls.Add(p);
                p.BringToFront();
                sidebar.BringToFront();
                /*p.Visible = false;
                FadeEffectBetweenPages.ShowSync(p);*/
            }

            contentView.SelectedTab = versionsTab;

            if (!_configCS.PerformanceMode)
            {
                p.Visible = true;
                FadeEffectBetweenPages.HideSync(p);
                this.Controls.Remove(p);
            }

            homeButton.Checked = false;
            cosmeticsButton.Checked = false;
            versionButton.Checked = true;
            settingsButton.Checked = false;
            aboutButton.Checked = false;
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            ChangeSettingColors();
            if (contentView.SelectedTab == settingsTab) return;

            var p = new Guna2Panel();

            if (!_configCS.PerformanceMode)
            {
                p.BackColor = ColorTranslator.FromHtml(_themeCS.Background);
                p.Size = VersionsPanel.Size;
                p.Location = new Point(165, 21);
                this.Controls.Add(p);
                p.BringToFront();
                sidebar.BringToFront();
                /*p.Visible = false;
                FadeEffectBetweenPages.ShowSync(p);*/
            }

            contentView.SelectedTab = settingsTab;
            settingsPagesTabControl.SelectedTab = Launcher;

            if (!_configCS.PerformanceMode)
            {
                p.Visible = true;
                FadeEffectBetweenPages.HideSync(p);
                this.Controls.Remove(p);
            }

            homeButton.Checked = false;
            cosmeticsButton.Checked = false;
            versionButton.Checked = false;
            settingsButton.Checked = true;
            aboutButton.Checked = false;

        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            ChangeAboutColors();
            if (contentView.SelectedTab == aboutTab) return;

            var p = new Guna2Panel();

            if (!_configCS.PerformanceMode)
            {
                p.BackColor = ColorTranslator.FromHtml(_themeCS.Background);
                p.Size = VersionsPanel.Size;
                p.Location = new Point(165, 21);
                this.Controls.Add(p);
                p.BringToFront();
                sidebar.BringToFront();
                /*p.Visible = false;
                FadeEffectBetweenPages.ShowSync(p);*/
            }

            contentView.SelectedTab = aboutTab;
            this.Refresh();

            if (!_configCS.PerformanceMode)
            {
                p.Visible = true;
                FadeEffectBetweenPages.HideSync(p);
                this.Controls.Remove(p);
            }

            homeButton.Checked = false;
            cosmeticsButton.Checked = false;
            versionButton.Checked = false;
            settingsButton.Checked = false;
            aboutButton.Checked = true;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            close("Closed Via Close Button");
        }
        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            close("Closed: " + e.CloseReason);
        }

        private void close(string logText)
        {

            WriteConfig(@"C:\temp\VentileClient\Presets\Config.json");
            WriteTheme(@"C:\temp\VentileClient\Presets\Theme.json");
            WriteCosmetics(@"C:\temp\VentileClient\Presets\Cosmetics.json");
            WritePresetColors(@"C:\temp\VentileClient\Presets\PresetColors.json");


            if (_allowClose == 0)
            {
                _drpc.Deinitialize();

                _defaultLogger.Log(logText);
                //Close all loggers
                closeButton.DisabledState.FillColor = closeButton.FillColor;
                closeButton.DisabledState.BorderColor = closeButton.DisabledState.BorderColor;
                closeButton.DisabledState.ForeColor = closeButton.ForeColor;

                closeButton.Enabled = false;


                FieldInfo[] fis = typeof(MainWindow).GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
                foreach (FieldInfo fieldInfo in fis)
                {
                    if (fieldInfo.FieldType == typeof(Logger))
                    {
                        var logger = fieldInfo.GetValue(this) as Logger;
                        logger.Disable();
                    }
                }

                fadeOut.Start();
            }
            else
            {
                if (_allowSelectVersion > 0)
                {
                    this.Toast("Version Manager", "Sorry, your still selecting your version!");
                    return;
                }
                this.Toast("Version Manager", "Sorry, your still installing!");
            }
        }

        private void minimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        #endregion

        #region Tabs

        #region Home
        private Guna2Panel VersionsPanel = new Guna2Panel();
        private async void InitHome()
        {
            //Colors
            // Make the color variable smaller
            Color backColor = ColorTranslator.FromHtml(_themeCS.Background);
            Color accentColor = ColorTranslator.FromHtml(_themeCS.Accent);
            Color foreColor = ColorTranslator.FromHtml(_themeCS.Foreground);
            Color outlineColor = ColorTranslator.FromHtml(_themeCS.Outline);
            Color fadedColor = ColorTranslator.FromHtml(_themeCS.Faded);
            Color backColor2 = ColorTranslator.FromHtml(_themeCS.SecondBackground);

            //Settings
            int progressWidth = 410;
            int buttonWidth = 150;
            int spacing = 30;
            int topOffset = 15;
            int rightOffset = 42;
            int rightButtonOffset = 70;


            VersionsPanel.Controls.Clear();

            VersionsPanel.Size = contentView.Size;
            VersionsPanel.Width = contentView.Width + rightOffset;

            //contentView.Width = 644 + rightOffset;
            VersionsPanel.AutoScroll = true;

            if (!internet) //Displays a tab that says you don't have internet
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
                VersionsPanel.Controls.Add(lbl);

                var noInternet = new System.Windows.Forms.Label()
                {
                    AutoSize = true,
                    Text = "Cannot retrieve data!\n - A firewall isn't allowing the launcher to acess the internet\n - You don't have an internet connection\n - If a reason isn't listed here, ask for help or contact thedevs!",
                    Font = new Font("Segoe UI", 14.25f),
                    Location = new Point(9, spacing + topOffset * 2),
                    ForeColor = foreColor
                };
                noInternet.BringToFront();
                VersionsPanel.Controls.Add(noInternet);

                contentView.SelectedTab = versionsTab;

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

            VersionsPanel.Controls.Add(label);


            // New List of class Version
            var versions = new List<Version>();

            IReadOnlyList<Release> releases = await _github.Repository.Release.GetAll(LINK_SETTINGS.repoOwner, LINK_SETTINGS.versionsRepo); // Gets all releases from the VersionChanger repo

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
                    accentColor.R - _progressBarGradientOffset > 0 ? accentColor.R - _progressBarGradientOffset :
                    accentColor.R + _progressBarGradientOffset < 255 ? accentColor.R + _progressBarGradientOffset : accentColor.R,

                    accentColor.R - _progressBarGradientOffset > 0 ? accentColor.R - _progressBarGradientOffset :
                    accentColor.R + _progressBarGradientOffset < 255 ? accentColor.R + _progressBarGradientOffset : accentColor.R,

                    accentColor.B - _progressBarGradientOffset > 0 ? accentColor.B - _progressBarGradientOffset :
                    accentColor.B + _progressBarGradientOffset < 255 ? accentColor.B + _progressBarGradientOffset : accentColor.B
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
                download.Location = new Point(VersionsPanel.Width - download.Width - (rightButtonOffset), versionName.Location.Y);
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
                select.Location = new Point(VersionsPanel.Width - select.Width - (rightButtonOffset), versionName.Location.Y);
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
                uninstall.Location = new Point(VersionsPanel.Width - uninstall.Width * 2 - (10 + rightButtonOffset), versionName.Location.Y);
                uninstall.Animated = true;
                uninstall.TabStop = false;
                uninstall.Visible = false;

                // Add Buttons to stuff ykyk
                VersionsPanel.Controls.Add(versionName);
                VersionsPanel.Controls.Add(download);
                VersionsPanel.Controls.Add(bar);
                VersionsPanel.Controls.Add(select);
                VersionsPanel.Controls.Add(uninstall);
            }
            //Make there be a little extra space at the bottom of panel

            versionsTab.Controls.Add(VersionsPanel);

            VersionsPanel.Size = new Size(VersionsPanel.Width, VersionsPanel.Height + topOffset * 2);
            // Refreshes The Currently Installed Versions
            RefreshVersionList(versions);
        }

        private void ChangeHomeColors()
        {
            // Make the color variable smaller
            Color backColor = ColorTranslator.FromHtml(_themeCS.Background);
            Color foreColor = ColorTranslator.FromHtml(_themeCS.Foreground);
            Color outlineColor = ColorTranslator.FromHtml(_themeCS.Outline);

            launchMc.FillColor = backColor;
            selectDll.FillColor = backColor;
            inject.FillColor = backColor;

            launchMc.ForeColor = foreColor;
            selectDll.ForeColor = foreColor;
            inject.ForeColor = foreColor;

            launchMc.BorderColor = outlineColor;
            selectDll.BorderColor = outlineColor;
            inject.BorderColor = outlineColor;

            // Reset button locations for bug
            launchMc.Location = new Point(169, 171);
            selectDll.Location = new Point(169, 248);
            inject.Location = new Point(357, 248);

            // Visible buttons on home screen
            if (!_configCS.CustomDLL)
            {
                selectDll.Visible = false;
                launchMc.Location = new Point(169, 198);
            }
            else
            {
                selectDll.Visible = true;
                selectDll.Location = new Point(235, 248);
                launchMc.Location = new Point(169, 171);
            }

            if (_configCS.AutoInject)
            {
                inject.Visible = false;
            }
            else
            {
                inject.Visible = true;
                inject.Location = new Point(260, 248);
                launchMc.Location = new Point(169, 171);
            }

            if (_configCS.CustomDLL && !_configCS.AutoInject)
            {
                selectDll.Location = new Point(169, 248);
                inject.Location = new Point(357, 248);
                launchMc.Location = new Point(169, 171);
            }

            this.Refresh();
        }

        private void launchMc_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("minecraft://");
            }
            catch
            {
                this.Toast("Error", "Sorry, there was an error launching...");
                return;
            }
            if (_configCS.AutoInject)
            {
                Task.Delay(_configCS.InjectDelay * 1000); // Delay injection by amount of milliseconds
                if (Process.GetProcessesByName("Minecraft.Windows").Length > 0)
                {
                    if (_configCS.CustomDLL)
                    {
                        if (_configCS.DefaultDLL.Length > 0)
                            InjectDLL(_configCS.DefaultDLL);
                        else
                            this.Toast("DLL", "Not injecting, no file specifed");
                    }
                    else
                    {
                        //Inject Ventile DLL

                    }
                }
            }
        }

        private void selectDll_Click(object sender, EventArgs e)
        {
            var FileIn = new OpenFileDialog()
            {
                RestoreDirectory = true,
                Filter = "DLL Files (*.dll)|*.dll|DLL Files (*.*)|*,*"
            };

            if (FileIn.ShowDialog() == DialogResult.OK)
            {
                _configCS.DefaultDLL = @FileIn.FileName;
                this.Toast("DLL", "Your DLL is selected!");
            }
            else
            {
                this.Toast("DLL", "You didnt specify a DLL!");
            }
        }

        private void inject_Click(object sender, EventArgs e)
        {
            if (Process.GetProcessesByName("Minecraft.Windows").Length > 0)
            {
                if (_configCS.CustomDLL)
                {
                    if (_configCS.DefaultDLL.Length > 0)
                        InjectDLL(_configCS.DefaultDLL);
                    else
                        this.Toast("DLL", "Not injecting, no file specifed");
                }
                else
                {
                    //Inject Ventile DLL

                }
            }
        }

        #endregion

        #region Cosmetics

        #region Functions
        private readonly Dictionary<string, int[]> _packInfo = new Dictionary<string, int[]>
        {
            { "3256f0cd-498a-4f97-a7ca-89dbeeeee4b8", new int[]{1, 0, 0 } }, // Black Cape
            { "51fabcfb-0636-4aa6-a935-2c34add462e4", new int[]{1, 0, 0 } }, // White Cape
            { "f495127b-83db-4e35-b93e-6c7f4b046a0f", new int[]{1, 0, 0 } }, // Pink Cape
            { "de9c860b-3ca6-4f48-8d81-1c8f4c65b8e9", new int[]{1, 0, 0 } }, // Blue Cape
            { "fc6bcc91-ee3c-4b97-bfcf-2243de323870", new int[]{1, 0, 0 } }, // Yellow Cape
            { "2fc8d46c-3652-4836-adfc-c1d2a43d5777", new int[]{1, 0, 0 } }, // Rick Cape

            { "982e6a3a-56f2-4e78-b0d5-b5eb9df0792b", new int[]{1, 0, 0 } }, // Black Mask
            { "03910601-ed59-4fb6-add5-f3b8cf27a8ff", new int[]{1, 0, 0 } }, // White Mask
            { "f4b600af-c2b3-43aa-b775-dec476f56829", new int[]{1, 0, 0 } }, // Pink Mask
            { "0af582ae-018f-47c4-92a9-db0643279fd0", new int[]{1, 0, 0 } }, // Blue Mask
            { "9891cbf5-d3d4-4d2d-94d9-cfeea717c2f9", new int[]{1, 0, 0 } }, // Yellow Mask
            { "6f7a314a-ea8c-4da0-ba38-4af023a0762e", new int[]{1, 0, 0 } }, // Rick Mask

            { "ed7b6991-50af-42c7-b302-84543a97e72b", new int[]{1, 0, 0 } }, // Glowing Cape
            { "57c6383e-7cb8-40b8-88af-8cbc18707c63", new int[]{1, 0, 0 } }, // Sliding Cape

            { "a6953918-a86c-43bb-a3af-ae6377bdba63", new int[]{1, 0, 0 } }, // Wavy Capes
            { "64564ae0-011b-4c2f-a87d-449c8119f234", new int[]{1, 0, 0 } } // Animated Kagune
        };

        private List<CosmeticsObject> packList()
        {
            if (!File.Exists(Path.Combine(minecraftResourcePacks, @"..", @"minecraftpe\global_resource_packs.json")))
            {

                this.Toast("Pack Error", "Looks like your com.mojang folder isnt avaliable!");
                return new List<CosmeticsObject>();

            }

            string json = File.ReadAllText(Path.Combine(minecraftResourcePacks, @"..", @"minecraftpe\global_resource_packs.json"));

            return JsonConvert.DeserializeObject<List<CosmeticsObject>>(json);
        }

        private bool cosmeticEnabled(string id)
        {
            if (!File.Exists(Path.Combine(minecraftResourcePacks, @"..", @"minecraftpe\global_resource_packs.json"))) return false;

            string json = File.ReadAllText(Path.Combine(minecraftResourcePacks, @"..", @"minecraftpe\global_resource_packs.json"));

            List<CosmeticsObject> jsonObject = JsonConvert.DeserializeObject<List<CosmeticsObject>>(json);

            bool enabled = false;

            for (int i = 0; i < jsonObject.Count; i++)
            {
                if (jsonObject[i].pack_id == id)
                {
                    enabled = true;
                }
            }

            return enabled;
        }

        private void removeCosmetic(string id)
        {
            if (!File.Exists(Path.Combine(minecraftResourcePacks, @"..", @"minecraftpe\global_resource_packs.json"))) return;

            if (cosmeticEnabled(id))
            {
                List<CosmeticsObject> packs = packList();

                if (packs[0].pack_id == "error") return;

                for (int i = 0; i < packs.Count; i++)
                {
                    if (packs[i].pack_id == id)
                    {
                        packs.RemoveAt(i);
                    }
                }

                File.WriteAllText(Path.Combine(minecraftResourcePacks, @"..", @"minecraftpe\global_resource_packs.json"), JsonConvert.SerializeObject(packs, Formatting.Indented));
            }
        }

        private void addCosmetic(string id)
        {
            if (!File.Exists(Path.Combine(minecraftResourcePacks, @"..", @"minecraftpe\global_resource_packs.json"))) return;

            if (!cosmeticEnabled(id))
            {
                List<CosmeticsObject> packs = packList();

                if (packs[0].pack_id == "error") return;

                if (id == "b6039dbe-c5f1-4544-afdb-dd4b9ed7d19e")
                {
                    packs.Insert(0, new CosmeticsObject()
                    {
                        pack_id = id,
                        version = new int[] { 6, 0, 0 }
                    });
                }
                else
                {
                    packs.Insert(0, new CosmeticsObject()
                    {
                        pack_id = id,
                        version = _packInfo[id]
                    });
                }


                File.WriteAllText(Path.Combine(minecraftResourcePacks, @"..", @"minecraftpe\global_resource_packs.json"), JsonConvert.SerializeObject(packs, Formatting.Indented));
            }
        }
        #endregion

        private void InitCosmetics()
        {
            //Cape Load
            if (_cosmeticsCS.cBlack)
            {
                if (!File.Exists(Path.Combine(minecraftResourcePacks, @"BlackVentileCape.zip")))
                {
                    Download(string.Format(@"https://github.com/" + LINK_SETTINGS.repoOwner + "/" + LINK_SETTINGS.downloadRepo + @"/blob/main/Cosmetics/{0}?raw=true", "BlackVentileCape.zip"), minecraftResourcePacks, "BlackVentileCape.zip");
                    addCosmetic(_packInfo.ElementAt(0).Key);
                }
                cBlack.Checked = true;


            }
            else if (_cosmeticsCS.cWhite)
            {
                if (!File.Exists(Path.Combine(minecraftResourcePacks, @"WhiteVentileCape.zip")))
                {
                    Download(string.Format(@"https://github.com/" + LINK_SETTINGS.repoOwner + "/" + LINK_SETTINGS.downloadRepo + @"/blob/main/Cosmetics/{0}?raw=true", "WhiteVentileCape.zip"), minecraftResourcePacks, "WhiteVentileCape.zip");
                    addCosmetic(_packInfo.ElementAt(1).Key);
                }
                cWhite.Checked = true;

            }
            else if (_cosmeticsCS.cPink)
            {
                if (!File.Exists(Path.Combine(minecraftResourcePacks, @"PinkVentileCape.zip")))
                {
                    Download(string.Format(@"https://github.com/" + LINK_SETTINGS.repoOwner + "/" + LINK_SETTINGS.downloadRepo + @"/blob/main/Cosmetics/{0}?raw=true", "PinkVentileCape.zip"), minecraftResourcePacks, "PinkVentileCape.zip");
                    addCosmetic(_packInfo.ElementAt(2).Key);
                }
                cPink.Checked = true;

            }
            else if (_cosmeticsCS.cBlue)
            {
                if (!File.Exists(Path.Combine(minecraftResourcePacks, @"BlueVentileCape.zip")))
                {
                    Download(string.Format(@"https://github.com/" + LINK_SETTINGS.repoOwner + "/" + LINK_SETTINGS.downloadRepo + @"/blob/main/Cosmetics/{0}?raw=true", "BlueVentileCape.zip"), minecraftResourcePacks, "BlueVentileCape.zip");
                    addCosmetic(_packInfo.ElementAt(3).Key);
                }
                cBlue.Checked = true;

            }
            else if (_cosmeticsCS.cYellow)
            {
                if (!File.Exists(Path.Combine(minecraftResourcePacks, @"YellowVentileCape.zip")))
                {
                    Download(string.Format(@"https://github.com/" + LINK_SETTINGS.repoOwner + "/" + LINK_SETTINGS.downloadRepo + @"/blob/main/Cosmetics/{0}?raw=true", "YellowVentileCape.zip"), minecraftResourcePacks, "YellowVentileCape.zip");
                    addCosmetic(_packInfo.ElementAt(4).Key);
                }
                cYellow.Checked = true;

            }
            else if (_cosmeticsCS.cRick)
            {
                if (!File.Exists(Path.Combine(minecraftResourcePacks, @"RickVentileCape.zip")))
                {
                    Download(string.Format(@"https://github.com/" + LINK_SETTINGS.repoOwner + "/" + LINK_SETTINGS.downloadRepo + @"/blob/main/Cosmetics/{0}?raw=true", "RickVentileCape.zip"), minecraftResourcePacks, "RickVentileCape.zip");
                    addCosmetic(_packInfo.ElementAt(5).Key);
                }
                cRick.Checked = true;

            }

            //Mask Load
            if (_cosmeticsCS.mBlack)
            {
                if (!File.Exists(Path.Combine(minecraftResourcePacks, @"BlackVentileMask.zip")))
                {
                    Download(string.Format(@"https://github.com/" + LINK_SETTINGS.repoOwner + "/" + LINK_SETTINGS.downloadRepo + @"/blob/main/Cosmetics/{0}?raw=true", "BlackVentileMask.zip"), minecraftResourcePacks, "BlackVentileMask.zip");
                    addCosmetic(_packInfo.ElementAt(6).Key);
                }
                mBlack.Checked = true;

            }
            else if (_cosmeticsCS.mWhite)
            {
                if (!File.Exists(Path.Combine(minecraftResourcePacks, @"WhiteVentileMask.zip")))
                {
                    Download(string.Format(@"https://github.com/" + LINK_SETTINGS.repoOwner + "/" + LINK_SETTINGS.downloadRepo + @"/blob/main/Cosmetics/{0}?raw=true", "WhiteVentileMask.zip"), minecraftResourcePacks, "WhiteVentileMask.zip");
                    addCosmetic(_packInfo.ElementAt(7).Key);
                }
                mWhite.Checked = true;

            }
            else if (_cosmeticsCS.mPink)
            {
                if (!File.Exists(Path.Combine(minecraftResourcePacks, @"PinkVentileMask.zip")))
                {
                    Download(string.Format(@"https://github.com/" + LINK_SETTINGS.repoOwner + "/" + LINK_SETTINGS.downloadRepo + @"/blob/main/Cosmetics/{0}?raw=true", "PinkVentileMask.zip"), minecraftResourcePacks, "PinkVentileMask.zip");
                    addCosmetic(_packInfo.ElementAt(8).Key);
                }
                mPink.Checked = true;

            }
            else if (_cosmeticsCS.mBlue)
            {
                if (!File.Exists(Path.Combine(minecraftResourcePacks, @"BlueVentileMask.zip")))
                {
                    Download(string.Format(@"https://github.com/" + LINK_SETTINGS.repoOwner + "/" + LINK_SETTINGS.downloadRepo + @"/blob/main/Cosmetics/{0}?raw=true", "BlueVentileMask.zip"), minecraftResourcePacks, "BlueVentileMask.zip");
                    addCosmetic(_packInfo.ElementAt(9).Key);
                }
                mBlue.Checked = true;

            }
            else if (_cosmeticsCS.mYellow)
            {
                if (!File.Exists(Path.Combine(minecraftResourcePacks, @"BlackVentileMask.zip")))
                {
                    Download(string.Format(@"https://github.com/" + LINK_SETTINGS.repoOwner + "/" + LINK_SETTINGS.downloadRepo + @"/blob/main/Cosmetics/{0}?raw=true", "YellowVentileMask.zip"), minecraftResourcePacks, "YellowVentileMask.zip");
                    addCosmetic(_packInfo.ElementAt(10).Key);
                }
                mYellow.Checked = true;

            }
            else if (_cosmeticsCS.mRick)
            {
                if (!File.Exists(Path.Combine(minecraftResourcePacks, @"RickVentileMask.zip")))
                {
                    Download(string.Format(@"https://github.com/" + LINK_SETTINGS.repoOwner + "/" + LINK_SETTINGS.downloadRepo + @"/blob/main/Cosmetics/{0}?raw=true", "RickVentileMask.zip"), minecraftResourcePacks, "RickVentileMask.zip");
                    addCosmetic(_packInfo.ElementAt(11).Key);
                }
                mRick.Checked = true;

            }

            //Load Extras
            if (_cosmeticsCS.aGlowing)
            {
                if (!File.Exists(Path.Combine(minecraftResourcePacks, @"GlowingVentileCape.zip")))
                {
                    Download(string.Format(@"https://github.com/" + LINK_SETTINGS.repoOwner + "/" + LINK_SETTINGS.downloadRepo + @"/blob/main/Cosmetics/{0}?raw=true", "GlowingVentileCape.zip"), minecraftResourcePacks, "GlowingVentileCape.zip");
                    addCosmetic(_packInfo.ElementAt(12).Key);
                }
                aGlowing.Checked = true;

            }
            else if (_cosmeticsCS.aSlide)
            {
                if (!File.Exists(Path.Combine(minecraftResourcePacks, @"SlidingVentileCape.zip")))
                {
                    Download(string.Format(@"https://github.com/" + LINK_SETTINGS.repoOwner + "/" + LINK_SETTINGS.downloadRepo + @"/blob/main/Cosmetics/{0}?raw=true", "SlidingVentileCape.zip"), minecraftResourcePacks, "SlidingVentileCape.zip");
                    addCosmetic(_packInfo.ElementAt(13).Key);
                }
                aSlide.Checked = true;

            }
            else if (_cosmeticsCS.oWavy)
            {
                if (!File.Exists(Path.Combine(minecraftResourcePacks, @"WavyVentile.zip")))
                {
                    Download(string.Format(@"https://github.com/" + LINK_SETTINGS.repoOwner + "/" + LINK_SETTINGS.downloadRepo + @"/blob/main/Cosmetics/{0}?raw=true", "WavyVentile.zip"), minecraftResourcePacks, "WavyVentile.zip");
                    addCosmetic(_packInfo.ElementAt(14).Key);
                }
                oWavy.Checked = true;

            }
            else if (_cosmeticsCS.oKagune)
            {
                if (!File.Exists(Path.Combine(minecraftResourcePacks, @"KaguneVentile.zip")))
                {
                    Download(string.Format(@"https://github.com/" + LINK_SETTINGS.repoOwner + "/" + LINK_SETTINGS.downloadRepo + @"/blob/main/Cosmetics/{0}?raw=true", "KaguneVentile.zip"), minecraftResourcePacks, "KaguneVentile.zip");
                    addCosmetic(_packInfo.ElementAt(15).Key);
                }
                oKagune.Checked = true;

            }

            if (File.Exists(Path.Combine(minecraftResourcePacks, @"CosmeticMixer.zip")))
            {
                File.Delete(Path.Combine(minecraftResourcePacks, @"CosmeticMixer.zip"));
            }

            Download(string.Format(@"https://github.com/" + LINK_SETTINGS.repoOwner + "/" + LINK_SETTINGS.downloadRepo + @"/blob/main/Cosmetics/{0}?raw=true", "CosmeticMixer.zip"), minecraftResourcePacks, "CosmeticMixer.zip");

            removeCosmetic("b6039dbe-c5f1-4544-afdb-dd4b9ed7d19e");
            addCosmetic("b6039dbe-c5f1-4544-afdb-dd4b9ed7d19e");
        }

        private void ChangeCosmeticColors()
        {
            // Make the color variable smaller
            Color backColor = ColorTranslator.FromHtml(_themeCS.Background);
            Color accentColor = ColorTranslator.FromHtml(_themeCS.Accent);
            Color foreColor = ColorTranslator.FromHtml(_themeCS.Foreground);
            Color backColor2 = ColorTranslator.FromHtml(_themeCS.SecondBackground);

            //Background
            cosmeticsBackground.BackColor = backColor;

            //Titles
            capesTitle.ForeColor = foreColor;
            capesTitle.BackColor = backColor;

            masksTitle.ForeColor = foreColor;
            masksTitle.BackColor = backColor;

            animatedCapesTitle.ForeColor = foreColor;
            animatedCapesTitle.BackColor = backColor;

            othersTitle.ForeColor = foreColor;
            othersTitle.BackColor = backColor;

            //Buttons
            //Capes
            cBlack.BackColor = backColor;
            cBlack.FillColor = backColor2;
            cBlack.CheckedState.FillColor = accentColor;
            cBlack.ForeColor = foreColor;

            cWhite.BackColor = backColor;
            cWhite.FillColor = backColor2;
            cWhite.CheckedState.FillColor = accentColor;
            cWhite.ForeColor = foreColor;

            cPink.BackColor = backColor;
            cPink.FillColor = backColor2;
            cPink.CheckedState.FillColor = accentColor;
            cPink.ForeColor = foreColor;

            cBlue.BackColor = backColor;
            cBlue.FillColor = backColor2;
            cBlue.CheckedState.FillColor = accentColor;
            cBlue.ForeColor = foreColor;

            cYellow.BackColor = backColor;
            cYellow.FillColor = backColor2;
            cYellow.CheckedState.FillColor = accentColor;
            cYellow.ForeColor = foreColor;

            cRick.BackColor = backColor;
            cRick.FillColor = backColor2;
            cRick.CheckedState.FillColor = accentColor;
            cRick.ForeColor = foreColor;

            //Masks
            mBlack.BackColor = backColor;
            mBlack.FillColor = backColor2;
            mBlack.CheckedState.FillColor = accentColor;
            mBlack.ForeColor = foreColor;

            mWhite.BackColor = backColor;
            mWhite.FillColor = backColor2;
            mWhite.CheckedState.FillColor = accentColor;
            mWhite.ForeColor = foreColor;

            mPink.BackColor = backColor;
            mPink.FillColor = backColor2;
            mPink.CheckedState.FillColor = accentColor;
            mPink.ForeColor = foreColor;

            mBlue.BackColor = backColor;
            mBlue.FillColor = backColor2;
            mBlue.CheckedState.FillColor = accentColor;
            mBlue.ForeColor = foreColor;

            mYellow.BackColor = backColor;
            mYellow.FillColor = backColor2;
            mYellow.CheckedState.FillColor = accentColor;
            mYellow.ForeColor = foreColor;

            mRick.BackColor = backColor;
            mRick.FillColor = backColor2;
            mRick.CheckedState.FillColor = accentColor;
            mRick.ForeColor = foreColor;

            //Animated Capes
            aGlowing.BackColor = backColor;
            aGlowing.FillColor = backColor2;
            aGlowing.CheckedState.FillColor = accentColor;
            aGlowing.ForeColor = foreColor;

            aSlide.BackColor = backColor;
            aSlide.FillColor = backColor2;
            aSlide.CheckedState.FillColor = accentColor;
            aSlide.ForeColor = foreColor;

            //Other
            oWavy.BackColor = backColor;
            oWavy.FillColor = backColor2;
            oWavy.CheckedState.FillColor = accentColor;
            oWavy.ForeColor = foreColor;

            oKagune.BackColor = backColor;
            oKagune.FillColor = backColor2;
            oKagune.CheckedState.FillColor = accentColor;
            oKagune.ForeColor = foreColor;

            resetAllCosmetics.BackColor = backColor;
            resetAllCosmetics.FillColor = backColor2;
            resetAllCosmetics.CheckedState.FillColor = accentColor;
            resetAllCosmetics.ForeColor = foreColor;

            //Rounded Buttons
            if (_configCS.RoundedButtons)
            {
                resetAllCosmetics.AutoRoundedCorners = true;
                cBlack.AutoRoundedCorners = true;
                cWhite.AutoRoundedCorners = true;
                cPink.AutoRoundedCorners = true;
                cBlue.AutoRoundedCorners = true;
                cYellow.AutoRoundedCorners = true;
                cRick.AutoRoundedCorners = true;

                mBlack.AutoRoundedCorners = true;
                mWhite.AutoRoundedCorners = true;
                mPink.AutoRoundedCorners = true;
                mBlue.AutoRoundedCorners = true;
                mYellow.AutoRoundedCorners = true;
                mRick.AutoRoundedCorners = true;
                aGlowing.AutoRoundedCorners = true;
                aSlide.AutoRoundedCorners = true;
                oWavy.AutoRoundedCorners = true;
                oKagune.AutoRoundedCorners = true;
            }
            else
            {
                resetAllCosmetics.AutoRoundedCorners = false;
                cBlack.AutoRoundedCorners = false;
                cWhite.AutoRoundedCorners = false;
                cPink.AutoRoundedCorners = false;
                cBlue.AutoRoundedCorners = false;
                cYellow.AutoRoundedCorners = false;
                cRick.AutoRoundedCorners = false;
                mBlack.AutoRoundedCorners = false;
                mWhite.AutoRoundedCorners = false;
                mPink.AutoRoundedCorners = false;
                mBlue.AutoRoundedCorners = false;
                mYellow.AutoRoundedCorners = false;
                mRick.AutoRoundedCorners = false;
                aGlowing.AutoRoundedCorners = false;
                aSlide.AutoRoundedCorners = false;
                oWavy.AutoRoundedCorners = false;
                oKagune.AutoRoundedCorners = false;
            }

            //Performance Mode
            if (_configCS.PerformanceMode)
            {
                resetAllCosmetics.Animated = false;
                cBlack.Animated = false;
                cWhite.Animated = false;
                cPink.Animated = false;
                cBlue.Animated = false;
                cYellow.Animated = false;
                cRick.Animated = false;
                mBlack.Animated = false;
                mWhite.Animated = false;
                mPink.Animated = false;
                mBlue.Animated = false;
                mYellow.Animated = false;
                mRick.Animated = false;
                aGlowing.Animated = false;
                aSlide.Animated = false;
                oWavy.Animated = false;
                oKagune.Animated = false;
            }
            else
            {
                resetAllCosmetics.Animated = true;
                cBlack.Animated = true;
                cWhite.Animated = true;
                cPink.Animated = true;
                cBlue.Animated = true;
                cYellow.Animated = true;
                cRick.Animated = true;

                mBlack.Animated = true;
                mWhite.Animated = true;
                mPink.Animated = true;
                mBlue.Animated = true;
                mYellow.Animated = true;
                mRick.Animated = true;
                aGlowing.Animated = true;
                aSlide.Animated = true;
                oWavy.Animated = true;
                oKagune.Animated = true;
            }
        }

        #region Capes
        private void cBlack_Click(object sender, EventArgs e)
        {
            resetCapes();
            if (internet)
            {
                cBlack.Checked = true;
                _cosmeticsCS.cBlack = true;
                addCosmetic(_packInfo.ElementAt(0).Key);
                removeCosmetic("b6039dbe-c5f1-4544-afdb-dd4b9ed7d19e");
                addCosmetic("b6039dbe-c5f1-4544-afdb-dd4b9ed7d19e");

                WriteCosmetics(@"C:\temp\VentileClient\Presets\Cosmetics.json");

                //Auto Download
                Download(string.Format(@"https://github.com/" + LINK_SETTINGS.repoOwner + "/" + LINK_SETTINGS.downloadRepo + @"/blob/main/Cosmetics/{0}?raw=true", "BlackVentileCape.zip"), minecraftResourcePacks, "BlackVentileCape.zip");

            }
            else
            {
                this.Toast("Internet", "You do not a wifi connection");
            }
        }

        private void cWhite_Click(object sender, EventArgs e)
        {
            resetCapes();
            if (internet)
            {
                cWhite.Checked = true;
                _cosmeticsCS.cWhite = true;
                addCosmetic(_packInfo.ElementAt(1).Key);
                removeCosmetic("b6039dbe-c5f1-4544-afdb-dd4b9ed7d19e");
                addCosmetic("b6039dbe-c5f1-4544-afdb-dd4b9ed7d19e");

                WriteCosmetics(@"C:\temp\VentileClient\Presets\Cosmetics.json");

                //Auto Download
                Download(string.Format(@"https://github.com/" + LINK_SETTINGS.repoOwner + "/" + LINK_SETTINGS.downloadRepo + @"/blob/main/Cosmetics/{0}?raw=true", "WhiteVentileCape.zip"), minecraftResourcePacks, "WhiteVentileCape.zip");

            }
            else
            {
                this.Toast("Internet", "You do not a wifi connection");
            }
        }

        private void cPink_Click(object sender, EventArgs e)
        {
            resetCapes();
            if (internet)
            {
                cPink.Checked = true;
                _cosmeticsCS.cPink = true;
                addCosmetic(_packInfo.ElementAt(2).Key);
                removeCosmetic("b6039dbe-c5f1-4544-afdb-dd4b9ed7d19e");
                addCosmetic("b6039dbe-c5f1-4544-afdb-dd4b9ed7d19e");

                WriteCosmetics(@"C:\temp\VentileClient\Presets\Cosmetics.json");

                //Auto Download
                Download(string.Format(@"https://github.com/" + LINK_SETTINGS.repoOwner + "/" + LINK_SETTINGS.downloadRepo + @"/blob/main/Cosmetics/{0}?raw=true", "PinkVentileCape.zip"), minecraftResourcePacks, "PinkVentileCape.zip");

            }
            else
            {
                this.Toast("Internet", "You do not a wifi connection");
            }
        }

        private void cBlue_Click(object sender, EventArgs e)
        {
            resetCapes();
            if (internet)
            {
                cBlue.Checked = true;
                _cosmeticsCS.cBlue = true;
                addCosmetic(_packInfo.ElementAt(3).Key);
                removeCosmetic("b6039dbe-c5f1-4544-afdb-dd4b9ed7d19e");
                addCosmetic("b6039dbe-c5f1-4544-afdb-dd4b9ed7d19e");

                WriteCosmetics(@"C:\temp\VentileClient\Presets\Cosmetics.json");

                //Auto Download
                Download(string.Format(@"https://github.com/" + LINK_SETTINGS.repoOwner + "/" + LINK_SETTINGS.downloadRepo + @"/blob/main/Cosmetics/{0}?raw=true", "BlueVentileCape.zip"), minecraftResourcePacks, "BlueVentileCape.zip");

            }
            else
            {
                this.Toast("Internet", "You do not a wifi connection");
            }
        }

        private void cYellow_Click(object sender, EventArgs e)
        {
            resetCapes();
            if (internet)
            {
                cYellow.Checked = true;
                _cosmeticsCS.cYellow = true;
                addCosmetic(_packInfo.ElementAt(4).Key);
                removeCosmetic("b6039dbe-c5f1-4544-afdb-dd4b9ed7d19e");
                addCosmetic("b6039dbe-c5f1-4544-afdb-dd4b9ed7d19e");

                WriteCosmetics(@"C:\temp\VentileClient\Presets\Cosmetics.json");

                //Auto Download
                Download(string.Format(@"https://github.com/" + LINK_SETTINGS.repoOwner + "/" + LINK_SETTINGS.downloadRepo + @"/blob/main/Cosmetics/{0}?raw=true", "YellowVentileCape.zip"), minecraftResourcePacks, "YellowVentileCape.zip");

            }
            else
            {
                this.Toast("Internet", "You do not a wifi connection");
            }
        }

        private void cRick_Click(object sender, EventArgs e)
        {
            resetCapes();
            if (internet)
            {
                cRick.Checked = true;
                _cosmeticsCS.cRick = true;
                addCosmetic(_packInfo.ElementAt(5).Key);
                removeCosmetic("b6039dbe-c5f1-4544-afdb-dd4b9ed7d19e");
                addCosmetic("b6039dbe-c5f1-4544-afdb-dd4b9ed7d19e");

                WriteCosmetics(@"C:\temp\VentileClient\Presets\Cosmetics.json");

                //Auto Download
                Download(string.Format(@"https://github.com/" + LINK_SETTINGS.repoOwner + "/" + LINK_SETTINGS.downloadRepo + @"/blob/main/Cosmetics/{0}?raw=true", "RickVentileCape.zip"), minecraftResourcePacks, "RickVentileCape.zip");

            }
            else
            {
                this.Toast("Internet", "You do not a wifi connection");
            }
        }

        private void resetCapes()
        {
            _cosmeticsCS.cBlack = false;
            _cosmeticsCS.cWhite = false;
            _cosmeticsCS.cPink = false;
            _cosmeticsCS.cBlue = false;
            _cosmeticsCS.cYellow = false;
            _cosmeticsCS.cRick = false;

            cBlack.Checked = false;
            cWhite.Checked = false;
            cPink.Checked = false;
            cBlue.Checked = false;
            cYellow.Checked = false;
            cRick.Checked = false;

            if (internet)
            {
                removeCosmetic(_packInfo.ElementAt(0).Key);
                removeCosmetic(_packInfo.ElementAt(1).Key);
                removeCosmetic(_packInfo.ElementAt(2).Key);
                removeCosmetic(_packInfo.ElementAt(3).Key);
                removeCosmetic(_packInfo.ElementAt(4).Key);
                removeCosmetic(_packInfo.ElementAt(5).Key);


                if (File.Exists(Path.Combine(minecraftResourcePacks, @"BlackVentileCape.zip")))
                {
                    File.Delete(Path.Combine(minecraftResourcePacks, @"BlackVentileCape.zip"));
                }
                if (File.Exists(Path.Combine(minecraftResourcePacks, @"WhiteVentileCape.zip")))
                {
                    File.Delete(Path.Combine(minecraftResourcePacks, @"WhiteVentileCape.zip"));
                }
                if (File.Exists(Path.Combine(minecraftResourcePacks, @"PinkVentileCape.zip")))
                {
                    File.Delete(Path.Combine(minecraftResourcePacks, @"PinkVentileCape.zip"));
                }
                if (File.Exists(Path.Combine(minecraftResourcePacks, @"BlueVentileCape.zip")))
                {
                    File.Delete(Path.Combine(minecraftResourcePacks, @"BlueVentileCape.zip"));
                }
                if (File.Exists(Path.Combine(minecraftResourcePacks, @"YellowVentileCape.zip")))
                {
                    File.Delete(Path.Combine(minecraftResourcePacks, @"YellowVentileCape.zip"));
                }
                if (File.Exists(Path.Combine(minecraftResourcePacks, @"RickVentileCape.zip")))
                {
                    File.Delete(Path.Combine(minecraftResourcePacks, @"RickVentileCape.zip"));
                }
            }
        }
        #endregion

        #region Masks

        private void mBlack_Click(object sender, EventArgs e)
        {
            resetMasks();
            if (internet)
            {
                mBlack.Checked = true;
                _cosmeticsCS.mBlack = true;
                addCosmetic(_packInfo.ElementAt(6).Key);
                removeCosmetic("b6039dbe-c5f1-4544-afdb-dd4b9ed7d19e");
                addCosmetic("b6039dbe-c5f1-4544-afdb-dd4b9ed7d19e");

                WriteCosmetics(@"C:\temp\VentileClient\Presets\Cosmetics.json");

                //Auto Download
                Download(string.Format(@"https://github.com/" + LINK_SETTINGS.repoOwner + "/" + LINK_SETTINGS.downloadRepo + @"/blob/main/Cosmetics/{0}?raw=true", "BlackVentileMask.zip"), minecraftResourcePacks, "BlackVentileMask.zip");

            }
            else
            {
                this.Toast("Internet", "You do not a wifi connection");
            }
        }

        private void mWhite_Click(object sender, EventArgs e)
        {
            resetMasks();
            if (internet)
            {
                mWhite.Checked = true;
                _cosmeticsCS.mWhite = true;
                addCosmetic(_packInfo.ElementAt(7).Key);
                removeCosmetic("b6039dbe-c5f1-4544-afdb-dd4b9ed7d19e");
                addCosmetic("b6039dbe-c5f1-4544-afdb-dd4b9ed7d19e");

                WriteCosmetics(@"C:\temp\VentileClient\Presets\Cosmetics.json");

                //Auto Download
                Download(string.Format(@"https://github.com/" + LINK_SETTINGS.repoOwner + "/" + LINK_SETTINGS.downloadRepo + @"/blob/main/Cosmetics/{0}?raw=true", "WhiteVentileMask.zip"), minecraftResourcePacks, "WhiteVentileMask.zip");

            }
            else
            {
                this.Toast("Internet", "You do not a wifi connection");
            }
        }

        private void mPink_Click(object sender, EventArgs e)
        {
            resetMasks();
            if (internet)
            {
                mPink.Checked = true;
                _cosmeticsCS.mPink = true;
                addCosmetic(_packInfo.ElementAt(8).Key);
                removeCosmetic("b6039dbe-c5f1-4544-afdb-dd4b9ed7d19e");
                addCosmetic("b6039dbe-c5f1-4544-afdb-dd4b9ed7d19e");

                WriteCosmetics(@"C:\temp\VentileClient\Presets\Cosmetics.json");

                //Auto Download
                Download(string.Format(@"https://github.com/" + LINK_SETTINGS.repoOwner + "/" + LINK_SETTINGS.downloadRepo + @"/blob/main/Cosmetics/{0}?raw=true", "PinkVentileMask.zip"), minecraftResourcePacks, "PinkVentileMask.zip");

            }
            else
            {
                this.Toast("Internet", "You do not a wifi connection");
            }
        }

        private void mBlue_Click(object sender, EventArgs e)
        {
            resetMasks();
            if (internet)
            {
                mBlue.Checked = true;
                _cosmeticsCS.mBlue = true;
                addCosmetic(_packInfo.ElementAt(9).Key);
                removeCosmetic("b6039dbe-c5f1-4544-afdb-dd4b9ed7d19e");
                addCosmetic("b6039dbe-c5f1-4544-afdb-dd4b9ed7d19e");

                WriteCosmetics(@"C:\temp\VentileClient\Presets\Cosmetics.json");

                //Auto Download
                Download(string.Format(@"https://github.com/" + LINK_SETTINGS.repoOwner + "/" + LINK_SETTINGS.downloadRepo + @"/blob/main/Cosmetics/{0}?raw=true", "BlueVentileMask.zip"), minecraftResourcePacks, "BlueVentileMask.zip");

            }
            else
            {
                this.Toast("Internet", "You do not a wifi connection");
            }
        }

        private void mYellow_Click(object sender, EventArgs e)
        {
            resetMasks();
            if (internet)
            {
                mYellow.Checked = true;
                _cosmeticsCS.mYellow = true;
                addCosmetic(_packInfo.ElementAt(10).Key);
                removeCosmetic("b6039dbe-c5f1-4544-afdb-dd4b9ed7d19e");
                addCosmetic("b6039dbe-c5f1-4544-afdb-dd4b9ed7d19e");

                WriteCosmetics(@"C:\temp\VentileClient\Presets\Cosmetics.json");

                //Auto Download
                Download(string.Format(@"https://github.com/" + LINK_SETTINGS.repoOwner + "/" + LINK_SETTINGS.downloadRepo + @"/blob/main/Cosmetics/{0}?raw=true", "YellowVentileMask.zip"), minecraftResourcePacks, "YellowVentileMask.zip");

            }
            else
            {
                this.Toast("Internet", "You do not a wifi connection");
            }
        }

        private void mRick_Click(object sender, EventArgs e)
        {
            resetMasks();
            if (internet)
            {
                mRick.Checked = true;
                _cosmeticsCS.mRick = true;
                addCosmetic(_packInfo.ElementAt(11).Key);
                removeCosmetic("b6039dbe-c5f1-4544-afdb-dd4b9ed7d19e");
                addCosmetic("b6039dbe-c5f1-4544-afdb-dd4b9ed7d19e");

                WriteCosmetics(@"C:\temp\VentileClient\Presets\Cosmetics.json");

                //Auto Download
                Download(string.Format(@"https://github.com/" + LINK_SETTINGS.repoOwner + "/" + LINK_SETTINGS.downloadRepo + @"/blob/main/Cosmetics/{0}?raw=true", "RickVentileMask.zip"), minecraftResourcePacks, "RickVentileMask.zip");

            }
            else
            {
                this.Toast("Internet", "You do not a wifi connection");
            }
        }

        private void resetMasks()
        {
            mBlack.Checked = false;
            mWhite.Checked = false;
            mPink.Checked = false;
            mBlue.Checked = false;
            mYellow.Checked = false;
            mRick.Checked = false;

            if (internet)
            {

                removeCosmetic(_packInfo.ElementAt(6).Key);
                removeCosmetic(_packInfo.ElementAt(7).Key);
                removeCosmetic(_packInfo.ElementAt(8).Key);
                removeCosmetic(_packInfo.ElementAt(9).Key);
                removeCosmetic(_packInfo.ElementAt(10).Key);
                removeCosmetic(_packInfo.ElementAt(11).Key);


                //Delete
                if (File.Exists(Path.Combine(minecraftResourcePacks, @"BlackVentileMask.zip")))
                {
                    File.Delete(Path.Combine(minecraftResourcePacks, @"BlackVentileMask.zip"));
                }
                if (File.Exists(Path.Combine(minecraftResourcePacks, @"WhiteVentileMask.zip")))
                {
                    File.Delete(Path.Combine(minecraftResourcePacks, @"WhiteVentileMask.zip"));
                }
                if (File.Exists(Path.Combine(minecraftResourcePacks, @"PinkVentileMask.zip")))
                {
                    File.Delete(Path.Combine(minecraftResourcePacks, @"PinkVentileMask.zip"));
                }
                if (File.Exists(Path.Combine(minecraftResourcePacks, @"BlueVentileMask.zip")))
                {
                    File.Delete(Path.Combine(minecraftResourcePacks, @"BlueVentileMask.zip"));
                }
                if (File.Exists(Path.Combine(minecraftResourcePacks, @"YellowVentileMask.zip")))
                {
                    File.Delete(Path.Combine(minecraftResourcePacks, @"YellowVentileMask.zip"));
                }
                if (File.Exists(Path.Combine(minecraftResourcePacks, @"RickVentileMask.zip")))
                {
                    File.Delete(Path.Combine(minecraftResourcePacks, @"RickVentileMask.zip"));
                }
            }
        }

        #endregion

        #region Extras

        private void aGlowing_Click(object sender, EventArgs e)
        {
            resetExtras();
            if (internet)
            {
                aGlowing.Checked = true;
                _cosmeticsCS.aGlowing = true;
                addCosmetic(_packInfo.ElementAt(12).Key);
                removeCosmetic("b6039dbe-c5f1-4544-afdb-dd4b9ed7d19e");
                addCosmetic("b6039dbe-c5f1-4544-afdb-dd4b9ed7d19e");

                WriteCosmetics(@"C:\temp\VentileClient\Presets\Cosmetics.json");

                Download(string.Format(@"https://github.com/" + LINK_SETTINGS.repoOwner + "/" + LINK_SETTINGS.downloadRepo + @"/blob/main/Cosmetics/{0}?raw=true", "GlowingVentileCape.zip"), minecraftResourcePacks, "GlowingVentileCape.zip");
            }
            else
            {
                this.Toast("Internet", "You do not a wifi connection");
            }
        }

        private void aSlide_Click(object sender, EventArgs e)
        {
            resetExtras();
            if (internet)
            {
                aSlide.Checked = true;
                _cosmeticsCS.aGlowing = true;

                addCosmetic(_packInfo.ElementAt(13).Key);
                removeCosmetic("b6039dbe-c5f1-4544-afdb-dd4b9ed7d19e");
                addCosmetic("b6039dbe-c5f1-4544-afdb-dd4b9ed7d19e");

                WriteCosmetics(@"C:\temp\VentileClient\Presets\Cosmetics.json");

                Download(string.Format(@"https://github.com/" + LINK_SETTINGS.repoOwner + "/" + LINK_SETTINGS.downloadRepo + @"/blob/main/Cosmetics/{0}?raw=true", "SlidingVentileCape.zip"), minecraftResourcePacks, "SlidingVentileCape.zip");
            }
            else
            {
                this.Toast("Internet", "You do not a wifi connection");
            }
        }

        private void resetExtras()
        {
            aGlowing.Checked = false;
            aSlide.Checked = false;

            _cosmeticsCS.aGlowing = false;
            _cosmeticsCS.aSlide = false;

            removeCosmetic(_packInfo.ElementAt(12).Key);
            removeCosmetic(_packInfo.ElementAt(13).Key);


            if (internet)
            {
                //Extras
                if (File.Exists(Path.Combine(minecraftResourcePacks, @"GlowingVentileCape.zip")))
                {
                    File.Delete(Path.Combine(minecraftResourcePacks, @"GlowingVentileCape.zip"));
                }
                if (File.Exists(Path.Combine(minecraftResourcePacks, @"SlidingVentileCape.zip")))
                {
                    File.Delete(Path.Combine(minecraftResourcePacks, @"SlidingVentileCape.zip"));
                }
            }
        }

        #endregion

        #region Others

        private void oWavy_Click(object sender, EventArgs e)
        {
            resetOthers();
            if (internet)
            {
                oWavy.Checked = true;
                _cosmeticsCS.oWavy = true;

                addCosmetic(_packInfo.ElementAt(14).Key);
                removeCosmetic("b6039dbe-c5f1-4544-afdb-dd4b9ed7d19e");
                addCosmetic("b6039dbe-c5f1-4544-afdb-dd4b9ed7d19e");

                WriteCosmetics(@"C:\temp\VentileClient\Presets\Cosmetics.json");

                Download(string.Format(@"https://github.com/" + LINK_SETTINGS.repoOwner + "/" + LINK_SETTINGS.downloadRepo + @"/blob/main/Cosmetics/{0}?raw=true", "WavyVentile.zip"), minecraftResourcePacks, "WavyVentile.zip");
            }
            else
            {
                this.Toast("Internet", "You do not a wifi connection");
            }
        }

        private void oKagune_Click(object sender, EventArgs e)
        {
            if (internet)
            {
                oKagune.Checked = true;
                _cosmeticsCS.oKagune = true;

                addCosmetic(_packInfo.ElementAt(15).Key);
                removeCosmetic("b6039dbe-c5f1-4544-afdb-dd4b9ed7d19e");
                addCosmetic("b6039dbe-c5f1-4544-afdb-dd4b9ed7d19e");

                WriteCosmetics(@"C:\temp\VentileClient\Presets\Cosmetics.json");

                Download(string.Format(@"https://github.com/" + LINK_SETTINGS.repoOwner + "/" + LINK_SETTINGS.downloadRepo + @"/blob/main/Cosmetics/{0}?raw=true", "Kagune.zip"), minecraftResourcePacks, "KaguneVentile.zip");
            }
            else
            {
                this.Toast("Internet", "You do not a wifi connection");
            }
        }

        private void resetOthers()
        {
            oWavy.Checked = false;
            oKagune.Checked = false;

            _cosmeticsCS.oWavy = false;
            _cosmeticsCS.oKagune = false;

            removeCosmetic(_packInfo.ElementAt(11).Key);
            removeCosmetic(_packInfo.ElementAt(15).Key);


            if (internet)
            {
                //Extras
                if (File.Exists(Path.Combine(minecraftResourcePacks, @"WavyVentile.zip")))
                {
                    File.Delete(Path.Combine(minecraftResourcePacks, @"WavyVentile.zip"));
                }
                if (File.Exists(Path.Combine(minecraftResourcePacks, @"KaguneVentile.zip")))
                {
                    File.Delete(Path.Combine(minecraftResourcePacks, @"KaguneVentile.zip"));
                }
            }
        }

        #endregion

        private void resetAllCosmetics_Click(object sender, EventArgs e)
        {
            resetCapes();
            resetMasks();
            resetExtras();
            resetOthers();
            WriteCosmetics(@"C:\temp\VentileClient\Presets\Cosmetics.json");
        }

        #endregion

        #region Settings
        private void ChangeSettingColors()
        {

            // Make the color variable smaller
            Color backColor = ColorTranslator.FromHtml(_themeCS.Background);
            Color accentColor = ColorTranslator.FromHtml(_themeCS.Accent);
            Color foreColor = ColorTranslator.FromHtml(_themeCS.Foreground);
            Color outlineColor = ColorTranslator.FromHtml(_themeCS.Outline);
            Color backColor2 = ColorTranslator.FromHtml(_themeCS.SecondBackground);

            Launcher.BackColor = backColor;
            Appearance.BackColor = backColor;
            Extras.BackColor = backColor;

            // Launcher \\
            windowStateLabel.BackColor = backColor;
            richPresenceLabel.BackColor = backColor;
            devDLLLabel.BackColor = backColor;
            injectDelayLabel.BackColor = backColor;
            autoLabel.BackColor = backColor;
            resourceLabel.BackColor = backColor;
            rpcButtonTextLabel.BackColor = backColor;
            rpcButtonLinkLabel.BackColor = backColor;

            windowStateLabel.ForeColor = foreColor;
            richPresenceLabel.ForeColor = foreColor;
            devDLLLabel.ForeColor = foreColor;
            injectDelayLabel.ForeColor = foreColor;
            autoLabel.ForeColor = foreColor;
            resourceLabel.ForeColor = foreColor;
            rpcButtonTextLabel.ForeColor = foreColor;
            rpcButtonLinkLabel.ForeColor = foreColor;

            //WindowState

            hideWindow.CheckedState.FillColor = accentColor;
            hideWindow.ForeColor = foreColor;
            hideWindow.FillColor = backColor2;

            minWindow.CheckedState.FillColor = accentColor;
            minWindow.ForeColor = foreColor;
            minWindow.FillColor = backColor2;

            closeWindow.CheckedState.FillColor = accentColor;
            closeWindow.ForeColor = foreColor;
            closeWindow.FillColor = backColor2;

            openWindow.CheckedState.FillColor = accentColor;
            openWindow.ForeColor = foreColor;
            openWindow.FillColor = backColor2;

            //AutoInject
            autoInject.CheckedState.FillColor = accentColor;
            autoInject.ForeColor = foreColor;
            autoInject.FillColor = backColor2;

            //RPC
            RpcToggle.CheckedState.FillColor = accentColor;
            RpcToggle.ForeColor = foreColor;
            RpcToggle.FillColor = backColor2;

            buttonForRpc.CheckedState.FillColor = accentColor;
            buttonForRpc.ForeColor = foreColor;
            buttonForRpc.FillColor = backColor2;

            //DEV DLL
            customDLLButton.CheckedState.FillColor = accentColor;
            customDLLButton.ForeColor = foreColor;
            customDLLButton.FillColor = backColor2;

            //Inject Delay
            injectDelay.ForeColor = foreColor;
            injectDelay.UpDownButtonFillColor = accentColor;
            injectDelay.FillColor = backColor2;


            //Blank Setting
            customLoc.CheckedState.FillColor = accentColor;
            customLoc.ForeColor = foreColor;
            customLoc.FillColor = backColor2;

            AppearanceButton.ForeColor = foreColor;
            AppearanceButton.FillColor = backColor2;

            // Appearance \\
            //Sliders
            backgroundBrightnessSlider.BackColor = backColor;
            accentRedSlider.BackColor = backColor;
            accentGreenSlider.BackColor = backColor;
            accentBlueSlider.BackColor = backColor;
            outlineBrightnessSlider.BackColor = backColor;
            buttonBrightnessSlider.BackColor = backColor;
            textBrightnessSlider.BackColor = backColor;

            backgroundBrightnessSlider.ThumbColor = accentColor;
            accentRedSlider.ThumbColor = accentColor;
            accentGreenSlider.ThumbColor = accentColor;
            accentBlueSlider.ThumbColor = accentColor;
            outlineBrightnessSlider.ThumbColor = accentColor;
            buttonBrightnessSlider.ThumbColor = accentColor;
            textBrightnessSlider.ThumbColor = accentColor;

            //Labels
            backgroundColorLabel.BackColor = backColor;
            accentColorLabel.BackColor = backColor;
            outlineColorLabel.BackColor = backColor;
            buttonColorLabel.BackColor = backColor;
            foreColorLabel.BackColor = backColor;
            presetsLabel.BackColor = backColor;
            themeTitle.BackColor = backColor;

            backgroundColorLabel.ForeColor = foreColor;
            accentColorLabel.ForeColor = foreColor;
            outlineColorLabel.ForeColor = foreColor;
            buttonColorLabel.ForeColor = foreColor;
            foreColorLabel.ForeColor = foreColor;
            presetsLabel.ForeColor = foreColor;
            themeTitle.ForeColor = foreColor;

            //Buttons
            theme.FillColor = backColor2;
            theme.ForeColor = foreColor;

            resetThemes.FillColor = backColor2;
            resetThemes.ForeColor = foreColor;

            LauncherButton.FillColor = backColor2;
            LauncherButton.ForeColor = foreColor;

            ExtrasButton.FillColor = backColor2;
            ExtrasButton.ForeColor = foreColor;

            //Slider Labels
            labelForSlider1.BackColor = backColor;
            labelForSlider2.BackColor = backColor;
            labelForSlider3.BackColor = backColor;
            labelForSlider4.BackColor = backColor;
            labelForSlider5.BackColor = backColor;

            labelForSlider1.ForeColor = foreColor;
            labelForSlider2.ForeColor = foreColor;
            labelForSlider3.ForeColor = foreColor;
            labelForSlider4.ForeColor = foreColor;
            labelForSlider5.ForeColor = foreColor;

            backgroundBT.BackColor = backColor;
            accentRT.BackColor = backColor;
            accentGT.BackColor = backColor;
            accentBT.BackColor = backColor;
            buttonBuT.BackColor = backColor;
            foreBT.BackColor = backColor;

            backgroundBT.ForeColor = foreColor;
            accentRT.ForeColor = foreColor;
            accentGT.ForeColor = foreColor;
            accentBT.ForeColor = foreColor;
            buttonBuT.ForeColor = foreColor;
            foreBT.ForeColor = foreColor;

            //Tab Labels
            settingsTabLabel.ForeColor = foreColor;
            cosmeticsTabLabel.ForeColor = foreColor;
            aboutTabLabel.ForeColor = foreColor;

            //Rounded
            if (_configCS.RoundedButtons)
            {
                hideWindow.AutoRoundedCorners = true;
                minWindow.AutoRoundedCorners = true;
                closeWindow.AutoRoundedCorners = true;
                openWindow.AutoRoundedCorners = true;
                buttonForRpc.AutoRoundedCorners = true;
                customImage.AutoRoundedCorners = true;
                autoInject.AutoRoundedCorners = true;
                RpcToggle.AutoRoundedCorners = true;
                theme.AutoRoundedCorners = true;
                AppearanceButton.AutoRoundedCorners = true;
                LauncherButton.AutoRoundedCorners = true;
                ExtrasButton.AutoRoundedCorners = true;
                AppearanceButton2.AutoRoundedCorners = true;
                resetThemes.AutoRoundedCorners = true;
                customDLLButton.AutoRoundedCorners = true;
                injectDelay.AutoRoundedCorners = true;
                customLoc.AutoRoundedCorners = true;
                roundedToggle.AutoRoundedCorners = true;
                toastsToggle.AutoRoundedCorners = true;
                toastsSelector.AutoRoundedCorners = true;
                performanceModeToggle.AutoRoundedCorners = true;
            }
            else
            {
                hideWindow.AutoRoundedCorners = false;
                minWindow.AutoRoundedCorners = false;
                closeWindow.AutoRoundedCorners = false;
                openWindow.AutoRoundedCorners = false;
                buttonForRpc.AutoRoundedCorners = false;
                customImage.AutoRoundedCorners = false;
                autoInject.AutoRoundedCorners = false;
                RpcToggle.AutoRoundedCorners = false;
                theme.AutoRoundedCorners = false;
                AppearanceButton.AutoRoundedCorners = false;
                LauncherButton.AutoRoundedCorners = false;
                ExtrasButton.AutoRoundedCorners = false;
                AppearanceButton2.AutoRoundedCorners = false;
                resetThemes.AutoRoundedCorners = false;
                customDLLButton.AutoRoundedCorners = false;
                injectDelay.AutoRoundedCorners = false;
                customLoc.AutoRoundedCorners = false;
                roundedToggle.AutoRoundedCorners = false;
                toastsToggle.AutoRoundedCorners = false;
                toastsSelector.AutoRoundedCorners = false;
                performanceModeToggle.AutoRoundedCorners = false;
            }

            //Performance Mode
            if (_configCS.PerformanceMode)
            {
                hideWindow.Animated = false;
                minWindow.Animated = false;
                closeWindow.Animated = false;
                openWindow.Animated = false;
                buttonForRpc.Animated = false;
                customImage.Animated = false;
                autoInject.Animated = false;
                RpcToggle.Animated = false;
                theme.Animated = false;
                AppearanceButton.Animated = false;
                LauncherButton.Animated = false;
                ExtrasButton.Animated = false;
                AppearanceButton2.Animated = false;
                resetThemes.Animated = false;
                customDLLButton.Animated = false;
                customLoc.Animated = false;
                roundedToggle.Animated = false;
                toastsToggle.Animated = false;
                toastsSelector.Animated = false;
                performanceModeToggle.Animated = false;

            }
            else
            {
                hideWindow.Animated = true;
                minWindow.Animated = true;
                closeWindow.Animated = true;
                openWindow.Animated = true;
                buttonForRpc.Animated = true;
                customImage.Animated = true;
                autoInject.Animated = true;
                RpcToggle.Animated = true;
                theme.Animated = true;
                AppearanceButton.Animated = true;
                LauncherButton.Animated = true;
                ExtrasButton.Animated = true;
                AppearanceButton2.Animated = true;
                resetThemes.Animated = true;
                customDLLButton.Animated = true;
                customLoc.Animated = true;
                roundedToggle.Animated = true;
                toastsToggle.Animated = true;
                toastsSelector.Animated = true;
                performanceModeToggle.Animated = true;
            }

            //Presets
            preset1.BorderColor = outlineColor;
            preset2.BorderColor = outlineColor;
            preset3.BorderColor = outlineColor;
            preset4.BorderColor = outlineColor;
            preset5.BorderColor = outlineColor;
            preset6.BorderColor = outlineColor;
            preset7.BorderColor = outlineColor;
            preset8.BorderColor = outlineColor;

            preset1.BackColor = ColorTranslator.FromHtml(_presetCS.p1);
            preset2.BackColor = ColorTranslator.FromHtml(_presetCS.p2);
            preset3.BackColor = ColorTranslator.FromHtml(_presetCS.p3);
            preset4.BackColor = ColorTranslator.FromHtml(_presetCS.p4);
            preset5.BackColor = ColorTranslator.FromHtml(_presetCS.p5);
            preset6.BackColor = ColorTranslator.FromHtml(_presetCS.p6);
            preset7.BackColor = ColorTranslator.FromHtml(_presetCS.p7);
            preset8.BackColor = ColorTranslator.FromHtml(_presetCS.p8);

            presets.ForeColor = foreColor;
            presets.BackColor = backColor2;
            presets.RenderStyle.SelectionBackColor = accentColor;
            presets.RenderStyle.SelectionForeColor = foreColor;
            presets.RenderStyle.BorderColor = outlineColor;

            //Extras
            AppearanceButton2.FillColor = backColor2;
            AppearanceButton2.ForeColor = foreColor;

            backImageTitle.BackColor = backColor;
            backImageTitle.ForeColor = foreColor;

            toastsTitle.BackColor = backColor;
            toastsTitle.ForeColor = foreColor;

            performanceModeTitle.BackColor = backColor;
            performanceModeTitle.ForeColor = foreColor;

            roundedTitle.BackColor = backColor;
            roundedTitle.ForeColor = foreColor;

            customImage.CheckedState.FillColor = accentColor;
            customImage.ForeColor = foreColor;
            customImage.FillColor = backColor2;

            toastsToggle.CheckedState.FillColor = accentColor;
            toastsToggle.ForeColor = foreColor;
            toastsToggle.FillColor = backColor2;

            //Dropdown
            toastsSelector.BorderColor = outlineColor;
            toastsSelector.FillColor = backColor2;
            toastsSelector.ForeColor = foreColor;
            toastsSelector.FocusedState.BorderColor = outlineColor;
            toastsSelector.ItemsAppearance.SelectedBackColor = Color.FromArgb(120, accentColor);

            roundedToggle.CheckedState.FillColor = accentColor;
            roundedToggle.ForeColor = foreColor;
            roundedToggle.FillColor = backColor2;

            performanceModeToggle.CheckedState.FillColor = accentColor;
            performanceModeToggle.ForeColor = foreColor;
            performanceModeToggle.FillColor = backColor2;
        }

        private void InitSettings()
        {
            hideWindow.Checked = false;
            minWindow.Checked = false;
            closeWindow.Checked = false;
            openWindow.Checked = false;
            //Window State
            if (_configCS.WindowState == "hide")
            {
                hideWindow.Checked = true;
            }
            else if (_configCS.WindowState == "minimize")
            {
                minWindow.Checked = true;
            }
            else if (_configCS.WindowState == "close")
            {
                closeWindow.Checked = true;
            }
            else
            {
                openWindow.Checked = true;
            }

            //RPC
            if (_configCS.RichPresence)
            {
                RpcToggle.Checked = true;
                RpcToggle.Text = "On";
                rpcLine.Text = _configCS.RpcText;
                rpcLine.Visible = true;
            }
            else
            {
                RpcToggle.Checked = false;
                RpcToggle.Text = "Off";
                rpcLine.Visible = false;
            }

            if (_configCS.RpcButton)
            {
                buttonForRpc.Checked = true;
                buttonForRpc.Visible = true;
                rpcButtonText.Visible = true;
                rpcButtonLink.Visible = true;
                rpcButtonTextLabel.Visible = true;
                rpcButtonLinkLabel.Visible = true;

                rpcButtonLink.Text = _configCS.RpcButtonLink;
                rpcButtonText.Text = _configCS.RpcButtonText;
            }
            else
            {
                buttonForRpc.Visible = false;
                rpcButtonText.Visible = false;
                rpcButtonLink.Visible = false;
                rpcButtonTextLabel.Visible = false;
                rpcButtonLinkLabel.Visible = false;
            }

            //Dev DLL
            if (_configCS.CustomDLL)
            {
                customDLLButton.Checked = true;
            }
            else
            {
                customDLLButton.Checked = false;
            }

            //Inject Delay
            injectDelay.Value = _configCS.InjectDelay;

            //Auto Inject
            if (_configCS.AutoInject)
            {
                _configCS.AutoInject = true;
                autoInject.Checked = true;
                autoInject.Text = "On";
            }
            else
            {
                _configCS.AutoInject = false;
                autoInject.Checked = false;
                autoInject.Text = "Off";
            }

            //Theme
            if (_themeCS.Theme == "dark")
            {
                theme.Text = "Dark";
            }
            else
            {
                theme.Text = "Light";
            }

            //Background Iamge
            if (_configCS.BackgroundImage)
            {
                customImage.Checked = true;
                customImage.Text = "On";
            }
            else
            {
                customImage.Checked = false;
                customImage.Text = "Off";
            }

            //Toasts
            if (_configCS.Toasts)
            {
                toastsToggle.Checked = true;
                toastsToggle.Text = "On";

                if (_configCS.ToastsLoc == "topRight")
                    toastsSelector.SelectedItem = "Top Right";
                else if (_configCS.ToastsLoc == "bottomRight")
                    toastsSelector.SelectedItem = "Bottom Right";
                else if (_configCS.ToastsLoc == "topLeft")
                    toastsSelector.SelectedItem = "Top Left";
                else if (_configCS.ToastsLoc == "bottomLeft")
                    toastsSelector.SelectedItem = "Bottom Left";

                toastsSelector.Visible = true;
            }
            else
            {
                toastsToggle.Checked = false;
                toastsToggle.Text = "Off";
                toastsSelector.Visible = false;
            }

            //Rounded Buttons
            if (_configCS.RoundedButtons)
            {
                roundedToggle.Checked = true;
                roundedToggle.Text = "On";
            }
            else
            {
                roundedToggle.Checked = false;
                roundedToggle.Text = "Off";
            }

            //Performance Mode
            if (_configCS.PerformanceMode)
            {
                performanceModeToggle.Checked = true;
                performanceModeToggle.Text = "On";
            }
            else
            {
                performanceModeToggle.Checked = false;
                performanceModeToggle.Text = "Off";
            }

            //Appearance Sliders
            int value = ColorTranslator.FromHtml(_themeCS.Background).R;

            backgroundBrightnessSlider.Value = value;
            backgroundBT.Text = value.ToString();

            value = ColorTranslator.FromHtml(_themeCS.Accent).R;
            accentRedSlider.Value = value;
            accentRT.Text = value.ToString();

            value = ColorTranslator.FromHtml(_themeCS.Accent).G;
            accentGreenSlider.Value = value;
            accentGT.Text = value.ToString();

            value = ColorTranslator.FromHtml(_themeCS.Accent).B;
            accentBlueSlider.Value = value;
            accentBT.Text = value.ToString();

            value = ColorTranslator.FromHtml(_themeCS.Outline).R;
            outlineBrightnessSlider.Value = value;
            outlineOT.Text = value.ToString();

            value = ColorTranslator.FromHtml(_themeCS.SecondBackground).R;
            buttonBrightnessSlider.Value = value;
            buttonBuT.Text = value.ToString();

            value = ColorTranslator.FromHtml(_themeCS.Foreground).R;
            textBrightnessSlider.Value = value;
            foreBT.Text = value.ToString();
        }

        //Launcher
        private void AppearanceButton_Click(object sender, EventArgs e)
        {
            var p = new Guna2Panel();

            if (!_configCS.PerformanceMode)
            {
                p.BackColor = ColorTranslator.FromHtml(_themeCS.Background);
                p.Size = new Size(settingsTab.Width, settingsPagesTabControl.Height);
                p.Location = new Point(165, 110);
                this.Controls.Add(p);
                p.BringToFront();
                sidebar.BringToFront();
                /*p.Visible = false;
                FadeEffectBetweenPages.ShowSync(p);*/
            }

            settingsPagesTabControl.SelectedTab = Appearance;

            if (!_configCS.PerformanceMode)
            {
                p.Visible = true;
                FadeEffectBetweenPages.HideSync(p);
                this.Controls.Remove(p);
            }
        }

        private void hideWindow_Click(object sender, EventArgs e)
        {
            _configCS.WindowState = "hide";
            hideWindow.Checked = true;
            minWindow.Checked = false;
            closeWindow.Checked = false;
            openWindow.Checked = false;
        }

        private void minWindow_Click(object sender, EventArgs e)
        {
            _configCS.WindowState = "minimize";
            hideWindow.Checked = false;
            minWindow.Checked = true;
            closeWindow.Checked = false;
            openWindow.Checked = false;
        }

        private void closeWindow_Click(object sender, EventArgs e)
        {
            _configCS.WindowState = "close";
            hideWindow.Checked = false;
            minWindow.Checked = false;
            closeWindow.Checked = true;
            openWindow.Checked = false;
        }

        private void openWindow_Click(object sender, EventArgs e)
        {
            _configCS.WindowState = "open";
            hideWindow.Checked = false;
            minWindow.Checked = false;
            closeWindow.Checked = false;
            openWindow.Checked = true;
        }

        private void autoInject_Click(object sender, EventArgs e)
        {
            if (_configCS.AutoInject)
            {
                _configCS.AutoInject = false;
                autoInject.Checked = false;
                autoInject.Text = "Off";
            }
            else
            {
                _configCS.AutoInject = true;
                autoInject.Checked = true;
                autoInject.Text = "On";
            }
        }

        private bool _rpcCooldown;

        private void RpcToggle_Click(object sender, EventArgs e)
        {
            if (_rpcCooldown)
                return;
            if (_configCS.RichPresence)
            {
                RpcToggle.Checked = false;
                RpcToggle.Text = "Off";
                rpcLine.Visible = false;
                buttonForRpc.Visible = false;
                rpcButtonLink.Visible = false;
                rpcButtonText.Visible = false;
                rpcButtonLinkLabel.Visible = false;
                rpcButtonTextLabel.Visible = false;

                _configCS.RichPresence = false;

                Cooldown(15);
                _drpc.Deinitialize();

            }
            else if (!_configCS.RichPresence)
            {

                _configCS.RichPresence = true;
                RpcToggle.FillColor = ColorTranslator.FromHtml(_themeCS.Accent);
                RpcToggle.Text = "On";
                rpcLine.Visible = true;
                buttonForRpc.Visible = true;

                if (_configCS.RpcButton)
                {
                    rpcButtonLink.Visible = true;
                    rpcButtonText.Visible = true;
                    rpcButtonLinkLabel.Visible = true;
                    rpcButtonTextLabel.Visible = true;
                    rpcButtonLink.Text = _configCS.RpcButtonLink;
                    rpcButtonText.Text = _configCS.RpcButtonText;
                }

                Cooldown(15);
                _drpc.Initialize();
                rpcLine.Text = _configCS.RpcText;
            }
        }

        private void customImage_Click(object sender, EventArgs e)
        {
            if (_configCS.BackgroundImage)
            {
                _configCS.BackgroundImage = false;
                customImage.Checked = false;

                ChangeBackground();
            }
            else
            {
                var customImg = new OpenFileDialog()
                {
                    Title = "Custom Background Image",
                    Filter = "Image Files (*.bmp;*.jpg;*.jpeg)|*.BMP;*.JPG;*.JPEG"
                };


                if (customImg.ShowDialog() == DialogResult.OK)
                {
                    _configCS.BackgroundImage = true;
                    _configCS.BackgroundImageLoc = customImg.FileName;
                    customImage.Checked = true;
                    ChangeBackground();
                }
                else
                {
                    this.Toast("Error", "There was an error selecting image.");
                }
            }
        }

        private void roundedToggle_Click(object sender, EventArgs e)
        {
            if (_configCS.RoundedButtons)
            {
                _configCS.RoundedButtons = false;
                roundedToggle.Checked = false;
                roundedToggle.Text = "Off";
            }
            else
            {
                _configCS.RoundedButtons = true;
                roundedToggle.Checked = true;
                roundedToggle.Text = "On";
            }
            ChangeSettingColors();
        }

        private void rpcLine_TextChanged(object sender, EventArgs e)
        {
            _configCS.RpcText = rpcLine.Text;
        }

        private void rpcButtonLink_TextChanged(object sender, EventArgs e)
        {
            _configCS.RpcButtonLink = rpcButtonLink.Text;
        }

        private void rpcButtonText_TextChanged(object sender, EventArgs e)
        {
            _configCS.RpcButtonText = rpcButtonText.Text;
        }

        private async void Cooldown(int sec)
        {
            _rpcCooldown = true;
            this.Toast("Rich Presence", "Your on cooldown for " + sec + "s");
            await Task.Delay(sec * 1000);
            _rpcCooldown = false;
            this.Toast("Rich Presence", "Cooldown finished");
        }

        private void buttonForRpc_Click(object sender, EventArgs e)
        {
            if (!_configCS.RpcButton)
            {
                rpcButtonLinkLabel.Visible = true;
                rpcButtonTextLabel.Visible = true;
                rpcButtonLink.Visible = true;
                rpcButtonText.Visible = true;
                buttonForRpc.Checked = true;

                _configCS.RpcButton = true;
                rpcButtonText.Text = _configCS.RpcButtonText;
                rpcButtonLink.Text = _configCS.RpcButtonLink;
            }
            else
            {
                rpcButtonLinkLabel.Visible = false;
                rpcButtonTextLabel.Visible = false;
                rpcButtonLink.Visible = false;
                rpcButtonText.Visible = false;
                buttonForRpc.Checked = false;

                _configCS.RpcButton = false;
            }
        }

        private void customDLLButton_Click(object sender, EventArgs e)
        {
            if (_configCS.CustomDLL)
            {
                _configCS.CustomDLL = false;

                customDLLButton.Checked = false;
            }
            else
            {
                _configCS.CustomDLL = true;

                customDLLButton.Checked = true;
            }
        }

        private void injectDelay_ValueChanged(object sender, EventArgs e)
        {
            injectDelay.DecimalPlaces = 0;
            _configCS.InjectDelay = (int)injectDelay.Value;
        }

        private void blankButton_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Blank Button!");
        }

        //Appearance
        private void LauncherButton_Click(object sender, EventArgs e)
        {
            var p = new Guna2Panel();
            if (!_configCS.PerformanceMode)
            {
                p.BackColor = ColorTranslator.FromHtml(_themeCS.Background);
                p.Size = new Size(settingsTab.Width, settingsPagesTabControl.Height);
                p.Location = new Point(165, 110);
                this.Controls.Add(p);
                p.BringToFront();
                sidebar.BringToFront();
                /*p.Visible = false;
                FadeEffectBetweenPages.ShowSync(p);*/
            }

            settingsPagesTabControl.SelectedTab = Launcher;

            if (!_configCS.PerformanceMode)
            {
                p.Visible = true;
                FadeEffectBetweenPages.HideSync(p);
                this.Controls.Remove(p);
            }
        }

        private void ExtrasButton_Click(object sender, EventArgs e)
        {
            var p = new Guna2Panel();

            if (!_configCS.PerformanceMode)
            {
                p.BackColor = ColorTranslator.FromHtml(_themeCS.Background);
                p.Size = new Size(settingsTab.Width, settingsPagesTabControl.Height);
                p.Location = new Point(165, 110);
                this.Controls.Add(p);
                p.BringToFront();
                sidebar.BringToFront();
                /*p.Visible = false;
                FadeEffectBetweenPages.ShowSync(p);*/
            }

            settingsPagesTabControl.SelectedTab = Extras;

            if (!_configCS.PerformanceMode)
            {
                p.Visible = true;
                FadeEffectBetweenPages.HideSync(p);
                this.Controls.Remove(p);
            }
        }

        private void theme_Click(object sender, EventArgs e)
        {
            bool[] presets = { false, false, false, false, false, false, false, false };
            if (preset1.BackColor == ColorTranslator.FromHtml(_themeCS.SecondBackground))
                presets[0] = true;
            if (preset2.BackColor == ColorTranslator.FromHtml(_themeCS.SecondBackground))
                presets[1] = true;
            if (preset3.BackColor == ColorTranslator.FromHtml(_themeCS.SecondBackground))
                presets[2] = true;
            if (preset4.BackColor == ColorTranslator.FromHtml(_themeCS.SecondBackground))
                presets[3] = true;
            if (preset5.BackColor == ColorTranslator.FromHtml(_themeCS.SecondBackground))
                presets[4] = true;
            if (preset6.BackColor == ColorTranslator.FromHtml(_themeCS.SecondBackground))
                presets[5] = true;
            if (preset7.BackColor == ColorTranslator.FromHtml(_themeCS.SecondBackground))
                presets[6] = true;
            if (preset8.BackColor == ColorTranslator.FromHtml(_themeCS.SecondBackground))
                presets[7] = true;

            if (_themeCS.Theme == "dark")
            {
                _themeCS.Theme = "light";

                _themeCS.Background = ColorTranslator.ToHtml(Color.FromArgb(240, 240, 240));
                _themeCS.SecondBackground = ColorTranslator.ToHtml(Color.FromArgb(205, 205, 205));
                //Properties.Colors.Default.accentColor1 = 15;
                //Properties.Colors.Default.accentColor2 = 105;
                //Properties.Colors.Default.accentColor3 = 255;
                _themeCS.Foreground = ColorTranslator.ToHtml(Color.FromArgb(0, 0, 0));
                _themeCS.Outline = ColorTranslator.ToHtml(Color.FromArgb(170, 170, 170));
                _themeCS.Faded = ColorTranslator.ToHtml(Color.FromArgb(163, 163, 163));

                //About things
                discord.Image = Properties.Resources.transparent_logo_black;
                website.Image = Properties.Resources.website_black;
            }
            else if (_themeCS.Theme == "light")
            {
                _themeCS.Theme = "dark";

                _themeCS.Background = ColorTranslator.ToHtml(Color.FromArgb(20, 20, 20));
                _themeCS.SecondBackground = ColorTranslator.ToHtml(Color.FromArgb(40, 40, 40));
                //Properties.Colors.Default.accentColor1 = 15;
                //Properties.Colors.Default.accentColor2 = 105;
                //Properties.Colors.Default.accentColor3 = 255;
                _themeCS.Foreground = ColorTranslator.ToHtml(Color.FromArgb(255, 255, 255));
                _themeCS.Outline = ColorTranslator.ToHtml(Color.FromArgb(5, 5, 5));
                _themeCS.Faded = ColorTranslator.ToHtml(Color.FromArgb(192, 192, 192));

                //About things
                discord.Image = Properties.Resources.transparent_logo_white;
                website.Image = Properties.Resources.website_white;
            }
            if (presets[0])
                _presetCS.p1 = _themeCS.SecondBackground;
            if (presets[1])
                _presetCS.p2 = _themeCS.SecondBackground;
            if (presets[2])
                _presetCS.p3 = _themeCS.SecondBackground;
            if (presets[3])
                _presetCS.p4 = _themeCS.SecondBackground;
            if (presets[4])
                _presetCS.p5 = _themeCS.SecondBackground;
            if (presets[5])
                _presetCS.p6 = _themeCS.SecondBackground;
            if (presets[6])
                _presetCS.p7 = _themeCS.SecondBackground;
            if (presets[7])
                _presetCS.p8 = _themeCS.SecondBackground;

            InitSettings();
            ChangeBackground();
            ChangeSettingColors();
            ChangeAboutColors();
            ChangeCosmeticColors();
            ChangeGlobalColors();
        }

        private void resetThemes_Click(object sender, EventArgs e)
        {
            bool[] presets = { false, false, false, false, false, false, false, false };
            if (preset1.BackColor == ColorTranslator.FromHtml(_themeCS.SecondBackground))
                presets[0] = true;
            if (preset2.BackColor == ColorTranslator.FromHtml(_themeCS.SecondBackground))
                presets[1] = true;
            if (preset3.BackColor == ColorTranslator.FromHtml(_themeCS.SecondBackground))
                presets[2] = true;
            if (preset4.BackColor == ColorTranslator.FromHtml(_themeCS.SecondBackground))
                presets[3] = true;
            if (preset5.BackColor == ColorTranslator.FromHtml(_themeCS.SecondBackground))
                presets[4] = true;
            if (preset6.BackColor == ColorTranslator.FromHtml(_themeCS.SecondBackground))
                presets[5] = true;
            if (preset7.BackColor == ColorTranslator.FromHtml(_themeCS.SecondBackground))
                presets[6] = true;
            if (preset8.BackColor == ColorTranslator.FromHtml(_themeCS.SecondBackground))
                presets[7] = true;

            if (_themeCS.Theme == "light")
            {

                _themeCS.Background = ColorTranslator.ToHtml(Color.FromArgb(240, 240, 240));
                _themeCS.SecondBackground = ColorTranslator.ToHtml(Color.FromArgb(205, 205, 205));
                _themeCS.Accent = ColorTranslator.ToHtml(Color.FromArgb(65, 105, 255));
                _themeCS.Foreground = ColorTranslator.ToHtml(Color.FromArgb(0, 0, 0));
                _themeCS.Outline = ColorTranslator.ToHtml(Color.FromArgb(170, 170, 170));
                _themeCS.Faded = ColorTranslator.ToHtml(Color.FromArgb(163, 163, 163));

                //Accent Color Changer
                backgroundBrightnessSlider.Value = ColorTranslator.FromHtml(_themeCS.Background).R;
                buttonBrightnessSlider.Value = ColorTranslator.FromHtml(_themeCS.SecondBackground).R;
                outlineBrightnessSlider.Value = ColorTranslator.FromHtml(_themeCS.Outline).R;
                textBrightnessSlider.Value = ColorTranslator.FromHtml(_themeCS.Foreground).R;
                accentRedSlider.Value = ColorTranslator.FromHtml(_themeCS.Accent).R;
                accentGreenSlider.Value = ColorTranslator.FromHtml(_themeCS.Accent).G;
                accentBlueSlider.Value = ColorTranslator.FromHtml(_themeCS.Accent).B;
            }
            else if (_themeCS.Theme == "dark")
            {

                _themeCS.Background = ColorTranslator.ToHtml(Color.FromArgb(20, 20, 20));
                _themeCS.SecondBackground = ColorTranslator.ToHtml(Color.FromArgb(40, 40, 40));
                _themeCS.Accent = ColorTranslator.ToHtml(Color.FromArgb(65, 105, 255));
                _themeCS.Foreground = ColorTranslator.ToHtml(Color.FromArgb(255, 255, 255));
                _themeCS.Outline = ColorTranslator.ToHtml(Color.FromArgb(5, 5, 5));
                _themeCS.Faded = ColorTranslator.ToHtml(Color.FromArgb(192, 192, 192));

                //Accent Color Changer
                backgroundBrightnessSlider.Value = ColorTranslator.FromHtml(_themeCS.Background).R;
                buttonBrightnessSlider.Value = ColorTranslator.FromHtml(_themeCS.SecondBackground).R;
                outlineBrightnessSlider.Value = ColorTranslator.FromHtml(_themeCS.Outline).R;
                textBrightnessSlider.Value = ColorTranslator.FromHtml(_themeCS.Foreground).R;
                accentRedSlider.Value = ColorTranslator.FromHtml(_themeCS.Accent).R;
                accentGreenSlider.Value = ColorTranslator.FromHtml(_themeCS.Accent).G;
                accentBlueSlider.Value = ColorTranslator.FromHtml(_themeCS.Accent).B;
            }

            if (presets[0])
                _presetCS.p1 = _themeCS.SecondBackground;
            if (presets[1])
                _presetCS.p2 = _themeCS.SecondBackground;
            if (presets[2])
                _presetCS.p3 = _themeCS.SecondBackground;
            if (presets[3])
                _presetCS.p4 = _themeCS.SecondBackground;
            if (presets[4])
                _presetCS.p5 = _themeCS.SecondBackground;
            if (presets[5])
                _presetCS.p6 = _themeCS.SecondBackground;
            if (presets[6])
                _presetCS.p7 = _themeCS.SecondBackground;
            if (presets[7])
                _presetCS.p8 = _themeCS.SecondBackground;

            backgroundBT.Text = backgroundBrightnessSlider.Value.ToString();
            accentRT.Text = accentRedSlider.Value.ToString();
            accentGT.Text = accentRedSlider.Value.ToString();
            accentBT.Text = accentRedSlider.Value.ToString();
            outlineOT.Text = outlineBrightnessSlider.Value.ToString();
            buttonBuT.Text = buttonBrightnessSlider.Value.ToString();
            foreBT.Text = textBrightnessSlider.Value.ToString();

            ChangeBackground();
            ChangeSettingColors();
            ChangeAboutColors();
            ChangeCosmeticColors();
            ChangeGlobalColors();

            //Appearance Sliders
            int value = ColorTranslator.FromHtml(_themeCS.Background).R;

            backgroundBrightnessSlider.Value = value;
            backgroundBT.Text = value.ToString();

            value = ColorTranslator.FromHtml(_themeCS.Accent).R;
            accentRedSlider.Value = value;
            accentRT.Text = value.ToString();

            value = ColorTranslator.FromHtml(_themeCS.Accent).G;
            accentGreenSlider.Value = value;
            accentGT.Text = value.ToString();

            value = ColorTranslator.FromHtml(_themeCS.Accent).B;
            accentBlueSlider.Value = value;
            accentBT.Text = value.ToString();

            value = ColorTranslator.FromHtml(_themeCS.Outline).R;
            outlineBrightnessSlider.Value = value;
            outlineOT.Text = value.ToString();

            value = ColorTranslator.FromHtml(_themeCS.SecondBackground).R;
            buttonBrightnessSlider.Value = value;
            buttonBuT.Text = value.ToString();

            value = ColorTranslator.FromHtml(_themeCS.Foreground).R;
            textBrightnessSlider.Value = value;
            foreBT.Text = value.ToString();
        }

        private void backgroundBrightnessSlider_Scroll(object sender, ScrollEventArgs e)
        {
            _themeCS.Background = ColorTranslator.ToHtml(Color.FromArgb(backgroundBrightnessSlider.Value, backgroundBrightnessSlider.Value, backgroundBrightnessSlider.Value));
            backgroundBT.Text = backgroundBrightnessSlider.Value.ToString();
            ChangeSettingColors();
            ChangeGlobalColors();
        }

        private void accentRedSlider_Scroll(object sender, ScrollEventArgs e)
        {
            _themeCS.Accent = ColorTranslator.ToHtml(Color.FromArgb(accentRedSlider.Value, accentGreenSlider.Value, accentBlueSlider.Value));
            accentRT.Text = accentRedSlider.Value.ToString();
            ChangeSettingColors();
            ChangeGlobalColors();
        }

        private void accentGreenSlider_Scroll(object sender, ScrollEventArgs e)
        {
            _themeCS.Accent = ColorTranslator.ToHtml(Color.FromArgb(accentRedSlider.Value, accentGreenSlider.Value, accentBlueSlider.Value));
            accentGT.Text = accentGreenSlider.Value.ToString();
            ChangeSettingColors();
            ChangeGlobalColors();
        }

        private void accentBlueSlider_Scroll(object sender, ScrollEventArgs e)
        {

            _themeCS.Accent = ColorTranslator.ToHtml(Color.FromArgb(accentRedSlider.Value, accentGreenSlider.Value, accentBlueSlider.Value));
            accentBT.Text = accentBlueSlider.Value.ToString();
            ChangeSettingColors();
            ChangeGlobalColors();
        }

        private void outlineBrightnessSlider_Scroll(object sender, ScrollEventArgs e)
        {

            _themeCS.Outline = ColorTranslator.ToHtml(Color.FromArgb(outlineBrightnessSlider.Value, outlineBrightnessSlider.Value, outlineBrightnessSlider.Value));
            outlineOT.Text = outlineBrightnessSlider.Value.ToString();
            ChangeSettingColors();
            ChangeGlobalColors();

        }

        private void buttonBrightnessSlider_Scroll(object sender, ScrollEventArgs e)
        {
            bool[] presets = { false, false, false, false, false, false, false, false };
            if (preset1.BackColor == ColorTranslator.FromHtml(_themeCS.SecondBackground))
                presets[0] = true;
            if (preset2.BackColor == ColorTranslator.FromHtml(_themeCS.SecondBackground))
                presets[1] = true;
            if (preset3.BackColor == ColorTranslator.FromHtml(_themeCS.SecondBackground))
                presets[2] = true;
            if (preset4.BackColor == ColorTranslator.FromHtml(_themeCS.SecondBackground))
                presets[3] = true;
            if (preset5.BackColor == ColorTranslator.FromHtml(_themeCS.SecondBackground))
                presets[4] = true;
            if (preset6.BackColor == ColorTranslator.FromHtml(_themeCS.SecondBackground))
                presets[5] = true;
            if (preset7.BackColor == ColorTranslator.FromHtml(_themeCS.SecondBackground))
                presets[6] = true;
            if (preset8.BackColor == ColorTranslator.FromHtml(_themeCS.SecondBackground))
                presets[7] = true;

            _themeCS.SecondBackground = ColorTranslator.ToHtml(Color.FromArgb(buttonBrightnessSlider.Value, buttonBrightnessSlider.Value, buttonBrightnessSlider.Value));
            if (presets[0])
                _presetCS.p1 = _themeCS.SecondBackground;
            if (presets[1])
                _presetCS.p2 = _themeCS.SecondBackground;
            if (presets[2])
                _presetCS.p3 = _themeCS.SecondBackground;
            if (presets[3])
                _presetCS.p4 = _themeCS.SecondBackground;
            if (presets[4])
                _presetCS.p5 = _themeCS.SecondBackground;
            if (presets[5])
                _presetCS.p6 = _themeCS.SecondBackground;
            if (presets[6])
                _presetCS.p7 = _themeCS.SecondBackground;
            if (presets[7])
                _presetCS.p8 = _themeCS.SecondBackground;

            buttonBuT.Text = buttonBrightnessSlider.Value.ToString();


            ChangeSettingColors();
            ChangeGlobalColors();
        }

        private void textBrightnessSlider_Scroll(object sender, ScrollEventArgs e)
        {
            _themeCS.Foreground = ColorTranslator.ToHtml(Color.FromArgb(textBrightnessSlider.Value, textBrightnessSlider.Value, textBrightnessSlider.Value));
            foreBT.Text = textBrightnessSlider.Value.ToString();

            ChangeSettingColors();
            ChangeGlobalColors();
        }


        private Panel _panel;
        private string _hoveredPreset;
        private void presetHover(object sender, EventArgs e)
        {
            _panel = (Panel)sender;
            _hoveredPreset = _panel.Name;
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_hoveredPreset == null)
            {
                this.Toast("Presets", "There was an error saving!");
            }
            else
            {
                ReadPresetColors(@"C:\temp\VentileClient\Presets\PresetColors.json");

                if (Convert.ToInt32(_panel.Name.Substring(6)) == 1)
                    _presetCS.p1 = _themeCS.Accent;

                if (Convert.ToInt32(_panel.Name.Substring(6)) == 2)
                    _presetCS.p2 = _themeCS.Accent;

                if (Convert.ToInt32(_panel.Name.Substring(6)) == 3)
                    _presetCS.p3 = _themeCS.Accent;

                if (Convert.ToInt32(_panel.Name.Substring(6)) == 4)
                    _presetCS.p4 = _themeCS.Accent;

                if (Convert.ToInt32(_panel.Name.Substring(6)) == 5)
                    _presetCS.p5 = _themeCS.Accent;

                if (Convert.ToInt32(_panel.Name.Substring(6)) == 6)
                    _presetCS.p6 = _themeCS.Accent;

                if (Convert.ToInt32(_panel.Name.Substring(6)) == 7)
                    _presetCS.p7 = _themeCS.Accent;

                if (Convert.ToInt32(_panel.Name.Substring(6)) == 8)
                    _presetCS.p8 = _themeCS.Accent;

                _panel.BackColor = ColorTranslator.FromHtml(_themeCS.Accent);
                WritePresetColors(@"C:\temp\VentileClient\Presets\PresetColors.json");

                WriteConfig(@"C:\temp\VentileClient\Presets\" + _hoveredPreset + ".json");
                WriteTheme(@"C:\temp\VentileClient\Presets\" + _hoveredPreset + "Theme.json");
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_hoveredPreset == null)
            {
                this.Toast("Presets", "There was an error loading!");
            }
            else
            {
                if (File.Exists(@"C:\temp\VentileClient\Presets\" + _hoveredPreset + ".json") && File.Exists(@"C:\temp\VentileClient\Presets\" + _hoveredPreset + "Theme.json"))
                {
                    ReadConfig(@"C:\temp\VentileClient\Presets\" + _hoveredPreset + ".json");
                    ReadTheme(@"C:\temp\VentileClient\Presets\" + _hoveredPreset + "Theme.json");
                    WriteConfig(@"C:\temp\VentileClient\Presets\Config.json");
                    WriteTheme(@"C:\temp\VentileClient\Presets\Theme.json");
                    InitSettings();
                    ChangeSettingColors();
                    ChangeGlobalColors();
                    ChangeHomeColors();
                    ChangeCosmeticColors();
                    ChangeAboutColors();
                }
                else
                {
                    this.Toast("Presets", "Preset not found!");
                    ReadPresetColors(@"C:\temp\VentileClient\Presets\PresetColors.json");

                    _panel.BackColor = ColorTranslator.FromHtml(_themeCS.SecondBackground);


                    if (Convert.ToInt32(_panel.Name.Substring(6)) == 1)
                        _presetCS.p1 = _themeCS.SecondBackground;

                    if (Convert.ToInt32(_panel.Name.Substring(6)) == 2)
                        _presetCS.p2 = _themeCS.SecondBackground;

                    if (Convert.ToInt32(_panel.Name.Substring(6)) == 3)
                        _presetCS.p3 = _themeCS.SecondBackground;

                    if (Convert.ToInt32(_panel.Name.Substring(6)) == 4)
                        _presetCS.p4 = _themeCS.SecondBackground;

                    if (Convert.ToInt32(_panel.Name.Substring(6)) == 5)
                        _presetCS.p5 = _themeCS.SecondBackground;

                    if (Convert.ToInt32(_panel.Name.Substring(6)) == 6)
                        _presetCS.p6 = _themeCS.SecondBackground;

                    if (Convert.ToInt32(_panel.Name.Substring(6)) == 7)
                        _presetCS.p7 = _themeCS.SecondBackground;

                    if (Convert.ToInt32(_panel.Name.Substring(6)) == 8)
                        _presetCS.p8 = _themeCS.SecondBackground;

                    WritePresetColors(@"C:\temp\VentileClient\Presets\PresetColors.json");
                }
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(@"C:\temp\VentileClient\Presets\" + _hoveredPreset + ".json") || File.Exists(@"C:\temp\VentileClient\Presets\" + _hoveredPreset + "Theme.json"))
            {
                try
                {
                    File.Delete(@"C:\temp\VentileClient\Presets\" + _hoveredPreset + ".json");
                    File.Delete(@"C:\temp\VentileClient\Presets\" + _hoveredPreset + "Theme.json");
                }
                catch { }
                ReadPresetColors(@"C:\temp\VentileClient\Presets\PresetColors.json");

                _panel.BackColor = ColorTranslator.FromHtml(_themeCS.SecondBackground);


                if (Convert.ToInt32(_panel.Name.Substring(6)) == 1)
                    _presetCS.p1 = _themeCS.SecondBackground;

                if (Convert.ToInt32(_panel.Name.Substring(6)) == 2)
                    _presetCS.p2 = _themeCS.SecondBackground;

                if (Convert.ToInt32(_panel.Name.Substring(6)) == 3)
                    _presetCS.p3 = _themeCS.SecondBackground;

                if (Convert.ToInt32(_panel.Name.Substring(6)) == 4)
                    _presetCS.p4 = _themeCS.SecondBackground;

                if (Convert.ToInt32(_panel.Name.Substring(6)) == 5)
                    _presetCS.p5 = _themeCS.SecondBackground;

                if (Convert.ToInt32(_panel.Name.Substring(6)) == 6)
                    _presetCS.p6 = _themeCS.SecondBackground;

                if (Convert.ToInt32(_panel.Name.Substring(6)) == 7)
                    _presetCS.p7 = _themeCS.SecondBackground;

                if (Convert.ToInt32(_panel.Name.Substring(6)) == 8)
                    _presetCS.p8 = _themeCS.SecondBackground;

                WritePresetColors(@"C:\temp\VentileClient\Presets\PresetColors.json");
            }
            else
            {
                this.Toast("Presets", "This preset doesn't exist!");
                ReadPresetColors(@"C:\temp\VentileClient\Presets\PresetColors.json");

                _panel.BackColor = ColorTranslator.FromHtml(_themeCS.SecondBackground);


                if (Convert.ToInt32(_panel.Name.Substring(6)) == 1)
                    _presetCS.p1 = _themeCS.SecondBackground;

                if (Convert.ToInt32(_panel.Name.Substring(6)) == 2)
                    _presetCS.p2 = _themeCS.SecondBackground;

                if (Convert.ToInt32(_panel.Name.Substring(6)) == 3)
                    _presetCS.p3 = _themeCS.SecondBackground;

                if (Convert.ToInt32(_panel.Name.Substring(6)) == 4)
                    _presetCS.p4 = _themeCS.SecondBackground;

                if (Convert.ToInt32(_panel.Name.Substring(6)) == 5)
                    _presetCS.p5 = _themeCS.SecondBackground;

                if (Convert.ToInt32(_panel.Name.Substring(6)) == 6)
                    _presetCS.p6 = _themeCS.SecondBackground;

                if (Convert.ToInt32(_panel.Name.Substring(6)) == 7)
                    _presetCS.p7 = _themeCS.SecondBackground;

                if (Convert.ToInt32(_panel.Name.Substring(6)) == 8)
                    _presetCS.p8 = _themeCS.SecondBackground;

                WritePresetColors(@"C:\temp\VentileClient\Presets\PresetColors.json");
            }
        }
        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var importConfig = new OpenFileDialog()
            {
                Filter = "JSON Files (*.json)|*.json|All files (*.*)|*.*",
                RestoreDirectory = true,
                Title = "Config File"
            };


            var importTheme = new OpenFileDialog()
            {
                Filter = "JSON Files (*.json)|*.json|All files (*.*)|*.*",
                RestoreDirectory = true,
                Title = "Theme File"
            };

            ConfigTemplate conf;
            ThemeTemplate them;

            if (importConfig.ShowDialog() == DialogResult.OK)
            {
                if (importTheme.ShowDialog() == DialogResult.OK)
                {
                    string configPath = importConfig.FileName;
                    string themePath = importTheme.FileName;
                    string temp;
                    try
                    {
                        temp = File.ReadAllText(configPath);
                        conf = JsonConvert.DeserializeObject<ConfigTemplate>(temp);

                        temp = File.ReadAllText(themePath);
                        them = JsonConvert.DeserializeObject<ThemeTemplate>(temp);

                        string json = JsonConvert.SerializeObject(conf, Formatting.Indented);
                        File.WriteAllText(@"C:\temp\VentileClient\Presets\" + _hoveredPreset + ".json", json);

                        json = JsonConvert.SerializeObject(them, Formatting.Indented);
                        File.WriteAllText(@"C:\temp\VentileClient\Presets\" + _hoveredPreset + "Theme.json", json);

                        if (Convert.ToInt32(_panel.Name.Substring(6)) == 1)
                            _presetCS.p1 = them.Accent;

                        if (Convert.ToInt32(_panel.Name.Substring(6)) == 2)
                            _presetCS.p2 = them.Accent;

                        if (Convert.ToInt32(_panel.Name.Substring(6)) == 3)
                            _presetCS.p3 = them.Accent;

                        if (Convert.ToInt32(_panel.Name.Substring(6)) == 4)
                            _presetCS.p4 = them.Accent;

                        if (Convert.ToInt32(_panel.Name.Substring(6)) == 5)
                            _presetCS.p5 = them.Accent;

                        if (Convert.ToInt32(_panel.Name.Substring(6)) == 6)
                            _presetCS.p6 = them.Accent;

                        if (Convert.ToInt32(_panel.Name.Substring(6)) == 7)
                            _presetCS.p7 = them.Accent;

                        if (Convert.ToInt32(_panel.Name.Substring(6)) == 8)
                            _presetCS.p8 = them.Accent;

                        this.Toast("Preset", "Preset Sucessfully Imported!");

                        InitSettings();
                        ChangeSettingColors();
                        ChangeGlobalColors();
                        ChangeAboutColors();
                        ChangeHomeColors();
                        ChangeCosmeticColors();
                    }
                    catch
                    {
                        this.Toast("Error", "There was an error :(");
                        return;
                    }
                }
                else
                {
                    this.Toast("File Dialog", "The file you selected caused an error!");
                    return;
                }
            }
            else
            {
                this.Toast("File Dialog", "The file you selected caused an error!");
                return;
            }
        }

        private async void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Copy to clipboard maybe?
            Directory.CreateDirectory(@"C:\temp\VentileClient\SHARE");
            WriteConfig(@"C:\temp\VentileClient\SHARE\Config.json");
            WriteTheme(@"C:\temp\VentileClient\SHARE\Theme.json");
            using (var sw = new StreamWriter(@"C:\temp\VentileClient\SHARE\Share These Files!"))
            {
                sw.Write("Did you share these files?");
                sw.Close();
            }
            Process.Start(@"C:\temp\VentileClient\SHARE\");
            await Task.Delay(20000);
            Directory.Delete(@"C:\temp\VentileClient\SHARE\", true);


        }

        //Extras
        private void AppearanceButton2_Click(object sender, EventArgs e)
        {
            var p = new Guna2Panel();

            if (!_configCS.PerformanceMode)
            {
                p.BackColor = ColorTranslator.FromHtml(_themeCS.Background);
                p.Size = new Size(settingsTab.Width, settingsPagesTabControl.Height);
                p.Location = new Point(165, 110);
                this.Controls.Add(p);
                p.BringToFront();
                sidebar.BringToFront();
                /*p.Visible = false;
                FadeEffectBetweenPages.ShowSync(p);*/
            }

            settingsPagesTabControl.SelectedTab = Appearance;

            if (!_configCS.PerformanceMode)
            {
                p.Visible = true;
                FadeEffectBetweenPages.HideSync(p);
                this.Controls.Remove(p);
            }
        }

        private void toastsToggle_Click(object sender, EventArgs e)
        {
            if (_configCS.Toasts)
            {
                _configCS.Toasts = false;
                toastsToggle.Checked = false;
                toastsToggle.Text = "Off";
                toastsSelector.Visible = false;
            }
            else
            {
                _configCS.Toasts = true;
                toastsToggle.Checked = true;
                toastsToggle.Text = "On";
                toastsSelector.Visible = true;
            }
        }

        private void toastsSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (toastsSelector.SelectedIndex == 0) //Top Right
            {
                _configCS.ToastsLoc = "topRight";
            }
            else if (toastsSelector.SelectedIndex == 1) //Bottom Right
            {
                _configCS.ToastsLoc = "bottomRight";
            }
            else if (toastsSelector.SelectedIndex == 2) //Top Left
            {
                _configCS.ToastsLoc = "topLeft";
            }
            else if (toastsSelector.SelectedIndex == 3) //Bottom Left
            {
                _configCS.ToastsLoc = "bottomLeft";
            }
        }

        private void performanceModeToggle_Click(object sender, EventArgs e)
        {
            if (_configCS.PerformanceMode)
            {
                _configCS.PerformanceMode = false;
                performanceModeToggle.Checked = false;
                performanceModeToggle.Animated = false;
                performanceModeToggle.Text = "Off";
            }
            else
            {
                _configCS.PerformanceMode = true;
                performanceModeToggle.Checked = true;
                performanceModeToggle.Animated = true;
                performanceModeToggle.Text = "On";
            }

            ChangeSettingColors();
            ChangeGlobalColors();
        }
        #endregion

        #region About
        private void InitAbout()
        {
            launcherVLabel.Text = VENTILE_SETTINGS.launcherVersion;
            clientVLabel.Text = VENTILE_SETTINGS.clientVersion;
            cosmeticsVLabel.Text = VENTILE_SETTINGS.cosmeticsVersion;
        }

        private void ChangeAboutColors()
        {
            // Make the color variable smaller
            Color backColor = ColorTranslator.FromHtml(_themeCS.Background);
            Color foreColor = ColorTranslator.FromHtml(_themeCS.Foreground);
            Color fadedColor = ColorTranslator.FromHtml(_themeCS.Faded);

            cosmeticsLabel.ForeColor = foreColor;
            cosmeticsLabel.BackColor = backColor;
            launcherLabel.ForeColor = foreColor;
            launcherLabel.BackColor = backColor;
            clientLabel.ForeColor = foreColor;
            clientLabel.BackColor = backColor;

            launcherBy.ForeColor = foreColor;
            launcherBy.BackColor = backColor;
            aboutDesc.ForeColor = foreColor;
            aboutDesc.BackColor = backColor;
            aboutBackgroundColor.BackColor = backColor;
            aboutSeparator.BackColor = foreColor;
            website.BackColor = backColor;
            discord.BackColor = backColor;


            cosmeticsVLabel.BackColor = backColor;
            cosmeticsVLabel.ForeColor = fadedColor;

            launcherVLabel.BackColor = backColor;
            launcherVLabel.ForeColor = fadedColor;

            clientVLabel.BackColor = backColor;
            clientVLabel.ForeColor = fadedColor;
        }

        private void website_Click(object sender, EventArgs e)
        {
            Process.Start(LINK_SETTINGS.websiteLink);
        }

        private void discord_Click(object sender, EventArgs e)
        {
            Process.Start(LINK_SETTINGS.discordInvite);
        }

        private void changeLogLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // New changelog window
            if ((ChangelogPrompt)System.Windows.Forms.Application.OpenForms["ChangelogPrompt"] != null) return;
            _currentChangelog = new ChangelogPrompt(_themeCS, VENTILE_SETTINGS.changelog);
            _currentChangelog.Show();
        }

        #endregion

        #endregion

        #region Injecting Crap

        //Not by me, 12Brendon34 gave it to me :)
        public static void ApplyAppPackages(string DLLPath)
        {
            var InfoFile = new FileInfo(DLLPath);
            FileSecurity fSecurity = InfoFile.GetAccessControl();
            fSecurity.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier("S-1-15-2-1"), FileSystemRights.FullControl, InheritanceFlags.None, PropagationFlags.NoPropagateInherit, AccessControlType.Allow));
            InfoFile.SetAccessControl(fSecurity);
        }

        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("kernel32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        private static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        private static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress,
            uint dwSize, uint flAllocationType, uint flProtect);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out UIntPtr lpNumberOfBytesWritten);

        [DllImport("kernel32.dll")]
        private static extern IntPtr CreateRemoteThread(IntPtr hProcess,
            IntPtr lpThreadAttributes, uint dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);



        // privileges
        private const int PROCESS_CREATE_THREAD = 0x0002;
        private const int PROCESS_QUERY_INFORMATION = 0x0400;
        private const int PROCESS_VM_OPERATION = 0x0008;
        private const int PROCESS_VM_WRITE = 0x0020;
        private const int PROCESS_VM_READ = 0x0010;

        // used for memory allocation
        private const uint MEM_COMMIT = 0x00001000;
        private const uint MEM_RESERVE = 0x00002000;
        private const uint PAGE_READWRITE = 4;

        private static bool ALREADY_ATTEMPTED_INJECT = false;

        public void InjectDLL(string DownloadedDllFilePath)
        {
            Task.Delay(1000);
            Process[] targetProcessIndex = Process.GetProcessesByName("Minecraft.Windows");
            if (targetProcessIndex.Length > 0)
            {
                ApplyAppPackages(DownloadedDllFilePath);

                Process targetProcess = Process.GetProcessesByName("Minecraft.Windows")[0];
                IntPtr procHandle = OpenProcess(PROCESS_CREATE_THREAD | PROCESS_QUERY_INFORMATION | PROCESS_VM_OPERATION | PROCESS_VM_WRITE | PROCESS_VM_READ, false, targetProcess.Id);

                IntPtr loadLibraryAddr = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");

                IntPtr allocMemAddress = VirtualAllocEx(procHandle, IntPtr.Zero, (uint)((DownloadedDllFilePath.Length + 1) * Marshal.SizeOf(typeof(char))), MEM_COMMIT | MEM_RESERVE, PAGE_READWRITE);

                WriteProcessMemory(procHandle, allocMemAddress, Encoding.Default.GetBytes(DownloadedDllFilePath), (uint)((DownloadedDllFilePath.Length + 1) * Marshal.SizeOf(typeof(char))), out UIntPtr _);
                CreateRemoteThread(procHandle, IntPtr.Zero, 0, loadLibraryAddr, allocMemAddress, 0, IntPtr.Zero);

                ALREADY_ATTEMPTED_INJECT = false;

                this.Toast("DLL", "Injected!");
            }
            else
            {
                if (!ALREADY_ATTEMPTED_INJECT)
                {
                    ALREADY_ATTEMPTED_INJECT = true;
                    this.Toast("DLL", "Injection failed");
                }
                else
                {
                    this.Toast("Minecraft", "I cannot find minecraft! (Bedrock)");
                    ALREADY_ATTEMPTED_INJECT = false;
                }
            }
        }


        #endregion Injecting Crap        
    }

    #region Small Classes
    internal class VersionSorter : IComparer<Version>
    {
        public int Compare(Version x, Version y)
        {

            if (x == null || y == null)
            {
                return 0;
            }

            return x.CompareTo(y);

        }
    }

    public class VentileSettings
    {
        public string launcherVersion;
        public string clientVersion;
        public string cosmeticsVersion;
        public string[] changelog;

        public bool isBeta;
    }

    public class LinkSettings
    {
        public string repoOwner;
        public string downloadRepo;
        public string versionsRepo;

        public string websiteLink;
        public string discordInvite;
        public string githubProductHeader;
    }

    #endregion
}//