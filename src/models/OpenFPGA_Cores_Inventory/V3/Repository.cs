// ReSharper disable InconsistentNaming

namespace Pockdater.Models.OpenFPGA_Cores_Inventory.V3;

public class Repository
{
    public string platform { get; set; }
    public string owner { get; set; }
    public string name { get; set; }
    public Funding funding { get; set; }
}
