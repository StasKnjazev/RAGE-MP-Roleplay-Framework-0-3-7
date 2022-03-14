using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;
using DerStr1k3r.SDK;

class Apfel : Script
{
    private static nLog Log = new nLog("Apfel");

    private static List<dynamic> apfel_positions = new List<dynamic>();
    public static List<TimerEx> sal_timer = new List<TimerEx>();

    public static void ApfelInit()
    {
        //NAPI.Util.ConsoleOutput("[Jobs] Apfel.");

        Blip temp_blip = null;
        temp_blip = NAPI.Blip.CreateBlip(new Vector3(370.1487, 6518.201, 28.37784), 0);
        temp_blip.Sprite = 515;
        temp_blip.Name = "Apfel Feld";
        temp_blip.Color = 83;
        temp_blip.ShortRange = true;

        temp_blip = NAPI.Blip.CreateBlip(new Vector3(1692.175, 3785.757, 34.76764), 0);
        temp_blip.Sprite = 480;
        temp_blip.Name = "Bäckerei";
        temp_blip.Color = 83;
        temp_blip.ShortRange = true;

        temp_blip = NAPI.Blip.CreateBlip(new Vector3(1244.571, -2949.847, 9.319254), 0);
        temp_blip.Sprite = 280;
        temp_blip.Name = "Expo Bäckerei";
        temp_blip.Color = 83;
        temp_blip.ShortRange = true;

        apfel_positions.Add(new { position = new Vector3(370.1487, 6518.201, 28.37784) });
        apfel_positions.Add(new { position = new Vector3(338.8145, 6517.671, 28.92393) });
        apfel_positions.Add(new { position = new Vector3(321.8523, 6517.972, 29.13893) });

        foreach(var refinaria in apfel_positions)
        {
            NAPI.Marker.CreateMarker(27, refinaria.position - new Vector3(0, 0, 0.8f), new Vector3(), new Vector3(), 3.0f, new Color(255, 255, 255, 110), false, 0);
            //NAPI.TextLabel.CreateTextLabel("- Apfel -~n~~n~Drücke ~y~E~w~ zum sammmeln", refinaria.position, 5f, 9f, 0, new Color(255, 255, 255, 100), false, 0);
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
        try
        {
            player.SetData("Apfel_Refinando", false);
            player.SetData("Sal", 20);
            player.SetData("Apfel_RefinandoTime", 0);
            player.TriggerEvent("Sync_PedCreate", "apfel_refinar", NAPI.Util.PedNameToModel("KTown01AMO"), new Vector3(1692.175, 3785.757, 34.76764), 45.28986f, "", 0);
            player.TriggerEvent("Sync_PedCreate", "comprador_de_apfel", NAPI.Util.PedNameToModel("GenStreet02AMY"), new Vector3(1244.571, -2949.847, 9.319254), 175.325f, "", 0);
        }
        catch (Exception e) { 
            Log.Write("ResourceStart: " + e.Message, nLog.Type.Error); 
        }
    }

    public static void PressKeyY(Client player)
    {
        try
        {
            foreach (var refinaria in apfel_positions)
            {
                if(Main.IsInRangeOfPoint(player.Position, refinaria.position, 5f) && player.GetData("Apfel_Refinando") == false)
                {

                    if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 56, 1, Inventory.Max_Inventory_Weight(player)) == true)
                    {
                        return;
                    }

                    Inventory.GiveItemToInventory(player, 56, 1);

                    player.SetData("Apfel_Refinando", true);
                    NAPI.Player.PlayPlayerAnimation(player, (int)(Main.AnimationFlags.Loop), "anim@mp_snowball", "pickup_snowball");
                
                    player.TriggerEvent("Notification.SendPictureNotification", "Apfelfeld", "Job", $"+ 1 Apfel in Ihrem Inventar hinzugefügt !", "CHAR_BANK_MAZE", true);

                    NAPI.Util.ConsoleOutput("[GET JOB APFEL] " + player.SocialClubName + " hat ein Apfel aufgehoben! ");

                    NAPI.Task.Run(() =>
                    {
                        player.SetData("Apfel_Refinando", false);
                        player.StopAnimation();
                    }, delayTime: 11500);
                }
            }

            if(Main.IsInRangeOfPoint(player.Position, new Vector3(1692.175, 3785.757, 34.76764), 3f))
            {
                if (Inventory.GetPlayerItemFromInventory(player, 56) >= 3 && player.GetData("Apfel_Refinando") == false)
                {
                //
                    int apfel = Inventory.GetPlayerItemFromInventory(player, 56);
                    int apfel_a_ser_refinados = 0;
                //
                    player.SetData("Apfel_Refinando", true);
                    player.SetData("Apfel_RefinandoTime", 5);

                    player.TriggerEvent("freezeEx", true);
                    player.PlayScenario("WORLD_HUMAN_GUARD_STAND");

                //
                    NAPI.ClientEvent.TriggerClientEvent(player, "SetProgressBar", player.GetData("Apfel_RefinandoTime"), "Verarbeite Apfel - " + apfel_a_ser_refinados + " von " + apfel + "");
                //
                    Apfel.sal_timer[Main.getIdFromClient(player)] = TimerEx.SetTimer(() =>
                    {
                        //
                        if (Inventory.GetPlayerItemFromInventory(player,56) >= 3)
                        {
                            if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 57, 1, Inventory.Max_Inventory_Weight(player)) == true)
                            {
                                return;
                            }

                        // 
                            player.SetData("Apfel_RefinandoTime", player.GetData("Apfel_RefinandoTime") + 5);
                            NAPI.ClientEvent.TriggerClientEvent(player, "SetProgressBar", player.GetData("Apfel_RefinandoTime"), "Verarbeite Apfel - " + apfel_a_ser_refinados + " von " + apfel + "");

                            if (player.GetData("Apfel_RefinandoTime") > 100)
                            {
                            //
                                apfel_a_ser_refinados += 3;

                            // Remove o Sal e conta tudo novamente.
                                Inventory.RemoveItem(player, "Apfel", 3);
                                Inventory.GiveItemToInventory(player, 57, 1);

                            //
                                player.SetData("Apfel_RefinandoTime", 0);
                                NAPI.ClientEvent.TriggerClientEvent(player, "SetProgressBar", player.GetData("Apfel_RefinandoTime"), "Verarbeite Apfel - " + apfel_a_ser_refinados + " von " + apfel + "");

                                NAPI.Util.ConsoleOutput("[GET JOB APFEL] " + player.SocialClubName + " hat ein Apfel verarbeitet! ");
                            //
                                player.TriggerEvent("Notification.SendPictureNotification", "Apfel Verarbeiter", "Job", $"1x Verarbeiten Apfel !", "CHAR_BANK_MAZE", true);
                            //
                                if (Inventory.GetPlayerItemFromInventory(player, 57) == 0)
                                {
                                    if (Apfel.sal_timer[Main.getIdFromClient(player)] != null)
                                    {
                                        Apfel.sal_timer[Main.getIdFromClient(player)].Kill();
                                        Apfel.sal_timer[Main.getIdFromClient(player)] = null;
                                    }
                                    player.StopAnimation();
                                    player.SetData("Apfel_Refinando", false);
                                    player.TriggerEvent("freezeEx", false);
                                    player.TriggerEvent("DestroyProgressBar");
                                }
                            }
                        }
                        else
                        {
                        //
                            if (player.GetData("Apfel_Refinando") == true)
                            {
                                if (Apfel.sal_timer[Main.getIdFromClient(player)] != null)
                                {
                                    Apfel.sal_timer[Main.getIdFromClient(player)].Kill();
                                    Apfel.sal_timer[Main.getIdFromClient(player)] = null;
                                }
                                player.StopAnimation();
                                player.SetData("Apfel_Refinando", false);
                                player.TriggerEvent("freezeEx", false);
                                player.TriggerEvent("DestroyProgressBar");
                            }
                        }
                        if (player.GetData("status") == false)
                        {
                            try
                            {
                                Apfel.sal_timer[Main.getIdFromClient(player)].Kill();
                                Apfel.sal_timer[Main.getIdFromClient(player)] = null;
                            }
                            catch(Exception)
                            {

                            }
                        }
                    }, 1000, 0);
                }
                else if(player.GetData("Apfel_Refinando") == true)
                {
                    if (Apfel.sal_timer[Main.getIdFromClient(player)] != null)
                    {
                        Apfel.sal_timer[Main.getIdFromClient(player)].Kill();
                        Apfel.sal_timer[Main.getIdFromClient(player)] = null;
                    }
                    player.StopAnimation();
                    player.SetData("Apfel_Refinando", false);
                    player.TriggerEvent("freezeEx", false);
                    player.TriggerEvent("DestroyProgressBar");
                }
            }

            if (Main.IsInRangeOfPoint(player.Position, new Vector3(1244.571, -2949.847, 9.319254), 3.0f))
            {
                if (Inventory.GetPlayerItemFromInventory(player, 57) > 0)
                {
                    InteractMenu.User_Input(player, "input_sell_apfel", " Apfel Kuchen verkaufen", Inventory.GetPlayerItemFromInventory(player, 57).ToString(), "Sie haben derzeit " + Inventory.GetPlayerItemFromInventory(player, 57) + "", "number");
                }
                else
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "Du hast keinen Apfelkuchen !");
                }
            }
        }
        catch (Exception e) { 
            Log.Write("ResourceStart: " + e.Message, nLog.Type.Error); 
        }
    }

    public static void OnInputResponse(Client player, string response, string inputtext)
    {
        if(response == "input_sell_apfel")
        {
            if (Inventory.GetPlayerItemFromInventory(player, 57) > 0)
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

                if(Inventory.GetPlayerItemFromInventory(player, 57) < valor)
                {
                    Main.DisplayErrorMessage(player, "Sie versuchen Apfel Kuchen zu verkaufen "+ valor + " doch Sie haben nur "+ Inventory.GetPlayerItemFromInventory(player, 57) + ".");
                    return;
                }

                Random rnd = new Random();
                int price = valor * rnd.Next(28, 44);

                Main.GivePlayerMoney(player, price);
                player.TriggerEvent("Notification.SendPictureNotification", "Apfel Kuchen Ankäufer", "Job", $"Du hast verkauft " + valor + " Apfel Kuchen durch $" + price.ToString("N0") + ".", "CHAR_CHEF", true);
                Inventory.RemoveItem(player, "Apfel Kuchen", valor);
            }
        }
    }
}

