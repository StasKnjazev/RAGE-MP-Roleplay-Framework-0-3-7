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
using DerStr1k3r.SDK;


class GeneralStore : Script
{
    public static List<dynamic> store_list = new List<dynamic>();

    public static dynamic handelskammersteuer { get; set; }

    public static void GeneralStoreInit()
    {
        store_list.Add(new { item_name = "Hamburger", item_price = 17 });
        store_list.Add(new { item_name = "Calzone", item_price = 16 });
        store_list.Add(new { item_name = "Wasser", item_price = 11 });
        store_list.Add(new { item_name = "Cola", item_price = 12 });
        store_list.Add(new { item_name = "Sprite", item_price = 12 });
        store_list.Add(new { item_name = "Kaffee", item_price = 12 });
        store_list.Add(new { item_name = "Champus", item_price = 489 });
        store_list.Add(new { item_name = "Döner", item_price = 12 });
        store_list.Add(new { item_name = "Snickers", item_price = 7 });
        store_list.Add(new { item_name = "Mars", item_price = 7 });
        store_list.Add(new { item_name = "Schokolade", item_price = 6 });
        store_list.Add(new { item_name = "Chips", item_price = 6 });
        store_list.Add(new { item_name = "Flips", item_price = 6 });
        store_list.Add(new { item_name = "Bockwurst", item_price = 11 });
        store_list.Add(new { item_name = "Cheese Burger", item_price = 16 });
        store_list.Add(new { item_name = "Bacon Burger", item_price = 16 });
        store_list.Add(new { item_name = "Lasagne", item_price = 16 });
        store_list.Add(new { item_name = "Thunfisch Pizza", item_price = 18 });
        store_list.Add(new { item_name = "Salami Pizza", item_price = 19 });
        store_list.Add(new { item_name = "Pizza Hawaii", item_price = 17 });
        store_list.Add(new { item_name = "Kleine Tasche", item_price = 199 });
        store_list.Add(new { item_name = "Große Tasche", item_price = 549 });
        store_list.Add(new { item_name = "Benzinkanister", item_price = 819 });
        store_list.Add(new { item_name = "First Aid Kit", item_price = 3500 });
        store_list.Add(new { item_name = "Öl Flasche", item_price = 4200 });
    }

    public static void ShowGeneralStoreMenu(Client player)
    {
        int business_id = Business.GetPlayerInBusinessInType(player, 2);
        if (business_id == -1)
        {
            Main.DisplayErrorMessage(player, "Sie befinden sich nicht in einer Firma.");
            return;
        }
        List<dynamic> menu_item_list = new List<dynamic>();
        foreach (var store in store_list)
        {
            menu_item_list.Add(new { Type = 1, Name = store.item_name, Description = "", RightLabel = "~g~$~w~" + store.item_price });
        }
        InteractMenu.CreateMenu(player, "BUSINESS_GENERAL_STORE", "24-7", "~b~" + Business.business_list[business_id].business_Name, true, JsonConvert.SerializeObject(menu_item_list), false, BackgroundColor: "Green");
    }

    public static void SelectMenuResponse(Client player, String callbackId, int selectedIndex, String objectName, String valueList)
    {
        if (callbackId == "BUSINESS_GENERAL_STORE")
        {
            string item = objectName;
            int index = selectedIndex;
            int business_id = Business.GetPlayerInBusinessInType(player, 2);
            if (business_id == -1)
            {
                return;
            }
            switch (item)
            {
                case "Lasagne":
                    {
                        //NAPI.Util.ConsoleOutput("DEBUG ::: index " + index + "");
                        if (Main.GetPlayerMoney(player) < store_list[index].item_price)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Leider können Sie diesen Artikel nicht bezahlen.", 5000);
                            return;
                        }

                        if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 2, 1, Inventory.Max_Inventory_Weight(player)))
                        {
                            return;
                        }

                        if (Business.business_list[business_id].business_Inventory > 0)
                        {
                            Business.business_list[business_id].business_Safe += store_list[index].item_price;
                            Business.business_list[business_id].business_Inventory -= 1;
                            Business.SaveBusiness(business_id);
                            Business.UpdateBusinessLabel(business_id);
                        }
                        else
                        {
                            NAPI.Notification.SendNotificationToPlayer(player, "[" + Business.business_list[business_id].business_Name + "]:~w~ Unser Unternehmen hat diesen Artikel nicht auf Lager, bitte kommen Sie später zurück !");
                            return;
                        }

                        Main.GivePlayerMoney(player, -store_list[index].item_price);
                        handelskammersteuer = Convert.ToInt32(System.Math.Ceiling(Convert.ToDouble(store_list[index].item_price) / Convert.ToDouble(100) * 19));
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Artikel: " + store_list[index].item_name + " Preis: $" + store_list[index].item_price + " Steuer: $" + handelskammersteuer + "", 5000);
                        
                        //NAPI.Notification.SendNotificationToPlayer(player, "  ~w~Steuer: ~g~$~y~" + handelskammersteuer + "");
                        Inventory.GiveItemToInventory(player, 51, 1);
                        break;
                    }
                case "Thunfisch Pizza":
                    {
                        //NAPI.Util.ConsoleOutput("DEBUG ::: index " + index + "");
                        if (Main.GetPlayerMoney(player) < store_list[index].item_price)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Leider können Sie diesen Artikel nicht bezahlen.", 5000);
                            return;
                        }

                        if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 2, 1, Inventory.Max_Inventory_Weight(player)))
                        {
                            return;
                        }

                        //NAPI.Util.ConsoleOutput("DEBUG ::: index " + index + " -- " + Business.business_list[business_id].business_OwnerID + " --- " + Business.business_list[business_id].business_Inventory + "");


                        if (Business.business_list[business_id].business_Inventory > 0)
                        {
                            Business.business_list[business_id].business_Safe += store_list[index].item_price;
                            Business.business_list[business_id].business_Inventory -= 1;
                            Business.SaveBusiness(business_id);
                            Business.UpdateBusinessLabel(business_id);
                        }
                        else
                        {
                            NAPI.Notification.SendNotificationToPlayer(player, "[" + Business.business_list[business_id].business_Name + "]:~w~ Unser Unternehmen hat diesen Artikel nicht auf Lager, bitte kommen Sie später zurück !");
                            return;
                        }

                        Main.GivePlayerMoney(player, -store_list[index].item_price);
                        handelskammersteuer = Convert.ToInt32(System.Math.Ceiling(Convert.ToDouble(store_list[index].item_price) / Convert.ToDouble(100) * 19));
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Artikel: " + store_list[index].item_name + " Preis: $" + store_list[index].item_price + " Steuer: $" + handelskammersteuer + "", 5000);
                        Inventory.GiveItemToInventory(player, 52, 1);
                        break;
                    }
                case "Salami Pizza":
                    {
                        //NAPI.Util.ConsoleOutput("DEBUG ::: index " + index + "");
                        if (Main.GetPlayerMoney(player) < store_list[index].item_price)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Leider können Sie diesen Artikel nicht bezahlen.", 5000);
                            return;
                        }

                        if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 2, 1, Inventory.Max_Inventory_Weight(player)))
                        {
                            return;
                        }

                        //NAPI.Util.ConsoleOutput("DEBUG ::: index " + index + " -- " + Business.business_list[business_id].business_OwnerID + " --- " + Business.business_list[business_id].business_Inventory + "");

                        if (Business.business_list[business_id].business_Inventory > 0)
                        {
                            Business.business_list[business_id].business_Safe += store_list[index].item_price;
                            Business.business_list[business_id].business_Inventory -= 1;
                            Business.SaveBusiness(business_id);
                            Business.UpdateBusinessLabel(business_id);

                            //NAPI.Util.ConsoleOutput("DEBUG ::: index " + index + " -- " + Business.business_list[business_id].business_OwnerID + " --- " + Business.business_list[business_id].business_Inventory + "");
                        }
                        else
                        {
                            NAPI.Notification.SendNotificationToPlayer(player, "[" + Business.business_list[business_id].business_Name + "]:~w~ Unser Unternehmen hat diesen Artikel nicht auf Lager, bitte kommen Sie später zurück !");
                            return;
                        }

                        Main.GivePlayerMoney(player, -store_list[index].item_price);
                        handelskammersteuer = Convert.ToInt32(System.Math.Ceiling(Convert.ToDouble(store_list[index].item_price) / Convert.ToDouble(100) * 19));
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Artikel: " + store_list[index].item_name + " Preis: $" + store_list[index].item_price + " Steuer: $" + handelskammersteuer + "", 5000);
                        Inventory.GiveItemToInventory(player, 53, 1);
                        break;
                    }
                case "Pizza Hawaii":
                    {
                        //NAPI.Util.ConsoleOutput("DEBUG ::: index " + index + "");
                        if (Main.GetPlayerMoney(player) < store_list[index].item_price)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Leider können Sie diesen Artikel nicht bezahlen.", 5000);
                            return;
                        }

                        if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 2, 1, Inventory.Max_Inventory_Weight(player)))
                        {
                            return;
                        }

                        //NAPI.Util.ConsoleOutput("DEBUG ::: index " + index + " -- " + Business.business_list[business_id].business_OwnerID + " --- " + Business.business_list[business_id].business_Inventory + "");

                        if (Business.business_list[business_id].business_Inventory > 0)
                        {
                            Business.business_list[business_id].business_Safe += store_list[index].item_price;
                            Business.business_list[business_id].business_Inventory -= 1;
                            Business.SaveBusiness(business_id);
                            Business.UpdateBusinessLabel(business_id);
                        }
                        else
                        {
                            NAPI.Notification.SendNotificationToPlayer(player, "[" + Business.business_list[business_id].business_Name + "]:~w~ Unser Unternehmen hat diesen Artikel nicht auf Lager, bitte kommen Sie später zurück !");
                            return;
                        }

                        Main.GivePlayerMoney(player, -store_list[index].item_price);
                        handelskammersteuer = Convert.ToInt32(System.Math.Ceiling(Convert.ToDouble(store_list[index].item_price) / Convert.ToDouble(100) * 19));
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Artikel: " + store_list[index].item_name + " Preis: $" + store_list[index].item_price + " Steuer: $" + handelskammersteuer + "", 5000);
                        Inventory.GiveItemToInventory(player, 54, 1);
                        break;
                    }
                case "Hamburger":
                    {
                        //NAPI.Util.ConsoleOutput("DEBUG ::: index " + index + "");
                        if (Main.GetPlayerMoney(player) < store_list[index].item_price)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Leider können Sie diesen Artikel nicht bezahlen.", 5000);
                            return;
                        }

                        if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 2, 1, Inventory.Max_Inventory_Weight(player)))
                        {
                            return;
                        }

                        //NAPI.Util.ConsoleOutput("DEBUG ::: index " + index + " -- " + Business.business_list[business_id].business_OwnerID + " --- " + Business.business_list[business_id].business_Inventory + "");


                        if (Business.business_list[business_id].business_Inventory > 0)
                        {
                            Business.business_list[business_id].business_Safe += store_list[index].item_price;
                            Business.business_list[business_id].business_Inventory -= 1;
                            Business.SaveBusiness(business_id);
                            Business.UpdateBusinessLabel(business_id);
                        }
                        else
                        {
                            NAPI.Notification.SendNotificationToPlayer(player, "[" + Business.business_list[business_id].business_Name + "]:~w~ Unser Unternehmen hat diesen Artikel nicht auf Lager, bitte kommen Sie später zurück !");
                            return;
                        }


                        Main.GivePlayerMoney(player, -store_list[index].item_price);
                        handelskammersteuer = Convert.ToInt32(System.Math.Ceiling(Convert.ToDouble(store_list[index].item_price) / Convert.ToDouble(100) * 19));
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Artikel: " + store_list[index].item_name + " Preis: $" + store_list[index].item_price + " Steuer: $" + handelskammersteuer + "", 5000);
                        Inventory.GiveItemToInventory(player, 2, 1);
                        break;
                    }
                case "Wasser":
                    {
                        if (Main.GetPlayerMoney(player) < store_list[index].item_price)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Leider können Sie diesen Artikel nicht bezahlen.", 5000);
                            return;
                        }
                        if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 1, 1, Inventory.Max_Inventory_Weight(player)))
                        {
                            return;
                        }

                        if (Business.business_list[business_id].business_Inventory > 0)
                        {
                            Business.business_list[business_id].business_Safe += store_list[index].item_price;
                            Business.business_list[business_id].business_Inventory -= 1;
                            Business.SaveBusiness(business_id);
                            Business.UpdateBusinessLabel(business_id);
                        }
                        else
                        {
                            NAPI.Notification.SendNotificationToPlayer(player, "[" + Business.business_list[business_id].business_Name + "]:~w~ Unser Unternehmen ist momentan nicht auf Lager, bitte kommen Sie später zurück!");
                            return;
                        }

                        Main.GivePlayerMoney(player, -store_list[index].item_price);
                        handelskammersteuer = Convert.ToInt32(System.Math.Ceiling(Convert.ToDouble(store_list[index].item_price) / Convert.ToDouble(100) * 19));
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Artikel: " + store_list[index].item_name + " Preis: $" + store_list[index].item_price + " Steuer: $" + handelskammersteuer + "", 5000);
                        Inventory.GiveItemToInventory(player, 1, 1);
                        break;
                    }
                case "Cola":
                    {
                        if (Main.GetPlayerMoney(player) < store_list[index].item_price)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Leider können Sie diesen Artikel nicht bezahlen.", 5000);
                            return;
                        }
                        if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 33, 1, Inventory.Max_Inventory_Weight(player)))
                        {
                            return;
                        }

                        if (Business.business_list[business_id].business_Inventory > 0)
                        {
                            Business.business_list[business_id].business_Safe += store_list[index].item_price;
                            Business.business_list[business_id].business_Inventory -= 1;
                            Business.SaveBusiness(business_id);
                            Business.UpdateBusinessLabel(business_id);
                        }
                        else
                        {
                            NAPI.Notification.SendNotificationToPlayer(player, "[" + Business.business_list[business_id].business_Name + "]:~w~ Unser Unternehmen ist momentan nicht auf Lager, bitte kommen Sie später zurück!");
                            return;
                        }

                        Main.GivePlayerMoney(player, -store_list[index].item_price);
                        handelskammersteuer = Convert.ToInt32(System.Math.Ceiling(Convert.ToDouble(store_list[index].item_price) / Convert.ToDouble(100) * 19));
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Artikel: " + store_list[index].item_name + " Preis: $" + store_list[index].item_price + " Steuer: $" + handelskammersteuer + "", 5000);
                        Inventory.GiveItemToInventory(player, 33, 1);
                        break;
                    }
                case "Sprite":
                    {
                        if (Main.GetPlayerMoney(player) < store_list[index].item_price)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Leider können Sie diesen Artikel nicht bezahlen.", 5000);
                            return;
                        }
                        if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 34, 1, Inventory.Max_Inventory_Weight(player)))
                        {
                            return;
                        }

                        if (Business.business_list[business_id].business_Inventory > 0)
                        {
                            Business.business_list[business_id].business_Safe += store_list[index].item_price;
                            Business.business_list[business_id].business_Inventory -= 1;
                            Business.SaveBusiness(business_id);
                            Business.UpdateBusinessLabel(business_id);
                        }
                        else
                        {
                            NAPI.Notification.SendNotificationToPlayer(player, "[" + Business.business_list[business_id].business_Name + "]:~w~ Unser Unternehmen ist momentan nicht auf Lager, bitte kommen Sie später zurück!");
                            return;
                        }

                        Main.GivePlayerMoney(player, -store_list[index].item_price);
                        handelskammersteuer = Convert.ToInt32(System.Math.Ceiling(Convert.ToDouble(store_list[index].item_price) / Convert.ToDouble(100) * 19));
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Artikel: " + store_list[index].item_name + " Preis: $" + store_list[index].item_price + " Steuer: $" + handelskammersteuer + "", 5000);
                        Inventory.GiveItemToInventory(player, 34, 1);
                        break;
                    }
                case "Kaffee":
                    {
                        if (Main.GetPlayerMoney(player) < store_list[index].item_price)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Leider können Sie diesen Artikel nicht bezahlen.", 5000);
                            return;
                        }
                        if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 35, 1, Inventory.Max_Inventory_Weight(player)))
                        {
                            return;
                        }

                        if (Business.business_list[business_id].business_Inventory > 0)
                        {
                            Business.business_list[business_id].business_Safe += store_list[index].item_price;
                            Business.business_list[business_id].business_Inventory -= 1;
                            Business.SaveBusiness(business_id);
                            Business.UpdateBusinessLabel(business_id);
                        }
                        else
                        {
                            NAPI.Notification.SendNotificationToPlayer(player, "[" + Business.business_list[business_id].business_Name + "]:~w~ Unser Unternehmen ist momentan nicht auf Lager, bitte kommen Sie später zurück!");
                            return;
                        }

                        Main.GivePlayerMoney(player, -store_list[index].item_price);
                        handelskammersteuer = Convert.ToInt32(System.Math.Ceiling(Convert.ToDouble(store_list[index].item_price) / Convert.ToDouble(100) * 19));
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Artikel: " + store_list[index].item_name + " Preis: $" + store_list[index].item_price + " Steuer: $" + handelskammersteuer + "", 5000);
                        Inventory.GiveItemToInventory(player, 35, 1);
                        break;
                    }
                case "Calzone":
                    {
                        //NAPI.Util.ConsoleOutput("DEBUG ::: index " + index + "");
                        if (Main.GetPlayerMoney(player) < store_list[index].item_price)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Leider können Sie diesen Artikel nicht bezahlen.", 5000);
                            return;
                        }

                        if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 36, 1, Inventory.Max_Inventory_Weight(player)))
                        {
                            return;
                        }

                        //NAPI.Util.ConsoleOutput("DEBUG ::: index " + index + " -- " + Business.business_list[business_id].business_OwnerID + " --- " + Business.business_list[business_id].business_Inventory + "");


                        if (Business.business_list[business_id].business_Inventory > 0)
                        {
                            Business.business_list[business_id].business_Safe += store_list[index].item_price;
                            Business.business_list[business_id].business_Inventory -= 1;
                            Business.SaveBusiness(business_id);
                            Business.UpdateBusinessLabel(business_id);
                        }
                        else
                        {
                            NAPI.Notification.SendNotificationToPlayer(player, "[" + Business.business_list[business_id].business_Name + "]:~w~ Unser Unternehmen hat diesen Artikel nicht auf Lager, bitte kommen Sie später zurück !");
                            return;
                        }


                        Main.GivePlayerMoney(player, -store_list[index].item_price);
                        handelskammersteuer = Convert.ToInt32(System.Math.Ceiling(Convert.ToDouble(store_list[index].item_price) / Convert.ToDouble(100) * 19));
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Artikel: " + store_list[index].item_name + " Preis: $" + store_list[index].item_price + " Steuer: $" + handelskammersteuer + "", 5000);
                        Inventory.GiveItemToInventory(player, 36, 1);
                        break;
                    }
                case "Kleine Tasche":
                    {
                        if (Main.GetPlayerMoney(player) < store_list[index].item_price)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Leider können Sie diesen Artikel nicht bezahlen.", 5000);
                            return;
                        }
                        if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 9, 1, Inventory.Max_Inventory_Weight(player)))
                        {
                            return;
                        }

                        if (Business.business_list[business_id].business_Inventory > 0)
                        {
                            Business.business_list[business_id].business_Safe += store_list[index].item_price;
                            Business.business_list[business_id].business_Inventory -= 1;
                            Business.SaveBusiness(business_id);
                            Business.UpdateBusinessLabel(business_id);
                        }
                        else
                        {
                            NAPI.Notification.SendNotificationToPlayer(player, "[" + Business.business_list[business_id].business_Name + "]:~w~ Unser Unternehmen hat momentan das nicht auf Lager, bitte kommen Sie später wieder!");
                            return;
                        }

                        Main.GivePlayerMoney(player, -store_list[index].item_price);
                        handelskammersteuer = Convert.ToInt32(System.Math.Ceiling(Convert.ToDouble(store_list[index].item_price) / Convert.ToDouble(100) * 19));
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Artikel: " + store_list[index].item_name + " Preis: $" + store_list[index].item_price + " Steuer: $" + handelskammersteuer + "", 5000);
                        Inventory.GiveItemToInventory(player, 9, 1);
                        break;
                    }
                case "Große Tasche":
                    {
                        if (Main.GetPlayerMoney(player) < store_list[index].item_price)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Leider können Sie diesen Artikel nicht bezahlen.", 5000);
                            return;
                        }
                        if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 9, 1, Inventory.Max_Inventory_Weight(player)))
                        {
                            return;
                        }

                        if (Business.business_list[business_id].business_Inventory > 0)
                        {
                            Business.business_list[business_id].business_Safe += store_list[index].item_price;
                            Business.business_list[business_id].business_Inventory -= 1;
                            Business.SaveBusiness(business_id);
                            Business.UpdateBusinessLabel(business_id);
                        }
                        else
                        {
                            NAPI.Notification.SendNotificationToPlayer(player, "[" + Business.business_list[business_id].business_Name + "]:~w~ Unser Unternehmen hat momentan das nicht auf Lager, bitte kommen Sie später wieder!");
                            return;
                        }

                        Main.GivePlayerMoney(player, -store_list[index].item_price);
                        handelskammersteuer = Convert.ToInt32(System.Math.Ceiling(Convert.ToDouble(store_list[index].item_price) / Convert.ToDouble(100) * 19));
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Artikel: " + store_list[index].item_name + " Preis: $" + store_list[index].item_price + " Steuer: $" + handelskammersteuer + "", 5000);
                        Inventory.GiveItemToInventory(player, 10, 1);
                        break;
                    }
                case "Smartphone":
                    {
                        if (Main.GetPlayerMoney(player) < store_list[index].item_price)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Leider können Sie diesen Artikel nicht bezahlen.", 5000);
                            return;
                        }


                        if (Business.business_list[business_id].business_Inventory > 0)
                        {
                            Business.business_list[business_id].business_Safe += store_list[index].item_price;
                            Business.business_list[business_id].business_Inventory -= 1;
                            Business.SaveBusiness(business_id);
                            Business.UpdateBusinessLabel(business_id);
                        }
                        else
                        {
                            NAPI.Notification.SendNotificationToPlayer(player, "[" + Business.business_list[business_id].business_Name + "]:~w~ Unser Unternehmen hat momentan das nicht auf Lager, bitte kommen Sie später wieder!");
                            return;
                        }

                        Main.GivePlayerMoney(player, -store_list[index].item_price);
                        handelskammersteuer = Convert.ToInt32(System.Math.Ceiling(Convert.ToDouble(store_list[index].item_price) / Convert.ToDouble(100) * 19));
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Artikel: " + store_list[index].item_name + " Preis: $" + store_list[index].item_price + " Steuer: $" + handelskammersteuer + "", 5000);
                        cellphoneSystem.NewNumber(player);
                        break;
                    }
                case "Benzinkanister":
                    {
                        if (Main.GetPlayerMoney(player) < store_list[index].item_price)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Leider können Sie diesen Artikel nicht bezahlen.", 5000);
                            return;
                        }
                        if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 9, 1, Inventory.Max_Inventory_Weight(player)))
                        {
                            return;
                        }

                        if (Business.business_list[business_id].business_Inventory > 0)
                        {
                            Business.business_list[business_id].business_Safe += store_list[index].item_price;
                            Business.business_list[business_id].business_Inventory -= 1;
                            Business.SaveBusiness(business_id);
                            Business.UpdateBusinessLabel(business_id);
                        }
                        else
                        {
                            NAPI.Notification.SendNotificationToPlayer(player, "[" + Business.business_list[business_id].business_Name + "]:~w~ Unser Unternehmen hat momentan das nicht auf Lager, bitte kommen Sie später wieder!");
                            return;
                        }

                        Main.GivePlayerMoney(player, -store_list[index].item_price);
                        handelskammersteuer = Convert.ToInt32(System.Math.Ceiling(Convert.ToDouble(store_list[index].item_price) / Convert.ToDouble(100) * 19));
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Artikel: " + store_list[index].item_name + " Preis: $" + store_list[index].item_price + " Steuer: $" + handelskammersteuer + "", 5000);
                        Inventory.GiveItemToInventory(player, 46, 1);
                        break;
                    }
                case "Döner":
                    {
                        //NAPI.Util.ConsoleOutput("DEBUG ::: index " + index + "");
                        if (Main.GetPlayerMoney(player) < store_list[index].item_price)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Leider können Sie diesen Artikel nicht bezahlen.", 5000);
                            return;
                        }

                        if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 47, 1, Inventory.Max_Inventory_Weight(player)))
                        {
                            return;
                        }

                        //NAPI.Util.ConsoleOutput("DEBUG ::: index " + index + " -- " + Business.business_list[business_id].business_OwnerID + " --- " + Business.business_list[business_id].business_Inventory + "");


                        if (Business.business_list[business_id].business_Inventory > 0)
                        {
                            Business.business_list[business_id].business_Safe += store_list[index].item_price;
                            Business.business_list[business_id].business_Inventory -= 1;
                            Business.SaveBusiness(business_id);
                            Business.UpdateBusinessLabel(business_id);
                        }
                        else
                        {
                            NAPI.Notification.SendNotificationToPlayer(player, "[" + Business.business_list[business_id].business_Name + "]:~w~ Unser Unternehmen hat diesen Artikel nicht auf Lager, bitte kommen Sie später zurück !");
                            return;
                        }


                        Main.GivePlayerMoney(player, -store_list[index].item_price);
                        handelskammersteuer = Convert.ToInt32(System.Math.Ceiling(Convert.ToDouble(store_list[index].item_price) / Convert.ToDouble(100) * 19));
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Artikel: " + store_list[index].item_name + " Preis: $" + store_list[index].item_price + " Steuer: $" + handelskammersteuer + "", 5000);
                        Inventory.GiveItemToInventory(player, 47, 1);
                        break;
                    }
                case "Bockwurst":
                    {
                        //NAPI.Util.ConsoleOutput("DEBUG ::: index " + index + "");
                        if (Main.GetPlayerMoney(player) < store_list[index].item_price)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Leider können Sie diesen Artikel nicht bezahlen.", 5000);
                            return;
                        }

                        if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 48, 1, Inventory.Max_Inventory_Weight(player)))
                        {
                            return;
                        }

                        //NAPI.Util.ConsoleOutput("DEBUG ::: index " + index + " -- " + Business.business_list[business_id].business_OwnerID + " --- " + Business.business_list[business_id].business_Inventory + "");

                        if (Business.business_list[business_id].business_Inventory > 0)
                        {
                            Business.business_list[business_id].business_Safe += store_list[index].item_price;
                            Business.business_list[business_id].business_Inventory -= 1;
                            Business.SaveBusiness(business_id);
                            Business.UpdateBusinessLabel(business_id);
                        }
                        else
                        {
                            NAPI.Notification.SendNotificationToPlayer(player, "[" + Business.business_list[business_id].business_Name + "]:~w~ Unser Unternehmen hat diesen Artikel nicht auf Lager, bitte kommen Sie später zurück !");
                            return;
                        }

                        Main.GivePlayerMoney(player, -store_list[index].item_price);
                        handelskammersteuer = Convert.ToInt32(System.Math.Ceiling(Convert.ToDouble(store_list[index].item_price) / Convert.ToDouble(100) * 19));
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Artikel: " + store_list[index].item_name + " Preis: $" + store_list[index].item_price + " Steuer: $" + handelskammersteuer + "", 5000);
                        Inventory.GiveItemToInventory(player, 48, 1);
                        break;
                    }
                case "Cheese Burger":
                    {
                        //NAPI.Util.ConsoleOutput("DEBUG ::: index " + index + "");
                        if (Main.GetPlayerMoney(player) < store_list[index].item_price)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Leider können Sie diesen Artikel nicht bezahlen.", 5000);
                            return;
                        }

                        if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 49, 1, Inventory.Max_Inventory_Weight(player)))
                        {
                            return;
                        }

                        //NAPI.Util.ConsoleOutput("DEBUG ::: index " + index + " -- " + Business.business_list[business_id].business_OwnerID + " --- " + Business.business_list[business_id].business_Inventory + "");

                        if (Business.business_list[business_id].business_Inventory > 0)
                        {
                            Business.business_list[business_id].business_Safe += store_list[index].item_price;
                            Business.business_list[business_id].business_Inventory -= 1;
                            Business.SaveBusiness(business_id);
                            Business.UpdateBusinessLabel(business_id);
                        }
                        else
                        {
                            NAPI.Notification.SendNotificationToPlayer(player, "[" + Business.business_list[business_id].business_Name + "]:~w~ Unser Unternehmen hat diesen Artikel nicht auf Lager, bitte kommen Sie später zurück !");
                            return;
                        }

                        Main.GivePlayerMoney(player, -store_list[index].item_price);
                        handelskammersteuer = Convert.ToInt32(System.Math.Ceiling(Convert.ToDouble(store_list[index].item_price) / Convert.ToDouble(100) * 19));
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Artikel: " + store_list[index].item_name + " Preis: $" + store_list[index].item_price + " Steuer: $" + handelskammersteuer + "", 5000);
                        Inventory.GiveItemToInventory(player, 49, 1);
                        break;
                    }
                case "Bacon Burger":
                    {
                        //NAPI.Util.ConsoleOutput("DEBUG ::: index " + index + "");
                        if (Main.GetPlayerMoney(player) < store_list[index].item_price)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Leider können Sie diesen Artikel nicht bezahlen.", 5000);
                            return;
                        }

                        if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 50, 1, Inventory.Max_Inventory_Weight(player)))
                        {
                            return;
                        }

                        //NAPI.Util.ConsoleOutput("DEBUG ::: index " + index + " -- " + Business.business_list[business_id].business_OwnerID + " --- " + Business.business_list[business_id].business_Inventory + "");


                        if (Business.business_list[business_id].business_Inventory > 0)
                        {
                            Business.business_list[business_id].business_Safe += store_list[index].item_price;
                            Business.business_list[business_id].business_Inventory -= 1;
                            Business.SaveBusiness(business_id);
                            Business.UpdateBusinessLabel(business_id);
                        }
                        else
                        {
                            NAPI.Notification.SendNotificationToPlayer(player, "[" + Business.business_list[business_id].business_Name + "]:~w~ Unser Unternehmen hat diesen Artikel nicht auf Lager, bitte kommen Sie später zurück !");
                            return;
                        }

                        Main.GivePlayerMoney(player, -store_list[index].item_price);
                        handelskammersteuer = Convert.ToInt32(System.Math.Ceiling(Convert.ToDouble(store_list[index].item_price) / Convert.ToDouble(100) * 19));
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Artikel: " + store_list[index].item_name + " Preis: $" + store_list[index].item_price + " Steuer: $" + handelskammersteuer + "", 5000);
                        Inventory.GiveItemToInventory(player, 50, 1);
                        break;
                    }
                case "First Aid Kit":
                    {
                        //NAPI.Util.ConsoleOutput("DEBUG ::: index " + index + "");
                        if (Main.GetPlayerMoney(player) < store_list[index].item_price)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Leider können Sie diesen Artikel nicht bezahlen.", 5000);
                            return;
                        }

                        if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 55, 1, Inventory.Max_Inventory_Weight(player)))
                        {
                            return;
                        }

                        //NAPI.Util.ConsoleOutput("DEBUG ::: index " + index + " -- " + Business.business_list[business_id].business_OwnerID + " --- " + Business.business_list[business_id].business_Inventory + "");

                        if (Business.business_list[business_id].business_Inventory > 0)
                        {
                            Business.business_list[business_id].business_Safe += store_list[index].item_price;
                            Business.business_list[business_id].business_Inventory -= 1;
                            Business.SaveBusiness(business_id);
                            Business.UpdateBusinessLabel(business_id);
                        }
                        else
                        {
                            NAPI.Notification.SendNotificationToPlayer(player, "[" + Business.business_list[business_id].business_Name + "]:~w~ Unser Unternehmen hat diesen Artikel nicht auf Lager, bitte kommen Sie später zurück !");
                            return;
                        }


                        Main.GivePlayerMoney(player, -store_list[index].item_price);
                        handelskammersteuer = Convert.ToInt32(System.Math.Ceiling(Convert.ToDouble(store_list[index].item_price) / Convert.ToDouble(100) * 19));
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Artikel: " + store_list[index].item_name + " Preis: $" + store_list[index].item_price + " Steuer: $" + handelskammersteuer + "", 5000);
                        Inventory.GiveItemToInventory(player, 55, 1);
                        break;
                    }
                case "Öl Flasche":
                    {
                        //NAPI.Util.ConsoleOutput("DEBUG ::: index " + index + "");
                        if (Main.GetPlayerMoney(player) < store_list[index].item_price)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Leider können Sie diesen Artikel nicht bezahlen.", 5000);
                            return;
                        }

                        if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 58, 1, Inventory.Max_Inventory_Weight(player)))
                        {
                            return;
                        }

                        //NAPI.Util.ConsoleOutput("DEBUG ::: index " + index + " -- " + Business.business_list[business_id].business_OwnerID + " --- " + Business.business_list[business_id].business_Inventory + "");

                        if (Business.business_list[business_id].business_Inventory > 0)
                        {
                            Business.business_list[business_id].business_Safe += store_list[index].item_price;
                            Business.business_list[business_id].business_Inventory -= 1;
                            Business.SaveBusiness(business_id);
                            Business.UpdateBusinessLabel(business_id);
                        }
                        else
                        {
                            NAPI.Notification.SendNotificationToPlayer(player, "[" + Business.business_list[business_id].business_Name + "]:~w~ Unser Unternehmen hat diesen Artikel nicht auf Lager, bitte kommen Sie später zurück !");
                            return;
                        }


                        Main.GivePlayerMoney(player, -store_list[index].item_price);
                        handelskammersteuer = Convert.ToInt32(System.Math.Ceiling(Convert.ToDouble(store_list[index].item_price) / Convert.ToDouble(100) * 19));
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Artikel: " + store_list[index].item_name + " Preis: $" + store_list[index].item_price + " Steuer: $" + handelskammersteuer + "", 5000);
                        Inventory.GiveItemToInventory(player, 58, 1);
                        break;
                    }
                case "Champus":
                    {
                        if (Main.GetPlayerMoney(player) < store_list[index].item_price)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Leider können Sie diesen Artikel nicht bezahlen.", 5000);
                            return;
                        }
                        if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 1, 1, Inventory.Max_Inventory_Weight(player)))
                        {
                            return;
                        }

                        if (Business.business_list[business_id].business_Inventory > 0)
                        {
                            Business.business_list[business_id].business_Safe += store_list[index].item_price;
                            Business.business_list[business_id].business_Inventory -= 1;
                            Business.SaveBusiness(business_id);
                            Business.UpdateBusinessLabel(business_id);
                        }
                        else
                        {
                            NAPI.Notification.SendNotificationToPlayer(player, "[" + Business.business_list[business_id].business_Name + "]:~w~ Unser Unternehmen ist momentan nicht auf Lager, bitte kommen Sie später zurück!");
                            return;
                        }

                        Main.GivePlayerMoney(player, -store_list[index].item_price);
                        handelskammersteuer = Convert.ToInt32(System.Math.Ceiling(Convert.ToDouble(store_list[index].item_price) / Convert.ToDouble(100) * 19));
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Artikel: " + store_list[index].item_name + " Preis: $" + store_list[index].item_price + " Steuer: $" + handelskammersteuer + "", 5000);
                        Inventory.GiveItemToInventory(player, 74, 1);
                        break;
                    }
                case "Snickers":
                    {
                        //NAPI.Util.ConsoleOutput("DEBUG ::: index " + index + "");
                        if (Main.GetPlayerMoney(player) < store_list[index].item_price)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Leider können Sie diesen Artikel nicht bezahlen.", 5000);
                            return;
                        }

                        if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 2, 1, Inventory.Max_Inventory_Weight(player)))
                        {
                            return;
                        }

                        //NAPI.Util.ConsoleOutput("DEBUG ::: index " + index + " -- " + Business.business_list[business_id].business_OwnerID + " --- " + Business.business_list[business_id].business_Inventory + "");


                        if (Business.business_list[business_id].business_Inventory > 0)
                        {
                            Business.business_list[business_id].business_Safe += store_list[index].item_price;
                            Business.business_list[business_id].business_Inventory -= 1;
                            Business.SaveBusiness(business_id);
                            Business.UpdateBusinessLabel(business_id);
                        }
                        else
                        {
                            NAPI.Notification.SendNotificationToPlayer(player, "[" + Business.business_list[business_id].business_Name + "]:~w~ Unser Unternehmen hat diesen Artikel nicht auf Lager, bitte kommen Sie später zurück !");
                            return;
                        }

                        Main.GivePlayerMoney(player, -store_list[index].item_price);
                        handelskammersteuer = Convert.ToInt32(System.Math.Ceiling(Convert.ToDouble(store_list[index].item_price) / Convert.ToDouble(100) * 19));
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Artikel: " + store_list[index].item_name + " Preis: $" + store_list[index].item_price + " Steuer: $" + handelskammersteuer + "", 5000);
                        Inventory.GiveItemToInventory(player, 94, 1);
                        break;
                    }
                case "Mars":
                    {
                        //NAPI.Util.ConsoleOutput("DEBUG ::: index " + index + "");
                        if (Main.GetPlayerMoney(player) < store_list[index].item_price)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Leider können Sie diesen Artikel nicht bezahlen.", 5000);
                            return;
                        }

                        if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 2, 1, Inventory.Max_Inventory_Weight(player)))
                        {
                            return;
                        }

                        //NAPI.Util.ConsoleOutput("DEBUG ::: index " + index + " -- " + Business.business_list[business_id].business_OwnerID + " --- " + Business.business_list[business_id].business_Inventory + "");


                        if (Business.business_list[business_id].business_Inventory > 0)
                        {
                            Business.business_list[business_id].business_Safe += store_list[index].item_price;
                            Business.business_list[business_id].business_Inventory -= 1;
                            Business.SaveBusiness(business_id);
                            Business.UpdateBusinessLabel(business_id);
                        }
                        else
                        {
                            NAPI.Notification.SendNotificationToPlayer(player, "[" + Business.business_list[business_id].business_Name + "]:~w~ Unser Unternehmen hat diesen Artikel nicht auf Lager, bitte kommen Sie später zurück !");
                            return;
                        }

                        Main.GivePlayerMoney(player, -store_list[index].item_price);
                        handelskammersteuer = Convert.ToInt32(System.Math.Ceiling(Convert.ToDouble(store_list[index].item_price) / Convert.ToDouble(100) * 19));
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Artikel: " + store_list[index].item_name + " Preis: $" + store_list[index].item_price + " Steuer: $" + handelskammersteuer + "", 5000);
                        Inventory.GiveItemToInventory(player, 95, 1);
                        break;
                    }
                case "Schokolade":
                    {
                        //NAPI.Util.ConsoleOutput("DEBUG ::: index " + index + "");
                        if (Main.GetPlayerMoney(player) < store_list[index].item_price)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Leider können Sie diesen Artikel nicht bezahlen.", 5000);
                            return;
                        }

                        if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 2, 1, Inventory.Max_Inventory_Weight(player)))
                        {
                            return;
                        }

                        //NAPI.Util.ConsoleOutput("DEBUG ::: index " + index + " -- " + Business.business_list[business_id].business_OwnerID + " --- " + Business.business_list[business_id].business_Inventory + "");


                        if (Business.business_list[business_id].business_Inventory > 0)
                        {
                            Business.business_list[business_id].business_Safe += store_list[index].item_price;
                            Business.business_list[business_id].business_Inventory -= 1;
                            Business.SaveBusiness(business_id);
                            Business.UpdateBusinessLabel(business_id);
                        }
                        else
                        {
                            NAPI.Notification.SendNotificationToPlayer(player, "[" + Business.business_list[business_id].business_Name + "]:~w~ Unser Unternehmen hat diesen Artikel nicht auf Lager, bitte kommen Sie später zurück !");
                            return;
                        }

                        Main.GivePlayerMoney(player, -store_list[index].item_price);
                        handelskammersteuer = Convert.ToInt32(System.Math.Ceiling(Convert.ToDouble(store_list[index].item_price) / Convert.ToDouble(100) * 19));
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Artikel: " + store_list[index].item_name + " Preis: $" + store_list[index].item_price + " Steuer: $" + handelskammersteuer + "", 5000);
                        Inventory.GiveItemToInventory(player, 96, 1);
                        break;
                    }
                case "Chips":
                    {
                        //NAPI.Util.ConsoleOutput("DEBUG ::: index " + index + "");
                        if (Main.GetPlayerMoney(player) < store_list[index].item_price)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Leider können Sie diesen Artikel nicht bezahlen.", 5000);
                            return;
                        }

                        if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 2, 1, Inventory.Max_Inventory_Weight(player)))
                        {
                            return;
                        }

                        //NAPI.Util.ConsoleOutput("DEBUG ::: index " + index + " -- " + Business.business_list[business_id].business_OwnerID + " --- " + Business.business_list[business_id].business_Inventory + "");


                        if (Business.business_list[business_id].business_Inventory > 0)
                        {
                            Business.business_list[business_id].business_Safe += store_list[index].item_price;
                            Business.business_list[business_id].business_Inventory -= 1;
                            Business.SaveBusiness(business_id);
                            Business.UpdateBusinessLabel(business_id);
                        }
                        else
                        {
                            NAPI.Notification.SendNotificationToPlayer(player, "[" + Business.business_list[business_id].business_Name + "]:~w~ Unser Unternehmen hat diesen Artikel nicht auf Lager, bitte kommen Sie später zurück !");
                            return;
                        }

                        Main.GivePlayerMoney(player, -store_list[index].item_price);
                        handelskammersteuer = Convert.ToInt32(System.Math.Ceiling(Convert.ToDouble(store_list[index].item_price) / Convert.ToDouble(100) * 19));
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Artikel: " + store_list[index].item_name + " Preis: $" + store_list[index].item_price + " Steuer: $" + handelskammersteuer + "", 5000);
                        Inventory.GiveItemToInventory(player, 97, 1);
                        break;
                    }
                case "Flips":
                    {
                        //NAPI.Util.ConsoleOutput("DEBUG ::: index " + index + "");
                        if (Main.GetPlayerMoney(player) < store_list[index].item_price)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Leider können Sie diesen Artikel nicht bezahlen.", 5000);
                            return;
                        }

                        if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 2, 1, Inventory.Max_Inventory_Weight(player)))
                        {
                            return;
                        }

                        //NAPI.Util.ConsoleOutput("DEBUG ::: index " + index + " -- " + Business.business_list[business_id].business_OwnerID + " --- " + Business.business_list[business_id].business_Inventory + "");


                        if (Business.business_list[business_id].business_Inventory > 0)
                        {
                            Business.business_list[business_id].business_Safe += store_list[index].item_price;
                            Business.business_list[business_id].business_Inventory -= 1;
                            Business.SaveBusiness(business_id);
                            Business.UpdateBusinessLabel(business_id);
                        }
                        else
                        {
                            NAPI.Notification.SendNotificationToPlayer(player, "[" + Business.business_list[business_id].business_Name + "]:~w~ Unser Unternehmen hat diesen Artikel nicht auf Lager, bitte kommen Sie später zurück !");
                            return;
                        }

                        Main.GivePlayerMoney(player, -store_list[index].item_price);
                        handelskammersteuer = Convert.ToInt32(System.Math.Ceiling(Convert.ToDouble(store_list[index].item_price) / Convert.ToDouble(100) * 19));
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Artikel: " + store_list[index].item_name + " Preis: $" + store_list[index].item_price + " Steuer: $" + handelskammersteuer + "", 5000);
                        Inventory.GiveItemToInventory(player, 98, 1);
                        break;
                    }

            }
        }
    }
}