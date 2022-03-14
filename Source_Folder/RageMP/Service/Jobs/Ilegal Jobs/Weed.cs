using System;
using System.Collections.Generic;
using GTANetworkAPI;
using DerStr1k3r.Core;
using DerStr1k3r.SDK;

//-2093428068 

class Weed : Script
{
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
      //Blip temp_blip = NAPI.Blip.CreateBlip(new Vector3(2201.68, 5579.258, 53.91399));
      //  NAPI.Blip.SetBlipName(temp_blip, "Colheita de Cannabis");
      //  NAPI.Blip.SetBlipSprite(temp_blip, 140);
      //  NAPI.Blip.SetBlipColor(temp_blip, 60);
      //  NAPI.Blip.SetBlipScale(temp_blip, 1.0f);
      //  NAPI.Blip.SetBlipShortRange(temp_blip, true);

      ///*  temp_blip = NAPI.Blip.CreateBlip(new Vector3(1469.512, 6550.428, 14.90413));
      //  NAPI.Blip.SetBlipName(temp_blip, "Processamento de Opium / Cannabis");
      //  NAPI.Blip.SetBlipSprite(temp_blip, 51); //501
      //  NAPI.Blip.SetBlipColor(temp_blip, 25);
      //  NAPI.Blip.SetBlipScale(temp_blip, 1.0f);
      //  NAPI.Blip.SetBlipShortRange(temp_blip, true);*/

      //  temp_blip = NAPI.Blip.CreateBlip(new Vector3(-140.1286, -1599.323, 34.83134));
      //  NAPI.Blip.SetBlipName(temp_blip, "Traficante de Drogas");
      //  NAPI.Blip.SetBlipSprite(temp_blip, 501); //501
      //  NAPI.Blip.SetBlipColor(temp_blip, 25);
      //  NAPI.Blip.SetBlipScale(temp_blip, 0.8f);
      //  NAPI.Blip.SetBlipShortRange(temp_blip, true);

        API.Shared.DeleteWorldProp(-305885281, new Vector3(2209.981, 5577.867, 53.93683), 40f);
        API.Shared.DeleteWorldProp(452618762, new Vector3(2209.981, 5577.867, 53.93683), 40f);

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


        //NAPI.Marker.CreateMarker(25, new Vector3(1469.512, 6550.428, 14.90413) - new Vector3(0, 0, 0.8f), new Vector3(), new Vector3(), 2.5f, new Color(0, 200, 0, 110));

        NAPI.TextLabel.CreateTextLabel("~g~- Drücke [ E ] ", new Vector3(1443.466, 6333.328, 23.88731 - 0.2f), 8.0f, 0.8f, 4, new Color(255, 255, 255, 255));
        NAPI.TextLabel.CreateTextLabel("~g~- Drücke [ E ] ", new Vector3(-359.0583, -2024.968, 29.94633 - 0.2f), 8.0f, 0.8f, 4, new Color(255, 255, 255, 255));

        NAPI.TextLabel.CreateTextLabel("~w~- Drücke [ E ] ", new Vector3(-45.23797, -1223.94, 29.2616 - 0.2f), 8.0f, 0.8f, 4, new Color(255, 255, 255, 255));
        NAPI.TextLabel.CreateTextLabel("~w~- Drücke [ E ] ", new Vector3(4924.355, -5244.069, 2.523737 - 0.2f), 8.0f, 0.8f, 4, new Color(255, 255, 255, 255));
       // API.Shared.CreateTextLabel("~w~- Drücke [ E ] ", new Vector3(5194.961, -5134.781, 3.34955 - 0.2f), 8.0f, 0.8f, 4, new Color(255, 255, 255, 255));
        NAPI.TextLabel.CreateTextLabel("~y~Drücke [ E ]", new Vector3(1545.236, 6332.537, 24.07878 - 0.5), 8.0f, 0.350f, 4, new Color(255, 255, 255, 255));
        NAPI.TextLabel.CreateTextLabel("~y~Drücke [ E ]", new Vector3(5194.961, -5134.781, 3.34955 - 0.5), 8.0f, 0.350f, 4, new Color(255, 255, 255, 255));

        foreach (var weed in WeedList)
        {
            weed.downtime = 10 * 60;
            weed.timer = null;
            weed.objectHandle = API.Shared.CreateObject(452618762, new Vector3(weed.position.X, weed.position.Y, weed.position.Z - 1.2f), new Vector3(), 255, 0);
            weed.textLabel = API.Shared.CreateTextLabel("~h~~g~-~y~ Drücke [ E ]", new Vector3(weed.position.X, weed.position.Y, weed.position.Z - 0.4f), 4.0f, 0.3f, 4, new Color(255, 255, 255, 255), true, 0);
        }


    }

    public static void PressKeyY(Client player)
    {
       if (Main.IsInRangeOfPoint(player.Position, new Vector3(1545.236, 6332.537, 24.07878), 2.0f) || Main.IsInRangeOfPoint(player.Position, new Vector3(5194.961, -5134.781, 3.34955), 2.0f))
        {
            List<dynamic> menu_item_list = new List<dynamic>();
            menu_item_list.Add(new { Type = 1, Name = "Verkaufe Marihuana", Description = "Wählen Sie diese Option, um Marihuana an den Händler zu verkaufen.", RightLabel = "" });
            menu_item_list.Add(new { Type = 1, Name = "Verkaufe Kokain", Description = "Wählen Sie diese Option, um Kokain an den Händler zu verkaufen.", RightLabel = "" });
            menu_item_list.Add(new { Type = 1, Name = "Verkaufe Ecstasy", Description = "Wählen Sie diese Option, um Kokain an den Händler zu verkaufen.", RightLabel = "" });
            InteractMenu.CreateMenu(player,  "SELL_DRUGS", "Labor", "~b~Illegale Drogen", true, NAPI.Util.ToJson(menu_item_list), false);
        }
        if (Main.IsInRangeOfPoint(player.Position, new Vector3(1469.512, 6550.428, 14.90413), 2.5f))
        {

            if (player.GetData("Sal") > 0 && player.GetData("Refinando") == false)
            {
                List<dynamic> menu_item_list = new List<dynamic>();
                menu_item_list.Add(new { Type = 1, Name = "Marihuana verarbeiten", Description = "Wählen Sie diese Option, um Cannabissamen für Marihuana zu verarbeiten.", RightLabel = "" });
                menu_item_list.Add(new { Type = 1, Name = "Kokain verarbeiten", Description = "Wählen Sie diese Option, um das Opium zu verarbeiten und in Heroin umzuwandeln.", RightLabel = "" });
                InteractMenu.CreateMenu(player,  "REFINAR_DROGAS", "Laboratorio", "~b~Illegale Drogen", true, NAPI.Util.ToJson(menu_item_list), false);
            }
            else if (player.GetData("Refinando") == true)
            {
                InteractMenu.CloseDynamicMenu(player);
                if (Main_Job.job_timer[Main.getIdFromClient(player)] != null)
                {
                    Main_Job.job_timer[Main.getIdFromClient(player)].Kill();
                    Main_Job.job_timer[Main.getIdFromClient(player)] = null;
                }
                player.StopAnimation();
                player.SetData("Refinando", false);
                player.TriggerEvent("freezeEx", false);
                player.TriggerEvent("DestroyProgressBar");
            }

        }
        else
        {
            if (Main.IsInRangeOfPoint(player.Position, new Vector3(-359.0583, -2024.968, 29.94633), 1.0f) || Main.IsInRangeOfPoint(player.Position, new Vector3(1443.466, 6333.328, 23.88731), 1.0f)) // Maconha
            {
                StartProcess(player, 1);
            }
            else if (Main.IsInRangeOfPoint(player.Position, new Vector3(4924.355, -5244.069, 2.523737), 1.0f) || Main.IsInRangeOfPoint(player.Position, new Vector3(-45.23797, -1223.94, 29.2616), 1.0f)) // Maconha
            {
                StartProcess(player, 2);
            }
            else if (Main.IsInRangeOfPoint(player.Position, new Vector3(1010.86, -3200.156, -38.99313), 3.0f)) // Meta
            {
                Main.SendInfoMessage(player, "System in Entwicklung ...");
            }
            else
            {
                foreach (var weed in WeedList)
                {
                    if (Main.IsInRangeOfPoint(player.Position, weed.position, 1.0f) && weed.stage == 0)
                    {
                        if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 11, 4, Inventory.Max_Inventory_Weight(player)))
                        {
                            return;
                        }

                        weed.stage = 1;

                        Inventory.GiveItemToInventory(player, 11, 7);
                        //player.TriggerEvent("createNewHeadNotificationAdvanced", "Voce colheu ~y~4~y~ Cannabis~w~ !");
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"7x Marihuana Pflanzen gesammelt!", 5000);
                        //Main.SendNotificationBrowser(player, "", "<string>+ 4</strong> Cannabis wurde Ihrem Inventar hinzugefügt!", "success");
                        //Main.SendSuccessMessage(player, "Você colheu " + Main.EMBED_LIGHTGREEN + "4" + Main.EMBED_WHITE + " " + Main.EMBED_ORANGE + "Maconha não-processada" + Main.EMBED_WHITE + " da fazenda.");

                        NAPI.Player.PlayPlayerAnimation(player, (int)(Main.AnimationFlags.Loop), "anim@mp_snowball", "pickup_snowball");
                        NAPI.Task.Run(() =>
                        {
                            player.StopAnimation();
                            weed.objectHandle.Position = new Vector3(weed.position.X, weed.position.Y, weed.position.Z - 2.8f);
                        }, delayTime: 1500);


                        //weed.timer = TimerEx.SetTimer(() =>
                        //{
                        //    weed.downtime--;

                        //    weed.textLabel.Text = "~h~~g~-~y~ Cannabis~g~ -~w~~n~~n~Bereit zum Sammeln in: ~y~" + weed.downtime;

                        //    switch (weed.downtime)
                        //    {
                        //        case 590: weed.objectHandle.MovePosition(new Vector3(weed.position.X, weed.position.Y, weed.position.Z - 2.7f), 1000); break;
                        //        case 550: weed.objectHandle.MovePosition(new Vector3(weed.position.X, weed.position.Y, weed.position.Z - 2.6f), 1000); break;
                        //        case 500: weed.objectHandle.MovePosition(new Vector3(weed.position.X, weed.position.Y, weed.position.Z - 2.5f), 1000); break;
                        //        case 450: weed.objectHandle.MovePosition(new Vector3(weed.position.X, weed.position.Y, weed.position.Z - 2.4f), 1000); break;
                        //        case 400: weed.objectHandle.MovePosition(new Vector3(weed.position.X, weed.position.Y, weed.position.Z - 2.3f), 1000); break;
                        //        case 350: weed.objectHandle.MovePosition(new Vector3(weed.position.X, weed.position.Y, weed.position.Z - 2.2f), 1000); break;
                        //        case 300: weed.objectHandle.MovePosition(new Vector3(weed.position.X, weed.position.Y, weed.position.Z - 2.1f), 1000); break;
                        //        case 250: weed.objectHandle.MovePosition(new Vector3(weed.position.X, weed.position.Y, weed.position.Z - 2.0f), 1000); break;
                        //        case 200: weed.objectHandle.MovePosition(new Vector3(weed.position.X, weed.position.Y, weed.position.Z - 1.9f), 1000); break;
                        //        case 150: weed.objectHandle.MovePosition(new Vector3(weed.position.X, weed.position.Y, weed.position.Z - 1.8f), 1000); break;
                        //        case 100: weed.objectHandle.MovePosition(new Vector3(weed.position.X, weed.position.Y, weed.position.Z - 1.7f), 1000); break;
                        //        case 50: weed.objectHandle.MovePosition(new Vector3(weed.position.X, weed.position.Y, weed.position.Z - 1.6f), 1000); break;
                        //        case 30: weed.objectHandle.MovePosition(new Vector3(weed.position.X, weed.position.Y, weed.position.Z - 1.5f), 1000); break;
                        //        case 20: weed.objectHandle.MovePosition(new Vector3(weed.position.X, weed.position.Y, weed.position.Z - 1.4f), 1000); break;
                        //        case 10: weed.objectHandle.MovePosition(new Vector3(weed.position.X, weed.position.Y, weed.position.Z - 1.3f), 1000); break;
                        //        case 0: weed.objectHandle.MovePosition(new Vector3(weed.position.X, weed.position.Y, weed.position.Z - 1.2f), 1000); break;
                        //    }

                        //    if (weed.downtime == 0)
                        //    {
                        //        weed.downtime = 10 * 60;
                        //        weed.stage = 0;
                        //        weed.textLabel.Text = "~h~~g~-~y~ Cannabis~g~ -~w~~n~~n~Drücke E";
                        //        weed.timer.Kill();
                        //    }

                        //}, 1000, 0);
                        return;
                    }

                }
            }
        }
    }

    public static void SelectMenuResponse(Client player, String callbackId, int selectedIndex, String objectName, String valueList)
    {
        if (callbackId == "REFINAR_DROGAS")
        {
            if (selectedIndex == 0)
            {
                StartProcess(player, 1);
            }
            else if (selectedIndex == 1)
            {
                StartProcess(player, 2);
            }

        }
        else if(callbackId == "SELL_DRUGS")
        {
            if (selectedIndex == 0)
            {
                if (Inventory.GetPlayerItemFromInventory(player, 12) > 0)
                {
                    InteractMenu.User_Input(player, "input_sell_weed", "Verkaufe Marihuana", Inventory.GetPlayerItemFromInventory(player, 12).ToString(), "Derzeit hast du "+Inventory.GetPlayerItemFromInventory(player, 12)+"", "number");
                }
            }
            else if (selectedIndex == 1)
            {
                if (Inventory.GetPlayerItemFromInventory(player, 16) > 0)
                {
                    InteractMenu.User_Input(player, "input_sell_heroin", "Verkaufe Kokain", Inventory.GetPlayerItemFromInventory(player, 16).ToString(), "Derzeit hast du " + Inventory.GetPlayerItemFromInventory(player, 16) + "", "number");
                }
            }
            else if (selectedIndex == 2)
            {
                if (Inventory.GetPlayerItemFromInventory(player, 61) > 0)
                {
                    InteractMenu.User_Input(player, "input_sell_ecstasy", "Verkaufe Ecstasy", Inventory.GetPlayerItemFromInventory(player, 61).ToString(), "Derzeit hast du " + Inventory.GetPlayerItemFromInventory(player, 61) + "", "number");
                }
            }
        }
    }
    public static void OnInputResponse(Client player, String response, String inputtext)
    {
        if(response == "input_sell_weed")
        {
            if (Inventory.GetPlayerItemFromInventory(player, 12) > 0)
            {
                if (player.GetData("character_licence_illegal_ordering_1") == 0)
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"Du hast das Buch der Pflanzen nicht!", 5000);
                    return;
                }

                if (!Main.IsNumeric(inputtext))
                {
                    Main.DisplayErrorMessage(player, "Der eingegebene Wert ist nicht numerisch, bitte geben Sie einen gültigen Wert ein.");
                    return;
                }

                int valor = Convert.ToInt32(inputtext);

                if (valor < 1)
                {
                    Main.DisplayErrorMessage(player, "Der eingegebene Wert darf nicht kleiner als 1 sein.");
                    return;
                }

                if (Inventory.GetPlayerItemFromInventory(player, 12) < valor)
                {
                    Main.DisplayErrorMessage(player, "Du hast " + valor + ", aber du hast nur " + Inventory.GetPlayerItemFromInventory(player, 12) + ".");
                    return;
                }

                int price = valor * 68;

                Main.GivePlayerMoney(player, price);
                Main.SendSuccessMessage(player, "Du hast " + Main.EMBED_BLUE + "" + valor + "" + Main.EMBED_WHITE + " verkauft für " + Main.EMBED_LIGHTGREEN + "$" + price.ToString("N0") + "" + Main.EMBED_WHITE + ".");
                Inventory.RemoveItemByType(player, 12, valor);
            }
        }
        else if(response == "input_sell_heroin")
        {
            if (Inventory.GetPlayerItemFromInventory(player, 16) > 0)
            {
                if (player.GetData("character_licence_illegal_ordering_2") == 0)
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"Du hast das Buch der Chemie nicht!", 5000);
                    return;
                }

                if (!Main.IsNumeric(inputtext))
                {
                    Main.DisplayErrorMessage(player, "Der eingegebene Wert ist nicht numerisch, bitte geben Sie einen gültigen Wert ein.");
                    return;
                }

                int valor = Convert.ToInt32(inputtext);

                if (valor < 1)
                {
                    Main.DisplayErrorMessage(player, "Der eingegebene Wert darf nicht kleiner als 1 sein.");
                    return;
                }

                if (Inventory.GetPlayerItemFromInventory(player, 16) < valor)
                {
                    Main.DisplayErrorMessage(player, "Du hast " + valor + ", aber du hast nur " + Inventory.GetPlayerItemFromInventory(player, 16) + ".");
                    return;
                }

                int price = valor * 99;

                Main.GivePlayerMoney(player, price);
                Main.SendSuccessMessage(player, "Verkauft: " + Main.EMBED_BLUE + "" + valor + "" + Main.EMBED_WHITE + " Kokain für " + Main.EMBED_LIGHTGREEN + "$" + price.ToString("N0") + "" + Main.EMBED_WHITE + ".");
                Inventory.RemoveItemByType(player, 16, valor);
            }
        }
        else if (response == "input_sell_ecstasy")
        {
            if (Inventory.GetPlayerItemFromInventory(player, 61) > 0)
            {
                if (player.GetData("character_licence_illegal_ordering_2") == 0)
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"Du hast das Buch der Chemie nicht!", 5000);
                    return;
                }

                if (!Main.IsNumeric(inputtext))
                {
                    Main.DisplayErrorMessage(player, "Der eingegebene Wert ist nicht numerisch, bitte geben Sie einen gültigen Wert ein.");
                    return;
                }

                int valor = Convert.ToInt32(inputtext);

                if (valor < 1)
                {
                    Main.DisplayErrorMessage(player, "Der eingegebene Wert darf nicht kleiner als 1 sein.");
                    return;
                }

                if (Inventory.GetPlayerItemFromInventory(player, 61) < valor)
                {
                    Main.DisplayErrorMessage(player, "Du hast " + valor + ", aber du hast nur " + Inventory.GetPlayerItemFromInventory(player, 16) + ".");
                    return;
                }

                int price = valor * 142;

                Main.GivePlayerMoney(player, price);
                Main.SendSuccessMessage(player, "Verkauft: " + Main.EMBED_BLUE + "" + valor + "" + Main.EMBED_WHITE + " Ecstasy für " + Main.EMBED_LIGHTGREEN + "$" + price.ToString("N0") + "" + Main.EMBED_WHITE + ".");
                Inventory.RemoveItemByType(player, 61, valor);
            }
        }
    }

    public static void StartProcess(Client player, int type)
    {
        if (player.GetData("Refinando") == true)
        {
            InteractMenu.CloseDynamicMenu(player);
            if (Main_Job.job_timer[Main.getIdFromClient(player)] != null)
            {
                Main_Job.job_timer[Main.getIdFromClient(player)].Kill();
                Main_Job.job_timer[Main.getIdFromClient(player)] = null;
            }
            player.StopAnimation();
            player.SetData("Refinando", false);
            player.TriggerEvent("freezeEx", false);
            player.TriggerEvent("DestroyProgressBar");
            return;
        }
        if (type == 1)
        {
            if (Inventory.GetPlayerItemFromInventory(player, 11) >= 2 && player.GetData("Refinando") == false)
            {
                if (player.GetData("character_licence_illegal_ordering_1") == 0)
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"Du hast das Buch der Pflanzen nicht!", 5000);
                    return;
                }
                //
                int sals = Inventory.GetPlayerItemFromInventory(player, 11);
                int sals_a_ser_refinados = 0;

                //
                player.SetData("Refinando", true);
                player.SetData("RefinandoTime", 25);

                //
                player.TriggerEvent("freezeEx", true);
                player.PlayScenario("WORLD_HUMAN_GUARD_STAND");

                //
                //player.TriggerEvent("SetProgressBar", player.GetData("RefinandoTime"), "Processando Maconha não-processada - " + sals_a_ser_refinados + " de " + sals + "");

                //
                Main_Job.job_timer[Main.getIdFromClient(player)] = TimerEx.SetTimer(() =>
                {
                    //
                    if (Inventory.GetPlayerItemFromInventory(player, 11) >= 2)
                    {
                        // 
                        player.SetData("RefinandoTime", player.GetData("RefinandoTime") + 25);
                        //player.TriggerEvent("SetProgressBar", player.GetData("RefinandoTime"), "Processando Maconha não-processada - " + sals_a_ser_refinados + " de " + sals + "");

                        if (player.GetData("RefinandoTime") > 100)
                        {
                            //
                            sals_a_ser_refinados += 2;

                            // Remove o Sal e conta tudo novamente.
                            Inventory.RemoveItemByType(player, 11, 2);
                            Inventory.GiveItemToInventory(player, 12, 1);

                            //
                            player.SetData("RefinandoTime", 0);
                            //player.TriggerEvent("SetProgressBar", player.GetData("RefinandoTime"), "Processando Maconha não-processada - " + sals_a_ser_refinados + " de " + sals + "");

                            //
                            player.TriggerEvent("createNewHeadNotificationAdvanced", "~g~+~w~ 1x verarbeitet");

                            //
                            if (Inventory.GetPlayerItemFromInventory(player, 11) == 0)
                            {
                                if (Main_Job.job_timer[Main.getIdFromClient(player)] != null)
                                {
                                    Main_Job.job_timer[Main.getIdFromClient(player)].Kill();
                                    Main_Job.job_timer[Main.getIdFromClient(player)] = null;
                                }
                                player.StopAnimation();
                                player.SetData("Refinando", false);
                                player.TriggerEvent("freezeEx", false);
                                //player.TriggerEvent("DestroyProgressBar");
                            }
                        }
                    }
                    else
                    {
                        //
                        if (Main_Job.job_timer[Main.getIdFromClient(player)] != null)
                        {
                            Main_Job.job_timer[Main.getIdFromClient(player)].Kill();
                            Main_Job.job_timer[Main.getIdFromClient(player)] = null;
                        }
                        player.StopAnimation();
                        player.SetData("Refinando", false);
                        player.TriggerEvent("freezeEx", false);
                        //player.TriggerEvent("DestroyProgressBar");
                    }

                    if (player.GetData("status") == false)
                    {
                        try
                        {
                            Main_Job.job_timer[Main.getIdFromClient(player)].Kill();
                            Main_Job.job_timer[Main.getIdFromClient(player)] = null;
                        }
                        catch (Exception)
                        {

                        }
                    }
                }, 1000, 0);
            }
        }
        else if (type == 2)
        {
            if (player.GetData("character_licence_illegal_ordering_2") == 0)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"Du hast das Buch der Chemie nicht!", 5000);
                return;
            }
            //
            int sals = Inventory.GetPlayerItemFromInventory(player, 15);
            int sals_a_ser_refinados = 0;

            //
            player.SetData("Refinando", true);
            player.SetData("RefinandoTime", 25);

            //
            player.TriggerEvent("freezeEx", true);
            player.PlayScenario("WORLD_HUMAN_GUARD_STAND");

            //
            //player.TriggerEvent("SetProgressBar", player.GetData("RefinandoTime"), "Processando Opium - " + sals_a_ser_refinados + " de " + sals + "");

            //
            Main_Job.job_timer[Main.getIdFromClient(player)] = TimerEx.SetTimer(() =>
            {
                //
                if (Inventory.GetPlayerItemFromInventory(player, 15) >= 1)
                {
                    // 
                    player.SetData("RefinandoTime", player.GetData("RefinandoTime") + 25);
                    //player.TriggerEvent("SetProgressBar", player.GetData("RefinandoTime"), "Processando Opium - " + sals_a_ser_refinados + " de " + sals + "");

                    if (player.GetData("RefinandoTime") > 100)
                    {
                        //
                        sals_a_ser_refinados += 1;

                        // Remove o Sal e conta tudo novamente.
                        Inventory.RemoveItemByType(player, 15, 1);
                        Inventory.GiveItemToInventory(player, 16, 1);

                        //
                        player.SetData("RefinandoTime", 0);
                        //player.TriggerEvent("SetProgressBar", player.GetData("RefinandoTime"), "Processando Opium - " + sals_a_ser_refinados + " de " + sals + "");

                        //
                        player.TriggerEvent("createNewHeadNotificationAdvanced", "~g~+~w~ 1x verarbeitet");

                        //
                        if (Inventory.GetPlayerItemFromInventory(player, 15) == 0)
                        {
                            if (Main_Job.job_timer[Main.getIdFromClient(player)] != null)
                            {
                                Main_Job.job_timer[Main.getIdFromClient(player)].Kill();
                                Main_Job.job_timer[Main.getIdFromClient(player)] = null;
                            }
                            player.StopAnimation();
                            player.SetData("Refinando", false);
                            player.TriggerEvent("freezeEx", false);
                            //player.TriggerEvent("DestroyProgressBar");
                        }
                    }
                }
                else
                {
                    //
                    if (Main_Job.job_timer[Main.getIdFromClient(player)] != null)
                    {
                        Main_Job.job_timer[Main.getIdFromClient(player)].Kill();
                        Main_Job.job_timer[Main.getIdFromClient(player)] = null;
                    }
                    player.StopAnimation();
                    player.SetData("Refinando", false);
                    player.TriggerEvent("freezeEx", false);
                    //player.TriggerEvent("DestroyProgressBar");
                }
                if (player.GetData("status") == false)
                {
                    try
                    {
                        Main_Job.job_timer[Main.getIdFromClient(player)].Kill();
                        Main_Job.job_timer[Main.getIdFromClient(player)] = null;
                    }
                    catch (Exception)
                    {

                    }
                }
            }, 1000, 0);
        }
    }

    [Command("vendermaconha", "/vendermaconha [quantidade] [preço] ~c~(O jogador deve está perto de você)")]
    public void CMD_vendermaconha(Client player, int amount, int price)
    {

        foreach (var target in NAPI.Pools.GetAllPlayers())
        {
            if (target.GetData("status") == true && Main.IsInRangeOfPoint(player.Position, target.Position, 3.0f) && player != target)
            {

                if(amount < 1)
                {
                    Main.SendErrorMessage(player, "Die Menge darf nicht kleiner als 1 sein.");
                    return;
                }

                int index = Inventory.GetInventoryIndexFromName(player, "Baseado");

                if (player.GetData("inventory_item_" + index + "_amount") >= amount)
                {
                    //Inventory.GiveItemToInventory(target, 12, 3);

                    target.SetData("offer_price", price);
                    target.SetData("offer_amount", amount);
                    target.SetData("offer_seller", player);
                    target.SetData("offer", true);

                    Main.SendInfoMessage(target, "O jogador "+AccountManage.GetCharacterName(player)+" está lhe oferecendo "+amount+ " baseado por " + price.ToString("N0")+".");
                    Main.SendInfoMessage(player, "Você está oferecendo à "+AccountManage.GetCharacterName(target)+ " baseado " + amount+" por "+price.ToString("N0")+".");

                    InteractMenu.ShowModal(target, "WEED_OFFER", "Ofereceu à você "+ amount + " baseado por " + amount + "", "O jogador " + AccountManage.GetCharacterName(player) + " está lhe oferecendo " + amount + " baseado por " + price.ToString("N0") + "<br><br>Você deseja aceitar está oferta ?", "Sim, pagar " + price.ToString("N0") + "", "Não, obrigado");
                }
                else
                {
                    Main.SendErrorMessage(player, "Você não tem este item em seu inventário.");
                }
                return;

            }
        }
        Main.SendErrorMessage(player, "Você não tem este item em seu inventário.");
    }

    [Command("vendercocaina", "/vendercocaina [quantidade] [preço] ~c~(O jogador deve está perto de você)")]
    public void CMD_venderheroina(Client player, int amount, int price)
    {

        foreach (var target in NAPI.Pools.GetAllPlayers())
        {
            
            if (target.GetData("status") == true && Main.IsInRangeOfPoint(player.Position, target.Position, 3.0f) && player != target)
            {

                if (amount < 1)
                {
                    Main.SendErrorMessage(player, "A quantidade não pode ser menos que 1.");
                    return;
                }

                int index = Inventory.GetInventoryIndexFromName(player, "Cocaina");

                if (player.GetData("inventory_item_" + index + "_amount") >= amount)
                {
                    //Inventory.GiveItemToInventory(target, 12, 3);

                    target.SetData("offer_price", price);
                    target.SetData("offer_amount", amount);
                    target.SetData("offer_seller", player);
                    target.SetData("offer", true);

                    Main.SendInfoMessage(target, "O jogador " + AccountManage.GetCharacterName(player) + " está lhe oferecendo " + amount + " heroina por " + price.ToString("N0") + ".");
                    Main.SendInfoMessage(player, "Você está oferecendo à " + AccountManage.GetCharacterName(target) + " heroina " + amount + " por " + price.ToString("N0") + ".");

                    InteractMenu.ShowModal(target, "HEROIN_OFFER", "Ofereceu à você " + amount + " heroina por " + amount + "", "O jogador " + AccountManage.GetCharacterName(player) + " está lhe oferecendo " + amount + " heroina por " + price.ToString("N0") + "<br><br>Você deseja aceitar está oferta ?", "Sim, pagar " + price.ToString("N0") + "", "Não, obrigado");
                }
                else
                {
                    Main.SendErrorMessage(player, "Você não tem este item em seu inventário.");
                }
                return;

            }
        }
        Main.SendErrorMessage(player, "Você não tem este item em seu inventário.");
    }

    public static void ModalConfirm(Client player, string response)
    {
        if(response == "WEED_OFFER")
        {
            Client selling = player.GetData("offer_seller");
            if (Main.IsPlayerLogged(selling) && selling.GetData("status") == true)
            {
                int index = Inventory.GetInventoryIndexFromName(selling, "Baseado");

                if (selling.GetData("inventory_item_" + index + "_amount") >= player.GetData("offer_amount"))
                {
                    if(Main.GetPlayerMoney(player) < player.GetData("offer_price"))
                    {
                        Main.SendErrorMessage(player, "O vendedor está vendendo por "+ player.GetData("offer_price") + ". Você não tem este dinheiro em mãos.");
                        return;
                    }

                    Inventory.RemoveItemByType(selling, 12, player.GetData("offer_amount"));
                    Inventory.GiveItemToInventory(player, 12, player.GetData("offer_amount"));

                    Main.SendSuccessMessage(player, "Você comprou " + player.GetData("offer_amount") + " maconha por " + player.GetData("offer_price") + " de " + AccountManage.GetCharacterName(selling) +".");
                    Main.SendSuccessMessage(selling, "Você vendeu " + player.GetData("offer_amount") + " maconha por " + player.GetData("offer_price") + " para " + AccountManage.GetCharacterName(player) +".");

                    Main.GivePlayerMoney(player, -player.GetData("offer_price"));
                    Main.GivePlayerMoney(selling, player.GetData("offer_price"));

                }
            }
            else
            {
                Main.SendErrorMessage(player, "Quem lhe enviou a oferta não está mais conectado.");
            }
            player.SetData("offer_price", 0);
            player.SetData("offer_amount", 0);
            player.SetData("offer", false);
        }
        else if (response == "HEROIN_OFFER")
        {
            Client selling = player.GetData("offer_seller");
            if (Main.IsPlayerLogged(selling) && selling.GetData("status") == true)
            {
                int index = Inventory.GetInventoryIndexFromName(selling, "Cocaina");

                if (selling.GetData("inventory_item_" + index + "_amount") >= player.GetData("offer_amount"))
                {
                    if (Main.GetPlayerMoney(player) < player.GetData("offer_price"))
                    {
                        Main.SendErrorMessage(player, "O vendedor está vendendo por " + player.GetData("offer_price") + ". Você não tem este dinheiro em mãos.");
                        return;
                    }

                    Inventory.RemoveItemByType(selling, 16, player.GetData("offer_amount"));
                    Inventory.GiveItemToInventory(player, 16, player.GetData("offer_amount"));

                    Main.SendSuccessMessage(player, "Você comprou " + player.GetData("offer_amount") + " cocaina por " + player.GetData("offer_price") + " de " + AccountManage.GetCharacterName(selling) + ".");
                    Main.SendSuccessMessage(selling, "Você vendeu " + player.GetData("offer_amount") + " cocaina por " + player.GetData("offer_price") + " para " + AccountManage.GetCharacterName(player) + ".");

                    Main.GivePlayerMoney(player, -player.GetData("offer_price"));
                    Main.GivePlayerMoney(selling, player.GetData("offer_price"));

                }
            }
            else
            {
                Main.SendErrorMessage(player, "Quem lhe enviou a oferta não está mais conectado.");
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

