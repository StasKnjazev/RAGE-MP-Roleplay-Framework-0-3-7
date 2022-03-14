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
using System.Security.Cryptography;
using Newtonsoft.Json;
using DerStr1k3r.Core;
using DerStr1k3r.SDK;
// Team Rank Table
// 1 - Tester 
// 2 - Game helper 
// 3 - Game Admin I 
// 4 - Game Admin II 
// 5 - Game Admin III 
// 6 - Lead Admin 
// 7 - Diretor 
// 8 - Coordenador 
// 9 - Developer 
// 10 - Management

class AccountManage : Script
{
    private static Client player;

    public static void SaveCharacter(Client player)
    {
        float essen = (int)NAPI.Data.GetEntityData(player, "Hunger");
        float trinken = (int)NAPI.Data.GetEntityData(player, "Thirsty");

        if (player.GetData("status") == true)
        {
            using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
            {
                try
                {
                    Mainpipeline.Open();
                    string query = "UPDATE characters SET name = @name, money = @money, bank = @bank, `character_hotel` = @character_hotel, `character_hotel_left` = @character_hotel_left, `InsideHotelID` = @InsideHotelID, Infinity = @Infinity, salary = @salary, char_position_x = @char_position_x, char_position_y = @char_position_y, char_position_z = @char_position_z, char_rotation_z = @char_rotation_z, char_torso = @char_torso, char_undershirt = @char_undershirt, char_undershirt_texture = @char_undershirt_texture, char_leg = @char_leg, char_leg_texture = @char_leg_texture, char_feet = @char_feet, char_feet_texture = @char_feet_texture, char_shirt = @char_shirt, char_shirt_texture = @char_shirt_texture, char_mask = @char_mask, char_mask_texture = @char_mask_texture, ";
                    query = query + " `business_key` = @business_key, `group` = @group, `group_rank` = @group_rank, `job` = @job, `job_center_status` = @job_center_status, `licence_illegal_ordering_1` = @licence_illegal_ordering_1, `licence_illegal_ordering_2` = @licence_illegal_ordering_2, `thirsty` = @thirsty, `hunger` = @hunger, `wanted` = @wanted, `last_crime` = @last_crime, `prison` = @prison, `prison_cell` = @prison_cell, `prison_time` = @prison_time, `hospital` = @hospital, `death` = @death, `death_seconds` = death_seconds, `leader` = @leader, `level` = @level, `exp` = @exp, ";
                    query = query + "char_outfit = @char_outfit, char_outfit_duty = @char_outfit_duty, char_dimension = @char_dimension, inside_house = @inside_house, peixe_0 = @peixe_0, peixe_1 = @peixe_1, peixe_2 = @peixe_2, peixe_3 = @peixe_3, peixe_4 = @peixe_4, peixe_5 = @peixe_5, peixe_6 = @peixe_6, peixe_7 = @peixe_7, peixe_8 = @peixe_8, peixe_9 = @peixe_9, `ooc_prison_time` = @ooc_prison_time, `ooc_warning` = @ooc_warning, `ooc_mute_newbie` = @ooc_mute_newbie,";
                    query = query + "`char_armor` = @char_armor, `char_armor_texture` = @char_armor_texture, `duty` = @duty, ammo_handguns = @ammo_handguns, ammo_machineguns = @ammo_machineguns, ammo_assaultrifles = @ammo_assaultrifles, ammo_sniperrifles = @ammo_sniperrifles, ammo_shotguns = @ammo_shotguns,";
                    query = query + "`car_lic` = @car_lic, `truck_lic` = @truck_lic, `fly_lic` = @fly_lic, `fish_lic` = @fish_lic, `taxi_lic` = @taxi_lic, `gun_lic` = @gun_lic, `cycles_lic` = @cycles_lic, `lawyer_lic` = @lawyer_lic,";
                    query = query + "`character_hats` = @character_hats, `character_hats_texture` = @character_hats_texture, `character_glasses` = @character_glasses, `character_glasses_texture` = @character_glasses_texture, `character_ears` = @character_ears, `character_ears_texture` = @character_ears_texture, `character_cellphone` = @character_cellphone, `helmet` = @helmet, `helmet_texture` = @helmet_texture, `character_rppoints`= @character_rppoints, ";
                    query = query + "`character_watches` = @character_watches, `character_watches_texture` = @character_watches_texture, `character_bracelets` = @character_bracelets, `character_tattoo_overlay` = @character_tattoo_overlay, `character_tattoo_collection` = @character_tattoo_collection, `character_accessories` = @character_accessories, `character_accessories_texture` = @character_accessories_texture, `backpack` = @backpack, `character_vip` = @character_vip, `character_vip_expire` = @character_vip_expire, `character_vip_date` = @character_vip_date, `character_donator` = @character_donator, `character_credits` = @character_credits, `health` = @health, `colete` = @armor, `LastLogin` = @LastLogin, `character_vehicle_slots` = @character_vehicle_slots, `character_house_slots` = @character_house_slots, `character_cat` = @character_cat ";
                    query = query + " WHERE name = '" + player.GetData("character_name") + "'";

#pragma warning disable CA2100 // Review SQL queries for security vulnerabilities
                    MySqlCommand myCommand = new MySqlCommand(query, Mainpipeline);
#pragma warning restore CA2100 // Review SQL queries for security vulnerabilities

                    myCommand.Parameters.AddWithValue("@name", player.GetData("character_name"));
                    myCommand.Parameters.AddWithValue("@money", player.GetData("character_money"));
                    myCommand.Parameters.AddWithValue("@bank", player.GetData("character_bank"));
                    myCommand.Parameters.AddWithValue("@salary", player.GetData("character_salary"));

                    myCommand.Parameters.AddWithValue("@level", player.GetData("character_level"));
                    myCommand.Parameters.AddWithValue("@exp", player.GetData("character_exp"));
                    myCommand.Parameters.AddWithValue("@leader", player.GetData("character_leader"));
                    myCommand.Parameters.AddWithValue("@group", player.GetData("character_group"));
                    myCommand.Parameters.AddWithValue("@group_rank", player.GetData("character_group_rank"));
                    myCommand.Parameters.AddWithValue("@job", player.GetData("character_job"));
                    myCommand.Parameters.AddWithValue("@job_center_status", player.GetData("character_job_center_status"));
                    myCommand.Parameters.AddWithValue("@licence_illegal_ordering_1", player.GetData("character_licence_illegal_ordering_1"));
                    myCommand.Parameters.AddWithValue("@licence_illegal_ordering_2", player.GetData("character_licence_illegal_ordering_2"));
                    myCommand.Parameters.AddWithValue("@wanted", player.GetData("character_wanted_level"));
                    myCommand.Parameters.AddWithValue("@last_crime", player.GetData("character_last_crime"));
                    myCommand.Parameters.AddWithValue("@business_key", player.GetData("character_business_key"));
                    //myCommand.Parameters.AddWithValue("@hunger", essen);
                    //myCommand.Parameters.AddWithValue("@thirsty", trinken);
                    myCommand.Parameters.AddWithValue("@hunger", "" + player.GetData("Hunger") + "");
                    myCommand.Parameters.AddWithValue("@thirsty", "" + player.GetData("Thirsty") + "");

                    myCommand.Parameters.AddWithValue("@duty", player.GetData("duty"));
                    myCommand.Parameters.AddWithValue("@hospital", player.GetSharedData("character_hospital"));
                    myCommand.Parameters.AddWithValue("@death", player.GetSharedData("Injured"));
                    myCommand.Parameters.AddWithValue("@death_seconds", player.GetSharedData("InjuredTime"));
                    myCommand.Parameters.AddWithValue("@health", player.Health);
                    myCommand.Parameters.AddWithValue("@armor", player.Armor);
                    myCommand.Parameters.AddWithValue("@LastLogin", DateTime.Now);

                    myCommand.Parameters.AddWithValue("@Infinity", player.GetData("Infinity"));

                    myCommand.Parameters.AddWithValue("@prison", player.GetData("character_prison"));
                    myCommand.Parameters.AddWithValue("@prison_cell", player.GetData("character_prison_cell"));
                    myCommand.Parameters.AddWithValue("@prison_time", player.GetData("character_prison_time"));
                    myCommand.Parameters.AddWithValue("@ooc_prison_time", player.GetData("character_ooc_prison_time"));
                    myCommand.Parameters.AddWithValue("@ooc_warning", player.GetData("character_ooc_warning"));
                    myCommand.Parameters.AddWithValue("@ooc_mute_newbie", player.GetData("character_ooc_mute_newbie"));


                    myCommand.Parameters.AddWithValue("@character_vip", player.GetData("character_vip"));
                    myCommand.Parameters.AddWithValue("@character_vip_expire", player.GetData("character_vip_expire"));
                    myCommand.Parameters.AddWithValue("@character_vip_date", player.GetData("character_vip_date"));
                    myCommand.Parameters.AddWithValue("@character_donator", player.GetData("character_donator"));
                    myCommand.Parameters.AddWithValue("@character_credits", player.GetData("character_credits"));
                    myCommand.Parameters.AddWithValue("@character_vehicle_slots", player.GetData("character_vehicle_slots"));
                    myCommand.Parameters.AddWithValue("@character_house_slots", player.GetData("character_house_slots"));
                    myCommand.Parameters.AddWithValue("@character_cat", player.GetData("character_cat"));

                    myCommand.Parameters.AddWithValue("@car_lic", player.GetData("character_car_lic"));
                    myCommand.Parameters.AddWithValue("@truck_lic", player.GetData("character_truck_lic"));
                    myCommand.Parameters.AddWithValue("@fly_lic", player.GetData("character_fly_lic"));
                    myCommand.Parameters.AddWithValue("@fish_lic", player.GetData("character_fish_lic"));
                    myCommand.Parameters.AddWithValue("@taxi_lic", player.GetData("character_taxi_lic"));
                    myCommand.Parameters.AddWithValue("@gun_lic", player.GetData("character_gun_lic"));
                    myCommand.Parameters.AddWithValue("@lawyer_lic", player.GetData("character_lawyer_lic"));
                    myCommand.Parameters.AddWithValue("@cycles_lic", player.GetData("character_cycles_lic"));

                    for (int i = 0; i < 10; i++)
                    {
                        if (player.GetData("peixe_" + i) == 255) myCommand.Parameters.AddWithValue("@peixe_" + i, -1);
                        else myCommand.Parameters.AddWithValue("@peixe_" + i, player.GetData("peixe_" + i));
                    }

                    myCommand.Parameters.AddWithValue("@ammo_handguns", player.GetData("character_ammo_handguns"));
                    myCommand.Parameters.AddWithValue("@ammo_machineguns", player.GetData("character_ammo_machineguns"));
                    myCommand.Parameters.AddWithValue("@ammo_assaultrifles", player.GetData("character_ammo_assaultrifles"));
                    myCommand.Parameters.AddWithValue("@ammo_sniperrifles", player.GetData("character_ammo_sniperrifles"));
                    myCommand.Parameters.AddWithValue("@ammo_shotguns", player.GetData("character_ammo_shotguns"));

                    // Hotel System #09.04.2020
                    myCommand.Parameters.AddWithValue("@character_hotel", player.GetData("character_hotel"));
                    myCommand.Parameters.AddWithValue("@character_hotel_left", player.GetData("character_hotel_left"));
                    myCommand.Parameters.AddWithValue("@InsideHotelID", player.GetData("InsideHotelID"));

                    myCommand.Parameters.AddWithValue("@backpack", player.GetData("character_backpack"));
                    myCommand.Parameters.AddWithValue("@character_rppoints", player.GetData("character_rppoints"));

                    myCommand.Parameters.AddWithValue("@char_position_x", player.Position.X.ToString());
                    myCommand.Parameters.AddWithValue("@char_position_y", player.Position.Y.ToString());
                    myCommand.Parameters.AddWithValue("@char_position_z", player.Position.Z.ToString());
                    myCommand.Parameters.AddWithValue("@char_rotation_z", player.Rotation.Z.ToString());

                    myCommand.Parameters.AddWithValue("@char_torso", (int)NAPI.Data.GetEntitySharedData(player, "character_torso"));
                    myCommand.Parameters.AddWithValue("@char_undershirt", (int)NAPI.Data.GetEntitySharedData(player, "character_undershirt"));
                    myCommand.Parameters.AddWithValue("@char_undershirt_texture", (int)NAPI.Data.GetEntitySharedData(player, "character_undershirt_texture"));
                    myCommand.Parameters.AddWithValue("@char_leg", (int)NAPI.Data.GetEntitySharedData(player, "character_leg"));
                    myCommand.Parameters.AddWithValue("@char_leg_texture", (int)NAPI.Data.GetEntitySharedData(player, "character_leg_texture"));
                    myCommand.Parameters.AddWithValue("@char_feet", (int)NAPI.Data.GetEntitySharedData(player, "character_feet"));
                    myCommand.Parameters.AddWithValue("@char_feet_texture", (int)NAPI.Data.GetEntitySharedData(player, "character_feet_texture"));
                    myCommand.Parameters.AddWithValue("@char_shirt", (int)NAPI.Data.GetEntitySharedData(player, "character_shirt"));
                    myCommand.Parameters.AddWithValue("@char_shirt_texture", (int)NAPI.Data.GetEntitySharedData(player, "character_shirt_texture"));
                    myCommand.Parameters.AddWithValue("@char_mask", (int)NAPI.Data.GetEntitySharedData(player, "character_mask"));
                    myCommand.Parameters.AddWithValue("@char_mask_texture", (int)NAPI.Data.GetEntitySharedData(player, "character_mask_texture"));
                    myCommand.Parameters.AddWithValue("@char_armor", (int)NAPI.Data.GetEntitySharedData(player, "character_armor"));
                    myCommand.Parameters.AddWithValue("@char_armor_texture", (int)NAPI.Data.GetEntitySharedData(player, "character_armor_texture"));

                    myCommand.Parameters.AddWithValue("@character_hats", (int)NAPI.Data.GetEntitySharedData(player, "character_hats"));
                    myCommand.Parameters.AddWithValue("@character_hats_texture", (int)NAPI.Data.GetEntitySharedData(player, "character_hats_texture"));
                    myCommand.Parameters.AddWithValue("@character_glasses", (int)NAPI.Data.GetEntitySharedData(player, "character_glasses"));
                    myCommand.Parameters.AddWithValue("@character_glasses_texture", (int)NAPI.Data.GetEntitySharedData(player, "character_glasses_texture"));
                    myCommand.Parameters.AddWithValue("@character_ears", (int)NAPI.Data.GetEntitySharedData(player, "character_ears"));
                    myCommand.Parameters.AddWithValue("@character_ears_texture", (int)NAPI.Data.GetEntitySharedData(player, "character_ears_texture"));
                    myCommand.Parameters.AddWithValue("@character_watches", (int)NAPI.Data.GetEntitySharedData(player, "character_watches"));
                    myCommand.Parameters.AddWithValue("@character_watches_texture", (int)NAPI.Data.GetEntitySharedData(player, "character_watches_texture"));
                    myCommand.Parameters.AddWithValue("@character_bracelets", (int)NAPI.Data.GetEntitySharedData(player, "character_bracelets"));
                    myCommand.Parameters.AddWithValue("@character_bracelets_texutre", (int)NAPI.Data.GetEntitySharedData(player, "character_bracelets_texutre"));
                    myCommand.Parameters.AddWithValue("@character_accessories", (int)NAPI.Data.GetEntitySharedData(player, "character_accessories"));
                    myCommand.Parameters.AddWithValue("@character_accessories_texture", (int)NAPI.Data.GetEntitySharedData(player, "character_accessories_texture"));
                    myCommand.Parameters.AddWithValue("@helmet", (int)NAPI.Data.GetEntitySharedData(player, "character_helmet"));
                    myCommand.Parameters.AddWithValue("@helmet_texture", (int)NAPI.Data.GetEntitySharedData(player, "character_helmet_texture"));

                    string toggle_clothing = Convert.ToInt32(player.GetData("clothes_neck"))
                        + "|" + Convert.ToInt32(player.GetData("clothes_ears"))
                        + "|" + Convert.ToInt32(player.GetData("clothes_watches"))
                        + "|" + Convert.ToInt32(player.GetData("clothes_glasses"))
                        + "|" + Convert.ToInt32(player.GetData("clothes_hats"))
                        + "|" + Convert.ToInt32(player.GetData("clothes_shirt"))
                        + "|" + Convert.ToInt32(player.GetData("clothes_armor"))
                        + "|" + Convert.ToInt32(player.GetData("clothes_leg"))
                        + "|" + Convert.ToInt32(player.GetData("clothes_feet"))
                        + "|" + Convert.ToInt32(player.GetData("clothes_bag"));

                    myCommand.Parameters.AddWithValue("@toggle_clothing", toggle_clothing);

                    toggle_clothing = Convert.ToInt32(player.GetData("character_lotto_0"))
                        + "|" + Convert.ToInt32(player.GetData("character_lotto_1"))
                        + "|" + Convert.ToInt32(player.GetData("character_lotto_2"))
                        + "|" + Convert.ToInt32(player.GetData("character_lotto_3"));
                    myCommand.Parameters.AddWithValue("@lotto_tickets", toggle_clothing);

                    myCommand.Parameters.AddWithValue("@character_tattoo_collection", (string)NAPI.Data.GetEntitySharedData(player, "character_tattoo_collection"));
                    myCommand.Parameters.AddWithValue("@character_tattoo_overlay", (string)NAPI.Data.GetEntitySharedData(player, "character_tattoo_overlay"));

                    myCommand.Parameters.AddWithValue("@char_outfit", player.GetData("character_outfit"));
                    myCommand.Parameters.AddWithValue("@char_outfit_duty", player.GetData("character_duty_outfit"));
                    myCommand.Parameters.AddWithValue("@char_dimension", player.Dimension);
                    myCommand.Parameters.AddWithValue("@connected_seconds", player.GetData("connected_seconds"));
                    myCommand.Parameters.AddWithValue("@character_cellphone", cellphoneSystem.GetPlayerNumber(player));

                    if (player.HasData("InsideHouse_ID"))
                    {
                        myCommand.Parameters.AddWithValue("@inside_house", player.GetData("InsideHouse_ID"));
                    }
                    else myCommand.Parameters.AddWithValue("@inside_house", "null");

                    myCommand.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    NAPI.Util.ConsoleOutput("[EXCEPTION SaveAccount] " + ex.Message);
                    NAPI.Util.ConsoleOutput("[EXCEPTION SaveAccount] " + ex.StackTrace);
                    //When handling errors, you can your application's response based 
                    //on the error number.
                    if (Mainpipeline != null)
                    {
                        NAPI.Util.ConsoleOutput("DATABASE: [ACCOUNT SAVE ERROR] " + ex.Message);
                        Mainpipeline.Dispose();
                        if (Mainpipeline != null)
                        {
                            Mainpipeline.ClearAllPoolsAsync();
                        }
                    }
                    throw;
                }
            }

        }
    }


    [RemoteEvent("ClientPreviewCharacterID")]
    public static void ClientPreviewCharacterID(Client player, int user)
    {
        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {

            Mainpipeline.Open();
            MySqlCommand query = new MySqlCommand("SELECT * FROM `characters` WHERE `id` = '" + user + "' LIMIT 1;", Mainpipeline);

            using (MySqlDataReader reader = query.ExecuteReader())
            {

                string data2txt = string.Empty;
                string datatxt = string.Empty;

                while (reader.Read())
                {
                    player.SetData("character_sqlid", reader.GetInt32("id"));
                    player.SetData("character_name", reader.GetString("name"));

                    player.SetData("character_duty_outfit", reader.GetInt32("char_outfit_duty"));
                    player.SetData("character_outfit", reader.GetInt32("char_outfit"));

                    player.SetData("character_customization", reader.GetString("char"));

                    player.TriggerEvent("csharp_UpdateName", player.GetData("character_name"));

                    player.TriggerEvent("csharp_LoadingCharacter");
                    //player.TriggerEvent("csharp_LoadingCharacter");

                    player.SetSharedData("character_torso", reader.GetInt32("char_torso"));
                    player.SetSharedData("character_torso_texture", 0);
                    player.SetSharedData("character_undershirt", reader.GetInt32("char_undershirt"));
                    player.SetSharedData("character_undershirt_texture", reader.GetInt32("char_undershirt_texture"));
                    player.SetSharedData("character_leg", reader.GetInt32("char_leg"));
                    player.SetSharedData("character_leg_texture", reader.GetInt32("char_leg_texture"));
                    player.SetSharedData("character_feet", reader.GetInt32("char_feet"));
                    player.SetSharedData("character_feet_texture", reader.GetInt32("char_feet_texture"));
                    player.SetSharedData("character_shirt", reader.GetInt32("char_shirt"));
                    player.SetSharedData("character_shirt_texture", reader.GetInt32("char_shirt_texture"));
                    player.SetSharedData("character_mask", reader.GetInt32("char_mask"));
                    player.SetSharedData("character_mask_texture", reader.GetInt32("char_mask_texture"));
                    player.SetSharedData("character_armor", reader.GetInt32("char_armor"));
                    player.SetSharedData("character_armor_texture", reader.GetInt32("char_armor_texture"));

                    player.SetSharedData("character_hats", reader.GetInt32("character_hats"));
                    player.SetSharedData("character_hats_texture", reader.GetInt32("character_hats_texture"));
                    player.SetSharedData("character_glasses", reader.GetInt32("character_glasses"));
                    player.SetSharedData("character_glasses_texture", reader.GetInt32("character_glasses_texture"));
                    player.SetSharedData("character_ears", reader.GetInt32("character_ears"));
                    player.SetSharedData("character_ears_texture", reader.GetInt32("character_ears_texture"));
                    player.SetSharedData("character_watches", reader.GetInt32("character_watches"));
                    player.SetSharedData("character_watches_texture", reader.GetInt32("character_watches_texture"));
                    player.SetSharedData("character_bracelets", reader.GetInt32("character_bracelets"));
                    player.SetSharedData("character_bracelets_texutre", reader.GetInt32("character_bracelets_texutre"));
                    player.SetSharedData("character_accessories", reader.GetInt32("character_accessories"));
                    player.SetSharedData("character_accessories_texture", reader.GetInt32("character_accessories_texture"));

                    player.SetSharedData("character_tattoo_collection", reader.GetString("character_tattoo_collection"));
                    player.SetSharedData("character_tattoo_overlay", reader.GetString("character_tattoo_overlay"));

                    NAPI.Data.SetEntityData(player, "duty", reader.GetInt32("duty"));

                    CharCreator.CharCreator.LoadCharacter(player, player.GetData("character_name"));
                    Main.UpdatePlayerClothes(player);
                }
            }
        }
    }

    public static void LoadCharacter(Client player, int user)
    {
        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {

            Mainpipeline.Open();
            MySqlCommand query = new MySqlCommand("SELECT * FROM `characters` WHERE `id` = '" + user + "' LIMIT 1;", Mainpipeline);

            using (MySqlDataReader reader = query.ExecuteReader())
            {

                string data2txt = string.Empty;
                string datatxt = string.Empty;
                
                while (reader.Read())
                {
                    NAPI.Util.ConsoleOutput("[MYSQL]: Der Benutzer " + player.GetData("player_username") + " hat sich mit dem Charakter auf dem Server angemeldet: " + reader.GetString("name") + ".");

                    player.SetData("character_sqlid", reader.GetInt32("id"));
                    player.SetSharedData("unknow_sqlid", reader.GetInt32("id"));
                    player.SetData("character_name", reader.GetString("name"));
                    player.SetData("character_money", reader.GetInt32("money"));
                    player.SetData("character_bank", reader.GetInt32("bank"));
                    player.SetData("character_salary", reader.GetInt32("salary"));
                    player.SetData("character_level", reader.GetInt32("level"));
                    player.SetData("character_exp", reader.GetInt32("exp"));
                    player.SetData("character_leader", reader.GetInt32("leader"));
                    player.SetData("character_group", reader.GetInt32("group"));
                    player.SetData("character_group_rank", reader.GetInt32("group_rank"));
                    player.SetData("character_job", reader.GetInt32("job"));
                    player.SetData("character_job_center_status", reader.GetInt32("job_center_status"));
                    player.SetData("character_licence_illegal_ordering_1", reader.GetInt32("licence_illegal_ordering_1"));
                    player.SetData("character_licence_illegal_ordering_2", reader.GetInt32("licence_illegal_ordering_2"));
                    player.SetData("character_wanted_level", reader.GetInt32("wanted"));
                    player.SetData("character_last_crime", reader.GetString("last_crime"));
                    player.SetData("character_prison", reader.GetInt32("prison"));
                    player.SetData("character_prison_cell", reader.GetInt32("prison_cell"));
                    player.SetData("character_prison_time", reader.GetInt32("prison_time"));
                    player.SetSharedData("character_hospital", reader.GetInt32("hospital"));
                    player.SetSharedData("Injured", reader.GetInt32("death"));
                    player.SetSharedData("InjuredTime", reader.GetInt32("death_seconds"));
                    player.SetData("character_position_x", float.Parse(reader.GetString("char_position_x")));
                    player.SetData("character_position_y", float.Parse(reader.GetString("char_position_y")));
                    player.SetData("character_position_z", float.Parse(reader.GetString("char_position_z")));
                    player.SetData("character_rotation_z", float.Parse(reader.GetString("char_rotation_z")));
                    player.SetData("character_business_key", reader.GetInt32("business_key"));
                    player.SetData("character_duty_outfit", reader.GetInt32("char_outfit_duty"));
                    player.SetData("character_outfit", reader.GetInt32("char_outfit"));
                    player.SetData("character_dimension", reader.GetInt32("char_dimension"));
                    player.SetData("character_vip", reader.GetInt32("character_vip"));
                    player.SetData("character_donator", reader.GetInt32("character_donator"));
                    //API.Util.ConsoleOutput("1,1");
                    player.SetData("character_credits", reader.GetInt32("character_credits"));
                    //API.Util.ConsoleOutput("1,2");
                    player.SetData("character_vip_expire", reader.GetDateTime("character_vip_expire"));
                    //API.Util.ConsoleOutput("1,3");
                    player.SetData("character_vip_date", reader.GetDateTime("character_vip_date"));
                    //API.Util.ConsoleOutput("1,4");
                    player.SetData("character_last_login", reader.GetDateTime("LastLogin"));
                    //API.Util.ConsoleOutput("1,5");
                    player.SetData("character_vehicle_slots", reader.GetInt32("character_vehicle_slots"));
                    //API.Util.ConsoleOutput("1,6");
                    player.SetData("character_house_slots", reader.GetInt32("character_house_slots"));
                    //API.Util.ConsoleOutput("1,7");
                    player.SetData("character_cat", reader.GetInt32("character_cat"));
                    //API.Util.ConsoleOutput("2");

                    player.SetData("character_car_lic", reader.GetInt32("car_lic"));
                    player.SetData("character_truck_lic", reader.GetInt32("truck_lic"));
                    player.SetData("character_fly_lic", reader.GetInt32("fly_lic"));
                    player.SetData("character_fish_lic", reader.GetInt32("fish_lic"));
                    player.SetData("character_taxi_lic", reader.GetInt32("taxi_lic"));
                    player.SetData("character_gun_lic", reader.GetInt32("gun_lic"));
                    player.SetData("character_lawyer_lic", reader.GetInt32("lawyer_lic"));
                    player.SetData("character_cycles_lic", reader.GetInt32("cycles_lic"));

                    player.SetData("character_rppoints", reader.GetInt32("character_rppoints"));

                    player.TriggerEvent("csharp_UpdateName", player.GetData("character_name"));

                    for (int i = 0; i < 10; i++)
                    {
                        if (reader.GetInt32("peixe_" + i) == 255) player.SetData("peixe_" + i, -1);
                        else player.SetData("peixe_" + i, reader.GetInt32("peixe_" + i));
                    }

                    //API.Util.ConsoleOutput("4");

                    player.SetData("character_ammo_handguns", reader.GetInt32("ammo_handguns"));
                    player.SetData("character_ammo_machineguns", reader.GetInt32("ammo_machineguns"));
                    player.SetData("character_ammo_assaultrifles", reader.GetInt32("ammo_assaultrifles"));
                    player.SetData("character_ammo_sniperrifles", reader.GetInt32("ammo_sniperrifles"));
                    player.SetData("character_ammo_shotguns", reader.GetInt32("ammo_shotguns"));

                    //API.Util.ConsoleOutput("5");

                    // Hotel System 09.04.2020
                    player.SetData("character_hotel", reader.GetInt32("character_hotel"));
                    player.SetData("character_hotel_left", reader.GetInt32("character_hotel_left"));
                    player.SetData("InsideHotelID", reader.GetInt32("InsideHotelID"));

                    player.SetData("character_backpack", reader.GetInt32("backpack"));

                    player.SetData("inside_house", reader.GetString("inside_house"));

                    //API.Util.ConsoleOutput("6");
                    player.SetData("character_ooc_prison_time", reader.GetInt32("ooc_prison_time"));
                    player.SetData("character_ooc_warning", reader.GetInt32("ooc_warning"));
                    player.SetData("character_ooc_mute_newbie", reader.GetInt32("ooc_mute_newbie"));

                    //
                    // Character
                    //
                    player.SetData("character_customization", reader.GetString("char"));

                    //API.Util.ConsoleOutput("7");
                    //player.TriggerEvent("csharp_LoadingCharacter");
                    player.TriggerEvent("csharp_LoadingCharacter");

                    player.SetSharedData("character_torso", reader.GetInt32("char_torso"));
                    player.SetSharedData("character_torso_texture", 0);
                    player.SetSharedData("character_undershirt", reader.GetInt32("char_undershirt"));
                    player.SetSharedData("character_undershirt_texture", reader.GetInt32("char_undershirt_texture"));
                    player.SetSharedData("character_leg", reader.GetInt32("char_leg"));
                    player.SetSharedData("character_leg_texture", reader.GetInt32("char_leg_texture"));
                    player.SetSharedData("character_feet", reader.GetInt32("char_feet"));
                    player.SetSharedData("character_feet_texture", reader.GetInt32("char_feet_texture"));
                    player.SetSharedData("character_shirt", reader.GetInt32("char_shirt"));
                    player.SetSharedData("character_shirt_texture", reader.GetInt32("char_shirt_texture"));
                    player.SetSharedData("character_mask", reader.GetInt32("char_mask"));
                    player.SetSharedData("character_mask_texture", reader.GetInt32("char_mask_texture"));
                    player.SetSharedData("character_armor", reader.GetInt32("char_armor"));
                    player.SetSharedData("character_armor_texture", reader.GetInt32("char_armor_texture"));

                    player.SetSharedData("character_hats", reader.GetInt32("character_hats"));
                    player.SetSharedData("character_hats_texture", reader.GetInt32("character_hats_texture"));
                    player.SetSharedData("character_glasses", reader.GetInt32("character_glasses"));
                    player.SetSharedData("character_glasses_texture", reader.GetInt32("character_glasses_texture"));
                    player.SetSharedData("character_ears", reader.GetInt32("character_ears"));
                    player.SetSharedData("character_ears_texture", reader.GetInt32("character_ears_texture"));
                    player.SetSharedData("character_watches", reader.GetInt32("character_watches"));
                    player.SetSharedData("character_watches_texture", reader.GetInt32("character_watches_texture"));
                    player.SetSharedData("character_bracelets", reader.GetInt32("character_bracelets"));
                    player.SetSharedData("character_bracelets_texutre", reader.GetInt32("character_bracelets_texutre"));
                    player.SetSharedData("character_accessories", reader.GetInt32("character_accessories"));
                    player.SetSharedData("character_accessories_texture", reader.GetInt32("character_accessories_texture"));

                    player.SetSharedData("character_helmet", reader.GetInt32("helmet"));
                    player.SetSharedData("character_helmet_texture", reader.GetInt32("helmet_texture"));

                    player.SetSharedData("character_tattoo_collection", reader.GetString("character_tattoo_collection"));
                    player.SetSharedData("character_tattoo_overlay", reader.GetString("character_tattoo_overlay"));
                    //player.SetSharedData("shortcut_0", reader.GetInt32("shortcut_0"));
                    //player.SetSharedData("shortcut_1", reader.GetInt32("shortcut_1"));
                    //player.SetSharedData("shortcut_2", reader.GetInt32("shortcut_2"));
                    //player.SetSharedData("shortcut_3", reader.GetInt32("shortcut_3"));
                    //player.SetSharedData("shortcut_4", reader.GetInt32("shortcut_4"));
                    //player.SetSharedData("shortcut_5", reader.GetInt32("shortcut_5"));
                    //player.SetSharedData("shortcut_6", reader.GetInt32("shortcut_6"));
                    //player.SetSharedData("shortcut_7", reader.GetInt32("shortcut_7"));
                    //player.SetSharedData("shortcut_8", reader.GetInt32("shortcut_8"));
                    //player.SetSharedData("shortcut_9", reader.GetInt32("shortcut_9"));

                    //API.Util.ConsoleOutput("10");
                    player.SetData("character_cellphone", reader.GetInt32("character_cellphone"));

                    player.SetData("connected_seconds", reader.GetInt32("connected_seconds"));

                    //API.Util.ConsoleOutput("11");
                    NAPI.Data.SetEntityData(player, "duty", reader.GetInt32("duty"));
                    // Default player data
                    player.SetData("Hunger", float.Parse(reader.GetString("hunger")));
                    player.SetData("Thirsty", float.Parse(reader.GetString("thirsty")));

                    player.SetData("ThirstyTimer", 0);
                    player.SetData("HungerTimer", 0);

                    string[] temp_mysql_data = reader.GetString("toggle_clothing").ToString().Replace(Translation.COORDS_FROM, Translation.COORDS_TO).Split('|');

                    player.SetData("clothes_neck", Convert.ToBoolean(Convert.ToInt32(temp_mysql_data[0])));
                    player.SetData("clothes_ears", Convert.ToBoolean(Convert.ToInt32(temp_mysql_data[1])));
                    player.SetData("clothes_watches", Convert.ToBoolean(Convert.ToInt32(temp_mysql_data[2])));
                    player.SetData("clothes_glasses", Convert.ToBoolean(Convert.ToInt32(temp_mysql_data[3])));
                    player.SetData("clothes_hats", Convert.ToBoolean(Convert.ToInt32(temp_mysql_data[4])));
                    player.SetData("clothes_shirt", Convert.ToBoolean(Convert.ToInt32(temp_mysql_data[5])));
                    player.SetData("clothes_armor", Convert.ToBoolean(Convert.ToInt32(temp_mysql_data[6])));
                    player.SetData("clothes_leg", Convert.ToBoolean(Convert.ToInt32(temp_mysql_data[7])));
                    player.SetData("clothes_feet", Convert.ToBoolean(Convert.ToInt32(temp_mysql_data[8])));
                    player.SetData("clothes_bag", Convert.ToBoolean(Convert.ToInt32(temp_mysql_data[9])));

                    //API.Util.ConsoleOutput("12");
                    player.SetData("LowHealthEffect", false);

                    //API.Util.ConsoleOutput("12.1");

                    cellphoneSystem.LoadContacts(player);
                    //API.Util.ConsoleOutput("12.2");
                    // ------------------

                    CharCreator.CharCreator.LoadCharacter(player, player.GetData("character_name"));

                    WeaponManage.LoadPlayerWeapons(player);
                    //API.Util.ConsoleOutput("12.3");
                    OnLoadCharacterData(player);
                    //API.Util.ConsoleOutput("12.4");

                    //API.Util.ConsoleOutput("13");

                    player.Health = reader.GetInt32("health");
                    API.Shared.SetPlayerArmor(player, reader.GetInt32("colete"));
                }
                //player.SendPictureNotificationToPlayer("CHAR_BLOCKED", "CHAR_BLOCKED", 0, 1, "Verbindung", $"Verbindung wird hergestellt!");
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Die Voice Verbindung wird hergestellt!", 5000);
                RAGEMP_TsVoice.Teamspeak.Connect(player, RAGEMP_TsVoice.Teamspeak.GetRandomString());
                //NAPI.ClientEvent.TriggerClientEvent(player, "SaltyChat_Initialize");
                //player.TriggerEvent("SaltyChat_Initialize");
            }
        }
    }
	
    private static byte RandomByte()
    {
        using (var random = new RNGCryptoServiceProvider())
        {
            var randomBytes = new byte[1];
            random.GetBytes(randomBytes);
            return randomBytes.Single();
        }
    }

    private static string RandomString(int length, string alphabet = "")
    {
        var outOfRange = byte.MaxValue + 1 - (byte.MaxValue + 1) & alphabet.Length;
        return string.Concat(
            Enumerable.Repeat(0, int.MaxValue).Select(e => RandomByte()).Where(randomByte => randomByte < outOfRange).Take(length).Select(randomByte => alphabet[randomByte & alphabet.Length]));
    }

    public static void SetPlayerLeader(Client player, int factionid)
    {
        NAPI.Data.SetEntityData(player, "character_leader", factionid);
        return;
    }

    public static void SetPlayerGroup(Client player, int factionid)
    {
        NAPI.Data.SetEntityData(player, "character_group", factionid);
        return;
    }

    public static void SetPlayerRank(Client player, int rankid)
    {
        NAPI.Data.SetEntityData(player, "character_group_rank", rankid);
        return;
    }

    public static void SetPlayerJob(Client player, int jobid)
    {
        NAPI.Data.SetEntityData(player, "character_job", jobid);
        return;
    }
    public static int GetPlayerJob(Client player)
    {
        return player.GetData("character_job");
    }

    public static int GetPlayerLeader(Client player)
    {
        return player.GetData("character_leader");
    }

    public static int GetPlayerGroup(Client player)
    {
        return player.GetData("character_group");
    }

    public static int GetPlayerRank(Client player)
    {
        return player.GetData("character_group_rank");
    }

    public static string GetCharacterName(Client player)
    {
        return player.GetData("character_name").Replace('_', ' ');
    }

    public static string Format_Name(string name)
    {
        return name.Replace('_', ' ');
    }

    public static bool GetPlayerConnected(Client player)
    {
        return player.GetData("status");

    }
    private static List<dynamic> spawn_one_positions = new List<dynamic>();

    public static Random spawn_first = new Random();

    public static void OnLoadCharacterData(Client player)
    {
        player.StopAnimation();
        player.TriggerEvent("logged");
        //player.TriggerEvent("logged");
        player.SetData("status", true);

        player.TriggerEvent("ps_DestroyCamera");
        TurfWar.CreatezoneForPlayer(player);
        PlayerVehicle.LoadPlayerVehicles(player);
        Inventory.LoadPlayerInventoryItens(player);
        NAPI.Player.SetPlayerName(player, player.GetData("character_name") + " (" + Main.getIdFromClient(player) + ")");
        Main.UpdateMoneyDisplay(player);
        Main.UpdatePlayerClothes(player);
        //bool show_menu = false;
        if (player.GetData("firstJoinned") == true)
        {
            NAPI.Entity.SetEntityPosition(player, new Vector3(-1105.8652, -2742.502, -7.410133));
            NAPI.Entity.SetEntityRotation(player, new Vector3(0, 0, -43.88814));
            NAPI.Entity.SetEntityDimension(player, 0);

            Random handrnd = new Random();
            int handprice = handrnd.Next(16000, 36250);

            Random bankrnd = new Random();
            int bankprice = bankrnd.Next(65000, 136500);

            Main.SetPlayerMoney(player, handprice);
            Main.SetPlayerMoneyBank(player, bankprice);

            player.ResetData("firstJoinned");

            CharCreator.CharCreator.SaveChar(player);
        }
        else
        {
            DateTime last_login = player.GetData("character_last_login");
            NAPI.Entity.SetEntityPosition(player, new Vector3(player.GetData("character_position_x"), player.GetData("character_position_y"), player.GetData("character_position_z")));
            NAPI.Entity.SetEntityRotation(player, new Vector3(0, 0, player.GetData("character_rotation_z")));
            NAPI.Entity.SetEntityDimension(player, (UInt32)player.GetData("character_dimension"));

            if (GetPlayerGroup(player) != 0 && FactionManage.faction_data[GetPlayerGroup(player)].faction_motd != "") NAPI.Notification.SendNotificationToPlayer(player, FactionManage.faction_data[GetPlayerGroup(player)].faction_motd);

            if (player.GetSharedData("character_hospital") > 0)
            {
                Main.sendToHospital(player, player.GetSharedData("InjuredTime"));
            }
            else if (NAPI.Data.GetEntityData(player, "character_prison") > 0)
            {
                Main.sendBackToPrison(player);
            }
            else if (player.GetData("character_ooc_prison_time") > 0)
            {
                adminCommands.SendBackToPrison(player);
            }
            else if (player.GetSharedData("Injured") == 1)
            {
                NAPI.Player.PlayPlayerAnimation(player, (int)(Main.AnimationFlags.Loop), "dead", "dead_d");

                NAPI.Task.Run(() =>
                {
                    NAPI.Player.PlayPlayerAnimation(player, (int)(Main.AnimationFlags.Loop), "dead", "dead_d");

                }, delayTime: 1000);

                player.SetSharedData("InjuredTime", 0);

                player.TriggerEvent("InjuredSystem", 120 * 10);
            }
            //else
            //{
            //    show_menu = true;

            //}

        }
        //API.Util.ConsoleOutput("[DEBUG OnLoadCharacterData]: ------- #11");
        if (GetPlayerAdmin(player) >= 1)
        {
            var players = NAPI.Pools.GetAllPlayers();
            foreach (var i in players)
            {
                if (i.GetData("status") == true && GetPlayerAdmin(i) > 0 && player != i)
                {
                    //NAPI.Notification.SendNotificationToPlayer(i, "Der Administrator ~b~" + GetCharacterName(player) + "~w~ hat sich gerade am Server angemeldet.");
                }
            }
        }

        //API.Util.ConsoleOutput("[DEBUG OnLoadCharacterData]: ------- #12");
        player.TriggerEvent("loadCaptureBlips");
        TurfWar.UpdateZoneBlipForAll();
        //player.TriggerEvent("screenFadeIn", 3000);

        UsefullyRP.UpdatePlayerKnows(player);
        UpdateBackpack(player);

        player.TriggerEvent("ps_DestroyCamera");
        NAPI.ClientEvent.TriggerClientEvent(player, "update_hunger_display", (int)player.GetData("Hunger"), (int)player.GetData("Thirsty"));
        player.TriggerEvent("SetPlayerWanted", player.GetData("character_wanted_level"));
        player.TriggerEvent("freeze", false);
        player.TriggerEvent("freezeEx", false);
        // Sky Camera #09.04.2020
        player.TriggerEvent("moveSkyCamera", player, "down");

        NAPI.Task.Run(() =>
        {
            TurfWar.UpdateZoneBlipForPlayer(player);
            player.TriggerEvent("showChat", true);
            player.TriggerEvent("show_player_hud", true);
            //player.TriggerEvent("show_radar");

            player.TriggerEvent("update_armor", player.Armor);

            if (cellphoneSystem.GetPlayerNumber(player) != 0)
            {

                player.TriggerEvent("initPhone");
                player.TriggerEvent("setPhoneNumber", cellphoneSystem.GetPlayerNumber(player));
                //NAPI.Util.ConsoleOutput("TELEFONE INICIADO !!");
            }

            player.SetData("DisplayRadar", false);
            player.TriggerEvent("UI:DisplayRadar", false);

        }, delayTime: 3500);
        player.TriggerEvent("setResistStage", 0);

    }

    public static void UpdateBackpack(Client player)
    {
        if (player.GetData("clothes_bag") == true)
        {
            if (player.GetData("character_backpack") == 1)
            {
                NAPI.Player.SetPlayerClothes(player, 5, 1, 0);
            }
            else if (player.GetData("character_backpack") == 2)
            {
                NAPI.Player.SetPlayerClothes(player, 5, 45, 0);
            }
            else if (player.GetData("character_backpack") == 3)
            {
                NAPI.Player.SetPlayerClothes(player, 5, 45, 0);
            }
            else NAPI.Player.SetPlayerClothes(player, 5, 0, 0);
        }
        else
        {
            NAPI.Player.SetPlayerClothes(player, 5, 0, 0);
        }
    }
    public static void CreateAccount(Client player, string username, string password)
    {
        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {

            Mainpipeline.Open();
            MySqlCommand query = Mainpipeline.CreateCommand();
            query.CommandType = CommandType.Text;
            query.CommandText = "SELECT * FROM `users` WHERE `username` = '" + player.SocialClubName + "' or `socialclubname` = '" + player.SocialClubName + "' ";
            query.ExecuteNonQuery();
            DataTable dt = new DataTable();
            using (MySqlDataAdapter da = new MySqlDataAdapter(query))
            {
                da.Fill(dt);
                int i = 0;
                i = Convert.ToInt32(dt.Rows.Count.ToString());
                //NAPI.Util.ConsoleOutput("[MySQL]: i count e igual: " + i + "");
                if (i == 0)
                {
                    string query2 = "INSERT INTO users (username, socialclubname, password, `FirstLogin`) VALUES (@username, @socialclubname, @password, @FirstLogin)";

                    MySqlCommand CreatNewAccount = new MySqlCommand(query2, Mainpipeline);

                    CreatNewAccount.Parameters.AddWithValue("@username", "" + player.SocialClubName + "");
                    CreatNewAccount.Parameters.AddWithValue("@socialclubname", "" + player.SocialClubName + "");
                    CreatNewAccount.Parameters.AddWithValue("@password", "" + password + "");
                    CreatNewAccount.Parameters.AddWithValue("@FirstLogin", DateTime.Now);

                    CreatNewAccount.ExecuteNonQuery();
                    LoadAccount(player, username);
                    player.TriggerEvent("clearLoginWindow");
                }
                else
                {
                    Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie haben bereits ein registriertes Konto!", 5000);

                }
            }
        }
    }

    public static void LoadAccount(Client player, string user)
    {
        Utils.ClearChat(player);
        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {
            Mainpipeline.Open();
            MySqlCommand query = new MySqlCommand("SELECT * FROM `users` WHERE `username` = '" + user + "';", Mainpipeline);
            using (MySqlDataReader reader = query.ExecuteReader())
            {

                string data2txt = string.Empty;
                string datatxt = string.Empty;

                while (reader.Read())
                {
                    if(reader.GetInt32("betaAcess") == 0)
                    {
                        player.TriggerEvent("Display_Whitelist_Screen");
                        //player.TriggerEvent("Display_Whitelist_Screen");
                        player.Kick();
                        return;
                    }

                    if (reader.GetInt32("banAces") == 0)
                    {
                        player.TriggerEvent("Display_Banned_Screen");
                        //player.TriggerEvent("Display_Banned_Screen");
                        player.Kick();
                        return;
                    }

                    NAPI.Data.SetEntityData(player, "player_sqlid", reader.GetInt32("id"));
                    NAPI.Data.SetEntityData(player, "player_username", reader.GetString("username"));
                    NAPI.Data.SetEntityData(player, "admin_level", reader.GetInt32("adminLevel"));
                    NAPI.Data.SetEntityData(player, "admin_name", reader.GetString("adminName"));

                    CharacterSelection(player);
                }
            }
        }
    }

    public static void CharacterSelection(Client player)
    {
        Random rnd = new Random();
        uint random_world = Convert.ToUInt32(rnd.Next(5, 500));

        NAPI.Entity.SetEntityDimension(player, random_world);

        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {
            Mainpipeline.Open();
            MySqlCommand query = new MySqlCommand("SELECT * FROM `characters` WHERE `userid` = '" + NAPI.Data.GetEntityData(player, "player_sqlid") + "'", Mainpipeline);

            using (MySqlDataReader reader = query.ExecuteReader())
            {
                string data2txt = string.Empty;
                string datatxt = string.Empty;

                ArrayList chars = new ArrayList();
                List<dynamic> menu_item_list = new List<dynamic>();
                int characters = 0;

                while (reader.Read())
                {
                    if (characters == 0)
                    {
                        menu_item_list.Add(new { ID = reader.GetInt32("id"), Name = reader.GetString("name"), Money = reader.GetInt32("money"), Bank = reader.GetInt32("bank"), CharacterKilled = reader.GetInt32("hospital"), LeftDead = reader.GetInt32("hospital"), Focus = true });
                        ClientPreviewCharacterID(player, reader.GetInt32("id"));
                    }
                    else menu_item_list.Add(new { ID = reader.GetInt32("id"), Name = reader.GetString("name"), Money = reader.GetInt32("money"), Bank = reader.GetInt32("bank"), CharacterKilled = reader.GetInt32("hospital"), LeftDead = reader.GetInt32("hospital"), Focus = false });
                    characters += 1;
                }

                player.TriggerEvent("Display_Characters", JsonConvert.SerializeObject(menu_item_list));
                player.Dimension = random_world;
                player.TriggerEvent("freeze", true);
                player.TriggerEvent("freezeEx", true);
                player.Position = new Vector3(-533.1306, -219.414, 37.64975);
                player.Rotation = new Vector3(0, 0, 177.7417);

                NAPI.Task.Run(() =>
                {
                    player.TriggerEvent("Show_Cursor");
                }, delayTime: 1500);
            }
        }
    }

    
    [RemoteEvent("SelectCharacter")]
    public static void SelectCharacter(Client player, int character_id)
    {
        if (player.HasData("waitLogando"))
        {
            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Einen Moment... Sie werden jetzt verbunden...", 5000);
            return;
        }
        player.SetData("waitLogando", true);

        player.TriggerEvent("freeze", true);
        player.TriggerEvent("freezeEx", true);

        player.TriggerEvent("Destroy_Character_Menu");
        // Sky Camera #09.04.2020
        player.TriggerEvent("moveSkyCamera", player, "up", 1, false);

        NAPI.Task.Run(() =>
        {
            LoadCharacter(player, character_id);
            player.ResetData("waitLogando");
        }, delayTime: 1000);
    }


    [RemoteEvent("CreateCharacter")]
    public static void CreateCharacter(Client player)
    {
        if (Main.g_mysql_get_characters_created(player) >= 2)
        {
            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie können nicht mehr als 2 Character haben..", 5000);
            //CharacterSelection(player);
        }
        else
        {
            player.TriggerEvent("freezeEx", true);
            player.TriggerEvent("freeze", true);
            player.TriggerEvent("Destroy_Character_Menu");
            player.TriggerEvent("ps_BodyCamera");
            CharCreator.CharCreator.SendToCreator(player);
        }
    }

    public static int GetPlayerSQLID(Client player)
    {
        return player.GetData("character_sqlid");
    }

    public static string GetPlayerNameFromSQL(int sqlid)
    {
        var players = NAPI.Pools.GetAllPlayers();
        foreach (var pl in players)
        {
            if (NAPI.Data.GetEntityData(pl, "character_sqlid") == sqlid)
            {
                return NAPI.Data.GetEntityData(pl, "character_name");
            }
        }
        return null;
    }

    public static int GetPlayerAdmin(Client player)
    {
        return NAPI.Data.GetEntityData(player, "admin_level");
    }

    public static void SetPlayerAdmin(Client player, int level)
    {
        NAPI.Data.SetEntityData(player, "admin_level", level);
    }

    public static void SetPlayerHunger(Client player, float hunger)
    {
        player.SetData("Hunger", player.GetData("Hunger") + hunger);
        if (player.GetData("Hunger") > 100)
        {
            player.SetData("Hunger", 100);
        }
        NAPI.ClientEvent.TriggerClientEvent(player, "update_hunger_display", (int)player.GetData("Hunger"), (int)player.GetData("Thirsty"));
    }

    public static void SetPlayerThirsty(Client player, float thirsty)
    {
        player.SetData("Thirsty", player.GetData("Thirsty") + thirsty);
        if (player.GetData("Thirsty") > 100)
        {
            player.SetData("Thirsty", 100);
        }
        NAPI.ClientEvent.TriggerClientEvent(player, "update_hunger_display", (int)player.GetData("Hunger"), (int)player.GetData("Thirsty"));
    }

    public static bool CheckEmailExist(string email)
    {
        var index = 0;

        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {
            Mainpipeline.Open();
            MySqlCommand query = new MySqlCommand("SELECT `email` FROM `users` WHERE `email` = '" + email + "'", Mainpipeline);
            using (MySqlDataReader reader = query.ExecuteReader())
            {
                while (reader.Read())
                {
                    index++;
                }
            }
        }
        if (index == 0)
        {
            return true;
        }
        else return false;
    }
}