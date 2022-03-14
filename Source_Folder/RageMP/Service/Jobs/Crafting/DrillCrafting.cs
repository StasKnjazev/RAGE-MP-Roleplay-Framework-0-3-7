using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;

class DrillCrafting : Script
{
    public static List<TimerEx> sal_timer = new List<TimerEx>();

    public static void DrillCraftingInit()
    {
        //NAPI.Util.ConsoleOutput("[Jobs] WeaponCrafting.");

        for (var i = 0; i < Main.MAX_PLAYERS; i++)
        {
            sal_timer.Add(null);
        }

    }

    public static void OnPlayerConnect(Client player)
    {
        player.SetData("DrillCrafting_Refinando", false);
        player.SetData("Sal", 20);
        player.SetData("DrillCrafting_RefinandoTime", 0);
        player.TriggerEvent("Sync_PedCreate", "comprador_de_drillcrafting", NAPI.Util.PedNameToModel("GenStreet02AMY"), new Vector3(1035.855, -3204.715, -38.17416), 80.27537f, "", 0);
    }

    public static void PressKeyY(Client player)
    {
        // Bohrer Ersteller
        if (Main.IsInRangeOfPoint(player.Position, new Vector3(1035.855, -3204.715, -38.17416), 3f))
        {
            if (Inventory.GetPlayerItemFromInventory(player, 68) >= 2 && Inventory.GetPlayerItemFromInventory(player, 71) >= 1 && player.GetData("DrillCrafting_Refinando") == false)
            {
                //
                int sals = Inventory.GetPlayerItemFromInventory(player, 68);
                int sals_a_ser_refinados = 0;

                //
                player.SetData("DrillCrafting_Refinando", true);
                player.SetData("DrillCrafting_RefinandoTime", 25);

                //
                player.TriggerEvent("freezeEx", true);
                player.PlayScenario("WORLD_HUMAN_GUARD_STAND");

                //
                player.TriggerEvent("SetProgressBar", player.GetData("DrillCrafting_RefinandoTime"), "Erstelle Bohrer - " + sals_a_ser_refinados + " von " + sals + "");

                //
                DrillCrafting.sal_timer[Main.getIdFromClient(player)] = TimerEx.SetTimer(() =>
                {
                    //
                    if (Inventory.GetPlayerItemFromInventory(player, 68) >= 2)
                    {
                        // 
                        player.SetData("DrillCrafting_RefinandoTime", player.GetData("DrillCrafting_RefinandoTime") + 2);
                        player.TriggerEvent("SetProgressBar", player.GetData("DrillCrafting_RefinandoTime"), "Erstelle Bohrer - " + sals_a_ser_refinados + " von " + sals + "");

                        if (player.GetData("DrillCrafting_RefinandoTime") > 100)
                        {
                            //
                            sals_a_ser_refinados += 2;

                            // Remove o Sal e conta tudo novamente.
                            Inventory.RemoveItem(player, "MetalBlock", 2);
                            Inventory.RemoveItem(player, "ElektroDraht", 1);
                            Inventory.GiveItemToInventory(player, 20, 1);

                            //
                            player.SetData("DrillCrafting_RefinandoTime", 0);
                            player.TriggerEvent("SetProgressBar", player.GetData("DrillCrafting_RefinandoTime"), "Erstelle Bohrer - " + sals_a_ser_refinados + " von " + sals + "");

                            //
                            player.TriggerEvent("createNewHeadNotificationAdvanced", "~g~+~w~ 1x Bohrer erhalten!");

                            //
                            if (Inventory.GetPlayerItemFromInventory(player, 20) == 0)
                            {
                                if (DrillCrafting.sal_timer[Main.getIdFromClient(player)] != null)
                                {
                                    DrillCrafting.sal_timer[Main.getIdFromClient(player)].Kill();
                                    DrillCrafting.sal_timer[Main.getIdFromClient(player)] = null;
                                }
                                player.StopAnimation();
                                player.SetData("DrillCrafting_Refinando", false);
                                player.TriggerEvent("freezeEx", false);
                                player.TriggerEvent("DestroyProgressBar");
                            }
                        }
                    }
                    else
                    {
                        //
                        if (player.GetData("DrillCrafting_Refinando") == true)
                        {
                            if (DrillCrafting.sal_timer[Main.getIdFromClient(player)] != null)
                            {
                                DrillCrafting.sal_timer[Main.getIdFromClient(player)].Kill();
                                DrillCrafting.sal_timer[Main.getIdFromClient(player)] = null;
                            }
                            player.StopAnimation();
                            player.SetData("DrillCrafting_Refinando", false);
                            player.TriggerEvent("freezeEx", false);
                            player.TriggerEvent("DestroyProgressBar");
                        }
                    }
                    if (player.GetData("status") == false)
                    {
                        try
                        {
                            DrillCrafting.sal_timer[Main.getIdFromClient(player)].Kill();
                            DrillCrafting.sal_timer[Main.getIdFromClient(player)] = null;
                        }
                        catch (Exception)
                        {

                        }
                    }
                }, 10000, 0);
            }
            else if (player.GetData("DrillCrafting_Refinando") == true)
            {
                if (sal_timer[Main.getIdFromClient(player)] != null)
                {
                    sal_timer[Main.getIdFromClient(player)].Kill();
                    sal_timer[Main.getIdFromClient(player)] = null;
                }
                player.StopAnimation();
                player.SetData("DrillCrafting_Refinando", false);
                player.TriggerEvent("freezeEx", false);
                player.TriggerEvent("DestroyProgressBar");
            }
        }
    }
}

