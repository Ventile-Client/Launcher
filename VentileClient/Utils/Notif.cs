using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using VentileClient.JSON_Template_Classes;

namespace VentileClient.Utils
{
    public static class Notif
    {
        static int index = 0;
        public static void Toast(string Title, string Message)
        {
            if (MainWindow.INSTANCE.configCS.Toasts == 2)
            {
                new ToastContentBuilder()
                    .AddText(Title)
                    .AddText(Message)
                    .SetToastDuration(ToastDuration.Short)
                    .Show(notif =>
                    {
                        notif.Tag = index.ToString();
                        Task.Delay(15000).ContinueWith((t) =>
                        {
                            ToastNotificationManagerCompat.History.Remove(index.ToString());
                        });
                    });

                return;
            }
            var toast = new ToastForm();
            toast.ShowToast(Title, Message, MainWindow.INSTANCE.configCS, MainWindow.INSTANCE.themeCS);
        }

        public static void Toast(string Title, string Message, ConfigTemplate Config)
        {
            if (MainWindow.INSTANCE.configCS.Toasts == 2)
            {
                new ToastContentBuilder()
                    .AddText(Title)
                    .AddText(Message)
                    .SetToastDuration(ToastDuration.Short)
                    .Show(notif =>
                    {
                        notif.Tag = index.ToString();
                        Task.Delay(15000).ContinueWith((t) =>
                        {
                            ToastNotificationManagerCompat.History.Remove(index.ToString());
                        });
                    });

                return;
            }

            var toast = new ToastForm();
            toast.ShowToast(Title, Message, Config, MainWindow.INSTANCE.themeCS);

        }

        public static void Toast(string Title, string Message, ConfigTemplate Config, ThemeTemplate Theme)
        {
            if (MainWindow.INSTANCE.configCS.Toasts == 2)
            {
                new ToastContentBuilder()
                    .AddText(Title)
                    .AddText(Message)
                    .SetToastDuration(ToastDuration.Short)
                    .Show(notif =>
                    {
                        notif.Tag = index.ToString();
                        Task.Delay(15000).ContinueWith((t) =>
                        {
                            ToastNotificationManagerCompat.History.Remove(index.ToString());
                        });
                    });

                return;
            }

            var toast = new ToastForm();
            toast.ShowToast(Title, Message, Config, Theme);
        }
    }
}
