using DiscordRPC;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using VentileClient.JSON_Template_Classes;
using Newtonsoft.Json;

namespace VentileClient
{
    class RPC
    {
        public void Toast(string title, string msg)
        {
            Toast toast = new Toast();
            toast.showToast(title, msg, configCS, themeCS);
        }

        #region Downloading Code

        public void download(string link, string path, string name)
        {
            using (WebClient Client = new WebClient())
            {
                if (path.EndsWith(@"\"))
                {
                    Client.DownloadFile(link, path + name);
                }
                else
                {
                    Client.DownloadFile(link, path + @"\" + name);
                }
            }
        }

        #endregion Downloading Code

        #region Stream Read/Write

        ConfigTemplate configCS = new ConfigTemplate();
        ThemeTemplate themeCS = new ThemeTemplate();

        private void readConfig(string path)
        {
            try
            {
                string temp = File.ReadAllText(path);
                configCS = JsonConvert.DeserializeObject<ConfigTemplate>(temp);
            }
            catch
            {
                this.Toast("Error", "There was an error :(");
            }
        }

        private void readTheme(string path)
        {
            try
            {
                string temp = File.ReadAllText(path);
                themeCS = JsonConvert.DeserializeObject<ThemeTemplate>(temp);
            }
            catch
            {
                this.Toast("Error", "There was an error :(");
            }
        }
        #endregion

        public DiscordRpcClient client = new DiscordRpcClient("832806990953840710");

        public static bool initialized = false;

        public void Initialize()
        {
            if (File.Exists(@"C:\temp\VentileClient\Presets\Config.txt"))
            {
                readConfig(@"C:\temp\VentileClient\Presets\Config.json");
            }
            else
            {
                try
                {
                    client.Dispose();
                }
                catch
                {

                }
            }

            if (configCS.RichPresence)
            {
                client = new DiscordRpcClient("832806990953840710");

                Thread.Sleep(100);
                client.Initialize();

                //Set the rich presence
                //Call this as many times as you want and anywhere in your code.
                try
                {
                    if (configCS.RpcButton)
                    {
                        client.SetPresence(new RichPresence()
                        {
                            Details = "Idling In Launcher...",
                            State = configCS.RpcText,
                            Timestamps = new Timestamps(),
                            Assets = new Assets()
                            {
                                LargeImageKey = "logo",
                                LargeImageText = Properties.Ventile.Default.Version,
                            },
                            Buttons = new DiscordRPC.Button[]
                            {
                                new DiscordRPC.Button() { Label = configCS.RpcButtonText, Url = configCS.RpcButtonLink },
                                new DiscordRPC.Button() { Label = "Ventile's Server", Url = "https://discord.gg/mCyHtD9twt" }
                            }
                        });
                    }
                    else
                    {
                        client.SetPresence(new RichPresence()
                        {
                            Details = "Idling In Launcher...",
                            State = configCS.RpcText,
                            Timestamps = new Timestamps(),
                            Assets = new Assets()
                            {
                                LargeImageKey = "logo",
                                LargeImageText = Properties.Ventile.Default.Version,
                            },
                            Buttons = new DiscordRPC.Button[]
                            {
                                new DiscordRPC.Button() { Label = "Ventile's Server", Url = "https://discord.gg/mCyHtD9twt" }
                            }
                        });
                    }
                }
                catch
                {
                    this.Toast("Rich Presence", "There was an error with RPC");
                }
            }
        }

        public void Deinitialize()
        {
            Thread.Sleep(500);
            try
            {
                Thread.Sleep(150);
                client.Dispose();
            }
            catch
            {

            }
        }

        //Home
        public void Home()
        {

            if (configCS.RichPresence)
            {
            bool error = false;
            if (File.Exists(@"C:\temp\VentileClient\Presets\Config.json"))
            {
                readConfig(@"C:\temp\VentileClient\Presets\Config.json");
            }
            else
            {
                error = true;
            }

            if (File.Exists(@"C:\temp\VentileClient\Presets\Theme.json"))
            {
                readTheme(@"C:\temp\VentileClient\Presets\Theme.json");
            }
            else
            {
                error = true;
            }

            if (error)
            {
                this.Toast("RPC", "There was an error!");
                return;
            }
                try
                {
                    if (configCS.RpcButton)
                    {
                        client.SetPresence(new RichPresence()
                        {
                            Details = "Idling In Launcher...",
                            State = configCS.RpcText,
                            Timestamps = new Timestamps(),
                            Assets = new Assets()
                            {
                                LargeImageKey = "logo",
                                LargeImageText = Properties.Ventile.Default.Version,
                            },
                            Buttons = new DiscordRPC.Button[]
                        {
                        new DiscordRPC.Button() { Label = configCS.RpcButtonText, Url = configCS.RpcButtonLink },
                        new DiscordRPC.Button() { Label = "Ventile's Server", Url = "https://discord.gg/mCyHtD9twt" }
                        }
                        });
                    }
                    else
                    {
                        client.SetPresence(new RichPresence()
                        {
                            Details = "Idling In Launcher...",
                            State = configCS.RpcText,
                            Timestamps = new Timestamps(),
                            Assets = new Assets()
                            {
                                LargeImageKey = "logo",
                                LargeImageText = Properties.Ventile.Default.Version,
                            },
                            Buttons = new DiscordRPC.Button[]
                        {
                        new DiscordRPC.Button() { Label = "Ventile's Server", Url = "https://discord.gg/mCyHtD9twt" }
                        }
                        });
                    }
                    this.Toast("Rich Prescence", "In the Launcher!");
                }
                catch
                {
                    this.Toast("Rich Presence", "There was an error with RPC");
                }
            }
        }

        //Settings
        public void Settings()
        {
            if (configCS.RichPresence)
            {
                bool error = false;
                if (File.Exists(@"C:\temp\VentileClient\Presets\Config.json"))
                {
                    readConfig(@"C:\temp\VentileClient\Presets\Config.json");
                }
                else
                {
                    error = true;
                }

                if (File.Exists(@"C:\temp\VentileClient\Presets\Theme.json"))
                {
                    readTheme(@"C:\temp\VentileClient\Presets\Theme.json");
                }
                else
                {
                    error = true;
                }

                if (error)
                {
                    this.Toast("RPC", "There was an error!");
                    return;
                }
                try
                {
                    if (configCS.RpcButton)
                    {
                        client.SetPresence(new RichPresence()
                        {
                            Details = "Changing Settings...",
                            State = configCS.RpcText,
                            Timestamps = new Timestamps(),
                            Assets = new Assets()
                            {
                                LargeImageKey = "logo",
                                LargeImageText = Properties.Ventile.Default.Version,
                            },
                            Buttons = new DiscordRPC.Button[]
                            {
                                new DiscordRPC.Button() { Label = configCS.RpcButtonText, Url = configCS.RpcButtonLink },
                                new DiscordRPC.Button() { Label = "Ventile's Server", Url = "https://discord.gg/mCyHtD9twt" }
                            }
                        });
                    }
                    else
                    {
                        client.SetPresence(new RichPresence()
                        {
                            Details = "Changing Settings...",
                            State = configCS.RpcText,
                            Timestamps = new Timestamps(),
                            Assets = new Assets()
                            {
                                LargeImageKey = "logo",
                                LargeImageText = Properties.Ventile.Default.Version,
                            },
                            Buttons = new DiscordRPC.Button[]
                            {
                                new DiscordRPC.Button() { Label = "Ventile's Server", Url = "https://discord.gg/mCyHtD9twt" }
                            }
                        });
                    }
                }
                catch
                {
                    this.Toast("Rich Presence", "There was an error with RPC");
                }
            }
        }

        //In Game
        public void InGame()
        {
            if (configCS.RichPresence)
            {
                bool error = false;
                if (File.Exists(@"C:\temp\VentileClient\Presets\Config.json"))
                {
                    readConfig(@"C:\temp\VentileClient\Presets\Config.json");
                }
                else
                {
                    error = true;
                }

                if (File.Exists(@"C:\temp\VentileClient\Presets\Theme.json"))
                {
                    readTheme(@"C:\temp\VentileClient\Presets\Theme.json");
                }
                else
                {
                    error = true;
                }

                if (error)
                {
                    this.Toast("RPC", "There was an error!");
                    return;
                }
                try
                {
                    if (configCS.RpcButton)
                    {
                        client.SetPresence(new RichPresence()
                        {
                            Details = "In the Game!",
                            State = configCS.RpcText,
                            Timestamps = new Timestamps(),
                            Assets = new Assets()
                            {
                                LargeImageKey = "logo",
                                LargeImageText = Properties.Ventile.Default.Version,
                            },
                            Buttons = new DiscordRPC.Button[]
                            {
                                new DiscordRPC.Button() { Label = configCS.RpcButtonText, Url = configCS.RpcButtonLink },
                                new DiscordRPC.Button() { Label = "Ventile's Server", Url = "https://discord.gg/mCyHtD9twt" }
                            }
                        });
                    }
                    else
                    {
                        client.SetPresence(new RichPresence()
                        {
                            Details = "In the Game!",
                            State = configCS.RpcText,
                            Timestamps = new Timestamps(),
                            Assets = new Assets()
                            {
                                LargeImageKey = "logo",
                                LargeImageText = Properties.Ventile.Default.Version,
                            },
                            Buttons = new DiscordRPC.Button[]
                            {
                                new DiscordRPC.Button() { Label = "Ventile's Server", Url = "https://discord.gg/mCyHtD9twt" }
                            }
                        });
                    }

                    this.Toast("Rich Prescence", "In the Game!");
                }
                catch
                {
                    this.Toast("Rich Presence", "There was an error with RPC");
                }
            }
        }
    }
}
