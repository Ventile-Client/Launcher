using DiscordRPC;
using System;
using System.IO;
using System.Threading;
using VentileClient.JSON_Template_Classes;

namespace VentileClient
{
    public static class RPC
    {
        static DiscordRpcClient client = new DiscordRpcClient(MainWindow.INSTANCE.ventile_settings.rpcID);

        static ConfigTemplate config = MainWindow.INSTANCE.configCS;

        public static void Idling()
        {
            if (config.RichPresence)
            {
                if (!client.IsInitialized)
                {

                    client = new DiscordRpcClient(MainWindow.INSTANCE.ventile_settings.rpcID);
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
                catch (Exception ex)
                {
                    MainWindow.INSTANCE.defaultLogger.Log(ex);
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

                    client = new DiscordRpcClient(MainWindow.INSTANCE.ventile_settings.rpcID);
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
                }
                catch (Exception ex)
                {
                    MainWindow.INSTANCE.defaultLogger.Log(ex);
                }
            }
        }
    }
}
