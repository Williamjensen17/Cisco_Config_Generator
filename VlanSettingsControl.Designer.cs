namespace SwitchConfigGenerator
{
    partial class VlanSettingsControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvVlans = new DataGridView();
            VlanId = new DataGridViewTextBoxColumn();
            VlanName = new DataGridViewTextBoxColumn();
            ManagementIP = new DataGridViewTextBoxColumn();
            ManagementMask = new DataGridViewTextBoxColumn();
            ManagementEnabled = new DataGridViewCheckBoxColumn();
            DefaultGateway = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvVlans).BeginInit();
            SuspendLayout();
            // 
            // dgvVlans
            // 
            dgvVlans.BackgroundColor = Color.FromArgb(46, 51, 73);
            dgvVlans.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVlans.Columns.AddRange(new DataGridViewColumn[] { VlanId, VlanName, ManagementIP, ManagementMask, ManagementEnabled, DefaultGateway });
            dgvVlans.Location = new Point(12, 12);
            dgvVlans.Name = "dgvVlans";
            dgvVlans.Size = new Size(476, 545);
            dgvVlans.TabIndex = 1;
            dgvVlans.CellContentClick += dgvVlans_CellContentClick;
            dgvVlans.CellValidating += dgvVlans_CellValidating;
            dgvVlans.CellValueChanged += dgvVlans_CellValueChanged;
            dgvVlans.DataError += dgvVlans_DataError;
            // 
            // VlanId
            // 
            VlanId.HeaderText = "ID";
            VlanId.Name = "VlanId";
            VlanId.Width = 40;
            // 
            // VlanName
            // 
            VlanName.HeaderText = "Name";
            VlanName.Name = "VlanName";
            VlanName.Width = 80;
            // 
            // ManagementIP
            // 
            ManagementIP.HeaderText = "Mgmt IP";
            ManagementIP.Name = "ManagementIP";
            ManagementIP.Width = 100;
            // 
            // ManagementMask
            // 
            ManagementMask.HeaderText = "Mask";
            ManagementMask.Name = "ManagementMask";
            ManagementMask.Width = 90;
            // 
            // ManagementEnabled
            // 
            ManagementEnabled.HeaderText = "Up";
            ManagementEnabled.Name = "ManagementEnabled";
            ManagementEnabled.Width = 40;
            // 
            // DefaultGateway
            // 
            DefaultGateway.HeaderText = "Gateway";
            DefaultGateway.Name = "DefaultGateway";
            DefaultGateway.Width = 100;
            // 
            // VlanSettingsControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            Controls.Add(dgvVlans);
            Name = "VlanSettingsControl";
            Size = new Size(500, 569);
            Load += VlanSettingsControl_Load;
            ((System.ComponentModel.ISupportInitialize)dgvVlans).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private DataGridView dgvVlans;
        private DataGridViewTextBoxColumn VlanId;
        private DataGridViewTextBoxColumn VlanName;
        private DataGridViewTextBoxColumn ManagementIP;
        private DataGridViewTextBoxColumn ManagementMask;
        private DataGridViewCheckBoxColumn ManagementEnabled;
        private DataGridViewTextBoxColumn DefaultGateway;
    }
}
