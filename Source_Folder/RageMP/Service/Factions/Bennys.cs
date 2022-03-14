using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;
using Newtonsoft.Json;
using DerStr1k3r.Core;
using DerStr1k3r.SDK;

public class Bennys : Script
{
    public static List<dynamic> colors = new List<dynamic>();
    public static List<dynamic> metalcolors = new List<dynamic>();
    public static List<dynamic> mattecolors = new List<dynamic>();

    public static List<dynamic> chrome = new List<dynamic>();
    public static List<dynamic> windowtint = new List<dynamic>();
    public static List<dynamic> neoncolor = new List<dynamic>();
    public static List<dynamic> plates = new List<dynamic>();
    public static List<dynamic> wheelaccessories = new List<dynamic>();
    public static List<dynamic> frontwheel = new List<dynamic>();
    public static List<dynamic> backwheel = new List<dynamic>();
    public static List<dynamic> sportwheels = new List<dynamic>();
    public static List<dynamic> suvwheels = new List<dynamic>();
    public static List<dynamic> offroadwheels = new List<dynamic>();
    public static List<dynamic> tunerwheels = new List<dynamic>();
    public static List<dynamic> highendwheels = new List<dynamic>();
    public static List<dynamic> lowriderwheels = new List<dynamic>();
    public static List<dynamic> musclewheels = new List<dynamic>();
    public static List<dynamic> Turbo = new List<dynamic>();
    public static List<dynamic> Armor = new List<dynamic>();
    public static List<dynamic> Suspension = new List<dynamic>();
    public static List<dynamic> Horn = new List<dynamic>();
    public static List<dynamic> Transmission = new List<dynamic>();
    public static List<dynamic> Brakes = new List<dynamic>();
    public static List<dynamic> Engine = new List<dynamic>();
    public static List<dynamic> neonlayout = new List<dynamic>();
    public static List<dynamic> Headlights = new List<dynamic>();


    public static int AEROFOLIO_PRICE = 1250, AEROFOLIO_PRICE_INCREASE = 650,
        SAIAS_PRICE = 850, SAIAS_PRICE_INCREASE = 310,
        ESCAPES_PRICE = 900, ESCAPES_PRICE_INCREASE = 350,
        GRADES_PRICE = 800, GRADES_PRICE_INCREASE = 270,
        CAPO_PRICE = 1300, CAPO_PRICE_INCREASE = 733,
        PARALAMAS_PRICE = 900, PARALAMAS_PRICE_INCREASE = 370,
        TETO_PRICE = 1150, TETO_PRICE_INCREASE = 500,
        LIVERIES_PRICE = 3100, LIVERIES_PRICE_INCREASE = 800,
        PARACHOQUEFRONTAL_PRICE = 1150, PARACHOQUEFRONTAL_PRICE_INCREASE = 680,
        PARACHOQUETRASEIRO_PRICE = 1050, PARACHOQUETRASEIRO_PRICE_INCREASE = 630,
        FAROLPERSONALIZADO_PRICE = 850, FAROLPERSONALIZADO_PRICE_INCREASE = 420,
        ANTENAS_PRICE = 530, ANTENAS_PRICE_INCREASE = 200,
        SAIDADEAR_PRICE = 450, SAIDADEAR_PRICE_INCREASE = 320,
        TANQUE_PRICE = 380, TANQUE_PRICE_INCREASE = 150,
        VIDRO_PRICE = 320, VIDRO_PRICE_INCREASE = 90,
        SANTANTONIO_PRICE = 1100, SANTANTONIO_PRICE_INCREASE = 488,
        COLORCLASSIC_PRICE = 3250, COLORCLASSIC_PRICE_INCREASE = 0,
        COLORMETAL_PRICE = 5800, COLORMETAL_PRICE_INCREASE = 0,
        MATTECOLOR_PRICE = 6500, MATTECOLOR_PRICE_INCREASE = 0,
        CHROMECOLOR_PRICE = 30000, CHROMECOLOR_PRICE_INCREASE = 0,
        METTALICCOLOR_PRICE = 5800, METTALICCOLOR_PRICE_INCREASE = 0,
        FRONTWHEEL_PRICE = 2500, FRONTWHEEL_PRICE_INCREASE = 0,
        BACKWHEEL_PRICE = 2500, BACKWHEEL_PRICE_INCREASE = 0,
        SPORTWHEEL_PRICE = 8200, SPORTWHEEL_PRICE_INCREASE = 100,
        SUVWHEEL_PRICE = 4200, SUVWHEEL_PRICE_INCREASE = 50,
        OFFROADWHEEL_PRICE = 4100, OFROADWHEEL_PRICE_INCREASE = 70,
        TUNERWHEEL_PRICE = 4500, TUNERWHEEL_PRICE_INCREASE = 85,
        HIGHENDWHELL_PRICE = 13000, HIGHENDWHELL_PRICE_INCREASE = 250,
        LOWRIDERWHEEL_PRICE = 4300, LOWRIDERWHEEL_PRICE_INCREASE = 30,
        MUSCLEWHEEL_PRICE = 3900, MUSCLEWHEEL_PRICE_INCREASE = 20,
        HEADLIGHTS_PRICE = 2800, HEADLIGHTS_PRICE_INCREASE = 500,
        TURBO_PRICE = 40000, TURBO_PRICE_INCREASE = 0,
        ARMOR_PRICE = 36000, ARMOR_PRICE_INCREASE = 10000,
        SUSPENSION_PRICE = 10000, SUSPENSION_PRICE_INCREASE = 5000,
        HORN_PRICE = 1500, HORN_PRICE_INCREASE = 480,
        TRANSMISSION_PRICE = 10000, TRANSMISSION_PRICE_INCREASE = 7500,
        BRAKES_PRICE = 8500, BRAKES_PRICE_INCREASE = 4000,
        ENGINE_PRICE = 18000, ENGINE_PRICE_INCREASE = 6800,
        NEONCOLOR_PRICE = 8000, NEONCOLOR_PRICE_INCREASE = 0,
        WHEELCOLOR_PRICE = 5000, WHEELCOLOR_PRICE_INCREASE = 0,
        TYREARMOR_PRICE = 75000, TYREARMOR_PRICE_INCREASE = 0,
        PLATE_PRICE = 500, PLATE_PRICE_INCREASE = 250;



    public Bennys()
    {

        colors.Add(new { name = "Black", colorindex = 0 });
        colors.Add(new { name = "Carbon Black", colorindex = 147 });
        colors.Add(new { name = "Hraphite", colorindex = 1 });
        colors.Add(new { name = "Anhracite Black", colorindex = 11 });
        colors.Add(new { name = "Black Steel", colorindex = 2 });
        colors.Add(new { name = "Dark Steel", colorindex = 3 });
        colors.Add(new { name = "Silver", colorindex = 4 });
        colors.Add(new { name = "Bluish Silver", colorindex = 5 });
        colors.Add(new { name = "Rolled Steel", colorindex = 6 });
        colors.Add(new { name = "Shadow Silver", colorindex = 7 });
        colors.Add(new { name = "Stone Silver", colorindex = 8 });
        colors.Add(new { name = "Midnight Silver", colorindex = 9 });
        colors.Add(new { name = "Cast Iron Silver", colorindex = 10 });
        colors.Add(new { name = "Red", colorindex = 27 });
        colors.Add(new { name = "Torino Red", colorindex = 28 });
        colors.Add(new { name = "Formula Red", colorindex = 29 });
        colors.Add(new { name = "Lava Red", colorindex = 150 });
        colors.Add(new { name = "Blaze Red", colorindex = 30 });
        colors.Add(new { name = "Grace Red", colorindex = 31 });
        colors.Add(new { name = "Garnet Red", colorindex = 32 });
        colors.Add(new { name = "Sunset Red", colorindex = 33 });
        colors.Add(new { name = "Cabernet Red", colorindex = 34 });
        colors.Add(new { name = "Wine Red", colorindex = 143 });
        colors.Add(new { name = "Candy Red", colorindex = 35 });
        colors.Add(new { name = "Hot Pink", colorindex = 135 });
        colors.Add(new { name = "Pfsiter Pink", colorindex = 137 });
        colors.Add(new { name = "Salmon Pink", colorindex = 136 });
        colors.Add(new { name = "Sunrise Orange", colorindex = 36 });
        colors.Add(new { name = "Orange", colorindex = 38 });
        colors.Add(new { name = "Bright Orange", colorindex = 138 });
        colors.Add(new { name = "Gold", colorindex = 99 });
        colors.Add(new { name = "Bronze", colorindex = 90 });
        colors.Add(new { name = "Yellow", colorindex = 88 });
        colors.Add(new { name = "Race Yellow", colorindex = 89 });
        colors.Add(new { name = "Dew Yellow", colorindex = 91 });
        colors.Add(new { name = "Dark Green", colorindex = 49 });
        colors.Add(new { name = "Racing Green", colorindex = 50 });
        colors.Add(new { name = "Sea Green", colorindex = 51 });
        colors.Add(new { name = "Olive Green", colorindex = 52 });
        colors.Add(new { name = "Bright Green", colorindex = 53 });
        colors.Add(new { name = "Gasoline Green", colorindex = 54 });
        colors.Add(new { name = "Lime Green", colorindex = 92 });
        colors.Add(new { name = "Midnight Blue", colorindex = 141 });
        colors.Add(new { name = "Galaxy Blue", colorindex = 61 });
        colors.Add(new { name = "Dark Blue", colorindex = 62 });
        colors.Add(new { name = "Saxon Blue", colorindex = 63 });
        colors.Add(new { name = "Blue", colorindex = 64 });
        colors.Add(new { name = "Mariner Blue", colorindex = 65 });
        colors.Add(new { name = "Harbor Blue", colorindex = 66 });
        colors.Add(new { name = "Diamond Blue", colorindex = 67 });
        colors.Add(new { name = "Surf Blue", colorindex = 68 });
        colors.Add(new { name = "Nautical Blue", colorindex = 69 });
        colors.Add(new { name = "Racing Blue", colorindex = 73 });
        colors.Add(new { name = "Ultra Blue", colorindex = 70 });
        colors.Add(new { name = "Light Blue", colorindex = 74 });
        colors.Add(new { name = "Chocolate Brown", colorindex = 96 });
        colors.Add(new { name = "Bison Brown", colorindex = 101 });
        colors.Add(new { name = "Creeen Brown", colorindex = 95 });
        colors.Add(new { name = "Feltzer Brown", colorindex = 94 });
        colors.Add(new { name = "Maple Brown", colorindex = 97 });
        colors.Add(new { name = "Beechwood Brown", colorindex = 103 });
        colors.Add(new { name = "Sienna Brown", colorindex = 104 });
        colors.Add(new { name = "Saddle Brown", colorindex = 98 });
        colors.Add(new { name = "Moss Brown", colorindex = 100 });
        colors.Add(new { name = "Woodbeech Brown", colorindex = 102 });
        colors.Add(new { name = "Straw Brown", colorindex = 99 });
        colors.Add(new { name = "Sandy Brown", colorindex = 105 });
        colors.Add(new { name = "Bleached Brown", colorindex = 106 });
        colors.Add(new { name = "Schafter Purple", colorindex = 71 });
        colors.Add(new { name = "Spinnaker Purple", colorindex = 72 });
        colors.Add(new { name = "Midnight Purple", colorindex = 142 });
        colors.Add(new { name = "Bright Purple", colorindex = 145 });
        colors.Add(new { name = "Cream", colorindex = 107 });
        colors.Add(new { name = "Ice White", colorindex = 111 });
        colors.Add(new { name = "Frost White", colorindex = 112 });

        metalcolors.Add(new { name = "Brushed Steel", colorindex = 117 });
        metalcolors.Add(new { name = "Brushed Black Steel", colorindex = 118 });
        metalcolors.Add(new { name = "Brushed Aluminum", colorindex = 119 });
        metalcolors.Add(new { name = "Pure Gold", colorindex = 158 });
        metalcolors.Add(new { name = "Brushed Gold", colorindex = 159 });

        mattecolors.Add(new { name = "Black", colorindex = 12 });
        mattecolors.Add(new { name = "Gray", colorindex = 13 });
        mattecolors.Add(new { name = "Light Gray", colorindex = 14 });
        mattecolors.Add(new { name = "Ice White", colorindex = 131 });
        mattecolors.Add(new { name = "Blue", colorindex = 83 });
        mattecolors.Add(new { name = "Dark Blue", colorindex = 82 });
        mattecolors.Add(new { name = "Midnight Blue", colorindex = 84 });
        mattecolors.Add(new { name = "Midnight Purple", colorindex = 149 });
        mattecolors.Add(new { name = "Schafter Purple", colorindex = 148 });
        mattecolors.Add(new { name = "Red", colorindex = 39 });
        mattecolors.Add(new { name = "Dark Red", colorindex = 40 });
        mattecolors.Add(new { name = "Orange", colorindex = 41 });
        mattecolors.Add(new { name = "Yellow", colorindex = 42 });
        mattecolors.Add(new { name = "Lime Green", colorindex = 55 });
        mattecolors.Add(new { name = "Green", colorindex = 128 });
        mattecolors.Add(new { name = "Frost Green", colorindex = 151 });
        mattecolors.Add(new { name = "Foliage Green", colorindex = 155 });
        mattecolors.Add(new { name = "Olive Darb", colorindex = 152 });
        mattecolors.Add(new { name = "Dark Earth", colorindex = 153 });
        mattecolors.Add(new { name = "Desert Tan", colorindex = 154 });


        chrome.Add(new { name = "Chrome", colorindex = 120 });


        windowtint.Add(new { name = "Original", tint = -1, price = 1000 });
        windowtint.Add(new { name = "Darksmoke", tint = 2, price = 1000 });
        windowtint.Add(new { name = "Lightsmoke", tint = 3, price = 1000 });
        windowtint.Add(new { name = "Limo", tint = 4, price = 1000 });
        windowtint.Add(new { name = "Green", tint = 5, price = 1000 });
        windowtint.Add(new { name = "Pure Black", tint = 1, price = 1000 });

        neonlayout.Add(new { name = "Front,Back and Sides", price = 5000 });

        neoncolor.Add(new { name = "Original", neon = new Color(0, 0, 0), price = 1000 });
        neoncolor.Add(new { name = "White", neon = new Color(254, 254, 254), price = 1000 });
        neoncolor.Add(new { name = "Blue", neon = new Color(0, 0, 255), price = 1000 });
        neoncolor.Add(new { name = "Electric Blue", neon = new Color(0, 150, 255), price = 1000 });
        neoncolor.Add(new { name = "Mint Green", neon = new Color(50, 255, 155), price = 1000 });
        neoncolor.Add(new { name = "Lime Green", neon = new Color(0, 255, 0), price = 1000 });
        neoncolor.Add(new { name = "Yellow", neon = new Color(255, 255, 0), price = 1000 });
        neoncolor.Add(new { name = "Golden Shower", neon = new Color(204, 204, 0), price = 1000 });
        neoncolor.Add(new { name = "Orange", neon = new Color(255, 128, 0), price = 1000 });
        neoncolor.Add(new { name = "Red", neon = new Color(255, 0, 0), price = 1000 });
        neoncolor.Add(new { name = "Pony Pink", neon = new Color(255, 102, 255), price = 1000 });
        neoncolor.Add(new { name = "Hot Pink", neon = new Color(255, 0, 255), price = 1000 });
        neoncolor.Add(new { name = "Purple", neon = new Color(153, 0, 153), price = 1000 });
        neoncolor.Add(new { name = "Brown", neon = new Color(139, 69, 19), price = 1000 });

        plates.Add(new { name = "Original", plateindex = -1, price = 200 });
        plates.Add(new { name = "Blue on White 1", plateindex = 0, price = 200 });
        plates.Add(new { name = "Blue On White 2", plateindex = 3, price = 200 });
        plates.Add(new { name = "Blue On White 3", plateindex = 4, price = 200 });
        plates.Add(new { name = "Yellow on Blue", plateindex = 2, price = 300 });
        plates.Add(new { name = "Yellow on Black", plateindex = 1, price = 600 });

        wheelaccessories.Add(new { name = "Original", price = 1000 });
        //wheelaccessories.Add(new { name = "Pneu Customizado", price = 1250 });
        wheelaccessories.Add(new { name = "Pneu a Prova de Balas", price = 5000 });
        /* wheelaccessories.Add(new { name = "Fumaça de Pneu Branco", smokecolor = new Color(254, 254, 254), price = 3000 });
         wheelaccessories.Add(new { name = "Fumaça de Pneu Preto", smokecolor = new Color(1, 1, 1), price = 3000 });
         wheelaccessories.Add(new { name = "Fumaça de Pneu Azul", smokecolor = new Color(0, 150, 255), price = 3000 });
         wheelaccessories.Add(new { name = "Fumaça de Pneu Amarelo", smokecolor = new Color(255, 255, 50), price = 3000 });
         wheelaccessories.Add(new { name = "Fumaça de Pneu Laranja", smokecolor = new Color(255, 153, 51), price = 3000 });
         wheelaccessories.Add(new { name = "Fumaça de Pneu Vermelho", smokecolor = new Color(255, 10, 10), price = 3000 });
         wheelaccessories.Add(new { name = "Fumaça de Pneu Verde", smokecolor = new Color(10, 255, 10), price = 3000 });
         wheelaccessories.Add(new { name = "Fumaça de Pneu Roxo", smokecolor = new Color(153, 10, 153), price = 3000 });
         wheelaccessories.Add(new { name = "Fumaça de Pneu Rosa", smokecolor = new Color(255, 102, 178), price = 3000 });
         wheelaccessories.Add(new { name = "Fumaça de Pneu Cinza", smokecolor = new Color(128, 128, 128), price = 3000 });*/

        frontwheel.Add(new { name = "Original", wtype = 6, mod = -1, price = 1000 });
        frontwheel.Add(new { name = "Speedway", wtype = 6, mod = 0, price = 1000 });
        frontwheel.Add(new { name = "Streetspecial", wtype = 6, mod = 1, price = 1000 });
        frontwheel.Add(new { name = "Racer", wtype = 6, mod = 2, price = 1000 });
        frontwheel.Add(new { name = "Trackstar", wtype = 6, mod = 3, price = 1000 });
        frontwheel.Add(new { name = "Overlord", wtype = 6, mod = 4, price = 1000 });
        frontwheel.Add(new { name = "Trident", wtype = 6, mod = 5, price = 1000 });
        frontwheel.Add(new { name = "Triplethreat", wtype = 6, mod = 6, price = 1000 });
        frontwheel.Add(new { name = "Stilleto", wtype = 6, mod = 7, price = 1000 });
        frontwheel.Add(new { name = "Wires", wtype = 6, mod = 8, price = 1000 });
        frontwheel.Add(new { name = "Bobber", wtype = 6, mod = 9, price = 1000 });
        frontwheel.Add(new { name = "Solidus", wtype = 6, mod = 10, price = 1000 });
        frontwheel.Add(new { name = "Iceshield", wtype = 6, mod = 11, price = 1000 });
        frontwheel.Add(new { name = "Loops", wtype = 6, mod = 12, price = 1000 });

        backwheel.Add(new { name = "Original", wtype = 6, mod = -1, price = 1000 });
        backwheel.Add(new { name = "Speedway", wtype = 6, mod = 0, price = 1000 });
        backwheel.Add(new { name = "Streetspecial", wtype = 6, mod = 1, price = 1000 });
        backwheel.Add(new { name = "Racer", wtype = 6, mod = 2, price = 1000 });
        backwheel.Add(new { name = "Trackstar", wtype = 6, mod = 3, price = 1000 });
        backwheel.Add(new { name = "Overlord", wtype = 6, mod = 4, price = 1000 });
        backwheel.Add(new { name = "Trident", wtype = 6, mod = 5, price = 1000 });
        backwheel.Add(new { name = "Triplethreat", wtype = 6, mod = 6, price = 1000 });
        backwheel.Add(new { name = "Stilleto", wtype = 6, mod = 7, price = 1000 });
        backwheel.Add(new { name = "Wires", wtype = 6, mod = 8, price = 1000 });
        backwheel.Add(new { name = "Bobber", wtype = 6, mod = 9, price = 1000 });
        backwheel.Add(new { name = "Solidus", wtype = 6, mod = 10, price = 1000 });
        backwheel.Add(new { name = "Iceshield", wtype = 6, mod = 11, price = 1000 });
        backwheel.Add(new { name = "Loops", wtype = 6, mod = 12, price = 1000 });

        sportwheels.Add(new { name = "Original", wtype = 0, mod = -1, price = 1000 });
        sportwheels.Add(new { name = "Inferno", wtype = 0, mod = 0, price = 1000 });
        sportwheels.Add(new { name = "Deepfive", wtype = 0, mod = 1, price = 1000 });
        sportwheels.Add(new { name = "Lozspeed", wtype = 0, mod = 2, price = 1000 });
        sportwheels.Add(new { name = "Diamondcut", wtype = 0, mod = 3, price = 1000 });
        sportwheels.Add(new { name = "Chrono", wtype = 0, mod = 4, price = 1000 });
        sportwheels.Add(new { name = "Feroccirr", wtype = 0, mod = 5, price = 1000 });
        sportwheels.Add(new { name = "Fiftynine", wtype = 0, mod = 6, price = 1000 });
        sportwheels.Add(new { name = "Mercie", wtype = 0, mod = 7, price = 1000 });
        sportwheels.Add(new { name = "Syntheticz", wtype = 0, mod = 8, price = 1000 });
        sportwheels.Add(new { name = "Organictyped", wtype = 0, mod = 9, price = 1000 });
        sportwheels.Add(new { name = "Endov1", wtype = 0, mod = 10, price = 1000 });
        sportwheels.Add(new { name = "Duper7", wtype = 0, mod = 11, price = 1000 });
        sportwheels.Add(new { name = "Uzer", wtype = 0, mod = 12, price = 1000 });
        sportwheels.Add(new { name = "Groundride", wtype = 0, mod = 13, price = 1000 });
        sportwheels.Add(new { name = "Spacer", wtype = 0, mod = 14, price = 1000 });
        sportwheels.Add(new { name = "Venum", wtype = 0, mod = 15, price = 1000 });
        sportwheels.Add(new { name = "Cosmo", wtype = 0, mod = 16, price = 1000 });
        sportwheels.Add(new { name = "Dashvip", wtype = 0, mod = 17, price = 1000 });
        sportwheels.Add(new { name = "Icekid", wtype = 0, mod = 18, price = 1000 });
        sportwheels.Add(new { name = "Ruffeld", wtype = 0, mod = 19, price = 1000 });
        sportwheels.Add(new { name = "Wangenmaster", wtype = 0, mod = 20, price = 1000 });
        sportwheels.Add(new { name = "Superfive", wtype = 0, mod = 21, price = 1000 });
        sportwheels.Add(new { name = "Endov2", wtype = 0, mod = 22, price = 1000 });
        sportwheels.Add(new { name = "Slitsix", wtype = 0, mod = 23, price = 1000 });


        suvwheels.Add(new { name = "Original", wtype = 3, mod = -1, price = 1000 });
        suvwheels.Add(new { name = "Vip", wtype = 3, mod = 0, price = 1000 });
        suvwheels.Add(new { name = "Benefactor", wtype = 3, mod = 1, price = 1000 });
        suvwheels.Add(new { name = "Cosmo", wtype = 3, mod = 2, price = 1000 });
        suvwheels.Add(new { name = "Bippu", wtype = 3, mod = 3, price = 1000 });
        suvwheels.Add(new { name = "Royalsix", wtype = 3, mod = 4, price = 1000 });
        suvwheels.Add(new { name = "Fagorme", wtype = 3, mod = 5, price = 1000 });
        suvwheels.Add(new { name = "Deluxe", wtype = 3, mod = 6, price = 1000 });
        suvwheels.Add(new { name = "Icedout", wtype = 3, mod = 7, price = 1000 });
        suvwheels.Add(new { name = "Cognscenti", wtype = 3, mod = 8, price = 1000 });
        suvwheels.Add(new { name = "Lozspeedten", wtype = 3, mod = 9, price = 1000 });
        suvwheels.Add(new { name = "Supernova", wtype = 3, mod = 10, price = 1000 });
        suvwheels.Add(new { name = "Obeyrs", wtype = 3, mod = 11, price = 1000 });
        suvwheels.Add(new { name = "Lozspeedballer", wtype = 3, mod = 12, price = 1000 });
        suvwheels.Add(new { name = "Extra vaganzo", wtype = 3, mod = 13, price = 1000 });
        suvwheels.Add(new { name = "Splitsix", wtype = 3, mod = 14, price = 1000 });
        suvwheels.Add(new { name = "Empowered", wtype = 3, mod = 15, price = 1000 });
        suvwheels.Add(new { name = "Sunrise", wtype = 3, mod = 16, price = 1000 });
        suvwheels.Add(new { name = "Dashvip", wtype = 3, mod = 17, price = 1000 });
        suvwheels.Add(new { name = "Cutter", wtype = 3, mod = 18, price = 1000 });


        offroadwheels.Add(new { name = "Original", wtype = 4, mod = -1, price = 1000 });
        offroadwheels.Add(new { name = "Raider", wtype = 4, mod = 0, price = 1000 });
        offroadwheels.Add(new { name = "Mudslinger", wtype = 4, mod = 1, price = 1000 });
        offroadwheels.Add(new { name = "Nevis", wtype = 4, mod = 2, price = 1000 });
        offroadwheels.Add(new { name = "Cairngorm", wtype = 4, mod = 3, price = 1000 });
        offroadwheels.Add(new { name = "Amazon", wtype = 4, mod = 4, price = 1000 });
        offroadwheels.Add(new { name = "Challenger", wtype = 4, mod = 5, price = 1000 });
        offroadwheels.Add(new { name = "Dunebasher", wtype = 4, mod = 6, price = 1000 });
        offroadwheels.Add(new { name = "Fivestar", wtype = 4, mod = 7, price = 1000 });
        offroadwheels.Add(new { name = "Rockcrawler", wtype = 4, mod = 8, price = 1000 });
        offroadwheels.Add(new { name = "Milspecsteelie", wtype = 4, mod = 9, price = 1000 });

        tunerwheels.Add(new { name = "Original", wtype = 5, mod = -1, price = 1000 });
        tunerwheels.Add(new { name = "Cosmo", wtype = 5, mod = 0, price = 1000 });
        tunerwheels.Add(new { name = "Supermesh", wtype = 5, mod = 1, price = 1000 });
        tunerwheels.Add(new { name = "Outsider", wtype = 5, mod = 2, price = 1000 });
        tunerwheels.Add(new { name = "Rollas", wtype = 5, mod = 3, price = 1000 });
        tunerwheels.Add(new { name = "Driffmeister", wtype = 5, mod = 4, price = 1000 });
        tunerwheels.Add(new { name = "Slicer", wtype = 5, mod = 5, price = 1000 });
        tunerwheels.Add(new { name = "Elquatro", wtype = 5, mod = 6, price = 1000 });
        tunerwheels.Add(new { name = "Dubbed", wtype = 5, mod = 7, price = 1000 });
        tunerwheels.Add(new { name = "Fivestar", wtype = 5, mod = 8, price = 1000 });
        tunerwheels.Add(new { name = "Slideways", wtype = 5, mod = 9, price = 1000 });
        tunerwheels.Add(new { name = "Apex", wtype = 5, mod = 10, price = 1000 });
        tunerwheels.Add(new { name = "Stancedeg", wtype = 5, mod = 11, price = 1000 });
        tunerwheels.Add(new { name = "Countersteer", wtype = 5, mod = 12, price = 1000 });
        tunerwheels.Add(new { name = "Endov1", wtype = 5, mod = 13, price = 1000 });
        tunerwheels.Add(new { name = "Endov2dish", wtype = 5, mod = 14, price = 1000 });
        tunerwheels.Add(new { name = "Guppez", wtype = 5, mod = 15, price = 1000 });
        tunerwheels.Add(new { name = "Chokadori", wtype = 5, mod = 16, price = 1000 });
        tunerwheels.Add(new { name = "Chicane", wtype = 5, mod = 17, price = 1000 });
        tunerwheels.Add(new { name = "Saisoku", wtype = 5, mod = 18, price = 1000 });
        tunerwheels.Add(new { name = "Dishedeight", wtype = 5, mod = 19, price = 1000 });
        tunerwheels.Add(new { name = "Fujiwara", wtype = 5, mod = 20, price = 1000 });
        tunerwheels.Add(new { name = "Zokusha", wtype = 5, mod = 21, price = 1000 });
        tunerwheels.Add(new { name = "Battlevill", wtype = 5, mod = 22, price = 1000 });
        tunerwheels.Add(new { name = "Rallymaster", wtype = 5, mod = 23, price = 1000 });


        highendwheels.Add(new { name = "Original", wtype = 7, mod = -1, price = 1000 });
        highendwheels.Add(new { name = "Shadow", wtype = 7, mod = 0, price = 1000 });
        highendwheels.Add(new { name = "Hyper", wtype = 7, mod = 1, price = 1000 });
        highendwheels.Add(new { name = "Blade", wtype = 7, mod = 2, price = 1000 });
        highendwheels.Add(new { name = "Diamond", wtype = 7, mod = 3, price = 1000 });
        highendwheels.Add(new { name = "Supagee", wtype = 7, mod = 4, price = 1000 });
        highendwheels.Add(new { name = "Chromaticz", wtype = 7, mod = 5, price = 1000 });
        highendwheels.Add(new { name = "Merciechlip", wtype = 7, mod = 6, price = 1000 });
        highendwheels.Add(new { name = "Obeyrs", wtype = 7, mod = 7, price = 1000 });
        highendwheels.Add(new { name = "Gtchrome", wtype = 7, mod = 8, price = 1000 });
        highendwheels.Add(new { name = "Cheetahr", wtype = 7, mod = 9, price = 1000 });
        highendwheels.Add(new { name = "Solar", wtype = 7, mod = 10, price = 1000 });
        highendwheels.Add(new { name = "Splitten", wtype = 7, mod = 11, price = 1000 });
        highendwheels.Add(new { name = "Dashvip", wtype = 7, mod = 12, price = 1000 });
        highendwheels.Add(new { name = "Lozspeedten", wtype = 7, mod = 13, price = 1000 });
        highendwheels.Add(new { name = "Carboninferno", wtype = 7, mod = 14, price = 1000 });
        highendwheels.Add(new { name = "Carbonshadow", wtype = 7, mod = 15, price = 1000 });
        highendwheels.Add(new { name = "Carbonz", wtype = 7, mod = 16, price = 1000 });
        highendwheels.Add(new { name = "Carbonsolar", wtype = 7, mod = 17, price = 1000 });
        highendwheels.Add(new { name = "Carboncheetahr", wtype = 7, mod = 18, price = 1000 });
        highendwheels.Add(new { name = "Carbonsracer", wtype = 7, mod = 19, price = 1000 });

        lowriderwheels.Add(new { name = "Original", wtype = 2, mod = -1, price = 1000 });
        lowriderwheels.Add(new { name = "Flare", wtype = 2, mod = 0, price = 1000 });
        lowriderwheels.Add(new { name = "Wired", wtype = 2, mod = 1, price = 1000 });
        lowriderwheels.Add(new { name = "Triplegolds", wtype = 2, mod = 2, price = 1000 });
        lowriderwheels.Add(new { name = "Bigworm", wtype = 2, mod = 3, price = 1000 });
        lowriderwheels.Add(new { name = "Sevenfives", wtype = 2, mod = 4, price = 1000 });
        lowriderwheels.Add(new { name = "Splitsix", wtype = 2, mod = 5, price = 1000 });
        lowriderwheels.Add(new { name = "Freshmesh", wtype = 2, mod = 6, price = 1000 });
        lowriderwheels.Add(new { name = "Leadsled", wtype = 2, mod = 7, price = 1000 });
        lowriderwheels.Add(new { name = "Turbine", wtype = 2, mod = 8, price = 1000 });
        lowriderwheels.Add(new { name = "Superfin", wtype = 2, mod = 9, price = 1000 });
        lowriderwheels.Add(new { name = "Classicrod", wtype = 2, mod = 10, price = 1000 });
        lowriderwheels.Add(new { name = "Dollar", wtype = 2, mod = 11, price = 1000 });
        lowriderwheels.Add(new { name = "Dukes", wtype = 2, mod = 12, price = 1000 });
        lowriderwheels.Add(new { name = "Lowfive", wtype = 2, mod = 13, price = 1000 });
        lowriderwheels.Add(new { name = "Gooch", wtype = 2, mod = 14, price = 1000 });


        musclewheels.Add(new { name = "Original", wtype = 1, mod = -1, price = 1000 });
        musclewheels.Add(new { name = "Classicfive", wtype = 1, mod = 0, price = 1000 });
        musclewheels.Add(new { name = "Dukes", wtype = 1, mod = 1, price = 1000 });
        musclewheels.Add(new { name = "Musclefreak", wtype = 1, mod = 2, price = 1000 });
        musclewheels.Add(new { name = "Kracka", wtype = 1, mod = 3, price = 1000 });
        musclewheels.Add(new { name = "Azrea", wtype = 1, mod = 4, price = 1000 });
        musclewheels.Add(new { name = "Mecha", wtype = 1, mod = 5, price = 1000 });
        musclewheels.Add(new { name = "Blacktop", wtype = 1, mod = 6, price = 1000 });
        musclewheels.Add(new { name = "Dragspl", wtype = 1, mod = 7, price = 1000 });
        musclewheels.Add(new { name = "Revolver", wtype = 1, mod = 8, price = 1000 });
        musclewheels.Add(new { name = "Classicrod", wtype = 1, mod = 9, price = 1000 });
        musclewheels.Add(new { name = "Spooner", wtype = 1, mod = 10, price = 1000 });
        musclewheels.Add(new { name = "Fivestar", wtype = 1, mod = 11, price = 1000 });
        musclewheels.Add(new { name = "Oldschool", wtype = 1, mod = 12, price = 1000 });
        musclewheels.Add(new { name = "Eljefe", wtype = 1, mod = 13, price = 1000 });
        musclewheels.Add(new { name = "Dodman", wtype = 1, mod = 14, price = 1000 });
        musclewheels.Add(new { name = "Sixgun", wtype = 1, mod = 15, price = 1000 });
        musclewheels.Add(new { name = "Mercenary", wtype = 1, mod = 16, price = 1000 });

        Headlights.Add(new { name = "Xenon Original", mod = -1, price = 0 });
        Headlights.Add(new { name = "Xenon Xenon", mod = 0, price = 1625 });

        Turbo.Add(new { name = "Original", mod = -1, price = 0 });
        Turbo.Add(new { name = "Turbo", mod = 0, price = 15000 });


        Armor.Add(new { name = "Original", modtype = 16, mod = -1, price = 2500 });
        Armor.Add(new { name = "Armor Upgrade 20%", modtype = 16, mod = 0, price = 2500 });
        Armor.Add(new { name = "Armor Upgrade 40%", modtype = 16, mod = 1, price = 5000 });
        Armor.Add(new { name = "Armor Upgrade 60%", modtype = 16, mod = 2, price = 7500 });
        Armor.Add(new { name = "Armor Upgrade 80%", modtype = 16, mod = 3, price = 10000 });
        Armor.Add(new { name = "Armor Upgrade 100%", modtype = 16, mod = 4, price = 12500 });


        Suspension.Add(new { name = "Original", mod = -1, price = 1000 });
        Suspension.Add(new { name = "Lowered Suspension", mod = 0, price = 1000 });
        Suspension.Add(new { name = "Street Suspension", mod = 1, price = 2000 });
        Suspension.Add(new { name = "Sport Suspension", mod = 2, price = 3500 });
        Suspension.Add(new { name = "Competition Suspension", mod = 3, price = 4000 });


        Horn.Add(new { name = "Original", mod = -1, price = 1625 });
        Horn.Add(new { name = "Truck Horn", mod = 0, price = 1625 });
        Horn.Add(new { name = "Police Horn", mod = 1, price = 4062 });
        Horn.Add(new { name = "Clown Horn", mod = 2, price = 6500 });
        Horn.Add(new { name = "Musical Horn 1", mod = 3, price = 11375 });
        Horn.Add(new { name = "Musical Horn 2", mod = 4, price = 11375 });
        Horn.Add(new { name = "Musical Horn 3", mod = 5, price = 11375 });
        Horn.Add(new { name = "Musical Horn 4", mod = 6, price = 11375 });
        Horn.Add(new { name = "Musical Horn 5", mod = 7, price = 11375 });
        Horn.Add(new { name = "Sadtrombone Horn", mod = 8, price = 11375 });
        Horn.Add(new { name = "Calssical Horn 1", mod = 9, price = 11375 });
        Horn.Add(new { name = "Calssical Horn 2", mod = 10, price = 11375 });
        Horn.Add(new { name = "Calssical Horn 3", mod = 11, price = 11375 });
        Horn.Add(new { name = "Calssical Horn 4", mod = 12, price = 11375 });
        Horn.Add(new { name = "Calssical Horn 5", mod = 13, price = 11375 });
        Horn.Add(new { name = "Calssical Horn 6", mod = 14, price = 11375 });
        Horn.Add(new { name = "Calssical Horn 7", mod = 15, price = 11375 });
        Horn.Add(new { name = "Scaledo Horn", mod = 16, price = 11375 });
        Horn.Add(new { name = "Scalere Horn", mod = 17, price = 11375 });
        Horn.Add(new { name = "Scalemi Horn", mod = 18, price = 11375 });
        Horn.Add(new { name = "Scalefa Horn", mod = 19, price = 11375 });
        Horn.Add(new { name = "Scalesol Horn", mod = 20, price = 11375 });
        Horn.Add(new { name = "Scalela Horn", mod = 21, price = 11375 });
        Horn.Add(new { name = "Scaleti Horn", mod = 22, price = 11375 });
        Horn.Add(new { name = "Scaledo Horn High", mod = 23, price = 11375 });
        Horn.Add(new { name = "Jazz Horn 1", mod = 25, price = 11375 });
        Horn.Add(new { name = "Jazz Horn 2", mod = 26, price = 11375 });
        Horn.Add(new { name = "Jazz Horn 3", mod = 27, price = 11375 });
        Horn.Add(new { name = "Jazzloop Horn", mod = 28, price = 11375 });
        Horn.Add(new { name = "Starspangban Horn 1", mod = 29, price = 11375 });
        Horn.Add(new { name = "Starspangban Horn 2", mod = 30, price = 11375 });
        Horn.Add(new { name = "Starspangban Horn 3", mod = 31, price = 11375 });
        Horn.Add(new { name = "Starspangban Horn 4", mod = 32, price = 11375 });
        Horn.Add(new { name = "Classicalloop Horn 1", mod = 33, price = 11375 });
        Horn.Add(new { name = "Classicalloop Horn 2", mod = 34, price = 11375 });
        Horn.Add(new { name = "Classicalloop Horn 3", mod = 35, price = 11375 });

        Transmission.Add(new { name = "Original", mod = -1, price = 10000 });
        Transmission.Add(new { name = "Street Transmission", mod = 0, price = 10000 });
        Transmission.Add(new { name = "Sports Transmission", mod = 1, price = 12500 });
        Transmission.Add(new { name = "Race Transmission", mod = 2, price = 15000 });

        Brakes.Add(new { name = "Original", mod = -1, price = 6500 });
        Brakes.Add(new { name = "Street Brakes", mod = 0, price = 6500 });
        Brakes.Add(new { name = "Sport Brakes", mod = 1, price = 8775 });
        Brakes.Add(new { name = "Race Brakes", mod = 2, price = 11375 });


        Engine.Add(new { name = "Motor Original", mod = -1, price = 4500 });
        Engine.Add(new { name = "EMS Upgrade, Level 2", mod = 0, price = 4500 });
        Engine.Add(new { name = "EMS Upgrade, Level 3", mod = 1, price = 8000 });
        Engine.Add(new { name = "EMS Upgrade, Level 4", mod = 2, price = 10500 });

        //NAPI.Marker.CreateMarker(27, new Vector3(-366.7836, -120.4633, 38.69604) - new Vector3(0, 0, 0.6f), new Vector3(), new Vector3(), 3.5f, new Color(247, 221, 52, 150));

        ls_custom.Add(new BennysEnum { position = new Vector3(-211.1027, -1323.604, 30.8904), in_use = false, vehicle = null });
        ls_custom.Add(new BennysEnum { position = new Vector3(-221.6903, -1329.618, 30.89039), in_use = false, vehicle = null });
        //ls_custom.Add(new BennysEnum { position = new Vector3(-334.7063, -136.8645, 39.00962), in_use = false, vehicle = null });

        foreach (var ls in ls_custom)
        {
            ls.label_position = API.Shared.CreateTextLabel("Bennys", ls.position + new Vector3(0, 0, 1.2f), 10.0f, 8.2f, 4, new Color(255, 255, 255, 255), false, 0);
            ls.marker_position = NAPI.Marker.CreateMarker(27, ls.position - new Vector3(0, 0, 0.9f), new Vector3(), new Vector3(), 6.0f, new Color(255, 255, 255, 255));
        }

    }

    public class BennysEnum : IEquatable<BennysEnum>

    {
        public int id { get; set; }

        public Vector3 position { get; set; }
        public Marker marker_position { get; set; }
        public TextLabel label_position { get; set; }
        public Vehicle vehicle { get; set; }
        public bool in_use { get; set; }


        public override int GetHashCode()
        {
            return id;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            BennysEnum objAsPart = obj as BennysEnum;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }

        public bool Equals(BennysEnum other)
        {
            if (other == null) return false;
            return (this.id.Equals(other.id));
        }
    }

    public static List<BennysEnum> ls_custom = new List<BennysEnum>();

    public static void PressKeyE(Client player)
    {
        int x = 0;
        foreach (var ls in ls_custom)
        {
            if (FactionManage.GetPlayerGroupType(player) == 6)
            {
                if (Main.IsInRangeOfPoint(player.Position, ls.position, 3.0f) && ls.in_use == false && player.IsInVehicle && player.VehicleSeat == -1)
            {
                player.TriggerEvent("StopVehicle");

                Vehicle vehicle = player.Vehicle;
                ls.in_use = true;
                ls.vehicle = vehicle;

                vehicle.SetData("lscustom_use", x);

                // Mods
                for (int i = 0; i < 68; i++)
                {
                    vehicle.SetData("lscustom_mod_" + i, player.Vehicle.GetMod(i));
                }

                vehicle.SetData("lscustom_color_1", vehicle.PrimaryColor);
                vehicle.SetData("lscustom_color_2", vehicle.SecondaryColor);
                vehicle.SetData("lscustom_neon", API.Shared.GetVehicleNeonState(vehicle));
                vehicle.SetData("lscustom_neon_color", vehicle.NeonColor);
                player.SetData("vehicle_mod_type", 0);
                player.SetData("vehicle_mod_index", 0);
                vehicle.SetData("primary_color_temp", vehicle.PrimaryColor);
                vehicle.SetData("secundary_color_temp", vehicle.SecondaryColor);


                //API.Shared.ConsoleOutput("" + NAPI.Vehicle.GetVehicleSecondaryColor(vehicle) + " <<<<<<<<< COLOR START");

                Create_BennysMainMenu(player);

                player.TriggerEvent("freeze", true);
                player.TriggerEvent("freezeVehicle", true);
                player.SetSharedData("DisableVehicleMove", true);

                ls.label_position.Text = "Bennys";
                return;
            }
            x++;
            }
        }
    }


    public static void Display_Bennys(Client player)
    {
        if (player.IsInVehicle && player.VehicleSeat == -1)
        {
            Vehicle vehicle = player.Vehicle;
            foreach (var ls in ls_custom)
            {
                if (ls.vehicle == vehicle)
                {
                    for (int i = 0; i < 68; i++)
                    {
                        vehicle.SetData("lscustom_mod_" + i, vehicle.GetMod(i));
                    }
                    vehicle.SetData("lscustom_color_1", vehicle.PrimaryColor);
                    vehicle.SetData("lscustom_color_2", vehicle.SecondaryColor);
                    vehicle.SetData("lscustom_neon", API.Shared.GetVehicleNeonState(vehicle));
                    vehicle.SetData("lscustom_neon_color", vehicle.NeonColor);
                    player.SetData("vehicle_mod_type", 0);
                    player.SetData("vehicle_mod_index", 0);
                    vehicle.SetData("primary_color_temp", vehicle.PrimaryColor);
                    vehicle.SetData("secundary_color_temp", vehicle.SecondaryColor);
                    Create_BennysMainMenu(player);

                    //API.Shared.ConsoleOutput("" + API.Shared.GetVehicleSecondaryColor(vehicle) + " <<<<<<<<< COLOR");
                }
            }
        }
    }

    public static void Create_BennysMainMenu(Client player)
    {
        List<dynamic> menu_item_list = new List<dynamic>();
        menu_item_list.Add(new { Type = 1, Name = "Tragflächenprofil", Description = "", RightLabel = "", Color = "Teal", HighlightColor = "White" });
        menu_item_list.Add(new { Type = 1, Name = "Saias", Description = "", RightLabel = "", Color = "LightSlateGray", HighlightColor = "White" });
        menu_item_list.Add(new { Type = 1, Name = "Fluchten", Description = "", RightLabel = "", Color = "Teal", HighlightColor = "White" });
        menu_item_list.Add(new { Type = 1, Name = "Noten", Description = "", RightLabel = "", Color = "LightSlateGray", HighlightColor = "White" });
        menu_item_list.Add(new { Type = 1, Name = "Kapuze", Description = "", RightLabel = "", Color = "Teal", HighlightColor = "White" });
        menu_item_list.Add(new { Type = 1, Name = "Kotflügel", Description = "", RightLabel = "", Color = "LightSlateGray", HighlightColor = "White" });
        menu_item_list.Add(new { Type = 1, Name = "Decke", Description = "", RightLabel = "", Color = "Teal", HighlightColor = "White" });
        menu_item_list.Add(new { Type = 1, Name = "Chassis", Description = "", RightLabel = "", Color = "LightSlateGray", HighlightColor = "White" });
        menu_item_list.Add(new { Type = 1, Name = "Benutzerdefinierte Malerei", Description = "", RightLabel = "", Color = "Teal", HighlightColor = "White" });
        menu_item_list.Add(new { Type = 1, Name = "Stoßstange", Description = "", RightLabel = "", Color = "LightSlateGray", HighlightColor = "White" });
        menu_item_list.Add(new { Type = 1, Name = "Armor", Description = "", RightLabel = "" });
        menu_item_list.Add(new { Type = 1, Name = "Bremsen", Description = "", RightLabel = "" });
        menu_item_list.Add(new { Type = 1, Name = "Transmission", Description = "", RightLabel = "" });
        menu_item_list.Add(new { Type = 1, Name = "Suspension", Description = "", RightLabel = "" });
        menu_item_list.Add(new { Type = 1, Name = "Motor", Description = "", RightLabel = "" });
        menu_item_list.Add(new { Type = 1, Name = "Turbo", Description = "", RightLabel = "" });
        menu_item_list.Add(new { Type = 1, Name = "Malerei", Description = "", RightLabel = "" });
        menu_item_list.Add(new { Type = 1, Name = "Reifen", Description = "", RightLabel = "" });
        menu_item_list.Add(new { Type = 1, Name = "Hupe", Description = "", RightLabel = "" });
        menu_item_list.Add(new { Type = 1, Name = "Kennzeichen", Description = "", RightLabel = "" });
        menu_item_list.Add(new { Type = 1, Name = "Xenon", Description = "", RightLabel = "" });
        menu_item_list.Add(new { Type = 1, Name = "Neon", Description = "", RightLabel = "" });
        menu_item_list.Add(new { Type = 1, Name = "Scheibentönung", Description = "", RightLabel = "" });
        InteractMenu.CreateMenu(player, "LSCUSTOM_MAIN", "", "~W~KATEGORIEN", true, NAPI.Util.ToJson(menu_item_list), false, BackgroundSprite: "shopui_title_carmod", MouseControl: true);
    }


    public static void ResetVehicle_Customization_Temp(Vehicle vehicle)
    {
        foreach (var ls in ls_custom)
        {
            if (ls.vehicle == vehicle)
            {
                for (int i = 0; i < 68; i++)
                {
                    if (vehicle.HasData("lscustom_mod_" + i)) vehicle.SetMod(i, vehicle.GetData("lscustom_mod_" + i));
                }

                if (vehicle.HasData("lscustom_color_1"))
                {
                    vehicle.PrimaryColor = vehicle.GetData("lscustom_color_1");
                    vehicle.SecondaryColor = vehicle.GetData("lscustom_color_2");

                    //API.Shared.SetVehicleNeonState(vehicle, vehicle.GetData("LSCUSTOM_neon"));
                    vehicle.NeonColor = vehicle.GetData("lscustom_neon_color");

                    if ((vehicle.NeonColor.Red == 0 && vehicle.NeonColor.Green == 0 && vehicle.NeonColor.Blue == 0) || (vehicle.NeonColor.Red == 255 && vehicle.NeonColor.Green == 255 && vehicle.NeonColor.Blue == 255))
                    {
                        API.Shared.SetVehicleNeonState(vehicle, false);
                    }
                    else
                    {
                        API.Shared.SetVehicleNeonState(vehicle, true);
                    }
                }
                vehicle.ResetData("lscustom_neon");
                vehicle.ResetData("lscustom_neon_color");
                vehicle.ResetData("lscustom_color_1");
                vehicle.ResetData("lscustom_color_2");

                for (int i = 0; i < 68; i++)
                {
                    vehicle.ResetData("lscustom_mod_" + i);
                }
            }
        }

    }


    public static void Hide_Bennys(Client player)
    {
        if (player.IsInVehicle && player.VehicleSeat == -1)
        {
            player.TriggerEvent("freeze", false);
            player.TriggerEvent("freezeVehicle", false);
            player.SetSharedData("DisableVehicleMove", false);

            ResetVehicle_Customization_Temp(player.Vehicle);

            foreach (var ls in Bennys.ls_custom)
            {
                if (ls.in_use == true && ls.vehicle == player.Vehicle)
                {
                    if (API.Shared.GetVehicleDriver(player.Vehicle) == null || !Main.IsInRangeOfPoint(player.Vehicle.Position, ls.position, 5.0f))
                    {

                        ls.in_use = false;
                        ls.vehicle = null;
                        ls.label_position.Text = "Strom Überladung";
                        player.Vehicle.ResetData("lscustom_use");
                    }
                }
            }
        }
    }

    public static void SelectMenuResponse(Client player, String callbackId, int selectedIndex, String objectName, String valueList)
    {
        if (!player.IsInVehicle && player.VehicleSeat != -1)
        {
            return;
        }

        int can_pass = 0;
        foreach (var ls in Bennys.ls_custom)
        {
            if (ls.in_use == true && ls.vehicle == player.Vehicle)
            {
                can_pass = 1;
            }
        }

        if (can_pass == 0)
        {
            return;
        }

        if (callbackId == "LSCUSTOM_MAIN")
        {
            List<dynamic> menu_item_list = new List<dynamic>();

            if (objectName == "Tragflächenprofil")
            {
                player.TriggerEvent("Get_Mod_Menu", 0, objectName);

            }
            else if (objectName == "Saias")
            {
                player.TriggerEvent("Get_Mod_Menu", 3, objectName);
            }
            else if (objectName == "Fluchten")
            {
                player.TriggerEvent("Get_Mod_Menu", 4, objectName);
            }
            else if (objectName == "Noten")
            {
                player.TriggerEvent("Get_Mod_Menu", 6, objectName);
            }
            else if (objectName == "Kapuze")
            {
                player.TriggerEvent("Get_Mod_Menu", 7, objectName);
            }
            else if (objectName == "Kotflügel")
            {
                player.TriggerEvent("Get_Mod_Menu", 8, objectName);
            }
            else if (objectName == "Decke")
            {
                player.TriggerEvent("Get_Mod_Menu", 10, objectName);
            }
            else if (objectName == "Bremsen")
            {
                int i = 0;
                foreach (var horn in Brakes)
                {
                    int price = 0;
                    if (i == 0)
                    {
                        price = 0;
                    }
                    else
                    {
                        price = BRAKES_PRICE + ((i - 1) * BRAKES_PRICE_INCREASE);
                    }
                    menu_item_list.Add(new { Type = 4, Name = horn.name, Description = "", RightLabel = "~s~$" + price + "" });
                    i++;
                }

                InteractMenu.CreateMenu(player, "LSCUSTOM_BRAKES", "", objectName, true, NAPI.Util.ToJson(menu_item_list), false, BackgroundSprite: "shopui_title_carmod", MouseControl: true);
            }
            else if (objectName == "Transmission")
            {
                int i = 0;
                foreach (var horn in Transmission)
                {
                    int price = 0;
                    if (i == 0)
                    {
                        price = 0;
                    }
                    else
                    {
                        price = TRANSMISSION_PRICE + ((i - 1) * TRANSMISSION_PRICE_INCREASE);
                    }
                    menu_item_list.Add(new { Type = 4, Name = horn.name, Description = "", RightLabel = "~s~$" + price + "" });
                    i++;
                }
                InteractMenu.CreateMenu(player, "LSCUSTOM_TRANSMISSION", "", objectName, true, NAPI.Util.ToJson(menu_item_list), false, BackgroundSprite: "shopui_title_carmod", MouseControl: true);
            }
            else if (objectName == "Hupe")
            {
                int i = 0;
                foreach (var horn in Horn)
                {
                    int price = 0;
                    if (i == 0)
                    {
                        price = 0;
                    }
                    else
                    {
                        price = HORN_PRICE + ((i - 1) * HORN_PRICE_INCREASE);
                    }
                    menu_item_list.Add(new { Type = 4, Name = horn.name, Description = "", RightLabel = "~s~$" + price + "" });
                    i++;
                }
                InteractMenu.CreateMenu(player, "LSCUSTOM_HORN", "", objectName, true, NAPI.Util.ToJson(menu_item_list), false, BackgroundSprite: "shopui_title_carmod", MouseControl: true);

            }
            else if (objectName == "Suspension")
            {
                int i = 0;
                foreach (var horn in Suspension)
                {
                    int price = 0;
                    if (i == 0)
                    {
                        price = 0;
                    }
                    else
                    {
                        price = SUSPENSION_PRICE + ((i - 1) * SUSPENSION_PRICE_INCREASE);
                    }
                    menu_item_list.Add(new { Type = 4, Name = horn.name, Description = "", RightLabel = "~s~$" + price + "" });
                    i++;
                }
                InteractMenu.CreateMenu(player, "LSCUSTOM_SUSPENSION", "", objectName, true, NAPI.Util.ToJson(menu_item_list), false, BackgroundSprite: "shopui_title_carmod", MouseControl: true);
            }
            else if (objectName == "Armor")
            {
                int i = 0;
                foreach (var horn in Armor)
                {
                    int price = 0;
                    if (i == 0)
                    {
                        price = 0;
                    }
                    else
                    {
                        price = ARMOR_PRICE + ((i - 1) * ARMOR_PRICE_INCREASE);
                    }
                    menu_item_list.Add(new { Type = 4, Name = horn.name, Description = "", RightLabel = "~s~$" + price + "" });
                    i++;
                }
                InteractMenu.CreateMenu(player, "LSCUSTOM_ARMOR", "", objectName, true, NAPI.Util.ToJson(menu_item_list), false, BackgroundSprite: "shopui_title_carmod", MouseControl: true);
            }
            else if (objectName == "Chassis")
            {
                menu_item_list.Add(new { Type = 1, Name = "Benutzerdefiniertes Chassis (vorne)", Description = "", RightLabel = "" });
                menu_item_list.Add(new { Type = 1, Name = "Antennen (vorne)", Description = "", RightLabel = "" });
                menu_item_list.Add(new { Type = 1, Name = "Luftauslass (oben)", Description = "", RightLabel = "" });
                menu_item_list.Add(new { Type = 1, Name = "Panzer", Description = "", RightLabel = "" });
                menu_item_list.Add(new { Type = 1, Name = "Scheibentönung", Description = "", RightLabel = "" });
                menu_item_list.Add(new { Type = 1, Name = "Santantonio", Description = "", RightLabel = "" });
                InteractMenu.CreateMenu(player, "LSCUSTOM_CHASSIS_RESPONSE", "", objectName, true, NAPI.Util.ToJson(menu_item_list), false, BackgroundSprite: "shopui_title_carmod", MouseControl: true);
            }
            else if (objectName == "Motor")
            {
                int i = 0;
                foreach (var horn in Engine)
                {
                    int price = 0;
                    if (i == 0)
                    {
                        price = 0;
                    }
                    else
                    {
                        price = ENGINE_PRICE + ((i - 1) * ENGINE_PRICE_INCREASE);
                    }
                    menu_item_list.Add(new { Type = 4, Name = horn.name, Description = "", RightLabel = "~s~$" + price + "" });
                    i++;
                }
                InteractMenu.CreateMenu(player, "LSCUSTOM_ENGINE", "", objectName, true, NAPI.Util.ToJson(menu_item_list), false, BackgroundSprite: "shopui_title_carmod", MouseControl: true);
            }
            else if (objectName == "Kennzeichen")
            {
                int i = 0;
                foreach (var horn in plates)
                {
                    int price = 0;
                    if (i == 0)
                    {
                        price = 0;
                    }
                    else
                    {
                        price = PLATE_PRICE + ((i - 1) * PLATE_PRICE_INCREASE);
                    }
                    menu_item_list.Add(new { Type = 4, Name = horn.name, Description = "", RightLabel = "~s~$" + price + "" });
                    i++;
                }
                InteractMenu.CreateMenu(player, "LSCUSTOM_PLATES", "", objectName, true, NAPI.Util.ToJson(menu_item_list), false, BackgroundSprite: "shopui_title_carmod", MouseControl: true);
            }
            else if (objectName == "Benutzerdefinierte Malerei")
            {
                player.TriggerEvent("Get_Mod_Menu", 48, objectName);
            }
            else if (objectName == "Stoßstange")
            {
                menu_item_list.Add(new { Type = 4, Name = "Stoßstange Frontal", Description = "", RightLabel = ">>" });
                menu_item_list.Add(new { Type = 4, Name = "Stoßstange Traseiro", Description = "", RightLabel = ">>" });
                InteractMenu.CreateMenu(player, "LSCUSTOM_BUMPERS", "", objectName, true, NAPI.Util.ToJson(menu_item_list), false, BackgroundSprite: "shopui_title_carmod", MouseControl: true);
            }
            else if (objectName == "Xenon")
            {
                int i = 0;
                foreach (var horn in Headlights)
                {
                    int price = 0;
                    if (i == 0)
                    {
                        price = 0;
                    }
                    else
                    {
                        price = HEADLIGHTS_PRICE + ((i - 1) * HEADLIGHTS_PRICE_INCREASE);
                    }
                    menu_item_list.Add(new { Type = 4, Name = horn.name, Description = "", RightLabel = "~s~$" + price + "" });
                    i++;
                }
                InteractMenu.CreateMenu(player, "LSCUSTOM_FAROL", "", objectName, true, NAPI.Util.ToJson(menu_item_list), false, BackgroundSprite: "shopui_title_carmod", MouseControl: true);
            }
            else if (objectName == "Malerei")
            {
                menu_item_list.Add(new { Type = 4, Name = "Grundfarbens", Description = "", RightLabel = ">>" });
                menu_item_list.Add(new { Type = 4, Name = "Sekundärfarben (Alphastatus)s", Description = "", RightLabel = ">>" });
                InteractMenu.CreateMenu(player, "LSCUSTOM_RESPRAY", "", objectName, true, NAPI.Util.ToJson(menu_item_list), false, BackgroundSprite: "shopui_title_carmod", MouseControl: true);
            }
            else if (objectName == "Reifen")
            {
                if (player.Vehicle.Class == 8)
                {
                    menu_item_list.Add(new { Type = 4, Name = "Reifen Transeira", Description = "", RightLabel = ">>" });
                    menu_item_list.Add(new { Type = 4, Name = "Reifen Frontal", Description = "", RightLabel = ">>" });
                    menu_item_list.Add(new { Type = 4, Name = "Reifen Farben", Description = "", RightLabel = ">>" });
                    menu_item_list.Add(new { Type = 4, Name = "Reifenzubehör & Farben", Description = "", RightLabel = ">>" });
                    InteractMenu.CreateMenu(player, "LSCUSTOM_BIKE_WHEELS", "", objectName, true, NAPI.Util.ToJson(menu_item_list), false, BackgroundSprite: "shopui_title_carmod", MouseControl: true);

                }
                else
                {
                    menu_item_list.Add(new { Type = 4, Name = "Reifen zu Sport", Description = "", RightLabel = ">>" });
                    menu_item_list.Add(new { Type = 4, Name = "Reifen Muscular", Description = "", RightLabel = ">>" });
                    menu_item_list.Add(new { Type = 4, Name = "Reifen Lowrider", Description = "", RightLabel = ">>" });
                    menu_item_list.Add(new { Type = 4, Name = "Reifen SUV", Description = "", RightLabel = ">>" });
                    menu_item_list.Add(new { Type = 4, Name = "Reifen Offroad", Description = "", RightLabel = ">>" });
                    menu_item_list.Add(new { Type = 4, Name = "Reifen Tunning", Description = "", RightLabel = ">>" });
                    menu_item_list.Add(new { Type = 4, Name = "Reifen zu Luxus", Description = "", RightLabel = ">>" });
                    menu_item_list.Add(new { Type = 4, Name = "Reifen Farben", Description = "", RightLabel = ">>" });
                    menu_item_list.Add(new { Type = 4, Name = "Reifenzubehör & Farben", Description = "", RightLabel = ">>" });
                    InteractMenu.CreateMenu(player, "LSCUSTOM_CAR_WHEELS", "", objectName, true, NAPI.Util.ToJson(menu_item_list), false, BackgroundSprite: "shopui_title_carmod", MouseControl: true);
                }
            }
            else if (objectName == "Turbo")
            {
                int i = 0;
                foreach (var horn in Turbo)
                {
                    int price = 0;
                    if (i == 0)
                    {
                        price = 0;
                    }
                    else
                    {
                        price = TURBO_PRICE + ((i - 1) * TURBO_PRICE_INCREASE);
                    }
                    menu_item_list.Add(new { Type = 4, Name = horn.name, Description = "", RightLabel = "~s~$" + price + "" });
                    i++;
                }
                InteractMenu.CreateMenu(player, "LSCUSTOM_TURBO", "", objectName, true, NAPI.Util.ToJson(menu_item_list), false, BackgroundSprite: "shopui_title_carmod", MouseControl: true);
            }
            else if (objectName == "Scheibentönung")
            {
                int i = 0;
                foreach (var horn in windowtint)
                {
                    int price = 0;
                    if (i == 0)
                    {
                        price = 0;
                    }
                    else
                    {
                        price = VIDRO_PRICE + ((i - 1) * VIDRO_PRICE_INCREASE);
                    }
                    menu_item_list.Add(new { Type = 4, Name = horn.name, Description = "", RightLabel = "~s~$" + price + "" });
                    i++;
                }
                InteractMenu.CreateMenu(player, "LSCUSTOM_WINDOW", "", objectName, true, NAPI.Util.ToJson(menu_item_list), false, BackgroundSprite: "shopui_title_carmod", MouseControl: true);
            }
            else if (objectName == "Neon")
            {
                int i = 0;
                foreach (var horn in neoncolor)
                {
                    int price = 0;
                    if (i == 0)
                    {
                        price = 0;
                    }
                    else
                    {
                        price = NEONCOLOR_PRICE + ((i - 1) * NEONCOLOR_PRICE_INCREASE);
                    }
                    menu_item_list.Add(new { Type = 4, Name = horn.name, Description = "", RightLabel = "~s~$" + price + "" });
                    i++;
                }
                InteractMenu.CreateMenu(player, "LSCUSTOM_NEON", "", objectName, true, NAPI.Util.ToJson(menu_item_list), false, BackgroundSprite: "shopui_title_carmod", MouseControl: true);
            }

        }
        else if (callbackId == "LSCUSTOM_NEON")
        {
            if (selectedIndex == 0)
            {
                Display_Bennys(player);
                InteractMenu_New.SendNotificationSuccess(player, "Sie haben die Änderung " + objectName + " gekauft. Dieser Artikel ist kostenlos.");
            }
            else
            {

                int price = NEONCOLOR_PRICE + ((selectedIndex - 1) * NEONCOLOR_PRICE_INCREASE);
                if (Main.GetPlayerMoney(player) < price)
                {
                    InteractMenu_New.SendNotificationError(player, "Nicht genug Geld.");
                    Hide_Bennys(player);
                    Display_Bennys(player);
                    return;
                }
                Main.GivePlayerMoney(player, -price);
                Display_Bennys(player);
                InteractMenu_New.SendNotificationSuccess(player, "Sie haben die Änderung " + objectName + " für $" + price + " gekauft.");
            }
        }
        else if (callbackId == "LSCUSTOM_CAR_WHEELS")
        {
            player.SetData("LSCUSTOM_CAR_WHEELS", selectedIndex);
            List<dynamic> menu_item_list = new List<dynamic>();
            if (selectedIndex == 0)
            {
                int i = 0;
                foreach (var horn in sportwheels)
                {
                    int price = 0;
                    if (i == 0)
                    {
                        price = 0;
                    }
                    else
                    {
                        price = SPORTWHEEL_PRICE + ((i - 1) * SPORTWHEEL_PRICE_INCREASE);
                    }
                    menu_item_list.Add(new { Type = 4, Name = horn.name, Description = "", RightLabel = "~s~$" + price + "" });
                    i++;
                }
            }
            else if (selectedIndex == 1)
            {
                int i = 0;
                foreach (var horn in musclewheels)
                {
                    int price = 0;
                    if (i == 0)
                    {
                        price = 0;
                    }
                    else
                    {
                        price = MUSCLEWHEEL_PRICE + ((i - 1) * MUSCLEWHEEL_PRICE_INCREASE);
                    }
                    menu_item_list.Add(new { Type = 4, Name = horn.name, Description = "", RightLabel = "~s~$" + price + "" });
                    i++;
                }
            }
            else if (selectedIndex == 2)
            {
                int i = 0;
                foreach (var horn in lowriderwheels)
                {
                    int price = 0;
                    if (i == 0)
                    {
                        price = 0;
                    }
                    else
                    {
                        price = LOWRIDERWHEEL_PRICE + ((i - 1) * LOWRIDERWHEEL_PRICE_INCREASE);
                    }
                    menu_item_list.Add(new { Type = 4, Name = horn.name, Description = "", RightLabel = "~s~$" + price + "" });
                    i++;
                }
            }
            else if (selectedIndex == 3)
            {
                foreach (var horn in suvwheels)
                {
                    menu_item_list.Add(new { Type = 4, Name = horn.name, Description = "", RightLabel = "~s~$" + horn.price + "" });
                }
            }
            else if (selectedIndex == 4)
            {
                int i = 0;
                foreach (var horn in offroadwheels)
                {

                    int price = 0;
                    if (i == 0)
                    {
                        price = 0;
                    }
                    else
                    {
                        price = OFFROADWHEEL_PRICE + ((i - 1) * OFROADWHEEL_PRICE_INCREASE);
                    }
                    menu_item_list.Add(new { Type = 4, Name = horn.name, Description = "", RightLabel = "~s~$" + price + "" });
                    i++;
                }
            }
            else if (selectedIndex == 5)
            {
                int i = 0;
                foreach (var horn in tunerwheels)
                {
                    int price = 0;
                    if (i == 0)
                    {
                        price = 0;
                    }
                    else
                    {
                        price = TUNERWHEEL_PRICE + ((i - 1) * TUNERWHEEL_PRICE_INCREASE);
                    }
                    menu_item_list.Add(new { Type = 4, Name = horn.name, Description = "", RightLabel = "~s~$" + price + "" });
                    i++;
                }
            }
            else if (selectedIndex == 6)
            {
                int i = 0;
                foreach (var horn in highendwheels)
                {
                    int price = 0;
                    if (i == 0)
                    {
                        price = 0;
                    }
                    else
                    {
                        price = HIGHENDWHELL_PRICE + ((i - 1) * HIGHENDWHELL_PRICE_INCREASE);
                    }
                    menu_item_list.Add(new { Type = 4, Name = horn.name, Description = "", RightLabel = "~s~$" + price + "" });
                    i++;
                }
            }
            else if (objectName == "Reifen Farben")
            {
                int i = 0;
                foreach (var horn in Main.metalic_color_list)
                {
                    int price = 0;
                    if (i == 0)
                    {
                        price = 0;
                    }
                    else
                    {
                        price = WHEELCOLOR_PRICE + (i * WHEELCOLOR_PRICE_INCREASE);
                    }
                    menu_item_list.Add(new { Type = 4, Name = horn.color_name, Description = "", RightLabel = "~s~$" + price + "" });
                    i++;


                }
            }
            else if (objectName == "Reifenzubehör & Farben")
            {
                int i = 0;
                foreach (var horn in wheelaccessories)
                {
                    int price = 0;
                    if (i == 0)
                    {
                        price = 0;
                    }
                    else
                    {
                        price = HIGHENDWHELL_PRICE + ((i - 1) * HIGHENDWHELL_PRICE_INCREASE);
                    }
                    menu_item_list.Add(new { Type = 4, Name = horn.name, Description = "", RightLabel = "~s~$" + price + "" });
                    i++;
                }
            }
            InteractMenu.CreateMenu(player, "LSCUSTOM_CAR_WHEELS_RESPONSE", "", objectName, true, NAPI.Util.ToJson(menu_item_list), false, BackgroundSprite: "shopui_title_carmod", MouseControl: true);

        }
        else if (callbackId == "LSCUSTOM_BIKE_WHEELS")
        {
            player.SetData("LSCUSTOM_BIKE_WHEELS", selectedIndex);

            List<dynamic> menu_item_list = new List<dynamic>();
            if (selectedIndex == 0)
            {
                int i = 0;
                foreach (var horn in backwheel)
                {
                    int price = 0;
                    if (i == 0)
                    {
                        price = 0;
                    }
                    else
                    {
                        price = BACKWHEEL_PRICE + ((i - 1) * BACKWHEEL_PRICE_INCREASE);
                    }
                    menu_item_list.Add(new { Type = 4, Name = horn.name, Description = "", RightLabel = "~s~$" + price + "" });
                    i++;
                }
            }
            else if (selectedIndex == 1)
            {
                int i = 0;
                foreach (var horn in frontwheel)
                {
                    int price = 0;
                    if (i == 0)
                    {
                        price = 0;
                    }
                    else
                    {
                        price = BACKWHEEL_PRICE + ((i - 1) * BACKWHEEL_PRICE_INCREASE);
                    }
                    menu_item_list.Add(new { Type = 4, Name = horn.name, Description = "", RightLabel = "~s~$" + price + "" });
                    i++;
                }
            }
            else if (selectedIndex == 2)
            {
                int i = 0;
                foreach (var horn in Main.metalic_color_list)
                {
                    int price = 0;
                    if (i == 0)
                    {
                        price = 0;
                    }
                    else
                    {
                        price = WHEELCOLOR_PRICE + (i * WHEELCOLOR_PRICE_INCREASE);
                    }
                    menu_item_list.Add(new { Type = 4, Name = horn.color_name, Description = "", RightLabel = "~s~$" + price + "" });
                    i++;
                }
            }
            else if (selectedIndex == 3)
            {
                int i = 0;
                foreach (var horn in wheelaccessories)
                {
                    int price = 0;
                    if (i == 0)
                    {
                        price = 0;
                    }
                    else
                    {
                        price = HIGHENDWHELL_PRICE + ((i - 1) * HIGHENDWHELL_PRICE_INCREASE);
                    }
                    menu_item_list.Add(new { Type = 4, Name = horn.name, Description = "", RightLabel = "~s~$" + price + "" });
                    i++;
                }
            }

            InteractMenu.CreateMenu(player, "LSCUSTOM_BIKE_WHEELS_RESPONSE", "", objectName, true, NAPI.Util.ToJson(menu_item_list), false, BackgroundSprite: "shopui_title_carmod", MouseControl: true);
        }
        else if (callbackId == "LSCUSTOM_CAR_WHEELS_RESPONSE")
        {
            if (player.GetData("LSCUSTOM_CAR_WHEELS") == 0)
            {
                if (selectedIndex == 0)
                {
                    Display_Bennys(player);
                    InteractMenu_New.SendNotificationSuccess(player, "Sie haben die Änderung " + objectName + " gekauft. Dieser Artikel ist kostenlos.");
                }
                else
                {

                    int price = SPORTWHEEL_PRICE + ((selectedIndex - 1) * SPORTWHEEL_PRICE_INCREASE);
                    if (Main.GetPlayerMoney(player) < price)
                    {
                        InteractMenu_New.SendNotificationError(player, "Nicht genug Geld.");
                        Hide_Bennys(player);
                        Display_Bennys(player);
                        return;
                    }
                    Main.GivePlayerMoney(player, -price);
                    Display_Bennys(player);
                    InteractMenu_New.SendNotificationSuccess(player, "Sie haben die Änderung " + objectName + " für $" + price + " gekauft.");
                }
            }
            else if (player.GetData("LSCUSTOM_CAR_WHEELS") == 1)
            {
                if (selectedIndex == 0)
                {
                    Display_Bennys(player);
                    InteractMenu_New.SendNotificationSuccess(player, "Sie haben die Änderung " + objectName + " gekauft. Dieser Artikel ist kostenlos.");
                }
                else
                {

                    int price = MUSCLEWHEEL_PRICE + ((selectedIndex - 1) * MUSCLEWHEEL_PRICE_INCREASE);
                    if (Main.GetPlayerMoney(player) < price)
                    {
                        InteractMenu_New.SendNotificationError(player, "Nicht genug Geld.");
                        Hide_Bennys(player);
                        Display_Bennys(player);
                        return;
                    }
                    Main.GivePlayerMoney(player, -price);
                    Display_Bennys(player);
                    InteractMenu_New.SendNotificationSuccess(player, "Sie haben die Änderung " + objectName + " für $" + price + " gekauft.");
                }
            }
            else if (player.GetData("LSCUSTOM_CAR_WHEELS") == 2)
            {
                if (selectedIndex == 0)
                {
                    Display_Bennys(player);
                    InteractMenu_New.SendNotificationSuccess(player, "Sie haben die Änderung " + objectName + " gekauft. Dieser Artikel ist kostenlos.");
                }
                else
                {

                    int price = LOWRIDERWHEEL_PRICE + ((selectedIndex - 1) * LOWRIDERWHEEL_PRICE_INCREASE);
                    if (Main.GetPlayerMoney(player) < price)
                    {
                        InteractMenu_New.SendNotificationError(player, "Nicht genug Geld.");
                        Hide_Bennys(player);
                        Display_Bennys(player);
                        return;
                    }
                    Main.GivePlayerMoney(player, -price);
                    Display_Bennys(player);
                    InteractMenu_New.SendNotificationSuccess(player, "Sie haben die Änderung " + objectName + " für $" + price + " gekauft.");
                }
            }
            else if (player.GetData("LSCUSTOM_CAR_WHEELS") == 3)
            {
                if (selectedIndex == 0)
                {
                    Display_Bennys(player);
                    InteractMenu_New.SendNotificationSuccess(player, "Sie haben die Änderung " + objectName + " gekauft. Dieser Artikel ist kostenlos.");
                }
                else
                {

                    int price = SUVWHEEL_PRICE + ((selectedIndex - 1) * SUVWHEEL_PRICE_INCREASE);
                    if (Main.GetPlayerMoney(player) < price)
                    {
                        InteractMenu_New.SendNotificationError(player, "Nicht genug Geld.");
                        Hide_Bennys(player);
                        Display_Bennys(player);
                        return;
                    }
                    Main.GivePlayerMoney(player, -price);
                    Display_Bennys(player);
                    InteractMenu_New.SendNotificationSuccess(player, "Sie haben die Änderung " + objectName + " für $" + price + " gekauft.");
                }
            }
            else if (player.GetData("LSCUSTOM_CAR_WHEELS") == 4)
            {
                if (selectedIndex == 0)
                {
                    Display_Bennys(player);
                    InteractMenu_New.SendNotificationSuccess(player, "Sie haben die Änderung " + objectName + " gekauft. Dieser Artikel ist kostenlos.");
                }
                else
                {

                    int price = OFFROADWHEEL_PRICE + ((selectedIndex - 1) * OFROADWHEEL_PRICE_INCREASE);
                    if (Main.GetPlayerMoney(player) < price)
                    {
                        InteractMenu_New.SendNotificationError(player, "Nicht genug Geld.");
                        Hide_Bennys(player);
                        Display_Bennys(player);
                        return;
                    }
                    Main.GivePlayerMoney(player, -price);
                    Display_Bennys(player);
                    InteractMenu_New.SendNotificationSuccess(player, "Sie haben die Änderung " + objectName + " für $" + price + " gekauft.");
                }

            }
            else if (player.GetData("LSCUSTOM_CAR_WHEELS") == 5)
            {
                if (selectedIndex == 0)
                {
                    Display_Bennys(player);
                    InteractMenu_New.SendNotificationSuccess(player, "Sie haben die Änderung " + objectName + " gekauft. Dieser Artikel ist kostenlos.");
                }
                else
                {
                    int price = TUNERWHEEL_PRICE + ((selectedIndex - 1) * TUNERWHEEL_PRICE_INCREASE);
                    if (Main.GetPlayerMoney(player) < price)
                    {
                        InteractMenu_New.SendNotificationError(player, "Nicht genug Geld.");
                        Hide_Bennys(player);
                        Display_Bennys(player);
                        return;
                    }
                    Main.GivePlayerMoney(player, -price);
                    Display_Bennys(player);
                    InteractMenu_New.SendNotificationSuccess(player, "Sie haben die Änderung " + objectName + " für $" + price + " gekauft.");
                }
            }
            else if (player.GetData("LSCUSTOM_CAR_WHEELS") == 6)
            {
                if (selectedIndex == 0)
                {
                    Display_Bennys(player);
                    InteractMenu_New.SendNotificationSuccess(player, "Sie haben die Änderung " + objectName + " gekauft. Dieser Artikel ist kostenlos.");
                }
                else
                {
                    int price = HIGHENDWHELL_PRICE + ((selectedIndex - 1) * HIGHENDWHELL_PRICE_INCREASE);
                    if (Main.GetPlayerMoney(player) < price)
                    {
                        InteractMenu_New.SendNotificationError(player, "Nicht genug Geld.");
                        Hide_Bennys(player);
                        Display_Bennys(player);
                        return;
                    }
                    Main.GivePlayerMoney(player, -price);
                    Display_Bennys(player);
                    InteractMenu_New.SendNotificationSuccess(player, "Sie haben die Änderung " + objectName + " für $" + price + " gekauft.");
                }
            }
            else if (player.GetData("LSCUSTOM_CAR_WHEELS") == 7)
            {
                int price = WHEELCOLOR_PRICE + (selectedIndex * WHEELCOLOR_PRICE_INCREASE);
                if (Main.GetPlayerMoney(player) < price)
                {
                    InteractMenu_New.SendNotificationError(player, "Nicht genug Geld.");
                    Hide_Bennys(player);
                    Display_Bennys(player);
                    return;
                }
                Main.GivePlayerMoney(player, -price);
                Display_Bennys(player);
                InteractMenu_New.SendNotificationSuccess(player, "Sie haben die Änderung " + objectName + " für $" + price + " gekauft.");
            }
            else if (player.GetData("LSCUSTOM_CAR_WHEELS") == 8)
            {
                if (selectedIndex == 0)
                {
                    Display_Bennys(player);
                    InteractMenu_New.SendNotificationSuccess(player, "Sie haben die Änderung " + objectName + " gekauft. Dieser Artikel ist kostenlos.");
                }
                else
                {
                    int price = TYREARMOR_PRICE + ((selectedIndex - 1) * TYREARMOR_PRICE_INCREASE);
                    if (Main.GetPlayerMoney(player) < price)
                    {
                        InteractMenu_New.SendNotificationError(player, "Nicht genug Geld.");
                        Hide_Bennys(player);
                        Display_Bennys(player);
                        return;
                    }
                    Main.GivePlayerMoney(player, -price);
                    Display_Bennys(player);
                    InteractMenu_New.SendNotificationSuccess(player, "Sie haben die Änderung " + objectName + " für $" + price + " gekauft.");
                }
            }
        }

        else if (callbackId == "LSCUSTOM_BIKE_WHEELS_RESPONSE")
        {
            if (player.GetData("LSCUSTOM_BIKE_WHEELS") == 0)
            {
                if (selectedIndex == 0)
                {
                    Display_Bennys(player);
                    InteractMenu_New.SendNotificationSuccess(player, "Sie haben die Änderung " + objectName + " gekauft. Dieser Artikel ist kostenlos.");
                }
                else
                {

                    int price = BACKWHEEL_PRICE + ((selectedIndex - 1) * BACKWHEEL_PRICE_INCREASE);
                    if (Main.GetPlayerMoney(player) < price)
                    {
                        InteractMenu_New.SendNotificationError(player, "Nicht genug Geld.");
                        Hide_Bennys(player);
                        Display_Bennys(player);
                        return;
                    }
                    Main.GivePlayerMoney(player, -price);
                    Display_Bennys(player);
                    InteractMenu_New.SendNotificationSuccess(player, "Sie haben die Änderung " + objectName + " für $" + price + " gekauft.");
                }
            }
            else if (player.GetData("LSCUSTOM_BIKE_WHEELS") == 1)
            {
                if (selectedIndex == 0)
                {
                    Display_Bennys(player);
                    InteractMenu_New.SendNotificationSuccess(player, "Sie haben die Änderung " + objectName + " gekauft. Dieser Artikel ist kostenlos.");
                }
                else
                {

                    int price = FRONTWHEEL_PRICE + ((selectedIndex - 1) * FRONTWHEEL_PRICE_INCREASE);
                    if (Main.GetPlayerMoney(player) < price)
                    {
                        InteractMenu_New.SendNotificationError(player, "Nicht genug Geld.");
                        Hide_Bennys(player);
                        Display_Bennys(player);
                        return;
                    }
                    Main.GivePlayerMoney(player, -price);
                    Display_Bennys(player);
                    InteractMenu_New.SendNotificationSuccess(player, "Sie haben die Änderung " + objectName + " für $" + price + " gekauft.");
                }
            }
            else if (player.GetData("LSCUSTOM_BIKE_WHEELS") == 2)
            {
                int price = WHEELCOLOR_PRICE + (selectedIndex * WHEELCOLOR_PRICE_INCREASE);
                if (Main.GetPlayerMoney(player) < price)
                {
                    InteractMenu_New.SendNotificationError(player, "Nicht genug Geld.");
                    Hide_Bennys(player);
                    Display_Bennys(player);
                    return;
                }
                Main.GivePlayerMoney(player, -price);
                Display_Bennys(player);
                InteractMenu_New.SendNotificationSuccess(player, "Sie haben die Änderung " + objectName + " für $" + price + " gekauft.");
            }
            else if (player.GetData("LSCUSTOM_BIKE_WHEELS") == 3)
            {
                if (selectedIndex == 0)
                {
                    Display_Bennys(player);
                    InteractMenu_New.SendNotificationSuccess(player, "Sie haben die Änderung " + objectName + " gekauft. Dieser Artikel ist kostenlos.");
                }
                else
                {
                    int price = TYREARMOR_PRICE + ((selectedIndex - 1) * TYREARMOR_PRICE_INCREASE);
                    if (Main.GetPlayerMoney(player) < price)
                    {
                        InteractMenu_New.SendNotificationError(player, "Nicht genug Geld.");
                        Hide_Bennys(player);
                        Display_Bennys(player);
                        return;
                    }
                    Main.GivePlayerMoney(player, -price);
                    Display_Bennys(player);
                    InteractMenu_New.SendNotificationSuccess(player, "Sie haben die Änderung " + objectName + " für $" + price + " gekauft.");
                }
            }
        }
        else if (callbackId == "LSCUSTOM_BUMPERS")
        {
            if (selectedIndex == 0)
            {
                player.TriggerEvent("Get_Mod_Menu", 1, objectName);
            }
            else if (selectedIndex == 1)
            {
                player.TriggerEvent("Get_Mod_Menu", 2, objectName);
            }
        }
        else if (callbackId == "LSCUSTOM_BRAKES")
        {
            if (selectedIndex == 0)
            {
                Display_Bennys(player);
                InteractMenu_New.SendNotificationSuccess(player, "Sie haben die Änderung " + objectName + " gekauft. Dieser Artikel ist kostenlos.");
            }
            else
            {

                int price = BRAKES_PRICE + ((selectedIndex - 1) * BRAKES_PRICE_INCREASE);
                if (Main.GetPlayerMoney(player) < price)
                {
                    InteractMenu_New.SendNotificationError(player, "Nicht genug Geld.");
                    Hide_Bennys(player);
                    Display_Bennys(player);
                    return;
                }
                Main.GivePlayerMoney(player, -price);
                Display_Bennys(player);
                InteractMenu_New.SendNotificationSuccess(player, "Sie haben die Änderung " + objectName + " für $" + price + " gekauft.");
            }
        }
        else if (callbackId == "LSCUSTOM_TURBO")
        {
            if (selectedIndex == 0)
            {
                Display_Bennys(player);
                InteractMenu_New.SendNotificationSuccess(player, "Sie haben die Änderung " + objectName + " gekauft. Dieser Artikel ist kostenlos.");
            }
            else
            {

                int price = TURBO_PRICE + ((selectedIndex - 1) * TURBO_PRICE_INCREASE);
                if (Main.GetPlayerMoney(player) < price)
                {
                    InteractMenu_New.SendNotificationError(player, "Nicht genug Geld.");
                    Hide_Bennys(player);
                    Display_Bennys(player);
                    return;
                }
                Main.GivePlayerMoney(player, -price);
                Display_Bennys(player);
                InteractMenu_New.SendNotificationSuccess(player, "Sie haben die Änderung " + objectName + " für $" + price + " gekauft.");
            }
        }
        else if (callbackId == "LSCUSTOM_HORN")
        {
            if (selectedIndex == 0)
            {
                Display_Bennys(player);
                InteractMenu_New.SendNotificationSuccess(player, "Sie haben die Änderung " + objectName + " gekauft. Dieser Artikel ist kostenlos.");
            }
            else
            {

                int price = HORN_PRICE + ((selectedIndex - 1) * HORN_PRICE_INCREASE);
                if (Main.GetPlayerMoney(player) < price)
                {
                    InteractMenu_New.SendNotificationError(player, "Nicht genug Geld.");
                    Hide_Bennys(player);
                    Display_Bennys(player);
                    return;
                }
                Main.GivePlayerMoney(player, -price);
                Display_Bennys(player);
                InteractMenu_New.SendNotificationSuccess(player, "Sie haben die Änderung " + objectName + " für $" + price + " gekauft.");
            }
        }
        else if (callbackId == "LSCUSTOM_TRANSMISSION")
        {
            if (selectedIndex == 0)
            {
                Display_Bennys(player);
                InteractMenu_New.SendNotificationSuccess(player, "Sie haben die Änderung " + objectName + " gekauft. Dieser Artikel ist kostenlos.");
            }
            else
            {

                int price = TRANSMISSION_PRICE + ((selectedIndex - 1) * TRANSMISSION_PRICE_INCREASE);
                if (Main.GetPlayerMoney(player) < price)
                {
                    InteractMenu_New.SendNotificationError(player, "Nicht genug Geld.");
                    Hide_Bennys(player);
                    Display_Bennys(player);
                    return;
                }
                Main.GivePlayerMoney(player, -price);
                Display_Bennys(player);
                InteractMenu_New.SendNotificationSuccess(player, "Sie haben die Änderung " + objectName + " für $" + price + " gekauft.");
            }
        }
        else if (callbackId == "LSCUSTOM_SUSPENSION")
        {
            if (selectedIndex == 0)
            {
                Display_Bennys(player);
                InteractMenu_New.SendNotificationSuccess(player, "Sie haben die Änderung " + objectName + " gekauft. Dieser Artikel ist kostenlos.");
            }
            else
            {

                int price = SUSPENSION_PRICE + ((selectedIndex - 1) * SUSPENSION_PRICE_INCREASE);
                if (Main.GetPlayerMoney(player) < price)
                {
                    InteractMenu_New.SendNotificationError(player, "Nicht genug Geld.");
                    Hide_Bennys(player);
                    Display_Bennys(player);
                    return;
                }
                Main.GivePlayerMoney(player, -price);
                Display_Bennys(player);
                InteractMenu_New.SendNotificationSuccess(player, "Sie haben die Änderung " + objectName + " für $" + price + " gekauft.");
            }
        }
        else if (callbackId == "LSCUSTOM_ARMOR")
        {
            if (selectedIndex == 0)
            {
                Display_Bennys(player);
                InteractMenu_New.SendNotificationSuccess(player, "Sie haben die Änderung " + objectName + " gekauft. Dieser Artikel ist kostenlos.");
            }
            else
            {

                int price = ARMOR_PRICE + ((selectedIndex - 1) * ARMOR_PRICE_INCREASE);
                if (Main.GetPlayerMoney(player) < price)
                {
                    InteractMenu_New.SendNotificationError(player, "Nicht genug Geld.");
                    Hide_Bennys(player);
                    Display_Bennys(player);
                    return;
                }
                Main.GivePlayerMoney(player, -price);
                Display_Bennys(player);
                InteractMenu_New.SendNotificationSuccess(player, "Sie haben die Änderung " + objectName + " für $" + price + " gekauft.");
            }
        }
        else if (callbackId == "LSCUSTOM_FAROL")
        {
            if (selectedIndex == 0)
            {
                Display_Bennys(player);
                InteractMenu_New.SendNotificationSuccess(player, "Sie haben die Änderung " + objectName + " gekauft. Dieser Artikel ist kostenlos.");
            }
            else
            {

                int price = HEADLIGHTS_PRICE + ((selectedIndex - 1) * HEADLIGHTS_PRICE_INCREASE);
                if (Main.GetPlayerMoney(player) < price)
                {
                    InteractMenu_New.SendNotificationError(player, "Nicht genug Geld.");
                    Hide_Bennys(player);
                    Display_Bennys(player);
                    return;
                }
                Main.GivePlayerMoney(player, -price);
                Display_Bennys(player);
                InteractMenu_New.SendNotificationSuccess(player, "Sie haben die Änderung " + objectName + " für $" + price + " gekauft.");
            }
        }
        if (callbackId == "LSCUSTOM_CHASSIS_RESPONSE")
        {
            if (selectedIndex == 0)
            {
                player.TriggerEvent("Get_Mod_Menu", 42, objectName);
            }
            else if (selectedIndex == 1)
            {
                player.TriggerEvent("Get_Mod_Menu", 43, objectName);
            }
            else if (selectedIndex == 2)
            {
                player.TriggerEvent("Get_Mod_Menu", 44, objectName);
            }
            else if (selectedIndex == 3)
            {
                player.TriggerEvent("Get_Mod_Menu", 45, objectName);
            }
            else if (selectedIndex == 4)
            {
                player.TriggerEvent("Get_Mod_Menu", 46, objectName);
            }
            else if (selectedIndex == 5)
            {
                player.TriggerEvent("Get_Mod_Menu", 5, objectName);
            }
        }
        else if (callbackId == "LSCUSTOM_ENGINE")
        {
            if (selectedIndex == 0)
            {
                Display_Bennys(player);
                InteractMenu_New.SendNotificationSuccess(player, "Sie haben die Änderung " + objectName + " gekauft. Dieser Artikel ist kostenlos.");
            }
            else
            {

                int price = ENGINE_PRICE + ((selectedIndex - 1) * ENGINE_PRICE_INCREASE);
                if (Main.GetPlayerMoney(player) < price)
                {
                    InteractMenu_New.SendNotificationError(player, "Nicht genug Geld.");
                    Hide_Bennys(player);
                    Display_Bennys(player);
                    return;
                }
                Main.GivePlayerMoney(player, -price);
                Display_Bennys(player);
                InteractMenu_New.SendNotificationSuccess(player, "Sie haben die Änderung " + objectName + " für $" + price + " gekauft.");
            }
        }
        else if (callbackId == "LSCUSTOM_PLATES")
        {
            if (selectedIndex == 0)
            {
                Display_Bennys(player);
                InteractMenu_New.SendNotificationSuccess(player, "Sie haben die Änderung " + objectName + " gekauft. Dieser Artikel ist kostenlos.");
            }
            else
            {

                int price = PLATE_PRICE + ((selectedIndex - 1) * PLATE_PRICE_INCREASE);
                if (Main.GetPlayerMoney(player) < price)
                {
                    InteractMenu_New.SendNotificationError(player, "Nicht genug Geld.");
                    Hide_Bennys(player);
                    Display_Bennys(player);
                    return;
                }
                Main.GivePlayerMoney(player, -price);
                Display_Bennys(player);
                InteractMenu_New.SendNotificationSuccess(player, "Sie haben die Änderung " + objectName + " für $" + price + " gekauft.");
            }
        }
        else if (callbackId == "LSCUSTOM_RESPRAY")
        {
            List<dynamic> menu_item_list = new List<dynamic>();
            menu_item_list.Add(new { Type = 1, Name = "Chromfarben", Description = "", RightLabel = "" });
            menu_item_list.Add(new { Type = 1, Name = "Malerei Classic", Description = "", RightLabel = "" });
            menu_item_list.Add(new { Type = 1, Name = "Malerei Matt", Description = "", RightLabel = "" });
            menu_item_list.Add(new { Type = 1, Name = "Malerei Metallisch", Description = "", RightLabel = "" });
            menu_item_list.Add(new { Type = 1, Name = "Malerei von Metallen", Description = "", RightLabel = "" });

            if (selectedIndex == 0)
            {
                InteractMenu.CreateMenu(player, "LSCUSTOM_COLORS", "", "~W~Grundfarben", true, NAPI.Util.ToJson(menu_item_list), false, BackgroundSprite: "shopui_title_carmod", MouseControl: true);
            }
            else
            {
                InteractMenu.CreateMenu(player, "LSCUSTOM_COLORS", "", "~W~Sekundärfarben (Alphastatus)", true, NAPI.Util.ToJson(menu_item_list), false, BackgroundSprite: "shopui_title_carmod", MouseControl: true);
            }
            player.SetData("LSCUSTOM_RESPRAY", selectedIndex);
        }
        else if (callbackId == "LSCUSTOM_COLORS")
        {
            player.SetData("LSCUSTOM_COLORS", selectedIndex);
            List<dynamic> menu_item_list = new List<dynamic>();
            if (selectedIndex == 0)
            {
                int i = 0;
                foreach (var horn in chrome)
                {
                    int price = 0;
                    if (i == 0)
                    {
                        price = 0;
                    }
                    else
                    {
                        price = CHROMECOLOR_PRICE + (i * CHROMECOLOR_PRICE_INCREASE);
                    }
                    menu_item_list.Add(new { Type = 4, Name = horn.name, Description = "", RightLabel = "~s~$" + price + "" });
                    i++;
                }
                InteractMenu.CreateMenu(player, "LSCUSTOM_SET_COLORS", "", objectName, true, NAPI.Util.ToJson(menu_item_list), false, BackgroundSprite: "shopui_title_carmod", MouseControl: true);
            }
            else if (selectedIndex == 1)
            {
                int i = 0;
                foreach (var horn in colors)
                {
                    int price = 0;
                    if (i == 0)
                    {
                        price = 0;
                    }
                    else
                    {
                        price = COLORCLASSIC_PRICE + (i * COLORCLASSIC_PRICE_INCREASE);
                    }
                    menu_item_list.Add(new { Type = 4, Name = horn.name, Description = "", RightLabel = "~s~$" + price + "" });
                    i++;
                }
                InteractMenu.CreateMenu(player, "LSCUSTOM_SET_COLORS", "", objectName, true, NAPI.Util.ToJson(menu_item_list), false, BackgroundSprite: "shopui_title_carmod", MouseControl: true);
            }
            else if (selectedIndex == 2)
            {
                int i = 0;
                foreach (var horn in mattecolors)
                {
                    int price = 0;
                    if (i == 0)
                    {
                        price = 0;
                    }
                    else
                    {
                        price = MATTECOLOR_PRICE + (i * MATTECOLOR_PRICE_INCREASE);
                    }
                    menu_item_list.Add(new { Type = 4, Name = horn.name, Description = "", RightLabel = "~s~$" + price + "" });
                    i++;
                }
                InteractMenu.CreateMenu(player, "LSCUSTOM_SET_COLORS", "", objectName, true, NAPI.Util.ToJson(menu_item_list), false, BackgroundSprite: "shopui_title_carmod", MouseControl: true);
            }
            else if (selectedIndex == 3)
            {
                int i = 0;
                foreach (var horn in Main.metalic_color_list)
                {
                    int price = 0;
                    if (i == 0)
                    {
                        price = 0;
                    }
                    else
                    {
                        price = METTALICCOLOR_PRICE + (i * METTALICCOLOR_PRICE_INCREASE);
                    }
                    menu_item_list.Add(new { Type = 4, Name = horn.color_name, Description = "", RightLabel = "~s~$" + price + "" });
                    i++;
                }
                InteractMenu.CreateMenu(player, "LSCUSTOM_SET_COLORS", "", objectName, true, NAPI.Util.ToJson(menu_item_list), false, BackgroundSprite: "shopui_title_carmod", MouseControl: true);
            }
            else if (selectedIndex == 4)
            {
                int i = 0;
                foreach (var horn in metalcolors)
                {
                    int price = 0;
                    if (i == 0)
                    {
                        price = 0;
                    }
                    else
                    {
                        price = COLORMETAL_PRICE + (i * COLORMETAL_PRICE_INCREASE);
                    }
                    menu_item_list.Add(new { Type = 4, Name = horn.name, Description = "", RightLabel = "~s~$" + price + "" });
                    i++;
                }
                InteractMenu.CreateMenu(player, "LSCUSTOM_SET_COLORS", "", "~W~Metal", true, NAPI.Util.ToJson(menu_item_list), false, BackgroundSprite: "shopui_title_carmod", MouseControl: true);
            }
        }
        else if (callbackId == "LSCUSTOM_SET_COLORS")
        {
            if (player.GetData("LSCUSTOM_COLORS") == 0)
            {
                int price = CHROMECOLOR_PRICE + (selectedIndex * CHROMECOLOR_PRICE_INCREASE);
                if (Main.GetPlayerMoney(player) < price)
                {
                    InteractMenu_New.SendNotificationError(player, "Nicht genug Geld.");
                    Hide_Bennys(player);
                    Display_Bennys(player);
                    return;
                }
                Main.GivePlayerMoney(player, -price);
                Display_Bennys(player);
                InteractMenu_New.SendNotificationSuccess(player, "Sie haben die Änderung " + objectName + " für $" + price + " gekauft.");
            }
            else if (player.GetData("LSCUSTOM_COLORS") == 1)
            {
                int price = COLORCLASSIC_PRICE + (selectedIndex * COLORCLASSIC_PRICE_INCREASE);
                if (Main.GetPlayerMoney(player) < price)
                {
                    InteractMenu_New.SendNotificationError(player, "Nicht genug Geld.");
                    Hide_Bennys(player);
                    Display_Bennys(player);
                    return;
                }
                Main.GivePlayerMoney(player, -price);
                Display_Bennys(player);
                InteractMenu_New.SendNotificationSuccess(player, "Sie haben die Änderung " + objectName + " für $" + price + " gekauft.");
            }
            else if (player.GetData("LSCUSTOM_COLORS") == 2)
            {
                int price = MATTECOLOR_PRICE + (selectedIndex * MATTECOLOR_PRICE_INCREASE);
                if (Main.GetPlayerMoney(player) < price)
                {
                    InteractMenu_New.SendNotificationError(player, "Nicht genug Geld.");
                    Hide_Bennys(player);
                    Display_Bennys(player);
                    return;
                }
                Main.GivePlayerMoney(player, -price);
                Display_Bennys(player);
                InteractMenu_New.SendNotificationSuccess(player, "Sie haben die Änderung " + objectName + " für $" + price + " gekauft.");
            }
            else if (player.GetData("LSCUSTOM_COLORS") == 3)
            {
                int price = METTALICCOLOR_PRICE + (selectedIndex * METTALICCOLOR_PRICE_INCREASE);
                if (Main.GetPlayerMoney(player) < price)
                {
                    InteractMenu_New.SendNotificationError(player, "Nicht genug Geld.");
                    Hide_Bennys(player);
                    Display_Bennys(player);
                    return;
                }
                Main.GivePlayerMoney(player, -price);
                Display_Bennys(player);
                InteractMenu_New.SendNotificationSuccess(player, "Sie haben die Änderung " + objectName + " für $" + price + " gekauft.");
            }
            else if (player.GetData("LSCUSTOM_COLORS") == 4)
            {
                int price = COLORMETAL_PRICE + (selectedIndex * COLORMETAL_PRICE_INCREASE);
                if (Main.GetPlayerMoney(player) < price)
                {
                    InteractMenu_New.SendNotificationError(player, "Nicht genug Geld.");
                    Hide_Bennys(player);
                    Display_Bennys(player);
                    return;
                }
                Main.GivePlayerMoney(player, -price);
                Display_Bennys(player);
                InteractMenu_New.SendNotificationSuccess(player, "Sie haben die Änderung " + objectName + " für $" + price + " gekauft.");
            }
        }
        else if (callbackId == "LSCUSTOM_WINDOW")
        {
            if (selectedIndex == 0)
            {
                Display_Bennys(player);
                InteractMenu_New.SendNotificationSuccess(player, "Sie haben die Änderung " + objectName + " gekauft. Dieser Artikel ist kostenlos.");
            }
            else
            {

                int price = VIDRO_PRICE + ((selectedIndex - 1) * VIDRO_PRICE_INCREASE);
                if (Main.GetPlayerMoney(player) < price)
                {
                    InteractMenu_New.SendNotificationError(player, "Nicht genug Geld.");
                    Hide_Bennys(player);
                    Display_Bennys(player);
                    return;
                }
                Main.GivePlayerMoney(player, -price);
                Display_Bennys(player);
                InteractMenu_New.SendNotificationSuccess(player, "Sie haben die Änderung " + objectName + " für $" + price + " gekauft.");
            }
        }
        else if (callbackId == "DYNAMIC_SUBMENU_LSCUSTOM")
        {
            if (objectName == "Original")
            {
                player.Vehicle.SetMod(player.GetData("vehicle_mod_type"), -1);
                Display_Bennys(player);
                InteractMenu_New.SendNotificationSuccess(player, "Sie haben die Änderung " + objectName + " gekauft. Dieser Artikel ist kostenlos.");
            }
            else
            {

                int price = 10000 + ((selectedIndex - 1) * 0);

                switch (player.GetData("vehicle_mod_type"))
                {
                    case 0: price = AEROFOLIO_PRICE + ((selectedIndex - 1) * AEROFOLIO_PRICE_INCREASE); break;
                    case 3: price = SAIAS_PRICE + ((selectedIndex - 1) * SAIAS_PRICE_INCREASE); break;
                    case 4: price = ESCAPES_PRICE + ((selectedIndex - 1) * ESCAPES_PRICE_INCREASE); break;
                    case 6: price = GRADES_PRICE + ((selectedIndex - 1) * GRADES_PRICE_INCREASE); break;
                    case 7: price = PARALAMAS_PRICE + ((selectedIndex - 1) * PARALAMAS_PRICE_INCREASE); break;
                    case 8: price = TETO_PRICE + ((selectedIndex - 1) * TETO_PRICE_INCREASE); break;
                    case 10: price = TETO_PRICE + ((selectedIndex - 1) * TETO_PRICE_INCREASE); break;
                    case 48: price = LIVERIES_PRICE + ((selectedIndex - 1) * LIVERIES_PRICE_INCREASE); break;
                    case 1: price = PARACHOQUEFRONTAL_PRICE + ((selectedIndex - 1) * PARACHOQUEFRONTAL_PRICE_INCREASE); break;
                    case 2: price = PARACHOQUETRASEIRO_PRICE + ((selectedIndex - 1) * PARACHOQUETRASEIRO_PRICE_INCREASE); break;
                    case 42: price = FAROLPERSONALIZADO_PRICE + ((selectedIndex - 1) * FAROLPERSONALIZADO_PRICE_INCREASE); break;
                    case 43: price = ANTENAS_PRICE + ((selectedIndex - 1) * ANTENAS_PRICE_INCREASE); break;
                    case 44: price = SAIDADEAR_PRICE + ((selectedIndex - 1) * SAIDADEAR_PRICE_INCREASE); break;
                    case 45: price = TANQUE_PRICE + ((selectedIndex - 1) * TANQUE_PRICE_INCREASE); break;
                    case 46: price = VIDRO_PRICE + ((selectedIndex - 1) * VIDRO_PRICE_INCREASE); break;
                    case 5: price = SANTANTONIO_PRICE + ((selectedIndex - 1) * SANTANTONIO_PRICE_INCREASE); break;
                }


                if (Main.GetPlayerMoney(player) < price)
                {
                    InteractMenu_New.SendNotificationError(player, "Nicht genug Geld.");
                    Hide_Bennys(player);
                    Display_Bennys(player);
                    return;
                }
                Main.GivePlayerMoney(player, -price);
                player.Vehicle.SetMod(player.GetData("vehicle_mod_type"), player.GetData("ListTrack_" + (selectedIndex - 1)));
                Display_Bennys(player);
                InteractMenu_New.SendNotificationSuccess(player, "Sie haben die Änderung " + objectName + " für $" + price + " gekauft.");

            }

        }
    }
    public static void IndexChangeMenuResponse(Client player, String callbackId, int selectedIndex, String objectName, String valueList)
    {
        if (!player.IsInVehicle && player.VehicleSeat != -1)
        {
            return;
        }

        int can_pass = 0;
        foreach (var ls in Bennys.ls_custom)
        {
            if (ls.in_use == true && ls.vehicle == player.Vehicle)
            {
                can_pass = 1;
            }
        }

        if (can_pass == 0)
        {
            return;
        }

        if (callbackId == "DYNAMIC_SUBMENU_LSCUSTOM")
        {
            if (objectName == "Original")
            {
                player.Vehicle.SetMod(player.GetData("vehicle_mod_type"), -1);
            }
            else
            {
                player.Vehicle.SetMod(player.GetData("vehicle_mod_type"), player.GetData("ListTrack_" + (selectedIndex - 1)));
            }
        }
        else if (callbackId == "LSCUSTOM_SET_COLORS")
        {
            if (player.GetData("LSCUSTOM_COLORS") == 0)
            {
                if (player.GetData("LSCUSTOM_RESPRAY") == 0) API.Shared.SetVehiclePrimaryColor(player.Vehicle, chrome[selectedIndex].colorindex);
                else API.Shared.SetVehicleSecondaryColor(player.Vehicle, chrome[selectedIndex].colorindex);
            }
            else if (player.GetData("LSCUSTOM_COLORS") == 1)
            {
                if (player.GetData("LSCUSTOM_RESPRAY") == 0) API.Shared.SetVehiclePrimaryColor(player.Vehicle, colors[selectedIndex].colorindex);
                else API.Shared.SetVehicleSecondaryColor(player.Vehicle, colors[selectedIndex].colorindex);
            }
            else if (player.GetData("LSCUSTOM_COLORS") == 2)
            {
                if (player.GetData("LSCUSTOM_RESPRAY") == 0) API.Shared.SetVehiclePrimaryColor(player.Vehicle, mattecolors[selectedIndex].colorindex);
                else API.Shared.SetVehicleSecondaryColor(player.Vehicle, mattecolors[selectedIndex].colorindex);
            }
            else if (player.GetData("LSCUSTOM_COLORS") == 3)
            {
                if (player.GetData("LSCUSTOM_RESPRAY") == 0) API.Shared.SetVehiclePrimaryColor(player.Vehicle, Main.metalic_color_list[selectedIndex].color_id);
                else API.Shared.SetVehicleSecondaryColor(player.Vehicle, Main.metalic_color_list[selectedIndex].color_id);

            }
            else if (player.GetData("LSCUSTOM_COLORS") == 4)
            {
                if (player.GetData("LSCUSTOM_RESPRAY") == 0) API.Shared.SetVehiclePrimaryColor(player.Vehicle, metalcolors[selectedIndex].colorindex);
                else API.Shared.SetVehicleSecondaryColor(player.Vehicle, metalcolors[selectedIndex].colorindex);
            }
        }
        else if (callbackId == "Bremsen")
        {
            API.Shared.SetVehicleMod(player.Vehicle, 12, Brakes[selectedIndex].mod);
        }
        else if (callbackId == "LSCUSTOM_HORN")
        {
            API.Shared.SetVehicleMod(player.Vehicle, 14, Horn[selectedIndex].mod);
        }
        else if (callbackId == "LSCUSTOM_TRANSMISSION")
        {
            API.Shared.SetVehicleMod(player.Vehicle, 13, Transmission[selectedIndex].mod);
        }
        else if (callbackId == "LSCUSTOM_SUSPENSION")
        {
            API.Shared.SetVehicleMod(player.Vehicle, 15, Suspension[selectedIndex].mod);
        }
        else if (callbackId == "LSCUSTOM_ARMOR")
        {
            API.Shared.SetVehicleMod(player.Vehicle, 16, Armor[selectedIndex].mod);
        }
        else if (callbackId == "LSCUSTOM_ENGINE")
        {
            API.Shared.SetVehicleMod(player.Vehicle, 11, Suspension[selectedIndex].mod);
        }
        else if (callbackId == "LSCUSTOM_PLATES")
        {
            API.Shared.SetVehicleNumberPlateStyle(player.Vehicle, plates[selectedIndex].plateindex);
        }
        else if (callbackId == "LSCUSTOM_WINDOW")
        {
            API.Shared.SetVehicleWindowTint(player.Vehicle, windowtint[selectedIndex].tint);
        }
        else if (callbackId == "LSCUSTOM_FAROL")
        {
            API.Shared.SetVehicleMod(player.Vehicle, 22, Headlights[selectedIndex].mod);
        }
        else if (callbackId == "LSCUSTOM_BIKE_WHEELS_RESPONSE")
        {
            if (player.GetData("LSCUSTOM_BIKE_WHEELS") == 0)
            {
                API.Shared.SetVehicleWheelType(player.Vehicle, backwheel[selectedIndex].wtype);
                API.Shared.SetVehicleMod(player.Vehicle, 24, backwheel[selectedIndex].mod);
            }
            else if (player.GetData("LSCUSTOM_BIKE_WHEELS") == 1)
            {
                API.Shared.SetVehicleWheelType(player.Vehicle, frontwheel[selectedIndex].wtype);
                API.Shared.SetVehicleMod(player.Vehicle, 23, frontwheel[selectedIndex].mod);
            }
            else if (player.GetData("LSCUSTOM_BIKE_WHEELS") == 2)
            {
                API.Shared.SetVehicleWheelColor(player.Vehicle, Main.metalic_color_list[selectedIndex].color_id);
            }
            else if (player.GetData("LSCUSTOM_BIKE_WHEELS") == 3)
            {
                if (selectedIndex == 0)
                {
                    API.Shared.SetVehicleBulletproofTyres(player.Vehicle, false);
                    API.Shared.SetVehicleTyreSmokeColor(player.Vehicle, new Color(255, 255, 255));
                }
                else if (selectedIndex == 1)
                {
                    API.Shared.SetVehicleBulletproofTyres(player.Vehicle, true);
                }
                else
                {
                    API.Shared.SetVehicleTyreSmokeColor(player.Vehicle, wheelaccessories[selectedIndex].smokecolor);
                }
            }

        }
        else if (callbackId == "LSCUSTOM_CAR_WHEELS_RESPONSE")
        {
            if (player.GetData("LSCUSTOM_CAR_WHEELS") == 0)
            {
                API.Shared.SetVehicleMod(player.Vehicle, 23, sportwheels[selectedIndex].mod);
                API.Shared.SetVehicleWheelType(player.Vehicle, sportwheels[selectedIndex].wtype);
            }
            else if (player.GetData("LSCUSTOM_CAR_WHEELS") == 1)
            {
                API.Shared.SetVehicleWheelType(player.Vehicle, musclewheels[selectedIndex].wtype);
                API.Shared.SetVehicleMod(player.Vehicle, 23, musclewheels[selectedIndex].mod);
            }
            else if (player.GetData("LSCUSTOM_CAR_WHEELS") == 2)
            {
                API.Shared.SetVehicleWheelType(player.Vehicle, lowriderwheels[selectedIndex].wtype);
                API.Shared.SetVehicleMod(player.Vehicle, 23, lowriderwheels[selectedIndex].mod);
            }
            else if (player.GetData("LSCUSTOM_CAR_WHEELS") == 3)
            {
                API.Shared.SetVehicleWheelType(player.Vehicle, suvwheels[selectedIndex].wtype);
                API.Shared.SetVehicleMod(player.Vehicle, 23, suvwheels[selectedIndex].mod);
            }
            else if (player.GetData("LSCUSTOM_CAR_WHEELS") == 4)
            {
                API.Shared.SetVehicleWheelType(player.Vehicle, offroadwheels[selectedIndex].wtype);
                API.Shared.SetVehicleMod(player.Vehicle, 23, offroadwheels[selectedIndex].mod);
            }
            else if (player.GetData("LSCUSTOM_CAR_WHEELS") == 5)
            {
                API.Shared.SetVehicleWheelType(player.Vehicle, tunerwheels[selectedIndex].wtype);
                API.Shared.SetVehicleMod(player.Vehicle, 23, tunerwheels[selectedIndex].mod);
            }
            else if (player.GetData("LSCUSTOM_CAR_WHEELS") == 6)
            {
                API.Shared.SetVehicleWheelType(player.Vehicle, highendwheels[selectedIndex].wtype);
                API.Shared.SetVehicleMod(player.Vehicle, 23, highendwheels[selectedIndex].mod);
            }
            else if (player.GetData("LSCUSTOM_CAR_WHEELS") == 7)
            {
                API.Shared.SetVehicleWheelColor(player.Vehicle, Main.metalic_color_list[selectedIndex].color_id);
            }
            else
            {
                if (selectedIndex == 0)
                {
                    API.Shared.SetVehicleBulletproofTyres(player.Vehicle, false);
                    API.Shared.SetVehicleTyreSmokeColor(player.Vehicle, new Color(255, 255, 255));
                }
                else if (selectedIndex == 1)
                {
                    API.Shared.SetVehicleBulletproofTyres(player.Vehicle, true);
                }
                else
                {
                    API.Shared.SetVehicleTyreSmokeColor(player.Vehicle, wheelaccessories[selectedIndex].smokecolor);
                }
            }
        }
        else if (callbackId == "LSCUSTOM_TURBO")
        {
            API.Shared.SetVehicleMod(player.Vehicle, 18, Turbo[selectedIndex].mod);
        }
        else if (callbackId == "LSCUSTOM_NEON")
        {
            if (selectedIndex == 0)
            {
                API.Shared.SetVehicleNeonState(player.Vehicle, false);
                API.Shared.SetVehicleNeonColor(player.Vehicle, neoncolor[selectedIndex].neon.Red, neoncolor[selectedIndex].neon.Green, neoncolor[selectedIndex].neon.Blue);

                player.SetData("lscustom_neon", false);
                player.SetData("lscustom_neon_color", player.Vehicle.NeonColor);
            }
            else
            {
                API.Shared.SetVehicleNeonState(player.Vehicle, true);
                API.Shared.SetVehicleNeonColor(player.Vehicle, neoncolor[selectedIndex].neon.Red, neoncolor[selectedIndex].neon.Green, neoncolor[selectedIndex].neon.Blue);

                player.SetData("lscustom_neon", true);
                player.SetData("lscustom_neon_color", player.Vehicle.NeonColor);
            }
        }
    }

    public static void ListItemMenuResponse(Client player, String callbackId, int selectedIndex, String objectName, String valueList, int valueIndex)
    {
    }

    public static void CheckBoxItemMenuResponse(Client player, String callbackId, int selectedIndex, String objectName, String valueList, bool _checked)
    {

    }

    public static void OnMenuReturnClose(Client player, String callbackId)
    {
        if (callbackId == "LSCUSTOM_TURBO" || callbackId == "LSCUSTOM_ENGINE" || callbackId == "LSCUSTOM_BRAKES" || callbackId == "LSCUSTOM_NEON" || callbackId == "LSCUSTOM_CHASSIS_RESPONSE" || callbackId == "LSCUSTOM_TRANSMISSION" || callbackId == "LSCUSTOM_HORN" || callbackId == "LSCUSTOM_SUSPENSION" || callbackId == "LSCUSTOM_ARMOR" || callbackId == "LSCUSTOM_CHASSIS" || callbackId == "LSCUSTOM_WINDOW" || callbackId == "LSCUSTOM_PRIMARY_COLORS" || callbackId == "LSCUSTOM_SECUNDARY_COLORS" || callbackId == "DYNAMIC_SUBMENU_LSCUSTOM" || callbackId == "LSCUSTOM_SET_COLORS" || callbackId == "LSCUSTOM_RESPRAY" || callbackId == "LSCUSTOM_COLORS" || callbackId == "LSCUSTOM_CHASSIS" || callbackId == "LSCUSTOM_CHASSIS_RESPONSE" || callbackId == "LSCUSTOM_CAR_WHEELS" || callbackId == "LSCUSTOM_BIKE_WHEELS" || callbackId == "LSCUSTOM_CAR_WHEELS_RESPONSE" || callbackId == "LSCUSTOM_BUMPERS" || callbackId == "LSCUSTOM_BIKE_WHEELS_RESPONSE")
        {
            Hide_Bennys(player);
            Display_Bennys(player);
        }
        else if (callbackId == "LSCUSTOM_MAIN")
        {
            Hide_Bennys(player);

            player.TriggerEvent("freeze", false);
            player.TriggerEvent("freezeVehicle", false);
            player.SetSharedData("DisableVehicleMove", false);


            int playerid = Main.getIdFromClient(player);
            for (int index = 0; index < PlayerVehicle.MAX_PLAYER_VEHICLES; index++)
            {
                if (PlayerVehicle.vehicle_data[playerid].state[index] == 1)
                {
                    if (PlayerVehicle.vehicle_data[playerid].handle[index].Exists && PlayerVehicle.vehicle_data[playerid].handle[index] == player.Vehicle)
                    {
                        PlayerVehicle.SavePlayerVehicle(player, index);
                    }
                }
            }

            if (player.IsInVehicle && player.VehicleSeat == -1)
            {
                foreach (var ls in ls_custom)
                {
                    if (ls.in_use == true && ls.vehicle == player.Vehicle)
                    {
                        Vehicle vehicle = player.Vehicle;
                        ls.in_use = false;
                        ls.vehicle = null;
                        ls.label_position.Text = "Strom Ausfall";
                        vehicle.ResetData("lscustom_use");
                    }
                }
            }
        }
    }

    public static void OnInputResponse(Client player, String response, String inputtext)
    {
    }


    public class SubMenu
    {
        public string Label { get; set; }
        public int modType { get; set; }
        public int modValue { get; set; }
    }


    [RemoteEvent("Create_Submenu_Mod")]
    public static void CreateSubMenu(Client player, string json, string submenu_name)
    {
        if (!player.IsInVehicle && player.VehicleSeat != -1)
        {
            return;
        }

        var data = JsonConvert.DeserializeObject<List<SubMenu>>(json);
        int i = 0;
        List<dynamic> menu_item_list = new List<dynamic>();

        menu_item_list.Add(new { Type = 4, Name = "Original", Description = "", RightLabel = "~s~~h~GRATIS" });

        foreach (var item in data)
        {
            if (item.Label != "NULL")
            {
                player.SetData("vehicle_mod_type", item.modType);
                player.SetData("ListTrack_" + i, item.modValue);


                int price = 0;


                switch (item.modType)
                {
                    case 0: price = AEROFOLIO_PRICE + (i * AEROFOLIO_PRICE_INCREASE); break;
                    case 3: price = SAIAS_PRICE + (i * SAIAS_PRICE_INCREASE); break;
                    case 4: price = ESCAPES_PRICE + (i * ESCAPES_PRICE_INCREASE); break;
                    case 6: price = GRADES_PRICE + (i * GRADES_PRICE_INCREASE); break;
                    case 7: price = PARALAMAS_PRICE + (i * PARALAMAS_PRICE_INCREASE); break;
                    case 8: price = TETO_PRICE + (i * TETO_PRICE_INCREASE); break;
                    case 10: price = TETO_PRICE + (i * TETO_PRICE_INCREASE); break;
                    case 48: price = LIVERIES_PRICE + (i * LIVERIES_PRICE_INCREASE); break;
                    case 1: price = PARACHOQUEFRONTAL_PRICE + (i * PARACHOQUEFRONTAL_PRICE_INCREASE); break;
                    case 2: price = PARACHOQUETRASEIRO_PRICE + (i * PARACHOQUETRASEIRO_PRICE_INCREASE); break;
                    case 42: price = FAROLPERSONALIZADO_PRICE + (i * FAROLPERSONALIZADO_PRICE_INCREASE); break;
                    case 43: price = ANTENAS_PRICE + (i * ANTENAS_PRICE_INCREASE); break;
                    case 44: price = SAIDADEAR_PRICE + (i * SAIDADEAR_PRICE_INCREASE); break;
                    case 45: price = TANQUE_PRICE + (i * TANQUE_PRICE_INCREASE); break;
                    case 46: price = VIDRO_PRICE + (i * VIDRO_PRICE_INCREASE); break;
                    case 5: price = SANTANTONIO_PRICE + (i * SANTANTONIO_PRICE_INCREASE); break;
                }

                menu_item_list.Add(new { Type = 4, Name = item.Label, Description = "", RightLabel = "~s~$" + price });
                i++;
            }
        }
        if (i == 0)
        {
            Display_Bennys(player);
            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Dieser Artikel ist für diesen Fahrzeugtyp nicht verfügbar.", 5000);
            return;
        }
        InteractMenu.CreateMenu(player, "DYNAMIC_SUBMENU_LSCUSTOM", "", submenu_name, true, NAPI.Util.ToJson(menu_item_list), false, BackgroundSprite: "shopui_title_carmod", MouseControl: true);
    }
}

