using System.Linq;
namespace SwitchConfigGenerator.Core;

public static class Variables
{
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
