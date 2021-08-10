using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using VentileClient.JSON_Template_Classes;
using Newtonsoft.Json;
using System.Diagnostics;

namespace VentileClient
{
    public partial class Toast : Form
    {


        //Rounded Window
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );

        public Toast()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        public enum enmAction
        {
            wait,
            start,
            close
        }

        private Toast.enmAction action;

        private int x, y;

        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (this.action)
            {
                case enmAction.wait:
                    timer1.Interval = 3250;
                    action = enmAction.close;
                    break;

                case enmAction.start:
                    if (configCS.ToastsLoc.ToLower() == "topright")
                        topRight(true);

                    if (configCS.ToastsLoc.ToLower() == "bottomright")
                        bottomRight(true);

                    if (configCS.ToastsLoc.ToLower() == "topleft")
                        topLeft(true);

                    if (configCS.ToastsLoc.ToLower() == "bottomleft")
                        bottomLeft(true);
                    break;

                case enmAction.close:
                    if (configCS.ToastsLoc.ToLower() == "topright")
                        topRight(false);

                    if (configCS.ToastsLoc.ToLower() == "bottomright")
                        bottomRight(false);

                    if (configCS.ToastsLoc.ToLower() == "topleft")
                        topLeft(false);

                    if (configCS.ToastsLoc.ToLower() == "bottomleft")
                        bottomLeft(false);
                    break;
            }
        }

        void topRight(bool Start)
        {
            if (Start)
            {
                timer1.Interval = 1;
                this.Opacity += 0.1; //Fade in
                if (this.x < this.Location.X)
                {
                    this.Left--; //Moves form from right to left
                }
                else
                {
                    if (this.Opacity == 1.0)
                    {
                        action = enmAction.wait; //Wait
                    }
                }
            }
            else
            {
                timer1.Interval = 1;
                this.Opacity -= 0.1;
                this.Left -= 3;
                if (base.Opacity == 0.0)
                {
                    base.Close();
                }
            }
        }

        void bottomRight(bool Start)
        {
            if (Start)
            {
                timer1.Interval = 1;
                this.Opacity += 0.1;
                if (this.x < this.Location.X)
                {
                    this.Left--;
                }
                else
                {
                    if (this.Opacity == 1.0)
                    {
                        action = enmAction.wait;
                    }
                }
            }
            else
            {
                timer1.Interval = 1;
                this.Opacity -= 0.1;

                this.Left -= 3;
                if (base.Opacity == 0.0)
                {
                    base.Close();
                }
            }
        }

        void topLeft(bool Start)
        {
            if (Start)
            {
                timer1.Interval = 1;
                this.Opacity += 0.1;
                if (this.x > this.Location.X)
                {
                    this.Left++;
                }
                else
                {
                    if (this.Opacity == 1.0)
                    {
                        action = enmAction.wait;
                    }
                }
            }
            else
            {
                timer1.Interval = 1;
                this.Opacity -= 0.1;

                this.Left += 3;
                if (base.Opacity == 0.0)
                {
                    base.Close();
                }
            }
        }

        void bottomLeft(bool Start)
        {
            if (Start)
            {
                timer1.Interval = 1;
                this.Opacity += 0.1;
                if (this.x > this.Location.X)
                {
                    this.Left++;
                }
                else
                {
                    if (this.Opacity == 1.0)
                    {
                        action = enmAction.wait;
                    }
                }
            }
            else
            {
                timer1.Interval = 1;
                this.Opacity -= 0.1; //Fade out
                this.Left += 3; //Move to the right
                if (base.Opacity == 0.0)
                {
                    base.Close(); //Close
                }
            }
        }



        private void Toast_Load(object sender, EventArgs e)
        {

            this.BackColor = ColorTranslator.FromHtml(themeCS.Accent);
            title.BackColor = ColorTranslator.FromHtml(themeCS.Accent);
            message.BackColor = ColorTranslator.FromHtml(themeCS.Accent);
            title.ForeColor = ColorTranslator.FromHtml(themeCS.Foreground);
            message.ForeColor = ColorTranslator.FromHtml(themeCS.Foreground);
            this.Refresh();
        }

        ConfigTemplate configCS;
        ThemeTemplate themeCS;

        public void showToast(string title, string msg, ConfigTemplate conf, ThemeTemplate theme)
        {
            configCS = conf;
            themeCS = theme;
            if (!configCS.Toasts)
                return;

            string fname;

            switch (configCS.ToastsLoc.ToLower())
            {
                case "topright":
                    this.Opacity = 0.0;
                    this.StartPosition = FormStartPosition.Manual;

                    for (int i = 0; i < 10; i++)
                    {
                        fname = "toast" + i.ToString();
                        Toast toast = (Toast)Application.OpenForms[fname];

                        if (toast == null)
                        {
                            this.Name = fname;
                            this.x = Screen.PrimaryScreen.WorkingArea.Width - this.Width + 15;
                            this.y = 7 + (this.Height + 3) * i;
                            this.Location = new Point(this.x, this.y);
                            break;
                        }
                    }

                    this.x = Screen.PrimaryScreen.WorkingArea.Width - base.Width - 5;

                    this.message.Text = msg;
                    this.title.Text = title;

                    this.Show();
                    this.action = enmAction.start;
                    this.timer1.Interval = 1;
                    timer1.Start();
                    break;

                case "bottomright":
                    this.Opacity = 0.0;
                    this.StartPosition = FormStartPosition.Manual;

                    for (int i = 0; i < 10; i++)
                    {
                        fname = "toast" + i.ToString();
                        Toast toast = (Toast)Application.OpenForms[fname];

                        if (toast == null)
                        {
                            this.Name = fname;
                            this.x = Screen.PrimaryScreen.WorkingArea.Width - this.Width + 15;
                            this.y = Screen.PrimaryScreen.WorkingArea.Height - (7 + (this.Height + 3) * (i + 1));
                            this.Location = new Point(this.x, this.y);
                            break;
                        }
                    }

                    this.x = Screen.PrimaryScreen.WorkingArea.Width - base.Width - 5;

                    this.message.Text = msg;
                    this.title.Text = title;

                    this.Show();
                    this.action = enmAction.start;
                    this.timer1.Interval = 1;
                    timer1.Start();
                    break;

                case "topleft":
                    this.Opacity = 0.0;
                    this.StartPosition = FormStartPosition.Manual;

                    for (int i = 0; i < 10; i++)
                    {
                        fname = "toast" + i.ToString();
                        Toast toast = (Toast)Application.OpenForms[fname];

                        if (toast == null)
                        {
                            this.Name = fname;
                            this.x = -15;
                            this.y = 7 + (this.Height + 3) * i;
                            this.Location = new Point(this.x, this.y);
                            break;
                        }
                    }

                    this.x = 5;

                    this.message.Text = msg;
                    this.title.Text = title;

                    this.Show();
                    this.action = enmAction.start;
                    this.timer1.Interval = 1;
                    timer1.Start();
                    break;

                case "bottomleft":
                    this.Opacity = 0.0;
                    this.StartPosition = FormStartPosition.Manual;

                    for (int i = 0; i < 10; i++)
                    {
                        fname = "toast" + i.ToString();
                        Toast toast = (Toast)Application.OpenForms[fname];

                        if (toast == null)
                        {
                            this.Name = fname;
                            this.x = -15;
                            this.y = Screen.PrimaryScreen.WorkingArea.Height - (7 + (this.Height + 3) * (i + 1));
                            this.Location = new Point(this.x, this.y);
                            break;
                        }
                    }

                    this.x = 5;

                    this.message.Text = msg;
                    this.title.Text = title;

                    this.Show();
                    this.action = enmAction.start;
                    this.timer1.Interval = 1;
                    timer1.Start();
                    break;
            }
        }
    }
}
