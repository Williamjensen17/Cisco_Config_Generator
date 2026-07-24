namespace SwitchConfigGenerator
{
    partial class GeneralSettingsControl
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
            lblUC = new Label();
            label1 = new Label();
            label2 = new Label();
            txtHostname = new TextBox();
            txtDomainName = new TextBox();
            SuspendLayout();
            // 
            // lblUC
            // 
            lblUC.AutoSize = true;
            lblUC.Font = new Font("Comic Sans MS", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUC.ForeColor = Color.Red;
            lblUC.Location = new Point(48, 93);
            lblUC.Name = "lblUC";
            lblUC.Size = new Size(283, 29);
            lblUC.TabIndex = 3;
            lblUC.Text = "UNDER CONSTRUCTION!!!";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Comic Sans MS", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(32, 162);
            label1.Name = "label1";
            label1.Size = new Size(70, 18);
            label1.TabIndex = 4;
            label1.Text = "Hostname:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Comic Sans MS", 9.75F);
            label2.ForeColor = SystemColors.Control;
            label2.Location = new Point(32, 222);
            label2.Name = "label2";
            label2.Size = new Size(111, 18);
            label2.TabIndex = 5;
            label2.Text = "IP Domain-Name:";
            // 
            // txtHostname
            // 
            txtHostname.Location = new Point(149, 161);
            txtHostname.Name = "txtHostname";
            txtHostname.Size = new Size(173, 23);
            txtHostname.TabIndex = 6;
            txtHostname.TextChanged += txtHostname_TextChanged;
            // 
            // txtDomainName
            // 
            txtDomainName.Location = new Point(149, 217);
            txtDomainName.Name = "txtDomainName";
            txtDomainName.Size = new Size(173, 23);
            txtDomainName.TabIndex = 7;
            txtDomainName.TextChanged += txtDomainName_TextChanged;
            // 
            // GeneralSettingsControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(txtDomainName);
            Controls.Add(txtHostname);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblUC);
            Name = "GeneralSettingsControl";
            Size = new Size(374, 596);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblUC;
        private Label label1;
        private Label label2;
        private TextBox txtHostname;
        private TextBox txtDomainName;
    }
}
