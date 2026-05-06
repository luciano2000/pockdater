using CommandLine;

namespace Pockdater.Options;

[Verb("update",  HelpText = "Run update all. (You can configure via the settings menu)")]
public class UpdateOptions : BaseOptions
{
    [Option ('c', "core", Required = false, HelpText = "The core you want to update.")]
    public string CoreName { get; set; }

    [Option('r', "clean", Required = false, HelpText = "Clean install. Remove all existing core files, before updating")]
    public bool CleanInstall { get; set; }
}
