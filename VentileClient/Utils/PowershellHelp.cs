using System;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace VentileClient.Utils
{
    public class PowershellHelp
    {
        public static void Invoke(string script)
        {
                PowerShell.Create().AddScript(script).Invoke();
        }

        public static async Task<string> Return(string script, string defaultReturn = null)
        {
            string output = defaultReturn;
            await Task.Run(() =>
            {
                var powerShell = PowerShell.Create();
                    powerShell
                        .AddScript(script)
                        .AddCommand("Out-String");
                    var psOutput = powerShell.Invoke();
                    var stringBuilder = new StringBuilder();
                    foreach (var pSObject in psOutput)
                        stringBuilder.AppendLine(pSObject.ToString());

                    output = stringBuilder.ToString().Replace(Environment.NewLine, "");
            });
            return output;
        }
    }
}
