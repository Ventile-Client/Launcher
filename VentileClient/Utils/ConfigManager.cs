using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
                string temp = File.ReadAllText(path);
                MAIN.configCS = JsonConvert.DeserializeObject<ConfigTemplate>(temp);
                MAIN.configLogger.Log("Successfully read: " + Path.GetFileName(path));
            }
            catch (Exception ex)
            {
                Notif.Toast("Error", "There was an error :(");
                MAIN.configLogger.Log(ex);
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
                    MAIN.configLogger.Log("Successfully wrote to " + Path.GetFileName(path));
                }
                catch (Exception ex)
                {
                    Notif.Toast("Error", "There was an error :(");
                    MAIN.configLogger.Log(ex);
                }
            });
        }

        public static void ReadTheme(string path)
        {
            try
            {
                string temp = File.ReadAllText(path);
                MAIN.themeCS = JsonConvert.DeserializeObject<ThemeTemplate>(temp);
                MAIN.configLogger.Log("Successfully read: " + Path.GetFileName(path));
            }
            catch (Exception ex)
            {
                Notif.Toast("Error", "There was an error :(");
                MAIN.configLogger.Log(ex);
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
                    MAIN.configLogger.Log("Successfully wrote to: " + Path.GetFileName(path));
                }
                catch (Exception ex)
                {
                    Notif.Toast("Error", "There was an error :(");
                    MAIN.configLogger.Log(ex);
                }
            });
        }

        public static void ReadPresetColors(string path)
        {
            try
            {
                string temp = File.ReadAllText(path);
                MAIN.presetCS = JsonConvert.DeserializeObject<PresetColorsTemplate>(temp);
                MAIN.configLogger.Log("Successfully read: " + Path.GetFileName(path));
            }
            catch (Exception ex)
            {
                Notif.Toast("Error", "There was an error :(");
                MAIN.configLogger.Log(ex);
            }
        }

        public static void GetPresetColors(string directory)
        {
            try
            {
                foreach (string a in Directory.GetFiles(directory, "*.json"))
                {
                    string fileName = Path.GetFileName(a).Split('.')[0].ToLower();
                    bool isPresetTheme = fileName.StartsWith("preset") && fileName.EndsWith("theme");
                    if (isPresetTheme)
                    {
                        int presetThemeIndex = int.Parse(fileName.Replace("preset", string.Empty).Replace("theme", string.Empty));
                        ThemeTemplate tempTheme;
                        try
                        {
                            string path = $@"C:\temp\VentileClient\Presets\preset{presetThemeIndex}Theme.json";
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

                            if (presetThemeIndex ==6)
                                MAIN.presetCS.p5 = tempTheme.Accent;

                            if (presetThemeIndex == 7)
                                MAIN.presetCS.p7 = tempTheme.Accent;

                            if (presetThemeIndex == 8)
                                MAIN.presetCS.p8 = tempTheme.Accent;

                            MAIN.configLogger.Log("Successfully read preset theme: " + Path.GetFileName(path));
                        }
                        catch (Exception ex)
                        {
                            Notif.Toast("Error", "There was an error :(");
                            MAIN.configLogger.Log(ex);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Notif.Toast("Error", "There was an error :(");
                MAIN.configLogger.Log(ex);
            }

        }

        public static async void WritePresetColors(string path)
        {
            await Task.Run(() =>
            {
                try
                {
                    PresetColorsTemplate temp = MAIN.presetCS;

                    string json = JsonConvert.SerializeObject(temp, Formatting.Indented);
                    File.WriteAllText(path, json);
                    MAIN.configLogger.Log("Successfully wrote to: " + Path.GetFileName(path));
                }
                catch (Exception ex)
                {
                    Notif.Toast("Error", "There was an error :(");
                    MAIN.configLogger.Log(ex);
                }
            });
        }

        public static void ReadCosmetics(string path)
        {
            try
            {
                string temp = File.ReadAllText(path);
                MAIN.cosmeticsCS = JsonConvert.DeserializeObject<CosmeticsTemplate>(temp);
                MAIN.configLogger.Log("Successfully read: " + Path.GetFileName(path));
            }
            catch (Exception ex)
            {
                Notif.Toast("Error", "There was an error :(");
                MAIN.configLogger.Log(ex);
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
                    MAIN.configLogger.Log("Successfully wrote to: " + Path.GetFileName(path));
                }
                catch (Exception ex)
                {
                    Notif.Toast("Error", "There was an error :(");
                    MAIN.configLogger.Log(ex);
                }
            });
        }
    }
}
