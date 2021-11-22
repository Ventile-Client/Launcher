using IWshRuntimeLibrary;
using System;
using System.Diagnostics;
using System.IO;
using System.Management.Automation;

namespace VentileClient.Utils
{
    public static class Shortcuts
    {

        public static void CreateHard(string GotoPath, string ShortcutPath, string ShortcutName)
        {
            // Check necessary parameters first:
            if (String.IsNullOrEmpty(GotoPath))
                throw new ArgumentNullException("GotoPath");
            if (String.IsNullOrEmpty(ShortcutPath))
                throw new ArgumentNullException("ShortcutPath");
           if (String.IsNullOrEmpty(ShortcutName))
                throw new ArgumentNullException("ShortcutName");

            PowershellHelp.Invoke("New-Item -ItemType Junction -Path \"" + Path.Combine(ShortcutPath, ShortcutName) + "\" -Target \"" + GotoPath + "\"");
        }

        public static void UpdateHard(string GotoPath, string ShortcutPath, string ShortcutName)
        {
            // Check necessary parameters first:
            if (String.IsNullOrEmpty(GotoPath))
                throw new ArgumentNullException("GotoPath");
            if (String.IsNullOrEmpty(ShortcutPath))
                throw new ArgumentNullException("ShortcutPath");
            if (String.IsNullOrEmpty(ShortcutName))
                throw new ArgumentNullException("ShortcutName");

            DeleteHard(ShortcutPath, ShortcutName);
            CreateHard(GotoPath, ShortcutPath, ShortcutName);
        }

        public static void DeleteHard(string ShortcutPath, string ShortcutName)
        {
            // Check necessary parameters first:
            if (String.IsNullOrEmpty(ShortcutPath))
                throw new ArgumentNullException("ShortcutPath");
            if (String.IsNullOrEmpty(ShortcutName))
                throw new ArgumentNullException("ShortcutName");

            PowershellHelp.Invoke($"(Get-Item {Path.Combine(ShortcutPath, ShortcutName)}).Delete()");
        }
    }
}
