using System;
using System.Collections.Generic;
using GTANetworkAPI;
using Newtonsoft.Json;
using static Services;
using DerStr1k3r.Core;
using DerStr1k3r.SDK;

/// <summary>
/// Class for managing weather
/// </summary>
class ATMSystem : Script
{
    public static int SETTINGS_COPS_NEEDED = 2;
    public static int SETTINGS_MEMBERS_NEEDED = 0;
    public static List<dynamic> atms = new List<dynamic>();
    public static List<TimerEx> player_atm_timer = new List<TimerEx>();
    private static Client target;
    private static string inputtext;
    private static string response;
    public float heading { get; set; }
    public int money { get; set; }
    //public Player owned { get; set; }
    public int time_remaining { get; set; }
    public DateTime time_vulnerable { get; set; }
    public int players_aiming { get; set; }
    public int cash_amount { get; set; }
    public static int id { get; set; }

    public ATMSystem()
    {
        // shop
        atms.Add(new { id = 1, MarkerType = 1, active = 0, position = new Vector3(74.08099, -218.7722, 54.64209) });
        // taxi
        atms.Add(new { id = 1, MarkerType = 1, active = 0, position = new Vector3(-226.4438, -335.306, 30.00277) });

        // taxi
        atms.Add(new { id = 1, MarkerType = 1, active = 0, position = new Vector3(903.8008, -164.0116, 74.16833) });

        // casino atm
        atms.Add(new { id = 1, MarkerType = 1, active = 0, position = new Vector3(1115.999, 220.005, -49.43497) });

        atms.Add(new { id = 1, MarkerType = 1, active = 0, position = new Vector3(-358.1067, -137.4947, 39.43066) });
        atms.Add(new { id = 1, MarkerType = 1, active = 0, position = new Vector3(-31.535383, -1659.8562, 29.478851) });
        atms.Add(new { id = 1, MarkerType = 1, active = 0, position = new Vector3(-1729.9677, -744.6379, 10.195256) });
        // Krankenhaus Stadt
        atms.Add(new { id = 1, MarkerType = 1, active = 0, position = new Vector3(350.6688, -603.5654, 28.76138) });
        // LKW Handel
        atms.Add(new { id = 1, MarkerType = 1, active = 0, position = new Vector3(105.0174, -2563.152, 5.999991) });
        // Bennys
        atms.Add(new { id = 1, MarkerType = 1, active = 0, position = new Vector3(-202.62, -1308.61, 31.69) });
        // Krankenhaus
        atms.Add(new { id = 1, MarkerType = 1, active = 0, position = new Vector3(315.5725, -1464.074, 29.96586) });
        atms.Add(new { id = 1, MarkerType = 1, active = 0, position = new Vector3(283.5047, -1444.499, 29.96586) });
        atms.Add(new { id = 1, MarkerType = 1, active = 0, position = new Vector3(384.6302, -1437.464, 29.27392) });
        atms.Add(new { id = 1, MarkerType = 1, active = 0, position = new Vector3(392.2803, -1426.654, 29.27392) });
        atms.Add(new { id = 1, MarkerType = 1, active = 0, position = new Vector3(365.7476, -1395.315, 32.9362) });
        // Larrys
        atms.Add(new { id = 1, MarkerType = 1, active = 0, position = new Vector3(1172.563, 2702.51, 38.17469) });
        atms.Add(new { id = 1, MarkerType = 1, active = 0, position = new Vector3(1171.465, 2702.508, 38.17551) });
        // Bahamas
        atms.Add(new { id = 1, MarkerType = 1, active = 0, position = new Vector3(-1390.884, -590.7057, 30.31956) });
        atms.Add(new { id = 3, MarkerType = 1, active = 0, position = new Vector3(-3240.933, 997.656, 12.55) });
        atms.Add(new { id = 4, MarkerType = 1, active = 0, position = new Vector3(-3044.012, 594.831, 7.737) });
        atms.Add(new { id = 5, MarkerType = 1, active = 0, position = new Vector3(-57.86, -92.967, 57.791) });
        atms.Add(new { id = 6, MarkerType = 1, active = 0, position = new Vector3(-203.85, -861.401, 30.268) });
        atms.Add(new { id = 7, MarkerType = 1, active = 0, position = new Vector3(288.75, -1282.301, 29.642) });
        atms.Add(new { id = 8, MarkerType = 1, active = 0, position = new Vector3(112.641, -819.372, 31.338) });
        atms.Add(new { id = 9, MarkerType = 1, active = 0, position = new Vector3(356.883, 173.482, 103.069) });
        atms.Add(new { id = 10, MarkerType = 1, active = 0, position = new Vector3(-386.733, 6045.953, 31.501) });
        atms.Add(new { id = 11, MarkerType = 1, active = 0, position = new Vector3(-284.037, 6224.385, 31.187) });
        atms.Add(new { id = 12, MarkerType = 1, active = 0, position = new Vector3(-284.037, 6224.385, 31.187) });
        atms.Add(new { id = 13, MarkerType = 1, active = 0, position = new Vector3(-135.165, 6365.738, 31.101) });
        atms.Add(new { id = 14, MarkerType = 1, active = 0, position = new Vector3(-110.753, 6467.703, 31.784) });
        atms.Add(new { id = 15, MarkerType = 1, active = 0, position = new Vector3(-135.165, 6467.703, 31.101) });
        atms.Add(new { id = 16, MarkerType = 1, active = 0, position = new Vector3(-94.9690, 6455.301, 31.784) });
        atms.Add(new { id = 17, MarkerType = 1, active = 0, position = new Vector3(155.4300, 6641.991, 31.784) });
        atms.Add(new { id = 18, MarkerType = 1, active = 0, position = new Vector3(174.6720, 6637.218, 31.784) });
        atms.Add(new { id = 19, MarkerType = 1, active = 0, position = new Vector3(1703.138, 6426.783, 32.730) });
        atms.Add(new { id = 20, MarkerType = 1, active = 0, position = new Vector3(1735.114, 6411.035, 35.164) });
        atms.Add(new { id = 21, MarkerType = 1, active = 0, position = new Vector3(1702.842, 4933.593, 42.051) });
        atms.Add(new { id = 22, MarkerType = 1, active = 0, position = new Vector3(1967.333, 3744.293, 32.272) });
        atms.Add(new { id = 23, MarkerType = 1, active = 0, position = new Vector3(1821.917, 3683.483, 34.244) });
        atms.Add(new { id = 24, MarkerType = 1, active = 0, position = new Vector3(1174.532, 2705.278, 38.027) });
        atms.Add(new { id = 25, MarkerType = 1, active = 0, position = new Vector3(540.0420, 2671.007, 42.177) });
        atms.Add(new { id = 27, MarkerType = 1, active = 0, position = new Vector3(2564.399, 2585.100, 38.016) });
        atms.Add(new { id = 28, MarkerType = 1, active = 0, position = new Vector3(2558.683, 349.6010, 108.050) });
        atms.Add(new { id = 29, MarkerType = 1, active = 0, position = new Vector3(2558.051, 389.4817, 108.660) });
        atms.Add(new { id = 30, MarkerType = 1, active = 0, position = new Vector3(1077.692, -775.796, 58.218) });
        atms.Add(new { id = 31, MarkerType = 1, active = 0, position = new Vector3(1139.018, -469.886, 66.789) });
        atms.Add(new { id = 32, MarkerType = 1, active = 0, position = new Vector3(1168.975, -457.241, 66.641) });
        atms.Add(new { id = 33, MarkerType = 1, active = 0, position = new Vector3(1153.884, -326.540, 69.245) });
        atms.Add(new { id = 34, MarkerType = 1, active = 0, position = new Vector3(381.2827, 323.2518, 103.270) });
        atms.Add(new { id = 35, MarkerType = 1, active = 0, position = new Vector3(236.4638, 217.4718, 106.840) });
        atms.Add(new { id = 36, MarkerType = 1, active = 0, position = new Vector3(265.0043, 212.1717, 106.780) });
        atms.Add(new { id = 37, MarkerType = 1, active = 0, position = new Vector3(285.2029, 143.5690, 104.970) });
        atms.Add(new { id = 38, MarkerType = 1, active = 0, position = new Vector3(157.7698, 233.5450, 106.450) });
        atms.Add(new { id = 39, MarkerType = 1, active = 0, position = new Vector3(-164.568, 233.5066, 94.919) });
        atms.Add(new { id = 40, MarkerType = 1, active = 0, position = new Vector3(-1827.04, 785.5159, 138.020) });
        atms.Add(new { id = 41, MarkerType = 1, active = 0, position = new Vector3(-1409.39, -99.2603, 52.473) });
        atms.Add(new { id = 42, MarkerType = 1, active = 0, position = new Vector3(-1205.35, -325.579, 37.870) });
        atms.Add(new { id = 43, MarkerType = 1, active = 0, position = new Vector3(-1215.64, -332.231, 37.881) });
        atms.Add(new { id = 44, MarkerType = 1, active = 0, position = new Vector3(-2072.41, -316.959, 13.345) });
        atms.Add(new { id = 45, MarkerType = 1, active = 0, position = new Vector3(-2975.72, 379.7737, 14.992) });
        atms.Add(new { id = 46, MarkerType = 1, active = 0, position = new Vector3(-2962.60, 482.1914, 15.762) });
        atms.Add(new { id = 47, MarkerType = 1, active = 0, position = new Vector3(-2955.70, 488.7218, 15.486) });
        atms.Add(new { id = 48, MarkerType = 1, active = 0, position = new Vector3(-3044.22, 595.2429, 7.595) });
        atms.Add(new { id = 49, MarkerType = 1, active = 0, position = new Vector3(-3144.13, 1127.415, 20.868) });
        atms.Add(new { id = 50, MarkerType = 1, active = 0, position = new Vector3(-3241.10, 996.6881, 12.500) });
        atms.Add(new { id = 51, MarkerType = 1, active = 0, position = new Vector3(-1305.40, -706.240, 25.352) });
        atms.Add(new { id = 52, MarkerType = 1, active = 0, position = new Vector3(-538.225, -854.423, 29.234) });
        atms.Add(new { id = 53, MarkerType = 1, active = 0, position = new Vector3(-711.156, -818.958, 23.768) });
        atms.Add(new { id = 54, MarkerType = 1, active = 0, position = new Vector3(-717.614, -915.880, 19.268) });
        atms.Add(new { id = 55, MarkerType = 1, active = 0, position = new Vector3(-526.566, -1222.90, 18.434) });
        atms.Add(new { id = 56, MarkerType = 1, active = 0, position = new Vector3(-256.0402, -716.1022, 33.50613) });
        atms.Add(new { id = 57, MarkerType = 1, active = 0, position = new Vector3(-203.548, -861.588, 30.205) });
        
        atms.Add(new { id = 58, MarkerType = 1, active = 0, position = new Vector3(111.227264, -775.3311, 31.438593) });
        atms.Add(new { id = 59, MarkerType = 1, active = 0, position = new Vector3(114.426445, -776.3689, 31.417803) });
        
        atms.Add(new { id = 60, MarkerType = 1, active = 0, position = new Vector3(119.9000, -883.826, 31.191) });
        atms.Add(new { id = 61, MarkerType = 1, active = 0, position = new Vector3(149.4551, -1038.95, 29.366) });
        atms.Add(new { id = 62, MarkerType = 1, active = 0, position = new Vector3(-846.304, -340.402, 38.687) });
        atms.Add(new { id = 63, MarkerType = 1, active = 0, position = new Vector3(-1204.35, -324.391, 37.877) });
        atms.Add(new { id = 64, MarkerType = 1, active = 0, position = new Vector3(-1216.27, -331.461, 37.773) });
        atms.Add(new { id = 65, MarkerType = 1, active = 0, position = new Vector3(-56.1935, -1752.53, 29.452) });
        atms.Add(new { id = 66, MarkerType = 1, active = 0, position = new Vector3(-261.692, -2012.64, 30.121) });
        atms.Add(new { id = 67, MarkerType = 1, active = 0, position = new Vector3(-273.001, -2025.60, 30.197) });
        atms.Add(new { id = 68, MarkerType = 1, active = 0, position = new Vector3(314.187, -278.621, 54.170) });
        atms.Add(new { id = 69, MarkerType = 1, active = 0, position = new Vector3(-351.534, -49.529, 49.042) });
        atms.Add(new { id = 70, MarkerType = 1, active = 0, position = new Vector3(24.589, -946.056, 29.357) });
        atms.Add(new { id = 71, MarkerType = 1, active = 0, position = new Vector3(-254.112, -692.483, 33.616) });
        atms.Add(new { id = 72, MarkerType = 1, active = 0, position = new Vector3(-1570.197, -546.651, 34.955) });
        atms.Add(new { id = 73, MarkerType = 1, active = 0, position = new Vector3(-1415.909, -211.825, 46.500) });
        atms.Add(new { id = 74, MarkerType = 1, active = 0, position = new Vector3(-1430.112, -211.014, 46.500) });
        atms.Add(new { id = 75, MarkerType = 1, active = 0, position = new Vector3(33.232, -1347.849, 29.497) });
        atms.Add(new { id = 76, MarkerType = 1, active = 0, position = new Vector3(129.216, -1292.347, 29.269) });
        atms.Add(new { id = 77, MarkerType = 1, active = 0, position = new Vector3(287.645, -1282.646, 29.659) });
        atms.Add(new { id = 78, MarkerType = 1, active = 0, position = new Vector3(289.012, -1256.545, 29.440) });
        atms.Add(new { id = 79, MarkerType = 1, active = 0, position = new Vector3(295.839, -895.640, 29.217) });
        atms.Add(new { id = 80, MarkerType = 1, active = 0, position = new Vector3(1686.753, 4815.809, 42.008) });
        atms.Add(new { id = 81, MarkerType = 1, active = 0, position = new Vector3(-302.408, -829.945, 32.417) });
        atms.Add(new { id = 82, MarkerType = 1, active = 0, position = new Vector3(5.134, -919.949, 29.557) });
        atms.Add(new { id = 83, MarkerType = 1, active = 0, position = new Vector3(-1138.9996, -1972.211, 13.16037) });
        atms.Add(new { id = 84, MarkerType = 1, active = 0, position = new Vector3(-283.0209, 6226.017, 31.493473) });
        atms.Add(new { id = 85, MarkerType = 1, active = 0, position = new Vector3(-283.4361, 6225.8306, 31.493666) });
        atms.Add(new { id = 86, MarkerType = 1, active = 0, position = new Vector3(1822.6799, 3683.2285, 34.276737) });

        foreach (var atm in atms)
        {
            //NAPI.TextLabel.CreateTextLabel("~g~~h~- ATM -~h~~n~~n~~w~Drücke ~y~~h~E~h~~w~", atm.position, 16, 0.600f, 0, new Color(255, 255, 255, 255));
            NAPI.Marker.CreateMarker(27, new Vector3(atm.position.X, atm.position.Y, atm.position.Z - 1.0), new Vector3(), new Vector3(), 0.8f, new Color(255, 255, 255, 155));
        }
    }

    public static void OnPlayerConnect(Client player)
    {
        player.SetData("ATM_Refinando", false);
    }

    public static void ATMShow(Client player)
    {
        foreach(var atm in atms)
        {
            if(Main.IsInRangeOfPoint(player.Position, atm.position, 1.0f))
            {
                List<dynamic> menu_item_list = new List<dynamic>();
                menu_item_list.Add(new { Type = 1, Name = "~c~Kontostand", Description = "", RightLabel = "~y~$~g~" + Main.GetPlayerBank(player).ToString("N0") + "" });
                menu_item_list.Add(new { Type = 1, Name = "Einzahlen", Description = "Zahlen Sie Geld auf Ihr Konto ein.", RightLabel = "" });
                menu_item_list.Add(new { Type = 1, Name = "Abheben", Description = "Heben Sie Geld von Ihrem Konto ab.", RightLabel = "" });
                menu_item_list.Add(new { Type = 1, Name = "Hacking", Description = "Hiermit machst du das, was du nicht machen solltest.", RightLabel = "" });
                InteractMenu.CreateMenu(player, "ATM_RESPONSE_MENU", "ATM", "~b~Los Santos Banks", true, JsonConvert.SerializeObject(menu_item_list), false);
            }
        }
    }

    public static void SelectMenuResponse(Client player, String callbackId, int selectedIndex, String objectName, String valueList)
    {
        if(callbackId == "ATM_RESPONSE_MENU")
        {
            if(selectedIndex == 0)
            {
                ATMShow(player);
            }
            else if(selectedIndex == 1)
            {
                InteractMenu.User_Input(player, "input_atm_deposit", "Einzahlen", "0", "", "number");
                InteractMenu.CloseDynamicMenu(player);
            }
            else if(selectedIndex == 2)
            {
                InteractMenu.User_Input(player, "input_atm_withdraw", "Abheben", "0", "", "number");
                InteractMenu.CloseDynamicMenu(player);
            }
            else if (selectedIndex == 3)
            {
                ATM_Hack(player, id);
                InteractMenu.CloseDynamicMenu(player);
            }
        }
    }

    public static void RemoveBlip(Client player)
    {
        foreach (Client target in NAPI.Pools.GetAllPlayers())
        {
            if (player.GetData("raub_blip") == true)
            {
                player.TriggerEvent("blip_remove", "raub_blip");
                player.SetData("raub_blip", false);
            }
        }
    }

    public static void OnInputResponse(Client player, String response, String inputtext)
    {
        if(response == "input_atm_deposit")
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
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Ungültiger eingegebener Wert.", 5000);
                return;
            }
            int value = Convert.ToInt32(inputtext);
            
            if (value < 1 || value > 1000000)
            {
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Der Betrag sollte zwischen $1 und $1,000,000 liegen.", 5000);
                return;
            }
            if(Main.GetPlayerMoney(player) < value)
            {
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie haben nicht genügend Bargeld.", 5000);
                return;
            }
            Main.GivePlayerMoney(player, -value);
            Main.GivePlayerMoneyBank(player, value);
            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du hast $" + value.ToString("N0") + " auf deinem Bankkonto eingezahlt.", 5000);
        }
        else if(response == "input_atm_withdraw")
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
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Ungültiger eingegebener Wert.", 5000);
                return;
            }
            int value = Convert.ToInt32(inputtext);
           
            if (value < 1 || value > 1000000)
            {
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Der Betrag sollte zwischen $1 und $1,000,000 liegen.", 5000);
                return;
            }
            if (Main.GetPlayerBank(player) < value)
            {
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie haben nicht soviel Geld auf Ihrem Bankkonto.", 5000);
                return;
            }
            Main.GivePlayerMoney(player, value);
            Main.GivePlayerMoneyBank(player, -value);
            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du hast $" + value.ToString("N0") + " von deinem Bankkonto abgehoben", 5000);
            //NAPI.Notification.SendNotificationToPlayer(player, "Sie haben ~g~$" + value.ToString("N0") + "~w~ von Ihrem Bankkonto abgehoben.");
        }
    }

    public static void ATM_Transfer(Client player, Client target, String response, String inputtext)
    {
        if (inputtext.Contains("-"))
        {
            return;
        }

        if (inputtext.Contains("+"))
        {
            return;
        }

        if (response == "input_atm_transfer")
        {
            if (!Main.IsNumeric(inputtext))
            {
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Ungültiger eingegebener Wert.", 5000);
                return;
            }
            int value = Convert.ToInt32(inputtext);

            if (value < 1 || value > 1000000)
            {
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Der Betrag sollte zwischen $1 und $1,000,000 liegen.", 5000);
                return;
            }
            if (Main.GetPlayerBank(player) < value)
            {
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie haben nicht soviel Geld auf Ihrem Bankkonto.", 5000);
                return;
            }
            Main.GivePlayerMoneyBank(player, -value);
            Main.GivePlayerMoneyBank(target, +value);
            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Ihre Überweisung von $" + value.ToString("N0") + " wurde abgeschickt.", 5000);
            //Main.DisplaySubtitle(player, "~y~ATM:~w~ Ihre Überweisung von ~g~$" + value.ToString("N0") + "~w~ wurde abgeschickt.", 5);
        }
    }

    public static void ATM_Hack(Client player, int id)
    {
        int cops_online = 0, members_online = 0;

        NAPI.Notification.SendNotificationToPlayer(player, "Du beginnst nun damit den ATM zu hacken!");
        NAPI.Notification.SendNotificationToPlayer(player, "Solltest du aufhören wollen, dann musst du das in die Wege leiten!");

        if (cops_online < 3)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Du hattest leider kein Erfolg bei den Hack-Versuch!");
            return;
        }

        if (members_online < SETTINGS_MEMBERS_NEEDED)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Du hattest leider kein Erfolg bei den Hack-Versuch!");
            return;
        }

        foreach (var atm in atms)
        {
            if (player.GetData("ATM_Refinando") == false)
            {
                foreach (var target in NAPI.Pools.GetAllPlayers())
                {
                    if (target.GetData("status") == true && AccountManage.GetPlayerGroup(target) == 1 && AccountManage.GetPlayerGroup(target) == 25)
                    {
                        player.SetData("ATM_Refinando", true);

                        if (target.GetData("status") == true)
                        {
                            if (AccountManage.GetPlayerGroup(target) == 1)
                            {
                                cops_online += 1;
                            }

                            if (AccountManage.GetPlayerGroup(player) == AccountManage.GetPlayerGroup(target) && Main.IsInRangeOfPoint(target.Position, atm.position, 15.0f))
                            {
                                members_online++;
                            }
                        }

                        NAPI.ClientEvent.TriggerClientEvent(target, "Notification.SendPictureNotification", "Maze Bank", "Hack Versuch", $"Es wird gerade ein ATM von unserer Los Santos Banks überfallen.");

                        Police.SetPlayerCrime(player, "Hack Angriff auf die Bank von Los Santos ", " Unbekannt", 12);

                        target.SendNotification("GPS-Route wegen den Hack-Versuch definiert!");
                        target.TriggerEvent("gps_set_loc", player.Position.X, player.Position.Y);
                    }
                }

                if (Main.IsInRangeOfPoint(player.Position, atm.position, 1f))
                {

                    NAPI.Task.Run(() =>
                    {
                        // Money 
                        Random rnd = new Random();
                        int money = rnd.Next(51, 86);
                        Inventory.GiveItemToInventory(player, 158, money);
                        // Msg
                        NAPI.Notification.SendNotificationToPlayer(player, "Sie haben ~b~$" + money + " Liberty Dollor~w~ von den ATM gehackt!");
                    }, delayTime: 30000);
                }
            }
            else if (player.GetData("ATM_Refinando") == true)
            {
                player.SetData("ATM_Refinando", false);
            }
        }
    }

    private class List
    {
        public int id { get; set; }
        public int MarkerType { get; set; }
        public int active { get; set; }
        public Vector3 position { get; set; }
    }
}