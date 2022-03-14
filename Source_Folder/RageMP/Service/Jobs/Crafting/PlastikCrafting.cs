using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;
using DerStr1k3r.SDK;
using DerStr1k3r.Core;

class PropylenCrafting : Script
{
    private static nLog Log = new nLog("Propylen Crafting");
    private static List<dynamic> propylen_positions = new List<dynamic>();
    public static List<TimerEx> sal_timer = new List<TimerEx>();
    public static void PropylenCraftingInit()
    {
        Blip temp_blip = null;
        temp_blip = NAPI.Blip.CreateBlip(new Vector3(833.9922, 2139.981, 52.29754), 0);
        temp_blip.Sprite = 515;
        temp_blip.Name = "Propylen Feld";
        temp_blip.Color = 21;
        temp_blip.ShortRange = true;

        temp_blip = NAPI.Blip.CreateBlip(new Vector3(45.45212, -1013.577, 29.52704), 0);
        temp_blip.Sprite = 515;
        temp_blip.Name = "Electro Werkstatt";
        temp_blip.Color = 21;
        temp_blip.ShortRange = true;

        temp_blip = NAPI.Blip.CreateBlip(new Vector3(1292.49, -3063.367, 5.906604), 0);
        temp_blip.Sprite = 280;
        temp_blip.Name = "Expo Electro";
        temp_blip.Color = 83;
        temp_blip.ShortRange = true;

        propylen_positions.Add(new { position = new Vector3(833.9922, 2139.981, 52.29754) });

        foreach(var refinaria in propylen_positions)
        {
            NAPI.Marker.CreateMarker(27, refinaria.position - new Vector3(0, 0, 0.8f), new Vector3(), new Vector3(), 2.0f, new Color(255, 255, 255, 110), false, 0);
            NAPI.TextLabel.CreateTextLabel("", refinaria.position, 3f, 9f, 0, new Color(255, 255, 255, 100), false, 0);
        }

        for (var i = 0; i < Main.MAX_PLAYERS; i++)
        {
            sal_timer.Add(null);
        }

        NAPI.TextLabel.CreateTextLabel("", new Vector3(45.45212, -1013.577, 29.52704 + 1.5), 12, 0.350f, 4, new Color(255, 255, 255, 255));
    }

    public static void OnPlayerConnect(Client player)
    {
        try
        {
            player.SetData("PropylenCrafting_Refinando", false);
            player.SetData("Sal", 20);
            player.SetData("PropylenCrafting_RefinandoTime", 0);
            player.TriggerEvent("Sync_PedCreate", "comprador_de_Propylencrafting", NAPI.Util.PedNameToModel("GenStreet02AMY"), new Vector3(45.45212, -1013.577, 29.52704), 0.3307558f, "", 0);
            player.TriggerEvent("Sync_PedCreate", "comprador_de_Propylendealer", NAPI.Util.PedNameToModel("GenStreet02AMY"), new Vector3(1292.49, -3063.367, 5.906604), 188.6428f, "", 0);
            player.TriggerEvent("Sync_PedCreate", "drugsdealer", NAPI.Util.PedNameToModel("GenStreet02AMY"), new Vector3(1469.512, 6550.428, 14.90413), 3.491002f, "", 0);
        }
        catch (Exception e)
        {
            Log.Write("OnPlayerConnect: " + e.Message, nLog.Type.Error);
        }
    }

    public static void PressKeyY(Client player)
    {
        try
        {
            foreach (var refinaria in propylen_positions)
        {
            // Metal aufsammeln
            if (Main.IsInRangeOfPoint(player.Position, refinaria.position, 14f) && player.GetData("PropylenCrafting_Refinando") == false)
            {
                if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 72, 1, Inventory.Max_Inventory_Weight(player)) == true)
                {
                    return;
                }

                Inventory.GiveItemToInventory(player, 72, 1);

                player.SetData("PropylenCrafting_Refinando", true);
                NAPI.Player.PlayPlayerAnimation(player, (int)(Main.AnimationFlags.Loop), "anim@mp_snowball", "pickup_snowball");
                NAPI.Notification.SendNotificationToPlayer(player, "Sie haben ~g~ ~c~1~b~ Propylen ~w~aufgehoben !");

                NAPI.Task.Run(() =>
                {
                    player.SetData("PropylenCrafting_Refinando", false);
                    player.StopAnimation();
                }, delayTime: 10500);
                return;
            }
        }

        // ElektroDraht Ersteller
        if (Main.IsInRangeOfPoint(player.Position, new Vector3(45.45212, -1013.577, 29.52704), 3f))
        {
            if (Inventory.GetPlayerItemFromInventory(player, 72) >= 1 && player.GetData("PropylenCrafting_Refinando") == false)
            {
                if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 71, 1, Inventory.Max_Inventory_Weight(player)) == true)
                {
                    return;
                }
                //
                int propylen = Inventory.GetPlayerItemFromInventory(player, 72);
                int propylen_a_ser_refinados = 0;

                player.SetData("PropylenCrafting_Refinando", true);
                player.SetData("PropylenCrafting_RefinandoTime", 4);

                player.TriggerEvent("freezeEx", true);
                player.PlayScenario("WORLD_HUMAN_GUARD_STAND");

                NAPI.ClientEvent.TriggerClientEvent(player, "SetProgressBar", player.GetData("PropylenCrafting_RefinandoTime"), "Erstelle Propylen - " + propylen_a_ser_refinados + " von " + propylen + " zu ein ElektroDraht");

                PropylenCrafting.sal_timer[Main.getIdFromClient(player)] = TimerEx.SetTimer(() =>
                {
                    //
                    if (Inventory.GetPlayerItemFromInventory(player, 72) >= 1)
                    {
                        // 
                        player.SetData("PropylenCrafting_RefinandoTime", player.GetData("PropylenCrafting_RefinandoTime") + 4);
                        NAPI.ClientEvent.TriggerClientEvent(player, "SetProgressBar", player.GetData("PropylenCrafting_RefinandoTime"), "Erstelle Propylen - " + propylen_a_ser_refinados + " von " + propylen + " zu ein ElektroDraht");

                        if (player.GetData("PropylenCrafting_RefinandoTime") > 100)
                        {
                            //
                            propylen_a_ser_refinados += 2;
                            // Remove o Sal e conta tudo novamente.
                            Inventory.RemoveItemByType(player, 72, 1);
                            Inventory.GiveItemToInventory(player, 71, 1);

                            player.SetData("PropylenCrafting_RefinandoTime", 0);
                            NAPI.ClientEvent.TriggerClientEvent(player, "SetProgressBar", player.GetData("PropylenCrafting_RefinandoTime"), "Erstelle Propylen - " + propylen_a_ser_refinados + " von " + propylen + " zu ein ElektroDraht");

                            NAPI.Notification.SendNotificationToPlayer(player, "1x Elektro Draht erhalten!");
                            //
                            if (Inventory.GetPlayerItemFromInventory(player, 71) == 0)
                            {
                                if (PropylenCrafting.sal_timer[Main.getIdFromClient(player)] != null)
                                {
                                    PropylenCrafting.sal_timer[Main.getIdFromClient(player)].Kill();
                                    PropylenCrafting.sal_timer[Main.getIdFromClient(player)] = null;
                                }
                                player.StopAnimation();
                                player.SetData("PropylenCrafting_Refinando", false);
                                player.TriggerEvent("freezeEx", false);
                                player.TriggerEvent("DestroyProgressBar");
                            }
                        }
                    }
                    else
                    {
                        //
                        if (player.GetData("PropylenCrafting_Refinando") == true)
                        {
                            if (PropylenCrafting.sal_timer[Main.getIdFromClient(player)] != null)
                            {
                                PropylenCrafting.sal_timer[Main.getIdFromClient(player)].Kill();
                                PropylenCrafting.sal_timer[Main.getIdFromClient(player)] = null;
                            }
                            player.StopAnimation();
                            player.SetData("PropylenCrafting_Refinando", false);
                            player.TriggerEvent("freezeEx", false);
                            player.TriggerEvent("DestroyProgressBar");
                        }
                    }
                    if (player.GetData("status") == false)
                    {
                        try
                        {
                            PropylenCrafting.sal_timer[Main.getIdFromClient(player)].Kill();
                            PropylenCrafting.sal_timer[Main.getIdFromClient(player)] = null;
                        }
                        catch (Exception)
                        {

                        }
                    }
                }, 10000, 0);
            }
            else if (player.GetData("PropylenCrafting_Refinando") == true)
            {
                if (PropylenCrafting.sal_timer[Main.getIdFromClient(player)] != null)
                {
                    PropylenCrafting.sal_timer[Main.getIdFromClient(player)].Kill();
                    PropylenCrafting.sal_timer[Main.getIdFromClient(player)] = null;
                }
                player.StopAnimation();
                player.SetData("PropylenCrafting_Refinando", false);
                player.TriggerEvent("freezeEx", false);
                player.TriggerEvent("DestroyProgressBar");
            }
        }
        if (Main.IsInRangeOfPoint(player.Position, new Vector3(1292.49, -3063.367, 5.906604), 3.0f))
        {
            if (Inventory.GetPlayerItemFromInventory(player, 72) > 0)
            {
                InteractMenu.User_Input(player, "input_sell_propylen", " Elektro Draht verkaufen", Inventory.GetPlayerItemFromInventory(player, 72).ToString(), "Sie haben derzeit " + Inventory.GetPlayerItemFromInventory(player, 72) + "", "number");
            }
            else
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Du hast was dafür vergessen!");
            }
        }
        }
        catch (Exception e)
        {
            Log.Write("PressKeyY: " + e.Message, nLog.Type.Error);
        }
    }
    public static void OnInputResponse(Client player, string response, string inputtext)
    {
        if (response == "input_sell_propylen")
        {
            if (Inventory.GetPlayerItemFromInventory(player, 72) > 0)
            {

                if (!Main.IsNumeric(inputtext))
                {
                    Main.DisplayErrorMessage(player, "Der eingegebene Wert ist nicht numerisch. Bitte geben Sie einen gültigen Wert ein.");
                    return;
                }

                int valor = Convert.ToInt32(inputtext);

                if (valor < 1)
                {
                    Main.DisplayErrorMessage(player, "Der eingegebene Wert darf nicht kleiner als 1 sein.");
                    return;
                }

                if (Inventory.GetPlayerItemFromInventory(player, 72) < valor)
                {
                    Main.DisplayErrorMessage(player, "Sie versuchen Elektro Draht zu verkaufen " + valor + " doch Sie haben nur " + Inventory.GetPlayerItemFromInventory(player, 72) + ".");
                    return;
                }

                Random rnd = new Random();
                int price = valor * rnd.Next(77, 89);

                Inventory.GiveItemToInventory(player, 158, +price);
                NAPI.Notification.SendNotificationToPlayer(player, "Du hast " + Main.EMBED_BLUE + "" + valor + "" + Main.EMBED_WHITE + " Elektro Draht durch $" + price.ToString("N0") + " verkauft.");
                Inventory.RemoveItemByType(player, 72, valor);
            }
        }
    }
}

