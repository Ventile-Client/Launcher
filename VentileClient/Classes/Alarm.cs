using System;
using System.Globalization;
using System.Threading.Tasks;
using VentileClient.LauncherUtils;
using VentileClient.Utils;

namespace VentileClient.Classes
{
    public class Alarm
    {
        public Alarm(int hour, int minute, bool isRepeated, bool isPM, DateTime creationDate = new DateTime(), string name = "Alarm", string message = "Alarm Finished!")
        {
            Name = name;
            Message = message;
            Hour = hour;
            Minute = minute;
            IsRepeated = isRepeated;
            IsPM = isPM;
            CreationDate = (creationDate == new DateTime() ? DateTime.Now : creationDate);
        }

        public string Name;
        public string Message;
        public int Hour;
        public int Minute;
        public bool IsRepeated;
        public bool IsPM;
        public string ID = DateTime.Now.Ticks.ToString() + "-" + Guid.NewGuid().ToString();
        public DateTime CreationDate;

        private bool IsExpired;

        /// <summary>
        /// Cancel the alarm, and removes it from the last
        /// </summary>
        public void Delete()
        {
            CancelAlarm();
            DataManager.RemoveAlarm(this);
        }

        /// <summary>
        /// Checks if the current alarm should trigger based on the current time and meridiem
        /// </summary>
        /// <returns>boolean</returns>
        public bool ShouldTrigger()
        {
            DateTime currentTime = DateTime.Now;
            if (!IsRepeated)
                if (CreationDate.Month != currentTime.Month || CreationDate.Day != currentTime.Day)
                    return true;

            if (
                currentTime.Hour >= Hour &&
                currentTime.Minute >= Minute &&
                currentTime.ToString("tt", CultureInfo.InvariantCulture).ToLower() == (IsPM ? "pm" : "am")
                ) return true;

            return false;
        }

        /// <summary>
        /// Checks if the alarm isnt expired, and that it should trigger
        /// </summary>
        public void TestTrigger()
        {
            if (!IsExpired)
                if (ShouldTrigger()) Trigger();
        }


        /// <summary>
        /// Triggers the alarm, and if the alarm isnt repeated, removes it and cancels the alarm
        /// </summary>
        public async void Trigger()
        {
            Notif.Toast(this.Name, this.Message);
            MainWindow.INSTANCE.aLogger.Log("Alarm Triggered: " + this.Name + " | " + this.Message);
            CancelAlarm();

            if (!IsRepeated)
                Delete();
            else
            {
                await TaskEx.WaitWhile(ShouldTrigger, 1000);
                IsExpired = false;
            }
        }


        /// <summary>
        /// Cancels the alarm, by setting it to expired, and requesting cancel the AutoTrigger()
        /// </summary>
        public void CancelAlarm()
        {
            IsExpired = true;
        }
    }
}

public static class TaskEx
{
    /// <summary>
    /// Blocks while condition is true or timeout occurs.
    /// </summary>
    /// <param name="condition">The condition that will perpetuate the block.</param>
    /// <param name="frequency">The frequency at which the condition will be check, in milliseconds.</param>
    /// <param name="timeout">Timeout in milliseconds.</param>
    /// <exception cref="TimeoutException"></exception>
    /// <returns></returns>
    public static async Task WaitWhile(Func<bool> condition, int frequency = 25, int timeout = -1)
    {
        var waitTask = Task.Run(async () =>
        {
            while (condition()) await Task.Delay(frequency);
        });

        if (waitTask != await Task.WhenAny(waitTask, Task.Delay(timeout)))
            throw new TimeoutException();
    }

    /// <summary>
    /// Blocks until condition is true or timeout occurs.
    /// </summary>
    /// <param name="condition">The break condition.</param>
    /// <param name="frequency">The frequency at which the condition will be checked.</param>
    /// <param name="timeout">The timeout in milliseconds.</param>
    /// <returns></returns>
    public static async Task WaitUntil(Func<bool> condition, int frequency = 25, int timeout = -1)
    {
        var waitTask = Task.Run(async () =>
        {
            while (!condition()) await Task.Delay(frequency);
        });

        if (waitTask != await Task.WhenAny(waitTask,
                Task.Delay(timeout)))
            throw new TimeoutException();
    }
}