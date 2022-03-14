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

public class Gangunit : Script
{
    public static void GangunitInit()
    {
        //NAPI.TextLabel.CreateTextLabel("~y~Gangunit", new Vector3(902.5832, -172.6801, 74.07558 + 1.5), 12, 0.350f, 4, new Color(255, 255, 255, 255));
       // NAPI.Marker.CreateMarker(27, new Vector3(903.7722, -173.3565, 74.07556 - 1.0), new Vector3(), new Vector3(), 0.6f, new Color(255, 221, 0, 170));

        ColShape gangunit_menu = NAPI.ColShape.CreateCylinderColShape(new Vector3(903.7722, -173.3565, 74.07556), 1.5f, 1.5f);

        gangunit_menu.OnEntityEnterColShape += (s, ent) =>
        {
            Client player;

            if ((player = NAPI.Player.GetPlayerFromHandle(ent)) != null)
            {
                Main.DisplayTextHelp(player, "Drücke~y~~h~E~h~.", 6000);
            }
        };

        gangunit_menu.OnEntityExitColShape += (s, ent) =>
        {
            Client player;

            if ((player = NAPI.Player.GetPlayerFromHandle(ent)) != null)
            {
                Main.DisplayTextHelp(player, "Drücke~y~~h~E~h~.", 1);
            }
        };
    }
}	