using DiscordRPC;
using System;
using System.Diagnostics;
using System.Net;
using System.Threading;
using VentileClient.JSON_Template_Classes;
using VentileClient.Utils;

namespace VentileClient
{
    public static class RPC
    {
        static DiscordRpcClient CLIENT = new DiscordRpcClient(MainWindow.INSTANCE.ventile_settings.rpcID);

        static ConfigTemplate CONFIG = MainWindow.INSTANCE.configCS;
        private enum RpcType
        {
            Text,
            ButtonText,
            ButtonLink
        }
        private static string FormatString(string text, RpcType type)
        {
            if (type == RpcType.Text)
            {
                return text.Trim();
            }

            if (type == RpcType.ButtonLink)
            {
                string newString = text;

                if (!(newString.StartsWith("https://") || newString.StartsWith("http://")))
                    newString = "http://" + newString;

                return newString;
            }

            if (type == RpcType.ButtonText)
            {
                return text.Trim();
            }

            return string.Empty;
        }

        public static void Idling()
        {
            if (CONFIG.RichPresence)
            {
                if (!CLIENT.IsInitialized)
                {
                    CLIENT = new DiscordRpcClient(MainWindow.INSTANCE.ventile_settings.rpcID);
                    CLIENT.Initialize();
                }

                // Sets the rich presence
                try
                {
                    if (CONFIG.RpcButton)
                    {
                        CLIENT.SetPresence(new RichPresence()
                        {
                            Details = "Idling In Launcher...",
                            State = FormatString(CONFIG.RpcText, RpcType.Text),
                            Timestamps = new Timestamps(),
                            Assets = new Assets()
                            {
                                LargeImageKey = "logo",
                                LargeImageText = MainWindow.INSTANCE.ventile_settings.launcherVersion,
                            },
                            Buttons = new Button[]
                            {
                                new Button() { Label = FormatString(CONFIG.RpcButtonText, RpcType.ButtonText), Url = FormatString(CONFIG.RpcButtonLink, RpcType.ButtonLink)},
                                new Button() { Label = "Ventile's Server", Url = MainWindow.INSTANCE.link_settings.discordInvite }
                            }
                        });
                    }
                    else
                    {
                        CLIENT.SetPresence(new RichPresence()
                        {
                            Details = "Idling In Launcher...",
                            State = CONFIG.RpcText,
                            Timestamps = new Timestamps(),
                            Assets = new Assets()
                            {
                                LargeImageKey = "logo",
                                LargeImageText = MainWindow.INSTANCE.ventile_settings.launcherVersion,
                            },
                            Buttons = new Button[]
                            {
                                new Button() { Label = "Ventile's Server", Url = MainWindow.INSTANCE.link_settings.discordInvite }
                            }
                        });
                    }
                }
                catch (Exception ex)
                {
                    MainWindow.INSTANCE.dLogger.Log(ex);
                }
            }
        }

        public static void Disable()
        {
            Thread.Sleep(100);
            try
            {
                CLIENT.Dispose();
            }
            catch (Exception ex)
            {
                MainWindow.INSTANCE.dLogger.Log(ex);
            }
        }

        public static void ChangeState(string detail)
        {
            if (CONFIG.RichPresence)
            {
                if (!CLIENT.IsInitialized)
                {

                    CLIENT = new DiscordRpcClient(MainWindow.INSTANCE.ventile_settings.rpcID);
                    CLIENT.Initialize();
                }

                // Sets the rich presence
                try
                {
                    if (CONFIG.RpcButton)
                    {
                        CLIENT.SetPresence(new RichPresence()
                        {
                            Details = detail,
                            State = FormatString(CONFIG.RpcText, RpcType.Text),
                            Timestamps = new Timestamps(),
                            Assets = new Assets()
                            {
                                LargeImageKey = "logo",
                                LargeImageText = MainWindow.INSTANCE.ventile_settings.launcherVersion,
                            },
                            Buttons = new Button[]
                            {
                                new Button() { Label = FormatString(CONFIG.RpcButtonText, RpcType.ButtonText), Url = FormatString(CONFIG.RpcButtonLink, RpcType.ButtonLink) },
                                new Button() { Label = "Ventile's Server", Url = MainWindow.INSTANCE.link_settings.discordInvite }
                            }
                        });
                    }
                    else
                    {
                        CLIENT.SetPresence(new RichPresence()
                        {
                            Details = detail,
                            State = FormatString(CONFIG.RpcText, RpcType.Text),
                            Timestamps = new Timestamps(),
                            Assets = new Assets()
                            {
                                LargeImageKey = "logo",
                                LargeImageText = MainWindow.INSTANCE.ventile_settings.launcherVersion,
                            },
                            Buttons = new Button[]
                            {
                                new Button() { Label = "Ventile's Server", Url = MainWindow.INSTANCE.link_settings.discordInvite }
                            }
                        });
                    }
                }
                catch (Exception ex)
                {
                    MainWindow.INSTANCE.dLogger.Log(ex);
                }
            }
        }
    }
}
