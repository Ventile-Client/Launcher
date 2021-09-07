using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentileClient.JSON_Template_Classes;

namespace VentileClient.Utils
{
    public static class Notif
    {
        public static void Toast(string Title, string Message)
        {
            var toast = new ToastForm();
            toast.ShowToast(Title, Message, MainWindow.INSTANCE.configCS, MainWindow.INSTANCE.themeCS);
        }

        public static void Toast(string Title, string Message, ConfigTemplate Config)
        {
            var toast = new ToastForm();
            toast.ShowToast(Title, Message, Config, MainWindow.INSTANCE.themeCS);
        }

        public static void Toast(string Title, string Message, ConfigTemplate Config, ThemeTemplate Theme)
        {
            var toast = new ToastForm();
            toast.ShowToast(Title, Message, Config, Theme);
        }
    }
}
