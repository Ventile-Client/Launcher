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

namespace VentileClient
{
    public partial class UpdatePrompt : Form
    {
        #region Downloading Code

        public void download(string link, string path, string name)
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

        private MainWindow mainWndw;

        public UpdatePrompt(MainWindow form)
        {
            InitializeComponent();
            mainWndw = form;
        }

        private void no_Click(object sender, EventArgs e)
        {
            mainWndw.TopMost = true;
            mainWndw.TopMost = false;

            for (int i = 0; i < 25; i++)
            {
                mainWndw.Opacity += 0.04;
                Thread.Sleep(1);
            }
            this.Close();
        }

        private void update_Click(object sender, EventArgs e)
        {
            try
            {
                if (!System.IO.File.Exists(@"C:\temp\VentileClient\Ventile-Updater.exe"))
                {
                    download(@"https://github.com/DeathlyBower959/Ventile-Client-Downloads/raw/main/Ventile-Updater.exe", @"C:\temp\VentileClient\", "Ventile-Updater.exe");
                }
                Process.Start(@"C:\temp\VentileClient\Ventile-Updater.exe");
            }
            catch (Exception err)
            {
                MessageBox.Show("Please open Ventile-Updater.exe manually\n   Error: " + err.Message, "Error", MessageBoxButtons.OK);
            }
            finally
            {
                mainWndw.Close();
            }
        }

        public void updateVersionText(string versionParam)
        {
            version.Text = versionParam;
        }
    }
}
