using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

class BannedManage : Script
{ 
    public BannedManage()
    {

    }

    [Command("adbanned")]
    public static void Banned(Client player)
    {
        if (AccountManage.GetPlayerAdmin(player) < 2)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben keine Berechtigung, diesen Befehl zu verwenden .");
            return;
        }

        Bannedlist(player);
    }

    public static void Bannedlist(Client player)
    {
        List<dynamic> menu_item_list = new List<dynamic>();

        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {

            Mainpipeline.Open();
            MySqlCommand query = new MySqlCommand("SELECT * FROM `users` WHERE `banAces` = 1 LIMIT 250;", Mainpipeline);

            using (MySqlDataReader reader = query.ExecuteReader())
            {
                string data2txt = string.Empty;
                string datatxt = string.Empty;

                while (reader.Read())
                {
                    if(reader.GetString("username").Length != 0) menu_item_list.Add(new { Index = reader.GetInt32("id"), Name = reader.GetString("username"), SocialName = reader.GetString("socialclubname") });
                }
            }
        }

        player.TriggerEvent("LoadBannedlist", JsonConvert.SerializeObject(menu_item_list));
    }

    [RemoteEvent("Player_Bannedlist_Aprove")]
    public static void Service_Track_Server(Client player, int id)
    {
        InteractMenu_New.SendNotificationSuccess(player, "Benutzer ~w~erfolgreich ~g~gebannt!");
        Main.CreateMySqlCommand("UPDATE users SET banAces = 0 WHERE `id` = " + id + ";");
        Bannedlist(player);
    }

    [RemoteEvent("Player_Bannedlist_Remove")]
    public static void Service_Remove_Server(Client player, int id)
    {
        InteractMenu_New.SendNotificationSuccess(player, "Benutzer ~w~erfolgreich ~g~entbannt!");
        Main.CreateMySqlCommand("DELETE FROM users WHERE `id` = " + id + ";");
        Bannedlist(player);
    }
}

