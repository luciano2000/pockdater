// ReSharper disable InconsistentNaming

using Pockdater.Models.Updater;

namespace Pockdater.Models.OpenFPGA_Cores_Inventory.V3;

public class Release
{
    public string download_url { get; set; }
    public bool requires_license { get; set; }
    public ReleaseCore core { get; set; }
    public ReleaseData data { get; set; }
    public Updaters updaters { get; set; }
}
