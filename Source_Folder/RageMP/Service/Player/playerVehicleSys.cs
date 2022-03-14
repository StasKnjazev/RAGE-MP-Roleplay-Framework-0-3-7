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
using DerStr1k3r.Core;

public class PlayerVehicle : Script
{
    public static int MAX_PLAYER_VEHICLES = 3000; // Maximo de Veiculos do Jogador

    public class VehicleEnum : IEquatable<VehicleEnum>
    {
        public int id { get; set; }

        public Vehicle[] handle { get; set; } = new Vehicle[MAX_PLAYER_VEHICLES];

        public int[] index { get; set; } = new int[MAX_PLAYER_VEHICLES];
        public string[] model { get; set; } = new string[MAX_PLAYER_VEHICLES];
        public Vector3[] position { get; set; } = new Vector3[MAX_PLAYER_VEHICLES];

        public float[] rotation { get; set; } = new float[MAX_PLAYER_VEHICLES];
        public int[] cor_1 { get; set; } = new int[MAX_PLAYER_VEHICLES];
        public int[] cor_2 { get; set; } = new int[MAX_PLAYER_VEHICLES];
        public int[] dimension { get; set; } = new int[MAX_PLAYER_VEHICLES];

        public int[] engine { get; set; } = new int[MAX_PLAYER_VEHICLES];
        public int[] brakes { get; set; } = new int[MAX_PLAYER_VEHICLES];
        public int[] suspension { get; set; } = new int[MAX_PLAYER_VEHICLES];
        public int[] neon_r { get; set; } = new int[MAX_PLAYER_VEHICLES];
        public int[] neon_g { get; set; } = new int[MAX_PLAYER_VEHICLES];
        public int[] neon_b { get; set; } = new int[MAX_PLAYER_VEHICLES];
        public int[] armor { get; set; } = new int[MAX_PLAYER_VEHICLES];
        public string[] plate { get; set; } = new string[MAX_PLAYER_VEHICLES];
        public int[] ticket { get; set; } = new int[MAX_PLAYER_VEHICLES];
        public int[] state { get; set; } = new int[MAX_PLAYER_VEHICLES];
        public int[] carkey { get; set; } = new int[MAX_PLAYER_VEHICLES];
        public DateTime[] flag { get; set; } = new DateTime[MAX_PLAYER_VEHICLES];
        public Vector3[] position_crash { get; set; } = new Vector3[MAX_PLAYER_VEHICLES];
        public float[] rotation_crash { get; set; } = new float[MAX_PLAYER_VEHICLES];

        public int[] health { get; set; } = new int[MAX_PLAYER_VEHICLES];
        public int[] fuel { get; set; } = new int[MAX_PLAYER_VEHICLES];

        public string[] json_vehicle_mods { get; set; } = new string[MAX_PLAYER_VEHICLES];

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            VehicleEnum objAsPart = obj as VehicleEnum;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }
        public override int GetHashCode()
        {
            return id;
        }
        public bool Equals(VehicleEnum other)
        {
            if (other == null) return false;
            return (this.id.Equals(other.id));
        }
    }

    public static List<VehicleEnum> vehicle_data = new List<VehicleEnum>();

    public static int MaxPlayerVehicles(Client player)
    {
        int vehicles = 20;
        if (player.GetData("status") == true)
        {
            if (player.GetData("character_vehicle_slots") >= 1)
            {
                vehicles += player.GetData("character_vehicle_slots");
            }
        }

        return vehicles;
    }

    public class VehicleMod
    {
        public int vehicle_color_1;
        public int vehicle_color_2;
        public int vehicle_engine;
        public int vehicle_brakes;
        public int vehicle_suspesion;
        public int vehicle_windowtint;
        public int vehicle_neoncolor;

        public VehicleMod()
        {
            vehicle_color_1 = 0;
            vehicle_color_2 = 0;
            vehicle_engine = -1;
            vehicle_brakes = -1;
            vehicle_suspesion = -1;
            vehicle_windowtint = -1;
            vehicle_neoncolor = -1;
        }
    }

    public static Dictionary<NetHandle, VehicleMod> VehicleModData = new Dictionary<NetHandle, VehicleMod>();

    public static void LoadPlayerVehicles(Client player)
    {
        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {
            Mainpipeline.Open();
            MySqlCommand query = new MySqlCommand("SELECT * FROM `vehicles` WHERE `vehicle_owner_id` = '" + NAPI.Data.GetEntityData(player, "character_sqlid") + "';", Mainpipeline);
            using (MySqlDataReader reader = query.ExecuteReader())
            {
                string data2txt = string.Empty;
                string datatxt = string.Empty;

                int playerid = Main.getIdFromClient(player);
                var index = 0;

                while (reader.Read())
                {
                    vehicle_data[playerid].index[index] = reader.GetInt32("id");
                    vehicle_data[playerid].model[index] = reader.GetString("vehicle_model");
                    vehicle_data[playerid].plate[index] = reader.GetString("vehicle_plate");
                    vehicle_data[playerid].ticket[index] = reader.GetInt32("vehicle_ticket");
                    vehicle_data[playerid].state[index] = reader.GetInt32("vehicle_state");
                    vehicle_data[playerid].carkey[index] = reader.GetInt32("vehicle_carkey");
                    vehicle_data[playerid].position[index] = new Vector3(float.Parse(reader.GetString("vehicle_position_x")), float.Parse(reader.GetString("vehicle_position_y")), float.Parse(reader.GetString("vehicle_position_z")));
                    vehicle_data[playerid].rotation[index] = float.Parse(reader.GetString("vehicle_rotation_x"));
                    vehicle_data[playerid].rotation[index] = float.Parse(reader.GetString("vehicle_rotation_y"));
                    vehicle_data[playerid].rotation[index] = float.Parse(reader.GetString("vehicle_rotation_z"));
                    vehicle_data[playerid].cor_1[index] = reader.GetInt32("vehicle_color_1");
                    vehicle_data[playerid].cor_2[index] = reader.GetInt32("vehicle_color_2");
                    vehicle_data[playerid].dimension[index] = reader.GetInt32("vehicle_dimension");
                    vehicle_data[playerid].engine[index] = reader.GetInt32("vehicle_engine");
                    vehicle_data[playerid].brakes[index] = reader.GetInt32("vehicle_brakes");
                    vehicle_data[playerid].suspension[index] = reader.GetInt32("vehicle_suspesion");
                    vehicle_data[playerid].neon_r[index] = reader.GetInt32("vehicle_neon_r");
                    vehicle_data[playerid].neon_g[index] = reader.GetInt32("vehicle_neon_g");
                    vehicle_data[playerid].neon_b[index] = reader.GetInt32("vehicle_neon_b");
                    vehicle_data[playerid].armor[index] = reader.GetInt32("vehicle_armor");
                    vehicle_data[playerid].health[index] = reader.GetInt32("health");
                    vehicle_data[playerid].fuel[index] = reader.GetInt32("fuel");
                    vehicle_data[playerid].position_crash[index] = new Vector3(float.Parse(reader.GetString("crash_x")), float.Parse(reader.GetString("crash_y")), float.Parse(reader.GetString("crash_z")));
                    vehicle_data[playerid].rotation_crash[index] = float.Parse(reader.GetString("crash_a"));
                    vehicle_data[playerid].flag[index] = reader.GetDateTime("crash_flag");

                    if (reader.GetString("mods").Length > 10)
                    {
                        vehicle_data[playerid].json_vehicle_mods[index] = reader.GetString("mods");
                    }
                    else vehicle_data[playerid].json_vehicle_mods[index] = "";

                    foreach (var business in Business.business_list)
                    {
                        if (business.business_Type == 4 && Main.IsInRangeOfPoint(vehicle_data[playerid].position[index], business.business_dealership_vehicle, 20.0f))
                        {
                            vehicle_data[playerid].state[index] = 0;
                        }
                    }

                    if (vehicle_data[playerid].state[index] == 1)
                    {
                        SpawnPlayerVehicle(player, index);

                        VehicleInventory.LoadVehicleInventoryItens(player, vehicle_data[playerid].handle[index], vehicle_data[playerid].index[index]);

                        if (vehicle_data[playerid].flag[index] < DateTime.Now.AddDays(10) && vehicle_data[playerid].position_crash[index].X != 0 && vehicle_data[playerid].position_crash[index].Y != 0 && vehicle_data[playerid].position_crash[index].Z != 0)
                        {
                            vehicle_data[playerid].handle[index].Position = vehicle_data[playerid].position_crash[index];
                            vehicle_data[playerid].handle[index].Rotation = new Vector3(0, 0, vehicle_data[playerid].rotation_crash[index]);

                            vehicle_data[playerid].position_crash[index] = new Vector3(0, 0, 0);
                            vehicle_data[playerid].rotation_crash[index] = 0f;

                            SaveVehicleFlag(player, index);
                        }

                        vehicle_data[playerid].handle[index].Health = vehicle_data[playerid].health[index];
                    }
                    index++;
                }
            }
        }
    }

    public static void SaveVehicleFlag(Client player, int index)
    {
        int playerid = Main.getIdFromClient(player);
        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {
            try
            {
                Mainpipeline.Open();
                string query = "UPDATE `vehicles` SET `crash_x` = @crash_x, `crash_y` = @crash_y, `crash_z` = @crash_z, `crash_a` = @crash_a, `crash_flag` = @crash_flag ";
                query = query + " WHERE `id` = '" + vehicle_data[playerid].index[index] + "'";

                //NAPI.Util.ConsoleOutput(query);

                MySqlCommand myCommand = new MySqlCommand(query, Mainpipeline);

                myCommand.Parameters.AddWithValue("@crash_x", vehicle_data[playerid].position_crash[index].X.ToString());
                myCommand.Parameters.AddWithValue("@crash_y", vehicle_data[playerid].position_crash[index].Y.ToString());
                myCommand.Parameters.AddWithValue("@crash_z", vehicle_data[playerid].position_crash[index].Z.ToString());
                myCommand.Parameters.AddWithValue("@crash_a", vehicle_data[playerid].rotation_crash[index].ToString());
                myCommand.Parameters.AddWithValue("@crash_flag", vehicle_data[playerid].flag[index]);

                myCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //NAPI.Util.ConsoleOutput("[EXCEPTION SaveVehicleFlag] " + ex.Message);
                //NAPI.Util.ConsoleOutput("[EXCEPTION SaveVehicleFlag] " + ex.StackTrace);
            }
        }
    }

    public static void SaveVehicleMods(Client player, int index)
    {
        int playerid = Main.getIdFromClient(player);
        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {
            try
            {
                Mainpipeline.Open();
                string query = "UPDATE `vehicles` SET  mods = @mods WHERE `id` = '" + vehicle_data[playerid].index[index] + "'";
                MySqlCommand myCommand = new MySqlCommand(query, Mainpipeline);


                string mods = "";
                for (int i = 0; i < 76; i++)
                {
                    if (i == 75) mods = "" + player.Vehicle.GetMod(i) + "";
                    else mods = "" + player.Vehicle.GetMod(i) + "|";
                }

                myCommand.Parameters.AddWithValue("@mods", mods.ToString());


                myCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //NAPI.Util.ConsoleOutput("[EXCEPTION SaveVehicleMods] " + ex.Message);
                //NAPI.Util.ConsoleOutput("[EXCEPTION SaveVehicleMods] " + ex.StackTrace);
            }
        }
    }

    public static void OnFlagVehicle(Client player)
    {
        int playerid = Main.getIdFromClient(player);
        for (int index = 0; index < MAX_PLAYER_VEHICLES; index++)
        {
            if (vehicle_data[playerid].state[index] == 1)
            {
                if (vehicle_data[playerid].handle[index].Exists)
                {
                    SavePlayerVehicle(player, index);

                    if (Main.IsInRangeOfPoint(player.Position, vehicle_data[playerid].handle[index].Position, 10.0f))
                    {
                        vehicle_data[playerid].position_crash[index] = vehicle_data[playerid].handle[index].Position;
                        vehicle_data[playerid].rotation_crash[index] = vehicle_data[playerid].handle[index].Rotation.Z;
                        vehicle_data[playerid].flag[index] = DateTime.Now;

                        SaveVehicleFlag(player, index);
                    }
                }
            }
        }
    }
    public class VehicleMods
    {
        public int vehicle_mod { get; set; }
    }

    public static void SpawnPlayerVehicle(Client player, int index)
    {
        int playerid = Main.getIdFromClient(player);

        var vehicle = NAPI.Util.GetHashKey(vehicle_data[playerid].model[index]).GetHashCode();
        vehicle_data[playerid].handle[index] = NAPI.Vehicle.CreateVehicle(vehicle, vehicle_data[playerid].position[index], vehicle_data[playerid].rotation[index], vehicle_data[playerid].cor_1[index], vehicle_data[playerid].cor_2[index], dimension: (uint)vehicle_data[playerid].dimension[index]);

        // Vehicle Inventory
        VehicleInventory.AddInventoryToVehicle(vehicle_data[playerid].handle[index], NAPI.Util.VehicleNameToModel(vehicle_data[playerid].model[index]));

        // colors
        NAPI.Vehicle.SetVehiclePrimaryColor(vehicle_data[playerid].handle[index], vehicle_data[playerid].cor_1[index]);
        NAPI.Vehicle.SetVehicleSecondaryColor(vehicle_data[playerid].handle[index], vehicle_data[playerid].cor_2[index]);

        // fuel e locks
        NAPI.Vehicle.SetVehicleEngineStatus(vehicle_data[playerid].handle[index], false);
        NAPI.Vehicle.SetVehicleLocked(vehicle_data[playerid].handle[index], true);
        Main.SetVehicleFuel(vehicle_data[playerid].handle[index], vehicle_data[playerid].fuel[index]);

        // plate
        NAPI.Vehicle.SetVehicleNumberPlate(vehicle_data[playerid].handle[index], vehicle_data[playerid].plate[index]);

        vehicle_data[playerid].handle[index].SetSharedData("INTERACT", vehicle_data[playerid].handle[index].Type);

        // string[] temp_mysql_data = reader.GetString("mods").ToString().Split('|');
        string[] temp_mysql_data = vehicle_data[playerid].json_vehicle_mods[index].ToString().Split('|');


        // mods
        if (vehicle_data[playerid].json_vehicle_mods[index] != "")
        {

            for (int i = 0; i < 68; i++)
            {
                if (i == 66) continue;
                if (i == 67) continue;
                vehicle_data[playerid].handle[index].SetMod(i, Convert.ToInt32(temp_mysql_data[i]));
            }
            NAPI.Task.Run(() =>
            {


                vehicle_data[playerid].handle[index].NeonColor = new Color(Convert.ToInt32(temp_mysql_data[68]), Convert.ToInt32(temp_mysql_data[69]), Convert.ToInt32(temp_mysql_data[70]));

                if ((vehicle_data[playerid].handle[index].NeonColor.Red == 0 && vehicle_data[playerid].handle[index].NeonColor.Green == 0 && vehicle_data[playerid].handle[index].NeonColor.Blue == 0) || (vehicle_data[playerid].handle[index].NeonColor.Red == 255 && vehicle_data[playerid].handle[index].NeonColor.Green == 255 && vehicle_data[playerid].handle[index].NeonColor.Blue == 255))
                {
                    API.Shared.SetVehicleNeonState(vehicle_data[playerid].handle[index], false);
                }
                else
                {
                    API.Shared.SetVehicleNeonState(vehicle_data[playerid].handle[index], true);
                }



            }, delayTime: 2000);
        }

        // colors
        NAPI.Vehicle.SetVehiclePrimaryColor(vehicle_data[playerid].handle[index], vehicle_data[playerid].cor_1[index]);
        NAPI.Vehicle.SetVehicleSecondaryColor(vehicle_data[playerid].handle[index], vehicle_data[playerid].cor_2[index]);
        NAPI.Vehicle.SetVehicleLocked(vehicle_data[playerid].handle[index], true);

        try
        {
            NAPI.Task.Run(() =>
            {

                vehicle_data[playerid].handle[index].PrimaryColor = vehicle_data[playerid].cor_1[index];
                vehicle_data[playerid].handle[index].SecondaryColor = vehicle_data[playerid].cor_2[index];
                //vehicle_data[playerid].handle[index].NeonColor = new Color(Convert.ToInt32(temp_mysql_data[67]), Convert.ToInt32(temp_mysql_data[68]), Convert.ToInt32(temp_mysql_data[69]));
                NAPI.Vehicle.SetVehicleLocked(vehicle_data[playerid].handle[index], true);
            }, delayTime: 2000);
        }
        catch
        {

        }

        vehicle_data[playerid].handle[index].Health = vehicle_data[playerid].health[index];
        Main.SetVehicleFuel(vehicle_data[playerid].handle[index], vehicle_data[playerid].fuel[index]);
    }

    public static void SavePlayerVehicle(Client player, int index)
    {
        int playerid = Main.getIdFromClient(player);

        // start string query
        string main_query = "UPDATE vehicles SET ";

        //update coluns
        main_query = main_query + "`vehicle_model` = '" + vehicle_data[playerid].model[index] + "',";
        main_query = main_query + "`vehicle_state` = '" + vehicle_data[playerid].state[index] + "',";
        main_query = main_query + "`vehicle_carkey` = '" + vehicle_data[playerid].carkey[index] + "',";
        main_query = main_query + "`vehicle_position_x` = '" + vehicle_data[playerid].position[index].X.ToString() + "',";
        main_query = main_query + "`vehicle_position_y` = '" + vehicle_data[playerid].position[index].Y.ToString() + "',";
        main_query = main_query + "`vehicle_position_z` = '" + vehicle_data[playerid].position[index].Z.ToString() + "',";
        main_query = main_query + "`vehicle_rotation_z` = '" + vehicle_data[playerid].rotation[index].ToString() + "',";

        main_query = main_query + "`vehicle_dimension` = '" + vehicle_data[playerid].dimension[index] + "',";
        main_query = main_query + "`vehicle_ticket` = '" + vehicle_data[playerid].ticket[index] + "',";

        if (vehicle_data[playerid].state[index] == 1)
        {
            main_query = main_query + "`vehicle_color_1` = '" + vehicle_data[playerid].handle[index].PrimaryColor + "',";
            main_query = main_query + "`vehicle_color_2` = '" + vehicle_data[playerid].handle[index].SecondaryColor + "',";

            main_query = main_query + "`vehicle_plate` = '" + vehicle_data[playerid].plate[index] + "',";

            main_query = main_query + "`health` = '" + Convert.ToInt32(vehicle_data[playerid].handle[index].Health) + "',";
            main_query = main_query + "`fuel` = '" + Convert.ToInt32(Main.GetVehicleFuel(vehicle_data[playerid].handle[index])) + "',";

            vehicle_data[playerid].health[index] = Convert.ToInt32(vehicle_data[playerid].handle[index].Health);
            vehicle_data[playerid].fuel[index] = Convert.ToInt32(Main.GetVehicleFuel(vehicle_data[playerid].handle[index]));
            string vehicle = "";
            for (int i = 0; i < 68; i++)
            {
                vehicle += vehicle_data[playerid].handle[index].GetMod(i) + "|";
            }
            vehicle += vehicle_data[playerid].handle[index].NeonColor.Red + "|";
            vehicle += vehicle_data[playerid].handle[index].NeonColor.Green + "|";
            vehicle += vehicle_data[playerid].handle[index].NeonColor.Blue + "";
            main_query = main_query + "`mods` = '" + vehicle + "' ";

            main_query = main_query + " WHERE `id` = '" + vehicle_data[playerid].index[index] + "'";


            vehicle_data[playerid].json_vehicle_mods[index] = vehicle;

            vehicle_data[playerid].cor_1[index] = vehicle_data[playerid].handle[index].PrimaryColor;
            vehicle_data[playerid].cor_2[index] = vehicle_data[playerid].handle[index].SecondaryColor;
            //API.Util.ConsoleOutput(vehicle);
        }
        else
        {
            main_query = main_query + "`vehicle_plate` = '" + vehicle_data[playerid].plate[index] + "'";
            main_query = main_query + " WHERE `id` = '" + vehicle_data[playerid].index[index] + "'";
        }

        //finish query

        //execute mysql command with the query
        Main.CreateMySqlCommand(main_query);

        //SaveVehicleMods(player, index);
    }

    public static void CreatePlayerVehicle(Client player, int index, string model, float position_x = 0.0f, float position_y = 0.0f, float position_z = 0.0f, float rotation_x = 0.0f, float rotation_y = 0.0f, float rotation_z = 0.0f, int color_1 = 0, int color_2 = 0, int dimension = 0)
    {
        int playerid = Main.getIdFromClient(player);

        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {

            try
            {
                Mainpipeline.Open();
                string query = "INSERT INTO vehicles (`vehicle_owner_id`, `vehicle_model`, `vehicle_state`)" + " VALUES ('" + AccountManage.GetPlayerSQLID(player) + "', '" + model + "', '1')";
                //NAPI.Util.ConsoleOutput(query);
                MySqlCommand myCommand = new MySqlCommand(query, Mainpipeline);
                myCommand.ExecuteNonQuery();
                long last_vehicle_id = myCommand.LastInsertedId;

                vehicle_data[playerid].index[index] = Convert.ToInt32(last_vehicle_id);
                vehicle_data[playerid].model[index] = model;

                vehicle_data[playerid].position[index] = new Vector3(position_x, position_y, position_z);
                vehicle_data[playerid].rotation[index] = rotation_z;
                vehicle_data[playerid].cor_1[index] = color_1;
                vehicle_data[playerid].cor_2[index] = color_2;
                vehicle_data[playerid].dimension[index] = dimension;
                vehicle_data[playerid].ticket[index] = 0;
                vehicle_data[playerid].health[index] = 1000;
                vehicle_data[playerid].fuel[index] = 100;

                string plate_sigla = "NL";
                string plate_number = "NL " + Utils.RandomNumbers(3);
                vehicle_data[playerid].plate[index] = plate_sigla;

                SavePlayerVehicle(player, index);
            }
            catch (Exception ex)
            {
                //NAPI.Util.ConsoleOutput("[EXCEPTION CreatePlayerVehicle] " + ex.Message);
                //NAPI.Util.ConsoleOutput("[EXCEPTION CreatePlayerVehicle] " + ex.StackTrace);
            }
        }
    }

    [RemoteEvent("BuyVehicleFromCreditStore")]
    public static void BuyVehicleFromCreditStore(Client player, string model, int price)
    {
        int index = PlayerVehicle.GetPlayerVehicleFreeSlotIndex(player);

        if (index == -1)
        {
            Main.SendErrorMessage(player, "Sie können nicht mehr als " + PlayerVehicle.MAX_PLAYER_VEHICLES + " Fahrzeuge besitzen.");
            return;
        }

        NAPI.Notification.SendNotificationToPlayer(player, "" + Main.EMBED_CYAN + "Du hast einen " + model + " für " + price + " gekauft.");

        CreatePlayerVehicle(player, index, model, player.Position.X, player.Position.Y, player.Position.Z, 0, 0, player.Rotation.Z, 120, 120, 0);

        PlayerVehicle.vehicle_data[Main.getIdFromClient(player)].state[index] = 1;
        PlayerVehicle.SpawnPlayerVehicle(player, index);

        NAPI.Player.SetPlayerIntoVehicle(player, PlayerVehicle.vehicle_data[Main.getIdFromClient(player)].handle[index], -1);

        NAPI.Vehicle.SetVehicleEngineStatus(PlayerVehicle.vehicle_data[Main.getIdFromClient(player)].handle[index], false);
        NAPI.Vehicle.SetVehicleLocked(PlayerVehicle.vehicle_data[Main.getIdFromClient(player)].handle[index], true);
    }

    public static void ResetPlayerVehicleData(Client player)
    {
        for (int index = 0; index < MAX_PLAYER_VEHICLES; index++)
        {
            ResetPlayerVehicleDataFromIndex(player, index);
        }
    }

    public static void ResetPlayerVehicleDataFromIndex(Client player, int index)
    {
        int playerid = Main.getIdFromClient(player);
        if (vehicle_data[playerid].state[index] == 1)
        {
            if (vehicle_data[playerid].handle[index].Exists) NAPI.Entity.DeleteEntity(vehicle_data[playerid].handle[index]);
        }

        vehicle_data[playerid].model[index] = "";
        vehicle_data[playerid].position[index] = new Vector3(0, 0, 0);
        vehicle_data[playerid].rotation[index] = 0;
        vehicle_data[playerid].cor_1[index] = 0;
        vehicle_data[playerid].cor_2[index] = 0;
        vehicle_data[playerid].dimension[index] = 0;
        vehicle_data[playerid].state[index] = 0;
        vehicle_data[playerid].carkey[index] = 0;
        vehicle_data[playerid].plate[index] = "0";
        vehicle_data[playerid].ticket[index] = 0;

    }

    public static int GetPlayerVehicleCount(Client player)
    {
        int playerid = Main.getIdFromClient(player);
        int index = 0, count = 0;
        while (count < MAX_PLAYER_VEHICLES)
        {
            if (vehicle_data[playerid].model[index] != "")
            {
                index++;
            }
            count++;
        }
        return index;
    }

    public static int GetPlayerVehicleFreeSlotIndex(Client player)
    {
        int playerid = Main.getIdFromClient(player);
        for (int index = 0; index < MAX_PLAYER_VEHICLES; index++)
        {
            if (vehicle_data[playerid].model[index] == "")
            {
                return index;
            }
        }
        return -1;
    }

    [RemoteEvent("KeyPress:F5")]
    public static void KeyPressF5(Client player)
    {
        if (player.GetData("General_CEF") == false)
        {
            ShowPlayerVehicles(player);
        }

    }

    [RemoteEvent("TrackVehicle")]
    public static void TrackVehicle(Client player, int index)
    {
        int playerid = Main.getIdFromClient(player);
        player.TriggerEvent("Destroy_Character_Menu");
        if (vehicle_data[playerid].model[index] != "")
        {
            if (vehicle_data[playerid].state[index] != 1)
            {
                Main.SendErrorMessage(player, "Ihr Fahrzeugbedarf wird erzeugt, damit Sie es finden können.");

            }
            else
            {
                Vector3 position = NAPI.Entity.GetEntityPosition(vehicle_data[playerid].handle[index]);

                NAPI.Notification.SendNotificationToPlayer(player, "Dein ~y~" + vehicle_data[playerid].model[index] + "~w~ ist ~b~" + position.DistanceTo(player.Position).ToString("0") + " meter~w~ von dir entfernt.");

                player.TriggerEvent("blip_remove", "Mein Fahrzeug");
                player.TriggerEvent("blip_create_ext", "Mein Fahrzeug", position, 75, 0.80f, 225);

                NAPI.Task.Run(() =>
                {
                    player.TriggerEvent("blip_remove", "Mein Fahrzeug");
                }, delayTime: 60 * 1000);
            }
        }
        else
        {
            Main.SendErrorMessage(player, "Sie haben keine Fahrzeuge im " + index + " Slot.");
        }
    }

    [RemoteEvent("DeleteVehicle")]
    public static void DeleteVehicle(Client player, int index)
    {
        player.TriggerEvent("Destroy_Character_Menu");
        int playerid = Main.getIdFromClient(player);

        if (vehicle_data[playerid].model[index] != "")
        {

            if (vehicle_data[playerid].state[index] == 1)
            {
                if (vehicle_data[playerid].handle[index].Exists)
                {
                    vehicle_data[playerid].handle[index].Delete();
                }
            }

            Main.CreateMySqlCommand("DELETE FROM `vehicles` WHERE `id` = '" + vehicle_data[playerid].index[index] + "';");

            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben das ~b~" + vehicle_data[playerid].model[index] + " ~w~Fahrzeug erfolgreich gelöscht.");

            vehicle_data[playerid].model[index] = "";
            vehicle_data[playerid].position[index] = new Vector3(0, 0, 0);
            vehicle_data[playerid].rotation[index] = 0;
            vehicle_data[playerid].cor_1[index] = 0;
            vehicle_data[playerid].cor_2[index] = 0;
            vehicle_data[playerid].dimension[index] = 0;
            vehicle_data[playerid].state[index] = 0;
            vehicle_data[playerid].carkey[index] = 0;
            vehicle_data[playerid].plate[index] = "0";
            vehicle_data[playerid].ticket[index] = 0;
        }
        else
        {
            Main.SendErrorMessage(player, "Sie haben keine Fahrzeuge im Slot " + index + ".");
        }
    }

    public static void ShowPlayerVehicles(Client player)
    {
        int playerid = Main.getIdFromClient(player);
        List<dynamic> menu_item_list = new List<dynamic>();
        for (int index = 0; index < MaxPlayerVehicles(player); index++)
        {
            if (vehicle_data[playerid].model[index] != "")
            {
                if (vehicle_data[playerid].state[index] == 0)
                {
                    menu_item_list.Add(new { Model = vehicle_data[playerid].model[index], Status = "In der LS-PD Impound Garage", Index = index });
                }
                else if (vehicle_data[playerid].state[index] == 1)
                {
                    menu_item_list.Add(new { Model = vehicle_data[playerid].model[index], Status = "In Los Santos", Index = index });
                }
                else if (vehicle_data[playerid].state[index] == 2)
                {
                    menu_item_list.Add(new { Model = vehicle_data[playerid].model[index], Status = "In der Garage", Index = index }); // Need Translate
                }
            }
        }
        player.TriggerEvent("Display_Player_Vehicles", NAPI.Util.ToJson(menu_item_list));
    }

    public static void ShowPlayerVehiclesToRelease(Client player)
    {
        int playerid = Main.getIdFromClient(player);
        List<dynamic> menu_item_list = new List<dynamic>();
        for (int index = 0; index < MaxPlayerVehicles(player); index++)
        {
            if (vehicle_data[playerid].model[index] != "")
            {
                int foreach_index = 0, dealership_index = -1, price = 1000;
                foreach (var vehicle_dealership in CarDealership.CarDealershipVehicles)
                {
                    if (vehicle_dealership.car_dealership_model_name == vehicle_data[playerid].model[index])
                    {
                        dealership_index = foreach_index;
                    }
                    foreach_index++;
                }

                if (dealership_index == -1)
                {
                    price = 1000;
                }
                else price = Convert.ToInt32(CarDealership.CarDealershipVehicles[dealership_index].car_dealership_stock_price) / 100 * 5;

                if (vehicle_data[playerid].state[index] == 0)
                {
                    menu_item_list.Add(new { Index = index, Model = vehicle_data[playerid].model[index], Price = price });
                }
            }
        }
        player.TriggerEvent("Display_Release_Vehicles", NAPI.Util.ToJson(menu_item_list));
    }

    [RemoteEvent("PayInsure")]
    public static void PayInsurece(Client player, int index, int price)
    {
        int playerid = Main.getIdFromClient(player);
        player.TriggerEvent("Hide_Browser");
        if (vehicle_data[playerid].model[index] != "")
        {
            if (vehicle_data[playerid].state[index] == 0)
            {
                if (Main.GetPlayerMoney(player) < price)
                {
                    // player.SendChatMessage(" Du hast nicht $" + price + " dieses Fahrzeug freizugeben.");
                    NAPI.Notification.SendNotificationToPlayer(player, " Du hast nicht $" + price + " genug um dieses Fahrzeug freizukaufen.");

                    return;
                }

                Random rnd = new Random();
                int estacionamento = rnd.Next(0, 5);

                switch (estacionamento)
                {
                    case 0:
                        vehicle_data[playerid].position[index] = new Vector3(410.3766, -1657.3262, 29.29192);//spawn
                        vehicle_data[playerid].rotation[index] = -37.68875f;

                        break;
                    case 1:
                        vehicle_data[playerid].position[index] = new Vector3(405.1207, -1653.2834, 29.292526);
                        vehicle_data[playerid].rotation[index] = -41.172325f;

                        break;
                    case 2:
                        vehicle_data[playerid].position[index] = new Vector3(400.4685, -1649.041, 29.293207);
                        vehicle_data[playerid].rotation[index] = -47.73843f;

                        break;
                    case 3:
                        vehicle_data[playerid].position[index] = new Vector3(395.82678, -1644.6279, 29.291952);
                        vehicle_data[playerid].rotation[index] = -51.233463f;
                        break;
                    case 4:
                        vehicle_data[playerid].position[index] = new Vector3(419.756, -1629.4135, 29.291935);
                        vehicle_data[playerid].rotation[index] = 139.77347f;
                        break;
                    case 5:
                        vehicle_data[playerid].position[index] = new Vector3(421.7046, -1635.8123, 29.303585);
                        vehicle_data[playerid].rotation[index] = 90.85434f;
                        break;
                }

                Main.GivePlayerMoney(player, -price);

                vehicle_data[playerid].state[index] = 1;
                vehicle_data[playerid].carkey[index] = 1;
                SpawnPlayerVehicle(player, index);
                SavePlayerVehicle(player, index);

                NAPI.Notification.SendNotificationToPlayer(player, "Du hast dein ~y~" + vehicle_data[playerid].model[index] + " vom~w~ ACLS für ~g~$" + price.ToString("N0") + "~w~ abgehollt.");
            }
            else
            {
                Main.SendErrorMessage(player, "Dieses Fahrzeug befindet sich nicht beim ACLS.");
            }
        }
        else
        {
            Main.SendErrorMessage(player, "Sie haben keine Fahrzeuge im Slot " + index + ".");
        }
    }

    [Command("carsave")]
    public static void AUTO_SAVE_Vehicle(Client player)
    {
        if (!player.IsInVehicle)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "<C>Fahrzeug:</C> ~n~Fahrzeug Position konnte nicht gespeichert werden, da du in kein Fahrzeug warst!");
            return;
        }
        int playerid = Main.getIdFromClient(player);


        for (int index = 0; index < MAX_PLAYER_VEHICLES; index++)
        {
            if (vehicle_data[playerid].state[index] == 1)
            {
                if (vehicle_data[playerid].handle[index].Exists && vehicle_data[playerid].handle[index] == player.Vehicle)
                {
                    int can_pass = 0;

                    foreach (var business in Business.business_list)
                    {
                        if (business.business_Type == 4 && Main.IsInRangeOfPoint(player.Position, business.business_dealership_vehicle, 5.0f))
                        {
                            can_pass = 1;
                        }
                    }

                    if (can_pass == 1)
                    {
                        NAPI.Notification.SendNotificationToPlayer(player, "<C>Fahrzeug:</C> ~n~Sie können Ihr Fahrzeug nicht in der Nähe eines Unternehmens abstellen.");
                        return;
                    }

                    vehicle_data[playerid].position[index] = player.Vehicle.Position;
                    vehicle_data[playerid].rotation[index] = player.Vehicle.Rotation.Z;

                    SavePlayerVehicle(player, index);
                    NAPI.Notification.SendNotificationToPlayer(player, "<C>Fahrzeug:</C> ~n~Sie haben Ihr " + vehicle_data[playerid].model[index] + " geparkt.");
                    return;
                }
            }
        }
    }

    public static void CMD_vehicle_parking_auto_save(Client player)
    {
        Vehicle vehicle = Utils.GetClosestVehicle(player, 15.0f);
        int playerid = Main.getIdFromClient(player);

        for (int index = 0; index < PlayerVehicle.MAX_PLAYER_VEHICLES; index++) //(int index = 0; index < MAX_PLAYER_VEHICLES; index++)
        {
            if (NAPI.Entity.DoesEntityExist(vehicle)) //(vehicle_data[playerid].state[index] == 1)
            {
                if (PlayerVehicle.vehicle_data[playerid].state[index] == 1 && PlayerVehicle.vehicle_data[playerid].handle[index].Exists && vehicle == PlayerVehicle.vehicle_data[playerid].handle[index])
                // if (vehicle_data[playerid].handle[index].Exists && vehicle_data[playerid].handle[index] == player.Vehicle)
                {
                    int can_pass = 0;

                    foreach (var business in Business.business_list)
                    {
                        if (business.business_Type == 4 && Main.IsInRangeOfPoint(player.Position, business.business_dealership_vehicle, 20.0f))
                        {
                            can_pass = 1;
                        }
                    }

                    if (can_pass == 1)
                    {
                        NAPI.Notification.SendNotificationToPlayer(player, "<C>Fahrzeug:</C> ~n~Sie können Ihr Fahrzeug nicht in der Nähe eines Unternehmens parken.");
                        return;
                    }

                    vehicle_data[playerid].position[index] = player.Vehicle.Position;
                    vehicle_data[playerid].rotation[index] = player.Vehicle.Rotation.Z;

                    SavePlayerVehicle(player, index);
                    NAPI.Notification.SendNotificationToPlayer(player, "<C>Fahrzeug:</C> ~n~Sie haben Ihr " + vehicle_data[playerid].model[index] + " geparkt.");
                    return;
                }
            }
        }
        InteractMenu_New.SendNotificationInfo(player, "Dieses Fahrzeug steht Ihnen nicht zum Parken zur Verfügung.");
    }

    [Command("estacionar")]
    public static void CMD_estacionar(Client player)
    {
        if (!player.IsInVehicle)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "<C>Fahrzeug:</C> ~n~Fahrzeug Position konnte nicht gespeichert werden, da du in kein Fahrzeug warst!");
            return;
        }
        Vehicle vehicle = Utils.GetClosestVehicle(player, 15.0f);
        int playerid = Main.getIdFromClient(player);

        for (int index = 0; index < PlayerVehicle.MAX_PLAYER_VEHICLES; index++) //(int index = 0; index < MAX_PLAYER_VEHICLES; index++)
        {
            if (NAPI.Entity.DoesEntityExist(vehicle)) //(vehicle_data[playerid].state[index] == 1)
            {
                if (PlayerVehicle.vehicle_data[playerid].state[index] == 1 && PlayerVehicle.vehicle_data[playerid].handle[index].Exists && vehicle == PlayerVehicle.vehicle_data[playerid].handle[index])
                // if (vehicle_data[playerid].handle[index].Exists && vehicle_data[playerid].handle[index] == player.Vehicle)
                {
                    int can_pass = 0;

                    foreach (var business in Business.business_list)
                    {
                        if (business.business_Type == 4 && Main.IsInRangeOfPoint(player.Position, business.business_dealership_vehicle, 20.0f))
                        {
                            can_pass = 1;
                        }
                    }

                    if (can_pass == 1)
                    {
                        NAPI.Notification.SendNotificationToPlayer(player, "<C>Fahrzeug:</C> ~n~Sie können Ihr Fahrzeug nicht in der Nähe eines Unternehmens abstellen.");
                        return;
                    }

                    vehicle_data[playerid].position[index] = player.Vehicle.Position;
                    vehicle_data[playerid].rotation[index] = player.Vehicle.Rotation.Z;

                    SavePlayerVehicle(player, index);
                    NAPI.Notification.SendNotificationToPlayer(player, "<C>Fahrzeug:</C> ~n~Sie haben Ihr " + vehicle_data[playerid].model[index] + " geparkt.");
                    return;
                }
            }
        }
        InteractMenu_New.SendNotificationInfo(player, "Dieses Fahrzeug steht Ihnen nicht zum Parken zur Verfügung.");
    }


    [Command("verkaufen", "~y~Uso:~w~ /verkaufen [büger] [preis]")]
    public static void CMD_verkaufen(Client player, Client target, int price)
    {
        if (target == null)
        {
            Main.SendErrorMessage(player, "Dieser Spieler ist nicht online.");
            return;
        }

        if (player.GetData("status") == false)
        {
            Main.SendErrorMessage(player, "Dieser Spieler ist nicht online.");
            return;
        }

        if (price <= 0)
        {
            Main.SendErrorMessage(player, "Der Betrag muss über 1 Dollar liegen.");
            return;
        }

        if (player == target)
        {
            Main.SendErrorMessage(player, "Sie können kein Fahrzeug für sich selbst verkaufen.");
            return;
        }

        if (!Main.IsInRangeOfPoint(player.Position, target.Position, 5.0f))
        {
            Main.SendErrorMessage(player, "Sie sind nicht in der Nähe dieses Players.");
            return;
        }

        int playerid = Main.getIdFromClient(player);

        for (int index = 0; index < MAX_PLAYER_VEHICLES; index++)
        {
            if (vehicle_data[playerid].state[index] == 1)
            {
                if (vehicle_data[playerid].handle[index].Exists && vehicle_data[playerid].handle[index] == player.Vehicle)
                {
                    if (player.Vehicle.Model == (uint)VehicleHash.Pbus2)
                    {
                        Main.SendErrorMessage(player, "Sie können dieses Fahrzeug nicht verkaufen, da es ausschließlich für Fonder bestimmt ist.");
                        return;
                    }

                    Main.SendInfoMessage(player, "Wird Ihr Angebot ~g~angenommen?~w~");


                    target.SetData("vehicle_offer_id", index);
                    target.SetData("vehicle_offer_price", price);
                    target.SetData("vehicle_offer_handle", player);


                    InteractMenu.ShowModal(target, "VEHICLE_SELL_TO_PLAYER", "Gebrauchtwagenhandel, gekauft wie gesehen", "" + AccountManage.GetCharacterName(player) + " bietet Dir folgenden Fahrzeugtyp  " + vehicle_data[playerid].model[index] + " für " + price.ToString("N0") + " $ an.", "Angebot annehmen.", "Angebot ablehnen.");
                    return;
                }
            }
        }
        Main.SendErrorMessage(player, "Dieses Fahrzeug gehört Ihnen nicht!");
    }

    public static void ModalConfirm(Client player, string response)
    {
        if (response == "VEHICLE_SELL_TO_PLAYER")
        {
            Client selling = NAPI.Data.GetEntityData(player, "vehicle_offer_handle");

            if (!API.Shared.IsPlayerConnected(selling))
            {
                Main.SendErrorMessage(player, "Kein Bürger da.");
                return;
            }

            if (selling.GetData("status") == false)
            {
                Main.SendErrorMessage(player, "Kein Bürger da.");
                return;
            }

            int vehicle_id = player.GetData("vehicle_offer_id");
            int price = player.GetData("vehicle_offer_price");

            int targetid = Main.getIdFromClient(selling);
            int playerid = Main.getIdFromClient(player);
            for (int index = 0; index < MAX_PLAYER_VEHICLES; index++)
            {
                if (vehicle_data[targetid].state[index] == 1)
                {
                    if (vehicle_data[targetid].handle[index].Exists && vehicle_data[targetid].handle[index] == selling.Vehicle && index == vehicle_id)
                    {

                        if (Main.GetPlayerMoney(player) < price)
                        {
                            Main.SendErrorMessage(player, "Sie haben kein Geld $" + price.ToString("N0") + " um dieses Angebot anzunehmen.");
                            return;
                        }

                        if (GetPlayerVehicleFreeSlotIndex(player) == -1)
                        {
                            Main.SendErrorMessage(player, "Sie haben bereits zuviele Autos.");
                            return;
                        }

                        Main.GivePlayerMoney(selling, price);
                        Main.GivePlayerMoney(player, -price);

                        // 
                        int free_slot = GetPlayerVehicleFreeSlotIndex(player);
                        Main.CreateMySqlCommand("UPDATE `vehicles` SET `vehicle_owner_id` = " + AccountManage.GetPlayerSQLID(player) + " WHERE `id` = " + vehicle_data[targetid].index[index] + "; ");

                        // Add Variable to new owner
                        vehicle_data[playerid].handle[free_slot] = selling.Vehicle;
                        vehicle_data[targetid].index[free_slot] = vehicle_data[targetid].index[index];
                        vehicle_data[playerid].model[free_slot] = vehicle_data[targetid].model[index];
                        vehicle_data[playerid].position[free_slot] = selling.Vehicle.Position;
                        vehicle_data[playerid].rotation[free_slot] = selling.Vehicle.Rotation.Z;
                        vehicle_data[playerid].cor_1[free_slot] = vehicle_data[targetid].cor_1[index];
                        vehicle_data[playerid].cor_2[free_slot] = vehicle_data[targetid].cor_2[index];
                        vehicle_data[playerid].dimension[free_slot] = vehicle_data[targetid].dimension[index];
                        vehicle_data[playerid].state[free_slot] = vehicle_data[targetid].state[index];
                        vehicle_data[playerid].plate[free_slot] = vehicle_data[targetid].plate[index];
                        vehicle_data[playerid].ticket[free_slot] = vehicle_data[targetid].ticket[index];


                        // Remove Vehicle from old owner
                        vehicle_data[targetid].handle[index] = null;
                        vehicle_data[targetid].model[index] = "";
                        vehicle_data[targetid].position[index] = new Vector3(0, 0, 0);
                        vehicle_data[targetid].rotation[index] = 0;
                        vehicle_data[targetid].cor_1[index] = 0;
                        vehicle_data[targetid].cor_2[index] = 0;
                        vehicle_data[targetid].dimension[index] = 0;
                        vehicle_data[targetid].state[index] = 0;
                        vehicle_data[targetid].plate[index] = "0";
                        vehicle_data[targetid].ticket[index] = 0;

                        // Save vehicle to new owner
                        SavePlayerVehicle(player, index);
                        SavePlayerVehicle(selling, index);

                        return;
                    }

                }
            }
        }
    }
}

