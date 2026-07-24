using SwitchConfigGenerator.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SwitchConfigGenerator
{
    public partial class GeneralSettingsControl : UserControl
    {
        public GeneralSettingsControl()
        {
            InitializeComponent();
        }

        private void txtHostname_TextChanged(object sender, EventArgs e)
        {
            Variables.hostname = txtHostname.Text;
        }

        private void txtDomainName_TextChanged(object sender, EventArgs e)
        {
            Variables.domainname = txtDomainName.Text;
        }
    }
}
