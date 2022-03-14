using System;
using System.Collections.Generic;
using GTANetworkAPI;
using Newtonsoft.Json;
using DerStr1k3r.Core;
using DerStr1k3r.SDK;

class LOrder : Script
{
    private static List<dynamic> lorder_adding = new List<dynamic>();
    public static int PRICE_KFZPLATE = 15000;
    public static int PRICE_KFZPLATE2 = 25000;
    public static List<dynamic> kfz = new List<dynamic>();

    public LOrder()
    {}

    public static void OnPlayerConnected(Client player)
    {
        lorder_adding.Add(new { position = new Vector3(-2305.173, 309.3862, 169.6068) });

        foreach (var lorder_adding_pos in lorder_adding)
        {
            player.TriggerEvent("Sync_PedCreate", "lorder_pos", NAPI.Util.PedNameToModel("AntonB"), new Vector3(-2305.173, 309.3862, 169.6068), 106.3153f, "", 0);
        }
    }

    public static void PlayerPressKeyE(Client player)
    {
        if (Main.IsInRangeOfPoint(player.Position, new Vector3(-2305.173, 309.3862, 169.6068), 3.0f))
        {
            int playerid = Main.getIdFromClient(player);
            List<dynamic> menu_item_list = new List<dynamic>();

            menu_item_list.Add(new { Type = 1, Name = "Buch der Pflanzen", Description = "Wofür das wohl gut ist.", RightLabel = "$" + LOrder.PRICE_KFZPLATE.ToString() + "" });
            menu_item_list.Add(new { Type = 1, Name = "Buch der Chemie", Description = "Wofür das wohl gut ist.", RightLabel = "$" + LOrder.PRICE_KFZPLATE2.ToString() + "" });
            InteractMenu.CreateMenu(player, "NEW_MENU_LICENSE_ORDERING_REPONSE", "Anton der Weise", "~g~Es gibt immer schöne Sachen:", false, JsonConvert.SerializeObject(menu_item_list), false, BackgroundColor: "Green");
        }
    }

    public static void SelectMenuResponse(Client player, String callbackId, int selectedIndex, String objectName, String valueList)
    {
        if (callbackId == "NEW_MENU_LICENSE_ORDERING_REPONSE")
        {
            if (selectedIndex == 0)
            {
                if (Main.IsInRangeOfPoint(player.Position, new Vector3(-2305.173, 309.3862, 169.6068), 3.0f))
                {
                    if (player.GetData("character_licence_illegal_ordering_1") != 0)
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"Du hast schon das Buch der Pflanzen erlernt!", 5000);
                        return;
                    }

                    player.SetData("character_licence_illegal_ordering_1", 1);
                    Main.GivePlayerMoney(player, -PRICE_KFZPLATE);
                    AccountManage.SaveCharacter(player);
                    Notify.Send(player, NotifyType.Success, NotifyPosition.BottomCenter, $"Du hast das Buch der Pflanzen erlernt.", 5000);
                }
            }
            else if (selectedIndex == 1)
            {
                if (Main.IsInRangeOfPoint(player.Position, new Vector3(-2305.173, 309.3862, 169.6068), 3.0f))
                {
                    if (player.GetData("character_licence_illegal_ordering_2") != 0)
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"Du hast schon das Buch der Chemie erlernt!", 5000);
                        return;
                    }

                    player.SetData("character_licence_illegal_ordering_2", 1);
                    Main.GivePlayerMoney(player, -PRICE_KFZPLATE2);
                    AccountManage.SaveCharacter(player);
                    Notify.Send(player, NotifyType.Success, NotifyPosition.BottomCenter, $"Du hast das Buch der Chemie erlernt.", 5000);
                }
            }
        }
    }
}
