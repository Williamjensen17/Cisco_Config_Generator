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
            lblUC = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvVlans).BeginInit();
            SuspendLayout();
            // 
            // dgvVlans
            // 
            dgvVlans.BackgroundColor = Color.FromArgb(46, 51, 73);
            dgvVlans.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVlans.Columns.AddRange(new DataGridViewColumn[] { VlanId, VlanName });
            dgvVlans.Location = new Point(62, 165);
            dgvVlans.Name = "dgvVlans";
            dgvVlans.Size = new Size(244, 354);
            dgvVlans.TabIndex = 1;
            dgvVlans.CellValidating += dgvVlans_CellValidating;
            dgvVlans.DataError += dgvVlans_DataError;
            // 
            // VlanId
            // 
            VlanId.HeaderText = "VlanId";
            VlanId.Name = "VlanId";
            // 
            // VlanName
            // 
            VlanName.HeaderText = "VlanName";
            VlanName.Name = "VlanName";
            // 
            // lblUC
            // 
            lblUC.AutoSize = true;
            lblUC.Font = new Font("Comic Sans MS", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUC.ForeColor = Color.Red;
            lblUC.Location = new Point(48, 93);
            lblUC.Name = "lblUC";
            lblUC.Size = new Size(283, 29);
            lblUC.TabIndex = 2;
            lblUC.Text = "UNDER CONSTRUCTION!!!";
            // 
            // VlanSettingsControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblUC);
            Controls.Add(dgvVlans);
            Name = "VlanSettingsControl";
            Size = new Size(371, 569);
            ((System.ComponentModel.ISupportInitialize)dgvVlans).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dgvVlans;
        private Label lblUC;
        private DataGridViewTextBoxColumn VlanId;
        private DataGridViewTextBoxColumn VlanName;
    }
}
