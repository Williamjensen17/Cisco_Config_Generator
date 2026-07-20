namespace SwitchConfigGenerator.Core;

public class GroupPort
{
    public int Number { get; set; }
    public bool? IsEnabled { get; set; }
    public string? Description { get; set; }
    public bool? NoNegotiate { get; set; }
    public PortMode.Mode Mode { get; set; } = PortMode.Mode.Null;
    public List<Vlan> Vlans { get; set; } = new();

    public GroupPort() { }

    public GroupPort(int number)
    {
        Number = number;
    }
}
