using System;
using System.Collections.Generic;
using GTANetworkAPI;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using DerStr1k3r.Core;

class GarageSys : Script
{
    public class GarageEnum : IEquatable<GarageEnum>
    {
        public int id { get; set; }
        public Vector3 position { get; set; }
        public float position_a { get; set; }

        public TextLabel label { get; set; }
        public Marker marker { get; set; }
        public Blip blip { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            GarageEnum objAsPart = obj as GarageEnum;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }
        public override int GetHashCode()
        {
            return id;
        }
        public bool Equals(GarageEnum other)
        {
            if (other == null) return false;
            return (this.id.Equals(other.id));
        }
    }

    public static List<GarageEnum> garage_array = new List<GarageEnum>();
    public static int MAX_GARAGEM = 0;

    public static void GarageSystemInit()
    {
        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {
            Mainpipeline.Open();
            MySqlCommand query = new MySqlCommand("SELECT * FROM `garagem`;", Mainpipeline);

            using (MySqlDataReader reader = query.ExecuteReader())
            {
                var index = 0;
                while (reader.Read())
                {
                    garage_array.Add(new GarageEnum()
                    {
                        id = reader.GetInt32("id"),
                        position = new Vector3(reader.GetFloat("position_x"), reader.GetFloat("position_y"), reader.GetFloat("position_z")),
                        position_a = reader.GetFloat("position_a"),
                    });

                    garage_array[index].label = NAPI.TextLabel.CreateTextLabel("", garage_array[index].position + new Vector3(0, 0, 0.6), 8.0f, 0.6f, 4, new Color(191, 26, 141, 255), false, 0);
                    garage_array[index].marker = NAPI.Marker.CreateMarker(27, garage_array[index].position - new Vector3(0, 0, 0.0), new Vector3(), new Vector3(), 2.0f, new Color(255, 255, 255, 200), false, 0);

                    if (garage_array[index].position.X == 0)
                    {
                        //NAPI.Blip.SetBlipTransparency(garage_array[index].blip, 0);
                    }
                    index++;
                    MAX_GARAGEM++;
                }
            }
        }
    }

    public static void SaveGaragem(int index)
    {
        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {
            try
            {
                Mainpipeline.Open();
                string query = "UPDATE `garagem` SET `position_x` = @position_x, `position_y` = @position_y, `position_z` = @position_z, `position_a` = @position_a WHERE `id` = '" + garage_array[index].id + "'";

                MySqlCommand myCommand = new MySqlCommand(query, Mainpipeline);

                myCommand.Parameters.AddWithValue("@position_x", garage_array[index].position.X);
                myCommand.Parameters.AddWithValue("@position_y", garage_array[index].position.Y);
                myCommand.Parameters.AddWithValue("@position_z", garage_array[index].position.Z);
                myCommand.Parameters.AddWithValue("@position_a", garage_array[index].position_a);
                myCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //NAPI.Util.ConsoleOutput("[EXCEPTION SaveGaragem] " + ex.Message);
                //NAPI.Util.ConsoleOutput("[EXCEPTION SaveGaragem] " + ex.StackTrace);
            }
        }
    }

    public static void PressKeyE(Client player)
    {
        foreach (var entrace in garage_array)
        {
            if (Main.IsInRangeOfPoint(player.Position, entrace.position, 4.0f))
            {
                int playerid = Main.getIdFromClient(player);

                if (player.IsInVehicle)
                {
                    for (int index = 0; index < PlayerVehicle.MAX_PLAYER_VEHICLES; index++)
                    {
                        if (PlayerVehicle.vehicle_data[playerid].state[index] == 1)
                        {
                            if (PlayerVehicle.vehicle_data[playerid].handle[index].Exists && PlayerVehicle.vehicle_data[playerid].handle[index] == player.Vehicle)
                            {
                                PlayerVehicle.vehicle_data[playerid].state[index] = 3;
                                PlayerVehicle.SavePlayerVehicle(player, index);
                                NAPI.Notification.SendNotificationToPlayer(player, "Du hast dein ~b~" + PlayerVehicle.vehicle_data[playerid].model[index] + "~w~ in der Garage geparkt.");

                                NAPI.Task.Run(() =>
                                {
                                    PlayerVehicle.vehicle_data[playerid].handle[index].Delete();
                                }, delayTime: 200);
                                return;
                            }
                        }
                    }
                    InteractMenu_New.SendNotificationError(player, "Dieses Fahrzeug gehört nicht Ihnen, um es in der Garage einzuparken !");
                }
                else
                {
                    List<dynamic> menu_item_list = new List<dynamic>();
                    int count = 0;
                    for (int index = 0; index < PlayerVehicle.MAX_PLAYER_VEHICLES; index++)
                    {
                        if (PlayerVehicle.vehicle_data[playerid].state[index] == 3)
                        {
                            menu_item_list.Add(new { Type = 1, Name = PlayerVehicle.vehicle_data[playerid].model[index], Description = "Tank: " + PlayerVehicle.vehicle_data[playerid].fuel[index] + "%", RightLabel = "" + PlayerVehicle.vehicle_data[playerid].plate[index].ToString() + "" });
                            player.SetData("ListTrack_" + count, index);
                            count++;
                        }
                    }

                    if (count == 0)
                    {
                        InteractMenu_New.SendNotificationError(player, "Sie haben keine Fahrzeuge in der Garage..");
                        return;
                    }
                    InteractMenu.CreateMenu(player, "GARAGE_SYSTEM_RESPONSE", "Fahrzeug Garage", "~g~GARAGE", true, JsonConvert.SerializeObject(menu_item_list), false, BackgroundColor: "LightSlateGray");
                }
            }
        }
    }

    public static void SelectMenuResponse(Client player, String callbackId, int selectedIndex, String objectName, String valueList)
    {
        if (callbackId == "GARAGE_SYSTEM_RESPONSE")
        {
            int index = player.GetData("ListTrack_" + selectedIndex);
            int playerid = Main.getIdFromClient(player);

            if (PlayerVehicle.vehicle_data[playerid].state[index] == 3)
            {
                PlayerVehicle.vehicle_data[playerid].state[index] = 1;
                PlayerVehicle.vehicle_data[playerid].carkey[index] = 1;
                PlayerVehicle.SpawnPlayerVehicle(player, index);
                PlayerVehicle.vehicle_data[playerid].handle[index].Position = player.Position;
                PlayerVehicle.vehicle_data[playerid].handle[index].Rotation = player.Rotation;

                try
                {
                    player.SetIntoVehicle(PlayerVehicle.vehicle_data[playerid].handle[index], -1);
                }
                catch
                {

                }

                PlayerVehicle.SavePlayerVehicle(player, index);
                VehicleInventory.LoadVehicleInventoryItens(player, PlayerVehicle.vehicle_data[playerid].handle[index], PlayerVehicle.vehicle_data[playerid].index[index]);
                NAPI.Notification.SendNotificationToPlayer(player, "Du hast dein ~b~" + PlayerVehicle.vehicle_data[playerid].model[index] + "~w~ ausgeparkt.");  
            }
        }
    }

    [Command("creategarage")]
    public static void CMD_creategarage(Client player)
    {
        if (AccountManage.GetPlayerAdmin(player) == 0)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben keine Berechtigung, diesen Befehl zu .");
            return;
        }
        int count = 0;
        foreach (var garage in garage_array)
        {
            if (garage.position.X == 0 && garage.position.Y == 0)
            {
                player.TriggerEvent("Notify", "~o~** ADMIN **~n~~n~~w~Sie haben die ID-Garage erfolgreich erstellt#" + count + "");

                garage.position = player.Position;
                garage.label.Position = player.Position + new Vector3(0, 0, 0.5);
                garage.marker.Position = player.Position - new Vector3(0, 0, 0.0);

                SaveGaragem(count);
                return;
            }
            count++;
        }
    }

    [Command("destroygarage")]
    public static void CMD_destroygarage(Client player)
    {
        if (AccountManage.GetPlayerAdmin(player) == 10)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben keine Berechtigung, diesen Befehl zu verwenden.");
            return;
        }
        int count = 0;
        foreach (var garage in garage_array)
        {
            if (Main.IsInRangeOfPoint(player.Position, garage.position, 4.0f))
            {
                player.TriggerEvent("Notify", "~o~** ADMIN **~n~~n~~w~Sie haben die ID - Garage erfolgreich zerstört. #" + count + "");

                garage.position = new Vector3(0, 0, 0);
                garage.label.Position = player.Position;
                garage.marker.Position = player.Position;

                garage.blip.Position = garage.label.Position;
                garage.blip.Transparency = 0;

                SaveGaragem(count);
                return;
            }
            count++;
        }
    }
}