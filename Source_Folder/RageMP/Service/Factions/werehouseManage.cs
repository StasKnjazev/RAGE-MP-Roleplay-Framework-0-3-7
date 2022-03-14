using System;
using System.Collections.Generic;
using GTANetworkAPI;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using DerStr1k3r.Core;
using DerStr1k3r.SDK;

class WerehouseManage : Script
{
    public static int HQ_TYPE_WEED = 1;
    public static int HQ_TYPE_COCAINE = 2;
    public static int HQ_TYPE_META = 3;
    public static int HQ_TYPE_WEAPONS = 4;

    public static int MAX_INVENTORY_ITENS = 200;

    public class WerehouseEnum : IEquatable<WerehouseEnum>
    {
        public int id { get; set; }

        public string name { get; set; }
        public int ownerid { get; set; }
        public int safe { get; set; }
        public int price { get; set; }
        public int type { get; set; }

        public float exterior_x { get; set; }
        public float exterior_y { get; set; }
        public float exterior_z { get; set; }
        public float exterior_a { get; set; }

        public float interior_x { get; set; }
        public float interior_y { get; set; }
        public float interior_z { get; set; }
        public float interior_a { get; set; }

        public float menu_x { get; set; }
        public float menu_y { get; set; }
        public float menu_z { get; set; }

        public ColShape menuArea { get; set; }

        public Entity exteriorLabel { get; set; }
        public Entity exteriorMarker { get; set; }

        public TextLabel interiorLabel { get; set; }
        public Marker interiorMarker { get; set; }

        public Entity exteriorBlip { get; set; }


        public bool lockStatus { get; set; }

        public bool using_inventory { get; set; }

        public string[] gun { get; set; } = new string[20];
        public int[] gun_units { get; set; } = new int[20];
        public int[] gun_perm { get; set; } = new int[20];

        public int[] inventory_index { get; set; } = new int[MAX_INVENTORY_ITENS];
        public int[] inventory_type { get; set; } = new int[MAX_INVENTORY_ITENS];
        public int[] inventory_amount { get; set; } = new int[MAX_INVENTORY_ITENS];

        public string[] safe_gun { get; set; } = new string[20];

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            WerehouseEnum objAsPart = obj as WerehouseEnum;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }
        public override int GetHashCode()
        {
            return id;
        }
        public bool Equals(WerehouseEnum other)
        {
            if (other == null) return false;
            return (this.id.Equals(other.id));
        }
    }

    public static List<WerehouseEnum> WereHouseData = new List<WerehouseEnum>();
    public static List<dynamic> weapon_order_list = new List<dynamic>();
    public static void WerehouseManageInit()
    {
        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {
            Mainpipeline.Open();
            MySqlCommand query = new MySqlCommand("SELECT * FROM `faction_werehouse`;", Mainpipeline);
            using (MySqlDataReader reader = query.ExecuteReader())
            {
                var index = 0;
                while (reader.Read())
                {
                    WereHouseData.Add(new WerehouseEnum()
                    {
                        id = reader.GetInt32("id"),
                        name = reader.GetString("name"),
                        ownerid = reader.GetInt32("ownerid"),
                        price = reader.GetInt32("price"),
                        safe = reader.GetInt32("safe"),
                        type = reader.GetInt32("type"),

                        lockStatus = true,

                        exterior_x = reader.GetFloat("exterior_x"),
                        exterior_y = reader.GetFloat("exterior_y"),
                        exterior_z = reader.GetFloat("exterior_z"),
                        exterior_a = reader.GetFloat("exterior_a"),

                        interior_x = reader.GetFloat("interior_x"),
                        interior_y = reader.GetFloat("interior_y"),
                        interior_z = reader.GetFloat("interior_z"),
                        interior_a = reader.GetFloat("interior_a"),

                        menu_x = reader.GetFloat("menu_x"),
                        menu_y = reader.GetFloat("menu_y"),
                        menu_z = reader.GetFloat("menu_z"),

                        using_inventory = false,
                    });

                    for (int i = 0; i < 20; i++)
                    {
                        WereHouseData[index].gun[i] = reader.GetString("gun_" + i);
                        WereHouseData[index].gun_units[i] = reader.GetInt32("gun_units_" + i);
                        WereHouseData[index].gun_perm[i] = reader.GetInt32("gun_perm_" + i);
                        WereHouseData[index].safe_gun[i] = reader.GetString("safe_gun_" + i);
                    }

                    if (WereHouseData[index].ownerid == -1)
                    {
                        WereHouseData[index].exteriorLabel = NAPI.TextLabel.CreateTextLabel("" + WereHouseData[index].name + "~n~~g~Preis: ~g~~h~$" + WereHouseData[index].price.ToString("N0") + "~n~~n~~y~Benutze O~w~", new Vector3(WereHouseData[index].exterior_x, WereHouseData[index].exterior_y, WereHouseData[index].exterior_z + 0.6), 14, 0.600f, 0, new Color(255, 255, 255, 255));
                    }
                    else WereHouseData[index].exteriorLabel = NAPI.TextLabel.CreateTextLabel("" + WereHouseData[index].name + " ~g~[Besitzer des Lagers.: " + FactionManage.faction_data[WereHouseData[index].ownerid].faction_name + "]", new Vector3(WereHouseData[index].exterior_x, WereHouseData[index].exterior_y, WereHouseData[index].exterior_z + 0.6), 14, 0.600f, 0, new Color(255, 255, 255, 255));
                    WereHouseData[index].exteriorMarker = NAPI.Marker.CreateMarker(27, new Vector3(WereHouseData[index].exterior_x, WereHouseData[index].exterior_y, WereHouseData[index].exterior_z - 0.3), new Vector3(), new Vector3(), 0.8f, new Color(56, 153, 0, 255));

                    WereHouseData[index].menuArea = NAPI.ColShape.CreateSphereColShape(new Vector3(WereHouseData[index].menu_x, WereHouseData[index].menu_y, WereHouseData[index].menu_z), 1.0f);

                    WereHouseData[index].menuArea.OnEntityEnterColShape += (s, ent) =>
                    {
                        Client player;

                        if ((player = NAPI.Player.GetPlayerFromHandle(ent)) != null)
                        {
                            if (player.GetData("status") == false) return;
                            Main.DisplaySubtitle(player, "Drücke[ ~b~E~w~ ] auf den Computer zugreifen", 3);
                        }
                    };

                    NAPI.TextLabel.CreateTextLabel("~g~-~y~ Computer~g~ -", new Vector3(WereHouseData[index].menu_x, WereHouseData[index].menu_y, WereHouseData[index].menu_z - 0.2f), 8.0f, 0.8f, 4, new Color(255, 255, 255, 255));

                    weapon_order_list.Add(new { order_model = "KnuckleDuster", order_price = 1000, permission = 0 });
                    weapon_order_list.Add(new { order_model = "Bat", order_price = 1000, permission = 0 });
                    weapon_order_list.Add(new { order_model = "SwitchBlade", order_price = 10000, permission = 0 });
                    weapon_order_list.Add(new { order_model = "Pistol", order_price = 40000, permission = 0 });
                    weapon_order_list.Add(new { order_model = "CombatPistol", order_price = 55000, permission = 1 });
                    weapon_order_list.Add(new { order_model = "Pistol50", order_price = 95000, permission = 1 });
                    weapon_order_list.Add(new { order_model = "HeavyPistol", order_price = 985000, permission = 1 });
                    weapon_order_list.Add(new { order_model = "MicroSMG", order_price = 900000, permission = 1 });
                    weapon_order_list.Add(new { order_model = "SMG", order_price = 450000, permission = 1 });
                    weapon_order_list.Add(new { order_model = "AssaultRifle", order_price = 645000, permission = 1 });
                    weapon_order_list.Add(new { order_model = "CarbineRifle", order_price = 845000, permission = 1 });
                    weapon_order_list.Add(new { order_model = "SawnOffShotgun", order_price = 1000000, permission = 1 });

                    for (int i = 0; i < MAX_INVENTORY_ITENS; i++)
                    {
                        WereHouseData[index].inventory_index[i] = -1;
                        WereHouseData[index].inventory_type[i] = 0;
                        WereHouseData[index].inventory_amount[i] = 0;
                    }

                    LoadInventoryItens(index);
                    index++;
                }
            }
        }

        NAPI.TextLabel.CreateTextLabel("- ~c~Verlasse das HQ~w~ -", new Vector3(-3183.432, -39.16352, 89.57901), 8.0f, 0.6f, 0, new Color(255, 255, 255, 255), false);
        NAPI.Marker.CreateMarker(27, new Vector3(-3183.432, -39.16352, 89.57901) - new Vector3(0, 0, 0.8f), new Vector3(), new Vector3(), 1.5f, new Color(11, 158, 16, 150), false);

        NAPI.TextLabel.CreateTextLabel("- ~c~Verlasse das HQ~w~ -", new Vector3(997.2776, -3200.509, -36.39372), 8.0f, 0.6f, 0, new Color(255, 255, 255, 255), false);
        NAPI.Marker.CreateMarker(27, new Vector3(997.2776, -3200.509, -36.39372) - new Vector3(0, 0, 0.8f), new Vector3(), new Vector3(), 1.5f, new Color(11, 158, 16, 150), false);

        NAPI.TextLabel.CreateTextLabel("- ~c~Verlasse das HQ~w~ -", new Vector3(1088.689, -3187.844, -38.99347), 8.0f, 0.6f, 0, new Color(255, 255, 255, 255), false);
        NAPI.Marker.CreateMarker(27, new Vector3(1088.689, -3187.844, -38.99347) - new Vector3(0, 0, 0.8f), new Vector3(), new Vector3(), 1.5f, new Color(11, 158, 16, 150), false);

        NAPI.TextLabel.CreateTextLabel("- ~c~Verlasse das HQ~w~ -", new Vector3(981.3119, -102.4228, 74.84509), 8.0f, 0.6f, 0, new Color(255, 255, 255, 255), false);
        NAPI.Marker.CreateMarker(27, new Vector3(981.3119, -102.4228, 74.84509) - new Vector3(0, 0, 0.8f), new Vector3(), new Vector3(), 1.5f, new Color(11, 158, 16, 150), false);

        NAPI.Marker.CreateMarker(27, new Vector3(1035.855, -3204.715, -38.17416) - new Vector3(0, 0, 0.8f), new Vector3(), new Vector3(), 2.5f, new Color(0, 200, 0, 110));
        //NAPI.TextLabel.CreateTextLabel("~g~-~y~ Marihuana-Verarbeitung~g~ -~w~~n~~n~Drücke ~y~E~w~ um mit der Verarbeitung zu beginnen", new Vector3(1035.855, -3204.715, -38.17416 - 0.2f), 8.0f, 0.8f, 4, new Color(255, 255, 255, 255));

        NAPI.Marker.CreateMarker(27, new Vector3(1101.75, -3194.092, -38.99347) - new Vector3(0, 0, 0.8f), new Vector3(), new Vector3(), 2.5f, new Color(0, 200, 0, 110));
        //NAPI.TextLabel.CreateTextLabel("~g~-~y~ Kokainverarbeitung~g~ -~w~~n~~n~Drücke ~y~E~w~ um mit der Verarbeitung zu beginnen", new Vector3(1101.75, -3194.092, -38.99347 - 0.2f), 8.0f, 0.8f, 4, new Color(255, 255, 255, 255));
        
        NAPI.Marker.CreateMarker(27, new Vector3(1010.86, -3200.156, -38.99313) - new Vector3(0, 0, 0.8f), new Vector3(), new Vector3(), 2.5f, new Color(0, 200, 0, 110));
        //NAPI.TextLabel.CreateTextLabel("~g~-~y~ Opiumverarbeitung~g~ -~w~~n~~n~Drücke ~y~E~w~ um mit der Verarbeitung zu beginnen", new Vector3(1010.86, -3200.156, -38.99313 - 0.2f), 8.0f, 0.8f, 4, new Color(255, 255, 255, 255));

        NAPI.TextLabel.CreateTextLabel("~o~-~y~ Safe~o~ -", new Vector3(1031.024, -3203.098, -38.19354 - 0.2f), 8.0f, 0.8f, 4, new Color(255, 255, 255, 255));
        NAPI.TextLabel.CreateTextLabel("~o~-~y~ Safe~o~ -", new Vector3(1017.242, -3198.394, -38.99321 - 0.2f), 8.0f, 0.8f, 4, new Color(255, 255, 255, 255));
        NAPI.TextLabel.CreateTextLabel("~o~-~y~ Safe~o~ -", new Vector3(977.1298, -104.1134, 74.84519 - 0.2f), 8.0f, 0.8f, 4, new Color(255, 255, 255, 255));
        NAPI.TextLabel.CreateTextLabel("~o~-~y~ Safe~o~ -", new Vector3(1096.997, -3192.923, -38.99346 - 0.2f), 8.0f, 0.8f, 4, new Color(255, 255, 255, 255));
    }


    public static void SaveWerehouse(int index)
    {
        string query = "UPDATE `faction_werehouse` SET `name` = @name, `ownerid` = @ownerid, `price` = @price, `type` = @type, `safe` = @safe, `exterior_x` = @exterior_x, `exterior_y` = @exterior_y, `exterior_z` = @exterior_z, `exterior_a` = @exterior_a, `interior_x` = @interior_x, `interior_y` = @interior_y, `interior_z` = @interior_z, `interior_a` = @interior_a, `menu_x` = @menu_x, `menu_y` = @menu_y, `menu_z` = @menu_z ";

        for (int i = 0; i < 20; i++)
        {
            query = query + ", `gun_" + i + "` = '" + WereHouseData[index].gun[i] + "', `gun_units_" + i + "` = '" + WereHouseData[index].gun_units[i] + "', `safe_gun_" + i + "` = '" + WereHouseData[index].safe_gun[i] + "' ";
        }
        
       query = query + " WHERE `id` = '" + index + "'";


        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {
            try
            {
                Mainpipeline.Open();
                MySqlCommand myCommand = new MySqlCommand(query, Mainpipeline);
                myCommand.Parameters.AddWithValue("@id", WereHouseData[index].id);
                myCommand.Parameters.AddWithValue("@name", WereHouseData[index].name);
                myCommand.Parameters.AddWithValue("@ownerid", WereHouseData[index].ownerid);
                myCommand.Parameters.AddWithValue("@safe", WereHouseData[index].safe);
                myCommand.Parameters.AddWithValue("@price", WereHouseData[index].price);
                myCommand.Parameters.AddWithValue("@type", WereHouseData[index].type);
                myCommand.Parameters.AddWithValue("@exterior_x", WereHouseData[index].exterior_x);
                myCommand.Parameters.AddWithValue("@exterior_y", WereHouseData[index].exterior_y);
                myCommand.Parameters.AddWithValue("@exterior_z", WereHouseData[index].exterior_z);
                myCommand.Parameters.AddWithValue("@exterior_a", WereHouseData[index].exterior_a);
                myCommand.Parameters.AddWithValue("@interior_x", WereHouseData[index].interior_x);
                myCommand.Parameters.AddWithValue("@interior_y", WereHouseData[index].interior_y);
                myCommand.Parameters.AddWithValue("@interior_z", WereHouseData[index].interior_z);
                myCommand.Parameters.AddWithValue("@interior_a", WereHouseData[index].interior_a);
                myCommand.Parameters.AddWithValue("@menu_x", WereHouseData[index].menu_x);
                myCommand.Parameters.AddWithValue("@menu_y", WereHouseData[index].menu_y);
                myCommand.Parameters.AddWithValue("@menu_z", WereHouseData[index].menu_z);
                myCommand.ExecuteNonQuery();
                //NAPI.Util.ConsoleOutput(myCommand.ToString());
            }
            catch (Exception ex)
            {
                //NAPI.Util.ConsoleOutput("[EXCEPTION SaveWerehouse] " + ex.Message);
                //NAPI.Util.ConsoleOutput("[EXCEPTION SaveWerehouse] " + ex.StackTrace);
            }
        }
    }

    public static void UpdateWerehousePickup(int index)
    {
        NAPI.Entity.DeleteEntity(WereHouseData[index].exteriorLabel);
        NAPI.Entity.DeleteEntity(WereHouseData[index].exteriorMarker);
        //NAPI.Entity.DeleteEntity(WereHouseData[index].exteriorBlip);

        WereHouseData[index].exteriorBlip = NAPI.Blip.CreateBlip(new Vector3(WereHouseData[index].exterior_x, WereHouseData[index].exterior_y, WereHouseData[index].exterior_z));
        NAPI.Blip.SetBlipName(WereHouseData[index].exteriorBlip, "Faction HQ");

        if (WereHouseData[index].type == HQ_TYPE_WEED)
        {
            NAPI.Blip.SetBlipSprite(WereHouseData[index].exteriorBlip, 501);
        }
        else if (WereHouseData[index].type == HQ_TYPE_META)
        {
            NAPI.Blip.SetBlipSprite(WereHouseData[index].exteriorBlip, 501);
        }
        else if (WereHouseData[index].type == HQ_TYPE_COCAINE)
        {
            NAPI.Blip.SetBlipSprite(WereHouseData[index].exteriorBlip, 514);
        }
        else if (WereHouseData[index].type == HQ_TYPE_WEAPONS)
        {
            NAPI.Blip.SetBlipSprite(WereHouseData[index].exteriorBlip, 501);
        }

        NAPI.Blip.SetBlipShortRange(WereHouseData[index].exteriorBlip, true);
        NAPI.Blip.SetBlipColor(WereHouseData[index].exteriorBlip, 51);

        if (WereHouseData[index].ownerid == -1)
        {
            WereHouseData[index].exteriorLabel = NAPI.TextLabel.CreateTextLabel("" + WereHouseData[index].name + "~n~~g~Preis: ~g~~h~$" + WereHouseData[index].price.ToString("N0") + "", new Vector3(WereHouseData[index].exterior_x, WereHouseData[index].exterior_y, WereHouseData[index].exterior_z + 0.6), 14, 0.600f, 0, new Color(255, 255, 255, 255));
        }
        else WereHouseData[index].exteriorLabel = NAPI.TextLabel.CreateTextLabel("" + WereHouseData[index].name + " ~g~[Lagerinhaber: " + FactionManage.faction_data[WereHouseData[index].ownerid].faction_name + "]", new Vector3(WereHouseData[index].exterior_x, WereHouseData[index].exterior_y, WereHouseData[index].exterior_z + 0.6), 14, 0.600f, 0, new Color(255, 255, 255, 255));
        WereHouseData[index].exteriorMarker = NAPI.Marker.CreateMarker(0, new Vector3(WereHouseData[index].exterior_x, WereHouseData[index].exterior_y, WereHouseData[index].exterior_z - 0.3), new Vector3(), new Vector3(), 0.8f, new Color(56, 153, 0, 255));

    }

    
    public static void ShowWarehouseMenu(Client player)
    {

        int count = 0;
        foreach (var werehouse in WereHouseData)
        {
            //NAPI.Util.ConsoleOutput("" + (count + 500) + " << " + count + "");
            if (Main.IsInRangeOfPoint(player.Position, new Vector3(werehouse.menu_x, werehouse.menu_y, werehouse.menu_z), 1) && NAPI.Entity.GetEntityDimension(player) == count + 500)
            {
                //NAPI.Util.ConsoleOutput("" + (count + 500) + " << " + count + "");
                player.SetData("EditingArmazemID", count);
                player.SetData("EditingArmazemGroupID", AccountManage.GetPlayerGroup(player));


                List<dynamic> menu_item_list = new List<dynamic>();
                menu_item_list.Add(new { Type = 1, Name = "Gangkasse", Description = "" });
                menu_item_list.Add(new { Type = 1, Name = "Waffen entnehmen", Description = "" });

                InteractMenu.CreateMenu(player, "WEREHOSE_MENU", "Lagerhaus", "~b~Lager", true, JsonConvert.SerializeObject(menu_item_list), false);
                return;
            }
            count++;
        }
        count = 0;
    }

    public static void SelectMenuResponse(Client player, String callbackId, int selectedIndex, String objectName, String valueList)
    {
        if (callbackId == "WEREHOSE_MENU")
        {
            List<dynamic> menu_item_list = new List<dynamic>();
            switch (selectedIndex)
            {
                case 0:
                    {
                        int index = player.GetData("EditingArmazemID");
                        menu_item_list.Add(new { Type = 1, Name = "Geld einzahlen", Description = "Wählen Sie diese Option, um einen Geldbetrag Ihrer Wahl in das Tresorfach der Gruppe einzuzahlen." });
                        menu_item_list.Add(new { Type = 1, Name = "Geld abheben", Description = "Wählen Sie diese Option, um einen Geldbetrag Ihrer Wahl im Gang-Safe abzuheben. " });

                        InteractMenu.CreateMenu(player, "WEREHOSE_MENU_SAFE", "Lagerhaus", "~b~Lager~g~($" + WereHouseData[index].safe.ToString("N0") + ")", true, JsonConvert.SerializeObject(menu_item_list), false);
                        break;
                    }
                case 1:
                    {
                        int index = player.GetData("EditingArmazemID");
                        int gangid = player.GetData("EditingArmazemGroupID");
                        for (int i = 0; i < 20; i++)
                        {
                            if (WereHouseData[index].gun_units[i] > 0)
                            {
                                menu_item_list.Add(new { Type = 1, Name = i + ". " + WereHouseData[index].gun[i] + " (perm. ~c~" + WereHouseData[index].gun_perm[i] + " +~w~)", Description = "", RightLabel = WereHouseData[index].gun_units[i] + " Einheiten" });
                            }
                            else
                            {
                                menu_item_list.Add(new { Type = 1, Name = i + ". Frei", Description = "" });
                            }
                        }
                        InteractMenu.CreateMenu(player, "WEREHOSE_MENU_ORDER_EQUIPMENT", "Lagerhaus", "~b~VERFÜGBARE OPTIONEN: ", true, JsonConvert.SerializeObject(menu_item_list), false);
                        break;
                    }
                case 2:
                    {
                        int index = player.GetData("EditingArmazemID");
                        int gangid = player.GetData("EditingArmazemGroupID");
                        for (int i = 0; i < 20; i++)
                        {
                            if (WereHouseData[index].safe_gun[i] != "undefiniert")
                            {
                                menu_item_list.Add(new { Type = 1, Name = i + ". ~g~" + WereHouseData[index].safe_gun[i] + "~w~", Description = "" });
                            }
                            else
                            {
                                menu_item_list.Add(new { Type = 1, Name = i + ". Frei zu speichern", Description = "" });
                            }
                        }
                        InteractMenu.CreateMenu(player, "WEREHOSE_MENU_SAFE_EQUIPMENT", "Lagerhaus", "~b~VERFÜGBARE OPTIONEN: ", true, JsonConvert.SerializeObject(menu_item_list), false);
                        break;
                    }

            }
        }
        else if (callbackId == "WEREHOSE_MENU_SAFE")
        {
            if (selectedIndex == 0)
            {
                InteractMenu.User_Input(player, "input_werehouse_deposit", "Geld einzahlen", "0", "", "number");
                InteractMenu.CloseDynamicMenu(player);
            }
            else
            {
                InteractMenu.User_Input(player, "input_werehouse_withdraw", "Geld abheben", "0", "", "number");
                InteractMenu.CloseDynamicMenu(player);
            }
        }
        else if (callbackId == "WEREHOSE_MENU_ORDER_EQUIPMENT")
        {
            player.SetData("EditingArmazemSlotID", selectedIndex);

            int index = player.GetData("EditingArmazemID");
            int gangid = player.GetData("EditingArmazemGroupID");
            int slotid = player.GetData("EditingArmazemSlotID");

            if (WereHouseData[index].gun_units[slotid] >= 1)
            {
                if (AccountManage.GetPlayerRank(player) >= WereHouseData[index].gun_perm[slotid])
                {
                    Inventory.GiveItemToInventory(player, 12, 1);
                    WeaponHash modelo = NAPI.Util.WeaponNameToModel(WereHouseData[index].gun[slotid]);
                    NAPI.Player.GivePlayerWeapon(player, modelo, 250);
                    WeaponManage.GivePlayerWeaponEx(player, WereHouseData[index].gun[slotid], 250);
                    NAPI.Player.SetPlayerCurrentWeaponAmmo(player, 250);

                    WereHouseData[index].gun_units[slotid] -= 1;
                    if (WereHouseData[index].gun_units[slotid] == 0)
                    {
                        NAPI.Notification.SendNotificationToPlayer(player, "Du hast die letzte~w~ Einheit aus~g~" + WereHouseData[index].gun[slotid] + "~w~ dem - Tresor Ihrer Gruppe genommen.");

                        WereHouseData[index].gun[slotid] = "undefiniert";
                        WereHouseData[index].gun_units[slotid] = 0;
                        WereHouseData[index].gun_perm[slotid] = 0;
                    }
                    else NAPI.Notification.SendNotificationToPlayer(player, "Du hast eine ~g~" + WereHouseData[index].gun[slotid] + "~w~  aus dem Arsenal genommen.");
                    SaveWerehouse(index);
                    ShowWarehouseMenu(player);
                }
                else
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "Sie dürfen dieses Gerät nicht nur verwenden~c~" + FactionManage.faction_data[gangid].faction_rank[WereHouseData[index].gun_perm[slotid]] + " (" + WereHouseData[index].gun_perm[slotid] + ")~w~ oder höher");
                    ShowWarehouseMenu(player);
                }
            }
            else
            {
                List<string> model_list = new List<string>();
                List<string> price_list = new List<string>();
                List<string> permi_list = new List<string>();

                int countIndex = 0;
                foreach (var order in weapon_order_list)
                {
                    if(order.permission == 0)
                    {
                        model_list.Add(Convert.ToString(order.order_model));
                        price_list.Add(Convert.ToString(order.order_price));
                    }

                    if(WereHouseData[index].type == HQ_TYPE_WEAPONS && order.permission == 1)
                    {
                        model_list.Add(Convert.ToString(order.order_model));
                        price_list.Add(Convert.ToString(order.order_price));
                    }
    
                    countIndex++;
                }

                for (int i = 0; i < 6; i++)
                {
                    permi_list.Add(FactionManage.faction_data[AccountManage.GetPlayerGroup(player)].faction_rank[i]);
                }

                List<string> list = new List<string>();
                list.Add("1 Einheiten");
                list.Add("2 Einheiten");
                list.Add("3 Einheiten");
                list.Add("4 Einheiten");

                player.SetData("werehouse_order_weapon", 0);
                player.SetData("werehouse_order_units", 0);
                player.SetData("werehouse_order_perm", 0);

                UpdateOrderPrice(player);

                List<dynamic> menu_item_list = new List<dynamic>();
                menu_item_list.Add(new { Type = 6, Name = "Waffen", Description = "Wählen Sie den gewünschten Waffentyp aus.", List = model_list, StartIndex = 0 });
                menu_item_list.Add(new { Type = 6, Name = "Menge", Description = "Wählen Sie die Anzahl der Waffen,die Sie in der Reihenfolge erhalten möchten.", List = list, StartIndex = 0 });
                menu_item_list.Add(new { Type = 6, Name = "Ab welchen Rang", Description = "Die Waffe genutz werden darf.", List = permi_list, StartIndex = 0 });
                menu_item_list.Add(new { Type = 1, Name = "Ausrüstung bestellen", Description = "Wählen Sie diese Option,um Ihre Ausrüstung zu bestellen." });

                InteractMenu.CreateMenu(player, "WEREHOSE_MENU_ORDER_PURCHASE", "Menü", "~b~Lager", true, JsonConvert.SerializeObject(menu_item_list), false);
            }
        }
        else if(callbackId == "WEREHOSE_MENU_ORDER_PURCHASE")
        {

            Main.DisplaySubtitle(player, " ", 1);
            int index = player.GetData("EditingArmazemID");
            int gangid = player.GetData("EditingArmazemGroupID");
            int slotid = player.GetData("EditingArmazemSlotID");

            int send_price = 999999999, send_units = 1, current_weapon = player.GetData("werehouse_order_weapon");
            switch (player.GetData("werehouse_order_units"))
            {
                case 0: { send_units = 1; send_price = 1 * weapon_order_list[current_weapon].order_price; break; }
                case 1: { send_units = 2; send_price = 2 * weapon_order_list[current_weapon].order_price; break; }
                case 2: { send_units = 3; send_price = 3 * weapon_order_list[current_weapon].order_price; break; }
                case 3: { send_units = 4; send_price = 4 * weapon_order_list[current_weapon].order_price; break; }
            }

            string modelo = weapon_order_list[current_weapon].order_model;
            int preco = send_price;
            int unidades = send_units;
            int permissao = player.GetData("werehouse_order_perm");

            if (WereHouseData[index].safe > preco)
            {
                WereHouseData[index].gun[slotid] = modelo;
                WereHouseData[index].gun_units[slotid] = unidades;
                WereHouseData[index].gun_perm[slotid] = permissao;

                WereHouseData[index].safe -= preco;
                SaveWerehouse(index);

                NAPI.Notification.SendNotificationToPlayer(player, "Du hast bestellt ~g~" + unidades + "~w~ Einheiten von ~b~" + modelo + "~w~ von~g~$" + preco.ToString("N0") + "~w~.");
                NAPI.Notification.SendNotificationToPlayer(player, "Die Bestellung kann jetzt im Lager-Laptop verwendet werden.");
            }
            else
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Sorry, aber der Gang deiner Bande kann es sich nicht leisten.");
            }
        }
        else if(callbackId == "WEREHOSE_MENU_SAFE_EQUIPMENT")
        {
            int slotid = selectedIndex;
            int index = player.GetData("EditingArmazemID");

            if (WereHouseData[index].safe_gun[slotid] == "undefiniert")
            {
                WeaponHash model = NAPI.Player.GetPlayerCurrentWeapon(player);
                if (model != NAPI.Util.WeaponNameToModel("Unarmed"))
                {
                    WereHouseData[index].safe_gun[slotid] = "" + model + "";
                    //NAPI.Player.RemovePlayerWeapon(player, model);
                    NAPI.Notification.SendNotificationToPlayer(player, "Sie haben eine gespeichert ~g~" + model + "~w~ im Gangschrank.");
                    SaveWerehouse(index);
                    ShowWarehouseMenu(player);
                }
                else
                {
                    ShowWarehouseMenu(player);
                    NAPI.Notification.SendNotificationToPlayer(player, "Sie brauchen die Waffe, die Sie behalten möchten.");
                }
            }
            else
            {
                WeaponHash model = NAPI.Util.WeaponNameToModel(WereHouseData[index].safe_gun[slotid]);
                WeaponManage.GivePlayerWeaponEx(player, WereHouseData[index].safe_gun[slotid], 250);
                NAPI.Player.SetPlayerCurrentWeaponAmmo(player, 250);
                WereHouseData[index].safe_gun[slotid] = "undefiniert";
                NAPI.Notification.SendNotificationToPlayer(player, "Du hast eine ~g~" + model + "~w~ im Schrank der Bande.");
                SaveWerehouse(index);
                ShowWarehouseMenu(player);
            }
        }
    }

    public static void UpdateOrderPrice(Client player)
    {
        int send_price = 999999999, current_weapon = player.GetData("werehouse_order_weapon");
        switch (player.GetData("werehouse_order_units"))
        {
            case 0: { send_price = 1 * weapon_order_list[current_weapon].order_price; break; }
            case 1: { send_price = 2 * weapon_order_list[current_weapon].order_price; break; }
            case 2: { send_price = 3 * weapon_order_list[current_weapon].order_price; break; }
            case 3: { send_price = 4 * weapon_order_list[current_weapon].order_price; break; }
        }
        Main.DisplaySubtitle(player, "Aktueller Wert der Bestellung ~c~"+ weapon_order_list[current_weapon].order_model + "~w~: ~g~$~w~" + send_price + "", 60);
    }

    public static void ListItemMenuResponse(Client player, String callbackId, int selectedIndex, String objectName, String valueList, int valueIndex)
    {
        if (callbackId == "WEREHOSE_MENU_ORDER_PURCHASE")
        {
            switch (objectName)
            {
                case "Waffen":
                    {
                        int index = 0;
                        foreach (var perm in weapon_order_list)
                        {
                            if (perm.order_model == valueList)
                            {
                                player.SetData("werehouse_order_weapon", index);
                                return;
                            }
                            index++;
                        }

                        UpdateOrderPrice(player);
                        break;
                    }
                case "Menge":
                    {
                        player.SetData("werehouse_order_units", valueIndex);
                        UpdateOrderPrice(player);
                        break;
                    }
                case "Ab welchen Rang":
                    {
                        player.SetData("werehouse_order_perm", valueIndex);
                        UpdateOrderPrice(player);
                        break;
                    }
            }
        }
    }


    public static void OnInputResponse(Client player, String response, String inputtext)
    {
        if(response == "input_werehouse_deposit")
        {
            if (!Main.IsNumeric(inputtext))
            {
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Ungültiger eingegebener Wert.", 5000);
                return;
            }
            int value = Convert.ToInt32(inputtext);

            int gangid = player.GetData("EditingArmazemID");
            if (inputtext.Contains("-"))
            {
                return;
            }

            if (value < 1 && value > 1000000)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Der Einzahlungsbetrag sollte zwischen 1 und 1000000 liegen.");
                ShowWarehouseMenu(player);
            }
            else
            {
                if (Inventory.GetPlayerItemFromInventory(player, 158) < value)
                {
                    Main.DisplayErrorMessage(player, "Du hast nicht genug Liberty Dollor.");
                    return;
                }
                if (Inventory.GetPlayerItemFromInventory(player, 158) > value)
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "Du hast eingezahlt~g~$" + value.ToString("N0") + "~w~ an die Gang sicher.");
                    Inventory.GiveItemToInventory(player, 158, -value);
                    WereHouseData[gangid].safe += value;
                    SaveWerehouse(gangid);
                    ShowWarehouseMenu(player);
                }
                else
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "Sie haben nicht alles Geld.");
                    ShowWarehouseMenu(player);
                }

            }
        }
        else if(response == "input_werehouse_withdraw")
        {
            if (!Main.IsNumeric(inputtext))
            {
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Ungültiger Wert eingeben.", 5000);
                return;
            }
            int value = Convert.ToInt32(inputtext);

            int gangid = player.GetData("EditingArmazemID");


            if (value < 1 && value > 1000000)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Umhüllungsmenge muss zwischen 1 und 1.000.000 liegen.");
                ShowWarehouseMenu(player);
            }
            else
            {
                if (WereHouseData[gangid].safe > value)
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "Sie haben sich zurückgezogen ~g~$" + value.ToString("N0") + "~w~ die Gang sicher.");
                    Inventory.GiveItemToInventory(player, 158, +value);
                    WereHouseData[gangid].safe -= value;
                    SaveWerehouse(gangid);
                    ShowWarehouseMenu(player);
                }
                else
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "Der Gang Safe hat nicht das Geld.");
                    ShowWarehouseMenu(player);
                }
            }
        }
    }

    public static void OnMenuReturnClose(Client player, String callbackId)
    {
        if(callbackId == "WEREHOSE_MENU_ORDER_PURCHASE" || callbackId == "WEREHOSE_MENU_ORDER_EQUIPMENT" || callbackId == "WEREHOSE_MENU_SAFE" || callbackId == "WEREHOSE_MENU_SAFE_EQUIPMENT")
        {
            ShowWarehouseMenu(player);
        }
    }

    public static int GetArmazemFreeSlotID()
    {
        int index = 0;
        foreach (var armazem in WereHouseData)
        {
            if (armazem.name == "undefiniert")
            {
                return index;
            }
            index++;
        }
        return -1;
    }


    [Command("criararmazem", "/criararmazem [preco] [maconha/cocaina/metanfetamina/armas]")]
    public void CMD_criararmazem(Client player, int preco, string interior)
    {
        if (AccountManage.GetPlayerAdmin(player) < adminCommands.COORDENADOR)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben keine Berechtigung, diesen Befehl zu verwenden.");
            return;
        }
        int i = GetArmazemFreeSlotID();

        if (i == -1) { NAPI.Notification.SendNotificationToPlayer(player, "Kein Lager mehr verfügbar .."); return; }

        WereHouseData[i].price = preco;
        WereHouseData[i].exterior_x = player.Position.X;
        WereHouseData[i].exterior_y = player.Position.Y;
        WereHouseData[i].exterior_z = player.Position.Z;
        WereHouseData[i].exterior_a = player.Rotation.Z;
        WereHouseData[i].ownerid = -1;
        WereHouseData[i].safe = 0;

        if (WereHouseData[i].exterior_x != 0 && WereHouseData[i].exterior_y != 0)
        {
            NAPI.Blip.SetBlipName(WereHouseData[i].exteriorBlip, "Fraktion HQ");
            if (WereHouseData[i].type == HQ_TYPE_WEED)
            {
                NAPI.Blip.SetBlipSprite(WereHouseData[i].exteriorBlip, 501);
            }
            else if (WereHouseData[i].type == HQ_TYPE_META)
            {
                NAPI.Blip.SetBlipSprite(WereHouseData[i].exteriorBlip, 501);
            }
            else if (WereHouseData[i].type == HQ_TYPE_COCAINE)
            {
                NAPI.Blip.SetBlipSprite(WereHouseData[i].exteriorBlip, 514);
            }
            else if (WereHouseData[i].type == HQ_TYPE_WEAPONS)
            {
                NAPI.Blip.SetBlipSprite(WereHouseData[i].exteriorBlip, 501);
            }
            NAPI.Blip.SetBlipShortRange(WereHouseData[i].exteriorBlip, true);
            NAPI.Blip.SetBlipColor(WereHouseData[i].exteriorBlip, 51);
        }
        NAPI.Blip.SetBlipTransparency(WereHouseData[i].exteriorBlip, 255);

        if (interior == "maconha")
        {

            WereHouseData[i].name = "Vivero";

            WereHouseData[i].interior_x = 1066.045f;
            WereHouseData[i].interior_y = -3183.432f;
            WereHouseData[i].interior_z = -39.16352f;
            WereHouseData[i].interior_a = 89.57901f;

            WereHouseData[i].menu_x = 1044.505f;
            WereHouseData[i].menu_y = -3194.785f;
            WereHouseData[i].menu_z = -38.15811f;


            WereHouseData[i].type = HQ_TYPE_WEED;
        }
        else if (interior == "metanfetamina")
        {
            WereHouseData[i].name = "Los Pollos";

            WereHouseData[i].interior_x = 997.0402f;
            WereHouseData[i].interior_y = -3200.761f;
            WereHouseData[i].interior_z = -36.39373f;
            WereHouseData[i].interior_a = 1.589574f;

            WereHouseData[i].menu_x = 1002.019f;
            WereHouseData[i].menu_y = -3194.924f;
            WereHouseData[i].menu_z = -38.99313f;

            WereHouseData[i].type = HQ_TYPE_META;

        }
        else if (interior == "cocaina")
        {

            WereHouseData[i].name = "Farmacia";

            WereHouseData[i].interior_x = 1088.689f;
            WereHouseData[i].interior_y = -3187.844f;
            WereHouseData[i].interior_z = -38.99347f;
            WereHouseData[i].interior_a = 176.7773f;

            WereHouseData[i].menu_x = 1087.198f;
            WereHouseData[i].menu_y = -3194.242f;
            WereHouseData[i].menu_z = -38.99347f;

            WereHouseData[i].type = HQ_TYPE_COCAINE;
        }
        else if (interior == "armas")
        {
            WereHouseData[i].name = "Trabajo de fuego";

            WereHouseData[i].interior_x = 981.3119f;
            WereHouseData[i].interior_y = -102.4228f;
            WereHouseData[i].interior_z = 74.84509f;
            WereHouseData[i].interior_a = 46.5757f;

            WereHouseData[i].menu_x = 983.9806f;
            WereHouseData[i].menu_y = -90.85281f;
            WereHouseData[i].menu_z = 74.84863f;

            WereHouseData[i].type = HQ_TYPE_WEAPONS;
        }

        NAPI.TextLabel.CreateTextLabel("~g~-~y~ Computer", new Vector3(WereHouseData[i].menu_x, WereHouseData[i].menu_y, WereHouseData[i].menu_z - 0.2f), 8.0f, 0.8f, 4, new Color(255, 255, 255, 255));


        UpdateWerehousePickup(i);
        SaveWerehouse(i);
    }

    [Command("editararmazem", "/editararmazem [armazem id] [nome(nome/preco/exterior/interior/cofre/delete)] [valor(ifnecessary)] ~c~(para encontrar id Frei use ~w~/proximowerehouse~c~)")]
    public void CMD_editararmazem(Client player, int index, string nome, string value = "undefiniert")
    {
        if (AccountManage.GetPlayerAdmin(player) < adminCommands.COORDENADOR)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben keine Berechtigung, diesen Befehl zu .");
            return;
        }
        if (nome == "exterior")
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben die Außenseite des ID - Speichers bearbeitet " + index + ".");
            WereHouseData[index].exterior_x = player.Position.X;
            WereHouseData[index].exterior_y = player.Position.Y;
            WereHouseData[index].exterior_z = player.Position.Z;
            WereHouseData[index].exterior_a = player.Rotation.Z;
            if (WereHouseData[index].exterior_x != 0 && WereHouseData[index].exterior_y != 0)
            {
                NAPI.Blip.SetBlipName(WereHouseData[index].exteriorBlip, "Fraktion HQ");
                if (WereHouseData[index].type == HQ_TYPE_WEED)
                {
                    NAPI.Blip.SetBlipSprite(WereHouseData[index].exteriorBlip, 501);
                }
                else if (WereHouseData[index].type == HQ_TYPE_META)
                {
                    NAPI.Blip.SetBlipSprite(WereHouseData[index].exteriorBlip, 499);
                }
                else if (WereHouseData[index].type == HQ_TYPE_COCAINE)
                {
                    NAPI.Blip.SetBlipSprite(WereHouseData[index].exteriorBlip, 514);
                }
                else if (WereHouseData[index].type == HQ_TYPE_WEAPONS)
                {
                    NAPI.Blip.SetBlipSprite(WereHouseData[index].exteriorBlip, 494);
                }
                NAPI.Blip.SetBlipShortRange(WereHouseData[index].exteriorBlip, true);
                NAPI.Blip.SetBlipColor(WereHouseData[index].exteriorBlip, 59);
            }
            NAPI.Blip.SetBlipTransparency(WereHouseData[index].exteriorBlip, 255);
            UpdateWerehousePickup(index);
            SaveWerehouse(index);
        }
        else if (nome == "interior")
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben das Innere des ID - Speichers bearbeitet " + index + ".");
            WereHouseData[index].interior_x = player.Position.X;
            WereHouseData[index].interior_y = player.Position.Y;
            WereHouseData[index].interior_z = player.Position.Z;
            WereHouseData[index].interior_a = player.Rotation.Z;
            UpdateWerehousePickup(index);
            SaveWerehouse(index);
        }
        else if (nome == "nome")
        {
            if (value == "undefiniert")
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Der Name darf nicht null sein.");
                return;
            }
            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben den ID Store-Namen bearbeitet " + index + " zu" + value + ".");
            WereHouseData[index].name = value;
            UpdateWerehousePickup(index);
            SaveWerehouse(index);
        }
        else if (nome == "preco")
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben den ID - Warehouse - Preis bearbeitet " + index + " zu $" + Convert.ToInt32(value).ToString("N0") + ".");
            WereHouseData[index].price = Convert.ToInt32(value);
            UpdateWerehousePickup(index);
            SaveWerehouse(index);
        }
        else if (nome == "cofre")
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben den ID-Speichertresor bearbeitet " + index + " zu " + Convert.ToInt32(value).ToString("N0") + ".");
            WereHouseData[index].safe = Convert.ToInt32(value);
            UpdateWerehousePickup(index);
            SaveWerehouse(index);
        }
        else if (nome == "delete")
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben das ID-Warehouse gelöscht " + index + ".");
            WereHouseData[index].name = "undefiniert";

            WereHouseData[index].ownerid = -1;
            WereHouseData[index].safe = 0;

            NAPI.Blip.SetBlipTransparency(WereHouseData[index].exteriorBlip, 0);

            WereHouseData[index].exterior_x = 0;
            WereHouseData[index].exterior_y = 0;
            WereHouseData[index].exterior_z = 0;
            WereHouseData[index].exterior_a = 0;

            WereHouseData[index].interior_x = 0;
            WereHouseData[index].interior_y = 0;
            WereHouseData[index].interior_z = 0;
            WereHouseData[index].interior_a = 0;

            for (int i = 0; i < 20; i++)
            {
                WereHouseData[index].gun[i] = "undefiniert";
                WereHouseData[index].gun_units[i] = 0;
                WereHouseData[index].gun_perm[i] = 0;
                WereHouseData[index].safe_gun[i] = "undefiniert";
            }

            UpdateWerehousePickup(index);
            SaveWerehouse(index);
        }
    }

    [Command("proximoarmazem")]
    public void CMD_warehouse(Client player)
    {
        if (AccountManage.GetPlayerAdmin(player) < 2)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben keine Berechtigung, diesen Befehl zu verwenden.");
            return;
        }
        NAPI.Notification.SendNotificationToPlayer(player, "Die nächste verfügbare Store - ID ist ~y~" + GetArmazemFreeSlotID() + "~w~.");
    }

    [Command("pertoarmazem")]
    public void CMD_nearwerehouse(Client player)
    {
        if (AccountManage.GetPlayerAdmin(player) < 2)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben keine Berechtigung, diesen Befehl zu verwenden.");
            return;
        }
        int index = 0;
        foreach(var werehouse in WereHouseData)
        {
            if(Main.IsInRangeOfPoint(player.Position, werehouse.exteriorLabel.Position, 50.0f))
            {
                NAPI.Notification.SendNotificationToPlayer(player,"Das ID - Warehouse ~c~" + index + "~w~ es ist um " + player.Position.DistanceTo(werehouse.exteriorLabel.Position) + " Meter von Ihnen entfernt.");

            }
            index++;
        }
        if(index == 0)
        {
            NAPI.Notification.SendNotificationToPlayer(player,"Haben Sie niemanden in Ihrer Nähe.");
        }
    }

    [Command("kaufenhq")]
    public void CMD_comprararmazem(Client player)
    {
        if (FactionManage.GetPlayerGroupType(player) == 4 || FactionManage.GetPlayerGroupType(player) == 7)
        {
            int index = 0;
            foreach (var armazem in WereHouseData)
            {
                if (Main.IsInRangeOfPoint(player.Position, new Vector3(armazem.exterior_x, armazem.exterior_y, armazem.exterior_z), 3))
                {
                    foreach (var pl in WereHouseData)
                    {
                        if (pl.ownerid == AccountManage.GetPlayerGroup(player))
                        {
                            NAPI.Notification.SendNotificationToPlayer(player, "Deine Gang kann nicht mehr als ein Lager haben!!");
                            return;
                        }
                    }

                    if (armazem.ownerid != -1)
                    {
                        NAPI.Notification.SendNotificationToPlayer(player, "Leider konnte dieses Lager nicht gekauft werden, da es bereits ein Besitzer hat.");
                        return;
                    }

                    if (Inventory.GetPlayerItemFromInventory(player, 158) < armazem.price)
                    {
                        Main.DisplayErrorMessage(player, "Du hast nicht genug Liberty Dollor.");
                        return;
                    }

                    if (Inventory.GetPlayerItemFromInventory(player, 158) > armazem.price)
                    {
                        armazem.ownerid = AccountManage.GetPlayerGroup(player);
                        NAPI.Notification.SendNotificationToPlayer(player, "Sie haben das Lager gekauft. " + armazem.name + " zu ~g~$" + armazem.price.ToString("N0") + ".");
                        NAPI.Notification.SendNotificationToPlayer(player, "Deine Bande kann jetzt Waffen lagern, unteranderem auch Liberty Dollor.");
                        UpdateWerehousePickup(index);
                        SaveWerehouse(index);
                        Inventory.GiveItemToInventory(player, 158, -armazem.price);
                        return;
                    }
                    else NAPI.Notification.SendNotificationToPlayer(player, "Leider haben Sie nicht genug Liberty Dollor, um dieses Lagerhaus zu kaufen.");
                }
                index++;
            }
        }
        else NAPI.Notification.SendNotificationToPlayer(player, "Sie können diesen Befehl nicht verwenden, sondern nur den Besitzer der Bande.");
    }
    [Command("abandonararmazem")]
    public void CMD_abandonararmazem(Client player)
    {
        int index = 0;
        foreach (var armazem in WereHouseData)
        {
            if (Main.IsInRangeOfPoint(player.Position, new Vector3(armazem.exterior_x, armazem.exterior_y, armazem.exterior_z), 3))
            {
                if(AccountManage.GetPlayerLeader(player) == armazem.ownerid)
                {

                    NAPI.Notification.SendNotificationToPlayer(player, "Sie haben Ihr Lager verlassen und 1 / 3 des Kaufpreises erhalten~g~$"+armazem.price / 3+"~w~.");
                    armazem.safe = 0;
                    armazem.ownerid = -1;

                    for (int i = 0; i < 20; i++)
                    {
                        armazem.gun[i] = "undefiniert";
                        armazem.gun_units[i] = 0;
                        armazem.gun_perm[i] = 0;
                        armazem.safe_gun[i] = "undefiniert";
                    }
                    UpdateWerehousePickup(index);
                    SaveWerehouse(index);
                }
                else NAPI.Notification.SendNotificationToPlayer(player, "Sie sind nicht Eigentümer dieses Lagers.");
                return;
            }
            index++;
        }
        NAPI.Notification.SendNotificationToPlayer(player, "Sie müssen sich oben auf dem Wareneingang befinden.");
    }
    [Command("trancararmazem")]
    public void CMD_trancar(Client player)
    {
        foreach (var armazem in WereHouseData)
        {
            if (Main.IsInRangeOfPoint(player.Position, new Vector3(armazem.exterior_x, armazem.exterior_y, armazem.exterior_z), 3) || Main.IsInRangeOfPoint(player.Position, new Vector3(armazem.interior_x, armazem.interior_y, armazem.interior_z), 3))
            {
                if(armazem.ownerid == AccountManage.GetPlayerGroup(player))
                {
                    if(armazem.lockStatus == true)
                    {
                        armazem.lockStatus = false;
                        NAPI.Notification.SendNotificationToPlayer(player, "Du ~g~freigeschaltet~w~ die Warentür für die Öffentlichkeit.");
                    }
                    else
                    {
                        armazem.lockStatus = true;
                        NAPI.Notification.SendNotificationToPlayer(player, "Du trancou~w~ die Warentür für die Öffentlichkeit.");
                    }
                    return;
                }
            }
        }
                
    }



    //
    // Inventory
    //
    public static void LoadInventoryItens(int house_id)
    {
        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {
            Mainpipeline.Open();
            MySqlCommand query = new MySqlCommand("SELECT * FROM `inventory_hq` WHERE `owner` = '" + WereHouseData[house_id].id + "';", Mainpipeline);

            using (MySqlDataReader reader = query.ExecuteReader())
            {
                string data2txt = string.Empty;
                string datatxt = string.Empty;

                while (reader.Read())
                {
                    if (reader.GetInt32("amount") == 0)
                    {
                        Main.CreateMySqlCommand("DELETE FROM `inventory_hq` WHERE `id` = '" + reader.GetInt32("id") + "';");
                        continue;
                    }

                    SendItemFromSQLtoInventory(house_id, reader.GetInt32("id"), reader.GetInt32("type"), reader.GetInt32("amount"));
                }
            }
        }
    }

    public static void SendItemFromSQLtoInventory(int house_id, int sql_id, int type, int amount = 1)
    {
        for (int index = 0; index < MAX_INVENTORY_ITENS; index++)
        {
            if (WereHouseData[house_id].inventory_type[index] == type)
            {
                WereHouseData[house_id].inventory_amount[index] = amount;
                return;
            }
        }

        for (int index = 0; index < MAX_INVENTORY_ITENS; index++)
        {
            if (WereHouseData[house_id].inventory_index[index] == -1)
            {
                WereHouseData[house_id].inventory_index[index] = sql_id;
                WereHouseData[house_id].inventory_type[index] = type;
                WereHouseData[house_id].inventory_amount[index] = amount;
                return;
            }
        }
    }

    public static void GiveItemToInventory(int house_id, int type, int amount = 1)
    {
        for (int index = 0; index < MAX_INVENTORY_ITENS; index++)
        {
            if (WereHouseData[house_id].inventory_type[index] == type)
            {
                WereHouseData[house_id].inventory_amount[index] += amount;
                Main.CreateMySqlCommand("UPDATE inventory_hq SET `amount` = " + WereHouseData[house_id].inventory_amount[index] + " WHERE `id` = " + WereHouseData[house_id].inventory_index[index] + "");
                return;
            }
        }

        for (int index = 0; index < MAX_INVENTORY_ITENS; index++)
        {
            if (WereHouseData[house_id].inventory_index[index] == -1)
            {
                using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
                {
                    try
                    {
                        Mainpipeline.Open();
                        string query = "INSERT INTO inventory_hq (`owner`, `type`, `amount`)" + " VALUES ('" + house_id + "', '" + type + "', '" + amount + "')";
                        MySqlCommand myCommand = new MySqlCommand(query, Mainpipeline);
                        myCommand.ExecuteNonQuery();
                        long last_inventory_id = myCommand.LastInsertedId;

                        WereHouseData[house_id].inventory_index[index] = Convert.ToInt32(last_inventory_id);
                        WereHouseData[house_id].inventory_type[index] = type;
                        WereHouseData[house_id].inventory_amount[index] = amount;
                    }
                    catch (Exception ex)
                    {
                        //NAPI.Util.ConsoleOutput("[EXCEPTION GiveItemToInventory] " + ex.Message);
                        //NAPI.Util.ConsoleOutput("[EXCEPTION GiveItemToInventory] " + ex.StackTrace);
                    }
                }
                return;
            }
        }
    }

    public static void RemoveItemFromInventory(int house_id, int index, int amount = 0)
    {
        if (WereHouseData[house_id].inventory_amount[index] >= 2)
        {
            WereHouseData[house_id].inventory_amount[index] -= amount;
            Main.CreateMySqlCommand("UPDATE inventory_hq SET `amount` = " + WereHouseData[house_id].inventory_amount[index] + " WHERE `id` = " + WereHouseData[house_id].inventory_index[index] + "");

            if (WereHouseData[house_id].inventory_amount[index] < 1)
            {
                Main.CreateMySqlCommand("DELETE FROM `inventory_hq` WHERE `id` = '" + WereHouseData[house_id].inventory_index[index] + "';");

                WereHouseData[house_id].inventory_index[index] = -1;
                WereHouseData[house_id].inventory_type[index] = 0;
                WereHouseData[house_id].inventory_amount[index] = 0;
            }
        }
        else
        {
            Main.CreateMySqlCommand("DELETE FROM `inventory_hq` WHERE `id` = '" + WereHouseData[house_id].inventory_index[index] + "';");

            WereHouseData[house_id].inventory_index[index] = -1;
            WereHouseData[house_id].inventory_type[index] = 0;
            WereHouseData[house_id].inventory_amount[index] = 0;
        }
    }

    public static void ClearInventory(int house_id)
    {
        for (int i = 0; i < MAX_INVENTORY_ITENS; i++)
        {
            WereHouseData[house_id].inventory_index[i] = -1;
            WereHouseData[house_id].inventory_type[i] = 0;
            WereHouseData[house_id].inventory_amount[i] = 0;
        }

        Main.CreateMySqlCommand("DELETE FROM `inventory_hq` WHERE `owner` = '" + house_id + "';");
    }

    public static void ResetInventoryVariables(int house_id)
    {
        for (int i = 0; i < MAX_INVENTORY_ITENS; i++)
        {
            WereHouseData[house_id].inventory_index[i] = -1;
            WereHouseData[house_id].inventory_type[i] = 0;
            WereHouseData[house_id].inventory_amount[i] = 0;
        }
    }

    public static int GetInventoryIndexFromType(int house_id, int type)
    {
        int slot = -1;
        for (int index = 0; index < MAX_INVENTORY_ITENS; index++)
        {
            if (WereHouseData[house_id].inventory_type[index] == type)
            {
                slot = index;
            }
        }
        return slot;
    }

    public static int GetPlayerItemFromInventory(int house_id, int type)
    {
        int amount = 0;
        for (int index = 0; index < MAX_INVENTORY_ITENS; index++)
        {
            if (WereHouseData[house_id].inventory_type[index] == type)
            {
                amount = WereHouseData[house_id].inventory_amount[index];
            }
        }
        return amount;
    }


    public static int GetInventoryIndexFromName(int house_id, string name)
    {

        int index = 0, slot = -1;
        foreach (var item in Inventory.itens_available)
        {
            if (item.name == name)
            {
                slot = GetInventoryIndexFromType(house_id, index);
            }
            index++;
        }
        return slot;
    }

    public static void RemoveItem(int house_id, string itemName, int amount)
    {
        int index = 0;
        foreach (var item in Inventory.itens_available)
        {
            if (item.name == itemName)
            {
                RemoveItemFromInventory(house_id, GetInventoryIndexFromType(house_id, index), amount);
                return;
            }
            index++;
        }
    }


    [Command("hqcofre")]
    public static void ShowHouseInventory(Client player)
    {
        int house_index = 0;
        foreach (var entrace in WereHouseData)
        {
            if (Main.IsInRangeOfPoint(player.Position, new Vector3(entrace.interior_x, entrace.interior_y, entrace.interior_z), 70.0f) && player.Dimension == (uint)house_index + 500)
            {
                if (entrace.ownerid != AccountManage.GetPlayerGroup(player))
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "Nur Mitglieder dieses Hauptquartiers können auf den Safe zugreifen.");
                    return;
                }

                if (Main.IsInRangeOfPoint(player.Position, new Vector3(1031.024, -3203.098, -38.19354), 2.0f) || Main.IsInRangeOfPoint(player.Position, new Vector3(1017.242, -3198.394, -38.99321), 2.0f) || Main.IsInRangeOfPoint(player.Position, new Vector3(977.1298, -104.1134, 74.84519), 2.0f) || Main.IsInRangeOfPoint(player.Position, new Vector3(1096.997, -3192.923, -38.99346), 2.0f))
                {
                    if(WereHouseData[house_index].using_inventory == true)
                    {
                        NAPI.Notification.SendNotificationToPlayer(player, "Es gibt bereits 1 Person, die auf dieses Inventar zugreift.");
                        return;
                    }

                    int playerid = Main.getIdFromClient(player);


                    List<dynamic> temp_inventory = new List<dynamic>();
                    for (int index = 0; index < Inventory.MAX_INVENTORY_ITENS; index++)
                    {
                        if (Inventory.player_inventory[playerid].sql_id[index] != -1)
                        {

                            int type = Inventory.player_inventory[playerid].type[index];

                            if (type > Inventory.itens_available.Count)
                            {
                                continue;
                            }

                            string new_category = "Diversos";
                            switch (Inventory.itens_available[type].guest)
                            {
                                case 0: new_category = "Diverses"; break;
                                case 1: new_category = "Verwendbar"; break;
                                case 2: new_category = "Munition"; break;
                                case 3: new_category = "Gast"; break;
                                case 4: new_category = "Diverses"; break;
                                default: new_category = "Diverses"; break;
                            }

                            temp_inventory.Add(new { name = Inventory.itens_available[type].name, type = type, description = Inventory.itens_available[type].description, amount = Inventory.player_inventory[playerid].amount[index], weight = Inventory.itens_available[type].weight, use_0 = "Usar Item", use_1 = "null", dontDisplayAmount = false, category = new_category });
                        }
                    }

                    //
                    List<dynamic> temp_storage_inventory = new List<dynamic>();
                    for (int index = 0; index < Inventory.MAX_INVENTORY_ITENS; index++)
                    {
                        if (WereHouseData[house_index].inventory_index[index] != -1)
                        {

                            int type = WereHouseData[house_index].inventory_type[index];

                            if (type > Inventory.itens_available.Count)
                            {
                                continue;
                            }

                            string new_category = "Diversos";
                            switch (Inventory.itens_available[type].guest)
                            {
                                case 0: new_category = "Diverses"; break;
                                case 1: new_category = "Verwendbar"; break;
                                case 2: new_category = "Munition"; break;
                                case 3: new_category = "Gast"; break;
                                case 4: new_category = "Diverses"; break;
                                default: new_category = "Diverses"; break;
                            }

                            temp_storage_inventory.Add(new
                            {
                                name = Inventory.itens_available[type].name,
                                type = type,
                                description = Inventory.itens_available[type].description,
                                amount = WereHouseData[house_index].inventory_amount[index],
                                weight = Inventory.itens_available[type].weight,
                                use_0 = "Benutze Item",
                                use_1 = "null",
                                dontDisplayAmount = false,
                                category = new_category
                            });
                        }
                    }

                    WereHouseData[house_index].using_inventory = true;


                    player.TriggerEvent("Display_HQ_Storage", NAPI.Util.ToJson(temp_inventory), NAPI.Util.ToJson(temp_storage_inventory), Inventory.GetInventoryMaxHeight(player), 20);

                    //player.SetData("using_inventory", true);
                }
                return;
            }
            house_index++;
        }
    }

    [RemoteEvent("HQ_Storage_Give_Item")]
    public static void UI_GiveItem(Client player, int type, string inputtext)
    {
        int house_index = 0, house_id = -1;
        foreach (var entrace in WereHouseData)
        {
            if (Main.IsInRangeOfPoint(player.Position, new Vector3(entrace.interior_x, entrace.interior_y, entrace.interior_z), 70.0f))
            {
                if (entrace.ownerid == AccountManage.GetPlayerGroup(player))
                {
                    house_id = house_index;
                }
            }
            house_index++;
        }

        if (house_id == -1)
        {
            return;
        }

        int playerid = Main.getIdFromClient(player);
        int index = Inventory.GetInventoryIndexFromType(player, type);

        if (Inventory.player_inventory[playerid].sql_id[index] == -1)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Ein unbekannter Fehler ist aufgetreten. (" + Inventory.player_inventory[playerid].sql_id[index] + " - " + index + " - " + Inventory.player_inventory[playerid].type[index] + ")");
            return;
        }

        if (Inventory.player_inventory[playerid].amount[index] > 1)
        {
            if (!Main.IsNumeric(inputtext))
            {
                return;
            }
            if (Inventory.player_inventory[playerid].sql_id[index] == -1)
            {
                return;
            }

            int amount = Convert.ToInt32(inputtext);


            if (Inventory.player_inventory[playerid].amount[index] < 1)
            {
                return;
            }

            if (Inventory.player_inventory[playerid].amount[index] < amount)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Sie haben diese Menge nicht in Ihrem Bestand.");
                return;
            }

            Inventory.RemoveItemFromInventory(player, index, amount);
            GiveItemToInventory(house_id, type, amount);

            ShowHouseInventory(player);

            List<Client> proxPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(15, player);
            foreach (Client alvo in proxPlayers)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "" + UsefullyRP.GetPlayerNameToTarget(player, alvo) + " gelegt in " + amount + "x " + Inventory.itens_available[type].name + "den HQ - Bestand.");
                //alvo.TriggerEvent("Send_ToChat", "", "<font color ='#C2A2DA'>* " + UsefullyRP.GetPlayerNameToTarget(player, alvo) + " gelegt in " + amount + "x " + Inventory.itens_available[type].name + "den HQ - Bestand.");
            }

        }
        else if (Inventory.player_inventory[playerid].amount[index] == 1)
        {
            Inventory.RemoveItemFromInventory(player, index, 1);
            GiveItemToInventory(house_id, type, 1);

            ShowHouseInventory(player);

            List<Client> proxPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(15, player);
            foreach (Client alvo in proxPlayers)
            {
                //alvo.TriggerEvent("Send_ToChat", "", "<font color ='#C2A2DA'>* " + UsefullyRP.GetPlayerNameToTarget(player, alvo) + " 1x gelegt in " + Inventory.itens_available[type].name + " den HQ - Bestand.");
                NAPI.Notification.SendNotificationToPlayer(player, "" + UsefullyRP.GetPlayerNameToTarget(player, alvo) + " 1x gelegt in " + Inventory.itens_available[type].name + " den HQ - Bestand.");
            }
            return;
        }
    }

    [RemoteEvent("HQ_Storage_Take_Item")]
    public static void UI_TakeItem(Client player, int type, string inputtext)
    {
        int house_index = 0, house_id = -1;
        foreach (var entrace in WereHouseData)
        {
            if (Main.IsInRangeOfPoint(player.Position, new Vector3(entrace.interior_x, entrace.interior_y, entrace.interior_z), 70.0f))
            {
                if (entrace.ownerid == AccountManage.GetPlayerGroup(player))
                {
                    house_id = house_index;
                }
            }
            house_index++;
        }

        if (house_id == -1)
        {
            return;
        }

        int playerid = Main.getIdFromClient(player);
        int index = GetInventoryIndexFromType(house_id, type);

        if (WereHouseData[house_id].inventory_amount[index] > 1)
        {
            if (!Main.IsNumeric(inputtext))
            {
                return;
            }

            int amount = Convert.ToInt32(inputtext);

            if (WereHouseData[house_id].inventory_amount[index] < 1)
            {
                return;
            }

            if (WereHouseData[house_id].inventory_amount[index] < amount)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Sie haben diese Menge nicht in Ihrem Bestand.");
                return;
            }

            if (Inventory.Check_InventoryWeight_With_ItemAmount(player, type, amount, Inventory.Max_Inventory_Weight(player)))
            {
                return;
            }


            Inventory.GiveItemToInventory(player, type, amount);
            RemoveItemFromInventory(house_id, index, amount);

            ShowHouseInventory(player);

            List<Client> proxPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(15, player);
            foreach (Client alvo in proxPlayers)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "" + UsefullyRP.GetPlayerNameToTarget(player, alvo) + " entfernt" + amount + "x " + Inventory.itens_available[type].name + " aus dem HQ Bestand.");
               // alvo.TriggerEvent("Send_ToChat", "", "<font color ='#C2A2DA'>* " + UsefullyRP.GetPlayerNameToTarget(player, alvo) + " entfernt" + amount + "x " + Inventory.itens_available[type].name + " aus dem HQ Bestand.");
            }

        }
        else if (WereHouseData[house_id].inventory_amount[index] == 1)
        {
            if (Inventory.Check_InventoryWeight_With_ItemAmount(player, type, 1, Inventory.Max_Inventory_Weight(player)))
            {
                return;
            }

            Inventory.GiveItemToInventory(player, type, 1);
            RemoveItemFromInventory(house_id, index, 1);

            ShowHouseInventory(player);

            List<Client> proxPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(15, player);
            foreach (Client alvo in proxPlayers)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "" + UsefullyRP.GetPlayerNameToTarget(player, alvo) + "  1x entfernt " + Inventory.itens_available[type].name + " aus dem HQ Bestand.");
                //alvo.TriggerEvent("Send_ToChat", "", "<font color ='#C2A2DA'>* " + UsefullyRP.GetPlayerNameToTarget(player, alvo) + "  1x entfernt " + Inventory.itens_available[type].name + " aus dem HQ Bestand.");
            }
            return;
        }

    }

    [RemoteEvent("Inventory_Close")]
    public static void Inventory_Close(Client player)
    {
        int house_index = 0;
        foreach (var entrace in WereHouseData)
        {
            if (Main.IsInRangeOfPoint(player.Position, new Vector3(entrace.interior_x, entrace.interior_y, entrace.interior_z), 70.0f))
            {
                if (entrace.ownerid == AccountManage.GetPlayerGroup(player))
                {
                    WereHouseData[house_index].using_inventory = false;
                }
            }
            house_index++;
        }
    }

}