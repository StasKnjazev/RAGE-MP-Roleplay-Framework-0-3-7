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
using DerStr1k3r.RemoteEventManager;

class adminCommands : Script
{
    public static int TESTER = 1;
    public static int HELPER = 2;
    public static int GAME_ADMIN_1 = 3;
    public static int GAME_ADMIN_2 = 4;
    public static int GAME_ADMIN_3 = 5;
    public static int LEAD_ADMIN = 6;
    public static int DIRECTOR = 7;
    public static int COORDENADOR = 8;
    public static int DEVELOPER = 9;
    public static int MANAGMENT = 10;
    private int weather;

    [RemoteEvent("kickclient")]
    public static void kickclient(Client player)
    {
        player.Kick();
    }

    [Command("pskin1")]
    public static void ChangeSkinCommand1(Client player)
    {
        if (AccountManage.GetPlayerAdmin(player) < 8)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben keine Berechtigung, diesen Befehl zu verwenden .");
            return;
        }

        NAPI.Player.SetPlayerSkin(player, 307287994);
    }

    [Command("pskin2")]
    public static void ChangeSkinCommand2(Client player)
    {
        if (AccountManage.GetPlayerAdmin(player) < 8)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben keine Berechtigung, diesen Befehl zu verwenden .");
            return;
        }

        NAPI.Player.SetPlayerSkin(player, 111281960);
    }

    [Command("pskin3")]
    public static void ChangeSkinCommand3(Client player)
    {
        if (AccountManage.GetPlayerAdmin(player) < 8)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben keine Berechtigung, diesen Befehl zu verwenden .");
            return;
        }

        NAPI.Player.SetPlayerSkin(player, 1832265812);
    }

    [Command("pskin4")]
    public static void ChangeSkinCommand4(Client player)
    {
        if (AccountManage.GetPlayerAdmin(player) < 8)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben keine Berechtigung, diesen Befehl zu verwenden .");
            return;
        }

        NAPI.Player.SetPlayerSkin(player, 1126154828);
    }

    [Command("pskin5")]
    public static void ChangeSkinCommand5(Client player)
    {
        if (AccountManage.GetPlayerAdmin(player) < 8)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben keine Berechtigung, diesen Befehl zu verwenden .");
            return;
        }

        NAPI.Player.SetPlayerSkin(player, 882848737);
    }

    [Command("pskin6")]
    public static void ChangeSkinCommand6(Client player)
    {
        if (AccountManage.GetPlayerAdmin(player) < 8)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben keine Berechtigung, diesen Befehl zu verwenden .");
            return;
        }

        NAPI.Player.SetPlayerSkin(player, 1125994524);
    }

    [Command("pskin7")]
    public static void ChangeSkinCommand7(Client player)
    {
        if (AccountManage.GetPlayerAdmin(player) < 8)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben keine Berechtigung, diesen Befehl zu verwenden .");
            return;
        }

        NAPI.Player.SetPlayerSkin(player, 1462895032);
    }

    [Command("pdel")]
    public static void ChangeSkinCommand8(Client player)
    {
        if (AccountManage.GetPlayerAdmin(player) < 8)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben keine Berechtigung, diesen Befehl zu verwenden .");
            return;
        }
        
        //NAPI.Player.
        UsefullyRP.CMD_AdminCharClothes(player);
    }


    [Command("q", Alias = "quit")]
    public static void CMD_disconnect(Client player)
    {
        //player.TriggerEvent("quitcmd");
        player.TriggerEvent("quitcmd");
    }

    [RemoteEvent("playerReady")]
    public static void start_blackout(Client player)
    {
        player.TriggerEvent("SetBlackoutState");
    }

    [Command("startepurge2", Alias = "purged")]
    public void CMD_purgebanned(Client player)
    {
        if (AccountManage.GetPlayerAdmin(player) < 2)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben keine Berechtigung, diesen Befehl zu verwenden .");
            return;
        }

        var players = NAPI.Pools.GetAllPlayers();
        foreach (var target in players)
        {
            if (target.GetData("status") == true)
            {
                target.TriggerEvent("Purge_Banned_Player");
                NAPI.World.SetWeather(Weather.THUNDER);
                player.TriggerEvent("SetBlackoutState");
            }
            else
            {
                player.TriggerEvent("SetBlackoutState", false);
                NAPI.World.SetWeather(Weather.CLEAR);
            }
        }

        NAPI.Task.Run(() =>
        {
            foreach (var target in players)
            {
                if (target.GetData("status") == true)
                {
                        target.TriggerEvent("Destroy_Purge_Banned_Player");
                }
            }
        }, delayTime: 110100);


        NAPI.Task.Run(() =>
        {
            foreach (var target in players)
            {
                if (target.GetData("status") == true)
                {
                    Main.ShowColorShardAll(target, "~y~Es gibt ein Versteck", "wo du Hilfe bekommst!", 2, 10, 6500);
                }
            }
        }, delayTime: 115000);
        
    }

    [Command("startepurge", Alias = "purged")]
    public static void CMD_purgebanned2(Client player)
    {
        if (AccountManage.GetPlayerAdmin(player) < 2)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben keine Berechtigung, diesen Befehl zu verwenden .");
            return;
        }

        var players = NAPI.Pools.GetAllPlayers();
        foreach (var target in players)
        {
            if (target.GetData("status") == true)
            {
                target.TriggerEvent("Purge_Banned_Player");
                NAPI.World.SetWeather(Weather.THUNDER);
                player.TriggerEvent("SetBlackoutState");
            }
            else
            {
                player.TriggerEvent("SetBlackoutState", false);
                NAPI.World.SetWeather(Weather.CLEAR);
            }
        }
    }


    [Command("msgtoall", Alias = "mta")]
    public void OnChatMessageHandler(Client player, string msg)
    {
        if (AccountManage.GetPlayerAdmin(player) < 1)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben keine Berechtigung, diesen Befehl zu verwenden .");
            return;
        }

        if (msg.Contains("_"))
        {
            msg = msg.Replace("_", " ");
        }
        NAPI.Notification.SendNotificationToAll(msg);
    }

    [Command("aprisao", "~y~Uso:~w~ /aprison [id/PartOfName] [minutos] [motivo]", GreedyArg = true)]
    public void CMD_setdimensao(Client player, string idOrName, int minutes, string reason)
    {
        if (AccountManage.GetPlayerAdmin(player) < 1)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben keine Berechtigung, diesen Befehl zu verwenden .");
            return;
        }

        Client target = Main.findPlayer(player, idOrName);

        if (target == null)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Dieser Player ist derzeit offline.");
            return;
        }

        if (target.GetData("status") != true)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Dieser Player ist derzeit offline.");
            return;
        }

        if(reason.Length < 3 && reason.Length > 34)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Das Gefängnis muss einen plausiblen Grund über 3 Zeichen haben");
            return;
        }

        if(minutes < 1)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Die Gefängniszeit sollte länger als 1 Minute sein.");
            return;
        }

        OOC_Prison(target, player, minutes * 60, reason);
    }

    [Command("atirarprisao", "~y~Uso:~w~ /atirarprisao [id/PartOfName] [motivo]", GreedyArg = true)]
    public void CMD_setdimensao(Client player, string idOrName, string reason)
    {
        if (AccountManage.GetPlayerAdmin(player) < 1)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben keine Berechtigung, diesen Befehl zu ");
            return;
        }

        Client target = Main.findPlayer(player, idOrName);

        if (target == null)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Dieser Player ist derzeit offline.");
            return;
        }

        if (target.GetData("status") != true)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Dieser Player ist derzeit offline.");
            return;
        }

        if (reason.Length < 3 && reason.Length > 34)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Muss einen plausiblen Grund über 3 Zeichen haben.");
            return;
        }

        if(player.GetData("character_ooc_prison_time") < 2)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Dieser Spieler ist nicht in einem OOC - Gefängnis eingesperrt.");
            return;
        }

        target.SetData("character_ooc_prison_time", 2);

        NAPI.Chat.SendChatMessageToAll("~y~-OperServer- " + AccountManage.GetCharacterName(target) + " wurde aus dem OOC - Gefängnis von " + GetPlayerAdminRank(player) + " " + player.GetData("admin_name") + ". Grund: " + reason + ".");
        Main.SendInfoMessage(target, "Sie wurden aus dem OOC entfernt " + GetPlayerAdminRank(player) + " " + player.GetData("admin_name") + ".");
        Main.SendInfoMessage(player, "Sie haben sich zurückgezogen " + AccountManage.GetCharacterName(target) + " des OOC - Gefängnisses.");
    }

    public static void OOC_Prison(Client player, Client admin, int time, string reason)
    {
        int new_time = time;
        if (NAPI.Data.GetEntityData(player, "character_prison") > 0)
        {
            new_time += player.GetData("character_prison_time");
            player.SetData("character_prison", 0);
            player.SetData("character_prison_time", 0);
        }
        player.SetData("character_ooc_prison_time", new_time);

        NAPI.Chat.SendChatMessageToAll("~y~-OperServer- " + AccountManage.GetCharacterName(player) + " wurde von OOC ins Gefängnis geschickt " + GetPlayerAdminRank(admin) + " "+ admin.GetData("admin_name") + ". Grund: " + reason + ".");
        Main.SendInfoMessage(player, "Sie wurden für ins Gefängnis geschickt" + GetPlayerAdminRank(admin) + " " + admin.GetData("admin_name") + "von " + time + " Sekunden.");
        Main.SendInfoMessage(admin, "Du hast geschickt " + AccountManage.GetCharacterName(player) + "für OOC Inhaftierung " + time + " Sekunden.");

        SendBackToPrison(player);
    }

    public static void SendBackToPrison(Client player)
    {
        if (player.GetData("character_ooc_prison_time") > 0)
        {
            player.Position = new Vector3(1651.297, 2573.728, 45.56485);
            player.Rotation = new Vector3(0, 0, 181.6034);
            player.Dimension = 255;
        }
    }

    public static string GetPlayerAdminRank(Client player)
    {
        string rank = "Nenhum";

        switch (AccountManage.GetPlayerAdmin(player))
        {
            case 1: rank = "Tester"; break;
            case 2: rank = "Game Helper"; break;
            case 3: rank = "Game Admin I"; break;
            case 4: rank = "Game Admin II"; break;
            case 5: rank = "Game Admin III"; break;
            case 6: rank = "Lead Admin"; break;
            case 7: rank = "Diretor"; break;
            case 8: rank = "Coordenador"; break;
            case 9: rank = "Developer"; break;
            case 10: rank = "Management"; break;
        }
        return rank;
    }
    
    [Command("setadminname")]
    public static void CMD_setadminname(Client player, string idOrName, string staff_name)
    {
        if (AccountManage.GetPlayerAdmin(player) < MANAGMENT)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben keine Berechtigung, diesen Befehl zu verwenden.");
            return;
        }
        Client target = Main.findPlayer(player, idOrName);

        if (target != null)
        {
            if(staff_name.Length < 3 && staff_name.Length > 32)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Der Name muss aus 3 bis 32 Zeichen bestehen.");
                return;
            }

            NAPI.Notification.SendNotificationToPlayer(player,"~o~[ADMIN]:~w~ Sie haben den Admin - Namen von festgelegt " + AccountManage.GetCharacterName(target) + " für " + staff_name + ".");
            target.SendChatMessage("~o~[ADMIN]:~w~ Du " + GetPlayerAdminRank(player) + " " + AccountManage.GetCharacterName(target) + " " + AccountManage.GetCharacterName(target) + " Setzen Sie Ihren Admin-Namen auf" + staff_name + ".");
  
            player.SetData("admin_name", staff_name);

            Main.CreateMySqlCommand("UPDATE `users` SET `adminName` = '" + target.GetData("admin_name") + "', `adminLevel` = '" + target.GetData("admin_level") + "'  WHERE `id` = '" + target.GetData("player_sqlid") + "';");
        }
        else Main.DisplayErrorMessage(player, "ERROR:~w~ Dieser Player ist derzeit offline.");

    }

    [Command("sa")]
    public static void CMD_sa(Client player)
    {
        if (AccountManage.GetPlayerAdmin(player) < MANAGMENT)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben keine Berechtigung, diesen Befehl zu verwenden.");
            return;
        }

        if(player.GetData("admin_name") == "null")
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben keinen festgelegten administrativen Namen.Bitten Sie einen hochrangigen Administrator, Ihren Administratornamen festzulegen.");
            return;
        }

        if(player.GetData("admin_duty") == 1)
        {
            foreach(var target in NAPI.Pools.GetAllPlayers())
            {
                if(target.GetData("status") == true && AccountManage.GetPlayerAdmin(target) > 0)
                {
                    Main.SendMessageWithTagToPlayer(target, "" + Main.EMBED_YELLOW + "Admin " + Main.EMBED_WHITE + ":", "" + Main.EMBED_WHITE + "O " + GetPlayerAdminRank(target) + " " + player.GetData("admin_name") + " " + Main.EMBED_LIGHTRED + " saiu" + Main.EMBED_WHITE + " em serviço administrativo.");
                }
            }
           
            player.SetData("admin_duty", 0);
            player.SetSharedData("admin_shared_name", 0);
        }
        else
        {
            foreach (var target in NAPI.Pools.GetAllPlayers())
            {
                if (target.GetData("status") == true && AccountManage.GetPlayerAdmin(target) > 0)
                {
                    Main.SendMessageWithTagToPlayer(target, "" + Main.EMBED_YELLOW + "Admin " + Main.EMBED_WHITE + ":", "" + Main.EMBED_WHITE + "O " + GetPlayerAdminRank(target) + " " + player.GetData("admin_name") + " " + Main.EMBED_YELLOW + " entrou" + Main.EMBED_WHITE + " em serviço administrativo.");
                }
            }

            player.SetData("admin_duty", 1);
            player.SetSharedData("admin_shared_name", player.GetData("admin_name"));

            if (player.GetData("admin_name") == "DerStr1k3r")
            {
                player.SetSharedData("admin_shared_color", 2);
            }
            else if (AccountManage.GetPlayerAdmin(player) > 0 && AccountManage.GetPlayerAdmin(player) < 10)
            {
                player.SetSharedData("admin_shared_color", 0);
            }
            else if (AccountManage.GetPlayerAdmin(player) >= 10)
            {
                player.SetSharedData("admin_shared_color", 1);
            }
        }

    }

    [Command("daradmin")]
    public static void SetPlayerAdminLevel(Client player, string idOrName, int level)
    {
        if (AccountManage.GetPlayerAdmin(player) < MANAGMENT)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben keine Berechtigung, diesen Befehl zu verwenden.");
            return;
        }
        Client target = Main.findPlayer(player, idOrName);

        if (target != null)
        {

            NAPI.Notification.SendNotificationToPlayer(player,"~o~[ADMIN]:~w~ Du setztest" + AccountManage.GetCharacterName(target)+ " als Admin - Ebene"+level+" "+GetPlayerAdminRank(target)+".");
            target.SendChatMessage("~o~[ADMIN]:~w~ Der "+GetPlayerAdminRank(player)+" "+player.GetData("admin_name")+ " hat Sie als Admin - Ebene eingestellt "+level+" "+GetPlayerAdminRank(target)+".");
            AccountManage.SetPlayerAdmin(target, level);
            Main.CreateMySqlCommand("UPDATE `users` SET `adminName` = '" + target.GetData("admin_name") + "', `adminLevel` = '" + target.GetData("admin_level") + "'  WHERE `id` = '" + target.GetData("player_sqlid") + "';");
        }
        else Main.DisplayErrorMessage(player, "ERROR:~w~ Dieser Player ist derzeit offline.");
        //NAPI.Util.ConsoleOutput("[" + DateTime.Now + "] [" + player.Name + "]benutze command /daradmin.");
    }

    [Command("kick", "/kick [id/PartOfName] [motivo]")]
    public void CMD_kick(Client player, string idOrName, string reason = null)
    {
        if (AccountManage.GetPlayerAdmin(player) < 1)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben keine Berechtigung, diesen Befehl zu verwenden .");
            return;
        }
        Client target = Main.findPlayer(player, idOrName);

        if (target != null)
        {

            if(reason == null) NAPI.Chat.SendChatMessageToAll("~y~-OperServ-Der Bürger" + target.Name + " wurde vom Administrator gekickt " + player.GetData("admin_name") + ".");
            else NAPI.Chat.SendChatMessageToAll("~y~-OperServ- der Bürger "+ target.Name + " wurde vom Administrator getreten " + player.GetData("admin_name") + ". Motive: "+reason+"");

            target.TriggerEvent("quitcmd");
        }
        else NAPI.Notification.SendNotificationToPlayer(player, "ERROR:~w~ Dieser Player ist derzeit offline.");
        //NAPI.Util.ConsoleOutput("[" + DateTime.Now + "] [" + player.Name + "] benutze command /kick.");
    }

    [Command("espiar", "/espiar [id/PartOfName] ~c~(Use ~w~/espiar off~c~ para parar de espiar)")]
    public void CMD_espiar(Client player, string idOrName)
    {
        if (AccountManage.GetPlayerAdmin(player) < 1)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben keine Berechtigung, diesen Befehl zu verwenden .");
            return;
        }

        if(idOrName == "off")
        {
            player.TriggerEvent("adminStopSpy");
            NAPI.Notification.SendNotificationToPlayer(player,"~o~[ADMIN]:~w~ Du bist im Betrachtermodus~w~.");
            return;
        }

        Client target = Main.findPlayer(player, idOrName);

        if (target != null)
        {

            NAPI.Notification.SendNotificationToPlayer(player,"~o~[ADMIN]:~w~ Sie spionieren den Spieler aus: ~b~"+AccountManage.GetCharacterName(target)+"~w~.");
            player.TriggerEvent("adminSpyPlayer", Main.getIdFromClient(target));
        }
        else NAPI.Notification.SendNotificationToPlayer(player, "ERROR:~w~ Dieser Player ist derzeit offline");
        //NAPI.Util.ConsoleOutput("[" + DateTime.Now + "] [" + player.Name + "] benutze command /espiar.");
    }

    [Command("fly")]
    public static void startFreemode(Client player)
    {
        if (AccountManage.GetPlayerAdmin(player) < 10)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben keine Berechtigung, diesen Befehl zu verwenden .");
            return;
        }

        player.TriggerEvent("flyModeStart");
        
    }

    [Command("startcam")]
    public void CMD_startcam(Client player, string active = "on")
    {
        if (AccountManage.GetPlayerAdmin(player) < 3)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben keine Berechtigung, diesen Befehl zu verwenden .");
            return;
        }

        if (active == "on")
        {
            player.TriggerEvent("startFreemode", player.Position.X, player.Position.Y, player.Position.Z);
        }
        else if(active == "off")
        {
            player.TriggerEvent("stopFreemode");
        }

    }
    //
    
    [Command("fixveh")]
    public static void fixVeh(Client player)
    {
        if (AccountManage.GetPlayerAdmin(player) < 3)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben keine Berechtigung, diesen Befehl zu verwenden.");
            return;
        }

        if (player.IsInVehicle)
        {
            player.Vehicle.Repair();
            Main.SendInfoMessage(player, "Sie haben dieses Fahrzeug repariert.");
        }

    }

    [RemoteEvent("saveFreemodePosition")]
    public static void saveFreemodePosition(Client player, string x, string y, string z, string rx, string ry, string rz)
    {
        //NAPI.Util.ConsoleOutput("saveFreemodePosition: "+x+", "+y+", "+z+" - "+rx+", "+ry+", "+rz+".");
        NAPI.Notification.SendNotificationToPlayer(player,"saveFreemodePosition:~y~ Position: ~c~"+x+", "+y+", "+z+" ~y~Rotation:~c~ "+rx+", "+ry+", "+rz+".");
    }

    [Command("setstat", "/setstat [id/PartOfName] [Tipo: 1 = chave da empresa, 2 = gasolina] [valor]")]
    public void CMD_setdimensao(Client player, string idOrName, int type, int value)
    {
        if (AccountManage.GetPlayerAdmin(player) < COORDENADOR)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben keine Berechtigung, diesen Befehl zu verwenden.");
            return;
        }
        Client target = Main.findPlayer(player, idOrName);

        if (target != null)
        {
            if (target.GetData("status") != true)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Dieser Spieler ist offline.");
                return;
            }

            switch (type)
            {
                case 1:
                    target.SetData("character_business_key", value);
                    NAPI.Notification.SendNotificationToPlayer(player,"Du hast das eingestellt ~c~Geschäftsschlüssel~w~ von ~y~" + AccountManage.GetCharacterName(target) + "~w~ zu" + value + ".");
                    return;
                case 2:
                    if (target.IsInVehicle)
                    {
                        Main.SetVehicleFuel(target.Vehicle, value);
                        NAPI.Notification.SendNotificationToPlayer(player,"Du hast das eingestellt ~c~Geschäftsschlüssel~w~ von ~y~" + AccountManage.GetCharacterName(target) + "~w~ zu " + value + ".");
                    }
                    else Main.DisplayErrorMessage(player, "Der angegebene Spieler befindet sich nicht in einem Fahrzeug.");
                    return;
            }

            NAPI.Notification.SendNotificationToPlayer(player,"/setstat [id/PartOfName] [Tipo: 1 = chave da empresa] [valor]");
           
        }
        else NAPI.Notification.SendNotificationToPlayer(player, "ERROR:~w~ Dieser Player ist derzeit offline.");
        //NAPI.Util.ConsoleOutput("[" + DateTime.Now + "] [" + player.Name + "] benutze command /setstats.");
    }

    [Command("admin", Alias = "a", GreedyArg = true)]
    public void CMD_admin(Client player, string mensagem)
    {
        if (player.GetData("status") == false)
        {
            return;
        }
        if (AccountManage.GetPlayerAdmin(player) < 1)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben keine Berechtigung, diesen Befehl zu verwenden .");
            return;
        }

        var players = NAPI.Pools.GetAllPlayers();

        foreach (Client c in players)
        {
            if (c.GetData("status") == true)
            {
                if (AccountManage.GetPlayerAdmin(c) > 0)
                {
                    //NAPI.Notification.SendNotificationToPlayer(c, "<font color='FFBD9D'>(Admin Chat) " + AccountManage.GetCharacterName(player) + " (id: "+ Main.getIdFromClient(player) + "): " + mensagem + "");
                    c.SendChatMessage("~y~(Admin Chat) " + GetPlayerAdminRank(player) + " " + player.GetData("admin_name") + " diz: " + mensagem + "");
                    //Main.SendMessageWithTagToPlayer(c, "" + Main.EMBED_YELLOW + "(Admin Chat)", "" + Main.EMBED_YELLOW + " " + GetPlayerAdminRank(player) + " " + AccountManage.GetCharacterName(player) + " diz: " + mensagem + "");
                }
            }
        }
        //NAPI.Util.ConsoleOutput("[" + DateTime.Now + "] [" + player.Name + "] benutze Command /a. (Dizendo: "+mensagem+")");
    }

    [Command("cv", GreedyArg = true)]
    public void CMD_cv(Client player, string mensagem)
    {
        if (AccountManage.GetPlayerAdmin(player) < 1)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben keine Berechtigung, diesen Befehl zu verwenden .");
            return;
        }

        Main.SendMessageWithTagToAll("" + Main.EMBED_SERVER + "["+GetPlayerAdminRank(player)+"]", ""+Main.EMBED_SERVER + " " + player.GetData("admin_name") + ": "+Main.EMBED_RED+"" + mensagem);
        //NAPI.Util.ConsoleOutput("[" + DateTime.Now + "] [" + player.Name + "] benutze command /cv. (Dizendo: " + mensagem+")");
    }

    
    /*'voice.phoneCall', (target_1, target_2, volume)*/
    [Command("revive")]
    public void CMD_reviver(Client sender, string idOrName)
    {
        if (AccountManage.GetPlayerAdmin(sender) < 1)
        {
            Main.SendErrorMessage(sender, "Sie haben keine Berechtigung, diesen Befehl zu verwenden .");
            return;
        }
        Client target = Main.findPlayer(sender, idOrName);
        if (target != null)
        {
            if (target.GetData("status") != true)
            {
                Main.SendErrorMessage(sender, "Dieser Player ist derzeit offline.");
                return;
            }
            if (target.GetSharedData("Injured") != 1)
            {
                Main.SendErrorMessage(sender, "Dieser Spieler ist nicht verletzt.");
                return;
            }

            target.SetSharedData("Injured", 0);
            NAPI.Player.SetPlayerHealth(target, 40);
            target.TriggerEvent("update_health", target.Health);
            target.TriggerEvent("freeze", false);
            target.TriggerEvent("freezeEx", false);
            NAPI.Player.StopPlayerAnimation(target);
            if (sender != target) NAPI.Notification.SendNotificationToPlayer(sender, "Du hast den Bürger ~g~wiederbelebto~w~  ~y~" + AccountManage.GetCharacterName(target) + "~w~.");
            NAPI.Notification.SendNotificationToPlayer(target, "Sie wurden vom Administrator wiederbelebt ~y~" + sender.GetData("admin_name") + "~w~.");
            target.TriggerEvent("update_health", target.Health);
        }
        else Main.SendErrorMessage(sender, "Dieser Bürger ist nicht verletzt.");
        //NAPI.Util.ConsoleOutput("[" + DateTime.Now + "] [" + sender.Name + "] benutze command /reviver.");
    }

    public static void CMD_reviveme(Client sender)
    {
        if (AccountManage.GetPlayerAdmin(sender) < 1)
        {
            Main.SendErrorMessage(sender, "Sie haben keine Berechtigung, diesen Befehl zu verwenden .");
            return;
        }

        if (sender != null)
        {
            if (sender.GetData("status") != true)
            {
                Main.SendErrorMessage(sender, "Dieser Player ist derzeit offline.");
                return;
            }
            if (sender.GetSharedData("Injured") != 1)
            {
                Main.SendErrorMessage(sender, "Dieser Spieler ist nicht verletzt.");
                return;
            }

            sender.SetSharedData("Injured", 0);
            NAPI.Player.SetPlayerHealth(sender, 40);
            sender.TriggerEvent("update_health", sender.Health);
            sender.TriggerEvent("freeze", false);
            sender.TriggerEvent("freezeEx", false);
            NAPI.Player.StopPlayerAnimation(sender);
            NAPI.Notification.SendNotificationToPlayer(sender, "Du hast dich wiederbelebt...");
            sender.TriggerEvent("update_health", sender.Health);
        }
        else Main.SendErrorMessage(sender, "Dieser Bürger ist nicht verletzt.");
        //NAPI.Util.ConsoleOutput("[" + DateTime.Now + "] [" + sender.Name + "] benutze command /reviver.");
    }

    [Command("tirarhospital")]
    public void CMD_tirarhospital(Client sender, string idOrName)
    {
        if (AccountManage.GetPlayerAdmin(sender) < 1)
        {
            Main.SendErrorMessage(sender, "Sie haben keine Berechtigung, diesen Befehl zu verwenden .");
            return;
        }
        Client target = Main.findPlayer(sender, idOrName);
        if (target != null)
        {
            if (target.GetData("status") != true)
            {
                Main.SendErrorMessage(sender, "Dieser Spieler ist nicht online.");
                return;
            }
            if (target.GetSharedData("Injured") != 2)
            {
                Main.SendErrorMessage(sender, "Dieser Spieler befindet sich nicht im Krankenhaus..");
                return;
            }

            target.SetSharedData("InjuredTime", 0);
            if (sender != target) NAPI.Notification.SendNotificationToPlayer(sender, "Sie haben  mit ~g~Erfolg~w~  ~y~" + AccountManage.GetCharacterName(target) + "~w~ den Spieler aus dem Krankenhaus entfernt");
            NAPI.Notification.SendNotificationToPlayer(target, "Sie wurden vom Administrator aus dem Krankenhaus entfernt~y~" + sender.GetData("admin_name") + "~w~.");
        }
        else Main.SendErrorMessage(sender, "Dieser Spieler ist nicht verletzt.");
        //NAPI.Util.ConsoleOutput("[" + DateTime.Now + "] [" + sender.Name + "] benutze command /tirarhospital.");
    }

    [Command("tirarprisao")]
    public void CMD_tirarprisao(Client sender, string idOrName)
    {
        if (AccountManage.GetPlayerAdmin(sender) < COORDENADOR)
        {
            Main.SendErrorMessage(sender, "Sie haben keine Berechtigung, diesen Befehl zu verwenden .");
            return;
        }
        Client target = Main.findPlayer(sender, idOrName);
        if (target != null)
        {
            if (target.GetData("status") != true)
            {
                Main.SendErrorMessage(sender, "Dieser Spieler ist nicht online.");
                return;
            }
            if (target.GetData("character_prison_time") < 1)
            {
                Main.SendErrorMessage(sender, "Dieser Spieler ist nicht im Gefängnis.");
                return;
            }

            target.SetData("character_prison_time", 1);

            if (sender != target) NAPI.Notification.SendNotificationToPlayer(sender, "Sie haben  ~g~Erfolgreich~w~den Spieler  ~y~" + AccountManage.GetCharacterName(target) + "~w~ aus dem Gefägnis entfernt.");
            NAPI.Notification.SendNotificationToPlayer(target, "Sie wurden vom Administrator aus dem Gefängnis entfernt ~y~" + sender.GetData("admin_name") + "~w~.");
        }
        else Main.SendErrorMessage(sender, "Dieser Spieler ist nicht verletzt.");
        //NAPI.Util.ConsoleOutput("[" + DateTime.Now + "] [" + sender.Name + "] benutze command /tirarprisao.");
    }
    [Command("setdimensao", "/setdimensao [id/PartOfName] [dimensao(padrão=0)]")]
    public void CMD_setdimensao(Client player, string idOrName, uint dimension)
    {
        if (AccountManage.GetPlayerAdmin(player) < 1)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben keine Berechtigung, diesen Befehl zu verwenden .");
            return;
        }
        Client target = Main.findPlayer(player, idOrName);

        if (target != null)
        {
            if (target.GetData("status") != true)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Dieser Spieler ist offline.");
                return;
            }

            NAPI.Notification.SendNotificationToPlayer(player, "Sie legen die Größe des Players fest ~y~" + AccountManage.GetCharacterName(target) + "~w~ para "+dimension+".");
            target.Dimension = dimension;
        }
        else NAPI.Notification.SendNotificationToPlayer(player, "ERROR:~w~ Dieser Player ist derzeit offline.");
        //NAPI.Util.ConsoleOutput("[" + DateTime.Now + "] [" + player.Name + "] benutze command /setdimensao.");
    }

    [Command("debug")]
    public void CMD_debug(Client player, string idOrName, int dimension)
    {
        NAPI.Notification.SendNotificationToPlayer(player,"[DEBUG]: Player Dimension: "+player.Dimension+".");
    }

    [Command("ir", "/ir [id/PartOfName]")]
    public void CMD_ir(Client player, string idOrName)
    {
        if (AccountManage.GetPlayerAdmin(player) < 1)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben keine Berechtigung, diesen Befehl zu verwenden .");
            return;
        }
        Client target = Main.findPlayer(player, idOrName);

        if (target != null)
        {
            if (target.GetData("status") != true)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Dieser Spieler ist offline.");
                return;
            }

            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben sich zum Bürger teleportiert ~y~" + AccountManage.GetCharacterName(target) + "~w~.");
            NAPI.Notification.SendNotificationToPlayer(target, "Der Administrator ~y~" + player.GetData("admin_name") + "~w~ hat sich zu Ihnen teleportiert.");

            if (player.IsInVehicle && player.VehicleSeat == -1)
            {
                Vehicle vehicle = player.Vehicle;
                vehicle.Position = target.Position;
                vehicle.Dimension = target.Dimension;
                player.SetIntoVehicle(vehicle, 0);
                player.TriggerEvent("createNewHeadNotificationAdvanced", "~c~(In-vehicle)~w~ Sie wurden  teleportiert ~g~Erfolgreich~w~.");
            }
            else
            {
                player.Position = target.Position;
                player.Dimension = target.Dimension;
                player.TriggerEvent("createNewHeadNotificationAdvanced", "~c~(On-foot)~w~ Sie wurden teleportiert~g~Erfolgreich~w~.");
            }

            //Utils.SetPlayerPosition(player, target.Position, target.rotation.Z, true);
        }
        else NAPI.Notification.SendNotificationToPlayer(player, "ERROR:~w~ Dieser Player ist derzeit offline.");
        //NAPI.Util.ConsoleOutput("[" + DateTime.Now + "] [" + player.Name + "] benutze command /ir (" + idOrName+").");
    }
    /*
    [Command("fixvoip")]
    public void CMD_fixvoip(Client player)
    {
        player.TriggerEvent("reloadBrowser");
        NAPI.Notification.SendNotificationToPlayer(player, "Se você não consegue se mover, minimize o jogo e retorne. Use ~y~ALT + TAB~w~ para fazer isto.");
        //NAPI.Util.ConsoleOutput("[" + player.Name + "] usou o comando /fixvoip.");
    }
    */

    [Command("trazer", "/trazer [id/PartOfName]")]
    public void CMD_trazer(Client player, string idOrName)
    {
        if (AccountManage.GetPlayerAdmin(player) < 1)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben keine Berechtigung, diesen Befehl zu verwenden.");
            return;
        }
        Client target = Main.findPlayer(player, idOrName);

        if (target != null)
        {
            if (target.GetData("status") != true)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Dieser Spieler ist offline.");
                return;
            }

            //if (target.GetData("fishing") == true)
            //{
            //    if (Fish.fishTimer != null)
            //    {
            //        //API.shared.stopTimer(Fish.fishTimer);
            //        Fish.fishTimer = null;
            //    }
            //    target.StopAnimation();
            //    target.SetData("fishing", false);
            //    target.SetData("fishingCaptured", -1);
            //}

            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben sich zum Bürger teleportiert ~y~" + AccountManage.GetCharacterName(target) + "~w~.");
            NAPI.Notification.SendNotificationToPlayer(target, "Der Admin ~y~" + player.GetData("admin_name") + "~w~ hat sich zu Ihnen teleportiert.");

            if (target.IsInVehicle && target.VehicleSeat == -1)
            {
                Vehicle vehicle = target.Vehicle;
                vehicle.Position = player.Position;
                target.Dimension = player.Dimension;
                vehicle.Dimension = player.Dimension;
                target.SetIntoVehicle(vehicle, 0);
                target.TriggerEvent("createNewHeadNotificationAdvanced", "~c~(In-vehicle)~w~ Sie wurden  teleportiert von einem Administrator~w~.");
            }
            else
            {
                target.Position = player.Position;
                target.Dimension = player.Dimension;
                target.TriggerEvent("createNewHeadNotificationAdvanced", "~c~(On-foot)~w~ Sie wurden  teleportiert von einem Administrator~w~.");
            }
            //Utils.SetPlayerPosition(target, player.Position, player.Rotation.Z, true);
        }
        else NAPI.Notification.SendNotificationToPlayer(player, "ERROR:~w~Dieser Player ist derzeit offline.");
        //NAPI.Util.ConsoleOutput("[" + DateTime.Now + "] [" + player.Name + "] benutze command /trazer " + idOrName+".");
    }
    [Command("darexperiencia", "/darexperiencia [id/PartOfName] [quantidade]")]
    public void CMD_darexperiencia(Client player, string idOrName, int quantidade)
    {
        if (AccountManage.GetPlayerAdmin(player) < COORDENADOR)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben keine Berechtigung, diesen Befehl zu verwenden .");
            return;
        }
        Client target = Main.findPlayer(player, idOrName);

        if (target != null)
        {
            if (target.GetData("status") != true)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Dieser Player ist derzeit offline.");
                return;
            }

            if (player != target) NAPI.Notification.SendNotificationToPlayer(player, "Du hast gegeben "+quantidade+" Erfahrung an den Bürger ~y~" + AccountManage.GetCharacterName(target) + "~w~.");
            NAPI.Notification.SendNotificationToPlayer(target, "Der Administrator~y~"+ player.GetData("admin_name") + "~w~ hat dir ~g~"+quantidade+"~w~ Erfahrung gegeben.");
            Main.GivePlayerEXP(target, quantidade);
        }
        //NAPI.Util.ConsoleOutput("[" + player.Name + "] benutze command /darexperiencia.");
    }
    [Command("salvarcontas")]
    public void CMD_saveaccounts(Client player)
    {
        if (AccountManage.GetPlayerAdmin(player) < COORDENADOR)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben keine Berechtigung, diesen Befehl zu verwenden .");
            return;
        }
        var players = NAPI.Pools.GetAllPlayers();
        foreach (var i in players)
        {
            AccountManage.SaveCharacter(i);
            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben die Konten aller Spieler online gespeichert.");
        }
        //NAPI.Util.ConsoleOutput("["+player.Name+ "] benutze command /salvarcontas.");
    }

    [Command("teleportar")]
    public static void CMD_teleportar(Client player)
    {
        if (AccountManage.GetPlayerAdmin(player) < 1)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben keine Berechtigung, diesen Befehl zu verwenden .");
            return;
        }
        player.TriggerEvent("get_waypoint_pos");
        NAPI.Notification.SendNotificationToPlayer(player, "<C>Admin Service</C> ~n~Sie werden in Kürze teleportiert....");
    }

    [Command("setfactionleader", "/setfactionleader [id/PartOfName]")]
    public void CMD_darlider(Client player, string idOrName, int factionid)
    {
        if (AccountManage.GetPlayerAdmin(player) < COORDENADOR)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben keine Berechtigung, diesen Befehl zu verwenden .");
            return;
        }
        Client target = Main.findPlayer(player, idOrName);
        if (target != null)
        {
            if (target.GetData("status") != true)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Dieser Spieler ist offline.");
                return;
            }

            if (factionid < 0 || factionid > 255)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Die Fraktions-ID muss zwischen 0 und 255 liegen.");
            }
            else if (FactionManage.faction_data[factionid].faction_type == 0)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Diese Fraktion ist noch nicht konfiguriert.");
            }
            else
            {
                target.SetData("duty", 0);
                Outfits.RemovePlayerDutyOutfit(target);
                AccountManage.SetPlayerLeader(target, factionid);
                AccountManage.SetPlayerGroup(target, factionid);
                AccountManage.SetPlayerRank(target, FactionManage.GetMaxRank(factionid));

                FactionManage.faction_data[factionid].faction_leader = AccountManage.GetPlayerSQLID(target);

                if(player != target) NAPI.Notification.SendNotificationToPlayer(player, "Du hast " + AccountManage.GetCharacterName(target) + " hinzugefügt als Führer der Fraktion~b~" + FactionManage.faction_data[factionid].faction_name +".");
                else NAPI.Notification.SendNotificationToPlayer(target, "Der Administrator" + player.GetData("admin_name") + " machte dich zum Fraktionsführer ~b~" + FactionManage.faction_data[factionid].faction_name + ".");

                AccountManage.SaveCharacter(player);
                FactionManage.SaveFaction(factionid);
                Main.SetPlayerToTeamColor(target);
            }
        }
        //NAPI.Util.ConsoleOutput("[" + DateTime.Now + "] [" + player.Name + "] benutze command /darlider.");
    }
    [Command("setfaction", "/setfaction [id/PartOfName]")]
    public void CMD_setfaccao(Client player, string idOrName, int factionid)
    {
        if (AccountManage.GetPlayerAdmin(player) < COORDENADOR)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben keine Berechtigung, diesen Befehl zu verwenden .");
            return;
        }
        Client target = Main.findPlayer(player, idOrName);
        if (target != null)
        {
            if (target.GetData("status") != true)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Dieser Spieler ist offline.");
                return;
            }
            if (factionid < 0 || factionid > 255)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Die Fraktions-ID muss zwischen 0 und 255 liegen.");
            }
            else if(FactionManage.faction_data[factionid].faction_type == 0)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Diese Fraktion ist noch nicht konfiguriert.");
            }
            else
            {
                target.SetData("duty", 0);
                Outfits.RemovePlayerDutyOutfit(target);
                AccountManage.SetPlayerGroup(target, factionid);
                AccountManage.SetPlayerRank(target, FactionManage.GetMaxRank(factionid));
                AccountManage.SaveCharacter(target);
                if (player != target) NAPI.Notification.SendNotificationToPlayer(player, "Du hast" + AccountManage.GetCharacterName(target) + " hinzugefütg zum Mitglied der Fraktion~b~" + FactionManage.faction_data[factionid].faction_name + ".");
                else NAPI.Notification.SendNotificationToPlayer(target, "Der Administrator" + player.GetData("admin_name") + " hat dich zu einem Fraktionsmitglied gemacht ~b~" + FactionManage.faction_data[factionid].faction_name + ".");
                //Main.SetPlayerToTeamColor(target);
            }
        }
        //NAPI.Util.ConsoleOutput("[" + DateTime.Now + "] [" + player.Name + "] benutze command /setfaccao.");
    }


    [Command("tirarfaccao", "/tirargrupo [id/PartOfName]")]
    public void CMD_tirargrupo(Client player, string idOrName)
    {
        if (AccountManage.GetPlayerAdmin(player) < COORDENADOR)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben keine Berechtigung, diesen Befehl zu verwenden.");
            return;
        }
        Client target = Main.findPlayer(player, idOrName);
        if (target != null)
        {
            if (target.GetData("status") != true)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Dieser Spieler ist offline.");
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
            if (player != target) NAPI.Notification.SendNotificationToPlayer(player, "Sie haben die Fraktion von entfernt " + AccountManage.GetCharacterName(target) + " und ist nun~Zivilist~w~.");
            else NAPI.Notification.SendNotificationToPlayer(target, "Der Administrator " + player.GetData("admin_name") + " Sie von der Fraktion entfernt und Sie sind nun ein ~b~Zivilist~w~.");
            Main.SetPlayerToTeamColor(target);

        }
        //NAPI.Util.ConsoleOutput("[" + DateTime.Now + "] [" + player.Name + "] benutze command/tirarfaccao.");
    }

    [Command("adgivemoney", "/adgivemoney [id/Name] [betrag]")]
    public void command_giveplayermoney(Client player, string idOrName, int value)
    {
        if (AccountManage.GetPlayerAdmin(player) < COORDENADOR)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben keine Berechtigung, diesen Befehl zu verwenden.");
            return;
        }
        Client target = Main.findPlayer(player, idOrName);

        if (target != null)
        {
            if (target.GetData("status") != true)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Dieser Spieler ist offline.");
                return;
            }

            if (player != target) NAPI.Notification.SendNotificationToPlayer(player, "Du hast gegeben ~g~$~y~" + value.ToString("N0") + "~w~ an ~y~" + AccountManage.GetCharacterName(target) + "~w~.");
            else NAPI.Notification.SendNotificationToPlayer(target, "Der Administrator " + player.GetData("admin_name") + " gab Ihnen ~g~$~y~" + value.ToString("N0") + "~w~.");


            Main.GivePlayerMoney(target, value);
            AccountManage.SaveCharacter(target);
            //player.TriggerEvent("SetCashBar", value);
        }
        //NAPI.Util.ConsoleOutput("[" + DateTime.Now + "] [" + player.Name + "] benutze command /dardinheiro.");
    }

    public static void CMD_adveh(Client sender)
    {
        if (AccountManage.GetPlayerAdmin(sender) < COORDENADOR)
        {
            Main.SendErrorMessage(sender, "Sie haben keine Berechtigung, diesen Befehl zu verwenden.");
            return;
        }
        
        for (int i = 0; i < 20; i++)
        {
            if (Main.admin_vehicle_spawned[i] == false)
            {
                Main.admin_vehicle_spawned[i] = true;
                var rot = NAPI.Entity.GetEntityRotation(sender);
                Main.admin_vehicle[i] = NAPI.Vehicle.CreateVehicle(1663218586, sender.Position, new Vector3(0, 0, rot.Z), 0, 0);
                NAPI.Player.SetPlayerIntoVehicle(sender, Main.admin_vehicle[i], -1);
                NAPI.Vehicle.SetVehicleEngineStatus(Main.admin_vehicle[i], true);
                NAPI.Vehicle.SetVehiclePrimaryColor(Main.admin_vehicle[i], 0);
                NAPI.Vehicle.SetVehicleSecondaryColor(Main.admin_vehicle[i], 0);
                NAPI.Vehicle.SetVehicleNumberPlate(Main.admin_vehicle[i], "SUPPORT");
                Main.SetVehicleFuel(Main.admin_vehicle[i], 100.0);
                NAPI.Vehicle.SetVehicleMod(Main.admin_vehicle[i], 18, 1);
                NAPI.Vehicle.SetVehicleMod(Main.admin_vehicle[i], 11, 1);
                NAPI.Vehicle.SetVehicleMod(Main.admin_vehicle[i], 13, 1);
                return;
            }
        }
    }


    [Command("veh", Alias = "car")]
    public void CMD_veh(Client sender, string modelname, int color = 0, int color2 = 0)
    {
        if (AccountManage.GetPlayerAdmin(sender) < COORDENADOR)
        {
            Main.SendErrorMessage(sender, "Sie haben keine Berechtigung, diesen Befehl zu verwenden.");
            return;
        }

        VehicleHash model = NAPI.Util.VehicleNameToModel(modelname);

        var hash = NAPI.Util.GetHashKey(modelname).GetHashCode();

        for (int i = 0; i < 20; i++)
        {
            if (Main.admin_vehicle_spawned[i] == false)
            {
                Main.admin_vehicle_spawned[i] = true;
                var rot = NAPI.Entity.GetEntityRotation(sender.Handle);
                Main.admin_vehicle[i] = NAPI.Vehicle.CreateVehicle(hash, sender.Position, new Vector3(0, 0, rot.Z), color, color2);
                NAPI.Vehicle.SetVehicleEngineStatus(Main.admin_vehicle[i], false);
                NAPI.Player.SetPlayerIntoVehicle(sender, Main.admin_vehicle[i], -1);
                

                Random rnd = new Random();
                int random_colors = rnd.Next(0, 250);

                NAPI.Vehicle.SetVehiclePrimaryColor(Main.admin_vehicle[i], random_colors);
                NAPI.Vehicle.SetVehicleSecondaryColor(Main.admin_vehicle[i], random_colors);
                Main.SetVehicleFuel(Main.admin_vehicle[i], 100.0);
                NAPI.Vehicle.SetVehicleNumberPlate(Main.admin_vehicle[i], "SUPPORT");
                NAPI.Vehicle.SetVehicleEnginePowerMultiplier(Main.admin_vehicle[i], 20);
                NAPI.Vehicle.SetVehicleMod(Main.admin_vehicle[i], 18, 1);
                NAPI.Vehicle.SetVehicleMod(Main.admin_vehicle[i], 11, 3);
                NAPI.Vehicle.SetVehicleMod(Main.admin_vehicle[i], 13, 3);
                VehicleInventory.AddInventoryToVehicle(Main.admin_vehicle[i], model);
                
                return;
            }
        }
    }

    [Command("delveh", Alias = "deletarveiculo")]
    public static void CMD_delveh(Client sender)
    {
        if (AccountManage.GetPlayerAdmin(sender) < COORDENADOR)
        {
            Main.SendErrorMessage(sender, "Sie haben keine Berechtigung, diesen Befehl zu .");
            return;
        }
        if (!sender.IsInVehicle)
        {
            NAPI.Notification.SendNotificationToPlayer(sender, "Sie befinden sich nicht in einem Adminfahrzeug.");
            return;
        }
        for (int i = 0; i < 20; i++)
        {
            if (NAPI.Player.GetPlayerVehicle(sender) == Main.admin_vehicle[i])
            {
                Main.admin_vehicle_spawned[i] = false;
                NAPI.Entity.DeleteEntity(Main.admin_vehicle[i]);
                NAPI.Notification.SendNotificationToPlayer(sender, "Sie haben das Adminfahrzeug zerstört.");
                return;
            }
        }
        NAPI.Notification.SendNotificationToPlayer(sender, "Sie befinden sich nicht in einem Adminfahrzeug.");
    }

    [Command("destruirveiculos")]
    public void CMD_destruirveiculoss(Client sender)
    {
        if (AccountManage.GetPlayerAdmin(sender) < COORDENADOR)
        {
            Main.SendErrorMessage(sender, "Sie haben keine Berechtigung, diesen Befehl zu verwenden.");
            return;
        }
        int contador = 0;
        for (int i = 0; i < 20; i++)
        {
            if (Main.admin_vehicle_spawned[i] == true)
            {
                int count = 0;
                foreach (var ocupantes in NAPI.Pools.GetAllPlayers())
                {
                    if (ocupantes.Vehicle == Main.admin_vehicle[i])
                    {
                        count++;
                    }
                }

                if (count == 0)
                {
                    Main.admin_vehicle_spawned[i] = false;
                    NAPI.Entity.DeleteEntity(Main.admin_vehicle[i]);
                    contador++;
                }
            }
        }

        foreach (Vehicle vehicles in NAPI.Pools.GetAllVehicles())
        {
            int count = 0;
            
            foreach (var ocupantes in NAPI.Pools.GetAllPlayers())
            {
                if (ocupantes.Vehicle == vehicles)
                {
                    count++;
                }
            }

            
            if (count > 0) continue;

            for (int faction_id = 0; faction_id < 20; faction_id++)
            {
                for (int i = 0; i < 20; i++)
                {
                    if (vehicles == FactionManage.faction_data[faction_id].faction_vehicle_entity[i])
                    {
                        FactionManage.faction_data[faction_id].faction_vehicle_name[i] = "Frei";
                        FactionManage.faction_data[faction_id].faction_vehicle_owned[i] = "Niemand";
                        NAPI.Entity.DeleteEntity(FactionManage.faction_data[faction_id].faction_vehicle_entity[i]);
                        contador++;
                    }
                }
            }

            for (int b = 0; b < RentVehicle.MAX_RENT_VEHICLES; b++)
            {
                if (RentVehicle.vehicle_rent_list[b].vehicle_free == true)
                {
                    if (vehicles == RentVehicle.vehicle_rent_list[b].vehicle_entity)
                    {
                        RentVehicle.vehicle_rent_list[b].vehicle_free = false;
                        RentVehicle.vehicle_rent_list[b].vehicle_ownedBy = -1;
                        NAPI.Data.SetEntityData(RentVehicle.vehicle_rent_list[b].vehicle_entity, "vehicle_entity", -1);
                        NAPI.Entity.DeleteEntity(RentVehicle.vehicle_rent_list[b].vehicle_entity);
                        contador++;
                    }
                }
            }
        }
        

       NAPI.Notification.SendNotificationToPlayer(sender, "Wurden zerstört " + contador+ " unbrauchbare Serverfahrzeuge.");
        //NAPI.Util.ConsoleOutput("[" + DateTime.Now + "] [" + sender.Name + "] benutze command /destruirveiculos.");
    }

    [Command("irpara")]
    public void irpara(Client player, string local = null)
    {
        if (AccountManage.GetPlayerAdmin(player) < 1)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben keine Berechtigung, diesen Befehl zu verwenden .");
            return;
        }
        if (local == "mors")
        {
            Utils.SetPlayerPosition(player, new Vector3(-188.4343, -1153.124, 23.04602), 0.5582753f, true);
            player.Dimension = 0;
        }
        else if (local == "spawn")
        {
            Utils.SetPlayerPosition(player, new Vector3(-536.447, -219.6322, 37.64978), 211.0624f, true);
            player.Dimension = 0;
        }
        else
        {
            NAPI.Notification.SendNotificationToPlayer(player, "/irpara [~c~local(~w~mors/spawn~c~)]");
        }
        //NAPI.Util.ConsoleOutput("[" + DateTime.Now + "] [" + player.Name + "] benutze command /irpara.");

    }

    //

    [Command("mudarclima", Description = "Muda o clima do mundo")]
    public void command_mudarclima(Client player, int weather)
    {
        if (AccountManage.GetPlayerAdmin(player) < COORDENADOR)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben keine Berechtigung, diesen Befehl zu verwenden.");
            return;
        }
        if (weather < 0 || weather > 14)
            NAPI.Notification.SendNotificationToPlayer(player, "ID Ungültiges Wetter.");
        else
        {

            NAPI.World.SetWeather(Main.weather_list[weather].name);
            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben das Wetter des Spiels geändert ~b~" + weather + "~w~.");
        }
        //NAPI.Util.ConsoleOutput("[" + DateTime.Now + "] [" + player.Name + "] benutze command /mudarclima.");
    }

    [Command("perto")]
    public void CMD_perto(Client player)
    {
        if (AccountManage.GetPlayerAdmin(player) < 1)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben keine Berechtigung, diesen Befehl zu verwenden .");
            return;
        }
        int i = 0;
        foreach(var business in Business.business_list)
        {
            if(Main.IsInRangeOfPoint(player.Position, new Vector3(float.Parse(business.business_posX), float.Parse(business.business_posY), float.Parse(business.business_posZ)), 60.0f))
            {
                Vector3 position = new Vector3(float.Parse(business.business_posX), float.Parse(business.business_posY), float.Parse(business.business_posZ));
                NAPI.Notification.SendNotificationToPlayer(player, "Es gibt eine ID " + i+" ("+ business.business_Name+ ") sie ist " + position.DistanceTo(player.Position)+ " Meter von Ihnen entfernt.");
            }
            i++;
        }
        //NAPI.Util.ConsoleOutput("[" + DateTime.Now + "] [" + player.Name + "] benutze command /perto.");
    }

    [Command("irempresa")]
    public void command_buybusinesss(Client player, int index)
    {
        if (AccountManage.GetPlayerAdmin(player) < 1)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben keine Berechtigung, diesen Befehl zu verwenden.");
            return;
        }

        NAPI.Entity.SetEntityPosition(player, new Vector3(float.Parse(Business.business_list[index].business_posX), float.Parse(Business.business_list[index].business_posY), float.Parse(Business.business_list[index].business_posZ)));
        //NAPI.Util.ConsoleOutput("[" + DateTime.Now + "] [" + player.Name + "] benutze command /irempresa.");
    }

    [Command("avenderempresa", "/avenderempresa [id da empresa]")]
    public void CMD_avenderempresa(Client player, int index)
    {
        if (AccountManage.GetPlayerAdmin(player) < COORDENADOR)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben keine Berechtigung, diesen Befehl zu verwenden.");
            return;
        }

        if (Business.business_list[index].business_OwnerID != -1)
        {
            var players = NAPI.Pools.GetAllPlayers();
            foreach (var i in players)
            {
                if (NAPI.Data.GetEntityData(i, "character_business_key") == index)
                {
                    NAPI.Data.SetEntityData(i, "character_business_key", -1);
                }
            }
            Main.CreateMySqlCommand("UPDATE `characters` SET `business_key` = -1 WHERE `business_key` = '"+ index + "';");
        }
        

        Business.business_list[index].business_OwnerID = -1;
        Business.business_list[index].business_OwnerName = "Niemand";
        Business.UpdateBusinessLabel(index);

        Business.business_list[index].business_Safe = 0;
        Business.business_list[index].business_Inventory = 50;
        Business.business_list[index].business_InventoryCapacity = 100;

        Business.SaveBusiness(index);
        AccountManage.SaveCharacter(player);

        //NAPI.Util.ConsoleOutput("[" + DateTime.Now + "] [" + player.Name + "] benutze command /avenderempresa.");
        //NAPI.Entity.SetEntityPosition(player, new Vector3(float.Parse(Business.business_list[index].business_posX), float.Parse(Business.business_list[index].business_posY), float.Parse(Business.business_list[index].business_posZ)));
    }

    [Command("criarobjeto")]
    public void command_criarobjeto(Client player, string object_prop, float zeee = 0)
    {
        if (AccountManage.GetPlayerAdmin(player) < 2)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben keine Berechtigung, diesen Befehl zu verwenden.");
            return;
        }
        NAPI.Object.CreateObject(Convert.ToUInt32(object_prop), new Vector3(player.Position.X, player.Position.Y, player.Position.Z - zeee), new Vector3(0, 0, 0), 0);
        //NAPI.TextLabel.CreateTextLabel("My Text", pos, range, size);

        NAPI.Notification.SendNotificationToPlayer(player, "Você criou um objeto de ~b~" + object_prop + "~w~.");
        //NAPI.Util.ConsoleOutput("[" + DateTime.Now + "] [" + player.Name + "] benutze command /criarobjeto.");
    }

    [Command("animation")]
    public void command_criarinv(Client player, string animDict, string animName)
    {
        if (AccountManage.GetPlayerAdmin(player) < 2)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben keine Berechtigung, diesen Befehl zu verwenden .");
            return;
        }
        NAPI.Player.PlayPlayerAnimation(player, 1, animDict, animName);
    }

    //
    //
    //

    [Command("fome")]
    public void command_fome(Client player, int value)
    {
        if (AccountManage.GetPlayerAdmin(player) < 2)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben keine Berechtigung, diesen Befehl zu verwenden .");
            return;
        }
        player.SetData("Hunger", value);
        NAPI.ClientEvent.TriggerClientEvent(player, "update_hunger_display", (int)player.GetData("Hunger"), (int)player.GetData("Thirsty"));
        //NAPI.Util.ConsoleOutput("[" + DateTime.Now + "] [" + player.Name + "] benutze command /fome.");
    }

    [Command("sede")]
    public void command_sede(Client player, int value)
    {
        if (AccountManage.GetPlayerAdmin(player) < 2)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben keine Berechtigung, diesen Befehl zu verwenden .");
            return;
        }
        player.SetData("Thirsty", value);
        NAPI.ClientEvent.TriggerClientEvent(player, "update_hunger_display", (int)player.GetData("Hunger"), (int)player.GetData("Thirsty"));
        //NAPI.Util.ConsoleOutput("[" + DateTime.Now + "] [" + player.Name + "] benutze command /sede.");
    }

    [Command("darvida", "/darvida [id/PartOfName] [vida]")]
    public void command_vida(Client player, string idOrName, int value)
    {
        if (AccountManage.GetPlayerAdmin(player) < COORDENADOR)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben keine Berechtigung, diesen Befehl zu verwenden.");
            return;
        }
        Client target = Main.findPlayer(player, idOrName);

        if (target != null)
        {
            NAPI.Player.SetPlayerHealth(target, value);
            target.TriggerEvent("update_health", target.Health);
        }
        //NAPI.Util.ConsoleOutput("[" + DateTime.Now + "] [" + player.Name + "] benutze command /darvida.");
    }


    [Command("darcolete", "/darcolete [id/PartOfName] [colete]")]
    public void command_colete(Client player, string idOrName, int value)
    {
        if (AccountManage.GetPlayerAdmin(player) < COORDENADOR)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben keine Berechtigung, diesen Befehl zu verwenden .");
            return;
        }
        Client target = Main.findPlayer(player, idOrName);
        if (target != null)
        {
            NAPI.Player.SetPlayerArmor(target, value);
        }
        //NAPI.Util.ConsoleOutput("[" + DateTime.Now + "] [" + player.Name + "] benutze command /darcolete.");
    }

    [Command("screen")]
    public void command_screen(Client player, string weather, int time = 1000)
    {
        if (AccountManage.GetPlayerAdmin(player) < 2)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben keine Berechtigung, diesen Befehl zu verwenden .");
            return;
        }
        //player.TriggerEvent("ApplyScreenEffect", weather, time);
    }

    [Command("stopscreen")]
    public void command_stropscreen(Client player)
    {
        //NAPI.Util.ConsoleOutput("-------- DEBUG CMD ADMINS: stop screen inicio");
        if (AccountManage.GetPlayerAdmin(player) < 2)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben keine Berechtigung, diesen Befehl zu verwenden .");
            return;
        }
        //player.TriggerEvent("StopAllScreenEffect");
    }

    [Command("irx")]
    public void command_irx(Client player, float x, float y, float z)
    {
        if (AccountManage.GetPlayerAdmin(player) < 1)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben keine Berechtigung, diesen Befehl zu verwenden ");
            return;
        }
        player.Position = new Vector3(x, y, z);
        //NAPI.Util.ConsoleOutput("[" + DateTime.Now + "] [" + player.Name + "] benutze command /irx.");
    }

}