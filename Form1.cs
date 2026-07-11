using SwitchConfigGenerator.Core;
using System.ComponentModel.Design.Serialization;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SwitchConfigGenerator;

public partial class ciscoConfigGenerator : Form
{
    //startups
    public ciscoConfigGenerator()
    {
        InitializeComponent();

        //event stuff
        Vlan.VlanAdded += Vlan_VlanAdded;
    }


    private void ciscoConfigGenerator_Load(object sender, EventArgs e)
    {
        DrawForm();
        RefreshVlanList();
    }

    //To avoid memory leaks:
    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        Vlan.VlanAdded -= Vlan_VlanAdded;
        base.OnFormClosed(e);
    }





    //event stuff
    private void Vlan_VlanAdded(Vlan vlan)
    {
        if (InvokeRequired)
        {
            Invoke(new Action(() => Vlan_VlanAdded(vlan)));
            return;
        }

        clbVlans.Items.Add(vlan, true);
    }



    //Fucntions getting called

    private void DrawForm()
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



    private void ShowDescriptionPlaceholder()
    {
        txtDesc.ForeColor = Color.Gray;
        txtDesc.Text = "Port Description";
    }


    private void RefreshVlanList()
    {
        clbVlans.Items.Clear();

        foreach (var vlan in Vlan.Vlans)
        {
            clbVlans.Items.Add(vlan, true);
        }
    }



    //events  that dosent change values, but are used to change the UI
    private void txtDesc_Enter(object sender, EventArgs e)
    {
        if (txtDesc.ForeColor == Color.Gray)
        {
            txtDesc.Text = "";
            txtDesc.ForeColor = Color.Black;
        }
    }




    // buttonclicks

    //When button X is clicked, set current port to X and load settings visually

    private void switchPort_Click(object sender, EventArgs e)
    {
        if (sender is Button btn && int.TryParse(btn.Tag?.ToString(), out int port))
        {
            if (Control.ModifierKeys.HasFlag(Keys.Shift)) LoadSettings(port, true);
            else LoadSettings(port, false);
        }
    }

    //dosent do anything yet, but will be used to submit the config to the switch in the future?
    //autocomplete above, but seems interesting
    private void btnSubmit_Click(object sender, EventArgs e) { }



    //Stripmenu buttons and vlanmenu buttons, will be used to import/export configs in the future, but not yet implemented

    private void btnSettings_Click(object sender, EventArgs e) { SettingsForm settingsForm = new SettingsForm(); settingsForm.ShowDialog(); }
    private void btnFile_Click(object sender, EventArgs e) { fileMenu.Show(btnFile, 0, btnFile.Height); }
    private void importFileToolStripMenuItem_Click(object sender, EventArgs e) { }
    private void exportFileToolStripMenuItem_Click(object sender, EventArgs e) { }


    //button to close the application
    private void btnQuit_Click(object sender, EventArgs e) { Application.Exit(); }




    //events that generate the config and debug output


    private void btnGenConfig_Click(object sender, EventArgs e)
    {
        string prefix = switchPortType.SelectedItem?.ToString()?.Replace("X", "") ?? "Fa0/";
        Generate GenerateClass = new(prefix);
        rtbOutput.Text = GenerateClass.GenerateConfig();
    }

    private void btnDebug_Click(object sender, EventArgs e)
    {
        Debug debug = new();
        rtbOutput.Text = debug.GenerateDebug();


    }



    //loadsettings will load the settings for the port into the UI, and set the current port to the port number passed in, and set the startport or endport depending on if shift is held down or not

    private void LoadSettings(int port, bool startPort)
    {
        if (!startPort)
        {
            Variables.startport = port;
            Variables.endport = null;
        }
        else
        {
            Variables.endport = port;
        }

        Variables.currentport = port;
        Variables.isLoading = true;


        if (port < 1 || port > Variables.Ports.Length)
            return;
        var portData = Variables.Ports[port - 1];

        string startPortVal = Variables.startport.ToString();
        string endPortVal = Variables.endport.ToString();


        //Set the port label to show the start and end port, or just the start port if the end port is null or empty
        if (string.IsNullOrWhiteSpace(endPortVal)) lblPort.Text = "Port: " + startPortVal;
        else lblPort.Text = "Ports: " + startPortVal + " - " + endPortVal;



        if (string.IsNullOrWhiteSpace(portData.Description)) ShowDescriptionPlaceholder();
        else
        {
            txtDesc.Text = portData.Description;
            txtDesc.ForeColor = Color.Black;
        }



        switchPortEnabled.Checked = portData.IsEnabled.GetValueOrDefault();

        rbtnAccess.CheckedChanged -= rbtnAccess_CheckedChanged;
        rbtnTrunk.CheckedChanged -= rbtnTrunk_CheckedChanged;

        rbtnAccess.Checked = portData.Mode == PortMode.Mode.Access;
        rbtnTrunk.Checked = portData.Mode == PortMode.Mode.Trunk;

        rbtnAccess.CheckedChanged += rbtnAccess_CheckedChanged;
        rbtnTrunk.CheckedChanged += rbtnTrunk_CheckedChanged;

        clbVlans.ItemCheck -= clbVlans_ItemCheck;
        for (int i = 0; i < clbVlans.Items.Count; i++)
            clbVlans.SetItemChecked(i, false);

        foreach (var vlan in portData.Vlans)
        {
            for (int i = 0; i < clbVlans.Items.Count; i++)
            {
                if (clbVlans.Items[i] is Vlan listVlan && listVlan.ID == vlan.ID)
                {
                    clbVlans.SetItemChecked(i, true);
                    break;
                }
            }
        }
        clbVlans.ItemCheck += clbVlans_ItemCheck;


        if (rbtnAccess.Checked) { clbVlans.Enabled = true; }
        else if (rbtnTrunk.Checked) { clbVlans.Enabled = true; }
        else { clbVlans.Enabled = false; }

        // Load new checkbox and combobox values
        chkNonegotiate.Checked = portData.NoNegotiate.GetValueOrDefault();
        chkChannelGroup.Checked = portData.IsGrouped.GetValueOrDefault();

        cmbChannelGroup.SelectedIndexChanged -= cmbChannelGroup_SelectedIndexChanged;
        cmbChannelGroup.SelectedItem = portData.GroupID.HasValue ? portData.GroupID.ToString() : null;
        cmbChannelGroup.SelectedIndexChanged += cmbChannelGroup_SelectedIndexChanged;

        Variables.isLoading = false;
    }



    private void clbVlans_ItemCheck(object sender, ItemCheckEventArgs e)
    {
        if (Variables.isLoading)
            return;

        if (clbVlans.Items[e.Index] is not Vlan vlan)
            return;

        foreach (var port in GetTargetPorts())
        {
            if (rbtnAccess.Checked)
            {
                if (e.NewValue == CheckState.Checked)
                {
                    port.Vlans.Clear();
                    port.Vlans.Add(vlan);
                }
                else if (e.NewValue == CheckState.Unchecked)
                {
                    port.Vlans.RemoveAll(v => v.ID == vlan.ID);
                }
            }
            else if (rbtnTrunk.Checked)
            {
                if (e.NewValue == CheckState.Checked)
                {
                    if (!port.Vlans.Any(v => v.ID == vlan.ID))
                        port.Vlans.Add(vlan);
                }
                else if (e.NewValue == CheckState.Unchecked)
                {
                    port.Vlans.RemoveAll(v => v.ID == vlan.ID);
                }
            }
        }
    }



    //Down here is values that are getting changed


    //Buttons vlans

    private void rbtnTrunk_CheckedChanged(object sender, EventArgs e)
    {
        if (Variables.isLoading)
            return;

        if (!rbtnTrunk.Checked)
            return;

        foreach (var port in GetTargetPorts())
        {
            port.Mode = PortMode.Mode.Trunk;
        }

        clbVlans.Enabled = true;
    }

    private void rbtnAccess_CheckedChanged(object sender, EventArgs e)
    {
        if (Variables.isLoading)
            return;

        if (!rbtnAccess.Checked)
            return;

        foreach (var port in GetTargetPorts())
        {
            port.Mode = PortMode.Mode.Access;
            port.Vlans.Clear();
        }

        clbVlans.Enabled = true;
    }

    //Description Textbox Handlers

    private void txtDesc_Leave(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtDesc.Text))
        {
            foreach (var port in GetTargetPorts())
                port.Description = null;
            ShowDescriptionPlaceholder();
        }
    }

    private void txtDesc_TextChanged(object sender, EventArgs e)
    {
        if (Variables.isLoading)
            return;

        if (txtDesc.ForeColor == Color.Gray)
            return;

        foreach (var port in GetTargetPorts())
        {
            port.Description = txtDesc.Text;
        }
    }

    private IEnumerable<Port> GetTargetPorts()
    {
        if (Variables.startport.HasValue && Variables.endport.HasValue)
        {
            int start = Math.Min(Variables.startport.Value, Variables.endport.Value);
            int end = Math.Max(Variables.startport.Value, Variables.endport.Value);

            for (int i = start; i <= end; i++)
                yield return Variables.Ports[i - 1];
        }
        else if (Variables.currentport.HasValue)
        {
            yield return Variables.Ports[Variables.currentport.Value - 1];
        }
    }
    private void switchPortEnabled_CheckedChanged(object sender, EventArgs e)
    {
        if (Variables.isLoading)
            return;

        foreach (var port in GetTargetPorts())
        {
            port.IsEnabled = switchPortEnabled.Checked;
        }
    }

    private void chkNonegotiate_CheckedChanged(object sender, EventArgs e)
    {
        if (Variables.isLoading)
            return;
        foreach (var port in GetTargetPorts())
        {
            port.NoNegotiate = chkNonegotiate.Checked;
        }
    }

    private void chkChannelGroup_CheckedChanged(object sender, EventArgs e)
    {
        if (Variables.isLoading)
            return;
        foreach (var port in GetTargetPorts())
        {
            port.IsGrouped = chkChannelGroup.Checked;
        }
    }

    private void cmbChannelGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Variables.isLoading)
            return;
        if (cmbChannelGroup.SelectedItem == null)
            return;
        foreach (var port in GetTargetPorts())
        {
            port.GroupID = Convert.ToInt32(cmbChannelGroup.SelectedItem);
        }
    }
}
