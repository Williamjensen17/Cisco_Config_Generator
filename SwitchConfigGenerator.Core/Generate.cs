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
            sb.AppendLine("enable");
            sb.AppendLine("  configure terminal");

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
