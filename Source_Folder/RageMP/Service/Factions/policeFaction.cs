using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using GTANetworkAPI;
using Newtonsoft.Json;
using DerStr1k3r.Core;
using DerStr1k3r.SDK;

class Police : Script
{
    static int[] male_head = { 8, 46};
    static int[] male_glasses = { 0, 9 };
    static int[] male_bodyarmor = { 0, 12, 16 };
    static int[] male_undershirt = { 0, 58, 122, 129, 130 };
    static int[] male_torso = { 0, 19, 30};

    public static int MAX_FACTION_VEHICLES = 200;

    public class call_911_enum : IEquatable<call_911_enum>
    {
        public int id { get; set; }
        public int active { get; set; }
        public Client player { get; set; }
        public Client accept_by { get; set; }
        public ColShape area { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            call_911_enum objAsPart = obj as call_911_enum;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }
        public override int GetHashCode()
        {
            return id;
        }
        public bool Equals(call_911_enum other)
        {
            if (other == null) return false;
            return (this.id.Equals(other.id));
        }
    }
    public static List<call_911_enum> Call_911 = new List<call_911_enum>();

    public Police()
    {
        for(int i = 0; i < 100; i++)
        {
            Call_911.Add(new call_911_enum { id = i, active = 0, player = null, accept_by = null });
        }
    }

    public static void DisplayCopVehicles(Client player)
    {
        int faction_id = AccountManage.GetPlayerGroup(player);
        if (faction_id == 1)
        {
            List<dynamic> menu_item_list = new List<dynamic>();
            menu_item_list.Add(new { Type = 4, Name = "police", Description = "", RightLabel = "~c~Alle" });
            menu_item_list.Add(new { Type = 4, Name = "police2", Description = "", RightLabel = "~c~Alle" });
            menu_item_list.Add(new { Type = 4, Name = "police3", Description = "", RightLabel = "~c~Alle" });
            menu_item_list.Add(new { Type = 4, Name = "pbus", Description = "", RightLabel = "~c~Alle" });
            menu_item_list.Add(new { Type = 4, Name = "policeb", Description = "", RightLabel = "~c~Alle" });
            menu_item_list.Add(new { Type = 4, Name = "pranger", Description = "", RightLabel = "~c~Alle" });
            menu_item_list.Add(new { Type = 4, Name = "Polmav", Description = "", RightLabel = "~c~Rank ~w~8~g~+" });
            menu_item_list.Add(new { Type = 4, Name = "Riot", Description = "", RightLabel = "~o~Rank ~w~9~g~+ (Chief)" });
            InteractMenu.CreateMenu(player, "POLICE_VEHICLE_SLOT_SPAWN", "Garage", "~b~Polizeibehörde Garage:", true, JsonConvert.SerializeObject(menu_item_list), false);
            //player.TriggerEvent("menu_handler_create_menu_generic", "POLICE_VEHICLE_SLOT_SPAWN", "Garage", "~b~Polizeibehörde Garage:", true, JsonConvert.SerializeObject(menu_item_list), "Seite", "durch die Seiten blättern", 100);
        }
    }

    public static void DisplayCopVehicles2(Client player)
    {
        int faction_id = AccountManage.GetPlayerGroup(player);
        if (faction_id == 1)
        {
            List<dynamic> menu_item_list = new List<dynamic>();
            menu_item_list.Add(new { Type = 4, Name = "Baller4", Description = "", RightLabel = "" });
            menu_item_list.Add(new { Type = 4, Name = "Schafter4", Description = "", RightLabel = "" });
            menu_item_list.Add(new { Type = 4, Name = "FIB", Description = "", RightLabel = "" });
            menu_item_list.Add(new { Type = 4, Name = "FIB2", Description = "", RightLabel = "" });
            InteractMenu.CreateMenu(player, "POLICE_VEHICLE_SLOT_SPAWN", "Garage", "~b~Gangunit Garage:", true, JsonConvert.SerializeObject(menu_item_list), false);
            //player.TriggerEvent("menu_handler_create_menu_generic", "POLICE_VEHICLE_SLOT_SPAWN", "Garage", "~b~Polizeibehörde Garage:", true, JsonConvert.SerializeObject(menu_item_list), "Seite", "durch die Seiten blättern", 100);
        }
    }

    public static void SetCopDefaultClothes(Client player)
    {
        Outfits.SetUnisexOutfit(player, 193);
    }

    public static void SetArmyDefaultClothes(Client player)
    {
        Outfits.SetUnisexOutfit(player, 193);
    }

    public static void DisplayCopUniforms(Client player)
    {
        List<dynamic> menu_item_list = new List<dynamic>();

        menu_item_list.Add(new { Type = 1, Name = "Uniform ~c~#1", Description = "", RightLabel = "" });
        menu_item_list.Add(new { Type = 1, Name = "Uniform ~c~#2", Description = "", RightLabel = "" });
        menu_item_list.Add(new { Type = 1, Name = "Uniform ~c~#3", Description = "", RightLabel = "" });
        menu_item_list.Add(new { Type = 1, Name = "Uniform ~c~#4", Description = "", RightLabel = "" });
        menu_item_list.Add(new { Type = 1, Name = "Uniform ~c~#5", Description = "", RightLabel = "" });
        menu_item_list.Add(new { Type = 1, Name = "Uniform ~c~#6", Description = "", RightLabel = "" });
        menu_item_list.Add(new { Type = 1, Name = "Uniform ~c~#7", Description = "", RightLabel = "" });
        menu_item_list.Add(new { Type = 1, Name = "Uniform ~c~#8", Description = "", RightLabel = "" });

        InteractMenu.CreateMenu(player, "POLICE_UNIFORM_RESPONSE", "Uniformen", "~b~Uniform:", true, JsonConvert.SerializeObject(menu_item_list), false);
        //player.TriggerEvent("menu_handler_create_menu_generic", "POLICE_UNIFORM_RESPONSE", "Uniformn", "~b~Uniform:", true, JsonConvert.SerializeObject(menu_item_list), "Seite", "durch die Seiten blättern", 10);
        return;
    }

    public static void SetPlayerCrime(Client player, string crime_name, string accuser, int level)
    {
        player.SetData("character_wanted_level", player.GetData("character_wanted_level") + level);
        player.SetData("character_last_crime", crime_name);
        player.TriggerEvent("SetPlayerWanted", player.GetData("character_wanted_level"));
        NAPI.Notification.SendNotificationToPlayer(player, "[Achtung] Du hast ein Verbrechen begangen. ( " + crime_name + " )");
        NAPI.Notification.SendNotificationToPlayer(player, "[Achtung] Aktuelle gewollte Ebene: " + player.GetData("character_wanted_level"));

        Main.CreateMySqlCommand("INSERT INTO `crime_report` (office, suspect, charge, stars) VALUES('"+accuser+"', '"+player.GetData("character_name")+"', '"+crime_name+"', "+level+");");

        foreach (var target in NAPI.Pools.GetAllPlayers())
        {
            if (target.GetData("status") == true && FactionManage.GetPlayerGroupType(target) == 1)
            {
                NAPI.Notification.SendNotificationToPlayer(target, "Achtung alle Einheiten! Neue Kriminalität trat in einem bestimmten Ausmaß auf: " + level + ", Geschichte: " + accuser + "");
                NAPI.Notification.SendNotificationToPlayer(target, "Verbrechen: " + crime_name + ".");
            }
        }
    }

    public static void ClearPlayerCrime(Client player)
    {
        Main.CreateMySqlCommand("DELETE FROM `crime_report` WHERE `suspect` = '" + player.GetData("character_name") + "';");

        player.SetData("character_wanted_level", 0);
        player.TriggerEvent("SetPlayerWanted", 0);
    }

    public static void SelectMenuResponse(Client player, String callbackId, int selectedIndex, String objectName, String valueList)
    {
        if(callbackId == "CRIME_LIST_RESPONSE")
        {
            int crime_id = selectedIndex;
            
            for (int i = 0; 0 < Main.crime_list.Count; i++)
            {
                if (i == crime_id)
                {
                    string name = Main.crime_list[i].crime_name;
                    int stars = Main.crime_list[i].crime_points;
                    Client target = NAPI.Data.GetEntityData(player, "CMDMandatoTarget");
                    SetPlayerCrime(target, name, player.GetData("character_name"), stars);
                    NAPI.Notification.SendNotificationToPlayer(player, "Sie haben a hinzugefügt~b~" + AccountManage.GetCharacterName(target) + "~w~ von~y~" + name + "~w~.");
                    return;
                }
            }
        }
        else if(callbackId == "POLICE_UNIFORM_RESPONSE")
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
                case 6:
                    if (NAPI.Data.GetEntityData(player, "CHARACTER_ONLINE_GENRE") == 0)
                    {
                        //Customization.SetHat(player, 39, 0);
                        player.SetAccessories(0, 39, 0);
                        player.SetClothes(1, 52, 0);
                        player.SetClothes(11, 53, 0);
                        player.SetClothes(4, 31, 0);
                        player.SetClothes(6, 25, 0);
                        player.SetClothes(9, 15, 2);
                        player.SetClothes(3, 49, 0);
                    }
                    else
                    {
                        //Customization.SetHat(player, 38, 0);
                        player.SetAccessories(0, 39, 0);
                        player.SetClothes(1, 57, 0);
                        player.SetClothes(11, 46, 0);
                        player.SetClothes(4, 30, 0);
                        player.SetClothes(6, 25, 0);
                        player.SetClothes(9, 17, 2);
                        player.SetClothes(3, 53, 0);
                    }
                    break;
                case 7:
                    if (NAPI.Data.GetEntityData(player, "CHARACTER_ONLINE_GENRE") == 0)
                    {
                        player.SetAccessories(0, 123, 2);
                        player.SetClothes(1, 52, 0);
                        player.SetClothes(11, 53, 2);
                        player.SetClothes(4, 31, 2);
                        player.SetClothes(6, 25, 0);
                        // player.SetClothes(9, 15, 2);
                        player.SetClothes(3, 49, 0);
                    }
                    else
                    {
                        player.SetAccessories(0, 122, 2);
                        //Customization.SetHat(player, 122, 2);
                        player.SetClothes(1, 52, 0);
                        player.SetClothes(11, 46, 2);
                        player.SetClothes(4, 30, 2);
                        player.SetClothes(6, 25, 0);
                        //player.SetClothes(9, 17, 2);
                        player.SetClothes(3, 53, 0);
                    }
                    break;
            }
            player.TriggerEvent("freeze", false);
            return;
        }
        else if (callbackId == "POLICE_VEHICLE_SLOT_SPAWN")
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

            if (index == -1)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Nein zu dem Fahrzeug, das derzeit zum Laichen verfügbar ist.");
                return;
            }

            if (vehicle_name == "Polmav" && AccountManage.GetPlayerRank(player) < 3)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Nur Mitglieder mit Rang 3 + kann dieses Fahrzeug verwenden.");
                return;
            }
            else if (vehicle_name == "Fbi" && AccountManage.GetPlayerRank(player) < 2)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Nur Mitglieder mit Rang 2 + kann dieses Fahrzeug verwenden.");
                return;
            }

            Random rnd = new Random();
            int item = rnd.Next(0, 3);
            switch (item)
            {
                case 0:
                    {
                        VehicleHash vehicle = NAPI.Util.VehicleNameToModel(vehicle_name);
                        FactionManage.faction_data[factionid].faction_vehicle_entity[index] = NAPI.Vehicle.CreateVehicle(vehicle, new Vector3(452.5644, -997.0695, 25.35032), new Vector3(-0.9376355, 0.01036374, 179.3837), -1, -1);
                        NAPI.Player.SetPlayerIntoVehicle(player, FactionManage.faction_data[factionid].faction_vehicle_entity[index], -1);
                        NAPI.Vehicle.SetVehicleEngineStatus(FactionManage.faction_data[factionid].faction_vehicle_entity[index], false);
                        Main.SetVehicleFuel(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 100.0);
                        NAPI.Vehicle.SetVehicleNumberPlate(FactionManage.faction_data[factionid].faction_vehicle_entity[index], "LSPD" + SecretService.GetTimestamp(DateTime.Now));
                        //NAPI.Vehicle.SetVehicleEnginePowerMultiplier(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 500);
                        //NAPI.Vehicle.SetVehicleEngineTorqueMultiplier(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 500);
                        NAPI.Vehicle.SetVehicleMod(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 18, 1);
                        NAPI.Vehicle.SetVehicleMod(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 11, 3);
                        NAPI.Vehicle.SetVehicleMod(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 13, 3);
                        break;
                    }
                case 1:
                    {
                        VehicleHash vehicle = NAPI.Util.VehicleNameToModel(vehicle_name);
                        FactionManage.faction_data[factionid].faction_vehicle_entity[index] = NAPI.Vehicle.CreateVehicle(vehicle, new Vector3(436.689, -1005.882, 26.84521), new Vector3(14.40796, -0.6033466, -178.2125), -1, -1);
                        NAPI.Player.SetPlayerIntoVehicle(player, FactionManage.faction_data[factionid].faction_vehicle_entity[index], -1);
                        NAPI.Vehicle.SetVehicleEngineStatus(FactionManage.faction_data[factionid].faction_vehicle_entity[index], false);
                        Main.SetVehicleFuel(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 100.0);
                        NAPI.Vehicle.SetVehicleNumberPlate(FactionManage.faction_data[factionid].faction_vehicle_entity[index], "LSPD" + SecretService.GetTimestamp(DateTime.Now));
                        //NAPI.Vehicle.SetVehicleEnginePowerMultiplier(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 500);
                        //NAPI.Vehicle.SetVehicleEngineTorqueMultiplier(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 500);
                        NAPI.Vehicle.SetVehicleMod(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 18, 1);
                        NAPI.Vehicle.SetVehicleMod(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 11, 3);
                        NAPI.Vehicle.SetVehicleMod(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 13, 3);
                        break;
                    }
                case 2:
                    {
                        VehicleHash vehicle = NAPI.Util.VehicleNameToModel(vehicle_name);
                        FactionManage.faction_data[factionid].faction_vehicle_entity[index] = NAPI.Vehicle.CreateVehicle(vehicle, new Vector3(447.4119, -997.0052, 25.35126), new Vector3(-0.9181333, 0.001428998, -179.4831), -1, 0 - 1);
                        NAPI.Player.SetPlayerIntoVehicle(player, FactionManage.faction_data[factionid].faction_vehicle_entity[index], -1);
                        NAPI.Vehicle.SetVehicleEngineStatus(FactionManage.faction_data[factionid].faction_vehicle_entity[index], false);
                        Main.SetVehicleFuel(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 100.0);
                        NAPI.Vehicle.SetVehicleNumberPlate(FactionManage.faction_data[factionid].faction_vehicle_entity[index], "LSPD" + SecretService.GetTimestamp(DateTime.Now));
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
                        FactionManage.faction_data[factionid].faction_vehicle_entity[index] = NAPI.Vehicle.CreateVehicle(vehicle, new Vector3(431.2721, -1005.77, 26.86351), new Vector3(16.75011, -0.8737264, -176.9977), -1, -1);
                        NAPI.Player.SetPlayerIntoVehicle(player, FactionManage.faction_data[factionid].faction_vehicle_entity[index], -1);
                        NAPI.Vehicle.SetVehicleEngineStatus(FactionManage.faction_data[factionid].faction_vehicle_entity[index], false);
                        Main.SetVehicleFuel(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 100.0);
                        NAPI.Vehicle.SetVehicleNumberPlate(FactionManage.faction_data[factionid].faction_vehicle_entity[index], "LSPD" + SecretService.GetTimestamp(DateTime.Now));
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
    }

    public static void IndexChangeMenuResponse(Client player, String callbackId, int selectedIndex, String objectName, String valueList)
    {
        if (callbackId == "POLICE_UNIFORM_RESPONSE")
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
                case 6:
                    if (NAPI.Data.GetEntityData(player, "CHARACTER_ONLINE_GENRE") == 0)
                    {
                        //Customization.SetHat(player, 39, 0);
                        player.SetAccessories(0, 39, 0);
                        player.SetClothes(11, 53, 1);
                        player.SetClothes(4, 31, 2);
                        player.SetClothes(6, 25, 0);
                        player.SetClothes(9, 28, 9);
                        player.SetClothes(8, 130, 0);
                        player.SetClothes(3, 49, 0);
                    }
                    else
                    {
                        //Customization.SetHat(player, 38, 0);
                        player.SetAccessories(0, 39, 0);
                        player.SetClothes(11, 46, 1);
                        player.SetClothes(4, 30, 2);
                        player.SetClothes(6, 25, 0);
                        player.SetClothes(9, 31, 9);
                        player.SetClothes(8, 160, 0);
                        player.SetClothes(3, 49, 0);
                    }
                    break;
                case 7:
                    if (NAPI.Data.GetEntityData(player, "CHARACTER_ONLINE_GENRE") == 0)
                    {
                        player.SetAccessories(0, 123, 2);
                        player.SetClothes(1, 52, 0);
                        player.SetClothes(11, 53, 2);
                        player.SetClothes(4, 31, 2);
                        player.SetClothes(6, 25, 0);
                        // player.SetClothes(9, 15, 2);
                        player.SetClothes(3, 49, 0);
                    }
                    else
                    {
                        player.SetAccessories(0, 122, 2);
                        //Customization.SetHat(player, 122, 2);
                        player.SetClothes(1, 52, 0);
                        player.SetClothes(11, 46, 2);
                        player.SetClothes(4, 30, 2);
                        player.SetClothes(6, 25, 0);
                        //player.SetClothes(9, 17, 2);
                        player.SetClothes(3, 53, 0);
                    }
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
        if(callbackId == "POLICE_VEHICLE_SLOT_SPAWN")
        {
            DisplayCopVehicles(player);
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

    // Calcular tempo de prisão
    public static int Calcular_Prisao(string name)
    {
        int count = 0, time = 0, crimes = 0, multas = 0;

        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {
            Mainpipeline.Open();
            MySqlCommand query = new MySqlCommand("SELECT * FROM `crime_report` WHERE `suspect` = '" + name + "' OR `suspect` = '" + name.Replace(' ', '_') + "';", Mainpipeline);

            using (MySqlDataReader reader = query.ExecuteReader())
            {
              
                while (reader.Read())
                {
                    if (reader.GetInt32("price") == 0)
                    {
                        time += reader.GetInt32("stars") * 60;
                        crimes++;
                    }
                    else
                    {
                        if (reader.GetInt32("price") < 10000)
                        {
                            time += 1 * 70;
                        }
                        else
                        {
                            time += 2 * 80;
                        }
                        multas++;
                    }
                    count++;
                }

                if (count == 0)
                {
                    time = 0;
                }
            }
        }

        return time;
    }

    #region 911_calls

    // Extened for MDC

    [Command("911")]
    public static void Call_Police(Client player)
    {
        int index = 0;
        foreach (var call in Call_911)
        {
            if (call.active >= 1 && call.player == player)
            {
                index++;
            }
        }

        if(index > 0)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben bereits eine Polizeieinheit angerufen, bitte warten Sie auf dem Gelände oder gehen Sie 15 Meter, um den Anruf abzubrechen.");
            return;
        }

        foreach (var call in Call_911)
        {
            if(call.active == 0)
            {
                call.active = 1;
                call.player = player;

                NAPI.Notification.SendNotificationToPlayer(player,"* Du ~g~angefordert~w~ Bitte warten Sie, bis jemand antwortet ...");
                FactionManage.SendFactionMessage(1, "-Central- "+AccountManage.GetCharacterName(player)+ " fordert eine Polizeieinheit an.");
                return;
            }
     
        }
    }

    [RemoteEvent("mdc_911_accept")]
    public static void Responder_Chamada(Client player, int chamada)
    {

        int count = 0;
        foreach (var call in Call_911)
        {
            if (call.active >= 1 && call.accept_by == player)
            {
                count++;
            }
        }

        if (count > 0)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Sie nehmen bereits einen Anruf an, Sie werden diesen Anruf zuerst beantworten, um einen anderen anzunehmen.");
            return;
        }

        int index = chamada;

        if(Call_911[index].active == 1)
        {
            Client target = Call_911[index].player;

            target.SendChatMessage("* Polizeieinheit~ nahm Ihren Anruf an, bitte warte sofort, dass eine Einheit unterwegs ist.");
            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Folgen Sie dem yellow Symbol auf Ihrem GPS, um zum Ziel des Anrufs zu gelangen.", 5000);

            Call_911[index].active = 2;
            Call_911[index].area = NAPI.ColShape.CreateCylinderColShape(target.Position, 15f, 15f);
            Call_911[index].accept_by = player;

            player.TriggerEvent("blip_remove", "RUFTE SIE AN");
            player.TriggerEvent("blip_create_ext", "RUFTE SIE AN", target.Position, 73, 0.70f, 0);
            player.TriggerEvent("blip_router_visible", "RUFTE SIE AN", true, 73);

            Lista_911(player);
        }
    }

    [RemoteEvent("mdc_911_refuse")]
    public static void Recusar_Chamada(Client player, int chamada)
    {
        int index = chamada;
        if (Call_911[index].active == 1)
        {
            //Call_911[index].Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Der offizielle " + AccountManage.GetCharacterName(player)+ " lehnte seinen Anruf ab.", 5000);
            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du die Nummer #" + chamada+" abgelehnt.", 5000);

            Call_911[index].active = 0;
            Call_911[index].player = null;
            Call_911[index].accept_by = null;

            Lista_911(player);
        }
    }

    public static void OnEnterDynamicArea(Client player, ColShape shape)
    {
        foreach (var call in Call_911)
        {
            if (call.active == 2)
            {
                if(call.area == shape)
                {
                    player.TriggerEvent("blip_remove", "RUFEN");
                    Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie sind am Ziel des Anrufs angekommen.", 5000);

                    call.active = 0;
                    call.player = null;
                    call.accept_by = null;
                    call.area.Delete();
                }
            }
        }
    }

    public static void OnLeaveDynamicArea(Client player, ColShape shape)
    {
        foreach (var call in Call_911)
        {
            if (call.active == 2)
            {
                if (call.area == shape && call.player == player)
                {
                    NAPI.Notification.SendNotificationToPlayer(player,"* Du abgewandt~w~ wo du es angefordert hast. ~c~Der Anruf wurde abgebrochen.");

                    call.active = 0;
                    call.player = null;
                    call.accept_by = null;
                    call.area.Delete();

                    call.accept_by.TriggerEvent("blip_remove", "RUFEN");
                }
            }
        }
    }

    public static void Call_OnDisconect(Client player)
    {
        foreach (var call in Call_911)
        {
            if (call.active == 1)
            {
                if (call.player == player)
                {
                    call.active = 0;
                    call.player = null;
                    call.accept_by = null;
                }
            }
            if (call.active == 2)
            {
                if (call.accept_by == player)
                {
                    Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"* Der Polizist musste zur Apotheke, Ihr Anruf wurde erneut in die Warteschlange gestellt. Bitte warten Sie...", 5000);

                    call.active = 1;
                    call.accept_by = null;
                    call.area.Delete();
                }
                if (call.player == player)
                {
                    Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"* 1x Person, die eine Polizeieinheit beantragt hat, wenn der Anruf abgebrochen wurde.", 5000);

                    call.active = 0;
                    call.player = null;
                    call.accept_by = null;
                    call.area.Delete();

                    call.accept_by.TriggerEvent("blip_remove", "RUFEN");
                }
            }
        }
    }

        #endregion 911_calls

        //
        // MDC System Events
        //

        #region MDC
    public static void ShowMDC(Client player)
    {
        if (Inventory.GetPlayerItemFromInventory(player, 154) >= 1)
        {
            if (Main.IsInRangeOfPoint(player.Position, new Vector3(441.2615, -978.7208, 30.6896), 2.0f))
            {
                player.TriggerEvent("Display_MDC");
            }
            else if (Main.IsInRangeOfPoint(player.Position, new Vector3(461.4842, -1007.66, 35.93107), 2.0f))
            {
                player.TriggerEvent("Display_MDC");
            }
        }
        if (Inventory.GetPlayerItemFromInventory(player, 155) >= 1)
        {
            if (Main.IsInRangeOfPoint(player.Position, new Vector3(107.6871, -747.3194, 242.1521), 2.0f))
            {
                player.TriggerEvent("Display_MDC");
            }
            else if (Main.IsInRangeOfPoint(player.Position, new Vector3(109.9118, -743.1069, 242.1521), 2.0f))
            {
                player.TriggerEvent("Display_MDC");
            }
            else if (Main.IsInRangeOfPoint(player.Position, new Vector3(111.4035, -754.4329, 242.1523), 2.0f))
            {
                player.TriggerEvent("Display_MDC");
            }
            else if (Main.IsInRangeOfPoint(player.Position, new Vector3(109.7236, -750.8882, 242.1523), 2.0f))
            {
                player.TriggerEvent("Display_MDC");
            }
        }
        if (Inventory.GetPlayerItemFromInventory(player, 156) >= 1)
        {
            if (Main.IsInRangeOfPoint(player.Position, new Vector3(441.2615, -978.7208, 30.6896), 2.0f))
            {
                player.TriggerEvent("Display_MDC");
            }
            else if (Main.IsInRangeOfPoint(player.Position, new Vector3(461.4842, -1007.66, 35.93107), 2.0f))
            {
                player.TriggerEvent("Display_MDC");
            }
            else if (Main.IsInRangeOfPoint(player.Position, new Vector3(107.6871, -747.3194, 242.1521), 2.0f))
            {
                player.TriggerEvent("Display_MDC");
            }
            else if (Main.IsInRangeOfPoint(player.Position, new Vector3(109.9118, -743.1069, 242.1521), 2.0f))
            {
                player.TriggerEvent("Display_MDC");
            }
            else if (Main.IsInRangeOfPoint(player.Position, new Vector3(111.4035, -754.4329, 242.1523), 2.0f))
            {
                player.TriggerEvent("Display_MDC");
            }
            else if (Main.IsInRangeOfPoint(player.Position, new Vector3(109.7236, -750.8882, 242.1523), 2.0f))
            {
                player.TriggerEvent("Display_MDC");
            }
        }
    }

    [RemoteEvent("mdc_checar_player")]
    public static void Checar_Ficha(Client player, string name)
    {
        //NAPI.Util.ConsoleOutput(name);
        List<dynamic> data = new List<dynamic>();
        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {
            Mainpipeline.Open();
            MySqlCommand query = new MySqlCommand("SELECT * FROM `crime_report` WHERE `suspect` = '" + name + "' OR `suspect` = '" + name.Replace(' ', '_') + "';", Mainpipeline);
               
            using(MySqlDataReader reader = query.ExecuteReader())
            {
                while (reader.Read())
                {
                    data.Add(new { Office = reader.GetString("office"), Suspect = reader.GetString("suspect"), Charge = reader.GetString("charge"), Stars = reader.GetInt32("stars"), Price = reader.GetInt32("price"), Data = reader.GetString("datetime") });
                }
            }
        }
        player.TriggerEvent("mdc_response_player", NAPI.Util.ToJson(data));
    }

    [RemoteEvent("mdc_print_suspect")]
    public static void Print_Ficha(Client player, string name)
    {
        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {
            Mainpipeline.Open();
            MySqlCommand query = new MySqlCommand("SELECT * FROM `crime_report` WHERE `suspect` = '" + name + "' OR `suspect` = '" + name.Replace(' ', '_') + "';", Mainpipeline);
            using (MySqlDataReader reader = query.ExecuteReader())
            {
                NAPI.Notification.SendNotificationToPlayer(player,"~w~Ficha de ~b~" + name + ":");

                int count = 0;
                while (reader.Read())
                {
                    if (reader.GetInt32("price") == 0)
                    {
                        NAPI.Notification.SendNotificationToPlayer(player, "Verbrechen:~w~ " + reader.GetString("charge") + " - Offiziell: " + reader.GetString("office") + " - Schwere des Verbrechens: " + reader.GetInt32("stars") + ".");
                    }
                    else
                    {
                        NAPI.Notification.SendNotificationToPlayer(player, "Gut:~w~ " + reader.GetString("charge") + " - Offiziell: " + reader.GetString("office") + " - Preis der Geldstrafe: " + reader.GetInt32("price") + ".");
                    }
                    count++;
                }

                if (count == 0)
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "Wir konnten keine Straftaten finden / Geldstrafen von " + name + " in unserer datenbank.");
                }
            }
        }
    }

    [RemoteEvent("mdc_print_prison")]
    public static void Print_Prision(Client player, string name)
    {
        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {
            Mainpipeline.Open();
            MySqlCommand query = new MySqlCommand("SELECT * FROM `crime_report` WHERE `suspect` = '" + name + "' OR `suspect` = '" + name.Replace(' ', '_') + "';", Mainpipeline);
            using (MySqlDataReader reader = query.ExecuteReader())
            {
                int count = 0, time = 0, crimes = 0, multas = 0;
                while (reader.Read())
                {
                    if (reader.GetInt32("price") == 0)
                    {
                        time += reader.GetInt32("stars") * 60;
                        crimes++;
                    }
                    else
                    {
                        if (reader.GetInt32("price") < 10000)
                        {
                            time += 1 * 70;
                        }
                        else
                        {
                            time += 2 * 80;
                        }
                        multas++;
                    }
                    count++;
                }
                if (count == 0)
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "Wir konnten keine Straftaten finden / Geldstrafen von  " + name + " in unserer datenbank.");
                }
                else
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "Du musst ~b~" + name + "~w~ wird auf geschätzt ~y~" + time + "~w~ Sekunden. Für ihre" + crimes + "Verbrechen und " + multas + " Geldstrafen");
                }
            }
        }
    }


    [RemoteEvent("mdc_checar_vehicle")]
    public void CMD_finevehicle(Client player, string placa)
    {
        List<dynamic> data = new List<dynamic>();

        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {
            Mainpipeline.Open();
            MySqlCommand query = new MySqlCommand("SELECT * FROM `vehicles` WHERE `vehicle_plate` = '" + placa + "' or `vehicle_plate` = '" + placa.Replace(" ", "-") + "';", Mainpipeline);

            using (MySqlDataReader reader = query.ExecuteReader())
            {
                string data2txt = string.Empty;
                string datatxt = string.Empty;

                //var index = 0;
                while (reader.Read())
                {
                    string vehicle_plate = reader.GetString("vehicle_plate");
                    if (vehicle_plate == placa)
                    {
                        if (AccountManage.GetPlayerNameFromSQL(reader.GetInt32("vehicle_owner_id")) != null)
                        {
                            data.Add(new { Owner = AccountManage.GetPlayerNameFromSQL(reader.GetInt32("vehicle_owner_id")), Model = reader.GetString("vehicle_model"), Plate = reader.GetString("vehicle_plate"), Ticket = reader.GetString("vehicle_ticket") });
                        }
                    }
                }
            }
        }
        player.TriggerEvent("mdc_response_vehicle", NAPI.Util.ToJson(data));
    }

    [RemoteEvent("mdc_warrant_list")]
    public void Lista_Procurados(Client player)
    {
        List<dynamic> data = new List<dynamic>();

        foreach(Client suspect in NAPI.Pools.GetAllPlayers())
        {
            data.Add(new { Suspect = NAPI.Data.GetEntityData(suspect, "character_name"), LastCrime = NAPI.Data.GetEntityData(suspect, "character_last_crime"), Wanted = NAPI.Data.GetEntityData(suspect, "character_wanted_level") });
        }
        player.TriggerEvent("mdc_response_warrants", NAPI.Util.ToJson(data));
    }

    [RemoteEvent("mdc_911_list")]
    public static void Lista_911(Client player)
    {
        List<dynamic> data = new List<dynamic>();
        int index = 0;
        foreach (var call in Call_911)
        {
            if (call.active == 1)
            {
                data.Add(new { Index = index, Player = AccountManage.GetCharacterName(call.player), Distance = call.player.Position.DistanceTo(player.Position).ToString("0") });
            }
            index++;
        }
        player.TriggerEvent("mdc_response_911list", NAPI.Util.ToJson(data));
    }
    #endregion MDC
}
