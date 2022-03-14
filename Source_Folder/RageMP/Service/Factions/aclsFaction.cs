using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using GTANetworkAPI;
using Newtonsoft.Json;

class AclsService : Script
{
    static int[] male_head = { 8, 46};
    static int[] male_glasses = { 0, 9 };
    static int[] male_bodyarmor = { 0, 12, 16 };
    static int[] male_undershirt = { 0, 58, 122, 129, 130 };
    static int[] male_torso = { 0, 19, 30};

    public static int MAX_FACTION_VEHICLES = 200;

    public static void DisplayAclsVehicles(Client player)
    {
        int faction_id = AccountManage.GetPlayerGroup(player);
        if (faction_id == 8)
        {
            List<dynamic> menu_item_list = new List<dynamic>();
            menu_item_list.Add(new { Type = 4, Name = "TowTruck", Description = "", RightLabel = "" });
            menu_item_list.Add(new { Type = 4, Name = "TowTruck2", Description = "", RightLabel = "" });
            menu_item_list.Add(new { Type = 4, Name = "Flatbed", Description = "", RightLabel = "" });
            InteractMenu.CreateMenu(player, "ACLS_VEHICLE_SLOT_SPAWN", "Garage", "~b~Acls Garage:", true, JsonConvert.SerializeObject(menu_item_list), false);
            //player.TriggerEvent("menu_handler_create_menu_generic", "ACLS_VEHICLE_SLOT_SPAWN", "Garage", "~b~Polizeibehörde Garage:", true, JsonConvert.SerializeObject(menu_item_list), "Seite", "durch die Seiten blättern", 100);
        }
        if (faction_id == 11)
        {
            List<dynamic> menu_item_list = new List<dynamic>();
            menu_item_list.Add(new { Type = 4, Name = "TowTruck", Description = "", RightLabel = "" });
            menu_item_list.Add(new { Type = 4, Name = "TowTruck2", Description = "", RightLabel = "" });
            InteractMenu.CreateMenu(player, "LSPC_VEHICLE_SLOT_SPAWN", "Garage", "~b~LSPC Garage:", true, JsonConvert.SerializeObject(menu_item_list), false);
            //player.TriggerEvent("menu_handler_create_menu_generic", "ACLS_VEHICLE_SLOT_SPAWN", "Garage", "~b~Polizeibehörde Garage:", true, JsonConvert.SerializeObject(menu_item_list), "Seite", "durch die Seiten blättern", 100);
        }
    }

    public static void SetCopDefaultClothes(Client player)
    {
        Outfits.SetUnisexOutfit(player, 193);
    }

    public static void DisplayAclsUniforms(Client player)
    {
        List<dynamic> menu_item_list = new List<dynamic>();

        menu_item_list.Add(new { Type = 1, Name = "Uniform ~c~#1", Description = "", RightLabel = "" });
        menu_item_list.Add(new { Type = 1, Name = "Uniform ~c~#2", Description = "", RightLabel = "" });
        menu_item_list.Add(new { Type = 1, Name = "Uniform ~c~#3", Description = "", RightLabel = "" });
        menu_item_list.Add(new { Type = 1, Name = "Uniform ~c~#4", Description = "", RightLabel = "" });
        menu_item_list.Add(new { Type = 1, Name = "Uniform ~c~#5", Description = "", RightLabel = "" });
        menu_item_list.Add(new { Type = 1, Name = "Uniform ~c~#6", Description = "", RightLabel = "" });

        InteractMenu.CreateMenu(player, "ACLS_UNIFORM_RESPONSE", "Uniformn", "~b~Uniform:", true, JsonConvert.SerializeObject(menu_item_list), false);
        //player.TriggerEvent("menu_handler_create_menu_generic", "ACLS_UNIFORM_RESPONSE", "Uniformn", "~b~Uniform:", true, JsonConvert.SerializeObject(menu_item_list), "Seite", "durch die Seiten blättern", 10);
        return;
    }

    public static void SelectMenuResponse(Client player, String callbackId, int selectedIndex, String objectName, String valueList)
    {
        if(callbackId == "ACLS_UNIFORM_RESPONSE")
        {
            switch (selectedIndex)
            {
                case 0:
                    Outfits.SetUnisexOutfit(player, 193);
                    player.SetData("character_duty_outfit", 193);
                    break;
                case 1:
                    Outfits.SetUnisexOutfit(player, 194);
                    player.SetData("character_duty_outfit", 194);
                    break;
                case 2:
                    Outfits.SetUnisexOutfit(player, 195);
                    player.SetData("character_duty_outfit", 195);
                    break;
                case 3:
                    Outfits.SetUnisexOutfit(player, 196);
                    player.SetData("character_duty_outfit", 196);
                    break;
                case 4:
                    Outfits.SetUnisexOutfit(player, 197);
                    player.SetData("character_duty_outfit", 197);
                    break;
                case 5:
                    Outfits.SetUnisexOutfit(player, 198);
                    player.SetData("character_duty_outfit", 198);
                    break;
            }
            player.TriggerEvent("freeze", false);
            return;
        }
        else if (callbackId == "ACLS_VEHICLE_SLOT_SPAWN")
        {
            string vehicle_name = objectName;
            
            var factionid = AccountManage.GetPlayerGroup(player);
            if (factionid != 8) { NAPI.Notification.SendNotificationToPlayer(player, "ERROR:~w~ Du bist kein Arbeiter von den ACLS mehr."); return; }

            int index = -1;
            for (int i = 0; i < MAX_FACTION_VEHICLES; i++)
            {
                if (FactionManage.faction_data[AccountManage.GetPlayerGroup(player)].faction_vehicle_name[index] == "Frei")
                {
                    index = i;
                }  
            }

            if (index == -1)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Nein zu dem Fahrzeug, das derzeit zum Laichen verfügbar ist.");
                return;
            }

            Random rnd = new Random();
            int item = rnd.Next(0, 3);
            switch (item)
            {
                case 0:
                    {
                        VehicleHash vehicle = NAPI.Util.VehicleNameToModel(vehicle_name);
                        FactionManage.faction_data[factionid].faction_vehicle_entity[index] = NAPI.Vehicle.CreateVehicle(vehicle, new Vector3(-1142.746, -1980.768, 13.16213), new Vector3(-0.9376355, 0.01036374, 179.3837), -1, -1);
                        NAPI.Player.SetPlayerIntoVehicle(player, FactionManage.faction_data[factionid].faction_vehicle_entity[index], -1);
                        NAPI.Vehicle.SetVehicleEngineStatus(FactionManage.faction_data[factionid].faction_vehicle_entity[index], false);
                        Main.SetVehicleFuel(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 100.0);
                        NAPI.Vehicle.SetVehicleNumberPlate(FactionManage.faction_data[factionid].faction_vehicle_entity[index], "LS " + SecretService.GetTimestamp(DateTime.Now));
                        NAPI.Vehicle.SetVehicleEnginePowerMultiplier(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 500);
                        NAPI.Vehicle.SetVehicleEngineTorqueMultiplier(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 500);
                        NAPI.Vehicle.SetVehicleMod(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 18, 1);
                        NAPI.Vehicle.SetVehicleMod(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 11, 3);
                        NAPI.Vehicle.SetVehicleMod(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 13, 3);
                        break;
                    }
                case 1:
                    {
                        VehicleHash vehicle = NAPI.Util.VehicleNameToModel(vehicle_name);
                        FactionManage.faction_data[factionid].faction_vehicle_entity[index] = NAPI.Vehicle.CreateVehicle(vehicle, new Vector3(-1142.746, -1980.768, 13.16213), new Vector3(14.40796, -0.6033466, -178.2125), -1, -1);
                        NAPI.Player.SetPlayerIntoVehicle(player, FactionManage.faction_data[factionid].faction_vehicle_entity[index], -1);
                        NAPI.Vehicle.SetVehicleEngineStatus(FactionManage.faction_data[factionid].faction_vehicle_entity[index], false);
                        Main.SetVehicleFuel(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 100.0);
                        NAPI.Vehicle.SetVehicleNumberPlate(FactionManage.faction_data[factionid].faction_vehicle_entity[index], "LS " + SecretService.GetTimestamp(DateTime.Now));
                        NAPI.Vehicle.SetVehicleEnginePowerMultiplier(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 500);
                        NAPI.Vehicle.SetVehicleEngineTorqueMultiplier(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 500);
                        NAPI.Vehicle.SetVehicleMod(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 18, 1);
                        NAPI.Vehicle.SetVehicleMod(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 11, 3);
                        NAPI.Vehicle.SetVehicleMod(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 13, 3);
                        break;
                    }
                case 2:
                    {
                        VehicleHash vehicle = NAPI.Util.VehicleNameToModel(vehicle_name);
                        FactionManage.faction_data[factionid].faction_vehicle_entity[index] = NAPI.Vehicle.CreateVehicle(vehicle, new Vector3(-1142.746, -1980.768, 13.16213), new Vector3(-0.9181333, 0.001428998, -179.4831), -1, 0 - 1);
                        NAPI.Player.SetPlayerIntoVehicle(player, FactionManage.faction_data[factionid].faction_vehicle_entity[index], -1);
                        NAPI.Vehicle.SetVehicleEngineStatus(FactionManage.faction_data[factionid].faction_vehicle_entity[index], false);
                        Main.SetVehicleFuel(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 100.0);
                        NAPI.Vehicle.SetVehicleNumberPlate(FactionManage.faction_data[factionid].faction_vehicle_entity[index], "LS " + SecretService.GetTimestamp(DateTime.Now));
                        //NAPI.Vehicle.SetVehicleEnginePowerMultiplier(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 100);
                        //NAPI.Vehicle.SetVehicleEngineTorqueMultiplier(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 100);
                        NAPI.Vehicle.SetVehicleMod(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 18, 1);
                        NAPI.Vehicle.SetVehicleMod(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 11, 3);
                        NAPI.Vehicle.SetVehicleMod(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 13, 3);
                        break;
                    }
                case 3:
                    {
                        VehicleHash vehicle = NAPI.Util.VehicleNameToModel(vehicle_name);
                        FactionManage.faction_data[factionid].faction_vehicle_entity[index] = NAPI.Vehicle.CreateVehicle(vehicle, new Vector3(-1142.746, -1980.768, 13.16213), new Vector3(16.75011, -0.8737264, -176.9977), -1, -1);
                        NAPI.Player.SetPlayerIntoVehicle(player, FactionManage.faction_data[factionid].faction_vehicle_entity[index], -1);
                        NAPI.Vehicle.SetVehicleEngineStatus(FactionManage.faction_data[factionid].faction_vehicle_entity[index], false);
                        Main.SetVehicleFuel(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 100.0);
                        NAPI.Vehicle.SetVehicleNumberPlate(FactionManage.faction_data[factionid].faction_vehicle_entity[index], "LS " + SecretService.GetTimestamp(DateTime.Now));
                        //NAPI.Vehicle.SetVehicleEnginePowerMultiplier(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 500);
                        //NAPI.Vehicle.SetVehicleEngineTorqueMultiplier(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 500);
                        NAPI.Vehicle.SetVehicleMod(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 18, 1);
                        NAPI.Vehicle.SetVehicleMod(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 11, 3);
                        NAPI.Vehicle.SetVehicleMod(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 13, 3);
                        break;
                    }
            }

            FactionManage.faction_data[factionid].faction_vehicle_name[index] = vehicle_name;
            FactionManage.faction_data[factionid].faction_vehicle_owned[index] = AccountManage.GetCharacterName(player);
            return;
        }
        else if (callbackId == "LSPC_VEHICLE_SLOT_SPAWN")
        {
            string vehicle_name = objectName;

            var factionid = AccountManage.GetPlayerGroup(player);
            if (factionid != 11) { NAPI.Notification.SendNotificationToPlayer(player, "ERROR:~w~ Du bist kein Arbeiter von den LSPC mehr."); return; }

            int index = -1;
            for (int i = 0; i < MAX_FACTION_VEHICLES; i++)
            {
                if (FactionManage.faction_data[AccountManage.GetPlayerGroup(player)].faction_vehicle_name[index] == "Frei")
                {
                    index = i;
                }
            }

            if (index == -1)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Nein zu dem Fahrzeug, das derzeit zum Laichen verfügbar ist.");
                return;
            }

            Random rnd = new Random();
            int item = rnd.Next(0, 1);
            switch (item)
            {
                case 0:
                    {
                        VehicleHash vehicle = NAPI.Util.VehicleNameToModel(vehicle_name);
                        FactionManage.faction_data[factionid].faction_vehicle_entity[index] = NAPI.Vehicle.CreateVehicle(vehicle, new Vector3(-353.73227, -116.190926, 38.697243), new Vector3(0, 0, 71.0701), -1, -1);
                        NAPI.Player.SetPlayerIntoVehicle(player, FactionManage.faction_data[factionid].faction_vehicle_entity[index], -1);
                        NAPI.Vehicle.SetVehicleEngineStatus(FactionManage.faction_data[factionid].faction_vehicle_entity[index], false);
                        Main.SetVehicleFuel(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 100.0);
                        NAPI.Vehicle.SetVehicleNumberPlate(FactionManage.faction_data[factionid].faction_vehicle_entity[index], "LS " + SecretService.GetTimestamp(DateTime.Now));
                        NAPI.Vehicle.SetVehicleEnginePowerMultiplier(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 500);
                        NAPI.Vehicle.SetVehicleEngineTorqueMultiplier(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 500);
                        NAPI.Vehicle.SetVehicleMod(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 18, 1);
                        NAPI.Vehicle.SetVehicleMod(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 11, 3);
                        NAPI.Vehicle.SetVehicleMod(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 13, 3);
                        break;
                    }
                case 1:
                    {
                        VehicleHash vehicle = NAPI.Util.VehicleNameToModel(vehicle_name);
                        FactionManage.faction_data[factionid].faction_vehicle_entity[index] = NAPI.Vehicle.CreateVehicle(vehicle, new Vector3(-379.07025, -101.915504, 38.695652), new Vector3(0, 0, 151.46754), -1, -1);
                        NAPI.Player.SetPlayerIntoVehicle(player, FactionManage.faction_data[factionid].faction_vehicle_entity[index], -1);
                        NAPI.Vehicle.SetVehicleEngineStatus(FactionManage.faction_data[factionid].faction_vehicle_entity[index], false);
                        Main.SetVehicleFuel(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 100.0);
                        NAPI.Vehicle.SetVehicleNumberPlate(FactionManage.faction_data[factionid].faction_vehicle_entity[index], "LS " + SecretService.GetTimestamp(DateTime.Now));
                        NAPI.Vehicle.SetVehicleEnginePowerMultiplier(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 500);
                        NAPI.Vehicle.SetVehicleEngineTorqueMultiplier(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 500);
                        NAPI.Vehicle.SetVehicleMod(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 18, 1);
                        NAPI.Vehicle.SetVehicleMod(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 11, 3);
                        NAPI.Vehicle.SetVehicleMod(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 13, 3);
                        break;
                    }
            }

            FactionManage.faction_data[factionid].faction_vehicle_name[index] = vehicle_name;
            FactionManage.faction_data[factionid].faction_vehicle_owned[index] = AccountManage.GetCharacterName(player);
            return;
        }
    }

    public static void IndexChangeMenuResponse(Client player, String callbackId, int selectedIndex, String objectName, String valueList)
    {
        if (callbackId == "ACLS_UNIFORM_RESPONSE")
        {
            switch (selectedIndex)
            {
                case 0:
                    Outfits.SetUnisexOutfit(player, 193);
                    player.SetData("character_duty_outfit", 193);
                    break;
                case 1:
                    Outfits.SetUnisexOutfit(player, 194);
                    player.SetData("character_duty_outfit", 194);
                    break;
                case 2:
                    Outfits.SetUnisexOutfit(player, 195);
                    player.SetData("character_duty_outfit", 195);
                    break;
                case 3:
                    Outfits.SetUnisexOutfit(player, 196);
                    player.SetData("character_duty_outfit", 196);
                    break;
                case 4:
                    Outfits.SetUnisexOutfit(player, 197);
                    player.SetData("character_duty_outfit", 197);
                    break;
                case 5:
                    Outfits.SetUnisexOutfit(player, 198);
                    player.SetData("character_duty_outfit", 198);
                    break;
            }
            return;
        }
    }

    public void ListItemMenuResponse(Client player, String callbackId, int selectedIndex, String objectName, String valueList, int valueIndex)
    {
    }

    public static void OnMenuReturnClose(Client player, String callbackId)
    {
        if(callbackId == "ACLS_VEHICLE_SLOT_SPAWN")
        {
            DisplayAclsVehicles(player);
            return;
        }
        else if (callbackId == "LSPC_VEHICLE_SLOT_SPAWN")
        {
            DisplayAclsVehicles(player);
            return;
        }
    }
}
