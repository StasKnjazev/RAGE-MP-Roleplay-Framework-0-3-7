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

class playerCommands : Script
{
    [Flags]
    public enum AnimationFlags
    {
        Loop = 1 << 0,
        StopOnLastFrame = 1 << 1,
        OnlyAnimateUpperBody = 1 << 4,
        AllowPlayerControl = 1 << 5,
        Cancellable = 1 << 7
    }

    
    [Command("pos")]
    public static void ShowPosition(Client player, double x = 0, double y = 0, double z = 0)
    {
        if (x == 0 && y == 0 && z == 0)
        {
            NAPI.Notification.SendNotificationToPlayer(player,"Position: " + player.Position.X + "  " + player.Position.Y + "  " + player.Position.Z);
            NAPI.Notification.SendNotificationToPlayer(player,"Rotation: " + player.Rotation.X + "  " + player.Rotation.Y + "  " + player.Rotation.Z);
        }
        else
            player.Position = new Vector3(x, y, z);
    }

    [Command("fixvoice")]
    public void CMD_FixVoice(Client player, Client target)
    {
		player.DisableVoiceTo(player);
	
        NAPI.Task.Run(() =>
        {
            player.EnableVoiceTo(target);
            //If you want it to be bidirectional
            target.EnableVoiceTo(player);
        }, delayTime: 500);
        Main.SendInfoMessage(player, "Du hast den Voice Reconnect erfolgreich gestartet!");
    }	
	
    [Command("vehs")]
    public void ME_Command(Client player)
    {
        player.TriggerEvent("showMain");
    }

    [Command("cruise", "/cruise [Geschwindikeit]")]
    public void CMD_cruise(Client player, string value)
    {
        if (player.IsInVehicle && player.VehicleSeat == -1)
        {
            if(value == "off")
            {
                player.SetData("SpeedLimit", false);
                player.TriggerEvent("speed_limiter_command", "off");
                return;
            }

            player.SetData("SpeedLimit", true);
            player.SetData("SpeedLimitValue", value);
            player.TriggerEvent("speed_limiter_command", value);
            Main.SendInfoMessage(player, "Tempolimit für Tempomat eingestellt auf " + Main.EMBED_YELLOW+value+ " KM/H"+Main.EMBED_WHITE+". "+Main.EMBED_GREY+"(Drücke ~y~L~c~ )");
        }
        else
        {
            Main.DisplayErrorMessage(player, "Dieser Befehl kann nicht innerhalb eines Fahrzeugs verwendet werden.");
        }
    }

    [Command("licencas", Alias = "lic,licenças", GreedyArg = true)]
    public static void CMD_lic(Client player)
    {
        Main.SendMessageWithTagToPlayer(player, "" + Main.EMBED_LIGHTGREEN + "", "" + Main.EMBED_LIGHTGREEN + "-------------------------------------");
        Main.SendMessageWithTagToPlayer(player, "" + Main.EMBED_LIGHTGREEN + "", "" + Main.EMBED_YELLOW + " Lizenzen:");

        if (player.GetData("character_car_lic") == 1)
        {
            Main.SendMessageWithTagToPlayer(player, "" + Main.EMBED_BLUE + "Führerschein", ""+Main.EMBED_GREEN+"in Besitz.");
        }
        else
        {
            Main.SendMessageWithTagToPlayer(player, "" + Main.EMBED_BLUE + "Führerschein", "" + Main.EMBED_GREY + "Nicht in Besitz.");
        }

        if (player.GetData("character_truck_lic") == 1)
        {
            Main.SendMessageWithTagToPlayer(player, "" + Main.EMBED_BLUE + "LKW-Führerschein", "" + Main.EMBED_GREEN + "in Besitz.");
        }
        else
        {
            Main.SendMessageWithTagToPlayer(player, "" + Main.EMBED_BLUE + "LKW-Führerschein", "" + Main.EMBED_GREY + "Nicht in Besitz.");
        }

        if (player.GetData("character_fly_lic") == 1)
        {
            Main.SendMessageWithTagToPlayer(player, "" + Main.EMBED_BLUE + "Brevê", "" + Main.EMBED_GREEN + "in Besitz.");
        }
        else
        {
            Main.SendMessageWithTagToPlayer(player, "" + Main.EMBED_BLUE + "Brevê", "" + Main.EMBED_GREY + "Nicht in Besitz.");
        }

        if (player.GetData("character_fish_lic") == 1)
        {
            Main.SendMessageWithTagToPlayer(player, "" + Main.EMBED_BLUE + "Angelschein", "" + Main.EMBED_GREEN + "in Besitz.");
        }
        else
        {
            Main.SendMessageWithTagToPlayer(player, "" + Main.EMBED_BLUE + "Angelschein", "" + Main.EMBED_GREY + "Nicht in Besitz.");
        }
        if (player.GetData("character_taxi_lic") == 1)
        {
            Main.SendMessageWithTagToPlayer(player, "" + Main.EMBED_BLUE + "Taxi-Schein", "" + Main.EMBED_GREEN + "in Besitz.");
        }
        else
        {
            Main.SendMessageWithTagToPlayer(player, "" + Main.EMBED_BLUE + "Taxi-Schein", "" + Main.EMBED_GREY + "Nicht in Besitz.");
        }
        if (player.GetData("character_gun_lic") == 1)
        {
            Main.SendMessageWithTagToPlayer(player, "" + Main.EMBED_BLUE + "Waffenschein", "" + Main.EMBED_GREEN + "in Besitz.");
        }
        else
        {
            Main.SendMessageWithTagToPlayer(player, "" + Main.EMBED_BLUE + "Waffenschein", "" + Main.EMBED_GREY + "Nicht in Besitz.");
        }
        if (player.GetData("character_lawyer_lic") == 1)
        {
            Main.SendMessageWithTagToPlayer(player, "" + Main.EMBED_BLUE + "Anwaltliches Zertifikat", "" + Main.EMBED_GREEN + "in Besitz.");
        }
        else
        {
            Main.SendMessageWithTagToPlayer(player, "" + Main.EMBED_BLUE + "Anwaltliches Zertifikat", "" + Main.EMBED_GREY + "Nicht in Besitz.");
        }
        if (player.GetData("character_cycles_lic") == 1)
        {
            Main.SendMessageWithTagToPlayer(player, "" + Main.EMBED_BLUE + "Motorrad-Führerschein", "" + Main.EMBED_GREEN + "in Besitz.");
        }
        else
        {
            Main.SendMessageWithTagToPlayer(player, "" + Main.EMBED_BLUE + "Motorrad-Führerschein", "" + Main.EMBED_GREY + "Nicht in Besitz.");
        }
    }


    [Command("mostrarlicencas", Alias = "ml,mostarlicenca,mostarlic", GreedyArg = true)]
    public static void CMD_mostrarlicencas(Client player, string idOrName)
    {
        Client target = Main.findPlayer(player, idOrName);

        if (target != null)
        {
            if(target.GetData("status") == false)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Bürger ist nicht da.");
                return; 
            }
            Main.SendInfoMessage(player, "Sie haben Ihre Lizenzliste angezeigt " + Main.EMBED_BLUE+""+AccountManage.GetCharacterName(target)+""+Main.EMBED_WHITE+".");

            Main.SendMessageWithTagToPlayer(target, "" + Main.EMBED_LIGHTGREEN + "", "" + Main.EMBED_LIGHTGREEN + "-------------------------------------");
            Main.SendMessageWithTagToPlayer(target, "" + Main.EMBED_LIGHTGREEN + "", "" + Main.EMBED_YELLOW + "Lizenzen " + AccountManage.GetCharacterName(player) + ":");

            if (player.GetData("character_car_lic") == 1)
            {
                Main.SendMessageWithTagToPlayer(target, "" + Main.EMBED_BLUE + "PKW-Führerschein", "" + Main.EMBED_GREEN + "in Besitz");
            }
            else
            {
                Main.SendMessageWithTagToPlayer(target, "" + Main.EMBED_BLUE + "PKW-Führerschein", "" + Main.EMBED_GREY + "Nicht in Besitz.");
            }

            if (player.GetData("character_truck_lic") == 1)
            {
                Main.SendMessageWithTagToPlayer(target, "" + Main.EMBED_BLUE + "LKW-Führerschein", "" + Main.EMBED_GREEN + "in Besitz.");
            }
            else
            {
                Main.SendMessageWithTagToPlayer(target, "" + Main.EMBED_BLUE + "LKW-Führerschein", "" + Main.EMBED_GREY + "Nicht in Besitz.");
            }

            if (player.GetData("character_fly_lic") == 1)
            {
                Main.SendMessageWithTagToPlayer(target, "" + Main.EMBED_BLUE + "Flugschein", "" + Main.EMBED_GREEN + "in Besitz.");
            }
            else
            {
                Main.SendMessageWithTagToPlayer(target, "" + Main.EMBED_BLUE + "Flugschein", "" + Main.EMBED_GREY + "Nicht in Besitz.");
            }

            if (player.GetData("character_fish_lic") == 1)
            {
                Main.SendMessageWithTagToPlayer(target, "" + Main.EMBED_BLUE + "Angelschein", "" + Main.EMBED_GREEN + "in Besitz.");
            }
            else
            {
                Main.SendMessageWithTagToPlayer(target, "" + Main.EMBED_BLUE + "Angelschein", "" + Main.EMBED_GREY + "Nicht in Besitz.");
            }

            if (player.GetData("character_taxi_lic") == 1)
            {
                Main.SendMessageWithTagToPlayer(target, "" + Main.EMBED_BLUE + "Taxi-Schein", "" + Main.EMBED_GREEN + "in Besitz.");
            }
            else
            {
                Main.SendMessageWithTagToPlayer(target, "" + Main.EMBED_BLUE + "Taxi-Schein", "" + Main.EMBED_GREY + "Nicht in Besitz.");
            }

            if (player.GetData("character_gun_lic") == 1)
            {
                Main.SendMessageWithTagToPlayer(target, "" + Main.EMBED_BLUE + "Waffenschein", "" + Main.EMBED_GREEN + "in Besitz.");
            }
            else
            {
                Main.SendMessageWithTagToPlayer(target, "" + Main.EMBED_BLUE + "Waffenschein", "" + Main.EMBED_GREY + "Nicht in Besitz.");
            }
            if (player.GetData("character_lawyer_lic") == 1)
            {
                Main.SendMessageWithTagToPlayer(player, "" + Main.EMBED_BLUE + "Anwaltliches Zertifikat", "" + Main.EMBED_GREEN + "in Besitz.");
            }
            else
            {
                Main.SendMessageWithTagToPlayer(player, "" + Main.EMBED_BLUE + "Anwaltliches Zertifikat", "" + Main.EMBED_GREY + "Nicht in Besitz.");
            }
            if (player.GetData("character_cycles_lic") == 1)
            {
                Main.SendMessageWithTagToPlayer(player, "" + Main.EMBED_BLUE + "Motorrad-Führerschein", "" + Main.EMBED_GREEN + "in Besitz.");
            }
            else
            {
                Main.SendMessageWithTagToPlayer(player, "" + Main.EMBED_BLUE + "Motorrad-Führerschein", "" + Main.EMBED_GREY + "Nicht in Besitz.");
            }
        }
        else
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Bürger ist nicht da.");
        }

    }
    [Command("pagar", "~y~USAGE: ~w~/id [id/PartOfName] [quantia]")]
    public void pagar(Client sender, string idOrName, int value)
    {
        Client target = Main.findPlayer(sender, idOrName);
        if (target != null)
        {
            if(Main.GetPlayerMoney(sender) < value)
            {
                Main.SendErrorMessage(sender, "Sie haben diesen Betrag nicht bei sich.");
                return;
            }

            Main.SendInfoMessage(sender, "Du hast das gegeben "+AccountManage.GetCharacterName(target)+ " $" + value.ToString("N0")+".");
            Main.SendInfoMessage(target, "Du hast erhalten $" + value.ToString("N0") + " von " + AccountManage.GetCharacterName(sender) +".");


            Main.GivePlayerMoney(sender, -value);
            Main.GivePlayerMoney(target, value);

        }
    }


    [Command("id", "~y~USAGE: ~w~/id [id/PartOfName]")]
    public void GetPlayerId(Client sender, string idOrName)
    {
        //NAPI.Util.ConsoleOutput("-------- DEBUG CMD PLAYER: id starten");
        Client target = Main.findPlayer(sender, idOrName);
        if (target != null)
        {
            NAPI.Notification.SendNotificationToPlayer(sender, string.Format("~w~{0} ~w~(ID:~y~ {1}~w~) (Ping:~y~ {2}~w~)", AccountManage.GetCharacterName(target), Main.getIdFromClient(target), NAPI.Player.GetPlayerPing(target)));
        }
        //NAPI.Util.ConsoleOutput("-------- DEBUG CMD PLAYER: endgültige id");
    }

    [Command("lock", Alias = "trava, trancarveiculo, destrancarveiculo, trancarcarro, destrancarcarro")]
    public void CMD_locked(Client player)
    {
        Vehicle vehicle = Utils.GetClosestVehicle(player, 5.0f);

        if (!NAPI.Entity.DoesEntityExist(vehicle))
        {
            NAPI.Notification.SendNotificationToPlayer(player," Sie sind nicht in der Nähe eines Fahrzeugs, das Sie besitzen.");
            return;
        }

        for (int index = 0; index < PlayerVehicle.MAX_PLAYER_VEHICLES; index++)
        {
            if (vehicle == NAPI.Data.GetEntityData(player, "character_data_vehicle_" + index + "_handle"))
            {
                if (NAPI.Vehicle.GetVehicleLocked(vehicle) == true)
                {
                    NAPI.Vehicle.SetVehicleLocked(vehicle, false);
                    Main.SendInfoMessage(player, "Sie haben Ihr  ~g~Fahrzeug geöffnet~w~ .");
                }
                else
                {
                    NAPI.Vehicle.SetVehicleLocked(vehicle, true);
                    Main.SendInfoMessage(player, "Sie haben Ihr  Fahrzeug abgeschlossen~w~.");

                }
                return;
            }
        }
        NAPI.Notification.SendNotificationToPlayer(player," Sie sind nicht in der Nähe eines Fahrzeugs, das Sie besitzen.");
    }

    [Command("membros")]
    public void CMD_membros(Client player)
    {
        if (AccountManage.GetPlayerGroup(player) == 0)
        {
            Main.DisplayErrorMessage(player, "Du bist kein Mitglied einer Fraktion..");
        }
        int faction = AccountManage.GetPlayerGroup(player);
        int rank = AccountManage.GetPlayerRank(player);

        NAPI.Notification.SendNotificationToPlayer(player,"<font color='#00BB99'>[" + FactionManage.faction_data[faction].faction_name + "] Mietglieder:");
        var players = NAPI.Pools.GetAllPlayers();
        foreach (var target in players)
        {
            if (AccountManage.GetPlayerGroup(target) == faction)
            {
                NAPI.Notification.SendNotificationToPlayer(player,"<font color='#fff000'> " + AccountManage.GetCharacterName(target) + " (id: " + Main.getIdFromClient(target) + ") - Cargo: " + FactionManage.faction_data[faction].faction_rank[rank] + " (" + rank + ")");
            }
        }
    }


    [Command("mug", Alias = "assaltar")]
    public void CMD_mug(Client player, string idOrName)
    {
        Client target = Main.findPlayer(player, idOrName);

        if (target == null)
        {
            return;
        }

        if (FactionManage.GetPlayerGroupType(player) != 4)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Nur Bandenmitglieder können einen Spieler angreifen.");
            return;
        }

        if (!Main.IsInRangeOfPoint(player.Position, target.Position, 2.0f))
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Dieser Spieler ist nicht in Ihrer Nähe.");
            return;
        }

        if (target.HasData("mug_timeout") && NAPI.Data.GetEntityData(target, "mug_timeout") < DateTime.Now)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Dieser Bürger wurde vor kurzem ausgeraubt.");
            return;
        }

        if (target.GetData("handsup") == false)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Dieser Bürger hält seine Hände nicht hoch.");
            return;
        }

        if(Main.GetPlayerMoney(target) < 2)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Dieser Bürger ist Pleite, Sie haben nichts in seinen Taschen gefunden.");
            return;
        }

        int money = Main.GetPlayerMoney(target) / 2;

        Main.GivePlayerMoney(player, money);
        Main.GivePlayerMoney(target, -money);

        List<Client> proxPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(15, player);
        foreach (Client alvo in proxPlayers)
        {
           // alvo.TriggerEvent("Send_ToChat", "", "<font color ='#C2A2DA'>* " + UsefullyRP.GetPlayerNameToTarget(player, alvo) + " ausgeraubt " + UsefullyRP.GetPlayerNameToTarget(target, alvo) + " Geld in Höhe von geraubt $" + money + ".");
        }

        target.SetData("mug_timeout", DateTime.Now.AddMinutes(15));
    }

    // Chat commands
    [Command("eu", Alias = "me", GreedyArg = true)]
    public void ME_Command(Client player, string mensagem)
    {
        UsefullyRP.SendRoleplayAction(player, mensagem);
    }

    [Command("do", GreedyArg = true)] // do command 
    public void DO_Command(Client player, string mensagem)
    {
        List<Client> proxPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(15, player);
        foreach (Client target in proxPlayers)
        {
            //target.TriggerEvent("Send_ToChat", "", "<font color ='#C2A2DA'>* "+mensagem+" ((" + UsefullyRP.GetPlayerNameToTarget(player, target) + "))");
        }

        //Main.EmoteMessage(player, "(( " + mensagem + " ))");
        NAPI.Notification.SendNotificationToPlayer(player, "" + mensagem + "");
    }

    [Command("g", Alias = "gritar", GreedyArg = true)]
    public void S_Command(Client player, string mensagem)
    {
        List<Client> proxPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(30, player);
        foreach (Client target in proxPlayers)
        {
            //target.TriggerEvent("Send_ToChat", "", UsefullyRP.GetPlayerNameToTarget(player, target) + " "+Main.EMBED_BLUE+"grita: "+Main.EMBED_WHITE+" " + mensagem.ToUpper() + " !!");
        }
        //Main.EmoteMessage(player, "(schreit) " + mensagem + "");
        NAPI.Notification.SendNotificationToPlayer(player, "" + mensagem + "");
    }

    [Command("s", Alias = "sussurar", GreedyArg = true)]
    public void W_Command(Client player, string mensagem)
    {
        List<Client> proxPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(7.5f, player);
        foreach (Client target in proxPlayers)
        {
           // target.TriggerEvent("Send_ToChat", "", UsefullyRP.GetPlayerNameToTarget(player, target) + " " + Main.EMBED_GREY + "sussurra: " + Main.EMBED_WHITE + " " + mensagem);
        }
        //Main.EmoteMessage(player, "(flüstert) " + mensagem + "");
        NAPI.Notification.SendNotificationToPlayer(player, "" + mensagem + "");
    }

    [Command("b", GreedyArg = true)]
    public void B_Command(Client player, string mensagem)
    {
        List<Client> proxPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(7.5f, player);
        foreach (Client target in proxPlayers)
        {
            //target.TriggerEvent("Send_ToChat", "", "" + Main.EMBED_SERVER + "(( " + Main.EMBED_WHITE + "[OOC Local] " + UsefullyRP.GetPlayerNameToTarget(player, target) + ": " + mensagem + " " + Main.EMBED_SERVER + "))");
        }
    }

    [Command("o", Alias = "ooc", GreedyArg = true)]
    public void CMD_ooc(Client player, string mensagem)
    {
        NAPI.Notification.SendNotificationToPlayer(player, "Der OOC - Kanal ist deaktiviert.");
        return;
        //NAPI.Util.ConsoleOutput("-------- DEBUG CMD PLAYER: o inicio");
        if (player.HasData("OOCCommand"))
        {
            if (player.GetData("OOCCommand") == false)
            {


                if (AccountManage.GetPlayerAdmin(player) > 0)
                {
                    Main.SendMessageWithTagToAll("" + Main.EMBED_SERVER + "(( [OOC]", "" + Main.EMBED_SERVER + " [" + adminCommands.GetPlayerAdminRank(player) + "] " + AccountManage.GetCharacterName(player) + " diz: " + mensagem + " ))");
                }
                else
                {

                    Main.SendMessageWithTagToAll("" + Main.EMBED_SERVER + "(( [OOC]", "" + Main.EMBED_SERVER + " [Level "+ NAPI.Data.GetEntityData(player, "character_level") + "] " + AccountManage.GetCharacterName(player) + " diz: " + mensagem + " ))");
                }
                //NAPI.Chat.SendChatMessageToAll("<font color='#009999'>(( [OOC] " + AccountManage.GetCharacterName(player) + " diz: " + mensagem + " ))");
                player.SetData("OOCCommand", true);

                NAPI.Task.Run(() =>
                {
                    player.SetData("OOCCommand", false);
                }, delayTime: 10 * 1000);
            }

            else NAPI.Notification.SendNotificationToPlayer(player, "ERROR:~w~ Sie müssen 10 Sekunden warten, bevor Sie diesen Befehl erneut verwenden.");
        }
        else
        {

            player.SetData("OOCCommand", true);

            NAPI.Task.Run(() =>
            {
                player.SetData("OOCCommand", false);
            }, delayTime: 10 * 1000);
            Main.SendMessageWithTagToAll("" + Main.EMBED_SERVER + "(( [OOC]", "" + Main.EMBED_SERVER + " " + AccountManage.GetCharacterName(player) + " diz: " + mensagem + " ))");
        }
        //NAPI.Util.ConsoleOutput("-------- DEBUG CMD PLAYER: o final");

    }


    [Command("n", Alias = "newbie,noob", GreedyArg = true)]
    public void CMD_newbie(Client player, string mensagem)
    {
        if (player.HasData("OOCCommand"))
        {

            if (player.GetData("OOCCommand") == false)
            {


                if (AccountManage.GetPlayerAdmin(player) > 0)
                {
                    Main.SendMessageWithTagToAll("" + Main.EMBED_NOOB_1 + "(( " + Main.EMBED_NOOB_2 + "Canal /n" + Main.EMBED_NOOB_1 + " ))", "" + Main.EMBED_NOOB_1 + " [" + adminCommands.GetPlayerAdminRank(player) + "] " + AccountManage.GetCharacterName(player) + " (" + Main.getIdFromClient(player) + "): " + mensagem + "");
                }
                else
                {
                    Main.SendMessageWithTagToAll("" + Main.EMBED_NOOB_1 + "(( " + Main.EMBED_NOOB_2 + "Canal /n" + Main.EMBED_NOOB_1 + " ))", "" + Main.EMBED_NOOB_1 + " [Level " + NAPI.Data.GetEntityData(player, "character_level") + "] " + AccountManage.GetCharacterName(player) + " ("+Main.getIdFromClient(player)+"): " + mensagem + "");
                }
                //NAPI.Chat.SendChatMessageToAll("<font color='#009999'>(( [OOC] " + AccountManage.GetCharacterName(player) + " diz: " + mensagem + " ))");
                player.SetData("OOCCommand", true);

                NAPI.Task.Run(() =>
                {
                    player.SetData("OOCCommand", false);
                }, delayTime: 10 * 1000);
            }

            else NAPI.Notification.SendNotificationToPlayer(player, "ERROR:~w~ Sie müssen 10 Sekunden warten, bevor Sie diesen Befehl erneut verwenden.");
        }
        else
        {
            player.SetData("OOCCommand", true);
            //{009999}({009966}Canal /n{009999}) [Level %d] %s (%i): %s
            NAPI.Task.Run(() =>
            {
                player.SetData("OOCCommand", false);
            }, delayTime: 10 * 1000);

            if (AccountManage.GetPlayerAdmin(player) > 0)
            {
                Main.SendMessageWithTagToAll("" + Main.EMBED_NOOB_1 + "(( " + Main.EMBED_NOOB_2 + "Kanal /n" + Main.EMBED_NOOB_1 + " ))", "" + Main.EMBED_NOOB_1 + " [" + adminCommands.GetPlayerAdminRank(player) + "] " + AccountManage.GetCharacterName(player) + " (" + Main.getIdFromClient(player) + "): " + mensagem + "");
            }
            else
            {
                Main.SendMessageWithTagToAll("" + Main.EMBED_NOOB_1 + "(( " + Main.EMBED_NOOB_2 + "Kanal /n" + Main.EMBED_NOOB_1 + " ))", "" + Main.EMBED_NOOB_1 + " [Level " + NAPI.Data.GetEntityData(player, "character_level") + "] " + AccountManage.GetCharacterName(player) + " (" + Main.getIdFromClient(player) + "): " + mensagem + "");
            }

        }
        //NAPI.Util.ConsoleOutput("-------- DEBUG CMD PLAYER: o final");
    }


    [Command("ren", GreedyArg = true)]
    public void CMD_ren(Client player, string idOrName, string mensagem)
    {
        Client target = Main.findPlayer(player, idOrName);
        if (target == null)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Dieser Bürger ist offline.");
            return;
        }

        if (AccountManage.GetPlayerAdmin(player) == 0)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben keine Berechtigung, diesen Befehl zu verwenden.");
            return;
        }
        Main.SendMessageWithTagToAll("" + Main.EMBED_NOOB_1 + "(( " + Main.EMBED_NOOB_2 + "Kanal /n" + Main.EMBED_NOOB_1 + " ))", "" + Main.EMBED_NOOB_1 + " [" + adminCommands.GetPlayerAdminRank(player) + "] " + player.GetData("admin_name") + " (" + Main.getIdFromClient(player) + "): "+Main.EMBED_RED+"@"+ target.GetData("character_name") + ""+Main.EMBED_NOOB_1+" " + mensagem + "");
    }

    [Command("sos", Alias = "/reportar,/relatar", GreedyArg = true)]
    public void CMD_sos(Client player, string mensagem)
    {
        //NAPI.Util.ConsoleOutput("-------- DEBUG CMD PLAYER: o inicio");
        if (player.HasData("OOCCommand"))
        {

            if (player.GetData("OOCCommand") == false)
            {
                foreach(var players in NAPI.Pools.GetAllPlayers())
                {
                    if(player.GetData("status") == true)
                    {
                        if(AccountManage.GetPlayerAdmin(players) > 0)
                        {
                            Main.SendMessageWithTagToPlayer(players, "" + Main.EMBED_REPORT + "(( [SOS]", "" + Main.EMBED_REPORT + " [Level " + NAPI.Data.GetEntityData(player, "character_level") + "] " + AccountManage.GetCharacterName(player) + " relata: " + mensagem + " ))");
                        }
                    }
                }

                Main.SendMessageToPlayer(player, "* Ihre Nachricht wurde an Online-Administratoren gesendet.");

                //NAPI.Chat.SendChatMessageToAll("<font color='#009999'>(( [OOC] " + AccountManage.GetCharacterName(player) + " diz: " + mensagem + " ))");
                player.SetData("OOCCommand", true);

                NAPI.Task.Run(() =>
                {
                    player.SetData("OOCCommand", false);
                }, delayTime: 30 * 1000);
            }

            else NAPI.Notification.SendNotificationToPlayer(player, "ERROR:~w~ Sie müssen 30 Sekunden warten, bevor Sie diesen Befehl erneut verwenden.");
        }
        else
        {
            player.SetData("OOCCommand", true);

            NAPI.Task.Run(() =>
            {
                player.SetData("OOCCommand", false);
            }, delayTime: 10 * 1000);
            foreach (var players in NAPI.Pools.GetAllPlayers())
            {
                if (player.GetData("status") == true)
                {
                    if (AccountManage.GetPlayerAdmin(players) > 0)
                    {
                        Main.SendMessageWithTagToPlayer(players, "" + Main.EMBED_REPORT + "(( [SOS]", "" + Main.EMBED_REPORT + " [Level " + NAPI.Data.GetEntityData(player, "character_level") + "] " + AccountManage.GetCharacterName(player) + " relata: " + mensagem + " ))");
                    }
                }
            }

            Main.SendMessageToPlayer(player, "* Ihre Nachricht wurde an Online - Administratoren gesendet.");
        }
        //NAPI.Util.ConsoleOutput("-------- DEBUG CMD PLAYER: o final");
    }

    [Command("f", Alias = "faction", GreedyArg = true)]
    public void CMD_faction(Client player, string mensagem)
    {
        //NAPI.Util.ConsoleOutput("-------- DEBUG CMD PLAYER: f inicio");
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

        int faction = AccountManage.GetPlayerGroup(player);
        int rank = AccountManage.GetPlayerRank(player);

        var players = NAPI.Pools.GetAllPlayers();

        foreach (Client c in players)
        {
            if (AccountManage.GetPlayerGroup(c) == faction)
            {
                Main.SendMessageWithTagToPlayer(c, "" + Main.EMBED_CYAN + "[Fraktion | " + FactionManage.faction_data[faction].faction_name + "]", "" + Main.EMBED_CYAN + "" + AccountManage.GetCharacterName(player) + " " + Main.EMBED_SERVER + "(( " + Main.EMBED_WHITE + "" + mensagem + "" + Main.EMBED_SERVER + " ))");
                //Main.EmoteMessage(player, "(facção) " + mensagem + "");
                NAPI.Notification.SendNotificationToPlayer(player, "" + mensagem + "");
            }
        }
        //NAPI.Util.ConsoleOutput("-------- DEBUG CMD PLAYER: f final");
    }

    [Command("r", Alias = "radio", GreedyArg = true)]
    public void CMD_radio(Client player, string mensagem)
    {
        //NAPI.Util.ConsoleOutput("-------- DEBUG CMD PLAYER: r inicio");
        if (AccountManage.GetPlayerGroup(player) == 0)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "ERROR:~w~ Sie befinden sich nicht in einer Polizeigruppe..");
            return;
        }
        if (AccountManage.GetPlayerRank(player) == 0)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "ERROR:~w~ Ihre Position hat keine Voraussetzungen für die Verwendung dieses Befehls.");
            return;
        }

        int faction = AccountManage.GetPlayerGroup(player);
        int rank = AccountManage.GetPlayerRank(player);

        var players = NAPI.Pools.GetAllPlayers();

        foreach (Client c in players)
        {
            if (player.GetData("status") == true)
            {
                if (AccountManage.GetPlayerGroup(c) == faction)
                {
                    //NAPI.Notification.SendNotificationToPlayer(c, "<font color='#2671D4'>** [RADIO] " + FactionManage.faction_data[faction].faction_rank[rank] + " " + AccountManage.GetCharacterName(player) + ":~w~ " + mensagem + "");
                    Main.SendMessageWithTagToPlayer(c, "" + Main.EMBED_BLUE + "* [RADIO]", "" + Main.EMBED_BLUE + "" + AccountManage.GetCharacterName(player) + " sagt: " + mensagem + ", austausch.");

                    //Main.EmoteMessage(player, "(radio) " + mensagem + "");
                    NAPI.Notification.SendNotificationToPlayer(player, "" + mensagem + "");
                }

              
            }
        }
        //NAPI.Util.ConsoleOutput("-------- DEBUG CMD PLAYER: r final");
    }

    [Command("cancelar")]
    public void CMD_cancelar(Client player, string nome)
    {
        if (nome == "carga")
        {
            if (player.GetData("shipment") == true)
            {
                NAPI.Notification.SendNotificationToPlayer(player,"* Sie haben Ihre Gebühr storniert.");
                player.SetData("shipment", false);
                //player.TriggerEvent("blip_remove", "LS Go Trucker");
                //player.TriggerEvent("delete_marker");

                if (player.HasData("shipment_vehicle"))
                {
                    Vehicle vehicleid = NAPI.Data.GetEntityData(player, "shipment_vehicle");

                    if (NAPI.Data.HasEntityData(vehicleid, "shipment_business"))
                    {
                        int business_id = NAPI.Data.GetEntityData(vehicleid, "shipment_business");

                        if (Business.business_list[business_id].business_OrderState > 1)
                        {
                            Business.business_list[business_id].business_OrderState = 1;
                            //NAPI.Util.ConsoleOutput("refunded !! ;;;");
                        }


                        if (NAPI.Data.HasEntityData(vehicleid, "shipment_trailerBy")) NAPI.Entity.DeleteEntity(NAPI.Data.GetEntityData(vehicleid, "shipment_trailerBy"));
                        NAPI.Entity.DeleteEntity(vehicleid);
                    }
                }
            }
        }
    }

    [Command("aceitar")]
    public void CMD_aceitar(Client player, string nome)
    {
        //NAPI.Util.ConsoleOutput("-------- DEBUG CMD PLAYER: aceitar inicio");
        if (nome == "morte")
        {
            if (player.GetSharedData("Injured") == 1 && player.GetData("character_prison") == 0)
            {
                Main.sendToHospital(player);
            }
            else NAPI.Notification.SendNotificationToPlayer(player, "ERROR:~w~ Du bist nicht schwer Verletzt.");
        }
        else if(nome == "cura")
        {
            if(player.GetData("curar_offerPrice") != 0)
            {
                //if(!AccountManage.GetPlayerConnected(player.GetData("curar_offerBy")))
                //{
                //    player.SetData("curar_offerBy", -1);
                //    player.SetData("curar_offerPrice", 0);

                //    NAPI.Notification.SendNotificationToPlayer(player, "Der Arzt, der Ihnen eine Kur angeboten hat, ist nicht mehr auf der Insel oder Sie haben kein Heilangebot erhalten.");
                //    return;
                //}
                if(Main.GetPlayerMoney(player) < player.GetData("curar_offerPrice"))
                {
                    player.SetData("curar_offerBy", -1);
                    player.SetData("curar_offerPrice", 0);
                    NAPI.Notification.SendNotificationToPlayer(player, "Sie haben nicht genug Geld, um medizinische Versorgung in Anspruch zu nehmen.");
                    return;
                }

                //if(!Main.IsInRangeOfPoint(player.Position, NAPI.Entity.GetEntityPosition(player.GetData("curar_offerBy")), 30))
                //{
                //    player.SetData("curar_offerBy", -1);
                //    player.SetData("curar_offerPrice", 0);
                //    NAPI.Notification.SendNotificationToPlayer(player, "Sie sind nicht in der Nähe des Arztes, der Sie medizinisch versorgt hat.");
                //    return;
                //}

                NAPI.Player.SetPlayerHealth(player, 100);

                //NAPI.Notification.SendNotificationToPlayer(player, "Sie haben die medizinische Versorgung angenommen ~y~"+ AccountManage.GetCharacterName(player.GetData("curar_offerBy")) + "~w~ por ~g~R$"+ player.GetData("curar_offerPrice").ToString("N0")+ "~w~.");
                //NAPI.Notification.SendNotificationToPlayer(player.GetData("curar_offerBy"), "Der Patient ~y~" + AccountManage.GetCharacterName(player) + "~w~ akzeptierte sein Heilungsangebot für~g~R$" + player.GetData("curar_offerPrice").ToString("N0") + "~w~.");

                Main.GivePlayerMoney(player, -player.GetData("curar_offerPrice"));
                Main.GivePlayerMoney(player, player.GetData("curar_offerPrice"));
                
                player.SetData("curar_offerBy", -1);
                player.SetData("curar_offerPrice", 0);
            }
        }
        else if (nome == "convite")
        {

            if (player.GetData("group_invite") != -1)
            {
                int group_id = player.GetData("group_invite");
                Client inviteBy = NAPI.Data.GetEntityData(player, "group_inviteBy");

                if (Main.IsPlayerLogged(inviteBy) == true)
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "Sie haben die Einladung vom angenommen " + FactionManage.faction_data[group_id].faction_rank[AccountManage.GetPlayerRank(inviteBy)] + " " + AccountManage.GetCharacterName(inviteBy) + ", und jetzt bist du ein Mitglied von " + FactionManage.faction_data[group_id].faction_name + ".");

                    NAPI.Notification.SendNotificationToPlayer(inviteBy, "~y~[INFO]:~w~ " + AccountManage.GetCharacterName(player) + " Ich akzeptiere Ihre Einladung, Ihrer Fraktion beizutreten.");

                    AccountManage.SetPlayerLeader(player, 0);
                    AccountManage.SetPlayerGroup(player, group_id);
                    AccountManage.SetPlayerRank(player, 0);
                    Main.SetPlayerToTeamColor(player);

                    player.SetData("group_invite", -1);
                    player.SetData("group_inviteBy", -1);
                }
                else
                {
                    player.SetData("group_invite", -1);
                    player.SetData("group_inviteBy", -1);

                    NAPI.Notification.SendNotificationToPlayer(player, "ERROR:~w~ Der Spieler, der Sie zur Fraktion eingeladen hat, ist nicht mehr verfügbar.");
                }
            }
            else NAPI.Notification.SendNotificationToPlayer(player, "ERROR:~w~ Sie wurden zu keiner Fraktion eingeladen oder die Einladung ist abgelaufen.");

        }
        //NAPI.Util.ConsoleOutput("-------- DEBUG CMD PLAYER: aceitar final");
    }

    [Command("convidar", "~y~Use: ~w~/convidar [id/PartOfName]")]
    public void CMD_convidar(Client player, string idOrName)
    {
        //NAPI.Util.ConsoleOutput("-------- DEBUG CMD PLAYER: convidar inicio");
        Client target = Main.findPlayer(player, idOrName);
        if (AccountManage.GetPlayerLeader(player) < 1 && AccountManage.GetPlayerLeader(player) > FactionManage.MAX_FACTIONS)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Du bist kein Fraktionsführer..");
            return;
        }
        if (target != null)
        {
            if (target.GetData("status") != true)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Bürger nicht da.");
                return;
            }

            if (AccountManage.GetPlayerGroup(target) != 0)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Bürger ist bereits Mitglied in einer Fraktiob.");
                return;
            }

            if(target.GetData("group_invite") != -1)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Dieser Spieler wurde bereits zu einer Fraktion eingeladen.Bitte warten Sie ca. 30 Sekunden, bis seine Einladung abgelaufen ist.");
                return;
            }

            int group_id = AccountManage.GetPlayerGroup(player);
            target.SetData("group_invite", AccountManage.GetPlayerGroup(player));
            target.SetData("group_inviteBy", player);

            NAPI.Notification.SendNotificationToPlayer(target, "Du ~b~" + FactionManage.faction_data[group_id].faction_rank[AccountManage.GetPlayerRank(player)] + " " + AccountManage.GetPlayerGroup(player) + "~w~ hat eine Einladung angeboten ~g~" + FactionManage.faction_data[group_id].faction_name + "~w~ (Benutze ~y~/aceitar convite~w~).");

            NAPI.Notification.SendNotificationToPlayer(player, "Du hast angeboten " + AccountManage.GetCharacterName(target) + " um das einzugeben" + FactionManage.faction_data[group_id].faction_name + ".");

            NAPI.Task.Run(() =>
            {
                target.SetData("group_inviteBy", -1);
                target.SetData("group_invite", -1);
            }, delayTime: 30 * 1000);

        }
        //NAPI.Util.ConsoleOutput("-------- DEBUG CMD PLAYER: convidar final");
    }


    [Command("expulsar", "~y~Use: ~w~/expulsar [id/PartOfName]")]
    public void CMD_expulsar(Client player, string idOrName)
    {
        //NAPI.Util.ConsoleOutput("-------- DEBUG CMD PLAYER: expulsar inicio");
        Client target = Main.findPlayer(player, idOrName);

        if (AccountManage.GetPlayerLeader(player) < 1 && AccountManage.GetPlayerLeader(player) > FactionManage.MAX_FACTIONS)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Du bist kein Fraktionsführer..");
            return;
        }
        if (target != null)
        {
            if (target.GetData("status") != true)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Bürger ist nicht da.");
                return;
            }

            int group_id = AccountManage.GetPlayerGroup(player);

            if (AccountManage.GetPlayerGroup(target) != group_id)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Bürger ist bereits Mitglied einer Fraktion.");
            }

            NAPI.Notification.SendNotificationToPlayer(target, "Du ~b~" + FactionManage.faction_data[group_id].faction_rank[AccountManage.GetPlayerRank(player)] + " " + AccountManage.GetPlayerGroup(player) + "~w~ hast rausgeworfen ~g~" + FactionManage.faction_data[group_id].faction_name + "~w~.");

            NAPI.Notification.SendNotificationToPlayer(player, "Du hast rausgeschmissen " + AccountManage.GetCharacterName(target) + " den " + FactionManage.faction_data[group_id].faction_name + ".");

            NAPI.Data.SetEntityData(target, "duty", 0);
            Main.UpdatePlayerClothes(target);
            target.SetData("duty", 0);
            Outfits.RemovePlayerDutyOutfit(target);
            AccountManage.SetPlayerLeader(target, 0);
            AccountManage.SetPlayerGroup(target, 0);
            AccountManage.SetPlayerRank(target, 0);
            AccountManage.SaveCharacter(target);
            Main.SetPlayerToTeamColor(target);

        }
        //NAPI.Util.ConsoleOutput("-------- DEBUG CMD PLAYER: expulsar final");
    }

    [Command("promover", "~y~Use: ~w~/promover [id/PartOfName]")]
    public void CMD_promover(Client player, string idOrName)
    {
        //NAPI.Util.ConsoleOutput("-------- DEBUG CMD PLAYER: promover inicio");
        Client target = Main.findPlayer(player, idOrName);

        if (AccountManage.GetPlayerLeader(player) < 1 && AccountManage.GetPlayerLeader(player) > FactionManage.MAX_FACTIONS)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Du bist kein Fraktionsführer..");
            return;
        }
        if (target != null)
        {
            if(target == player)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Sie können sich nicht selbst bewerben.");
                return;
            }
            if (target.GetData("status") != true)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Der Bürger it nicht da.");
                return;
            }
            int group_id = AccountManage.GetPlayerGroup(player);

            if (AccountManage.GetPlayerGroup(target) != group_id)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Der Bürger ist bereits Mitglied einer Fraktion.");
            }

            if (AccountManage.GetPlayerRank(target) == FactionManage.GetMaxRank(group_id) - 1)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Dieser Spieler befindet sich bereits in der maximal zulässigen Position.");
                return;
            }

            NAPI.Notification.SendNotificationToPlayer(target, "Du ~b~" + FactionManage.faction_data[group_id].faction_rank[AccountManage.GetPlayerRank(player)] + " " + AccountManage.GetPlayerGroup(player) + "~w~ wurdest befördert ~g~" + FactionManage.faction_data[group_id].faction_rank[AccountManage.GetPlayerRank(target) + 1] + "~w~.");

            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben befördert " + AccountManage.GetCharacterName(target) + " zum " + FactionManage.faction_data[group_id].faction_rank[AccountManage.GetPlayerRank(target) + 1] + ".");

            AccountManage.SetPlayerRank(target, AccountManage.GetPlayerRank(target) + 1);
        }
        //NAPI.Util.ConsoleOutput("-------- DEBUG CMD PLAYER: promover final");
    }

    [Command("setstation", "~y~USAGE: ~w~/setstation [id/PartOfName]")]
    public void CMD_setstation(Client player, string station)
    {
        if(player.IsInVehicle)
        {
            player.TriggerEvent("AddRadio", player.Position.X, player.Position.Y, player.Position.Z, station, player.Vehicle);
        }
        else player.TriggerEvent("AddRadio", player.Position.X, player.Position.Y, player.Position.Z, station, null);
    }


    [Command("station", "~y~USAGE: ~w~/setstation [id/PartOfName]")]
    public void CMD_station(Client player, int station)
    {
        player.TriggerEvent("Update", player.Position.X, player.Position.Y, player.Position.Z, player.Vehicle, 1.0);
    }


    [Command("rebaixar", "~y~Use: ~w~/rebaixar [id/PartOfName]")]
    public void CMD_rebaixar(Client player, string idOrName)
    {
        //NAPI.Util.ConsoleOutput("-------- DEBUG CMD PLAYER: rebaixar inicio");
        Client target = Main.findPlayer(player, idOrName);
        if (AccountManage.GetPlayerLeader(player) < 1 && AccountManage.GetPlayerLeader(player) > FactionManage.MAX_FACTIONS)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Você não é líder de uma facção.");
            return;
        }
        if (target != null)
        {
            if (target.GetData("status") != true)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Der Bürger ist nicht da.");
                return;
            }
            int group_id = AccountManage.GetPlayerGroup(player);

            if (AccountManage.GetPlayerGroup(target) != group_id)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Der Bürger ist bereits Mitglied einer Fraktiob.");
            }

            if (AccountManage.GetPlayerRank(target) == 0)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Dieser Bürger hat bereits den kleinsten Rang.");
                return;
            }

            NAPI.Notification.SendNotificationToPlayer(target, "Du ~b~" + FactionManage.faction_data[group_id].faction_rank[AccountManage.GetPlayerRank(player)] + " " + AccountManage.GetPlayerGroup(player) + "~w~ wurdest degradiert ~g~" + FactionManage.faction_data[group_id].faction_rank[AccountManage.GetPlayerRank(target) - 1] + "~w~.");

            NAPI.Notification.SendNotificationToPlayer(player, "Du bist degradiert " + AccountManage.GetCharacterName(target) + " zum " + FactionManage.faction_data[group_id].faction_rank[AccountManage.GetPlayerRank(target) - 1] + ".");

            AccountManage.SetPlayerRank(target, AccountManage.GetPlayerRank(target) - 1);
        }
        //NAPI.Util.ConsoleOutput("-------- DEBUG CMD PLAYER: rebaixar final");
    }
}