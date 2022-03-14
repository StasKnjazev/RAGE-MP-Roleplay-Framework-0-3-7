using System;
using System.Collections.Generic;
using GTANetworkAPI;
using MySql.Data.MySqlClient;

class EntraceSystem : Script
{
    public class EntraceEnum : IEquatable<EntraceEnum>
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
            EntraceEnum objAsPart = obj as EntraceEnum;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }
        public override int GetHashCode()
        {
            return id;
        }
        public bool Equals(EntraceEnum other)
        {
            if (other == null) return false;
            return (this.id.Equals(other.id));
        }
    }

    public static List<EntraceEnum> entrace_data = new List<EntraceEnum>();

    public static int MAX_ENTRACE = 0;

    public static void EntraceSystemInit()
    {
        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {
            Mainpipeline.Open();
            MySqlCommand query = new MySqlCommand("SELECT * FROM `entraces`;", Mainpipeline);

            using (MySqlDataReader reader = query.ExecuteReader())
            {
                var index = 0;
                while (reader.Read())
                {
                    entrace_data.Add(new EntraceEnum()
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

                    entrace_data[index].label = NAPI.TextLabel.CreateTextLabel("" + entrace_data[index].name + "~n~~n~Drücke ~y~E~w~ zum eintreten", entrace_data[index].exterior, 8.0f, 0.6f, 0, new Color(255, 255, 255, 255), false, entrace_data[index].exterior_dimension);
                    entrace_data[index].label_interior = NAPI.TextLabel.CreateTextLabel("- Ausgang -", entrace_data[index].interior, 8.0f, 0.6f, 0, new Color(255, 255, 255, 255), false, entrace_data[index].exterior_dimension);

                    entrace_data[index].marker = NAPI.Marker.CreateMarker(27, entrace_data[index].exterior - new Vector3(0, 0, 0.8f), new Vector3(), new Vector3(), 1.0f, new Color(244, 217, 66, 150), false, entrace_data[index].exterior_dimension);
                    entrace_data[index].marker_interior = NAPI.Marker.CreateMarker(27, entrace_data[index].interior - new Vector3(0, 0, 0.8f), new Vector3(), new Vector3(), 1.0f, new Color(244, 217, 66, 150), false, entrace_data[index].interior_dimension);

                    index++;
                    MAX_ENTRACE++;
                }
            }
        }
    }

    public static void SaveEntrace(int index)
    {
        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {
            try
            {
                Mainpipeline.Open();
                string query = "UPDATE `entraces` SET `name` = @name, `exterior_x` = @exterior_x, `exterior_y` = @exterior_y, `exterior_z` = @exterior_z, `exterior_a` = @exterior_a, `interior_x` = @interior_x, `interior_y` = @interior_y, `interior_z` = @interior_z, `interior_a` = @interior_a, `interior_dimension` = @interior_dimension, `exterior_dimension` = @exterior_dimension WHERE `id` = '" + entrace_data[index].id + "'";

                MySqlCommand myCommand = new MySqlCommand(query, Mainpipeline);

                myCommand.Parameters.AddWithValue("@name", "" + entrace_data[index].name + "");
                myCommand.Parameters.AddWithValue("@exterior_x", entrace_data[index].exterior.X);
                myCommand.Parameters.AddWithValue("@exterior_y", entrace_data[index].exterior.Y);
                myCommand.Parameters.AddWithValue("@exterior_z", entrace_data[index].exterior.Z);
                myCommand.Parameters.AddWithValue("@exterior_a", entrace_data[index].exterior_a);
                myCommand.Parameters.AddWithValue("@interior_x", entrace_data[index].interior.X);
                myCommand.Parameters.AddWithValue("@interior_y", entrace_data[index].interior.Y);
                myCommand.Parameters.AddWithValue("@interior_z", entrace_data[index].interior.Z);
                myCommand.Parameters.AddWithValue("@interior_a", entrace_data[index].interior_a);
                myCommand.Parameters.AddWithValue("@interior_dimension", entrace_data[index].interior_dimension);
                myCommand.Parameters.AddWithValue("@exterior_dimension", entrace_data[index].exterior_dimension);
                myCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {
                //NAPI.Util.ConsoleOutput("[EXCEPTION SaveEntrace] " + ex.Message);
                //NAPI.Util.ConsoleOutput("[EXCEPTION SaveEntrace] " + ex.StackTrace);
            }
        }
    }


    public static void PressKeyY(Client player)
    {
        foreach(var entrace in entrace_data)
        {
            if(Main.IsInRangeOfPoint(player.Position, entrace.exterior, 1.0f) && player.Dimension == entrace.exterior_dimension)
            {
                player.TriggerEvent("screenFadeOut", 1000);
                NAPI.Task.Run(() =>
                {
                    player.Position = entrace.interior;
                    player.Rotation = new Vector3(0, 0, entrace.interior_a);
                    player.Dimension = entrace.interior_dimension;

                    player.TriggerEvent("screenFadeIn", 1000);

                }, delayTime: 5500);
                return;
            }
            else if (Main.IsInRangeOfPoint(player.Position, entrace.interior, 1.0f) && player.Dimension == entrace.interior_dimension)
            {
                player.TriggerEvent("screenFadeOut", 1000);
                NAPI.Task.Run(() =>
                {
                    player.Position = entrace.exterior;
                    player.Rotation = new Vector3(0, 0, entrace.exterior_a);
                    player.Dimension = entrace.exterior_dimension;

                    player.TriggerEvent("screenFadeIn", 1000);

                }, delayTime: 5500);
                return;
            }
        }
    }

    [Command("editentrace")]
    public void CMD_editarentrada(Client player, int entrace_id, string type)
    {
        if (AccountManage.GetPlayerAdmin(player) < adminCommands.COORDENADOR)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben keine Berechtigung, diesen Befehl zu verwenden.");
            return;
        }

        if (entrace_id < 1 && entrace_id > MAX_ENTRACE)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Die id darf nicht kleiner als 1 oder größer als sein" + MAX_ENTRACE + ".");
            return;
        }

        if (type == "name")
        {
            InteractMenu.User_Input(player, "input_entrace_name", "Eintragsname bearbeiten", entrace_data[entrace_id].name);
            player.SetData("entrace_id", entrace_id);
        }
        else if (type == "exterior")
        {
     
            NAPI.Notification.SendNotificationToPlayer(player,"Sie haben die Außenposition des ID-Eintrags bearbeitet" + entrace_id + " zu Ihrer aktuellen Position.");
            entrace_data[entrace_id].exterior = player.Position;
            entrace_data[entrace_id].exterior_a = player.Rotation.Z;
            entrace_data[entrace_id].exterior_dimension = player.Dimension;
            entrace_data[entrace_id].label.Position = player.Position;
            entrace_data[entrace_id].marker.Position = player.Position - new Vector3(0,0, 0.8f);

            entrace_data[entrace_id].label.Delete();
            entrace_data[entrace_id].label = NAPI.TextLabel.CreateTextLabel("" + entrace_data[entrace_id].name + "~n~~n~Drücke ~y~E~w~ zum betreten", entrace_data[entrace_id].exterior, 8.0f, 0.6f, 0, new Color(255, 255, 255, 255), false, entrace_data[entrace_id].exterior_dimension);

            SaveEntrace(entrace_id);
        }
        else if (type == "interior")
        {
            NAPI.Notification.SendNotificationToPlayer(player,"Sie haben die Innenposition des ID-Eintrags bearbeitet " + entrace_id + " zu Ihrer aktuellen Position.");

            entrace_data[entrace_id].interior = player.Position;
            entrace_data[entrace_id].interior_a = player.Rotation.Z;
            entrace_data[entrace_id].interior_dimension = player.Dimension;
            entrace_data[entrace_id].label_interior.Position = player.Position;
            entrace_data[entrace_id].marker_interior.Position = player.Position - new Vector3(0, 0, 0.8f);

            entrace_data[entrace_id].label_interior.Delete();
            entrace_data[entrace_id].label_interior = NAPI.TextLabel.CreateTextLabel("- Ausgang -", entrace_data[entrace_id].interior, 8.0f, 0.6f, 0, new Color(255, 255, 255, 255), false, entrace_data[entrace_id].exterior_dimension);

            SaveEntrace(entrace_id);
        }
        else if(type == "delete")
        {
            NAPI.Notification.SendNotificationToPlayer(player,"Sie haben den ID - Eintrag gelöscht. "+ entrace_id + ".");

            entrace_data[entrace_id].name = "";
            entrace_data[entrace_id].exterior = new Vector3(0,0,0);
            entrace_data[entrace_id].interior = new Vector3(0,0,0);
            entrace_data[entrace_id].exterior_dimension = 0;
            entrace_data[entrace_id].interior_dimension = 0;
            entrace_data[entrace_id].exterior_a = 0;
            entrace_data[entrace_id].interior_a = 0;
            entrace_data[entrace_id].label.Position = new Vector3(0, 0, 0);
            entrace_data[entrace_id].label_interior.Position = new Vector3(0, 0, 0);
            entrace_data[entrace_id].marker.Position = new Vector3(0, 0, 0);
            entrace_data[entrace_id].marker_interior.Position = new Vector3(0, 0, 0);
            SaveEntrace(entrace_id);
        }
    }

    public static void OnInputResponse(Client player, String response, String inputtext)
    {
        if(response == "input_entrace_name")
        {
            entrace_data[player.GetData("entrace_id")].name = inputtext;
            NAPI.Notification.SendNotificationToPlayer(player,"Sie haben den Namen des ID - Eintrags bearbeitet "+ player.GetData("entrace_id") + " zu ~b~"+ inputtext + "~w~.");
            SaveEntrace(player.GetData("entrace_id"));
            entrace_data[player.GetData("entrace_id")].label_interior.Text = "- Ausgang -";
            entrace_data[player.GetData("entrace_id")].label.Text = "" + entrace_data[player.GetData("entrace_id")].name + "~n~~n~Drücke ~y~E~w~ zum betreten";
            player.ResetData("entrace_id");
        }
    }
}