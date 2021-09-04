using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace VentileClient.Utils
{
    public static class DownloadManager
    {
        static MainWindow MAIN = MainWindow.INSTANCE;
        public static async Task Download(string link, string path, string name)
        {
            await Task.Run(() =>
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
                    MAIN.defaultLogger.Log($"Failed to download\n   Link: {link}\n   Path: {Path.Combine(path, name)}", LogLevel.Error);
                }
                return Task.CompletedTask;
            });
        }
    }
}
