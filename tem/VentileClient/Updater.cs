using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VentileClient
{
    public partial class Updater : Form
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

        public Updater()
        {
            InitializeComponent();
        }

        private void fadeIn_Tick(object sender, EventArgs e)
        {
            if (Opacity == 1.0)
            {
                fadeIn.Stop();
            }
            Opacity += 0.1;
        }

        private void fadeOut_Tick(object sender, EventArgs e)
        {
            Opacity -= 0.1;
            if (Opacity == 0)
            {
                for (int i = 0; i < 25; i++)
                {
                    MainWindow.instance.Opacity += 0.04;
                    Thread.Sleep(1);
                }

                this.Close();
            }
        }

        private void Updater_Load(object sender, EventArgs e)
        {
            if (File.Exists(@"C:\temp\VentileClient\Version.txt"))
            {
                File.Delete(@"C:\temp\VentileClient\Version.txt");
            }

            if (File.Exists(@"C:\temp\VentileClient\Version.zip"))
            {
                File.Delete(@"C:\temp\VentileClient\Version.zip");
            }

            download(@"https://github.com/DeathlyBower959/Ventile-Client-Downloads/raw/main/Version.zip", @"C:\temp\VentileClient", "Version.zip");
            ZipFile.ExtractToDirectory(@"C:\temp\VentileClient\Version.zip", @"C:\temp\VentileClient\");

            string[] VersionLines = System.IO.File.ReadAllLines(@"C:\temp\VentileClient\Version.txt");

            if (VersionLines[0] != Properties.Ventile.Default.Version)
            {
                UpdatePrompt prompt = new UpdatePrompt(this, MainWindow.instance);
                TopMost = false;
                prompt.Show();
                MainWindow.instance.Opacity = 0;
            }
            else
            {
                fadeOut.Start();
            }
        }
    }
}
