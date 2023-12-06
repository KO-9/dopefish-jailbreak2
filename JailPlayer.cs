using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dopefish;

public class JailPlayer : DopePlayer
{
    public JailPlayer()
    {
        cashLoaded = false;
        Cash = 0;
    }

}