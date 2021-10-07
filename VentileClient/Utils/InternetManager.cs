using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using VentileClient.JSON_Template_Classes;
using VentileClient.LauncherUtils;

namespace VentileClient.Utils
{
    public static class InternetManager
    {
        static MainWindow MAIN = MainWindow.INSTANCE;

        [DllImport("wininet.dll")]
        static extern bool InternetGetConnectedState(out int Description, int ReservedValue);

        static bool OnlineCheck()
        {
            var request = (HttpWebRequest)WebRequest.Create("https://github.com/");
            request.Timeout = 15000;
            request.Method = "HEAD";
            try
            {
                using (var response = (HttpWebResponse)request.GetResponse())
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
            bool internetcheckone = InternetGetConnectedState(out int _, 0);
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

        private static List<bool> PREVIOUS_INTERNET_STATE = new List<bool>() { true, true };

        public static async void ReCheckInternet()
        {
            bool internet = InternetGetConnectedState(out int _, 0);;
            PREVIOUS_INTERNET_STATE.Add(internet);
            PREVIOUS_INTERNET_STATE.RemoveAt(PREVIOUS_INTERNET_STATE.Count - 3);
            if (internet && !PREVIOUS_INTERNET_STATE[PREVIOUS_INTERNET_STATE.Count - 2])
            {
                if (MAIN.cosmeticsButton.Checked) MAIN.contentView.SelectedTab = MAIN.cosmeticsTab;

                Notif.Toast("Internet", "Connection found!");
                DataManager.Cosmetics();
                await DataManager.GetMCVersions(false);
                DataManager.Version(true);
            }
            else if (!internet && PREVIOUS_INTERNET_STATE[PREVIOUS_INTERNET_STATE.Count - 2])
            {
                Notif.Toast("Internet", "You don't have an active wifi connection!");
                DataManager.Version(false);
            }
        }
    }
}
