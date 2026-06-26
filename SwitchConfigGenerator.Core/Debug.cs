using System;

namespace SwitchConfigGenerator.Core
{
    public class Debug
    {
        public string GenerateDebug()
        {
            string output = "";

            foreach (var port in Variables.Ports)
            {
                string activeText = port.IsEnabled.HasValue ? port.IsEnabled.Value.ToString() : "null";
                string descText = port.Description ?? "null";
                output += $"Port {port.Number}: Active = {activeText}, Desc = {descText}{Environment.NewLine}";
            }
            return output;
        }
    }
}
