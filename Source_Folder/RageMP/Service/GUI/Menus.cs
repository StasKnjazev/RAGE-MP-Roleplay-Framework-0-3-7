using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Data;
using System.IO;
using System.Timers;
using GTANetworkAPI;
using MySql.Data.MySqlClient;
using DerStr1k3r.Core;
using DerStr1k3r.SDK;

public class Menus : Script
{
    private static List<dynamic> mechanic_custom_engine = new List<dynamic>();
    private static List<dynamic> mechanic_custom_break = new List<dynamic>();
    private static List<dynamic> mechanic_custom_suspensioon = new List<dynamic>();
    private static List<dynamic> mechanic_custom_armor = new List<dynamic>();
    private static List<dynamic> mechanic_custom_colors = new List<dynamic>();
    private static List<dynamic> mechanic_custom_metal = new List<dynamic>();
    private static List<dynamic> mechanic_custom_matte = new List<dynamic>();

    public static ColShape upgrade_vehicle;

    public static Timer repairTimer = null;

    public static void MechanicInit()
    {
      
    }

    public static void CreateMenu(Client player, int menu_type)
    {
        //player.TriggerEvent("DestroyMenu");
        List<dynamic> menu_item_list = new List<dynamic>();
        switch (menu_type)
        {
            case 10:
                {
    
                    menu_item_list.Add(new { Type = 1, Name = "Job annehmen", Description = "", RightLabel = "" });

                    if (AccountManage.GetPlayerJob(player) == 3)
                    {
                        menu_item_list.Add(new { Type = 1, Name = "Taxi einfügen", Description = "", RightLabel = "" });
                    }

                    InteractMenu.CreateMenu(player,  "TAXI_MENU", "JOB", "~b~Taxifahrer", true, NAPI.Util.ToJson(menu_item_list), false);

                    //player.TriggerEvent("Create_Menu", "TAXI_MENU", "Taxistas", "Menu dos Taxista", "EXIT_MECHANIC_JOB", NAPI.Util.ToJson(menu_item_list), null);
                    break;
                }
            case 11:
                {
                    int count = 0;
                    for (int index = 0; index < PlayerVehicle.MAX_PLAYER_VEHICLES; index++)
                    {
                        if (PlayerVehicle.vehicle_data[Main.getIdFromClient(player)].model[index] != "")
                        {
                            if (PlayerVehicle.vehicle_data[Main.getIdFromClient(player)].ticket[index] != 0)
                            {
                                menu_item_list.Add(new { Type = 1, Name = PlayerVehicle.vehicle_data[Main.getIdFromClient(player)].model[index], Description = "", RightLabel = "~y~$~g~" + PlayerVehicle.vehicle_data[Main.getIdFromClient(player)].ticket[index].ToString("N0") + " em multas" });
                                player.SetData("ListTrack_" + count + "", index);
                                count++;
                            }
                        }
                    }
                    if(count == 0)
                    {
                        Main.DisplayErrorMessage(player, "Sie müssen keine Geldstrafen zahlen.");
                        return;
                    }
                    InteractMenu.CreateMenu(player,  "PAY_TICKETS", "GELDBUSSEN", "~b~Bußgelder zahlen", true, NAPI.Util.ToJson(menu_item_list), false);

                    //player.TriggerEvent("Create_Menu", "PAY_TICKETS", "Multas", "Pagar mulas", "EXIT_MECHANIC_JOB", NAPI.Util.ToJson(menu_item_list), null);

                    break;
                }
            case 12:
                {

                    menu_item_list.Add(new { Type = 1, Name = "Job annehmen", Description = "", RightLabel = "" });

                    if (AccountManage.GetPlayerJob(player) == 4)
                    {
                        menu_item_list.Add(new { Type = 1, Name = "Job gehen", Description = "Nehme den Müllwagen und geh in den Dienst.", RightLabel = "" });
                    }

                    InteractMenu.CreateMenu(player,  "GARBAGE_MENU", "MÜLL", "~b~Job", true, NAPI.Util.ToJson(menu_item_list), false);

                    //player.TriggerEvent("Create_Menu", "GARBAGE_MENU", "Lixeiro", "Menu do Emprego", "EXIT_MECHANIC_JOB", NAPI.Util.ToJson(menu_item_list), null);
                    break;
                }
            case 13:
                {

                    int business_id = Business.GetPlayerInBusinessInType(player, 3), count = 0, listtrack = 0;

                    if(business_id == -1)
                    {
                        Main.DisplayErrorMessage(player, "Sie sind nicht in einer Firma.");
                        return;
                    }

                    foreach (var color in Ammunation.ammunation_weapon_list)
                    {

                        if (Business.business_list[business_id].business_ammunation_price[count] > 0)
                        {
                            menu_item_list.Add(new { Type = 1, Name = color.model, Description = "", RightLabel = "~g~$~y~"+ Business.business_list[business_id].business_ammunation_price[count].ToString("N0") + "" });

                            player.SetData("listitem_track_id_" + listtrack + "", count);
                            listtrack++;
                        }

                        count++;
                    }

                    if(listtrack == 0)
                    {
                        Main.DisplayErrorMessage(player, "Dieser Laden verkauft derzeit keine Waffen.");
                        return;
                    }
                    InteractMenu.CreateMenu(player,  "AMMUNATION_BUY", "", "~b~LISTE DER VERFÜGBAREN WAFFEN", true, NAPI.Util.ToJson(menu_item_list), false, BackgroundSprite: "shopui_title_gunclub");

                    //player.TriggerEvent("Create_Menu", "AMMUNATION_BUY", "Ammunation", "~o~LISTA DE ARMAS DISPONÍVEIS", "EXIT_MECHANIC_JOB", NAPI.Util.ToJson(menu_item_list), "shopui_title_gunclub");
                    break;
                }
            case 14:
                {
                    int business_id = Business.GetPlayerInBusinessInType(player, 3), count = 0;

                    if (business_id == -1)
                    {
                        Main.DisplayErrorMessage(player, "Sie sind nicht in einer Firma.");
                        return;
                    }

                    foreach (var color in Ammunation.ammunation_weapon_list)
                    {

                        menu_item_list.Add(new { Type = 1, Name = color.model, Description = "", RightLabel = "~g~$~y~" + Business.business_list[business_id].business_ammunation_price[count].ToString("N0") + "" });

                        count++;
                    }

                    if(count == 0)
                    {
                        return;
                    }

                    InteractMenu.CreateMenu(player,  "AMMUNATION_EDITING", "", "~b~PREIS", true, NAPI.Util.ToJson(menu_item_list), false, BackgroundSprite: "shopui_title_gunclub");

                    //player.TriggerEvent("Create_Menu", "AMMUNATION_EDITING", "Ammunation", "~o~EDITAR PREÇO DOS ITENS", "EXIT_MECHANIC_JOB", NAPI.Util.ToJson(menu_item_list), "shopui_title_gunclub");
                    break;
                }
            case 15:
                {
                    int business_id = Business.GetPlayerInBusinessInType(player, 3);

                    if (business_id == -1)
                    {
                        Main.DisplayErrorMessage(player, "Sie sind nicht in einer Firma.");
                        return;
                    }

                    if (Business.business_list[business_id].business_Type != 3)
                    {
                        Main.DisplayErrorMessage(player, "Du bist nicht in einem Waffenladen.");
                        return;
                    }
                    menu_item_list.Add(new { Type = 1, Name = "Waffen", Description = "", RightLabel = "" });
                    menu_item_list.Add(new { Type = 1, Name = "Munition", Description = "", RightLabel = "" });
                    InteractMenu.CreateMenu(player,  "AMMUNATION_RESPONSE", "", "~o~" + Business.business_list[business_id].business_Name + "", true, NAPI.Util.ToJson(menu_item_list), false, BackgroundSprite: "shopui_title_gunclub");

                    //player.TriggerEvent("Create_Menu", "AMMUNATION_RESPONSE", "Ammunation", "~o~"+ Business.business_list[business_id].business_Name+ "", "EXIT_MECHANIC_JOB", NAPI.Util.ToJson(menu_item_list), "shopui_title_gunclub");
                    break;
                }
            case 16:
                {

                    menu_item_list.Add(new { Type = 1, Name = "~y~15x~s~ Munition 7.62 (Sniper Rifles)", Description = "~y~Sniper Rifles~w~.", RightLabel = "$"+Economy.PRECO_MUNICAO_SNIPER+"" });
                    menu_item_list.Add(new { Type = 1, Name = "~y~100x~s~ Munition 7.62 (Assault Rifles)", Description = "~y~Assault Rifles~w~.", RightLabel = "$" + Economy.PRECO_MUNICAO_ASSAULT + "" });
                    menu_item_list.Add(new { Type = 1, Name = "~y~30x~s~ Munition 12x (Shotguns)", Description = "~y~Shotguns~w~.", RightLabel = "$" + Economy.PRECO_MUNICAO_SHOTGUN + "" });
                    menu_item_list.Add(new { Type = 1, Name = "~y~200x~s~ Munition 9mm (Pistolas)", Description = "~y~Pistol~w~.", RightLabel = "$" + Economy.PRECO_MUNICAO_PISTOL + "" });
                    menu_item_list.Add(new { Type = 1, Name = "~y~350x~s~ Munition 45x (Micro-SMG)", Description = "~y~Micro SMG~w~.", RightLabel = "$" + Economy.PRECO_MUNICAO_SMG + "" });

                    InteractMenu.CreateMenu(player,  "AMMUNATION_BUY_AMMO", "", "~o~LISTE DER VERFÜGBAREN MUNITION", true, NAPI.Util.ToJson(menu_item_list), false, BackgroundSprite: "shopui_title_gunclub");

                    //player.TriggerEvent("Create_Menu", "AMMUNATION_BUY_AMMO", "Ammunation", "~o~LISTA DE MUNIÇÕES DISPONÍVEIS", "EXIT_MECHANIC_JOB", NAPI.Util.ToJson(menu_item_list), "shopui_title_gunclub");
                    break;
                }

        }
    }

    public static void SelectMenuResponse(Client player, String callbackId, int selectedIndex, String objectName, String valueList)
    {
        int listitem = selectedIndex;
        switch (callbackId)
        {
            case "null": break;
            case "AMMUNATION_RESPONSE":
                {
                    //player.TriggerEvent("DestroyMenu");

                    if (listitem == 0)
                    {
                        CreateMenu(player, 13);
                    }
                    else if (listitem == 1)
                    {
                        CreateMenu(player, 16);
                    }
                    break;
                }
            case "AMMUNATION_BUY":
                {
                    //player.TriggerEvent("DestroyMenu");

                    int business_id = Business.GetPlayerInBusinessInType(player, 3), weapon_id = player.GetData("listitem_track_id_" + listitem + "");

                    if (business_id == -1)
                    {
                        Main.DisplayErrorMessage(player, "Sie sind nicht in einer Firma.");
                        return;
                    }

                    if (Business.business_list[business_id].business_Type != 3)
                    {
                        Main.DisplayErrorMessage(player, "Você não está em uma Loja de Armas.");
                        return;
                    }

                    if (Business.business_list[business_id].business_Inventory < 1)
                    {
                        Main.DisplayErrorMessage(player, "Artikel sind derzeit nicht vorrätig.");
                        return;
                    }

                    if (Main.GetPlayerMoney(player) < Business.business_list[business_id].business_ammunation_price[weapon_id])
                    {
                        Main.DisplayErrorMessage(player, "Du hast nicht genug Geld.");
                        return;
                    }

                    //WeaponManage.GivePlayerWeaponEx(player, Ammunation.ammunation_weapon_list[weapon_id].model, 0, true, false);

                    WeaponManage.SetPlayerWeaponEx(player, Ammunation.ammunation_weapon_list[weapon_id].model, 30);
                    NAPI.Player.SetPlayerCurrentWeaponAmmo(player, 30);

                    //player.SendChatMessage("~g~INFO:~w~ Você comprou ~y~" + Ammunation.ammunation_weapon_list[weapon_id].model + "~w~ por ~g~$" + Business.business_list[business_id].business_ammunation_price[weapon_id] + "~w~.");

                    Main.GivePlayerMoney(player, -Business.business_list[business_id].business_ammunation_price[weapon_id]);
                    Business.business_list[business_id].business_Inventory--;
                    Business.business_list[business_id].business_Safe += Business.business_list[business_id].business_ammunation_price[weapon_id];
                    break;
                }
            case "AMMUNATION_BUY_AMMO":
                {
                    //player.TriggerEvent("DestroyMenu");

                    int business_id = Business.GetPlayerInBusinessInType(player, 3);

                    if (business_id == -1)
                    {
                        Main.DisplayErrorMessage(player, "Sie sind nicht in einer Firma.");
                        return;
                    }

                    if (Business.business_list[business_id].business_Type != 3)
                    {
                        Main.DisplayErrorMessage(player, "Du bist nicht in einem Waffenladen.");
                        return;
                    }

                    if (Business.business_list[business_id].business_Inventory < 1)
                    {
                        Main.DisplayErrorMessage(player, "Artikel sind derzeit nicht vorrätig.");
                        return;
                    }
                    switch (listitem)
                    {
                        case 0:
                            {
                                if (Main.GetPlayerMoney(player) < Economy.PRECO_MUNICAO_SNIPER)
                                {
                                    Main.DisplayErrorMessage(player, Translation.message_14);
                                    return;
                                }
                                //player.SendChatMessage("~g~INFO:~w~ Você comprou ~y~15x ~b~Munição 7.62 (Sniper Rifles)~w~ por ~g~$" + Economy.PRECO_MUNICAO_SNIPER + "~w~.");
                                Main.GivePlayerMoney(player, -Economy.PRECO_MUNICAO_SNIPER);

                                NAPI.Notification.SendNotificationToPlayer(player, "~g~(Sniper Rifles)~g~ Munition wurde Ihrem Inventar hinzugefügt.", false);

                                Business.business_list[business_id].business_Inventory--;
                                Business.business_list[business_id].business_Safe += Economy.PRECO_MUNICAO_SNIPER;

                                Inventory.GiveItemToInventory(player, 3, 15);
                                break;
                            }
                        case 1:
                            {
                                if (Main.GetPlayerMoney(player) < Economy.PRECO_MUNICAO_ASSAULT)
                                {
                                    Main.DisplayErrorMessage(player, Translation.message_14);
                                    return;
                                }
                                //player.SendChatMessage("~g~INFO:~w~ Você comprou ~y~100x ~b~Munição 7.62 (Assault Rifles)~w~ por ~g~$" + Economy.PRECO_MUNICAO_ASSAULT + "~w~.");
                                Main.GivePlayerMoney(player, -Economy.PRECO_MUNICAO_ASSAULT);

                                NAPI.Notification.SendNotificationToPlayer(player, "~g~(Assault Rifles)~g~ Munition wurde Ihrem Inventar hinzugefügt.", false);
                                Business.business_list[business_id].business_Inventory--;
                                Business.business_list[business_id].business_Safe += Economy.PRECO_MUNICAO_ASSAULT;

                                Inventory.GiveItemToInventory(player, 4, 100);
                                break;
                            }
                        case 2:
                            {
                                if (Main.GetPlayerMoney(player) < Economy.PRECO_MUNICAO_SHOTGUN)
                                {
                                    Main.DisplayErrorMessage(player, Translation.message_14);
                                    return;
                                }
                                //player.SendChatMessage("~g~INFO:~w~ Você comprou ~y~30x ~b~Munição de 12 (Shotguns)~w~ por ~g~$" + Economy.PRECO_MUNICAO_SHOTGUN + "~w~.");
                                Main.GivePlayerMoney(player, -Economy.PRECO_MUNICAO_SHOTGUN);

                                NAPI.Notification.SendNotificationToPlayer(player, "~g~(Shotguns)~w~ Munition wurde Ihrem Inventar hinzugefügt.", false);
                                Business.business_list[business_id].business_Inventory--;
                                Business.business_list[business_id].business_Safe += Economy.PRECO_MUNICAO_SHOTGUN;

                                Inventory.GiveItemToInventory(player, 5, 30);
                                break;
                            }
                        case 3:
                            {
                                if (Main.GetPlayerMoney(player) < Economy.PRECO_MUNICAO_PISTOL)
                                {
                                    Main.DisplayErrorMessage(player, Translation.message_14);
                                    return;
                                }
                                //player.SendChatMessage("~g~INFO:~w~ Você comprou ~y~200x ~b~Munição 9mm (Pistolas)~w~ por ~g~$" + Economy.PRECO_MUNICAO_PISTOL + "~w~.");
                                Main.GivePlayerMoney(player, -Economy.PRECO_MUNICAO_PISTOL);

                                NAPI.Notification.SendNotificationToPlayer(player, "~g~(Pistol)~g~ Munition wurde Ihrem Inventar hinzugefügt.", false);
                                Business.business_list[business_id].business_Inventory--;
                                Business.business_list[business_id].business_Safe += Economy.PRECO_MUNICAO_PISTOL;

                                Inventory.GiveItemToInventory(player, 6, 200);
                                break;
                            }
                        case 4:
                            {
                                if (Main.GetPlayerMoney(player) < Economy.PRECO_MUNICAO_SMG)
                                {
                                    Main.DisplayErrorMessage(player, Translation.message_14);
                                    return;
                                }
                                //player.SendChatMessage("~g~INFO:~w~ Você comprou ~y~350x ~b~Munição de .45 (Micro-SMG)~w~ por ~g~$" + Economy.PRECO_MUNICAO_SMG + "~w~.");
                                Main.GivePlayerMoney(player, -Economy.PRECO_MUNICAO_SMG);

                                NAPI.Notification.SendNotificationToPlayer(player, "~g~(Micro-SMG)~g~ Munition wurde Ihrem Inventar hinzugefügt.", false);
                                Business.business_list[business_id].business_Inventory--;
                                Business.business_list[business_id].business_Safe += Economy.PRECO_MUNICAO_SMG;

                                Inventory.GiveItemToInventory(player, 7, 350);
                                break;
                            }
                    }
                    break;
                }
            case "AMMUNATION_EDITING":
                {
                    player.SetData("editingWeapon", listitem);
                    int weapon_id = player.GetData("editingWeapon"), business_id = Business.GetPlayerInBusinessInType(player, 3);
                    InteractMenu.User_Input(player, "input_editing_weapon", "Preis bearbeiten", Business.business_list[business_id].business_ammunation_price[weapon_id].ToString(), "", "number");
                    
                    //NAPI.ClientEvent.TriggerClientEvent(player, "GetUserInput", "", "INPUT_EDITING_WEAPON", 4);
                    break;
                }
            case "PAY_TICKETS":
                {
                    int index = player.GetData("ListTrack_" + listitem + "");

                    if (PlayerVehicle.vehicle_data[Main.getIdFromClient(player)].model[index] != "")
                    {

                        if (PlayerVehicle.vehicle_data[Main.getIdFromClient(player)].ticket[index] == 0)
                        {
                            Main.SendErrorMessage(player, "Sie müssen keine Geldstrafen für dieses Fahrzeug bezahlen.");
                            return;
                        }


                        NAPI.Notification.SendNotificationToPlayer(player, "Bezahlt: ~g~$" + PlayerVehicle.vehicle_data[Main.getIdFromClient(player)].ticket[index] + "~w~ für ~y~" + PlayerVehicle.vehicle_data[Main.getIdFromClient(player)].model[index] + "~w~.");

                        PlayerVehicle.vehicle_data[Main.getIdFromClient(player)].ticket[index] = 0;
                        PlayerVehicle.SavePlayerVehicle(player, index);
                    }
                    else
                    {
                        Main.SendErrorMessage(player, "Sie haben keine Fahrzeuge im Steckplatz " + index + ".");
                    }
                    break;
                }
           
           
            default:
                {
                    break;
                }
        }
    }

    public static void ListItemMenuResponse(Client player, String callbackId, int selectedIndex, String objectName, String valueList, int valueIndex)
    {
    }

    public static void OnMenuReturnClose(Client player, String callbackId)
    {
        switch (callbackId)
        {
            case "EXIT_MECHANIC_JOB":
                {
                    player.TriggerEvent("freeze", false);
                    break;
                }

        }
    }

    

    [Command("modmod")]
    public void CMD_mod(Client player, int modType, int mod)
    {
        player.Vehicle.SetMod(modType, mod);
    }


    public static void OnInputResponse(Client player, String response, String inputtext)
    {
        if(response == "input_editing_weapon")
        {
            int weapon_id = player.GetData("editingWeapon"), business_id = Business.GetPlayerInBusinessInType(player, 3);

            if (business_id == -1)
            {
                Main.DisplayErrorMessage(player, "Sie sind nicht in einer Firma.");
                return;
            }

            if (Business.business_list[business_id].business_Type != 3)
            {
                Main.DisplayErrorMessage(player, "Das war nicht möglich.");
                return;
            }

            if (!Main.IsNumeric(inputtext))
            {
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Ungültiger eingegebener Wert.", 5000);
                return;
            }

            if (inputtext.Length == 0)
            {
                Main.DisplaySubtitle(player, "ERROR:~w~ Der Preis darf nicht unter 1 liegen.", 3);
                Inventory.ShowPlayerInventory(player);
                return;
            }

            int amount = Convert.ToInt32(inputtext);

            if (amount < 1)
            {
                Main.DisplaySubtitle(player, "ERROR:~w~ Der Preis darf nicht unter 1 liegen.", 3);
                return;
            }

            if (amount > 100000)
            {
                Main.DisplaySubtitle(player, "ERROR:~w~ Der Preis darf nicht höher als 100000 sein.", 3);
                return;
            }

            player.TriggerEvent("DestroyMenu");
            NAPI.Task.Run(() =>
            {
                CreateMenu(player, 14);
            }, delayTime: 500);

            Business.business_list[business_id].business_ammunation_price[weapon_id] = amount;
            Business.SaveBusiness(business_id);
            Main.SendSuccessMessage(player, "Sie haben den Preis von ~b~" + Ammunation.ammunation_weapon_list[weapon_id].model + " bearbeitet.");


        }
       

    }
}

