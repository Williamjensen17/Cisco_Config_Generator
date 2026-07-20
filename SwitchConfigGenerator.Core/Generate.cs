using System.Text;

namespace SwitchConfigGenerator.Core
{
    public class Generate
    {
        private readonly string _interfacePrefix;

        public Generate(string interfacePrefix = "fa0/")
        {
            _interfacePrefix = interfacePrefix;
        }

        public string GenerateConfig()
        {
            var sb = new StringBuilder();

            //enable and enter configuration
            sb.AppendLine("enable");
            sb.AppendLine("  configure terminal");

            //Here we make the vlans
            sb.AppendLine();
            sb.AppendLine("!Initialize Vlans");

            foreach (var vlan in Vlan.Vlans)
            {
                sb.AppendLine("    vlan " + vlan.ID);
                sb.AppendLine("    name " + vlan.Name);
            }


            sb.AppendLine();
            sb.AppendLine("!Setup Ports");

            foreach (var port in Variables.Ports)
            {
                bool hasDesc = !string.IsNullOrWhiteSpace(port.Description);
                bool hasEnabled = port.IsEnabled.HasValue;
                bool hasNegotiate = port.NoNegotiate.HasValue;
                bool hasMode = port.Mode != PortMode.Mode.Null;
                bool hasGroup = port.IsGrouped.HasValue;
                bool hasGroupID = port.GroupID.HasValue;

                //when ready, add this back to the if statement
                //&& !hasGroup && !hasGroupID
                if (!hasDesc && !hasNegotiate && !hasMode && !hasEnabled ) continue;

                sb.AppendLine($"  interface {_interfacePrefix}{port.Number}");

                if (hasDesc)
                    sb.AppendLine($"    description {port.Description}");

                if (hasEnabled)
                    sb.AppendLine(port.IsEnabled == true ? "    no shutdown" : "    shutdown");

                if (port.Mode == PortMode.Mode.Access)
                {
                    sb.AppendLine("    switchport mode access");

                    if (port.Vlans.Count > 0)
                        sb.AppendLine($"    switchport access vlan {port.Vlans[0].ID}");
                }
                else if (port.Mode == PortMode.Mode.Trunk)
                {
                    sb.AppendLine("    switchport mode trunk");

                    if (port.Vlans.Count > 0)
                    {
                        var vlanIds = string.Join(",", port.Vlans.Select(v => v.ID));
                        sb.AppendLine($"    switchport trunk allowed vlan {vlanIds}");
                    }
                }

                if (port.IsGrouped == true && port.GroupID.HasValue)
                {
                    string mode = port.ChannelGroupMode ?? "active";
                    sb.AppendLine($"    channel-group {port.GroupID.Value} mode {mode}");
                }



                if (hasNegotiate)
                {
                    sb.AppendLine(port.NoNegotiate == true ? "    switchport nonegotiate" : "    no switchport nonegotiate");
                }
            }

            sb.AppendLine();
            sb.AppendLine("!Setup Port-Channels");

            foreach (var groupPort in Variables.GroupPorts)
            {
                bool hasDesc = !string.IsNullOrWhiteSpace(groupPort.Description);
                bool hasEnabled = groupPort.IsEnabled.HasValue;
                bool hasNegotiate = groupPort.NoNegotiate.HasValue;
                bool hasMode = groupPort.Mode != PortMode.Mode.Null;

                if (!hasDesc && !hasNegotiate && !hasMode && !hasEnabled) continue;

                sb.AppendLine($"  interface Port-channel {groupPort.Number}");

                if (hasDesc)
                    sb.AppendLine($"    description {groupPort.Description}");

                if (hasEnabled)
                    sb.AppendLine(groupPort.IsEnabled == true ? "    no shutdown" : "    shutdown");

                if (groupPort.Mode == PortMode.Mode.Access)
                {
                    sb.AppendLine("    switchport mode access");

                    if (groupPort.Vlans.Count > 0)
                        sb.AppendLine($"    switchport access vlan {groupPort.Vlans[0].ID}");
                }
                else if (groupPort.Mode == PortMode.Mode.Trunk)
                {
                    sb.AppendLine("    switchport mode trunk");

                    if (groupPort.Vlans.Count > 0)
                    {
                        var vlanIds = string.Join(",", groupPort.Vlans.Select(v => v.ID));
                        sb.AppendLine($"    switchport trunk allowed vlan {vlanIds}");
                    }
                }

                if (hasNegotiate)
                {
                    sb.AppendLine(groupPort.NoNegotiate == true ? "    switchport nonegotiate" : "    no switchport nonegotiate");
                }
            }

            return sb.ToString();
        }
    }
}
