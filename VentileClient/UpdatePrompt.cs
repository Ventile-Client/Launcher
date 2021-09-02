using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using VentileClient.JSON_Template_Classes;

namespace VentileClient
{
    public partial class UpdatePrompt : Form
    {
        #region Downloading Code

        public void Download(string link, string path, string name)
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
        }

        #endregion Downloading Code

        private MainWindow _mainWndw;
        private ThemeTemplate _themeCS;

        public UpdatePrompt(MainWindow form)
        {
            InitializeComponent();
            _mainWndw = form;
        }

        private void no_Click(object sender, EventArgs e)
        {
            if (_chnglogPrmpt != null)
            {
                _chnglogPrmpt.fadeOut.Start();
            }
            fadeOut.Start();

            _mainWndw.fadeIn.Start();
            _mainWndw.BringToFront();

        }

        private void update_Click(object sender, EventArgs e)
        {
            if (_chnglogPrmpt != null)
            {
                _chnglogPrmpt.fadeOut.Start();
            }
            try
            {
                if (!System.IO.File.Exists(@"C:\temp\VentileClient\Ventile-Updater.exe"))
                {
                    Download(string.Format(@"https://github.com/" + MainWindow.LINK_SETTINGS.repoOwner + "/" + MainWindow.LINK_SETTINGS.downloadRepo + @"/blob/main/${0}?raw=true", "VentileUpdater.exe"), @"C:\temp\VentileClient\", "Ventile-Updater.exe");
                }
                Process.Start(@"C:\temp\VentileClient\Ventile-Updater.exe");
            }
            catch (Exception err)
            {
                MessageBox.Show("Please open Ventile-Updater.exe manually\n   Error: " + err.Message, "Error", MessageBoxButtons.OK);
            }
            finally
            {
                _mainWndw.Close();
            }
        }

        string[] _changelog;
        ChangelogPrompt _chnglogPrmpt;
        public void UpdateVersionText(string[] changelogParam, string latestVersion, ThemeTemplate theme)
        {
            _changelog = changelogParam;
            _themeCS = theme;
            version.Text = latestVersion;
            this.BackColor = ColorTranslator.FromHtml(theme.Background);
            text1.ForeColor = ColorTranslator.FromHtml(theme.Faded);
            version.ForeColor = ColorTranslator.FromHtml(theme.Faded);
            text2.ForeColor = ColorTranslator.FromHtml(theme.Faded);
            Title.ForeColor = ColorTranslator.FromHtml(theme.Foreground);
            text1.BackColor = ColorTranslator.FromHtml(theme.Background);
            version.BackColor = ColorTranslator.FromHtml(theme.Background);
            text2.BackColor = ColorTranslator.FromHtml(theme.Background);
            Title.BackColor = ColorTranslator.FromHtml(theme.Background);
            update.ForeColor = ColorTranslator.FromHtml(theme.Foreground);
            no.ForeColor = ColorTranslator.FromHtml(theme.Foreground);
            update.FillColor = ColorTranslator.FromHtml(theme.SecondBackground);
            no.FillColor = ColorTranslator.FromHtml(theme.SecondBackground);
            this.Refresh();
        }

        private void changeLogLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // New changelog window
            if ((ChangelogPrompt)System.Windows.Forms.Application.OpenForms["ChangelogPrompt"] != null) return;
            _chnglogPrmpt = new ChangelogPrompt(_themeCS, _changelog);
            _chnglogPrmpt.Show();
        }

        private void fadeIn_Tick(object sender, EventArgs e)
        {
            if (Opacity == 1.0)
            {
                fadeIn.Stop();
            }
            this.Opacity += 0.04;
        }

        private void fadeOut_Tick(object sender, EventArgs e)
        {
            if (Opacity == 1.0)
            {
                fadeOut.Stop();
                this.Close();
            }
            this.Opacity -= 0.04;
        }
    }
}
