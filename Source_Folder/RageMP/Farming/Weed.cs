using System;
using System.Collections.Generic;
using GTANetworkAPI;
using Newtonsoft.Json;
using DerStr1k3r.SDK;

class Weed : Script
{
    private static nLog Log = new nLog("Weed");

    public class WeedEnum : IEquatable<WeedEnum>
    {
        public int id { get; set; }
        public Entity objectHandle { get; set; }
        public TextLabel textLabel { get; set; }
        public Vector3 position { get; set; }
        public TimerEx timer { get; set; }
        public int stage { get; set; }
        public int downtime { get; set; }
        public override int GetHashCode()
        {
            return id;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            WeedEnum objAsPart = obj as WeedEnum;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }

        public bool Equals(WeedEnum other)
        {
            if (other == null) return false;
            return (this.id.Equals(other.id));
        }
    }

    public static List<WeedEnum> WeedList = new List<WeedEnum>();

    public static void WeedInit()
    {
        NAPI.World.DeleteWorldProp(-305885281, new Vector3(2209.981, 5577.867, 53.93683), 40f);
        NAPI.World.DeleteWorldProp(452618762, new Vector3(2209.981, 5577.867, 53.93683), 40f);

        WeedList.Add(new WeedEnum { position = new Vector3(2209.981, 5577.867, 53.93683), stage = 0 }); // SavedRotation: 0, 0, 263.3716
        WeedList.Add(new WeedEnum { position = new Vector3(2211.644, 5577.785, 53.85914), stage = 0 }); // SavedRotation: 0, 0, 268.5566
        WeedList.Add(new WeedEnum { position = new Vector3(2213.56, 5577.729, 53.81), stage = 0 }); // SavedRotation: 0, 0, 270.1692
        WeedList.Add(new WeedEnum { position = new Vector3(2216.202, 5577.533, 53.84117), stage = 0 }); // SavedRotation: 0, 0, 269.441
        WeedList.Add(new WeedEnum { position = new Vector3(2218.27, 5577.475, 53.85551), stage = 0 }); // SavedRotation: 0, 0, 268.7005
        WeedList.Add(new WeedEnum { position = new Vector3(2220.48, 5577.303, 53.84985), stage = 0 }); // SavedRotation: 0, 0, 268.3207
        WeedList.Add(new WeedEnum { position = new Vector3(2222.818, 5577.122, 53.84286), stage = 0 }); // SavedRotation: 0, 0, 269.0052
        WeedList.Add(new WeedEnum { position = new Vector3(2224.955, 5576.902, 53.85326), stage = 0 }); // SavedRotation: 0, 0, 263.5453
        WeedList.Add(new WeedEnum { position = new Vector3(2227.907, 5576.912, 53.86923), stage = 0 }); // SavedRotation: 0, 0, 270.2586
        WeedList.Add(new WeedEnum { position = new Vector3(2230.851, 5576.681, 53.97025), stage = 0 }); // SavedRotation: 0, 0, 267.059
        WeedList.Add(new WeedEnum { position = new Vector3(2232.535, 5576.648, 54.02378), stage = 0 }); // SavedRotation: 0, 0, 356.2679
        WeedList.Add(new WeedEnum { position = new Vector3(2234.716, 5576.416, 54.05343), stage = 0 }); // SavedRotation: 0, 0, 267.3956
        WeedList.Add(new WeedEnum { position = new Vector3(2236.708, 5576.405, 54.03064), stage = 0 }); // SavedRotation: 0, 0, 270.0922
        WeedList.Add(new WeedEnum { position = new Vector3(2238.665, 5576.363, 54.0117), stage = 0 }); // SavedRotation: 0, 0, 269.5212
        WeedList.Add(new WeedEnum { position = new Vector3(2239.521, 5578.258, 54.05408), stage = 0 }); // SavedRotation: 0, 0, 89.70883
        WeedList.Add(new WeedEnum { position = new Vector3(2237.163, 5578.394, 54.08027), stage = 0 }); // SavedRotation: 0, 0, 90.36221
        WeedList.Add(new WeedEnum { position = new Vector3(2234.716, 5578.551, 54.1121), stage = 0 }); // SavedRotation: 0, 0, 86.38636
        WeedList.Add(new WeedEnum { position = new Vector3(2232.82, 5578.671, 54.09954), stage = 0 }); // SavedRotation: 0, 0, 88.11132
        WeedList.Add(new WeedEnum { position = new Vector3(2230.612, 5578.806, 54.03109), stage = 0 }); // SavedRotation: 0, 0, 88.41028
        WeedList.Add(new WeedEnum { position = new Vector3(2228.185, 5578.897, 53.94024), stage = 0 }); // SavedRotation: 0, 0, 89.13777
        WeedList.Add(new WeedEnum { position = new Vector3(2225.854, 5579.076, 53.93369), stage = 0 }); // SavedRotation: 0, 0, 87.80364
        WeedList.Add(new WeedEnum { position = new Vector3(2222.923, 5579.303, 53.92711), stage = 0 }); // SavedRotation: 0, 0, 87.00317
        WeedList.Add(new WeedEnum { position = new Vector3(2218.802, 5579.675, 53.9707), stage = 0 }); // SavedRotation: 0, 0, 89.27118
        WeedList.Add(new WeedEnum { position = new Vector3(2215.653, 5579.752, 53.9519), stage = 0 }); // SavedRotation: 0, 0, 85.86916
        WeedList.Add(new WeedEnum { position = new Vector3(2212.631, 5579.991, 53.94592), stage = 0 }); // SavedRotation: 0, 0, 85.86916
        WeedList.Add(new WeedEnum { position = new Vector3(2210.287, 5580.178, 54.08629), stage = 0 }); // SavedRotation: 0, 0, 85.86916
        WeedList.Add(new WeedEnum { position = new Vector3(2211.06, 5575.304, 53.73389), stage = 0 }); // SavedRotation: 0, 0, 269.1892
        WeedList.Add(new WeedEnum { position = new Vector3(2213.819, 5575.241, 53.67646), stage = 0 }); // SavedRotation: 0, 0, 269.1225
        WeedList.Add(new WeedEnum { position = new Vector3(2216.586, 5575.175, 53.71393), stage = 0 }); // SavedRotation: 0, 0, 269.1225
        WeedList.Add(new WeedEnum { position = new Vector3(2218.92, 5575.12, 53.72364), stage = 0 }); // SavedRotation: 0, 0, 269.1225
        WeedList.Add(new WeedEnum { position = new Vector3(2221.422, 5575.063, 53.72345), stage = 0 }); // SavedRotation: 0, 0, 269.1225
        WeedList.Add(new WeedEnum { position = new Vector3(2226.573, 5574.743, 53.79113), stage = 0 }); // SavedRotation: 0, 0, 269.1225
        WeedList.Add(new WeedEnum { position = new Vector3(2229.898, 5574.506, 53.88105), stage = 0 }); // SavedRotation: 0, 0, 269.1225
        WeedList.Add(new WeedEnum { position = new Vector3(2233.531, 5574.091, 54.00314), stage = 0 }); // SavedRotation: 0, 0, 269.1225
        WeedList.Add(new WeedEnum { position = new Vector3(2236.104, 5574.032, 53.92502), stage = 0 }); // SavedRotation: 0, 0, 269.1225
        WeedList.Add(new WeedEnum { position = new Vector3(2238.447, 5573.976, 53.85835), stage = 0 }); // SavedRotation: 0, 0, 261.7181


        foreach (var weed in WeedList)
        {
            weed.objectHandle = NAPI.Object.CreateObject(452618762, new Vector3(weed.position.X, weed.position.Y, weed.position.Z - 1.2f), new Vector3(), 255, 0);
        }
    }

    public static void OnPlayerConnect(Client player)
    {
        player.SetData("Weed_Refinando", false);
        player.SetData("Sal", 20);
        player.SetData("Weed_RefinandoTime", 0);
        player.TriggerEvent("Sync_PedCreate", "drug_dealer", NAPI.Util.PedNameToModel("ig_g"), new Vector3(2387.77, 5919.821, 73.08957), 115.7029f, "", 0);
        player.TriggerEvent("Sync_PedCreate", "drug_dealer", NAPI.Util.PedNameToModel("ig_g"), new Vector3(-2668.936, 2629.708, 0.04988921), 149.7894f, "", 0);
        player.TriggerEvent("Sync_PedCreate", "drug_dealer", NAPI.Util.PedNameToModel("ig_g"), new Vector3(1247.809, -2915.462, 26.45622), 271.458f, "", 0);
        player.TriggerEvent("Sync_PedCreate", "drug_dealer", NAPI.Util.PedNameToModel("ig_g"), new Vector3(1010.423, -1632.608, 48.65954), 186.6264f, "", 0);
    }


    public static void PressKeyY(Client player)
    {
        foreach (var weed in WeedList)
        {
            if (Main.IsInRangeOfPoint(player.Position, weed.position, 1.0f) && player.GetData("Weed_Refinando") == false)
            {
                if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 11, 1, Inventory.Max_Inventory_Weight(player)) == true)
                {
                    return;
                }

                Random rnd = new Random();
                int sammeln = rnd.Next(1, 3);

                player.SetData("Weed_Refinando", true);
                Inventory.GiveItemToInventory(player, 11, sammeln);
                NAPI.Notification.SendNotificationToPlayer(player, "Sie haben ~c~" + sammeln + "x ~b~Unverarbeitetes Marihuana ~w~abgeschnitten!");
                player.PlayAnimation("anim@mp_snowball", "pickup_snowball", 1 << 0 | 1 << 5);
                NAPI.Task.Run(() =>
                {
                    player.SetData("Weed_Refinando", false);
                    player.StopAnimation();
                }, delayTime: 8500);
                return;
            }
        }

        if (Main.IsInRangeOfPoint(player.Position, new Vector3(2387.77, 5919.821, 73.08957), 3.0f))
        {
            List<dynamic> menu_item_list = new List<dynamic>();
            menu_item_list.Add(new { Type = 1, Name = "Verkaufen Sie Marihuana", Description = "Wählen Sie diese Option aus, um Marihuana an den Dealer zu verkaufen.", RightLabel = "" });
            InteractMenu.CreateMenu(player, "SELL_WEED", "Dealer", "~b~Drogen - Verkaufen", true, JsonConvert.SerializeObject(menu_item_list), false);
        }
        else if (Main.IsInRangeOfPoint(player.Position, new Vector3(1010.423, -1632.608, 48.65954), 3.0f))
        {
            List<dynamic> menu_item_list = new List<dynamic>();
            menu_item_list.Add(new { Type = 1, Name = "Verkaufe Kokain", Description = "Wählen Sie diese Option aus, um Kokain an den Dealer zu verkaufen.", RightLabel = "" });
            InteractMenu.CreateMenu(player, "SELL_KOKAIN", "Dealer", "~b~Drogen - Verkaufen", true, JsonConvert.SerializeObject(menu_item_list), false);
        }
        else if (Main.IsInRangeOfPoint(player.Position, new Vector3(-2668.936, 2629.708, 0.04988921), 3.0f))
        {
            List<dynamic> menu_item_list = new List<dynamic>();
            menu_item_list.Add(new { Type = 1, Name = "Verkaufe Meth", Description = "Wählen Sie diese Option aus, um Meth an den Dealer zu verkaufen.", RightLabel = "" });
            InteractMenu.CreateMenu(player, "SELL_METH", "Dealer", "~b~Drogen - Verkaufen", true, JsonConvert.SerializeObject(menu_item_list), false);
        }
        else if (Main.IsInRangeOfPoint(player.Position, new Vector3(1247.809, -2915.462, 26.45622), 3.0f))
        {
            List<dynamic> menu_item_list = new List<dynamic>();
            menu_item_list.Add(new { Type = 1, Name = "Verkaufe Ecstasy", Description = "Wählen Sie diese Option aus, um Ecstasy an den Dealer zu verkaufen.", RightLabel = "" });
            InteractMenu.CreateMenu(player, "SELL_ECSTASY", "Dealer", "~b~Drogen - Verkaufen", true, JsonConvert.SerializeObject(menu_item_list), false);
        }
    }

    public static void SelectMenuResponse(Client player, String callbackId, int selectedIndex, String objectName, String valueList)
    {
        if (callbackId == "SELL_WEED")
        {
            if (selectedIndex == 0)
            {
                if (Inventory.GetPlayerItemFromInventory(player, 12) > 0)
                {
                    InteractMenu.User_Input(player, "input_sell_weed", "Verkaufen Sie Marihuana", Inventory.GetPlayerItemFromInventory(player, 12).ToString(), "Sie haben derzeit " + Inventory.GetPlayerItemFromInventory(player, 12) + "", "number");
                }
            }
        }
        else if (callbackId == "SELL_KOKAIN")
        {
            if (selectedIndex == 0)
            {
                if (Inventory.GetPlayerItemFromInventory(player, 16) > 0)
                {
                    InteractMenu.User_Input(player, "input_sell_heroin", "Verkaufen Sie Heroin", Inventory.GetPlayerItemFromInventory(player, 16).ToString(), "Sie haben derzeit " + Inventory.GetPlayerItemFromInventory(player, 16) + "", "number");
                }
            }
        }
        else if (callbackId == "SELL_METH")
        {
            if (selectedIndex == 0)
            {
                if (Inventory.GetPlayerItemFromInventory(player, 37) > 0)
                {
                    InteractMenu.User_Input(player, "input_sell_meth", "Verkaufen Sie Meth", Inventory.GetPlayerItemFromInventory(player, 37).ToString(), "Sie haben derzeit " + Inventory.GetPlayerItemFromInventory(player, 37) + "", "number");
                }
            }
        }
        else if (callbackId == "SELL_ECSTASY")
        {
            if (selectedIndex == 0)
            {
                if (Inventory.GetPlayerItemFromInventory(player, 61) > 0)
                {
                    InteractMenu.User_Input(player, "input_sell_ecstasy", "Verkaufen Sie Ecstasy", Inventory.GetPlayerItemFromInventory(player, 61).ToString(), "Sie haben derzeit " + Inventory.GetPlayerItemFromInventory(player, 61) + "", "number");
                }
            }
        }
    }
    public static void OnInputResponse(Client player, String response, String inputtext)
    {
        if (response == "input_sell_weed")
        {
            if (Inventory.GetPlayerItemFromInventory(player, 12) > 0)
            {
                if (inputtext.Contains("-"))
                {
                    return;
                }

                if (inputtext.Contains("+"))
                {
                    return;
                }

                if (!Main.IsNumeric(inputtext))
                {
                    Main.DisplayErrorMessage(player, "Der eingegebene Wert ist nicht numerisch.Bitte geben Sie einen gültigen Wert ein.");
                    return;
                }

                int valor = Convert.ToInt32(inputtext);

                if (valor < 1)
                {
                    Main.DisplayErrorMessage(player, "Der von Ihnen eingegebene Wert darf nicht kleiner als 1 sein.");
                    return;
                }

                if (Inventory.GetPlayerItemFromInventory(player, 12) < valor)
                {
                    Main.DisplayErrorMessage(player, "Sie versuchen zu verkaufen " + valor + " Marihuana ,  Sie  haben nur" + Inventory.GetPlayerItemFromInventory(player, 12) + ".");
                    return;
                }

                Random rnd = new Random();
                int price = valor * rnd.Next(118, 303);

                //int price = valor * 325;

                Inventory.GiveItemToInventory(player, 158, price);
                NAPI.Notification.SendNotificationToPlayer(player, "Du hast verkauft: " + valor + "x Marihuana für $" + price.ToString("N0") + "");
                Inventory.RemoveItem(player, "Marihuana", valor);
            }
        }
        else if (response == "input_sell_heroin")
        {
            if (Inventory.GetPlayerItemFromInventory(player, 16) > 0)
            {
                if (inputtext.Contains("-"))
                {
                    return;
                }

                if (inputtext.Contains("+"))
                {
                    return;
                }

                if (!Main.IsNumeric(inputtext))
                {
                    Main.DisplayErrorMessage(player, "Der eingegebene Wert ist nicht numerisch. Bitte geben Sie einen gültigen Wert ein.");
                    return;
                }

                int valor = Convert.ToInt32(inputtext);

                if (valor < 1)
                {
                    Main.DisplayErrorMessage(player, "Der von Ihnen eingegebene Wert darf nicht kleiner als 1 sein.");
                    return;
                }

                if (Inventory.GetPlayerItemFromInventory(player, 16) < valor)
                {
                    Main.DisplayErrorMessage(player, "Sie versuchen zu verkaufen " + valor + " Kokain und Sie haben nur " + Inventory.GetPlayerItemFromInventory(player, 16) + ".");
                    return;
                }

                Random rnd = new Random();
                int price = valor * rnd.Next(179, 455);

                //int price = valor * 375;

                Inventory.GiveItemToInventory(player, 158, price);
                NAPI.Notification.SendNotificationToPlayer(player, "Du hast verkauft: " + valor + "x Kokain für $" + price.ToString("N0") + "");
                Inventory.RemoveItem(player, "Kokain", valor);
            }
        }
        else if (response == "input_sell_meth")
        {
            if (Inventory.GetPlayerItemFromInventory(player, 37) > 0)
            {
                if (inputtext.Contains("-"))
                {
                    return;
                }

                if (inputtext.Contains("+"))
                {
                    return;
                }

                if (!Main.IsNumeric(inputtext))
                {
                    Main.DisplayErrorMessage(player, "Der eingegebene Wert ist nicht numerisch. Bitte geben Sie einen gültigen Wert ein.");
                    return;
                }

                int valor = Convert.ToInt32(inputtext);

                if (valor < 1)
                {
                    Main.DisplayErrorMessage(player, "Der von Ihnen eingegebene Wert darf nicht kleiner als 1 sein.");
                    return;
                }

                if (Inventory.GetPlayerItemFromInventory(player, 37) < valor)
                {
                    Main.DisplayErrorMessage(player, "Sie versuchen zu verkaufen " + valor + " Meth und Sie haben nur " + Inventory.GetPlayerItemFromInventory(player, 37) + ".");
                    return;
                }

                Random rnd = new Random();
                int price = valor * rnd.Next(269, 565);

                //int price = valor * 485;

                Inventory.GiveItemToInventory(player, 158, price);
                NAPI.Notification.SendNotificationToPlayer(player, "Du hast verkauft: " + valor + "x Meth für $" + price.ToString("N0") + "");
                Inventory.RemoveItem(player, "Meth", valor);
            }
        }
        else if (response == "input_sell_ecstasy")
        {
            if (Inventory.GetPlayerItemFromInventory(player, 61) > 0)
            {
                if (inputtext.Contains("-"))
                {
                    return;
                }

                if (inputtext.Contains("+"))
                {
                    return;
                }

                if (!Main.IsNumeric(inputtext))
                {
                    Main.DisplayErrorMessage(player, "Der eingegebene Wert ist nicht numerisch. Bitte geben Sie einen gültigen Wert ein.");
                    return;
                }

                int valor = Convert.ToInt32(inputtext);

                if (valor < 1)
                {
                    Main.DisplayErrorMessage(player, "Der von Ihnen eingegebene Wert darf nicht kleiner als 1 sein.");
                    return;
                }

                if (Inventory.GetPlayerItemFromInventory(player, 61) < valor)
                {
                    Main.DisplayErrorMessage(player, "Sie versuchen zu verkaufen " + valor + " Ecstasy und Sie haben nur " + Inventory.GetPlayerItemFromInventory(player, 61) + ".");
                    return;
                }

                Random rnd = new Random();
                int price = valor * rnd.Next(349, 615);

                //int price = valor * 665;

                Inventory.GiveItemToInventory(player, 158, price);
                NAPI.Notification.SendNotificationToPlayer(player, "Du hast verkauft: " + valor + "x Ecstasy für $" + price.ToString("N0") + "");
                Inventory.RemoveItem(player, "Ecstasy", valor);
            }
        }
    }

    public static void StartProcess(Client player, int type)
    {

    }

    [Command("vendermaconha", "/vendermaconha [Menge] [preis] ~c~(Der Spieler muss sich in Ihrer Nähe befinden)")]
    public void CMD_vendermaconha(Client player, int amount, int price)
    {

        foreach (var target in NAPI.Pools.GetAllPlayers())
        {
            if (Main.IsInRangeOfPoint(player.Position, target.Position, 3.0f) && player != target)
            {

                if (amount < 1)
                {
                    Main.SendErrorMessage(player, "Die Menge kann nicht kleiner als 1 sein.");
                    return;
                }

                int index = Inventory.GetInventoryIndexFromName(player, "Marihuana");

                if (player.GetData("inventory_item_" + index + "_amount") >= amount)
                {
                    target.SetData("offer_price", price);
                    target.SetData("offer_amount", amount);
                    target.SetData("offer_seller", player);
                    target.SetData("offer", true);

                    Main.SendInfoMessage(target, "Der Bürger" + AccountManage.GetCharacterName(player) + " bietet dir an" + amount + " Marihuana für " + price.ToString("N0") + ".");
                    Main.SendInfoMessage(player, "Du bietest  " + AccountManage.GetCharacterName(target) + " Marihuana " + amount + " für " + price.ToString("N0") + ".");

                    InteractMenu.ShowModal(target, "WEED_OFFER", "Ihnen angeboten " + amount + " Marihuana " + amount + "", "Der Bürger" + AccountManage.GetCharacterName(player) + " bietet dir an" + amount + " basierend auf " + price.ToString("N0") + "<br><br>Sie möchten dieses Angebot annehmen ? ", "Ja, zahle " + price.ToString("N0") + "", "Nein, danke");
                }
                else
                {
                    Main.SendErrorMessage(player, "Sie haben diesen Artikel nicht in Ihrem Inventar.");
                }
                return;
            }
        }
        Main.SendErrorMessage(player, "Sie haben diesen Artikel nicht in Ihrem Inventar.");
    }

    [Command("vendercocaina", "/vendercocaina [Menge] [preis] ~c~(Der Bürger muss sich in Ihrer Nähe befinden)")]
    public void CMD_venderheroina(Client player, int amount, int price)
    {

        foreach (var target in NAPI.Pools.GetAllPlayers())
        {
            if (Main.IsInRangeOfPoint(player.Position, target.Position, 3.0f) && player != target)
            {

                if (amount < 1)
                {
                    Main.SendErrorMessage(player, "Die Menge kann nicht kleiner als 1 sein.");
                    return;
                }

                int index = Inventory.GetInventoryIndexFromName(player, "Kokain");

                if (player.GetData("inventory_item_" + index + "_amount") >= amount)
                {
                    target.SetData("offer_price", price);
                    target.SetData("offer_amount", amount);
                    target.SetData("offer_seller", player);
                    target.SetData("offer", true);

                    Main.SendInfoMessage(target, "Der Spieler " + AccountManage.GetCharacterName(player) + " bietet dir an " + amount + " Kokain" + price.ToString("N0") + ".");
                    Main.SendInfoMessage(player, "Du bietest an " + AccountManage.GetCharacterName(target) + " Kokain" + amount + " für " + price.ToString("N0") + ".");

                    InteractMenu.ShowModal(target, "HEROIN_OFFER", "Ihnen angeboten " + amount + " Kokain für " + amount + "", "Der Bürger " + AccountManage.GetCharacterName(player) + " bietet dir an " + amount + " Kokain für " + price.ToString("N0") + "<br><br>Möchten Sie dieses Angebot annehmen?", "Ja " + price.ToString("N0") + "", "Nein");
                }
                else
                {
                    Main.SendErrorMessage(player, "Sie haben diesen Artikel nicht in Ihrem Inventar.");
                }
                return;

            }
        }
        Main.SendErrorMessage(player, "Sie haben diesen Artikel nicht in Ihrem Inventar.");
    }

    [Command("vendermeth", "/vendercocaina [Menge] [preis] ~c~(Der Bürger muss sich in Ihrer Nähe befinden)")]
    public void CMD_vendermeth(Client player, int amount, int price)
    {

        foreach (var target in NAPI.Pools.GetAllPlayers())
        {
            if (Main.IsInRangeOfPoint(player.Position, target.Position, 3.0f) && player != target)
            {

                if (amount < 1)
                {
                    Main.SendErrorMessage(player, "Die Menge kann nicht kleiner als 1 sein.");
                    return;
                }

                int index = Inventory.GetInventoryIndexFromName(player, "Kokain");

                if (player.GetData("inventory_item_" + index + "_amount") >= amount)
                {
                    target.SetData("offer_price", price);
                    target.SetData("offer_amount", amount);
                    target.SetData("offer_seller", player);
                    target.SetData("offer", true);

                    Main.SendInfoMessage(target, "Der Spieler " + AccountManage.GetCharacterName(player) + " bietet dir an " + amount + " Kokain" + price.ToString("N0") + ".");
                    Main.SendInfoMessage(player, "Du bietest an " + AccountManage.GetCharacterName(target) + " Meth" + amount + " für " + price.ToString("N0") + ".");

                    InteractMenu.ShowModal(target, "HEROIN_OFFER", "Ihnen angeboten " + amount + " Kokain für " + amount + "", "Der Bürger " + AccountManage.GetCharacterName(player) + " bietet dir an " + amount + " Kokain für " + price.ToString("N0") + "<br><br>Möchten Sie dieses Angebot annehmen?", "Ja " + price.ToString("N0") + "", "Nein");
                }
                else
                {
                    Main.SendErrorMessage(player, "Sie haben diesen Artikel nicht in Ihrem Inventar.");
                }
                return;

            }
        }
        Main.SendErrorMessage(player, "Sie haben diesen Artikel nicht in Ihrem Inventar.");
    }

    public static void ModalConfirm(Client player, string response)
    {
        if (response == "WEED_OFFER")
        {
            Client selling = NAPI.Data.GetEntityData(player, "offer_seller");
            if (Main.IsPlayerLogged(selling) && selling.GetData("status") == true)
            {
                int index = Inventory.GetInventoryIndexFromName(selling, "Marihuana");

                if (selling.GetData("inventory_item_" + index + "_amount") >= player.GetData("offer_amount"))
                {
                    if (Main.GetPlayerMoney(player) < player.GetData("offer_price"))
                    {
                        Main.SendErrorMessage(player, "Der Verkäufer verkauft von " + player.GetData("offer_price") + ". Sie haben dieses Geld nicht in Ihren Händen..");
                        return;
                    }

                    Inventory.RemoveItem(selling, "Marihuana", player.GetData("offer_amount"));
                    Inventory.GiveItemToInventory(player, 12, player.GetData("offer_amount"));

                    NAPI.Notification.SendNotificationToPlayer(player, "Du hast es gekauft. " + player.GetData("offer_amount") + " Marihuana für" + player.GetData("offer_price") + " von " + AccountManage.GetCharacterName(selling) + ".");
                    Main.SendSuccessMessage(selling, "Du hast verkauft" + player.GetData("offer_amount") + " Marihuana für " + player.GetData("offer_price") + " zu " + AccountManage.GetCharacterName(player) + ".");

                    Main.GivePlayerMoney(player, -player.GetData("offer_price"));
                    Main.GivePlayerMoney(selling, player.GetData("offer_price"));

                }
            }
            else
            {
                Main.SendErrorMessage(player, "Wer Ihnen das Angebot geschickt hat, ist nicht mehr verbunden.");
            }
            player.SetData("offer_price", 0);
            player.SetData("offer_amount", 0);
            player.SetData("offer", false);
        }
        else if (response == "HEROIN_OFFER")
        {
            Client selling = NAPI.Data.GetEntityData(player, "offer_seller");
            if (Main.IsPlayerLogged(selling) && selling.GetData("status") == true)
            {
                int index = Inventory.GetInventoryIndexFromName(selling, "Kokain");

                if (selling.GetData("inventory_item_" + index + "_amount") >= player.GetData("offer_amount"))
                {
                    if (Main.GetPlayerMoney(player) < player.GetData("offer_price"))
                    {
                        Main.SendErrorMessage(player, "Der Verkäufer verkauft von " + player.GetData("offer_price") + ". Sie haben dieses Geld nicht in Ihren Händen..");
                        return;
                    }

                    Inventory.RemoveItem(selling, "Kokain", player.GetData("offer_amount"));
                    Inventory.GiveItemToInventory(player, 16, player.GetData("offer_amount"));

                    NAPI.Notification.SendNotificationToPlayer(player, "Du hast es gekauft. " + player.GetData("offer_amount") + " Kokain für " + player.GetData("offer_price") + " von " + AccountManage.GetCharacterName(selling) + ".");
                    Main.SendSuccessMessage(selling, "Du hast verkauft " + player.GetData("offer_amount") + " Kokain für " + player.GetData("offer_price") + " zu " + AccountManage.GetCharacterName(player) + ".");

                    Main.GivePlayerMoney(player, -player.GetData("offer_price"));
                    Main.GivePlayerMoney(selling, player.GetData("offer_price"));
                }
            }
            else
            {
                Main.SendErrorMessage(player, "Wer Ihnen das Angebot geschickt hat, ist nicht mehr verbunden.");
            }
            player.SetData("offer_price", 0);
            player.SetData("offer_amount", 0);
            player.SetData("offer", false);
        }
    }

    public static void ModalCancel(Client player, string response)
    {
        if (response == "WEED_OFFER")
        {
            player.SetData("offer_price", 0);
            player.SetData("offer_amount", 0);
            player.SetData("offer", false);
        }
    }
}