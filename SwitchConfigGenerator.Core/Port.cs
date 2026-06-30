namespace SwitchConfigGenerator.Core;

public class Port
{
    public int Number { get; set; }
    public bool? IsEnabled { get; set; }
    public string? Description { get; set; }

    public PortMode.Mode Mode { get; set; }
    

    public Vlan?[] Vlan { get; set; }


    public Port() { }

    public Port(int number, bool? isEnabled = null, string? description = null, Vlan?[] vlan = null)
    {
        Number = number;
        IsEnabled = isEnabled;
        Description = description;
        Vlan = vlan;

    }
}
