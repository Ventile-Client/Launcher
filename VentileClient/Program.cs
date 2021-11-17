using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace VentileClient
{
    static class Program
    {
        const int SW_RESTORE = 9;
        const int SW_SHOW = 5;
        const int SW_HIDE = 0;

        [DllImport("User32.dll")]
        private static extern bool SetForegroundWindow(IntPtr handle);
        [DllImport("User32.dll")]
        private static extern bool ShowWindow(int handle, int nCmdShow);
        [DllImport("User32.dll")]
        private static extern bool IsIconic(IntPtr handle);

        // WORKING: Unhide the window when its minimized to the tray
        public static void BringProcessToFront(Process process)
        {
            IntPtr handle = process.MainWindowHandle;
            if (IsIconic(handle))
            {
               ShowWindow(handle.ToInt32(), SW_RESTORE);
            }

            SetForegroundWindow(handle);
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string procName = Process.GetCurrentProcess().ProcessName;
            Process[] proc = Process.GetProcessesByName(procName);
            if (proc.Length > 1) // 1 because of the current process
            {
                MessageBox.Show("It seems like the launcher is already open!\nMaybe check your tray?", "Already Open");

                BringProcessToFront(proc[0]);
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());
        }
    }
}
