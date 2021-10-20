using IWshRuntimeLibrary;
using System;
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

            PowerShell.Create()
                .AddScript("New-Item -ItemType Junction -Path \"" + Path.Combine(ShortcutPath + ShortcutName) + "\" -Target \"" + GotoPath + "\"")
                .Invoke();
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
            PowerShell.Create()
                .AddScript($"(Get-Item {Path.Combine(ShortcutPath, ShortcutName)}).Delete()")
                .Invoke();

        }

        public static void Create(string GotoPath, string ShortcutPath, string ShortcutName, string Description = null, string Arguments = null, string HotKey = null, string WorkingDirectory = null)
        {
            // Check necessary parameters first:
            if (String.IsNullOrEmpty(GotoPath))
                throw new ArgumentNullException("GotoPath");
            if (String.IsNullOrEmpty(ShortcutPath))
                throw new ArgumentNullException("ShortcutPath");
            if (String.IsNullOrEmpty(ShortcutName))
                throw new ArgumentNullException("ShortcutName");

            // Create WshShellClass instance:
            var wshShell = new WshShell();

            // Create shortcut object:
            IWshShortcut shorcut = (IWshShortcut)wshShell.CreateShortcut(Path.Combine(ShortcutPath, ShortcutName));
            // Assign shortcut properties:
            shorcut.TargetPath = GotoPath;
            if (!String.IsNullOrEmpty(Description))
                shorcut.Description = Description;
            if (!String.IsNullOrEmpty(Arguments))
                shorcut.Arguments = Arguments;
            if (!String.IsNullOrEmpty(HotKey))
                shorcut.Hotkey = HotKey;
            if (!String.IsNullOrEmpty(WorkingDirectory))
                shorcut.WorkingDirectory = WorkingDirectory;

            // Save the shortcut:
            shorcut.Save();
        }

        public static void Delete(string ShortcutPath, string ShortcutName)
        {
            if (String.IsNullOrEmpty(ShortcutPath))
                throw new ArgumentNullException("ShortcutPath");
            if (String.IsNullOrEmpty(ShortcutName))
                throw new ArgumentNullException("ShortcutName");

            System.IO.File.Delete(Path.Combine(ShortcutPath, ShortcutName));
        }
    }
}
