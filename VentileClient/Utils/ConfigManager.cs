using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
                    var temp = MAIN.configCS;

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
                    var temp = MAIN.themeCS;

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

        public static async void WritePresetColors(string path)
        {
            await Task.Run(() =>
            {
                try
                {
                    var temp = MAIN.presetCS;

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
                    var temp = MAIN.cosmeticsCS;

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
