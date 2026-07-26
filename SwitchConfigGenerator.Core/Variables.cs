using System.Linq;
namespace SwitchConfigGenerator.Core;

public static class Variables
{

    //Basic identity
    public static string? hostname = null;
    public static string? domainname = null;

    //Security settings
    public static string? username = null;
    public static string? password = null;

    public static bool AAAEnabled = false;
    public static bool SSHEnabled = false;
    public static bool TelnetEnabled = false;


    //VTY settings

    public static int vtyStart = 0;
    public static int vtyEnd = 15;

    public static int timeoutMinutes = 10; //in minutes
    public static int timeoutSeconds = 0; //in seconds


    //RSA settings
    public static int rsaSize = 2048;


    //port settings
    public static int? startport = null;
    public static int? endport = null;
    public static int? currentport = null;

    public static bool isGroupPort = false;

    public static int? startGroupPort = null;
    public static int? endGroupPort = null;
    public static int? currentGroupPort = null;

    public static bool isLoading = false;

    public static Port[] Ports = Enumerable.Range(1, 24).Select(i => new Port(i)).ToArray();
    public static GroupPort[] GroupPorts = Enumerable.Range(1, 6).Select(i => new GroupPort(i)).ToArray();
}
