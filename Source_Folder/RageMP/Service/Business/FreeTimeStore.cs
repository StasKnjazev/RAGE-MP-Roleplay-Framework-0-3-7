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

class FreeTimeStore : Script
{
    public static List<dynamic> freetimestore_list = new List<dynamic>();

    public static int handelskammersteuer { get; set; }

    public static void FreeTimeStoreInit()
    {
        freetimestore_list.Add(new { item_name = "Snickers-Cocktail", item_price = 49 });
        freetimestore_list.Add(new { item_name = "Mango-Maracuja-Spritz", item_price = 49 });
        freetimestore_list.Add(new { item_name = "Bier-Cocktail", item_price = 45 });
        freetimestore_list.Add(new { item_name = "Coconut-Dream", item_price = 46 });
        freetimestore_list.Add(new { item_name = "Himbeer-Dream", item_price = 49 });
        freetimestore_list.Add(new { item_name = "Erdbeer-Dream", item_price = 45 });
        freetimestore_list.Add(new { item_name = "Wodka-Cocktail", item_price = 46 });
    }

    public static void ShowFreeTimeStoreMenu(Client player)
    {
        int business_id = Business.GetPlayerInBusinessInType(player, 11);
        if (business_id == -1)
        {
            Main.DisplayErrorMessage(player, "Sie befinden sich nicht in einer Firma.");
            return;
        }
        List<dynamic> menu_item_list = new List<dynamic>();
        foreach (var freetimestore in freetimestore_list)
        {
            menu_item_list.Add(new { Type = 1, Name = freetimestore.item_name, Description = "", RightLabel = "~g~$~w~" + freetimestore.item_price });
        }
        InteractMenu.CreateMenu(player, "BUSINESS_FREETIME_STORE", Business.business_list[business_id].business_Name, "~b~" + Business.business_list[business_id].business_Name, true, JsonConvert.SerializeObject(menu_item_list), false);
    }

    public static void SelectMenuResponse(Client player, String callbackId, int selectedIndex, String objectName, String valueList)
    {
        if (callbackId == "BUSINESS_FREETIME_STORE")
        {
            string item = objectName;
            int index = selectedIndex;
            int business_id = Business.GetPlayerInBusinessInType(player, 11);
            if (business_id == -1)
            {
                return;
            }
            switch (item)
            {
                case "Snickers-Cocktail":
                    {
                        //NAPI.Util.ConsoleOutput("DEBUG ::: index " + index + "");
                        if (Main.GetPlayerMoney(player) < freetimestore_list[index].item_price)
                        {
                            NAPI.Notification.SendNotificationToPlayer(player, "ERROR:~w~ Leider können Sie diesen Artikel nicht bezahlen.");
                            return;
                        }

                        if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 2, 1, Inventory.Max_Inventory_Weight(player)))
                        {
                            return;
                        }

                        //NAPI.Util.ConsoleOutput("DEBUG ::: index " + index + " -- " + Business.business_list[business_id].business_OwnerID + " --- " + Business.business_list[business_id].business_Inventory + "");

                        if (Business.business_list[business_id].business_Inventory > 0)
                        {
                            Business.business_list[business_id].business_Safe += freetimestore_list[index].item_price;
                            Business.business_list[business_id].business_Inventory -= 1;
                            Business.SaveBusiness(business_id);
                            Business.UpdateBusinessLabel(business_id);
                        }
                        else
                        {
                            NAPI.Notification.SendNotificationToPlayer(player, "[" + Business.business_list[business_id].business_Name + "]:~w~ Unser Unternehmen hat diesen Artikel nicht auf Lager, bitte kommen Sie später zurück !");
                            return;
                        }

                        Main.GivePlayerMoney(player, -freetimestore_list[index].item_price);
                        handelskammersteuer = Convert.ToInt32(System.Math.Ceiling(Convert.ToDouble(freetimestore_list[index].item_price) / Convert.ToDouble(100) * 19));
                        NAPI.Notification.SendNotificationToPlayer(player, "Artikel: ~y~" + freetimestore_list[index].item_name + " \n Kosten: ~g~$" + freetimestore_list[index].item_price + " \n ~w~Steuer: ~g~$~y~" + handelskammersteuer + "");
                        Inventory.GiveItemToInventory(player, 75, 1);
                        break;
                    }
                case "Mango-Maracuja-Spritz":
                    {
                        //NAPI.Util.ConsoleOutput("DEBUG ::: index " + index + "");
                        if (Main.GetPlayerMoney(player) < freetimestore_list[index].item_price)
                        {
                            NAPI.Notification.SendNotificationToPlayer(player, "ERROR:~w~ Leider können Sie diesen Artikel nicht bezahlen.");
                            return;
                        }

                        if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 2, 1, Inventory.Max_Inventory_Weight(player)))
                        {
                            return;
                        }

                        //NAPI.Util.ConsoleOutput("DEBUG ::: index " + index + " -- " + Business.business_list[business_id].business_OwnerID + " --- " + Business.business_list[business_id].business_Inventory + "");


                        if (Business.business_list[business_id].business_Inventory > 0)
                        {
                            Business.business_list[business_id].business_Safe += freetimestore_list[index].item_price;
                            Business.business_list[business_id].business_Inventory -= 1;
                            Business.SaveBusiness(business_id);
                            Business.UpdateBusinessLabel(business_id);
                        }
                        else
                        {
                            NAPI.Notification.SendNotificationToPlayer(player, "[" + Business.business_list[business_id].business_Name + "]:~w~ Unser Unternehmen hat diesen Artikel nicht auf Lager, bitte kommen Sie später zurück !");
                            return;
                        }

                        Main.GivePlayerMoney(player, -freetimestore_list[index].item_price);
                        handelskammersteuer = Convert.ToInt32(System.Math.Ceiling(Convert.ToDouble(freetimestore_list[index].item_price) / Convert.ToDouble(100) * 19));
                        NAPI.Notification.SendNotificationToPlayer(player, "Artikel: ~y~" + freetimestore_list[index].item_name + " \n Kosten: ~g~$" + freetimestore_list[index].item_price + " \n ~w~Steuer: ~g~$~y~" + handelskammersteuer + "");
                        Inventory.GiveItemToInventory(player, 76, 1);
                        break;
                    }
                case "Bier-Cocktail":
                    {
                        //NAPI.Util.ConsoleOutput("DEBUG ::: index " + index + "");
                        if (Main.GetPlayerMoney(player) < freetimestore_list[index].item_price)
                        {
                            NAPI.Notification.SendNotificationToPlayer(player, "ERROR:~w~ Leider können Sie diesen Artikel nicht bezahlen.");
                            return;
                        }

                        if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 2, 1, Inventory.Max_Inventory_Weight(player)))
                        {
                            return;
                        }

                        //NAPI.Util.ConsoleOutput("DEBUG ::: index " + index + " -- " + Business.business_list[business_id].business_OwnerID + " --- " + Business.business_list[business_id].business_Inventory + "");

                        if (Business.business_list[business_id].business_Inventory > 0)
                        {
                            Business.business_list[business_id].business_Safe += freetimestore_list[index].item_price;
                            Business.business_list[business_id].business_Inventory -= 1;
                            Business.SaveBusiness(business_id);
                            Business.UpdateBusinessLabel(business_id);
                        }
                        else
                        {
                            NAPI.Notification.SendNotificationToPlayer(player, "[" + Business.business_list[business_id].business_Name + "]:~w~ Unser Unternehmen hat diesen Artikel nicht auf Lager, bitte kommen Sie später zurück !");
                            return;
                        }

                        Main.GivePlayerMoney(player, -freetimestore_list[index].item_price);
                        handelskammersteuer = Convert.ToInt32(System.Math.Ceiling(Convert.ToDouble(freetimestore_list[index].item_price) / Convert.ToDouble(100) * 19));
                        NAPI.Notification.SendNotificationToPlayer(player, "Artikel: ~y~" + freetimestore_list[index].item_name + " \n Kosten: ~g~$" + freetimestore_list[index].item_price + " \n ~w~Steuer: ~g~$~y~" + handelskammersteuer + "");
                        Inventory.GiveItemToInventory(player, 77, 1);
                        break;
                    }
                case "Coconut-Dream":
                    {
                        //NAPI.Util.ConsoleOutput("DEBUG ::: index " + index + "");
                        if (Main.GetPlayerMoney(player) < freetimestore_list[index].item_price)
                        {
                            NAPI.Notification.SendNotificationToPlayer(player, "ERROR:~w~ Leider können Sie diesen Artikel nicht bezahlen.");
                            return;
                        }

                        if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 2, 1, Inventory.Max_Inventory_Weight(player)))
                        {
                            return;
                        }

                        //NAPI.Util.ConsoleOutput("DEBUG ::: index " + index + " -- " + Business.business_list[business_id].business_OwnerID + " --- " + Business.business_list[business_id].business_Inventory + "");

                        if (Business.business_list[business_id].business_Inventory > 0)
                        {
                            Business.business_list[business_id].business_Safe += freetimestore_list[index].item_price;
                            Business.business_list[business_id].business_Inventory -= 1;
                            Business.SaveBusiness(business_id);
                            Business.UpdateBusinessLabel(business_id);
                        }
                        else
                        {
                            NAPI.Notification.SendNotificationToPlayer(player, "[" + Business.business_list[business_id].business_Name + "]:~w~ Unser Unternehmen hat diesen Artikel nicht auf Lager, bitte kommen Sie später zurück !");
                            return;
                        }

                        Main.GivePlayerMoney(player, -freetimestore_list[index].item_price);
                        handelskammersteuer = Convert.ToInt32(System.Math.Ceiling(Convert.ToDouble(freetimestore_list[index].item_price) / Convert.ToDouble(100) * 19));
                        NAPI.Notification.SendNotificationToPlayer(player, "Artikel: ~y~" + freetimestore_list[index].item_name + " \n Kosten: ~g~$" + freetimestore_list[index].item_price + " \n ~w~Steuer: ~g~$~y~" + handelskammersteuer + "");
                        Inventory.GiveItemToInventory(player, 78, 1);
                        break;
                    }
                case "Himbeer-Dream":
                    {
                        //NAPI.Util.ConsoleOutput("DEBUG ::: index " + index + "");
                        if (Main.GetPlayerMoney(player) < freetimestore_list[index].item_price)
                        {
                            NAPI.Notification.SendNotificationToPlayer(player, "ERROR:~w~ Leider können Sie diesen Artikel nicht bezahlen.");
                            return;
                        }

                        if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 2, 1, Inventory.Max_Inventory_Weight(player)))
                        {
                            return;
                        }

                        //NAPI.Util.ConsoleOutput("DEBUG ::: index " + index + " -- " + Business.business_list[business_id].business_OwnerID + " --- " + Business.business_list[business_id].business_Inventory + "");

                        if (Business.business_list[business_id].business_Inventory > 0)
                        {
                            Business.business_list[business_id].business_Safe += freetimestore_list[index].item_price;
                            Business.business_list[business_id].business_Inventory -= 1;
                            Business.SaveBusiness(business_id);
                            Business.UpdateBusinessLabel(business_id);
                        }
                        else
                        {
                            NAPI.Notification.SendNotificationToPlayer(player, "[" + Business.business_list[business_id].business_Name + "]:~w~ Unser Unternehmen hat diesen Artikel nicht auf Lager, bitte kommen Sie später zurück !");
                            return;
                        }

                        Main.GivePlayerMoney(player, -freetimestore_list[index].item_price);
                        handelskammersteuer = Convert.ToInt32(System.Math.Ceiling(Convert.ToDouble(freetimestore_list[index].item_price) / Convert.ToDouble(100) * 19));
                        NAPI.Notification.SendNotificationToPlayer(player, "Artikel: ~y~" + freetimestore_list[index].item_name + " \n Kosten: ~g~$" + freetimestore_list[index].item_price + " \n ~w~Steuer: ~g~$~y~" + handelskammersteuer + "");
                        Inventory.GiveItemToInventory(player, 79, 1);
                        break;
                    }
                case "Erdbeer-Dream":
                    {
                        //NAPI.Util.ConsoleOutput("DEBUG ::: index " + index + "");
                        if (Main.GetPlayerMoney(player) < freetimestore_list[index].item_price)
                        {
                            NAPI.Notification.SendNotificationToPlayer(player, "ERROR:~w~ Leider können Sie diesen Artikel nicht bezahlen.");
                            return;
                        }

                        if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 2, 1, Inventory.Max_Inventory_Weight(player)))
                        {
                            return;
                        }

                        //NAPI.Util.ConsoleOutput("DEBUG ::: index " + index + " -- " + Business.business_list[business_id].business_OwnerID + " --- " + Business.business_list[business_id].business_Inventory + "");

                        if (Business.business_list[business_id].business_Inventory > 0)
                        {
                            Business.business_list[business_id].business_Safe += freetimestore_list[index].item_price;
                            Business.business_list[business_id].business_Inventory -= 1;
                            Business.SaveBusiness(business_id);
                            Business.UpdateBusinessLabel(business_id);
                        }
                        else
                        {
                            NAPI.Notification.SendNotificationToPlayer(player, "[" + Business.business_list[business_id].business_Name + "]:~w~ Unser Unternehmen hat diesen Artikel nicht auf Lager, bitte kommen Sie später zurück !");
                            return;
                        }

                        Main.GivePlayerMoney(player, -freetimestore_list[index].item_price);
                        handelskammersteuer = Convert.ToInt32(System.Math.Ceiling(Convert.ToDouble(freetimestore_list[index].item_price) / Convert.ToDouble(100) * 19));
                        NAPI.Notification.SendNotificationToPlayer(player, "Artikel: ~y~" + freetimestore_list[index].item_name + " \n Kosten: ~g~$" + freetimestore_list[index].item_price + " \n ~w~Steuer: ~g~$~y~" + handelskammersteuer + "");
                        Inventory.GiveItemToInventory(player, 80, 1);
                        break;
                    }
                case "Wodka-Cocktail":
                    {
                        //NAPI.Util.ConsoleOutput("DEBUG ::: index " + index + "");
                        if (Main.GetPlayerMoney(player) < freetimestore_list[index].item_price)
                        {
                            NAPI.Notification.SendNotificationToPlayer(player, "ERROR:~w~ Leider können Sie diesen Artikel nicht bezahlen.");
                            return;
                        }

                        if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 2, 1, Inventory.Max_Inventory_Weight(player)))
                        {
                            return;
                        }

                        //NAPI.Util.ConsoleOutput("DEBUG ::: index " + index + " -- " + Business.business_list[business_id].business_OwnerID + " --- " + Business.business_list[business_id].business_Inventory + "");

                        if (Business.business_list[business_id].business_Inventory > 0)
                        {
                            Business.business_list[business_id].business_Safe += freetimestore_list[index].item_price;
                            Business.business_list[business_id].business_Inventory -= 1;
                            Business.SaveBusiness(business_id);
                            Business.UpdateBusinessLabel(business_id);
                        }
                        else
                        {
                            NAPI.Notification.SendNotificationToPlayer(player, "[" + Business.business_list[business_id].business_Name + "]:~w~ Unser Unternehmen hat diesen Artikel nicht auf Lager, bitte kommen Sie später zurück !");
                            return;
                        }

                        Main.GivePlayerMoney(player, -freetimestore_list[index].item_price);
                        handelskammersteuer = Convert.ToInt32(System.Math.Ceiling(Convert.ToDouble(freetimestore_list[index].item_price) / Convert.ToDouble(100) * 19));
                        NAPI.Notification.SendNotificationToPlayer(player, "Artikel: ~y~" + freetimestore_list[index].item_name + " \n Kosten: ~g~$" + freetimestore_list[index].item_price + " \n ~w~Steuer: ~g~$~y~" + handelskammersteuer + "");
                        Inventory.GiveItemToInventory(player, 81, 1);
                        break;
                    }
            }
        }
    }
}