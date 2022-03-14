using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;

using Newtonsoft.Json;

class Barber : Script
{


    public static List<string> hair_style_female = new List<string>();
    public static List<string> hair_style_male = new List<string>();
    public static List<string> eye_colors = new List<string>();
    public static List<string> dad = new List<string>();
    public static List<string> mom = new List<string>();
    public static List<string> shape_mix_list = new List<string>();

    public static int handelskammersteuer { get; set; }

    public Barber()
    {
        hair_style_male.Add("0");
        hair_style_male.Add("1");
        hair_style_male.Add("2");
        hair_style_male.Add("3");
        hair_style_male.Add("4");
        hair_style_male.Add("5");
        hair_style_male.Add("6");
        hair_style_male.Add("7");
        hair_style_male.Add("8");
        hair_style_male.Add("9");
        hair_style_male.Add("10");
        hair_style_male.Add("11");
        hair_style_male.Add("12");
        hair_style_male.Add("13");
        hair_style_male.Add("14");
        hair_style_male.Add("15");
        hair_style_male.Add("16");
        hair_style_male.Add("17");
        hair_style_male.Add("18");
        hair_style_male.Add("19");
        hair_style_male.Add("20");
        hair_style_male.Add("21");
        hair_style_male.Add("22");
        hair_style_male.Add("24");
        hair_style_male.Add("25");
        hair_style_male.Add("26");
        hair_style_male.Add("27");
        hair_style_male.Add("28");
        hair_style_male.Add("29");
        hair_style_male.Add("30");
        hair_style_male.Add("31");
        hair_style_male.Add("32");
        hair_style_male.Add("33");
        hair_style_male.Add("34");
        hair_style_male.Add("35");
        hair_style_male.Add("36");
        hair_style_male.Add("37");
        hair_style_male.Add("38");
        hair_style_male.Add("39");
        hair_style_male.Add("40");
        hair_style_male.Add("41");
        hair_style_male.Add("42");
        hair_style_male.Add("43");
        hair_style_male.Add("44");
        hair_style_male.Add("45");
        hair_style_male.Add("46");
        hair_style_male.Add("47");
        hair_style_male.Add("48");
        hair_style_male.Add("49");
        hair_style_male.Add("50");
        hair_style_male.Add("51");
        hair_style_male.Add("52");
        hair_style_male.Add("53");
        hair_style_male.Add("54");
        hair_style_male.Add("55");
        hair_style_male.Add("56");
        hair_style_male.Add("57");
        hair_style_male.Add("58");
        hair_style_male.Add("59");
        hair_style_male.Add("60");
        hair_style_male.Add("61");
        hair_style_male.Add("62");
        hair_style_male.Add("63");
        hair_style_male.Add("64");
        hair_style_male.Add("65");
        hair_style_male.Add("66");
        hair_style_male.Add("67");
        hair_style_male.Add("68");
        hair_style_male.Add("69");
        hair_style_male.Add("70");
        hair_style_male.Add("71");
        hair_style_male.Add("72");
        hair_style_male.Add("73");


        hair_style_female.Add("0");
        hair_style_female.Add("1");
        hair_style_female.Add("2");
        hair_style_female.Add("3");
        hair_style_female.Add("4");
        hair_style_female.Add("5");
        hair_style_female.Add("6");
        hair_style_female.Add("7");
        hair_style_female.Add("8");
        hair_style_female.Add("9");
        hair_style_female.Add("10");
        hair_style_female.Add("11");
        hair_style_female.Add("12");
        hair_style_female.Add("13");
        hair_style_female.Add("14");
        hair_style_female.Add("15");
        hair_style_female.Add("16");
        hair_style_female.Add("17");
        hair_style_female.Add("18");
        hair_style_female.Add("19");
        hair_style_female.Add("20");
        hair_style_female.Add("21");
        hair_style_female.Add("22");
        hair_style_female.Add("23");
        hair_style_female.Add("25");
        hair_style_female.Add("26");
        hair_style_female.Add("27");
        hair_style_female.Add("28");
        hair_style_female.Add("29");
        hair_style_female.Add("30");
        hair_style_female.Add("31");
        hair_style_female.Add("32");
        hair_style_female.Add("33");
        hair_style_female.Add("34");
        hair_style_female.Add("35");
        hair_style_female.Add("36");
        hair_style_female.Add("37");
        hair_style_female.Add("38");
        hair_style_female.Add("39");
        hair_style_female.Add("40");
        hair_style_female.Add("41");
        hair_style_female.Add("42");
        hair_style_female.Add("43");
        hair_style_female.Add("44");
        hair_style_female.Add("45");
        hair_style_female.Add("46");
        hair_style_female.Add("47");
        hair_style_female.Add("48");
        hair_style_female.Add("49");
        hair_style_female.Add("50");
        hair_style_female.Add("51");
        hair_style_female.Add("52");
        hair_style_female.Add("53");
        hair_style_female.Add("54");
        hair_style_female.Add("55");
        hair_style_female.Add("56");
        hair_style_female.Add("57");
        hair_style_female.Add("58");
        hair_style_female.Add("59");
        hair_style_female.Add("60");
        hair_style_female.Add("61");
        hair_style_female.Add("62");
        hair_style_female.Add("63");
        hair_style_female.Add("64");
        hair_style_female.Add("65");
        hair_style_female.Add("66");
        hair_style_female.Add("67");
        hair_style_female.Add("68");
        hair_style_female.Add("69");
        hair_style_female.Add("70");
        hair_style_female.Add("71");
        hair_style_female.Add("72");
        hair_style_female.Add("73");
        hair_style_female.Add("74");
        hair_style_female.Add("75");
        hair_style_female.Add("76");
        hair_style_female.Add("77");
        hair_style_female.Add("78");


        //
        eye_colors.Add("Green");
        eye_colors.Add("Emerald");
        eye_colors.Add("Light Blue");
        eye_colors.Add("Ocean Blue");
        eye_colors.Add("Light Brown");
        eye_colors.Add("Dark Brown");
        eye_colors.Add("Hazel");
        eye_colors.Add("Dark Gray");
        eye_colors.Add("Light Gray");
        eye_colors.Add("Pink");
        eye_colors.Add("Yellow");
        eye_colors.Add("Blackout");
        eye_colors.Add("Shades of Gray");
        eye_colors.Add("Tequila Sunrise");
        eye_colors.Add("Atomic");
        eye_colors.Add("Warp");
        eye_colors.Add("ECola");
        eye_colors.Add("Space Ranger");
        eye_colors.Add("Ying Yang");
        eye_colors.Add("Bullseye");
        eye_colors.Add("Lizard");
        eye_colors.Add("Dragon");
        eye_colors.Add("Extra Terrestrial");
        eye_colors.Add("Goat");
        eye_colors.Add("Smiley");
        eye_colors.Add("Possessed");
        eye_colors.Add("Demon");
        eye_colors.Add("Infected");
        eye_colors.Add("Alien");
        eye_colors.Add("Undead");
        eye_colors.Add("Zombie");

    }



    public static void DisplayMenu(Client player)
    {
        var business_id = Business.GetPlayerInBusinessInType(player, 10);
        if (business_id == -1)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Du bist nicht in einem Friseursalon.");
            return;
        }

        player.SetData("barber_hair", CharCreator.CharCreator.CustomPlayerData[player.Handle].Hair.Hair);
        player.SetData("barber_hair_color_1", CharCreator.CharCreator.CustomPlayerData[player.Handle].Hair.Color);
        player.SetData("barber_hair_color_2", CharCreator.CharCreator.CustomPlayerData[player.Handle].Hair.HighlightColor);

        player.SetData("barber_beard", CharCreator.CharCreator.CustomPlayerData[player.Handle].Appearance[1].Value);
        player.SetData("barber_beard_color", CharCreator.CharCreator.CustomPlayerData[player.Handle].Appearance[1].Color);

        player.SetData("barber_eyebrown", CharCreator.CharCreator.CustomPlayerData[player.Handle].Appearance[2].Color);
        player.SetData("barber_eyebrown_color", CharCreator.CharCreator.CustomPlayerData[player.Handle].Appearance[2].Color);

        player.SetData("barber_chesthair", CharCreator.CharCreator.CustomPlayerData[player.Handle].Appearance[10].Color);
        player.SetData("barber_chesthair_color", CharCreator.CharCreator.CustomPlayerData[player.Handle].Appearance[10].Color);

        player.SetData("barber_eyes", CharCreator.CharCreator.CustomPlayerData[player.Handle].EyeColor);

        player.SetData("barber_makeup", CharCreator.CharCreator.CustomPlayerData[player.Handle].Appearance[4].Value);
        player.SetData("barber_blush", CharCreator.CharCreator.CustomPlayerData[player.Handle].Appearance[5].Value);
        player.SetData("barber_lipstick", CharCreator.CharCreator.CustomPlayerData[player.Handle].Appearance[8].Value);

        List<dynamic> menu_item_list = new List<dynamic>();

        menu_item_list.Add(new { Type = 1, Name = "Frisur", Description = "", RightLabel = "" });
        menu_item_list.Add(new { Type = 1, Name = "Bart", Description = "", RightLabel = "" });
        menu_item_list.Add(new { Type = 1, Name = "Augenbrauen", Description = "", RightLabel = "" });
        menu_item_list.Add(new { Type = 1, Name = "Augenfarbe", Description = "", RightLabel = "" });
        menu_item_list.Add(new { Type = 1, Name = "Haare auf der Brust", Description = "", RightLabel = "" });
        menu_item_list.Add(new { Type = 1, Name = "Makeup", Description = "", RightLabel = "" });
        menu_item_list.Add(new { Type = 1, Name = "Blush", Description = "", RightLabel = "" });
        menu_item_list.Add(new { Type = 1, Name = "Lippenstift", Description = "", RightLabel = "" });

        InteractMenu.CreateMenu(player, "BARBER_SHOP", "", "~g~" + Business.business_list[business_id].business_Name, true, JsonConvert.SerializeObject(menu_item_list), false, BackgroundSprite: "shopui_title_barber3");
    }



    public static void SelectMenuResponse(Client player, String callbackId, int selectedIndex, String objectName, String valueList)
    {
        if (callbackId == "BARBER_SHOP")
        {
            var business_id = Business.GetPlayerInBusinessInType(player, 10);
            if (business_id == -1)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Du bist nicht in einem Friseursalon.");
                return;
            }

            List<dynamic> menu_item_list = new List<dynamic>();
            List<string> model_list = new List<string>();
            List<string> color_list = new List<string>();

            switch (selectedIndex)
            {
                case 0:
                    {


                        if (NAPI.Data.GetEntitySharedData(player, "CHARACTER_ONLINE_GENRE") == 1)
                        {
                            for (int i = 0; i < hair_style_female.Count; i++)
                            {
                                model_list.Add(hair_style_female[i]);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < hair_style_male.Count; i++)
                            {
                                model_list.Add(hair_style_male[i]);
                            }
                        }


                        for (int i = 0; i < 65; i++)
                        {
                            color_list.Add(i.ToString());
                        }


                        menu_item_list.Add(new { Type = 2, Name = "Frisur", Description = "", List = model_list, StartIndex = 0 });
                        menu_item_list.Add(new { Type = 2, Name = "Haarfarbe", Description = "", List = color_list, StartIndex = 0 });
                        menu_item_list.Add(new { Type = 2, Name = "Hightlights", Description = "", List = color_list, StartIndex = 0 });
                        menu_item_list.Add(new { Type = 1, Name = "Jetzt kaufen", Description = "", RightLabel = "$250", Color = "Lime", HighlightColor = "White" });

                        InteractMenu.CreateMenu(player, "HAIR_MENU", "", "~g~" + Business.business_list[business_id].business_Name, true, JsonConvert.SerializeObject(menu_item_list), false, BackgroundSprite: "shopui_title_barber3");
                        break;
                    }
                case 1:
                    {


                        for (int i = 0; i < 28; i++)
                        {
                            model_list.Add(i.ToString());
                        }


                        for (int i = 0; i < 65; i++)
                        {
                            color_list.Add(i.ToString());
                        }


                        menu_item_list.Add(new { Type = 2, Name = "Bartart", Description = "", List = model_list, StartIndex = 0 });
                        menu_item_list.Add(new { Type = 2, Name = "Bartfarbe", Description = "", List = color_list, StartIndex = 0 });
                        menu_item_list.Add(new { Type = 1, Name = "Jetzt kaufen", Description = "", RightLabel = "$250", Color = "Lime", HighlightColor = "White" });

                        InteractMenu.CreateMenu(player, "FACIALHAIR_MENU", "", "~g~" + Business.business_list[business_id].business_Name, true, JsonConvert.SerializeObject(menu_item_list), false, BackgroundSprite: "shopui_title_barber3");
                        break;
                    }
                case 2:
                    {
                        for (int i = 0; i < 33; i++)
                        {
                            model_list.Add(i.ToString());
                        }


                        for (int i = 0; i < 65; i++)
                        {
                            color_list.Add(i.ToString());
                        }


                        menu_item_list.Add(new { Type = 2, Name = "Schmincke-Maske", Description = "", List = model_list, StartIndex = 0 });
                        menu_item_list.Add(new { Type = 2, Name = "Schminckfarbe", Description = "", List = color_list, StartIndex = 0 });
                        menu_item_list.Add(new { Type = 1, Name = "Jetzt kaufen", Description = "", RightLabel = "$250", Color = "Lime", HighlightColor = "White" });

                        InteractMenu.CreateMenu(player, "EYEBROWS_MENU", "", "~g~" + Business.business_list[business_id].business_Name, true, JsonConvert.SerializeObject(menu_item_list), false, BackgroundSprite: "shopui_title_barber3");
                        break;
                    }
                case 3:
                    {
                        for (int i = 0; i < 14; i++)
                        {
                            model_list.Add(eye_colors[i]);
                        }



                        menu_item_list.Add(new { Type = 2, Name = "Augenfarbe braun", Description = "", List = model_list, StartIndex = 0 });

                        InteractMenu.CreateMenu(player, "EYES_MENU", "", "~g~" + Business.business_list[business_id].business_Name, true, JsonConvert.SerializeObject(menu_item_list), false, BackgroundSprite: "shopui_title_barber3");
                        break;
                    }
                case 4:
                    {
                        for (int i = 0; i < 16; i++)
                        {
                            model_list.Add(i.ToString());
                        }


                        for (int i = 0; i < 65; i++)
                        {
                            color_list.Add(i.ToString());
                        }


                        menu_item_list.Add(new { Type = 2, Name = "Brust-Frisur", Description = "", List = model_list, StartIndex = 0 });
                        menu_item_list.Add(new { Type = 2, Name = "Brusthaarfarbe", Description = "", List = color_list, StartIndex = 0 });
                        menu_item_list.Add(new { Type = 1, Name = "Jetzt kaufen", Description = "", RightLabel = "$250", Color = "Lime", HighlightColor = "White" });

                        InteractMenu.CreateMenu(player, "CHESTHAIR_MENU", "", "~g~" + Business.business_list[business_id].business_Name, true, JsonConvert.SerializeObject(menu_item_list), false, BackgroundSprite: "shopui_title_barber3");
                        break;
                    }
                case 5:
                    {
                        for (int i = 0; i < 74; i++)
                        {
                            model_list.Add(i.ToString());
                        }


                        menu_item_list.Add(new { Type = 2, Name = "Makeup-Stil", Description = "", List = model_list, StartIndex = 0 });
                        menu_item_list.Add(new { Type = 1, Name = "Jetzt kaufen", Description = "", RightLabel = "$250", Color = "Lime", HighlightColor = "White" });

                        InteractMenu.CreateMenu(player, "MAKEUP_MENU", "", "~g~" + Business.business_list[business_id].business_Name, true, JsonConvert.SerializeObject(menu_item_list), false, BackgroundSprite: "shopui_title_barber3");
                        break;
                    }
                case 6:
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            model_list.Add(i.ToString());
                        }


                        menu_item_list.Add(new { Type = 2, Name = "Blush Style", Description = "", List = model_list, StartIndex = 0 });
                        menu_item_list.Add(new { Type = 1, Name = "Jetzt kaufen", Description = "", RightLabel = "$250", Color = "Lime", HighlightColor = "White" });

                        InteractMenu.CreateMenu(player, "BLUSH_MENU", "", "~g~" + Business.business_list[business_id].business_Name, true, JsonConvert.SerializeObject(menu_item_list), false, BackgroundSprite: "shopui_title_barber3");
                        break;
                    }
                case 7:
                    {
                        for (int i = 0; i < 9; i++)
                        {
                            model_list.Add(i.ToString());
                        }


                        menu_item_list.Add(new { Type = 2, Name = "Blush Style", Description = "", List = model_list, StartIndex = 0 });
                        menu_item_list.Add(new { Type = 1, Name = "Jetzt kaufen", Description = "", RightLabel = "$250", Color = "Lime", HighlightColor = "White" });

                        InteractMenu.CreateMenu(player, "LIPSTICK_MENU", "", "~g~" + Business.business_list[business_id].business_Name, true, JsonConvert.SerializeObject(menu_item_list), false, BackgroundSprite: "shopui_title_barber3");
                        break;
                    }
            }
        }
        else if (callbackId == "HAIR_MENU")
        {
            BuyBarber(player, 0);
        }
        else if (callbackId == "FACIALHAIR_MENU")
        {
            BuyBarber(player, 1);
        }
        else if (callbackId == "EYEBROWS_MENU")
        {
            BuyBarber(player, 2);
        }
        else if (callbackId == "EYES_MENU")
        {
            BuyBarber(player, 3);
        }
        else if (callbackId == "CHESTHAIR_MENU")
        {
            BuyBarber(player, 4);
        }
        else if (callbackId == "MAKEUP_MENU")
        {
            BuyBarber(player, 5);
        }
        else if (callbackId == "BLUSH_MENU")
        {
            BuyBarber(player, 6);
        }
        else if (callbackId == "LIPSTICK_MENU")
        {
            BuyBarber(player, 7);
        }
    }

    public static void IndexChangeMenuResponse(Client player, String callbackId, int selectedIndex, String objectName, String valueList)
    {
    }

    public static void ListItemMenuResponse(Client player, String callbackId, int selectedIndex, String objectName, String valueList, int valueIndex)
    {
        if (callbackId == "HAIR_MENU")
        {
            if (selectedIndex == 0)
            {
                if (NAPI.Data.GetEntitySharedData(player, "CHARACTER_ONLINE_GENRE") == 1)
                {
                    player.SetData("barber_hair", Convert.ToByte(hair_style_female[valueIndex]));
                    player.SetClothes(2, Convert.ToByte(hair_style_female[valueIndex]), 0);

                }
                else
                {
                    player.SetData("barber_hair", Convert.ToByte(hair_style_male[valueIndex]));
                    player.SetClothes(2, Convert.ToByte(hair_style_male[valueIndex]), 0);
                }
            }
            else if (selectedIndex == 1)
            {
                int value = Convert.ToInt32(valueIndex);
                NAPI.Player.SetPlayerHairColor(player, (byte)value, (byte)player.GetData("barber_hair_color_2"));
                player.SetData("barber_hair_color_1", (byte)value);
            }
            else if (selectedIndex == 2)
            {
                int value = Convert.ToInt32(valueIndex);
                NAPI.Player.SetPlayerHairColor(player, (byte)player.GetData("barber_hair_color_1"), (byte)value);
                player.SetData("barber_hair_color_2", (byte)value);
            }
        }
        else if (callbackId == "FACIALHAIR_MENU")
        {
            if (selectedIndex == 0)
            {
                int value = Convert.ToInt32(valueIndex);
                HeadOverlay headoverlay2 = new HeadOverlay();
                int index = 1;
                if (value == 0) player.SetData("barber_beard", (byte)value);
                else player.SetData("barber_beard", (byte)value - 1);
                headoverlay2.Index = (byte)player.GetData("barber_beard");
                headoverlay2.Color = (byte)player.GetData("barber_beard_color");
                headoverlay2.Opacity = 255;
                NAPI.Player.SetPlayerHeadOverlay(player, index, headoverlay2);
            }
            else if (selectedIndex == 1)
            {
                int value = Convert.ToInt32(valueIndex);
                HeadOverlay headoverlay2 = new HeadOverlay();
                int index = 1;
                player.SetData("barber_beard_color", (byte)value);
                headoverlay2.Index = (byte)player.GetData("barber_beard");
                headoverlay2.Color = (byte)player.GetData("barber_beard_color");
                headoverlay2.Opacity = 255;
                NAPI.Player.SetPlayerHeadOverlay(player, index, headoverlay2);
            }
        }
        else if (callbackId == "EYEBROWS_MENU")
        {
            if (selectedIndex == 0)
            {
                int value = Convert.ToInt32(valueIndex);
                HeadOverlay headoverlay2 = new HeadOverlay();
                int index = 2;
                if (value == 0) player.SetData("barber_eyebrown", (byte)value);
                else player.SetData("barber_eyebrown", (byte)value - 1);
                headoverlay2.Index = (byte)player.GetData("barber_eyebrown");
                headoverlay2.Color = (byte)player.GetData("barber_eyebrown_color");
                headoverlay2.Opacity = 255;
                NAPI.Player.SetPlayerHeadOverlay(player, index, headoverlay2);
            }
            else if (selectedIndex == 1)
            {
                int value = Convert.ToInt32(valueIndex);
                HeadOverlay headoverlay2 = new HeadOverlay();
                int index = 2;
                player.SetData("barber_eyebrown_color", (byte)value);
                headoverlay2.Index = (byte)player.GetData("barber_eyebrown");
                headoverlay2.Color = (byte)player.GetData("barber_eyebrown_color");
                headoverlay2.Opacity = 255;
                NAPI.Player.SetPlayerHeadOverlay(player, index, headoverlay2);
            }
        }
        else if (callbackId == "EYES_MENU")
        {
            int value = Convert.ToInt32(valueIndex);
            NAPI.Player.SetPlayerEyeColor(player, (byte)value);
            player.SetData("barber_eyes", (byte)value);
        }
        else if (callbackId == "MAKEUP_MENU")
        {
            int value = Convert.ToInt32(valueIndex);
            HeadOverlay headoverlay2 = new HeadOverlay();
            int index = 4;
            player.SetData("barber_makeup", (byte)value);
            headoverlay2.Index = (byte)player.GetData("barber_makeup");
            headoverlay2.Color = 0;
            headoverlay2.Opacity = 255;
            NAPI.Player.SetPlayerHeadOverlay(player, index, headoverlay2);
        }
        else if (callbackId == "BLUSH_MENU")
        {

            int value = Convert.ToInt32(valueIndex);
            HeadOverlay headoverlay2 = new HeadOverlay();
            int index = 5;
            player.SetData("barber_blush", (byte)value);
            headoverlay2.Index = (byte)player.GetData("barber_blush");
            headoverlay2.Color = 0;
            headoverlay2.Opacity = 255;
            NAPI.Player.SetPlayerHeadOverlay(player, index, headoverlay2);
        }
        else if (callbackId == "LIPSTICK_MENU")
        {

            int value = Convert.ToInt32(valueIndex);
            HeadOverlay headoverlay2 = new HeadOverlay();
            int index = 8;
            player.SetData("barber_lipstick", (byte)value);
            headoverlay2.Index = (byte)player.GetData("barber_lipstick");
            headoverlay2.Color = 0;
            headoverlay2.Opacity = 255;
            NAPI.Player.SetPlayerHeadOverlay(player, index, headoverlay2);
        }
        else if (callbackId == "CHESTHAIR_MENU")
        {
            if (selectedIndex == 0)
            {
                int value = Convert.ToInt32(valueIndex);
                HeadOverlay headoverlay2 = new HeadOverlay();
                int index = 10;
                if (value == 0) player.SetData("barber_chesthair", (byte)value);
                else player.SetData("barber_chesthair", (byte)value - 1);
                headoverlay2.Index = (byte)player.GetData("barber_chesthair");
                headoverlay2.Color = (byte)player.GetData("barber_chesthair_color");
                headoverlay2.Opacity = 255;
                NAPI.Player.SetPlayerHeadOverlay(player, index, headoverlay2);
            }
            else if (selectedIndex == 1)
            {
                int value = Convert.ToInt32(valueIndex);
                HeadOverlay headoverlay2 = new HeadOverlay();
                int index = 10;
                player.SetData("barber_chesthair_color", (byte)value);
                headoverlay2.Index = (byte)player.GetData("barber_chesthair");
                headoverlay2.Color = (byte)player.GetData("barber_chesthair_color");
                headoverlay2.Opacity = 255;
                NAPI.Player.SetPlayerHeadOverlay(player, index, headoverlay2);
            }
        }
    }

    public static void OnMenuReturnClose(Client player, String callbackId)
    {
        if (callbackId == "HAIR_MENU" || callbackId == "BARBER_SHOP" || callbackId == "MAKEUP_MENU" || callbackId == "BLUSH_MENU" || callbackId == "LIPSTICK_MENU")
        {
            CharCreator.CharCreator.UpdateCharacter(player);
        }
    }

    [RemoteEvent("BuyBarber")]
    public static void BuyBarber(Client player, int menu_index)
    {
        Barber_Menu_Destroy(player);

        var business_id = Business.GetPlayerInBusinessInType(player, 10);
        if (business_id == -1)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Du bist nicht in einem Friseursalon..");
            return;
        }

        if (menu_index == 0) // Hair
        {
            int item_price = 250;

            if (Main.GetPlayerMoney(player) < item_price)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Sie haben nicht genug Geld, um diesen Artikel zu kaufen.");
                return;
            }

            if (Business.business_list[business_id].business_OwnerID != -1)
            {
                if (Business.business_list[business_id].business_Inventory > 0)
                {
                    Business.business_list[business_id].business_Safe += (item_price / 100 * 50);
                    Business.business_list[business_id].business_Inventory -= 1;
                    Business.SaveBusiness(business_id);
                    Business.UpdateBusinessLabel(business_id);
                }
                else
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "[" + Business.business_list[business_id].business_Name + "]:~w~ " + "Unser Unternehmen hat momentan nichts auf Lager, bitte kommen Sie später wieder!");
                    return;
                }
            }

            handelskammersteuer = Convert.ToInt32(System.Math.Ceiling(Convert.ToDouble(item_price) / Convert.ToDouble(100) * 19));
            NAPI.ClientEvent.TriggerClientEvent(player, "Notification.SendPictureNotification", "Barber Shop", "Einkauf", $" Kosten: ~g~$" + item_price + " \n ~w~Steuer: ~g~$~y~" + handelskammersteuer + "", "DIA_WILLY", true);
            Main.GivePlayerMoney(player, -item_price);

            CharCreator.CharCreator.CustomPlayerData[player.Handle].Hair.Hair = (byte)player.GetData("barber_hair");
            CharCreator.CharCreator.CustomPlayerData[player.Handle].Hair.Color = (byte)player.GetData("barber_hair_color_1");
            CharCreator.CharCreator.CustomPlayerData[player.Handle].Hair.HighlightColor = (byte)player.GetData("barber_hair_color_2");
            CharCreator.CharCreator.UpdateCharacter(player);
            CharCreator.CharCreator.SaveChar(player);
        }
        else if (menu_index == 1) // Beard
        {
            int item_price = 250;

            if (Main.GetPlayerMoney(player) < item_price)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Sie haben nicht genug Geld, um diesen Artikel zu kaufen.");
                return;
            }

            if (Business.business_list[business_id].business_OwnerID != -1)
            {
                if (Business.business_list[business_id].business_Inventory > 0)
                {
                    Business.business_list[business_id].business_Safe += (item_price / 100 * 50);
                    Business.business_list[business_id].business_Inventory -= 1;
                    Business.SaveBusiness(business_id);
                    Business.UpdateBusinessLabel(business_id);
                }
                else
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "[" + Business.business_list[business_id].business_Name + "]:~w~ " + "Unser Unternehmen hat momentan nichts auf Lager, bitte kommen Sie später wieder!");
                    return;
                }
            }

            handelskammersteuer = Convert.ToInt32(System.Math.Ceiling(Convert.ToDouble(item_price) / Convert.ToDouble(100) * 19));
            NAPI.ClientEvent.TriggerClientEvent(player, "Notification.SendPictureNotification", "Barber Shop", "Einkauf", $" Kosten: ~g~$" + item_price + " \n ~w~Steuer: ~g~$~y~" + handelskammersteuer + "", "DIA_WILLY", true);
            Main.GivePlayerMoney(player, -item_price);

            CharCreator.CharCreator.CustomPlayerData[player.Handle].Appearance[1].Value = (byte)player.GetData("barber_beard");
            CharCreator.CharCreator.CustomPlayerData[player.Handle].Appearance[1].Color = (byte)player.GetData("barber_beard_color");
            CharCreator.CharCreator.UpdateCharacter(player);
            CharCreator.CharCreator.SaveChar(player);
        }
        else if (menu_index == 2) // Sombra
        {
            int item_price = 250;

            if (Main.GetPlayerMoney(player) < item_price)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Sie haben nicht genug Geld, um diesen Artikel zu kaufen.");
                return;
            }

            if (Business.business_list[business_id].business_OwnerID != -1)
            {
                if (Business.business_list[business_id].business_Inventory > 0)
                {
                    Business.business_list[business_id].business_Safe += (item_price / 100 * 50);
                    Business.business_list[business_id].business_Inventory -= 1;
                    Business.SaveBusiness(business_id);
                    Business.UpdateBusinessLabel(business_id);
                }
                else
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "[" + Business.business_list[business_id].business_Name + "]:~w~ " + "Unser Unternehmen hat momentan nichts auf Lager, bitte kommen Sie später wieder!");
                    return;
                }
            }

            handelskammersteuer = Convert.ToInt32(System.Math.Ceiling(Convert.ToDouble(item_price) / Convert.ToDouble(100) * 19));
            NAPI.ClientEvent.TriggerClientEvent(player, "Notification.SendPictureNotification", "Barber Shop", "Einkauf", $" Kosten: ~g~$" + item_price + " \n ~w~Steuer: ~g~$~y~" + handelskammersteuer + "", "DIA_WILLY", true);
            Main.GivePlayerMoney(player, -item_price);

            CharCreator.CharCreator.CustomPlayerData[player.Handle].Appearance[2].Value = (byte)player.GetData("barber_beard");
            CharCreator.CharCreator.CustomPlayerData[player.Handle].Appearance[2].Color = (byte)player.GetData("barber_beard_color");
            CharCreator.CharCreator.UpdateCharacter(player);
            CharCreator.CharCreator.SaveChar(player);
        }
        else if (menu_index == 3) // Eyes
        {
            int item_price = 250;

            if (Main.GetPlayerMoney(player) < item_price)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Sie haben nicht genug Geld, um diesen Artikel zu kaufen.");
                return;
            }

            if (Business.business_list[business_id].business_OwnerID != -1)
            {
                if (Business.business_list[business_id].business_Inventory > 0)
                {
                    Business.business_list[business_id].business_Safe += (item_price / 100 * 50);
                    Business.business_list[business_id].business_Inventory -= 1;
                    Business.SaveBusiness(business_id);
                    Business.UpdateBusinessLabel(business_id);
                }
                else
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "[" + Business.business_list[business_id].business_Name + "]:~w~ " + "Unser Unternehmen hat momentan nichts auf Lager, bitte kommen Sie später wieder!");
                    return;
                }
            }

            handelskammersteuer = Convert.ToInt32(System.Math.Ceiling(Convert.ToDouble(item_price) / Convert.ToDouble(100) * 19));
            NAPI.ClientEvent.TriggerClientEvent(player, "Notification.SendPictureNotification", "Barber Shop", "Einkauf", $" Kosten: ~g~$" + item_price + " \n ~w~Steuer: ~g~$~y~" + handelskammersteuer + "", "DIA_WILLY", true);
            Main.GivePlayerMoney(player, -item_price);
            CharCreator.CharCreator.CustomPlayerData[player.Handle].EyeColor = (byte)player.GetData("barber_eyes");
            CharCreator.CharCreator.UpdateCharacter(player);
            CharCreator.CharCreator.SaveChar(player);
        }
        else if (menu_index == 4) // Cabelo Peito
        {
            int item_price = 250;

            if (Main.GetPlayerMoney(player) < item_price)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Sie haben nicht genug Geld, um diesen Artikel zu kaufen.");
                return;
            }

            if (Business.business_list[business_id].business_OwnerID != -1)
            {
                if (Business.business_list[business_id].business_Inventory > 0)
                {
                    Business.business_list[business_id].business_Safe += (item_price / 100 * 50);
                    Business.business_list[business_id].business_Inventory -= 1;
                    Business.SaveBusiness(business_id);
                    Business.UpdateBusinessLabel(business_id);
                }
                else
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "[" + Business.business_list[business_id].business_Name + "]:~w~ ");

                    return;
                }
            }

            handelskammersteuer = Convert.ToInt32(System.Math.Ceiling(Convert.ToDouble(item_price) / Convert.ToDouble(100) * 19));
            NAPI.ClientEvent.TriggerClientEvent(player, "Notification.SendPictureNotification", "Barber Shop", "Einkauf", $" Kosten: ~g~$" + item_price + " \n ~w~Steuer: ~g~$~y~" + handelskammersteuer + "", "DIA_WILLY", true);
            Main.GivePlayerMoney(player, -item_price);

            CharCreator.CharCreator.CustomPlayerData[player.Handle].Appearance[10].Value = (byte)player.GetData("barber_beard");
            CharCreator.CharCreator.CustomPlayerData[player.Handle].Appearance[10].Color = (byte)player.GetData("barber_beard_color");
            CharCreator.CharCreator.UpdateCharacter(player);
            CharCreator.CharCreator.SaveChar(player);
        }
        else if (menu_index == 5) // 
        {
            int item_price = 250;

            if (Main.GetPlayerMoney(player) < item_price)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Sie haben nicht genug Geld, um diesen Artikel zu kaufen.");
                return;
            }

            if (Business.business_list[business_id].business_OwnerID != -1)
            {
                if (Business.business_list[business_id].business_Inventory > 0)
                {
                    Business.business_list[business_id].business_Safe += (item_price / 100 * 50);
                    Business.business_list[business_id].business_Inventory -= 1;
                    Business.SaveBusiness(business_id);
                    Business.UpdateBusinessLabel(business_id);
                }
                else
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "[" + Business.business_list[business_id].business_Name + "]:~w~ " + "Unser Unternehmen hat momentan nichts auf Lager, bitte kommen Sie später wieder!");

                    return;
                }
            }

            handelskammersteuer = Convert.ToInt32(System.Math.Ceiling(Convert.ToDouble(item_price) / Convert.ToDouble(100) * 19));
            NAPI.ClientEvent.TriggerClientEvent(player, "Notification.SendPictureNotification", "Barber Shop", "Einkauf", $" Kosten: ~g~$" + item_price + " \n ~w~Steuer: ~g~$~y~" + handelskammersteuer + "", "DIA_WILLY", true);
            Main.GivePlayerMoney(player, -item_price);

            CharCreator.CharCreator.CustomPlayerData[player.Handle].Appearance[4].Value = (byte)player.GetData("barber_makeup");
            CharCreator.CharCreator.CustomPlayerData[player.Handle].Appearance[4].Color = 0;
            CharCreator.CharCreator.UpdateCharacter(player);
            CharCreator.CharCreator.SaveChar(player);
        }
        else if (menu_index == 6) // 
        {
            int item_price = 250;

            if (Main.GetPlayerMoney(player) < item_price)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Sie haben nicht genug Geld, um diesen Artikel zu kaufen.");
                return;
            }

            if (Business.business_list[business_id].business_OwnerID != -1)
            {
                if (Business.business_list[business_id].business_Inventory > 0)
                {
                    Business.business_list[business_id].business_Safe += (item_price / 100 * 50);
                    Business.business_list[business_id].business_Inventory -= 1;
                    Business.SaveBusiness(business_id);
                    Business.UpdateBusinessLabel(business_id);
                }
                else
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "[" + Business.business_list[business_id].business_Name + "]:~w~ " + "Unser Unternehmen hat momentan nichts auf Lager, bitte kommen Sie später wieder!");

                    return;
                }
            }

            handelskammersteuer = Convert.ToInt32(System.Math.Ceiling(Convert.ToDouble(item_price) / Convert.ToDouble(100) * 19));
            NAPI.ClientEvent.TriggerClientEvent(player, "Notification.SendPictureNotification", "Barber Shop", "Einkauf", $" Kosten: ~g~$" + item_price + " \n ~w~Steuer: ~g~$~y~" + handelskammersteuer + "", "DIA_WILLY", true);
            Main.GivePlayerMoney(player, -item_price);

            CharCreator.CharCreator.CustomPlayerData[player.Handle].Appearance[5].Value = (byte)player.GetData("barber_blush");
            CharCreator.CharCreator.CustomPlayerData[player.Handle].Appearance[5].Color = 0;
            CharCreator.CharCreator.UpdateCharacter(player);
            CharCreator.CharCreator.SaveChar(player);
        }
        else if (menu_index == 7) // 
        {
            int item_price = 250;

            if (Main.GetPlayerMoney(player) < item_price)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Sie haben nicht genug Geld, um diesen Artikel zu kaufen.");
                return;
            }

            if (Business.business_list[business_id].business_OwnerID != -1)
            {
                if (Business.business_list[business_id].business_Inventory > 0)
                {
                    Business.business_list[business_id].business_Safe += (item_price / 100 * 50);
                    Business.business_list[business_id].business_Inventory -= 1;
                    Business.SaveBusiness(business_id);
                    Business.UpdateBusinessLabel(business_id);
                }
                else
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "[" + Business.business_list[business_id].business_Name + "]:~w~ " + "Unser Unternehmen hat momentan nichts auf Lager, bitte kommen Sie später wieder!");

                    return;
                }
            }

            handelskammersteuer = Convert.ToInt32(System.Math.Ceiling(Convert.ToDouble(item_price) / Convert.ToDouble(100) * 19));
            NAPI.ClientEvent.TriggerClientEvent(player, "Notification.SendPictureNotification", "Barber Shop", "Einkauf", $" Kosten: ~g~$" + item_price + " \n ~w~Steuer: ~g~$~y~" + handelskammersteuer + "", "DIA_WILLY", true);
            Main.GivePlayerMoney(player, -item_price);

            CharCreator.CharCreator.CustomPlayerData[player.Handle].Appearance[8].Value = (byte)player.GetData("barber_lipstick");
            CharCreator.CharCreator.CustomPlayerData[player.Handle].Appearance[8].Color = 0;
            CharCreator.CharCreator.UpdateCharacter(player);
            CharCreator.CharCreator.SaveChar(player);
        }
    }

    [RemoteEvent("Barber_Menu_Destroy")]
    public static void Barber_Menu_Destroy(Client player)
    {
        player.TriggerEvent("ps_DestroyCamera");
        player.TriggerEvent("Destroy_Character_Menu");
        CharCreator.CharCreator.UpdateCharacter(player);
    }

    [RemoteEvent("Barber_Update_Character")]
    public static void Barber_Update_Character(Client player)
    {
        CharCreator.CharCreator.UpdateCharacter(player);
    }


    [RemoteEvent("ClientOnRangeChangeBarber")]
    public static void ClientOnRangeChangeBarber(Client player, string response, string valueIndex)
    {
        if (response == "barber_range_hair")
        {
            int value = Convert.ToInt32(valueIndex);
            player.SetData("barber_hair", (byte)value);

            player.SetClothes(2, value, 0);
        }
        else if (response == "barber_range_hair_color_1")
        {
            int value = Convert.ToInt32(valueIndex);
            NAPI.Player.SetPlayerHairColor(player, (byte)value, (byte)player.GetData("barber_hair_color_2"));
            player.SetData("barber_hair_color_1", (byte)value);
        }
        else if (response == "barber_range_hair_color_2")
        {
            int value = Convert.ToInt32(valueIndex);
            NAPI.Player.SetPlayerHairColor(player, (byte)player.GetData("barber_hair_color_1"), (byte)value);
            player.SetData("barber_hair_color_2", (byte)value);
        }
        else if (response == "barber_range_beard")
        {
            int value = Convert.ToInt32(valueIndex);
            HeadOverlay headoverlay2 = new HeadOverlay();
            int index = 1;
            if (value == 0) player.SetData("barber_beard", (byte)value);
            else player.SetData("barber_beard", (byte)value - 1);
            headoverlay2.Index = (byte)player.GetData("barber_beard");
            headoverlay2.Color = (byte)player.GetData("barber_beard_color");
            headoverlay2.Opacity = 255;
            NAPI.Player.SetPlayerHeadOverlay(player, index, headoverlay2);

        }
        else if (response == "barber_range_beard_color")
        {
            int value = Convert.ToInt32(valueIndex);
            HeadOverlay headoverlay2 = new HeadOverlay();
            int index = 1;
            player.SetData("barber_beard_color", (byte)value);
            headoverlay2.Index = (byte)player.GetData("barber_beard");
            headoverlay2.Color = (byte)player.GetData("barber_beard_color");
            headoverlay2.Opacity = 255;
            NAPI.Player.SetPlayerHeadOverlay(player, index, headoverlay2);
        }
        else if (response == "barber_range_eyebrown")
        {
            int value = Convert.ToInt32(valueIndex);
            HeadOverlay headoverlay2 = new HeadOverlay();
            int index = 2;
            if (value == 0) player.SetData("barber_eyebrown", (byte)value);
            else player.SetData("barber_eyebrown", (byte)value - 1);
            headoverlay2.Index = (byte)player.GetData("barber_eyebrown");
            headoverlay2.Color = (byte)player.GetData("barber_eyebrown_color");
            headoverlay2.Opacity = 255;
            NAPI.Player.SetPlayerHeadOverlay(player, index, headoverlay2);
        }
        else if (response == "barber_range_eyebrown_color")
        {
            int value = Convert.ToInt32(valueIndex);
            HeadOverlay headoverlay2 = new HeadOverlay();
            int index = 2;
            player.SetData("barber_eyebrown_color", (byte)value);
            headoverlay2.Index = (byte)player.GetData("barber_eyebrown");
            headoverlay2.Color = (byte)player.GetData("barber_eyebrown_color");
            headoverlay2.Opacity = 255;
            NAPI.Player.SetPlayerHeadOverlay(player, index, headoverlay2);
        }
        else if (response == "barber_range_eyes")
        {
            int value = Convert.ToInt32(valueIndex);
            NAPI.Player.SetPlayerEyeColor(player, (byte)value);
            player.SetData("barber_eyes", (byte)value);
        }
        else if (response == "barber_range_chesthair")
        {
            int value = Convert.ToInt32(valueIndex);
            HeadOverlay headoverlay2 = new HeadOverlay();
            int index = 10;
            if (value == 0) player.SetData("barber_chesthair", (byte)value);
            else player.SetData("barber_chesthair", (byte)value - 1);
            headoverlay2.Index = (byte)player.GetData("barber_chesthair");
            headoverlay2.Color = (byte)player.GetData("barber_chesthair_color");
            headoverlay2.Opacity = 255;
            NAPI.Player.SetPlayerHeadOverlay(player, index, headoverlay2);
        }
        else if (response == "barber_range_chesthair_color")
        {
            int value = Convert.ToInt32(valueIndex);
            HeadOverlay headoverlay2 = new HeadOverlay();
            int index = 10;
            player.SetData("barber_chesthair_color", (byte)value);
            headoverlay2.Index = (byte)player.GetData("barber_chesthair");
            headoverlay2.Color = (byte)player.GetData("barber_chesthair_color");
            headoverlay2.Opacity = 255;
            NAPI.Player.SetPlayerHeadOverlay(player, index, headoverlay2);
        }
    }

}

