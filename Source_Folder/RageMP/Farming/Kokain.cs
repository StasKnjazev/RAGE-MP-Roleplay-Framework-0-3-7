using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;

class Kokain : Script
{
    private static List<dynamic> ecstasy_positions = new List<dynamic>();
    public static List<TimerEx> sal_timer = new List<TimerEx>();

    public static void KokainInit()
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
        player.SetData("Kokain_Refinando", false);
        player.SetData("Sal", 20);
        player.SetData("Kokain_RefinandoTime", 0);
        player.TriggerEvent("Sync_PedCreate", "ecstasy_refinar", NAPI.Util.PedNameToModel("KTown01AMO"), new Vector3(-1445.129, 5422.376, 22.9738), 109.7066f, "", 0);
    }

    public static void PressKeyY(Client player)
    {
        if(Main.IsInRangeOfPoint(player.Position, new Vector3(-1445.129, 5422.376, 22.9738), 3f))
        {
            if (Inventory.GetPlayerItemFromInventory(player, 15) >= 2 && player.GetData("Kokain_Refinando") == false)
            {
                if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 16, 1, Inventory.Max_Inventory_Weight(player)) == true)
                {
                    return;
                }
                //
                int kokain = Inventory.GetPlayerItemFromInventory(player, 15);
                int kokain_a_ser_refinados = 0;

                //
                player.SetData("Kokain_Refinando", true);
                player.SetData("Kokain_RefinandoTime", 10);

                //
                player.TriggerEvent("freezeEx", true);
                player.PlayScenario("WORLD_HUMAN_GUARD_STAND");

                //
                NAPI.ClientEvent.TriggerClientEvent(player, "SetProgressBar", player.GetData("Kokain_RefinandoTime"), "Verarbeite Koks - " + kokain_a_ser_refinados + " von " + kokain + "");

                //
                Kokain.sal_timer[Main.getIdFromClient(player)] = TimerEx.SetTimer(() =>
                {
                    //
                    if (Inventory.GetPlayerItemFromInventory(player,15) >= 2)
                    {
                        // 
                        player.SetData("Kokain_RefinandoTime", player.GetData("Kokain_RefinandoTime") + 10);
                        NAPI.ClientEvent.TriggerClientEvent(player, "SetProgressBar", player.GetData("Kokain_RefinandoTime"), "Verarbeite Koks - " + kokain_a_ser_refinados + " von " + kokain + "");

                        if (player.GetData("Kokain_RefinandoTime") > 100)
                        {
                            //
                            kokain_a_ser_refinados += 2;

                            // Remove o Sal e conta tudo novamente.
                            Inventory.RemoveItem(player, "Kokainblätter", 2);
                            Inventory.GiveItemToInventory(player, 16, 1);

                            //
                            NAPI.Util.ConsoleOutput("[GET JOB KOKAIN] " + player.SocialClubName + " hat #verarbeitet");

                            player.SetData("Kokain_RefinandoTime", 0);
                            NAPI.ClientEvent.TriggerClientEvent(player, "SetProgressBar", player.GetData("Kokain_RefinandoTime"), "Verarbeite Koks - " + kokain_a_ser_refinados + " von " + kokain + "");

                            //
                            player.TriggerEvent("Notification.SendPictureNotification", "Kokain Verarbeiter", "Job", $"+1 Kokain!", "CHAR_CHEF", true);

                            //
                            if (Inventory.GetPlayerItemFromInventory(player, 15) == 0)
                            {
                                if (Kokain.sal_timer[Main.getIdFromClient(player)] != null)
                                {
                                    Kokain.sal_timer[Main.getIdFromClient(player)].Kill();
                                    Kokain.sal_timer[Main.getIdFromClient(player)] = null;
                                }
                                player.SetData("Kokain_Refinando", false);
                                player.TriggerEvent("freezeEx", false);
                                player.TriggerEvent("DestroyProgressBar");
                            }
                        }
                    }
                    else
                    {
                        //
                        if (player.GetData("Kokain_Refinando") == true)
                        {
                            if (Kokain.sal_timer[Main.getIdFromClient(player)] != null)
                            {
                                Kokain.sal_timer[Main.getIdFromClient(player)].Kill();
                                Kokain.sal_timer[Main.getIdFromClient(player)] = null;
                            }
                            player.StopAnimation();
                            player.SetData("Kokain_Refinando", false);
                            player.TriggerEvent("freezeEx", false);
                            player.TriggerEvent("DestroyProgressBar");
                        }
                    }
                    if (player.GetData("status") == false)
                    {
                        try
                        {
                            Kokain.sal_timer[Main.getIdFromClient(player)].Kill();
                            Kokain.sal_timer[Main.getIdFromClient(player)] = null;
                        }
                        catch(Exception)
                        {

                        }
                    }
                }, 1000, 0);
            }
            else if(player.GetData("Kokain_Refinando") == true)
            {
                if (Kokain.sal_timer[Main.getIdFromClient(player)] != null)
                {
                    Kokain.sal_timer[Main.getIdFromClient(player)].Kill();
                    Kokain.sal_timer[Main.getIdFromClient(player)] = null;
                }
                player.StopAnimation();
                player.SetData("Kokain_Refinando", false);
                player.TriggerEvent("freezeEx", false);
                player.TriggerEvent("DestroyProgressBar");
            } 
        }
    }
}

