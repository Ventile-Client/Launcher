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
                    using (var client = new WebClient())
                    {
                        client.DownloadFile(link, Path.Combine(path, name));
                    }
                }
                catch
                {
                    MAIN.dLogger.Log($"Failed to download\n   Link: {link}\n   Path: {Path.Combine(path, name)}", LogLevel.Error);
                }
                return Task.CompletedTask;
            });
        }

        public static Task Download(string link, string path, string name)
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
                MAIN.dLogger.Log($"Failed to download\n   Link: {link}\n   Path: {Path.Combine(path, name)}", LogLevel.Error);
            }

            return Task.CompletedTask;
        }
    }
}
