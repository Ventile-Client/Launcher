using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using VentileClient.JSON_Template_Classes;
using VentileClient.Utils;

namespace VentileClient.LauncherUtils
{
    public static class ColorManager
    {
        static MainWindow MAIN = MainWindow.INSTANCE;

        private static string ImageToBase64String(Image image, ImageFormat format)
        {
            var memory = new MemoryStream();
            image.Save(memory, format);
            string base64 = Convert.ToBase64String(memory.ToArray());
            memory.Close();
            return base64;
        }

        private static Image ImageFromBase64String(string base64)
        {
            var memory = new MemoryStream(Convert.FromBase64String(base64));
            var result = Image.FromStream(memory);
            memory.Close();
            return result;
        }

        public static void ChangeBackground()
        {
            if (MAIN.configCS.BackgroundImage)
            {
                try
                {
                    MAIN.homeTab.BackgroundImage = null;
                    MAIN.cosmeticsTab.BackgroundImage = null;
                    MAIN.versionsTab.BackgroundImage = null;
                    MAIN.settingsTab.BackgroundImage = null;
                    MAIN.aboutTab.BackgroundImage = null;

                    var imageFromString = ImageFromBase64String(MAIN.configCS.BackgroundImageLoc);

                    MAIN.homeTab.BackgroundImage = imageFromString;
                    MAIN.cosmeticsTab.BackgroundImage = imageFromString;
                    MAIN.settingsTab.BackgroundImage = imageFromString;
                    MAIN.aboutTab.BackgroundImage = imageFromString;

                    return;
                }
                catch (Exception ex)
                {
                    MAIN.dLogger.Log(ex);
                }
            }

            // Change background and logo
            if (MAIN.themeCS.Theme == ThemeTemplate.theme.Dark)
            {
                MAIN.logo.Image = VentileClient.Properties.Resources.transparent_logo_white;
                MAIN.homeTab.BackgroundImage = VentileClient.Properties.Resources.background;
                MAIN.cosmeticsTab.BackgroundImage = VentileClient.Properties.Resources.background;
                MAIN.settingsTab.BackgroundImage = VentileClient.Properties.Resources.background;
                MAIN.aboutTab.BackgroundImage = VentileClient.Properties.Resources.background;
            }
            else
            {
                MAIN.logo.Image = VentileClient.Properties.Resources.transparent_logo_black;
                MAIN.homeTab.BackgroundImage = VentileClient.Properties.Resources.background2;
                MAIN.cosmeticsTab.BackgroundImage = VentileClient.Properties.Resources.background2;
                MAIN.settingsTab.BackgroundImage = VentileClient.Properties.Resources.background2;
                MAIN.aboutTab.BackgroundImage = VentileClient.Properties.Resources.background2;
            }
        }

        public static void SetBackgroundString()
        {
            string text = ImageToBase64String(MAIN.homeTab.BackgroundImage, MAIN.homeTab.BackgroundImage.RawFormat);
            MAIN.configCS.BackgroundImageLoc = text;
        }

        public static void Global()
        {
            // Make the color variable smaller
            Color backColor = ColorTranslator.FromHtml(MAIN.themeCS.Background);
            Color accentColor = ColorTranslator.FromHtml(MAIN.themeCS.Accent);
            Color foreColor = ColorTranslator.FromHtml(MAIN.themeCS.Foreground);
            Color outlineColor = ColorTranslator.FromHtml(MAIN.themeCS.Outline);
            Color fadedColor = ColorTranslator.FromHtml(MAIN.themeCS.Faded);
            Color backColor2 = ColorTranslator.FromHtml(MAIN.themeCS.SecondBackground);

            //Sidebar
            MAIN.sidebar.BackColor = backColor;
            MAIN.dragBar.BackColor = backColor;
            MAIN.version.BackColor = backColor;
            MAIN.version.ForeColor = fadedColor;
            MAIN.launcherTitle.ForeColor = foreColor;
            MAIN.launcherTitle.BackColor = backColor;
            MAIN.line.ForeColor = foreColor;
            MAIN.line.BackColor = backColor;


            MAIN.settingsTab.BackColor = backColor;

            MAIN.TrayIconContextMenu.ForeColor = foreColor;
            MAIN.TrayIconContextMenu.BackColor = backColor2;
            MAIN.TrayIconContextMenu.RenderStyle.SelectionBackColor = accentColor;
            MAIN.TrayIconContextMenu.RenderStyle.SelectionForeColor = foreColor;
            MAIN.TrayIconContextMenu.RenderStyle.BorderColor = outlineColor;

            MAIN.DefaultDLLSelector.ForeColor = foreColor;
            MAIN.DefaultDLLSelector.BackColor = backColor2;
            MAIN.DefaultDLLSelector.RenderStyle.SelectionBackColor = accentColor;
            MAIN.DefaultDLLSelector.RenderStyle.SelectionForeColor = foreColor;
            MAIN.DefaultDLLSelector.RenderStyle.BorderColor = outlineColor;

            MAIN.closeButton.ForeColor = fadedColor;
            MAIN.minimizeButton.ForeColor = fadedColor;

            //Home Button
            MAIN.homeButton.ForeColor = foreColor;
            if (backColor.R + 15 <= 255)
                MAIN.homeButton.CheckedState.FillColor = Color.FromArgb(130, backColor.R + 15, backColor.G + 15, backColor.B + 15);
            else
                MAIN.homeButton.CheckedState.FillColor = Color.FromArgb(130, backColor.R - 15, backColor.G - 15, backColor.B - 15);

            if (backColor.R - 15 > 0)
                MAIN.homeButton.HoverState.FillColor = Color.FromArgb(130, backColor.R - 15, backColor.G - 15, backColor.B - 15);
            else
                MAIN.homeButton.HoverState.FillColor = Color.FromArgb(130, backColor.R + 15, backColor.G + 15, backColor.B + 15);

            MAIN.homeButtonIcon.IconColor = accentColor;

            //Cosmetics Button
            MAIN.cosmeticsButton.ForeColor = foreColor;
            if (backColor.R + 15 <= 255)
                MAIN.cosmeticsButton.CheckedState.FillColor = Color.FromArgb(130, backColor.R + 15, backColor.G + 15, backColor.B + 15);
            else
                MAIN.cosmeticsButton.CheckedState.FillColor = Color.FromArgb(130, backColor.R - 15, backColor.G - 15, backColor.B - 15);

            if (backColor.R - 15 > 0)
                MAIN.cosmeticsButton.HoverState.FillColor = Color.FromArgb(130, backColor.R - 15, backColor.G - 15, backColor.B - 15);
            else
                MAIN.cosmeticsButton.HoverState.FillColor = Color.FromArgb(130, backColor.R + 15, backColor.G + 15, backColor.B + 15);

            MAIN.cosmeticsButtonIcon.IconColor = accentColor;

            //Version Button
            MAIN.versionButton.ForeColor = foreColor;
            if (backColor.R + 15 <= 255)
                MAIN.versionButton.CheckedState.FillColor = Color.FromArgb(130, backColor.R + 15, backColor.G + 15, backColor.B + 15);
            else
                MAIN.versionButton.CheckedState.FillColor = Color.FromArgb(130, backColor.R - 15, backColor.G - 15, backColor.B - 15);

            if (backColor.R - 15 > 0)
                MAIN.versionButton.HoverState.FillColor = Color.FromArgb(130, backColor.R - 15, backColor.G - 15, backColor.B - 15);
            else
                MAIN.versionButton.HoverState.FillColor = Color.FromArgb(130, backColor.R + 15, backColor.G + 15, backColor.B + 15);

            MAIN.versionButtonIcon.IconColor = accentColor;

            //Settings Button
            MAIN.settingsButton.ForeColor = foreColor;
            if (backColor.R + 15 <= 255)
                MAIN.settingsButton.CheckedState.FillColor = Color.FromArgb(130, backColor.R + 15, backColor.G + 15, backColor.B + 15);
            else
                MAIN.settingsButton.CheckedState.FillColor = Color.FromArgb(130, backColor.R - 15, backColor.G - 15, backColor.B - 15);

            if (backColor.R - 15 > 0)
                MAIN.settingsButton.HoverState.FillColor = Color.FromArgb(130, backColor.R - 15, backColor.G - 15, backColor.B - 15);
            else
                MAIN.settingsButton.HoverState.FillColor = Color.FromArgb(130, backColor.R + 15, backColor.G + 15, backColor.B + 15);

            MAIN.settingsButtonIcon.IconColor = accentColor;

            //About Button
            MAIN.aboutButton.ForeColor = foreColor;
            if (backColor.R + 15 <= 255)
                MAIN.aboutButton.CheckedState.FillColor = Color.FromArgb(130, backColor.R + 15, backColor.G + 15, backColor.B + 15);
            else
                MAIN.aboutButton.CheckedState.FillColor = Color.FromArgb(130, backColor.R - 15, backColor.G - 15, backColor.B - 15);

            if (backColor.R - 15 > 0)
                MAIN.aboutButton.HoverState.FillColor = Color.FromArgb(130, backColor.R - 15, backColor.G - 15, backColor.B - 15);
            else
                MAIN.aboutButton.HoverState.FillColor = Color.FromArgb(130, backColor.R + 15, backColor.G + 15, backColor.B + 15);

            MAIN.aboutButtonIcon.IconColor = accentColor;

            if (MAIN.configCS.PerformanceMode)
            {
                MAIN.homeButton.Animated = false;
                MAIN.cosmeticsButton.Animated = false;
                MAIN.versionButton.Animated = false;
                MAIN.settingsButton.Animated = false;
                MAIN.aboutButton.Animated = false;
                MAIN.closeButton.Animated = false;
                MAIN.minimizeButton.Animated = false;
            }
            else
            {
                MAIN.homeButton.Animated = true;
                MAIN.cosmeticsButton.Animated = true;
                MAIN.versionButton.Animated = true;
                MAIN.settingsButton.Animated = true;
                MAIN.aboutButton.Animated = true;
                MAIN.closeButton.Animated = true;
                MAIN.minimizeButton.Animated = true;
            }

            MAIN.Refresh();
        }

        public static void Home()
        {
            // Make the color variable smaller
            Color backColor = ColorTranslator.FromHtml(MAIN.themeCS.Background);
            Color backColor2 = ColorTranslator.FromHtml(MAIN.themeCS.SecondBackground);
            Color foreColor = ColorTranslator.FromHtml(MAIN.themeCS.Foreground);
            Color outlineColor = ColorTranslator.FromHtml(MAIN.themeCS.Outline);

            MAIN.launchMc.FillColor = backColor;
            MAIN.selectDll.FillColor = backColor;
            MAIN.inject.FillColor = backColor;

            MAIN.launchMc.ForeColor = foreColor;
            MAIN.selectDll.ForeColor = foreColor;
            MAIN.inject.ForeColor = foreColor;

            MAIN.launchMc.CustomBorderColor = outlineColor;
            MAIN.selectDll.CustomBorderColor = outlineColor;
            MAIN.inject.CustomBorderColor = outlineColor;

            MAIN.SelectDLLTooltip.BackColor = backColor2;
            MAIN.SelectDLLTooltip.BorderColor = outlineColor;
            MAIN.SelectDLLTooltip.ForeColor = foreColor;

            if (MAIN.configCS.PerformanceMode)
            {
                MAIN.SelectDLLTooltip.UseAnimation = false;
                MAIN.SelectDLLTooltip.UseFading = false;
            }
            else
            {
                MAIN.SelectDLLTooltip.UseAnimation = true;
                MAIN.SelectDLLTooltip.UseFading = true;
            }

            MAIN.homeTab.BackColor = backColor;


            MAIN.Refresh();
        }

        public static void Cosmetics()
        {
            // Make the color variable smaller
            Color backColor = ColorTranslator.FromHtml(MAIN.themeCS.Background);
            Color accentColor = ColorTranslator.FromHtml(MAIN.themeCS.Accent);
            Color foreColor = ColorTranslator.FromHtml(MAIN.themeCS.Foreground);
            Color backColor2 = ColorTranslator.FromHtml(MAIN.themeCS.SecondBackground);

            //Background
            MAIN.cosmeticsBackground.BackColor = backColor;

            //Titles
            MAIN.capesTitle.ForeColor = foreColor;
            MAIN.capesTitle.BackColor = backColor;

            MAIN.masksTitle.ForeColor = foreColor;
            MAIN.masksTitle.BackColor = backColor;

            MAIN.animatedCapesTitle.ForeColor = foreColor;
            MAIN.animatedCapesTitle.BackColor = backColor;

            MAIN.othersTitle.ForeColor = foreColor;
            MAIN.othersTitle.BackColor = backColor;

            //Buttons
            //Capes
            MAIN.cBlack.BackColor = backColor;
            MAIN.cBlack.FillColor = backColor2;
            MAIN.cBlack.CheckedState.FillColor = accentColor;
            MAIN.cBlack.ForeColor = foreColor;

            MAIN.cWhite.BackColor = backColor;
            MAIN.cWhite.FillColor = backColor2;
            MAIN.cWhite.CheckedState.FillColor = accentColor;
            MAIN.cWhite.ForeColor = foreColor;

            MAIN.cPink.BackColor = backColor;
            MAIN.cPink.FillColor = backColor2;
            MAIN.cPink.CheckedState.FillColor = accentColor;
            MAIN.cPink.ForeColor = foreColor;

            MAIN.cBlue.BackColor = backColor;
            MAIN.cBlue.FillColor = backColor2;
            MAIN.cBlue.CheckedState.FillColor = accentColor;
            MAIN.cBlue.ForeColor = foreColor;

            MAIN.cYellow.BackColor = backColor;
            MAIN.cYellow.FillColor = backColor2;
            MAIN.cYellow.CheckedState.FillColor = accentColor;
            MAIN.cYellow.ForeColor = foreColor;

            MAIN.cRick.BackColor = backColor;
            MAIN.cRick.FillColor = backColor2;
            MAIN.cRick.CheckedState.FillColor = accentColor;
            MAIN.cRick.ForeColor = foreColor;

            //Masks
            MAIN.mBlack.BackColor = backColor;
            MAIN.mBlack.FillColor = backColor2;
            MAIN.mBlack.CheckedState.FillColor = accentColor;
            MAIN.mBlack.ForeColor = foreColor;

            MAIN.mWhite.BackColor = backColor;
            MAIN.mWhite.FillColor = backColor2;
            MAIN.mWhite.CheckedState.FillColor = accentColor;
            MAIN.mWhite.ForeColor = foreColor;

            MAIN.mPink.BackColor = backColor;
            MAIN.mPink.FillColor = backColor2;
            MAIN.mPink.CheckedState.FillColor = accentColor;
            MAIN.mPink.ForeColor = foreColor;

            MAIN.mBlue.BackColor = backColor;
            MAIN.mBlue.FillColor = backColor2;
            MAIN.mBlue.CheckedState.FillColor = accentColor;
            MAIN.mBlue.ForeColor = foreColor;

            MAIN.mYellow.BackColor = backColor;
            MAIN.mYellow.FillColor = backColor2;
            MAIN.mYellow.CheckedState.FillColor = accentColor;
            MAIN.mYellow.ForeColor = foreColor;

            MAIN.mRick.BackColor = backColor;
            MAIN.mRick.FillColor = backColor2;
            MAIN.mRick.CheckedState.FillColor = accentColor;
            MAIN.mRick.ForeColor = foreColor;

            //Animated Capes
            MAIN.aGlowing.BackColor = backColor;
            MAIN.aGlowing.FillColor = backColor2;
            MAIN.aGlowing.CheckedState.FillColor = accentColor;
            MAIN.aGlowing.ForeColor = foreColor;

            MAIN.aSlide.BackColor = backColor;
            MAIN.aSlide.FillColor = backColor2;
            MAIN.aSlide.CheckedState.FillColor = accentColor;
            MAIN.aSlide.ForeColor = foreColor;

            //Other
            MAIN.oWavy.BackColor = backColor;
            MAIN.oWavy.FillColor = backColor2;
            MAIN.oWavy.CheckedState.FillColor = accentColor;
            MAIN.oWavy.ForeColor = foreColor;

            MAIN.oKagune.BackColor = backColor;
            MAIN.oKagune.FillColor = backColor2;
            MAIN.oKagune.CheckedState.FillColor = accentColor;
            MAIN.oKagune.ForeColor = foreColor;

            MAIN.resetAllCosmetics.BackColor = backColor;
            MAIN.resetAllCosmetics.FillColor = backColor2;
            MAIN.resetAllCosmetics.CheckedState.FillColor = accentColor;
            MAIN.resetAllCosmetics.ForeColor = foreColor;

            //Rounded Buttons
            if (MAIN.configCS.RoundedButtons)
            {
                MAIN.resetAllCosmetics.AutoRoundedCorners = true;
                MAIN.cBlack.AutoRoundedCorners = true;
                MAIN.cWhite.AutoRoundedCorners = true;
                MAIN.cPink.AutoRoundedCorners = true;
                MAIN.cBlue.AutoRoundedCorners = true;
                MAIN.cYellow.AutoRoundedCorners = true;
                MAIN.cRick.AutoRoundedCorners = true;

                MAIN.mBlack.AutoRoundedCorners = true;
                MAIN.mWhite.AutoRoundedCorners = true;
                MAIN.mPink.AutoRoundedCorners = true;
                MAIN.mBlue.AutoRoundedCorners = true;
                MAIN.mYellow.AutoRoundedCorners = true;
                MAIN.mRick.AutoRoundedCorners = true;
                MAIN.aGlowing.AutoRoundedCorners = true;
                MAIN.aSlide.AutoRoundedCorners = true;
                MAIN.oWavy.AutoRoundedCorners = true;
                MAIN.oKagune.AutoRoundedCorners = true;
            }
            else
            {
                MAIN.resetAllCosmetics.AutoRoundedCorners = false;
                MAIN.cBlack.AutoRoundedCorners = false;
                MAIN.cWhite.AutoRoundedCorners = false;
                MAIN.cPink.AutoRoundedCorners = false;
                MAIN.cBlue.AutoRoundedCorners = false;
                MAIN.cYellow.AutoRoundedCorners = false;
                MAIN.cRick.AutoRoundedCorners = false;
                MAIN.mBlack.AutoRoundedCorners = false;
                MAIN.mWhite.AutoRoundedCorners = false;
                MAIN.mPink.AutoRoundedCorners = false;
                MAIN.mBlue.AutoRoundedCorners = false;
                MAIN.mYellow.AutoRoundedCorners = false;
                MAIN.mRick.AutoRoundedCorners = false;
                MAIN.aGlowing.AutoRoundedCorners = false;
                MAIN.aSlide.AutoRoundedCorners = false;
                MAIN.oWavy.AutoRoundedCorners = false;
                MAIN.oKagune.AutoRoundedCorners = false;
            }

            //Performance Mode
            if (MAIN.configCS.PerformanceMode)
            {
                MAIN.resetAllCosmetics.Animated = false;
                MAIN.cBlack.Animated = false;
                MAIN.cWhite.Animated = false;
                MAIN.cPink.Animated = false;
                MAIN.cBlue.Animated = false;
                MAIN.cYellow.Animated = false;
                MAIN.cRick.Animated = false;
                MAIN.mBlack.Animated = false;
                MAIN.mWhite.Animated = false;
                MAIN.mPink.Animated = false;
                MAIN.mBlue.Animated = false;
                MAIN.mYellow.Animated = false;
                MAIN.mRick.Animated = false;
                MAIN.aGlowing.Animated = false;
                MAIN.aSlide.Animated = false;
                MAIN.oWavy.Animated = false;
                MAIN.oKagune.Animated = false;
            }
            else
            {
                MAIN.resetAllCosmetics.Animated = true;
                MAIN.cBlack.Animated = true;
                MAIN.cWhite.Animated = true;
                MAIN.cPink.Animated = true;
                MAIN.cBlue.Animated = true;
                MAIN.cYellow.Animated = true;
                MAIN.cRick.Animated = true;
                MAIN.mBlack.Animated = true;
                MAIN.mWhite.Animated = true;
                MAIN.mPink.Animated = true;
                MAIN.mBlue.Animated = true;
                MAIN.mYellow.Animated = true;
                MAIN.mRick.Animated = true;
                MAIN.aGlowing.Animated = true;
                MAIN.aSlide.Animated = true;
                MAIN.oWavy.Animated = true;
                MAIN.oKagune.Animated = true;
            }

            MAIN.settingsTab.BackColor = backColor;

            MAIN.Refresh();
        }

        public static void Version()
        {
            // Make the color variable smaller
            Color backColor = ColorTranslator.FromHtml(MAIN.themeCS.Background);
            Color accentColor = ColorTranslator.FromHtml(MAIN.themeCS.Accent);
            Color foreColor = ColorTranslator.FromHtml(MAIN.themeCS.Foreground);
            Color backColor2 = ColorTranslator.FromHtml(MAIN.themeCS.SecondBackground);

            List<Control> buttons = ControlManager.GetControlByType(typeof(Guna2Button), MAIN.versionsPanel);
            List<Control> progressBars = ControlManager.GetControlByType(typeof(Guna2ProgressBar), MAIN.versionsPanel);
            List<Control> labels = ControlManager.GetControlByType(typeof(Label), MAIN.versionsPanel);

            MAIN.versionsPanel.BackColor = backColor;


            bool perf = MAIN.configCS.PerformanceMode;

            foreach (Control b in buttons)
            {
                var button = b as Guna2Button;
                button.ForeColor = foreColor;
                button.FillColor = backColor2;
                button.CheckedState.FillColor = accentColor;
                button.Animated = !perf;
            }

            foreach (Control p in progressBars)
            {
                var progressBar = p as Guna2ProgressBar;
                progressBar.ForeColor = foreColor;
                progressBar.FillColor = backColor2;
                progressBar.ProgressColor = accentColor;
                int r = 0;
                int g = 0;
                int b = 0;

                if (accentColor.R - MAIN.progressBarGradientOffset > 0)
                    r = accentColor.R - MAIN.progressBarGradientOffset;
                else if (accentColor.R + MAIN.progressBarGradientOffset <= 255)
                    r = accentColor.R + MAIN.progressBarGradientOffset;

                if (accentColor.G - MAIN.progressBarGradientOffset > 0)
                    g = accentColor.G - MAIN.progressBarGradientOffset;
                else if (accentColor.G + MAIN.progressBarGradientOffset <= 255)
                    g = accentColor.G + MAIN.progressBarGradientOffset;

                if (accentColor.B - MAIN.progressBarGradientOffset > 0)
                    b = accentColor.B - MAIN.progressBarGradientOffset;
                else if (accentColor.B + MAIN.progressBarGradientOffset <= 255)
                    b = accentColor.B + MAIN.progressBarGradientOffset;

                progressBar.ProgressColor2 = Color.FromArgb(r, g, b);
            }

            foreach (Control label in labels)
            {
                label.ForeColor = foreColor;
                label.BackColor = backColor;
            }

            MAIN.versionsTab.BackColor = backColor;

            MAIN.Refresh();
        }

        public static void Settings()
        {
            // Make the color variable smaller
            Color backColor = ColorTranslator.FromHtml(MAIN.themeCS.Background);
            Color accentColor = ColorTranslator.FromHtml(MAIN.themeCS.Accent);
            Color foreColor = ColorTranslator.FromHtml(MAIN.themeCS.Foreground);
            Color outlineColor = ColorTranslator.FromHtml(MAIN.themeCS.Outline);
            Color backColor2 = ColorTranslator.FromHtml(MAIN.themeCS.SecondBackground);
            Color fadedColor = ColorTranslator.FromHtml(MAIN.themeCS.Faded);

            MAIN.Launcher.BackColor = backColor;
            MAIN.Appearance.BackColor = backColor;
            MAIN.Extras.BackColor = backColor;
            MAIN.PackProfiles.BackColor = backColor;

            // Launcher \\
            MAIN.windowStateLabel.BackColor = backColor;
            MAIN.richPresenceLabel.BackColor = backColor;
            MAIN.devDLLLabel.BackColor = backColor;
            MAIN.injectDelayLabel.BackColor = backColor;
            MAIN.autoLabel.BackColor = backColor;
            MAIN.personaLabel.BackColor = backColor;

            MAIN.windowStateLabel.ForeColor = foreColor;
            MAIN.richPresenceLabel.ForeColor = foreColor;
            MAIN.devDLLLabel.ForeColor = foreColor;
            MAIN.injectDelayLabel.ForeColor = foreColor;
            MAIN.autoLabel.ForeColor = foreColor;
            MAIN.personaLabel.ForeColor = foreColor;

            //WindowState

            MAIN.hideWindow.CheckedState.FillColor = accentColor;
            MAIN.hideWindow.ForeColor = foreColor;
            MAIN.hideWindow.FillColor = backColor2;

            MAIN.minWindow.CheckedState.FillColor = accentColor;
            MAIN.minWindow.ForeColor = foreColor;
            MAIN.minWindow.FillColor = backColor2;

            MAIN.closeWindow.CheckedState.FillColor = accentColor;
            MAIN.closeWindow.ForeColor = foreColor;
            MAIN.closeWindow.FillColor = backColor2;

            MAIN.openWindow.CheckedState.FillColor = accentColor;
            MAIN.openWindow.ForeColor = foreColor;
            MAIN.openWindow.FillColor = backColor2;

            //AutoInject
            MAIN.autoInject.CheckedState.FillColor = accentColor;
            MAIN.autoInject.ForeColor = foreColor;
            MAIN.autoInject.FillColor = backColor2;

            //RPC
            MAIN.RpcToggle.CheckedState.FillColor = accentColor;
            MAIN.RpcToggle.ForeColor = foreColor;
            MAIN.RpcToggle.FillColor = backColor2;

            MAIN.buttonForRpc.CheckedState.FillColor = accentColor;
            MAIN.buttonForRpc.ForeColor = foreColor;
            MAIN.buttonForRpc.FillColor = backColor2;

            MAIN.profileNameTextbox.BorderColor = outlineColor;
            MAIN.profileNameTextbox.PlaceholderForeColor = Color.FromArgb(((foreColor.R + 55 <= 255) ? foreColor.R + 55 : foreColor.R - 55), ((foreColor.G + 55 <= 255) ? foreColor.G + 55 : foreColor.G - 55), ((foreColor.B + 55 <= 255) ? foreColor.B + 55 : foreColor.B - 55));
            MAIN.profileNameTextbox.ForeColor = foreColor;
            MAIN.profileNameTextbox.FillColor = backColor2;

            MAIN.RPCTextbox.BorderColor = outlineColor;
            MAIN.RPCTextbox.PlaceholderForeColor = Color.FromArgb(((foreColor.R + 55 <= 255) ? foreColor.R + 55 : foreColor.R - 55), ((foreColor.G + 55 <= 255) ? foreColor.G + 55 : foreColor.G - 55), ((foreColor.B + 55 <= 255) ? foreColor.B + 55 : foreColor.B - 55)); ;
            MAIN.RPCTextbox.ForeColor = foreColor;
            MAIN.RPCTextbox.FillColor = backColor2; /*Color.FromArgb(((backColor.R + 40 <= 255) ? backColor.R + 40 : backColor.R - 40), ((backColor.G + 40 <= 255) ? backColor.G + 40 : backColor.G - 40), ((backColor.B + 40 <= 255) ? backColor.B + 40 : backColor.B - 40));*/

            MAIN.RPCButtonTextbox.BorderColor = outlineColor;
            MAIN.RPCButtonTextbox.PlaceholderForeColor = Color.FromArgb(((foreColor.R + 55 <= 255) ? foreColor.R + 55 : foreColor.R - 55), ((foreColor.G + 55 <= 255) ? foreColor.G + 55 : foreColor.G - 55), ((foreColor.B + 55 <= 255) ? foreColor.B + 55 : foreColor.B - 55)); ;
            MAIN.RPCButtonTextbox.ForeColor = foreColor;
            MAIN.RPCButtonTextbox.FillColor = backColor2; /*Color.FromArgb(((backColor.R + 40 <= 255) ? backColor.R + 40 : backColor.R - 40), ((backColor.G + 40 <= 255) ? backColor.G + 40 : backColor.G - 40), ((backColor.B + 40 <= 255) ? backColor.B + 40 : backColor.B - 40));*/

            MAIN.RPCButtonLinkTextbox.BorderColor = outlineColor;
            MAIN.RPCButtonLinkTextbox.PlaceholderForeColor = Color.FromArgb(((foreColor.R + 55 <= 255) ? foreColor.R + 55 : foreColor.R - 55), ((foreColor.G + 55 <= 255) ? foreColor.G + 55 : foreColor.G - 55), ((foreColor.B + 55 <= 255) ? foreColor.B + 55 : foreColor.B - 55)); ;
            MAIN.RPCButtonLinkTextbox.ForeColor = foreColor;
            MAIN.RPCButtonLinkTextbox.FillColor = backColor2; /*Color.FromArgb(((backColor.R + 40 <= 255) ? backColor.R + 40 : backColor.R - 40), ((backColor.G + 40 <= 255) ? backColor.G + 40 : backColor.G - 40), ((backColor.B + 40 <= 255) ? backColor.B + 40 : backColor.B - 40));*/


            //DEV DLL
            MAIN.customDLLButton.CheckedState.FillColor = accentColor;
            MAIN.customDLLButton.ForeColor = foreColor;
            MAIN.customDLLButton.FillColor = backColor2;

            //Inject Delay
            MAIN.injectDelay.ForeColor = foreColor;
            MAIN.injectDelay.UpDownButtonFillColor = accentColor;
            MAIN.injectDelay.FillColor = backColor2;


            //Blank Setting
            MAIN.personaLoc.CheckedState.FillColor = accentColor;
            MAIN.personaLoc.ForeColor = foreColor;
            MAIN.personaLoc.FillColor = backColor2;

            MAIN.AppearanceButton.ForeColor = foreColor;
            MAIN.AppearanceButton.FillColor = backColor2;

            // Appearance \\

            //Sliders
            MAIN.backgroundBrightnessSlider.BackColor = backColor;
            MAIN.accentRedSlider.BackColor = backColor;
            MAIN.accentGreenSlider.BackColor = backColor;
            MAIN.accentBlueSlider.BackColor = backColor;
            MAIN.outlineBrightnessSlider.BackColor = backColor;
            MAIN.buttonBrightnessSlider.BackColor = backColor;
            MAIN.textBrightnessSlider.BackColor = backColor;

            MAIN.backgroundBrightnessSlider.ThumbColor = accentColor;
            MAIN.accentRedSlider.ThumbColor = accentColor;
            MAIN.accentGreenSlider.ThumbColor = accentColor;
            MAIN.accentBlueSlider.ThumbColor = accentColor;
            MAIN.outlineBrightnessSlider.ThumbColor = accentColor;
            MAIN.buttonBrightnessSlider.ThumbColor = accentColor;
            MAIN.textBrightnessSlider.ThumbColor = accentColor;

            //Labels
            MAIN.backgroundColorLabel.BackColor = backColor;
            MAIN.accentColorLabel.BackColor = backColor;
            MAIN.outlineColorLabel.BackColor = backColor;
            MAIN.buttonColorLabel.BackColor = backColor;
            MAIN.foreColorLabel.BackColor = backColor;
            MAIN.presetsLabel.BackColor = backColor;
            MAIN.themeTitle.BackColor = backColor;

            MAIN.backgroundColorLabel.ForeColor = foreColor;
            MAIN.accentColorLabel.ForeColor = foreColor;
            MAIN.outlineColorLabel.ForeColor = foreColor;
            MAIN.buttonColorLabel.ForeColor = foreColor;
            MAIN.foreColorLabel.ForeColor = foreColor;
            MAIN.presetsLabel.ForeColor = foreColor;
            MAIN.themeTitle.ForeColor = foreColor;

            //Buttons
            MAIN.theme.FillColor = backColor2;
            MAIN.theme.ForeColor = foreColor;

            MAIN.resetThemes.FillColor = backColor2;
            MAIN.resetThemes.ForeColor = foreColor;

            MAIN.LauncherButton.FillColor = backColor2;
            MAIN.LauncherButton.ForeColor = foreColor;

            MAIN.ExtrasButton.FillColor = backColor2;
            MAIN.ExtrasButton.ForeColor = foreColor;

            //Slider Labels
            MAIN.labelForSlider1.BackColor = backColor;
            MAIN.labelForSlider2.BackColor = backColor;
            MAIN.labelForSlider3.BackColor = backColor;
            MAIN.labelForSlider4.BackColor = backColor;
            MAIN.labelForSlider5.BackColor = backColor;

            MAIN.labelForSlider1.ForeColor = foreColor;
            MAIN.labelForSlider2.ForeColor = foreColor;
            MAIN.labelForSlider3.ForeColor = foreColor;
            MAIN.labelForSlider4.ForeColor = foreColor;
            MAIN.labelForSlider5.ForeColor = foreColor;

            MAIN.backgroundBT.BackColor = backColor;
            MAIN.accentRT.BackColor = backColor;
            MAIN.accentGT.BackColor = backColor;
            MAIN.accentBT.BackColor = backColor;
            MAIN.outlineOT.BackColor = backColor;
            MAIN.buttonBuT.BackColor = backColor;
            MAIN.foreBT.BackColor = backColor;

            MAIN.backgroundBT.ForeColor = foreColor;
            MAIN.accentRT.ForeColor = foreColor;
            MAIN.accentGT.ForeColor = foreColor;
            MAIN.accentBT.ForeColor = foreColor;
            MAIN.outlineOT.ForeColor = foreColor;
            MAIN.buttonBuT.ForeColor = foreColor;
            MAIN.foreBT.ForeColor = foreColor;

            //Tab Labels
            MAIN.settingsTabLabel.ForeColor = foreColor;
            MAIN.cosmeticsTabLabel.ForeColor = foreColor;
            MAIN.aboutTabLabel.ForeColor = foreColor;

            //Rounded
            MAIN.hideWindow.AutoRoundedCorners = MAIN.configCS.RoundedButtons;
            MAIN.minWindow.AutoRoundedCorners = MAIN.configCS.RoundedButtons;
            MAIN.closeWindow.AutoRoundedCorners = MAIN.configCS.RoundedButtons;
            MAIN.openWindow.AutoRoundedCorners = MAIN.configCS.RoundedButtons;
            MAIN.buttonForRpc.AutoRoundedCorners = MAIN.configCS.RoundedButtons;
            MAIN.customImage.AutoRoundedCorners = MAIN.configCS.RoundedButtons;
            MAIN.autoInject.AutoRoundedCorners = MAIN.configCS.RoundedButtons;
            MAIN.RpcToggle.AutoRoundedCorners = MAIN.configCS.RoundedButtons;
            MAIN.theme.AutoRoundedCorners = MAIN.configCS.RoundedButtons;
            MAIN.AppearanceButton.AutoRoundedCorners = MAIN.configCS.RoundedButtons;
            MAIN.LauncherButton.AutoRoundedCorners = MAIN.configCS.RoundedButtons;
            MAIN.ExtrasButton.AutoRoundedCorners = MAIN.configCS.RoundedButtons;
            MAIN.AppearanceButton2.AutoRoundedCorners = MAIN.configCS.RoundedButtons;
            MAIN.resetThemes.AutoRoundedCorners = MAIN.configCS.RoundedButtons;
            MAIN.customDLLButton.AutoRoundedCorners = MAIN.configCS.RoundedButtons;
            MAIN.injectDelay.AutoRoundedCorners = MAIN.configCS.RoundedButtons;
            MAIN.personaLoc.AutoRoundedCorners = MAIN.configCS.RoundedButtons;
            MAIN.roundedToggle.AutoRoundedCorners = MAIN.configCS.RoundedButtons;
            MAIN.toastsToggle.AutoRoundedCorners = MAIN.configCS.RoundedButtons;
            MAIN.toastsSelector.AutoRoundedCorners = MAIN.configCS.RoundedButtons;
            MAIN.performanceModeToggle.AutoRoundedCorners = MAIN.configCS.RoundedButtons;
            MAIN.packProfileButtonOpen.AutoRoundedCorners = MAIN.configCS.RoundedButtons;
            MAIN.exitPackProfilesButton.AutoRoundedCorners = MAIN.configCS.RoundedButtons;

            //Performance Mode
            MAIN.hideWindow.Animated = !MAIN.configCS.PerformanceMode;
            MAIN.minWindow.Animated = !MAIN.configCS.PerformanceMode;
            MAIN.closeWindow.Animated = !MAIN.configCS.PerformanceMode;
            MAIN.openWindow.Animated = !MAIN.configCS.PerformanceMode;
            MAIN.buttonForRpc.Animated = !MAIN.configCS.PerformanceMode;
            MAIN.customImage.Animated = !MAIN.configCS.PerformanceMode;
            MAIN.autoInject.Animated = !MAIN.configCS.PerformanceMode;
            MAIN.RpcToggle.Animated = !MAIN.configCS.PerformanceMode;
            MAIN.theme.Animated = !MAIN.configCS.PerformanceMode;
            MAIN.AppearanceButton.Animated = !MAIN.configCS.PerformanceMode;
            MAIN.LauncherButton.Animated = !MAIN.configCS.PerformanceMode;
            MAIN.ExtrasButton.Animated = !MAIN.configCS.PerformanceMode;
            MAIN.AppearanceButton2.Animated = !MAIN.configCS.PerformanceMode;
            MAIN.resetThemes.Animated = !MAIN.configCS.PerformanceMode;
            MAIN.customDLLButton.Animated = !MAIN.configCS.PerformanceMode;
            MAIN.personaLoc.Animated = !MAIN.configCS.PerformanceMode;
            MAIN.roundedToggle.Animated = !MAIN.configCS.PerformanceMode;
            MAIN.toastsToggle.Animated = !MAIN.configCS.PerformanceMode;
            MAIN.toastsSelector.Animated = !MAIN.configCS.PerformanceMode;
            MAIN.performanceModeToggle.Animated = !MAIN.configCS.PerformanceMode;
            MAIN.packProfileButtonOpen.Animated = !MAIN.configCS.PerformanceMode;
            MAIN.exitPackProfilesButton.Animated = !MAIN.configCS.PerformanceMode;
            MAIN.loadProfileButton.Animated = !MAIN.configCS.PerformanceMode;
            MAIN.deleteProfileButton.Animated = !MAIN.configCS.PerformanceMode;
            MAIN.saveProfileButton.Animated = !MAIN.configCS.PerformanceMode;

            //Presets
            MAIN.preset1.BorderColor = outlineColor;
            MAIN.preset2.BorderColor = outlineColor;
            MAIN.preset3.BorderColor = outlineColor;
            MAIN.preset4.BorderColor = outlineColor;
            MAIN.preset5.BorderColor = outlineColor;
            MAIN.preset6.BorderColor = outlineColor;
            MAIN.preset7.BorderColor = outlineColor;
            MAIN.preset8.BorderColor = outlineColor;

            MAIN.preset1.BackColor = ColorTranslator.FromHtml(MAIN.presetCS.p1);
            MAIN.preset2.BackColor = ColorTranslator.FromHtml(MAIN.presetCS.p2);
            MAIN.preset3.BackColor = ColorTranslator.FromHtml(MAIN.presetCS.p3);
            MAIN.preset4.BackColor = ColorTranslator.FromHtml(MAIN.presetCS.p4);
            MAIN.preset5.BackColor = ColorTranslator.FromHtml(MAIN.presetCS.p5);
            MAIN.preset6.BackColor = ColorTranslator.FromHtml(MAIN.presetCS.p6);
            MAIN.preset7.BackColor = ColorTranslator.FromHtml(MAIN.presetCS.p7);
            MAIN.preset8.BackColor = ColorTranslator.FromHtml(MAIN.presetCS.p8);

            MAIN.presets.ForeColor = foreColor;
            MAIN.presets.BackColor = backColor2;
            MAIN.presets.RenderStyle.SelectionBackColor = accentColor;
            MAIN.presets.RenderStyle.SelectionForeColor = foreColor;
            MAIN.presets.RenderStyle.BorderColor = outlineColor;

            //Extras
            MAIN.AppearanceButton2.FillColor = backColor2;
            MAIN.AppearanceButton2.ForeColor = foreColor;

            MAIN.backImageTitle.BackColor = backColor;
            MAIN.backImageTitle.ForeColor = foreColor;

            MAIN.toastsTitle.BackColor = backColor;
            MAIN.toastsTitle.ForeColor = foreColor;

            MAIN.performanceModeTitle.BackColor = backColor;
            MAIN.performanceModeTitle.ForeColor = foreColor;

            MAIN.packProfilesTitle.BackColor = backColor;
            MAIN.packProfilesTitle.ForeColor = foreColor;

            MAIN.roundedTitle.BackColor = backColor;
            MAIN.roundedTitle.ForeColor = foreColor;

            MAIN.customImage.CheckedState.FillColor = accentColor;
            MAIN.customImage.ForeColor = foreColor;
            MAIN.customImage.FillColor = backColor2;

            MAIN.toastsToggle.CheckedState.FillColor = accentColor;
            MAIN.toastsToggle.ForeColor = foreColor;
            MAIN.toastsToggle.FillColor = backColor2;

            //Dropdown
            MAIN.toastsSelector.BorderColor = outlineColor;
            MAIN.toastsSelector.FillColor = backColor2;
            MAIN.toastsSelector.ForeColor = foreColor;
            MAIN.toastsSelector.FocusedState.BorderColor = outlineColor;
            MAIN.toastsSelector.ItemsAppearance.SelectedBackColor = Color.FromArgb(120, accentColor);

            MAIN.roundedToggle.CheckedState.FillColor = accentColor;
            MAIN.roundedToggle.ForeColor = foreColor;
            MAIN.roundedToggle.FillColor = backColor2;

            MAIN.performanceModeToggle.CheckedState.FillColor = accentColor;
            MAIN.performanceModeToggle.ForeColor = foreColor;
            MAIN.performanceModeToggle.FillColor = backColor2;

            MAIN.packProfileButtonOpen.CheckedState.FillColor = accentColor;
            MAIN.packProfileButtonOpen.ForeColor = foreColor;
            MAIN.packProfileButtonOpen.FillColor = backColor2;

            MAIN.exitPackProfilesButton.CheckedState.FillColor = accentColor;
            MAIN.exitPackProfilesButton.ForeColor = foreColor;
            MAIN.exitPackProfilesButton.FillColor = backColor2;

            MAIN.loadProfileButton.CheckedState.FillColor = accentColor;
            MAIN.loadProfileButton.ForeColor = foreColor;
            MAIN.loadProfileButton.FillColor = backColor2;

            MAIN.deleteProfileButton.CheckedState.FillColor = accentColor;
            MAIN.deleteProfileButton.ForeColor = foreColor;
            MAIN.deleteProfileButton.FillColor = backColor2;

            MAIN.saveProfileButton.CheckedState.FillColor = accentColor;
            MAIN.saveProfileButton.ForeColor = foreColor;
            MAIN.saveProfileButton.FillColor = backColor2;

            MAIN.guna2VScrollBar1.ThumbColor = backColor2;
            MAIN.packProfilesList.BackColor = backColor2;

            MAIN.profileNameLabel.ForeColor = foreColor;
            MAIN.profileListLabel.ForeColor = foreColor;

            MAIN.profileIconPictureBox.FillColor = backColor2;

            MAIN.profileNameTextbox.BorderColor = outlineColor;
            MAIN.profileNameTextbox.PlaceholderForeColor = Color.FromArgb(((foreColor.R + 55 <= 255) ? foreColor.R + 55 : foreColor.R - 55), ((foreColor.G + 55 <= 255) ? foreColor.G + 55 : foreColor.G - 55), ((foreColor.B + 55 <= 255) ? foreColor.B + 55 : foreColor.B - 55));
            MAIN.profileNameTextbox.ForeColor = foreColor;
            MAIN.profileNameTextbox.FillColor = backColor2;

            for (int i = 0; i < MAIN.packProfilesList.Controls.Count; i++)
            {
                if (MAIN.packProfilesList.Controls[i].GetType() != typeof(Guna2Button)) continue;

                ((Guna2Button)MAIN.packProfilesList.Controls[i]).FillColor = Color.FromArgb(((backColor.R + 10 <= 255) ? backColor.R + 10 : backColor.R - 10), ((backColor.G + 10 <= 255) ? backColor.G + 10 : backColor.G - 10), ((backColor.B + 10 <= 255) ? backColor.B + 10 : backColor.B - 10));
                ((Guna2Button)MAIN.packProfilesList.Controls[i]).ForeColor = foreColor;
                ((Guna2Button)MAIN.packProfilesList.Controls[i]).Animated = !MAIN.configCS.PerformanceMode;
            }

            MAIN.settingsTab.BackColor = backColor;

            MAIN.Refresh();
        }

        public static void About()
        {
            // Make the color variable smaller
            Color backColor = ColorTranslator.FromHtml(MAIN.themeCS.Background);
            Color foreColor = ColorTranslator.FromHtml(MAIN.themeCS.Foreground);
            Color fadedColor = ColorTranslator.FromHtml(MAIN.themeCS.Faded);

            MAIN.cosmeticsLabel.ForeColor = foreColor;
            MAIN.cosmeticsLabel.BackColor = backColor;
            MAIN.launcherLabel.ForeColor = foreColor;
            MAIN.launcherLabel.BackColor = backColor;
            MAIN.clientLabel.ForeColor = foreColor;
            MAIN.clientLabel.BackColor = backColor;

            MAIN.launcherBy.ForeColor = foreColor;
            MAIN.launcherBy.BackColor = backColor;
            MAIN.aboutDesc.ForeColor = foreColor;
            MAIN.aboutDesc.BackColor = backColor;
            MAIN.aboutBackgroundColor.BackColor = backColor;
            MAIN.aboutSeparator.BackColor = foreColor;
            MAIN.website.BackColor = backColor;
            MAIN.discord.BackColor = backColor;

            MAIN.helpButton.ForeColor = foreColor;
            MAIN.helpButton.FillColor = backColor;

            MAIN.cosmeticsVLabel.BackColor = backColor;
            MAIN.cosmeticsVLabel.ForeColor = fadedColor;

            MAIN.launcherVLabel.BackColor = backColor;
            MAIN.launcherVLabel.ForeColor = fadedColor;

            MAIN.clientVLabel.BackColor = backColor;
            MAIN.clientVLabel.ForeColor = fadedColor;

            MAIN.aboutTab.BackColor = backColor;

            //Performance Mode
            if (MAIN.configCS.PerformanceMode)
            {
                MAIN.helpButton.Animated = false;
                MAIN.helpButton.Animated = false;
            }
            else
            {
                MAIN.helpButton.Animated = true;
                MAIN.helpButton.Animated = true;
            }
        }

    }
}
