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
using System.Timers;
using Newtonsoft.Json;

public class CallSystem : Script
{
    public static Timer callTimer = null;

    public static void CallSystemInit()
    {
        for (int i = 0; i < 15; i++)
        {
            NAPI.Data.SetWorldData("taxi_call_active" + i, 0);
            NAPI.Data.SetWorldData("taxi_call_player" + i, null);
        }
        for (int i = 0; i < 15; i++)
        {
            NAPI.Data.SetWorldData("cop_call_active" + i, 0);
            NAPI.Data.SetWorldData("cop_call_player" + i, null);
        }
        for (int i = 0; i < 15; i++)
        {
            NAPI.Data.SetWorldData("mech_call_active" + i, 0);
            NAPI.Data.SetWorldData("mech_call_player" + i, null);
        }
        for (int i = 0; i < 15; i++)
        {
            NAPI.Data.SetWorldData("sammu_call_active" + i, 0);
            NAPI.Data.SetWorldData("sammu_call_player" + i, null);
        }
    }

    [Command("solicitar")]
    public void CMD_solicitar(Client player)
    {
        List<dynamic> menu_item_list = new List<dynamic>();
        menu_item_list.Add(new { Type = 1, Name = "Doktor", Description = "" });
        menu_item_list.Add(new { Type = 1, Name = "Polizei", Description = "" });
        menu_item_list.Add(new { Type = 1, Name = "Mechaniker", Description = "" });
        menu_item_list.Add(new { Type = 1, Name = "Taxi", Description = "" });
        InteractMenu.CreateMenu(player, "CALL_SYSTEM_RESPONSE", "Anrufen", "~b~Anruf anfordern:", false, JsonConvert.SerializeObject(menu_item_list), false);
    }
   
    public static void SelectMenuResponse(Client player, String callbackId, int selectedIndex, String objectName, String valueList)
    {
        if(callbackId == "CALL_SYSTEM_RESPONSE")
        {
            int index = -1;
            switch (selectedIndex)
            {
                case 0:
                    {
                        for (int i = 0; i < 15; i++)
                        {
                            if (NAPI.Data.GetWorldData("sammu_call_active" + i) == 0)
                            {
                                index = i;
                                break;
                            }
                        }
                        if (index == -1) { NAPI.Notification.SendNotificationToPlayer(player,"* Es ist besetzt versuchen Sie es später noch einmal."); return; }

                        for (int i = 0; i < 15; i++)
                        {
                            if (NAPI.Data.GetWorldData("sammu_call_player" + i) == player && NAPI.Data.GetWorldData("sammu_call_active" + i) != 0)
                            {
                                NAPI.Notification.SendNotificationToPlayer(player, "Sie haben bereits eine medizinische Abteilung angerufen, bitte warten Sie...");
                                return;
                            }
                        }

                        NAPI.Data.SetWorldData("sammu_call_player" + index, player);
                        NAPI.Data.SetWorldData("sammu_call_active" + index, 1);

                        NAPI.Notification.SendNotificationToPlayer(player,"~y~[INFO]:~w~ Sie haben einen medizinischen Dienst beantragt, bitte warten Sie, bis jemand vom medizinischen Team...");
                        FactionManage.SendGroupMessage(2, "~y~*~w~ " + AccountManage.GetCharacterName(player) + " Sie benötigen einen Arzt, um die Anfrage zu bestätigen ~y~/antworten anrufen " + index + "~w~.");
                        break;
                    }
                case 1:
                    {
                        for (int i = 0; i < 15; i++)
                        {
                            if (NAPI.Data.GetWorldData("cop_call_active" + i) == 0)
                            {
                                index = i;
                                break;
                            }
                        }
                        if (index == -1) { NAPI.Notification.SendNotificationToPlayer(player,"* Es ist besetzt versuchen Sie es später noch einmal."); return; }

                        for (int i = 0; i < 15; i++)
                        {
                            if (NAPI.Data.GetWorldData("cop_call_player" + i) == player && NAPI.Data.GetWorldData("cop_call_active" + i) != 0)
                            {
                                NAPI.Notification.SendNotificationToPlayer(player, "Sie haben bereits eine Polizeieinheit angerufen, bitte warten Sie...");
                                return;
                            }
                        }

                        NAPI.Data.SetWorldData("cop_call_player" + index, player);
                        NAPI.Data.SetWorldData("cop_call_active" + index, 1);

                        NAPI.Notification.SendNotificationToPlayer(player,"~y~[INFO]:~w~Sie haben um eine Polizeieinheit gebeten, bitte warten Sie, bis ein Polizist antwortet...");
                        FactionManage.SendGroupMessage(1, "~y~*~w~ " + AccountManage.GetCharacterName(player) + "Sie benötigen eine Polizeieinheit, um die Verwendung der Anfrage zu bestätigen ~y~/antworten anrufen " + index + "~w~.");
                        break;
                    }
                case 2:
                    {
                        for (int i = 0; i < 15; i++)
                        {
                            if (NAPI.Data.GetWorldData("mech_call_active" + i) == 0)
                            {
                                index = i;
                                break;
                            }
                        }
                        if (index == -1) { NAPI.Notification.SendNotificationToPlayer(player,"* Es ist besetzt versuchen Sie es später noch einmal.."); return; }

                        for (int i = 0; i < 15; i++)
                        {
                            if (NAPI.Data.GetWorldData("mech_call_player" + i) == player && NAPI.Data.GetWorldData("mech_call_active" + i) != 0)
                            {
                                NAPI.Notification.SendNotificationToPlayer(player, "Sie haben bereits einen Mechaniker angerufen, bitte warten Sie...");
                                return;
                            }
                        }

                        NAPI.Data.SetWorldData("mech_call_player" + index, player);
                        NAPI.Data.SetWorldData("mech_call_active" + index, 1);

                        NAPI.Notification.SendNotificationToPlayer(player,"~y~[INFO]:~w~ Sie haben einen Mechanikerservice angefordert, warten Sie, bis ein Mechaniker antwortet.");
                        Main.SendJobMessage(2, "~y~*~w~ " + AccountManage.GetCharacterName(player) + " Sie benötigen einen Mechaniker, um die Anfrage zu bestätigen~y~/antworten" + index + "~w~.");
                        break;
                    }
                case 3:
                    {
                        for (int i = 0; i < 15; i++)
                        {
                            if (NAPI.Data.GetWorldData("taxi_call_active" + i) == 0)
                            {
                                index = i;
                                break;
                            }
                        }
                        if (index == -1) { NAPI.Notification.SendNotificationToPlayer(player,"*Es ist besetzt versuchen Sie es später noch einmal."); return; }

                        for (int i = 0; i < 15; i++)
                        {
                            if (NAPI.Data.GetWorldData("taxi_call_player" + i) == player && NAPI.Data.GetWorldData("taxi_call_active" + i) != 0)
                            {
                                NAPI.Notification.SendNotificationToPlayer(player, "Sie haben bereits ein Taxi gerufen, bitte warten Sie...");
                                return;
                            }
                        }

                        NAPI.Data.SetWorldData("taxi_call_player" + index, player);
                        NAPI.Data.SetWorldData("taxi_call_active" + index, 1);

                        NAPI.Notification.SendNotificationToPlayer(player,"~y~[INFO]:~w~ Sie haben einen Taxidienst angefordert, warten Sie, bis ein Taxifahrer reagiert.");
                        Main.SendJobMessage(3, "~y~*~w~ " + AccountManage.GetCharacterName(player) + "Sie benötigten einen Taxifahrer, um die Benutzeranfrage zu bestätigen ~y~/antworten taxi " + index + "~w~.");
                        break;
                    }
            }
        }
        else if(callbackId == "VIEW_CALL_SYSTEM_MEDIC")
        {
            int chamada = player.GetData("ListTrack_" + selectedIndex + "");

            if (FactionManage.GetPlayerGroupType(player) == 2)
            {
                Client target = NAPI.Data.GetWorldData("sammu_call_player" + chamada);
                int active = NAPI.Data.GetWorldData("sammu_call_active" + chamada);

                if (active == 0)
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "Dieser Aufruf existiert nicht. Doktor");        
                    return;
                }

                if (active == 2)
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "Jemand beantwortet diesen Anruf bereits.");
                    return;
                }

                if (!AccountManage.GetPlayerConnected(target))
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "Der Bürger ist nicht mehr verbunden.");
                    return;
                }

                target.SendChatMessage("~y~[INFO]:~w~ Der Arzt ~y~" + AccountManage.GetCharacterName(player) + "~w~ Ihre Anfrage beantwortet und ist unterwegs. Verlassen Sie diesen Bereich nicht, sonst wird der Anruf abgebrochen!");
                NAPI.Notification.SendNotificationToPlayer(player,"~y~[INFO]:~w~ Sie haben geantwortet ~y~" + AccountManage.GetCharacterName(target) + "~w~. ~c~Folgen Sie der gelben Markierung auf der Minikarte.");

                NAPI.Data.SetWorldData("sammu_call_active" + chamada, 2);

                player.TriggerEvent("delete_call_marker");
                player.TriggerEvent("marker_call_create", new Vector3(target.Position.X, target.Position.Y, target.Position.Z - 1), new Vector3(12, 12, 80));

                NAPI.Data.SetWorldData("sammu_call_responder" + chamada, player);
                NAPI.Data.SetWorldData("sammu_call_area" + chamada, NAPI.ColShape.CreateCylinderColShape(target.Position, 12f, 12f));

                player.TriggerEvent("job_create_blipped_marker", "Anrufen", target.Position);
                player.TriggerEvent("blip_remove", "Anrufen");
                player.TriggerEvent("blip_create_ext", "Anrufen", target.Position, 60, 0.70f, 0);
                player.TriggerEvent("blip_router_visible", "Anrufen", true, 60);
            }
            else NAPI.Notification.SendNotificationToPlayer(player, "Sie sind im Notdienst.");
        }
        else if(callbackId == "VIEW_CALL_SYSTEM_POLICE")
        {
            int chamada = player.GetData("ListTrack_" + selectedIndex + "");
            if (FactionManage.GetPlayerGroupType(player) == 1)
            {
                Client target = NAPI.Data.GetWorldData("cop_call_player" + chamada);
                int active = NAPI.Data.GetWorldData("cop_call_active" + chamada);

                if (active == 0)
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "Dieser Aufruf existiert nicht.COP");
                    return;
                }

                if (active == 2)
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "Jemand beantwortet diesen Anruf bereits.");
                    return;
                }

                if (!AccountManage.GetPlayerConnected(target))
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "Der Bürger ist nicht mehr verbunden");
                    return;
                }


                target.SendChatMessage("~y~[INFO]:~w~ O Offizielle ~y~" + AccountManage.GetCharacterName(player) + "~w~ Ihre Anfrage beantwortet und ist unterwegs Verlassen Sie diesen Bereich nicht, sonst wird der Anruf abgebrochen!");
                NAPI.Notification.SendNotificationToPlayer(player,"~y~[INFO]:~w~ Sie haben auf das geantwortet ~y~" + AccountManage.GetCharacterName(target) + "~w~. ~c~Folgen Sie der gelben Markierung auf der Minikarte.");

                NAPI.Data.SetWorldData("cop_call_active" + chamada, 2);

                player.TriggerEvent("delete_call_marker");
                player.TriggerEvent("marker_call_create", new Vector3(target.Position.X, target.Position.Y, target.Position.Z - 1), new Vector3(12, 12, 80));

                NAPI.Data.SetWorldData("cop_call_responder" + chamada, player);
                NAPI.Data.SetWorldData("cop_call_area" + chamada, NAPI.ColShape.CreateCylinderColShape(target.Position, 12f, 12f));

                player.TriggerEvent("job_create_blipped_marker", "Anrufen", target.Position);

                player.TriggerEvent("blip_remove", "Anrufen");
                player.TriggerEvent("blip_create_ext", "Anrufen", target.Position, 60, 0.70f, 0);
                player.TriggerEvent("blip_router_visible", "Anrufen", true, 60);
            }
        }
        else if(callbackId == "VIEW_CALL_SYSTEM_MECHANIC")
        {
            int chamada = player.GetData("ListTrack_" + selectedIndex + "");
            if (AccountManage.GetPlayerGroup(player) != 15)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Du bist kein Arbeiter von den LS ACLS!");
                return;
            }
            Client target = NAPI.Data.GetWorldData("mech_call_player" + chamada);
            int active = NAPI.Data.GetWorldData("mech_call_active" + chamada);

            if (active == 0)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Dieser Aufruf existiert nicht.");
                return;
            }

            if (active == 2)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Jemand beantwortet diesen Anruf bereits.");
                return;
            }

            if (!AccountManage.GetPlayerConnected(target))
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Bürger ist nicht mehr verbunden.");
                return;
            }


            target.SendChatMessage("~y~[INFO]:~w~ O Mechaniker ~y~" + AccountManage.GetCharacterName(player) + "~w~ Ihre Anfrage beantwortet und ist unterwegs. Verlassen Sie diesen Bereich nicht, sonst wird der Anruf abgebrochen!");
            NAPI.Notification.SendNotificationToPlayer(player,"~y~[INFO]:~w~Sie haben auf das geantwortet~y~" + AccountManage.GetCharacterName(target) + "~w~. ~c~Folgen Sie der gelben Markierung auf der Minikarte.");

            NAPI.Data.SetWorldData("mech_call_active" + chamada, 2);

            player.TriggerEvent("delete_call_marker");
            player.TriggerEvent("marker_call_create", new Vector3(target.Position.X, target.Position.Y, target.Position.Z - 1), new Vector3(12, 12, 80));

            NAPI.Data.SetWorldData("mech_call_responder" + chamada, player);
            NAPI.Data.SetWorldData("mech_call_area" + chamada, NAPI.ColShape.CreateCylinderColShape(target.Position, 12f, 12f));

            player.TriggerEvent("job_create_blipped_marker", "Anrufen", target.Position);

            player.TriggerEvent("blip_remove", "Anrufen");
            player.TriggerEvent("blip_create_ext", "Anrufen", target.Position, 60, 0.70f, 0);
            player.TriggerEvent("blip_router_visible", "Anrufen", true, 60);
        }
        else if(callbackId == "VIEW_CALL_SYSTEM_TAXI")
        {
            int chamada = player.GetData("ListTrack_" + selectedIndex + "");
            if (AccountManage.GetPlayerJob(player) != 3)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Du bist kein Taxifahrer..");
                return;
            }

            Client target = NAPI.Data.GetWorldData("taxi_call_player" + chamada);
            int active = NAPI.Data.GetWorldData("taxi_call_active" + chamada);

            if (active == 0)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Dieser Aufruf existiert nicht.");
                return;
            }

            if (active == 2)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Jemand beantwortet diesen Anruf bereits.");
                return;
            }

            if (!AccountManage.GetPlayerConnected(target))
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Bürger ist nicht mehr verbunden");
                return;
            }


            target.SendChatMessage("~y~[INFO]:~w~ Taxi~y~" + AccountManage.GetCharacterName(player) + "~w~ Ihre Anfrage beantwortet und ist unterwegs. Verlassen Sie diesen Bereich nicht, sonst wird der Anruf abgebrochen!");
            NAPI.Notification.SendNotificationToPlayer(player,"~y~[INFO]:~w~ Sie haben auf das geantwortet ~y~" + AccountManage.GetCharacterName(target) + "~w~. ~c~Folgen Sie der gelben Markierung auf der Minikarte.");

            NAPI.Data.SetWorldData("taxi_call_active" + chamada, 2);

            player.TriggerEvent("delete_call_marker");
            player.TriggerEvent("marker_call_create", new Vector3(target.Position.X, target.Position.Y, target.Position.Z - 1), new Vector3(12, 12, 80));

            NAPI.Data.SetWorldData("taxi_call_responder" + chamada, player);
            NAPI.Data.SetWorldData("taxi_call_area" + chamada, NAPI.ColShape.CreateCylinderColShape(target.Position, 12f, 12f));

            player.TriggerEvent("job_create_blipped_marker", "Anrufen", target.Position);

            player.TriggerEvent("blip_remove", "Anrufen");
            player.TriggerEvent("blip_create_ext", "Anrufen", target.Position, 60, 0.70f, 0);
            player.TriggerEvent("blip_router_visible", "Anrufen", true, 60);
        }
    }

    [Command("chamadas")]
    public void CMD_chamadas(Client player)
    {
        List<dynamic> menu_item_list = new List<dynamic>();
        int index = 0;
        if (FactionManage.GetPlayerGroupType(player) == 1 || AccountManage.GetPlayerGroup(player) == 25)
        {
            for (int i = 0; i < 15; i++)
            {
                if (NAPI.Data.GetWorldData("cop_call_player" + i) != null && AccountManage.GetPlayerConnected(NAPI.Data.GetWorldData("cop_call_player" + i)))
                {
                    menu_item_list.Add(new { Type = 1, Name = "~c~#" + i + ". ~s~" + AccountManage.GetCharacterName(NAPI.Data.GetWorldData("cop_call_player" + i)) + "", Description = "Wählen Sie, um den Anruf anzunehmen.", RightLabel = "~y~Status:~c~ Erwarte Antwort" });
                    player.SetData("ListTrack_" + index + "", i);
                    index++;
                }
            }
            if(index == 0)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Nein zu allen ausstehenden Anrufen zu diesem Zeitpunkt.");
                return;
            }
            InteractMenu.CreateMenu(player, "VIEW_CALL_SYSTEM_MEDIC", "Anrufen", "~b~Ausstehende Anrufliste:", false, JsonConvert.SerializeObject(menu_item_list), false);
        }
        else if (FactionManage.GetPlayerGroupType(player) == 2)
        {
            for (int i = 0; i < 15; i++)
            {
                if (NAPI.Data.GetWorldData("sammu_call_player" + i) != null && AccountManage.GetPlayerConnected(NAPI.Data.GetWorldData("sammu_call_player" + i)))
                {
                    menu_item_list.Add(new { Type = 1, Name = "~c~#" + i + ". ~s~" + AccountManage.GetCharacterName(NAPI.Data.GetWorldData("sammu_call_player" + i)) + "", Description = "Wählen Sie,um den Anruf anzunehmen.", RightLabel = "~y~Status:~c~ Erwarte Antwort" });
                    player.SetData("ListTrack_" + index + "", i);
                    index++;

                }
            }
            if (index == 0)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Nein zu allen ausstehenden Anrufen zu diesem Zeitpunkt.");
                return;
            }
            InteractMenu.CreateMenu(player, "VIEW_CALL_SYSTEM_POLICE", "Anrufen", "~b~Ausstehende Anrufliste: ", false, JsonConvert.SerializeObject(menu_item_list), false);
        }
        else
        {
            if(AccountManage.GetPlayerJob(player) == 2)
            {
                for (int i = 0; i < 15; i++)
                {
                    if (NAPI.Data.GetWorldData("mech_call_player" + i) != null && AccountManage.GetPlayerConnected(NAPI.Data.GetWorldData("mech_call_player" + i)))
                    {
                        menu_item_list.Add(new { Type = 1, Name = "~c~#" + i + ". ~s~" + AccountManage.GetCharacterName(NAPI.Data.GetWorldData("mech_call_player" + i)) + "", Description = "Wählen Sie,um den Anruf anzunehmen.", RightLabel = "~y~Status:~c~ Erwarte Antwort" });
                        player.SetData("ListTrack_" + index + "", i);
                        index++;
                    }
                }
                if (index == 0)
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "Nein zu allen ausstehenden Anrufen zu diesem Zeitpunkt..");
                    return;
                }
                InteractMenu.CreateMenu(player, "VIEW_CALL_SYSTEM_MECHANIC", "Anrufen", "~b~Ausstehende Anrufliste:", true, JsonConvert.SerializeObject(menu_item_list), false);
            }
            else if (AccountManage.GetPlayerJob(player) == 3)
            {
                for (int i = 0; i < 15; i++)
                {
                    if (NAPI.Data.GetWorldData("taxi_call_player" + i) != null && AccountManage.GetPlayerConnected(NAPI.Data.GetWorldData("taxi_call_player" + i)))
                    {
                        menu_item_list.Add(new { Type = 1, Name = "~c~#" + i + ". ~s~" + AccountManage.GetCharacterName(NAPI.Data.GetWorldData("taxi_call_player" + i)) + "", Description = "Wählen Sie,um den Anruf anzunehmen.", RightLabel = "~y~Status:~c~ Erwarte Antwort" });
                        player.SetData("ListTrack_" + index + "", i);
                        index++;
                    }
                }
                if (index == 0)
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "Nein - zu diesem Zeitpunkt keine anstehenden Anrufe.");
                    return;
                }
                InteractMenu.CreateMenu(player, "VIEW_CALL_SYSTEM_TAXI", "Anrufen", "~b~Ausstehende Anrufliste: ", true, JsonConvert.SerializeObject(menu_item_list), false);
            }
            else
            {
                NAPI.Notification.SendNotificationToPlayer(player," Sie haben keinen Zugriff auf das aufrufende System.");
            }
        }
    }

    [Command("verchamadas", "/verchamadas [taxi / mecanico / policia / sammu]")]
    public void CMD_verchamdas(Client player, string nome)
    {
        if (nome == "sammu")
        {
            for (int i = 0; i < 15; i++)
            {
                if (NAPI.Data.GetWorldData("sammu_call_player" + i) != null && AccountManage.GetPlayerConnected(NAPI.Data.GetWorldData("sammu_call_player" + i)))
                {
                    NAPI.Notification.SendNotificationToPlayer(player,"~y~Anrufen:~c~ #" + i + " ~w~-~y~ Name:~w~ " + AccountManage.GetCharacterName(NAPI.Data.GetWorldData("sammu_call_player" + i)) + "~w~ -~y~ Status:~c~ Erwarte Antwort");
                }
            }
        }
        else if (nome == "policia")
        {
            for (int i = 0; i < 15; i++)
            {
                if (NAPI.Data.GetWorldData("cop_call_player" + i) != null && AccountManage.GetPlayerConnected(NAPI.Data.GetWorldData("cop_call_player" + i)))
                {
                    NAPI.Notification.SendNotificationToPlayer(player,"~y~Anrufen:~c~ #" + i + " ~w~-~y~ Name:~w~ " + AccountManage.GetCharacterName(NAPI.Data.GetWorldData("cop_call_player" + i)) + "~w~ -~y~ Status:~c~ Erwarte Antwort");
                }
            }
        }
        else if (nome == "mecanico")
        {
            for (int i = 0; i < 15; i++)
            {
                if (NAPI.Data.GetWorldData("mech_call_player" + i) != null && AccountManage.GetPlayerConnected(NAPI.Data.GetWorldData("mech_call_player" + i)))
                {
                    NAPI.Notification.SendNotificationToPlayer(player,"~y~Chamada:~c~ #" + i + " ~w~-~y~ Name:~w~ " + AccountManage.GetCharacterName(NAPI.Data.GetWorldData("mech_call_player" + i)) + "~w~ -~y~ Status:~c~ Erwarte Antwort");
                }
            }
        }
        else if (nome == "taxista")
        {
            for (int i = 0; i < 15; i++)
            {
                if (NAPI.Data.GetWorldData("taxi_call_player" + i) != null && AccountManage.GetPlayerConnected(NAPI.Data.GetWorldData("taxi_call_player" + i)))
                {
                    NAPI.Notification.SendNotificationToPlayer(player,"~y~Anruf:~c~ #" + i + " ~w~-~y~ Name:~w~ " + AccountManage.GetCharacterName(NAPI.Data.GetWorldData("taxi_call_player" + i)) + "~w~ -~y~ Status:~c~ Erwarte Antwort");
                }
            }
        }
    }

    [Command("responder", "/responder [taxi / mecanico / chamada] [# chamada]")]
    public void CMD_responder(Client player, string nome, int chamada)
    {
        if (nome == "taxi")
        {
            if (AccountManage.GetPlayerJob(player) != 3)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Du bist kein Taxifahrer..");
                return;
            }

            Client target = NAPI.Data.GetWorldData("taxi_call_player" + chamada);
            int active = NAPI.Data.GetWorldData("taxi_call_active" + chamada);

            if (active == 0)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Dieser Aufruf existiert nicht.");
                return;
            }

            if (active == 2)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Jemand beantwortet diesen Anruf bereits.");
                return;
            }

            if (!AccountManage.GetPlayerConnected(target))
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Bürger ist nicht mehr verbunden");
                return;
            }

            target.SendChatMessage("~y~[INFO]:~w~ O Taxi ~y~" + AccountManage.GetCharacterName(player) + "~w~ Sie haben Ihre Anfrage beantwortet und sind unterwegs  halten Sie sich hier im Bereich auf, sonst wird der Auftrag abgebrochen!");
            NAPI.Notification.SendNotificationToPlayer(player,"~y~[INFO]:~w~ Sie haben geantwortet auf ~y~" + AccountManage.GetCharacterName(target) + "~w~. ~c~Folgen Sie der gelben Markierung auf der Minikarte.");

            NAPI.Data.SetWorldData("taxi_call_active" + chamada, 2);

            player.TriggerEvent("delete_call_marker");
            player.TriggerEvent("marker_call_create", new Vector3(target.Position.X, target.Position.Y, target.Position.Z - 1), new Vector3(12, 12, 80));

            NAPI.Data.SetWorldData("taxi_call_responder" + chamada, player);
            NAPI.Data.SetWorldData("taxi_call_area" + chamada, NAPI.ColShape.CreateCylinderColShape(target.Position, 12f, 12f));

            player.TriggerEvent("job_create_blipped_marker", "Anrufen", target.Position);

            player.TriggerEvent("blip_remove", "Anrufen");
            player.TriggerEvent("blip_create_ext", "Anrufen", target.Position, 60, 0.70f, 0);
            player.TriggerEvent("blip_router_visible", "Anrufen", true, 60);

        }
        else if (nome == "mecanico")
        {
            if (AccountManage.GetPlayerGroup(player) != 15)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Du bist kein Arbeiter von den LS ACLS!");
                return;
            }
            Client target = NAPI.Data.GetWorldData("mech_call_player" + chamada);
            int active = NAPI.Data.GetWorldData("mech_call_active" + chamada);

            if (active == 0)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Dieser Aufruf existiert nicht.");
                return;
            }

            if (active == 2)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Jemand beantwortet diesen Anruf bereits.");
                return;
            }

            if (!AccountManage.GetPlayerConnected(target))
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Der Bürger ist nicht mehr verbunden.");
                return;
            }

            target.SendChatMessage("~y~[INFO]:~w~ ACLS ~y~" + AccountManage.GetCharacterName(player) + "~w~ Ihre Anfrage beantwortet und ist unterwegs. Verlassen Sie diesen Bereich nicht, sonst wird der Anruf abgebrochen!");
            NAPI.Notification.SendNotificationToPlayer(player,"~y~[INFO]:~w~ Sie haben auf das geantwortet~y~" + AccountManage.GetCharacterName(target) + "~w~. ~c~Folgen Sie der gelben Markierung auf der Minikarte");

            NAPI.Data.SetWorldData("mech_call_active" + chamada, 2);

            player.TriggerEvent("delete_call_marker");
            player.TriggerEvent("marker_call_create", new Vector3(target.Position.X, target.Position.Y, target.Position.Z - 1), new Vector3(12, 12, 80));

            NAPI.Data.SetWorldData("mech_call_responder" + chamada, player);
            NAPI.Data.SetWorldData("mech_call_area" + chamada, NAPI.ColShape.CreateCylinderColShape(target.Position, 12f, 12f));

            player.TriggerEvent("job_create_blipped_marker", "Anrufen", target.Position);

            player.TriggerEvent("blip_remove", "Anrufen");
            player.TriggerEvent("blip_create_ext", "Anrufen", target.Position, 60, 0.70f, 0);
            player.TriggerEvent("blip_router_visible", "Anrufen", true, 60);

        }
        else if (nome == "chamada")
        {
            if (FactionManage.GetPlayerGroupType(player) == 1 || AccountManage.GetPlayerGroup(player) == 25)
            {
                Client target = NAPI.Data.GetWorldData("cop_call_player" + chamada);
                int active = NAPI.Data.GetWorldData("cop_call_active" + chamada);

                if (active == 0)
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "Dieser Aufruf existiert nicht.COP");
                    return;
                }

                if (active == 2)
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "Jemand beantwortet diesen Anruf bereits.");
                    return;
                }

                if (!AccountManage.GetPlayerConnected(target))
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "Dieser Player ist nicht mehr angeschlossen.");
                    return;
                }


                target.SendChatMessage("~y~[INFO]:~w~ O Offiziell ~y~" + AccountManage.GetCharacterName(player) + "~w~Ihre Anfrage beantwortet und ist unterwegs. Verlassen Sie diesen Bereich nicht, sonst wird der Anruf abgebrochen!");
                NAPI.Notification.SendNotificationToPlayer(player,"~y~[INFO]:~w~ Sie haben auf das geantwortet ~y~" + AccountManage.GetCharacterName(target) + "~w~. ~c~Folgen Sie der gelben Markierung auf der Minikarte.");

                NAPI.Data.SetWorldData("cop_call_active" + chamada, 2);

                player.TriggerEvent("delete_call_marker");
                player.TriggerEvent("marker_call_create", new Vector3(target.Position.X, target.Position.Y, target.Position.Z - 1), new Vector3(12, 12, 80));

                NAPI.Data.SetWorldData("cop_call_responder" + chamada, player);
                NAPI.Data.SetWorldData("cop_call_area" + chamada, NAPI.ColShape.CreateCylinderColShape(target.Position, 12f, 12f));

                player.TriggerEvent("job_create_blipped_marker", "Anrufen", target.Position);

                player.TriggerEvent("blip_remove", "Anrufen");
                player.TriggerEvent("blip_create_ext", "Anrufen", target.Position, 60, 0.70f, 0);
                player.TriggerEvent("blip_router_visible", "Anrufen", true, 60);
            }
            else if (FactionManage.GetPlayerGroupType(player) == 2)
            {
                Client target = NAPI.Data.GetWorldData("sammu_call_player" + chamada);
                int active = NAPI.Data.GetWorldData("sammu_call_active" + chamada);

                if (active == 0)
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "Dieser Aufruf existiert nicht.MEDIZIN ");
                    return;
                }

                if (active == 2)
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "Jemand beantwortet diesen Anruf bereits.");
                    return;
                }

                if (!AccountManage.GetPlayerConnected(target))
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "Bürger ist nicht mehr verbunden.");
                    return;
                }

                target.SendChatMessage("~y~[INFO]:~w~ Der Doktor ~y~" + AccountManage.GetCharacterName(player) + "~w~ Ihre Anfrage beantwortet und ist unterwegs. Verlassen Sie diesen Bereich nicht, sonst wird der Anruf abgebrochen!");
                NAPI.Notification.SendNotificationToPlayer(player,"~y~[INFO]:~w~ Sie haben auf das geantwortet ~y~" + AccountManage.GetCharacterName(target) + "~w~. ~c~Folgen Sie der gelben Markierung auf der Minikarte.");

                NAPI.Data.SetWorldData("sammu_call_active" + chamada, 2);

                player.TriggerEvent("delete_call_marker");
                player.TriggerEvent("marker_call_create", new Vector3(target.Position.X, target.Position.Y, target.Position.Z - 1), new Vector3(12, 12, 80));

                NAPI.Data.SetWorldData("sammu_call_responder" + chamada, player);
                NAPI.Data.SetWorldData("sammu_call_area" + chamada, NAPI.ColShape.CreateCylinderColShape(target.Position, 12f, 12f));

                player.TriggerEvent("job_create_blipped_marker", "Anrufen", target.Position);
                player.TriggerEvent("blip_remove", "Anrufen");
                player.TriggerEvent("blip_create_ext", "Anrufen", target.Position, 60, 0.70f, 0);
                player.TriggerEvent("blip_router_visible", "Anrufen", true, 60);
            }
            else NAPI.Notification.SendNotificationToPlayer(player, "Sie sind kein Politiker oder Arzt.");
        }
        else NAPI.Notification.SendNotificationToPlayer(player," / responder[taxi / mecanico / chamada][# chamada]");

    }
    public static void OnEnterDynamicArea(Client player, ColShape shape)
    {
        for (int i = 0; i < 15; i++)
        {
            if (NAPI.Data.GetWorldData("taxi_call_area" + i) == shape)
            {
                if(NAPI.Data.GetWorldData("taxi_call_responder" + i) == player)
                {
                    NAPI.Notification.SendNotificationToPlayer(player,"~y~[INFO]:~w~ Sie haben Ihr Ziel erreicht.");
                    player.TriggerEvent("job_remove_marker", "Anrufen");

                    NAPI.Data.SetWorldData("taxi_call_active" + i, 0);
                    NAPI.ColShape.DeleteColShape(NAPI.Data.GetWorldData("taxi_call_area" + i));
                }
            }
            else if (NAPI.Data.GetWorldData("cop_call_area" + i) == shape)
            {
                if (NAPI.Data.GetWorldData("cop_call_responder" + i) == player)
                {
                    NAPI.Notification.SendNotificationToPlayer(player,"~y~[INFO]:~w~ Sie sind an Ihrem Ziel angekommen.");

                    player.TriggerEvent("job_remove_marker", "Anrufen");

                    NAPI.Data.SetWorldData("cop_call_active" + i, 0);
                    NAPI.ColShape.DeleteColShape(NAPI.Data.GetWorldData("cop_call_area" + i));
                }
            }
            else if (NAPI.Data.GetWorldData("mech_call_area" + i) == shape)
            {
                if (NAPI.Data.GetWorldData("mech_call_responder" + i) == player)
                {
                    NAPI.Notification.SendNotificationToPlayer(player,"~y~[INFO]:~w~Sie sind an Ihrem Ziel angekommen.");

                    player.TriggerEvent("job_remove_marker", "Anrufen");

                    NAPI.Data.SetWorldData("mech_call_active" + i, 0);
                    NAPI.ColShape.DeleteColShape(NAPI.Data.GetWorldData("mech_call_area" + i));
                }
            }
            else if (NAPI.Data.GetWorldData("sammu_call_area" + i) == shape)
            {
                if (NAPI.Data.GetWorldData("sammu_call_responder" + i) == player)
                {
                    NAPI.Notification.SendNotificationToPlayer(player,"~y~[INFO]:~w~ Sie sind an Ihrem Ziel angekommen.");

                    player.TriggerEvent("job_remove_marker", "Anrufen");

                    NAPI.Data.SetWorldData("sammu_call_active" + i, 0);
                    NAPI.ColShape.DeleteColShape(NAPI.Data.GetWorldData("sammu_call_area" + i));
                }
            }
        }
    }

    public static void OnLeaveDynamicArea(Client player, ColShape shape)
    {
        for (int i = 0; i < 15; i++)
        {
            if (NAPI.Data.GetWorldData("taxi_call_area" + i) == shape)
            {
                if (NAPI.Data.GetWorldData("taxi_call_player" + i) == player)
                {
                    Client responser = NAPI.Data.GetWorldData("taxi_call_responder" + i);
                    NAPI.Data.SetWorldData("taxi_call_active" + i, 0);
                    NAPI.ColShape.DeleteColShape(NAPI.Data.GetWorldData("taxi_call_area" + i));

                    if (responser.GetData("status") == true)
                    {
                        responser.TriggerEvent("job_remove_marker", "Anrufen");
                        responser.SendChatMessage("~y~[INFO]:~w~Der Anruf wurde abgebrochen~w~ da sich der Bürger von der Unfallstelle entfernt hat.");
                    }
                    
                    NAPI.Notification.SendNotificationToPlayer(player,"~y~[INFO]:~w~ Der Anruf wurde abgebrochen~w~ weil Sie zu weit vom Standort entfernt sind.");
                }
            }
            else if (NAPI.Data.GetWorldData("mech_call_area" + i) == shape)
            {
                if (NAPI.Data.GetWorldData("mech_call_player" + i) == player)
                {
                    Client responser = NAPI.Data.GetWorldData("mech_call_responder" + i);
                    NAPI.Data.SetWorldData("mech_call_active" + i, 0);
                    NAPI.ColShape.DeleteColShape(NAPI.Data.GetWorldData("mech_call_area" + i));

                    if (responser.GetData("status") == true)
                    {
                        responser.TriggerEvent("job_remove_marker", "Anrufen");
                        responser.SendChatMessage("~y~[INFO]:~w~ Der Anruf wurde abgebrochen~w~ da sich der Bürger von der Unfallstelle entfernt hat.");
                    }

                    NAPI.Notification.SendNotificationToPlayer(player,"~y~[INFO]:~w~ Der Anruf wurde abgebrochen~w~ weil Sie zu weit vom Standort entfernt sind.");
                }
            }
            else if (NAPI.Data.GetWorldData("cop_call_area" + i) == shape)
            {
                if (NAPI.Data.GetWorldData("cop_call_player" + i) == player)
                {
                    Client responser = NAPI.Data.GetWorldData("cop_call_responder" + i);
                    NAPI.Data.SetWorldData("cop_call_active" + i, 0);
                    NAPI.ColShape.DeleteColShape(NAPI.Data.GetWorldData("cop_call_area" + i));

                    if (responser.GetData("status") == true)
                    {
                        responser.TriggerEvent("job_remove_marker", "Anrufen");
                        responser.SendChatMessage("~y~[INFO]:~w~ Der Anruf wurde abgebrochen~w~ da sich der Bürger von der Unfallstelle entfernt hat.");
                    }


                    NAPI.Notification.SendNotificationToPlayer(player,"~y~[INFO]:~w~ Der Anruf wurde abgebrochen~w~ weil Sie zu weit vom Standort entfernt sind.");
                }
            }
            else if (NAPI.Data.GetWorldData("sammu_call_area" + i) == shape)
            {
                if (NAPI.Data.GetWorldData("sammu_call_player" + i) == player)
                {
                    Client responser = NAPI.Data.GetWorldData("sammu_call_responder" + i);
                    NAPI.Data.SetWorldData("sammu_call_active" + i, 0);
                    NAPI.ColShape.DeleteColShape(NAPI.Data.GetWorldData("sammu_call_area" + i));

                    if (responser.GetData("status") == true)
                    {
                        responser.TriggerEvent("job_remove_marker", "Anrufen");
                        responser.SendChatMessage("~y~[INFO]:~w~ Der Anruf wurde abgebrochen~w~ da sich der Bürger von der Unfallstelle entfernt hat.");
                    }

                    NAPI.Notification.SendNotificationToPlayer(player,"~y~[INFO]:~w~ Der Anruf wurde abgebrochen~w~ weil Sie zu weit vom Standort entfernt sind.");
                }
            }
        }
    }
}
