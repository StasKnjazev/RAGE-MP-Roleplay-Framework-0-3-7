using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;
using DerStr1k3r.Core;
using DerStr1k3r.SDK;


class illegaleWaffen : Script
{
    public static int PRICE_Gusenberg = 265000;
    public static int PRICE_Pistol50 = 90500;
    public static int PRICE_Assault = 280000;
    public static int PRICE_Machete = 45000;
    public static int PRICE_revolver = 120000;
    public static int PRICE_pump = 220000;
    public static int PRICE_carabiner = 265000;


    public illegaleWaffen()
    {

    }

    [ServerEvent(Event.PlayerConnected)]
    public void OnPlayerConnected(Client player)
    {
        // player.TriggerEvent("Sync_PedCreate", "apotheke", NAPI.Util.PedNameToModel("Doctor01SMM"), new Vector3(268.9323, -1365.9414, 24.537785), 8.566136f, "", 0);
        player.TriggerEvent("Sync_PedCreate", "clearmoney", NAPI.Util.PedNameToModel("GenFat01AMM"), new Vector3(-1137.9171, 4873.4644, 212.07933), -100.82297f, "", 0);
    }

    public static void PressKeyE(Client player)
    {
   
            if (Main.IsInRangeOfPoint(player.Position, new Vector3(-1137.9171, 4873.4644, 212.07933), 1.0f))
            {
           
            List<dynamic> menu_item_list = new List<dynamic>();
            menu_item_list.Add(new { Type = 1, Name = "~c~1x~w~ Gusenberg", Description = "Meinungsverstärker.", RightLabel = "~g~$"+ PRICE_Gusenberg.ToString("N0")+ "" });
            menu_item_list.Add(new { Type = 1, Name = "~c~1x~w~ Pistol 50er", Description = "Das ist ne richtige Knarre.", RightLabel = "~g~$" + PRICE_Pistol50.ToString("N0") + "" });              
            menu_item_list.Add(new { Type = 1, Name = "~c~1x~w~ AK-47", Description = "Macht große löscher.", RightLabel = "~g~$" + PRICE_Assault.ToString("N0") + "" });
            menu_item_list.Add(new { Type = 1, Name = "~c~1x~w~ Machete", Description = "Doppelte Action.", RightLabel = "~g~$" + PRICE_Machete.ToString("N0") + "" });
            menu_item_list.Add(new { Type = 1, Name = "~c~1x~w~ Revolver", Description = "Boom, Loch ist da .", RightLabel = "~g~$" + PRICE_revolver.ToString("N0") + "" });
            menu_item_list.Add(new { Type = 1, Name = "~c~1x~w~ Pumgun", Description = "Boom, Loch ist da .", RightLabel = "~g~$" + PRICE_pump.ToString("N0") + "" });
            menu_item_list.Add(new { Type = 1, Name = "~c~1x~w~ Carabiner", Description = "Boom, Loch ist da .", RightLabel = "~g~$" + PRICE_carabiner.ToString("N0") + "" });

            InteractMenu.CreateMenu(player, "ILLEGALEWAFFEN_ITENS", "illegale Waffen", "~b~Schau was ich feines für dich habe:", true, NAPI.Util.ToJson(menu_item_list), false);
          
            }
      
    }

  

    public static void SelectMenuResponse(Client player, String callbackId, int selectedIndex, String objectName, String valueList)
    {
        if(callbackId == "ILLEGALEWAFFEN_ITENS")
        {
            if (selectedIndex == 0)
            {
                if (Main.GetPlayerMoney(player) < PRICE_Gusenberg)
                {
                    Main.SendErrorMessage(player, "Sie haben dieses Geld nicht zur Hand, dieser Artikel kostet $" + PRICE_Gusenberg + " und du hast nur $" + Main.GetPlayerMoney(player) + ".");
                    return;
                }

                if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 85, 1, Inventory.Max_Inventory_Weight(player)))
                {
                    return;
                }

                Main.GivePlayerMoney(player, -PRICE_Gusenberg);
                Inventory.GiveItemToInventory(player, 141, 1);
                Main.SendSuccessMessage(player, "Du hast es gekauft. " + Main.EMBED_LIGHTGREEN + "1x Gusenberg" + Main.EMBED_WHITE + " von " + Main.EMBED_GREEN + "$" + PRICE_Gusenberg.ToString("N0") + "" + Main.EMBED_WHITE + ".");
            }
            else if (selectedIndex == 1)
            {
                if (Main.GetPlayerMoney(player) < PRICE_Pistol50)
                {
                    Main.SendErrorMessage(player, "Sie haben dieses Geld nicht zur Hand, dieser Artikel kostet$" + PRICE_Pistol50 + " und du hast nur $" + Main.GetPlayerMoney(player) + ".");
                    return;
                }

                if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 72, 1, Inventory.Max_Inventory_Weight(player)))
                {
                    return;
                }
                Inventory.GiveItemToInventory(player, 120, 1);
                Main.GivePlayerMoney(player, -PRICE_Pistol50);
                Main.SendSuccessMessage(player, "Du hast es gekauft." + Main.EMBED_LIGHTGREEN + "1x Pistol50 erhalten" + Main.EMBED_WHITE + " von " + Main.EMBED_GREEN + "$" + PRICE_Pistol50.ToString("N0") + "" + Main.EMBED_WHITE + ".");
            }
           
           
            
            
            else if (selectedIndex == 2)
            {
                if (Main.GetPlayerMoney(player) < PRICE_Assault)
                {
                    Main.SendErrorMessage(player, "Sie haben dieses Geld nicht zur Hand, dieser Artikel kostet$" + PRICE_Assault + " und du hast nur $" + Main.GetPlayerMoney(player) + ".");
                    return;
                }

                
                Inventory.GiveItemToInventory(player, 144, 1);
                Main.GivePlayerMoney(player, -PRICE_Assault);
                Main.SendSuccessMessage(player, "Du hast es gekauft." + Main.EMBED_LIGHTGREEN + "1x AK" + Main.EMBED_WHITE + " von " + Main.EMBED_GREEN + "$" + PRICE_Assault.ToString("N0") + "" + Main.EMBED_WHITE + ".");


            }
            else if (selectedIndex == 3)
            {
                if (Main.GetPlayerMoney(player) < PRICE_Machete)
                {
                    Main.SendErrorMessage(player, "Sie haben dieses Geld nicht zur Hand, dieser Artikel kostet$" + PRICE_Machete + " und du hast nur $" + Main.GetPlayerMoney(player) + ".");
                    return;
                }

                if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 90, 1, Inventory.Max_Inventory_Weight(player)))
                {
                    return;
                }
                Inventory.GiveItemToInventory(player, 111, 1);
                Main.GivePlayerMoney(player, -PRICE_Machete);
                Main.SendSuccessMessage(player, "Du hast es gekauft." + Main.EMBED_LIGHTGREEN + "1x Machete" + Main.EMBED_WHITE + " von " + Main.EMBED_GREEN + "$" + PRICE_Machete.ToString("N0") + "" + Main.EMBED_WHITE + ".");


            }
            else if (selectedIndex == 4)
            {
                if (Main.GetPlayerMoney(player) < PRICE_revolver)
                {
                    Main.SendErrorMessage(player, "Sie haben dieses Geld nicht zur Hand, dieser Artikel kostet$" + PRICE_revolver + " und du hast nur $" + Main.GetPlayerMoney(player) + ".");
                    return;
                }

                if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 88, 1, Inventory.Max_Inventory_Weight(player)))
                {
                    return;
                }
                Inventory.GiveItemToInventory(player, 125, 1);
                Main.GivePlayerMoney(player, -PRICE_revolver);
                Main.SendSuccessMessage(player, "Du hast es gekauft." + Main.EMBED_LIGHTGREEN + "1x Revolver" + Main.EMBED_WHITE + " von " + Main.EMBED_GREEN + "$" + PRICE_revolver.ToString("N0") + "" + Main.EMBED_WHITE + ".");


            }
            else if (selectedIndex == 5)
            {
                if (Main.GetPlayerMoney(player) < PRICE_pump)
                {
                    Main.SendErrorMessage(player, "Sie haben dieses Geld nicht zur Hand, dieser Artikel kostet$" + PRICE_pump + " und du hast nur $" + Main.GetPlayerMoney(player) + ".");
                    return;
                }

                
                Inventory.GiveItemToInventory(player, 143, 1);
                Main.GivePlayerMoney(player, -PRICE_pump);
                Main.SendSuccessMessage(player, "Du hast es gekauft." + Main.EMBED_LIGHTGREEN + "1x Pumgun" + Main.EMBED_WHITE + " von " + Main.EMBED_GREEN + "$" + PRICE_pump.ToString("N0") + "" + Main.EMBED_WHITE + ".");


            }
            else if (selectedIndex == 6)
            {
                if (Main.GetPlayerMoney(player) < PRICE_pump)
                {
                    Main.SendErrorMessage(player, "Sie haben dieses Geld nicht zur Hand, dieser Artikel kostet$" + PRICE_pump + " und du hast nur $" + Main.GetPlayerMoney(player) + ".");
                    return;
                }


                Inventory.GiveItemToInventory(player, 145, 1);
                Main.GivePlayerMoney(player, -PRICE_carabiner);
                Main.SendSuccessMessage(player, "Du hast es gekauft." + Main.EMBED_LIGHTGREEN + "1x Carabiner" + Main.EMBED_WHITE + " von " + Main.EMBED_GREEN + "$" + PRICE_carabiner.ToString("N0") + "" + Main.EMBED_WHITE + ".");


            }

        }
    }
}

