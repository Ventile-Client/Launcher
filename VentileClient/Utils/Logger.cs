using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace VentileClient
{
    public enum LogLevel
    {
        Default,
        Debug,
        Error,
        Information
    }

    public enum LogLocation
    {
        Default,
        Console,
        File,
        ConsoleAndFile
    }

    public class Logger : LogBase
    {
        private string _dir; //Make public if want to be able to edit by using foo.Directory = "C:\foo\bar"
        private string _fileName; //Make public if want to be able to edit by using foo.FileName = "FileName.txt"
        private bool _enabled;
        private LogLevel _exceptionLevel;
        private LogLevel _messageLevel;
        private LogLocation _exceptionLocation;
        private LogLocation _messageLocation;
        private readonly string _initializedTime;
        private readonly string _fileType = ".log";

        public Logger()
        {
            _initializedTime = DateTime.Now.ToString("MMM-dd-yyyy (hh.mm.sstt)");

            this._dir = Path.Combine(@"C:\temp\VentileClient\Logs\", _initializedTime);
            this._fileName = "VentileLog" + _fileType;
            this._enabled = false;
            this._exceptionLevel = LogLevel.Error;
            this._messageLevel = LogLevel.Information;
            this._exceptionLocation = LogLocation.ConsoleAndFile;
            this._messageLocation = LogLocation.Console;

            // Check for log directory
            System.IO.Directory.CreateDirectory(_dir);

            Debug.WriteLine("-------------------\nLogger Initialized: {0}\n  State: {1}\n-------------------", this._fileName, "Disabled");
        }

        public Logger(string Directory, string FileName)
        {
            _initializedTime = DateTime.Now.ToString("MMM-dd-yyyy (hh.mm.sstt)");

            this._dir = Directory + "\\" + _initializedTime;
            this._fileName = FileName + _fileType;
            this._enabled = false;
            this._exceptionLevel = LogLevel.Error;
            this._messageLevel = LogLevel.Information;
            this._exceptionLocation = LogLocation.ConsoleAndFile;
            this._messageLocation = LogLocation.Console;

            // Check for log directory
            System.IO.Directory.CreateDirectory(_dir);


            Debug.WriteLine("-------------------\nLogger Initialized: {0}\n  State: {1}\n-------------------", this._fileName, "Disabled");
        }

        public Logger(string Directory, string FileName, bool Enabled)
        {
            _initializedTime = DateTime.Now.ToString("MMM-dd-yyyy (hh.mm.sstt)");

            this._dir = Directory + "\\" + _initializedTime;
            this._fileName = FileName + _fileType;
            this._enabled = Enabled;
            this._exceptionLevel = LogLevel.Error;
            this._messageLevel = LogLevel.Information;
            this._exceptionLocation = LogLocation.ConsoleAndFile;
            this._messageLocation = LogLocation.Console;

            // Check for log directory
            System.IO.Directory.CreateDirectory(_dir);

            if (Enabled)
            {
                Debug.WriteLine("-------------------\nLogger Initialized: {0}\n  State: {1}\n-------------------", this._fileName, "Enabled");
                this._enabled = false;
                Enable();
            }
        }

        public Logger(string Directory, string FileName, bool Enabled, LogLevel ExceptionLevel, LogLevel MessageLevel, LogLocation ExceptionLocation, LogLocation MessageLocation)
        {
            _initializedTime = DateTime.Now.ToString("MMM-dd-yyyy (hh.mm.sstt)");

            this._dir = Directory + "\\" + _initializedTime;
            this._fileName = FileName + _fileType;
            this._enabled = Enabled;
            this._exceptionLevel = ExceptionLevel;
            this._messageLevel = MessageLevel;
            this._exceptionLocation = ExceptionLocation;
            this._messageLocation = MessageLocation;

            // Check for log directory
            System.IO.Directory.CreateDirectory(_dir);

            if (Enabled)
            {
                Debug.WriteLine("-------------------\nLogger Initialized: {0}\n  State: {1}\n-------------------", this._fileName, "Enabled");
                this._enabled = false;
                Enable();
            }
        }

        private static int EXTRA_METHODS_FROM_STACK_TRACE = 15; //Change to decide how many methods to skip at the end (Extra Methods)

        private Task<string> FormatOutput(LogLevel logLevel, string message)
        {
            string.Format("", "", "", "", "", "", "", "", "");
            string output = string.Format("{0}: {1} : {2}\n   ", logLevel.ToString(), DateTime.Now.ToString("ddd, dd MMM yyyy hh:mm:ss tt"), message);
            var st = new StackTrace(3, true);
            for (int i = 4; i < st.GetFrames().Length - EXTRA_METHODS_FROM_STACK_TRACE; i++) // Change start index to decide how many methods to skip from the beginning (Extra Methods)
            {
                StackFrame sf = st.GetFrame(i);
                output += string.Format("[Method: {0}, Line: {1}] <- ", sf.GetMethod(), sf.GetFileColumnNumber());
            }
            output = output.Remove(output.Length - 4, 4); //Remove extra arrow
            output += "\n"; //Double new line
            return Task.FromResult(output);
        }

        private async void LogToFile(string logOutput)
        {
            await Task.Run(() =>
                {

                    READ_WRITE_LOCK.EnterWriteLock();
                    try
                    {
                        // Append text to the file
                        using (StreamWriter sw = File.AppendText(Path.Combine(_dir, _fileName)))
                        {
                            sw.WriteLine(logOutput);
                            sw.Close();
                        }
                    }
                    finally
                    {
                        // Release lock
                        READ_WRITE_LOCK.ExitWriteLock();
                    }
                });
        }

        private void LogToConsole(string logOutput)
        {
            Debug.WriteLine(logOutput);
        }

        public void Enable()
        {
            if (_enabled)
            {
                Debug.WriteLine($"-------------------\nLogger \"{_fileName}\" Already Enabled!\n-------------------");
                return;
            }
            using (StreamWriter sw = File.AppendText(Path.Combine(_dir, _fileName)))
            {
                sw.WriteLine(string.Format("\nNew Session: {0}", DateTime.Now.ToString("MMM-dd-yyyy hh:mm:ss tt")));
                sw.WriteLine("---------------------------------------------------------------------------------------\n");
                sw.Close();
            }
            _enabled = true;
        }

        public void Disable()
        {
            if (!_enabled)
            {
                Debug.WriteLine($"-------------------\nLogger \"{_fileName}\" Already Disabled!\n-------------------");
                return;
            }
            using (StreamWriter sw = File.AppendText(Path.Combine(_dir, _fileName)))
            {
                sw.WriteLine("---------------------------------------------------------------------------------------");
                sw.Close();
            }
            _enabled = false;
        }

        private static ReaderWriterLockSlim READ_WRITE_LOCK = new ReaderWriterLockSlim();

        private async Task Publish(string message, LogLevel logLevel, LogLocation logLoc)
        {
            // Check for log directory
            Directory.CreateDirectory(_dir);

            if (!_enabled) return;

            string output = await FormatOutput(logLevel, message);

            if (logLoc == LogLocation.Console || logLoc == LogLocation.ConsoleAndFile)
            {
                LogToConsole(output);
            }
            if (logLoc == LogLocation.File || logLoc == LogLocation.ConsoleAndFile)
            {
                LogToFile(output);
            }
        }

        public override async void Log(string message, LogLevel logLevel = LogLevel.Default, LogLocation logLoc = LogLocation.Default)
        {
            if (logLevel == LogLevel.Default) logLevel = _messageLevel;
            if (logLoc == LogLocation.Default) logLoc = _messageLocation;
            await Publish(message, logLevel, logLoc);
        }

        public override async void Log(Exception exception, LogLevel logLevel = LogLevel.Default, LogLocation logLoc = LogLocation.Default)
        {
            if (logLevel == LogLevel.Default) logLevel = _exceptionLevel;
            if (logLoc == LogLocation.Default) logLoc = _exceptionLocation;
            await Publish(exception.Message, logLevel, logLoc);
        }
    }

    public abstract class LogBase
    {
        // Log Message
        public abstract void Log(string message, LogLevel loggingLevel = LogLevel.Default, LogLocation logLoc = LogLocation.Default);

        // Log Exception
        public abstract void Log(Exception exception, LogLevel loggingLevel = LogLevel.Default, LogLocation logLoc = LogLocation.Default);
    }
}
