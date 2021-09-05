using DiscordRPC;
using System;
using System.IO;
using System.Threading;
using VentileClient.JSON_Template_Classes;

namespace VentileClient
{
    public static class RPC
    {
        public static void Toast(string title, string msg)
        {
            var toast = new Toast();
            toast.ShowToast(title, msg, config, theme);
        }

        static DiscordRpcClient client = new DiscordRpcClient(MainWindow.INSTANCE.ventile_settings.rpcClientID);

        static ConfigTemplate config = MainWindow.INSTANCE.configCS;
        static ThemeTemplate theme = MainWindow.INSTANCE.themeCS;

        public static void Idling()
        {
            if (config.RichPresence)
            {
                if (!client.IsInitialized)
                {

                    client = new DiscordRpcClient(MainWindow.INSTANCE.ventile_settings.rpcClientID);
                    client.Initialize();
                }

                // Sets the rich presence
                try
                {
                    if (config.RpcButton)
                    {
                        client.SetPresence(new RichPresence()
                        {
                            Details = "Idling In Launcher...",
                            State = config.RpcText,
                            Timestamps = new Timestamps(),
                            Assets = new Assets()
                            {
                                LargeImageKey = "logo",
                                LargeImageText = MainWindow.INSTANCE.ventile_settings.launcherVersion,
                            },
                            Buttons = new Button[]
                            {
                                new Button() { Label = config.RpcButtonText, Url = config.RpcButtonLink },
                                new Button() { Label = "Ventile's Server", Url = "https://discord.gg/ventile" }
                            }
                        });
                    }
                    else
                    {
                        client.SetPresence(new RichPresence()
                        {
                            Details = "Idling In Launcher...",
                            State = config.RpcText,
                            Timestamps = new Timestamps(),
                            Assets = new Assets()
                            {
                                LargeImageKey = "logo",
                                LargeImageText = MainWindow.INSTANCE.ventile_settings.launcherVersion,
                            },
                            Buttons = new Button[]
                            {
                                new Button() { Label = "Ventile's Server", Url = "https://discord.gg/ventile" }
                            }
                        });
                    }
                }
                catch
                {
                    Toast("Rich Presence", "There was an error with RPC");
                }
            }
        }

        public static void Disable()
        {
            Thread.Sleep(100);
            try
            {
                client.Dispose();
            }
            catch (Exception ex)
            {
                MainWindow.INSTANCE.defaultLogger.Log(ex);
            }
        }

        public static void ChangeState(string detail)
        {
            if (config.RichPresence)
            {
                if (!client.IsInitialized)
                {

                    client = new DiscordRpcClient(MainWindow.INSTANCE.ventile_settings.rpcClientID);
                    client.Initialize();
                }

                // Sets the rich presence
                try
                {
                    if (config.RpcButton)
                    {
                        client.SetPresence(new RichPresence()
                        {
                            Details = detail,
                            State = config.RpcText,
                            Timestamps = new Timestamps(),
                            Assets = new Assets()
                            {
                                LargeImageKey = "logo",
                                LargeImageText = MainWindow.INSTANCE.ventile_settings.launcherVersion,
                            },
                            Buttons = new Button[]
                            {
                                new Button() { Label = config.RpcButtonText, Url = config.RpcButtonLink },
                                new Button() { Label = "Ventile's Server", Url = "https://discord.gg/ventile" }
                            }
                        });
                    }
                    else
                    {
                        client.SetPresence(new RichPresence()
                        {
                            Details = detail,
                            State = config.RpcText,
                            Timestamps = new Timestamps(),
                            Assets = new Assets()
                            {
                                LargeImageKey = "logo",
                                LargeImageText = MainWindow.INSTANCE.ventile_settings.launcherVersion,
                            },
                            Buttons = new Button[]
                            {
                                new Button() { Label = "Ventile's Server", Url = "https://discord.gg/ventile" }
                            }
                        });
                    }
                    Toast("Rich Prescence", "In the Launcher!");
                }
                catch (Exception ex)
                {
                    Toast("Rich Presence", "There was an error with RPC");
                    MainWindow.INSTANCE.defaultLogger.Log(ex);
                }
            }
        }
    }
}
