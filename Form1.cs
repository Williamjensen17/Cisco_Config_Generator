using System.Diagnostics;
using System.Drawing.Drawing2D;

namespace SwitchConfigGenerator;

public partial class ciscoConfigGenerator : Form
{

    int? currentport = null;

    bool?[] portActive = new bool?[24];

    string?[] portDesc = new string?[24];

    public ciscoConfigGenerator()
    {
        InitializeComponent();
    }

    bool isLoading = false;

    private void LoadSettings()
    {
        isLoading = true;

        lblPort.Text = "Port: " + currentport.ToString();

        if (currentport != null && portActive[currentport.Value - 1] == true)
        {
            switchPortEnabled.Checked = true;
        }
        else
        {
            switchPortEnabled.Checked = false;
        }

        if (currentport != null)
        {
            string? desc = portDesc[currentport.Value - 1];

            if (string.IsNullOrWhiteSpace(desc))
            {
                ShowDescriptionPlaceholder();
            }
            else
            {
                txtDesc.Text = desc;
                txtDesc.ForeColor = Color.Black;
            }
        }
        else
        {
            ShowDescriptionPlaceholder();
        }

        isLoading = false;
    }

    private void txtDesc_TextChanged(object sender, EventArgs e)
    {
        if (isLoading || currentport == null)
            return;

        if (txtDesc.ForeColor == Color.Gray)
            return;

        portDesc[currentport.Value - 1] = txtDesc.Text;
    }
    private void ShowDescriptionPlaceholder()
    {
        txtDesc.Text = "Port Description";
        txtDesc.ForeColor = Color.Gray;
    }

    private void switchPortEnabled_CheckedChanged(object sender, EventArgs e)
    {
        if (currentport == null)
            return;
        portActive[currentport.Value - 1] = switchPortEnabled.Checked;
    }

    private void btnDebug_Click(object sender, EventArgs e)
    {
        string output = "";

        for (int i = 0; i < 24; i++)
        {
            string activeText = portActive[i].HasValue
                ? portActive[i].Value.ToString()
                : "null";

            string descText = portDesc[i] ?? "null";

            output += $"Port {i}: Active = {activeText}, Desc = {descText}{Environment.NewLine}";
        }

        rtbOutput.Text = output;
    }


    private void txtDesc_Leave(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtDesc.Text))
        {
            if (currentport != null)
                portDesc[currentport.Value - 1] = null;

            ShowDescriptionPlaceholder();
        }
    }
    private void ciscoConfigGenerator_Load(object sender, EventArgs e)
    {
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

    private void btnGenConfig_Click(object sender, EventArgs e)
    {
        var sb = new System.Text.StringBuilder();
        //Add Enable and Configure Terminal to the top of output
        sb.AppendLine("enable");
        sb.AppendLine("  configure terminal");

        for (int i = 0; i < portActive.Length; i++)
        {
            if (portActive[i] == null)
                continue;

            sb.AppendLine($"  interface fa0/{i + 1}");
            sb.AppendLine(portActive[i] == true ? "    no shutdown" : "    shutdown");
        }
        rtbOutput.Text = sb.ToString();
    }


    //When button X is clicked, set current port to X and load settings visually

    private void switchPort_01_Click(object sender, EventArgs e) { currentport = 1; LoadSettings(); }
    private void switchPort_02_Click(object sender, EventArgs e) { currentport = 2; LoadSettings(); }
    private void switchPort_03_Click(object sender, EventArgs e) { currentport = 3; LoadSettings(); }
    private void switchPort_04_Click(object sender, EventArgs e) { currentport = 4; LoadSettings(); }
    private void switchPort_05_Click(object sender, EventArgs e) { currentport = 5; LoadSettings(); }
    private void switchPort_06_Click(object sender, EventArgs e) { currentport = 6; LoadSettings(); }
    private void switchPort_07_Click(object sender, EventArgs e) { currentport = 7; LoadSettings(); }
    private void switchPort_08_Click(object sender, EventArgs e) { currentport = 8; LoadSettings(); }
    private void switchPort_09_Click(object sender, EventArgs e) { currentport = 9; LoadSettings(); }
    private void switchPort_10_Click(object sender, EventArgs e) { currentport = 10; LoadSettings(); }
    private void switchPort_11_Click(object sender, EventArgs e) { currentport = 11; LoadSettings(); }
    private void switchPort_12_Click(object sender, EventArgs e) { currentport = 12; LoadSettings(); }
    private void switchPort_13_Click(object sender, EventArgs e) { currentport = 13; LoadSettings(); }
    private void switchPort_14_Click(object sender, EventArgs e) { currentport = 14; LoadSettings(); }
    private void switchPort_15_Click(object sender, EventArgs e) { currentport = 15; LoadSettings(); }
    private void switchPort_16_Click(object sender, EventArgs e) { currentport = 16; LoadSettings(); }
    private void switchPort_17_Click(object sender, EventArgs e) { currentport = 17; LoadSettings(); }
    private void switchPort_18_Click(object sender, EventArgs e) { currentport = 18; LoadSettings(); }
    private void switchPort_19_Click(object sender, EventArgs e) { currentport = 19; LoadSettings(); }
    private void switchPort_20_Click(object sender, EventArgs e) { currentport = 20; LoadSettings(); }
    private void switchPort_21_Click(object sender, EventArgs e) { currentport = 21; LoadSettings(); }
    private void switchPort_22_Click(object sender, EventArgs e) { currentport = 22; LoadSettings(); }
    private void switchPort_23_Click(object sender, EventArgs e) { currentport = 23; LoadSettings(); }
    private void switchPort_24_Click(object sender, EventArgs e) { currentport = 24; LoadSettings(); }

    private void btnSubmit_Click(object sender, EventArgs e) { }

    private void btnFile_Click(object sender, EventArgs e) { fileMenu.Show(btnFile, 0, btnFile.Height); }

    private void btnSettings_Click(object sender, EventArgs e) { SettingsForm settingsForm = new SettingsForm(); settingsForm.ShowDialog(); }

    private void importFileToolStripMenuItem_Click(object sender, EventArgs e) { }
    private void exportFileToolStripMenuItem_Click(object sender, EventArgs e) { }

    private void button1_Click(object sender, EventArgs e) { Application.Exit(); }

    private void txtDesc_Enter(object sender, EventArgs e)
    {
        if (txtDesc.ForeColor == Color.Gray)
        {
            txtDesc.Text = "";
            txtDesc.ForeColor = Color.Black;
        }
    }
}
