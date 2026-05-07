using System.Runtime.InteropServices;

namespace Pockdater.Helpers;

public static class ConsoleHelper
{
    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern bool GetConsoleMode(IntPtr hConsoleHandle, out uint lpMode);

    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern bool SetConsoleMode(IntPtr hConsoleHandle, uint dwMode);

    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern IntPtr GetStdHandle(int nStdHandle);

    private const int STD_OUTPUT_HANDLE = -11;
    private const uint ENABLE_VIRTUAL_TERMINAL_PROCESSING = 0x0004;

    public static void EnableAnsiOnWindows()
    {
        if (!OperatingSystem.IsWindows()) return;
        try
        {
            IntPtr handle = GetStdHandle(STD_OUTPUT_HANDLE);
            GetConsoleMode(handle, out uint mode);
            SetConsoleMode(handle, mode | ENABLE_VIRTUAL_TERMINAL_PROCESSING);
        }
        catch { }
    }

    public static void ShowProgressBar(long current, long total)
    {
        var progress = (double)current / total;
        var progressWidth = Console.WindowWidth - 14;
        var progressBarWidth = (int)(progress * progressWidth);
        var progressBar = new string('=', progressBarWidth);
        var emptyProgressBar = new string(' ', progressWidth - progressBarWidth);

        Console.Write($"\r{progressBar}{emptyProgressBar}] {progress * 100:0.00}%");

        if (current == total)
        {
            Console.CursorLeft = 0;
            Console.Write(new string(' ', Console.WindowWidth));
            Console.CursorLeft = 0;
            Console.Write("\r");
        }
    }
}
