using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;

class C4Crafting : Script
{
    public static List<TimerEx> sal_timer = new List<TimerEx>();

    public static void C4CraftingInit()
    {
        //NAPI.Util.ConsoleOutput("[Jobs] WeaponCrafting.");

        for (var i = 0; i < Main.MAX_PLAYERS; i++)
        {
            sal_timer.Add(null);
        }
    }

    public static void OnPlayerConnect(Client player)
    {
        player.SetData("C4Crafting_Refinando", false);
        player.SetData("Sal", 20);
        player.SetData("C4Crafting_RefinandoTime", 0);
        player.TriggerEvent("Sync_PedCreate", "comprador_de_c4crafting", NAPI.Util.PedNameToModel("GenStreet02AMY"), new Vector3(1363.05, -2073.559, 50.99854 ), 326.1876f, "", 0);
    }

    public static void PressKeyY(Client player)
    {
        // Bohrer Ersteller
        if (Main.IsInRangeOfPoint(player.Position, new Vector3(1363.05, -2073.559, 50.99854 ), 3f))
        {
            if (Inventory.GetPlayerItemFromInventory(player, 68) >= 2 && Inventory.GetPlayerItemFromInventory(player, 99) >= 1 && player.GetData("C4Crafting_Refinando") == false)
            {
                //
                int sals = Inventory.GetPlayerItemFromInventory(player, 68);
                int sals_a_ser_refinados = 0;

                //
                player.SetData("C4Crafting_Refinando", true);
                player.SetData("C4Crafting_RefinandoTime", 25);

                //
                player.TriggerEvent("freezeEx", true);
                player.PlayScenario("WORLD_HUMAN_GUARD_STAND");

                //
                player.TriggerEvent("SetProgressBar", player.GetData("C4Crafting_RefinandoTime"), "Erstelle C4 - " + sals_a_ser_refinados + " von " + sals + "");

                //
                C4Crafting.sal_timer[Main.getIdFromClient(player)] = TimerEx.SetTimer(() =>
                {
                    //
                    if (Inventory.GetPlayerItemFromInventory(player, 68) >= 2 && Inventory.GetPlayerItemFromInventory(player, 99) >= 1)
                    {
                        // 
                        player.SetData("C4Crafting_RefinandoTime", player.GetData("C4Crafting_RefinandoTime") + 2);
                        player.TriggerEvent("SetProgressBar", player.GetData("C4Crafting_RefinandoTime"), "Erstelle C4 - " + sals_a_ser_refinados + " von " + sals + "");

                        if (player.GetData("C4Crafting_RefinandoTime") > 100)
                        {
                            //
                            sals_a_ser_refinados += 2;

                            // Remove o Sal e conta tudo novamente.
                            Inventory.RemoveItem(player, "MetalBlock", 2);
                            Inventory.GiveItemToInventory(player, 19, 1);

                            //
                            player.SetData("C4Crafting_RefinandoTime", 0);
                            player.TriggerEvent("SetProgressBar", player.GetData("C4Crafting_RefinandoTime"), "Erstelle C4 - " + sals_a_ser_refinados + " von " + sals + "");

                            //
                            player.TriggerEvent("createNewHeadNotificationAdvanced", "~g~+~w~ 1x C4 erhalten!");

                            //
                            if (Inventory.GetPlayerItemFromInventory(player, 19) == 0)
                            {
                                if (C4Crafting.sal_timer[Main.getIdFromClient(player)] != null)
                                {
                                    C4Crafting.sal_timer[Main.getIdFromClient(player)].Kill();
                                    C4Crafting.sal_timer[Main.getIdFromClient(player)] = null;
                                }
                                player.StopAnimation();
                                player.SetData("C4Crafting_Refinando", false);
                                player.TriggerEvent("freezeEx", false);
                                player.TriggerEvent("DestroyProgressBar");
                            }
                        }
                    }
                    else
                    {
                        //
                        if (player.GetData("C4Crafting_Refinando") == true)
                        {
                            if (C4Crafting.sal_timer[Main.getIdFromClient(player)] != null)
                            {
                                C4Crafting.sal_timer[Main.getIdFromClient(player)].Kill();
                                C4Crafting.sal_timer[Main.getIdFromClient(player)] = null;
                            }
                            player.StopAnimation();
                            player.SetData("C4Crafting_Refinando", false);
                            player.TriggerEvent("freezeEx", false);
                            player.TriggerEvent("DestroyProgressBar");
                        }
                    }
                    if (player.GetData("status") == false)
                    {
                        try
                        {
                            C4Crafting.sal_timer[Main.getIdFromClient(player)].Kill();
                            C4Crafting.sal_timer[Main.getIdFromClient(player)] = null;
                        }
                        catch (Exception)
                        {

                        }
                    }
                }, 10000, 0);
            }
            else if (player.GetData("C4Crafting_Refinando") == true)
            {
                if (sal_timer[Main.getIdFromClient(player)] != null)
                {
                    sal_timer[Main.getIdFromClient(player)].Kill();
                    sal_timer[Main.getIdFromClient(player)] = null;
                }
                player.StopAnimation();
                player.SetData("C4Crafting_Refinando", false);
                player.TriggerEvent("freezeEx", false);
                player.TriggerEvent("DestroyProgressBar");
            }
        }
    }
}

