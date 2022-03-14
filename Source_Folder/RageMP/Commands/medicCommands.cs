/*
 /reanimar
 /desfibrilador

 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTANetworkAPI;

class MedicSystem : Script
{
    [Command("curar", "~y~Benutze ~w~/curar [Name] [preis]")]
    public void CMD_curar(Client player, string idOrName, int price)
    {
        if (FactionManage.GetPlayerGroupType(player) != FactionManage.FACTION_TYPE_MEDIC)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "ERROR:~w~ Sie sind nicht im Dienst.");
            return;
        }

        if (NAPI.Data.HasEntityData(player, "reanimando"))
        {
            if (player.GetData("reanimando") == true)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Sie können das jetzt nicht tun..");
                return;
            }
        }
        if(player.GetSharedData("Injured") < 101)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Sie können das jetzt nicht tun..");
            return;
        }
        if(price < 1)
        {
            NAPI.Notification.SendNotificationToPlayer(player," Der Wert darf nicht kleiner als 1 oder größer als 100000 sein.");
            return;
        }
        if (price > 100000)
        {
            NAPI.Notification.SendNotificationToPlayer(player," Der Wert darf nicht kleiner als 1 oder größer als 100000 sein.");
            return;
        }
        Client target = Main.findPlayer(player, idOrName);
        if (target != null)
        {
            if (target.GetSharedData("Injured") == 1)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Der Spieler ist bewusstlos, man kann ihm keine Heilung anbieten.");
                return;
            }

            if (target.Health >= 100)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Dieser Spieler ist bereits geheilt.");
                return;
            }

            if (!Main.IsInRangeOfPoint(player.Position, target.Position, 5))
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Sie müssen sich in der Nähe des Spielers befinden, den Sie heilen möchten.");
                return;
            }

            NAPI.Notification.SendNotificationToPlayer(player,"* Du hast ein Heilmittel für angeboten" + AccountManage.GetCharacterName(target) + " für ~g~R$" + price.ToString("N0") + "~w~.");
            target.SendChatMessage("~b~[Medic]:~w~ Der Arzt ~y~" + AccountManage.GetCharacterName(player) + "~w~ hat Ihnen ein Heilmittel angeboten ~g~$" + price.ToString("N0") + "~w~ (Benutze ~y~/aceitar cura~w~ um zu aktzeptieren).");

            target.SetData("curar_offerBy", player);
            target.SetData("curar_offerPrice", price);

            target.TriggerEvent("update_health", target.Health);

            NAPI.Task.Run(() =>
            {
                player.SetData("curar_offerBy", -1);
                player.SetData("curar_offerPrice", 0);
            }, delayTime: 30000);
        }
    }

    [Command("desfibrilador", Alias = "reanimar")]
    public void CMD_desfibrilador(Client sender)
    {
        //NAPI.Util.ConsoleOutput("-------- DEBUG CMD PLAYER: desf inicio");
        if (NAPI.Data.HasEntityData(sender, "reanimando"))
        {
            if (sender.GetData("reanimando") == true)
            {
                NAPI.Notification.SendNotificationToPlayer(sender, "ERROR:~w~ Sie erholen bereits einen Patienten, bitte warten Sie...");
                return;
            }
        }
        if (FactionManage.GetPlayerGroupType(sender) != FactionManage.FACTION_TYPE_MEDIC)
        {
            NAPI.Notification.SendNotificationToPlayer(sender, "ERROR:~w~ Du bist noch im Dienst..");
            return;
        }

        var players = NAPI.Pools.GetAllPlayers();
        foreach (var target in players)
        {
            if (target.GetData("status") == true)
            {
                if (Main.IsInRangeOfPoint(sender.Position, target.Position, 2.0f) && sender != target)
                {
                    if (target.GetSharedData("Injured") == 1)
                    {
                        sender.SetData("reanimando", true);
                        NAPI.Notification.SendNotificationToPlayer(sender, "~y~[INFO]:~w~ Sie versuchen den Patienten wiederzubeleben. ~y~" + AccountManage.GetCharacterName(target) + "~w~ ...");
                        NAPI.Player.PlayPlayerAnimation(sender, 49, "mini@cpr@char_a@cpr_str", "cpr_kol");
                        NAPI.Task.Run(() =>
                        {
                            if (sender.GetData("reanimando") == true)
                            {
                                AccountManage.SetPlayerHunger(target, 20.0f);
                                AccountManage.SetPlayerThirsty(target, 20.0f);
                                sender.SetData("reanimando", false);
                                target.SetSharedData("Injured", 0);
                                NAPI.Player.SetPlayerHealth(target, 40);
                                target.TriggerEvent("freeze", false);
                                target.TriggerEvent("freezeEx", false);
                                NAPI.Player.StopPlayerAnimation(target);
                                NAPI.Player.StopPlayerAnimation(sender);
                                NAPI.Notification.SendNotificationToPlayer(sender, "~y~[INFO]:~w~ Sie haben mit Erfolg den Patienten wiederbelebt ~y~" + AccountManage.GetCharacterName(target) + "~w~.");
                                Main.SendInfoMessage(target, "Sie wurden vom Arzt wiederbelebt ~y~" + AccountManage.GetCharacterName(sender) + "~w~.");
                                target.TriggerEvent("update_health", target.Health);
                            }
                        }, delayTime: 7 * 1000);


                    }
                    else NAPI.Notification.SendNotificationToPlayer(sender, "ERROR:~w~ Dieser Spieler ist nicht verletzt.");
                }
            }
        }
        NAPI.Notification.SendNotificationToPlayer(sender, "ERROR:~w~ Sie sind nicht in der Nähe eines unbewussten Spielers.");
        //NAPI.Util.ConsoleOutput("-------- DEBUG CMD PLAYER: des final");
    }

}

