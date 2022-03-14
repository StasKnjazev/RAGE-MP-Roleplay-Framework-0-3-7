using GTANetworkAPI;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System;
using System.Threading;
using Newtonsoft.Json;
using DerStr1k3r.Core;
using DerStr1k3r.SDK;
public class Business : Script
{
    public static int MAX_BUSINESS = 100;

    public class BusinessEnum : IEquatable<BusinessEnum>
    {
        public int business_ID { get; set; }
        public string business_Name { get; set; }
        public int business_OwnerID { get; set; }
        public string business_OwnerName { get; set; }
        public int business_Type { get; set; }
        public int business_Price { get; set; }
        public string business_posX { get; set; }
        public string business_posY { get; set; }
        public string business_posZ { get; set; }
        public bool business_Lock { get; set; }
        public int business_Safe { get; set; }
        public int business_Inventory { get; set; }
        public int business_InventoryCapacity { get; set; }

        public int business_OrderState { get; set; }
        public int business_OrderAmount { get; set; }
        public Entity business_objects_blip { get; set; }
        public Entity business_object_MarkerID { get; set; }
        public TextLabel business_object_TextLabel { get; set; }
        public TextLabel business_second_label { get; set; }
        public ColShape business_object_Area { get; set; }

        public ColShape business_marker_area { get; set; }

        public int business_gas_refilling { get; set; }

        /// <summary>
        ///  Business Clothes Store Type Objects
        /// </summary>
        /// 

        public Vector3 business_clothes_shirt { get; set; }
        public float business_clothes_shirt_rotation { get; set; }
        public Entity business_clothes_shirt_marker { get; set; }
        public Entity business_clothes_shirt_label { get; set; }

        public Vector3 business_clothes_legs { get; set; }
        public float business_clothes_legs_rotation { get; set; }
        public Entity business_clothes_legs_marker { get; set; }
        public Entity business_clothes_legs_label { get; set; }

        public Vector3 business_clothes_shoes { get; set; }
        public float business_clothes_shoes_rotation { get; set; }
        public Entity business_clothes_shoes_marker { get; set; }
        public Entity business_clothes_shoes_label { get; set; }

        public Vector3 business_clothes_head { get; set; }
        public float business_clothes_head_rotation { get; set; }
        public Entity business_clothes_head_marker { get; set; }
        public Entity business_clothes_head_label { get; set; }

        public Vector3 business_clothes_fit { get; set; }
        public float business_clothes_fit_rotation { get; set; }
        public Entity business_clothes_fit_marker { get; set; }
        public Entity business_clothes_fit_label { get; set; }

        public Vector3 business_clothes_acessories { get; set; }
        public float business_clothes_acessories_rotation { get; set; }
        public Entity business_clothes_acessories_marker { get; set; }
        public Entity business_clothes_acessories_label { get; set; }

        /// <summary>
        /// Business Car Dealership Type Objects
        /// </summary>
        /// 
        public Vector3 business_dealership_buy { get; set; }
        public float business_dealership_buy_a { get; set; }

        public Entity business_dealership_buy_marker { get; set; }
        public Entity business_dealership_buy_label { get; set; }

        public Vector3 business_dealership_preview { get; set; }
        public float business_dealership_preview_a { get; set; }

        public Vector3 business_dealership_vehicle { get; set; }
        public float business_dealership_vehicle_a { get; set; }

        public float business_store_buy_x { get; set; }
        public float business_store_buy_y { get; set; }
        public float business_store_buy_z { get; set; }
        public float business_store_buy_a { get; set; }

        public Entity business_store_buy_marker { get; set; }
        public Entity business_store_buy_label { get; set; }

        public float business_gasstation_1_x { get; set; }
        public float business_gasstation_1_y { get; set; }
        public float business_gasstation_1_z { get; set; }

        public float business_gasstation_2_x { get; set; }
        public float business_gasstation_2_y { get; set; }
        public float business_gasstation_2_z { get; set; }

        public float business_gasstation_3_x { get; set; }
        public float business_gasstation_3_y { get; set; }
        public float business_gasstation_3_z { get; set; }

        public float business_gasstation_4_x { get; set; }
        public float business_gasstation_4_y { get; set; }
        public float business_gasstation_4_z { get; set; }

        public TextLabel business_manage_label { get; set; }
        public Marker business_manage_marker { get; set; }

        public float business_restock_manage_x { get; set; }
        public float business_restock_manage_y { get; set; }
        public float business_restock_manage_z { get; set; }

        public float business_freetimestore_buy_x { get; set; }
        public float business_freetimestore_buy_y { get; set; }
        public float business_freetimestore_buy_z { get; set; }
        public float business_freetimestore_buy_a { get; set; }

        public float business_juvestore_buy_x { get; set; }
        public float business_juvestore_buy_y { get; set; }
        public float business_juvestore_buy_z { get; set; }
        public float business_juvestore_buy_a { get; set; }

        public float business_phonestore_buy_x { get; set; }
        public float business_phonestore_buy_y { get; set; }
        public float business_phonestore_buy_z { get; set; }
        public float business_phonestore_buy_a { get; set; }

        public Entity business_phonestore_buy_marker { get; set; }
        public Entity business_phonestore_buy_label { get; set; }

        public Entity business_freetimestore_buy_marker { get; set; }
        public Entity business_freetimestore_buy_label { get; set; }

        public Entity business_juvestore_buy_marker { get; set; }
        public Entity business_juvestore_buy_label { get; set; }

        public TextLabel business_restock_manage_label { get; set; }

        /// <summary>
        /// Bomba de Treibstoff
        /// </summary>
        public int business_fuel_price { get; set; }

        public float[] business_pump_sale_price { get; set; } = new float[9];
        public float[] business_pump_sale_galons { get; set; } = new float[9];

        public float[] business_pump_capacity { get; set; } = new float[9];
        public float[] business_pump_galons { get; set; } = new float[9];

        public bool[] business_pump_using { get; set; } = new bool[9];

        public Vector3[] business_pump_position { get; set; } = new Vector3[9];
        public TextLabel[] business_pump_textlabel { get; set; } = new TextLabel[9];
        public TextLabel[] business_pump_textlabel_secundary { get; set; } = new TextLabel[9];
        public TimerEx[] business_pump_timer { get; set; } = new TimerEx[9];
        public Vehicle[] business_pump_vehicle { get; set; } = new Vehicle[9];

        public int[] business_ammunation_price { get; set; } = new int[9];

        public Vector3 ammunation_position { get; set; }

        public Entity ammunation_label { get; set; }
        public Entity ammunation_marker { get; set; }

        public override string ToString()
        {
            return "ID: " + business_ID + "   Name: " + business_Name;
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            BusinessEnum objAsPart = obj as BusinessEnum;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }
        public override int GetHashCode()
        {
            return business_ID;
        }
        public bool Equals(BusinessEnum other)
        {
            if (other == null) return false;
            return (this.business_ID.Equals(other.business_ID));
        }
    }

    public static List<BusinessEnum> business_list = new List<BusinessEnum>();

    public static void BusinessInit()
    {
        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {

            Mainpipeline.Open();
            MySqlCommand query = new MySqlCommand("SELECT * FROM `business` LIMIT " + MAX_BUSINESS + ";", Mainpipeline);
            var index = 0;

            using (MySqlDataReader reader = query.ExecuteReader())
            {
                while (reader.Read())
                {
                    business_list.Add(new BusinessEnum()
                    {
                        business_ID = reader.GetInt32("id"),
                        business_Name = reader.GetString("name"),
                        business_OwnerID = reader.GetInt32("owner_id"),
                        business_OwnerName = reader.GetString("owner_name"),
                        business_Type = reader.GetInt32("type"),
                        business_Price = reader.GetInt32("price"),
                        business_posX = reader.GetString("pos_x"),
                        business_posY = reader.GetString("pos_y"),
                        business_posZ = reader.GetString("pos_z"),
                        business_Lock = Convert.ToBoolean(reader.GetInt32("lock_status")),
                        business_Safe = reader.GetInt32("safe"),
                        business_Inventory = reader.GetInt32("inventory"),
                        business_InventoryCapacity = reader.GetInt32("inventory_capacity"),
                        business_fuel_price = reader.GetInt32("gas_price")
                    });

                    business_list[index].ammunation_position = new Vector3(float.Parse(reader.GetString("ammunation_x")), float.Parse(reader.GetString("ammunation_y")), float.Parse(reader.GetString("ammunation_z")));

                    business_list[index].business_objects_blip = NAPI.Blip.CreateBlip(new Vector3(float.Parse(business_list[index].business_posX), float.Parse(business_list[index].business_posY), float.Parse(business_list[index].business_posZ)));
                    business_list[index].business_object_MarkerID = NAPI.Marker.CreateMarker(27, new Vector3(float.Parse(business_list[index].business_posX), float.Parse(business_list[index].business_posY), float.Parse(business_list[index].business_posZ) - 1.0), new Vector3(), new Vector3(), 0.8f, new Color(255, 255, 255, 155));
                    business_list[index].business_object_TextLabel = NAPI.TextLabel.CreateTextLabel("undefiniert", new Vector3(float.Parse(business_list[index].business_posX), float.Parse(business_list[index].business_posY), float.Parse(business_list[index].business_posZ) + 0.65), 8, 0.400f, 4, new Color(255, 255, 255, 255));
                    business_list[index].business_second_label = NAPI.TextLabel.CreateTextLabel("", new Vector3(float.Parse(business_list[index].business_posX), float.Parse(business_list[index].business_posY), float.Parse(business_list[index].business_posZ) - 0.09), 3, 0.380f, 4, new Color(255, 255, 255, 255));
                    business_list[index].business_object_Area = NAPI.ColShape.CreateSphereColShape(new Vector3(float.Parse(business_list[index].business_posX), float.Parse(business_list[index].business_posY), float.Parse(business_list[index].business_posZ)), 55.0f);


                    business_list[index].ammunation_marker = NAPI.Marker.CreateMarker(27, new Vector3(business_list[index].ammunation_position.X, business_list[index].ammunation_position.Y, business_list[index].ammunation_position.Z - 1.0), new Vector3(), new Vector3(), 0.8f, new Color(255, 255, 255, 155));
                    business_list[index].ammunation_label = NAPI.TextLabel.CreateTextLabel("~b~~h~( Waffenladen )", new Vector3(business_list[index].ammunation_position.X, business_list[index].ammunation_position.Y, business_list[index].ammunation_position.Z + 0.3), 11, 0.600f, 0, new Color(255, 255, 255, 255));

                    for (int pump = 0; pump < 9; pump++)
                    {
                        business_list[index].business_pump_position[pump] = new Vector3(reader.GetFloat("gas_pump_" + pump + "_x"), reader.GetFloat("gas_pump_" + pump + "_y"), reader.GetFloat("gas_pump_" + pump + "_z"));
                        business_list[index].business_pump_capacity[pump] = reader.GetFloat("gas_pump_" + pump + "_capacity");
                        business_list[index].business_pump_galons[pump] = reader.GetFloat("gas_pump_" + pump + "_gas");
                        CreateDynamicPump(index, pump);
                    }

                    for (int ammu = 0; ammu < 9; ammu++)
                    {
                        business_list[index].business_ammunation_price[ammu] = reader.GetInt32("weapon_price_" + ammu);
                    }

                    business_list[index].business_store_buy_x = float.Parse(reader.GetString("business_store_buy_x"));
                    business_list[index].business_store_buy_y = float.Parse(reader.GetString("business_store_buy_y"));
                    business_list[index].business_store_buy_z = float.Parse(reader.GetString("business_store_buy_z"));

                    business_list[index].business_restock_manage_x = float.Parse(reader.GetString("business_restock_x"));
                    business_list[index].business_restock_manage_y = float.Parse(reader.GetString("business_restock_y"));
                    business_list[index].business_restock_manage_z = float.Parse(reader.GetString("business_restock_z"));

                    business_list[index].business_freetimestore_buy_x = float.Parse(reader.GetString("business_freetimestore_buy_x"));
                    business_list[index].business_freetimestore_buy_y = float.Parse(reader.GetString("business_freetimestore_buy_y"));
                    business_list[index].business_freetimestore_buy_z = float.Parse(reader.GetString("business_freetimestore_buy_z"));

                    business_list[index].business_juvestore_buy_x = float.Parse(reader.GetString("business_juvestore_buy_x"));
                    business_list[index].business_juvestore_buy_y = float.Parse(reader.GetString("business_juvestore_buy_y"));
                    business_list[index].business_juvestore_buy_z = float.Parse(reader.GetString("business_juvestore_buy_z"));

                    business_list[index].business_phonestore_buy_x = float.Parse(reader.GetString("business_phonestore_buy_x"));
                    business_list[index].business_phonestore_buy_y = float.Parse(reader.GetString("business_phonestore_buy_y"));
                    business_list[index].business_phonestore_buy_z = float.Parse(reader.GetString("business_phonestore_buy_z"));

                    business_list[index].business_restock_manage_label = NAPI.TextLabel.CreateTextLabel("Lager der Firma", new Vector3(business_list[index].business_restock_manage_x, business_list[index].business_restock_manage_y, business_list[index].business_restock_manage_z + 0.3), 16, 0.600f, 0, new Color(255, 255, 255, 50));

                    business_list[index].business_store_buy_label = NAPI.TextLabel.CreateTextLabel("~g~~h~[ " + business_list[index].business_Name + " (" + index + ") ]", new Vector3(business_list[index].business_store_buy_x, business_list[index].business_store_buy_y, business_list[index].business_store_buy_z + 0.3), 16, 0.600f, 0, new Color(255, 255, 255, 255));
                    business_list[index].business_store_buy_marker = NAPI.Marker.CreateMarker(27, new Vector3(business_list[index].business_store_buy_x, business_list[index].business_store_buy_y, business_list[index].business_store_buy_z - 1.0), new Vector3(), new Vector3(), 0.8f, new Color(255, 255, 255, 155));

                    business_list[index].business_freetimestore_buy_label = NAPI.TextLabel.CreateTextLabel("~g~~h~[ " + business_list[index].business_Name + " (" + index + ") ]", new Vector3(business_list[index].business_freetimestore_buy_x, business_list[index].business_freetimestore_buy_y, business_list[index].business_freetimestore_buy_z + 0.3), 16, 0.600f, 0, new Color(255, 255, 255, 255));
                    business_list[index].business_freetimestore_buy_marker = NAPI.Marker.CreateMarker(27, new Vector3(business_list[index].business_freetimestore_buy_x, business_list[index].business_freetimestore_buy_y, business_list[index].business_freetimestore_buy_z - 1.0), new Vector3(), new Vector3(), 0.8f, new Color(255, 255, 255, 155));

                    business_list[index].business_juvestore_buy_label = NAPI.TextLabel.CreateTextLabel("~g~~h~[ " + business_list[index].business_Name + " (" + index + ") ] ", new Vector3(business_list[index].business_juvestore_buy_x, business_list[index].business_juvestore_buy_y, business_list[index].business_juvestore_buy_z + 0.3), 16, 0.600f, 0, new Color(255, 255, 255, 255));
                    business_list[index].business_juvestore_buy_marker = NAPI.Marker.CreateMarker(27, new Vector3(business_list[index].business_juvestore_buy_x, business_list[index].business_juvestore_buy_y, business_list[index].business_juvestore_buy_z - 1.0), new Vector3(), new Vector3(), 0.8f, new Color(255, 255, 255, 155));

                    business_list[index].business_phonestore_buy_label = NAPI.TextLabel.CreateTextLabel("~g~~h~[ " + business_list[index].business_Name + " (" + index + ") ] ", new Vector3(business_list[index].business_phonestore_buy_x, business_list[index].business_phonestore_buy_y, business_list[index].business_phonestore_buy_z + 0.3), 16, 0.600f, 0, new Color(255, 255, 255, 255));
                    business_list[index].business_phonestore_buy_marker = NAPI.Marker.CreateMarker(27, new Vector3(business_list[index].business_phonestore_buy_x, business_list[index].business_phonestore_buy_y, business_list[index].business_phonestore_buy_z - 1.0), new Vector3(), new Vector3(), 0.8f, new Color(255, 255, 255, 155));

                    UpdateBusinessBlip(index);
                    UpdateBusinessLabel(index);
                    LoadBusinessClothes(index);
                    LoadBusinesDealership(index);
                    index++;
                }
            }
        }
    }


    public static void LoadBusinessClothes(int index)
    {
        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {
            Mainpipeline.Open();
            MySqlCommand query = new MySqlCommand("SELECT * FROM `business_type_clothes_points` WHERE `id` = " + index + " LIMIT 1;", Mainpipeline);
            using (MySqlDataReader reader = query.ExecuteReader())
            {
                while (reader.Read())
                {
                    string[] temp_mysql_data = reader.GetString("shirt_positions").ToString().Split('|');
                    business_list[index].business_clothes_shirt = new Vector3(Convert.ToSingle(temp_mysql_data[0]), Convert.ToSingle(temp_mysql_data[1]), Convert.ToSingle(temp_mysql_data[2]));
                    business_list[index].business_clothes_shirt_rotation = Convert.ToSingle(temp_mysql_data[3]);

                    temp_mysql_data = reader.GetString("legs_positions").ToString().Split('|');
                    business_list[index].business_clothes_legs = new Vector3(Convert.ToSingle(temp_mysql_data[0]), Convert.ToSingle(temp_mysql_data[1]), Convert.ToSingle(temp_mysql_data[2]));
                    business_list[index].business_clothes_legs_rotation = Convert.ToSingle(temp_mysql_data[3]);

                    temp_mysql_data = reader.GetString("shoes_positions").ToString().Split('|');
                    business_list[index].business_clothes_shoes = new Vector3(Convert.ToSingle(temp_mysql_data[0]), Convert.ToSingle(temp_mysql_data[1]), Convert.ToSingle(temp_mysql_data[2]));
                    business_list[index].business_clothes_shoes_rotation = Convert.ToSingle(temp_mysql_data[3]);

                    temp_mysql_data = reader.GetString("head_positions").ToString().Split('|');
                    business_list[index].business_clothes_head = new Vector3(Convert.ToSingle(temp_mysql_data[0]), Convert.ToSingle(temp_mysql_data[1]), Convert.ToSingle(temp_mysql_data[2]));
                    business_list[index].business_clothes_head_rotation = Convert.ToSingle(temp_mysql_data[3]);

                    temp_mysql_data = reader.GetString("fit_positions").ToString().Split('|');
                    business_list[index].business_clothes_fit = new Vector3(Convert.ToSingle(temp_mysql_data[0]), Convert.ToSingle(temp_mysql_data[1]), Convert.ToSingle(temp_mysql_data[2]));
                    business_list[index].business_clothes_fit_rotation = Convert.ToSingle(temp_mysql_data[3]);

                    temp_mysql_data = reader.GetString("acessories_positions").ToString().Split('|');
                    business_list[index].business_clothes_acessories = new Vector3(Convert.ToSingle(temp_mysql_data[0]), Convert.ToSingle(temp_mysql_data[1]), Convert.ToSingle(temp_mysql_data[2]));
                    business_list[index].business_clothes_acessories_rotation = Convert.ToSingle(temp_mysql_data[3]);

                    business_list[index].business_clothes_shirt_marker = NAPI.Marker.CreateMarker(27, business_list[index].business_clothes_shirt - new Vector3(0, 0, 0.8), new Vector3(), new Vector3(), 0.8f, new Color(255, 255, 255, 155));
                    business_list[index].business_clothes_shirt_label = NAPI.TextLabel.CreateTextLabel("~y~-~w~ Bekleidungsladen ", business_list[index].business_clothes_shirt + new Vector3(0, 0, 0.3), 11, 1.0f, 0, new Color(255, 255, 255, 255));

                    business_list[index].business_clothes_acessories_marker = NAPI.Marker.CreateMarker(27, business_list[index].business_clothes_acessories - new Vector3(0, 0, 0.8), new Vector3(), new Vector3(), 0.8f, new Color(255, 255, 255, 155));
                    business_list[index].business_clothes_acessories_label = NAPI.TextLabel.CreateTextLabel("~y~-~w~ Tattoo Studio ", business_list[index].business_clothes_acessories + new Vector3(0, 0, 0.3), 11, 1.0f, 0, new Color(255, 255, 255, 255));

                    business_list[index].business_clothes_legs_marker = NAPI.Marker.CreateMarker(27, business_list[index].business_clothes_legs - new Vector3(0, 0, 0.8), new Vector3(), new Vector3(), 0.8f, new Color(255, 255, 255, 155));
                    business_list[index].business_clothes_legs_label = NAPI.TextLabel.CreateTextLabel("~y~-~w~ Friseurladen ", business_list[index].business_clothes_legs + new Vector3(0, 0, 0.3), 11, 1.0f, 0, new Color(255, 255, 255, 255));
                }
            }
        }
    }

    public static void LoadBusinesDealership(int index)
    {
        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {
            Mainpipeline.Open();
            MySqlCommand query = new MySqlCommand("SELECT * FROM `business_type_dealership_points` WHERE `id` = " + index + " LIMIT 1;", Mainpipeline);
            using (MySqlDataReader reader = query.ExecuteReader())
            {
                while (reader.Read())
                {
                    string[] temp_mysql_data = reader.GetString("buy").ToString().Split('|');
                    business_list[index].business_dealership_buy = new Vector3(Convert.ToSingle(temp_mysql_data[0]), Convert.ToSingle(temp_mysql_data[1]), Convert.ToSingle(temp_mysql_data[2]));
                    business_list[index].business_dealership_buy_a = Convert.ToSingle(temp_mysql_data[3]);

                    temp_mysql_data = reader.GetString("preview").ToString().Split('|');
                    business_list[index].business_dealership_preview = new Vector3(Convert.ToSingle(temp_mysql_data[0]), Convert.ToSingle(temp_mysql_data[1]), Convert.ToSingle(temp_mysql_data[2]));
                    business_list[index].business_dealership_preview_a = Convert.ToSingle(temp_mysql_data[3]);

                    temp_mysql_data = reader.GetString("vehicle").ToString().Split('|');
                    business_list[index].business_dealership_vehicle = new Vector3(Convert.ToSingle(temp_mysql_data[0]), Convert.ToSingle(temp_mysql_data[1]), Convert.ToSingle(temp_mysql_data[2]));
                    business_list[index].business_dealership_vehicle_a = Convert.ToSingle(temp_mysql_data[3]);

                    business_list[index].business_dealership_buy_label = NAPI.TextLabel.CreateTextLabel("~g~~h~[ " + business_list[index].business_Name + " ] ", business_list[index].business_dealership_buy + new Vector3(0, 0, 0.3), 16, 0.600f, 0, new Color(255, 255, 255, 255));
                    business_list[index].business_dealership_buy_marker = NAPI.Marker.CreateMarker(27, business_list[index].business_dealership_buy - new Vector3(0, 0, 1.0), new Vector3(), new Vector3(), 0.8f, new Color(255, 255, 255, 155));
                }
            }
        }
    }

    public static void SaveBusiness(int index)
    {
        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {
            Mainpipeline.Open();
            try
            {
                string query = "UPDATE business SET name = @name, owner_id = @owner_id, owner_name = @owner_name, type = @type, price = @price, pos_x = @pos_x, pos_y = @pos_y, pos_z = @pos_z, safe = @safe, inventory = @inventory, inventory_capacity = @inventory_capacity, lock_status = @lock_status,";
                query = query + "ammunation_x = @ammunation_x, ammunation_y = @ammunation_y, ammunation_z = @ammunation_z, ";
                query = query + "business_store_buy_x = @business_store_buy_x, business_store_buy_y = @business_store_buy_y, business_store_buy_z = @business_store_buy_z, gas_price = @gas_price, business_restock_x = @business_restock_x, business_restock_y = @business_restock_y, business_restock_z = @business_restock_z, business_freetimestore_buy_x = @business_freetimestore_buy_x, business_freetimestore_buy_y = @business_freetimestore_buy_y, business_freetimestore_buy_z = @business_freetimestore_buy_z, business_juvestore_buy_x = @business_juvestore_buy_x, business_juvestore_buy_y = @business_juvestore_buy_y, business_juvestore_buy_z = @business_juvestore_buy_z, business_phonestore_buy_x = @business_phonestore_buy_x, business_phonestore_buy_y = @business_phonestore_buy_y, business_phonestore_buy_z = @business_phonestore_buy_z, ";
                for (int weapon = 0; weapon < 9; weapon++)
                {
                    query = query + "weapon_price_" + weapon + " = @weapon_price_" + weapon + ", ";
                }
                for (int pump = 0; pump < 9; pump++)
                {
                    query = query + "gas_pump_" + pump + "_x = @gas_pump_" + pump + "_x, ";
                    query = query + "gas_pump_" + pump + "_y = @gas_pump_" + pump + "_y, ";
                    query = query + "gas_pump_" + pump + "_z = @gas_pump_" + pump + "_z, ";
                    query = query + "gas_pump_" + pump + "_capacity = @gas_pump_" + pump + "_capacity, ";
                    if (pump == 8) query = query + "gas_pump_" + pump + "_gas = @gas_pump_" + pump + "_gas ";
                    else query = query + "gas_pump_" + pump + "_gas = @gas_pump_" + pump + "_gas, ";
                }
                query = query + " WHERE `id` = '" + business_list[index].business_ID + "'";
                //NAPI.Util.ConsoleOutput(query);

                MySqlCommand myCommand = new MySqlCommand(query, Mainpipeline);

                for (int weapon = 0; weapon < 9; weapon++)
                {

                    myCommand.Parameters.AddWithValue("@weapon_price_" + weapon + "", business_list[index].business_ammunation_price[weapon]);

                }

                for (int pump = 0; pump < 9; pump++)
                {
                    myCommand.Parameters.AddWithValue("@gas_pump_" + pump + "_x", "" + business_list[index].business_pump_position[pump].X + "");
                    myCommand.Parameters.AddWithValue("@gas_pump_" + pump + "_y", "" + business_list[index].business_pump_position[pump].Y + "");
                    myCommand.Parameters.AddWithValue("@gas_pump_" + pump + "_z", "" + business_list[index].business_pump_position[pump].Z + "");
                    myCommand.Parameters.AddWithValue("@gas_pump_" + pump + "_capacity", "" + business_list[index].business_pump_capacity[pump] + "");
                    myCommand.Parameters.AddWithValue("@gas_pump_" + pump + "_gas", "" + business_list[index].business_pump_galons[pump] + "");
                }

                myCommand.Parameters.AddWithValue("@ammunation_x", "" + business_list[index].ammunation_position.X + "");
                myCommand.Parameters.AddWithValue("@ammunation_y", "" + business_list[index].ammunation_position.Y + "");
                myCommand.Parameters.AddWithValue("@ammunation_z", "" + business_list[index].ammunation_position.Z + "");

                myCommand.Parameters.AddWithValue("@gas_price", business_list[index].business_fuel_price);

                myCommand.Parameters.AddWithValue("@name", business_list[index].business_Name);
                myCommand.Parameters.AddWithValue("@owner_id", business_list[index].business_OwnerID);
                myCommand.Parameters.AddWithValue("@owner_name", business_list[index].business_OwnerName);
                myCommand.Parameters.AddWithValue("@type", business_list[index].business_Type);
                myCommand.Parameters.AddWithValue("@price", business_list[index].business_Price);
                myCommand.Parameters.AddWithValue("@pos_x", "" + business_list[index].business_posX + "");
                myCommand.Parameters.AddWithValue("@pos_y", "" + business_list[index].business_posY + "");
                myCommand.Parameters.AddWithValue("@pos_z", "" + business_list[index].business_posZ + "");
                myCommand.Parameters.AddWithValue("@safe", business_list[index].business_Safe);
                myCommand.Parameters.AddWithValue("@inventory", business_list[index].business_Inventory);
                myCommand.Parameters.AddWithValue("@inventory_capacity", business_list[index].business_InventoryCapacity);
                myCommand.Parameters.AddWithValue("@lock_status", business_list[index].business_Lock);

                myCommand.Parameters.AddWithValue("@business_store_buy_x", "" + business_list[index].business_store_buy_x + "");
                myCommand.Parameters.AddWithValue("@business_store_buy_y", "" + business_list[index].business_store_buy_y + "");
                myCommand.Parameters.AddWithValue("@business_store_buy_z", "" + business_list[index].business_store_buy_z + "");

                myCommand.Parameters.AddWithValue("@business_freetimestore_buy_x", "" + business_list[index].business_freetimestore_buy_x + "");
                myCommand.Parameters.AddWithValue("@business_freetimestore_buy_y", "" + business_list[index].business_freetimestore_buy_y + "");
                myCommand.Parameters.AddWithValue("@business_freetimestore_buy_z", "" + business_list[index].business_freetimestore_buy_z + "");

                myCommand.Parameters.AddWithValue("@business_juvestore_buy_x", "" + business_list[index].business_juvestore_buy_x + "");
                myCommand.Parameters.AddWithValue("@business_juvestore_buy_y", "" + business_list[index].business_juvestore_buy_y + "");
                myCommand.Parameters.AddWithValue("@business_juvestore_buy_z", "" + business_list[index].business_juvestore_buy_z + "");

                myCommand.Parameters.AddWithValue("@business_phonestore_buy_x", "" + business_list[index].business_phonestore_buy_x + "");
                myCommand.Parameters.AddWithValue("@business_phonestore_buy_y", "" + business_list[index].business_phonestore_buy_y + "");
                myCommand.Parameters.AddWithValue("@business_phonestore_buy_z", "" + business_list[index].business_phonestore_buy_z + "");

                myCommand.Parameters.AddWithValue("@business_restock_x", "" + business_list[index].business_restock_manage_x + "");
                myCommand.Parameters.AddWithValue("@business_restock_y", "" + business_list[index].business_restock_manage_y + "");
                myCommand.Parameters.AddWithValue("@business_restock_z", "" + business_list[index].business_restock_manage_z + "");

                myCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
        }
    }


    public static void SaveBusinessClothes(int index)
    {
        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {
            Mainpipeline.Open();
            try
            {
                string query = "UPDATE business_type_clothes_points SET shirt_positions = @shirt_positions, legs_positions = @legs_positions, shoes_positions = @shoes_positions, head_positions = @head_positions, fit_positions = @fit_positions, acessories_positions = @acessories_positions WHERE `id` = '" + business_list[index].business_ID + "'";
                MySqlCommand myCommand = new MySqlCommand(query, Mainpipeline);

                string shirt = business_list[index].business_clothes_shirt.X + "|" + business_list[index].business_clothes_shirt.Y + "|" + business_list[index].business_clothes_shirt.Z + "|" + business_list[index].business_clothes_shirt_rotation;
                string shoes = business_list[index].business_clothes_shoes.X + "|" + business_list[index].business_clothes_shoes.Y + "|" + business_list[index].business_clothes_shoes.Z + "|" + business_list[index].business_clothes_shoes_rotation;
                string legs = business_list[index].business_clothes_legs.X + "|" + business_list[index].business_clothes_legs.Y + "|" + business_list[index].business_clothes_legs.Z + "|" + business_list[index].business_clothes_legs_rotation;
                string fit = business_list[index].business_clothes_fit.X + "|" + business_list[index].business_clothes_fit.Y + "|" + business_list[index].business_clothes_fit.Z + "|" + business_list[index].business_clothes_fit_rotation;
                string head = business_list[index].business_clothes_head.X + "|" + business_list[index].business_clothes_head.Y + "|" + business_list[index].business_clothes_head.Z + "|" + business_list[index].business_clothes_head_rotation;
                string acessories = business_list[index].business_clothes_acessories.X + "|" + business_list[index].business_clothes_acessories.Y + "|" + business_list[index].business_clothes_acessories.Z + "|" + business_list[index].business_clothes_acessories_rotation;

                myCommand.Parameters.AddWithValue("@shirt_positions", "" + shirt + "");
                myCommand.Parameters.AddWithValue("@legs_positions", "" + legs + "");
                myCommand.Parameters.AddWithValue("@shoes_positions", "" + shoes + "");
                myCommand.Parameters.AddWithValue("@head_positions", "" + head + "");
                myCommand.Parameters.AddWithValue("@fit_positions", "" + fit + "");
                myCommand.Parameters.AddWithValue("@acessories_positions", "" + acessories + "");

                myCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
        }
    }

    public static void SaveBusinessDealership(int index)
    {
        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {
            Mainpipeline.Open();
            try
            {
                string query = "UPDATE business_type_dealership_points SET buy = @buy, preview = @preview, vehicle = @vehicle WHERE `id` = '" + business_list[index].business_ID + "'";
                MySqlCommand myCommand = new MySqlCommand(query, Mainpipeline);

                string buy = business_list[index].business_dealership_buy.X + "|" + business_list[index].business_dealership_buy.Y + "|" + business_list[index].business_dealership_buy.Z + "|" + business_list[index].business_dealership_buy_a;
                string preview = business_list[index].business_dealership_preview.X + "|" + business_list[index].business_dealership_preview.Y + "|" + business_list[index].business_dealership_preview.Z + "|" + business_list[index].business_dealership_preview_a;
                string vehicle = business_list[index].business_dealership_vehicle.X + "|" + business_list[index].business_dealership_vehicle.Y + "|" + business_list[index].business_dealership_vehicle.Z + "|" + business_list[index].business_dealership_vehicle_a;

                myCommand.Parameters.AddWithValue("@buy", "" + buy + "");
                myCommand.Parameters.AddWithValue("@preview", "" + preview + "");
                myCommand.Parameters.AddWithValue("@vehicle", "" + vehicle + "");

                myCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
        }
    }

    public static void SaveBusinessStoreItem(int business_id)
    {

        //Main.CreateMySqlCommand();
    }

    public static void UpdateBusinessLabel(int business_id)
    {
        string
            door_status,
            stock_status,
            business_name = business_list[business_id].business_Name
        ;

        if (business_list[business_id].business_Lock == true)
        {
            door_status = "Geschlossen~w~";
        }
        else
        {
            door_status = "~g~Offen~w~";
        }


        if (business_list[business_id].business_Inventory <= 0)
        {
            stock_status = "Wir haben keine Ware mehr, kommen Sie später zurück.!~w~";
        }
        else stock_status = "";

        if (business_list[business_id].business_OwnerID == -1)
        {

            NAPI.TextLabel.SetTextLabelText(business_list[business_id].business_object_TextLabel, "~y~Firma zum Verkauf~n~~n~~w~Name: ~y~" + business_name + "~n~~w~Preis: ~g~$" + business_list[business_id].business_Price.ToString("N0") + "");
            //business_list[business_id].business_second_label.Text = "Esta empresa esta ha venda!!~n~Preco: ~g~$~w~" + business_list[business_id].business_Price.ToString("N0") + "~n~~n~~y~/comprarempresa~w~~n~~n~ID: " + business_id + "";
        }
        else
        {
            NAPI.TextLabel.SetTextLabelText(business_list[business_id].business_object_TextLabel, "~y~Firma~n~~n~~w~" + business_name + "~n~~w~Besitzer: ~y~" + AccountManage.Format_Name(business_list[business_id].business_OwnerName) + "~n~" + door_status + "");
            //business_list[business_id].business_second_label.Text = "ID: " + business_id + "";
        }
    }

    public static void UpdateBusinessBlip(int business_id)
    {
        if (business_list[business_id].business_Type == 1)
        {
            NAPI.Blip.SetBlipName(business_list[business_id].business_objects_blip, "Bekleidungsladen");
            NAPI.Blip.SetBlipSprite(business_list[business_id].business_objects_blip, 73);
            NAPI.Blip.SetBlipShortRange(business_list[business_id].business_objects_blip, true);
            NAPI.Blip.SetBlipScale(business_list[business_id].business_objects_blip, 0.75f);
        }
        else if (business_list[business_id].business_Type == 2)
        {
            NAPI.Blip.SetBlipName(business_list[business_id].business_objects_blip, "24-7");
            NAPI.Blip.SetBlipSprite(business_list[business_id].business_objects_blip, 52);
            NAPI.Blip.SetBlipShortRange(business_list[business_id].business_objects_blip, true);
            NAPI.Blip.SetBlipScale(business_list[business_id].business_objects_blip, 0.75f);
        }
        else if (business_list[business_id].business_Type == 3)
        {
            NAPI.Blip.SetBlipName(business_list[business_id].business_objects_blip, "Waffenladen");
            NAPI.Blip.SetBlipSprite(business_list[business_id].business_objects_blip, 110);
            NAPI.Blip.SetBlipShortRange(business_list[business_id].business_objects_blip, true);
            NAPI.Blip.SetBlipScale(business_list[business_id].business_objects_blip, 0.75f);
        }
        else if (business_list[business_id].business_Type == 4)
        {
            NAPI.Blip.SetBlipName(business_list[business_id].business_objects_blip, "Autohandel");
            NAPI.Blip.SetBlipSprite(business_list[business_id].business_objects_blip, 380);
            NAPI.Blip.SetBlipShortRange(business_list[business_id].business_objects_blip, true);
            NAPI.Blip.SetBlipColor(business_list[business_id].business_objects_blip, 38);
        }
        else if (business_list[business_id].business_Type == 5)
        {
            NAPI.Blip.SetBlipName(business_list[business_id].business_objects_blip, "Tankstelle");
            NAPI.Blip.SetBlipSprite(business_list[business_id].business_objects_blip, 361);
            NAPI.Blip.SetBlipShortRange(business_list[business_id].business_objects_blip, true);
            NAPI.Blip.SetBlipColor(business_list[business_id].business_objects_blip, 59);
            NAPI.Blip.SetBlipScale(business_list[business_id].business_objects_blip, 0.75f);
        }
        else if (business_list[business_id].business_Type == 6)
        {
            NAPI.Blip.SetBlipName(business_list[business_id].business_objects_blip, "Motorradhandel");
            NAPI.Blip.SetBlipSprite(business_list[business_id].business_objects_blip, 522);
            NAPI.Blip.SetBlipShortRange(business_list[business_id].business_objects_blip, true);
            NAPI.Blip.SetBlipScale(business_list[business_id].business_objects_blip, 0.75f);
            NAPI.Blip.SetBlipColor(business_list[business_id].business_objects_blip, 38);
        }
        else if (business_list[business_id].business_Type == 7)
        {
            NAPI.Blip.SetBlipName(business_list[business_id].business_objects_blip, "Bootshandel");
            NAPI.Blip.SetBlipSprite(business_list[business_id].business_objects_blip, 455);
            NAPI.Blip.SetBlipShortRange(business_list[business_id].business_objects_blip, true);
            NAPI.Blip.SetBlipScale(business_list[business_id].business_objects_blip, 0.75f);
            NAPI.Blip.SetBlipColor(business_list[business_id].business_objects_blip, 38);
        }
        else if (business_list[business_id].business_Type == 8)
        {
            NAPI.Blip.SetBlipName(business_list[business_id].business_objects_blip, "Helikopterhandel");
            NAPI.Blip.SetBlipSprite(business_list[business_id].business_objects_blip, 43);
            NAPI.Blip.SetBlipShortRange(business_list[business_id].business_objects_blip, true);
            NAPI.Blip.SetBlipScale(business_list[business_id].business_objects_blip, 0.75f);
            NAPI.Blip.SetBlipColor(business_list[business_id].business_objects_blip, 38);
        }
        else if (business_list[business_id].business_Type == 9)
        {
            NAPI.Blip.SetBlipName(business_list[business_id].business_objects_blip, "LKW Handel");
            NAPI.Blip.SetBlipSprite(business_list[business_id].business_objects_blip, 477);
            NAPI.Blip.SetBlipShortRange(business_list[business_id].business_objects_blip, true);
            NAPI.Blip.SetBlipScale(business_list[business_id].business_objects_blip, 0.75f);
            NAPI.Blip.SetBlipColor(business_list[business_id].business_objects_blip, 38);
        }
        else if (business_list[business_id].business_Type == 10)
        {
            NAPI.Blip.SetBlipName(business_list[business_id].business_objects_blip, "Friseurladen");
            NAPI.Blip.SetBlipSprite(business_list[business_id].business_objects_blip, 71);
            NAPI.Blip.SetBlipShortRange(business_list[business_id].business_objects_blip, true);
            NAPI.Blip.SetBlipScale(business_list[business_id].business_objects_blip, 0.75f);
            NAPI.Blip.SetBlipColor(business_list[business_id].business_objects_blip, 38);
        }
        else if (business_list[business_id].business_Type == 11)
        {
            NAPI.Blip.SetBlipName(business_list[business_id].business_objects_blip, "Freizeitladen");
            NAPI.Blip.SetBlipSprite(business_list[business_id].business_objects_blip, 614);
            NAPI.Blip.SetBlipShortRange(business_list[business_id].business_objects_blip, true);
            NAPI.Blip.SetBlipScale(business_list[business_id].business_objects_blip, 0.75f);
            NAPI.Blip.SetBlipColor(business_list[business_id].business_objects_blip, 70);
        }
        else if (business_list[business_id].business_Type == 12)
        {
            NAPI.Blip.SetBlipName(business_list[business_id].business_objects_blip, "Juvelier");
            NAPI.Blip.SetBlipSprite(business_list[business_id].business_objects_blip, 617);
            NAPI.Blip.SetBlipShortRange(business_list[business_id].business_objects_blip, true);
            NAPI.Blip.SetBlipScale(business_list[business_id].business_objects_blip, 0.75f);
            NAPI.Blip.SetBlipColor(business_list[business_id].business_objects_blip, 70);
        }
        else if (business_list[business_id].business_Type == 13)
        {
            NAPI.Blip.SetBlipName(business_list[business_id].business_objects_blip, "IDNet");
            NAPI.Blip.SetBlipSprite(business_list[business_id].business_objects_blip, 485);
            NAPI.Blip.SetBlipShortRange(business_list[business_id].business_objects_blip, true);
            NAPI.Blip.SetBlipScale(business_list[business_id].business_objects_blip, 0.75f);
            NAPI.Blip.SetBlipColor(business_list[business_id].business_objects_blip, 36);
        }
        else if (business_list[business_id].business_Type == 14)
        {
            NAPI.Blip.SetBlipName(business_list[business_id].business_objects_blip, "Tattoo Studio");
            NAPI.Blip.SetBlipSprite(business_list[business_id].business_objects_blip, 75);
            NAPI.Blip.SetBlipShortRange(business_list[business_id].business_objects_blip, true);
            NAPI.Blip.SetBlipScale(business_list[business_id].business_objects_blip, 0.75f);
            NAPI.Blip.SetBlipColor(business_list[business_id].business_objects_blip, 36);
        }
        else
        {
            NAPI.Blip.SetBlipTransparency(business_list[business_id].business_objects_blip, 0);
        }
    }

    public static int GetPlayerInBusiness(Client player)
    {
        return NAPI.Data.GetEntityData(player, "player_in_business");
    }

    public static int GetPlayerInBusinessEx(Client player)
    {
        int index = 0;
        float range = 50f;
        foreach (var business in business_list)
        {
            Vector3 target = new Vector3(float.Parse(business_list[index].business_posX), float.Parse(business_list[index].business_posY), float.Parse(business_list[index].business_posZ));

            switch (business.business_Type)
            {
                case 1: range = 30f; break;
                case 2: range = 30f; break;
                case 3: range = 30f; break;
                case 4: range = 75f; break;
                case 5: range = 80f; break;
            }

            if (Main.IsInRangeOfPoint(player.Position, target, range))
            {
                return index;
            }
            index++;
        }
        return -1;
    }

    public static int GetPlayerInBusinessInType(Client player, int type)
    {
        int index = 0;
        float range = 750f;
        foreach (var business in business_list)
        {
            Vector3 target = new Vector3(float.Parse(business_list[index].business_posX), float.Parse(business_list[index].business_posY), float.Parse(business_list[index].business_posZ));

            switch (business.business_Type)
            {
                case 1: range = 50f; break;
                case 2: range = 50f; break;
                case 3: range = 50f; break;
                case 4: range = 75f; break;
                case 5: range = 80f; break;
            }

            if (Main.IsInRangeOfPoint(player.Position, target, range) && business.business_Type == type)
            {
                return index;
            }
            index++;
        }
        return -1;
    }

    public static int GetPlayerInBusinessInDealership(Client player)
    {
        int index = 0;
        foreach (var business in business_list)
        {
            Vector3 target = new Vector3(float.Parse(business_list[index].business_posX), float.Parse(business_list[index].business_posY), float.Parse(business_list[index].business_posZ));

            if (Main.IsInRangeOfPoint(player.Position, target, 75f) && (business.business_Type == 4 || business.business_Type == 6 || business.business_Type == 7 || business.business_Type == 8 || business.business_Type == 9))
            {
                return index;
            }
            index++;
        }
        return -1;
    }

    public static int GetPlayerInBusinessOwnerEx(Client player, int type)
    {
        int index = 0;
        float range = 750f;
        foreach (var business in business_list)
        {
            Vector3 target = new Vector3(float.Parse(business_list[index].business_posX), float.Parse(business_list[index].business_posY), float.Parse(business_list[index].business_posZ));

            switch (business.business_Type)
            {
                case 1: range = 50f; break;
                case 2: range = 50f; break;
                case 3: range = 50f; break;
                case 4: range = 75f; break;
                case 5: range = 80f; break;
            }

            if (Main.IsInRangeOfPoint(player.Position, target, range) && business.business_Type == type)
            {
                if (business.business_OwnerID == AccountManage.GetPlayerSQLID(player))
                {
                    return index;
                }
            }
            index++;
        }
        return -1;
    }

    public static int GetPlayerInBusinessOwner(Client player)
    {
        int index = 0;
        foreach (var business in business_list)
        {
            if (Main.IsInRangeOfPoint(player.Position, business.business_object_MarkerID.Position, 20.0f))
            {
                if (business.business_OwnerID == AccountManage.GetPlayerSQLID(player))
                {
                    return index;
                }
            }
            index++;
        }
        return -1;
    }

    public static void DestroyDynamicPump(int index, int pump)
    {
        business_list[index].business_pump_textlabel[pump].Delete();
        business_list[index].business_pump_textlabel_secundary[pump].Delete();
    }

    public static void CreateDynamicPump(int index, int pump)
    {
        string text = "~y~Zapfhahn~w~\nID: " + pump + "  (" + index + ")\nBenutze ~y~O~w~ im Fahrzeug.";
        string label = "~s~Preis pro Liter: $" + business_list[index].business_fuel_price + "\nDieser Verkauf: $" + business_list[index].business_pump_sale_price[pump].ToString("0") + "\nLiter: " + business_list[index].business_pump_sale_galons[pump].ToString("C2").Replace("$", "") + "";
        business_list[index].business_pump_textlabel[pump] = NAPI.TextLabel.CreateTextLabel(label, business_list[index].business_pump_position[pump] - new Vector3(0, 0, 1.45f), 8, 0.580f, 4, new Color(255, 255, 255, 255));
        business_list[index].business_pump_textlabel_secundary[pump] = NAPI.TextLabel.CreateTextLabel(text, business_list[index].business_pump_position[pump] - new Vector3(0, 0, 2.45f), 8, 0.580f, 4, new Color(255, 255, 255, 255));
    }

    public static string Business_Type(int business_type)
    {
        string type = "undefiniert";
        switch (business_type)
        {
            case 1:
                {
                    type = "Bekleidungsladen";
                    break;
                }
            case 2:
                {
                    type = "24/7";
                    break;
                }
            case 3:
                {
                    type = "Waffenladen";
                    break;
                }
            case 4:
                {
                    type = "Autohandel";
                    break;
                }
            case 5:
                {
                    type = "Tankstelle";
                    break;
                }
            case 6:
                {
                    type = "Motorradhandel";
                    break;
                }
            case 7:
                {
                    type = "Bootshandel";
                    break;
                }
            case 8:
                {
                    type = "Helikopterhandel";
                    break;
                }
            case 9:
                {
                    type = "LKW Handel";
                    break;
                }
            case 10:
                {
                    type = "Friseurladen";
                    break;
                }
            case 11:
                {
                    type = "Freizeitladen";
                    break;
                }
            case 12:
                {
                    type = "Juvelier";
                    break;
                }
            case 13:
                {
                    type = "IDNet";
                    break;
                }
            case 14:
                {
                    type = "Tattoo Studio";
                    break;
                }
            default:
                {
                    type = "undefiniert";
                    break;
                }
        }
        return type;
    }

    public static int GetPlayerBusinessKey(Client player)
    {
        return player.GetData("character_business_key");
    }

    public static void DisplayEditBusinessMenu(Client player, int empresaid)
    {
        List<string> list = new List<string>();

        list.Add("undefiniert");
        list.Add("Bekleidungsladen");
        list.Add("24/7");
        list.Add("Waffenladen");
        list.Add("Autohandel");
        list.Add("Tankstelle");
        list.Add("Motorradhandel");
        list.Add("Bootshandel");
        list.Add("Helikopterhandel");
        list.Add("LKW Handel");
        list.Add("Friseurladen");
        list.Add("Freizeitladen");
        list.Add("Juvelier");
        list.Add("IDNet");
        list.Add("Tattoo Studio");

        List<dynamic> menu_item_list = new List<dynamic>();
        menu_item_list.Add(new { Type = 1, Name = "Name", Description = "", RightLabel = "~c~" + business_list[empresaid].business_Name });
        menu_item_list.Add(new { Type = 6, Name = "Typ", Description = "Firmentyp ändern. ACHTUNG!:~y~Einstellung wird direkt übernommen.", List = list, StartIndex = business_list[empresaid].business_Type });
        menu_item_list.Add(new { Type = 1, Name = "Kaufpreis", Description = "", RightLabel = "~c~" + business_list[empresaid].business_Price });
        menu_item_list.Add(new { Type = 1, Name = "Bestand", Description = "", RightLabel = "~c~" + business_list[empresaid].business_Inventory });
        menu_item_list.Add(new { Type = 1, Name = "Lagergröße", Description = "", RightLabel = "~c~" + business_list[empresaid].business_InventoryCapacity });
        menu_item_list.Add(new { Type = 1, Name = "Verkäufer", Description = "Für Geschäft setzen." });
        menu_item_list.Add(new { Type = 1, Name = "Lager", Description = "Lager vom Geschäft setzen" });

        if (business_list[empresaid].business_Type == 1)
        {
            menu_item_list.Add(new { Type = 1, Name = "Bekleidungsladen", Description = " ." });
        }
        else if (business_list[empresaid].business_Type == 2)
        {
            menu_item_list.Add(new { Type = 1, Name = "Ort des Kaufmenue", Description = "Änder den Ort wo Bürger Artikel kaufen können" });
        }
        else if (business_list[empresaid].business_Type == 3)
        {
            menu_item_list.Add(new { Type = 1, Name = "Ort des Kaufmenü", Description = "Änder den Ort wo Bürger Artikel kaufen können." });
        }
        else if (business_list[empresaid].business_Type == 5)
        {
            menu_item_list.Add(new { Type = 1, Name = "Zapfhahn 1", Description = "Ändern Sie die Position der Kraftstoffpumpe #1." });
            menu_item_list.Add(new { Type = 1, Name = "Zapfhahn 2", Description = "Ändern Sie die Position der Kraftstoffpumpe #2." });
            menu_item_list.Add(new { Type = 1, Name = "Zapfhahn 3", Description = "Ändern Sie die Position der Kraftstoffpumpe #3." });
            menu_item_list.Add(new { Type = 1, Name = "Zapfhahn 4", Description = "Ändern Sie die Position der Kraftstoffpumpe #4." });
            menu_item_list.Add(new { Type = 1, Name = "Zapfhahn 5", Description = "Ändern Sie die Position der Kraftstoffpumpe #5." });
            menu_item_list.Add(new { Type = 1, Name = "Zapfhahn 6", Description = "Ändern Sie die Position der Kraftstoffpumpe #6." });
            menu_item_list.Add(new { Type = 1, Name = "Zapfhahn 7", Description = "Ändern Sie die Position der Kraftstoffpumpe #7." });
            menu_item_list.Add(new { Type = 1, Name = "Zapfhahn 8", Description = "Ändern Sie die Position der Kraftstoffpumpe #8." });
            menu_item_list.Add(new { Type = 1, Name = "Zapfhahn 9", Description = "Ändern Sie die Position der Kraftstoffpumpe #9." });
        }
        else if (business_list[empresaid].business_Type == 4 || business_list[empresaid].business_Type == 6 || business_list[empresaid].business_Type == 7 || business_list[empresaid].business_Type == 8 || business_list[empresaid].business_Type == 9)
        {
            menu_item_list.Add(new { Type = 1, Name = "Ort des Kaufmenü", Description = "Ändern Sie den Ort, an dem die Spieler ~~Y~w ~drücken, um das Menü mit der Liste der Fahrzeuge zu öffnen." });
            menu_item_list.Add(new { Type = 1, Name = "Ort der Voransicht ", Description = "Vorvisualisierungsstelle des Fahrzeugs mit der Liste der Fahrzeuge.." });
            menu_item_list.Add(new { Type = 1, Name = "Ort Auotspawn", Description = "Ändern Sie den Ort, an dem Sie nach dem Kauf das Fahrzeugs Spawnen." });
        }
        else if (business_list[empresaid].business_Type == 10)
        {
            menu_item_list.Add(new { Type = 1, Name = "Ort des Kaufmenü", Description = "Ändern Sie den Ort, an dem die Spieler ~~Y~w ~drücken, um das Menü mit der Liste der Fahrzeuge zu öffnen" });
        }
        else if (business_list[empresaid].business_Type == 11)
        {
            menu_item_list.Add(new { Type = 1, Name = "Ort des Freizeitladen Kaufmenü", Description = "Änder den Ort wo Bürger Artikel kaufen können" });
        }
        else if (business_list[empresaid].business_Type == 12)
        {
            menu_item_list.Add(new { Type = 1, Name = "Ort des Juvelier Kaufmenü", Description = "Änder den Ort wo Bürger Artikel kaufen können" });
        }
        else if (business_list[empresaid].business_Type == 13)
        {
            menu_item_list.Add(new { Type = 1, Name = "Ort des IDNet Kaufmenü", Description = "Änder den Ort wo Bürger Artikel kaufen können" });
        }
        else if (business_list[empresaid].business_Type == 14)
        {
            menu_item_list.Add(new { Type = 1, Name = "Tattoo Studio", Description = " ." });
        }
        InteractMenu.CreateMenu(player, "BUSINESS_EDIT_MAINMENU", "Firmen Menü", "~b~" + business_list[empresaid].business_Name + " (" + empresaid + ")", false, JsonConvert.SerializeObject(menu_item_list), false);
    }

    public static void ShowBusinessMenu(Client player)
    {
        int index = player.GetData("character_business_key");

        if (index == -1) { return; }

        int new_price = business_list[index].business_Price / 3;

        List<dynamic> menu_item_list = new List<dynamic>();
        //menu_item_list.Add(new { Type = 1, Name = "Name der Firma", Description = "Ändere den Firmennamen.", RightLabel = "" });
        menu_item_list.Add(new { Type = 5, Name = "Öffne/Schließe", Description = "Deinen Laden.", IsTicked = business_list[index].business_Lock });
        menu_item_list.Add(new { Type = 1, Name = "Firmensafe", Description = "Um Firmengeld zu sichern.", RightLabel = "" });
        if (business_list[index].business_Type == 3)
        {
            menu_item_list.Add(new { Type = 1, Name = "Waffenpreis bearbeiten", Description = "Optionen zur Verwaltung Ihres Unternehmensbestands.", RightLabel = "" });
        }
        else if (business_list[index].business_Type == 4)
        {
            menu_item_list.Add(new { Type = 1, Name = "Safe", Description = "Optionen zur Verwaltung Ihres Unternehmensgeldes.", RightLabel = "" });
        }
        else if (business_list[index].business_Type == 5)
        {
            menu_item_list.Add(new { Type = 1, Name = "Benzinpreis einstellen", Description = "Du kannst den Benzinpreis von 1$ bis 100$ einstellen", RightLabel = "" });
        }

        //if (business_list[index].business_Type != 4)
        //{
        //    menu_item_list.Add(new { Type = 1, Name = "Bestellen Sie Nachschub", Description = "Bestellen Sie eine Warenbestand Lieferung bei der LS Go Postal für ~y~$"+ Economy.SHIPMENT_BUSINESS_REESTOCK + "~w~.", RightLabel = "" });
        //}
        menu_item_list.Add(new { Type = 1, Name = "Firma verkaufen", Description = "Verkauft Ihre Firma Ihre Firma für ~g~$" + new_price.ToString("N0") + "~w~, die Hälfte des Kaufpreises.", RightLabel = "" });
        InteractMenu.CreateMenu(player, "PLAYER_BUSINESS_MENU", "Firma", "~b~Firmenmenü", false, JsonConvert.SerializeObject(menu_item_list), false);
    }

    public static void CheckBoxItemMenuResponse(Client player, String callbackId, int selectedIndex, String objectName, String valueList, bool _checked)
    {
        if (callbackId == "PLAYER_BUSINESS_MENU")
        {
            int index = player.GetData("character_business_key");

            if (index == -1) { return; }

            bool new_state = _checked;
            business_list[index].business_Lock = new_state;

            UpdateBusinessLabel(index);
            SaveBusiness(index);

            Main.DisplaySubtitle(player, ((new_state) ? "~y~INFO: ~w~Die Firma ist jetzt geschlossen~w~." : "~y~ERROR: ~w~Die Firma ist jetzt ~g~geöffnet~w~."));
        }
    }

    public static void SelectMenuResponse(Client player, String callbackId, int selectedIndex, String objectName, String valueList)
    {
        if (callbackId == "PLAYER_BUSINESS_MENU")
        {
            int business_id = player.GetData("character_business_key");

            if (business_id == -1) { return; }

            switch (objectName)
            {
                case "Name der Firma":
                    {
                        InteractMenu.User_Input(player, "input_manage_business_name", "Name der Firma", business_list[business_id].business_Name);
                        InteractMenu.CloseDynamicMenu(player);
                        break;
                    }

                case "Firmensafe":
                    {
                        List<dynamic> menu_item_list = new List<dynamic>();
                        menu_item_list.Add(new { Type = 1, Name = "Geld einzahlen", Description = "Legen Sie Geld in den Safe Ihres Hauses.", RightLabel = "" });
                        menu_item_list.Add(new { Type = 1, Name = "Geld auszahlen", Description = "Ziehen Sie Geld aus dem Safe Ihres Hauses ab.", RightLabel = "" });
                        InteractMenu.CreateMenu(player, "PLAYER_BUSINESS_SAFE", "Firma", "Fonds der Gesellschaft ~g~($" + business_list[business_id].business_Safe.ToString("N0") + ")", true, JsonConvert.SerializeObject(menu_item_list), false);
                        //player.TriggerEvent("menu_handler_create_menu_generic", "PLAYER_BUSINESS_SAFE", "Empresa", "~b~Fundos da Empresa ~g~($"+business_list[business_id].business_Safe.ToString("N0")+")", true, JsonConvert.SerializeObject(menu_item_list), "Pagina", "Alternar entre paginas", 100);
                        break;
                    }
                case "Waffenpreis bearbeiten":
                    {
                        Menus.CreateMenu(player, 14);
                        break;
                    }
                case "Benzinpreis einstellen":
                    {
                        InteractMenu.User_Input(player, "input_business_gas_price", "Preis für Benzin", business_list[business_id].business_fuel_price.ToString(), "", "number");
                        InteractMenu.CloseDynamicMenu(player);
                        //input_business_gas_price
                        break;
                    }
                case "Bestellen Sie Nachschub":
                    {
                        if (Business.GetPlayerBusinessKey(player) == -1)
                        {
                            Main.DisplayErrorMessage(player, "Sie besitzen kein Unternehmen..");
                            return;
                        }
                        if (Business.business_list[business_id].business_Type != 5)
                        {
                            if (Business.business_list[business_id].business_Inventory >= Business.business_list[business_id].business_InventoryCapacity)
                            {
                                Main.DisplayErrorMessage(player, "Ihr Unternehmen ist bereits vorrätig.");
                                return;
                            }
                        }

                        if (Business.business_list[business_id].business_OrderState == 1)
                        {
                            Main.DisplayErrorMessage(player, "Sie haben bereits eine ausstehende Bestellung.Stornieren Sie die Bestellung oder warten Sie auf die Lieferung.");
                            return;
                        }

                        if (Business.business_list[business_id].business_OrderState != 0)
                        {
                            Main.DisplayErrorMessage(player, "Sie haben bereits eine Bestellung erhalten.");
                            return;
                        }

                        if (Business.business_list[business_id].business_restock_manage_x == 0 && Business.business_list[business_id].business_restock_manage_y == 0)
                        {
                            Main.DisplayErrorMessage(player, "Diese Firma verfügt nicht über einen Lagereinkauf. Wenden Sie sich an einen Administrator.");
                            return;
                        }


                        if (Business.business_list[business_id].business_Safe < Economy.SHIPMENT_BUSINESS_REESTOCK)
                        {
                            Main.DisplayErrorMessage(player, "Der Wert Ihrer Bestellung ist in ~y~$" + Economy.SHIPMENT_BUSINESS_REESTOCK + "~w~ aber du hast nur $" + Business.business_list[business_id].business_Safe + " in deiner Firma.");
                            return;
                        }

                        Business.business_list[business_id].business_Safe -= Economy.SHIPMENT_BUSINESS_REESTOCK;
                        Business.business_list[business_id].business_OrderState = 1;
                        Business.business_list[business_id].business_OrderAmount = Business.business_list[business_id].business_InventoryCapacity;

                        foreach (var players in NAPI.Pools.GetAllPlayers())
                        {
                            if (player.GetData("status") == true && AccountManage.GetPlayerJob(players) == 7)
                            {
                                players.TriggerEvent("BN_ShowWithPicture", "NEUE LIEFERUNG VERFÜGBAR", "liefern weiter" + Business.business_list[business_id].business_Name + "", "Unsere Kunden haben nichts auf Lager, wir müssen " + Shipment.GetInventoryType(business_id) + " dringend liefern!", "CHAR_PLANESITE");

                            }
                        }

                        NAPI.Notification.SendNotificationToPlayer(player, "~b~[Encomenda]:~w~ Sie haben einen kompletten Nachschub Ihres Unternehmens für bestellt ~g~$" + Economy.SHIPMENT_BUSINESS_REESTOCK + "~w~, um Ihre Bestellung zu verfolgen ~b~/encomendas~w~.");
                        break;
                    }
                case "Firma verkaufen":
                    {
                        int
                           count = 0,
                           index = -1
                       ;

                        foreach (var business in business_list)
                        {
                            if (Main.IsInRangeOfPoint(player.Position, business.business_object_MarkerID.Position + new Vector3(0, 0, 1.0), 3))
                            {

                                index = count;
                            }
                            count++;
                        }

                        if (business_list[business_id].business_Safe > 0)
                        {
                            Main.DisplaySubtitle(player, "ERROR: ~w~Leeren Sie den Tresor, bevor Sie das Unternehmen verkaufen..");
                            return;
                        }

                        int new_price = business_list[business_id].business_Price / 3;


                        player.SetData("character_business_key", -1);

                        Main.GivePlayerMoney(player, new_price);

                        business_list[business_id].business_OwnerID = -1;
                        business_list[business_id].business_OwnerName = "Niemand";
                        UpdateBusinessLabel(business_id);

                        business_list[business_id].business_Safe = 0;
                        business_list[business_id].business_Inventory = 50;
                        business_list[business_id].business_InventoryCapacity = 100;

                        SaveBusiness(business_id);
                        AccountManage.SaveCharacter(player);

                        NAPI.Notification.SendNotificationToPlayer(player, "~y~[Firma]:~w~ Sie haben Ihr Geschäft für verkauft ~y~$" + new_price.ToString("N0") + "~w~.");
                        break;
                    }

            }
        }
        else if (callbackId == "PLAYER_BUSINESS_SAFE")
        {
            if (selectedIndex == 1)
            {
                InteractMenu.User_Input(player, "input_business_safe_withdraw", "Geld abheben", "0", "", "number");
            }
            else
            {
                InteractMenu.User_Input(player, "input_business_safe_deposit", "Geld einzahlen", "0", "", "number");
            }
        }
        //
        else if (callbackId == "BUSINESS_EDIT_MAINMENU")
        {
            int business_id = player.GetData("editingBusinessID");
            int business_type = business_list[business_id].business_Type;

            switch (selectedIndex)
            {
                case 0:
                    InteractMenu.User_Input(player, "input_business_name", "Name der Firma", business_list[business_id].business_Name);
                    InteractMenu.CloseDynamicMenu(player);
                    return;

                case 2:
                    InteractMenu.User_Input(player, "input_business_price", "Unternehmenswert", business_list[business_id].business_Price.ToString(), "", "number");
                    InteractMenu.CloseDynamicMenu(player);
                    return;
                case 3:
                    InteractMenu.User_Input(player, "input_business_stock", "Lagerbestand", business_list[business_id].business_Inventory.ToString(), "", "number");
                    InteractMenu.CloseDynamicMenu(player);
                    return;
                case 4:
                    InteractMenu.User_Input(player, "input_business_stock_limit", "Kontostand", business_list[business_id].business_InventoryCapacity.ToString(), "", "number");
                    InteractMenu.CloseDynamicMenu(player);
                    return;
                case 5:
                    business_list[business_id].business_posX = player.Position.X.ToString();
                    business_list[business_id].business_posY = player.Position.Y.ToString();
                    business_list[business_id].business_posZ = player.Position.Z.ToString();

                    NAPI.Entity.DeleteEntity(business_list[business_id].business_objects_blip);
                    NAPI.Entity.DeleteEntity(business_list[business_id].business_object_MarkerID);
                    NAPI.Entity.DeleteEntity(business_list[business_id].business_object_TextLabel);
                    NAPI.ColShape.DeleteColShape(business_list[business_id].business_object_Area);

                    business_list[business_id].business_objects_blip = NAPI.Blip.CreateBlip(new Vector3(float.Parse(business_list[business_id].business_posX), float.Parse(business_list[business_id].business_posY), float.Parse(business_list[business_id].business_posZ)));
                    business_list[business_id].business_object_MarkerID = NAPI.Marker.CreateMarker(27, new Vector3(float.Parse(business_list[business_id].business_posX), float.Parse(business_list[business_id].business_posY), float.Parse(business_list[business_id].business_posZ) - 1.0), new Vector3(), new Vector3(), 0.8f, new Color(255, 255, 255, 155));
                    business_list[business_id].business_object_TextLabel = NAPI.TextLabel.CreateTextLabel("", new Vector3(float.Parse(business_list[business_id].business_posX), float.Parse(business_list[business_id].business_posY), float.Parse(business_list[business_id].business_posZ) + 0.3), 8, 0.400f, 4, new Color(255, 255, 255, 255));
                    business_list[business_id].business_object_Area = NAPI.ColShape.CreateSphereColShape(new Vector3(float.Parse(business_list[business_id].business_posX), float.Parse(business_list[business_id].business_posY), float.Parse(business_list[business_id].business_posZ)), 30.0f);

                    business_list[business_id].business_object_TextLabel.Position = new Vector3(float.Parse(business_list[business_id].business_posX), float.Parse(business_list[business_id].business_posY), float.Parse(business_list[business_id].business_posZ) + 0.5);

                    UpdateBusinessBlip(business_id);
                    UpdateBusinessLabel(business_id);

                    SaveBusiness(business_id);
                    DisplayEditBusinessMenu(player, business_id);
                    return;
                case 6:
                    business_list[business_id].business_restock_manage_x = player.Position.X;
                    business_list[business_id].business_restock_manage_y = player.Position.Y;
                    business_list[business_id].business_restock_manage_z = player.Position.Z;

                    NAPI.Entity.DeleteEntity(business_list[business_id].business_restock_manage_label);
                    business_list[business_id].business_restock_manage_label = NAPI.TextLabel.CreateTextLabel("~c~Lagerbestand der Firma~w~", new Vector3(business_list[business_id].business_restock_manage_x, business_list[business_id].business_restock_manage_y, business_list[business_id].business_restock_manage_z + 0.3), 16, 0.600f, 0, new Color(255, 255, 255, 255));

                    SaveBusiness(business_id);
                    DisplayEditBusinessMenu(player, business_id);
                    return;

            }
            switch (objectName)
            {
                case "Bekleidungsladen":
                    {
                        business_list[business_id].business_clothes_shirt = player.Position;
                        business_list[business_id].business_clothes_shirt_rotation = player.Rotation.Z;

                        business_list[business_id].business_clothes_shirt_marker.Position = player.Position - new Vector3(0, 0, 1.0);
                        business_list[business_id].business_clothes_shirt_label.Position = player.Rotation + new Vector3(0, 0, 0.3);

                        SaveBusinessClothes(business_id);

                        DisplayEditBusinessMenu(player, business_id);
                        return;
                    }
                case "Friseurladen":
                    {
                        business_list[business_id].business_clothes_legs = player.Position;
                        business_list[business_id].business_clothes_legs_rotation = player.Rotation.Z;

                        business_list[business_id].business_clothes_legs_marker.Position = player.Position - new Vector3(0, 0, 1.0);
                        business_list[business_id].business_clothes_legs_label.Position = player.Rotation + new Vector3(0, 0, 0.3);

                        SaveBusinessClothes(business_id);

                        DisplayEditBusinessMenu(player, business_id);
                        return;
                    }
                case "Tennis Abholung":
                    {
                        business_list[business_id].business_clothes_shoes = player.Position;
                        business_list[business_id].business_clothes_shoes_rotation = player.Rotation.Z;

                        business_list[business_id].business_clothes_shoes_marker.Position = player.Position - new Vector3(0, 0, 1.0);
                        business_list[business_id].business_clothes_shoes_label.Position = player.Rotation + new Vector3(0, 0, 0.3);

                        SaveBusinessClothes(business_id);

                        DisplayEditBusinessMenu(player, business_id);
                        return;
                    }
                case "Knochenabholung":
                    {
                        business_list[business_id].business_clothes_head = player.Position;
                        business_list[business_id].business_clothes_head_rotation = player.Rotation.Z;

                        business_list[business_id].business_clothes_head_marker.Position = player.Position - new Vector3(0, 0, 1.0);
                        business_list[business_id].business_clothes_head_label.Position = player.Rotation + new Vector3(0, 0, 0.3);

                        SaveBusinessClothes(business_id);

                        DisplayEditBusinessMenu(player, business_id);
                        return;
                    }
                case "Zubehörabholungs":
                    {
                        business_list[business_id].business_clothes_acessories = player.Position;
                        business_list[business_id].business_clothes_acessories_rotation = player.Rotation.Z;

                        business_list[business_id].business_clothes_acessories_marker.Position = player.Position - new Vector3(0, 0, 1.0);
                        business_list[business_id].business_clothes_acessories_label.Position = player.Rotation + new Vector3(0, 0, 0.3);

                        SaveBusinessClothes(business_id);

                        DisplayEditBusinessMenu(player, business_id);
                        return;
                    }
                case "Anzugabholung":
                    {
                        business_list[business_id].business_clothes_fit = player.Position;
                        business_list[business_id].business_clothes_fit_rotation = player.Rotation.Z;

                        business_list[business_id].business_clothes_fit_marker.Position = player.Position - new Vector3(0, 0, 1.0);
                        business_list[business_id].business_clothes_fit_label.Position = player.Rotation + new Vector3(0, 0, 0.3);

                        SaveBusinessClothes(business_id);

                        DisplayEditBusinessMenu(player, business_id);
                        return;
                    }
                case "Ort des Kaufmenü":
                    {
                        business_list[business_id].ammunation_position = player.Position;
                        NAPI.Entity.DeleteEntity(business_list[business_id].ammunation_marker);
                        business_list[business_id].ammunation_marker = NAPI.Marker.CreateMarker(27, new Vector3(business_list[business_id].ammunation_position.X, business_list[business_id].ammunation_position.Y, business_list[business_id].ammunation_position.Z - 1.0), new Vector3(), new Vector3(), 0.8f, new Color(255, 255, 255, 155));

                        NAPI.Entity.DeleteEntity(business_list[business_id].ammunation_label);
                        business_list[business_id].ammunation_label = NAPI.TextLabel.CreateTextLabel("~b~~h~( Waffenladen ) ", new Vector3(business_list[business_id].ammunation_position.X, business_list[business_id].ammunation_position.Y, business_list[business_id].ammunation_position.Z + 0.3), 11, 0.600f, 0, new Color(255, 255, 255, 255));

                        SaveBusiness(business_id);

                        DisplayEditBusinessMenu(player, business_id);
                        return;
                    }
                case "Ort um Firma zu kaufen":
                    {

                        business_list[business_id].business_dealership_buy = player.Position;
                        business_list[business_id].business_dealership_buy_a = player.Rotation.Z;


                        business_list[business_id].business_dealership_buy_label.Position = player.Position + new Vector3(0, 0, 0.3);
                        business_list[business_id].business_dealership_buy_marker.Position = player.Position - new Vector3(0, 0, 1.0);

                        SaveBusinessDealership(business_id);
                        DisplayEditBusinessMenu(player, business_id);
                        return;
                    }
                case "Ort der Voransicht":
                    {
                        business_list[business_id].business_dealership_preview = player.Position;
                        business_list[business_id].business_dealership_preview_a = player.Rotation.Z;
                        SaveBusinessDealership(business_id);
                        DisplayEditBusinessMenu(player, business_id);
                        return;
                    }
                case "Ort Autospawn":
                    {
                        business_list[business_id].business_dealership_vehicle = player.Position;
                        business_list[business_id].business_dealership_vehicle_a = player.Rotation.Z;
                        SaveBusinessDealership(business_id);
                        DisplayEditBusinessMenu(player, business_id);
                        return;
                    }
                case "Ort des Kaufmenue":
                    {
                        business_list[business_id].business_store_buy_x = player.Position.X;
                        business_list[business_id].business_store_buy_y = player.Position.Y;
                        business_list[business_id].business_store_buy_z = player.Position.Z;

                        NAPI.Entity.DeleteEntity(business_list[business_id].business_store_buy_label);
                        NAPI.Entity.DeleteEntity(business_list[business_id].business_store_buy_marker);
                        business_list[business_id].business_store_buy_label = NAPI.TextLabel.CreateTextLabel("~g~~h~[ " + business_list[business_id].business_Name + " (" + business_id + ") ] ", new Vector3(business_list[business_id].business_store_buy_x, business_list[business_id].business_store_buy_y, business_list[business_id].business_store_buy_z + 0.3), 16, 0.600f, 0, new Color(255, 255, 255, 255));
                        business_list[business_id].business_store_buy_marker = NAPI.Marker.CreateMarker(27, new Vector3(business_list[business_id].business_store_buy_x, business_list[business_id].business_store_buy_y, business_list[business_id].business_store_buy_z - 1.0), new Vector3(), new Vector3(), 0.8f, new Color(255, 255, 255, 155));

                        SaveBusiness(business_id);
                        DisplayEditBusinessMenu(player, business_id);
                        return;
                    }
                case "Ort des Freizeitladen Kaufmenü":
                    {
                        business_list[business_id].business_freetimestore_buy_x = player.Position.X;
                        business_list[business_id].business_freetimestore_buy_y = player.Position.Y;
                        business_list[business_id].business_freetimestore_buy_z = player.Position.Z;

                        NAPI.Entity.DeleteEntity(business_list[business_id].business_freetimestore_buy_label);
                        NAPI.Entity.DeleteEntity(business_list[business_id].business_freetimestore_buy_marker);
                        business_list[business_id].business_freetimestore_buy_label = NAPI.TextLabel.CreateTextLabel("~g~~h~[ " + business_list[business_id].business_Name + " (" + business_id + ") ] ", new Vector3(business_list[business_id].business_freetimestore_buy_x, business_list[business_id].business_freetimestore_buy_y, business_list[business_id].business_freetimestore_buy_z + 0.3), 16, 0.600f, 0, new Color(255, 255, 255, 255));
                        business_list[business_id].business_freetimestore_buy_marker = NAPI.Marker.CreateMarker(27, new Vector3(business_list[business_id].business_freetimestore_buy_x, business_list[business_id].business_freetimestore_buy_y, business_list[business_id].business_freetimestore_buy_z - 1.0), new Vector3(), new Vector3(), 0.8f, new Color(255, 255, 255, 155));

                        SaveBusiness(business_id);
                        DisplayEditBusinessMenu(player, business_id);
                        return;
                    }
                case "Ort des Juvelier Kaufmenü":
                    {
                        business_list[business_id].business_juvestore_buy_x = player.Position.X;
                        business_list[business_id].business_juvestore_buy_y = player.Position.Y;
                        business_list[business_id].business_juvestore_buy_z = player.Position.Z;

                        NAPI.Entity.DeleteEntity(business_list[business_id].business_juvestore_buy_label);
                        NAPI.Entity.DeleteEntity(business_list[business_id].business_juvestore_buy_marker);
                        business_list[business_id].business_juvestore_buy_label = NAPI.TextLabel.CreateTextLabel("~g~~h~[ " + business_list[business_id].business_Name + " (" + business_id + ") ] ", new Vector3(business_list[business_id].business_juvestore_buy_x, business_list[business_id].business_juvestore_buy_y, business_list[business_id].business_juvestore_buy_z + 0.3), 16, 0.600f, 0, new Color(255, 255, 255, 255));
                        business_list[business_id].business_juvestore_buy_marker = NAPI.Marker.CreateMarker(27, new Vector3(business_list[business_id].business_juvestore_buy_x, business_list[business_id].business_juvestore_buy_y, business_list[business_id].business_juvestore_buy_z - 1.0), new Vector3(), new Vector3(), 0.8f, new Color(255, 255, 255, 155));

                        SaveBusiness(business_id);
                        DisplayEditBusinessMenu(player, business_id);
                        return;
                    }
                case "Ort des IDNet Kaufmenü":
                    {
                        business_list[business_id].business_phonestore_buy_x = player.Position.X;
                        business_list[business_id].business_phonestore_buy_y = player.Position.Y;
                        business_list[business_id].business_phonestore_buy_z = player.Position.Z;

                        NAPI.Entity.DeleteEntity(business_list[business_id].business_phonestore_buy_label);
                        NAPI.Entity.DeleteEntity(business_list[business_id].business_phonestore_buy_marker);
                        business_list[business_id].business_phonestore_buy_label = NAPI.TextLabel.CreateTextLabel("~g~~h~[ " + business_list[business_id].business_Name + " (" + business_id + ") ] ", new Vector3(business_list[business_id].business_phonestore_buy_x, business_list[business_id].business_phonestore_buy_y, business_list[business_id].business_phonestore_buy_z + 0.3), 16, 0.600f, 0, new Color(255, 255, 255, 255));
                        business_list[business_id].business_phonestore_buy_marker = NAPI.Marker.CreateMarker(27, new Vector3(business_list[business_id].business_phonestore_buy_x, business_list[business_id].business_phonestore_buy_y, business_list[business_id].business_phonestore_buy_z - 1.0), new Vector3(), new Vector3(), 0.8f, new Color(255, 255, 255, 155));

                        SaveBusiness(business_id);
                        DisplayEditBusinessMenu(player, business_id);
                        return;
                    }
                case "Zapfhahn 1":
                    {
                        business_list[business_id].business_pump_position[0] = new Vector3(player.Position.X, player.Position.Y, player.Position.Z);
                        business_list[business_id].business_pump_textlabel[0].Position = business_list[business_id].business_pump_position[0] - new Vector3(0, 0, 1.45f); ;
                        business_list[business_id].business_pump_textlabel_secundary[0].Position = business_list[business_id].business_pump_position[0] - new Vector3(0, 0, 2.45f);

                        DestroyDynamicPump(business_id, 0);
                        CreateDynamicPump(business_id, 0);

                        SaveBusiness(business_id);
                        DisplayEditBusinessMenu(player, business_id);
                        break;
                    }

                case "Zapfhahn 2":
                    {
                        business_list[business_id].business_pump_position[1] = new Vector3(player.Position.X, player.Position.Y, player.Position.Z);
                        business_list[business_id].business_pump_textlabel[1].Position = business_list[business_id].business_pump_position[1] - new Vector3(0, 0, 1.45f);
                        business_list[business_id].business_pump_textlabel_secundary[1].Position = business_list[business_id].business_pump_position[1] - new Vector3(0, 0, 2.45f);

                        DestroyDynamicPump(business_id, 1);
                        CreateDynamicPump(business_id, 1);
                        SaveBusiness(business_id);
                        DisplayEditBusinessMenu(player, business_id);
                        break;
                    }

                case "Zapfhahn 3":
                    {
                        business_list[business_id].business_pump_position[2] = new Vector3(player.Position.X, player.Position.Y, player.Position.Z);
                        business_list[business_id].business_pump_textlabel[2].Position = business_list[business_id].business_pump_position[2] - new Vector3(0, 0, 1.45f);
                        business_list[business_id].business_pump_textlabel_secundary[2].Position = business_list[business_id].business_pump_position[2] - new Vector3(0, 0, 2.45f);

                        DestroyDynamicPump(business_id, 2);
                        CreateDynamicPump(business_id, 2);
                        SaveBusiness(business_id);
                        DisplayEditBusinessMenu(player, business_id);
                        break;
                    }

                case "Zapfhahn 4":
                    {
                        business_list[business_id].business_pump_position[3] = new Vector3(player.Position.X, player.Position.Y, player.Position.Z);
                        business_list[business_id].business_pump_textlabel[3].Position = business_list[business_id].business_pump_position[3] - new Vector3(0, 0, 1.45f);
                        business_list[business_id].business_pump_textlabel_secundary[3].Position = business_list[business_id].business_pump_position[3] - new Vector3(0, 0, 2.45f);

                        DestroyDynamicPump(business_id, 3);
                        CreateDynamicPump(business_id, 3);
                        SaveBusiness(business_id);
                        DisplayEditBusinessMenu(player, business_id);
                        break;
                    }

                case "Zapfhahn 5":
                    {
                        business_list[business_id].business_pump_position[4] = new Vector3(player.Position.X, player.Position.Y, player.Position.Z);
                        business_list[business_id].business_pump_textlabel[4].Position = business_list[business_id].business_pump_position[4] - new Vector3(0, 0, 1.45f);
                        business_list[business_id].business_pump_textlabel_secundary[4].Position = business_list[business_id].business_pump_position[4] - new Vector3(0, 0, 2.45f);

                        DestroyDynamicPump(business_id, 4);
                        CreateDynamicPump(business_id, 4);
                        SaveBusiness(business_id);
                        DisplayEditBusinessMenu(player, business_id);
                        break;
                    }
                case "Zapfhahn 6":
                    {
                        business_list[business_id].business_pump_position[5] = new Vector3(player.Position.X, player.Position.Y, player.Position.Z);
                        business_list[business_id].business_pump_textlabel[5].Position = business_list[business_id].business_pump_position[5] - new Vector3(0, 0, 1.45f);
                        business_list[business_id].business_pump_textlabel_secundary[5].Position = business_list[business_id].business_pump_position[5] - new Vector3(0, 0, 2.45f);

                        DestroyDynamicPump(business_id, 5);
                        CreateDynamicPump(business_id, 5);
                        SaveBusiness(business_id);
                        DisplayEditBusinessMenu(player, business_id);
                        break;
                    }
                case "Zapfhahn 7":
                    {
                        business_list[business_id].business_pump_position[6] = new Vector3(player.Position.X, player.Position.Y, player.Position.Z);
                        business_list[business_id].business_pump_textlabel[6].Position = business_list[business_id].business_pump_position[6] - new Vector3(0, 0, 1.45f);
                        business_list[business_id].business_pump_textlabel_secundary[6].Position = business_list[business_id].business_pump_position[6] - new Vector3(0, 0, 2.45f);

                        DestroyDynamicPump(business_id, 6);
                        CreateDynamicPump(business_id, 6);
                        SaveBusiness(business_id);
                        DisplayEditBusinessMenu(player, business_id);
                        break;
                    }
                case "Zapfhahn 8":
                    {
                        business_list[business_id].business_pump_position[7] = new Vector3(player.Position.X, player.Position.Y, player.Position.Z);
                        business_list[business_id].business_pump_textlabel[7].Position = business_list[business_id].business_pump_position[7] - new Vector3(0, 0, 1.45f);
                        business_list[business_id].business_pump_textlabel_secundary[7].Position = business_list[business_id].business_pump_position[7] - new Vector3(0, 0, 2.45f);

                        DestroyDynamicPump(business_id, 7);
                        CreateDynamicPump(business_id, 7);
                        SaveBusiness(business_id);
                        DisplayEditBusinessMenu(player, business_id);
                        break;
                    }
                case "Zapfhahn 9":
                    {
                        business_list[business_id].business_pump_position[8] = new Vector3(player.Position.X, player.Position.Y, player.Position.Z);
                        business_list[business_id].business_pump_textlabel[8].Position = business_list[business_id].business_pump_position[8] - new Vector3(0, 0, 1.45f);
                        business_list[business_id].business_pump_textlabel_secundary[8].Position = business_list[business_id].business_pump_position[8] - new Vector3(0, 0, 2.45f);

                        DestroyDynamicPump(business_id, 8);
                        CreateDynamicPump(business_id, 8);
                        SaveBusiness(business_id);
                        DisplayEditBusinessMenu(player, business_id);
                        break;
                    }
                case "Tattoo Studio":
                    {
                        business_list[business_id].business_clothes_acessories = player.Position;
                        business_list[business_id].business_clothes_acessories_rotation = player.Rotation.Z;

                        business_list[business_id].business_clothes_acessories_marker.Position = player.Position - new Vector3(0, 0, 1.0);
                        business_list[business_id].business_clothes_acessories_label.Position = player.Rotation + new Vector3(0, 0, 0.3);

                        SaveBusinessClothes(business_id);

                        DisplayEditBusinessMenu(player, business_id);
                        return;
                    }
            }
        }
    }
    public static void OnInputResponse(Client player, String response, String inputtext)
    {
        if (response == "input_business_name")
        {
            int business_id = player.GetData("editingBusinessID");
            int business_type = business_list[business_id].business_Type;

            if (inputtext.Contains("-"))
            {
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Das - Zeichen ist nicht erlaubt!", 5000);
                return;
            }

            if (inputtext.Contains("+"))
            {
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Das + Zeichen ist nicht erlaubt!", 5000);
                return;
            }

            if (inputtext.Contains("*"))
            {
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Das * Zeichen ist nicht erlaubt!", 5000);
                return;
            }

            if (inputtext.Contains("'"))
            {
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Das ' Zeichen ist nicht erlaubt!", 5000);
                return;
            }

            if (inputtext.Contains("/"))
            {
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Das / Zeichen ist nicht erlaubt!", 5000);
                return;
            }

            if (inputtext.Contains("|"))
            {
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Das | Zeichen ist nicht erlaubt!", 5000);
                return;
            }

            if (inputtext.Contains(">"))
            {
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Das > Zeichen ist nicht erlaubt!", 5000);
                return;
            }

            if (inputtext.Contains("#"))
            {
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Das # Zeichen ist nicht erlaubt!", 5000);
                return;
            }

            if (inputtext.Contains("<"))
            {
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Das < Zeichen ist nicht erlaubt!", 5000);
                return;
            }

            if (inputtext.Contains(";"))
            {
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Das ; Zeichen ist nicht erlaubt!", 5000);
                return;
            }

            if (inputtext.Contains("&"))
            {
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Das & Zeichen ist nicht erlaubt!", 5000);
                return;
            }

            if (inputtext.Contains("$"))
            {
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Das $ Zeichen ist nicht erlaubt!", 5000);
                return;
            }

            if (inputtext.Contains("("))
            {
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Das ( Zeichen ist nicht erlaubt!", 5000);
                return;
            }

            if (inputtext.Contains(")"))
            {
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Das ) Zeichen ist nicht erlaubt!", 5000);
                return;
            }

            if (inputtext.Contains("["))
            {
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Das [ Zeichen ist nicht erlaubt!", 5000);
                return;
            }

            if (inputtext.Contains("]"))
            {
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Das ] Zeichen ist nicht erlaubt!", 5000);
                return;
            }

            if (inputtext.Contains("="))
            {
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Das = Zeichen ist nicht erlaubt!", 5000);
                return;
            }

            if (inputtext.Contains(":"))
            {
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Das : Zeichen ist nicht erlaubt!", 5000);
                return;
            }
            string name = inputtext.ToString();
            if (String.IsNullOrEmpty(name))
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Sie können keinen Nullnamen verwenden.");
                ////player.TriggerEvent("display_editbiz_menu", business_id, business_type);
                DisplayEditBusinessMenu(player, business_id);
                return;
            }
            business_list[business_id].business_Name = name.ToString();

            NAPI.Entity.DeleteEntity(business_list[business_id].business_objects_blip);
            business_list[business_id].business_objects_blip = NAPI.Blip.CreateBlip(new Vector3(float.Parse(business_list[business_id].business_posX), float.Parse(business_list[business_id].business_posY), float.Parse(business_list[business_id].business_posZ)));

            UpdateBusinessBlip(business_id);
            UpdateBusinessLabel(business_id);

            SaveBusiness(business_id);
            DisplayEditBusinessMenu(player, business_id);

            //InteractMenu.ShowPlayerNotification(player, "Nome da Empresa", "Você alterou o nome da empresa para "+ business_list[business_id].business_Name + ".", "success");
        }
        else if (response == "input_business_price")
        {
            int business_id = player.GetData("editingBusinessID");
            int business_type = business_list[business_id].business_Type;
            string price_name = inputtext.ToString();
            if (String.IsNullOrEmpty(price_name))
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"Sie können keinen Nullwert verwenden.", 5000);
                ////player.TriggerEvent("display_editbiz_menu", business_id, business_type);
                DisplayEditBusinessMenu(player, business_id);
                return;
            }

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
                Main.DisplaySubtitle(player, "Ungültiger eingegebener Wert.");
                return;
            }

            int price = Convert.ToInt32(price_name);

            if (price < 1 || price > 100000000)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Der Preis sollte mindestens 1 oder mehr betragen" + 100000000.ToString("N0") + ".");
            }
            else
            {
                business_list[business_id].business_Price = price;

                NAPI.Entity.DeleteEntity(business_list[business_id].business_objects_blip);
                business_list[business_id].business_objects_blip = NAPI.Blip.CreateBlip(new Vector3(float.Parse(business_list[business_id].business_posX), float.Parse(business_list[business_id].business_posY), float.Parse(business_list[business_id].business_posZ)));

                UpdateBusinessBlip(business_id);
                UpdateBusinessLabel(business_id);

                SaveBusiness(business_id);
                DisplayEditBusinessMenu(player, business_id);
            }
        }
        else if (response == "input_business_stock")
        {
            int business_id = player.GetData("editingBusinessID");
            int business_type = business_list[business_id].business_Type;
            string value_name = inputtext.ToString();
            if (String.IsNullOrEmpty(value_name))
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"Sie können keinen Nullwert verwenden.", 5000);
                ////player.TriggerEvent("display_editbiz_menu", business_id, business_type);
                DisplayEditBusinessMenu(player, business_id);
                return;
            }
            if (inputtext.Contains("-"))
            {
                return;
            }

            if (inputtext.Contains("+"))
            {
                return;
            }

            int value = Convert.ToInt32(value_name);
            if (!Main.IsNumeric(inputtext))
            {
                Main.DisplaySubtitle(player, "Ungültiger Wert eingegeben");
                return;
            }
            if (value < 1 || value > 20000)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Der Wert darf nicht kleiner als 1 oder größer sein " + 20000.ToString("N0") + ".");
            }
            else
            {
                business_list[business_id].business_Inventory = value;

                NAPI.Entity.DeleteEntity(business_list[business_id].business_objects_blip);
                business_list[business_id].business_objects_blip = NAPI.Blip.CreateBlip(new Vector3(float.Parse(business_list[business_id].business_posX), float.Parse(business_list[business_id].business_posY), float.Parse(business_list[business_id].business_posZ)));

                UpdateBusinessBlip(business_id);
                UpdateBusinessLabel(business_id);
                SaveBusiness(business_id);
                DisplayEditBusinessMenu(player, business_id);
            }
        }
        else if (response == "input_business_stock_limit")
        {
            int business_id = player.GetData("editingBusinessID");
            int business_type = business_list[business_id].business_Type;
            string value_name = inputtext.ToString();
            if (String.IsNullOrEmpty(value_name))
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"Sie können keinen Nullwert verwenden.", 5000);
                ////player.TriggerEvent("display_editbiz_menu", business_id, business_type);
                DisplayEditBusinessMenu(player, business_id);
                return;
            }

            if (inputtext.Contains("-"))
            {
                return;
            }

            if (inputtext.Contains("+"))
            {
                return;
            }

            int value = Convert.ToInt32(value_name);
            if (!Main.IsNumeric(inputtext))
            {
                Main.DisplaySubtitle(player, "Ungültiger eingegebener Wert.");
                return;
            }
            if (value < 1 || value > 20000)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Der Wert darf nicht kleiner als 1 oder größer sein" + 20000.ToString("N0") + ".");
            }
            else
            {
                business_list[business_id].business_InventoryCapacity = value;

                NAPI.Entity.DeleteEntity(business_list[business_id].business_objects_blip);
                business_list[business_id].business_objects_blip = NAPI.Blip.CreateBlip(new Vector3(float.Parse(business_list[business_id].business_posX), float.Parse(business_list[business_id].business_posY), float.Parse(business_list[business_id].business_posZ)));

                UpdateBusinessBlip(business_id);
                UpdateBusinessLabel(business_id);
                SaveBusiness(business_id);
                DisplayEditBusinessMenu(player, business_id);
            }
        }
        else if (response == "input_manage_business_name")
        {
            int business_id = player.GetData("character_business_key");
            int business_type = business_list[business_id].business_Type;

            string name = inputtext.ToString();
            if (String.IsNullOrEmpty(name))
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"Sie können keinen Nullwert verwenden.", 5000);
                ////player.TriggerEvent("display_editbiz_menu", business_id, business_type);
                DisplayEditBusinessMenu(player, business_id);
                return;
            }

            business_list[business_id].business_Name = name.ToString();

            NAPI.Entity.DeleteEntity(business_list[business_id].business_objects_blip);
            business_list[business_id].business_objects_blip = NAPI.Blip.CreateBlip(new Vector3(float.Parse(business_list[business_id].business_posX), float.Parse(business_list[business_id].business_posY), float.Parse(business_list[business_id].business_posZ)));

            UpdateBusinessBlip(business_id);
            UpdateBusinessLabel(business_id);

            SaveBusiness(business_id);
            ShowBusinessMenu(player);
        }
        else if (response == "input_business_safe_deposit")
        {
            int
               count = 0,
               index = -1
           ;

            if (inputtext.Contains("-"))
            {
                return;
            }

            if (inputtext.Contains("+"))
            {
                return;
            }

            foreach (var business in business_list)
            {
                if (Main.IsInRangeOfPoint(player.Position, business.business_object_MarkerID.Position + new Vector3(0, 0, 1.0), 3))
                {
                    index = count;
                }
                count++;
            }

            if (index == -1)
            {
                Main.DisplaySubtitle(player, "ERROR: ~w~Sie sind nicht an der Stelle der Unternehmensadministration.");
                return;
            }

            if (business_list[index].business_OwnerID == -1)
            {

                return;
            }

            if (business_list[index].business_OwnerID != AccountManage.GetPlayerSQLID(player))
            {
                Main.DisplaySubtitle(player, "ERROR: ~w~Das kann nur der Besitzer.");
                return;
            }

            int amount = 0;

            if (!Main.IsNumeric(inputtext))
            {
                Main.DisplaySubtitle(player, "Ungültiger Wert eingegeben");
                return;
            }

            if (!int.TryParse(inputtext, out amount))
            {
                Main.DisplaySubtitle(player, "ERROR: ~w~Ungültiger Betrag.");
                return;
            }

            if (amount < 1) return;

            if (Main.GetPlayerMoney(player) < amount)
            {
                Main.DisplaySubtitle(player, "ERROR: ~w~Sie haben nicht so viel Geld..");
                return;
            }

            Main.GivePlayerMoney(player, -amount);
            business_list[index].business_Safe = business_list[index].business_Safe + amount;
            SaveBusiness(index);

            Main.DisplaySubtitle(player, string.Format("~w~Du hast  ~g~${0:n0}~w~ in den Geld in den Sage gelegt.~n~~n~~y~Neuer Kontostand: ~g~${0:n0}", amount, business_list[index].business_Safe));
            ShowBusinessMenu(player);

        }
        else if (response == "input_business_safe_withdraw")
        {
            int
              count = 0,
              index = -1
          ;

            if (inputtext.Contains("-"))
            {
                return;
            }

            if (inputtext.Contains("+"))
            {
                return;
            }

            foreach (var business in business_list)
            {
                if (Main.IsInRangeOfPoint(player.Position, business.business_object_MarkerID.Position + new Vector3(0, 0, 1.0), 3))
                {
                    index = count;
                }
                count++;
            }

            if (index == -1)
            {
                Main.DisplaySubtitle(player, "ERROR: ~w~Sie sind nicht an der Stelle der Unternehmensadministration.");
                return;
            }

            if (business_list[index].business_OwnerID == -1)
            {

                return;
            }

            if (business_list[index].business_OwnerID != AccountManage.GetPlayerSQLID(player))
            {
                Main.DisplaySubtitle(player, "ERROR: ~w~Das kann nur der Besitzer.");
                return;
            }

            int amount = 0;

            if (!Main.IsNumeric(inputtext))
            {
                Main.DisplaySubtitle(player, "Ungültiger eingegebener Wert ..");
                return;
            }

            if (!int.TryParse(inputtext, out amount))
            {
                Main.DisplaySubtitle(player, "ERROR: ~w~Ungültiger Betrag.");
                return;
            }

            if (amount < 1) return;
            if (business_list[index].business_Safe < amount)
            {
                Main.DisplaySubtitle(player, "~w~ERROR: ~w~Der Firmensafe hat dieses Geld nicht.");
                return;
            }

            Main.GivePlayerMoney(player, amount);
            business_list[index].business_Safe = business_list[index].business_Safe - amount;
            SaveBusiness(index);

            Main.DisplaySubtitle(player, string.Format("~w~Du hast ~G~${0:n0}~W~ Geld aus dem Safe genommen~n~~n~~y~Neuer Stand: ~g~${0:n0}", amount, business_list[index].business_Safe));
            ShowBusinessMenu(player);
        }
        else if (response == "input_business_gas_price")
        {
            int
                           count = 0,
                           index = -1
                       ;

            foreach (var business in business_list)
            {
                if (Main.IsInRangeOfPoint(player.Position, business.business_object_MarkerID.Position + new Vector3(0, 0, 1.0), 3))
                {
                    index = count;
                }
                count++;
            }

            if (inputtext.Contains("-"))
            {
                return;
            }

            if (inputtext.Contains("+"))
            {
                return;
            }

            if (index == -1)
            {
                Main.DisplaySubtitle(player, "ERROR: ~w~Sie sind nicht an der Stelle der Unternehmensadministration.");
                return;
            }

            if (business_list[index].business_OwnerID == -1)
            {

                return;
            }

            if (business_list[index].business_OwnerID != AccountManage.GetPlayerSQLID(player))
            {
                Main.DisplaySubtitle(player, "ERROR: ~w~Das kann nur der Besitzer.");
                return;
            }

            if (business_list[index].business_gas_refilling > 0)
            {
                Main.DisplaySubtitle(player, "ERROR: ~w~Sie haben derzeit Mitarbeiter, die Ihr Unternehmen beliefern.Sie können damit rechnen, den Benzinpreis zu ändern.");
                return;
            }

            int amount = 0;

            if (!Main.IsNumeric(inputtext))
            {
                Main.DisplaySubtitle(player, "Ungültiger Wert eingegeben");
                return;
            }

            if (!int.TryParse(inputtext.ToString(), out amount))
            {
                Main.DisplaySubtitle(player, "ERROR: ~w~Ungültige Menge");
                return;
            }

            if (amount < 1) return;

            business_list[index].business_fuel_price = amount;
            SaveBusiness(index);

            for (int pump = 0; pump < 6; pump++)
            {
                business_list[index].business_pump_sale_price[pump] = 0;
                business_list[index].business_pump_sale_galons[pump] = 0;


                string text = "~y~Tankstelle~w~\nID: " + pump + "  (" + index + ")\nbenutze ~y~O~w~ im Fahrzeug.";
                string label = "~s~Preis pro liter: $" + business_list[index].business_fuel_price + "\nDieser Verkauf: $" + business_list[index].business_pump_sale_price[pump].ToString("0") + "\nLiter: " + business_list[index].business_pump_sale_galons[pump].ToString("C2").Replace("R$", "") + "\nComb. verfügbar: " + business_list[index].business_pump_galons[pump].ToString("C2").Replace("R$", "") + " /  " + business_list[index].business_pump_capacity[pump].ToString("C2").Replace("R$", "") + " liter";
                business_list[index].business_pump_textlabel[pump].Text = label;
                business_list[index].business_pump_textlabel_secundary[pump].Text = text;
            }
            Main.DisplaySubtitle(player, string.Format("~w~Sie haben den Preis für das Benzin Ihres Unternehmens für geändert ~g~${0:n0}~w~.", amount));
            ShowBusinessMenu(player);
        }
    }

    public static void ListItemMenuResponse(Client player, String callbackId, int selectedIndex, String objectName, String valueList, int valueIndex)
    {

        if (callbackId == "BUSINESS_EDIT_MAINMENU")
        {
            int business_id = player.GetData("editingBusinessID");
            if (objectName == "Typ")
            {
                int type = valueIndex;

                business_list[business_id].business_Type = type;

                //DisplayEditBusinessMenu(player, business_id);

                NAPI.Entity.DeleteEntity(business_list[business_id].business_objects_blip);
                business_list[business_id].business_objects_blip = NAPI.Blip.CreateBlip(new Vector3(float.Parse(business_list[business_id].business_posX), float.Parse(business_list[business_id].business_posY), float.Parse(business_list[business_id].business_posZ)));

                UpdateBusinessBlip(business_id);
                UpdateBusinessLabel(business_id);
                SaveBusiness(business_id);
            }
        }
    }

    public static void OnInputDestroy(Client player, String response)
    {
        int business_id = player.GetData("editingBusinessID");
        if (response == "input_business_name")
        {
            DisplayEditBusinessMenu(player, business_id);
        }
    }

    [Command("editbuisness")]
    public void CMD_editarempresa(Client player, int empresaid)
    {
        if (empresaid < 1 || empresaid > MAX_BUSINESS)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Die Firmen-ID darf nicht kleiner als 1 oder größer sein " + MAX_BUSINESS + ".");
        }
        else
        {
            if (AccountManage.GetPlayerAdmin(player) < adminCommands.COORDENADOR)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Sie haben keine Berechtigung, diesen Befehl zu verwenden.");
                return;
            }

            player.SetData("editingBusinessID", empresaid);
            DisplayEditBusinessMenu(player, empresaid);
        }
    }

    [Command("comprarempresa")]
    public void command_buybusiness(Client player)
    {
        int
            count = 0,
            index = -1
        ;

        foreach (var business in business_list)
        {
            if (Main.IsInRangeOfPoint(player.Position, new Vector3(float.Parse(business.business_posX), float.Parse(business.business_posY), float.Parse(business.business_posZ)), 3))
            {
                index = count;
            }
            count++;
        }

        if (index == -1)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Sie befinden sich nicht in einer Firma..");
            return;
        }
        if (NAPI.Data.GetEntityData(player, "character_business_key") != -1)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Sie besitzen bereits eine Firma.");
            return;
        }
        if (business_list[index].business_OwnerID != -1)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Diese Firma besitzt bereits.");
            return;
        }
        if (Main.GetPlayerMoney(player) < business_list[index].business_Price)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "[Firma]:~w~ Sie haben nicht genug Geld, um zu kaufen~y~" + business_list[index].business_Name + "~w~.");
            return;
        }
        Main.GivePlayerMoney(player, -business_list[index].business_Price);

        NAPI.Data.SetEntityData(player, "character_business_key", index);

        //NAPI.Util.ConsoleOutput("SQLID: "+ AccountManage.GetPlayerSQLID(player) + "");
        business_list[index].business_OwnerID = AccountManage.GetPlayerSQLID(player);
        business_list[index].business_OwnerName = NAPI.Data.GetEntityData(player, "character_name");
        UpdateBusinessLabel(index);

        // Reset Safe e Inventory
        business_list[index].business_Safe = 0;
        business_list[index].business_Inventory = 3;
        business_list[index].business_InventoryCapacity = 100;

        // Save Business and Account
        SaveBusiness(index);
        AccountManage.SaveCharacter(player);

        NAPI.Notification.SendNotificationToPlayer(player, "~y~[Firma]:~w~ Sie haben die Firma ~y~" + business_list[index].business_Name + " gekauft ~w~für ~g~$~w~" + business_list[index].business_Price.ToString("N0") + ".");
        //NAPI.Notification.SendNotificationToPlayer(player, "~y~[Firma]:~w~ Benutze~y~Drücke F3~w~ um Ihre Unternehmensinformationen und - befehle anzuzeigen.");
    }

    [RemoteEvent("business_safe")]
    public void BusinessSafe(Client player, int type, int amount)
    {
        int index = player.GetData("character_business_key");

        if (index == -1)
        {
            Main.DisplaySubtitle(player, "ERROR: ~w~Sie sind nicht an der Stelle der Unternehmensadministration.");
            return;
        }

        if (business_list[index].business_OwnerID == -1)
        {

            return;
        }

        if (business_list[index].business_OwnerID != AccountManage.GetPlayerSQLID(player))
        {
            Main.DisplaySubtitle(player, "ERROR: ~w~Das kann nur der Besitzer.");
            return;
        }


        if (amount < 1) { Main.DisplaySubtitle(player, "ERROR: ~w~Ungültige Menge"); return; }
        if (type == 0)
        {
            if (Main.GetPlayerMoney(player) < amount)
            {
                Main.DisplaySubtitle(player, "ERROR: ~w~Sie haben nicht so viel Geld..");
                return;
            }

            Main.GivePlayerMoney(player, -amount);
            business_list[index].business_Safe = business_list[index].business_Safe + amount;
            SaveBusiness(index);

            Main.DisplaySubtitle(player, string.Format("~w~Du hast eingezahlt ~g~${0:n0}~w~ in dein Haussafe.~n~~n~~y~Neuer Stand: ~g~${0:n0}", amount, business_list[index].business_Safe));
            player.TriggerEvent("hide_faction_browser");
            //player.TriggerEvent("BusinessUpdateSafe", NAPI.Util.ToJson(new { Money = business_list[index].business_Safe }));
        }
        else
        {
            if (business_list[index].business_Safe < amount)
            {
                Main.DisplaySubtitle(player, "Der Firmensafe hat dieses Geld nicht.");
                return;
            }

            Main.GivePlayerMoney(player, amount);
            business_list[index].business_Safe = business_list[index].business_Safe - amount;
            SaveBusiness(index);

            Main.DisplaySubtitle(player, string.Format("~w~Du hast aus dem Safe~G~${0:n0}~W~ genommen.~n~~n~~y~Neuer Stand: ~g~${0:n0}", amount, business_list[index].business_Safe));
            player.TriggerEvent("hide_faction_browser");
            //player.TriggerEvent("BusinessUpdateSafe", NAPI.Util.ToJson(new { Money = business_list[index].business_Safe }));
        }

    }

    [RemoteEvent("Business_Change_Name")]
    public void Business_Change_Name(Client player, string new_name)
    {
        int index = GetPlayerInBusinessOwner(player);

        if (index == -1)
        {
            player.TriggerEvent("Destroy_Character_Menu");
            return;
        }

        if (new_name.Contains("-"))
        {
            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Das - Zeichen ist nicht erlaubt!", 5000);
            return;
        }

        if (new_name.Contains("+"))
        {
            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Das + Zeichen ist nicht erlaubt!", 5000);
            return;
        }

        if (new_name.Contains("*"))
        {
            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Das * Zeichen ist nicht erlaubt!", 5000);
            return;
        }

        if (new_name.Contains("'"))
        {
            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Das ' Zeichen ist nicht erlaubt!", 5000);
            return;
        }

        if (new_name.Contains("/"))
        {
            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Das / Zeichen ist nicht erlaubt!", 5000);
            return;
        }

        if (new_name.Contains("|"))
        {
            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Das | Zeichen ist nicht erlaubt!", 5000);
            return;
        }

        if (new_name.Contains(","))
        {
            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Das , Zeichen ist nicht erlaubt!", 5000);
            return;
        }

        if (new_name.Contains("#"))
        {
            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Das # Zeichen ist nicht erlaubt!", 5000);
            return;
        }

        if (new_name.Contains("."))
        {
            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Das . Zeichen ist nicht erlaubt!", 5000);
            return;
        }

        if (new_name.Length > 32)
        {
            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Der Name darf nicht länger als 32 Zeichen sein.", 5000);
            return;
        }

        business_list[index].business_Name = new_name;
        UpdateBusinessLabel(index);
        SaveBusiness(index);

        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie haben den Namen Ihrer Firma in geändert: " + new_name + ".", 5000);

        //
        if (business_list[index].business_Type == 4) CarDealership.ShowDealershipManage(player);
    }

    [RemoteEvent("Business_Depositar_Fundos")]
    public void Business_Depositar_Fundos(Client player, string new_value)
    {
        int index = GetPlayerInBusinessOwner(player);

        if (index == -1)
        {
            player.TriggerEvent("Destroy_Character_Menu");
            return;
        }

        if (new_value.Contains("-"))
        {
            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Das ist nicht erlaubt!", 5000);
            return;
        }

        if (new_value.Contains("+"))
        {
            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Das ist nicht erlaubt!", 5000);
            return;
        }

        if (new_value.Length < 1)
        {
            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie können keinen Nullwert oder einen negativen Wert verwenden.", 5000);
            return;
        }

        if (!Main.IsNumeric(new_value))
        {
            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Der eingegebene Wert muss in Zahlen angegeben werden.", 5000);
            return;
        }

        int value = Convert.ToInt32(new_value);

        if (Main.GetPlayerMoney(player) < value)
        {
            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie haben diesen Betrag nicht bei sich.", 5000);
            return;
        }

        Main.GivePlayerMoney(player, -value);
        business_list[index].business_Safe += value;
        UpdateBusinessLabel(index);
        SaveBusiness(index);

        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie haben einen Betrag von $" + value.ToString("N0") + " in Ihrem Unternehmen hinterlegt.", 5000);

        //
        if (business_list[index].business_Type == 4) CarDealership.ShowDealershipManage(player);
    }

    [RemoteEvent("Business_Retirar_Fundos")]
    public void Business_Retirar_Fundos(Client player, string new_value)
    {
        int index = GetPlayerInBusinessOwner(player);

        if (index == -1)
        {
            player.TriggerEvent("Destroy_Character_Menu");
            return;
        }

        if (new_value.Contains("-"))
        {
            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Das ist nicht erlaubt!", 5000);
            return;
        }

        if (new_value.Contains("+"))
        {
            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Das ist nicht erlaubt!", 5000);
            return;
        }

        if (new_value.Length < 1)
        {
            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie können keinen Nullwert oder einen negativen Wert verwenden.", 5000);
            return;
        }

        if (!Main.IsNumeric(new_value))
        {
            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Der eingegebene Wert muss in Zahlen angegeben werden.", 5000);
            return;
        }

        int value = Convert.ToInt32(new_value);

        if (business_list[index].business_Safe < value)
        {
            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie haben diesen Betrag nicht bei sich.", 5000);
            return;
        }

        Main.GivePlayerMoney(player, value);
        business_list[index].business_Safe -= value;
        UpdateBusinessLabel(index);
        SaveBusiness(index);

        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie haben eine Menge Geld von $" + value.ToString("N0") + " aus dem Firmenkonto abgehoben.", 5000);

        //
        if (business_list[index].business_Type == 4) CarDealership.ShowDealershipManage(player);
    }

    [RemoteEvent("business_sell")]
    public void SellBusiness(Client player)
    {
        int index = player.GetData("character_business_key");

        player.TriggerEvent("hide_faction_browser");
        if (index == -1)
        {
            Main.DisplaySubtitle(player, "ERROR: ~w~Sie sind nicht an der Stelle der Unternehmensadministration.");
            return;
        }

        if (business_list[index].business_OwnerID == -1)
        {

            return;
        }

        if (business_list[index].business_OwnerID != AccountManage.GetPlayerSQLID(player))
        {
            Main.DisplaySubtitle(player, "ERROR: ~w~Das kann nur der Besitzer.");
            return;
        }

        if (business_list[index].business_Safe > 0)
        {
            Main.DisplaySubtitle(player, "ERROR: ~w~Leeren Sie den Tresor, bevor Sie das Unternehmen verkaufen..");
            return;
        }

        int new_price = business_list[index].business_Price / 3;


        player.SetData("character_business_key", -1);

        Main.GivePlayerMoney(player, new_price);

        business_list[index].business_OwnerID = -1;
        business_list[index].business_OwnerName = "Niemand";
        UpdateBusinessLabel(index);

        business_list[index].business_Safe = 0;
        business_list[index].business_Inventory = 50;
        business_list[index].business_InventoryCapacity = 100;

        SaveBusiness(index);
        AccountManage.SaveCharacter(player);

        NAPI.Notification.SendNotificationToPlayer(player, "~y~[Firma]:~w~ Sie haben Ihr Geschäft verkauft für: ~y~$" + new_price.ToString("N0") + "~w~.");
        player.TriggerEvent("hide_faction_browser");
    }
}