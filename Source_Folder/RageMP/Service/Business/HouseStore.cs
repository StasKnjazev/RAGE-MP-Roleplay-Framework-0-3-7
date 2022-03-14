using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;
using Newtonsoft.Json;
using DerStr1k3r.Core;

class HouseStore : Script
{
    public static int PRICE_MARS = 2;
    public static int PRICE_SNICKERS = 4;
    public static dynamic handelskammersteuer { get; set; }

    public HouseStore()
    {
    }

    [ServerEvent(Event.PlayerConnected)]
    public void OnPlayerConnected(Client player)
    {
        NAPI.Marker.CreateMarker(27, new Vector3(343.7401, -1001.1867, -99.19624 - 1.0), new Vector3(), new Vector3(), 0.8f, new Color(255, 255, 255, 155));
        NAPI.Marker.CreateMarker(27, new Vector3(-677.93164, 592.79407, 145.37962 - 1.0), new Vector3(), new Vector3(), 0.8f, new Color(255, 255, 255, 155));
    }

    public static void PressKeyY(Client player)
    {
        if(Main.IsInRangeOfPoint(player.Position, new Vector3(343.7401, -1001.1867, -99.19624), 1.0f))
        {
            List<dynamic> menu_item_list = new List<dynamic>();
            menu_item_list.Add(new { Type = 1, Name = "~c~1x~w~ Wasser", Description = "Die Strom kosten werden dir bei heraus nehmen berechnet." });
            menu_item_list.Add(new { Type = 1, Name = "~c~1x~w~ Hamburger", Description = "Die Strom kosten werden dir bei heraus nehmen berechnet." });
            InteractMenu.CreateMenu(player, "HOUSE_STORE_ITENS", "Kühlschrank", "~b~Erhältliche Artikel:", true, JsonConvert.SerializeObject(menu_item_list), false);
        }
        if (Main.IsInRangeOfPoint(player.Position, new Vector3(-677.93164, 592.79407, 145.37962), 1.0f))
        {
            List<dynamic> menu_item_list = new List<dynamic>();
            menu_item_list.Add(new { Type = 1, Name = "~c~1x~w~ Wasser", Description = "Die Strom kosten werden dir bei heraus nehmen berechnet." });
            menu_item_list.Add(new { Type = 1, Name = "~c~1x~w~ Hamburger", Description = "Die Strom kosten werden dir bei heraus nehmen berechnet." });
            InteractMenu.CreateMenu(player, "HOUSE_STORE_ITENS", "Kühlschrank", "~b~Erhältliche Artikel:", true, JsonConvert.SerializeObject(menu_item_list), false);
        }
    }

    public static void SelectMenuResponse(Client player, String callbackId, int selectedIndex, String objectName, String valueList)
    {
        if(callbackId == "HOUSE_STORE_ITENS")
        {
            if (selectedIndex == 0)
            {
                if (Main.GetPlayerMoney(player) < PRICE_MARS)
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "Sie haben dieses Geld nicht zur Hand, dieser Artikel kostet$" + PRICE_MARS + " und du hast nur $" + Main.GetPlayerMoney(player) + ".");
                    return;
                }

                if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 1, 1, Inventory.Max_Inventory_Weight(player)))
                {
                    return;
                }
                Inventory.GiveItemToInventory(player, 1, 1);
                handelskammersteuer = Convert.ToInt32(System.Math.Ceiling(Convert.ToDouble(PRICE_MARS) / Convert.ToDouble(100) * 19));
                Main.GivePlayerMoney(player, -handelskammersteuer);
                NAPI.Notification.SendNotificationToPlayer(player, "Artikel: ~y~Wasser \n ~w~Strom Preis: ~g~$~y~" + handelskammersteuer + "");
            }
            else if (selectedIndex == 1)
            {
                if (Main.GetPlayerMoney(player) < PRICE_SNICKERS)
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "Sie haben dieses Geld nicht zur Hand, dieser Artikel kostet$" + PRICE_SNICKERS + " und du hast nur $" + Main.GetPlayerMoney(player) + ".");
                    return;
                }

                if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 2, 1, Inventory.Max_Inventory_Weight(player)))
                {
                    return;
                }
                Inventory.GiveItemToInventory(player, 2, 1);
                handelskammersteuer = Convert.ToInt32(System.Math.Ceiling(Convert.ToDouble(PRICE_SNICKERS) / Convert.ToDouble(100) * 19));
                Main.GivePlayerMoney(player, -handelskammersteuer);
                NAPI.Notification.SendNotificationToPlayer(player, "Artikel: ~y~Hamburger \n ~w~Strom Preis: ~g~$~y~" + handelskammersteuer + "");
            }
        }
    }
}

