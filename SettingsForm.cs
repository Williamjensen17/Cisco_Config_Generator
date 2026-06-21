using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SwitchConfigGenerator
{
    public partial class SettingsForm : Form
    {

        private readonly GeneralSettingsControl generalPage = new();
        private readonly VlanSettingsControl vlanPage = new();


        public SettingsForm()
        {
            InitializeComponent();
            panelSidebar.Dock = DockStyle.Left;
            panelContent.Dock = DockStyle.Fill;
        }

        private void btnGeneral_Click(object sender, EventArgs e)
        {
            ShowPage(generalPage);
        }

        private void btnVlan_Click(object sender, EventArgs e)
        {
            ShowPage(vlanPage);
        }

        private void ShowPage(UserControl page)
        {
            panelContent.Controls.Clear();
            page.Dock = DockStyle.Fill;
            panelContent.Controls.Add(page);
        }


        private void SettingsForm_Load(object sender, EventArgs e)
        {
            ShowPage(vlanPage);


            int radius = 20;
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(this.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(this.Width - radius, this.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, this.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();

            this.Region = new Region(path);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
