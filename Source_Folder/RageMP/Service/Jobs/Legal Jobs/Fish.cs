using System;
using System.Collections.Generic;
using GTANetworkAPI;
using DerStr1k3r.Core;

/*| fish_1 | Saved Coordenates:  Saved Rotation: 0, 0, 
| fish_2 | Saved Coordenates:  Saved Rotation: 0, 0, 
| fish_3 | Saved Coordenates:  Saved Rotation: 0, 0, 
| fish_4 | Saved Coordenates:  Saved Rotation: 0, 0, 147.2524
| fish_5 | Saved Coordenates:  Saved Rotation: 0, 0, 148.6728
| fish_6 | Saved Coordenates:  Saved Rotation: 0, 0, 132.5456
| fish_7 | Saved Coordenates:  Saved Rotation: 0, 0, 134.1147
| fish_8 | Saved Coordenates:  Saved Rotation: 0, 0, 153.3554
| fish_9 | Saved Coordenates:  Saved Rotation: 0, 0, 
| fish_10 | Saved Coordenates:  Saved Rotation: 0, 0,
| fish_11 | Saved Coordenates:  Saved Rotation: 0, 0, 
*/
public class Fish : Script
{
    private static List<dynamic> fish_points = new List<dynamic>();
    private static List<dynamic> fishes = new List<dynamic>();

    //public static Timer fishTimer = null;

    public static List<TimerEx> fishTimer = new List<TimerEx>();

    public static int MAX_FISH_PER_PLAYER = 10;

    public static void FishInit()
    {
        for (var i = 0; i < Main.MAX_PLAYERS; i++)
        {
            fishTimer.Add(null);
        }

        fish_points.Add(new { position = new Vector3(-1862.562, -1239.655, 8.61578), rotation = 150f });
        fish_points.Add(new { position = new Vector3(-1858.801, -1242.655, 8.61578), rotation = 150f });
        fish_points.Add(new { position = new Vector3(-1855.091, -1245.834, 8.61578), rotation = 150f });
        fish_points.Add(new { position = new Vector3(-1850.168, -1249.849, 8.615788), rotation = 150f });
        fish_points.Add(new { position = new Vector3(-1843.511, -1255.606, 8.615788), rotation = 150f });
        fish_points.Add(new { position = new Vector3(-1839.353, -1258.88, 8.615788), rotation = 150f });
        fish_points.Add(new { position = new Vector3(-1832.99, -1264.137, 8.618262), rotation = 150f });
        fish_points.Add(new { position = new Vector3(-1827.465, -1268.84, 8.618273), rotation = 150f });
        fish_points.Add(new { position = new Vector3(-1807.345, -1247.277, 8.615784), rotation = -118.4473 });
        fish_points.Add(new { position = new Vector3(-1811.151, -1251.748, 8.615784), rotation = -122.2939 });
        fish_points.Add(new { position = new Vector3(-1818.028, -1260.091, 8.618272), rotation = -121.6565 });

        fish_points.Add(new { position = new Vector3(-3330.099, 970.8427, 8.29153), rotation = -2.001033 });
        fish_points.Add(new { position = new Vector3(-3348.137, 970.8254, 8.29153), rotation = 6.756034 });
        fish_points.Add(new { position = new Vector3(-3369.595, 970.8124, 8.29153), rotation = 6.686509 });
        fish_points.Add(new { position = new Vector3(-3389.376, 970.8115, 8.29153), rotation = -6.814515 });
        fish_points.Add(new { position = new Vector3(-3405.011, 970.8079, 8.29153), rotation = 9.969207 });
        fish_points.Add(new { position = new Vector3(-3404.45, 964.2892, 8.29153), rotation = 179.3898 });
        fish_points.Add(new { position = new Vector3(-3385.782, 964.285, 8.29153), rotation = -169.8227 });
        fish_points.Add(new { position = new Vector3(-3368.831, 964.2776, 8.29153), rotation = -156.9146 });
        fish_points.Add(new { position = new Vector3(-3354.332, 964.2852, 8.29153), rotation = -170.8588 });
        fish_points.Add(new { position = new Vector3(-3332.538, 964.2855, 8.29153), rotation = 174.2529 });
        fish_points.Add(new { position = new Vector3(1594.731, 3864.085, 31.13297), rotation = 81.42986 });
        fish_points.Add(new { position = new Vector3(1594.528, 3876.812, 31.14991), rotation = 111.9265 });
        fish_points.Add(new { position = new Vector3(1584.282, 3880.07, 31.29387), rotation = 113.9885 });
        fish_points.Add(new { position = new Vector3(1578.708, 3897.709, 31.85919), rotation = 172.9068 });
        fish_points.Add(new { position = new Vector3(1568.55, 3902.587, 31.82836), rotation = 154.5187 });
        fish_points.Add(new { position = new Vector3(1517.259, 3912.425, 31.02946), rotation = 165.7924 });
        fish_points.Add(new { position = new Vector3(1501.184, 3918.447, 31.51341), rotation = 156.2282 });
        fish_points.Add(new { position = new Vector3(1491.023, 3920.476, 31.7021), rotation = 127.5541 });
        fish_points.Add(new { position = new Vector3(1500.777, 3924.481, 31.6792), rotation = -18.231 });
        fish_points.Add(new { position = new Vector3(1515.932, 3923.05, 31.70509), rotation = 12.2893 });
        fish_points.Add(new { position = new Vector3(1532.626, 3922.794, 31.69301), rotation = -13.07514 });
        fish_points.Add(new { position = new Vector3(1545.555, 3918.878, 31.89232), rotation = -2.685519 });
        fish_points.Add(new { position = new Vector3(1562.995, 3913.709, 31.23233), rotation = -12.27696 });
        fish_points.Add(new { position = new Vector3(1580.244, 3909.558, 31.31064), rotation = -6.706637 });
        fish_points.Add(new { position = new Vector3(-1125.417, 4412.993, 12.04512), rotation = -177.4343 });
        fish_points.Add(new { position = new Vector3(-1109.045, 4407.587, 14.24012), rotation = -171.8859 });
        fish_points.Add(new { position = new Vector3(-610.6617, 4403.605, 15.99488), rotation = -7.609299 });
        fish_points.Add(new { position = new Vector3(-573.8457, 4400.951, 17.73419), rotation = 9.382575 });
        fish_points.Add(new { position = new Vector3(-578.2349, 4438.644, 17.3753), rotation = 110.0637 });

        // Comuns
        fishes.Add(new { name = "Seitling", rarity = "Verbreitet", price = 40, weight = 1.0f });
        fishes.Add(new { name = "Hering", rarity = "Verbreitet", price = 50, weight = 1.0f });
        // Seltens
        fishes.Add(new { name = "Tinten Fisch", rarity = "Selten", price = 100, weight = 1.0f });
        fishes.Add(new { name = "Grüner Aal", rarity = "Selten", price = 120, weight = 1.0f });
        // Super Seltens
        fishes.Add(new { name = "Kugelfisch", rarity = "Super Selten", price = 200, weight = 1.1f });
        // Epos
        fishes.Add(new { name = "Weißen Hai", rarity = "Extrem Selten", price = 300, weight = 1.5f });



        foreach (var points in fish_points)
        {
            NAPI.Marker.CreateMarker(1, new Vector3(points.position.X, points.position.Y, points.position.Z - 1.0), new Vector3(), new Vector3(), 0.6f, new Color(255, 255, 255, 70));
            NAPI.TextLabel.CreateTextLabel("~c~-~w~ Angelstelle ~c~-~b~~n~~n~(( ~w~Drücke ~c~[~w~ E~c~ ] ~b~))", new Vector3(points.position.X, points.position.Y, points.position.Z + 0.3), 12, 0.3500f, 0, new Color(255, 255, 255, 255));
        }

        Blip temp_blip = null;
        temp_blip = NAPI.Blip.CreateBlip(new Vector3(-1843.952, -1227.803, 13.01728), 0);
        temp_blip.Sprite = 68;
        temp_blip.Name = "Angelstelle";
        temp_blip.Color = 67;
        temp_blip.ShortRange = true;

        temp_blip = NAPI.Blip.CreateBlip(new Vector3(-1608.298, 5251.786, 3.974101), 0);
        temp_blip.Sprite = 68;
        temp_blip.Name = "Angelstelle";
        temp_blip.Color = 67;
        temp_blip.ShortRange = true;

        temp_blip = NAPI.Blip.CreateBlip(new Vector3(-575.2971, 4440.058, 17.70979), 0);
        temp_blip.Sprite = 68;
        temp_blip.Name = "Angelstelle";
        temp_blip.Color = 67;
        temp_blip.ShortRange = true;

        temp_blip = NAPI.Blip.CreateBlip(new Vector3(1575.447, 3902.083, 31.37904), 0);
        temp_blip.Sprite = 68;
        temp_blip.Name = "Angelstelle";
        temp_blip.Color = 67;
        temp_blip.ShortRange = true;

        temp_blip = NAPI.Blip.CreateBlip(new Vector3(-3417.252, 967.2628, 7.825385), 0);
        temp_blip.Sprite = 68;
        temp_blip.Name = "Angelstelle";
        temp_blip.Color = 67;
        temp_blip.ShortRange = true;

        temp_blip = NAPI.Blip.CreateBlip(new Vector3(-41.26046, 224.6604, 107.9488), 0);
        temp_blip.Sprite = 68;
        temp_blip.Name = "Fish of Point";
        temp_blip.Color = 59;
        temp_blip.ShortRange = true;

        Ped garbage_ped = NAPI.Ped.CreatePed(NAPI.Util.PedNameToModel("Chef2"), new Vector3(-41.26046, 224.6604, 107.9488), 80.9303f, 0);
        NAPI.Ped.PlayPedScenario(garbage_ped, "CODE_HUMAN_MEDIC_TIME_OF_DEATH");

        NAPI.TextLabel.CreateTextLabel("~y~Drücke ~b~E~w~", new Vector3(-41.26046, 224.6604, 107.9488 + 1.5), 12, 0.350f, 4, new Color(255, 255,255,255));



    }
    public static void PressKeyK(Client player)
    {
        if (player.GetData("fishing") == true && player.GetData("fishingCaptured") != -1 && player.GetData("fishingCaptured") != -255)
        {
            if (player.GetData("fishingCaptured") == -255)
            {
                return;
            }

            int fish_id = player.GetData("fishingCaptured");
            NAPI.Util.ConsoleOutput(">>> fish" + fish_id);
            if(fish_id == -1)
            {
                return;
            }
            if (fish_id == 255)
            {
                return;
            }

            if (Inventory.Check_InventoryWeight_With_ItemAmount(player, Inventory.Item_Name_To_Type(fishes[fish_id].name), 1, Inventory.Max_Inventory_Weight(player)))
            {
                return;
            }


            Inventory.GiveItemToInventory(player, Inventory.Item_Name_To_Type(fishes[fish_id].name), 1);

            player.SetData("fishingCaptured", 255);
            //player.SendChatMessage("~y~*~w~ Você pegou um ~b~" + fishes[fish_id].name + " ~y~(" + fishes[fish_id].rarity + ")~w~ que vale ~g~$" + fishes[fish_id].price + "~w~.");
            Main.DisplaySubtitle(player, "Du hast 1x ~y~" + fishes[fish_id].name + " ~o~(" + fishes[fish_id].rarity + ")~w~ ! weiter Angeln ... ", 7);

            player.TriggerEvent("createNewHeadNotificationAdvanced", "Du hast einen ~y~" + fishes[fish_id].name + " ~o~(" + fishes[fish_id].rarity + ")~w~ gefangen!");


        }
    }

    public static void SelectMenuResponse(Client player, String callbackId, int selectedIndex, String objectName, String valueList)
    {
        if (callbackId == "FISH_SELL")
        {
            string item_name = player.GetData("ListTrack_" + selectedIndex);


            API.Shared.ConsoleOutput(item_name.ToString() + Inventory.Item_Name_To_Type(item_name).ToString() );

            if (Inventory.GetPlayerItemFromInventory(player, Inventory.Item_Name_To_Type(item_name)) < 1)
            {
                Main.SendErrorMessage(player, "Sie besitzen diese Artikelmenge nicht.");
                return;
            }

            int index = Inventory.GetInventoryIndexFromName(player, item_name);

            foreach (var fishes in fishes)
            {
                if (fishes.name == item_name)
                {
                    int price = fishes.price;
                    Main.GivePlayerMoney(player, price);

                    player.TriggerEvent("createNewHeadNotificationAdvanced", "Du hast einen ~y~" + fishes.name + " verkauft ~o~(" + fishes.rarity + ")~w~ für ~g~$" + price + "~w~.");

                    Inventory.RemoveItem(player, item_name, 1);
                    CMD_venderpeixe(player);

                    
                }
            }
        }
    }


    [Command("venderpeixe")]
    public static void CMD_venderpeixe(Client player)
    {
        if (!Main.IsInRangeOfPoint(player.Position, new Vector3(-41.26046, 224.6604, 107.9488), 4.0f))
        {
            Main.DisplayErrorMessage(player, "Sie sind nicht an einem Fish of Point. ~c~ Der Fish of Point befindet sich auf der Karte mit einem roten Angelsymbol.");
            return;
        }

        int count = 0;
        List<dynamic> menu_item_list = new List<dynamic>();

        foreach (var fishes in fishes)
        {
            foreach (var inventory in Inventory.player_inventory)
            {
                for (int index = 0; index < Inventory.MAX_INVENTORY_ITENS; index++)
                {
                    if (fishes.name == Inventory.itens_available[inventory.type[index]].name)
                    {
                        if (inventory.sql_id[index] != -1 && inventory.type[index] >= 27 && inventory.type[index] <= 32 && inventory.amount[index] > 0)
                        {
                            menu_item_list.Add(new { Type = 1, Name = "" + inventory.amount[index] + "x " + Inventory.itens_available[inventory.type[index]].name, Description = "", RightLabel = "$" + fishes.price + "" });
                            player.SetData("ListTrack_" + count, Inventory.itens_available[inventory.type[index]].name);
                            count++;
                        }
                    }
                }
            }
        }

        if (count == 0)
        {
            return;
        }
        //
       
        InteractMenu.CreateMenu(player,  "FISH_SELL", "Fish of Point", "~b~Fischverkauf", false, NAPI.Util.ToJson(menu_item_list), false);

    }

    public static void PressKeyY(Client player)
    {
        if(Main.IsInRangeOfPoint(player.Position, new Vector3(-41.26046, 224.6604, 107.9488), 5f))
        {
            CMD_venderpeixe(player);
        }
        foreach (var points in fish_points)
        {
            if (Main.IsInRangeOfPoint(player.Position, points.position, 1f))
            {
                if (player.GetData("fishing") == false)
                {
                    if (Main.getIdFromClient(player) == -1) return;
                    int can_pass = -1;
                    for (int i = 0; i < MAX_FISH_PER_PLAYER; i++)
                    {
                        if (NAPI.Data.GetEntityData(player, "peixe_" + i) == -1)
                        {
                            can_pass = i;
                            break;
                        }
                    }
                    if (can_pass == -1)
                    {
                        player.SendChatMessage("Du hast soviele Fische gefangen, daher gehe nun diese verkaufen, damit du mehr fangen können!");
                        return;
                    }
                    //player.moveRotation(new Vector3(player.Rotation.X, player.Rotation.Y, points.rotation), 1000);
                    //NAPI.Entity.SetEntityRotation(player, new Vector3(player.Rotation.X, player.Rotation.Y, points.rotation));
                    player.TriggerEvent("freezeEx", true);

                    //player.PlayScenario("WORLD_HUMAN_STAND_FISHING");
                    NAPI.Player.PlayPlayerAnimation(player, 49, "amb@world_human_stand_fishing@idle_a", "idle_c");
                    BasicSync.AttachObjectToPlayer(player, NAPI.Util.GetHashKey("prop_fishing_rod_01"), 57005, new Vector3(0.1, -0.1, -0.02), new Vector3(80, 0, 170));

                    player.TriggerEvent("addLocal", "fish_rod");
                    //player.TriggerEvent("playScenarioEx", "WORLD_HUMAN_STAND_FISHING");
             
          

                    player.SetData("fishing", true);
                    
                    Random rnd = new Random();
                    int random_timer = rnd.Next(15, 30);
                    int current_timer = 0;

                    int random_fish = 0;

                    Main.SendInfoMessage(player, "Sie fischen jetzt. Um das Fischen zu beenden, drücken Sie " + Main.EMBED_LIGHTGREEN+"E"+Main.EMBED_WHITE+".");

                    // 0 - Verbreitet
                    // 1 - Selten
                    // 2 - Super Selten
                    // 3 - Epos
                    //Main.getIdFromClient(player)
                    
                    fishTimer[Main.getIdFromClient(player)] = TimerEx.SetTimer(() => {
                        current_timer++;

                        if(!Main.IsInRangeOfPoint(player.Position, points.position, 1f))
                        {
                            if (Main.getIdFromClient(player) != -1 && fishTimer[Main.getIdFromClient(player)] != null)
                            {
                                //API.shared.stopTimer(fishTimer);
                                fishTimer[Main.getIdFromClient(player)].Kill();
                                fishTimer[Main.getIdFromClient(player)] = null;
                                Main.DisplaySubtitle(player, "", 3);
                            }
                            player.TriggerEvent("removeLocal", "fish_rod");
                            BasicSync.DetachObject(player);
                            player.StopAnimation();
                            player.SetData("fishing", false);
                            player.TriggerEvent("freezeEx", false);
                            player.SetData("fishingCaptured", -1);
                        }

                        if(current_timer >= random_timer)
                        {
                            if (current_timer == random_timer)
                            {
                                int fishes = rnd.Next(0, 1000);

                                if(fishes >= 0 && fishes <= 499)
                                {
                                    random_fish = 2;
                                }
                                else if (fishes >= 500 && fishes <= 899)
                                {
                                    random_fish = 3;
                                }
                                else if (fishes >= 900 && fishes <= 999)
                                {
                                    random_fish = 5;
                                }
                                else
                                {
                                    random_fish = 6;
                                }

                                player.SetData("fishingCaptured", random_fish);

                            }

                            if(player.GetData("fishingCaptured") != 255)
                            {
                                Main.DisplaySubtitle(player, "~y~" + fishes[random_fish].name + " (" + fishes[random_fish].rarity + ") nimmt den Köder!~w~ Drücke ~b~K~w~ !", 1);

                                if(fishes[random_fish].rarity == "Extrem Selten") player.TriggerEvent("createNewHeadNotificationAdvanced", "Ein Fisch hat den Köder genommen!");
                                
                            }

                            if (current_timer == random_timer + 6)
                            {
                                if (player.GetData("fishingCaptured") != 255) Main.DisplaySubtitle(player, "~o~Scheisse! Der Fisch ist entkommen !!", 1);
                                random_timer = rnd.Next(15, 30);
                                current_timer = 0;

                                player.SetData("fishingCaptured", -1);
                            }

                        }
                        else Main.DisplaySubtitle(player, "~b~ Angeln: ~w~darauf warten, dass ein Fisch den Köder nimmt ...", 1);

                        if(player.GetData("status") == false)
                        {
                            try
                            {
                                fishTimer[Main.getIdFromClient(player)].Kill();
                                fishTimer[Main.getIdFromClient(player)] = null;
                            }
                            catch (Exception)
                            {

                            }
                        }

                    }, 1000, 0);
                }
                else
                {
                   if (Main.getIdFromClient(player) != -1 && fishTimer[Main.getIdFromClient(player)] != null)
                    {
                        //API.shared.stopTimer(fishTimer);
                        fishTimer[Main.getIdFromClient(player)].Kill();
                        fishTimer[Main.getIdFromClient(player)] = null;
                        Main.DisplaySubtitle(player, "", 3);
                    }
                    player.TriggerEvent("removeLocal", "fish_rod");
                    player.StopAnimation();
                    player.SetData("fishing", false);
                    player.TriggerEvent("freezeEx", false);
                    player.SetData("fishingCaptured", -1);
                }
                return;
            }
        }
    }
}