using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Data;
using System.IO;
using GTANetworkAPI;
using MySql.Data.MySqlClient;

public class Shipment : Script
{
    public static int MISSION_TYPE_CLOTHES = 1;
    public static int MISSION_TYPE_FUEL = 2;

    private static ColShape combustivel;
    private static ColShape reabastecimento;
    private static ColShape ls_docas;
    private static List<dynamic> shipment_spawn_positions = new List<dynamic>();
    private static List<dynamic> tanker_spawn_positions = new List<dynamic>();

    public static void ShipmentInit()
    {
        shipment_spawn_positions.Add(new { position = new Vector3(-522.2831, -2866.42, 6.233933), rotation = 45.6522f });
        shipment_spawn_positions.Add(new { position = new Vector3(-513.8803, -2857.485, 6.234046), rotation = 45.29362f });
        shipment_spawn_positions.Add(new { position = new Vector3(-509.2549, -2852.311, 6.235158), rotation = 44.92556f });
        shipment_spawn_positions.Add(new { position = new Vector3(-504.2822, -2848.205, 6.235496), rotation = 44.66128f });
        shipment_spawn_positions.Add(new { position = new Vector3(-500.9508, -2843.298, 6.235119), rotation = 43.60129f });
        shipment_spawn_positions.Add(new { position = new Vector3(-496.4277, -2839.228, 6.234237), rotation = 42.41617f });
        shipment_spawn_positions.Add(new { position = new Vector3(-487.0428, -2830.315, 6.234374), rotation = 46.0502f });
        shipment_spawn_positions.Add(new { position = new Vector3(-483.0009, -2825.719, 6.235212), rotation = 46.27613f });
        shipment_spawn_positions.Add(new { position = new Vector3(-478.1009, -2820.859, 6.23531), rotation = 44.10042f });
        shipment_spawn_positions.Add(new { position = new Vector3(-469.3639, -2812.231, 6.235707), rotation = 43.51445f });

        tanker_spawn_positions.Add(new { position = new Vector3(997.5258, -3186.094, 5.900802), rotation = 0f });
        tanker_spawn_positions.Add(new { position = new Vector3(989.4745, -3184.714, 5.900802), rotation = 0f });
        tanker_spawn_positions.Add(new { position = new Vector3(993.5807, -3184.509, 5.900802), rotation = 0f });
        tanker_spawn_positions.Add(new { position = new Vector3(997.5874, -3184.327, 5.900804), rotation = 0f });
        tanker_spawn_positions.Add(new { position = new Vector3(1001.438, -3184.154, 5.900805), rotation = 0f });
        tanker_spawn_positions.Add(new { position = new Vector3(1005.572, -3183.806, 5.900823), rotation = 0f });
        tanker_spawn_positions.Add(new { position = new Vector3(1009.664, -3183.604, 5.900905), rotation = 0f });
        tanker_spawn_positions.Add(new { position = new Vector3(1013.801, -3185.612, 5.900986), rotation = 0f });
        tanker_spawn_positions.Add(new { position = new Vector3(1017.606, -3185.355, 5.900978), rotation = 0f });
        tanker_spawn_positions.Add(new { position = new Vector3(1021.829, -3185.085, 5.900968), rotation = 0f });
        tanker_spawn_positions.Add(new { position = new Vector3(1025.855, -3186.394, 5.901033), rotation = 0f });
        tanker_spawn_positions.Add(new { position = new Vector3(1029.986, -3186.032, 5.901073), rotation = 0f });
        tanker_spawn_positions.Add(new { position = new Vector3(1033.852, -3185.516, 5.901045), rotation = 0f });
        tanker_spawn_positions.Add(new { position = new Vector3(1037.966, -3185.566, 5.901042), rotation = 0f });
        tanker_spawn_positions.Add(new { position = new Vector3(1042.227, -3185.795, 5.901048), rotation = 0f });
        tanker_spawn_positions.Add(new { position = new Vector3(1046.201, -3185.687, 5.901037), rotation = 0f });
        tanker_spawn_positions.Add(new { position = new Vector3(1050.069, -3186.553, 5.901539), rotation = 0f });
        tanker_spawn_positions.Add(new { position = new Vector3(1054.479, -3186.662, 5.901915), rotation = 0f });
        tanker_spawn_positions.Add(new { position = new Vector3(1058.456, -3186.954, 5.901964), rotation = 0f });
        tanker_spawn_positions.Add(new { position = new Vector3(1062.12, -3186.58, 5.901867), rotation = 0f });
        tanker_spawn_positions.Add(new { position = new Vector3(1066.5, -3186.063, 5.903139), rotation = 0f });


        Ped shipment_ped = NAPI.Ped.CreatePed(NAPI.Util.PedNameToModel("DockWork01SMY"), new Vector3(-536.6481, -2846.78, 6.000384), -69.83067f, 0);
        NAPI.Ped.PlayPedScenario(shipment_ped, "CODE_HUMAN_MEDIC_TIME_OF_DEATH");

        NAPI.TextLabel.CreateTextLabel("Drücke ~b~E", new Vector3(-536.6481, -2846.78, 6.000384 + 1.5), 12, 0.350f, 4, new Color(255, 255, 255, 255));

        

        NAPI.Marker.CreateMarker(1, new Vector3(-535.4819, -2846.199, 6.000383 - 1.0), new Vector3(), new Vector3(), 0.6f, new Color(255, 255, 255, 155));

        NAPI.TextLabel.CreateTextLabel("- Produktablage -", new Vector3(-409.1514, -2795.149, 5.589162 + 1.6), 27, 1.1f, 0, new Color(255,255,255,255));
        NAPI.Marker.CreateMarker(23, new Vector3(-409.1514, -2795.149, 5.589162), new Vector3(), new Vector3(), 7.0f, new Color(255, 255, 255, 180));

        NAPI.TextLabel.CreateTextLabel("- Fossile Brennstoffe -", new Vector3(593.6568, -2806.843, 6.059729 + 1.6), 27, 1.1f, 0, new Color(255, 255, 255, 255));
        NAPI.Marker.CreateMarker(23, new Vector3(593.6568, -2806.843, 6.059729), new Vector3(), new Vector3(), 7.0f, new Color(255, 255, 255, 180));

        Blip temp_blip = null;
        temp_blip = NAPI.Blip.CreateBlip(new Vector3(593.6568, -2806.843, 6.059729), 0);
        temp_blip.Sprite = 89;
        temp_blip.Name = "Fossile Brennstoffe";
        temp_blip.Color = 1;
        temp_blip.ShortRange = true;

        temp_blip = NAPI.Blip.CreateBlip(new Vector3(-409.1514, -2795.149, 5.589162), 0);
        temp_blip.Sprite = 355;
        temp_blip.Name = "Produktablage";
        temp_blip.Color = 1;
        temp_blip.ShortRange = true;

        temp_blip = NAPI.Blip.CreateBlip(new Vector3(-536.6481, -2846.78, 6.000384), 0);
        temp_blip.Sprite = 477;
        temp_blip.Name = "LS Go Trucker";
        temp_blip.Color = 1;
        temp_blip.ShortRange = true;       
        
        // create colshape
        combustivel = NAPI.ColShape.CreateCylinderColShape(new Vector3(593.6568, -2806.843, 6.059729), 1.5f, 1.5f);
        reabastecimento = NAPI.ColShape.CreateCylinderColShape(new Vector3(-409.1514, -2795.149, 5.589162), 1.5f, 1.5f);
        ls_docas = NAPI.ColShape.CreateCylinderColShape(new Vector3(-533.1777, -2857.792, 6.000384), 1.5f, 1.5f);

        ColShape ShipmentArea = NAPI.ColShape.CreateCylinderColShape(new Vector3(-535.4819, -2846.199, 6.000383), 0.85f, 0.85f);

        ShipmentArea.OnEntityEnterColShape += (s, ent) =>
        {
            Client player;

            if ((player = NAPI.Player.GetPlayerFromHandle(ent)) != null)
            {
                Main.DisplaySubtitle(player, "Drücke E");
                //player.TriggerEvent("ShowShipmentText", 1);
            }
        };

        ShipmentArea.OnEntityExitColShape += (s, ent) =>
        {
            Client player;

            if ((player = NAPI.Player.GetPlayerFromHandle(ent)) != null)
            {
                Main.DisplaySubtitle(player, " ");
                //player.TriggerEvent("ShowShipmentText", 0);
            }
        };

        int index = 0, count = 0;
        foreach (var business in Business.business_list)
        {
            if (Business.business_list[index].business_OrderState == 0 && Business.business_list[index].business_restock_manage_x != 0 && Business.business_list[index].business_restock_manage_y != 0 && (Business.business_list[index].business_Type == 1 || Business.business_list[index].business_Type == 2 || Business.business_list[index].business_Type == 3 || Business.business_list[index].business_Type == 5))
            {
                Business.business_list[index].business_OrderState = 1;
                Business.business_list[index].business_OrderAmount = Business.business_list[index].business_InventoryCapacity;
                count++;
            }
            index++;
        }
    }

    public static string GetInventoryType(int business_id)
    {
        string szType = "Unbekannt";
        switch (Business.business_list[business_id].business_Type)
        {
            case 1:

                szType = "Bekleidungsladen";
                break;
            case 2:
                szType = "24/7 Shop";
                break;

            case 3:
                szType = "Illegale Materialien";
                break;

            case 4:
                szType = "Autostücke";
                break;

            case 5:
                szType = "Treibstoff";
                break;

            case 10:
                szType = "Schönheitsprodukte";
                break;

            default:
                szType = "Unbekannt";
                break;
        }
        return szType;
    }

    public static void DisplayOrders(Client player)
    {
        if (player.GetData("shipment") == true)
        {
            Main.DisplayErrorMessage(player, "Sie haben bereits eine aktive Lieferung. Stornieren Sie zuerst, um eine neue zu starten.");
            return;
        }

        //List<dynamic> item_list = new List<dynamic>();
        List<dynamic> menu_item_list = new List<dynamic>();
        int count = 0, index = 0;
        foreach (var business in Business.business_list)
        {
            if (business.business_OrderState == 1)
            {
                if (business.business_Type > 0 && business.business_restock_manage_x != 0 && business.business_restock_manage_y != 0)
                {
                    menu_item_list.Add(new { Type = 1, Name = ""+ GetInventoryType(index) + " para "+ business.business_Name + "", Description = "", RightLabel = "" });
                    player.SetData("TrackItem_"+ count + "", index);
                    count++;
                }
            }
            index++;
        }
        if (count == 0)
        {
            Main.SendErrorMessage(player, "Derzeit sind keine Dienste verfügbar.");
            return;
        }
        InteractMenu.CreateMenu(player,  "SHIPMENT_MENU_RESPONSE", "Ladungen", "~b~Liste der verfügbaren Bestellungen:", false, NAPI.Util.ToJson(menu_item_list), false);
    }

    public static void SelectMenuResponse(Client player, String callbackId, int selectedIndex, String objectName, String valueList)
    {
        if(callbackId == "SHIPMENT_MENU_RESPONSE")
        {
            int index = player.GetData("TrackItem_" + selectedIndex + "");
            int playerid = Main.getIdFromClient(player);
            if (Business.business_list[index].business_OrderState == 1)
            {
                // spawn truck
                int count_spawn = 0;
                foreach (var truck_spawn in shipment_spawn_positions)
                {
                    count_spawn++;
                }

                Random rnd = new Random();
                int spawn = rnd.Next(0, count_spawn);
                Vector3 position = new Vector3(-409.1514, -2795.149, 5.589162);

                Main_Job.FinishallServices(player);
                switch (Business.business_list[index].business_Type)
                {
                    case 1:
                        {
                            // vehicle
                            Vehicle vehicleid = NAPI.Vehicle.CreateVehicle(VehicleHash.Benson, shipment_spawn_positions[spawn].position, shipment_spawn_positions[spawn].rotation, -1, -1);
                            vehicleid.SetSharedData("INTERACT", vehicleid.Type);
                            NAPI.Data.SetEntityData(vehicleid, "shipment_business", index);
                            Main.SetVehicleFuel(vehicleid, 100.0);
                            vehicleid.Health = Main.DEFAULT_VEHICLE_HEALTH;
                            vehicleid.SetSharedData("INTERACT", vehicleid.Type);

                            Random rndex = new Random();

                            vehicleid.SetSharedData("vehicle_radio_id", rndex.Next(100000, 500000));
                            NAPI.Task.Run(() =>
                            {
                                player.SetIntoVehicle(vehicleid, -1);
                            }, delayTime: 1000);

                            //
                            //
                            //

                            if(Business.business_list[index].business_Type == 2)
                            {
                                NAPI.Data.SetEntityData(vehicleid, "shipment_distance", 2500);
                            }
                            else if (Business.business_list[index].business_Type == 1)
                            {
                                NAPI.Data.SetEntityData(vehicleid, "shipment_distance", 3500);
                            }
                            else if (Business.business_list[index].business_Type == 10)
                            {
                                NAPI.Data.SetEntityData(vehicleid, "shipment_distance", 3500);
                            }
                            else if (Business.business_list[index].business_Type == 3)
                            {
                                NAPI.Data.SetEntityData(vehicleid, "shipment_distance", 5500);
                            }
                            else if (Business.business_list[index].business_Type == 5)
                            {
                                NAPI.Data.SetEntityData(vehicleid, "shipment_distance", 4500);
                            }
                            else 
                            {
                                NAPI.Data.SetEntityData(vehicleid, "shipment_distance", 2000);
                            }


                            //NAPI.Data.SetEntityData(vehicleid, "shipment_distance", Convert.ToInt32(position.DistanceTo(player.Position)));
                            //player.SetData("shipment_vehicle", vehicleid);
                            Main_Job.job_vehicle[playerid] = vehicleid;

                            NAPI.Data.SetEntityData(vehicleid, "shipment_type", MISSION_TYPE_CLOTHES);

                            player.SetData("shipment", true);

                            // blip
                            player.TriggerEvent("blip_remove", "LS Go Trucker");
                            player.TriggerEvent("blip_create_ext", "LS Go Trucker", position, 60, 0.80f, 0);
                            player.TriggerEvent("blip_router_visible", "LS Go Trucker", true, 60);

                            // message
                            Main.SendInfoMessage(player, "Gehen Sie zur Tankstelle, um die Ladung abzuholen und mit der Lieferung zu beginnen.");

                            // business
                            Business.business_list[index].business_OrderState = 2;

                            
                            break;
                        }

                    case 2:
                        {

                            Vehicle vehicleid = NAPI.Vehicle.CreateVehicle(VehicleHash.Pounder, shipment_spawn_positions[spawn].position, shipment_spawn_positions[spawn].rotation, -1, -1);
                            Random rndex = new Random();

                            vehicleid.SetSharedData("vehicle_radio_id", rndex.Next(100000, 500000));
                            if (Business.business_list[index].business_Type == 2)
                            {
                                NAPI.Data.SetEntityData(vehicleid, "shipment_distance", 2500);
                            }
                            else if (Business.business_list[index].business_Type == 1)
                            {
                                NAPI.Data.SetEntityData(vehicleid, "shipment_distance", 3500);
                            }
                            else if (Business.business_list[index].business_Type == 10)
                            {
                                NAPI.Data.SetEntityData(vehicleid, "shipment_distance", 3500);
                            }
                            else if (Business.business_list[index].business_Type == 3)
                            {
                                NAPI.Data.SetEntityData(vehicleid, "shipment_distance", 5500);
                            }
                            else if (Business.business_list[index].business_Type == 5)
                            {
                                NAPI.Data.SetEntityData(vehicleid, "shipment_distance", 4500);
                            }
                            else
                            {
                                NAPI.Data.SetEntityData(vehicleid, "shipment_distance", 2000);
                            }

                            vehicleid.SetSharedData("INTERACT", vehicleid.Type);
                            NAPI.Data.SetEntityData(vehicleid, "shipment_business", index);
                            Main.SetVehicleFuel(vehicleid, 100.0);
                            vehicleid.Health = Main.DEFAULT_VEHICLE_HEALTH;
                            NAPI.Task.Run(() =>
                            {
                                player.SetIntoVehicle(vehicleid, -1);
                            }, delayTime: 1000);
                            //NAPI.Data.SetEntityData(vehicleid, "shipment_distance", Convert.ToInt32(position.DistanceTo(player.Position)));
                            //player.SetData("shipment_vehicle", vehicleid);
                            Main_Job.job_vehicle[playerid] = vehicleid;
                            NAPI.Data.SetEntityData(vehicleid, "shipment_type", MISSION_TYPE_CLOTHES);

                            player.SetData("shipment", true);

                            // blip
                            player.TriggerEvent("blip_remove", "LS Go Trucker");
                            player.TriggerEvent("blip_create_ext", "LS Go Trucker", position, 60, 0.80f, 0);
                            player.TriggerEvent("blip_router_visible", "LS Go Trucker", true, 60);

                            // message
                            Main.SendInfoMessage(player, "Gehen Sie zur Tankstelle, um die Ladung abzuholen und mit der Lieferung zu beginnen.");

                            // business
                            Business.business_list[index].business_OrderState = 2;
     
                            break;
                        }

                    case 3:
                        {
                            Vehicle vehicleid = NAPI.Vehicle.CreateVehicle(VehicleHash.Pounder, shipment_spawn_positions[spawn].position, shipment_spawn_positions[spawn].rotation, -1, -1);
                            Random rndex = new Random();

                            vehicleid.SetSharedData("vehicle_radio_id", rndex.Next(100000, 500000));
                            if (Business.business_list[index].business_Type == 2)
                            {
                                NAPI.Data.SetEntityData(vehicleid, "shipment_distance", 2500);
                            }
                            else if (Business.business_list[index].business_Type == 1)
                            {
                                NAPI.Data.SetEntityData(vehicleid, "shipment_distance", 3500);
                            }
                            else if (Business.business_list[index].business_Type == 10)
                            {
                                NAPI.Data.SetEntityData(vehicleid, "shipment_distance", 3500);
                            }
                            else if (Business.business_list[index].business_Type == 3)
                            {
                                NAPI.Data.SetEntityData(vehicleid, "shipment_distance", 5500);
                            }
                            else if (Business.business_list[index].business_Type == 5)
                            {
                                NAPI.Data.SetEntityData(vehicleid, "shipment_distance", 4500);
                            }
                            else
                            {
                                NAPI.Data.SetEntityData(vehicleid, "shipment_distance", 2000);
                            }

                 
                            vehicleid.SetSharedData("INTERACT", vehicleid.Type);
                            NAPI.Data.SetEntityData(vehicleid, "shipment_business", index);
                            Main.SetVehicleFuel(vehicleid, 100.0);
                            vehicleid.Health = Main.DEFAULT_VEHICLE_HEALTH;
                            NAPI.Task.Run(() =>
                            {
                                player.SetIntoVehicle(vehicleid, -1);
                            }, delayTime: 1000);
                            //NAPI.Data.SetEntityData(vehicleid, "shipment_distance", Convert.ToInt32(position.DistanceTo(player.Position)));
                            //player.SetData("shipment_vehicle", vehicleid);
                            Main_Job.job_vehicle[playerid] = vehicleid;
                            NAPI.Data.SetEntityData(vehicleid, "shipment_type", MISSION_TYPE_CLOTHES);

                            player.SetData("shipment", true);

                            // blip
                            player.TriggerEvent("blip_remove", "LS Go Trucker");
                            player.TriggerEvent("blip_create_ext", "LS Go Trucker", position, 60, 0.80f, 0);
                            player.TriggerEvent("blip_router_visible", "LS Go Trucker", true, 60);

                            // message
                            Main.SendInfoMessage(player, "Gehen Sie zur Tankstelle, um die Ladung abzuholen und mit der Lieferung zu beginnen.");

                            // business
                            Business.business_list[index].business_OrderState = 2;

                            break;
                        }

                    case 4:
                        {
                            //szType = "Autostücke";
                            break;
                        }

                    case 5:
                        {
                            Vehicle vehicleid = NAPI.Vehicle.CreateVehicle(VehicleHash.Packer, shipment_spawn_positions[spawn].position, shipment_spawn_positions[spawn].rotation, -1, -1);
                            Random rndex = new Random();

                            vehicleid.SetSharedData("vehicle_radio_id", rndex.Next(100000, 500000));
                            if (Business.business_list[index].business_Type == 2)
                            {
                                NAPI.Data.SetEntityData(vehicleid, "shipment_distance", 2500);
                            }
                            else if (Business.business_list[index].business_Type == 1)
                            {
                                NAPI.Data.SetEntityData(vehicleid, "shipment_distance", 3500);
                            }
                            else if (Business.business_list[index].business_Type == 10)
                            {
                                NAPI.Data.SetEntityData(vehicleid, "shipment_distance", 3500);
                            }
                            else if (Business.business_list[index].business_Type == 3)
                            {
                                NAPI.Data.SetEntityData(vehicleid, "shipment_distance", 5500);
                            }
                            else if (Business.business_list[index].business_Type == 5)
                            {
                                NAPI.Data.SetEntityData(vehicleid, "shipment_distance", 4500);
                            }
                            else
                            {
                                NAPI.Data.SetEntityData(vehicleid, "shipment_distance", 2000);
                            }

                            // vehicle
                  
                            vehicleid.SetSharedData("INTERACT", vehicleid.Type);
                            NAPI.Data.SetEntityData(vehicleid, "shipment_business", index);
                            Main.SetVehicleFuel(vehicleid, 100.0);
                            vehicleid.Health = Main.DEFAULT_VEHICLE_HEALTH;
                            NAPI.Task.Run(() =>
                            {
                                player.SetIntoVehicle(vehicleid, -1);
                            }, delayTime: 1000);
                            //NAPI.Data.SetEntityData(vehicleid, "shipment_distance", Convert.ToInt32(position.DistanceTo(player.Position)));
                            //player.SetData("shipment_vehicle", vehicleid);
                            Main_Job.job_vehicle[playerid] = vehicleid;
                            NAPI.Data.SetEntityData(vehicleid, "shipment_type", MISSION_TYPE_FUEL);

                            player.SetData("shipment", true);

                            // trailer
                            Random rTrailer = new Random();
                            int Trailer = rTrailer.Next(0, 19);
                            NetHandle trailerid = NAPI.Vehicle.CreateVehicle(VehicleHash.Tanker2, tanker_spawn_positions[Trailer].position, tanker_spawn_positions[Trailer].rotation, -1, -1);
                            NAPI.Data.SetEntityData(vehicleid, "shipment_trailerBy", trailerid);

                            // marker
                            player.TriggerEvent("delete_marker", "shipment");
                            player.TriggerEvent("marker_create", "shipment", new Vector3(tanker_spawn_positions[Trailer].position.X, tanker_spawn_positions[Trailer].position.Y, tanker_spawn_positions[Trailer].position.Z - 1.0), 7f);

                            // blip
                            player.TriggerEvent("blip_remove", "LS Go Trucker");
                            player.TriggerEvent("blip_create_ext", "LS Go Trucker", tanker_spawn_positions[Trailer].position, 60, 0.80f, 0);
                            player.TriggerEvent("blip_router_visible", "LS Go Trucker", true, 60);

                            // business var
                            Business.business_list[index].business_OrderState = 2;

                            // message
                            Main.SendInfoMessage(player, "Vá até a marcação amarela para pegar o tanque de combustível.");
   
                            break;
                        }
                    case 10:
                        {
                            Vehicle vehicleid = NAPI.Vehicle.CreateVehicle(VehicleHash.Pounder, shipment_spawn_positions[spawn].position, shipment_spawn_positions[spawn].rotation, -1, -1);
                            Random rndex = new Random();

                            vehicleid.SetSharedData("vehicle_radio_id", rndex.Next(100000, 500000));
                            if (Business.business_list[index].business_Type == 2)
                            {
                                NAPI.Data.SetEntityData(vehicleid, "shipment_distance", 2500);
                            }
                            else if (Business.business_list[index].business_Type == 1)
                            {
                                NAPI.Data.SetEntityData(vehicleid, "shipment_distance", 3500);
                            }
                            else if (Business.business_list[index].business_Type == 10)
                            {
                                NAPI.Data.SetEntityData(vehicleid, "shipment_distance", 3500);
                            }
                            else if (Business.business_list[index].business_Type == 3)
                            {
                                NAPI.Data.SetEntityData(vehicleid, "shipment_distance", 5500);
                            }
                            else if (Business.business_list[index].business_Type == 5)
                            {
                                NAPI.Data.SetEntityData(vehicleid, "shipment_distance", 4500);
                            }
                            else
                            {
                                NAPI.Data.SetEntityData(vehicleid, "shipment_distance", 2000);
                            }

               
                            vehicleid.SetSharedData("INTERACT", vehicleid.Type);
                            NAPI.Data.SetEntityData(vehicleid, "shipment_business", index);
                            Main.SetVehicleFuel(vehicleid, 100.0);
                            vehicleid.Health = Main.DEFAULT_VEHICLE_HEALTH;
                            NAPI.Task.Run(() =>
                            {
                                player.SetIntoVehicle(vehicleid, -1);
                            }, delayTime: 1000);
                            //NAPI.Data.SetEntityData(vehicleid, "shipment_distance", Convert.ToInt32(position.DistanceTo(player.Position)));
                            //player.SetData("shipment_vehicle", vehicleid);
                            Main_Job.job_vehicle[playerid] = vehicleid;
                            NAPI.Data.SetEntityData(vehicleid, "shipment_type", MISSION_TYPE_CLOTHES);

                            player.SetData("shipment", true);

                            // blip
                            player.TriggerEvent("blip_remove", "LS Go Trucker");
                            player.TriggerEvent("blip_create_ext", "LS Go Trucker", position, 60, 0.80f, 0);
                            player.TriggerEvent("blip_router_visible", "LS Go Trucker", true, 60);

                            // message
                            Main.SendInfoMessage(player, "Gehen Sie zur Tankstelle, um die Ladung abzuholen und mit der Lieferung zu beginnen.");

                            // business
                            Business.business_list[index].business_OrderState = 2;
                            break;
                        }

                    default:
                        {
                            //szType = "Indefinido";
                            break;
                        }
                }

            }
        }
    }


    public static void OnVehicleTrailerChangeHandler(Entity tower, NetHandle trailer)
    {

        var players = NAPI.Pools.GetAllPlayers();
        if (NAPI.Data.HasEntityData(tower, "shipment_business"))
        {
            NAPI.Util.ConsoleOutput("1");
            foreach (var player in players)
            {
                if (player.GetData("status") == true && player.GetData("shipment") == true)
                {
                    try
                    {
                        if (player.IsInVehicle && player.VehicleSeat == -1 && Main_Job.job_vehicle[Main.getIdFromClient(player)] == tower)
                        {
                            NAPI.Util.ConsoleOutput("2");
                            if (NAPI.Data.GetEntityData(tower, "shipment_business") != -1 && NAPI.Data.GetEntityData(tower, "shipment_trailerBy") == trailer)
                            {
                                NAPI.Util.ConsoleOutput("3");
                                int business_id = NAPI.Data.GetEntityData(tower, "shipment_business");
                                if (Business.business_list[business_id].business_OrderState == 2)
                                {
                                    NAPI.Util.ConsoleOutput("4");
                                    Business.business_list[business_id].business_OrderState = 3;

                                    Vector3 position = new Vector3(593.6568, -2806.843, 6.059729);

                                    // remove mark
                                    player.TriggerEvent("delete_marker", "shipment");

                                    // blip
                                    player.TriggerEvent("blip_remove", "LS Go Trucker");
                                    player.TriggerEvent("blip_create_ext", "LS Go Trucker", position, 60, 0.80f, 0);
                                    player.TriggerEvent("blip_router_visible", "LS Go Trucker", true, 60);

                                    Main.DisplaySubtitle(player, "~y~Leve a tanque até o local de reabastecimento.", 5);
                                }
                            }
                        }
                    }
                    catch(Exception)
                    {
                        NAPI.Util.ConsoleOutput("[Exception] OnVehicleTralerChangeHandle - "+player.Name+"");
                    }
                }
            }
        }
    }

    public static void OnEnterReabastecimento(Client player, ColShape shape)
    {
        if(shape == combustivel)
        {
            if (player.IsInVehicle && player.VehicleSeat == -1)
            {
                if (player.Vehicle.HasData("shipment_business"))
                {
                    if (player.Vehicle.GetData("shipment_business") != -1 && Main_Job.job_vehicle[Main.getIdFromClient(player)] == player.Vehicle)
                    {
                        int business_id = player.Vehicle.GetData("shipment_business");

                        if (player.Vehicle.HasData("shipment_type") && player.Vehicle.GetData("shipment_type") == MISSION_TYPE_FUEL)
                        {
                           
                            if (Business.business_list[business_id].business_OrderState == 3 && Business.business_list[business_id].business_Type == 5)
                            {
                                //NAPI.Util.ConsoleOutput(" "+NAPI.Entity.GetEntityModel(player.Vehicle.Trailer)+" --- >> "+ NAPI.Entity.GetEntityModel(player.Vehicle.GetData("shipment_trailerBy")) + "");
                                //NAPI.Util.ConsoleOutput(" "+ NAPI.Vehicle.GetVehicleTrailer(player.Vehicle) + " --- >> "+ player.Vehicle.GetData("shipment_trailerBy") + "");
                                //NAPI.Util.ConsoleOutput(" "+ NAPI.Vehicle.GetVehicleTraileredBy(player.Vehicle) + " --- >> "+ player.Vehicle.GetData("shipment_trailerBy") + "");
                                /*if(NAPI.Vehicle.GetVehicleTraileredBy(player.Vehicle) != player.Vehicle.GetData("shipment_trailerBy"))
                                {
                                    Main.SendErrorMessage(player, "Você não está carregando o tanque de combustivel.");
                                    return;
                                }*/

                                if (NAPI.Entity.GetEntityModel(player.Vehicle.GetData("shipment_trailerBy")) != (uint)VehicleHash.Tanker2)
                                {
                                    Main.SendErrorMessage(player, "Você não está carregando o tanque de combustivel.");
                                    return;
                                }

                                Main.DisplaySubtitle(player, "~y~Colocando Combustível no tanque, porfavor aguarde ...", 5);
                                player.SetSharedData( "DisableVehicleMove", true);
                                player.TriggerEvent("freezeVehicle", true);
                                player.TriggerEvent("StopVehicle");

                                NAPI.Task.Run(() =>
                                {
                                    player.SetSharedData( "DisableVehicleMove", false);
                                    player.TriggerEvent("freezeVehicle", false);
                                    Main.DisplaySubtitle(player, "~g~Tanque cheio ! Siga o GPS para fazer a entrega.", 2);
                                    Main.SendInfoMessage(player, "Você encheu combustível do tanque com sucesso. Siga o GPS para fazer a entrega na empresa " + Main.EMBED_LIGHTGREEN + "" + Business.business_list[business_id].business_Name + ""+Main.EMBED_WHITE+".");

                                    Business.business_list[business_id].business_OrderState = 4;

                                    Vector3 position = new Vector3(Business.business_list[business_id].business_restock_manage_x, Business.business_list[business_id].business_restock_manage_y, Business.business_list[business_id].business_restock_manage_z);

                                    //player.Vehicle.SetData("shipment_distance", player.Vehicle.GetData("shipment_distance") + Convert.ToInt32(position.DistanceTo(player.Position)));
                                    player.Vehicle.SetData("ShipmentArea", NAPI.ColShape.CreateCylinderColShape(position, 1.5f, 1.5f));

                                    player.TriggerEvent("delete_marker", "shipment");
                                    player.TriggerEvent("marker_create", "shipment", new Vector3(position.X, position.Y, position.Z - 1.0), 7f);

                                    player.TriggerEvent("blip_remove", "LS Go Trucker");
                                    player.TriggerEvent("blip_create_ext", "LS Go Trucker", position, 60, 0.70f, 0);
                                    player.TriggerEvent("blip_router_visible", "LS Go Trucker", true, 60);

                                }, delayTime: 5000);
                            }
                        }
                    }
                }
            }
        }

        if (shape == reabastecimento) // In Reabastecimento
        {
            if (player.IsInVehicle && player.VehicleSeat == -1)
            {
                if (player.Vehicle.HasData("shipment_business"))
                {
                    if (player.Vehicle.GetData("shipment_business") != -1 && Main_Job.job_vehicle[Main.getIdFromClient(player)] == player.Vehicle)
                    {
                        int business_id = player.Vehicle.GetData("shipment_business");
                        if (Business.business_list[business_id].business_OrderState == 2 && (Business.business_list[business_id].business_Type == 1 || Business.business_list[business_id].business_Type == 2 || Business.business_list[business_id].business_Type == 3 || Business.business_list[business_id].business_Type == 10))
                        {

                            if (player.Vehicle.HasData("shipment_type") && player.Vehicle.GetData("shipment_type") == MISSION_TYPE_CLOTHES)
                            {
                                Main.DisplaySubtitle(player, "~y~Colocando itens no caminhão, porfavor aguarde ...", 5);
                                player.SetSharedData( "DisableVehicleMove", true);
                                player.TriggerEvent("freezeVehicle", true);
                                player.TriggerEvent("StopVehicle");
                                NAPI.Task.Run(() =>
                                {
                                    player.SetSharedData( "DisableVehicleMove", false);
                                    player.TriggerEvent("freezeVehicle", false);
                                    Main.DisplaySubtitle(player, "~g~Caminhão carregado com sucesso ... Siga o GPS para fazer a entrega.", 2);
                                    Main.SendInfoMessage(player, "Caminhão carregado com sucesso, siga o GPS amarelo no mini-mapa para entregar "+Main.EMBED_LIGHTGREEN+"" + GetInventoryType(business_id) + ""+Main.EMBED_WHITE+" na empresa " + Business.business_list[business_id].business_Name + ".");

                                    Business.business_list[business_id].business_OrderState = 3;



                                    Vector3 position = new Vector3(Business.business_list[business_id].business_restock_manage_x, Business.business_list[business_id].business_restock_manage_y, Business.business_list[business_id].business_restock_manage_z);

                                   // player.Vehicle.SetData("shipment_distance", player.Vehicle.GetData("shipment_distance") + Convert.ToInt32(position.DistanceTo(player.Position)));
                                    player.Vehicle.SetData("ShipmentArea", NAPI.ColShape.CreateCylinderColShape(position, 1.5f, 1.5f));

                                    player.TriggerEvent("delete_marker", "shipment");
                                    player.TriggerEvent("marker_create", "shipment", new Vector3(position.X, position.Y, position.Z - 1.0), 7f);

                                    player.TriggerEvent("blip_remove", "LS Go Trucker");
                                    player.TriggerEvent("blip_create_ext", "LS Go Trucker", position, 60, 0.70f, 0);
                                    player.TriggerEvent("blip_router_visible", "LS Go Trucker", true, 60);
                                }, delayTime: 5000);
                            }
                        }
                    }
                }
            }
        }
        try
        {
            if (player.IsInVehicle && player.Vehicle.HasData("ShipmentArea"))
            {
                if (shape == player.Vehicle.GetData("ShipmentArea") && player.VehicleSeat == -1) // in Business
                {
                    if (player.IsInVehicle && player.VehicleSeat == -1)
                    {
                        if (player.Vehicle.HasData("shipment_business"))
                        {

                            if (player.Vehicle.GetData("shipment_business") != -1 && Main_Job.job_vehicle[Main.getIdFromClient(player)] == player.Vehicle)
                            {
                                int business_id = player.Vehicle.GetData("shipment_business");
                                if (Business.business_list[business_id].business_OrderState == 3 || Business.business_list[business_id].business_OrderState == 4)
                                {
                                    if (Business.business_list[business_id].business_Type == 5)
                                    {
                                        /*if (NAPI.Vehicle.GetVehicleTrailer(player.Vehicle) != player.Vehicle.GetData("shipment_trailerBy"))
                                        {
                                            Main.SendErrorMessage(player, "Você não está carregando o tanque com o combustivel para fazer a entrega.");
                                            return;
                                        }*/

                                        if (NAPI.Entity.GetEntityModel(player.Vehicle.GetData("shipment_trailerBy")) != (uint)VehicleHash.Tanker2)
                                        {
                                            Main.SendErrorMessage(player, "Sie laden den Kraftstofftank nicht.");
                                            return;
                                        }
                                    }

                                    Main.SendInfoMessage(player, "Aguarde um momento enquanto o caminhão está descarregando " + Main.EMBED_LIGHTGREEN + "" + GetInventoryType(business_id) + "" + Main.EMBED_WHITE + " ...");

                                    player.SetSharedData("DisableVehicleMove", true);
                                    player.TriggerEvent("freezeVehicle", true);
                                    player.TriggerEvent("StopVehicle");
                                    NAPI.Task.Run(() =>
                                    {
                                        player.SetSharedData("DisableVehicleMove", false);
                                        player.TriggerEvent("freezeVehicle", false);
                                        Main.DisplaySubtitle(player, "~g~Entrega finalizada. ~y~Retorne com o caminhão até as docas de LS para receber seu pagamento.", 4);


                                        if (Business.business_list[business_id].business_OwnerID != -1)
                                        {
                                            var players = NAPI.Pools.GetAllPlayers();
                                            foreach (var i in players)
                                            {
                                                if (i.GetData("status") == true)
                                                {
                                                    if (Business.business_list[business_id].business_OwnerID == AccountManage.GetPlayerSQLID(i))
                                                    {
                                                        i.SendPictureNotificationToPlayer("O LKW Fahrer ~y~" + AccountManage.GetCharacterName(player) + "~w~ entregou ~b~" + Business.business_list[business_id].business_OrderAmount + " estoque de " + GetInventoryType(business_id) + "~w~ na sua empresa.", "CHAR_DEFAULT", 0, 3, "" + Business.business_list[business_id].business_Name + "", "Entrega de Estoque");
                                                    }
                                                }
                                            }
                                        }

                                        if (Business.business_list[business_id].business_Type == 5)
                                        {

                                            for (int pump = 0; pump < 9; pump++)
                                            {
                                                Business.business_list[business_id].business_pump_galons[pump] = Business.business_list[business_id].business_pump_capacity[pump];
                                                NAPI.Util.ConsoleOutput("" + pump + " -- reabatece " + Business.business_list[business_id].business_pump_capacity[pump] + " agora e " + Business.business_list[business_id].business_pump_galons[pump] + ".");

                                                string text = "~y~Bomba de Treibstoff~w~\nID: " + pump + "  (" + business_id + ")\nUse ~y~/reabastecer~w~ para encher o tanque do seu veiculo.";
                                                string label = "~s~Preco por litro: $" + Business.business_list[business_id].business_fuel_price + "\nEsta venda: $" + Business.business_list[business_id].business_pump_sale_price[pump].ToString("0") + "\nLitros: " + Business.business_list[business_id].business_pump_sale_galons[pump].ToString("C2").Replace("R$", "") + "\nComb. disponivel: " + Business.business_list[business_id].business_pump_galons[pump].ToString("C2").Replace("R$", "") + " /  " + Business.business_list[business_id].business_pump_capacity[pump].ToString("C2").Replace("R$", "") + " litros";
                                                Business.business_list[business_id].business_pump_textlabel[pump].Text = label;
                                                Business.business_list[business_id].business_pump_textlabel_secundary[pump].Text = text;

                                            }
                                        }




                                        Business.business_list[business_id].business_Inventory = Business.business_list[business_id].business_InventoryCapacity;
                                        Business.business_list[business_id].business_OrderState = 0;
                                        Business.business_list[business_id].business_OrderAmount = 0;

                                        Vector3 position = new Vector3(-533.1777, -2857.792, 6.000384);


                                        try
                                        {
                                            player.Vehicle.SetData("shipment_business", -1);
                                            NAPI.ColShape.DeleteColShape(player.Vehicle.GetData("ShipmentArea"));

                                            player.Vehicle.SetData("ShipmentFinished", 1);
                                        }
                                        catch
                                        {
                                            NAPI.Util.ConsoleOutput("Server Crash HERE !! (# 15100)");
                                        }
                                        player.TriggerEvent("delete_marker", "shipment");
                                        player.TriggerEvent("marker_create", "shipment", new Vector3(position.X, position.Y, position.Z - 1.0), 7f);

                                        player.TriggerEvent("blip_remove", "LS Go Trucker");
                                        player.TriggerEvent("blip_create_ext", "LS Go Trucker", position, 60, 0.70f, 0);
                                        player.TriggerEvent("blip_router_visible", "LS Go Trucker", true, 60);
                                    }, delayTime: 5000);
                                }
                            }
                        }
                    }
                }
            }
        }
        catch
        {
            NAPI.Util.ConsoleOutput("Server Crash HERE !! (# 1000)");
        }
        if (player.IsInVehicle && player.Vehicle.HasData("ShipmentFinished"))
        {
            if (shape == ls_docas && player.IsInVehicle && player.VehicleSeat == -1 && player.Vehicle.GetData("ShipmentFinished") == 1 && Main_Job.job_vehicle[Main.getIdFromClient(player)] == player.Vehicle)
            {
                player.SetData("shipment", false);

                int metros = player.Vehicle.GetData("shipment_distance");
                player.Vehicle.SetData("shipment_distance", -1);
                player.TriggerEvent("delete_marker", "shipment");
                player.TriggerEvent("blip_remove", "LS Go Trucker");
                player.Vehicle.SetData("ShipmentFinished", -1);

                try
                {
                    if (NAPI.Data.HasEntityData(player.Vehicle, "shipment_trailerBy"))
                    {
                        NAPI.Entity.DeleteEntity(NAPI.Data.GetEntityData(player.Vehicle, "shipment_trailerBy"));
                    }
                }
                catch
                {
                }

                NAPI.Entity.DeleteEntity(player.Vehicle);
                Main_Job.job_vehicle[Main.getIdFromClient(player)] = null;


                //
                //
                //
                /* public static int price_trucker1 = 2500; // Mercado
    public static int price_trucker2 = 3500; // Roupas e Barbeiro
    public static int price_trucker3 = 4500; // Treibstoff
    public static int price_truker4 = 5500; // armas loja de armas
    public static int price_trucker_special = 10000; // Reabasteciamento Policia*/
                Main.SendSuccessMessage(player, "Você terminou a entrega, e ganhou um valor de "+Main.EMBED_GREEN+"$" + metros.ToString("N0") + "" + Main.EMBED_WHITE + ".");
                Main.GivePlayerMoney(player, metros);
            }
        }

    }

    public static void OnExitReabastecimento(Client player, ColShape shape)
    {
        if (shape == reabastecimento)
        {
            if (player.IsInVehicle && player.VehicleSeat == -1)
            {
                if (player.Vehicle.HasData("shipment_business"))
                {
                    if (player.Vehicle.GetData("shipment_business") != -1)
                    {

                        player.SetSharedData( "DisableVehicleMove", false);
                        player.TriggerEvent("freezeVehicle", false);

                    }
                }
            }
        }
    }

    [Command("encomendar")]
    public void CMD_ressuprimento(Client player, int index)
    {

        /*if (Business.business_list[index].business_Inventory == Business.business_list[index].business_InventoryCapacity)
        {
            Main.DisplayErrorMessage(player, "A sua empresa já está com o estoque cheio.");
            return;
        }*/

        if (AccountManage.GetPlayerAdmin(player) < 2)
        {
            Main.SendErrorMessage(player, "Sie dürfen diesen Befehl nicht verwenden.");
            return;
        }

        if (Business.business_list[index].business_Type != 1 && Business.business_list[index].business_Type != 2 && Business.business_list[index].business_Type != 3 && Business.business_list[index].business_Type != 5 && Business.business_list[index].business_Type != 10)
        {
            Main.DisplayErrorMessage(player, "Este tipo de empresa não suporta o sitema de encomendas.");
            return;
        }

        if (Business.business_list[index].business_restock_manage_x == 0 && Business.business_list[index].business_restock_manage_y == 0)
        {
            Main.DisplayErrorMessage(player, "Esta empresa não tem um ponto de reabastecimendo de estoque. Você precisa definir um primeiro.");
            return;
        }

        if (Business.business_list[index].business_OrderState == 1)
        {
            Main.DisplayErrorMessage(player, "Já existe tem um pedido de encomenda pendente para esta empresa.");
            return;
        }

        if (Business.business_list[index].business_OrderState != 0)
        {
            Main.DisplayErrorMessage(player, "Já existe um pedido que está sendo estrengue para está empresa..");
            return;
        }

        Business.business_list[index].business_OrderState = 1;
        Business.business_list[index].business_OrderAmount = Business.business_list[index].business_InventoryCapacity;

        foreach (var players in NAPI.Pools.GetAllPlayers())
        {
            if (players.GetData("status") == true && AccountManage.GetPlayerJob(players) == 10)
            {
                players.TriggerEvent("BN_ShowWithPicture", "~h~NOVA ENTREGA DISPONÍVEL", "para entregar em ~b~" + Business.business_list[index].business_Name + "~w~", "Nossa empresta está sem estoque, precisamos de ~b~" + GetInventoryType(index) + "~w~ urgente !", "CHAR_PLANESITE");

            }
        }

        player.SendChatMessage("~o~[ADMIN]:~c~ Você colocou uma ordem de ressuprimento de ~b~" + GetInventoryType(index) + "~c~ para a empresa ~y~"+ Business.business_list[index].business_Name + " ("+Business.Business_Type(index)+")~w~.");
    }


    [Command("encomendartodos")]
    public void CMD_ressuprimentoall(Client player)
    {

        if (AccountManage.GetPlayerAdmin(player) < 2)
        {
            Main.SendErrorMessage(player, "Sie dürfen diesen Befehl nicht verwenden.");
            return;
        }

        int index = 0, count = 0;
        foreach(var business in Business.business_list)
        {
            if (Business.business_list[index].business_OrderState == 0 && Business.business_list[index].business_restock_manage_x != 0 && Business.business_list[index].business_restock_manage_y != 0 && (Business.business_list[index].business_Type == 1 || Business.business_list[index].business_Type == 2 || Business.business_list[index].business_Type == 3 || Business.business_list[index].business_Type == 5 || Business.business_list[index].business_Type == 10))
            {
                Business.business_list[index].business_OrderState = 1;
                Business.business_list[index].business_OrderAmount = Business.business_list[index].business_InventoryCapacity;
                count++;
            }
            index++;
        }

        if(count != 0)
        {
            foreach(var players in NAPI.Pools.GetAllPlayers())
            {
                if(players.GetData("status") == true && AccountManage.GetPlayerJob(players) == 10)
                {
                    players.TriggerEvent("BN_ShowWithPicture", "~y~"+count+"~g~ NOVA(S) ENTREGA(S) DISPONÍVEL", "~o~da central", "~w~Hà ~b~"+count+"~w~ nova entregas disponíveis em nosso menu, ~y~precisamos de LKW Fahrers para entregar urgente~w~ !", "CHAR_PLANESITE");

                }
            }
            player.SendChatMessage("~o~[ADMIN]:~c~ Você colocou uma ordem de ressuprimento para ~y~" + count + " empresa(s).");
        }
        Main.SendErrorMessage(player, "Não à nenhuma empresa disponível para ressuprimento.");
    }



    [Command("encomendas")]
    public void CMD_encomendas(Client player)
    {
        if (Business.GetPlayerBusinessKey(player) == -1)
        {
            Main.DisplayErrorMessage(player, "Você não é dono de uma empresa.");
            return;
        }

        int index = Business.GetPlayerBusinessKey(player);

        player.SendChatMessage("~y~ Lista de Encomendas:");
        if (Business.business_list[index].business_OrderState == 1)
        {
            player.SendChatMessage("~w~ Tipo da Encomenda: ~c~" + GetInventoryType(index) + " ~w~- Quantidade Encomendada: ~c~" + GetInventoryType(index) + "~w~ - Status: ~c~Pendente");
        }
        else if (Business.business_list[index].business_OrderState == 2)
        {
            player.SendChatMessage("~w~ Tipo da Encomenda: ~c~" + GetInventoryType(index) + "~w~ - Quantidade Encomendada: ~c~" + GetInventoryType(index) + "~w~ - Status: ~c~Produtos em separação.");
        }
        else if (Business.business_list[index].business_OrderState == 3)
        {
            player.SendChatMessage("~w~ Tipo da Encomenda: ~c~" + GetInventoryType(index) + "~w~ - Quantidade Encomendada: ~c~" + GetInventoryType(index) + "~w~ - Status: ~c~Há Caminho");
        }
        else player.SendChatMessage("~~ Você não fez nenhuma encomenda.");
    }


    [Command("j", Alias = "job", GreedyArg = true)]
    public void CMD_admin(Client player, string mensagem)
    {
        if (player.GetData("status") == false)
        {
            return;
        }
        if (AccountManage.GetPlayerJob(player) == 0)
        {
            Main.SendErrorMessage(player, "Você não está em um emprego para usar o comando de rádio.");
            return;
        }

        var players = NAPI.Pools.GetAllPlayers();

        if (AccountManage.GetPlayerJob(player) == 10)
        {
            foreach (Client c in players)
            {
                if (c.GetData("status") == true)
                {
                    if (AccountManage.GetPlayerJob(c) == 7)
                    {
                        c.SendChatMessage("~b~[Radio - LS Go Trucker]~c~ " + AccountManage.GetCharacterName(player) + " ~c~diz:~w~ " + mensagem + "~b~, câmbio.");
                    }
                }
            }
        }
        /*else if(AccountManage.GetPlayerJob(player) == 3)
        {
            foreach (Client c in players)
            {
                if (c.GetData("status") == true)
                {
                    if (AccountManage.GetPlayerJob(c) == 3)
                    {
                        c.SendChatMessage("~b~[Radio - Taxista]~c~ " + AccountManage.GetCharacterName(player) + " ~c~diz:~w~ " + mensagem + "~b~, câmbio.");
                    }
                }
            }
        }*/
        else
        {
            Main.SendErrorMessage(player, "Este tipo de emprego não tem acesso ao radio.");
            return;
        }
        NAPI.Util.ConsoleOutput("[" + DateTime.Now + "] [" + player.Name + "] usou o comando /j. (Dizendo: " + mensagem + ")");
    }
}