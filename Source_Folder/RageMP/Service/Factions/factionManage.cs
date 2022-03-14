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
using Newtonsoft.Json;
using DerStr1k3r.Core;
using DerStr1k3r.SDK;

public class FactionManage : Script
{
    //int teste = PlayerVehicles.IndexOf(new vehicleEnum() { player_vehicle_id = 55 });
    public static int MAX_FACTIONS = 200;
    public static int MAX_FACTION_RANK = 10;

    public static int FACTION_TYPE_NONE = 0;
    public static int FACTION_TYPE_POLICE = 1;
    public static int FACTION_TYPE_MEDIC = 2;
    public static int FACTION_TYPE_REPORTER = 3;
    public static int FACTION_TYPE_GANGUE = 4;
    public static int FACTION_TYPE_GANGUNIT = 5;
    public static int FACTION_TYPE_BENNYS = 6;
    public static int FACTION_TYPE_LOSTMCCUSTOM = 7;
    public static int FACTION_TYPE_ACLS = 8;
    public static int FACTION_TYPE_DOJ = 9;
    public static int FACTION_TYPE_TAXI = 10;
    public static int FACTION_TYPE_LSC = 11;
    public static int FACTION_TYPE_VANILLA_UNICORN = 12;
    public static int FACTION_TYPE_LSGOPOSTAL = 13;
    public static int FACTION_TYPE_LSPRESIDENT = 14;
    public static int FACTION_TYPE_LSSECRETSERVICE = 15;
    public static int FACTION_TYPE_NOOSETEAM = 16;

    public class FactionEnum : IEquatable<FactionEnum>
    {
        public int faction_id { get; set; }
        public int faction_type { get; set; }
        public string faction_name { get; set; }
        public string faction_abbrev { get; set; }
        public int faction_leader { get; set; }
        public string faction_motd { get; set; }
        public string faction_rplerinfo { get; set; }
        public string faction_color { get; set; }
        public string faction_logo { get; set; }
        public string faction_description { get; set; }
        public int faction_turf_color { get; set; }

        public string[] faction_rank { get; set; } = new string[MAX_FACTION_RANK];
        public int[] faction_salary { get; set; } = new int[MAX_FACTION_RANK];


        public int faction_armory_recurso { get; set; }
        public string[] faction_armory_gun { get; set; } = new string[20];
        public int[] faction_armory_stock { get; set; } = new int[20];
        public int[] faction_armory_price { get; set; } = new int[20];

        public Entity faction_armory_marker { get; set; }
        public Entity faction_armory_label { get; set; }

        public float faction_armory_x { get; set; }
        public float faction_armory_y { get; set; }
        public float faction_armory_z { get; set; }

        public string[] faction_vehicle_name { get; set; } = new string[MAX_FACTION_VEHICLES];
        public string[] faction_vehicle_owned { get; set; } = new string[MAX_FACTION_VEHICLES];
        public Vehicle[] faction_vehicle_entity { get; set; } = new Vehicle[MAX_FACTION_VEHICLES];
        
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            FactionEnum objAsPart = obj as FactionEnum;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }
        public override int GetHashCode()
        {
            return faction_id;
        }
        public bool Equals(FactionEnum other)
        {
            if (other == null) return false;
            return (this.faction_id.Equals(other.faction_id));
        }
    }

    public static List<FactionEnum> faction_data = new List<FactionEnum>();

    public static void FactionInit()
    {

        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {
            Mainpipeline.Open();
            MySqlCommand query = new MySqlCommand("SELECT * FROM `faction`;", Mainpipeline);

            using (MySqlDataReader reader = query.ExecuteReader())
            {
                var index = 0;
                while (reader.Read())
                {
                    faction_data.Add(new FactionEnum()
                    {
                        faction_id = reader.GetInt32("id"),
                        faction_type = reader.GetInt32("type"),
                        faction_name = reader.GetString("name"),
                        faction_abbrev = reader.GetString("abbrev"),
                        faction_leader = reader.GetInt32("leader"),
                        faction_motd = reader.GetString("motd"),
                        faction_color = reader.GetString("color"),
                        faction_logo = reader.GetString("logo"),
                        faction_description = reader.GetString("description"),
                        faction_turf_color = reader.GetInt32("zone_color"),
                    });

                    for (int i = 0; i < 20; i++)
                    {
                        faction_data[index].faction_armory_gun[i] = reader.GetString("armory_gun_" + i);
                        faction_data[index].faction_armory_stock[i] = reader.GetInt32("armory_stock_" + i);
                        faction_data[index].faction_armory_price[i] = reader.GetInt32("armory_price_" + i);
                        ////NAPI.Util.ConsoleOutput("[Faction rank] Rank: " + faction_data[factionid].faction_rank[i] + " - Name: " + faction_data[factionid].faction_name + " - Salary " + faction_data[factionid].faction_salary[i] + ".");
                    }

                    faction_data[index].faction_armory_recurso = reader.GetInt32("stock");
                    faction_data[index].faction_armory_x = reader.GetFloat("armory_x");
                    faction_data[index].faction_armory_y = reader.GetFloat("armory_y");
                    faction_data[index].faction_armory_z = reader.GetFloat("armory_z") - 1.0f;

                    faction_data[index].faction_armory_label = NAPI.TextLabel.CreateTextLabel("~y~~h~- Arsenal von ~b~" + faction_data[index].faction_name + "~y~ -~w~~h~~n~~n~~w~Benutze ~y~~h~E~h~~w~ ", new Vector3(faction_data[index].faction_armory_x, faction_data[index].faction_armory_y, faction_data[index].faction_armory_z + 0.3), 12, 0.3500f, 4, new Color(255, 255, 255, 255));
                    faction_data[index].faction_armory_marker = NAPI.Marker.CreateMarker(27, new Vector3(faction_data[index].faction_armory_x, faction_data[index].faction_armory_y, faction_data[index].faction_armory_z - 1.0), new Vector3(), new Vector3(), 0.8f, new Color(255, 208, 0, 200));


                    for (int b = 0; b < MAX_FACTION_VEHICLES; b++)
                    {
                        faction_data[index].faction_vehicle_name[b] = "Frei";
                        faction_data[index].faction_vehicle_owned[b] = "Niemand";
                    }

                    // //NAPI.Util.ConsoleOutput("[Faction Load] ID: " + index + " - Name: " + faction_data[index].faction_name + ".  "+ faction_data[index].faction_armory_x + "");
                    LoadFactionRank(index);
                    index++;
                }
            }
        }
    }




    public static void LoadFactionRank(int factionid)
    {
        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {
            Mainpipeline.Open();
            MySqlCommand query = new MySqlCommand("SELECT * FROM `faction_rank` WHERE  `id` = " + factionid + ";", Mainpipeline);
            MySqlDataReader reader = query.ExecuteReader();
            while (reader.Read())
            {
                for (int i = 0; i < MAX_FACTION_RANK; i++)
                {
                    faction_data[factionid].faction_rank[i] = reader.GetString("rank_" + i);
                    faction_data[factionid].faction_salary[i] = reader.GetInt32("salary_" + i);
                    ////NAPI.Util.ConsoleOutput("[Faction rank] Rank: " + faction_data[factionid].faction_rank[i] + " - Name: " + faction_data[factionid].faction_name + " - Salary " + faction_data[factionid].faction_salary[i] + ".");
                }
            }
        }
    }


    public static void SaveFaction(int index)
    {
        string query = "UPDATE faction SET name = @name, type = @type, abbrev = @abbrev, leader = @leader, motd = @motd, color = @color, `stock` = @stock, `armory_x` = @armory_x, `armory_y` = @armory_y, `armory_z` = @armory_z, `zone_color` = @zone_color";

        for (int i = 0; i < 20; i++)
        {
            query = query + ", armory_gun_" + i + " = '" + faction_data[index].faction_armory_gun[i] + "', armory_stock_" + i + " = '" + faction_data[index].faction_armory_stock[i] + "', armory_price_" + i + " = '" + faction_data[index].faction_armory_price[i] + "' ";
        }
        query = query + " WHERE `id` = '" + index + "'";


        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {
            try
            {
                Mainpipeline.Open();

                MySqlCommand myCommand = new MySqlCommand(query, Mainpipeline);

                // paramenters
                myCommand.Parameters.AddWithValue("@name", faction_data[index].faction_name);
                myCommand.Parameters.AddWithValue("@type", faction_data[index].faction_type);
                myCommand.Parameters.AddWithValue("@abbrev", faction_data[index].faction_abbrev);
                myCommand.Parameters.AddWithValue("@leader", faction_data[index].faction_leader);
                myCommand.Parameters.AddWithValue("@motd", faction_data[index].faction_motd);
                myCommand.Parameters.AddWithValue("@color", faction_data[index].faction_color);
                myCommand.Parameters.AddWithValue("@zone_color", faction_data[index].faction_turf_color);

                myCommand.Parameters.AddWithValue("@stock", faction_data[index].faction_armory_recurso);
                myCommand.Parameters.AddWithValue("@armory_x", faction_data[index].faction_armory_x);
                myCommand.Parameters.AddWithValue("@armory_y", faction_data[index].faction_armory_y);
                myCommand.Parameters.AddWithValue("@armory_z", faction_data[index].faction_armory_z);


                // command
                myCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //NAPI.Util.ConsoleOutput("[EXCEPTION SaveFaction] " + ex.Message);
                //NAPI.Util.ConsoleOutput("[EXCEPTION SaveFaction] " + ex.StackTrace);
            }
        }
    }

    public static void SaveFactionRanks(int index)
    {
        string query = "UPDATE faction_rank SET rank_0 = '" + faction_data[index].faction_rank[0] + "', salary_0 = '" + faction_data[index].faction_salary[0] + "'";
        for (int i = 0; i < MAX_FACTION_RANK; i++)
        {
            query = query + ", rank_" + i + " = '" + faction_data[index].faction_rank[i] + "', salary_" + i + " = '" + faction_data[index].faction_salary[i] + "'";
        }
        query = query + "WHERE `id` = '" + index + "'";

        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {
            try
            {
                Mainpipeline.Open();
                MySqlCommand myCommand = new MySqlCommand(query, Mainpipeline);
                myCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //NAPI.Util.ConsoleOutput("[EXCEPTION SaveFactionRanks] " + ex.Message);
                //NAPI.Util.ConsoleOutput("[EXCEPTION SaveFactionRanks] " + ex.StackTrace);
            }

        }
    }

    public static int GetPlayerGroupType(Client player)
    {
        return faction_data[NAPI.Data.GetEntityData(player, "character_group")].faction_type;
    }

    public static string Faction_Type(int factionid)
    {
        string type = "Zivilist";
        switch (factionid)
        {
            case 1:
                {
                    type = "Polizei";
                    break;
                }

            case 2:
                {
                    type = "Medic";
                    break;
                }
            case 3:
                {
                    type = "Reporter";
                    break;
                }
            case 4:
                {
                    type = "Gang";
                    break;
                }
            case 5:
                {
                    type = "Gangunit";
                    break;
                }
            case 6:
                {
                    type = "Bennys";
                    break;
                }
            case 7:
                {
                    type = "Lost MC Custom";
                    break;
                }
            case 8:
                {
                    type = "ACLS";
                    break;
                }
            case 9:
                {
                    type = "DoJ";
                    break;
                }
            case 10:
                {
                    type = "Los Santos Taxi";
                    break;
                }
            case 11:
                {
                    type = "LS Customs";
                    break;
                }
            case 12:
                {
                    type = "Vanilla Unicorn";
                    break;
                }
            case 13:
                {
                    type = "LS Go Postal";
                    break;
                }
            case 14:
                {
                    type = "LS President";
                    break;
                }
            case 15:
                {
                    type = "LS FIB";
                    break;
                }
            case 16:
                {
                    type = "Army Fort Zancundo";
                    break;
                }
        }
        return type;
    }

    public static int GetMaxRank(int index)
    {
        int rank = MAX_FACTION_RANK - 1;
        while (0 < rank)
        {
            if (faction_data[index].faction_rank[rank] != "Zivilist")
            {
                //NAPI.Util.ConsoleOutput(">>>>>>> hier gestoppt" + rank + " -- " + faction_data[index].faction_rank[rank] + "");
                return rank;
            }
            rank--;
        }
        return MAX_FACTION_RANK - 1;
    }

    public static void DisplayEditFaction(Client player)
    {
        int index = NAPI.Data.GetEntityData(player, "EditingFactionID");

        List<string> list = new List<string>();

        list.Add("Zivilist");
        list.Add("Polizei");
        list.Add("Medic");
        list.Add("Reporter");
        list.Add("Gang");
        list.Add("Gangunit");
        list.Add("Bennys");
        list.Add("Lost MC Custom");
        list.Add("ACLS");
        list.Add("DoJ");
        list.Add("Los Santos Taxi");
        list.Add("LS Customs");
        list.Add("Vanilla Unicorn");
        list.Add("LS Go Postal");
        list.Add("LS President");
        list.Add("LS FIB");
        list.Add("Army Fort Zancundo");

        List<dynamic> menu_item_list = new List<dynamic>();
        
        menu_item_list.Add(new { Type = 1, Name = "Name", Description = "", RightLabel = "~b~" + faction_data[index].faction_name });
        menu_item_list.Add(new { Type = 6, Name = "Typ", Description = "", List = list, StartIndex = faction_data[index].faction_type });
        menu_item_list.Add(new { Type = 1, Name = "Verkürzung", Description = "", RightLabel = "~y~" + faction_data[index].faction_abbrev });
        menu_item_list.Add(new { Type = 1, Name = "Gangfarbe", Description = "Muss in Hex-Farbe sein, ~y~Beispiel: ~w~FFFFFF", RightLabel = "~y~" + faction_data[index].faction_color });
        menu_item_list.Add(new { Type = 1, Name = "Gebietsfarbe", Description = "Siehe die Farb - ID in: ~y~https://wiki.rage.mp/index.php?title=Blips", RightLabel = "~y~" + faction_data[index].faction_turf_color });
        menu_item_list.Add(new { Type = 1, Name = "Gebühren bearbeiten", Description = "", RightLabel = "~c~>>" });
        menu_item_list.Add(new { Type = 1, Name = "Lohn bearbeiten", Description = "", RightLabel = "~c~>>" });
        menu_item_list.Add(new { Type = 1, Name = "Arsenal-Position bearbeiten", Description = "" });
        menu_item_list.Add(new { Type = 1, Name = "Arsenal Stock bearbeiten", Description = "", RightLabel = "~y~" + faction_data[index].faction_armory_recurso });
        menu_item_list.Add(new { Type = 1, Name = "Arsenalwaffen bearbeiten", Description = "", RightLabel = "~c~>>" });
        menu_item_list.Add(new { Type = 1, Name = "Bearbeiten Sie die Kosten für Arsenal-Waffen", Description = "", RightLabel = "~c~>>" });

        InteractMenu.CreateMenu(player, "FACTION_EDITING_MENU", "Faction", "Bearbeitung ~b~" + faction_data[index].faction_name + " ~c~(" + index + ").", true, JsonConvert.SerializeObject(menu_item_list), false);
    }
    public static int MAX_FACTION_VEHICLES = 200;

    public static void DisplayFactionVehicles(Client player)
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
            InteractMenu.CreateMenu(player, "VEHICLE_FACTION_SPAWN", "Garage", "~b~Polizei Garage:", true, JsonConvert.SerializeObject(menu_item_list), false);
            //player.TriggerEvent("menu_handler_create_menu_generic", "VEHICLE_FACTION_SPAWN", "Garage", "~b~Polizei Garage:", true, JsonConvert.SerializeObject(menu_item_list), "Seite", "durch die Seiten blättern", 100);
        }
        else if (faction_id == 2)
        {
            List<dynamic> menu_item_list = new List<dynamic>();
            menu_item_list.Add(new { Type = 4, Name = "Ambulance", Description = "", RightLabel = "~c~Alle" });
            menu_item_list.Add(new { Type = 4, Name = "FireTruck", Description = "", RightLabel = "~c~Alle" });
            menu_item_list.Add(new { Type = 4, Name = "Supervolito", Description = "", RightLabel = "~c~Alle" });
            InteractMenu.CreateMenu(player, "VEHICLE_FACTION_SPAWN", "Garage", "~b~Polizei Garage:", true, JsonConvert.SerializeObject(menu_item_list), false);
            //player.TriggerEvent("menu_handler_create_menu_generic", "VEHICLE_FACTION_SPAWN", "Garage", "~b~LSMC Garage:", true, JsonConvert.SerializeObject(menu_item_list), "Seite", "durch die Seiten blättern", 100);
        }
        else if (faction_id == 3)
        {
            List<dynamic> menu_item_list = new List<dynamic>();
            menu_item_list.Add(new { Type = 4, Name = "Sheriff", Description = "", RightLabel = "~c~Alle" });
            menu_item_list.Add(new { Type = 4, Name = "Sheriff2", Description = "", RightLabel = "~c~Alle" });
            menu_item_list.Add(new { Type = 4, Name = "Spsuv", Description = "", RightLabel = "~c~Alle" });
            menu_item_list.Add(new { Type = 4, Name = "Pranger", Description = "", RightLabel = "~c~Alle" });
            menu_item_list.Add(new { Type = 4, Name = "Police4", Description = "", RightLabel = "~c~Alle" });
            menu_item_list.Add(new { Type = 4, Name = "Polmav", Description = "", RightLabel = "~c~Rank ~w~5~g~+" });
            InteractMenu.CreateMenu(player, "VEHICLE_FACTION_SPAWN", "Garage", "~b~Polizei Garage:", true, JsonConvert.SerializeObject(menu_item_list), false);
            //player.TriggerEvent("menu_handler_create_menu_generic", "VEHICLE_FACTION_SPAWN", "Garage", "~b~Polizei Garage:", true, JsonConvert.SerializeObject(menu_item_list), "Seite", "durch die Seiten blättern", 100);
        }
        else if (faction_id == 1)
        {
            List<dynamic> menu_item_list = new List<dynamic>();
            menu_item_list.Add(new { Type = 4, Name = "FBI", Description = "", RightLabel = "~c~Alle" });
            menu_item_list.Add(new { Type = 4, Name = "FBI2", Description = "", RightLabel = "~c~Alle" });
            menu_item_list.Add(new { Type = 4, Name = "Sheriff", Description = "", RightLabel = "~c~Alle" });
            menu_item_list.Add(new { Type = 4, Name = "Schafter4", Description = "", RightLabel = "~c~Alle" });
            InteractMenu.CreateMenu(player, "VEHICLE_FACTION_SPAWN", "Garage", "~b~Gangunit Garage:", true, JsonConvert.SerializeObject(menu_item_list), false);
            //player.TriggerEvent("menu_handler_create_menu_generic", "VEHICLE_FACTION_SPAWN", "Garage", "~b~Polizei Garage:", true, JsonConvert.SerializeObject(menu_item_list), "Seite", "durch die Seiten blättern", 100);
        }
        else if (AccountManage.GetPlayerGroup(player) == 25)
        {
            List<dynamic> menu_item_list = new List<dynamic>();
            menu_item_list.Add(new { Type = 4, Name = "FBI", Description = "", RightLabel = "~c~Alle" });
            menu_item_list.Add(new { Type = 4, Name = "FBI2", Description = "", RightLabel = "~c~Alle" });
            menu_item_list.Add(new { Type = 4, Name = "police4", Description = "", RightLabel = "~c~Alle" });
            InteractMenu.CreateMenu(player, "VEHICLE_FACTION_SPAWN", "Garage", "~b~LS FIB:", true, JsonConvert.SerializeObject(menu_item_list), false);
            //player.TriggerEvent("menu_handler_create_menu_generic", "VEHICLE_FACTION_SPAWN", "Garage", "~b~Polizei Garage:", true, JsonConvert.SerializeObject(menu_item_list), "Seite", "durch die Seiten blättern", 100);
        }
        else if (AccountManage.GetPlayerGroup(player) == 15)
        {
            List<dynamic> menu_item_list = new List<dynamic>();
            menu_item_list.Add(new { Type = 4, Name = "TowTruck", Description = "", RightLabel = "~c~Alle" });
            menu_item_list.Add(new { Type = 4, Name = "TowTruck2", Description = "", RightLabel = "~c~Alle" });
            InteractMenu.CreateMenu(player, "VEHICLE_FACTION_SPAWN", "Garage", "~b~ACLS Garage:", true, JsonConvert.SerializeObject(menu_item_list), false);
            //player.TriggerEvent("menu_handler_create_menu_generic", "VEHICLE_FACTION_SPAWN", "Garage", "~b~ACLS Garage:", true, JsonConvert.SerializeObject(menu_item_list), "Seite", "durch die Seiten blättern", 100);
        }
        else if (AccountManage.GetPlayerGroup(player) == 21)
        {
            List<dynamic> menu_item_list = new List<dynamic>();
            menu_item_list.Add(new { Type = 4, Name = "TowTruck", Description = "", RightLabel = "~c~Alle" });
            menu_item_list.Add(new { Type = 4, Name = "TowTruck2", Description = "", RightLabel = "~c~Alle" });
            InteractMenu.CreateMenu(player, "VEHICLE_FACTION_SPAWN", "Garage", "~b~LPC Garage:", true, JsonConvert.SerializeObject(menu_item_list), false);
            //player.TriggerEvent("menu_handler_create_menu_generic", "VEHICLE_FACTION_SPAWN", "Garage", "~b~ACLS Garage:", true, JsonConvert.SerializeObject(menu_item_list), "Seite", "durch die Seiten blättern", 100);
        }
        else if (AccountManage.GetPlayerGroup(player) == 26)
        {
            List<dynamic> menu_item_list = new List<dynamic>();
            menu_item_list.Add(new { Type = 4, Name = "APC", Description = "", RightLabel = "" });
            menu_item_list.Add(new { Type = 4, Name = "Crusader", Description = "", RightLabel = "" });
            menu_item_list.Add(new { Type = 4, Name = "Halftrack", Description = "", RightLabel = "" });
            menu_item_list.Add(new { Type = 4, Name = "Barracks", Description = "", RightLabel = "" });
            menu_item_list.Add(new { Type = 4, Name = "Barracks2", Description = "", RightLabel = "" });
            menu_item_list.Add(new { Type = 4, Name = "Barracks3", Description = "", RightLabel = "" });
            menu_item_list.Add(new { Type = 4, Name = "minitank", Description = "", RightLabel = "" });
            InteractMenu.CreateMenu(player, "VEHICLE_FACTION_SPAWN", "Garage", "~b~Army Fort Zancundo Garage:", true, JsonConvert.SerializeObject(menu_item_list), false);
            //player.TriggerEvent("menu_handler_create_menu_generic", "VEHICLE_FACTION_SPAWN", "Garage", "~b~Polizei Garage:", true, JsonConvert.SerializeObject(menu_item_list), "Seite", "durch die Seiten blättern", 100);
        }
    }

    public static String GetTimestamp(DateTime value)
    {
        return value.ToString("HHmmss");
    }

    public static void SelectMenuResponse(Client player, String callbackId, int selectedIndex, String objectName, String valueList)
    {
        if (callbackId == "VEHICLE_FACTION_SPAWN")
        {
            string vehicle_name = objectName;

            var factionid = AccountManage.GetPlayerGroup(player);
            if (factionid == -1) { return; }

            int index = -1;
            for (int i = 0; i < MAX_FACTION_VEHICLES; i++)
            {
                if (faction_data[factionid].faction_vehicle_name[i] == "Frei")
                {
                    index = i;
                }
            }

            if (index == -1)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Nicht das zur Zeit verfügbare Fahrzeug in der Garage.");
                return;
            }

            if (factionid == 1)
            {
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

                for (int i = 0; i < MAX_FACTION_VEHICLES; i++)
                {
                    if (faction_data[factionid].faction_vehicle_owned[i] == AccountManage.GetCharacterName(player))
                    {
                        try { if (faction_data[factionid].faction_vehicle_entity[i] != null && faction_data[factionid].faction_vehicle_entity[i].Exists) faction_data[factionid].faction_vehicle_entity[i].Delete(); faction_data[factionid].faction_vehicle_entity[i] = null; } catch (Exception) { }
                        faction_data[factionid].faction_vehicle_name[i] = "Frei";
                        faction_data[factionid].faction_vehicle_owned[i] = "Niemand";
                    }
                }
                if (vehicle_name == "Polmav")
                {
                    var hash = NAPI.Util.GetHashKey(vehicle_name).GetHashCode();
                    VehicleHash vehicle = NAPI.Util.VehicleNameToModel(vehicle_name);
                    faction_data[factionid].faction_vehicle_entity[index] = NAPI.Vehicle.CreateVehicle(hash, new Vector3(449.2292, -981.2446, 43.69167), new Vector3(0, 0, 83.33051), -1, -1);
                    NAPI.Player.SetPlayerIntoVehicle(player, faction_data[factionid].faction_vehicle_entity[index], -1);
                    NAPI.Vehicle.SetVehicleEngineStatus(faction_data[factionid].faction_vehicle_entity[index], false);
                    Main.SetVehicleFuel(faction_data[factionid].faction_vehicle_entity[index], 100.0);
                    NAPI.Vehicle.SetVehicleNumberPlate(faction_data[factionid].faction_vehicle_entity[index], "LSPD" + SecretService.GetTimestamp(DateTime.Now));
                    NAPI.Vehicle.SetVehicleEnginePowerMultiplier(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 500);
                    NAPI.Vehicle.SetVehicleEngineTorqueMultiplier(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 500);
                    NAPI.Vehicle.SetVehicleMod(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 18, 1);
                    NAPI.Vehicle.SetVehicleMod(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 11, 3);
                    NAPI.Vehicle.SetVehicleMod(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 13, 3);
                }
                else
                {
                    Random rnd = new Random();
                    int item = rnd.Next(0, 3);
                    var hash = NAPI.Util.GetHashKey(vehicle_name).GetHashCode();
                    switch (item)
                    {
                        case 0:
                            {
                                //VehicleHash vehicle = NAPI.Util.VehicleNameToModel(vehicle_name);
                                faction_data[factionid].faction_vehicle_entity[index] = NAPI.Vehicle.CreateVehicle(hash, new Vector3(452.5644, -997.0695, 25.35032), new Vector3(-0.9376355, 0.01036374, 179.3837), -1, -1);
                                NAPI.Player.SetPlayerIntoVehicle(player, faction_data[factionid].faction_vehicle_entity[index], -1);
                                NAPI.Vehicle.SetVehicleEngineStatus(faction_data[factionid].faction_vehicle_entity[index], false);
                                Main.SetVehicleFuel(faction_data[factionid].faction_vehicle_entity[index], 100.0);
                                NAPI.Vehicle.SetVehicleNumberPlate(faction_data[factionid].faction_vehicle_entity[index], "LSPD" + SecretService.GetTimestamp(DateTime.Now));
                                NAPI.Vehicle.SetVehicleEnginePowerMultiplier(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 500);
                                NAPI.Vehicle.SetVehicleEngineTorqueMultiplier(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 500);
                                NAPI.Vehicle.SetVehicleMod(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 18, 1);
                                NAPI.Vehicle.SetVehicleMod(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 11, 3);
                                NAPI.Vehicle.SetVehicleMod(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 13, 3);
                                break;
                            }
                        case 1:
                            {
                                //VehicleHash vehicle = NAPI.Util.VehicleNameToModel(vehicle_name);
                                faction_data[factionid].faction_vehicle_entity[index] = NAPI.Vehicle.CreateVehicle(hash, new Vector3(436.689, -1005.882, 26.84521), new Vector3(14.40796, -0.6033466, -178.2125), -1, -1);
                                NAPI.Player.SetPlayerIntoVehicle(player, faction_data[factionid].faction_vehicle_entity[index], -1);
                                NAPI.Vehicle.SetVehicleEngineStatus(faction_data[factionid].faction_vehicle_entity[index], false);
                                Main.SetVehicleFuel(faction_data[factionid].faction_vehicle_entity[index], 100.0);
                                NAPI.Vehicle.SetVehicleNumberPlate(faction_data[factionid].faction_vehicle_entity[index], "LSPD" + SecretService.GetTimestamp(DateTime.Now));
                                NAPI.Vehicle.SetVehicleEnginePowerMultiplier(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 500);
                                NAPI.Vehicle.SetVehicleEngineTorqueMultiplier(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 500);
                                NAPI.Vehicle.SetVehicleMod(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 18, 1);
                                NAPI.Vehicle.SetVehicleMod(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 11, 3);
                                NAPI.Vehicle.SetVehicleMod(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 13, 3);
                                break;

                            }
                        case 2:
                            {
                                //VehicleHash vehicle = NAPI.Util.VehicleNameToModel(vehicle_name);
                                faction_data[factionid].faction_vehicle_entity[index] = NAPI.Vehicle.CreateVehicle(hash, new Vector3(447.4119, -997.0052, 25.35126), new Vector3(-0.9181333, 0.001428998, -179.4831), -1, 0 - 1);
                                NAPI.Player.SetPlayerIntoVehicle(player, faction_data[factionid].faction_vehicle_entity[index], -1);
                                NAPI.Vehicle.SetVehicleEngineStatus(faction_data[factionid].faction_vehicle_entity[index], false);
                                Main.SetVehicleFuel(faction_data[factionid].faction_vehicle_entity[index], 100.0);
                                NAPI.Vehicle.SetVehicleNumberPlate(faction_data[factionid].faction_vehicle_entity[index], "LSPD" + SecretService.GetTimestamp(DateTime.Now));
                                NAPI.Vehicle.SetVehicleEnginePowerMultiplier(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 500);
                                NAPI.Vehicle.SetVehicleEngineTorqueMultiplier(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 500);
                                NAPI.Vehicle.SetVehicleMod(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 18, 1);
                                NAPI.Vehicle.SetVehicleMod(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 11, 3);
                                NAPI.Vehicle.SetVehicleMod(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 13, 3);
                                break;
                            }
                        case 3:
                            {
                                //VehicleHash vehicle = NAPI.Util.VehicleNameToModel(vehicle_name);
                                faction_data[factionid].faction_vehicle_entity[index] = NAPI.Vehicle.CreateVehicle(hash, new Vector3(431.2721, -1005.77, 26.86351), new Vector3(16.75011, -0.8737264, -176.9977), -1, -1);
                                NAPI.Player.SetPlayerIntoVehicle(player, faction_data[factionid].faction_vehicle_entity[index], -1);
                                NAPI.Vehicle.SetVehicleEngineStatus(faction_data[factionid].faction_vehicle_entity[index], false);
                                Main.SetVehicleFuel(faction_data[factionid].faction_vehicle_entity[index], 100.0);
                                NAPI.Vehicle.SetVehicleNumberPlate(faction_data[factionid].faction_vehicle_entity[index], "LSPD" + SecretService.GetTimestamp(DateTime.Now));
                                NAPI.Vehicle.SetVehicleEnginePowerMultiplier(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 500);
                                NAPI.Vehicle.SetVehicleEngineTorqueMultiplier(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 500);
                                NAPI.Vehicle.SetVehicleMod(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 18, 1);
                                NAPI.Vehicle.SetVehicleMod(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 11, 3);
                                NAPI.Vehicle.SetVehicleMod(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 13, 3);
                                break;
                            }
                    }
                }
                faction_data[factionid].faction_vehicle_name[index] = vehicle_name;
                faction_data[factionid].faction_vehicle_owned[index] = AccountManage.GetCharacterName(player);
            }
            else if (factionid == 2)
            {
                if (vehicle_name == "Supervolito" && AccountManage.GetPlayerRank(player) < 2)
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "Nur Mitglieder mit rank 2 + kann dieses Fahrzeug verwenden.");
                    return;
                }
                for (int i = 0; i < MAX_FACTION_VEHICLES; i++)
                {
                    if (faction_data[factionid].faction_vehicle_owned[i] == AccountManage.GetCharacterName(player))
                    {
                        try { if (faction_data[factionid].faction_vehicle_entity[i] != null && faction_data[factionid].faction_vehicle_entity[i].Exists) faction_data[factionid].faction_vehicle_entity[i].Delete(); faction_data[factionid].faction_vehicle_entity[i] = null; } catch (Exception) { }
                        faction_data[factionid].faction_vehicle_name[i] = "Frei";
                        faction_data[factionid].faction_vehicle_owned[i] = "Niemand";
                    }
                }
                var hash = NAPI.Util.GetHashKey(vehicle_name).GetHashCode();
                if (vehicle_name == "Supervolito")
                {
                    VehicleHash vehicle = NAPI.Util.VehicleNameToModel(vehicle_name);
                    faction_data[factionid].faction_vehicle_entity[index] = NAPI.Vehicle.CreateVehicle(hash, new Vector3(337.1457, -623.214, 35.17906), new Vector3(0, 0, 354.5452), -1, -1);
                    NAPI.Vehicle.SetVehiclePrimaryColor(faction_data[factionid].faction_vehicle_entity[index], 150);
                    NAPI.Vehicle.SetVehicleSecondaryColor(faction_data[factionid].faction_vehicle_entity[index], 150);
                    NAPI.Player.SetPlayerIntoVehicle(player, faction_data[factionid].faction_vehicle_entity[index], -1);
                    NAPI.Vehicle.SetVehicleEngineStatus(faction_data[factionid].faction_vehicle_entity[index], false);
                    Main.SetVehicleFuel(faction_data[factionid].faction_vehicle_entity[index], 100.0);
                    faction_data[factionid].faction_vehicle_entity[index].PrimaryColor = 130;
                    faction_data[factionid].faction_vehicle_entity[index].SecondaryColor = 130;
                    NAPI.Vehicle.SetVehicleNumberPlate(faction_data[factionid].faction_vehicle_entity[index], "LSMC" + SecretService.GetTimestamp(DateTime.Now));
                    //NAPI.Vehicle.SetVehicleEnginePowerMultiplier(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 500);
                    //NAPI.Vehicle.SetVehicleEngineTorqueMultiplier(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 500);
                    NAPI.Vehicle.SetVehicleMod(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 18, 1);
                    NAPI.Vehicle.SetVehicleMod(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 11, 3);
                    NAPI.Vehicle.SetVehicleMod(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 13, 1);
                }
                else
                {
                    Random rnd = new Random();
                    int item = rnd.Next(0, 3);
                    switch (item)
                    {
                        case 0:
                            {
                                VehicleHash vehicle = NAPI.Util.VehicleNameToModel(vehicle_name);
                                faction_data[factionid].faction_vehicle_entity[index] = NAPI.Vehicle.CreateVehicle(hash, new Vector3(326.6893, -540.1364, 28.74344), new Vector3(0, 0, 173.8378), -1, -1);
                                NAPI.Player.SetPlayerIntoVehicle(player, faction_data[factionid].faction_vehicle_entity[index], -1);
                                NAPI.Vehicle.SetVehicleEngineStatus(faction_data[factionid].faction_vehicle_entity[index], false);
                                Main.SetVehicleFuel(faction_data[factionid].faction_vehicle_entity[index], 99.0);
                                NAPI.Vehicle.SetVehicleNumberPlate(faction_data[factionid].faction_vehicle_entity[index], "LSMC" + SecretService.GetTimestamp(DateTime.Now));
                                NAPI.Vehicle.SetVehicleEnginePowerMultiplier(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 500);
                                NAPI.Vehicle.SetVehicleEngineTorqueMultiplier(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 500);
                                NAPI.Vehicle.SetVehicleMod(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 18, 1);
                                NAPI.Vehicle.SetVehicleMod(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 11, 3);
                                NAPI.Vehicle.SetVehicleMod(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 13, 1);
                                break;
                            }
                        case 1:
                            {
                                VehicleHash vehicle = NAPI.Util.VehicleNameToModel(vehicle_name);
                                faction_data[factionid].faction_vehicle_entity[index] = NAPI.Vehicle.CreateVehicle(hash, new Vector3(321.0083, -540.6923, 28.74344), new Vector3(0, 0, 172.3402), -1, -1);
                                NAPI.Player.SetPlayerIntoVehicle(player, faction_data[factionid].faction_vehicle_entity[index], -1);
                                NAPI.Vehicle.SetVehicleEngineStatus(faction_data[factionid].faction_vehicle_entity[index], false);
                                Main.SetVehicleFuel(faction_data[factionid].faction_vehicle_entity[index], 99.0);
                                NAPI.Vehicle.SetVehicleNumberPlate(faction_data[factionid].faction_vehicle_entity[index], "LSMC" + SecretService.GetTimestamp(DateTime.Now));
                                NAPI.Vehicle.SetVehicleEnginePowerMultiplier(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 500);
                                NAPI.Vehicle.SetVehicleEngineTorqueMultiplier(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 500);
                                NAPI.Vehicle.SetVehicleMod(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 18, 1);
                                NAPI.Vehicle.SetVehicleMod(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 11, 3);
                                NAPI.Vehicle.SetVehicleMod(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 13, 1);
                                break;
                            }
                        case 2:
                            {
                                VehicleHash vehicle = NAPI.Util.VehicleNameToModel(vehicle_name);
                                faction_data[factionid].faction_vehicle_entity[index] = NAPI.Vehicle.CreateVehicle(hash, new Vector3(320.8026, -1478.074, 29.80909), new Vector3(0, 0, 182.7946), -1, -1);
                                NAPI.Player.SetPlayerIntoVehicle(player, faction_data[factionid].faction_vehicle_entity[index], -1);
                                NAPI.Vehicle.SetVehicleEngineStatus(faction_data[factionid].faction_vehicle_entity[index], false);
                                Main.SetVehicleFuel(faction_data[factionid].faction_vehicle_entity[index], 99.0);
                                NAPI.Vehicle.SetVehicleNumberPlate(faction_data[factionid].faction_vehicle_entity[index], "LSMC" + SecretService.GetTimestamp(DateTime.Now));
                                NAPI.Vehicle.SetVehicleEnginePowerMultiplier(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 500);
                                NAPI.Vehicle.SetVehicleEngineTorqueMultiplier(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 500);
                                NAPI.Vehicle.SetVehicleMod(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 18, 1);
                                NAPI.Vehicle.SetVehicleMod(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 11, 3);
                                NAPI.Vehicle.SetVehicleMod(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 13, 1);
                                break;
                            }
                        case 3:
                            {
                                VehicleHash vehicle = NAPI.Util.VehicleNameToModel(vehicle_name);
                                faction_data[factionid].faction_vehicle_entity[index] = NAPI.Vehicle.CreateVehicle(hash, new Vector3(315.8894, -550.9187, 28.74345), new Vector3(0, 0, 273.8017), -1, -1);
                                NAPI.Player.SetPlayerIntoVehicle(player, faction_data[factionid].faction_vehicle_entity[index], -1);
                                NAPI.Vehicle.SetVehicleEngineStatus(faction_data[factionid].faction_vehicle_entity[index], false);
                                Main.SetVehicleFuel(faction_data[factionid].faction_vehicle_entity[index], 99.0);
                                NAPI.Vehicle.SetVehicleNumberPlate(faction_data[factionid].faction_vehicle_entity[index], "LSMC" + SecretService.GetTimestamp(DateTime.Now));
                                NAPI.Vehicle.SetVehicleEnginePowerMultiplier(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 500);
                                NAPI.Vehicle.SetVehicleEngineTorqueMultiplier(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 500);
                                NAPI.Vehicle.SetVehicleMod(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 18, 1);
                                NAPI.Vehicle.SetVehicleMod(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 11, 3);
                                NAPI.Vehicle.SetVehicleMod(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 13, 1);
                                break;
                            }
                    }

                }

            }
            else if (AccountManage.GetPlayerGroup(player) == 15)
            {
                if (vehicle_name == "Flatbed" && AccountManage.GetPlayerRank(player) < 2)
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "Nur Mitglieder mit rank 2 + kann dieses Fahrzeug verwenden.");
                    return;
                }
                for (int i = 0; i < MAX_FACTION_VEHICLES; i++)
                {
                    if (faction_data[factionid].faction_vehicle_owned[i] == AccountManage.GetCharacterName(player))
                    {
                        try { if (faction_data[factionid].faction_vehicle_entity[i] != null && faction_data[factionid].faction_vehicle_entity[i].Exists) faction_data[factionid].faction_vehicle_entity[i].Delete(); faction_data[factionid].faction_vehicle_entity[i] = null; } catch (Exception) { }
                        faction_data[factionid].faction_vehicle_name[i] = "Frei";
                        faction_data[factionid].faction_vehicle_owned[i] = "Niemand";
                    }
                }
                var hash = NAPI.Util.GetHashKey(vehicle_name).GetHashCode();
                if (vehicle_name == "Flatbed")
                {
                    VehicleHash vehicle = NAPI.Util.VehicleNameToModel(vehicle_name);
                    faction_data[factionid].faction_vehicle_entity[index] = NAPI.Vehicle.CreateVehicle(hash, new Vector3(-1142.746, -1980.768, 13.16213), new Vector3(0, 0, 337.2804), -1, -1);
                    NAPI.Player.SetPlayerIntoVehicle(player, faction_data[factionid].faction_vehicle_entity[index], -1);
                    NAPI.Vehicle.SetVehicleEngineStatus(faction_data[factionid].faction_vehicle_entity[index], false);
                    Main.SetVehicleFuel(faction_data[factionid].faction_vehicle_entity[index], 100.0);
                    faction_data[factionid].faction_vehicle_entity[index].PrimaryColor = 12;
                    faction_data[factionid].faction_vehicle_entity[index].SecondaryColor = 12;
                    NAPI.Vehicle.SetVehicleNumberPlate(faction_data[factionid].faction_vehicle_entity[index], "LS " + GetTimestamp(DateTime.Now));
                    //NAPI.Vehicle.SetVehicleEnginePowerMultiplier(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 500);
                    //NAPI.Vehicle.SetVehicleEngineTorqueMultiplier(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 500);
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
                                faction_data[factionid].faction_vehicle_entity[index] = NAPI.Vehicle.CreateVehicle(hash, new Vector3(-1142.746, -1980.768, 13.16213), new Vector3(0, 0, 337.2804), -1, -1);
                                NAPI.Player.SetPlayerIntoVehicle(player, faction_data[factionid].faction_vehicle_entity[index], -1);
                                NAPI.Vehicle.SetVehicleEngineStatus(faction_data[factionid].faction_vehicle_entity[index], false);
                                Main.SetVehicleFuel(faction_data[factionid].faction_vehicle_entity[index], 99.0);
                                faction_data[factionid].faction_vehicle_entity[index].PrimaryColor = 12;
                                faction_data[factionid].faction_vehicle_entity[index].SecondaryColor = 12;
                                NAPI.Vehicle.SetVehicleNumberPlate(faction_data[factionid].faction_vehicle_entity[index], "LS " + GetTimestamp(DateTime.Now));
                                NAPI.Vehicle.SetVehicleEnginePowerMultiplier(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 500);
                                NAPI.Vehicle.SetVehicleEngineTorqueMultiplier(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 500);
                                NAPI.Vehicle.SetVehicleMod(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 18, 1);
                                NAPI.Vehicle.SetVehicleMod(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 11, 3);
                                NAPI.Vehicle.SetVehicleMod(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 13, 1);
                                break;
                            }
                        case 1:
                            {
                                VehicleHash vehicle = NAPI.Util.VehicleNameToModel(vehicle_name);
                                faction_data[factionid].faction_vehicle_entity[index] = NAPI.Vehicle.CreateVehicle(hash, new Vector3(-1142.746, -1980.768, 13.16213), new Vector3(0, 0, 337.2804), -1, -1);
                                NAPI.Player.SetPlayerIntoVehicle(player, faction_data[factionid].faction_vehicle_entity[index], -1);
                                NAPI.Vehicle.SetVehicleEngineStatus(faction_data[factionid].faction_vehicle_entity[index], false);
                                Main.SetVehicleFuel(faction_data[factionid].faction_vehicle_entity[index], 99.0);
                                faction_data[factionid].faction_vehicle_entity[index].PrimaryColor = 12;
                                faction_data[factionid].faction_vehicle_entity[index].SecondaryColor = 12;
                                NAPI.Vehicle.SetVehicleNumberPlate(faction_data[factionid].faction_vehicle_entity[index], "LS " + GetTimestamp(DateTime.Now));
                                //NAPI.Vehicle.SetVehicleEnginePowerMultiplier(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 500);
                                //NAPI.Vehicle.SetVehicleEngineTorqueMultiplier(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 500);
                                NAPI.Vehicle.SetVehicleMod(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 18, 1);
                                NAPI.Vehicle.SetVehicleMod(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 11, 3);
                                NAPI.Vehicle.SetVehicleMod(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 13, 1);
                                break;
                            }
                    }

                }

            }
            else if (AccountManage.GetPlayerGroup(player) == 21)
            {
                if (vehicle_name == "Flatbed" && AccountManage.GetPlayerRank(player) < 2)
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "Nur Mitglieder mit rank 2 + kann dieses Fahrzeug verwenden.");
                    return;
                }
                for (int i = 0; i < MAX_FACTION_VEHICLES; i++)
                {
                    if (faction_data[factionid].faction_vehicle_owned[i] == AccountManage.GetCharacterName(player))
                    {
                        try { if (faction_data[factionid].faction_vehicle_entity[i] != null && faction_data[factionid].faction_vehicle_entity[i].Exists) faction_data[factionid].faction_vehicle_entity[i].Delete(); faction_data[factionid].faction_vehicle_entity[i] = null; } catch (Exception) { }
                        faction_data[factionid].faction_vehicle_name[i] = "Frei";
                        faction_data[factionid].faction_vehicle_owned[i] = "Niemand";
                    }
                }
                var hash = NAPI.Util.GetHashKey(vehicle_name).GetHashCode();
                if (vehicle_name == "Flatbed")
                {
                    VehicleHash vehicle = NAPI.Util.VehicleNameToModel(vehicle_name);
                    faction_data[factionid].faction_vehicle_entity[index] = NAPI.Vehicle.CreateVehicle(hash, new Vector3(-353.73227, -116.190926, 38.697243), new Vector3(0, 0, 71.0701), -1, -1);
                    NAPI.Player.SetPlayerIntoVehicle(player, faction_data[factionid].faction_vehicle_entity[index], -1);
                    NAPI.Vehicle.SetVehicleEngineStatus(faction_data[factionid].faction_vehicle_entity[index], false);
                    Main.SetVehicleFuel(faction_data[factionid].faction_vehicle_entity[index], 100.0);
                    faction_data[factionid].faction_vehicle_entity[index].PrimaryColor = 11;
                    faction_data[factionid].faction_vehicle_entity[index].SecondaryColor = 11;
                    NAPI.Vehicle.SetVehicleNumberPlate(faction_data[factionid].faction_vehicle_entity[index], "LS " + GetTimestamp(DateTime.Now));
                    //NAPI.Vehicle.SetVehicleEnginePowerMultiplier(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 500);
                    //NAPI.Vehicle.SetVehicleEngineTorqueMultiplier(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 500);
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
                                faction_data[factionid].faction_vehicle_entity[index] = NAPI.Vehicle.CreateVehicle(hash, new Vector3(-353.73227, -116.190926, 38.697243), new Vector3(0, 0, 71.0701), -1, -1);
                                NAPI.Player.SetPlayerIntoVehicle(player, faction_data[factionid].faction_vehicle_entity[index], -1);
                                NAPI.Vehicle.SetVehicleEngineStatus(faction_data[factionid].faction_vehicle_entity[index], false);
                                Main.SetVehicleFuel(faction_data[factionid].faction_vehicle_entity[index], 99.0);
                                faction_data[factionid].faction_vehicle_entity[index].PrimaryColor = 11;
                                faction_data[factionid].faction_vehicle_entity[index].SecondaryColor = 11;
                                NAPI.Vehicle.SetVehicleNumberPlate(faction_data[factionid].faction_vehicle_entity[index], "LS " + GetTimestamp(DateTime.Now));
                                NAPI.Vehicle.SetVehicleEnginePowerMultiplier(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 500);
                                NAPI.Vehicle.SetVehicleEngineTorqueMultiplier(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 500);
                                NAPI.Vehicle.SetVehicleMod(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 18, 1);
                                NAPI.Vehicle.SetVehicleMod(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 11, 3);
                                NAPI.Vehicle.SetVehicleMod(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 13, 1);
                                break;
                            }
                        case 1:
                            {
                                VehicleHash vehicle = NAPI.Util.VehicleNameToModel(vehicle_name);
                                faction_data[factionid].faction_vehicle_entity[index] = NAPI.Vehicle.CreateVehicle(hash, new Vector3(-379.07025, -101.915504, 38.695652), new Vector3(0, 0, 151.46754), -1, -1);
                                NAPI.Player.SetPlayerIntoVehicle(player, faction_data[factionid].faction_vehicle_entity[index], -1);
                                NAPI.Vehicle.SetVehicleEngineStatus(faction_data[factionid].faction_vehicle_entity[index], false);
                                Main.SetVehicleFuel(faction_data[factionid].faction_vehicle_entity[index], 99.0);
                                faction_data[factionid].faction_vehicle_entity[index].PrimaryColor = 11;
                                faction_data[factionid].faction_vehicle_entity[index].SecondaryColor = 11;
                                NAPI.Vehicle.SetVehicleNumberPlate(faction_data[factionid].faction_vehicle_entity[index], "LS " + GetTimestamp(DateTime.Now));
                                //NAPI.Vehicle.SetVehicleEnginePowerMultiplier(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 500);
                                //NAPI.Vehicle.SetVehicleEngineTorqueMultiplier(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 500);
                                NAPI.Vehicle.SetVehicleMod(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 18, 1);
                                NAPI.Vehicle.SetVehicleMod(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 11, 3);
                                NAPI.Vehicle.SetVehicleMod(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 13, 1);
                                break;
                            }
                    }

                }

            }
            else if (AccountManage.GetPlayerGroup(player) == 25)
            {
                if (vehicle_name == "cls63" && AccountManage.GetPlayerRank(player) < 6)
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "Nur Mitglieder mit rank 6 + kann dieses Fahrzeug verwenden.");
                    return;
                }
                for (int i = 0; i < MAX_FACTION_VEHICLES; i++)
                {
                    if (faction_data[factionid].faction_vehicle_owned[i] == AccountManage.GetCharacterName(player))
                    {
                        try { if (faction_data[factionid].faction_vehicle_entity[i] != null && faction_data[factionid].faction_vehicle_entity[i].Exists) faction_data[factionid].faction_vehicle_entity[i].Delete(); faction_data[factionid].faction_vehicle_entity[i] = null; } catch (Exception) { }
                        faction_data[factionid].faction_vehicle_name[i] = "Frei";
                        faction_data[factionid].faction_vehicle_owned[i] = "Niemand";
                    }
                }
                var hash = NAPI.Util.GetHashKey(vehicle_name).GetHashCode();
                if (vehicle_name == "cls63")
                {
                    VehicleHash vehicle = NAPI.Util.VehicleNameToModel(vehicle_name);
                    faction_data[factionid].faction_vehicle_entity[index] = NAPI.Vehicle.CreateVehicle(hash, new Vector3(126.1775, -700.9872, 32.75008), new Vector3(0, 0, 337.2804), -1, -1);
                    NAPI.Player.SetPlayerIntoVehicle(player, faction_data[factionid].faction_vehicle_entity[index], -1);
                    NAPI.Vehicle.SetVehicleEngineStatus(faction_data[factionid].faction_vehicle_entity[index], false);
                    Main.SetVehicleFuel(faction_data[factionid].faction_vehicle_entity[index], 100.0);
                    faction_data[factionid].faction_vehicle_entity[index].PrimaryColor = 12;
                    faction_data[factionid].faction_vehicle_entity[index].SecondaryColor = 12;
                    NAPI.Vehicle.SetVehicleNumberPlate(faction_data[factionid].faction_vehicle_entity[index], "LS " + GetTimestamp(DateTime.Now));
                    NAPI.Vehicle.SetVehicleEnginePowerMultiplier(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 500);
                    NAPI.Vehicle.SetVehicleEngineTorqueMultiplier(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 500);
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
                                faction_data[factionid].faction_vehicle_entity[index] = NAPI.Vehicle.CreateVehicle(hash, new Vector3(134.1375, -703.6973, 32.7591), new Vector3(0, 0, 337.2804), -1, -1);
                                NAPI.Player.SetPlayerIntoVehicle(player, faction_data[factionid].faction_vehicle_entity[index], -1);
                                NAPI.Vehicle.SetVehicleEngineStatus(faction_data[factionid].faction_vehicle_entity[index], false);
                                Main.SetVehicleFuel(faction_data[factionid].faction_vehicle_entity[index], 99.0);
                                faction_data[factionid].faction_vehicle_entity[index].PrimaryColor = 12;
                                faction_data[factionid].faction_vehicle_entity[index].SecondaryColor = 12;
                                NAPI.Vehicle.SetVehicleNumberPlate(faction_data[factionid].faction_vehicle_entity[index], "LS " + GetTimestamp(DateTime.Now));
                                NAPI.Vehicle.SetVehicleEnginePowerMultiplier(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 500);
                                NAPI.Vehicle.SetVehicleEngineTorqueMultiplier(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 500);
                                NAPI.Vehicle.SetVehicleMod(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 18, 1);
                                NAPI.Vehicle.SetVehicleMod(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 11, 3);
                                NAPI.Vehicle.SetVehicleMod(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 13, 1);
                                break;
                            }
                        case 1:
                            {
                                VehicleHash vehicle = NAPI.Util.VehicleNameToModel(vehicle_name);
                                faction_data[factionid].faction_vehicle_entity[index] = NAPI.Vehicle.CreateVehicle(hash, new Vector3(134.1375, -703.6973, 32.7591), new Vector3(0, 0, 337.2804), -1, -1);
                                NAPI.Player.SetPlayerIntoVehicle(player, faction_data[factionid].faction_vehicle_entity[index], -1);
                                NAPI.Vehicle.SetVehicleEngineStatus(faction_data[factionid].faction_vehicle_entity[index], false);
                                Main.SetVehicleFuel(faction_data[factionid].faction_vehicle_entity[index], 99.0);
                                faction_data[factionid].faction_vehicle_entity[index].PrimaryColor = 12;
                                faction_data[factionid].faction_vehicle_entity[index].SecondaryColor = 12;
                                NAPI.Vehicle.SetVehicleNumberPlate(faction_data[factionid].faction_vehicle_entity[index], "LS " + GetTimestamp(DateTime.Now));
                                NAPI.Vehicle.SetVehicleEnginePowerMultiplier(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 500);
                                NAPI.Vehicle.SetVehicleEngineTorqueMultiplier(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 500);
                                NAPI.Vehicle.SetVehicleMod(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 18, 1);
                                NAPI.Vehicle.SetVehicleMod(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 11, 3);
                                NAPI.Vehicle.SetVehicleMod(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 13, 1);
                                break;
                            }
                    }

                }

            }
            else if (AccountManage.GetPlayerGroup(player) == 26)
            {
                if (vehicle_name == "Valkyrie2" && AccountManage.GetPlayerRank(player) < 1)
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "Nur Mitglieder mit rank 6 + kann dieses Fahrzeug verwenden.");
                    return;
                }
                for (int i = 0; i < MAX_FACTION_VEHICLES; i++)
                {
                    if (faction_data[factionid].faction_vehicle_owned[i] == AccountManage.GetCharacterName(player))
                    {
                        try { if (faction_data[factionid].faction_vehicle_entity[i] != null && faction_data[factionid].faction_vehicle_entity[i].Exists) faction_data[factionid].faction_vehicle_entity[i].Delete(); faction_data[factionid].faction_vehicle_entity[i] = null; } catch (Exception) { }
                        faction_data[factionid].faction_vehicle_name[i] = "Frei";
                        faction_data[factionid].faction_vehicle_owned[i] = "Niemand";
                    }
                }
                var hash = NAPI.Util.GetHashKey(vehicle_name).GetHashCode();
                if (vehicle_name == "Valkyrie2")
                {
                    VehicleHash vehicle = NAPI.Util.VehicleNameToModel(vehicle_name);
                    faction_data[factionid].faction_vehicle_entity[index] = NAPI.Vehicle.CreateVehicle(hash, new Vector3(-1868.719, 3006.974, 32.81048), new Vector3(0, 0, 355.0793), -1, -1);
                    NAPI.Player.SetPlayerIntoVehicle(player, faction_data[factionid].faction_vehicle_entity[index], -1);
                    NAPI.Vehicle.SetVehicleEngineStatus(faction_data[factionid].faction_vehicle_entity[index], false);
                    Main.SetVehicleFuel(faction_data[factionid].faction_vehicle_entity[index], 100.0);
                    faction_data[factionid].faction_vehicle_entity[index].PrimaryColor = 0;
                    faction_data[factionid].faction_vehicle_entity[index].SecondaryColor = 0;
                    NAPI.Vehicle.SetVehicleNumberPlate(faction_data[factionid].faction_vehicle_entity[index], "LS " + GetTimestamp(DateTime.Now));
                    NAPI.Vehicle.SetVehicleEnginePowerMultiplier(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 500);
                    NAPI.Vehicle.SetVehicleEngineTorqueMultiplier(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 500);
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
                                faction_data[factionid].faction_vehicle_entity[index] = NAPI.Vehicle.CreateVehicle(hash, new Vector3(-1819.2789, 2976.9167, 32.809883), new Vector3(0, 0, 307.0581), -1, -1);
                                NAPI.Player.SetPlayerIntoVehicle(player, faction_data[factionid].faction_vehicle_entity[index], -1);
                                NAPI.Vehicle.SetVehicleEngineStatus(faction_data[factionid].faction_vehicle_entity[index], false);
                                Main.SetVehicleFuel(faction_data[factionid].faction_vehicle_entity[index], 99.0);
                                faction_data[factionid].faction_vehicle_entity[index].PrimaryColor = 0;
                                faction_data[factionid].faction_vehicle_entity[index].SecondaryColor = 0;
                                NAPI.Vehicle.SetVehicleNumberPlate(faction_data[factionid].faction_vehicle_entity[index], "LS " + GetTimestamp(DateTime.Now));
                                NAPI.Vehicle.SetVehicleEnginePowerMultiplier(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 500);
                                NAPI.Vehicle.SetVehicleEngineTorqueMultiplier(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 500);
                                NAPI.Vehicle.SetVehicleMod(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 18, 1);
                                NAPI.Vehicle.SetVehicleMod(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 11, 3);
                                NAPI.Vehicle.SetVehicleMod(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 13, 1);
                                break;
                            }
                        case 1:
                            {
                                VehicleHash vehicle = NAPI.Util.VehicleNameToModel(vehicle_name);
                                faction_data[factionid].faction_vehicle_entity[index] = NAPI.Vehicle.CreateVehicle(hash, new Vector3(-1819.2789, 2976.9167, 32.809883), new Vector3(0, 0, 307.0581), -1, -1);
                                NAPI.Player.SetPlayerIntoVehicle(player, faction_data[factionid].faction_vehicle_entity[index], -1);
                                NAPI.Vehicle.SetVehicleEngineStatus(faction_data[factionid].faction_vehicle_entity[index], false);
                                Main.SetVehicleFuel(faction_data[factionid].faction_vehicle_entity[index], 99.0);
                                faction_data[factionid].faction_vehicle_entity[index].PrimaryColor = 0;
                                faction_data[factionid].faction_vehicle_entity[index].SecondaryColor = 0;
                                NAPI.Vehicle.SetVehicleNumberPlate(faction_data[factionid].faction_vehicle_entity[index], "LS " + GetTimestamp(DateTime.Now));
                                NAPI.Vehicle.SetVehicleEnginePowerMultiplier(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 500);
                                NAPI.Vehicle.SetVehicleEngineTorqueMultiplier(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 500);
                                NAPI.Vehicle.SetVehicleMod(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 18, 1);
                                NAPI.Vehicle.SetVehicleMod(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 11, 3);
                                NAPI.Vehicle.SetVehicleMod(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 13, 1);
                                break;
                            }
                    }

                }

            }
            else if (factionid == 3)
            {
                if (vehicle_name == "Polmav" && AccountManage.GetPlayerRank(player) < 2)
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "Nur Mitglieder mit Rang 8 + kann dieses Fahrzeug verwenden.");
                    return;
                }

                for (int i = 0; i < MAX_FACTION_VEHICLES; i++)
                {
                    if (faction_data[factionid].faction_vehicle_owned[i] == AccountManage.GetCharacterName(player))
                    {
                        try { if (faction_data[factionid].faction_vehicle_entity[i] != null && faction_data[factionid].faction_vehicle_entity[i].Exists) faction_data[factionid].faction_vehicle_entity[i].Delete(); faction_data[factionid].faction_vehicle_entity[i] = null; } catch (Exception) { }
                        faction_data[factionid].faction_vehicle_name[i] = "Frei";
                        faction_data[factionid].faction_vehicle_owned[i] = "Niemand";
                    }
                }
                if (vehicle_name == "Polmav")
                {
                    VehicleHash vehicle = NAPI.Util.VehicleNameToModel(vehicle_name);
                    faction_data[factionid].faction_vehicle_entity[index] = NAPI.Vehicle.CreateVehicle(vehicle, new Vector3(-475.2526, 5988.587, 31.33668), new Vector3(0, 0, 314.8221), -1, -1);
                    NAPI.Player.SetPlayerIntoVehicle(player, faction_data[factionid].faction_vehicle_entity[index], -1);
                    NAPI.Vehicle.SetVehicleEngineStatus(faction_data[factionid].faction_vehicle_entity[index], false);
                    Main.SetVehicleFuel(faction_data[factionid].faction_vehicle_entity[index], 100.0);
                    NAPI.Vehicle.SetVehicleMod(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 18, 1);
                    NAPI.Vehicle.SetVehicleMod(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 11, 3);
                    NAPI.Vehicle.SetVehicleMod(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 13, 3);
                }
                else
                {
                    VehicleHash vehicle = NAPI.Util.VehicleNameToModel(vehicle_name);
                    faction_data[factionid].faction_vehicle_entity[index] = NAPI.Vehicle.CreateVehicle(vehicle, new Vector3(-361.8666, 6075.878, 31.49743), new Vector3(0, 0, 135.0627), -1, -1);
                    NAPI.Player.SetPlayerIntoVehicle(player, faction_data[factionid].faction_vehicle_entity[index], -1);
                    NAPI.Vehicle.SetVehicleEngineStatus(faction_data[factionid].faction_vehicle_entity[index], false);
                    Main.SetVehicleFuel(faction_data[factionid].faction_vehicle_entity[index], 100.0);
                    NAPI.Vehicle.SetVehicleMod(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 18, 1);
                    NAPI.Vehicle.SetVehicleMod(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 11, 3);
                    NAPI.Vehicle.SetVehicleMod(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 13, 3);

                }
                faction_data[factionid].faction_vehicle_name[index] = vehicle_name;
                faction_data[factionid].faction_vehicle_owned[index] = AccountManage.GetCharacterName(player);
            }

            else if (factionid == 1)
            {
                if (vehicle_name == "Sheriff" && AccountManage.GetPlayerRank(player) < 2)
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "Nur Mitglieder des SD kann dieses Fahrzeug verwenden.");
                    return;
                }
                for (int i = 0; i < MAX_FACTION_VEHICLES; i++)
                {
                    if (faction_data[factionid].faction_vehicle_owned[i] == AccountManage.GetCharacterName(player))
                    {
                        try { if (faction_data[factionid].faction_vehicle_entity[i] != null && faction_data[factionid].faction_vehicle_entity[i].Exists) faction_data[factionid].faction_vehicle_entity[i].Delete(); faction_data[factionid].faction_vehicle_entity[i] = null; } catch (Exception) { }
                        faction_data[factionid].faction_vehicle_name[i] = "Frei";
                        faction_data[factionid].faction_vehicle_owned[i] = "Niemand";
                    }
                }

                if (vehicle_name == "Sheriff")
                {
                    VehicleHash vehicle = NAPI.Util.VehicleNameToModel(vehicle_name);
                    faction_data[factionid].faction_vehicle_entity[index] = NAPI.Vehicle.CreateVehicle(vehicle, new Vector3(1868.748, 3695.093, 33.59127), new Vector3(0, 0, 24.32342), -1, -1);
                    NAPI.Player.SetPlayerIntoVehicle(player, faction_data[factionid].faction_vehicle_entity[index], -1);
                    NAPI.Vehicle.SetVehicleEngineStatus(faction_data[factionid].faction_vehicle_entity[index], false);
                    Main.SetVehicleFuel(faction_data[factionid].faction_vehicle_entity[index], 100.0);
                    faction_data[factionid].faction_vehicle_entity[index].PrimaryColor = 130;
                    faction_data[factionid].faction_vehicle_entity[index].SecondaryColor = 130;
                    NAPI.Vehicle.SetVehicleNumberPlate(faction_data[factionid].faction_vehicle_entity[index], "SD");
                    NAPI.Vehicle.SetVehicleMod(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 18, 1);
                }
            }

            faction_data[factionid].faction_vehicle_name[index] = vehicle_name;
            faction_data[factionid].faction_vehicle_owned[index] = AccountManage.GetCharacterName(player);
        }


        //-359.3449, 6062.392, 31.50013
        else if (callbackId == "FACTION_LIST_MENU")
        {
            NAPI.Data.SetEntityData(player, "EditingFactionID", selectedIndex);
            DisplayEditFaction(player);
        }
        else if (callbackId == "FACTION_EDITING_MENU")
        {
            int index = NAPI.Data.GetEntityData(player, "EditingFactionID");
            switch (selectedIndex)
            {
                case 0:
                    {
                        InteractMenu.User_Input(player, "input_faction_name", "Name der Fraktion", faction_data[index].faction_name);
                        InteractMenu.CloseDynamicMenu(player);
                        break;
                    }
                case 2:
                    {
                        InteractMenu.User_Input(player, "input_faction_abbrev", "Abkürzung der Fraktion", faction_data[index].faction_abbrev);
                        InteractMenu.CloseDynamicMenu(player);
                        break;
                    }
                case 3:
                    {
                        InteractMenu.User_Input(player, "input_faction_color", "Fraktionsfarbe", faction_data[index].faction_color);
                        InteractMenu.CloseDynamicMenu(player);
                        break;
                    }
                case 4:
                    {
                        InteractMenu.User_Input(player, "input_faction_turf_color", "Gebiets - Farb - ID", faction_data[index].faction_turf_color.ToString(), "", "number");
                        InteractMenu.CloseDynamicMenu(player);
                        break;
                    }
                case 5:
                    {
                        List<dynamic> menu_item_list = new List<dynamic>();
                        for (int i = 0; i < MAX_FACTION_RANK; i++)
                        {
                            if (faction_data[index].faction_rank[i] == "Zivilist")
                            {
                                menu_item_list.Add(new { Type = 4, Name = "Rank " + i + ".", Description = "", RightLabel = "~c~Zivilist" });
                            }
                            else
                            {
                                menu_item_list.Add(new { Type = 4, Name = "Rank " + i + ".", Description = "", RightLabel = "~s~" + faction_data[index].faction_rank[i] + "" });
                            }

                        }
                        InteractMenu.CreateMenu(player, "FACTION_EDITING_RANK", "Fraktion", "~b~Rang-ID bearbeiten " + index + ":", true, JsonConvert.SerializeObject(menu_item_list), false);
                        break;
                    }
                case 6:
                    {
                        List<dynamic> menu_item_list = new List<dynamic>();
                        for (int i = 0; i < MAX_FACTION_RANK; i++)
                        {
                            menu_item_list.Add(new { Type = 4, Name = "~c~Rank " + i + ".~s~ " + faction_data[index].faction_rank[i], Description = "", RightLabel = "~g~$" + faction_data[index].faction_salary[i] + "" });
                        }
                        InteractMenu.CreateMenu(player, "FACTION_EDITING_SALARY", "Fraktion", "~b~GEBÜHR DURCH GEBÜHREN: ", true, JsonConvert.SerializeObject(menu_item_list), false);
                        break;
                    }
                case 7:
                    {
                        faction_data[index].faction_armory_x = player.Position.X;
                        faction_data[index].faction_armory_y = player.Position.Y;
                        faction_data[index].faction_armory_z = player.Position.Z;

                        NAPI.Entity.DeleteEntity(faction_data[index].faction_armory_label);
                        NAPI.Entity.DeleteEntity(faction_data[index].faction_armory_marker);
                        faction_data[index].faction_armory_label = NAPI.TextLabel.CreateTextLabel("~y~~h~- Arsenal von ~b~" + faction_data[index].faction_name + "~y~ -~w~~h~~n~~n~~w~Benutze ~y~~h~E~h~~w~ ", new Vector3(faction_data[index].faction_armory_x, faction_data[index].faction_armory_y, faction_data[index].faction_armory_z + 0.3), 12, 0.3500f, 4, new Color(255, 255, 255, 255));
                        faction_data[index].faction_armory_marker = NAPI.Marker.CreateMarker(27, new Vector3(faction_data[index].faction_armory_x, faction_data[index].faction_armory_y, faction_data[index].faction_armory_z - 1.0), new Vector3(), new Vector3(), 0.8f, new Color(255, 208, 0, 200));

                        SaveFaction(index);
                        DisplayEditFaction(player);
                        break;
                    }
                case 8:
                    {
                        InteractMenu.User_Input(player, "input_faction_recurso", "Arsenal Berufung", faction_data[index].faction_armory_recurso.ToString(), "", "number");
                        InteractMenu.CloseDynamicMenu(player);
                        break;
                    }
                case 9:
                    {
                        List<dynamic> menu_item_list = new List<dynamic>();
                        for (int i = 0; i < 20; i++)
                        {
                            if (faction_data[index].faction_armory_gun[i] == "0")
                            {
                                menu_item_list.Add(new { Type = 4, Name = "~w~" + i + ". ~c~Leer", Description = "", RightLabel = "" });
                            }
                            else
                            {
                                menu_item_list.Add(new { Type = 4, Name = "~w~" + i + ". ~y~" + faction_data[index].faction_armory_gun[i] + "", Description = "", RightLabel = "~c~600x Munition" });
                            }
                        }
                        InteractMenu.CreateMenu(player, "FACTION_EDITING_GUN", "Faction", "~b~Waffen: ", true, JsonConvert.SerializeObject(menu_item_list), false);
                        break;
                    }
                case 10:
                    {
                        List<dynamic> menu_item_list = new List<dynamic>();
                        for (int i = 0; i < 20; i++)
                        {
                            menu_item_list.Add(new { Type = 4, Name = "~w~" + i + ". ~y~" + faction_data[index].faction_armory_gun[i] + "", Description = "", RightLabel = "~c~Kosten: " + faction_data[index].faction_armory_price[i] + " de recurso" });
                        }
                        InteractMenu.CreateMenu(player, "FACTION_EDITING_GUN_STOCK", "Fraktion", "~b~Waffen:", true, JsonConvert.SerializeObject(menu_item_list), false);
                        break;
                    }
            }
        }
        else if (callbackId == "FACTION_EDITING_RANK")
        {
            int index = NAPI.Data.GetEntityData(player, "EditingFactionID");
            player.SetData("faction_editing_rank", selectedIndex);
            InteractMenu.User_Input(player, "input_faction_rank", "Rangname", faction_data[index].faction_rank[selectedIndex]);
            InteractMenu.CloseDynamicMenu(player);
            SaveFactionRanks(index);
        }
        else if (callbackId == "FACTION_EDITING_SALARY")
        {
            int index = NAPI.Data.GetEntityData(player, "EditingFactionID");
            player.SetData("faction_editing_rank", selectedIndex);
            InteractMenu.User_Input(player, "input_faction_salary", "Gehalt pro Position", faction_data[index].faction_salary[selectedIndex].ToString(), "", "number");
            InteractMenu.CloseDynamicMenu(player);
            SaveFactionRanks(index);
        }
        else if (callbackId == "FACTION_EDITING_GUN")
        {
            int index = NAPI.Data.GetEntityData(player, "EditingFactionID");
            player.SetData("faction_editing_rank", selectedIndex);
            InteractMenu.User_Input(player, "input_faction_gun", "Waffen", faction_data[index].faction_armory_gun[selectedIndex].ToString(), "", "number");
            InteractMenu.CloseDynamicMenu(player);
        }
        else if (callbackId == "FACTION_EDITING_GUN_STOCK")
        {
            int index = NAPI.Data.GetEntityData(player, "EditingFactionID");
            player.SetData("faction_editing_rank", selectedIndex);
            InteractMenu.User_Input(player, "input_faction_gun_stock", "Vorrat an Waffen", faction_data[index].faction_armory_price[selectedIndex].ToString(), "", "number");
            InteractMenu.CloseDynamicMenu(player);
        }
        else if (callbackId == "FACTION_EDITING_RESOURCE")
        {
            int index = NAPI.Data.GetEntityData(player, "EditingFactionID");
            player.SetData("faction_editing_rank", selectedIndex);
            InteractMenu.User_Input(player, "input_faction_resource", "Lager", faction_data[index].faction_armory_recurso.ToString(), "", "number");
            InteractMenu.CloseDynamicMenu(player);
        }
        else if (callbackId == "ARMORY_BUY_RESPONSE")
        {
            int faction_id = AccountManage.GetPlayerGroup(player);
            int item = selectedIndex;
            if (faction_id == -1)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Du bist nicht mehr in einer Fraktion..");
                return;
            }

            if (faction_data[faction_id].faction_armory_gun[item] == "0")
            {
                NAPI.Notification.SendNotificationToPlayer(player, "ERROR: Nichts in diesem Slot!", true);
            }
            else if (faction_data[faction_id].faction_armory_recurso < faction_data[faction_id].faction_armory_price[item])
            {
                NAPI.Notification.SendNotificationToPlayer(player, "ERROR: Das Arsenal hat momentan keinen Vorrat für diese Waffe.", true);
            }
            else
            {
                //player.TriggerEvent("removeAllWeapons");
                NAPI.Task.Run(() =>
                {
                    //NAPI.Player.RemoveAllPlayerWeapons(player);
                }, delayTime: 250);

                NAPI.Task.Run(() =>
                {
                    WeaponHash hashcode = NAPI.Util.WeaponNameToModel(faction_data[faction_id].faction_armory_gun[item]);
                    faction_data[faction_id].faction_armory_recurso -= faction_data[faction_id].faction_armory_price[item];

                    if (faction_data[faction_id].faction_armory_price[item] == 0) NAPI.Notification.SendNotificationToPlayer(player, "~y~[ARSENAL]:~w~ " + hashcode + "~w~ im Arsenal.");
                    else NAPI.Notification.SendNotificationToPlayer(player, "Du hast: ~y~" + hashcode + "~w~ im Arsenal. (Kosten des Arsenals: " + faction_data[faction_id].faction_armory_price[item] + "");

                    WeaponManage.GivePlayerWeaponEx(player, faction_data[faction_id].faction_armory_gun[item], 500);
                    NAPI.Player.SetPlayerCurrentWeaponAmmo(player, 500);
                    WeaponManage.SaveWeapons(player);
                    //NAPI.Player.SetPlayerWeaponAmmo(player, faction_data[faction_id].faction_armory_gun[item], 500);
                    //if (player.Armor <= 100)
                    //{
                    //    player.Armor = player.Armor + 100;
                    //}

                    //var armor = new Dictionary<int, ComponentVariation>();
                    //armor.Add(9, new ComponentVariation { Drawable = 2, Texture = 0 });

                    //NAPI.Notification.SendNotificationToPlayer(player, "Du hast deine Schutzweste bekommen!");
                    //player.SetClothes(armor);
                }, delayTime: 500);
            }
        }
    }

    public static void ListItemMenuResponse(Client player, String callbackId, int selectedIndex, String objectName, String valueList, int valueIndex)
    {
        if(callbackId == "FACTION_EDITING_MENU")
        {
            int index = NAPI.Data.GetEntityData(player, "EditingFactionID");
            int type_id = valueIndex;

            faction_data[index].faction_type = type_id;
            SaveFaction(index);
           // DisplayEditFaction(player);
        }
    }

    public static void OnMenuReturnClose(Client player, String callbackId)
    {
    }

    public static void OnInputResponse(Client player, string response, string inputtext)
    {
        if(response == "input_faction_name")
        {

            int faction_id = NAPI.Data.GetEntityData(player, "EditingFactionID");
            string name = inputtext;
            if (String.IsNullOrEmpty(name))
            {
                NAPI.Notification.SendNotificationToPlayer(player, "[ERROR]:~w~ Sie können keinen Nullwert verwenden.");
                DisplayEditFaction(player);
                return;
            }
            faction_data[faction_id].faction_name = name.ToString();
            SaveFaction(faction_id);
            DisplayEditFaction(player);
        }
        else if (response == "input_faction_abbrev")
        {

            int faction_id = NAPI.Data.GetEntityData(player, "EditingFactionID");
            string name = inputtext;
            if (String.IsNullOrEmpty(name))
            {
                NAPI.Notification.SendNotificationToPlayer(player, "[ERROR]:~w~ Sie können keinen Nullwert verwenden.");
                DisplayEditFaction(player);
                return;
            }
            faction_data[faction_id].faction_abbrev = name.ToString();
            SaveFaction(faction_id);
            DisplayEditFaction(player);
        }
        else if (response == "input_faction_color")
        {

            int faction_id = NAPI.Data.GetEntityData(player, "EditingFactionID");
            string name = inputtext;
            if (String.IsNullOrEmpty(name))
            {
                NAPI.Notification.SendNotificationToPlayer(player, "[ERROR]:~w~ Sie können keinen Nullwert verwenden.");
                DisplayEditFaction(player);
                return;
            }
            faction_data[faction_id].faction_color = name.ToString();
            SaveFaction(faction_id);
            DisplayEditFaction(player);
        }
        else if (response == "input_faction_turf_color")
        {

            int faction_id = NAPI.Data.GetEntityData(player, "EditingFactionID");
            int value = Convert.ToInt32(inputtext);
            if (!Main.IsNumeric(inputtext))
            {
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Ungültiger Wert eingegeben", 5000);
                return;
            }
            if (value < 1)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "[ERROR]:~w~ Sie können keinen Wert unter 1 und über 85 verwenden.");
                DisplayEditFaction(player);
                return;
            }
            if (value > 85)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "[ERROR]:~w~ Sie können keinen Wert unter 1 und über 85 verwenden.");
                DisplayEditFaction(player);
                return;
            }
            faction_data[faction_id].faction_turf_color = value;
            SaveFaction(faction_id);
            DisplayEditFaction(player);
            TurfWar.UpdateZoneBlipForAll();
        }
        else if (response == "input_faction_rank")
        {

            int faction_id = NAPI.Data.GetEntityData(player, "EditingFactionID");
            int rank_id = NAPI.Data.GetEntityData(player, "faction_editing_rank");
            string name = inputtext;
            if (String.IsNullOrEmpty(name))
            {
                NAPI.Notification.SendNotificationToPlayer(player, "[ERROR]:~w~ Sie können keinen Nullwert verwenden.");
                DisplayEditFaction(player);
                return;
            }
            faction_data[faction_id].faction_rank[rank_id] = name.ToString();
            SaveFaction(faction_id);
            DisplayEditFaction(player);
        }
        else if (response == "input_player_faction_rank")
        {

            int faction_id = AccountManage.GetPlayerGroup(player);
            int rank_id = NAPI.Data.GetEntityData(player, "faction_editing_rank");
            string name = inputtext;
            if (String.IsNullOrEmpty(name))
            {
                NAPI.Notification.SendNotificationToPlayer(player, "[ERROR]:~w~ Sie können keinen Nullwert verwenden.");
                DisplayEditFaction(player);
                return;
            }
            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben den Rangnamen geändert ~c~" + rank_id+ "~w~ von ~c~" + faction_data[faction_id].faction_rank[rank_id] + "~w~ zu ~y~"+ name.ToString() + "~w~.");
            faction_data[faction_id].faction_rank[rank_id] = name.ToString();
            SaveFaction(faction_id);
            InteractMenu.ShowPlayerFactionMenu(player);
        }
        else if (response == "input_faction_salary")
        {

            int faction_id = NAPI.Data.GetEntityData(player, "EditingFactionID");
            int rank_id = NAPI.Data.GetEntityData(player, "faction_editing_rank");
            string value = inputtext;
            if (!Main.IsNumeric(inputtext))
            {
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Ungültiger eingegebener Wert.", 5000);
                return;
            }

            if (Convert.ToInt32(value) < 1)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "[ERROR]:~w~ Der Betrag sollte zwischen 1 und 50.000 USD liegen.");
                DisplayEditFaction(player);
                return;
            }
            else if (Convert.ToInt32(value) > 50000)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "[ERROR]:~w~ Der Betrag sollte zwischen 1 und 50.000 USD liegen.");
                DisplayEditFaction(player);
                return;
            }
            faction_data[faction_id].faction_salary[rank_id] = Convert.ToInt32(value);
            SaveFaction(faction_id);
            DisplayEditFaction(player);
        }
        else if (response == "input_faction_gun")
        {

            int index = NAPI.Data.GetEntityData(player, "EditingFactionID");
            int slot = NAPI.Data.GetEntityData(player, "faction_editing_rank");
            string value = inputtext;

            if (value == "0")
            {
                faction_data[index].faction_armory_gun[slot] = "0";
                DisplayEditFaction(player);
                return;
            }
            faction_data[index].faction_armory_gun[slot] = value;
            SaveFaction(index);
            DisplayEditFaction(player);
        }
        else if (response == "input_faction_gun_stock")
        {

            int index = NAPI.Data.GetEntityData(player, "EditingFactionID");
            int slot = NAPI.Data.GetEntityData(player, "faction_editing_rank");
            string value = inputtext;

            if (!Main.IsNumeric(inputtext))
            {
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Ungültiger eingegebener Wert.", 5000);
                return;
            }

            if (Convert.ToInt32(value) < 0)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "[ERROR]:~w~ Der Wert muss zwischen 0 und 1000 liegen.");
                DisplayEditFaction(player);
                return;
            }
            else if (Convert.ToInt32(value) > 50000)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "[ERROR]:~w~ Der Wert muss zwischen 0 und 1000 liegen.");
                DisplayEditFaction(player);
                return;
            }

            faction_data[index].faction_armory_price[slot] = Convert.ToInt32(value);
            SaveFaction(index);
            DisplayEditFaction(player);
        }
        else if (response == "input_faction_recurso")
        {

            int index = NAPI.Data.GetEntityData(player, "EditingFactionID");
            
            if (!Main.IsNumeric(inputtext))
            {
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Ungültiger eingegebener Wert.", 5000);
                return;
            }

            int value = Convert.ToInt32(inputtext);

            if (Convert.ToInt32(value) < 0)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "[ERROR]:~w~ Der Wert muss zwischen 0 und 1000 liegen.");
                DisplayEditFaction(player);
                return;
            }
            else if (Convert.ToInt32(value) > 10000)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "[ERROR]:~w~ Der Wert muss zwischen 0 und 1000 liegen.");
                DisplayEditFaction(player);
                return;
            }

            faction_data[index].faction_armory_recurso = Convert.ToInt32(value);
            SaveFaction(index);
            DisplayEditFaction(player);
        } 
    }


    public static void SendFactionMessage(int faction, string mensagem)
    {
        var players = NAPI.Pools.GetAllPlayers();
        foreach (Client c in players)
        {
            if (c.GetData("status") == true)
            {
                if (AccountManage.GetPlayerGroup(c) == faction)
                {
                    if (faction_data[faction].faction_color == "Zivilist")
                    {
                        NAPI.Notification.SendNotificationToPlayer(c, "<font color='#009E12'>" + mensagem);
                    }
                    else NAPI.Notification.SendNotificationToPlayer(c, "<font color='#" + faction_data[faction].faction_color + "'>" + mensagem);
                }
            }
        }
    }

    public static void SendGroupMessage(int group_type, string mensagem)
    {
        var players = NAPI.Pools.GetAllPlayers();
        foreach (Client c in players)
        {
            if (c.GetData("status") == true)
            {
                if (AccountManage.GetPlayerGroup(c) != 0 && faction_data[AccountManage.GetPlayerGroup(c)].faction_type == group_type)
                {
                    if (faction_data[AccountManage.GetPlayerGroup(c)].faction_color == "Zivilist")
                    {
                        NAPI.Notification.SendNotificationToPlayer(c, "<font color='#009E12'>" + mensagem);
                    }
                    else NAPI.Notification.SendNotificationToPlayer(c, "<font color='#" + faction_data[AccountManage.GetPlayerGroup(c)].faction_color + "'>" + mensagem);
                }
            }
        }
    }

    [RemoteEvent("OnFaction_ClickButton")]
    public void MyFaction(Client player, int buttonid, int faction_id)
    {
        if(buttonid == 1)
        {
            List<dynamic> member_list = new List<dynamic>();
            List<dynamic> faction_temp_data = new List<dynamic>();

            int count = 0;
            using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
            {
                
                Mainpipeline.Open();
                MySqlCommand query = new MySqlCommand("SELECT * FROM `characters` WHERE  `group` = " + faction_id + ";", Mainpipeline);
                using (MySqlDataReader reader = query.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        member_list.Add(new { name = reader.GetString("name"), rank = reader.GetInt32("group_rank"), leader = reader.GetInt32("leader"), level = reader.GetInt32("level"), online = reader.GetInt32("status") });
                        count++;
                    }

                    faction_temp_data.Add(new
                    {
                        f_name = faction_data[faction_id].faction_name,
                        f_type_name = Faction_Type(faction_data[faction_id].faction_type),
                        f_members = count,
                        f_logo = faction_data[faction_id].faction_logo,
                        f_description = faction_data[faction_id].faction_description,

                        f_rank = faction_data[faction_id].faction_rank,
                        f_salary = faction_data[faction_id].faction_salary,
                        f_abbrev = faction_data[faction_id].faction_abbrev,
                        f_color = faction_data[faction_id].faction_color,
                        f_type = faction_data[faction_id].faction_type,
                        f_stock = faction_data[faction_id].faction_armory_recurso
                    });

                    player.TriggerEvent("ViewFaction_Display", NAPI.Util.ToJson(member_list), NAPI.Util.ToJson(faction_temp_data));
                }
            }
        }
    }

    [RemoteEvent("OnFaction_SaveEditing")]
    public void MyFaction(Client player, int faction_id, string name, int type, string color, string abbrev, int recurso, string logo, string des, string rank_0, string rank_1, string rank_2, string rank_3, string rank_4, string rank_5, string rank_6, string rank_7, string rank_8, string rank_9, int salary_0, int salary_1, int salary_2, int salary_3, int salary_4, int salary_5, int salary_6, int salary_7, int salary_8, int salary_9)
    {
        faction_data[faction_id].faction_name = name;
        faction_data[faction_id].faction_color = color;
        faction_data[faction_id].faction_abbrev = abbrev;
        faction_data[faction_id].faction_armory_recurso = recurso;
        faction_data[faction_id].faction_type = type;
        faction_data[faction_id].faction_name = name;

        faction_data[faction_id].faction_logo = logo;
        faction_data[faction_id].faction_description = des;

        faction_data[faction_id].faction_rank[0] = rank_0; 
        faction_data[faction_id].faction_rank[1] = rank_1;
        faction_data[faction_id].faction_rank[2] = rank_2;
        faction_data[faction_id].faction_rank[3] = rank_3;
        faction_data[faction_id].faction_rank[4] = rank_4;
        faction_data[faction_id].faction_rank[5] = rank_5;
        faction_data[faction_id].faction_rank[6] = rank_6;
        faction_data[faction_id].faction_rank[7] = rank_7;
        faction_data[faction_id].faction_rank[8] = rank_8;
        faction_data[faction_id].faction_rank[9] = rank_9;

        faction_data[faction_id].faction_salary[0] = salary_0;
        faction_data[faction_id].faction_salary[1] = salary_1;
        faction_data[faction_id].faction_salary[2] = salary_2;
        faction_data[faction_id].faction_salary[3] = salary_3;
        faction_data[faction_id].faction_salary[4] = salary_4;
        faction_data[faction_id].faction_salary[5] = salary_5;
        faction_data[faction_id].faction_salary[6] = salary_7;
        faction_data[faction_id].faction_salary[7] = salary_8;
        faction_data[faction_id].faction_salary[8] = salary_9;
        faction_data[faction_id].faction_salary[9] = salary_9;

        SaveFaction(faction_id);
        SaveFactionRanks(faction_id);

        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Fraktion erfolgreich bearbeitet.", 5000);

    }

    [Command("editfaction", Alias = "editfac,editfact", GreedyArg = true)]
    public void CMD_editarfaction(Client player)
    {
        if (AccountManage.GetPlayerAdmin(player) < adminCommands.COORDENADOR)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "[ERROR]:~w~ Sie haben keine Berechtigung, diesen Befehl zu verwenden.");
            return;
        }
        int index = 0;

        List<dynamic> menu_item_list = new List<dynamic>();
        foreach (var faction in faction_data)
        {
            if(faction.faction_color == "Zivilist") menu_item_list.Add(new { Type = 4, Name = "~c~" + index + ".~s~ " + faction.faction_name + "", Description = "", RightLabel = "~c~>>" });
            else menu_item_list.Add(new { Type = 4, Name = "~c~" + index + ".~s~ " + faction.faction_name + "", Description = "", RightLabel = "~c~>>", BackgroundColor = new Color(255, 0, 0, 255), FrontColor = new Color(255, 255, 255, 255) });
            index++;
        }
        InteractMenu.CreateMenu(player, "FACTION_LIST_MENU", "Factions", "~b~Liste aller Fraktionen:", true, JsonConvert.SerializeObject(menu_item_list), false);
    }

}

