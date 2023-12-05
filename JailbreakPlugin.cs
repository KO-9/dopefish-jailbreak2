using CounterStrikeSharp.API.Core;

namespace JailbreakPlugin;
public class JailbreakPlugin : BasePlugin
{
    private static JailbreakPlugin _instance;
    public static JailbreakPlugin Instance => _instance;

    public override string ModuleName => "Dopefish Jailbreak plugin";

    public override string ModuleVersion => "0.0.1";

    public Database _db;
    private EventHooks _eventHooks;
    public JailCore _jailCore;
    public DopeMenu _dopeMenu;

    public override void Load(bool hotReload)
    {
        base.Load(hotReload);

        if (_instance == null) _instance = this;
        Console.WriteLine("Plugin loaded");

        _db = new Database(this);
        _db.Initialize();
        
        _eventHooks = new EventHooks(this, _db);
        _eventHooks.Initialize();

        _jailCore = new JailCore(this);
        _jailCore.Initialize();
        
        _dopeMenu = new DopeMenu(this);
        _dopeMenu.Initialize();
    }
}