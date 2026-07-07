using System.Text;

namespace SwitchConfigGenerator.Core
{
    public class Debug
    {
        public string GenerateDebug()
        {
            var sb = new StringBuilder();

            foreach (var port in Variables.Ports)
            {
                string activeText = port.IsEnabled.HasValue ? port.IsEnabled.Value.ToString() : "null";
                string descText = port.Description ?? "null";
                string modeText = port.Mode.ToString();
                string negotiateText = port.NoNegotiate.HasValue ? port.NoNegotiate.Value.ToString() : "null";
                sb.AppendLine($"Port {port.Number}: Active = {activeText}, Desc = {descText}, Mode = {modeText}, Nonegotiate = {negotiateText}");
            }





            foreach (var vlan in Vlan.Vlans) 
            {
                
                sb.AppendLine(vlan.ToString());
            
            }






            return sb.ToString();
        }
    }
}
