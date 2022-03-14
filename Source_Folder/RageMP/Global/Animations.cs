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


class Animations : Script
{
    public static List<dynamic> animations_list = new List<dynamic>();

    [Command("anims")]
    public void command_anims(Client player)
    {
        
    }
}
