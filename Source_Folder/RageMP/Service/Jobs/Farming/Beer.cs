using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;
using DerStr1k3r.SDK;
using DerStr1k3r.Core;

class Beer : Script
{
    private static nLog Log = new nLog("Beer");
    private static List<dynamic> beer_positions = new List<dynamic>();
    public static List<TimerEx> sal_timer = new List<TimerEx>();

    public static void BeerInit()
    {
        Blip temp_blip = null;
        temp_blip = NAPI.Blip.CreateBlip(new Vector3(-91.44819, 1909.623, 196.7357), 0);
        temp_blip.Sprite = 515;
        temp_blip.Name = "Hopfen Feld";
        temp_blip.Color = 80;
        temp_blip.ShortRange = true;

        temp_blip = NAPI.Blip.CreateBlip(new Vector3(-635.4933, 396.7227, 101.2252), 0);
        temp_blip.Sprite = 480;
        temp_blip.Name = "Hopfenwerk";
        temp_blip.Color = 80;
        temp_blip.ShortRange = true;
        
        temp_blip = NAPI.Blip.CreateBlip(new Vector3(1297.491, -3260.388, 5.907377), 0);
        temp_blip.Sprite = 280;
        temp_blip.Name = "Expo Beer";
        temp_blip.Color = 83;
        temp_blip.ShortRange = true;

        beer_positions.Add(new { position = new Vector3(-102.1648, 1910.922, 196.9615) });

        foreach(var refinaria in beer_positions)
        {
            NAPI.Marker.CreateMarker(27, refinaria.position - new Vector3(0, 0, 0.8f), new Vector3(), new Vector3(), 5.0f, new Color(255, 255, 255, 110), false, 0);
           // NAPI.TextLabel.CreateTextLabel("- Hopfen -~n~~n~Drücke ~y~E~w~ zum sammmeln", refinaria.position, 5f, 9f, 0, new Color(255, 255, 255, 100), false, 0);
        }

        for (var i = 0; i < Main.MAX_PLAYERS; i++)
        {
            sal_timer.Add(null);
        }       
    }

    public static void OnPlayerConnect(Client player)
    {
        try
        {
            player.SetData("Beer_Refinando", false);
            player.SetData("Sal", 20);
            player.SetData("Beer_RefinandoTime", 0);
            player.TriggerEvent("Sync_PedCreate", "beer_refinar", NAPI.Util.PedNameToModel("KTown01AMO"), new Vector3(-635.4933, 396.7227, 101.2252), 45.28986f, "", 0);
            player.TriggerEvent("Sync_PedCreate", "comprador_de_beer", NAPI.Util.PedNameToModel("GenStreet02AMY"), new Vector3(1297.491, -3260.388, 5.907377), 88.90591f, "", 0);
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
            foreach (var refinaria in beer_positions)
            {
                if (Main.IsInRangeOfPoint(player.Position, refinaria.position, 14f) && player.GetData("Beer_Refinando") == false)
                {

                    if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 65, 1, Inventory.Max_Inventory_Weight(player)) == true)
                    {
                        return;
                    }

                    Inventory.GiveItemToInventory(player, 65, 1);

                    player.SetData("Beer_Refinando", true);
                    NAPI.Player.PlayPlayerAnimation(player, (int)(Main.AnimationFlags.Loop), "anim@mp_snowball", "pickup_snowball");
                    //NAPI.Notification.SendNotificationToPlayer(player, "Sie haben ~g~ ~c~1x~b~ Hopfen~w~aufgehoben !");
                    Notify.Send(player, NotifyType.Success, NotifyPosition.BottomCenter, $"Sie haben 1x Hopfen aufgehoben !", 5000);

                    NAPI.Task.Run(() =>
                    {
                        player.SetData("Beer_Refinando", false);
                        player.StopAnimation();
                    }, delayTime: 8500);
                    return;
                }
            }

            if (Main.IsInRangeOfPoint(player.Position, new Vector3(-635.4933, 396.7227, 101.2252), 3f))
            {
                if (Inventory.GetPlayerItemFromInventory(player, 65) >= 3 && player.GetData("Beer_Refinando") == false)
                {
                    if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 66, 1, Inventory.Max_Inventory_Weight(player)) == true)
                    {
                        return;
                    }

                    int beer = Inventory.GetPlayerItemFromInventory(player, 65);
                    int beer_a_ser_refinados = 0;

                    player.SetData("Beer_Refinando", true);
                    player.SetData("Beer_RefinandoTime", 5);
                    player.TriggerEvent("freezeEx", true);
                    player.PlayScenario("WORLD_HUMAN_GUARD_STAND");

                    NAPI.ClientEvent.TriggerClientEvent(player, "SetProgressBar", player.GetData("Beer_RefinandoTime"), "Verarbeite Hopfen - " + beer_a_ser_refinados + " von " + beer + "");

                    Beer.sal_timer[Main.getIdFromClient(player)] = TimerEx.SetTimer(() =>
                    {
                    //
                        if (Inventory.GetPlayerItemFromInventory(player,65) >= 3)
                        {
                        // 
                            player.SetData("Beer_RefinandoTime", player.GetData("Beer_RefinandoTime") + 5);
                            NAPI.ClientEvent.TriggerClientEvent(player, "SetProgressBar", player.GetData("Beer_RefinandoTime"), "Verarbeite Hopfen - " + beer_a_ser_refinados + " von " + beer + "");

                            if (player.GetData("Beer_RefinandoTime") > 100)
                            {
                            //
                                beer_a_ser_refinados += 3;

                                // Remove o Sal e conta tudo novamente.
                                Inventory.RemoveItemByType(player, 65, 3);
                               //Inventory.RemoveItem(player, "Hopfen", 3);
                                Inventory.GiveItemToInventory(player, 66, 1);

                            //
                                NAPI.Util.ConsoleOutput("[GET JOB BEER] " + player.SocialClubName + " hat #verarbeitet");

                                player.SetData("Beer_RefinandoTime", 0);
                                NAPI.ClientEvent.TriggerClientEvent(player, "SetProgressBar", player.GetData("Beer_RefinandoTime"), "Verarbeite Hopfen - " + beer_a_ser_refinados + " von " + beer + "");

                                NAPI.Notification.SendNotificationToPlayer(player, "~g~+~w~ 1x Verarbeite Hopfen !");

                            //
                                if (Inventory.GetPlayerItemFromInventory(player, 66) == 0)
                                {
                                    if (Beer.sal_timer[Main.getIdFromClient(player)] != null)
                                    {
                                        Beer.sal_timer[Main.getIdFromClient(player)].Kill();
                                        Beer.sal_timer[Main.getIdFromClient(player)] = null;
                                    }
                                    player.StopAnimation();
                                    player.SetData("Beer_Refinando", false);
                                    player.TriggerEvent("freezeEx", false);
                                    player.TriggerEvent("DestroyProgressBar");
                                }
                            }
                        }
                        else
                        {
                            //
                            if (player.GetData("Beer_Refinando") == true)
                            {
                                if (Beer.sal_timer[Main.getIdFromClient(player)] != null)
                                {
                                    Beer.sal_timer[Main.getIdFromClient(player)].Kill();
                                    Beer.sal_timer[Main.getIdFromClient(player)] = null;
                                }
                                player.StopAnimation();
                                player.SetData("Beer_Refinando", false);
                                player.TriggerEvent("freezeEx", false);
                                player.TriggerEvent("DestroyProgressBar");
                            }
                        }
                        if (player.GetData("status") == false)
                        {
                            try
                            {
                                Beer.sal_timer[Main.getIdFromClient(player)].Kill();
                                Beer.sal_timer[Main.getIdFromClient(player)] = null;
                            }
                            catch(Exception)
                            {

                            }
                        }
                    }, 1000, 0);
                }
                else if(player.GetData("Beer_Refinando") == true)
                {
                    if (Beer.sal_timer[Main.getIdFromClient(player)] != null)
                    {
                        Beer.sal_timer[Main.getIdFromClient(player)].Kill();
                        Beer.sal_timer[Main.getIdFromClient(player)] = null;
                    }
                    player.StopAnimation();
                    player.SetData("Beer_Refinando", false);
                    player.TriggerEvent("freezeEx", false);
                    player.TriggerEvent("DestroyProgressBar");
                }
            
            }

            if (Main.IsInRangeOfPoint(player.Position, new Vector3(1297.491, -3260.388, 5.907377), 3.0f))
            {
                if (Inventory.GetPlayerItemFromInventory(player, 66) > 0)
                {
                    InteractMenu.User_Input(player, "input_sell_beer", " Bier verkaufen", Inventory.GetPlayerItemFromInventory(player, 66).ToString(), "Sie haben derzeit " + Inventory.GetPlayerItemFromInventory(player, 66) + "", "number");
                }
                else
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "Du hast kein Bier !");
                }
            }
        }
        catch (Exception e)
        {
            Log.Write("ResourceStart: " + e.Message, nLog.Type.Error);
        }
    }

    public static void OnInputResponse(Client player, string response, string inputtext)
    {
        if(response == "input_sell_beer")
        {
            if (Inventory.GetPlayerItemFromInventory(player, 66) > 0)
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

                if(Inventory.GetPlayerItemFromInventory(player, 66) < valor)
                {
                    Main.DisplayErrorMessage(player, "Sie versuchen Wodka zu verkaufen "+ valor + " doch Sie haben nur "+ Inventory.GetPlayerItemFromInventory(player, 66) + ".");
                    return;
                }

                Random rnd = new Random();
                int price = valor * rnd.Next(29, 35);

                Main.GivePlayerMoney(player, price);
                NAPI.Notification.SendNotificationToPlayer(player, "Du hast verkauft " + Main.EMBED_BLUE+""+ valor + ""+Main.EMBED_WHITE+ " Bier durch $"+ price.ToString("N0") + ".");
                Inventory.RemoveItemByType(player, 66, valor);
            }
        }
    }

}

