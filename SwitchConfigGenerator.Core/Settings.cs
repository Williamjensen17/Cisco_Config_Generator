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

        public int? currentport = Variables.currentport;
        private  bool isLoading = Variables.isLoading;

        private bool?[] portActive = Variables.portActive;
        private string?[] portDesc = Variables.portDesc; 


        public (int, bool, string) Load()
        {
            
            isLoading = true;
            bool f2;
            //lblPort.Text = "Port: " + currentport.ToString();

            int f1 = currentport.Value;




            if (currentport != null && portActive[currentport.Value - 1] == true) { f2 = true; }
            else { f2 = false; }


            string? d3 = portDesc[currentport.Value - 1];

            isLoading = false;


            return (f1, f2, d3);
        }




    }
}
