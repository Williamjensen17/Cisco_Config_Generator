using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SwitchConfigGenerator.Core
{
    public class Generate
    {
        private bool?[] portActive = Variables.portActive;
        private string?[] portDesc = Variables.portDesc;
        public string GenerateConfig()
        {
            var sb = new System.Text.StringBuilder();
            //Add Enable and Configure Terminal to the top of output
            sb.AppendLine("enable");
            sb.AppendLine("  configure terminal");

            for (int i = 0; i < portActive.Length; i++)
            {
                bool hasDesc = !string.IsNullOrWhiteSpace(portDesc[i]);

                if (portActive[i] == null && !hasDesc) { continue; }

                sb.AppendLine($"  interface fa0/{i + 1}");

                if (hasDesc) { sb.AppendLine($"    description {portDesc[i]}"); }

                if (portActive[i] != null)
                {
                    sb.AppendLine(portActive[i] == true ? "    no shutdown" : "    shutdown");
                }
            }
            return sb.ToString();

        }






    }
}
