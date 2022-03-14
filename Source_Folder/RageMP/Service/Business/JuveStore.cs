using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Data;
using System.IO;
using GTANetworkAPI;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using DerStr1k3r.Core;

class JuveStore : Script
{
    public static List<dynamic> juvestore_list = new List<dynamic>();

    public static dynamic handelskammersteuer { get; set; }

    public static void JuveStoreInit()
    {
        juvestore_list.Add(new { item_name = "Verlobungsring", item_price = 5000 });
        juvestore_list.Add(new { item_name = "Ehering", item_price = 7500 });
    }

    public static void ShowJuveStoreMenu(Client player)
    {
        int business_id = Business.GetPlayerInBusinessInType(player, 12);
        if (business_id == -1)
        {
            Main.DisplayErrorMessage(player, "Sie befinden sich nicht in einer Firma.");
            return;
        }
        List<dynamic> menu_item_list = new List<dynamic>();
        foreach (var JuveStore in juvestore_list)
        {
            menu_item_list.Add(new { Type = 1, Name = JuveStore.item_name, Description = "", RightLabel = "~g~$~w~" + JuveStore.item_price });
        }
        InteractMenu.CreateMenu(player, "BUSINESS_JUVE_STORE", "Juvelier", "~b~" + Business.business_list[business_id].business_Name, true, JsonConvert.SerializeObject(menu_item_list), false);
    }

    public static void SelectMenuResponse(Client player, String callbackId, int selectedIndex, String objectName, String valueList)
    {
        if (callbackId == "BUSINESS_JUVE_STORE")
        {
            string item = objectName;
            int index = selectedIndex;
            int business_id = Business.GetPlayerInBusinessInType(player, 12);
            if (business_id == -1)
            {
                return;
            }
            switch (item)
            {
                case "Verlobungsring":
                    {
                        //NAPI.Util.ConsoleOutput("DEBUG ::: index " + index + "");
                        if (Main.GetPlayerMoney(player) < juvestore_list[index].item_price)
                        {
                            NAPI.Notification.SendNotificationToPlayer(player, "ERROR:~w~ Leider können Sie diesen Artikel nicht bezahlen.");
                            return;
                        }

                        if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 82, 1, Inventory.Max_Inventory_Weight(player)))
                        {
                            return;
                        }

                        //NAPI.Util.ConsoleOutput("DEBUG ::: index " + index + " -- " + Business.business_list[business_id].business_OwnerID + " --- " + Business.business_list[business_id].business_Inventory + "");

                        if (Business.business_list[business_id].business_Inventory > 0)
                        {
                            Business.business_list[business_id].business_Safe += juvestore_list[index].item_price;
                            Business.business_list[business_id].business_Inventory -= 1;
                            Business.SaveBusiness(business_id);
                            Business.UpdateBusinessLabel(business_id);
                        }
                        else
                        {
                            NAPI.Notification.SendNotificationToPlayer(player, "[" + Business.business_list[business_id].business_Name + "]:~w~ Unser Unternehmen hat diesen Artikel nicht auf Lager, bitte kommen Sie später zurück !");
                            return;
                        }

                        Main.GivePlayerMoney(player, -juvestore_list[index].item_price);
                        handelskammersteuer = Convert.ToInt32(System.Math.Ceiling(Convert.ToDouble(juvestore_list[index].item_price) / Convert.ToDouble(100) * 19));
                        NAPI.Notification.SendNotificationToPlayer(player, "Artikel: ~y~" + juvestore_list[index].item_name + " \n Kosten: ~g~$" + juvestore_list[index].item_price + " \n ~w~Steuer: ~g~$~y~" + handelskammersteuer + "");
                        Inventory.GiveItemToInventory(player, 82, 1);
                        break;
                    }
                case "Ehering":
                    {
                        //NAPI.Util.ConsoleOutput("DEBUG ::: index " + index + "");
                        if (Main.GetPlayerMoney(player) < juvestore_list[index].item_price)
                        {
                            NAPI.Notification.SendNotificationToPlayer(player, "ERROR:~w~ Leider können Sie diesen Artikel nicht bezahlen.");
                            return;
                        }

                        if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 93, 1, Inventory.Max_Inventory_Weight(player)))
                        {
                            return;
                        }

                        //NAPI.Util.ConsoleOutput("DEBUG ::: index " + index + " -- " + Business.business_list[business_id].business_OwnerID + " --- " + Business.business_list[business_id].business_Inventory + "");

                        if (Business.business_list[business_id].business_Inventory > 0)
                        {
                            Business.business_list[business_id].business_Safe += juvestore_list[index].item_price;
                            Business.business_list[business_id].business_Inventory -= 1;
                            Business.SaveBusiness(business_id);
                            Business.UpdateBusinessLabel(business_id);
                        }
                        else
                        {
                            NAPI.Notification.SendNotificationToPlayer(player, "[" + Business.business_list[business_id].business_Name + "]:~w~ Unser Unternehmen hat diesen Artikel nicht auf Lager, bitte kommen Sie später zurück !");
                            return;
                        }

                        Main.GivePlayerMoney(player, -juvestore_list[index].item_price);
                        handelskammersteuer = Convert.ToInt32(System.Math.Ceiling(Convert.ToDouble(juvestore_list[index].item_price) / Convert.ToDouble(100) * 19));
                        NAPI.Notification.SendNotificationToPlayer(player, "Artikel: ~y~" + juvestore_list[index].item_name + " \n Kosten: ~g~$" + juvestore_list[index].item_price + " \n ~w~Steuer: ~g~$~y~" + handelskammersteuer + "");
                        Inventory.GiveItemToInventory(player, 93, 1);
                        break;
                    }

            }
        }
    }
}