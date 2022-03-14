using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;

class RoleplayPoints : Script
{
    public RoleplayPoints()
    {

    }

    [Command("giverp", "~y~Use:~w~ /giverp [player] [points] [reason]", GreedyArg = true)]
    public static void CMD_GIVERP(Client player, string idOrName, int value, string reason)
    {
        Client target = Main.findPlayer(player, idOrName);

        if (target == null)
        {
            return;
        }

        if (target.GetData("status") == false)
        {
            return;
        }

        player.SetData("character_rppoints", player.GetData("character_rppoints") + value);

        NAPI.Notification.SendNotificationToPlayer(player,"~y~[INFO]:~w~ Du hast gegeben" + value + " Rollenspiel zeigt auf " + AccountManage.GetCharacterName(target) + ". Grund: " + reason + "");
        target.SendChatMessage("~y~[INFO]:~w~ Gab " + value + " Rollenspielpunkte für Sie. Grund: "+reason+"");

        if (player.GetData("character_rppoints") == -3)
        {
            adminCommands.OOC_Prison(target, player, 72 * 60, "Viele Negative");
        }
        else if (player.GetData("character_rppoints") == -5)
        {
            adminCommands.OOC_Prison(target, player, 360 * 60, "Viele Negative");
        }
    }

    [Command("rp", Alias = "roleplay,rpoints")]
    public static void CMD_MYRP(Client player)
    {
        if(player.GetData("character_rppoints") == 0)
        {
            NAPI.Notification.SendNotificationToPlayer(player,"* Ihr Rollenspiel auf unserem Server wurde noch nicht bewertet.");
        }
        else if (player.GetData("character_rppoints") >= 1)
        {
            NAPI.Notification.SendNotificationToPlayer(player,"* Ihr Rollenspiel ist derzeit auf unserem Server ~g~Gut~w~ mit ~o~" + player.GetData("character_rppoints") + "~w~ Punkte des Rollenspiels.");
        }
        else if (player.GetData("character_rppoints") < 0)
        {
            NAPI.Notification.SendNotificationToPlayer(player,"* Ihr Rollenspiel ist derzeit auf unserem Server BAD~w~ mit ~o~" + player.GetData("character_rppoints") + "~w~ Punkte des Rollenspiels. ");
            NAPI.Notification.SendNotificationToPlayer(player,"* Du brauchst~b~zu verbessern~w~ oder wird am Ende von einem Administrator verhaftet oder verboten ! ");
        }
    }
}

