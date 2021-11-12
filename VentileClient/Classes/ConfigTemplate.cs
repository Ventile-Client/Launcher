namespace VentileClient.JSON_Template_Classes
{
    public class ConfigTemplate
    {
        //Private variables
        string _windowState;
        bool _autoInject;
        bool _richPresence = true;
        string _rpcText;
        bool _rpcButton;
        string _rpcButtonText;
        string _rpcButtonLink;
        bool _customDLL;
        string _defaultDLL;
        bool _persona;
        string _personaLoc;
        int _injectDelay;
        bool _toasts = true;
        string _toastsLoc;
        bool _roundedButtons = true;
        bool _performanceMode;
        bool _backgroundImage;
        string _backgroundImageLoc;
        string _defaultProfile;

        public string WindowState
        {
            get
            {
                if (string.IsNullOrEmpty(_windowState))
                    _windowState = "Hide";

                return _windowState.ToLower();
            }
            set
            {
                _windowState = value;
            }
        }
        public bool AutoInject
        {
            get
            {
                return _autoInject;
            }
            set
            {
                _autoInject = value;
            }
        }
        public bool RichPresence
        {
            get
            {
                return _richPresence;
            }
            set
            {
                _richPresence = value;
            }
        }
        public string RpcText
        {
            get
            {
                if (string.IsNullOrEmpty(_rpcText))
                    _rpcText = "No Rpc Text";

                return _rpcText;
            }
            set
            {
                _rpcText = value;
            }
        }
        public bool RpcButton
        {
            get
            {

                return _rpcButton;
            }
            set
            {
                _rpcButton = value;
            }
        }
        public string RpcButtonText
        {
            get
            {
                if (string.IsNullOrEmpty(_rpcButtonText))
                    _rpcButtonText = "No Text";

                return _rpcButtonText;
            }
            set
            {
                _rpcButtonText = value;
            }
        }
        public string RpcButtonLink
        {
            get
            {
                if (string.IsNullOrEmpty(_rpcButtonLink))
                    _rpcButtonLink = "https://none";

                return _rpcButtonLink;
            }
            set
            {
                _rpcButtonLink = value;
            }
        }
        public bool CustomDLL
        {
            get
            {
                return _customDLL;
            }
            set
            {
                _customDLL = value;
            }
        }
        public string DefaultDLL
        {
            get
            {
                return _defaultDLL;
            }
            set
            {
                _defaultDLL = value;
            }
        }
        public bool Persona
        {
            get
            {
                return _persona;
            }
            set
            {
                _persona = value;
            }
        }
        public string PersonaLoc
        {
            get
            {
                return _personaLoc;
            }
            set
            {
                _personaLoc = value;
            }
        }
        public int InjectDelay
        {
            get
            {
                return _injectDelay;
            }
            set
            {
                _injectDelay = value;
            }
        }
        public bool Toasts
        {
            get
            {
                return _toasts;
            }
            set
            {
                _toasts = value;
            }
        }
        public string ToastsLoc
        {
            get
            {
                if (string.IsNullOrEmpty(_toastsLoc))
                    _toastsLoc = "topRight";

                return _toastsLoc;
            }
            set
            {
                _toastsLoc = value;
            }
        }
        public bool RoundedButtons
        {
            get
            {
                return _roundedButtons;
            }
            set
            {
                _roundedButtons = value;
            }
        }
        public bool PerformanceMode
        {
            get
            {
                return _performanceMode;
            }
            set
            {
                _performanceMode = value;
            }
        }
        public bool BackgroundImage
        {
            get
            {
                return _backgroundImage;
            }
            set
            {
                _backgroundImage = value;
            }
        }
        public string BackgroundImageLoc
        {
            get
            {
                return _backgroundImageLoc;
            }
            set
            {
                _backgroundImageLoc = value;
            }
        }

        public string DefaultProfile
        {
            get
            {
                return _defaultProfile;
            }
            set
            {
                _defaultProfile = value;
            }
        }
    }
}
