using System.Reflection;

namespace Pockdater;

internal static partial class Program
{
    private static readonly string VERSION = Assembly.GetExecutingAssembly().GetName().Version!.ToString(3);

    private static readonly string SYSTEM_OS_PLATFORM = GetSystemPlatform();

    private const string USER = "luciano2000";

    private const string REPOSITORY = "pockdater";

    private const string RELEASE_URL = "https://github.com/luciano2000/pockdater/releases/download/{0}/pockdater_{1}.zip";

    private const string RETROGAMER_CREDIT =
        "Retrogamer Brasil  |  @souretrogamer  |  www.retrogamer.com.br" +
        "\n\"Play like a kid from the 80s.\"";

    private static readonly string[] WELCOME_MESSAGES =
    {
        """
                        888
                        888
                        888
        888d888 .d88b.  888888 888d888 .d88b.   .d88b.   8888b.  88888b.d88b.   .d88b.  888d888
        888P"  d8P  Y8b 888    888P"  d88""88b d88P"88b     "88b 888 "888 "88b d8P  Y8b 888P"
        888    88888888 888    888    888  888 888  888 .d888888 888  888  888 88888888 888
        888    Y8b.     Y88b.  888    Y88..88P Y88b 888 888  888 888  888  888 Y8b.     888
        888     "Y8888   "Y888 888     "Y88P"   "Y88888 "Y888888 888  888  888  "Y8888  888
                                                    888
                                               Y8b d88P
                                                "Y88P"
        """
    };
}
