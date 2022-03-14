using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;

class SecreatWeaponCrafting : Script
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
    private static List<Dealer> _dealerPositions2;
    private static List<uint> _dealerHashs;
    public static int DealerIndex = 0;
    public static int DealerHash = 0;

    public static void SecreatWeaponCraftingInit()
    {
        //NAPI.Util.ConsoleOutput("[Jobs] WeaponCrafting.");

        Blip temp_blip = null;
        temp_blip = NAPI.Blip.CreateBlip(new Vector3(22.77834, -1105.551, 29.79703), 0);
        temp_blip.Sprite = 461;
        temp_blip.Name = "Waffen Ankäufer";
        temp_blip.Color = 4;
        temp_blip.ShortRange = true;

        refinaria_positions.Add(new { position = new Vector3(-588.7558, 2050.376, 129.9985) });
        refinaria_positions.Add(new { position = new Vector3(-520.6819, 1894.66, 122.4449) });

        NAPI.TextLabel.CreateTextLabel("- Metal -", new Vector3(-588.7558, 2050.376, 129.9985), 3f, 9f, 0, new Color(255, 255, 255, 100), false, 0);
        NAPI.TextLabel.CreateTextLabel("- Metal -", new Vector3(-520.6819, 1894.66, 122.4449), 3f, 9f, 0, new Color(255, 255, 255, 100), false, 0);

        _dealerPositions2 = new List<Dealer>
        {
            new Dealer(new Vector3(-1656.672, -1105.112, 1.14157 ), -91.42896f),
            new Dealer(new Vector3(-1801.436, -1001.805, 1.02071 ), -57.33409f),
            new Dealer(new Vector3(653.0134, 1381.875, 323.9514 ), -13.56122f),
            new Dealer(new Vector3(800.0999, 1371.068, 346.5405 ), -130.953f),
            new Dealer(new Vector3(-1692.87, -1081.361, 0.9677091 ), -130.953f),
            new Dealer(new Vector3(1218.899, 1848.793, 78.96677 ), -134.9447f),
            new Dealer(new Vector3(2239.239, 5576.159, 53.99812 ), -134.9447f),
            new Dealer(new Vector3(1363.05, -2073.559, 50.99854 ), 179.1598f),
        };

        _dealerHashs = new List<uint>(new[] { 0xF0EC56E2, 0xFDA94268, 0xBDA21E5C, 0x9D0087A8, 0xA28E71D7, 0xFD1C49BB });

        foreach (var refinaria in refinaria_positions)
        {
            NAPI.Marker.CreateMarker(27, refinaria.position - new Vector3(0, 0, 0.8f), new Vector3(), new Vector3(), 3.0f, new Color(255, 255, 255, 110), false, 0);
        }

        for (var i = 0; i < Main.MAX_PLAYERS; i++)
        {
            sal_timer.Add(null);
        }
    }

    public static void OnPlayerConnect(Client player)
    {
        var rnddealer = new Random();

        DealerIndex = rnddealer.Next(0, _dealerPositions2.Count);
        DealerHash = rnddealer.Next(0, _dealerHashs.Count);

        player.SetData("Secreats_Refinando", false);
        player.SetData("Sal", 20);
        player.SetData("Secreats_RefinandoTime", 0);
        player.TriggerEvent("Sync_PedCreate", "weaponcrafting_refinar", NAPI.Util.PedNameToModel("KTown01AMO"), new Vector3(136.5698, -1048.194, 29.15182), 161.6467f, "", 0);
        player.TriggerEvent("Sync_PedCreate", "comprador_de_weaponcrafting", NAPI.Util.PedNameToModel("GenStreet02AMY"), new Vector3(22.77834, -1105.551, 29.79703), 154.6975f, "", 0);
        player.TriggerEvent("Sync_PedCreate", "comprador_de_weaponcrafting", NAPI.Util.PedNameToModel("GenStreet02AMY"), new Vector3(-1692.87, -1081.361, 0.9677091), "", 0);
    }

    public static void PressKeyY(Client player)
    {
        foreach (var refinaria in refinaria_positions)
        {
            // Metal aufsammeln
            if (Main.IsInRangeOfPoint(player.Position, refinaria.position, 14f) && player.GetData("Secreats_Refinando") == false)
            {

                if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 67, 2, Inventory.Max_Inventory_Weight(player)) == true)
                {
                    return;
                }

                Inventory.GiveItemToInventory(player, 67, 4);

                player.SetData("Secreats_Refinando", true);
                player.PlayAnimation("amb@world_human_hammering@male@base", "base", 1 << 0 | 1 << 5);
                Main.AttachObjectToEntity("prop_tool_pickaxe", player.Value, 28422);
                player.TriggerEvent("createNewHeadNotificationAdvanced", "Sie haben ~g~ ~c~4~b~ Metal~w~aufgehoben !");
                Main.SendNotificationBrowser(player, "", "<string>+ 4</strong> Metal in Ihrem Inventar hinzugefügt !", "success");

                NAPI.Task.Run(() =>
                {
                    player.SetData("Secreats_Refinando", false);
                    player.StopAnimation();
                    Main.DeleteAttachedObject(player);
                }, delayTime: 10500);
                return;
            }
        }

        // MetalBlock Ersteller
       if (Main.IsInRangeOfPoint(player.Position, new Vector3(136.5698, -1048.194, 29.15182), 3f))
        {
            if (Inventory.GetPlayerItemFromInventory(player, 67) >= 2 && player.GetData("Secreats_Refinando") == false)
            {
                //
                int sals = Inventory.GetPlayerItemFromInventory(player, 67);
                int sals_a_ser_refinados = 0;

                //
                player.SetData("Secreats_Refinando", true);
                player.SetData("Secreats_RefinandoTime", 1);

                //
                player.TriggerEvent("freezeEx", true);
                player.PlayScenario("WORLD_HUMAN_GUARD_STAND");

                //
                player.TriggerEvent("SetProgressBar", player.GetData("Secreats_RefinandoTime"), "Verarbeite Metal - " + sals_a_ser_refinados + " von " + sals + " zu ein Block");

                //
                SecreatWeaponCrafting.sal_timer[Main.getIdFromClient(player)] = TimerEx.SetTimer(() =>
                {
                    //
                    if (Inventory.GetPlayerItemFromInventory(player, 67) >= 2)
                    {
                        // 
                        player.SetData("Secreats_RefinandoTime", player.GetData("Secreats_RefinandoTime") + 1);
                        player.TriggerEvent("SetProgressBar", player.GetData("Secreats_RefinandoTime"), "Verarbeite Metal - " + sals_a_ser_refinados + " von " + sals + " zu ein Block");

                        if (player.GetData("Secreats_RefinandoTime") > 100)
                        {
                            //
                            sals_a_ser_refinados += 2;

                            // Remove o Sal e conta tudo novamente.
                            Inventory.RemoveItem(player, "Metal", 2);
                            //Inventory.RemoveItem(player, "Sack", 1);
                            // MetalBlock
                            Inventory.GiveItemToInventory(player, 68, 1);

                            //
                            player.SetData("Secreats_RefinandoTime", 0);
                            player.TriggerEvent("SetProgressBar", player.GetData("Secreats_RefinandoTime"), "Verarbeite Metal - " + sals_a_ser_refinados + " von " + sals + " zu ein Block");

                            //
                            player.TriggerEvent("createNewHeadNotificationAdvanced", "~g~+~w~ 1x Verarbeiten MetalBlock erhalten!");

                            //
                            if (Inventory.GetPlayerItemFromInventory(player, 67) == 0)
                            {
                                if (SecreatWeaponCrafting.sal_timer[Main.getIdFromClient(player)] != null)
                                {
                                    SecreatWeaponCrafting.sal_timer[Main.getIdFromClient(player)].Kill();
                                    SecreatWeaponCrafting.sal_timer[Main.getIdFromClient(player)] = null;
                                }
                                player.StopAnimation();
                                player.SetData("Secreats_Refinando", false);
                                player.TriggerEvent("freezeEx", false);
                                player.TriggerEvent("DestroyProgressBar");
                            }
                        }
                    }
                    else
                    {
                        //
                        if (player.GetData("Secreats_Refinando") == true)
                        {
                            if (SecreatWeaponCrafting.sal_timer[Main.getIdFromClient(player)] != null)
                            {
                                SecreatWeaponCrafting.sal_timer[Main.getIdFromClient(player)].Kill();
                                SecreatWeaponCrafting.sal_timer[Main.getIdFromClient(player)] = null;
                            }
                            player.StopAnimation();
                            player.SetData("Secreats_Refinando", false);
                            player.TriggerEvent("freezeEx", false);
                            player.TriggerEvent("DestroyProgressBar");
                        }
                    }
                    if (player.GetData("status") == false)
                    {
                        try
                        {
                            SecreatWeaponCrafting.sal_timer[Main.getIdFromClient(player)].Kill();
                            SecreatWeaponCrafting.sal_timer[Main.getIdFromClient(player)] = null;
                        }
                        catch(Exception)
                        {

                        }
                    }
                }, 1000, 0);
            }
            else if(player.GetData("Secreats_Refinando") == true)
            {
                if (sal_timer[Main.getIdFromClient(player)] != null)
                {
                    sal_timer[Main.getIdFromClient(player)].Kill();
                    sal_timer[Main.getIdFromClient(player)] = null;
                }
                player.StopAnimation();
                player.SetData("Secreats_Refinando", false);
                player.TriggerEvent("freezeEx", false);
                player.TriggerEvent("DestroyProgressBar");
            }
            
        }

        // Waffen Ersteller
        if (Main.IsInRangeOfPoint(player.Position, new Vector3(-1692.87, -1081.361, 0.9677091), 3f))
        {
            if (Inventory.GetPlayerItemFromInventory(player, 68) >= 2 && Inventory.GetPlayerItemFromInventory(player, 99) >= 1 && player.GetData("Secreats_Refinando") == false)
            {
                //
                int sals = Inventory.GetPlayerItemFromInventory(player, 68);
                int sals_a_ser_refinados = 0;

                //
                player.SetData("Secreats_Refinando", true);
                player.SetData("Secreats_RefinandoTime", 5);

                //
                player.TriggerEvent("freezeEx", true);
                player.PlayScenario("WORLD_HUMAN_GUARD_STAND");

                //
                player.TriggerEvent("SetProgressBar", player.GetData("Secreats_RefinandoTime"), "Erstelle Waffe - " + sals_a_ser_refinados + " von " + sals + "");

                //
                SecreatWeaponCrafting.sal_timer[Main.getIdFromClient(player)] = TimerEx.SetTimer(() =>
                {
                    //
                    if (Inventory.GetPlayerItemFromInventory(player, 68) >= 2 && Inventory.GetPlayerItemFromInventory(player, 99) >= 1)
                    {
                        // 
                        player.SetData("Secreats_RefinandoTime", player.GetData("Secreats_RefinandoTime") + 1);
                        player.TriggerEvent("SetProgressBar", player.GetData("Secreats_RefinandoTime"), "Erstelle Waffe - " + sals_a_ser_refinados + " von " + sals + "");

                        if (player.GetData("Secreats_RefinandoTime") > 100)
                        {
                            //
                            sals_a_ser_refinados += 1;

                            // Remove o Sal e conta tudo novamente.
                            Inventory.RemoveItem(player, "MetalBlock", 2);
                            Inventory.RemoveItem(player, "Griff", 1);
                            //Inventory.RemoveItem(player, "ElektroDraht", 1);
                            Inventory.GiveItemToInventory(player, 63, 1);

                            //
                            player.SetData("Secreats_RefinandoTime", 0);
                            player.TriggerEvent("SetProgressBar", player.GetData("Secreats_RefinandoTime"), "Erstelle Waffe - " + sals_a_ser_refinados + " von " + sals + "");

                            //
                            player.TriggerEvent("createNewHeadNotificationAdvanced", "~g~+~w~ 1x Waffe erhalten!");

                            //
                            if (Inventory.GetPlayerItemFromInventory(player, 68) == 0)
                            {
                                if (SecreatWeaponCrafting.sal_timer[Main.getIdFromClient(player)] != null)
                                {
                                    SecreatWeaponCrafting.sal_timer[Main.getIdFromClient(player)].Kill();
                                    SecreatWeaponCrafting.sal_timer[Main.getIdFromClient(player)] = null;
                                }
                                player.StopAnimation();
                                player.SetData("Secreats_Refinando", false);
                                player.TriggerEvent("freezeEx", false);
                                player.TriggerEvent("DestroyProgressBar");
                            }
                        }
                    }
                    else
                    {
                        //
                        if (player.GetData("Secreats_Refinando") == true)
                        {
                            if (SecreatWeaponCrafting.sal_timer[Main.getIdFromClient(player)] != null)
                            {
                                SecreatWeaponCrafting.sal_timer[Main.getIdFromClient(player)].Kill();
                                SecreatWeaponCrafting.sal_timer[Main.getIdFromClient(player)] = null;
                            }
                            player.StopAnimation();
                            player.SetData("Secreats_Refinando", false);
                            player.TriggerEvent("freezeEx", false);
                            player.TriggerEvent("DestroyProgressBar");
                        }
                    }
                    if (player.GetData("status") == false)
                    {
                        try
                        {
                            SecreatWeaponCrafting.sal_timer[Main.getIdFromClient(player)].Kill();
                            SecreatWeaponCrafting.sal_timer[Main.getIdFromClient(player)] = null;
                        }
                        catch (Exception)
                        {

                        }
                    }
                }, 10000, 0);
            }
            else if (player.GetData("Secreats_Refinando") == true)
            {
                if (sal_timer[Main.getIdFromClient(player)] != null)
                {
                    sal_timer[Main.getIdFromClient(player)].Kill();
                    sal_timer[Main.getIdFromClient(player)] = null;
                }
                player.StopAnimation();
                player.SetData("Secreats_Refinando", false);
                player.TriggerEvent("freezeEx", false);
                player.TriggerEvent("DestroyProgressBar");
            }

        }

        if (Main.IsInRangeOfPoint(player.Position, new Vector3(22.77834, -1105.551, 29.79703), 3.0f))
        {
            if (Inventory.GetPlayerItemFromInventory(player, 63) > 0)
            {
                InteractMenu.User_Input(player, "input_sell_secweaponcrafting", " Waffe verkaufen", Inventory.GetPlayerItemFromInventory(player, 63).ToString(), "Sie haben derzeit " + Inventory.GetPlayerItemFromInventory(player, 63) + "", "number");
            }
            else
            {
                NAPI.Notification.SendNotificationToPlayer(player, "You dont have Weapon !");
            }
        }

    }

    public static void OnInputResponse(Client player, string response, string inputtext)
    {
        if(response == "input_sell_secweaponcrafting")
        {
            if (Inventory.GetPlayerItemFromInventory(player, 63) > 0)
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

                if(Inventory.GetPlayerItemFromInventory(player, 63) < valor)
                {
                    Main.DisplayErrorMessage(player, "Sie versuchen eine Waffe zu verkaufen "+ valor + " doch Sie haben nur "+ Inventory.GetPlayerItemFromInventory(player, 63) + ".");
                    return;
                }

                int price = valor * 498;

                Main.GivePlayerMoney(player, price);
                NAPI.Notification.SendNotificationToPlayer(player, "Du hast verkauft " + Main.EMBED_BLUE+""+ valor + ""+Main.EMBED_WHITE+ " Waffe durch $"+ price.ToString("N0") + ".");
                Inventory.RemoveItem(player, "CompactRifle", valor);
            }
        }
    }

}

