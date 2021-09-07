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
                    var temp = new ConfigTemplate()
                    {
                        WindowState = MAIN.configCS.WindowState,
                        AutoInject = MAIN.configCS.AutoInject,
                        RichPresence = MAIN.configCS.RichPresence,
                        RpcText = MAIN.configCS.RpcText,
                        RpcButton = MAIN.configCS.RpcButton,
                        RpcButtonLink = MAIN.configCS.RpcButtonLink,
                        RpcButtonText = MAIN.configCS.RpcButtonText,
                        CustomDLL = MAIN.configCS.CustomDLL,
                        DefaultDLL = MAIN.configCS.DefaultDLL,
                        InjectDelay = MAIN.configCS.InjectDelay,
                        Toasts = MAIN.configCS.Toasts,
                        ToastsLoc = MAIN.configCS.ToastsLoc,
                        RoundedButtons = MAIN.configCS.RoundedButtons,
                        PerformanceMode = MAIN.configCS.PerformanceMode,
                        BackgroundImageLoc = MAIN.configCS.BackgroundImageLoc,
                        BackgroundImage = MAIN.configCS.BackgroundImage
                    };

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
                    var temp = new ThemeTemplate()
                    {
                        Theme = MAIN.themeCS.Theme,
                        Background = MAIN.themeCS.Background,
                        SecondBackground = MAIN.themeCS.SecondBackground,
                        Foreground = MAIN.themeCS.Foreground,
                        Accent = MAIN.themeCS.Accent,
                        Outline = MAIN.themeCS.Outline,
                        Faded = MAIN.themeCS.Faded
                    };

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
                    var temp = new PresetColorsTemplate()
                    {
                        p1 = MAIN.presetCS.p1,
                        p2 = MAIN.presetCS.p2,
                        p3 = MAIN.presetCS.p3,
                        p4 = MAIN.presetCS.p4,
                        p5 = MAIN.presetCS.p5,
                        p6 = MAIN.presetCS.p6,
                        p7 = MAIN.presetCS.p7,
                        p8 = MAIN.presetCS.p8,
                    };

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
                    var temp = new CosmeticsTemplate()
                    {
                        cBlack = MAIN.cosmeticsCS.cBlack,
                        cWhite = MAIN.cosmeticsCS.cWhite,
                        cPink = MAIN.cosmeticsCS.cPink,
                        cBlue = MAIN.cosmeticsCS.cBlue,
                        cYellow = MAIN.cosmeticsCS.cYellow,
                        cRick = MAIN.cosmeticsCS.cRick,

                        mBlack = MAIN.cosmeticsCS.mBlack,
                        mWhite = MAIN.cosmeticsCS.mWhite,
                        mPink = MAIN.cosmeticsCS.mPink,
                        mBlue = MAIN.cosmeticsCS.mBlue,
                        mYellow = MAIN.cosmeticsCS.mYellow,
                        mRick = MAIN.cosmeticsCS.mRick,

                        aGlowing = MAIN.cosmeticsCS.aGlowing,
                        aSlide = MAIN.cosmeticsCS.aSlide,

                        oWavy = MAIN.cosmeticsCS.oWavy,
                        oKagune = MAIN.cosmeticsCS.oKagune,
                    };

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
