using QRCoder;

namespace Pockdater;

internal static partial class Program
{
    private static string[] BuildQRLines()
    {
        using QRCodeGenerator generator = new QRCodeGenerator();
        using QRCodeData data = generator.CreateQrCode(DONATION_URL, QRCodeGenerator.ECCLevel.L);
        using AsciiQRCode qr = new AsciiQRCode(data);
        return qr.GetGraphic(1, "██", "  ").Split('\n');
    }

    // Displayed on startup: QR code on the left, donation message on the right
    private static void WriteHeaderWithQR()
    {
        string[] qrLines = BuildQRLines();

        string[] textLines =
        {
            "",
            "  pockdater v" + VERSION,
            "  Analogue Pocket Updater",
            "",
            "  If this software has been useful to you,",
            "  please consider supporting Retrogamer Brasil",
            "  by scanning the QR code to make a donation.",
            "",
            "  Every contribution keeps the project alive!",
            "",
            "  PayPal: scan the code or visit",
            "  " + DONATION_URL,
        };

        int totalLines = Math.Max(qrLines.Length, textLines.Length);

        int qrWidth = qrLines.Length > 0 ? qrLines.Max(l => l.Length) : 0;

        Console.ForegroundColor = ConsoleColor.White;

        for (int i = 0; i < totalLines; i++)
        {
            string qrPart = i < qrLines.Length ? qrLines[i] : string.Empty;
            string txtPart = i < textLines.Length ? textLines[i] : string.Empty;

            // QR in white, text in cyan
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(qrPart.PadRight(qrWidth + 2));
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(txtPart);
        }

        Console.ResetColor();
    }

    // Full-screen donation view accessible from the menu
    private static void ShowDonationQR()
    {
        Console.Clear();

        string[] qrLines = BuildQRLines();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine();
        Console.WriteLine("  Support Retrogamer Brasil  |  @souretrogamer  |  www.retrogamer.com.br");
        Console.WriteLine("  \"Play like a kid from the 80s.\"");
        Console.WriteLine();
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.White;
        foreach (string line in qrLines)
            Console.WriteLine("  " + line);

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine();
        Console.WriteLine("  Scan to donate via PayPal — every contribution helps!");
        Console.WriteLine("  " + DONATION_URL);
        Console.ResetColor();
        Console.WriteLine();

        Pause();
    }
}
