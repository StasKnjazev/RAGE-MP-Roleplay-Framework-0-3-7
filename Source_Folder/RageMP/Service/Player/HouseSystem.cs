using System;
using System.Collections.Generic;
using GTANetworkAPI;
using MySql.Data.MySqlClient;
using DerStr1k3r.Core;
using DerStr1k3r.SDK;

public class HouseSystem : Script
{
    public static int HOUSES_CREATED = 0;
    public static int MAX_INVENTORY_ITENS = 100;

    public class HouseEnum : IEquatable<HouseEnum>
    {
        public int id { get; set; }

        public string name { get; set; }
        public string owner_name { get; set; }

        public int owner { get; set; }
        public int price { get; set; }
        public int vip { get; set; }
        public int locked { get; set; }
        public int sell_house { get; set; }

        public int safe { get; set; }

        public Vector3 exterior { get; set; }
        public Vector3 interior { get; set; }
        public Vector3 exterior_garage { get; set; }
        public Vector3 interior_garage { get; set; }
        public float exterior_a { get; set; }
        public float interior_a { get; set; }
        public float exterior_garage_a { get; set; }
        public float interior_garage_a { get; set; }

        public TextLabel label { get; set; }
        public Marker marker { get; set; }
        public Blip blip { get; set; }
        public ColShape Shape { get; set; }


        public TextLabel label_interior { get; set; }
        public Marker marker_interior { get; set; }


        public string[] key_acess { get; set; } = new string[10];

        // furniture
        public GTANetworkAPI.Object[] furniture_handle { get; set; } = new GTANetworkAPI.Object[60];
        public int[] furniture_id { get; set; } = new int[60];
        public string[] furniture_name { get; set; } = new string[60];
        public string[] furniture_model_name { get; set; } = new string[60];
        public int[] furniture_model { get; set; } = new int[60];
        public int[] furniture_price { get; set; } = new int[60];
        public int[] furniture_status { get; set; } = new int[60];

        public int[] inventory_index { get; set; } = new int[MAX_INVENTORY_ITENS];
        public int[] inventory_type { get; set; } = new int[MAX_INVENTORY_ITENS];
        public int[] inventory_amount { get; set; } = new int[MAX_INVENTORY_ITENS];


        public Vector3[] furniture_position { get; set; } = new Vector3[60];
        public Vector3[] furniture_rotation { get; set; } = new Vector3[60];

        public override string ToString()
        {
            return "ID: " + id + "   Name: " + name;
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            HouseEnum objAsPart = obj as HouseEnum;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }
        public override int GetHashCode()
        {
            return id;
        }
        public bool Equals(HouseEnum other)
        {
            if (other == null) return false;
            return (this.id.Equals(other.id));
        }
    }


    /*
     -786.9469, 315.5655, 217.6383
         */

    public static List<HouseEnum> HouseInfo = new List<HouseEnum>();
    public static List<dynamic> furniture_data = new List<dynamic>();
    public static List<Vector3> house_cofre = new List<Vector3>();

    public static int MAX_ENTRACE = 200;

    public static void HouseSystemInit()
    {
        //Haushaltsgeräte, Encanamento, Conforto, Decorações, Entretenimento, Iluminação, Armazenamento, Estrutura, Miscelânea
        furniture_data.Add(new { name = "Akustische Gitarre", model = "prop_acc_guitar_01_d1", classe = "Sonstiges", price = 280, hash = -121802573 });
        furniture_data.Add(new { name = "Günstiges Bett", model = "p_lestersbed_s", classe = "Komfort", price = 250, hash = 1937985747 });// || Preço: $250
        furniture_data.Add(new { name = "Verrücktes Leben Bett", model = "p_v_res_tt_bed_s", classe = "Komfort", price = 350, hash = -1211387925 });// || Preço: $350
        furniture_data.Add(new { name = "High Comfort Bett", model = "v_res_msonbed_s", classe = "Komfort", price = 550, hash = -980185685 });// || Preço: $550
        furniture_data.Add(new { name = "Puro Malte Luxusbett", model = "p_mbbed_s", classe = "Komfort", price = 1020, hash = -1284191201 });//  || Preço: $1020
        furniture_data.Add(new { name = "Sofa Tramp", model = "v_tre_sofa_mess_c_s", classe = "Komfort", price = 50, hash = 417935208 });// || Preço: $50
        furniture_data.Add(new { name = "Sofa Detonado", model = "v_tre_sofa_mess_b_s", classe = "Komfort", price = 80, hash = -1726933877 });// || Preço: $80
        furniture_data.Add(new { name = "Sofa Restaurado", model = "v_res_tre_sofa_s", classe = "Komfort", price = 250, hash = 2109741755 });//  || Preço: $250
        furniture_data.Add(new { name = "Sofa Grande", model = "p_v_med_p_sofa_s", classe = "Komfort", price = 250, hash = 1593135630 });// || Preço: $250
        furniture_data.Add(new { name = "Bett Fit", model = "p_res_sofa_l_s", classe = "Komfort", price = 350, hash = -406716247 });//  || Preço: $350
        furniture_data.Add(new { name = "Sofa Alto Corforto", model = "prop_t_sofa", classe = "Komfort", price = 450, hash = -1964110779 });// || Preço: $450
        furniture_data.Add(new { name = "Sofa L", model = "p_lev_sofa_s", classe = "Komfort", price = 760, hash = 1526269963 });// || Preço: $760
        furniture_data.Add(new { name = "Schreibtischstuhl I", model = "prop_off_chair_04_s", classe = "Komfort", price = 120, hash = 475561894 });// || Preço: $120
        furniture_data.Add(new { name = "Schreibtischstuhl V", model = "hei_prop_heist_off_chair", classe = "Komfort", price = 360, hash = -1198343923 });// || Preço: $360
        furniture_data.Add(new { name = "Schreibtischstuhl VX", model = "p_clb_officechair_s", classe = "Komfort", price = 460, hash = -1173315865 });// || Preço: $460
        furniture_data.Add(new { name = "Standardisierter Stuhl", model = "v_ilev_chair02_ped", classe = "Komfort", price = 100, hash = -784954167 });// || Preço: $100
        furniture_data.Add(new { name = "Puro Malte Stuhl", model = "prop_cs_office_chair", classe = "Komfort", price = 180, hash = -1118419705 });// || Preço: $180
        furniture_data.Add(new { name = "Schaukelstuhl", model = "prop_rock_chair_01", classe = "Komfort", price = 120, hash = 854385596 });// || Preço: $120
        furniture_data.Add(new { name = "Boteco Plus Stuhl", model = "prop_chair_pile_01", classe = "Komfort", price = 120, hash = -296249014 });// || Preço: $120
        furniture_data.Add(new { name = "Vorsitzender von Boteco", model = "prop_chair_08", classe = "Komfort", price = 120, hash = 1281480215 });// || Preço: $120
        furniture_data.Add(new { name = "Sessel do Vagabundo", model = "prop_ld_farm_chair01", classe = "Komfort", price = 120, hash = 1281480215 });// || Preço: $120
        furniture_data.Add(new { name = "Sessel do Vovo", model = "p_armchair_01_s", classe = "Komfort", price = 250, hash = -2065455377 });// || Preço: $250
        furniture_data.Add(new { name = "Sessel Luxo", model = "p_ilev_p_easychair_s", classe = "Komfort", price = 340, hash = 736919402 });// || Preço: $340
        furniture_data.Add(new { name = "Sessel de Praia", model = "p_yacht_chair_01_s", classe = "Komfort", price = 210, hash = 604553643 });//  || Preço: $210
        furniture_data.Add(new { name = "Fernsehen Antiga", model = "prop_tv_test", classe = "Unterhaltung", price = 100, hash = 1553931317 });// || Preço: $100
        furniture_data.Add(new { name = "Fernsehen de Tubo", model = "prop_tv_03", classe = "Unterhaltung", price = 150, hash = -897601557 });// || Preço: $150
        furniture_data.Add(new { name = "Fernsehen com Rack", model = "prop_cs_tv_stand", classe = "Unterhaltung", price = 350, hash = 122877578 });// || Preço: $350
        furniture_data.Add(new { name = "Fernsehen Simples", model = "prop_trev_tv_01", classe = "Unterhaltung", price = 370, hash = 1434219911 });//  || Preço: $370
        furniture_data.Add(new { name = "Fernsehen Mediana", model = "prop_tv_flat_02", classe = "Unterhaltung", price = 640, hash = 1340914825 });//  || Preço: $640
        furniture_data.Add(new { name = "Fernsehen de Boa Qualidade", model = "prop_tv_flat_01", classe = "Unterhaltung", price = 820, hash = 1036195894 });// || Preço: $820
        furniture_data.Add(new { name = "Fernsehen Gigante", model = "prop_michaels_credit_tv", classe = "Unterhaltung", price = 1120, hash = 566576618 });// || Preço: $1120
        furniture_data.Add(new { name = "Fernsehen Ultra Gigante", model = "hei_heist_str_avunitl_03", classe = "Unterhaltung", price = 2200, hash = 777010715 });// || Preço: $2200
        furniture_data.Add(new { name = "Computer Simples", model = "prop_dyn_pc", classe = "Unterhaltung", price = 850, hash = -1830645735 });// || Preço: $850
        furniture_data.Add(new { name = "Computer Bom", model = "prop_pc_02a", classe = "Unterhaltung", price = 1000, hash = 1654151435 });//  || Preço: $1000
        furniture_data.Add(new { name = "Laptop Lenovo", model = "p_cs_laptop_02", classe = "Unterhaltung", price = 1300, hash = 2109346928 });//  || Preço: $1300
        furniture_data.Add(new { name = "Macbook", model = "prop_laptop_jimmy", classe = "Unterhaltung", price = 2000, hash = 363555755 });// || Preço: $2000
        furniture_data.Add(new { name = "Macbook X", model = "prop_laptop_lester", classe = "Unterhaltung", price = 2200, hash = 881450200 });// || Preço: $2200
        furniture_data.Add(new { name = "Pussy Beat Box ", model = "prop_speaker_05", classe = "Unterhaltung", price = 550, hash = -1885111468 });// || Preço: $550
        furniture_data.Add(new { name = "Simple Beat Box", model = "prop_speaker_08", classe = "Unterhaltung", price = 550, hash = 648227157 });//  || Preço: $550
        furniture_data.Add(new { name = "Black Beat Box", model = "v_res_mm_audio", classe = "Unterhaltung", price = 850, hash = 2079380440 });// || Preço: $850
        furniture_data.Add(new { name = "Black Beat JBL Box", model = "prop_speaker_01", classe = "Unterhaltung", price = 950, hash = -968169310 });// || Preço: $950
        furniture_data.Add(new { name = "einfach Uhr", model = "prop_game_clock_01", classe = "Sonstiges", price = 20, hash = -1004588353 });// || Preço: $20
        furniture_data.Add(new { name = "basic Uhr", model = "prop_big_clock_01", classe = "Sonstiges", price = 35, hash = -346427197 });// || Preço: $35
        furniture_data.Add(new { name = "exklusive Uhr", model = "prop_hotel_clock_01", classe = "Sonstiges", price = 50, hash = 495599970 });//  || Preço: $50
        furniture_data.Add(new { name = "USA Uhr", model = "prop_v_15_cars_clock", classe = "Sonstiges", price = 40, hash = 763497189 });// || Preço: $40
        furniture_data.Add(new { name = "DVD Bluray", model = "prop_cs_dvd_player", classe = "Unterhaltung", price = 350, hash = 159474821 });//  || Preço: $350
        furniture_data.Add(new { name = "Kamera 360°", model = "hei_prop_bank_cctv_02", classe = "Sonstiges", price = 250, hash = -1842407088 });//  || Preço: $250
        furniture_data.Add(new { name = "Kamera Kjo", model = "p_cctv_s", classe = "Sonstiges", price = 350, hash = 289451089 });// || Preço: $350
        furniture_data.Add(new { name = "Kamera Espiã", model = "prop_spycam", classe = "Sonstiges", price = 200, hash = -203475463 });//  || Preço: $200
        furniture_data.Add(new { name = "Bong", model = "hei_heist_sh_bong_01", classe = "Sonstiges", price = 200, hash = 1874679314 });//   || Preço: $200
        furniture_data.Add(new { name = "Tablet ", model = "prop_cs_tablet", classe = "Entertaiment", price = 500, hash = -1585232418 });// || Preço: $500
        furniture_data.Add(new { name = "Ipad", model = "prop_cs_tablet_02", classe = "Entertaiment", price = 1000, hash = 921401054 });//  || Preço: $1000
        furniture_data.Add(new { name = "Billiard", model = "prop_pooltable_02", classe = "Entertaiment", price = 800, hash = 322248450 });//  || Preço: $800
        furniture_data.Add(new { name = "Ping Pong", model = "prop_table_tennis", classe = "Entertaiment", price = 800, hash = -692384911 });//  || Preço: $800  
        furniture_data.Add(new { name = "Getränkeflaschen", model = "beerrow_local", classe = "Sonstiges", price = 40, hash = -1574447115 });// || Preço: $40
        furniture_data.Add(new { name = "Arsenal BioTip", model = "hei_bio_heist_gear", classe = "Sonstiges", price = 10000, hash = -912160221 });// || Preço: $10000
        furniture_data.Add(new { name = "Arsenal Movel", model = "hei_p_generic_heist_guns", classe = "Sonstiges", price = 7500, hash = -1585232418 });// || Preço: $7500
        furniture_data.Add(new { name = "Überwachungskamera", model = "hei_prop_bank_cctv_01", classe = "Sonstiges", price = 340, hash = -1007354661 });// || Preço: $340
        furniture_data.Add(new { name = "Karten", model = "hei_prop_dlc_heist_map", classe = "Sonstiges", price = 50, hash = 1609935604 });// || Preço: $50
        furniture_data.Add(new { name = "Königliche Statue Superheld", model = "hei_prop_drug_statue_01", classe = "Sonstiges", price = 500, hash = 155105927 });// || Preço: $500
        furniture_data.Add(new { name = "GOLD", model = "hei_prop_gold_trolly_half_full", classe = "Sonstiges", price = 10000, hash = -636408770 });//  || Preço: $10000
        furniture_data.Add(new { name = "Geld", model = "hei_prop_hei_cash_trolly_01", classe = "Sonstiges", price = 7000, hash = 269934519 });//  || Preço: $7000
        furniture_data.Add(new { name = "Koffer mit Drogen", model = "hei_prop_hei_drug_case", classe = "Sonstiges", price = 3500, hash = 1049338225 });//  || Preço: $3500
        furniture_data.Add(new { name = "Goldbarren", model = "hei_prop_heist_gold_bar", classe = "Sonstiges", price = 2000, hash = -599546004 });//  || Preço: $2000
        furniture_data.Add(new { name = "Kaffeetasse", model = "ng_proc_coffee_01a", classe = "Sonstiges", price = 20, hash = -163314598 });//  || Preço: $20
        furniture_data.Add(new { name = "Viel Geld wert", model = "p_large_gold_s", classe = "Sonstiges", price = 50000, hash = -1585232418 });// || Preço: $50000
        furniture_data.Add(new { name = "Planungstafel", model = "p_planning_board_04", classe = "Sonstiges", price = 500, hash = -2117059320 });//  || Preço: $500

        NAPI.TextLabel.CreateTextLabel("- ~c~Lager~w~ -", new Vector3(152.2726, -1001.37, -99), 8.0f, 0.6f, 0, new Color(255, 255, 255, 255), false);
        NAPI.Marker.CreateMarker(27, new Vector3(152.2726, -1001.37, -99) - new Vector3(0, 0, 0.8f), new Vector3(), new Vector3(), 1.5f, new Color(11, 158, 16, 150), false);

        NAPI.TextLabel.CreateTextLabel("- ~c~Lager~w~ -", new Vector3(350.7189, -993.5916, -99.19617), 8.0f, 0.6f, 0, new Color(255, 255, 255, 255), false);
        NAPI.Marker.CreateMarker(27, new Vector3(350.7189, -993.5916, -99.19617) - new Vector3(0, 0, 0.8f), new Vector3(), new Vector3(), 1.5f, new Color(11, 158, 16, 150), false);

        NAPI.TextLabel.CreateTextLabel("- ~c~Lager~w~ -", new Vector3(-680.7666, 589.0926, 137.7698), 8.0f, 0.6f, 0, new Color(255, 255, 255, 255), false);
        NAPI.Marker.CreateMarker(27, new Vector3(-680.7666, 589.0926, 137.7698) - new Vector3(0, 0, 0.8f), new Vector3(), new Vector3(), 1.5f, new Color(11, 158, 16, 150), false);

        NAPI.TextLabel.CreateTextLabel("- ~c~Lager~w~ -", new Vector3(-765.5396, 330.8761, 196.086), 8.0f, 0.6f, 0, new Color(255, 255, 255, 255), false);
        NAPI.Marker.CreateMarker(27, new Vector3(-765.5396, 330.8761, 196.086) - new Vector3(0, 0, 0.8f), new Vector3(), new Vector3(), 1.5f, new Color(11, 158, 16, 150), false);

        NAPI.TextLabel.CreateTextLabel("- ~c~Lager~w~ -", new Vector3(985.2975, 60.41732, 116.1642), 8.0f, 0.6f, 0, new Color(255, 255, 255, 255), false);
        NAPI.Marker.CreateMarker(27, new Vector3(985.2975, 60.41732, 116.1642) - new Vector3(0, 0, 0.8f), new Vector3(), new Vector3(), 1.5f, new Color(11, 158, 16, 150), false);

        /*          if (Main.IsInRangeOfPoint(player.Position, new Vector3(259.8143, -1003.954, -99.00856), 2.0f)||
         *          Main.IsInRangeOfPoint(player.Position, new Vector3(350.7189, -993.5916, -99.19617), 2.0f) ||
         *          Main.IsInRangeOfPoint(player.Position, new Vector3(-680.7666, 589.0926, 137.7698), 2.0f))
                {*/

        /*     NAPI.TextLabel.CreateTextLabel("- ~c~Armário de Itens~w~ -~n~~n~Pressione ~b~Y~w~ para usar", new Vector3(259.8143, -1003.954, -99.00856), 8.0f, 0.6f, 0, new Color(255, 255, 255, 255), false);
             NAPI.Marker.CreateMarker(25, new Vector3(259.8143, -1003.954, -99.00856) - new Vector3(0, 0, 0.8f), new Vector3(), new Vector3(), 1.5f, new Color(11, 158, 16, 150), false);

             NAPI.TextLabel.CreateTextLabel("- ~c~Armário de Itens~w~ -~n~~n~Pressione ~b~Y~w~ para usar", new Vector3(350.7189, -993.5916, -99.19617), 8.0f, 0.6f, 0, new Color(255, 255, 255, 255), false);
             NAPI.Marker.CreateMarker(25, new Vector3(350.7189, -993.5916, -99.19617) - new Vector3(0, 0, 0.8f), new Vector3(), new Vector3(), 1.5f, new Color(11, 158, 16, 150), false);

             NAPI.TextLabel.CreateTextLabel("- ~c~Armário de Itens~w~ -~n~~n~Pressione ~b~Y~w~ para usar", new Vector3(-680.7666, 589.0926, 137.7698), 8.0f, 0.6f, 0, new Color(255, 255, 255, 255), false);
             NAPI.Marker.CreateMarker(25, new Vector3(-680.7666, 589.0926, 137.7698) - new Vector3(0, 0, 0.8f), new Vector3(), new Vector3(), 1.5f, new Color(11, 158, 16, 150), false);

             NAPI.TextLabel.CreateTextLabel("- ~c~Armário de Itens~w~ -~n~~n~Pressione ~b~Y~w~ para usar", new Vector3(-680.7666, 589.0926, 137.7698), 8.0f, 0.6f, 0, new Color(255, 255, 255, 255), false);
             NAPI.Marker.CreateMarker(25, new Vector3(-680.7666, 589.0926, 137.7698) - new Vector3(0, 0, 0.8f), new Vector3(), new Vector3(), 1.5f, new Color(11, 158, 16, 150), false);

             */
        house_cofre.Add(new Vector3(152.2726, -1001.37, -99));
        house_cofre.Add(new Vector3(350.7189, -993.5916, -99.19617));
        house_cofre.Add(new Vector3(-680.7666, 589.0926, 137.7698));

        house_cofre.Add(new Vector3(-765.5396, 330.8761, 196.086));
        house_cofre.Add(new Vector3(985.2975, 60.41732, 116.1642));
        //house_cofre.Add(new Vector3(-858.3709, 697.944, 145.253));
        //house_cofre.Add(new Vector3(118.6947, 566.7052, 176.6971));
        //house_cofre.Add(new Vector3(-1287.923, 455.8705, 90.29468));

        foreach (var cofre in house_cofre)
        {

            NAPI.TextLabel.CreateTextLabel("- ~c~Drücke ~b~E~w~ ", cofre, 8.0f, 0.6f, 0, new Color(255, 255, 255, 255), false);
            NAPI.Marker.CreateMarker(25, cofre - new Vector3(0, 0, 0.8f), new Vector3(), new Vector3(), 1.5f, new Color(11, 158, 16, 150), false);

        }

        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {

            Mainpipeline.Open();
            MySqlCommand query = new MySqlCommand("SELECT * FROM `houses`;", Mainpipeline);



            using (MySqlDataReader reader = query.ExecuteReader())
            {

                var index = 0;
                while (reader.Read())
                {
                    if (index > MAX_ENTRACE) break;
                    HouseInfo.Add(new HouseEnum()
                    {
                        id = reader.GetInt32("id"),
                        name = reader.GetString("name"),
                        owner = reader.GetInt32("owner"),
                        owner_name = reader.GetString("owner_name"),
                        price = reader.GetInt32("price"),
                        vip = reader.GetInt32("vip"),
                        locked = reader.GetInt32("lock_status"),
                        sell_house = reader.GetInt32("sell_house"),
                        exterior = new Vector3(float.Parse(reader.GetString("exterior_x").Replace(Translation.COORDS_FROM, Translation.COORDS_TO)), float.Parse(reader.GetString("exterior_y").Replace(Translation.COORDS_FROM, Translation.COORDS_TO)), float.Parse(reader.GetString("exterior_z").Replace(Translation.COORDS_FROM, Translation.COORDS_TO))),
                        interior = new Vector3(float.Parse(reader.GetString("interior_x").Replace(Translation.COORDS_FROM, Translation.COORDS_TO)), float.Parse(reader.GetString("interior_y").Replace(Translation.COORDS_FROM, Translation.COORDS_TO)), float.Parse(reader.GetString("interior_z").Replace(Translation.COORDS_FROM, Translation.COORDS_TO))),
                        exterior_a = float.Parse(reader.GetString("exterior_a").Replace(Translation.COORDS_FROM, Translation.COORDS_TO)),
                        interior_a = float.Parse(reader.GetString("interior_a").Replace(Translation.COORDS_FROM, Translation.COORDS_TO)),
                        exterior_garage = new Vector3(reader.GetFloat("exterior_garage_x"), reader.GetFloat("exterior_garage_y"), reader.GetFloat("exterior_garage_z")),
                        interior_garage = new Vector3(reader.GetFloat("interior_garage_x"), reader.GetFloat("interior_garage_y"), reader.GetFloat("interior_garage_z")),
                    });


                    for (int i = 0; i < 9; i++)
                    {
                        HouseInfo[index].key_acess[i] = reader.GetString("house_key_" + i);
                    }

                    //HouseInfo[index].blip = NAPI.Blip.CreateBlip(HouseInfo[index].exterior);
                    //NAPI.Blip.SetBlipName(HouseInfo[index].blip, "Haus");
                    //NAPI.Blip.SetBlipSprite(HouseInfo[index].blip, 350);
                    //NAPI.Blip.SetBlipScale(HouseInfo[index].blip, 0.5f);
                    //NAPI.Blip.SetBlipShortRange(HouseInfo[index].blip, true);

                    ////HouseInfo[index].blip = NAPI.Blip.CreateBlip(HouseInfo[index].exterior);
                    ////HouseInfo[index].blip.Sprite = 350;
                    ////HouseInfo[index].blip.Name = "Haus";
                    ////HouseInfo[index].blip.Color = 1;
                    ////HouseInfo[index].blip.ShortRange = true;

                    if (HouseInfo[index].exterior.X == 0 && HouseInfo[index].exterior.Y == 0)
                    {
                       // NAPI.Blip.SetBlipTransparency(HouseInfo[index].blip, 0);
                    }

                    UpdateHouseLabel(index, false);

                    for (int i = 0; i < 60; i++)
                    {
                        HouseInfo[index].furniture_id[i] = -1;
                        HouseInfo[index].furniture_name[i] = "";
                        HouseInfo[index].furniture_model_name[i] = "";
                        HouseInfo[index].furniture_model[i] = 0;
                        HouseInfo[index].furniture_price[i] = 0;
                        HouseInfo[index].furniture_status[i] = 0;

                        HouseInfo[index].furniture_position[i] = new Vector3(0, 0, 0);
                        HouseInfo[index].furniture_rotation[i] = new Vector3(0, 0, 0);
                    }

                    for (int i = 0; i < MAX_INVENTORY_ITENS; i++)
                    {
                        HouseInfo[index].inventory_index[i] = -1;
                        HouseInfo[index].inventory_type[i] = 0;
                        HouseInfo[index].inventory_amount[i] = 0;
                    }



                    HouseInfo[index].Shape = NAPI.ColShape.CreateCylinderColShape(HouseInfo[index].exterior, 1, 2, 0);
                    /*HouseInfo[index].Shape.OnEntityEnterColShape += (s, ent) =>
                    {
                        try
                        {
                            NAPI.Data.SetEntityData(ent, "HOUSEID", index);
                            NAPI.Data.SetEntityData(ent, "INTERACTIONCHECK", 6);
                            Gopostal.GoPostal_onEntityEnterColShape(s, ent);
                        }
                        catch (Exception ex) { Console.WriteLine("shape.OnEntityEnterColShape: " + ex.Message); }
                    };
                    HouseInfo[index].Shape.OnEntityExitColShape += (s, ent) =>
                    {
                        try
                        {
                            NAPI.Data.SetEntityData(ent, "INTERACTIONCHECK", 0);
                            NAPI.Data.ResetEntityData(ent, "HOUSEID");
                        }
                        catch (Exception ex) { Console.WriteLine("shape.OnEntityExitColShape: " + ex.Message); }
                    };*/


                    LoadFurniture(index);
                    LoadInventoryItens(index);



                    index++;
                }
                //Fire.FireInit();
                HOUSES_CREATED = index;
            }
        }
    }

    public static void SaveEntrace(int index)
    {
        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {
            try
            {
                Mainpipeline.Open();
                string query = "UPDATE `houses` SET `name` = @name, `owner` = @owner, `owner_name` = @owner_name,  `sell_house` = @sell_house, `lock_status` = @lock_status, `price` = @price, `vip` = @vip, `exterior_x` = @exterior_x, `exterior_y` = @exterior_y, `exterior_z` = @exterior_z, `exterior_a` = @exterior_a, `interior_x` = @interior_x, `interior_y` = @interior_y, `interior_z` = @interior_z, `interior_a` = @interior_a, `exterior_garage_x` = @exterior_garage_x, `exterior_garage_y` = @exterior_garage_y , `exterior_garage_z` = @exterior_garage_z , `exterior_garage_a` = @exterior_garage_a , `interior_garage_x` = @interior_garage_x , `interior_garage_y` = @interior_garage_y , `interior_garage_z` = @interior_garage_z , `interior_garage_a` = @interior_garage_a ";

                for (int i = 0; i < 9; i++)
                {
                    query = query + ", `house_key_" + i + "` = @house_key_" + i + " ";
                }

                query = query + " WHERE `id` = '" + HouseInfo[index].id + "'";


                MySqlCommand myCommand = new MySqlCommand(query, Mainpipeline);


                myCommand.Parameters.AddWithValue("@name", "" + HouseInfo[index].name + "");
                myCommand.Parameters.AddWithValue("@owner", HouseInfo[index].owner);
                myCommand.Parameters.AddWithValue("@owner_name", HouseInfo[index].owner_name);
                myCommand.Parameters.AddWithValue("@lock_status", HouseInfo[index].locked);
                myCommand.Parameters.AddWithValue("@price", HouseInfo[index].price);
                myCommand.Parameters.AddWithValue("@sell_house", HouseInfo[index].sell_house);

                myCommand.Parameters.AddWithValue("@vip", HouseInfo[index].vip);

                for (int i = 0; i < 9; i++)
                {
                    myCommand.Parameters.AddWithValue("@house_key_" + i, "" + HouseInfo[index].key_acess[i] + "");
                }

                myCommand.Parameters.AddWithValue("@exterior_x", HouseInfo[index].exterior.X.ToString());
                myCommand.Parameters.AddWithValue("@exterior_y", HouseInfo[index].exterior.Y.ToString());
                myCommand.Parameters.AddWithValue("@exterior_z", HouseInfo[index].exterior.Z.ToString());
                myCommand.Parameters.AddWithValue("@exterior_a", HouseInfo[index].exterior_a.ToString());
                myCommand.Parameters.AddWithValue("@interior_x", HouseInfo[index].interior.X.ToString());
                myCommand.Parameters.AddWithValue("@interior_y", HouseInfo[index].interior.Y.ToString());
                myCommand.Parameters.AddWithValue("@interior_z", HouseInfo[index].interior.Z.ToString());
                myCommand.Parameters.AddWithValue("@interior_a", HouseInfo[index].interior_a.ToString());

                myCommand.Parameters.AddWithValue("@exterior_garage_x", HouseInfo[index].exterior_garage.X.ToString());
                myCommand.Parameters.AddWithValue("@exterior_garage_y", HouseInfo[index].exterior_garage.Y.ToString());
                myCommand.Parameters.AddWithValue("@exterior_garage_z", HouseInfo[index].exterior_garage.Z.ToString());
                myCommand.Parameters.AddWithValue("@exterior_garage_a", HouseInfo[index].exterior_garage_a.ToString());

                myCommand.Parameters.AddWithValue("@interior_garage_x", HouseInfo[index].interior_garage.X.ToString());
                myCommand.Parameters.AddWithValue("@interior_garage_y", HouseInfo[index].interior_garage.Y.ToString());
                myCommand.Parameters.AddWithValue("@interior_garage_z", HouseInfo[index].interior_garage.Z.ToString());
                myCommand.Parameters.AddWithValue("@interior_garage_a", HouseInfo[index].interior_garage_a.ToString());

                myCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                NAPI.Util.ConsoleOutput("[EXCEPTION AddSMSLog] " + ex.Message);
                NAPI.Util.ConsoleOutput("[EXCEPTION AddSMSLog] " + ex.StackTrace);
            }
        }
    }

    public static void LoadFurniture(int house_id)
    {
        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {
            Mainpipeline.Open();
            MySqlCommand query = new MySqlCommand("SELECT * FROM `furnitures` WHERE `house` = " + house_id + ";", Mainpipeline);

            using (MySqlDataReader reader = query.ExecuteReader())
            {

                var index = 0;
                while (reader.Read())
                {
                    HouseInfo[house_id].furniture_id[index] = reader.GetInt32("id");
                    HouseInfo[house_id].furniture_name[index] = reader.GetString("name");
                    HouseInfo[house_id].furniture_model_name[index] = reader.GetString("model_name");
                    HouseInfo[house_id].furniture_model[index] = reader.GetInt32("model");
                    HouseInfo[house_id].furniture_price[index] = reader.GetInt32("price");
                    HouseInfo[house_id].furniture_status[index] = reader.GetInt32("status");
                    HouseInfo[house_id].furniture_position[index] = new Vector3(float.Parse(reader.GetString("position_x")), float.Parse(reader.GetString("position_y")), float.Parse(reader.GetString("position_z")));
                    HouseInfo[house_id].furniture_rotation[index] = new Vector3(float.Parse(reader.GetString("rotation_x")), float.Parse(reader.GetString("rotation_y")), float.Parse(reader.GetString("rotation_z")));

                    NAPI.Util.ConsoleOutput("" + HouseInfo[house_id].furniture_rotation[index] + "" + HouseInfo[house_id].furniture_position[index] + "");
                    HouseInfo[house_id].furniture_handle[index] = NAPI.Object.CreateObject(HouseInfo[house_id].furniture_model[index], HouseInfo[house_id].furniture_position[index], new Vector3(HouseInfo[house_id].furniture_rotation[index].X, HouseInfo[house_id].furniture_rotation[index].Y, HouseInfo[house_id].furniture_rotation[index].Z), 255, 500 + (uint)house_id);
                    index++;
                }
            }
        }
    }

    public static void UpdateFurniture(int house_id)
    {
        for (int index = 0; index < 60; index++)
        {
            if (HouseInfo[house_id].furniture_position[index] != new Vector3(0, 0, 0))
            {

                if (HouseInfo[house_id].furniture_handle[index].Exists)
                {
                    HouseInfo[house_id].furniture_handle[index].Delete();
                }

                if (HouseInfo[house_id].furniture_status[index] == 0)
                {
                    HouseInfo[house_id].furniture_handle[index] = NAPI.Object.CreateObject(HouseInfo[house_id].furniture_model[index], HouseInfo[house_id].furniture_position[index], new Vector3(HouseInfo[house_id].furniture_rotation[index].X, HouseInfo[house_id].furniture_rotation[index].Y, HouseInfo[house_id].furniture_rotation[index].Z), 255, 500 + (uint)house_id);
                }
            }
        }
    }


    public static void UpdateFurnitureIndex(int house_id, int index)
    {

        if (HouseInfo[house_id].furniture_position[index] != new Vector3(0, 0, 0))
        {

            if (HouseInfo[house_id].furniture_handle[index].Exists)
            {
                HouseInfo[house_id].furniture_handle[index].Delete();
            }

            if (HouseInfo[house_id].furniture_status[index] == 0)
            {
                HouseInfo[house_id].furniture_handle[index] = NAPI.Object.CreateObject(HouseInfo[house_id].furniture_model[index], HouseInfo[house_id].furniture_position[index], new Vector3(HouseInfo[house_id].furniture_rotation[index].X, HouseInfo[house_id].furniture_rotation[index].Y, HouseInfo[house_id].furniture_rotation[index].Z), 255, 500 + (uint)house_id);
            }

            NAPI.Util.ConsoleOutput("" + index + " item ; ativo " + house_id + "");
        }

    }


    public static void SaveFurniture(int house_id, int index)
    {
        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {
            try
            {
                Mainpipeline.Open();

                string query = "UPDATE `furnitures` SET `name` = @name,  `model` = @model,  `model_name` = @model_name,  `price` = @price,  `status` = @status,  `position_x` = @position_x,  `position_y` = @position_y,  `position_z` = @position_z,  `rotation_x` = @rotation_x,   `rotation_y` = @rotation_y,   `rotation_z` = @rotation_z  ";
                query = query + " WHERE `id` = '" + HouseInfo[house_id].furniture_id[index] + "'";


                MySqlCommand myCommand = new MySqlCommand(query, Mainpipeline);

                myCommand.Parameters.AddWithValue("@name", "" + HouseInfo[house_id].furniture_name[index] + "");
                myCommand.Parameters.AddWithValue("@model_name", "" + HouseInfo[house_id].furniture_model_name[index] + "");
                myCommand.Parameters.AddWithValue("@model", HouseInfo[house_id].furniture_model[index]);
                myCommand.Parameters.AddWithValue("@price", HouseInfo[house_id].furniture_price[index]);
                myCommand.Parameters.AddWithValue("@status", HouseInfo[house_id].furniture_status[index]);
                myCommand.Parameters.AddWithValue("@position_x", HouseInfo[house_id].furniture_position[index].X.ToString());
                myCommand.Parameters.AddWithValue("@position_y", HouseInfo[house_id].furniture_position[index].Y.ToString());
                myCommand.Parameters.AddWithValue("@position_z", HouseInfo[house_id].furniture_position[index].Z.ToString());
                myCommand.Parameters.AddWithValue("@rotation_x", HouseInfo[house_id].furniture_rotation[index].X.ToString());
                myCommand.Parameters.AddWithValue("@rotation_y", HouseInfo[house_id].furniture_rotation[index].Y.ToString());
                myCommand.Parameters.AddWithValue("@rotation_z", HouseInfo[house_id].furniture_rotation[index].Z.ToString());

                myCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                NAPI.Util.ConsoleOutput("[EXCEPTION SaveFurniture] " + ex.Message);
                NAPI.Util.ConsoleOutput("[EXCEPTION SaveFurniture] " + ex.StackTrace);
            }
        }

    }

    public static void UpdateHouseLabel(int index, bool first = true)
    {
        if (first)
        {
            HouseInfo[index].label.Delete();
            HouseInfo[index].label_interior.Delete();
            HouseInfo[index].marker.Delete();
            HouseInfo[index].marker_interior.Delete();
        }

        if (HouseInfo[index].owner == -1)
        {
            //HouseInfo[index].blip.Sprite = 350;
            //HouseInfo[index].blip.Color = 25;

            if (HouseInfo[index].vip == 1)
            {
                HouseInfo[index].label = NAPI.TextLabel.CreateTextLabel("- ~g~Haus zu verkaufen~w~ -~n~~y~" + HouseInfo[index].name + "~w~~n~Credits: ~b~" + HouseInfo[index].price.ToString("N0") + "", HouseInfo[index].exterior, 8.0f, 0.6f, 4, new Color(255, 255, 255, 255), false, 0);
            }
            else
            {
                HouseInfo[index].label = NAPI.TextLabel.CreateTextLabel("- ~g~Haus zu verkaufen~w~ -~n~~y~" + HouseInfo[index].name + "~w~~n~Preis: ~g~$" + HouseInfo[index].price.ToString("N0") + "", HouseInfo[index].exterior, 8.0f, 0.6f, 4, new Color(255, 255, 255, 255), false, 0);
            }
        }
        else
        {
            //HouseInfo[index].blip.Sprite = 40;
            //HouseInfo[index].blip.Color = 25;
            string lock_string = "abgeschlossen";
            if (HouseInfo[index].locked == 0)
            {
                lock_string = "~g~aufgeschlossen";
            }
            else if (HouseInfo[index].locked == 1)
            {
                lock_string = "abgeschlossen";
            }
            HouseInfo[index].label = NAPI.TextLabel.CreateTextLabel("- ~y~Haus~w~ -~n~~n~~y~" + HouseInfo[index].name + "~w~~n~~n~Besitzer ~b~" + HouseInfo[index].owner_name + "~n~" + lock_string + "", HouseInfo[index].exterior, 8.0f, 0.6f, 4, new Color(255, 255, 255, 255), false);
        }
        HouseInfo[index].label_interior = NAPI.TextLabel.CreateTextLabel("- ~c~Haus verlassen~w~ -", HouseInfo[index].interior, 8.0f, 0.6f, 0, new Color(255, 255, 255, 255), false, 500 + (uint)index);

        HouseInfo[index].marker = NAPI.Marker.CreateMarker(25, HouseInfo[index].exterior - new Vector3(0, 0, 0.8f), new Vector3(), new Vector3(), 1.5f, new Color(11, 158, 16, 150), false, 0);
        HouseInfo[index].marker_interior = NAPI.Marker.CreateMarker(25, HouseInfo[index].interior - new Vector3(0, 0, 0.8f), new Vector3(), new Vector3(), 1.5f, new Color(11, 158, 16, 150), false, 500 + (uint)index);
    }


    public static int GetPlayerInHouse(Client player)
    {
        int index = 0;
        foreach (var entrace in HouseInfo)
        {
            if (Main.IsInRangeOfPoint(player.Position, entrace.interior, 70.0f) && player.Dimension == 500 + (uint)index)
            {
                return index;
            }
            index++;
        }
        return -1;
    }

    public static bool GetPlayerHouseOwner(Client player, int house_id)
    {
        if (house_id == -1) return false;
        if (HouseInfo[house_id].owner == AccountManage.GetPlayerSQLID(player))
        {
            return true;

        }
        return false;
    }

    public static void DisplayManageHouseMenu(Client player)
    {
        int index = 0;
        foreach (var entrace in HouseInfo)
        {
            if (Main.IsInRangeOfPoint(player.Position, entrace.interior, 70.0f) && player.Dimension == 500 + (uint)index)
            {
                if (entrace.owner != AccountManage.GetPlayerSQLID(player))
                {
                    Main.SendErrorMessage(player, "Nur der Eigentümer dieses Hauses kann auf das Hausverwaltungsmenü zugreifen.");
                    return;
                }


                List<dynamic> menu_item_list = new List<dynamic>();
                menu_item_list.Add(new { Type = 5, Name = "Sperren", IsTicked = Convert.ToBoolean(entrace.locked), Description = "Wählen Sie diese Option, um das Haus zu sperren oder zu entsperren." });
                menu_item_list.Add(new { Type = 1, Name = "Safe", Description = "Geld im Haustresor abheben / sparen." });
                menu_item_list.Add(new { Type = 1, Name = "Schlüssel verwalten", Description = "Geben / Nehmen Sie Schlüssel von zu Hause an eine Person." });
                /* menu_item_list.Add(new { Type = 1, Name = "Comprar Mobilia", Description = "Comprar mobilia, cofre de itens, etc ..." });
                 menu_item_list.Add(new { Type = 1, Name = "Möbel verwalten", Description = "Editar posição, guardar ou vender uma mobilia." });
                 */

                InteractMenu.CreateMenu(player, "HOUSE_MENU", "House", "~g~Haus von ~b~" + entrace.owner_name + "", false, NAPI.Util.ToJson(menu_item_list), false);
                //
            }
            index++;
        }
    }

    public static void DisplayHouseMenu(Client player, int menu_id, string objectName = "", int selectIndex = 0)
    {
        int house_id = GetPlayerInHouse(player);

        if (house_id == -1)
        {
            Main.SendErrorMessage(player, "Ein unbekannter Fehler ist aufgetreten. (Code: " + house_id + ")");
            return;
        }

        switch (menu_id)
        {
            case 1:
                {
                    List<dynamic> menu_item_list = new List<dynamic>();
                    menu_item_list.Add(new { Type = 1, Name = "Deponieren", Description = "" });
                    menu_item_list.Add(new { Type = 1, Name = "Entnehmen", Description = "" });

                    InteractMenu.CreateMenu(player, "HOUSE_MENU_SAFE", "House", "~g~Safe von ~w~($" + HouseInfo[house_id].safe.ToString("N0") + ")", false, NAPI.Util.ToJson(menu_item_list), false);
                    break;
                }
            case 2:
                {
                    List<dynamic> menu_item_list = new List<dynamic>();
                    menu_item_list.Add(new { Type = 1, Name = "Haushaltsgeräte", Description = "" });
                    menu_item_list.Add(new { Type = 1, Name = "Installation", Description = "" });
                    menu_item_list.Add(new { Type = 1, Name = "Komfort", Description = "" });
                    menu_item_list.Add(new { Type = 1, Name = "Dekorationen.", Description = "" });
                    menu_item_list.Add(new { Type = 1, Name = "Unterhaltung", Description = "" });
                    menu_item_list.Add(new { Type = 1, Name = "Beleuchtung", Description = "" });
                    menu_item_list.Add(new { Type = 1, Name = "Lager", Description = "" });
                    menu_item_list.Add(new { Type = 1, Name = "Struktur", Description = "" });
                    menu_item_list.Add(new { Type = 1, Name = "mehrere", Description = "" });

                    InteractMenu.CreateMenu(player, "HOUSE_MENU_FURNITURE_CATEGORY", "House", "~g~Kategorie", false, NAPI.Util.ToJson(menu_item_list), false);
                    break;
                }
            case 3:
                {
                    List<dynamic> menu_item_list = new List<dynamic>();
                    int count = 0, index = 0;
                    foreach (var furniture in furniture_data)
                    {
                        if (furniture.classe == objectName)
                        {
                            menu_item_list.Add(new { Type = 1, Name = furniture.name, Description = "", RightLabel = "~g~$~s~" + furniture.price });
                            player.SetData("ListTrack_" + count, index);
                            count++;
                        }
                        index++;
                    }

                    if (count == 0)
                    {
                        DisplayHouseMenu(player, 2);
                        return;
                    }
                    InteractMenu.CreateMenu(player, "HOUSE_MENU_FURNITURE_PREVIEW", "House", "~g~" + objectName + "", false, NAPI.Util.ToJson(menu_item_list), false);


                    //furniture_data.Add(new { name = "Quadro de Planejamento", model = "p_planning_board_04", classe = "Diversos", price = 500, hash = -2117059320 });
                    break;
                }
            case 4:
                {
                    List<dynamic> menu_item_list = new List<dynamic>();
                    int count = 0;
                    for (int i = 0; i < 60; i++)
                    {
                        if (HouseInfo[house_id].furniture_position[i].X != 0 && HouseInfo[house_id].furniture_position[i].Y != 0)
                        {
                            menu_item_list.Add(new { Type = 1, Name = HouseInfo[house_id].furniture_name[i], Description = "", RightLabel = "~g~$~s~" + HouseInfo[house_id].furniture_price[i] });
                            player.SetData("ListTrack_" + count, i);
                            count++;
                        }

                    }
                    if (count == 0)
                    {
                        DisplayManageHouseMenu(player);
                        return;
                    }
                    InteractMenu.CreateMenu(player, "HOUSE_MENU_MANAGE_FURNITURE", "Haus", "~g~Möbel verwalten", false, NAPI.Util.ToJson(menu_item_list), false);

                    break;
                }
            case 5:
                {
                    int index = player.GetData("ListTrack_" + selectIndex);
                    player.SetData("select_mobilia", index);

                    List<dynamic> menu_item_list = new List<dynamic>();
                    menu_item_list.Add(new { Type = 1, Name = "Möbel aktivieren", Description = "" });
                    menu_item_list.Add(new { Type = 1, Name = "Position bearbeiten", Description = "" });
                    menu_item_list.Add(new { Type = 1, Name = "Möbel verkaufen", Description = "" });

                    InteractMenu.CreateMenu(player, "HOUSE_MENU_MANAGE_SELECT", "Haus", "~g~" + objectName + "", false, NAPI.Util.ToJson(menu_item_list), false);


                    break;
                }
            case 6:
                {
                    List<dynamic> menu_item_list = new List<dynamic>();
                    int count = 0;
                    for (int i = 0; i < 9; i++)
                    {
                        if (HouseInfo[house_id].key_acess[i] != "0")
                        {
                            menu_item_list.Add(new { Type = 1, Name = HouseInfo[house_id].key_acess[i], Description = "Wählen Sie, " + HouseInfo[house_id].key_acess[i] + " um das zu entfernen.", RightLabel = "" });
                            player.SetData("ListTrack_" + count, i);
                            count++;
                        }
                    }
                    if (count == 0)
                    {
                        DisplayManageHouseMenu(player);
                        return;
                    }
                    InteractMenu.CreateMenu(player, "HOUSE_MENU_KEYS_MANAGE", "Haus", "~g~Schlüssel verwalten", false, NAPI.Util.ToJson(menu_item_list), false);

                    break;
                }
        }
    }

    public static void SelectMenuResponse(Client player, String callbackId, int selectedIndex, String objectName, String valueList)
    {
        if (callbackId == "HOUSE_MENU")
        {
            if (selectedIndex == 1)
            {
                DisplayHouseMenu(player, 1);
            }
            else if (selectedIndex == 2)
            {
                DisplayHouseMenu(player, 6);
            }
            else if (selectedIndex == 3)
            {
                DisplayHouseMenu(player, 2);
            }
            else if (selectedIndex == 4)
            {
                DisplayHouseMenu(player, 4);
            }

        }
        else if (callbackId == "HOUSE_MENU_FURNITURE_CATEGORY")
        {
            DisplayHouseMenu(player, 3, objectName);
        }
        else if (callbackId == "HOUSE_MENU_FURNITURE_PREVIEW")
        {
            int house_id = GetPlayerInHouse(player);
            if (house_id == -1)
            {
                Main.SendErrorMessage(player, "Ein unbekannter Fehler ist aufgetreten. (Code: " + house_id + ")");
                return;
            }

            int index = player.GetData("ListTrack_" + selectedIndex);

            BuyFurniture(player, furniture_data[index].name, furniture_data[index].model, Convert.ToString(furniture_data[index].hash), furniture_data[index].price);
        }
        else if (callbackId == "HOUSE_MENU_MANAGE_FURNITURE")
        {
            DisplayHouseMenu(player, 5, objectName, selectedIndex);
        }
        else if (callbackId == "HOUSE_MENU_MANAGE_SELECT")
        {
            int house_id = GetPlayerInHouse(player);
            if (house_id == -1)
            {
                Main.SendErrorMessage(player, "Ein unbekannter Fehler ist aufgetreten. (Code: " + house_id + ")");
                return;
            }

            int i = player.GetData("select_mobilia");

            if (selectedIndex == 0)
            {
                AtivarMobilia(player, i);
            }
            else if (selectedIndex == 1)
            {
                EditarMobilia(player, i);
            }
            else if (selectedIndex == 2)
            {
                VenderMobilia(player, i);
            }
        }
        else if (callbackId == "HOUSE_MENU_KEYS_MANAGE")
        {
            int house_id = GetPlayerInHouse(player);
            if (house_id == -1)
            {
                Main.SendErrorMessage(player, "Ein unbekannter Fehler ist aufgetreten. (Code: " + house_id + ")");
                return;
            }
            int index = player.GetData("ListTrack_" + selectedIndex);
            RetirarChaveCasa(player, index, HouseInfo[house_id].key_acess[index]);
        }
        else if (callbackId == "HOUSE_MENU_SAFE")
        {
            int house_id = GetPlayerInHouse(player);
            if (house_id == -1)
            {
                Main.SendErrorMessage(player, "Ein unbekannter Fehler ist aufgetreten. (Code: " + house_id + ")");
                return;
            }
            if (selectedIndex == 0) InteractMenu.User_Input(player, "HOUSE_MENU_DEPOSIT", "Geld in den Safe legen", Main.GetPlayerMoney(player).ToString(), "Wählen Sie den Betrag", "number");
            else InteractMenu.User_Input(player, "HOUSE_MENU_WITHDRAW", "Geld aus den Safe nehmen", HouseInfo[house_id].safe.ToString(), "Wählen Sie den Betrag", "number");
        }


    }

    public static void IndexChangeMenuResponse(Client player, String callbackId, int selectedIndex, String objectName, String valueList)
    {
    }

    public static void ListItemMenuResponse(Client player, String callbackId, int selectedIndex, String objectName, String valueList, int valueIndex)
    {
    }

    public static void CheckBoxItemMenuResponse(Client player, String callbackId, int selectedIndex, String objectName, String valueList, bool _checked)
    {
        if (callbackId == "HOUSE_MENU")
        {
            if (selectedIndex == 0)
            {
                int house_id = GetPlayerInHouse(player);

                if (house_id == -1)
                {
                    Main.SendErrorMessage(player, "Ein unbekannter Fehler ist aufgetreten. (Code: " + house_id + ")");
                    return;
                }


                if (_checked)
                {
                    Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Haus abgeschlossen.", 5000);
                    HouseInfo[house_id].locked = 1;
                }
                else
                {
                    Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Haus aufgeschlossen", 5000);
                    HouseInfo[house_id].locked = 0;
                }

                UpdateHouseLabel(house_id);
            }
        }
    }


    public static void OnInputResponse(Client player, String response, String inputtext)
    {
        if (response == "HOUSE_MENU_DEPOSIT")
        {
            int house_id = GetPlayerInHouse(player);

            if (house_id == -1)
            {
                Main.SendErrorMessage(player, "Ein unbekannter Fehler ist aufgetreten. (Code: " + house_id + ")");
                return;
            }

            if (!Main.IsNumeric(inputtext))
            {
                Main.SendErrorMessage(player, "Der eingegebene Wert ist ungültig.");
                return;
            }

            int money = Convert.ToInt32(inputtext);

            if (Main.GetPlayerMoney(player) < 1)
            {
                Main.SendErrorMessage(player, "Sie können keinen negativen Betrag einzahlen.");
                return;
            }

            if (Main.GetPlayerMoney(player) < money)
            {
                Main.SendErrorMessage(player, "Du hast nicht so viel Geld.");
                return;
            }

            HouseInfo[house_id].safe += money;
            Main.GivePlayerMoney(player, -money);
            Main.SendSuccessMessage(player, "Sie haben $" + money.ToString("N0") + " hinterlegt.");

        }
        else if (response == "HOUSE_MENU_WITHDRAW")
        {
            int house_id = GetPlayerInHouse(player);

            if (house_id == -1)
            {
                Main.SendErrorMessage(player, "Ein unbekannter Fehler ist aufgetreten. (Code: " + house_id + ")");
                return;
            }

            if (!Main.IsNumeric(inputtext))
            {
                Main.SendErrorMessage(player, "Sie haben einen ungültigen Wert eingegeben.");
                return;
            }

            int money = Convert.ToInt32(inputtext);

            if (Main.GetPlayerMoney(player) < 1)
            {
                Main.SendErrorMessage(player, "Sie haben nicht so viel Geld bei sich.");
                return;
            }

            if (HouseInfo[house_id].safe < money)
            {
                Main.SendErrorMessage(player, "Du hast nicht so viel Geld.");
                return;
            }

            HouseInfo[house_id].safe -= money;
            Main.GivePlayerMoney(player, money);
            Main.SendSuccessMessage(player, "Entnommen $" + money.ToString("N0") + " vom Haus Safe.");
        }
    }

    public static void OnMenuReturnClose(Client player, String callbackId)
    {

    }

    [Command("darchaves", "/darchaves [player/name]")]
    public static void CMD_darchaves(Client player, Client target)
    {
        //Client target = Main.findPlayer(player, idOrName);

        if (target == null)
        {
            Main.SendErrorMessage(player, "Dieser Player ist nicht verbunden.");
            return;
        }

        if (!API.Shared.IsPlayerConnected(target))
        {
            Main.SendErrorMessage(player, "Dieser Player ist nicht verbunden.");
            return;
        }

        if (target.GetData("status") == false)
        {
            Main.SendErrorMessage(player, "Dieser Player ist nicht verbunden.");
            return;
        }

        if (target == player)
        {
            Main.SendErrorMessage(player, "Sie können Ihre Hausschlüssel nicht an sich selbst weitergeben.");
            return;
        }

        DarAcessoCasa(player, target.GetData("character_name"));
    }

    //
    //
    //


    [RemoteEvent("BuyFurniture")]
    public static void BuyFurniture(Client player, string name, string model, string hash, int price)
    {

        player.TriggerEvent("Hide_Browser");

        player.TriggerEvent("startBuy", model);

        Main.SendMessageWithTagToPlayer(player, "" + Main.EMBED_LIGHTGREEN + "[Mobilia]", "Sie befinden sich jetzt im Objekteditor.");
        Main.SendMessageWithTagToPlayer(player, "" + Main.EMBED_LIGHTGREEN + "[Mobilia]", "Platzieren Sie es an der gewünschten Position und drücken Sie Y, um den Kauf für $" + price + " zu bestätigen.");

        player.SetData("startEditing", true);
        player.SetData("startEditing_name", name);

    }

    [RemoteEvent("acceptEdit")]
    public static void BuyFurniture(Client player, uint modelo, float x, float y, float z, float rx, float ry, float rz)
    {
        // Main.SendMessageWithTagToPlayer(player, "" + Main.EMBED_LIGHTGREEN + "[Mobilia]", "Você está agora no modo editor de objeto.");
        // Main.SendMessageWithTagToPlayer(player, "" + Main.EMBED_LIGHTGREEN + "[Mobilia]", "Coloque-o na posição que você deseja e pressione Y para confirmar a comprar por $"+ price + ".");



        if (player.GetData("startFurnitureEditing") == true)
        {
            player.SetData("startFurnitureEditing", false);
            if (player.Dimension < 500)
            {
                Main.SendErrorMessage(player, "Du bist nicht in einem Haus.");
                return;
            }

            int i = player.GetData("startFurnitureEditing_id");

            int house_id = (int)player.Dimension - 500;

            HouseInfo[house_id].furniture_position[i] = new Vector3(x, y, z);
            HouseInfo[house_id].furniture_rotation[i] = new Vector3(rx, ry, rz);
            HouseInfo[house_id].furniture_handle[i].Position = new Vector3(x, y, z);
            HouseInfo[house_id].furniture_handle[i].Rotation = new Vector3(rx, ry, rz);

            //Main.DisplaySubtitle(player, "Posição do ~b~"+ HouseInfo[house_id].name[i] + "~w~ alterada com sucesso.");

            UpdateFurniture(house_id);
            SaveFurniture(house_id, i);

        }

        else if (player.GetData("startEditing") == true)
        {
            player.SetData("startEditing", false);
            if (player.Dimension < 500)
            {
                Main.SendErrorMessage(player, "Du bist nicht in einem Haus.");
                return;
            }

            NAPI.Util.ConsoleOutput("" + player.GetData("startEditing_hash") + " << QQTAVANEDO!!");

            int house_id = (int)player.Dimension - 500;
            for (int i = 0; i < 60; i++)
            {

                if (HouseInfo[house_id].furniture_position[i] == new Vector3(0, 0, 0))
                {
                    foreach (var furniture in furniture_data)
                    {
                        if (furniture.name == player.GetData("startEditing_name"))
                        {
                            using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
                            {
                                try
                                {

                                    string query = "INSERT INTO furnitures (`house`)" + " VALUES ('" + house_id + "')";
                                    NAPI.Util.ConsoleOutput(query);
                                    MySqlCommand myCommand = new MySqlCommand(query, Mainpipeline);

                                    myCommand.ExecuteNonQuery();
                                    HouseInfo[house_id].furniture_id[i] = (int)myCommand.LastInsertedId;

                                    Main.SendSuccessMessage(player, "Du kauftest " + Main.EMBED_BLUE + "" + furniture.name + "" + Main.EMBED_WHITE + " für " + Main.EMBED_LIGHTGREEN + "$" + furniture.price + "" + Main.EMBED_WHITE + ".");


                                    HouseInfo[house_id].furniture_name[i] = furniture.name;
                                    HouseInfo[house_id].furniture_model_name[i] = furniture.model;
                                    HouseInfo[house_id].furniture_price[i] = furniture.price;
                                    HouseInfo[house_id].furniture_model[i] = furniture.hash;
                                    HouseInfo[house_id].furniture_position[i] = new Vector3(x, y, z);
                                    HouseInfo[house_id].furniture_rotation[i] = new Vector3(rx, ry, rz);
                                    HouseInfo[house_id].furniture_handle[i] = NAPI.Object.CreateObject(furniture.hash, HouseInfo[house_id].furniture_position[i], new Vector3(HouseInfo[house_id].furniture_rotation[i].X, HouseInfo[house_id].furniture_rotation[i].Y, HouseInfo[house_id].furniture_rotation[i].Z), 255, player.Dimension);
                                    SaveFurniture(house_id, i);
                                }
                                catch (Exception ex)
                                {
                                    NAPI.Util.ConsoleOutput("[EXCEPTION AddSMSLog] " + ex.Message);
                                    NAPI.Util.ConsoleOutput("[EXCEPTION AddSMSLog] " + ex.StackTrace);
                                }
                            }
                            return;
                        }
                    }
                }
            }
            Main.SendErrorMessage(player, "Sie haben keine Möbelplätze mehr in Ihrem Haus.");
        }
    }

    [RemoteEvent("cancelEdit")]
    public static void cancelEdit(Client player)
    {
        if (player.GetData("startFurnitureEditing") == true)
        {
            UpdateFurniture(player.GetData("startFurnitureEditing_house"));
            player.SetData("startFurnitureEditing", false);
        }
        else if (player.GetData("startEditing") == true)
        {
            player.SetData("startEditing", false);
        }
    }

    [RemoteEvent("EditarMobilia")]
    public static void EditarMobilia(Client player, int id)
    {
        if (player.Dimension < 500)
        {
            Main.SendErrorMessage(player, "Du bist nicht in einem Haus.");
            return;
        }


        int house_id = (int)player.Dimension - 500;

        player.TriggerEvent("Hide_Browser");
        player.SetData("General_CEF", false);

        NAPI.Util.ConsoleOutput("1");
        player.TriggerEvent("startEditing", HouseInfo[house_id].furniture_model_name[id], HouseInfo[house_id].furniture_position[id], HouseInfo[house_id].furniture_rotation[id]);
        player.SetData("startFurnitureEditing", true);
        player.SetData("startFurnitureEditing_id", id);
        player.SetData("startFurnitureEditing_house", house_id);
        HouseInfo[house_id].furniture_handle[id].Delete();
        NAPI.Util.ConsoleOutput("2");

    }

    [RemoteEvent("AtivarMobilia")]
    public static void AtivarMobilia(Client player, int id)
    {
        if (player.Dimension < 500)
        {
            Main.SendErrorMessage(player, "Du bist nicht in einem Haus.");
            return;
        }
        int house_id = (int)player.Dimension - 500;

        if (HouseInfo[house_id].furniture_status[id] == 0) HouseInfo[house_id].furniture_status[id] = 1;
        else HouseInfo[house_id].furniture_status[id] = 0;
        UpdateFurnitureIndex(house_id, id);

    }

    [RemoteEvent("VenderMobilia")]
    public static void VenderMobilia(Client player, int id)
    {
        if (player.Dimension < 500)
        {
            Main.SendErrorMessage(player, "Du bist nicht in einem Haus.");
            return;
        }
        int house_id = (int)player.Dimension - 500;


        if (HouseInfo[house_id].furniture_price[id] > 2)
        {
            int price = HouseInfo[house_id].furniture_price[id] / 2;
            Main.SendMessageWithTagToPlayer(player, "" + Main.EMBED_LIGHTGREEN + "[Mobilia]", "Sie haben diese Möbel für $" + price.ToString("N0") + " verkauft.");
            Main.GivePlayerMoney(player, price);
        }


        Main.CreateMySqlCommand("DELETE FROM `furnitures` WHERE `id` = " + HouseInfo[house_id].furniture_id[id] + ";");

        HouseInfo[house_id].furniture_id[id] = -1;
        HouseInfo[house_id].furniture_name[id] = "";
        HouseInfo[house_id].furniture_model_name[id] = "";
        HouseInfo[house_id].furniture_model[id] = 0;
        HouseInfo[house_id].furniture_price[id] = 0;
        HouseInfo[house_id].furniture_status[id] = 0;

        HouseInfo[house_id].furniture_position[id] = new Vector3(0, 0, 0);
        HouseInfo[house_id].furniture_rotation[id] = new Vector3(0, 0, 0);
        HouseInfo[house_id].furniture_handle[id].Delete();

        UpdateFurniture(house_id);

    }


    [RemoteEvent("DepoistarDinheiroCasa")]
    public static void DepoistarDinheiroCasa(Client player, int money)
    {
        NAPI.Util.ConsoleOutput("money " + money + "");
        if (player.Dimension < 500)
        {
            Main.SendErrorMessage(player, "Du bist nicht in einem Haus.");
            return;
        }
        int house_id = (int)player.Dimension - 500;

        if (Main.GetPlayerMoney(player) < money)
        {
            Main.SendNotificationBrowser(player, "ERROR:", "Sie haben diesen Betrag nicht zur Verfügung, um ihn im Haus Safe zu deponieren.", "danger", "top", "center");
            return;
        }

        HouseInfo[house_id].safe += money;
        Main.GivePlayerMoney(player, -money);
        Main.SendSuccessMessage(player, "Erfolgreich: $" + money.ToString("N0") + "");
        //Main.SendNotificationBrowser(player, "SUCESSO:", "Você depositou $" + money.ToString("N0") + " no cofre da casa.", "success", "top", "center");

    }

    [RemoteEvent("RetirarDinheiroCasa")]
    public static void RetirarDinheiroCasa(Client player, int money)
    {
        NAPI.Util.ConsoleOutput("money " + money + "");
        if (player.Dimension < 500)
        {
            Main.SendErrorMessage(player, "Du bist nicht in einem Haus.");
            return;
        }
        int house_id = (int)player.Dimension - 500;

        if (HouseInfo[house_id].safe < money)
        {
            Main.SendNotificationBrowser(player, "ERROR:", "Sie haben diesen Geldbetrag nicht in Ihrem Safe, um ihn abzuheben.", "danger", "top", "center");
            return;
        }

        HouseInfo[house_id].safe -= money;
        Main.GivePlayerMoney(player, money);
        Main.SendSuccessMessage(player, "Erfolgreich: $" + money.ToString("N0") + "");
        //Main.SendNotificationBrowser(player, "SUCESSO:", "Você retirou $" + money.ToString("N0") + " do cofre de sua casa.", "success", "top", "center");

    }

    [RemoteEvent("DarAcessoCasa")]
    public static void DarAcessoCasa(Client player, string name)
    {
        if (player.Dimension < 500)
        {
            Main.SendErrorMessage(player, "Du bist nicht in einem Haus.");
            return;
        }
        int house_id = (int)player.Dimension - 500;

        for (int i = 0; i < 9; i++)
        {
            if (HouseInfo[house_id].key_acess[i] == name)
            {
                Main.SendNotificationBrowser(player, "ERROR:", "Dieser Player hat bereits Zugriff auf Ihr Zuhause.", "danger", "top", "right");
                return;
            }
        }

        for (int i = 0; i < 9; i++)
        {
            if (HouseInfo[house_id].key_acess[i] == "0")
            {
                HouseInfo[house_id].key_acess[i] = name;
                Main.SendSuccessMessage(player, "Sie haben eine Kopie Ihres Schlüssels an " + name + " übergeben.");

                return;
            }
        }

        Main.SendNotificationBrowser(player, "ERROR:", "Höchstgrenze erreicht! Entfernen Sie den Schlüssel eines Spielers, um einen weiteren hinzuzufügen.", "danger", "top", "right");
    }


    [RemoteEvent("RetirarChaveCasa")]
    public static void RetirarChaveCasa(Client player, int i, string name)
    {
        if (player.Dimension < 500)
        {
            Main.SendErrorMessage(player, "Du bist nicht in einem Haus.");
            return;
        }
        int house_id = (int)player.Dimension - 500;

        HouseInfo[house_id].key_acess[i] = "0";

        Main.SendNotificationBrowser(player, "SUCESSO:", "Du hast den Schlüssel von " + name + " entfernt.", "success", "top", "right");

    }


    //DarAcessoCasa

    public static void PressKeyY(Client player)
    {
        int index = 0;
        foreach (var entrace in HouseInfo)
        {
            if (Main.IsInRangeOfPoint(player.Position, entrace.exterior, 2.0f) && player.Dimension == 0)
            {
                if (entrace.locked == 1)
                {
                    Main.SendErrorMessage(player, "Dieses Haus ist verschlossen.");
                    return;
                }

                player.TriggerEvent("screenFadeOut", 500);

                NAPI.Task.Run(() =>
                {
                    player.Position = entrace.interior;
                    player.Rotation = new Vector3(0, 0, entrace.interior_a);
                    player.Dimension = 500 + (uint)index;

                    player.TriggerEvent("screenFadeIn", 1000);

                }, delayTime: 500);
                return;
            }
            else if (Main.IsInRangeOfPoint(player.Position, entrace.interior, 2.0f) && player.Dimension == 500 + (uint)index)
            {
                if (entrace.locked == 1)
                {
                    Main.SendErrorMessage(player, "Dieses Haus ist verschlossen.");
                    return;
                }
                player.TriggerEvent("screenFadeOut", 500);

                NAPI.Task.Run(() =>
                {
                    player.Position = entrace.exterior;
                    player.Rotation = new Vector3(0, 0, entrace.exterior_a);
                    player.Dimension = 0;

                    player.TriggerEvent("screenFadeIn", 1000);

                }, delayTime: 500);
                return;
            }
            index++;
        }
    }


    public static void KeyPressM(Client player)
    {
        if (player.GetData("startEditing") == true || player.GetData("startFurnitureEditing") == true)
        {
            Main.SendErrorMessage(player, "Sie können das Menü im Objekteditor nicht öffnen. Drücken Sie zum Abbrechen N oder Y und versuchen Sie es erneut.");
            return;
        }
        DisplayManageHouseMenu(player);

    }

    public static int GetPlayerHouses(Client player)
    {
        int houses = 0;
        foreach (var entrace in HouseInfo)
        {
            if (entrace.owner == AccountManage.GetPlayerSQLID(player))
            {
                houses++;
            }
        }
        return houses;
    }

    public static int GetPlayerHousesLimit(Client player)
    {
        int houses = 1;
        if (player.GetData("character_house_slots") > 0)
        {
            houses += player.GetData("character_house_slots");
        }
        return houses;
    }

    [Command("comprarcasa")]
    public void CMD_comprarcasa(Client player)
    {
        int index = 0;
        foreach (var entrace in HouseInfo)
        {
            if (Main.IsInRangeOfPoint(player.Position, entrace.exterior, 2.0f) && player.Dimension == 0)
            {
                if (entrace.owner != -1)
                {
                    Main.SendErrorMessage(player, "Dieses Haus steht nicht zum Verkauf.");
                    return;
                }

                if (GetPlayerHouses(player) > GetPlayerHousesLimit(player))
                {
                    Main.SendErrorMessage(player, "Sie können nicht mehr als " + GetPlayerHousesLimit(player) + " Häuser haben.");
                    return;
                }

                if (entrace.vip == 1)
                {
                    //if(VIP.GetPlayerVIP(player) == 0)
                    //{
                    //    Main.SendErrorMessage(player, "Você precisa de um status VIP para poder comprar esta casa.");
                    //    return;
                    //}
                    //if (VIP.GetPlayerCredits(player) < entrace.price)
                    //{
                    //    Main.SendErrorMessage(player, "Você não tem créditos pra comprar está casa.");
                    //    return;
                    //}
                    //VIP.SetPlayerCredits(player, VIP.GetPlayerCredits(player) - entrace.price);
                }
                else
                {
                    if (Main.GetPlayerMoney(player) < entrace.price)
                    {
                        Main.SendErrorMessage(player, "Sie haben nicht das Geld, um dieses Haus zu kaufen.");
                        return;
                    }

                    Main.GivePlayerMoney(player, -entrace.price);
                }



                //Main.SendMessageWithTagToPlayer(player, ""+Main.EMBED_GROVE+"Propriedade", "" + Main.EMBED_WHITE + "Você comprou uma nova propriedade, pressione " + Main.EMBED_LIGHTGREEN+"M"+Main.EMBED_WHITE+" para gerencia-la.");
                //Main.SendMessageWithTagToPlayer(player, "" + Main.EMBED_GROVE + "Propriedade", "" + Main.EMBED_WHITE + "Para mais informações use " + Main.EMBED_LIGHTRED+"/ajuda"+Main.EMBED_WHITE+" ou acesse nosso forum para ver o guia de propriedades.");




                // Entrce Name
                entrace.owner = AccountManage.GetPlayerSQLID(player);
                entrace.owner_name = NAPI.Data.GetEntityData(player, "character_name");

                UpdateHouseLabel(index);
                //

                // teleport
                player.TriggerEvent("screenFadeOut", 500);
                NAPI.Task.Run(() =>
                {
                    player.Position = entrace.interior;
                    player.Rotation = new Vector3(0, 0, entrace.interior_a);
                    player.Dimension = 500 + (uint)index;

                    player.TriggerEvent("screenFadeIn", 1000);

                }, delayTime: 500);
                SaveEntrace(index);
                return;
            }
            index++;
        }
    }

    [Command("vendercasa")]
    public void CMD_vendercasa(Client player)
    {
        int index = 0;
        foreach (var entrace in HouseInfo)
        {
            if (Main.IsInRangeOfPoint(player.Position, entrace.exterior, 2.0f) && player.Dimension == 0)
            {
                if (entrace.owner != AccountManage.GetPlayerSQLID(player))
                {
                    Main.SendErrorMessage(player, "Dieses Haus gehört nicht dir.");
                    return;
                }

                //Main.SendMessageWithTagToPlayer(player, "" + Main.EMBED_GROVE + "Eigentum", "" + Main.EMBED_WHITE + "Você vendeu está casa por $"+ entrace.price.ToString("N0") + ". "+Main.EMBED_LIGHTRED+"Todos os itens, mobilias, dinheiro no cofre, entre outros foram removidos.");

                Main.GivePlayerMoney(player, entrace.price);

                // Entrce Name
                entrace.owner = -1;
                entrace.owner_name = "";
                entrace.locked = 1;
                entrace.safe = 0;

                for (int i = 0; i < 9; i++)
                {
                    entrace.key_acess[i] = "0";
                }



                for (int id = 0; id < 60; id++)
                {
                    if (entrace.furniture_position[id].X != 0 && entrace.furniture_position[id].Y != 0)
                    {
                        Main.CreateMySqlCommand("DELETE FROM `furnitures` WHERE `id` = " + entrace.furniture_id[id] + ";");

                        entrace.furniture_id[id] = -1;
                        entrace.furniture_name[id] = "";
                        entrace.furniture_model_name[id] = "";
                        entrace.furniture_model[id] = 0;
                        entrace.furniture_price[id] = 0;
                        entrace.furniture_status[id] = 0;

                        entrace.furniture_position[id] = new Vector3(0, 0, 0);
                        entrace.furniture_rotation[id] = new Vector3(0, 0, 0);
                        entrace.furniture_handle[id].Delete();

                        UpdateFurniture(index);
                    }
                }

                UpdateHouseLabel(index);
                //
                SaveEntrace(index);

                return;
            }
            index++;
        }
    }


    [Command("campainha")]
    public void CMD_campainha(Client player)
    {
        int index = 0;
        foreach (var entrace in HouseInfo)
        {
            if (Main.IsInRangeOfPoint(player.Position, entrace.exterior, 2.0f) && player.Dimension == 0)
            {
                List<Client> proxPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(15, player);
                foreach (Client alvo in proxPlayers)
                {
                    //alvo.TriggerEvent("Send_ToChat", "", "", "<font color ='#C2A2DA'>* " + UsefullyRP.GetPlayerNameToTarget(player, alvo) + " tocou a campainha.");
                }

                foreach (Client alvo in NAPI.Pools.GetAllPlayers())
                {
                    if (alvo.GetData("status") == true && GetPlayerInHouse(alvo) == index)
                    {
                        //alvo.TriggerEvent("Send_ToChat", "", "", "<font color ='#C2A2DA'>* " + UsefullyRP.GetPlayerNameToTarget(player, alvo) + " está tocando a campainha.");
                    }
                }
                return;
            }
            index++;
        }
        Main.SendErrorMessage(player, "Sie benötigen es oben auf dem Haussymbol.");
    }


    [Command("ircasa", "/ircasa [id da casa]")]
    public void CMD_ircasa(Client player, int house_id)
    {
        if (AccountManage.GetPlayerAdmin(player) < adminCommands.COORDENADOR)
        {
            Main.SendErrorMessage(player, "Sie dürfen diesen Befehl nicht verwenden.");
            return;
        }

        if (house_id >= HOUSES_CREATED)
        {
            Main.SendErrorMessage(player, "Dieses Haus existiert nicht.");
            return;
        }
        player.Position = HouseInfo[house_id].exterior;
        player.Rotation = new Vector3(0, 0, HouseInfo[house_id].exterior_a);
        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie teleportieren sich vom Ausweis nach Hause: " + house_id + ".", 5000);
    }


    [Command("ircasainterior", "/ircasainterior [id da casa]")]
    public void CMD_ircasainterior(Client player, int house_id)
    {
        if (AccountManage.GetPlayerAdmin(player) < adminCommands.COORDENADOR)
        {
            Main.SendErrorMessage(player, "Sie dürfen diesen Befehl nicht verwenden.");
            return;
        }

        if (house_id >= HOUSES_CREATED)
        {
            Main.SendErrorMessage(player, "Dieses Haus existiert nicht.");
            return;
        }
        player.Position = HouseInfo[house_id].interior;
        player.Rotation = new Vector3(0, 0, HouseInfo[house_id].interior_a);
        //Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Você teleportar para o interior da casa de ID: ~b~" + house_id + "~w~.");
    }

    [Command("criarcasa", "/criarcasa [0 = classe baixa, 1 = classe media, 2 = casa vip] (para adicionar mais tipos olha no script no comando 'criarcasa')")]
    public void CMD_criarcasa(Client player, int type)
    {
        if (AccountManage.GetPlayerAdmin(player) < adminCommands.COORDENADOR)
        {
            Main.SendErrorMessage(player, "Sie dürfen diesen Befehl nicht verwenden.");
            return;
        }

        int index = 0;
        foreach (var entrace in HouseInfo)
        {
            if (entrace.exterior.X == 0 && entrace.exterior.Y == 0 && entrace.interior.X == 0 && entrace.interior.Y == 0)
            {
                Random rnd = new Random();
                if (type == 0)
                {
                    entrace.exterior = player.Position;
                    entrace.exterior_a = player.Rotation.Z;
                    entrace.interior = new Vector3(151.5398, -1006.991, -98.99998);
                    entrace.interior_a = 158.3622f;

                    HouseInfo[index].Shape.Position = player.Position;



                    entrace.name = "Apartment";
                    int random_price = rnd.Next(7500, 17000);
                    entrace.price = random_price;
                    UpdateHouseLabel(index);
                    SaveEntrace(index);

                    HouseInfo[index].blip.Position = entrace.exterior;
                    HouseInfo[index].blip.Transparency = 255;
                }
                else if (type == 1)
                {
                    entrace.exterior = player.Position;
                    entrace.exterior_a = player.Rotation.Z;
                    entrace.interior = new Vector3(346.5961, -1002.541, -99.19624);
                    entrace.interior_a = 357.6783f;
                    HouseInfo[index].Shape.Position = player.Position;



                    int random_price = rnd.Next(120000, 1500000);
                    entrace.price = random_price;

                    entrace.name = "Luxus Haus";
                    UpdateHouseLabel(index);
                    SaveEntrace(index);

                    HouseInfo[index].blip.Position = entrace.exterior;
                    HouseInfo[index].blip.Transparency = 255;
                }
                else if (type == 2)
                {
                    entrace.exterior = player.Position;
                    entrace.exterior_a = player.Rotation.Z;
                    entrace.interior = new Vector3(-682.2648, 592.4819, 145.3918);
                    entrace.interior_a = 218.7982f;

                    HouseInfo[index].Shape.Position = player.Position;


                    entrace.price = 1000000;
                    //entrace.vip = 1;

                    entrace.name = "Villa";
                    UpdateHouseLabel(index);
                    SaveEntrace(index);

                    HouseInfo[index].blip.Position = entrace.exterior;
                    HouseInfo[index].blip.Transparency = 255;
                }

                else if (type == 3)
                {
                    //Dell Perro Heights, Apt 4    new Vector3(-1468.14, -541.815, 73.4442); 2500 credits
                    entrace.exterior = player.Position;
                    entrace.exterior_a = player.Rotation.Z;
                    entrace.interior = new Vector3(-774.2465, 342.0875, 196.6864);
                    entrace.interior_a = 90.05319f;
                    HouseInfo[index].Shape.Position = player.Position;



                    entrace.price = 2500000;

                    entrace.name = "Pure End Villa";
                    UpdateHouseLabel(index);
                    SaveEntrace(index);

                    HouseInfo[index].blip.Position = entrace.exterior;
                    HouseInfo[index].blip.Transparency = 255;
                }
                else if (type == 4)
                {
                    //Dell Perro Heights, Apt 4    new Vector3(-1468.14, -541.815, 73.4442); 2500 credits
                    entrace.exterior = player.Position;
                    entrace.exterior_a = player.Rotation.Z;
                    entrace.interior = new Vector3(-774.2465, 342.0875, 196.6864);
                    entrace.interior_a = 90.05319f;

                    HouseInfo[index].Shape.Position = player.Position;

                    entrace.price = 15000000;

                    entrace.name = "High End Villa";
                    UpdateHouseLabel(index);
                    SaveEntrace(index);

                    HouseInfo[index].blip.Position = entrace.exterior;
                    HouseInfo[index].blip.Transparency = 255;
                }
                else if (type == 5)
                {
                    //Dell Perro Heights, Apt 4    new Vector3(-1468.14, -541.815, 73.4442); 2500 credits
                    entrace.exterior = player.Position;
                    entrace.exterior_a = player.Rotation.Z;
                    entrace.interior = new Vector3(976.636, 70.295, 115.164);
                    entrace.interior_a = 90.05319f;
                    HouseInfo[index].Shape.Position = player.Position;

                    int random_price = rnd.Next(3500000, 6500000);
                    entrace.price = random_price;
                    //entrace.price = 15000000;

                    entrace.name = "Pent Villa﻿﻿﻿";
                    UpdateHouseLabel(index);
                    SaveEntrace(index);

                    HouseInfo[index].blip.Position = entrace.exterior;
                    HouseInfo[index].blip.Transparency = 255;
                }
                else Main.SendErrorMessage(player, "Ungültiger Haustyp!");

                return;

            }
            index++;
        }
    }

    [Command("editarcasa", "/editarcasa [id of house] [type(name, exterior, interior, delete)]")]
    public void CMD_editarcasa(Client player, int entrace_id, string type)
    {
        if (AccountManage.GetPlayerAdmin(player) < adminCommands.COORDENADOR)
        {
            Main.SendErrorMessage(player, "Sie dürfen diesen Befehl nicht verwenden.");
            return;
        }

        if (entrace_id < 1 && entrace_id > MAX_ENTRACE)
        {
            Main.SendErrorMessage(player, "O id não pode ser inferior que 1 ou maior que " + MAX_ENTRACE + ".");
            return;
        }

        if (type == "name")
        {
            InteractMenu.User_Input(player, "input_entrace_name", "Editar Nome da Casa", HouseInfo[entrace_id].name);
            player.SetData("entrace_id", entrace_id);
        }
        else if (type == "exterior")
        {

            player.SendChatMessage("Você editou a posição do exterior da casa de id " + entrace_id + " para sua posição atual.");
            HouseInfo[entrace_id].exterior = player.Position;
            HouseInfo[entrace_id].exterior_a = player.Rotation.Z;
            HouseInfo[entrace_id].label.Position = player.Position;
            HouseInfo[entrace_id].marker.Position = player.Position - new Vector3(0, 0, 0.8f);
            HouseInfo[entrace_id].Shape.Position = player.Position;
            UpdateHouseLabel(entrace_id);

            HouseInfo[entrace_id].blip.Position = HouseInfo[entrace_id].exterior;

            NAPI.Blip.SetBlipTransparency(HouseInfo[entrace_id].blip, 255);
            SaveEntrace(entrace_id);
        }
        else if (type == "interior")
        {
            player.SendChatMessage("Você editou a posição do interior da casa de id " + entrace_id + " para sua posição atual.");

            HouseInfo[entrace_id].interior = player.Position;
            HouseInfo[entrace_id].interior_a = player.Rotation.Z;
            HouseInfo[entrace_id].label_interior.Position = player.Position;
            HouseInfo[entrace_id].marker_interior.Position = player.Position - new Vector3(0, 0, 0.8f);

            UpdateHouseLabel(entrace_id);
            SaveEntrace(entrace_id);
        }
        else if (type == "delete")
        {
            player.SendChatMessage("Você deletou a casa de id " + entrace_id + ".");

            HouseInfo[entrace_id].blip.Transparency = 0;

            HouseInfo[entrace_id].name = "";
            HouseInfo[entrace_id].exterior = new Vector3(0, 0, 0);
            HouseInfo[entrace_id].interior = new Vector3(0, 0, 0);
            HouseInfo[entrace_id].exterior_a = 0;
            HouseInfo[entrace_id].interior_a = 0;
            HouseInfo[entrace_id].label.Position = new Vector3(0, 0, 0);
            HouseInfo[entrace_id].label_interior.Position = new Vector3(0, 0, 0);
            HouseInfo[entrace_id].marker.Position = new Vector3(0, 0, 0);
            HouseInfo[entrace_id].marker_interior.Position = new Vector3(0, 0, 0);
            SaveEntrace(entrace_id);
        }
    }

    //
    // Inventory
    //
    public static void LoadInventoryItens(int house_id)
    {
        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {
            Mainpipeline.Open();
            MySqlCommand query = new MySqlCommand("SELECT * FROM `inventory_house` WHERE `owner` = '" + HouseInfo[house_id].id + "';", Mainpipeline);

            using (MySqlDataReader reader = query.ExecuteReader())
            {
                string data2txt = string.Empty;
                string datatxt = string.Empty;

                while (reader.Read())
                {
                    if (reader.GetInt32("amount") == 0)
                    {
                        Main.CreateMySqlCommand("DELETE FROM `inventory_house` WHERE `id` = '" + reader.GetInt32("id") + "';");
                        continue;
                    }

                    SendItemFromSQLtoInventory(house_id, reader.GetInt32("id"), reader.GetInt32("type"), reader.GetInt32("amount"));
                }
            }
        }
    }

    public static void SendItemFromSQLtoInventory(int house_id, int sql_id, int type, int amount = 1)
    {
        for (int index = 0; index < MAX_INVENTORY_ITENS; index++)
        {
            if (HouseInfo[house_id].inventory_type[index] == type)
            {
                HouseInfo[house_id].inventory_amount[index] = amount;
                return;
            }
        }

        for (int index = 0; index < MAX_INVENTORY_ITENS; index++)
        {
            if (HouseInfo[house_id].inventory_index[index] == -1)
            {
                HouseInfo[house_id].inventory_index[index] = sql_id;
                HouseInfo[house_id].inventory_type[index] = type;
                HouseInfo[house_id].inventory_amount[index] = amount;
                return;
            }
        }
    }

    public static void GiveItemToInventory(int house_id, int type, int amount = 1)
    {
        for (int index = 0; index < MAX_INVENTORY_ITENS; index++)
        {
            if (HouseInfo[house_id].inventory_type[index] == type)
            {
                HouseInfo[house_id].inventory_amount[index] += amount;
                Main.CreateMySqlCommand("UPDATE inventory_house SET `amount` = " + HouseInfo[house_id].inventory_amount[index] + " WHERE `id` = " + HouseInfo[house_id].inventory_index[index] + "");
                return;
            }
        }

        for (int index = 0; index < MAX_INVENTORY_ITENS; index++)
        {
            if (HouseInfo[house_id].inventory_index[index] == -1)
            {
                using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
                {
                    try
                    {
                        Mainpipeline.Open();
                        string query = "INSERT INTO inventory_house (`owner`, `type`, `amount`)" + " VALUES ('" + house_id + "', '" + type + "', '" + amount + "')";
                        MySqlCommand myCommand = new MySqlCommand(query, Mainpipeline);
                        myCommand.ExecuteNonQuery();
                        long last_inventory_id = myCommand.LastInsertedId;

                        HouseInfo[house_id].inventory_index[index] = Convert.ToInt32(last_inventory_id);
                        HouseInfo[house_id].inventory_type[index] = type;
                        HouseInfo[house_id].inventory_amount[index] = amount;
                    }
                    catch (Exception ex)
                    {
                        NAPI.Util.ConsoleOutput("[EXCEPTION GiveItemToInventory] " + ex.Message);
                        NAPI.Util.ConsoleOutput("[EXCEPTION GiveItemToInventory] " + ex.StackTrace);
                    }
                }
                return;
            }
        }
    }

    public static void RemoveItemFromInventory(int house_id, int index, int amount = 0)
    {
        if (HouseInfo[house_id].inventory_amount[index] >= 2)
        {
            HouseInfo[house_id].inventory_amount[index] -= amount;
            Main.CreateMySqlCommand("UPDATE inventory_house SET `amount` = " + HouseInfo[house_id].inventory_amount[index] + " WHERE `id` = " + HouseInfo[house_id].inventory_index[index] + "");

            if (HouseInfo[house_id].inventory_amount[index] < 1)
            {
                Main.CreateMySqlCommand("DELETE FROM `inventory_house` WHERE `id` = '" + HouseInfo[house_id].inventory_index[index] + "';");


                HouseInfo[house_id].inventory_index[index] = -1;
                HouseInfo[house_id].inventory_type[index] = 0;
                HouseInfo[house_id].inventory_amount[index] = 0;
            }
        }
        else
        {
            Main.CreateMySqlCommand("DELETE FROM `inventory_house` WHERE `id` = '" + HouseInfo[house_id].inventory_index[index] + "';");

            HouseInfo[house_id].inventory_index[index] = -1;
            HouseInfo[house_id].inventory_type[index] = 0;
            HouseInfo[house_id].inventory_amount[index] = 0;
        }
    }

    public static void ClearInventory(int house_id)
    {
        for (int i = 0; i < MAX_INVENTORY_ITENS; i++)
        {
            HouseInfo[house_id].inventory_index[i] = -1;
            HouseInfo[house_id].inventory_type[i] = 0;
            HouseInfo[house_id].inventory_amount[i] = 0;
        }

        Main.CreateMySqlCommand("DELETE FROM `inventory_house` WHERE `owner` = '" + house_id + "';");
    }

    public static void ResetInventoryVariables(int house_id)
    {
        for (int i = 0; i < MAX_INVENTORY_ITENS; i++)
        {
            HouseInfo[house_id].inventory_index[i] = -1;
            HouseInfo[house_id].inventory_type[i] = 0;
            HouseInfo[house_id].inventory_amount[i] = 0;
        }
    }

    public static int GetInventoryIndexFromType(int house_id, int type)
    {
        int slot = -1;
        for (int index = 0; index < MAX_INVENTORY_ITENS; index++)
        {
            if (HouseInfo[house_id].inventory_type[index] == type)
            {
                slot = index;
            }
        }
        return slot;
    }

    public static int GetPlayerItemFromInventory(int house_id, int type)
    {
        int amount = 0;
        for (int index = 0; index < MAX_INVENTORY_ITENS; index++)
        {
            if (HouseInfo[house_id].inventory_type[index] == type)
            {
                amount = HouseInfo[house_id].inventory_amount[index];
            }
        }
        return amount;
    }


    public static int GetInventoryIndexFromName(int house_id, string name)
    {

        int index = 0, slot = -1;
        foreach (var item in Inventory.itens_available)
        {
            if (item.name == name)
            {
                slot = GetInventoryIndexFromType(house_id, index);
            }
            index++;
        }
        return slot;
    }

    public static void RemoveItem(int house_id, string itemName, int amount)
    {
        int index = 0;
        foreach (var item in Inventory.itens_available)
        {
            if (item.name == itemName)
            {
                RemoveItemFromInventory(house_id, GetInventoryIndexFromType(house_id, index), amount);
                return;
            }
            index++;
        }
    }

    [Command("arrombarporta")]
    public void CMD_arrombarporta(Client player)
    {
        if (AccountManage.GetPlayerGroup(player) == 1)
        {

            int index = 0;
            foreach (var entrace in HouseInfo)
            {
                if (Main.IsInRangeOfPoint(player.Position, entrace.exterior, 2.0f) && player.Dimension == 0)
                {
                    //UsefullyRP.SendRoleplayAction(player, "er brach die Tür des Hauses ein.");
                    entrace.locked = 0;
                    return;
                }
                index++;
            }
        }
    }

    [Command("cofre")]
    public static void ShowHouseInventory(Client player)
    {
        int house_index = 0;
        foreach (var isafe in house_cofre)
        {
            if (Main.IsInRangeOfPoint(player.Position, isafe, 2.0f))
            {
                foreach (var entrace in HouseInfo)
                {
                    if (Main.IsInRangeOfPoint(player.Position, entrace.interior, 70.0f) && player.Dimension == 500 + (uint)house_index)
                    {



                        int playerid = Main.getIdFromClient(player);

                        float weight = 0f;
                        float vehicle_weight = 0f;

                        List<dynamic> temp_inventory = new List<dynamic>();
                        for (int index = 0; index < Inventory.MAX_INVENTORY_ITENS; index++)
                        {
                            if (Inventory.player_inventory[playerid].sql_id[index] != -1)
                            {

                                int type = Inventory.player_inventory[playerid].type[index];

                                if (type > Inventory.itens_available.Count)
                                {
                                    continue;
                                }

                                string new_category = "NONE";


                                temp_inventory.Add(new { name = Inventory.itens_available[type].name, type = type, description = Inventory.itens_available[type].description, amount = Inventory.player_inventory[playerid].amount[index], weight = Inventory.itens_available[type].weight, use_0 = "Usar Item", use_1 = "null", dontDisplayAmount = false, category = new_category });
                                weight += Inventory.player_inventory[playerid].amount[index] * Inventory.itens_available[type].weight;
                            }
                        }

                        //
                        List<dynamic> temp_storage_inventory = new List<dynamic>();
                        for (int index = 0; index < Inventory.MAX_INVENTORY_ITENS; index++)
                        {
                            if (HouseInfo[house_index].inventory_index[index] != -1)
                            {

                                int type = HouseInfo[house_index].inventory_type[index];

                                if (type > Inventory.itens_available.Count)
                                {
                                    continue;
                                }

                                string new_category = "NONE";


                                temp_storage_inventory.Add(new
                                {
                                    name = Inventory.itens_available[type].name,
                                    type = type,
                                    description = Inventory.itens_available[type].description,
                                    amount = HouseInfo[house_index].inventory_amount[index],
                                    weight = Inventory.itens_available[type].weight,
                                    use_0 = "Usar Item",
                                    use_1 = "null",
                                    dontDisplayAmount = false,
                                    category = new_category
                                });

                                vehicle_weight += HouseInfo[house_index].inventory_amount[index] * Inventory.itens_available[type].weight;
                            }
                        }


                        player.TriggerEvent("Display_House_Storage", NAPI.Util.ToJson(temp_inventory), NAPI.Util.ToJson(temp_storage_inventory), weight, Inventory.GetInventoryMaxHeight(player), vehicle_weight, 20);


                    }
                    house_index++;
                }
                return;

            }

        }
    }

    [RemoteEvent("House_Storage_Give_Item")]
    public static void UI_GiveItem(Client player, int type, string inputtext)
    {

        int house_index = 0, house_id = -1;
        foreach (var entrace in HouseInfo)
        {
            if (Main.IsInRangeOfPoint(player.Position, entrace.interior, 70.0f) && player.Dimension == 500 + (uint)house_index)
            {
                if (entrace.owner == AccountManage.GetPlayerSQLID(player))
                {
                    house_id = house_index;
                }
            }
            house_index++;
        }

        if (house_id == -1)
        {
            ShowHouseInventory(player);

            return;
        }

        int playerid = Main.getIdFromClient(player);
        int index = Inventory.GetInventoryIndexFromType(player, type);

        if (Inventory.player_inventory[playerid].sql_id[index] == -1)
        {
            Main.SendErrorMessage(player, "Ein unbekannter Fehler ist aufgetreten. (" + Inventory.player_inventory[playerid].sql_id[index] + " - " + index + " - " + Inventory.player_inventory[playerid].type[index] + ")");
            ShowHouseInventory(player);

            return;
        }



        if (Inventory.player_inventory[playerid].amount[index] > 1)
        {
            if (!Main.IsNumeric(inputtext))
            {
                ShowHouseInventory(player);

                return;
            }
            if (Inventory.player_inventory[playerid].sql_id[index] == -1)
            {
                ShowHouseInventory(player);

                return;
            }

            int amount = Convert.ToInt32(inputtext);


            if (Inventory.player_inventory[playerid].amount[index] < 1)
            {
                ShowHouseInventory(player);

                return;
            }

            if (Inventory.player_inventory[playerid].amount[index] < amount)
            {
                Main.SendErrorMessage(player, "Sie haben diesen Betrag nicht in Ihrem Inventar.");
                ShowHouseInventory(player);

                return;
            }

            /*if (VehicleInventory.Check_VehicleInventoryWeight_With_ItemAmount(player, vehicle, type, amount, vehicle.GetData("MAX_VEHICLE_SLOT")))
            {
                return;
            }*/

            Inventory.RemoveItemFromInventory(player, index, amount);
            GiveItemToInventory(house_id, type, amount);

            ShowHouseInventory(player);

            List<Client> proxPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(15, player);
            foreach (Client alvo in proxPlayers)
            {
                // alvo.TriggerEvent("Send_ToChat", "", "", "<font color ='#C2A2DA'>* " + UsefullyRP.GetPlayerNameToTarget(player, alvo) + " colocou " + amount + "x " + Inventory.itens_available[type].name + " no inventário da casa.");
            }

        }
        else if (Inventory.player_inventory[playerid].amount[index] == 1)
        {
            /*if (VehicleInventory.Check_VehicleInventoryWeight_With_ItemAmount(player, vehicle, type, 1, vehicle.GetData("MAX_VEHICLE_SLOT")))
            {
                return;
            }*/

            Inventory.RemoveItemFromInventory(player, index, 1);
            GiveItemToInventory(house_id, type, 1);

            ShowHouseInventory(player);

            List<Client> proxPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(15, player);
            foreach (Client alvo in proxPlayers)
            {
                // alvo.TriggerEvent("Send_ToChat", "", "", "<font color ='#C2A2DA'>* " + UsefullyRP.GetPlayerNameToTarget(player, alvo) + " colocou 1x " + Inventory.itens_available[type].name + " no inventário da casa.");
            }
            return;
        }

    }

    [RemoteEvent("House_Storage_Take_Item")]
    public static void UI_TakeItem(Client player, int type, string inputtext)
    {
        int house_index = 0, house_id = -1;
        foreach (var entrace in HouseInfo)
        {
            if (Main.IsInRangeOfPoint(player.Position, entrace.interior, 70.0f) && player.Dimension == 500 + (uint)house_index)
            {
                if (entrace.owner == AccountManage.GetPlayerSQLID(player))
                {
                    house_id = house_index;
                }
            }
            house_index++;
        }

        if (house_id == -1)
        {
            ShowHouseInventory(player);

            return;
        }

        int playerid = Main.getIdFromClient(player);
        int index = GetInventoryIndexFromType(house_id, type);

        if (HouseInfo[house_id].inventory_amount[index] > 1)
        {
            if (!Main.IsNumeric(inputtext))
            {
                ShowHouseInventory(player);

                return;
            }

            int amount = Convert.ToInt32(inputtext);

            if (HouseInfo[house_id].inventory_amount[index] < 1)
            {
                ShowHouseInventory(player);

                return;
            }

            if (HouseInfo[house_id].inventory_amount[index] < amount)
            {
                Main.SendErrorMessage(player, "Sie haben diesen Betrag nicht in Ihrem Inventar.");
                ShowHouseInventory(player);

                return;
            }

            if (Inventory.Check_InventoryWeight_With_ItemAmount(player, type, amount, Inventory.Max_Inventory_Weight(player)))
            {
                ShowHouseInventory(player);

                return;
            }


            Inventory.GiveItemToInventory(player, type, amount);
            RemoveItemFromInventory(house_id, index, amount);

            ShowHouseInventory(player);

            List<Client> proxPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(15, player);
            foreach (Client alvo in proxPlayers)
            {
                //alvo.TriggerEvent("Send_ToChat", "", "", "<font color ='#C2A2DA'>* " + UsefullyRP.GetPlayerNameToTarget(player, alvo) + " retirou " + amount + "x " + Inventory.itens_available[type].name + " do inventário da casa.");
            }

        }
        else if (HouseInfo[house_id].inventory_amount[index] == 1)
        {
            if (Inventory.Check_InventoryWeight_With_ItemAmount(player, type, 1, Inventory.Max_Inventory_Weight(player)))
            {
                ShowHouseInventory(player);

                return;
            }

            Inventory.GiveItemToInventory(player, type, 1);
            RemoveItemFromInventory(house_id, index, 1);

            ShowHouseInventory(player);

            List<Client> proxPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(15, player);
            foreach (Client alvo in proxPlayers)
            {
                //alvo.TriggerEvent("Send_ToChat", "", "", "<font color ='#C2A2DA'>* " + UsefullyRP.GetPlayerNameToTarget(player, alvo) + " retirou 1x " + Inventory.itens_available[type].name + " do inventário da casa.");
            }
            return;
        }

    }


    [Command("avendercasa", "/avendercasa [id da empresa]")]
    public void CMD_avendercasa(Client player, int index)
    {
        if (AccountManage.GetPlayerAdmin(player) < adminCommands.COORDENADOR)
        {
            Main.SendErrorMessage(player, "Sie haben keine Berechtigung, diesen Befehl zu verwenden.");
            return;
        }

        if (index > HouseInfo.Count)
        {
            Main.SendErrorMessage(player, "Falsche ID des angegebenen Hauses.");
            return;
        }
        HouseInfo[index].owner = -1;
        UpdateHouseLabel(index);
        SaveEntrace(index);

        Main.SendMessageToPlayer(player, $"Sie haben mit erfolgreich das Haus {index} verkauft.");
    }
}