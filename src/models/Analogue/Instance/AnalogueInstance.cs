// ReSharper disable InconsistentNaming

using Pockdater.Models.Analogue.Shared;

namespace Pockdater.Models.Analogue.Instance;

public class Instance
{
    public DataSlot[] data_slots { get; set; }
    public string data_path { get; set; } = string.Empty;
    public string magic { get; set; } = "APF_VER_1";
}
