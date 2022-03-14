using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTANetworkAPI;
using DerStr1k3r.Core;
using DerStr1k3r.SDK;

public class TattooShop : Script
{

    public static int PRICE_TATTOO = 3500;
    static List<dynamic> acessories = new List<dynamic>();
    static List<dynamic> acessoriesdel = new List<dynamic>();
    private static int category;

    public static void TattooInit()
    {
        acessories.Add(new { item_id = 0, category = "Tattoos", collection = "mpbusiness_overlays", overlay = "MP_Buis_M_Neck_000", name = "Cash is King" });
        acessories.Add(new { item_id = 1, category = "Tattoos", collection = "mpbusiness_overlays", overlay = "MP_Buis_M_Neck_001", name = "Bold Dollar Sign" });
        acessories.Add(new { item_id = 2, category = "Tattoos", collection = "mpbusiness_overlays", overlay = "MP_Buis_M_Neck_002", name = "Script Dollar Sign" });
        acessories.Add(new { item_id = 3, category = "Tattoos", collection = "mpbusiness_overlays", overlay = "MP_Buis_M_Neck_003", name = "$100" });
        acessories.Add(new { item_id = 4, category = "Tattoos", collection = "mpbusiness_overlays", overlay = "MP_Buis_M_LeftArm_000", name = "$100 Bill" });
        acessories.Add(new { item_id = 5, category = "Tattoos", collection = "mpbusiness_overlays", overlay = "MP_Buis_M_LeftArm_001", name = "All-Seeing Eye" });
        acessories.Add(new { item_id = 6, category = "Tattoos", collection = "mpbusiness_overlays", overlay = "MP_Buis_M_RightArm_000", name = "Dollar Skull" });
        acessories.Add(new { item_id = 7, category = "Tattoos", collection = "mpbusiness_overlays", overlay = "MP_Buis_M_RightArm_001", name = "Green" });
        acessories.Add(new { item_id = 9, category = "Tattoos", collection = "mpbusiness_overlays", overlay = "MP_Buis_M_Stomach_000", name = "Refined Hustler" });
        acessories.Add(new { item_id = 9, category = "Tattoos", collection = "mpbusiness_overlays", overlay = "MP_Buis_M_Chest_000", name = "Rich" });
        acessories.Add(new { item_id = 10, category = "Tattoos", collection = "mpbusiness_overlays", overlay = "MP_Buis_M_Chest_001", name = "$$$" });
        acessories.Add(new { item_id = 11, category = "Tattoos", collection = "mpbusiness_overlays", overlay = "MP_Buis_M_Back_000", name = "Makin' Paper" });
        acessories.Add(new { item_id = 12, category = "Tattoos", collection = "mpbusiness_overlays", overlay = "MP_Buis_F_Chest_000", name = "High Roller" });
        acessories.Add(new { item_id = 13, category = "Tattoos", collection = "mpbusiness_overlays", overlay = "MP_Buis_F_Chest_001", name = "Makin' Money" });
        acessories.Add(new { item_id = 14, category = "Tattoos", collection = "mpbusiness_overlays", overlay = "MP_Buis_F_Chest_002", name = "Love Money" });
        acessories.Add(new { item_id = 15, category = "Tattoos", collection = "mpbusiness_overlays", overlay = "MP_Buis_F_Stom_000", name = "Diamond Back" });
        acessories.Add(new { item_id = 16, category = "Tattoos", collection = "mpbusiness_overlays", overlay = "MP_Buis_F_Stom_001", name = "Santo Capra Logo" });
        acessories.Add(new { item_id = 17, category = "Tattoos", collection = "mpbusiness_overlays", overlay = "MP_Buis_F_Stom_002", name = "Money Bag" });
        acessories.Add(new { item_id = 18, category = "Tattoos", collection = "mpbusiness_overlays", overlay = "MP_Buis_F_Back_000", name = "Respect" });
        acessories.Add(new { item_id = 19, category = "Tattoos", collection = "mpbusiness_overlays", overlay = "MP_Buis_F_Back_001", name = "Gold Digger" });
        acessories.Add(new { item_id = 20, category = "Tattoos", collection = "mpbusiness_overlays", overlay = "MP_Buis_F_Neck_000", name = "Val-de-Grace Logo" });
        acessories.Add(new { item_id = 21, category = "Tattoos", collection = "mpbusiness_overlays", overlay = "MP_Buis_F_Neck_001", name = "Money Rose" });
        acessories.Add(new { item_id = 22, category = "Tattoos", collection = "multiplayer_overlays", overlay = "FM_Tat_Award_M_000", name = "Skull Man" });
        acessories.Add(new { item_id = 23, category = "Tattoos", collection = "multiplayer_overlays", overlay = "FM_Tat_Award_F_000", name = "Skull Girl" });
        acessories.Add(new { item_id = 24, category = "Tattoos", collection = "multiplayer_overlays", overlay = "FM_Tat_Award_M_001", name = "" });
        acessories.Add(new { item_id = 25, category = "Tattoos", collection = "multiplayer_overlays", overlay = "FM_Tat_Award_F_001", name = "" });
        acessories.Add(new { item_id = 26, category = "Tattoos", collection = "multiplayer_overlays", overlay = "FM_Tat_Award_M_002", name = "" });
        acessories.Add(new { item_id = 27, category = "Tattoos", collection = "multiplayer_overlays", overlay = "FM_Tat_Award_F_002", name = "" });
        acessories.Add(new { item_id = 28, category = "Tattoos", collection = "multiplayer_overlays", overlay = "FM_Tat_Award_M_003", name = "" });
        acessories.Add(new { item_id = 29, category = "Tattoos", collection = "multiplayer_overlays", overlay = "FM_Tat_Award_F_003", name = "" });
        acessories.Add(new { item_id = 30, category = "Tattoos", collection = "multiplayer_overlays", overlay = "FM_Tat_Award_M_004", name = "" });
        acessories.Add(new { item_id = 24, category = "Tattoos", collection = "multiplayer_overlays", overlay = "FM_Tat_Award_F_004", name = "" });
        acessories.Add(new { item_id = 25, category = "Tattoos", collection = "multiplayer_overlays", overlay = "FM_Tat_Award_M_005", name = "" });
        acessories.Add(new { item_id = 26, category = "Tattoos", collection = "multiplayer_overlays", overlay = "FM_Tat_Award_F_005", name = "" });
        acessories.Add(new { item_id = 27, category = "Tattoos", collection = "multiplayer_overlays", overlay = "FM_Tat_Award_M_006", name = "" });
        acessories.Add(new { item_id = 28, category = "Tattoos", collection = "multiplayer_overlays", overlay = "FM_Tat_Award_F_006", name = "" });
        acessories.Add(new { item_id = 29, category = "Tattoos", collection = "multiplayer_overlays", overlay = "FM_Tat_Award_M_007", name = "" });
        acessories.Add(new { item_id = 30, category = "Tattoos", collection = "multiplayer_overlays", overlay = "FM_Tat_Award_F_007", name = "" });
        acessories.Add(new { item_id = 24, category = "Tattoos", collection = "multiplayer_overlays", overlay = "FM_Tat_Award_M_008", name = "" });
        acessories.Add(new { item_id = 25, category = "Tattoos", collection = "multiplayer_overlays", overlay = "FM_Tat_Award_F_008", name = "" });
        acessories.Add(new { item_id = 26, category = "Tattoos", collection = "multiplayer_overlays", overlay = "FM_Tat_Award_M_009", name = "" });
        acessories.Add(new { item_id = 27, category = "Tattoos", collection = "multiplayer_overlays", overlay = "FM_Tat_Award_F_009", name = "" });
        acessories.Add(new { item_id = 28, category = "Tattoos", collection = "multiplayer_overlays", overlay = "FM_Tat_Award_M_010", name = "" });
        acessories.Add(new { item_id = 29, category = "Tattoos", collection = "multiplayer_overlays", overlay = "FM_Tat_Award_F_010", name = "" });
        acessories.Add(new { item_id = 30, category = "Tattoos", collection = "multiplayer_overlays", overlay = "FM_Tat_Award_M_011", name = "" });
        acessories.Add(new { item_id = 31, category = "Tattoos", collection = "multiplayer_overlays", overlay = "FM_Tat_Award_F_011", name = "" });
        acessories.Add(new { item_id = 32, category = "Tattoos", collection = "multiplayer_overlays", overlay = "FM_Tat_Award_M_012", name = "" });
        acessories.Add(new { item_id = 33, category = "Tattoos", collection = "multiplayer_overlays", overlay = "FM_Tat_Award_F_012", name = "" });
        acessories.Add(new { item_id = 34, category = "Tattoos", collection = "multiplayer_overlays", overlay = "FM_Tat_Award_M_013", name = "" });
        acessories.Add(new { item_id = 35, category = "Tattoos", collection = "multiplayer_overlays", overlay = "FM_Tat_Award_F_013", name = "" });
        acessories.Add(new { item_id = 36, category = "Tattoos", collection = "multiplayer_overlays", overlay = "FM_Tat_Award_M_014", name = "" });
        acessories.Add(new { item_id = 37, category = "Tattoos", collection = "multiplayer_overlays", overlay = "FM_Tat_Award_F_014", name = "" });
        acessories.Add(new { item_id = 38, category = "Tattoos", collection = "multiplayer_overlays", overlay = "FM_Tat_Award_M_015", name = "" });
        acessories.Add(new { item_id = 39, category = "Tattoos", collection = "multiplayer_overlays", overlay = "FM_Tat_Award_F_015", name = "" });
        acessories.Add(new { item_id = 40, category = "Tattoos", collection = "multiplayer_overlays", overlay = "FM_Tat_Award_M_016", name = "" });
        acessories.Add(new { item_id = 41, category = "Tattoos", collection = "multiplayer_overlays", overlay = "FM_Tat_Award_F_016", name = "" });
        acessories.Add(new { item_id = 42, category = "Tattoos", collection = "multiplayer_overlays", overlay = "FM_Tat_Award_M_017", name = "" });
        acessories.Add(new { item_id = 43, category = "Tattoos", collection = "multiplayer_overlays", overlay = "FM_Tat_Award_F_017", name = "" });
        acessories.Add(new { item_id = 44, category = "Tattoos", collection = "multiplayer_overlays", overlay = "FM_Tat_Award_M_018", name = "" });
        acessories.Add(new { item_id = 45, category = "Tattoos", collection = "multiplayer_overlays", overlay = "FM_Tat_Award_F_018", name = "" });
        acessories.Add(new { item_id = 46, category = "Tattoos", collection = "mpheist3_overlays", overlay = "mpHeist3_Tat_000_M", name = "" });
        acessories.Add(new { item_id = 47, category = "Tattoos", collection = "mpheist3_overlays", overlay = "mpHeist3_Tat_000_F", name = "" });
        acessories.Add(new { item_id = 48, category = "Tattoos", collection = "mpheist3_overlays", overlay = "mpHeist3_Tat_001_M", name = "" });
        acessories.Add(new { item_id = 49, category = "Tattoos", collection = "mpheist3_overlays", overlay = "mpHeist3_Tat_001_F", name = "" });
        acessories.Add(new { item_id = 50, category = "Tattoos", collection = "mpheist3_overlays", overlay = "mpHeist3_Tat_002_M", name = "" });
        acessories.Add(new { item_id = 51, category = "Tattoos", collection = "mpheist3_overlays", overlay = "mpHeist3_Tat_002_F", name = "" });
        acessories.Add(new { item_id = 52, category = "Tattoos", collection = "mpheist3_overlays", overlay = "mpHeist3_Tat_003_M", name = "" });
        acessories.Add(new { item_id = 53, category = "Tattoos", collection = "mpheist3_overlays", overlay = "mpHeist3_Tat_003_F", name = "" });
        acessories.Add(new { item_id = 54, category = "Tattoos", collection = "mpheist3_overlays", overlay = "mpHeist3_Tat_004_M", name = "" });
        acessories.Add(new { item_id = 55, category = "Tattoos", collection = "mpheist3_overlays", overlay = "mpHeist3_Tat_004_F", name = "" });
        acessories.Add(new { item_id = 56, category = "Tattoos", collection = "mpheist3_overlays", overlay = "mpHeist3_Tat_005_M", name = "" });
        acessories.Add(new { item_id = 57, category = "Tattoos", collection = "mpheist3_overlays", overlay = "mpHeist3_Tat_005_F", name = "" });
        acessories.Add(new { item_id = 58, category = "Tattoos", collection = "mpheist3_overlays", overlay = "mpHeist3_Tat_006_M", name = "" });
        acessories.Add(new { item_id = 59, category = "Tattoos", collection = "mpheist3_overlays", overlay = "mpHeist3_Tat_006_F", name = "" });
        acessories.Add(new { item_id = 60, category = "Tattoos", collection = "mpheist3_overlays", overlay = "mpHeist3_Tat_007_M", name = "" });
        acessories.Add(new { item_id = 61, category = "Tattoos", collection = "mpheist3_overlays", overlay = "mpHeist3_Tat_007_F", name = "" });
        acessories.Add(new { item_id = 62, category = "Tattoos", collection = "mpheist3_overlays", overlay = "mpHeist3_Tat_008_M", name = "" });
        acessories.Add(new { item_id = 63, category = "Tattoos", collection = "mpheist3_overlays", overlay = "mpHeist3_Tat_008_F", name = "" });
        acessories.Add(new { item_id = 64, category = "Tattoos", collection = "mpvinewood_overlays", overlay = "MP_Vinewood_Tat_000_F", name = "" });
        acessories.Add(new { item_id = 65, category = "Tattoos", collection = "mpvinewood_overlays", overlay = "MP_Vinewood_Tat_000_M", name = "" });
        acessories.Add(new { item_id = 66, category = "Tattoos", collection = "mpvinewood_overlays", overlay = "MP_Vinewood_Tat_001_F", name = "" });
        acessories.Add(new { item_id = 67, category = "Tattoos", collection = "mpvinewood_overlays", overlay = "MP_Vinewood_Tat_001_M", name = "" });
        acessories.Add(new { item_id = 68, category = "Tattoos", collection = "mpvinewood_overlays", overlay = "MP_Vinewood_Tat_002_F", name = "" });
        acessories.Add(new { item_id = 69, category = "Tattoos", collection = "mpvinewood_overlays", overlay = "MP_Vinewood_Tat_002_M", name = "" });
        acessories.Add(new { item_id = 70, category = "Tattoos", collection = "mpvinewood_overlays", overlay = "MP_Vinewood_Tat_003_F", name = "" });
        acessories.Add(new { item_id = 71, category = "Tattoos", collection = "mpvinewood_overlays", overlay = "MP_Vinewood_Tat_003_M", name = "" });
        acessories.Add(new { item_id = 72, category = "Tattoos", collection = "mpvinewood_overlays", overlay = "MP_Vinewood_Tat_004_F", name = "" });
        acessories.Add(new { item_id = 73, category = "Tattoos", collection = "mpvinewood_overlays", overlay = "MP_Vinewood_Tat_004_M", name = "" });
        acessories.Add(new { item_id = 74, category = "Tattoos", collection = "mpvinewood_overlays", overlay = "MP_Vinewood_Tat_005_F", name = "" });
        acessories.Add(new { item_id = 75, category = "Tattoos", collection = "mpvinewood_overlays", overlay = "MP_Vinewood_Tat_005_M", name = "" });
        acessories.Add(new { item_id = 76, category = "Tattoos", collection = "mpvinewood_overlays", overlay = "MP_Vinewood_Tat_006_F", name = "" });
        acessories.Add(new { item_id = 77, category = "Tattoos", collection = "mpvinewood_overlays", overlay = "MP_Vinewood_Tat_006_M", name = "" });
        acessories.Add(new { item_id = 78, category = "Tattoos", collection = "mpvinewood_overlays", overlay = "MP_Vinewood_Tat_007_F", name = "" });
        acessories.Add(new { item_id = 79, category = "Tattoos", collection = "mpvinewood_overlays", overlay = "MP_Vinewood_Tat_007_M", name = "" });
        acessories.Add(new { item_id = 80, category = "Tattoos", collection = "mpvinewood_overlays", overlay = "MP_Vinewood_Tat_008_F", name = "" });
        acessories.Add(new { item_id = 81, category = "Tattoos", collection = "mpvinewood_overlays", overlay = "MP_Vinewood_Tat_008_M", name = "" });
        acessories.Add(new { item_id = 82, category = "Tattoos", collection = "mpvinewood_overlays", overlay = "MP_Vinewood_Tat_009_F", name = "" });
        acessories.Add(new { item_id = 83, category = "Tattoos", collection = "mpvinewood_overlays", overlay = "MP_Vinewood_Tat_009_M", name = "" });
        acessories.Add(new { item_id = 84, category = "Tattoos", collection = "mpvinewood_overlays", overlay = "MP_Vinewood_Tat_010_F", name = "" });
        acessories.Add(new { item_id = 85, category = "Tattoos", collection = "mpvinewood_overlays", overlay = "MP_Vinewood_Tat_010_M", name = "" });
        acessories.Add(new { item_id = 86, category = "Tattoos", collection = "mpvinewood_overlays", overlay = "MP_Vinewood_Tat_011_F", name = "" });
        acessories.Add(new { item_id = 87, category = "Tattoos", collection = "mpvinewood_overlays", overlay = "MP_Vinewood_Tat_011_M", name = "" });
        acessories.Add(new { item_id = 88, category = "Tattoos", collection = "mpvinewood_overlays", overlay = "MP_Vinewood_Tat_012_F", name = "" });
        acessories.Add(new { item_id = 89, category = "Tattoos", collection = "mpvinewood_overlays", overlay = "MP_Vinewood_Tat_012_M", name = "" });
        acessories.Add(new { item_id = 90, category = "Tattoos", collection = "mpvinewood_overlays", overlay = "MP_Vinewood_Tat_013_F", name = "" });
        acessories.Add(new { item_id = 91, category = "Tattoos", collection = "mpvinewood_overlays", overlay = "MP_Vinewood_Tat_013_M", name = "" });
        acessories.Add(new { item_id = 92, category = "Tattoos", collection = "mpvinewood_overlays", overlay = "MP_Vinewood_Tat_014_F", name = "" });
        acessories.Add(new { item_id = 93, category = "Tattoos", collection = "mpvinewood_overlays", overlay = "MP_Vinewood_Tat_015_M", name = "" });
        acessories.Add(new { item_id = 94, category = "Tattoos", collection = "mpvinewood_overlays", overlay = "MP_Vinewood_Tat_015_F", name = "" });
        acessories.Add(new { item_id = 95, category = "Tattoos", collection = "mpvinewood_overlays", overlay = "MP_Vinewood_Tat_016_M", name = "" });
        acessories.Add(new { item_id = 96, category = "Tattoos", collection = "mpvinewood_overlays", overlay = "MP_Vinewood_Tat_017_F", name = "" });
        acessories.Add(new { item_id = 97, category = "Tattoos", collection = "mpvinewood_overlays", overlay = "MP_Vinewood_Tat_017_M", name = "" });
        acessories.Add(new { item_id = 98, category = "Tattoos", collection = "mpvinewood_overlays", overlay = "MP_Vinewood_Tat_018_F", name = "" });
        acessories.Add(new { item_id = 99, category = "Tattoos", collection = "mpvinewood_overlays", overlay = "MP_Vinewood_Tat_018_M", name = "" });
        acessories.Add(new { item_id = 100, category = "Tattoos", collection = "mpvinewood_overlays", overlay = "MP_Vinewood_Tat_019_F", name = "" });
        acessories.Add(new { item_id = 101, category = "Tattoos", collection = "mpvinewood_overlays", overlay = "MP_Vinewood_Tat_019_M", name = "" });
        acessories.Add(new { item_id = 102, category = "Tattoos", collection = "mpvinewood_overlays", overlay = "MP_Vinewood_Tat_020_F", name = "" });
        acessories.Add(new { item_id = 103, category = "Tattoos", collection = "mpvinewood_overlays", overlay = "MP_Vinewood_Tat_020_M", name = "" });
        acessories.Add(new { item_id = 104, category = "Tattoos", collection = "mpvinewood_overlays", overlay = "MP_Vinewood_Tat_021_F", name = "" });
        acessories.Add(new { item_id = 105, category = "Tattoos", collection = "mpvinewood_overlays", overlay = "MP_Vinewood_Tat_021_M", name = "" });
        acessories.Add(new { item_id = 106, category = "Tattoos", collection = "mpvinewood_overlays", overlay = "MP_Vinewood_Tat_022_F", name = "" });
        acessories.Add(new { item_id = 107, category = "Tattoos", collection = "mpvinewood_overlays", overlay = "MP_Vinewood_Tat_022_M", name = "" });
        acessories.Add(new { item_id = 108, category = "Tattoos", collection = "mpvinewood_overlays", overlay = "MP_Vinewood_Tat_023_F", name = "" });
        acessories.Add(new { item_id = 109, category = "Tattoos", collection = "mpvinewood_overlays", overlay = "MP_Vinewood_Tat_023_M", name = "" });
        acessories.Add(new { item_id = 110, category = "Tattoos", collection = "mpvinewood_overlays", overlay = "MP_Vinewood_Tat_024_F", name = "" });
        acessories.Add(new { item_id = 111, category = "Tattoos", collection = "mpvinewood_overlays", overlay = "MP_Vinewood_Tat_025_M", name = "" });
        acessories.Add(new { item_id = 112, category = "Tattoos", collection = "mpvinewood_overlays", overlay = "MP_Vinewood_Tat_025_F", name = "" });
        acessories.Add(new { item_id = 113, category = "Tattoos", collection = "mpvinewood_overlays", overlay = "MP_Vinewood_Tat_026_M", name = "" });
        acessories.Add(new { item_id = 114, category = "Tattoos", collection = "mpvinewood_overlays", overlay = "MP_Vinewood_Tat_026_F", name = "" });
        acessories.Add(new { item_id = 115, category = "Tattoos", collection = "mpvinewood_overlays", overlay = "MP_Vinewood_Tat_027_M", name = "" });
        acessories.Add(new { item_id = 116, category = "Tattoos", collection = "mpvinewood_overlays", overlay = "MP_Vinewood_Tat_027_F", name = "" });
        acessories.Add(new { item_id = 117, category = "Tattoos", collection = "mpvinewood_overlays", overlay = "MP_Vinewood_Tat_028_M", name = "" });
        acessories.Add(new { item_id = 118, category = "Tattoos", collection = "mpvinewood_overlays", overlay = "MP_Vinewood_Tat_028_F", name = "" });
        acessories.Add(new { item_id = 119, category = "Tattoos", collection = "mplowrider_overlays", overlay = "MP_LR_Tat_001_F", name = "" });
        acessories.Add(new { item_id = 119, category = "Tattoos", collection = "mplowrider_overlays", overlay = "MP_LR_Tat_001_M", name = "" });
        acessories.Add(new { item_id = 120, category = "Tattoos", collection = "mplowrider_overlays", overlay = "MP_LR_Tat_002_F", name = "" });
        acessories.Add(new { item_id = 120, category = "Tattoos", collection = "mplowrider_overlays", overlay = "MP_LR_Tat_002_M", name = "" });
        acessories.Add(new { item_id = 121, category = "Tattoos", collection = "mplowrider_overlays", overlay = "MP_LR_Tat_003_F", name = "" });
        acessories.Add(new { item_id = 121, category = "Tattoos", collection = "mplowrider_overlays", overlay = "MP_LR_Tat_003_M", name = "" });
        acessories.Add(new { item_id = 122, category = "Tattoos", collection = "mplowrider_overlays", overlay = "MP_LR_Tat_004_F", name = "" });
        acessories.Add(new { item_id = 122, category = "Tattoos", collection = "mplowrider_overlays", overlay = "MP_LR_Tat_004_M", name = "" });
        acessories.Add(new { item_id = 123, category = "Tattoos", collection = "mplowrider_overlays", overlay = "MP_LR_Tat_005_F", name = "" });
        acessories.Add(new { item_id = 123, category = "Tattoos", collection = "mplowrider_overlays", overlay = "MP_LR_Tat_005_M", name = "" });
        acessories.Add(new { item_id = 124, category = "Tattoos", collection = "mplowrider_overlays", overlay = "MP_LR_Tat_006_F", name = "" });
        acessories.Add(new { item_id = 124, category = "Tattoos", collection = "mplowrider_overlays", overlay = "MP_LR_Tat_006_M", name = "" });
        acessories.Add(new { item_id = 125, category = "Tattoos", collection = "mplowrider_overlays", overlay = "MP_LR_Tat_007_F", name = "" });
        acessories.Add(new { item_id = 125, category = "Tattoos", collection = "mplowrider_overlays", overlay = "MP_LR_Tat_007_M", name = "" });
        acessories.Add(new { item_id = 126, category = "Tattoos", collection = "mplowrider_overlays", overlay = "MP_LR_Tat_008_F", name = "" });
        acessories.Add(new { item_id = 126, category = "Tattoos", collection = "mplowrider_overlays", overlay = "MP_LR_Tat_009_M", name = "" });
        acessories.Add(new { item_id = 127, category = "Tattoos", collection = "mplowrider_overlays", overlay = "MP_LR_Tat_010_F", name = "" });
        acessories.Add(new { item_id = 127, category = "Tattoos", collection = "mplowrider_overlays", overlay = "MP_LR_Tat_010_M", name = "" });
        acessories.Add(new { item_id = 128, category = "Tattoos", collection = "mplowrider_overlays", overlay = "MP_LR_Tat_011_F", name = "" });
        acessories.Add(new { item_id = 128, category = "Tattoos", collection = "mplowrider_overlays", overlay = "MP_LR_Tat_011_M", name = "" });
        acessories.Add(new { item_id = 129, category = "Tattoos", collection = "mplowrider_overlays", overlay = "MP_LR_Tat_012_F", name = "" });
        acessories.Add(new { item_id = 129, category = "Tattoos", collection = "mplowrider_overlays", overlay = "MP_LR_Tat_012_M", name = "" });
        acessories.Add(new { item_id = 130, category = "Tattoos", collection = "mpsmuggler_overlays", overlay = "MP_Smuggler_Tattoo_001_F", name = "" });
        acessories.Add(new { item_id = 130, category = "Tattoos", collection = "mpsmuggler_overlays", overlay = "MP_Smuggler_Tattoo_001_M", name = "" });
        acessories.Add(new { item_id = 131, category = "Tattoos", collection = "mpsmuggler_overlays", overlay = "MP_Smuggler_Tattoo_002_F", name = "" });
        acessories.Add(new { item_id = 131, category = "Tattoos", collection = "mpsmuggler_overlays", overlay = "MP_Smuggler_Tattoo_002_M", name = "" });
        acessories.Add(new { item_id = 132, category = "Tattoos", collection = "mpsmuggler_overlays", overlay = "MP_Smuggler_Tattoo_003_F", name = "" });
        acessories.Add(new { item_id = 132, category = "Tattoos", collection = "mpsmuggler_overlays", overlay = "MP_Smuggler_Tattoo_003_M", name = "" });
        acessories.Add(new { item_id = 133, category = "Tattoos", collection = "mpsmuggler_overlays", overlay = "MP_Smuggler_Tattoo_004_F", name = "" });
        acessories.Add(new { item_id = 133, category = "Tattoos", collection = "mpsmuggler_overlays", overlay = "MP_Smuggler_Tattoo_004_M", name = "" });
        acessories.Add(new { item_id = 134, category = "Tattoos", collection = "mpsmuggler_overlays", overlay = "MP_Smuggler_Tattoo_005_F", name = "" });
        acessories.Add(new { item_id = 134, category = "Tattoos", collection = "mpsmuggler_overlays", overlay = "MP_Smuggler_Tattoo_005_M", name = "" });
        acessories.Add(new { item_id = 135, category = "Tattoos", collection = "mpsmuggler_overlays", overlay = "MP_Smuggler_Tattoo_006_F", name = "" });
        acessories.Add(new { item_id = 135, category = "Tattoos", collection = "mpsmuggler_overlays", overlay = "MP_Smuggler_Tattoo_006_M", name = "" });
        acessories.Add(new { item_id = 136, category = "Tattoos", collection = "mpsmuggler_overlays", overlay = "MP_Smuggler_Tattoo_007_F", name = "" });
        acessories.Add(new { item_id = 136, category = "Tattoos", collection = "mpsmuggler_overlays", overlay = "MP_Smuggler_Tattoo_007_M", name = "" });
        acessories.Add(new { item_id = 137, category = "Tattoos", collection = "mpsmuggler_overlays", overlay = "MP_Smuggler_Tattoo_008_F", name = "" });
        acessories.Add(new { item_id = 137, category = "Tattoos", collection = "mpsmuggler_overlays", overlay = "MP_Smuggler_Tattoo_009_M", name = "" });
        acessories.Add(new { item_id = 138, category = "Tattoos", collection = "mpsmuggler_overlays", overlay = "MP_Smuggler_Tattoo_010_F", name = "" });
        acessories.Add(new { item_id = 138, category = "Tattoos", collection = "mpsmuggler_overlays", overlay = "MP_Smuggler_Tattoo_010_M", name = "" });
        acessories.Add(new { item_id = 139, category = "Tattoos", collection = "mpsmuggler_overlays", overlay = "MP_Smuggler_Tattoo_011_F", name = "" });
        acessories.Add(new { item_id = 139, category = "Tattoos", collection = "mpsmuggler_overlays", overlay = "MP_Smuggler_Tattoo_011_M", name = "" });
        acessories.Add(new { item_id = 140, category = "Tattoos", collection = "mpsmuggler_overlays", overlay = "MP_Smuggler_Tattoo_012_F", name = "" });
        acessories.Add(new { item_id = 140, category = "Tattoos", collection = "mpsmuggler_overlays", overlay = "MP_Smuggler_Tattoo_012_M", name = "" });
        acessories.Add(new { item_id = 141, category = "Tattoos", collection = "mpimportexport_overlays", overlay = "MP_MP_ImportExport_Tat_001_F", name = "" });
        acessories.Add(new { item_id = 141, category = "Tattoos", collection = "mpimportexport_overlays", overlay = "MP_MP_ImportExport_Tat_001_M", name = "" });
        acessories.Add(new { item_id = 142, category = "Tattoos", collection = "mpimportexport_overlays", overlay = "MP_MP_ImportExport_Tat_002_F", name = "" });
        acessories.Add(new { item_id = 142, category = "Tattoos", collection = "mpimportexport_overlays", overlay = "MP_MP_ImportExport_Tat_002_M", name = "" });
        acessories.Add(new { item_id = 143, category = "Tattoos", collection = "mpimportexport_overlays", overlay = "MP_MP_ImportExport_Tat_003_F", name = "" });
        acessories.Add(new { item_id = 143, category = "Tattoos", collection = "mpimportexport_overlays", overlay = "MP_MP_ImportExport_Tat_003_M", name = "" });
        acessories.Add(new { item_id = 144, category = "Tattoos", collection = "mpimportexport_overlays", overlay = "MP_MP_ImportExport_Tat_004_F", name = "" });
        acessories.Add(new { item_id = 144, category = "Tattoos", collection = "mpimportexport_overlays", overlay = "MP_MP_ImportExport_Tat_004_M", name = "" });
        acessories.Add(new { item_id = 145, category = "Tattoos", collection = "mpimportexport_overlays", overlay = "MP_MP_ImportExport_Tat_005_F", name = "" });
        acessories.Add(new { item_id = 145, category = "Tattoos", collection = "mpimportexport_overlays", overlay = "MP_MP_ImportExport_Tat_005_M", name = "" });
        acessories.Add(new { item_id = 146, category = "Tattoos", collection = "mpimportexport_overlays", overlay = "MP_MP_ImportExport_Tat_006_F", name = "" });
        acessories.Add(new { item_id = 146, category = "Tattoos", collection = "mpimportexport_overlays", overlay = "MP_MP_ImportExport_Tat_006_M", name = "" });
        acessories.Add(new { item_id = 147, category = "Tattoos", collection = "mpimportexport_overlays", overlay = "MP_MP_ImportExport_Tat_007_F", name = "" });
        acessories.Add(new { item_id = 147, category = "Tattoos", collection = "mpimportexport_overlays", overlay = "MP_MP_ImportExport_Tat_007_M", name = "" });
        acessories.Add(new { item_id = 148, category = "Tattoos", collection = "mpimportexport_overlays", overlay = "MP_MP_ImportExport_Tat_008_F", name = "" });
        acessories.Add(new { item_id = 149, category = "Tattoos", collection = "mpimportexport_overlays", overlay = "MP_MP_ImportExport_Tat_009_M", name = "" });
        acessories.Add(new { item_id = 149, category = "Tattoos", collection = "mpimportexport_overlays", overlay = "MP_MP_ImportExport_Tat_010_F", name = "" });
        acessories.Add(new { item_id = 150, category = "Tattoos", collection = "mpimportexport_overlays", overlay = "MP_MP_ImportExport_Tat_010_M", name = "" });
        acessories.Add(new { item_id = 150, category = "Tattoos", collection = "mpimportexport_overlays", overlay = "MP_MP_ImportExport_Tat_011_F", name = "" });
        acessories.Add(new { item_id = 151, category = "Tattoos", collection = "mpimportexport_overlays", overlay = "MP_MP_ImportExport_Tat_011_M", name = "" });
        acessories.Add(new { item_id = 151, category = "Tattoos", collection = "mpimportexport_overlays", overlay = "MP_MP_ImportExport_Tat_012_F", name = "" });
        acessories.Add(new { item_id = 152, category = "Tattoos", collection = "mpimportexport_overlays", overlay = "MP_MP_ImportExport_Tat_012_M", name = "" });
        acessories.Add(new { item_id = 152, category = "Tattoos", collection = "mpimportexport_overlays", overlay = "MP_MP_ImportExport_Tat_008_M", name = "" });

    }

    public static int GetClotheIndex(string name)
    {
        int index = -1, foreach_index = -1;

        foreach (var clothes in acessories)
        {
            if (clothes.name == name)
            {
                return index = foreach_index;
            }
            foreach_index++;
        }
        return -1;
    }

    public static int GetMenuItems(string category)
    {
        int index = 0;
        foreach (var clothes in acessories)
        {
            if (clothes.clothe_class == category)
            {
                index += 1;
            }
        }
        return index;
    }

    public static int GetClotheIndexFirst(string category)
    {
        int index = 0, foreach_index = 0;

        foreach (var clothes in acessories)
        {
            if (clothes.clothe_class == category)
            {
                return index = foreach_index;
            }
            foreach_index++;
        }
        return -1;
    }

    public static int GetClotheIndexLast(string category)
    {
        int index = GetClotheIndexFirst(category);
        foreach (var clothes in acessories)
        {
            if (clothes.clothe_class == category)
            {
                index += 1;
            }
        }
        return index;
    }

    [RemoteEvent("Preview_Tattoo")]
    public static void Preview_Tattoo(Client player, int index)
    {
        // vorherige löschen
        player.SetDecoration(new Decoration { Collection = NAPI.Util.GetHashKey((string)acessories[index].collection), Overlay = NAPI.Util.GetHashKey((string)acessories[index].overlay) });
        //Decoration data = new Decoration();
        //data.Collection = NAPI.Util.GetHashKey((string)acessories[index].collection);
        //data.Overlay = NAPI.Util.GetHashKey((string)acessories[index].overlay);
        //NAPI.Player.RemovePlayerDecoration(player, data);
        NAPI.Player.ClearPlayerDecorations(player);
        //player.RemoveDecoration(player);

        // neues setzen
        player.SetDecoration(new Decoration { Collection = NAPI.Util.GetHashKey((string)acessories[index].collection), Overlay = NAPI.Util.GetHashKey((string)acessories[index].overlay) });
        //data.Collection = NAPI.Util.GetHashKey((string)acessories[index].collection);
        //data.Overlay = NAPI.Util.GetHashKey((string)acessories[index].overlay);
        //NAPI.Player.SetPlayerDecoration(player, data);
    }

    public static void ShowClothesMainMenu(Client player, string response)
    {
        int count = 0;
        List<string> acessories = new List<string>();
        List<dynamic> menu_item_list = new List<dynamic>();

        acessories.Add("Auswählen");

        count = 0;
        for (int index = 0; index < 153; index++)
        {
                acessories.Add(count.ToString());
                count++;
        }
        menu_item_list.Add(new { Type = 6, Name = "Tattoo´s", Description = "Die Kosten für den Umstieg auf diesen Tattoo betragen ~g~" + PRICE_TATTOO.ToString("N0") + " ~w~Drücke ~c~[ENTER]~w~ um zu kaufen.", List = acessories, StartIndex = 0 });

        player.SetData("Tattoos_NewIndex_Buy", -1);

        InteractMenu.CreateMenu(player, "TATTOOSTUDIO_MENU", "Tattoo Studio", "~g~", true, NAPI.Util.ToJson(menu_item_list), false, MouseControl: true);
        player.TriggerEvent("ps_BodyCamera");
        if (NAPI.Data.GetEntityData(player, "shirt_enable") == true)
        {
            if (NAPI.Data.GetEntityData(player, "CHARACTER_ONLINE_GENRE") == 0)
            {
                player.SetClothes(3, 15, 0);
                player.SetClothes(11, 15, 0);
                player.SetClothes(8, 15, 0);
                player.SetData("shirt_enable", false);
                NAPI.Data.SetEntitySharedData(player, "using_torso", false);
                NAPI.Data.SetEntitySharedData(player, "using_shirt", false);
                NAPI.Data.SetEntitySharedData(player, "using_undershirt", false);
            }
            else
            {
                player.SetClothes(3, 15, 0);
                player.SetClothes(11, 15, 0);
                player.SetClothes(8, 15, 0);
                player.SetData("shirt_enable", false);
                NAPI.Data.SetEntitySharedData(player, "using_torso", false);
                NAPI.Data.SetEntitySharedData(player, "using_shirt", false);
                NAPI.Data.SetEntitySharedData(player, "using_undershirt", false);
            }
        }
    }

    public static void OnMenuReturnClose(Client player, String callbackId)
    {
        if (callbackId == "TATTOOSTUDIO_MENU")
        {
            player.TriggerEvent("ps_DestroyCamera");
            UsefullyRP.charclothes[Main.getIdFromClient(player)] = true;
            player.SetData("shirt_enable", true);
            NAPI.Data.SetEntitySharedData(player, "using_torso", true);
            NAPI.Data.SetEntitySharedData(player, "using_shirt", true);
            NAPI.Data.SetEntitySharedData(player, "using_undershirt", true);
            player.SetClothes(3, (int)NAPI.Data.GetEntitySharedData(player, "character_torso"), (int)NAPI.Data.GetEntitySharedData(player, "character_torso_texture"));
            player.SetClothes(11, (int)NAPI.Data.GetEntitySharedData(player, "character_shirt"), (int)NAPI.Data.GetEntitySharedData(player, "character_shirt_texture"));
            player.SetClothes(8, (int)NAPI.Data.GetEntitySharedData(player, "character_undershirt"), (int)NAPI.Data.GetEntitySharedData(player, "character_undershirt_texture"));
            player.TriggerEvent("Destroy_Character_Menu");
            Main.UpdatePlayerClothes(player);
        }
    }

    public static void SelectMenuResponse(Client player, String callbackId, int selectedIndex, String objectName, String valueList)
    {
        if (callbackId == "TATTOOSTUDIO_MENU")
        {

            switch (selectedIndex)
            {
                case 0:
                    {
                        
                        if (player.GetData("Tattoos_NewIndex_Buy") == -1)
                        {
                            InteractMenu_New.SendNotificationError(player, "Sie müssen zuerst den zu kaufenden Artikel auswählen.");
                            //Update_Player_Clothes(player);
                            return;
                        }
                        BuyTattoo(player, player.GetData("Tattoos_NewIndex_Buy"));
                        break;
                    }
            }
        }
    }


    public static void ListItemMenuResponse(Client player, String callbackId, int selectedIndex, String objectName, String valueList, int valueIndex)
    {
        if (callbackId == "TATTOOSTUDIO_MENU")
        {

            switch (selectedIndex)
            {
                case 0:
                    {
                        if (valueList == "Auswählen")
                        {
                            if (valueList == "Auswählen")
                            {
                                player.SetData("Tattoos_NewIndex_Buy", -1);
                                return;
                            }
                        }
                        player.SetData("Tattoos_NewIndex_Buy", Convert.ToInt32(valueList));
                        Preview_Tattoo(player, Convert.ToInt32(valueList));
                        break;
                    }
            }
        }
    }

    [RemoteEvent("Buy_Tattoo")]
    public static void BuyTattoo(Client player, int item_id)
    {

        var business_id = Business.GetPlayerInBusinessInType(player, 14);
        if (business_id == -1)
        {
            Main.SendErrorMessage(player, "Sie befinden sich nicht in einer Firma.");
            //ClothesCloseMenu(player);
            return;
        }

        int item_price = PRICE_TATTOO;

        if (item_id == -1)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "[" + Business.business_list[business_id].business_Name + "]:~w~ Wir konnten Ihre Anfrage nicht bearbeiten. Sie müssen zunächst eine Art von Element auswählen.");
            //player.TriggerEvent("show_menu_shirts", 0);
            //ClothesCloseMenu(player);
        }
        else
        {
            if (Main.GetPlayerMoney(player) < item_price)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "[" + Business.business_list[business_id].business_Name + "]:~w~ Der Artikel, den Sie zu kaufen versuchen, kostet $" + item_price + ", sie haben nicht genug Geld in Ihren Händen.");
                //ClothesCloseMenu(player);
                return;
            }

            //Business safe and Inventory stuffs
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
                    NAPI.Notification.SendNotificationToPlayer(player, "[" + Business.business_list[business_id].business_Name + "]:~w~ Unser Unternehmen hat momentan nichts auf Lager, bitte kommen Sie später wieder!");
                    //ClothesCloseMenu(player);
                    return;
                }
            }

            Main.GivePlayerMoney(player, -item_price);
            string name = "unbekannt";

            name = "unbekannt";

                player.SetSharedData("character_tattoo_collection", (string)acessories[item_id].collection);
                player.SetSharedData("character_tattoo_overlay", (string)acessories[item_id].overlay);
                name = acessories[item_id].name;
                AccountManage.SaveCharacter(player);

            Notify.Send(player, NotifyType.Success, NotifyPosition.BottomCenter, $"Du hast ein Tattoo ~w~für ~g~$" + item_price + " gekauft.", 5000);
            //NAPI.Notification.SendNotificationToPlayer(player, "Du hast ein Tattoo ~w~für ~g~$" + item_price + " gekauft.");
            player.TriggerEvent("ps_DestroyCamera");
        }

    }

    [RemoteEvent("Tattoo_Menu_Destroy")]
    public static void ClothesCloseMenu(Client player)
    {
        UsefullyRP.charclothes[Main.getIdFromClient(player)] = true;
        player.SetData("shirt_enable", true);
        NAPI.Data.SetEntitySharedData(player, "using_torso", true);
        NAPI.Data.SetEntitySharedData(player, "using_shirt", true);
        NAPI.Data.SetEntitySharedData(player, "using_undershirt", true);
        player.SetClothes(3, (int)NAPI.Data.GetEntitySharedData(player, "character_torso"), (int)NAPI.Data.GetEntitySharedData(player, "character_torso_texture"));
        player.SetClothes(11, (int)NAPI.Data.GetEntitySharedData(player, "character_shirt"), (int)NAPI.Data.GetEntitySharedData(player, "character_shirt_texture"));
        player.SetClothes(8, (int)NAPI.Data.GetEntitySharedData(player, "character_undershirt"), (int)NAPI.Data.GetEntitySharedData(player, "character_undershirt_texture"));
        player.TriggerEvent("ps_DestroyCamera");
        player.TriggerEvent("Destroy_Character_Menu");
        Main.UpdatePlayerClothes(player);
    }


    [RemoteEvent("Update_Player_Tattoo")]
    public static void Update_Player_Tattoo(Client player)
    {
        player.TriggerEvent("ps_DestroyCamera");
        Main.UpdatePlayerClothes(player);
    }
}
