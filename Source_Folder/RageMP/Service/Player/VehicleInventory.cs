using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Data;
using System.IO;
using GTANetworkAPI;
using MySql.Data.MySqlClient;
using DerStr1k3r.SDK;
using DerStr1k3r.Core;

class VehicleInventory : Script
{
    public static void AddInventoryToVehicle(NetHandle vehicle, VehicleHash vehicle_hash)
    {
        int
            vehicleClass = NAPI.Vehicle.GetVehicleClass(vehicle_hash);

        float MAX_VEHICLE_SLOT = 0f;

        switch (vehicleClass)
        {
            case 0: MAX_VEHICLE_SLOT = 25f; break;
            case 1: MAX_VEHICLE_SLOT = 45f; break;
            case 2: MAX_VEHICLE_SLOT = 50f; break;
            case 3: MAX_VEHICLE_SLOT = 25f; break;
            case 4: MAX_VEHICLE_SLOT = 30f; break;
            case 5: MAX_VEHICLE_SLOT = 25f; break;
            case 6: MAX_VEHICLE_SLOT = 25f; break;
            case 7: MAX_VEHICLE_SLOT = 25f; break;
            case 8: MAX_VEHICLE_SLOT = 10f; break;
            case 9: MAX_VEHICLE_SLOT = 30f; break;
            case 10: MAX_VEHICLE_SLOT = 25f; break;
            case 11: MAX_VEHICLE_SLOT = 25f; break;
            case 12: MAX_VEHICLE_SLOT = 60f; break;
            case 14: MAX_VEHICLE_SLOT = 30f; break;
            case 15: MAX_VEHICLE_SLOT = 30f; break;
            case 17: MAX_VEHICLE_SLOT = 20f; break;
            case 18: MAX_VEHICLE_SLOT = 20f; break;
            case 19: MAX_VEHICLE_SLOT = 20f; break;
            case 20: MAX_VEHICLE_SLOT = 50f; break;
        }

        if (MAX_VEHICLE_SLOT != 0f)
        {

            NAPI.Data.SetEntityData(vehicle, "MAX_VEHICLE_SLOT", MAX_VEHICLE_SLOT);

            for (int i = 0; i < 30; i++)
            {
                NAPI.Data.SetEntityData(vehicle, "trunk_item_" + i + "_index", i);
                NAPI.Data.SetEntityData(vehicle, "trunk_item_" + i + "_type", 0);
                NAPI.Data.SetEntityData(vehicle, "trunk_item_" + i + "_amount", 0);
            }
        }
    }

    public static void LoadVehicleInventoryItens(Client player, Vehicle vehicle, int vehicleSQLID)
    {
        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {

            Mainpipeline.Open();
            MySqlCommand query = new MySqlCommand("SELECT * FROM `vehicle_inventory` WHERE `vehicle` = '" + vehicleSQLID + "';", Mainpipeline);

            using (MySqlDataReader reader = query.ExecuteReader())
            {

                string data2txt = string.Empty;
                string datatxt = string.Empty;

                var index = 0;
                while (reader.Read())
                {
                    NAPI.Data.SetEntityData(vehicle, "trunk_item_" + index + "_index", index);
                    NAPI.Data.SetEntityData(vehicle, "trunk_item_" + index + "_type", reader.GetInt32("type"));
                    NAPI.Data.SetEntityData(vehicle, "trunk_item_" + index + "_amount", reader.GetInt32("amount"));

                    index++;
                }

            }
        }

    }

    public static bool Check_VehicleInventoryWeight_With_ItemAmount(Client player, Vehicle vehicle, int type, int amount, float MAX_HEIGHT)
    {
        //Main.SendErrorMessage(player, "O inventário do veículo não tem espaço suficiente para carregar este item.");

        float height = 0.00f;
        for (int i = 0; i < 30; i++)
        {
            if (NAPI.Data.GetEntityData(vehicle, "trunk_item_" + i + "_type") != 0 && NAPI.Data.GetEntityData(vehicle, "trunk_item_" + i + "_amount") > 0)
            {
                height += Inventory.itens_available[NAPI.Data.GetEntityData(vehicle, "trunk_item_" + i + "_type")].weight;
            }
        }

        float free_space = MAX_HEIGHT - height;

        height += amount * Inventory.itens_available[type].weight;

        if (height > MAX_HEIGHT)
        {
            Notify.Send(player, NotifyType.Success, NotifyPosition.BottomCenter, $"Sie haben nicht genügend Platz im Kofferraum !", 5000);
            return true;
        }
        return false;
    }


    public static void RemoveVehicleInventory(NetHandle vehicle)
    {
        if (NAPI.Data.HasEntityData(vehicle, "MAX_VEHICLE_SLOT")) NAPI.Data.ResetEntityData(vehicle, "MAX_VEHICLE_SLOT");

        foreach (var player in NAPI.Pools.GetAllPlayers())
        {
            if (player.GetData("status") == true)
            {
                for (int index = 0; index < PlayerVehicle.MAX_PLAYER_VEHICLES; index++)
                {
                    if (PlayerVehicle.vehicle_data[Main.getIdFromClient(player)].state[index] == 1 && PlayerVehicle.vehicle_data[Main.getIdFromClient(player)].handle[index] == vehicle)
                    {
                        Main.CreateMySqlCommand("DELETE FROM `vehicle_inventory` WHERE `vehicle` = '" + PlayerVehicle.vehicle_data[Main.getIdFromClient(player)].index[index] + "';");
                        for (int i = 0; i < 30; i++)
                        {
                            if (NAPI.Data.HasEntityData(vehicle, "trunk_item_" + i + "_index")) NAPI.Data.ResetEntityData(vehicle, "trunk_item_" + i + "_index");
                            if (NAPI.Data.HasEntityData(vehicle, "trunk_item_" + i + "_type")) NAPI.Data.ResetEntityData(vehicle, "trunk_item_" + i + "_type");
                            if (NAPI.Data.HasEntityData(vehicle, "trunk_item_" + i + "_amount")) NAPI.Data.ResetEntityData(vehicle, "trunk_item_" + i + "_amount");
                        }
                        return;
                    }
                }
            }
        }


        for (int i = 0; i < 30; i++)
        {
            if (NAPI.Data.HasEntityData(vehicle, "trunk_item_" + i + "_index")) NAPI.Data.ResetEntityData(vehicle, "trunk_item_" + i + "_index");
            if (NAPI.Data.HasEntityData(vehicle, "trunk_item_" + i + "_type")) NAPI.Data.ResetEntityData(vehicle, "trunk_item_" + i + "_type");
            if (NAPI.Data.HasEntityData(vehicle, "trunk_item_" + i + "_amount")) NAPI.Data.ResetEntityData(vehicle, "trunk_item_" + i + "_amount");
        }
    }

    public static void AddItemToVehicleInventory(NetHandle vehicle, int item_type, int item_amount)
    {
        foreach (var player in NAPI.Pools.GetAllPlayers())
        {
            if (player.GetData("status") == true)
            {
                for (int index = 0; index < PlayerVehicle.MAX_PLAYER_VEHICLES; index++)
                {
                    if (PlayerVehicle.vehicle_data[Main.getIdFromClient(player)].state[index] == 1 && PlayerVehicle.vehicle_data[Main.getIdFromClient(player)].handle[index] == vehicle)
                    {

                        for (int i = 0; i < 30; i++)
                        {
                            if (NAPI.Data.GetEntityData(vehicle, "trunk_item_" + i + "_type") == item_type)
                            {
                                NAPI.Data.SetEntityData(vehicle, "trunk_item_" + i + "_amount", NAPI.Data.GetEntityData(vehicle, "trunk_item_" + i + "_amount") + item_amount);
                                Main.CreateMySqlCommand("UPDATE vehicle_inventory SET `amount` = " + NAPI.Data.GetEntityData(vehicle, "trunk_item_" + i + "_amount") + " WHERE `vehicle` = " + PlayerVehicle.vehicle_data[Main.getIdFromClient(player)].index[index] + " AND `type` = " + item_type + ";");
                                return;
                            }
                        }

                        for (int i = 0; i < 30; i++)
                        {
                            if (NAPI.Data.GetEntityData(vehicle, "trunk_item_" + i + "_type") == 0)
                            {
                                using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
                                {
                                    try
                                    {
                                        Mainpipeline.Open();
                                        string query = "INSERT INTO vehicle_inventory (`vehicle`, `type`, `amount`)" + " VALUES ('" + PlayerVehicle.vehicle_data[Main.getIdFromClient(player)].index[index] + "', '" + item_type + "', '" + item_amount + "')";
                                        MySqlCommand myCommand = new MySqlCommand(query, Mainpipeline);
                                        myCommand.ExecuteNonQuery();
                                        long last_inventory_id = myCommand.LastInsertedId;

                                        NAPI.Data.SetEntityData(vehicle, "trunk_item_" + i + "_index", i);
                                        NAPI.Data.SetEntityData(vehicle, "trunk_item_" + i + "_type", item_type);
                                        NAPI.Data.SetEntityData(vehicle, "trunk_item_" + i + "_amount", item_amount);
                                    }
                                    catch (Exception ex)
                                    {
                                        NAPI.Util.ConsoleOutput("[EXCEPTION AddItemToVehicleInventory] " + ex.Message);
                                        NAPI.Util.ConsoleOutput("[EXCEPTION AddItemToVehicleInventory] " + ex.StackTrace);
                                    }
                                }
                                return;
                            }
                        }
                        return;
                    }
                }
            }
        }

        for (int i = 0; i < 30; i++)
        {
            if (NAPI.Data.GetEntityData(vehicle, "trunk_item_" + i + "_type") == item_type)
            {
                NAPI.Data.SetEntityData(vehicle, "trunk_item_" + i + "_amount", NAPI.Data.GetEntityData(vehicle, "trunk_item_" + i + "_amount") + item_amount);
                return;
            }
        }

        for (int i = 0; i < 30; i++)
        {
            if (NAPI.Data.GetEntityData(vehicle, "trunk_item_" + i + "_type") == 0)
            {
                NAPI.Data.SetEntityData(vehicle, "trunk_item_" + i + "_index", i);
                NAPI.Data.SetEntityData(vehicle, "trunk_item_" + i + "_type", item_type);
                NAPI.Data.SetEntityData(vehicle, "trunk_item_" + i + "_amount", item_amount);
                return;
            }
        }

    }

    public static void RemoveItemFromVehicleInventory(Vehicle vehicle, int id, int amount = 0)
    {
        foreach (var player in NAPI.Pools.GetAllPlayers())
        {
            if (player.GetData("status") == true)
            {
                for (int index = 0; index < PlayerVehicle.MAX_PLAYER_VEHICLES; index++)
                {
                    if (PlayerVehicle.vehicle_data[Main.getIdFromClient(player)].state[index] == 1 && PlayerVehicle.vehicle_data[Main.getIdFromClient(player)].handle[index] == vehicle)
                    {
                        if (NAPI.Data.GetEntityData(vehicle, "trunk_item_" + id + "_amount") >= 2)
                        {
                            NAPI.Data.SetEntityData(vehicle, "trunk_item_" + id + "_amount", NAPI.Data.GetEntityData(vehicle, "trunk_item_" + id + "_amount") - amount);
                            Main.CreateMySqlCommand("UPDATE vehicle_inventory SET `amount` = " + NAPI.Data.GetEntityData(vehicle, "trunk_item_" + id + "_amount") + " WHERE `vehicle` = " + PlayerVehicle.vehicle_data[Main.getIdFromClient(player)].index[index] + " AND `type` = " + NAPI.Data.GetEntityData(vehicle, "trunk_item_" + id + "_type") + ";");

                            if (NAPI.Data.GetEntityData(vehicle, "trunk_item_" + id + "_amount") < 1)
                            {
                                NAPI.Data.SetEntityData(vehicle, "trunk_item_" + id + "_type", 0);
                                NAPI.Data.SetEntityData(vehicle, "trunk_item_" + id + "_amount", 0);
                                Main.CreateMySqlCommand("DELETE FROM vehicle_inventory WHERE `amount` = 0 AND `vehicle` = " + PlayerVehicle.vehicle_data[Main.getIdFromClient(player)].index[index] + ";");
                            }
                        }
                        else
                        {
                            Main.CreateMySqlCommand("DELETE FROM vehicle_inventory WHERE `vehicle` = " + PlayerVehicle.vehicle_data[Main.getIdFromClient(player)].index[index] + " AND `type` = " + NAPI.Data.GetEntityData(vehicle, "trunk_item_" + id + "_type") + ";");
                            NAPI.Data.SetEntityData(vehicle, "trunk_item_" + id + "_type", 0);
                            NAPI.Data.SetEntityData(vehicle, "trunk_item_" + id + "_amount", 0);
                        }
                        return;
                    }
                }
            }
        }

        if (NAPI.Data.GetEntityData(vehicle, "trunk_item_" + id + "_amount") >= 2)
        {
            NAPI.Data.SetEntityData(vehicle, "trunk_item_" + id + "_amount", NAPI.Data.GetEntityData(vehicle, "trunk_item_" + id + "_amount") - amount);

            if (NAPI.Data.GetEntityData(vehicle, "trunk_item_" + id + "_amount") < 1)
            {

                NAPI.Data.SetEntityData(vehicle, "trunk_item_" + id + "_type", 0);
                NAPI.Data.SetEntityData(vehicle, "trunk_item_" + id + "_amount", 0);
            }
        }
        else
        {
            NAPI.Data.SetEntityData(vehicle, "trunk_item_" + id + "_type", 0);
            NAPI.Data.SetEntityData(vehicle, "trunk_item_" + id + "_amount", 0);
        }

    }

    public static Vehicle HasVehicleInventory(Client handle)
    {

        if (!handle.IsInVehicle)
        {

            foreach (var vehicle in NAPI.Pools.GetAllVehicles())
            {

                if (NAPI.Data.HasEntityData(vehicle, "MAX_VEHICLE_SLOT") && Main.IsInRangeOfPoint(handle.Position, vehicle.Position, 3.0f))
                {
                    if (NAPI.Data.GetEntityData(vehicle, "MAX_VEHICLE_SLOT") > 0)
                    {
                        if (NAPI.Vehicle.GetVehicleHealth(vehicle) > 0)
                        {

                            bool can_acess = false;

                            foreach (var player in NAPI.Pools.GetAllPlayers())
                            {
                                if (player.GetData("status") == true)
                                {
                                    for (int index = 0; index < PlayerVehicle.MAX_PLAYER_VEHICLES; index++)
                                    {
                                        if (PlayerVehicle.vehicle_data[Main.getIdFromClient(player)].state[index] == 1)
                                        {
                                            if (PlayerVehicle.vehicle_data[Main.getIdFromClient(player)].handle[index].Exists && PlayerVehicle.vehicle_data[Main.getIdFromClient(player)].handle[index] == vehicle)
                                            {
                                                can_acess = true;
                                            }
                                        }
                                    }
                                }
                            }

                            for (int b = 0; b < RentVehicle.MAX_RENT_VEHICLES; b++)
                            {
                                if (RentVehicle.vehicle_rent_list[b].vehicle_free == true && RentVehicle.vehicle_rent_list[b].vehicle_entity == vehicle)
                                {
                                    can_acess = true;
                                }
                            }

                            if (can_acess == false)
                            {
                                return null;
                            }

                            return vehicle;
                        }
                    }
                }
            }
        }

        if (handle.IsInVehicle)
        {
            if (NAPI.Data.HasEntityData(handle.Vehicle, "MAX_VEHICLE_SLOT"))
            {
                if (NAPI.Data.GetEntityData(handle.Vehicle, "MAX_VEHICLE_SLOT") > 0)
                {
                    if (NAPI.Vehicle.GetVehicleHealth(handle.Vehicle) > 0)
                    {
                        bool can_acess = false;
                        foreach (var player in NAPI.Pools.GetAllPlayers())
                        {
                            if (player.GetData("status") == true)
                            {
                                for (int index = 0; index < PlayerVehicle.MAX_PLAYER_VEHICLES; index++)
                                {
                                    if (PlayerVehicle.vehicle_data[Main.getIdFromClient(player)].state[index] == 1)
                                    {
                                        if (PlayerVehicle.vehicle_data[Main.getIdFromClient(player)].handle[index].Exists && PlayerVehicle.vehicle_data[Main.getIdFromClient(player)].handle[index] == handle.Vehicle)
                                        {
                                            can_acess = true;
                                        }
                                    }
                                }
                            }
                        }

                        for (int b = 0; b < RentVehicle.MAX_RENT_VEHICLES; b++)
                        {
                            if (RentVehicle.vehicle_rent_list[b].vehicle_free == true && RentVehicle.vehicle_rent_list[b].vehicle_entity == handle.Vehicle)
                            {
                                can_acess = true;
                            }
                        }

                        if (can_acess == false)
                        {
                            return null;
                        }

                        return handle.Vehicle;
                    }
                }
            }
        }
        return null;
    }

    public static void ShowToPlayerVehicleInventory(Client handle)
    {
        if (HasVehicleInventory(handle) == null)
        {
            return;
        }
        Vehicle vehicle = HasVehicleInventory(handle);

        handle.SetData("vehicle_handle_inv", vehicle);

        int playerid = Main.getIdFromClient(handle);
        List<dynamic> temp_inventory = new List<dynamic>();

        float weight = 0f;
        float vehicle_weight = 0f;

        for (int index = 0; index < Inventory.MAX_INVENTORY_ITENS; index++)
        {
            if (Inventory.player_inventory[playerid].sql_id[index] != -1)
            {

                int type = Inventory.player_inventory[playerid].type[index];

                if (type > Inventory.itens_available.Count)
                {
                    continue;
                }

                string new_category = "NONE";

                temp_inventory.Add(new { name = Inventory.itens_available[type].name, type = type, description = Inventory.itens_available[type].description, amount = Inventory.player_inventory[playerid].amount[index], weight = Inventory.itens_available[type].weight, use_0 = "Usar Item", use_1 = "null", dontDisplayAmount = false, category = new_category });

                weight += Inventory.player_inventory[playerid].amount[index] * Inventory.itens_available[type].weight;
            }
        }

        int itens = 0;
        List<dynamic> temp_vehicle_inventory = new List<dynamic>();
        for (int i = 0; i < 30; i++)
        {
            if (NAPI.Data.GetEntityData(vehicle, "trunk_item_" + i + "_type") != 0)
            {
                if (NAPI.Data.GetEntityData(vehicle, "trunk_item_" + i + "_amount") > 0)
                {
                    int type = NAPI.Data.GetEntityData(vehicle, "trunk_item_" + i + "_type");

                    string new_category = "NONE";

                    temp_vehicle_inventory.Add(new { name = Inventory.itens_available[type].name, type = type, description = Inventory.itens_available[type].description, amount = NAPI.Data.GetEntityData(vehicle, "trunk_item_" + i + "_amount"), weight = Inventory.itens_available[type].weight, dontDisplayAmount = false, category = new_category });
                    vehicle_weight += NAPI.Data.GetEntityData(vehicle, "trunk_item_" + i + "_amount") * Inventory.itens_available[type].weight;
                }
                itens++;
            }
        }

        handle.TriggerEvent("Display_Player_Storage", NAPI.Util.ToJson(temp_inventory), NAPI.Util.ToJson(temp_vehicle_inventory), weight, Inventory.GetInventoryMaxHeight(handle), vehicle_weight, vehicle.GetData("MAX_VEHICLE_SLOT"));
        handle.SetData("inVehicleInventory", true);
        handle.SetData("vehicle_handle_inv", vehicle);
        VehicleStreaming.SetDoorState(vehicle, DoorID.DoorTrunk, DoorState.DoorOpen);
    }

    [RemoteEvent("closeVehicleInventory")]
    public static void closeVehicleInventory(Client player)
    {
        if (player.HasData("vehicle_handle_inv"))
        {
            Vehicle teste = player.GetData("vehicle_handle_inv");

            if (teste.Exists && player.GetData("inVehicleInventory") == true)
            {
                if (VehicleStreaming.GetDoorState(teste, DoorID.DoorTrunk) == DoorState.DoorOpen)
                {
                    VehicleStreaming.SetDoorState(teste, DoorID.DoorTrunk, DoorState.DoorClosed);
                }
            }

        }
    }

    public static void HidePlayerVehicleInventory(Client player)
    {
        /*Vehicle teste = player.GetData("vehicle_handle_inv");

        if (teste.Exists)
        {
            if (VehicleStreaming.GetDoorState(teste, VehicleSync.DoorID.DoorTrunk) == VehicleSync.DoorState.DoorOpen)
            {
                VehicleStreaming.SetDoorState(teste, VehicleSync.DoorID.DoorTrunk, VehicleSync.DoorState.DoorClosed);
            }
        }*/


        //NAPI.ClientEvent.TriggerClientEvent(player, "HidePlayerVehicleInventory");
        player.SetData("inVehicleInventory", false);
    }

    public static int GetInventoryIndexFromType(Client player, int type)
    {
        NetHandle vehicle = player.GetData("vehicle_handle_inv");
        int slot = -1;
        for (int index = 0; index < NAPI.Data.GetEntityData(vehicle, "MAX_VEHICLE_SLOT"); index++)
        {
            if (NAPI.Data.GetEntityData(vehicle, "trunk_item_" + index + "_type") == type)
            {
                slot = index;
            }
        }
        return slot;
    }


}
