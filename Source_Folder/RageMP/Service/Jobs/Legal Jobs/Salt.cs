using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;
using DerStr1k3r.Core;
using DerStr1k3r.SDK;

class Salt : Script
{
    private static List<dynamic> refinaria_positions = new List<dynamic>();
    public static List<TimerEx> sal_timer = new List<TimerEx>();

    public Salt()
    {
        NAPI.Util.ConsoleOutput("[Jobs] Arma 3 jobs carregado.");

        Blip temp_blip = null;
        temp_blip = NAPI.Blip.CreateBlip(new Vector3(2080.293, 3856.056, 33.21302), 0);
        temp_blip.Sprite = 515;
        temp_blip.Name = "Salzmine";
        temp_blip.Color = 38;
        temp_blip.ShortRange = true;

        temp_blip = NAPI.Blip.CreateBlip(new Vector3(2564.25, 4680.224, 34.07677), 0);
        temp_blip.Sprite = 515;
        temp_blip.Name = "Salzraffinerie";
        temp_blip.Color = 51;
        temp_blip.ShortRange = true;
        

        temp_blip = NAPI.Blip.CreateBlip(new Vector3(1134.348, -1304.325, 34.67915), 0);
        temp_blip.Sprite = 515;
        temp_blip.Name = "Salzverkaufsstelle";
        temp_blip.Color = 52;
        temp_blip.ShortRange = true;


        refinaria_positions.Add(new { position = new Vector3(2090.284, 3886.263, 31.76323) });
        refinaria_positions.Add(new { position = new Vector3(2057.113, 3873.247, 31.6693) });
        refinaria_positions.Add(new { position = new Vector3(2045.156, 3906.454, 31.80743) });
        refinaria_positions.Add(new { position = new Vector3(2016.871, 3882.518, 32.25341) });
        refinaria_positions.Add(new { position = new Vector3(2023.599, 3858.569, 32.32414) });
        refinaria_positions.Add(new { position = new Vector3(2105.61, 3849.383, 31.93057) });
        refinaria_positions.Add(new { position = new Vector3(2087.806, 3806.496, 31.80482) });

        foreach(var refinaria in refinaria_positions)
        {
            NAPI.Marker.CreateMarker(27, refinaria.position - new Vector3(0, 0, 0.8f), new Vector3(), new Vector3(), 14.0f, new Color(255, 255, 255, 110), false, 0);
            NAPI.TextLabel.CreateTextLabel("Drücke E", refinaria.position, 15f, 9f, 0, new Color(255, 255, 255, 100), false, 0);
        }

        for (var i = 0; i < Main.MAX_PLAYERS; i++)
        {
            sal_timer.Add(null);
        }
    }

    [ServerEvent(Event.PlayerConnected)]
    public static void OnPlayerConnect(Client player)
    {
        player.SetData("Refinando", false);
        player.SetData("Sal", 20);
        player.SetData("RefinandoTime", 0);
        player.TriggerEvent("Sync_PedCreate", "sal_refinar", NAPI.Util.PedNameToModel("KTown01AMO"), new Vector3(2564.25, 4680.224, 34.07677), 45.28986f, "", 0);
        player.TriggerEvent("Sync_PedCreate", "comprador_de_sall", NAPI.Util.PedNameToModel("GenStreet02AMY"), new Vector3(1134.348, -1304.325, 34.67915), 4.437579f, "", 0);
    }

    public static void PressKeyY(Client player)
    {
        foreach (var refinaria in refinaria_positions)
        {
            if(Main.IsInRangeOfPoint(player.Position, refinaria.position, 14f) && player.GetData("Refinando") == false)
            {

                if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 13, 3, Inventory.Max_Inventory_Weight(player)) == true)
                {
                    return;
                }

                Inventory.GiveItemToInventory(player, 13, 3);

                player.SetData("Refinando", true);
                NAPI.Player.PlayPlayerAnimation(player, (int)(Main.AnimationFlags.Loop), "anim@mp_snowball", "pickup_snowball");
                //player.TriggerEvent("createNewHeadNotificationAdvanced", "Du hast Salz aus der Salzlösung gewonnen!");
                Main.SendNotificationBrowser(player, "", "<string>+ 3</strong> Salz zu Ihrem Inventar hinzugefügt!", "success");

                NAPI.Task.Run(() =>
                {
                    player.SetData("Refinando", false);
                    player.StopAnimation();
                }, delayTime: 1500);
            }
        }

        if(Main.IsInRangeOfPoint(player.Position, new Vector3(2564.25, 4680.224, 34.07677), 3f))
        {
            if (Inventory.GetPlayerItemFromInventory(player, 13) >= 2 && player.GetData("Refinando") == false)
            {
                //
                int sals = Inventory.GetPlayerItemFromInventory(player, 13);
                int sals_a_ser_refinados = 0;

                //
                player.SetData("Refinando", true);
                player.SetData("RefinandoTime", 25);

                //
                player.TriggerEvent("freezeEx", true);
                player.PlayScenario("WORLD_HUMAN_GUARD_STAND");

                //
                player.TriggerEvent("SetProgressBar", player.GetData("RefinandoTime"), "Salz Verarbeitung - " + sals_a_ser_refinados + " de " + sals + "");

                //
                sal_timer[Main.getIdFromClient(player)] = TimerEx.SetTimer(() =>
                {
                    //
                    if (Inventory.GetPlayerItemFromInventory(player, 13) >= 2)
                    {
                        // 
                        player.SetData("RefinandoTime", player.GetData("RefinandoTime") + 25);
                        player.TriggerEvent("SetProgressBar", player.GetData("RefinandoTime"), "Salz Verarbeitung - " + sals_a_ser_refinados + " von " + sals + "");

                        if (player.GetData("RefinandoTime") > 100)
                        {
                            //
                            sals_a_ser_refinados += 2;

                            // Remove o Sal e conta tudo novamente.
                            Inventory.RemoveItemByType(player, 13, 2);
                            Inventory.GiveItemToInventory(player, 14, 1);

                            //
                            player.SetData("RefinandoTime", 0);
                            player.TriggerEvent("SetProgressBar", player.GetData("RefinandoTime"), "Salz Verarbeitung - " + sals_a_ser_refinados + " von " + sals + "");

                            //
                            player.TriggerEvent("createNewHeadNotificationAdvanced", "~g~+~w~ 1 raffiniertes Salz!");

                            //
                            if (Inventory.GetPlayerItemFromInventory(player, 13) == 0)
                            {
                                if (Salt.sal_timer[Main.getIdFromClient(player)] != null)
                                {
                                    Salt.sal_timer[Main.getIdFromClient(player)].Kill();
                                    Salt.sal_timer[Main.getIdFromClient(player)] = null;
                                }
                                player.StopAnimation();
                                player.SetData("Refinando", false);
                                player.TriggerEvent("freezeEx", false);
                                player.TriggerEvent("DestroyProgressBar");
                            }
                        }
                    }
                    else
                    {
                        //
                        if (player.GetData("Refinando") == true)
                        {
                            if (Salt.sal_timer[Main.getIdFromClient(player)] != null)
                            {
                                Salt.sal_timer[Main.getIdFromClient(player)].Kill();
                                Salt.sal_timer[Main.getIdFromClient(player)] = null;
                            }
                            player.StopAnimation();
                            player.SetData("Refinando", false);
                            player.TriggerEvent("freezeEx", false);
                            player.TriggerEvent("DestroyProgressBar");
                        }
                    }
                    if (player.GetData("status") == false)
                    {
                        try
                        {
                            sal_timer[Main.getIdFromClient(player)].Kill();
                            sal_timer[Main.getIdFromClient(player)] = null;
                        }
                        catch(Exception)
                        {

                        }
                    }
                }, 1000, 0);
            }
            else if(player.GetData("Refinando") == true)
            {
                if (sal_timer[Main.getIdFromClient(player)] != null)
                {
                    sal_timer[Main.getIdFromClient(player)].Kill();
                    sal_timer[Main.getIdFromClient(player)] = null;
                }
                player.StopAnimation();
                player.SetData("Refinando", false);
                player.TriggerEvent("freezeEx", false);
                player.TriggerEvent("DestroyProgressBar");
            }
            
        }

        if (Main.IsInRangeOfPoint(player.Position, new Vector3(1134.348, -1304.325, 34.67915), 3.0f))
        {
            if (Inventory.GetPlayerItemFromInventory(player, 14) > 0)
            {
                InteractMenu.User_Input(player, "input_sell_salt", "Verkaufe raffiniertes Salz", Inventory.GetPlayerItemFromInventory(player, 14).ToString(), "Derzeit hast du " + Inventory.GetPlayerItemFromInventory(player, 14) + "", "number");
            }
            else
            {
                InteractMenu_New.SendNotificationError(player, "Sie haben kein Salz in Ihrem Inventar zu verkaufen.");
            }
        }

    }

    public static void OnInputResponse(Client player, string response, string inputtext)
    {
        if(response == "input_sell_salt")
        {
            if (Inventory.GetPlayerItemFromInventory(player, 14) > 0)
            {
                
                if(!Main.IsNumeric(inputtext))
                {
                    Main.DisplayErrorMessage(player, "Der eingegebene Wert ist nicht numerisch, bitte geben Sie einen gültigen Wert ein.");
                    return;
                }

                int valor = Convert.ToInt32(inputtext);

                if (valor < 1)
                {
                    Main.DisplayErrorMessage(player, "Der eingegebene Wert darf nicht kleiner als 1 sein.");
                    return;
                }

                if(Inventory.GetPlayerItemFromInventory(player, 14) < valor)
                {
                    Main.DisplayErrorMessage(player, "Versuchen Sie "+ valor + " zu verkaufen raffinierte Sals, die Sie nur haben " + Inventory.GetPlayerItemFromInventory(player, 14) + ".");
                    return;
                }

                int price = valor * 50;

                Main.GivePlayerMoney(player, price);
                Main.SendSuccessMessage(player, "Du hast " + Main.EMBED_BLUE+""+ valor + ""+Main.EMBED_WHITE+ " Salz verkauft für " + Main.EMBED_LIGHTGREEN+"$"+ price.ToString("N0") + ""+Main.EMBED_WHITE+".");
                Inventory.RemoveItemByType(player, 14, valor);
            }
            else
            {
                InteractMenu_New.SendNotificationError(player, "Sie haben kein Salz in Ihrem Inventar zu verkaufen.");
            }
        }
    }

}

