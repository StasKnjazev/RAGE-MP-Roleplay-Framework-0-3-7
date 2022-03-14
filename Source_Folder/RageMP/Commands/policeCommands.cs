using System;
using System.Collections.Generic;
using GTANetworkAPI;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using DerStr1k3r.Core;
using DerStr1k3r.SDK;

class policeCommands : Script
{
    [Command("d", "~y~Benutze:~w~ /d(epartamento) [Nachricht]", Alias = "departamento", GreedyArg = true)]
    public void CMD_departamento(Client player, string mensagem)
    {
        //NAPI.Util.ConsoleOutput("-------- DEBUG CMD PLAYER: d starten");
        if (AccountManage.GetPlayerGroup(player) == 0)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "ERROR:~w~ Sie befinden sich nicht in einer Polizeigruppe..");
            return;
        }
        if (AccountManage.GetPlayerRank(player) == -1)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "ERROR:~w~ Ihre Position hat keine Voraussetzungen für die Verwendung dieses Befehls.");
            return;
        }
        if (FactionManage.GetPlayerGroupType(player) != FactionManage.FACTION_TYPE_POLICE && FactionManage.GetPlayerGroupType(player) != FactionManage.FACTION_TYPE_MEDIC)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "ERROR:~w~ Sie befinden sich nicht in einer Regierungsfraktion..");
            return;
        }
        int faction = AccountManage.GetPlayerGroup(player);
        int rank = AccountManage.GetPlayerRank(player);

        var players = NAPI.Pools.GetAllPlayers();

        foreach (Client c in players)
        {

            if (FactionManage.GetPlayerGroupType(c) == FactionManage.FACTION_TYPE_POLICE || FactionManage.GetPlayerGroupType(player) == FactionManage.FACTION_TYPE_MEDIC)
            {
                NAPI.Notification.SendNotificationToPlayer(c, "<font color='#F0D066'>** [ABTEILUNG] " + FactionManage.faction_data[faction].faction_name + " " + FactionManage.faction_data[faction].faction_rank[rank] + " " + AccountManage.GetCharacterName(player) + " sagt: " + mensagem + "");
            }
        }
        //NAPI.Util.ConsoleOutput("-------- DEBUG CMD PLAYER: d final");
    }
    [Command("m", "~y~Uso:~w~ /m(egafone) [mensagem]", Alias = "megafone", GreedyArg = true)]
    public void CMD_megafone(Client player, string mensagem)
    {
        //NAPI.Util.ConsoleOutput("-------- DEBUG CMD PLAYER: Ich fange an");
        if (AccountManage.GetPlayerGroup(player) == 0)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "ERROR:~w~ Sie befinden sich nicht in einer Polizeigruppe.");
            return;
        }
        if (FactionManage.GetPlayerGroupType(player) != FactionManage.FACTION_TYPE_POLICE)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "ERROR:~w~ Sie befinden sich nicht in einer Polizeigruppe..");
            return;
        }
        if (player.GetData("duty") == 0)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "ERROR:~w~ Du bist außer Dienst..");
            return;
        }

        int faction = AccountManage.GetPlayerGroup(player);
        int rank = AccountManage.GetPlayerRank(player);

        List<Client> proxPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(45, player);
        foreach (Client target in proxPlayers)
        {
            target.TriggerEvent("Send_ToChat", "", "<font color ='#C2A2DA'>** " + FactionManage.faction_data[faction].faction_rank[rank] + " " + UsefullyRP.GetPlayerNameToTarget(player, target) + " (MEGAFONE): " + mensagem);
        }

    }
    [Command("prender", "~y~Benutze:~w~ /prender [player] [optional(tempo)]", GreedyArg = false)]
    public void CMD_prender(Client player, string idOrname, int tempo = 0)
    {
        if (AccountManage.GetPlayerGroup(player) == 0)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "ERROR:~w~ Sie befinden sich nicht in einer Polizeigruppe.");
            return;
        }
        if (AccountManage.GetPlayerRank(player) == -1)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "ERROR:~w~ Ihre Position hat keine Voraussetzungen für die Verwendung dieses Befehls.");
            return;
        }
        if (FactionManage.GetPlayerGroupType(player) != FactionManage.FACTION_TYPE_POLICE)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "ERROR:~w~ Sie befinden sich nicht in einer Polizeigruppe.");
            return;
        }
        if (!Main.IsInRangeOfPoint(player.Position, new Vector3(1690.666, 2592.404, 45.74735), 3.0f) && !Main.IsInRangeOfPoint(player.Position, new Vector3(-450.0119, 6016.234, 31.71639), 3.0f))
        {
            NAPI.Notification.SendNotificationToPlayer(player, "ERROR:~w~ Sie müssen sich im Haftbereich in der Nähe der Zellen aufhalten, um einen Spieler zu verhaften.");
            return;
        }
        Client target = Main.findPlayer(player, idOrname);
        if(target != null)
        {
            if (Main.IsInRangeOfPoint(target.Position, player.Position, 3) && target.GetData("character_wanted_level") > 0 && player != target)
            {

                if (target.GetData("SendoArrastado") == true)
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "ERROR:~w~ Sie müssen den Player nicht mehr ziehen, bevor Sie ihn verhaften.");
                    return;
                }

                int minutes = 0;
                if(tempo == 0)
                {
                    minutes = Police.Calcular_Prisao(target.GetData("character_name"));
                }
                else if(tempo > 0)
                {
                    minutes = tempo * 60;
                }

                if(minutes == 0)
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "Es wurde keine Zeit für die Festnahme eines Spielers festgelegt.Stellen Sie sicher, dass Sie eine Zeit gesetzt haben oder ob er ein gesuchter Spieler ist.");
                    return;
                }

                NAPI.Notification.SendNotificationToPlayer(target, "Sie wurden wegen verhaftet ~b~" + AccountManage.GetCharacterName(player) + "~w~ von~g~" + minutes + "~w~ Sekunden.");
                NAPI.Notification.SendNotificationToPlayer(player, "Du hast verhaftet ~b~" + AccountManage.GetCharacterName(target) + "~w~ von ~g~" + minutes + "~w~ Sekunden.");

                int count = 0;
                foreach (var teste in Main.prison_spawns)
                {
                    count++;
                }
                Random rnd = new Random();
                int index = rnd.Next(0, count);

                target.Position = Main.prison_spawns[index].position;
                target.Rotation = Main.prison_spawns[index].rotation;

                target.SetClothes(1, 0, 0);
                target.SetClothes(5, 0, 0);
                target.SetClothes(1, 0, 0);
                target.SetClothes(7, 0, 0);
                target.SetClothes(9, 0, 0);
                NAPI.Player.ClearPlayerAccessory(target, 0);
                NAPI.Player.ClearPlayerAccessory(target, 1);
                NAPI.Player.ClearPlayerAccessory(target, 2);
                NAPI.Player.ClearPlayerAccessory(target, 6);
                NAPI.Player.ClearPlayerAccessory(target, 7);

                if (target.GetSharedData("CHARACTER_ONLINE_GENRE") == 0)
                {
                    target.SetClothes(4, 3, 7);
                    target.SetClothes(11, 5, 0);
                    target.SetClothes(3, 5, 0);
                    target.SetClothes(8, 0, 18);
                    target.SetClothes(6, 8, 0);
                }
                else
                {
                    target.SetClothes(4, 3, 7);
                    target.SetClothes(11, 5, 0);
                    target.SetClothes(3, 4, 0);
                    target.SetClothes(8, 0, 18);
                    target.SetClothes(6, 1, 0);
                }

                target.SetData("character_prison", 1);
                target.SetData("character_prison_cell", index);
                target.SetData("character_prison_time", minutes);
                target.SetData("character_wanted_level", 0);

                target.SetData("playerCuffed", 0);
                target.StopAnimation();

                target.TriggerEvent("freezeEx", false);
                target.TriggerEvent("setFollow", false, player);

                cellphoneSystem.FinishCall(target);
                return;
            }
        }
        NAPI.Notification.SendNotificationToPlayer(player, "ERROR:~w~ Der Spieler ist nicht in Ihrer Nähe oder er ist kein Gesuchter.");
    }

    [Command("suspeito", "~y~Benutze:~w~ /su(speito) [player]", Alias = "su,mandato,ma")]
    public void CMD_mandato(Client p, string idOrName)
    {
        //NAPI.Util.ConsoleOutput("-------- DEBUG CMD PLAYER: suspeito inicio");
        Client target = Main.findPlayer(p, idOrName);
        if (AccountManage.GetPlayerGroup(p) == -1)
        {
            Main.DisplayErrorMessage(p, " Sie befinden sich nicht in einer Polizeigruppe.");
            return;
        }
        if (FactionManage.GetPlayerGroupType(p) != FactionManage.FACTION_TYPE_POLICE)
        {
            Main.DisplayErrorMessage(p, " Sie befinden sich nicht in einer Polizeigruppe.");
            return;
        }


        List<dynamic> menu_item_list = new List<dynamic>();
        int index = 0;
        foreach (var crime in Main.crime_list)
        {
            menu_item_list.Add(new { Type = 1, Name = crime.crime_name, Description = "", RightLabel = "~c~"+ crime.crime_points + " estrelas" });

            index++;
        }

        InteractMenu.CreateMenu(p, "CRIME_LIST_RESPONSE", "Mandat", "~b~LISTE VON MANDATEN:", true, JsonConvert.SerializeObject(menu_item_list), false);

        p.SetData("CMDMandatoTarget", target);
        //NAPI.Util.ConsoleOutput("-------- DEBUG CMD PLAYER:Endverdächtiger");
    }

    [Command("revistar", "~y~Uso:~w~ /revistar [player]")]
    public void CMD_revistar(Client p, string idOrName)
    {

        Client target = Main.findPlayer(p, idOrName);
        if (AccountManage.GetPlayerGroup(p) == -1)
        {
            Main.DisplayErrorMessage(p, " Sie befinden sich nicht in einer Polizeigruppe.");
            return;
        }
        if (FactionManage.GetPlayerGroupType(p) != FactionManage.FACTION_TYPE_POLICE)
        {
            Main.DisplayErrorMessage(p, " Sie befinden sich nicht in einer Polizeigruppe.");
            return;
        }

        p.SendChatMessage("~g~Itens de "+AccountManage.GetCharacterName(target)+"");

        if(target.GetData("primary_weapon") != 0)
        {
            NAPI.Notification.SendNotificationToPlayer(p, "(Hauptwaffe) ~c~" + target.GetData("primary_weapon"));
        }
        if (target.GetData("secundary_weapon") != 0)
        {
            NAPI.Notification.SendNotificationToPlayer(p, "(Sekundärwaffe) ~c~" + target.GetData("secundary_weapon"));
        }
        if (target.GetData("weapon_meele") != 0)
        {
            NAPI.Notification.SendNotificationToPlayer(p, "(leichte Waffe) ~c~" + target.GetData("weapon_meele"));
        }

        for (int index = 0; index < Inventory.MAX_INVENTORY_ITENS; index++)
        {
            if (target.GetData("inventory_item_" + index + "_type") != 0 && target.GetData("inventory_item_" + index + "_type") < Inventory.itens_available.Count)
            {
                if (target.GetData("inventory_item_" + index + "_amount") > 0)
                {
                    NAPI.Notification.SendNotificationToPlayer(p, "(items) ~c~" + Inventory.itens_available[target.GetData("inventory_item_" + index + "_type")].name +" ~w~("+ target.GetData("inventory_item_" + index + "_amount") + ") ");
                }
            }
        }  
    }

    [Command("revistarveiculo")]
    public void CMD_revistarveiculo(Client p)
    {
        if (AccountManage.GetPlayerGroup(p) == -1)
        {
            Main.DisplayErrorMessage(p, " Sie befinden sich nicht in einer Polizeigruppe..");
            return;
        }
        if (FactionManage.GetPlayerGroupType(p) != FactionManage.FACTION_TYPE_POLICE)
        {
            Main.DisplayErrorMessage(p, " Sie befinden sich nicht in einer Polizeigruppe..");
            return;
        }

        Vehicle vehicle = Utils.GetClosestVehicle(p, 5.0f);

        if (NAPI.Entity.DoesEntityExist(vehicle))
        {
            if (NAPI.Data.HasEntityData(vehicle, "MAX_VEHICLE_SLOT"))
            {
                if (NAPI.Data.GetEntityData(vehicle, "MAX_VEHICLE_SLOT") > 0)
                {
                    p.SendChatMessage("~g~Artikel im Fahrzeuginventar");
                    List<dynamic> menu_item_list = new List<dynamic>();
                    for (int i = 0; i < 30; i++)
                    {
                        if (NAPI.Data.GetEntityData(vehicle, "trunk_item_" + i + "_type") != 0)
                        {
                            if (NAPI.Data.GetEntityData(vehicle, "trunk_item_" + i + "_amount") > 0)
                            {
                                NAPI.Notification.SendNotificationToPlayer(p, "(item) ~c~" + Inventory.itens_available[NAPI.Data.GetEntityData(vehicle, "trunk_item_" + i + "_type")].name + " ~w~(" + NAPI.Data.GetEntityData(vehicle, "trunk_item_" + i + "_amount") + ")");
                            }
                        }
                    }
                    return;
                }
            }
        }
        Main.SendErrorMessage(p, "* Sie sind nicht in der Nähe des Fahrzeugs oder dieses Fahrzeug hat kein Inventar.");
    }

    [Command("dar", "~y~Benutze:~w~ /dar [player] [Artikelname] [quantidade]")]
    public void CMD_dar(Client player, string idOrName, string itemName, int amount)
    {
        Client target = Main.findPlayer(player, idOrName);

        if (target == null)
        {
            Main.DisplayErrorMessage(player, " O Spieler ist nicht verbunden.");
            return;
        }

        if(target == player)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Du kannst dir nichts geben.");
            return;
        }

        int playerid = Main.getIdFromClient(player);

        for (int index = 0; index < Inventory.MAX_INVENTORY_ITENS; index++)
        {
            if (Inventory.player_inventory[playerid].type[index] != 0 && Inventory.player_inventory[playerid].type[index] < Inventory.itens_available.Count)
            {
                if (Inventory.itens_available[Inventory.player_inventory[playerid].type[index]].name == itemName)
                {
                    if (Inventory.player_inventory[playerid].amount[index] > 0)
                    {
       
                        target.SetData("offer_amount", amount);
                        target.SetData("offer_seller", player);
                        target.SetData("offer_item", Inventory.player_inventory[playerid].type[index]);
                        target.SetData("offer", true);

                        InteractMenu.ShowModal(target, "GIVE_ITEM", "Hoppla! Jemand bietet dir etwas an !", "O Bürger"+AccountManage.GetCharacterName(player) + " bietet dir an " + amount + "  " + Inventory.itens_available[Inventory.player_inventory[playerid].type[index]].name + ".<br><br>Você deseja aceitar ?", "Sim", "Não, Recusar");

                        Main.SendInfoMessage(player, "Du hast angeboten " + amount + " " + Inventory.itens_available[Inventory.player_inventory[playerid].type[index]].name + " zu " + AccountManage.GetCharacterName(target) + ".");
                        return;
                    }
                }

            }
        }

        Main.DisplayErrorMessage(player, "Dieser Artikel wurde nicht gefunden.");
    }

    [Command("confiscaritem", "~y~Benutze:~w~ /confiscaritem [player] [Artikelname] ~c~~c~Hinweis: Dieser Befehl gilt nur für Gegenstände, um die Verwendung von Waffen zu beschlagnahmen / confiscararmas")]
    public void CMD_confiscaritem(Client p, string idOrName, string itemName)
    {

        Client target = Main.findPlayer(p, idOrName);
        if (AccountManage.GetPlayerGroup(p) == -1)
        {
            Main.DisplayErrorMessage(p, " Sie befinden sich nicht in einer Polizeigruppe..");
            return;
        }
        if (FactionManage.GetPlayerGroupType(p) != FactionManage.FACTION_TYPE_POLICE)
        {
           Main.DisplayErrorMessage(p, " Sie befinden sich nicht in einer Polizeigruppe..");
            return;
        }

        if (target == null)
        {
            Main.DisplayErrorMessage(p, " O Spieler ist nicht verbunden.");
            return;
        }

        int playerid = Main.getIdFromClient(target);

        for (int index = 0; index < Inventory.MAX_INVENTORY_ITENS; index++)
        {
            if (Inventory.player_inventory[playerid].type[index] != 0 && Inventory.player_inventory[playerid].type[index] < Inventory.itens_available.Count)
            {
                if (Inventory.itens_available[Inventory.player_inventory[playerid].type[index]].name == itemName)
                {
                    if (Inventory.player_inventory[playerid].amount[index] > 0)
                    {
                        
                        Main.SendSuccessMessage(p, "Sie haben konfisziert " + Inventory.player_inventory[playerid].amount[index] + " " + Inventory.itens_available[Inventory.player_inventory[playerid].type[index]].name + " von "+AccountManage.GetCharacterName(target)+".");
                        Main.SendSuccessMessage(target, "O offiziell "+AccountManage.GetCharacterName(p)+ " konfisziert"+ Inventory.player_inventory[playerid].amount[index] + " " + Inventory.itens_available[Inventory.player_inventory[playerid].type[index]].name + " Ihres Inventars.");
                        Inventory.RemoveItem(target, itemName, Inventory.player_inventory[playerid].amount[index]);
                        return;
                    }
                }

            }
        }
        Main.DisplayErrorMessage(p, "Dieser Artikel wurde nicht gefunden.");
    }

    [Command("confiscararmas", "~y~Benutze:~w~ /confiscararmas [player] ~c~Hinweis: Dieser Befehl gilt nur für Waffen, um die Verwendung von Gegenständen zu konfiszieren /confiscaritem")]
    public void CMD_confiscararmas(Client p, string idOrName)
    {
        Client target = Main.findPlayer(p, idOrName);
        if (AccountManage.GetPlayerGroup(p) == -1)
        {
            Main.DisplayErrorMessage(p, " Sie befinden sich nicht in einer Polizeigruppe..");
            return;
        }
        if (FactionManage.GetPlayerGroupType(p) != FactionManage.FACTION_TYPE_POLICE)
        {
            Main.DisplayErrorMessage(p, " Sie befinden sich nicht in einer Polizeigruppe..");
            return;
        }
        if (target == null)
        {
            Main.DisplayErrorMessage(p, "Der Bürger schläft.");
            return;
        }

        WeaponManage.RemoveAllWeaponEx(target);

        Main.SendSuccessMessage(p, "Sie haben alle konfisziert" + AccountManage.GetCharacterName(target)+".");
        Main.SendSuccessMessage(target, "O offiziell " + AccountManage.GetCharacterName(p)+ " beschlagnahmte alle seine Waffen.");

        Main.DisplayErrorMessage(p, "Dieser Artikel wurde nicht gefunden.");

    }

    [Command("nagelbrett", "~o~Nutze: ~w~/rb [create/clear] um Nagelbretter zu erstellen/löschen.")]
    public static void CMD_nagelbrett(Client player)
    {
        GTANetworkAPI.Object RoadBlock;
        if (player.HasData("PlayerData.Temp.RoadBlock"))
        {
            RoadBlock = NAPI.Data.GetEntityData(player, "PlayerData.Temp.RoadBlock");
            RoadBlock.Delete();
            player.ResetData("PlayerData.Temp.RoadBlock");
            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Nagelbrett aufgehoben", 5000);
            return;
        }

        RoadBlock = NAPI.Object.CreateObject(3698367558, Main.GetPositionInFrontOfPlayer(player, 2).Add(new Vector3(0, 0, -0.95)), player.Rotation, 0);
        player.SetData("PlayerData.Temp.RoadBlock", RoadBlock);
        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Nagelbrett ~g~aufgestellt", 5000);
    }

    [Command("multar", "~y~Benutze:~w~ /multar [id/PartOfName] [valor da multa]")]
    public void CMD_fine(Client player, string idOrName, int preco)
    {
        //NAPI.Util.ConsoleOutput("-------- DEBUG CMD PLAYER: feiner Start");
        Client target = Main.findPlayer(player, idOrName);
        if (AccountManage.GetPlayerGroup(player) == 0)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "ERROR:~w~ Sie befinden sich nicht in einer Polizeigruppe..");
            return;
        }
        if (AccountManage.GetPlayerRank(player) == -1)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "ERROR:~w~ Ihre Position hat keine Voraussetzungen für die Verwendung dieses Befehls.");
            return;
        }
        if (FactionManage.GetPlayerGroupType(player) != FactionManage.FACTION_TYPE_POLICE)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "ERROR:~w~ Sie befinden sich nicht in einer Polizeigruppe..");
            return;
        }

        if (target == null)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "ERROR:~w~ O Spieler ist nicht verbunden.");
            return;
        }
        if (!Main.IsInRangeOfPoint(player.Position, target.Position, 3.0f))
        {
            NAPI.Notification.SendNotificationToPlayer(player, "ERROR:~w~ Du bist nicht in der Nähe des Spielers..");
            return;
        }
        if (preco < 1 || preco > 20000)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "ERROR:~w~ O Der Preis sollte zwischen 1 und 20000 liegen.");
            return;
        }

        target.SetData("ticketOffer", true);
        target.SetData("ticketOfferBy", player);
        target.SetData("ticketOfferPrice", preco);
 
        NAPI.Notification.SendNotificationToPlayer(player, "Sie wurden bestraft ~g~$" + preco.ToString("N0") + "~w~ in" + AccountManage.GetCharacterName(target) + ".");
        Main.SendInfoMessage(target, "O " + FactionManage.faction_data[AccountManage.GetPlayerGroup(player)].faction_rank[AccountManage.GetPlayerRank(player)] + " " + AccountManage.GetCharacterName(player) + " hat eine Geldstrafe auf Sie angewandt ~g~$" + preco.ToString("N0") + "~w~.");
        Main.SendInfoMessage(target, "Benutze ~g~/aceitarmulta~w~ zu akzeptieren und /recusarmulta~w~ ablehnen. ATENÇÃO: Die Geldbuße wird innerhalb von 1 Minute automatisch abgelehnt.");

        NAPI.Task.Run(() =>
        {
            player.ResetData("ticketOffer");
            player.ResetData("ticketOfferBy");
            player.ResetData("ticketOfferPrice");
        }, delayTime: 60000);

        //NAPI.Util.ConsoleOutput("-------- DEBUG CMD PLAYER: letzte Geldstrafe");
    }

    [Command("aceitarmulta")]
    public void CMD_aceitarmulta(Client player)
    {
        if (player.HasData("ticketOffer") && player.GetData("ticketOffer") == true)
        {
            if (!API.Shared.IsPlayerConnected(player))
            {
                List<Client> target = NAPI.Player.GetPlayersInRadiusOfPlayer(15, player);
                foreach (Client targets in target)
                {
                    Main.SendInfoMessage(targets, "Der Bürger" + AccountManage.GetCharacterName(player) + " akzeptierte seine Geldstrafe von $" + player.GetData("ticketOfferPrice") + ".");
                    NAPI.Notification.SendNotificationToPlayer(player, "Sie haben die Geldstrafe von angenommen" + AccountManage.GetCharacterName(targets) + " von $" + player.GetData("ticketOfferPrice") + ".");

                    Main.GivePlayerMoney(player, -player.GetData("ticketOfferPrice"));
                    player.ResetData("ticketOffer");
                    player.ResetData("ticketOfferBy");
                    player.ResetData("ticketOfferPrice");
                }
            }
            else Main.DisplayErrorMessage(player, "Der Spieler, der die Geldstrafe geschickt hat, ist nicht verbunden.");
        }
        else Main.DisplayErrorMessage(player, "Sie haben keine Geldstrafe zu akzeptieren..");
    }

    [Command("recusarmulta")]
    public void CMD_recusarmulta(Client player)
    {
        if (player.HasData("ticketOffer") && player.GetData("ticketOffer") == true)
        {
            if (AccountManage.GetPlayerConnected(NAPI.Data.GetEntityData(player, "ticketOfferBy")))
            {
                Client target = NAPI.Data.GetEntityData(player, "ticketOfferBy");
                Main.SendInfoMessage(target, "Der Bürger ~y~" + AccountManage.GetCharacterName(player) + " abgelehnt~w~ deine Geldstrafe ~g~$" + player.GetData("ticketOfferPrice") + "~w~.");
                NAPI.Notification.SendNotificationToPlayer(player, "Du recusou~w~ die Geldstrafe von ~y~" + AccountManage.GetCharacterName(target) + "~w~ von ~g~$" + player.GetData("ticketOfferPrice") + ".");

                player.ResetData("ticketOffer");
                player.ResetData("ticketOfferBy");
                player.ResetData("ticketOfferPrice");
            }
            else Main.DisplayErrorMessage(player, "O Bürger, der die Geldstrafe geschickt hat, ist nicht verbunden.");
        }
        else Main.DisplayErrorMessage(player, "Sie haben keine Geldstrafe zu akzeptieren..");
    }

    [Command("multarveiculo", "~y~Uso:~w~ /multarveiculo [placa] [preço]")]
    public void CMD_finevehicle(Client player, string placa, int preco)
    {
        if (AccountManage.GetPlayerGroup(player) == 0)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "ERROR:~w~ Sie befinden sich nicht in einer Polizeigruppe..");
            return;
        }
        if (AccountManage.GetPlayerRank(player) == -1)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "ERROR:~w~ Ihre Position hat keine Berechtigungen, um diesen Befehl zu verwenden.");
            return;
        } 
        if (FactionManage.GetPlayerGroupType(player) != FactionManage.FACTION_TYPE_POLICE)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "ERROR:~w~ Sie befinden sich nicht in einer Polizeigruppe..");
            return;
        }

        if (preco < 1 || preco > 20000)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "ERROR:~w~ O Der Preis sollte zwischen 1 und 20000 liegen.");
            return;
        }

        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {

            Mainpipeline.Open();
            MySqlCommand query = new MySqlCommand("SELECT * FROM `vehicles` WHERE `vehicle_plate` = '" + placa + "' or `vehicle_plate` = '" + placa.Replace(" ", "-") + "';", Mainpipeline);

            using (MySqlDataReader reader = query.ExecuteReader())
            {

                string data2txt = string.Empty;
                string datatxt = string.Empty;

                //var index = 0;
                while (reader.Read())
                {
                    string vehicle_plate = reader.GetString("vehicle_plate");
                    if (vehicle_plate == placa)
                    {
                        var players = NAPI.Pools.GetAllPlayers();
                        foreach (var pl in players)
                        {
                            if (pl.GetData("status") == true)
                            {
                                if (NAPI.Data.GetEntityData(pl, "character_sqlid") == reader.GetInt32("vehicle_owner_id"))
                                {
                                    for (int index = 0; 0 < PlayerVehicle.MAX_PLAYER_VEHICLES; index++)
                                    {
                                        if (placa == Convert.ToString(PlayerVehicle.vehicle_data[Main.getIdFromClient(pl)].plate[index]))
                                        {
                                            NAPI.Notification.SendNotificationToPlayer(pl, "Ihr Fahrzeug ~c~(" + PlayerVehicle.vehicle_data[Main.getIdFromClient(player)].model[index] + ")~w~ mit dem ~y~" + Convert.ToString(PlayerVehicle.vehicle_data[Main.getIdFromClient(pl)].plate[index]) + "~w~ wurde bestraft~g~$" + preco.ToString("N0") + "~w~vom Beamten " + AccountManage.GetCharacterName(player) + "~w~.");
                                            PlayerVehicle.vehicle_data[Main.getIdFromClient(pl)].ticket[index] = preco;
                                            PlayerVehicle.SavePlayerVehicle(pl, index);
                                            return;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        NAPI.Notification.SendNotificationToPlayer(player, "ERROR:~w~ Das Kfz - Kennzeichen konnte nicht in der Datenbank gefunden werden.");
    }

    [Command("algemar", "~y~Uso:~w~ /algemar [player]")]
    public void CMD_algemar(Client handle, string idOrName)
    {
        //NAPI.Util.ConsoleOutput("-------- DEBUG CMD PLAYER: Handschellen nach Hause");
        if (AccountManage.GetPlayerGroup(handle) == -1)
        {
            NAPI.Notification.SendNotificationToPlayer(handle, "ERROR:~w~Sie befinden sich nicht in einer Polizeigruppe..");
            return;
        }
        if (AccountManage.GetPlayerRank(handle) == -1)
        {
            NAPI.Notification.SendNotificationToPlayer(handle, "ERROR:~w~ Ihre Position hat keine Voraussetzungen für die Verwendung dieses Befehls.");
            return;
        }
        if (FactionManage.GetPlayerGroupType(handle) != FactionManage.FACTION_TYPE_POLICE)
        {
            NAPI.Notification.SendNotificationToPlayer(handle, "ERROR:~w~ Sie befinden sich nicht in einer Polizeigruppe..");
            return;
        }
        Client target = Main.findPlayer(handle, idOrName);
        if(target != null)
        {
            if (Main.IsInRangeOfPoint(handle.Position, target.Position, 3) && handle != target)
            {

                if (target.GetData("playerCuffed") == 1)
                {
                    NAPI.Notification.SendNotificationToPlayer(handle, "ERROR:~w~ Dieser Bürger ist bereits mit Handschellen gefesselt.");
                    return;
                }

                if (target.GetData("handsup") == false)
                {
                    NAPI.Notification.SendNotificationToPlayer(handle, "ERROR:~w~ Dieser Bürger hat keine Hände.");
                    return;
                }

                if (target.IsInVehicle)
                {
                    NAPI.Notification.SendNotificationToPlayer(handle, "ERROR:~w~ Sie können einen Bürger, der sich in einem Fahrzeug befindet, nicht in Handschellen legen.");
                    return;
                }

                target.SetData("handsup", false);
                NAPI.Notification.SendNotificationToPlayer(handle, "~y~INFO:~w~ Sie haben den Bürger mit Handschellen gefesselt ~b~" + AccountManage.GetCharacterName(target) + "~w~.");
                NAPI.Notification.SendNotificationToPlayer(target, "~y~INFO:~w~ O offiziell ~b~" + AccountManage.GetCharacterName(handle) + "~w~ dich in Handschellen gelegt.");

                target.SetData("playerCuffed", 1);
                target.StopAnimation();


                // turn off cellphone ;
                cellphoneSystem.FinishCall(target);

                NAPI.Player.PlayPlayerAnimation(target, (int)(Main.AnimationFlags.Loop | Main.AnimationFlags.AllowPlayerControl | Main.AnimationFlags.OnlyAnimateUpperBody), "mp_arresting", "idle");
                return;
            }
        }
        NAPI.Notification.SendNotificationToPlayer(handle, "ERROR:~w~ Es gibt keine Spieler, deren Hände in Ihrer Nähe sind.");
    }

    [Command("desalgemar", "~y~Benutze:~w~ /desalgemar")]
    public void CMD_desalgemar(Client handle, string idOrName)
    {
        if (FactionManage.GetPlayerGroupType(handle) != FactionManage.FACTION_TYPE_POLICE)
        {
            Main.SendErrorMessage(handle, "Sie befinden sich nicht in einer Polizeigruppe..");
            return;
        }
        Client target = Main.findPlayer(handle, idOrName);
        if(target != null)
        {
            if (Main.IsInRangeOfPoint(handle.Position, target.Position, 3) && handle != target)
            {

                if (target.GetData("playerCuffed") == 0)
                {
                    Main.SendErrorMessage(target, "Dieser Player ist nicht mit Handschellen gefesselt..");
                    return;
                }

                NAPI.Notification.SendNotificationToPlayer(handle, "~y~INFO:~w~ Du hast die ausgezogen ~b~" + AccountManage.GetCharacterName(target) + "~w~.");
                NAPI.Notification.SendNotificationToPlayer(target, "~y~INFO:~w~ O offiziell ~b~" + AccountManage.GetCharacterName(handle) + "~w~ nahm dir die Handschellen ab.");

                target.SetData("playerCuffed", 0);
                target.StopAnimation();
                target.TriggerEvent("freezeEx", false);
                return;
            }
        }
        Main.SendErrorMessage(handle, "Dieser Player ist nicht verbunden oder befindet sich nicht in Ihrer Nähe.");
    }

    [Command("tirarmascara", "~y~Benutze:~w~ /tirarmascara")]
    public void CMD_tirarmascara(Client handle, string idOrName)
    {
        if (FactionManage.GetPlayerGroupType(handle) != FactionManage.FACTION_TYPE_POLICE)
        {
            Main.SendErrorMessage(handle, "Sie befinden sich nicht in einer Polizeigruppe..");
            return;
        }
        Client target = Main.findPlayer(handle, idOrName);
        if(target != null)
        {
            if (Main.IsInRangeOfPoint(handle.Position, target.Position, 3) && handle != target)
            {

                if (target.GetData("playerCuffed") == 0)
                {
                    Main.SendErrorMessage(target, "Dieser Bürgerist nicht mit Handschellen gefesselt..");
                    return;
                }

                if(!UsefullyRP.mask[Main.getIdFromClient(target)])
                {
                    Main.SendErrorMessage(target, "Dieser Bürger trägt keine Maske.");
                    return;
                }

                NAPI.Notification.SendNotificationToPlayer(handle, "~y~INFO:~w~ Du hast die ausgezogen ~b~" + AccountManage.GetCharacterName(target) + "~w~.");
                //NAPI.Notification.SendNotificationToPlayer(target, "~y~INFO:~w~ Die offiziell ~b~" + AccountManage.GetCharacterName(handle) + "~w~ Nimm die Maske ab, die du getragen hast.");

                UsefullyRP.RemoveMaskFromPlayer(target);

                target.SetData("playerCuffed", 0);
                target.StopAnimation();
                target.TriggerEvent("freezeEx", false);
                return;
            }
        }
        Main.SendErrorMessage(handle, "Dieser Player ist nicht verbunden oder befindet sich nicht in Ihrer Nähe.");
    }

    [Command("deter", "~y~Benutze: ~w~/deter [player] [assento(1 - 2)]")]
    public void CMD_deter(Client handle, string idOrName, int assento)
    {
        //NAPI.Util.ConsoleOutput("-------- DEBUG CMD PLAYER: zu beginnen");
        if (AccountManage.GetPlayerGroup(handle) == -1)
        {
            NAPI.Notification.SendNotificationToPlayer(handle, "ERROR:~w~ Sie befinden sich nicht in einer Polizeigruppe..");
            return;
        }
        if (AccountManage.GetPlayerRank(handle) == -1)
        {
            NAPI.Notification.SendNotificationToPlayer(handle, "ERROR:~w~ Ihre Position hat keine Voraussetzungen für die Verwendung dieses Befehls.");
            return;
        }
        if (FactionManage.GetPlayerGroupType(handle) != FactionManage.FACTION_TYPE_POLICE)
        {
            NAPI.Notification.SendNotificationToPlayer(handle, "ERROR:~w~ Sie befinden sich nicht in einer Polizeigruppe.");
            return;
        }
        if (handle.IsInVehicle)
        {
            NAPI.Notification.SendNotificationToPlayer(handle, "ERROR:~w~ Sie können diesen Befehl nicht in einem Fahrzeug verwenden.");
            return;
        }

        Client target = Main.findPlayer(handle, idOrName);
        if(target != null)
        {
            if (Main.IsInRangeOfPoint(handle.Position, target.Position, 3) && handle != target)
            {
                if(assento != 1 && assento != 2)
                {
                    Main.SendErrorMessage(handle, "O Sitz sollte zwischen 1 und 2 sein.");
                    return;
                }

                if (target.GetData("playerCuffed") == 0)
                {
                    NAPI.Notification.SendNotificationToPlayer(handle, "ERROR:~w~ O Der Bürger muss dafür mit Handschellen gefesselt sein");
                    return;
                }

                if (target.IsInVehicle)
                {
                    NAPI.Notification.SendNotificationToPlayer(target, "ERROR:~w~ Dieser Bürger befindet sich bereits in einem Fahrzeug.");
                    return;
                }
                Vehicle vehicle = Utils.GetClosestVehicle(target, 5.0f);

                if (!NAPI.Entity.DoesEntityExist(vehicle))
                {
                    NAPI.Notification.SendNotificationToPlayer(handle, "ERROR:~w~ Sie sind nicht in der Nähe eines Fahrzeugs.");
                    return;
                }

                var p = NAPI.Pools.GetAllPlayers();
                foreach (var i in p)
                {
                    if (NAPI.Player.IsPlayerInAnyVehicle(i) && NAPI.Player.GetPlayerVehicleSeat(i) == assento)
                    {
                        NAPI.Notification.SendNotificationToPlayer(handle, "ERROR:~w~ Der Beifahrersitz" + assento + " wird bereits verwendet.");
                        return;
                    }
                }
                NAPI.Notification.SendNotificationToPlayer(handle, "~y~INFO:~w~ Sie setzen den Bürger ~b~" + AccountManage.GetCharacterName(target) + "~w~ auf dem Beifahrersitz");
                NAPI.Player.SetPlayerIntoVehicle(target, vehicle, assento);
                //NAPI.Player.PlayPlayerAnimation(target, 1, "mp_arresting", "sit");
                NAPI.Player.PlayPlayerAnimation(target, (int)(Main.AnimationFlags.Loop | Main.AnimationFlags.OnlyAnimateUpperBody), "mp_arresting", "sit");

                return;
            }
        }
        NAPI.Notification.SendNotificationToPlayer(handle, "ERROR:~w~ Es sind keine Bürger in Ihrer Nähe.");
        //NAPI.Util.ConsoleOutput("-------- DEBUG CMD PLAYER: abschrecken ende");
    }

    [Command("arrastar", "~y~Uso:~w~ /arrastar [player]")]
    public static void CMD_arrastar(Client handle, string idOrName)
    {
        //NAPI.Util.ConsoleOutput("-------- DEBUG CMD PLAYER: Start ziehen");
        if (AccountManage.GetPlayerGroup(handle) == -1)
        {
            NAPI.Notification.SendNotificationToPlayer(handle, "ERROR:~w~ Sie befinden sich nicht in einer Polizeigruppe.");
            return;
        }
        if (AccountManage.GetPlayerRank(handle) == -1)
        {
            NAPI.Notification.SendNotificationToPlayer(handle, "ERROR:~w~Ihre Position hat keine Voraussetzungen für die Verwendung dieses Befehls.");
            return;
        }
        if (FactionManage.GetPlayerGroupType(handle) != FactionManage.FACTION_TYPE_POLICE)
        {
            NAPI.Notification.SendNotificationToPlayer(handle, "ERROR:~w~ Sie befinden sich nicht in einer Polizeigruppe..");
            return;
        }

        Client target = Main.findPlayer(handle, idOrName);
        if(target != null)
        {
            if (Main.IsInRangeOfPoint(handle.Position, target.Position, 3) && handle != target)
            {
                if (NAPI.Data.GetEntityData(target, "SendoArrastado") == false)
                {
                    if (target.GetData("playerCuffed") == 0)
                    {
                        NAPI.Notification.SendNotificationToPlayer(handle, "ERROR:~w~ O Der Bürger muss dafür mit Handschellen gefesselt sein.");
                        return;
                    }

                    if (target.IsInVehicle)
                    {
                        NAPI.Player.WarpPlayerOutOfVehicle(target);
                    }
                    target.TriggerEvent("setFollow", true, handle);
                    target.SetData("SendoArrastado", true);

                    target.SetSharedData("DisableExitVehicle", false);
                    Main.DisplaySubtitle(handle, "Sie ziehen jetzt den Bürger " + AccountManage.GetCharacterName(target) + ".");
                }
                else
                {
                    Main.DisplaySubtitle(handle, "Sie haben den Bürger nicht mehr gezogen " + AccountManage.GetCharacterName(target) + ".");
                    target.TriggerEvent("setFollow", false, handle);
                    target.SetData("SendoArrastado", false);
                }
                return;
            }
        }
        Notify.Send(handle, NotifyType.Info, NotifyPosition.BottomCenter, $"Es sind keine Spieler in Ihrer Nähe.", 5000);
        //NAPI.Util.ConsoleOutput("-------- DEBUG CMD PLAYER: endgültiges Ziehen");
    }

    public static void CMD_prison(Client player, Client target)
    {
        if (AccountManage.GetPlayerGroup(player) == 0)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "ERROR:~w~ Sie befinden sich nicht in einer Polizeigruppe.");
            return;
        }
        if (AccountManage.GetPlayerRank(player) == -1)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "ERROR:~w~ Ihre Position hat keine Voraussetzungen für die Verwendung dieses Befehls.");
            return;
        }
        if (!Main.IsInRangeOfPoint(player.Position, new Vector3(1690.666, 2592.404, 45.74735), 3.0f) && !Main.IsInRangeOfPoint(player.Position, new Vector3(-450.0119, 6016.234, 31.71639), 3.0f))
        {
            NAPI.Notification.SendNotificationToPlayer(player, "ERROR:~w~ Sie müssen sich im Haftbereich in der Nähe der Zellen aufhalten, um einen Spieler zu verhaften.");
            return;
        }
        target = Police.Calcular_Prisao(NAPI.Data.GetEntityData(target, "character_name"));
        if (target != null)
        {
            if (Main.IsInRangeOfPoint(target.Position, player.Position, 3) && target.GetData("character_wanted_level") > 0 && player != target)
            {

                if (NAPI.Data.GetEntityData(target, "SendoArrastado") == true)
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "ERROR:~w~ Sie müssen den Player nicht mehr ziehen, bevor Sie ihn verhaften.");
                    return;
                }

                int minutes = 0;
                int tempo = 65;
                if (tempo == 0)
                {
                    minutes = Police.Calcular_Prisao(target.GetData("character_name"));
                }
                else if (tempo > 0)
                {
                    minutes = tempo * 60 * 60;
                }

                if (minutes == 0)
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "Es wurde keine Zeit für die Festnahme eines Spielers festgelegt.Stellen Sie sicher, dass Sie eine Zeit gesetzt haben oder ob er ein gesuchter Spieler ist.");
                    return;
                }

                NAPI.Notification.SendNotificationToPlayer(target, "Sie wurden wegen ~b~" + AccountManage.GetCharacterName(player) + "~w~ verhaftet für~g~" + minutes + "~w~ Sekunden.");
                NAPI.Notification.SendNotificationToPlayer(player, "Du bist ~b~" + AccountManage.GetCharacterName(target) + "~w~ verhaftet für ~g~" + minutes + "~w~ Sekunden.");

                Main.SendMessageWithTagToAll("" + Main.EMBED_LIGHTRED + "[Polizei]", "" + Main.EMBED_WHITE + "" + AccountManage.GetCharacterName(target) + " wurde für verhaftet " + AccountManage.GetCharacterName(player) + " von " + minutes + " Sekunden.");

                player.TriggerEvent("createNewHeadNotificationAdvanced", "Sie haben den Spieler ~y~" + AccountManage.GetCharacterName(target) + "~w~ verhaftet für ~g~" + minutes + "~w~ Sekunden.");

                int count = 0;
                foreach (var teste in Main.prison_spawns)
                {
                    count++;
                }
                Random rnd = new Random();
                int index = rnd.Next(0, count);

                target.Position = Main.prison_spawns[index].position;
                target.Rotation = Main.prison_spawns[index].rotation;

                target.SetClothes(1, 0, 0);
                target.SetClothes(5, 0, 0);
                target.SetClothes(1, 0, 0);
                target.SetClothes(7, 0, 0);
                target.SetClothes(9, 0, 0);
                NAPI.Player.ClearPlayerAccessory(target, 0);
                NAPI.Player.ClearPlayerAccessory(target, 1);
                NAPI.Player.ClearPlayerAccessory(target, 2);
                NAPI.Player.ClearPlayerAccessory(target, 6);
                NAPI.Player.ClearPlayerAccessory(target, 7);

                if (target.GetSharedData("CHARACTER_ONLINE_GENRE") == 0)
                {
                    target.SetClothes(4, 3, 7);
                    target.SetClothes(11, 5, 0);
                    target.SetClothes(3, 5, 0);
                    target.SetClothes(8, 0, 18);
                    target.SetClothes(6, 8, 0);
                }
                else
                {
                    target.SetClothes(4, 3, 7);
                    target.SetClothes(11, 5, 0);
                    target.SetClothes(3, 4, 0);
                    target.SetClothes(8, 0, 18);
                    target.SetClothes(6, 1, 0);
                }

                target.SetData("character_prison", 1);
                target.SetData("character_prison_cell", index);
                target.SetData("character_prison_time", minutes);
                target.SetData("character_wanted_level", 0);

                target.SetData("playerCuffed", 0);
                target.StopAnimation();

                //target.TriggerEvent("freezeEx", false);
                target.TriggerEvent("setFollow", false, player);
                Police.ClearPlayerCrime(target);
                cellphoneSystem.FinishCall(target);
                return;
            }
        }
        NAPI.Notification.SendNotificationToPlayer(player, "ERROR:~w~ O Der Spieler ist nicht in Ihrer Nähe oder er ist kein Gesuchter.");
    }

}

