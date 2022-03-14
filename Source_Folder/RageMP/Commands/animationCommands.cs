using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTANetworkAPI;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

class animationCommands : Script
{

    public static List<dynamic> animAllgemein1 = new List<dynamic>();
    public static List<dynamic> animHandbewegungen1 = new List<dynamic>();
    public static List<dynamic> animSport1 = new List<dynamic>();
    public static List<dynamic> animTanz1 = new List<dynamic>();
    public static List<dynamic> animStehen1 = new List<dynamic>();
    public static List<dynamic> animSitzenBeugen1 = new List<dynamic>();
    public static List<dynamic> animLiegen1 = new List<dynamic>();
    public static List<dynamic> animWeiblich1 = new List<dynamic>();
    public static List<dynamic> animAnlehnen1 = new List<dynamic>();
    public static List<dynamic> animLaufstile1 = new List<dynamic>();
    public static List<dynamic> animPolice1 = new List<dynamic>();

    public animationCommands()
    {
        animAllgemein1.Add(new { hash = "etwas auf dem Boden suchen", descriptionHash = "animDescrcmrc_omega_2omega_idle_looking_around", dict = "rcmrc_omega_2", state = "omega_idle_looking_around", flag = 49, repeat = true, sex = "both" });
        animAllgemein1.Add(new { hash = "Magenschmerzen", descriptionHash = "animDescrcmpaparazzo1idle", dict = "rcmpaparazzo1", state = "idle", flag = 49, repeat = true, sex = "both" });
        animAllgemein1.Add(new { hash = "Hinsetzen", descriptionHash = "animmissexile1_cargoplaneleadinoutexile_1_int", dict = "missexile1_cargoplaneleadinoutexile_1_int", state = "_leadout_michael", flag = 49, repeat = true, sex = "both" });
        animAllgemein1.Add(new { hash = "Jubeln", descriptionHash = "animDescamb@world_human_cheering@male_bbase", dict = "amb@world_human_cheering@male_b", state = "base", flag = 33, repeat = true, sex = "both" });
        animAllgemein1.Add(new { hash = "nach rechts und links schauen", descriptionHash = "animDescamb@code_human_cross_road@male@basebase", dict = "amb@code_human_cross_road@male@base", state = "base", flag = 33, repeat = true, sex = "both" });
        animAllgemein1.Add(new { hash = "Küsschen verteilen", descriptionHash = "animDescanim@mp_player_intcelebrationfemale@blow_kissblow_kiss", dict = "anim@mp_player_intcelebrationfemale@blow_kiss", state = "blow_kiss", flag = 33, repeat = true, sex = "both" });
        animAllgemein1.Add(new { hash = "Fassungslos", descriptionHash = "animDescoddjobs@towingpleadingidle_bidle_d", dict = "oddjobs@towingpleadingidle_b", state = "idle_d", flag = 49, repeat = true, sex = "both" });
        animAllgemein1.Add(new { hash = "Ausrasten", descriptionHash = "animDescrandom@street_race_streetracer_accepted", dict = "random@street_race", state = "_streetracer_accepted", flag = 33, repeat = true, sex = "both" });
        animAllgemein1.Add(new { hash = "Auto polieren", descriptionHash = "animDescmisscarsteal2fixerconfused_a", dict = "misscarsteal2fixer", state = "confused_a", flag = 33, repeat = true, sex = "both" });
        animAllgemein1.Add(new { hash = "abstüzen vom Tisch", descriptionHash = "animDescabigail_mcs_1_concat-5player_zero_dual-5", dict = "abigail_mcs_1_concat-5", state = "player_zero_dual-5", flag = 33, repeat = true, sex = "both" });
        animAllgemein1.Add(new { hash = "Flirten", descriptionHash = "animDescmini@hookers_spidle_a", dict = "mini@hookers_sp", state = "idle_a", flag = 49, repeat = true, sex = "both" });
        animAllgemein1.Add(new { hash = "Umarmung", descriptionHash = "animDescmp_ped_interactionkisses_guy_a", dict = "mp_ped_interaction", state = "kisses_guy_a", flag = 33, repeat = true, sex = "both" });
        animAllgemein1.Add(new { hash = "Strafzettel", descriptionHash = "animDescamb@prop_human_parking_meter@male@basebase", dict = "amb@prop_human_parking_meter@male@base", state = "base", flag = 49, repeat = true, sex = "both" });
        animAllgemein1.Add(new { hash = "Selfi machen", descriptionHash = "animDescamb@world_human_tourist_mobile@male@basebase", dict = "amb@world_human_tourist_mobile@male@base", state = "base", flag = 49, repeat = true, sex = "both" });
        animAllgemein1.Add(new { hash = "am Kopf kratzen", descriptionHash = "animDescmisstrevor1ig_3action_b", dict = "misstrevor1ig_3", state = "action_b", flag = 49, repeat = true, sex = "both" });
        animAllgemein1.Add(new { hash = "Heli zu sich winken", descriptionHash = "animDescmissfbi2extradirect_heli_loop_dave", dict = "missfbi2extra", state = "direct_heli_loop_dave", flag = 49, repeat = true, sex = "both" });
        animAllgemein1.Add(new { hash = "High Five", descriptionHash = "animDescmp_ped_interactionhighfive_guy_a", dict = "mp_ped_interaction", state = "highfive_guy_a", flag = 49, repeat = true, sex = "both" });
        animAllgemein1.Add(new { hash = "Reparatur unterm Auto", descriptionHash = "animDescamb@world_human_vehicle_mechanic@male@basebase", dict = "amb@world_human_vehicle_mechanic@male@base", state = "base", flag = 33, repeat = true, sex = "both" });
        animAllgemein1.Add(new { hash = "bis hier und nicht weiter", descriptionHash = "animDescmini@prostitutestalkstreet_argue_f_a", dict = "mini@prostitutestalk", state = "street_argue_f_a", flag = 49, repeat = true, sex = "both" });
        animAllgemein1.Add(new { hash = "Zigarette rauchen", descriptionHash = "animDescamb@world_human_smoking@male@male_a@basebase", dict = "amb@world_human_smoking@male@male_a@base", state = "base", flag = 49, repeat = true, sex = "both" });
        animAllgemein1.Add(new { hash = "Luftgitarre", descriptionHash = "animDescmisslester1aig_4mainair_guitar_02_a", dict = "misslester1aig_4main", state = "air_guitar_02_a", flag = 49, repeat = true, sex = "both" });
        animAllgemein1.Add(new { hash = "Die Welt bricht zusammen", descriptionHash = "animDescmisscarsteal2car_stolenchad_car_stolen_reaction", dict = "misscarsteal2car_stolen", state = "chad_car_stolen_reaction", flag = 33, repeat = true, sex = "both" });
        animAllgemein1.Add(new { hash = "sich nach Links umschauen", descriptionHash = "animDescmissarmenian2lamar_idlesidle_look_behind_left", dict = "missarmenian2lamar_idles", state = "idle_look_behind_left", flag = 49, repeat = true, sex = "both" });
        animAllgemein1.Add(new { hash = "sich nach rechts umschauen", descriptionHash = "animDescmissarmenian2lamar_idlesidle_look_behind_right", dict = "missarmenian2lamar_idles", state = "idle_look_behind_right", flag = 49, repeat = true, sex = "both" });
        animAllgemein1.Add(new { hash = "in die Luft schauen", descriptionHash = "animDescmissarmenian2lamar_idlesidle_c", dict = "missarmenian2lamar_idles", state = "idle_c", flag = 49, repeat = true, sex = "both" });
        animAllgemein1.Add(new { hash = "Warten und umschauen", descriptionHash = "animDescmissarmenian2arm2_lamar_idle_01", dict = "missarmenian2", state = "arm2_lamar_idle_01", flag = 49, repeat = true, sex = "both" });
        animAllgemein1.Add(new { hash = "Aus Handy schauen", descriptionHash = "animDescfriends@laf@ig_1@basebase", dict = "friends@laf@ig_1@base", state = "base", flag = 49, repeat = true, sex = "both" });
        animAllgemein1.Add(new { hash = "Taxi rufen", descriptionHash = "animDesctaxi_hailhail_taxi", dict = "taxi_hail", state = "hail_taxi", flag = 49, repeat = true, sex = "both" });
        animAllgemein1.Add(new { hash = "Die Füße küssen", descriptionHash = "animDescmissfam4leadinoutmcs2tracy_loop", dict = "missfam4leadinoutmcs2", state = "tracy_loop", flag = 33, repeat = true, sex = "both" });
        animAllgemein1.Add(new { hash = "Auf die Uhr schauen", descriptionHash = "animDescfriends@pickupwait", dict = "friends@", state = "pickupwait", flag = 49, repeat = true, sex = "both" });
        animAllgemein1.Add(new { hash = "Bro Umarmung", descriptionHash = "animDescmp_ped_interactionhugs_guy_a", dict = "mp_ped_interaction", state = "hugs_guy_a", flag = 33, repeat = true, sex = "both" });
        animAllgemein1.Add(new { hash = "Pissen männlich", descriptionHash = "animDescmissbigscore1switch_trevor_pisspiss_loop", dict = "missbigscore1switch_trevor_piss", state = "piss_loop", flag = 33, repeat = true, sex = "both" });
        animAllgemein1.Add(new { hash = "Elektroschlag", descriptionHash = "animDescstungun@standingdamage", dict = "stungun@standing", state = "damage", flag = 49, repeat = true, sex = "both" });
        animAllgemein1.Add(new { hash = "sich freuen", descriptionHash = "animDescmissfbi3_snipingmale_unarmed_a", dict = "missfbi3_sniping", state = "male_unarmed_a", flag = 33, repeat = true, sex = "both" });
        animAllgemein1.Add(new { hash = "Balancieren", descriptionHash = "animDescmisslamar1leadinoutmagenta_idle", dict = "misslamar1leadinout", state = "magenta_idle", flag = 49, repeat = true, sex = "both" });
        animAllgemein1.Add(new { hash = "Facepalm linker arm", descriptionHash = "animDescanim@mp_player_intcelebrationfemale@face_palmface_palm", dict = "anim@mp_player_intcelebrationfemale@face_palm", state = "face_palm", flag = 49, repeat = true, sex = "both" });
        animAllgemein1.Add(new { hash = "Facepalm rechter arm", descriptionHash = "animDescanim@mp_player_intcelebrationmale@face_palmface_palm", dict = "anim@mp_player_intcelebrationmale@face_palm", state = "face_palm", flag = 49, repeat = true, sex = "both" });
        animAllgemein1.Add(new { hash = "mit Fernglas schauen", descriptionHash = "animDescamb@world_human_binoculars@male@basebase", dict = "amb@world_human_binoculars@male@base", state = "base", flag = 49, repeat = true, sex = "both" });
        animAllgemein1.Add(new { hash = "im Gesicht kratzen", descriptionHash = "animDescmisscarsteal4@aliensrehearsal_base_idle_director", dict = "misscarsteal4@aliens", state = "rehearsal_base_idle_director", flag = 49, repeat = true, sex = "both" });
        animAllgemein1.Add(new { hash = "Nachdenklich", descriptionHash = "animDesctimetable@tracy@ig_8@basebase", dict = "timetable@tracy@ig_8@base", state = "base", flag = 49, repeat = true, sex = "both" });
        animAllgemein1.Add(new { hash = "Joint rauchen", descriptionHash = "animDescamb@world_human_smoking@male@male_b@basebase", dict = "amb@world_human_smoking@male@male_b@base", state = "base", flag = 49, repeat = true, sex = "both" });
        animAllgemein1.Add(new { hash = "Joint rauchen 2", descriptionHash = "animDescamb@world_human_smoking_pot@male@basebase", dict = "amb@world_human_smoking_pot@male@base", state = "base", flag = 49, repeat = true, sex = "both" });
        animAllgemein1.Add(new { hash = "Heavy Metal", descriptionHash = "animDescmp_player_int_upperrockmp_player_int_rock", dict = "mp_player_int_upperrock", state = "mp_player_int_rock", flag = 49, repeat = true, sex = "both" });
        animAllgemein1.Add(new { hash = "Rocken", descriptionHash = "animDescmp_player_introckmp_player_int_rock", dict = "mp_player_introck", state = "mp_player_int_rock", flag = 49, repeat = true, sex = "both" });
        animAllgemein1.Add(new { hash = "Ausflippen", descriptionHash = "animDescanim@mp_player_intcelebrationmale@freakoutfreakout", dict = "anim@mp_player_intcelebrationmale@freakout", state = "freakout", flag = 33, repeat = true, sex = "both" });
        animAllgemein1.Add(new { hash = "Komm doch her", descriptionHash = "animDescmissarmenian2lamar_impatient_a", dict = "missarmenian2", state = "lamar_impatient_a", flag = 49, repeat = true, sex = "both" });


        //
        //
        //

        animHandbewegungen1.Add(new { hash = "Hände hoch", descriptionHash = "animDescrcmpaparazzo_4lift_hands_in_air_loop", dict = "rcmpaparazzo_4", state = "lift_hands_in_air_loop", flag = 49, repeat = true, sex = "both" });
        animHandbewegungen1.Add(new { hash = "Hände hinterm Kopf", descriptionHash = "animDescrandom@arrests@bustedidle_c", dict = "random@arrests@busted", state = "idle_c", flag = 49, repeat = true, sex = "both" });
        animHandbewegungen1.Add(new { hash = "Klatschen", descriptionHash = "animDescamb@world_human_cheering@male_abase", dict = "amb@world_human_cheering@male_a", state = "base", flag = 49, repeat = true, sex = "both" });
        animHandbewegungen1.Add(new { hash = "Mittelfinge arme ausgestreckt", descriptionHash = "animDescnm@handsmiddle_finger", dict = "nm@hands", state = "middle_finger", flag = 33, repeat = true, sex = "both" });
        animHandbewegungen1.Add(new { hash = "Arme gekreuzt", descriptionHash = "animDescoddjobs@assassinate@guardunarmed_fold_arms", dict = "oddjobs@assassinate@guard", state = "unarmed_fold_arms", flag = 49, repeat = true, sex = "both" });
        animHandbewegungen1.Add(new { hash = "herbei rufen", descriptionHash = "animDescoddjobs@towingcome_herecome_here_idle_a", dict = "oddjobs@towingcome_here", state = "come_here_idle_a", flag = 49, repeat = true, sex = "both" });
        animHandbewegungen1.Add(new { hash = "Danke", descriptionHash = "animDescrandom@bicycle_thief@thanksthanks_a", dict = "random@bicycle_thief@thanks", state = "thanks_a", flag = 49, repeat = true, sex = "both" });
        animHandbewegungen1.Add(new { hash = "wartend aufregen", descriptionHash = "animDescrandom@car_thief@waiting_ig_4waiting", dict = "random@car_thief@waiting_ig_4", state = "waiting", flag = 49, repeat = true, sex = "both" });
        animHandbewegungen1.Add(new { hash = "weiblich Hallo", descriptionHash = "animDescrandom@gang_intimidation@001445_01_gangintimidation_1_female_idle_b", dict = "random@gang_intimidation@", state = "001445_01_gangintimidation_1_female_idle_b", flag = 49, repeat = true, sex = "both" });
        animHandbewegungen1.Add(new { hash = "beide Hände in die höhe", descriptionHash = "animDescrandom@mugging5001445_01_gangintimidation_1_female_idle_b", dict = "random@mugging5", state = "001445_01_gangintimidation_1_female_idle_b", flag = 49, repeat = true, sex = "both" });
        animHandbewegungen1.Add(new { hash = "Ok", descriptionHash = "animDescanim@mp_player_intselfiedockidle_a", dict = "anim@mp_player_intselfiedock", state = "idle_a", flag = 49, repeat = true, sex = "both" });
        animHandbewegungen1.Add(new { hash = "zu sich rufen", descriptionHash = "animDesctimetable@amanda@facemask@basebase", dict = "timetable@amanda@facemask@base", state = "base", flag = 49, repeat = true, sex = "both" });
        animHandbewegungen1.Add(new { hash = "sich ergeben", descriptionHash = "animDescmp_am_hold_uphandsup_base", dict = "mp_am_hold_up", state = "handsup_base", flag = 49, repeat = true, sex = "both" });
        animHandbewegungen1.Add(new { hash = "Cola Trinken", descriptionHash = "animDescamb@world_human_drinking@coffee@female@idle_aidle_a", dict = "amb@world_human_drinking@coffee@female@idle_a", state = "idle_a", flag = 49, repeat = true, sex = "both" });
        animHandbewegungen1.Add(new { hash = "Döner essen", descriptionHash = "animDescmp_player_inteat@burgermp_player_int_eat_burger", dict = "mp_player_inteat@burger", state = "mp_player_int_eat_burger", flag = 49, repeat = true, sex = "both" });
        animHandbewegungen1.Add(new { hash = "Fäuste knacken lassen", descriptionHash = "animDescanim@mp_player_intupperknuckle_crunchidle_a", dict = "anim@mp_player_intupperknuckle_crunch", state = "idle_a", flag = 49, repeat = true, sex = "both" });
        animHandbewegungen1.Add(new { hash = "Alles easy", descriptionHash = "animDescgestures@f@standing@casualgesture_easy_now", dict = "gestures@f@standing@casual", state = "gesture_easy_now", flag = 49, repeat = true, sex = "both" });
        animHandbewegungen1.Add(new { hash = "Salutieren", descriptionHash = "animDescanim@mp_player_intincarsalutestd@rds@idle_a", dict = "anim@mp_player_intincarsalutestd@rds@", state = "idle_a", flag = 49, repeat = true, sex = "both" });
        animHandbewegungen1.Add(new { hash = "Salutieren grüßen", descriptionHash = "animDescmp_player_intsalutemp_player_int_salute", dict = "mp_player_intsalute", state = "mp_player_int_salute", flag = 49, repeat = true, sex = "both" });
        animHandbewegungen1.Add(new { hash = "kratzen am Hinterkopf", descriptionHash = "animDescclothingtiecheck_out_a", dict = "clothingtie", state = "check_out_a", flag = 49, repeat = true, sex = "both" });
        animHandbewegungen1.Add(new { hash = "Peace mit beiden Händen", descriptionHash = "animDescp_player_int_upperpeace_signmp_player_int_peace_sign", dict = "mp_player_int_upperpeace_sign", state = "mp_player_int_peace_sign", flag = 49, repeat = true, sex = "both" });
        animHandbewegungen1.Add(new { hash = "Hand in die Luft", descriptionHash = "animDescmisscarsteal2come_here_idle_c", dict = "misscarsteal2", state = "come_here_idle_c", flag = 49, repeat = true, sex = "both" });
        animHandbewegungen1.Add(new { hash = "Handy telefonieren", descriptionHash = "animDescamb@world_human_stand_mobile@male@standing@call@basebase", dict = "amb@world_human_stand_mobile@male@standing@call@base", state = "base", flag = 49, repeat = true, sex = "both" });
        animHandbewegungen1.Add(new { hash = "Mittelfinger 1", descriptionHash = "animDescmp_player_int_upperfingermp_player_int_finger_02", dict = "mp_player_int_upperfinger", state = "mp_player_int_finger_02", flag = 49, repeat = true, sex = "both" });
        animHandbewegungen1.Add(new { hash = "Mittelfinger 2", descriptionHash = "animDescmp_player_int_upperfingermp_player_int_finger_01", dict = "mp_player_int_upperfinger", state = "mp_player_int_finger_01", flag = 49, repeat = true, sex = "both" });
        animHandbewegungen1.Add(new { hash = "Mittelfiner 3", descriptionHash = "animDescanim@mp_player_intupperfingeridle_a_fp", dict = "anim@mp_player_intupperfinger", state = "idle_a_fp", flag = 49, repeat = true, sex = "both" });
        animHandbewegungen1.Add(new { hash = "Mittelfiner take a Round", descriptionHash = "animDescmp_player_intfingermp_player_int_finger", dict = "mp_player_intfinger", state = "mp_player_int_finger", flag = 49, repeat = true, sex = "both" });
        animHandbewegungen1.Add(new { hash = "Pssssssst", descriptionHash = "animDescanim@mp_player_intuppershushidle_a_fp", dict = "anim@mp_player_intuppershush", state = "idle_a_fp", flag = 49, repeat = true, sex = "both" });
        animHandbewegungen1.Add(new { hash = "Daumen Hoch", descriptionHash = "animDescanim@mp_player_intincarthumbs_upstd@ds@idle_a", dict = "anim@mp_player_intincarthumbs_upstd@ds@", state = "idle_a", flag = 49, repeat = true, sex = "both" });
        animHandbewegungen1.Add(new { hash = "Damn", descriptionHash = "animDescgestures@f@standing@casualgesture_damn", dict = "gestures@f@standing@casual", state = "gesture_damn", flag = 49, repeat = true, sex = "both" });
        animHandbewegungen1.Add(new { hash = "Emotionsloses Klatschen", descriptionHash = "animDescanim@mp_player_intcelebrationmale@slow_clapslow_clap", dict = "anim@mp_player_intcelebrationmale@slow_clap", state = "slow_clap", flag = 49, repeat = true, sex = "both" });

        //
        //
        //

        animSport1.Add(new { hash = "Gymnastik", descriptionHash = "animDescamb@world_human_yoga@male@basebase_a", dict = "amb@world_human_yoga@male@base", state = "base_a", flag = 33, repeat = true, sex = "both" });
        animSport1.Add(new { hash = "Sport Übung 1", descriptionHash = "animDescrcmfanatic1maryann_stretchidle_bidle_e", dict = "rcmfanatic1maryann_stretchidle_b", state = "idle_e", flag = 33, repeat = true, sex = "both" });
        animSport1.Add(new { hash = "Yoga", descriptionHash = "animDescrcmcollect_paperleadinout@meditiate_idle", dict = "rcmcollect_paperleadinout@", state = "meditiate_idle", flag = 33, repeat = true, sex = "both" });
        animSport1.Add(new { hash = "Liegstüze", descriptionHash = "animDescrcmfanatic3ef_3_rcm_loop_maryann", dict = "rcmfanatic3", state = "ef_3_rcm_loop_maryann", flag = 33, repeat = true, sex = "both" });
        animSport1.Add(new { hash = "auf der Stelle joggen", descriptionHash = "animDescamb@world_human_jog_standing@male@fitbasebase", dict = "amb@world_human_jog_standing@male@fitbase", state = "base", flag = 33, repeat = true, sex = "both" });
        animSport1.Add(new { hash = "Situps", descriptionHash = "animDescamb@world_human_sit_ups@male@idle_aidle_a", dict = "amb@world_human_sit_ups@male@idle_a", state = "idle_a", flag = 33, repeat = true, sex = "both" });

        //
        //
        //

        animTanz1.Add(new { hash = "Zappelig", descriptionHash = "animDescspecial_ped@mountain_dancer@basebase", dict = "special_ped@mountain_dancer@base", state = "base", flag = 33, repeat = true, sex = "both" });
        animTanz1.Add(new { hash = "Angel", descriptionHash = "animDescspecial_ped@mountain_dancer@monologue_2@monologue_2amnt_dnc_angel", dict = "special_ped@mountain_dancer@monologue_2@monologue_2a", state = "mnt_dnc_angel", flag = 33, repeat = true, sex = "both" });
        animTanz1.Add(new { hash = "Buttwag", descriptionHash = "animDescspecial_ped@mountain_dancer@monologue_3@monologue_3amnt_dnc_buttwag", dict = "special_ped@mountain_dancer@monologue_3@monologue_3a", state = "mnt_dnc_buttwag", flag = 33, repeat = true, sex = "both" });
        animTanz1.Add(new { hash = "Tänzer", descriptionHash = "animDescspecial_ped@mountain_dancer@monologue_4@monologue_4amnt_dnc_verse", dict = "special_ped@mountain_dancer@monologue_4@monologue_4a", state = "mnt_dnc_verse", flag = 33, repeat = true, sex = "both" });
        animTanz1.Add(new { hash = "Angeheitert", descriptionHash = "animDescamb@world_human_partying@female@partying_beer@basebase", dict = "amb@world_human_partying@female@partying_beer@base", state = "base", flag = 33, repeat = true, sex = "both" });
        animTanz1.Add(new { hash = "Its Cool Men", descriptionHash = "animDescamb@world_human_strip_watch_stand@male_a@basebase", dict = "amb@world_human_strip_watch_stand@male_a@base", state = "base", flag = 33, repeat = true, sex = "both" });
        animTanz1.Add(new { hash = "Privatdance 1", descriptionHash = "animDescmini@strip_club@private_dance@part1priv_dance_p1", dict = "mini@strip_club@private_dance@part1", state = "priv_dance_p1", flag = 33, repeat = true, sex = "both" });
        animTanz1.Add(new { hash = "Privatdance 2", descriptionHash = "animDescmini@strip_club@private_dance@part2priv_dance_p2", dict = "mini@strip_club@private_dance@part2", state = "priv_dance_p2", flag = 33, repeat = true, sex = "both" });
        animTanz1.Add(new { hash = "Privatdance 3", descriptionHash = "animDescmini@strip_club@private_dance@part3priv_dance_p3", dict = "mini@strip_club@private_dance@part3", state = "priv_dance_p3", flag = 33, repeat = true, sex = "both" });
        animTanz1.Add(new { hash = "Dance 1", descriptionHash = "amb@code_human_in_car_mp_actions@dance@std@ds@base", dict = "amb@code_human_in_car_mp_actions@dance@std@ds@base", state = "idle_a", flag = 33, repeat = true, sex = "both" });
        animTanz1.Add(new { hash = "Dance 2", descriptionHash = "amb@code_human_in_car_mp_actions@dance@std@ps@base", dict = "amb@code_human_in_car_mp_actions@dance@std@ps@base", state = "idle_a", flag = 33, repeat = true, sex = "both" });
        animTanz1.Add(new { hash = "Dance 3", descriptionHash = "mini@strip_club@pole_dance@pole_a_2_stage", dict = "mini@strip_club@pole_dance@pole_a_2_stage", state = "pole_a_2_stage", flag = 33, repeat = true, sex = "both" });
        animTanz1.Add(new { hash = "Dance 4", descriptionHash = "misschinese1crazydance", dict = "misschinese1crazydance", state = "crazy_dance_3", flag = 33, repeat = true, sex = "both" });
        animTanz1.Add(new { hash = "Dance 5", descriptionHash = "amb@code_human_in_car_mp_actions@dance@std@rps@base", dict = "amb@code_human_in_car_mp_actions@dance@std@rps@base", state = "idle_a", flag = 33, repeat = true, sex = "both" });
        animTanz1.Add(new { hash = "Dance 6", descriptionHash = "special_ped@mountain_dancer@base", dict = "special_ped@mountain_dancer@base", state = "base", flag = 33, repeat = true, sex = "both" });
        animTanz1.Add(new { hash = "Playboy", descriptionHash = "animDesctimetable@tracy@ig_8@idle_aidle_a", dict = "timetable@tracy@ig_8@idle_a", state = "idle_a", flag = 33, repeat = true, sex = "both" });


        //
        //
        //

        animStehen1.Add(new { hash = "Betrunken", descriptionHash = "animDescmissarmenian2standing_idle_loop_drunk", dict = "missarmenian2", state = "standing_idle_loop_drunk", flag = 33, repeat = true, sex = "both" });
        animStehen1.Add(new { hash = "wartende Nutte", descriptionHash = "animDescamb@world_human_prostitute@hooker@idle_aidle_a", dict = "amb@world_human_prostitute@hooker@idle_a", state = "idle_a", flag = 33, repeat = true, sex = "both" });
        animStehen1.Add(new { hash = "weibliches Rauchen", descriptionHash = "animDescamb@world_human_smoking@female@basebase", dict = "amb@world_human_smoking@female@base", state = "base", flag = 33, repeat = true, sex = "both" });
        animStehen1.Add(new { hash = "Verägert", descriptionHash = "animDescmisscarsteal1leadinout@i_fought_the_lawmicarrive_leadin_loop_devin", dict = "misscarsteal1leadinout@i_fought_the_law", state = "micarrive_leadin_loop_devin", flag = 49, repeat = true, sex = "both" });
        animStehen1.Add(new { hash = "weiblich Arme gekreuzt", descriptionHash = "animDescamb@world_human_hang_out_street@female_arms_crossed@basebase", dict = "amb@world_human_hang_out_street@female_arms_crossed@base", state = "base", flag = 33, repeat = true, sex = "both" });
        animStehen1.Add(new { hash = "rum hängen", descriptionHash = "animDescamb@world_human_hang_out_street@male_c@basebase", dict = "amb@world_human_hang_out_street@male_c@base", state = "base", flag = 33, repeat = true, sex = "both" });
        animStehen1.Add(new { hash = "cool stehen", descriptionHash = "animDescamb@world_human_stand_guard@male@basebase", dict = "amb@world_human_stand_guard@male@base", state = "base", flag = 33, repeat = true, sex = "both" });
        animStehen1.Add(new { hash = "locker stehen", descriptionHash = "animDescamb@world_human_stand_impatient@female@no_sign@basebase", dict = "amb@world_human_stand_impatient@female@no_sign@base", state = "base", flag = 33, repeat = true, sex = "both" });
        animStehen1.Add(new { hash = "Alles easy im Schritt", descriptionHash = "animDescmini@strip_club@idles@bouncer@idle_aidle_a", dict = "mini@strip_club@idles@bouncer@idle_a", state = "idle_a", flag = 33, repeat = true, sex = "both" });
        animStehen1.Add(new { hash = "Ich bin der Boss", descriptionHash = "animDescanim@heists@heist_corona@single_teamsingle_team_intro_boss", dict = "anim@heists@heist_corona@single_team", state = "single_team_intro_boss", flag = 33, repeat = true, sex = "both" });

        //
        //
        //
        animSitzenBeugen1.Add(new { hash = "verbittert Hocken", descriptionHash = "animDescamb@code_human_cower@male@basebase", dict = "amb@code_human_cower@male@base", state = "base", flag = 33, repeat = true, sex = "both" });
        animSitzenBeugen1.Add(new { hash = "Traumtänzer", descriptionHash = "animDescamb@code_human_cower@male@idle_aidle_b", dict = "amb@code_human_cower@male@idle_a", state = "idle_b", flag = 33, repeat = true, sex = "both" });
        animSitzenBeugen1.Add(new { hash = "auf die knie fallen", descriptionHash = "animDescrandom@rescue_hostagegirl_helping_girl_loop", dict = "random@rescue_hostage", state = "girl_helping_girl_loop", flag = 33, repeat = true, sex = "both" });
        animSitzenBeugen1.Add(new { hash = "Hocken", descriptionHash = "animDescmisstrevor2ron_basic_movesidle", dict = "misstrevor2ron_basic_moves", state = "idle", flag = 33, repeat = true, sex = "both" });
        animSitzenBeugen1.Add(new { hash = "vor dem König knien", descriptionHash = "animDescmissheistdockssetup1ig_3@basewelding_base_dockworker", dict = "missheistdockssetup1ig_3@base", state = "welding_base_dockworker", flag = 33, repeat = true, sex = "both" });
        animSitzenBeugen1.Add(new { hash = "Boden fegen", descriptionHash = "animDescamb@world_human_bum_wash@male@low@basebase", dict = "amb@world_human_bum_wash@male@low@base", state = "base", flag = 33, repeat = true, sex = "both" });
        animSitzenBeugen1.Add(new { hash = "Felge montieren", descriptionHash = "animDescmini@cpr@char_a@cpr_strcpr_kol_idle", dict = "mini@cpr@char_a@cpr_str", state = "cpr_kol_idle", flag = 33, repeat = true, sex = "both" });
        animSitzenBeugen1.Add(new { hash = "Medic leistet Beistand", descriptionHash = "animDescamb@medic@standing@kneel@basebase", dict = "amb@medic@standing@kneel@base", state = "base", flag = 33, repeat = true, sex = "both" });
        animSitzenBeugen1.Add(new { hash = "auf die Schuhe schauen", descriptionHash = "animDescclothingshoescheck_out_a", dict = "clothingshoes", state = "check_out_a", flag = 33, repeat = true, sex = "both" });
        animSitzenBeugen1.Add(new { hash = "Picnic ", descriptionHash = "animDescamb@world_human_picnic@male@basebase", dict = "amb@world_human_picnic@male@base", state = "base", flag = 33, repeat = true, sex = "both" });
        animSitzenBeugen1.Add(new { hash = "auf dem boden Sitzen", descriptionHash = "animDescamb@world_human_stupor@male@basebase", dict = "amb@world_human_stupor@male@base", state = "base", flag = 33, repeat = true, sex = "both" });
        animSitzenBeugen1.Add(new { hash = "weiblich auf dem Boden sitzen", descriptionHash = "animDescamb@lo_res_idles@world_human_picnic_female_lo_res_base", dict = "amb@lo_res_idles@", state = "world_human_picnic_female_lo_res_base", flag = 33, repeat = true, sex = "both" });
        animSitzenBeugen1.Add(new { hash = "Boden sitzen männlich", descriptionHash = "animDescanim@heists@fleeca_bank@ig_7_jetski_ownerowner_idle", dict = "anim@heists@fleeca_bank@ig_7_jetski_owner", state = "owner_idle", flag = 33, repeat = true, sex = "both" });


        //
        //
        //

        animLiegen1.Add(new { hash = "verletzt", descriptionHash = "animDescrandom@crash_rescue@wounded@basebase", dict = "random@crash_rescue@wounded@base", state = "base", flag = 33, repeat = true, sex = "both" });
        animLiegen1.Add(new { hash = "Unterleibsschmerzen", descriptionHash = "animDescmissfbi5ig_0lyinginpain_loop_steve", dict = "missfbi5ig_0", state = "lyinginpain_loop_steve", flag = 33, repeat = true, sex = "both" });
        animLiegen1.Add(new { hash = "Sonnebaden Rückenliegend weiblich", descriptionHash = "animDescamb@world_human_sunbathe@female@back@basebase", dict = "amb@world_human_sunbathe@female@back@base", state = "base", flag = 33, repeat = true, sex = "both" });
        animLiegen1.Add(new { hash = "Sonnebaden Bauchliegend weiblich", descriptionHash = "animDescamb@world_human_sunbathe@female@front@basebase", dict = "amb@world_human_sunbathe@female@front@base", state = "base", flag = 33, repeat = true, sex = "both" });
        animLiegen1.Add(new { hash = "Sonnebaden Rückenliegend männlich", descriptionHash = "animDescamb@world_human_sunbathe@male@back@basebase", dict = "amb@world_human_sunbathe@male@back@base", state = "base", flag = 33, repeat = true, sex = "both" });
        animLiegen1.Add(new { hash = "Sonnebaden Bauchliegend männlich", descriptionHash = "animDescamb@world_human_sunbathe@male@front@basebase", dict = "amb@world_human_sunbathe@male@front@base", state = "base", flag = 33, repeat = true, sex = "both" });
        animLiegen1.Add(new { hash = "Auf dem Rücken liegen", descriptionHash = "animDescmini@cpr@char_b@cpr_defcpr_pumpchest_idle", dict = "mini@cpr@char_b@cpr_def", state = "cpr_pumpchest_idle", flag = 33, repeat = true, sex = "both" });
        animLiegen1.Add(new { hash = "Auf der Seite schlafen", descriptionHash = "animDesctimetable@tracy@sleep@base", dict = "timetable@tracy@sleep@", state = "base", flag = 33, repeat = true, sex = "both" });

        //
        //
        //

        animWeiblich1.Add(new { hash = "Rauchen", descriptionHash = "animDescamb@world_human_leaning@female@smoke@basebase", dict = "amb@world_human_leaning@female@smoke@base", state = "base", flag = 33, repeat = true, sex = "female" });
        animWeiblich1.Add(new { hash = "Warten", descriptionHash = "animDescamb@world_human_leaning@female@wall@back@holding_elbow@basebase", dict = "amb@world_human_leaning@female@wall@back@holding_elbow@base", state = "base", flag = 33, repeat = true, sex = "female" });
        animWeiblich1.Add(new { hash = "Warten 1", descriptionHash = "animDescamb@world_human_prostitute@hooker@idle_aidle_a", dict = "amb@world_human_prostitute@hooker@idle_a", state = "idle_a", flag = 33, repeat = true, sex = "female" });
        animWeiblich1.Add(new { hash = "Rauchen 1", descriptionHash = "animDescamb@world_human_smoking@female@basebase", dict = "amb@world_human_smoking@female@base", state = "base", flag = 33, repeat = true, sex = "female" });
        animWeiblich1.Add(new { hash = "Hallo", descriptionHash = "animDescrandom@gang_intimidation@001445_01_gangintimidation_1_female_idle_b", dict = "random@gang_intimidation@", state = "001445_01_gangintimidation_1_female_idle_b", flag = 49, repeat = true, sex = "female" });
        animWeiblich1.Add(new { hash = "Küsschen geben", descriptionHash = "animDescanim@mp_player_intcelebrationfemale@blow_kissblow_kiss", dict = "anim@mp_player_intcelebrationfemale@blow_kiss", state = "blow_kiss", flag = 33, repeat = true, sex = "female" });
        animWeiblich1.Add(new { hash = "Warten 3", descriptionHash = "animDescrcmnigel1cnmt_1cprice_tag", dict = "rcmnigel1cnmt_1c", state = "price_tag", flag = 49, repeat = true, sex = "female" });
        animWeiblich1.Add(new { hash = "Nein, heißt Nein", descriptionHash = "animDescmini@prostitutestalkstreet_argue_f_a", dict = "mini@prostitutestalk", state = "street_argue_f_a", flag = 49, repeat = true, sex = "female" });
        animWeiblich1.Add(new { hash = "Facepalm", descriptionHash = "animDescanim@mp_player_intcelebrationfemale@face_palmface_palm", dict = "anim@mp_player_intcelebrationfemale@face_palm", state = "face_palm", flag = 49, repeat = true, sex = "female" });
        animWeiblich1.Add(new { hash = "Arme gekreuzt", descriptionHash = "animDescamb@world_human_hang_out_street@female_arms_crossed@basebase", dict = "amb@world_human_hang_out_street@female_arms_crossed@base", state = "base", flag = 33, repeat = true, sex = "female" });
        animWeiblich1.Add(new { hash = "Auf Boden liegen", descriptionHash = "animDescamb@lo_res_idles@world_human_picnic_female_lo_res_base", dict = "amb@lo_res_idles@", state = "world_human_picnic_female_lo_res_base", flag = 33, repeat = true, sex = "female" });
        animWeiblich1.Add(new { hash = "Sonnebaden Rücken", descriptionHash = "animDescamb@world_human_sunbathe@female@back@basebase", dict = "amb@world_human_sunbathe@female@back@base", state = "base", flag = 33, repeat = true, sex = "female" });
        animWeiblich1.Add(new { hash = "Sonnebaden Bauch", descriptionHash = "animDescamb@world_human_sunbathe@female@front@basebase", dict = "amb@world_human_sunbathe@female@front@base", state = "base", flag = 33, repeat = true, sex = "female" });


        //
        //
        //
        animAnlehnen1.Add(new { hash = "An der Wand lehnen", descriptionHash = "animDescamb@world_human_leaning@female@smoke@basebase", dict = "amb@world_human_leaning@female@smoke@base", state = "base", flag = 33, repeat = true, sex = "both" });
        animAnlehnen1.Add(new { hash = "An der Wand lehnen 1", descriptionHash = "animDescamb@world_human_leaning@female@wall@back@holding_elbow@basebase", dict = "amb@world_human_leaning@female@wall@back@holding_elbow@base", state = "base", flag = 33, repeat = true, sex = "both" });
        animAnlehnen1.Add(new { hash = "An der Wand lehnen 2", descriptionHash = "animDescamb@world_human_leaning@male@wall@back@foot_up@basebase", dict = "amb@world_human_leaning@male@wall@back@foot_up@base", state = "base", flag = 33, repeat = true, sex = "both" });
        animAnlehnen1.Add(new { hash = "An der Wand lehnen 3", descriptionHash = "animDescamb@world_human_leaning@male@wall@back@hands_together@basebase", dict = "amb@world_human_leaning@male@wall@back@hands_together@base", state = "base", flag = 33, repeat = true, sex = "both" });
        animAnlehnen1.Add(new { hash = "An der Wand lehnen 4", descriptionHash = "animDescamb@world_human_leaning@male@wall@back@legs_crossed@basebase", dict = "amb@world_human_leaning@male@wall@back@legs_crossed@base", state = "base", flag = 33, repeat = true, sex = "both" });
        animAnlehnen1.Add(new { hash = "An der Wand lehnen 5", descriptionHash = "animDescoddjobs@assassinate@hotel@leaning@idle_a", dict = "oddjobs@assassinate@hotel@leaning@", state = "idle_a", flag = 33, repeat = true, sex = "both" });
        animAnlehnen1.Add(new { hash = "An der Wand lehnen 6", descriptionHash = "animDescrcmnigel1aig_1this_is_awkward_willie", dict = "rcmnigel1aig_1", state = "this_is_awkward_willie", flag = 33, repeat = true, sex = "both" });

        //
        //
        //

        animLaufstile1.Add(new { hash = "Depressiv", descriptionHash = "animDescoddjobs@bailbond_hobodepressedidle_a", dict = "oddjobs@bailbond_hobodepressed", state = "idle_a", flag = 49, repeat = true, sex = "both" });
        animLaufstile1.Add(new { hash = "Aufgeregt", descriptionHash = "animDescoddjobs@bailbond_hobotwitchyidle_a", dict = "oddjobs@bailbond_hobotwitchy", state = "idle_a", flag = 49, repeat = true, sex = "both" });
        animLaufstile1.Add(new { hash = "Erklärend", descriptionHash = "animDescoddjobs@bailbond_mountainexcited_idle_b", dict = "oddjobs@bailbond_mountain", state = "excited_idle_b", flag = 49, repeat = true, sex = "both" });
        animLaufstile1.Add(new { hash = "Telefonierend", descriptionHash = "animDescoddjobs@bailbond_quarryprem_producer_argue_a", dict = "oddjobs@bailbond_quarry", state = "prem_producer_argue_a", flag = 49, repeat = true, sex = "both" });
        animLaufstile1.Add(new { hash = "Angeregt", descriptionHash = "animDescoddjobs@bailbond_surf_farmidle_a", dict = "oddjobs@bailbond_surf_farm", state = "idle_a", flag = 49, repeat = true, sex = "both" });
        animLaufstile1.Add(new { hash = "ängstlich", descriptionHash = "animDescrandom@prisoner_liftloop2_idlelook2", dict = "random@prisoner_lift", state = "loop2_idlelook2", flag = 49, repeat = true, sex = "both" });
        animLaufstile1.Add(new { hash = "erschöpft", descriptionHash = "animDescrcmfanatic1out_of_breathp_zero_tired_01", dict = "rcmfanatic1out_of_breath", state = "p_zero_tired_01", flag = 49, repeat = true, sex = "both" });
        animLaufstile1.Add(new { hash = "Voll betrunken", descriptionHash = "animDescmove_m@drunk@verydrunkwalk", dict = "move_m@drunk@verydrunk", state = "walk", flag = 33, repeat = true, sex = "both" });

        //
        //
        //

        animPolice1.Add(new { hash = "An den Gürtel packen ", descriptionHash = "animDescamb@world_human_cop_idles@male@basebase", dict = "amb@world_human_cop_idles@male@base", state = "base", flag = 49, repeat = true, sex = "both" });
        animPolice1.Add(new { hash = "Arme in die Hüfte stemmen", descriptionHash = "animDescamb@world_human_cop_idles@male@idle_bidle_e", dict = "amb@world_human_cop_idles@male@idle_b", state = "idle_e", flag = 49, repeat = true, sex = "both" });
        animPolice1.Add(new { hash = "Arme übre Kreuz", descriptionHash = "animDescamb@world_human_cop_idles@female@idle_bidle_e", dict = "amb@world_human_cop_idles@female@idle_b", state = "idle_e", flag = 49, repeat = true, sex = "both" });
        animPolice1.Add(new { hash = "An der Unfallstelle vorbei Winken", descriptionHash = "animDescamb@world_human_car_park_attendant@male@basebase", dict = "amb@world_human_car_park_attendant@male@base", state = "base", flag = 49, repeat = true, sex = "both" });
        animPolice1.Add(new { hash = "Strafzettel", descriptionHash = "animDescamb@medic@standing@timeofdeath@basebase", dict = "amb@medic@standing@timeofdeath@base", state = "base", flag = 49, repeat = true, sex = "both" });
        animPolice1.Add(new { hash = "schauen Sie hier ", descriptionHash = "animDescamb@world_human_clipboard@male@idle_aidle_c", dict = "amb@world_human_clipboard@male@idle_a", state = "idle_c", flag = 49, repeat = true, sex = "both" });
        animPolice1.Add(new { hash = "Rückendeckung geben", descriptionHash = "animDescmove_m@intimidation@cop@unarmedidle", dict = "move_m@intimidation@cop@unarmed", state = "idle", flag = 49, repeat = true, sex = "both" });
        animPolice1.Add(new { hash = "auf dem Stuhl sitzen", descriptionHash = "animDescamb@prop_human_seat_chair@male@left_elbow_on_knee@base", dict = "amb@prop_human_seat_chair@male@left_elbow_on_knee@base", state = "base", flag = 33, repeat = true, sex = "both" });

    }


    [Flags]
    public enum AnimationFlags
    {
        Loop = 1 << 0,
        StopOnLastFrame = 1 << 1,
        OnlyAnimateUpperBody = 1 << 4,
        AllowPlayerControl = 1 << 5,
        Cancellable = 1 << 7
    }

    [RemoteEvent("Falando")]
    public static void FalandoOn(Client player)
    {
        player.SetSharedData("falando", true);
    }

    [RemoteEvent("FalandoOff")]
    public static void FalandoOff(Client player)
    {
        player.SetSharedData("falando", false);
    }

    [RemoteEvent("MuteVoice")]
    public static void MuteVoice(Client player, Client target)
    {
        target.TriggerEvent("MuteVoice");
    }

    [RemoteEvent("handsUp")]
    public static void handsUp(Client player)
    {
        player.SetData("handsup", true);
    }

    [RemoteEvent("handsDown")]
    public static void handsDown(Client player)
    {
        player.SetData("handsup", false);
        player.StopAnimation();
    }

    [RemoteEvent("PlayAnimationFromMenu")]
    public static void OnPlayAnimationFromMenu(Client player, string dict, string state, int flag)
    {
        player.PlayAnimation(dict, state, flag);
    }

    [RemoteEvent("StopAnimationFromMenu")]
    public static void StopAnimationFromMenu(Client player)
    {
        player.StopAnimation();
    }


  
    [RemoteEvent("keypress:U")]
    public void KeyPressF1(Client player)
    {
        if (player.GetData("status") == false)
        {
            return;
        }

        if(player.IsInVehicle)
        {
            return;
        }


        ShowAnimationMenu(player);
       /* if(player.HasData("AnimationMenu"))
        {
            player.TriggerEvent("Destroy_Character_Menu");
            player.ResetData("AnimationMenu");
        }
        else
        {
            player.TriggerEvent("Display_Animation");
            player.SetData("AnimationMenu", true);
        }*/
    }

    [RemoteEvent("closeAnimationMenu")]
    public static void closeAnimationMenu(Client player)
    {
        if (player.HasData("AnimationMenu"))
        {
            player.ResetData("AnimationMenu");
        }
    }


    public static void ShowAnimationMenu(Client player)
    {

        List<dynamic> menu_item_list = new List<dynamic>();
        menu_item_list.Add(new { Type = 1, Name = "Animation stoppen", Description = "Dient zum Stoppen der aktuellen Animation.", RightBadge = "", Color = "Firebrick", HighlightColor = "White" });
        menu_item_list.Add(new { Type = 1, Name = "Allgemeines", Description = "", RightBadge = "none" });
        menu_item_list.Add(new { Type = 1, Name = "Handbewegung", Description = "", RightBadge = "none" });
        menu_item_list.Add(new { Type = 1, Name = "Sport", Description = "", RightBadge = "none" });
        menu_item_list.Add(new { Type = 1, Name = "Tänze", Description = "", RightBadge = "none" });
        menu_item_list.Add(new { Type = 1, Name = "Unterstützung", Description = "", RightBadge = "none" });
        menu_item_list.Add(new { Type = 1, Name = "Entspannen", Description = "", RightBadge = "none" });
        menu_item_list.Add(new { Type = 1, Name = "Liegend / verletzt", Description = "", RightBadge = "none" });
        menu_item_list.Add(new { Type = 1, Name = "Frauen", Description = "", RightBadge = "none" });
        menu_item_list.Add(new { Type = 1, Name = "Anlehnen", Description = "", RightBadge = "none" });
        menu_item_list.Add(new { Type = 1, Name = "Laufstile", Description = "", RightBadge = "none" });
        menu_item_list.Add(new { Type = 1, Name = "Polizeianimationen", Description = "", RightBadge = "none" });


        InteractMenu.CreateMenu(player, "ANIMATION_MENU", "Animation", "~b~Animationssystem", false, JsonConvert.SerializeObject(menu_item_list), false);

    }

    public static void SelectMenuResponse(Client player, String callbackId, int selectedIndex, String objectName, String valueList)
    {
        if (callbackId == "ANIMATION_MENU")
        {
            List<dynamic> menu_item_list = new List<dynamic>();
            switch (selectedIndex)
            {
                case 0:
                    {
                        StopAnimationFromMenu(player);
                        break;
                    }
                case 1:
                    {
                        foreach (var menu in animAllgemein1)
                        {
                            menu_item_list.Add(new { Type = 1, Name = menu.hash, Description = "", RightBadge = "none" });
                        }
                        InteractMenu.CreateMenu(player, "PLAY_ANIMATION", "Animation", "~b~ANIMATION: " + objectName, false, JsonConvert.SerializeObject(menu_item_list), false);
                        player.SetData("Enable_K_Menu", true);
                        break;
                    }
                case 2:
                    {
                        foreach (var menu in animHandbewegungen1)
                        {
                            menu_item_list.Add(new { Type = 1, Name = menu.hash, Description = "", RightBadge = "none" });
                        }
                        InteractMenu.CreateMenu(player, "PLAY_ANIMATION", "Animation", "~b~ANIMATION: " + objectName, false, JsonConvert.SerializeObject(menu_item_list), false);
                        player.SetData("Enable_K_Menu", true);
                        break;
                    }
                case 3:
                    {
                        foreach (var menu in animSport1)
                        {
                            menu_item_list.Add(new { Type = 1, Name = menu.hash, Description = "", RightBadge = "none" });
                        }
                        InteractMenu.CreateMenu(player, "PLAY_ANIMATION", "Animation", "~b~ANIMATION: " + objectName, false, JsonConvert.SerializeObject(menu_item_list), false);
                        player.SetData("Enable_K_Menu", true);
                        break;
                    }
                case 4:
                    {
                        foreach (var menu in animTanz1)
                        {
                            menu_item_list.Add(new { Type = 1, Name = menu.hash, Description = "", RightBadge = "none" });
                        }
                        InteractMenu.CreateMenu(player, "PLAY_ANIMATION", "Animation", "~b~ANIMATION: " + objectName, false, JsonConvert.SerializeObject(menu_item_list), false);
                        player.SetData("Enable_K_Menu", true);
                        break;
                    }
                case 5:
                    {
                        foreach (var menu in animStehen1)
                        {
                            menu_item_list.Add(new { Type = 1, Name = menu.hash, Description = "", RightBadge = "none" });
                        }
                        InteractMenu.CreateMenu(player, "PLAY_ANIMATION", "Animation", "~b~ANIMATION: " + objectName, false, JsonConvert.SerializeObject(menu_item_list), false);
                        player.SetData("Enable_K_Menu", true);
                        break;
                    }
                case 6:
                    {
                        foreach (var menu in animSitzenBeugen1)
                        {
                            menu_item_list.Add(new { Type = 1, Name = menu.hash, Description = "", RightBadge = "none" });
                        }
                        InteractMenu.CreateMenu(player, "PLAY_ANIMATION", "Animation", "~b~ANIMATION: " + objectName, false, JsonConvert.SerializeObject(menu_item_list), false);
                        player.SetData("Enable_K_Menu", true);
                        break;
                    }
                case 7:
                    {
                        foreach (var menu in animLiegen1)
                        {
                            menu_item_list.Add(new { Type = 1, Name = menu.hash, Description = "", RightBadge = "none" });
                        }
                        InteractMenu.CreateMenu(player, "PLAY_ANIMATION", "Animation", "~b~ANIMATION: " + objectName, false, JsonConvert.SerializeObject(menu_item_list), false);
                        player.SetData("Enable_K_Menu", true);
                        break;
                    }
                case 8:
                    {
                        foreach (var menu in animWeiblich1)
                        {
                            menu_item_list.Add(new { Type = 1, Name = menu.hash, Description = "", RightBadge = "none" });
                        }
                        InteractMenu.CreateMenu(player, "PLAY_ANIMATION", "Animation", "~b~ANIMATION: " + objectName, false, JsonConvert.SerializeObject(menu_item_list), false);
                        player.SetData("Enable_K_Menu", true);
                        break;
                    }
                case 9:
                    {
                        foreach (var menu in animAnlehnen1)
                        {
                            menu_item_list.Add(new { Type = 1, Name = menu.hash, Description = "", RightBadge = "none" });
                        }
                        InteractMenu.CreateMenu(player, "PLAY_ANIMATION", "Animation", "~b~ANIMATION: " + objectName, false, JsonConvert.SerializeObject(menu_item_list), false);
                        player.SetData("Enable_K_Menu", true);
                        break;
                    }
                case 10:
                    {
                        foreach (var menu in animLaufstile1)
                        {
                            menu_item_list.Add(new { Type = 1, Name = menu.hash, Description = "", RightBadge = "none" });
                        }
                        InteractMenu.CreateMenu(player, "PLAY_ANIMATION", "Animation", "~b~ANIMATION: " + objectName, false, JsonConvert.SerializeObject(menu_item_list), false);
                        player.SetData("Enable_K_Menu", true);
                        break;
                    }
                case 11:
                    {
                        foreach (var menu in animPolice1)
                        {
                            menu_item_list.Add(new { Type = 1, Name = menu.hash, Description = "", RightBadge = "none" });
                        }
                        InteractMenu.CreateMenu(player, "PLAY_ANIMATION", "Animation", "~b~ANIMATION: " + objectName, false, JsonConvert.SerializeObject(menu_item_list), false);
                        player.SetData("Enable_K_Menu", true);
                        break;
                    }

            }
        }
        else if (callbackId == "PLAY_ANIMATION")
        {
            foreach (var menu in animAllgemein1)
            {
                if (objectName == menu.hash)
                {
                    OnPlayAnimationFromMenu(player, menu.dict, menu.state, menu.flag);
                    return;
                }
            }
            foreach (var menu in animHandbewegungen1)
            {
                if (objectName == menu.hash)
                {
                    OnPlayAnimationFromMenu(player, menu.dict, menu.state, menu.flag);
                    return;
                }
            }
            foreach (var menu in animSport1)
            {
                if (objectName == menu.hash)
                {
                    OnPlayAnimationFromMenu(player, menu.dict, menu.state, menu.flag);
                    return;
                }
            }
            foreach (var menu in animTanz1)
            {
                if (objectName == menu.hash)
                {
                    OnPlayAnimationFromMenu(player, menu.dict, menu.state, menu.flag);
                    return;
                }
            }
            foreach (var menu in animStehen1)
            {
                if (objectName == menu.hash)
                {
                    OnPlayAnimationFromMenu(player, menu.dict, menu.state, menu.flag);
                    return;
                }
            }
            foreach (var menu in animSitzenBeugen1)
            {
                if (objectName == menu.hash)
                {
                    OnPlayAnimationFromMenu(player, menu.dict, menu.state, menu.flag);
                    return;
                }
            }
            foreach (var menu in animLiegen1)
            {
                if (objectName == menu.hash)
                {
                    OnPlayAnimationFromMenu(player, menu.dict, menu.state, menu.flag);
                    return;
                }
            }
            foreach (var menu in animWeiblich1)
            {
                if (objectName == menu.hash)
                {
                    OnPlayAnimationFromMenu(player, menu.dict, menu.state, menu.flag);
                    return;
                }
            }
            foreach (var menu in animAnlehnen1)
            {
                if (objectName == menu.hash)
                {
                    OnPlayAnimationFromMenu(player, menu.dict, menu.state, menu.flag);
                    return;
                }
            }
            foreach (var menu in animLaufstile1)
            {
                if (objectName == menu.hash)
                {
                    OnPlayAnimationFromMenu(player, menu.dict, menu.state, menu.flag);
                    return;
                }
            }

            foreach (var menu in animPolice1)
            {
                if (objectName == menu.hash)
                {
                    OnPlayAnimationFromMenu(player, menu.dict, menu.state, menu.flag);
                    return;
                }
            }


        }
        else if(callbackId == "ANIMATION_MENU_SHORTCUT_ADD")
        {
            string dict = player.GetData("animation_dict");
            string state = player.GetData("animation_state");
            int flag = player.GetData("animation_flag");

            if(dict == "")
            {
                return;
            }

            player.SetData("animation_shortcut_dict_" + selectedIndex, dict);
            player.SetData("animation_shortcut_state_" + selectedIndex, state);
            player.SetData("animation_shortcut_flag_" + selectedIndex, flag);

            SaveShortcut(player);
        }
    }


    public static void SaveShortcut(Client player)
    {
        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {
            Mainpipeline.Open();
            try
            {
                string query = "UPDATE characters SET shortcut_0 = @shortcut_0, shortcut_1 = @shortcut_1, shortcut_2 = @shortcut_2, shortcut_3 = @shortcut_3, shortcut_4 = @shortcut_4, shortcut_5 = @shortcut_5, shortcut_6 = @shortcut_6, shortcut_7 = @shortcut_7, shortcut_8 = @shortcut_8, shortcut_9 = @shortcut_9 WHERE `id` = '" + AccountManage.GetPlayerSQLID(player) + "'";
                MySqlCommand myCommand = new MySqlCommand(query, Mainpipeline);

                string shortcut_0 = player.GetData("animation_shortcut_dict_0") + "|" + player.GetData("animation_shortcut_state_0") + "|" + player.GetData("animation_shortcut_flag_0");
                string shortcut_1 = player.GetData("animation_shortcut_dict_1") + "|" + player.GetData("animation_shortcut_state_1") + "|" + player.GetData("animation_shortcut_flag_1");
                string shortcut_2 = player.GetData("animation_shortcut_dict_2") + "|" + player.GetData("animation_shortcut_state_2") + "|" + player.GetData("animation_shortcut_flag_2");
                string shortcut_3 = player.GetData("animation_shortcut_dict_3") + "|" + player.GetData("animation_shortcut_state_3") + "|" + player.GetData("animation_shortcut_flag_3");
                string shortcut_4 = player.GetData("animation_shortcut_dict_4") + "|" + player.GetData("animation_shortcut_state_4") + "|" + player.GetData("animation_shortcut_flag_4");
                string shortcut_5 = player.GetData("animation_shortcut_dict_5") + "|" + player.GetData("animation_shortcut_state_5") + "|" + player.GetData("animation_shortcut_flag_5");
                string shortcut_6 = player.GetData("animation_shortcut_dict_6") + "|" + player.GetData("animation_shortcut_state_6") + "|" + player.GetData("animation_shortcut_flag_6");
                string shortcut_7 = player.GetData("animation_shortcut_dict_7") + "|" + player.GetData("animation_shortcut_state_7") + "|" + player.GetData("animation_shortcut_flag_7");
                string shortcut_8 = player.GetData("animation_shortcut_dict_8") + "|" + player.GetData("animation_shortcut_state_8") + "|" + player.GetData("animation_shortcut_flag_8");
                string shortcut_9 = player.GetData("animation_shortcut_dict_9") + "|" + player.GetData("animation_shortcut_state_9") + "|" + player.GetData("animation_shortcut_flag_9");


                myCommand.Parameters.AddWithValue("@shortcut_0", "" + shortcut_0 + "");
                myCommand.Parameters.AddWithValue("@shortcut_1", "" + shortcut_1 + "");
                myCommand.Parameters.AddWithValue("@shortcut_2", "" + shortcut_2 + "");
                myCommand.Parameters.AddWithValue("@shortcut_3", "" + shortcut_3 + "");
                myCommand.Parameters.AddWithValue("@shortcut_4", "" + shortcut_4 + "");
                myCommand.Parameters.AddWithValue("@shortcut_5", "" + shortcut_5 + "");
                myCommand.Parameters.AddWithValue("@shortcut_6", "" + shortcut_6 + "");
                myCommand.Parameters.AddWithValue("@shortcut_7", "" + shortcut_7 + "");
                myCommand.Parameters.AddWithValue("@shortcut_8", "" + shortcut_8 + "");
                myCommand.Parameters.AddWithValue("@shortcut_9", "" + shortcut_9 + "");



                myCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {
                //NAPI.Util.ConsoleOutput("[EXCEPTION SaveShortCut] " + ex.Message);
                //NAPI.Util.ConsoleOutput("[EXCEPTION SaveShortCut] " + ex.StackTrace);
            }
        }
    }

    public static void IndexChangeMenuResponse(Client player, String callbackId, int selectedIndex, String objectName, String valueList)
    {
        if (callbackId == "PLAY_ANIMATION")
        {
            foreach (var menu in animAllgemein1)
            {
                if (objectName == menu.hash)
                {
                    AddVariable(player, menu.dict, menu.state, menu.flag);
                    return;
                }
            }
            foreach (var menu in animHandbewegungen1)
            {
                if (objectName == menu.hash)
                {
                    AddVariable(player, menu.dict, menu.state, menu.flag);
                    return;
                }
            }
            foreach (var menu in animSport1)
            {
                if (objectName == menu.hash)
                {
                    AddVariable(player, menu.dict, menu.state, menu.flag);
                    return;
                }
            }
            foreach (var menu in animTanz1)
            {
                if (objectName == menu.hash)
                {
                    AddVariable(player, menu.dict, menu.state, menu.flag);
                    return;
                }
            }
            foreach (var menu in animStehen1)
            {
                if (objectName == menu.hash)
                {
                    AddVariable(player, menu.dict, menu.state, menu.flag);
                    return;
                }
            }
            foreach (var menu in animSitzenBeugen1)
            {
                if (objectName == menu.hash)
                {
                    AddVariable(player, menu.dict, menu.state, menu.flag);
                    return;
                }
            }
            foreach (var menu in animLiegen1)
            {
                if (objectName == menu.hash)
                {
                    AddVariable(player, menu.dict, menu.state, menu.flag);
                    return;
                }
            }
            foreach (var menu in animWeiblich1)
            {
                if (objectName == menu.hash)
                {
                    AddVariable(player, menu.dict, menu.state, menu.flag);
                    return;
                }
            }
            foreach (var menu in animAnlehnen1)
            {
                if (objectName == menu.hash)
                {
                    AddVariable(player, menu.dict, menu.state, menu.flag);
                    return;
                }
            }
            foreach (var menu in animLaufstile1)
            {
                if (objectName == menu.hash)
                {
                    AddVariable(player, menu.dict, menu.state, menu.flag);
                    return;
                }
            }

            foreach (var menu in animPolice1)
            {
                if (objectName == menu.hash)
                {
                    AddVariable(player, menu.dict, menu.state, menu.flag);
                    return;
                }
            }


        }
    }

    [RemoteEvent("DisplayInfoAnimationShot")]
    public static void DisplayInfoAnimationShot(Client player)
    {
        if (player.GetData("Enable_K_Menu") == false)
        {
            return;
        }

        InteractMenu.CloseDynamicMenu(player);
        List<dynamic> menu_item_list = new List<dynamic>();

        for(int i = 0; i < 10; i ++)
        {
            if(player.GetData("animation_shortcut_dict_"+ i) != "")
            {
                menu_item_list.Add(new { Type = 1, Name = "CTRL + " + i, Description = "Wählen Sie zum Ersetzen aus!", RightLabel = "Im Einsatz" });
            }
            else
            {
                menu_item_list.Add(new { Type = 1, Name = "CTRL + " + i, Description = "Wählen Sie aus, um diesen Slot zu verwenden!", RightLabel = "~c~Benutzen" });
            }
        }

        InteractMenu.CreateMenu(player, "ANIMATION_MENU_SHORTCUT_ADD", "Animation", "~b~ANIMATIONSSYSTEM - Verknüpfungen", false, JsonConvert.SerializeObject(menu_item_list), false);
    }

    [RemoteEvent("animationMenuVariableOff")]
    public static void animationMenuVariableOff(Client player)
    {
        player.SetSharedData("Enable_K_Menu", false);
    }

    [RemoteEvent("keypress:0")]
    public static void KeyPress0(Client player)
    {
        int number = 0;

        string dict = player.GetData("animation_shortcut_dict_" + number);
        string state = player.GetData("animation_shortcut_state_" + number);
        int flag = player.GetData("animation_shortcut_flag_" + number);

        if(dict == "")
        {
            return;
        }

        OnPlayAnimationFromMenu(player, dict, state, flag);
    }
    

    [RemoteEvent("keypress:1")]
    public static void KeyPress1(Client player)
    {
        int number = 1;

        string dict = player.GetData("animation_shortcut_dict_" + number);
        string state = player.GetData("animation_shortcut_state_" + number);
        int flag = player.GetData("animation_shortcut_flag_" + number);

        if(dict == "")
        {
            return;
        }

        OnPlayAnimationFromMenu(player, dict, state, flag);
    }
    

    [RemoteEvent("keypress:2")]
    public static void KeyPress2(Client player)
    {
        int number = 2;

        string dict = player.GetData("animation_shortcut_dict_" + number);
        string state = player.GetData("animation_shortcut_state_" + number);
        int flag = player.GetData("animation_shortcut_flag_" + number);

        if(dict == "")
        {
            return;
        }

        OnPlayAnimationFromMenu(player, dict, state, flag);
    }
    

    [RemoteEvent("keypress:3")]
    public static void KeyPress3(Client player)
    {
        int number = 3;

        string dict = player.GetData("animation_shortcut_dict_" + number);
        string state = player.GetData("animation_shortcut_state_" + number);
        int flag = player.GetData("animation_shortcut_flag_" + number);

        if(dict == "")
        {
            return;
        }

        OnPlayAnimationFromMenu(player, dict, state, flag);
    }
    

    [RemoteEvent("keypress:4")]
    public static void KeyPress4(Client player)
    {
        int number = 4;

        string dict = player.GetData("animation_shortcut_dict_" + number);
        string state = player.GetData("animation_shortcut_state_" + number);
        int flag = player.GetData("animation_shortcut_flag_" + number);

        if(dict == "")
        {
            return;
        }

        OnPlayAnimationFromMenu(player, dict, state, flag);
    }
    

    [RemoteEvent("keypress:5")]
    public static void KeyPress5(Client player)
    {
        int number = 5;

        string dict = player.GetData("animation_shortcut_dict_" + number);
        string state = player.GetData("animation_shortcut_state_" + number);
        int flag = player.GetData("animation_shortcut_flag_" + number);

        if(dict == "")
        {
            return;
        }

        OnPlayAnimationFromMenu(player, dict, state, flag);
    }
    

    [RemoteEvent("keypress:6")]
    public static void KeyPress6(Client player)
    {
        int number = 6;

        string dict = player.GetData("animation_shortcut_dict_" + number);
        string state = player.GetData("animation_shortcut_state_" + number);
        int flag = player.GetData("animation_shortcut_flag_" + number);

        if(dict == "")
        {
            return;
        }

        OnPlayAnimationFromMenu(player, dict, state, flag);
    }
    

    [RemoteEvent("keypress:7")]
    public static void KeyPress7(Client player)
    {
        int number = 7;

        string dict = player.GetData("animation_shortcut_dict_" + number);
        string state = player.GetData("animation_shortcut_state_" + number);
        int flag = player.GetData("animation_shortcut_flag_" + number);

        if(dict == "")
        {
            return;
        }

        OnPlayAnimationFromMenu(player, dict, state, flag);
    }
    

    [RemoteEvent("keypress:8")]
    public static void KeyPress8(Client player)
    {
  
        int number = 8;

        string dict = player.GetData("animation_shortcut_dict_" + number);
        string state = player.GetData("animation_shortcut_state_" + number);
        int flag = player.GetData("animation_shortcut_flag_" + number);

        if(dict == "")
        {
            return;
        }

        OnPlayAnimationFromMenu(player, dict, state, flag);
    }
    

    [RemoteEvent("keypress:9")]
    public static void KeyPress9(Client player)
    {
        if (player.GetData("status") == false)
        {
            return;
        }

        if (AccountManage.GetPlayerAdmin(player) < 2)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben keine Berechtigung, diesen Befehl zu verwenden .");
            return;
        }

        BannedManage.Bannedlist(player);
    }

    public static void AddVariable(Client player, string dict, string state, int flag)
    {
        player.SetData("animation_dict", dict);
        player.SetData("animation_state", state);
        player.SetData("animation_flag", flag);
       // NAPI.Notification.SendNotificationToPlayer(player,""+dict+" -- "+state+" -- "+flag+"");
        //player.PlayAnimation(dict, state, flag);
    }


    [Command("anim")]
    public void CMD_anim(Client player)
    {
        player.TriggerEvent("Display_Animation");
    }

    //Display_Animation
    [Command("pararanim")]
    public void StopAaa(Client player)
    {
        if (NAPI.Data.GetEntityData(player, "Injured") != 0 || player.GetData("handsup") == true || player.GetData("playerCuffed") != 0 || player.GetData("SendoArrastado") == true)
        {
            Main.DisplayErrorMessage(player, "Animation konnte nicht ausgeführt werden.");
            return;
        }
        player.StopAnimation();
    }

    [Command("grab")]
    public void GrabCommand(Client player)
    {
         if (NAPI.Data.GetEntityData(player, "Injured") != 0 || player.GetData("handsup") == true || player.GetData("playerCuffed") != 0 || player.GetData("SendoArrastado") == true)
        {
            Main.DisplayErrorMessage(player, "Animation konnte nicht ausgeführt werden.");
        }
        else
        {
            player.StopAnimation();
            NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "anim@heists@money_grab@duffel", "loop");
        }
    }

    [Command("facepalm")]
    public void FacepalmCommand(Client player)
    {
         if (NAPI.Data.GetEntityData(player, "Injured") != 0 || player.GetData("handsup") == true || player.GetData("playerCuffed") != 0 || player.GetData("SendoArrastado") == true)
        {
            Main.DisplayErrorMessage(player, "Animation konnte nicht ausgeführt werden.");
        }
        else
        {
            player.StopAnimation();
            NAPI.Player.PlayPlayerAnimation(player, 0, "anim@mp_player_intcelebrationmale@face_palm", "face_palm");
        }
    }

    [Command("loco")]
    public void LocoCommand(Client player)
    {
        if (NAPI.Data.GetEntityData(player, "Injured") != 0 || player.GetData("handsup") == true || player.GetData("playerCuffed") != 0 || player.GetData("SendoArrastado") == true)
        {
            Main.DisplayErrorMessage(player, "Animation konnte nicht ausgeführt werden.");
        }
        else
        {
            player.StopAnimation();
            NAPI.Player.PlayPlayerAnimation(player, 0, "anim@mp_player_intcelebrationmale@you_loco", "you_loco");
        }
    }

    [Command("freakout")]
    public void FreakoutCommand(Client player)
    {
         if (NAPI.Data.GetEntityData(player, "Injured") != 0 || player.GetData("handsup") == true || player.GetData("playerCuffed") != 0 || player.GetData("SendoArrastado") == true)
        {
            Main.DisplayErrorMessage(player, "Animation konnte nicht ausgeführt werden.");
        }
        else
        {
            player.StopAnimation();
            NAPI.Player.PlayPlayerAnimation(player, 0, "anim@mp_player_intcelebrationmale@freakout", "freakout");
        }
    }

    [Command("thumb")]
    public void ThumbOnEarsCommand(Client player)
    {
         if (NAPI.Data.GetEntityData(player, "Injured") != 0 || player.GetData("handsup") == true || player.GetData("playerCuffed") != 0 || player.GetData("SendoArrastado") == true)
        {
            Main.DisplayErrorMessage(player, "Animation konnte nicht ausgeführt werden.");
        }
        else
        {
            player.StopAnimation();
            NAPI.Player.PlayPlayerAnimation(player, 0, "anim@mp_player_intcelebrationmale@thumb_on_ears", "thumb_on_ears");
        }
    }

    [Command("victory")]
    public void VictoryCommand(Client player)
    {
         if (NAPI.Data.GetEntityData(player, "Injured") != 0 || player.GetData("handsup") == true || player.GetData("playerCuffed") != 0 || player.GetData("SendoArrastado") == true)
        {
            Main.DisplayErrorMessage(player, "Animation konnte nicht ausgeführt werden.");
        }
        else
        {
            player.StopAnimation();
            NAPI.Player.PlayPlayerAnimation(player, 0, "anim@mp_player_intcelebrationmale@v_sign", "v_sign");
        }
    }

    [Command("crouch")]
    public void CrouchCommand(Client player)
    {
         if (NAPI.Data.GetEntityData(player, "Injured") != 0 || player.GetData("handsup") == true || player.GetData("playerCuffed") != 0 || player.GetData("SendoArrastado") == true)
        {
            Main.DisplayErrorMessage(player, "Animation konnte nicht ausgeführt werden.");
        }
        else
        {
            player.StopAnimation();
            NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "misscarstealfinalecar_5_ig_3", "crouchloop");
        }
    }

    [Command("dj")]
    public void DjCommand(Client player)
    {
         if (NAPI.Data.GetEntityData(player, "Injured") != 0 || player.GetData("handsup") == true || player.GetData("playerCuffed") != 0 || player.GetData("SendoArrastado") == true)
        {
            Main.DisplayErrorMessage(player, "Animation konnte nicht ausgeführt werden.");
        }
        else
        {
            player.StopAnimation();
            NAPI.Player.PlayPlayerAnimation(player, 0, "anim@mp_player_intupperdj", "enter");
        }
    }

    [Command("kneel")]
    public void KneelCommand(Client player)
    {
         if (NAPI.Data.GetEntityData(player, "Injured") != 0 || player.GetData("handsup") == true || player.GetData("playerCuffed") != 0 || player.GetData("SendoArrastado") == true)
        {
            Main.DisplayErrorMessage(player, "Animation konnte nicht ausgeführt werden.");
        }
        else
        {
            player.StopAnimation();
            NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "amb@medic@standing@kneel@base", "base");
        }
    }

    [Command("speak")]
    public void SpeakCommand(Client player)
    {
         if (NAPI.Data.GetEntityData(player, "Injured") != 0 || player.GetData("handsup") == true || player.GetData("playerCuffed") != 0 || player.GetData("SendoArrastado") == true)
        {
            Main.DisplayErrorMessage(player, "Animation konnte nicht ausgeführt werden.");
        }
        else
        {
            player.StopAnimation();
            NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "amb@code_human_police_crowd_control@idle_a", "idle_b");
        }
    }

    [Command("mechanic", "~y~Verwendungsart:~w~ /mechanic [1 a 3]")]
    public void MechanicCommand(Client player, int action)
    {
         if (NAPI.Data.GetEntityData(player, "Injured") != 0 || player.GetData("handsup") == true || player.GetData("playerCuffed") != 0 || player.GetData("SendoArrastado") == true)
        {
            Main.DisplayErrorMessage(player, "Animation konnte nicht ausgeführt werden.");
        }
        else
        {
            switch (action)
            {
                case 1:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "amb@world_human_vehicle_mechanic@male@idle_a", "idle_a");
                    break;
                case 2:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "mini@repair", "fixing_a_ped");
                    break;
                case 3:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "missheistdockssetup1ig_10@laugh", "laugh_pipe_worker1");
                    break;
                default:
                    NAPI.Notification.SendNotificationToPlayer(player, "~y~Verwendungsart:~w~ /mechanic [1 a 3]");
                    break;
            }
        }
    }

    [Command("dig")]
    public void DigCommand(Client player)
    {
         if (NAPI.Data.GetEntityData(player, "Injured") != 0 || player.GetData("handsup") == true || player.GetData("playerCuffed") != 0 || player.GetData("SendoArrastado") == true)
        {
            Main.DisplayErrorMessage(player, "Animation konnte nicht ausgeführt werden.");
        }
        else
        {
            player.StopAnimation();
            NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "missmic1leadinoutmic_1_mcs_2", "_leadin_trevor");
        }
    }

    [Command("cry")]
    public void CryCommand(Client player)
    {
         if (NAPI.Data.GetEntityData(player, "Injured") != 0 || player.GetData("handsup") == true || player.GetData("playerCuffed") != 0 || player.GetData("SendoArrastado") == true)
        {
            Main.DisplayErrorMessage(player, "Animation konnte nicht ausgeführt werden.");
        }
        else
        {
            player.StopAnimation();
            NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "mp_bank_heist_1", "f_cower_01");
        }
    }

    [Command("clean", "~y~Verwendungsart:~w~ /clean [1 a 5]")]
    public void CleanCommand(Client player, int action)
    {
         if (NAPI.Data.GetEntityData(player, "Injured") != 0 || player.GetData("handsup") == true || player.GetData("playerCuffed") != 0 || player.GetData("SendoArrastado") == true)
        {
            Main.DisplayErrorMessage(player, "Animation konnte nicht ausgeführt werden.");
        }
        else
        {
            switch (action)
            {
                case 1:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "switch@franklin@cleaning_car", "001946_01_gc_fras_v2_ig_5_base");
                    break;
                case 2:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "timetable@maid@cleaning_window@base", "base");
                    break;
                case 3:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "missheistdocks2bleadinoutlsdh_2b_int", "leg_massage_b_floyd");
                    break;
                case 4:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "missfbi_s4mop", "idle_scrub");
                    break;
                case 5:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "amb@world_human_bum_wash@male@low@idle_a", "idle_c");
                    break;
                default:
                    NAPI.Notification.SendNotificationToPlayer(player, "~y~Verwendungsart: ~w~/clean [1 a 5]");
                    break;
            }
        }
    }

    [Command("shower", "~y~Verwendungsart: ~w~/shower [1 a 2]")]
    public void ShowerCommand(Client player, int action)
    {
         if (NAPI.Data.GetEntityData(player, "Injured") != 0 || player.GetData("handsup") == true || player.GetData("playerCuffed") != 0 || player.GetData("SendoArrastado") == true)
        {
            Main.DisplayErrorMessage(player, "Animation konnte nicht ausgeführt werden.");
        }
        else
        {
            switch (action)
            {
                case 1:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "anim@mp_yacht@shower@male@", "male_shower_idle_d");
                    break;
                case 2:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "anim@mp_yacht@shower@female@", "shower_idle_a");
                    break;
                default:
                    NAPI.Notification.SendNotificationToPlayer(player, "~y~Verwendungsart: ~w~/shower [1 a 2]");
                    break;
            }
        }
    }

    [Command("hurryup")]
    public void HurryUpCommand(Client player)
    {
         if (NAPI.Data.GetEntityData(player, "Injured") != 0 || player.GetData("handsup") == true || player.GetData("playerCuffed") != 0 || player.GetData("SendoArrastado") == true)
        {
            Main.DisplayErrorMessage(player, "Animation konnte nicht ausgeführt werden.");
        }
        else
        {
            player.StopAnimation();
            NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "missfam4", "say_hurry_up_a_trevor");
        }
    }

    [Command("sports", "~y~Verwendungsart: ~w~/sports [1 a 15]")]
    public void SportsCommand(Client player, int action)
    {
         if (NAPI.Data.GetEntityData(player, "Injured") != 0 || player.GetData("handsup") == true || player.GetData("playerCuffed") != 0 || player.GetData("SendoArrastado") == true)
        {
            Main.DisplayErrorMessage(player, "Animation konnte nicht ausgeführt werden.");
        }
        else
        {
            switch (action)
            {
                case 1:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop | AnimationFlags.AllowPlayerControl), "rcmcollect_paperleadinout@", "meditiate_idle");
                    break;
                case 2:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "timetable@reunited@ig_2", "jimmy_masterbation");
                    break;
                case 3:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "timetable@reunited@ig_2", "jimmy_base");
                    break;
                case 4:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop | AnimationFlags.AllowPlayerControl), "move_m@jog@", "run");
                    break;
                case 5:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop | AnimationFlags.AllowPlayerControl), "move_f@jogger", "jogging");
                    break;
                case 6:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop | AnimationFlags.AllowPlayerControl), "amb@world_human_jog@female@base", "base");
                    break;
                case 7:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "mini@triathlon", "idle_a");
                    break;
                case 8:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "mini@triathlon", "idle_d");
                    break;
                case 9:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "mini@triathlon", "idle_e");
                    break;
                case 10:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "mini@triathlon", "idle_f");
                    break;
                case 11:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "amb@world_human_yoga@female@base", "base_a");
                    break;
                case 12:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "amb@world_human_yoga@female@base", "base_c");
                    break;
                case 13:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "amb@world_human_yoga@male@base", "base_b");
                    break;
                case 14:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "amb@world_human_push_ups@male@idle_a", "idle_d");
                    break;
                case 15:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "amb@world_human_sit_ups@male@base", "base");
                    break;
                default:
                    NAPI.Notification.SendNotificationToPlayer(player, "~y~Verwendungsart: ~w~/sports [1 a 15]");
                    break;
            }
        }
    }

    [Command("type")]
    public void TypeCommand(Client player)
    {
         if (NAPI.Data.GetEntityData(player, "Injured") != 0 || player.GetData("handsup") == true || player.GetData("playerCuffed") != 0 || player.GetData("SendoArrastado") == true)
        {
            Main.DisplayErrorMessage(player, "Animation konnte nicht ausgeführt werden.");
        }
        else
        {
            player.StopAnimation();
            NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "mp_fbi_heist", "loop");
        }
    }

    [Command("knockdoor")]
    public void KnockDoorCommand(Client player)
    {
         if (NAPI.Data.GetEntityData(player, "Injured") != 0 || player.GetData("handsup") == true || player.GetData("playerCuffed") != 0 || player.GetData("SendoArrastado") == true)
        {
            Main.DisplayErrorMessage(player, "Animation konnte nicht ausgeführt werden.");
        }
        else
        {
            player.StopAnimation();
            NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "timetable@jimmy@doorknock@", "knockdoor_idle");
        }
    }

    [Command("tagging")]
    public void TaggingCommand(Client player)
    {
         if (NAPI.Data.GetEntityData(player, "Injured") != 0 || player.GetData("handsup") == true || player.GetData("playerCuffed") != 0 || player.GetData("SendoArrastado") == true)
        {
            Main.DisplayErrorMessage(player, "Animation konnte nicht ausgeführt werden.");
        }
        else
        {
            player.StopAnimation();
            NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "switch@franklin@lamar_tagging_wall", "lamar_tagging_exit_loop_lamar");
        }
    }

    [Command("striptease", "~y~Verwendungsart: ~w~/striptease [1 a 14]")]
    public void StripteaseCommand(Client player, int action)
    {
         if (NAPI.Data.GetEntityData(player, "Injured") != 0 || player.GetData("handsup") == true || player.GetData("playerCuffed") != 0 || player.GetData("SendoArrastado") == true)
        {
            Main.DisplayErrorMessage(player, "Animation konnte nicht ausgeführt werden.");
        }
        else
        {
            switch (action)
            {
                case 1:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.StopOnLastFrame), "mini@strip_club@pole_dance@pole_a_2_stage", "pole_a_2_stage");
                    break;
                case 2:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.StopOnLastFrame), "mini@strip_club@pole_dance@pole_b_2_stage", "pole_b_2_stage");
                    break;
                case 3:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.StopOnLastFrame), "mini@strip_club@pole_dance@pole_c_2_prvd_a", "pole_c_2_prvd_a");
                    break;
                case 4:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.StopOnLastFrame), "mini@strip_club@pole_dance@pole_c_2_prvd_b", "pole_c_2_prvd_b");
                    break;
                case 5:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "mini@hookers_spcrackhead", "idle_b");
                    break;
                case 6:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.StopOnLastFrame), "mini@strip_club@pole_dance@pole_c_2_prvd_c", "pole_c_2_prvd_c");
                    break;
                case 7:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "mini@strip_club@pole_dance@pole_dance1", "pd_dance_01");
                    break;
                case 8:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "mini@strip_club@pole_dance@pole_dance2", "pd_dance_02");
                    break;
                case 9:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "mini@strip_club@pole_dance@pole_dance3", "pd_dance_03");
                    break;
                case 10:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "mini@strip_club@pole_dance@pole_enter", "pd_enter");
                    break;
                case 11:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "mini@strip_club@pole_dance@pole_exit", "pd_exit");
                    break;
                case 12:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "mini@strip_club@private_dance@exit", "priv_dance_exit");
                    break;
                case 13:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "mini@strip_club@private_dance@idle", "priv_dance_idle");
                    break;
                case 14:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "mp_am_stripper", "lap_dance_girl");
                    break;
                default:
                    NAPI.Notification.SendNotificationToPlayer(player, "~y~Verwendungsart: ~w~/striptease [1 a 14]");
                    break;
            }
        }
    }

    [Command("drink")]
    public void DrinkCommand(Client player)
    {
         if (NAPI.Data.GetEntityData(player, "Injured") != 0 || player.GetData("handsup") == true || player.GetData("playerCuffed") != 0 || player.GetData("SendoArrastado") == true)
        {
            Main.DisplayErrorMessage(player, "Animation konnte nicht ausgeführt werden.");
        }
        else
        {
            player.StopAnimation();
            NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop | AnimationFlags.AllowPlayerControl), "amb@world_human_drinking_fat@beer@male@idle_a", "idle_a");
        }
    }

    [Command("kiss")]
    public void KissCommand(Client player, int action)
    {
         if (NAPI.Data.GetEntityData(player, "Injured") != 0 || player.GetData("handsup") == true || player.GetData("playerCuffed") != 0 || player.GetData("SendoArrastado") == true)
        {
            Main.DisplayErrorMessage(player, "Animation konnte nicht ausgeführt werden.");
        }
        else
        {
            player.StopAnimation();
            NAPI.Player.PlayPlayerAnimation(player, 0, "mini@hookers_sp", "idle_a");
        }
    }

    [Command("aim")]
    public void AimCommand(Client player, int action)
    {
         if (NAPI.Data.GetEntityData(player, "Injured") != 0 || player.GetData("handsup") == true || player.GetData("playerCuffed") != 0 || player.GetData("SendoArrastado") == true)
        {
            Main.DisplayErrorMessage(player, "Animation konnte nicht ausgeführt werden.");
        }
        else
        {
            player.StopAnimation();
            NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "combat@chg_stance", "aima_loop");
        }
    }

    [Command("salute", "~y~Verwendungsart: ~w~/salute [1 a 6]")]
    public void SaluteCommand(Client player, int action)
    {
         if (NAPI.Data.GetEntityData(player, "Injured") != 0 || player.GetData("handsup") == true || player.GetData("playerCuffed") != 0 || player.GetData("SendoArrastado") == true)
        {
            Main.DisplayErrorMessage(player, "Animation konnte nicht ausgeführt werden.");
        }
        else
        {
            switch (action)
            {
                case 1:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "mp_player_int_uppersalute", "mp_player_int_salute");
                    break;
                case 2:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, 0, "mp_ped_interaction", "hugs_guy_a");
                    break;
                case 3:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, 0, "mp_player_intsalute", "mp_player_int_salute");
                    break;
                case 4:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "missmic4premiere", "crowd_a_idle_01");
                    break;
                case 5:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "missexile2", "franklinwavetohelicopter");
                    break;
                case 6:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, 0, "anim@mp_player_intcelebrationmale@wave", "wave");
                    break;
                default:
                    player.StopAnimation();
                    NAPI.Notification.SendNotificationToPlayer(player, "~y~Verwendungsart: ~w~/salute [1 a 6]");
                    break;
            }
        }
    }

    [Command("fucku")]
    public void FuckUCommand(Client player)
    {
         if (NAPI.Data.GetEntityData(player, "Injured") != 0 || player.GetData("handsup") == true || player.GetData("playerCuffed") != 0 || player.GetData("SendoArrastado") == true)
        {
            Main.DisplayErrorMessage(player, "Animation konnte nicht ausgeführt werden.");
        }
        else
        {
            player.StopAnimation();
            NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop | AnimationFlags.AllowPlayerControl | AnimationFlags.OnlyAnimateUpperBody), "anim@mp_player_intselfiethe_bird", "idle_a");
        }
    }

    [Command("walk", "~y~Verwendungsart: ~w~/walk [1 a 21]")]
    public void WalkCommand(Client player, int action)
    {
         if (NAPI.Data.GetEntityData(player, "Injured") != 0 || player.GetData("handsup") == true || player.GetData("playerCuffed") != 0 || player.GetData("SendoArrastado") == true)
        {
            Main.DisplayErrorMessage(player, "Animation konnte nicht ausgeführt werden.");
        }
        else
        {
            switch (action)
            {
                case 1:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop | AnimationFlags.AllowPlayerControl), "move_f@heels@c", "walk");
                    break;
                case 2:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop | AnimationFlags.AllowPlayerControl), "move_f@arrogant@a", "walk");
                    break;
                case 3:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop | AnimationFlags.AllowPlayerControl), "move_f@sad@a", "walk");
                    break;
                case 4:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop | AnimationFlags.AllowPlayerControl), "move_m@drunk@moderatedrunk", "walk");
                    break;
                case 5:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop | AnimationFlags.AllowPlayerControl), "move_m@shadyped@a", "walk");
                    break;
                case 6:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop | AnimationFlags.AllowPlayerControl), "move_f@gangster@ng", "walk");
                    break;
                case 7:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop | AnimationFlags.AllowPlayerControl), "move_f@generic", "walk");
                    break;
                case 8:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop | AnimationFlags.AllowPlayerControl), "move_f@heels@d", "walk");
                    break;
                case 9:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop | AnimationFlags.AllowPlayerControl), "move_f@posh@", "walk");
                    break;
                case 10:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop | AnimationFlags.AllowPlayerControl), "move_m@brave@b", "walk");
                    break;
                case 11:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop | AnimationFlags.AllowPlayerControl), "move_m@confident", "walk");
                    break;
                case 12:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop | AnimationFlags.AllowPlayerControl), "move_m@depressed@d", "walk");
                    break;
                case 13:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop | AnimationFlags.AllowPlayerControl), "move_m@favor_right_foot", "walk");
                    break;
                case 14:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop | AnimationFlags.AllowPlayerControl), "move_m@generic", "walk");
                    break;
                case 15:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop | AnimationFlags.AllowPlayerControl), "move_m@generic_variations@walk", "walk_a");
                    break;
                case 16:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop | AnimationFlags.AllowPlayerControl), "move_m@generic_variations@walk", "walk_f");
                    break;
                case 17:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop | AnimationFlags.AllowPlayerControl), "move_m@golfer@", "golf_walk");
                    break;
                case 18:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop | AnimationFlags.AllowPlayerControl), "move_m@money", "walk");
                    break;
                case 19:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop | AnimationFlags.AllowPlayerControl), "move_m@shadyped@a", "walk");
                    break;
                case 20:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop | AnimationFlags.AllowPlayerControl), "move_m@swagger@b", "walk");
                    break;
                case 21:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop | AnimationFlags.AllowPlayerControl), "switch@franklin@dispensary", "exit_dispensary_outro_ped_f_a");
                    break;
                default:
                    NAPI.Notification.SendNotificationToPlayer(player, "~y~Verwendungsart: ~w~/walk [1 a 21]");
                    break;
            }
        }
    }

    [Command("knuckles")]
    public void KnucklesCommand(Client player)
    {
         if (NAPI.Data.GetEntityData(player, "Injured") != 0 || player.GetData("handsup") == true || player.GetData("playerCuffed") != 0 || player.GetData("SendoArrastado") == true)
        {
            Main.DisplayErrorMessage(player, "Animation konnte nicht ausgeführt werden.");
        }
        else
        {
            player.StopAnimation();
            NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop | AnimationFlags.AllowPlayerControl | AnimationFlags.OnlyAnimateUpperBody), "anim@mp_player_intupperknuckle_crunch", "idle_a");
        }
    }

    [Command("surrender", "~y~Verwendungsart: ~w~/surrender [1 a 11]")]
    public static void SurrenderCommands(Client player, int action)
    {
        if (NAPI.Data.GetEntityData(player, "Injured") != 0 || player.GetData("handsup") == true || player.GetData("playerCuffed") != 0 || player.GetData("SendoArrastado") == true)
        {
            Main.DisplayErrorMessage(player, "Animation konnte nicht ausgeführt werden.");
        }
        else
        {
            if(action >= 1 && action <= 11)
            {
                player.SetData("handsup", true);
            }
            switch (action)
            {
                case 1:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop | AnimationFlags.AllowPlayerControl | AnimationFlags.OnlyAnimateUpperBody), "mp_am_hold_up", "handsup_base");
                    break;
                case 2:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop | AnimationFlags.AllowPlayerControl | AnimationFlags.OnlyAnimateUpperBody), "anim@mp_player_intuppersurrender", "idle_a_fp");
                    break;
                case 3:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop | AnimationFlags.AllowPlayerControl | AnimationFlags.OnlyAnimateUpperBody), "amb@code_human_cower@female@react_cowering", "base_back_left");
                    break;
                case 4:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop | AnimationFlags.AllowPlayerControl | AnimationFlags.OnlyAnimateUpperBody), "amb@code_human_cower@female@react_cowering", "base_right");
                    break;
                case 5:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "missfbi5ig_0", "lyinginpain_loop_steve");
                    break;
                case 6:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "missfbi5ig_10", "lift_holdup_loop_labped");
                    break;
                case 7:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "missfbi5ig_17", "walk_in_aim_loop_scientista");
                    break;
                case 8:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "mp_am_hold_up", "cower_loop");
                    break;
                case 9:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "mp_arrest_paired", "crook_p1_idle");
                    break;
                case 10:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "mp_bank_heist_1", "m_cower_02");
                    break;
                case 11:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "misstrevor1", "threaten_ortega_endloop_ort");
                    break;
                default:
                    NAPI.Notification.SendNotificationToPlayer(player, "~y~Verwendungsart: ~w~/surrender [1 a 11]");
                    break;
            }
        }
    }

    [Command("eat")]
    public void EatCommand(Client player)
    {
         if (NAPI.Data.GetEntityData(player, "Injured") != 0 || player.GetData("handsup") == true || player.GetData("playerCuffed") != 0 || player.GetData("SendoArrastado") == true)
        {
            Main.DisplayErrorMessage(player, "Animation konnte nicht ausgeführt werden.");
        }
        else
        {
            player.StopAnimation();
            NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop | AnimationFlags.AllowPlayerControl | AnimationFlags.OnlyAnimateUpperBody), "mp_player_inteat@burger", "mp_player_int_eat_burger");
        }
    }

    [Command("puke")]
    public void PukeCommand(Client player)
    {
         if (NAPI.Data.GetEntityData(player, "Injured") != 0 || player.GetData("handsup") == true || player.GetData("playerCuffed") != 0 || player.GetData("SendoArrastado") == true)
        {
            Main.DisplayErrorMessage(player, "Animation konnte nicht ausgeführt werden.");
        }
        else
        {
            player.StopAnimation();
            NAPI.Player.PlayPlayerAnimation(player, 0, "missheistpaletoscore1leadinout", "trv_puking_leadout");
        }
    }

    [Command("plant")]
    public void PlantCommand(Client player)
    {
         if (NAPI.Data.GetEntityData(player, "Injured") != 0 || player.GetData("handsup") == true || player.GetData("playerCuffed") != 0 || player.GetData("SendoArrastado") == true)
        {
            Main.DisplayErrorMessage(player, "Animation konnte nicht ausgeführt werden.");
        }
        else
        {
            player.StopAnimation();
            NAPI.Player.PlayPlayerAnimation(player, 0, "amb@world_human_gardener_plant@male@idle_a", "idle_a");
        }
    }

    [Command("cpr", "~y~Verwendungsart: ~w~/cpr [1 a 4]")]
    public void CprCommand(Client player, int action)
    {
         if (NAPI.Data.GetEntityData(player, "Injured") != 0 || player.GetData("handsup") == true || player.GetData("playerCuffed") != 0 || player.GetData("SendoArrastado") == true)
        {
            Main.DisplayErrorMessage(player, "Animation konnte nicht ausgeführt werden.");
        }
        else
        {
            switch (action)
            {
                case 1:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.StopOnLastFrame | AnimationFlags.AllowPlayerControl), "mini@cpr@char_a@cpr_def", "cpr_intro");
                    break;
                case 2:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop | AnimationFlags.AllowPlayerControl), "mini@cpr@char_a@cpr_str", "cpr_kol");
                    break;
                case 3:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop | AnimationFlags.AllowPlayerControl), "mini@cpr@char_a@cpr_def", "cpr_pumpchest_idle");
                    break;
                case 4:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, 0, "mini@cpr@char_a@cpr_str", "cpr_success");
                    break;
                default:
                    NAPI.Notification.SendNotificationToPlayer(player, "~y~Verwendungsart: ~w~/cpr [1 a 4]");
                    break;
            }
        }
    }

    [Command("carsex", "~y~Verwendungsart: ~w~/carsex [1 a 6]")]
    public void CarSexCommand(Client player, int action)
    {
         if (NAPI.Data.GetEntityData(player, "Injured") != 0 || player.GetData("handsup") == true || player.GetData("playerCuffed") != 0 || player.GetData("SendoArrastado") == true)
        {
            Main.DisplayErrorMessage(player, "Animation konnte nicht ausgeführt werden.");
        }
        else if (NAPI.Player.IsPlayerInAnyVehicle(player) == false)
        {
            Main.DisplayErrorMessage(player, "Sie fahren kein Fahrzeug.");
        }
        else
        {
            /*NetHandle vehicle = NAPI.Player.GetPlayerVehicle(player);
            String vehicleModel = NAPI.Entity.GetEntityModel(vehicle);
            VehicleHash vehicleHash = NAPI.Util.VehicleNameToModel(vehicleModel);
            if (NAPI.Vehicle.GetVehicleClass(vehicleHash) == VEHICLE_CLASS_CYCLES || NAPI.Vehicle.GetVehicleClass(vehicleHash) == VEHICLE_CLASS_MOTORCYCLES || NAPI.Vehicle.GetVehicleClass(vehicleHash) == VEHICLE_CLASS_BOATS)
            {
                Main.DisplayErrorMessage(player, "Você não está em um veículo compativel com esta animação.");
            }
            else
            {*/
            switch (action)
            {
                case 1:
                    if (NAPI.Player.GetPlayerVehicleSeat(player) != (int)VehicleSeat.Driver)
                    {
                        Main.DisplayErrorMessage(player, "Sie fahren kein Fahrzeug.");
                    }
                    else
                    {
                        player.StopAnimation();
                        NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "mini@prostitutes@sexnorm_veh", "bj_loop_male");
                    }
                    break;
                case 2:
                    if (NAPI.Player.GetPlayerVehicleSeat(player) != (int)VehicleSeat.Driver)
                    {
                        Main.DisplayErrorMessage(player, "Sie fahren kein Fahrzeug.");
                    }
                    else
                    {
                        player.StopAnimation();
                        NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "mini@prostitutes@sexnorm_veh", "sex_loop_male");
                    }
                    break;
                case 3:
                    if (NAPI.Player.GetPlayerVehicleSeat(player) != (int)VehicleSeat.RightFront)
                    {
                        Main.DisplayErrorMessage(player, "Sie befinden sich nicht auf dem richtigen Sitz des Fahrzeuginsassen.");
                    }
                    else
                    {
                        player.StopAnimation();
                        NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "mini@prostitutes@sexnorm_veh", "sex_loop_prostitute");
                    }
                    break;
                case 4:
                    if (NAPI.Player.GetPlayerVehicleSeat(player) != (int)VehicleSeat.Driver)
                    {
                        Main.DisplayErrorMessage(player, "Sie fahren kein Fahrzeug.");
                    }
                    else
                    {
                        player.StopAnimation();
                        NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "mini@prostitutes@sexlow_veh", "low_car_bj_loop_player");
                    }
                    break;
                case 5:
                    if (NAPI.Player.GetPlayerVehicleSeat(player) != (int)VehicleSeat.RightFront)
                    {
                        Main.DisplayErrorMessage(player, "Sie befinden sich nicht auf dem richtigen Sitz des Fahrzeuginsassen.");
                    }
                    else
                    {
                        player.StopAnimation();
                        NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "mini@prostitutes@sexlow_veh", "low_car_bj_loop_female");
                    }
                    break;
                case 6:
                    if (NAPI.Player.GetPlayerVehicleSeat(player) != (int)VehicleSeat.RightFront)
                    {
                        Main.DisplayErrorMessage(player, "Sie befinden sich nicht auf dem richtigen Sitz des Fahrzeuginsassen.");
                    }
                    else
                    {
                        player.StopAnimation();
                        NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "mini@prostitutes@sexlow_veh", "low_car_sex_loop_female");
                    }
                    break;
                default:
                    NAPI.Notification.SendNotificationToPlayer(player, "~y~Verwendungsart: ~w~/carsex [1 a 6]");
                    break;
            }
            //}
        }
    }

    [Command("sexydance", "~y~Verwendungsart: ~w~/sexydance [1 a 6]")]
    public void SexyDanceCommand(Client player, int action)
    {
         if (NAPI.Data.GetEntityData(player, "Injured") != 0 || player.GetData("handsup") == true || player.GetData("playerCuffed") != 0 || player.GetData("SendoArrastado") == true)
        {
            Main.DisplayErrorMessage(player, "Animation konnte nicht ausgeführt werden.");
        }
        else
        {
            switch (action)
            {
                case 1:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "amb@world_human_prostitute@cokehead@idle_a", "idle_b");
                    break;
                case 2:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, 0, "mini@hookers_sp", "ilde_c");
                    break;
                case 3:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, 0, "mini@hookers_spcokehead", "idle_a");
                    break;
                case 4:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, 0, "mini@hookers_spcokehead", "idle_c");
                    break;
                case 5:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "mini@hookers_spcrackhead", "idle_b");
                    break;
                case 6:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, 0, "mini@hookers_spvanilla", "idle_b");
                    break;
                default:
                    NAPI.Notification.SendNotificationToPlayer(player, "~y~Verwendungsart: ~w~/sexydance [1 a 6]");
                    break;
            }
        }
    }

    [Command("sit", "~y~Verwendungsart: ~w~/sit [1 a 11]")]
    public void SitCommand(Client player, int action)
    {
         if (NAPI.Data.GetEntityData(player, "Injured") != 0 || player.GetData("handsup") == true || player.GetData("playerCuffed") != 0 || player.GetData("SendoArrastado") == true)
        {
            Main.DisplayErrorMessage(player, "Animation konnte nicht ausgeführt werden.");
        }
        else
        {
            switch (action)
            {
                case 1:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "amb@world_human_stupor@male@base", "base");
                    break;
                case 2:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "amb@world_human_stupor@male_looking_left@base", "base");
                    break;
                case 3:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "anim@heists@fleeca_bank@ig_7_jetski_owner", "owner_idle");
                    break;
                case 4:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "mp_army_contact", "positive_a");
                    break;
                case 5:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "timetable@reunited@ig_10", "base_amanda");
                    break;
                case 6:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "anim@heists@prison_heistunfinished_biztarget_idle", "target_idle");
                    break;
                case 7:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "switch@michael@sitting", "idle");
                    break;
                case 8:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "timetable@michael@on_sofaidle_c", "sit_sofa_g");
                    break;
                case 9:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "timetable@michael@on_sofaidle_b", "sit_sofa_d");
                    break;
                case 10:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "timetable@michael@on_sofaidle_a", "sit_sofa_a");
                    break;
                case 11:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "rcm_barry3", "barry_3_sit_loop");
                    break;
                default:
                    NAPI.Notification.SendNotificationToPlayer(player, "~y~Verwendungsart: ~w~/sit [1 a 11]");
                    break;
            }
        }
    }

    [Command("smoke", "~y~Verwendungsart: ~w~/smoke [1 a 3]")]
    public void SmokeCommand(Client player, int action)
    {
         if (NAPI.Data.GetEntityData(player, "Injured") != 0 || player.GetData("handsup") == true || player.GetData("playerCuffed") != 0 || player.GetData("SendoArrastado") == true)
        {
            Main.DisplayErrorMessage(player, "Animation konnte nicht ausgeführt werden.");
        }
        else
        {
            switch (action)
            {
                case 1:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "amb@world_human_smoking@male@male_a@idle_a", "idle_c");
                    break;
                case 2:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop | AnimationFlags.OnlyAnimateUpperBody | AnimationFlags.AllowPlayerControl), "amb@world_human_smoking@female@idle_a", "idle_b");
                    break;
                case 3:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop | AnimationFlags.AllowPlayerControl | AnimationFlags.OnlyAnimateUpperBody), "mini@hookers_spfrench", "idle_wait");
                    break;
                default:
                    NAPI.Notification.SendNotificationToPlayer(player, "~y~Verwendungsart: ~w~/smoke [1 a 3]");
                    break;
            }
        }
    }

    [Command("liedown", "~y~Verwendungsart: ~w~/liedown [1 a 6]")]
    public void LieDownCommand(Client player, int action)
    {
         if (NAPI.Data.GetEntityData(player, "Injured") != 0 || player.GetData("handsup") == true || player.GetData("playerCuffed") != 0 || player.GetData("SendoArrastado") == true)
        {
            Main.DisplayErrorMessage(player, "Animation konnte nicht ausgeführt werden.");
        }
        else
        {
            switch (action)
            {
                case 1:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "amb@world_human_sunbathe@male@back@idle_a", "idle_a");
                    break;
                case 2:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "amb@world_human_sunbathe@female@back@idle_a", "idle_a");
                    break;
                case 3:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "amb@world_human_sunbathe@female@front@base", "base");
                    break;
                case 4:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "amb@world_human_picnic@male@base", "base");
                    break;
                case 5:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "amb@world_human_picnic@female@base", "base");
                    break;
                case 6:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "missfra0_chop_fchase", "ballasog_rollthroughtraincar_ig6_loop");
                    break;
                default:
                    NAPI.Notification.SendNotificationToPlayer(player, "~y~Verwendungsart: ~w~/liedown [1 a 6]");
                    break;
            }
        }
    }

    [Command("arms", "~y~Verwendungsart: ~w~/arms [1 a 4]")]
    public void ArmsCommand(Client player, int action)
    {
         if (NAPI.Data.GetEntityData(player, "Injured") != 0 || player.GetData("handsup") == true || player.GetData("playerCuffed") != 0 || player.GetData("SendoArrastado") == true)
        {
            Main.DisplayErrorMessage(player, "Animation konnte nicht ausgeführt werden.");
        }
        else
        {
            switch (action)
            {
                case 1:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "amb@world_human_hang_out_street@male_c@base", "base");
                    break;
                case 2:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "amb@world_human_hang_out_street@female_arms_crossed@idle_a", "idle_a");
                    break;
                case 3:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop | AnimationFlags.AllowPlayerControl | AnimationFlags.OnlyAnimateUpperBody), "mini@hookers_sp", "idle_reject_loop_c");
                    break;
                case 4:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.AllowPlayerControl | AnimationFlags.OnlyAnimateUpperBody), "mini@hookers_sp", "idle_reject");
                    break;
                default:
                    NAPI.Notification.SendNotificationToPlayer(player, "~y~Verwendungsart: ~w~/arms [1 a 4]");
                    break;
            }
        }
    }

    [Command("guard", "~y~Verwendungsart: ~w~/guard [1 a 4]")]
    public void GuardCommand(Client player, int action)
    {
         if (NAPI.Data.GetEntityData(player, "Injured") != 0 || player.GetData("handsup") == true || player.GetData("playerCuffed") != 0 || player.GetData("SendoArrastado") == true)
        {
            Main.DisplayErrorMessage(player, "Animation konnte nicht ausgeführt werden.");
        }
        else
        {
            switch (action)
            {
                case 1:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "missbigscore1", "idle_a");
                    break;
                case 2:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "missbigscore1", "idle_base");
                    break;
                case 3:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "missbigscore1", "idle_c");
                    break;
                case 4:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "missbigscore1", "idle_e");
                    break;
                default:
                    NAPI.Notification.SendNotificationToPlayer(player, "~y~Verwendungsart: ~w~/guard [1 a 4]");
                    break;
            }
        }
    }

    [Command("dead", "~y~Verwendungsart: ~w~/dead [1 a 5]")]
    public void DeadCommand(Client player, int action)
    {
         if (NAPI.Data.GetEntityData(player, "Injured") != 0 || player.GetData("handsup") == true || player.GetData("playerCuffed") != 0 || player.GetData("SendoArrastado") == true)
        {
            Main.DisplayErrorMessage(player, "Animation konnte nicht ausgeführt werden.");
        }
        else
        {
            switch (action)
            {
                case 1:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "missarmenian2", "corpse_search_exit_ped");
                    break;
                case 2:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "missarmenian2", "drunk_loop");
                    break;
                case 3:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "missfinale_c1@", "lying_dead_player0");
                    break;
                case 4:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "mp_bank_heist_1", "prone_l_loop");
                    break;
                case 5:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "missfra2", "lamar_base_idle");
                    break;
                default:
                    NAPI.Notification.SendNotificationToPlayer(player, "~y~Verwendungsart: ~w~/dead [1 a 5]");
                    break;
            }
        }
    }

    [Command("idle", "~y~Verwendungsart: ~w~/idle [1 a 9]")]
    public void IdleCommand(Client player, int action)
    {
         if (NAPI.Data.GetEntityData(player, "Injured") != 0 || player.GetData("handsup") == true || player.GetData("playerCuffed") != 0 || player.GetData("SendoArrastado") == true)
        {
            Main.DisplayErrorMessage(player, "Animation konnte nicht ausgeführt werden.");
        }
        else
        {
            switch (action)
            {
                case 1:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop | AnimationFlags.OnlyAnimateUpperBody | AnimationFlags.AllowPlayerControl), "amb@world_human_hang_out_street@female_hold_arm@base", "base");
                    break;
                case 2:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop | AnimationFlags.AllowPlayerControl | AnimationFlags.OnlyAnimateUpperBody), "mini@hookers_sp", "idle_wait");
                    break;
                case 3:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "amb@world_human_stand_impatient@female@no_sign@base", "base");
                    break;
                case 4:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "mini@hookers_spfrench", "idle_wait");
                    break;
                case 5:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "amb@world_human_hang_out_street@female_arm_side@idle_a", "idle_a");
                    break;
                case 6:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "amb@world_human_muscle_flex@arms_in_front@idle_a", "idle_b");
                    break;
                case 7:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "missfbi5leadinout", "leadin_2_fra");
                    break;
                case 8:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "amb@world_human_cop_idles@female@idle_a", "idle_d");
                    break;
                case 9:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "amb@world_human_cop_idles@male@idle_b", "idle_a");
                    break;
                default:
                    NAPI.Notification.SendNotificationToPlayer(player, "~y~Verwendungsart: ~w~/idle [1 a 9]");
                    break;
            }
        }
    }

    [Command("phone", "~y~Verwendungsart: ~w~/phone [1 a 5]")]
    public void PhoneCommand(Client player, int action)
    {
         if (NAPI.Data.GetEntityData(player, "Injured") != 0 || player.GetData("handsup") == true || player.GetData("playerCuffed") != 0 || player.GetData("SendoArrastado") == true)
        {
            Main.DisplayErrorMessage(player, "Animation konnte nicht ausgeführt werden.");
        }
        else
        {
            switch (action)
            {
                case 1:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop | AnimationFlags.AllowPlayerControl | AnimationFlags.OnlyAnimateUpperBody), "amb@world_human_stand_mobile@male@text@base", "base");
                    break;
                case 2:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop | AnimationFlags.AllowPlayerControl | AnimationFlags.OnlyAnimateUpperBody), "cellphone@", "cellphone_email_read_base");
                    break;
                case 3:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop | AnimationFlags.AllowPlayerControl | AnimationFlags.OnlyAnimateUpperBody), "cellphone@", "cellphone_photo_idle");
                    break;
                case 4:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop | AnimationFlags.OnlyAnimateUpperBody | AnimationFlags.AllowPlayerControl), "amb@world_human_stand_mobile@female@standing@call@idle_a", "idle_a");
                    break;
                case 5:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "amb@world_human_mobile_film_shocking@female@idle_a", "idle_a");
                    break;
                default:
                    NAPI.Notification.SendNotificationToPlayer(player, "~y~Verwendungsart: ~w~/carsex [1 a 5]");
                    break;
            }
        }
    }

    [Command("lean", "~y~Verwendungsart: ~w~/lean [1 a 11]")]
    public void LeanCommand(Client player, int action)
    {
         if (NAPI.Data.GetEntityData(player, "Injured") != 0 || player.GetData("handsup") == true || player.GetData("playerCuffed") != 0 || player.GetData("SendoArrastado") == true)
        {
            Main.DisplayErrorMessage(player, "Animation konnte nicht ausgeführt werden.");
        }
        else
        {
            switch (action)
            {
                case 1:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "amb@prop_human_bum_shopping_cart@male@idle_a", "idle_a");
                    break;
                case 2:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "anim@mp_ferris_wheel", "idle_a_player_one");
                    break;
                case 3:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "amb@prop_human_bum_shopping_cart@male@base", "base");
                    break;
                case 4:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "amb@world_human_leaning@male@wall@back@legs_crossed@idle_b", "idle_d");
                    break;
                case 5:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "amb@world_human_leaning@male@wall@back@hands_together@idle_a", "idle_c");
                    break;
                case 6:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "amb@world_human_leaning@male@wall@back@mobile@base", "base");
                    break;
                case 7:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "amb@world_human_leaning@male@wall@back@texting@base", "base");
                    break;
                case 8:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "amb@world_human_leaning@female@wall@back@mobile@base", "base");
                    break;
                case 9:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "amb@world_human_leaning@female@wall@back@texting@base", "base");
                    break;
                case 10:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "amb@world_human_leaning@female@smoke@idle_a", "idle_a");
                    break;
                case 11:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "amb@world_human_leaning@male@wall@back@foot_up@idle_b", "idle_d");
                    break;
                case 12:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "misscarsteal1car_1_ext_leadin", "base_driver1");
                    break;
                default:
                    NAPI.Notification.SendNotificationToPlayer(player, "~y~Verwendungsart: ~w~/lean [1 a 11]");
                    break;
            }
        }
    }

    [Command("cheer", "~y~Verwendungsart: ~w~/cheer [1 a 7]")]
    public void CheerCommand(Client player, int action)
    {
         if (NAPI.Data.GetEntityData(player, "Injured") != 0 || player.GetData("handsup") == true || player.GetData("playerCuffed") != 0 || player.GetData("SendoArrastado") == true)
        {
            Main.DisplayErrorMessage(player, "Animation konnte nicht ausgeführt werden.");
        }
        else
        {
            switch (action)
            {
                case 1:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "amb@world_human_cheering@female_a", "base");
                    break;
                case 2:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "amb@world_human_cheering@female_c", "base");
                    break;
                case 3:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "amb@world_human_cheering@female_d", "base");
                    break;
                case 4:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "amb@world_human_cheering@male_a", "base");
                    break;
                case 5:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "amb@world_human_cheering@male_b", "base");
                    break;
                case 6:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "amb@world_human_cheering@male_d", "base");
                    break;
                case 7:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "amb@world_human_cheering@male_e", "base");
                    break;
                default:
                    NAPI.Notification.SendNotificationToPlayer(player, "~y~Verwendungsart: ~w~/cheer [1 a 7]");
                    break;
            }
        }
    }

    [Command("dance", "~y~Verwendungsart: ~w~/dance [1 a 6]")]
    public void DanceCommand(Client player, int action)
    {
         if (NAPI.Data.GetEntityData(player, "Injured") != 0 || player.GetData("handsup") == true || player.GetData("playerCuffed") != 0 || player.GetData("SendoArrastado") == true)
        {
            Main.DisplayErrorMessage(player, "Animation konnte nicht ausgeführt werden.");
        }
        else
        {
            switch (action)
            {
                case 1:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "amb@world_human_jog_standing@female@base", "base");
                    break;
                case 2:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "amb@world_human_jog_standing@female@idle_a", "idle_a");
                    break;
                case 3:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "amb@world_human_power_walker@female@static", "static");
                    break;
                case 4:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "amb@world_human_partying@female@partying_beer@base", "base");
                    break;
                case 5:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "amb@world_human_partying@female@partying_cellphone@idle_a", "idle_a");
                    break;
                case 6:
                    player.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "amb@world_human_partying@female@partying_beer@idle_a", "idle_a");
                    break;
                default:
                    NAPI.Notification.SendNotificationToPlayer(player, "~y~Verwendungsart: ~w~/dance [1 a 6]");
                    break;
            }
        }
    }

    [Command("piss")]
    public void PissCommand(Client player)
    {
         if (NAPI.Data.GetEntityData(player, "Injured") != 0 || player.GetData("handsup") == true || player.GetData("playerCuffed") != 0 || player.GetData("SendoArrastado") == true)
        {
            Main.DisplayErrorMessage(player, "Animation konnte nicht ausgeführt werden.");
        }
        else
        {
            player.StopAnimation();
            NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "missbigscore1switch_trevor_piss", "piss_loop");
        }
    }

    [Command("aplause")]
    public void AplauseCommand(Client player)
    {
         if (NAPI.Data.GetEntityData(player, "Injured") != 0 || player.GetData("handsup") == true || player.GetData("playerCuffed") != 0 || player.GetData("SendoArrastado") == true)
        {
            Main.DisplayErrorMessage(player, "Animation konnte nicht ausgeführt werden.");
        }
        else
        {
            player.StopAnimation();
            NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "amb@world_human_strip_watch_stand@male_a@idle_a", "idle_a");
        }
    }

    [Command("drunk")]
    public void DrunkCommand(Client player)
    {
         if (NAPI.Data.GetEntityData(player, "Injured") != 0 || player.GetData("handsup") == true || player.GetData("playerCuffed") != 0 || player.GetData("SendoArrastado") == true)
        {
            Main.DisplayErrorMessage(player, "Animation konnte nicht ausgeführt werden.");
        }
        else
        {
            player.StopAnimation();
            NAPI.Player.PlayPlayerAnimation(player, 0, "mini@hookers_spcrackhead", "idle_c");
        }
    }

    [Command("shrug")]
    public void ShrugCommand(Client player)
    {
         if (NAPI.Data.GetEntityData(player, "Injured") != 0 || player.GetData("handsup") == true || player.GetData("playerCuffed") != 0 || player.GetData("SendoArrastado") == true)
        {
            Main.DisplayErrorMessage(player, "Animation konnte nicht ausgeführt werden.");
        }
        else
        {
            player.StopAnimation();
            NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.AllowPlayerControl | AnimationFlags.OnlyAnimateUpperBody), "gestures@f@standing@casual", "gesture_shrug_hard");
        }
    }

    [Command("desperate")]
    public void DesperateCommand(Client player)
    {
         if (NAPI.Data.GetEntityData(player, "Injured") != 0 || player.GetData("handsup") == true || player.GetData("playerCuffed") != 0 || player.GetData("SendoArrastado") == true)
        {
            Main.DisplayErrorMessage(player, "Animation konnte nicht ausgeführt werden.");
        }
        else
        {
            player.StopAnimation();
            NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "misscarsteal4@toilet", "desperate_toilet_idle_a");
        }
    }

    [Command("pensive")]
    public void PensiveCommand(Client player)
    {
         if (NAPI.Data.GetEntityData(player, "Injured") != 0 || player.GetData("handsup") == true || player.GetData("playerCuffed") != 0 || player.GetData("SendoArrastado") == true)
        {
            Main.DisplayErrorMessage(player, "Animation konnte nicht ausgeführt werden.");
        }
        else
        {
            player.StopAnimation();
            NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop | AnimationFlags.OnlyAnimateUpperBody | AnimationFlags.AllowPlayerControl), "misscarsteal4@aliens", "rehearsal_base_idle_director");
        }
    }

    [Command("handsheat")]
    public void HandsHeatCommand(Client player)
    {
         if (NAPI.Data.GetEntityData(player, "Injured") != 0 || player.GetData("handsup") == true || player.GetData("playerCuffed") != 0 || player.GetData("SendoArrastado") == true)
        {
            Main.DisplayErrorMessage(player, "Animation konnte nicht ausgeführt werden.");
        }
        else
        {
            player.StopAnimation();
            NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "amb@world_human_stand_fire@male@base", "base");
        }
    }

    [Command("rock")]
    public void RockCommand(Client player)
    {
         if (NAPI.Data.GetEntityData(player, "Injured") != 0 || player.GetData("handsup") == true || player.GetData("playerCuffed") != 0 || player.GetData("SendoArrastado") == true)
        {
            Main.DisplayErrorMessage(player, "Animation konnte nicht ausgeführt werden.");
        }
        else
        {
            player.StopAnimation();
            NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.AllowPlayerControl | AnimationFlags.OnlyAnimateUpperBody), "anim@mp_player_intincarrockbodhi@ps@", "enter");
        }
    }

    [Command("injured")]
    public void InjuredCommand(Client player)
    {
         if (NAPI.Data.GetEntityData(player, "Injured") != 0 || player.GetData("handsup") == true || player.GetData("playerCuffed") != 0 || player.GetData("SendoArrastado") == true)
        {
            Main.DisplayErrorMessage(player, "Animation konnte nicht ausgeführt werden.");
        }
        else
        {
            player.StopAnimation();
            NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.StopOnLastFrame | AnimationFlags.AllowPlayerControl), "combat@damage@injured_pistol@to_writhe", "variation_b");
        }
    }

    [Command("stumble")]
    public void StumbleCommand(Client player)
    {
         if (NAPI.Data.GetEntityData(player, "Injured") != 0 || player.GetData("handsup") == true || player.GetData("playerCuffed") != 0 || player.GetData("SendoArrastado") == true)
        {
            Main.DisplayErrorMessage(player, "Animation konnte nicht ausgeführt werden.");
        }
        else
        {
            player.StopAnimation();
            NAPI.Player.PlayPlayerAnimation(player, 0, "misscarsteal4@actor", "stumble");
        }
    }

}

