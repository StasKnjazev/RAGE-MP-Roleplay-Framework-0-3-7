using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;
using Newtonsoft.Json;
using DerStr1k3r.Core;
using DerStr1k3r.SDK;

class Schlüsseldienst : Script
{
    public static List<TimerEx> sal_timer = new List<TimerEx>();
    private static List<dynamic> kfz_zulassung = new List<dynamic>();
    public static int PRICE_KFZPLATE = 450;
    public static int PRICE_KFZPLATE2 = 850;

    public static void OnPlayerConnected(Client player)
    {
        kfz_zulassung.Add(new { position = new Vector3(331.7356, -1563.089, 30.311596) });

        foreach (var Veh_Zulassung in kfz_zulassung)
        {
            ColShape kfz_zulassung = NAPI.ColShape.CreateSphereColShape(Veh_Zulassung.position, 1f);
            NAPI.Marker.CreateMarker(27, Veh_Zulassung.position - new Vector3(0, 0, 0.8f), new Vector3(), new Vector3(), 1.0f, new Color(255, 255, 255, 110), false, 0);
        }

        for (var i = 0; i < Main.MAX_PLAYERS; i++)
        {
            sal_timer.Add(null);
        }

        player.SetData("SCHDienst_Refinando", false);
        player.SetData("Sal", 20);
        player.SetData("SCHDienst_RefinandoTime", 0);
    }

    public static void PressKeyE(Client player)
    {
        if (Main.IsInRangeOfPoint(player.Position, new Vector3(331.7356, -1563.089, 30.311596), 1.0f))
        {
            int playerid = Main.getIdFromClient(player);
            List<dynamic> menu_item_list = new List<dynamic>();

            menu_item_list.Add(new { Type = 1, Name = "Schlüssel fürs Fahrzeug", Description = "Hiermit lässt du für dein Fahrzeug neue Schlüssel anfertigen.", RightLabel = "$" + PRICE_KFZPLATE.ToString() + "" });
            menu_item_list.Add(new { Type = 1, Name = "Schlüssel fürs Haus", Description = "Hiermit lässt du für dein Haus neue Schlüssel anfertigen.", RightLabel = "$" + PRICE_KFZPLATE2.ToString() + "" });
            InteractMenu.CreateMenu(player, "NEW_MENU_SCHLÜSSELDIENST_RESPONSE", "Schlüsseldienst", "~g~Schlüssel nach machen:", false, JsonConvert.SerializeObject(menu_item_list), false, BackgroundColor: "Green");
        }
    }

    public static void SelectMenuResponse(Client player, String callbackId, int selectedIndex, String objectName, String valueList)
    {
        if (callbackId == "NEW_MENU_SCHLÜSSELDIENST_RESPONSE")
        {
            if (selectedIndex == 0)
            {
                if (Main.IsInRangeOfPoint(player.Position, new Vector3(331.7356, -1563.089, 30.311596), 2f))
                {
                    if (player.GetData("SCHDienst_Refinando") == false)
                    {
                        if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 157, 1, Inventory.Max_Inventory_Weight(player)) == true)
                        {
                            return;
                        }
                        //
                        int schdienst_a_ser_refinados = 0;

                        player.SetData("SCHDienst_Refinando", true);
                        player.SetData("SCHDienst_RefinandoTime", 4);

                        player.TriggerEvent("freezeEx", true);
                        player.PlayScenario("WORLD_HUMAN_GUARD_STAND");

                        NAPI.ClientEvent.TriggerClientEvent(player, "SetProgressBar", player.GetData("SCHDienst_RefinandoTime"), "Fahrzeug Schlüssel wird erstellt - " + schdienst_a_ser_refinados + "");

                        Schlüsseldienst.sal_timer[Main.getIdFromClient(player)] = TimerEx.SetTimer(() =>
                        {
                            //
                            if (PlayerVehicle.GetPlayerVehicleCount(player) >= 1)
                            {
                                // 
                                player.SetData("SCHDienst_RefinandoTime", player.GetData("SCHDienst_RefinandoTime") + 4);
                                NAPI.ClientEvent.TriggerClientEvent(player, "SetProgressBar", player.GetData("SCHDienst_RefinandoTime"), "Fahrzeug Schlüssel wird erstellt - " + schdienst_a_ser_refinados + "");

                                if (player.GetData("SCHDienst_RefinandoTime") > 100)
                                {
                                    //
                                    schdienst_a_ser_refinados += 1;
                                    // Remove o Sal e conta tudo novamente.
                                    Inventory.GiveItemToInventory(player, 157, 1);

                                    player.SetData("SCHDienst_RefinandoTime", 0);
                                    NAPI.ClientEvent.TriggerClientEvent(player, "SetProgressBar", player.GetData("SCHDienst_RefinandoTime"), "Fahrzeug Schlüssel wird erstellt - " + schdienst_a_ser_refinados + "");

                                    NAPI.Notification.SendNotificationToPlayer(player, "1x Fahrzeug Schlüssel erhalten!");
                                    Main.GivePlayerMoney(player, -PRICE_KFZPLATE);
                                    if (PlayerVehicle.GetPlayerVehicleCount(player) == 1)
                                    {
                                        if (Schlüsseldienst.sal_timer[Main.getIdFromClient(player)] != null)
                                        {
                                            Schlüsseldienst.sal_timer[Main.getIdFromClient(player)].Kill();
                                            Schlüsseldienst.sal_timer[Main.getIdFromClient(player)] = null;
                                        }
                                        player.StopAnimation();
                                        player.SetData("SCHDienst_Refinando", false);
                                        player.TriggerEvent("freezeEx", false);
                                        player.TriggerEvent("DestroyProgressBar");
                                    }
                                }
                            }
                            else
                            {
                                //
                                if (player.GetData("SCHDienst_Refinando") == true)
                                {
                                    if (Schlüsseldienst.sal_timer[Main.getIdFromClient(player)] != null)
                                    {
                                        Schlüsseldienst.sal_timer[Main.getIdFromClient(player)].Kill();
                                        Schlüsseldienst.sal_timer[Main.getIdFromClient(player)] = null;
                                    }
                                    player.StopAnimation();
                                    player.SetData("SCHDienst_Refinando", false);
                                    player.TriggerEvent("freezeEx", false);
                                    player.TriggerEvent("DestroyProgressBar");
                                }
                            }
                            if (player.GetData("status") == false)
                            {
                                try
                                {
                                    Schlüsseldienst.sal_timer[Main.getIdFromClient(player)].Kill();
                                    Schlüsseldienst.sal_timer[Main.getIdFromClient(player)] = null;
                                }
                                catch (Exception)
                                {

                                }
                            }
                        }, 10000, 0);
                    }
                    else if (player.GetData("SCHDienst_Refinando") == true)
                    {
                        if (Schlüsseldienst.sal_timer[Main.getIdFromClient(player)] != null)
                        {
                            Schlüsseldienst.sal_timer[Main.getIdFromClient(player)].Kill();
                            Schlüsseldienst.sal_timer[Main.getIdFromClient(player)] = null;
                        }
                        player.StopAnimation();
                        player.SetData("SCHDienst_Refinando", false);
                        player.TriggerEvent("freezeEx", false);
                        player.TriggerEvent("DestroyProgressBar");
                    }
                }
            }
            else if (selectedIndex == 1)
            {
                if (Main.IsInRangeOfPoint(player.Position, new Vector3(331.7356, -1563.089, 30.311596), 3.0f))
                {
                    Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Momentan nicht möglich!", 5000);
                }
            }
        }
    }
}

