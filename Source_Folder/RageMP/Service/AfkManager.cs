using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using GTANetworkAPI;

class AfkManager : Script
{
	Timer _afkTimer;

    [ServerEvent(Event.ResourceStart)]
    public void OnResourceStart()
    {
        _afkTimer = new Timer()
		{
			Interval = 15000,
			AutoReset = true
		};
		_afkTimer.Elapsed += _afkTimer_Elapsed;
		_afkTimer.Start();
	}

	//10 Minutes
	private const int KickInterval = 60;
	//9 Minute warning 
	private const int WarningTimer = 54;

	private void _afkTimer_Elapsed(object sender, ElapsedEventArgs e)
	{
        foreach (var player in NAPI.Pools.GetAllPlayers())
        {
                if(player == null)
                    continue;
                var c = player.GetData("status") == true;
                if (c == null)
                    return;
                if (!c.IsCreated)
                    return;

                if (c.LastPos == player.Position)
                {
                    c.AfkTimer++;
                    if (c.AfkTimer == WarningTimer)
                    {
                        NAPI.Notification.SendNotificationToPlayer(player, "~r~[AFK WARNING] Sie werden in einer Minute dafür gekickt, AFK zu sein!");
                    }
                    else if (c.AfkTimer >= KickInterval)
                    {
                        NAPI.Player.KickPlayer(player, "AFK länger als 10 Minuten.");
                    }
                }
                else
                {
                    c.LastPos = player.Position;
                    c.AfkTimer = 0;
                }
        }
	}
}

