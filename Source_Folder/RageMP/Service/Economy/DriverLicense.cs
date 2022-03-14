using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;
using Newtonsoft.Json;

public class DriverLicense : Script
{ 
    public static Vehicle[] school_vehicle { get; set; } = new Vehicle[Main.MAX_PLAYERS];
    public static ColShape[] school_checkpoint { get; set; } = new ColShape[Main.MAX_PLAYERS];
    public static TimerEx[] school_tutorial_timer { get; set; } = new TimerEx[Main.MAX_PLAYERS];

    public static List<dynamic> vehicle_rota = new List<dynamic>();

    public DriverLicense()
    {
        //

        vehicle_rota.Add(new { position = new Vector3(-857.7657, -678.655, 27.44595), message = "nein" });
        vehicle_rota.Add(new { position = new Vector3(-766.16, -663.4907, 29.68983), message = "stop" });
        vehicle_rota.Add(new { position = new Vector3(-659.6437, -666.3749, 31.17846), message = "vorbereiten rechts abbiegen" });
        vehicle_rota.Add(new { position = new Vector3(-647.0443, -809.8311, 24.40849), message = "nein" });
        vehicle_rota.Add(new { position = new Vector3(-724.0414, -835.6301, 22.67143), message = "nein" });
        vehicle_rota.Add(new { position = new Vector3(-808.5193, -1001.585, 12.83885), message = "nein" });
        vehicle_rota.Add(new { position = new Vector3(-852.2369, -854.4364, 18.84173), message = "nein" });
        vehicle_rota.Add(new { position = new Vector3(-1056.724, -772.5824, 18.80974), message = "nein" }); // 0, 0, 65.57136
        vehicle_rota.Add(new { position = new Vector3(-1276.796, -509.2187, 32.36356), message = "vorwärts" }); // 0, 0, 65.57136
        vehicle_rota.Add(new { position = new Vector3(-1019.54, -364.7518, 37.30814), message = "links" }); // 0, 0, 65.57136
        vehicle_rota.Add(new { position = new Vector3(-852.7932, -738.0178, 23.72642), message = "bereiten Sie sich vor" }); // 0, 0, 65.57136
        vehicle_rota.Add(new { position = new Vector3(-866.0205, -810.6578, 18.73167), message = "bereiten Sie sich vor" }); // 0, 0, 65.57136

        Entity temp_blip;
        temp_blip = NAPI.Blip.CreateBlip(new Vector3(-830.2873, -795.3666, 20.23415));
        NAPI.Blip.SetBlipName(temp_blip, "LS Lizenzamt");
        NAPI.Blip.SetBlipSprite(temp_blip, 498);
        NAPI.Blip.SetBlipColor(temp_blip, 81);
        NAPI.Blip.SetBlipScale(temp_blip, 1.0f);
        NAPI.Blip.SetBlipShortRange(temp_blip, true);

        NAPI.Marker.CreateMarker(27, new Vector3(-830.2873, -795.3666, 20.23415) - new Vector3(0, 0, 0.6f), new Vector3(), new Vector3(), 3.5f, new Color(247, 221, 52, 150));
        NAPI.Marker.CreateMarker(29, new Vector3(-830.2873, -795.3666, 20.23415) - new Vector3(0, 0, 0.5f), new Vector3(), new Vector3(), 1.0f, new Color(247, 221, 52, 150));
        NAPI.TextLabel.CreateTextLabel("- LS Lizenzamt - ", new Vector3(-830.2873, -795.3666, 20.23415) + new Vector3(0, 0, 0.2f), 15.0f, 0.9f, 4, new Color(252, 68, 68, 210));
    }

    public static void PressKeyY(Client player)
    {
        if(Main.IsInRangeOfPoint(player.Position, new Vector3(-830.2873, -795.3666, 20.23415), 3))
        {
            List<dynamic> menu_item_list = new List<dynamic>();
            menu_item_list.Add(new { Type = 1, Name = "~c~Führerschein PKW", Description = "Eine praktische Prüfung zum Füherschein erfordert die Theorie.", RightLabel = "$1650" });
            menu_item_list.Add(new { Type = 1, Name = "~c~Führerschein LKW", Description = "Für die praktische Prüfung eines LKW-Führerschein, benötigen Sie einen PKW-Führerschein", RightLabel = "$4000" });
            menu_item_list.Add(new { Type = 1, Name = "Flugschein", Description = "Eine Kontrolle über die Fahrschule erfolgt nicht!", RightLabel = "$25000" });
            menu_item_list.Add(new { Type = 1, Name = "Angelschein", Description = "Eine Kontrolle über die Fahrschule erfolgt nicht!", RightLabel = "$1000" });
            menu_item_list.Add(new { Type = 1, Name = "Taxi Führerschein", Description = "Eine Kontrolle über die Fahrschule erfolgt nicht!", RightLabel = "$10000" });
            menu_item_list.Add(new { Type = 1, Name = "Waffenschein", Description = "Dieser Waffenschein ist für Pistolen! Alles andere ist Illegal!", RightLabel = "$25000" });
            menu_item_list.Add(new { Type = 1, Name = "Anwaltliches Zertifikat", Description = "Dieses Anwaltliches Zertifikat ist für die Prüfung bei der Justiz gedacht! Ohne einer Prüfung bekommen Sie keine Staatliche Hilfe!", RightLabel = "$40000" });
            menu_item_list.Add(new { Type = 1, Name = "Motorrad-Führerschein", Description = "Eine praktische Prüfung zum Füherschein erfordert die Theorie.", RightLabel = "$3000" });
            InteractMenu.CreateMenu(player, "DMV_SCHOOL", "Lizenzamt", "Führerscheine", true, JsonConvert.SerializeObject(menu_item_list), false);
        }
    }


    public static void SelectMenuResponse(Client player, String callbackId, int selectedIndex, String objectName, String valueList)
    {
        if(callbackId == "DMV_SCHOOL")
        {
            if(selectedIndex == 0)
            {
                if (player.GetData("character_car_lic") == 1)
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "Du hast schon einen Führerschein.");
                    return;
                }

                if (Main.GetPlayerMoney(player) < 1650)
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "Sie benötigen 1.650$, um einen PKW-Führerschein zu erhalten.");
                    return;
                }
                player.SetData("character_car_lic", 1);
                Main.GivePlayerMoney(player, -1650);
                NAPI.Notification.SendNotificationToPlayer(player, "Sie haben einen PKW-Führerschein für $1,650 erworben.");
            }
            else if (selectedIndex == 1)
            {
                if(Main.GetPlayerMoney(player) < 4000)
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "Sie benötigen 4.000$ für einen LKW-Führerschein.");
                    return;
                }

                if (player.GetData("character_truck_lic") == 1)
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "Sie haben bereits einen Führerschein.");
                    return;
                }

                if (player.GetData("character_car_lic") == 0)
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "Sie neötigen die Theorie, um einen Führerschein zu erwerben.");
                    return;
                }

                player.SetData("character_truck_lic", 1);
                Main.GivePlayerMoney(player, -4000);
                NAPI.Notification.SendNotificationToPlayer(player, "Sie haben einen LKW-Führerschein für $4,000 erworben.");
            }
            else if (selectedIndex == 2)
            {
                if (Main.GetPlayerMoney(player) < 25000)
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "Sie benötigen 25.000$ für einen Flugschein.");
                    return;
                }

                if (player.GetData("character_fly_lic") == 1)
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "Sie haben bereits einen Führerschein.");
                    return;
                }

                player.SetData("character_fly_lic", 1);
                Main.GivePlayerMoney(player, -25000);
                NAPI.Notification.SendNotificationToPlayer(player, "Sie haben einen Flugschein für $25,000 erworben.");
            }
            else if (selectedIndex == 3)
            {
                if (Main.GetPlayerMoney(player) < 1000)
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "Sie benötigen 1.000$ für einen Angelschein.");
                    return;
                }

                if (player.GetData("character_fish_lic") == 1)
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "Sie haben bereits einen Führerschein.");
                    return;
                }

                player.SetData("character_fish_lic", 1);
                Main.GivePlayerMoney(player, -1000);
                NAPI.Notification.SendNotificationToPlayer(player, "Sie haben einen Angelschein für $1,000 erworben.");
            }
            else if (selectedIndex == 4)
            {
                if (Main.GetPlayerMoney(player) < 15000)
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "Sie benötigen 10.000$ für einen Taxi Führerschein.");
                    return;
                }

                if (player.GetData("character_taxi_lic") == 1)
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "Sie haben bereits einen Führerschein.");
                    return;
                }

                if (player.GetData("character_car_lic") == 0)
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "Sie neötigen die Theorie, um einen Führerschein zu erwerben.");
                    return;
                }

                player.SetData("character_taxi_lic", 1);
                Main.GivePlayerMoney(player, -15000);
                NAPI.Notification.SendNotificationToPlayer(player, "Sie haben einen Taxi Führerschein für $15,000 erworben.");
            }
            else if (selectedIndex == 5)
            {
                if (Main.GetPlayerMoney(player) < 25000)
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "Sie benötigen 25.000$ für einen Waffenschein.");
                    return;
                }

                if (player.GetData("character_gun_lic") == 1)
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "Sie haben bereits einen Führerschein.");
                    return;
                }

                player.SetData("character_gun_lic", 1);
                Main.GivePlayerMoney(player, -25000);
                NAPI.Notification.SendNotificationToPlayer(player, "Sie haben einen Waffenschein für $25,000 erworben.");
            }
            else if (selectedIndex == 6)
            {
                if (Main.GetPlayerMoney(player) < 40000)
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "Sie benötigen 40.000$ für ein Anwaltliches Zertifikat.");
                    return;
                }

                if (player.GetData("character_lawyer_lic") == 1)
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "Sie haben bereits ein Anwaltliches Zertifikat.");
                    return;
                }

                player.SetData("character_lawyer_lic", 1);
                Main.GivePlayerMoney(player, -40000);
                NAPI.Notification.SendNotificationToPlayer(player, "Sie haben ein Anwaltliches Zertifikat für $40,000 erworben.");
            }
            else if (selectedIndex == 7)
            {
                if (Main.GetPlayerMoney(player) < 3000)
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "Sie benötigen 3.000$ für ein Motorrad-Führerschein.");
                    return;
                }

                if (player.GetData("character_cycles_lic") == 1)
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "Sie haben bereits ein Motorrad-Führerschein.");
                    return;
                }

                player.SetData("character_cycles_lic", 1);
                Main.GivePlayerMoney(player, -3000);
                NAPI.Notification.SendNotificationToPlayer(player, "Sie haben ein Motorrad-Führerschein für $3,000 erworben.");
            }
        }
    }


    public static void PlayerPressKeyE(Client player)
    {
        //if(Main.IsInRangeOfPoint(player.Position, new Vector3(-852.7932, -738.0178, 23.72642), 1))
        //{
        //    //Main.SendInfoMessage(player, "Do percurso " + player.GetData("school_in_stage") + " para " + (player.GetData("school_in_stage") + 1) + ".");
        //    player.SetData("school_in_stage", player.GetData("school_in_stage") + 1);
        //    player.TriggerEvent("DeleteRaceCheckpoint");
        //    player.TriggerEvent("CreateRaceCheckpoint", vehicle_rota[player.GetData("school_in_stage")].position - new Vector3(0, 0, 1.0), vehicle_rota[player.GetData("school_in_stage") + 1].position);

        //    school_checkpoint[Main.getIdFromClient(player)].Delete();
        //    school_checkpoint[Main.getIdFromClient(player)] = NAPI.ColShape.CreateCylinderColShape(vehicle_rota[player.GetData("school_in_stage")].position, 5.0f, 4.0f);
        //}
        //if(Main.IsInRangeOfPoint(player.Position, new Vector3(-830.2873, -795.3666, 20.23415), 1))
        //{
        //    //Main.DisplaySubtitle(player, "Sie haben den Kurs abgeschlossen.");
        //    //player.SetData("school_in_stage", 0);

        //    //school_checkpoint[Main.getIdFromClient(player)].Delete();
        //    //player.TriggerEvent("DeleteRaceCheckpoint");

        //    Main.ShowColorShard(player, "~g~Du hast den Test bestanden !", "Herzlichen Glückwunsch, Sie haben die ~y~A~w~ Prüfung erfolgreich bestanden. !", 0, 5, 7000);

        //    player.SetData("character_car_lic", 1);
        //    AccountManage.SaveCharacter(player);

        //    try
        //    {
        //        school_vehicle[Main.getIdFromClient(player)].Delete();
        //    }
        //    catch(Exception)
        //    {

        //    }
        //}
    }

    public static void OnEnterDynamicArea(Client player, ColShape area)
    {
        
        if(school_checkpoint[Main.getIdFromClient(player)] == area && player.GetData("school_in_stage") == 2 && player.GetData("school_in_teste") == 1 && player.IsInVehicle && NAPI.Entity.GetEntityModel(player.Vehicle) == (uint)VehicleHash.Dilettante && school_vehicle[Main.getIdFromClient(player)].Exists && player.Vehicle == player.Vehicle)
        {
            //você deve estacionar seu veículo no centro, em sentido inverso e deve ser estacionado em linha reta!
            Main.SendMessageWithTagToPlayer(player, "" + Main.EMBED_YELLOW + "[Ausbilder]", "Sie sollten Ihr Fahrzeug parken "+Main.EMBED_BLUE+"mitten"+Main.EMBED_WHITE+", auf dem Parkplatz "+Main.EMBED_LIGHTGREEN+"gerade linie"+Main.EMBED_WHITE+"!");
        }

        if (school_checkpoint[Main.getIdFromClient(player)] == area && player.GetData("school_in_stage") != 2 && player.GetData("school_in_teste") == 1 && player.IsInVehicle && NAPI.Entity.GetEntityModel(player.Vehicle) == (uint)VehicleHash.Dilettante && school_vehicle[Main.getIdFromClient(player)].Exists && player.Vehicle == player.Vehicle)
        {
            if (player.GetData("school_in_stage") == player.GetData("school_in_stages") - 1)
            {
                Main.SendMessageWithTagToPlayer(player, "" + Main.EMBED_YELLOW + "[Ausbilder]", "Sie sollten Ihr Fahrzeug parken " + Main.EMBED_BLUE + "mitten" + Main.EMBED_WHITE + ", Parken Sie Rückwärts ein " + Main.EMBED_LIGHTGREEN + "gerade linie" + Main.EMBED_WHITE + "!");
            }
            else
            {
                if(vehicle_rota[player.GetData("school_in_stage")].message == "stop")
                {
                    Main.SendMessageWithTagToPlayer(player, "" + Main.EMBED_YELLOW + "[Ausbilder]", "Sie sollten immer vor einem " + Main.EMBED_LIGHTRED + "Haltebreich" + Main.EMBED_WHITE + ", anhalten wenn die Straße nicht durch Ampeln gesteuert wird!");
                }
                else if (vehicle_rota[player.GetData("school_in_stage")].message == "vorwärts")
                {
                    Main.SendMessageWithTagToPlayer(player, "" + Main.EMBED_YELLOW + "[Ausbilder]", "Weiter vorwärts.");
                }
                else if (vehicle_rota[player.GetData("school_in_stage")].message == "vorbereiten Rechts")
                {
                    Main.SendMessageWithTagToPlayer(player, "" + Main.EMBED_YELLOW + "[Ausbilder]", "Geschwindigkeit runter regeln, bereiten Sie sich auf das Wechseln " + Main.EMBED_LIGHTGREEN + "richts" + Main.EMBED_WHITE + ".");
                }
                else if (vehicle_rota[player.GetData("school_in_stage")].message == "vorbereiten Links")
                {
                    Main.SendMessageWithTagToPlayer(player, "" + Main.EMBED_YELLOW + "[Ausbilder]", "Geschwindikeite runter regeln, bereiten Sie sich auf das Wechseln" + Main.EMBED_LIGHTGREEN + "links" + Main.EMBED_WHITE + ".");
                }
                else if (vehicle_rota[player.GetData("school_in_stage")].message == "links")
                {
                    Main.SendMessageWithTagToPlayer(player, "" + Main.EMBED_YELLOW + "[Ausbilder]", "Wende " + Main.EMBED_LIGHTGREEN + "links" + Main.EMBED_WHITE + ".");
                }
                else if (vehicle_rota[player.GetData("school_in_stage")].message == "rechts")
                {
                    Main.SendMessageWithTagToPlayer(player, "" + Main.EMBED_YELLOW + "[Ausbilder]", "Wende " + Main.EMBED_LIGHTGREEN + "rechts" + Main.EMBED_WHITE + ".");
                }
                else if (vehicle_rota[player.GetData("school_in_stage")].message == "bereiten Sie sich vor")
                {
                    Main.SendMessageWithTagToPlayer(player, "" + Main.EMBED_YELLOW + "[Ausbilder]", "Langsam werden und bereiten Sie auf den Parkvorgang  " + Main.EMBED_LIGHTGREEN + "richtig" + Main.EMBED_WHITE + ".");
                }


                if (player.GetData("school_in_stage") == 5)
                {
                    player.TriggerEvent("StopVehicle");
                    player.TriggerEvent("freezeVehicle", true);

                    Main.SendMessageWithTagToPlayer(player, "" + Main.EMBED_YELLOW + "[Ausbilder]", "Langsam vorbereiten auf dne " + Main.EMBED_LIGHTRED + "Stopbereich" + Main.EMBED_WHITE + "!");

                    NAPI.Task.Run(() =>
                    {
                        Main.SendMessageWithTagToPlayer(player, "" + Main.EMBED_YELLOW + "[Ausbilder]", "Einmal starten und umdrehen " + Main.EMBED_LIGHTRED + "richtig" + Main.EMBED_WHITE + ", und los gehts!");
                        player.TriggerEvent("freezeVehicle", false);
                    }, delayTime: 3000);
                }

                Main.DisplaySubtitle(player, "Prüf Punkt "+ player.GetData("school_in_stage") + " von "+ (player.GetData("school_in_stage") + 1) + ".");
                player.SetData("school_in_stage", player.GetData("school_in_stage") + 1);
                player.TriggerEvent("DeleteRaceCheckpoint");

                if (player.GetData("school_in_stage") + 1 == player.GetData("school_in_stages"))
                {
                    player.TriggerEvent("CreateRaceCheckpoint", vehicle_rota[player.GetData("school_in_stage")].position - new Vector3(0, 0, 1.0), vehicle_rota[player.GetData("school_in_stage")].position);
                }
                else
                {
                    player.TriggerEvent("CreateRaceCheckpoint", vehicle_rota[player.GetData("school_in_stage")].position - new Vector3(0, 0, 1.0), vehicle_rota[player.GetData("school_in_stage") + 1].position);
                }

                school_checkpoint[Main.getIdFromClient(player)].Delete();
                school_checkpoint[Main.getIdFromClient(player)] = NAPI.ColShape.CreateCylinderColShape(vehicle_rota[player.GetData("school_in_stage")].position, 5.0f, 4.0f);

                
            }
        }
    }
}

