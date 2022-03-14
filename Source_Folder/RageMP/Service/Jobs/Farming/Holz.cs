using System;
using System.Collections.Generic;
using System.Text;
using DerStr1k3r.SDK;
using DerStr1k3r.Core;
using GTANetworkAPI;
//Holz.OnInputResponse
class Holz : Script
{
    private static List<dynamic> Holz_positions = new List<dynamic>();
    public static List<TimerEx> sal_timer = new List<TimerEx>();

    public static void HolzInit()
    {
        Blip temp_blip = null;
        temp_blip = NAPI.Blip.CreateBlip(new Vector3(-636.1621, 5171.339, 103.3772), 0);
        temp_blip.Sprite = 515;
        temp_blip.Name = "Holz Feld";
        temp_blip.Color = 21;
        temp_blip.ShortRange = true;

        temp_blip = NAPI.Blip.CreateBlip(new Vector3(-567.3469, 5332.323, 70.21522), 0);
        temp_blip.Sprite = 515;
        temp_blip.Name = "Sägewerk";
        temp_blip.Color = 21;
        temp_blip.ShortRange = true;


        temp_blip = NAPI.Blip.CreateBlip(new Vector3(1201.699, -3349.795, 5.901858), 0);
        temp_blip.Sprite = 280;
        temp_blip.Name = "Expo Woods";
        temp_blip.Color = 83;
        temp_blip.ShortRange = true;

        Holz_positions.Add(new { position = new Vector3(-636.1621, 5171.339, 103.3772) });
        //Holz_positions.Add(new { position = new Vector3(-89.22218, 6210.221, 31.08841) });
        //Holz_positions.Add(new { position = new Vector3(-89.22218, 6210.221, 31.08841) });

        foreach(var refinaria in Holz_positions)
        {
            NAPI.Marker.CreateMarker(27, refinaria.position - new Vector3(0, 0, 0.8f), new Vector3(), new Vector3(), 5.0f, new Color(255, 255, 255, 110), false, 0);
         //   NAPI.TextLabel.CreateTextLabel("- Holz -~n~~n~Drücke ~y~E~w~ zum sammmeln", refinaria.position, 15f, 9f, 0, new Color(255, 255, 255, 100), false, 0);
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
        player.SetData("Holz_Refinando", false);
        player.SetData("Sal", 20);
        player.SetData("Holz_RefinandoTime", 0);
        player.TriggerEvent("Sync_PedCreate", "refinar_holzdealer", NAPI.Util.PedNameToModel("KTown01AMO"), new Vector3(-567.3469, 5332.323, 70.21522), 71.59953f, "", 0);
        player.TriggerEvent("Sync_PedCreate", "comprador_de_holzdealer", NAPI.Util.PedNameToModel("GenStreet02AMY"), new Vector3(1201.699, -3349.795, 5.901858), 359.0011f, "", 0);
    }

    public static void PressKeyY(Client player)
    {
        foreach (var refinaria in Holz_positions)
        {
            if(Main.IsInRangeOfPoint(player.Position, refinaria.position, 14f) && player.GetData("Holz_Refinando") == false)
            {

                if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 84, 1, Inventory.Max_Inventory_Weight(player)) == true)
                {
                    return;
                }

                Inventory.GiveItemToInventory(player, 84, 1);

                player.SetData("Holz_Refinando", true);
                player.PlayAnimation("amb@world_human_hammering@male@base", "base", 1 << 0 | 1 << 5);
                Main.AttachObjectToEntity("prop_tool_pickaxe", player.Value, 28422);
                //player.TriggerEvent("createNewHeadNotificationAdvanced", "Sie haben ~g~ ~c~1~b~ Holz~w~aufgehoben !");
                Notify.Send(player, NotifyType.Success, NotifyPosition.BottomCenter, $"Sie haben 1x Holz aufgehoben !", 5000);
                //NAPI.Notification.SendNotificationToPlayer(player, "Sie haben ~g~ ~c~1~b~ Holz~w~aufgehoben");
                //Main.SendNotificationBrowser(player, "", "<string>+ 1</strong> Holz in Ihrem Inventar hinzugefügt !", "success");

                NAPI.Task.Run(() =>
                {
                    player.SetData("Holz_Refinando", false);
                    player.StopAnimation();
                    Main.DeleteAttachedObject(player);
                }, delayTime: 1500);
            }
        }

        if(Main.IsInRangeOfPoint(player.Position, new Vector3(-567.3469, 5332.323, 70.21522), 3f))
        {
            if (Inventory.GetPlayerItemFromInventory(player, 84) >= 2 && player.GetData("Holz_Refinando") == false)
            {
                if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 85, 1, Inventory.Max_Inventory_Weight(player)) == true)
                {
                    return;
                }
                //
                int holz = Inventory.GetPlayerItemFromInventory(player, 84);
                int holz_a_ser_refinados = 0;

                //
                player.SetData("Holz_Refinando", true);
                player.SetData("Holz_RefinandoTime", 10);

                //
                player.TriggerEvent("freezeEx", true);
                player.PlayScenario("WORLD_HUMAN_GUARD_STAND");

                //
                NAPI.ClientEvent.TriggerClientEvent(player, "SetProgressBar", player.GetData("Holz_RefinandoTime"), "Verarbeite Holz zu Holzplatten - " + holz_a_ser_refinados + " von " + holz + "");

                //
                Holz.sal_timer[Main.getIdFromClient(player)] = TimerEx.SetTimer(() =>
                {
                    //
                    if (Inventory.GetPlayerItemFromInventory(player, 84) >= 2)
                    {
                        // 
                        player.SetData("Holz_RefinandoTime", player.GetData("Holz_RefinandoTime") + 10);
                        NAPI.ClientEvent.TriggerClientEvent(player, "SetProgressBar", player.GetData("Holz_RefinandoTime"), "Verarbeite Holz zu Holzplatten  - " + holz_a_ser_refinados + " von " + holz + "");

                        if (player.GetData("Holz_RefinandoTime") > 100)
                        {
                            //
                            holz_a_ser_refinados += 2;

                            // Remove o Sal e conta tudo novamente.
                            //Inventory.RemoveItem(player, "Holz", 2);
                            Inventory.RemoveItemByType(player, 84, 2);
                            Inventory.GiveItemToInventory(player, 85, 1);

                            //
                            player.SetData("Holz_RefinandoTime", 0);
                            NAPI.ClientEvent.TriggerClientEvent(player, "SetProgressBar", player.GetData("Holz_RefinandoTime"), "Verarbeite Holz zu Holzplatten  - " + holz_a_ser_refinados + " von " + holz + "");

                            //
                            //player.TriggerEvent("createNewHeadNotificationAdvanced", "~g~+~w~ 1 Verarbeite Holz zu Blut  !");
                            NAPI.Notification.SendNotificationToPlayer(player, "~g~+~w~ 1 Verarbeite Holz zu Holzplatten  !");

                            //
                            if (Inventory.GetPlayerItemFromInventory(player, 84) == 0)
                            {
                                if (Holz.sal_timer[Main.getIdFromClient(player)] != null)
                                {
                                    Holz.sal_timer[Main.getIdFromClient(player)].Kill();
                                    Holz.sal_timer[Main.getIdFromClient(player)] = null;
                                }
                                player.StopAnimation();
                                player.SetData("Holz_Refinando", false);
                                player.TriggerEvent("freezeEx", false);
                                player.TriggerEvent("DestroyProgressBar");
                            }
                        }
                    }
                    else
                    {
                        //
                        if (player.GetData("Holz_Refinando") == true)
                        {
                            if (Holz.sal_timer[Main.getIdFromClient(player)] != null)
                            {
                                Holz.sal_timer[Main.getIdFromClient(player)].Kill();
                                Holz.sal_timer[Main.getIdFromClient(player)] = null;
                            }
                            player.StopAnimation();
                            player.SetData("Holz_Refinando", false);
                            player.TriggerEvent("freezeEx", false);
                            player.TriggerEvent("DestroyProgressBar");
                        }
                    }
                    if (player.GetData("status") == false)
                    {
                        try
                        {
                            Holz.sal_timer[Main.getIdFromClient(player)].Kill();
                            Holz.sal_timer[Main.getIdFromClient(player)] = null;
                        }
                        catch(Exception)
                        {

                        }
                    }
                }, 1000, 0);
            }
            else if(player.GetData("Holz_Refinando") == true)
            {
                if (Holz.sal_timer[Main.getIdFromClient(player)] != null)
                {
                    Holz.sal_timer[Main.getIdFromClient(player)].Kill();
                    Holz.sal_timer[Main.getIdFromClient(player)] = null;
                }
                player.StopAnimation();
                player.SetData("Holz_Refinando", false);
                player.TriggerEvent("freezeEx", false);
                player.TriggerEvent("DestroyProgressBar");
            }
            
        }

        if (Main.IsInRangeOfPoint(player.Position, new Vector3(1201.699, -3349.795, 5.901858), 3.0f))
        {
            if (Inventory.GetPlayerItemFromInventory(player, 85) > 0)
            {
                InteractMenu.User_Input(player, "input_sell_holz", " Holzplatten verkaufen", Inventory.GetPlayerItemFromInventory(player, 85).ToString(), "Sie haben derzeit " + Inventory.GetPlayerItemFromInventory(player, 85) + "", "number");
            }
            else
            {
                player.TriggerEvent("Notification.SendPictureNotification", "System Information", "Job", $"Du hast was dafür vergessen!", "CHAR_CHEF", true);
            }
        }

    }

    public static void OnInputResponse(Client player, string response, string inputtext)
    {
        if(response == "input_sell_holz")
        {
            if (Inventory.GetPlayerItemFromInventory(player, 85) > 0)
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

                if(Inventory.GetPlayerItemFromInventory(player, 85) < valor)
                {
                    Main.DisplayErrorMessage(player, "Sie versuchen Holzplatten zu verkaufen " + valor + " doch Sie haben nur "+ Inventory.GetPlayerItemFromInventory(player, 85) + ".");
                    return;
                }

                Random rnd = new Random();
                int price = valor * rnd.Next(22, 45);

                Main.GivePlayerMoney(player, price);
                NAPI.Notification.SendNotificationToPlayer(player, "Du hast verkauft " + Main.EMBED_BLUE+""+ valor + ""+Main.EMBED_WHITE+ " Holzplatten durch $" + price.ToString("N0") + ".");
                Inventory.RemoveItemByType(player, 85, valor);
            }
        }
    }

}

