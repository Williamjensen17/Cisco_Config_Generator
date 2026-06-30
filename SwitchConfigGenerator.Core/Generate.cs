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

                if (port.IsEnabled == null && !hasDesc) continue;

                sb.AppendLine($"  interface {_interfacePrefix}{port.Number}");

                if (hasDesc) sb.AppendLine($"    description {port.Description}");

                if (port.IsEnabled != null)
                {
                    sb.AppendLine(port.IsEnabled == true ? "    no shutdown" : "    shutdown");
                }
            }

            return sb.ToString();
        }
    }
}
