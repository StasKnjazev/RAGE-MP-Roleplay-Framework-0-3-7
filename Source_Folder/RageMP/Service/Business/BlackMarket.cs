using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;
using Newtonsoft.Json;
using DerStr1k3r.Core;
using DerStr1k3r.SDK;

class BlackMarket : Script
{
    public static int PRICE_DRILL = 6000;
    public static int PRICE_C4 = 6000;
    public static int PRICE_DIETRICH = 750;
    public static int PRICE_SACK = 350;
    public static int PRICE_GRIFF = 1000;
    public static int PRICE_CARWASHTICKET = 5000;
    public static int PRICE_ElEKTRODRAHT = 3500;
    public static int PRICE_PTKEY = 500000;

    public BlackMarket()
    {
    }

    [ServerEvent(Event.PlayerConnected)]
    public void OnPlayerConnected(Client player)
    {
        player.TriggerEvent("Sync_PedCreate", "blackmarket", NAPI.Util.PedNameToModel("Car3Guy1Cutscene"), new Vector3(2749.514, 3470.527, 55.68787), 241.1673f, "", 0);
        player.TriggerEvent("Sync_PedCreate", "clearmoney", NAPI.Util.PedNameToModel("Business01AMY"), new Vector3(-61.192886, -1217.3431, 28.765644), -102.112114f, "", 0);
        player.TriggerEvent("Sync_PedCreate", "clearibuprofen", NAPI.Util.PedNameToModel("Business01AMY"), new Vector3(774.8753, -499.07864, 28.474493), 23.050507f, "", 0);
        player.TriggerEvent("Sync_PedCreate", "clearlevothyroxin", NAPI.Util.PedNameToModel("Business01AMY"), new Vector3(826.1712, -815.7916, 26.332218), -10.519092f, "", 0);
        player.TriggerEvent("Sync_PedCreate", "clearsimvastatin", NAPI.Util.PedNameToModel("Business01AMY"), new Vector3(-1564.225, -3235.139, 26.33617), 238.8821f, "", 0);
    }

    public static void PressKeyY(Client player)
    {
        if(Main.IsInRangeOfPoint(player.Position, new Vector3(2749.514, 3470.527, 55.68787), 3.0f))
        {
            List<dynamic> menu_item_list = new List<dynamic>();
            menu_item_list.Add(new { Type = 1, Name = "~c~1x~w~ Bohrer", Description = "Derzeit erforderlich, um die Bank zu überfallen.", RightLabel = "~g~$"+ PRICE_DRILL.ToString("N0")+ "" });
            menu_item_list.Add(new { Type = 1, Name = "~c~1x~w~ C4", Description = "Derzeit erforderlich, um die Bank zu überfallen.", RightLabel = "~g~$" + PRICE_C4.ToString("N0") + "" });
            menu_item_list.Add(new { Type = 1, Name = "~c~1x~w~ Dietrich", Description = "Derzeit erforderlich, um ein Fahrzeug aufzubrechen sowie kurz zu schliessen.", RightLabel = "~g~$" + PRICE_DIETRICH.ToString("N0") + "" });
            menu_item_list.Add(new { Type = 1, Name = "~c~1x~w~ Griff", Description = "Derzeit erforderlich, um diesen Artikel dem Waffen Ersteller zugeben.", RightLabel = "~g~$" + PRICE_GRIFF.ToString("N0") + "" });
            menu_item_list.Add(new { Type = 1, Name = "~c~1x~w~ Carwash Ticket", Description = "Derzeit erforderlich, um diesen Artikel bei den Carwash einzulösen.", RightLabel = "~g~$" + PRICE_CARWASHTICKET.ToString("N0") + "" });
            menu_item_list.Add(new { Type = 1, Name = "~c~1x~w~ ElektroDraht", Description = "Derzeit erforderlich, um diesen Artikel bei ein Rätsel als Lösung zu benutzen.", RightLabel = "~g~$" + PRICE_ElEKTRODRAHT.ToString("N0") + "" });
            menu_item_list.Add(new { Type = 1, Name = "~c~1x~w~ Sack", Description = "Metal Sack zum verarbeiten.", RightLabel = "~g~$" + PRICE_SACK.ToString("N0") + "" });
            menu_item_list.Add(new { Type = 1, Name = "~c~1x~w~ LSPD Schlüssel", Description = "Dieser Schlüssel ist dafür da um die Polizeitüren auf zu bekommen.", RightLabel = "~g~$" + PRICE_PTKEY.ToString("N0") + "" });
            InteractMenu.CreateMenu(player, "BLACKMARKET_ITENS", "O.B.I.", "~b~Bei dem O.B.I. erhältliche Artikel:", true, JsonConvert.SerializeObject(menu_item_list), false);
        }
        else if(Main.IsInRangeOfPoint(player.Position, new Vector3(-61.192886, -1217.3431, 28.765644), 3.0f))
        {
            InteractMenu.User_Input(player, "clear_money", "Menge, die Sie waschen möchten", "0", "", "number");
        }
        else if (Main.IsInRangeOfPoint(player.Position, new Vector3(774.8753, -499.07864, 28.474493), 3.0f))
        {
            InteractMenu.User_Input(player, "clear_ibuprofen", "Menge, die Sie verkaufen möchten", "0", "", "number");
        }
        else if (Main.IsInRangeOfPoint(player.Position, new Vector3(826.1712, -815.7916, 26.332218), 3.0f))
        {
            InteractMenu.User_Input(player, "clear_levothyroxin", "Menge, die Sie verkaufen möchten", "0", "", "number");
        }
        else if (Main.IsInRangeOfPoint(player.Position, new Vector3(-1564.225, -3235.139, 26.33617), 3.0f))
        {
            InteractMenu.User_Input(player, "clear_simvastatin", "Menge, die Sie verkaufen möchten", "0", "", "number");
        }
    }

    public static void OnInputResponse(Client player, String response, String inputtext)
    {
        if(response == "clear_money")
        {
            if (!Main.IsNumeric(inputtext))
            {
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Ungültiger eingegebener Wert.", 5000);
                return;
            }
            int value = Convert.ToInt32(inputtext);

            if (value < 1000 || value > 10000)
            {
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Der Betrag sollte zwischen 1.000 und 10.000 Liberty Dollor liegen.", 5000);
                return;
            }

            if (Inventory.GetPlayerItemFromInventory(player, 158) < value)
            {
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du hast nicht genügend von den Item!", 5000);
                return;
            }

            Inventory.RemoveItemByType(player, 158, value);
            Main.GivePlayerMoney(player, value - Convert.ToInt32((1.25 * value)));
            Notify.Send(player, NotifyType.Success, NotifyPosition.BottomCenter, $"Du hast gewaschen " + value + "x  Liberty Dollor zu $" + (value - Convert.ToInt32((1.25 * value))) + " sauberem Geld.", 5000);
        }
        else if (response == "clear_ibuprofen")
        {
            if (!Main.IsNumeric(inputtext))
            {
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Ungültiger eingegebener Wert.", 5000);
                return;
            }
            int value = Convert.ToInt32(inputtext);

            if (value < 10 || value > 20)
            {
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Der Betrag sollte zwischen 10 und 20 Einheiten liegen.", 5000);
                return;
            }

            if (Inventory.GetPlayerItemFromInventory(player, 22) < value)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Sie haben diesen Betrag nicht, Sie besitzen nur $" + Inventory.GetPlayerItemFromInventory(player, 22) + " Illegales Ibuprofen, und Sie versuchen es zu " + value + " verkaufen.");
                return;
            }

            Random rnd = new Random();
            int price = value * rnd.Next(199, 243);

            Inventory.RemoveItemByType(player, 22, value);
            Inventory.GiveItemToInventory(player, 158, price);
            NAPI.Notification.SendNotificationToPlayer(player, "Du hast " + value + "x Illegales Ibuprofen zu $" + price + " verkauft.");
        }
        else if (response == "clear_levothyroxin")
        {
            if (!Main.IsNumeric(inputtext))
            {
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Ungültiger eingegebener Wert.", 5000);
                return;
            }
            int value = Convert.ToInt32(inputtext);

            if (value < 10 || value > 20)
            {
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Der Betrag sollte zwischen 10 und 20 Einheiten liegen.", 5000);
                return;
            }

            if (Inventory.GetPlayerItemFromInventory(player, 23) < value)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Sie haben diesen Betrag nicht, Sie besitzen nur $" + Inventory.GetPlayerItemFromInventory(player, 23) + " Illegales Ibuprofen, und Sie versuchen es zu " + value + " verkaufen.");
                return;
            }

            Random rnd = new Random();
            int price2 = value * rnd.Next(299, 313);

            Inventory.RemoveItemByType(player, 23, value);
            Inventory.GiveItemToInventory(player, 158, price2);
            NAPI.Notification.SendNotificationToPlayer(player, "Du hast " + value + "x Illegales Levothyroxin zu $" + price2 + " verkauft.");
        }
        else if (response == "clear_simvastatin")
        {
            if (!Main.IsNumeric(inputtext))
            {
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Ungültiger eingegebener Wert.", 5000);
                return;
            }
            int value = Convert.ToInt32(inputtext);

            if (value < 10 || value > 20)
            {
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Der Betrag sollte zwischen 10 und 20 Einheiten liegen.", 5000);
                return;
            }

            if (Inventory.GetPlayerItemFromInventory(player, 26) < value)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Sie haben diesen Betrag nicht, Sie besitzen nur $" + Inventory.GetPlayerItemFromInventory(player, 26) + " Illegales Simvastatin, und Sie versuchen es zu " + value + " verkaufen.");
                return;
            }

            Random rnd = new Random();
            int price3 = value * rnd.Next(399, 423);

            Inventory.RemoveItemByType(player, 26, value);
            Inventory.GiveItemToInventory(player, 158, price3);
            NAPI.Notification.SendNotificationToPlayer(player, "Du hast " + value + "x Illegales Simvastatin zu $" + price3 + " verkauft.");
        }
    }

    public static void SelectMenuResponse(Client player, String callbackId, int selectedIndex, String objectName, String valueList)
    {
        if(callbackId == "BLACKMARKET_ITENS")
        {
            if(selectedIndex == 0)
            {
                if(Main.GetPlayerMoney(player) < PRICE_DRILL)
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "Sie haben dieses Geld nicht zur Hand, dieser Artikel kostet $"+ PRICE_DRILL + " und du hast nur $" + Main.GetPlayerMoney(player)+".");
                    return;
                }

                if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 19, 1, Inventory.Max_Inventory_Weight(player)))
                {
                    return;
                }

                Main.GivePlayerMoney(player, -PRICE_DRILL);
                Inventory.GiveItemToInventory(player, 20, 1);
                NAPI.Notification.SendNotificationToPlayer(player, "Du hast " + Main.EMBED_LIGHTGREEN + "1x Bohren gekauft" + Main.EMBED_WHITE + " von " + Main.EMBED_GREEN + "$" + PRICE_DRILL.ToString("N0") + "" + Main.EMBED_WHITE + ".");
            }
            else if(selectedIndex == 1)
            {
                if (Main.GetPlayerMoney(player) < PRICE_C4)
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "Sie haben dieses Geld nicht zur Hand, dieser Artikel kostet$" + PRICE_C4 + " und du hast nur $" + Main.GetPlayerMoney(player) + ".");
                    return;
                }

                if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 20, 1, Inventory.Max_Inventory_Weight(player)))
                {
                    return;
                }

                Inventory.GiveItemToInventory(player, 19, 1);
                Main.GivePlayerMoney(player, -PRICE_C4);
                NAPI.Notification.SendNotificationToPlayer(player, "Du hast " + Main.EMBED_LIGHTGREEN + "1x C4 gekauft" + Main.EMBED_WHITE+" von "+Main.EMBED_GREEN+"$"+ PRICE_C4.ToString("N0")+ ""+Main.EMBED_WHITE+".");
            }
            else if (selectedIndex == 2)
            {
                if (Main.GetPlayerMoney(player) < PRICE_DIETRICH)
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "Sie haben dieses Geld nicht zur Hand, dieser Artikel kostet$" + PRICE_DIETRICH + " und du hast nur $" + Main.GetPlayerMoney(player) + ".");
                    return;
                }

                if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 71, 1, Inventory.Max_Inventory_Weight(player)))
                {
                    return;
                }
                Inventory.GiveItemToInventory(player, 70, 1);
                Main.GivePlayerMoney(player, -PRICE_DIETRICH);
                NAPI.Notification.SendNotificationToPlayer(player, "Du hast " + Main.EMBED_LIGHTGREEN + "1x Dietrich gekauft" + Main.EMBED_WHITE + " von " + Main.EMBED_GREEN + "$" + PRICE_DIETRICH.ToString("N0") + "" + Main.EMBED_WHITE + ".");
            }
            else if (selectedIndex == 3)
            {
                if (Main.GetPlayerMoney(player) < PRICE_GRIFF)
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "Sie haben dieses Geld nicht zur Hand, dieser Artikel kostet$" + PRICE_GRIFF + " und du hast nur $" + Main.GetPlayerMoney(player) + ".");
                    return;
                }

                if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 99, 1, Inventory.Max_Inventory_Weight(player)))
                {
                    return;
                }
                Inventory.GiveItemToInventory(player, 99, 1);
                Main.GivePlayerMoney(player, -PRICE_GRIFF);
                NAPI.Notification.SendNotificationToPlayer(player, "Du hast " + Main.EMBED_LIGHTGREEN + "1x Griff gekauft" + Main.EMBED_WHITE + " von " + Main.EMBED_GREEN + "$" + PRICE_GRIFF.ToString("N0") + "" + Main.EMBED_WHITE + ".");
            }
            else if (selectedIndex == 4)
            {
                if (Main.GetPlayerMoney(player) < PRICE_CARWASHTICKET)
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "Sie haben dieses Geld nicht zur Hand, dieser Artikel kostet$" + PRICE_CARWASHTICKET + " und du hast nur $" + Main.GetPlayerMoney(player) + ".");
                    return;
                }

                if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 73, 1, Inventory.Max_Inventory_Weight(player)))
                {
                    return;
                }
                Inventory.GiveItemToInventory(player, 73, 1);
                Main.GivePlayerMoney(player, -PRICE_CARWASHTICKET);
                NAPI.Notification.SendNotificationToPlayer(player, "Du hast " + Main.EMBED_LIGHTGREEN + "1x Carwash Ticket gekauft" + Main.EMBED_WHITE + " von " + Main.EMBED_GREEN + "$" + PRICE_CARWASHTICKET.ToString("N0") + "" + Main.EMBED_WHITE + ".");
            }
            else if (selectedIndex == 5)
            {
                if (Main.GetPlayerMoney(player) < PRICE_ElEKTRODRAHT)
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "Sie haben dieses Geld nicht zur Hand, dieser Artikel kostet$" + PRICE_ElEKTRODRAHT + " und du hast nur $" + Main.GetPlayerMoney(player) + ".");
                    return;
                }

                if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 71, 1, Inventory.Max_Inventory_Weight(player)))
                {
                    return;
                }
                Inventory.GiveItemToInventory(player, 71, 1);
                Main.GivePlayerMoney(player, -PRICE_ElEKTRODRAHT);
                NAPI.Notification.SendNotificationToPlayer(player, "Du hast " + Main.EMBED_LIGHTGREEN + "1x ElektroDraht gekauft" + Main.EMBED_WHITE + " von " + Main.EMBED_GREEN + "$" + PRICE_ElEKTRODRAHT.ToString("N0") + "" + Main.EMBED_WHITE + ".");
            }
            else if (selectedIndex == 6)
            {
                if (Main.GetPlayerMoney(player) < PRICE_ElEKTRODRAHT)
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "Sie haben dieses Geld nicht zur Hand, dieser Artikel kostet$" + PRICE_ElEKTRODRAHT + " und du hast nur $" + Main.GetPlayerMoney(player) + ".");
                    return;
                }

                if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 100, 1, Inventory.Max_Inventory_Weight(player)))
                {
                    return;
                }
                Inventory.GiveItemToInventory(player, 100, 1);
                Main.GivePlayerMoney(player, -PRICE_SACK);
                NAPI.Notification.SendNotificationToPlayer(player, "Du hast " + Main.EMBED_LIGHTGREEN + "1x Metal Sack gekauft" + Main.EMBED_WHITE + " von " + Main.EMBED_GREEN + "$" + PRICE_SACK.ToString("N0") + "" + Main.EMBED_WHITE + ".");
            }
            else if (selectedIndex == 7)
            {
                if (Main.GetPlayerMoney(player) < PRICE_PTKEY)
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "Sie haben dieses Geld nicht zur Hand, dieser Artikel kostet$" + PRICE_PTKEY + " und du hast nur $" + Main.GetPlayerMoney(player) + ".");
                    return;
                }

                if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 69, 1, Inventory.Max_Inventory_Weight(player)))
                {
                    return;
                }
                Inventory.GiveItemToInventory(player, 69, 1);
                Main.GivePlayerMoney(player, -PRICE_PTKEY);
                NAPI.Notification.SendNotificationToPlayer(player, "Du hast " + Main.EMBED_LIGHTGREEN + "1x LSPD Schlüssel gekauft" + Main.EMBED_WHITE + " von " + Main.EMBED_GREEN + "$" + PRICE_PTKEY.ToString("N0") + "" + Main.EMBED_WHITE + ".");
            }
        }
    }
}

