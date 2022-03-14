using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;
using Newtonsoft.Json;
using DerStr1k3r.Core;

class ACLSStore : Script
{
    public static int PRICE_HAMBURGER = 10;

    public static dynamic handelskammersteuer { get; set; }

    public ACLSStore()
    {
    }

    [ServerEvent(Event.PlayerConnected)]
    public void OnPlayerConnected(Client player)
    {
        NAPI.Marker.CreateMarker(27, new Vector3(-1166.258, -2017.697, 13.18026 - 1.0), new Vector3(), new Vector3(), 0.8f, new Color(255, 255, 255, 155));
    }

    public static void PressKeyY(Client player)
    {
        if(Main.IsInRangeOfPoint(player.Position, new Vector3(-1166.258, -2017.697, 13.18026), 1.0f))
        {
            List<dynamic> menu_item_list = new List<dynamic>();
            menu_item_list.Add(new { Type = 1, Name = "~c~1x~w~ Reperaturteil", Description = "Reperaturteil für die Fahrzeugreperatur!", RightLabel = "~g~$"+ PRICE_HAMBURGER.ToString("N0")+ "" });
            InteractMenu.CreateMenu(player, "ACLS_STORE_ITENS", "ACLS Shop", "~b~Erhältliche Artikel:", true, JsonConvert.SerializeObject(menu_item_list), false);
        }
    }

    public static void SelectMenuResponse(Client player, String callbackId, int selectedIndex, String objectName, String valueList)
    {
        if(callbackId == "ACLS_STORE_ITENS")
        {
            if (selectedIndex == 0)
            {
                if (Main.GetPlayerMoney(player) < PRICE_HAMBURGER)
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "Sie haben dieses Geld nicht zur Hand, dieser Artikel kostet $" + PRICE_HAMBURGER + " und du hast nur $" + Main.GetPlayerMoney(player) + ".");
                    return;
                }

                if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 8, 1, Inventory.Max_Inventory_Weight(player)))
                {
                    return;
                }

                Main.GivePlayerMoney(player, -PRICE_HAMBURGER);
                handelskammersteuer = Convert.ToInt32(System.Math.Ceiling(Convert.ToDouble(PRICE_HAMBURGER) / Convert.ToDouble(100) * 19));
                Inventory.GiveItemToInventory(player, 8, 1);
                NAPI.Notification.SendNotificationToPlayer(player, "Artikel: ~y~Reperaturteil \n Kosten: ~g~$" + PRICE_HAMBURGER.ToString("N0") + " \n ~w~Steuer: ~g~$~y~" + handelskammersteuer + "");
            }
        }
    }
}

