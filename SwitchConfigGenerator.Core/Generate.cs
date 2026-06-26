using System.Text;

namespace SwitchConfigGenerator.Core
{
    public class Generate
    {
        public string GenerateConfig()
        {
            var sb = new StringBuilder();
            sb.AppendLine("enable");
            sb.AppendLine("  configure terminal");

            foreach (var port in Variables.Ports)
            {
                bool hasDesc = !string.IsNullOrWhiteSpace(port.Description);

                if (port.IsEnabled == null && !hasDesc) continue;

                sb.AppendLine($"  interface fa0/{port.Number}");

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
