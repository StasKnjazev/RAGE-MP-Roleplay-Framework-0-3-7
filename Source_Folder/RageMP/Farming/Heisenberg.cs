using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;
using DerStr1k3r.SDK;

class Heisenberg : Script
{
    private static nLog Log = new nLog("Heisenberg");
    public static List<TimerEx> sal_timer = new List<TimerEx>();

    public static void HeisenbergInit()
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
            player.SetData("Heisenberg_Refinando", false);
            player.SetData("Sal", 20);
            player.SetData("Heisenberg_RefinandoTime", 0);
            player.TriggerEvent("Sync_PedCreate", "heisenberg_refinar", NAPI.Util.PedNameToModel("KTown01AMO"), new Vector3(2531.849, 3795.493, 53.57233), 76.37725f, "", 0);
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
            if (Main.IsInRangeOfPoint(player.Position, new Vector3(2531.849, 3795.493, 53.57233), 3f))
            {
                if (Inventory.GetPlayerItemFromInventory(player, 43) >= 1 && player.GetData("Heisenberg_Refinando") == false)
                {
                    if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 37, 1, Inventory.Max_Inventory_Weight(player)) == true)
                    {
                        return;
                    }
                //
                    int heisenberg = Inventory.GetPlayerItemFromInventory(player, 43);
                    int heisenberg_a_ser_refinados = 0;

                    player.SetData("Heisenberg_Refinando", true);
                    player.SetData("Heisenberg_RefinandoTime", 10);

                    player.TriggerEvent("freezeEx", true);
                    player.PlayScenario("WORLD_HUMAN_GUARD_STAND");

                    NAPI.ClientEvent.TriggerClientEvent(player, "SetProgressBar", player.GetData("Heisenberg_RefinandoTime"), "Verarbeite Meth - " + heisenberg_a_ser_refinados + " von " + heisenberg + "");

                    //
                    Heisenberg.sal_timer[Main.getIdFromClient(player)] = TimerEx.SetTimer(() =>
                    {
                        //
                        if (Inventory.GetPlayerItemFromInventory(player, 43) >= 1)
                        {
                        // 
                            player.SetData("Heisenberg_RefinandoTime", player.GetData("Heisenberg_RefinandoTime") + 10);
                            NAPI.ClientEvent.TriggerClientEvent(player, "SetProgressBar", player.GetData("Heisenberg_RefinandoTime"), "Verarbeite Meth - " + heisenberg_a_ser_refinados + " von " + heisenberg + "");

                            if (player.GetData("Heisenberg_RefinandoTime") > 100)
                            {
                                heisenberg_a_ser_refinados += 1;

                                // Remove o Sal e conta tudo novamente.
                                Inventory.RemoveItem(player, "Penicillin", 1);
                                Inventory.GiveItemToInventory(player, 37, 1);
                                NAPI.Util.ConsoleOutput("[GET JOB HEISENBERG] " + player.SocialClubName + " hat #verarbeitet");

                                player.SetData("Heisenberg_RefinandoTime", 0);
                                NAPI.ClientEvent.TriggerClientEvent(player, "SetProgressBar", player.GetData("Heisenberg_RefinandoTime"), "Verarbeite Meth - " + heisenberg_a_ser_refinados + " von " + heisenberg + "");
                                player.TriggerEvent("Notification.SendPictureNotification", "Meth Verarbeiter", "Job", $"+1 Meth!", "CHAR_CHEF", true);

                                //
                                if (Inventory.GetPlayerItemFromInventory(player, 43) == 0)
                                {
                                    if (Heisenberg.sal_timer[Main.getIdFromClient(player)] != null)
                                    {
                                        Heisenberg.sal_timer[Main.getIdFromClient(player)].Kill();
                                        Heisenberg.sal_timer[Main.getIdFromClient(player)] = null;
                                    }
                                    player.SetData("Heisenberg_Refinando", false);
                                    player.TriggerEvent("freezeEx", false);
                                    player.TriggerEvent("DestroyProgressBar");
                                }
                            }
                        }
                        else
                        {
                        //
                            if (player.GetData("Heisenberg_Refinando") == true)
                            {
                                if (Heisenberg.sal_timer[Main.getIdFromClient(player)] != null)
                                {
                                    Heisenberg.sal_timer[Main.getIdFromClient(player)].Kill();
                                    Heisenberg.sal_timer[Main.getIdFromClient(player)] = null;
                                }
                                player.StopAnimation();
                                player.SetData("Heisenberg_Refinando", false);
                                player.TriggerEvent("freezeEx", false);
                                player.TriggerEvent("DestroyProgressBar");
                            }
                        }
                        if (player.GetData("status") == false)
                        {
                            try
                            {
                                Heisenberg.sal_timer[Main.getIdFromClient(player)].Kill();
                                Heisenberg.sal_timer[Main.getIdFromClient(player)] = null;
                            }
                            catch(Exception)
                            {

                            }
                        }
                    }, 1000, 0);
                }
                else if(player.GetData("Heisenberg_Refinando") == true)
                {
                    if (Heisenberg.sal_timer[Main.getIdFromClient(player)] != null)
                    {
                        Heisenberg.sal_timer[Main.getIdFromClient(player)].Kill();
                        Heisenberg.sal_timer[Main.getIdFromClient(player)] = null;
                    }
                    player.StopAnimation();
                    player.SetData("Heisenberg_Refinando", false);
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


