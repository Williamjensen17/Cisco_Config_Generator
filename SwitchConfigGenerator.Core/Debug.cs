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
                string channelGroupActive = port.IsGrouped.HasValue ? port.IsGrouped.Value.ToString() : "null";
                string channelGroupId = port.GroupID.HasValue ? port.GroupID.Value.ToString() : "null";
                sb.AppendLine($"Port {port.Number}: Active = {activeText}, Desc = {descText}, Mode = {modeText}, Nonegotiate = {negotiateText}, CG A = {channelGroupActive}, CG ID {channelGroupId}");
            }





            foreach (var vlan in Vlan.Vlans) 
            {
                
                sb.AppendLine(vlan.ToString());
            
            }






            return sb.ToString();
        }
    }
}
