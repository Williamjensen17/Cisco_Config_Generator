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

        private void txtUname_TextChanged(object sender, EventArgs e)
        {
            Variables.username = txtUname.Text;
        }

        private void txtPasswd_TextChanged(object sender, EventArgs e)
        {
            Variables.password = txtPasswd.Text;
        }

        private void txtVtyStart_TextChanged(object sender, EventArgs e)
        {
            Variables.vtyStart = int.TryParse(txtVtyStart.Text, out int start) ? start : 0;
        }

        private void txtVtyEnd_TextChanged(object sender, EventArgs e)
        {
            Variables.vtyEnd = int.TryParse(txtVtyEnd.Text, out int end) ? end : 15;
        }

        private void txtRsaSize_TextChanged(object sender, EventArgs e)
        {
            Variables.rsaSize = int.TryParse(txtRsaSize.Text, out int size) ? size : 2048;
        }

        private void txtTimeoutMin_TextChanged(object sender, EventArgs e)
        {
            Variables.timeoutMinutes = int.TryParse(txtTimeoutMin.Text, out int minutes) ? minutes : 10;
        }

        private void txtTimeoutSec_TextChanged(object sender, EventArgs e)
        {
            Variables.timeoutSeconds = int.TryParse(txtTimeoutSec.Text, out int seconds) ? seconds : 0;
        }

        private void chkEnableAAA_CheckedChanged(object sender, EventArgs e)
        {
            Variables.AAAEnabled = chkEnableAAA.Checked;
        }

        private void chkEnableSSH_CheckedChanged(object sender, EventArgs e)
        {
            Variables.SSHEnabled = chkEnableSSH.Checked;
        }

        private void chkEnableTelnet_CheckedChanged(object sender, EventArgs e)
        {
            Variables.TelnetEnabled = chkEnableTelnet.Checked;
        }

        private void GeneralSettingsControl_Load(object sender, EventArgs e)
        {
            txtHostname.Text = Variables.hostname ?? "";
            txtDomainName.Text = Variables.domainname ?? "";
            txtUname.Text = Variables.username ?? "";
            txtPasswd.Text = Variables.password ?? "";
            txtVtyStart.Text = Variables.vtyStart.ToString();
            txtVtyEnd.Text = Variables.vtyEnd.ToString();
            txtRsaSize.Text = Variables.rsaSize.ToString();
            txtTimeoutMin.Text = Variables.timeoutMinutes.ToString();
            txtTimeoutSec.Text = Variables.timeoutSeconds.ToString();
            chkEnableAAA.Checked = Variables.AAAEnabled;
            chkEnableSSH.Checked = Variables.SSHEnabled;
            chkEnableTelnet.Checked = Variables.TelnetEnabled;
        }
    }
}
