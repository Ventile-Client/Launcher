using Guna.UI2.WinForms;
using Newtonsoft.Json;
using Octokit;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using VentileClient.Classes;
using VentileClient.JSON_Template_Classes;
using VentileClient.LauncherUtils;
using VentileClient.Utils;
using WK.Libraries.BetterFolderBrowserNS;

namespace VentileClient
{
    public partial class MainWindow : Form
    {

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

        public VentileSettings ventile_settings = new VentileSettings()
        {
            launcherVersion = new Version(4, 3, 0),
            clientVersion = null,
            cosmeticsVersion = new Version(1, 1, 0),
            isBeta = true,
            rpcID = "832806990953840710",
            changelog = null, // Initialized in public MainWindow()
            help = Properties.Resources.Help.Trim().Split('\n')
        };


        public LinkSettings link_settings = new LinkSettings()
        {
            githubProductHeader = "VentileClientLauncher",
            githubToken = null,

            discordInvite = "https://discord.gg/WxXw2SA9ZH",
            websiteLink = "https://ventileclient.ml",
            repoOwner = "Ventile-Client",
            versionsRepo = "VersionChanger",
            downloadRepo = "Download"
        };

        /*     >>>>>>>>>>>>>>>> REMEMBER TO CHANGE "isBeta" IN VENTILE SETTINGS BEFORE RELEASE <<<<<<<<<<<<<<<<     */

        public GitHubClient github;

        // Error/Info Loggers
        public Logger dLogger = new Logger(@"C:\temp\VentileClient\Logs", "Default", true, LogLevel.Error, LogLevel.Information, LogLocation.ConsoleAndFile, LogLocation.ConsoleAndFile);
        public Logger cLogger = new Logger(@"C:\temp\VentileClient\Logs", "Config", true, LogLevel.Error, LogLevel.Information, LogLocation.ConsoleAndFile, LogLocation.ConsoleAndFile);
        public Logger vLogger = new Logger(@"C:\temp\VentileClient\Logs", "Version", true, LogLevel.Error, LogLevel.Information, LogLocation.ConsoleAndFile, LogLocation.ConsoleAndFile);
        public Logger aLogger = new Logger(@"C:\temp\VentileClient\Logs", "Alarms", true, LogLevel.Error, LogLevel.Information, LogLocation.ConsoleAndFile, LogLocation.ConsoleAndFile);

        #region Global Variables

        #region Configurations

        public ConfigTemplate configCS = new ConfigTemplate();
        public CosmeticsTemplate cosmeticsCS = new CosmeticsTemplate();

        public ThemeTemplate themeCS = new ThemeTemplate();

        public PresetColorsTemplate presetCS = new PresetColorsTemplate();

        #endregion

        #region Version Switcher

        public int progressBarGradientOffset = 40;
        public int allowClose = 0;
        public int allowSelectVersion = 0;
        public bool backedUp = false;
        public bool versionsRetrieved = false;

        #endregion

        #region MCData Management

        public bool importing;
        public List<string> savingProfile = new List<string>();
        public bool savingRoamingState = false;

        #endregion

        #endregion

        public static MainWindow INSTANCE;
        public MainWindow()
        {
            ventile_settings.changelog = Properties.Resources.Changelog.Trim().Replace("{{Version}}", ventile_settings.launcherVersion.ToString()).Split('\n');

            INSTANCE = this;

            //Only allow app to open once is in Program.cs

            // Check for internet
            internet = InternetManager.InternetCheck();

            //Get Link settings
            if (internet)
            {
                try
                {

                    DownloadManager.Download(@"https://github.com/Ventile-Client/Download/blob/main/Settings/link_settings.json?raw=true", @"C:\temp\VentileClient", "link_settings.json");
                    string temp = File.ReadAllText(@"C:\temp\VentileClient\link_settings.json");
                    LinkSettings tmpSettings = JsonConvert.DeserializeObject<LinkSettings>(temp);
                    link_settings.discordInvite = tmpSettings?.discordInvite;
                    link_settings.websiteLink = tmpSettings?.websiteLink;
                    link_settings.repoOwner = tmpSettings?.repoOwner;
                    link_settings.versionsRepo = tmpSettings?.versionsRepo;
                    link_settings.downloadRepo = tmpSettings?.downloadRepo;
                    File.Delete(@"C:\temp\VentileClient\link_settings.json");
                }
                catch (Exception err)
                {
                    dLogger.Log(err);
                }
            }

            github = new GitHubClient(new ProductHeaderValue(link_settings.githubProductHeader));

            //Only needed when I reach api limit, to use my own token
            if (link_settings.githubToken != null) github.Credentials = new Credentials(link_settings.githubToken);

            InitializeComponent();


            // Round the form window
            this.FormBorderStyle = FormBorderStyle.None;
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            // Get Current Theme
            ConfigManager.ReadTheme();

            // Set the version's text
            Task.Run(async () =>
            {
                launcherVersionHomeLabel.Text = $"{(ventile_settings.isBeta ? "Beta " : "")}{ventile_settings.launcherVersion}";

                minecraftVersion.Text = await MCDataManager.GetMCVersion();
            });


            // Check for update
            if (!internet)
                fadeIn.Start();

            else
            {
                new UpdateCheck()
                    .CheckForUpdate(themeCS, ventile_settings, link_settings, internet, github);

                // Checks for all avaliable dlls in github
                DataManager.GetDLLS();
            }


        }

        public bool internet;

        public string minecraftResourcePacks = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"Packages\Microsoft.MinecraftUWP_8wekyb3d8bbwe\LocalState\games\com.mojang\resource_packs");
        public string gamesFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"Packages\Microsoft.MinecraftUWP_8wekyb3d8bbwe\LocalState\games\");
        private ChangelogPrompt _currentChangelog;
        private HelpPrompt _currentHelp;

        // List of all mc versions from github (Will initialize later)
        public List<Version> versions = new List<Version>();

        private async void MainWindow_Load(object sender, EventArgs e)
        {
            ConfigManager.ReadConfig();

            if (!Directory.Exists(Path.Combine(gamesFolder, "com.mojang")))
                Notif.Toast("MC Data", "I couldn't find your com.mojang, maybe start minecraft?");

            ConfigManager.ReadCosmetics();
            ConfigManager.GetPresetColors();

            ColorManager.Global();
            ColorManager.Home();
            ColorManager.ChangeBackground();

            DataManager.Home();
            DataManager.Cosmetics();
            DataManager.Settings();
            DataManager.About();

            // Initialize Rich Presence
            RPC.Idling();

            //Get Repos
            if (internet)
                await DataManager.GetMCVersions(true);

            DataManager.Version(internet);
        }

        #region Timers
        private void fadeIn_Tick(object sender, EventArgs e)
        {
            if (Opacity == 1.0)
            {
                fadeIn.Stop();
            }
            Opacity += 0.04;
        }

        private bool _inGameTest = false;
        private void internetCheck_Tick(object sender, EventArgs e)
        {
            InternetManager.ReCheckInternet();
        }

        private void TrayIcon_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) return;
            TrayIcon.Visible = false;
            this.Show();
            this.Activate();
        }

        private void TrayQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TrayOpen_Click(object sender, EventArgs e)
        {
            TrayIcon.Visible = false;
            this.Show();
            this.Activate();
        }

        List<bool> _previousMCOpenState = new List<bool>() { true, true };
        private void tick_Tick(object sender, EventArgs e)
        {
            bool minecraftOpen = Process.GetProcessesByName("Minecraft.Windows").Length > 0;
            _previousMCOpenState.Add(minecraftOpen);
            _previousMCOpenState.RemoveAt(_previousMCOpenState.Count - 3);

            bool prevMinecraftOpen = _previousMCOpenState[_previousMCOpenState.Count - 2];

            if (minecraftOpen && !prevMinecraftOpen) // Means Minecraft Was Opened
            {
                if (configCS.WindowState == "hide") // Minimizes Launcher to Tray
                {
                    this.Hide();
                    TrayIcon.Visible = true;
                    //Notif.Toast("Launcher", "Minimized to tray!");
                }

                if (configCS.WindowState == "minimize") // Minimizes launcher to taskbar
                {
                    this.WindowState = FormWindowState.Minimized;
                    //Notif.Toast("Launcher", "Minimized!");
                }

                if (configCS.WindowState == "close") // Closes Launcher
                {
                    ConfigManager.WriteConfig();
                    ConfigManager.WriteTheme();
                    RPC.Disable();
                    Task.Delay(100);
                    fadeOut.Start();
                }

                //RPC
                if (!_inGameTest)
                {
                    _inGameTest = true;
                    RPC.ChangeState("In the Game!");
                }
            }
            else if (!minecraftOpen && prevMinecraftOpen) // Means Minecraft Was Closed
            {
                if (configCS.WindowState == "hide") // Minimizes Launcher to Tray
                {
                    TrayIcon.Visible = false;
                    this.Show();
                    this.Activate();
                }

                // RPC
                if (_inGameTest)
                {
                    _inGameTest = false;
                    RPC.Idling();
                }
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

        private void homeButton_Click(object sender, EventArgs e)
        {
            //if (contentView.SelectedTab == homeTab) return;
            if (((Guna2Button)sender).Checked) return;

            DataManager.Home();
            ColorManager.Home();

            var p = new Guna2Panel();
            if (!configCS.PerformanceMode)
            {
                p.BackColor = ColorTranslator.FromHtml(themeCS.Background);
                p.Size = versionsTab.Size;
                p.Location = new Point(165, 21);
                this.Controls.Add(p);
                p.BringToFront();
                sidebar.BringToFront();
                /*p.Visible = false;
                FadeEffectBetweenPages.ShowSync(p);*/
            }

            contentView.SelectedTab = homeTab;
            this.Refresh();
            RPC.Idling();

            if (!configCS.PerformanceMode)
            {
                p.Visible = true;
                FadeEffectBetweenPages.HideSync(p);
                this.Controls.Remove(p);
            }
            this.Refresh();

            homeButton.Checked = true;
            cosmeticsButton.Checked = false;
            versionButton.Checked = false;
            settingsButton.Checked = false;
            aboutButton.Checked = false;
        }

        private void cosmeticsButton_Click(object sender, EventArgs e)
        {
            //if (contentView.SelectedTab == cosmeticsTab) return;
            if (((Guna2Button)sender).Checked) return;

            DataManager.Cosmetics();
            ColorManager.Cosmetics();

            var p = new Guna2Panel();

            if (!configCS.PerformanceMode)
            {
                p.BackColor = ColorTranslator.FromHtml(themeCS.Background);
                p.Size = versionsTab.Size;
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

            RPC.ChangeState("Choosing Cosmetics...");

            if (!configCS.PerformanceMode)
            {
                p.Visible = true;
                FadeEffectBetweenPages.HideSync(p);
                this.Controls.Remove(p);
            }
            this.Refresh();

            homeButton.Checked = false;
            cosmeticsButton.Checked = true;
            versionButton.Checked = false;
            settingsButton.Checked = false;
            aboutButton.Checked = false;
        }

        private void versionButton_Click(object sender, EventArgs e)
        {
            //if (contentView.SelectedTab == versionsTab) return;
            if (((Guna2Button)sender).Checked) return;

            DataManager.Settings();
            ColorManager.Version();

            var p = new Guna2Panel();

            if (!configCS.PerformanceMode)
            {
                p.BackColor = ColorTranslator.FromHtml(themeCS.Background);
                p.Size = versionsTab.Size;
                p.Location = new Point(165, 21);
                this.Controls.Add(p);
                p.BringToFront();
                sidebar.BringToFront();
                /*p.Visible = false;
                FadeEffectBetweenPages.ShowSync(p);*/
            }

            contentView.SelectedTab = versionsTab;
            this.Refresh();
            RPC.ChangeState("Choosing a version...");

            if (!configCS.PerformanceMode)
            {
                p.Visible = true;
                FadeEffectBetweenPages.HideSync(p);
                this.Controls.Remove(p);
            }
            this.Refresh();

            homeButton.Checked = false;
            cosmeticsButton.Checked = false;
            versionButton.Checked = true;
            settingsButton.Checked = false;
            aboutButton.Checked = false;
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            //if (contentView.SelectedTab == settingsTab) return;
            if (((Guna2Button)sender).Checked) return;

            DataManager.Settings();
            ColorManager.Settings();

            var p = new Guna2Panel();

            if (!configCS.PerformanceMode)
            {
                p.BackColor = ColorTranslator.FromHtml(themeCS.Background);
                p.Size = versionsTab.Size;
                p.Location = new Point(165, 21);
                this.Controls.Add(p);
                p.BringToFront();
                sidebar.BringToFront();
                /*p.Visible = false;
                FadeEffectBetweenPages.ShowSync(p);*/
            }

            contentView.SelectedTab = settingsTab;
            settingsPagesTabControl.SelectedTab = Launcher;
            this.Refresh();
            RPC.ChangeState("Configuring Settings...");

            if (!configCS.PerformanceMode)
            {
                p.Visible = true;
                FadeEffectBetweenPages.HideSync(p);
                this.Controls.Remove(p);
            }
            this.Refresh();

            homeButton.Checked = false;
            cosmeticsButton.Checked = false;
            versionButton.Checked = false;
            settingsButton.Checked = true;
            aboutButton.Checked = false;

            DataManager.GetProfiles();
            DataManager.GetAlarms();
        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            //if (contentView.SelectedTab == aboutTab) return;
            if (((Guna2Button)sender).Checked) return;

            DataManager.About();
            ColorManager.About();

            var p = new Guna2Panel();

            if (!configCS.PerformanceMode)
            {
                p.BackColor = ColorTranslator.FromHtml(themeCS.Background);
                p.Size = versionsTab.Size;
                p.Location = new Point(165, 21);
                this.Controls.Add(p);
                p.BringToFront();
                sidebar.BringToFront();
                /*p.Visible = false;
                FadeEffectBetweenPages.ShowSync(p);*/
            }

            contentView.SelectedTab = aboutTab;
            this.Refresh();
            RPC.Idling();

            if (!configCS.PerformanceMode)
            {
                p.Visible = true;
                FadeEffectBetweenPages.HideSync(p);
                this.Controls.Remove(p);
            }
            this.Refresh();

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

        bool _isClosing;
        private void close(string logText)
        {
            if (allowClose == 0)
            {
                if (_isClosing) return;
                _isClosing = true;

                ConfigManager.WriteConfig();
                ConfigManager.WriteTheme();
                ConfigManager.WriteCosmetics();

                RPC.Disable();

                dLogger.Log(logText);
                closeButton.DisabledState.FillColor = closeButton.FillColor;
                closeButton.DisabledState.BorderColor = closeButton.DisabledState.BorderColor;
                closeButton.DisabledState.ForeColor = closeButton.ForeColor;

                closeButton.Enabled = false;


                //Close all loggers
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
                if (allowSelectVersion > 0)
                {
                    Notif.Toast("Version Manager", "Sorry, your still selecting your version!");
                    return;
                }
                Notif.Toast("Version Manager", "Sorry, your still installing!");
            }
        }

        private void minimizeButton_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.Hide();
                TrayIcon.Visible = true;
                Notif.Toast("Launcher", "Minimized to tray!");
                return;
            }
            this.WindowState = FormWindowState.Minimized;
        }

        #endregion

        #region Tabs

        #region Home
        public Guna2Panel versionsPanel = new Guna2Panel();

        private async void launchMc_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("minecraft://");
            }
            catch (Exception ex)
            {
                Notif.Toast("Error", "Sorry, there was an error launching...");
                dLogger.Log(ex);
                return;
            }

            if (configCS.AutoInject)
            {
                await Task.Delay(configCS.InjectDelay * 1000); // Delay injection by amount of milliseconds

                if (Process.GetProcessesByName("Minecraft.Windows").Length > 0)
                {
                    if (configCS.CustomDLL)
                    {
                        if (configCS.DefaultDLL?.Length > 0)
                            InjectionManager.InjectDLL(configCS.DefaultDLL);

                        else
                            Notif.Toast("DLL", "Not injecting, no file specified");
                    }
                    else
                    {
                        //Inject Selected DLL
                        if (selectedDLLName != null)
                            InjectionManager.InjectDLL(Path.Combine(@"C:\temp\VentileClient\Dlls", selectedDLLName));

                        else
                            Notif.Toast("DLL", "Not injecting, no file specified");
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
                configCS.DefaultDLL = @FileIn.FileName;
                Notif.Toast("DLL", "Your DLL is selected!");
                SelectDLLTooltip.SetToolTip(selectDll, configCS.DefaultDLL);

                if (!configCS.CustomDLL)
                {
                    Notif.Toast("DLL", "Enable Custom DLL to use your selected DLL!");
                }
            }
            else
            {
                Notif.Toast("DLL", "You didn't specify a DLL!");
            }
        }

        private void inject_Click(object sender, EventArgs e)
        {
            if (Process.GetProcessesByName("Minecraft.Windows").Length > 0)
            {
                if (configCS.CustomDLL)
                {
                    if (configCS.DefaultDLL.Length > 0)
                    {
                        InjectionManager.InjectDLL(configCS.DefaultDLL);
                    }
                }
                else
                {
                    //Inject Selected DLL
                    if (selectedDLLName != null)
                        InjectionManager.InjectDLL(Path.Combine(@"C:\temp\VentileClient\DLLS", selectedDLLName));
                    else
                        Notif.Toast("DLL", "Not injecting, no file specified");
                }
            }
        }

        #endregion

        #region Cosmetics

        #region Capes
        private async void cBlack_Click(object sender, EventArgs e)
        {
            if (internet)
            {
                resetCapes();
                resetAnimated();
                cBlack.Checked = true;
                cosmeticsCS.cBlack = true;

                CosmeticManager.Add(CosmeticManager.Pack.BlackCape);

                CosmeticManager.Remove(CosmeticManager.Pack.CosmeticMixer);
                CosmeticManager.Add(CosmeticManager.Pack.CosmeticMixer);

                ConfigManager.WriteCosmetics();

                //Auto Download
                await DownloadManager.DownloadAsync(string.Format(@"https://github.com/" + link_settings.repoOwner + "/" + link_settings.downloadRepo + @"/blob/main/Cosmetics/{0}?raw=true", "BlackVentileCape.zip"), minecraftResourcePacks, "BlackVentileCape.zip");
            }
            else
            {
                Notif.Toast("Internet", "You do not a wifi connection");
            }
        }

        private async void cWhite_Click(object sender, EventArgs e)
        {
            if (internet)
            {
                resetCapes();
                resetAnimated();
                cWhite.Checked = true;
                cosmeticsCS.cWhite = true;

                CosmeticManager.Add(CosmeticManager.Pack.WhiteCape);

                CosmeticManager.Remove(CosmeticManager.Pack.CosmeticMixer);
                CosmeticManager.Add(CosmeticManager.Pack.CosmeticMixer);

                ConfigManager.WriteCosmetics();

                //Auto Download

                await DownloadManager.DownloadAsync(string.Format(@"https://github.com/" + link_settings.repoOwner + "/" + link_settings.downloadRepo + @"/blob/main/Cosmetics/{0}?raw=true", "WhiteVentileCape.zip"), minecraftResourcePacks, "WhiteVentileCape.zip");

            }
            else
            {
                Notif.Toast("Internet", "You do not a wifi connection");
            }
        }

        private async void cPink_Click(object sender, EventArgs e)
        {
            if (internet)
            {
                resetCapes();
                resetAnimated();
                cPink.Checked = true;
                cosmeticsCS.cPink = true;

                CosmeticManager.Add(CosmeticManager.Pack.PinkCape);

                CosmeticManager.Remove(CosmeticManager.Pack.CosmeticMixer);
                CosmeticManager.Add(CosmeticManager.Pack.CosmeticMixer);

                ConfigManager.WriteCosmetics();

                //Auto Download

                await DownloadManager.DownloadAsync(string.Format(@"https://github.com/" + link_settings.repoOwner + "/" + link_settings.downloadRepo + @"/blob/main/Cosmetics/{0}?raw=true", "PinkVentileCape.zip"), minecraftResourcePacks, "PinkVentileCape.zip");

            }
            else
            {
                Notif.Toast("Internet", "You do not a wifi connection");
            }
        }

        private async void cBlue_Click(object sender, EventArgs e)
        {
            if (internet)
            {
                resetCapes();
                resetAnimated();
                cBlue.Checked = true;
                cosmeticsCS.cBlue = true;

                CosmeticManager.Add(CosmeticManager.Pack.BlueCape);

                CosmeticManager.Remove(CosmeticManager.Pack.CosmeticMixer);
                CosmeticManager.Add(CosmeticManager.Pack.CosmeticMixer);

                ConfigManager.WriteCosmetics();

                //Auto Download

                await DownloadManager.DownloadAsync(string.Format(@"https://github.com/" + link_settings.repoOwner + "/" + link_settings.downloadRepo + @"/blob/main/Cosmetics/{0}?raw=true", "BlueVentileCape.zip"), minecraftResourcePacks, "BlueVentileCape.zip");

            }
            else
            {
                Notif.Toast("Internet", "You do not a wifi connection");
            }
        }

        private async void cYellow_Click(object sender, EventArgs e)
        {
            if (internet)
            {
                resetCapes();
                resetAnimated();

                cYellow.Checked = true;
                cosmeticsCS.cYellow = true;
                CosmeticManager.Add(CosmeticManager.Pack.YellowCape);

                CosmeticManager.Remove(CosmeticManager.Pack.CosmeticMixer);
                CosmeticManager.Add(CosmeticManager.Pack.CosmeticMixer);

                ConfigManager.WriteCosmetics();

                //Auto Download

                await DownloadManager.DownloadAsync(string.Format(@"https://github.com/" + link_settings.repoOwner + "/" + link_settings.downloadRepo + @"/blob/main/Cosmetics/{0}?raw=true", "YellowVentileCape.zip"), minecraftResourcePacks, "YellowVentileCape.zip");

            }
            else
            {
                Notif.Toast("Internet", "You do not a wifi connection");
            }
        }

        private async void cRick_Click(object sender, EventArgs e)
        {
            if (internet)
            {
                resetCapes();
                resetAnimated();
                cRick.Checked = true;
                cosmeticsCS.cRick = true;

                CosmeticManager.Add(CosmeticManager.Pack.RickCape);

                CosmeticManager.Remove(CosmeticManager.Pack.CosmeticMixer);
                CosmeticManager.Add(CosmeticManager.Pack.CosmeticMixer);

                ConfigManager.WriteCosmetics();

                //Auto Download

                await DownloadManager.DownloadAsync(string.Format(@"https://github.com/" + link_settings.repoOwner + "/" + link_settings.downloadRepo + @"/blob/main/Cosmetics/{0}?raw=true", "RickVentileCape.zip"), minecraftResourcePacks, "RickVentileCape.zip");

            }
            else
            {
                Notif.Toast("Internet", "You do not a wifi connection");
            }
        }

        private async void resetCapes()
        {
            if (!internet) return;

            cosmeticsCS.cBlack = false;
            cosmeticsCS.cWhite = false;
            cosmeticsCS.cPink = false;
            cosmeticsCS.cBlue = false;
            cosmeticsCS.cYellow = false;
            cosmeticsCS.cRick = false;

            cBlack.Checked = false;
            cWhite.Checked = false;
            cPink.Checked = false;
            cBlue.Checked = false;
            cYellow.Checked = false;
            cRick.Checked = false;

            CosmeticManager.Remove(CosmeticManager.Pack.BlackCape);
            CosmeticManager.Remove(CosmeticManager.Pack.WhiteCape);
            CosmeticManager.Remove(CosmeticManager.Pack.PinkCape);
            CosmeticManager.Remove(CosmeticManager.Pack.BlueCape);
            CosmeticManager.Remove(CosmeticManager.Pack.YellowCape);
            CosmeticManager.Remove(CosmeticManager.Pack.RickCape);

            await deleteCosmetics(new string[] { "BlackVentileCape.zip", "WhiteVentileCape.zip", "PinkVentileCape.zip", "BlueVentileCape.zip", "YellowVentileCape.zip", "RickVentileCape.zip" });
        }
        #endregion

        #region Masks

        private async void mBlack_Click(object sender, EventArgs e)
        {
            if (internet)
            {
                resetMasks();
                mBlack.Checked = true;
                cosmeticsCS.mBlack = true;

                CosmeticManager.Add(CosmeticManager.Pack.BlackMask);

                CosmeticManager.Remove(CosmeticManager.Pack.CosmeticMixer);
                CosmeticManager.Add(CosmeticManager.Pack.CosmeticMixer);

                ConfigManager.WriteCosmetics();

                //Auto Download

                await DownloadManager.DownloadAsync(string.Format(@"https://github.com/" + link_settings.repoOwner + "/" + link_settings.downloadRepo + @"/blob/main/Cosmetics/{0}?raw=true", "BlackVentileMask.zip"), minecraftResourcePacks, "BlackVentileMask.zip");

            }
            else
            {
                Notif.Toast("Internet", "You do not a wifi connection");
            }
        }

        private async void mWhite_Click(object sender, EventArgs e)
        {
            if (internet)
            {
                resetMasks();
                mWhite.Checked = true;
                cosmeticsCS.mWhite = true;

                CosmeticManager.Add(CosmeticManager.Pack.WhiteMask);

                CosmeticManager.Remove(CosmeticManager.Pack.CosmeticMixer);
                CosmeticManager.Add(CosmeticManager.Pack.CosmeticMixer);

                ConfigManager.WriteCosmetics();

                //Auto Download

                await DownloadManager.DownloadAsync(string.Format(@"https://github.com/" + link_settings.repoOwner + "/" + link_settings.downloadRepo + @"/blob/main/Cosmetics/{0}?raw=true", "WhiteVentileMask.zip"), minecraftResourcePacks, "WhiteVentileMask.zip");

            }
            else
            {
                Notif.Toast("Internet", "You do not a wifi connection");
            }
        }

        private async void mPink_Click(object sender, EventArgs e)
        {
            if (internet)
            {
                resetMasks();
                mPink.Checked = true;
                cosmeticsCS.mPink = true;

                CosmeticManager.Add(CosmeticManager.Pack.PinkMask);

                CosmeticManager.Remove(CosmeticManager.Pack.CosmeticMixer);
                CosmeticManager.Add(CosmeticManager.Pack.CosmeticMixer);

                ConfigManager.WriteCosmetics();

                //Auto Download

                await DownloadManager.DownloadAsync(string.Format(@"https://github.com/" + link_settings.repoOwner + "/" + link_settings.downloadRepo + @"/blob/main/Cosmetics/{0}?raw=true", "PinkVentileMask.zip"), minecraftResourcePacks, "PinkVentileMask.zip");

            }
            else
            {
                Notif.Toast("Internet", "You do not a wifi connection");
            }
        }

        private async void mBlue_Click(object sender, EventArgs e)
        {
            if (internet)
            {
                resetMasks();
                mBlue.Checked = true;
                cosmeticsCS.mBlue = true;

                CosmeticManager.Add(CosmeticManager.Pack.BlueMask);

                CosmeticManager.Remove(CosmeticManager.Pack.CosmeticMixer);
                CosmeticManager.Add(CosmeticManager.Pack.CosmeticMixer);

                ConfigManager.WriteCosmetics();

                //Auto Download

                await DownloadManager.DownloadAsync(string.Format(@"https://github.com/" + link_settings.repoOwner + "/" + link_settings.downloadRepo + @"/blob/main/Cosmetics/{0}?raw=true", "BlueVentileMask.zip"), minecraftResourcePacks, "BlueVentileMask.zip");

            }
            else
            {
                Notif.Toast("Internet", "You do not a wifi connection");
            }
        }

        private async void mYellow_Click(object sender, EventArgs e)
        {
            if (internet)
            {
                resetMasks();
                mYellow.Checked = true;
                cosmeticsCS.mYellow = true;

                CosmeticManager.Add(CosmeticManager.Pack.YellowMask);

                CosmeticManager.Remove(CosmeticManager.Pack.CosmeticMixer);
                CosmeticManager.Add(CosmeticManager.Pack.CosmeticMixer);

                ConfigManager.WriteCosmetics();

                //Auto Download

                await DownloadManager.DownloadAsync(string.Format(@"https://github.com/" + link_settings.repoOwner + "/" + link_settings.downloadRepo + @"/blob/main/Cosmetics/{0}?raw=true", "YellowVentileMask.zip"), minecraftResourcePacks, "YellowVentileMask.zip");

            }
            else
            {
                Notif.Toast("Internet", "You do not a wifi connection");
            }
        }

        private async void mRick_Click(object sender, EventArgs e)
        {
            if (internet)
            {
                resetMasks();
                mRick.Checked = true;
                cosmeticsCS.mRick = true;

                CosmeticManager.Add(CosmeticManager.Pack.RickMask);

                CosmeticManager.Remove(CosmeticManager.Pack.CosmeticMixer);
                CosmeticManager.Add(CosmeticManager.Pack.CosmeticMixer);

                ConfigManager.WriteCosmetics();

                //Auto Download

                await DownloadManager.DownloadAsync(string.Format(@"https://github.com/" + link_settings.repoOwner + "/" + link_settings.downloadRepo + @"/blob/main/Cosmetics/{0}?raw=true", "RickVentileMask.zip"), minecraftResourcePacks, "RickVentileMask.zip");

            }
            else
            {
                Notif.Toast("Internet", "You do not a wifi connection");
            }
        }

        private async Task deleteCosmetics(string[] FileNames)
        {
            await Task.Run(async () =>
            {
                foreach (string fileName in FileNames)
                {
                    try
                    {
                        if (File.Exists(Path.Combine(minecraftResourcePacks, fileName)))
                        {
                            File.Delete(Path.Combine(minecraftResourcePacks, fileName));
                            Debug.WriteLine("Deleted: " + fileName);
                        }
                    }
                    catch
                    {
                        await Task.Delay(5);
                        await deleteCosmetics(new string[] { fileName });
                        Debug.WriteLine("Trying to delete: " + fileName);
                    }
                }
                return Task.CompletedTask;
            });
        }

        private async void resetMasks()
        {
            if (!internet) return;


            cosmeticsCS.mBlack = false;
            cosmeticsCS.mWhite = false;
            cosmeticsCS.mPink = false;
            cosmeticsCS.mBlue = false;
            cosmeticsCS.mYellow = false;
            cosmeticsCS.mRick = false;

            mBlack.Checked = false;
            mWhite.Checked = false;
            mPink.Checked = false;
            mBlue.Checked = false;
            mYellow.Checked = false;
            mRick.Checked = false;

            CosmeticManager.Remove(CosmeticManager.Pack.BlackMask);
            CosmeticManager.Remove(CosmeticManager.Pack.WhiteMask);
            CosmeticManager.Remove(CosmeticManager.Pack.PinkMask);
            CosmeticManager.Remove(CosmeticManager.Pack.BlueMask);
            CosmeticManager.Remove(CosmeticManager.Pack.YellowMask);
            CosmeticManager.Remove(CosmeticManager.Pack.RickMask);

            await deleteCosmetics(new string[] { "BlackVentileMask.zip", "WhiteVentileMask.zip", "PinkVentileMask.zip", "BlueVentileMask.zip", "YellowVentileMask.zip", "RickVentileMask.zip" });
        }

        #endregion

        #region Animated

        private async void aGlowing_Click(object sender, EventArgs e)
        {
            if (internet)
            {
                resetAnimated();
                resetCapes();

                aGlowing.Checked = true;
                cosmeticsCS.aGlowing = true;

                CosmeticManager.Add(CosmeticManager.Pack.GlowingCape);

                CosmeticManager.Remove(CosmeticManager.Pack.CosmeticMixer);
                CosmeticManager.Add(CosmeticManager.Pack.CosmeticMixer);

                ConfigManager.WriteCosmetics();


                await DownloadManager.DownloadAsync(string.Format(@"https://github.com/" + link_settings.repoOwner + "/" + link_settings.downloadRepo + @"/blob/main/Cosmetics/{0}?raw=true", "GlowingVentileCape.zip"), minecraftResourcePacks, "GlowingVentileCape.zip");

            }
            else
            {
                Notif.Toast("Internet", "You do not a wifi connection");
            }
        }

        private async void aSlide_Click(object sender, EventArgs e)
        {
            if (internet)
            {
                resetAnimated();
                resetCapes();

                aSlide.Checked = true;
                cosmeticsCS.aGlowing = true;

                CosmeticManager.Add(CosmeticManager.Pack.SlidingCape);

                CosmeticManager.Remove(CosmeticManager.Pack.CosmeticMixer);
                CosmeticManager.Add(CosmeticManager.Pack.CosmeticMixer);

                ConfigManager.WriteCosmetics();


                await DownloadManager.DownloadAsync(string.Format(@"https://github.com/" + link_settings.repoOwner + "/" + link_settings.downloadRepo + @"/blob/main/Cosmetics/{0}?raw=true", "SlidingVentileCape.zip"), minecraftResourcePacks, "SlidingVentileCape.zip");

            }
            else
            {
                Notif.Toast("Internet", "You do not a wifi connection");
            }
        }

        private async void resetAnimated()
        {
            if (!internet) return;

            aGlowing.Checked = false;
            aSlide.Checked = false;

            cosmeticsCS.aGlowing = false;
            cosmeticsCS.aSlide = false;


            CosmeticManager.Remove(CosmeticManager.Pack.GlowingCape);
            CosmeticManager.Remove(CosmeticManager.Pack.SlidingCape);

            await deleteCosmetics(new string[] { "GlowingVentileCape.zip", "SlidingVentileCape.zip" });

        }


        #endregion

        #region Others

        private async void oWavy_Click(object sender, EventArgs e)
        {
            if (internet)
            {
                oWavy.Checked = true;
                cosmeticsCS.oWavy = true;

                CosmeticManager.Add(CosmeticManager.Pack.WavyOverlay);

                CosmeticManager.Remove(CosmeticManager.Pack.CosmeticMixer);
                CosmeticManager.Add(CosmeticManager.Pack.CosmeticMixer);

                ConfigManager.WriteCosmetics();


                await DownloadManager.DownloadAsync(string.Format(@"https://github.com/" + link_settings.repoOwner + "/" + link_settings.downloadRepo + @"/blob/main/Cosmetics/{0}?raw=true", "WavyVentile.zip"), minecraftResourcePacks, "WavyVentile.zip");

            }
            else
            {
                Notif.Toast("Internet", "You do not a wifi connection");
            }
        }

        private async void oKagune_Click(object sender, EventArgs e)
        {
            if (internet)
            {
                oKagune.Checked = true;
                cosmeticsCS.oKagune = true;

                CosmeticManager.Add(CosmeticManager.Pack.Kagune);
                CosmeticManager.Remove(CosmeticManager.Pack.CosmeticMixer);
                CosmeticManager.Add(CosmeticManager.Pack.CosmeticMixer);

                ConfigManager.WriteCosmetics();

                await DownloadManager.DownloadAsync(string.Format(@"https://github.com/" + link_settings.repoOwner + "/" + link_settings.downloadRepo + @"/blob/main/Cosmetics/{0}?raw=true", "Kagune.zip"), minecraftResourcePacks, "KaguneVentile.zip");
            }
            else
            {
                Notif.Toast("Internet", "You do not a wifi connection");
            }
        }

        private async void resetOthers()
        {
            if (!internet) return;

            oWavy.Checked = false;
            oKagune.Checked = false;

            cosmeticsCS.oWavy = false;
            cosmeticsCS.oKagune = false;

            CosmeticManager.Remove(CosmeticManager.Pack.WavyOverlay);
            CosmeticManager.Remove(CosmeticManager.Pack.Kagune);

            await deleteCosmetics(new string[] { "WavyVentile.zip", "KaguneVentile.zip" });

        }

        #endregion

        private void resetAllCosmetics_Click(object sender, EventArgs e)
        {
            resetCapes();
            resetMasks();
            resetAnimated();
            resetOthers();
            ConfigManager.WriteCosmetics();
        }

        #endregion

        #region Settings

        //Launcher
        private void AppearanceButton_Click(object sender, EventArgs e)
        {
            var p = new Guna2Panel();

            if (!configCS.PerformanceMode)
            {
                p.BackColor = ColorTranslator.FromHtml(themeCS.Background);
                p.Size = new Size(settingsTab.Width, settingsPagesTabControl.Height);
                p.Location = new Point(165, 110);
                this.Controls.Add(p);
                p.BringToFront();
                sidebar.BringToFront();
                /*p.Visible = false;
                FadeEffectBetweenPages.ShowSync(p);*/
            }

            settingsPagesTabControl.SelectedTab = Appearance;
            this.Refresh();

            if (!configCS.PerformanceMode)
            {
                p.Visible = true;
                FadeEffectBetweenPages.HideSync(p);
                this.Controls.Remove(p);
            }
            this.Refresh();
        }

        private void hideWindow_Click(object sender, EventArgs e)
        {
            configCS.WindowState = "hide";
            hideWindow.Checked = true;
            minWindow.Checked = false;
            closeWindow.Checked = false;
            openWindow.Checked = false;
        }

        private void minWindow_Click(object sender, EventArgs e)
        {
            configCS.WindowState = "minimize";
            hideWindow.Checked = false;
            minWindow.Checked = true;
            closeWindow.Checked = false;
            openWindow.Checked = false;
        }

        private void closeWindow_Click(object sender, EventArgs e)
        {
            configCS.WindowState = "close";
            hideWindow.Checked = false;
            minWindow.Checked = false;
            closeWindow.Checked = true;
            openWindow.Checked = false;
        }

        private void openWindow_Click(object sender, EventArgs e)
        {
            configCS.WindowState = "open";
            hideWindow.Checked = false;
            minWindow.Checked = false;
            closeWindow.Checked = false;
            openWindow.Checked = true;
        }

        private void autoInject_Click(object sender, EventArgs e)
        {
            if (configCS.AutoInject)
            {
                configCS.AutoInject = false;
                autoInject.Checked = false;
                autoInject.Text = "Off";
            }
            else
            {
                configCS.AutoInject = true;
                autoInject.Checked = true;
                autoInject.Text = "On";
            }
        }

        private bool _rpcCooldown;

        private void RpcToggle_Click(object sender, EventArgs e)
        {
            if (_rpcCooldown)
                return;

            if (configCS.RichPresence)
            {
                RpcToggle.Checked = false;
                RpcToggle.Text = "Off";

                RPCTextbox.Visible = false;

                buttonForRpc.Visible = false;
                RPCButtonLinkTextbox.Visible = false;
                RPCButtonTextbox.Visible = false;

                configCS.RichPresence = false;

                Cooldown(10);
                RPC.Disable();
            }
            else
            {
                RpcToggle.Checked = true;
                RpcToggle.Text = "On";

                RPCTextbox.Visible = true;

                buttonForRpc.Visible = true;
                RPCTextbox.Text = configCS.RpcText;
                RPCTextbox.Visible = true;


                if (configCS.RpcButton)
                {
                    RPCButtonLinkTextbox.Visible = true;
                    RPCButtonTextbox.Visible = true;

                    RPCButtonLinkTextbox.Text = configCS.RpcButtonLink;
                    RPCButtonTextbox.Text = configCS.RpcButtonText;
                }

                configCS.RichPresence = true;

                Cooldown(10);
                RPC.Idling();
            }
        }

        private void customImage_Click(object sender, EventArgs e)
        {
            if (configCS.BackgroundImage)
            {
                configCS.BackgroundImage = false;
                customImage.Checked = false;
                customImage.Text = "Off";

                ColorManager.SetBackgroundString();
                ColorManager.ChangeBackground();
            }
            else
            {
                var customImg = new OpenFileDialog()
                {
                    Title = "Custom Background Image",
                    Filter = "Image Files (*.bmp;*.jpg;*.jpeg;*.png)|*.BMP;*.JPG;*.JPEG;*.PNG"
                };


                if (customImg.ShowDialog() == DialogResult.OK)
                {
                    configCS.BackgroundImage = true;
                    customImage.Checked = true;
                    customImage.Text = "On";

                    homeTab.BackgroundImage = new Bitmap(customImg.FileName);

                    ColorManager.SetBackgroundString();
                    ColorManager.ChangeBackground();
                }
                else
                {
                    Notif.Toast("Error", "There was an error selecting image.");
                }
            }
        }

        private void roundedToggle_Click(object sender, EventArgs e)
        {
            if (configCS.RoundedButtons)
            {
                configCS.RoundedButtons = false;
                roundedToggle.Checked = false;
                roundedToggle.Text = "Off";
            }
            else
            {
                configCS.RoundedButtons = true;
                roundedToggle.Checked = true;
                roundedToggle.Text = "On";
            }
            ColorManager.Settings();
        }

        private void rpcLine_TextChanged(object sender, EventArgs e)
        {
            configCS.RpcText = RPCTextbox.Text;
        }

        private void rpcButtonLink_TextChanged(object sender, EventArgs e)
        {
            configCS.RpcButtonLink = RPCButtonLinkTextbox.Text;
        }

        private void rpcButtonText_TextChanged(object sender, EventArgs e)
        {
            configCS.RpcButtonText = RPCButtonTextbox.Text;
        }

        private async void Cooldown(int sec)
        {
            _rpcCooldown = true;
            Notif.Toast("Rich Presence", "You're on cooldown for " + sec + "s");
            await Task.Delay(sec * 1000);
            _rpcCooldown = false;
            Notif.Toast("Rich Presence", "Cooldown finished");
        }

        private void buttonForRpc_Click(object sender, EventArgs e)
        {
            if (configCS.RpcButton)
            {
                buttonForRpc.Checked = false;
                RPCButtonLinkTextbox.Visible = false;
                RPCButtonTextbox.Visible = false;

                configCS.RpcButton = false;
            }
            else
            {
                RPCButtonLinkTextbox.Text = configCS.RpcButtonLink;
                RPCButtonTextbox.Text = configCS.RpcButtonText;

                buttonForRpc.Checked = true;
                RPCButtonLinkTextbox.Visible = true;
                RPCButtonTextbox.Visible = true;


                configCS.RpcButton = true;
            }
        }

        public string selectedDLLName;
        private void customDLLButton_Click(object sender, EventArgs e)
        {
            if (configCS.CustomDLL)
            {
                configCS.CustomDLL = false;

                customDLLButton.Checked = false;
            }
            else
            {
                configCS.CustomDLL = true;

                customDLLButton.Checked = true;
            }
        }

        private void injectDelay_ValueChanged(object sender, EventArgs e)
        {
            injectDelay.DecimalPlaces = 0;
            configCS.InjectDelay = (int)injectDelay.Value;
        }

        private void personaLoc_Click(object sender, EventArgs e)
        {
            if (configCS.Persona)
            {
                configCS.Persona = false;
                personaLoc.Checked = false;
                configCS.PersonaLoc = "";
                VersionManager.RemovePersona();
            }
            else
            {
                var personaFolder = new BetterFolderBrowser
                {
                    Title = "Choose your persona folder!"
                };
                if (Directory.Exists(@"C:\Program Files\WindowsApps\Microsoft.MinecraftUWP_8wekyb3d8bbwe\data\skin_packs"))
                    personaFolder.RootFolder = @"C:\Program Files\WindowsApps\Microsoft.MinecraftUWP_8wekyb3d8bbwe\data\skin_packs";
                else
                    personaFolder.RootFolder = @"C:\";

                // Allow multi-selection of folders.
                personaFolder.Multiselect = false;

                if (personaFolder.ShowDialog() == DialogResult.OK)
                {
                    configCS.PersonaLoc = personaFolder.SelectedFolder;
                    Notif.Toast("Persona", "Persona Selected!");
                }
                else
                {
                    Notif.Toast("Persona", "There was an error selecting your persona!");
                    return;
                }
                configCS.Persona = true;
                personaLoc.Checked = true;
                VersionManager.ImportPersona(false, true);
            }
        }

        //Appearance
        private void LauncherButton_Click(object sender, EventArgs e)
        {
            var p = new Guna2Panel();
            if (!configCS.PerformanceMode)
            {
                p.BackColor = ColorTranslator.FromHtml(themeCS.Background);
                p.Size = new Size(settingsTab.Width, settingsPagesTabControl.Height);
                p.Location = new Point(165, 110);
                this.Controls.Add(p);
                p.BringToFront();
                sidebar.BringToFront();
                /*p.Visible = false;
                FadeEffectBetweenPages.ShowSync(p);*/
            }

            settingsPagesTabControl.SelectedTab = Launcher;
            this.Refresh();

            if (!configCS.PerformanceMode)
            {
                p.Visible = true;
                FadeEffectBetweenPages.HideSync(p);
                this.Controls.Remove(p);
            }
            this.Refresh();
        }

        private void ExtrasButton_Click(object sender, EventArgs e)
        {
            var p = new Guna2Panel();

            if (!configCS.PerformanceMode)
            {
                p.BackColor = ColorTranslator.FromHtml(themeCS.Background);
                p.Size = new Size(settingsTab.Width, settingsPagesTabControl.Height);
                p.Location = new Point(165, 110);
                this.Controls.Add(p);
                p.BringToFront();
                sidebar.BringToFront();
                /*p.Visible = false;
                FadeEffectBetweenPages.ShowSync(p);*/
            }

            settingsPagesTabControl.SelectedTab = Extras;
            this.Refresh();

            if (!configCS.PerformanceMode)
            {
                p.Visible = true;
                FadeEffectBetweenPages.HideSync(p);
                this.Controls.Remove(p);
            }
            this.Refresh();
        }

        private void theme_Click(object sender, EventArgs e)
        {
            bool[] presets = { false, false, false, false, false, false, false, false };
            if (preset1.BackColor == ColorTranslator.FromHtml(themeCS.SecondBackground))
                presets[0] = true;
            if (preset2.BackColor == ColorTranslator.FromHtml(themeCS.SecondBackground))
                presets[1] = true;
            if (preset3.BackColor == ColorTranslator.FromHtml(themeCS.SecondBackground))
                presets[2] = true;
            if (preset4.BackColor == ColorTranslator.FromHtml(themeCS.SecondBackground))
                presets[3] = true;
            if (preset5.BackColor == ColorTranslator.FromHtml(themeCS.SecondBackground))
                presets[4] = true;
            if (preset6.BackColor == ColorTranslator.FromHtml(themeCS.SecondBackground))
                presets[5] = true;
            if (preset7.BackColor == ColorTranslator.FromHtml(themeCS.SecondBackground))
                presets[6] = true;
            if (preset8.BackColor == ColorTranslator.FromHtml(themeCS.SecondBackground))
                presets[7] = true;

            if (themeCS.Theme == ThemeTemplate.theme.Dark)
            {
                themeCS.Background = Themes.lightTheme.Background;
                themeCS.SecondBackground = Themes.lightTheme.SecondBackground;
                themeCS.Foreground = Themes.lightTheme.Foreground;
                themeCS.Outline = Themes.lightTheme.Outline;
                themeCS.Faded = Themes.lightTheme.Faded;

                themeCS.Theme = ThemeTemplate.theme.Light;


                logo.Image = Properties.Resources.transparent_logo_black;

                //About things
                discord.Image = Properties.Resources.transparent_logo_black;
                website.Image = Properties.Resources.website_black;
            }
            else if (themeCS.Theme == ThemeTemplate.theme.Light)
            {
                themeCS.Background = Themes.darkTheme.Background;
                themeCS.SecondBackground = Themes.darkTheme.SecondBackground;
                themeCS.Foreground = Themes.darkTheme.Foreground;
                themeCS.Outline = Themes.darkTheme.Outline;
                themeCS.Faded = Themes.darkTheme.Faded;

                themeCS.Theme = ThemeTemplate.theme.Dark;

                logo.Image = Properties.Resources.transparent_logo_white;

                //About things
                discord.Image = Properties.Resources.transparent_logo_white;
                website.Image = Properties.Resources.website_white;
            }

            if (presets[0])
                presetCS.p1 = themeCS.SecondBackground;
            if (presets[1])
                presetCS.p2 = themeCS.SecondBackground;
            if (presets[2])
                presetCS.p3 = themeCS.SecondBackground;
            if (presets[3])
                presetCS.p4 = themeCS.SecondBackground;
            if (presets[4])
                presetCS.p5 = themeCS.SecondBackground;
            if (presets[5])
                presetCS.p6 = themeCS.SecondBackground;
            if (presets[6])
                presetCS.p7 = themeCS.SecondBackground;
            if (presets[7])
                presetCS.p8 = themeCS.SecondBackground;

            DataManager.Settings();
            ColorManager.ChangeBackground();
            ColorManager.Settings();
            ColorManager.About();
            ColorManager.Cosmetics();
            ColorManager.Global();
        }

        private void resetThemes_Click(object sender, EventArgs e)
        {
            bool[] presets = { false, false, false, false, false, false, false, false };
            if (preset1.BackColor == ColorTranslator.FromHtml(themeCS.SecondBackground))
                presets[0] = true;
            if (preset2.BackColor == ColorTranslator.FromHtml(themeCS.SecondBackground))
                presets[1] = true;
            if (preset3.BackColor == ColorTranslator.FromHtml(themeCS.SecondBackground))
                presets[2] = true;
            if (preset4.BackColor == ColorTranslator.FromHtml(themeCS.SecondBackground))
                presets[3] = true;
            if (preset5.BackColor == ColorTranslator.FromHtml(themeCS.SecondBackground))
                presets[4] = true;
            if (preset6.BackColor == ColorTranslator.FromHtml(themeCS.SecondBackground))
                presets[5] = true;
            if (preset7.BackColor == ColorTranslator.FromHtml(themeCS.SecondBackground))
                presets[6] = true;
            if (preset8.BackColor == ColorTranslator.FromHtml(themeCS.SecondBackground))
                presets[7] = true;

            if (themeCS.Theme == ThemeTemplate.theme.Light)
            {
                themeCS.Background = Themes.lightTheme.Background;
                themeCS.SecondBackground = Themes.lightTheme.SecondBackground;
                themeCS.Accent = Themes.lightTheme.Accent;
                themeCS.Foreground = Themes.lightTheme.Foreground;
                themeCS.Outline = Themes.lightTheme.Outline;
                themeCS.Faded = Themes.lightTheme.Faded;

                themeCS.Theme = ThemeTemplate.theme.Light;

                //Accent Color Changer
                backgroundBrightnessSlider.Value = ColorTranslator.FromHtml(themeCS.Background).R;
                buttonBrightnessSlider.Value = ColorTranslator.FromHtml(themeCS.SecondBackground).R;
                outlineBrightnessSlider.Value = ColorTranslator.FromHtml(themeCS.Outline).R;
                textBrightnessSlider.Value = ColorTranslator.FromHtml(themeCS.Foreground).R;
                accentRedSlider.Value = ColorTranslator.FromHtml(themeCS.Accent).R;
                accentGreenSlider.Value = ColorTranslator.FromHtml(themeCS.Accent).G;
                accentBlueSlider.Value = ColorTranslator.FromHtml(themeCS.Accent).B;
            }
            else if (themeCS.Theme == ThemeTemplate.theme.Dark)
            {
                themeCS.Background = Themes.darkTheme.Background;
                themeCS.SecondBackground = Themes.darkTheme.SecondBackground;
                themeCS.Accent = Themes.darkTheme.Accent;
                themeCS.Foreground = Themes.darkTheme.Foreground;
                themeCS.Outline = Themes.darkTheme.Outline;
                themeCS.Faded = Themes.darkTheme.Faded;

                themeCS.Theme = ThemeTemplate.theme.Dark;

                //Accent Color Changer
                backgroundBrightnessSlider.Value = ColorTranslator.FromHtml(themeCS.Background).R;
                buttonBrightnessSlider.Value = ColorTranslator.FromHtml(themeCS.SecondBackground).R;
                outlineBrightnessSlider.Value = ColorTranslator.FromHtml(themeCS.Outline).R;
                textBrightnessSlider.Value = ColorTranslator.FromHtml(themeCS.Foreground).R;
                accentRedSlider.Value = ColorTranslator.FromHtml(themeCS.Accent).R;
                accentGreenSlider.Value = ColorTranslator.FromHtml(themeCS.Accent).G;
                accentBlueSlider.Value = ColorTranslator.FromHtml(themeCS.Accent).B;
            }

            if (presets[0])
                presetCS.p1 = themeCS.SecondBackground;
            if (presets[1])
                presetCS.p2 = themeCS.SecondBackground;
            if (presets[2])
                presetCS.p3 = themeCS.SecondBackground;
            if (presets[3])
                presetCS.p4 = themeCS.SecondBackground;
            if (presets[4])
                presetCS.p5 = themeCS.SecondBackground;
            if (presets[5])
                presetCS.p6 = themeCS.SecondBackground;
            if (presets[6])
                presetCS.p7 = themeCS.SecondBackground;
            if (presets[7])
                presetCS.p8 = themeCS.SecondBackground;

            backgroundBT.Text = backgroundBrightnessSlider.Value.ToString();
            accentRT.Text = accentRedSlider.Value.ToString();
            accentGT.Text = accentRedSlider.Value.ToString();
            accentBT.Text = accentRedSlider.Value.ToString();
            outlineOT.Text = outlineBrightnessSlider.Value.ToString();
            buttonBuT.Text = buttonBrightnessSlider.Value.ToString();
            foreBT.Text = textBrightnessSlider.Value.ToString();

            ColorManager.ChangeBackground();
            ColorManager.Settings();
            ColorManager.About();
            ColorManager.Cosmetics();
            ColorManager.Global();

            //Appearance Sliders
            int value = ColorTranslator.FromHtml(themeCS.Background).R;

            backgroundBrightnessSlider.Value = value;
            backgroundBT.Text = value.ToString();

            value = ColorTranslator.FromHtml(themeCS.Accent).R;
            accentRedSlider.Value = value;
            accentRT.Text = value.ToString();

            value = ColorTranslator.FromHtml(themeCS.Accent).G;
            accentGreenSlider.Value = value;
            accentGT.Text = value.ToString();

            value = ColorTranslator.FromHtml(themeCS.Accent).B;
            accentBlueSlider.Value = value;
            accentBT.Text = value.ToString();

            value = ColorTranslator.FromHtml(themeCS.Outline).R;
            outlineBrightnessSlider.Value = value;
            outlineOT.Text = value.ToString();

            value = ColorTranslator.FromHtml(themeCS.SecondBackground).R;
            buttonBrightnessSlider.Value = value;
            buttonBuT.Text = value.ToString();

            value = ColorTranslator.FromHtml(themeCS.Foreground).R;
            textBrightnessSlider.Value = value;
            foreBT.Text = value.ToString();
        }

        private void backgroundBrightnessSlider_Scroll(object sender, ScrollEventArgs e)
        {
            themeCS.Background = ColorTranslator.ToHtml(Color.FromArgb(backgroundBrightnessSlider.Value, backgroundBrightnessSlider.Value, backgroundBrightnessSlider.Value));
            backgroundBT.Text = backgroundBrightnessSlider.Value.ToString();

            ColorManager.Settings();
            ColorManager.Global();
        }

        private void accentRedSlider_Scroll(object sender, ScrollEventArgs e)
        {
            themeCS.Accent = ColorTranslator.ToHtml(Color.FromArgb(accentRedSlider.Value, accentGreenSlider.Value, accentBlueSlider.Value));
            accentRT.Text = accentRedSlider.Value.ToString();

            ColorManager.Settings();
            ColorManager.Global();
        }

        private void accentGreenSlider_Scroll(object sender, ScrollEventArgs e)
        {
            themeCS.Accent = ColorTranslator.ToHtml(Color.FromArgb(accentRedSlider.Value, accentGreenSlider.Value, accentBlueSlider.Value));
            accentGT.Text = accentGreenSlider.Value.ToString();

            ColorManager.Settings();
            ColorManager.Global();
        }

        private void accentBlueSlider_Scroll(object sender, ScrollEventArgs e)
        {

            themeCS.Accent = ColorTranslator.ToHtml(Color.FromArgb(accentRedSlider.Value, accentGreenSlider.Value, accentBlueSlider.Value));
            accentBT.Text = accentBlueSlider.Value.ToString();

            ColorManager.Settings();
            ColorManager.Global();
        }

        private void outlineBrightnessSlider_Scroll(object sender, ScrollEventArgs e)
        {

            themeCS.Outline = ColorTranslator.ToHtml(Color.FromArgb(outlineBrightnessSlider.Value, outlineBrightnessSlider.Value, outlineBrightnessSlider.Value));
            outlineOT.Text = outlineBrightnessSlider.Value.ToString();

            ColorManager.Settings();
            ColorManager.Global();

        }

        private void buttonBrightnessSlider_Scroll(object sender, ScrollEventArgs e)
        {
            bool[] presets = { false, false, false, false, false, false, false, false };
            if (preset1.BackColor == ColorTranslator.FromHtml(themeCS.SecondBackground))
                presets[0] = true;
            if (preset2.BackColor == ColorTranslator.FromHtml(themeCS.SecondBackground))
                presets[1] = true;
            if (preset3.BackColor == ColorTranslator.FromHtml(themeCS.SecondBackground))
                presets[2] = true;
            if (preset4.BackColor == ColorTranslator.FromHtml(themeCS.SecondBackground))
                presets[3] = true;
            if (preset5.BackColor == ColorTranslator.FromHtml(themeCS.SecondBackground))
                presets[4] = true;
            if (preset6.BackColor == ColorTranslator.FromHtml(themeCS.SecondBackground))
                presets[5] = true;
            if (preset7.BackColor == ColorTranslator.FromHtml(themeCS.SecondBackground))
                presets[6] = true;
            if (preset8.BackColor == ColorTranslator.FromHtml(themeCS.SecondBackground))
                presets[7] = true;

            themeCS.SecondBackground = ColorTranslator.ToHtml(Color.FromArgb(buttonBrightnessSlider.Value, buttonBrightnessSlider.Value, buttonBrightnessSlider.Value));

            if (presets[0])
                presetCS.p1 = themeCS.SecondBackground;
            if (presets[1])
                presetCS.p2 = themeCS.SecondBackground;
            if (presets[2])
                presetCS.p3 = themeCS.SecondBackground;
            if (presets[3])
                presetCS.p4 = themeCS.SecondBackground;
            if (presets[4])
                presetCS.p5 = themeCS.SecondBackground;
            if (presets[5])
                presetCS.p6 = themeCS.SecondBackground;
            if (presets[6])
                presetCS.p7 = themeCS.SecondBackground;
            if (presets[7])
                presetCS.p8 = themeCS.SecondBackground;

            buttonBuT.Text = buttonBrightnessSlider.Value.ToString();

            ColorManager.Settings();
            ColorManager.Global();
        }

        private void textBrightnessSlider_Scroll(object sender, ScrollEventArgs e)
        {
            themeCS.Foreground = ColorTranslator.ToHtml(Color.FromArgb(textBrightnessSlider.Value, textBrightnessSlider.Value, textBrightnessSlider.Value));
            foreBT.Text = textBrightnessSlider.Value.ToString();

            ColorManager.Settings();
            ColorManager.Global();
        }

        #region Presets

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
                Notif.Toast("Presets", "There was an error saving!");
            }
            else
            {
                ConfigManager.GetPresetColors();

                if (Convert.ToInt32(_panel.Name.Substring(6)) == 1)
                    presetCS.p1 = themeCS.Accent;

                if (Convert.ToInt32(_panel.Name.Substring(6)) == 2)
                    presetCS.p2 = themeCS.Accent;

                if (Convert.ToInt32(_panel.Name.Substring(6)) == 3)
                    presetCS.p3 = themeCS.Accent;

                if (Convert.ToInt32(_panel.Name.Substring(6)) == 4)
                    presetCS.p4 = themeCS.Accent;

                if (Convert.ToInt32(_panel.Name.Substring(6)) == 5)
                    presetCS.p5 = themeCS.Accent;

                if (Convert.ToInt32(_panel.Name.Substring(6)) == 6)
                    presetCS.p6 = themeCS.Accent;

                if (Convert.ToInt32(_panel.Name.Substring(6)) == 7)
                    presetCS.p7 = themeCS.Accent;

                if (Convert.ToInt32(_panel.Name.Substring(6)) == 8)
                    presetCS.p8 = themeCS.Accent;

                _panel.BackColor = ColorTranslator.FromHtml(themeCS.Accent);

                ConfigManager.WriteConfig(@"C:\temp\VentileClient\Presets\" + _hoveredPreset + ".json");
                ConfigManager.WriteTheme(@"C:\temp\VentileClient\Presets\" + _hoveredPreset + "Theme.json");
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_hoveredPreset == null)
            {
                Notif.Toast("Presets", "There was an error loading!");
            }
            else
            {
                if (File.Exists(@"C:\temp\VentileClient\Presets\" + _hoveredPreset + ".json") && File.Exists(@"C:\temp\VentileClient\Presets\" + _hoveredPreset + "Theme.json"))
                {
                    bool[] presets = { false, false, false, false, false, false, false, false };
                    if (preset1.BackColor == ColorTranslator.FromHtml(themeCS.SecondBackground))
                        presets[0] = true;
                    if (preset2.BackColor == ColorTranslator.FromHtml(themeCS.SecondBackground))
                        presets[1] = true;
                    if (preset3.BackColor == ColorTranslator.FromHtml(themeCS.SecondBackground))
                        presets[2] = true;
                    if (preset4.BackColor == ColorTranslator.FromHtml(themeCS.SecondBackground))
                        presets[3] = true;
                    if (preset5.BackColor == ColorTranslator.FromHtml(themeCS.SecondBackground))
                        presets[4] = true;
                    if (preset6.BackColor == ColorTranslator.FromHtml(themeCS.SecondBackground))
                        presets[5] = true;
                    if (preset7.BackColor == ColorTranslator.FromHtml(themeCS.SecondBackground))
                        presets[6] = true;
                    if (preset8.BackColor == ColorTranslator.FromHtml(themeCS.SecondBackground))
                        presets[7] = true;

                    ConfigManager.ReadConfig(@"C:\temp\VentileClient\Presets\" + _hoveredPreset + ".json");
                    ConfigManager.ReadTheme(@"C:\temp\VentileClient\Presets\" + _hoveredPreset + "Theme.json");
                    ConfigManager.WriteConfig();
                    ConfigManager.WriteTheme();

                    if (presets[0])
                        presetCS.p1 = themeCS.SecondBackground;
                    if (presets[1])
                        presetCS.p2 = themeCS.SecondBackground;
                    if (presets[2])
                        presetCS.p3 = themeCS.SecondBackground;
                    if (presets[3])
                        presetCS.p4 = themeCS.SecondBackground;
                    if (presets[4])
                        presetCS.p5 = themeCS.SecondBackground;
                    if (presets[5])
                        presetCS.p6 = themeCS.SecondBackground;
                    if (presets[6])
                        presetCS.p7 = themeCS.SecondBackground;
                    if (presets[7])
                        presetCS.p8 = themeCS.SecondBackground;

                    ColorManager.Global();
                    ColorManager.Home();
                    ColorManager.Cosmetics();
                    ColorManager.Version();
                    ColorManager.Settings();
                    ColorManager.About();
                    ColorManager.ChangeBackground();

                    DataManager.Home();
                    DataManager.Settings();

                }
                else
                {
                    Notif.Toast("Presets", "Preset not found!");
                    ConfigManager.GetPresetColors(@"C:\temp\VentileClient\Presets\");

                    _panel.BackColor = ColorTranslator.FromHtml(themeCS.SecondBackground);


                    if (Convert.ToInt32(_panel.Name.Substring(6)) == 1)
                        presetCS.p1 = themeCS.SecondBackground;

                    if (Convert.ToInt32(_panel.Name.Substring(6)) == 2)
                        presetCS.p2 = themeCS.SecondBackground;

                    if (Convert.ToInt32(_panel.Name.Substring(6)) == 3)
                        presetCS.p3 = themeCS.SecondBackground;

                    if (Convert.ToInt32(_panel.Name.Substring(6)) == 4)
                        presetCS.p4 = themeCS.SecondBackground;

                    if (Convert.ToInt32(_panel.Name.Substring(6)) == 5)
                        presetCS.p5 = themeCS.SecondBackground;

                    if (Convert.ToInt32(_panel.Name.Substring(6)) == 6)
                        presetCS.p6 = themeCS.SecondBackground;

                    if (Convert.ToInt32(_panel.Name.Substring(6)) == 7)
                        presetCS.p7 = themeCS.SecondBackground;

                    if (Convert.ToInt32(_panel.Name.Substring(6)) == 8)
                        presetCS.p8 = themeCS.SecondBackground;
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
                ConfigManager.GetPresetColors();

                _panel.BackColor = ColorTranslator.FromHtml(themeCS.SecondBackground);


                if (Convert.ToInt32(_panel.Name.Substring(6)) == 1)
                    presetCS.p1 = themeCS.SecondBackground;

                if (Convert.ToInt32(_panel.Name.Substring(6)) == 2)
                    presetCS.p2 = themeCS.SecondBackground;

                if (Convert.ToInt32(_panel.Name.Substring(6)) == 3)
                    presetCS.p3 = themeCS.SecondBackground;

                if (Convert.ToInt32(_panel.Name.Substring(6)) == 4)
                    presetCS.p4 = themeCS.SecondBackground;

                if (Convert.ToInt32(_panel.Name.Substring(6)) == 5)
                    presetCS.p5 = themeCS.SecondBackground;

                if (Convert.ToInt32(_panel.Name.Substring(6)) == 6)
                    presetCS.p6 = themeCS.SecondBackground;

                if (Convert.ToInt32(_panel.Name.Substring(6)) == 7)
                    presetCS.p7 = themeCS.SecondBackground;

                if (Convert.ToInt32(_panel.Name.Substring(6)) == 8)
                    presetCS.p8 = themeCS.SecondBackground;
            }
            else
            {
                Notif.Toast("Presets", "This preset doesn't exist!");
                ConfigManager.GetPresetColors();

                _panel.BackColor = ColorTranslator.FromHtml(themeCS.SecondBackground);


                if (Convert.ToInt32(_panel.Name.Substring(6)) == 1)
                    presetCS.p1 = themeCS.SecondBackground;

                if (Convert.ToInt32(_panel.Name.Substring(6)) == 2)
                    presetCS.p2 = themeCS.SecondBackground;

                if (Convert.ToInt32(_panel.Name.Substring(6)) == 3)
                    presetCS.p3 = themeCS.SecondBackground;

                if (Convert.ToInt32(_panel.Name.Substring(6)) == 4)
                    presetCS.p4 = themeCS.SecondBackground;

                if (Convert.ToInt32(_panel.Name.Substring(6)) == 5)
                    presetCS.p5 = themeCS.SecondBackground;

                if (Convert.ToInt32(_panel.Name.Substring(6)) == 6)
                    presetCS.p6 = themeCS.SecondBackground;

                if (Convert.ToInt32(_panel.Name.Substring(6)) == 7)
                    presetCS.p7 = themeCS.SecondBackground;

                if (Convert.ToInt32(_panel.Name.Substring(6)) == 8)
                    presetCS.p8 = themeCS.SecondBackground;
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
                            presetCS.p1 = them.Accent;

                        if (Convert.ToInt32(_panel.Name.Substring(6)) == 2)
                            presetCS.p2 = them.Accent;

                        if (Convert.ToInt32(_panel.Name.Substring(6)) == 3)
                            presetCS.p3 = them.Accent;

                        if (Convert.ToInt32(_panel.Name.Substring(6)) == 4)
                            presetCS.p4 = them.Accent;

                        if (Convert.ToInt32(_panel.Name.Substring(6)) == 5)
                            presetCS.p5 = them.Accent;

                        if (Convert.ToInt32(_panel.Name.Substring(6)) == 6)
                            presetCS.p6 = them.Accent;

                        if (Convert.ToInt32(_panel.Name.Substring(6)) == 7)
                            presetCS.p7 = them.Accent;

                        if (Convert.ToInt32(_panel.Name.Substring(6)) == 8)
                            presetCS.p8 = them.Accent;

                        Notif.Toast("Preset", "Preset Sucessfully Imported!");

                        ColorManager.Global();
                        ColorManager.Home();
                        ColorManager.Cosmetics();
                        ColorManager.Version();
                        ColorManager.Settings();
                        ColorManager.About();

                        DataManager.Home();
                        DataManager.Settings();
                    }
                    catch
                    {
                        Notif.Toast("Error", "There was an error :(");
                        return;
                    }
                }
                else
                {
                    Notif.Toast("File Dialog", "The file you selected caused an error!");
                    return;
                }
            }
            else
            {
                Notif.Toast("File Dialog", "The file you selected caused an error!");
                return;
            }
        }

        private async void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Copy to clipboard maybe?
            Directory.CreateDirectory(@"C:\temp\VentileClient\SHARE");
            ConfigManager.WriteConfig(@"C:\temp\VentileClient\SHARE\Config.json");
            ConfigManager.WriteTheme(@"C:\temp\VentileClient\SHARE\Theme.json");
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

            if (!configCS.PerformanceMode)
            {
                p.BackColor = ColorTranslator.FromHtml(themeCS.Background);
                p.Size = new Size(settingsTab.Width, settingsPagesTabControl.Height);
                p.Location = new Point(165, 110);
                this.Controls.Add(p);
                p.BringToFront();
                sidebar.BringToFront();
                /*p.Visible = false;
                FadeEffectBetweenPages.ShowSync(p);*/
            }

            settingsPagesTabControl.SelectedTab = Appearance;
            this.Refresh();

            if (!configCS.PerformanceMode)
            {
                p.Visible = true;
                FadeEffectBetweenPages.HideSync(p);
                this.Controls.Remove(p);
            }
            this.Refresh();
        }

        private void toastsToggle_Click(object sender, EventArgs e)
        {
            if (configCS.Toasts == 0)
            {
                configCS.Toasts = 1;
                toastsToggle.Checked = true;
                toastsToggle.Text = "Ventile Toast";
                toastsSelector.Visible = true;
            }
            else if (configCS.Toasts == 1)
            {
                configCS.Toasts = 2;
                toastsToggle.Checked = true;
                toastsToggle.Text = "Windows Toast";
                toastsSelector.Visible = false;
            }
            else
            {
                configCS.Toasts = 0;
                toastsToggle.Checked = false;
                toastsToggle.Text = "Off";
                toastsSelector.Visible = false;
            }
        }

        private void toastsSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (toastsSelector.SelectedIndex == 0) //Top Right
                configCS.ToastsLoc = "topRight";
            else if (toastsSelector.SelectedIndex == 1) //Bottom Right
                configCS.ToastsLoc = "bottomRight";
            else if (toastsSelector.SelectedIndex == 2) //Top Left
                configCS.ToastsLoc = "topLeft";
            else if (toastsSelector.SelectedIndex == 3) //Bottom Left
                configCS.ToastsLoc = "bottomLeft";
        }

        private void performanceModeToggle_Click(object sender, EventArgs e)
        {
            Notif.Toast("Hello", "Epico");
            configCS.PerformanceMode = !configCS.PerformanceMode;
            performanceModeToggle.Checked = configCS.PerformanceMode;
            performanceModeToggle.Animated = configCS.PerformanceMode;

            if (configCS.PerformanceMode)
                performanceModeToggle.Text = "On";
            else
                performanceModeToggle.Text = "Off";

            ColorManager.Settings();
            ColorManager.Global();
        }

        private void packProfileButtonOpen_Click(object sender, EventArgs e)
        {
            var p = new Guna2Panel();

            if (!configCS.PerformanceMode)
            {
                p.BackColor = ColorTranslator.FromHtml(themeCS.Background);
                p.Size = new Size(settingsTab.Width, settingsPagesTabControl.Height);
                p.Location = new Point(165, 110);
                this.Controls.Add(p);
                p.BringToFront();
                sidebar.BringToFront();
                /*p.Visible = false;
                FadeEffectBetweenPages.ShowSync(p);*/
            }

            settingsPagesTabControl.SelectedTab = PackProfiles;
            this.Refresh();

            if (!configCS.PerformanceMode)
            {
                p.Visible = true;
                FadeEffectBetweenPages.HideSync(p);
                this.Controls.Remove(p);
            }
            this.Refresh();
        }

        private void exitPackProfilesButton_Click(object sender, EventArgs e)
        {
            var p = new Guna2Panel();

            if (!configCS.PerformanceMode)
            {
                p.BackColor = ColorTranslator.FromHtml(themeCS.Background);
                p.Size = new Size(settingsTab.Width, settingsPagesTabControl.Height);
                p.Location = new Point(165, 110);
                this.Controls.Add(p);
                p.BringToFront();
                sidebar.BringToFront();
                /*p.Visible = false;
                FadeEffectBetweenPages.ShowSync(p);*/
            }

            settingsPagesTabControl.SelectedTab = Extras;
            this.Refresh();

            if (!configCS.PerformanceMode)
            {
                p.Visible = true;
                FadeEffectBetweenPages.HideSync(p);
                this.Controls.Remove(p);
            }
            this.Refresh();
        }

        // Timers
        private void TimersButton_Click(object sender, EventArgs e)
        {
            var p = new Guna2Panel();

            if (!configCS.PerformanceMode)
            {
                p.BackColor = ColorTranslator.FromHtml(themeCS.Background);
                p.Size = new Size(settingsTab.Width, settingsPagesTabControl.Height);
                p.Location = new Point(165, 110);
                this.Controls.Add(p);
                p.BringToFront();
                sidebar.BringToFront();
                /*p.Visible = false;
                FadeEffectBetweenPages.ShowSync(p);*/
            }

            settingsPagesTabControl.SelectedTab = Alarms;
            this.Refresh();

            if (!configCS.PerformanceMode)
            {
                p.Visible = true;
                FadeEffectBetweenPages.HideSync(p);
                this.Controls.Remove(p);
            }
            this.Refresh();
        }

        #endregion

        #endregion

        #region About        

        private void website_Click(object sender, EventArgs e)
        {
            Process.Start(link_settings.websiteLink);
        }

        private void discord_Click(object sender, EventArgs e)
        {
            Process.Start(link_settings.discordInvite);
        }

        private void changeLogLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // New changelog window
            if ((ChangelogPrompt)System.Windows.Forms.Application.OpenForms["ChangelogPrompt"] != null) return;
            _currentChangelog = new ChangelogPrompt(themeCS, ventile_settings.changelog);
            _currentChangelog.Show();
        }

        private void helpButton_Click(object sender, EventArgs e)
        {
            // New changelog window
            if ((HelpPrompt)System.Windows.Forms.Application.OpenForms["HelpPrompt"] != null) return;
            _currentHelp = new HelpPrompt(themeCS, ventile_settings.help);
            _currentHelp.Show();
        }




        #endregion

        #endregion

        private void packProfilesScrollbar_Scroll(object sender, ScrollEventArgs e)
        {
            packProfilesList.AutoScrollPosition = new Point(0, packProfileScrollBar.Value);
        }

        private void alarmsScrollbar_Scroll(object sender, ScrollEventArgs e)
        {
            alarmsList.AutoScrollPosition = new Point(0, packProfileScrollBar.Value);
        }

        private void saveProfileButton_Click(object s, EventArgs e)
        {
            string profileName = profileNameTextbox.Text.Trim();
            if (profileName == string.Empty || profileName == null) return;
            Guna2Button sender = (Guna2Button)s;
            ProfileInfo info = sender.Tag as ProfileInfo; // Gets information about the selected profile | If null, it means wants to create a new profile

            if (info == null) // Create new profile
            {
                bool isOverwrite = false;
                if (Directory.Exists(Path.Combine(@"C:\temp\VentileClient\Profiles", profileName))) isOverwrite = true;

                Task.Run(async () =>
                {
                    await MCDataManager.SaveProfile(profileName, isOverwrite);
                    Invoke(new Action(() =>
                    {
                        deleteProfileButton.Enabled = true;
                        loadProfileButton.Enabled = true;
                    }));
                });

            }
            else // Update existing profile
            {
                DataManager.UpdateProfile(info.Name, NewName: profileName);
            }
        }

        private async void deleteProfileButton_Click(object s, EventArgs e)
        {
            Guna2Button sender = (Guna2Button)s;

            deleteProfileButton.Enabled = false;
            loadProfileButton.Enabled = false;

            ProfileInfo info = sender.Tag as ProfileInfo;

            await MCDataManager.DeleteProfile(info.Name);
        }

        private async void loadProfileButton_Click(object sender, EventArgs e)
        {
            await MCDataManager.ImportProfile(profileNameTextbox.Text);
        }

        private void profileIconPictureBox_MouseClick(object s, MouseEventArgs e)
        {

            Guna2PictureBox sender = (Guna2PictureBox)s;
            ProfileInfo info = (ProfileInfo)sender.Tag;

            if (info == null) return;

            if (e.Button == MouseButtons.Right)
            {

                info.Image = new Bitmap(Properties.Resources.GrassBlock);

                using (Bitmap btmp = (Bitmap)info.Image.Clone())
                {
                    btmp.Save(Path.Combine(info.FullDirPath, "profileLogo.png"), ImageFormat.Png);
                }


                DataManager.UpdateProfile(info.Name, info.Image);
                return;

            }

            var customImg = new OpenFileDialog()
            {
                Title = "Profile Image",
                Filter = "Image Files (*.bmp;*.jpg;*.jpeg;*.png)|*.BMP;*.JPG;*.JPEG;*.PNG"
            };


            if (customImg.ShowDialog() == DialogResult.OK)
            {
                info.Image = new Bitmap(customImg.FileName);

                using (Bitmap btmp = (Bitmap)info.Image.Clone())
                {
                    btmp.Save(Path.Combine(info.FullDirPath, "profileLogo.png"), ImageFormat.Png);
                }

                DataManager.UpdateProfile(info.Name, info.Image);
            }
            else
            {
                Notif.Toast("Error", "There was an error selecting image.");
            }
        }

        private void packProfilesList_Click(object sender, EventArgs e) // Clicking the background deselects as well
        {
            foreach (Control profileBtn in packProfilesList.Controls)
            {
                if (profileBtn.GetType() == typeof(Guna2Button))
                    ((Guna2Button)profileBtn).Checked = false;
            }

            deleteProfileButton.Enabled = false;
            loadProfileButton.Enabled = false;

            profileIconPictureBox.Tag = null;
            profileNameTextbox.Tag = null;
            saveProfileButton.Tag = null;
            saveProfileButton.Tag = null;
            deleteProfileButton.Tag = null;

            profileNameLabel.Text = "Profile Name";
            profileNameTextbox.Text = null;
            profileIconPictureBox.Image = null;
        }

        private void profileNameTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Delete && !Char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar)) // Only allows backspace, space, letters and numbers (no `~!@#$%^&*()-=_+1234567890[]\{}|;':",./<>?)
                e.Handled = true;

            if (packProfilesList.Controls?.Count > 1) // One because of title
            {
                Guna2Button ctrlInf = packProfilesList.Controls[1] as Guna2Button;
                Size size = TextRenderer.MeasureText(profileNameTextbox.Text, ctrlInf.Font);
                if (size.Width > ctrlInf.Width - (ctrlInf.ImageSize.Width + (ctrlInf.Margin.Right * 3)) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Delete && !Char.IsControl(e.KeyChar)) e.Handled = true;
            }
        }

        private void RPCTextbox_TextChanged(object sender, EventArgs e)
        {
            configCS.RpcText = RPCTextbox.Text;
        }

        private void RPCButtonTextbox_TextChanged(object sender, EventArgs e)
        {
            configCS.RpcButtonText = RPCButtonTextbox.Text;
        }

        private void RPCButtonLinkTextbox_TextChanged(object sender, EventArgs e)
        {
            configCS.RpcButtonLink = RPCButtonLinkTextbox.Text;

        }

        private void saveAlarm_Click(object s, EventArgs e)
        {
            string alarmName = alarmNameTextbox.Text.Trim();
            if (alarmName == string.Empty || alarmName == null) return;
            Guna2Button sender = (Guna2Button)s;
            Alarm info = sender.Tag as Alarm; // Gets information about the selected profile | If null, it means wants to create a new profile

            if (info == null) // Create new profile
            {
                string message = alarmMessageTextbox.Text;
                if (message == null || message == string.Empty) message = "Alarm Finished!";
                DataManager.AddAlarm(alarmNameTextbox.Text, message, (int)alarmHoursSelector.Value, (int)alarmMinutesSelector.Value, alarmRepeatedToggle.Checked, AmPmToggle.Checked);
            }
            else // Update existing profile
            {
                DataManager.UpdateAlarm(info.ID, (int)alarmHoursSelector.Value, (int)alarmMinutesSelector.Value, alarmRepeatedToggle.Checked, AmPmToggle.Checked, alarmNameTextbox.Text, alarmMessageTextbox.Text);
            }
        }

        private void deleteAlarm_Click(object s, EventArgs e)
        {
            Guna2Button sender = (Guna2Button)s;

            Alarm alarm = sender.Tag as Alarm;

            alarm.Delete();
        }

        private void alarmsList_Click(object sender, EventArgs e)
        {
            foreach (Control alarmBtn in alarmsList.Controls)
            {
                if (alarmBtn.GetType() == typeof(Guna2Button))
                    ((Guna2Button)alarmBtn).Checked = false;
            }

            saveAlarm.Tag = null;
            deleteAlarm.Tag = null;

            alarmNameLabel.Tag = null;
            alarmMinutesSelector.Tag = null;
            alarmHoursSelector.Tag = null;
            alarmRepeatedToggle.Tag = null;
            AmPmToggle.Tag = null;

            alarmNameLabel.Text = "Name";
            DateTime currentTime = DateTime.Now;
            alarmHoursSelector.Value = currentTime.Hour > 12 ? currentTime.Hour - 12 : currentTime.Hour;
            alarmMinutesSelector.Value = currentTime.Minute;
            alarmRepeatedToggle.Checked = false;
            AmPmToggle.Checked = currentTime.ToString("tt", CultureInfo.InvariantCulture).ToLower() == "pm";

            alarmNameTextbox.Text = null;
            alarmMessageTextbox.Text = null;
        }

        private void alarmsTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                foreach (Alarm alarm in configCS.Alarms)
                    alarm.TestTrigger();
            }
            catch (Exception err) { aLogger.Log(err); };
        }
    }

    #region Small Classes

    public class VentileSettings
    {
        public Version launcherVersion;
        public Version clientVersion;
        public Version cosmeticsVersion;
        public bool isBeta;

        public string rpcID;

        public string[] changelog;
        public string[] help;
    }

    public class LinkSettings
    {
        public string repoOwner;
        public string downloadRepo;
        public string versionsRepo;

        public string websiteLink;
        public string discordInvite;
        public string githubProductHeader;

        public string githubToken;
    }

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

    #endregion
}