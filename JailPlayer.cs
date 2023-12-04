using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class JailPlayer
{
    public UInt64 SteamID { get; set; }
    public int Cash { get; set; }

    public CCSPlayerController? Player { get; set; }

    public JailPlayer()
    {
        Cash = 0;
    }

    public void load(CCSPlayerController player)
    {
        Player = player;
        SteamID = player.SteamID;
        Cash = 0;
    }

    public void reset()
    {

        // TODO: reset client specific settings
    }

}