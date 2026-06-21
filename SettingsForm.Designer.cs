namespace SwitchConfigGenerator
{
    partial class SettingsForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelSidebar = new Panel();
            btnVlan = new Button();
            btnGeneral = new Button();
            panelContent = new Panel();
            button1 = new Button();
            panelSidebar.SuspendLayout();
            SuspendLayout();
            // 
            // panelSidebar
            // 
            panelSidebar.BackColor = Color.FromArgb(60, 60, 73);
            panelSidebar.Controls.Add(button1);
            panelSidebar.Controls.Add(btnVlan);
            panelSidebar.Controls.Add(btnGeneral);
            panelSidebar.Location = new Point(0, 0);
            panelSidebar.Name = "panelSidebar";
            panelSidebar.Size = new Size(103, 572);
            panelSidebar.TabIndex = 0;
            // 
            // btnVlan
            // 
            btnVlan.BackColor = Color.FromArgb(60, 60, 74);
            btnVlan.Location = new Point(12, 175);
            btnVlan.Name = "btnVlan";
            btnVlan.Size = new Size(75, 64);
            btnVlan.TabIndex = 1;
            btnVlan.Text = "Vlan";
            btnVlan.UseVisualStyleBackColor = false;
            btnVlan.Click += btnVlan_Click;
            // 
            // btnGeneral
            // 
            btnGeneral.BackColor = Color.FromArgb(60, 60, 74);
            btnGeneral.Location = new Point(12, 65);
            btnGeneral.Name = "btnGeneral";
            btnGeneral.Size = new Size(75, 64);
            btnGeneral.TabIndex = 0;
            btnGeneral.Text = "General";
            btnGeneral.UseVisualStyleBackColor = false;
            btnGeneral.Click += btnGeneral_Click;
            // 
            // panelContent
            // 
            panelContent.AutoScroll = true;
            panelContent.Location = new Point(109, 0);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(387, 572);
            panelContent.TabIndex = 1;
            // 
            // button1
            // 
            button1.BackColor = Color.Red;
            button1.Location = new Point(12, 12);
            button1.Name = "button1";
            button1.Size = new Size(33, 32);
            button1.TabIndex = 0;
            button1.Text = "X";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(495, 571);
            Controls.Add(panelContent);
            Controls.Add(panelSidebar);
            FormBorderStyle = FormBorderStyle.None;
            Name = "SettingsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "SettingsForm";
            Load += SettingsForm_Load;
            panelSidebar.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelSidebar;
        private Panel panelContent;
        private Button btnGeneral;
        private Button btnVlan;
        private Button button1;
    }
}