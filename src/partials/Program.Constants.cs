// ReSharper disable UseRawString

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
        @"
  ____   ___   ____ _  _____   _  _____ ___ ____
 |  _ \ / _ \ / ___| |/ /   \ / \|_   _| __| _  \
 | |_) | | | | |   | ' /| |) / _ \ | | | _|| |) |
 |  __/| |_| | |___| . \|  _/ ___ \| | | |__|  __/
 |_|    \___/ \____|_|\_\_|/_/   \_\|_| |___|_|
                                                   ",
        @"
  _ __   ___   ___  _  __  __| | __ _| |_ ___ _ __
 | '_ \ / _ \ / __|| |/ / / _  |/ _  | __/ _ \ '__|
 | |_) | (_) | (__ |   < | (_| | (_| | ||  __/ |
 | .__/ \___/ \___||_|\_\ \__,_|\__,_|\__\___|_|
 |_|
                                                    ",
        @"
  _   _   _   _   _   _   _   _   _
 / \ / \ / \ / \ / \ / \ / \ / \ / \
( P | O | C | K | D | A | T | E | R )
 \_/ \_/ \_/ \_/ \_/ \_/ \_/ \_/ \_/
                                     ",
        @"
 |``'  .``  '``| |``  |``'  /``\  |``''|  '``| |`'\
 |--   |    |  | |<   |  | |----| |    | |--  |--<
 |  .  `..  `--| |__. |__'  \__/  |___.'  `--| |  \
                                                    ",
        @"
 ______  ______  ______  ____  _____   ______  ______  ______
|  __  \|  __  \|  ____||  _ \|  __ \ |  __  ||__  __||  ____|
| |__) || |  | || |     | | \ | |  | || |__|    | |   | |___
|  ___/ | |  | || |     | |_/ | |__| || |  \    | |   |  ___|
| |     | |__| || |____ |  _ \|  ___/ | |\  \  _| |_  | |____
|_|     |______/ \______||_| \_|_|     |_| \__|______| |______|
                                                               ",
        @"
 +-+-+-+-+-+-+-+-+-+
 |P|O|C|K|D|A|T|E|R|
 +-+-+-+-+-+-+-+-+-+
   Analogue Pocket Updater
                          ",
        @"
 ##  ##  ###  ## ##  ##   ###   ###  ##  ##  ##
 ##  ## ## ## ## ## ##   ## ## ## ## ##  ## ##
 ## ## ## ## ## ##  ##  ##  ## ##  ## ## ###
 ##### ## ## ## ## ##  ####### ##  ## ## ## ##
 ##  ## ## ## ## ## ### ##   ## ## ## ##  ## ##
 ##  ##  ###  #####  ## ##   ##  ###  ##  ##  ##
                                               ",
        @"       _=,_
    o_/6 /#\
    \__ |##/
     ='|--\
       /   #'-.    P O C K D A T E R
       \#|_   _'-. /
        |/ \_( # |''
       C/ ,--___/
                    "
    };
}
