using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VentileClient.Utils
{
    public static class ControlManager
    {
        static MainWindow MAIN = MainWindow.INSTANCE;

        public static Control GetControl(string controlTag, Control parentCtrl)
        {
            foreach (Control c in parentCtrl.Controls)
            {
                if ((string)c.Tag == controlTag)
                    return c;
            }

            MAIN.defaultLogger.Log($"Could not find a control with the specified tag: {controlTag}!", LogLevel.Error);
            return null;
        }
        public static List<Control> GetControlByType(Type type, Control parentCtrl)
        {
            var ctrls = new List<Control>();
            foreach (Control c in parentCtrl.Controls)
            {
                if (c.GetType() == type)
                {
                    ctrls.Add(c);
                }
            }
            return ctrls;
        }
    }
}
