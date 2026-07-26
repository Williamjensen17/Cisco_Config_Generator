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
            lblHostname = new Label();
            lblDomainName = new Label();
            txtHostname = new TextBox();
            txtDomainName = new TextBox();
            txtPasswd = new TextBox();
            txtUname = new TextBox();
            lblPasswd = new Label();
            lblUname = new Label();
            txtVtyStart = new TextBox();
            lblVtyStart = new Label();
            txtVtyEnd = new TextBox();
            lblVtyEnd = new Label();
            txtRsaSize = new TextBox();
            lblRsaSize = new Label();
            txtTimeoutMin = new TextBox();
            lblTimeout = new Label();
            lblTimeoutMin = new Label();
            lblTimeoutSec = new Label();
            txtTimeoutSec = new TextBox();
            chkEnableSSH = new CheckBox();
            chkEnableTelnet = new CheckBox();
            chkEnableAAA = new CheckBox();
            SuspendLayout();
            // 
            // lblHostname
            // 
            lblHostname.AutoSize = true;
            lblHostname.Font = new Font("Comic Sans MS", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblHostname.ForeColor = SystemColors.Control;
            lblHostname.Location = new Point(39, 79);
            lblHostname.Name = "lblHostname";
            lblHostname.Size = new Size(70, 18);
            lblHostname.TabIndex = 4;
            lblHostname.Text = "Hostname:";
            // 
            // lblDomainName
            // 
            lblDomainName.AutoSize = true;
            lblDomainName.Font = new Font("Comic Sans MS", 9.75F);
            lblDomainName.ForeColor = SystemColors.Control;
            lblDomainName.Location = new Point(39, 120);
            lblDomainName.Name = "lblDomainName";
            lblDomainName.Size = new Size(93, 18);
            lblDomainName.TabIndex = 5;
            lblDomainName.Text = "Domain-Name:";
            // 
            // txtHostname
            // 
            txtHostname.Location = new Point(156, 78);
            txtHostname.Name = "txtHostname";
            txtHostname.Size = new Size(173, 23);
            txtHostname.TabIndex = 6;
            txtHostname.TextChanged += txtHostname_TextChanged;
            // 
            // txtDomainName
            // 
            txtDomainName.Location = new Point(156, 119);
            txtDomainName.Name = "txtDomainName";
            txtDomainName.Size = new Size(173, 23);
            txtDomainName.TabIndex = 7;
            txtDomainName.TextChanged += txtDomainName_TextChanged;
            // 
            // txtPasswd
            // 
            txtPasswd.Location = new Point(156, 238);
            txtPasswd.Name = "txtPasswd";
            txtPasswd.Size = new Size(173, 23);
            txtPasswd.TabIndex = 11;
            txtPasswd.TextChanged += txtPasswd_TextChanged;
            // 
            // txtUname
            // 
            txtUname.Location = new Point(156, 209);
            txtUname.Name = "txtUname";
            txtUname.Size = new Size(173, 23);
            txtUname.TabIndex = 10;
            txtUname.TextChanged += txtUname_TextChanged;
            // 
            // lblPasswd
            // 
            lblPasswd.AutoSize = true;
            lblPasswd.Font = new Font("Comic Sans MS", 9.75F);
            lblPasswd.ForeColor = SystemColors.Control;
            lblPasswd.Location = new Point(39, 239);
            lblPasswd.Name = "lblPasswd";
            lblPasswd.Size = new Size(65, 18);
            lblPasswd.TabIndex = 9;
            lblPasswd.Text = "Password";
            // 
            // lblUname
            // 
            lblUname.AutoSize = true;
            lblUname.Font = new Font("Comic Sans MS", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUname.ForeColor = SystemColors.Control;
            lblUname.Location = new Point(39, 210);
            lblUname.Name = "lblUname";
            lblUname.Size = new Size(71, 18);
            lblUname.TabIndex = 8;
            lblUname.Text = "Username:";
            // 
            // txtVtyStart
            // 
            txtVtyStart.Location = new Point(156, 291);
            txtVtyStart.Name = "txtVtyStart";
            txtVtyStart.Size = new Size(173, 23);
            txtVtyStart.TabIndex = 14;
            txtVtyStart.Text = "0";
            txtVtyStart.TextChanged += txtVtyStart_TextChanged;
            // 
            // lblVtyStart
            // 
            lblVtyStart.AutoSize = true;
            lblVtyStart.Font = new Font("Comic Sans MS", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblVtyStart.ForeColor = SystemColors.Control;
            lblVtyStart.Location = new Point(39, 292);
            lblVtyStart.Name = "lblVtyStart";
            lblVtyStart.Size = new Size(74, 18);
            lblVtyStart.TabIndex = 12;
            lblVtyStart.Text = "VTY Start:";
            // 
            // txtVtyEnd
            // 
            txtVtyEnd.Location = new Point(156, 320);
            txtVtyEnd.Name = "txtVtyEnd";
            txtVtyEnd.Size = new Size(173, 23);
            txtVtyEnd.TabIndex = 16;
            txtVtyEnd.Text = "15";
            txtVtyEnd.TextChanged += txtVtyEnd_TextChanged;
            // 
            // lblVtyEnd
            // 
            lblVtyEnd.AutoSize = true;
            lblVtyEnd.Font = new Font("Comic Sans MS", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblVtyEnd.ForeColor = SystemColors.Control;
            lblVtyEnd.Location = new Point(39, 321);
            lblVtyEnd.Name = "lblVtyEnd";
            lblVtyEnd.Size = new Size(65, 18);
            lblVtyEnd.TabIndex = 15;
            lblVtyEnd.Text = "VTY End:";
            // 
            // txtRsaSize
            // 
            txtRsaSize.Location = new Point(156, 405);
            txtRsaSize.Name = "txtRsaSize";
            txtRsaSize.Size = new Size(173, 23);
            txtRsaSize.TabIndex = 18;
            txtRsaSize.Text = "2048";
            txtRsaSize.TextChanged += txtRsaSize_TextChanged;
            // 
            // lblRsaSize
            // 
            lblRsaSize.AutoSize = true;
            lblRsaSize.Font = new Font("Comic Sans MS", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRsaSize.ForeColor = SystemColors.Control;
            lblRsaSize.Location = new Point(39, 406);
            lblRsaSize.Name = "lblRsaSize";
            lblRsaSize.Size = new Size(64, 18);
            lblRsaSize.TabIndex = 17;
            lblRsaSize.Text = "Rsa Size:";
            // 
            // txtTimeoutMin
            // 
            txtTimeoutMin.Location = new Point(156, 349);
            txtTimeoutMin.Name = "txtTimeoutMin";
            txtTimeoutMin.Size = new Size(45, 23);
            txtTimeoutMin.TabIndex = 20;
            txtTimeoutMin.Text = "10";
            txtTimeoutMin.TextChanged += txtTimeoutMin_TextChanged;
            // 
            // lblTimeout
            // 
            lblTimeout.AutoSize = true;
            lblTimeout.Font = new Font("Comic Sans MS", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTimeout.ForeColor = SystemColors.Control;
            lblTimeout.Location = new Point(39, 350);
            lblTimeout.Name = "lblTimeout";
            lblTimeout.Size = new Size(56, 18);
            lblTimeout.TabIndex = 19;
            lblTimeout.Text = "Timeout";
            // 
            // lblTimeoutMin
            // 
            lblTimeoutMin.AutoSize = true;
            lblTimeoutMin.Font = new Font("Comic Sans MS", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTimeoutMin.ForeColor = SystemColors.Control;
            lblTimeoutMin.Location = new Point(207, 350);
            lblTimeoutMin.Name = "lblTimeoutMin";
            lblTimeoutMin.Size = new Size(30, 18);
            lblTimeoutMin.TabIndex = 23;
            lblTimeoutMin.Text = "Min";
            // 
            // lblTimeoutSec
            // 
            lblTimeoutSec.AutoSize = true;
            lblTimeoutSec.Font = new Font("Comic Sans MS", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTimeoutSec.ForeColor = SystemColors.Control;
            lblTimeoutSec.Location = new Point(294, 350);
            lblTimeoutSec.Name = "lblTimeoutSec";
            lblTimeoutSec.Size = new Size(31, 18);
            lblTimeoutSec.TabIndex = 24;
            lblTimeoutSec.Text = "Sec";
            // 
            // txtTimeoutSec
            // 
            txtTimeoutSec.Location = new Point(243, 349);
            txtTimeoutSec.Name = "txtTimeoutSec";
            txtTimeoutSec.Size = new Size(45, 23);
            txtTimeoutSec.TabIndex = 25;
            txtTimeoutSec.Text = "0";
            txtTimeoutSec.TextChanged += txtTimeoutSec_TextChanged;
            // 
            // chkEnableSSH
            // 
            chkEnableSSH.AutoSize = true;
            chkEnableSSH.Font = new Font("Comic Sans MS", 9.75F);
            chkEnableSSH.ForeColor = SystemColors.Control;
            chkEnableSSH.Location = new Point(156, 481);
            chkEnableSSH.Name = "chkEnableSSH";
            chkEnableSSH.Size = new Size(100, 22);
            chkEnableSSH.TabIndex = 26;
            chkEnableSSH.Text = "Enable SSH";
            chkEnableSSH.UseVisualStyleBackColor = true;
            // 
            // chkEnableTelnet
            // 
            chkEnableTelnet.AutoSize = true;
            chkEnableTelnet.Font = new Font("Comic Sans MS", 9.75F);
            chkEnableTelnet.ForeColor = SystemColors.Control;
            chkEnableTelnet.Location = new Point(156, 509);
            chkEnableTelnet.Name = "chkEnableTelnet";
            chkEnableTelnet.Size = new Size(111, 22);
            chkEnableTelnet.TabIndex = 27;
            chkEnableTelnet.Text = "Enable Telnet";
            chkEnableTelnet.UseVisualStyleBackColor = true;
            // 
            // chkEnableAAA
            // 
            chkEnableAAA.AutoSize = true;
            chkEnableAAA.Font = new Font("Comic Sans MS", 9.75F);
            chkEnableAAA.ForeColor = SystemColors.Control;
            chkEnableAAA.Location = new Point(156, 453);
            chkEnableAAA.Name = "chkEnableAAA";
            chkEnableAAA.Size = new Size(99, 22);
            chkEnableAAA.TabIndex = 28;
            chkEnableAAA.Text = "Enable AAA";
            chkEnableAAA.UseVisualStyleBackColor = true;
            // 
            // GeneralSettingsControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(46, 51, 73);
            Controls.Add(chkEnableAAA);
            Controls.Add(chkEnableTelnet);
            Controls.Add(chkEnableSSH);
            Controls.Add(txtTimeoutSec);
            Controls.Add(lblTimeoutSec);
            Controls.Add(lblTimeoutMin);
            Controls.Add(txtTimeoutMin);
            Controls.Add(lblTimeout);
            Controls.Add(txtRsaSize);
            Controls.Add(lblRsaSize);
            Controls.Add(txtVtyEnd);
            Controls.Add(lblVtyEnd);
            Controls.Add(txtVtyStart);
            Controls.Add(lblVtyStart);
            Controls.Add(txtPasswd);
            Controls.Add(txtUname);
            Controls.Add(lblPasswd);
            Controls.Add(lblUname);
            Controls.Add(txtDomainName);
            Controls.Add(txtHostname);
            Controls.Add(lblDomainName);
            Controls.Add(lblHostname);
            Name = "GeneralSettingsControl";
            Size = new Size(374, 721);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblHostname;
        private Label lblDomainName;
        private TextBox txtHostname;
        private TextBox txtDomainName;
        private TextBox txtPasswd;
        private TextBox txtUname;
        private Label lblPasswd;
        private Label lblUname;
        private TextBox txtVtyStart;
        private Label lblVtyStart;
        private TextBox txtVtyEnd;
        private Label lblVtyEnd;
        private TextBox txtRsaSize;
        private Label lblRsaSize;
        private TextBox txtTimeoutMin;
        private Label lblTimeout;
        private Label lblTimeoutMin;
        private Label lblTimeoutSec;
        private TextBox txtTimeoutSec;
        private CheckBox chkEnableSSH;
        private CheckBox chkEnableTelnet;
        private CheckBox chkEnableAAA;
    }
}
