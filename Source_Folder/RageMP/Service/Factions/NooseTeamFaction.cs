using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using GTANetworkAPI;
using Newtonsoft.Json;
using DerStr1k3r.Core;

class NooseTeam : Script
{
    public static int MAX_FACTION_VEHICLES = 200;

    public static void DisplayNooseTeamVehicles(Client player)
    {
        int faction_id = AccountManage.GetPlayerGroup(player);
        if (faction_id == 26)
        {
            List<dynamic> menu_item_list = new List<dynamic>();
            menu_item_list.Add(new { Type = 4, Name = "Scarab", Description = "", RightLabel = "" });
            menu_item_list.Add(new { Type = 4, Name = "Crusader", Description = "", RightLabel = "" });
            menu_item_list.Add(new { Type = 4, Name = "Halftrack", Description = "", RightLabel = "" });
            menu_item_list.Add(new { Type = 4, Name = "Barracks", Description = "", RightLabel = "" });
            menu_item_list.Add(new { Type = 4, Name = "Barracks2", Description = "", RightLabel = "" });
            menu_item_list.Add(new { Type = 4, Name = "Barracks3", Description = "", RightLabel = "" });
            menu_item_list.Add(new { Type = 4, Name = "Barrage", Description = "", RightLabel = "" });
            InteractMenu.CreateMenu(player, "NOOSETEAM_VEHICLE_SLOT_SPAWN", "Garage", "~b~Army Fort Zancundo Garage:", true, JsonConvert.SerializeObject(menu_item_list), false);
        }
    }

    public static String GetTimestamp(DateTime value)
    {
        return value.ToString("HHmmss");
    }

    public static void SelectMenuResponse(Client player, String callbackId, int selectedIndex, String objectName, String valueList)
    {
        if (callbackId == "NOOSETEAM_VEHICLE_SLOT_SPAWN")
        {
            
            string vehicle_name = objectName;
            
            var factionid = AccountManage.GetPlayerGroup(player);
            if (factionid != 1) { NAPI.Notification.SendNotificationToPlayer(player, "ERROR:~w~ Du bist kein Polizist mehr."); return; }

            int index = -1;
            for (int i = 0; i < MAX_FACTION_VEHICLES; i++)
            {
                if (FactionManage.faction_data[AccountManage.GetPlayerGroup(player)].faction_vehicle_name[index] == "Frei")
                {
                    index = i;
                }  
            }

            if (vehicle_name == "Valkyrie2" && AccountManage.GetPlayerRank(player) < 1)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Nur Mitglieder mit rank 1 + kann dieses Fahrzeug verwenden.");
                return;
            }

            if (index == -1)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Nein zu dem Fahrzeug, das derzeit zum Laichen verfügbar ist.");
                return;
            }

            var hash = NAPI.Util.GetHashKey(vehicle_name).GetHashCode();
            if (vehicle_name == "Valkyrie2")
            {
                VehicleHash vehicle = NAPI.Util.VehicleNameToModel(vehicle_name);
                FactionManage.faction_data[factionid].faction_vehicle_entity[index] = NAPI.Vehicle.CreateVehicle(hash, new Vector3(-1868.719, 3006.974, 32.81048), new Vector3(0, 0, 355.0793), -1, -1);
                NAPI.Player.SetPlayerIntoVehicle(player, FactionManage.faction_data[factionid].faction_vehicle_entity[index], -1);
                NAPI.Vehicle.SetVehicleEngineStatus(FactionManage.faction_data[factionid].faction_vehicle_entity[index], false);
                Main.SetVehicleFuel(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 100.0);
                FactionManage.faction_data[factionid].faction_vehicle_entity[index].PrimaryColor = 0;
                FactionManage.faction_data[factionid].faction_vehicle_entity[index].SecondaryColor = 0;
                NAPI.Vehicle.SetVehicleNumberPlate(FactionManage.faction_data[factionid].faction_vehicle_entity[index], "LS " + GetTimestamp(DateTime.Now));
                NAPI.Vehicle.SetVehicleMod(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 18, 1);
                NAPI.Vehicle.SetVehicleMod(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 11, 3);
                NAPI.Vehicle.SetVehicleMod(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 13, 1);
            }
            else
            {
                Random rnd = new Random();
                int item = rnd.Next(0, 1);
                switch (item)
                {
                    case 0:
                        {
                            VehicleHash vehicle = NAPI.Util.VehicleNameToModel(vehicle_name);
                            FactionManage.faction_data[factionid].faction_vehicle_entity[index] = NAPI.Vehicle.CreateVehicle(hash, new Vector3(-1865.098, 3035.328, 32.50615), new Vector3(0, 0, 307.0581), -1, -1);
                            NAPI.Player.SetPlayerIntoVehicle(player, FactionManage.faction_data[factionid].faction_vehicle_entity[index], -1);
                            NAPI.Vehicle.SetVehicleEngineStatus(FactionManage.faction_data[factionid].faction_vehicle_entity[index], false);
                            Main.SetVehicleFuel(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 99.0);
                            FactionManage.faction_data[factionid].faction_vehicle_entity[index].PrimaryColor = 0;
                            FactionManage.faction_data[factionid].faction_vehicle_entity[index].SecondaryColor = 0;
                            NAPI.Vehicle.SetVehicleNumberPlate(FactionManage.faction_data[factionid].faction_vehicle_entity[index], "LS " + GetTimestamp(DateTime.Now));
                            NAPI.Vehicle.SetVehicleMod(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 18, 1);
                            NAPI.Vehicle.SetVehicleMod(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 11, 3);
                            NAPI.Vehicle.SetVehicleMod(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 13, 1);
                            break;
                        }
                    case 1:
                        {
                            VehicleHash vehicle = NAPI.Util.VehicleNameToModel(vehicle_name);
                            FactionManage.faction_data[factionid].faction_vehicle_entity[index] = NAPI.Vehicle.CreateVehicle(hash, new Vector3(-1891.791, 3023.401, 32.50639), new Vector3(0, 0, 307.0581), -1, -1);
                            NAPI.Player.SetPlayerIntoVehicle(player, FactionManage.faction_data[factionid].faction_vehicle_entity[index], -1);
                            NAPI.Vehicle.SetVehicleEngineStatus(FactionManage.faction_data[factionid].faction_vehicle_entity[index], false);
                            Main.SetVehicleFuel(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 99.0);
                            FactionManage.faction_data[factionid].faction_vehicle_entity[index].PrimaryColor = 0;
                            FactionManage.faction_data[factionid].faction_vehicle_entity[index].SecondaryColor = 0;
                            NAPI.Vehicle.SetVehicleNumberPlate(FactionManage.faction_data[factionid].faction_vehicle_entity[index], "LS " + GetTimestamp(DateTime.Now));
                            NAPI.Vehicle.SetVehicleMod(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 18, 1);
                            NAPI.Vehicle.SetVehicleMod(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 11, 3);
                            NAPI.Vehicle.SetVehicleMod(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 13, 1);
                            break;
                        }
                }

            }

            FactionManage.faction_data[factionid].faction_vehicle_name[index] = vehicle_name;
            FactionManage.faction_data[factionid].faction_vehicle_owned[index] = AccountManage.GetCharacterName(player);
            return;
        }
    }

    public void ListItemMenuResponse(Client player, String callbackId, int selectedIndex, String objectName, String valueList, int valueIndex)
    {
    }

    public static void OnMenuReturnClose(Client player, String callbackId)
    {
        if(callbackId == "NOOSETEAM_VEHICLE_SLOT_SPAWN")
        {
            DisplayNooseTeamVehicles(player);
            return;
        }
    }

    public static void CuffPlayer(Client player)
    {
        player.StopAnimation();
        cellphoneSystem.FinishCall(player);

        player.SetData("playerCuffed", 1);
        NAPI.Player.PlayPlayerAnimation(player, (int)(Main.AnimationFlags.Loop | Main.AnimationFlags.AllowPlayerControl | Main.AnimationFlags.OnlyAnimateUpperBody), "mp_arresting", "idle");
    }

    public static void UnCuffPlayer(Client player)
    {
        player.StopAnimation();

        player.SetData("playerCuffed", 0);
    }

    public static void DragPlayerToTarget(Client player, Client target)
    {
        if (player.IsInVehicle)
        {
            NAPI.Player.WarpPlayerOutOfVehicle(player);
        }
        player.TriggerEvent("setFollow", true, target);
        player.SetData("SendoArrastado", true);

        player.SetSharedData("DisableExitVehicle", false);
    }

    public static void UnDragPlayer(Client player)
    {
        player.TriggerEvent("setFollow", false, null);
        player.SetData("SendoArrastado", false);
    }


    public static void FriskPlayerToTarget(Client target, Client player)
    {
        NAPI.Notification.SendNotificationToPlayer(player,"~g~Artikel von " + AccountManage.GetCharacterName(target) + "");


        if (target.GetData("primary_weapon") != 0)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "(Hauptwaffe) ~c~" + target.GetData("primary_weapon"));
        }
        if (target.GetData("secundary_weapon") != 0)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "(Sekundärwaffe) ~c~" + target.GetData("secundary_weapon"));
        }
        if (target.GetData("weapon_meele") != 0)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "(leichte Waffe) ~c~" + target.GetData("weapon_meele"));
        }

        for (int index = 0; index < Inventory.MAX_INVENTORY_ITENS; index++)
        {
            if (target.GetData("inventory_item_" + index + "_type") != 0 && target.GetData("inventory_item_" + index + "_type") < Inventory.itens_available.Count)
            {
                if (target.GetData("inventory_item_" + index + "_amount") > 0)
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "(items) ~c~" + Inventory.itens_available[target.GetData("inventory_item_" + index + "_type")].name + " ~w~(" + target.GetData("inventory_item_" + index + "_amount") + ") ");
                }

            }
        }
    }
}
