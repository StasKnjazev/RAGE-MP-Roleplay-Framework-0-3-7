using System;
using System.Collections.Generic;
using GTANetworkAPI;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using DerStr1k3r.Core;
using DerStr1k3r.SDK;
class InteractMenu_New : Script
{
    private static string weaponName;
    public static bool MouseControl { get; private set; }
    public static string BackgroundColor { get; private set; }
    public static string BackgroundSprite { get; private set; }

    public static Vehicle vehicle { get; set; }
    //
    // Interact With Vehicle
    //
    [RemoteEvent("Display_InteractVehicle_Menu")]
    public void Display_InteractVehicle_Menu(Client player, Vehicle vehicle)
    {
        player.SetData("new_interact_menu_ticket", 1);
        player.SetData("new_interact_vehicle_assento", 0);

        int playerid = Main.getIdFromClient(player);
        List<dynamic> menu_item_list = new List<dynamic>();

        int pecas = 1;
        if (NAPI.Vehicle.GetVehicleHealth(vehicle) >= 900)
        {
            pecas = 1;
        }
        else if (NAPI.Vehicle.GetVehicleHealth(vehicle) >= 800 && NAPI.Vehicle.GetVehicleHealth(vehicle) <= 899)
        {
            pecas = 2;
        }
        else if (NAPI.Vehicle.GetVehicleHealth(vehicle) >= 700 && NAPI.Vehicle.GetVehicleHealth(vehicle) <= 799)
        {
            pecas = 3;
        }
        else if (NAPI.Vehicle.GetVehicleHealth(vehicle) >= 600 && NAPI.Vehicle.GetVehicleHealth(vehicle) <= 699)
        {
            pecas = 4;
        }
        else if (NAPI.Vehicle.GetVehicleHealth(vehicle) >= 500 && NAPI.Vehicle.GetVehicleHealth(vehicle) <= 599)
        {
            pecas = 5;
        }
        else
        {
            pecas = 7;
        }



        for (int index = 0; index < PlayerVehicle.MAX_PLAYER_VEHICLES; index++)
        {
            if (PlayerVehicle.vehicle_data[playerid].state[index] == 1 && PlayerVehicle.vehicle_data[playerid].handle[index].Exists && vehicle == PlayerVehicle.vehicle_data[playerid].handle[index])
            {
                menu_item_list.Add(new { Type = 5, Name = "Öffnen/Schließen", Description = "", IsTicked = NAPI.Vehicle.GetVehicleLocked(vehicle) });

            }
        }

        for (int i = 0; i < FactionManage.MAX_FACTION_VEHICLES; i++)
        {

            if (FactionManage.faction_data[AccountManage.GetPlayerGroup(player)].faction_vehicle_owned[i] != "Niemand" && FactionManage.faction_data[AccountManage.GetPlayerGroup(player)].faction_vehicle_entity[i] == vehicle)
            {
                menu_item_list.Add(new { Type = 5, Name = "Öffnen/Schließen", Description = "", IsTicked = NAPI.Vehicle.GetVehicleLocked(vehicle) });
            }
        }

        for (int b = 0; b < RentVehicle.MAX_RENT_VEHICLES; b++)
        {
            if (RentVehicle.vehicle_rent_list[b].vehicle_free == true && RentVehicle.vehicle_rent_list[b].vehicle_ownedBy == AccountManage.GetPlayerSQLID(player) && RentVehicle.vehicle_rent_list[b].vehicle_entity == vehicle)
            {
                menu_item_list.Add(new { Type = 5, Name = "Öffnen/Schließen", Description = "", IsTicked = NAPI.Vehicle.GetVehicleLocked(vehicle) });
            }
        }

        if (Inventory.GetPlayerItemFromInventory(player, 8) < pecas)
        {
            menu_item_list.Add(new { Type = 1, Name = "Fahrzeug reparieren", Description = "Du brauchst ~y~" + pecas + "~w~ Ersatzteile für die Reparatur.", RightBadge = "Lock" });
        }
        else
        {
            menu_item_list.Add(new { Type = 1, Name = "Fahrzeug reparieren", Description = "Du brauchst ~y~" + pecas + "~w~ Ersatzteile für die Reparatur." });
        }

        if (Inventory.GetPlayerItemFromInventory(player, 32) < 1)
        {
            menu_item_list.Add(new { Type = 1, Name = "Fahrzeug auftanken", Description = "Du brauchst einen Benzinkasten.", RightBadge = "Lock" });
        }
        else
        {
            menu_item_list.Add(new { Type = 1, Name = "Fahrzeug auftanken", Description = "Du brauchst einen Benzinkasten." });
        }

        List<dynamic> data = new List<dynamic>();

        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {
            Mainpipeline.Open();
            MySqlCommand query = new MySqlCommand("SELECT * FROM `vehicles` WHERE `vehicle_plate` = '" + data + "';", Mainpipeline);

            using (MySqlDataReader reader = query.ExecuteReader())
            {
                string data2txt = string.Empty;
                string datatxt = string.Empty;

                //var index = 0;
                while (reader.Read())
                {
                    string vehicle_plate = reader.GetString("vehicle_plate");
                    menu_item_list.Add(new { Type = 5, Name = "Kennzeichen", Description = reader.GetString("vehicle_plate"), RightLabel = "" });
                }
            }
        }

        if (NAPI.Data.HasEntityData(vehicle, "MAX_VEHICLE_SLOT"))
        {
            if (NAPI.Data.GetEntityData(vehicle, "MAX_VEHICLE_SLOT") > 0)
            {
                

                if (NAPI.Vehicle.GetVehicleLocked(vehicle) == true)
                {
                    menu_item_list.Add(new { Type = 1, Name = "Kofferraum", Description = "Dieses Fahrzeug ist gesperrt, so dass Sie nicht auf den Kofferraum zugreifen können.", RightBadge = "Lock" });
                }
                else
                {
                    menu_item_list.Add(new { Type = 1, Name = "Kofferraum", Description = "" });
                }
            }
        }


        if (NAPI.Entity.DoesEntityExist(vehicle))
        {
            if (NAPI.Data.HasEntityData(vehicle, "MAX_VEHICLE_SLOT"))
            {
                if (NAPI.Data.GetEntityData(vehicle, "MAX_VEHICLE_SLOT") > 0)
                {

                    if (NAPI.Vehicle.GetVehicleLocked(vehicle) == true)
                    {
                        menu_item_list.Add(new { Type = 1, Name = "In den Kofferraum schauen", Description = "Dieses Fahrzeug ist gesperrt, Sie können es jedoch nicht überprüfen!", RightBadge = "Locked" });
                    }
                    else
                    {
                        menu_item_list.Add(new { Type = 1, Name = "In den Kofferraum schauen", Description = "", RightBadge = "Car" });
                    }

                }
            }
        }

        if (FactionManage.GetPlayerGroupType(player) == 1 || AccountManage.GetPlayerGroup(player) == 25)
        {
            if (NAPI.Entity.DoesEntityExist(vehicle))
            {
                if (NAPI.Data.HasEntityData(vehicle, "MAX_VEHICLE_SLOT"))
                {
                    if (NAPI.Data.GetEntityData(vehicle, "MAX_VEHICLE_SLOT") > 0)
                    {

                        if (NAPI.Vehicle.GetVehicleLocked(vehicle) == true)
                        {
                            menu_item_list.Add(new { Type = 1, Name = "Fahrzeug durchsuchen", Description = "Dieses Fahrzeug ist gesperrt, Sie können es jedoch nicht überprüfen!", RightBadge = "Locked" });
                        }
                        else
                        {
                            menu_item_list.Add(new { Type = 1, Name = "Fahrzeug durchsuchen", Description = "", RightBadge = "Car" });
                        }

                    }
                }
            }
            bool can_pass = false;
            var players = NAPI.Pools.GetAllPlayers();
            List<string> list = new List<string>();

            foreach (var pl in players)
            {
                if (pl.GetData("status") == true)
                {
                    for (int index = 0; index < PlayerVehicle.MAX_PLAYER_VEHICLES; index++)
                    {
                        if (PlayerVehicle.vehicle_data[Main.getIdFromClient(pl)].state[index] == 1 && PlayerVehicle.vehicle_data[Main.getIdFromClient(pl)].handle[index].Exists && PlayerVehicle.vehicle_data[Main.getIdFromClient(pl)].handle[index] == vehicle)
                        {
                            can_pass = true;
                        }
                    }
                }
            }
            list.Clear();
            list.Add("Fahrer");
            list.Add("Passagier #0");
            list.Add("Passagier #1");
            list.Add("Passagier #2");
            list.Add("Passagier #3");

            menu_item_list.Add(new { Type = 2, Name = "Aus dem Fahrzeug ziehen", Description = "Bürger aus Fahrzeug ziehen.", List = list, StartIndex = player.GetData("new_interact_vehicle_assento") });


            if (can_pass == true)
            {

                menu_item_list.Add(new { Type = 1, Name = "Fahrzeug beschlagnahmen", Description = "Bürger kann sich Fahrzeug bei der ACLS Garage abholen." });


                list.Clear();
                list.Add("500");
                list.Add("1000");
                list.Add("1500");
                list.Add("2000");
                list.Add("2500");
                list.Add("3000");
                list.Add("3500");
                list.Add("4000");
                list.Add("4500");
                list.Add("5000");
                list.Add("5500");
                list.Add("6000");
                list.Add("6500");
                list.Add("7000");
                list.Add("7500");
                list.Add("8000");
                list.Add("8500");
                list.Add("9000");
                list.Add("9500");
                list.Add("10000");

                menu_item_list.Add(new { Type = 2, Name = "KFZ Strafe", Description = "", List = list, StartIndex = player.GetData("new_interact_menu_ticket") });
            }
            else
            {
                menu_item_list.Add(new { Type = 1, Name = "KFZ Strafe", Description = "Stellen Sie einen Strafzettel aus.", RightBadge = "Lock" });
            }
        }

        player.SetData("InteractMenu_vehicle_handle", vehicle);
        InteractMenu.CreateMenu(player, "NEW_MENU_VEHICLE_RESPONSE", "Fahrzeug Menü", "~g~" + vehicle.DisplayName, false, JsonConvert.SerializeObject(menu_item_list), false, BackgroundColor: "Green");
    }

    public static void Responder_Vehicle_Menu(Client player, int selectedIndex, String objectName, String valueList)
    {
        if (objectName == "Kofferraum")
        {

            Vehicle vehicle = NAPI.Data.GetEntityData(player, "InteractMenu_vehicle_handle");
            if (!vehicle.Exists)
            {
                SendNotificationError(player, "Dieses Fahrzeug existiert nicht mehr.");
                return;
            }
            if (!Main.IsInRangeOfPoint(player.Position, vehicle.Position, 5.0f))
            {
                SendNotificationError(player, "Sie sind zuweit vom Fahrzeug entfernt.");
                return;
            }
            if (vehicle.Locked == true)
            {
                SendNotificationError(player, "Der Kofferraum des Fahrzeugs ist geschlossen, so dass Sie nicht darauf zugreifen können!");
                return;
            }
            VehicleInventory.ShowToPlayerVehicleInventory(player);
        }
        else if (objectName == "Aufschließen")
        {

            Vehicle vehicle = NAPI.Data.GetEntityData(player, "InteractMenu_vehicle_handle");
            if (!vehicle.Exists)
            {
                SendNotificationError(player, "Dieses Fahrzeug existiert nicht mehr.");
                return;
            }
            if (!Main.IsInRangeOfPoint(player.Position, vehicle.Position, 5.0f))
            {
                SendNotificationError(player, "Sie sind zuweit vom Fahrzeug entfernt.");
                return;
            }
            Main.CMD_VehLocked(player);
        }
        else if (objectName == "Abschließen")
        {

            Vehicle vehicle = NAPI.Data.GetEntityData(player, "InteractMenu_vehicle_handle");
            if (!vehicle.Exists)
            {
                SendNotificationError(player, "Dieses Fahrzeug existiert nicht mehr.");
                return;
            }
            if (!Main.IsInRangeOfPoint(player.Position, vehicle.Position, 5.0f))
            {
                SendNotificationError(player, "Sie sind zuweit vom Fahrzeug entfernt.");
                return;
            }
            Main.CMD_VehLocked(player);
        }
        else if (objectName == "Fahrzeug beschlagnahmen")
        {
            Vehicle vehicle = NAPI.Data.GetEntityData(player, "InteractMenu_vehicle_handle");
            if (!vehicle.Exists)
            {
                SendNotificationError(player, "Dieses Fahrzeug existiert nicht mehr.");
                return;
            }
            if (!Main.IsInRangeOfPoint(player.Position, vehicle.Position, 5.0f))
            {
                SendNotificationError(player, "Sie sind vom Fahrzeug weggetreten.");
                return;
            }

            foreach (var pl in NAPI.Pools.GetAllPlayers())
            {
                if (pl.GetData("status") == true)
                {
                    for (int index = 0; index < PlayerVehicle.MAX_PLAYER_VEHICLES; index++)
                    {
                        if (PlayerVehicle.vehicle_data[Main.getIdFromClient(pl)].state[index] == 1 && PlayerVehicle.vehicle_data[Main.getIdFromClient(pl)].handle[index].Exists && PlayerVehicle.vehicle_data[Main.getIdFromClient(pl)].handle[index] == vehicle)
                        {

                            if (PlayerVehicle.vehicle_data[Main.getIdFromClient(pl)].state[index] == 1)
                            {
                                if (PlayerVehicle.vehicle_data[Main.getIdFromClient(pl)].handle[index].Exists) NAPI.Entity.DeleteEntity(PlayerVehicle.vehicle_data[Main.getIdFromClient(pl)].handle[index]);
                                PlayerVehicle.vehicle_data[Main.getIdFromClient(pl)].handle[index] = null;
                                PlayerVehicle.vehicle_data[Main.getIdFromClient(pl)].state[index] = 0;

                                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie haben dieses Fahrzeug beschlagnahmt.", 5000);
                                Notify.Send(pl, NotifyType.Info, NotifyPosition.BottomCenter, $"Das LSPD hat ihr Fahrzeug beschlagnahmt.", 5000);
                                //pl.SendNotification("Das LSPD hat ihr Fahrzeug beschlagnahmt.", 5000);
                            }
                        }
                    }
                }
            }
        }
        else if (objectName == "Aus dem Fahrzeug ziehen")
        {
            Vehicle vehicle = NAPI.Data.GetEntityData(player, "InteractMenu_vehicle_handle");
            if (!vehicle.Exists)
            {
                SendNotificationError(player, "Dieses Fahrzeug existiert nicht mehr.");
                return;
            }
            if (!Main.IsInRangeOfPoint(player.Position, vehicle.Position, 5.0f))
            {
                SendNotificationError(player, "Sie sind zu weit vom Fahrzeug entfernt..");
                return;
            }

            int assento = player.GetData("new_interact_menu_ticket");

            foreach (var target in NAPI.Pools.GetAllPlayers())
            {

                if (target.GetData("status") == true && target.GetData("status") == true)
                {
                    if (target.IsInVehicle && vehicle == target.Vehicle)
                    {
                        if (target.VehicleSeat == assento - 1)
                        {
                            target.WarpOutOfVehicle();
                            SendNotificationInfo(target, "Der Polizist hat Sie aus dem Fahrzeug gezogen..");
                            SendNotificationInfo(target, "Sie haben den Bürger aus dem Fahrzeug gezogen.");
                            return;
                        }
                    }
                }
                SendNotificationError(target, "Nein, niemand auf diesem Platz.");
            }

            return;
        }
        else if (objectName == "In den Kofferraum schauen")
        {

            Vehicle vehicle = NAPI.Data.GetEntityData(player, "InteractMenu_vehicle_handle");
            if (!vehicle.Exists)
            {
                SendNotificationError(player, "Dieses Fahrzeug existiert nicht mehr.");
                return;
            }
            if (!Main.IsInRangeOfPoint(player.Position, vehicle.Position, 5.0f))
            {
                SendNotificationError(player, "Sie sind zu weit vom Fahrzeug entfernt..");
                return;
            }

            if (NAPI.Entity.DoesEntityExist(vehicle))
            {
                if (NAPI.Data.HasEntityData(vehicle, "MAX_VEHICLE_SLOT"))
                {
                    if (NAPI.Data.GetEntityData(vehicle, "MAX_VEHICLE_SLOT") > 0)
                    {
                        if (NAPI.Vehicle.GetVehicleLocked(vehicle) == true)
                        {
                            SendNotificationError(player, "Das Fahrzeug ist verschlossen und kann nicht durchsucht werden.");
                            return;
                        }

                        List<dynamic> menu_item_list = new List<dynamic>();
                        int count = 0;
                        for (int i = 0; i < 30; i++)
                        {
                            if (NAPI.Data.GetEntityData(vehicle, "trunk_item_" + i + "_type") != 0)
                            {
                                if (NAPI.Data.GetEntityData(vehicle, "trunk_item_" + i + "_amount") > 0)
                                {
                                    menu_item_list.Add(new { Type = 1, Name = count + ". " + Inventory.itens_available[NAPI.Data.GetEntityData(vehicle, "trunk_item_" + i + "_type")].name, Description = "", RightLabel = NAPI.Data.GetEntityData(vehicle, "trunk_item_" + i + "_amount") });
                                    count++;
                                }
                            }
                        }
                        if (count == 0)
                        {
                            SendNotificationError(player, "Kofferraum leer.");
                        }
                        InteractMenu.CreateMenu(player, "NOTHING_HAPPENS", "Inventar", "~g~Inventar von " + vehicle.DisplayName, false, JsonConvert.SerializeObject(menu_item_list), false, BackgroundColor: "Green");

                        return;
                    }
                }
            }
        }
        else if (objectName == "Fahrzeug durchsuchen")
        {

            Vehicle vehicle = NAPI.Data.GetEntityData(player, "InteractMenu_vehicle_handle");
            if (!vehicle.Exists)
            {
                SendNotificationError(player, "Dieses Fahrzeug existiert nicht mehr.");
                return;
            }
            if (!Main.IsInRangeOfPoint(player.Position, vehicle.Position, 5.0f))
            {
                SendNotificationError(player, "Sie sind zu weit vom Fahrzeug entfernt..");
                return;
            }

            if (NAPI.Entity.DoesEntityExist(vehicle))
            {
                if (NAPI.Data.HasEntityData(vehicle, "MAX_VEHICLE_SLOT"))
                {
                    if (NAPI.Data.GetEntityData(vehicle, "MAX_VEHICLE_SLOT") > 0)
                    {
                        if (NAPI.Vehicle.GetVehicleLocked(vehicle) == true)
                        {
                            SendNotificationError(player, "Das Fahrzeug ist verschlossen und kann nicht durchsucht werden.");
                            return;
                        }

                        List<dynamic> menu_item_list = new List<dynamic>();
                        int count = 0;
                        for (int i = 0; i < 30; i++)
                        {
                            if (NAPI.Data.GetEntityData(vehicle, "trunk_item_" + i + "_type") != 0)
                            {
                                if (NAPI.Data.GetEntityData(vehicle, "trunk_item_" + i + "_amount") > 0)
                                {
                                    menu_item_list.Add(new { Type = 1, Name = count + ". " + Inventory.itens_available[NAPI.Data.GetEntityData(vehicle, "trunk_item_" + i + "_type")].name, Description = "", RightLabel = NAPI.Data.GetEntityData(vehicle, "trunk_item_" + i + "_amount") });
                                    count++;
                                }
                            }
                        }
                        if (count == 0)
                        {
                            SendNotificationError(player, "Kofferraum leer.");
                        }
                        InteractMenu.CreateMenu(player, "NOTHING_HAPPENS", "Inventar", "~g~Inventar von " + vehicle.DisplayName, false, JsonConvert.SerializeObject(menu_item_list), false, BackgroundColor: "Green");

                        return;
                    }
                }
            }
        }
        else if (objectName == "KFZ Strafe")
        {

            Vehicle vehicle = NAPI.Data.GetEntityData(player, "InteractMenu_vehicle_handle");
            if (!vehicle.Exists)
            {
                SendNotificationError(player, "Dieses Fahrzeug existiert nicht mehr.");
                return;
            }
            if (!Main.IsInRangeOfPoint(player.Position, vehicle.Position, 5.0f))
            {
                SendNotificationError(player, "Sie sind zu weit vom Fahrzeug entfernt..");
                return;
            }

            var players = NAPI.Pools.GetAllPlayers();
            foreach (var pl in players)
            {
                if (pl.GetData("status") == true)
                {
                    for (int index = 0; index < PlayerVehicle.MAX_PLAYER_VEHICLES; index++)
                    {
                        if (PlayerVehicle.vehicle_data[Main.getIdFromClient(pl)].state[index] == 1 && PlayerVehicle.vehicle_data[Main.getIdFromClient(pl)].handle[index].Exists && PlayerVehicle.vehicle_data[Main.getIdFromClient(pl)].handle[index] == vehicle)
                        {
                            int preco = (player.GetData("new_interact_menu_ticket") + 1) * 500;
                            SendNotificationSuccess(player, "Sie haben einen Strafzettel in höhe von ~g~$" + preco.ToString("N0") + "~w~ no " + PlayerVehicle.vehicle_data[Main.getIdFromClient(pl)].handle[index].DisplayName + " ausgestellt ~b~" + PlayerVehicle.vehicle_data[Main.getIdFromClient(pl)].plate[index] + "~w~.");
                            NAPI.Notification.SendNotificationToPlayer(pl, "Ihr Fahrzeug ~c~(" + PlayerVehicle.vehicle_data[Main.getIdFromClient(player)].model[index] + ")~w~ mit dem Kennzeichen hat einen ~y~" + Convert.ToString(PlayerVehicle.vehicle_data[Main.getIdFromClient(pl)].plate[index]) + "~w~ Straffzettel ~g~$" + preco.ToString("N0") + "~w~ pelo oficial " + AccountManage.GetCharacterName(player) + "~w~.");
                            PlayerVehicle.vehicle_data[Main.getIdFromClient(pl)].ticket[index] = preco;
                            PlayerVehicle.SavePlayerVehicle(pl, index);
                            return;
                        }
                    }
                }
            }
        }
        else if (objectName == "Fahrzeug auftanken")
        {

            Vehicle vehicle = NAPI.Data.GetEntityData(player, "InteractMenu_vehicle_handle");

            if (!vehicle.Exists)
            {
                SendNotificationError(player, "Dieses Fahrzeug existiert nicht mehr.");
                return;
            }
            if (!Main.IsInRangeOfPoint(player.Position, vehicle.Position, 5.0f))
            {
                SendNotificationError(player, "Sie sind zu weit vom Fahrzeug entfernt..");
                return;
            }


            if (NAPI.Entity.DoesEntityExist(vehicle))
            {
                if (player.GetData("vehicle_fuel") > 79)
                {
                    SendNotificationError(player, "Dieses Fahrzeug ist bereits voll!");
                    return;
                }
                if (Inventory.GetPlayerItemFromInventory(player, 46) < 1)
                {
                    SendNotificationError(player, "Du brauchst ~b~1~w~ Benzinkanister zum Auftanken.");
                    return;
                }


                if (!player.IsInVehicle)
                {
                    if (NAPI.Entity.DoesEntityExist(vehicle))
                    {
                        Inventory.RemoveItemByType(player, 46, 1);
                        Main.SetVehicleFuel(vehicle, Main.GetVehicleFuel(vehicle) + 20.0);
                        SendNotificationSuccess(player, "Sie haben in dieses Fahrzeug „Benzin“ gefüllt.");
                    }
                    else SendNotificationError(player, "Sie sind nicht in der Nähe eines Fahrzeugs.");
                }
            }
            else SendNotificationError(player, "Sie sind nicht in der Nähe eines Fahrzeugs.");

        }
        else if (objectName == "Fahrzeug reparieren")
        {
            Vehicle vehicle = NAPI.Data.GetEntityData(player, "InteractMenu_vehicle_handle");

            if (!vehicle.Exists)
            {
                SendNotificationError(player, "Dieses Fahrzeug existiert nicht mehr.");
                return;
            }
            if (!Main.IsInRangeOfPoint(player.Position, vehicle.Position, 5.0f))
            {
                SendNotificationError(player, "Sie sind zu weit vom Fahrzeug entfernt..");
                return;
            }

            if (NAPI.Entity.DoesEntityExist(vehicle))
            {
                if (NAPI.Vehicle.GetVehicleHealth(vehicle) < 300 && !Main.IsInRangeOfPoint(player.Position, new Vector3(490.1718, -1333.338, 29.33208), 7.0f))
                {
                    SendNotificationError(player, "Dieses Fahrzeug hat einen Totalschaden.");
                    return;
                }

                if (NAPI.Data.HasEntityData(vehicle, "vehicle_repairing"))
                {
                    if (NAPI.Data.GetEntityData(vehicle, "vehicle_repairing") == true)
                    {
                        SendNotificationError(player, "Dieses Fahrzeug wird zu diesem Zeitpunkt bereits repariert.");
                        return;
                    }
                }

                int pecas = 1;
                if (NAPI.Vehicle.GetVehicleHealth(vehicle) >= 900)
                {
                    pecas = 1;
                }
                else if (NAPI.Vehicle.GetVehicleHealth(vehicle) >= 800 && NAPI.Vehicle.GetVehicleHealth(vehicle) <= 899)
                {
                    pecas = 2;
                }
                else if (NAPI.Vehicle.GetVehicleHealth(vehicle) >= 700 && NAPI.Vehicle.GetVehicleHealth(vehicle) <= 799)
                {
                    pecas = 3;
                }
                else if (NAPI.Vehicle.GetVehicleHealth(vehicle) >= 600 && NAPI.Vehicle.GetVehicleHealth(vehicle) <= 699)
                {
                    pecas = 4;
                }
                else if (NAPI.Vehicle.GetVehicleHealth(vehicle) >= 500 && NAPI.Vehicle.GetVehicleHealth(vehicle) <= 599)
                {
                    pecas = 5;
                }
                else
                {
                    pecas = 7;
                }

                if (Inventory.GetPlayerItemFromInventory(player, 8) < pecas)
                {
                    SendNotificationError(player, "Du benötigst " + pecas + "~w~ Teile, um dieses Fahrzeug zu reparieren, Sie haben nur " + Inventory.GetPlayerItemFromInventory(player, 8) + " Ersatzteile.");
                    return;
                }

                if (!player.IsInVehicle)
                {

                    if (NAPI.Entity.DoesEntityExist(vehicle))
                    {
                        int time = 10;
                        Main.DisplaySubtitle(player, "~y~Fahrzeug reparieren " + time + "~y~ ...", 1);

                        player.StopAnimation();
                        NAPI.Player.PlayPlayerAnimation(player, 33, "mini@repair", "fixing_a_ped");

                        NAPI.Data.SetEntityData(vehicle, "vehicle_repairing", true);
                        TimerEx repairTimer = null;
                        repairTimer = TimerEx.SetTimer(() =>
                        {

                            time--;
                            Main.DisplaySubtitle(player, "~y~Fahrzeug reparieren " + time + "~y~ ...", 1);

                            if (NAPI.Vehicle.GetVehicleHealth(vehicle) < 100)
                            {
                                repairTimer.Kill();
                                player.StopAnimation();
                                Main.DisplaySubtitle(player, "Farhzeug repariert~w~ !", 1);
                                NAPI.Data.SetEntityData(vehicle, "vehicle_repairing", false);
                                return;
                            }

                            if (!Main.IsInRangeOfPoint(player.Position, NAPI.Entity.GetEntityPosition(vehicle), 3.0f))
                            {
                                repairTimer.Kill();
                                player.StopAnimation();
                                Main.DisplaySubtitle(player, "~y~Reparatur abgebrochen.", 1);
                                NAPI.Data.SetEntityData(vehicle, "vehicle_repairing", false);
                                return;
                            }

                            if (Inventory.GetPlayerItemFromInventory(player, 8) < pecas)
                            {
                                repairTimer.Kill();
                                player.StopAnimation();
                                Main.DisplaySubtitle(player, "~y~Keine Ersatzteile mehr, Reparatur abgebrochen.", 1);
                                NAPI.Data.SetEntityData(vehicle, "vehicle_repairing", false);
                                return;
                            }

                            if (time == 0)
                            {
                                NAPI.Data.SetEntityData(vehicle, "vehicle_repairing", false);
                                Inventory.RemoveItemByType(player, 8, pecas);

                                //NAPI.Vehicle.SetVehicleDoorState(vehicle, 4, false);
                                repairTimer.Kill();
                                NAPI.Vehicle.RepairVehicle(vehicle);
                                player.StopAnimation();
                                Main.DisplaySubtitle(player, "~g~Fahrzeug erfolgreich repariert!", 1);
                                SendNotificationSuccess(player, "Fahrzeug erfolgreich repariert.");
                            }
                        }, 1000, 0);

                    }
                    else SendNotificationError(player, "Sie sind nicht in der Nähe eines Fahrzeugs.");
                }
            }
            else SendNotificationError(player, "Sie sind nicht in der Nähe eines Fahrzeugs.");
        }
    }


    //
    // Interact With Vehicle
    //
    [RemoteEvent("Display_InteractPlayer_Menu")]
    public void Display_InteractPlayer_Menu(Client player, Client target)
    {
        player.SetData("new_interact_menu_ticket_player", 0);
        player.SetData("new_interact_menu_arrest", 0);
        player.SetData("new_interact_menu_healing", 0);
        player.SetData("new_interact_menu_seat", 0);
        List<dynamic> menu_item_list = new List<dynamic>();

        // Player
        menu_item_list.Add(new { Type = 1, Name = "Geld geben", Description = "" });
        menu_item_list.Add(new { Type = 1, Name = "Online Überweisung", Description = "" });
        menu_item_list.Add(new { Type = 1, Name = "Ausweis zeigen", Description = "" });
        menu_item_list.Add(new { Type = 1, Name = "Lizenzen zeigen", Description = "" });

        if (FactionManage.GetPlayerGroupType(player) == 1)
        {
            menu_item_list.Add(new { Type = 1, Name = "Cop Ausweis zeigen", Description = "" });
        }
        if (FactionManage.GetPlayerGroupType(player) == 2)
        {
            menu_item_list.Add(new { Type = 1, Name = "Medic Ausweis zeigen", Description = "" });
        }
        if (FactionManage.GetPlayerGroupType(player) == 14)
        {
            menu_item_list.Add(new { Type = 1, Name = "President Ausweis zeigen", Description = "" });
        }
        if (AccountManage.GetPlayerGroup(player) == 25)
        {
            menu_item_list.Add(new { Type = 1, Name = "FIB Ausweis zeigen", Description = "" });
        }
        if (AccountManage.GetPlayerGroup(player) == 16)
        {
            menu_item_list.Add(new { Type = 1, Name = "DoJ Ausweis zeigen", Description = "" });
        }

        menu_item_list.Add(new { Type = 1, Name = "Haus Schlüssel übergeben", Description = "Hiermit kannst du ein Zweitschlüssel deines Hauses übergeben" });

        // Police 
        List<string> list = new List<string>();

        if (FactionManage.GetPlayerGroupType(player) == 1)
        {
            if (target.GetData("playerCuffed") == 0)
            {
                menu_item_list.Add(new { Type = 1, Name = "Handschellen anlegen", Description = "" });
            }
            else menu_item_list.Add(new { Type = 1, Name = "Handschellen ablegen", Description = "" });

            //menu_item_list.Add(new { Type = 1, Name = "Drogen beschlagnahmen", Description = "" });
            menu_item_list.Add(new { Type = 1, Name = "Waffen beschlagnahmen", Description = "" });
            menu_item_list.Add(new { Type = 1, Name = "Bürger durchsuchen", Description = "" });
            
            list.Clear();
            list.Add("500");
            list.Add("1000");
            list.Add("1500");
            list.Add("2000");
            list.Add("2500");
            list.Add("3000");
            list.Add("3500");
            list.Add("4000");
            list.Add("4500");
            list.Add("5000");
            list.Add("5500");
            list.Add("6000");
            list.Add("6500");
            list.Add("7000");
            list.Add("7500");
            list.Add("8000");
            list.Add("8500");
            list.Add("9000");
            list.Add("9500");
            list.Add("10000");
            list.Add("20000");
            list.Add("30000");
            list.Add("40000");
            list.Add("50000");

            menu_item_list.Add(new { Type = 2, Name = "Geldstrafe", Description = "", List = list, StartIndex = player.GetData("new_interact_menu_ticket_player") });
            menu_item_list.Add(new { Type = 1, Name = "Eintrag in die Strafakte", Description = "" });

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
                menu_item_list.Add(new { Type = 2, Name = "Ins Prison stecken", Description = "", List = list, StartIndex = player.GetData("new_interact_menu_arrest") });
            }
            else
            {
                menu_item_list.Add(new { Type = 1, Name = "Ins Prison stecken", Description = "Um jemanden ins Gefängnis zu stecken, erst Eintrag in Strafakte.", RightBadge = "Lock" });
            }
        }
        // Gang
        if (AccountManage.GetPlayerGroup(player) == 25)
        {
            if (target.GetData("playerCuffed") == 0)
            {
                menu_item_list.Add(new { Type = 1, Name = "Handschellen anlegen", Description = "" });
            }
            else menu_item_list.Add(new { Type = 1, Name = "Handschellen ablegen", Description = "" });

            //menu_item_list.Add(new { Type = 1, Name = "Drogen beschlagnahmen", Description = "" });
            menu_item_list.Add(new { Type = 1, Name = "Waffen beschlagnahmen", Description = "" });
            menu_item_list.Add(new { Type = 1, Name = "Bürger durchsuchen", Description = "" });

            list.Clear();
            list.Add("500");
            list.Add("1000");
            list.Add("1500");
            list.Add("2000");
            list.Add("2500");
            list.Add("3000");
            list.Add("3500");
            list.Add("4000");
            list.Add("4500");
            list.Add("5000");
            list.Add("5500");
            list.Add("6000");
            list.Add("6500");
            list.Add("7000");
            list.Add("7500");
            list.Add("8000");
            list.Add("8500");
            list.Add("9000");
            list.Add("9500");
            list.Add("10000");
            list.Add("20000");
            list.Add("30000");
            list.Add("40000");
            list.Add("50000");

            menu_item_list.Add(new { Type = 2, Name = "Geldstrafe", Description = "", List = list, StartIndex = player.GetData("new_interact_menu_ticket_player") });
            menu_item_list.Add(new { Type = 1, Name = "Eintrag in die Strafakte", Description = "" });

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
                menu_item_list.Add(new { Type = 2, Name = "Ins Prison stecken", Description = "", List = list, StartIndex = player.GetData("new_interact_menu_arrest") });
            }
            else
            {
                menu_item_list.Add(new { Type = 1, Name = "Ins Prison stecken", Description = "Um jemanden ins Gefängnis zu stecken, erst Eintrag in Strafakte.", RightBadge = "Lock" });
            }
        }
        //if (FactionManage.GetPlayerGroupType(player) == 4)
        //{
        if (target.GetData("handsup") == false)
            {
                menu_item_list.Add(new { Type = 1, Name = "Bürger ausrauben", Description = "Bürger muss um ausgeraubt zu werden, Hände hoch halten", RightBadge = "Lock" });
            }
            else menu_item_list.Add(new { Type = 1, Name = "Bürger ausrauben", Description = "" });
        //}

        if (FactionManage.GetPlayerGroupType(player) == 2)
        {
            // Sammu
            list.Clear();
            list.Add("Automatisch");
            for (int i = 0; i < 1000; i++) list.Add("$" + i + "");
            menu_item_list.Add(new { Type = 2, Name = "Heilen", Description = "", List = list, StartIndex = player.GetData("new_interact_menu_healing") });

            if (target.GetSharedData("Injured") == 1)
            {
                menu_item_list.Add(new { Type = 1, Name = "Wiederbeleben", Description = "" });
            }
            else menu_item_list.Add(new { Type = 1, Name = "Wiederbeleben", Description = "", RightBadge = "Lock" });
        }

        if (AccountManage.GetPlayerLeader(player) != 0)
        {
            // Leader
            menu_item_list.Add(new { Type = 1, Name = "In die Fraktion Einladen", Description = "" });
            menu_item_list.Add(new { Type = 1, Name = "Aus der Fraktion entlassen", Description = "" });
        }
        InteractMenu.CreateMenu(player, "TARGET_MENU_RESPONSE", "Interaktion", "~g~Interagieren", false, JsonConvert.SerializeObject(menu_item_list), false, BackgroundColor: "Green");

        player.SetData("interact_target", target);
    }

    public static void Responder_Target_Menu(Client player, int selectedIndex, String objectName, String valueList)
    {
        Client target = NAPI.Data.GetEntityData(player, "interact_target");

        if (!API.Shared.IsPlayerConnected(target))
        {
            SendNotificationError(player, "Bürger ist nicht da.");
            return;
        }
        if (target.GetData("status") == false)
        {
            SendNotificationError(player, "Bürger ist nicht da.");
            return;
        }
        if (!Main.IsInRangeOfPoint(player.Position, target.Position, 5.0f))
        {
            SendNotificationError(player, "Sie sind zu weit vom Bürger entfernt..");
            return;
        }


        int targetid = Main.getIdFromClient(target);

        if (objectName == "Geld geben")
        {
            player.SetData("UserMenuToTarget_handle", target);
            player.SetData("UserMenuToTarget_name", AccountManage.GetCharacterName(target));
            InteractMenu.User_Input(player, "responser_money_user", "Geld geben", "", "Wählen Sie einen Betrag für den ausgewählten Spieler", "number");
        }
        else if (objectName == "Online Überweisung")
        {
            player.SetData("UserMenuToTarget_handle", target);
            player.SetData("UserMenuToTarget_name", AccountManage.GetCharacterName(target));
            InteractMenu.User_Input(player, "responser_money_to_user_bank", "Online Überweisung", "", "Geben Sie einen Betrag für die Online Überweisung ein", "number");
        }
        else if (objectName == "Fahrzeug Verkauf")
        {
            player.SetData("UserMenuToTarget_handle", target);
            player.SetData("UserMenuToTarget_name", AccountManage.GetCharacterName(target));
            InteractMenu.User_Input(player, "responser_sell_vehicle", "Fahrzeug Verkauf", "", "Geben Sie einen Betrag für den Fahrzeug Verkauf ein", "number");
        }
        else if (objectName == "Ausweis zeigen")
        {
            ShowPlayerIDCard(player, target);

            // Main.ShowPlayerStats(player, target);
            List<Client> proxPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(15, player);
            foreach (Client alvo in proxPlayers)
            {
                //NAPI.Notification.SendNotificationToPlayer(alvo, "" + UsefullyRP.GetPlayerNameToTarget(player, alvo) + " zeigt seinen Ausweis " + UsefullyRP.GetPlayerNameToTarget(target, alvo) + ".");
                //alvo.TriggerEvent("Send_ToChat", "", "<font color ='#C2A2DA'>* " + UsefullyRP.GetPlayerNameToTarget(player, alvo) + " zeigt seinen Ausweis " + UsefullyRP.GetPlayerNameToTarget(target, alvo) + ".");
            }
        }
        else if (objectName == "Cop Ausweis zeigen")
        {
            ShowPlayerFactionIDCard(player, target);

            // Main.ShowPlayerStats(player, target);
            List<Client> proxPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(15, player);
            foreach (Client alvo in proxPlayers)
            {
                //NAPI.Notification.SendNotificationToPlayer(alvo, "" + UsefullyRP.GetPlayerNameToTarget(player, alvo) + " zeigt seinen Dienstausweis " + UsefullyRP.GetPlayerNameToTarget(target, alvo) + ".");
                //alvo.TriggerEvent("Send_ToChat", "", "<font color ='#C2A2DA'>* " + UsefullyRP.GetPlayerNameToTarget(player, alvo) + " zeigt seinen Ausweis " + UsefullyRP.GetPlayerNameToTarget(target, alvo) + ".");
            }
        }
        else if (objectName == "Medic Ausweis zeigen")
        {
            ShowPlayerFactionIDCard(player, target);

            // Main.ShowPlayerStats(player, target);
            List<Client> proxPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(15, player);
            foreach (Client alvo in proxPlayers)
            {
                //NAPI.Notification.SendNotificationToPlayer(alvo, "" + UsefullyRP.GetPlayerNameToTarget(player, alvo) + " zeigt seinen Dienstausweis " + UsefullyRP.GetPlayerNameToTarget(target, alvo) + ".");
                //alvo.TriggerEvent("Send_ToChat", "", "<font color ='#C2A2DA'>* " + UsefullyRP.GetPlayerNameToTarget(player, alvo) + " zeigt seinen Ausweis " + UsefullyRP.GetPlayerNameToTarget(target, alvo) + ".");
            }
        }
        else if (objectName == "President Ausweis zeigen")
        {
            ShowPlayerFactionIDCard(player, target);

            // Main.ShowPlayerStats(player, target);
            List<Client> proxPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(15, player);
            foreach (Client alvo in proxPlayers)
            {
                //NAPI.Notification.SendNotificationToPlayer(alvo, "" + UsefullyRP.GetPlayerNameToTarget(player, alvo) + " zeigt seinen Dienstausweis " + UsefullyRP.GetPlayerNameToTarget(target, alvo) + ".");
                //alvo.TriggerEvent("Send_ToChat", "", "<font color ='#C2A2DA'>* " + UsefullyRP.GetPlayerNameToTarget(player, alvo) + " zeigt seinen Ausweis " + UsefullyRP.GetPlayerNameToTarget(target, alvo) + ".");
            }
        }
        else if (objectName == "FIB Ausweis zeigen")
        {
            ShowPlayerFactionIDCard(player, target);

            // Main.ShowPlayerStats(player, target);
            List<Client> proxPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(15, player);
            foreach (Client alvo in proxPlayers)
            {
                //NAPI.Notification.SendNotificationToPlayer(alvo, "" + UsefullyRP.GetPlayerNameToTarget(player, alvo) + " zeigt seinen Dienstausweis " + UsefullyRP.GetPlayerNameToTarget(target, alvo) + ".");
                //alvo.TriggerEvent("Send_ToChat", "", "<font color ='#C2A2DA'>* " + UsefullyRP.GetPlayerNameToTarget(player, alvo) + " zeigt seinen Ausweis " + UsefullyRP.GetPlayerNameToTarget(target, alvo) + ".");
            }
        }
        else if (objectName == "DoJ Ausweis zeigen")
        {
            ShowPlayerFactionIDCard(player, target);

            // Main.ShowPlayerStats(player, target);
            List<Client> proxPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(15, player);
            foreach (Client alvo in proxPlayers)
            {
                //NAPI.Notification.SendNotificationToPlayer(alvo, "" + UsefullyRP.GetPlayerNameToTarget(player, alvo) + " zeigt seinen Dienstausweis " + UsefullyRP.GetPlayerNameToTarget(target, alvo) + ".");
                //alvo.TriggerEvent("Send_ToChat", "", "<font color ='#C2A2DA'>* " + UsefullyRP.GetPlayerNameToTarget(player, alvo) + " zeigt seinen Ausweis " + UsefullyRP.GetPlayerNameToTarget(target, alvo) + ".");
            }
        }
        else if (objectName == "Haus Schlüssel übergeben")
        {
            HouseSystem.CMD_darchaves(player, target);

            // Main.ShowPlayerStats(player, target);
            List<Client> proxPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(15, player);
            foreach (Client alvo in proxPlayers)
            {
                //NAPI.Notification.SendNotificationToPlayer(alvo, "" + UsefullyRP.GetPlayerNameToTarget(player, alvo) + " zeigt seinen Dienstausweis " + UsefullyRP.GetPlayerNameToTarget(target, alvo) + ".");
                //alvo.TriggerEvent("Send_ToChat", "", "<font color ='#C2A2DA'>* " + UsefullyRP.GetPlayerNameToTarget(player, alvo) + " zeigt seinen Ausweis " + UsefullyRP.GetPlayerNameToTarget(target, alvo) + ".");
            }
        }
        else if (objectName == "Haus aufschliessen")
        {
            int house_index = 0;
            foreach (var entrace in HouseSystem.HouseInfo)
            {
                if (Main.IsInRangeOfPoint(player.Position, entrace.exterior, 2.0f) && player.Dimension == 0)
                {
                    bool can_pass = false;
                    for (int i = 0; i < 9; i++)
                    {
                        if (entrace.key_acess[i] == player.GetData("character_name"))
                        {
                            can_pass = true;
                        }
                    }

                    if (entrace.owner == AccountManage.GetPlayerSQLID(player))
                    {
                        can_pass = true;
                    }

                    if (can_pass == false)
                    {
                        NAPI.Notification.SendNotificationToPlayer(player, "Sie haben die Schlüssel zu diesem Haus nicht.");
                        return;
                    }

                    if (entrace.locked == 1)
                    {
                        NAPI.Notification.SendNotificationToPlayer(player, "Du hast dein " + Main.EMBED_LIGHTGREEN + " dein Zuhause aufgeschlossen" + Main.EMBED_WHITE + " .");
                        entrace.locked = 0;
                    }
                    else
                    {
                        NAPI.Notification.SendNotificationToPlayer(player, "Du hast dein " + Main.EMBED_RED + "dein Zuhause abgeschlossen" + Main.EMBED_WHITE + " .");
                        entrace.locked = 1;
                    }
                    HouseSystem.UpdateHouseLabel(house_index);
                    return;
                }
                else if (Main.IsInRangeOfPoint(player.Position, entrace.interior, 2.0f) && player.Dimension == 500 + (uint)house_index)
                {
                    bool can_pass = false;
                    for (int i = 0; i < 9; i++)
                    {
                        if (entrace.key_acess[i] == player.GetData("character_name"))
                        {
                            can_pass = true;
                        }
                    }

                    if (entrace.owner == AccountManage.GetPlayerSQLID(player))
                    {
                        can_pass = true;
                    }

                    if (can_pass == false)
                    {
                        NAPI.Notification.SendNotificationToPlayer(player, "Sie hatten die Schlüssel zu diesem Haus nicht.");
                        return;
                    }
                    if (entrace.locked == 1)
                    {
                        NAPI.Notification.SendNotificationToPlayer(player, "Du hast dein " + Main.EMBED_LIGHTGREEN + "dein Zuhause freigeschaltet" + Main.EMBED_WHITE + ".");
                        entrace.locked = 0;
                    }
                    else
                    {
                        NAPI.Notification.SendNotificationToPlayer(player, "Du hast dein " + Main.EMBED_RED + "dein Zuhause gesperrt" + Main.EMBED_WHITE + " .");
                        entrace.locked = 1;
                    }
                    HouseSystem.UpdateHouseLabel(house_index);

                    return;
                }
                house_index++;
            }
        }
        else if (objectName == "Haus abschliessen")
        {
            int house_index = 0;
            foreach (var entrace in HouseSystem.HouseInfo)
            {
                if (Main.IsInRangeOfPoint(player.Position, entrace.exterior, 2.0f) && player.Dimension == 0)
                {
                    bool can_pass = false;
                    for (int i = 0; i < 9; i++)
                    {
                        if (entrace.key_acess[i] == player.GetData("character_name"))
                        {
                            can_pass = true;
                        }
                    }

                    if (entrace.owner == AccountManage.GetPlayerSQLID(player))
                    {
                        can_pass = true;
                    }

                    if (can_pass == false)
                    {
                        NAPI.Notification.SendNotificationToPlayer(player, "Sie haben die Schlüssel zu diesem Haus nicht.");
                        return;
                    }

                    if (entrace.locked == 1)
                    {
                        NAPI.Notification.SendNotificationToPlayer(player, "Du hast dein " + Main.EMBED_LIGHTGREEN + " dein Zuhause aufgeschlossen" + Main.EMBED_WHITE + " .");
                        entrace.locked = 0;
                    }
                    else
                    {
                        NAPI.Notification.SendNotificationToPlayer(player, "Du hast dein " + Main.EMBED_RED + "dein Zuhause abgeschlossen" + Main.EMBED_WHITE + " .");
                        entrace.locked = 1;
                    }
                    HouseSystem.UpdateHouseLabel(house_index);
                    return;
                }
                else if (Main.IsInRangeOfPoint(player.Position, entrace.interior, 2.0f) && player.Dimension == 500 + (uint)house_index)
                {
                    bool can_pass = false;
                    for (int i = 0; i < 9; i++)
                    {
                        if (entrace.key_acess[i] == player.GetData("character_name"))
                        {
                            can_pass = true;
                        }
                    }

                    if (entrace.owner == AccountManage.GetPlayerSQLID(player))
                    {
                        can_pass = true;
                    }

                    if (can_pass == false)
                    {
                        NAPI.Notification.SendNotificationToPlayer(player, "Sie hatten die Schlüssel zu diesem Haus nicht.");
                        return;
                    }
                    if (entrace.locked == 1)
                    {
                        NAPI.Notification.SendNotificationToPlayer(player, "Du hast dein " + Main.EMBED_LIGHTGREEN + "dein Zuhause freigeschaltet" + Main.EMBED_WHITE + ".");
                        entrace.locked = 0;
                    }
                    else
                    {
                        NAPI.Notification.SendNotificationToPlayer(player, "Du hast dein " + Main.EMBED_RED + "dein Zuhause gesperrt" + Main.EMBED_WHITE + " .");
                        entrace.locked = 1;
                    }
                    HouseSystem.UpdateHouseLabel(house_index);

                    return;
                }
                house_index++;
            }
        }
        else if (objectName == "Lizenzen zeigen")
        {
            ShowPlayerLicenses(player, target);

            List<Client> proxPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(15, player);
            foreach (Client alvo in proxPlayers)
            {
                //NAPI.Notification.SendNotificationToPlayer(alvo, "" + UsefullyRP.GetPlayerNameToTarget(player, alvo) + " zeigt seine Lizenzen " + UsefullyRP.GetPlayerNameToTarget(target, alvo) + ".");
                //alvo.TriggerEvent("Send_ToChat", "", "<font color ='#C2A2DA'>* " + UsefullyRP.GetPlayerNameToTarget(player, alvo) + " zeigt seine Lizenzen " + UsefullyRP.GetPlayerNameToTarget(target, alvo) + ".");
            }
        }
        else if (objectName == "Gefangenen ins Auto setzten")
        {
            int assento = player.GetData("new_interact_menu_seat");
            if (assento != 1 && assento != 2)
            {
                SendNotificationError(player, "Der Sitz sollte zwischen 1 und 2 liegen");
                return;
            }

            if (target.GetData("playerCuffed") == 0)
            {
                SendNotificationError(player, "Der Bürger muss dafür mit Handschellen gefesselt sein.");
                return;
            }

            if (target.IsInVehicle)
            {
                SendNotificationError(player, "Dieser Bürger befindet sich bereits in einem Fahrzeug.");
                return;
            }

            Vehicle vehicle = Utils.GetClosestVehicle(target, 5.0f);

            if (!NAPI.Entity.DoesEntityExist(vehicle))
            {
                SendNotificationError(player, "Sie sind nicht in der Nähe eines Fahrzeugs.");
                return;
            }


            var p = NAPI.Pools.GetAllPlayers();
            foreach (var i in p)
            {
                if (i.GetData("status") == true && NAPI.Player.IsPlayerInAnyVehicle(i) && NAPI.Player.GetPlayerVehicleSeat(i) == assento)
                {
                    SendNotificationError(player, "Der Beifahrersitz " + assento + " wird bereits verwendet.");
                    return;
                }
            }

            SendNotificationInfo(player, "Sie setzen den Bürger ~b~" + AccountManage.GetCharacterName(target) + "~w~ auf dem Beifahrersitz.");
            NAPI.Player.SetPlayerIntoVehicle(target, vehicle, assento);
            NAPI.Player.PlayPlayerAnimation(target, (int)(Main.AnimationFlags.Loop | Main.AnimationFlags.OnlyAnimateUpperBody), "mp_arresting", "sit");
            target.TriggerEvent("freezeEx", true);
            return;

        }
        else if (objectName == "Handschellen anlegen")
        {
            if (target.GetData("playerCuffed") == 1)
            {
                SendNotificationError(player, "Dieser Bürger ist bereits mit Handschellen gefesselt.");
                return;
            }

            if (target.GetData("handsup") == false)
            {
                SendNotificationError(player, "Dieser Spieler hält seine Hände nicht hoch.");
                return;
            }

            Police.CuffPlayer(target);

            List<Client> proxPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(15, player);
            foreach (Client alvo in proxPlayers)
            {
                //alvo.TriggerEvent("Send_ToChat", "", "<font color ='#C2A2DA'>* " + UsefullyRP.GetPlayerNameToTarget(player, alvo) + " gefesselt " + UsefullyRP.GetPlayerNameToTarget(target, alvo) + ".");
            }
        }
        else if (objectName == "Handschellen ablegen")
        {
            Police.UnCuffPlayer(target);
            List<Client> proxPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(15, player);
            foreach (Client alvo in proxPlayers)
            {
                //alvo.TriggerEvent("Send_ToChat", "", "<font color ='#C2A2DA'>* " + UsefullyRP.GetPlayerNameToTarget(player, alvo) + " entfesselt " + UsefullyRP.GetPlayerNameToTarget(target, alvo) + ".");
            }
        }
        else if (objectName == "Bürger durchsuchen")
        {
            if (target.GetData("playerCuffed") == 1 || target.GetData("handsup") == true)
            {

                List<dynamic> menu_item_list = new List<dynamic>();
                int count = 0;

                if ((WeaponHash)target.GetData("primary_weapon") != 0)
                {
                    menu_item_list.Add(new { Type = 1, Name = "" + (WeaponHash)target.GetData("primary_weapon")+"", Description = "", RightBadge = "Gun" });
                    count++;
                }
                if ((WeaponHash)target.GetData("secundary_weapon") != 0)
                {
                    menu_item_list.Add(new { Type = 1, Name = "" + (WeaponHash)target.GetData("secundary_weapon") + "", Description = "", RightBadge = "Gun" });
                    count++;
                }
                if ((WeaponHash)target.GetData("weapon_meele") != 0)
                {
                    menu_item_list.Add(new { Type = 1, Name = "" + (WeaponHash)target.GetData("weapon_meele") + "", Description = "", RightBadge = "Gun" });
                    count++;
                }

                for (int index = 0; index < Inventory.MAX_INVENTORY_ITENS; index++)
                {
                    if (Inventory.player_inventory[targetid].type[index] != 0 && Inventory.player_inventory[targetid].type[index] < Inventory.itens_available.Count)
                    {
                        if (Inventory.player_inventory[targetid].amount[index] > 0)
                        {
                            
                            menu_item_list.Add(new { Type = 1, Name = Inventory.itens_available[Inventory.player_inventory[targetid].type[index]].name, Description = "Wählen Sie diese Option, um Gegenstände einzuziehen.", RightLabel = Inventory.player_inventory[targetid].amount[index] });
                            count++;
                        }
                    }
                }
                if (count == 0)
                {
                    SendNotificationError(player, "Dieser Bürger besitzt keine Gegenstände oder Waffen.");
                    return;
                }
                InteractMenu.CreateMenu(player, "NOTHING_HAPPEND", "Polizei", "~g~Artikel von " + UsefullyRP.GetPlayerNameToTarget(target, player), false, JsonConvert.SerializeObject(menu_item_list), false, BackgroundColor: "Green");


                List<Client> proxPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(15, player);
                foreach (Client alvo in proxPlayers)
                {
                    //NAPI.Notification.SendNotificationToPlayer(player, "" + UsefullyRP.GetPlayerNameToTarget(player, alvo) + " durchsucht " + UsefullyRP.GetPlayerNameToTarget(target, alvo) + ".");
                    //alvo.TriggerEvent("Send_ToChat", "", "<font color ='#C2A2DA'>* " + UsefullyRP.GetPlayerNameToTarget(player, alvo) + " durchsucht " + UsefullyRP.GetPlayerNameToTarget(target, alvo) + ".");
                }
            }
            else
            {
                SendNotificationError(player, "Dieser Bürger hält keine Hände hoch oder hat Handschellen angelget.");
            }
        }
        else if (objectName == "Bürger hinterher ziehen")
        {
            if (target.GetData("playerCuffed") == 1)
            {
                SendNotificationError(player, "Dieser Bürger muss zum Ziehen mit Handschellen gefesselt werden.");
                return;
            }

            if (NAPI.Data.GetEntityData(target, "SendoArrastado") == true)
            {
                SendNotificationError(player, "Dieser Bürger wird bereits gezogen.");
                return;
            }

            Police.DragPlayerToTarget(target, player);
            List<Client> proxPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(15, player);
            foreach (Client alvo in proxPlayers)
            {
                //NAPI.Notification.SendNotificationToPlayer(player, "" + UsefullyRP.GetPlayerNameToTarget(player, alvo) + " schleppt " + UsefullyRP.GetPlayerNameToTarget(target, alvo) + ".");
                //alvo.TriggerEvent("Send_ToChat", "", "<font color ='#C2A2DA'>* " + UsefullyRP.GetPlayerNameToTarget(player, alvo) + " schleppt " + UsefullyRP.GetPlayerNameToTarget(target, alvo) + ".");
            }
        }
        else if (objectName == "Bürger loslassen")
        {
            if (NAPI.Data.GetEntityData(target, "SendoArrastado") == false)
            {
                SendNotificationError(player, "Dieser Bürger wird nicht mehr gezogen.");
                return;
            }

            Police.UnDragPlayer(target);
            List<Client> proxPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(15, player);
            foreach (Client alvo in proxPlayers)
            {
                //alvo.TriggerEvent("Send_ToChat", "", "<font color ='#C2A2DA'>* " + UsefullyRP.GetPlayerNameToTarget(player, alvo) + " hörte auf zu ziehen " + UsefullyRP.GetPlayerNameToTarget(target, alvo) + ".");
            }
        }
        else if (objectName == "Waffen beschlagnahmen")
        {
            WeaponManage.RemoveAllWeaponEx(target);

            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben alle Waffen konfisziert " + AccountManage.GetCharacterName(target) + ".");
            Main.SendSuccessMessage(target, "Der Offizier hat Ihnen alle Waffen entzogen.");
            WeaponManage.SaveWeapons(player);
        }
        else if (objectName == "Nagelbrett legen & aufheben")
        {
            policeCommands.CMD_nagelbrett(player);
        }
        else if (objectName == "Geldstrafe")
        {
            int preco = (player.GetData("new_interact_menu_ticket_player") + 1) * 500;

            target.SetData("ticketOffer", true);
            target.SetData("ticketOfferBy", player);
            target.SetData("ticketOfferPrice", preco);

            NAPI.Notification.SendNotificationToPlayer(player, "Sie wurden bestraft ~g~$" + preco.ToString("N0") + "~w~ em " + AccountManage.GetCharacterName(target) + ".");
            Main.SendInfoMessage(target, "O " + FactionManage.faction_data[AccountManage.GetPlayerGroup(player)].faction_rank[AccountManage.GetPlayerRank(player)] + " " + AccountManage.GetCharacterName(player) + "hat Ihnen eine Geldstrafe gegeben ~g~$" + preco.ToString("N0") + "~w~.");
            //Main.SendInfoMessage(target, "Use ~g~/aceitarmulta~w~ para aceitar e /recusarmulta~w~ para recusar. ATENÇÃO: A multa será recusada altomaticamente dentro de 1 minuto.");

            NAPI.Task.Run(() =>
            {
                player.ResetData("ticketOffer");
                player.ResetData("ticketOfferBy");
                player.ResetData("ticketOfferPrice");
            }, delayTime: 60000);
        }
        else if (objectName == "Eintrag in die Strafakte")
        {

            List<dynamic> menu_item_list = new List<dynamic>();
            int index = 0;
            foreach (var crime in Main.crime_list)
            {
                menu_item_list.Add(new { Type = 1, Name = crime.crime_name, Description = "", RightLabel = "~c~" + crime.crime_points + " Sterne" });

                index++;
            }
            InteractMenu.CreateMenu(player, "CRIME_LIST_RESPONSE", "Strafen", "~g~Auswahl der Strafe " + UsefullyRP.GetPlayerNameToTarget(target, player), false, JsonConvert.SerializeObject(menu_item_list), false, BackgroundColor: "Green");

            player.SetData("CMDMandatoTarget", target);
        }
        else if (objectName == "Ins Prison stecken")
        {
            if (!Main.IsInRangeOfPoint(player.Position, new Vector3(1690.666, 2592.404, 45.74735), 3.0f) && !Main.IsInRangeOfPoint(player.Position, new Vector3(-450.0119, 6016.234, 31.71639), 3.0f))
            {
                SendNotificationError(player, " Sie müssen sich im Haftbereich in der Nähe der Zellen aufhalten, um einen Bürger in Gefängnis zu stecken.");
                return;
            }

            
                if (NAPI.Data.GetEntityData(target, "SendoArrastado") == true)
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "ERROR:~w~ Sie dürfen den Bürger nicht mehr ziehen, bevor Sie ihn verhaften.");
                    return;
                }

                int tempo = player.GetData("new_interact_menu_arrest");
                int minutes = 0;
                if (tempo == 0)
                {
                    minutes = Police.Calcular_Prisao(target.GetData("character_name"));
                }
                else if (tempo > 0)
                {
                    minutes = tempo * 120;
                }

                if (minutes == 0)
                {
                    SendNotificationError(player, "Es wurde keine Zeit für die Festnahme eines Bürger festgelegt.");
                    return;
                }

            NAPI.Notification.SendNotificationToPlayer(target, "Sie wurden wegen ~b~" + AccountManage.GetCharacterName(player) + "~w~ verhaftet zu ~g~" + minutes + "~w~ Sekunden.");
            NAPI.Notification.SendNotificationToPlayer(player, "Du bist verhaftet~b~" + AccountManage.GetCharacterName(target) + "~w~ für ~g~" + minutes + "~w~ Sekunden.");

            //player.TriggerEvent("createNewHeadNotificationAdvanced", "Sie haben den Spieler ~y~" + AccountManage.GetCharacterName(target) + "~w~ verhaftet für ~g~" + minutes + "~w~ Sekunden.");

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

                Police.ClearPlayerCrime(target);
                cellphoneSystem.FinishCall(target);
                return;

        }
        else if (objectName == "Bürger ausrauben")
        {
            if (target.HasData("mug_timeout") && NAPI.Data.GetEntityData(target, "mug_timeout") < DateTime.Now)
            {
                SendNotificationError(player, "Dieser Bürger wurde vor kurzem ausgeraubt.");
                return;
            }

            if (target.GetData("handsup") == false)
            {
                SendNotificationError(player, "Dieser Bürger hält seine Hände nicht hoch.");
                return;
            }

            if (Main.GetPlayerMoney(target) < 2)
            {
                SendNotificationError(player, "Dieser Bürger ist bankrott, Sie haben nichts in seinen Taschen gefunden.");
                return;
            }

            int money = Main.GetPlayerMoney(target) / 2;

            Main.GivePlayerMoney(player, money);
            Main.GivePlayerMoney(target, -money);


            List<Client> proxPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(15, player);
            foreach (Client alvo in proxPlayers)
            {
                //NAPI.Notification.SendNotificationToPlayer(player, "" + UsefullyRP.GetPlayerNameToTarget(player, alvo) + " ausgeraubt " + UsefullyRP.GetPlayerNameToTarget(target, alvo) + " und es geschafft zu nehmen $" + money + ".");
                //alvo.TriggerEvent("Send_ToChat", "", "<font color ='#C2A2DA'>* " + UsefullyRP.GetPlayerNameToTarget(player, alvo) + " ausgeraubt " + UsefullyRP.GetPlayerNameToTarget(target, alvo) + " und es geschafft zu nehmen $" + money + ".");
            }

            target.SetData("mug_timeout", DateTime.Now.AddMinutes(15));
        }
        else if (objectName == "Heilen")
        {
            if (target.GetSharedData("Injured") == 1)
            {
                SendNotificationError(player, "Der Bürger ist bewusstlos, man kann ihm keine Heilung anbieten.");
                return;
            }
            int price = player.GetData("new_interact_menu_healing");
            if (target.Health >= 100)
            {
                SendNotificationError(player, "Dieser Spieler ist bereits geheilt.");
                return;
            }

            if (!Main.IsInRangeOfPoint(player.Position, target.Position, 5))
            {
                SendNotificationError(player, "Sie müssen sich in der Nähe des Spielers befinden, den Sie heilen möchten.");
                return;
            }
            NAPI.Notification.SendNotificationToPlayer(player, "Du hast ein Heilmittel angeboten " + AccountManage.GetCharacterName(target) + " für ~g~$" + price.ToString("N0") + "~w~.");
            NAPI.Notification.SendNotificationToPlayer(target, "Der Arzt ~w~ bot ihm eine Heilung für ~g~$" + price.ToString("N0") + "~w~ (Gute Besserung).");

            target.SetData("curar_offerBy", player);
            target.SetData("curar_offerPrice", price);

            target.TriggerEvent("update_health", target.Health);

            NAPI.Task.Run(() =>
            {
                player.SetData("curar_offerBy", -1);
                player.SetData("curar_offerPrice", 0);
            }, delayTime: 70000);
        }
        else if (objectName == "Wiederbeleben")
        {
            if (Main.IsInRangeOfPoint(player.Position, target.Position, 3.0f) && player != target)
            {
                if (target.GetSharedData("Injured") == 1)
                {
                    player.SetData("reanimando", true);
                    NAPI.Notification.SendNotificationToPlayer(player, "~y~[INFO]:~w~ Sie versuchen den Patienten wiederzubeleben.~y~" + AccountManage.GetCharacterName(target) + "~w~ ...");
                    NAPI.Player.PlayPlayerAnimation(player, 49, "mini@cpr@char_a@cpr_str", "cpr_kol");
                    NAPI.Task.Run(() =>
                    {
                        if (player.GetData("reanimando") == true)
                        {
                            AccountManage.SetPlayerHunger(target, 20.0f);
                            AccountManage.SetPlayerThirsty(target, 20.0f);
                            player.SetData("reanimando", false);
                            target.SetSharedData("Injured", 0);
                            NAPI.Player.SetPlayerHealth(target, 40);
                            target.TriggerEvent("freeze", false);
                            target.TriggerEvent("freezeEx", false);
                            NAPI.Player.StopPlayerAnimation(target);
                            NAPI.Player.StopPlayerAnimation(player);
                            NAPI.Notification.SendNotificationToPlayer(player, "~y~[INFO]:~w~ Du hast ~g~Erfolgreich~w~ wiederbelebt ~y~" + AccountManage.GetCharacterName(target) + "~w~.");
                            Main.SendInfoMessage(target, "Sie wurden vom Arzt wiederbelebt ~y~" + AccountManage.GetCharacterName(player) + "~w~.");
                            target.TriggerEvent("update_health", target.Health);
                            Main.GivePlayerMoney(player, 500);
                            SendNotificationSuccess(player, "Sie haben $ 500 für die Wiederbelebung dieses Spielers gewonnen.");
                        }
                    }, delayTime: 7 * 1000);
                }
                else SendNotificationError(player, "Dieser Bürger ist nicht verletzt.");
            }
            else SendNotificationError(player, "Sie müssen sich in der Nähe des Bürgers befinden.");
        }
        else if (objectName == "In die Fraktion Einladen")
        {

            if (target.GetData("group_invite") != -1)
            {
                SendNotificationError(player, "Dieser Spieler wurde bereits zu einer Fraktion eingeladen. Bitte warten Sie ca. 30 Sekunden, bis seine Einladung abgelaufen ist.");
                return;
            }

            int group_id = AccountManage.GetPlayerGroup(player);
            target.SetData("group_invite", AccountManage.GetPlayerGroup(player));
            target.SetData("group_inviteBy", player);

            NAPI.Notification.SendNotificationToPlayer(target, "Du ~b~" + FactionManage.faction_data[group_id].faction_rank[AccountManage.GetPlayerRank(player)] + " " + AccountManage.GetPlayerGroup(player) + "~w~ bot eine Einladung an ~g~" + FactionManage.faction_data[group_id].faction_name + "~w~ (Glückwunsch).");

            NAPI.Notification.SendNotificationToPlayer(player, "Du hast angeboten " + AccountManage.GetCharacterName(target) + " um das einzugeben " + FactionManage.faction_data[group_id].faction_name + ".");

            NAPI.Task.Run(() =>
            {
                target.SetData("group_inviteBy", -1);
                target.SetData("group_invite", -1);
            }, delayTime: 30 * 1000);
        }
        else if (objectName == "Aus der Fraktion entlassen")
        {
            NAPI.Data.SetEntityData(target, "duty", 0);
            Main.UpdatePlayerClothes(target);
            target.SetData("duty", 0);
            Outfits.RemovePlayerDutyOutfit(target);
            AccountManage.SetPlayerLeader(target, 0);
            AccountManage.SetPlayerGroup(target, 0);
            AccountManage.SetPlayerRank(target, 0);
            AccountManage.SaveCharacter(target);
            NAPI.Notification.SendNotificationToPlayer(target, "Du wurdest von deiner Fraktion ~b~gekündigt!~w~.");
            Main.SetPlayerToTeamColor(target);
        }
    }

    //
    // Single Player
    //
    [RemoteEvent("keypress:O")]
    public void KeyPressO(Client player)
    {
        if (AccountManage.GetPlayerConnected(player))
        {
            //if (player.GetData("fishing") == true)
            //{
            //    Main.DisplayErrorMessage(player, "Sie können während des Angelns kein Rucksack verwenden.");
            //    return;
            //}
            ShowPlayerInteractMenu(player);
        }
    }

    public static void ShowAdminInteractMenu(Client player)
    {
        int playerid = Main.getIdFromClient(player);
        List<dynamic> menu_item_list = new List<dynamic>();

        menu_item_list.Add(new { Type = 1, Name = "System", Description = "", RightBadge = "", Color = "Firebrick", HighlightColor = "White" });
        if (AccountManage.GetPlayerAdmin(player) == 10)
        {
            menu_item_list.Add(new { Type = 1, Name = "Skins", Description = "", RightBadge = "", Color = "Firebrick", HighlightColor = "White" });
            menu_item_list.Add(new { Type = 1, Name = "Wetter System", Description = "", RightBadge = "", Color = "Firebrick", HighlightColor = "White" });
            menu_item_list.Add(new { Type = 1, Name = "Online Spieler", Description = "", RightBadge = "", Color = "Firebrick", HighlightColor = "White" });
        }
        menu_item_list.Add(new { Type = 1, Name = "Verbindung vom Server beenden", Description = "", Color = "RoyalBlue", HighlightColor = "SteelBlue" });
        InteractMenu.CreateMenu(player, "NEW_MENU_RESPONSE", "Admin Menu", "~g~Admin Menu:", false, JsonConvert.SerializeObject(menu_item_list), false, BackgroundColor: "Green");
    }

    public static void ShowPlayerCharakterInteractMenu(Client player)
    {
        int playerid = Main.getIdFromClient(player);
        List<dynamic> menu_item_list = new List<dynamic>();

        menu_item_list.Add(new { Type = 1, Name = "Aktuelle Position", Description = "Hiermit kannst du deine Aktuelle Position anzeigen lassen um zb. diese an den Support zu übergeben." });
        menu_item_list.Add(new { Type = 1, Name = "Tastaturbelegung", Description = "Unsere Tastaturbelegung" });
        menu_item_list.Add(new { Type = 1, Name = "Dimension", Description = "Hiermit kannst du die Dimension deines Charakters fixen" });
        InteractMenu.CreateMenu(player, "NEW_MENU_RESPONSE", "Charakter Menu", "~g~Charakter Menu:", false, JsonConvert.SerializeObject(menu_item_list), false, BackgroundColor: "Green");
    }

    public static void ShowPlayerKeyboardInteractMenu(Client player)
    {
        int playerid = Main.getIdFromClient(player);
        List<dynamic> menu_item_list = new List<dynamic>();

        menu_item_list.Add(new { Type = 1, Name = "F2", Description = "Damit kannst du den Maus Zeiger ein und ausschalten.", RightLabel = "Mauszeiger" });
        menu_item_list.Add(new { Type = 1, Name = "F3", Description = "Damit rufst du über das Tablet unser UCP auf.", RightLabel = "Tablet" });
        menu_item_list.Add(new { Type = 1, Name = "F4", Description = "Für die Staatsfraktionen.", RightLabel = "Fraktion" });
        menu_item_list.Add(new { Type = 1, Name = "F5", Description = "Fahrzeug orten & verschrotten", RightLabel = "Fahrzeug" });
        menu_item_list.Add(new { Type = 1, Name = "F6", Description = "Für alle Staatsfraktionen.", RightLabel = "Dispatch" });
        menu_item_list.Add(new { Type = 1, Name = "F7", Description = "LSPD & LSSD System", RightLabel = "Aktensystem" });
        menu_item_list.Add(new { Type = 1, Name = "F8", Description = "Damit erstellst du ein Screenshot.", RightLabel = "Screenshot" });
        menu_item_list.Add(new { Type = 1, Name = "F10", Description = "Hiermit kannst du deine Voice Reichweite einstellen", RightLabel = "Voice Range" });
        menu_item_list.Add(new { Type = 1, Name = "H", Description = "Hände hoch nehmen", RightLabel = "Ergeben" });
        menu_item_list.Add(new { Type = 1, Name = "O", Description = "Dein Interaktions Menü.", RightLabel = "Interaktion" });
        menu_item_list.Add(new { Type = 1, Name = "M", Description = "Damit kannst du mit anderen in die Interaktion gehen.", RightLabel = "Spieler" });
        menu_item_list.Add(new { Type = 1, Name = "L", Description = "Fahrzeug auf & zu schliessen & Verschlossende Türen auf & zu machen", RightLabel = "Türen" });
        menu_item_list.Add(new { Type = 1, Name = "E", Description = "Interaktion bei allen anderen wie zb. Farming ect. pp", RightLabel = "Siehe Beschreibung" });
        menu_item_list.Add(new { Type = 1, Name = "X", Description = "Shortcuts hinterlegen im Animationssystem.", RightLabel = "Fahrzeug" });
        menu_item_list.Add(new { Type = 1, Name = "I", Description = "Dein Inventar", RightLabel = "Inventar" });
        menu_item_list.Add(new { Type = 1, Name = "ARROW UP", Description = "Hiermit rufst du dein Handy ab & weg", RightLabel = "Handy" });
        InteractMenu.CreateMenu(player, "NEW_MENU_RESPONSE", "Tastaturbelegung", "~g~Unsere Tastaturbelebung:", false, JsonConvert.SerializeObject(menu_item_list), false, BackgroundColor: "Green");
    }

    public static void ShowPlayerBekleidungInteractMenu(Client player)
    {
        int playerid = Main.getIdFromClient(player);
        List<dynamic> menu_item_list = new List<dynamic>();

        var hats = NAPI.Data.GetEntityData(player, "character_hats");
        var hats_texture = NAPI.Data.GetEntityData(player, "character_hats_texture");
        var glasses = NAPI.Data.GetEntityData(player, "character_glasses");
        var glasses_texture = NAPI.Data.GetEntityData(player, "character_glasses_texture");
        var backpack = NAPI.Data.GetEntityData(player, "character_backpack");
        var mask = NAPI.Data.GetEntityData(player, "character_mask");

        var torso = NAPI.Data.GetEntityData(player, "character_torso");
        var torso_texture = NAPI.Data.GetEntityData(player, "character_torso_texture");
        var undershirt = NAPI.Data.GetEntityData(player, "character_undershirt");
        var undershirt_texture = NAPI.Data.GetEntityData(player, "character_undershirt_texture");
        var leg = NAPI.Data.GetEntityData(player, "character_leg");
        var leg_texture = NAPI.Data.GetEntityData(player, "character_leg_texture");
        var feet = NAPI.Data.GetEntityData(player, "character_feet");
        var feet_texture = NAPI.Data.GetEntityData(player, "character_feet_texture");
        var shirt = NAPI.Data.GetEntityData(player, "character_shirt");
        var shirt_texture = NAPI.Data.GetEntityData(player, "character_shirt_texture");

        //if (player.GetData("hats_enable") == true)
        //{
        //    menu_item_list.Add(new { Type = 5, Name = "Hut abnehmen", Description = "Hiermit kannst du dein Hut aus & anziehen.", /*LeftBadge = "Clothes",*/ IsTicked = player.GetData("hats_enable") });
        //}
        //else
        //{
        //    menu_item_list.Add(new { Type = 5, Name = "Hut aufsetzen", Description = "Hiermit kannst du dein Hut aus & anziehen.", /*LeftBadge = "Clothes",*/ IsTicked = player.GetData("hats_enable") });
        //}

        //if (player.GetData("glasses_enable") == true)
        //{
        //    menu_item_list.Add(new { Type = 5, Name = "Brille abnehmen", Description = "Hiermit kannst du deine Brille aus & anziehen.", /*LeftBadge = "Clothes",*/ IsTicked = player.GetData("glasses_enable") });
        //}
        //else
        //{
        //    menu_item_list.Add(new { Type = 5, Name = "Brille aufsetzen", Description = "Hiermit kannst du dein Brille aus & anziehen.", /*LeftBadge = "Clothes",*/ IsTicked = player.GetData("glasses_enable") });
        //}

        //if (player.GetData("ears_enable") == true)
        //{
        //    menu_item_list.Add(new { Type = 5, Name = "Kopfschmuck abnehmen", Description = "Hiermit kannst du deine Kopfschmuck aus & anziehen.", /*LeftBadge = "Clothes",*/ IsTicked = player.GetData("ears_enable") });
        //}
        //else
        //{
        //    menu_item_list.Add(new { Type = 5, Name = "Kopfschmuck aufsetzen", Description = "Hiermit kannst du dein Kopfschmuck aus & anziehen.", /*LeftBadge = "Clothes",*/ IsTicked = player.GetData("ears_enable") });
        //}

        //if (player.GetData("watches_enable") == true)
        //{
        //    menu_item_list.Add(new { Type = 5, Name = "Uhr abnehmen", Description = "Hiermit kannst du dein Funkgerät aus & anziehen.", /*LeftBadge = "Clothes",*/ IsTicked = player.GetData("watches_enable") });
        //}
        //else
        //{
        //    menu_item_list.Add(new { Type = 5, Name = "Uhr aufsetzen", Description = "Hiermit kannst du dein Funkgerät aus & anziehen.", /*LeftBadge = "Clothes",*/ IsTicked = player.GetData("watches_enable") });
        //}

        //if (player.GetData("backpack_enable") == true)
        //{
        //    menu_item_list.Add(new { Type = 5, Name = "Rucksack abnehmen", Description = "Hiermit kannst du dein Rucksack aus & anziehen.", /*LeftBadge = "Clothes",*/ IsTicked = player.GetData("backpack_enable") });
        //}
        //else
        //{
        //    menu_item_list.Add(new { Type = 5, Name = "Rucksack aufsetzen", Description = "Hiermit kannst du dein Rucksack aus & anziehen.", /*LeftBadge = "Clothes",*/ IsTicked = player.GetData("backpack_enable") });
        //}
        
        //if (player.GetData("using_mask") == true)
        //{
        //    menu_item_list.Add(new { Type = 5, Name = "Maske abnehmen", Description = "Hiermit kannst du deine Maske aus & anziehen.", /*LeftBadge = "Clothes",*/ IsTicked = UsefullyRP.mask[playerid] });
        //}
        //else
        //{
        //    menu_item_list.Add(new { Type = 5, Name = "Maske aufsetzen", Description = "Hiermit kannst du dein Maske aus & anziehen.", /*LeftBadge = "Clothes",*/ IsTicked = UsefullyRP.mask[playerid] });
        //}

        menu_item_list.Add(new { Type = 5, Name = "Oberteil", Description = "Hiermit kannst du dein Oberteil aus & anziehen.", /*LeftBadge = "Clothes",*//* IsTicked = NAPI.Data.GetEntityData(player, "glasses_enable")*/ });
        menu_item_list.Add(new { Type = 5, Name = "Nackig", Description = "Hiermit kannst du deine Kleidung aus & anziehen." });
        InteractMenu.CreateMenu(player, "NEW_MENU_RESPONSE", "Bekleidung Menu", "~g~Bekleidung Menu:", false, JsonConvert.SerializeObject(menu_item_list), false, BackgroundColor: "Green");
    }

    public static void ShowPlayerDokumenteInteractMenu(Client player)
    {
        int playerid = Main.getIdFromClient(player);
        List<dynamic> menu_item_list = new List<dynamic>();

        menu_item_list.Add(new { Type = 1, Name = "Infos über meinen Bürger", Description = "", RightBadge = "Michael" });
        menu_item_list.Add(new { Type = 1, Name = "Identität anzeigen nur sich selbst", Description = "", RightBadge = "Michael" });
        menu_item_list.Add(new { Type = 1, Name = "Lizenzen anzeigen nur sich selbst", Description = "", RightBadge = "Michael" });
        if (FactionManage.GetPlayerGroupType(player) == 1)
        {
            menu_item_list.Add(new { Type = 1, Name = "Cop Ausweis anzeigen", Description = "" });
        }
        if (FactionManage.GetPlayerGroupType(player) == 2)
        {
            menu_item_list.Add(new { Type = 1, Name = "Medic Ausweis anzeigen", Description = "" });
        }
        if (FactionManage.GetPlayerGroupType(player) == 14)
        {
            menu_item_list.Add(new { Type = 1, Name = "President Ausweis anzeigen", Description = "" });
        }
        if (FactionManage.GetPlayerGroupType(player) == 15)
        {
            menu_item_list.Add(new { Type = 1, Name = "FIB Ausweis anzeigen", Description = "" });
        }
        if (FactionManage.GetPlayerGroupType(player) == 16)
        {
            menu_item_list.Add(new { Type = 1, Name = "Army Ausweis anzeigen", Description = "" });
        }
        InteractMenu.CreateMenu(player, "NEW_MENU_RESPONSE", "Dokumente Menu", "~g~Dokumente Menu:", false, JsonConvert.SerializeObject(menu_item_list), false, BackgroundColor: "Green");
    }

    public static void ShowAdminInteractSkinsMenu(Client player)
    {
        int playerid = Main.getIdFromClient(player);
        List<dynamic> menu_item_list = new List<dynamic>();

        menu_item_list.Add(new { Type = 1, Name = "MountainLion", Description = "", RightBadge = "", Color = "Firebrick", HighlightColor = "White" });
        menu_item_list.Add(new { Type = 1, Name = "Pigeon", Description = "", RightBadge = "Michael" });
        menu_item_list.Add(new { Type = 1, Name = "Pug", Description = "", RightBadge = "", Color = "Firebrick", HighlightColor = "White" });
        menu_item_list.Add(new { Type = 1, Name = "Shepherd", Description = "", RightBadge = "Michael" });
        menu_item_list.Add(new { Type = 1, Name = "Retriever", RightBadge = "", Color = "Firebrick", HighlightColor = "White" });
        menu_item_list.Add(new { Type = 1, Name = "Poodle", Description = "", RightBadge = "Michael" });
        menu_item_list.Add(new { Type = 1, Name = "Cat", Description = "", RightBadge = "", Color = "Firebrick", HighlightColor = "White" });
        menu_item_list.Add(new { Type = 1, Name = "Abschalten", Description = "", RightBadge = "", Color = "Firebrick", HighlightColor = "Red" });
        InteractMenu.CreateMenu(player, "NEW_MENU_RESPONSE", "Admin Menu", "~g~Admin Skins:", false, JsonConvert.SerializeObject(menu_item_list), false, BackgroundColor: "Green");
    }

    public static void ShowAdminInteractSystemMenu(Client player)
    {
        int playerid = Main.getIdFromClient(player);
        List<dynamic> menu_item_list = new List<dynamic>();
        if (AccountManage.GetPlayerAdmin(player) == 10)
        {
            menu_item_list.Add(new { Type = 1, Name = "Bankraub ein/ausschalten", Description = "", RightBadge = "Alert", Color = "Red", HighlightColor = "DarkRed" });
            menu_item_list.Add(new { Type = 1, Name = "Purge / Noose Einsatz", Description = "", RightBadge = "Alert", Color = "Red", HighlightColor = "DarkRed" });
            menu_item_list.Add(new { Type = 1, Name = "Flying", Description = "", RightBadge = "Alert", Color = "Red", HighlightColor = "DarkRed" });
            menu_item_list.Add(new { Type = 1, Name = "Fahrzeug Repair", Description = "", RightBadge = "Alert", Color = "Red", HighlightColor = "DarkRed" });
            menu_item_list.Add(new { Type = 1, Name = "Wiederbeleben", Description = "", RightBadge = "Alert", Color = "Red", HighlightColor = "DarkRed" });
            menu_item_list.Add(new { Type = 1, Name = "Teleportar", Description = "", RightBadge = "Alert", Color = "Red", HighlightColor = "DarkRed" });
        }
        menu_item_list.Add(new { Type = 1, Name = "Admin Fahrzeug spawnen", Description = "", RightBadge = "", Color = "Firebrick", HighlightColor = "White" });
        menu_item_list.Add(new { Type = 1, Name = "Admin Fahrzeug löschen", Description = "", RightBadge = "", Color = "Firebrick", HighlightColor = "White" });
        menu_item_list.Add(new { Type = 1, Name = "Ban System", Description = "", RightBadge = "", Color = "Firebrick", HighlightColor = "White" });
        menu_item_list.Add(new { Type = 1, Name = "Whitelist System", Description = "", RightBadge = "", Color = "Firebrick", HighlightColor = "White" });
        InteractMenu.CreateMenu(player, "NEW_MENU_RESPONSE", "Admin Menu", "~g~Admin System:", false, JsonConvert.SerializeObject(menu_item_list), false, BackgroundColor: "Green");
    }

    public static void ShowAdminWeatherInteractSystemMenu(Client player)
    {
        int playerid = Main.getIdFromClient(player);
        List<dynamic> menu_item_list = new List<dynamic>();
        menu_item_list.Add(new { Type = 1, Name = "Wetter 1", Description = "", RightBadge = "", Color = "Firebrick", HighlightColor = "White" });
        menu_item_list.Add(new { Type = 1, Name = "Wetter 2", Description = "", RightBadge = "", Color = "Firebrick", HighlightColor = "White" });
        menu_item_list.Add(new { Type = 1, Name = "Wetter 3", Description = "", RightBadge = "", Color = "Firebrick", HighlightColor = "White" });
        menu_item_list.Add(new { Type = 1, Name = "Wetter 4", Description = "", RightBadge = "", Color = "Firebrick", HighlightColor = "White" });
        menu_item_list.Add(new { Type = 1, Name = "Wetter 5", Description = "", RightBadge = "", Color = "Firebrick", HighlightColor = "White" });
        menu_item_list.Add(new { Type = 1, Name = "Wetter 6", Description = "", RightBadge = "", Color = "Firebrick", HighlightColor = "White" });
        menu_item_list.Add(new { Type = 1, Name = "Wetter 7", Description = "", RightBadge = "", Color = "Firebrick", HighlightColor = "White" });
        menu_item_list.Add(new { Type = 1, Name = "Wetter 8", Description = "", RightBadge = "", Color = "Firebrick", HighlightColor = "White" });
        menu_item_list.Add(new { Type = 1, Name = "Wetter 9", Description = "", RightBadge = "", Color = "Firebrick", HighlightColor = "White" });
        menu_item_list.Add(new { Type = 1, Name = "Wetter 10", Description = "", RightBadge = "", Color = "Firebrick", HighlightColor = "White" });
        menu_item_list.Add(new { Type = 1, Name = "Wetter 11", Description = "", RightBadge = "", Color = "Firebrick", HighlightColor = "White" });
        InteractMenu.CreateMenu(player, "NEW_MENU_RESPONSE", "Admin Wetter Menu", "~g~Admin Wetter System:", false, JsonConvert.SerializeObject(menu_item_list), false, BackgroundColor: "Green");
    }

    public static void ShowPlayerWeaponsMenu(Client player)
    {
        int playerid = Main.getIdFromClient(player);
        List<dynamic> menu_item_list = new List<dynamic>();

        if (player.GetSharedData("Injured") == 1)
        {

        }
        else
        {

            menu_item_list.Add(new { Type = 1, Name = "Waffe ins Inventar legen", Description = "Löschen Sie Ihre aktuellen Waffen an Ihrem Charakter. ~ R ~ ** EINMAL AUSGEFÜHRT UND ES KANN KEINE WAFFE WIEDERHERGESTELLT WERDEN!! **", RightBadge = "", Color = "Firebrick", HighlightColor = "White" });

        }
        InteractMenu.CreateMenu(player, "NEW_MENU_RESPONSE", "Waffen Menu", "~g~Waffen System:", false, JsonConvert.SerializeObject(menu_item_list), false, BackgroundColor: "Green");
    }

    public static void ShowPlayerInteractSystemMenu(Client player)
    {
        int playerid = Main.getIdFromClient(player);
        List<dynamic> menu_item_list = new List<dynamic>();

        menu_item_list.Add(new { Type = 1, Name = "Animationen", Description = "" });
        //menu_item_list.Add(new { Type = 1, Name = "Bekleidung", Description = "" });
        menu_item_list.Add(new { Type = 1, Name = "Charakter", Description = "" });
        menu_item_list.Add(new { Type = 1, Name = "Unterlagen", Description = "" });
        menu_item_list.Add(new { Type = 1, Name = "Waffen", Description = "" });
        InteractMenu.CreateMenu(player, "NEW_MENU_RESPONSE", "Bürger Menü", "~g~Bürger Menü:", false, JsonConvert.SerializeObject(menu_item_list), false, BackgroundColor: "Green");
    }

    public static void ShowPlayerVehicleSystemMenu(Client player)
    {
        int playerid = Main.getIdFromClient(player);
        List<dynamic> menu_item_list = new List<dynamic>();

        // Vehicle
        if (player.IsInVehicle)
        {
            for (int index = 0; index < PlayerVehicle.MAX_PLAYER_VEHICLES; index++)
            {
                if (PlayerVehicle.vehicle_data[playerid].state[index] == 1 && PlayerVehicle.vehicle_data[playerid].handle[index].Exists && player.Vehicle == PlayerVehicle.vehicle_data[playerid].handle[index])
                {
                    menu_item_list.Add(new { Type = 4, Name = "Model", Description = "", RightLabel = "" + PlayerVehicle.vehicle_data[playerid].model[index].ToString() + "" });
                    menu_item_list.Add(new { Type = 4, Name = "Tank", Description = "", RightLabel = "" + PlayerVehicle.vehicle_data[playerid].fuel[index].ToString() + "%" });
                    menu_item_list.Add(new { Type = 4, Name = "Kennzeichen", Description = "", RightLabel = "" + PlayerVehicle.vehicle_data[playerid].plate[index].ToString() + "" });
                }
            }

            if (NAPI.Vehicle.GetVehicleEngineStatus(player.Vehicle) == true)
            {
                menu_item_list.Add(new { Type = 5, Name = "Motor ausschalten", Description = "", RightBadge = "Car" });
                //sendProxMessage(player, 15.0f, "C2A2DA", "** " + AccountManage.GetCharacterName(player) + " coloca a chave na ignição e desliga o motor do veículo.");

            }
            else if (NAPI.Vehicle.GetVehicleEngineStatus(player.Vehicle) == false && player.GetData("StartEngineStatus") == false)
            {
                menu_item_list.Add(new { Type = 5, Name = "Motor einschalten", Description = "", RightBadge = "Car" });
            }

            if (player.Vehicle.Class == 8)
            {
                menu_item_list.Add(new
                {
                    Type = 5,
                    Name = "Helm",
                    Description = "", /*LeftBadge = "Car",*/
                    IsTicked = UsefullyRP.seatbelt[playerid]
                });
            }
            else
            {
                menu_item_list.Add(new { Type = 5, Name = "Sicherheitsgurt", Description = "", /*LeftBadge = "Car",*/ IsTicked = UsefullyRP.seatbelt[playerid] });
            }

            for (int index = 0; index < PlayerVehicle.MAX_PLAYER_VEHICLES; index++)
            {
                if (PlayerVehicle.vehicle_data[playerid].state[index] == 1 && PlayerVehicle.vehicle_data[playerid].handle[index].Exists && vehicle == PlayerVehicle.vehicle_data[playerid].handle[index])
                {
                    menu_item_list.Add(new { Type = 1, Name = "Auto Parken", Description = "Auto wird an dieser stelle gespeichert", RightBadge = "Car" });

                    if (NAPI.Vehicle.GetVehicleLocked(player.Vehicle) == true)
                    {
                        menu_item_list.Add(new { Type = 1, Name = "Fahrzeug öffnen", Description = "", RightBadge = "Car" });
                    }
                    else
                    {
                        menu_item_list.Add(new { Type = 1, Name = "Fahrzeug schließen", Description = "", RightBadge = "Car" });
                    }

                }
            }

            for (int index = 0; index < PlayerVehicle.MAX_PLAYER_VEHICLES; index++)
            {
                if (PlayerVehicle.vehicle_data[playerid].state[index] == 1 && PlayerVehicle.vehicle_data[playerid].handle[index].Exists && vehicle == PlayerVehicle.vehicle_data[playerid].handle[index])
                {
                    if (NAPI.Vehicle.GetVehicleLocked(player.Vehicle) == true)
                    {
                        menu_item_list.Add(new { Type = 1, Name = "Fahrzeug öffnen", Description = "", RightBadge = "Car" });
                    }
                    else
                    {
                        menu_item_list.Add(new { Type = 1, Name = "Fahrzeug schließen", Description = "", RightBadge = "Car" });
                    }
                    return;
                }
            }

            for (int b = 0; b < RentVehicle.MAX_RENT_VEHICLES; b++)
            {
                if (RentVehicle.vehicle_rent_list[b].vehicle_free == true && RentVehicle.vehicle_rent_list[b].vehicle_ownedBy == AccountManage.GetPlayerSQLID(player) && RentVehicle.vehicle_rent_list[b].vehicle_entity == player.Vehicle)
                {
                    if (NAPI.Vehicle.GetVehicleLocked(player.Vehicle) == true)
                    {
                        menu_item_list.Add(new { Type = 1, Name = "Fahrzeug öffnen", Description = "", RightBadge = "Car" });
                    }
                    else
                    {
                        menu_item_list.Add(new { Type = 1, Name = "Fahrzeug schließen", Description = "", RightBadge = "Car" });
                    }
                }
            }

            if (NAPI.Data.HasEntityData(player.Vehicle, "MAX_VEHICLE_SLOT"))
            {
                if (NAPI.Data.GetEntityData(player.Vehicle, "MAX_VEHICLE_SLOT") > 0)
                {
                    if (NAPI.Vehicle.GetVehicleHealth(player.Vehicle) > 0)
                    {
                        if (player.Vehicle.Locked == false)
                        {
                            menu_item_list.Add(new { Type = 1, Name = "Kofferraum", Description = "", RightBadge = "Car" });
                        }
                        else
                        {
                            menu_item_list.Add(new { Type = 1, Name = "Kofferraum", Description = "", RightBadge = "Lock" });
                        }
                    }
                }
            }

            List<string> list = new List<string>();

            list.Add("Deaktivieren");
            list.Add("5 KM/H");
            list.Add("10 KM/H");
            list.Add("15 KM/H");
            list.Add("20 KM/H");
            list.Add("25 KM/H");
            list.Add("30 KM/H");
            list.Add("35 KM/H");
            list.Add("40 KM/H");
            list.Add("45 KM/H");
            list.Add("50 KM/H");
            list.Add("55 KM/H");
            list.Add("60 KM/H");
            list.Add("65 KM/H");
            list.Add("70 KM/H");
            list.Add("75 KM/H");
            list.Add("80 KM/H");
            list.Add("85 KM/H");
            list.Add("90 KM/H");
            list.Add("95 KM/H");
            list.Add("100 KM/H");
            list.Add("105 KM/H");
            list.Add("110 KM/H");
            list.Add("115 KM/H");
            list.Add("120 KM/H");
            list.Add("125 KM/H");
            list.Add("130 KM/H");

            menu_item_list.Add(new { Type = 2, Name = "Tempomat", Description = "", List = list, StartIndex = player.GetData("new_interact_menu_speedlimit") });
        }
        InteractMenu.CreateMenu(player, "NEW_MENU_RESPONSE", "Fahrzeug Menü", "~g~Fahrzeug Menü:", false, JsonConvert.SerializeObject(menu_item_list), false, BackgroundColor: "Green");
    }

    public static void ShowPlayerInteractMenu(Client player)
    {
        int playerid = Main.getIdFromClient(player);
        List<dynamic> menu_item_list = new List<dynamic>();

        if (player.GetSharedData("Injured") == 1)
        {
            if (NAPI.Data.GetEntityData(player, "InjuredTime") == 0)
            {
                menu_item_list.Add(new { Type = 1, Name = "Arzt anrufen", Description = "Sie können jetzt einen Arzt anrufen", RightBadge = "", Color = "Firebrick", HighlightColor = "White" });
                menu_item_list.Add(new { Type = 1, Name = "Akzeptiere den Tod", Description = "Sie können jetzt ihren Tod akzeptieren", RightBadge = "", Color = "Firebrick", HighlightColor = "White" });

            }
            else
            {
                menu_item_list.Add(new { Type = 1, Name = "Arzt anrufen", Description = "Sie können jetzt einen Arzt anrufen", RightBadge = "", Color = "Firebrick", HighlightColor = "White" });
                menu_item_list.Add(new { Type = 1, Name = "Akzeptiere den Tod", Description = "Du musst noch warten " + player.GetSharedData("InjuredTime") + " Sekunden, um den Spawn Ihres Charakters akzeptieren zu können und ins Krankenhaus zu gehen.", RightBadge = "Lock", Color = "Firebrick", HighlightColor = "White" });

            }
        }
        else
        {
            // Variables
            if (!player.HasData("new_interact_menu_speedlimit"))
            {
                player.SetData("new_interact_menu_speedlimit", 12);
            }

            if (!player.HasData("new_interact_menu_taximetro"))
            {
                player.SetData("new_interact_menu_taximetro", 4);
            }

            // Buy a Gallon
            int business_id = Business.GetPlayerInBusinessInType(player, 5);
            if (business_id != -1)
            {
                int pump_id = FuelBusiness.GetClosestGasPump(player, business_id);
                if (pump_id != -1)
                {
                    int price2 = (Business.business_list[business_id].business_fuel_price);
                    menu_item_list.Add(new { Type = 1, Name = "Fahrzeug Tanken", Description = "Der Preis ist pro Liter!", RightLabel = "$" + price2, Color = "Green", HighlightColor = "White" });
                                        
                    int price = (Business.business_list[business_id].business_fuel_price * 20) + 50;
                    menu_item_list.Add(new { Type = 1, Name = "Kaufen Sie 20L Benzin Kanister", Description = "", RightLabel = "$" + price, Color = "Lime", HighlightColor = "White" });
                    
                }

            }

            foreach (var business in Business.business_list)
            {
                if (Main.IsInRangeOfPoint(player.Position, business.business_object_MarkerID.Position, 3.0f))
                {
                    if (business.business_OwnerID == AccountManage.GetPlayerSQLID(player))
                    {
                        menu_item_list.Add(new { Type = 1, Name = "Unternehmen verwalten", Description = "", RightLabel = ">>", Color = "Green", HighlightColor = "White" });

                        menu_item_list.Add(new { Type = 1, Name = "Firma verkaufen", Description = "Verkaufen Sie diese Firma von $" + (business.business_Price / 2).ToString("N0") + " ? auswählen, um zu bestätigen.", RightBadge = "Alert", Color = "Tomato", HighlightColor = "Salmon" });
                    }
                    else if (business.business_OwnerID == -1)
                    {
                        if (player.GetData("character_business_key") == -1)
                        {
                            menu_item_list.Add(new { Type = 1, Name = "Firma kaufen", Description = "Dieses Unternehmen kostet ~g~$" + business.business_Price.ToString("N0") + "~w~, Sie können es kaufen, wenn Sie möchten,indem Sie dieses Menü auswählen!", RightLabel = "$" + business.business_Price.ToString("N0"), Color = "Green", HighlightColor = "White" });
                        }
                    }
                }
            }

            int house_index = 0;
            foreach (var entrace in HouseSystem.HouseInfo)
            {
                if (Main.IsInRangeOfPoint(player.Position, entrace.exterior, 2.0f) && player.Dimension == 0)
                {
                    bool can_pass = false;
                    if (entrace.owner == -1)
                    {
                        can_pass = true;
                        menu_item_list.Add(new { Type = 1, Name = "Haus kaufen", Description = "Dieses Haus kostet $" + entrace.price.ToString("N0") + "", RightLabel = "$" + entrace.price.ToString("N0"), Color = "Green", HighlightColor = "White" });
                    }

                    for (int i = 0; i < 9; i++)
                    {
                        if (entrace.key_acess[i] == player.GetData("character_name"))
                        {
                            can_pass = true;
                            menu_item_list.Add(new { Type = 1, Name = "Haustür verwalten", IsTicked = Convert.ToBoolean(entrace.locked), Description = "Wählen Sie, um das Haus zu sperren oder zu entsperren.", Color = "Green", HighlightColor = "White" });
                        }
                    }

                    if (entrace.owner == AccountManage.GetPlayerSQLID(player))
                    {
                        can_pass = true;
                        menu_item_list.Add(new { Type = 1, Name = "Haustür verwalten", IsTicked = Convert.ToBoolean(entrace.locked), Description = "Wählen Sie, um das Haus zu sperren oder zu entsperren.", Color = "Green", HighlightColor = "White" });
                        menu_item_list.Add(new { Type = 1, Name = "Haus verkaufen", Description = "Sie möchten dieses Haus von verkaufen$" + (entrace.price / 2).ToString("N0") + " ? auswählen, um zu bestätigen.", RightLabel = "$" + entrace.price.ToString("N0"), Color = "Green", HighlightColor = "White" });
                    }

                    if (can_pass == false)
                    {
                        Main.SendErrorMessage(player, "Sie hatten die Schlüssel zu diesem Haus nicht.");
                        return;
                    }

                }
                if (Main.IsInRangeOfPoint(player.Position, entrace.interior, 70.0f) && player.Dimension == 500 + (uint)house_index)
                {
                    bool can_pass = false;
                    for (int i = 0; i < 9; i++)
                    {
                        if (entrace.key_acess[i] == player.GetData("character_name"))
                        {
                            can_pass = true;
                            menu_item_list.Add(new { Type = 1, Name = "Haustür verwalten", IsTicked = Convert.ToBoolean(entrace.locked), Description = "Wählen Sie, um das Haus zu sperren oder zu entsperren.", Color = "Green", HighlightColor = "White" });
                        }
                    }

                    if (entrace.owner == AccountManage.GetPlayerSQLID(player))
                    {
                        can_pass = true;
                        menu_item_list.Add(new { Type = 1, Name = "Haustür verwalten", IsTicked = Convert.ToBoolean(entrace.locked), Description = "Wählen Sie, um das Haus zu sperren oder zu entsperren.", Color = "Green", HighlightColor = "White" });
                        menu_item_list.Add(new { Type = 1, Name = "Haus verwalten", Description = "Wählen Sie, um das Menü zu öffnen, um Ihr Zuhause zu verwalten!", RightLabel = ">>", Color = "Green", HighlightColor = "White" });
                    }


                    if (can_pass == false)
                    {
                        Main.SendErrorMessage(player, "Sie haben die Schlüssel zu diesem Haus nicht.");
                        return;
                    }
                }
                house_index++;
            }

        if (FactionManage.GetPlayerGroupType(player) == 4 || FactionManage.GetPlayerGroupType(player) == 7)
            {
                int index = 0;
                foreach (var armazem in WerehouseManage.WereHouseData)
                {
                    if (Main.IsInRangeOfPoint(player.Position, new Vector3(armazem.exterior_x, armazem.exterior_y, armazem.exterior_z), 3))
                    {
                        if (armazem.ownerid == -1)
                        {
                            menu_item_list.Add(new { Type = 1, Name = "Kaufen Sie HQ", Description = "Sie möchten dieses HQ von kaufen $" + armazem.price.ToString("N0") + " ? auswählen, um zu bestätigen.", RightLabel = "$" + armazem.price.ToString("N0"), Color = "Green", HighlightColor = "DarkGreen" });
                        }

                        if (armazem.ownerid == AccountManage.GetPlayerLeader(player))
                        {
                            menu_item_list.Add(new { Type = 1, Name = "HQ verkaufen", Description = "Sie möchten dieses HQ für verkaufen $" + (armazem.price / 2).ToString("N0") + " ? auswählen, um zu bestätigen.", RightBadge = "Alert", Color = "Tomato", HighlightColor = "Salmon" });

                        }
                    }
                }
            }

            // Invites
            if (player.GetData("group_invite") != -1)
            {
                menu_item_list.Add(new { Type = 1, Name = "Einladung zur Fraktion annehmen", Description = "", RightBadge = "Alert", Color = "Gold", HighlightColor = "Goldenrod" });
                menu_item_list.Add(new { Type = 1, Name = "Einladung zur Fraktion ablehnen", Description = "", RightBadge = "Alert", Color = "Gold", HighlightColor = "Goldenrod" });
            }

            if (player.HasData("ticketOffer") && player.GetData("ticketOffer") == true)
            {
                if (AccountManage.GetPlayerConnected(NAPI.Data.GetEntityData(player, "ticketOfferBy")))
                {
                    menu_item_list.Add(new { Type = 1, Name = "Akzeptiere Strafe", Description = "", RightBadge = "Alert", Color = "Gold", HighlightColor = "Goldenrod" });
                    menu_item_list.Add(new { Type = 1, Name = "Strafe ablehnen", Description = "", RightBadge = "Alert", Color = "Gold", HighlightColor = "Goldenrod" });
                }
            }

            if (player.GetData("curar_offerPrice") != 0)
            {
                menu_item_list.Add(new { Type = 1, Name = "Akzeptiere Heilung", Description = "", RightBadge = "Alert", Color = "Gold", HighlightColor = "Goldenrod" });
                menu_item_list.Add(new { Type = 1, Name = "Heilung ablehnen", Description = "", RightBadge = "Alert", Color = "Gold", HighlightColor = "Goldenrod" });
            }

            // Priority
            if (bankRobbery.enable_bank_robbery == true && bankRobbery.main_robbery_bank_stage == 0 && FactionManage.GetPlayerGroupType(player) == 0 && FactionManage.GetPlayerGroupType(player) == 4 && Main.IsInRangeOfPoint(player.Position, new Vector3(247.1953, 222.6497, 106.2868), 15.0f))
            {
                menu_item_list.Add(new { Type = 1, Name = "Bankraub starten", Description = "", RightBadge = "Alert", Color = "Red", HighlightColor = "DarkRed" });
            }


            // Player
            menu_item_list.Add(new { Type = 1, Name = "Bürger Menü", Description = "", RightBadge = "", Color = "Firebrick", HighlightColor = "White" });
            menu_item_list.Add(new { Type = 1, Name = "Fahrzeug Menü", Description = "", RightBadge = "", Color = "Firebrick", HighlightColor = "White" });

            if (AccountManage.GetPlayerAdmin(player) == 3)
            {
                menu_item_list.Add(new { Type = 1, Name = "Admin System", Description = "", RightBadge = ">>", Color = "ForestGreen", HighlightColor = "Red" });
            }

            if (AccountManage.GetPlayerAdmin(player) == 10)
            {
                menu_item_list.Add(new { Type = 1, Name = "Admin System", Description = "", RightBadge = ">>", Color = "ForestGreen", HighlightColor = "Red" });
            }

            // Facção / Emprego
            if (AccountManage.GetPlayerGroup(player) == 0)
            {
                menu_item_list.Add(new { Type = 1, Name = "Fraktion", Description = "", RightBadge = "Lock", Color = "RoyalBlue", HighlightColor = "SteelBlue" });
            }
            else menu_item_list.Add(new { Type = 1, Name = "Fraktion", Description = "", RightLabel = ">>", Color = "RoyalBlue", HighlightColor = "SteelBlue" });

            if (AccountManage.GetPlayerJob(player) == 0)
            {
                menu_item_list.Add(new { Type = 1, Name = "Firma", Description = "", RightBadge = "Lock", Color = "ForestGreen", HighlightColor = "Green" });
            }
            else menu_item_list.Add(new { Type = 1, Name = "Firma", Description = "", RightLabel = ">>", Color = "ForestGreen", HighlightColor = "Green" });
        }
        InteractMenu.CreateMenu(player, "NEW_MENU_RESPONSE", "Interaktions Menu", "~g~Interaktionsmenü:", false, JsonConvert.SerializeObject(menu_item_list), false, BackgroundColor: "Green");
    }

    public static void Responder_Menu(Client player, int selectedIndex, String objectName, String valueList)
    {
        if (objectName == "Waffe ins Inventar legen")
        {
            foreach (var w in Main.weapon_list)
            {
                if (player.CurrentWeapon == NAPI.Util.WeaponNameToModel(w.model) && ((int)player.GetData("primary_weapon") == (int)NAPI.Util.WeaponNameToModel(w.model) || (int)player.GetData("secundary_weapon") == (int)NAPI.Util.WeaponNameToModel(w.model) || (int)player.GetData("weapon_meele") == (int)NAPI.Util.WeaponNameToModel(w.model)))
                {
                    Inventory.GiveItemToInventory(player, Inventory.Item_Name_To_Type(w.model), 1);



                    if (w.classe == "Melee")
                    {
                        player.SetData("weapon_meele", 0);
                    }
                    else if (w.classe == "Secundary")
                    {
                        player.SetData("secundary_weapon", 0);
                        player.SetData("secundary_ammunation", 0);
                    }
                    else if (w.classe == "Primary")
                    {
                        player.SetData("primary_weapon", 0);
                        player.SetData("primary_ammunation", 0);
                    }

                    API.Shared.RemovePlayerWeapon(player, player.CurrentWeapon);

                }
            }
        }
        else if (objectName == "Firma kaufen")
        {
            int
          count = 0,
          index = -1
      ;

            foreach (var business in Business.business_list)
            {
                if (Main.IsInRangeOfPoint(player.Position, new Vector3(float.Parse(business.business_posX), float.Parse(business.business_posY), float.Parse(business.business_posZ)), 3))
                {
                    index = count;
                }
                count++;
            }

            if (index == -1)
            {
                SendNotificationError(player, "Sie befinden sich nicht in einer Firma..");
                return;
            }
            if (NAPI.Data.GetEntityData(player, "character_business_key") != -1)
            {
                SendNotificationError(player, "Sie besitzen bereits eine Firma.");
                return;
            }
            if (Business.business_list[index].business_OwnerID != -1)
            {
                SendNotificationError(player, "Diese Firma besitzt bereits jemand.");
                return;
            }
            if (Main.GetPlayerMoney(player) < Business.business_list[index].business_Price)
            {
                SendNotificationError(player, "Sie haben nicht genug Geld, um zu kaufen á ~y~" + Business.business_list[index].business_Name + "~w~.");
                return;
            }
            Main.GivePlayerMoney(player, -Business.business_list[index].business_Price);

            NAPI.Data.SetEntityData(player, "character_business_key", index);

            //NAPI.Util.ConsoleOutput("SQLID: " + AccountManage.GetPlayerSQLID(player) + "");
            Business.business_list[index].business_OwnerID = AccountManage.GetPlayerSQLID(player);
            Business.business_list[index].business_OwnerName = NAPI.Data.GetEntityData(player, "character_name");
            Business.UpdateBusinessLabel(index);

            // Reset Safe e Inventory
            Business.business_list[index].business_Safe = 0;
            Business.business_list[index].business_Inventory = 3;
            Business.business_list[index].business_InventoryCapacity = 100;

            // Save Business and Account
            Business.SaveBusiness(index);
            AccountManage.SaveCharacter(player);

            NAPI.Notification.SendNotificationToPlayer(player, "~y~[Firma]:~w~ Sie haben die Firma gekauft. ~y~" + Business.business_list[index].business_Name + "~w~ für ~g~$~w~" + Business.business_list[index].business_Price.ToString("N0") + ".");
            NAPI.Notification.SendNotificationToPlayer(player, "~y~[Firma]:~w~ Benutze E um Einsicht in deine Firma zu erhalten");
        }
        else if (objectName == "Unternehmen verwalten")
        {
            Business.ShowBusinessMenu(player);
        }
        else if (objectName == "Firma verkaufen")
        {
            int
            count = 0,
            index = -1
            ;

            foreach (var business in Business.business_list)
            {
                if (Main.IsInRangeOfPoint(player.Position, new Vector3(float.Parse(business.business_posX), float.Parse(business.business_posY), float.Parse(business.business_posZ)), 3) && business.business_OwnerID == AccountManage.GetPlayerSQLID(player))
                {
                    index = count;
                }
                count++;
            }

            if (index == -1)
            {
                SendNotificationError(player, "Sie sind nicht in einem Geschäft.a.");
                return;
            }

            Main.GivePlayerMoney(player, (Business.business_list[index].business_Price / 2));
            NAPI.Data.SetEntityData(player, "character_business_key", -1);

            Business.business_list[index].business_OwnerID = -1;
            Business.business_list[index].business_OwnerName = "";
            Business.UpdateBusinessLabel(index);

            // Reset Safe e Inventory
            Business.business_list[index].business_Safe = 0;
            Business.business_list[index].business_Inventory = 100;
            Business.business_list[index].business_InventoryCapacity = 100;

            // Save Business and Account
            Business.SaveBusiness(index);
            AccountManage.SaveCharacter(player);

            SendNotificationSuccess(player, "Sie haben Ihr Geschäft  verkauft ~g~$" + (Business.business_list[index].business_Price / 2).ToString("N0") + "~w~.");
        }
        else if (objectName == "Haus kaufen")
        {
            int index = 0;
            foreach (var entrace in HouseSystem.HouseInfo)
            {
                if (Main.IsInRangeOfPoint(player.Position, entrace.exterior, 2.0f) && player.Dimension == 0)
                {
                    if (entrace.owner != -1)
                    {
                        SendNotificationError(player, "Dieses Haus steht nicht zum Verkauf.");
                        return;
                    }

                    if (HouseSystem.GetPlayerHouses(player) > HouseSystem.GetPlayerHousesLimit(player))
                    {
                        SendNotificationError(player, "Sie können nicht mehr als " + HouseSystem.GetPlayerHousesLimit(player) + " ein Haus besitzen.");
                        return;
                    }

                    if (entrace.vip == 1)
                    {
                        //if (VIP.GetPlayerCredits(player) < entrace.price)
                        //{
                        //    SendNotificationError(player, "Você não tem créditos pra comprar está casa.");
                        //    return;
                        //}
                        //VIP.SetPlayerCredits(player, VIP.GetPlayerCredits(player) - entrace.price);
                    }
                    else
                    {
                        if (Main.GetPlayerMoney(player) < entrace.price)
                        {
                            SendNotificationError(player, "Sie haben nicht das Geld, um dieses Haus zu kaufen..");
                            return;
                        }

                        Main.GivePlayerMoney(player, -entrace.price);
                    }



                    Main.SendMessageWithTagToPlayer(player, "" + Main.EMBED_GROVE + "Eigenschaft", "" + Main.EMBED_WHITE + "Sie haben eine neue Immobilie erworben, drücken Sie " + Main.EMBED_LIGHTGREEN + "M" + Main.EMBED_WHITE + " viel Spaß.");

                    entrace.owner = AccountManage.GetPlayerSQLID(player);
                    entrace.owner_name = NAPI.Data.GetEntityData(player, "character_name");

                    HouseSystem.UpdateHouseLabel(index);
                    //

                    // teleport
                    player.TriggerEvent("screenFadeOut", 1000);
                    NAPI.Task.Run(() =>
                    {
                        player.Position = entrace.interior;
                        player.Rotation = new Vector3(0, 0, entrace.interior_a);
                        player.Dimension = 500 + (uint)index;
                        player.TriggerEvent("screenFadeIn", 1000);

                    }, delayTime: 2000);
                    HouseSystem.SaveEntrace(index);
                    return;
                }
                index++;
            }
        }
        else if (objectName == "Haus verwalten")
        {
            HouseSystem.DisplayManageHouseMenu(player);
        }
        else if (objectName == "Kaufen Sie HQ")
        {
            if (FactionManage.GetPlayerGroupType(player) == 4 || FactionManage.GetPlayerGroupType(player) == 7)
            {
                int index = 0;
                foreach (var armazem in WerehouseManage.WereHouseData)
                {
                    if (Main.IsInRangeOfPoint(player.Position, new Vector3(armazem.exterior_x, armazem.exterior_y, armazem.exterior_z), 3))
                    {
                        if (armazem.ownerid != -1)
                        {
                            SendNotificationError(player, "Leider konnte dieses HQ nicht gekauft werden, da es bereits Besitzer hat.");
                            return;
                        }

                        if (Main.GetPlayerMoney(player) > armazem.price)
                        {
                            Main.GivePlayerMoney(player, -armazem.price);
                            armazem.ownerid = AccountManage.GetPlayerGroup(player);
                            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben das Lager gekauft." + armazem.name + " für ~g~$" + armazem.price.ToString("N0") + ".");
                            NAPI.Notification.SendNotificationToPlayer(player, "Deine Gang kann jetzt Waffen aufstocken.");
                            WerehouseManage.UpdateWerehousePickup(index);
                            WerehouseManage.SaveWerehouse(index);
                            return;
                        }
                        else SendNotificationError(player, "Leider haben Sie nicht genug Geld, um dieses HQ zu kaufen.");
                    }
                    index++;
                }
            }
            else SendNotificationError(player, "Sie können diesen Befehl nicht verwenden, sondern nur den Besitzer der Gang.");
        }
        else if (objectName == "HQ verkaufen")
        {

            int index = 0;
            foreach (var armazem in WerehouseManage.WereHouseData)
            {
                if (Main.IsInRangeOfPoint(player.Position, new Vector3(armazem.exterior_x, armazem.exterior_y, armazem.exterior_z), 3))
                {
                    if (AccountManage.GetPlayerLeader(player) == armazem.ownerid)
                    {

                        Main.GivePlayerMoney(player, armazem.price / 3);
                        NAPI.Notification.SendNotificationToPlayer(player, "Sie haben Ihr HQ verkauft und 1/3 des Kaufpreises erhalten~g~$" + armazem.price / 3 + "~w~.");
                        armazem.safe = 0;
                        armazem.ownerid = -1;

                        for (int i = 0; i < 20; i++)
                        {
                            armazem.gun[i] = "undefiniert";
                            armazem.gun_units[i] = 0;
                            armazem.gun_perm[i] = 0;
                            armazem.safe_gun[i] = "undefiniert";
                        }
                        WerehouseManage.UpdateWerehousePickup(index);
                        WerehouseManage.SaveWerehouse(index);
                    }
                    else SendNotificationError(player, "Sie sind nicht Eigentümer dieses Lagers..");
                    return;
                }
                index++;
            }
            SendNotificationError(player, "Sie müssen sich auf dem Lagerpunkt befinden.");
        }

        else if (objectName == "Haustür verwalten")
        {
            int house_index = 0;
            foreach (var entrace in HouseSystem.HouseInfo)
            {
                if (Main.IsInRangeOfPoint(player.Position, entrace.exterior, 2.0f) && player.Dimension == 0)
                {
                    bool can_pass = false;
                    for (int i = 0; i < 9; i++)
                    {
                        if (entrace.key_acess[i] == player.GetData("character_name"))
                        {
                            can_pass = true;
                        }
                    }

                    if (entrace.owner == AccountManage.GetPlayerSQLID(player))
                    {
                        can_pass = true;
                    }

                    if (can_pass == false)
                    {
                        Main.SendErrorMessage(player, "Sie haben die Schlüssel zu diesem Haus nicht.");
                        return;
                    }

                    if (entrace.locked == 1)
                    {
                        Main.SendSuccessMessage(player, "Du hast dein " + Main.EMBED_LIGHTGREEN + " dein Zuhause freigeschaltet" + Main.EMBED_WHITE + " .");
                        entrace.locked = 0;
                    }
                    else
                    {
                        Main.SendSuccessMessage(player, "Du hast dein " + Main.EMBED_RED + "dein Zuhause gesperrt" + Main.EMBED_WHITE + " .");
                        entrace.locked = 1;
                    }
                    HouseSystem.UpdateHouseLabel(house_index);
                    return;
                }
                else if (Main.IsInRangeOfPoint(player.Position, entrace.interior, 2.0f) && player.Dimension == 500 + (uint)house_index)
                {
                    bool can_pass = false;
                    for (int i = 0; i < 9; i++)
                    {
                        if (entrace.key_acess[i] == player.GetData("character_name"))
                        {
                            can_pass = true;
                        }
                    }

                    if (entrace.owner == AccountManage.GetPlayerSQLID(player))
                    {
                        can_pass = true;
                    }

                    if (can_pass == false)
                    {
                        Main.SendErrorMessage(player, "Sie hatten die Schlüssel zu diesem Haus nicht.");
                        return;
                    }
                    if (entrace.locked == 1)
                    {
                        Main.SendSuccessMessage(player, "Du hast dein " + Main.EMBED_LIGHTGREEN + "dein Zuhause freigeschaltet" + Main.EMBED_WHITE + ".");
                        entrace.locked = 0;
                    }
                    else
                    {
                        Main.SendSuccessMessage(player, "Du hast dein " + Main.EMBED_RED + "dein Zuhause gesperrt" + Main.EMBED_WHITE + " .");
                        entrace.locked = 1;
                    }
                    HouseSystem.UpdateHouseLabel(house_index);

                    return;
                }
                house_index++;
            }
        }
        else if (objectName == "Haus verkaufen")
        {
            int index = 0;
            foreach (var entrace in HouseSystem.HouseInfo)
            {
                if (Main.IsInRangeOfPoint(player.Position, entrace.exterior, 2.0f) && player.Dimension == 0)
                {
                    if (entrace.owner != AccountManage.GetPlayerSQLID(player))
                    {
                        SendNotificationError(player, "Dieses Haus gehört nicht Ihnen, um es zu verkaufen.");
                        return;
                    }

                    Main.SendMessageWithTagToPlayer(player, "" + Main.EMBED_GROVE + "Eigenschaft", "" + Main.EMBED_WHITE + "Sie haben dieses Haus von verkauft $" + entrace.price.ToString("N0") + ". " + Main.EMBED_LIGHTRED + "Alle Gegenstände, Möbel, Geld im Safe wurden unter anderem entfernt.");

                    Main.GivePlayerMoney(player, entrace.price);

                    // Entrce Name
                    entrace.owner = -1;
                    entrace.owner_name = "";
                    entrace.locked = 1;
                    entrace.safe = 0;

                    for (int i = 0; i < 9; i++)
                    {
                        entrace.key_acess[i] = "0";
                    }



                    for (int id = 0; id < 60; id++)
                    {
                        if (entrace.furniture_position[id].X != 0 && entrace.furniture_position[id].Y != 0)
                        {
                            Main.CreateMySqlCommand("DELETE FROM `furnitures` WHERE `id` = " + entrace.furniture_id[id] + ";");

                            entrace.furniture_id[id] = -1;
                            entrace.furniture_name[id] = "";
                            entrace.furniture_model_name[id] = "";
                            entrace.furniture_model[id] = 0;
                            entrace.furniture_price[id] = 0;
                            entrace.furniture_status[id] = 0;

                            entrace.furniture_position[id] = new Vector3(0, 0, 0);
                            entrace.furniture_rotation[id] = new Vector3(0, 0, 0);
                            entrace.furniture_handle[id].Delete();

                            HouseSystem.UpdateFurniture(index);
                        }
                    }

                    HouseSystem.UpdateHouseLabel(index);
                    //
                    HouseSystem.SaveEntrace(index);

                    return;
                }
                index++;
            }
        }
        else if (objectName == "Infos über meinen Bürger")
        {
            ShowPlayerInfos(player, player);
        }
        else if (objectName == "Bekleidung")
        {
            ShowPlayerBekleidungInteractMenu(player);
        }
        else if (objectName == "Waffen")
        {
            ShowPlayerWeaponsMenu(player);
        }
        else if (objectName == "Aktuelle Position")
        {
            playerCommands.ShowPosition(player);
        }
        else if (objectName == "Tastaturbelegung")
        {
            ShowPlayerKeyboardInteractMenu(player);
        }
        else if (objectName == "Dimension")
        {
            player.Dimension = 0;
            AccountManage.SaveCharacter(player);
            Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"Die Dimension deines Charakters wurde wiederhergestellt.", 5000);
        }
        else if (objectName == "Unterlagen")
        {
            ShowPlayerDokumenteInteractMenu(player);
        }
        else if (objectName == "Fahrzeug Menü")
        {
            ShowPlayerVehicleSystemMenu(player);
        }
        else if (objectName == "Charakter")
        {
            ShowPlayerCharakterInteractMenu(player);
        }
        else if (objectName == "Bürger Menü")
        {
            ShowPlayerInteractSystemMenu(player);
        }
        else if (objectName == "Animationen")
        {
            animationCommands.ShowAnimationMenu(player);
        }
        else if (objectName == "Admin System")
        {
            ShowAdminInteractMenu(player);
        }
        else if (objectName == "System")
        {
            ShowAdminInteractSystemMenu(player);
        }
        else if (objectName == "Ban System")
        {
            BannedManage.Bannedlist(player);
        }
        else if (objectName == "Admin Fahrzeug spawnen")
        {
            adminCommands.CMD_adveh(player);
        }
        else if (objectName == "Admin Fahrzeug löschen")
        {
            adminCommands.CMD_delveh(player);

        }
        else if (objectName == "Whitelist System")
        {
            WhitelistManage.LoadWhiteList(player);
        }
        else if (objectName == "Purge / Noose Einsatz")
        {
            adminCommands.CMD_purgebanned2(player);
        }
        else if (objectName == "Flying")
        {
            adminCommands.startFreemode(player);
        }
        else if (objectName == "Online Spieler")
        {
            if (player.GetData("status") == false)
            {
                return;
            }

            List<dynamic> menu_item_list = new List<dynamic>();
            int count = 0, online = 0;
            for (var i = 0; i < Main.MAX_PLAYERS; i++)
            {
                if (Main.players[i] != null)
                {

                    if (Main.players[i].GetData("status") == true)
                    {
                        if (FactionManage.GetPlayerGroupType(Main.players[i]) == 1 && Main.players[i].GetData("duty") == 1)
                        {
                            menu_item_list.Add(new { ID = i, Name = UsefullyRP.GetPlayerNameToTarget(Main.players[i], player), Ping = Main.players[i].Ping, Level = Main.players[i].GetData("character_level"), Color = "#7676E2" });
                        }
                        else if (FactionManage.GetPlayerGroupType(Main.players[i]) == 2 && Main.players[i].GetData("duty") == 1)
                        {
                            menu_item_list.Add(new { ID = i, Name = UsefullyRP.GetPlayerNameToTarget(Main.players[i], player), Ping = Main.players[i].Ping, Level = Main.players[i].GetData("character_level"), Color = "#ED9FA0" });
                        }
                        else
                        {
                            menu_item_list.Add(new { ID = i, Name = UsefullyRP.GetPlayerNameToTarget(Main.players[i], player), Ping = Main.players[i].Ping, Level = Main.players[i].GetData("character_level"), Color = "#000000" });
                        }

                        player.SetData("ListTrack_" + count + "", UsefullyRP.GetPlayerNameToTarget(Main.players[i], player));
                    }
                    else
                    {
                        menu_item_list.Add(new { ID = i, Name = Main.players[i].Name, Ping = Main.players[i].Ping, Level = 0, Color = "#5C5C5C" });
                        player.SetData("ListTrack_" + count + "", Main.players[i].Name);
                    }
                    online++;
                }
                count++;
            }
            player.SetData("Global_Browser", true);

            player.TriggerEvent("Display_Player_List", JsonConvert.SerializeObject(menu_item_list), online, Main.MAX_PLAYERS);
        }
        else if (objectName == "Wetter System")
        {
            ShowAdminWeatherInteractSystemMenu(player);
        }
        else if (objectName == "Waffen wegscheissen")
        {
                    WeaponManage.RemoveAllWeaponEx(player);
                    NAPI.Player.RemoveAllPlayerWeapons(player);
                    WeaponManage.SaveWeapons(player);
                    AccountManage.SaveCharacter(player);
        }
        else if (objectName == "Wetter 1")
        {
            NAPI.World.SetWeather(Main.weather_list[1].name);
        }
        else if (objectName == "Wetter 2")
        {
            NAPI.World.SetWeather(Main.weather_list[2].name);
        }
        else if (objectName == "Wetter 3")
        {
            NAPI.World.SetWeather(Main.weather_list[3].name);
        }
        else if (objectName == "Wetter 4")
        {
            NAPI.World.SetWeather(Main.weather_list[4].name);
        }
        else if (objectName == "Wetter 5")
        {
            NAPI.World.SetWeather(Main.weather_list[5].name);
        }
        else if (objectName == "Wetter 6")
        {
            NAPI.World.SetWeather(Main.weather_list[6].name);
        }
        else if (objectName == "Wetter 7")
        {
            NAPI.World.SetWeather(Main.weather_list[7].name);
        }
        else if (objectName == "Wetter 8")
        {
            NAPI.World.SetWeather(Main.weather_list[8].name);
        }
        else if (objectName == "Wetter 9")
        {
            NAPI.World.SetWeather(Main.weather_list[9].name);
        }
        else if (objectName == "Wetter 10")
        {
            NAPI.World.SetWeather(Main.weather_list[10].name);
        }
        else if (objectName == "Wetter 11")
        {
            NAPI.World.SetWeather(Main.weather_list[11].name);
        }
        else if (objectName == "Fahrzeug Repair")
        {
            adminCommands.fixVeh(player);
        }
        else if (objectName == "Wiederbeleben")
        {
            adminCommands.CMD_reviveme(player);
        }
        else if (objectName == "Teleportar")
        {
            adminCommands.CMD_teleportar(player);
        }
        else if (objectName == "Skins")
        {
            ShowAdminInteractSkinsMenu(player);
        }
        else if (objectName == "MountainLion")
        {
            adminCommands.ChangeSkinCommand1(player);
        }
        else if (objectName == "Pigeon")
        {
            adminCommands.ChangeSkinCommand2(player);
        }
        else if (objectName == "Pug")
        {
            adminCommands.ChangeSkinCommand3(player);
        }
        else if (objectName == "Shepherd")
        {
            adminCommands.ChangeSkinCommand4(player);
        }
        else if (objectName == "Retriever")
        {
            adminCommands.ChangeSkinCommand5(player);
        }
        else if (objectName == "Poodle")
        {
            adminCommands.ChangeSkinCommand6(player);
        }
        else if (objectName == "Cat")
        {
            adminCommands.ChangeSkinCommand7(player);
        }
        else if (objectName == "Abschalten")
        {
            adminCommands.ChangeSkinCommand8(player);
        }
        else if (objectName == "Identität anzeigen nur sich selbst")
        {
            ShowPlayerIDCard(player, player);
        }
        else if (objectName == "Lizenzen anzeigen nur sich selbst")
        {
            ShowPlayerLicenses(player, player);
        }
        else if (objectName == "Cop Ausweis anzeigen")
        {
            ShowPlayerFactionIDCard(player, player);
        }
        else if (objectName == "FIB Ausweis anzeigen")
        {
            ShowPlayerFactionIDCard(player, player);
        }
        else if (objectName == "President Ausweis anzeigen")
        {
            ShowPlayerFactionIDCard(player, player);
        }
        else if (objectName == "Medic Ausweis anzeigen")
        {
            ShowPlayerFactionIDCard(player, player);
        }
        else if (objectName == "Army Ausweis anzeigen")
        {
            ShowPlayerFactionIDCard(player, player);
        }
        else if (objectName == "Nagelbrett legen & aufheben")
        {
            policeCommands.CMD_nagelbrett(player);
        }
        else if (objectName == "Fahrzeug Tanken")
        {
            int business_id = Business.GetPlayerInBusinessInType(player, 5);
            if (business_id != -1)
            {
                int pump_id = FuelBusiness.GetClosestGasPump(player, business_id);
                if (pump_id != -1)
                {
                    FuelBusiness.CMD_tanken(player);
                }
            }
        }
        else if (objectName == "Kaufen Sie 20L Benzin Kanister")
        {
            int business_id = Business.GetPlayerInBusinessInType(player, 5);
            if (business_id != -1)
            {
                int pump_id = FuelBusiness.GetClosestGasPump(player, business_id);
                if (pump_id != -1)
                {
                    if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 46, 1, Inventory.Max_Inventory_Weight(player)))
                    {
                        return;
                    }

                    int price = (Business.business_list[business_id].business_fuel_price * 20) + 50;
                    SendNotificationSuccess(player, "Sie haben 1x 20 Liter Benzin Kanister gekauft für: ~b~$" + price + "~w~.");
                    Inventory.GiveItemToInventory(player, 46, 1);
                    Main.GivePlayerMoney(player, -price);
                }
            }
        }
        else if (objectName == "Akzeptiere den Tod")
        {
            if (player.GetSharedData("Injured") != 1)
            {
                Main.ShowColorShardAll(player, "~y~Du bist gestorben", "Möge es dir im Himmel besser gehen.", 2, 10, 6500);
                return;
            }

            if (player.GetSharedData("Injured") == 1)
            {
                if (player.GetSharedData("InjuredTime") > 0)
                {
                    SendNotificationError(player, "Sie sind noch nicht bereit, Bitte warten Sie. ~b~" + player.GetSharedData("InjuredTime") + "~w~ Sekunden.");
                    return;
                }
                Main.sendToHospital(player);
            }
        }
        else if (objectName == "Arzt anrufen")
        {
            SendNotificationInfo(player, "Um einen Arzt anzurufen, öffnen Sie Ihr Telefon und wählen Sie die Nummer ~b~912~w~.");
            return;
        }
        else if (objectName == "Einladung zur Fraktion annehmen")
        {
            if (player.GetData("group_invite") == -1)
            {
                SendNotificationError(player, "Sie wurden zu keiner Fraktion eingeladen oder die Einladung ist abgelaufen.");
                return;
            }
            int group_id = player.GetData("group_invite");
            Client inviteBy = NAPI.Data.GetEntityData(player, "group_inviteBy");

            if (Main.IsPlayerLogged(inviteBy) == true)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Sie haben die Einladung von angenommen" + FactionManage.faction_data[group_id].faction_rank[AccountManage.GetPlayerRank(inviteBy)] + " " + AccountManage.GetCharacterName(inviteBy) + ", und jetzt bist du ein Mitglied von " + FactionManage.faction_data[group_id].faction_name + ".");
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

                SendNotificationError(player, "Der Bürger, der Sie zur Fraktion eingeladen hat, ist nicht mehr verfügbar.");
            }

            return;
        }
        else if (objectName == "Einladung zur Fraktion ablehnen")
        {
            if (player.GetData("group_invite") != -1)
            {
                SendNotificationError(player, "Sie wurden zu keiner Fraktion eingeladen oder die Einladung ist abgelaufen.");
                return;
            }

            int group_id = player.GetData("group_invite");
            Client inviteBy = NAPI.Data.GetEntityData(player, "group_inviteBy");

            if (Main.IsPlayerLogged(inviteBy) == true)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Sie haben die Einladung von abgelehnt " + FactionManage.faction_data[group_id].faction_rank[AccountManage.GetPlayerRank(inviteBy)] + " " + AccountManage.GetCharacterName(inviteBy) + ", um die Fraktion zu betreten " + FactionManage.faction_data[group_id].faction_name + ".");
                NAPI.Notification.SendNotificationToPlayer(inviteBy, "~y~[INFO]:~w~ " + AccountManage.GetCharacterName(player) + " lehnte die Einladung ab, sich seiner Fraktion anzuschließen.");

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

                SendNotificationSuccess(player, "Sie haben die Fraktionseinladung abgelehnt.");
            }
            return;
        }
        else if (objectName == "Akzeptiere Strafe")
        {
            if (player.HasData("ticketOffer") && player.GetData("ticketOffer") == true)
            {
                if (AccountManage.GetPlayerConnected(NAPI.Data.GetEntityData(player, "ticketOfferBy")))
                {
                    if (Main.GetPlayerMoney(player) < NAPI.Data.GetEntityData(player, "ticketOfferPrice"))
                    {
                        SendNotificationError(player, "Du hast nicht $" + player.GetData("ticketOfferPrice") + " zur Verfügung, um diese Strafe zu zahlen.");
                        return;
                    }
                    Client target = NAPI.Data.GetEntityData(player, "ticketOfferBy");
                    Main.SendInfoMessage(target, "Der Spieler " + AccountManage.GetCharacterName(player) + " akzeptierte seine Geldstrafe von $" + player.GetData("ticketOfferPrice") + ".");
                    NAPI.Notification.SendNotificationToPlayer(player, "Sie haben die Geldstrafe von angenommen " + AccountManage.GetCharacterName(target) + " de $" + player.GetData("ticketOfferPrice") + ".");

                    Main.GivePlayerMoney(player, -NAPI.Data.GetEntityData(player, "ticketOfferPrice"));
                    player.ResetData("ticketOffer");
                    player.ResetData("ticketOfferBy");
                    player.ResetData("ticketOfferPrice");
                    return;
                }
                else SendNotificationError(player, "Der Bürger, der das Ticket gesendet hat, ist nicht online.");
            }
            else SendNotificationError(player, "Sie haben keine Geldstrafe zu akzeptieren..");
            player.ResetData("ticketOffer");
            player.ResetData("ticketOfferBy");
            player.ResetData("ticketOfferPrice");
        }
        else if (objectName == "Strafe ablehnen")
        {
            if (player.HasData("ticketOffer") && player.GetData("ticketOffer") == true)
            {
                if (AccountManage.GetPlayerConnected(NAPI.Data.GetEntityData(player, "ticketOfferBy")))
                {
                    Client target = NAPI.Data.GetEntityData(player, "ticketOfferBy");
                    Main.SendInfoMessage(target, "Der Bürger ~y~" + AccountManage.GetCharacterName(player) + " abgelehnt~w~ deine Geldstrafe ~g~$" + player.GetData("ticketOfferPrice") + "~w~.");
                    NAPI.Notification.SendNotificationToPlayer(player, "Du hast abgelehnt~w~ die Strafe ~y~" + AccountManage.GetCharacterName(target) + "~w~ von ~g~$" + player.GetData("ticketOfferPrice") + ".");

                    player.ResetData("ticketOffer");
                    player.ResetData("ticketOfferBy");
                    player.ResetData("ticketOfferPrice");
                    return;
                }
                else SendNotificationError(player, "Der Bürger, der das Ticket gesendet hat, ist nicht online.");
            }
            else SendNotificationError(player, "Sie haben keine Geldstrafe zu akzeptieren.");
            player.ResetData("ticketOffer");
            player.ResetData("ticketOfferBy");
            player.ResetData("ticketOfferPrice");
            return;
        }
        else if (objectName == "Akzeptiere Heilung")
        {
            if (player.GetData("curar_offerPrice") != -1)
            {
                if (!AccountManage.GetPlayerConnected(NAPI.Data.GetEntityData(player, "curar_offerBy")))
                {
                    player.SetData("curar_offerBy", -1);
                    player.SetData("curar_offerPrice", 0);

                    SendNotificationError(player, "Der Arzt, der Ihnen eine Kur angeboten hat, ist nicht da oder Sie haben kein Heilangebot erhalten.");
                    return;
                }
                if (Main.GetPlayerMoney(player) < player.GetData("curar_offerPrice"))
                {
                    player.SetData("curar_offerBy", -1);
                    player.SetData("curar_offerPrice", 0);
                    SendNotificationError(player, "Sie haben nicht genug Geld, um medizinische Versorgung in Anspruch zu nehmen.");
                    return;
                }

                if (!Main.IsInRangeOfPoint(player.Position, NAPI.Entity.GetEntityPosition(NAPI.Data.GetEntityData(player, "curar_offerBy")), 30))
                {
                    player.SetData("curar_offerBy", -1);
                    player.SetData("curar_offerPrice", 0);
                    SendNotificationError(player, "Sie sind nicht in der Nähe des Arztes, der Sie medizinisch versorgt hat.");
                    return;
                }

                NAPI.Player.SetPlayerHealth(player, 100);

                //NAPI.Notification.SendNotificationToPlayer(player, "Sie haben die medizinische Versorgung angenommen~y~" + AccountManage.GetCharacterName(player, "curar_offerBy") + "~w~ und zahlen ~g~R$" + player.GetData("curar_offerPrice").ToString("N0") + "~w~.");
                //NAPI.Notification.SendNotificationToPlayer(player.GetData("curar_offerBy"), "Der Patient ~y~" + AccountManage.GetCharacterName(player) + "~w~ hat angenommen und zahlt ~g~R$" + player.GetData("curar_offerPrice").ToString("N0") + "~w~.");

                Main.GivePlayerMoney(player, -player.GetData("curar_offerPrice"));
                Main.GivePlayerMoney(NAPI.Data.GetEntityData(player, "curar_offerBy"), player.GetData("curar_offerPrice"));

                player.SetData("curar_offerBy", -1);
                player.SetData("curar_offerPrice", 0);
            }
            else
            {
                SendNotificationError(player, "Nenhum um médico lhe enviou uma oferta de cura.");
            }
            return;
        }
        else if (objectName == "Heilung ablehnen")
        {
            if (player.GetData("curar_offerPrice") != 0)
            {
                player.SetData("curar_offerBy", -1);
                player.SetData("curar_offerPrice", 0);
                SendNotification(player, "Sie haben die Heilungsanfrage abgelehnt, die der Arzt Ihnen geschickt hat.");
            }
            return;
        }
        else if (objectName == "Bankraub starten")
        {
            bankRobbery.CMD_roubarbanco(player);
            return;
        }
        else if (objectName == "Bankraub ein/ausschalten")
        {
            bankRobbery.CMD_ativarbanco(player);
            return;
        }
        else if (objectName == "Auto Parken")
        {
            PlayerVehicle.CMD_estacionar(player);
            return;
        }
        else if (objectName == "Fahrzeug schließen")
        {
            if (player.IsInVehicle && player.VehicleSeat == -1)
            {
                Vehicle vehicle = player.Vehicle;
                int playerid = Main.getIdFromClient(player);


                for (int index = 0; index < PlayerVehicle.MAX_PLAYER_VEHICLES; index++)
                {
                    if (PlayerVehicle.vehicle_data[playerid].state[index] == 1 && PlayerVehicle.vehicle_data[playerid].handle[index].Exists && vehicle == PlayerVehicle.vehicle_data[playerid].handle[index])
                    {
                        if (NAPI.Vehicle.GetVehicleLocked(vehicle) == false)
                        {
                            NAPI.Vehicle.SetVehicleLocked(vehicle, true);
                            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben Ihr Fahrzeug verriegelt !");
                        }
                        return;
                    }
                }

                for (int i = 0; i < FactionManage.MAX_FACTION_VEHICLES; i++)
                {

                    if (FactionManage.faction_data[AccountManage.GetPlayerGroup(player)].faction_vehicle_owned[i] != "Niemand" && FactionManage.faction_data[AccountManage.GetPlayerGroup(player)].faction_vehicle_entity[i] == vehicle)
                    {
                        if (NAPI.Vehicle.GetVehicleLocked(vehicle) == false)
                        {

                            NAPI.Vehicle.SetVehicleLocked(vehicle, true);
                            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben Ihr Fahrzeug verriegelt !");
                        }
                        return;
                    }
                }

                for (int b = 0; b < RentVehicle.MAX_RENT_VEHICLES; b++)
                {
                    if (RentVehicle.vehicle_rent_list[b].vehicle_free == true && RentVehicle.vehicle_rent_list[b].vehicle_ownedBy == AccountManage.GetPlayerSQLID(player) && RentVehicle.vehicle_rent_list[b].vehicle_entity == vehicle)
                    {
                        if (NAPI.Vehicle.GetVehicleLocked(vehicle) == false)
                        {
                            NAPI.Vehicle.SetVehicleLocked(vehicle, true);
                            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben Ihr Fahrzeug verriegelt !");
                        }
                        return;
                    }
                }

                return;

            }
            return;
        }
        else if (objectName == "Fahrzeug öffnen")
        {

            if (player.IsInVehicle && player.VehicleSeat == -1)
            {
                Vehicle vehicle = player.Vehicle;
                int playerid = Main.getIdFromClient(player);

                for (int index = 0; index < PlayerVehicle.MAX_PLAYER_VEHICLES; index++)
                {
                    if (PlayerVehicle.vehicle_data[playerid].state[index] == 1 && PlayerVehicle.vehicle_data[playerid].handle[index].Exists && vehicle == PlayerVehicle.vehicle_data[playerid].handle[index])
                    {
                        if (NAPI.Vehicle.GetVehicleLocked(vehicle) == true)
                        {
                            NAPI.Vehicle.SetVehicleLocked(vehicle, false);
                           // player.TriggerEvent("createNewHeadNotificationAdvanced", "Du hast  ~g~geöffnet~w~ dieses Fahrzeug");
                            NAPI.Notification.SendNotificationToPlayer(player, "Du hast dieses Fahrzeug ~g~geöffnet~w~!");
                        }

                        return;
                    }
                }

                for (int i = 0; i < FactionManage.MAX_FACTION_VEHICLES; i++)
                {

                    if (FactionManage.faction_data[AccountManage.GetPlayerGroup(player)].faction_vehicle_owned[i] != "Niemand" && FactionManage.faction_data[AccountManage.GetPlayerGroup(player)].faction_vehicle_entity[i] == vehicle)
                    {
                        if (NAPI.Vehicle.GetVehicleLocked(vehicle) == true)
                        {
                            NAPI.Vehicle.SetVehicleLocked(vehicle, false);
                           // player.TriggerEvent("createNewHeadNotificationAdvanced", "Du hast  ~g~geöffnet~w~ dieses Fahrzeug");
                            NAPI.Notification.SendNotificationToPlayer(player, "Du hast dieses Fahrzeug ~g~geöffnet~w~!");
                        }

                        return;
                    }
                }

                for (int b = 0; b < RentVehicle.MAX_RENT_VEHICLES; b++)
                {
                    if (RentVehicle.vehicle_rent_list[b].vehicle_free == true && RentVehicle.vehicle_rent_list[b].vehicle_ownedBy == AccountManage.GetPlayerSQLID(player) && RentVehicle.vehicle_rent_list[b].vehicle_entity == vehicle)
                    {
                        if (NAPI.Vehicle.GetVehicleLocked(vehicle) == true)
                        {
                            NAPI.Vehicle.SetVehicleLocked(vehicle, false);
                           // player.TriggerEvent("createNewHeadNotificationAdvanced", "Du hast  ~g~geöffnet~w~ dieses Fahrzeug");
                            NAPI.Notification.SendNotificationToPlayer(player, "Du hast dieses Fahrzeug ~g~geöffnet~w~!");
                        }

                        return;
                    }
                }

                return;

            }

            return;
        }
        else if (objectName == "Kofferaum")
        {
            if (player.Vehicle.Locked == true)
            {
                SendNotificationError(player, "Der Kofferraum des Fahrzeugs ist geschlossen, so dass Sie nicht darauf zugreifen können!");
                return;
            }
            VehicleInventory.ShowToPlayerVehicleInventory(player);
            return;
        }
        else if (objectName == "Tempomat")
        {
            int value = player.GetData("new_interact_menu_speedlimit");

            if (player.IsInVehicle)
            {
                if (value == 0)
                {
                    player.SetData("SpeedLimit", false);
                    player.TriggerEvent("speed_limiter_command", "off");
                    return;
                }

                value = value * 5;

                player.SetData("SpeedLimit", true);
                player.SetData("SpeedLimitValue", value);
                player.TriggerEvent("speed_limiter_command", value);
                Main.SendInfoMessage(player, "Tempolimit für Tempomat eingestellt auf " + Main.EMBED_YELLOW + value + " KM/H" + Main.EMBED_WHITE + ". " + Main.EMBED_GREY + "(Drücke ~y~L~c~ zum aufheben)");
            }
            return;
        }
        else if (objectName == "Firma")
        {
            int index = AccountManage.GetPlayerJob(player);

            if (index == 0)
            {
                SendNotificationError(player, "Sie haben keinen Job..");
                ShowPlayerInteractMenu(player);
                return;
            }

            List<dynamic> menu_item_list = new List<dynamic>();

            if (index == 2)
            {
                menu_item_list.Add(new { Type = 1, Name = "Arbeitsplatz finden", Description = "Legt ein GPS-Navigationsgerät fest, an dem Sie loslegen müssen, um zu beginnen." });
                menu_item_list.Add(new { Type = 1, Name = "Job beenden", Description = "", RightBadge = "Alert", Color = "OrangeRed", HighlightColor = "Tomato" });
                InteractMenu.CreateMenu(player, "PLAYER_JOB_MENU", "Emprego", "~g~Mecânico", false, JsonConvert.SerializeObject(menu_item_list), false, BackgroundColor: "SeaGreen");
            }
            else if (index == 3)
            {
                if (player.IsInVehicle && player.VehicleSeat == -1 && NAPI.Entity.GetEntityModel(player.Vehicle) == (uint)NAPI.Util.VehicleNameToModel("Taxi"))
                {
                    if (player.Vehicle.HasData("TransportDuty"))
                    {
                        menu_item_list.Add(new { Type = 1, Name = "Taximeter trennen", Description = "" });
                    }
                    else
                    {
                        List<string> list = new List<string>();
                        for (int i = 1; i <= 200; i++) list.Add("$" + i + " /10 s");
                        menu_item_list.Add(new { Type = 2, Name = "Taximeter", Description = "", List = list, StartIndex = player.GetData("new_interact_menu_taximetro") });
                    }
                }
                else
                {
                    menu_item_list.Add(new { Type = 1, Name = "Taximeter", Description = "Sie müssen sich in einem Taxi befinden,um den Taxameter zu starten.", RightBadge = "Lock" });
                }
                menu_item_list.Add(new { Type = 1, Name = "Arbeitsplatz finden", Description = "Legt ein GPS-Navigationsgerät fest, an dem Sie loslegen müssen, um zu beginnen." });
                menu_item_list.Add(new { Type = 1, Name = "Job beenden", Description = "", RightBadge = "Alert", Color = "OrangeRed", HighlightColor = "Tomato" });
                InteractMenu.CreateMenu(player, "PLAYER_JOB_MENU", "Firma", "~g~Job", false, JsonConvert.SerializeObject(menu_item_list), false, BackgroundColor: "SeaGreen");
            }
            else if (index == 4)
            {
                menu_item_list.Add(new { Type = 1, Name = "Arbeitsplatz finden", Description = "Legt ein GPS-Navigationsgerät fest, an dem Sie loslegen müssen, um zu beginnen." });
                menu_item_list.Add(new { Type = 1, Name = "Job beenden", Description = "", RightBadge = "Alert", Color = "OrangeRed", HighlightColor = "Tomato" });
                InteractMenu.CreateMenu(player, "PLAYER_JOB_MENU", "Emprego", "~g~Job", false, JsonConvert.SerializeObject(menu_item_list), false, BackgroundColor: "SeaGreen");
            }
            else if (index == 5)
            {
                menu_item_list.Add(new { Type = 1, Name = "Arbeitsplatz finden", Description = "Legt ein GPS-Navigationsgerät fest, an dem Sie loslegen müssen, um zu beginnen." });
                menu_item_list.Add(new { Type = 1, Name = "Job beenden", Description = "", RightBadge = "Alert", Color = "OrangeRed", HighlightColor = "Tomato" });
                InteractMenu.CreateMenu(player, "PLAYER_JOB_MENU", "Lawn more", "~g~Job", false, JsonConvert.SerializeObject(menu_item_list), false, BackgroundColor: "SeaGreen");
            }
            else if (index == 6)
            {
                menu_item_list.Add(new { Type = 1, Name = "Arbeitsplatz finden", Description = "Legt ein GPS-Navigationsgerät fest, an dem Sie loslegen müssen, um zu beginnen." });
                menu_item_list.Add(new { Type = 1, Name = "Finden Sie den Verkaufsstandort", Description = "Stellen Sie ein GPS auf den Ort ein, an den Sie die Körner verkaufen müssen, die Sie geerntet haben." });
                menu_item_list.Add(new { Type = 1, Name = "Job beenden", Description = "", RightBadge = "Alert", Color = "OrangeRed", HighlightColor = "Tomato" });
                InteractMenu.CreateMenu(player, "PLAYER_JOB_MENU", "Emprego", "~g~Job", false, JsonConvert.SerializeObject(menu_item_list), false, BackgroundColor: "SeaGreen");
            }
            else if (index == 7)
            {
                menu_item_list.Add(new { Type = 1, Name = "Arbeitsplatz finde", Description = "Legt ein GPS-Navigationsgerät fest, an dem Sie loslegen müssen, um zu beginnen." });
                menu_item_list.Add(new { Type = 1, Name = "Job beenden", Description = "", RightBadge = "Alert", Color = "OrangeRed", HighlightColor = "Tomato" });
                InteractMenu.CreateMenu(player, "PLAYER_JOB_MENU", "Job", "~g~Job", false, JsonConvert.SerializeObject(menu_item_list), false, BackgroundColor: "SeaGreen");
            }
            else if (index == 8)
            {
                menu_item_list.Add(new { Type = 1, Name = "Arbeitsplatz finde", Description = "Legt ein GPS-Navigationsgerät fest, an dem Sie loslegen müssen, um zu beginnen." });
                menu_item_list.Add(new { Type = 1, Name = "Job beenden", Description = "", RightBadge = "Alert", Color = "OrangeRed", HighlightColor = "Tomato" });
                InteractMenu.CreateMenu(player, "PLAYER_JOB_MENU", "Job", "~g~Job", false, JsonConvert.SerializeObject(menu_item_list), false, BackgroundColor: "SeaGreen");
            }
            else if (index == 9)
            {
                menu_item_list.Add(new { Type = 1, Name = "Arbeitsplatz finde", Description = "Legt ein GPS-Navigationsgerät fest, an dem Sie loslegen müssen, um zu beginnen." });
                menu_item_list.Add(new { Type = 1, Name = "Job beenden", Description = "", RightBadge = "Alert", Color = "OrangeRed", HighlightColor = "Tomato" });
                InteractMenu.CreateMenu(player, "PLAYER_JOB_MENU", "Job", "~g~Job", false, JsonConvert.SerializeObject(menu_item_list), false, BackgroundColor: "SeaGreen");
            }
            else if (index == 10)
            {
                menu_item_list.Add(new { Type = 1, Name = "Arbeitsplatz finde", Description = "Legt ein GPS-Navigationsgerät fest, an dem Sie loslegen müssen, um zu beginnen." });
                menu_item_list.Add(new { Type = 1, Name = "Job beenden", Description = "", RightBadge = "Alert", Color = "OrangeRed", HighlightColor = "Tomato" });
                InteractMenu.CreateMenu(player, "PLAYER_JOB_MENU", "Job", "~g~Job", false, JsonConvert.SerializeObject(menu_item_list), false, BackgroundColor: "SeaGreen");
            }
            else if (index == 11)
            {
                menu_item_list.Add(new { Type = 1, Name = "Arbeitsplatz finde", Description = "Legt ein GPS-Navigationsgerät fest, an dem Sie loslegen müssen, um zu beginnen." });
                menu_item_list.Add(new { Type = 1, Name = "Job beenden", Description = "", RightBadge = "Alert", Color = "OrangeRed", HighlightColor = "Tomato" });
                InteractMenu.CreateMenu(player, "PLAYER_JOB_MENU", "Job", "~g~Job", false, JsonConvert.SerializeObject(menu_item_list), false, BackgroundColor: "SeaGreen");
            }
            else if (index == 12)
            {
                menu_item_list.Add(new { Type = 1, Name = "Arbeitsplatz finde", Description = "Legt ein GPS-Navigationsgerät fest, an dem Sie loslegen müssen, um zu beginnen." });
                menu_item_list.Add(new { Type = 1, Name = "Job beenden", Description = "", RightBadge = "Alert", Color = "OrangeRed", HighlightColor = "Tomato" });
                InteractMenu.CreateMenu(player, "PLAYER_JOB_MENU", "Job", "~g~Farmer", false, JsonConvert.SerializeObject(menu_item_list), false, BackgroundColor: "SeaGreen");
            }

        }
        else if (objectName == "Taximeter")
        {
            if (AccountManage.GetPlayerJob(player) != 3)
            {
                SendNotificationError(player, "Du bist kein Taxifahrer mehr..");
                return;
            }

            if (player.IsInVehicle && player.VehicleSeat == -1 && NAPI.Entity.GetEntityModel(player.Vehicle) == (uint)NAPI.Util.VehicleNameToModel("Taxi"))
            {
                if (!player.Vehicle.HasData("TransportDuty"))
                {
                    int price = player.GetData("new_interact_menu_taximetro") + 1;

                    if (price < 1 || price > 200)
                    {
                        Main.DisplayErrorMessage(player, "Der Tarif sollte zwischen 1 und 200 liegen.");
                        return;
                    }


                    player.Vehicle.SetData("TransportDuty", true);
                    player.Vehicle.SetData("TransportPrice", price);
                    player.Vehicle.SetData("TransportFee", 0);
                    player.Vehicle.SetData("TransportTime", 0);
                    player.Vehicle.SetData("TransportDriver", player);

                    NAPI.Notification.SendNotificationToPlayer(player, "Sie sind jetzt in Betrieb, Fahrpreis: ~y~$" + price.ToString("N0") + "~w~.");

                    if (!player.HasData("announceTaxi"))
                    {
                        player.SetData("announceTaxi", true);
                        NAPI.Task.Run(() =>
                        {

                            player.ResetData("announceTaxi");
                        }, delayTime: 10000);

                        //NAPI.Notification.SendNotificationToPlayer("~g~*Der Taxifahrer" + AccountManage.GetCharacterName(player) + "begann seine Arbeit, Preis: $" + price.ToString("N0") + ", Rufen Sie das Taxi 914 an, um ihn anzurufen.");

                    }
                    SendNotificationInfo(player, "Sie haben den Taxifahrer gerufen..");
                }
            }
        }
        else if (objectName == "Job beenden")
        {
            Main_Job.CMD_desempregar(player);
        }
        else if (objectName == "Arbeitsplatz finden")
        {
            int index = AccountManage.GetPlayerJob(player);

            if (index == 0)
            {
                Main.DisplayErrorMessage(player, "Du bist nicht in einer Fraktion..");
                ShowPlayerInteractMenu(player);
                return;
            }

            if (index == 2)
            {
                SendNotificationInfo(player, "GPS Definiert für den Job: ~y~Mechaniker~w~");
                player.TriggerEvent("gps_set_loc", 1381.848f, -2078.385f);
            }
            else if (index == 3)
            {
                SendNotificationInfo(player, "GPS Definiert für den Job: ~y~Taxifahrer~w~");
                player.TriggerEvent("gps_set_loc", 903.7703f, -173.278f);
            }
            else if (index == 4)
            {
                SendNotificationInfo(player, "GPS Definiert für den Job: ~y~Müllmann~w~");
                player.TriggerEvent("gps_set_loc", 1381.848f, -2078.385f);
            }
            else if (index == 6)
            {
                SendNotificationInfo(player, "GPS Definiert für den Jobo: ~y~Farmer~w~");
                player.TriggerEvent("gps_set_loc", 2832.978f, 4571.757f);
            }
            else if (index == 7)
            {
                SendNotificationInfo(player, "GPS Definiert für den Job: ~y~LS Go Postal~w~");
                player.TriggerEvent("gps_set_loc", 63.60947f, 121.3167f);
            }
            else if (index == 8)
            {
                SendNotificationInfo(player, "GPS Definiert für den Jobo: ~y~Busfahrer~w~");
                player.TriggerEvent("gps_set_loc", 460.5518f, -595.4134f);
            }
        }
        else if (objectName == "Finden Sie den Verkaufsstandort")
        {
            SendNotificationInfo(player, "GPS Definiert für: ~y~Korn Ankäufer");
            player.TriggerEvent("gps_set_loc", 2886.25f, 4386.166f);
        }
        else if (objectName == "Taximeter trennen")
        {

            if (player.IsInVehicle && player.VehicleSeat == -1 && NAPI.Entity.GetEntityModel(player.Vehicle) == (uint)NAPI.Util.VehicleNameToModel("Taxi"))
            {
                player.TriggerEvent("update_taxi_fare", false, 0, 0, false);

                var players_in_vehicle = NAPI.Pools.GetAllPlayers();
                foreach (var i in players_in_vehicle)
                {
                    if (i.GetData("status") == true && player.Vehicle == i.Vehicle && i.VehicleSeat != -1 && i.GetData("TaxiFee") > 0)
                    {
                        Main.GivePlayerMoney(i, -i.GetData("TaxiFee"));
                        i.SetData("TaxiFee", 0);
                        i.SendChatMessage("~y~*~w~ Der Taxifahrer hat den Dienst verlassen, Sie haben  bezahlt ~g~$" + i.GetData("TaxiFee").ToString("N0") + "~w~ an den Taxifahrer.");
                        i.TriggerEvent("update_taxi_fare", false, 0, 0, false);
                    }
                }

                player.Vehicle.SetData("TransportDuty", false);
                player.Vehicle.SetData("TransportPrice", 0);
                player.Vehicle.SetData("TransportFee", 0);
                player.Vehicle.SetData("TransportTime", 0);
                player.Vehicle.ResetData("TransportDuty");

                SendNotificationInfo(player, "Sie haben den Taxameter ausgeschaltet.");
            }
        }
        else if (objectName == "Fraktion")
        {
            int index = AccountManage.GetPlayerGroup(player);

            if (index == 0)
            {
                SendNotificationError(player, "Du bist nicht in einer Fraktion..");
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
        else if (objectName == "Botschaft des Tages")
        {
            int index = AccountManage.GetPlayerGroup(player);

            InteractMenu.User_Input(player, "interact_faction_motd", "Botschaft des Tages", FactionManage.faction_data[index].faction_motd);
        }
        else if (objectName == "Bürgerschaft Benachrichtigung")
        {
            int index = AccountManage.GetPlayerGroup(player);

            InteractMenu.User_Input(player, "interact_faction_rplerinfo", "Bürgerschaft Benachrichtigung", FactionManage.faction_data[index].faction_rplerinfo);
        }
        else if (objectName == "Mitglieder verwalten")
        {
            int index = AccountManage.GetPlayerGroup(player);

            using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
            {
                Mainpipeline.Open();
                MySqlCommand query = new MySqlCommand("SELECT `name`, `leader`, `group`, `group_rank` FROM characters WHERE `group` = " + index + " ORDER BY `group_rank` DESC;", Mainpipeline);
                using (MySqlDataReader reader = query.ExecuteReader())
                {
                    var count = 0;

                    List<dynamic> menu_item_list = new List<dynamic>();
                    while (reader.Read())
                    {
                        string name = reader.GetString("name");
                        int leader = reader.GetInt32("leader");
                        int group = reader.GetInt32("group");
                        int group_rank = reader.GetInt32("group_rank");

                        if (leader != 0)
                        {
                            menu_item_list.Add(new { Type = 1, Name = "~c~" + count + ".~s~ " + name.Replace("_", " ") + "", Description = "", RightBadge = "Crown", Color = "Gold", HighlightColor = "Goldenrod" });
                        }
                        else
                        {
                            menu_item_list.Add(new { Type = 1, Name = "~c~" + count + ".~s~ " + name.Replace("_", " ") + "", Description = "", RightLabel = "~c~" + FactionManage.faction_data[index].faction_rank[group_rank] + "" });

                        }

                        player.SetData("ListTrack_" + count, name);
                        count++;
                    }
                    if (count == 0) return;
                    InteractMenu.CreateMenu(player, "PLAYER_FACTION_MENU_MEMBER", "Fraktion", "~b~" + FactionManage.faction_data[index].faction_name + "", false, JsonConvert.SerializeObject(menu_item_list), false);
                }
            }
        }
        else if (objectName == "Hierarchie verwalten")
        {
            int index = AccountManage.GetPlayerGroup(player);

            List<dynamic> menu_item_list = new List<dynamic>();
            for (int i = 0; i < FactionManage.MAX_FACTION_RANK; i++)
            {
                if (FactionManage.faction_data[index].faction_rank[i] == "undefiniert")
                {
                    menu_item_list.Add(new { Type = 4, Name = "Rank " + i + ".", Description = "", RightLabel = "~c~undefiniert" });
                }
                else
                {
                    menu_item_list.Add(new { Type = 4, Name = "Rank " + i + ".", Description = "", RightLabel = "~s~" + FactionManage.faction_data[index].faction_rank[i] + "" });
                }

            }
            InteractMenu.CreateMenu(player, "PLAYER_FACTION_MENU_HIERARQUIA", "Fraktion", "~b~" + FactionManage.faction_data[index].faction_name + " - befördern/degradieren", false, JsonConvert.SerializeObject(menu_item_list), false);
        }

        else if (objectName == "Liste der Mitglieder")
        {
            int index = AccountManage.GetPlayerGroup(player);

            using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
            {
                Mainpipeline.Open();
                MySqlCommand query = new MySqlCommand("SELECT `name`, `leader`, `group`, `group_rank` FROM characters WHERE `group` = " + index + " ORDER BY `group_rank` DESC; ", Mainpipeline);
                using (MySqlDataReader reader = query.ExecuteReader())
                {
                    var count = 0;

                    List<dynamic> menu_item_list = new List<dynamic>();
                    while (reader.Read())
                    {
                        string name = reader.GetString("name");
                        int leader = reader.GetInt32("leader");
                        int group = reader.GetInt32("group");
                        int group_rank = reader.GetInt32("group_rank");

                        if (leader != 0)
                        {
                            menu_item_list.Add(new { Type = 1, Name = "~c~" + count + ".~s~ " + name.Replace("_", " ") + "", Description = "", RightBadge = "Crown", Color = "Gold", HighlightColor = "Goldenrod" });
                        }
                        else
                        {
                            menu_item_list.Add(new { Type = 1, Name = "~c~" + count + ".~s~ " + name.Replace("_", " ") + "", Description = "", RightLabel = "~c~" + FactionManage.faction_data[index].faction_rank[group_rank] + "" });

                        }
                        player.SetData("ListTrack_" + count, name);
                        count++;
                    }
                    if (count == 0) return;
                    InteractMenu.CreateMenu(player, "NULL", "Fraktion", "~b~" + FactionManage.faction_data[index].faction_name + "", false, JsonConvert.SerializeObject(menu_item_list), false);
                }

            }
        }
        else if (objectName == "Leitstelle")
        {
            if (player.GetData("duty") == 0)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Sie sind nicht im Dienst.");
            }
            else if (player.GetData("duty") == 1)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Sie sind die Leitstelle.");
                player.TriggerEvent("getLeitstelle");
                //player.TriggerEvent("leitstelleToggle");

            }
        }
        else if (objectName == "Dienst melden")
        {
            if (AccountManage.GetPlayerGroup(player) == 15)
            {
                if (player.GetData("duty") == 0)
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "Du bist in den Dienst gegangen!");
                    player.SetData("duty", 1);
                }
                else if (player.GetData("duty") == 1)
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "Du bist aus den Dienst gegangen!");
                    player.SetData("duty", 0);
                }
            }
        }
        else if (objectName == "Fraktion verlassen")
        {
            NAPI.Data.SetEntityData(player, "duty", 0);
            Main.UpdatePlayerClothes(player);
            player.SetData("duty", 0);
            Outfits.RemovePlayerDutyOutfit(player);
            AccountManage.SetPlayerLeader(player, 0);
            AccountManage.SetPlayerGroup(player, 0);
            AccountManage.SetPlayerRank(player, 0);
            AccountManage.SaveCharacter(player);
            NAPI.Notification.SendNotificationToPlayer(player, "Du bist nun ein ~b~Zivilist~w~.");
            Main.SetPlayerToTeamColor(player);
        }
    }

    public static void ListItemMenuResponse(Client player, String callbackId, int selectedIndex, String objectName, String valueList, int valueIndex)
    {
        if (callbackId == "NEW_MENU_RESPONSE")
        {
            player.SetData("new_interact_menu_speedlimit", valueIndex);
        }
        else if (callbackId == "PLAYER_JOB_MENU")
        {
            player.SetData("new_interact_menu_taximetro", valueIndex);
        }
        else if (callbackId == "NEW_MENU_VEHICLE_RESPONSE")
        {
            if (objectName == "KFZ Strafe")
            {
                player.SetData("new_interact_menu_ticket", valueIndex);
            }
            else if (objectName == "Bürger aus Fahrzeug ziehen")
            {
                player.SetData("new_interact_vehicle_assento", valueIndex);
            }
        }
        else if (callbackId == "TARGET_MENU_RESPONSE")
        {
            if (objectName == "Geldstrafe")
            {
                player.SetData("new_interact_menu_ticket_player", valueIndex);
            }
            else if (objectName == "Ins Gefängis stecken")
            {
                player.SetData("new_interact_menu_arrest", valueIndex);
            }
            else if (objectName == "Heilen")
            {
                player.SetData("new_interact_menu_healing", valueIndex);
            }
            else if (objectName == "Gefangenen ins Auto setzten")
            {
                player.SetData("new_interact_menu_seat", valueIndex);
            }
        }
    }


    public static void SelectMenuResponse(Client player, String callbackId, int selectedIndex, String objectName, String valueList)
    {
        if (callbackId == "NEW_MENU_RESPONSE")
        {
            Responder_Menu(player, selectedIndex, objectName, valueList);
        }
        else if (callbackId == "PLAYER_FACTION_MENU")
        {
            Responder_Menu(player, selectedIndex, objectName, valueList);
        }
        else if (callbackId == "PLAYER_JOB_MENU")
        {
            Responder_Menu(player, selectedIndex, objectName, valueList);
        }
        else if (callbackId == "NEW_MENU_VEHICLE_RESPONSE")
        {
            Responder_Vehicle_Menu(player, selectedIndex, objectName, valueList);
        }
        else if (callbackId == "TARGET_MENU_RESPONSE")
        {
            Responder_Target_Menu(player, selectedIndex, objectName, valueList);
        }
        else if (callbackId == "TARGET_MENU_REMOVE_ITEM")
        {

            Client target = NAPI.Data.GetEntityData(player, "interact_target");
            if (!API.Shared.IsPlayerConnected(target))
            {
                SendNotificationError(player, "Dieser Bürger ist nicht mehr da.");
                return;
            }
            if (target.GetData("status") == false)
            {
                SendNotificationError(player, "Dieser Bürger ist nicht mehr da.");
                return;
            }
            if (!Main.IsInRangeOfPoint(player.Position, target.Position, 5.0f))
            {
                SendNotificationError(player, "Sie sind zu weit vom Bürger entfernt..");
                return;
            }
            int targetid = Main.getIdFromClient(target);

            string item = objectName;
            int amount = Inventory.GetPlayerItemFromInventory(target, Inventory.Item_Name_To_Type(item));

            if (amount < 1)
            {
                SendNotificationError(player, "Dieser Spieler besitzt diesen Gegenstand nicht mehr.");
                return;
            }

            Inventory.RemoveItem(target, item, amount);
            SendNotificationSuccess(player, "Du hast entfernt" + UsefullyRP.GetPlayerNameToTarget(target, player) + " folgendes " + item + ".");
            SendNotificationSuccess(target, "Der Offizier " + UsefullyRP.GetPlayerNameToTarget(player, target) + " entfernt folgendes " + item + " aus Ihrem Inventar.");
        }
    }

    public static void CheckBoxItemMenuResponse(Client player, String callbackId, int selectedIndex, String objectName, String valueList, bool _checked)
    {
        if (callbackId == "NEW_MENU_RESPONSE")
        {
            if (objectName == "Sicherheitsgurt")
            {
                UsefullyRP.CMD_seatbelt(player);
                return;
            }
            else if (objectName == "Motor einschalten")
            {
                Main.VehicleEngineStarting(player);
                return;
            }
            else if (objectName == "Motor ausschalten")
            {
                Main.VehicleEngineStarting(player);
                PlayerVehicle.CMD_estacionar(player);
                return;
            }
            else if (objectName == "Helm")
            {
                UsefullyRP.CMD_capacete(player);
                return;
            }
            else if (objectName == "Hut abnehmen")
            {
                player.SetAccessories(0, 0, 0);
                player.ClearAccessory(0);
                player.SetData("hats_enable", false);
                return;
            }
            else if (objectName == "Hut aufsetzen")
            {               
                player.SetAccessories(0, (int)NAPI.Data.GetEntitySharedData(player, "character_hats"), (int)NAPI.Data.GetEntitySharedData(player, "character_hats_texture"));
                player.SetData("hats_enable", true);
                return;
            }
            else if (objectName == "Brille abnehmen")
            {
                player.SetAccessories(1, 0, 0);
                player.ClearAccessory(1);
                player.SetData("glasses_enable", false);
                return;
            }
            else if (objectName == "Brille aufsetzen")
            {
                player.SetData("glasses_enable", true);
                player.SetAccessories(1, (int)NAPI.Data.GetEntitySharedData(player, "character_glasses"), (int)NAPI.Data.GetEntitySharedData(player, "character_glasses_texture"));
                return;
            }
            else if (objectName == "Kopfschmuck abnehmen")
            {
                player.SetAccessories(2, 0, 0);
                player.ClearAccessory(2);
                player.SetData("ears_enable", false);
                return;
            }
            else if (objectName == "Kopfschmuck aufsetzen")
            {
                if (NAPI.Data.GetEntityData(player, "CHARACTER_ONLINE_GENRE") == 0)
                {
                    player.SetData("ears_enable", true);
                    player.SetAccessories(2, (int)NAPI.Data.GetEntitySharedData(player, "character_ears"), (int)NAPI.Data.GetEntitySharedData(player, "character_ears_texture"));
                    return;
                }
                else
                {
                    player.SetData("ears_enable", true);
                    player.SetAccessories(2, (int)NAPI.Data.GetEntitySharedData(player, "character_ears"), (int)NAPI.Data.GetEntitySharedData(player, "character_ears_texture"));
                    return;
                }
            }
            else if (objectName == "Uhr abnehmen")
            {
                player.SetAccessories(6, 0, 0);
                player.ClearAccessory(6);
                player.SetData("watches_enable", false);
                return;
            }
            else if (objectName == "Uhr aufsetzen")
            {
                if (NAPI.Data.GetEntityData(player, "CHARACTER_ONLINE_GENRE") == 0)
                {
                    player.SetData("watches_enable", true);
                    player.SetAccessories(6, (int)NAPI.Data.GetEntitySharedData(player, "character_watches"), (int)NAPI.Data.GetEntitySharedData(player, "character_watches_texture"));
                    return;
                }
                else
                {
                    player.SetData("watches_enable", true);
                    player.SetAccessories(6, (int)NAPI.Data.GetEntitySharedData(player, "character_watches"), (int)NAPI.Data.GetEntitySharedData(player, "character_watches_texture"));
                    return;
                }
            }
            else if (objectName == "Oberteil")
            {
                var shirt = NAPI.Data.GetEntityData(player, "character_shirt");
                var shirt_texture = NAPI.Data.GetEntityData(player, "character_shirt_texture");

                if (NAPI.Data.GetEntityData(player, "shirt_enable") == true)
                {
                    if (NAPI.Data.GetEntityData(player, "CHARACTER_ONLINE_GENRE") == 0)
                    {
                        player.SetClothes(3, 15, 0);
                        player.SetClothes(11, 15, 0);
                        player.SetClothes(8, 15, 0);
                        player.SetData("shirt_enable", false);
                        NAPI.Data.SetEntitySharedData(player, "using_torso", false);
                        NAPI.Data.SetEntitySharedData(player, "using_shirt", false);
                        NAPI.Data.SetEntitySharedData(player, "using_undershirt", false);
                    }
                    else
                    {
                        player.SetClothes(3, 15, 0);
                        player.SetClothes(11, 15, 0);
                        player.SetClothes(8, 15, 0);
                        player.SetData("shirt_enable", false);
                        NAPI.Data.SetEntitySharedData(player, "using_torso", false);
                        NAPI.Data.SetEntitySharedData(player, "using_shirt", false);
                        NAPI.Data.SetEntitySharedData(player, "using_undershirt", false);
                    }
                }
                else
                {

                    UsefullyRP.charclothes[Main.getIdFromClient(player)] = true;
                    SendNotificationSuccess(player, "Du hast dein Oberteil angezogen.");
                    player.SetData("shirt_enable", true);
                    NAPI.Data.SetEntitySharedData(player, "using_torso", true);
                    NAPI.Data.SetEntitySharedData(player, "using_shirt", true);
                    NAPI.Data.SetEntitySharedData(player, "using_undershirt", true);
                    player.SetClothes(3, (int)NAPI.Data.GetEntitySharedData(player, "character_torso"), (int)NAPI.Data.GetEntitySharedData(player, "character_torso_texture"));
                    player.SetClothes(11, (int)NAPI.Data.GetEntitySharedData(player, "character_shirt"), (int)NAPI.Data.GetEntitySharedData(player, "character_shirt_texture"));
                    player.SetClothes(8, (int)NAPI.Data.GetEntitySharedData(player, "character_undershirt"), (int)NAPI.Data.GetEntitySharedData(player, "character_undershirt_texture"));

                }

                return;
            }
            else if (objectName == "Rucksack abnehmen")
            {
                var backpack = NAPI.Data.GetEntitySharedData(player, "character_backpack");
                SendNotificationSuccess(player, "Du hast den Rucksack ausgezogen.");
                player.SetClothes(5, (int)0, (int)0);
                player.SetData("backpack_enable", false);
                return;
            }
            else if (objectName == "Rucksack aufsetzen")
            {
                var backpack = NAPI.Data.GetEntitySharedData(player, "character_backpack");

                SendNotificationSuccess(player, "Sie haben die Rucksack angezogen.");
                if (player.GetData("character_backpack") == 2)
                {
                    player.SetClothes(5, (int)39, (int)0);
                }
                else if (player.GetData("character_backpack") == 3)
                {
                    player.SetClothes(5, (int)45, (int)0);
                }
                player.SetData("backpack_enable", true);
                return;
            }
            else if (objectName == "Maske abnehmen")
            {
                UsefullyRP.mask[Main.getIdFromClient(player)] = false;
                player.SetClothes(1, 0, 0);
                player.ClearAccessory(1);
                player.SetData("using_mask", false);
                NAPI.Data.SetEntitySharedData(player, "using_mask", false);
                return;
            }
            else if (objectName == "Maske aufsetzen")
            {
                UsefullyRP.mask[Main.getIdFromClient(player)] = true;
                NAPI.Data.SetEntitySharedData(player, "using_mask", true);
                player.SetData("using_mask", true);
                player.SetClothes(1, (int)NAPI.Data.GetEntitySharedData(player, "character_mask"), (int)NAPI.Data.GetEntitySharedData(player, "character_mask_texture"));
                return;
            }
            else if (objectName == "Nackig")
            {
                UsefullyRP.CMD_CharClothes(player);
                return;
            }
            else if (objectName == "Verbindung vom Server beenden")
            {
                adminCommands.CMD_disconnect(player);
                return;
            }
        }
        else if (callbackId == "NEW_MENU_VEHICLE_RESPONSE")
        {
            if (objectName == "Öffnen/Schließen")
            {
                Main.CMD_VehLocked(player);
            }
        }

    }

    public static void OnInputResponse(Client player, String response, String inputtext)
    {
        if (response == "responser_money_user")
        {
            Client target = NAPI.Data.GetEntityData(player, "UserMenuToTarget_handle");
            string name = player.GetData("UserMenuToTarget_name");

            if (inputtext.Contains("-"))
            {
                return;
            }

            if (inputtext.Contains("+"))
            {
                return;
            }

            if (!API.Shared.IsPlayerConnected(target))
            {
                SendNotificationError(player, "Der Bürger ist nicht da.");
                return;
            }

            if (target.GetData("status") == false)
            {
                SendNotificationError(player, "Der Bürger ist nicht da.");
                return;
            }

            if (AccountManage.GetCharacterName(target) != name)
            {
                SendNotificationError(player, "Der Bürger ist nicht da.");
                return;
            }

            if (!Main.IsInRangeOfPoint(player.Position, target.Position, 4.0f))
            {
                SendNotificationError(player, "Der Bürger ist nicht da.");
                return;
            }

            if (!Main.IsNumeric(inputtext))
            {
                SendNotificationError(player, "In diesem Dialog sollten nur Zahlen verwendet werden..");
                return;
            }

            int money = Convert.ToInt32(inputtext);

            if (money < 1 && money > 200000)
            {
                SendNotificationError(player, "Sie können keinen Wert unter 1 USD oder über 200.000 USD verwenden.");
                return;
            }

            if (Main.GetPlayerMoney(player) > money)
            {

                Main.GivePlayerMoney(player, -money);
                Main.GivePlayerMoney(target, money);

                List<Client> proxPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(15, player);
                foreach (Client alvo in proxPlayers)
                {
                    //alvo.TriggerEvent("Send_ToChat", "", "<font color ='#C2A2DA'>* " + UsefullyRP.GetPlayerNameToTarget(player, alvo) + " nahm seine Hand aus der Tasche und gab etwas " + UsefullyRP.GetPlayerNameToTarget(target, alvo) + ".");
                }
            }
            else
            {
                SendNotificationError(player, "Sie haben nicht das ganze Geld..");
                return;
            }
            NAPI.Notification.SendNotificationToPlayer(player, "Du hast  ~g~$" + money.ToString("N0") + "~w~ übergeben.");
            NAPI.ClientEvent.TriggerClientEvent(target, "Notification.SendPictureNotification", "Maze Bank", "Geld bekommen", $"Du hast  ~g~$" + money.ToString("N0") + "~w~ bekommen.");
        }
        if (response == "responser_money_to_user_bank")
        {
            Client target = NAPI.Data.GetEntityData(player, "UserMenuToTarget_handle");
            string name = player.GetData("UserMenuToTarget_name");

            if (inputtext.Contains("-"))
            {
                return;
            }

            if (inputtext.Contains("+"))
            {
                return;
            }

            if (!Main.IsNumeric(inputtext))
            {
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Ungültiger eingegebener Wert.", 5000);
                return;
            }
            int money = Convert.ToInt32(inputtext);

            if (!API.Shared.IsPlayerConnected(target))
            {
                SendNotificationError(player, "Der Bürger ist nicht da.");
                return;
            }

            if (target.GetData("status") == false)
            {
                SendNotificationError(player, "Der Bürger ist nicht da.");
                return;
            }

            if (AccountManage.GetCharacterName(target) != name)
            {
                SendNotificationError(player, "Der Bürger ist nicht da.");
                return;
            }

            if (Main.GetPlayerBank(player) > money)
            {
                Main.GivePlayerMoneyBank(player, -money);
                Main.GivePlayerMoneyBank(target, +money);
            }
            else
            {
                SendNotificationError(player, "Sie haben nicht genug Geld auf ihren Bankkonto!");
                return;
            }
            NAPI.Notification.SendNotificationToPlayer(player, "Du hast  ~g~$" + money.ToString("N0") + "~w~ per Online Überweisung überwiesen.");
            NAPI.ClientEvent.TriggerClientEvent(target, "Notification.SendPictureNotification", "Maze Bank", "Online Überweisung", $"Du hast  ~g~$" + money.ToString("N0") + "~w~ per Online Überweisung überwiesen bekommen.");
        }
        else if (response == "responser_sell_vehicle")
        {
            Client target = NAPI.Data.GetEntityData(player, "UserMenuToTarget_handle");
            string name = player.GetData("UserMenuToTarget_name");

            if (inputtext.Contains("-"))
            {
                return;
            }

            if (inputtext.Contains("+"))
            {
                return;
            }

            if (!Main.IsNumeric(inputtext))
            {
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Ungültiger eingegebener Wert.", 5000);
                return;
            }
            int money = Convert.ToInt32(inputtext);

            if (!API.Shared.IsPlayerConnected(target))
            {
                SendNotificationError(player, "Der Bürger ist nicht da.");
                return;
            }

            if (target.GetData("status") == false)
            {
                SendNotificationError(player, "Der Bürger ist nicht da.");
                return;
            }

            if (AccountManage.GetCharacterName(target) != name)
            {
                SendNotificationError(player, "Der Bürger ist nicht da.");
                return;
            }

            PlayerVehicle.CMD_verkaufen(player, target, money);
        }
    }

    public static void IndexChangeMenuResponse(Client player, String callbackId, int selectedIndex, String objectName, String valueList)
    {
    }

    public static void SendNotification(Client player, string Message)
    {
        player.TriggerEvent("Notify", Message);
    }

    public static void SendNotificationError(Client player, string errorMessage)
    {
        player.TriggerEvent("Notify", "Error: " + errorMessage);
    }

    public static void SendNotificationInfo(Client player, string infoMessage)
    {
        player.TriggerEvent("Notify", "~y~Info:~w~ " + infoMessage);
    }


    public static void SendNotificationSuccess(Client player, string successMessage)
    {
        player.TriggerEvent("Notify", "~g~Erfolgreich:~w~ " + successMessage);
    }


    // Eingende Infos
    public static void ShowPlayerInfos(Client player, Client target)
    {
        List<dynamic> menu_item_list = new List<dynamic>();
        menu_item_list.Add(new { Type = 1, Name = "Name", Description = "", RightLabel = AccountManage.GetCharacterName(player) });
        menu_item_list.Add(new { Type = 1, Name = "Geld:", Description = "", RightLabel = Main.GetPlayerMoney(player).ToString("N0") });
        menu_item_list.Add(new { Type = 1, Name = "Bank:", Description = "", RightLabel = Main.GetPlayerBank(player).ToString("N0") });
        if (AccountManage.GetPlayerGroup(player) != 0)
        {
            menu_item_list.Add(new { Type = 1, Name = "Fraktion:", Description = "", RightLabel = FactionManage.faction_data[AccountManage.GetPlayerGroup(player)].faction_name });
            menu_item_list.Add(new { Type = 1, Name = "Rang:", Description = "", RightLabel = FactionManage.faction_data[AccountManage.GetPlayerGroup(player)].faction_rank[AccountManage.GetPlayerRank(player)] });
        }
        if (player.GetData("character_business_key") != -1)
        {
            int business = player.GetData("character_business_key");
            menu_item_list.Add(new { Type = 1, Name = "Firmenname:", Description = "", RightLabel = Business.business_list[business].business_Name });
            menu_item_list.Add(new { Type = 1, Name = "Typ:", Description = "", RightLabel = Business.Business_Type(Business.business_list[business].business_Type) });
            //NAPI.Notification.SendNotificationToPlayer(target, "~g~Firma~w~  |  Firmenname: ~b~" + Business.business_list[business].business_Name + " (" + business + ")~w~ | Typ: ~b~" + Business.Business_Type(Business.business_list[business].business_Type) + "");
        }
        menu_item_list.Add(new { Type = 1, Name = "RP Level:", Description = "", RightLabel = player.GetData("character_level") });
        menu_item_list.Add(new { Type = 1, Name = "RP EXP:", Description = "", RightLabel = player.GetData("character_exp") });
        menu_item_list.Add(new { Type = 1, Name = "Fahrezeuge:", Description = "", RightLabel = PlayerVehicle.GetPlayerVehicleCount(player) });
        InteractMenu.CreateMenu(target, "NOTHING_HAPPEND", "Bürger Statistiken", "~y~Infos von " + AccountManage.GetCharacterName(player) + "", false, JsonConvert.SerializeObject(menu_item_list), false, BackgroundColor: "Gold");
    }

    //
    // ID Cards and License Shows
    //
    public static void ShowPlayerIDCard(Client player, Client target)
    {
        List<dynamic> menu_item_list = new List<dynamic>();
        menu_item_list.Add(new { Type = 1, Name = "Name", Description = "", RightLabel = AccountManage.GetCharacterName(player) });
        menu_item_list.Add(new { Type = 1, Name = "Einwanderung", Description = "", RightLabel = player.GetData("character_createrchar") });
        menu_item_list.Add(new { Type = 1, Name = "Wohnsitz", Description = "", RightLabel = "Los Santos" });
        InteractMenu.CreateMenu(target, "NOTHING_HAPPEND", AccountManage.GetCharacterName(player), "~y~Identität von " + AccountManage.GetCharacterName(player) + "", false, JsonConvert.SerializeObject(menu_item_list), false, BackgroundColor: "Gold");
    }

    public static void ShowPlayerFactionIDCard(Client player, Client target)
    {
        List<dynamic> menu_item_list = new List<dynamic>();
        menu_item_list.Add(new { Type = 1, Name = "Name", Description = "", RightLabel = AccountManage.GetCharacterName(player) });
        menu_item_list.Add(new { Type = 1, Name = "Fraktion", Description = "", RightLabel = FactionManage.faction_data[AccountManage.GetPlayerGroup(player)].faction_name });
        menu_item_list.Add(new { Type = 1, Name = "Rang", Description = "", RightLabel = FactionManage.faction_data[AccountManage.GetPlayerGroup(player)].faction_rank[AccountManage.GetPlayerRank(player)] });
        InteractMenu.CreateMenu(target, "NOTHING_HAPPEND", "Dienstausweis", "~y~Dienstausweis von " + AccountManage.GetCharacterName(player) + "", false, JsonConvert.SerializeObject(menu_item_list), false, BackgroundColor: "Gold");
    }

    public static void ShowPlayerFactionIDCardX(Client player, Client target)
    {
        List<dynamic> menu_item_list = new List<dynamic>();
        menu_item_list.Add(new { Type = 1, Name = "Name", Description = "", RightLabel = AccountManage.GetCharacterName(player) });
        menu_item_list.Add(new { Type = 1, Name = "Fraktion", Description = "", RightLabel = FactionManage.faction_data[AccountManage.GetPlayerGroup(player)].faction_name });
        menu_item_list.Add(new { Type = 1, Name = "Rang", Description = "", RightLabel = FactionManage.faction_data[AccountManage.GetPlayerGroup(player)].faction_rank[AccountManage.GetPlayerRank(player)] });
        InteractMenu.CreateMenu(target, "NOTHING_HAPPEND", "Dienstausweis", "~y~Dienstausweis von " + AccountManage.GetCharacterName(player) + "", false, JsonConvert.SerializeObject(menu_item_list), false, BackgroundColor: "Gold");
    }

    //
    public static void ShowPlayerDistintivo(Client player, Client target)
    {
        List<dynamic> menu_item_list = new List<dynamic>();
        if (AccountManage.GetPlayerGroup(player) != 0)
        {
            menu_item_list.Add(new { Type = 1, Name = "Fraktion", Description = "", RightLabel = FactionManage.faction_data[AccountManage.GetPlayerGroup(player)].faction_name });
            menu_item_list.Add(new { Type = 1, Name = "Rang", Description = "", RightLabel = FactionManage.faction_data[AccountManage.GetPlayerGroup(player)].faction_rank[AccountManage.GetPlayerRank(player)] });
        }
        InteractMenu.CreateMenu(target, "NOTHING_HAPPEND", AccountManage.GetCharacterName(player), "~y~Identität von " + AccountManage.GetCharacterName(player) + "", false, JsonConvert.SerializeObject(menu_item_list), false, BackgroundColor: "Gold");
    }


    public static void ShowPlayerLicenses(Client player, Client target)
    {
        List<dynamic> menu_item_list = new List<dynamic>();
        if (player.GetData("character_car_lic") == 1)
        {
            menu_item_list.Add(new { Type = 1, Name = "PKW-Führerschein", Description = "Dieser Bürger hat einen Führerschein.", RightBadge = "Tick" });
        }
        else
        {
            menu_item_list.Add(new { Type = 1, Name = "PKW-Führerschein", Description = "Dieser Bürger hat keinen Führerschein.", RightBadge = "Lock" });
        }

        if (player.GetData("character_truck_lic") == 1)
        {
            menu_item_list.Add(new { Type = 1, Name = "LKW-Führerschein", Description = "Dieser Bürger hat einen LKW-Führerschein", RightBadge = "Tick" });
        }
        else
        {
            menu_item_list.Add(new { Type = 1, Name = "LKW-Führerschein", Description = "Dieser Bürger hat keinen LKW-Führerschein.", RightBadge = "Lock" });
        }

        if (player.GetData("character_fly_lic") == 1)
        {
            menu_item_list.Add(new { Type = 1, Name = "Flugschein", Description = "Dieser Bürger hat einen Flugschein.", RightBadge = "Tick" });
        }
        else
        {
            menu_item_list.Add(new { Type = 1, Name = "Flugschein", Description = "Dieser Bürger hat keinen Flugschein..", RightBadge = "Lock" });
        }


        if (player.GetData("character_fish_lic") == 1)
        {
            menu_item_list.Add(new { Type = 1, Name = "Angelschein", Description = "Dieser Bürger besitzt einen Angelschein.", RightBadge = "Tick" });
        }
        else
        {
            menu_item_list.Add(new { Type = 1, Name = "Angelschein", Description = "Dieser Bürger besitzt keinen Angelschein.", RightBadge = "Lock" });
        }

        if (player.GetData("character_taxi_lic") == 1)
        {
            menu_item_list.Add(new { Type = 1, Name = "Taxi Führerschein", Description = "Dieser Spieler besitzt eine Taxifahrerlizenz.", RightBadge = "Tick" });
        }
        else
        {
            menu_item_list.Add(new { Type = 1, Name = "Taxi Führerschein", Description = "Dieser Spieler besitzt keine Taxifahrerlizenz.", RightBadge = "Lock" });
        }

        if (player.GetData("character_gun_lic") == 1)
        {
            menu_item_list.Add(new { Type = 1, Name = "Waffenschein", Description = "Dieser Spieler besitzt ein Waffenschein für Pistolen. Alle anderen Waffen sind hiermit nicht abgedeckt!", RightBadge = "Tick" });
        }
        else
        {
            menu_item_list.Add(new { Type = 1, Name = "Waffenschein", Description = "Dieser Spieler besitzt kein Waffenschein.", RightBadge = "Lock" });
        }

        if (player.GetData("character_lawyer_lic") == 1)
        {
            menu_item_list.Add(new { Type = 1, Name = "Anwaltliches Zertifikat", Description = "Dieses Anwaltliches Zertifikat ist für die Prüfung bei der Justiz gedacht! Ohne einer Prüfung bekommen Sie keine Staatliche Hilfe!", RightBadge = "Tick" });
        }
        else
        {
            menu_item_list.Add(new { Type = 1, Name = "Anwaltliches Zertifikat", Description = "Dieser Spieler besitzt kein Anwaltliches Zertifikat.", RightBadge = "Lock" });
        }

        if (player.GetData("character_cycles_lic") == 1)
        {
            menu_item_list.Add(new { Type = 1, Name = "Motorrad-Führerschein", Description = "Dieser Bürger hat einen Motorrad-Führerschein.", RightBadge = "Tick" });
        }
        else
        {
            menu_item_list.Add(new { Type = 1, Name = "Motorrad-Führerschein", Description = "Dieser Bürger hat keinen Motorrad-Führerschein.", RightBadge = "Lock" });
        }

        InteractMenu.CreateMenu(target, "NOTHING_HAPPEND", AccountManage.GetCharacterName(player), "~y~Lizenzen für " + AccountManage.GetCharacterName(player) + "", false, JsonConvert.SerializeObject(menu_item_list), false, BackgroundColor: "Gold");
    }


    //
    // Temporally untill has been updated !
    //
    //[RemoteEvent("client_side_enable")]
    //public static void client_side_enable(Client player)
    //{
    //    player.SetData("client_side_enable", true);
    //}

    //public static void Check_Player_ClientSide(Client player)
    //{
    //    if (!player.HasData("client_side_enable"))
    //    {
    //        player.TriggerEvent("Display_FilesMissing_Screen");
    //        player.Kick();
    //        return;
    //    }
    //}

    //public static void Reset_ClientSide_Variable(Client player)
    //{
    //    player.ResetData("client_side_enable");
    //}
}

