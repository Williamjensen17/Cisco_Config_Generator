namespace SwitchConfigGenerator.Core;

public class Settings
{
    public Port Load(int port) => Variables.Ports[port - 1];
}
