using GTANetworkAPI;
using System.Collections.Generic;
using System;

class AntiCheat : Script
{
    public static List<WeaponHash> blacklist = new List<WeaponHash>() { WeaponHash.RPG, WeaponHash.Minigun, WeaponHash.GrenadeLauncher };
    public static int stopInterval = 750;
    private static DateTime Anticheat_DateTime = DateTime.Now.AddMinutes(1); // Beim Serverstart wartet er eine minute!

        public static void onAntiCheatUpdate()
        {
            if(Anticheat_DateTime <= DateTime.Now)
            {
                Anticheat_DateTime.AddSeconds(7);
                foreach (Client player in NAPI.Pools.GetAllPlayers())
                {
                    if (player != null)
                    {
                        if (player.GetData("id") != 0)
                        {
                            player.SetData("update_health", 0);
                            if (player.HasData("update_health") || player.GetData("update_health") != player.Health)
                            {
                            player.SetData("update_health", player.GetData("update_health") - player.Health);
                            player.SetData("update_health", player.Health);
                            }
                            if (player.GetData("update_health") > 0)
                            {
                                player.Health = 0;
                            }

                            if (blacklist.Contains(player.CurrentWeapon))
                            {
                                Main.CreateMySqlCommand("UPDATE users SET banAces = 0 WHERE `id` = " + player.GetData("id") + ";");
                                player.Ban();
                                NAPI.Util.ConsoleOutput("[LOG~w~] ~b~Anti-Cheat ~w~hat ~b~CharName:" + player.GetData("character_name") + " ~b~CharName:" + player.SocialClubName + " ~w~gebannt! | Grund: ~b~Hacking");
                            }
                        }
                    }
                }
            }
        }

        [RemoteEvent("server:antiCheat")]
        public void RemoteEvent_antiCheat(Client player)
        {
            try
            {
                if (player.GetData("id"))
                {
                    Main.CreateMySqlCommand("UPDATE users SET banAces = 0 WHERE `id` = " + player.GetData("id") + ";");
                    player.Ban();
                    NAPI.Util.ConsoleOutput("[LOG~w~] ~b~Anti-Cheat ~w~hat ~b~CharName:" + player.GetData("character_name") + " ~b~CharName:" + player.SocialClubName + " ~w~gebannt! | Grund: ~b~Hacking");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
}
