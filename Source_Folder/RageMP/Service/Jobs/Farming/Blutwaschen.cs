using System;
using System.Collections.Generic;
using System.Text;
using DerStr1k3r.SDK;
using DerStr1k3r.Core;
using GTANetworkAPI;
//Blutwaschen.OnInputResponse
class Blutwaschen : Script
{
    private static List<dynamic> blutwaschen_positions = new List<dynamic>();
    public static List<TimerEx> sal_timer = new List<TimerEx>();

    public static void BlutwaschenInit()
    {
        blutwaschen_positions.Add(new { position = new Vector3(-89.22218, 6210.221, 31.08841) });
        //blutwaschen_positions.Add(new { position = new Vector3(-89.22218, 6210.221, 31.08841) });
        //blutwaschen_positions.Add(new { position = new Vector3(-89.22218, 6210.221, 31.08841) });

        foreach(var refinaria in blutwaschen_positions)
        {
            NAPI.Marker.CreateMarker(27, refinaria.position - new Vector3(0, 0, 0.8f), new Vector3(), new Vector3(), 14.0f, new Color(255, 255, 255, 110), false, 0);
         //   NAPI.TextLabel.CreateTextLabel("- Kadaver -~n~~n~Drücke ~y~E~w~ zum sammmeln", refinaria.position, 15f, 9f, 0, new Color(255, 255, 255, 100), false, 0);
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
        player.SetData("Blutwaschen_Refinando", false);
        player.SetData("Sal", 20);
        player.SetData("Blutwaschen_RefinandoTime", 0);
        player.TriggerEvent("Sync_PedCreate", "bloodw_refinar", NAPI.Util.PedNameToModel("KTown01AMO"), new Vector3(1700.583, 3294.279, 48.92205), 45.28986f, "", 0);
        player.TriggerEvent("Sync_PedCreate", "comprador_de_bloodw", NAPI.Util.PedNameToModel("GenStreet02AMY"), new Vector3(3438.595, 3648.91, 42.59587), 4.437579f, "", 0);
    }

    public static void PressKeyY(Client player)
    {
        foreach (var refinaria in blutwaschen_positions)
        {
            if(Main.IsInRangeOfPoint(player.Position, refinaria.position, 14f) && player.GetData("Blutwaschen_Refinando") == false)
            {

                if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 44, 1, Inventory.Max_Inventory_Weight(player)) == true)
                {
                    return;
                }

                Inventory.GiveItemToInventory(player, 44, 1);

                player.SetData("Blutwaschen_Refinando", true);
                player.PlayAnimation("anim@mp_snowball", "pickup_snowball", 1 << 0 | 1 << 5);
                //player.TriggerEvent("createNewHeadNotificationAdvanced", "Sie haben ~g~ ~c~1~b~ Kadaver~w~aufgehoben !");
                //NAPI.Notification.SendNotificationToPlayer(player, "Sie haben ~g~ ~c~1x~b~ Kadaver~w~aufgehoben");
                Notify.Send(player, NotifyType.Success, NotifyPosition.BottomCenter, $"Sie haben 1x Kadaver aufgehoben !", 5000);
                Main.SendNotificationBrowser(player, "", "<string>+ 1</strong> Kadaver in Ihrem Inventar hinzugefügt !", "success");

                NAPI.Task.Run(() =>
                {
                    player.SetData("Blutwaschen_Refinando", false);
                    player.StopAnimation();
                }, delayTime: 1500);
            }
        }

        if(Main.IsInRangeOfPoint(player.Position, new Vector3(1700.583, 3294.279, 48.92205), 3f))
        {
            if (Inventory.GetPlayerItemFromInventory(player, 44) >= 2 && player.GetData("Blutwaschen_Refinando") == false)
            {
                //
                int sals = Inventory.GetPlayerItemFromInventory(player, 44);
                int sals_a_ser_refinados = 0;

                //
                player.SetData("Blutwaschen_Refinando", true);
                player.SetData("Blutwaschen_RefinandoTime", 20);

                //
                player.TriggerEvent("freezeEx", true);
                player.PlayScenario("WORLD_HUMAN_GUARD_STAND");

                //
                player.TriggerEvent("SetProgressBar", player.GetData("Blutwaschen_RefinandoTime"), "Verarbeite Kadaver zu Blut - " + sals_a_ser_refinados + " von " + sals + "");

                //
                sal_timer[Main.getIdFromClient(player)] = TimerEx.SetTimer(() =>
                {
                    //
                    if (Inventory.GetPlayerItemFromInventory(player,44) >= 2)
                    {
                        // 
                        player.SetData("Blutwaschen_RefinandoTime", player.GetData("Blutwaschen_RefinandoTime") + 20);
                        player.TriggerEvent("SetProgressBar", player.GetData("Blutwaschen_RefinandoTime"), "Verarbeite Kadaver zu Blut  - " + sals_a_ser_refinados + " von " + sals + "");

                        if (player.GetData("Blutwaschen_RefinandoTime") > 100)
                        {
                            //
                            sals_a_ser_refinados += 2;

                            // Remove o Sal e conta tudo novamente.
                            Inventory.RemoveItemByType(player, 44, 2);
                            //Inventory.RemoveItem(player, "Kadaver", 2);
                            Inventory.GiveItemToInventory(player, 45, 1);

                            //
                            player.SetData("Blutwaschen_RefinandoTime", 0);
                            player.TriggerEvent("SetProgressBar", player.GetData("Blutwaschen_RefinandoTime"), "Verarbeite Kadaver zu Blut  - " + sals_a_ser_refinados + " von " + sals + "");

                            //
                            //player.TriggerEvent("createNewHeadNotificationAdvanced", "~g~+~w~ 1 Verarbeite Kadaver zu Blut  !");
                            NAPI.Notification.SendNotificationToPlayer(player, "~g~+~w~ 1 Verarbeite Kadaver zu Blut  !");

                            //
                            if (Inventory.GetPlayerItemFromInventory(player, 44) == 0)
                            {
                                if (Blutwaschen.sal_timer[Main.getIdFromClient(player)] != null)
                                {
                                    Blutwaschen.sal_timer[Main.getIdFromClient(player)].Kill();
                                    Blutwaschen.sal_timer[Main.getIdFromClient(player)] = null;
                                }
                                player.StopAnimation();
                                player.SetData("Blutwaschen_Refinando", false);
                                player.TriggerEvent("freezeEx", false);
                                player.TriggerEvent("DestroyProgressBar");
                            }
                        }
                    }
                    else
                    {
                        //
                        if (player.GetData("Blutwaschen_Refinando") == true)
                        {
                            if (Blutwaschen.sal_timer[Main.getIdFromClient(player)] != null)
                            {
                                Blutwaschen.sal_timer[Main.getIdFromClient(player)].Kill();
                                Blutwaschen.sal_timer[Main.getIdFromClient(player)] = null;
                            }
                            player.StopAnimation();
                            player.SetData("Blutwaschen_Refinando", false);
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
            else if(player.GetData("Blutwaschen_Refinando") == true)
            {
                if (sal_timer[Main.getIdFromClient(player)] != null)
                {
                    sal_timer[Main.getIdFromClient(player)].Kill();
                    sal_timer[Main.getIdFromClient(player)] = null;
                }
                player.StopAnimation();
                player.SetData("Blutwaschen_Refinando", false);
                player.TriggerEvent("freezeEx", false);
                player.TriggerEvent("DestroyProgressBar");
            }
            
        }

        if (Main.IsInRangeOfPoint(player.Position, new Vector3(3438.595, 3648.91, 42.59587), 3.0f))
        {
            if (Inventory.GetPlayerItemFromInventory(player, 45) > 0)
            {
                InteractMenu.User_Input(player, "input_sell_blutwaschen", " Blut verkaufen", Inventory.GetPlayerItemFromInventory(player, 45).ToString(), "Sie haben derzeit " + Inventory.GetPlayerItemFromInventory(player, 45) + "", "number");
            }
            else
            {
                NAPI.ClientEvent.TriggerClientEvent(player, "Notification.SendPictureNotification", "System Information", "Job", $"Du hast was dafür vergessen!", "CHAR_CHEF", true);
            }
        }

    }

    public static void OnInputResponse(Client player, string response, string inputtext)
    {
        if(response == "input_sell_blutwaschen")
        {
            if (Inventory.GetPlayerItemFromInventory(player, 45) > 0)
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

                if(Inventory.GetPlayerItemFromInventory(player, 45) < valor)
                {
                    Main.DisplayErrorMessage(player, "Sie versuchen Blut zu verkaufen "+ valor + " doch Sie haben nur "+ Inventory.GetPlayerItemFromInventory(player, 45) + ".");
                    return;
                }

                Random rnd = new Random();
                int price = valor * rnd.Next(75, 84);

                Main.GivePlayerMoney(player, price);
                NAPI.Notification.SendNotificationToPlayer(player, "Du hast verkauft " + Main.EMBED_BLUE+""+ valor + ""+Main.EMBED_WHITE+ " Blut durch $"+ price.ToString("N0") + ".");
                Inventory.RemoveItemByType(player, 45, valor);
            }
        }
    }

}

