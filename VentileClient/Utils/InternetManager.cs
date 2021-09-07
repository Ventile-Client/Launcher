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

        private static List<bool> PREVIOUS_INTERNET_STATE = new List<bool>() { true };

        public static void ReCheckInternet()
        {
            bool internet = InternetGetConnectedState(out int _, 0);; 
            PREVIOUS_INTERNET_STATE.Add(internet);
            if (internet && !PREVIOUS_INTERNET_STATE[PREVIOUS_INTERNET_STATE.Count - 2])
            {
                if (MAIN.cosmeticsButton.Checked) MAIN.contentView.SelectedTab = MAIN.cosmeticsTab;
                else if (MAIN.versionButton.Checked) MAIN.contentView.SelectedTab = MAIN.versionsTab;
                DataManager.Home();
                DataManager.Cosmetics();
                ColorManager.Version();
                Notif.Toast("Internet", "Connection found!");
            }
            else if (!internet && PREVIOUS_INTERNET_STATE[PREVIOUS_INTERNET_STATE.Count - 2])
            {
                MAIN.versionsPanel.Controls.Clear();

                //Colors
                // Make the color variable smaller
                Color foreColor = ColorTranslator.FromHtml(MAIN.themeCS.Foreground);

                Notif.Toast("Internet", "Could not find a connection");

                var lbl = new System.Windows.Forms.Label()
                {
                    AutoSize = true,
                    Text = "No Internet...",
                    Font = new Font("Segoe UI", 20.25f, FontStyle.Bold),
                    Location = new Point(5, 14),
                    ForeColor = foreColor
                };
                lbl.BringToFront();
                MAIN.versionsPanel.Controls.Add(lbl);

                var noInternet = new System.Windows.Forms.Label()
                {
                    AutoSize = true,
                    Text = "Cannot retrieve data!\n - A firewall isn't allowing the launcher to acess the internet\n - You don't have an internet connection\n - If a reason isn't listed here, ask for help or contact the devs!",
                    Font = new Font("Segoe UI", 14.25f),
                    Location = new Point(9, 30 + 15 * 2),
                    ForeColor = foreColor
                };
                noInternet.BringToFront();
                MAIN.versionsPanel.Controls.Add(noInternet);

                MAIN.contentView.SelectedTab = MAIN.versionsTab;
            }
        }
    }
}
