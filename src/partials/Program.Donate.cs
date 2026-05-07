using QRCoder;

namespace Pockdater;

internal static partial class Program
{
    private static void ShowDonationQR()
    {
        Console.Clear();

        using QRCodeGenerator generator = new QRCodeGenerator();
        using QRCodeData data = generator.CreateQrCode(DONATION_URL, QRCodeGenerator.ECCLevel.L);
        using AsciiQRCode qr = new AsciiQRCode(data);
        string[] qrLines = qr.GetGraphic(1, "██", "  ").Split('\n');

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
