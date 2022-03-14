using System;
using System.Collections.Generic;
using System.Linq;
using GTANetworkAPI;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using DerStr1k3r.Core;
using DerStr1k3r.SDK;
using System.Threading;
using DerStr1k3r.RemoteEventManager;

class InteractMenu : Script
{
    private static nLog Log = new nLog("InteractMenu");
    public static List<dynamic> animation_list = new List<dynamic>();

    [RemoteEvent("keypress:I")]
    public void KeyPressI(Client player)
    {
        if (AccountManage.GetPlayerConnected(player))
        {
            //if (player.GetData("fishing") == true)
            //{
            //    Main.DisplayErrorMessage(player, "Sie können während des Angelns kein Inventar verwenden.");
            //    return;
            //}
            Inventory.ShowPlayerInventory(player);
        }
    }

    public static void ShowPlayerInteractMenu(Client player)
    {
        InteractMenu_New.ShowPlayerInteractMenu(player);
    }

    public static void CreateMenu(Client player, string callback, string title, string description, bool freezePlayer, string json, bool resetBack, string BackgroundSprite = "none", string BackgroundColor = "none", int CurrentSelect = 0, bool MouseControl = false)
    {
        player.SetData("NativeUi_Menu", true);
        NAPI.ClientEvent.TriggerClientEvent(player, "menu_handler_create_menu_generic", callback, title, description, freezePlayer, json, resetBack, BackgroundSprite, BackgroundColor, CurrentSelect, MouseControl);
    }


    public static void ShowPlayerFactionMenu(Client player)
    {
        int index = AccountManage.GetPlayerGroup(player);

        if (index == 0)
        {
            Main.DisplayErrorMessage(player, "Du bist nicht in einer Fraktion..");
            ShowPlayerInteractMenu(player);
            return;
        }

        if (index == 0)
        {
            Main.DisplayErrorMessage(player, "Du bist nicht in einer Fraktion.");
            ShowPlayerInteractMenu(player);
            return;
        }

        List<dynamic> menu_item_list = new List<dynamic>();
        menu_item_list.Add(new { Type = 1, Name = "Botschaft des Tages", Description = FactionManage.faction_data[index].faction_motd, RightBadge = "Crown" });
        if (FactionManage.GetPlayerGroupType(player) == FactionManage.FACTION_TYPE_POLICE || FactionManage.GetPlayerGroupType(player) == FactionManage.FACTION_TYPE_MEDIC || FactionManage.GetPlayerGroupType(player) == FactionManage.FACTION_TYPE_ACLS || FactionManage.GetPlayerGroupType(player) == FactionManage.FACTION_TYPE_DOJ || FactionManage.GetPlayerGroupType(player) == FactionManage.FACTION_TYPE_LSSECRETSERVICE || FactionManage.GetPlayerGroupType(player) == FactionManage.FACTION_TYPE_NOOSETEAM || FactionManage.GetPlayerGroupType(player) == FactionManage.FACTION_TYPE_TAXI || FactionManage.GetPlayerGroupType(player) == FactionManage.FACTION_TYPE_LSC || FactionManage.GetPlayerGroupType(player) == FactionManage.FACTION_TYPE_BENNYS)
        {
            menu_item_list.Add(new { Type = 1, Name = "Bürgerschaft Benachrichtigung", Description = "Benachrichtigung an alle Bürger", RightBadge = "Crown" });
        }
        if (FactionManage.GetPlayerGroupType(player) == FactionManage.FACTION_TYPE_POLICE || FactionManage.GetPlayerGroupType(player) == FactionManage.FACTION_TYPE_MEDIC || FactionManage.GetPlayerGroupType(player) == FactionManage.FACTION_TYPE_ACLS || FactionManage.GetPlayerGroupType(player) == FactionManage.FACTION_TYPE_TAXI)
        {
            menu_item_list.Add(new { Type = 1, Name = "Leitstelle", Description = "Ab und Anmeldung", RightBadge = "Crown" });
        }
        if (FactionManage.GetPlayerGroupType(player) == FactionManage.FACTION_TYPE_ACLS)
        {
            menu_item_list.Add(new { Type = 1, Name = "Dienst melden", Description = "Ab und Anmeldung", RightBadge = "Crown" });
        }
        menu_item_list.Add(new { Type = 1, Name = "Mitglieder verwalten", Description = "", RightBadge = "Crown" });
        menu_item_list.Add(new { Type = 1, Name = "Hierarchie verwalten", Description = "", RightBadge = "Crown" });
        menu_item_list.Add(new { Type = 1, Name = "Liste der Mitglieder", Description = "" });
        menu_item_list.Add(new { Type = 1, Name = "Fraktion verlassen", Description = "", RightBadge = "Alert", Color = "OrangeRed", HighlightColor = "Tomato" });

        InteractMenu.CreateMenu(player, "PLAYER_FACTION_MENU", "Fraktion", "~b~" + FactionManage.faction_data[index].faction_name + "", false, JsonConvert.SerializeObject(menu_item_list), false);
    }



    [RemoteEvent("menu_handler_select_item_generic")]
    public void menu_handler_select_item_generic(Client player, String callbackId, int selectedIndex, String objectName, String valueList)
    {

        if (callbackId == "PLAYER_FACTION_MENU_MEMBER")
        {
            //string name = player.GetData("ListTrack_" + selectedIndex);
            player.SetData("LisTrack_ID", selectedIndex);

            int index = AccountManage.GetPlayerGroup(player);

            if (index == 0)
            {
                Main.DisplayErrorMessage(player, "Du bist nicht in einer Fraktion..");
                ShowPlayerInteractMenu(player);
                return;
            }

            List<dynamic> menu_item_list = new List<dynamic>();
            if (AccountManage.GetPlayerLeader(player) != 0)
            {
                menu_item_list.Add(new { Type = 1, Name = "befördern/degradieren", Description = "" });
                //menu_item_list.Add(new { Type = 1, Name = "Mitglied entlassen", Description = "" });
            }
            else
            {
                ShowPlayerFactionMenu(player);
            }

            InteractMenu.CreateMenu(player,  "PLAYER_FACTION_INFO", "Fraktion", "~b~" + FactionManage.faction_data[index].faction_name + "", false, JsonConvert.SerializeObject(menu_item_list), false);
        }
        else if (callbackId == "PLAYER_FACTION_INFO")
        {
            int index = AccountManage.GetPlayerGroup(player);

            if (index == 0)
            {
                Main.DisplayErrorMessage(player, "Du bist nicht in einer Fraktion.");
                ShowPlayerInteractMenu(player);
                return;
            }

            if (AccountManage.GetPlayerLeader(player) == 0)
            {
                Main.DisplayErrorMessage(player, "Du bist kein Fraktionsführer..");
                return;
            }

            string name = NAPI.Data.GetEntityData(player, "ListTrack_" + player.GetData("LisTrack_ID"));
            int leader = 0;
            int group = 0;
            int group_rank = 0;

            using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
            {
                Mainpipeline.Open();
                MySqlCommand query = new MySqlCommand("SELECT `name`, `leader`, `group`, `group_rank` FROM characters WHERE `name` = '" + name + "' LIMIT 1;", Mainpipeline);
                using (MySqlDataReader reader = query.ExecuteReader())
                {
                    List<dynamic> menu_item_list = new List<dynamic>();
                    while (reader.Read())
                    {
                        leader = reader.GetInt32("leader");
                        group = reader.GetInt32("group");
                        group_rank = reader.GetInt32("group_rank");
                    }
                }
            }

            if (group == 0)
            {
                return;
            }

            if (selectedIndex == 0)
            {
                List<dynamic> menu_item_list = new List<dynamic>();
                for (int i = 0; i < FactionManage.MAX_FACTION_RANK; i++)
                {
                    if (FactionManage.faction_data[group].faction_rank[i] == "undefiniert")
                    {
                        menu_item_list.Add(new { Type = 4, Name = "Rank " + i + ".", Description = "", RightLabel = "~c~undefiniert" });
                    }
                    else
                    {
                        menu_item_list.Add(new { Type = 4, Name = "Rank " + i + ".", Description = "", RightLabel = "~s~" + FactionManage.faction_data[group].faction_rank[i] + "" });
                    }
                }
                InteractMenu.CreateMenu(player,  "PLAYER_FACTION_GIVERANK", "Fraktion", "~b~" + FactionManage.faction_data[index].faction_name + " - befördern/degradieren", false, JsonConvert.SerializeObject(menu_item_list), false);
            }
            else if (selectedIndex == 1)
            {

            }
        }
        else if (callbackId == "PLAYER_FACTION_MENU_HIERARQUIA")
        {
            int index = AccountManage.GetPlayerGroup(player);

            if (index == 0)
            {
                Main.DisplayErrorMessage(player, "Du bist nicht in einer Fraktion..");
                ShowPlayerInteractMenu(player);
                return;
            }

            if (AccountManage.GetPlayerLeader(player) == 0)
            {
                Main.DisplayErrorMessage(player, "Du bist kein Fraktionsführer.");
                return;
            }

            player.SetData("faction_editing_rank", selectedIndex);
            User_Input(player, "input_player_faction_rank", "Name des Rank", FactionManage.faction_data[index].faction_rank[selectedIndex]);

            FactionManage.SaveFactionRanks(selectedIndex);
        }
        else if (callbackId == "PLAYER_FACTION_GIVERANK")
        {
            int index = AccountManage.GetPlayerGroup(player);

            if (index == 0)
            {
                Main.DisplayErrorMessage(player, "Du bist nicht in einer Fraktion..");
                ShowPlayerInteractMenu(player);
                return;
            }

            if (AccountManage.GetPlayerLeader(player) == 0)
            {
                Main.DisplayErrorMessage(player, "Du bist kein Fraktionsführer..");
                return;
            }

            string name = NAPI.Data.GetEntityData(player, "ListTrack_" + player.GetData("LisTrack_ID"));
            int leader = 0;
            int group = 0;
            int group_rank = 0;

            using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
            {

                Mainpipeline.Open();
                MySqlCommand query = new MySqlCommand("SELECT `name`, `leader`, `group`, `group_rank` FROM characters WHERE `name` = '" + name + "' LIMIT 1;", Mainpipeline);
                using (MySqlDataReader reader = query.ExecuteReader())
                {
                    var count = 0;

                    List<dynamic> menu_item_list = new List<dynamic>();
                    while (reader.Read())
                    {
                        leader = reader.GetInt32("leader");
                        group = reader.GetInt32("group");
                        group_rank = reader.GetInt32("group_rank");
                    }
                }
            }


            var players = NAPI.Pools.GetAllPlayers();
            foreach (var member in players)
            {
                if (member.GetData("status") == true)
                {
                    if (AccountManage.GetCharacterName(player) == name.Replace("_", " "))
                    {
                        NAPI.Notification.SendNotificationToPlayer(player, "~y~INFO:~w~ Du hast das gegeben " + name + " den Rang " + FactionManage.faction_data[index].faction_rank[selectedIndex] + ".");
                        NAPI.Notification.SendNotificationToPlayer(member, "~y~INFO:~w~ " + AccountManage.GetCharacterName(player) + " Hast nun folgenden Rang " + FactionManage.faction_data[index].faction_rank[selectedIndex] + ".");

                        AccountManage.SaveCharacter(member);
                    }
                    else
                    {
                        NAPI.Notification.SendNotificationToPlayer(player,"~y~INFO:~w~ Du hast das gegeben " + name + " den Rang " + FactionManage.faction_data[index].faction_rank[selectedIndex] + ".");
                        Main.CreateMySqlCommand("UPDATE `characters` SET `group_rank` = " + selectedIndex + " WHERE `name` = '" + NAPI.Data.GetEntityData(player, "ListTrack_" + player.GetData("LisTrack_ID")) + "';");
                    }
                }
            }
        }

        if (callbackId == "interaction_menu")
        {
            switch (selectedIndex)
            {
                case 0: break;
                case 1:
                    {
                        List<dynamic> menu_item_list = new List<dynamic>();
                        menu_item_list.Add(new { Type = 1, Name = "Auto Parken", Description = "" });
                        menu_item_list.Add(new { Type = 1, Name = "Fahrzeug finden", Description = "" });

                        InteractMenu.CreateMenu(player,  "interecation_vehicle_response", "Player Menu", "~B~INTERAKTIONSMENÜ: ", false, JsonConvert.SerializeObject(menu_item_list), false);
                        break;
                    }
                case 2:
                    // Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Menu em construcao.");
                    ShowPlayerFactionMenu(player);
                    break;
                case 3:
                    //Main.command_stats(player);
                    break;
                case 4:
                    {
                        var players = NAPI.Pools.GetAllPlayers();
                        foreach (var target in players)
                        {
                            if (target.GetData("status") == true && Main.IsInRangeOfPoint(player.Position, target.Position, 5f) && player != target)
                            {
                                InteractMenu_New.ShowPlayerInfos(player, target);
                                return;
                            }
                        }
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Es sind keine Bürger in Ihrer Nähe.", 5000);

                        break;
                    }
                case 5:
                    {
                        var players = NAPI.Pools.GetAllPlayers();
                        foreach (var target in players)
                        {
                            if (target.GetData("status") == true)
                            {
                                if (Main.IsInRangeOfPoint(player.Position, target.Position, 5f) && player != target)
                                {
                                    //Main.ShowPlayerStats(player, target);
                                    player.SetData("interact_target", target);
                                    User_Input(player, "interactMenu_giveMoney", "Geld zu geben " + AccountManage.GetCharacterName(target) + "", "100", "", "number");
                                    return;
                                }
                            }
                        }
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Es sind keine Spieler in Ihrer Nähe.", 5000);
                        break;
                    }
                case 6:
                    {
                        var players = NAPI.Pools.GetAllPlayers();
                        foreach (var target in players)
                        {
                            if (target.GetData("status") == true)
                            {
                                if (Main.IsInRangeOfPoint(player.Position, target.Position, 5f) && player != target)
                                {
                                    //Main.ShowPlayerStats(player, target);
                                    player.SetData("interact_target", target);
                                    User_Input(player, "interactMenu_sellVehicle", "Fahrzeug Verkaufen an " + AccountManage.GetCharacterName(target) + "", "100", "", "number");
                                    return;
                                }
                            }
                        }
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Es sind keine Spieler in Ihrer Nähe.", 5000);
                        break;
                    }
                case 7:
                    {
                        break;
                    }
            }
            return;
        }
        else if (callbackId == "interecation_vehicle_response")
        {
            if (selectedIndex == 0)
            {
                PlayerVehicle.ShowPlayerVehicles(player);
            }
            else if (selectedIndex == 1)
            {
                //PlayerVehicle.ShowPlayerVehiclesToTrack(player);
            }
            return;
        }
        else if (callbackId == "PLAYER_LIST_RESPONSE")
        {
            //player.SetData("ListTrack_"+ i + "", AccountManage.GetCharacterName(Main.players[i]));

            if (AccountManage.GetPlayerAdmin(player) == 10)
            {
                player.SetData("ListTrack_ID", selectedIndex);
                string name = NAPI.Data.GetEntityData(player, "ListTrack_" + player.GetData("ListTrack_ID") + "");
                List<dynamic> menu_item_list = new List<dynamic>();
                menu_item_list.Add(new { Type = 1, Name = "Telerpotar", Description = "" });
                menu_item_list.Add(new { Type = 1, Name = "Trazer", Description = "" });
                menu_item_list.Add(new { Type = 1, Name = "Geld geben", Description = "" });
                menu_item_list.Add(new { Type = 1, Name = "Remover da Facção", Description = "" });
                menu_item_list.Add(new { Type = 1, Name = "Kick", Description = "" });
                menu_item_list.Add(new { Type = 1, Name = "Ban", Description = "" });
                InteractMenu.CreateMenu(player,  "PLAYER_LIST_ADMIN_CALL", "Admin", "~b~Manage Player -> ~s~" + name + ":", false, JsonConvert.SerializeObject(menu_item_list), false);
            }
            else
            {

            }
        }
        else if (callbackId == "PLAYER_LIST_ADMIN_CALL")
        {

            if (!player.HasData("ListTrack_" + player.GetData("ListTrack_ID") + ""))
            {
                return;
            }
            string name = NAPI.Data.GetEntityData(player, "ListTrack_" + player.GetData("ListTrack_ID") + "").Replace(" ", "_");
            Client target = Main.findPlayer(player, name);

            if (target == null)
            {
                Main.DisplayErrorMessage(player, "Bürger abgemeldet.");
                return;
            }

            switch (selectedIndex)
            {
                case 0:
                    {
                        if (AccountManage.GetPlayerAdmin(player) < 1)
                        {
                            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben keine Berechtigung, diesen Befehl zu verwenden.");
                            return;
                        }

                        if (target.GetData("status") != true)
                        {
                            NAPI.Notification.SendNotificationToPlayer(player, "Dieser Bürger ist nicht angemeldet.");
                            return;
                        }
                        if (player.IsInVehicle && player.VehicleSeat == -1)
                        {
                            Vehicle vehicle = player.Vehicle;
                            vehicle.Position = target.Position;
                            vehicle.Dimension = target.Dimension;
                            player.Dimension = target.Dimension;
                            player.SetIntoVehicle(vehicle, -1);
                            player.TriggerEvent("createNewHeadNotificationAdvanced", "Sie wurden teleportiert.");
                        }
                        else
                        {
                            player.Position = target.Position;
                            player.Dimension = target.Dimension;
                            player.TriggerEvent("createNewHeadNotificationAdvanced", "Sie wurden teleportiert.");
                        }
                        break;
                    }
                case 1:
                    {
                        if (AccountManage.GetPlayerAdmin(player) < 1)
                        {
                            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben keine Berechtigung, diesen Befehl zu verwenden.");
                            return;
                        }

                        if (target.GetData("status") != true)
                        {
                            NAPI.Notification.SendNotificationToPlayer(player, "Dieser Bürger ist nicht angemeldet.");
                            return;
                        }
                        if (target.IsInVehicle && target.VehicleSeat == -1)
                        {
                            Vehicle vehicle = target.Vehicle;
                            vehicle.Position = player.Position;
                            vehicle.Dimension = player.Dimension;
                            target.Dimension = player.Dimension;
                            target.SetIntoVehicle(vehicle, -1);
                            target.TriggerEvent("createNewHeadNotificationAdvanced", "Sie wurden teleportiert.");
                        }
                        else
                        {
                            target.Position = player.Position;
                            target.Dimension = player.Dimension;
                            target.TriggerEvent("createNewHeadNotificationAdvanced", "Sie wurden teleportiert.");
                        }
                        break;
                    }
                case 2:
                    {
                        if (AccountManage.GetPlayerAdmin(player) < 2)
                        {
                            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben keine Berechtigung, diesen Befehl zu verwenden.");
                            return;
                        }
                        if (target.GetData("status") != true)
                        {
                            NAPI.Notification.SendNotificationToPlayer(player, "Dieser Bürgre ist nicht da.");
                            return;
                        }
                        User_Input(player, "input_admin_give_money", "Geldbetrag", "0", "", "number");
                        break;
                    }
                case 3:
                    {
                        if (AccountManage.GetPlayerAdmin(player) < 2)
                        {
                            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben keine Berechtigung, diesen Befehl zu verwenden.");
                            return;
                        }
                        if (target.GetData("status") != true)
                        {
                            NAPI.Notification.SendNotificationToPlayer(player, "Dieser Bürgre ist nicht da.");
                            return;
                        }

                        NAPI.Data.SetEntityData(target, "duty", 0);
                        Main.UpdatePlayerClothes(target);
                        target.SetData("duty", 0);
                        Outfits.RemovePlayerDutyOutfit(target);
                        AccountManage.SetPlayerLeader(target, 0);
                        AccountManage.SetPlayerGroup(target, 0);
                        AccountManage.SetPlayerRank(target, 0);
                        AccountManage.SaveCharacter(target);
                        if (player != target) NAPI.Notification.SendNotificationToPlayer(player, "Sie haben die Fraktion von entfernt " + AccountManage.GetCharacterName(target) + " Sie sind nun ~b~civil~w~.");
                        else Main.SendInfoMessage(player, "Der Administrator " + AccountManage.GetCharacterName(player) + " hat sie aus der Fraktion entfernt, Sie sind nun ~b~civil~w~.");
                        Main.SetPlayerToTeamColor(target);
                        break;
                    }
                case 4:
                    {
                        if (AccountManage.GetPlayerAdmin(player) < 1)
                        {
                            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben keine Berechtigung, diesen Befehl zu verwenden..");
                            return;
                        }
                        if (target.GetData("status") != true)
                        {
                            NAPI.Notification.SendNotificationToPlayer(player, "Dieser Bürgre ist nicht da.");
                            return;
                        }

                        NAPI.Chat.SendChatMessageToAll("~y~-OperServ- Der Spieler " + AccountManage.GetCharacterName(target) + " kickt " + AccountManage.GetCharacterName(player) + ".");
                        target.Kick();
                        break;
                    }
                case 5:
                    {
                        if (AccountManage.GetPlayerAdmin(player) < 1)
                        {
                            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben keine Berechtigung, diesen Befehl zu verwenden..");
                            return;
                        }
                        if (target.GetData("status") != true)
                        {
                            NAPI.Notification.SendNotificationToPlayer(player, "Dieser Bürger ist nicht da.");
                            return;
                        }

                        NAPI.Chat.SendChatMessageToAll("~y~-OperServ- Der Spieler " + AccountManage.GetCharacterName(target) + " bannend " + AccountManage.GetCharacterName(player) + ".");
                        target.Ban();
                        break;
                    }
            }
        }
        else if (callbackId == "INTERACT_DOOR_VEHICLE_RESPONSE")
        {
            if (!player.IsInVehicle && player.VehicleSeat != -1)
            {
                return;
            }
        }
        else if(callbackId == "PLAYER_TELEPORT")
        {
            int house_id = player.GetData("List_Track_" + selectedIndex);


            if (HouseSystem.HouseInfo[house_id].exterior.X == 0 && HouseSystem.HouseInfo[house_id].exterior.Y == 0)
            {
                return;
            }

            player.TriggerEvent("moveSkyCamera", player, "up", 1, false);
            NAPI.Task.Run(() =>
            {

                player.Position = HouseSystem.HouseInfo[house_id].interior;
                player.Rotation = new Vector3(0, 0, HouseSystem.HouseInfo[house_id].interior_a);
                player.Dimension = 500 + (uint)house_id;
                player.TriggerEvent("moveSkyCamera", player, "down");
            }, delayTime: 4000);
        }
        else
        {
            illegaleWaffen.SelectMenuResponse(player, callbackId, selectedIndex, objectName, valueList);
            InteractMenu_New.SelectMenuResponse(player, callbackId, selectedIndex, objectName, valueList);
            Business.SelectMenuResponse(player, callbackId, selectedIndex, objectName, valueList);
            FactionManage.SelectMenuResponse(player, callbackId, selectedIndex, objectName, valueList);
            Police.SelectMenuResponse(player, callbackId, selectedIndex, objectName, valueList);
            AclsService.SelectMenuResponse(player, callbackId, selectedIndex, objectName, valueList);
            SecretService.SelectMenuResponse(player, callbackId, selectedIndex, objectName, valueList);
            NooseTeam.SelectMenuResponse(player, callbackId, selectedIndex, objectName, valueList);
            RentVehicle.SelectMenuResponse(player, callbackId, selectedIndex, objectName, valueList);
            Menus.SelectMenuResponse(player, callbackId, selectedIndex, objectName, valueList);
            WerehouseManage.SelectMenuResponse(player, callbackId, selectedIndex, objectName, valueList);
            GangueManage.SelectMenuResponse(player, callbackId, selectedIndex, objectName, valueList);
            Fish.SelectMenuResponse(player, callbackId, selectedIndex, objectName, valueList);
            Shipment.SelectMenuResponse(player, callbackId, selectedIndex, objectName, valueList);
            GeneralStore.SelectMenuResponse(player, callbackId, selectedIndex, objectName, valueList);
            FreeTimeStore.SelectMenuResponse(player, callbackId, selectedIndex, objectName, valueList);
            JuveStore.SelectMenuResponse(player, callbackId, selectedIndex, objectName, valueList);
            PhoneStore.SelectMenuResponse(player, callbackId, selectedIndex, objectName, valueList);
            ATMSystem.SelectMenuResponse(player, callbackId, selectedIndex, objectName, valueList);
            CanineSystem.SelectMenuResponse(player, callbackId, selectedIndex, objectName, valueList);
            Weed.SelectMenuResponse(player, callbackId, selectedIndex, objectName, valueList);
            cellphoneSystem.SelectMenuResponse(player, callbackId, selectedIndex, objectName, valueList);
            Bennys.SelectMenuResponse(player, callbackId, selectedIndex, objectName, valueList);
            LSCustom.SelectMenuResponse(player, callbackId, selectedIndex, objectName, valueList);
            LostMCCustom.SelectMenuResponse(player, callbackId, selectedIndex, objectName, valueList);
            DriverLicense.SelectMenuResponse(player, callbackId, selectedIndex, objectName, valueList);
            BlackMarket.SelectMenuResponse(player, callbackId, selectedIndex, objectName, valueList);
            PoliceStore.SelectMenuResponse(player, callbackId, selectedIndex, objectName, valueList);
            LKWStore.SelectMenuResponse(player, callbackId, selectedIndex, objectName, valueList);
            LSCCostumStore.SelectMenuResponse(player, callbackId, selectedIndex, objectName, valueList);
            MedicSnackStore.SelectMenuResponse(player, callbackId, selectedIndex, objectName, valueList);
            ACLSStore.SelectMenuResponse(player, callbackId, selectedIndex, objectName, valueList);
            HouseStore.SelectMenuResponse(player, callbackId, selectedIndex, objectName, valueList);
            CarDealerSnackStore.SelectMenuResponse(player, callbackId, selectedIndex, objectName, valueList);
            MedicStore.SelectMenuResponse(player, callbackId, selectedIndex, objectName, valueList);
            UsefullyRP.SelectMenuResponse(player, callbackId, selectedIndex, objectName, valueList);
            UserMenu.SelectMenuResponse(player, callbackId, selectedIndex, objectName, valueList);
            HouseSystem.SelectMenuResponse(player, callbackId, selectedIndex, objectName, valueList);
            GarageSys.SelectMenuResponse(player, callbackId, selectedIndex, objectName, valueList);
            Barber.SelectMenuResponse(player, callbackId, selectedIndex, objectName, valueList);
            femaleClothes.SelectMenuResponse(player, callbackId, selectedIndex, objectName, valueList);
            TattooShop.SelectMenuResponse(player, callbackId, selectedIndex, objectName, valueList);
            animationCommands.SelectMenuResponse(player, callbackId, selectedIndex, objectName, valueList);
            Hotel.SelectMenuResponse(player, callbackId, selectedIndex, objectName, valueList);
            Zulassung.SelectMenuResponse(player, callbackId, selectedIndex, objectName, valueList);
            JobCenter.SelectMenuResponse(player, callbackId, selectedIndex, objectName, valueList);
            LOrder.SelectMenuResponse(player, callbackId, selectedIndex, objectName, valueList);
            Schlüsseldienst.SelectMenuResponse(player, callbackId, selectedIndex, objectName, valueList);
            cellphoneSystem.SelectMenuResponse(player, callbackId, selectedIndex, objectName, valueList);
            Gopostal.SelectMenuResponse(player, callbackId, selectedIndex, objectName, valueList);
        }
    }

    [RemoteEvent("menu_handler_index_change_generic")]
    public void IndexChangeMenuResponse(Client player, String callbackId, int selectedIndex, String objectName, String valueList)
    {
        InteractMenu_New.IndexChangeMenuResponse(player, callbackId, selectedIndex, objectName, valueList);
        Police.IndexChangeMenuResponse(player, callbackId, selectedIndex, objectName, valueList);
        //SecretService.IndexChangeMenuResponse(player, callbackId, selectedIndex, objectName, valueList);
        //Menus.IndexChangeMenuResponse(player, callbackId, selectedIndex, objectName, valueList);
        Bennys.IndexChangeMenuResponse(player, callbackId, selectedIndex, objectName, valueList);
        LSCustom.IndexChangeMenuResponse(player, callbackId, selectedIndex, objectName, valueList);
        LostMCCustom.IndexChangeMenuResponse(player, callbackId, selectedIndex, objectName, valueList);
        UsefullyRP.IndexChangeMenuResponse(player, callbackId, selectedIndex, objectName, valueList);
        Barber.IndexChangeMenuResponse(player, callbackId, selectedIndex, objectName, valueList);
        animationCommands.IndexChangeMenuResponse(player, callbackId, selectedIndex, objectName, valueList);
    }

    [RemoteEvent("menu_handler_listchanged_item_generic")]
    public void ListItemMenuResponse(Client player, String callbackId, int selectedIndex, String objectName, String valueList, int valueIndex)
    {
        WerehouseManage.ListItemMenuResponse(player, callbackId, selectedIndex, objectName, valueList, valueIndex);
        InteractMenu_New.ListItemMenuResponse(player, callbackId, selectedIndex, objectName, valueList, valueIndex);
        Business.ListItemMenuResponse(player, callbackId, selectedIndex, objectName, valueList, valueIndex);
        FactionManage.ListItemMenuResponse(player, callbackId, selectedIndex, objectName, valueList, valueIndex);
        Menus.ListItemMenuResponse(player, callbackId, selectedIndex, objectName, valueList, valueIndex);
        CanineSystem.ListItemMenuResponse(player, callbackId, selectedIndex, objectName, valueList, valueIndex);
        Barber.ListItemMenuResponse(player, callbackId, selectedIndex, objectName, valueList, valueIndex);
        femaleClothes.ListItemMenuResponse(player, callbackId, selectedIndex, objectName, valueList, valueIndex);
        TattooShop.ListItemMenuResponse(player, callbackId, selectedIndex, objectName, valueList, valueIndex);
        //Police.ListItemMenuResponse(player, callbackId, selectedIndex, objectName, valueList, valueIndex);
    }


    [RemoteEvent("menu_handler_checked_item_generic")]
    public void CheckBoxItemMenuResponse(Client player, String callbackId, int selectedIndex, String objectName, String valueList, bool _checked)
    {
        InteractMenu_New.CheckBoxItemMenuResponse(player, callbackId, selectedIndex, objectName, valueList, _checked);
        Business.CheckBoxItemMenuResponse(player, callbackId, selectedIndex, objectName, valueList, _checked);
        HouseSystem.CheckBoxItemMenuResponse(player, callbackId, selectedIndex, objectName, valueList, _checked);
    }

    [RemoteEvent("menu_handler_on_close")]
    public void OnMenuReturnClose(Client player, String callbackId)
    {
        player.SetData("NativeUi_Menu", false);
        NAPI.Task.Run(() =>
        {
           // InteractMenu_New..OnMenuReturnClose(player, callbackId);
            FactionManage.OnMenuReturnClose(player, callbackId);
            Police.OnMenuReturnClose(player, callbackId);
            AclsService.OnMenuReturnClose(player, callbackId);
            SecretService.OnMenuReturnClose(player, callbackId);
            NooseTeam.OnMenuReturnClose(player, callbackId);
            Menus.OnMenuReturnClose(player, callbackId);
            WerehouseManage.OnMenuReturnClose(player, callbackId);
            GangueManage.OnMenuReturnClose(player, callbackId);
            Bennys.OnMenuReturnClose(player, callbackId);
            LSCustom.OnMenuReturnClose(player, callbackId);
            LostMCCustom.OnMenuReturnClose(player, callbackId);
            UsefullyRP.OnMenuReturnClose(player, callbackId);
            HouseSystem.OnMenuReturnClose(player, callbackId);
            Barber.OnMenuReturnClose(player, callbackId);
            femaleClothes.OnMenuReturnClose(player, callbackId);
            TattooShop.OnMenuReturnClose(player, callbackId);
        }, delayTime: 500);
    }

    // Input Text By Mike
    [RemoteEvent("uiInput_response")]
    public void OnInputResponse(Client player, String response, String inputtext)
    {
        if (response == "interactMenu_giveMoney")
        {
            Client target = NAPI.Data.GetEntityData(player, "interact_target");
            if (!NAPI.Player.IsPlayerConnected(target))
            {
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Dieser Bürger ist nicht mehr angeschlossen.", 5000);
                return;
            }
            if (target.GetData("status") == false)
            {
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Dieser Bürger ist nicht mehr angeschlossen..", 5000);
                return;
            }
            if (!Main.IsInRangeOfPoint(player.Position, target.Position, 5f))
            {
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Dieser Bürger ist nicht mehr in Ihrer Nähe.", 5000);
                return;
            }

            if (!Main.IsNumeric(inputtext))
            {
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Ungültiger eingegebener Wert.", 5000);
                return;
            }

            if (inputtext.Length == 0)
            {
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Die Menge kann nicht kleiner als 1 sein.", 5000);
                return;
            }

            int value = Convert.ToInt32(inputtext);

            if (value < 1)
            {
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Der Wert darf nicht unter 1 USD oder über 100.000 USD liegen.", 5000);
                return;
            }

            if (value > 100000)
            {
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Der Wert darf nicht unter 1 USD oder über 100.000 USD liegen.", 5000);
                return;
            }

            if (Main.GetPlayerMoney(player) < value)
            {
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie haben nicht das ganze Geld.", 5000);
                return;
            }

            Main.GivePlayerMoney(player, -value);
            Main.GivePlayerMoney(target, value);
            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du hast $" + value.ToString("N0") + " zu " + AccountManage.GetCharacterName(target) + " bezahlt.", 5000);
            target.SendNotification("~g~Erfolgreich~n~~w~Du hast erhalten ~g~$" + value.ToString("N0") + "~w~ von ~y~" + AccountManage.GetCharacterName(player) + "~w~.");
        }
        else if (response == "interactMenu_sellVehicle")
        {
            Client target = NAPI.Data.GetEntityData(player, "interact_target");
            if (!NAPI.Player.IsPlayerConnected(target))
            {
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Dieser Bürger ist nicht mehr angeschlossen.", 5000);
                return;
            }
            if (target.GetData("status") == false)
            {
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Dieser Bürger ist nicht mehr angeschlossen..", 5000);
                return;
            }
            if (!Main.IsInRangeOfPoint(player.Position, target.Position, 5f))
            {
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Dieser Bürger ist nicht mehr in Ihrer Nähe.", 5000);
                return;
            }

            if (!Main.IsNumeric(inputtext))
            {
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Ungültiger eingegebener Wert.", 5000);
                return;
            }

            if (inputtext.Length == 0)
            {
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Die Menge kann nicht kleiner als 1 sein.", 5000);
                return;
            }

            int value = Convert.ToInt32(inputtext);

            if (value < 1)
            {
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Der Wert darf nicht unter 1 USD oder über 100.000 USD liegen.", 5000);
                return;
            }

            if (value > 100000)
            {
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Der Wert darf nicht unter 1 USD oder über 100.000 USD liegen.", 5000);
                return;
            }

            int playerid = Main.getIdFromClient(player);
            

            for (int index = 0; index < PlayerVehicle.MAX_PLAYER_VEHICLES; index++)
            {
                if (PlayerVehicle.vehicle_data[playerid].state[index] == 1)
                {
                    if (PlayerVehicle.vehicle_data[playerid].handle[index].Exists && PlayerVehicle.vehicle_data[playerid].handle[index] == player.Vehicle)
                    {
                        if (player.Vehicle.Model == (uint)VehicleHash.Pbus2)
                        {
                            Main.SendErrorMessage(player, "Sie können dieses Fahrzeug nicht verkaufen, da es ausschließlich für Fonder bestimmt ist.");
                            return;
                        }

                        Main.SendInfoMessage(player, "Wird Ihr Angebot ~g~angenommen?~w~");


                        target.SetData("vehicle_offer_id", index);
                        target.SetData("vehicle_offer_price", value);
                        target.SetData("vehicle_offer_handle", player);

                        InteractMenu.ShowModal(target, "VEHICLE_SELL_TO_PLAYER", "Gebrauchtwagenhandel, gekauft wie gesehen", "" + AccountManage.GetCharacterName(player) + " bietet Dir folgenden Fahrzeugtyp  " + PlayerVehicle.vehicle_data[playerid].model[index] + " an.", "Angebot annehmen.", "Angebot ablehnen.") ;
                        return;
                    }
                }
            }
        }
        else if (response == "interact_faction_motd")
        {
            if (inputtext.Length > 128)
            {
                Main.DisplayErrorMessage(player, "Die Anzahl der Zeichen muss zwischen 5 und 128 liegen.");
                return;
            }
            if (inputtext.Length < 5)
            {
                Main.DisplayErrorMessage(player, "Die Anzahl der Zeichen muss zwischen 5 und 128 liegen.");
                return;
            }
            int index = AccountManage.GetPlayerGroup(player);

            if (index == 0)
            {
                Main.DisplayErrorMessage(player, "Du bist nicht in einer Fraktion..");
                return;
            }

            FactionManage.faction_data[index].faction_motd = inputtext;

            FactionManage.SendFactionMessage(index, "~y~Neue Nachricht des Tages:~w~ ");
            FactionManage.SendFactionMessage(index, "~y~•~w~ " + inputtext);
        }
        else if (response == "interact_faction_rplerinfo")
        {
            if (inputtext.Length > 256)
            {
                Main.DisplayErrorMessage(player, "Die Anzahl der Zeichen muss zwischen 5 und 256 liegen.");
                return;
            }
            if (inputtext.Length < 5)
            {
                Main.DisplayErrorMessage(player, "Die Anzahl der Zeichen muss zwischen 5 und 256 liegen.");
                return;
            }
            int index = AccountManage.GetPlayerGroup(player);

            if (index == 0)
            {
                Main.DisplayErrorMessage(player, "Du bist nicht in einer Fraktion..");
                return;
            }

            FactionManage.faction_data[index].faction_rplerinfo = inputtext;
            foreach (var target in NAPI.Pools.GetAllPlayers())
            {
                Notify.Send(target, NotifyType.Info, NotifyPosition.BottomCenter, $"Nachricht von " + FactionManage.faction_data[index].faction_name + ":  " + inputtext + "", 15000);
                //NAPI.Notification.SendNotificationToAll("Bürgerschaft Benachrichtigung von: " + FactionManage.faction_data[index].faction_name + " \n " + inputtext + "");
                //NAPI.ClientEvent.TriggerClientEvent(target, "Notification.SendPictureNotification", "" + FactionManage.faction_data[index].faction_name + "", "Bürgerschaft Benachrichtigung", $" " + inputtext + "", "CHAR_HUMANDEFAULT", true);
            }
        }
        else if (response == "input_admin_give_money")
        {
            string name = NAPI.Data.GetEntityData(player, "ListTrack_" + player.GetData("ListTrack_ID") + "").Replace(" ", "_"); ;

            Client target = Main.findPlayer(player, name);

            if (target == null)
            {
                Main.DisplayErrorMessage(player, "Dieser Bürger ist nicht mehr angeschlossen.");
                return;
            }

            if (!Main.IsNumeric(inputtext))
            {
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Ungültiger eingegebener Wert.", 5000);
                return;
            }

            if (inputtext.Length == 0)
            {
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Die Menge kann nicht kleiner als 1 sein.", 5000);
                return;
            }

            int value = Convert.ToInt32(inputtext);

            Main.GivePlayerMoney(target, value);
            AccountManage.SaveCharacter(target);

            if (player != target) NAPI.Notification.SendNotificationToPlayer(player, "Du hast gegeben~g~$~y~" + value.ToString("N0") + "~w~ zu ~y~" + AccountManage.GetCharacterName(target) + ".");
            else Main.SendInfoMessage(player, "Der Administrator" + AccountManage.GetCharacterName(player) + "hat dir gegeben~g~$~y~" + value.ToString("N0") + "~.");
        }

        Apfel.OnInputResponse(player, response, inputtext);
        Beer.OnInputResponse(player, response, inputtext);
        Bergbau.OnInputResponse(player, response, inputtext);
        Blutwaschen.OnInputResponse(player, response, inputtext);
        Holz.OnInputResponse(player, response, inputtext);
        Pelz.OnInputResponse(player, response, inputtext);
        Penicillin.OnInputResponse(player, response, inputtext);
        Traube.OnInputResponse(player, response, inputtext);
        Wodka.OnInputResponse(player, response, inputtext);

        Farm.OnInputResponse(player, response, inputtext);
        Salt.OnInputResponse(player, response, inputtext);
        Weed.OnInputResponse(player, response, inputtext);
        WerehouseManage.OnInputResponse(player, response, inputtext);
        Business.OnInputResponse(player, response, inputtext);
        FactionManage.OnInputResponse(player, response, inputtext);
        Menus.OnInputResponse(player, response, inputtext);
        GangueManage.OnInputResponse(player, response, inputtext);
        TurfWar.OnInputResponse(player, response, inputtext);
        ATMSystem.OnInputResponse(player, response, inputtext);
        Metall.OnInputResponse(player, response, inputtext);
        EntraceSystem.OnInputResponse(player, response, inputtext);
        SecreatsSystem.OnInputResponse(player, response, inputtext);
        cellphoneSystem.OnInputResponse(player, response, inputtext);
        Farm.OnInputResponse(player, response, inputtext);
        BlackMarket.OnInputResponse(player, response, inputtext);
        Inventory.OnInputResponse(player, response, inputtext);
        HouseSystem.OnInputResponse(player, response, inputtext);
        Zulassung.OnInputResponse(player, response, inputtext);
        InteractMenu_New.OnInputResponse(player, response, inputtext);
    }

    [RemoteEvent("uiInput_destroy")]
    public void uiInput_destroy(Client player, String response)
    {
        Business.OnInputDestroy(player, response);
        //Business.ListItemMenuResponse(player, callbackId, selectedIndex, objectName, valueList);
    }

    public static void User_Input(Client player, string callback, string title, string placeholder, string description = "", string type = "text")
    {
        player.TriggerEvent("uiGeneralInput", callback, title, placeholder, description, type);

    }
    // End Input Text

    [RemoteEvent("Destroy_Menu")]
    public static void CloseDynamicMenu(Client player)
    {
        player.SetData("NativeUi_Menu", false);
        player.TriggerEvent("menu_dynamic_close");
    }


    [RemoteEvent("keypress:INSERT")]
    public void KeyPressINSERT(Client player)
    {
            Main.CMD_VehLocked(player);
    }

    public static void ShowModal(Client player, string callback_id, string title, string text, string bottom_confirm, string bottom_cancel)
    {
        player.TriggerEvent("ShowModal", callback_id, title, text, bottom_confirm, bottom_cancel);
    }

    [RemoteEvent("modalConfirm")]
    public static void modalConfirm(Client player, string response)
    {
        if (response == "GIVE_ITEM")
        {
            /*target.SetData("offer_amount", amount);
                        target.SetData("offer_seller", p);
                        target.SetData("offer_item", p.GetData("inventory_item_" + index + "_type"));
                        target.SetData("offer", true);*/

            Client target = player.GetData("offer_seller");

            if (NAPI.Player.IsPlayerConnected(target) && player.GetData("status") == true)
            {

                int type = player.GetData("offer_item");
                int amount = player.GetData("offer_amount");
                int index = Inventory.GetInventoryIndexFromType(target, type);

                if (Inventory.Check_InventoryWeight_With_ItemAmount(player, type, 1, Inventory.Max_Inventory_Weight(player)))
                {
                    return;
                }

                if (Inventory.player_inventory[Main.getIdFromClient(target)].amount[index] < amount)
                {
                    Main.DisplayErrorMessage(player, "Der Spieler, der Ihnen diesen Gegenstand angeboten hat, besitzt diesen nicht mehr.");
                    return;
                }

                Main.SendSuccessMessage(player, "Você recebeu " + amount + " " + Inventory.itens_available[type].name + " de " + AccountManage.GetCharacterName(target) + ".");
                Main.SendSuccessMessage(target, "Você deu à " + AccountManage.GetCharacterName(target) + " " + amount + " " + Inventory.itens_available[type].name + ".");
                Inventory.GiveItemToInventory(player, type, amount);
                Inventory.RemoveItem(player, Inventory.itens_available[type].name, amount);
            }
        }
        //VIP.ModalConfirm(player, response);
        Weed.ModalConfirm(player, response);
        UsefullyRP.ModalConfirm(player, response);
        PlayerVehicle.ModalConfirm(player, response);
        Lawnmower.ModalConfirm(player, response);
        Bus.ModalConfirm(player, response);
        Collector.ModalConfirm(player, response);
        Garbage.ModalConfirm(player, response);
        Farm.ModalConfirm(player, response);
    }

    [RemoteEvent("modalCancel")]
    public static void ModalCancel(Client player, string response)
    {
        Weed.ModalCancel(player, response);
        Lawnmower.ModalCancel(player, response);
        Bus.ModalCancel(player, response);
        Collector.ModalCancel(player, response);
        Garbage.ModalCancel(player, response);
        Farm.ModalCancel(player, response);
    }

    /*
     *         
     *  List<string> list = new List<string>();
        list.Add("");

        List<dynamic> menu_item_list = new List<dynamic>();
        menu_item_list.Add(new { Type = 6, Name = "", Description = "", List = list, StartIndex = 0 });
        menu_item_list.Add(new { Type = 1, Name = "", Description = "", RightLabel = "" });
        InteractMenu.CreateMenu(player,  "interaction_menu", "Player Menu", "~b~MENU DE INTERACAO:", false, JsonConvert.SerializeObject(menu_item_list), false);

    public static void SelectMenuResponse(Client player, String callbackId, int selectedIndex, String objectName, String valueList)
    {
    }

    public static void IndexChangeMenuResponse(Client player, String callbackId, int selectedIndex, String objectName, String valueList)
    {
    }

    public static void ListItemMenuResponse(Client player, String callbackId, int selectedIndex, String objectName, String valueList, int valueIndex)
    {
    }

    public static void CheckBoxItemMenuResponse(Client player, String callbackId, int selectedIndex, String objectName, String valueList, bool _checked)
    {
       
    }


    public static void OnMenuReturnClose(Client player, String callbackId)
    {
    }

    public static void OnInputResponse(Client player, String response, String inputtext)
    { 
    }
     */
}

