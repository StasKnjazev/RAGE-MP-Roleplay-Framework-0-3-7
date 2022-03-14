using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

class WhitelistManage : Script
{ 
    public WhitelistManage()
    {

    }

    [Command("whitelist")]
    public static void WhiteList(Client player)
    {
        if (AccountManage.GetPlayerAdmin(player) < 2)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben keine Berechtigung, diesen Befehl zu verwenden .");
            return;
        }

        LoadWhiteList(player);
    }

    public static void LoadWhiteList(Client player)
    {
        List<dynamic> menu_item_list = new List<dynamic>();

        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {

            Mainpipeline.Open();
            MySqlCommand query = new MySqlCommand("SELECT * FROM `users` WHERE `betaAcess` = 0 LIMIT 250;", Mainpipeline);

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

        player.TriggerEvent("LoadWhiteList", JsonConvert.SerializeObject(menu_item_list));
    }


    [RemoteEvent("Player_Whitelist_Aprove")]
    public static void Service_Track_Server(Client player, int id)
    {
        InteractMenu_New.SendNotificationSuccess(player, "Benutzer ~g~genehmigt ~w~ erfolgreich!");
        Main.CreateMySqlCommand("UPDATE users SET betaAcess = 1 WHERE `id` = " + id + ";");
        LoadWhiteList(player);
    }

    [RemoteEvent("Player_Whitelist_Remove")]
    public static void Service_Remove_Server(Client player, int id)
    {
        InteractMenu_New.SendNotificationSuccess(player, "Benutzer ~g~ausgeschlossen ~w~ erfolgreich!");
        Main.CreateMySqlCommand("DELETE FROM users WHERE `id` = " + id + ";");
        LoadWhiteList(player);
    }
}

