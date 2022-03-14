using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Data;
using System.IO;
using GTANetworkAPI;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

class UsefullyRP : Script
{
    public static List<dynamic> mask_list = new List<dynamic>();
    public static List<dynamic> helmet_list = new List<dynamic>();

    public static bool[] seatbelt { get; set; } = new bool[Main.MAX_PLAYERS];
    public static bool[] mask { get; set; } = new bool[Main.MAX_PLAYERS];

    public static bool[] charclothes { get; set; } = new bool[Main.MAX_PLAYERS];

    public UsefullyRP()
    {
        mask_list.Add(new { Name = "Maske 1", variation = 1, texture = 0, price = 450 });
        mask_list.Add(new { Name = "Maske 5", variation = 2, texture = 0, price = 450 });
        mask_list.Add(new { Name = "Maske 9", variation = 3, texture = 0, price = 450 });
        mask_list.Add(new { Name = "Maske 13", variation = 5, texture = 3, price = 450 });
        mask_list.Add(new { Name = "Maske 68", variation = 17, texture = 1, price = 450 });
        mask_list.Add(new { Name = "Maske 69", variation = 18, texture = 0, price = 450 });
        mask_list.Add(new { Name = "Maske 71", variation = 19, texture = 0, price = 450 });


        mask_list.Add(new { Name = "Maske 73", variation = 20, texture = 0, price = 450 });
        mask_list.Add(new { Name = "Maske 74", variation = 20, texture = 1, price = 450 });

        mask_list.Add(new { Name = "Maske 75", variation = 21, texture = 0, price = 450 });
        mask_list.Add(new { Name = "Maske 76", variation = 21, texture = 1, price = 450 });

        mask_list.Add(new { Name = "Maske 77", variation = 22, texture = 0, price = 450 });
        mask_list.Add(new { Name = "Maske 78", variation = 22, texture = 1, price = 450 });

        mask_list.Add(new { Name = "Maske 79", variation = 23, texture = 0, price = 450 });
        mask_list.Add(new { Name = "Maske 80", variation = 23, texture = 1, price = 450 });

        mask_list.Add(new { Name = "Maske 81", variation = 24, texture = 0, price = 450 });
        mask_list.Add(new { Name = "Maske 82", variation = 24, texture = 1, price = 450 });

        mask_list.Add(new { Name = "Maske 83", variation = 25, texture = 0, price = 450 });
        mask_list.Add(new { Name = "Maske 84", variation = 25, texture = 1, price = 450 });

        mask_list.Add(new { Name = "Maske 85", variation = 26, texture = 0, price = 450 });
        mask_list.Add(new { Name = "Maske 86", variation = 26, texture = 1, price = 450 });



        mask_list.Add(new { Name = "Maske 88", variation = 28, texture = 0, price = 450 });
        mask_list.Add(new { Name = "Maske 89", variation = 28, texture = 1, price = 450 });
        mask_list.Add(new { Name = "Maske 90", variation = 28, texture = 2, price = 450 });
        mask_list.Add(new { Name = "Maske 91", variation = 28, texture = 3, price = 450 });
        mask_list.Add(new { Name = "Maske 92", variation = 28, texture = 4, price = 450 });
           

        mask_list.Add(new { Name = "Maske 98", variation = 30, texture = 0, price = 450 });

        mask_list.Add(new { Name = "Maske 99", variation = 31, texture = 0, price = 450 });

        mask_list.Add(new { Name = "Maske 100", variation = 32, texture = 0, price = 450 });

        mask_list.Add(new { Name = "Maske 101", variation = 33, texture = 0, price = 450 });

        mask_list.Add(new { Name = "Maske 102", variation = 34, texture = 0, price = 450 });
        mask_list.Add(new { Name = "Maske 103", variation = 34, texture = 1, price = 450 });
        mask_list.Add(new { Name = "Maske 104", variation = 34, texture = 2, price = 450 });


        mask_list.Add(new { Name = "Maske 107", variation = 37, texture = 0, price = 450 });

        mask_list.Add(new { Name = "Maske 108", variation = 39, texture = 0, price = 450 });
        mask_list.Add(new { Name = "Maske 109", variation = 39, texture = 1, price = 450 });

        mask_list.Add(new { Name = "Maske 110", variation = 40, texture = 0, price = 450 });
        mask_list.Add(new { Name = "Maske 111", variation = 40, texture = 1, price = 450 });

        mask_list.Add(new { Name = "Maske 112", variation = 41, texture = 0, price = 450 });
        mask_list.Add(new { Name = "Maske 113", variation = 41, texture = 1, price = 450 });

        mask_list.Add(new { Name = "Maske 114", variation = 42, texture = 0, price = 450 });
        mask_list.Add(new { Name = "Maske 115", variation = 42, texture = 1, price = 450 });

        mask_list.Add(new { Name = "Maske 116", variation = 43, texture = 0, price = 450 });

        mask_list.Add(new { Name = "Maske 117", variation = 44, texture = 0, price = 450 });

        mask_list.Add(new { Name = "Maske 118", variation = 45, texture = 0, price = 450 });

        mask_list.Add(new { Name = "Maske 119", variation = 46, texture = 0, price = 450 });

        mask_list.Add(new { Name = "Maske 120", variation = 47, texture = 0, price = 450 });
        mask_list.Add(new { Name = "Maske 121", variation = 47, texture = 1, price = 450 });
        mask_list.Add(new { Name = "Maske 122", variation = 47, texture = 2, price = 450 });
        mask_list.Add(new { Name = "Maske 123", variation = 47, texture = 3, price = 450 });

       

       
        mask_list.Add(new { Name = "Maske 593", variation = 109, texture = 11, price = 450 });

        mask_list.Add(new { Name = "Maske 594", variation = 110, texture = 0, price = 450 });
        mask_list.Add(new { Name = "Maske 595", variation = 110, texture = 1, price = 450 });
        mask_list.Add(new { Name = "Maske 596", variation = 110, texture = 2, price = 450 });
        mask_list.Add(new { Name = "Maske 597", variation = 110, texture = 3, price = 450 });
        mask_list.Add(new { Name = "Maske 598", variation = 110, texture = 4, price = 450 });
        mask_list.Add(new { Name = "Maske 599", variation = 110, texture = 5, price = 450 });
        mask_list.Add(new { Name = "Maske 600", variation = 110, texture = 6, price = 450 });


        mask_list.Add(new { Name = "Maske 620", variation = 111, texture = 0, price = 450 });
        mask_list.Add(new { Name = "Maske 621", variation = 111, texture = 1, price = 450 });
        mask_list.Add(new { Name = "Maske 622", variation = 111, texture = 2, price = 450 });
        mask_list.Add(new { Name = "Maske 623", variation = 111, texture = 3, price = 450 });
        mask_list.Add(new { Name = "Maske 624", variation = 111, texture = 4, price = 450 });
        mask_list.Add(new { Name = "Maske 625", variation = 111, texture = 5, price = 450 });
        mask_list.Add(new { Name = "Maske 626", variation = 111, texture = 6, price = 450 });
        mask_list.Add(new { Name = "Maske 627", variation = 111, texture = 7, price = 450 });


        mask_list.Add(new { Name = "Maske 646", variation = 112, texture = 0, price = 450 });
        mask_list.Add(new { Name = "Maske 647", variation = 112, texture = 1, price = 450 });
        mask_list.Add(new { Name = "Maske 648", variation = 112, texture = 2, price = 450 });
        mask_list.Add(new { Name = "Maske 649", variation = 112, texture = 3, price = 450 });
        mask_list.Add(new { Name = "Maske 650", variation = 112, texture = 4, price = 450 });
        mask_list.Add(new { Name = "Maske 651", variation = 112, texture = 5, price = 450 });
        mask_list.Add(new { Name = "Maske 652", variation = 112, texture = 6, price = 450 });
        mask_list.Add(new { Name = "Maske 653", variation = 112, texture = 7, price = 450 });


        mask_list.Add(new { Name = "Maske 672", variation = 113, texture = 0, price = 450 });
        mask_list.Add(new { Name = "Maske 673", variation = 113, texture = 1, price = 450 });
        mask_list.Add(new { Name = "Maske 674", variation = 113, texture = 2, price = 450 });
        mask_list.Add(new { Name = "Maske 675", variation = 113, texture = 3, price = 450 });
        mask_list.Add(new { Name = "Maske 676", variation = 113, texture = 4, price = 450 });
        mask_list.Add(new { Name = "Maske 677", variation = 113, texture = 5, price = 450 });


        mask_list.Add(new { Name = "Maske 694", variation = 114, texture = 0, price = 450 });
        mask_list.Add(new { Name = "Maske 695", variation = 114, texture = 1, price = 450 });
        mask_list.Add(new { Name = "Maske 696", variation = 114, texture = 2, price = 450 });
        mask_list.Add(new { Name = "Maske 697", variation = 114, texture = 3, price = 450 });
        mask_list.Add(new { Name = "Maske 698", variation = 114, texture = 4, price = 450 });
        mask_list.Add(new { Name = "Maske 699", variation = 114, texture = 5, price = 450 });
        mask_list.Add(new { Name = "Maske 700", variation = 114, texture = 6, price = 450 });


        mask_list.Add(new { Name = "Maske 722", variation = 115, texture = 0, price = 450 });
        mask_list.Add(new { Name = "Maske 723", variation = 115, texture = 1, price = 450 });
        mask_list.Add(new { Name = "Maske 724", variation = 115, texture = 2, price = 450 });
        mask_list.Add(new { Name = "Maske 725", variation = 115, texture = 3, price = 450 });
        mask_list.Add(new { Name = "Maske 726", variation = 115, texture = 4, price = 450 });
        mask_list.Add(new { Name = "Maske 727", variation = 115, texture = 5, price = 450 });
        mask_list.Add(new { Name = "Maske 728", variation = 115, texture = 6, price = 450 });

        mask_list.Add(new { Name = "Maske 774", variation = 117, texture = 0, price = 450 });
        mask_list.Add(new { Name = "Maske 775", variation = 117, texture = 1, price = 450 });
        mask_list.Add(new { Name = "Maske 776", variation = 117, texture = 2, price = 450 });
        mask_list.Add(new { Name = "Maske 777", variation = 117, texture = 3, price = 450 });
        mask_list.Add(new { Name = "Maske 778", variation = 117, texture = 4, price = 450 });
        mask_list.Add(new { Name = "Maske 779", variation = 117, texture = 5, price = 450 });
        mask_list.Add(new { Name = "Maske 780", variation = 117, texture = 6, price = 450 });
        mask_list.Add(new { Name = "Maske 781", variation = 117, texture = 7, price = 450 });
        mask_list.Add(new { Name = "Maske 782", variation = 117, texture = 8, price = 450 });


        mask_list.Add(new { Name = "Maske 796", variation = 118, texture = 0, price = 450 });
        mask_list.Add(new { Name = "Maske 797", variation = 118, texture = 1, price = 450 });
        mask_list.Add(new { Name = "Maske 798", variation = 118, texture = 2, price = 450 });
        mask_list.Add(new { Name = "Maske 799", variation = 118, texture = 3, price = 450 });
        mask_list.Add(new { Name = "Maske 800", variation = 118, texture = 4, price = 450 });
        mask_list.Add(new { Name = "Maske 801", variation = 118, texture = 5, price = 450 });
        mask_list.Add(new { Name = "Maske 802", variation = 118, texture = 6, price = 450 });
        mask_list.Add(new { Name = "Maske 803", variation = 118, texture = 7, price = 450 });
        mask_list.Add(new { Name = "Maske 804", variation = 118, texture = 8, price = 450 });


        mask_list.Add(new { Name = "Maske 822", variation = 119, texture = 0, price = 450 });
        mask_list.Add(new { Name = "Maske 823", variation = 119, texture = 1, price = 450 });
        mask_list.Add(new { Name = "Maske 824", variation = 119, texture = 2, price = 450 });
        mask_list.Add(new { Name = "Maske 825", variation = 119, texture = 3, price = 450 });
        mask_list.Add(new { Name = "Maske 826", variation = 119, texture = 4, price = 450 });
        mask_list.Add(new { Name = "Maske 827", variation = 119, texture = 5, price = 450 });
        mask_list.Add(new { Name = "Maske 828", variation = 119, texture = 6, price = 450 });
        mask_list.Add(new { Name = "Maske 829", variation = 119, texture = 7, price = 450 });
        mask_list.Add(new { Name = "Maske 830", variation = 119, texture = 8, price = 450 });
        mask_list.Add(new { Name = "Maske 831", variation = 119, texture = 9, price = 450 });
        mask_list.Add(new { Name = "Maske 832", variation = 119, texture = 10, price = 450 });
        mask_list.Add(new { Name = "Maske 833", variation = 119, texture = 11, price = 450 });
        mask_list.Add(new { Name = "Maske 834", variation = 119, texture = 12, price = 450 });
        mask_list.Add(new { Name = "Maske 835", variation = 119, texture = 13, price = 450 });
        mask_list.Add(new { Name = "Maske 836", variation = 119, texture = 14, price = 450 });
        mask_list.Add(new { Name = "Maske 837", variation = 119, texture = 15, price = 450 });
        mask_list.Add(new { Name = "Maske 838", variation = 119, texture = 16, price = 450 });
        mask_list.Add(new { Name = "Maske 839", variation = 119, texture = 17, price = 450 });
        mask_list.Add(new { Name = "Maske 840", variation = 119, texture = 18, price = 450 });
        mask_list.Add(new { Name = "Maske 841", variation = 119, texture = 19, price = 450 });
        mask_list.Add(new { Name = "Maske 842", variation = 119, texture = 20, price = 450 });
        mask_list.Add(new { Name = "Maske 843", variation = 119, texture = 21, price = 450 });
        mask_list.Add(new { Name = "Maske 844", variation = 119, texture = 22, price = 450 });
        mask_list.Add(new { Name = "Maske 845", variation = 119, texture = 23, price = 450 });
        mask_list.Add(new { Name = "Maske 846", variation = 119, texture = 24, price = 450 });


        mask_list.Add(new { Name = "Maske 902", variation = 131, texture = 0, price = 450 });


        helmet_list.Add(new { Name = "Helm öffnen 1", variation = 16, texture = 0, price = 1050 });
        helmet_list.Add(new { Name = "Helm öffnen 2", variation = 16, texture = 1, price = 1050 });
        helmet_list.Add(new { Name = "Helm öffnen 3", variation = 16, texture = 2, price = 1050 });
        helmet_list.Add(new { Name = "Helm öffnen 4", variation = 16, texture = 3, price = 1050 });
        helmet_list.Add(new { Name = "Helm öffnen 5", variation = 16, texture = 4, price = 1050 });
        helmet_list.Add(new { Name = "Helm öffnen 6", variation = 16, texture = 5, price = 1050 });
        helmet_list.Add(new { Name = "Helm öffnen 7", variation = 16, texture = 6, price = 1050 });
        helmet_list.Add(new { Name = "Helm öffnen 8", variation = 16, texture = 7, price = 1050 });

        helmet_list.Add(new { Name = "Chin-Helm 1", variation = 17, texture = 0, price = 850 });
        helmet_list.Add(new { Name = "Chin-Helm 2", variation = 17, texture = 1, price = 850 });
        helmet_list.Add(new { Name = "Chin-Helm 3", variation = 17, texture = 2, price = 850 });
        helmet_list.Add(new { Name = "Chin-Helm 4", variation = 17, texture = 3, price = 850 });
        helmet_list.Add(new { Name = "Chin-Helm 5", variation = 17, texture = 4, price = 850 });
        helmet_list.Add(new { Name = "Chin-Helm 6", variation = 17, texture = 5, price = 850 });
        helmet_list.Add(new { Name = "Chin-Helm 7", variation = 17, texture = 6, price = 850 });
        helmet_list.Add(new { Name = "Chin-Helm 8", variation = 17, texture = 7, price = 850 });

        helmet_list.Add(new { Name = "Geschlossener Visierhelm 1", variation = 18, texture = 0, price = 1600 });
        helmet_list.Add(new { Name = "Geschlossener Visierhelm 2", variation = 18, texture = 1, price = 1600 });
        helmet_list.Add(new { Name = "Geschlossener Visierhelm 3", variation = 18, texture = 2, price = 1600 });
        helmet_list.Add(new { Name = "Geschlossener Visierhelm 4", variation = 18, texture = 3, price = 1600 });
        helmet_list.Add(new { Name = "Geschlossener Visierhelm 5", variation = 18, texture = 4, price = 1600 });
        helmet_list.Add(new { Name = "Geschlossener Visierhelm 6", variation = 18, texture = 5, price = 1600 });
        helmet_list.Add(new { Name = "Geschlossener Visierhelm 7", variation = 18, texture = 6, price = 1600 });
        helmet_list.Add(new { Name = "Geschlossener Visierhelm 8", variation = 18, texture = 7, price = 1600 });

        helmet_list.Add(new { Name = "Open Track Visier Helm", variation = 48, texture = 0, price = 1750 });
        helmet_list.Add(new { Name = "Open Track Visier Helm", variation = 49, texture = 0, price = 1750 });

        helmet_list.Add(new { Name = "Foscos Helm 1", variation = 50, texture = 0, price = 10000 });
        helmet_list.Add(new { Name = "Foscos Helm 2", variation = 52, texture = 0, price = 10000 });
        helmet_list.Add(new { Name = "Verchromter Boss-Helm 1", variation = 51, texture = 0, price = 15000 });
        helmet_list.Add(new { Name = "Verchromter Boss-Helm 2", variation = 53, texture = 0, price = 15000 });

        //-1336.596, -1279.008, 4.856604

        Entity temp_blip;
        temp_blip = NAPI.Blip.CreateBlip(new Vector3(-1336.596, -1279.008, 4.856604));
        NAPI.Blip.SetBlipName(temp_blip, "Masken und Helme");
        NAPI.Blip.SetBlipSprite(temp_blip, 362);
        NAPI.Blip.SetBlipColor(temp_blip, 33);
        NAPI.Blip.SetBlipScale(temp_blip, 1.0f);
        NAPI.Blip.SetBlipShortRange(temp_blip, true);


        NAPI.TextLabel.CreateTextLabel("~b~- ~w~Masken und Helme~b~ -~n~~n~~w~Drücke ~y~E~w~ ", new Vector3(-1336.596, -1279.008, 4.856604), 8.0f, 1.0f, 0, new Color(255, 255, 255, 255), false, 0);
        NAPI.Marker.CreateMarker(27, new Vector3(-1336.596, -1279.008, 4.856604 - 0.8), new Vector3(), new Vector3(), 1.5f, new Color(244, 217, 66, 150), false, 0);
    }

    [ServerEvent(Event.PlayerConnected)]
    public void OnPlayerConnected(Client player)
    {
        for (int i = 0; i < Main.MAX_PLAYERS; i++)
        {
            player.SetSharedData("know_player_" + i, -1);
        }
    }

    [Command("conhecer")]
    public static void CMD_conhecer(Client player, string idOrName)
    {
        if (player.GetData("status") == false)
        {
            return;
        }

        Client target = Main.findPlayer(player, idOrName);
        if (target == null)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Dieser Player ist offline oder existiert nicht.");
            return;
        }

        if (target.GetData("status") == false)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Dieser Bürger ist nicht online oder existiert nicht.");
            return;
        }

        if (!Main.IsInRangeOfPoint(player.Position, target.Position, 10.0f))
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Sie sind nicht in der Nähe dieses Bürger.");
            return;
        }

        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {
            Mainpipeline.Open();
            MySqlCommand query = Mainpipeline.CreateCommand();
            query.CommandType = CommandType.Text;
            query.CommandText = "SELECT * FROM `known` WHERE `player_one` = " + AccountManage.GetPlayerSQLID(player) + " AND `player_two` = " + AccountManage.GetPlayerSQLID(target) + " OR `player_one` = " + AccountManage.GetPlayerSQLID(target) + " AND `player_two` = " + AccountManage.GetPlayerSQLID(player) + ";";
            query.ExecuteNonQuery();
            DataTable dt = new DataTable();
            using (MySqlDataAdapter da = new MySqlDataAdapter(query))
            {
                da.Fill(dt);
                int i = 0;
                i = Convert.ToInt32(dt.Rows.Count.ToString());
                if (i == 0)
                {
                    target.SetData("know_sender", player);
                    target.SetData("know_sender_sqlid", AccountManage.GetPlayerSQLID(player));
                    InteractMenu.ShowModal(target, "KNOW_SYSTEM", "Erkennungssystem", "Der Bürger " + AccountManage.GetCharacterName(player) + " will dich treffen", "Ja, ich möchte dich treffen..", "Nein, danke.");

                    Main.SendInfoMessage(player, "Sie haben eine Bestätigungsanfrage an den gesendetDesconhecido_" + AccountManage.GetPlayerSQLID(target) + ".");
                }
                else
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "Sie und dieser Spieler kennen sich bereits.");
                }
            }
        }
    }

    public static void ModalConfirm(Client player, string response)
    {
        if (response == "KNOW_SYSTEM")
        {
            Client target = NAPI.Data.GetEntityData(player, "know_sender");
            int target_sqlid = player.GetData("know_sender_sqlid");

            if (!API.Shared.IsPlayerConnected(target))
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Der Bürger, der Ihnen die Wissensanfrage gesendet hat, ist nicht mehr verbunden.");
                return;
            }

            if (target.GetData("status") == false && AccountManage.GetPlayerSQLID(target) != target_sqlid)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Der Bürger, der Ihnen die Wissensanfrage gesendet hat, ist nicht mehr verbunden.");
                return;
            }

            if (!Main.IsInRangeOfPoint(player.Position, target.Position, 50.0f))
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Der Bürger, der Ihnen die Wissensanfrage gesendet hat, hat sich zu weit von Ihnen entfernt.");
                return;
            }

            Main.CreateMySqlCommand("INSERT INTO `known` (player_one, player_two) VALUES (" + AccountManage.GetPlayerSQLID(player) + ", " + AccountManage.GetPlayerSQLID(target) + ");");
            UpdatePlayerKnows(player);
            UpdatePlayerKnows(target);

            Main.SendSuccessMessage(target, "Der Bürger" + AccountManage.GetPlayerSQLID(player) + " Ich akzeptiere, Sie kennenzulernen, Ihr Name ist " + AccountManage.GetCharacterName(player) + ".");
            NAPI.Notification.SendNotificationToPlayer(player, "Sie stimmten zu, den Bürger zu treffen." + AccountManage.GetPlayerSQLID(target) + ", dein Name ist" + AccountManage.GetCharacterName(target) + ".");
        }
    }

    public static void UpdatePlayerKnows(Client player)
    {
        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {

            for (int i = 0; i < Main.MAX_PLAYERS; i++)
            {
                player.SetSharedData("know_player_" + i, -1);
            }

            List<dynamic> menu_item_list = new List<dynamic>();

            Mainpipeline.Open();
            MySqlCommand query = new MySqlCommand("SELECT * FROM `known` WHERE `player_one` = " + AccountManage.GetPlayerSQLID(player) + " OR `player_two` = " + AccountManage.GetPlayerSQLID(player) + ";", Mainpipeline);
            using (MySqlDataReader reader = query.ExecuteReader())
            {
                var index = 0;
                while (reader.Read())
                {
                    if (AccountManage.GetPlayerSQLID(player) == reader.GetInt32("player_one"))
                    {
                        player.SetSharedData("know_player_" + index, reader.GetInt32("player_two"));
                    }
                    else if (AccountManage.GetPlayerSQLID(player) == reader.GetInt32("player_two"))
                    {
                        player.SetSharedData("know_player_" + index, reader.GetInt32("player_one"));
                    }
                    index++;
                }
            }

        }
    }

    public static void GetPlayerName(Client player)
    {

    }

    public static void KeyPressY(Client player)
    {
        if(Main.IsInRangeOfPoint(player.Position, new Vector3(-1336.596, -1279.008, 4.856604), 3.0f))
        {
            if(player.IsInVehicle)
            {
                return;
            }
            if(mask[Main.getIdFromClient(player)] == true)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Sie können diesen Laden nicht mit einer Maske oder einem Helm verwenden.");
                return;
            }
            List<dynamic> menu_item_list = new List<dynamic>();
            menu_item_list.Add(new { Type = 1, Name = "Motorradhelme", Description = "", RightLabel = "" });
            menu_item_list.Add(new { Type = 1, Name = "Masken", Description = "", RightLabel = "" });
            InteractMenu.CreateMenu(player,  "MASK_AND_HELMET_STORE", "Masken und Helme", "~b~Preis:", true, JsonConvert.SerializeObject(menu_item_list), false);
        }
    }

    public static void SelectMenuResponse(Client player, String callbackId, int selectedIndex, String objectName, String valueList)
    {
        if(callbackId == "MASK_AND_HELMET_STORE")
        {
            if(selectedIndex == 0)
            {
                List<dynamic> menu_item_list = new List<dynamic>();

                foreach(var helmet in helmet_list)
                {
                    menu_item_list.Add(new { Type = 4, Name = helmet.Name, Description = "", RightLabel = "$"+ helmet.price+"" });
                }
                InteractMenu.CreateMenu(player,  "HELMET_STORE", "Masken und Helme", "~b~Preis:", true, JsonConvert.SerializeObject(menu_item_list), false);
            }
            else if(selectedIndex == 1)
            {
                List<dynamic> menu_item_list = new List<dynamic>();
                foreach (var mask in mask_list)
                {
                    menu_item_list.Add(new { Type = 4, Name = mask.Name, Description = "", RightLabel = "$" + mask.price + "" });
                }
                InteractMenu.CreateMenu(player,  "MASK_STORE", "Masken und Helme", "~b~Preis:", true, JsonConvert.SerializeObject(menu_item_list), false);
            }
        }
        else if(callbackId == "MASK_STORE")
        {

            if(Main.GetPlayerMoney(player) < mask_list[selectedIndex].price)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Dieser Artikel kostet $" + mask_list[selectedIndex].price + " du hast nun " + Main.GetPlayerMoney(player)+ " in händen.");
                return;
            }

            NAPI.Data.SetEntitySharedData(player, "character_mask", mask_list[selectedIndex].variation);
            NAPI.Data.SetEntitySharedData(player, "character_mask_texture", mask_list[selectedIndex].texture);
            player.SetClothes(1, 0, 0);
            Main.UpdatePlayerClothes(player);
            Main.GivePlayerMoney(player, -mask_list[selectedIndex].price);
            NAPI.Notification.SendNotificationToPlayer(player, "Du hast gekauft " + Main.EMBED_YELLOW + "" + mask_list[selectedIndex].Name + "" + Main.EMBED_WHITE + " eine Maske " + Main.EMBED_GREEN + "$" + mask_list[selectedIndex].price + "" + Main.EMBED_WHITE + ".");
            Main.SendInfoMessage(player, "Verwenden Sie die Maske, Aber Vorsicht, Masken in der Öffentlichkeit zu tragen, ist ein Verbrechen. !");
        }
        else if (callbackId == "HELMET_STORE")
        {

            if (Main.GetPlayerMoney(player) < helmet_list[selectedIndex].price)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Dieser Artikel kostet $" + helmet_list[selectedIndex].price + " du hast nur " + Main.GetPlayerMoney(player) + " in händen.");
                return;
            }

            NAPI.Data.SetEntitySharedData(player, "character_helmet", helmet_list[selectedIndex].variation);
            NAPI.Data.SetEntitySharedData(player, "character_helmet_texture", helmet_list[selectedIndex].texture);
            player.ClearAccessory(0);
            Main.UpdatePlayerClothes(player);
            Main.GivePlayerMoney(player, -helmet_list[selectedIndex].price);
            NAPI.Notification.SendNotificationToPlayer(player, "Du hast einen gekauft " + Main.EMBED_YELLOW + "" + helmet_list[selectedIndex].Name + "" + Main.EMBED_WHITE + " in der Filmmaske für " + Main.EMBED_GREEN + "$" + helmet_list[selectedIndex].price + "" + Main.EMBED_WHITE + ".");
            Main.SendInfoMessage(player, "Verwenden Sie den Helm " + Main.EMBED_LIGHTGREEN + "aber" + Main.EMBED_WHITE + ", du musst auf einem Motorrad sein. !");
        }

    }

    public static void IndexChangeMenuResponse(Client player, String callbackId, int selectedIndex, String objectName, String valueList)
    {
        if(callbackId == "MASK_STORE")
        {
            player.SetClothes(1, mask_list[selectedIndex].variation, mask_list[selectedIndex].texture);
        }
        else if (callbackId == "HELMET_STORE")
        {
            player.SetAccessories(0, helmet_list[selectedIndex].variation, helmet_list[selectedIndex].texture);
        }

    }

    public static void OnMenuReturnClose(Client player, String callbackId)
    {
        if (callbackId == "MASK_STORE")
        {
            player.SetClothes(1, 0, 0);
            Main.UpdatePlayerClothes(player);
        }
        else if (callbackId == "HELMET_STORE")
        {
            player.ClearAccessory(0);
            Main.UpdatePlayerClothes(player);
        }
    }


    [Command("mask", Alias = "mascara")]
    public static void CMD_Mascara(Client player)
    {
        if ((int)NAPI.Data.GetEntitySharedData(player, "character_mask") == 0)
        {
            InteractMenu_New.SendNotificationError(player, "Du hast keine Maske.");
            return;
        }
        if (mask[Main.getIdFromClient(player)])
        {
            mask[Main.getIdFromClient(player)] = false;
            NAPI.Player.SetPlayerClothes(player, 1, 0, 0);
            NAPI.Data.SetEntitySharedData(player, "using_mask", false);
        }
        else
        {
            var temp_mask = (int)NAPI.Data.GetEntitySharedData(player, "character_mask");
            var temp_mask_texture = (int)NAPI.Data.GetEntitySharedData(player, "character_mask_texture");

            mask[Main.getIdFromClient(player)] = true;
            NAPI.Data.SetEntitySharedData(player, "using_mask", true);
            NAPI.Player.SetPlayerClothes(player, 1, temp_mask, temp_mask_texture);


        }
    }

    public static void RemoveMaskFromPlayer(Client player)
    {
        mask[Main.getIdFromClient(player)] = false;
        NAPI.Player.SetPlayerClothes(player, 1, 0, 0);
        NAPI.Data.SetEntitySharedData(player, "using_mask", false);
    }

    [RemoteEvent("keypress:F9")]
    public static void CMD_CharClothes(Client player)
    {
        


        if (charclothes[Main.getIdFromClient(player)])
        {
            if (NAPI.Data.GetEntityData(player, "CHARACTER_ONLINE_GENRE") == 0)
            {
                //var feet = new Dictionary<int, ComponentVariation>();
                //feet.Add(6, new ComponentVariation { Drawable = player.GetData("character_feet"), Texture = player.GetData("character_feet_texture") });

                charclothes[Main.getIdFromClient(player)] = false;
                player.SetClothes(3, 15, 0);
                player.SetClothes(4, 61, 0);
                player.SetClothes(6, 5, 0);
                player.SetClothes(7, 0, 0);
                player.SetClothes(8, 15, 0);
                player.SetClothes(11, 15, 0);

                player.SetAccessories(0, 0, 0);
                player.ClearAccessory(0);
                NAPI.Data.SetEntitySharedData(player, "using_torso", false);
                NAPI.Data.SetEntitySharedData(player, "using_undershirt", false);
                NAPI.Data.SetEntitySharedData(player, "using_accessories", false);
                NAPI.Data.SetEntitySharedData(player, "using_leg", false);
                NAPI.Data.SetEntitySharedData(player, "using_feet", false);
                NAPI.Data.SetEntitySharedData(player, "using_shirt", false);
            }
            else
            {
                //var feet = new Dictionary<int, ComponentVariation>();
                //feet.Add(6, new ComponentVariation { Drawable = player.GetData("character_feet"), Texture = player.GetData("character_feet_texture") });

                charclothes[Main.getIdFromClient(player)] = false;
                player.SetClothes(3, 15, 0);
                player.SetClothes(4, 15, 0);
                player.SetClothes(6, 5, 0);
                player.SetClothes(7, 0, 0);
                player.SetClothes(8, 15, 0);
                player.SetClothes(11, 15, 0);
                player.SetAccessories(0, 0, 0);
                player.ClearAccessory(0);
                NAPI.Data.SetEntitySharedData(player, "using_torso", false);
                NAPI.Data.SetEntitySharedData(player, "using_undershirt", false);
                NAPI.Data.SetEntitySharedData(player, "using_accessories", false);
                NAPI.Data.SetEntitySharedData(player, "using_leg", false);
                NAPI.Data.SetEntitySharedData(player, "using_feet", false);
                NAPI.Data.SetEntitySharedData(player, "using_shirt", false);
            }

           
        }
        else
        {
            var mask = (int)NAPI.Data.GetEntitySharedData(player, "character_mask");
            var mask_texture = (int)NAPI.Data.GetEntitySharedData(player, "character_mask_texture");
            var torso = (int)NAPI.Data.GetEntitySharedData(player, "character_torso");
            var torso_texture = (int)NAPI.Data.GetEntitySharedData(player, "character_torso_texture");
            var undershirt = (int)NAPI.Data.GetEntitySharedData(player, "character_undershirt");
            var undershirt_texture = (int)NAPI.Data.GetEntitySharedData(player, "character_undershirt_texture");
            var leg = (int)NAPI.Data.GetEntitySharedData(player, "character_leg");
            var leg_texture = (int)NAPI.Data.GetEntitySharedData(player, "character_leg_texture");
            var feet = (int)NAPI.Data.GetEntitySharedData(player, "character_feet");
            var feet_texture = (int)NAPI.Data.GetEntitySharedData(player, "character_feet_texture");
            var shirt = (int)NAPI.Data.GetEntitySharedData(player, "character_shirt");
            var shirt_texture = (int)NAPI.Data.GetEntitySharedData(player, "character_shirt_texture");
            var armor = (int)NAPI.Data.GetEntitySharedData(player, "character_armor");
            var armor_texture = (int)NAPI.Data.GetEntitySharedData(player, "character_armor_texture");

            var ears = (int)NAPI.Data.GetEntitySharedData(player, "character_ears");
            var ears_texture = (int)NAPI.Data.GetEntitySharedData(player, "character_ears_texture");
            var watches = (int)NAPI.Data.GetEntitySharedData(player, "character_watches");
            var watches_texture = (int)NAPI.Data.GetEntitySharedData(player, "character_watches_texture");
            var bracelets = (int)NAPI.Data.GetEntitySharedData(player, "character_bracelets");
            var bracelets_texture = (int)NAPI.Data.GetEntitySharedData(player, "character_bracelets_texutre");

            charclothes[Main.getIdFromClient(player)] = true;
            NAPI.Data.SetEntitySharedData(player, "using_torso", true);
            NAPI.Data.SetEntitySharedData(player, "using_undershirt", true);
            NAPI.Data.SetEntitySharedData(player, "using_leg", true);
            NAPI.Data.SetEntitySharedData(player, "using_feet", true);
            NAPI.Data.SetEntitySharedData(player, "using_shirt", true);
            
            player.SetClothes(3, (int)NAPI.Data.GetEntitySharedData(player, "character_torso"), (int)NAPI.Data.GetEntitySharedData(player, "character_torso_texture"));
            player.SetClothes(4, (int)NAPI.Data.GetEntitySharedData(player, "character_leg"), (int)NAPI.Data.GetEntitySharedData(player, "character_leg_texture"));
            player.SetClothes(6, (int)NAPI.Data.GetEntitySharedData(player, "character_feet"), (int)NAPI.Data.GetEntitySharedData(player, "character_feet_texture"));
            player.SetClothes(7, (int)NAPI.Data.GetEntitySharedData(player, "character_accessories"), (int)NAPI.Data.GetEntitySharedData(player, "character_accessories_texture"));
            player.SetClothes(8, (int)NAPI.Data.GetEntitySharedData(player, "character_undershirt"), (int)NAPI.Data.GetEntitySharedData(player, "character_undershirt_texture"));
            player.SetClothes(9, (int)NAPI.Data.GetEntitySharedData(player, "character_armor"), (int)NAPI.Data.GetEntitySharedData(player, "character_armor_texture"));
            player.SetClothes(11, (int)NAPI.Data.GetEntitySharedData(player, "character_shirt"), (int)NAPI.Data.GetEntitySharedData(player, "character_shirt_texture"));

        }
    }

    public static void CMD_AdminCharClothes(Client player)
    {

  
        if (charclothes[Main.getIdFromClient(player)])
        {
            if ((int)NAPI.Data.GetEntityData(player, "CHARACTER_ONLINE_GENRE") == 0)
            {
                var clothes = new Dictionary<int, ComponentVariation>();
                clothes.Add(1, new ComponentVariation { Drawable = player.GetData("character_mask"), Texture = player.GetData("character_mask_texture") });
                clothes.Add(3, new ComponentVariation { Drawable = player.GetData("character_torso"), Texture = player.GetData("character_torso_texture") });
                clothes.Add(8, new ComponentVariation { Drawable = player.GetData("character_undershirt"), Texture = player.GetData("character_undershirt_texture") });
                clothes.Add(4, new ComponentVariation { Drawable = player.GetData("character_leg"), Texture = player.GetData("character_leg_texture") });
                clothes.Add(6, new ComponentVariation { Drawable = player.GetData("character_feet"), Texture = player.GetData("character_feet_texture") });
                clothes.Add(11, new ComponentVariation { Drawable = player.GetData("character_shirt"), Texture = player.GetData("character_shirt_texture") });
                clothes.Add(9, new ComponentVariation { Drawable = player.GetData("character_armor"), Texture = player.GetData("character_armor_texture") });
                clothes.Add(7, new ComponentVariation { Drawable = player.GetData("character_accessories"), Texture = player.GetData("character_accessories_texture") });

                //NAPI.Util.ConsoleOutput("DEBUG ::: clothes " + clothes + "");


                charclothes[Main.getIdFromClient(player)] = true;
                NAPI.Data.SetEntitySharedData(player, "using_torso", true);
                NAPI.Data.SetEntitySharedData(player, "using_undershirt", true);
                NAPI.Data.SetEntitySharedData(player, "using_leg", true);
                NAPI.Data.SetEntitySharedData(player, "using_feet", true);
                NAPI.Data.SetEntitySharedData(player, "using_shirt", true);
                player.SetClothes(clothes);
            }
            else
            {
                var clothes = new Dictionary<int, ComponentVariation>();
                clothes.Add(1, new ComponentVariation { Drawable = player.GetData("character_mask"), Texture = player.GetData("character_mask_texture") });
                clothes.Add(3, new ComponentVariation { Drawable = player.GetData("character_torso"), Texture = player.GetData("character_torso_texture") });
                clothes.Add(8, new ComponentVariation { Drawable = player.GetData("character_undershirt"), Texture = player.GetData("character_undershirt_texture") });
                clothes.Add(4, new ComponentVariation { Drawable = player.GetData("character_leg"), Texture = player.GetData("character_leg_texture") });
                clothes.Add(6, new ComponentVariation { Drawable = player.GetData("character_feet"), Texture = player.GetData("character_feet_texture") });
                clothes.Add(11, new ComponentVariation { Drawable = player.GetData("character_shirt"), Texture = player.GetData("character_shirt_texture") });
                clothes.Add(9, new ComponentVariation { Drawable = player.GetData("character_armor"), Texture = player.GetData("character_armor_texture") });
                clothes.Add(7, new ComponentVariation { Drawable = player.GetData("character_accessories"), Texture = player.GetData("character_accessories_texture") });

                //NAPI.Util.ConsoleOutput("DEBUG ::: clothes " + clothes + "");

                charclothes[Main.getIdFromClient(player)] = true;
                NAPI.Data.SetEntitySharedData(player, "using_torso", true);
                NAPI.Data.SetEntitySharedData(player, "using_undershirt", true);
                NAPI.Data.SetEntitySharedData(player, "using_leg", true);
                NAPI.Data.SetEntitySharedData(player, "using_feet", true);
                NAPI.Data.SetEntitySharedData(player, "using_shirt", true);
                player.SetClothes(clothes);

            }
        }
    }

    [Command("capacete", Alias = "helmet")]
    public static void CMD_capacete(Client player)
    {
        if (!player.IsInVehicle)
        {
            InteractMenu_New.SendNotificationError(player, "Sie sind nicht in einem Fahrzeug..");
            return;
        }
        if (player.Vehicle.Class != 8)
        {
            InteractMenu_New.SendNotificationError(player, "Sie können einen Helm nur in Fahrrädern tragen.");
            return;
        }
        if ((int)NAPI.Data.GetEntitySharedData(player, "character_helmet") == 0)
        {
            InteractMenu_New.SendNotificationError(player, "Sie haben keinen Helm..");
            return;
        }
        if (seatbelt[Main.getIdFromClient(player)])
        {
            //InteractMenu_New.SendNotificationSuccess(player, "Du hast den Helm abgenommen..");
            //UsefullyRP.SendRoleplayAction(player, "Helm entfernt.");
            seatbelt[Main.getIdFromClient(player)] = false;
            NAPI.Player.ClearPlayerAccessory(player, 0);
            Main.UpdatePlayerClothes(player);
        }
        else
        {
            var helmet = (int)NAPI.Data.GetEntitySharedData(player, "character_helmet");
            var helmet_texture = (int)NAPI.Data.GetEntitySharedData(player, "character_helmet_texture");

            //InteractMenu_New.SendNotificationSuccess(player, "Sie setzen den Helm auf..");
            //UsefullyRP.SendRoleplayAction(player, "den Helm aufsetzen.");

            seatbelt[Main.getIdFromClient(player)] = true;
            NAPI.Player.SetPlayerAccessory(player, 0, helmet, helmet_texture);
        }
    }


    [Command("seatbelt", Alias = "sb,cinto", GreedyArg = true)]
    public static void CMD_seatbelt(Client player)
    {
        if (!player.IsInVehicle)
        {
            InteractMenu_New.SendNotificationError(player, "Sie sind nicht in einem Fahrzeug.");
            return;
        }

        if (player.Vehicle.Class == 8 || player.Vehicle.Class == 13)
        {
            InteractMenu_New.SendNotificationError(player, "Sie können in diesem Fahrzeug keinen Sicherheitsgurt anlegen.");
            return;
        }

        if (seatbelt[Main.getIdFromClient(player)])
        {
            InteractMenu_New.SendNotificationSuccess(player, "Du hast deinen Sicherheitsgurt abgenommen..");
            UsefullyRP.SendRoleplayAction(player, "den Sicherheitsgurt entfernt.");
            seatbelt[Main.getIdFromClient(player)] = false;
        }
        else
        {
            InteractMenu_New.SendNotificationSuccess(player, "Sie legen den Sicherheitsgurt an.");
            UsefullyRP.SendRoleplayAction(player, "Legen Sie den Sicherheitsgurt an.");
            seatbelt[Main.getIdFromClient(player)] = true;
        }
    }

    [Command("checarcinto", GreedyArg = true)]
    public void CMD_checarcinto(Client player, string idOrName)
    {
        Client target = Main.findPlayer(player, idOrName);
        if (target == null)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Dieser Bürger ist nicht da.");
            return;
        }

        if (!target.IsInVehicle)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Dieser Bürger befindet sich nicht in einem Fahrzeug.");
            return;
        }

        if (target.VehicleSeat != -1)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Dieser Bürger befindet sich nicht als Fahrer eines Fahrzeugs.");
            return;
        }

        if(!Main.IsInRangeOfPoint(player.Position, target.Position, 10.0f))
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Sie sind nicht in der Nähe des Zielspielers.");
            return;
        }

        if (seatbelt[Main.getIdFromClient(player)])
        {
            Main.SendInfoMessage(player, "Dieser Spieler trägt einen Sicherheitsgurt.");
        }
        else
        {
            Main.SendInfoMessage(player, "Dieser Spieler trägt keinen Sicherheitsgurt.");
        }
    }

    public static void SendRoleplayAction(Client player, string msg)
    {
        List<Client> proxPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(15, player);
        foreach (Client target in proxPlayers)
        {
           // target.TriggerEvent("Send_ToChat", "", "<font color ='#C2A2DA'>* " + GetPlayerNameToTarget(player, target) + "", "<font color ='#C2A2DA'>"+msg);
        }
        //Main.EmoteMessage(player, msg);
        NAPI.Notification.SendNotificationToPlayer(player, ""+ msg + "");
    }

    public static string GetPlayerNameToTarget(Client player, Client target)
    {
        if (mask[Main.getIdFromClient(player)])
        {
            return "Maskierte Person: " + AccountManage.GetPlayerSQLID(player);
        }
        else
        {
            bool can_pass = true;
            for (int index = 0; index < Main.MAX_PLAYERS; index++)
            {
                if (target.GetSharedData("know_player_" + index) == AccountManage.GetPlayerSQLID(player))
                {
                    return AccountManage.GetCharacterName(player);
                }
            }

            if (can_pass == true)
            {
                if (player == target)
                {
                    return AccountManage.GetCharacterName(player);
                }
                else
                {
                    return "Unbekannte Person: " + AccountManage.GetPlayerSQLID(player);
                }
            }
        }
        return AccountManage.GetCharacterName(player);
    }
}

