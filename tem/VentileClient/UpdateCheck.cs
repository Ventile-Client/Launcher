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

        public void CheckForUpdate()
        {
            if (!Properties.Ventile.Default.IsBeta) return; //Ignore update if in beta mode

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

            if (latestVersion != Properties.Ventile.Default.Version)
            {
                UpdatePrompt updatePrompt = new UpdatePrompt(MainWindow.instance);
                updatePrompt.Show();
                updatePrompt.updateVersionText(latestVersion);
                MainWindow.instance.Opacity = 0;
            }

            File.Delete(@"C:\temp\VentileClient\Version.txt");
            File.Delete(@"C:\temp\VentileClient\Version.zip");

        }
    }
}
