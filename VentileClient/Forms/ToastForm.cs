using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

using VentileClient.JSON_Template_Classes;

namespace VentileClient
{
    public partial class ToastForm : Form
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

        public ToastForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        public enum EnmAction
        {
            wait,
            start,
            close
        }

        private EnmAction _action;

        private int _x, _y;
        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (this._action)
            {
                case EnmAction.wait:
                    this.timer1.Interval = 3250;
                    _action = EnmAction.close;
                    break;

                case EnmAction.start:
                    if (_configCS.ToastsLoc.ToLower() == "topright")
                    {
                        this.timer1.Interval = 1;
                        this.Opacity += 0.1; //Fade in
                        if (this._x < this.Location.X)
                        {
                            this.Left--; //Moves form from right to left
                        }
                        else
                        {
                            if (this.Opacity == 1.0)
                            {
                                _action = EnmAction.wait; //Wait
                            }
                        }
                    }

                    if (_configCS.ToastsLoc.ToLower() == "bottomright")
                    {
                        this.timer1.Interval = 1;
                        this.Opacity += 0.1;
                        if (this._x < this.Location.X)
                        {
                            this.Left--;
                        }
                        else
                        {
                            if (this.Opacity == 1.0)
                            {
                                _action = EnmAction.wait;
                            }
                        }
                    }

                    if (_configCS.ToastsLoc.ToLower() == "topleft")
                    {
                        this.timer1.Interval = 1;
                        this.Opacity += 0.1;
                        if (this._x > this.Location.X)
                        {
                            this.Left++;
                        }
                        else
                        {
                            if (this.Opacity == 1.0)
                            {
                                _action = EnmAction.wait;
                            }
                        }
                    }

                    if (_configCS.ToastsLoc.ToLower() == "bottomleft")
                    {
                        this.timer1.Interval = 1;
                        this.Opacity += 0.1;
                        if (this._x > this.Location.X)
                        {
                            this.Left++;
                        }
                        else
                        {
                            if (this.Opacity == 1.0)
                            {
                                _action = EnmAction.wait;
                            }
                        }
                    }
                    break;

                case EnmAction.close:
                    if (_configCS.ToastsLoc.ToLower() == "topright")
                    {
                        this.timer1.Interval = 1;
                        this.Opacity -= 0.1;
                        this.Left -= 3;
                        if (base.Opacity == 0.0)
                        {
                            base.Close();
                        }
                    }

                    if (_configCS.ToastsLoc.ToLower() == "bottomright")
                    {
                        this.timer1.Interval = 1;
                        this.Opacity -= 0.1;
                        this.Left -= 3;
                        if (base.Opacity == 0.0)
                        {
                            base.Close();
                        }
                    }

                    if (_configCS.ToastsLoc.ToLower() == "topleft")
                    {
                        this.timer1.Interval = 1;
                        this.Opacity -= 0.1;

                        this.Left += 3;
                        if (base.Opacity == 0.0)
                        {
                            base.Close();
                        }
                    }

                    if (_configCS.ToastsLoc.ToLower() == "bottomleft")
                    {
                        this.timer1.Interval = 1;
                        this.Opacity -= 0.1; //Fade out
                        this.Left += 3; //Move to the right
                        if (base.Opacity == 0.0)
                        {
                            base.Close(); //Close
                        }
                    }
                    break;
            }
        }



        private void Toast_Load(object sender, EventArgs e)
        {
            this.BackColor = ColorTranslator.FromHtml(_themeCS.Accent);
            this.title.BackColor = ColorTranslator.FromHtml(_themeCS.Accent);
            this.message.BackColor = ColorTranslator.FromHtml(_themeCS.Accent);
            this.title.ForeColor = ColorTranslator.FromHtml(_themeCS.Foreground);
            this.message.ForeColor = ColorTranslator.FromHtml(_themeCS.Foreground);
            this.Refresh();
        }

        ConfigTemplate _configCS;
        ThemeTemplate _themeCS;

        public void ShowToast(string title, string msg, ConfigTemplate conf, ThemeTemplate theme)
        {
            _configCS = conf;
            _themeCS = theme;

            if (_configCS.Toasts == 0) // 0 Means off
                return;


            MainWindow.INSTANCE.dLogger.Log("Toast Called : " + title + " | " + msg);

            string fname;

            Size size = TextRenderer.MeasureText(msg, this.message.Font);
            if (this.Width < size.Width + 45)
            {
                this.Width = size.Width + 45;
            }

            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            this.Opacity = 0.0;
            this.StartPosition = FormStartPosition.Manual;

            this.message.Text = msg;
            this.title.Text = title;

            switch (_configCS.ToastsLoc.ToLower())
            {
                case "topright":
                    for (int i = 0; i < 10; i++)
                    {
                        fname = "toast" + i.ToString();
                        var toast = (ToastForm)Application.OpenForms[fname];

                        if (toast == null)
                        {
                            this.Name = fname;
                            this._x = Screen.PrimaryScreen.WorkingArea.Width - this.Width + 15;
                            this._y = 7 + ((this.Height + 3) * i);
                            this.Location = new Point(this._x, this._y);
                            break;
                        }
                    }

                    this._x = Screen.PrimaryScreen.WorkingArea.Width - base.Width - 5;
                    break;

                case "bottomright":
                    for (int i = 0; i < 10; i++)
                    {
                        fname = "toast" + i.ToString();
                        var toast = (ToastForm)Application.OpenForms[fname];

                        if (toast == null)
                        {
                            this.Name = fname;
                            this._x = Screen.PrimaryScreen.WorkingArea.Width - this.Width + 15;
                            this._y = Screen.PrimaryScreen.WorkingArea.Height - (7 + (this.Height + 3) * (i + 1));
                            this.Location = new Point(this._x, this._y);
                            break;
                        }
                    }

                    this._x = Screen.PrimaryScreen.WorkingArea.Width - base.Width - 5;
                    break;

                case "topleft":
                    for (int i = 0; i < 10; i++)
                    {
                        fname = "toast" + i.ToString();
                        var toast = (ToastForm)Application.OpenForms[fname];

                        if (toast == null)
                        {
                            this.Name = fname;
                            this._x = -15;
                            this._y = 7 + ((this.Height + 3) * i);
                            this.Location = new Point(this._x, this._y);
                            break;
                        }
                    }

                    this._x = 5;
                    break;

                case "bottomleft":
                    for (int i = 0; i < 10; i++)
                    {
                        fname = "toast" + i.ToString();
                        var toast = (ToastForm)Application.OpenForms[fname];

                        if (toast == null)
                        {
                            this.Name = fname;
                            this._x = -15;
                            this._y = Screen.PrimaryScreen.WorkingArea.Height - (7 + (this.Height + 3) * (i + 1));
                            this.Location = new Point(this._x, this._y);
                            break;
                        }
                    }

                    this._x = 5;
                    break;
            }

            this.Show();
            this._action = EnmAction.start;
            this.timer1.Interval = 1;
            this.timer1.Start();
        }
    }
}