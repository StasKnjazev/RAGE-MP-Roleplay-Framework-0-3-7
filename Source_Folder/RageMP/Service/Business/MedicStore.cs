using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;
using Newtonsoft.Json;
using DerStr1k3r.Core;

class MedicStore : Script
{
    public static int PRICE_IBU = 10;
    public static int PRICE_LEV = 4;
    public static int PRICE_PANT = 5;
    public static int PRICE_RAMI = 5;
    public static int PRICE_SIMVA = 3;

    public MedicStore()
    {
    }

    [ServerEvent(Event.PlayerConnected)]
    public void OnPlayerConnected(Client player)
    {
        NAPI.Marker.CreateMarker(27, new Vector3(354.625, -574.7686, 28.79147 - 1.0), new Vector3(), new Vector3(), 0.8f, new Color(255, 255, 255, 155));
        NAPI.Marker.CreateMarker(27, new Vector3(-252.5446, 6327.801, 32.43393 - 1.0), new Vector3(), new Vector3(), 0.8f, new Color(255, 255, 255, 155));
        NAPI.Marker.CreateMarker(27, new Vector3(1832.8021, 3688.832, 34.27082 - 1.0), new Vector3(), new Vector3(), 0.8f, new Color(255, 255, 255, 155));
    }

    public static void PressKeyY(Client player)
    {
        if (FactionManage.GetPlayerGroupType(player) == 2)
        {
            if (Main.IsInRangeOfPoint(player.Position, new Vector3(354.625, -574.7686, 28.79147), 1.0f))
            {
                List<dynamic> menu_item_list = new List<dynamic>();
                menu_item_list.Add(new { Type = 1, Name = "~c~1x~w~ Ibuprofen", Description = "Nicht-steroidales Antirheumatikum zur Behandlung von mittelschweren Schmerzen", RightLabel = "~g~$" + PRICE_IBU.ToString("N0") + "" });
                menu_item_list.Add(new { Type = 1, Name = "~c~1x~w~ Levothyroxin", Description = "Schilddrüsenhormon.", RightLabel = "~g~$" + PRICE_LEV.ToString("N0") + "" });
                menu_item_list.Add(new { Type = 1, Name = "~c~1x~w~ Pantoprazol", Description = "Magensäurehemmendes Präparat.", RightLabel = "~g~$" + PRICE_PANT.ToString("N0") + "" });
                menu_item_list.Add(new { Type = 1, Name = "~c~1x~w~ Ramipril", Description = "ACE-Hemmer", RightLabel = "~g~$" + PRICE_RAMI.ToString("N0") + "" });
                menu_item_list.Add(new { Type = 1, Name = "~c~1x~w~ Simvastatin", Description = "Cholesterinsenker", RightLabel = "~g~$" + PRICE_SIMVA.ToString("N0") + "" });
                InteractMenu.CreateMenu(player, "MEDIC_STORE_ITENS", "Medic Store", "~b~Erhältliche Artikel:", true, JsonConvert.SerializeObject(menu_item_list), false);
            }
            if (Main.IsInRangeOfPoint(player.Position, new Vector3(-252.5446, 6327.801, 32.43393), 1.0f))
            {
                List<dynamic> menu_item_list = new List<dynamic>();
                menu_item_list.Add(new { Type = 1, Name = "~c~1x~w~ Ibuprofen", Description = "Nicht-steroidales Antirheumatikum zur Behandlung von mittelschweren Schmerzen", RightLabel = "~g~$" + PRICE_IBU.ToString("N0") + "" });
                menu_item_list.Add(new { Type = 1, Name = "~c~1x~w~ Levothyroxin", Description = "Schilddrüsenhormon.", RightLabel = "~g~$" + PRICE_LEV.ToString("N0") + "" });
                menu_item_list.Add(new { Type = 1, Name = "~c~1x~w~ Pantoprazol", Description = "Magensäurehemmendes Präparat.", RightLabel = "~g~$" + PRICE_PANT.ToString("N0") + "" });
                menu_item_list.Add(new { Type = 1, Name = "~c~1x~w~ Ramipril", Description = "ACE-Hemmer", RightLabel = "~g~$" + PRICE_RAMI.ToString("N0") + "" });
                menu_item_list.Add(new { Type = 1, Name = "~c~1x~w~ Simvastatin", Description = "Cholesterinsenker", RightLabel = "~g~$" + PRICE_SIMVA.ToString("N0") + "" });
                InteractMenu.CreateMenu(player, "MEDIC_STORE_ITENS", "Medic Store", "~b~Erhältliche Artikel:", true, JsonConvert.SerializeObject(menu_item_list), false);
            }
            if (Main.IsInRangeOfPoint(player.Position, new Vector3(1832.8021, 3688.832, 34.27082), 1.0f))
            {
                List<dynamic> menu_item_list = new List<dynamic>();
                menu_item_list.Add(new { Type = 1, Name = "~c~1x~w~ Ibuprofen", Description = "Nicht-steroidales Antirheumatikum zur Behandlung von mittelschweren Schmerzen", RightLabel = "~g~$" + PRICE_IBU.ToString("N0") + "" });
                menu_item_list.Add(new { Type = 1, Name = "~c~1x~w~ Levothyroxin", Description = "Schilddrüsenhormon.", RightLabel = "~g~$" + PRICE_LEV.ToString("N0") + "" });
                menu_item_list.Add(new { Type = 1, Name = "~c~1x~w~ Pantoprazol", Description = "Magensäurehemmendes Präparat.", RightLabel = "~g~$" + PRICE_PANT.ToString("N0") + "" });
                menu_item_list.Add(new { Type = 1, Name = "~c~1x~w~ Ramipril", Description = "ACE-Hemmer", RightLabel = "~g~$" + PRICE_RAMI.ToString("N0") + "" });
                menu_item_list.Add(new { Type = 1, Name = "~c~1x~w~ Simvastatin", Description = "Cholesterinsenker", RightLabel = "~g~$" + PRICE_SIMVA.ToString("N0") + "" });
                InteractMenu.CreateMenu(player, "MEDIC_STORE_ITENS", "Medic Store", "~b~Erhältliche Artikel:", true, JsonConvert.SerializeObject(menu_item_list), false);
            }
        }
    }

    public static void SelectMenuResponse(Client player, String callbackId, int selectedIndex, String objectName, String valueList)
    {
        if(callbackId == "MEDIC_STORE_ITENS")
        {
            if(selectedIndex == 0)
            {
                if(Main.GetPlayerMoney(player) < PRICE_IBU)
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "Sie haben dieses Geld nicht zur Hand, dieser Artikel kostet $"+ PRICE_IBU + " und du hast nur $" + Main.GetPlayerMoney(player)+".");
                    return;
                }

                if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 22, 1, Inventory.Max_Inventory_Weight(player)))
                {
                    return;
                }

                Main.GivePlayerMoney(player, -PRICE_IBU);
                Inventory.GiveItemToInventory(player, 22, 1);
                NAPI.Notification.SendNotificationToPlayer(player, "Du hast " + Main.EMBED_LIGHTGREEN + "1x Ibuprofen gekauft" + Main.EMBED_WHITE + " von " + Main.EMBED_GREEN + "$" + PRICE_IBU.ToString("N0") + "" + Main.EMBED_WHITE + ".");
            }
            else if(selectedIndex == 1)
            {
                if (Main.GetPlayerMoney(player) < PRICE_LEV)
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "Sie haben dieses Geld nicht zur Hand, dieser Artikel kostet$" + PRICE_LEV + " und du hast nur $" + Main.GetPlayerMoney(player) + ".");
                    return;
                }

                if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 23, 1, Inventory.Max_Inventory_Weight(player)))
                {
                    return;
                }
                Inventory.GiveItemToInventory(player, 23, 1);
                Main.GivePlayerMoney(player, -PRICE_LEV);
                NAPI.Notification.SendNotificationToPlayer(player, "Du hast " + Main.EMBED_LIGHTGREEN + "1x Levothyroxin gekauft" + Main.EMBED_WHITE+" von "+Main.EMBED_GREEN+"$"+ PRICE_LEV.ToString("N0")+ ""+Main.EMBED_WHITE+".");
            }
            else if (selectedIndex == 2)
            {
                if (Main.GetPlayerMoney(player) < PRICE_PANT)
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "Sie haben dieses Geld nicht zur Hand, dieser Artikel kostet$" + PRICE_PANT + " und du hast nur $" + Main.GetPlayerMoney(player) + ".");
                    return;
                }

                if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 24, 1, Inventory.Max_Inventory_Weight(player)))
                {
                    return;
                }
                Inventory.GiveItemToInventory(player, 24, 1);
                Main.GivePlayerMoney(player, -PRICE_PANT);
                NAPI.Notification.SendNotificationToPlayer(player, "Du hast " + Main.EMBED_LIGHTGREEN + "1x Pantoprazol gekauft" + Main.EMBED_WHITE + " von " + Main.EMBED_GREEN + "$" + PRICE_PANT.ToString("N0") + "" + Main.EMBED_WHITE + ".");
            }
            else if (selectedIndex == 3)
            {
                if (Main.GetPlayerMoney(player) < PRICE_RAMI)
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "Sie haben dieses Geld nicht zur Hand, dieser Artikel kostet$" + PRICE_RAMI + " und du hast nur $" + Main.GetPlayerMoney(player) + ".");
                    return;
                }

                if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 25, 1, Inventory.Max_Inventory_Weight(player)))
                {
                    return;
                }
                Inventory.GiveItemToInventory(player, 25, 1);
                Main.GivePlayerMoney(player, -PRICE_RAMI);
                NAPI.Notification.SendNotificationToPlayer(player, "Du hast " + Main.EMBED_LIGHTGREEN + "1x Ramipril gekauft" + Main.EMBED_WHITE + " von " + Main.EMBED_GREEN + "$" + PRICE_RAMI.ToString("N0") + "" + Main.EMBED_WHITE + ".");
            }
            else if (selectedIndex == 4)
            {
                if (Main.GetPlayerMoney(player) < PRICE_SIMVA)
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "Sie haben dieses Geld nicht zur Hand, dieser Artikel kostet$" + PRICE_SIMVA + " und du hast nur $" + Main.GetPlayerMoney(player) + ".");
                    return;
                }

                if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 26, 1, Inventory.Max_Inventory_Weight(player)))
                {
                    return;
                }
                Inventory.GiveItemToInventory(player, 26, 1);
                Main.GivePlayerMoney(player, -PRICE_SIMVA);
                NAPI.Notification.SendNotificationToPlayer(player, "Du hast " + Main.EMBED_LIGHTGREEN + "1x Simvastatin gekauft" + Main.EMBED_WHITE + " von " + Main.EMBED_GREEN + "$" + PRICE_SIMVA.ToString("N0") + "" + Main.EMBED_WHITE + ".");
            }
        }
    }
}

