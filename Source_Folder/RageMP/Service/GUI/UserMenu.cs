using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;
using Newtonsoft.Json;

class UserMenu : Script
{
    
    public UserMenu()
    {

    }

    [RemoteEvent("keypress:M")]
    public void KeyPressM(Client player)
    {
        int passed = 0;
        List<Client> proxPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(3, player);
        foreach (Client target in proxPlayers)
        {
           if(target.GetData("status") == true && player != target)
           {
                ShowPlayerUserMenuToTarget(target, player);
                passed = 1;
           }
        }

        if (VehicleInventory.HasVehicleInventory(player) != null)
        {
            VehicleInventory.ShowToPlayerVehicleInventory(player);
        }
        else if (passed == 0)
        {
            HouseSystem.KeyPressM(player);
        }
    }

    [Command("interagir", Alias = "interact, selecionar")]
    public static void CMD_interagir(Client player, string idOrName)
    {
        Client target = Main.findPlayer(player, idOrName);

        if (target == null)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Bürger wurde nicht gefunden oder nicht verbunden.");
            return;
        }

        if (target.GetData("status") == false)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Bürger wurde nicht gefunden oder nicht verbunden..");
            return;
        }

        if(target == player)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Sie können diesen Befehl nicht für sich selbst verwenden.");
            return;
        }

        if(!Main.IsInRangeOfPoint(player.Position, target.Position, 3.0f))
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Sie sind dem Spieler nicht nahe genug, um mit ihm zu interagieren.");
            return;
        }

        ShowPlayerUserMenuToTarget(target, player);
    }

    public static void ShowPlayerUserMenuToTarget(Client player, Client target)
    {
        List<dynamic> menu_item_list = new List<dynamic>();
        List<string> list = new List<string>();

        menu_item_list.Add(new { Type = 1, Name = "Geld geben", Description = "Wählen Sie diese Option, um dem Bürger Geld zu geben." });
        menu_item_list.Add(new { Type = 1, Name = "Online Überweisung", Description = "Hiermit leitest du eine Online Überweisung an." });
        menu_item_list.Add(new { Type = 1, Name = "Ausweis zeigen", Description = "Zeige deinen Ausweis" });
        menu_item_list.Add(new { Type = 1, Name = "Lizenzen zeigen", Description = "zeige deine Lizenzen" });
        menu_item_list.Add(new { Type = 1, Name = "Fahrzeug Verkauf", Description = "zeige deine Lizenzen" });

        if (FactionManage.GetPlayerGroupType(player) == 1)
        {
            menu_item_list.Add(new { Type = 1, Name = "Cop Identität zeigen", Description = "Zeige deinen Dienstausweis" });
        }
        if (FactionManage.GetPlayerGroupType(player) == 2)
        {
            menu_item_list.Add(new { Type = 1, Name = "Medic Identität zeigen", Description = "Zeige deinen Dienstausweis" });
        }
        if (FactionManage.GetPlayerGroupType(player) == 14)
        {
            menu_item_list.Add(new { Type = 1, Name = "President Identität zeigen", Description = "Zeige deinen Dienstausweis" });
        }
        if (AccountManage.GetPlayerGroup(player) == 25)
        {
            menu_item_list.Add(new { Type = 1, Name = "FIB Identität zeigen", Description = "Zeige deinen Dienstausweis" });
        }
        if (AccountManage.GetPlayerGroup(player) == 16)
        {
            menu_item_list.Add(new { Type = 1, Name = "DoJ Identität zeigen", Description = "Zeige deinen Dienstausweis" });
        }
        if (AccountManage.GetPlayerGroup(player) == 26)
        {
            menu_item_list.Add(new { Type = 1, Name = "Army Identität zeigen", Description = "Zeige deinen Dienstausweis" });
        }

        menu_item_list.Add(new { Type = 1, Name = "Haus Schlüssel übergeben", Description = "Hiermit kannst du ein Zweitschlüssel deines Hauses übergeben" });

        if (FactionManage.GetPlayerGroupType(target) == 1)
        {
            if (target.GetData("playerCuffed") == 1)
            {
                menu_item_list.Add(new { Type = 1, Name = "~b~Handschellen ablegen", Description = "Wählen Sie diese Option, um den Bürger zu fesseln." });
            }
            else if (player.GetData("handsup") == true)
            {
                menu_item_list.Add(new { Type = 1, Name = "~b~Bürger durchsuchen", Description = "Wählen Sie die Option, um den Bürger zu durch suchen." });

                if (target.GetData("playerCuffed") == 0)
                {
                    menu_item_list.Add(new { Type = 1, Name = "~b~Handschellen anlegen", Description = "Wählen Sie diese Option, um die Fesseln zu lösen." });
                }
            }
            if (Main.IsInRangeOfPoint(player.Position, new Vector3(1690.666, 2592.404, 45.74735), 3.0f) && !Main.IsInRangeOfPoint(player.Position, new Vector3(-450.0119, 6016.234, 31.71639), 3.0f))
            {
                list.Clear();
                list.Add("auswählen");
                list.Add("10");
                list.Add("15");
                list.Add("20");
                list.Add("25");
                list.Add("30");
                list.Add("35");
                list.Add("40");
                list.Add("45");
                list.Add("50");
                list.Add("55");
                list.Add("60");
                list.Add("65");
                list.Add("70");
                list.Add("75");
                list.Add("80");
                list.Add("85");
                list.Add("90");
                list.Add("95");
                list.Add("100");
                list.Add("110");
                list.Add("115");
                list.Add("120");
                list.Add("125");
                list.Add("130");
                list.Add("135");
                list.Add("140");
                list.Add("145");
                list.Add("150");
                list.Add("155");
                list.Add("160");
                list.Add("165");
                list.Add("170");
                list.Add("175");
                list.Add("180");
                list.Add("185");
                list.Add("190");
                list.Add("195");
                list.Add("200");
                list.Add("210");
                list.Add("215");
                list.Add("220");
                list.Add("225");
                list.Add("230");
                list.Add("235");
                list.Add("240");
                list.Add("245");
                list.Add("250");
                list.Add("255");
                list.Add("260");
                list.Add("265");
                list.Add("270");
                list.Add("275");
                list.Add("280");
                list.Add("285");
                list.Add("290");
                list.Add("295");
                list.Add("300");
                list.Add("400");
                list.Add("500");
                list.Add("600");
                list.Add("700");
                list.Add("800");
                list.Add("900");
                list.Add("1000");
                for (int i = 0; i < 1000; i++) list.Add(i + " Sekunden x 120");
                menu_item_list.Add(new { Type = 2, Name = "~b~Ins Prison stecken", Description = "", List = list, StartIndex = player.GetData("new_interact_menu_arrest") });
            }
            else
            {
                menu_item_list.Add(new { Type = 1, Name = "~b~Ins Prison stecken", Description = "Um jemanden ins Gefängnis zu stecken, erst Eintrag in Strafakte.", RightBadge = "Lock" });
            }
        }
        if (AccountManage.GetPlayerGroup(target) == 25)
        {
            if (target.GetData("playerCuffed") == 1)
            {
                menu_item_list.Add(new { Type = 1, Name = "~b~Handschellen ablegen", Description = "Wählen Sie diese Option, um den Bürger zu fesseln." });
            }
            else if (player.GetData("handsup") == true)
            {
                menu_item_list.Add(new { Type = 1, Name = "~b~Bürger durchsuchen", Description = "Wählen Sie die Option, um den Bürger zu durch suchen." });

                if (target.GetData("playerCuffed") == 0)
                {
                    menu_item_list.Add(new { Type = 1, Name = "~b~Handschellen anlegen", Description = "Wählen Sie diese Option, um die Fesseln zu lösen." });
                }
            }
            menu_item_list.Add(new { Type = 1, Name = "~b~Ins Prison stecken", Description = "Wählen Sie die Option, um den Bürger ins Prison zu stecken." });

            if (Main.IsInRangeOfPoint(player.Position, new Vector3(1690.666, 2592.404, 45.74735), 3.0f) && !Main.IsInRangeOfPoint(player.Position, new Vector3(-450.0119, 6016.234, 31.71639), 3.0f))
            {
                list.Clear();
                list.Add("auswählen");
                list.Add("10");
                list.Add("15");
                list.Add("20");
                list.Add("25");
                list.Add("30");
                list.Add("35");
                list.Add("40");
                list.Add("45");
                list.Add("50");
                list.Add("55");
                list.Add("60");
                list.Add("65");
                list.Add("70");
                list.Add("75");
                list.Add("80");
                list.Add("85");
                list.Add("90");
                list.Add("95");
                list.Add("100");
                list.Add("110");
                list.Add("115");
                list.Add("120");
                list.Add("125");
                list.Add("130");
                list.Add("135");
                list.Add("140");
                list.Add("145");
                list.Add("150");
                list.Add("155");
                list.Add("160");
                list.Add("165");
                list.Add("170");
                list.Add("175");
                list.Add("180");
                list.Add("185");
                list.Add("190");
                list.Add("195");
                list.Add("200");
                list.Add("210");
                list.Add("215");
                list.Add("220");
                list.Add("225");
                list.Add("230");
                list.Add("235");
                list.Add("240");
                list.Add("245");
                list.Add("250");
                list.Add("255");
                list.Add("260");
                list.Add("265");
                list.Add("270");
                list.Add("275");
                list.Add("280");
                list.Add("285");
                list.Add("290");
                list.Add("295");
                list.Add("300");
                list.Add("400");
                list.Add("500");
                list.Add("600");
                list.Add("700");
                list.Add("800");
                list.Add("900");
                list.Add("1000");
                list.Add("10000");
                list.Add("20000");
                for (int i = 0; i < 20000; i++) list.Add(i + " Sekunden x 120");
                menu_item_list.Add(new { Type = 2, Name = "~b~Ins Prison stecken", Description = "", List = list, StartIndex = player.GetData("new_interact_menu_arrest") });
            }
            else
            {
                menu_item_list.Add(new { Type = 1, Name = "~b~Ins Prison stecken", Description = "Um jemanden ins Gefängnis zu stecken, erst Eintrag in Strafakte.", RightBadge = "Lock" });
            }
        }

        target.TriggerEvent("menu_handler_create_menu_generic", "RESPONSE_USER_MENU", "Bürger Menü", "Optionen für den Bürger " + UsefullyRP.GetPlayerNameToTarget(player, target) + "", false, JsonConvert.SerializeObject(menu_item_list), false);
        target.SetData("UserMenuToTarget_handle", player);
        target.SetData("UserMenuToTarget_name", AccountManage.GetCharacterName(player));
       
    }

    public static void SelectMenuResponse(Client player, String callbackId, int selectedIndex, String objectName, String valueList)
    {
        if(callbackId == "RESPONSE_USER_MENU")
        {
            Client target = NAPI.Data.GetEntityData(player, "UserMenuToTarget_handle");
            string name = player.GetData("UserMenuToTarget_name");

            if(!API.Shared.IsPlayerConnected(target))
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Dieser Bürger ist nicht mehr angeschlossen.");
                return;
            }

            if(target.GetData("status") == false)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Dieser Bürger ist nicht mehr angeschlossen.");
                return;
            }

            if(AccountManage.GetCharacterName(target) != name)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Dieser Bürger ist nicht mehr angeschlossen.");
                return;
            }

            if(!Main.IsInRangeOfPoint(player.Position, target.Position, 4.0f))
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Du bist dem Spieler nicht nah genug..");
                return;
            }

            if (objectName == "Geld geben")
            {
                InteractMenu.User_Input(player, "responser_money_user", "Geld geben", "", "Wählen Sie einen Betrag für den ausgewählten Spieler", "number");
            }
            else if (objectName == "Fahrzeug Verkauf")
            {
                InteractMenu.User_Input(player, "responser_sell_vehicle", "Fahrzeug Verkauf", "", "Wählen Sie einen Betrag für den ausgewählten Verkauf", "number");
            }
            else if (objectName == "Online Überweisung")
            {
                InteractMenu.User_Input(player, "responser_money_to_user_bank", "Online Überweisung", "", "Geben Sie einen Betrag für die Online Überweisung ein", "number");

            }
            else if (objectName == "Infos über meinen Bürger")
            {
                InteractMenu_New.ShowPlayerInfos(player, target);

                List<Client> proxPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(15, player);
                foreach (Client alvo in proxPlayers)
                {
                   // alvo.TriggerEvent("Send_ToChat", "", "<font color ='#C2A2DA'>* " + UsefullyRP.GetPlayerNameToTarget(player, alvo) + " zeigte seine Infos " + UsefullyRP.GetPlayerNameToTarget(target, alvo) + ".");
                }

            }
            else if (objectName == "Cop Identität zeigen")
            {
                InteractMenu_New.ShowPlayerFactionIDCard(player, target);

                List<Client> proxPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(15, player);
                foreach (Client alvo in proxPlayers)
                {
                    // alvo.TriggerEvent("Send_ToChat", "", "<font color ='#C2A2DA'>* " + UsefullyRP.GetPlayerNameToTarget(player, alvo) + " zeigte seine Infos " + UsefullyRP.GetPlayerNameToTarget(target, alvo) + ".");
                }
            }
            else if (objectName == "Medic Identität zeigen")
            {
                InteractMenu_New.ShowPlayerFactionIDCard(player, target);

                List<Client> proxPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(15, player);
                foreach (Client alvo in proxPlayers)
                {
                    // alvo.TriggerEvent("Send_ToChat", "", "<font color ='#C2A2DA'>* " + UsefullyRP.GetPlayerNameToTarget(player, alvo) + " zeigte seine Infos " + UsefullyRP.GetPlayerNameToTarget(target, alvo) + ".");
                }
            }
            else if (objectName == "FIB Identität zeigen")
            {
                InteractMenu_New.ShowPlayerFactionIDCard(player, target);

                List<Client> proxPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(15, player);
                foreach (Client alvo in proxPlayers)
                {
                    // alvo.TriggerEvent("Send_ToChat", "", "<font color ='#C2A2DA'>* " + UsefullyRP.GetPlayerNameToTarget(player, alvo) + " zeigte seine Infos " + UsefullyRP.GetPlayerNameToTarget(target, alvo) + ".");
                }
            }
            else if (objectName == "Haus Schlüssel übergeben")
            {
                HouseSystem.CMD_darchaves(player, target);
            }
            else if (objectName == "DoJ Identität zeigen")
            {
                InteractMenu_New.ShowPlayerFactionIDCard(player, target);

                List<Client> proxPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(15, player);
                foreach (Client alvo in proxPlayers)
                {
                    // alvo.TriggerEvent("Send_ToChat", "", "<font color ='#C2A2DA'>* " + UsefullyRP.GetPlayerNameToTarget(player, alvo) + " zeigte seine Infos " + UsefullyRP.GetPlayerNameToTarget(target, alvo) + ".");
                }
            }
            else if (objectName == "Army Identität zeigen")
            {
                InteractMenu_New.ShowPlayerFactionIDCard(player, target);

                List<Client> proxPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(15, player);
                foreach (Client alvo in proxPlayers)
                {
                    // alvo.TriggerEvent("Send_ToChat", "", "<font color ='#C2A2DA'>* " + UsefullyRP.GetPlayerNameToTarget(player, alvo) + " zeigte seine Infos " + UsefullyRP.GetPlayerNameToTarget(target, alvo) + ".");
                }
            }
            else if (objectName == "President Identität zeigen")
            {
                InteractMenu_New.ShowPlayerFactionIDCard(player, target);

                List<Client> proxPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(15, player);
                foreach (Client alvo in proxPlayers)
                {
                    // alvo.TriggerEvent("Send_ToChat", "", "<font color ='#C2A2DA'>* " + UsefullyRP.GetPlayerNameToTarget(player, alvo) + " zeigte seine Infos " + UsefullyRP.GetPlayerNameToTarget(target, alvo) + ".");
                }
            }
            else if (objectName == "Lizenzen anzeigen nur sich selbst")
            {
                playerCommands.CMD_mostrarlicencas(player, name);
            }
            else if (objectName == "~b~Handschellen ablegen")
            {
                Police.UnCuffPlayer(target);
                List<Client> proxPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(15, player);
                foreach (Client alvo in proxPlayers)
                {
                   // alvo.TriggerEvent("Send_ToChat", "", "<font color ='#C2A2DA'>* " + UsefullyRP.GetPlayerNameToTarget(player, alvo) + " Handschellen abgenommen " + UsefullyRP.GetPlayerNameToTarget(target, alvo) + ".");
                }
            }
            else if (objectName == "~b~Bürger hinterher ziehen")
            {
                Police.DragPlayerToTarget(target, player);
                List<Client> proxPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(15, player);
                foreach (Client alvo in proxPlayers)
                {
                   // alvo.TriggerEvent("Send_ToChat", "", "<font color ='#C2A2DA'>* " + UsefullyRP.GetPlayerNameToTarget(player, alvo) + " Bürger hinterher ziehen" + UsefullyRP.GetPlayerNameToTarget(target, alvo) + ".");
                }
            }
            else if (objectName == "~b~Bürger loslassen")
            {
                Police.UnDragPlayer(target);

                List<Client> proxPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(15, player);
                foreach (Client alvo in proxPlayers)
                {
                    //alvo.TriggerEvent("Send_ToChat", "", "<font color ='#C2A2DA'>* " + UsefullyRP.GetPlayerNameToTarget(player, alvo) + " Bürger loslassen " + UsefullyRP.GetPlayerNameToTarget(target, alvo) + ".");
                }
            }
            else if (objectName == "~b~Bürger durchsuchen")
            {
                Police.FriskPlayerToTarget(target, player);
                List<Client> proxPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(15, player);
                foreach (Client alvo in proxPlayers)
                {
                   // alvo.TriggerEvent("Send_ToChat", "", "<font color ='#C2A2DA'>* " + UsefullyRP.GetPlayerNameToTarget(player, alvo) + " Bürger durchsuchen" + UsefullyRP.GetPlayerNameToTarget(target, alvo) + ".");
                }
            }
            else if (objectName == "Nagelbrett legen & aufheben")
            {
                policeCommands.CMD_nagelbrett(player);
            }
            else if (objectName == "~b~Handschellen anlegen")
            {
                Police.CuffPlayer(target);

                List<Client> proxPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(15, player);
                foreach (Client alvo in proxPlayers)
                {
                   // alvo.TriggerEvent("Send_ToChat", "", "<font color ='#C2A2DA'>* " + UsefullyRP.GetPlayerNameToTarget(player, alvo) + " Handschellen anlegen " + UsefullyRP.GetPlayerNameToTarget(target, alvo) + ".");
                }
            }
            else if (objectName == "~b~Ins Prison stecken")
            {
                policeCommands.CMD_prison(player, target);
                return;
            }
        }
    }
}

