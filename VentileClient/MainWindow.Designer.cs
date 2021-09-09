
namespace VentileClient
{
    partial class MainWindow
    {

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        public void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Guna.UI2.AnimatorNS.Animation animation1 = new Guna.UI2.AnimatorNS.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.dragBar = new Guna.UI2.WinForms.Guna2Panel();
            this.minimizeButton = new Guna.UI2.WinForms.Guna2Button();
            this.closeButton = new Guna.UI2.WinForms.Guna2Button();
            this.dragWindowControl = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.sidebar = new Guna.UI2.WinForms.Guna2Panel();
            this.versionButton = new Guna.UI2.WinForms.Guna2Button();
            this.versionButtonIcon = new FontAwesome.Sharp.IconPictureBox();
            this.homeButton = new Guna.UI2.WinForms.Guna2Button();
            this.version = new System.Windows.Forms.Label();
            this.aboutButton = new Guna.UI2.WinForms.Guna2Button();
            this.aboutButtonIcon = new FontAwesome.Sharp.IconPictureBox();
            this.settingsButton = new Guna.UI2.WinForms.Guna2Button();
            this.settingsButtonIcon = new FontAwesome.Sharp.IconPictureBox();
            this.cosmeticsButton = new Guna.UI2.WinForms.Guna2Button();
            this.cosmeticsButtonIcon = new FontAwesome.Sharp.IconPictureBox();
            this.homeButtonIcon = new FontAwesome.Sharp.IconPictureBox();
            this.launcherTitle = new System.Windows.Forms.Label();
            this.line = new System.Windows.Forms.Button();
            this.logo = new Guna.UI2.WinForms.Guna2PictureBox();
            this.fadeIn = new System.Windows.Forms.Timer(this.components);
            this.fadeOut = new System.Windows.Forms.Timer(this.components);
            this.tick = new System.Windows.Forms.Timer(this.components);
            this.contentView = new Guna.UI2.WinForms.Guna2TabControl();
            this.homeTab = new System.Windows.Forms.TabPage();
            this.launchMc = new Guna.UI2.WinForms.Guna2Button();
            this.inject = new Guna.UI2.WinForms.Guna2Button();
            this.selectDll = new Guna.UI2.WinForms.Guna2Button();
            this.cosmeticsTab = new System.Windows.Forms.TabPage();
            this.oKagune = new Guna.UI2.WinForms.Guna2Button();
            this.oWavy = new Guna.UI2.WinForms.Guna2Button();
            this.aSlide = new Guna.UI2.WinForms.Guna2Button();
            this.aGlowing = new Guna.UI2.WinForms.Guna2Button();
            this.mRick = new Guna.UI2.WinForms.Guna2Button();
            this.mYellow = new Guna.UI2.WinForms.Guna2Button();
            this.mBlue = new Guna.UI2.WinForms.Guna2Button();
            this.mPink = new Guna.UI2.WinForms.Guna2Button();
            this.mWhite = new Guna.UI2.WinForms.Guna2Button();
            this.mBlack = new Guna.UI2.WinForms.Guna2Button();
            this.resetAllCosmetics = new Guna.UI2.WinForms.Guna2Button();
            this.cRick = new Guna.UI2.WinForms.Guna2Button();
            this.cYellow = new Guna.UI2.WinForms.Guna2Button();
            this.cBlue = new Guna.UI2.WinForms.Guna2Button();
            this.cPink = new Guna.UI2.WinForms.Guna2Button();
            this.cWhite = new Guna.UI2.WinForms.Guna2Button();
            this.cBlack = new Guna.UI2.WinForms.Guna2Button();
            this.othersTitle = new System.Windows.Forms.Label();
            this.masksTitle = new System.Windows.Forms.Label();
            this.animatedCapesTitle = new System.Windows.Forms.Label();
            this.capesTitle = new System.Windows.Forms.Label();
            this.cosmeticsTabLabel = new System.Windows.Forms.Label();
            this.cosmeticsBackground = new System.Windows.Forms.PictureBox();
            this.versionsTab = new System.Windows.Forms.TabPage();
            this.settingsTab = new System.Windows.Forms.TabPage();
            this.settingsTabLabel = new System.Windows.Forms.Label();
            this.settingsPagesTabControl = new Guna.UI2.WinForms.Guna2TabControl();
            this.Launcher = new System.Windows.Forms.TabPage();
            this.injectDelayLabel = new System.Windows.Forms.Label();
            this.injectDelay = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.rpcButtonTextLabel = new System.Windows.Forms.Label();
            this.rpcLine = new System.Windows.Forms.MaskedTextBox();
            this.buttonForRpc = new Guna.UI2.WinForms.Guna2Button();
            this.rpcButtonLinkLabel = new System.Windows.Forms.Label();
            this.rpcButtonText = new System.Windows.Forms.MaskedTextBox();
            this.rpcButtonLink = new System.Windows.Forms.MaskedTextBox();
            this.windowStateLabel = new System.Windows.Forms.Label();
            this.hideWindow = new Guna.UI2.WinForms.Guna2Button();
            this.minWindow = new Guna.UI2.WinForms.Guna2Button();
            this.richPresenceLabel = new System.Windows.Forms.Label();
            this.closeWindow = new Guna.UI2.WinForms.Guna2Button();
            this.devDLLLabel = new System.Windows.Forms.Label();
            this.RpcToggle = new Guna.UI2.WinForms.Guna2Button();
            this.resourceLabel = new System.Windows.Forms.Label();
            this.autoLabel = new System.Windows.Forms.Label();
            this.customDLLButton = new Guna.UI2.WinForms.Guna2Button();
            this.DefaultDLLSelector = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
            this.openWindow = new Guna.UI2.WinForms.Guna2Button();
            this.autoInject = new Guna.UI2.WinForms.Guna2Button();
            this.customLoc = new Guna.UI2.WinForms.Guna2Button();
            this.AppearanceButton = new Guna.UI2.WinForms.Guna2Button();
            this.Appearance = new System.Windows.Forms.TabPage();
            this.foreColorLabel = new System.Windows.Forms.Label();
            this.buttonColorLabel = new System.Windows.Forms.Label();
            this.preset8 = new Guna.UI2.WinForms.Guna2Panel();
            this.presets = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
            this.saveToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preset7 = new Guna.UI2.WinForms.Guna2Panel();
            this.preset6 = new Guna.UI2.WinForms.Guna2Panel();
            this.preset5 = new Guna.UI2.WinForms.Guna2Panel();
            this.preset4 = new Guna.UI2.WinForms.Guna2Panel();
            this.preset3 = new Guna.UI2.WinForms.Guna2Panel();
            this.preset2 = new Guna.UI2.WinForms.Guna2Panel();
            this.textBrightnessSlider = new Guna.UI2.WinForms.Guna2TrackBar();
            this.buttonBrightnessSlider = new Guna.UI2.WinForms.Guna2TrackBar();
            this.outlineBrightnessSlider = new Guna.UI2.WinForms.Guna2TrackBar();
            this.accentBlueSlider = new Guna.UI2.WinForms.Guna2TrackBar();
            this.accentGreenSlider = new Guna.UI2.WinForms.Guna2TrackBar();
            this.accentRedSlider = new Guna.UI2.WinForms.Guna2TrackBar();
            this.backgroundBrightnessSlider = new Guna.UI2.WinForms.Guna2TrackBar();
            this.preset1 = new Guna.UI2.WinForms.Guna2Panel();
            this.presetsLabel = new System.Windows.Forms.Label();
            this.resetThemes = new Guna.UI2.WinForms.Guna2Button();
            this.foreBT = new System.Windows.Forms.Label();
            this.labelForSlider5 = new System.Windows.Forms.Label();
            this.accentBT = new System.Windows.Forms.Label();
            this.accentGT = new System.Windows.Forms.Label();
            this.accentRT = new System.Windows.Forms.Label();
            this.labelForSlider2 = new System.Windows.Forms.Label();
            this.accentColorLabel = new System.Windows.Forms.Label();
            this.ExtrasButton = new Guna.UI2.WinForms.Guna2Button();
            this.LauncherButton = new Guna.UI2.WinForms.Guna2Button();
            this.theme = new Guna.UI2.WinForms.Guna2Button();
            this.outlineOT = new System.Windows.Forms.Label();
            this.labelForSlider3 = new System.Windows.Forms.Label();
            this.outlineColorLabel = new System.Windows.Forms.Label();
            this.buttonBuT = new System.Windows.Forms.Label();
            this.labelForSlider4 = new System.Windows.Forms.Label();
            this.backgroundBT = new System.Windows.Forms.Label();
            this.labelForSlider1 = new System.Windows.Forms.Label();
            this.backgroundColorLabel = new System.Windows.Forms.Label();
            this.themeTitle = new System.Windows.Forms.Label();
            this.Extras = new System.Windows.Forms.TabPage();
            this.performanceModeToggle = new Guna.UI2.WinForms.Guna2Button();
            this.performanceModeTitle = new System.Windows.Forms.Label();
            this.toastsSelector = new Guna.UI2.WinForms.Guna2ComboBox();
            this.customImage = new Guna.UI2.WinForms.Guna2Button();
            this.backImageTitle = new System.Windows.Forms.Label();
            this.roundedToggle = new Guna.UI2.WinForms.Guna2Button();
            this.roundedTitle = new System.Windows.Forms.Label();
            this.toastsToggle = new Guna.UI2.WinForms.Guna2Button();
            this.AppearanceButton2 = new Guna.UI2.WinForms.Guna2Button();
            this.toastsTitle = new System.Windows.Forms.Label();
            this.aboutTab = new System.Windows.Forms.TabPage();
            this.changeLogLink = new System.Windows.Forms.LinkLabel();
            this.cosmeticsVLabel = new System.Windows.Forms.Label();
            this.clientVLabel = new System.Windows.Forms.Label();
            this.launcherVLabel = new System.Windows.Forms.Label();
            this.website = new System.Windows.Forms.PictureBox();
            this.discord = new System.Windows.Forms.PictureBox();
            this.launcherBy = new System.Windows.Forms.Label();
            this.aboutSeparator = new System.Windows.Forms.PictureBox();
            this.clientLabel = new System.Windows.Forms.Label();
            this.cosmeticsLabel = new System.Windows.Forms.Label();
            this.aboutTabLabel = new System.Windows.Forms.Label();
            this.launcherLabel = new System.Windows.Forms.Label();
            this.aboutDesc = new System.Windows.Forms.Label();
            this.aboutBackgroundColor = new System.Windows.Forms.PictureBox();
            this.TrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.TrayIconContextMenu = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.injectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FadeEffectBetweenPages = new Guna.UI2.WinForms.Guna2Transition();
            this.internetCheckTimer = new System.Windows.Forms.Timer(this.components);
            this.dragBar.SuspendLayout();
            this.sidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.versionButtonIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aboutButtonIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.settingsButtonIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cosmeticsButtonIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.homeButtonIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            this.contentView.SuspendLayout();
            this.homeTab.SuspendLayout();
            this.cosmeticsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cosmeticsBackground)).BeginInit();
            this.settingsTab.SuspendLayout();
            this.settingsPagesTabControl.SuspendLayout();
            this.Launcher.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.injectDelay)).BeginInit();
            this.Appearance.SuspendLayout();
            this.presets.SuspendLayout();
            this.Extras.SuspendLayout();
            this.aboutTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.website)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.discord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aboutSeparator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aboutBackgroundColor)).BeginInit();
            this.TrayIconContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // dragBar
            // 
            this.dragBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.dragBar.Controls.Add(this.minimizeButton);
            this.dragBar.Controls.Add(this.closeButton);
            this.FadeEffectBetweenPages.SetDecoration(this.dragBar, Guna.UI2.AnimatorNS.DecorationType.None);
            this.dragBar.Location = new System.Drawing.Point(0, 0);
            this.dragBar.Name = "dragBar";
            this.dragBar.ShadowDecoration.Parent = this.dragBar;
            this.dragBar.Size = new System.Drawing.Size(813, 25);
            this.dragBar.TabIndex = 0;
            // 
            // minimizeButton
            // 
            this.minimizeButton.Animated = true;
            this.minimizeButton.BackColor = System.Drawing.Color.Transparent;
            this.minimizeButton.CheckedState.Parent = this.minimizeButton;
            this.minimizeButton.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.minimizeButton.CustomImages.Parent = this.minimizeButton;
            this.FadeEffectBetweenPages.SetDecoration(this.minimizeButton, Guna.UI2.AnimatorNS.DecorationType.None);
            this.minimizeButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.minimizeButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.minimizeButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.minimizeButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.minimizeButton.DisabledState.Parent = this.minimizeButton;
            this.minimizeButton.FillColor = System.Drawing.Color.Transparent;
            this.minimizeButton.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold);
            this.minimizeButton.ForeColor = System.Drawing.Color.White;
            this.minimizeButton.HoverState.Parent = this.minimizeButton;
            this.minimizeButton.Location = new System.Drawing.Point(741, -8);
            this.minimizeButton.Name = "minimizeButton";
            this.minimizeButton.ShadowDecoration.Parent = this.minimizeButton;
            this.minimizeButton.Size = new System.Drawing.Size(35, 38);
            this.minimizeButton.TabIndex = 1;
            this.minimizeButton.Text = "-";
            this.minimizeButton.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.minimizeButton.UseTransparentBackground = true;
            this.minimizeButton.Click += new System.EventHandler(this.minimizeButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Animated = true;
            this.closeButton.BackColor = System.Drawing.Color.Transparent;
            this.closeButton.CheckedState.Parent = this.closeButton;
            this.closeButton.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.closeButton.CustomImages.Parent = this.closeButton;
            this.FadeEffectBetweenPages.SetDecoration(this.closeButton, Guna.UI2.AnimatorNS.DecorationType.None);
            this.closeButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.closeButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.closeButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.closeButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.closeButton.DisabledState.Parent = this.closeButton;
            this.closeButton.FillColor = System.Drawing.Color.Transparent;
            this.closeButton.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.closeButton.ForeColor = System.Drawing.Color.White;
            this.closeButton.HoverState.Parent = this.closeButton;
            this.closeButton.Location = new System.Drawing.Point(778, -5);
            this.closeButton.Name = "closeButton";
            this.closeButton.ShadowDecoration.Parent = this.closeButton;
            this.closeButton.Size = new System.Drawing.Size(35, 35);
            this.closeButton.TabIndex = 0;
            this.closeButton.Text = "X";
            this.closeButton.UseTransparentBackground = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // dragWindowControl
            // 
            this.dragWindowControl.TargetControl = this.dragBar;
            // 
            // sidebar
            // 
            this.sidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.sidebar.Controls.Add(this.versionButton);
            this.sidebar.Controls.Add(this.versionButtonIcon);
            this.sidebar.Controls.Add(this.homeButton);
            this.sidebar.Controls.Add(this.version);
            this.sidebar.Controls.Add(this.aboutButton);
            this.sidebar.Controls.Add(this.aboutButtonIcon);
            this.sidebar.Controls.Add(this.settingsButton);
            this.sidebar.Controls.Add(this.settingsButtonIcon);
            this.sidebar.Controls.Add(this.cosmeticsButton);
            this.sidebar.Controls.Add(this.cosmeticsButtonIcon);
            this.sidebar.Controls.Add(this.homeButtonIcon);
            this.sidebar.Controls.Add(this.launcherTitle);
            this.sidebar.Controls.Add(this.line);
            this.sidebar.Controls.Add(this.logo);
            this.FadeEffectBetweenPages.SetDecoration(this.sidebar, Guna.UI2.AnimatorNS.DecorationType.None);
            this.sidebar.Location = new System.Drawing.Point(0, 24);
            this.sidebar.Name = "sidebar";
            this.sidebar.ShadowDecoration.Parent = this.sidebar;
            this.sidebar.Size = new System.Drawing.Size(170, 468);
            this.sidebar.TabIndex = 1;
            // 
            // versionButton
            // 
            this.versionButton.Animated = true;
            this.versionButton.BackColor = System.Drawing.Color.Transparent;
            this.versionButton.CheckedState.Parent = this.versionButton;
            this.versionButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.versionButton.CustomImages.Parent = this.versionButton;
            this.FadeEffectBetweenPages.SetDecoration(this.versionButton, Guna.UI2.AnimatorNS.DecorationType.None);
            this.versionButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.versionButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.versionButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.versionButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.versionButton.DisabledState.Parent = this.versionButton;
            this.versionButton.FillColor = System.Drawing.Color.Transparent;
            this.versionButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.versionButton.ForeColor = System.Drawing.Color.White;
            this.versionButton.HoverState.Parent = this.versionButton;
            this.versionButton.Location = new System.Drawing.Point(0, 264);
            this.versionButton.Name = "versionButton";
            this.versionButton.ShadowDecoration.Parent = this.versionButton;
            this.versionButton.Size = new System.Drawing.Size(170, 52);
            this.versionButton.TabIndex = 15;
            this.versionButton.Text = "Version";
            this.versionButton.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.versionButton.TextOffset = new System.Drawing.Point(55, 0);
            this.versionButton.UseTransparentBackground = true;
            this.versionButton.Click += new System.EventHandler(this.versionButton_Click);
            // 
            // versionButtonIcon
            // 
            this.versionButtonIcon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.FadeEffectBetweenPages.SetDecoration(this.versionButtonIcon, Guna.UI2.AnimatorNS.DecorationType.None);
            this.versionButtonIcon.ForeColor = System.Drawing.Color.RoyalBlue;
            this.versionButtonIcon.IconChar = FontAwesome.Sharp.IconChar.CodeBranch;
            this.versionButtonIcon.IconColor = System.Drawing.Color.RoyalBlue;
            this.versionButtonIcon.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.versionButtonIcon.IconSize = 48;
            this.versionButtonIcon.Location = new System.Drawing.Point(11, 268);
            this.versionButtonIcon.Name = "versionButtonIcon";
            this.versionButtonIcon.Size = new System.Drawing.Size(48, 48);
            this.versionButtonIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.versionButtonIcon.TabIndex = 16;
            this.versionButtonIcon.TabStop = false;
            // 
            // homeButton
            // 
            this.homeButton.Animated = true;
            this.homeButton.BackColor = System.Drawing.Color.Transparent;
            this.homeButton.CheckedState.Parent = this.homeButton;
            this.homeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.homeButton.CustomImages.Parent = this.homeButton;
            this.FadeEffectBetweenPages.SetDecoration(this.homeButton, Guna.UI2.AnimatorNS.DecorationType.None);
            this.homeButton.DisabledState.Parent = this.homeButton;
            this.homeButton.FillColor = System.Drawing.Color.Transparent;
            this.homeButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.homeButton.ForeColor = System.Drawing.Color.White;
            this.homeButton.HoverState.Parent = this.homeButton;
            this.homeButton.Location = new System.Drawing.Point(0, 154);
            this.homeButton.Name = "homeButton";
            this.homeButton.ShadowDecoration.Parent = this.homeButton;
            this.homeButton.Size = new System.Drawing.Size(170, 52);
            this.homeButton.TabIndex = 2;
            this.homeButton.Text = "Home";
            this.homeButton.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.homeButton.TextOffset = new System.Drawing.Point(55, 0);
            this.homeButton.UseTransparentBackground = true;
            this.homeButton.Click += new System.EventHandler(this.homeButton_Click);
            // 
            // version
            // 
            this.FadeEffectBetweenPages.SetDecoration(this.version, Guna.UI2.AnimatorNS.DecorationType.None);
            this.version.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.version.ForeColor = System.Drawing.Color.Silver;
            this.version.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.version.Location = new System.Drawing.Point(0, 441);
            this.version.Name = "version";
            this.version.Size = new System.Drawing.Size(170, 25);
            this.version.TabIndex = 14;
            this.version.Text = "Version";
            this.version.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // aboutButton
            // 
            this.aboutButton.Animated = true;
            this.aboutButton.BackColor = System.Drawing.Color.Transparent;
            this.aboutButton.CheckedState.Parent = this.aboutButton;
            this.aboutButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.aboutButton.CustomImages.Parent = this.aboutButton;
            this.FadeEffectBetweenPages.SetDecoration(this.aboutButton, Guna.UI2.AnimatorNS.DecorationType.None);
            this.aboutButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.aboutButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.aboutButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.aboutButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.aboutButton.DisabledState.Parent = this.aboutButton;
            this.aboutButton.FillColor = System.Drawing.Color.Transparent;
            this.aboutButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.aboutButton.ForeColor = System.Drawing.Color.White;
            this.aboutButton.HoverState.Parent = this.aboutButton;
            this.aboutButton.Location = new System.Drawing.Point(0, 374);
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.ShadowDecoration.Parent = this.aboutButton;
            this.aboutButton.Size = new System.Drawing.Size(170, 52);
            this.aboutButton.TabIndex = 12;
            this.aboutButton.Text = "About";
            this.aboutButton.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.aboutButton.TextOffset = new System.Drawing.Point(55, 0);
            this.aboutButton.UseTransparentBackground = true;
            this.aboutButton.Click += new System.EventHandler(this.aboutButton_Click);
            // 
            // aboutButtonIcon
            // 
            this.aboutButtonIcon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.FadeEffectBetweenPages.SetDecoration(this.aboutButtonIcon, Guna.UI2.AnimatorNS.DecorationType.None);
            this.aboutButtonIcon.ForeColor = System.Drawing.Color.RoyalBlue;
            this.aboutButtonIcon.IconChar = FontAwesome.Sharp.IconChar.Info;
            this.aboutButtonIcon.IconColor = System.Drawing.Color.RoyalBlue;
            this.aboutButtonIcon.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.aboutButtonIcon.IconSize = 48;
            this.aboutButtonIcon.Location = new System.Drawing.Point(10, 378);
            this.aboutButtonIcon.Name = "aboutButtonIcon";
            this.aboutButtonIcon.Size = new System.Drawing.Size(48, 48);
            this.aboutButtonIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.aboutButtonIcon.TabIndex = 13;
            this.aboutButtonIcon.TabStop = false;
            // 
            // settingsButton
            // 
            this.settingsButton.Animated = true;
            this.settingsButton.BackColor = System.Drawing.Color.Transparent;
            this.settingsButton.CheckedState.Parent = this.settingsButton;
            this.settingsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.settingsButton.CustomImages.Parent = this.settingsButton;
            this.FadeEffectBetweenPages.SetDecoration(this.settingsButton, Guna.UI2.AnimatorNS.DecorationType.None);
            this.settingsButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.settingsButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.settingsButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.settingsButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.settingsButton.DisabledState.Parent = this.settingsButton;
            this.settingsButton.FillColor = System.Drawing.Color.Transparent;
            this.settingsButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.settingsButton.ForeColor = System.Drawing.Color.White;
            this.settingsButton.HoverState.Parent = this.settingsButton;
            this.settingsButton.Location = new System.Drawing.Point(0, 319);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.ShadowDecoration.Parent = this.settingsButton;
            this.settingsButton.Size = new System.Drawing.Size(170, 52);
            this.settingsButton.TabIndex = 10;
            this.settingsButton.Text = "Settings";
            this.settingsButton.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.settingsButton.TextOffset = new System.Drawing.Point(55, 0);
            this.settingsButton.UseTransparentBackground = true;
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // settingsButtonIcon
            // 
            this.settingsButtonIcon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.FadeEffectBetweenPages.SetDecoration(this.settingsButtonIcon, Guna.UI2.AnimatorNS.DecorationType.None);
            this.settingsButtonIcon.ForeColor = System.Drawing.Color.RoyalBlue;
            this.settingsButtonIcon.IconChar = FontAwesome.Sharp.IconChar.Cog;
            this.settingsButtonIcon.IconColor = System.Drawing.Color.RoyalBlue;
            this.settingsButtonIcon.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.settingsButtonIcon.IconSize = 48;
            this.settingsButtonIcon.Location = new System.Drawing.Point(10, 323);
            this.settingsButtonIcon.Name = "settingsButtonIcon";
            this.settingsButtonIcon.Size = new System.Drawing.Size(48, 48);
            this.settingsButtonIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.settingsButtonIcon.TabIndex = 11;
            this.settingsButtonIcon.TabStop = false;
            // 
            // cosmeticsButton
            // 
            this.cosmeticsButton.Animated = true;
            this.cosmeticsButton.BackColor = System.Drawing.Color.Transparent;
            this.cosmeticsButton.CheckedState.Parent = this.cosmeticsButton;
            this.cosmeticsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cosmeticsButton.CustomImages.Parent = this.cosmeticsButton;
            this.FadeEffectBetweenPages.SetDecoration(this.cosmeticsButton, Guna.UI2.AnimatorNS.DecorationType.None);
            this.cosmeticsButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.cosmeticsButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.cosmeticsButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.cosmeticsButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.cosmeticsButton.DisabledState.Parent = this.cosmeticsButton;
            this.cosmeticsButton.FillColor = System.Drawing.Color.Transparent;
            this.cosmeticsButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.cosmeticsButton.ForeColor = System.Drawing.Color.White;
            this.cosmeticsButton.HoverState.Parent = this.cosmeticsButton;
            this.cosmeticsButton.Location = new System.Drawing.Point(0, 209);
            this.cosmeticsButton.Name = "cosmeticsButton";
            this.cosmeticsButton.ShadowDecoration.Parent = this.cosmeticsButton;
            this.cosmeticsButton.Size = new System.Drawing.Size(170, 52);
            this.cosmeticsButton.TabIndex = 8;
            this.cosmeticsButton.Text = "Cosmetics";
            this.cosmeticsButton.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.cosmeticsButton.TextOffset = new System.Drawing.Point(55, 0);
            this.cosmeticsButton.UseTransparentBackground = true;
            this.cosmeticsButton.Click += new System.EventHandler(this.cosmeticsButton_Click);
            // 
            // cosmeticsButtonIcon
            // 
            this.cosmeticsButtonIcon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.FadeEffectBetweenPages.SetDecoration(this.cosmeticsButtonIcon, Guna.UI2.AnimatorNS.DecorationType.None);
            this.cosmeticsButtonIcon.ForeColor = System.Drawing.Color.RoyalBlue;
            this.cosmeticsButtonIcon.IconChar = FontAwesome.Sharp.IconChar.Tshirt;
            this.cosmeticsButtonIcon.IconColor = System.Drawing.Color.RoyalBlue;
            this.cosmeticsButtonIcon.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.cosmeticsButtonIcon.IconSize = 48;
            this.cosmeticsButtonIcon.Location = new System.Drawing.Point(10, 212);
            this.cosmeticsButtonIcon.Name = "cosmeticsButtonIcon";
            this.cosmeticsButtonIcon.Size = new System.Drawing.Size(48, 48);
            this.cosmeticsButtonIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.cosmeticsButtonIcon.TabIndex = 9;
            this.cosmeticsButtonIcon.TabStop = false;
            // 
            // homeButtonIcon
            // 
            this.homeButtonIcon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.FadeEffectBetweenPages.SetDecoration(this.homeButtonIcon, Guna.UI2.AnimatorNS.DecorationType.None);
            this.homeButtonIcon.ForeColor = System.Drawing.Color.RoyalBlue;
            this.homeButtonIcon.IconChar = FontAwesome.Sharp.IconChar.Home;
            this.homeButtonIcon.IconColor = System.Drawing.Color.RoyalBlue;
            this.homeButtonIcon.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.homeButtonIcon.IconSize = 48;
            this.homeButtonIcon.Location = new System.Drawing.Point(10, 157);
            this.homeButtonIcon.Name = "homeButtonIcon";
            this.homeButtonIcon.Size = new System.Drawing.Size(48, 48);
            this.homeButtonIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.homeButtonIcon.TabIndex = 2;
            this.homeButtonIcon.TabStop = false;
            // 
            // launcherTitle
            // 
            this.launcherTitle.AutoSize = true;
            this.FadeEffectBetweenPages.SetDecoration(this.launcherTitle, Guna.UI2.AnimatorNS.DecorationType.None);
            this.launcherTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.launcherTitle.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.launcherTitle.ForeColor = System.Drawing.Color.White;
            this.launcherTitle.Location = new System.Drawing.Point(16, 103);
            this.launcherTitle.Name = "launcherTitle";
            this.launcherTitle.Size = new System.Drawing.Size(144, 30);
            this.launcherTitle.TabIndex = 2;
            this.launcherTitle.Text = "Ventile Client";
            this.launcherTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // line
            // 
            this.line.BackColor = System.Drawing.Color.Transparent;
            this.line.Cursor = System.Windows.Forms.Cursors.Default;
            this.FadeEffectBetweenPages.SetDecoration(this.line, Guna.UI2.AnimatorNS.DecorationType.None);
            this.line.FlatAppearance.BorderSize = 0;
            this.line.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.line.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.line.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.line.Font = new System.Drawing.Font("Segoe UI Black", 15.75F, System.Drawing.FontStyle.Bold);
            this.line.ForeColor = System.Drawing.Color.White;
            this.line.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.line.Location = new System.Drawing.Point(0, 110);
            this.line.Name = "line";
            this.line.Size = new System.Drawing.Size(169, 39);
            this.line.TabIndex = 7;
            this.line.TabStop = false;
            this.line.Text = "_________";
            this.line.UseVisualStyleBackColor = false;
            // 
            // logo
            // 
            this.logo.BackColor = System.Drawing.Color.Transparent;
            this.FadeEffectBetweenPages.SetDecoration(this.logo, Guna.UI2.AnimatorNS.DecorationType.None);
            this.logo.FillColor = System.Drawing.Color.Transparent;
            this.logo.Image = global::VentileClient.Properties.Resources.transparent_logo_white;
            this.logo.ImageRotate = 0F;
            this.logo.Location = new System.Drawing.Point(35, 10);
            this.logo.Name = "logo";
            this.logo.ShadowDecoration.Parent = this.logo;
            this.logo.Size = new System.Drawing.Size(100, 100);
            this.logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logo.TabIndex = 2;
            this.logo.TabStop = false;
            this.logo.UseTransparentBackground = true;
            // 
            // fadeIn
            // 
            this.fadeIn.Interval = 1;
            this.fadeIn.Tick += new System.EventHandler(this.fadeIn_Tick);
            // 
            // fadeOut
            // 
            this.fadeOut.Interval = 1;
            this.fadeOut.Tick += new System.EventHandler(this.fadeOut_Tick);
            // 
            // tick
            // 
            this.tick.Enabled = true;
            this.tick.Interval = 250;
            this.tick.Tick += new System.EventHandler(this.tick_Tick);
            // 
            // contentView
            // 
            this.contentView.Alignment = System.Windows.Forms.TabAlignment.Right;
            this.contentView.Controls.Add(this.homeTab);
            this.contentView.Controls.Add(this.cosmeticsTab);
            this.contentView.Controls.Add(this.versionsTab);
            this.contentView.Controls.Add(this.settingsTab);
            this.contentView.Controls.Add(this.aboutTab);
            this.FadeEffectBetweenPages.SetDecoration(this.contentView, Guna.UI2.AnimatorNS.DecorationType.None);
            this.contentView.ItemSize = new System.Drawing.Size(40, 40);
            this.contentView.Location = new System.Drawing.Point(165, 21);
            this.contentView.Margin = new System.Windows.Forms.Padding(0);
            this.contentView.Name = "contentView";
            this.contentView.Padding = new System.Drawing.Point(0, 0);
            this.contentView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.contentView.SelectedIndex = 0;
            this.contentView.Size = new System.Drawing.Size(653, 473);
            this.contentView.TabButtonHoverState.BorderColor = System.Drawing.Color.Empty;
            this.contentView.TabButtonHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.contentView.TabButtonHoverState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.contentView.TabButtonHoverState.ForeColor = System.Drawing.Color.White;
            this.contentView.TabButtonHoverState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.contentView.TabButtonIdleState.BorderColor = System.Drawing.Color.Empty;
            this.contentView.TabButtonIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.contentView.TabButtonIdleState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.contentView.TabButtonIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(160)))), ((int)(((byte)(167)))));
            this.contentView.TabButtonIdleState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.contentView.TabButtonSelectedState.BorderColor = System.Drawing.Color.Empty;
            this.contentView.TabButtonSelectedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(37)))), ((int)(((byte)(49)))));
            this.contentView.TabButtonSelectedState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.contentView.TabButtonSelectedState.ForeColor = System.Drawing.Color.White;
            this.contentView.TabButtonSelectedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(132)))), ((int)(((byte)(255)))));
            this.contentView.TabButtonSize = new System.Drawing.Size(40, 40);
            this.contentView.TabIndex = 0;
            this.contentView.TabMenuBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.contentView.TabMenuOrientation = Guna.UI2.WinForms.TabMenuOrientation.VerticalRight;
            this.contentView.TabMenuVisible = false;
            this.contentView.TabStop = false;
            // 
            // homeTab
            // 
            this.homeTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.homeTab.BackgroundImage = global::VentileClient.Properties.Resources.background;
            this.homeTab.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.homeTab.Controls.Add(this.launchMc);
            this.homeTab.Controls.Add(this.inject);
            this.homeTab.Controls.Add(this.selectDll);
            this.FadeEffectBetweenPages.SetDecoration(this.homeTab, Guna.UI2.AnimatorNS.DecorationType.None);
            this.homeTab.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.homeTab.ForeColor = System.Drawing.Color.White;
            this.homeTab.Location = new System.Drawing.Point(4, 4);
            this.homeTab.Margin = new System.Windows.Forms.Padding(0);
            this.homeTab.Name = "homeTab";
            this.homeTab.Size = new System.Drawing.Size(644, 465);
            this.homeTab.TabIndex = 0;
            this.homeTab.Text = "home";
            // 
            // launchMc
            // 
            this.launchMc.Animated = true;
            this.launchMc.BackColor = System.Drawing.Color.Transparent;
            this.launchMc.CheckedState.Parent = this.launchMc;
            this.launchMc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.launchMc.CustomBorderColor = System.Drawing.Color.Black;
            this.launchMc.CustomBorderThickness = new System.Windows.Forms.Padding(3);
            this.launchMc.CustomImages.Parent = this.launchMc;
            this.FadeEffectBetweenPages.SetDecoration(this.launchMc, Guna.UI2.AnimatorNS.DecorationType.None);
            this.launchMc.DisabledState.Parent = this.launchMc;
            this.launchMc.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.launchMc.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold);
            this.launchMc.ForeColor = System.Drawing.Color.White;
            this.launchMc.HoverState.Parent = this.launchMc;
            this.launchMc.Location = new System.Drawing.Point(163, 170);
            this.launchMc.Name = "launchMc";
            this.launchMc.ShadowDecoration.Parent = this.launchMc;
            this.launchMc.Size = new System.Drawing.Size(318, 73);
            this.launchMc.TabIndex = 89;
            this.launchMc.TabStop = false;
            this.launchMc.Text = "Launch Minecraft";
            this.launchMc.Click += new System.EventHandler(this.launchMc_Click);
            // 
            // inject
            // 
            this.inject.Animated = true;
            this.inject.CheckedState.Parent = this.inject;
            this.inject.Cursor = System.Windows.Forms.Cursors.Hand;
            this.inject.CustomBorderColor = System.Drawing.Color.Black;
            this.inject.CustomBorderThickness = new System.Windows.Forms.Padding(3);
            this.inject.CustomImages.Parent = this.inject;
            this.FadeEffectBetweenPages.SetDecoration(this.inject, Guna.UI2.AnimatorNS.DecorationType.None);
            this.inject.DisabledState.Parent = this.inject;
            this.inject.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.inject.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.inject.ForeColor = System.Drawing.Color.White;
            this.inject.HoverState.Parent = this.inject;
            this.inject.Location = new System.Drawing.Point(351, 249);
            this.inject.Name = "inject";
            this.inject.ShadowDecoration.Parent = this.inject;
            this.inject.Size = new System.Drawing.Size(130, 39);
            this.inject.TabIndex = 91;
            this.inject.TabStop = false;
            this.inject.Text = "Inject";
            this.inject.Click += new System.EventHandler(this.inject_Click);
            // 
            // selectDll
            // 
            this.selectDll.Animated = true;
            this.selectDll.CheckedState.Parent = this.selectDll;
            this.selectDll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.selectDll.CustomBorderColor = System.Drawing.Color.Black;
            this.selectDll.CustomBorderThickness = new System.Windows.Forms.Padding(3);
            this.selectDll.CustomImages.Parent = this.selectDll;
            this.FadeEffectBetweenPages.SetDecoration(this.selectDll, Guna.UI2.AnimatorNS.DecorationType.None);
            this.selectDll.DisabledState.Parent = this.selectDll;
            this.selectDll.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.selectDll.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.selectDll.ForeColor = System.Drawing.Color.White;
            this.selectDll.HoverState.Parent = this.selectDll;
            this.selectDll.Location = new System.Drawing.Point(163, 249);
            this.selectDll.Name = "selectDll";
            this.selectDll.ShadowDecoration.Parent = this.selectDll;
            this.selectDll.Size = new System.Drawing.Size(182, 39);
            this.selectDll.TabIndex = 90;
            this.selectDll.TabStop = false;
            this.selectDll.Text = "Select DLL";
            this.selectDll.Click += new System.EventHandler(this.selectDll_Click);
            // 
            // cosmeticsTab
            // 
            this.cosmeticsTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cosmeticsTab.BackgroundImage = global::VentileClient.Properties.Resources.background;
            this.cosmeticsTab.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cosmeticsTab.Controls.Add(this.oKagune);
            this.cosmeticsTab.Controls.Add(this.oWavy);
            this.cosmeticsTab.Controls.Add(this.aSlide);
            this.cosmeticsTab.Controls.Add(this.aGlowing);
            this.cosmeticsTab.Controls.Add(this.mRick);
            this.cosmeticsTab.Controls.Add(this.mYellow);
            this.cosmeticsTab.Controls.Add(this.mBlue);
            this.cosmeticsTab.Controls.Add(this.mPink);
            this.cosmeticsTab.Controls.Add(this.mWhite);
            this.cosmeticsTab.Controls.Add(this.mBlack);
            this.cosmeticsTab.Controls.Add(this.resetAllCosmetics);
            this.cosmeticsTab.Controls.Add(this.cRick);
            this.cosmeticsTab.Controls.Add(this.cYellow);
            this.cosmeticsTab.Controls.Add(this.cBlue);
            this.cosmeticsTab.Controls.Add(this.cPink);
            this.cosmeticsTab.Controls.Add(this.cWhite);
            this.cosmeticsTab.Controls.Add(this.cBlack);
            this.cosmeticsTab.Controls.Add(this.othersTitle);
            this.cosmeticsTab.Controls.Add(this.masksTitle);
            this.cosmeticsTab.Controls.Add(this.animatedCapesTitle);
            this.cosmeticsTab.Controls.Add(this.capesTitle);
            this.cosmeticsTab.Controls.Add(this.cosmeticsTabLabel);
            this.cosmeticsTab.Controls.Add(this.cosmeticsBackground);
            this.FadeEffectBetweenPages.SetDecoration(this.cosmeticsTab, Guna.UI2.AnimatorNS.DecorationType.None);
            this.cosmeticsTab.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cosmeticsTab.ForeColor = System.Drawing.Color.White;
            this.cosmeticsTab.Location = new System.Drawing.Point(4, 4);
            this.cosmeticsTab.Name = "cosmeticsTab";
            this.cosmeticsTab.Size = new System.Drawing.Size(644, 465);
            this.cosmeticsTab.TabIndex = 1;
            this.cosmeticsTab.Text = "cosmetics";
            // 
            // oKagune
            // 
            this.oKagune.Animated = true;
            this.oKagune.AutoRoundedCorners = true;
            this.oKagune.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.oKagune.BorderRadius = 13;
            this.oKagune.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            this.oKagune.CheckedState.FillColor = System.Drawing.Color.RoyalBlue;
            this.oKagune.CheckedState.Parent = this.oKagune;
            this.oKagune.Cursor = System.Windows.Forms.Cursors.Hand;
            this.oKagune.CustomImages.Parent = this.oKagune;
            this.FadeEffectBetweenPages.SetDecoration(this.oKagune, Guna.UI2.AnimatorNS.DecorationType.None);
            this.oKagune.DisabledState.Parent = this.oKagune;
            this.oKagune.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.oKagune.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.oKagune.ForeColor = System.Drawing.Color.White;
            this.oKagune.HoverState.Parent = this.oKagune;
            this.oKagune.Location = new System.Drawing.Point(485, 185);
            this.oKagune.Name = "oKagune";
            this.oKagune.ShadowDecoration.Parent = this.oKagune;
            this.oKagune.Size = new System.Drawing.Size(141, 29);
            this.oKagune.TabIndex = 113;
            this.oKagune.TabStop = false;
            this.oKagune.Tag = "c7e73878-9d01-11eb-a8b3-0242ac130003";
            this.oKagune.Text = "Kagune";
            this.oKagune.Click += new System.EventHandler(this.oKagune_Click);
            // 
            // oWavy
            // 
            this.oWavy.Animated = true;
            this.oWavy.AutoRoundedCorners = true;
            this.oWavy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.oWavy.BorderRadius = 13;
            this.oWavy.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            this.oWavy.CheckedState.FillColor = System.Drawing.Color.RoyalBlue;
            this.oWavy.CheckedState.Parent = this.oWavy;
            this.oWavy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.oWavy.CustomImages.Parent = this.oWavy;
            this.FadeEffectBetweenPages.SetDecoration(this.oWavy, Guna.UI2.AnimatorNS.DecorationType.None);
            this.oWavy.DisabledState.Parent = this.oWavy;
            this.oWavy.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.oWavy.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.oWavy.ForeColor = System.Drawing.Color.White;
            this.oWavy.HoverState.Parent = this.oWavy;
            this.oWavy.Location = new System.Drawing.Point(485, 150);
            this.oWavy.Name = "oWavy";
            this.oWavy.ShadowDecoration.Parent = this.oWavy;
            this.oWavy.Size = new System.Drawing.Size(141, 29);
            this.oWavy.TabIndex = 112;
            this.oWavy.TabStop = false;
            this.oWavy.Tag = "be2492f2-d1d2-4396-99b9-85058eada547";
            this.oWavy.Text = "Wavy Overlay";
            this.oWavy.Click += new System.EventHandler(this.oWavy_Click);
            // 
            // aSlide
            // 
            this.aSlide.Animated = true;
            this.aSlide.AutoRoundedCorners = true;
            this.aSlide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.aSlide.BorderRadius = 13;
            this.aSlide.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            this.aSlide.CheckedState.FillColor = System.Drawing.Color.RoyalBlue;
            this.aSlide.CheckedState.Parent = this.aSlide;
            this.aSlide.Cursor = System.Windows.Forms.Cursors.Hand;
            this.aSlide.CustomImages.Parent = this.aSlide;
            this.FadeEffectBetweenPages.SetDecoration(this.aSlide, Guna.UI2.AnimatorNS.DecorationType.None);
            this.aSlide.DisabledState.Parent = this.aSlide;
            this.aSlide.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.aSlide.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.aSlide.ForeColor = System.Drawing.Color.White;
            this.aSlide.HoverState.Parent = this.aSlide;
            this.aSlide.Location = new System.Drawing.Point(329, 185);
            this.aSlide.Name = "aSlide";
            this.aSlide.ShadowDecoration.Parent = this.aSlide;
            this.aSlide.Size = new System.Drawing.Size(141, 29);
            this.aSlide.TabIndex = 111;
            this.aSlide.TabStop = false;
            this.aSlide.Tag = "bbf3d2cf-4b88-40e0-982e-e7cabeb5ab5e";
            this.aSlide.Text = "Slide";
            this.aSlide.Click += new System.EventHandler(this.aSlide_Click);
            // 
            // aGlowing
            // 
            this.aGlowing.Animated = true;
            this.aGlowing.AutoRoundedCorners = true;
            this.aGlowing.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.aGlowing.BorderRadius = 13;
            this.aGlowing.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            this.aGlowing.CheckedState.FillColor = System.Drawing.Color.RoyalBlue;
            this.aGlowing.CheckedState.Parent = this.aGlowing;
            this.aGlowing.Cursor = System.Windows.Forms.Cursors.Hand;
            this.aGlowing.CustomImages.Parent = this.aGlowing;
            this.FadeEffectBetweenPages.SetDecoration(this.aGlowing, Guna.UI2.AnimatorNS.DecorationType.None);
            this.aGlowing.DisabledState.Parent = this.aGlowing;
            this.aGlowing.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.aGlowing.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.aGlowing.ForeColor = System.Drawing.Color.White;
            this.aGlowing.HoverState.Parent = this.aGlowing;
            this.aGlowing.Location = new System.Drawing.Point(329, 150);
            this.aGlowing.Name = "aGlowing";
            this.aGlowing.ShadowDecoration.Parent = this.aGlowing;
            this.aGlowing.Size = new System.Drawing.Size(141, 29);
            this.aGlowing.TabIndex = 110;
            this.aGlowing.TabStop = false;
            this.aGlowing.Tag = "66954147-e59f-49dc-87b5-a18c4c6a9648";
            this.aGlowing.Text = "Glowing Pulse";
            this.aGlowing.Click += new System.EventHandler(this.aGlowing_Click);
            // 
            // mRick
            // 
            this.mRick.Animated = true;
            this.mRick.AutoRoundedCorners = true;
            this.mRick.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.mRick.BorderRadius = 13;
            this.mRick.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            this.mRick.CheckedState.FillColor = System.Drawing.Color.RoyalBlue;
            this.mRick.CheckedState.Parent = this.mRick;
            this.mRick.Cursor = System.Windows.Forms.Cursors.Hand;
            this.mRick.CustomImages.Parent = this.mRick;
            this.FadeEffectBetweenPages.SetDecoration(this.mRick, Guna.UI2.AnimatorNS.DecorationType.None);
            this.mRick.DisabledState.Parent = this.mRick;
            this.mRick.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.mRick.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.mRick.ForeColor = System.Drawing.Color.White;
            this.mRick.HoverState.Parent = this.mRick;
            this.mRick.Location = new System.Drawing.Point(171, 325);
            this.mRick.Name = "mRick";
            this.mRick.ShadowDecoration.Parent = this.mRick;
            this.mRick.Size = new System.Drawing.Size(141, 29);
            this.mRick.TabIndex = 109;
            this.mRick.TabStop = false;
            this.mRick.Tag = "03b61725-eec7-44ab-9315-aeef52e051e1";
            this.mRick.Text = "Rick Astley";
            this.mRick.Click += new System.EventHandler(this.mRick_Click);
            // 
            // mYellow
            // 
            this.mYellow.Animated = true;
            this.mYellow.AutoRoundedCorners = true;
            this.mYellow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.mYellow.BorderRadius = 13;
            this.mYellow.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            this.mYellow.CheckedState.FillColor = System.Drawing.Color.RoyalBlue;
            this.mYellow.CheckedState.Parent = this.mYellow;
            this.mYellow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.mYellow.CustomImages.Parent = this.mYellow;
            this.FadeEffectBetweenPages.SetDecoration(this.mYellow, Guna.UI2.AnimatorNS.DecorationType.None);
            this.mYellow.DisabledState.Parent = this.mYellow;
            this.mYellow.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.mYellow.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.mYellow.ForeColor = System.Drawing.Color.White;
            this.mYellow.HoverState.Parent = this.mYellow;
            this.mYellow.Location = new System.Drawing.Point(171, 290);
            this.mYellow.Name = "mYellow";
            this.mYellow.ShadowDecoration.Parent = this.mYellow;
            this.mYellow.Size = new System.Drawing.Size(141, 29);
            this.mYellow.TabIndex = 108;
            this.mYellow.TabStop = false;
            this.mYellow.Tag = "03b61725-eec7-44ab-9315-aeef52e051e1";
            this.mYellow.Text = "Yellow Gradient";
            this.mYellow.Click += new System.EventHandler(this.mYellow_Click);
            // 
            // mBlue
            // 
            this.mBlue.Animated = true;
            this.mBlue.AutoRoundedCorners = true;
            this.mBlue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.mBlue.BorderRadius = 13;
            this.mBlue.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            this.mBlue.CheckedState.FillColor = System.Drawing.Color.RoyalBlue;
            this.mBlue.CheckedState.Parent = this.mBlue;
            this.mBlue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.mBlue.CustomImages.Parent = this.mBlue;
            this.FadeEffectBetweenPages.SetDecoration(this.mBlue, Guna.UI2.AnimatorNS.DecorationType.None);
            this.mBlue.DisabledState.Parent = this.mBlue;
            this.mBlue.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.mBlue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.mBlue.ForeColor = System.Drawing.Color.White;
            this.mBlue.HoverState.Parent = this.mBlue;
            this.mBlue.Location = new System.Drawing.Point(172, 255);
            this.mBlue.Name = "mBlue";
            this.mBlue.ShadowDecoration.Parent = this.mBlue;
            this.mBlue.Size = new System.Drawing.Size(141, 29);
            this.mBlue.TabIndex = 107;
            this.mBlue.TabStop = false;
            this.mBlue.Tag = "03b61725-eec7-44ab-9315-aeef52e051e1";
            this.mBlue.Text = "Dark Blue Sky";
            this.mBlue.Click += new System.EventHandler(this.mBlue_Click);
            // 
            // mPink
            // 
            this.mPink.Animated = true;
            this.mPink.AutoRoundedCorners = true;
            this.mPink.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.mPink.BorderRadius = 13;
            this.mPink.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            this.mPink.CheckedState.FillColor = System.Drawing.Color.RoyalBlue;
            this.mPink.CheckedState.Parent = this.mPink;
            this.mPink.Cursor = System.Windows.Forms.Cursors.Hand;
            this.mPink.CustomImages.Parent = this.mPink;
            this.FadeEffectBetweenPages.SetDecoration(this.mPink, Guna.UI2.AnimatorNS.DecorationType.None);
            this.mPink.DisabledState.Parent = this.mPink;
            this.mPink.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.mPink.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.mPink.ForeColor = System.Drawing.Color.White;
            this.mPink.HoverState.Parent = this.mPink;
            this.mPink.Location = new System.Drawing.Point(171, 220);
            this.mPink.Name = "mPink";
            this.mPink.ShadowDecoration.Parent = this.mPink;
            this.mPink.Size = new System.Drawing.Size(141, 29);
            this.mPink.TabIndex = 106;
            this.mPink.TabStop = false;
            this.mPink.Tag = "03b61725-eec7-44ab-9315-aeef52e051e1";
            this.mPink.Text = "Pink Galaxy";
            this.mPink.Click += new System.EventHandler(this.mPink_Click);
            // 
            // mWhite
            // 
            this.mWhite.Animated = true;
            this.mWhite.AutoRoundedCorners = true;
            this.mWhite.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.mWhite.BorderRadius = 13;
            this.mWhite.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            this.mWhite.CheckedState.FillColor = System.Drawing.Color.RoyalBlue;
            this.mWhite.CheckedState.Parent = this.mWhite;
            this.mWhite.Cursor = System.Windows.Forms.Cursors.Hand;
            this.mWhite.CustomImages.Parent = this.mWhite;
            this.FadeEffectBetweenPages.SetDecoration(this.mWhite, Guna.UI2.AnimatorNS.DecorationType.None);
            this.mWhite.DisabledState.Parent = this.mWhite;
            this.mWhite.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.mWhite.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.mWhite.ForeColor = System.Drawing.Color.White;
            this.mWhite.HoverState.Parent = this.mWhite;
            this.mWhite.Location = new System.Drawing.Point(172, 185);
            this.mWhite.Name = "mWhite";
            this.mWhite.ShadowDecoration.Parent = this.mWhite;
            this.mWhite.Size = new System.Drawing.Size(141, 29);
            this.mWhite.TabIndex = 105;
            this.mWhite.TabStop = false;
            this.mWhite.Tag = "03b61725-eec7-44ab-9315-aeef52e051e1";
            this.mWhite.Text = "White";
            this.mWhite.Click += new System.EventHandler(this.mWhite_Click);
            // 
            // mBlack
            // 
            this.mBlack.Animated = true;
            this.mBlack.AutoRoundedCorners = true;
            this.mBlack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.mBlack.BorderRadius = 13;
            this.mBlack.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            this.mBlack.CheckedState.FillColor = System.Drawing.Color.RoyalBlue;
            this.mBlack.CheckedState.Parent = this.mBlack;
            this.mBlack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.mBlack.CustomImages.Parent = this.mBlack;
            this.FadeEffectBetweenPages.SetDecoration(this.mBlack, Guna.UI2.AnimatorNS.DecorationType.None);
            this.mBlack.DisabledState.Parent = this.mBlack;
            this.mBlack.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.mBlack.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.mBlack.ForeColor = System.Drawing.Color.White;
            this.mBlack.HoverState.Parent = this.mBlack;
            this.mBlack.Location = new System.Drawing.Point(172, 150);
            this.mBlack.Name = "mBlack";
            this.mBlack.ShadowDecoration.Parent = this.mBlack;
            this.mBlack.Size = new System.Drawing.Size(141, 29);
            this.mBlack.TabIndex = 104;
            this.mBlack.TabStop = false;
            this.mBlack.Tag = "03b61725-eec7-44ab-9315-aeef52e051e1";
            this.mBlack.Text = "Black";
            this.mBlack.Click += new System.EventHandler(this.mBlack_Click);
            // 
            // resetAllCosmetics
            // 
            this.resetAllCosmetics.Animated = true;
            this.resetAllCosmetics.AutoRoundedCorners = true;
            this.resetAllCosmetics.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.resetAllCosmetics.BorderRadius = 13;
            this.resetAllCosmetics.CheckedState.Parent = this.resetAllCosmetics;
            this.resetAllCosmetics.Cursor = System.Windows.Forms.Cursors.Hand;
            this.resetAllCosmetics.CustomImages.Parent = this.resetAllCosmetics;
            this.FadeEffectBetweenPages.SetDecoration(this.resetAllCosmetics, Guna.UI2.AnimatorNS.DecorationType.None);
            this.resetAllCosmetics.DisabledState.Parent = this.resetAllCosmetics;
            this.resetAllCosmetics.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.resetAllCosmetics.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.resetAllCosmetics.ForeColor = System.Drawing.Color.White;
            this.resetAllCosmetics.HoverState.Parent = this.resetAllCosmetics;
            this.resetAllCosmetics.Location = new System.Drawing.Point(240, 418);
            this.resetAllCosmetics.Name = "resetAllCosmetics";
            this.resetAllCosmetics.ShadowDecoration.Parent = this.resetAllCosmetics;
            this.resetAllCosmetics.Size = new System.Drawing.Size(141, 29);
            this.resetAllCosmetics.TabIndex = 103;
            this.resetAllCosmetics.TabStop = false;
            this.resetAllCosmetics.Text = "Reset";
            this.resetAllCosmetics.Click += new System.EventHandler(this.resetAllCosmetics_Click);
            // 
            // cRick
            // 
            this.cRick.Animated = true;
            this.cRick.AutoRoundedCorners = true;
            this.cRick.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cRick.BorderRadius = 13;
            this.cRick.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            this.cRick.CheckedState.FillColor = System.Drawing.Color.RoyalBlue;
            this.cRick.CheckedState.Parent = this.cRick;
            this.cRick.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cRick.CustomImages.Parent = this.cRick;
            this.FadeEffectBetweenPages.SetDecoration(this.cRick, Guna.UI2.AnimatorNS.DecorationType.None);
            this.cRick.DisabledState.Parent = this.cRick;
            this.cRick.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.cRick.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.cRick.ForeColor = System.Drawing.Color.White;
            this.cRick.HoverState.Parent = this.cRick;
            this.cRick.Location = new System.Drawing.Point(16, 325);
            this.cRick.Name = "cRick";
            this.cRick.ShadowDecoration.Parent = this.cRick;
            this.cRick.Size = new System.Drawing.Size(141, 29);
            this.cRick.TabIndex = 102;
            this.cRick.TabStop = false;
            this.cRick.Tag = "f517a479-d94c-467c-9542-31fa33da6770";
            this.cRick.Text = "Rick Astley";
            this.cRick.Click += new System.EventHandler(this.cRick_Click);
            // 
            // cYellow
            // 
            this.cYellow.Animated = true;
            this.cYellow.AutoRoundedCorners = true;
            this.cYellow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cYellow.BorderRadius = 13;
            this.cYellow.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            this.cYellow.CheckedState.FillColor = System.Drawing.Color.RoyalBlue;
            this.cYellow.CheckedState.Parent = this.cYellow;
            this.cYellow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cYellow.CustomImages.Parent = this.cYellow;
            this.FadeEffectBetweenPages.SetDecoration(this.cYellow, Guna.UI2.AnimatorNS.DecorationType.None);
            this.cYellow.DisabledState.Parent = this.cYellow;
            this.cYellow.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.cYellow.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.cYellow.ForeColor = System.Drawing.Color.White;
            this.cYellow.HoverState.Parent = this.cYellow;
            this.cYellow.Location = new System.Drawing.Point(16, 290);
            this.cYellow.Name = "cYellow";
            this.cYellow.ShadowDecoration.Parent = this.cYellow;
            this.cYellow.Size = new System.Drawing.Size(141, 29);
            this.cYellow.TabIndex = 101;
            this.cYellow.TabStop = false;
            this.cYellow.Tag = "f557a479-d94c-467c-9542-31fa53da6570";
            this.cYellow.Text = "Yellow Gradient";
            this.cYellow.Click += new System.EventHandler(this.cYellow_Click);
            // 
            // cBlue
            // 
            this.cBlue.Animated = true;
            this.cBlue.AutoRoundedCorners = true;
            this.cBlue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cBlue.BorderRadius = 13;
            this.cBlue.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            this.cBlue.CheckedState.FillColor = System.Drawing.Color.RoyalBlue;
            this.cBlue.CheckedState.Parent = this.cBlue;
            this.cBlue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cBlue.CustomImages.Parent = this.cBlue;
            this.FadeEffectBetweenPages.SetDecoration(this.cBlue, Guna.UI2.AnimatorNS.DecorationType.None);
            this.cBlue.DisabledState.Parent = this.cBlue;
            this.cBlue.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.cBlue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.cBlue.ForeColor = System.Drawing.Color.White;
            this.cBlue.HoverState.Parent = this.cBlue;
            this.cBlue.Location = new System.Drawing.Point(17, 255);
            this.cBlue.Name = "cBlue";
            this.cBlue.ShadowDecoration.Parent = this.cBlue;
            this.cBlue.Size = new System.Drawing.Size(141, 29);
            this.cBlue.TabIndex = 100;
            this.cBlue.TabStop = false;
            this.cBlue.Tag = "f557a479-d94c-467c-9592-31fa33da6570";
            this.cBlue.Text = "Dark Blue Sky";
            this.cBlue.Click += new System.EventHandler(this.cBlue_Click);
            // 
            // cPink
            // 
            this.cPink.Animated = true;
            this.cPink.AutoRoundedCorners = true;
            this.cPink.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cPink.BorderRadius = 13;
            this.cPink.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            this.cPink.CheckedState.FillColor = System.Drawing.Color.RoyalBlue;
            this.cPink.CheckedState.Parent = this.cPink;
            this.cPink.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cPink.CustomImages.Parent = this.cPink;
            this.FadeEffectBetweenPages.SetDecoration(this.cPink, Guna.UI2.AnimatorNS.DecorationType.None);
            this.cPink.DisabledState.Parent = this.cPink;
            this.cPink.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.cPink.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.cPink.ForeColor = System.Drawing.Color.White;
            this.cPink.HoverState.Parent = this.cPink;
            this.cPink.Location = new System.Drawing.Point(16, 220);
            this.cPink.Name = "cPink";
            this.cPink.ShadowDecoration.Parent = this.cPink;
            this.cPink.Size = new System.Drawing.Size(141, 29);
            this.cPink.TabIndex = 99;
            this.cPink.TabStop = false;
            this.cPink.Tag = "f557a479-d84c-467c-9542-31fa33da6570";
            this.cPink.Text = "Pink Galaxy";
            this.cPink.Click += new System.EventHandler(this.cPink_Click);
            // 
            // cWhite
            // 
            this.cWhite.Animated = true;
            this.cWhite.AutoRoundedCorners = true;
            this.cWhite.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cWhite.BorderRadius = 13;
            this.cWhite.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            this.cWhite.CheckedState.FillColor = System.Drawing.Color.RoyalBlue;
            this.cWhite.CheckedState.Parent = this.cWhite;
            this.cWhite.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cWhite.CustomImages.Parent = this.cWhite;
            this.FadeEffectBetweenPages.SetDecoration(this.cWhite, Guna.UI2.AnimatorNS.DecorationType.None);
            this.cWhite.DisabledState.Parent = this.cWhite;
            this.cWhite.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.cWhite.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.cWhite.ForeColor = System.Drawing.Color.White;
            this.cWhite.HoverState.Parent = this.cWhite;
            this.cWhite.Location = new System.Drawing.Point(17, 185);
            this.cWhite.Name = "cWhite";
            this.cWhite.ShadowDecoration.Parent = this.cWhite;
            this.cWhite.Size = new System.Drawing.Size(141, 29);
            this.cWhite.TabIndex = 98;
            this.cWhite.TabStop = false;
            this.cWhite.Tag = "f557a479-d94c-467c-9542-31fa33da6470";
            this.cWhite.Text = "White";
            this.cWhite.Click += new System.EventHandler(this.cWhite_Click);
            // 
            // cBlack
            // 
            this.cBlack.Animated = true;
            this.cBlack.AutoRoundedCorners = true;
            this.cBlack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cBlack.BorderRadius = 13;
            this.cBlack.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            this.cBlack.CheckedState.FillColor = System.Drawing.Color.RoyalBlue;
            this.cBlack.CheckedState.Parent = this.cBlack;
            this.cBlack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cBlack.CustomImages.Parent = this.cBlack;
            this.FadeEffectBetweenPages.SetDecoration(this.cBlack, Guna.UI2.AnimatorNS.DecorationType.None);
            this.cBlack.DisabledState.Parent = this.cBlack;
            this.cBlack.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.cBlack.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.cBlack.ForeColor = System.Drawing.Color.White;
            this.cBlack.HoverState.Parent = this.cBlack;
            this.cBlack.Location = new System.Drawing.Point(17, 150);
            this.cBlack.Name = "cBlack";
            this.cBlack.ShadowDecoration.Parent = this.cBlack;
            this.cBlack.Size = new System.Drawing.Size(141, 29);
            this.cBlack.TabIndex = 97;
            this.cBlack.TabStop = false;
            this.cBlack.Tag = "f557a479-d94c-467c-9542-31fa33da6570";
            this.cBlack.Text = "Black";
            this.cBlack.Click += new System.EventHandler(this.cBlack_Click);
            // 
            // othersTitle
            // 
            this.othersTitle.AutoSize = true;
            this.othersTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.FadeEffectBetweenPages.SetDecoration(this.othersTitle, Guna.UI2.AnimatorNS.DecorationType.None);
            this.othersTitle.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.othersTitle.ForeColor = System.Drawing.Color.White;
            this.othersTitle.Location = new System.Drawing.Point(524, 109);
            this.othersTitle.Name = "othersTitle";
            this.othersTitle.Size = new System.Drawing.Size(62, 25);
            this.othersTitle.TabIndex = 96;
            this.othersTitle.Text = "Other";
            this.othersTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // masksTitle
            // 
            this.masksTitle.AutoSize = true;
            this.masksTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.FadeEffectBetweenPages.SetDecoration(this.masksTitle, Guna.UI2.AnimatorNS.DecorationType.None);
            this.masksTitle.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.masksTitle.ForeColor = System.Drawing.Color.White;
            this.masksTitle.Location = new System.Drawing.Point(212, 109);
            this.masksTitle.Name = "masksTitle";
            this.masksTitle.Size = new System.Drawing.Size(67, 25);
            this.masksTitle.TabIndex = 95;
            this.masksTitle.Text = "Masks";
            this.masksTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // animatedCapesTitle
            // 
            this.animatedCapesTitle.AutoSize = true;
            this.animatedCapesTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.FadeEffectBetweenPages.SetDecoration(this.animatedCapesTitle, Guna.UI2.AnimatorNS.DecorationType.None);
            this.animatedCapesTitle.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.animatedCapesTitle.ForeColor = System.Drawing.Color.White;
            this.animatedCapesTitle.Location = new System.Drawing.Point(324, 109);
            this.animatedCapesTitle.Name = "animatedCapesTitle";
            this.animatedCapesTitle.Size = new System.Drawing.Size(155, 25);
            this.animatedCapesTitle.TabIndex = 94;
            this.animatedCapesTitle.Text = "Animated Capes";
            this.animatedCapesTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // capesTitle
            // 
            this.capesTitle.AutoSize = true;
            this.capesTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.FadeEffectBetweenPages.SetDecoration(this.capesTitle, Guna.UI2.AnimatorNS.DecorationType.None);
            this.capesTitle.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.capesTitle.ForeColor = System.Drawing.Color.White;
            this.capesTitle.Location = new System.Drawing.Point(55, 109);
            this.capesTitle.Name = "capesTitle";
            this.capesTitle.Size = new System.Drawing.Size(64, 25);
            this.capesTitle.TabIndex = 93;
            this.capesTitle.Text = "Capes";
            this.capesTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cosmeticsTabLabel
            // 
            this.cosmeticsTabLabel.AutoSize = true;
            this.cosmeticsTabLabel.BackColor = System.Drawing.Color.Transparent;
            this.FadeEffectBetweenPages.SetDecoration(this.cosmeticsTabLabel, Guna.UI2.AnimatorNS.DecorationType.None);
            this.cosmeticsTabLabel.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cosmeticsTabLabel.ForeColor = System.Drawing.Color.White;
            this.cosmeticsTabLabel.Location = new System.Drawing.Point(223, 20);
            this.cosmeticsTabLabel.Name = "cosmeticsTabLabel";
            this.cosmeticsTabLabel.Size = new System.Drawing.Size(185, 47);
            this.cosmeticsTabLabel.TabIndex = 92;
            this.cosmeticsTabLabel.Text = "Cosmetics";
            this.cosmeticsTabLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cosmeticsBackground
            // 
            this.cosmeticsBackground.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.FadeEffectBetweenPages.SetDecoration(this.cosmeticsBackground, Guna.UI2.AnimatorNS.DecorationType.None);
            this.cosmeticsBackground.Location = new System.Drawing.Point(-8, 85);
            this.cosmeticsBackground.Name = "cosmeticsBackground";
            this.cosmeticsBackground.Size = new System.Drawing.Size(660, 384);
            this.cosmeticsBackground.TabIndex = 91;
            this.cosmeticsBackground.TabStop = false;
            // 
            // versionsTab
            // 
            this.versionsTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.FadeEffectBetweenPages.SetDecoration(this.versionsTab, Guna.UI2.AnimatorNS.DecorationType.None);
            this.versionsTab.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.versionsTab.ForeColor = System.Drawing.Color.White;
            this.versionsTab.Location = new System.Drawing.Point(4, 4);
            this.versionsTab.Name = "versionsTab";
            this.versionsTab.Size = new System.Drawing.Size(644, 465);
            this.versionsTab.TabIndex = 4;
            this.versionsTab.Text = "versions";
            // 
            // settingsTab
            // 
            this.settingsTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.settingsTab.BackgroundImage = global::VentileClient.Properties.Resources.background;
            this.settingsTab.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.settingsTab.Controls.Add(this.settingsTabLabel);
            this.settingsTab.Controls.Add(this.settingsPagesTabControl);
            this.FadeEffectBetweenPages.SetDecoration(this.settingsTab, Guna.UI2.AnimatorNS.DecorationType.None);
            this.settingsTab.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.settingsTab.ForeColor = System.Drawing.Color.White;
            this.settingsTab.Location = new System.Drawing.Point(4, 4);
            this.settingsTab.Name = "settingsTab";
            this.settingsTab.Size = new System.Drawing.Size(644, 465);
            this.settingsTab.TabIndex = 2;
            this.settingsTab.Text = "settings";
            // 
            // settingsTabLabel
            // 
            this.settingsTabLabel.AutoSize = true;
            this.settingsTabLabel.BackColor = System.Drawing.Color.Transparent;
            this.FadeEffectBetweenPages.SetDecoration(this.settingsTabLabel, Guna.UI2.AnimatorNS.DecorationType.None);
            this.settingsTabLabel.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settingsTabLabel.ForeColor = System.Drawing.Color.White;
            this.settingsTabLabel.Location = new System.Drawing.Point(244, 20);
            this.settingsTabLabel.Name = "settingsTabLabel";
            this.settingsTabLabel.Size = new System.Drawing.Size(155, 47);
            this.settingsTabLabel.TabIndex = 12;
            this.settingsTabLabel.Text = "Settings";
            this.settingsTabLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // settingsPagesTabControl
            // 
            this.settingsPagesTabControl.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.settingsPagesTabControl.Controls.Add(this.Launcher);
            this.settingsPagesTabControl.Controls.Add(this.Appearance);
            this.settingsPagesTabControl.Controls.Add(this.Extras);
            this.FadeEffectBetweenPages.SetDecoration(this.settingsPagesTabControl, Guna.UI2.AnimatorNS.DecorationType.None);
            this.settingsPagesTabControl.ItemSize = new System.Drawing.Size(180, 40);
            this.settingsPagesTabControl.Location = new System.Drawing.Point(0, 85);
            this.settingsPagesTabControl.Margin = new System.Windows.Forms.Padding(0);
            this.settingsPagesTabControl.Name = "settingsPagesTabControl";
            this.settingsPagesTabControl.Padding = new System.Drawing.Point(0, 0);
            this.settingsPagesTabControl.SelectedIndex = 0;
            this.settingsPagesTabControl.Size = new System.Drawing.Size(644, 382);
            this.settingsPagesTabControl.TabButtonHoverState.BorderColor = System.Drawing.Color.Empty;
            this.settingsPagesTabControl.TabButtonHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.settingsPagesTabControl.TabButtonHoverState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.settingsPagesTabControl.TabButtonHoverState.ForeColor = System.Drawing.Color.White;
            this.settingsPagesTabControl.TabButtonHoverState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.settingsPagesTabControl.TabButtonIdleState.BorderColor = System.Drawing.Color.Empty;
            this.settingsPagesTabControl.TabButtonIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.settingsPagesTabControl.TabButtonIdleState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.settingsPagesTabControl.TabButtonIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(160)))), ((int)(((byte)(167)))));
            this.settingsPagesTabControl.TabButtonIdleState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.settingsPagesTabControl.TabButtonSelectedState.BorderColor = System.Drawing.Color.Empty;
            this.settingsPagesTabControl.TabButtonSelectedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(37)))), ((int)(((byte)(49)))));
            this.settingsPagesTabControl.TabButtonSelectedState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.settingsPagesTabControl.TabButtonSelectedState.ForeColor = System.Drawing.Color.White;
            this.settingsPagesTabControl.TabButtonSelectedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(132)))), ((int)(((byte)(255)))));
            this.settingsPagesTabControl.TabButtonSize = new System.Drawing.Size(180, 40);
            this.settingsPagesTabControl.TabIndex = 0;
            this.settingsPagesTabControl.TabMenuBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.settingsPagesTabControl.TabMenuVisible = false;
            this.settingsPagesTabControl.TabStop = false;
            // 
            // Launcher
            // 
            this.Launcher.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.Launcher.Controls.Add(this.injectDelayLabel);
            this.Launcher.Controls.Add(this.injectDelay);
            this.Launcher.Controls.Add(this.rpcButtonTextLabel);
            this.Launcher.Controls.Add(this.rpcLine);
            this.Launcher.Controls.Add(this.buttonForRpc);
            this.Launcher.Controls.Add(this.rpcButtonLinkLabel);
            this.Launcher.Controls.Add(this.rpcButtonText);
            this.Launcher.Controls.Add(this.rpcButtonLink);
            this.Launcher.Controls.Add(this.windowStateLabel);
            this.Launcher.Controls.Add(this.hideWindow);
            this.Launcher.Controls.Add(this.minWindow);
            this.Launcher.Controls.Add(this.richPresenceLabel);
            this.Launcher.Controls.Add(this.closeWindow);
            this.Launcher.Controls.Add(this.devDLLLabel);
            this.Launcher.Controls.Add(this.RpcToggle);
            this.Launcher.Controls.Add(this.resourceLabel);
            this.Launcher.Controls.Add(this.autoLabel);
            this.Launcher.Controls.Add(this.customDLLButton);
            this.Launcher.Controls.Add(this.openWindow);
            this.Launcher.Controls.Add(this.autoInject);
            this.Launcher.Controls.Add(this.customLoc);
            this.Launcher.Controls.Add(this.AppearanceButton);
            this.FadeEffectBetweenPages.SetDecoration(this.Launcher, Guna.UI2.AnimatorNS.DecorationType.None);
            this.Launcher.Location = new System.Drawing.Point(5, 4);
            this.Launcher.Margin = new System.Windows.Forms.Padding(0);
            this.Launcher.Name = "Launcher";
            this.Launcher.Size = new System.Drawing.Size(635, 374);
            this.Launcher.TabIndex = 0;
            this.Launcher.Text = "Launcher";
            // 
            // injectDelayLabel
            // 
            this.injectDelayLabel.AutoSize = true;
            this.injectDelayLabel.BackColor = System.Drawing.Color.Transparent;
            this.FadeEffectBetweenPages.SetDecoration(this.injectDelayLabel, Guna.UI2.AnimatorNS.DecorationType.None);
            this.injectDelayLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.injectDelayLabel.ForeColor = System.Drawing.Color.White;
            this.injectDelayLabel.Location = new System.Drawing.Point(452, 115);
            this.injectDelayLabel.Name = "injectDelayLabel";
            this.injectDelayLabel.Size = new System.Drawing.Size(47, 20);
            this.injectDelayLabel.TabIndex = 101;
            this.injectDelayLabel.Text = "Delay";
            this.injectDelayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // injectDelay
            // 
            this.injectDelay.AutoRoundedCorners = true;
            this.injectDelay.BackColor = System.Drawing.Color.Transparent;
            this.injectDelay.BorderColor = System.Drawing.Color.Empty;
            this.injectDelay.BorderRadius = 13;
            this.injectDelay.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.FadeEffectBetweenPages.SetDecoration(this.injectDelay, Guna.UI2.AnimatorNS.DecorationType.None);
            this.injectDelay.DisabledState.Parent = this.injectDelay;
            this.injectDelay.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.injectDelay.FocusedState.Parent = this.injectDelay;
            this.injectDelay.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.injectDelay.ForeColor = System.Drawing.Color.Black;
            this.injectDelay.Location = new System.Drawing.Point(505, 112);
            this.injectDelay.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.injectDelay.Name = "injectDelay";
            this.injectDelay.ShadowDecoration.Parent = this.injectDelay;
            this.injectDelay.Size = new System.Drawing.Size(94, 29);
            this.injectDelay.TabIndex = 100;
            this.injectDelay.UpDownButtonFillColor = System.Drawing.Color.RoyalBlue;
            this.injectDelay.UseTransparentBackground = true;
            this.injectDelay.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.injectDelay.ValueChanged += new System.EventHandler(this.injectDelay_ValueChanged);
            // 
            // rpcButtonTextLabel
            // 
            this.rpcButtonTextLabel.AutoSize = true;
            this.FadeEffectBetweenPages.SetDecoration(this.rpcButtonTextLabel, Guna.UI2.AnimatorNS.DecorationType.None);
            this.rpcButtonTextLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rpcButtonTextLabel.ForeColor = System.Drawing.Color.White;
            this.rpcButtonTextLabel.Location = new System.Drawing.Point(241, 158);
            this.rpcButtonTextLabel.Name = "rpcButtonTextLabel";
            this.rpcButtonTextLabel.Size = new System.Drawing.Size(37, 20);
            this.rpcButtonTextLabel.TabIndex = 98;
            this.rpcButtonTextLabel.Text = "Text";
            // 
            // rpcLine
            // 
            this.rpcLine.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.FadeEffectBetweenPages.SetDecoration(this.rpcLine, Guna.UI2.AnimatorNS.DecorationType.None);
            this.rpcLine.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rpcLine.HidePromptOnLeave = true;
            this.rpcLine.Location = new System.Drawing.Point(245, 109);
            this.rpcLine.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.rpcLine.Name = "rpcLine";
            this.rpcLine.Size = new System.Drawing.Size(143, 18);
            this.rpcLine.TabIndex = 80;
            this.rpcLine.TextChanged += new System.EventHandler(this.rpcLine_TextChanged);
            // 
            // buttonForRpc
            // 
            this.buttonForRpc.Animated = true;
            this.buttonForRpc.AutoRoundedCorners = true;
            this.buttonForRpc.BackColor = System.Drawing.Color.Transparent;
            this.buttonForRpc.BorderRadius = 8;
            this.buttonForRpc.CheckedState.Parent = this.buttonForRpc;
            this.buttonForRpc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonForRpc.CustomImages.Parent = this.buttonForRpc;
            this.FadeEffectBetweenPages.SetDecoration(this.buttonForRpc, Guna.UI2.AnimatorNS.DecorationType.None);
            this.buttonForRpc.DisabledState.Parent = this.buttonForRpc;
            this.buttonForRpc.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.buttonForRpc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.buttonForRpc.ForeColor = System.Drawing.Color.White;
            this.buttonForRpc.HoverState.Parent = this.buttonForRpc;
            this.buttonForRpc.Location = new System.Drawing.Point(268, 133);
            this.buttonForRpc.Name = "buttonForRpc";
            this.buttonForRpc.ShadowDecoration.Parent = this.buttonForRpc;
            this.buttonForRpc.Size = new System.Drawing.Size(98, 19);
            this.buttonForRpc.TabIndex = 99;
            this.buttonForRpc.TabStop = false;
            this.buttonForRpc.Text = "Button";
            this.buttonForRpc.UseTransparentBackground = true;
            this.buttonForRpc.Click += new System.EventHandler(this.buttonForRpc_Click);
            // 
            // rpcButtonLinkLabel
            // 
            this.rpcButtonLinkLabel.AutoSize = true;
            this.FadeEffectBetweenPages.SetDecoration(this.rpcButtonLinkLabel, Guna.UI2.AnimatorNS.DecorationType.None);
            this.rpcButtonLinkLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rpcButtonLinkLabel.ForeColor = System.Drawing.Color.White;
            this.rpcButtonLinkLabel.Location = new System.Drawing.Point(241, 182);
            this.rpcButtonLinkLabel.Name = "rpcButtonLinkLabel";
            this.rpcButtonLinkLabel.Size = new System.Drawing.Size(37, 20);
            this.rpcButtonLinkLabel.TabIndex = 97;
            this.rpcButtonLinkLabel.Text = "Link";
            // 
            // rpcButtonText
            // 
            this.rpcButtonText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.FadeEffectBetweenPages.SetDecoration(this.rpcButtonText, Guna.UI2.AnimatorNS.DecorationType.None);
            this.rpcButtonText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rpcButtonText.HidePromptOnLeave = true;
            this.rpcButtonText.Location = new System.Drawing.Point(285, 158);
            this.rpcButtonText.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.rpcButtonText.Name = "rpcButtonText";
            this.rpcButtonText.Size = new System.Drawing.Size(103, 18);
            this.rpcButtonText.TabIndex = 81;
            this.rpcButtonText.TextChanged += new System.EventHandler(this.rpcButtonText_TextChanged);
            // 
            // rpcButtonLink
            // 
            this.rpcButtonLink.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.FadeEffectBetweenPages.SetDecoration(this.rpcButtonLink, Guna.UI2.AnimatorNS.DecorationType.None);
            this.rpcButtonLink.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rpcButtonLink.HidePromptOnLeave = true;
            this.rpcButtonLink.Location = new System.Drawing.Point(285, 182);
            this.rpcButtonLink.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.rpcButtonLink.Name = "rpcButtonLink";
            this.rpcButtonLink.Size = new System.Drawing.Size(103, 18);
            this.rpcButtonLink.TabIndex = 82;
            this.rpcButtonLink.TextChanged += new System.EventHandler(this.rpcButtonLink_TextChanged);
            // 
            // windowStateLabel
            // 
            this.windowStateLabel.AutoSize = true;
            this.windowStateLabel.BackColor = System.Drawing.Color.Transparent;
            this.FadeEffectBetweenPages.SetDecoration(this.windowStateLabel, Guna.UI2.AnimatorNS.DecorationType.None);
            this.windowStateLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.windowStateLabel.ForeColor = System.Drawing.Color.White;
            this.windowStateLabel.Location = new System.Drawing.Point(26, 30);
            this.windowStateLabel.Name = "windowStateLabel";
            this.windowStateLabel.Size = new System.Drawing.Size(137, 25);
            this.windowStateLabel.TabIndex = 79;
            this.windowStateLabel.Text = "Window State";
            this.windowStateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // hideWindow
            // 
            this.hideWindow.Animated = true;
            this.hideWindow.AutoRoundedCorners = true;
            this.hideWindow.BackColor = System.Drawing.Color.Transparent;
            this.hideWindow.BorderRadius = 13;
            this.hideWindow.CheckedState.Parent = this.hideWindow;
            this.hideWindow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hideWindow.CustomImages.Parent = this.hideWindow;
            this.FadeEffectBetweenPages.SetDecoration(this.hideWindow, Guna.UI2.AnimatorNS.DecorationType.None);
            this.hideWindow.DisabledState.Parent = this.hideWindow;
            this.hideWindow.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.hideWindow.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.hideWindow.ForeColor = System.Drawing.Color.White;
            this.hideWindow.HoverState.Parent = this.hideWindow;
            this.hideWindow.Location = new System.Drawing.Point(23, 75);
            this.hideWindow.Name = "hideWindow";
            this.hideWindow.ShadowDecoration.Parent = this.hideWindow;
            this.hideWindow.Size = new System.Drawing.Size(141, 29);
            this.hideWindow.TabIndex = 87;
            this.hideWindow.TabStop = false;
            this.hideWindow.Text = "Hide Launcher";
            this.hideWindow.UseTransparentBackground = true;
            this.hideWindow.Click += new System.EventHandler(this.hideWindow_Click);
            // 
            // minWindow
            // 
            this.minWindow.Animated = true;
            this.minWindow.AutoRoundedCorners = true;
            this.minWindow.BackColor = System.Drawing.Color.Transparent;
            this.minWindow.BorderRadius = 13;
            this.minWindow.CheckedState.Parent = this.minWindow;
            this.minWindow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.minWindow.CustomImages.Parent = this.minWindow;
            this.FadeEffectBetweenPages.SetDecoration(this.minWindow, Guna.UI2.AnimatorNS.DecorationType.None);
            this.minWindow.DisabledState.Parent = this.minWindow;
            this.minWindow.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.minWindow.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.minWindow.ForeColor = System.Drawing.Color.White;
            this.minWindow.HoverState.Parent = this.minWindow;
            this.minWindow.Location = new System.Drawing.Point(23, 110);
            this.minWindow.Name = "minWindow";
            this.minWindow.ShadowDecoration.Parent = this.minWindow;
            this.minWindow.Size = new System.Drawing.Size(141, 29);
            this.minWindow.TabIndex = 88;
            this.minWindow.TabStop = false;
            this.minWindow.Text = "Minimize Launcher";
            this.minWindow.UseTransparentBackground = true;
            this.minWindow.Click += new System.EventHandler(this.minWindow_Click);
            // 
            // richPresenceLabel
            // 
            this.richPresenceLabel.AutoSize = true;
            this.richPresenceLabel.BackColor = System.Drawing.Color.Transparent;
            this.FadeEffectBetweenPages.SetDecoration(this.richPresenceLabel, Guna.UI2.AnimatorNS.DecorationType.None);
            this.richPresenceLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richPresenceLabel.ForeColor = System.Drawing.Color.White;
            this.richPresenceLabel.Location = new System.Drawing.Point(250, 30);
            this.richPresenceLabel.Name = "richPresenceLabel";
            this.richPresenceLabel.Size = new System.Drawing.Size(133, 25);
            this.richPresenceLabel.TabIndex = 86;
            this.richPresenceLabel.Text = "Rich Presence";
            this.richPresenceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // closeWindow
            // 
            this.closeWindow.Animated = true;
            this.closeWindow.AutoRoundedCorners = true;
            this.closeWindow.BackColor = System.Drawing.Color.Transparent;
            this.closeWindow.BorderRadius = 13;
            this.closeWindow.CheckedState.Parent = this.closeWindow;
            this.closeWindow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeWindow.CustomImages.Parent = this.closeWindow;
            this.FadeEffectBetweenPages.SetDecoration(this.closeWindow, Guna.UI2.AnimatorNS.DecorationType.None);
            this.closeWindow.DisabledState.Parent = this.closeWindow;
            this.closeWindow.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.closeWindow.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.closeWindow.ForeColor = System.Drawing.Color.White;
            this.closeWindow.HoverState.Parent = this.closeWindow;
            this.closeWindow.Location = new System.Drawing.Point(22, 144);
            this.closeWindow.Name = "closeWindow";
            this.closeWindow.ShadowDecoration.Parent = this.closeWindow;
            this.closeWindow.Size = new System.Drawing.Size(141, 29);
            this.closeWindow.TabIndex = 89;
            this.closeWindow.TabStop = false;
            this.closeWindow.Text = "Close Launcher";
            this.closeWindow.UseTransparentBackground = true;
            this.closeWindow.Click += new System.EventHandler(this.closeWindow_Click);
            // 
            // devDLLLabel
            // 
            this.devDLLLabel.AutoSize = true;
            this.devDLLLabel.BackColor = System.Drawing.Color.Transparent;
            this.FadeEffectBetweenPages.SetDecoration(this.devDLLLabel, Guna.UI2.AnimatorNS.DecorationType.None);
            this.devDLLLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.devDLLLabel.ForeColor = System.Drawing.Color.White;
            this.devDLLLabel.Location = new System.Drawing.Point(457, 30);
            this.devDLLLabel.Name = "devDLLLabel";
            this.devDLLLabel.Size = new System.Drawing.Size(142, 25);
            this.devDLLLabel.TabIndex = 83;
            this.devDLLLabel.Text = "Developer DLL";
            this.devDLLLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RpcToggle
            // 
            this.RpcToggle.Animated = true;
            this.RpcToggle.AutoRoundedCorners = true;
            this.RpcToggle.BackColor = System.Drawing.Color.Transparent;
            this.RpcToggle.BorderRadius = 13;
            this.RpcToggle.CheckedState.Parent = this.RpcToggle;
            this.RpcToggle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RpcToggle.CustomImages.Parent = this.RpcToggle;
            this.FadeEffectBetweenPages.SetDecoration(this.RpcToggle, Guna.UI2.AnimatorNS.DecorationType.None);
            this.RpcToggle.DisabledState.Parent = this.RpcToggle;
            this.RpcToggle.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.RpcToggle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.RpcToggle.ForeColor = System.Drawing.Color.White;
            this.RpcToggle.HoverState.Parent = this.RpcToggle;
            this.RpcToggle.Location = new System.Drawing.Point(245, 75);
            this.RpcToggle.Name = "RpcToggle";
            this.RpcToggle.ShadowDecoration.Parent = this.RpcToggle;
            this.RpcToggle.Size = new System.Drawing.Size(141, 29);
            this.RpcToggle.TabIndex = 92;
            this.RpcToggle.TabStop = false;
            this.RpcToggle.Text = "On";
            this.RpcToggle.UseTransparentBackground = true;
            this.RpcToggle.Click += new System.EventHandler(this.RpcToggle_Click);
            // 
            // resourceLabel
            // 
            this.resourceLabel.AutoSize = true;
            this.resourceLabel.BackColor = System.Drawing.Color.Transparent;
            this.FadeEffectBetweenPages.SetDecoration(this.resourceLabel, Guna.UI2.AnimatorNS.DecorationType.None);
            this.resourceLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resourceLabel.ForeColor = System.Drawing.Color.White;
            this.resourceLabel.Location = new System.Drawing.Point(463, 183);
            this.resourceLabel.Name = "resourceLabel";
            this.resourceLabel.Size = new System.Drawing.Size(131, 25);
            this.resourceLabel.TabIndex = 84;
            this.resourceLabel.Text = "Blank Setting";
            this.resourceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // autoLabel
            // 
            this.autoLabel.AutoSize = true;
            this.autoLabel.BackColor = System.Drawing.Color.Transparent;
            this.FadeEffectBetweenPages.SetDecoration(this.autoLabel, Guna.UI2.AnimatorNS.DecorationType.None);
            this.autoLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel.ForeColor = System.Drawing.Color.White;
            this.autoLabel.Location = new System.Drawing.Point(36, 244);
            this.autoLabel.Name = "autoLabel";
            this.autoLabel.Size = new System.Drawing.Size(110, 25);
            this.autoLabel.TabIndex = 85;
            this.autoLabel.Text = "Auto Inject";
            this.autoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // customDLLButton
            // 
            this.customDLLButton.Animated = true;
            this.customDLLButton.AutoRoundedCorners = true;
            this.customDLLButton.BackColor = System.Drawing.Color.Transparent;
            this.customDLLButton.BorderRadius = 13;
            this.customDLLButton.CheckedState.Parent = this.customDLLButton;
            this.customDLLButton.ContextMenuStrip = this.DefaultDLLSelector;
            this.customDLLButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.customDLLButton.CustomImages.Parent = this.customDLLButton;
            this.FadeEffectBetweenPages.SetDecoration(this.customDLLButton, Guna.UI2.AnimatorNS.DecorationType.None);
            this.customDLLButton.DisabledState.Parent = this.customDLLButton;
            this.customDLLButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.customDLLButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.customDLLButton.ForeColor = System.Drawing.Color.White;
            this.customDLLButton.HoverState.Parent = this.customDLLButton;
            this.customDLLButton.Location = new System.Drawing.Point(456, 75);
            this.customDLLButton.Name = "customDLLButton";
            this.customDLLButton.ShadowDecoration.Parent = this.customDLLButton;
            this.customDLLButton.Size = new System.Drawing.Size(141, 29);
            this.customDLLButton.TabIndex = 93;
            this.customDLLButton.TabStop = false;
            this.customDLLButton.Text = "Custom DLL";
            this.customDLLButton.UseTransparentBackground = true;
            this.customDLLButton.Click += new System.EventHandler(this.customDLLButton_Click);
            // 
            // DefaultDLLSelector
            // 
            this.FadeEffectBetweenPages.SetDecoration(this.DefaultDLLSelector, Guna.UI2.AnimatorNS.DecorationType.None);
            this.DefaultDLLSelector.Name = "guna2ContextMenuStrip1";
            this.DefaultDLLSelector.RenderStyle.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.DefaultDLLSelector.RenderStyle.BorderColor = System.Drawing.Color.Gainsboro;
            this.DefaultDLLSelector.RenderStyle.ColorTable = null;
            this.DefaultDLLSelector.RenderStyle.RoundedEdges = true;
            this.DefaultDLLSelector.RenderStyle.SelectionArrowColor = System.Drawing.Color.White;
            this.DefaultDLLSelector.RenderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.DefaultDLLSelector.RenderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.DefaultDLLSelector.RenderStyle.SeparatorColor = System.Drawing.Color.Gainsboro;
            this.DefaultDLLSelector.RenderStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.DefaultDLLSelector.Size = new System.Drawing.Size(61, 4);
            // 
            // openWindow
            // 
            this.openWindow.Animated = true;
            this.openWindow.AutoRoundedCorners = true;
            this.openWindow.BackColor = System.Drawing.Color.Transparent;
            this.openWindow.BorderRadius = 13;
            this.openWindow.CheckedState.Parent = this.openWindow;
            this.openWindow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.openWindow.CustomImages.Parent = this.openWindow;
            this.FadeEffectBetweenPages.SetDecoration(this.openWindow, Guna.UI2.AnimatorNS.DecorationType.None);
            this.openWindow.DisabledState.Parent = this.openWindow;
            this.openWindow.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.openWindow.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.openWindow.ForeColor = System.Drawing.Color.White;
            this.openWindow.HoverState.Parent = this.openWindow;
            this.openWindow.Location = new System.Drawing.Point(22, 179);
            this.openWindow.Name = "openWindow";
            this.openWindow.ShadowDecoration.Parent = this.openWindow;
            this.openWindow.Size = new System.Drawing.Size(141, 29);
            this.openWindow.TabIndex = 90;
            this.openWindow.TabStop = false;
            this.openWindow.Text = "Leave Open";
            this.openWindow.UseTransparentBackground = true;
            this.openWindow.Click += new System.EventHandler(this.openWindow_Click);
            // 
            // autoInject
            // 
            this.autoInject.Animated = true;
            this.autoInject.AutoRoundedCorners = true;
            this.autoInject.BackColor = System.Drawing.Color.Transparent;
            this.autoInject.BorderRadius = 13;
            this.autoInject.CheckedState.Parent = this.autoInject;
            this.autoInject.Cursor = System.Windows.Forms.Cursors.Hand;
            this.autoInject.CustomImages.Parent = this.autoInject;
            this.FadeEffectBetweenPages.SetDecoration(this.autoInject, Guna.UI2.AnimatorNS.DecorationType.None);
            this.autoInject.DisabledState.Parent = this.autoInject;
            this.autoInject.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.autoInject.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.autoInject.ForeColor = System.Drawing.Color.White;
            this.autoInject.HoverState.Parent = this.autoInject;
            this.autoInject.Location = new System.Drawing.Point(23, 277);
            this.autoInject.Name = "autoInject";
            this.autoInject.ShadowDecoration.Parent = this.autoInject;
            this.autoInject.Size = new System.Drawing.Size(141, 29);
            this.autoInject.TabIndex = 91;
            this.autoInject.TabStop = false;
            this.autoInject.Text = "On";
            this.autoInject.UseTransparentBackground = true;
            this.autoInject.Click += new System.EventHandler(this.autoInject_Click);
            // 
            // customLoc
            // 
            this.customLoc.Animated = true;
            this.customLoc.AutoRoundedCorners = true;
            this.customLoc.BackColor = System.Drawing.Color.Transparent;
            this.customLoc.BorderRadius = 13;
            this.customLoc.CheckedState.Parent = this.customLoc;
            this.customLoc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.customLoc.CustomImages.Parent = this.customLoc;
            this.FadeEffectBetweenPages.SetDecoration(this.customLoc, Guna.UI2.AnimatorNS.DecorationType.None);
            this.customLoc.DisabledState.Parent = this.customLoc;
            this.customLoc.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.customLoc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.customLoc.ForeColor = System.Drawing.Color.White;
            this.customLoc.HoverState.Parent = this.customLoc;
            this.customLoc.Location = new System.Drawing.Point(456, 229);
            this.customLoc.Name = "customLoc";
            this.customLoc.ShadowDecoration.Parent = this.customLoc;
            this.customLoc.Size = new System.Drawing.Size(141, 29);
            this.customLoc.TabIndex = 94;
            this.customLoc.TabStop = false;
            this.customLoc.Text = "Blank Button";
            this.customLoc.UseTransparentBackground = true;
            this.customLoc.Click += new System.EventHandler(this.blankButton_Click);
            // 
            // AppearanceButton
            // 
            this.AppearanceButton.Animated = true;
            this.AppearanceButton.AutoRoundedCorners = true;
            this.AppearanceButton.BackColor = System.Drawing.Color.Transparent;
            this.AppearanceButton.BorderRadius = 13;
            this.AppearanceButton.CheckedState.Parent = this.AppearanceButton;
            this.AppearanceButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AppearanceButton.CustomImages.Parent = this.AppearanceButton;
            this.FadeEffectBetweenPages.SetDecoration(this.AppearanceButton, Guna.UI2.AnimatorNS.DecorationType.None);
            this.AppearanceButton.DisabledState.Parent = this.AppearanceButton;
            this.AppearanceButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.AppearanceButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.AppearanceButton.ForeColor = System.Drawing.Color.White;
            this.AppearanceButton.HoverState.Parent = this.AppearanceButton;
            this.AppearanceButton.Location = new System.Drawing.Point(533, 336);
            this.AppearanceButton.Name = "AppearanceButton";
            this.AppearanceButton.ShadowDecoration.Parent = this.AppearanceButton;
            this.AppearanceButton.Size = new System.Drawing.Size(96, 29);
            this.AppearanceButton.TabIndex = 96;
            this.AppearanceButton.TabStop = false;
            this.AppearanceButton.Text = "Appearance";
            this.AppearanceButton.UseTransparentBackground = true;
            this.AppearanceButton.Click += new System.EventHandler(this.AppearanceButton_Click);
            // 
            // Appearance
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.Appearance.Controls.Add(this.foreColorLabel);
            this.Appearance.Controls.Add(this.buttonColorLabel);
            this.Appearance.Controls.Add(this.preset8);
            this.Appearance.Controls.Add(this.preset7);
            this.Appearance.Controls.Add(this.preset6);
            this.Appearance.Controls.Add(this.preset5);
            this.Appearance.Controls.Add(this.preset4);
            this.Appearance.Controls.Add(this.preset3);
            this.Appearance.Controls.Add(this.preset2);
            this.Appearance.Controls.Add(this.textBrightnessSlider);
            this.Appearance.Controls.Add(this.buttonBrightnessSlider);
            this.Appearance.Controls.Add(this.outlineBrightnessSlider);
            this.Appearance.Controls.Add(this.accentBlueSlider);
            this.Appearance.Controls.Add(this.accentGreenSlider);
            this.Appearance.Controls.Add(this.accentRedSlider);
            this.Appearance.Controls.Add(this.backgroundBrightnessSlider);
            this.Appearance.Controls.Add(this.preset1);
            this.Appearance.Controls.Add(this.presetsLabel);
            this.Appearance.Controls.Add(this.resetThemes);
            this.Appearance.Controls.Add(this.foreBT);
            this.Appearance.Controls.Add(this.labelForSlider5);
            this.Appearance.Controls.Add(this.accentBT);
            this.Appearance.Controls.Add(this.accentGT);
            this.Appearance.Controls.Add(this.accentRT);
            this.Appearance.Controls.Add(this.labelForSlider2);
            this.Appearance.Controls.Add(this.accentColorLabel);
            this.Appearance.Controls.Add(this.ExtrasButton);
            this.Appearance.Controls.Add(this.LauncherButton);
            this.Appearance.Controls.Add(this.theme);
            this.Appearance.Controls.Add(this.outlineOT);
            this.Appearance.Controls.Add(this.labelForSlider3);
            this.Appearance.Controls.Add(this.outlineColorLabel);
            this.Appearance.Controls.Add(this.buttonBuT);
            this.Appearance.Controls.Add(this.labelForSlider4);
            this.Appearance.Controls.Add(this.backgroundBT);
            this.Appearance.Controls.Add(this.labelForSlider1);
            this.Appearance.Controls.Add(this.backgroundColorLabel);
            this.Appearance.Controls.Add(this.themeTitle);
            this.FadeEffectBetweenPages.SetDecoration(this.Appearance, Guna.UI2.AnimatorNS.DecorationType.None);
            this.Appearance.Location = new System.Drawing.Point(5, 4);
            this.Appearance.Margin = new System.Windows.Forms.Padding(0);
            this.Appearance.Name = "Appearance";
            this.Appearance.Size = new System.Drawing.Size(635, 374);
            this.Appearance.TabIndex = 1;
            this.Appearance.Text = "Appearance";
            // 
            // foreColorLabel
            // 
            this.foreColorLabel.AutoSize = true;
            this.foreColorLabel.BackColor = System.Drawing.Color.Transparent;
            this.FadeEffectBetweenPages.SetDecoration(this.foreColorLabel, Guna.UI2.AnimatorNS.DecorationType.None);
            this.foreColorLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.foreColorLabel.ForeColor = System.Drawing.Color.White;
            this.foreColorLabel.Location = new System.Drawing.Point(266, 241);
            this.foreColorLabel.Name = "foreColorLabel";
            this.foreColorLabel.Size = new System.Drawing.Size(103, 25);
            this.foreColorLabel.TabIndex = 126;
            this.foreColorLabel.Text = "Text Color";
            this.foreColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonColorLabel
            // 
            this.buttonColorLabel.AutoSize = true;
            this.buttonColorLabel.BackColor = System.Drawing.Color.Transparent;
            this.FadeEffectBetweenPages.SetDecoration(this.buttonColorLabel, Guna.UI2.AnimatorNS.DecorationType.None);
            this.buttonColorLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonColorLabel.ForeColor = System.Drawing.Color.White;
            this.buttonColorLabel.Location = new System.Drawing.Point(253, 176);
            this.buttonColorLabel.Name = "buttonColorLabel";
            this.buttonColorLabel.Size = new System.Drawing.Size(128, 25);
            this.buttonColorLabel.TabIndex = 125;
            this.buttonColorLabel.Text = "Button Color";
            this.buttonColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // preset8
            // 
            this.preset8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.preset8.BorderColor = System.Drawing.Color.White;
            this.preset8.BorderThickness = 2;
            this.preset8.ContextMenuStrip = this.presets;
            this.FadeEffectBetweenPages.SetDecoration(this.preset8, Guna.UI2.AnimatorNS.DecorationType.None);
            this.preset8.Location = new System.Drawing.Point(532, 264);
            this.preset8.Name = "preset8";
            this.preset8.ShadowDecoration.Parent = this.preset8;
            this.preset8.Size = new System.Drawing.Size(25, 25);
            this.preset8.TabIndex = 118;
            this.preset8.MouseEnter += new System.EventHandler(this.presetHover);
            // 
            // presets
            // 
            this.FadeEffectBetweenPages.SetDecoration(this.presets, Guna.UI2.AnimatorNS.DecorationType.None);
            this.presets.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem1,
            this.loadToolStripMenuItem1,
            this.deleteToolStripMenuItem,
            this.importToolStripMenuItem,
            this.exportToolStripMenuItem});
            this.presets.Name = "presets";
            this.presets.RenderStyle.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.presets.RenderStyle.BorderColor = System.Drawing.Color.Gainsboro;
            this.presets.RenderStyle.ColorTable = null;
            this.presets.RenderStyle.RoundedEdges = true;
            this.presets.RenderStyle.SelectionArrowColor = System.Drawing.Color.White;
            this.presets.RenderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.presets.RenderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.presets.RenderStyle.SeparatorColor = System.Drawing.Color.Gainsboro;
            this.presets.RenderStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.presets.Size = new System.Drawing.Size(111, 114);
            // 
            // saveToolStripMenuItem1
            // 
            this.saveToolStripMenuItem1.Name = "saveToolStripMenuItem1";
            this.saveToolStripMenuItem1.Size = new System.Drawing.Size(110, 22);
            this.saveToolStripMenuItem1.Text = "Save";
            this.saveToolStripMenuItem1.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem1
            // 
            this.loadToolStripMenuItem1.Name = "loadToolStripMenuItem1";
            this.loadToolStripMenuItem1.Size = new System.Drawing.Size(110, 22);
            this.loadToolStripMenuItem1.Text = "Load";
            this.loadToolStripMenuItem1.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.importToolStripMenuItem.Text = "Import";
            this.importToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.exportToolStripMenuItem.Text = "Export";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // preset7
            // 
            this.preset7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.preset7.BorderColor = System.Drawing.Color.White;
            this.preset7.BorderThickness = 2;
            this.preset7.ContextMenuStrip = this.presets;
            this.FadeEffectBetweenPages.SetDecoration(this.preset7, Guna.UI2.AnimatorNS.DecorationType.None);
            this.preset7.Location = new System.Drawing.Point(487, 264);
            this.preset7.Name = "preset7";
            this.preset7.ShadowDecoration.Parent = this.preset7;
            this.preset7.Size = new System.Drawing.Size(25, 25);
            this.preset7.TabIndex = 117;
            this.preset7.MouseEnter += new System.EventHandler(this.presetHover);
            // 
            // preset6
            // 
            this.preset6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.preset6.BorderColor = System.Drawing.Color.White;
            this.preset6.BorderThickness = 2;
            this.preset6.ContextMenuStrip = this.presets;
            this.FadeEffectBetweenPages.SetDecoration(this.preset6, Guna.UI2.AnimatorNS.DecorationType.None);
            this.preset6.Location = new System.Drawing.Point(532, 221);
            this.preset6.Name = "preset6";
            this.preset6.ShadowDecoration.Parent = this.preset6;
            this.preset6.Size = new System.Drawing.Size(25, 25);
            this.preset6.TabIndex = 116;
            this.preset6.MouseEnter += new System.EventHandler(this.presetHover);
            // 
            // preset5
            // 
            this.preset5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.preset5.BorderColor = System.Drawing.Color.White;
            this.preset5.BorderThickness = 2;
            this.preset5.ContextMenuStrip = this.presets;
            this.FadeEffectBetweenPages.SetDecoration(this.preset5, Guna.UI2.AnimatorNS.DecorationType.None);
            this.preset5.Location = new System.Drawing.Point(487, 221);
            this.preset5.Name = "preset5";
            this.preset5.ShadowDecoration.Parent = this.preset5;
            this.preset5.Size = new System.Drawing.Size(25, 25);
            this.preset5.TabIndex = 115;
            this.preset5.MouseEnter += new System.EventHandler(this.presetHover);
            // 
            // preset4
            // 
            this.preset4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.preset4.BorderColor = System.Drawing.Color.White;
            this.preset4.BorderThickness = 2;
            this.preset4.ContextMenuStrip = this.presets;
            this.FadeEffectBetweenPages.SetDecoration(this.preset4, Guna.UI2.AnimatorNS.DecorationType.None);
            this.preset4.Location = new System.Drawing.Point(532, 179);
            this.preset4.Name = "preset4";
            this.preset4.ShadowDecoration.Parent = this.preset4;
            this.preset4.Size = new System.Drawing.Size(25, 25);
            this.preset4.TabIndex = 114;
            this.preset4.MouseEnter += new System.EventHandler(this.presetHover);
            // 
            // preset3
            // 
            this.preset3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.preset3.BorderColor = System.Drawing.Color.White;
            this.preset3.BorderThickness = 2;
            this.preset3.ContextMenuStrip = this.presets;
            this.FadeEffectBetweenPages.SetDecoration(this.preset3, Guna.UI2.AnimatorNS.DecorationType.None);
            this.preset3.Location = new System.Drawing.Point(487, 179);
            this.preset3.Name = "preset3";
            this.preset3.ShadowDecoration.Parent = this.preset3;
            this.preset3.Size = new System.Drawing.Size(25, 25);
            this.preset3.TabIndex = 113;
            this.preset3.MouseEnter += new System.EventHandler(this.presetHover);
            // 
            // preset2
            // 
            this.preset2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.preset2.BorderColor = System.Drawing.Color.White;
            this.preset2.BorderThickness = 2;
            this.preset2.ContextMenuStrip = this.presets;
            this.FadeEffectBetweenPages.SetDecoration(this.preset2, Guna.UI2.AnimatorNS.DecorationType.None);
            this.preset2.Location = new System.Drawing.Point(532, 142);
            this.preset2.Name = "preset2";
            this.preset2.ShadowDecoration.Parent = this.preset2;
            this.preset2.Size = new System.Drawing.Size(25, 25);
            this.preset2.TabIndex = 112;
            this.preset2.MouseEnter += new System.EventHandler(this.presetHover);
            // 
            // textBrightnessSlider
            // 
            this.textBrightnessSlider.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.FadeEffectBetweenPages.SetDecoration(this.textBrightnessSlider, Guna.UI2.AnimatorNS.DecorationType.None);
            this.textBrightnessSlider.HoverState.Parent = this.textBrightnessSlider;
            this.textBrightnessSlider.Location = new System.Drawing.Point(267, 269);
            this.textBrightnessSlider.Maximum = 255;
            this.textBrightnessSlider.Name = "textBrightnessSlider";
            this.textBrightnessSlider.Size = new System.Drawing.Size(101, 23);
            this.textBrightnessSlider.TabIndex = 124;
            this.textBrightnessSlider.TabStop = false;
            this.textBrightnessSlider.ThumbColor = System.Drawing.Color.RoyalBlue;
            this.textBrightnessSlider.Scroll += new System.Windows.Forms.ScrollEventHandler(this.textBrightnessSlider_Scroll);
            // 
            // buttonBrightnessSlider
            // 
            this.buttonBrightnessSlider.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.FadeEffectBetweenPages.SetDecoration(this.buttonBrightnessSlider, Guna.UI2.AnimatorNS.DecorationType.None);
            this.buttonBrightnessSlider.HoverState.Parent = this.buttonBrightnessSlider;
            this.buttonBrightnessSlider.Location = new System.Drawing.Point(267, 205);
            this.buttonBrightnessSlider.Maximum = 255;
            this.buttonBrightnessSlider.Name = "buttonBrightnessSlider";
            this.buttonBrightnessSlider.Size = new System.Drawing.Size(101, 23);
            this.buttonBrightnessSlider.TabIndex = 123;
            this.buttonBrightnessSlider.TabStop = false;
            this.buttonBrightnessSlider.ThumbColor = System.Drawing.Color.RoyalBlue;
            this.buttonBrightnessSlider.Scroll += new System.Windows.Forms.ScrollEventHandler(this.buttonBrightnessSlider_Scroll);
            // 
            // outlineBrightnessSlider
            // 
            this.outlineBrightnessSlider.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.FadeEffectBetweenPages.SetDecoration(this.outlineBrightnessSlider, Guna.UI2.AnimatorNS.DecorationType.None);
            this.outlineBrightnessSlider.HoverState.Parent = this.outlineBrightnessSlider;
            this.outlineBrightnessSlider.Location = new System.Drawing.Point(267, 135);
            this.outlineBrightnessSlider.Maximum = 255;
            this.outlineBrightnessSlider.Name = "outlineBrightnessSlider";
            this.outlineBrightnessSlider.Size = new System.Drawing.Size(101, 23);
            this.outlineBrightnessSlider.TabIndex = 122;
            this.outlineBrightnessSlider.TabStop = false;
            this.outlineBrightnessSlider.ThumbColor = System.Drawing.Color.RoyalBlue;
            this.outlineBrightnessSlider.Scroll += new System.Windows.Forms.ScrollEventHandler(this.outlineBrightnessSlider_Scroll);
            // 
            // accentBlueSlider
            // 
            this.accentBlueSlider.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.FadeEffectBetweenPages.SetDecoration(this.accentBlueSlider, Guna.UI2.AnimatorNS.DecorationType.None);
            this.accentBlueSlider.HoverState.Parent = this.accentBlueSlider;
            this.accentBlueSlider.Location = new System.Drawing.Point(70, 252);
            this.accentBlueSlider.Maximum = 255;
            this.accentBlueSlider.Name = "accentBlueSlider";
            this.accentBlueSlider.Size = new System.Drawing.Size(101, 23);
            this.accentBlueSlider.TabIndex = 121;
            this.accentBlueSlider.TabStop = false;
            this.accentBlueSlider.ThumbColor = System.Drawing.Color.RoyalBlue;
            this.accentBlueSlider.Scroll += new System.Windows.Forms.ScrollEventHandler(this.accentBlueSlider_Scroll);
            // 
            // accentGreenSlider
            // 
            this.accentGreenSlider.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.FadeEffectBetweenPages.SetDecoration(this.accentGreenSlider, Guna.UI2.AnimatorNS.DecorationType.None);
            this.accentGreenSlider.HoverState.Parent = this.accentGreenSlider;
            this.accentGreenSlider.Location = new System.Drawing.Point(70, 230);
            this.accentGreenSlider.Maximum = 255;
            this.accentGreenSlider.Name = "accentGreenSlider";
            this.accentGreenSlider.Size = new System.Drawing.Size(101, 23);
            this.accentGreenSlider.TabIndex = 120;
            this.accentGreenSlider.TabStop = false;
            this.accentGreenSlider.ThumbColor = System.Drawing.Color.RoyalBlue;
            this.accentGreenSlider.Scroll += new System.Windows.Forms.ScrollEventHandler(this.accentGreenSlider_Scroll);
            // 
            // accentRedSlider
            // 
            this.accentRedSlider.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.FadeEffectBetweenPages.SetDecoration(this.accentRedSlider, Guna.UI2.AnimatorNS.DecorationType.None);
            this.accentRedSlider.HoverState.Parent = this.accentRedSlider;
            this.accentRedSlider.Location = new System.Drawing.Point(70, 207);
            this.accentRedSlider.Maximum = 255;
            this.accentRedSlider.Name = "accentRedSlider";
            this.accentRedSlider.Size = new System.Drawing.Size(101, 23);
            this.accentRedSlider.TabIndex = 119;
            this.accentRedSlider.TabStop = false;
            this.accentRedSlider.ThumbColor = System.Drawing.Color.RoyalBlue;
            this.accentRedSlider.Scroll += new System.Windows.Forms.ScrollEventHandler(this.accentRedSlider_Scroll);
            // 
            // backgroundBrightnessSlider
            // 
            this.backgroundBrightnessSlider.BackColor = System.Drawing.Color.Transparent;
            this.backgroundBrightnessSlider.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.FadeEffectBetweenPages.SetDecoration(this.backgroundBrightnessSlider, Guna.UI2.AnimatorNS.DecorationType.None);
            this.backgroundBrightnessSlider.HoverState.Parent = this.backgroundBrightnessSlider;
            this.backgroundBrightnessSlider.Location = new System.Drawing.Point(68, 135);
            this.backgroundBrightnessSlider.Maximum = 255;
            this.backgroundBrightnessSlider.Name = "backgroundBrightnessSlider";
            this.backgroundBrightnessSlider.Size = new System.Drawing.Size(101, 23);
            this.backgroundBrightnessSlider.TabIndex = 111;
            this.backgroundBrightnessSlider.TabStop = false;
            this.backgroundBrightnessSlider.ThumbColor = System.Drawing.Color.RoyalBlue;
            this.backgroundBrightnessSlider.Scroll += new System.Windows.Forms.ScrollEventHandler(this.backgroundBrightnessSlider_Scroll);
            // 
            // preset1
            // 
            this.preset1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.preset1.BorderColor = System.Drawing.Color.White;
            this.preset1.BorderThickness = 2;
            this.preset1.ContextMenuStrip = this.presets;
            this.FadeEffectBetweenPages.SetDecoration(this.preset1, Guna.UI2.AnimatorNS.DecorationType.None);
            this.preset1.Location = new System.Drawing.Point(487, 142);
            this.preset1.Name = "preset1";
            this.preset1.ShadowDecoration.Parent = this.preset1;
            this.preset1.Size = new System.Drawing.Size(25, 25);
            this.preset1.TabIndex = 110;
            this.preset1.MouseEnter += new System.EventHandler(this.presetHover);
            // 
            // presetsLabel
            // 
            this.presetsLabel.AutoSize = true;
            this.presetsLabel.BackColor = System.Drawing.Color.Transparent;
            this.FadeEffectBetweenPages.SetDecoration(this.presetsLabel, Guna.UI2.AnimatorNS.DecorationType.None);
            this.presetsLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.presetsLabel.ForeColor = System.Drawing.Color.White;
            this.presetsLabel.Location = new System.Drawing.Point(483, 101);
            this.presetsLabel.Name = "presetsLabel";
            this.presetsLabel.Size = new System.Drawing.Size(75, 25);
            this.presetsLabel.TabIndex = 109;
            this.presetsLabel.Text = "Presets";
            this.presetsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // resetThemes
            // 
            this.resetThemes.Animated = true;
            this.resetThemes.AutoRoundedCorners = true;
            this.resetThemes.BackColor = System.Drawing.Color.Transparent;
            this.resetThemes.BorderRadius = 13;
            this.resetThemes.CheckedState.Parent = this.resetThemes;
            this.resetThemes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.resetThemes.CustomImages.Parent = this.resetThemes;
            this.FadeEffectBetweenPages.SetDecoration(this.resetThemes, Guna.UI2.AnimatorNS.DecorationType.None);
            this.resetThemes.DisabledState.Parent = this.resetThemes;
            this.resetThemes.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.resetThemes.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.resetThemes.ForeColor = System.Drawing.Color.White;
            this.resetThemes.HoverState.Parent = this.resetThemes;
            this.resetThemes.Location = new System.Drawing.Point(246, 311);
            this.resetThemes.Name = "resetThemes";
            this.resetThemes.ShadowDecoration.Parent = this.resetThemes;
            this.resetThemes.Size = new System.Drawing.Size(141, 29);
            this.resetThemes.TabIndex = 106;
            this.resetThemes.TabStop = false;
            this.resetThemes.Text = "Reset";
            this.resetThemes.UseTransparentBackground = true;
            this.resetThemes.Click += new System.EventHandler(this.resetThemes_Click);
            // 
            // foreBT
            // 
            this.foreBT.AutoSize = true;
            this.foreBT.BackColor = System.Drawing.Color.Transparent;
            this.FadeEffectBetweenPages.SetDecoration(this.foreBT, Guna.UI2.AnimatorNS.DecorationType.None);
            this.foreBT.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.foreBT.ForeColor = System.Drawing.Color.White;
            this.foreBT.Location = new System.Drawing.Point(371, 271);
            this.foreBT.Name = "foreBT";
            this.foreBT.Size = new System.Drawing.Size(29, 17);
            this.foreBT.TabIndex = 108;
            this.foreBT.Text = "255";
            // 
            // labelForSlider5
            // 
            this.labelForSlider5.AutoSize = true;
            this.FadeEffectBetweenPages.SetDecoration(this.labelForSlider5, Guna.UI2.AnimatorNS.DecorationType.None);
            this.labelForSlider5.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelForSlider5.ForeColor = System.Drawing.Color.White;
            this.labelForSlider5.Location = new System.Drawing.Point(246, 270);
            this.labelForSlider5.Name = "labelForSlider5";
            this.labelForSlider5.Size = new System.Drawing.Size(18, 20);
            this.labelForSlider5.TabIndex = 107;
            this.labelForSlider5.Text = "B";
            // 
            // accentBT
            // 
            this.accentBT.AutoSize = true;
            this.accentBT.BackColor = System.Drawing.Color.Transparent;
            this.FadeEffectBetweenPages.SetDecoration(this.accentBT, Guna.UI2.AnimatorNS.DecorationType.None);
            this.accentBT.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accentBT.ForeColor = System.Drawing.Color.White;
            this.accentBT.Location = new System.Drawing.Point(174, 254);
            this.accentBT.Name = "accentBT";
            this.accentBT.Size = new System.Drawing.Size(29, 17);
            this.accentBT.TabIndex = 94;
            this.accentBT.Text = "255";
            // 
            // accentGT
            // 
            this.accentGT.AutoSize = true;
            this.accentGT.BackColor = System.Drawing.Color.Transparent;
            this.FadeEffectBetweenPages.SetDecoration(this.accentGT, Guna.UI2.AnimatorNS.DecorationType.None);
            this.accentGT.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accentGT.ForeColor = System.Drawing.Color.White;
            this.accentGT.Location = new System.Drawing.Point(174, 231);
            this.accentGT.Name = "accentGT";
            this.accentGT.Size = new System.Drawing.Size(29, 17);
            this.accentGT.TabIndex = 93;
            this.accentGT.Text = "255";
            // 
            // accentRT
            // 
            this.accentRT.AutoSize = true;
            this.accentRT.BackColor = System.Drawing.Color.Transparent;
            this.FadeEffectBetweenPages.SetDecoration(this.accentRT, Guna.UI2.AnimatorNS.DecorationType.None);
            this.accentRT.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accentRT.ForeColor = System.Drawing.Color.White;
            this.accentRT.Location = new System.Drawing.Point(174, 209);
            this.accentRT.Name = "accentRT";
            this.accentRT.Size = new System.Drawing.Size(29, 17);
            this.accentRT.TabIndex = 92;
            this.accentRT.Text = "255";
            // 
            // labelForSlider2
            // 
            this.labelForSlider2.AutoSize = true;
            this.labelForSlider2.BackColor = System.Drawing.Color.Transparent;
            this.FadeEffectBetweenPages.SetDecoration(this.labelForSlider2, Guna.UI2.AnimatorNS.DecorationType.None);
            this.labelForSlider2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelForSlider2.ForeColor = System.Drawing.Color.White;
            this.labelForSlider2.Location = new System.Drawing.Point(48, 209);
            this.labelForSlider2.Name = "labelForSlider2";
            this.labelForSlider2.Size = new System.Drawing.Size(19, 60);
            this.labelForSlider2.TabIndex = 91;
            this.labelForSlider2.Text = "R\r\nG\r\nB";
            // 
            // accentColorLabel
            // 
            this.accentColorLabel.AutoSize = true;
            this.accentColorLabel.BackColor = System.Drawing.Color.Transparent;
            this.FadeEffectBetweenPages.SetDecoration(this.accentColorLabel, Guna.UI2.AnimatorNS.DecorationType.None);
            this.accentColorLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accentColorLabel.ForeColor = System.Drawing.Color.White;
            this.accentColorLabel.Location = new System.Drawing.Point(62, 170);
            this.accentColorLabel.Name = "accentColorLabel";
            this.accentColorLabel.Size = new System.Drawing.Size(126, 25);
            this.accentColorLabel.TabIndex = 90;
            this.accentColorLabel.Text = "Accent Color";
            this.accentColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ExtrasButton
            // 
            this.ExtrasButton.Animated = true;
            this.ExtrasButton.AutoRoundedCorners = true;
            this.ExtrasButton.BackColor = System.Drawing.Color.Transparent;
            this.ExtrasButton.BorderRadius = 13;
            this.ExtrasButton.CheckedState.Parent = this.ExtrasButton;
            this.ExtrasButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ExtrasButton.CustomImages.Parent = this.ExtrasButton;
            this.FadeEffectBetweenPages.SetDecoration(this.ExtrasButton, Guna.UI2.AnimatorNS.DecorationType.None);
            this.ExtrasButton.DisabledState.Parent = this.ExtrasButton;
            this.ExtrasButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ExtrasButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.ExtrasButton.ForeColor = System.Drawing.Color.White;
            this.ExtrasButton.HoverState.Parent = this.ExtrasButton;
            this.ExtrasButton.Location = new System.Drawing.Point(540, 337);
            this.ExtrasButton.Name = "ExtrasButton";
            this.ExtrasButton.ShadowDecoration.Parent = this.ExtrasButton;
            this.ExtrasButton.Size = new System.Drawing.Size(90, 29);
            this.ExtrasButton.TabIndex = 105;
            this.ExtrasButton.TabStop = false;
            this.ExtrasButton.Text = "Extras";
            this.ExtrasButton.UseTransparentBackground = true;
            this.ExtrasButton.Click += new System.EventHandler(this.ExtrasButton_Click);
            // 
            // LauncherButton
            // 
            this.LauncherButton.Animated = true;
            this.LauncherButton.AutoRoundedCorners = true;
            this.LauncherButton.BackColor = System.Drawing.Color.Transparent;
            this.LauncherButton.BorderRadius = 13;
            this.LauncherButton.CheckedState.Parent = this.LauncherButton;
            this.LauncherButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LauncherButton.CustomImages.Parent = this.LauncherButton;
            this.FadeEffectBetweenPages.SetDecoration(this.LauncherButton, Guna.UI2.AnimatorNS.DecorationType.None);
            this.LauncherButton.DisabledState.Parent = this.LauncherButton;
            this.LauncherButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.LauncherButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.LauncherButton.ForeColor = System.Drawing.Color.White;
            this.LauncherButton.HoverState.Parent = this.LauncherButton;
            this.LauncherButton.Location = new System.Drawing.Point(5, 336);
            this.LauncherButton.Name = "LauncherButton";
            this.LauncherButton.ShadowDecoration.Parent = this.LauncherButton;
            this.LauncherButton.Size = new System.Drawing.Size(85, 29);
            this.LauncherButton.TabIndex = 104;
            this.LauncherButton.TabStop = false;
            this.LauncherButton.Text = "Launcher";
            this.LauncherButton.Click += new System.EventHandler(this.LauncherButton_Click);
            // 
            // theme
            // 
            this.theme.Animated = true;
            this.theme.AutoRoundedCorners = true;
            this.theme.BackColor = System.Drawing.Color.Transparent;
            this.theme.BorderRadius = 13;
            this.theme.CheckedState.Parent = this.theme;
            this.theme.Cursor = System.Windows.Forms.Cursors.Hand;
            this.theme.CustomImages.Parent = this.theme;
            this.FadeEffectBetweenPages.SetDecoration(this.theme, Guna.UI2.AnimatorNS.DecorationType.None);
            this.theme.DisabledState.Parent = this.theme;
            this.theme.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.theme.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.theme.ForeColor = System.Drawing.Color.White;
            this.theme.HoverState.Parent = this.theme;
            this.theme.Location = new System.Drawing.Point(246, 58);
            this.theme.Name = "theme";
            this.theme.ShadowDecoration.Parent = this.theme;
            this.theme.Size = new System.Drawing.Size(141, 29);
            this.theme.TabIndex = 103;
            this.theme.TabStop = false;
            this.theme.Text = "Dark";
            this.theme.UseTransparentBackground = true;
            this.theme.Click += new System.EventHandler(this.theme_Click);
            // 
            // outlineOT
            // 
            this.outlineOT.AutoSize = true;
            this.outlineOT.BackColor = System.Drawing.Color.Transparent;
            this.FadeEffectBetweenPages.SetDecoration(this.outlineOT, Guna.UI2.AnimatorNS.DecorationType.None);
            this.outlineOT.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outlineOT.ForeColor = System.Drawing.Color.White;
            this.outlineOT.Location = new System.Drawing.Point(370, 137);
            this.outlineOT.Name = "outlineOT";
            this.outlineOT.Size = new System.Drawing.Size(29, 17);
            this.outlineOT.TabIndex = 102;
            this.outlineOT.Text = "255";
            // 
            // labelForSlider3
            // 
            this.labelForSlider3.AutoSize = true;
            this.labelForSlider3.BackColor = System.Drawing.Color.Transparent;
            this.FadeEffectBetweenPages.SetDecoration(this.labelForSlider3, Guna.UI2.AnimatorNS.DecorationType.None);
            this.labelForSlider3.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelForSlider3.ForeColor = System.Drawing.Color.White;
            this.labelForSlider3.Location = new System.Drawing.Point(246, 136);
            this.labelForSlider3.Name = "labelForSlider3";
            this.labelForSlider3.Size = new System.Drawing.Size(18, 20);
            this.labelForSlider3.TabIndex = 101;
            this.labelForSlider3.Text = "B";
            // 
            // outlineColorLabel
            // 
            this.outlineColorLabel.AutoSize = true;
            this.outlineColorLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.FadeEffectBetweenPages.SetDecoration(this.outlineColorLabel, Guna.UI2.AnimatorNS.DecorationType.None);
            this.outlineColorLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outlineColorLabel.ForeColor = System.Drawing.Color.White;
            this.outlineColorLabel.Location = new System.Drawing.Point(252, 101);
            this.outlineColorLabel.Name = "outlineColorLabel";
            this.outlineColorLabel.Size = new System.Drawing.Size(131, 25);
            this.outlineColorLabel.TabIndex = 100;
            this.outlineColorLabel.Text = "Outline Color";
            this.outlineColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonBuT
            // 
            this.buttonBuT.AutoSize = true;
            this.buttonBuT.BackColor = System.Drawing.Color.Transparent;
            this.FadeEffectBetweenPages.SetDecoration(this.buttonBuT, Guna.UI2.AnimatorNS.DecorationType.None);
            this.buttonBuT.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBuT.ForeColor = System.Drawing.Color.White;
            this.buttonBuT.Location = new System.Drawing.Point(370, 207);
            this.buttonBuT.Name = "buttonBuT";
            this.buttonBuT.Size = new System.Drawing.Size(29, 17);
            this.buttonBuT.TabIndex = 99;
            this.buttonBuT.Text = "255";
            // 
            // labelForSlider4
            // 
            this.labelForSlider4.AutoSize = true;
            this.FadeEffectBetweenPages.SetDecoration(this.labelForSlider4, Guna.UI2.AnimatorNS.DecorationType.None);
            this.labelForSlider4.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelForSlider4.ForeColor = System.Drawing.Color.White;
            this.labelForSlider4.Location = new System.Drawing.Point(246, 206);
            this.labelForSlider4.Name = "labelForSlider4";
            this.labelForSlider4.Size = new System.Drawing.Size(18, 20);
            this.labelForSlider4.TabIndex = 98;
            this.labelForSlider4.Text = "B";
            // 
            // backgroundBT
            // 
            this.backgroundBT.AutoSize = true;
            this.backgroundBT.BackColor = System.Drawing.Color.Transparent;
            this.FadeEffectBetweenPages.SetDecoration(this.backgroundBT, Guna.UI2.AnimatorNS.DecorationType.None);
            this.backgroundBT.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backgroundBT.ForeColor = System.Drawing.Color.White;
            this.backgroundBT.Location = new System.Drawing.Point(171, 137);
            this.backgroundBT.Name = "backgroundBT";
            this.backgroundBT.Size = new System.Drawing.Size(29, 17);
            this.backgroundBT.TabIndex = 97;
            this.backgroundBT.Text = "255";
            // 
            // labelForSlider1
            // 
            this.labelForSlider1.AutoSize = true;
            this.labelForSlider1.BackColor = System.Drawing.Color.Transparent;
            this.FadeEffectBetweenPages.SetDecoration(this.labelForSlider1, Guna.UI2.AnimatorNS.DecorationType.None);
            this.labelForSlider1.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelForSlider1.ForeColor = System.Drawing.Color.White;
            this.labelForSlider1.Location = new System.Drawing.Point(47, 136);
            this.labelForSlider1.Name = "labelForSlider1";
            this.labelForSlider1.Size = new System.Drawing.Size(18, 20);
            this.labelForSlider1.TabIndex = 96;
            this.labelForSlider1.Text = "B";
            // 
            // backgroundColorLabel
            // 
            this.backgroundColorLabel.AutoSize = true;
            this.backgroundColorLabel.BackColor = System.Drawing.Color.Transparent;
            this.FadeEffectBetweenPages.SetDecoration(this.backgroundColorLabel, Guna.UI2.AnimatorNS.DecorationType.None);
            this.backgroundColorLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backgroundColorLabel.ForeColor = System.Drawing.Color.White;
            this.backgroundColorLabel.Location = new System.Drawing.Point(43, 101);
            this.backgroundColorLabel.Name = "backgroundColorLabel";
            this.backgroundColorLabel.Size = new System.Drawing.Size(176, 25);
            this.backgroundColorLabel.TabIndex = 95;
            this.backgroundColorLabel.Text = "Background Color";
            this.backgroundColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // themeTitle
            // 
            this.themeTitle.AutoSize = true;
            this.themeTitle.BackColor = System.Drawing.Color.Transparent;
            this.FadeEffectBetweenPages.SetDecoration(this.themeTitle, Guna.UI2.AnimatorNS.DecorationType.None);
            this.themeTitle.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.themeTitle.ForeColor = System.Drawing.Color.White;
            this.themeTitle.Location = new System.Drawing.Point(282, 21);
            this.themeTitle.Name = "themeTitle";
            this.themeTitle.Size = new System.Drawing.Size(71, 25);
            this.themeTitle.TabIndex = 89;
            this.themeTitle.Text = "Theme";
            this.themeTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Extras
            // 
            this.Extras.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.Extras.Controls.Add(this.performanceModeToggle);
            this.Extras.Controls.Add(this.performanceModeTitle);
            this.Extras.Controls.Add(this.toastsSelector);
            this.Extras.Controls.Add(this.customImage);
            this.Extras.Controls.Add(this.backImageTitle);
            this.Extras.Controls.Add(this.roundedToggle);
            this.Extras.Controls.Add(this.roundedTitle);
            this.Extras.Controls.Add(this.toastsToggle);
            this.Extras.Controls.Add(this.AppearanceButton2);
            this.Extras.Controls.Add(this.toastsTitle);
            this.FadeEffectBetweenPages.SetDecoration(this.Extras, Guna.UI2.AnimatorNS.DecorationType.None);
            this.Extras.Location = new System.Drawing.Point(5, 4);
            this.Extras.Margin = new System.Windows.Forms.Padding(0);
            this.Extras.Name = "Extras";
            this.Extras.Size = new System.Drawing.Size(635, 374);
            this.Extras.TabIndex = 2;
            this.Extras.Text = "Extras";
            // 
            // performanceModeToggle
            // 
            this.performanceModeToggle.Animated = true;
            this.performanceModeToggle.AutoRoundedCorners = true;
            this.performanceModeToggle.BackColor = System.Drawing.Color.Transparent;
            this.performanceModeToggle.BorderRadius = 13;
            this.performanceModeToggle.CheckedState.Parent = this.performanceModeToggle;
            this.performanceModeToggle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.performanceModeToggle.CustomImages.Parent = this.performanceModeToggle;
            this.FadeEffectBetweenPages.SetDecoration(this.performanceModeToggle, Guna.UI2.AnimatorNS.DecorationType.None);
            this.performanceModeToggle.DisabledState.Parent = this.performanceModeToggle;
            this.performanceModeToggle.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.performanceModeToggle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.performanceModeToggle.ForeColor = System.Drawing.Color.White;
            this.performanceModeToggle.HoverState.Parent = this.performanceModeToggle;
            this.performanceModeToggle.Location = new System.Drawing.Point(247, 213);
            this.performanceModeToggle.Name = "performanceModeToggle";
            this.performanceModeToggle.ShadowDecoration.Parent = this.performanceModeToggle;
            this.performanceModeToggle.Size = new System.Drawing.Size(141, 29);
            this.performanceModeToggle.TabIndex = 87;
            this.performanceModeToggle.TabStop = false;
            this.performanceModeToggle.Text = "On";
            this.performanceModeToggle.Click += new System.EventHandler(this.performanceModeToggle_Click);
            // 
            // performanceModeTitle
            // 
            this.performanceModeTitle.AutoSize = true;
            this.performanceModeTitle.BackColor = System.Drawing.Color.Transparent;
            this.FadeEffectBetweenPages.SetDecoration(this.performanceModeTitle, Guna.UI2.AnimatorNS.DecorationType.None);
            this.performanceModeTitle.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.performanceModeTitle.ForeColor = System.Drawing.Color.White;
            this.performanceModeTitle.Location = new System.Drawing.Point(228, 175);
            this.performanceModeTitle.Name = "performanceModeTitle";
            this.performanceModeTitle.Size = new System.Drawing.Size(183, 25);
            this.performanceModeTitle.TabIndex = 86;
            this.performanceModeTitle.Text = "Performance Mode";
            this.performanceModeTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // toastsSelector
            // 
            this.toastsSelector.AutoRoundedCorners = true;
            this.toastsSelector.BackColor = System.Drawing.Color.Transparent;
            this.toastsSelector.BorderRadius = 15;
            this.FadeEffectBetweenPages.SetDecoration(this.toastsSelector, Guna.UI2.AnimatorNS.DecorationType.None);
            this.toastsSelector.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.toastsSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toastsSelector.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.toastsSelector.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.toastsSelector.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.toastsSelector.FocusedState.Parent = this.toastsSelector;
            this.toastsSelector.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.toastsSelector.ForeColor = System.Drawing.Color.White;
            this.toastsSelector.HoverState.Parent = this.toastsSelector;
            this.toastsSelector.ItemHeight = 27;
            this.toastsSelector.Items.AddRange(new object[] {
            "Top Right",
            "Bottom Right",
            "Top Left",
            "Bottom Left"});
            this.toastsSelector.ItemsAppearance.Parent = this.toastsSelector;
            this.toastsSelector.Location = new System.Drawing.Point(246, 112);
            this.toastsSelector.Name = "toastsSelector";
            this.toastsSelector.ShadowDecoration.Parent = this.toastsSelector;
            this.toastsSelector.Size = new System.Drawing.Size(141, 33);
            this.toastsSelector.TabIndex = 85;
            this.toastsSelector.TabStop = false;
            this.toastsSelector.SelectedIndexChanged += new System.EventHandler(this.toastsSelector_SelectedIndexChanged);
            // 
            // customImage
            // 
            this.customImage.Animated = true;
            this.customImage.AutoRoundedCorners = true;
            this.customImage.BackColor = System.Drawing.Color.Transparent;
            this.customImage.BorderRadius = 13;
            this.customImage.CheckedState.Parent = this.customImage;
            this.customImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.customImage.CustomImages.Parent = this.customImage;
            this.FadeEffectBetweenPages.SetDecoration(this.customImage, Guna.UI2.AnimatorNS.DecorationType.None);
            this.customImage.DisabledState.Parent = this.customImage;
            this.customImage.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.customImage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.customImage.ForeColor = System.Drawing.Color.White;
            this.customImage.HoverState.Parent = this.customImage;
            this.customImage.Location = new System.Drawing.Point(43, 73);
            this.customImage.Name = "customImage";
            this.customImage.ShadowDecoration.Parent = this.customImage;
            this.customImage.Size = new System.Drawing.Size(141, 29);
            this.customImage.TabIndex = 84;
            this.customImage.TabStop = false;
            this.customImage.Text = "Choose Image";
            this.customImage.Click += new System.EventHandler(this.customImage_Click);
            // 
            // backImageTitle
            // 
            this.backImageTitle.AutoSize = true;
            this.backImageTitle.BackColor = System.Drawing.Color.Transparent;
            this.FadeEffectBetweenPages.SetDecoration(this.backImageTitle, Guna.UI2.AnimatorNS.DecorationType.None);
            this.backImageTitle.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backImageTitle.ForeColor = System.Drawing.Color.White;
            this.backImageTitle.Location = new System.Drawing.Point(26, 36);
            this.backImageTitle.Name = "backImageTitle";
            this.backImageTitle.Size = new System.Drawing.Size(182, 25);
            this.backImageTitle.TabIndex = 83;
            this.backImageTitle.Text = "Background Image";
            this.backImageTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // roundedToggle
            // 
            this.roundedToggle.Animated = true;
            this.roundedToggle.AutoRoundedCorners = true;
            this.roundedToggle.BackColor = System.Drawing.Color.Transparent;
            this.roundedToggle.BorderRadius = 13;
            this.roundedToggle.CheckedState.Parent = this.roundedToggle;
            this.roundedToggle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.roundedToggle.CustomImages.Parent = this.roundedToggle;
            this.FadeEffectBetweenPages.SetDecoration(this.roundedToggle, Guna.UI2.AnimatorNS.DecorationType.None);
            this.roundedToggle.DisabledState.Parent = this.roundedToggle;
            this.roundedToggle.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.roundedToggle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.roundedToggle.ForeColor = System.Drawing.Color.White;
            this.roundedToggle.HoverState.Parent = this.roundedToggle;
            this.roundedToggle.Location = new System.Drawing.Point(439, 73);
            this.roundedToggle.Name = "roundedToggle";
            this.roundedToggle.ShadowDecoration.Parent = this.roundedToggle;
            this.roundedToggle.Size = new System.Drawing.Size(141, 29);
            this.roundedToggle.TabIndex = 82;
            this.roundedToggle.TabStop = false;
            this.roundedToggle.Text = "On";
            this.roundedToggle.Click += new System.EventHandler(this.roundedToggle_Click);
            // 
            // roundedTitle
            // 
            this.roundedTitle.AutoSize = true;
            this.roundedTitle.BackColor = System.Drawing.Color.Transparent;
            this.FadeEffectBetweenPages.SetDecoration(this.roundedTitle, Guna.UI2.AnimatorNS.DecorationType.None);
            this.roundedTitle.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roundedTitle.ForeColor = System.Drawing.Color.White;
            this.roundedTitle.Location = new System.Drawing.Point(424, 36);
            this.roundedTitle.Name = "roundedTitle";
            this.roundedTitle.Size = new System.Drawing.Size(169, 25);
            this.roundedTitle.TabIndex = 81;
            this.roundedTitle.Text = "Rounded Buttons";
            this.roundedTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // toastsToggle
            // 
            this.toastsToggle.Animated = true;
            this.toastsToggle.AutoRoundedCorners = true;
            this.toastsToggle.BackColor = System.Drawing.Color.Transparent;
            this.toastsToggle.BorderRadius = 13;
            this.toastsToggle.CheckedState.Parent = this.toastsToggle;
            this.toastsToggle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.toastsToggle.CustomImages.Parent = this.toastsToggle;
            this.FadeEffectBetweenPages.SetDecoration(this.toastsToggle, Guna.UI2.AnimatorNS.DecorationType.None);
            this.toastsToggle.DisabledState.Parent = this.toastsToggle;
            this.toastsToggle.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.toastsToggle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toastsToggle.ForeColor = System.Drawing.Color.White;
            this.toastsToggle.HoverState.Parent = this.toastsToggle;
            this.toastsToggle.Location = new System.Drawing.Point(245, 75);
            this.toastsToggle.Name = "toastsToggle";
            this.toastsToggle.ShadowDecoration.Parent = this.toastsToggle;
            this.toastsToggle.Size = new System.Drawing.Size(141, 29);
            this.toastsToggle.TabIndex = 80;
            this.toastsToggle.TabStop = false;
            this.toastsToggle.Text = "On";
            this.toastsToggle.Click += new System.EventHandler(this.toastsToggle_Click);
            // 
            // AppearanceButton2
            // 
            this.AppearanceButton2.Animated = true;
            this.AppearanceButton2.AutoRoundedCorners = true;
            this.AppearanceButton2.BackColor = System.Drawing.Color.Transparent;
            this.AppearanceButton2.BorderRadius = 13;
            this.AppearanceButton2.CheckedState.Parent = this.AppearanceButton2;
            this.AppearanceButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AppearanceButton2.CustomImages.Parent = this.AppearanceButton2;
            this.FadeEffectBetweenPages.SetDecoration(this.AppearanceButton2, Guna.UI2.AnimatorNS.DecorationType.None);
            this.AppearanceButton2.DisabledState.Parent = this.AppearanceButton2;
            this.AppearanceButton2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.AppearanceButton2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.AppearanceButton2.ForeColor = System.Drawing.Color.White;
            this.AppearanceButton2.HoverState.Parent = this.AppearanceButton2;
            this.AppearanceButton2.Location = new System.Drawing.Point(6, 336);
            this.AppearanceButton2.Name = "AppearanceButton2";
            this.AppearanceButton2.ShadowDecoration.Parent = this.AppearanceButton2;
            this.AppearanceButton2.Size = new System.Drawing.Size(99, 29);
            this.AppearanceButton2.TabIndex = 79;
            this.AppearanceButton2.TabStop = false;
            this.AppearanceButton2.Text = "Appearance";
            this.AppearanceButton2.Click += new System.EventHandler(this.AppearanceButton2_Click);
            // 
            // toastsTitle
            // 
            this.toastsTitle.AutoSize = true;
            this.toastsTitle.BackColor = System.Drawing.Color.Transparent;
            this.FadeEffectBetweenPages.SetDecoration(this.toastsTitle, Guna.UI2.AnimatorNS.DecorationType.None);
            this.toastsTitle.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toastsTitle.ForeColor = System.Drawing.Color.White;
            this.toastsTitle.Location = new System.Drawing.Point(282, 36);
            this.toastsTitle.Name = "toastsTitle";
            this.toastsTitle.Size = new System.Drawing.Size(66, 25);
            this.toastsTitle.TabIndex = 78;
            this.toastsTitle.Text = "Toasts";
            this.toastsTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // aboutTab
            // 
            this.aboutTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.aboutTab.BackgroundImage = global::VentileClient.Properties.Resources.background;
            this.aboutTab.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.aboutTab.Controls.Add(this.changeLogLink);
            this.aboutTab.Controls.Add(this.cosmeticsVLabel);
            this.aboutTab.Controls.Add(this.clientVLabel);
            this.aboutTab.Controls.Add(this.launcherVLabel);
            this.aboutTab.Controls.Add(this.website);
            this.aboutTab.Controls.Add(this.discord);
            this.aboutTab.Controls.Add(this.launcherBy);
            this.aboutTab.Controls.Add(this.aboutSeparator);
            this.aboutTab.Controls.Add(this.clientLabel);
            this.aboutTab.Controls.Add(this.cosmeticsLabel);
            this.aboutTab.Controls.Add(this.aboutTabLabel);
            this.aboutTab.Controls.Add(this.launcherLabel);
            this.aboutTab.Controls.Add(this.aboutDesc);
            this.aboutTab.Controls.Add(this.aboutBackgroundColor);
            this.FadeEffectBetweenPages.SetDecoration(this.aboutTab, Guna.UI2.AnimatorNS.DecorationType.None);
            this.aboutTab.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.aboutTab.ForeColor = System.Drawing.Color.White;
            this.aboutTab.Location = new System.Drawing.Point(4, 4);
            this.aboutTab.Name = "aboutTab";
            this.aboutTab.Size = new System.Drawing.Size(644, 465);
            this.aboutTab.TabIndex = 3;
            this.aboutTab.Text = "about";
            // 
            // changeLogLink
            // 
            this.changeLogLink.ActiveLinkColor = System.Drawing.Color.RoyalBlue;
            this.changeLogLink.AutoSize = true;
            this.FadeEffectBetweenPages.SetDecoration(this.changeLogLink, Guna.UI2.AnimatorNS.DecorationType.None);
            this.changeLogLink.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.changeLogLink.LinkBehavior = System.Windows.Forms.LinkBehavior.AlwaysUnderline;
            this.changeLogLink.LinkColor = System.Drawing.Color.RoyalBlue;
            this.changeLogLink.Location = new System.Drawing.Point(268, 425);
            this.changeLogLink.Name = "changeLogLink";
            this.changeLogLink.Size = new System.Drawing.Size(83, 20);
            this.changeLogLink.TabIndex = 33;
            this.changeLogLink.TabStop = true;
            this.changeLogLink.Text = "Changelog";
            this.changeLogLink.VisitedLinkColor = System.Drawing.Color.RoyalBlue;
            this.changeLogLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.changeLogLink_LinkClicked);
            // 
            // cosmeticsVLabel
            // 
            this.cosmeticsVLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.FadeEffectBetweenPages.SetDecoration(this.cosmeticsVLabel, Guna.UI2.AnimatorNS.DecorationType.None);
            this.cosmeticsVLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cosmeticsVLabel.ForeColor = System.Drawing.Color.Silver;
            this.cosmeticsVLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cosmeticsVLabel.Location = new System.Drawing.Point(16, 197);
            this.cosmeticsVLabel.Name = "cosmeticsVLabel";
            this.cosmeticsVLabel.Size = new System.Drawing.Size(204, 40);
            this.cosmeticsVLabel.TabIndex = 32;
            this.cosmeticsVLabel.Text = "Version";
            this.cosmeticsVLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // clientVLabel
            // 
            this.clientVLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.FadeEffectBetweenPages.SetDecoration(this.clientVLabel, Guna.UI2.AnimatorNS.DecorationType.None);
            this.clientVLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clientVLabel.ForeColor = System.Drawing.Color.Silver;
            this.clientVLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.clientVLabel.Location = new System.Drawing.Point(456, 197);
            this.clientVLabel.Name = "clientVLabel";
            this.clientVLabel.Size = new System.Drawing.Size(151, 40);
            this.clientVLabel.TabIndex = 31;
            this.clientVLabel.Text = "Version";
            this.clientVLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // launcherVLabel
            // 
            this.launcherVLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.FadeEffectBetweenPages.SetDecoration(this.launcherVLabel, Guna.UI2.AnimatorNS.DecorationType.None);
            this.launcherVLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.launcherVLabel.ForeColor = System.Drawing.Color.Silver;
            this.launcherVLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.launcherVLabel.Location = new System.Drawing.Point(234, 153);
            this.launcherVLabel.Name = "launcherVLabel";
            this.launcherVLabel.Size = new System.Drawing.Size(195, 40);
            this.launcherVLabel.TabIndex = 30;
            this.launcherVLabel.Text = "Version";
            this.launcherVLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // website
            // 
            this.website.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.website.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FadeEffectBetweenPages.SetDecoration(this.website, Guna.UI2.AnimatorNS.DecorationType.None);
            this.website.Image = global::VentileClient.Properties.Resources.website_white;
            this.website.Location = new System.Drawing.Point(9, 405);
            this.website.Name = "website";
            this.website.Size = new System.Drawing.Size(48, 47);
            this.website.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.website.TabIndex = 29;
            this.website.TabStop = false;
            this.website.Click += new System.EventHandler(this.website_Click);
            // 
            // discord
            // 
            this.discord.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.discord.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.discord.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FadeEffectBetweenPages.SetDecoration(this.discord, Guna.UI2.AnimatorNS.DecorationType.None);
            this.discord.Image = global::VentileClient.Properties.Resources.transparent_logo_white;
            this.discord.InitialImage = null;
            this.discord.Location = new System.Drawing.Point(587, 409);
            this.discord.Name = "discord";
            this.discord.Size = new System.Drawing.Size(48, 41);
            this.discord.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.discord.TabIndex = 28;
            this.discord.TabStop = false;
            this.discord.Click += new System.EventHandler(this.discord_Click);
            // 
            // launcherBy
            // 
            this.launcherBy.AutoSize = true;
            this.launcherBy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.FadeEffectBetweenPages.SetDecoration(this.launcherBy, Guna.UI2.AnimatorNS.DecorationType.None);
            this.launcherBy.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.launcherBy.ForeColor = System.Drawing.Color.White;
            this.launcherBy.Location = new System.Drawing.Point(182, 259);
            this.launcherBy.Name = "launcherBy";
            this.launcherBy.Size = new System.Drawing.Size(279, 25);
            this.launcherBy.TabIndex = 27;
            this.launcherBy.Text = "Launcher By: DeathlyBower959";
            this.launcherBy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // aboutSeparator
            // 
            this.FadeEffectBetweenPages.SetDecoration(this.aboutSeparator, Guna.UI2.AnimatorNS.DecorationType.None);
            this.aboutSeparator.Location = new System.Drawing.Point(-6, 292);
            this.aboutSeparator.Name = "aboutSeparator";
            this.aboutSeparator.Size = new System.Drawing.Size(660, 3);
            this.aboutSeparator.TabIndex = 26;
            this.aboutSeparator.TabStop = false;
            // 
            // clientLabel
            // 
            this.clientLabel.AutoSize = true;
            this.clientLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.FadeEffectBetweenPages.SetDecoration(this.clientLabel, Guna.UI2.AnimatorNS.DecorationType.None);
            this.clientLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            this.clientLabel.ForeColor = System.Drawing.Color.White;
            this.clientLabel.Location = new System.Drawing.Point(450, 162);
            this.clientLabel.Name = "clientLabel";
            this.clientLabel.Size = new System.Drawing.Size(164, 32);
            this.clientLabel.TabIndex = 25;
            this.clientLabel.Text = "Client Version";
            this.clientLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cosmeticsLabel
            // 
            this.cosmeticsLabel.AutoSize = true;
            this.cosmeticsLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.FadeEffectBetweenPages.SetDecoration(this.cosmeticsLabel, Guna.UI2.AnimatorNS.DecorationType.None);
            this.cosmeticsLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            this.cosmeticsLabel.ForeColor = System.Drawing.Color.White;
            this.cosmeticsLabel.Location = new System.Drawing.Point(10, 165);
            this.cosmeticsLabel.Name = "cosmeticsLabel";
            this.cosmeticsLabel.Size = new System.Drawing.Size(210, 32);
            this.cosmeticsLabel.TabIndex = 24;
            this.cosmeticsLabel.Text = "Cosmetics Version";
            this.cosmeticsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // aboutTabLabel
            // 
            this.aboutTabLabel.AutoSize = true;
            this.aboutTabLabel.BackColor = System.Drawing.Color.Transparent;
            this.FadeEffectBetweenPages.SetDecoration(this.aboutTabLabel, Guna.UI2.AnimatorNS.DecorationType.None);
            this.aboutTabLabel.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aboutTabLabel.ForeColor = System.Drawing.Color.White;
            this.aboutTabLabel.Location = new System.Drawing.Point(264, 20);
            this.aboutTabLabel.Name = "aboutTabLabel";
            this.aboutTabLabel.Size = new System.Drawing.Size(123, 47);
            this.aboutTabLabel.TabIndex = 23;
            this.aboutTabLabel.Text = "About";
            this.aboutTabLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // launcherLabel
            // 
            this.launcherLabel.AutoSize = true;
            this.launcherLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.FadeEffectBetweenPages.SetDecoration(this.launcherLabel, Guna.UI2.AnimatorNS.DecorationType.None);
            this.launcherLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            this.launcherLabel.ForeColor = System.Drawing.Color.White;
            this.launcherLabel.Location = new System.Drawing.Point(228, 121);
            this.launcherLabel.Name = "launcherLabel";
            this.launcherLabel.Size = new System.Drawing.Size(201, 32);
            this.launcherLabel.TabIndex = 21;
            this.launcherLabel.Text = "Launcher Version";
            this.launcherLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // aboutDesc
            // 
            this.aboutDesc.AutoSize = true;
            this.aboutDesc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.FadeEffectBetweenPages.SetDecoration(this.aboutDesc, Guna.UI2.AnimatorNS.DecorationType.None);
            this.aboutDesc.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aboutDesc.ForeColor = System.Drawing.Color.White;
            this.aboutDesc.Location = new System.Drawing.Point(-10, 305);
            this.aboutDesc.Name = "aboutDesc";
            this.aboutDesc.Size = new System.Drawing.Size(664, 168);
            this.aboutDesc.TabIndex = 20;
            this.aboutDesc.Text = resources.GetString("aboutDesc.Text");
            this.aboutDesc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // aboutBackgroundColor
            // 
            this.aboutBackgroundColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.FadeEffectBetweenPages.SetDecoration(this.aboutBackgroundColor, Guna.UI2.AnimatorNS.DecorationType.None);
            this.aboutBackgroundColor.Location = new System.Drawing.Point(-6, 85);
            this.aboutBackgroundColor.Name = "aboutBackgroundColor";
            this.aboutBackgroundColor.Size = new System.Drawing.Size(660, 246);
            this.aboutBackgroundColor.TabIndex = 22;
            this.aboutBackgroundColor.TabStop = false;
            // 
            // TrayIcon
            // 
            this.TrayIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.TrayIcon.BalloonTipText = "Test";
            this.TrayIcon.BalloonTipTitle = "TEST";
            this.TrayIcon.ContextMenuStrip = this.TrayIconContextMenu;
            this.TrayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("TrayIcon.Icon")));
            this.TrayIcon.Text = "Ventile Client";
            this.TrayIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TrayIcon_Click);
            // 
            // TrayIconContextMenu
            // 
            this.FadeEffectBetweenPages.SetDecoration(this.TrayIconContextMenu, Guna.UI2.AnimatorNS.DecorationType.None);
            this.TrayIconContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.injectToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.TrayIconContextMenu.Name = "guna2ContextMenuStrip1";
            this.TrayIconContextMenu.RenderStyle.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.TrayIconContextMenu.RenderStyle.BorderColor = System.Drawing.Color.Gainsboro;
            this.TrayIconContextMenu.RenderStyle.ColorTable = null;
            this.TrayIconContextMenu.RenderStyle.RoundedEdges = true;
            this.TrayIconContextMenu.RenderStyle.SelectionArrowColor = System.Drawing.Color.White;
            this.TrayIconContextMenu.RenderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.TrayIconContextMenu.RenderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.TrayIconContextMenu.RenderStyle.SeparatorColor = System.Drawing.Color.Gainsboro;
            this.TrayIconContextMenu.RenderStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.TrayIconContextMenu.Size = new System.Drawing.Size(104, 70);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.TrayOpen_Click);
            // 
            // injectToolStripMenuItem
            // 
            this.injectToolStripMenuItem.Name = "injectToolStripMenuItem";
            this.injectToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.injectToolStripMenuItem.Text = "Inject";
            this.injectToolStripMenuItem.Click += new System.EventHandler(this.inject_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.TrayQuit_Click);
            // 
            // FadeEffectBetweenPages
            // 
            this.FadeEffectBetweenPages.AnimationType = Guna.UI2.AnimatorNS.AnimationType.Transparent;
            this.FadeEffectBetweenPages.Cursor = null;
            animation1.AnimateOnlyDifferences = true;
            animation1.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.BlindCoeff")));
            animation1.LeafCoeff = 0F;
            animation1.MaxTime = 1F;
            animation1.MinTime = 0F;
            animation1.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicCoeff")));
            animation1.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicShift")));
            animation1.MosaicSize = 0;
            animation1.Padding = new System.Windows.Forms.Padding(0);
            animation1.RotateCoeff = 0F;
            animation1.RotateLimit = 0F;
            animation1.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.ScaleCoeff")));
            animation1.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.SlideCoeff")));
            animation1.TimeCoeff = 0F;
            animation1.TransparencyCoeff = 1F;
            this.FadeEffectBetweenPages.DefaultAnimation = animation1;
            this.FadeEffectBetweenPages.Interval = 1;
            this.FadeEffectBetweenPages.MaxAnimationTime = 500;
            this.FadeEffectBetweenPages.TimeStep = 0.04F;
            // 
            // internetCheckTimer
            // 
            this.internetCheckTimer.Enabled = true;
            this.internetCheckTimer.Interval = 10;
            this.internetCheckTimer.Tick += new System.EventHandler(this.internetCheck_Tick);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 490);
            this.Controls.Add(this.dragBar);
            this.Controls.Add(this.sidebar);
            this.Controls.Add(this.contentView);
            this.FadeEffectBetweenPages.SetDecoration(this, Guna.UI2.AnimatorNS.DecorationType.None);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(813, 490);
            this.MinimumSize = new System.Drawing.Size(813, 490);
            this.Name = "MainWindow";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VentileLauncher";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.dragBar.ResumeLayout(false);
            this.sidebar.ResumeLayout(false);
            this.sidebar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.versionButtonIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aboutButtonIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.settingsButtonIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cosmeticsButtonIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.homeButtonIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            this.contentView.ResumeLayout(false);
            this.homeTab.ResumeLayout(false);
            this.cosmeticsTab.ResumeLayout(false);
            this.cosmeticsTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cosmeticsBackground)).EndInit();
            this.settingsTab.ResumeLayout(false);
            this.settingsTab.PerformLayout();
            this.settingsPagesTabControl.ResumeLayout(false);
            this.Launcher.ResumeLayout(false);
            this.Launcher.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.injectDelay)).EndInit();
            this.Appearance.ResumeLayout(false);
            this.Appearance.PerformLayout();
            this.presets.ResumeLayout(false);
            this.Extras.ResumeLayout(false);
            this.Extras.PerformLayout();
            this.aboutTab.ResumeLayout(false);
            this.aboutTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.website)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.discord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aboutSeparator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aboutBackgroundColor)).EndInit();
            this.TrayIconContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public Guna.UI2.WinForms.Guna2Panel dragBar;
        public Guna.UI2.WinForms.Guna2DragControl dragWindowControl;
        public Guna.UI2.WinForms.Guna2Panel sidebar;
        public Guna.UI2.WinForms.Guna2PictureBox logo;
        public Guna.UI2.WinForms.Guna2Button closeButton;
        public System.Windows.Forms.Label launcherTitle;
        public System.Windows.Forms.Button line;
        public Guna.UI2.WinForms.Guna2Button minimizeButton;
        public Guna.UI2.WinForms.Guna2Button homeButton;
        public FontAwesome.Sharp.IconPictureBox homeButtonIcon;
        public System.Windows.Forms.Timer fadeOut;
        public System.Windows.Forms.Timer tick;
        public Guna.UI2.WinForms.Guna2Button cosmeticsButton;
        public FontAwesome.Sharp.IconPictureBox cosmeticsButtonIcon;
        public Guna.UI2.WinForms.Guna2Button settingsButton;
        public FontAwesome.Sharp.IconPictureBox settingsButtonIcon;
        public Guna.UI2.WinForms.Guna2Button aboutButton;
        public FontAwesome.Sharp.IconPictureBox aboutButtonIcon;
        public System.Windows.Forms.Label version;
        public System.Windows.Forms.TabPage aboutTab;
        public System.Windows.Forms.TabPage settingsTab;
        public System.Windows.Forms.TabPage cosmeticsTab;
        public System.Windows.Forms.TabPage homeTab;
        public Guna.UI2.WinForms.Guna2Button inject;
        public Guna.UI2.WinForms.Guna2Button selectDll;
        public Guna.UI2.WinForms.Guna2Button launchMc;
        public System.Windows.Forms.Label cosmeticsVLabel;
        public System.Windows.Forms.Label clientVLabel;
        public System.Windows.Forms.Label launcherVLabel;
        public System.Windows.Forms.PictureBox website;
        public System.Windows.Forms.PictureBox discord;
        public System.Windows.Forms.Label launcherBy;
        public System.Windows.Forms.PictureBox aboutSeparator;
        public System.Windows.Forms.Label clientLabel;
        public System.Windows.Forms.Label cosmeticsLabel;
        public System.Windows.Forms.Label aboutTabLabel;
        public System.Windows.Forms.Label launcherLabel;
        public System.Windows.Forms.Label aboutDesc;
        public System.Windows.Forms.PictureBox aboutBackgroundColor;
        public Guna.UI2.WinForms.Guna2Button oKagune;
        public Guna.UI2.WinForms.Guna2Button oWavy;
        public Guna.UI2.WinForms.Guna2Button aSlide;
        public Guna.UI2.WinForms.Guna2Button aGlowing;
        public Guna.UI2.WinForms.Guna2Button mRick;
        public Guna.UI2.WinForms.Guna2Button mYellow;
        public Guna.UI2.WinForms.Guna2Button mBlue;
        public Guna.UI2.WinForms.Guna2Button mPink;
        public Guna.UI2.WinForms.Guna2Button mWhite;
        public Guna.UI2.WinForms.Guna2Button mBlack;
        public Guna.UI2.WinForms.Guna2Button resetAllCosmetics;
        public Guna.UI2.WinForms.Guna2Button cRick;
        public Guna.UI2.WinForms.Guna2Button cYellow;
        public Guna.UI2.WinForms.Guna2Button cBlue;
        public Guna.UI2.WinForms.Guna2Button cPink;
        public Guna.UI2.WinForms.Guna2Button cWhite;
        public Guna.UI2.WinForms.Guna2Button cBlack;
        public System.Windows.Forms.Label othersTitle;
        public System.Windows.Forms.Label masksTitle;
        public System.Windows.Forms.Label animatedCapesTitle;
        public System.Windows.Forms.Label capesTitle;
        public System.Windows.Forms.Label cosmeticsTabLabel;
        public System.Windows.Forms.PictureBox cosmeticsBackground;
        public Guna.UI2.WinForms.Guna2TabControl settingsPagesTabControl;
        public System.Windows.Forms.Label settingsTabLabel;
        public System.Windows.Forms.TabPage Launcher;
        public System.Windows.Forms.TabPage Appearance;
        public System.Windows.Forms.TabPage Extras;
        public Guna.UI2.WinForms.Guna2Panel preset8;
        public Guna.UI2.WinForms.Guna2Panel preset7;
        public Guna.UI2.WinForms.Guna2Panel preset6;
        public Guna.UI2.WinForms.Guna2Panel preset5;
        public Guna.UI2.WinForms.Guna2Panel preset4;
        public Guna.UI2.WinForms.Guna2Panel preset3;
        public Guna.UI2.WinForms.Guna2Panel preset2;
        public Guna.UI2.WinForms.Guna2TrackBar textBrightnessSlider;
        public Guna.UI2.WinForms.Guna2TrackBar buttonBrightnessSlider;
        public Guna.UI2.WinForms.Guna2TrackBar outlineBrightnessSlider;
        public Guna.UI2.WinForms.Guna2TrackBar accentBlueSlider;
        public Guna.UI2.WinForms.Guna2TrackBar accentGreenSlider;
        public Guna.UI2.WinForms.Guna2TrackBar accentRedSlider;
        public Guna.UI2.WinForms.Guna2TrackBar backgroundBrightnessSlider;
        public Guna.UI2.WinForms.Guna2Panel preset1;
        public System.Windows.Forms.Label presetsLabel;
        public Guna.UI2.WinForms.Guna2Button resetThemes;
        public System.Windows.Forms.Label foreBT;
        public System.Windows.Forms.Label labelForSlider5;
        public System.Windows.Forms.Label accentBT;
        public System.Windows.Forms.Label accentGT;
        public System.Windows.Forms.Label accentRT;
        public System.Windows.Forms.Label labelForSlider2;
        public System.Windows.Forms.Label accentColorLabel;
        public Guna.UI2.WinForms.Guna2Button ExtrasButton;
        public Guna.UI2.WinForms.Guna2Button LauncherButton;
        public Guna.UI2.WinForms.Guna2Button theme;
        public System.Windows.Forms.Label outlineOT;
        public System.Windows.Forms.Label labelForSlider3;
        public System.Windows.Forms.Label outlineColorLabel;
        public System.Windows.Forms.Label buttonBuT;
        public System.Windows.Forms.Label labelForSlider4;
        public System.Windows.Forms.Label backgroundBT;
        public System.Windows.Forms.Label labelForSlider1;
        public System.Windows.Forms.Label backgroundColorLabel;
        public System.Windows.Forms.Label themeTitle;
        public System.Windows.Forms.Label foreColorLabel;
        public System.Windows.Forms.Label buttonColorLabel;
        public System.Windows.Forms.Label rpcButtonTextLabel;
        public System.Windows.Forms.MaskedTextBox rpcLine;
        public Guna.UI2.WinForms.Guna2Button buttonForRpc;
        public System.Windows.Forms.Label rpcButtonLinkLabel;
        public System.Windows.Forms.MaskedTextBox rpcButtonText;
        public System.Windows.Forms.MaskedTextBox rpcButtonLink;
        public System.Windows.Forms.Label windowStateLabel;
        public Guna.UI2.WinForms.Guna2Button hideWindow;
        public Guna.UI2.WinForms.Guna2Button minWindow;
        public System.Windows.Forms.Label richPresenceLabel;
        public Guna.UI2.WinForms.Guna2Button closeWindow;
        public System.Windows.Forms.Label devDLLLabel;
        public Guna.UI2.WinForms.Guna2Button RpcToggle;
        public System.Windows.Forms.Label resourceLabel;
        public System.Windows.Forms.Label autoLabel;
        public Guna.UI2.WinForms.Guna2Button customDLLButton;
        public Guna.UI2.WinForms.Guna2Button openWindow;
        public Guna.UI2.WinForms.Guna2Button autoInject;
        public Guna.UI2.WinForms.Guna2Button customLoc;
        public Guna.UI2.WinForms.Guna2Button AppearanceButton;
        public Guna.UI2.WinForms.Guna2ContextMenuStrip presets;
        public System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem1;
        public System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem1;
        public System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        public Guna.UI2.WinForms.Guna2Button customImage;
        public System.Windows.Forms.Label backImageTitle;
        public Guna.UI2.WinForms.Guna2Button roundedToggle;
        public System.Windows.Forms.Label roundedTitle;
        public Guna.UI2.WinForms.Guna2Button toastsToggle;
        public Guna.UI2.WinForms.Guna2Button AppearanceButton2;
        public System.Windows.Forms.Label toastsTitle;
        public Guna.UI2.WinForms.Guna2ComboBox toastsSelector;
        public System.Windows.Forms.NotifyIcon TrayIcon;
        public Guna.UI2.WinForms.Guna2ContextMenuStrip TrayIconContextMenu;
        public System.Windows.Forms.ToolStripMenuItem injectToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        public Guna.UI2.WinForms.Guna2Button versionButton;
        public FontAwesome.Sharp.IconPictureBox versionButtonIcon;
        public System.Windows.Forms.TabPage versionsTab;
        public Guna.UI2.WinForms.Guna2TabControl contentView;
        public Guna.UI2.WinForms.Guna2Transition FadeEffectBetweenPages;
        public Guna.UI2.WinForms.Guna2Button performanceModeToggle;
        public System.Windows.Forms.Label performanceModeTitle;
        public System.Windows.Forms.Timer fadeIn;
        public System.Windows.Forms.Timer internetCheckTimer;
        public System.Windows.Forms.LinkLabel changeLogLink;
        public Guna.UI2.WinForms.Guna2NumericUpDown injectDelay;
        public System.Windows.Forms.Label injectDelayLabel;
        public Guna.UI2.WinForms.Guna2ContextMenuStrip DefaultDLLSelector;
        private System.ComponentModel.IContainer components;
    }
}

