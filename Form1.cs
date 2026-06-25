using System.Diagnostics;
using System.Drawing.Drawing2D;

namespace SwitchConfigGenerator;

public partial class ciscoConfigGenerator : Form
{


    // initialize Variables

    //ints
    int? currentport = null;

    //bools
    bool?[] portActive = new bool?[24];
    bool isLoading = false;

    //strings
    string?[] portDesc = new string?[24];



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

        portActive[currentport.Value - 1] = switchPortEnabled.Checked;
    }



    //Description Textbox Handlers


    private void txtDesc_Leave(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtDesc.Text))
        {
            if (currentport != null) { portDesc[currentport.Value - 1] = null; }

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

        portDesc[currentport.Value - 1] = txtDesc.Text;
    }



    //Fucntions getting called



    private void ShowDescriptionPlaceholder()
    {
        txtDesc.ForeColor = Color.Gray;
        txtDesc.Text = "Port Description";
    }



    private void LoadSettings(int Current)
    {
        currentport = Convert.ToInt32(Current);
        isLoading = true;

        lblPort.Text = "Port: " + currentport.ToString();

        if (currentport != null && portActive[currentport.Value - 1] == true) { switchPortEnabled.Checked = true; }
        else { switchPortEnabled.Checked = false; }

        if (currentport != null)
        {
            string? desc = portDesc[currentport.Value - 1];

            if (string.IsNullOrWhiteSpace(desc)) { ShowDescriptionPlaceholder(); }
            else
            {
                txtDesc.Text = desc;
                txtDesc.ForeColor = Color.Black;
            }
        }
        else { ShowDescriptionPlaceholder(); }

        isLoading = false;
    }


    // buttonclicks

    private void btnDebug_Click(object sender, EventArgs e)
    {
        string output = "";

        for (int i = 0; i < 24; i++)
        {

            //make a string variable, if the port[i] has a value, set activeText to that value, otherwise set to "null"
            string activeText = portActive[i].HasValue ? portActive[i].Value.ToString() : "null";

            //sets the string variable to portDesc if not null
            string descText = portDesc[i] ?? "null";

            //generate the output
            output += $"Port {i}: Active = {activeText}, Desc = {descText}{Environment.NewLine}";
        }

        rtbOutput.Text = output;
    }


    private void btnGenConfig_Click(object sender, EventArgs e)
    {
        var sb = new System.Text.StringBuilder();
        //Add Enable and Configure Terminal to the top of output
        sb.AppendLine("enable");
        sb.AppendLine("  configure terminal");

        for (int i = 0; i < portActive.Length; i++)
        {
            bool hasDesc = !string.IsNullOrWhiteSpace(portDesc[i]);

            if (portActive[i] == null && !hasDesc) { continue; }

            sb.AppendLine($"  interface fa0/{i + 1}");

            if (hasDesc) { sb.AppendLine($"    description {portDesc[i]}"); }

            if (portActive[i] != null)
            {
                sb.AppendLine(portActive[i] == true ? "    no shutdown" : "    shutdown");
            }
        }
        rtbOutput.Text = sb.ToString();
    }





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


}
