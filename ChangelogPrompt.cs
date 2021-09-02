using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            changelog.ForeColor = ColorTranslator.FromHtml(themeCS.Faded);
            changelog.BackColor = ColorTranslator.FromHtml(themeCS.SecondBackground);


            for (int i = 0; i < changelogParam.Length; i++)
            {
                changelog.Text += changelogParam[i] + "\n";
            }

            //Sizing
            Size size = TextRenderer.MeasureText(changelog.Text, changelog.Font);
            if (size.Height > changelog.Height - 10)
            {
                changelog.Height = size.Height + 10;
                this.Height = changelog.Height + 70;
            }
            if (size.Width > changelog.Width - 15)
            {
                changelog.Width = size.Width + 15;
                this.Width = changelog.Width + 35;
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
