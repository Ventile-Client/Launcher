using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentileClient.JSON_Template_Classes
{
    public class ThemeTemplate
    {// Private variables
        string theme;
        string background;
        string secondBackground;
        string foreground;
        string accent;
        string outline;
        string faded;

        public string Theme
        {
            get
            {
                if (string.IsNullOrEmpty(theme))
                    theme = "Dark";

                return theme.ToLower();
            }
            set
            {
                theme = value;
            }
        }
        public string Background
        {
            get
            {
                if (string.IsNullOrEmpty(background))
                    background = "#141414";

                return (background);
            }
            set
            {
                background = (value);
            }
        }
        public string SecondBackground
        {
            get
            {
                if (string.IsNullOrEmpty(secondBackground))
                    background = "#282828";

                return (secondBackground);
            }
            set
            {
                secondBackground = (value);
            }
        }
        public string Foreground
        {
            get
            {
                if (string.IsNullOrEmpty(foreground))
                    background = "#FFFFFF";

                return (foreground);
            }
            set
            {
                foreground = (value);
            }
        }
        public string Accent
        {
            get
            {
                if (string.IsNullOrEmpty(accent))
                    background = "#FF2C29";

                return (accent);
            }
            set
            {
                accent = (value);
            }
        }
        public string Outline
        {
            get
            {
                if (string.IsNullOrEmpty(outline))
                    outline = "#050505";

                return (outline);
            }
            set
            {
                outline = (value);
            }
        }
        public string Faded
        {
            get
            {
                if (string.IsNullOrEmpty(faded))
                    faded = "#C0C0C0";

                return (faded);
            }
            set
            {
                faded = (value);
            }
        }
    }
}

