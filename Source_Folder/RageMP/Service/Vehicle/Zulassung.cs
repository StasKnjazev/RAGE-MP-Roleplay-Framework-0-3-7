using System;
using System.Collections.Generic;
using GTANetworkAPI;
using Newtonsoft.Json;
using DerStr1k3r.Core;
using DerStr1k3r.SDK;

class Zulassung : Script
{
    private static List<dynamic> kfz_zulassung = new List<dynamic>();
    public static int PRICE_KFZPLATE = 350;
    public static int PRICE_KFZPLATE2 = 250;
    public static List<dynamic> kfz = new List<dynamic>();

    public Zulassung()
    {

    }

    public static void OnPlayerConnected(Client player)
    {
        kfz_zulassung.Add(new { position = new Vector3(307.87268, -1550.5299, 29.329536) });

        foreach (var Veh_Zulassung in kfz_zulassung)
        {
            ColShape kfz_zulassung = NAPI.ColShape.CreateSphereColShape(Veh_Zulassung.position, 5f);
            NAPI.Marker.CreateMarker(27, Veh_Zulassung.position - new Vector3(0, 0, 0.8f), new Vector3(), new Vector3(), 5.0f, new Color(255, 255, 255, 110), false, 0);
        }
    }

    public static void PlayerPressKeyE(Client player)
    {
        if (Main.IsInRangeOfPoint(player.Position, new Vector3(307.87268, -1550.5299, 29.329536), 3.0f))
        {
            int playerid = Main.getIdFromClient(player);
            List<dynamic> menu_item_list = new List<dynamic>();

            menu_item_list.Add(new { Type = 1, Name = "Fahrzeug anmelden", Description = "Hiermit meldest du dein Fahrzeug an.", RightLabel = "$" + Zulassung.PRICE_KFZPLATE.ToString() + "" });
            menu_item_list.Add(new { Type = 1, Name = "Fahrzeug abmelden", Description = "Hiermit meldest du dein Fahrzeug ab.", RightLabel = "$" + Zulassung.PRICE_KFZPLATE2.ToString() + "" });
            InteractMenu.CreateMenu(player, "KFZ_NEW_PLATE_SHIELD", "Straßenverkehrsamt", "~g~Fahrzeug Ab & Anmeldung:", false, NAPI.Util.ToJson(menu_item_list), false, BackgroundColor: "Green");
        }
    }

    public static void SelectMenuResponse(Client player, String callbackId, int selectedIndex, String objectName, String valueList)
    {
        if (callbackId == "KFZ_NEW_PLATE_SHIELD")
        {
            switch (selectedIndex)
            {
                case 0:
                    {
                        if (Main.IsInRangeOfPoint(player.Position, new Vector3(307.87268, -1550.5299, 29.329536), 3.0f))
                        {
                            //CLIENT CRASHING TO MOVE THE INPUT
                            //if (player.IsInVehicle)
                            //{
                            //    for (int index = 0; index < PlayerVehicle.MAX_PLAYER_VEHICLES; index++)
                            //    {
                            //        int playerid = Main.getIdFromClient(player);
                            //        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Die Zulassung für dein " + PlayerVehicle.vehicle_data[playerid].model[index] + " beträgt $" + PRICE_KFZPLATE.ToString() + "!", 5000);
                            //        if (PlayerVehicle.vehicle_data[playerid].state[index] == 1)
                            //        {
                            //            InteractMenu.User_Input(player, "input_kfzplate_name", "Fahrzeug Zulassung für: " + PlayerVehicle.vehicle_data[playerid].model[index] + "", PlayerVehicle.vehicle_data[playerid].plate[index]);
                            //            InteractMenu.CloseDynamicMenu(player);
                            //        }
                            //    }
                            //}
                            int playerid = Main.getIdFromClient(player);
                            Random rnd = new Random();
                            int vehplate = rnd.Next(1, 999);
                            string name = "LS " + player.GetData("character_sqlid") + "" + vehplate + "";
                            
                            if (player.IsInVehicle)
                            {
                                for (int index = 0; index < PlayerVehicle.MAX_PLAYER_VEHICLES; index++)
                                {
                                    if (PlayerVehicle.vehicle_data[playerid].state[index] == 1)
                                    {
                                        PlayerVehicle.vehicle_data[playerid].plate[index] = name.ToString();

                                        if (PlayerVehicle.vehicle_data[playerid].handle[index].Exists && PlayerVehicle.vehicle_data[playerid].handle[index] == player.Vehicle)
                                        {
                                            PlayerVehicle.vehicle_data[playerid].plate[index] = name.ToString();

                                            PlayerVehicle.SavePlayerVehicle(player, index);
                                            Notify.Send(player, NotifyType.Success, NotifyPosition.BottomCenter, $"Sie haben Ihr " + PlayerVehicle.vehicle_data[playerid].model[index] + " für $" + PRICE_KFZPLATE.ToString() + " zugelassen.", 5000);
                                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Das neue Nummernschild lautet wie folgt: " + name.ToString() + "", 5000);
                                            //NAPI.Notification.SendNotificationToPlayer(player, "<C>Straßenverkehrsamt:</C> ~n~Sie haben Ihr " + PlayerVehicle.vehicle_data[playerid].model[index] + " für $" + Zulassung.PRICE_KFZPLATE.ToString() + " abgemeldet.");
                                            Main.GivePlayerMoney(player, -PRICE_KFZPLATE2);
                                            NAPI.Vehicle.SetVehicleNumberPlate(player.Vehicle, name.ToString());
                                            return;
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    }
                case 1:
                    {
                        if (Main.IsInRangeOfPoint(player.Position, new Vector3(307.87268, -1550.5299, 29.329536), 3.0f))
                        {
                            string name = "NL";
                            int playerid = Main.getIdFromClient(player);
                            if (player.IsInVehicle)
                            {
                                for (int index = 0; index < PlayerVehicle.MAX_PLAYER_VEHICLES; index++)
                                {
                                    if (PlayerVehicle.vehicle_data[playerid].state[index] == 1)
                                    {
                                        PlayerVehicle.vehicle_data[playerid].plate[index] = name.ToString();

                                        if (PlayerVehicle.vehicle_data[playerid].handle[index].Exists && PlayerVehicle.vehicle_data[playerid].handle[index] == player.Vehicle)
                                        {
                                            PlayerVehicle.vehicle_data[playerid].plate[index] = name.ToString();

                                            PlayerVehicle.SavePlayerVehicle(player, index);
                                            Notify.Send(player, NotifyType.Success, NotifyPosition.BottomCenter, $"Sie haben Ihr " + PlayerVehicle.vehicle_data[playerid].model[index] + " für $" + PRICE_KFZPLATE.ToString() + " abgemeldet.", 5000);
                                            //NAPI.Notification.SendNotificationToPlayer(player, "<C>Straßenverkehrsamt:</C> ~n~Sie haben Ihr " + PlayerVehicle.vehicle_data[playerid].model[index] + " für $" + Zulassung.PRICE_KFZPLATE.ToString() + " abgemeldet.");
                                            Main.GivePlayerMoney(player, -PRICE_KFZPLATE2);
                                            NAPI.Vehicle.SetVehicleNumberPlate(player.Vehicle, name.ToString());
                                            return;
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    }
            }
        }
    }

    public static void OnInputResponse(Client player, String response, String inputtext)
    {
        if (response == "input_kfzplate_name")
        {
            int playerid = Main.getIdFromClient(player);

            string name = inputtext.ToString();
            if (String.IsNullOrEmpty(name))
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"Diese Art von Nummernschilder ist nicht erlaubt!", 5000);
                return;
            }

            if (player.IsInVehicle)
            {
                for (int index = 0; index < PlayerVehicle.MAX_PLAYER_VEHICLES; index++)
                {
                    if (PlayerVehicle.vehicle_data[playerid].state[index] == 1)
                    {
                        PlayerVehicle.vehicle_data[playerid].plate[index] = name.ToString();

                        if (PlayerVehicle.vehicle_data[playerid].handle[index].Exists && PlayerVehicle.vehicle_data[playerid].handle[index] == player.Vehicle)
                        {
                            PlayerVehicle.vehicle_data[playerid].plate[index] = name.ToString();

                            PlayerVehicle.SavePlayerVehicle(player, index);
                            NAPI.Notification.SendNotificationToPlayer(player, "<C>Straßenverkehrsamt:</C> ~n~Sie haben Ihr " + PlayerVehicle.vehicle_data[playerid].model[index] + " für $" + Zulassung.PRICE_KFZPLATE.ToString() + " zugelassen.");
                            Main.GivePlayerMoney(player, -PRICE_KFZPLATE);
                            NAPI.Vehicle.SetVehicleNumberPlate(player.Vehicle, name.ToString());
                            return;
                        }
                    }
                }
            }
        }
    }
}
