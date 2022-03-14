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
using DerStr1k3r.Core;
using DerStr1k3r.SDK;

public class CarDealership : Script
{
    public static List<dynamic> CarDealershipVehicles = new List<dynamic>();

    public int handelskammersteuer { get; set; }

    public static void CarDealershipInit()
    {
        //Compact
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Blista", car_dealership_class = "Compact Cars", car_dealership_stock_price = "6500" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Issi2", car_dealership_class = "Compact Cars", car_dealership_stock_price = "7000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Dilettante", car_dealership_class = "Compact Cars", car_dealership_stock_price = "10000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Prairie", car_dealership_class = "Compact Cars", car_dealership_stock_price = "10000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Panto", car_dealership_class = "Compact Cars", car_dealership_stock_price = "15000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Rhapsody", car_dealership_class = "Compact Cars", car_dealership_stock_price = "20000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Brioso", car_dealership_class = "Compact Cars", car_dealership_stock_price = "30000" });

        //Coupes
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Sentinel", car_dealership_class = "Coupes", car_dealership_stock_price = "25000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Zion", car_dealership_class = "Coupes", car_dealership_stock_price = "29000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Jackal", car_dealership_class = "Coupes", car_dealership_stock_price = "32000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Zion2", car_dealership_class = "Coupes", car_dealership_stock_price = "34000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Oracle2", car_dealership_class = "Coupes", car_dealership_stock_price = "34500" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Sentinel2", car_dealership_class = "Coupes", car_dealership_stock_price = "35000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Oracle", car_dealership_class = "Coupes", car_dealership_stock_price = "39500" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "F620", car_dealership_class = "Coupes", car_dealership_stock_price = "40000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Felon", car_dealership_class = "Coupes", car_dealership_stock_price = "40000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Felon2", car_dealership_class = "Coupes", car_dealership_stock_price = "45000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Cogcabrio", car_dealership_class = "Coupes", car_dealership_stock_price = "70000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Exemplar", car_dealership_class = "Coupes", car_dealership_stock_price = "85000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Windsor", car_dealership_class = "Coupes", car_dealership_stock_price = "250000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Windsor2", car_dealership_class = "Coupes", car_dealership_stock_price = "265000" });

        //Muscle
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Voodoo2", car_dealership_class = "Muscle", car_dealership_stock_price = "1500" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Ratloader", car_dealership_class = "Muscle", car_dealership_stock_price = "2500" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Picador", car_dealership_class = "Muscle", car_dealership_stock_price = "3600" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Ratloader2", car_dealership_class = "Muscle", car_dealership_stock_price = "5000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Ruiner", car_dealership_class = "Muscle", car_dealership_stock_price = "9999" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Blade", car_dealership_class = "Muscle", car_dealership_stock_price = "15000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Slamvan", car_dealership_class = "Muscle", car_dealership_stock_price = "15000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Faction", car_dealership_class = "Muscle", car_dealership_stock_price = "15500" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Vamos", car_dealership_class = "Sports", car_dealership_stock_price = "17000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Tampa", car_dealership_class = "Muscle", car_dealership_stock_price = "17500" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Vigero", car_dealership_class = "Muscle", car_dealership_stock_price = "18000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Buccaneer", car_dealership_class = "Muscle", car_dealership_stock_price = "19500" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Sabregt", car_dealership_class = "Muscle", car_dealership_stock_price = "19500" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Chino", car_dealership_class = "Muscle", car_dealership_stock_price = "20000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Slamvan2", car_dealership_class = "Muscle", car_dealership_stock_price = "20000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Stalion", car_dealership_class = "Muscle", car_dealership_stock_price = "20000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Moonbeam", car_dealership_class = "Muscle", car_dealership_stock_price = "21000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Virgo", car_dealership_class = "Muscle", car_dealership_stock_price = "21500" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Dominator", car_dealership_class = "Muscle", car_dealership_stock_price = "25000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Gauntlet", car_dealership_class = "Muscle", car_dealership_stock_price = "25000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Dukes", car_dealership_class = "Muscle", car_dealership_stock_price = "27000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Faction2", car_dealership_class = "Muscle", car_dealership_stock_price = "29900" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Hotknife", car_dealership_class = "Muscle", car_dealership_stock_price = "30999" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Voodoo", car_dealership_class = "Muscle", car_dealership_stock_price = "37500" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Buccaneer2", car_dealership_class = "Muscle", car_dealership_stock_price = "39500" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Chino2", car_dealership_class = "Muscle", car_dealership_stock_price = "40000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Hustler", car_dealership_class = "Muscle", car_dealership_stock_price = "40000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Yosemite", car_dealership_class = "Muscle", car_dealership_stock_price = "41000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Faction3", car_dealership_class = "Muscle", car_dealership_stock_price = "42000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Moonbeam2", car_dealership_class = "Muscle", car_dealership_stock_price = "42000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Slamvan3", car_dealership_class = "Muscle", car_dealership_stock_price = "42000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Virgo2", car_dealership_class = "Muscle", car_dealership_stock_price = "42000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Virgo2", car_dealership_class = "Muscle", car_dealership_stock_price = "42000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Sabregt2", car_dealership_class = "Muscle", car_dealership_stock_price = "44500" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Lurcher", car_dealership_class = "Muscle", car_dealership_stock_price = "45000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Phoenix", car_dealership_class = "Muscle", car_dealership_stock_price = "50000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Stalion2", car_dealership_class = "Muscle", car_dealership_stock_price = "70000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Nightshade", car_dealership_class = "Muscle", car_dealership_stock_price = "80000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Gauntlet2", car_dealership_class = "Muscle", car_dealership_stock_price = "87500" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Dominator2", car_dealership_class = "Muscle", car_dealership_stock_price = "89000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Deviant", car_dealership_class = "Muscle", car_dealership_stock_price = "135000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Hermes", car_dealership_class = "Muscle", car_dealership_stock_price = "140000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Ellie", car_dealership_class = "Muscle", car_dealership_stock_price = "145000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Coquette3", car_dealership_class = "Muscle", car_dealership_stock_price = "150000" });

        //OFFROAD
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Rebel", car_dealership_class = "SUV", car_dealership_stock_price = "3333" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Bfinjection", car_dealership_class = "SUV", car_dealership_stock_price = "5000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Dloader", car_dealership_class = "SUV", car_dealership_stock_price = "5500" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Rebel2", car_dealership_class = "SUV", car_dealership_stock_price = "6666" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Dune", car_dealership_class = "SUV", car_dealership_stock_price = "7500" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Bodhi2", car_dealership_class = "SUV", car_dealership_stock_price = "8500" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Blazer", car_dealership_class = "SUV", car_dealership_stock_price = "9000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Rancherxl", car_dealership_class = "SUV", car_dealership_stock_price = "9000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Kalahari", car_dealership_class = "SUV", car_dealership_stock_price = "9750" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Bifta", car_dealership_class = "SUV", car_dealership_stock_price = "15000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Blazer4", car_dealership_class = "SUV", car_dealership_stock_price = "15000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Blazer3", car_dealership_class = "SUV", car_dealership_stock_price = "18000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Sandking2", car_dealership_class = "SUV", car_dealership_stock_price = "20000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Sandking", car_dealership_class = "SUV", car_dealership_stock_price = "25000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Riata", car_dealership_class = "SUV", car_dealership_stock_price = "32000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Guardian", car_dealership_class = "SUV", car_dealership_stock_price = "32000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Mesa3", car_dealership_class = "SUV", car_dealership_stock_price = "35000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Brawler", car_dealership_class = "SUV", car_dealership_stock_price = "45000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Dubsta3", car_dealership_class = "SUV", car_dealership_stock_price = "82000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Kamacho", car_dealership_class = "Sedans", car_dealership_stock_price = "95000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Trophytruck", car_dealership_class = "SUV", car_dealership_stock_price = "92000" });

        //SUV
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Radi", car_dealership_class = "SUV", car_dealership_stock_price = "17500" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Habanero", car_dealership_class = "SUV", car_dealership_stock_price = "19000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Mesa", car_dealership_class = "SUV", car_dealership_stock_price = "19500" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Landstalker", car_dealership_class = "SUV", car_dealership_stock_price = "20000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Fq2", car_dealership_class = "SUV", car_dealership_stock_price = "22000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Seminole", car_dealership_class = "SUV", car_dealership_stock_price = "22200" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Cavalcade", car_dealership_class = "SUV", car_dealership_stock_price = "23000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Baller", car_dealership_class = "SUV", car_dealership_stock_price = "23500" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Serrano", car_dealership_class = "SUV", car_dealership_stock_price = "24000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Bjxl", car_dealership_class = "SUV", car_dealership_stock_price = "25000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Contender", car_dealership_class = "SUV", car_dealership_stock_price = "28000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Gresley", car_dealership_class = "SUV", car_dealership_stock_price = "29000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Baller2", car_dealership_class = "SUV", car_dealership_stock_price = "30500" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Cavalcade2", car_dealership_class = "SUV", car_dealership_stock_price = "31000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Patriot", car_dealership_class = "SUV", car_dealership_stock_price = "33500" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Baller3", car_dealership_class = "SUV", car_dealership_stock_price = "35000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Dubsta", car_dealership_class = "SUV", car_dealership_stock_price = "37000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Baller4", car_dealership_class = "SUV", car_dealership_stock_price = "38900" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Granger", car_dealership_class = "SUV", car_dealership_stock_price = "42000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Rocoto", car_dealership_class = "SUV", car_dealership_stock_price = "45555" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Xls", car_dealership_class = "SUV", car_dealership_stock_price = "49000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Dubsta2", car_dealership_class = "SUV", car_dealership_stock_price = "50000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Huntley", car_dealership_class = "SUV", car_dealership_stock_price = "52000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Patriot2", car_dealership_class = "SUV", car_dealership_stock_price = "57400" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Toros", car_dealership_class = "SUV", car_dealership_stock_price = "390000" });

        //Sedans
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Emperor2", car_dealership_class = "Sedans", car_dealership_stock_price = "500" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Emperor", car_dealership_class = "Sedans", car_dealership_stock_price = "2500" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Regina", car_dealership_class = "Sedans", car_dealership_stock_price = "3800" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Ingot", car_dealership_class = "Sedans", car_dealership_stock_price = "4800" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Asea", car_dealership_class = "Sedans", car_dealership_stock_price = "7000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Premier", car_dealership_class = "Sedans", car_dealership_stock_price = "7200" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Stratum", car_dealership_class = "Sedans", car_dealership_stock_price = "8000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Intruder", car_dealership_class = "Sedans", car_dealership_stock_price = "8500" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Asterope", car_dealership_class = "Sedans", car_dealership_stock_price = "9000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Primo", car_dealership_class = "Sedans", car_dealership_stock_price = "10200" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Stanier", car_dealership_class = "Sedans", car_dealership_stock_price = "12000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Surge", car_dealership_class = "Sedans", car_dealership_stock_price = "13000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Warrener", car_dealership_class = "Sedans", car_dealership_stock_price = "15000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Romero", car_dealership_class = "Sedans", car_dealership_stock_price = "19500" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Primo2", car_dealership_class = "Sedans", car_dealership_stock_price = "19800" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Washington", car_dealership_class = "Sedans", car_dealership_stock_price = "23000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Fugitive", car_dealership_class = "Sedans", car_dealership_stock_price = "29000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Glendale", car_dealership_class = "Sedans", car_dealership_stock_price = "32000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Tailgater", car_dealership_class = "Sedans", car_dealership_stock_price = "35400" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Schafter2", car_dealership_class = "Sedans", car_dealership_stock_price = "39900" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Stretch", car_dealership_class = "Sedans", car_dealership_stock_price = "55000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Cog55", car_dealership_class = "Sedans", car_dealership_stock_price = "154000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Superd", car_dealership_class = "Sedans", car_dealership_stock_price = "159050" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Stafford", car_dealership_class = "Sedans", car_dealership_stock_price = "195000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Cognoscenti", car_dealership_class = "Sedans", car_dealership_stock_price = "212000" });

        //Sports
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Raptor", car_dealership_class = "Sports", car_dealership_stock_price = "20000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Futo", car_dealership_class = "Sports", car_dealership_stock_price = "23000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Blista2", car_dealership_class = "Sports", car_dealership_stock_price = "24200" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Sultan", car_dealership_class = "Sports", car_dealership_stock_price = "29000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Fusilade", car_dealership_class = "Sports", car_dealership_stock_price = "31500" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Buffalo", car_dealership_class = "Sports", car_dealership_stock_price = "32000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Penumbra", car_dealership_class = "Sports", car_dealership_stock_price = "33000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Alpha", car_dealership_class = "Sports", car_dealership_stock_price = "35000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Buffalo2", car_dealership_class = "Sports", car_dealership_stock_price = "41000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Khamelion", car_dealership_class = "Sports", car_dealership_stock_price = "45000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Schafter4", car_dealership_class = "Sports", car_dealership_stock_price = "55000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Elegy2", car_dealership_class = "Sports", car_dealership_stock_price = "60000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Streiter", car_dealership_class = "Sports", car_dealership_stock_price = "60000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Coquette", car_dealership_class = "Sports", car_dealership_stock_price = "63000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Kuruma", car_dealership_class = "Sports", car_dealership_stock_price = "66300" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Sentinel3", car_dealership_class = "Sports", car_dealership_stock_price = "69000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Comet2", car_dealership_class = "Sports", car_dealership_stock_price = "70000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Feltzer2", car_dealership_class = "Sports", car_dealership_stock_price = "70000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Ruston", car_dealership_class = "Sports", car_dealership_stock_price = "72000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Schwarzer", car_dealership_class = "Sports", car_dealership_stock_price = "75000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Furoregt", car_dealership_class = "Sports", car_dealership_stock_price = "75400" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Lynx2", car_dealership_class = "Sports", car_dealership_stock_price = "76000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Banshee", car_dealership_class = "Sports", car_dealership_stock_price = "76400" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Jester", car_dealership_class = "Sports", car_dealership_stock_price = "90000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Comet5", car_dealership_class = "Sports", car_dealership_stock_price = "95000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Ninef", car_dealership_class = "Sports", car_dealership_stock_price = "95000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Raiden", car_dealership_class = "Sports", car_dealership_stock_price = "98750" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Ninef2", car_dealership_class = "Sports", car_dealership_stock_price = "100000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Surano", car_dealership_class = "Sports", car_dealership_stock_price = "102000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Specter", car_dealership_class = "Sports", car_dealership_stock_price = "105000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Tropos", car_dealership_class = "Sports", car_dealership_stock_price = "105000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Buffalo3", car_dealership_class = "Sports", car_dealership_stock_price = "110000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Elegy", car_dealership_class = "Sports", car_dealership_stock_price = "110000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Omnis", car_dealership_class = "Sports", car_dealership_stock_price = "110000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Comet3", car_dealership_class = "Sports", car_dealership_stock_price = "115000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Bestiagts", car_dealership_class = "Sports", car_dealership_stock_price = "120000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Seven70", car_dealership_class = "Sports", car_dealership_stock_price = "120000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Comet4", car_dealership_class = "Sports", car_dealership_stock_price = "125000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Carbonizzare", car_dealership_class = "Sports", car_dealership_stock_price = "130000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Jester2", car_dealership_class = "Sports", car_dealership_stock_price = "144500" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Tampa2", car_dealership_class = "Sports", car_dealership_stock_price = "150000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Massacro", car_dealership_class = "Sports", car_dealership_stock_price = "158000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Verlierer2", car_dealership_class = "Sports", car_dealership_stock_price = "163000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Schafter3", car_dealership_class = "Sports", car_dealership_stock_price = "168000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Rapidgt", car_dealership_class = "Sports", car_dealership_stock_price = "172000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Neon", car_dealership_class = "Sports", car_dealership_stock_price = "175000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Rapidgt2", car_dealership_class = "Sports", car_dealership_stock_price = "175000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Jester3", car_dealership_class = "Sports", car_dealership_stock_price = "180000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Specter2", car_dealership_class = "Sports", car_dealership_stock_price = "180000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Massacro2", car_dealership_class = "Sports", car_dealership_stock_price = "204000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Revolter", car_dealership_class = "Sports", car_dealership_stock_price = "210000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Pariah", car_dealership_class = "Sports", car_dealership_stock_price = "295000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Schlagen", car_dealership_class = "Sports", car_dealership_stock_price = "633000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Monster", car_dealership_class = "SUV", car_dealership_stock_price = "75000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Clique", car_dealership_class = "Muscle", car_dealership_stock_price = "125000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Italigto", car_dealership_class = "Sports", car_dealership_stock_price = "465000" });

        // Sport Classics
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Tornado4", car_dealership_class = "Sports", car_dealership_stock_price = "750" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Tornado3", car_dealership_class = "Sports", car_dealership_stock_price = "2000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Tornado6", car_dealership_class = "Sports", car_dealership_stock_price = "15000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Tornado2", car_dealership_class = "Sports", car_dealership_stock_price = "28500" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Tornado", car_dealership_class = "Sports", car_dealership_stock_price = "32000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Manana", car_dealership_class = "Sports", car_dealership_stock_price = "41000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Retinue", car_dealership_class = "Sports", car_dealership_stock_price = "50000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Tornado5", car_dealership_class = "Sports", car_dealership_stock_price = "50000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Peyote", car_dealership_class = "Sports", car_dealership_stock_price = "69000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Pigalle", car_dealership_class = "Sports", car_dealership_stock_price = "70000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Coquette2", car_dealership_class = "Sports", car_dealership_stock_price = "72000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Savestra", car_dealership_class = "Sports", car_dealership_stock_price = "90000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Viseris", car_dealership_class = "Sports", car_dealership_stock_price = "99000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Monroe", car_dealership_class = "Sports", car_dealership_stock_price = "145000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Rapidgt3", car_dealership_class = "Sports", car_dealership_stock_price = "160000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Infernus2", car_dealership_class = "Sports", car_dealership_stock_price = "175000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Torero", car_dealership_class = "Sports", car_dealership_stock_price = "180000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Stinger", car_dealership_class = "Sports", car_dealership_stock_price = "190000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Casco", car_dealership_class = "Sports", car_dealership_stock_price = "199000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Btype2", car_dealership_class = "Sports", car_dealership_stock_price = "200000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Cheetah2", car_dealership_class = "Sports", car_dealership_stock_price = "205000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Stingergt", car_dealership_class = "Sports", car_dealership_stock_price = "210000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Turismo2", car_dealership_class = "Sports", car_dealership_stock_price = "225000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Btype", car_dealership_class = "Sports", car_dealership_stock_price = "250000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Mamba", car_dealership_class = "Sports", car_dealership_stock_price = "250000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Feltzer3", car_dealership_class = "Sports", car_dealership_stock_price = "270000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Btype3", car_dealership_class = "Sports", car_dealership_stock_price = "275000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Swinger", car_dealership_class = "Sports", car_dealership_stock_price = "290000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Gt500", car_dealership_class = "Sports", car_dealership_stock_price = "320000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Ztype", car_dealership_class = "Sports", car_dealership_stock_price = "550000" });

        // Super
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Voltic", car_dealership_class = "Sports", car_dealership_stock_price = "709000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Sultanrs", car_dealership_class = "Sports", car_dealership_stock_price = "145000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Banshee2", car_dealership_class = "Sports", car_dealership_stock_price = "168000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Bullet", car_dealership_class = "Sports", car_dealership_stock_price = "170000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Infernus", car_dealership_class = "Sports", car_dealership_stock_price = "199000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Vacca", car_dealership_class = "Sports", car_dealership_stock_price = "205000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Sc1", car_dealership_class = "Sports", car_dealership_stock_price = "220000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Tempesta", car_dealership_class = "Sports", car_dealership_stock_price = "250000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Italigtb", car_dealership_class = "Sports", car_dealership_stock_price = "275000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Penetrator", car_dealership_class = "Sports", car_dealership_stock_price = "280000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Reaper", car_dealership_class = "Sports", car_dealership_stock_price = "280000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Cheetah", car_dealership_class = "Sports", car_dealership_stock_price = "290000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Cyclone", car_dealership_class = "Sports", car_dealership_stock_price = "295000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Sheava", car_dealership_class = "Sports", car_dealership_stock_price = "300000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Italigtb2", car_dealership_class = "Sports", car_dealership_stock_price = "405000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Fmj", car_dealership_class = "Sports", car_dealership_stock_price = "315000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Pfister811", car_dealership_class = "Sports", car_dealership_stock_price = "330000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Entityxf", car_dealership_class = "Sports", car_dealership_stock_price = "440000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "T20", car_dealership_class = "Sports", car_dealership_stock_price = "540000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Adder", car_dealership_class = "Sports", car_dealership_stock_price = "350000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Zentorno", car_dealership_class = "Sports", car_dealership_stock_price = "365000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Osiris", car_dealership_class = "Sports", car_dealership_stock_price = "378000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Nero", car_dealership_class = "Sports", car_dealership_stock_price = "380000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Turismor", car_dealership_class = "Sports", car_dealership_stock_price = "380000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Xa21", car_dealership_class = "Sports", car_dealership_stock_price = "399000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Nero2", car_dealership_class = "Sports", car_dealership_stock_price = "440000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Visione", car_dealership_class = "Sports", car_dealership_stock_price = "480000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Gp1", car_dealership_class = "Sports", car_dealership_stock_price = "490000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Tyrus", car_dealership_class = "Sports", car_dealership_stock_price = "500000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Prototipo", car_dealership_class = "Sports", car_dealership_stock_price = "550000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Vagner", car_dealership_class = "Sports", car_dealership_stock_price = "580000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Autarch", car_dealership_class = "Sports", car_dealership_stock_price = "550000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Le7b", car_dealership_class = "Sports", car_dealership_stock_price = "650000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Sentinel4", car_dealership_class = "Sports", car_dealership_stock_price = "100000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Pmp600", car_dealership_class = "Sports", car_dealership_stock_price = "90000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Kawaii", car_dealership_class = "Sports", car_dealership_stock_price = "110000" });

        // Other
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Surfer2", car_dealership_class = "Sports", car_dealership_stock_price = "4520" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Caddy", car_dealership_class = "Sports", car_dealership_stock_price = "5000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Surfer", car_dealership_class = "Sports", car_dealership_stock_price = "20000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Journey", car_dealership_class = "Sports", car_dealership_stock_price = "24000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Tourbus", car_dealership_class = "Sports", car_dealership_stock_price = "30000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Camper", car_dealership_class = "Sports", car_dealership_stock_price = "40000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Taco", car_dealership_class = "Sports", car_dealership_stock_price = "50000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Tractor2", car_dealership_class = "Sports", car_dealership_stock_price = "75000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Pbus2", car_dealership_class = "Sports", car_dealership_stock_price = "100000" });

        //Motorcycles
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Faggio3", car_dealership_class = "Motorcycles", car_dealership_stock_price = "1000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Faggio2", car_dealership_class = "Motorcycles", car_dealership_stock_price = "2000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Faggio", car_dealership_class = "Motorcycles", car_dealership_stock_price = "3000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Ratbike", car_dealership_class = "Motorcycles", car_dealership_stock_price = "8000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Nemesis", car_dealership_class = "Motorcycles", car_dealership_stock_price = "10400" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Lectro", car_dealership_class = "Motorcycles", car_dealership_stock_price = "13700" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Vader", car_dealership_class = "Motorcycles", car_dealership_stock_price = "14250" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Fcr", car_dealership_class = "Motorcycles", car_dealership_stock_price = "15700" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Sanchez2", car_dealership_class = "Motorcycles", car_dealership_stock_price = "17500" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Pcj", car_dealership_class = "Motorcycles", car_dealership_stock_price = "18250" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Enduro", car_dealership_class = "Motorcycles", car_dealership_stock_price = "18500" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Fcr2", car_dealership_class = "Motorcycles", car_dealership_stock_price = "19200" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Esskey", car_dealership_class = "Motorcycles", car_dealership_stock_price = "21300" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Ruffian", car_dealership_class = "Motorcycles", car_dealership_stock_price = "23650" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Carbonrs", car_dealership_class = "Motorcycles", car_dealership_stock_price = "48900" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Akuma", car_dealership_class = "Motorcycles", car_dealership_stock_price = "31350" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Wolfsbane", car_dealership_class = "Motorcycles", car_dealership_stock_price = "32500" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Vindicator", car_dealership_class = "Motorcycles", car_dealership_stock_price = "34500" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Defiler", car_dealership_class = "Motorcycles", car_dealership_stock_price = "35000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Manchez", car_dealership_class = "Motorcycles", car_dealership_stock_price = "25000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Diablous", car_dealership_class = "Motorcycles", car_dealership_stock_price = "36400" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Thrust", car_dealership_class = "Motorcycles", car_dealership_stock_price = "37400" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Bagger", car_dealership_class = "Motorcycles", car_dealership_stock_price = "39000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Zombiea", car_dealership_class = "Motorcycles", car_dealership_stock_price = "40000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Hexer", car_dealership_class = "Motorcycles", car_dealership_stock_price = "40200" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Daemon", car_dealership_class = "Motorcycles", car_dealership_stock_price = "41000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Daemon2", car_dealership_class = "Motorcycles", car_dealership_stock_price = "44000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Diablous2", car_dealership_class = "Motorcycles", car_dealership_stock_price = "44300" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Zombieb", car_dealership_class = "Motorcycles", car_dealership_stock_price = "45000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Cliffhanger", car_dealership_class = "Motorcycles", car_dealership_stock_price = "48000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Vortex", car_dealership_class = "Motorcycles", car_dealership_stock_price = "48200" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Double", car_dealership_class = "Motorcycles", car_dealership_stock_price = "49700" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Gargoyle", car_dealership_class = "Motorcycles", car_dealership_stock_price = "50500" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Bf400", car_dealership_class = "Motorcycles", car_dealership_stock_price = "21000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Sovereign", car_dealership_class = "Motorcycles", car_dealership_stock_price = "51000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Bati", car_dealership_class = "Motorcycles", car_dealership_stock_price = "54000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Nightblade", car_dealership_class = "Motorcycles", car_dealership_stock_price = "68400" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Avarus", car_dealership_class = "Motorcycles", car_dealership_stock_price = "69000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Hakuchou", car_dealership_class = "Motorcycles", car_dealership_stock_price = "84000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Bati2", car_dealership_class = "Motorcycles", car_dealership_stock_price = "79000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Chimera", car_dealership_class = "Motorcycles", car_dealership_stock_price = "105000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Hakuchou2", car_dealership_class = "Motorcycles", car_dealership_stock_price = "120000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Innovation", car_dealership_class = "Motorcycles", car_dealership_stock_price = "145000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Sanctus", car_dealership_class = "Motorcycles", car_dealership_stock_price = "150000" });

        //Pickup Trucks
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Bobcatxl", car_dealership_class = "Pickup Trucks", car_dealership_stock_price = "14900" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Sadler", car_dealership_class = "SUV", car_dealership_stock_price = "15000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Bison", car_dealership_class = "Pickup Trucks", car_dealership_stock_price = "15500" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Mule", car_dealership_class = "Pickup Trucks", car_dealership_stock_price = "45000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Pounder", car_dealership_class = "Big Trucks", car_dealership_stock_price = "645000" });

        //Vans
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Minivan", car_dealership_class = "Vans", car_dealership_stock_price = "9999" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Gburrito", car_dealership_class = "Vans", car_dealership_stock_price = "16000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Youga", car_dealership_class = "Vans", car_dealership_stock_price = "17000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Gburrito2", car_dealership_class = "Vans", car_dealership_stock_price = "17000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Burrito", car_dealership_class = "Vans", car_dealership_stock_price = "18000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Speedo", car_dealership_class = "Vans", car_dealership_stock_price = "18500" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Minivan2", car_dealership_class = "Vans", car_dealership_stock_price = "19980" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Pony", car_dealership_class = "Vans", car_dealership_stock_price = "20000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Rumpo3", car_dealership_class = "Vans", car_dealership_stock_price = "20500" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Boxville4", car_dealership_class = "Vans", car_dealership_stock_price = "30000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Walton", car_dealership_class = "Vans", car_dealership_stock_price = "35000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Sadler4", car_dealership_class = "Vans", car_dealership_stock_price = "35000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Yosemite3", car_dealership_class = "Vans", car_dealership_stock_price = "35000" });

        //Heli
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Maverick", car_dealership_class = "Helicopters", car_dealership_stock_price = "950000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Supervolito", car_dealership_class = "Helicopters", car_dealership_stock_price = "1400000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Supervolito2", car_dealership_class = "Helicopters", car_dealership_stock_price = "1500000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Volatus", car_dealership_class = "Helicopters", car_dealership_stock_price = "1750000" });

        //Boats
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Seashark", car_dealership_class = "Boats", car_dealership_stock_price = "5000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Seashark3", car_dealership_class = "Boats", car_dealership_stock_price = "7500" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Dinghy", car_dealership_class = "Boats", car_dealership_stock_price = "20000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Squalo", car_dealership_class = "Boats", car_dealership_stock_price = "40000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Jetmax", car_dealership_class = "Boats", car_dealership_stock_price = "45000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Tropic2", car_dealership_class = "Boats", car_dealership_stock_price = "50000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Speeder2", car_dealership_class = "Boats", car_dealership_stock_price = "82000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Toro2", car_dealership_class = "Boats", car_dealership_stock_price = "95000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Marquis", car_dealership_class = "Boats", car_dealership_stock_price = "200000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "Seashark2", car_dealership_class = "Boats", car_dealership_stock_price = "500000" });

        CarDealershipVehicles.Add(new { car_dealership_model_name = "drafter", car_dealership_class = "Sports", car_dealership_stock_price = "49000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "krieger", car_dealership_class = "Sports", car_dealership_stock_price = "299000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "zorrusso", car_dealership_class = "Sports", car_dealership_stock_price = "289000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "emerus", car_dealership_class = "Sports", car_dealership_stock_price = "281000" });

        CarDealershipVehicles.Add(new { car_dealership_model_name = "bmwm8", car_dealership_class = "Sports", car_dealership_stock_price = "3751000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "s5", car_dealership_class = "Vans", car_dealership_stock_price = "59000" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "asdbx", car_dealership_class = "Coupes", car_dealership_stock_price = "62599" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "bmwm5", car_dealership_class = "Sports", car_dealership_stock_price = "451000" });

        //CarDealershipVehicles.Add(new { car_dealership_model_name = "17m760i", car_dealership_class = "Sports", car_dealership_stock_price = "325100" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "lhuracan", car_dealership_class = "Sports", car_dealership_stock_price = "525100" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "17m760i", car_dealership_class = "Sports", car_dealership_stock_price = "325100" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "tts", car_dealership_class = "Sports", car_dealership_stock_price = "115100" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "mach1", car_dealership_class = "Sports", car_dealership_stock_price = "215100" });

        // Tuner DLC
        CarDealershipVehicles.Add(new { car_dealership_model_name = "calico", car_dealership_class = "Sports", car_dealership_stock_price = "115100" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "comet6", car_dealership_class = "Sports", car_dealership_stock_price = "215100" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "cypher", car_dealership_class = "Sports", car_dealership_stock_price = "215100" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "dominator7", car_dealership_class = "Sports", car_dealership_stock_price = "215100" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "dominator8", car_dealership_class = "Sports", car_dealership_stock_price = "215100" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "euros", car_dealership_class = "Sports", car_dealership_stock_price = "215100" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "remus", car_dealership_class = "Sports", car_dealership_stock_price = "215100" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "sultan3", car_dealership_class = "Sports", car_dealership_stock_price = "215100" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "zr350", car_dealership_class = "Sports", car_dealership_stock_price = "215100" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "dominator8", car_dealership_class = "Sports", car_dealership_stock_price = "215100" });
        CarDealershipVehicles.Add(new { car_dealership_model_name = "dominator8", car_dealership_class = "Sports", car_dealership_stock_price = "215100" });

    }

    public static void ShowDealershipManage(Client player)
    {
        int business_id = Business.GetPlayerInBusinessInDealership(player);

        if(business_id == -1)
        {
            return;
        }

        if(Business.business_list[business_id].business_OwnerID != AccountManage.GetPlayerSQLID(player))
        {
            return;
        }

        // Vehicles From Stock
        List<dynamic> client_vehicle_stock = new List<dynamic>();
        foreach (var veh_stock in CarDealershipVehicles)
        {//   Compact Cars, Coupes, Muscle, SUV, Sedans, Sports, Sport Classics, Motorcycles, Bicycles, Pickup Trucks, Vans
            if (Business.business_list[business_id].business_Type == 4)
            {
                if (veh_stock.car_dealership_class == "Compact Cars" || veh_stock.car_dealership_class == "Coupes" || veh_stock.car_dealership_class == "Muscle" || veh_stock.car_dealership_class == "SUV" || veh_stock.car_dealership_class == "Sedans" || veh_stock.car_dealership_class == "Sports" || veh_stock.car_dealership_class == "Sport Classics")
                {

                    client_vehicle_stock.Add(new { Model = veh_stock.car_dealership_model_name, Classe = veh_stock.car_dealership_class, Price = veh_stock.car_dealership_stock_price });
                }
            }
            else if (Business.business_list[business_id].business_Type == 6)
            {
                if (veh_stock.car_dealership_class == "Motorcycles" || veh_stock.car_dealership_class == "Bicycles")
                {

                    client_vehicle_stock.Add(new { Model = veh_stock.car_dealership_model_name, Classe = veh_stock.car_dealership_class, Price = veh_stock.car_dealership_stock_price });
                }
            }
            else if (Business.business_list[business_id].business_Type == 7)
            {
                if (veh_stock.car_dealership_class == "Boats")
                {

                    client_vehicle_stock.Add(new { Model = veh_stock.car_dealership_model_name, Classe = veh_stock.car_dealership_class, Price = veh_stock.car_dealership_stock_price });
                }
            }
            else if (Business.business_list[business_id].business_Type == 8)
            {
                if (veh_stock.car_dealership_class == "Helicopters")
                {

                    client_vehicle_stock.Add(new { Model = veh_stock.car_dealership_model_name, Classe = veh_stock.car_dealership_class, Price = veh_stock.car_dealership_stock_price });
                }
            }
            else if (Business.business_list[business_id].business_Type == 9)
            {
                if (veh_stock.car_dealership_class == "Pickup Trucks" || veh_stock.car_dealership_class == "Vans" || veh_stock.car_dealership_class == "Big Trucks")
                {

                    client_vehicle_stock.Add(new { Model = veh_stock.car_dealership_model_name, Classe = veh_stock.car_dealership_class, Price = veh_stock.car_dealership_stock_price });
                }
            }

        }

        List<dynamic> vehicle_list = new List<dynamic>();
        // Vehicles From Business
        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {
            Mainpipeline.Open();
            MySqlCommand query = new MySqlCommand("SELECT * FROM `business_vehicles` WHERE `vehicle_stock` > 0 AND `business_id` = '" + business_id + "';", Mainpipeline);
            using (MySqlDataReader reader = query.ExecuteReader())
            {
                while (reader.Read())
                {
                    vehicle_list.Add(new { Model = reader.GetString("vehicle_model"), Price = reader.GetInt32("vehicle_price"), Status = Convert.ToBoolean(reader.GetInt32("vehicle_status")), Stock = reader.GetInt32("vehicle_stock") });
                }
            }
        }
        //

        player.TriggerEvent("Display_DealerShip_Manage", Business.business_list[business_id].business_Name, Business.Business_Type(Business.business_list[business_id].business_Type), Business.business_list[business_id].business_Safe, NAPI.Util.ToJson(client_vehicle_stock), NAPI.Util.ToJson(vehicle_list));
    }

    public static void ShowDealerShipVehicles(Client player)
    {
        int business_id = -1, count = 0;
        foreach (var business in Business.business_list)
        {
            if (Main.IsInRangeOfPoint(player.Position, business.business_dealership_buy, 30) && (business.business_Type == 4 || business.business_Type == 6 || business.business_Type == 7 || business.business_Type == 8 || business.business_Type == 9))
            {
                business_id = count;
            }
            count++;
        }

        if (business_id == -1)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Sie sind nicht in einer Verkaufsstelle..");
            return;
        }

        List<dynamic> vehicle_list = new List<dynamic>();
        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {
            Mainpipeline.Open();
            MySqlCommand query = new MySqlCommand("SELECT * FROM `business_vehicles` WHERE `vehicle_status` > 0 AND `vehicle_stock` > 0 AND `business_id` = '" + business_id + "';", Mainpipeline);
            using (MySqlDataReader reader = query.ExecuteReader())
            {
                while (reader.Read())
                {
                    vehicle_list.Add(new { Model = reader.GetString("vehicle_model"), Price = reader.GetInt32("vehicle_price"), Stock = reader.GetInt32("vehicle_stock") });
                }
            }
        }

        player.TriggerEvent("Display_Vehicle_Dealership_Player", Business.business_list[business_id].business_Name, NAPI.Util.ToJson(vehicle_list));
    }

    [RemoteEvent("BuyVehicle_FromDealership")]
    public static void BuyVehicle(Client player, string model, int color_id)
    {
       
        int index = PlayerVehicle.GetPlayerVehicleFreeSlotIndex(player);
        int business_id = Business.GetPlayerInBusinessInDealership(player);

        if(business_id == -1)
        {
            return;
        }

        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {
            Mainpipeline.Open();
            MySqlCommand query = new MySqlCommand("SELECT * FROM `business_vehicles` WHERE (`vehicle_model` = '" + model + "' AND `vehicle_stock` > 0) AND `business_id` = '" + business_id + "';", Mainpipeline);
            using (MySqlDataReader reader = query.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (reader.GetInt32("business_id") == business_id && reader.GetInt32("vehicle_stock") > 0 && reader.GetString("vehicle_model") == model)
                    {
                        if (PlayerVehicle.GetPlayerVehicleCount(player) >= PlayerVehicle.MaxPlayerVehicles(player))
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie können nicht mehr als " + PlayerVehicle.MaxPlayerVehicles(player) + " Fahrzeuge kaufen.", 5000);
                            return;
                        }

                        if (index == -1)
                        {
                            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie können nicht mehr als " + PlayerVehicle.MAX_PLAYER_VEHICLES + " Fahrzeuge bestizen.", 5000);
                            return;
                        }
                        else
                        {
                            //
                            if (Main.GetPlayerMoney(player) < reader.GetInt32("vehicle_price"))
                            {
                                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du hast nicht genug Geld um dieses Fahrzeug zu kaufen.", 5000);
                                return;
                            }
                            Main.GivePlayerMoney(player, -reader.GetInt32("vehicle_price"));

                            if (Business.business_list[business_id].business_OwnerID != -1)
                            {
                                Business.business_list[business_id].business_Safe = Business.business_list[business_id].business_Safe + reader.GetInt32("vehicle_price");
                            }
                            PlayerVehicle.CreatePlayerVehicle(player, index, model, Business.business_list[business_id].business_dealership_vehicle.X, Business.business_list[business_id].business_dealership_vehicle.Y, Business.business_list[business_id].business_dealership_vehicle.Z, 0.0f, 0.0f, Business.business_list[business_id].business_dealership_vehicle_a, color_id, color_id);

                            Main.CreateMySqlCommand("UPDATE `business_vehicles` SET `vehicle_stock` = `vehicle_stock` - 1 WHERE `vehicle_model` = '" + model + "' and `business_id` = '" + business_id + "';");
                            

                            PlayerVehicle.vehicle_data[Main.getIdFromClient(player)].health[index] = Convert.ToInt32(Main.DEFAULT_VEHICLE_HEALTH);

                            PlayerVehicle.vehicle_data[Main.getIdFromClient(player)].state[index] = 1;

                            PlayerVehicle.vehicle_data[Main.getIdFromClient(player)].json_vehicle_mods[index] = "";

                            PlayerVehicle.SpawnPlayerVehicle(player, index);
                            NAPI.Player.SetPlayerIntoVehicle(player, PlayerVehicle.vehicle_data[Main.getIdFromClient(player)].handle[index], -1);

                            NAPI.Vehicle.SetVehicleEngineStatus(PlayerVehicle.vehicle_data[Main.getIdFromClient(player)].handle[index], false);
                            NAPI.Vehicle.SetVehicleLocked(PlayerVehicle.vehicle_data[Main.getIdFromClient(player)].handle[index], true);

                            // Am WE wieder freigeben
                            //Inventory.GiveItemToInventory(player, 157, 1);

                            PlayerVehicle.SavePlayerVehicle(player, index);
                            player.TriggerEvent("Destroy_Character_Menu");
                            Notify.Send(player, NotifyType.Success, NotifyPosition.BottomCenter, $"Glückwunsch, Sie haben einen " + model + " gekauft.", 5000);
                            //NAPI.Notification.SendNotificationToPlayer(player, "Glückwunsch, Sie haben einen gekauft ~y~" + model + "~w~ von " + Business.business_list[business_id].business_Name + ".");
                            return;
                        }
                    }
                }
            }
        }
        player.TriggerEvent("Destroy_Character_Menu");
        NAPI.Notification.SendNotificationToPlayer(player, "Wir konnten Ihren Einkauf nicht abwickeln, das Unternehmen ist nicht geöffnet oder hat dieses Fahrzeug nicht auf Lager.");
    }
    
    [RemoteEvent("vehicle_to_business")]
    public void AddVehicleToBusiness(Client player, string name, int stock, int price)
    {
        string dealership_vehicle_name = name;
        int dealership_vehicle_stock = stock;
        int dealership_vehicle_price = price;

        int business_id = Business.GetPlayerInBusinessInDealership(player);

        if (business_id == -1)
        {
            Main.DisplayErrorMessage(player, "Sie haben keine Firma mehr.");
            player.TriggerEvent("Destroy_Character_Menu");
            return;
        }

        if (Business.business_list[business_id].business_OwnerID != AccountManage.GetPlayerSQLID(player))
        {
            Main.DisplayErrorMessage(player, "Sie haben keine Firma mehr.");
            player.TriggerEvent("Destroy_Character_Menu");
            return;
        }


        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {
            Mainpipeline.Open();
            MySqlCommand query = Mainpipeline.CreateCommand();
            query.CommandType = CommandType.Text;
            query.CommandText = "SELECT * FROM `business_vehicles` WHERE `vehicle_model` = '" + dealership_vehicle_name + "' AND `business_id` = '" + business_id + "'";
            ////NAPI.Util.ConsoleOutput(query.CommandText);
            query.ExecuteNonQuery();
            DataTable dt = new DataTable();

            int i = 0;
            using (MySqlDataAdapter da = new MySqlDataAdapter(query))
            {
                da.Fill(dt);
                i = Convert.ToInt32(dt.Rows.Count.ToString());
            }

            int foreach_index = 0, index = -1;
            foreach (var vehicle_dealership in CarDealershipVehicles)
            {
                if (vehicle_dealership.car_dealership_model_name == dealership_vehicle_name)
                {
                    index = foreach_index;
                }
                foreach_index++;
            }

            if (index == -1)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Fehler beim Hinzufügen / Bearbeiten von Fahrzeugbestand ~y~" + dealership_vehicle_name + "~w~. [CODE #000010]");
                player.TriggerEvent("Destroy_Character_Menu");
                return;
            }

            if (i == 0)
            {
                if (Business.business_list[business_id].business_Safe < dealership_vehicle_price)
                {
                    Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Ihr Unternehmen hat nicht genug Geld im Safe, um diese Aktie zu kaufen", 5000);
                    return;
                }

                Business.business_list[business_id].business_Safe = Business.business_list[business_id].business_Safe - dealership_vehicle_price;
                Business.SaveBusiness(business_id);

                Main.CreateMySqlCommand("INSERT INTO business_vehicles (business_id, vehicle_model, vehicle_price, vehicle_stock)" + " VALUES ('" + business_id + "', '" + dealership_vehicle_name + "', '" + CarDealershipVehicles[index].car_dealership_stock_price + "', '" + dealership_vehicle_stock + "')");

                handelskammersteuer = Convert.ToInt32(System.Math.Ceiling(Convert.ToDouble(dealership_vehicle_price.ToString("N0")) / Convert.ToDouble(100) * 19 * dealership_vehicle_stock));
                NAPI.Notification.SendNotificationToPlayer(player, "Fahrzeug: ~y~" + dealership_vehicle_name + " \n Kosten: ~g~$" + dealership_vehicle_price.ToString("N0") + " \n ~w~Steuer: ~g~$~y~" + handelskammersteuer + " \n Verwenden Sie das Unternehmensmenü, um es zu aktivieren.");
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du hast einen " + dealership_vehicle_stock + " von " + dealership_vehicle_name + " gekauft. New Balance: $" + Business.business_list[business_id].business_Safe.ToString("N0") + "", 5000);
                ShowDealershipManage(player);
            }
            else
            {
                using (MySqlDataReader reader = query.ExecuteReader())
                {
                    string data2txt = string.Empty;
                    string datatxt = string.Empty;
                    int old_stock = 0;


                    while (reader.Read())
                    {
                        old_stock = reader.GetInt32("vehicle_stock");
                    }

                    if (Business.business_list[business_id].business_Safe < dealership_vehicle_price)
                    {
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Ihr Unternehmen hat nicht genug Geld im Safe, um diese Aktie zu kaufen.", 5000);
                        return;
                    }

                    Business.business_list[business_id].business_Safe = Business.business_list[business_id].business_Safe - dealership_vehicle_price;
                    Business.SaveBusiness(business_id);

                    int new_stock = old_stock + dealership_vehicle_stock;
                    Main.CreateMySqlCommand("UPDATE business_vehicles SET vehicle_stock = '" + new_stock + "' WHERE `vehicle_model` = '" + dealership_vehicle_name + "' AND `business_id` = '" + business_id + "'");

                    handelskammersteuer = Convert.ToInt32(System.Math.Ceiling(Convert.ToDouble(dealership_vehicle_price.ToString("N0")) / Convert.ToDouble(100) * 19 * dealership_vehicle_stock));
                    NAPI.Notification.SendNotificationToPlayer(player, "Fahrzeug: ~y~" + dealership_vehicle_name + " \n Kosten: ~g~$" + dealership_vehicle_price.ToString("N0") + " \n ~w~Steuer: ~g~$~y~" + handelskammersteuer + " \n Verwenden Sie das Unternehmensmenü, um es zu aktivieren.");

                    Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du hast einen " + dealership_vehicle_stock + " von " + dealership_vehicle_name + " gekauft. Neuer Stand: $" + Business.business_list[business_id].business_Safe.ToString("N0") + "", 5000);
                    ShowDealershipManage(player);
                }
            }
        }
    }
    [RemoteEvent("vehicle_save_business")]
    public void SaveVehicleToBusiness(Client player, string name, int price, int new_state)
    {
        int business_id = Business.GetPlayerInBusinessInDealership(player);

        if (business_id == -1)
        {
            Main.DisplayErrorMessage(player, "Sie haben keine Firma mehr.");
            player.TriggerEvent("Destroy_Character_Menu");
            return;
        }

        if (Business.business_list[business_id].business_OwnerID != AccountManage.GetPlayerSQLID(player))
        {
            Main.DisplayErrorMessage(player, "Sie haben keine Firma mehr.");
            player.TriggerEvent("Destroy_Character_Menu");
            return;
        }

        string EditingModel = name;

        int amount = 0;

        if (!int.TryParse(price.ToString(), out amount))
        {
            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Ungültiger Betrag.", 5000);
            return;
        }

        if (amount < 1) return;

        Main.CreateMySqlCommand("UPDATE `business_vehicles` SET `vehicle_status` = '" + new_state + "' WHERE `business_id` = '" + business_id + "' AND `vehicle_model` = '" + EditingModel + "';");
        Main.CreateMySqlCommand("UPDATE `business_vehicles` SET `vehicle_price` = '" + amount + "' WHERE `business_id` = '" + business_id + "' AND `vehicle_model` = '" + EditingModel + "';");

        string response = "";
        if(new_state == 1)
        {
            response = "~g~ja";
        }
        else
        {
            response = "nein";
        }

        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Fahrzeug "+name+ " aktualisiert! Neuer Preis: $" + price.ToString("N0")+ " Auf die Verkaufsliste gesetzt: " + response + "", 5000);
        ShowDealershipManage(player);
    }
}
