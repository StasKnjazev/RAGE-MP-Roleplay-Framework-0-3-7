using System;
using System.Collections.Generic;
using System.Text;
using DerStr1k3r.SDK;
using DerStr1k3r.Core;
using GTANetworkAPI;

class Traube : Script
{
    private static List<dynamic> traube_positions = new List<dynamic>();
    public static List<TimerEx> sal_timer = new List<TimerEx>();

    public static void TraubeInit()
    {
        //NAPI.Util.ConsoleOutput("[Jobs] Traube.");

        Blip temp_blip = null;
        temp_blip = NAPI.Blip.CreateBlip(new Vector3(-1635.634, 2222.556, 88.11916), 0);
        temp_blip.Sprite = 515;
        temp_blip.Name = "Traubenfeld";
        temp_blip.Color = 83;
        temp_blip.ShortRange = true;

        temp_blip = NAPI.Blip.CreateBlip(new Vector3(-1886.575, 2050.288, 140.9809), 0);
        temp_blip.Sprite = 480;
        temp_blip.Name = "Weinwerk";
        temp_blip.Color = 83;
        temp_blip.ShortRange = true;
        

        temp_blip = NAPI.Blip.CreateBlip(new Vector3(1297.792, -3325.901, 5.906372), 0);
        temp_blip.Sprite = 280;
        temp_blip.Name = "Expo Wein";
        temp_blip.Color = 83;
        temp_blip.ShortRange = true;

        traube_positions.Add(new { position = new Vector3(-1635.634, 2222.556, 88.11916) });

        foreach(var refinaria in traube_positions)
        {
            NAPI.Marker.CreateMarker(27, refinaria.position - new Vector3(0, 0, 0.8f), new Vector3(), new Vector3(), 14.0f, new Color(255, 255, 255, 110), false, 0);
         //   NAPI.TextLabel.CreateTextLabel("- Trauben -~n~~n~Drücke ~y~E~w~ zum sammmeln", refinaria.position, 5f, 9f, 0, new Color(255, 255, 255, 100), false, 0);
        }

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
        player.SetData("Traube_Refinando", false);
        player.SetData("Sal", 20);
        player.SetData("Traube_RefinandoTime", 0);
        player.TriggerEvent("Sync_PedCreate", "traube_refinar", NAPI.Util.PedNameToModel("KTown01AMO"), new Vector3(-1886.575, 2050.288, 140.9809), 45.28986f, "", 0);
        player.TriggerEvent("Sync_PedCreate", "comprador_de_traube", NAPI.Util.PedNameToModel("GenStreet02AMY"), new Vector3(1297.792, -3325.901, 5.906372), 90.35799f, "", 0);
    }

    public static void PressKeyY(Client player)
    {
        foreach (var refinaria in traube_positions)
        {
            if(Main.IsInRangeOfPoint(player.Position, refinaria.position, 5f) && player.GetData("Traube_Refinando") == false)
            {

                if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 40, 1, Inventory.Max_Inventory_Weight(player)) == true)
                {
                    return;
                }

                Inventory.GiveItemToInventory(player, 40, 1);

                player.SetData("Traube_Refinando", true);
                NAPI.Player.PlayPlayerAnimation(player, (int)(Main.AnimationFlags.Loop), "anim@mp_snowball", "pickup_snowball");
               // player.TriggerEvent("createNewHeadNotificationAdvanced", "Sie haben ~g~ ~c~1~b~ Trauben~w~aufgehoben !");
                //NAPI.Notification.SendNotificationToPlayer(player, "Sie haben ~g~ ~c~1x~b~ Trauben~w~aufgehoben !");
                Notify.Send(player, NotifyType.Success, NotifyPosition.BottomCenter, $"Sie haben 1x Traube aufgehoben !", 5000);
                //Main.SendNotificationBrowser(player, "", "<string>+ 1</strong> Trauben in Ihrem Inventar hinzugefügt !", "success");

                NAPI.Task.Run(() =>
                {
                    player.SetData("Traube_Refinando", false);
                    player.StopAnimation();
                }, delayTime: 6500);
            }
        }

        if(Main.IsInRangeOfPoint(player.Position, new Vector3(-1886.575, 2050.288, 140.9809), 3f))
        {
            if (Inventory.GetPlayerItemFromInventory(player, 40) >= 2 && player.GetData("Traube_Refinando") == false)
            {
                if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 41, 1, Inventory.Max_Inventory_Weight(player)) == true)
                {
                    return;
                }
                //
                int traube = Inventory.GetPlayerItemFromInventory(player, 40);
                int traube_a_ser_refinados = 0;

                //
                player.SetData("Traube_Refinando", true);
                player.SetData("Traube_RefinandoTime", 5);

                //
                player.TriggerEvent("freezeEx", true);
                player.PlayScenario("WORLD_HUMAN_GUARD_STAND");

                //
                NAPI.ClientEvent.TriggerClientEvent(player, "SetProgressBar", player.GetData("Traube_RefinandoTime"), "Verarbeite Trauben - " + traube_a_ser_refinados + " von " + traube + "");

                //
                Traube.sal_timer[Main.getIdFromClient(player)] = TimerEx.SetTimer(() =>
                {
                    //
                    if (Inventory.GetPlayerItemFromInventory(player,40) >= 1)
                    {
                        // 
                        player.SetData("Traube_RefinandoTime", player.GetData("Traube_RefinandoTime") + 5);
                        NAPI.ClientEvent.TriggerClientEvent(player, "SetProgressBar", player.GetData("Traube_RefinandoTime"), "Verarbeite Trauben - " + traube_a_ser_refinados + " von " + traube + "");

                        if (player.GetData("Traube_RefinandoTime") > 100)
                        {
                            //
                            traube_a_ser_refinados += 2;

                            // Remove o Sal e conta tudo novamente.
                            //Inventory.RemoveItem(player, "Traube", 2);
                            Inventory.RemoveItemByType(player, 40, 2);
                            Inventory.GiveItemToInventory(player, 41, 1);

                            //
                            player.SetData("Traube_RefinandoTime", 0);
                            NAPI.ClientEvent.TriggerClientEvent(player, "SetProgressBar", player.GetData("Traube_RefinandoTime"), "Verarbeite Traube - " + traube_a_ser_refinados + " von " + traube + "");

                            //
                            //player.TriggerEvent("createNewHeadNotificationAdvanced", "~g~+~w~ 1 Verarbeite Traube !");
                            NAPI.Notification.SendNotificationToPlayer(player, "~g~+~w~ 1 Verarbeite Traube !");

                            //
                            if (Inventory.GetPlayerItemFromInventory(player, 40) == 0)
                            {
                                if (Traube.sal_timer[Main.getIdFromClient(player)] != null)
                                {
                                    Traube.sal_timer[Main.getIdFromClient(player)].Kill();
                                    Traube.sal_timer[Main.getIdFromClient(player)] = null;
                                }
                                player.StopAnimation();
                                player.SetData("Traube_Refinando", false);
                                player.TriggerEvent("freezeEx", false);
                                player.TriggerEvent("DestroyProgressBar");
                            }
                        }
                    }
                    else
                    {
                        //
                        if (player.GetData("Traube_Refinando") == true)
                        {
                            if (Traube.sal_timer[Main.getIdFromClient(player)] != null)
                            {
                                Traube.sal_timer[Main.getIdFromClient(player)].Kill();
                                Traube.sal_timer[Main.getIdFromClient(player)] = null;
                            }
                            player.StopAnimation();
                            player.SetData("Traube_Refinando", false);
                            player.TriggerEvent("freezeEx", false);
                            player.TriggerEvent("DestroyProgressBar");
                        }
                    }
                    if (player.GetData("status") == false)
                    {
                        try
                        {
                            Traube.sal_timer[Main.getIdFromClient(player)].Kill();
                            Traube.sal_timer[Main.getIdFromClient(player)] = null;
                        }
                        catch(Exception)
                        {

                        }
                    }
                }, 1000, 0);
            }
            else if(player.GetData("Traube_Refinando") == true)
            {
                if (Traube.sal_timer[Main.getIdFromClient(player)] != null)
                {
                    Traube.sal_timer[Main.getIdFromClient(player)].Kill();
                    Traube.sal_timer[Main.getIdFromClient(player)] = null;
                }
                player.StopAnimation();
                player.SetData("Traube_Refinando", false);
                player.TriggerEvent("freezeEx", false);
                player.TriggerEvent("DestroyProgressBar");
            }
            
        }

        if (Main.IsInRangeOfPoint(player.Position, new Vector3(1297.792, -3325.901, 5.906372), 3.0f))
        {
            if (Inventory.GetPlayerItemFromInventory(player, 41) > 0)
            {
                InteractMenu.User_Input(player, "input_sell_wein", " Wein verkaufen", Inventory.GetPlayerItemFromInventory(player, 41).ToString(), "Sie haben derzeit " + Inventory.GetPlayerItemFromInventory(player, 41) + "", "number");
            }
            else
            {
                NAPI.Notification.SendNotificationToPlayer(player, "You dont have wein !");
            }
        }
    }

    public static void OnInputResponse(Client player, string response, string inputtext)
    {
        if(response == "input_sell_wein")
        {
            if (Inventory.GetPlayerItemFromInventory(player, 41) > 0)
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

                if(Inventory.GetPlayerItemFromInventory(player, 41) < valor)
                {
                    Main.DisplayErrorMessage(player, "Sie versuchen Wein zu verkaufen "+ valor + " doch Sie haben nur "+ Inventory.GetPlayerItemFromInventory(player, 41) + ".");
                    return;
                }

                Random rnd = new Random();
                int price = valor * rnd.Next(12, 21);

                Main.GivePlayerMoney(player, price);
                NAPI.Notification.SendNotificationToPlayer(player, "Du hast verkauft " + Main.EMBED_BLUE+""+ valor + ""+Main.EMBED_WHITE+ " Wein durch $"+ price.ToString("N0") + ".");
                Inventory.RemoveItemByType(player, 41, valor);
            }
        }
    }
}

