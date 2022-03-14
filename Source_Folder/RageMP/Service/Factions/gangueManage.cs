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

class GangueManage : Script
{
    public static void DisplayCreateGangueMenu(Client player, bool firstTime = false)
    {
        if (firstTime == true)
        {
            player.SetData("gangue_name", "undefiniert");
            player.SetData("gangue_abreviacao", "undefiniert");
            player.SetData("gangue_color", "FFFFFF");

            player.SetData("gangue_hierarquia_0", "Newcomer");
            player.SetData("gangue_hierarquia_1", "Getauft");
            player.SetData("gangue_hierarquia_2", "Mitglied");
            player.SetData("gangue_hierarquia_3", "Gangster");
            player.SetData("gangue_hierarquia_4", "Rechte Hand");
            player.SetData("gangue_hierarquia_5", "Chef");
        }

        List<dynamic> menu_item_list = new List<dynamic>();
        menu_item_list.Add(new { Type = 1, Name = "Name der Fraktion", Description = "", RightLabel = "~c~" + player.GetData("gangue_name") });
        menu_item_list.Add(new { Type = 1, Name = "Abkürzung", Description = "", RightLabel = "~c~" + player.GetData("gangue_abreviacao") });
        menu_item_list.Add(new { Type = 1, Name = "Fraktionsfarbe", Description = "", RightLabel = "~c~" + player.GetData("gangue_color") });
        menu_item_list.Add(new { Type = 1, Name = "Hierarchie", Description = "", RightLabel = ">>"});
        menu_item_list.Add(new { Type = 1, Name = "Fraktion erstellen", Description = "", RightLabel = ""});

        InteractMenu.CreateMenu(player, "PLAYER_FACTION_CREATE", "Fraktion", "~b~Fraktion erstellen", true, JsonConvert.SerializeObject(menu_item_list), false);
    }

    public static void SelectMenuResponse(Client player, String callbackId, int selectedIndex, String objectName, String valueList)
    {
        if (callbackId == "PLAYER_FACTION_CREATE")
        {
            switch (selectedIndex)
            {
                case 0:
                    {
                        InteractMenu.User_Input(player, "input_player_faction_create", "Name der Fraktion", player.GetData("gangue_name"));
                        InteractMenu.CloseDynamicMenu(player);
                        break;
                    }
                case 1:
                    {
                        InteractMenu.User_Input(player, "input_player_faction_abbrev", "Abkürzung, Ex: IND", player.GetData("gangue_abreviacao"));
                        InteractMenu.CloseDynamicMenu(player);
                        break;
                    }
                case 2:
                    {
                        InteractMenu.User_Input(player, "input_player_faction_color", "Fraktionsfarbe, Ex: FFFF00", player.GetData("gangue_color"));
                        InteractMenu.CloseDynamicMenu(player);
                        break;
                    }
                case 3:
                    {
                        List<dynamic> menu_item_list = new List<dynamic>();
                        for (int i = 0; i < 6; i++)
                        {
                            menu_item_list.Add(new { Type = 1, Name = "Rank " + i + ".", Description = "", RightLabel = "~w~" + player.GetData("gangue_hierarquia_" + i) });
                        }
                        InteractMenu.CreateMenu(player, "PLAYER_FACTION_HIERARQUIA", "Fraktion", "~b~Hierarchie", true, JsonConvert.SerializeObject(menu_item_list), false);
                        //player.TriggerEvent("menu_handler_create_menu_generic", "PLAYER_FACTION_HIERARQUIA", "Fraktion", "~b~Hierarchie", false, JsonConvert.SerializeObject(menu_item_list), "Seite", "durch die Seiten blättern", 100);
                        break;
                    }
                case 4:
                    {
                        if (player.GetData("gangue_name") == "undefiniert")
                        {
                            NAPI.Notification.SendNotificationToPlayer(player, "Du musst zuerst einen Namen für deine Bande wählen.");
                            return;
                        }
                        if (player.GetData("gangue_abreviacao") == "undefiniert")
                        {
                            NAPI.Notification.SendNotificationToPlayer(player, "Du musst zuerst einen Namen für deine Bande wählen");
                            return;
                        }
                        if (player.GetData("gangue_color") == "FFFFFF")
                        {
                            NAPI.Notification.SendNotificationToPlayer(player, "Sie sollten zuerst eine Farbe für Ihre Bande wählen.Besuch ~y~www.Colorpicker.com~w~ eine Farbe im Hex-Stil erhalten. Ex: ~b~CCFF00~w~.");
                            return;
                        }

                        for (int i = 20; i < FactionManage.MAX_FACTIONS; i++)
                        {
                            if (FactionManage.faction_data[i].faction_name == "undefiniert")
                            {
                                FactionManage.faction_data[i].faction_name = Convert.ToString(player.GetData("gangue_name"));
                                FactionManage.faction_data[i].faction_abbrev = player.GetData("gangue_abreviacao");
                                FactionManage.faction_data[i].faction_color = player.GetData("gangue_color");

                                FactionManage.faction_data[i].faction_type = 4;

                                FactionManage.faction_data[i].faction_rank[0] = player.GetData("gangue_hierarquia_0");
                                FactionManage.faction_data[i].faction_rank[1] = player.GetData("gangue_hierarquia_1");
                                FactionManage.faction_data[i].faction_rank[2] = player.GetData("gangue_hierarquia_2");
                                FactionManage.faction_data[i].faction_rank[3] = player.GetData("gangue_hierarquia_3");
                                FactionManage.faction_data[i].faction_rank[4] = player.GetData("gangue_hierarquia_4");
                                FactionManage.faction_data[i].faction_rank[5] = player.GetData("gangue_hierarquia_5");

                                NAPI.Data.SetEntityData(player, "character_leader", i);
                                NAPI.Data.SetEntityData(player, "character_group", i);
                                NAPI.Data.SetEntityData(player, "character_group_rank", 5);

                                NAPI.Notification.SendNotificationToPlayer(player, "Sie haben eine Bande mit dem Namen erstellt ~g~" + player.GetData("gangue_name") + "~w~.");
                                FactionManage.SaveFaction(i);
                                FactionManage.SaveFactionRanks(i);
                                return;
                            }
                        }
                        NAPI.Notification.SendNotificationToPlayer(player, "Die Gang - Datenbank ist ausgebucht.Versuchen Sie es später erneut. ");
                        break;
                    }
            }
        }
        else if (callbackId == "PLAYER_FACTION_HIERARQUIA")
        {
            player.SetData("customListItem", selectedIndex);
            InteractMenu.User_Input(player, "input_player_faction_hierarquia", "Hierarchiename", player.GetData("gangue_hierarquia_" + selectedIndex));
            InteractMenu.CloseDynamicMenu(player);
        }

    }

    public static void OnInputResponse(Client player, String response, String inputtext)
    {
        switch(response)
        {
            case "input_player_faction_create":
                player.SetData("gangue_name", inputtext);
                DisplayCreateGangueMenu(player);
                break;
            case "input_player_faction_abbrev":
                player.SetData("gangue_abreviacao", inputtext);
                DisplayCreateGangueMenu(player);
                break;
            case "input_player_faction_color":
                player.SetData("gangue_color", inputtext);
                DisplayCreateGangueMenu(player);
                break;
            case "input_player_faction_hierarquia":

                int index = player.GetData("customListItem");
                if (inputtext.Count() < 4)
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "Der Hierarchiename muss mindestens 3 Zeichen enthalten.");
                    DisplayCreateGangueMenu(player);
                    return;
                }
                player.SetData("gangue_hierarquia_" + index, inputtext);

                // show menu again
                List<dynamic> menu_item_list = new List<dynamic>();
                for (int i = 0; i < 6; i++)
                {
                    menu_item_list.Add(new { Type = 1, Name = "Rank " + i + ".", Description = "", RightLabel = "~w~" + player.GetData("gangue_hierarquia_" + i) });
                }
                InteractMenu.CreateMenu(player, "PLAYER_FACTION_HIERARQUIA", "Fraktion", "~b~Hierarchie", true, JsonConvert.SerializeObject(menu_item_list), false);
                //player.TriggerEvent("menu_handler_create_menu_generic", "PLAYER_FACTION_HIERARQUIA", "Fraktion", "~b~Hierarchie", false, JsonConvert.SerializeObject(menu_item_list), "Seite", "durch die Seiten blättern", 100);
                break;
        }
    }
    public static void OnMenuReturnClose(Client player, String callbackId)
    {
        if(callbackId == "PLAYER_FACTION_HIERARQUIA")
        {
            DisplayCreateGangueMenu(player);
        }
    }
}
