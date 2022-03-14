using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;
using MySql.Data.MySqlClient;
using System.Data;
using System.Linq;
using System.Threading;
using Newtonsoft.Json;
using DerStr1k3r.Core;
using DerStr1k3r.SDK;


namespace DerStr1k3r.Core
{
    class Inventory : Script
    {
        public static int ITEM_TYPE_NONE = 0;
        public static int ITEM_TYPE_CONSUMIBLE = 1;
        public static int ITEM_TYPE_MUNITION = 2;
        public static int ITEM_TYPE_WORK = 3;
        public static int ITEM_TYPE_MISCELLANEOUS = 4;
        public static int ITEM_TYPE_WEAPON = 5;
        public static int ITEM_TYPE_MEDICITEM = 6;
        public static int ITEM_TYPE_CARKEY = 7;

        public static int MAX_INVENTORY_ITENS = 200;
        private static nLog Log = new nLog("Inventory");

        public enum ItemType
        {
            Mask = -1, // Маска
            Gloves = -3, // Перчатки
            Leg = -4, // Штанишки
            Bag = -5, // Рюкзачок
            Feet = -6, // Обуточки 
            Jewelry = -7, // Аксессуарчики всякие там
            Undershit = -8, // Рубашечки
            BodyArmor = -9, // Бронька
            Unknown = -10, // Вообще хер пойми что это
            Top = -11, // Верх
            Hat = -12, // Шляпы
            Glasses = -13, // Очочки
            Accessories = -14, // Часы/Браслеты

            ITEM_TYPE_NONE = 0,
            ITEM_TYPE_WATER = 1,
            ITEM_TYPE_BURGER = 2,
            ITEM_TYPE_AMMO_SNIPER_RIFLE = 3,
            ITEM_TYPE_AMMO_ASSAULT_RIFLE = 4,
            ITEM_TYPE_AMMO_SHOTGUN = 5,
            ITEM_TYPE_AMMO_PISTOL = 6,
            ITEM_TYPE_AMMO_SMG = 7,
            ITEM_TYPE_RESOURCES = 8,
            ITEM_TYPE_SMALL_BAG = 9,
            ITEM_TYPE_MEDIUM_BAG = 10,
            ITEM_TYPE_BIG_BAG = 11,
            ITEM_TYPE_WEED_SEEDS = 12,
            ITEM_TYPE_WEED = 13,
            ITEM_TYPE_SALT = 14,
            ITEM_TYPE_REFINED_SALT = 15,
            ITEM_TYPE_OPIUM = 16,
            ITEM_TYPE_HEROINA = 17,
            ITEM_TYPE_SEEDS = 18,
            ITEM_TYPE_DIRTY_MONEY = 19,
            ITEM_TYPE_C4 = 20,
            ITEM_TYPE_DRILL = 21,
            ITEM_TYPE_WEAPON = 22,
            ITEM_TYPE_MASK = 24,
            ITEM_TYPE_FISH_COMMON = 25,
            ITEM_TYPE_FISH_RARITY = 26,
            ITEM_TYPE_FISH_SUPER_RARITY = 27,
            ITEM_TYPE_FISH_EPIC = 28,
            ITEM_TYPE_GAS_CAN = 29,
            ITEM_TYPE_KEVLA_VEST = 30,

            /* Drinks */
            RusDrink1 = 31,
            RusDrink2 = 32,
            RusDrink3 = 33,

            YakDrink1 = 34,
            YakDrink2 = 35,
            YakDrink3 = 36,

            LcnDrink1 = 37,
            LcnDrink2 = 38,
            LcnDrink3 = 39,

            ArmDrink1 = 40,
            ArmDrink2 = 41,
            ArmDrink3 = 42,

            Material = 43

        }

        public class itemEnum : IEquatable<itemEnum>
        {
            public int id { get; set; }
            public string name { get; set; }
            public string icon { get; set; }
            public string description { get; set; }
            public float weight { get; set; }
            public int guest { get; set; }
            public uint hash { get; set; }
            public float position { get; set; }
            public bool Useable { get; set; }

            public override bool Equals(object obj)
            {
                if (obj == null) return false;
                itemEnum objAsPart = obj as itemEnum;
                if (objAsPart == null) return false;
                else return Equals(objAsPart);
            }
            public override int GetHashCode()
            {
                return id;
            }
            public bool Equals(itemEnum other)
            {
                if (other == null) return false;
                return (this.id.Equals(other.id));
            }
        }
        public static List<itemEnum> itens_available = new List<itemEnum>();
        public static List<dynamic> inventory_objects = new List<dynamic>();

        public class InventoryEnum : IEquatable<InventoryEnum>
        {
            public int id { get; set; }
            public int[] sql_id { get; set; } = new int[MAX_INVENTORY_ITENS];
            public int[] type { get; set; } = new int[MAX_INVENTORY_ITENS];
            public int[] amount { get; set; } = new int[MAX_INVENTORY_ITENS];
            public bool[] active { get; set; } = new bool[MAX_INVENTORY_ITENS];
            public string[] data { get; set; } = new string[MAX_INVENTORY_ITENS];

            public override bool Equals(object obj)
            {
                if (obj == null) return false;
                InventoryEnum objAsPart = obj as InventoryEnum;
                if (objAsPart == null) return false;
                else return Equals(objAsPart);
            }
            public override int GetHashCode()
            {
                return id;
            }
            public bool Equals(InventoryEnum other)
            {
                if (other == null) return false;
                return (this.id.Equals(other.id));
            }
        }

        public static List<InventoryEnum> player_inventory = new List<InventoryEnum>();

        public Inventory()
        {
            using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
            {
                Mainpipeline.Open();
                MySqlCommand query = new MySqlCommand("SELECT * FROM `inventory_items`;", Mainpipeline);

                using (MySqlDataReader reader = query.ExecuteReader())
                {
                    var index = 0;
                    while (reader.Read())
                    {
                        itens_available.Add(new itemEnum()
                        {
                            id = reader.GetInt32("id"),
                            icon = reader.GetString("icon"),
                            name = reader.GetString("name"),
                            Useable = false,
                            description = reader.GetString("description"),
                            guest = reader.GetInt32("guest"),
                            hash = reader.GetUInt32("hash"),
                            position = reader.GetFloat("position"),
                            weight = reader.GetFloat("weight"),
                        });

                        //if (player_inventory[index].id == -1)
                        //{}
                        index++;
                        //MAX_INVENTORY_ITENS++;
                    }
                }
            }

            for (int i = 0; i < Main.MAX_PLAYERS; i++)
            {
                player_inventory.Add(new InventoryEnum { id = i });
            }
        }


        public static void OnPlayerConnected(Client player)
        {
            int playerid = Main.getIdFromClient(player);
            for (int i = 0; i < MAX_INVENTORY_ITENS; i++)
            {
                player_inventory[playerid].sql_id[i] = -1;
                player_inventory[playerid].type[i] = 0;
                player_inventory[playerid].amount[i] = 0;
                player_inventory[playerid].data[i] = "";
                player_inventory[playerid].active[i] = false;
            }
        }

        public static void OnPlayerDisconnect(Client player)
        {
            int playerid = Main.getIdFromClient(player);
            for (int i = 0; i < MAX_INVENTORY_ITENS; i++)
            {
                player_inventory[playerid].sql_id[i] = -1;
                player_inventory[playerid].type[i] = 0;
                player_inventory[playerid].amount[i] = 0;
                player_inventory[playerid].data[i] = "";
                player_inventory[playerid].active[i] = false;
            }
        }

        public static void LoadPlayerInventoryItens(Client player)
        {
            using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
            {
                Mainpipeline.Open();
                MySqlCommand query = new MySqlCommand("SELECT * FROM `inventory` WHERE `owner` = '" + AccountManage.GetPlayerSQLID(player) + "';", Mainpipeline);

                using (MySqlDataReader reader = query.ExecuteReader())
                {
                    string data2txt = string.Empty;
                    string datatxt = string.Empty;
                    int playerid = Main.getIdFromClient(player);
                    while (reader.Read())
                    {
                        if (reader.GetInt32("amount") == 0)
                        {
                            Main.CreateMySqlCommand("DELETE FROM `inventory` WHERE `id` = '" + reader.GetInt32("id") + "';");
                            continue;
                        }

                        SendItemFromSQLtoInventory(player, reader.GetInt32("id"), reader.GetInt32("type"), reader.GetInt32("amount"));
                    }
                }
            }
        }

        public static void SendItemFromSQLtoInventory(Client player, int sql_id, int type, int amount = 1)
        {
            int playerid = Main.getIdFromClient(player);
            for (int index = 0; index < MAX_INVENTORY_ITENS; index++)
            {
                if (player_inventory[playerid].type[index] == type)
                {
                    player_inventory[playerid].amount[index] = amount;
                    return;
                }
            }

            for (int index = 0; index < MAX_INVENTORY_ITENS; index++)
            {
                if (player_inventory[playerid].sql_id[index] == -1)
                {
                    player_inventory[playerid].sql_id[index] = sql_id;
                    player_inventory[playerid].type[index] = type;
                    player_inventory[playerid].amount[index] = amount;
                    return;
                }
            }
        }

        public static void GiveItemToInventoryFromName(Client player, string item_name, int item_amount = 1, string data = "")
        {
            if (item_amount < 1)
            {
                return;
            }

            if (Item_Name_To_Type(item_name) == 255)
            {
                return;
            }

            GiveItemToInventory(player, Item_Name_To_Type(item_name), item_amount, data);
        }

        public static void GiveItemToInventory(Client player, int type, int amount = 1, string data = "")
        {
            int playerid = Main.getIdFromClient(player);
            for (int index = 0; index < MAX_INVENTORY_ITENS; index++)
            {
                if (player_inventory[playerid].type[index] == type)
                {
                    player_inventory[playerid].amount[index] += amount;
                    Main.CreateMySqlCommand("UPDATE inventory SET `amount` = " + player_inventory[playerid].amount[index] + " WHERE `id` = " + player_inventory[playerid].sql_id[index] + "");
                    return;
                }
            }

            for (int index = 0; index < MAX_INVENTORY_ITENS; index++)
            {
                if (player_inventory[playerid].sql_id[index] == -1)
                {
                    using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
                    {
                        try
                        {
                            Mainpipeline.Open();
                            string query = "INSERT INTO inventory (`owner`, `type`, `amount`)" + " VALUES ('" + AccountManage.GetPlayerSQLID(player) + "', '" + type + "', '" + amount + "')";
                            MySqlCommand myCommand = new MySqlCommand(query, Mainpipeline);
                            myCommand.ExecuteNonQuery();
                            long last_inventory_id = myCommand.LastInsertedId;

                            player_inventory[playerid].sql_id[index] = Convert.ToInt32(last_inventory_id);
                            player_inventory[playerid].type[index] = type;
                            player_inventory[playerid].amount[index] = amount;
                            player_inventory[playerid].data[index] = data;
                        }
                        catch (Exception ex)
                        {
                            NAPI.Util.ConsoleOutput("[EXCEPTION GiveItemToInventory] " + ex.Message);
                            NAPI.Util.ConsoleOutput("[EXCEPTION GiveItemToInventory] " + ex.StackTrace);
                        }
                    }
                    return;
                }
            }
        }

        public static void RemoveItemFromInventory(Client player, int index, int amount = 0)
        {
            int playerid = Main.getIdFromClient(player);
            if (player_inventory[playerid].amount[index] >= 2)
            {
                player_inventory[playerid].amount[index] -= amount;
                Main.CreateMySqlCommand("UPDATE inventory SET `amount` = " + player_inventory[playerid].amount[index] + " WHERE `id` = " + player_inventory[playerid].sql_id[index] + "");

                if (player_inventory[playerid].amount[index] < 1)
                {
                    Main.CreateMySqlCommand("DELETE FROM `inventory` WHERE `id` = '" + player_inventory[playerid].sql_id[index] + "';");


                    player_inventory[playerid].sql_id[index] = -1;
                    player_inventory[playerid].type[index] = 0;
                    player_inventory[playerid].amount[index] = 0;
                }
            }
            else
            {
                Main.CreateMySqlCommand("DELETE FROM `inventory` WHERE `id` = '" + player_inventory[playerid].sql_id[index] + "';");

                player_inventory[playerid].sql_id[index] = -1;
                player_inventory[playerid].type[index] = 0;
                player_inventory[playerid].amount[index] = 0;
            }
        }

        public static void ClearInventory(Client player)
        {
            int playerid = Main.getIdFromClient(player);
            for (int i = 0; i < MAX_INVENTORY_ITENS; i++)
            {
                player_inventory[playerid].sql_id[i] = -1;
                player_inventory[playerid].type[i] = 0;
                player_inventory[playerid].amount[i] = 0;
            }

            Main.CreateMySqlCommand("DELETE FROM `inventory` WHERE `owner` = '" + AccountManage.GetPlayerSQLID(player) + "';");
        }

        public static void ResetInventoryVariables(Client player)
        {
            int playerid = Main.getIdFromClient(player);
            for (int i = 0; i < MAX_INVENTORY_ITENS; i++)
            {
                player_inventory[playerid].sql_id[i] = -1;
                player_inventory[playerid].type[i] = 0;
                player_inventory[playerid].amount[i] = 0;
            }
        }

        public static int Item_Name_To_Type(string name)
        {
            foreach (var item in itens_available)
            {
                if (item.name == name)
                {
                    return item.id;
                }
            }
            return 255;
        }


        public static int InventoryTypeToID(int type)
        {
            int index = -1;
            foreach (var item in itens_available)
            {
                if (item.id == type)
                {
                    return item.id;
                }
            }
            return index;
        }


        public static void DropItemFromInventory(Client player, int index, string itemName, int amount)
        {

            int i = 0;
            foreach (var item in itens_available)
            {
                if (item.name == itemName)
                {
                    string unidade;
                    if (amount == 1) unidade = "Gegenstand";
                    else unidade = "Gegenstände";
                    inventory_objects.Add(new
                    {
                        item_type = player_inventory[Main.getIdFromClient(player)].type[index],
                        item_pos_x = player.Position.X,
                        item_pos_y = player.Position.Y,
                        item_pos_z = player.Position.Z,

                        item_amount = amount,

                        item_object_handle = NAPI.Object.CreateObject(item.hash, new Vector3(player.Position.X, player.Position.Y, player.Position.Z - item.position), new Vector3(0, 0, 0), 0),
                        item_label_handle = NAPI.TextLabel.CreateTextLabel("" + item.name + " (" + amount + " " + unidade + ")~n~Drücke ~c~E", new Vector3(player.Position.X, player.Position.Y, player.Position.Z - 0.54), 7, 0.35f, 4, new Color(255, 255, 255, 255))
                    });



                    RemoveItemFromInventory(player, index, amount);

                    // player.PlayAnimation("mp_weapon_drop", "drop_lh", 0);

                    NAPI.Player.PlayPlayerAnimation(player, (int)(Main.AnimationFlags.Cancellable), "mp_weapon_drop", "drop_lh");
                    /* NAPI.Task.Run(() =>
                     {
                         NAPI.Player.StopPlayerAnimation(player);
                     }, delayTime: 1500);*/

                    return;
                }
                i++;
            }
        }

        [RemoteEvent("OnClientItemAction")]
        public static void OnClientItemAction(Client player, int type, int action, int amount)
        {
            int playerid = Main.getIdFromClient(player);
            int index = GetInventoryIndexFromType(player, type);

            try
            {
                if (player_inventory[playerid].sql_id[index] == -1)
                {
                    Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Ein unbekannter Fehler ist aufgetreten.", 5000);
                    return;
                }
                //API.Shared.ConsoleOutput("" + action + " -- action " + player_inventory[playerid].amount[index] + "");
                if (player_inventory[playerid].amount[index] < 1)
                {
                    return;
                }


                if (action == 0)
                {
                    UseItemFromInventory(player, index, amount);

                }
                else if (action == 1)
                {
                    foreach (var target in API.Shared.GetAllPlayers())
                    {
                        if (target.GetData("status") == true)
                        {
                            if (Main.IsInRangeOfPoint(player.Position, target.Position, 2.0f))
                            {
                                player.SetData("target_item_handle", target);
                                player.SetData("target_item_name", itens_available[player_inventory[playerid].type[index]].name);


                                player.TriggerEvent("Destroy_Character_Menu");
                                InteractMenu.User_Input(player, "give_item_to_other_play", "Artikel: " + itens_available[player_inventory[playerid].type[index]].name + " \nFür: " + AccountManage.GetCharacterName(target) + "", 50.ToString(), "", "number");
                            }
                        }
                    }
                }
            }
            catch
            {

            }
        }


        public static void UseItemFromInventory(Client player, int item, int amount)
        {
            int playerid = Main.getIdFromClient(player);
            int index = item;
            int type = player_inventory[playerid].type[index];
            var arrItem = player_inventory[playerid];
            player.SetData("inventory_item_selected", itens_available[type].name);

            var Customization = CharCreator.CharCreator.CustomPlayerData[player.Handle];


            //API.Shared.ConsoleOutput("** >> DEBUG >> --  " + index + " -- " + type + " " + itens_available[type].guest + " -- " + itens_available[type].name + "");
            if (itens_available[type].guest == 5)
            {
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie haben ausgerüstet: " + itens_available[type].name + "", 5000);

                WeaponManage.SetPlayerWeaponEx(player, itens_available[type].name, 0);
                RemoveItemFromInventory(player, index, 1);

                ShowPlayerInventory(player);
                return;
            }

            var gender = false;

            if (player.GetSharedData("CHARACTER_ONLINE_GENRE") == 0)
            {
                gender = true;
            }
            else
            {
                gender = false;
            }

            switch (type)
            {
                case 1:
                    {
                        // message
                        Notify.Send(player, NotifyType.Success, NotifyPosition.BottomCenter, $"Du trinkst Wasser", 5000);
                        //Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du trinkst Wasser");

                        // remove item and hide inventory
                        player.TriggerEvent("Destroy_Character_Menu");
                        RemoveItemFromInventory(player, index, 1);

                        if (!player.IsInVehicle)
                        {
                            NAPI.Player.PlayPlayerAnimation(player, 49, "mp_player_intdrink", "loop");

                            NAPI.Task.Run(() =>
                            {
                                NAPI.Player.StopPlayerAnimation(player);
                            }, delayTime: 1500);
                        }
                        else
                        {

                        }

                        // attributes
                        AccountManage.SetPlayerThirsty(player, 40.0f);
                        break;
                    }

                case 2:
                    {
                        // message
                        Notify.Send(player, NotifyType.Success, NotifyPosition.BottomCenter, $"Du ißt einen Hamburger", 5000);
                        //Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du ißt einen Hamburger");

                        // remove item and hide inventory
                        player.TriggerEvent("Destroy_Character_Menu");
                        RemoveItemFromInventory(player, index, 1);

                        if (!player.IsInVehicle)
                        {
                            NAPI.Player.PlayPlayerAnimation(player, 49, "mp_player_inteat@burger", "mp_player_int_eat_burger");
                            NAPI.Task.Run(() =>
                            {
                                NAPI.Player.StopPlayerAnimation(player);
                            }, delayTime: 1500);
                        }
                        else
                        {

                        }
                        AccountManage.SetPlayerHunger(player, 40.0f);
                        break;
                    }
                case 3:
                    {
                        bool can_pass = false;
                        foreach (var w in Main.weapon_list)
                        {
                            if (player.CurrentWeapon == NAPI.Util.WeaponNameToModel(w.model))
                            {
                                if (w.type == "Sniper Rifles")
                                {
                                    can_pass = true;
                                }
                            }
                        }

                        if (can_pass == false)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie müssen die Waffe verwenden, mit der Sie die Munition ausrüsten möchten.", 5000);
                            return;
                        }

                        int ammo_actual = player_inventory[playerid].amount[index];

                        if (player.GetData("primary_ammunation") >= 250)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Diese Waffe ist bereits voll. Limit: 250", 5000);
                            return;
                        }

                        player.TriggerEvent("Destroy_Character_Menu");

                        InteractMenu.User_Input(player, "weapon_reload_primary", "Primärwaffe nachladen(Limit: 250)", 50.ToString(), "", "number");
                        WeaponManage.SaveWeapons(player);
                        break;
                    }
                case 4:
                    {
                        bool can_pass = false;
                        foreach (var w in Main.weapon_list)
                        {
                            if (player.CurrentWeapon == NAPI.Util.WeaponNameToModel(w.model))
                            {
                                if (w.type == "Assault Rifles")
                                {
                                    can_pass = true;
                                }
                            }
                        }

                        if (can_pass == false)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie müssen die Waffe verwenden, mit der Sie die Munition ausrüsten möchten.", 5000);
                            return;
                        }

                        int ammo_actual = player_inventory[playerid].amount[index];

                        if (player.GetData("primary_ammunation") >= 250)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Diese Waffe ist bereits voll. Limit: 250", 5000);
                            return;
                        }

                        player.TriggerEvent("Destroy_Character_Menu");

                        InteractMenu.User_Input(player, "weapon_reload_primary", "Primärwaffe nachladen(Limit: 250)", 50.ToString(), "", "number");
                        WeaponManage.SaveWeapons(player);
                        break;
                    }
                case 5:
                    {
                        bool can_pass = false;
                        foreach (var w in Main.weapon_list)
                        {
                            if (player.CurrentWeapon == NAPI.Util.WeaponNameToModel(w.model))
                            {
                                if (w.type == "Shotguns")
                                {
                                    can_pass = true;
                                }
                            }
                        }

                        if (can_pass == false)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie müssen die Waffe verwenden, mit der Sie die Munition ausrüsten möchten.", 5000);
                            return;
                        }

                        int ammo_actual = player_inventory[playerid].amount[index];

                        if (player.GetData("primary_ammunation") >= 250)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Diese Waffe ist bereits voll. Limit: 250", 5000);
                            return;
                        }

                        player.TriggerEvent("Destroy_Character_Menu");

                        InteractMenu.User_Input(player, "weapon_reload_secundary", "Primärwaffe nachladen(Limit: 250)", 50.ToString(), "", "number");
                        WeaponManage.SaveWeapons(player);
                        break;
                    }
                case 6:
                    {
                        bool can_pass = false;
                        foreach (var w in Main.weapon_list)
                        {
                            if (player.CurrentWeapon == NAPI.Util.WeaponNameToModel(w.model))
                            {
                                if (w.type == "Handguns")
                                {
                                    can_pass = true;
                                }
                            }
                        }

                        if (can_pass == false)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie müssen die Waffe benutzen, mit der Sie die Munition ausrüsten möchten.", 5000);
                            return;
                        }

                        int ammo_actual = player_inventory[playerid].amount[index];

                        if (player.GetData("primary_ammunation") >= 250)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Diese Waffe ist bereits voll. Limit: 250", 5000);
                            return;
                        }

                        player.TriggerEvent("Destroy_Character_Menu");

                        InteractMenu.User_Input(player, "weapon_reload_secundary", "Primärwaffe nachladen (Limite: 250)", 50.ToString(), "", "number");
                        WeaponManage.SaveWeapons(player);
                        break;
                    }
                case 7:
                    {
                        bool can_pass = false;
                        foreach (var w in Main.weapon_list)
                        {
                            if (player.CurrentWeapon == NAPI.Util.WeaponNameToModel(w.model))
                            {
                                if (w.type == "Machine Guns")
                                {
                                    can_pass = true;
                                }
                            }
                        }

                        if (can_pass == false)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie müssen die Waffe verwenden, mit der Sie die Munition ausrüsten möchten.", 5000);
                            return;
                        }

                        int ammo_actual = player_inventory[playerid].amount[index];

                        if (player.GetData("primary_ammunation") >= 250)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Diese Waffe ist bereits voll. Limit: 250", 5000);
                            return;
                        }

                        player.TriggerEvent("Destroy_Character_Menu");

                        InteractMenu.User_Input(player, "weapon_reload_secundary", "Primärwaffe nachladen(Limite: 250)", 50.ToString(), "", "number");
                        WeaponManage.SaveWeapons(player);
                        break;
                    }
                case 9:
                    {
                        if (player.GetData("character_backpack") != 2)
                        {
                            player.SetData("character_backpack", 2);
                            AccountManage.UpdateBackpack(player);
                            RemoveItemFromInventory(player, index, 1);
                            player.TriggerEvent("Destroy_Character_Menu");
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Hast du einen ausgerüstet? " + Main.EMBED_ORANGE + "Kleiner Rucksack" + Main.EMBED_WHITE + " jetzt kannst du laden " + Main.EMBED_LIGHTGREEN + "bis " + GetInventoryMaxHeight(player) + " kg" + Main.EMBED_WHITE + " in Ihrem Inventar.", 5000);
                            player.TriggerEvent("ShowDialogAutoClose", "success", "Verwendeter Artikel !", "Sie haben einen kleinen Rucksack ausgestattet.", 1400);
                        }
                        else
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie haben bereits einen kleinen Rucksack ausgestattet.", 5000);
                        }
                        break;
                    }
                case 10:
                    {
                        if (player.GetData("character_backpack") != 3)
                        {
                            player.SetData("character_backpack", 3);
                            AccountManage.UpdateBackpack(player);
                            RemoveItemFromInventory(player, index, 1);
                            player.TriggerEvent("Destroy_Character_Menu");
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Hast du einen ausgerüstet?" + Main.EMBED_ORANGE + "Großer Rucksack" + Main.EMBED_WHITE + " jetzt kannst du laden " + Main.EMBED_LIGHTGREEN + "bis " + GetInventoryMaxHeight(player) + " kg" + Main.EMBED_WHITE + " in Ihrem Inventar.", 5000);

                            player.TriggerEvent("ShowDialogAutoClose", "success", "Verwendeter Artikel !", "Sie haben einen großen Rucksack ausgestattet.", 1400);
                        }
                        else
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie haben bereits einen kleinen Rucksack ausgestattet.", 5000);
                        }
                        break;
                    }
                case 12:
                    {
                        player.TriggerEvent("Destroy_Character_Menu");
                        player.TriggerEvent("screen_weed");
                        NAPI.Player.PlayPlayerAnimation(player, 49, "amb@world_human_smoking@male@male_a@idle_a", "idle_c");
                        RemoveItemFromInventory(player, index, 1);

                        if (player.Armor <= 50)
                        {
                            player.Armor = player.Armor + 10;
                        }

                        if (player.GetData("inEffect_weed") == -1)
                        {
                            player.SetData("inEffect_weed", 30);
                        }
                        else player.SetData("inEffect_weed", player.GetData("inEffect_weed") + 30);

                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Bist du auf Drogen ? !", 5000);
                        player.TriggerEvent("update_armor", player.Armor);
                        break;
                    }
                case 16:
                    {
                        player.TriggerEvent("setResistStage", 3);
                        player.TriggerEvent("Destroy_Character_Menu");
                        player.TriggerEvent("screen_cocaine");
                        NAPI.Player.PlayPlayerAnimation(player, 49, "amb@world_human_smoking@male@male_a@idle_a", "idle_c");
                        RemoveItemFromInventory(player, index, 1);

                        if (player.Armor <= 99)
                        {
                            if (player.Armor + 35 >= 100) player.Armor = 50;
                            else player.Armor = player.Armor + 35;
                        }

                        if (player.GetData("inEffect_heroin") == -1)
                        {
                            player.SetData("inEffect_heroin", 40);
                        }
                        else player.SetData("inEffect_heroin", player.GetData("inEffect_heroin") + 40);

                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Bist du auf Drogen ? !!", 5000);
                        player.TriggerEvent("update_armor", player.Armor);
                        break;
                    }
                case 21:
                    {
                        // message
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du legst eine Heavy Sniper an.", 5000);

                        // remove item and hide inventory
                        player.TriggerEvent("Destroy_Character_Menu");
                        RemoveItemFromInventory(player, index, 1);

                        // attributes
                        WeaponHash weapon = NAPI.Util.WeaponNameToModel("HeavySniper");
                        NAPI.Player.GivePlayerWeapon(player, weapon, 250);
                        WeaponManage.GivePlayerWeaponEx(player, "HeavySniper", 250);
                        break;
                    }
                case 22:
                    {
                        if (player.GetData("first_aid_kit") == true)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie müssen 5 Sekunden lang ruhig bleiben und in der Zwischenzeit keinen Schaden nehmen.", 5000);
                            return;
                        }
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Bewegen Sie sich nicht für 5 Sekunden!", 5000);
                        player.SetData("first_aid_kit", true);
                        int health = player.Health;
                        Vector3 position = player.Position;
                        player.TriggerEvent("Destroy_Character_Menu");
                        NAPI.Task.Run(() =>
                        {
                            if (health == player.Health && Main.IsInRangeOfPoint(player.Position, position, 1.0f))
                            {
                                player.Health += 75;

                                NAPI.Player.StopPlayerAnimation(player);
                                RemoveItemFromInventory(player, index, 1);
                            }
                            else
                            {
                                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie haben innerhalb der letzten 5 Sekunden Schaden erhalten, die Aktion wurde abgebrochen.", 5000);
                            }
                            player.SetData("first_aid_kit", false);
                        }, delayTime: 5000);
                        break;
                    }
                case 23:
                    {
                        if (player.GetData("first_aid_kit") == true)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie müssen 5 Sekunden lang ruhig bleiben und in der Zwischenzeit keinen Schaden nehmen.", 5000);
                            return;
                        }
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Bewegen Sie sich nicht für 5 Sekunden!", 5000);
                        player.SetData("first_aid_kit", true);
                        int health = player.Health;
                        Vector3 position = player.Position;
                        player.TriggerEvent("Destroy_Character_Menu");
                        NAPI.Task.Run(() =>
                        {
                            if (health == player.Health && Main.IsInRangeOfPoint(player.Position, position, 1.0f))
                            {
                                player.Health += 75;

                                NAPI.Player.StopPlayerAnimation(player);
                                RemoveItemFromInventory(player, index, 1);
                            }
                            else
                            {
                                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie haben innerhalb der letzten 5 Sekunden Schaden erhalten, die Aktion wurde abgebrochen.", 5000);
                            }
                            player.SetData("first_aid_kit", false);
                        }, delayTime: 5000);
                        break;
                    }
                case 24:
                    {
                        if (player.GetData("first_aid_kit") == true)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie müssen 5 Sekunden lang ruhig bleiben und in der Zwischenzeit keinen Schaden nehmen.", 5000);
                            return;
                        }
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Bewegen Sie sich nicht für 5 Sekunden!", 5000);
                        player.SetData("first_aid_kit", true);
                        int health = player.Health;
                        Vector3 position = player.Position;
                        player.TriggerEvent("Destroy_Character_Menu");
                        NAPI.Task.Run(() =>
                        {
                            if (health == player.Health && Main.IsInRangeOfPoint(player.Position, position, 1.0f))
                            {
                                player.Health += 75;

                                NAPI.Player.StopPlayerAnimation(player);
                                RemoveItemFromInventory(player, index, 1);
                            }
                            else
                            {
                                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie haben innerhalb der letzten 5 Sekunden Schaden erhalten, die Aktion wurde abgebrochen.", 5000);
                            }
                            player.SetData("first_aid_kit", false);
                        }, delayTime: 5000);
                        break;
                    }
                case 25:
                    {
                        if (player.GetData("first_aid_kit") == true)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie müssen 5 Sekunden lang ruhig bleiben und in der Zwischenzeit keinen Schaden nehmen.", 5000);
                            return;
                        }
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Bewegen Sie sich nicht für 5 Sekunden!", 5000);
                        player.SetData("first_aid_kit", true);
                        int health = player.Health;
                        Vector3 position = player.Position;
                        player.TriggerEvent("Destroy_Character_Menu");
                        NAPI.Task.Run(() =>
                        {
                            if (health == player.Health && Main.IsInRangeOfPoint(player.Position, position, 1.0f))
                            {
                                player.Health += 75;

                                NAPI.Player.StopPlayerAnimation(player);
                                RemoveItemFromInventory(player, index, 1);
                            }
                            else
                            {
                                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie haben innerhalb der letzten 5 Sekunden Schaden erhalten, die Aktion wurde abgebrochen.", 5000);
                            }
                            player.SetData("first_aid_kit", false);
                        }, delayTime: 5000);
                        break;
                    }
                case 26:
                    {
                        if (player.GetData("first_aid_kit") == true)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie müssen 5 Sekunden lang ruhig bleiben und in der Zwischenzeit keinen Schaden nehmen.", 5000);
                            return;
                        }
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Bewegen Sie sich nicht für 5 Sekunden!", 5000);
                        player.SetData("first_aid_kit", true);
                        int health = player.Health;
                        Vector3 position = player.Position;
                        player.TriggerEvent("Destroy_Character_Menu");
                        NAPI.Task.Run(() =>
                        {
                            if (health == player.Health && Main.IsInRangeOfPoint(player.Position, position, 1.0f))
                            {
                                player.Health += 75;

                                NAPI.Player.StopPlayerAnimation(player);
                                RemoveItemFromInventory(player, index, 1);
                            }
                            else
                            {
                                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie haben innerhalb der letzten 5 Sekunden Schaden erhalten, die Aktion wurde abgebrochen.", 5000);
                            }
                            player.SetData("first_aid_kit", false);
                        }, delayTime: 5000);
                        break;
                    }
                case 33:
                    {
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du trinkst Cola.", 5000);
                        // remove item and hide inventory
                        player.TriggerEvent("Destroy_Character_Menu");
                        RemoveItemFromInventory(player, index, 1);

                        if (!player.IsInVehicle)
                        {
                            NAPI.Player.PlayPlayerAnimation(player, 49, "mp_player_intdrink", "loop");

                            NAPI.Task.Run(() =>
                            {
                                NAPI.Player.StopPlayerAnimation(player);
                            }, delayTime: 1500);
                        }
                        else
                        {

                        }

                        // attributes
                        AccountManage.SetPlayerThirsty(player, 40.0f);
                        break;
                    }
                case 34:
                    {
                        // message
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du trinkst Sprite.", 5000);

                        // remove item and hide inventory
                        player.TriggerEvent("Destroy_Character_Menu");
                        RemoveItemFromInventory(player, index, 1);

                        if (!player.IsInVehicle)
                        {
                            NAPI.Player.PlayPlayerAnimation(player, 49, "mp_player_intdrink", "loop");

                            NAPI.Task.Run(() =>
                            {
                                NAPI.Player.StopPlayerAnimation(player);
                            }, delayTime: 1500);
                        }
                        else
                        {

                        }

                        // attributes
                        AccountManage.SetPlayerThirsty(player, 40.0f);
                        break;
                    }
                case 35:
                    {
                        // message
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du trinkst Kaffee.", 5000);

                        // remove item and hide inventory
                        player.TriggerEvent("Destroy_Character_Menu");
                        RemoveItemFromInventory(player, index, 1);

                        if (!player.IsInVehicle)
                        {
                            NAPI.Player.PlayPlayerAnimation(player, 49, "mp_player_intdrink", "loop");

                            NAPI.Task.Run(() =>
                            {
                                NAPI.Player.StopPlayerAnimation(player);
                            }, delayTime: 1500);
                        }
                        else
                        {

                        }

                        // attributes
                        AccountManage.SetPlayerThirsty(player, 40.0f);
                        break;
                    }
                case 36:
                    {
                        // message
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du ißt einen Calzone.", 5000);

                        // remove item and hide inventory
                        player.TriggerEvent("Destroy_Character_Menu");
                        RemoveItemFromInventory(player, index, 1);

                        if (!player.IsInVehicle)
                        {
                            NAPI.Player.PlayPlayerAnimation(player, 49, "mp_player_inteat@burger", "mp_player_int_eat_burger");
                            NAPI.Task.Run(() =>
                            {
                                NAPI.Player.StopPlayerAnimation(player);
                            }, delayTime: 1500);
                        }
                        else
                        {

                        }
                        AccountManage.SetPlayerHunger(player, 40.0f);
                        break;
                    }
                case 46:
                    {
                        player.TriggerEvent("Destroy_Character_Menu");
                        RemoveItemFromInventory(player, index, 1);

                        Vehicle vehicle = player.Vehicle;

                        if (!vehicle.Exists)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Dieses Fahrzeug existiert nicht mehr.", 5000);
                            return;
                        }
                        if (!Main.IsInRangeOfPoint(player.Position, vehicle.Position, 5.0f))
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie sind zu weit vom Fahrzeug entfernt..", 5000);
                            return;
                        }


                        if (NAPI.Entity.DoesEntityExist(vehicle))
                        {
                            if (player.GetData("vehicle_fuel") > 79)
                            {
                                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Dieses Fahrzeug ist bereits voll!", 5000);
                                return;
                            }
                            if (Inventory.GetPlayerItemFromInventory(player, 46) < 1)
                            {
                                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du brauchst 1x Benzinkanister zum Auftanken.", 5000);
                                return;
                            }


                            if (!player.IsInVehicle)
                            {
                                if (NAPI.Entity.DoesEntityExist(vehicle))
                                {
                                    Inventory.RemoveItemByType(player, 46, 1);
                                    //Inventory.RemoveItem(player, "Benzinkanister", 1);
                                    Main.SetVehicleFuel(vehicle, Main.GetVehicleFuel(vehicle) + 20.0);
                                    Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du benutzt den Benzinkanister.", 5000);
                                }
                                else Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie sind nicht in der Nähe eines Fahrzeugs.", 5000);
                            }
                        }
                        else Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie sind nicht in der Nähe eines Fahrzeugs.", 5000);
                        break;
                    }
                case 47:
                    {
                        // message
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du ißt einen Döner.", 5000);

                        // remove item and hide inventory
                        player.TriggerEvent("Destroy_Character_Menu");
                        RemoveItemFromInventory(player, index, 1);
                        if (!player.IsInVehicle)
                        {
                            NAPI.Player.PlayPlayerAnimation(player, 49, "mp_player_inteat@burger", "mp_player_int_eat_burger");
                            NAPI.Task.Run(() =>
                            {
                                NAPI.Player.StopPlayerAnimation(player);
                            }, delayTime: 1500);
                        }
                        else
                        {

                        }
                        AccountManage.SetPlayerHunger(player, 40.0f);
                        break;
                    }
                case 48:
                    {
                        // message
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du ißt einen Bockwurst.", 5000);

                        // remove item and hide inventory
                        player.TriggerEvent("Destroy_Character_Menu");
                        RemoveItemFromInventory(player, index, 1);
                        if (!player.IsInVehicle)
                        {
                            NAPI.Player.PlayPlayerAnimation(player, 49, "mp_player_inteat@burger", "mp_player_int_eat_burger");
                            NAPI.Task.Run(() =>
                            {
                                NAPI.Player.StopPlayerAnimation(player);
                            }, delayTime: 1500);
                        }
                        else
                        {

                        }
                        AccountManage.SetPlayerHunger(player, 40.0f);
                        break;
                    }
                case 49:
                    {
                        // message
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du ißt einen Cheese Burger.", 5000);

                        // remove item and hide inventory
                        player.TriggerEvent("Destroy_Character_Menu");
                        RemoveItemFromInventory(player, index, 1);
                        if (!player.IsInVehicle)
                        {
                            NAPI.Player.PlayPlayerAnimation(player, 49, "mp_player_inteat@burger", "mp_player_int_eat_burger");
                            NAPI.Task.Run(() =>
                            {
                                NAPI.Player.StopPlayerAnimation(player);
                            }, delayTime: 1500);
                        }
                        else
                        {

                        }
                        AccountManage.SetPlayerHunger(player, 40.0f);
                        break;
                    }
                case 50:
                    {
                        // message
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du ißt einen Bacon Burger.", 5000);
                        // remove item and hide inventory
                        player.TriggerEvent("Destroy_Character_Menu");
                        RemoveItemFromInventory(player, index, 1);
                        if (!player.IsInVehicle)
                        {
                            NAPI.Player.PlayPlayerAnimation(player, 49, "mp_player_inteat@burger", "mp_player_int_eat_burger");
                            NAPI.Task.Run(() =>
                            {
                                NAPI.Player.StopPlayerAnimation(player);
                            }, delayTime: 1500);
                        }
                        else
                        {

                        }
                        AccountManage.SetPlayerHunger(player, 40.0f);
                        break;
                    }
                case 51:
                    {
                        // message
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du ißt einen Lasagne.", 5000);
                        // remove item and hide inventory
                        player.TriggerEvent("Destroy_Character_Menu");
                        RemoveItemFromInventory(player, index, 1);
                        if (!player.IsInVehicle)
                        {
                            NAPI.Player.PlayPlayerAnimation(player, 49, "mp_player_inteat@burger", "mp_player_int_eat_burger");
                            NAPI.Task.Run(() =>
                            {
                                NAPI.Player.StopPlayerAnimation(player);
                            }, delayTime: 1500);
                        }
                        else
                        {

                        }
                        AccountManage.SetPlayerHunger(player, 40.0f);
                        break;
                    }
                case 52:
                    {
                        // message
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du ißt einen Thunfisch Pizza.", 5000);

                        // remove item and hide inventory
                        player.TriggerEvent("Destroy_Character_Menu");
                        RemoveItemFromInventory(player, index, 1);
                        if (!player.IsInVehicle)
                        {
                            NAPI.Player.PlayPlayerAnimation(player, 49, "mp_player_inteat@burger", "mp_player_int_eat_burger");
                            NAPI.Task.Run(() =>
                            {
                                NAPI.Player.StopPlayerAnimation(player);
                            }, delayTime: 1500);
                        }
                        else
                        {

                        }
                        AccountManage.SetPlayerHunger(player, 40.0f);
                        break;
                    }
                case 53:
                    {
                        // message
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du ißt einen Salami Pizza.", 5000);

                        // remove item and hide inventory
                        player.TriggerEvent("Destroy_Character_Menu");
                        RemoveItemFromInventory(player, index, 1);
                        if (!player.IsInVehicle)
                        {
                            NAPI.Player.PlayPlayerAnimation(player, 49, "mp_player_inteat@burger", "mp_player_int_eat_burger");
                            NAPI.Task.Run(() =>
                            {
                                NAPI.Player.StopPlayerAnimation(player);
                            }, delayTime: 1500);
                        }
                        else
                        {

                        }
                        AccountManage.SetPlayerHunger(player, 40.0f);
                        break;
                    }
                case 54:
                    {
                        // message
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du ißt einen Hawaii Pizza.", 5000);

                        // remove item and hide inventory
                        player.TriggerEvent("Destroy_Character_Menu");
                        RemoveItemFromInventory(player, index, 1);
                        if (!player.IsInVehicle)
                        {
                            NAPI.Player.PlayPlayerAnimation(player, 49, "mp_player_inteat@burger", "mp_player_int_eat_burger");
                            NAPI.Task.Run(() =>
                            {
                                NAPI.Player.StopPlayerAnimation(player);
                            }, delayTime: 1500);
                        }
                        else
                        {

                        }
                        AccountManage.SetPlayerHunger(player, 40.0f);
                        break;
                    }
                case 55:
                    {
                        if (player.GetData("first_aid_kit") == true)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie müssen 5 Sekunden lang ruhig bleiben und in der Zwischenzeit keinen Schaden nehmen.", 5000);
                            return;
                        }
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Bewegen Sie sich nicht für 5 Sekunden!", 5000);
                        player.SetData("first_aid_kit", true);
                        int health = player.Health;
                        Vector3 position = player.Position;
                        player.TriggerEvent("Destroy_Character_Menu");
                        NAPI.Task.Run(() =>
                        {
                            if (health == player.Health && Main.IsInRangeOfPoint(player.Position, position, 1.0f))
                            {
                                player.Health += 25;

                                NAPI.Player.StopPlayerAnimation(player);
                                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie verwenden ein Erste-Hilfe-Set!", 5000);
                                RemoveItemFromInventory(player, index, 1);
                            }
                            else
                            {
                                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie haben innerhalb der letzten 5 Sekunden Schaden erhalten, die Aktion wurde abgebrochen.", 5000);
                            }
                            player.SetData("first_aid_kit", false);
                        }, delayTime: 5000);
                        break;
                    }
                // Neue
                case 56:
                    {
                        // message
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du ißt einen Apfel.", 5000);

                        // remove item and hide inventory
                        player.TriggerEvent("Destroy_Character_Menu");
                        RemoveItemFromInventory(player, index, 1);
                        if (!player.IsInVehicle)
                        {
                            NAPI.Player.PlayPlayerAnimation(player, 49, "mp_player_inteat@burger", "mp_player_int_eat_burger");
                            NAPI.Task.Run(() =>
                            {
                                NAPI.Player.StopPlayerAnimation(player);
                            }, delayTime: 1500);
                        }
                        else
                        {

                        }
                        // attributes
                        AccountManage.SetPlayerThirsty(player, 15.0f);
                        AccountManage.SetPlayerHunger(player, 5.0f);
                        break;
                    }
                case 42:
                    {
                        // message
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du ißt einen Orange.", 5000);

                        // remove item and hide inventory
                        player.TriggerEvent("Destroy_Character_Menu");
                        RemoveItemFromInventory(player, index, 1);
                        if (!player.IsInVehicle)
                        {
                            NAPI.Player.PlayPlayerAnimation(player, 49, "mp_player_inteat@burger", "mp_player_int_eat_burger");
                            NAPI.Task.Run(() =>
                            {
                                NAPI.Player.StopPlayerAnimation(player);
                            }, delayTime: 1500);
                        }
                        else
                        {

                        }
                        // attributes
                        AccountManage.SetPlayerThirsty(player, 13.0f);
                        AccountManage.SetPlayerHunger(player, 5.0f);
                        break;
                    }

                case 58:
                    {
                        // message
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Bist du sicher, dass du gerade die Öl Flasche richtig benutzt?", 5000);

                        // remove item and hide inventory
                        player.TriggerEvent("Destroy_Character_Menu");
                        RemoveItemFromInventory(player, index, 1);
                        AccountManage.SetPlayerHunger(player, -10.0f);
                        break;
                    }
                case 60:
                    {
                        // message
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du trinkst einen Wodka.", 5000);

                        // remove item and hide inventory
                        player.TriggerEvent("Destroy_Character_Menu");
                        player.TriggerEvent("screen_weed");
                        RemoveItemFromInventory(player, index, 1);
                        if (!player.IsInVehicle)
                        {
                            NAPI.Player.PlayPlayerAnimation(player, 49, "mp_player_inteat@burger", "mp_player_int_eat_burger");
                            NAPI.Task.Run(() =>
                            {
                                NAPI.Player.StopPlayerAnimation(player);
                            }, delayTime: 1500);
                        }
                        else
                        {

                        }
                        // attributes
                        AccountManage.SetPlayerThirsty(player, 45.0f);
                        AccountManage.SetPlayerHunger(player, -5.0f);
                        if (player.GetData("inEffect_weed") == -1)
                        {
                            player.SetData("inEffect_weed", 15);
                        }
                        else player.SetData("inEffect_weed", player.GetData("inEffect_weed") + 15);


                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du solltest nicht soviel Alkohol trinken!", 5000);
                        break;
                    }
                case 61:
                    {
                        player.TriggerEvent("Destroy_Character_Menu");
                        player.TriggerEvent("screen_weed");
                        RemoveItemFromInventory(player, index, 1);

                        if (player.Armor <= 50)
                        {
                            player.Armor = player.Armor + 20;
                        }

                        if (player.GetData("inEffect_weed") == -1)
                        {
                            player.SetData("inEffect_weed", 45);
                        }
                        else player.SetData("inEffect_weed", player.GetData("inEffect_weed") + 45);

                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Bist du auf Drogen ? !", 5000);
                        player.TriggerEvent("update_armor", player.Armor);
                        break;
                    }
                case 62:
                    {
                        // message
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du legst eine SMG an.", 5000);

                        // remove item and hide inventory
                        player.TriggerEvent("Destroy_Character_Menu");
                        RemoveItemFromInventory(player, index, 1);

                        // attributes
                        WeaponHash weapon = NAPI.Util.WeaponNameToModel("SMG");
                        NAPI.Player.GivePlayerWeapon(player, weapon, 250);
                        WeaponManage.GivePlayerWeaponEx(player, "SMG", 250);
                        break;
                    }
                case 63:
                    {
                        // message
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du legst eine Compact Rifle an.", 5000);

                        // remove item and hide inventory
                        player.TriggerEvent("Destroy_Character_Menu");
                        RemoveItemFromInventory(player, index, 1);

                        // attributes
                        WeaponHash weapon = NAPI.Util.WeaponNameToModel("CompactRifle");
                        NAPI.Player.GivePlayerWeapon(player, weapon, 250);
                        WeaponManage.GivePlayerWeaponEx(player, "CompactRifle", 250);
                        break;
                    }
                case 64:
                    {
                        // message
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du legst eine Pump Shotgun an.", 5000);

                        // remove item and hide inventory
                        player.TriggerEvent("Destroy_Character_Menu");
                        RemoveItemFromInventory(player, index, 1);

                        // attributes
                        WeaponHash weapon = NAPI.Util.WeaponNameToModel("PumpShotgun");
                        NAPI.Player.GivePlayerWeapon(player, weapon, 250);
                        WeaponManage.GivePlayerWeaponEx(player, "PumpShotgun", 250);
                        break;
                    }
                case 66:
                    {
                        // message
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du trinkst einen Bier.", 5000);

                        // remove item and hide inventory
                        player.TriggerEvent("Destroy_Character_Menu");
                        player.TriggerEvent("screen_weed");
                        RemoveItemFromInventory(player, index, 1);

                        if (!player.IsInVehicle)
                        {
                            NAPI.Player.PlayPlayerAnimation(player, 49, "mp_player_intdrink", "loop");

                            NAPI.Task.Run(() =>
                            {
                                NAPI.Player.StopPlayerAnimation(player);
                            }, delayTime: 1500);
                        }
                        else
                        {

                        }

                        // attributes
                        AccountManage.SetPlayerThirsty(player, 45.0f);
                        AccountManage.SetPlayerHunger(player, -3.0f);
                        if (player.GetData("inEffect_weed") == -1)
                        {
                            player.SetData("inEffect_weed", 15);
                        }
                        else player.SetData("inEffect_weed", player.GetData("inEffect_weed") + 15);


                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du solltest nicht soviel Alkohol trinken!", 5000);
                        break;
                    }
                case 70:
                    {
                        // message
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du benutzt 1x Dietrich", 5000);

                        // remove item and hide inventory
                        player.TriggerEvent("Destroy_Character_Menu");
                        RemoveItemFromInventory(player, index, 1);

                        var players = NAPI.Pools.GetAllPlayers();
                        foreach (var target in players)
                        {
                            if (target.GetData("status") == true)
                            {
                                if (Main.IsInRangeOfPoint(player.Position, target.Position, 20.0f) && player != target)
                                {
                                    //player.TriggerEvent("Vehicle_Alarm_Player");
                                    target.TriggerEvent("Vehicle_Alarm_Player");
                                    if (target.GetData("status") == true && AccountManage.GetPlayerGroup(target) == 1)
                                    {
                                        Police.SetPlayerCrime(player, "Fahrzeug geklaut ", " Unbekannt", 12);

                                        target.SendNotification("GPS-Route wegen den Fahrzeug geklaut definiert!");
                                        target.TriggerEvent("gps_set_loc", player.Position.X, player.Position.Y);
                                    }
                                }
                            }
                        }

                        NAPI.Task.Run(() =>
                        {
                            foreach (var target in players)
                            {
                                if (target.GetData("status") == true)
                                {
                                    if (Main.IsInRangeOfPoint(player.Position, target.Position, 20.0f) && player != target)
                                    {
                                        //player.TriggerEvent("Destroy_Vehicle_Alarm_Player");
                                        target.TriggerEvent("Destroy_Vehicle_Alarm_Player");
                                        if (target.GetData("status") == true && AccountManage.GetPlayerGroup(target) == 1)
                                        {
                                            Police.SetPlayerCrime(player, "Fahrzeug geklaut ", " Unbekannt", 12);

                                            target.SendNotification("GPS-Route wegen den Fahrzeug geklaut definiert!");
                                            target.TriggerEvent("gps_set_loc", player.Position.X, player.Position.Y);
                                        }
                                    }
                                }
                            }
                        }, delayTime: 25500);
                        // attributes
                        if (player.IsInVehicle)
                        {
                            NAPI.Task.Run(() =>
                            {
                                foreach (var veh in NAPI.Pools.GetAllVehicles())
                                {
                                    if (Main.IsInRangeOfPoint(player.Position, veh.Position, 20.0f) && player != veh)
                                    {
                                        NAPI.Vehicle.SetVehicleEngineStatus(veh, true);
                                        veh.EngineStatus = true;
                                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du hast das Fahrzeug Erfolgreich kurz geschlossen!", 5000);
                                    }
                                }
                            }, delayTime: 45000);
                        }
                        else
                        {
                            NAPI.Task.Run(() =>
                            {
                                foreach (var veh in NAPI.Pools.GetAllVehicles())
                                {
                                    if (Main.IsInRangeOfPoint(player.Position, veh.Position, 20.0f) && player != veh)
                                    {
                                        NAPI.Vehicle.SetVehicleLocked(veh, false);
                                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du hast das Fahrzeug Erfolgreich aufgebrochen!", 5000);
                                    }
                                }

                            }, delayTime: 55000);
                        }
                        break;
                    }
                case 74:
                    {
                        // message
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du trinkst ein Champus", 5000);

                        // remove item and hide inventory
                        player.TriggerEvent("Destroy_Character_Menu");
                        player.TriggerEvent("screen_weed");
                        RemoveItemFromInventory(player, index, 1);

                        if (!player.IsInVehicle)
                        {
                            NAPI.Player.PlayPlayerAnimation(player, 49, "mp_player_intdrink", "loop");

                            NAPI.Task.Run(() =>
                            {
                                NAPI.Player.StopPlayerAnimation(player);
                            }, delayTime: 1500);
                        }
                        else
                        {

                        }

                        // attributes
                        AccountManage.SetPlayerThirsty(player, 25.0f);
                        AccountManage.SetPlayerHunger(player, 5.0f);
                        if (player.GetData("inEffect_weed") == -1)
                        {
                            player.SetData("inEffect_weed", 15);
                        }
                        else player.SetData("inEffect_weed", player.GetData("inEffect_weed") + 15);


                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du solltest nicht soviel Alkohol trinken!", 5000);
                        break;
                    }
                case 75:
                    {
                        // message
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du trinkst ein Snickers-Cocktail", 5000);

                        // remove item and hide inventory
                        player.TriggerEvent("Destroy_Character_Menu");
                        player.TriggerEvent("screen_weed");
                        RemoveItemFromInventory(player, index, 1);

                        if (!player.IsInVehicle)
                        {
                            NAPI.Player.PlayPlayerAnimation(player, 49, "mp_player_intdrink", "loop");

                            NAPI.Task.Run(() =>
                            {
                                NAPI.Player.StopPlayerAnimation(player);
                            }, delayTime: 1500);
                        }
                        else
                        {

                        }

                        // attributes
                        AccountManage.SetPlayerThirsty(player, 25.0f);
                        AccountManage.SetPlayerHunger(player, 5.0f);
                        if (player.GetData("inEffect_weed") == -1)
                        {
                            player.SetData("inEffect_weed", 15);
                        }
                        else player.SetData("inEffect_weed", player.GetData("inEffect_weed") + 15);


                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du solltest nicht soviel Alkohol trinken!", 5000);
                        break;
                    }
                case 76:
                    {
                        // message
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du trinkst ein Mango-Maracuja-Spritz", 5000);

                        // remove item and hide inventory
                        player.TriggerEvent("Destroy_Character_Menu");
                        player.TriggerEvent("screen_weed");
                        RemoveItemFromInventory(player, index, 1);

                        if (!player.IsInVehicle)
                        {
                            NAPI.Player.PlayPlayerAnimation(player, 49, "mp_player_intdrink", "loop");

                            NAPI.Task.Run(() =>
                            {
                                NAPI.Player.StopPlayerAnimation(player);
                            }, delayTime: 1500);
                        }
                        else
                        {

                        }

                        // attributes
                        AccountManage.SetPlayerThirsty(player, 25.0f);
                        AccountManage.SetPlayerHunger(player, 5.0f);
                        if (player.GetData("inEffect_weed") == -1)
                        {
                            player.SetData("inEffect_weed", 15);
                        }
                        else player.SetData("inEffect_weed", player.GetData("inEffect_weed") + 15);


                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du solltest nicht soviel Alkohol trinken!", 5000);
                        break;
                    }
                case 77:
                    {
                        // message
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du trinkst ein Bier-Cocktail", 5000);

                        // remove item and hide inventory
                        player.TriggerEvent("Destroy_Character_Menu");
                        player.TriggerEvent("screen_weed");
                        RemoveItemFromInventory(player, index, 1);

                        if (!player.IsInVehicle)
                        {
                            NAPI.Player.PlayPlayerAnimation(player, 49, "mp_player_intdrink", "loop");

                            NAPI.Task.Run(() =>
                            {
                                NAPI.Player.StopPlayerAnimation(player);
                            }, delayTime: 1500);
                        }
                        else
                        {

                        }

                        // attributes
                        AccountManage.SetPlayerThirsty(player, 25.0f);
                        AccountManage.SetPlayerHunger(player, 5.0f);
                        if (player.GetData("inEffect_weed") == -1)
                        {
                            player.SetData("inEffect_weed", 15);
                        }
                        else player.SetData("inEffect_weed", player.GetData("inEffect_weed") + 15);


                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du solltest nicht soviel Alkohol trinken!", 5000);
                        break;
                    }
                case 78:
                    {
                        // message
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du trinkst ein Coconut-Dream", 5000);

                        // remove item and hide inventory
                        player.TriggerEvent("Destroy_Character_Menu");
                        player.TriggerEvent("screen_weed");
                        RemoveItemFromInventory(player, index, 1);

                        if (!player.IsInVehicle)
                        {
                            NAPI.Player.PlayPlayerAnimation(player, 49, "mp_player_intdrink", "loop");

                            NAPI.Task.Run(() =>
                            {
                                NAPI.Player.StopPlayerAnimation(player);
                            }, delayTime: 1500);
                        }
                        else
                        {

                        }

                        // attributes
                        AccountManage.SetPlayerThirsty(player, 25.0f);
                        AccountManage.SetPlayerHunger(player, 5.0f);
                        if (player.GetData("inEffect_weed") == -1)
                        {
                            player.SetData("inEffect_weed", 15);
                        }
                        else player.SetData("inEffect_weed", player.GetData("inEffect_weed") + 15);


                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du solltest nicht soviel Alkohol trinken!", 5000);
                        break;
                    }
                case 79:
                    {
                        // message
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du trinkst ein Himbeer-Dream", 5000);

                        // remove item and hide inventory
                        player.TriggerEvent("Destroy_Character_Menu");
                        player.TriggerEvent("screen_weed");
                        RemoveItemFromInventory(player, index, 1);

                        if (!player.IsInVehicle)
                        {
                            NAPI.Player.PlayPlayerAnimation(player, 49, "mp_player_intdrink", "loop");

                            NAPI.Task.Run(() =>
                            {
                                NAPI.Player.StopPlayerAnimation(player);
                            }, delayTime: 1500);
                        }
                        else
                        {

                        }

                        // attributes
                        AccountManage.SetPlayerThirsty(player, 25.0f);
                        AccountManage.SetPlayerHunger(player, 5.0f);
                        if (player.GetData("inEffect_weed") == -1)
                        {
                            player.SetData("inEffect_weed", 15);
                        }
                        else player.SetData("inEffect_weed", player.GetData("inEffect_weed") + 15);


                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du solltest nicht soviel Alkohol trinken!", 5000);
                        break;
                    }
                case 80:
                    {
                        // message
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du trinkst ein Erdbeer-Dream", 5000);

                        // remove item and hide inventory
                        player.TriggerEvent("Destroy_Character_Menu");
                        player.TriggerEvent("screen_weed");
                        RemoveItemFromInventory(player, index, 1);

                        if (!player.IsInVehicle)
                        {
                            NAPI.Player.PlayPlayerAnimation(player, 49, "mp_player_intdrink", "loop");

                            NAPI.Task.Run(() =>
                            {
                                NAPI.Player.StopPlayerAnimation(player);
                            }, delayTime: 1500);
                        }
                        else
                        {

                        }

                        // attributes
                        AccountManage.SetPlayerThirsty(player, 25.0f);
                        AccountManage.SetPlayerHunger(player, 5.0f);
                        if (player.GetData("inEffect_weed") == -1)
                        {
                            player.SetData("inEffect_weed", 15);
                        }
                        else player.SetData("inEffect_weed", player.GetData("inEffect_weed") + 15);


                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du solltest nicht soviel Alkohol trinken!", 5000);
                        break;
                    }
                case 81:
                    {
                        // message
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du trinkst ein Wodka-Cocktail", 5000);

                        // remove item and hide inventory
                        player.TriggerEvent("Destroy_Character_Menu");
                        player.TriggerEvent("screen_weed");
                        RemoveItemFromInventory(player, index, 1);

                        if (!player.IsInVehicle)
                        {
                            NAPI.Player.PlayPlayerAnimation(player, 49, "mp_player_intdrink", "loop");

                            NAPI.Task.Run(() =>
                            {
                                NAPI.Player.StopPlayerAnimation(player);
                            }, delayTime: 1500);
                        }
                        else
                        {

                        }

                        // attributes
                        AccountManage.SetPlayerThirsty(player, 25.0f);
                        AccountManage.SetPlayerHunger(player, 5.0f);
                        if (player.GetData("inEffect_weed") == -1)
                        {
                            player.SetData("inEffect_weed", 15);
                        }
                        else player.SetData("inEffect_weed", player.GetData("inEffect_weed") + 15);


                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du solltest nicht soviel Alkohol trinken!", 5000);
                        break;
                    }
                case 82:
                    {
                        // message
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du hast dein Verlobungsring angelegt.", 5000);

                        // remove item and hide inventory
                        player.TriggerEvent("Destroy_Character_Menu");
                        RemoveItemFromInventory(player, index, 1);

                        foreach (var target in NAPI.Pools.GetAllPlayers())
                        {
                            Main.ShowColorShardAll(target, "~y~Der Staat wünscht alles Gute!", "Es fand gerade eine Verlobung statt.", 2, 10, 6500);
                        }
                        // attributes

                        break;
                    }
                case 93:
                    {
                        // message
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du hast dein Ehering angelegt.", 5000);

                        // remove item and hide inventory
                        player.TriggerEvent("Destroy_Character_Menu");
                        RemoveItemFromInventory(player, index, 1);

                        foreach (var target in NAPI.Pools.GetAllPlayers())
                        {
                            Main.ShowColorShardAll(target, "~y~Der Staat wünscht alles Gute!", "Es fand gerade eine Hochzeit statt.", 2, 10, 6500);
                        }
                        // attributes

                        break;
                    }
                case 94:
                    {
                        // message
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du ißt ein Snickers", 5000);

                        // remove item and hide inventory
                        player.TriggerEvent("Destroy_Character_Menu");
                        RemoveItemFromInventory(player, index, 1);
                        if (!player.IsInVehicle)
                        {
                            NAPI.Player.PlayPlayerAnimation(player, 49, "mp_player_inteat@burger", "mp_player_int_eat_burger");
                            NAPI.Task.Run(() =>
                            {
                                NAPI.Player.StopPlayerAnimation(player);
                            }, delayTime: 1500);
                        }
                        else
                        {

                        }
                        AccountManage.SetPlayerHunger(player, 26.0f);
                        break;
                    }
                case 95:
                    {
                        // message
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du ißt ein Mars", 5000);

                        // remove item and hide inventory
                        player.TriggerEvent("Destroy_Character_Menu");
                        RemoveItemFromInventory(player, index, 1);
                        if (!player.IsInVehicle)
                        {
                            NAPI.Player.PlayPlayerAnimation(player, 49, "mp_player_inteat@burger", "mp_player_int_eat_burger");
                            NAPI.Task.Run(() =>
                            {
                                NAPI.Player.StopPlayerAnimation(player);
                            }, delayTime: 1500);
                        }
                        else
                        {

                        }
                        AccountManage.SetPlayerHunger(player, 23.0f);
                        break;
                    }
                case 96:
                    {
                        // message
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du ißt ein Schokolade", 5000);

                        // remove item and hide inventory
                        player.TriggerEvent("Destroy_Character_Menu");
                        RemoveItemFromInventory(player, index, 1);
                        if (!player.IsInVehicle)
                        {
                            NAPI.Player.PlayPlayerAnimation(player, 49, "mp_player_inteat@burger", "mp_player_int_eat_burger");
                            NAPI.Task.Run(() =>
                            {
                                NAPI.Player.StopPlayerAnimation(player);
                            }, delayTime: 1500);
                        }
                        else
                        {

                        }
                        AccountManage.SetPlayerHunger(player, 17.0f);
                        break;
                    }
                case 97:
                    {
                        // message
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du ißt ein Chips", 5000);

                        // remove item and hide inventory
                        player.TriggerEvent("Destroy_Character_Menu");
                        RemoveItemFromInventory(player, index, 1);
                        if (!player.IsInVehicle)
                        {
                            NAPI.Player.PlayPlayerAnimation(player, 49, "mp_player_inteat@burger", "mp_player_int_eat_burger");
                            NAPI.Task.Run(() =>
                            {
                                NAPI.Player.StopPlayerAnimation(player);
                            }, delayTime: 1500);
                        }
                        else
                        {

                        }
                        AccountManage.SetPlayerHunger(player, 19.0f);
                        break;
                    }
                case 98:
                    {
                        // message
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du ißt ein Flips", 5000);

                        // remove item and hide inventory
                        player.TriggerEvent("Destroy_Character_Menu");
                        RemoveItemFromInventory(player, index, 1);
                        if (!player.IsInVehicle)
                        {
                            NAPI.Player.PlayPlayerAnimation(player, 49, "mp_player_inteat@burger", "mp_player_int_eat_burger");
                            NAPI.Task.Run(() =>
                            {
                                NAPI.Player.StopPlayerAnimation(player);
                            }, delayTime: 1500);
                        }
                        else
                        {

                        }
                        AccountManage.SetPlayerHunger(player, 19.0f);
                        break;
                    }
                case 101:
                    {
                        bool can_pass = false;
                        foreach (var w in Main.weapon_list)
                        {
                            if (player.CurrentWeapon == NAPI.Util.WeaponNameToModel(w.model))
                            {
                                if (w.type == "Branca")
                                {
                                    can_pass = true;
                                }
                            }
                        }

                        if (can_pass == false)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie müssen die Waffe verwenden, mit der Sie die Munition ausrüsten möchten.", 5000);
                            return;
                        }

                        int ammo_actual = player_inventory[playerid].amount[index];

                        int value = amount;

                        if (value < 1)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie können keinen Nullwert verwenden.", 5000);
                            return;
                        }

                        if (ammo_actual < value)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie haben diesen Betrag nicht.", 5000);
                            return;
                        }

                        //
                        player.TriggerEvent("Destroy_Character_Menu");
                        RemoveItemFromInventory(player, index, value);

                        //
                        player.SetData("primary_ammunation", player.GetData("primary_ammunation") + value);
                        API.Shared.SetPlayerWeaponAmmo(player, player.CurrentWeapon, player.GetData("primary_ammunation"));
                        NAPI.Player.SetPlayerCurrentWeaponAmmo(player, player.GetData("primary_ammunation"));
                        WeaponManage.SaveWeapons(player);
                        //
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"" + itens_available[type].name + " angelegt", 5000);
                        break;
                    }
                case 102:
                    {
                        bool can_pass = false;
                        foreach (var w in Main.weapon_list)
                        {
                            if (player.CurrentWeapon == NAPI.Util.WeaponNameToModel(w.model))
                            {
                                if (w.type == "Branca")
                                {
                                    can_pass = true;
                                }
                            }
                        }

                        if (can_pass == false)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie müssen die Waffe verwenden, mit der Sie die Munition ausrüsten möchten.", 5000);
                            return;
                        }

                        int ammo_actual = player_inventory[playerid].amount[index];

                        int value = amount;

                        if (value < 1)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie können keinen Nullwert verwenden.", 5000);
                            return;
                        }

                        if (ammo_actual < value)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie haben diesen Betrag nicht.", 5000);
                            return;
                        }

                        //
                        player.TriggerEvent("Destroy_Character_Menu");
                        RemoveItemFromInventory(player, index, value);

                        //
                        player.SetData("primary_ammunation", player.GetData("primary_ammunation") + value);
                        API.Shared.SetPlayerWeaponAmmo(player, player.CurrentWeapon, player.GetData("primary_ammunation"));
                        NAPI.Player.SetPlayerCurrentWeaponAmmo(player, player.GetData("primary_ammunation"));
                        WeaponManage.SaveWeapons(player);
                        //
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"" + itens_available[type].name + " angelegt!", 5000);
                        break;
                    }
                case 103:
                    {
                        bool can_pass = false;
                        foreach (var w in Main.weapon_list)
                        {
                            if (player.CurrentWeapon == NAPI.Util.WeaponNameToModel(w.model))
                            {
                                if (w.type == "Branca")
                                {
                                    can_pass = true;
                                }
                            }
                        }

                        if (can_pass == false)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie müssen die Waffe verwenden, mit der Sie die Munition ausrüsten möchten.", 5000);
                            return;
                        }

                        int ammo_actual = player_inventory[playerid].amount[index];

                        int value = amount;

                        if (value < 1)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie können keinen Nullwert verwenden.", 5000);
                            return;
                        }

                        if (ammo_actual < value)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie haben diesen Betrag nicht.", 5000);
                            return;
                        }

                        //
                        player.TriggerEvent("Destroy_Character_Menu");
                        RemoveItemFromInventory(player, index, value);

                        //
                        player.SetData("primary_ammunation", player.GetData("primary_ammunation") + value);
                        API.Shared.SetPlayerWeaponAmmo(player, player.CurrentWeapon, player.GetData("primary_ammunation"));
                        NAPI.Player.SetPlayerCurrentWeaponAmmo(player, player.GetData("primary_ammunation"));
                        WeaponManage.SaveWeapons(player);
                        //
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"" + itens_available[type].name + " angelegt!", 5000);
                        break;
                    }
                case 104:
                    {
                        bool can_pass = false;
                        foreach (var w in Main.weapon_list)
                        {
                            if (player.CurrentWeapon == NAPI.Util.WeaponNameToModel(w.model))
                            {
                                if (w.type == "Branca")
                                {
                                    can_pass = true;
                                }
                            }
                        }

                        if (can_pass == false)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie müssen die Waffe verwenden, mit der Sie die Munition ausrüsten möchten.", 5000);
                            return;
                        }

                        int ammo_actual = player_inventory[playerid].amount[index];

                        int value = amount;

                        if (value < 1)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie können keinen Nullwert verwenden.", 5000);
                            return;
                        }

                        if (ammo_actual < value)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie haben diesen Betrag nicht.", 5000);
                            return;
                        }

                        //
                        player.TriggerEvent("Destroy_Character_Menu");
                        RemoveItemFromInventory(player, index, value);

                        //
                        player.SetData("primary_ammunation", player.GetData("primary_ammunation") + value);
                        API.Shared.SetPlayerWeaponAmmo(player, player.CurrentWeapon, player.GetData("primary_ammunation"));
                        NAPI.Player.SetPlayerCurrentWeaponAmmo(player, player.GetData("primary_ammunation"));
                        WeaponManage.SaveWeapons(player);
                        //
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"" + itens_available[type].name + " angelegt!", 5000);
                        break;
                    }
                case 105:
                    {
                        bool can_pass = false;
                        foreach (var w in Main.weapon_list)
                        {
                            if (player.CurrentWeapon == NAPI.Util.WeaponNameToModel(w.model))
                            {
                                if (w.type == "Branca")
                                {
                                    can_pass = true;
                                }
                            }
                        }

                        if (can_pass == false)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie müssen die Waffe verwenden, mit der Sie die Munition ausrüsten möchten.", 5000);
                            return;
                        }

                        int ammo_actual = player_inventory[playerid].amount[index];

                        int value = amount;

                        if (value < 1)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie können keinen Nullwert verwenden.", 5000);
                            return;
                        }

                        if (ammo_actual < value)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie haben diesen Betrag nicht.", 5000);
                            return;
                        }

                        //
                        player.TriggerEvent("Destroy_Character_Menu");
                        RemoveItemFromInventory(player, index, value);

                        //
                        player.SetData("primary_ammunation", player.GetData("primary_ammunation") + value);
                        API.Shared.SetPlayerWeaponAmmo(player, player.CurrentWeapon, player.GetData("primary_ammunation"));
                        NAPI.Player.SetPlayerCurrentWeaponAmmo(player, player.GetData("primary_ammunation"));
                        WeaponManage.SaveWeapons(player);
                        //
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"" + itens_available[type].name + " angelegt!", 5000);
                        break;
                    }
                case 106:
                    {
                        bool can_pass = false;
                        foreach (var w in Main.weapon_list)
                        {
                            if (player.CurrentWeapon == NAPI.Util.WeaponNameToModel(w.model))
                            {
                                if (w.type == "Branca")
                                {
                                    can_pass = true;
                                }
                            }
                        }

                        if (can_pass == false)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie müssen die Waffe verwenden, mit der Sie die Munition ausrüsten möchten.", 5000);
                            return;
                        }

                        int ammo_actual = player_inventory[playerid].amount[index];

                        int value = amount;

                        if (value < 1)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie können keinen Nullwert verwenden.", 5000);
                            return;
                        }

                        if (ammo_actual < value)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie haben diesen Betrag nicht.", 5000);
                            return;
                        }

                        //
                        player.TriggerEvent("Destroy_Character_Menu");
                        RemoveItemFromInventory(player, index, value);

                        //
                        player.SetData("primary_ammunation", player.GetData("primary_ammunation") + value);
                        API.Shared.SetPlayerWeaponAmmo(player, player.CurrentWeapon, player.GetData("primary_ammunation"));
                        NAPI.Player.SetPlayerCurrentWeaponAmmo(player, player.GetData("primary_ammunation"));
                        WeaponManage.SaveWeapons(player);
                        //
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"" + itens_available[type].name + " angelegt!", 5000);
                        break;
                    }
                case 107:
                    {
                        bool can_pass = false;
                        foreach (var w in Main.weapon_list)
                        {
                            if (player.CurrentWeapon == NAPI.Util.WeaponNameToModel(w.model))
                            {
                                if (w.type == "Branca")
                                {
                                    can_pass = true;
                                }
                            }
                        }

                        if (can_pass == false)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie müssen die Waffe verwenden, mit der Sie die Munition ausrüsten möchten.", 5000);
                            return;
                        }

                        int ammo_actual = player_inventory[playerid].amount[index];

                        int value = amount;

                        if (value < 1)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie können keinen Nullwert verwenden.", 5000);
                            return;
                        }

                        if (ammo_actual < value)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie haben diesen Betrag nicht.", 5000);
                            return;
                        }

                        //
                        player.TriggerEvent("Destroy_Character_Menu");
                        RemoveItemFromInventory(player, index, value);

                        //
                        player.SetData("primary_ammunation", player.GetData("primary_ammunation") + value);
                        API.Shared.SetPlayerWeaponAmmo(player, player.CurrentWeapon, player.GetData("primary_ammunation"));
                        NAPI.Player.SetPlayerCurrentWeaponAmmo(player, player.GetData("primary_ammunation"));
                        WeaponManage.SaveWeapons(player);
                        //
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"" + itens_available[type].name + " angelegt!", 5000);
                        break;
                    }
                case 108:
                    {
                        bool can_pass = false;
                        foreach (var w in Main.weapon_list)
                        {
                            if (player.CurrentWeapon == NAPI.Util.WeaponNameToModel(w.model))
                            {
                                if (w.type == "Branca")
                                {
                                    can_pass = true;
                                }
                            }
                        }

                        if (can_pass == false)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie müssen die Waffe verwenden, mit der Sie die Munition ausrüsten möchten.", 5000);
                            return;
                        }

                        int ammo_actual = player_inventory[playerid].amount[index];

                        int value = amount;

                        if (value < 1)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie können keinen Nullwert verwenden.", 5000);
                            return;
                        }

                        if (ammo_actual < value)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie haben diesen Betrag nicht.", 5000);
                            return;
                        }

                        //
                        player.TriggerEvent("Destroy_Character_Menu");
                        RemoveItemFromInventory(player, index, value);

                        //
                        player.SetData("primary_ammunation", player.GetData("primary_ammunation") + value);
                        API.Shared.SetPlayerWeaponAmmo(player, player.CurrentWeapon, player.GetData("primary_ammunation"));
                        NAPI.Player.SetPlayerCurrentWeaponAmmo(player, player.GetData("primary_ammunation"));
                        WeaponManage.SaveWeapons(player);
                        //
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"" + itens_available[type].name + " angelegt!", 5000);
                        break;
                    }
                case 109:
                    {
                        bool can_pass = false;
                        foreach (var w in Main.weapon_list)
                        {
                            if (player.CurrentWeapon == NAPI.Util.WeaponNameToModel(w.model))
                            {
                                if (w.type == "Branca")
                                {
                                    can_pass = true;
                                }
                            }
                        }

                        if (can_pass == false)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie müssen die Waffe verwenden, mit der Sie die Munition ausrüsten möchten.", 5000);
                            return;
                        }

                        int ammo_actual = player_inventory[playerid].amount[index];

                        int value = amount;

                        if (value < 1)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie können keinen Nullwert verwenden.", 5000);
                            return;
                        }

                        if (ammo_actual < value)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie haben diesen Betrag nicht.", 5000);
                            return;
                        }

                        //
                        player.TriggerEvent("Destroy_Character_Menu");
                        RemoveItemFromInventory(player, index, value);

                        //
                        player.SetData("primary_ammunation", player.GetData("primary_ammunation") + value);
                        API.Shared.SetPlayerWeaponAmmo(player, player.CurrentWeapon, player.GetData("primary_ammunation"));
                        NAPI.Player.SetPlayerCurrentWeaponAmmo(player, player.GetData("primary_ammunation"));
                        WeaponManage.SaveWeapons(player);
                        //
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"" + itens_available[type].name + " angelegt!", 5000);
                        break;
                    }
                case 110:
                    {
                        bool can_pass = false;
                        foreach (var w in Main.weapon_list)
                        {
                            if (player.CurrentWeapon == NAPI.Util.WeaponNameToModel(w.model))
                            {
                                if (w.type == "Branca")
                                {
                                    can_pass = true;
                                }
                            }
                        }

                        if (can_pass == false)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie müssen die Waffe verwenden, mit der Sie die Munition ausrüsten möchten.", 5000);
                            return;
                        }

                        int ammo_actual = player_inventory[playerid].amount[index];

                        int value = amount;

                        if (value < 1)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie können keinen Nullwert verwenden.", 5000);
                            return;
                        }

                        if (ammo_actual < value)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie haben diesen Betrag nicht.", 5000);
                            return;
                        }

                        //
                        player.TriggerEvent("Destroy_Character_Menu");
                        RemoveItemFromInventory(player, index, value);

                        //
                        player.SetData("primary_ammunation", player.GetData("primary_ammunation") + value);
                        API.Shared.SetPlayerWeaponAmmo(player, player.CurrentWeapon, player.GetData("primary_ammunation"));
                        NAPI.Player.SetPlayerCurrentWeaponAmmo(player, player.GetData("primary_ammunation"));
                        WeaponManage.SaveWeapons(player);
                        //
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"" + itens_available[type].name + " angelegt!", 5000);
                        break;
                    }
                case 111:
                    {
                        bool can_pass = false;
                        foreach (var w in Main.weapon_list)
                        {
                            if (player.CurrentWeapon == NAPI.Util.WeaponNameToModel(w.model))
                            {
                                if (w.type == "Branca")
                                {
                                    can_pass = true;
                                }
                            }
                        }

                        if (can_pass == false)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie müssen die Waffe verwenden, mit der Sie die Munition ausrüsten möchten.", 5000);
                            return;
                        }

                        int ammo_actual = player_inventory[playerid].amount[index];

                        int value = amount;

                        if (value < 1)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie können keinen Nullwert verwenden.", 5000);
                            return;
                        }

                        if (ammo_actual < value)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie haben diesen Betrag nicht.", 5000);
                            return;
                        }

                        //
                        player.TriggerEvent("Destroy_Character_Menu");
                        RemoveItemFromInventory(player, index, value);

                        //
                        player.SetData("primary_ammunation", player.GetData("primary_ammunation") + value);
                        API.Shared.SetPlayerWeaponAmmo(player, player.CurrentWeapon, player.GetData("primary_ammunation"));
                        NAPI.Player.SetPlayerCurrentWeaponAmmo(player, player.GetData("primary_ammunation"));
                        WeaponManage.SaveWeapons(player);
                        //
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"" + itens_available[type].name + " angelegt!", 5000);
                        break;
                    }
                case 112:
                    {
                        bool can_pass = false;
                        foreach (var w in Main.weapon_list)
                        {
                            if (player.CurrentWeapon == NAPI.Util.WeaponNameToModel(w.model))
                            {
                                if (w.type == "Branca")
                                {
                                    can_pass = true;
                                }
                            }
                        }

                        if (can_pass == false)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie müssen die Waffe verwenden, mit der Sie die Munition ausrüsten möchten.", 5000);
                            return;
                        }

                        int ammo_actual = player_inventory[playerid].amount[index];

                        int value = amount;

                        if (value < 1)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie können keinen Nullwert verwenden.", 5000);
                            return;
                        }

                        if (ammo_actual < value)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie haben diesen Betrag nicht.", 5000);
                            return;
                        }

                        //
                        player.TriggerEvent("Destroy_Character_Menu");
                        RemoveItemFromInventory(player, index, value);
                        WeaponManage.SaveWeapons(player);
                        //
                        player.SetData("primary_ammunation", player.GetData("primary_ammunation") + value);
                        API.Shared.SetPlayerWeaponAmmo(player, player.CurrentWeapon, player.GetData("primary_ammunation"));
                        NAPI.Player.SetPlayerCurrentWeaponAmmo(player, player.GetData("primary_ammunation"));
                        //
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"" + itens_available[type].name + " angelegt!", 5000);
                        break;
                    }
                case 113:
                    {
                        bool can_pass = false;
                        foreach (var w in Main.weapon_list)
                        {
                            if (player.CurrentWeapon == NAPI.Util.WeaponNameToModel(w.model))
                            {
                                if (w.type == "Handguns")
                                {
                                    can_pass = true;
                                }
                            }
                        }

                        if (can_pass == false)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie müssen die Waffe verwenden, mit der Sie die Munition ausrüsten möchten.", 5000);
                            return;
                        }

                        int ammo_actual = player_inventory[playerid].amount[index];

                        int value = amount;

                        if (value < 1)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie können keinen Nullwert verwenden.", 5000);
                            return;
                        }

                        if (ammo_actual < value)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie haben diesen Betrag nicht.", 5000);
                            return;
                        }

                        //
                        player.TriggerEvent("Destroy_Character_Menu");
                        RemoveItemFromInventory(player, index, value);

                        //
                        player.SetData("primary_ammunation", player.GetData("primary_ammunation") + value);
                        API.Shared.SetPlayerWeaponAmmo(player, player.CurrentWeapon, player.GetData("primary_ammunation"));
                        NAPI.Player.SetPlayerCurrentWeaponAmmo(player, player.GetData("primary_ammunation"));
                        WeaponManage.SaveWeapons(player);
                        //
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"" + itens_available[type].name + " angelegt!", 5000);
                        break;
                    }
                case 114:
                    {
                        bool can_pass = false;
                        foreach (var w in Main.weapon_list)
                        {
                            if (player.CurrentWeapon == NAPI.Util.WeaponNameToModel(w.model))
                            {
                                if (w.type == "Handguns")
                                {
                                    can_pass = true;
                                }
                            }
                        }

                        if (can_pass == false)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie müssen die Waffe verwenden, mit der Sie die Munition ausrüsten möchten.", 5000);
                            return;
                        }

                        int ammo_actual = player_inventory[playerid].amount[index];

                        int value = amount;

                        if (value < 1)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie können keinen Nullwert verwenden.", 5000);
                            return;
                        }

                        if (ammo_actual < value)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie haben diesen Betrag nicht.", 5000);
                            return;
                        }

                        //
                        player.TriggerEvent("Destroy_Character_Menu");
                        RemoveItemFromInventory(player, index, value);

                        //
                        player.SetData("primary_ammunation", player.GetData("primary_ammunation") + value);
                        API.Shared.SetPlayerWeaponAmmo(player, player.CurrentWeapon, player.GetData("primary_ammunation"));
                        NAPI.Player.SetPlayerCurrentWeaponAmmo(player, player.GetData("primary_ammunation"));
                        WeaponManage.SaveWeapons(player);
                        //
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"" + itens_available[type].name + " angelegt!", 5000);
                        break;
                    }
                case 115:
                    {
                        bool can_pass = false;
                        foreach (var w in Main.weapon_list)
                        {
                            if (player.CurrentWeapon == NAPI.Util.WeaponNameToModel(w.model))
                            {
                                if (w.type == "Handguns")
                                {
                                    can_pass = true;
                                }
                            }
                        }

                        if (can_pass == false)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie müssen die Waffe verwenden, mit der Sie die Munition ausrüsten möchten.", 5000);
                            return;
                        }

                        int ammo_actual = player_inventory[playerid].amount[index];

                        int value = amount;

                        if (value < 1)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie können keinen Nullwert verwenden.", 5000);
                            return;
                        }

                        if (ammo_actual < value)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie haben diesen Betrag nicht.", 5000);
                            return;
                        }

                        //
                        player.TriggerEvent("Destroy_Character_Menu");
                        RemoveItemFromInventory(player, index, value);

                        //
                        player.SetData("primary_ammunation", player.GetData("primary_ammunation") + value);
                        API.Shared.SetPlayerWeaponAmmo(player, player.CurrentWeapon, player.GetData("primary_ammunation"));
                        NAPI.Player.SetPlayerCurrentWeaponAmmo(player, player.GetData("primary_ammunation"));
                        WeaponManage.SaveWeapons(player);
                        //
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"" + itens_available[type].name + " angelegt!", 5000);
                        break;
                    }
                case 116:
                    {
                        bool can_pass = false;
                        foreach (var w in Main.weapon_list)
                        {
                            if (player.CurrentWeapon == NAPI.Util.WeaponNameToModel(w.model))
                            {
                                if (w.type == "Handguns")
                                {
                                    can_pass = true;
                                }
                            }
                        }

                        if (can_pass == false)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie müssen die Waffe verwenden, mit der Sie die Munition ausrüsten möchten.", 5000);
                            return;
                        }

                        int ammo_actual = player_inventory[playerid].amount[index];

                        int value = amount;

                        if (value < 1)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie können keinen Nullwert verwenden.", 5000);
                            return;
                        }

                        if (ammo_actual < value)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie haben diesen Betrag nicht.", 5000);
                            return;
                        }

                        //
                        player.TriggerEvent("Destroy_Character_Menu");
                        RemoveItemFromInventory(player, index, value);

                        //
                        player.SetData("primary_ammunation", player.GetData("primary_ammunation") + value);
                        API.Shared.SetPlayerWeaponAmmo(player, player.CurrentWeapon, player.GetData("primary_ammunation"));
                        NAPI.Player.SetPlayerCurrentWeaponAmmo(player, player.GetData("primary_ammunation"));
                        WeaponManage.SaveWeapons(player);
                        //
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"" + itens_available[type].name + " angelegt!", 5000);
                        break;
                    }
                case 117:
                    {
                        bool can_pass = false;
                        foreach (var w in Main.weapon_list)
                        {
                            if (player.CurrentWeapon == NAPI.Util.WeaponNameToModel(w.model))
                            {
                                if (w.type == "Handguns")
                                {
                                    can_pass = true;
                                }
                            }
                        }

                        if (can_pass == false)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie müssen die Waffe verwenden, mit der Sie die Munition ausrüsten möchten.", 5000);
                            return;
                        }

                        int ammo_actual = player_inventory[playerid].amount[index];

                        int value = amount;

                        if (value < 1)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie können keinen Nullwert verwenden.", 5000);
                            return;
                        }

                        if (ammo_actual < value)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie haben diesen Betrag nicht.", 5000);
                            return;
                        }

                        //
                        player.TriggerEvent("Destroy_Character_Menu");
                        RemoveItemFromInventory(player, index, value);

                        //
                        player.SetData("primary_ammunation", player.GetData("primary_ammunation") + value);
                        API.Shared.SetPlayerWeaponAmmo(player, player.CurrentWeapon, player.GetData("primary_ammunation"));
                        NAPI.Player.SetPlayerCurrentWeaponAmmo(player, player.GetData("primary_ammunation"));
                        WeaponManage.SaveWeapons(player);
                        //
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"" + itens_available[type].name + " angelegt!", 5000);
                        break;
                    }
                case 118:
                    {
                        bool can_pass = false;
                        foreach (var w in Main.weapon_list)
                        {
                            if (player.CurrentWeapon == NAPI.Util.WeaponNameToModel(w.model))
                            {
                                if (w.type == "Handguns")
                                {
                                    can_pass = true;
                                }
                            }
                        }

                        if (can_pass == false)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie müssen die Waffe verwenden, mit der Sie die Munition ausrüsten möchten.", 5000);
                            return;
                        }

                        int ammo_actual = player_inventory[playerid].amount[index];

                        int value = amount;

                        if (value < 1)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie können keinen Nullwert verwenden.", 5000);
                            return;
                        }

                        if (ammo_actual < value)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie haben diesen Betrag nicht.", 5000);
                            return;
                        }

                        //
                        player.TriggerEvent("Destroy_Character_Menu");
                        RemoveItemFromInventory(player, index, value);

                        //
                        player.SetData("primary_ammunation", player.GetData("primary_ammunation") + value);
                        API.Shared.SetPlayerWeaponAmmo(player, player.CurrentWeapon, player.GetData("primary_ammunation"));
                        NAPI.Player.SetPlayerCurrentWeaponAmmo(player, player.GetData("primary_ammunation"));
                        WeaponManage.SaveWeapons(player);
                        //
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"" + itens_available[type].name + " angelegt!", 5000);
                        break;
                    }
                case 119:
                    {
                        bool can_pass = false;
                        foreach (var w in Main.weapon_list)
                        {
                            if (player.CurrentWeapon == NAPI.Util.WeaponNameToModel(w.model))
                            {
                                if (w.type == "Handguns")
                                {
                                    can_pass = true;
                                }
                            }
                        }

                        if (can_pass == false)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie müssen die Waffe verwenden, mit der Sie die Munition ausrüsten möchten.", 5000);
                            return;
                        }

                        int ammo_actual = player_inventory[playerid].amount[index];

                        int value = amount;

                        if (value < 1)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie können keinen Nullwert verwenden.", 5000);
                            return;
                        }

                        if (ammo_actual < value)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie haben diesen Betrag nicht.", 5000);
                            return;
                        }

                        //
                        player.TriggerEvent("Destroy_Character_Menu");
                        RemoveItemFromInventory(player, index, value);

                        //
                        player.SetData("primary_ammunation", player.GetData("primary_ammunation") + value);
                        API.Shared.SetPlayerWeaponAmmo(player, player.CurrentWeapon, player.GetData("primary_ammunation"));
                        NAPI.Player.SetPlayerCurrentWeaponAmmo(player, player.GetData("primary_ammunation"));
                        WeaponManage.SaveWeapons(player);
                        //
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"" + itens_available[type].name + " angelegt!", 5000);
                        break;
                    }
                case 120:
                    {
                        bool can_pass = false;
                        foreach (var w in Main.weapon_list)
                        {
                            if (player.CurrentWeapon == NAPI.Util.WeaponNameToModel(w.model))
                            {
                                if (w.type == "Handguns")
                                {
                                    can_pass = true;
                                }
                            }
                        }

                        if (can_pass == false)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie müssen die Waffe verwenden, mit der Sie die Munition ausrüsten möchten.", 5000);
                            return;
                        }

                        int ammo_actual = player_inventory[playerid].amount[index];

                        int value = amount;

                        if (value < 1)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie können keinen Nullwert verwenden.", 5000);
                            return;
                        }

                        if (ammo_actual < value)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie haben diesen Betrag nicht.", 5000);
                            return;
                        }

                        //
                        player.TriggerEvent("Destroy_Character_Menu");
                        RemoveItemFromInventory(player, index, value);

                        //
                        player.SetData("primary_ammunation", player.GetData("primary_ammunation") + value);
                        API.Shared.SetPlayerWeaponAmmo(player, player.CurrentWeapon, player.GetData("primary_ammunation"));
                        NAPI.Player.SetPlayerCurrentWeaponAmmo(player, player.GetData("primary_ammunation"));
                        WeaponManage.SaveWeapons(player);
                        //
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"" + itens_available[type].name + " angelegt!", 5000);
                        break;
                    }
                case 121:
                    {
                        bool can_pass = false;
                        foreach (var w in Main.weapon_list)
                        {
                            if (player.CurrentWeapon == NAPI.Util.WeaponNameToModel(w.model))
                            {
                                if (w.type == "Handguns")
                                {
                                    can_pass = true;
                                }
                            }
                        }

                        if (can_pass == false)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie müssen die Waffe verwenden, mit der Sie die Munition ausrüsten möchten.", 5000);
                            return;
                        }

                        int ammo_actual = player_inventory[playerid].amount[index];

                        int value = amount;

                        if (value < 1)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie können keinen Nullwert verwenden.", 5000);
                            return;
                        }

                        if (ammo_actual < value)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie haben diesen Betrag nicht.", 5000);
                            return;
                        }

                        //
                        player.TriggerEvent("Destroy_Character_Menu");
                        RemoveItemFromInventory(player, index, value);

                        //
                        player.SetData("primary_ammunation", player.GetData("primary_ammunation") + value);
                        API.Shared.SetPlayerWeaponAmmo(player, player.CurrentWeapon, player.GetData("primary_ammunation"));
                        NAPI.Player.SetPlayerCurrentWeaponAmmo(player, player.GetData("primary_ammunation"));
                        WeaponManage.SaveWeapons(player);
                        //
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"" + itens_available[type].name + " angelegt!", 5000);
                        break;
                    }
                case 122:
                    {
                        bool can_pass = false;
                        foreach (var w in Main.weapon_list)
                        {
                            if (player.CurrentWeapon == NAPI.Util.WeaponNameToModel(w.model))
                            {
                                if (w.type == "Handguns")
                                {
                                    can_pass = true;
                                }
                            }
                        }

                        if (can_pass == false)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie müssen die Waffe verwenden, mit der Sie die Munition ausrüsten möchten.", 5000);
                            return;
                        }

                        int ammo_actual = player_inventory[playerid].amount[index];

                        int value = amount;

                        if (value < 1)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie können keinen Nullwert verwenden.", 5000);
                            return;
                        }

                        if (ammo_actual < value)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie haben diesen Betrag nicht.", 5000);
                            return;
                        }

                        //
                        player.TriggerEvent("Destroy_Character_Menu");
                        RemoveItemFromInventory(player, index, value);

                        //
                        player.SetData("primary_ammunation", player.GetData("primary_ammunation") + value);
                        API.Shared.SetPlayerWeaponAmmo(player, player.CurrentWeapon, player.GetData("primary_ammunation"));
                        NAPI.Player.SetPlayerCurrentWeaponAmmo(player, player.GetData("primary_ammunation"));
                        WeaponManage.SaveWeapons(player);
                        //
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"" + itens_available[type].name + " angelegt!", 5000);
                        break;
                    }
                case 123:
                    {
                        bool can_pass = false;
                        foreach (var w in Main.weapon_list)
                        {
                            if (player.CurrentWeapon == NAPI.Util.WeaponNameToModel(w.model))
                            {
                                if (w.type == "Machine Guns")
                                {
                                    can_pass = true;
                                }
                            }
                        }

                        if (can_pass == false)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie müssen die Waffe verwenden, mit der Sie die Munition ausrüsten möchten.", 5000);
                            return;
                        }

                        int ammo_actual = player_inventory[playerid].amount[index];

                        int value = amount;

                        if (value < 1)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie können keinen Nullwert verwenden.", 5000);
                            return;
                        }

                        if (ammo_actual < value)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie haben diesen Betrag nicht.", 5000);
                            return;
                        }

                        //
                        player.TriggerEvent("Destroy_Character_Menu");
                        RemoveItemFromInventory(player, index, value);

                        //
                        player.SetData("primary_ammunation", player.GetData("primary_ammunation") + value);
                        API.Shared.SetPlayerWeaponAmmo(player, player.CurrentWeapon, player.GetData("primary_ammunation"));
                        NAPI.Player.SetPlayerCurrentWeaponAmmo(player, player.GetData("primary_ammunation"));
                        WeaponManage.SaveWeapons(player);
                        //
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"" + itens_available[type].name + " angelegt!", 5000);
                        break;
                    }
                case 124:
                    {
                        bool can_pass = false;
                        foreach (var w in Main.weapon_list)
                        {
                            if (player.CurrentWeapon == NAPI.Util.WeaponNameToModel(w.model))
                            {
                                if (w.type == "Machine Guns")
                                {
                                    can_pass = true;
                                }
                            }
                        }

                        if (can_pass == false)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie müssen die Waffe verwenden, mit der Sie die Munition ausrüsten möchten.", 5000);
                            return;
                        }

                        int ammo_actual = player_inventory[playerid].amount[index];

                        int value = amount;

                        if (value < 1)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie können keinen Nullwert verwenden.", 5000);
                            return;
                        }

                        if (ammo_actual < value)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie haben diesen Betrag nicht.", 5000);
                            return;
                        }

                        //
                        player.TriggerEvent("Destroy_Character_Menu");
                        RemoveItemFromInventory(player, index, value);

                        //
                        player.SetData("primary_ammunation", player.GetData("primary_ammunation") + value);
                        API.Shared.SetPlayerWeaponAmmo(player, player.CurrentWeapon, player.GetData("primary_ammunation"));
                        NAPI.Player.SetPlayerCurrentWeaponAmmo(player, player.GetData("primary_ammunation"));
                        WeaponManage.SaveWeapons(player);
                        //
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"" + itens_available[type].name + " angelegt!", 5000);
                        break;
                    }
                case 125:
                    {
                        bool can_pass = false;
                        foreach (var w in Main.weapon_list)
                        {
                            if (player.CurrentWeapon == NAPI.Util.WeaponNameToModel(w.model))
                            {
                                if (w.type == "Machine Guns")
                                {
                                    can_pass = true;
                                }
                            }
                        }

                        if (can_pass == false)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie müssen die Waffe verwenden, mit der Sie die Munition ausrüsten möchten.", 5000);
                            return;
                        }

                        int ammo_actual = player_inventory[playerid].amount[index];

                        int value = amount;

                        if (value < 1)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie können keinen Nullwert verwenden.", 5000);
                            return;
                        }

                        if (ammo_actual < value)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie haben diesen Betrag nicht.", 5000);
                            return;
                        }

                        //
                        player.TriggerEvent("Destroy_Character_Menu");
                        RemoveItemFromInventory(player, index, value);

                        //
                        player.SetData("primary_ammunation", player.GetData("primary_ammunation") + value);
                        API.Shared.SetPlayerWeaponAmmo(player, player.CurrentWeapon, player.GetData("primary_ammunation"));
                        NAPI.Player.SetPlayerCurrentWeaponAmmo(player, player.GetData("primary_ammunation"));
                        WeaponManage.SaveWeapons(player);
                        //
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"" + itens_available[type].name + " angelegt!", 5000);
                        break;
                    }
                case 126:
                    {
                        bool can_pass = false;
                        foreach (var w in Main.weapon_list)
                        {
                            if (player.CurrentWeapon == NAPI.Util.WeaponNameToModel(w.model))
                            {
                                if (w.type == "Shotguns")
                                {
                                    can_pass = true;
                                }
                            }
                        }

                        if (can_pass == false)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie müssen die Waffe verwenden, mit der Sie die Munition ausrüsten möchten.", 5000);
                            return;
                        }

                        int ammo_actual = player_inventory[playerid].amount[index];

                        int value = amount;

                        if (value < 1)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie können keinen Nullwert verwenden.", 5000);
                            return;
                        }

                        if (ammo_actual < value)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie haben diesen Betrag nicht.", 5000);
                            return;
                        }

                        //
                        player.TriggerEvent("Destroy_Character_Menu");
                        RemoveItemFromInventory(player, index, value);

                        //
                        player.SetData("primary_ammunation", player.GetData("primary_ammunation") + value);
                        API.Shared.SetPlayerWeaponAmmo(player, player.CurrentWeapon, player.GetData("primary_ammunation"));
                        NAPI.Player.SetPlayerCurrentWeaponAmmo(player, player.GetData("primary_ammunation"));
                        WeaponManage.SaveWeapons(player);
                        //
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"" + itens_available[type].name + " angelegt!", 5000);
                        break;
                    }
                case 127:
                    {
                        bool can_pass = false;
                        foreach (var w in Main.weapon_list)
                        {
                            if (player.CurrentWeapon == NAPI.Util.WeaponNameToModel(w.model))
                            {
                                if (w.type == "Shotguns")
                                {
                                    can_pass = true;
                                }
                            }
                        }

                        if (can_pass == false)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie müssen die Waffe verwenden, mit der Sie die Munition ausrüsten möchten.", 5000);
                            return;
                        }

                        int ammo_actual = player_inventory[playerid].amount[index];

                        int value = amount;

                        if (value < 1)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie können keinen Nullwert verwenden.", 5000);
                            return;
                        }

                        if (ammo_actual < value)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie haben diesen Betrag nicht.", 5000);
                            return;
                        }

                        //
                        player.TriggerEvent("Destroy_Character_Menu");
                        RemoveItemFromInventory(player, index, value);

                        //
                        player.SetData("primary_ammunation", player.GetData("primary_ammunation") + value);
                        API.Shared.SetPlayerWeaponAmmo(player, player.CurrentWeapon, player.GetData("primary_ammunation"));
                        NAPI.Player.SetPlayerCurrentWeaponAmmo(player, player.GetData("primary_ammunation"));
                        WeaponManage.SaveWeapons(player);
                        //
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"" + itens_available[type].name + " angelegt!", 5000);
                        break;
                    }
                case 128:
                    {
                        bool can_pass = false;
                        foreach (var w in Main.weapon_list)
                        {
                            if (player.CurrentWeapon == NAPI.Util.WeaponNameToModel(w.model))
                            {
                                if (w.type == "Machine Guns")
                                {
                                    can_pass = true;
                                }
                            }
                        }

                        if (can_pass == false)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie müssen die Waffe verwenden, mit der Sie die Munition ausrüsten möchten.", 5000);
                            return;
                        }

                        int ammo_actual = player_inventory[playerid].amount[index];

                        int value = amount;

                        if (value < 1)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie können keinen Nullwert verwenden.", 5000);
                            return;
                        }

                        if (ammo_actual < value)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie haben diesen Betrag nicht.", 5000);
                            return;
                        }

                        //
                        player.TriggerEvent("Destroy_Character_Menu");
                        RemoveItemFromInventory(player, index, value);

                        //
                        player.SetData("primary_ammunation", player.GetData("primary_ammunation") + value);
                        API.Shared.SetPlayerWeaponAmmo(player, player.CurrentWeapon, player.GetData("primary_ammunation"));
                        NAPI.Player.SetPlayerCurrentWeaponAmmo(player, player.GetData("primary_ammunation"));
                        WeaponManage.SaveWeapons(player);
                        //
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"" + itens_available[type].name + " angelegt!", 5000);
                        break;
                    }
                case 129:
                    {
                        bool can_pass = false;
                        foreach (var w in Main.weapon_list)
                        {
                            if (player.CurrentWeapon == NAPI.Util.WeaponNameToModel(w.model))
                            {
                                if (w.type == "Machine Guns")
                                {
                                    can_pass = true;
                                }
                            }
                        }

                        if (can_pass == false)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie müssen die Waffe verwenden, mit der Sie die Munition ausrüsten möchten.", 5000);
                            return;
                        }

                        int ammo_actual = player_inventory[playerid].amount[index];

                        int value = amount;

                        if (value < 1)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie können keinen Nullwert verwenden.", 5000);
                            return;
                        }

                        if (ammo_actual < value)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie haben diesen Betrag nicht.", 5000);
                            return;
                        }

                        //
                        player.TriggerEvent("Destroy_Character_Menu");
                        RemoveItemFromInventory(player, index, value);

                        //
                        player.SetData("primary_ammunation", player.GetData("primary_ammunation") + value);
                        API.Shared.SetPlayerWeaponAmmo(player, player.CurrentWeapon, player.GetData("primary_ammunation"));
                        NAPI.Player.SetPlayerCurrentWeaponAmmo(player, player.GetData("primary_ammunation"));
                        WeaponManage.SaveWeapons(player);
                        //
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"" + itens_available[type].name + " angelegt!", 5000);
                        break;
                    }
                case 130:
                    {
                        bool can_pass = false;
                        foreach (var w in Main.weapon_list)
                        {
                            if (player.CurrentWeapon == NAPI.Util.WeaponNameToModel(w.model))
                            {
                                if (w.type == "Handguns")
                                {
                                    can_pass = true;
                                }
                            }
                        }

                        if (can_pass == false)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie müssen die Waffe verwenden, mit der Sie die Munition ausrüsten möchten.", 5000);
                            return;
                        }

                        int ammo_actual = player_inventory[playerid].amount[index];

                        int value = amount;

                        if (value < 1)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie können keinen Nullwert verwenden.", 5000);
                            return;
                        }

                        if (ammo_actual < value)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie haben diesen Betrag nicht.", 5000);
                            return;
                        }

                        //
                        player.TriggerEvent("Destroy_Character_Menu");
                        RemoveItemFromInventory(player, index, value);

                        //
                        player.SetData("primary_ammunation", player.GetData("primary_ammunation") + value);
                        API.Shared.SetPlayerWeaponAmmo(player, player.CurrentWeapon, player.GetData("primary_ammunation"));
                        NAPI.Player.SetPlayerCurrentWeaponAmmo(player, player.GetData("primary_ammunation"));
                        WeaponManage.SaveWeapons(player);
                        //
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"" + itens_available[type].name + " angelegt!", 5000);
                        break;
                    }
                case 131:
                    {
                        bool can_pass = false;
                        foreach (var w in Main.weapon_list)
                        {
                            if (player.CurrentWeapon == NAPI.Util.WeaponNameToModel(w.model))
                            {
                                if (w.type == "Branca")
                                {
                                    can_pass = true;
                                }
                            }
                        }

                        if (can_pass == false)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie müssen die Waffe verwenden, mit der Sie die Munition ausrüsten möchten.", 5000);
                            return;
                        }

                        int ammo_actual = player_inventory[playerid].amount[index];

                        int value = amount;

                        if (value < 1)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie können keinen Nullwert verwenden.", 5000);
                            return;
                        }

                        if (ammo_actual < value)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie haben diesen Betrag nicht.", 5000);
                            return;
                        }

                        //
                        player.TriggerEvent("Destroy_Character_Menu");
                        RemoveItemFromInventory(player, index, value);

                        //
                        player.SetData("primary_ammunation", player.GetData("primary_ammunation") + value);
                        API.Shared.SetPlayerWeaponAmmo(player, player.CurrentWeapon, player.GetData("primary_ammunation"));
                        NAPI.Player.SetPlayerCurrentWeaponAmmo(player, player.GetData("primary_ammunation"));
                        WeaponManage.SaveWeapons(player);
                        //
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"" + itens_available[type].name + " angelegt!", 5000);
                        break;
                    }
                case 132:
                    {
                        bool can_pass = false;
                        foreach (var w in Main.weapon_list)
                        {
                            if (player.CurrentWeapon == NAPI.Util.WeaponNameToModel(w.model))
                            {
                                if (w.type == "Branca")
                                {
                                    can_pass = true;
                                }
                            }
                        }

                        if (can_pass == false)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie müssen die Waffe verwenden, mit der Sie die Munition ausrüsten möchten.", 5000);
                            return;
                        }

                        int ammo_actual = player_inventory[playerid].amount[index];

                        int value = amount;

                        if (value < 1)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie können keinen Nullwert verwenden.", 5000);
                            return;
                        }

                        if (ammo_actual < value)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie haben diesen Betrag nicht.", 5000);
                            return;
                        }

                        //
                        player.TriggerEvent("Destroy_Character_Menu");
                        RemoveItemFromInventory(player, index, value);

                        //
                        player.SetData("primary_ammunation", player.GetData("primary_ammunation") + value);
                        API.Shared.SetPlayerWeaponAmmo(player, player.CurrentWeapon, player.GetData("primary_ammunation"));
                        NAPI.Player.SetPlayerCurrentWeaponAmmo(player, player.GetData("primary_ammunation"));
                        WeaponManage.SaveWeapons(player);
                        //
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"" + itens_available[type].name + " angelegt!", 5000);
                        break;
                    }
                case 133:
                    {
                        bool can_pass = false;
                        foreach (var w in Main.weapon_list)
                        {
                            if (player.CurrentWeapon == NAPI.Util.WeaponNameToModel(w.model))
                            {
                                if (w.type == "Branca")
                                {
                                    can_pass = true;
                                }
                            }
                        }

                        if (can_pass == false)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie müssen die Waffe verwenden, mit der Sie die Munition ausrüsten möchten.", 5000);
                            return;
                        }

                        int ammo_actual = player_inventory[playerid].amount[index];

                        int value = amount;

                        if (value < 1)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie können keinen Nullwert verwenden.", 5000);
                            return;
                        }

                        if (ammo_actual < value)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie haben diesen Betrag nicht.", 5000);
                            return;
                        }

                        //
                        player.TriggerEvent("Destroy_Character_Menu");
                        RemoveItemFromInventory(player, index, value);

                        //
                        player.SetData("primary_ammunation", player.GetData("primary_ammunation") + value);
                        API.Shared.SetPlayerWeaponAmmo(player, player.CurrentWeapon, player.GetData("primary_ammunation"));
                        NAPI.Player.SetPlayerCurrentWeaponAmmo(player, player.GetData("primary_ammunation"));
                        WeaponManage.SaveWeapons(player);
                        //
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"" + itens_available[type].name + " angelegt!", 5000);
                        break;
                    }
                case 134:
                    {
                        bool can_pass = false;
                        foreach (var w in Main.weapon_list)
                        {
                            if (player.CurrentWeapon == NAPI.Util.WeaponNameToModel(w.model))
                            {
                                if (w.type == "Branca")
                                {
                                    can_pass = true;
                                }
                            }
                        }

                        if (can_pass == false)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie müssen die Waffe verwenden, mit der Sie die Munition ausrüsten möchten.", 5000);
                            return;
                        }

                        int ammo_actual = player_inventory[playerid].amount[index];

                        int value = amount;

                        if (value < 1)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie können keinen Nullwert verwenden.", 5000);
                            return;
                        }

                        if (ammo_actual < value)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie haben diesen Betrag nicht.", 5000);
                            return;
                        }

                        //
                        player.TriggerEvent("Destroy_Character_Menu");
                        RemoveItemFromInventory(player, index, value);

                        //
                        player.SetData("primary_ammunation", player.GetData("primary_ammunation") + value);
                        API.Shared.SetPlayerWeaponAmmo(player, player.CurrentWeapon, player.GetData("primary_ammunation"));
                        NAPI.Player.SetPlayerCurrentWeaponAmmo(player, player.GetData("primary_ammunation"));
                        WeaponManage.SaveWeapons(player);
                        //
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"" + itens_available[type].name + " angelegt!", 5000);
                        break;
                    }
                case 135:
                    {
                        bool can_pass = false;
                        foreach (var w in Main.weapon_list)
                        {
                            if (player.CurrentWeapon == NAPI.Util.WeaponNameToModel(w.model))
                            {
                                if (w.type == "Branca")
                                {
                                    can_pass = true;
                                }
                            }
                        }

                        if (can_pass == false)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie müssen die Waffe verwenden, mit der Sie die Munition ausrüsten möchten.", 5000);
                            return;
                        }

                        int ammo_actual = player_inventory[playerid].amount[index];

                        int value = amount;

                        if (value < 1)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie können keinen Nullwert verwenden.", 5000);
                            return;
                        }

                        if (ammo_actual < value)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie haben diesen Betrag nicht.", 5000);
                            return;
                        }

                        //
                        player.TriggerEvent("Destroy_Character_Menu");
                        RemoveItemFromInventory(player, index, value);

                        //
                        player.SetData("primary_ammunation", player.GetData("primary_ammunation") + value);
                        API.Shared.SetPlayerWeaponAmmo(player, player.CurrentWeapon, player.GetData("primary_ammunation"));
                        NAPI.Player.SetPlayerCurrentWeaponAmmo(player, player.GetData("primary_ammunation"));
                        WeaponManage.SaveWeapons(player);
                        //
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"" + itens_available[type].name + " angelegt!", 5000);
                        break;
                    }
                case 136:
                    {
                        bool can_pass = false;
                        foreach (var w in Main.weapon_list)
                        {
                            if (player.CurrentWeapon == NAPI.Util.WeaponNameToModel(w.model))
                            {
                                if (w.type == "Machine Guns")
                                {
                                    can_pass = true;
                                }
                            }
                        }

                        if (can_pass == false)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie müssen die Waffe verwenden, mit der Sie die Munition ausrüsten möchten.", 5000);
                            return;
                        }

                        int ammo_actual = player_inventory[playerid].amount[index];

                        int value = amount;

                        if (value < 1)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie können keinen Nullwert verwenden.", 5000);
                            return;
                        }

                        if (ammo_actual < value)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie haben diesen Betrag nicht.", 5000);
                            return;
                        }

                        //
                        player.TriggerEvent("Destroy_Character_Menu");
                        RemoveItemFromInventory(player, index, value);

                        //
                        player.SetData("primary_ammunation", player.GetData("primary_ammunation") + value);
                        API.Shared.SetPlayerWeaponAmmo(player, player.CurrentWeapon, player.GetData("primary_ammunation"));
                        NAPI.Player.SetPlayerCurrentWeaponAmmo(player, player.GetData("primary_ammunation"));
                        WeaponManage.SaveWeapons(player);
                        //
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"" + itens_available[type].name + " angelegt!", 5000);
                        break;
                    }
                case 137:
                    {
                        bool can_pass = false;
                        foreach (var w in Main.weapon_list)
                        {
                            if (player.CurrentWeapon == NAPI.Util.WeaponNameToModel(w.model))
                            {
                                if (w.type == "Shotguns")
                                {
                                    can_pass = true;
                                }
                            }
                        }

                        if (can_pass == false)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie müssen die Waffe verwenden, mit der Sie die Munition ausrüsten möchten.", 5000);
                            return;
                        }

                        int ammo_actual = player_inventory[playerid].amount[index];

                        int value = amount;

                        if (value < 1)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie können keinen Nullwert verwenden.", 5000);
                            return;
                        }

                        if (ammo_actual < value)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie haben diesen Betrag nicht.", 5000);
                            return;
                        }

                        //
                        player.TriggerEvent("Destroy_Character_Menu");
                        RemoveItemFromInventory(player, index, value);

                        //
                        player.SetData("primary_ammunation", player.GetData("primary_ammunation") + value);
                        API.Shared.SetPlayerWeaponAmmo(player, player.CurrentWeapon, player.GetData("primary_ammunation"));
                        NAPI.Player.SetPlayerCurrentWeaponAmmo(player, player.GetData("primary_ammunation"));
                        WeaponManage.SaveWeapons(player);
                        //
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"" + itens_available[type].name + " angelegt!", 5000);
                        break;
                    }
                case 138:
                    {
                        bool can_pass = false;
                        foreach (var w in Main.weapon_list)
                        {
                            if (player.CurrentWeapon == NAPI.Util.WeaponNameToModel(w.model))
                            {
                                if (w.type == "Shotguns")
                                {
                                    can_pass = true;
                                }
                            }
                        }

                        if (can_pass == false)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie müssen die Waffe verwenden, mit der Sie die Munition ausrüsten möchten.", 5000);
                            return;
                        }

                        int ammo_actual = player_inventory[playerid].amount[index];

                        int value = amount;

                        if (value < 1)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie können keinen Nullwert verwenden.", 5000);
                            return;
                        }

                        if (ammo_actual < value)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie haben diesen Betrag nicht.", 5000);
                            return;
                        }

                        //
                        player.TriggerEvent("Destroy_Character_Menu");
                        RemoveItemFromInventory(player, index, value);

                        //
                        player.SetData("primary_ammunation", player.GetData("primary_ammunation") + value);
                        API.Shared.SetPlayerWeaponAmmo(player, player.CurrentWeapon, player.GetData("primary_ammunation"));
                        NAPI.Player.SetPlayerCurrentWeaponAmmo(player, player.GetData("primary_ammunation"));
                        WeaponManage.SaveWeapons(player);
                        //
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"" + itens_available[type].name + " angelegt!", 5000);
                        break;
                    }
                case 139:
                    {
                        bool can_pass = false;
                        foreach (var w in Main.weapon_list)
                        {
                            if (player.CurrentWeapon == NAPI.Util.WeaponNameToModel(w.model))
                            {
                                if (w.type == "Branca")
                                {
                                    can_pass = true;
                                }
                            }
                        }

                        if (can_pass == false)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie müssen die Waffe verwenden, mit der Sie die Munition ausrüsten möchten.", 5000);
                            return;
                        }

                        int ammo_actual = player_inventory[playerid].amount[index];

                        int value = amount;

                        if (value < 1)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie können keinen Nullwert verwenden.", 5000);
                            return;
                        }

                        if (ammo_actual < value)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie haben diesen Betrag nicht.", 5000);
                            return;
                        }

                        //
                        player.TriggerEvent("Destroy_Character_Menu");
                        RemoveItemFromInventory(player, index, value);

                        //
                        player.SetData("primary_ammunation", player.GetData("primary_ammunation") + value);
                        API.Shared.SetPlayerWeaponAmmo(player, player.CurrentWeapon, player.GetData("primary_ammunation"));
                        NAPI.Player.SetPlayerCurrentWeaponAmmo(player, player.GetData("primary_ammunation"));
                        WeaponManage.SaveWeapons(player);
                        //
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"" + itens_available[type].name + " angelegt!", 5000);
                        break;
                    }
                case 140:
                    {
                        bool can_pass = false;
                        foreach (var w in Main.weapon_list)
                        {
                            if (player.CurrentWeapon == NAPI.Util.WeaponNameToModel(w.model))
                            {
                                if (w.type == "Shotguns")
                                {
                                    can_pass = true;
                                }
                            }
                        }

                        if (can_pass == false)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie müssen die Waffe verwenden, mit der Sie die Munition ausrüsten möchten.", 5000);
                            return;
                        }

                        int ammo_actual = player_inventory[playerid].amount[index];

                        int value = amount;

                        if (value < 1)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie können keinen Nullwert verwenden.", 5000);
                            return;
                        }

                        if (ammo_actual < value)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie haben diesen Betrag nicht.", 5000);
                            return;
                        }

                        //
                        player.TriggerEvent("Destroy_Character_Menu");
                        RemoveItemFromInventory(player, index, value);

                        //
                        player.SetData("primary_ammunation", player.GetData("primary_ammunation") + value);
                        API.Shared.SetPlayerWeaponAmmo(player, player.CurrentWeapon, player.GetData("primary_ammunation"));
                        NAPI.Player.SetPlayerCurrentWeaponAmmo(player, player.GetData("primary_ammunation"));
                        WeaponManage.SaveWeapons(player);
                        //
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"" + itens_available[type].name + " angelegt!", 5000);
                        break;
                    }
                case 141:
                    {
                        bool can_pass = false;
                        foreach (var w in Main.weapon_list)
                        {
                            if (player.CurrentWeapon == NAPI.Util.WeaponNameToModel(w.model))
                            {
                                if (w.type == "Shotguns")
                                {
                                    can_pass = true;
                                }
                            }
                        }

                        if (can_pass == false)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie müssen die Waffe verwenden, mit der Sie die Munition ausrüsten möchten.", 5000);
                            return;
                        }

                        int ammo_actual = player_inventory[playerid].amount[index];

                        int value = amount;

                        if (value < 1)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie können keinen Nullwert verwenden.", 5000);
                            return;
                        }

                        if (ammo_actual < value)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie haben diesen Betrag nicht.", 5000);
                            return;
                        }

                        //
                        player.TriggerEvent("Destroy_Character_Menu");
                        RemoveItemFromInventory(player, index, value);

                        //
                        player.SetData("primary_ammunation", player.GetData("primary_ammunation") + value);
                        API.Shared.SetPlayerWeaponAmmo(player, player.CurrentWeapon, player.GetData("primary_ammunation"));
                        NAPI.Player.SetPlayerCurrentWeaponAmmo(player, player.GetData("primary_ammunation"));
                        WeaponManage.SaveWeapons(player);
                        //
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"" + itens_available[type].name + " angelegt!", 5000);
                        break;
                    }
                case 142:
                    {
                        bool can_pass = false;
                        foreach (var w in Main.weapon_list)
                        {
                            if (player.CurrentWeapon == NAPI.Util.WeaponNameToModel(w.model))
                            {
                                if (w.type == "Shotguns")
                                {
                                    can_pass = true;
                                }
                            }
                        }

                        if (can_pass == false)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie müssen die Waffe verwenden, mit der Sie die Munition ausrüsten möchten.", 5000);
                            return;
                        }

                        int ammo_actual = player_inventory[playerid].amount[index];

                        int value = amount;

                        if (value < 1)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie können keinen Nullwert verwenden.", 5000);
                            return;
                        }

                        if (ammo_actual < value)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie haben diesen Betrag nicht.", 5000);
                            return;
                        }

                        //
                        player.TriggerEvent("Destroy_Character_Menu");
                        RemoveItemFromInventory(player, index, value);

                        //
                        player.SetData("primary_ammunation", player.GetData("primary_ammunation") + value);
                        API.Shared.SetPlayerWeaponAmmo(player, player.CurrentWeapon, player.GetData("primary_ammunation"));
                        NAPI.Player.SetPlayerCurrentWeaponAmmo(player, player.GetData("primary_ammunation"));
                        WeaponManage.SaveWeapons(player);
                        //
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"" + itens_available[type].name + " angelegt!", 5000);
                        break;
                    }
                case 143:
                    {
                        bool can_pass = false;
                        foreach (var w in Main.weapon_list)
                        {
                            if (player.CurrentWeapon == NAPI.Util.WeaponNameToModel(w.model))
                            {
                                if (w.type == "Machine Guns")
                                {
                                    can_pass = true;
                                }
                            }
                        }

                        if (can_pass == false)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie müssen die Waffe verwenden, mit der Sie die Munition ausrüsten möchten.", 5000);
                            return;
                        }

                        int ammo_actual = player_inventory[playerid].amount[index];

                        int value = amount;

                        if (value < 1)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie können keinen Nullwert verwenden.", 5000);
                            return;
                        }

                        if (ammo_actual < value)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie haben diesen Betrag nicht.", 5000);
                            return;
                        }

                        //
                        player.TriggerEvent("Destroy_Character_Menu");
                        RemoveItemFromInventory(player, index, value);

                        //
                        player.SetData("primary_ammunation", player.GetData("primary_ammunation") + value);
                        API.Shared.SetPlayerWeaponAmmo(player, player.CurrentWeapon, player.GetData("primary_ammunation"));
                        NAPI.Player.SetPlayerCurrentWeaponAmmo(player, player.GetData("primary_ammunation"));
                        WeaponManage.SaveWeapons(player);
                        //
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"" + itens_available[type].name + " angelegt!", 5000);
                        break;
                    }
                case 144:
                    {
                        bool can_pass = false;
                        foreach (var w in Main.weapon_list)
                        {
                            if (player.CurrentWeapon == NAPI.Util.WeaponNameToModel(w.model))
                            {
                                if (w.type == "Machine Guns")
                                {
                                    can_pass = true;
                                }
                            }
                        }

                        if (can_pass == false)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie müssen die Waffe verwenden, mit der Sie die Munition ausrüsten möchten.", 5000);
                            return;
                        }

                        int ammo_actual = player_inventory[playerid].amount[index];

                        int value = amount;

                        if (value < 1)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie können keinen Nullwert verwenden.", 5000);
                            return;
                        }

                        if (ammo_actual < value)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie haben diesen Betrag nicht.", 5000);
                            return;
                        }

                        //
                        player.TriggerEvent("Destroy_Character_Menu");
                        RemoveItemFromInventory(player, index, value);

                        //
                        player.SetData("primary_ammunation", player.GetData("primary_ammunation") + value);
                        API.Shared.SetPlayerWeaponAmmo(player, player.CurrentWeapon, player.GetData("primary_ammunation"));
                        NAPI.Player.SetPlayerCurrentWeaponAmmo(player, player.GetData("primary_ammunation"));
                        WeaponManage.SaveWeapons(player);
                        //
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"" + itens_available[type].name + " angelegt!", 5000);
                        break;
                    }
                case 145:
                    {
                        bool can_pass = false;
                        foreach (var w in Main.weapon_list)
                        {
                            if (player.CurrentWeapon == NAPI.Util.WeaponNameToModel(w.model))
                            {
                                if (w.type == "Machine Guns")
                                {
                                    can_pass = true;
                                }
                            }
                        }

                        if (can_pass == false)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie müssen die Waffe verwenden, mit der Sie die Munition ausrüsten möchten.", 5000);
                            return;
                        }

                        int ammo_actual = player_inventory[playerid].amount[index];

                        int value = amount;

                        if (value < 1)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie können keinen Nullwert verwenden.", 5000);
                            return;
                        }

                        if (ammo_actual < value)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie haben diesen Betrag nicht.", 5000);
                            return;
                        }

                        //
                        player.TriggerEvent("Destroy_Character_Menu");
                        RemoveItemFromInventory(player, index, value);

                        //
                        player.SetData("primary_ammunation", player.GetData("primary_ammunation") + value);
                        API.Shared.SetPlayerWeaponAmmo(player, player.CurrentWeapon, player.GetData("primary_ammunation"));
                        NAPI.Player.SetPlayerCurrentWeaponAmmo(player, player.GetData("primary_ammunation"));
                        WeaponManage.SaveWeapons(player);
                        //
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"" + itens_available[type].name + " angelegt!", 5000);
                        break;
                    }
                case 146:
                    {
                        bool can_pass = false;
                        foreach (var w in Main.weapon_list)
                        {
                            if (player.CurrentWeapon == NAPI.Util.WeaponNameToModel(w.model))
                            {
                                if (w.type == "Machine Guns")
                                {
                                    can_pass = true;
                                }
                            }
                        }

                        if (can_pass == false)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie müssen die Waffe verwenden, mit der Sie die Munition ausrüsten möchten.", 5000);
                            return;
                        }

                        int ammo_actual = player_inventory[playerid].amount[index];

                        int value = amount;

                        if (value < 1)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie können keinen Nullwert verwenden.", 5000);
                            return;
                        }

                        if (ammo_actual < value)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie haben diesen Betrag nicht.", 5000);
                            return;
                        }

                        //
                        player.TriggerEvent("Destroy_Character_Menu");
                        RemoveItemFromInventory(player, index, value);

                        //
                        player.SetData("primary_ammunation", player.GetData("primary_ammunation") + value);
                        API.Shared.SetPlayerWeaponAmmo(player, player.CurrentWeapon, player.GetData("primary_ammunation"));
                        NAPI.Player.SetPlayerCurrentWeaponAmmo(player, player.GetData("primary_ammunation"));
                        WeaponManage.SaveWeapons(player);
                        //
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"" + itens_available[type].name + " angelegt!", 5000);
                        break;
                    }
                case 147:
                    {
                        bool can_pass = false;
                        foreach (var w in Main.weapon_list)
                        {
                            if (player.CurrentWeapon == NAPI.Util.WeaponNameToModel(w.model))
                            {
                                if (w.type == "Machine Guns")
                                {
                                    can_pass = true;
                                }
                            }
                        }

                        if (can_pass == false)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie müssen die Waffe verwenden, mit der Sie die Munition ausrüsten möchten.", 5000);
                            return;
                        }

                        int ammo_actual = player_inventory[playerid].amount[index];

                        int value = amount;

                        if (value < 1)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie können keinen Nullwert verwenden.", 5000);
                            return;
                        }

                        if (ammo_actual < value)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie haben diesen Betrag nicht.", 5000);
                            return;
                        }

                        //
                        player.TriggerEvent("Destroy_Character_Menu");
                        RemoveItemFromInventory(player, index, value);

                        //
                        player.SetData("primary_ammunation", player.GetData("primary_ammunation") + value);
                        API.Shared.SetPlayerWeaponAmmo(player, player.CurrentWeapon, player.GetData("primary_ammunation"));
                        NAPI.Player.SetPlayerCurrentWeaponAmmo(player, player.GetData("primary_ammunation"));
                        WeaponManage.SaveWeapons(player);
                        //
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"" + itens_available[type].name + " angelegt!", 5000);
                        break;
                    }
                case 148:
                    {
                        bool can_pass = false;
                        foreach (var w in Main.weapon_list)
                        {
                            if (player.CurrentWeapon == NAPI.Util.WeaponNameToModel(w.model))
                            {
                                if (w.type == "Machine Guns")
                                {
                                    can_pass = true;
                                }
                            }
                        }

                        if (can_pass == false)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie müssen die Waffe verwenden, mit der Sie die Munition ausrüsten möchten.", 5000);
                            return;
                        }

                        int ammo_actual = player_inventory[playerid].amount[index];

                        int value = amount;

                        if (value < 1)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie können keinen Nullwert verwenden.", 5000);
                            return;
                        }

                        if (ammo_actual < value)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie haben diesen Betrag nicht.", 5000);
                            return;
                        }

                        //
                        player.TriggerEvent("Destroy_Character_Menu");
                        RemoveItemFromInventory(player, index, value);

                        //
                        player.SetData("primary_ammunation", player.GetData("primary_ammunation") + value);
                        API.Shared.SetPlayerWeaponAmmo(player, player.CurrentWeapon, player.GetData("primary_ammunation"));
                        NAPI.Player.SetPlayerCurrentWeaponAmmo(player, player.GetData("primary_ammunation"));
                        WeaponManage.SaveWeapons(player);
                        //
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"" + itens_available[type].name + " angelegt!", 5000);
                        break;
                    }
                case 149:
                    {
                        bool can_pass = false;
                        foreach (var w in Main.weapon_list)
                        {
                            if (player.CurrentWeapon == NAPI.Util.WeaponNameToModel(w.model))
                            {
                                if (w.type == "Machine Guns")
                                {
                                    can_pass = true;
                                }
                            }
                        }

                        if (can_pass == false)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie müssen die Waffe verwenden, mit der Sie die Munition ausrüsten möchten.", 5000);
                            return;
                        }

                        int ammo_actual = player_inventory[playerid].amount[index];

                        int value = amount;

                        if (value < 1)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie können keinen Nullwert verwenden.", 5000);
                            return;
                        }

                        if (ammo_actual < value)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie haben diesen Betrag nicht.", 5000);
                            return;
                        }

                        //
                        player.TriggerEvent("Destroy_Character_Menu");
                        RemoveItemFromInventory(player, index, value);

                        //
                        player.SetData("primary_ammunation", player.GetData("primary_ammunation") + value);
                        API.Shared.SetPlayerWeaponAmmo(player, player.CurrentWeapon, player.GetData("primary_ammunation"));
                        NAPI.Player.SetPlayerCurrentWeaponAmmo(player, player.GetData("primary_ammunation"));
                        WeaponManage.SaveWeapons(player);
                        //
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"" + itens_available[type].name + " angelegt!", 5000);
                        break;
                    }
                case 150:
                    {
                        bool can_pass = false;
                        foreach (var w in Main.weapon_list)
                        {
                            if (player.CurrentWeapon == NAPI.Util.WeaponNameToModel(w.model))
                            {
                                if (w.type == "Sniper Rifles")
                                {
                                    can_pass = true;
                                }
                            }
                        }

                        if (can_pass == false)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie müssen die Waffe verwenden, mit der Sie die Munition ausrüsten möchten.", 5000);
                            return;
                        }

                        int ammo_actual = player_inventory[playerid].amount[index];

                        int value = amount;

                        if (value < 1)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie können keinen Nullwert verwenden.", 5000);
                            return;
                        }

                        if (ammo_actual < value)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie haben diesen Betrag nicht.", 5000);
                            return;
                        }

                        //
                        player.TriggerEvent("Destroy_Character_Menu");
                        RemoveItemFromInventory(player, index, value);

                        //
                        player.SetData("primary_ammunation", player.GetData("primary_ammunation") + value);
                        API.Shared.SetPlayerWeaponAmmo(player, player.CurrentWeapon, player.GetData("primary_ammunation"));
                        NAPI.Player.SetPlayerCurrentWeaponAmmo(player, player.GetData("primary_ammunation"));
                        WeaponManage.SaveWeapons(player);
                        //
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"" + itens_available[type].name + " angelegt!", 5000);
                        break;
                    }
                case 151:
                    {
                        bool can_pass = false;
                        foreach (var w in Main.weapon_list)
                        {
                            if (player.CurrentWeapon == NAPI.Util.WeaponNameToModel(w.model))
                            {
                                if (w.type == "Sniper Rifles")
                                {
                                    can_pass = true;
                                }
                            }
                        }

                        if (can_pass == false)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie müssen die Waffe verwenden, mit der Sie die Munition ausrüsten möchten.", 5000);
                            return;
                        }

                        int ammo_actual = player_inventory[playerid].amount[index];

                        int value = amount;

                        if (value < 1)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie können keinen Nullwert verwenden.", 5000);
                            return;
                        }

                        if (ammo_actual < value)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie haben diesen Betrag nicht.", 5000);
                            return;
                        }

                        //
                        player.TriggerEvent("Destroy_Character_Menu");
                        RemoveItemFromInventory(player, index, value);

                        //
                        player.SetData("primary_ammunation", player.GetData("primary_ammunation") + value);
                        API.Shared.SetPlayerWeaponAmmo(player, player.CurrentWeapon, player.GetData("primary_ammunation"));
                        NAPI.Player.SetPlayerCurrentWeaponAmmo(player, player.GetData("primary_ammunation"));
                        WeaponManage.SaveWeapons(player);
                        //
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"" + itens_available[type].name + " angelegt!", 5000);
                        break;
                    }
                case 152:
                    {
                        bool can_pass = false;
                        foreach (var w in Main.weapon_list)
                        {
                            if (player.CurrentWeapon == NAPI.Util.WeaponNameToModel(w.model))
                            {
                                if (w.type == "Sniper Rifles")
                                {
                                    can_pass = true;
                                }
                            }
                        }

                        if (can_pass == false)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie müssen die Waffe verwenden, mit der Sie die Munition ausrüsten möchten.", 5000);
                            return;
                        }

                        int ammo_actual = player_inventory[playerid].amount[index];

                        int value = amount;

                        if (value < 1)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie können keinen Nullwert verwenden.", 5000);
                            return;
                        }

                        if (ammo_actual < value)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie haben diesen Betrag nicht.", 5000);
                            return;
                        }

                        //
                        player.TriggerEvent("Destroy_Character_Menu");
                        RemoveItemFromInventory(player, index, value);

                        //
                        player.SetData("primary_ammunation", player.GetData("primary_ammunation") + value);
                        API.Shared.SetPlayerWeaponAmmo(player, player.CurrentWeapon, player.GetData("primary_ammunation"));
                        NAPI.Player.SetPlayerCurrentWeaponAmmo(player, player.GetData("primary_ammunation"));
                        WeaponManage.SaveWeapons(player);
                        //
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"" + itens_available[type].name + " angelegt!", 5000);
                        break;
                    }

            }
        }

        public static void PlayerPressKeyE(Client player)
        {
            try
            {
                int index = 0;
            foreach (var inventory in inventory_objects)
            {
                if (Main.IsInRangeOfPoint(player.Position, new Vector3(inventory.item_pos_x, inventory.item_pos_y, inventory.item_pos_z), 1))
                {

                    if (Inventory.Check_InventoryWeight_With_ItemAmount(player, inventory.item_type, inventory.item_amount, Inventory.Max_Inventory_Weight(player)))
                    {
                        return;
                    }

                    NAPI.Player.PlayPlayerAnimation(player, (int)(Main.AnimationFlags.Loop), "anim@mp_snowball", "pickup_snowball");
                    NAPI.Task.Run(() =>
                    {
                        player.StopAnimation();
                    }, delayTime: 1500);

                    Main.PlaySoundFrontend(player, "PICK_UP", "HUD_FRONTEND_DEFAULT_SOUNDSET");

                    GiveItemToInventory(player, inventory.item_type, inventory.item_amount);

                    if (inventory.item_amount == 1)
                    {
                        //Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Voce pegou um ~y~" + item_list[inventory.item_type].name + ".");
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du hast eine. " + itens_available[inventory.item_type].name + ".", 5000);
                    }
                    else
                    {
                        //Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Voce pegou "+ inventory.item_amount + " unidades de ~y~" + item_list[inventory.item_type].name + ".");
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du hast genommen " + inventory.item_amount + " Einheiten von " + itens_available[inventory.item_type].name + ".", 5000);
                        }

                    NAPI.Entity.DeleteEntity(inventory.item_object_handle);
                    NAPI.Entity.DeleteEntity(inventory.item_label_handle);

                    inventory_objects.RemoveAt(index);

                    return; ;
                }
                index++;
            }
        }
        catch (Exception e) { Log.Write("PlayerPressKeyE: " + e.Message, nLog.Type.Error); }
        }



        public static float Max_Inventory_Weight(Client player)
        {
            float carry = 15.0f;

            switch (player.GetData("character_backpack"))
            {
                case 1:

                    carry = 20.0f;
                    break;

                case 2:

                    carry = 40.0f;
                    break;

                case 3:

                    carry = 60.0f;
                    break;

                default:

                    carry = 15.0f;
                    break;
            }
            return carry;
        }

        public static bool Check_InventoryWeight_With_ItemAmount(Client player, int type, int amount, float MAX_HEIGHT)
        {
            int playerid = Main.getIdFromClient(player);
            float height = 0.00f;


            for (int index = 0; index < MAX_INVENTORY_ITENS; index++)
            {
                if (player_inventory[playerid].sql_id[index] != -1 && player_inventory[playerid].amount[index] > 0)
                {
                    height += player_inventory[playerid].amount[index] * itens_available[player_inventory[playerid].type[index]].weight;

                }
            }

            if (type < itens_available.Count && type != -1)
            {

                float free_space = MAX_HEIGHT - height;

                height += amount * itens_available[type].weight;


                if (height > MAX_HEIGHT)
                {
                    Main.SendErrorMessage(player, "Sie haben nicht genügend Platz im Inventar, um diesen Artikel zu laden. Dieser Artikel wiegt " + Main.EMBED_LIGHTRED + "" + (amount * itens_available[type].weight).ToString("#.##").Replace(",", ".") + "kg.");
                    return true;
                }

                return false;
            }
            else
            {
                return true;
            }

        }

        public static void UnActiveItem(Client player, ItemType type)
        {
            int playerid = Main.getIdFromClient(player);
            int slot = -1;
            for (int index = 0; index < MAX_INVENTORY_ITENS; index++)
            {
                if ((ItemType)player_inventory[playerid].type[index] == type && player_inventory[playerid].active[index])
                {
                    player_inventory[playerid].active[index] = false;
                }
            }
        }


        public static int GetInventoryIndexFromType(Client player, int type)
        {
            int playerid = Main.getIdFromClient(player);
            int slot = -1;
            for (int index = 0; index < MAX_INVENTORY_ITENS; index++)
            {
                if (player_inventory[playerid].type[index] == type)
                {
                    slot = index;
                }
            }
            return slot;


        }

        public static int GetPlayerItemFromInventory(Client player, int type)
        {
            int playerid = Main.getIdFromClient(player);
            int amount = 0;
            try
            {
                for (int index = 0; index < MAX_INVENTORY_ITENS; index++)
                {
                    if (player_inventory[playerid].type[index] == type)
                    {
                        amount = player_inventory[playerid].amount[index];
                    }
                }
            }
            catch
            {

            }
            return amount;
        }

        public static int GetInventoryIndexFromName(Client player, string name)
        {

            int index = 0, slot = -1;
            foreach (var item in itens_available)
            {
                if (item.name == name)
                {
                    slot = GetInventoryIndexFromType(player, index);
                }
                index++;
            }
            return slot;
        }

        public static void RemoveItem(Client player, string itemName, int amount)
        {
            int index = 0;
            foreach (var item in itens_available)
            {
                if (item.name == itemName)
                {
                    RemoveItemFromInventory(player, GetInventoryIndexFromType(player, index), amount);
                    return;
                }
                index++;
            }
        }

        public static void RemoveItemByType(Client player, int type, int amount)
        {
            int index = 0;
            foreach (var item in itens_available)
            {
                if (item.id == type)
                {
                    RemoveItemFromInventory(player, GetInventoryIndexFromType(player, index), amount);
                    return;
                }
                index++;
            }
        }

        public static void OnInputResponse(Client player, String response, String inputtext)
        {
            int playerid = Main.getIdFromClient(player);
            if (response == "weapon_reload_primary")
            {
                string itemName = player.GetData("inventory_item_selected");
                int index = GetInventoryIndexFromName(player, itemName);
                int ammo_actual = player_inventory[playerid].amount[index];

                if (!Main.IsNumeric(inputtext))
                {
                    return;
                }

                int value = Convert.ToInt32(inputtext);

                if (value < 1)
                {
                    Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie können keinen Nullwert verwenden.", 5000);
                    return;
                }

                if (ammo_actual < value)
                {
                    Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie haben diesen Betrag nicht.", 5000);
                    return;
                }

                //
                player.TriggerEvent("Destroy_Character_Menu");
                RemoveItem(player, itemName, value);

                player.SetData("primary_ammunation", player.GetData("primary_ammunation") + value);
                API.Shared.SetPlayerWeaponAmmo(player, player.CurrentWeapon, player.GetData("primary_ammunation"));
                NAPI.Player.SetPlayerCurrentWeaponAmmo(player, player.GetData("primary_ammunation"));

                // message
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du hast ausgerüstet: " + value + " " + itemName + "", 5000);

            }
            else if (response == "weapon_reload_secundary")
            {
                string itemName = player.GetData("inventory_item_selected");
                int index = GetInventoryIndexFromName(player, itemName);
                int ammo_actual = player_inventory[playerid].amount[index];


                if (!Main.IsNumeric(inputtext))
                {
                    return;
                }

                int value = Convert.ToInt32(inputtext);

                if (value < 1)
                {
                    Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie können keinen Nullwert verwenden.", 5000);
                    return;
                }

                if (ammo_actual < value)
                {
                    Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie haben diesen Betrag nicht.", 5000);
                    return;
                }

                //
                player.TriggerEvent("Destroy_Character_Menu");
                RemoveItem(player, itemName, value);

                //
                player.SetData("secundary_ammunation", player.GetData("primary_ammunation") + value);
                API.Shared.SetPlayerWeaponAmmo(player, player.CurrentWeapon, player.GetData("primary_ammunation"));
                NAPI.Player.SetPlayerCurrentWeaponAmmo(player, player.GetData("primary_ammunation"));

                //
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du hast ausgerüstet: " + value + " " + itemName + "", 5000);

            }
            else if (response == "input_inventory_drop_amount")
            {
                string item_name = player.GetData("inventory_item_selected").ToString();

                if (!Main.IsNumeric(inputtext))
                {
                    Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Der eingegebene Wert ist nicht in Zahlen.", 5000);
                    return;
                }

                if (inputtext.Length == 0)
                {
                    Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Der eingegebene Wert ist nicht in Zahlen.", 5000);
                    return;
                }

                int amount = Convert.ToInt32(inputtext);

                if (amount < 1)
                {
                    Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Der eingegebene Wert ist nicht in Zahlen.", 5000);
                    return;
                }

                int i = 0;
                foreach (var invItem in itens_available)
                {
                    if (invItem.name == item_name)
                    {
                        int slot_id = GetInventoryIndexFromType(player, i);
                        if (slot_id == -1)
                        {
                            return;
                        }

                        if (player_inventory[playerid].amount[slot_id] < amount)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Das " + amount + " " + item_name + " ist zu schwer.", 5000);
                            return;
                        }
                        player.TriggerEvent("Destroy_Character_Menu");
                        DropItemFromInventory(player, slot_id, item_name, amount);
                    }
                    i++;
                }
            }
            else if (response == "give_item_to_other_play")
            {
                Client target = player.GetData("target_item_handle");
                string item_name = player.GetData("target_item_name");
                if (target.Exists && API.Shared.IsPlayerConnected(target))
                {
                    if (target.GetData("status") == true)
                    {
                        if (Main.IsInRangeOfPoint(player.Position, target.Position, 2.0f))
                        {
                            if (inputtext.Length == 0)
                            {
                                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Der eingegebene Wert ist nicht in Zahlen.", 5000);
                                return;
                            }

                            int amount = Convert.ToInt32(inputtext);

                            if (amount < 1)
                            {
                                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Der eingegebene Wert ist nicht in Zahlen.", 5000);
                                return;
                            }

                            if (inputtext.Contains("-"))
                            {
                                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Der eingegebene Wert ist nicht in Zahlen.", 5000);
                                return;
                            }


                            Give_Item_To_OtherPlayer(player, target, item_name, amount);
                        }
                    }
                }
            }
        }

        [RemoteEvent("JogarItem")]
        public void UI_JogarItem(Client player, int type, int value)
        {

            int playerid = Main.getIdFromClient(player);
            int index = GetInventoryIndexFromType(player, type);

            if (player_inventory[playerid].sql_id[index] == -1)
            {
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Ein unbekannter Fehler ist aufgetreten.", 5000);
                return;
            }

            if (player_inventory[playerid].amount[index] < 1)
            {
                return;
            }

            player.SetData("inventory_item_selected", itens_available[type].name);


            player.TriggerEvent("Destroy_Character_Menu");
            if (player_inventory[playerid].amount[index] == 1)
            {
                DropItemFromInventory(player, index, itens_available[type].name, 1);

                List<Client> proxPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(15, player);
                foreach (Client alvo in proxPlayers)
                {
                    //alvo.TriggerEvent("Send_ToChat", "", "", "<font color ='#C2A2DA'>* " + UsefullyRP.GetPlayerNameToTarget(player, alvo) + " jogou 1x " + itens_available[type].name + " no chão.");
                }
            }
            else
            {

                if (value == 0)
                {
                    Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Der eingegebene Wert ist nicht in Zahlen.", 5000);
                    return;
                }

                if (value < 1)
                {
                    Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Der eingegebene Wert ist nicht in Zahlen.", 5000);
                    return;
                }

                int i = 0;
                foreach (var invItem in itens_available)
                {
                    if (invItem.name == itens_available[type].name)
                    {
                        int slot_id = GetInventoryIndexFromType(player, i);
                        if (slot_id == -1)
                        {
                            return;
                        }

                        if (player_inventory[playerid].amount[slot_id] < value)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Halt! Stop! So nicht!.", 5000);
                            return;
                        }
                        DropItemFromInventory(player, slot_id, itens_available[type].name, value);
                    }
                    i++;
                }

            }
        }

        [RemoteEvent("Storage_Give_Item")]
        public static void UI_GiveItem(Client player, int type, string inputtext)
        {
            int playerid = Main.getIdFromClient(player);
            int index = GetInventoryIndexFromType(player, type);

            if (player_inventory[playerid].sql_id[index] == -1)
            {
                Main.SendErrorMessage(player, "Halt! Stop! So nicht!.");
                VehicleInventory.ShowToPlayerVehicleInventory(player);
                return;
            }

            Vehicle vehicle = player.GetData("vehicle_handle_inv");

            if (vehicle.Exists && Main.IsInRangeOfPoint(player.Position, vehicle.Position, 3.0f))
            {
                if (player_inventory[playerid].amount[index] > 1)
                {
                    if (!Main.IsNumeric(inputtext))
                    {
                        VehicleInventory.ShowToPlayerVehicleInventory(player);
                        return;
                    }
                    if (player_inventory[playerid].sql_id[index] == -1)
                    {
                        VehicleInventory.ShowToPlayerVehicleInventory(player);
                        return;
                    }

                    int amount = Convert.ToInt32(inputtext);

                    if (amount == 0)
                    {
                        VehicleInventory.ShowToPlayerVehicleInventory(player);
                        return;
                    }

                    if (vehicle.Exists && Main.IsInRangeOfPoint(player.Position, vehicle.Position, 3.0f))
                    {
                        if (player_inventory[playerid].amount[index] < 1)
                        {
                            VehicleInventory.ShowToPlayerVehicleInventory(player);
                            return;
                        }

                        if (player_inventory[playerid].amount[index] < amount)
                        {
                            Main.SendErrorMessage(player, "Sie haben diesen Betrag nicht in Ihrem Inventar.");
                            VehicleInventory.ShowToPlayerVehicleInventory(player);
                            return;
                        }
                        float height = 0.0f;
                        for (int i = 0; i < 30; i++)
                        {
                            if (NAPI.Data.GetEntityData(vehicle, "trunk_item_" + i + "_type") != 0 && NAPI.Data.GetEntityData(vehicle, "trunk_item_" + i + "_amount") > 0)
                            {
                                height += NAPI.Data.GetEntityData(vehicle, "trunk_item_" + i + "_amount") * itens_available[NAPI.Data.GetEntityData(vehicle, "trunk_item_" + i + "_type")].weight;
                            }
                        }

                        height += amount * itens_available[type].weight;


                        if (height > vehicle.GetData("MAX_VEHICLE_SLOT"))
                        {
                            InteractMenu_New.SendNotificationError(player, "Das Fahrzeug hat nicht genügend Platz, um diesen Artikel zu verstauen.");
                            VehicleInventory.ShowToPlayerVehicleInventory(player);
                            return;
                        }


                        player.SetData("vehicle_handle_inv", vehicle);
                        RemoveItemFromInventory(player, index, amount);
                        VehicleInventory.AddItemToVehicleInventory(vehicle, type, amount);

                        VehicleInventory.ShowToPlayerVehicleInventory(player);

                        List<Client> proxPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(15, player);
                        foreach (Client alvo in proxPlayers)
                        {
                            //alvo.TriggerEvent("Send_ToChat", "", "", "<font color ='#C2A2DA'>* " + UsefullyRP.GetPlayerNameToTarget(player, alvo) + " colocou " + amount + "x " + itens_available[type].name + " no inventário do veículo.");
                        }
                    }
                    return;
                }
                else if (player_inventory[playerid].amount[index] == 1)
                {
                    float height = 0.0f;
                    for (int i = 0; i < 30; i++)
                    {
                        if (NAPI.Data.GetEntityData(vehicle, "trunk_item_" + i + "_type") != 0 && NAPI.Data.GetEntityData(vehicle, "trunk_item_" + i + "_amount") > 0)
                        {
                            height += NAPI.Data.GetEntityData(vehicle, "trunk_item_" + i + "_amount") * itens_available[NAPI.Data.GetEntityData(vehicle, "trunk_item_" + i + "_type")].weight;
                        }
                    }

                    height += 1 * itens_available[type].weight;

                    if (height > vehicle.GetData("MAX_VEHICLE_SLOT"))
                    {
                        InteractMenu_New.SendNotificationError(player, "Das Fahrzeug hat nicht genügend Platz, um diesen Artikel zu verstauen.");
                        VehicleInventory.ShowToPlayerVehicleInventory(player);
                        return;
                    }


                    player.SetData("vehicle_handle_inv", vehicle);
                    RemoveItemFromInventory(player, index, 1);
                    VehicleInventory.AddItemToVehicleInventory(vehicle, type, 1);

                    VehicleInventory.ShowToPlayerVehicleInventory(player);

                    List<Client> proxPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(15, player);
                    foreach (Client alvo in proxPlayers)
                    {
                        //alvo.TriggerEvent("Send_ToChat", "", "", "<font color ='#C2A2DA'>* " + UsefullyRP.GetPlayerNameToTarget(player, alvo) + " colocou 1x " + itens_available[type].name + " no inventário do veículo.");
                    }
                    return;
                }
            }
        }

        [RemoteEvent("Storage_Take_Item")]
        public static void UI_TakeItem(Client player, int type, string inputtext)
        {

            Vehicle vehicle = player.GetData("vehicle_handle_inv");

            int playerid = Main.getIdFromClient(player);
            int index = VehicleInventory.GetInventoryIndexFromType(player, type);

            if (vehicle.Exists && Main.IsInRangeOfPoint(player.Position, vehicle.Position, 3.0f))
            {
                if (vehicle.GetData("trunk_item_" + index + "_amount") > 1)
                {
                    if (!Main.IsNumeric(inputtext))
                    {
                        VehicleInventory.ShowToPlayerVehicleInventory(player);
                        return;
                    }

                    int amount = Convert.ToInt32(inputtext);
                    if (amount == 0)
                    {
                        VehicleInventory.ShowToPlayerVehicleInventory(player);
                        return;
                    }
                    if (vehicle.Exists && Main.IsInRangeOfPoint(player.Position, vehicle.Position, 3.0f))
                    {
                        if (vehicle.GetData("trunk_item_" + index + "_amount") < 1)
                        {
                            VehicleInventory.ShowToPlayerVehicleInventory(player);
                            return;
                        }

                        if (vehicle.GetData("trunk_item_" + index + "_amount") < amount)
                        {
                            Main.SendErrorMessage(player, "Sie haben diesen Betrag nicht in Ihrem Inventar.");
                            VehicleInventory.ShowToPlayerVehicleInventory(player);
                            return;
                        }

                        if (Check_InventoryWeight_With_ItemAmount(player, type, amount, Max_Inventory_Weight(player)))
                        {
                            VehicleInventory.ShowToPlayerVehicleInventory(player);
                            return;
                        }

                        player.SetData("vehicle_handle_inv", vehicle);
                        GiveItemToInventory(player, type, amount);
                        VehicleInventory.RemoveItemFromVehicleInventory(vehicle, index, amount);

                        VehicleInventory.ShowToPlayerVehicleInventory(player);

                        List<Client> proxPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(15, player);
                        foreach (Client alvo in proxPlayers)
                        {
                            //alvo.TriggerEvent("Send_ToChat", "", "", "<font color ='#C2A2DA'>* " + UsefullyRP.GetPlayerNameToTarget(player, alvo) + " retirou " + amount + "x " + itens_available[type].name + " do inventário do veículo.");
                        }
                    }
                    return;
                }
                else if (vehicle.GetData("trunk_item_" + index + "_amount") == 1)
                {
                    if (Check_InventoryWeight_With_ItemAmount(player, type, 1, Max_Inventory_Weight(player)))
                    {
                        VehicleInventory.ShowToPlayerVehicleInventory(player);
                        return;
                    }

                    player.SetData("vehicle_handle_inv", vehicle);
                    GiveItemToInventory(player, type, 1);
                    VehicleInventory.RemoveItemFromVehicleInventory(vehicle, index, 1);

                    VehicleInventory.ShowToPlayerVehicleInventory(player);

                    List<Client> proxPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(15, player);
                    foreach (Client alvo in proxPlayers)
                    {
                        //alvo.TriggerEvent("Send_ToChat", "", "", "<font color ='#C2A2DA'>* " + UsefullyRP.GetPlayerNameToTarget(player, alvo) + " retirou 1x " + itens_available[type].name + " do inventário do veículo.");
                    }
                    return;
                }
            }
        }

        [Command("inventario", Alias = "inv")]
        public static void ShowPlayerInventory(Client player)
        {
            if (player.GetData("playerCuffed") != 0)
            {
                Main.SendErrorMessage(player, "Sie können kein Inventar verwenden, wenn Sie mit Handschellen gefesselt sind.");
                return;
            }

            int playerid = Main.getIdFromClient(player);

            List<dynamic> item_list = new List<dynamic>();
            List<dynamic> inventory_data = new List<dynamic>();
            float weight = 0f;
            for (int index = 0; index < MAX_INVENTORY_ITENS; index++)
            {
                if (player_inventory[playerid].sql_id[index] != -1)
                {


                    int type = player_inventory[playerid].type[index];

                    if (type > Inventory.itens_available.Count)
                    {
                        continue;
                    }



                    item_list.Add(new { icon = itens_available[type].icon, name = itens_available[type].name, type = type, description = itens_available[type].description, amount = player_inventory[playerid].amount[index], weight = itens_available[type].weight, use_0 = "Usar Item", use_1 = "Dar Item", dontDisplayAmount = false, category = "NONE", Useable = itens_available[type].Useable });

                    weight += player_inventory[playerid].amount[index] * itens_available[type].weight;
                }
            }

            //inventory_data.Add(new { Money = Main.GetPlayerMoney(player), InventoryId = 1, ActualWeight = weight , MaxWeight  = GetInventoryMaxHeight(player), Name  = "Meu Inventario", Items = NAPI.Util.ToJson(item_list) });
            player.TriggerEvent("Display_Player_Inventory", NAPI.Util.ToJson(item_list), Main.GetPlayerMoney(player), GetInventoryMaxHeight(player), weight);
        }

        [Command("getadminitem")]
        public static void CMD_getitem(Client player, int type, int amount)
        {
            GiveItemToInventory(player, type, amount);

            //Decoration decoration = new Decoration();

            //decoration.Collection = API.Shared.GetHashKey("mpbeach_overlays");
            //decoration.Overlay = API.Shared.GetHashKey("fm_hair_fuzz");

            //player.SetDecoration(decoration);
        }

        public static float GetInventoryMaxHeight(Client player)
        {
            float carry = 15.0f;
            if (player.GetData("character_backpack") == 1)
            {
                carry = 20.0f;
            }
            else if (player.GetData("character_backpack") == 2)
            {
                carry = 40.0f;
            }
            else if (player.GetData("character_backpack") == 3)
            {
                carry = 60.0f;
            }
            else
            {
                carry = 15.0f;
            }
            return carry;
        }



        public static void Give_Item_To_OtherPlayer(Client player, Client target, string itemName, int amount)
        {

            if (target.GetData("status") == false)
            {
                Main.DisplayErrorMessage(player, " Da ist was schief gelaufen!");
                return;
            }

            /*if (target == player)
            {
                Main.SendErrorMessage(player, "Você não pode dar algo para si mesmo.");
                return;
            }*/

            int playerid = Main.getIdFromClient(player);

            for (int index = 0; index < Inventory.MAX_INVENTORY_ITENS; index++)
            {
                if (Inventory.player_inventory[playerid].type[index] != 0 && Inventory.player_inventory[playerid].type[index] < Inventory.itens_available.Count)
                {
                    if (Inventory.itens_available[Inventory.player_inventory[playerid].type[index]].name == itemName)
                    {
                        if (Inventory.player_inventory[playerid].amount[index] > 0)
                        {

                            target.SetData("offer_amount", amount);
                            target.SetData("offer_seller", player);
                            target.SetData("offer_item", Inventory.player_inventory[playerid].type[index]);
                            target.SetData("offer", true);

                            InteractMenu.ShowModal(target, "GIVE_ITEM", "Jemand bietet Ihnen etwas an!", "Der Bürger " + AccountManage.GetCharacterName(player) + " bietet dir folgendes an " + amount + "  " + Inventory.itens_available[Inventory.player_inventory[playerid].type[index]].name + ".<br><br>Möchtest du es annehmen?", "Ja", "Nein");

                            Main.SendInfoMessage(player, "Du hast folgendes angeboten: " + amount + " " + Inventory.itens_available[Inventory.player_inventory[playerid].type[index]].name + " para " + AccountManage.GetCharacterName(target) + ".");
                            return;
                        }
                    }

                }
            }

            Main.DisplayErrorMessage(player, "Dieser Artikel wurde nicht gefunden.");
        }


        [Command("dar", "~y~Uso: /dar [player] [nome do item] [quantidade]")]
        public static void CMD_dar(Client player, string idOrName, string itemName, int amount)
        {
            Client target = Main.findPlayer(player, idOrName);

            if (target == null)
            {
                Main.DisplayErrorMessage(player, " Da ist was schief gelaufen!");
                return;
            }

            /*if (target == player)
            {
                Main.SendErrorMessage(player, "Você não pode dar algo para si mesmo.");
                return;
            }*/

            int playerid = Main.getIdFromClient(player);

            for (int index = 0; index < Inventory.MAX_INVENTORY_ITENS; index++)
            {
                if (Inventory.player_inventory[playerid].type[index] != 0 && Inventory.player_inventory[playerid].type[index] < Inventory.itens_available.Count)
                {
                    if (Inventory.itens_available[Inventory.player_inventory[playerid].type[index]].name == itemName)
                    {
                        if (Inventory.player_inventory[playerid].amount[index] > 0)
                        {

                            target.SetData("offer_amount", amount);
                            target.SetData("offer_seller", player);
                            target.SetData("offer_item", Inventory.player_inventory[playerid].type[index]);
                            target.SetData("offer", true);

                            InteractMenu.ShowModal(target, "GIVE_ITEM", "Jemand bietet Ihnen etwas an!", "Der Bürger " + AccountManage.GetCharacterName(player) + " bietet dir folgendes an " + amount + "  " + Inventory.itens_available[Inventory.player_inventory[playerid].type[index]].name + ".<br><br>Möchtest du es annehmen?", "Ja", "Nein");

                            Main.SendInfoMessage(player, "Du hast folgendes angeboten: " + amount + " " + Inventory.itens_available[Inventory.player_inventory[playerid].type[index]].name + " \nAn die Person: " + AccountManage.GetCharacterName(target) + ".");
                            return;
                        }
                    }

                }
            }

            Main.DisplayErrorMessage(player, "Dieser Artikel wurde nicht gefunden.");
        }

        [RemoteEvent("InventoryService:ToggleClothing")]
        public static void ToggleClothing(Client player, int type)
        {
            switch (type)
            {
                case 13:
                    {
                        if (player.GetData("clothes_hats") == false)
                        {
                            player.SetData("clothes_hats", true);
                        }
                        else
                        {
                            player.SetData("clothes_hats", false);
                        }
                        break;
                    }
                case 14:
                    {
                        if (player.GetData("clothes_glasses") == false)
                        {
                            player.SetData("clothes_glasses", true);
                        }
                        else
                        {
                            player.SetData("clothes_glasses", false);
                        }
                        break;
                    }
                case 9:
                    {
                        if (player.GetData("clothes_shirt") == false)
                        {
                            player.SetData("clothes_shirt", true);
                        }
                        else
                        {
                            player.SetData("clothes_shirt", false);
                        }
                        break;
                    }
                case 2:
                    {
                        if (player.GetData("clothes_leg") == false)
                        {
                            player.SetData("clothes_leg", true);
                        }
                        else
                        {
                            player.SetData("clothes_leg", false);
                        }
                        break;
                    }
                case 5:
                    {
                        if (player.GetData("clothes_neck") == false)
                        {
                            player.SetData("clothes_neck", true);
                        }
                        else
                        {
                            player.SetData("clothes_neck", false);
                        }
                        break;
                    }
                case 4:
                    {
                        if (player.GetData("clothes_feet") == false)
                        {
                            player.SetData("clothes_feet", true);
                        }
                        else
                        {
                            player.SetData("clothes_feet", false);
                        }
                        break;
                    }
                case 17:
                    {
                        if (player.GetData("clothes_watches") == false)
                        {
                            player.SetData("clothes_watches", true);
                        }
                        else
                        {
                            player.SetData("clothes_watches", false);
                        }
                        break;
                    }
                case 15:
                    {
                        if (player.GetData("clothes_ears") == false)
                        {
                            player.SetData("clothes_ears", true);
                        }
                        else
                        {
                            player.SetData("clothes_ears", false);
                        }
                        break;
                    }
                case 8:
                    {
                        if (player.GetData("clothes_bag") == false)
                        {
                            player.SetData("clothes_bag", true);
                        }
                        else
                        {
                            player.SetData("clothes_bag", false);
                        }
                        AccountManage.UpdateBackpack(player);
                        break;
                    }
                case 0:
                    {
                        UsefullyRP.CMD_Mascara(player);
                        break;
                    }
            }
            Main.UpdatePlayerClothes(player);
        }

    }
}
