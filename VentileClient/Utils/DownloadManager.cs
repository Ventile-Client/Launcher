using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace VentileClient.Utils
{
    public static class DownloadManager
    {
        static MainWindow MAIN = MainWindow.INSTANCE;
        public static async Task DownloadAsync(string link, string path, string name)
        {
            await Task.Run(() =>
            {

                try
                {
                    string combinedPath = Path.Combine(path, name);
                    if (Directory.Exists(path))
                    {

                        using (var client = new WebClient())
                        {
                            client.DownloadFile(link, combinedPath);
                        }
                    }
                }
                catch (Exception err)
                {
                    MAIN?.dLogger?.Log($"Failed to download\n   Link: {link}\n   Path: {Path.Combine(path, name)}\n   Error: {err.Message}", LogLevel.Error);
                }
                return Task.CompletedTask;
            });
        }

        public static void Download(string link, string path, string name)
        {
            try
            {
                string combinedPath = Path.Combine(path, name);
                if (Directory.Exists(path))
                {
                    using (var client = new WebClient())
                    {
                        client.DownloadFile(link, combinedPath);
                    }
                }
            }
            catch (Exception err)
            {
                MAIN?.dLogger?.Log($"Failed to download\n   Link: {link}\n   Path: {Path.Combine(path, name)}\n   Error: {err.Message}", LogLevel.Error);
            }
        }
    }
}
