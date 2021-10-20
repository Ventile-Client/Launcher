namespace VentileClient.JSON_Template_Classes
{
    public class ThemeTemplate
    {
        // Private variables
        string _theme;
        string _background;
        string _secondBackground;
        string _foreground;
        string _accent;
        string _outline;
        string _faded;

        public string Theme
        {
            get
            {
                if (string.IsNullOrEmpty(_theme))
                    _theme = "Dark";

                return _theme.ToLower();
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
                    _background = "#141414";

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
                    _background = "#282828";

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
                    _background = "#FFFFFF";

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
                    _background = "#FF2C29";

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
                    _outline = "#050505";

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
                    _faded = "#C0C0C0";

                return (_faded);
            }
            set
            {
                _faded = (value);
            }
        }
    }
}

