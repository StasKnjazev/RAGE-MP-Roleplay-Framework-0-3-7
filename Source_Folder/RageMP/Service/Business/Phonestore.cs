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

class PhoneStore : Script
{
    public static List<dynamic> phonestore_list = new List<dynamic>();

    public static dynamic handelskammersteuer { get; set; }

    public static void PhoneStoreInit()
    {
        phonestore_list.Add(new { item_name = "Snomia", item_price = 149 });
        phonestore_list.Add(new { item_name = "Sumsumg", item_price = 349 });
        phonestore_list.Add(new { item_name = "Bpple", item_price = 449 });
        phonestore_list.Add(new { item_name = "Quawei", item_price = 549 });
    }

    public static void ShowPhoneStoreMenu(Client player)
    {
        int business_id = Business.GetPlayerInBusinessInType(player, 13);
        if (business_id == -1)
        {
            Main.DisplayErrorMessage(player, "Sie befinden sich nicht in einer Firma.");
            return;
        }
        List<dynamic> menu_item_list = new List<dynamic>();
        foreach (var phonestore in phonestore_list)
        {
            menu_item_list.Add(new { Type = 1, Name = phonestore.item_name, Description = "", RightLabel = "~g~$~w~" + phonestore.item_price });
        }
        InteractMenu.CreateMenu(player, "BUSINESS_PHONE_STORE", "IDNet", "~b~" + Business.business_list[business_id].business_Name, true, JsonConvert.SerializeObject(menu_item_list), false);
    }

    public static void SelectMenuResponse(Client player, String callbackId, int selectedIndex, String objectName, String valueList)
    {
        if (callbackId == "BUSINESS_PHONE_STORE")
        {
            string item = objectName;
            int index = selectedIndex;
            int business_id = Business.GetPlayerInBusinessInType(player, 13);
            if (business_id == -1)
            {
                return;
            }
            switch (item)
            {
                case "Snomia":
                    {
                        if (Main.GetPlayerMoney(player) < phonestore_list[index].item_price)
                        {
                            NAPI.Notification.SendNotificationToPlayer(player, "ERROR:~w~ Leider können Sie diesen Artikel nicht bezahlen.");
                            return;
                        }

                        if (Business.business_list[business_id].business_Inventory > 0)
                        {
                            Business.business_list[business_id].business_Safe += phonestore_list[index].item_price;
                            Business.business_list[business_id].business_Inventory -= 1;
                            Business.SaveBusiness(business_id);
                            Business.UpdateBusinessLabel(business_id);
                        }
                        else
                        {
                            NAPI.Notification.SendNotificationToPlayer(player, "[" + Business.business_list[business_id].business_Name + "]:~w~ Unser Unternehmen hat momentan das nicht auf Lager, bitte kommen Sie später wieder!");
                            return;
                        }

                        Main.GivePlayerMoney(player, -phonestore_list[index].item_price);
                        handelskammersteuer = Convert.ToInt32(System.Math.Ceiling(Convert.ToDouble(phonestore_list[index].item_price) / Convert.ToDouble(100) * 19));
                        NAPI.Notification.SendNotificationToPlayer(player, "Artikel: ~y~" + phonestore_list[index].item_name + " \n Kosten: ~g~$" + phonestore_list[index].item_price + " \n ~w~Steuer: ~g~$~y~" + handelskammersteuer + "");
                        cellphoneSystem.NewNumber(player);
                        break;
                    }
                case "Sumsumg":
                    {
                        if (Main.GetPlayerMoney(player) < phonestore_list[index].item_price)
                        {
                            NAPI.Notification.SendNotificationToPlayer(player, "ERROR:~w~ Leider können Sie diesen Artikel nicht bezahlen.");
                            return;
                        }

                        if (Business.business_list[business_id].business_Inventory > 0)
                        {
                            Business.business_list[business_id].business_Safe += phonestore_list[index].item_price;
                            Business.business_list[business_id].business_Inventory -= 1;
                            Business.SaveBusiness(business_id);
                            Business.UpdateBusinessLabel(business_id);
                        }
                        else
                        {
                            NAPI.Notification.SendNotificationToPlayer(player, "[" + Business.business_list[business_id].business_Name + "]:~w~ Unser Unternehmen hat momentan das nicht auf Lager, bitte kommen Sie später wieder!");
                            return;
                        }

                        Main.GivePlayerMoney(player, -phonestore_list[index].item_price);
                        handelskammersteuer = Convert.ToInt32(System.Math.Ceiling(Convert.ToDouble(phonestore_list[index].item_price) / Convert.ToDouble(100) * 19));
                        NAPI.Notification.SendNotificationToPlayer(player, "Artikel: ~y~" + phonestore_list[index].item_name + " \n Kosten: ~g~$" + phonestore_list[index].item_price + " \n ~w~Steuer: ~g~$~y~" + handelskammersteuer + "");
                        cellphoneSystem.NewNumber(player);
                        break;
                    }
                case "Bpple":
                    {
                        if (Main.GetPlayerMoney(player) < phonestore_list[index].item_price)
                        {
                            NAPI.Notification.SendNotificationToPlayer(player, "ERROR:~w~ Leider können Sie diesen Artikel nicht bezahlen.");
                            return;
                        }

                        if (Business.business_list[business_id].business_Inventory > 0)
                        {
                            Business.business_list[business_id].business_Safe += phonestore_list[index].item_price;
                            Business.business_list[business_id].business_Inventory -= 1;
                            Business.SaveBusiness(business_id);
                            Business.UpdateBusinessLabel(business_id);
                        }
                        else
                        {
                            NAPI.Notification.SendNotificationToPlayer(player, "[" + Business.business_list[business_id].business_Name + "]:~w~ Unser Unternehmen hat momentan das nicht auf Lager, bitte kommen Sie später wieder!");
                            return;
                        }

                        Main.GivePlayerMoney(player, -phonestore_list[index].item_price);
                        handelskammersteuer = Convert.ToInt32(System.Math.Ceiling(Convert.ToDouble(phonestore_list[index].item_price) / Convert.ToDouble(100) * 19));
                        NAPI.Notification.SendNotificationToPlayer(player, "Artikel: ~y~" + phonestore_list[index].item_name + " \n Kosten: ~g~$" + phonestore_list[index].item_price + " \n ~w~Steuer: ~g~$~y~" + handelskammersteuer + "");
                        cellphoneSystem.NewNumber(player);
                        break;
                    }
                case "Quawei":
                    {
                        if (Main.GetPlayerMoney(player) < phonestore_list[index].item_price)
                        {
                            NAPI.Notification.SendNotificationToPlayer(player, "ERROR:~w~ Leider können Sie diesen Artikel nicht bezahlen.");
                            return;
                        }

                        if (Business.business_list[business_id].business_Inventory > 0)
                        {
                            Business.business_list[business_id].business_Safe += phonestore_list[index].item_price;
                            Business.business_list[business_id].business_Inventory -= 1;
                            Business.SaveBusiness(business_id);
                            Business.UpdateBusinessLabel(business_id);
                        }
                        else
                        {
                            NAPI.Notification.SendNotificationToPlayer(player, "[" + Business.business_list[business_id].business_Name + "]:~w~ Unser Unternehmen hat momentan das nicht auf Lager, bitte kommen Sie später wieder!");
                            return;
                        }

                        Main.GivePlayerMoney(player, -phonestore_list[index].item_price);
                        handelskammersteuer = Convert.ToInt32(System.Math.Ceiling(Convert.ToDouble(phonestore_list[index].item_price) / Convert.ToDouble(100) * 19));
                        NAPI.Notification.SendNotificationToPlayer(player, "Artikel: ~y~" + phonestore_list[index].item_name + " \n Kosten: ~g~$" + phonestore_list[index].item_price + " \n ~w~Steuer: ~g~$~y~" + handelskammersteuer + "");
                        cellphoneSystem.NewNumber(player);
                        break;
                    }

            }
        }
    }
}