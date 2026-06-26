using System.ComponentModel.Design.Serialization;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using SwitchConfigGenerator.Core;

namespace SwitchConfigGenerator;

public partial class ciscoConfigGenerator : Form
{

    public bool isLoading = Variables.isLoading;
    public int? currentport = Variables.currentport;
    public Port[] ports = Variables.Ports;



    //startups
    public ciscoConfigGenerator()
    {
        InitializeComponent();
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


    //Checkbox Handler
    private void switchPortEnabled_CheckedChanged(object sender, EventArgs e)
    {
        if (isLoading || currentport == null)
            return;

        ports[currentport.Value - 1].IsEnabled = switchPortEnabled.Checked;
    }



    //Description Textbox Handlers


    private void txtDesc_Leave(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtDesc.Text))
        {
            if (currentport != null) { ports[currentport.Value - 1].Description = null; }

            ShowDescriptionPlaceholder();
        }
    }

    private void txtDesc_Enter(object sender, EventArgs e)
    {
        if (txtDesc.ForeColor == Color.Gray)
        {
            txtDesc.Text = "";
            txtDesc.ForeColor = Color.Black;
        }
    }

    private void txtDesc_TextChanged(object sender, EventArgs e)
    {
        if (isLoading || currentport == null)
            return;

        if (txtDesc.ForeColor == Color.Gray)
            return;

        ports[currentport.Value - 1].Description = txtDesc.Text;
    }








    //Down her works ()i hope
    //Fucntions getting called



    private void ShowDescriptionPlaceholder()
    {
        txtDesc.ForeColor = Color.Gray;
        txtDesc.Text = "Port Description";
    }

    




    // buttonclicks

    //When button X is clicked, set current port to X and load settings visually

    private void switchPort_01_Click(object sender, EventArgs e) { LoadSettings(1); }
    private void switchPort_02_Click(object sender, EventArgs e) { LoadSettings(2); }
    private void switchPort_03_Click(object sender, EventArgs e) { LoadSettings(3); }
    private void switchPort_04_Click(object sender, EventArgs e) { LoadSettings(4); }
    private void switchPort_05_Click(object sender, EventArgs e) { LoadSettings(5); }
    private void switchPort_06_Click(object sender, EventArgs e) { LoadSettings(6); }
    private void switchPort_07_Click(object sender, EventArgs e) { LoadSettings(7); }
    private void switchPort_08_Click(object sender, EventArgs e) { LoadSettings(8); }
    private void switchPort_09_Click(object sender, EventArgs e) { LoadSettings(9); }
    private void switchPort_10_Click(object sender, EventArgs e) { LoadSettings(10); }
    private void switchPort_11_Click(object sender, EventArgs e) { LoadSettings(11); }
    private void switchPort_12_Click(object sender, EventArgs e) { LoadSettings(12); }
    private void switchPort_13_Click(object sender, EventArgs e) { LoadSettings(13); }
    private void switchPort_14_Click(object sender, EventArgs e) { LoadSettings(14); }
    private void switchPort_15_Click(object sender, EventArgs e) { LoadSettings(15); }
    private void switchPort_16_Click(object sender, EventArgs e) { LoadSettings(16); }
    private void switchPort_17_Click(object sender, EventArgs e) { LoadSettings(17); }
    private void switchPort_18_Click(object sender, EventArgs e) { LoadSettings(18); }
    private void switchPort_19_Click(object sender, EventArgs e) { LoadSettings(19); }
    private void switchPort_20_Click(object sender, EventArgs e) { LoadSettings(20); }
    private void switchPort_21_Click(object sender, EventArgs e) { LoadSettings(21); }
    private void switchPort_22_Click(object sender, EventArgs e) { LoadSettings(22); }
    private void switchPort_23_Click(object sender, EventArgs e) { LoadSettings(23); }
    private void switchPort_24_Click(object sender, EventArgs e) { LoadSettings(24); }


    //Rest of button clicks

    private void btnSubmit_Click(object sender, EventArgs e) { }



    private void btnSettings_Click(object sender, EventArgs e) { SettingsForm settingsForm = new SettingsForm(); settingsForm.ShowDialog(); }
    private void btnFile_Click(object sender, EventArgs e) { fileMenu.Show(btnFile, 0, btnFile.Height); }
    private void importFileToolStripMenuItem_Click(object sender, EventArgs e) { }
    private void exportFileToolStripMenuItem_Click(object sender, EventArgs e) { }


    private void btnQuit_Click(object sender, EventArgs e) { Application.Exit(); }





    private void btnGenConfig_Click(object sender, EventArgs e)
    {
        Generate GenerateClass = new();
        rtbOutput.Text = GenerateClass.GenerateConfig();
    }

    private void btnDebug_Click(object sender, EventArgs e)
    {
        Debug debug = new();
        rtbOutput.Text = debug.GenerateDebug();
    }

    private void LoadSettings(int port)
    {
        currentport = port;
        Variables.currentport = port;
        isLoading = true;

        Settings settings = new();
        Port portData = settings.Load(port);

        lblPort.Text = "Port: " + portData.Number;

        if (string.IsNullOrWhiteSpace(portData.Description)) { ShowDescriptionPlaceholder(); }
        else
        {
            txtDesc.Text = portData.Description;
            txtDesc.ForeColor = Color.Black;
        }
        switchPortEnabled.Checked = portData.IsEnabled == true;

        isLoading = false;
    }
}
