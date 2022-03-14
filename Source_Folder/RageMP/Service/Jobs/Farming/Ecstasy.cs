using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;
using DerStr1k3r.SDK;
using DerStr1k3r.Core;

class Ecstasy : Script
{
    private static nLog Log = new nLog("Ecstasy");

    private static List<dynamic> ecstasy_positions = new List<dynamic>();
    public static List<TimerEx> sal_timer = new List<TimerEx>();

    public static void EcstasyInit()
    {
        for (var i = 0; i < Main.MAX_PLAYERS; i++)
        {
            sal_timer.Add(null);
        }
    }

    [Command("ro2")]
    public void removeob2(Client player)
    {
        player.TriggerEvent("remoooo");
    }

    public static void OnPlayerConnect(Client player)
    {
        try
        {
            player.SetData("Ecstasy_Refinando", false);
            player.SetData("Sal", 20);
            player.SetData("Ecstasy_RefinandoTime", 0);
            player.TriggerEvent("Sync_PedCreate", "ecstasy_refinar", NAPI.Util.PedNameToModel("KTown01AMO"), new Vector3(2186.55, 3490.092, 45.42768), 215.0529f, "", 0);
        }
        catch (Exception e)
        {
            Log.Write("ResourceStart: " + e.Message, nLog.Type.Error);
        }
    }

    public static void PressKeyY(Client player)
    {
        try
        {
            if (Main.IsInRangeOfPoint(player.Position, new Vector3(2186.55, 3490.092, 45.42768), 3f))
            {
                if (Inventory.GetPlayerItemFromInventory(player, 14) >= 2 && player.GetData("Ecstasy_Refinando") == false)
                {
                    if (player.GetData("character_licence_illegal_ordering_2") != 1)
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"Du hast das Buch der Chemie nicht!", 5000);
                        return;
                    }
                    if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 61, 1, Inventory.Max_Inventory_Weight(player)) == true)
                    {
                        return;
                    }
                //
                    int ecstasy = Inventory.GetPlayerItemFromInventory(player, 14);
                    int ecstasy_a_ser_refinados = 0;
                    player.SetData("Ecstasy_Refinando", true);
                    player.SetData("Ecstasy_RefinandoTime", 10);
                    player.TriggerEvent("freezeEx", true);
                    player.PlayScenario("WORLD_HUMAN_GUARD_STAND");

                    NAPI.ClientEvent.TriggerClientEvent(player, "SetProgressBar", player.GetData("Ecstasy_RefinandoTime"), "Verarbeite Salz - " + ecstasy_a_ser_refinados + " von " + ecstasy + " zu Ecstasy");

                    Ecstasy.sal_timer[Main.getIdFromClient(player)] = TimerEx.SetTimer(() =>
                    {
                    //
                        if (Inventory.GetPlayerItemFromInventory(player,14) >= 2)
                        {
                        // 
                            player.SetData("Ecstasy_RefinandoTime", player.GetData("Ecstasy_RefinandoTime") + 10);
                            NAPI.ClientEvent.TriggerClientEvent(player, "SetProgressBar", player.GetData("Ecstasy_RefinandoTime"), "Verarbeite Salz - " + ecstasy_a_ser_refinados + " von " + ecstasy + " zu Ecstasy");

                            if (player.GetData("Ecstasy_RefinandoTime") > 100)
                            {
                            //
                                ecstasy_a_ser_refinados += 2;
                                Inventory.RemoveItemByType(player, 14, 2);
                                //Inventory.RemoveItem(player, "Salz", 2);
                                Inventory.GiveItemToInventory(player, 61, 1);

                                NAPI.Util.ConsoleOutput("[GET JOB Ecstasy] " + player.SocialClubName + " hat #verarbeitet");

                            //
                                player.SetData("Ecstasy_RefinandoTime", 0);
                                NAPI.ClientEvent.TriggerClientEvent(player, "SetProgressBar", player.GetData("Ecstasy_RefinandoTime"), "Verarbeite Salz - " + ecstasy_a_ser_refinados + " von " + ecstasy + " zu Ecstasy");
                                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"1x Ecstasy erhalten!", 5000);
                                //NAPI.Notification.SendNotificationToPlayer(player, "~g~+~w~ 1x Ecstasy erhalten!");

                            //
                                if (Inventory.GetPlayerItemFromInventory(player, 14) == 0)
                                {
                                    if (Ecstasy.sal_timer[Main.getIdFromClient(player)] != null)
                                    {
                                        Ecstasy.sal_timer[Main.getIdFromClient(player)].Kill();
                                        Ecstasy.sal_timer[Main.getIdFromClient(player)] = null;
                                    }
                                    player.SetData("Ecstasy_Refinando", false);
                                    player.TriggerEvent("freezeEx", false);
                                    player.TriggerEvent("DestroyProgressBar");
                                }
                            }
                        }
                        else
                        {
                        //
                            if (player.GetData("Ecstasy_Refinando") == true)
                            {
                                if (Ecstasy.sal_timer[Main.getIdFromClient(player)] != null)
                                {
                                    Ecstasy.sal_timer[Main.getIdFromClient(player)].Kill();
                                    Ecstasy.sal_timer[Main.getIdFromClient(player)] = null;
                                }
                                player.StopAnimation();
                                player.SetData("Ecstasy_Refinando", false);
                                player.TriggerEvent("freezeEx", false);
                                player.TriggerEvent("DestroyProgressBar");
                            }
                        }
                        if (player.GetData("status") == false)
                        {
                            try
                            {
                                Ecstasy.sal_timer[Main.getIdFromClient(player)].Kill();
                                Ecstasy.sal_timer[Main.getIdFromClient(player)] = null;
                            }
                            catch(Exception)
                            {

                            }
                        }
                    }, 1000, 0);
                }
                else if(player.GetData("Ecstasy_Refinando") == true)
                {
                    if (Ecstasy.sal_timer[Main.getIdFromClient(player)] != null)
                    {
                        Ecstasy.sal_timer[Main.getIdFromClient(player)].Kill();
                        Ecstasy.sal_timer[Main.getIdFromClient(player)] = null;
                    }
                    player.StopAnimation();
                    player.SetData("Ecstasy_Refinando", false);
                    player.TriggerEvent("freezeEx", false);
                    player.TriggerEvent("DestroyProgressBar");
                } 
            }
        }
        catch (Exception e)
        {
            Log.Write("ResourceStart: " + e.Message, nLog.Type.Error);
        }
    }
}

