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
    public class UpdateCheck
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

        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        public void CheckForUpdate()
        {
            timer.Tick += timer_tick;
            timer.Interval = 1;
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

            string latestVersion = File.ReadAllLines(@"C:\temp\VentileClient\Version.txt")[0];
            
            File.Delete(@"C:\temp\VentileClient\Version.txt");
            File.Delete(@"C:\temp\VentileClient\Version.zip");

            if (latestVersion != Properties.Ventile.Default.Version && !Properties.Ventile.Default.IsBeta)
            {
                UpdatePrompt updatePrompt = new UpdatePrompt(MainWindow.instance);
                updatePrompt.Show();
                updatePrompt.updateVersionText(latestVersion);
                MainWindow.instance.Opacity = 0;
                return;
            }
            timer.Start();
        }

        private void timer_tick(object sender, EventArgs e)
        {
            if (MainWindow.instance.Opacity < 1)
            {
                MainWindow.instance.Opacity += 0.04;
            } else
            {
                timer.Stop();
            }
        }
    }
}
