namespace SwitchConfigGenerator.Core;

public class GroupPort
{
    public int Number { get; set; }
    public bool? IsEnabled { get; set; }
    public string? Description { get; set; }

    //not needed as it will be a group port
    //public bool? IsGrouped { get; set; }
    //not needed as GroupID will be directly correlated to port Number
    //public int? GroupID { get; set; }
    public bool? NoNegotiate { get; set; }

    public PortMode.Mode Mode { get; set; } = PortMode.Mode.Null;


    public List<Vlan> Vlans { get; set; } = new();


    public GroupPort() { }

    public GroupPort(int number, bool? isEnabled = null, bool? isgrouped = null, int? groupid = null, string? description = null, Vlan?[] vlan = null, IEnumerable<Vlan>? vlans = null, bool? nonegotiate = null, int? groupID = null)
    {
        Number = number;
        IsEnabled = isEnabled;
        Description = description;
        //IsGrouped = isgrouped;
        //GroupID = groupid;

        if (vlans != null)
            Vlans = vlans.ToList();
        NoNegotiate = nonegotiate;
    }
}
