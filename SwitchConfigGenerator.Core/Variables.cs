using System.Linq;
using System.Xml.Linq;
namespace SwitchConfigGenerator.Core;

public static class Variables
{
    public static int? currentport = null;

    public static bool isLoading = false;

    public static Port[] Ports = Enumerable.Range(1, 24).Select(i => new Port(i)).ToArray();
}
