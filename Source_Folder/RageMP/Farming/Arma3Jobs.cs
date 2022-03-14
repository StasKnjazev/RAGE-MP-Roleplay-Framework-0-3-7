using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;
using DerStr1k3r.SDK;

class Arma3Jobs : Script
{
    private static nLog Log = new nLog("Salz");

    private static List<dynamic> refinaria_positions = new List<dynamic>();
    public static List<TimerEx> sal_timer = new List<TimerEx>();

    public static void Arma3JobsInit()
    {
        Blip temp_blip = null;
        temp_blip = NAPI.Blip.CreateBlip(new Vector3(2080.293, 3856.056, 33.21302), 0);
        temp_blip.Sprite = 515;
        temp_blip.Name = "Salz";
        temp_blip.Color = 38;
        temp_blip.ShortRange = true;

        temp_blip = NAPI.Blip.CreateBlip(new Vector3(2564.25, 4680.224, 34.07677), 0);
        temp_blip.Sprite = 515;
        temp_blip.Name = "Salz Verarbeiter";
        temp_blip.Color = 51;
        temp_blip.ShortRange = true;

        temp_blip = NAPI.Blip.CreateBlip(new Vector3(1298.114, -3194.987, 5.906411), 0);
        temp_blip.Sprite = 280;
        temp_blip.Name = "Expo Salz";
        temp_blip.Color = 83;
        temp_blip.ShortRange = true;

        refinaria_positions.Add(new { position = new Vector3(2090.284, 3886.263, 31.76323) });
        refinaria_positions.Add(new { position = new Vector3(2057.113, 3873.247, 31.6693) });
        refinaria_positions.Add(new { position = new Vector3(2045.156, 3906.454, 31.80743) });

        foreach(var refinaria in refinaria_positions)
        {
            NAPI.Marker.CreateMarker(27, refinaria.position - new Vector3(0, 0, 0.8f), new Vector3(), new Vector3(), 14.0f, new Color(255, 255, 255, 110), false, 0);
         //   NAPI.TextLabel.CreateTextLabel("- Salz -~n~~n~Drücke ~y~E~w~ zum sammmeln", refinaria.position, 15f, 9f, 0, new Color(255, 255, 255, 100), false, 0);
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
            player.SetData("Salz_Refinando", false);
            player.SetData("Sal", 20);
            player.SetData("Salz_RefinandoTime", 0);
            player.TriggerEvent("Sync_PedCreate", "sal_refinar", NAPI.Util.PedNameToModel("KTown01AMO"), new Vector3(2564.25, 4680.224, 34.07677), 45.28986f, "", 0);
            player.TriggerEvent("Sync_PedCreate", "comprador_de_sall", NAPI.Util.PedNameToModel("GenStreet02AMY"), new Vector3(1298.114, -3194.987, 5.906411), 87.85758f, "", 0);
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
            foreach (var refinaria in refinaria_positions)
            {
                if(Main.IsInRangeOfPoint(player.Position, refinaria.position, 14f) && player.GetData("Salz_Refinando") == false)
                {

                    if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 13, 3, Inventory.Max_Inventory_Weight(player)) == true)
                    {
                        return;
                    }

                    Inventory.GiveItemToInventory(player, 13, 3);

                    player.SetData("Salz_Refinando", true);
                    player.PlayAnimation("amb@world_human_gardener_plant@male@base", "base", 1 << 0 | 1 << 5);
                    Main.AttachObjectToEntity("prop_knife", player.Value, 28422);
                    //player.TriggerEvent("createNewHeadNotificationAdvanced", "Sie haben ~g~ ~c~3~b~ schmutziges Salz~w~aufgehoben !");
                    player.TriggerEvent("Notification.SendPictureNotification", "Salzfeld", "Job", $"+ 3x Salz in Ihrem Inventar hinzugefügt !", "CHAR_CHEF", true);

                    NAPI.Task.Run(() =>
                    {
                        player.SetData("Salz_Refinando", false);
                        player.StopAnimation();
                        Main.DeleteAttachedObject(player);
                    }, delayTime: 3500);
                }

                if(Main.IsInRangeOfPoint(player.Position, new Vector3(2564.25, 4680.224, 34.07677), 3f))
                {
                    if (Inventory.GetPlayerItemFromInventory(player, 13) >= 3 && player.GetData("Salz_Refinando") == false)
                    {
                    //
                    int sals = Inventory.GetPlayerItemFromInventory(player, 13);
                    int sals_a_ser_refinados = 0;

                    //
                    player.SetData("Salz_Refinando", true);
                    player.SetData("Salz_RefinandoTime", 10);

                    //
                    player.TriggerEvent("freezeEx", true);
                    player.PlayScenario("WORLD_HUMAN_GUARD_STAND");

                    //
                    NAPI.ClientEvent.TriggerClientEvent(player, "SetProgressBar", player.GetData("Salz_RefinandoTime"), "Verarbeite Salz - " + sals_a_ser_refinados + " von " + sals + "");

                        //
                    Arma3Jobs.sal_timer[Main.getIdFromClient(player)] = TimerEx.SetTimer(() =>
                    {
                        //
                        if (Inventory.GetPlayerItemFromInventory(player, 13) >= 3)
                        {
                            if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 14, 1, Inventory.Max_Inventory_Weight(player)) == true)
                            {
                                return;
                            }

                        // 
                        player.SetData("Salz_RefinandoTime", player.GetData("Salz_RefinandoTime") + 10);
                        NAPI.ClientEvent.TriggerClientEvent(player, "SetProgressBar", player.GetData("Salz_RefinandoTime"), "Verarbeite Salz - " + sals_a_ser_refinados + " von " + sals + "");

                        if (player.GetData("Salz_RefinandoTime") > 100)
                        {
                            //
                            sals_a_ser_refinados += 3;

                            // Remove o Sal e conta tudo novamente.
                            Inventory.RemoveItem(player, "schmutziges Salz", 3);
                            Inventory.GiveItemToInventory(player, 14, 1);

                            //
                            player.SetData("Salz_RefinandoTime", 0);
                            NAPI.ClientEvent.TriggerClientEvent(player, "SetProgressBar", player.GetData("Salz_RefinandoTime"), "Verarbeite Salz - " + sals_a_ser_refinados + " von " + sals + "");

                            player.TriggerEvent("Notification.SendPictureNotification", "Salz Verarbeiter", "Job", $"+ 1 Verarbeite Salz !", "CHAR_CHEF", true);

                            //
                            if (Inventory.GetPlayerItemFromInventory(player, 13) == 0)
                            {
                                if (Arma3Jobs.sal_timer[Main.getIdFromClient(player)] != null)
                                {
                                    Arma3Jobs.sal_timer[Main.getIdFromClient(player)].Kill();
                                    Arma3Jobs.sal_timer[Main.getIdFromClient(player)] = null;
                                }
                                player.StopAnimation();
                                player.SetData("Salz_Refinando", false);
                                player.TriggerEvent("freezeEx", false);
                                player.TriggerEvent("DestroyProgressBar");
                            }
                        }
                    }
                    else
                    {
                        //
                        if (player.GetData("Salz_Refinando") == true)
                        {
                            if (Arma3Jobs.sal_timer[Main.getIdFromClient(player)] != null)
                            {
                                Arma3Jobs.sal_timer[Main.getIdFromClient(player)].Kill();
                                Arma3Jobs.sal_timer[Main.getIdFromClient(player)] = null;
                            }
                            player.StopAnimation();
                            player.SetData("Salz_Refinando", false);
                            player.TriggerEvent("freezeEx", false);
                            player.TriggerEvent("DestroyProgressBar");
                        }
                    }
                    if (player.GetData("status") == false)
                    {
                        try
                        {
                            Arma3Jobs.sal_timer[Main.getIdFromClient(player)].Kill();
                            Arma3Jobs.sal_timer[Main.getIdFromClient(player)] = null;
                        }
                        catch(Exception)
                        {

                        }
                    }
                    }, 1000, 0);
                    }
                    else if(player.GetData("Salz_Refinando") == true)
                    {
                        if (Arma3Jobs.sal_timer[Main.getIdFromClient(player)] != null)
                        {
                            Arma3Jobs.sal_timer[Main.getIdFromClient(player)].Kill();
                            Arma3Jobs.sal_timer[Main.getIdFromClient(player)] = null;
                        }
                        player.StopAnimation();
                        player.SetData("Salz_Refinando", false);
                        player.TriggerEvent("freezeEx", false);
                        player.TriggerEvent("DestroyProgressBar");
                    }
                }

                if (Main.IsInRangeOfPoint(player.Position, new Vector3(1298.114, -3194.987, 5.906411), 3.0f))
                {
                    if (Inventory.GetPlayerItemFromInventory(player, 14) > 0)
                    {
                        InteractMenu.User_Input(player, "input_sell_salt", " Salz verkaufen", Inventory.GetPlayerItemFromInventory(player, 14).ToString(), "Sie haben derzeit " + Inventory.GetPlayerItemFromInventory(player, 14) + "", "number");
                    }
                    else
                    {
                        NAPI.Notification.SendNotificationToPlayer(player, "Du hast kein Salz!");
                    }
                }
            }
        }
        catch (Exception e) { 
            Log.Write("ResourceStart: " + e.Message, nLog.Type.Error); 
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
                    Main.DisplayErrorMessage(player, "Der eingegebene Wert ist nicht numerisch. Bitte geben Sie einen gültigen Wert ein.");
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
                    Main.DisplayErrorMessage(player, "Sie versuchen Salz zu verkaufen "+ valor + " doch Sie haben nur "+ Inventory.GetPlayerItemFromInventory(player, 14) + ".");
                    return;
                }

                Random rnd = new Random();
                int price = valor * rnd.Next(17, 43);

                Main.GivePlayerMoney(player, price);
                player.TriggerEvent("Notification.SendPictureNotification", "Apfel Kuchen Ankäufer", "Job", $"Du hast verkauft " + valor + " Salz (e) durch $" + price.ToString("N0") + ".", "CHAR_CHEF", true);
                Inventory.RemoveItem(player, "Salz", valor);
            }
        }
    }
}

