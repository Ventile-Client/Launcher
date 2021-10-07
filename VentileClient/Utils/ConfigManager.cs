using Newtonsoft.Json;
using System;
using System.IO;
using VentileClient.JSON_Template_Classes;
using System.Threading.Tasks;


namespace VentileClient.Utils
{
    public static class ConfigManager
    {
        static MainWindow MAIN = MainWindow.INSTANCE;
        public static void ReadConfig(string path)
        {
            try
            {
                if (!File.Exists(path))
                {
                    MAIN.configCS = new ConfigTemplate()
                    {
                        WindowState = "hide",
                        AutoInject = true,
                        RichPresence = true,
                        RpcText = "No Rich Presence",
                        RpcButton = false,
                        RpcButtonText = "No Button Text",
                        RpcButtonLink = "https://none",
                        CustomDLL = true,
                        DefaultDLL = null,
                        Persona = true,
                        PersonaLoc = null,
                        InjectDelay = 0,
                        Toasts = true,
                        ToastsLoc = "topRight",
                        RoundedButtons = true,
                        BackgroundImage = false,
                        BackgroundImageLoc = null,
                        DefaultProfile = "Default"
                    };

                    WriteConfig(path);
                    return;
                }
                string temp = File.ReadAllText(path);
                MAIN.configCS = JsonConvert.DeserializeObject<ConfigTemplate>(temp);
                MAIN.cLogger.Log("Successfully read: " + Path.GetFileName(path));
            }
            catch (Exception ex)
            {
                Notif.Toast("Error", "There was an error :(");
                MAIN.cLogger.Log(ex);
            }
        }

        public static async void WriteConfig(string path)
        {
            await Task.Run(() =>
            {
                try
                {
                    ConfigTemplate temp = MAIN.configCS;

                    string json = JsonConvert.SerializeObject(temp, Formatting.Indented);
                    File.WriteAllText(path, json);
                    MAIN.cLogger.Log("Successfully wrote to " + Path.GetFileName(path));
                }
                catch (Exception ex)
                {
                    Notif.Toast("Error", "There was an error :(");
                    MAIN.cLogger.Log(ex);
                }
            });
        }

        public static void ReadTheme(string path)
        {
            try
            {
                if (!File.Exists(path))
                {
                    MAIN.themeCS = new ThemeTemplate()
                    {
                        Theme = "dark",
                        Background = "#141414",
                        SecondBackground = "#282828",
                        Foreground = "#FFFFFF",
                        Accent = "#4169FF",
                        Outline = "#050505",
                        Faded = "#C0C0C0"
                    };

                    WriteTheme(path);
                    return;
                }
                string temp = File.ReadAllText(path);
                MAIN.themeCS = JsonConvert.DeserializeObject<ThemeTemplate>(temp);
                MAIN.cLogger.Log("Successfully read: " + Path.GetFileName(path));
            }
            catch (Exception ex)
            {
                Notif.Toast("Error", "There was an error :(");
                MAIN.cLogger.Log(ex);
            }
        }

        public static async void WriteTheme(string path)
        {
            await Task.Run(() =>
            {
                try
                {
                    ThemeTemplate temp = MAIN.themeCS;

                    string json = JsonConvert.SerializeObject(temp, Formatting.Indented);
                    File.WriteAllText(path, json);
                    MAIN.cLogger.Log("Successfully wrote to: " + Path.GetFileName(path));
                }
                catch (Exception ex)
                {
                    Notif.Toast("Error", "There was an error :(");
                    MAIN.cLogger.Log(ex);
                }
            });
        }

        public static void GetPresetColors(string directory)
        {
            try
            {
                for (int i = 1; i < 10; i++)
                {
                    string a = $@"preset{i}Theme.json";

                    string fileName = a.Split('.')[0].ToLower();
                    bool isPresetTheme = fileName.StartsWith("preset") && fileName.EndsWith("theme");
                    if (isPresetTheme)
                    {
                        int presetThemeIndex = int.Parse(fileName.Replace("preset", string.Empty).Replace("theme", string.Empty));
                        ThemeTemplate tempTheme;
                        try
                        {
                            string path = $@"{directory}\preset{presetThemeIndex}Theme.json";
                            if (!File.Exists(path))
                            {
                                if (presetThemeIndex == 1)
                                    MAIN.presetCS.p1 = MAIN.themeCS.SecondBackground;

                                if (presetThemeIndex == 2)
                                    MAIN.presetCS.p2 = MAIN.themeCS.SecondBackground;

                                if (presetThemeIndex == 3)
                                    MAIN.presetCS.p3 = MAIN.themeCS.SecondBackground;

                                if (presetThemeIndex == 4)
                                    MAIN.presetCS.p4 = MAIN.themeCS.SecondBackground;

                                if (presetThemeIndex == 5)
                                    MAIN.presetCS.p5 = MAIN.themeCS.SecondBackground;

                                if (presetThemeIndex == 6)
                                    MAIN.presetCS.p6 = MAIN.themeCS.SecondBackground;

                                if (presetThemeIndex == 7)
                                    MAIN.presetCS.p7 = MAIN.themeCS.SecondBackground;

                                if (presetThemeIndex == 8)
                                    MAIN.presetCS.p8 = MAIN.themeCS.SecondBackground;
                            }
                            else
                            {
                                string temp = File.ReadAllText(path);
                                tempTheme = JsonConvert.DeserializeObject<ThemeTemplate>(temp);

                                if (presetThemeIndex == 1)
                                    MAIN.presetCS.p1 = tempTheme.Accent;

                                if (presetThemeIndex == 2)
                                    MAIN.presetCS.p2 = tempTheme.Accent;

                                if (presetThemeIndex == 3)
                                    MAIN.presetCS.p3 = tempTheme.Accent;

                                if (presetThemeIndex == 4)
                                    MAIN.presetCS.p4 = tempTheme.Accent;

                                if (presetThemeIndex == 5)
                                    MAIN.presetCS.p5 = tempTheme.Accent;

                                if (presetThemeIndex == 6)
                                    MAIN.presetCS.p6 = tempTheme.Accent;

                                if (presetThemeIndex == 7)
                                    MAIN.presetCS.p7 = tempTheme.Accent;

                                if (presetThemeIndex == 8)
                                    MAIN.presetCS.p8 = tempTheme.Accent;

                                MAIN.cLogger.Log("Successfully read Preset Theme: " + Path.GetFileName(path));
                            }
                        }
                        catch (Exception ex)
                        {
                            Notif.Toast("Error", "There was an error :(");
                            MAIN.cLogger.Log(ex);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Notif.Toast("Error", "There was an error :(");
                MAIN.cLogger.Log(ex);
            }

        }

        public static void ReadCosmetics(string path)
        {
            try
            {
                if (!File.Exists(path))
                {
                    MAIN.cosmeticsCS = new CosmeticsTemplate()
                    {
                        cBlack = false,
                        cWhite = false,
                        cPink = false,
                        cBlue = false,
                        cYellow = false,
                        cRick = false,
                        mBlack = false,
                        mWhite = false,
                        mPink = false,
                        mBlue = false,
                        mYellow = false,
                        mRick = false,
                        aGlowing = false,
                        aSlide = false,
                        oWavy = false,
                        oKagune = false
                    };

                    WriteCosmetics(path);
                    return;
                }
                string temp = File.ReadAllText(path);
                MAIN.cosmeticsCS = JsonConvert.DeserializeObject<CosmeticsTemplate>(temp);
                MAIN.cLogger.Log("Successfully read: " + Path.GetFileName(path));
            }
            catch (Exception ex)
            {
                Notif.Toast("Error", "There was an error :(");
                MAIN.cLogger.Log(ex);
            }
        }

        public static async void WriteCosmetics(string path)
        {
            await Task.Run(() =>
            {
                try
                {
                    CosmeticsTemplate temp = MAIN.cosmeticsCS;

                    string json = JsonConvert.SerializeObject(temp, Formatting.Indented);
                    File.WriteAllText(path, json);
                    MAIN.cLogger.Log("Successfully wrote to: " + Path.GetFileName(path));
                }
                catch (Exception ex)
                {
                    Notif.Toast("Error", "There was an error  :(");
                    MAIN.cLogger.Log(ex);
                }
            });
        }
    }
}
