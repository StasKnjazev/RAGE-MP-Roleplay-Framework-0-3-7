using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;

class Wodka : Script
{
    private static List<dynamic> wodka_positions = new List<dynamic>();
    public static List<TimerEx> sal_timer = new List<TimerEx>();

    public static void WodkaInit()
    {
        //NAPI.Util.ConsoleOutput("[Jobs] Wodka.");

        Blip temp_blip = null;
        temp_blip = NAPI.Blip.CreateBlip(new Vector3(1985.403, 4825.375, 43.77779), 0);
        temp_blip.Sprite = 515;
        temp_blip.Name = "Kartoffel Feld";
        temp_blip.Color = 16;
        temp_blip.ShortRange = true;

        temp_blip = NAPI.Blip.CreateBlip(new Vector3(-45.92524, 1958.817, 190.1716), 0);
        temp_blip.Sprite = 480;
        temp_blip.Name = "Kartoffel Verarbeiter";
        temp_blip.Color = 16;
        temp_blip.ShortRange = true;
        

        temp_blip = NAPI.Blip.CreateBlip(new Vector3(1250.167, -2925.561, 9.319258), 0);
        temp_blip.Sprite = 280;
        temp_blip.Name = "Expo Wodka";
        temp_blip.Color = 83;
        temp_blip.ShortRange = true;


        wodka_positions.Add(new { position = new Vector3(1976.683, 4834.338, 44.07155) });
        wodka_positions.Add(new { position = new Vector3(1990.691, 4846.441, 44.0032) });
        wodka_positions.Add(new { position = new Vector3(2005.16, 4832.573, 43.15826) });

        foreach(var refinaria in wodka_positions)
        {
            NAPI.Marker.CreateMarker(27, refinaria.position - new Vector3(0, 0, 0.8f), new Vector3(), new Vector3(), 3.0f, new Color(255, 255, 255, 110), false, 0);
         //   NAPI.TextLabel.CreateTextLabel("- Kartoffel -~n~~n~Drücke ~y~E~w~ zum sammmeln", refinaria.position, 5f, 9f, 0, new Color(255, 255, 255, 100), false, 0);
        }

        for (var i = 0; i < Main.MAX_PLAYERS; i++)
        {
            sal_timer.Add(null);
        }

      //  NAPI.TextLabel.CreateTextLabel("~y~Kartoffel Verarbeiter~w~~n~Drücke ~b~E~w~ damit ~n~~w~Serge verarbeitet es ", new Vector3(-45.92524, 1958.817, 190.1716 + 1.5), 12, 0.350f, 4, new Color(255, 255, 255, 255));
      //  NAPI.TextLabel.CreateTextLabel("~y~Wodka Ankäufer~w~~n~Drücke ~b~E~w~ um Wodka an ~n~~w~Ivan zu verkaufen", new Vector3(1250.167, -2925.561, 9.319258 + 1.5), 12, 0.350f, 4, new Color(255, 255, 255, 255));  
    }

    public static void OnPlayerConnect(Client player)
    {
        player.SetData("Wodka_Refinando", false);
        player.SetData("Sal", 20);
        player.SetData("Wodka_RefinandoTime", 0);
        player.TriggerEvent("Sync_PedCreate", "wodka_refinar", NAPI.Util.PedNameToModel("KTown01AMO"), new Vector3(-45.92524, 1958.817, 190.1716), 45.28986f, "", 0);
        player.TriggerEvent("Sync_PedCreate", "comprador_de_wodka", NAPI.Util.PedNameToModel("GenStreet02AMY"), new Vector3(1250.167, -2925.561, 9.319258), 2.324081f, "", 0);
    }

    public static void PressKeyY(Client player)
    {
        foreach (var refinaria in wodka_positions)
        {
            if (Main.IsInRangeOfPoint(player.Position, refinaria.position, 14f) && player.GetData("Wodka_Refinando") == false)
            {
                if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 59, 1, Inventory.Max_Inventory_Weight(player)) == true)
                {
                    return;
                }

                Inventory.GiveItemToInventory(player, 59, 1);

                player.SetData("Wodka_Refinando", true);
                NAPI.Player.PlayPlayerAnimation(player, (int)(Main.AnimationFlags.Loop), "anim@mp_snowball", "pickup_snowball");
               // player.TriggerEvent("createNewHeadNotificationAdvanced", "Sie haben ~g~ ~c~1~b~ Kartoffel~w~aufgehoben !");
                NAPI.Notification.SendNotificationToPlayer(player, "Sie haben ~g~ ~c~1x~b~ Kartoffel~w~aufgehoben !");
                //Main.SendNotificationBrowser(player, "", "<string>+ 1</strong> Kartoffel in Ihrem Inventar hinzugefügt !", "success");

                NAPI.Task.Run(() =>
                {
                    player.SetData("Wodka_Refinando", false);
                    player.StopAnimation();
                }, delayTime: 15000);
                return;
            }
        }

       if (Main.IsInRangeOfPoint(player.Position, new Vector3(-45.92524, 1958.817, 190.1716), 3f))
        {
            if (Inventory.GetPlayerItemFromInventory(player, 59) >= 3 && player.GetData("Wodka_Refinando") == false)
            {
                if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 60, 1, Inventory.Max_Inventory_Weight(player)) == true)
                {
                    return;
                }
                //
                int wodka = Inventory.GetPlayerItemFromInventory(player, 59);
                int wodka_a_ser_refinados = 0;

                //
                player.SetData("Wodka_Refinando", true);
                player.SetData("Wodka_RefinandoTime", 5);

                //
                player.TriggerEvent("freezeEx", true);
                player.PlayScenario("WORLD_HUMAN_GUARD_STAND");

                //
                NAPI.ClientEvent.TriggerClientEvent(player, "SetProgressBar", player.GetData("Wodka_RefinandoTime"), "Verarbeite Kartoffel - " + wodka_a_ser_refinados + " von " + wodka + "");

                //
                Wodka.sal_timer[Main.getIdFromClient(player)] = TimerEx.SetTimer(() =>
                {
                    //
                    if (Inventory.GetPlayerItemFromInventory(player,59) >= 3)
                    {
                        // 
                        player.SetData("Wodka_RefinandoTime", player.GetData("Wodka_RefinandoTime") + 5);
                        NAPI.ClientEvent.TriggerClientEvent(player, "SetProgressBar", player.GetData("Wodka_RefinandoTime"), "Verarbeite Kartoffel - " + wodka_a_ser_refinados + " von " + wodka + "");

                        if (player.GetData("Wodka_RefinandoTime") > 100)
                        {
                            //
                            wodka_a_ser_refinados += 3;

                            // Remove o Sal e conta tudo novamente.
                            Inventory.RemoveItem(player, "Kartoffel", 3);
                            Inventory.GiveItemToInventory(player, 60, 1);

                            //
                            player.SetData("Wodka_RefinandoTime", 0);
                            NAPI.ClientEvent.TriggerClientEvent(player, "SetProgressBar", player.GetData("Wodka_RefinandoTime"), "Verarbeite Kartoffel - " + wodka_a_ser_refinados + " von " + wodka + "");

                            //
                            //player.TriggerEvent("createNewHeadNotificationAdvanced", "~g~+~w~ 1x Verarbeiten Kartoffel !");
                            NAPI.Notification.SendNotificationToPlayer(player, "~g~+~w~ 1x Verarbeiten Kartoffel ! !");

                            //
                            if (Inventory.GetPlayerItemFromInventory(player, 60) == 0)
                            {
                                if (Wodka.sal_timer[Main.getIdFromClient(player)] != null)
                                {
                                    Wodka.sal_timer[Main.getIdFromClient(player)].Kill();
                                    Wodka.sal_timer[Main.getIdFromClient(player)] = null;
                                }
                                player.StopAnimation();
                                player.SetData("Wodka_Refinando", false);
                                player.TriggerEvent("freezeEx", false);
                                player.TriggerEvent("DestroyProgressBar");
                            }
                        }
                    }
                    else
                    {
                        //
                        if (player.GetData("Wodka_Refinando") == true)
                        {
                            if (Wodka.sal_timer[Main.getIdFromClient(player)] != null)
                            {
                                Wodka.sal_timer[Main.getIdFromClient(player)].Kill();
                                Wodka.sal_timer[Main.getIdFromClient(player)] = null;
                            }
                            player.StopAnimation();
                            player.SetData("Wodka_Refinando", false);
                            player.TriggerEvent("freezeEx", false);
                            player.TriggerEvent("DestroyProgressBar");
                        }
                    }
                    if (player.GetData("status") == false)
                    {
                        try
                        {
                            Wodka.sal_timer[Main.getIdFromClient(player)].Kill();
                            Wodka.sal_timer[Main.getIdFromClient(player)] = null;
                        }
                        catch(Exception)
                        {

                        }
                    }
                }, 1000, 0);
            }
            else if(player.GetData("Wodka_Refinando") == true)
            {
                if (Wodka.sal_timer[Main.getIdFromClient(player)] != null)
                {
                    Wodka.sal_timer[Main.getIdFromClient(player)].Kill();
                    Wodka.sal_timer[Main.getIdFromClient(player)] = null;
                }
                player.StopAnimation();
                player.SetData("Wodka_Refinando", false);
                player.TriggerEvent("freezeEx", false);
                player.TriggerEvent("DestroyProgressBar");
            }
            
        }

        if (Main.IsInRangeOfPoint(player.Position, new Vector3(1250.167, -2925.561, 9.319258), 3.0f))
        {
            if (Inventory.GetPlayerItemFromInventory(player, 60) > 0)
            {
                InteractMenu.User_Input(player, "input_sell_wodka", " Wodka verkaufen", Inventory.GetPlayerItemFromInventory(player, 60).ToString(), "Sie haben derzeit " + Inventory.GetPlayerItemFromInventory(player, 60) + "", "number");
            }
            else
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Du hast keinen Wodka !");
            }
        }

    }

    public static void OnInputResponse(Client player, string response, string inputtext)
    {
        if(response == "input_sell_wodka")
        {
            if (Inventory.GetPlayerItemFromInventory(player, 60) > 0)
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

                if(Inventory.GetPlayerItemFromInventory(player, 60) < valor)
                {
                    Main.DisplayErrorMessage(player, "Sie versuchen Wodka zu verkaufen "+ valor + " doch Sie haben nur "+ Inventory.GetPlayerItemFromInventory(player, 60) + ".");
                    return;
                }

                Random rnd = new Random();
                int price = valor * rnd.Next(9, 31);

                Inventory.GiveItemToInventory(player, 158, price);
                NAPI.Notification.SendNotificationToPlayer(player, "Du hast verkauft " + Main.EMBED_BLUE+""+ valor + ""+Main.EMBED_WHITE+ " Wodka durch $"+ price.ToString("N0") + ".");
                Inventory.RemoveItem(player, "Wodka", valor);           
            }
        }
    }
}

