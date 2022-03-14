using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;
//Pelz.OnInputResponse
class Pelz : Script
{
    private static List<dynamic> Pelz_positions = new List<dynamic>();
    public static List<TimerEx> sal_timer = new List<TimerEx>();

    public static void PelzInit()
    {
        Blip temp_blip = null;
        temp_blip = NAPI.Blip.CreateBlip(new Vector3(-2532.958, 2800.941, 0.8222725), 0);
        temp_blip.Sprite = 515;
        temp_blip.Name = "Schlangen Feld";
        temp_blip.Color = 22;
        temp_blip.ShortRange = true;

        temp_blip = NAPI.Blip.CreateBlip(new Vector3(1129.79, -3349.713, 5.900944), 0);
        temp_blip.Sprite = 280;
        temp_blip.Name = "Expo Leder";
        temp_blip.Color = 83;
        temp_blip.ShortRange = true;

        Pelz_positions.Add(new { position = new Vector3(-2532.958, 2800.941, 0.8222725) });

        foreach(var refinaria in Pelz_positions)
        {
            NAPI.Marker.CreateMarker(27, refinaria.position - new Vector3(0, 0, 0.8f), new Vector3(), new Vector3(), 5.0f, new Color(255, 255, 255, 110), false, 0);
        }

        for (var i = 0; i < Main.MAX_PLAYERS; i++)
        {
            sal_timer.Add(null);
        }
    }

    //452618762 --

    [Command("ro2")]
    public void removeob2(Client player)
    {
        player.TriggerEvent("remoooo");
    }

    public static void OnPlayerConnect(Client player)
    {
        player.SetData("Pelz_Refinando", false);
        player.SetData("Sal", 20);
        player.SetData("Pelz_RefinandoTime", 0);
        player.TriggerEvent("Sync_PedCreate", "refinar_pelzdealer", NAPI.Util.PedNameToModel("KTown01AMO"), new Vector3(-2290.787, 365.4806, 174.6016), 26.7976f, "", 0);
        player.TriggerEvent("Sync_PedCreate", "comprador_de_pelzdealer", NAPI.Util.PedNameToModel("GenStreet02AMY"), new Vector3(1129.79, -3349.713, 5.900944), 10.85808f, "", 0);
    }

    public static void PressKeyY(Client player)
    {
        foreach (var refinaria in Pelz_positions)
        {
            if(Main.IsInRangeOfPoint(player.Position, refinaria.position, 14f) && player.GetData("Pelz_Refinando") == false)
            {

                if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 88, 1, Inventory.Max_Inventory_Weight(player)) == true)
                {
                    return;
                }

                Inventory.GiveItemToInventory(player, 88, 1);

                player.SetData("Pelz_Refinando", true);
                player.PlayAnimation("amb@world_human_gardener_plant@male@base", "base", 1 << 0 | 1 << 5);
                Main.AttachObjectToEntity("prop_knife", player.Value, 28422);
                NAPI.Notification.SendNotificationToPlayer(player, "Sie haben ~g~ ~c~1~b~ Schlange~w~aufgehoben");
                NAPI.Util.ConsoleOutput("[GET JOB PELZE] " + player.SocialClubName + " hat eine Schlange aufgehoben! ");
                NAPI.Task.Run(() =>
                {
                    player.SetData("Pelz_Refinando", false);
                    player.StopAnimation();
                    Main.DeleteAttachedObject(player);
                }, delayTime: 3000);
            }
        }

        if(Main.IsInRangeOfPoint(player.Position, new Vector3(-2290.787, 365.4806, 174.6016), 3f))
        {
            if (Inventory.GetPlayerItemFromInventory(player, 88) >= 2 && player.GetData("Pelz_Refinando") == false)
            {
                if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 89, 1, Inventory.Max_Inventory_Weight(player)) == true)
                {
                    return;
                }
                //
                int sals = Inventory.GetPlayerItemFromInventory(player, 84);
                int pelz_a_ser_refinados = 0;

                //
                player.SetData("Pelz_Refinando", true);
                player.SetData("Pelz_RefinandoTime", 10);

                //
                player.TriggerEvent("freezeEx", true);
                player.PlayScenario("WORLD_HUMAN_GUARD_STAND");

                //
                NAPI.ClientEvent.TriggerClientEvent(player, "SetProgressBar", player.GetData("Pelz_RefinandoTime"), "Verarbeite Schlange zu Leder - " + pelz_a_ser_refinados + " von " + sals + "");

                //
                Pelz.sal_timer[Main.getIdFromClient(player)] = TimerEx.SetTimer(() =>
                {
                    //
                    if (Inventory.GetPlayerItemFromInventory(player, 88) >= 2)
                    {
                        // 
                        player.SetData("Pelz_RefinandoTime", player.GetData("Pelz_RefinandoTime") + 10);
                        NAPI.ClientEvent.TriggerClientEvent(player, "SetProgressBar", player.GetData("Pelz_RefinandoTime"), "Verarbeite Schlange zu Leder  - " + pelz_a_ser_refinados + " von " + sals + "");

                        if (player.GetData("Pelz_RefinandoTime") > 100)
                        {

                            //
                            pelz_a_ser_refinados += 2;

                            // Remove o Sal e conta tudo novamente.
                            Inventory.RemoveItem(player, "Schlange", 2);
                            Inventory.GiveItemToInventory(player, 89, 1);

                            //
                            player.SetData("Pelz_RefinandoTime", 0);
                            NAPI.ClientEvent.TriggerClientEvent(player, "SetProgressBar", player.GetData("Pelz_RefinandoTime"), "Verarbeite Schlange zu Leder  - " + pelz_a_ser_refinados + " von " + sals + "");

                            NAPI.Util.ConsoleOutput("[GET JOB PELZE] " + player.SocialClubName + " hat eine Schlange aufgehoben! #verarbeitet");
                            //
                            //player.TriggerEvent("createNewHeadNotificationAdvanced", "~g~+~w~ 1 Verarbeite Pelz zu Blut  !");
                            NAPI.Notification.SendNotificationToPlayer(player, "~g~+~w~ 1 Verarbeite Schlange zu Leder  !");

                            //
                            if (Inventory.GetPlayerItemFromInventory(player, 88) == 0)
                            {
                                if (Pelz.sal_timer[Main.getIdFromClient(player)] != null)
                                {
                                    Pelz.sal_timer[Main.getIdFromClient(player)].Kill();
                                    Pelz.sal_timer[Main.getIdFromClient(player)] = null;
                                }
                                player.SetData("Pelz_Refinando", false);
                                player.TriggerEvent("freezeEx", false);
                                player.TriggerEvent("DestroyProgressBar");
                            }
                        }
                    }
                    else
                    {
                        //
                        if (player.GetData("Pelz_Refinando") == true)
                        {
                            if (Pelz.sal_timer[Main.getIdFromClient(player)] != null)
                            {
                                Pelz.sal_timer[Main.getIdFromClient(player)].Kill();
                                Pelz.sal_timer[Main.getIdFromClient(player)] = null;
                            }
                            player.StopAnimation();
                            player.SetData("Pelz_Refinando", false);
                            player.TriggerEvent("freezeEx", false);
                            player.TriggerEvent("DestroyProgressBar");
                        }
                    }
                    if (player.GetData("status") == false)
                    {
                        try
                        {
                            Pelz.sal_timer[Main.getIdFromClient(player)].Kill();
                            Pelz.sal_timer[Main.getIdFromClient(player)] = null;
                        }
                        catch(Exception)
                        {

                        }
                    }
                }, 1000, 0);
            }
            else if(player.GetData("Pelz_Refinando") == true)
            {
                if (Pelz.sal_timer[Main.getIdFromClient(player)] != null)
                {
                    Pelz.sal_timer[Main.getIdFromClient(player)].Kill();
                    Pelz.sal_timer[Main.getIdFromClient(player)] = null;
                }
                player.StopAnimation();
                player.SetData("Pelz_Refinando", false);
                player.TriggerEvent("freezeEx", false);
                player.TriggerEvent("DestroyProgressBar");
            }
            
        }

        if (Main.IsInRangeOfPoint(player.Position, new Vector3(1129.79, -3349.713, 5.900944), 3.0f))
        {
            if (Inventory.GetPlayerItemFromInventory(player, 89) > 0)
            {
                InteractMenu.User_Input(player, "input_sell_pelz", " Leder verkaufen", Inventory.GetPlayerItemFromInventory(player, 89).ToString(), "Sie haben derzeit " + Inventory.GetPlayerItemFromInventory(player, 89) + "", "number");
            }
            else
            {
                player.TriggerEvent("Notification.SendPictureNotification", "System Information", "Job", $"Du hast was dafür vergessen!", "CHAR_CHEF", true);
            }
        }

    }

    public static void OnInputResponse(Client player, string response, string inputtext)
    {
        if(response == "input_sell_pelz")
        {
            if (Inventory.GetPlayerItemFromInventory(player, 89) > 0)
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

                if(Inventory.GetPlayerItemFromInventory(player, 89) < valor)
                {
                    Main.DisplayErrorMessage(player, "Sie versuchen Leder zu verkaufen " + valor + " doch Sie haben nur "+ Inventory.GetPlayerItemFromInventory(player, 85) + ".");
                    return;
                }

                Random rnd = new Random();
                int price = valor * rnd.Next(47, 87);

                Main.GivePlayerMoney(player, price);
                NAPI.Notification.SendNotificationToPlayer(player, "Du hast verkauft " + Main.EMBED_BLUE+""+ valor + ""+Main.EMBED_WHITE+ " Leder durch $" + price.ToString("N0") + ".");
                Inventory.RemoveItem(player, "Leder", valor);
            }
        }
    }

}

