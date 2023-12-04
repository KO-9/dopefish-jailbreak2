using CounterStrikeSharp.API.Core;

namespace JailbreakPlugin;
public class JailbreakPlugin : BasePlugin
{
    private static JailbreakPlugin _instance;
    public static JailbreakPlugin Instance => _instance;

    public override string ModuleName => "Dopefish Jailbreak plugin";

    public override string ModuleVersion => "0.0.1";

    private EventHooks _eventHooks;

    public override void Load(bool hotReload)
    {
        if (_instance == null) _instance = this;
        Console.WriteLine("Hello World!");

        _eventHooks = new EventHooks(this);
        _eventHooks.Initialize();
    }
}