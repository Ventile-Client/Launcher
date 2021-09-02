using System;
using System.Drawing;
using System.Windows.Forms;
using VentileClient.JSON_Template_Classes;

namespace VentileClient
{
    public partial class ChangelogPrompt : Form
    {
        public ChangelogPrompt(ThemeTemplate themeCS, string[] changelogParam)
        {
            InitializeComponent();
            TopMost = true;
            this.BackColor = ColorTranslator.FromHtml(themeCS.Background);
            Title.ForeColor = ColorTranslator.FromHtml(themeCS.Foreground);
            Title.BackColor = ColorTranslator.FromHtml(themeCS.Background);
            ChangeLog.ForeColor = ColorTranslator.FromHtml(themeCS.Faded);
            ChangeLogScrollPanel.BackColor = ColorTranslator.FromHtml(themeCS.SecondBackground);
            CoverUpSliderPanel.BackColor = ColorTranslator.FromHtml(themeCS.Background);

            for (int i = 0; i < changelogParam.Length; i++)
            {
                ChangeLog.Text += changelogParam[i] + "\n";
            }

            //Sizing
            Size size = TextRenderer.MeasureText(ChangeLog.Text, ChangeLog.Font);
            /*if (size.Height > changelog.Height - 10)
            {
                changelog.Height = size.Height + 10;
                this.Height = changelog.Height + 70;
            }*/
            if (size.Width > ChangeLogScrollPanel.Width - (15 + CoverUpSliderPanel.Width))
            {
                ChangeLogScrollPanel.Width = size.Width + (15 + CoverUpSliderPanel.Width);
                this.Width = ChangeLogScrollPanel.Width + CoverUpSliderPanel.Width;
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
