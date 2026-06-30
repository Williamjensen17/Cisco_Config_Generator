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
    public partial class VlanSettingsControl : UserControl
    {
        public VlanSettingsControl()
        {
            InitializeComponent();
        }

        private void dgvVlans_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string columnName = dgvVlans.Columns[e.ColumnIndex].HeaderText;
            string input = e.FormattedValue?.ToString() ?? "";

            var row = dgvVlans.Rows[e.RowIndex];

            if (columnName == "VlanId")
            {
                if (!int.TryParse(input, out int vlanId) || vlanId < 1 || vlanId > 4094)
                {
                    row.ErrorText = "VLAN ID must be a number from 1 to 4094.";
                    e.Cancel = true;
                    return;
                }

                row.ErrorText = "";

                string vlanName = row.Cells["VlanName"].Value?.ToString();

                if (!string.IsNullOrWhiteSpace(vlanName))
                {
                    Vlan.AddVlan(vlanId, vlanName);
                }
            }
            else if (columnName == "VlanName")
            {
                if (string.IsNullOrWhiteSpace(input))
                {
                    row.ErrorText = "VLAN Name cannot be empty.";
                    e.Cancel = true;
                    return;
                }

                if (input.Contains(" "))
                {
                    row.ErrorText = "VLAN Name cannot contain spaces.";
                    e.Cancel = true;
                    return;
                }

                row.ErrorText = "";

                string vlanIdText = row.Cells["VlanId"].Value?.ToString();
                if (int.TryParse(vlanIdText, out int vlanId))
                {
                    Vlan.AddVlan(vlanId, input);
                }
            }
        }

        private void dgvVlans_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
            e.Cancel = true;
        }

        private void dgvVlans_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
