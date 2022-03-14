using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;

class WeaponCrafting : Script
{
    class Dealer
    {
        public Vector3 Position;
        public float Rotation;

        public Dealer(Vector3 position, float rotation)
        {
            Position = position;
            Rotation = rotation;
        }
    }

    private static List<dynamic> refinaria_positions = new List<dynamic>();
    public static List<TimerEx> sal_timer = new List<TimerEx>();
    private static List<Dealer> _dealerPositions3;
    private static List<uint> _dealerHashs;
    public static int DealerIndex = 0;
    public static int DealerHash = 0;

    public static void WeaponCraftingInit()
    {
        //NAPI.Util.ConsoleOutput("[Jobs] WeaponCrafting.");

        Blip temp_blip = null;
        temp_blip = NAPI.Blip.CreateBlip(new Vector3(844.0646, -1035.391, 28.19486), 0);
        temp_blip.Sprite = 461;
        temp_blip.Name = "Waffen Ankäufer";
        temp_blip.Color = 4;
        temp_blip.ShortRange = true;

        _dealerPositions3 = new List<Dealer>
        {
            new Dealer(new Vector3(-553.3751, 307.9679, 81.742 ), -91.42896f),
            new Dealer(new Vector3(-277.0289, 204.4182, 84.25507 ), -57.33409f),
            new Dealer(new Vector3(-1520.694, -411.7015, 34.027 ), -13.56122f),
            new Dealer(new Vector3(-1007.824, 6535.076, -32.67678 ), -130.953f),
            new Dealer(new Vector3(-705.4124, -2537.478, 12.51044 ), -134.9447f),
            new Dealer(new Vector3(-1296.669, -619.4992, 25.61686 ), 179.1598f),
        };

        _dealerHashs = new List<uint>(new[] { 0xF0EC56E2, 0xFDA94268, 0xBDA21E5C, 0x9D0087A8, 0xA28E71D7, 0xFD1C49BB });

        for (var i = 0; i < Main.MAX_PLAYERS; i++)
        {
            sal_timer.Add(null);
        }
    }

    public static void OnPlayerConnect(Client player)
    {
        var rnddealer = new Random();

        DealerIndex = rnddealer.Next(0, _dealerPositions3.Count);
        DealerHash = rnddealer.Next(0, _dealerHashs.Count);

        player.SetData("Refinando", false);
        player.SetData("Sal", 20);
        player.SetData("RefinandoTime", 0);
        player.TriggerEvent("Sync_PedCreate", "weaponcrafting_refinar", NAPI.Util.PedNameToModel("KTown01AMO"), new Vector3(2518.894, 2578.546, 37.94483), 45.28986f, "", 0);
        player.TriggerEvent("Sync_PedCreate", "comprador_de_weaponcrafting", NAPI.Util.PedNameToModel("GenStreet02AMY"), new Vector3(844.0646, -1035.391, 28.19486), 4.437579f, "", 0);
        player.TriggerEvent("Sync_PedCreate", "comprador_de_weaponcrafting", NAPI.Util.PedNameToModel("GenStreet02AMY"), new Vector3(-1520.694, -411.7015, 34.027), "", 0);
    }

    public static void PressKeyY(Client player)
    {
        // MetalBlock Ersteller
       if (Main.IsInRangeOfPoint(player.Position, new Vector3(2518.894, 2578.546, 37.94483), 3f))
        {
            if (Inventory.GetPlayerItemFromInventory(player, 67) >= 2 && player.GetData("Refinando") == false)
            {
                int sals = Inventory.GetPlayerItemFromInventory(player, 67);
                int sals_a_ser_refinados = 0;

                //
                player.SetData("Refinando", true);
                player.SetData("RefinandoTime", 1);

                //
                player.TriggerEvent("freezeEx", true);
                player.PlayScenario("WORLD_HUMAN_GUARD_STAND");

                //
                player.TriggerEvent("SetProgressBar", player.GetData("RefinandoTime"), "Verarbeite Metal - " + sals_a_ser_refinados + " von " + sals + " zu ein Block");

                WeaponCrafting.sal_timer[Main.getIdFromClient(player)] = TimerEx.SetTimer(() =>
                {
                    //
                    if (Inventory.GetPlayerItemFromInventory(player, 67) >= 2)
                    {
                        player.SetData("RefinandoTime", player.GetData("RefinandoTime") + 1);
                        player.TriggerEvent("SetProgressBar", player.GetData("RefinandoTime"), "Verarbeite Metal - " + sals_a_ser_refinados + " von " + sals + " zu ein Block");

                        if (player.GetData("RefinandoTime") > 100)
                        {
                            //
                            sals_a_ser_refinados += 2;

                            // Remove o Sal e conta tudo novamente.
                            Inventory.RemoveItem(player, "Metal", 2);
                            //Inventory.RemoveItem(player, "Sack", 1);
                            // MetalBlock
                            Inventory.GiveItemToInventory(player, 68, 1);

                            //
                            player.SetData("RefinandoTime", 0);
                            player.TriggerEvent("SetProgressBar", player.GetData("RefinandoTime"), "Verarbeite Metal - " + sals_a_ser_refinados + " von " + sals + " zu ein Block");

                            //
                            player.TriggerEvent("createNewHeadNotificationAdvanced", "~g~+~w~ 1x Verarbeiten MetalBlock erhalten!");

                            if (Inventory.GetPlayerItemFromInventory(player, 67) == 0)
                            {
                                if (WeaponCrafting.sal_timer[Main.getIdFromClient(player)] != null)
                                {
                                    WeaponCrafting.sal_timer[Main.getIdFromClient(player)].Kill();
                                    WeaponCrafting.sal_timer[Main.getIdFromClient(player)] = null;
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
                            if (WeaponCrafting.sal_timer[Main.getIdFromClient(player)] != null)
                            {
                                WeaponCrafting.sal_timer[Main.getIdFromClient(player)].Kill();
                                WeaponCrafting.sal_timer[Main.getIdFromClient(player)] = null;
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
                            WeaponCrafting.sal_timer[Main.getIdFromClient(player)].Kill();
                            WeaponCrafting.sal_timer[Main.getIdFromClient(player)] = null;
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

        // Waffen Ersteller
        if (Main.IsInRangeOfPoint(player.Position, new Vector3(-1520.694, -411.7015, 34.027), 3f))
        {
            if (Inventory.GetPlayerItemFromInventory(player, 68) >= 2 && Inventory.GetPlayerItemFromInventory(player, 99) >= 1 && player.GetData("Refinando") == false)
            {
                //
                int sals = Inventory.GetPlayerItemFromInventory(player, 68);
                int sals_a_ser_refinados = 0;

                //
                player.SetData("Refinando", true);
                player.SetData("RefinandoTime", 1);

                //
                player.TriggerEvent("freezeEx", true);
                player.PlayScenario("WORLD_HUMAN_GUARD_STAND");

                //
                player.TriggerEvent("SetProgressBar", player.GetData("RefinandoTime"), "Erstelle Waffe - " + sals_a_ser_refinados + " von " + sals + "");

                //
                WeaponCrafting.sal_timer[Main.getIdFromClient(player)] = TimerEx.SetTimer(() =>
                {
                    //
                    if (Inventory.GetPlayerItemFromInventory(player, 68) >= 2 && Inventory.GetPlayerItemFromInventory(player, 99) >= 1)
                    {
                        // 
                        player.SetData("RefinandoTime", player.GetData("RefinandoTime") + 1);
                        player.TriggerEvent("SetProgressBar", player.GetData("RefinandoTime"), "Erstelle Waffe - " + sals_a_ser_refinados + " von " + sals + "");

                        if (player.GetData("RefinandoTime") > 100)
                        {
                            //
                            sals_a_ser_refinados += 1;

                            // Remove o Sal e conta tudo novamente.
                            Inventory.RemoveItem(player, "MetalBlock", 2);
                            Inventory.RemoveItem(player, "Griff", 1);
                            //Inventory.RemoveItem(player, "ElektroDraht", 1);
                            Inventory.GiveItemToInventory(player, 64, 1);

                            //
                            player.SetData("RefinandoTime", 0);
                            player.TriggerEvent("SetProgressBar", player.GetData("RefinandoTime"), "Erstelle Waffe - " + sals_a_ser_refinados + " von " + sals + "");

                            //
                            player.TriggerEvent("createNewHeadNotificationAdvanced", "~g~+~w~ 1x Waffe erhalten!");

                            //
                            if (Inventory.GetPlayerItemFromInventory(player, 68) == 0)
                            {
                                if (WeaponCrafting.sal_timer[Main.getIdFromClient(player)] != null)
                                {
                                    WeaponCrafting.sal_timer[Main.getIdFromClient(player)].Kill();
                                    WeaponCrafting.sal_timer[Main.getIdFromClient(player)] = null;
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
                            if (WeaponCrafting.sal_timer[Main.getIdFromClient(player)] != null)
                            {
                                WeaponCrafting.sal_timer[Main.getIdFromClient(player)].Kill();
                                WeaponCrafting.sal_timer[Main.getIdFromClient(player)] = null;
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
                            WeaponCrafting.sal_timer[Main.getIdFromClient(player)].Kill();
                            WeaponCrafting.sal_timer[Main.getIdFromClient(player)] = null;
                        }
                        catch (Exception)
                        {

                        }
                    }
                }, 10000, 0);
            }
            else if (player.GetData("Refinando") == true)
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

        if (Main.IsInRangeOfPoint(player.Position, new Vector3(844.0646, -1035.391, 28.19486), 3.0f))
        {
            if (Inventory.GetPlayerItemFromInventory(player, 64) > 0)
            {
                InteractMenu.User_Input(player, "input_sell_weaponcrafting", " Waffe verkaufen", Inventory.GetPlayerItemFromInventory(player, 64).ToString(), "Sie haben derzeit " + Inventory.GetPlayerItemFromInventory(player, 64) + "", "number");
            }
            else
            {
                NAPI.ClientEvent.TriggerClientEvent(player, "Notification.SendPictureNotification", "System Information", "Job", $"Du hast was dafür vergessen!", "CHAR_CHEF", true);
            }
        }

    }

    public static void OnInputResponse(Client player, string response, string inputtext)
    {
        if(response == "input_sell_weaponcrafting")
        {
            if (Inventory.GetPlayerItemFromInventory(player, 64) > 0)
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

                if(Inventory.GetPlayerItemFromInventory(player, 64) < valor)
                {
                    Main.DisplayErrorMessage(player, "Sie versuchen WeaponCrafting zu verkaufen "+ valor + " doch Sie haben nur "+ Inventory.GetPlayerItemFromInventory(player, 64) + ".");
                    return;
                }

                int price = valor * 467;

                Main.GivePlayerMoney(player, price);
                NAPI.Notification.SendNotificationToPlayer(player, "Du hast verkauft " + Main.EMBED_BLUE+""+ valor + ""+Main.EMBED_WHITE+ " Waffe durch $"+ price.ToString("N0") + ".");
                Inventory.RemoveItem(player, "PumpShotgun", valor);
            }
        }
    }

}

