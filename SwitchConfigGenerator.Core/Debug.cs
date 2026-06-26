using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchConfigGenerator.Core
{
    public class Debug()
    {
        private bool?[] portActive = Variables.portActive;
        private string?[] portDesc = Variables.portDesc;

        public string GenerateDebug()
        {
            string output = "";

            for (int i = 0; i < 24; i++)
            {

                //make a string variable, if the port[i] has a value, set activeText to that value, otherwise set to "null"
                string activeText = portActive[i].HasValue ? portActive[i].Value.ToString() : "null";

                //sets the string variable to portDesc if not null
                string descText = portDesc[i] ?? "null";

                //generate the output
                output += $"Port {i}: Active = {activeText}, Desc = {descText}{Environment.NewLine}";
            }
            return output;
        }

    }
}
