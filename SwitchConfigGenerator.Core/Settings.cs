using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchConfigGenerator.Core
{
    public class Settings
    {
        private bool?[] portActive = Variables.portActive;
        private string?[] portDesc = Variables.portDesc;

        public (int, bool, string?) Load(int port)
        {
            int f1 = port;
            bool f2 = portActive[port - 1] == true;
            string? d3 = portDesc[port - 1];

            return (f1, f2, d3);
        }
    }
}
