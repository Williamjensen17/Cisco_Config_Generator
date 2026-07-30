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

            //Basic identity
            sb.AppendLine("!");
            sb.AppendLine("!Setup Basic Identity");
            if (!string.IsNullOrWhiteSpace(Variables.hostname))
            {
                sb.AppendLine("    hostname " + Variables.hostname);
            }
            if (!string.IsNullOrWhiteSpace(Variables.domainname))
            {
                sb.AppendLine("    ip domain-name " + Variables.domainname);
            }

            //AAA configuration
            if (Variables.AAAEnabled)
            {
                sb.AppendLine("!");
                sb.AppendLine("!Setup AAA");
                sb.AppendLine("    aaa new-model");
            }

            //Username and password
            if (!string.IsNullOrWhiteSpace(Variables.username) && !string.IsNullOrWhiteSpace(Variables.password))
            {
                sb.AppendLine("    username " + Variables.username + " privilege 15 password 0 " + Variables.password);
            }

            //RSA key and SSH
            if (Variables.SSHEnabled)
            {
                sb.AppendLine("!");
                sb.AppendLine("!Setup SSH");
                if (!string.IsNullOrWhiteSpace(Variables.domainname))
                {
                    sb.AppendLine("    crypto key generate rsa modulus " + Variables.rsaSize);
                }
                sb.AppendLine("    ip ssh version 2");
            }

            //Here we make the vlans
            sb.AppendLine("!");
            sb.AppendLine("!Setup Vlans");

            foreach (var vlan in Vlan.Vlans)
            {
                sb.AppendLine("    vlan " + vlan.ID);
                sb.AppendLine("    name " + vlan.Name);
            }

            //Management VLAN interface config
            bool hasMgmtVlan = false;
            foreach (var vlan in Vlan.Vlans)
            {
                if (string.IsNullOrWhiteSpace(vlan.ManagementIP)) continue;
                hasMgmtVlan = true;
                break;
            }

            if (hasMgmtVlan)
            {
                sb.AppendLine("!");
                sb.AppendLine("!Setup Management VLAN");

                foreach (var vlan in Vlan.Vlans)
                {
                    if (string.IsNullOrWhiteSpace(vlan.ManagementIP)) continue;

                    sb.AppendLine("  interface vlan " + vlan.ID);
                    sb.AppendLine("    ip address " + vlan.ManagementIP + " " + (vlan.ManagementMask ?? "255.255.255.0"));
                    sb.AppendLine(vlan.ManagementEnabled ? "    no shutdown" : "    shutdown");
                }

                foreach (var vlan in Vlan.Vlans)
                {
                    if (string.IsNullOrWhiteSpace(vlan.DefaultGateway)) continue;
                    sb.AppendLine("  ip default-gateway " + vlan.DefaultGateway);
                    break;
                }
            }

            sb.AppendLine("!");
            sb.AppendLine("!Setup Ports");

            foreach (var port in Variables.Ports)
            {
                bool isGrouped = port.IsGrouped == true && port.GroupID.HasValue;

                bool hasDesc = !string.IsNullOrWhiteSpace(port.Description);
                bool hasEnabled = port.IsEnabled.HasValue;
                bool hasNegotiate = port.NoNegotiate.HasValue;
                bool hasMode = port.Mode != PortMode.Mode.Null;

                // If nothing is configured at all, skip
                if (!hasDesc && !hasNegotiate && !hasMode && !hasEnabled && !isGrouped)
                    continue;

                sb.AppendLine($"  interface {_interfacePrefix}{port.Number}");

                // ✅ If grouped → ONLY generate channel membership
                if (isGrouped)
                {
                    string mode = port.ChannelGroupMode ?? "active";
                    sb.AppendLine($"    channel-group {port.GroupID.Value} mode {mode}");

                    if (hasEnabled)
                        sb.AppendLine(port.IsEnabled == true
                            ? "    no shutdown"
                            : "    shutdown");

                    continue; // 🔥 Skip the rest of the config
                }

                // ✅ Normal (non-grouped) port config below

                if (hasDesc)
                    sb.AppendLine($"    description {port.Description}");

                if (hasEnabled)
                    sb.AppendLine(port.IsEnabled == true
                        ? "    no shutdown"
                        : "    shutdown");

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

                if (hasNegotiate)
                {
                    sb.AppendLine(port.NoNegotiate == true
                        ? "    switchport nonegotiate"
                        : "    no switchport nonegotiate");
                }
            }

            sb.AppendLine("!");
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

            //VTY line configuration
            sb.AppendLine("!");
            sb.AppendLine("!Setup VTY Lines");
            sb.AppendLine("  line vty " + Variables.vtyStart + " " + Variables.vtyEnd);
            sb.AppendLine("    exec-timeout " + Variables.timeoutMinutes + " " + Variables.timeoutSeconds);

            if (!string.IsNullOrWhiteSpace(Variables.username) && !string.IsNullOrWhiteSpace(Variables.password))
            {
                sb.AppendLine("    login local");
            }

            var transportInputs = new List<string>();
            if (Variables.SSHEnabled) transportInputs.Add("ssh");
            if (Variables.TelnetEnabled) transportInputs.Add("telnet");

            if (transportInputs.Count > 0)
            {
                sb.AppendLine("    transport input " + string.Join(" ", transportInputs));
            }

            return sb.ToString();
        }
    }
}
