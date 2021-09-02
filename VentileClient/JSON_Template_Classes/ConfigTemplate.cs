using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentileClient.JSON_Template_Classes
{
    public class ConfigTemplate
    {
        //Private variables
        string windowState;
        bool autoInject;
        bool richPresence;
        string rpcText;
        bool rpcButton;
        string rpcButtonText;
        string rpcButtonLink;
        bool customDLL;
        string defaultDLL;
        int injectDelay;
        bool backgroundImage;
        string backgroundImageLoc;
        bool toasts;
        string toastsLoc;
        bool roundedButtons;
        bool performanceMode;

        public string WindowState
        {
            get
            {
                if (string.IsNullOrEmpty(windowState))
                    windowState = "Hide";

                return windowState.ToLower();
            }
            set
            {
                windowState = value;
            }
        }
        public bool AutoInject
        {
            get
            {
                return autoInject;
            }
            set
            {
                autoInject = value;
            }
        }
        public bool RichPresence
        {
            get
            {
                return richPresence;
            }
            set
            {
                richPresence = value;
            }
        }
        public string RpcText
        {
            get
            {
                if (string.IsNullOrEmpty(rpcText))
                    rpcText = "No Rpc Text";

                return rpcText;
            }
            set
            {
                rpcText = value;
            }
        }
        public bool RpcButton
        {
            get
            {
                return rpcButton;
            }
            set
            {
                rpcButton = value;
            }
        }
        public string RpcButtonText
        {
            get
            {
                if (string.IsNullOrEmpty(rpcButtonText))
                    rpcButtonText = "Hide";

                return rpcButtonText;
            }
            set
            {
                rpcButtonText = value;
            }
        }
        public string RpcButtonLink
        {
            get
            {
                if (string.IsNullOrEmpty(rpcButtonLink))
                    rpcButtonLink = "Hide";

                return rpcButtonLink;
            }
            set
            {
                rpcButtonLink = value;
            }
        }
        public bool CustomDLL
        {
            get
            {
                return customDLL;
            }
            set
            {
                customDLL = value;
            }
        }
        public string DefaultDLL
        {
            get
            {
                return defaultDLL;
            }
            set
            {
                defaultDLL = value;
            }
        }

        public int InjectDelay
        {
            get
            {
                return injectDelay;
            }
            set
            {
                injectDelay = value;
            }
        }

        public bool BackgroundImage
        {
            get
            {
                return backgroundImage;
            }
            set
            {
                backgroundImage = value;
            }
        }
        public string BackgroundImageLoc
        {
            get
            {
                return backgroundImageLoc;
            }
            set
            {
                backgroundImageLoc = value;
            }
        }
        public bool Toasts
        {
            get
            {
                return toasts;
            }
            set
            {
                toasts = value;
            }
        }
        public string ToastsLoc
        {
            get
            {
                if (string.IsNullOrEmpty(toastsLoc))
                    toastsLoc = "topRight";

                return toastsLoc;
            }
            set
            {
                toastsLoc = value;
            }
        }
        public bool RoundedButtons
        {
            get
            {
                return roundedButtons;
            }
            set
            {
                roundedButtons = value;
            }
        }

        public bool PerformanceMode
        {
            get
            {
                return performanceMode;
            }
            set
            {
                performanceMode = value;
            }
        }

    }
}
