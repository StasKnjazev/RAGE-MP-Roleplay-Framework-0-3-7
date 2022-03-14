using GTANetworkAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class Hotel : Script
{
    public static int HotelRent = 120;
    public static int action { get; set; }
    public static Vector3 coords { get; set; }
    public static int id { get; set; }

    public static List<dynamic> HotelEnters = new List<dynamic>();
    private static Vector3 InteriorDoor = new Vector3(151.21239, -1007.0881, -98.999985 - 0.8);

    public static void HotelsInit()
    {
        HotelEnters.Add(new { id = 1, coords = new Vector3(416.20956, -1108.3958, 30.05602), action = 1 });
        HotelEnters.Add(new { id = 2, coords = new Vector3(-878.30664, -2178.9768, 9.809033), action = 2 });
        HotelEnters.Add(new { id = 3, coords = new Vector3(436.21335, 216.62991, 103.16568), action = 3 });
        HotelEnters.Add(new { id = 4, coords = new Vector3(-1274.6196, 314.02087, 65.511856), action = 4 });

        
    }
    [ServerEvent(Event.ResourceStart)]
    public void Event_ResourceStart()
    {
        try
        {
        }
        catch (Exception e) {
            NAPI.Util.ConsoleOutput("[EXCEPTION Hotel ResourceStart:] " + e.Message);
        }
    }

    public static void Event_InteractPressed(Client player)
    {
        switch (player.GetData("character_hotel"))
        {
            case 48:

            case 0:
                NAPI.Entity.SetEntityPosition(player, HotelEnters[player.GetData("InsideHotelID")] + new Vector3(0, 0, 1.5));
                player.SetData("InsideHotelID", -1);
                NAPI.ColShape.DeleteColShape(player.GetData("InsideHotel_ColShape"));
                NAPI.Entity.DeleteEntity(player.GetData("InsideHotel_Marker"));
                //Dimensions.DismissPrivateDimension(player);
                NAPI.Entity.SetEntityDimension(player, 0);
                return;
        }
    }
    
    public static void KeyPressE(Client player)
    {
        //NAPI.Util.ConsoleOutput("DEBUG ::: Hotels: " + HotelEnters[id].action + "");
        if (Main.IsInRangeOfPoint(player.Position, HotelEnters[action].coords, 1.0f))
        {
            if (player.GetData("character_hotel") == -1)
                OpenHotelBuyMenu(player);
            else
                SendToRoom(player);
            return;
        }
    }

public static void Event_OnPlayerDisconnected(Client player)
    {
        if (player.HasData("HOTELCAR"))
            NAPI.Entity.DeleteEntity(player.GetData("HOTELCAR"));
    }

    public static void SendToRoom(Client player)
    {
        if (!player.GetData("status") || player.GetData("character_hotel") == -1) return;

        Random rnd = new Random();
        uint  dim = (uint)rnd.Next(1000, 100000);

        NAPI.Entity.SetEntityPosition(player, InteriorDoor + new Vector3(0, 0, 1.12));
        NAPI.Entity.SetEntityDimension(player, dim);
        player.SetData("char_dimension", dim);
        player.SetData("InsideHotelID", player.GetData("character_hotel"));
        var colShape = NAPI.ColShape.CreateCylinderColShape(InteriorDoor, 1.5f, 3, dim);
        colShape.OnEntityEnterColShape += (s,e) =>
        {
            OpenHotelManageMenu(player);
        };
        colShape.OnEntityExitColShape += (s, e) =>
        {
            OpenHotelManageMenu(player);
        };
        player.SetData("InsideHotel_ColShape", colShape);
        var marker = NAPI.Marker.CreateMarker(1, InteriorDoor, new Vector3(), new Vector3(), 1, new Color(255, 255, 255), false, dim);
        player.SetData("InsideHotel_Marker", marker);
    }

    public static void ExtendHotelRent(Client player, int hours)
    {
        if (!player.GetData("status")) return;

        if (player.GetData("character_hotel") == -1)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Sie sind in keinem Hotel untergebracht");
            return;
        }

        if (player.GetData("character_hotel_left") + hours > 24)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Die Miete kann nur für 24 Stunden bezahlt werden");
            return;
        }

        if (Main.GetPlayerBank(player) < (HotelRent * hours))
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Unzureichendes Geld");
            return;
        }

        player.SetData("character_hotel_left", player.GetData("character_hotel_left") + hours);
        Main.GivePlayerMoneyBank(player, (HotelRent * hours));
        NAPI.Notification.SendNotificationToPlayer(player, "Wenn Sie den Vertrag um {hours} Stunden nicht verlängert haben, dann werden Sie in "+player.GetData("character_hotel_left")+" Stunden gekündigt!");
    }

    public static void MoveOutPlayer(Client player)
    {
        if (player.GetData("InsideHotelID") != -1)
            NAPI.Entity.SetEntityPosition(player, HotelEnters[id].coords + new Vector3(0, 0, 1.12));

        if (!player.GetData("status")) return;


        player.SetData("character_hotel", -1);
        player.SetData("character_hotel_left", 0);
        player.SetData("char_dimension", 0);
        player.SetData("InsideHotelID", -1);
        player.Dimension = 0;
        AccountManage.SaveCharacter(player);

        if (player.HasData("HOTELCAR"))
        {
            NAPI.Entity.DeleteEntity(player.GetData("HOTELCAR"));
            player.ResetData("HOTELCAR");
        }
    }

    public static void OpenHotelBuyMenu(Client player)
    {
        List<dynamic> menu_item_list = new List<dynamic>();

        menu_item_list.Add(new { Type = 1, Name = "~g~Mieten", Description = "Das Mietgeld wird bei jeder Zahlung nur dann abgehoben, wenn Sie im Staat sind.", RightLabel = "$" + HotelRent + " pro Stunde" });
        InteractMenu.CreateMenu(player, "HOTEL_BUY", "Hotel", "Hotel Options", false, NAPI.Util.ToJson(menu_item_list), false);
    }

    public static void SelectMenuResponse(Client player, String callbackId, int selectedIndex, String objectName, String valueList)
    {
        if (callbackId == "HOTEL_BUY")
        {

            switch (selectedIndex)
            {
                case 0:
                    {

                        if (Main.GetPlayerMoney(player) < HotelRent)
                        {
                            NAPI.Notification.SendNotificationToPlayer(player, "Unzureichendes Geld");
                            return;
                        }
                        Main.GivePlayerMoney(player, -HotelRent);


                        player.SetData("character_hotel", HotelEnters[id].action);
                        player.SetData("character_hotel_left", HotelEnters[id].action);
                        player.SetData("InsideHotelID", HotelEnters[id].action);
                        AccountManage.SaveCharacter(player);

                        NAPI.Notification.SendNotificationToPlayer(player, "Sie haben ein Zimmer im Hotel für 1 Stunde gemietet.");
                        SendToRoom(player);
                        break;
                    }
            }
        }
        else if (callbackId == "HOTEL_MANAGE")
        {
            switch (selectedIndex)
            {
                case 0:
                    {

                        InteractMenu.User_Input(player, "extend_hotel_rent", $"Du hast noch ({HotelRent}$/ч)", "Wieviel Stunden?", "number");
                        break;
                    }
                case 1:
                    {

                        MoveOutPlayer(player);
                        NAPI.Notification.SendNotificationToPlayer(player, "Sie haben das Hotel verlassen.");
                        break;
                    }
            }
        }
    }

   public static void OpenHotelManageMenu(Client player)
    {

        List<dynamic> menu_item_list = new List<dynamic>();
        menu_item_list.Add(new { Type = 1, Name = "Vertrag verlängern", Description = "", RightLabel = "" });
        menu_item_list.Add(new { Type = 1, Name = "Beenden", Description = "", RightLabel = "" });
        InteractMenu.CreateMenu(player, "HOTEL_MANAGE", "Hotel", $"Du hast noch {player.GetData("character_hotel_left")}", false, NAPI.Util.ToJson(menu_item_list), false);
    }
    
}
