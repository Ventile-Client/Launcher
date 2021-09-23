using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using VentileClient.JSON_Template_Classes;

namespace VentileClient
{
    public partial class HelpPrompt : Form
    {
        public HelpPrompt(ThemeTemplate themeCS, string[] tempHelpParam)
        {
            var helpParam = new List<string>(tempHelpParam);
            InitializeComponent();


            TopMost = true;
            this.BackColor = ColorTranslator.FromHtml(themeCS.Background);
            Title.ForeColor = ColorTranslator.FromHtml(themeCS.Foreground);
            Title.BackColor = ColorTranslator.FromHtml(themeCS.Background);
            HelpLog.ForeColor = ColorTranslator.FromHtml(themeCS.Faded);
            HelplogScrollPanel.BackColor = ColorTranslator.FromHtml(themeCS.SecondBackground);
            CoverUpSliderPanel.BackColor = ColorTranslator.FromHtml(themeCS.Background);


            for (int i = 0; i < helpParam.Count; i++)
            {
                HelpLog.Text += helpParam[i] + "\n";
            }
            HelpLog.Text += "\n";

            //Sizing
            Size size = TextRenderer.MeasureText(HelpLog.Text, HelpLog.Font);
            /*if (size.Height > changelog.Height - 10)
            {
                changelog.Height = size.Height + 10;
                this.Height = changelog.Height + 70;
            }*/
            if (size.Width > HelplogScrollPanel.Width - (15 + CoverUpSliderPanel.Width))
            {
                HelplogScrollPanel.Width = size.Width + (15 + CoverUpSliderPanel.Width);
                this.Width = HelplogScrollPanel.Width + CoverUpSliderPanel.Width;
            }
            this.Refresh();
        }

        private void fadeIn_Tick(object sender, EventArgs e)
        {
            if (Opacity < 1)
            {
                this.Opacity += 0.04;
            }
            else
            {
                fadeIn.Stop();
            }
        }

        private void fadeOut_Tick(object sender, EventArgs e)
        {
            if (Opacity > 0)
            {
                this.Opacity -= 0.04;
            }
            else
            {
                fadeOut.Stop();
                this.Close();
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            fadeOut.Start();
        }
    }
}
