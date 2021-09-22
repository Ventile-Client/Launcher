using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;

namespace TextFormatterBecusLazy
{
    class Program
    {
        static string TargetDir;
        static string ProjectDir;
        static void Main(string[] args)
        {

            TargetDir = args[0] ?? @"C:\Users\Death\source\repos\_VentileRemake\VentileClient\VentileClient\bin\x64\Release";
            ProjectDir = args[1] ?? @"C:\Users\Death\source\repos\_VentileRemake\VentileClient\VentileClient";


            Directory.CreateDirectory(Path.Combine(TargetDir, "LauncherZip"));
            Console.WriteLine("Created Temporary Launcher Zip Folder");

            Console.WriteLine("Begin Moving Launcher Files:");
            foreach (string file in Directory.GetFiles(TargetDir))
            {
                var mFile = new FileInfo(file);

                mFile.MoveTo(Path.Combine(TargetDir, "LauncherZip", mFile.Name));
                Console.WriteLine("  Moved: " + mFile.Name);

            }
            Console.WriteLine("Movied Files to Launcher Zip Folder");

            Console.WriteLine("Begin Deleting Excess Files:");
            foreach (string file in Directory.GetFiles(Path.Combine(TargetDir, "LauncherZip")))
            {
                var mFile = new FileInfo(file);

                if (file.EndsWith(".xml") || file.EndsWith(".pdb") || file.EndsWith(".winmd"))
                {
                    mFile.Delete();
                    Console.WriteLine("  Deleted: " + mFile.Name);
                }
            }
            Console.WriteLine("Deleted Excess Files");

            Console.WriteLine("Zipping Launcher");
            ZipFile.CreateFromDirectory(Path.Combine(TargetDir, "LauncherZip"), Path.Combine(TargetDir, "VentileClient.zip"));
            Console.WriteLine("Zipped Launcher");

            Directory.CreateDirectory(Path.Combine(TargetDir, "PresetsZip"));
            Console.WriteLine("Created Temporary Presets Zip Folder");

            Console.WriteLine("Begin Copying Preset Files:");
            foreach (string file in Directory.GetFiles(Path.Combine(ProjectDir, "ReleaseData")))
            {
                var mFile = new FileInfo(file);

                if (file.EndsWith(".json"))
                {

                    mFile.CopyTo(Path.Combine(TargetDir, "PresetsZip", mFile.Name));
                    Console.WriteLine("  Copied: " + mFile.Name);
                }
            }

            Console.WriteLine("Zipping Presets");
            ZipFile.CreateFromDirectory(Path.Combine(TargetDir, "PresetsZip"), Path.Combine(TargetDir, "Presets.zip"));
            Console.WriteLine("Zipped Presets");

            Console.WriteLine("Copied Changelog");
            File.Copy(Path.Combine(ProjectDir, "ReleaseData\\Changelog.txt"), Path.Combine(TargetDir, "Changelog.txt"));

            Directory.Delete(Path.Combine(TargetDir, "LauncherZip"), true);
            Directory.Delete(Path.Combine(TargetDir, "PresetsZip"), true);
            Console.WriteLine("Deleted Extra Folders");

            FormatDiscord();
            FormatGithub();

            Console.WriteLine("Cleaned Up!");

            Process.Start(TargetDir);

            Console.WriteLine("--------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("|");
            Console.WriteLine($"| Built: {TargetDir}");
            Console.WriteLine("|");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------");

            Console.ReadKey();
        }

        static void FormatDiscord()
        {
            string[] changelogLines = File.ReadAllLines(Path.Combine(ProjectDir, "ReleaseData\\Changelog.txt"));
           

            using (var sw = new StreamWriter(Path.Combine(TargetDir, "DiscordChangelog.txt"))) //path
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
                sw.Close();
            }
        }

        static void FormatGithub()
        {
            string[] changelogLines = File.ReadAllLines(Path.Combine(ProjectDir, "ReleaseData\\Changelog.txt"));


            using (var sw = new StreamWriter(Path.Combine(TargetDir, "GithubChangelog.txt"))) //path
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
                sw.Close();
            }
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
