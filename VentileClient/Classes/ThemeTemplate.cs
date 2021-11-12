using System.Drawing;

namespace VentileClient.JSON_Template_Classes
{
    public class ThemeTemplate
    {
        public enum theme
        {
            Dark,
            Light
        }

        // Private variables
        theme _theme;
        string _background;
        string _secondBackground;
        string _foreground;
        string _accent;
        string _outline;
        string _faded;

        public theme Theme
        {
            get {
                return _theme;
            }
            set
            {
                _theme = value;
            }
        }
        public string Background
        {
            get
            {
                if (string.IsNullOrEmpty(_background))
                    _background = Themes.darkTheme.Background;

                return (_background);
            }
            set
            {
                _background = (value);
            }
        }
        public string SecondBackground
        {
            get
            {
                if (string.IsNullOrEmpty(_secondBackground))
                {
                    _secondBackground = Themes.darkTheme.SecondBackground;
                }

                return (_secondBackground);
            }
            set
            {
                _secondBackground = (value);
            }
        }
        public string Foreground
        {
            get
            {
                if (string.IsNullOrEmpty(_foreground))
                    _foreground = Themes.darkTheme.Foreground;

                return (_foreground);
            }
            set
            {
                _foreground = (value);
            }
        }
        public string Accent
        {
            get
            {
                if (string.IsNullOrEmpty(_accent))
                    _accent = Themes.darkTheme.Accent;

                return (_accent);
            }
            set
            {
                _accent = (value);
            }
        }
        public string Outline
        {
            get
            {
                if (string.IsNullOrEmpty(_outline))
                    _outline = Themes.darkTheme.Outline;

                return (_outline);
            }
            set
            {
                _outline = (value);
            }
        }
        public string Faded
        {
            get
            {
                if (string.IsNullOrEmpty(_faded))
                    _faded = Themes.darkTheme.Faded;

                return (_faded);
            }
            set
            {
                _faded = (value);
            }
        }
    }

    public static class Themes
    {
        public static readonly ThemeTemplate darkTheme = new ThemeTemplate()
        {
            Background = ColorTranslator.ToHtml(Color.FromArgb(20, 20, 20)),
            SecondBackground = ColorTranslator.ToHtml(Color.FromArgb(40, 40, 40)),
            Accent = ColorTranslator.ToHtml(Color.FromArgb(65, 105, 255)),
            Faded = ColorTranslator.ToHtml(Color.FromArgb(192, 192, 192)),
            Foreground = ColorTranslator.ToHtml(Color.FromArgb(255, 255, 255)),
            Outline = ColorTranslator.ToHtml(Color.FromArgb(30, 30, 30))
        };

        public static readonly ThemeTemplate lightTheme = new ThemeTemplate()
        {
            Background = ColorTranslator.ToHtml(Color.FromArgb(240, 240, 240)),
            SecondBackground = ColorTranslator.ToHtml(Color.FromArgb(205, 205, 205)),
            Accent = ColorTranslator.ToHtml(Color.FromArgb(65, 105, 255)),
            Faded = ColorTranslator.ToHtml(Color.FromArgb(163, 163, 163)),
            Foreground = ColorTranslator.ToHtml(Color.FromArgb(35, 35, 35)),
            Outline = ColorTranslator.ToHtml(Color.FromArgb(180, 180, 180))
        };
    }
}

