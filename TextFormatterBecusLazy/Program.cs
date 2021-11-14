using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;

namespace TextFormatterBecusLazy
{
    class Program
    {
        static string TARGET_DIR;
        static string PROJECT_DIR;
        static void Main(string[] args)
        {

            TARGET_DIR = args[0] ?? @"C:\Users\Death\source\repos\_VentileRemake\VentileClient\VentileClient\bin\x64\Release";
            PROJECT_DIR = args[1] ?? @"C:\Users\Death\source\repos\_VentileRemake\VentileClient\VentileClient";


            Directory.CreateDirectory(Path.Combine(TARGET_DIR, "LauncherZip"));
            Console.WriteLine("Created Temporary Launcher Zip Folder");

            Console.WriteLine("Begin Moving Launcher Files:");
            foreach (string file in Directory.GetFiles(TARGET_DIR))
            {
                var mFile = new FileInfo(file);

                mFile.MoveTo(Path.Combine(TARGET_DIR, "LauncherZip", mFile.Name));
                Console.WriteLine("  Moved: " + mFile.Name);

            }
            Console.WriteLine("Movied Files to Launcher Zip Folder");

            Console.WriteLine("Begin Deleting Excess Files:");
            foreach (string file in Directory.GetFiles(Path.Combine(TARGET_DIR, "LauncherZip")))
            {
                var mFile = new FileInfo(file);

                if (file.EndsWith(".xml") || file.EndsWith(".pdb") || file.EndsWith(".winmd"))
                {
                    mFile.Delete();
                    Console.WriteLine("  Deleted: " + mFile.Name);
                }
            }
            Console.WriteLine("Deleted Excess Files");

            File.Copy(Path.Combine(PROJECT_DIR, "AppLogo.ico"), Path.Combine(TARGET_DIR, "LauncherZip", "AppLogo.ico"));
            Console.WriteLine("Copied Icon");

            Console.WriteLine("Zipping Launcher");
            ZipFile.CreateFromDirectory(Path.Combine(TARGET_DIR, "LauncherZip"), Path.Combine(TARGET_DIR, "VentileClient.zip"));
            Console.WriteLine("Zipped Launcher");

            File.Copy(Path.Combine(PROJECT_DIR, "ReleaseData\\Changelog.txt"), Path.Combine(TARGET_DIR, "Changelog.txt"));
            Console.WriteLine("Copied Changelog");

            Directory.Delete(Path.Combine(TARGET_DIR, "LauncherZip"), true);
            Console.WriteLine("Deleted Extra Folder");

            FormatDiscord();
            FormatGithub();

            Console.WriteLine("Cleaned Up!");

            Process.Start(TARGET_DIR);

            Console.WriteLine("--------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("|");
            Console.WriteLine($"| Built: {TARGET_DIR}");
            Console.WriteLine("|");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------");

            return;
        }

        static void FormatDiscord()
        {
            string[] changelogLines = File.ReadAllLines(Path.Combine(PROJECT_DIR, "ReleaseData\\Changelog.txt"));

            using (var sw = new StreamWriter(Path.Combine(TARGET_DIR, ".DiscordChangelog.txt"))) //path
            {
                    for (int i = 0; i < changelogLines.Length; i++)
                    {
                        if (changelogLines[i].StartsWith(" -"))
                        {
                            sw.WriteLine($"``` {changelogLines[i].Substring(3, changelogLines[i].Length - 3)} ```");
                        }
                        else if (changelogLines[i].StartsWith("    "))
                        {
                            sw.WriteLine($"> {changelogLines[i].Trim()}");
                        }
                        else
                        {
                            sw.WriteLine(changelogLines[i]);
                        }
                    }

                sw.WriteLine();
                sw.WriteLine("You can use Ventile-Installer (<#890391081462689793>) or do it manually using the .zip below");
                sw.Flush();
                sw.Close();
            }
            Console.WriteLine("Formatted Discord");
        }

        static void FormatGithub()
        {
            string[] changelogLines = File.ReadAllLines(Path.Combine(PROJECT_DIR, "ReleaseData\\Changelog.txt"));
            

            using (var sw = new StreamWriter(Path.Combine(TARGET_DIR, ".GithubChangelog.txt"))) //path
            {
                for (int i = 0; i < changelogLines.Length; i++)
                {
                    if (changelogLines[i].StartsWith(" -"))
                    {
                        sw.WriteLine($"### {changelogLines[i].Substring(3, changelogLines[i].Length - 3)}");
                    }
                    else
                    {
                        sw.WriteLine(changelogLines[i]);
                    }
                }
                sw.Flush();
                sw.Close();
            }
            Console.WriteLine("Formatted Github");
        }

    }
}

/*@echo off
if %ERRORLEVEL% GEQ 8 goto failed

if $(ConfigurationName) == Release(
  cd $(TargetDir)
  mkdir LauncherZip
  echo Created Temporary Launcher Zip Folder
  cd LauncherZip
  move $(TargetDir) *.* $(TargetDir)LauncherZip
  echo Movied Files to Launcher Zip Folder
  del *.xml
  echo Deleted.xml files
  del *.pdb
  echo Deleted.pdb files
  del *.winmd
  echo Deleted.winmd files
  powershell Compress - Archive - Path "$(TargetDir)LauncherZip\*.*" - DestinationPath "$(TargetDir)\VentileClient.zip"
  echo Zipped Launcher

  cd $(TargetDir)
  mkdir PresetsZip
  echo Created Temporary Presets Zip Folder
  cd PresetsZip
  for / R $(ProjectDir)ReleaseData %% f in (*.json) do copy "%%f" $(TargetDir)PresetsZip\
  echo Copied.json files
  powershell Compress-Archive -Path "$(TargetDir)PresetsZip\*.*" -DestinationPath "$(TargetDir)\Presets.zip"
  echo Zipped Presets
  cd $(TargetDir)
  copy $(ProjectDir) ReleaseData\Changelog.txt $(TargetDir)
  rmdir /s /q $(TargetDir) PresetsZip
  rmdir /s /q $(TargetDir) LauncherZip
  echo Cleaned Up!

  explorer "$(TargetDir)"

  echo --------------------------------------------------------------------------------------------------------------
  echo ^|
  echo ^|^ Built: $(TargetDir)
  echo ^|
  echo --------------------------------------------------------------------------------------------------------------

  goto success

  :failed
  Failed Post Build!
  exit 1

  :success
  exit 0
) else (
echo------------------------------------------------------------ -
echo ^| ^IF BUILDING TO PUBLISH, SWITCH TO RELEASE MODE
echo -------------------------------------------------------------
)*/
