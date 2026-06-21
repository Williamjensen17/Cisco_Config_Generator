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
            // GeneralSettingsControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblUC);
            Name = "GeneralSettingsControl";
            Size = new Size(374, 596);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblUC;
    }
}
