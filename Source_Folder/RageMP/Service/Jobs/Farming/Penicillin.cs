using System;
using System.Collections.Generic;
using System.Text;
using DerStr1k3r.Core;
using DerStr1k3r.SDK;
using GTANetworkAPI;

class Penicillin : Script
{
    private static List<dynamic> penicillin_positions = new List<dynamic>();
    public static List<TimerEx> sal_timer = new List<TimerEx>();

    public static void PenicillinInit()
    {
        //NAPI.Util.ConsoleOutput("[Jobs] Penicillin.");

        Blip temp_blip = null;
        temp_blip = NAPI.Blip.CreateBlip(new Vector3(2316.954, 5007.919, 42.49178), 0);
        temp_blip.Sprite = 472;
        temp_blip.Name = "Orangenfeld";
        temp_blip.Color = 83;
        temp_blip.ShortRange = true;

        temp_blip = NAPI.Blip.CreateBlip(new Vector3(1348.422, 4309.694, 37.99122), 0);
        temp_blip.Sprite = 472;
        temp_blip.Name = "O.B.I. Obst";
        temp_blip.Color = 83;
        temp_blip.ShortRange = true;
        

        temp_blip = NAPI.Blip.CreateBlip(new Vector3(1022.941, -2893.105, 11.2601), 0);
        temp_blip.Sprite = 280;
        temp_blip.Name = "Expo Medical";
        temp_blip.Color = 83;
        temp_blip.ShortRange = true;


        penicillin_positions.Add(new { position = new Vector3(2316.954, 5007.919, 42.49178) });

        foreach(var refinaria in penicillin_positions)
        {
            NAPI.Marker.CreateMarker(27, refinaria.position - new Vector3(0, 0, 0.8f), new Vector3(), new Vector3(), 14.0f, new Color(255, 255, 255, 110), false, 0);
          //  NAPI.TextLabel.CreateTextLabel("- Orangen -~n~~n~Drücke ~y~E~w~ zum sammmeln", refinaria.position, 15f, 9f, 0, new Color(255, 255, 255, 100), false, 0);
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
        player.SetData("Penicillin_Refinando", false);
        player.SetData("Sal", 20);
        player.SetData("Penicillin_RefinandoTime", 0);
        player.TriggerEvent("Sync_PedCreate", "penicillin_refinar", NAPI.Util.PedNameToModel("KTown01AMO"), new Vector3(1348.422, 4309.694, 37.99122), 79.48059f, "", 0);
        player.TriggerEvent("Sync_PedCreate", "comprador_de_penicillin", NAPI.Util.PedNameToModel("GenStreet02AMY"), new Vector3(1022.941, -2893.105, 11.2601), 121.1011f, "", 0);
    }

    public static void PressKeyY(Client player)
    {
        foreach (var refinaria in penicillin_positions)
        {
            if(Main.IsInRangeOfPoint(player.Position, refinaria.position, 14f) && player.GetData("Penicillin_Refinando") == false)
            {

                if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 42, 3, Inventory.Max_Inventory_Weight(player)) == true)
                {
                    //NAPI.Util.ConsoleOutput("[ORANGE] Kann nicht soviel tragen!");
                    return;
                }

                Inventory.GiveItemToInventory(player, 42, 3);

                player.SetData("Penicillin_Refinando", true);
                NAPI.Player.PlayPlayerAnimation(player, (int)(Main.AnimationFlags.Loop), "anim@mp_snowball", "pickup_snowball");
                //player.TriggerEvent("createNewHeadNotificationAdvanced", "Sie haben ~g~ ~c~3~b~ Orangen~w~aufgehoben !");
                Notify.Send(player, NotifyType.Success, NotifyPosition.BottomCenter, $"Sie haben 3x Orangen aufgehoben !", 5000);
                //NAPI.Notification.SendNotificationToPlayer(player, "Sie haben ~g~ ~c~3x~b~ Orangen~w~aufgehoben !");
                //Main.SendNotificationBrowser(player, "", "<string>+ 3</strong> Orangen in Ihrem Inventar hinzugefügt !", "success");

                NAPI.Task.Run(() =>
                {
                    player.SetData("Penicillin_Refinando", false);
                    player.StopAnimation();
                }, delayTime: 10500);
            }
        }

        if(Main.IsInRangeOfPoint(player.Position, new Vector3(1348.422, 4309.694, 37.99122), 3f))
        {
            if (Inventory.GetPlayerItemFromInventory(player, 42) >= 2 && player.GetData("Penicillin_Refinando") == false)
            {
                if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 43, 1, Inventory.Max_Inventory_Weight(player)) == true)
                {
                    return;
                }
                //
                int orange = Inventory.GetPlayerItemFromInventory(player, 42);
                int orange_a_ser_refinados = 0;

                //
                player.SetData("Penicillin_Refinando", true);
                player.SetData("Penicillin_RefinandoTime", 5);

                //
                player.TriggerEvent("freezeEx", true);
                player.PlayScenario("WORLD_HUMAN_GUARD_STAND");

                //
                NAPI.ClientEvent.TriggerClientEvent(player, "SetProgressBar", player.GetData("Penicillin_RefinandoTime"), "Verarbeite Orangen - " + orange_a_ser_refinados + " von " + orange + "");

                //
                Penicillin.sal_timer[Main.getIdFromClient(player)] = TimerEx.SetTimer(() =>
                {
                    //
                    if (Inventory.GetPlayerItemFromInventory(player,42) >= 2)
                    {

                        // 
                        player.SetData("Penicillin_RefinandoTime", player.GetData("Penicillin_RefinandoTime") + 5);
                        NAPI.ClientEvent.TriggerClientEvent(player, "SetProgressBar", player.GetData("Penicillin_RefinandoTime"), "Verarbeite Orangen - " + orange_a_ser_refinados + " von " + orange + "");

                        if (player.GetData("Penicillin_RefinandoTime") > 100)
                        {
                            //
                            orange_a_ser_refinados += 2;

                            // Remove o Sal e conta tudo novamente.
                            Inventory.RemoveItemByType(player, 42, 2);
                            //Inventory.RemoveItem(player, "Orange", 2);
                            Inventory.GiveItemToInventory(player, 43, 1);

                            //
                            player.SetData("Penicillin_RefinandoTime", 0);
                            NAPI.ClientEvent.TriggerClientEvent(player, "SetProgressBar", player.GetData("Penicillin_RefinandoTime"), "Verarbeite Orangen - " + orange_a_ser_refinados + " von " + orange + "");

                            //
                            NAPI.Util.ConsoleOutput("[GET JOB PENICILLIN] " + player.SocialClubName + " hat #verarbeitet");

                            //player.TriggerEvent("createNewHeadNotificationAdvanced", "~g~+~w~ 1 Verarbeite Orangen zu Penicillin !");
                            //player.TriggerEvent("Notification.SendPictureNotification", "Orangen Verarbeiter", "Job", $"+1 Orangen!", "CHAR_CHEF", true);
                            //
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"1x Orangen erhalten!", 5000);
                            if (Inventory.GetPlayerItemFromInventory(player, 42) == 0)
                            {
                                if (Penicillin.sal_timer[Main.getIdFromClient(player)] != null)
                                {
                                    Penicillin.sal_timer[Main.getIdFromClient(player)].Kill();
                                    Penicillin.sal_timer[Main.getIdFromClient(player)] = null;
                                }
                                player.StopAnimation();
                                player.SetData("Penicillin_Refinando", false);
                                player.TriggerEvent("freezeEx", false);
                                player.TriggerEvent("DestroyProgressBar");
                            }
                        }
                    }
                    else
                    {
                        //
                        if (player.GetData("Penicillin_Refinando") == true)
                        {
                            if (Penicillin.sal_timer[Main.getIdFromClient(player)] != null)
                            {
                                Penicillin.sal_timer[Main.getIdFromClient(player)].Kill();
                                Penicillin.sal_timer[Main.getIdFromClient(player)] = null;
                            }
                            player.StopAnimation();
                            player.SetData("Penicillin_Refinando", false);
                            player.TriggerEvent("freezeEx", false);
                            player.TriggerEvent("DestroyProgressBar");
                        }
                    }
                    if (player.GetData("status") == false)
                    {
                        try
                        {
                            Penicillin.sal_timer[Main.getIdFromClient(player)].Kill();
                            Penicillin.sal_timer[Main.getIdFromClient(player)] = null;
                        }
                        catch(Exception)
                        {

                        }
                    }
                }, 1000, 0);
            }
            else if(player.GetData("Penicillin_Refinando") == true)
            {
                if (Penicillin.sal_timer[Main.getIdFromClient(player)] != null)
                {
                    Penicillin.sal_timer[Main.getIdFromClient(player)].Kill();
                    Penicillin.sal_timer[Main.getIdFromClient(player)] = null;
                }
                player.StopAnimation();
                player.SetData("Penicillin_Refinando", false);
                player.TriggerEvent("freezeEx", false);
                player.TriggerEvent("DestroyProgressBar");
            }
            
        }

        if (Main.IsInRangeOfPoint(player.Position, new Vector3(1022.941, -2893.105, 11.2601), 3.0f))
        {
            if (player.GetData("character_licence_illegal_ordering_1") != 1)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"Du hast das Buch der Chemie nicht!", 5000);
                return;
            }
            if (Inventory.GetPlayerItemFromInventory(player, 43) > 0)
            {
                InteractMenu.User_Input(player, "input_sell_salt", " Penicillin verkaufen", Inventory.GetPlayerItemFromInventory(player, 43).ToString(), "Sie haben derzeit " + Inventory.GetPlayerItemFromInventory(player, 43) + "", "number");
            }
            else
            {
                player.TriggerEvent("Notification.SendPictureNotification", "System Information", "Job", $"Du hast was dafür vergessen!", "CHAR_CHEF", true);
            }
        }

    }

    public static void OnInputResponse(Client player, string response, string inputtext)
    {
        if(response == "input_sell_salt")
        {
            if (Inventory.GetPlayerItemFromInventory(player, 43) > 0)
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

                if(Inventory.GetPlayerItemFromInventory(player, 43) < valor)
                {
                    Main.DisplayErrorMessage(player, "Sie versuchen Penicillin zu verkaufen "+ valor + " doch Sie haben nur "+ Inventory.GetPlayerItemFromInventory(player, 43) + ".");
                    return;
                }

                Random rnd = new Random();
                int price = valor * rnd.Next(9, 17);

                Inventory.GiveItemToInventory(player, 158, price);
                NAPI.Notification.SendNotificationToPlayer(player, "Du hast verkauft " + Main.EMBED_BLUE+""+ valor + ""+Main.EMBED_WHITE+ " Penicillin durch $"+ price.ToString("N0") + ".");
                Inventory.RemoveItemByType(player, 43, valor);
            }
        }
    }

}

