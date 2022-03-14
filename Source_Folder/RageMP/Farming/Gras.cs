using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;

class Gras : Script
{
    public static List<TimerEx> sal_timer = new List<TimerEx>();

    public static void GrasInit()
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
        player.SetData("Gras_Refinando", false);
        player.SetData("Sal", 20);
        player.SetData("Gras_RefinandoTime", 0);
        player.TriggerEvent("Sync_PedCreate", "gras_refinar", NAPI.Util.PedNameToModel("KTown01AMO"), new Vector3(-128.5948, 188.2878, 85.42721), 122.6032f, "", 0);
    }

    public static void PressKeyY(Client player)
    {
        if(Main.IsInRangeOfPoint(player.Position, new Vector3(-128.5948, 188.2878, 85.42721), 3f))
        {
            if (Inventory.GetPlayerItemFromInventory(player, 11) >= 2 && player.GetData("Gras_Refinando") == false)
            {
                if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 12, 1, Inventory.Max_Inventory_Weight(player)) == true)
                {
                    return;
                }
                //
                int gras = Inventory.GetPlayerItemFromInventory(player, 11);
                int gras_a_ser_refinados = 0;

                //
                player.SetData("Gras_Refinando", true);
                player.SetData("Gras_RefinandoTime", 10);

                //
                player.TriggerEvent("freezeEx", true);
                player.PlayScenario("WORLD_HUMAN_GUARD_STAND");

                //
                NAPI.ClientEvent.TriggerClientEvent(player, "SetProgressBar", player.GetData("Gras_RefinandoTime"), "Verarbeite Weed - " + gras_a_ser_refinados + " von " + gras + "");

                    //
                Gras.sal_timer[Main.getIdFromClient(player)] = TimerEx.SetTimer(() =>
                {
                    //
                    if (Inventory.GetPlayerItemFromInventory(player, 11) >= 2)
                    {
                        // 
                        player.SetData("Gras_RefinandoTime", player.GetData("Gras_RefinandoTime") + 10);
                        NAPI.ClientEvent.TriggerClientEvent(player, "SetProgressBar", player.GetData("Gras_RefinandoTime"), "Verarbeite Weed - " + gras_a_ser_refinados + " von " + gras + "");

                        if (player.GetData("Gras_RefinandoTime") > 100)
                        {

                            //
                            gras_a_ser_refinados += 2;

                            // Remove o Sal e conta tudo novamente.
                            Inventory.RemoveItem(player, "Unverarbeitetes Marihuana", 2);
                            Inventory.GiveItemToInventory(player, 12, 1);

                            NAPI.Util.ConsoleOutput("[GET JOB GRAS] " + player.SocialClubName + " hat #verarbeitet");

                            //
                            player.SetData("Gras_RefinandoTime", 0);
                            NAPI.ClientEvent.TriggerClientEvent(player, "SetProgressBar", player.GetData("Gras_RefinandoTime"), "Verarbeite Weed - " + gras_a_ser_refinados + " von " + gras + "");

                            //
                            //player.TriggerEvent("createNewHeadNotificationAdvanced", "~g~+~w~ 1 Weed !");
                            player.TriggerEvent("Notification.SendPictureNotification", "Weed Verarbeiter", "Job", $"+1 Weed!", "CHAR_CHEF", true);
                            //
                            if (Inventory.GetPlayerItemFromInventory(player, 11) == 0)
                            {
                                if (Gras.sal_timer[Main.getIdFromClient(player)] != null)
                                {
                                    Gras.sal_timer[Main.getIdFromClient(player)].Kill();
                                    Gras.sal_timer[Main.getIdFromClient(player)] = null;
                                }
                                player.SetData("Gras_Refinando", false);
                                player.TriggerEvent("freezeEx", false);
                                player.TriggerEvent("DestroyProgressBar");
                            }
                        }
                    }
                    else
                    {
                        //
                        if (player.GetData("Gras_Refinando") == true)
                        {
                            if (Gras.sal_timer[Main.getIdFromClient(player)] != null)
                            {
                                Gras.sal_timer[Main.getIdFromClient(player)].Kill();
                                Gras.sal_timer[Main.getIdFromClient(player)] = null;
                            }
                            player.StopAnimation();
                            player.SetData("Gras_Refinando", false);
                            player.TriggerEvent("freezeEx", false);
                            player.TriggerEvent("DestroyProgressBar");
                        }
                    }
                    if (player.GetData("status") == false)
                    {
                        try
                        {
                            Gras.sal_timer[Main.getIdFromClient(player)].Kill();
                            Gras.sal_timer[Main.getIdFromClient(player)] = null;
                        }
                        catch(Exception)
                        {

                        }
                    }
                }, 1000, 0);
            }
            else if(player.GetData("Gras_Refinando") == true)
            {
                if (Gras.sal_timer[Main.getIdFromClient(player)] != null)
                {
                    Gras.sal_timer[Main.getIdFromClient(player)].Kill();
                    Gras.sal_timer[Main.getIdFromClient(player)] = null;
                }
                player.StopAnimation();
                player.SetData("Gras_Refinando", false);
                player.TriggerEvent("freezeEx", false);
                player.TriggerEvent("DestroyProgressBar");
            }  
        }
    }
}


