using QRCoder;

namespace Pockdater;

internal static partial class Program
{
    private static void ShowDonationQR()
    {
        Console.Clear();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine();
        Console.WriteLine("  Support Retrogamer Brasil");
        Console.WriteLine("  " + RETROGAMER_CREDIT.Split('\n')[0]);
        Console.WriteLine();
        Console.ResetColor();

        // Generate QR code using ECCLevel.L (lowest) to keep the matrix small
        using QRCodeGenerator generator = new QRCodeGenerator();
        using QRCodeData data = generator.CreateQrCode(DONATION_URL, QRCodeGenerator.ECCLevel.L);
        using AsciiQRCode qr = new AsciiQRCode(data);

        // darkColorString / whiteColorString — use block chars that render well in most terminals
        string qrText = qr.GetGraphic(1, "██", "  ");

        foreach (string line in qrText.Split('\n'))
        {
            Console.WriteLine("  " + line);
        }

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine();
        Console.WriteLine("  Scan to donate via PayPal — every contribution helps!");
        Console.WriteLine("  " + DONATION_URL);
        Console.ResetColor();
        Console.WriteLine();

        Pause();
    }
}
