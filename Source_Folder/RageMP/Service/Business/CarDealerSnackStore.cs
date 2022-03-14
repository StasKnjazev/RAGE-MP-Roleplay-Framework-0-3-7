using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;
using Newtonsoft.Json;
using DerStr1k3r.Core;

class CarDealerSnackStore : Script
{
    public static int PRICE_MARS = 5;
    public static int PRICE_SNICKERS = 3;
    public static dynamic handelskammersteuer { get; set; }

    public CarDealerSnackStore()
    {
    }

    [ServerEvent(Event.PlayerConnected)]
    public void OnPlayerConnected(Client player)
    {
        NAPI.Marker.CreateMarker(27, new Vector3(-38.282272, -1094.5762, 26.422354 - 1.0), new Vector3(), new Vector3(), 0.8f, new Color(255, 255, 255, 155));
    }

    public static void PressKeyY(Client player)
    {
        if(Main.IsInRangeOfPoint(player.Position, new Vector3(-38.282272, -1094.5762, 26.422354), 1.0f))
        {
            List<dynamic> menu_item_list = new List<dynamic>();
            menu_item_list.Add(new { Type = 1, Name = "~c~1x~w~ Mars", Description = "Ein leckeres Mars zum Beruhigung.", RightLabel = "~g~$" + PRICE_MARS.ToString("N0") + "" });
            menu_item_list.Add(new { Type = 1, Name = "~c~1x~w~ Snickers", Description = "Ein leckeres Snickers zum Beruhigung.", RightLabel = "~g~$" + PRICE_SNICKERS.ToString("N0") + "" });
            InteractMenu.CreateMenu(player, "CARDEALER_SNACK_STORE_ITENS", "Car Dealer Snack Store", "~b~Erhältliche Artikel:", true, JsonConvert.SerializeObject(menu_item_list), false);
        }
    }

    public static void SelectMenuResponse(Client player, String callbackId, int selectedIndex, String objectName, String valueList)
    {
        if(callbackId == "CARDEALER_SNACK_STORE_ITENS")
        {
            if (selectedIndex == 0)
            {
                if (Main.GetPlayerMoney(player) < PRICE_MARS)
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "Sie haben dieses Geld nicht zur Hand, dieser Artikel kostet$" + PRICE_MARS + " und du hast nur $" + Main.GetPlayerMoney(player) + ".");
                    return;
                }

                if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 34, 1, Inventory.Max_Inventory_Weight(player)))
                {
                    return;
                }
                Inventory.GiveItemToInventory(player, 34, 1);
                handelskammersteuer = Convert.ToInt32(System.Math.Ceiling(Convert.ToDouble(PRICE_MARS) / Convert.ToDouble(100) * 19));
                Main.GivePlayerMoney(player, -PRICE_MARS);
                NAPI.Notification.SendNotificationToPlayer(player, "Artikel: ~y~Sprite \n Kosten: ~g~$" + PRICE_MARS.ToString("N0") + " \n ~w~Steuer: ~g~$~y~" + handelskammersteuer + "");
            }
            else if (selectedIndex == 1)
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

