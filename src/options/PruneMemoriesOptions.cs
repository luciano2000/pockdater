using CommandLine;

namespace Pockdater.Options;

[Verb("prune-memories",  HelpText = "Prune old memories")]
public class PruneMemoriesOptions : BaseOptions
{
    [Option ('c', "core", Required = false, HelpText = "The core you want to prune save states for.")]
    public string CoreName { get; set; }
}
