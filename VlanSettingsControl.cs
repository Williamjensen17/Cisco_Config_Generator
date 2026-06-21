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
            string columnName = dgvVlans.Columns[e.ColumnIndex].Name;
            string input = e.FormattedValue?.ToString() ?? "";

            if (columnName == "VlanId")
            {
                if (!int.TryParse(input, out int vlanId) || vlanId < 1 || vlanId > 4094)
                {
                    dgvVlans.Rows[e.RowIndex].ErrorText =
                        "VLAN ID must be a number from 1 to 4094.";
                    e.Cancel = true;
                }
                else
                {
                    dgvVlans.Rows[e.RowIndex].ErrorText = "";
                }
            }
            else if (columnName == "VlanName")
            {
                if (string.IsNullOrWhiteSpace(input))
                {
                    dgvVlans.Rows[e.RowIndex].ErrorText = "VLAN Name cannot be empty.";
                    e.Cancel = true;
                }
                else if (input.Contains(" "))
                {
                    dgvVlans.Rows[e.RowIndex].ErrorText = "VLAN Name cannot contain spaces.";
                    e.Cancel = true;
                }
                else
                {
                    dgvVlans.Rows[e.RowIndex].ErrorText = "";
                }
            }
        }

        private void dgvVlans_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
            e.Cancel = true;
        }
    }
}
