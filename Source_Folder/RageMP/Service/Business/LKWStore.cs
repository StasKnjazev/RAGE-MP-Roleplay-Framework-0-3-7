using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;
using Newtonsoft.Json;
using DerStr1k3r.Core;

class LKWStore : Script
{
    public static int PRICE_HAMBURGER = 10;
    public static int PRICE_KAFFEE = 4;
    public static int PRICE_COLA = 5;
    public static int PRICE_SPRITE = 5;
    public static int PRICE_SNICKERS = 3;
    public static dynamic handelskammersteuer { get; set; }

    public LKWStore()
    {
    }

    [ServerEvent(Event.PlayerConnected)]
    public void OnPlayerConnected(Client player)
    {
        NAPI.Marker.CreateMarker(27, new Vector3(102.2458, -2563.187, 5.999994 - 1.0), new Vector3(), new Vector3(), 0.8f, new Color(255, 255, 255, 155));
    }

    public static void PressKeyY(Client player)
    {
        if(Main.IsInRangeOfPoint(player.Position, new Vector3(102.2458, -2563.187, 5.999994), 1.0f))
        {
            List<dynamic> menu_item_list = new List<dynamic>();
            menu_item_list.Add(new { Type = 1, Name = "~c~1x~w~ Hamburger", Description = "American Style Hamburger.", RightLabel = "~g~$"+ PRICE_HAMBURGER.ToString("N0")+ "" });
            menu_item_list.Add(new { Type = 1, Name = "~c~1x~w~ Kaffee", Description = "Ein frischen Kaffee zum mitnehmen.", RightLabel = "~g~$" + PRICE_KAFFEE.ToString("N0") + "" });
            menu_item_list.Add(new { Type = 1, Name = "~c~1x~w~ Cola", Description = "Eine kalte Cola zum mitnehmen.", RightLabel = "~g~$" + PRICE_COLA.ToString("N0") + "" });
            menu_item_list.Add(new { Type = 1, Name = "~c~1x~w~ Sprite", Description = "Eine kalte Sprite zum mitnehmen.", RightLabel = "~g~$" + PRICE_SPRITE.ToString("N0") + "" });
            menu_item_list.Add(new { Type = 1, Name = "~c~1x~w~ Snickers", Description = "Ein leckeres Snickers zum Beruhigung.", RightLabel = "~g~$" + PRICE_SNICKERS.ToString("N0") + "" });
            InteractMenu.CreateMenu(player, "LKW_STORE_ITENS", "LKW Store", "~b~Erhältliche Artikel:", true, JsonConvert.SerializeObject(menu_item_list), false);
        }
    }

    public static void SelectMenuResponse(Client player, String callbackId, int selectedIndex, String objectName, String valueList)
    {
        if(callbackId == "LKW_STORE_ITENS")
        {
            if (selectedIndex == 0)
            {
                if (Main.GetPlayerMoney(player) < PRICE_HAMBURGER)
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "Sie haben dieses Geld nicht zur Hand, dieser Artikel kostet $" + PRICE_HAMBURGER + " und du hast nur $" + Main.GetPlayerMoney(player) + ".");
                    return;
                }

                if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 2, 1, Inventory.Max_Inventory_Weight(player)))
                {
                    return;
                }

                Main.GivePlayerMoney(player, -PRICE_HAMBURGER);
                handelskammersteuer = Convert.ToInt32(System.Math.Ceiling(Convert.ToDouble(PRICE_HAMBURGER) / Convert.ToDouble(100) * 19));
                Inventory.GiveItemToInventory(player, 2, 1);
                NAPI.Notification.SendNotificationToPlayer(player, "Artikel: ~y~Hamburger \n Kosten: ~g~$" + PRICE_HAMBURGER.ToString("N0") + " \n ~w~Steuer: ~g~$~y~" + handelskammersteuer + "");
            }
            else if (selectedIndex == 1)
            {
                if (Main.GetPlayerMoney(player) < PRICE_KAFFEE)
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "Sie haben dieses Geld nicht zur Hand, dieser Artikel kostet$" + PRICE_KAFFEE + " und du hast nur $" + Main.GetPlayerMoney(player) + ".");
                    return;
                }

                if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 35, 1, Inventory.Max_Inventory_Weight(player)))
                {
                    return;
                }
                Inventory.GiveItemToInventory(player, 35, 1);
                handelskammersteuer = Convert.ToInt32(System.Math.Ceiling(Convert.ToDouble(PRICE_KAFFEE) / Convert.ToDouble(100) * 19));
                Main.GivePlayerMoney(player, -PRICE_KAFFEE);
                NAPI.Notification.SendNotificationToPlayer(player, "Artikel: ~y~Kaffee \n Kosten: ~g~$" + PRICE_KAFFEE.ToString("N0") + " \n ~w~Steuer: ~g~$~y~" + handelskammersteuer + "");
            }
            else if (selectedIndex == 2)
            {
                if (Main.GetPlayerMoney(player) < PRICE_COLA)
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "Sie haben dieses Geld nicht zur Hand, dieser Artikel kostet$" + PRICE_COLA + " und du hast nur $" + Main.GetPlayerMoney(player) + ".");
                    return;
                }

                if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 33, 1, Inventory.Max_Inventory_Weight(player)))
                {
                    return;
                }
                Inventory.GiveItemToInventory(player, 33, 1);
                handelskammersteuer = Convert.ToInt32(System.Math.Ceiling(Convert.ToDouble(PRICE_COLA) / Convert.ToDouble(100) * 19));
                Main.GivePlayerMoney(player, -PRICE_COLA);
                NAPI.Notification.SendNotificationToPlayer(player, "Artikel: ~y~Cola \n Kosten: ~g~$" + PRICE_COLA.ToString("N0") + " \n ~w~Steuer: ~g~$~y~" + handelskammersteuer + "");
            }
            else if (selectedIndex == 3)
            {
                if (Main.GetPlayerMoney(player) < PRICE_SPRITE)
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "Sie haben dieses Geld nicht zur Hand, dieser Artikel kostet$" + PRICE_SPRITE + " und du hast nur $" + Main.GetPlayerMoney(player) + ".");
                    return;
                }

                if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 34, 1, Inventory.Max_Inventory_Weight(player)))
                {
                    return;
                }
                Inventory.GiveItemToInventory(player, 34, 1);
                handelskammersteuer = Convert.ToInt32(System.Math.Ceiling(Convert.ToDouble(PRICE_SPRITE) / Convert.ToDouble(100) * 19));
                Main.GivePlayerMoney(player, -PRICE_SPRITE);
                NAPI.Notification.SendNotificationToPlayer(player, "Artikel: ~y~Sprite \n Kosten: ~g~$" + PRICE_SPRITE.ToString("N0") + " \n ~w~Steuer: ~g~$~y~" + handelskammersteuer + "");
            }
            else if (selectedIndex == 4)
            {
                if (Main.GetPlayerMoney(player) < PRICE_SNICKERS)
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "Sie haben dieses Geld nicht zur Hand, dieser Artikel kostet$" + PRICE_SNICKERS + " und du hast nur $" + Main.GetPlayerMoney(player) + ".");
                    return;
                }

                if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 94, 1, Inventory.Max_Inventory_Weight(player)))
                {
                    return;
                }
                Inventory.GiveItemToInventory(player, 94, 1);
                handelskammersteuer = Convert.ToInt32(System.Math.Ceiling(Convert.ToDouble(PRICE_SNICKERS) / Convert.ToDouble(100) * 19));
                Main.GivePlayerMoney(player, -PRICE_SNICKERS);
                NAPI.Notification.SendNotificationToPlayer(player, "Artikel: ~y~Sprite \n Kosten: ~g~$" + PRICE_SNICKERS.ToString("N0") + " \n ~w~Steuer: ~g~$~y~" + handelskammersteuer + "");
            }
        }
    }
}

