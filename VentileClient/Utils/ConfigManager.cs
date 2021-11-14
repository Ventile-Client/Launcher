using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;
using VentileClient.JSON_Template_Classes;

namespace VentileClient.Utils
{
    public static class ConfigManager
    {
        static MainWindow MAIN = MainWindow.INSTANCE;

        // Configs

        public static void ReadConfig(string path)
        {
            try
            {
                Directory.CreateDirectory(@"C:\temp\VentileClient\Presets");

                if (!File.Exists(path))
                {
                    MAIN.configCS = new ConfigTemplate();
                    WriteConfig(path);
                    return;
                }

                string temp = File.ReadAllText(path);
                MAIN.configCS = JsonConvert.DeserializeObject<ConfigTemplate>(temp);
                MAIN.cLogger.Log("Successfully read: " + Path.GetFileName(path));
            }
            catch (Exception ex)
            {
                Notif.Toast("Config Error", "There was an error reading the config!");
                MAIN.cLogger.Log(ex);
            }
        }

        public static async void WriteConfig(string path)
        {
            await Task.Run(() =>
            {
                try
                {
                    Directory.CreateDirectory(@"C:\temp\VentileClient\Presets");

                    if (MAIN.configCS == null)
                        MAIN.configCS = new ConfigTemplate();

                    string json = JsonConvert.SerializeObject(MAIN.configCS, Formatting.Indented);
                    File.WriteAllText(path, json);
                    MAIN.cLogger.Log("Successfully wrote to " + Path.GetFileName(path));
                }
                catch (Exception ex)
                {
                    Notif.Toast("Config Error", "There was an error writing to your config!");
                    MAIN.cLogger.Log(ex);
                }
            });
        }


        // Themes

        public static void ReadTheme(string path)
        {
            try
            {
                Directory.CreateDirectory(@"C:\temp\VentileClient\Presets");

                if (!File.Exists(path))
                {
                    MAIN.themeCS = new ThemeTemplate();
                    WriteTheme(path);
                    return;
                }

                string temp = File.ReadAllText(path);
                MAIN.themeCS = JsonConvert.DeserializeObject<ThemeTemplate>(temp);
                MAIN.cLogger.Log("Successfully read: " + Path.GetFileName(path));
            }
            catch (Exception ex)
            {
                Notif.Toast("Theme Error", "There was an error reading your theme!");
                MAIN.cLogger.Log(ex);
            }
        }

        public static async void WriteTheme(string path)
        {
            await Task.Run(() =>
            {
                try
                {
                    Directory.CreateDirectory(@"C:\temp\VentileClient\Presets");

                    if (MAIN.themeCS == null)
                        MAIN.themeCS = new ThemeTemplate();

                    string json = JsonConvert.SerializeObject(MAIN.themeCS, Formatting.Indented);
                    File.WriteAllText(path, json);
                    MAIN.cLogger.Log("Successfully wrote to: " + Path.GetFileName(path));
                }
                catch (Exception ex)
                {
                    Notif.Toast("Theme Error", "There was an error writing to your theme!");
                    MAIN.cLogger.Log(ex);
                }
            });
        }


        // Cosmetics
        public static void ReadCosmetics(string path)
        {
            try
            {
                Directory.CreateDirectory(@"C:\temp\VentileClient\Presets");

                if (!File.Exists(path))
                {
                    MAIN.cosmeticsCS = new CosmeticsTemplate();
                    WriteCosmetics(path);
                    return;
                }

                string temp = File.ReadAllText(path);
                MAIN.cosmeticsCS = JsonConvert.DeserializeObject<CosmeticsTemplate>(temp);
                MAIN.cLogger.Log("Successfully read: " + Path.GetFileName(path));
            }
            catch (Exception ex)
            {
                Notif.Toast("Cosmetics Error", "There was an error reading your cosmetics!");
                MAIN.cLogger.Log(ex);
            }
        }

        public static async void WriteCosmetics(string path)
        {
            await Task.Run(() =>
            {
                try
                {
                    Directory.CreateDirectory(@"C:\temp\VentileClient\Presets");

                    if (MAIN.cosmeticsCS == null)
                        MAIN.cosmeticsCS = new CosmeticsTemplate();

                    string json = JsonConvert.SerializeObject(MAIN.cosmeticsCS, Formatting.Indented);
                    File.WriteAllText(path, json);
                    MAIN.cLogger.Log("Successfully wrote to: " + Path.GetFileName(path));
                }
                catch (Exception ex)
                {
                    Notif.Toast("Cosmetics Error", "There was an error writing to your cosmetics!");
                    MAIN.cLogger.Log(ex);
                }
            });
        }

        // Preset Colors
        public static void GetPresetColors(string directory)
        {
            try
            {
                for (int i = 1; i <= 8; i++)
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
    }
}
