using GTANetworkAPI;
using System.Collections.Generic;

class PingCheck : Script
{
    public List<Client> Warned { get; set; }

    static class EData
    {
        public delegate void TimeElapsed();

        public static TimeElapsed Every1Seconds;
        public static TimeElapsed Every10Seconds;
        public static TimeElapsed Every30Seconds;
        public static TimeElapsed Every60Seconds;
        public static TimeElapsed Every1Hours;
    }

    [ServerEvent(Event.ResourceStart)]
    public void OnResourceStart()
    {
        EData.Every10Seconds += CheckPing;
        Warned = new List<Client>();
        NAPI.Task.Run(() =>
        {
            CheckPing();
        }, delayTime: 10000);
    }

    public void CheckPing()
    {
        var player = NAPI.Pools.GetAllPlayers();

        foreach(Client c in player)
        {
            if(c.Ping > 55)
            {
                if(Warned.Contains(c))
                {
                    c.Kick($"Dein Ping liegt bei ({c.Ping}~w~) und ist daher zu hoch!");
                    Warned.Remove(c);
                }
                else
                {
                    Main.SendErrorMessage(c, $"Dein Ping liegt bei ({c.Ping}~w~) und ist daher zu hoch!");
                    Warned.Add(c);
                }
            }
            else
            {
                if (Warned.Contains(c))
                Warned.Remove(c);
            }
        }
    }
}