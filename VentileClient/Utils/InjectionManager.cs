using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Security.AccessControl;
using System.IO;
using System.Security.Principal;

namespace VentileClient.Utils
{
    public static class InjectionManager
    {
        //                    THIS CODE IS NOT BY ME, I HAVE NOT CODED THIS INJECTOR, 12BRENDON34 HAS GIVEN IT TO ME BECAUSE IM TO STIPUD TO FIGURE THIS OUT                    \\

        private static void ApplyAppPackages(string DLLPath)
        {
            var InfoFile = new FileInfo(DLLPath);
            FileSecurity fSecurity = InfoFile.GetAccessControl();
            fSecurity.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier("S-1-15-2-1"), FileSystemRights.FullControl, InheritanceFlags.None, PropagationFlags.NoPropagateInherit, AccessControlType.Allow));
            InfoFile.SetAccessControl(fSecurity);
        }

        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("kernel32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        private static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        private static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress,
            uint dwSize, uint flAllocationType, uint flProtect);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out UIntPtr lpNumberOfBytesWritten);

        [DllImport("kernel32.dll")]
        private static extern IntPtr CreateRemoteThread(IntPtr hProcess,
            IntPtr lpThreadAttributes, uint dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);


        // privileges
        private const int PROCESS_CREATE_THREAD = 0x0002;
        private const int PROCESS_QUERY_INFORMATION = 0x0400;
        private const int PROCESS_VM_OPERATION = 0x0008;
        private const int PROCESS_VM_WRITE = 0x0020;
        private const int PROCESS_VM_READ = 0x0010;

        // used for memory allocation
        private const uint MEM_COMMIT = 0x00001000;
        private const uint MEM_RESERVE = 0x00002000;
        private const uint PAGE_READWRITE = 4;

        private static bool ALREADY_ATTEMPTED_INJECT = false;

        public static void InjectDLL(string DownloadedDllFilePath)
        {
            if (!File.Exists(DownloadedDllFilePath))
            {
                Notif.Toast("DLL", "Not injecting, no file specified");
                return;
            }
            Task.Delay(1000);
            Process[] targetProcessIndex = Process.GetProcessesByName("Minecraft.Windows");
            if (targetProcessIndex.Length > 0)
            {
                ApplyAppPackages(DownloadedDllFilePath);

                Process targetProcess = Process.GetProcessesByName("Minecraft.Windows")[0];
                IntPtr procHandle = OpenProcess(PROCESS_CREATE_THREAD | PROCESS_QUERY_INFORMATION | PROCESS_VM_OPERATION | PROCESS_VM_WRITE | PROCESS_VM_READ, false, targetProcess.Id);

                IntPtr loadLibraryAddr = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");

                IntPtr allocMemAddress = VirtualAllocEx(procHandle, IntPtr.Zero, (uint)((DownloadedDllFilePath.Length + 1) * Marshal.SizeOf(typeof(char))), MEM_COMMIT | MEM_RESERVE, PAGE_READWRITE);

                WriteProcessMemory(procHandle, allocMemAddress, Encoding.Default.GetBytes(DownloadedDllFilePath), (uint)((DownloadedDllFilePath.Length + 1) * Marshal.SizeOf(typeof(char))), out UIntPtr _);
                CreateRemoteThread(procHandle, IntPtr.Zero, 0, loadLibraryAddr, allocMemAddress, 0, IntPtr.Zero);

                ALREADY_ATTEMPTED_INJECT = false;

                Notif.Toast("DLL", "Injected!");
                Notif.Toast("Path", DownloadedDllFilePath);
                MainWindow.INSTANCE.dLogger.Log($"DLL Injected: {DownloadedDllFilePath}");
            }
            else
            {
                if (!ALREADY_ATTEMPTED_INJECT)
                {
                    ALREADY_ATTEMPTED_INJECT = true;
                    Notif.Toast("DLL", "Injection failed");
                    MainWindow.INSTANCE.dLogger.Log($"Injection Failed: {DownloadedDllFilePath}");
                }
                else
                {
                    ALREADY_ATTEMPTED_INJECT = false;
                    Notif.Toast("Minecraft", "I cannot find minecraft! (Bedrock)");
                    MainWindow.INSTANCE.dLogger.Log($"Minecraft Bedrock doesn't exist.");
                }
            }
        }

    }
}
