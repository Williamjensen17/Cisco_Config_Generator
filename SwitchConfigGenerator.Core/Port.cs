namespace SwitchConfigGenerator.Core;

public class Port
{
    public int Number { get; set; }
    public bool? IsEnabled { get; set; }
    public string? Description { get; set; }

    public PortMode.Mode Mode { get; set; } = PortMode.Mode.Null;


    public List<Vlan> Vlans { get; set; } = new();


    public Port() { }

    public Port(int number, bool? isEnabled = null, string? description = null, Vlan?[] vlan = null, IEnumerable<Vlan> ? vlans = null)
    {
        Number = number;
        IsEnabled = isEnabled;
        Description = description;
        if (vlans != null)
            Vlans = vlans.ToList();

    }
}
