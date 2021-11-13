using DiscordRPC;
using System;
using System.Threading;
using VentileClient.JSON_Template_Classes;

namespace VentileClient
{
    public static class RPC
    {
        static DiscordRpcClient CLIENT = new DiscordRpcClient(MainWindow.INSTANCE.ventile_settings.rpcID);

        static ConfigTemplate CONFIG = MainWindow.INSTANCE.configCS;

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
                            State = CONFIG.RpcText.Trim(),
                            Timestamps = new Timestamps(),
                            Assets = new Assets()
                            {
                                LargeImageKey = "logo",
                                LargeImageText = MainWindow.INSTANCE.ventile_settings.launcherVersion.ToString(),
                            },
                            Buttons = new Button[]
                            {
                                new Button() { Label = CONFIG.RpcButtonText.Trim(), Url = CONFIG.RpcButtonLink},
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
                                LargeImageText = MainWindow.INSTANCE.ventile_settings.launcherVersion.ToString(),
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
                            State = CONFIG.RpcText.Trim(),
                            Timestamps = new Timestamps(),
                            Assets = new Assets()
                            {
                                LargeImageKey = "logo",
                                LargeImageText = MainWindow.INSTANCE.ventile_settings.launcherVersion.ToString(),
                            },
                            Buttons = new Button[]
                            {
                                new Button() { Label = CONFIG.RpcButtonText.Trim(), Url = CONFIG.RpcButtonLink},
                                new Button() { Label = "Ventile's Server", Url = MainWindow.INSTANCE.link_settings.discordInvite }
                            }
                        });
                    }
                    else
                    {
                        CLIENT.SetPresence(new RichPresence()
                        {
                            Details = detail,
                            State = CONFIG.RpcText.Trim(),
                            Timestamps = new Timestamps(),
                            Assets = new Assets()
                            {
                                LargeImageKey = "logo",
                                LargeImageText = MainWindow.INSTANCE.ventile_settings.launcherVersion.ToString(),
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
