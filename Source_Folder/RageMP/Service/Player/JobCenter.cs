using System;
using System.Collections.Generic;
using GTANetworkAPI;
using Newtonsoft.Json;
using DerStr1k3r.Core;
using DerStr1k3r.SDK;

class JobCenter : Script
{
    private static List<dynamic> hartz_beantragung = new List<dynamic>();
    public static int PRICE_KFZPLATE = 50;
    public static int PRICE_KFZPLATE2 = 25;
    public static List<dynamic> kfz = new List<dynamic>();

    public JobCenter()
    {}

    public static void OnPlayerConnected(Client player)
    {
        hartz_beantragung.Add(new { position = new Vector3(248.6638, -1596.327, 31.53196) });

        foreach (var JobCenter_beantragung in hartz_beantragung)
        {
            ColShape hartz_beantragung = NAPI.ColShape.CreateSphereColShape(JobCenter_beantragung.position, 1f);
            NAPI.Marker.CreateMarker(27, JobCenter_beantragung.position - new Vector3(0, 0, 0.8f), new Vector3(), new Vector3(), 1.0f, new Color(255, 255, 255, 110), false, 0);
        }
    }

    public static void PlayerPressKeyE(Client player)
    {
        if (Main.IsInRangeOfPoint(player.Position, new Vector3(248.6638, -1596.327, 31.53196), 1.0f))
        {
            int playerid = Main.getIdFromClient(player);
            List<dynamic> menu_item_list = new List<dynamic>();

            menu_item_list.Add(new { Type = 1, Name = "Hartz V beantragen", Description = "Hiermit kannst du dein Hartz V beantragen.", RightLabel = "$" + JobCenter.PRICE_KFZPLATE.ToString() + "" });
            menu_item_list.Add(new { Type = 1, Name = "Hartz V abmelden", Description = "Hiermit kannst du dein Hartz V abmelden.", RightLabel = "$" + JobCenter.PRICE_KFZPLATE2.ToString() + "" });
            InteractMenu.CreateMenu(player, "NEW_MENU_JOB_CENTER_REPONSE", "LS Job Center", "~g~Staatliche Hilfe:", false, JsonConvert.SerializeObject(menu_item_list), false, BackgroundColor: "Green");
        }
    }

    public static void SelectMenuResponse(Client player, String callbackId, int selectedIndex, String objectName, String valueList)
    {
        if (callbackId == "NEW_MENU_JOB_CENTER_REPONSE")
        {
            if (selectedIndex == 0)
            {
                if (Main.IsInRangeOfPoint(player.Position, new Vector3(248.6638, -1596.327, 31.53196), 3.0f))
                {
                    if (player.GetData("character_job_center_status") != 0)
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"Du hast schon die Staatliche Hilfe beantragt!", 5000);
                        return;
                    }

                    player.SetData("character_job_center_status", 1);
                    Main.GivePlayerMoney(player, -PRICE_KFZPLATE);
                    AccountManage.SaveCharacter(player);
                    Notify.Send(player, NotifyType.Success, NotifyPosition.BottomCenter, $"Dein Antrag für die Staatliche Hilfe wurde bewilligt.", 5000);
                }
            }
            else if (selectedIndex == 1)
            {
                if (Main.IsInRangeOfPoint(player.Position, new Vector3(248.6638, -1596.327, 31.53196), 3.0f))
                {
                    if (player.GetData("character_job_center_status") != 1)
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"Du hast schon die Staatliche Hilfe abgemeldet!", 5000);
                        return;
                    }
                    player.SetData("character_job_center_status", 0);
                    Main.GivePlayerMoney(player, -PRICE_KFZPLATE2);
                    AccountManage.SaveCharacter(player);
                    Notify.Send(player, NotifyType.Success, NotifyPosition.BottomCenter, $"Dein Staatliche Hilfe wurde abgemeldet.", 5000);
                }
            }
        }
    }
}
