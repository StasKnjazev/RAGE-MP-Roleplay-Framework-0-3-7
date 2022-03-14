using System;
using System.Collections.Generic;
using GTANetworkAPI;
using MySql.Data.MySqlClient;

class SecreatsSystem : Script
{
    public class SecreatsEnum : IEquatable<SecreatsEnum>
    {
        public int id { get; set; }
        public string name { get; set; }

        public Vector3 exterior { get; set; }
        public Vector3 interior { get; set; }
        public float exterior_a { get; set; }
        public float interior_a { get; set; }
        public uint exterior_dimension { get; set; }
        public uint interior_dimension { get; set; }

        public TextLabel label { get; set; }
        public Marker marker { get; set; }

        public TextLabel label_interior { get; set; }
        public Marker marker_interior { get; set; }

        public override string ToString()
        {
            return "ID: " + id + "   Name: " + name;
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            SecreatsEnum objAsPart = obj as SecreatsEnum;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }
        public override int GetHashCode()
        {
            return id;
        }
        public bool Equals(SecreatsEnum other)
        {
            if (other == null) return false;
            return (this.id.Equals(other.id));
        }
    }

    public static List<SecreatsEnum> secreats_data = new List<SecreatsEnum>();

    public static int MAX_SECREATS = 0;

    public static void SecreatsSystemInit()
    {
        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {
            Mainpipeline.Open();
            MySqlCommand query = new MySqlCommand("SELECT * FROM `secreats`;", Mainpipeline);

            using (MySqlDataReader reader = query.ExecuteReader())
            {
                var index = 0;
                while (reader.Read())
                {
                    secreats_data.Add(new SecreatsEnum()
                    {
                        id = reader.GetInt32("id"),
                        name = reader.GetString("name"),
                        exterior = new Vector3(reader.GetFloat("exterior_x"), reader.GetFloat("exterior_y"), reader.GetFloat("exterior_z")),
                        interior = new Vector3(reader.GetFloat("interior_x"), reader.GetFloat("interior_y"), reader.GetFloat("interior_z")),
                        exterior_a = reader.GetFloat("exterior_a"),
                        interior_a = reader.GetFloat("interior_a"),
                        exterior_dimension = reader.GetUInt32("exterior_dimension"),
                        interior_dimension = reader.GetUInt32("interior_dimension")
                    });

                    secreats_data[index].label = NAPI.TextLabel.CreateTextLabel("" + secreats_data[index].name + "~n~~n~Drücke ~y~E~w~ zum eintreten", secreats_data[index].exterior, 8.0f, 0.6f, 0, new Color(255, 255, 255, 255), false, secreats_data[index].exterior_dimension);
                    secreats_data[index].label_interior = NAPI.TextLabel.CreateTextLabel("- Secreat verlassen -", secreats_data[index].interior, 8.0f, 0.6f, 0, new Color(255, 255, 255, 255), false, secreats_data[index].exterior_dimension);

                    secreats_data[index].marker = NAPI.Marker.CreateMarker(27, secreats_data[index].exterior - new Vector3(0, 0, 0.8f), new Vector3(), new Vector3(), 1.5f, new Color(244, 217, 66, 150), false, secreats_data[index].exterior_dimension);
                    secreats_data[index].marker_interior = NAPI.Marker.CreateMarker(27, secreats_data[index].interior - new Vector3(0, 0, 0.8f), new Vector3(), new Vector3(), 1.5f, new Color(244, 217, 66, 150), false, secreats_data[index].interior_dimension);

                    index++;
                    MAX_SECREATS++;
                }
            }
        }
    }

    public static void SaveSecreats(int index)
    {
        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {
            try
            {
                Mainpipeline.Open();
                string query = "UPDATE `secreats` SET `name` = @name, `exterior_x` = @exterior_x, `exterior_y` = @exterior_y, `exterior_z` = @exterior_z, `exterior_a` = @exterior_a, `interior_x` = @interior_x, `interior_y` = @interior_y, `interior_z` = @interior_z, `interior_a` = @interior_a, `interior_dimension` = @interior_dimension, `exterior_dimension` = @exterior_dimension WHERE `id` = '" + secreats_data[index].id + "'";

                MySqlCommand myCommand = new MySqlCommand(query, Mainpipeline);

                myCommand.Parameters.AddWithValue("@name", "" + secreats_data[index].name + "");
                myCommand.Parameters.AddWithValue("@exterior_x", secreats_data[index].exterior.X);
                myCommand.Parameters.AddWithValue("@exterior_y", secreats_data[index].exterior.Y);
                myCommand.Parameters.AddWithValue("@exterior_z", secreats_data[index].exterior.Z);
                myCommand.Parameters.AddWithValue("@exterior_a", secreats_data[index].exterior_a);
                myCommand.Parameters.AddWithValue("@interior_x", secreats_data[index].interior.X);
                myCommand.Parameters.AddWithValue("@interior_y", secreats_data[index].interior.Y);
                myCommand.Parameters.AddWithValue("@interior_z", secreats_data[index].interior.Z);
                myCommand.Parameters.AddWithValue("@interior_a", secreats_data[index].interior_a);
                myCommand.Parameters.AddWithValue("@interior_dimension", secreats_data[index].interior_dimension);
                myCommand.Parameters.AddWithValue("@exterior_dimension", secreats_data[index].exterior_dimension);
                myCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {
                //NAPI.Util.ConsoleOutput("[EXCEPTION SaveSecreats] " + ex.Message);
                //NAPI.Util.ConsoleOutput("[EXCEPTION SaveSecreats] " + ex.StackTrace);
            }
        }
    }

    public static void PressKeyY(Client player)
    {
        foreach(var secreats in secreats_data)
        {
            if(Main.IsInRangeOfPoint(player.Position, secreats.exterior, 2.0f) && player.Dimension == secreats.exterior_dimension)
            {
                player.TriggerEvent("moveSkyCamera", player, "up", 1, false);
                NAPI.Task.Run(() =>
                {
                    player.Position = secreats.interior;
                    player.Rotation = new Vector3(0, 0, secreats.interior_a);
                    player.Dimension = secreats.interior_dimension;

                    player.TriggerEvent("moveSkyCamera", player, "down");
                    NAPI.TextLabel.CreateTextLabel("- Metal -~n~~n~Drücke ~y~E~w~ zum sammmeln", new Vector3(-588.7558, 2050.376, 129.9985), 3f, 9f, 0, new Color(255, 255, 255, 100), false, 0);
                    NAPI.TextLabel.CreateTextLabel("- Metal -~n~~n~Drücke ~y~E~w~ zum sammmeln", new Vector3(-520.6819, 1894.66, 122.4449), 3f, 9f, 0, new Color(255, 255, 255, 100), false, 0);
                }, delayTime: 3500);
                return;
            }
            else if (Main.IsInRangeOfPoint(player.Position, secreats.interior, 2.0f) && player.Dimension == secreats.interior_dimension)
            {
                player.TriggerEvent("moveSkyCamera", player, "up", 1, false);
                NAPI.Task.Run(() =>
                {
                    player.Position = secreats.exterior;
                    player.Rotation = new Vector3(0, 0, secreats.exterior_a);
                    player.Dimension = secreats.exterior_dimension;

                    player.TriggerEvent("screenFadeIn", 200);
                    NAPI.TextLabel.CreateTextLabel("- Metal -~n~~n~Drücke ~y~E~w~ zum sammmeln", new Vector3(-588.7558, 2050.376, 129.9985), 3f, 9f, 0, new Color(255, 255, 255, 100), false, 0);
                    NAPI.TextLabel.CreateTextLabel("- Metal -~n~~n~Drücke ~y~E~w~ zum sammmeln", new Vector3(-520.6819, 1894.66, 122.4449), 3f, 9f, 0, new Color(255, 255, 255, 100), false, 0);
                }, delayTime: 500);
                return;
            }
        }
    }

    [Command("editsecreat")]
    public void CMD_editsecreat(Client player, int secreats_id, string type)
    {
        if (AccountManage.GetPlayerAdmin(player) < adminCommands.COORDENADOR)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben keine Berechtigung, diesen Befehl zu verwenden.");
            return;
        }

        if (secreats_id < 1 && secreats_id > MAX_SECREATS)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Die id darf nicht kleiner als 1 oder größer als sein" + MAX_SECREATS + ".");
            return;
        }

        if (type == "name")
        {
            InteractMenu.User_Input(player, "input_Secreats_name", "Eintragsname bearbeiten", secreats_data[secreats_id].name);
            player.SetData("secreats_id", secreats_id);
        }
        else if (type == "exterior")
        {
     
            NAPI.Notification.SendNotificationToPlayer(player,"Sie haben die Außenposition des ID-Eintrags bearbeitet" + secreats_id + " zu Ihrer aktuellen Position.");
            secreats_data[secreats_id].exterior = player.Position;
            secreats_data[secreats_id].exterior_a = player.Rotation.Z;
            secreats_data[secreats_id].exterior_dimension = player.Dimension;
            secreats_data[secreats_id].label.Position = player.Position;
            secreats_data[secreats_id].marker.Position = player.Position - new Vector3(0,0, 0.8f);

            secreats_data[secreats_id].label.Delete();
            secreats_data[secreats_id].label = NAPI.TextLabel.CreateTextLabel("" + secreats_data[secreats_id].name + "~n~~n~Drücke ~y~E~w~ zum betreten", secreats_data[secreats_id].exterior, 8.0f, 0.6f, 0, new Color(255, 255, 255, 255), false, secreats_data[secreats_id].exterior_dimension);

            SaveSecreats(secreats_id);
        }
        else if (type == "interior")
        {
            NAPI.Notification.SendNotificationToPlayer(player,"Sie haben die Innenposition des ID-Eintrags bearbeitet " + secreats_id + " zu Ihrer aktuellen Position.");



            secreats_data[secreats_id].interior = player.Position;
            secreats_data[secreats_id].interior_a = player.Rotation.Z;
            secreats_data[secreats_id].interior_dimension = player.Dimension;
            secreats_data[secreats_id].label_interior.Position = player.Position;
            secreats_data[secreats_id].marker_interior.Position = player.Position - new Vector3(0, 0, 0.8f);

            secreats_data[secreats_id].label_interior.Delete();
            secreats_data[secreats_id].label_interior = NAPI.TextLabel.CreateTextLabel("- Secreat verlassen -", secreats_data[secreats_id].interior, 8.0f, 0.6f, 0, new Color(255, 255, 255, 255), false, secreats_data[secreats_id].exterior_dimension);

            SaveSecreats(secreats_id);
        }
        else if(type == "delete")
        {
            NAPI.Notification.SendNotificationToPlayer(player,"Sie haben den ID - Eintrag gelöscht. "+ secreats_id + ".");

            secreats_data[secreats_id].name = "";
            secreats_data[secreats_id].exterior = new Vector3(0,0,0);
            secreats_data[secreats_id].interior = new Vector3(0,0,0);
            secreats_data[secreats_id].exterior_dimension = 0;
            secreats_data[secreats_id].interior_dimension = 0;
            secreats_data[secreats_id].exterior_a = 0;
            secreats_data[secreats_id].interior_a = 0;
            secreats_data[secreats_id].label.Position = new Vector3(0, 0, 0);
            secreats_data[secreats_id].label_interior.Position = new Vector3(0, 0, 0);
            secreats_data[secreats_id].marker.Position = new Vector3(0, 0, 0);
            secreats_data[secreats_id].marker_interior.Position = new Vector3(0, 0, 0);
            SaveSecreats(secreats_id);
        }
    }

    public static void OnInputResponse(Client player, String response, String inputtext)
    {
        if(response == "input_Secreats_name")
        {
            secreats_data[player.GetData("secreats_id")].name = inputtext;
            NAPI.Notification.SendNotificationToPlayer(player,"Sie haben den Namen des ID - Eintrags bearbeitet "+ player.GetData("secreats_id") + " zu ~b~"+ inputtext + "~w~.");
            SaveSecreats(player.GetData("secreats_id"));
            secreats_data[player.GetData("secreats_id")].label_interior.Text = "- Secreat verlassen -";
            secreats_data[player.GetData("secreats_id")].label.Text = "" + secreats_data[player.GetData("secreats_id")].name + "~n~~n~Drücke ~y~E~w~ zum betreten";
            player.ResetData("secreats_id");
        }
    }
}

