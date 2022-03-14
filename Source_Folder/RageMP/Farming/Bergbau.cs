using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;

class Bergbau : Script
{
    private static List<dynamic> bergbau_positions = new List<dynamic>();
    public static List<TimerEx> sal_timer = new List<TimerEx>();

    public static void BergbauInit()
    {
        Blip temp_blip = null;
        temp_blip = NAPI.Blip.CreateBlip(new Vector3(2958.414, 2782.324, 40.70641), 0);
        temp_blip.Sprite = 365;
        temp_blip.Name = "Stein Mine";
        temp_blip.Color = 38;
        temp_blip.ShortRange = true;

        temp_blip = NAPI.Blip.CreateBlip(new Vector3(1084.301, -1997.37, 30.87674), 0);
        temp_blip.Sprite = 365;
        temp_blip.Name = "Steinwerk";
        temp_blip.Color = 51;
        temp_blip.ShortRange = true;
        

        temp_blip = NAPI.Blip.CreateBlip(new Vector3(1237.667, -3349.753, 5.901594), 0);
        temp_blip.Sprite = 280;
        temp_blip.Name = "Expo Beton";
        temp_blip.Color = 83;
        temp_blip.ShortRange = true;

        bergbau_positions.Add(new { position = new Vector3(2934.265, 2771.041, 39.47127) });
        //bergbau_positions.Add(new { position = new Vector3(1292.49, -3063.367, 5.906604) });
        //bergbau_positions.Add(new { position = new Vector3(2924.844, 2809.276, 43.3462) });

        foreach(var refinaria in bergbau_positions)
        {
            NAPI.Marker.CreateMarker(27, refinaria.position - new Vector3(0, 0, 0.8f), new Vector3(), new Vector3(), 14.0f, new Color(255, 255, 255, 110), false, 0);
            NAPI.TextLabel.CreateTextLabel("- Stein -", refinaria.position, 15f, 9f, 0, new Color(255, 255, 255, 100), false, 0);
        }

        for (var i = 0; i < Main.MAX_PLAYERS; i++)
        {
            sal_timer.Add(null);
        }
    }

    public static void OnPlayerConnect(Client player)
    {
        player.SetData("Bergbau_Refinando", false);
        player.SetData("Sal", 20);
        player.SetData("Bergbau_RefinandoTime", 0);
        player.TriggerEvent("Sync_PedCreate", "bergbau_refinar", NAPI.Util.PedNameToModel("KTown01AMO"), new Vector3(1084.301, -1997.37, 30.87674), 45.28986f, "", 0);
        player.TriggerEvent("Sync_PedCreate", "comprador_de_bergbau", NAPI.Util.PedNameToModel("GenStreet02AMY"), new Vector3(1237.667, -3349.753, 5.901594), 14.48114f, "", 0);
    }

    public static void PressKeyY(Client player)
    {
        foreach (var refinaria in bergbau_positions)
        {
            if(Main.IsInRangeOfPoint(player.Position, refinaria.position, 14f) && player.GetData("Bergbau_Refinando") == false)
            {

                if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 38, 3, Inventory.Max_Inventory_Weight(player)) == true)
                {
                    return;
                }

                Inventory.GiveItemToInventory(player, 38, 2);

                player.SetData("Bergbau_Refinando", true);
                player.PlayAnimation("amb@world_human_hammering@male@base", "base", 1 << 0 | 1 << 5);
                Main.AttachObjectToEntity("prop_tool_pickaxe", player.Value, 28422);
                //player.TriggerEvent("createNewHeadNotificationAdvanced", "Sie haben ~g~ ~c~2~b~ Stein~w~aufgehoben !");
                NAPI.Notification.SendNotificationToPlayer(player, "Sie haben ~g~ ~c~2x~b~ Stein~w~aufgehoben !");
                //Main.SendNotificationBrowser(player, "", "<string>+ 2</strong> Stein in Ihrem Inventar hinzugefügt !", "success");

                NAPI.Task.Run(() =>
                {
                    player.SetData("Bergbau_Refinando", false);
                    player.StopAnimation();
                    Main.DeleteAttachedObject(player);
                }, delayTime: 3500);
            }
        }

        if(Main.IsInRangeOfPoint(player.Position, new Vector3(1084.301, -1997.37, 30.87674), 3f))
        {
            if (Inventory.GetPlayerItemFromInventory(player, 38) >= 2 && player.GetData("Bergbau_Refinando") == false)
            {
                //
                int sals = Inventory.GetPlayerItemFromInventory(player, 38);
                int sals_a_ser_refinados = 0;

                //
                player.SetData("Bergbau_Refinando", true);
                player.SetData("Bergbau_RefinandoTime", 25);

                //
                player.TriggerEvent("freezeEx", true);
                player.PlayScenario("WORLD_HUMAN_GUARD_STAND");

                //
                NAPI.ClientEvent.TriggerClientEvent(player, "SetProgressBar", player.GetData("Bergbau_RefinandoTime"), "Verarbeite Stein - " + sals_a_ser_refinados + " von " + sals + "");

                //
                Bergbau.sal_timer[Main.getIdFromClient(player)] = TimerEx.SetTimer(() =>
                {
                    //
                    if (Inventory.GetPlayerItemFromInventory(player,38) >= 2)
                    {
                        if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 39, 1, Inventory.Max_Inventory_Weight(player)) == true)
                        {
                            if (Bergbau.sal_timer[Main.getIdFromClient(player)] != null)
                            {
                                Bergbau.sal_timer[Main.getIdFromClient(player)].Kill();
                                Bergbau.sal_timer[Main.getIdFromClient(player)] = null;
                            }
                            player.SetData("Bergbau_Refinando", false);
                            player.TriggerEvent("freezeEx", false);
                            player.TriggerEvent("DestroyProgressBar");
                            return;
                        }
                        // 
                        player.SetData("Bergbau_RefinandoTime", player.GetData("Bergbau_RefinandoTime") + 25);
                        NAPI.ClientEvent.TriggerClientEvent(player, "SetProgressBar", player.GetData("Bergbau_RefinandoTime"), "Verarbeite Stein - " + sals_a_ser_refinados + " von " + sals + "");

                        if (player.GetData("Bergbau_RefinandoTime") > 100)
                        {

                            //
                            sals_a_ser_refinados += 2;

                            // Remove o Sal e conta tudo novamente.
                            Inventory.RemoveItem(player, "Stein", 2);
                            Inventory.GiveItemToInventory(player, 39, 1);

                            //
                            player.SetData("Bergbau_RefinandoTime", 0);
                            NAPI.ClientEvent.TriggerClientEvent(player, "SetProgressBar", player.GetData("Bergbau_RefinandoTime"), "Verarbeite Stein - " + sals_a_ser_refinados + " von " + sals + "");

                            //
                           // player.TriggerEvent("createNewHeadNotificationAdvanced", "~g~+~w~ 1 Verarbeite Stein !");
                            NAPI.Notification.SendNotificationToPlayer(player, "~g~+~w~ 1 Verarbeite Stein !");

                            //
                            if (Inventory.GetPlayerItemFromInventory(player, 38) == 0)
                            {
                                if (Bergbau.sal_timer[Main.getIdFromClient(player)] != null)
                                {
                                    Bergbau.sal_timer[Main.getIdFromClient(player)].Kill();
                                    Bergbau.sal_timer[Main.getIdFromClient(player)] = null;
                                }
                                player.StopAnimation();
                                player.SetData("Bergbau_Refinando", false);
                                player.TriggerEvent("freezeEx", false);
                                player.TriggerEvent("DestroyProgressBar");
                            }
                        }
                    }
                    else
                    {
                        //
                        if (player.GetData("Bergbau_Refinando") == true)
                        {
                            if (Bergbau.sal_timer[Main.getIdFromClient(player)] != null)
                            {
                                Bergbau.sal_timer[Main.getIdFromClient(player)].Kill();
                                Bergbau.sal_timer[Main.getIdFromClient(player)] = null;
                            }
                            player.StopAnimation();
                            player.SetData("Bergbau_Refinando", false);
                            player.TriggerEvent("freezeEx", false);
                            player.TriggerEvent("DestroyProgressBar");
                        }
                    }
                    if (player.GetData("status") == false)
                    {
                        try
                        {
                            Bergbau.sal_timer[Main.getIdFromClient(player)].Kill();
                            Bergbau.sal_timer[Main.getIdFromClient(player)] = null;
                        }
                        catch(Exception)
                        {

                        }
                    }
                }, 1000, 0);
            }
            else if(player.GetData("Bergbau_Refinando") == true)
            {
                if (Bergbau.sal_timer[Main.getIdFromClient(player)] != null)
                {
                    Bergbau.sal_timer[Main.getIdFromClient(player)].Kill();
                    Bergbau.sal_timer[Main.getIdFromClient(player)] = null;
                }
                player.StopAnimation();
                player.SetData("Bergbau_Refinando", false);
                player.TriggerEvent("freezeEx", false);
                player.TriggerEvent("DestroyProgressBar");
            }
            
        }

        if (Main.IsInRangeOfPoint(player.Position, new Vector3(1237.667, -3349.753, 5.901594), 3.0f))
        {
            if (Inventory.GetPlayerItemFromInventory(player, 39) > 0)
            {
                InteractMenu.User_Input(player, "input_sell_bergbau", " Beton verkaufen", Inventory.GetPlayerItemFromInventory(player, 39).ToString(), "Sie haben derzeit " + Inventory.GetPlayerItemFromInventory(player, 39) + "", "number");
            }
            else
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Sie haben kein Beton !");
            }
        }

    }

    public static void OnInputResponse(Client player, string response, string inputtext)
    {
        if(response == "input_sell_bergbau")
        {
            if (Inventory.GetPlayerItemFromInventory(player, 39) > 0)
            {
                
                if(!Main.IsNumeric(inputtext))
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

                if(Inventory.GetPlayerItemFromInventory(player, 39) < valor)
                {
                    Main.DisplayErrorMessage(player, "Sie versuchen Beton zu verkaufen "+ valor + " doch Sie haben nur "+ Inventory.GetPlayerItemFromInventory(player, 39) + ".");
                    return;
                }

                Random rnd = new Random();
                int price = valor * rnd.Next(18, 28);

                Main.GivePlayerMoney(player, price);
                NAPI.Notification.SendNotificationToPlayer(player, "Du hast verkauft " + Main.EMBED_BLUE+""+ valor + ""+Main.EMBED_WHITE+ " Beton durch $"+ price.ToString("N0") + ".");
                Inventory.RemoveItem(player, "Beton", valor);
            }
        }
    }
}

