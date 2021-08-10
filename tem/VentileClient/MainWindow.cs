using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;

using System.IO;
using System.IO.Compression;

using System.Net;
using Guna.UI2.WinForms;

using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;

using VentileClient.JSON_Template_Classes;
using Newtonsoft.Json;
using System.ComponentModel;

namespace VentileClient
{
    public partial class MainWindow : Form
    {




        /*                                                  >>>>>>>>>>>>>>>> REMEMBER TO CHANGE ISBETA IN PROPERTIES BEFORE RELEASE <<<<<<<<<<<<<<<<                                                  */






        // Importing Public Functions from RPC.cs
        private readonly RPC drpc = new RPC();

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

        #region Extra Functions

        #region Download
        public void download(string link, string path, string name)
        {
            Task.Run(() =>
            {
                using (WebClient Client = new WebClient())
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
            });
        }
        #endregion

        #region InternetCheck
        [System.Runtime.InteropServices.DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);

        public static bool OnlineCheck()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://github.com/");
            request.Timeout = 15000;
            request.Method = "HEAD";
            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
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
            int desc;
            bool internetcheckone = InternetGetConnectedState(out desc, 0);
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

        #region Stream Read/Write

        ConfigTemplate configCS = new ConfigTemplate();
        CosmeticsTemplate cosmeticsCS = new CosmeticsTemplate();
        ThemeTemplate themeCS = new ThemeTemplate();
        PresetColorsTemplate presetCS = new PresetColorsTemplate();

        private void readPresetColors(string path)
        {
            try
            {
                string temp = File.ReadAllText(path);
                presetCS = JsonConvert.DeserializeObject<PresetColorsTemplate>(temp);
            }
            catch
            {
                this.Toast("Error", "There was an error :(");
            }
        }

        private async void writePresetColors(string path)
        {
            await Task.Run(() =>
            {
                try
                {
                    PresetColorsTemplate temp = new PresetColorsTemplate()
                    {
                        p1 = presetCS.p1,
                        p2 = presetCS.p2,
                        p3 = presetCS.p3,
                        p4 = presetCS.p4,
                        p5 = presetCS.p5,
                        p6 = presetCS.p6,
                        p7 = presetCS.p7,
                        p8 = presetCS.p8,
                    };

                    string json = JsonConvert.SerializeObject(temp, Formatting.Indented);
                    File.WriteAllText(path, json);
                }
                catch
                {
                    this.Toast("Error", "There was an error :(");
                }
            });
        }

        private void readConfig(string path)
        {
            try
            {
                string temp = File.ReadAllText(path);
                configCS = JsonConvert.DeserializeObject<ConfigTemplate>(temp);
            }
            catch
            {
                this.Toast("Error", "There was an error :(");
            }
        }

        private async void writeConfig(string path)
        {
            await Task.Run(() =>
            {
                try
                {
                    ConfigTemplate temp = new ConfigTemplate()
                    {
                        WindowState = configCS.WindowState,
                        AutoInject = configCS.AutoInject,
                        RichPresence = configCS.RichPresence,
                        RpcText = configCS.RpcText,
                        RpcButton = configCS.RpcButton,
                        RpcButtonLink = configCS.RpcButtonLink,
                        RpcButtonText = configCS.RpcButtonText,
                        CustomDLL = configCS.CustomDLL,
                        DefaultDLL = configCS.DefaultDLL,
                        ResourcePackLoc = configCS.ResourcePackLoc,
                        BackgroundImage = configCS.BackgroundImage,
                        BackgroundImageLoc = configCS.BackgroundImageLoc,
                        Toasts = configCS.Toasts,
                        ToastsLoc = configCS.ToastsLoc,
                        RoundedButtons = configCS.RoundedButtons

                    };

                    string json = JsonConvert.SerializeObject(temp, Formatting.Indented);
                    File.WriteAllText(path, json);
                }
                catch
                {
                    this.Toast("Error", "There was an error :(");
                }
            });
        }

        private void readTheme(string path)
        {
            try
            {
                string temp = File.ReadAllText(path);
                themeCS = JsonConvert.DeserializeObject<ThemeTemplate>(temp);
            }
            catch
            {
                this.Toast("Error", "There was an error :(");
            }
        }

        private async void writeTheme(string path)
        {
            await Task.Run(() =>
            {
                try
                {
                    ThemeTemplate temp = new ThemeTemplate()
                    {
                        Theme = themeCS.Theme,
                        Background = themeCS.Background,
                        SecondBackground = themeCS.SecondBackground,
                        Foreground = themeCS.Foreground,
                        Accent = themeCS.Accent,
                        Outline = themeCS.Outline,
                        Faded = themeCS.Faded
                    };

                    string json = JsonConvert.SerializeObject(temp, Formatting.Indented);
                    File.WriteAllText(path, json);
                }
                catch
                {
                    this.Toast("Error", "There was an error :(");
                }
            });
        }

        private void readCosmetics(string path)
        {
            try
            {
                string temp = File.ReadAllText(path);
                cosmeticsCS = JsonConvert.DeserializeObject<CosmeticsTemplate>(temp);
            }
            catch
            {
                this.Toast("Error", "There was an error :(");
            }
        }

        private async void writeCosmetics(string path)
        {
            await Task.Run(() =>
            {
                try
                {
                    CosmeticsTemplate temp = new CosmeticsTemplate()
                    {
                        cBlack = cosmeticsCS.cBlack,
                        cWhite = cosmeticsCS.cWhite,
                        cPink = cosmeticsCS.cPink,
                        cBlue = cosmeticsCS.cBlue,
                        cYellow = cosmeticsCS.cYellow,
                        cRick = cosmeticsCS.cRick,

                        mBlack = cosmeticsCS.mBlack,
                        mWhite = cosmeticsCS.mWhite,
                        mPink = cosmeticsCS.mPink,
                        mBlue = cosmeticsCS.mBlue,
                        mYellow = cosmeticsCS.mYellow,
                        mRick = cosmeticsCS.mRick,

                        aGlowing = cosmeticsCS.aGlowing,
                        aSlide = cosmeticsCS.aSlide,

                        oWavy = cosmeticsCS.oWavy,
                        oKagune = cosmeticsCS.oKagune,
                    };

                    string json = JsonConvert.SerializeObject(temp, Formatting.Indented);
                    File.WriteAllText(path, json);
                }
                catch
                {
                    this.Toast("Error", "There was an error :(");
                }
            });
        }
        #endregion

        #region Toasts
        public void Toast(string title, string msg)
        {
            Toast toast = new Toast();
            toast.showToast(title, msg, configCS, themeCS);
        }
        #endregion

        #endregion

        public static MainWindow instance;

        public MainWindow()
        {
            instance = this;

            InitializeComponent();
            // Round the form window
            this.FormBorderStyle = FormBorderStyle.None;
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            UpdateCheck updateCheck = new UpdateCheck();
            updateCheck.CheckForUpdate();

        }

        public bool internet;
        private void MainWindow_Load(object sender, EventArgs e)
        {
            readConfig(@"C:\temp\VentileClient\Presets\Config.json");
            readTheme(@"C:\temp\VentileClient\Presets\Theme.json");
            readCosmetics(@"C:\temp\VentileClient\Presets\Cosmetics.json");
            readPresetColors(@"C:\temp\VentileClient\Presets\PresetColors.json");

            InitHome();
            ChangeGlobalColors();
            ChangeHomeColors();
            ChangeBackground();
            InitCosmetics();
            InitSettings();
            InitAbout();

            version.Text = Properties.Ventile.Default.Version;

            internet = OnlineCheck();
        }

        class VersionSorter : IComparer<Version>
        {
            public int Compare(Version x, Version y)
            {

                if (x == null || y == null)
                {
                    return 0;
                }

                // "CompareTo()" method
                return x.CompareTo(y);

            }
        }

        Guna2Panel versionsPanel = new Guna2Panel();
        private void InitHome()
        {
            //Colors
            // Make the color variable smaller
            Color backColor = ColorTranslator.FromHtml(themeCS.Background);
            Color accentColor = ColorTranslator.FromHtml(themeCS.Accent);
            Color foreColor = ColorTranslator.FromHtml(themeCS.Foreground);
            Color outlineColor = ColorTranslator.FromHtml(themeCS.Outline);
            Color fadedColor = ColorTranslator.FromHtml(themeCS.Faded);
            Color backColor2 = ColorTranslator.FromHtml(themeCS.SecondBackground);

            //Create downloading buttons and crap with page and stuff ykyk
            //Settings
            int progressWidth = 400;
            int buttonWidth = 150;
            int spacing = 30;
            int topOffset = 15;
            int rightOffset = 16;


            
            versionsPanel.Size = new Size(644 + rightOffset, 465);
            versionsPanel.Location = new Point(0, 0);
            versionsPanel.Name = "versionsPanel";
            homeTab.Controls.Add(versionsPanel);
            versionsPanel.BringToFront();
            versionsPanel.AutoScroll = true;
            //panel.Visible = false;

            
            List<Version> versions = new List<Version>();


            string[] versionArray = { "1.16.40.2", "1.16.100.4", "1.16.200.2", "1.16.201.2", "1.16.210.5", "1.16.220.2", "1.16.221.1", "1.17.0.2", "1.17.2.1", "1.17.10.4" };
            foreach (string versionName in versionArray)
            {
                Version v = new Version(versionName);
                versions.Add(v);
            }
            VersionSorter vs = new VersionSorter();
            versions.Sort(vs);
            int index = 0;
            for (int i = versions.Count - 1; i > -1; i--)
            {
                index++;

                Label versionName = new Label();
                versionName.Name = "versionLabel" + i.ToString();
                versionName.Text = versions[i].ToString();
                versionName.Tag = versions[i].ToString();
                versionName.Font = new Font("Segoe UI", 14.25f);
                versionName.Location = new Point(9, (versionName.Height + spacing) * index + topOffset);
                versionName.AutoSize = true;

                Guna2ProgressBar bar = new Guna2ProgressBar();
                bar.Name = "bar" + i.ToString();
                bar.UseTransparentBackground = true;
                bar.Tag = "bar|" + versionName.Tag;
                bar.Height = versionName.Height - 5;
                bar.Width = progressWidth;
                bar.ForeColor = foreColor;
                bar.FillColor = backColor2;
                bar.ProgressBrushMode = Guna.UI2.WinForms.Enums.BrushMode.Gradient;
                bar.ProgressColor = accentColor;
                int r = 0;
                int g = 0;
                int b = 0;

                if (accentColor.R - 20 > 0)
                    r = accentColor.R - 20;
                else if (accentColor.R + 20 < 255)
                    r = accentColor.R + 20;

                if (accentColor.G - 20 > 0)
                    g = accentColor.G - 20;
                else if (accentColor.G + 20 < 255)
                    g = accentColor.G + 20;

                if (accentColor.B - 20 > 0)
                    b = accentColor.B - 20;
                else if (accentColor.B + 20 < 255)
                    b = accentColor.B + 20;

                bar.ProgressColor2 = Color.FromArgb(r, g, b);
                bar.Location = new Point(versionName.Location.X + 15, versionName.Location.Y + 30);
                bar.Visible = false;
                bar.TabStop = false;
                Guna2ProgressBar.CheckForIllegalCrossThreadCalls = false;

                Guna2Button download = new Guna2Button();
                download.Click += new EventHandler(DownloadVersion_Clicked);
                download.Name = "button" + i.ToString();
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
                download.Location = new Point(versionsPanel.Width - download.Width - (30 + rightOffset), versionName.Location.Y);
                download.UseTransparentBackground = true;
                download.Animated = true;
                download.TabStop = false;
                Guna2Button.CheckForIllegalCrossThreadCalls = false;

                Guna2Button select = new Guna2Button();
                select.Click += new EventHandler(SelectVersion_Clicked);
                select.Name = "button" + i.ToString();
                select.Text = "Select";
                select.Tag = "select|" + versionName.Tag;
                select.Font = new Font("Segoe UI", 14.25f, FontStyle.Bold);
                select.Width = buttonWidth;
                select.Height = versionName.Height + 10;
                select.ForeColor = foreColor;
                select.FillColor = backColor2;
                select.CheckedState.FillColor = accentColor;
                select.Checked = false;
                select.Location = new Point(versionsPanel.Width - select.Width - (30 + rightOffset), versionName.Location.Y);
                select.UseTransparentBackground = true;
                select.Animated = true;
                select.TabStop = false;
                select.Visible = false;

                Guna2Button uninstall = new Guna2Button();
                uninstall.Click += new EventHandler(UninstallVersion_Clicked);
                uninstall.Name = "button" + i.ToString();
                uninstall.Text = "Uninstall";
                uninstall.Tag = "uninstall|" + versionName.Tag;
                uninstall.Font = new Font("Segoe UI", 14.25f, FontStyle.Bold);
                uninstall.Width = buttonWidth;
                uninstall.Height = versionName.Height + 10;
                uninstall.ForeColor = foreColor;
                uninstall.FillColor = backColor2;
                uninstall.CheckedState.FillColor = accentColor;
                uninstall.Checked = false;
                uninstall.Location = new Point(versionsPanel.Width - uninstall.Width*2 - (40 + rightOffset), versionName.Location.Y);
                uninstall.UseTransparentBackground = true;
                uninstall.Animated = true;
                uninstall.TabStop = false;
                uninstall.Visible = false;

                versionsPanel.Controls.Add(download);
                versionsPanel.Controls.Add(select);
                versionsPanel.Controls.Add(uninstall);
                versionsPanel.Controls.Add(versionName);
                versionsPanel.Controls.Add(bar);
            }
            versionsPanel.Size = new Size(versionsPanel.Width, versionsPanel.Height + topOffset * 2);

            Label label = new Label();
            label.AutoSize = true;
            label.Text = "Version Selector";
            label.Font = new Font("Segoe UI", 20.25f, FontStyle.Bold);
            label.Location = new Point(5, 14);
            label.BringToFront();
            versionsPanel.Controls.Add(label);

            RefreshVersionList(versions);
        }

        private void RefreshVersionList(List<Version> versions)
        {
            foreach (Version dirname in versions)
            {
                string dirnameSub = dirname.ToString();
                if (Directory.Exists(@"C:\temp\VentileClient\Versions\Minecraft-" + dirnameSub))
                {
                    Guna2ProgressBar bar = (Guna2ProgressBar)GetControl("bar|" + dirnameSub, versionsPanel);
                    Guna2Button download = (Guna2Button)GetControl("download|" + dirnameSub, versionsPanel);
                    Guna2Button uninstall = (Guna2Button)GetControl("uninstall|" + dirnameSub, versionsPanel);
                    Guna2Button select = (Guna2Button)GetControl("select|" + dirnameSub, versionsPanel);

                    bar.Visible = false;
                    download.Visible = false;
                    uninstall.Visible = true;
                    select.Visible = true;
                    this.Refresh();
                }
            }
        }

        int downloadingVersions = 0;
        bool backedUp = false;
        private void BackupMCData(object sender, DoWorkEventArgs e, string sourceDirName, string destDirName)
        {

            if (!Directory.Exists(@"C:\temp\VentileClient\Versions\.data\"))
                Directory.CreateDirectory(@"C:\temp\VentileClient\Versions\.data\");

            if (sourceDirName == null) sourceDirName = configCS.ResourcePackLoc + "\\..\\..\\" + "com.mojang";
            if (destDirName == null) destDirName = @"C:\temp\VentileClient\Versions\.data\com.mojang";

            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            if (!dir.Exists)
            {
                this.Toast("Version Error", "Sorry, please manually back up your com.mojang folder!");
                //return false;
            }

            try
            {
                DirectoryInfo[] dirs = dir.GetDirectories();

                Directory.CreateDirectory(destDirName);
                FileInfo[] files = dir.GetFiles();
                foreach (FileInfo file in files)
                {
                    string tempPath = Path.Combine(destDirName, file.Name);
                    file.CopyTo(tempPath, false);
                }
                foreach (DirectoryInfo subdir in dirs)
                {
                    string tempPath = Path.Combine(destDirName, subdir.Name);
                    BackgroundWorker backup = new BackgroundWorker();
                    backup.DoWork += new DoWorkEventHandler((sndrsndr, mm) => BackupMCData(sndrsndr, mm, subdir.FullName, tempPath));
                    backup.RunWorkerAsync();
                }

                //return true;
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                this.Toast("Version Error", "Sorry, there was an error...");
                //return false;
            }
        }

        private void DelData(object sender, DoWorkEventArgs e)
        {
            if (Directory.Exists((@"C:\temp\VentileClient\Versions\.data")))
                Directory.Delete(@"C:\temp\VentileClient\Versions\.data", true);


            BackgroundWorker backup = new BackgroundWorker();
            backup.DoWork += new DoWorkEventHandler((sndrsndr, mm) => BackupMCData(sndrsndr, mm, null, null));
            backup.RunWorkerAsync();
        }

        private async void DownloadVersion_Clicked(object sender, EventArgs e)
        {
            if (!backedUp)
            {
                BackgroundWorker deldata = new BackgroundWorker();
                deldata.DoWork += DelData;
                deldata.RunWorkerAsync();

                backedUp = true;
            }
            downloadingVersions++;
            Guna2Button sndr = sender as Guna2Button;
            string version = ((Guna2Button)sender).Tag.ToString().Substring(sndr.Text.Length + 1);
            sndr.Enabled = false;
            await DownloadVersion(version, sndr);
        }

        private async void SelectVersion_Clicked(object sender, EventArgs e)
        {
            downloadingVersions++;
            Guna2Button sndr = sender as Guna2Button;
            string version = ((Guna2Button)sender).Tag.ToString().Substring(sndr.Text.Length + 1);
            sndr.Enabled = false;
            await DownloadVersion(version, sndr);
        }

        private async void UninstallVersion_Clicked(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                downloadingVersions++;
                Guna2Button sndr = sender as Guna2Button;
                string version = ((Guna2Button)sender).Tag.ToString().Substring(sndr.Text.Length + 1);
                Guna2Button ctrl2 = (Guna2Button)GetControl("select|" + version, versionsPanel);
                ctrl2.Invoke(new Action(() =>
                {
                    ctrl2.Enabled = false;
                    ctrl2.Visible = true;
                }));

                ctrl2 = (Guna2Button)GetControl("uninstall|" + version, versionsPanel);
                ctrl2.Invoke(new Action(() =>
                {
                    ctrl2.Enabled = false;
                    ctrl2.Visible = true;
                }));
                Directory.Delete(@"C:\temp\VentileClient\Versions\" + "Minecraft-" + version, true);

                ctrl2 = (Guna2Button)GetControl("download|" + version, versionsPanel);
                ctrl2.Invoke(new Action(() =>
                {
                    ctrl2.Enabled = true;
                    ctrl2.Visible = true;
                }));

                ctrl2 = (Guna2Button)GetControl("select|" + version, versionsPanel);
                ctrl2.Invoke(new Action(() =>
                {
                    ctrl2.Enabled = true;
                    ctrl2.Visible = false;
                }));

                ctrl2 = (Guna2Button)GetControl("uninstall|" + version, versionsPanel);
                ctrl2.Invoke(new Action(() =>
                {
                    ctrl2.Enabled = true;
                    ctrl2.Visible = false;
                }));
            });
        }

        private async Task DownloadVersion(string version, Guna2Button sender)
        {
            Guna2ProgressBar ctrl = (Guna2ProgressBar)GetControl("bar|" + version, versionsPanel);
            ctrl.Invoke(new Action(() =>
            {
                ctrl.Visible = true;
            }));

            await Task.Run(() =>
            {
                string link = @"https://github.com/Ventile-Client/VersionChanger/releases/download/" + version + @"/Minecraft-" + version + ".Appx";
                string path = @"C:\temp\VentileClient\Versions";
                string name = "Minecraft-" + version + ".Appx";
                using (WebClient Client = new WebClient())
                {
                    Client.DownloadProgressChanged += new DownloadProgressChangedEventHandler((sndr, e) => VersionDownloadProgressChanged(sndr, e, version));
                    Client.DownloadFileCompleted += new AsyncCompletedEventHandler((sndr, e) => VersionDownloadCompleted(sndr, e, version));

                    Debug.WriteLine("Started Downloading Version: " + version);
                    Uri url = new Uri(link);
                    if (path.EndsWith(@"\"))
                    {
                        Client.DownloadFileAsync(url, path + name);
                    }
                    else
                    {
                        Client.DownloadFileAsync(url, path + @"\" + name);
                    }
                }
            });

        }

        private async void VersionDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e, string version)
        {
            await Task.Run(() =>
            {
                Guna2ProgressBar ctrl = (Guna2ProgressBar)GetControl("bar|" + version, versionsPanel);
                double recieve = double.Parse(e.BytesReceived.ToString());
                double total = double.Parse(e.TotalBytesToReceive.ToString());
                double percent = recieve / total * 100;
                ctrl.Value = int.Parse(Math.Truncate(percent).ToString());
            });
        }

        private void VersionDownloadCompleted(object sender, AsyncCompletedEventArgs e, string version)
        {
            Debug.WriteLine("Downloaded version: " + version);
            Guna2ProgressBar ctrl = (Guna2ProgressBar)GetControl("bar|" + version, versionsPanel);
            ctrl.Maximum = int.MaxValue;
            ctrl.Value = 0;
            ExtractAndRegisterAppx(@"C:\temp\VentileClient\Versions\Minecraft-" + version + ".Appx", @"C:\temp\VentileClient\Versions", "Minecraft-" + version, version);
        }

        BackgroundWorker extractFile;
        long fileSize;
        long extractedSizeTotal;
        long compressedSize;
        private async void ExtractAndRegisterAppx(string AppxPath, string OutputPath, string dirName, string version)
        {
            await Task.Run(() =>
            {
                Directory.CreateDirectory(OutputPath + @"\" + dirName);
                Debug.WriteLine("Created Directory: " + dirName + " in: " + OutputPath + @"\");

                extractFile = new BackgroundWorker();
                extractFile.DoWork += ExtractFile_DoWork;
                extractFile.ProgressChanged += new ProgressChangedEventHandler((sndr, e) => ExtractFile_ProgressChanged(sndr, e, version));
                extractFile.RunWorkerCompleted += new RunWorkerCompletedEventHandler((sndr, e) => ExtractFile_RunWorkerCompleted(sndr, e, version, AppxPath, OutputPath, dirName));
                extractFile.WorkerReportsProgress = true;

                var workerThing = new workerThing();
                workerThing.a = AppxPath;
                workerThing.b = OutputPath + @"\" + dirName;
                workerThing.version = version;

                extractFile.RunWorkerAsync(workerThing);
            });
        }

        private void ExtractFile_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                workerThing arguments = (workerThing)e.Argument;
                string AppxPath = arguments.a;
                string OutputPath = arguments.b;

                Debug.WriteLine("Started to extract version: " + arguments.version);
                FileInfo fileInfo = new FileInfo(AppxPath);
                fileSize = fileInfo.Length;
                using (Ionic.Zip.ZipFile zipFile = Ionic.Zip.ZipFile.Read(AppxPath))
                {
                    extractedSizeTotal = 0;
                    int fileAmount = zipFile.Count;
                    int fileIndex = 0;
                    zipFile.ExtractProgress += Zip_ExtractProgress;
                    foreach (Ionic.Zip.ZipEntry entry in zipFile)
                    {
                        fileIndex++;
                        compressedSize = entry.CompressedSize;
                        entry.Extract(OutputPath, Ionic.Zip.ExtractExistingFileAction.OverwriteSilently);
                        extractedSizeTotal += compressedSize;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ExtractFile_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e, string version, string AppxPath, string OutputPath, string dirName)
        {
            
            Guna2ProgressBar ctrl = (Guna2ProgressBar)GetControl("bar|" + version, versionsPanel);
            ctrl.Value = int.MaxValue;
            ctrl.Visible = false;

            Guna2Button ctrl2 = (Guna2Button)GetControl("download|" + version, versionsPanel);
            ctrl2.Invoke(new Action(() =>
            {
                ctrl2.Enabled = true;
                ctrl2.Visible = false;
            }));

            ctrl2 = (Guna2Button)GetControl("select|" + version, versionsPanel);
            ctrl2.Invoke(new Action(() =>
            {
                ctrl2.Enabled = true;
                ctrl2.Visible = true;
            }));

            ctrl2 = (Guna2Button)GetControl("uninstall|" + version, versionsPanel);
            ctrl2.Invoke(new Action(() =>
            {
                ctrl2.Enabled = true;
                ctrl2.Visible = true;
            }));

            Debug.WriteLine("Extracted Appx: " + AppxPath + " to: " + OutputPath + @"\" + dirName);
            File.Delete(AppxPath);

            //Register Appx
            downloadingVersions--;
        }

        private async void ExtractFile_ProgressChanged(object sender, ProgressChangedEventArgs e, string version)
        {
            await Task.Run(() =>
            {

            long totalPercent = ((long)e.ProgressPercentage * compressedSize + extractedSizeTotal * int.MaxValue) / fileSize;
            if (totalPercent > int.MaxValue)
                totalPercent = int.MaxValue;
            Guna2ProgressBar ctrl = (Guna2ProgressBar)GetControl("bar|" + version, versionsPanel);
            ctrl.Value = (int)totalPercent;
            });
        }

        private async void Zip_ExtractProgress(object sender, Ionic.Zip.ExtractProgressEventArgs e)
        {
            await Task.Run(() =>
            {

            if (e.TotalBytesToTransfer > 0)
            {
                long percent = e.BytesTransferred * int.MaxValue / e.TotalBytesToTransfer;
                extractFile.ReportProgress((int)percent);
            }
            });
        }

        private Control GetControl(string controlTag, Control parentCtrl)
        {
            foreach (Control c in parentCtrl.Controls)
                if ((string)c.Tag == controlTag)
                    return c;

            return null;
        }


        private void closeButton_Click(object sender, EventArgs e)
        {
            writeConfig(@"C:\temp\VentileClient\Presets\Config.json");
            writeTheme(@"C:\temp\VentileClient\Presets\Theme.json");
            writeCosmetics(@"C:\temp\VentileClient\Presets\Cosmetics.json");
            writePresetColors(@"C:\temp\VentileClient\Presets\PresetColors.json");
            if (downloadingVersions == 0)
            {
                drpc.Deinitialize();
                Thread.Sleep(100);
                fadeOut.Start();
            } else
            {
                this.Toast("Version Manager", "Sorry, your still installing!");
            }
        }
        private void minimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        #region Timers
        private void fadeIn_Tick(object sender, EventArgs e)
        {
            if (Opacity >= 1)
            {
                fadeIn.Stop();
            }
            Opacity += 0.04;
        }

        bool hidden = false;

        bool inGameTest = false;

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
            if (configCS.WindowState == "hide" && Process.GetProcessesByName("Minecraft.Windows").Length > 0 && !hidden)
            {
                this.Hide();
                TrayIcon.Visible = true;
                this.Toast("Launcher", "Minimized to tray!");
                hidden = true;
            }

            if (configCS.WindowState == "hide" && !(Process.GetProcessesByName("Minecraft.Windows").Length > 0) && hidden)
            {
                TrayIcon.Visible = false;
                this.Show();
                this.BringToFront();
                this.TopMost = true;
                this.TopMost = false;
                hidden = false;
            }

            if (configCS.WindowState == "minimize" && Process.GetProcessesByName("Minecraft.Windows").Length > 0 && !hidden)
            {
                this.WindowState = FormWindowState.Minimized;
                hidden = true;
            }

            if (configCS.WindowState == "close" && Process.GetProcessesByName("Minecraft.Windows").Length > 0)
            {
                writeTheme(@"C:\temp\VentileClient\Presets\Theme.json");
                writeConfig(@"C:\temp\VentileClient\Presets\Config.json");
                drpc.Deinitialize();
                Thread.Sleep(100);
                fadeOut.Start();
            }

            //RPC
            if (Process.GetProcessesByName("Minecraft.Windows").Length > 0 && !inGameTest)
            {
                inGameTest = true;
                drpc.InGame();
            }
            else if (!(Process.GetProcessesByName("Minecraft.Windows").Length > 0) && inGameTest)
            {
                inGameTest = false;
                drpc.Home();
            }
        }

        private void fadeOut_Tick(object sender, EventArgs e)
        {
            if (Opacity <= 0)
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
            ChangeHomeColors();
            contentView.SelectedTab = contentView.TabPages[0];
            homeButton.Checked = true;
            cosmeticsButton.Checked = false;
            settingsButton.Checked = false;
            aboutButton.Checked = false;
        }

        private void cosmeticsButton_Click(object sender, EventArgs e)
        {
            ChangeCosmeticColors();
            contentView.SelectedTab = contentView.TabPages[1];
            homeButton.Checked = false;
            cosmeticsButton.Checked = true;
            settingsButton.Checked = false;
            aboutButton.Checked = false;
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            settingsPagesTabControl.SelectedTab = settingsPagesTabControl.TabPages[0];
            contentView.SelectedTab = contentView.TabPages[2];
            ChangeSettingColors();
            homeButton.Checked = false;
            cosmeticsButton.Checked = false;
            settingsButton.Checked = true;
            aboutButton.Checked = false;

        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            ChangeAboutColors();
            contentView.SelectedTab = contentView.TabPages[3];
            homeButton.Checked = false;
            cosmeticsButton.Checked = false;
            settingsButton.Checked = false;
            aboutButton.Checked = true;
        }

        #endregion

        private void ChangeGlobalColors()
        {
            // Make the color variable smaller
            Color backColor = ColorTranslator.FromHtml(themeCS.Background);
            Color accentColor = ColorTranslator.FromHtml(themeCS.Accent);
            Color foreColor = ColorTranslator.FromHtml(themeCS.Foreground);
            Color outlineColor = ColorTranslator.FromHtml(themeCS.Outline);
            Color fadedColor = ColorTranslator.FromHtml(themeCS.Faded);
            Color backColor2 = ColorTranslator.FromHtml(themeCS.SecondBackground);


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

            this.Refresh();
        }

        private void ChangeBackground()
        {
            if (configCS.BackgroundImage)
            {
                homeTab.BackgroundImage = new Bitmap(configCS.BackgroundImageLoc);
                cosmeticsTab.BackgroundImage = new Bitmap(configCS.BackgroundImageLoc);
                settingsTab.BackgroundImage = new Bitmap(configCS.BackgroundImageLoc);
                aboutTab.BackgroundImage = new Bitmap(configCS.BackgroundImageLoc);
                return;
            }

            // Change background and logo
            if (themeCS.Theme == "dark")
            {
                logo.Image = VentileClient.Properties.Resources.transparent_logo_white;
                homeTab.BackgroundImage = VentileClient.Properties.Resources.background;
                cosmeticsTab.BackgroundImage = VentileClient.Properties.Resources.background;
                settingsTab.BackgroundImage = VentileClient.Properties.Resources.background;
                aboutTab.BackgroundImage = VentileClient.Properties.Resources.background;
            }
            else if (themeCS.Theme == "light")
            {
                logo.Image = VentileClient.Properties.Resources.transparent_logo_black;
                homeTab.BackgroundImage = VentileClient.Properties.Resources.background2;
                cosmeticsTab.BackgroundImage = VentileClient.Properties.Resources.background2;
                settingsTab.BackgroundImage = VentileClient.Properties.Resources.background2;
                aboutTab.BackgroundImage = VentileClient.Properties.Resources.background2;
            }
        }

        #region Home
        private void ChangeHomeColors()
        {
            // Make the color variable smaller
            Color backColor = ColorTranslator.FromHtml(themeCS.Background);
            Color accentColor = ColorTranslator.FromHtml(themeCS.Accent);
            Color foreColor = ColorTranslator.FromHtml(themeCS.Foreground);
            Color outlineColor = ColorTranslator.FromHtml(themeCS.Outline);
            Color fadedColor = ColorTranslator.FromHtml(themeCS.Faded);
            Color backColor2 = ColorTranslator.FromHtml(themeCS.SecondBackground);

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
            if (!configCS.CustomDLL)
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

            if (configCS.AutoInject)
            {
                inject.Visible = false;
            }
            else
            {
                inject.Visible = true;
                inject.Location = new Point(260, 248);
                launchMc.Location = new Point(169, 171);
            }

            if (configCS.CustomDLL && !configCS.AutoInject)
            {
                selectDll.Location = new Point(169, 248);
                inject.Location = new Point(357, 248);
                launchMc.Location = new Point(169, 171);
            }

            // Deletes version files for auto update
            if (File.Exists(@"C:\temp\VentileClient\Version.txt"))
            {
                File.Delete(@"C:\temp\VentileClient\Version.txt");
            }

            if (File.Exists(@"C:\temp\VentileClient\Version.zip"))
            {
                File.Delete(@"C:\temp\VentileClient\Version.zip");
            }
        }

        private void launchMc_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("minecraft://");
            } catch
            {
                this.Toast("Error", "Sorry, there was an error launching...");
                return;
            }
            Task.Delay(250);
            if (configCS.AutoInject)
            {
                if (Process.GetProcessesByName("Minecraft.Windows").Length > 0)
                {
                    if (configCS.CustomDLL)
                    {
                        if (configCS.DefaultDLL.Length > 0)
                            InjectDLL(configCS.DefaultDLL);
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
            OpenFileDialog FileIn = new OpenFileDialog();
            FileIn.RestoreDirectory = true;
            FileIn.Filter = "DLL Files (*.dll)|*.dll|DLL Files (*.*)|*,*";
            if (FileIn.ShowDialog() == DialogResult.OK)
            {
                configCS.DefaultDLL = @FileIn.FileName;
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
                if (configCS.CustomDLL)
                {
                    if (configCS.DefaultDLL.Length > 0)
                        InjectDLL(configCS.DefaultDLL);
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
        readonly Dictionary<string, int[]> packInfo = new Dictionary<string, int[]>
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
            if (!File.Exists(configCS.ResourcePackLoc + @"\..\minecraftpe\global_resource_packs.json")) {

                 var err = new CosmeticsObject()
                {
                    pack_id = "error",
                    subpack = "error",
                    version = new int[] {0, 0, 0}
                };

                return new List<CosmeticsObject> { err };

            }

            string json = File.ReadAllText(configCS.ResourcePackLoc + @"\..\minecraftpe\global_resource_packs.json");

            return JsonConvert.DeserializeObject<List<CosmeticsObject>>(json);
        }

        private bool cosmeticEnabled(string id)
        {
            if (!File.Exists(configCS.ResourcePackLoc + @"\..\minecraftpe\global_resource_packs.json")) return false;

            string json = File.ReadAllText(configCS.ResourcePackLoc + @"\..\minecraftpe\global_resource_packs.json");

            var jsonObject = JsonConvert.DeserializeObject<List<CosmeticsObject>>(json);

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

        private void removeCosmetics(string id)
        {
            if (!File.Exists(configCS.ResourcePackLoc + @"\..\minecraftpe\global_resource_packs.json")) return;

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

                File.WriteAllText(configCS.ResourcePackLoc + @"\..\minecraftpe\global_resource_packs.json", JsonConvert.SerializeObject(packs, Formatting.Indented));
            }
        }

        private void addCosmetic(string id)
        {
            if (!File.Exists(configCS.ResourcePackLoc + @"\..\minecraftpe\global_resource_packs.json")) return;

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
                } else
                {
                    packs.Insert(0, new CosmeticsObject()
                    {
                        pack_id = id,
                        version = packInfo[id]
                    });
                }
                

                File.WriteAllText(configCS.ResourcePackLoc + @"\..\minecraftpe\global_resource_packs.json", JsonConvert.SerializeObject(packs, Formatting.Indented));
            }
        }
        #endregion

        private void InitCosmetics()
        {
            //Cape Load
            if (cosmeticsCS.cBlack)
            {
                if (!File.Exists(configCS.ResourcePackLoc + @"\BlackVentileCape.zip"))
                {
                    download(@"https://github.com/DeathlyBower959/Ventile-Client-Downloads/releases/latest/download/BlackVentileCape.zip", configCS.ResourcePackLoc, "BlackVentileCape.zip");
                    addCosmetic(packInfo.ElementAt(0).Key);
                }
                cBlack.Checked = true;


            }
            else if (cosmeticsCS.cWhite)
            {
                if (!File.Exists(configCS.ResourcePackLoc + @"\WhiteVentileCape.zip"))
                {
                    download(@"https://github.com/DeathlyBower959/Ventile-Client-Downloads/releases/latest/download/WhiteVentileCape.zip", configCS.ResourcePackLoc, "WhiteVentileCape.zip");
                    addCosmetic(packInfo.ElementAt(1).Key);
                }
                cWhite.Checked = true;

            }
            else if (cosmeticsCS.cPink)
            {
                if (!File.Exists(configCS.ResourcePackLoc + @"\PinkVentileCape.zip"))
                {
                    download(@"https://github.com/DeathlyBower959/Ventile-Client-Downloads/releases/latest/download/PinkVentileCape.zip", configCS.ResourcePackLoc, "PinkVentileCape.zip");
                    addCosmetic(packInfo.ElementAt(2).Key);
                }
                cPink.Checked = true;

            }
            else if (cosmeticsCS.cBlue)
            {
                if (!File.Exists(configCS.ResourcePackLoc + @"\BlueVentileCape.zip"))
                {
                    download(@"https://github.com/DeathlyBower959/Ventile-Client-Downloads/releases/latest/download/BlueVentileCape.zip", configCS.ResourcePackLoc, "BlueVentileCape.zip");
                    addCosmetic(packInfo.ElementAt(3).Key);
                }
                cBlue.Checked = true;

            }
            else if (cosmeticsCS.cYellow)
            {
                if (!File.Exists(configCS.ResourcePackLoc + @"\YellowVentileCape.zip"))
                {
                    download(@"https://github.com/DeathlyBower959/Ventile-Client-Downloads/releases/latest/download/YellowVentileCape.zip", configCS.ResourcePackLoc, "YellowVentileCape.zip");
                    addCosmetic(packInfo.ElementAt(4).Key);
                }
                cYellow.Checked = true;

            }
            else if (cosmeticsCS.cRick)
            {
                if (!File.Exists(configCS.ResourcePackLoc + @"\RickVentileCape.zip"))
                {
                    download(@"https://github.com/DeathlyBower959/Ventile-Client-Downloads/releases/latest/download/RickVentileCape.zip", configCS.ResourcePackLoc, "RickVentileCape.zip");
                    addCosmetic(packInfo.ElementAt(5).Key);
                }
                cRick.Checked = true;

            }

            //Mask Load
            if (cosmeticsCS.mBlack)
            {
                if (!File.Exists(configCS.ResourcePackLoc + @"\BlackVentileMask.zip"))
                {
                    download(@"https://github.com/DeathlyBower959/Ventile-Client-Downloads/releases/latest/download/BlackVentileMask.zip", configCS.ResourcePackLoc, "BlackVentileMask.zip");
                    addCosmetic(packInfo.ElementAt(6).Key);
                }
                mBlack.Checked = true;

            }
            else if (cosmeticsCS.mWhite)
            {
                if (!File.Exists(configCS.ResourcePackLoc + @"\WhiteVentileMask.zip"))
                {
                    download(@"https://github.com/DeathlyBower959/Ventile-Client-Downloads/releases/latest/download/WhiteVentileMask.zip", configCS.ResourcePackLoc, "WhiteVentileMask.zip");
                    addCosmetic(packInfo.ElementAt(7).Key);
                }
                mWhite.Checked = true;

            }
            else if (cosmeticsCS.mPink)
            {
                if (!File.Exists(configCS.ResourcePackLoc + @"\PinkVentileMask.zip"))
                {
                    download(@"https://github.com/DeathlyBower959/Ventile-Client-Downloads/releases/latest/download/PinkVentileMask.zip", configCS.ResourcePackLoc, "PinkVentileMask.zip");
                    addCosmetic(packInfo.ElementAt(8).Key);
                }
                mPink.Checked = true;

            }
            else if (cosmeticsCS.mBlue)
            {
                if (!File.Exists(configCS.ResourcePackLoc + @"\BlueVentileMask.zip"))
                {
                    download(@"https://github.com/DeathlyBower959/Ventile-Client-Downloads/releases/latest/download/BlueVentileMask.zip", configCS.ResourcePackLoc, "BlueVentileMask.zip");
                    addCosmetic(packInfo.ElementAt(9).Key);
                }
                mBlue.Checked = true;

            }
            else if (cosmeticsCS.mYellow)
            {
                if (!File.Exists(configCS.ResourcePackLoc + @"\BlackVentileMask.zip"))
                {
                    download(@"https://github.com/DeathlyBower959/Ventile-Client-Downloads/releases/latest/download/YellowVentileMask.zip", configCS.ResourcePackLoc, "YellowVentileMask.zip");
                    addCosmetic(packInfo.ElementAt(10).Key);
                }
                mYellow.Checked = true;

            }
            else if (cosmeticsCS.mRick)
            {
                if (!File.Exists(configCS.ResourcePackLoc + @"\RickVentileMask.zip"))
                {
                    download(@"https://github.com/DeathlyBower959/Ventile-Client-Downloads/releases/latest/download/RickVentileMask.zip", configCS.ResourcePackLoc, "RickVentileMask.zip");
                    addCosmetic(packInfo.ElementAt(11).Key);
                }
                mRick.Checked = true;

            }

            //Load Extras
            if (cosmeticsCS.aGlowing)
            {
                if (!File.Exists(configCS.ResourcePackLoc + @"\GlowingVentileCape.zip"))
                {
                    download(@"https://github.com/DeathlyBower959/Ventile-Client-Downloads/releases/latest/download/GlowingVentileCape.zip", configCS.ResourcePackLoc, "GlowingVentileCape.zip");
                    addCosmetic(packInfo.ElementAt(12).Key);
                }
                aGlowing.Checked = true;

            }
            else if (cosmeticsCS.aSlide)
            {
                if (!File.Exists(configCS.ResourcePackLoc + @"\SlidingVentileCape.zip"))
                {
                    download(@"https://github.com/DeathlyBower959/Ventile-Client-Downloads/releases/latest/download/GlowingVentileCape.zip", configCS.ResourcePackLoc, "SlidingVentileCape.zip");
                    addCosmetic(packInfo.ElementAt(13).Key);
                }
                aSlide.Checked = true;

            }
            else if (cosmeticsCS.oWavy)
            {
                if (!File.Exists(configCS.ResourcePackLoc + @"\WavyVentile.zip"))
                {
                    download(@"https://github.com/DeathlyBower959/Ventile-Client-Downloads/releases/latest/download/WavyVentile.zip", configCS.ResourcePackLoc, "WavyVentile.zip");
                    addCosmetic(packInfo.ElementAt(14).Key);
                }
                oWavy.Checked = true;

            }
            else if (cosmeticsCS.oKagune)
            {
                if (!File.Exists(configCS.ResourcePackLoc + @"\KaguneVentile.zip"))
                {
                    download(@"https://github.com/DeathlyBower959/Ventile-Client-Downloads/releases/latest/download/KaguneVentile.zip", configCS.ResourcePackLoc, "KaguneVentile.zip");
                    addCosmetic(packInfo.ElementAt(15).Key);
                }
                oKagune.Checked = true;

            }

            if (File.Exists(configCS.ResourcePackLoc + @"\CosmeticMixer.zip"))
            {
                File.Delete(configCS.ResourcePackLoc + @"\CosmeticMixer.zip");
            }

            download(@"https://github.com/DeathlyBower959/Ventile-Client-Downloads/releases/latest/download/CosmeticMixerV6.zip", configCS.ResourcePackLoc, "CosmeticMixer.zip");

            removeCosmetics("b6039dbe-c5f1-4544-afdb-dd4b9ed7d19e");
            addCosmetic("b6039dbe-c5f1-4544-afdb-dd4b9ed7d19e");
        }

        private void ChangeCosmeticColors()
        {
            // Make the color variable smaller
            Color backColor = ColorTranslator.FromHtml(themeCS.Background);
            Color accentColor = ColorTranslator.FromHtml(themeCS.Accent);
            Color foreColor = ColorTranslator.FromHtml(themeCS.Foreground);
            Color outlineColor = ColorTranslator.FromHtml(themeCS.Outline);
            Color fadedColor = ColorTranslator.FromHtml(themeCS.Faded);
            Color backColor2 = ColorTranslator.FromHtml(themeCS.SecondBackground);

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

            cWhite.BackColor = backColor;
            cWhite.FillColor = backColor2;
            cWhite.CheckedState.FillColor = accentColor;

            cPink.BackColor = backColor;
            cPink.FillColor = backColor2;
            cPink.CheckedState.FillColor = accentColor;

            cBlue.BackColor = backColor;
            cBlue.FillColor = backColor2;
            cBlue.CheckedState.FillColor = accentColor;

            cYellow.BackColor = backColor;
            cYellow.FillColor = backColor2;
            cYellow.CheckedState.FillColor = accentColor;

            cRick.BackColor = backColor;
            cRick.FillColor = backColor2;
            cRick.CheckedState.FillColor = accentColor;

            //Masks
            mBlack.BackColor = backColor;
            mBlack.FillColor = backColor2;
            mBlack.CheckedState.FillColor = accentColor;

            mWhite.BackColor = backColor;
            mWhite.FillColor = backColor2;
            mWhite.CheckedState.FillColor = accentColor;

            mPink.BackColor = backColor;
            mPink.FillColor = backColor2;
            mPink.CheckedState.FillColor = accentColor;

            mBlue.BackColor = backColor;
            mBlue.FillColor = backColor2;
            mBlue.CheckedState.FillColor = accentColor;

            mYellow.BackColor = backColor;
            mYellow.FillColor = backColor2;
            mYellow.CheckedState.FillColor = accentColor;

            mRick.BackColor = backColor;
            mRick.FillColor = backColor2;
            mRick.CheckedState.FillColor = accentColor;

            //Animated Capes
            aGlowing.BackColor = backColor;
            aGlowing.FillColor = backColor2;
            aGlowing.CheckedState.FillColor = accentColor;

            aSlide.BackColor = backColor;
            aSlide.FillColor = backColor2;
            aSlide.CheckedState.FillColor = accentColor;

            //Other
            oWavy.BackColor = backColor;
            oWavy.FillColor = backColor2;
            oWavy.CheckedState.FillColor = accentColor;

            oKagune.BackColor = backColor;
            oKagune.FillColor = backColor2;
            oKagune.CheckedState.FillColor = accentColor;

            //Rounded Buttons
            resetAllCosmetics.BackColor = backColor;
            resetAllCosmetics.FillColor = backColor2;
            resetAllCosmetics.CheckedState.FillColor = accentColor;
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

            if (configCS.RoundedButtons)
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
        }

        #region Capes
        private void cBlack_Click(object sender, EventArgs e)
        {
            resetCapes();
            if (internet)
            {
                cBlack.Checked = true;
                cosmeticsCS.cBlack = true;
                addCosmetic(packInfo.ElementAt(0).Key);
                removeCosmetics("b6039dbe-c5f1-4544-afdb-dd4b9ed7d19e");
                addCosmetic("b6039dbe-c5f1-4544-afdb-dd4b9ed7d19e");

                writeCosmetics(@"C:\temp\VentileClient\Presets\Cosmetics.json");

                //Auto Download
                download(@"https://github.com/DeathlyBower959/Ventile-Client-Downloads/releases/latest/download/BlackVentileCape.zip", configCS.ResourcePackLoc, "BlackVentileCape.zip");

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
                cosmeticsCS.cWhite = true;
                addCosmetic(packInfo.ElementAt(1).Key);
                removeCosmetics("b6039dbe-c5f1-4544-afdb-dd4b9ed7d19e");
                addCosmetic("b6039dbe-c5f1-4544-afdb-dd4b9ed7d19e");

                writeCosmetics(@"C:\temp\VentileClient\Presets\Cosmetics.json");

                //Auto Download
                download(@"https://github.com/DeathlyBower959/Ventile-Client-Downloads/releases/latest/download/WhiteVentileCape.zip", configCS.ResourcePackLoc, "WhiteVentileCape.zip");

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
                cosmeticsCS.cPink = true;
                addCosmetic(packInfo.ElementAt(2).Key);
                removeCosmetics("b6039dbe-c5f1-4544-afdb-dd4b9ed7d19e");
                addCosmetic("b6039dbe-c5f1-4544-afdb-dd4b9ed7d19e");

                writeCosmetics(@"C:\temp\VentileClient\Presets\Cosmetics.json");

                //Auto Download
                download(@"https://github.com/DeathlyBower959/Ventile-Client-Downloads/releases/latest/download/PinkVentileCape.zip", configCS.ResourcePackLoc, "PinkVentileCape.zip");

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
                cosmeticsCS.cBlue = true;
                addCosmetic(packInfo.ElementAt(3).Key);
                removeCosmetics("b6039dbe-c5f1-4544-afdb-dd4b9ed7d19e");
                addCosmetic("b6039dbe-c5f1-4544-afdb-dd4b9ed7d19e");

                writeCosmetics(@"C:\temp\VentileClient\Presets\Cosmetics.json");

                //Auto Download
                download(@"https://github.com/DeathlyBower959/Ventile-Client-Downloads/releases/latest/download/BlueVentileCape.zip", configCS.ResourcePackLoc, "BlueVentileCape.zip");

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
                cosmeticsCS.cYellow = true;
                addCosmetic(packInfo.ElementAt(4).Key);
                removeCosmetics("b6039dbe-c5f1-4544-afdb-dd4b9ed7d19e");
                addCosmetic("b6039dbe-c5f1-4544-afdb-dd4b9ed7d19e");

                writeCosmetics(@"C:\temp\VentileClient\Presets\Cosmetics.json");

                //Auto Download
                download(@"https://github.com/DeathlyBower959/Ventile-Client-Downloads/releases/latest/download/YellowVentileCape.zip", configCS.ResourcePackLoc, "YellowVentileCape.zip");

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
                cosmeticsCS.cRick = true;
                addCosmetic(packInfo.ElementAt(5).Key);
                removeCosmetics("b6039dbe-c5f1-4544-afdb-dd4b9ed7d19e");
                addCosmetic("b6039dbe-c5f1-4544-afdb-dd4b9ed7d19e");

                writeCosmetics(@"C:\temp\VentileClient\Presets\Cosmetics.json");

                //Auto Download
                download(@"https://github.com/DeathlyBower959/Ventile-Client-Downloads/releases/latest/download/RickVentileCape.zip", configCS.ResourcePackLoc, "RickVentileCape.zip");

            }
            else
            {
                this.Toast("Internet", "You do not a wifi connection");
            }
        }

        private void resetCapes()
        {
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

            if (internet)
            {
                removeCosmetics(packInfo.ElementAt(0).Key);
                removeCosmetics(packInfo.ElementAt(1).Key);
                removeCosmetics(packInfo.ElementAt(2).Key);
                removeCosmetics(packInfo.ElementAt(3).Key);
                removeCosmetics(packInfo.ElementAt(4).Key);
                removeCosmetics(packInfo.ElementAt(5).Key);


                if (File.Exists(configCS.ResourcePackLoc + @"\BlackVentileCape.zip"))
                {
                    File.Delete(configCS.ResourcePackLoc + @"\BlackVentileCape.zip");
                }
                if (File.Exists(configCS.ResourcePackLoc + @"\WhiteVentileCape.zip"))
                {
                    File.Delete(configCS.ResourcePackLoc + @"\WhiteVentileCape.zip");
                }
                if (File.Exists(configCS.ResourcePackLoc + @"\PinkVentileCape.zip"))
                {
                    File.Delete(configCS.ResourcePackLoc + @"\PinkVentileCape.zip");
                }
                if (File.Exists(configCS.ResourcePackLoc + @"\BlueVentileCape.zip"))
                {
                    File.Delete(configCS.ResourcePackLoc + @"\BlueVentileCape.zip");
                }
                if (File.Exists(configCS.ResourcePackLoc + @"\YellowVentileCape.zip"))
                {
                    File.Delete(configCS.ResourcePackLoc + @"\YellowVentileCape.zip");
                }
                if (File.Exists(configCS.ResourcePackLoc + @"\RickVentileCape.zip"))
                {
                    File.Delete(configCS.ResourcePackLoc + @"\RickVentileCape.zip");
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
                cosmeticsCS.mBlack = true;
                addCosmetic(packInfo.ElementAt(6).Key);
                removeCosmetics("b6039dbe-c5f1-4544-afdb-dd4b9ed7d19e");
                addCosmetic("b6039dbe-c5f1-4544-afdb-dd4b9ed7d19e");

                writeCosmetics(@"C:\temp\VentileClient\Presets\Cosmetics.json");

                //Auto Download
                download(@"https://github.com/DeathlyBower959/Ventile-Client-Downloads/releases/latest/download/BlackVentileMask.zip", configCS.ResourcePackLoc, "BlackVentileMask.zip");

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
                cosmeticsCS.mWhite = true;
                addCosmetic(packInfo.ElementAt(7).Key);
                removeCosmetics("b6039dbe-c5f1-4544-afdb-dd4b9ed7d19e");
                addCosmetic("b6039dbe-c5f1-4544-afdb-dd4b9ed7d19e");

                writeCosmetics(@"C:\temp\VentileClient\Presets\Cosmetics.json");

                //Auto Download
                download(@"https://github.com/DeathlyBower959/Ventile-Client-Downloads/releases/latest/download/WhiteVentileMask.zip", configCS.ResourcePackLoc, "WhiteVentileMask.zip");

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
                cosmeticsCS.mPink = true;
                addCosmetic(packInfo.ElementAt(8).Key);
                removeCosmetics("b6039dbe-c5f1-4544-afdb-dd4b9ed7d19e");
                addCosmetic("b6039dbe-c5f1-4544-afdb-dd4b9ed7d19e");

                writeCosmetics(@"C:\temp\VentileClient\Presets\Cosmetics.json");

                //Auto Download
                download(@"https://github.com/DeathlyBower959/Ventile-Client-Downloads/releases/latest/download/PinkVentileMask.zip", configCS.ResourcePackLoc, "PinkVentileMask.zip");

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
                cosmeticsCS.mBlue = true;
                addCosmetic(packInfo.ElementAt(9).Key);
                removeCosmetics("b6039dbe-c5f1-4544-afdb-dd4b9ed7d19e");
                addCosmetic("b6039dbe-c5f1-4544-afdb-dd4b9ed7d19e");

                writeCosmetics(@"C:\temp\VentileClient\Presets\Cosmetics.json");

                //Auto Download
                download(@"https://github.com/DeathlyBower959/Ventile-Client-Downloads/releases/latest/download/BlueVentileMask.zip", configCS.ResourcePackLoc, "BlueVentileMask.zip");

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
                cosmeticsCS.mYellow = true;
                addCosmetic(packInfo.ElementAt(10).Key);
                removeCosmetics("b6039dbe-c5f1-4544-afdb-dd4b9ed7d19e");
                addCosmetic("b6039dbe-c5f1-4544-afdb-dd4b9ed7d19e");

                writeCosmetics(@"C:\temp\VentileClient\Presets\Cosmetics.json");

                //Auto Download
                download(@"https://github.com/DeathlyBower959/Ventile-Client-Downloads/releases/latest/download/YellowVentileMask.zip", configCS.ResourcePackLoc, "YellowVentileMask.zip");

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
                cosmeticsCS.mRick = true;
                addCosmetic(packInfo.ElementAt(11).Key);
                removeCosmetics("b6039dbe-c5f1-4544-afdb-dd4b9ed7d19e");
                addCosmetic("b6039dbe-c5f1-4544-afdb-dd4b9ed7d19e");

                writeCosmetics(@"C:\temp\VentileClient\Presets\Cosmetics.json");

                //Auto Download
                download(@"https://github.com/DeathlyBower959/Ventile-Client-Downloads/releases/latest/download/RickVentileMask.zip", configCS.ResourcePackLoc, "RickVentileMask.zip");

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

                removeCosmetics(packInfo.ElementAt(6).Key);
                removeCosmetics(packInfo.ElementAt(7).Key);
                removeCosmetics(packInfo.ElementAt(8).Key);
                removeCosmetics(packInfo.ElementAt(9).Key);
                removeCosmetics(packInfo.ElementAt(10).Key);
                removeCosmetics(packInfo.ElementAt(11).Key);


                //Delete
                if (File.Exists(configCS.ResourcePackLoc + @"\BlackVentileMask.zip"))
                {
                    File.Delete(configCS.ResourcePackLoc + @"\BlackVentileMask.zip");
                }
                if (File.Exists(configCS.ResourcePackLoc + @"\WhiteVentileMask.zip"))
                {
                    File.Delete(configCS.ResourcePackLoc + @"\WhiteVentileMask.zip");
                }
                if (File.Exists(configCS.ResourcePackLoc + @"\PinkVentileMask.zip"))
                {
                    File.Delete(configCS.ResourcePackLoc + @"\PinkVentileMask.zip");
                }
                if (File.Exists(configCS.ResourcePackLoc + @"\BlueVentileMask.zip"))
                {
                    File.Delete(configCS.ResourcePackLoc + @"\BlueVentileMask.zip");
                }
                if (File.Exists(configCS.ResourcePackLoc + @"\YellowVentileMask.zip"))
                {
                    File.Delete(configCS.ResourcePackLoc + @"\YellowVentileMask.zip");
                }
                if (File.Exists(configCS.ResourcePackLoc + @"\RickVentileMask.zip"))
                {
                    File.Delete(configCS.ResourcePackLoc + @"\RickVentileMask.zip");
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
                cosmeticsCS.aGlowing = true;
                addCosmetic(packInfo.ElementAt(12).Key);
                removeCosmetics("b6039dbe-c5f1-4544-afdb-dd4b9ed7d19e");
                addCosmetic("b6039dbe-c5f1-4544-afdb-dd4b9ed7d19e");

                writeCosmetics(@"C:\temp\VentileClient\Presets\Cosmetics.json");

                download(@"https://github.com/DeathlyBower959/Ventile-Client-Downloads/releases/latest/download/GlowingVentileCape.zip", configCS.ResourcePackLoc, "GlowingVentileCape.zip");
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
                cosmeticsCS.aGlowing = true;

                addCosmetic(packInfo.ElementAt(13).Key);
                removeCosmetics("b6039dbe-c5f1-4544-afdb-dd4b9ed7d19e");
                addCosmetic("b6039dbe-c5f1-4544-afdb-dd4b9ed7d19e");

                writeCosmetics(@"C:\temp\VentileClient\Presets\Cosmetics.json");

                download(@"https://github.com/DeathlyBower959/Ventile-Client-Downloads/releases/latest/download/SlidingVentileCape.zip", configCS.ResourcePackLoc, "SlidingVentileCape.zip");
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

            cosmeticsCS.aGlowing = false;
            cosmeticsCS.aSlide = false;

            removeCosmetics(packInfo.ElementAt(12).Key);
            removeCosmetics(packInfo.ElementAt(13).Key);


            if (internet)
            {
                //Extras
                if (File.Exists(configCS.ResourcePackLoc + @"\GlowingVentileCape.zip"))
                {
                    File.Delete(configCS.ResourcePackLoc + @"\GlowingVentileCape.zip");
                }
                if (File.Exists(configCS.ResourcePackLoc + @"\SlidingVentileCape.zip"))
                {
                    File.Delete(configCS.ResourcePackLoc + @"\SlidingVentileCape.zip");
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
                cosmeticsCS.oWavy = true;

                addCosmetic(packInfo.ElementAt(14).Key);
                removeCosmetics("b6039dbe-c5f1-4544-afdb-dd4b9ed7d19e");
                addCosmetic("b6039dbe-c5f1-4544-afdb-dd4b9ed7d19e");

                writeCosmetics(@"C:\temp\VentileClient\Presets\Cosmetics.json");

                download(@"https://github.com/DeathlyBower959/Ventile-Client-Downloads/releases/latest/download/WavyVentile.zip", configCS.ResourcePackLoc, "WavyVentile.zip");
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
                cosmeticsCS.oKagune = true;

                addCosmetic(packInfo.ElementAt(15).Key);
                removeCosmetics("b6039dbe-c5f1-4544-afdb-dd4b9ed7d19e");
                addCosmetic("b6039dbe-c5f1-4544-afdb-dd4b9ed7d19e");

                writeCosmetics(@"C:\temp\VentileClient\Presets\Cosmetics.json");

                download(@"https://github.com/DeathlyBower959/Ventile-Client-Downloads/releases/latest/download/Kagune.zip", configCS.ResourcePackLoc, "KaguneVentile.zip");
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

            cosmeticsCS.oWavy = false;
            cosmeticsCS.oKagune = false;

            removeCosmetics(packInfo.ElementAt(11).Key);
            removeCosmetics(packInfo.ElementAt(15).Key);


            if (internet)
            {
                //Extras
                if (File.Exists(configCS.ResourcePackLoc + @"\WavyVentile.zip"))
                {
                    File.Delete(configCS.ResourcePackLoc + @"\WavyVentile.zip");
                }
                if (File.Exists(configCS.ResourcePackLoc + @"\KaguneVentile.zip"))
                {
                    File.Delete(configCS.ResourcePackLoc + @"\KaguneVentile.zip");
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
            writeCosmetics(@"C:\temp\VentileClient\Presets\Cosmetics.json");
        }

        #endregion

        #region Settings
        private void ChangeSettingColors()
        {

            // Make the color variable smaller
            Color backColor = ColorTranslator.FromHtml(themeCS.Background);
            Color accentColor = ColorTranslator.FromHtml(themeCS.Accent);
            Color foreColor = ColorTranslator.FromHtml(themeCS.Foreground);
            Color outlineColor = ColorTranslator.FromHtml(themeCS.Outline);
            Color fadedColor = ColorTranslator.FromHtml(themeCS.Faded);
            Color backColor2 = ColorTranslator.FromHtml(themeCS.SecondBackground);

            Launcher.BackColor = backColor;
            Appearance.BackColor = backColor;
            Extras.BackColor = backColor;

            // Launcher \\
            windowStateLabel.BackColor = backColor;
            richPresenceLabel.BackColor = backColor;
            devDLLLabel.BackColor = backColor;
            autoLabel.BackColor = backColor;
            resourceLabel.BackColor = backColor;
            rpcButtonTextLabel.BackColor = backColor;
            rpcButtonLinkLabel.BackColor = backColor;

            windowStateLabel.ForeColor = foreColor;
            richPresenceLabel.ForeColor = foreColor;
            devDLLLabel.ForeColor = foreColor;
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


            //Resource Location
            customLoc.CheckedState.FillColor = accentColor;
            customLoc.ForeColor = foreColor;
            customLoc.FillColor = backColor2;

            resetResourceLoc.ForeColor = foreColor;
            resetResourceLoc.FillColor = backColor2;

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
            if (configCS.RoundedButtons)
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
                resetResourceLoc.AutoRoundedCorners = true;
                customLoc.AutoRoundedCorners = true;
                roundedToggle.AutoRoundedCorners = true;
                toastsToggle.AutoRoundedCorners = true;
                toastsSelector.AutoRoundedCorners = true;
            } else
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
                resetResourceLoc.AutoRoundedCorners = false;
                customLoc.AutoRoundedCorners = false;
                roundedToggle.AutoRoundedCorners = false;
                toastsToggle.AutoRoundedCorners = false;
                toastsSelector.AutoRoundedCorners = false;
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

            preset1.BackColor = ColorTranslator.FromHtml(presetCS.p1);
            preset2.BackColor = ColorTranslator.FromHtml(presetCS.p2);
            preset3.BackColor = ColorTranslator.FromHtml(presetCS.p3);
            preset4.BackColor = ColorTranslator.FromHtml(presetCS.p4);
            preset5.BackColor = ColorTranslator.FromHtml(presetCS.p5);
            preset6.BackColor = ColorTranslator.FromHtml(presetCS.p6);
            preset7.BackColor = ColorTranslator.FromHtml(presetCS.p7);
            preset8.BackColor = ColorTranslator.FromHtml(presetCS.p8);

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

        }

        private void InitSettings()
        {
            //Window State
            if (configCS.WindowState == "hide")
            {
                hideWindow.Checked = true;
            }
            else if (configCS.WindowState == "minimize")
            {
                minWindow.Checked = true;
            }
            else if (configCS.WindowState == "close")
            {
                closeWindow.Checked = true;
            }
            else
            {
                openWindow.Checked = true;
            }

            //RPC
            if (configCS.RichPresence)
            {
                RpcToggle.Checked = true;
                RpcToggle.Text = "On";
                rpcLine.Text = configCS.RpcText;
                rpcLine.Visible = true;
            }
            else
            {
                RpcToggle.Checked = false;
                RpcToggle.Text = "Off";
                rpcLine.Visible = false;
            }

            if (configCS.RpcButton)
            {
                buttonForRpc.Checked = true;
                buttonForRpc.Visible = true;
                rpcButtonText.Visible = true;
                rpcButtonLink.Visible = true;
                rpcButtonTextLabel.Visible = true;
                rpcButtonLinkLabel.Visible = true;

                rpcButtonLink.Text = configCS.RpcButtonLink;
                rpcButtonText.Text = configCS.RpcButtonText;
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
            if (configCS.CustomDLL)
            {
                customDLLButton.Checked = true;
            }
            else
            {
                customDLLButton.Checked = false;
            }

            //Auto Inject
            if (configCS.AutoInject)
            {
                configCS.AutoInject = true;
                autoInject.Checked = true;
                autoInject.Text = "On";
            }
            else
            {
                configCS.AutoInject = false;
                autoInject.Checked = false;
                autoInject.Text = "Off";
            }

            //Resource Pack Loc
            if (configCS.CustomResourcePackLoc)
            {
                customLoc.Checked = true;
                resetResourceLoc.Visible = true;
            }
            else
            {
                customLoc.Checked = false;
                resetResourceLoc.Visible = false;
            }

            //Theme
            if (themeCS.Theme == "dark")
            {
                theme.Text = "Dark";
            }
            else
            {
                theme.Text = "Light";
            }

            //Background Iamge
            if (configCS.BackgroundImage)
            {
                customImage.Checked = true;
            } else
            {
                customImage.Checked = false;
            }

            //Toasts
            if (configCS.Toasts)
            {
                toastsToggle.Checked = true;

                if (configCS.ToastsLoc == "topRight")
                    toastsSelector.SelectedItem = "Top Right";
                else if (configCS.ToastsLoc == "bottomRight")
                    toastsSelector.SelectedItem = "Bottom Right";
                else if(configCS.ToastsLoc == "topLeft")
                    toastsSelector.SelectedItem = "Top Left";
                else if (configCS.ToastsLoc == "bottomLeft")
                    toastsSelector.SelectedItem = "Bottom Left";

                toastsSelector.Visible = true;
            }
            else
            {
                toastsToggle.Checked = false;
                toastsSelector.Visible = false;
            }

            //Rounded Buttons
            if (configCS.RoundedButtons)
            {
                roundedToggle.Checked = true;
            }
            else
            {
                roundedToggle.Checked = false;
            }

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

        //Launcher
        private void AppearanceButton_Click(object sender, EventArgs e)
        {
            settingsPagesTabControl.SelectedTab = settingsPagesTabControl.TabPages[1];
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

        private bool rpcCooldown;

        private void RpcToggle_Click(object sender, EventArgs e)
        {
            if (configCS.RichPresence && !rpcCooldown)
            {
                rpcCooldown = true;
                Cooldown(15);
                drpc.Deinitialize();

                RpcToggle.Checked = false;
                RpcToggle.Text = "Off";
                rpcLine.Visible = false;
                buttonForRpc.Visible = false;
                rpcButtonLink.Visible = false;
                rpcButtonText.Visible = false;
                rpcButtonLinkLabel.Visible = false;
                rpcButtonTextLabel.Visible = false;

                configCS.RichPresence = false;
            }
            else if (!configCS.RichPresence && !rpcCooldown)
            {
                rpcCooldown = true;

                Cooldown(15);
                configCS.RichPresence = true;
                drpc.Initialize();

                RpcToggle.FillColor = ColorTranslator.FromHtml(themeCS.Accent);
                RpcToggle.Text = "On";
                rpcLine.Visible = true;
                buttonForRpc.Visible = true;

                if (configCS.RpcButton)
                {
                    rpcButtonLink.Visible = false;
                    rpcButtonText.Visible = false;
                    rpcButtonLinkLabel.Visible = false;
                    rpcButtonTextLabel.Visible = false;
                    rpcButtonLink.Text = configCS.RpcButtonLink;
                    rpcButtonText.Text = configCS.RpcButtonText;
                }

                rpcLine.Text = configCS.RpcText;
            }
        }

        private void customImage_Click(object sender, EventArgs e)
        {
            if (configCS.BackgroundImage)
            {
                configCS.BackgroundImage = false;
                customImage.Checked = false;

                ChangeBackground();
            }
            else
            {
                OpenFileDialog customImg = new OpenFileDialog();

                customImg.Title = "Custom Background Image";
                customImg.Filter = "Image Files (*.bmp;*.jpg;*.jpeg)|*.BMP;*.JPG;*.JPEG";
                if (customImg.ShowDialog() == DialogResult.OK)
                {
                    configCS.BackgroundImage = true;
                    configCS.BackgroundImageLoc = customImg.FileName;
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
            ChangeSettingColors();
        }

        private void rpcLine_TextChanged(object sender, EventArgs e)
        {
            configCS.RpcText = rpcLine.Text;
        }

        private void rpcButtonLink_TextChanged(object sender, EventArgs e)
        {
            configCS.RpcButtonLink = rpcButtonLink.Text;
        }

        private void rpcButtonText_TextChanged(object sender, EventArgs e)
        {
            configCS.RpcButtonText = rpcButtonText.Text;
        }

        async private void Cooldown(int sec)
        {
            this.Toast("Rich Presence", "Your on cooldown for " + sec + "s");
            await Task.Delay(sec * 1000);
            rpcCooldown = false;
            this.Toast("Rich Presence", "Cooldown finished");
        }

        private void buttonForRpc_Click(object sender, EventArgs e)
        {
            if (!configCS.RpcButton)
            {
                rpcButtonLinkLabel.Visible = true;
                rpcButtonTextLabel.Visible = true;
                rpcButtonLink.Visible = true;
                rpcButtonText.Visible = true;
                buttonForRpc.Checked = true;

                configCS.RpcButton = true;
                rpcButtonText.Text = configCS.RpcButtonText;
                rpcButtonLink.Text = configCS.RpcButtonLink;
            }
            else
            {
                rpcButtonLinkLabel.Visible = false;
                rpcButtonTextLabel.Visible = false;
                rpcButtonLink.Visible = false;
                rpcButtonText.Visible = false;
                buttonForRpc.Checked = false;

                configCS.RpcButton = false;
            }
        }

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

        private void customLoc_Click(object sender, EventArgs e)
        {
            if (configCS.CustomResourcePackLoc)
            {
                configCS.CustomResourcePackLoc = false;

                customLoc.Checked = false;
                resetResourceLoc.Visible = false;
            }
            else
            {
                FolderBrowserDialog resourceLoc = new FolderBrowserDialog();
                resourceLoc.RootFolder = Environment.SpecialFolder.MyComputer;
                resourceLoc.Description = "Select the folder where cosmetics will install to \n(Resource Packs folder for minecraft)";
                resourceLoc.ShowNewFolderButton = false;

                if (resourceLoc.ShowDialog() == DialogResult.OK)
                {
                    configCS.ResourcePackLoc = resourceLoc.SelectedPath;
                    this.Toast("Chosen Path", resourceLoc.SelectedPath.ToString());
                    configCS.CustomResourcePackLoc = true;
                    customLoc.Checked = true;
                    resetResourceLoc.Visible = true;
                }
            }
        }

        private void resetResourceLoc_Click(object sender, EventArgs e)
        {
            configCS.ResourcePackLoc = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Packages\Microsoft.MinecraftUWP_8wekyb3d8bbwe\LocalState\games\com.mojang\resource_packs";
            this.Toast("Resources", "Resource pack location reset");
            configCS.CustomResourcePackLoc = false;
            resetResourceLoc.Visible = false;

            customLoc.Checked = false;
        }

        //Appearance
        private void LauncherButton_Click(object sender, EventArgs e)
        {
            settingsPagesTabControl.SelectedTab = settingsPagesTabControl.TabPages[0];
        }

        private void ExtrasButton_Click(object sender, EventArgs e)
        {
            settingsPagesTabControl.SelectedTab = settingsPagesTabControl.TabPages[2];
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

            if (themeCS.Theme == "dark")
            {
                themeCS.Theme = "light";

                themeCS.Background = ColorTranslator.ToHtml(Color.FromArgb(240, 240, 240));
                themeCS.SecondBackground = ColorTranslator.ToHtml(Color.FromArgb(205, 205, 205));
                //Properties.Colors.Default.accentColor1 = 15;
                //Properties.Colors.Default.accentColor2 = 105;
                //Properties.Colors.Default.accentColor3 = 255;
                themeCS.Foreground = ColorTranslator.ToHtml(Color.FromArgb(0, 0, 0));
                themeCS.Outline = ColorTranslator.ToHtml(Color.FromArgb(170, 170, 170));
                themeCS.Faded = ColorTranslator.ToHtml(Color.FromArgb(163, 163, 163));
            }
            else if (themeCS.Theme == "light")
            {
                themeCS.Theme = "dark";

                themeCS.Background = ColorTranslator.ToHtml(Color.FromArgb(20, 20, 20));
                themeCS.SecondBackground = ColorTranslator.ToHtml(Color.FromArgb(40, 40, 40));
                //Properties.Colors.Default.accentColor1 = 15;
                //Properties.Colors.Default.accentColor2 = 105;
                //Properties.Colors.Default.accentColor3 = 255;
                themeCS.Foreground = ColorTranslator.ToHtml(Color.FromArgb(255, 255, 255));
                themeCS.Outline = ColorTranslator.ToHtml(Color.FromArgb(5, 5, 5));
                themeCS.Faded = ColorTranslator.ToHtml(Color.FromArgb(192, 192, 192));
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

            if (themeCS.Theme == "light")
            {

                themeCS.Background = ColorTranslator.ToHtml(Color.FromArgb(240, 240, 240));
                themeCS.SecondBackground = ColorTranslator.ToHtml(Color.FromArgb(205, 205, 205));
                themeCS.Accent = ColorTranslator.ToHtml(Color.FromArgb(65, 105, 255));
                themeCS.Foreground = ColorTranslator.ToHtml(Color.FromArgb(0, 0, 0));
                themeCS.Outline = ColorTranslator.ToHtml(Color.FromArgb(170, 170, 170));
                themeCS.Faded = ColorTranslator.ToHtml(Color.FromArgb(163, 163, 163));

                //Accent Color Changer
                backgroundBrightnessSlider.Value = ColorTranslator.FromHtml(themeCS.Background).R;
                buttonBrightnessSlider.Value = ColorTranslator.FromHtml(themeCS.SecondBackground).R;
                outlineBrightnessSlider.Value = ColorTranslator.FromHtml(themeCS.Outline).R;
                textBrightnessSlider.Value = ColorTranslator.FromHtml(themeCS.Foreground).R;
                accentRedSlider.Value = ColorTranslator.FromHtml(themeCS.Accent).R;
                accentGreenSlider.Value = ColorTranslator.FromHtml(themeCS.Accent).G;
                accentBlueSlider.Value = ColorTranslator.FromHtml(themeCS.Accent).B;
            }
            else if (themeCS.Theme == "dark")
            {

                themeCS.Background = ColorTranslator.ToHtml(Color.FromArgb(20, 20, 20));
                themeCS.SecondBackground = ColorTranslator.ToHtml(Color.FromArgb(40, 40, 40));
                themeCS.Accent = ColorTranslator.ToHtml(Color.FromArgb(65, 105, 255));
                themeCS.Foreground = ColorTranslator.ToHtml(Color.FromArgb(255, 255, 255));
                themeCS.Outline = ColorTranslator.ToHtml(Color.FromArgb(5, 5, 5));
                themeCS.Faded = ColorTranslator.ToHtml(Color.FromArgb(192, 192, 192));

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

            ChangeBackground();
            ChangeSettingColors();
            ChangeAboutColors();
            ChangeCosmeticColors();
            ChangeGlobalColors();

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
            ChangeSettingColors();
            ChangeGlobalColors();
        }

        private void accentRedSlider_Scroll(object sender, ScrollEventArgs e)
        {
            themeCS.Accent = ColorTranslator.ToHtml(Color.FromArgb(accentRedSlider.Value, accentGreenSlider.Value, accentBlueSlider.Value));
            accentRT.Text = accentRedSlider.Value.ToString();
            ChangeSettingColors();
            ChangeGlobalColors();
        }

        private void accentGreenSlider_Scroll(object sender, ScrollEventArgs e)
        {
            themeCS.Accent = ColorTranslator.ToHtml(Color.FromArgb(accentRedSlider.Value, accentGreenSlider.Value, accentBlueSlider.Value));
            accentGT.Text = accentGreenSlider.Value.ToString();
            ChangeSettingColors();
            ChangeGlobalColors();
        }

        private void accentBlueSlider_Scroll(object sender, ScrollEventArgs e)
        {

            themeCS.Accent = ColorTranslator.ToHtml(Color.FromArgb(accentRedSlider.Value, accentGreenSlider.Value, accentBlueSlider.Value));
            accentBT.Text = accentBlueSlider.Value.ToString();
            ChangeSettingColors();
            ChangeGlobalColors();
        }

        private void outlineBrightnessSlider_Scroll(object sender, ScrollEventArgs e)
        {

            themeCS.Outline = ColorTranslator.ToHtml(Color.FromArgb(outlineBrightnessSlider.Value, outlineBrightnessSlider.Value, outlineBrightnessSlider.Value));
            outlineOT.Text = outlineBrightnessSlider.Value.ToString();
            ChangeSettingColors();
            ChangeGlobalColors();

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


            ChangeSettingColors();
            ChangeGlobalColors();
        }

        private void textBrightnessSlider_Scroll(object sender, ScrollEventArgs e)
        {
            themeCS.Foreground = ColorTranslator.ToHtml(Color.FromArgb(textBrightnessSlider.Value, textBrightnessSlider.Value, textBrightnessSlider.Value));
            foreBT.Text = textBrightnessSlider.Value.ToString();

            ChangeSettingColors();
            ChangeGlobalColors();
        }


        private Panel panel;
        private string hoveredPreset;
        private void presetHover(object sender, EventArgs e)
        {
            panel = (Panel)sender;
            hoveredPreset = panel.Name;
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (hoveredPreset == null)
            {
                this.Toast("Presets", "There was an error saving!");
            }
            else
            {
                readPresetColors(@"C:\temp\VentileClient\Presets\PresetColors.json");

                if (Convert.ToInt32(panel.Name.Substring(6)) == 1)
                    presetCS.p1 = themeCS.Accent;

                if (Convert.ToInt32(panel.Name.Substring(6)) == 2)
                    presetCS.p2 = themeCS.Accent;

                if (Convert.ToInt32(panel.Name.Substring(6)) == 3)
                    presetCS.p3 = themeCS.Accent;

                if (Convert.ToInt32(panel.Name.Substring(6)) == 4)
                    presetCS.p4 = themeCS.Accent;

                if (Convert.ToInt32(panel.Name.Substring(6)) == 5)
                    presetCS.p5 = themeCS.Accent;

                if (Convert.ToInt32(panel.Name.Substring(6)) == 6)
                    presetCS.p6 = themeCS.Accent;

                if (Convert.ToInt32(panel.Name.Substring(6)) == 7)
                    presetCS.p7 = themeCS.Accent;

                if (Convert.ToInt32(panel.Name.Substring(6)) == 8)
                    presetCS.p8 = themeCS.Accent;

                panel.BackColor = ColorTranslator.FromHtml(themeCS.Accent);
                writePresetColors(@"C:\temp\VentileClient\Presets\PresetColors.json");

                writeConfig(@"C:\temp\VentileClient\Presets\" + hoveredPreset + ".json");
                writeTheme(@"C:\temp\VentileClient\Presets\" + hoveredPreset + "Theme.json");
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (hoveredPreset == null)
            {
                this.Toast("Presets", "There was an error loading!");
            }
            else
            {
                if (File.Exists(@"C:\temp\VentileClient\Presets\" + hoveredPreset + ".json") && File.Exists(@"C:\temp\VentileClient\Presets\" + hoveredPreset + "Theme.json"))
                {
                    readConfig(@"C:\temp\VentileClient\Presets\" + hoveredPreset + ".json");
                    readTheme(@"C:\temp\VentileClient\Presets\" + hoveredPreset + "Theme.json");
                    writeConfig(@"C:\temp\VentileClient\Presets\Config.json");
                    writeTheme(@"C:\temp\VentileClient\Presets\Theme.json");
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
                    readPresetColors(@"C:\temp\VentileClient\Presets\PresetColors.json");

                    panel.BackColor = ColorTranslator.FromHtml(themeCS.SecondBackground);


                    if (Convert.ToInt32(panel.Name.Substring(6)) == 1)
                        presetCS.p1 = themeCS.SecondBackground;

                    if (Convert.ToInt32(panel.Name.Substring(6)) == 2)
                        presetCS.p2 = themeCS.SecondBackground;

                    if (Convert.ToInt32(panel.Name.Substring(6)) == 3)
                        presetCS.p3 = themeCS.SecondBackground;

                    if (Convert.ToInt32(panel.Name.Substring(6)) == 4)
                        presetCS.p4 = themeCS.SecondBackground;

                    if (Convert.ToInt32(panel.Name.Substring(6)) == 5)
                        presetCS.p5 = themeCS.SecondBackground;

                    if (Convert.ToInt32(panel.Name.Substring(6)) == 6)
                        presetCS.p6 = themeCS.SecondBackground;

                    if (Convert.ToInt32(panel.Name.Substring(6)) == 7)
                        presetCS.p7 = themeCS.SecondBackground;

                    if (Convert.ToInt32(panel.Name.Substring(6)) == 8)
                        presetCS.p8 = themeCS.SecondBackground;

                    writePresetColors(@"C:\temp\VentileClient\Presets\PresetColors.json");
                }
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(@"C:\temp\VentileClient\Presets\" + hoveredPreset + ".json") || File.Exists(@"C:\temp\VentileClient\Presets\" + hoveredPreset + "Theme.json"))
            {
                try
                {
                    File.Delete(@"C:\temp\VentileClient\Presets\" + hoveredPreset + ".json");
                    File.Delete(@"C:\temp\VentileClient\Presets\" + hoveredPreset + "Theme.json");
                }
                catch { }
                readPresetColors(@"C:\temp\VentileClient\Presets\PresetColors.json");

                panel.BackColor = ColorTranslator.FromHtml(themeCS.SecondBackground);


                if (Convert.ToInt32(panel.Name.Substring(6)) == 1)
                    presetCS.p1 = themeCS.SecondBackground;

                if (Convert.ToInt32(panel.Name.Substring(6)) == 2)
                    presetCS.p2 = themeCS.SecondBackground;

                if (Convert.ToInt32(panel.Name.Substring(6)) == 3)
                    presetCS.p3 = themeCS.SecondBackground;

                if (Convert.ToInt32(panel.Name.Substring(6)) == 4)
                    presetCS.p4 = themeCS.SecondBackground;

                if (Convert.ToInt32(panel.Name.Substring(6)) == 5)
                    presetCS.p5 = themeCS.SecondBackground;

                if (Convert.ToInt32(panel.Name.Substring(6)) == 6)
                    presetCS.p6 = themeCS.SecondBackground;

                if (Convert.ToInt32(panel.Name.Substring(6)) == 7)
                    presetCS.p7 = themeCS.SecondBackground;

                if (Convert.ToInt32(panel.Name.Substring(6)) == 8)
                    presetCS.p8 = themeCS.SecondBackground;

                writePresetColors(@"C:\temp\VentileClient\Presets\PresetColors.json");
            }
            else
            {
                this.Toast("Presets", "This preset doesn't exist!");
                readPresetColors(@"C:\temp\VentileClient\Presets\PresetColors.json");

                panel.BackColor = ColorTranslator.FromHtml(themeCS.SecondBackground);


                if (Convert.ToInt32(panel.Name.Substring(6)) == 1)
                    presetCS.p1 = themeCS.SecondBackground;

                if (Convert.ToInt32(panel.Name.Substring(6)) == 2)
                    presetCS.p2 = themeCS.SecondBackground;

                if (Convert.ToInt32(panel.Name.Substring(6)) == 3)
                    presetCS.p3 = themeCS.SecondBackground;

                if (Convert.ToInt32(panel.Name.Substring(6)) == 4)
                    presetCS.p4 = themeCS.SecondBackground;

                if (Convert.ToInt32(panel.Name.Substring(6)) == 5)
                    presetCS.p5 = themeCS.SecondBackground;

                if (Convert.ToInt32(panel.Name.Substring(6)) == 6)
                    presetCS.p6 = themeCS.SecondBackground;

                if (Convert.ToInt32(panel.Name.Substring(6)) == 7)
                    presetCS.p7 = themeCS.SecondBackground;

                if (Convert.ToInt32(panel.Name.Substring(6)) == 8)
                    presetCS.p8 = themeCS.SecondBackground;

                writePresetColors(@"C:\temp\VentileClient\Presets\PresetColors.json");
            }
        }
        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog importConfig = new OpenFileDialog();
            importConfig.Filter = "JSON Files (*.json)|*.json|All files (*.*)|*.*";
            importConfig.RestoreDirectory = true;
            importConfig.Title = "Config File";

            OpenFileDialog importTheme = new OpenFileDialog();
            importTheme.Filter = "JSON Files (*.json)|*.json|All files (*.*)|*.*";
            importTheme.RestoreDirectory = true;
            importTheme.Title = "Theme File";

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
                        File.WriteAllText(@"C:\temp\VentileClient\Presets\" + hoveredPreset + ".json", json);

                        json = JsonConvert.SerializeObject(them, Formatting.Indented);
                        File.WriteAllText(@"C:\temp\VentileClient\Presets\" + hoveredPreset + "Theme.json", json);

                        if (Convert.ToInt32(panel.Name.Substring(6)) == 1)
                            presetCS.p1 = them.Accent;

                        if (Convert.ToInt32(panel.Name.Substring(6)) == 2)
                            presetCS.p2 = them.Accent;

                        if (Convert.ToInt32(panel.Name.Substring(6)) == 3)
                            presetCS.p3 = them.Accent;

                        if (Convert.ToInt32(panel.Name.Substring(6)) == 4)
                            presetCS.p4 = them.Accent;

                        if (Convert.ToInt32(panel.Name.Substring(6)) == 5)
                            presetCS.p5 = them.Accent;

                        if (Convert.ToInt32(panel.Name.Substring(6)) == 6)
                            presetCS.p6 = them.Accent;

                        if (Convert.ToInt32(panel.Name.Substring(6)) == 7)
                            presetCS.p7 = them.Accent;

                        if (Convert.ToInt32(panel.Name.Substring(6)) == 8)
                            presetCS.p8 = them.Accent;

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
            writeConfig(@"C:\temp\VentileClient\SHARE\Config.json");
            writeTheme(@"C:\temp\VentileClient\SHARE\Theme.json");
            using (StreamWriter sw = new StreamWriter(@"C:\temp\VentileClient\SHARE\Share These Files!"))
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
            settingsPagesTabControl.SelectedTab = settingsPagesTabControl.TabPages[1];
        }

        private void toastsToggle_Click(object sender, EventArgs e)
        {
            if (configCS.Toasts)
            {
                configCS.Toasts = false;
                toastsToggle.Checked = false;
                toastsToggle.Text = "Off";
                toastsSelector.Visible = false;
            }
            else
            {
                configCS.Toasts = true;
                toastsToggle.Checked = true;
                toastsToggle.Text = "On";
                toastsSelector.Visible = true;
            }
        }

        private void toastsSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (toastsSelector.SelectedIndex == 0) //Top Right
            {
                configCS.ToastsLoc = "topRight";
            }
            else if (toastsSelector.SelectedIndex == 1) //Bottom Right
            {
                configCS.ToastsLoc = "bottomRight";
            }
            else if (toastsSelector.SelectedIndex == 2) //Top Left
            {
                configCS.ToastsLoc = "topLeft";
            }
            else if (toastsSelector.SelectedIndex == 3) //Bottom Left
            {
                configCS.ToastsLoc = "bottomLeft";
            }
        }
        #endregion

        #region About
        private void InitAbout()
        {
            launcherVLabel.Text = Properties.Ventile.Default.Version;
            clientVLabel.Text = Properties.Ventile.Default.ClientVersion;
            cosmeticsVLabel.Text = Properties.Ventile.Default.CosmeticsVersion;
        }
        private void ChangeAboutColors()
        {
            // Make the color variable smaller
            Color backColor = ColorTranslator.FromHtml(themeCS.Background);
            Color accentColor = ColorTranslator.FromHtml(themeCS.Accent);
            Color foreColor = ColorTranslator.FromHtml(themeCS.Foreground);
            Color outlineColor = ColorTranslator.FromHtml(themeCS.Outline);
            Color fadedColor = ColorTranslator.FromHtml(themeCS.Faded);
            Color backColor2 = ColorTranslator.FromHtml(themeCS.SecondBackground);

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
            Process.Start("https://ventile-client.github.io/Ventile/");
        }

        private void discord_Click(object sender, EventArgs e)
        {
            Process.Start("https://discord.gg/rgrGyBDrrV");
        }
        #endregion



        #region Injecting Crap

        //Not by me, 12Brendon34 gave it to me :)
        public static void applyAppPackages(string DLLPath)
        {
            FileInfo InfoFile = new FileInfo(DLLPath);
            FileSecurity fSecurity = InfoFile.GetAccessControl();
            fSecurity.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier("S-1-15-2-1"), FileSystemRights.FullControl, InheritanceFlags.None, PropagationFlags.NoPropagateInherit, AccessControlType.Allow));
            InfoFile.SetAccessControl(fSecurity);
        }

        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("kernel32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress,
            uint dwSize, uint flAllocationType, uint flProtect);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out UIntPtr lpNumberOfBytesWritten);

        [DllImport("kernel32.dll")]
        static extern IntPtr CreateRemoteThread(IntPtr hProcess,
            IntPtr lpThreadAttributes, uint dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);



        // privileges
        const int PROCESS_CREATE_THREAD = 0x0002;
        const int PROCESS_QUERY_INFORMATION = 0x0400;
        const int PROCESS_VM_OPERATION = 0x0008;
        const int PROCESS_VM_WRITE = 0x0020;
        const int PROCESS_VM_READ = 0x0010;

        // used for memory allocation
        const uint MEM_COMMIT = 0x00001000;
        const uint MEM_RESERVE = 0x00002000;
        const uint PAGE_READWRITE = 4;

        private static bool alreadyAttemptedInject = false;

        public void InjectDLL(string DownloadedDllFilePath)
        {
            Task.Delay(1000);
            Process[] targetProcessIndex = Process.GetProcessesByName("Minecraft.Windows");
            if (targetProcessIndex.Length > 0)
            {
                applyAppPackages(DownloadedDllFilePath);

                Process targetProcess = Process.GetProcessesByName("Minecraft.Windows")[0];
                IntPtr procHandle = OpenProcess(PROCESS_CREATE_THREAD | PROCESS_QUERY_INFORMATION | PROCESS_VM_OPERATION | PROCESS_VM_WRITE | PROCESS_VM_READ, false, targetProcess.Id);

                IntPtr loadLibraryAddr = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");

                IntPtr allocMemAddress = VirtualAllocEx(procHandle, IntPtr.Zero, (uint)((DownloadedDllFilePath.Length + 1) * Marshal.SizeOf(typeof(char))), MEM_COMMIT | MEM_RESERVE, PAGE_READWRITE);

                UIntPtr bytesWritten; // byteswritten value L
                WriteProcessMemory(procHandle, allocMemAddress, Encoding.Default.GetBytes(DownloadedDllFilePath), (uint)((DownloadedDllFilePath.Length + 1) * Marshal.SizeOf(typeof(char))), out bytesWritten);
                CreateRemoteThread(procHandle, IntPtr.Zero, 0, loadLibraryAddr, allocMemAddress, 0, IntPtr.Zero);

                alreadyAttemptedInject = false;

                this.Toast("DLL", "Injected!");
            }
            else
            {
                if (!alreadyAttemptedInject)
                {
                    alreadyAttemptedInject = true;
                    this.Toast("DLL", "Injection failed");
                }
                else
                {
                    this.Toast("Minecraft", "I cannot find minecraft! (Bedrock)");
                    alreadyAttemptedInject = false;
                }
            }
        }

        #endregion Injecting Crap

        
    }

    class workerThing
    {
        public string a;
        public string b;
        public string version; 
    }
}
