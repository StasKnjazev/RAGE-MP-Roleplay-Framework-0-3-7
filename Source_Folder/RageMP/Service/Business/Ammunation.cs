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

public class Ammunation : Script
{
    //ShowAmmunationList


    public static List<dynamic> ammunation_weapon_list = new List<dynamic>();

    public static void AmmunationInit()
    {
        ammunation_weapon_list.Add(new { model = "Bat", hash = "-1786099057", classe = "Melee" });
        ammunation_weapon_list.Add(new { model = "Knife", hash = "-1716189206", classe = "Melee" });
        ammunation_weapon_list.Add(new { model = "Hatchet", hash = "-102973651", classe = "Melee" });
        ammunation_weapon_list.Add(new { model = "Pistol50", hash = "-1716589765", classe = "Handguns" });
        //ammunation_weapon_list.Add(new { model = "HeavyPistol", hash = "-771403250", classe = "Handguns" });
        
    }

}