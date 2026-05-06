using System.Diagnostics;
using System.Reflection;
using System.Text;
using Pockdater.Helpers;

namespace Pockdater;

internal static partial class Program
{
    private static int UpdateSelfAndRun(string directory, string[] updaterArgs)
    {
        string execName = "pockdater";

        if (SYSTEM_OS_PLATFORM == "win")
        {
            execName += ".exe";
        }

        // Resolve the actual running exe path — not the install path (-p flag).
        string execLocation = Environment.ProcessPath ?? Path.Combine(directory, execName);
        string execDir = Path.GetDirectoryName(execLocation) ?? directory;
        string backupName = $"{execName}.backup";
        string backupLocation = Path.Combine(execDir, backupName);
        const string updateName = "pockdater.zip";
        // Zip was downloaded to temp (matching CheckVersion)
        string updateLocation = Path.Combine(Path.GetTempPath(), updateName);

        int exitCode = int.MinValue;

        try
        {
            // Load System.IO.Compression now
            Assembly.Load("System.IO.Compression");
            Assembly.Load("System.IO.Compression.ZipFile");

            if (SYSTEM_OS_PLATFORM != "win")
            {
                Assembly.Load("System.IO.Pipes");
            }

            // Move current process file
            Console.WriteLine($"Renaming {execLocation} to {backupLocation}");
            File.Move(execLocation, backupLocation, true);

            // Extract update into the exe's own folder
            Console.WriteLine($"Extracting {updateLocation} to {execDir}");
            ZipHelper.ExtractToDirectory(updateLocation, execDir, true);

            // Execute
            Console.WriteLine($"Executing {execLocation}");

            // Rebuild the arguments, quoting the values
            // First element is always the verb, quote every element
            //   that starts with a dash (denoting a switch)
            StringBuilder args = new();

            for (int i = 0; i < updaterArgs.Length; i++)
            {
                if (i != 0 && updaterArgs[i][0] != '-')
                    args.Append($"\"{updaterArgs[i]}\" ");
                else
                    args.Append($"{updaterArgs[i]} ");
            }

            ProcessStartInfo pInfo = new ProcessStartInfo(execLocation)
            {
                Arguments = args.ToString(),
                UseShellExecute = false
            };

            Process p = Process.Start(pInfo);

            p!.WaitForExit();

            exitCode = p.ExitCode;
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred: {ex.GetType().Name}:{ex}");
        }

        return exitCode;
    }
}
