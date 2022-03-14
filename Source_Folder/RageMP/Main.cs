/////////////////////////////////////////////////////
// GTA5 RP Script V7.0
/////////////////////////////////////////////////////
// © 2019 - 2021 DerStr1k3r. All rights reserved.
/////////////////////////////////////////////////////
using System;
using System.Timers;
using System.Collections.Generic;
using System.Threading;
using System.Net;
using System.IO;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Timer = System.Threading.Timer;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Data;
using GTANetworkAPI;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using DerStr1k3r.SDK;
using DerStr1k3r.Core;
using DerStr1k3r.Settings;


public class Main : Script
{
    private static nLog Log = new nLog("Main");

    public static string SERVER_NAME = "[GER/VOICE] xxx";
    public static string SERVER_SIGLA = "xxx";
    public static string SERVER_WEBSITE = "https://xxx";

    /// <summary>
    /// MySQL Connection
    /// </summary>
    /// 
    public static object MultipleActiveResultSets { get; private set; }
    public static string myConnectionString = "SERVER=localhost;DATABASE=ragesvr;UID=XXXXXXX;PASSWORD=XXXXXX;PORT=3308;SSL Mode=None;pooling = false;convert zero datetime=True";

    public static bool CANINE_SYSTEM = true;
    public static List<TimerEx> emote_timer = new List<TimerEx>();

    /// <summary>
    /// Dynamic Array Lists
    /// </summary>
    public static List<dynamic> prison_spawns = new List<dynamic>();
    public static List<dynamic> crime_list = new List<dynamic>();

    /// <summary>
    /// Variables
    /// </summary>
    public static List<Client> players = new List<Client>();
    public static Dictionary<Client, NetHandle> playerLabels = new Dictionary<Client, NetHandle>();
    public static bool[] admin_vehicle_spawned { get; set; } = new bool[20];
    public static Vehicle[] admin_vehicle { get; set; } = new Vehicle[20];
    public static int MAX_PLAYERS = 500;

    public static int HOSPITAL_TIME_EXECUTE = 15; //         Tempo kein Krankenhaus ohne Jogador oder Executado
    public static int HOSPITAL_TIME_DEFAULT = 15;  //             Zeit im Krankenhaus entfernen, wird der Spieler natürlich getötet
    public static float DEFAULT_VEHICLE_HEALTH = 500.0f;
    /// <summary>
    /// Door's Variables
    /// </summary>
    public int clothe_store_door_1, clothe_store_door_2, ammunation_pillbox_1, ammunation_pillbox_2, motorsport_parking_door1, motorsport_parking_door2, motorsport_main_door1, motorsport_main_door2, motorsport_right_office_door, motorsport_left_office_door, oficina_portao, oficina_porta;

    /// <summary>
    /// /Animmation Enum from Wiki
    /// </summary>
    [Flags]
    public enum AnimationFlags
    {
        Loop = 1 << 0,
        StopOnLastFrame = 1 << 1,
        OnlyAnimateUpperBody = 1 << 4,
        AllowPlayerControl = 1 << 5,
        Cancellable = 1 << 7
    }

    public Main()
    {
        Thread.CurrentThread.Name = "Main";

        NAPI.Server.SetAutoSpawnOnConnect(false);
        NAPI.Server.SetAutoRespawnAfterDeath(false);
    }

    // Uploade Server + Client
    public static List<dynamic> metalic_color_list = new List<dynamic>();
    public static List<dynamic> weapon_list = new List<dynamic>();
    public static List<dynamic> weather_list = new List<dynamic>();

    [ServerEvent(Event.ResourceStart)]
    public void OnResourceStart()
    {
        Environment.SetEnvironmentVariable("COMPlus_legacyCorruptedState­­ExceptionsPolicy", "1");

        for (var i = 0; i < MAX_PLAYERS; i++)
        {
            emote_timer.Add(null);
            cellphoneSystem.ringtone_time.Add(null);
            PlayerVehicle.vehicle_data.Add(new PlayerVehicle.VehicleEnum { id = i });
        }

        // Server Weather
        Server.Weather();

        foreach (var player in NAPI.Pools.GetAllPlayers())
        {
            NAPI.Player.SpawnPlayer(player, new Vector3(1482.36, 3587.45, 35.39));
        }

        // Tunuer Colors
        Server.TunerColors();

        // Server Weapons for the Player
        Server.Weapons();

        for (var i = 0; i < MAX_PLAYERS; i++)
        {
            players.Add(null);
        }

        // Server / Client IPLS
        Server.Client_IPLS();

        foreach (var player in NAPI.Pools.GetAllPlayers()) NAPI.Player.FreezePlayerTime(player, true);

        if (NAPI.Resource.HasSetting(this, "MAX_BUSINESS")) Business.MAX_BUSINESS = NAPI.Resource.GetSetting<int>(this, "MAX_BUSINESS");
        if (NAPI.Resource.HasSetting(this, "XP_RATE")) Economy.XP_RATE = NAPI.Resource.GetSetting<int>(this, "XP_RATE");
        if (NAPI.Resource.HasSetting(this, "XP_RATE_HOURLY")) Economy.XP_RATE = NAPI.Resource.GetSetting<int>(this, "XP_RATE_HOURLY");
        if (NAPI.Resource.HasSetting(this, "PRECO_MUNICAO_SNIPER")) Economy.PRECO_MUNICAO_SNIPER = NAPI.Resource.GetSetting<int>(this, "PRECO_MUNICAO_SNIPER");
        if (NAPI.Resource.HasSetting(this, "PRECO_MUNICAO_ASSAULT")) Economy.PRECO_MUNICAO_ASSAULT = NAPI.Resource.GetSetting<int>(this, "PRECO_MUNICAO_ASSAULT");
        if (NAPI.Resource.HasSetting(this, "PRECO_MUNICAO_SHOTGUN")) Economy.PRECO_MUNICAO_SHOTGUN = NAPI.Resource.GetSetting<int>(this, "PRECO_MUNICAO_SHOTGUN");
        if (NAPI.Resource.HasSetting(this, "PRECO_MUNICAO_PISTOL")) Economy.PRECO_MUNICAO_PISTOL = NAPI.Resource.GetSetting<int>(this, "PRECO_MUNICAO_PISTOL");
        if (NAPI.Resource.HasSetting(this, "PRECO_MUNICAO_SMG")) Economy.PRECO_MUNICAO_SMG = NAPI.Resource.GetSetting<int>(this, "PRECO_MUNICAO_SMG");
        if (NAPI.Resource.HasSetting(this, "SHIPMENT_BUSINESS_REESTOCK")) Economy.SHIPMENT_BUSINESS_REESTOCK = NAPI.Resource.GetSetting<int>(this, "SHIPMENT_BUSINESS_REESTOCK");
        if (NAPI.Resource.HasSetting(this, "HAMBURGUER")) Economy.HAMBURGUER = NAPI.Resource.GetSetting<int>(this, "HAMBURGUER");
        if (NAPI.Resource.HasSetting(this, "ENERGY_DRINK")) Economy.ENERGY_DRINK = NAPI.Resource.GetSetting<int>(this, "ENERGY_DRINK");
        if (NAPI.Resource.HasSetting(this, "TURF_WAR_VULNERABLE")) Economy.TURF_WAR_VULNERABLE = NAPI.Resource.GetSetting<int>(this, "TURF_WAR_VULNERABLE");
        if (NAPI.Resource.HasSetting(this, "PLAYER_TO_START_WAR")) Economy.PLAYER_TO_START_WAR = NAPI.Resource.GetSetting<int>(this, "PLAYER_TO_START_WAR");
        if (NAPI.Resource.HasSetting(this, "VEHICLE_RENT_FAGGIO")) Economy.VEHICLE_RENT_FAGGIO = NAPI.Resource.GetSetting<int>(this, "VEHICLE_RENT_FAGGIO");
        if (NAPI.Resource.HasSetting(this, "VEHICLE_RENT_ASEA")) Economy.VEHICLE_RENT_ASEA = NAPI.Resource.GetSetting<int>(this, "VEHICLE_RENT_ASEA");

        // Server Features
        Apfel.ApfelInit();
        Beer.BeerInit();
        Bergbau.BergbauInit();
        Blutwaschen.BlutwaschenInit();
        Ecstasy.EcstasyInit();
        Holz.HolzInit();
        Pelz.PelzInit();
        Penicillin.PenicillinInit();
        Traube.TraubeInit();
        Wodka.WodkaInit();
        Carwash.CarwashInit();
        PropylenCrafting.PropylenCraftingInit();
        Metall.MetallInit();
        Weed.WeedInit();
        Meth.MethInit();
        femaleClothes.ClothesInit();
        Hotel.HotelsInit();
        TattooShop.TattooInit();
        Business.BusinessInit();
        CarDealership.CarDealershipInit();
        FactionManage.FactionInit();
        WerehouseManage.WerehouseManageInit();
        GeneralStore.GeneralStoreInit();     
        FreeTimeStore.FreeTimeStoreInit();      
        JuveStore.JuveStoreInit();
        PhoneStore.PhoneStoreInit();
        DoorLock.DoorLockInit();
        Outfits.OutfitTester_Init();     
        RentVehicle.RentVehicleInit();
        Shipment.ShipmentInit();
        CallSystem.CallSystemInit();
        Garbage.GarbageInit();
        Ammunation.AmmunationInit();
        GarageSys.GarageSystemInit();
        EntraceSystem.EntraceSystemInit();
        HouseSystem.HouseSystemInit();
        SecreatsSystem.SecreatsSystemInit();
        AntiCheat.onAntiCheatUpdate();
        Fish.FishInit();

        // Server Blips
        Server.Server_Blips();

        // Server Markers
        Server.Server_Markers();

        prison_spawns.Add(new { position = new Vector3(1661.671, 2592.471, 45.56485), rotation = new Vector3(0, 0, 21.73181) });
        prison_spawns.Add(new { position = new Vector3(1662.752, 2615.52, 45.56486), rotation = new Vector3(0, 0, 83.67094) });
        prison_spawns.Add(new { position = new Vector3(1643.627, 2585.518, 45.56486), rotation = new Vector3(0, 0, 356.6671) });

        // Server / Player Crime List
        Server.Player_Crime_List();

        NAPI.Data.SetWorldData("announceTime", 1);
        
        //Timer initialisieren
        GlobalTime();
        OneHour();
        //WarTimer();
        UpdateTime();
        SyncTime();
        // Server Version
        Server.Server_Version();

        Console.WriteLine($"Main-Thread = {Thread.CurrentThread.ManagedThreadId}");
    }

    public static List<Client> GetPlayersInRadiusOfPosition(Vector3 position, float radius, uint dimension = 39999999)
    {
        List<Client> players = NAPI.Player.GetPlayersInRadiusOfPosition(radius, position);
        players.RemoveAll(P => !P.GetData("status"));
        players.RemoveAll(P => P.Dimension != dimension && dimension != 39999999);
        return players;
    }

    public static void GivePlayerEXP(Client player, int amount)
    {
        if (player.GetData("character_level") >= 0)
        {
            int new_level = (50 * (player.GetData("character_level")) * (player.GetData("character_level")) * (player.GetData("character_level")) - 150 * (player.GetData("character_level")) * (player.GetData("character_level")) + 600 * (player.GetData("character_level"))) / 5;

            player.TriggerEvent("updateRankBar", player.GetData("character_level"), new_level, player.GetData("character_exp"), player.GetData("character_exp") + amount, player.GetData("character_level"));

            player.SetData("character_exp", player.GetData("character_exp") + amount);

            if (player.GetData("character_exp") >= new_level)
            {
                int next_level = player.GetData("character_level") + 1;

                NAPI.Notification.SendNotificationToPlayer(player, "Glückwunsch, du hast bekommen~g~" + new_level.ToString("N0") + "~w~ mehr Erfahrung und bist aufgestiegen ~y~" + next_level + "~w~.");
                ShowColorShard(player, "~g~ERHALTE LEVEL", "Glückwunsch, du hast bekommen " + new_level.ToString("N0") + " mehr Erfahrung und bist aufgestiegen " + next_level + ".", 69, 10, 7000);
                player.SetData("character_level", player.GetData("character_level") + 1);
                GivePlayerEXP(player, -new_level);
            }
        }
    }

    [ServerEvent(Event.ResourceStop)]
    public void OnResourceStop()
    {
        var players = NAPI.Pools.GetAllPlayers();
        foreach (var player in players)
        {
            if (player.GetData("status") == true)
            {
                AccountManage.SaveCharacter(player);
            }
        }
    }

    [RemoteEvent("enableChatInput")]
    public void enableChatInput(Client player, bool toggle)
    {
        player.SetSharedData("enableChatInput", toggle);
    }

    [RemoteEvent("OnPlayerCreateWaypoint")]
    public void OnplayerCreateWaypoint(Client player, float x, float y, float z)
    {
        if (AccountManage.GetPlayerAdmin(player) > 0)
        {
            if (player.IsInVehicle && player.VehicleSeat == -1)
            {
                Vehicle vehicle = player.Vehicle;
                vehicle.Position = new Vector3(x, y, z);
                player.SetIntoVehicle(vehicle, -1);
                player.TriggerEvent("createNewHeadNotificationAdvanced", "Sie wurden  ~g~Erfolgreich~w~ teleportiert.");
            }
            else
            {
                player.Position = new Vector3(x, y, z);
                player.TriggerEvent("createNewHeadNotificationAdvanced", "Sie wurden  ~g~Erfolgreich~w~ teleportiert.");
            }
        }
    }


    [ServerEvent(Event.PlayerEnterColshape)]
    public void OnPlayerEnterColshape(ColShape shape, Client player)
    {

        if (player.GetData("status") == true)
        {
            Shipment.OnEnterReabastecimento(player, shape);
            //Mechanic.OnEnterDynamicArea(player, shape);
            CallSystem.OnEnterDynamicArea(player, shape);
            Shipment.OnEnterReabastecimento(player, shape);
            Garbage.OnEnterDynamicArea(player, shape);
            Farm.OnEnterDynamicArea(player, shape);
            //DriverLicense.OnEnterDynamicArea(player, shape);
            Police.OnEnterDynamicArea(player, shape);

            int houseid = 0;
            foreach (var house in HouseSystem.HouseInfo)
            {
                if (house.Shape == shape)
                {
                    NAPI.Data.SetEntityData(player, "HOUSEID", houseid);
                    NAPI.Data.SetEntityData(player, "INTERACTIONCHECK", 6);
                    Gopostal.GoPostal_onEntityEnterColShape(shape, player);
                    return;
                }
                houseid++;
            }

            var index = 0;
            foreach (var turf in TurfWar.turf_war)
            {
                if (shape == turf.areaid)
                {
                    player.SetData("player_in_turf", index);
                }
                index++;
            }
            index = 0;
            foreach (var business in Business.business_list)
            {
                if (shape == business.business_object_Area)
                {
                    NAPI.Data.SetEntityData(player, "player_in_business", index);
                }
                if (shape == business.business_marker_area)
                {
                    if (business.business_OwnerID != -1 && business.business_OwnerID == AccountManage.GetPlayerSQLID(player))
                    {
                        DisplaySubtitle(player, "Drücke ~y~E~w~ um das Firmenmenü zu öffnen", 3);
                    }
                }
                index++;
            }
            foreach (var werehouse in WerehouseManage.WereHouseData)
            {
                if (shape == werehouse.menuArea)
                {
                    DisplaySubtitle(player, "Drücke ~y~E~w~ um den Laptop öffnen", 3);
                }
            }
        }
    }

    [ServerEvent(Event.PlayerExitColshape)]
    public void OnPlayerExitColShape(ColShape shape, Client player)
    {
        ////NAPI.Util.ConsoleOutput("DEBUG: OnPlayerExitColShape ;;");
        if (player.GetData("status") == true)
        {
            foreach (var house in HouseSystem.HouseInfo)
            {
                if (house.Shape == shape)
                {
                    NAPI.Data.ResetEntityData(player, "HOUSEID");
                    NAPI.Data.SetEntityData(player, "INTERACTIONCHECK", 0);
                    Gopostal.GoPostal_onEntityEnterColShape(shape, player);
                    return;
                }
            }
            Shipment.OnExitReabastecimento(player, shape);
            CallSystem.OnLeaveDynamicArea(player, shape);
            Garbage.OnLeaveDynamicArea(player, shape);
            //Baustelle.OnLeaveDynamicArea(player, shape);
            Police.OnLeaveDynamicArea(player, shape);

            var index = 0;
            foreach (var business in Business.business_list)
            {
                if (shape == business.business_object_Area)
                {
                    NAPI.Data.SetEntityData(player, "player_in_business", -1);
                }
                if (shape == business.business_marker_area)
                {
                    player.TriggerEvent("BusinessPlayerMenuHide");
                    player.TriggerEvent("DealerShipMenuHide");
                }
                index++;
            }
            index = 0;
            foreach (var turf in TurfWar.turf_war)
            {
                if (shape == turf.areaid)
                {
                    player.SetData("player_in_turf", -1);
                }
                index++;
            }
        }
    }

    public static void DisplayRadar(Client player, bool toggle)
    {

        if (player.GetData("DisplayRadar") != toggle)
        {
            player.TriggerEvent("UI:DisplayRadar", toggle);
        }
        player.SetData("DisplayRadar", toggle);


    }

    [ServerEvent(Event.PlayerConnected)]
    public void OnPlayerConnected(Client player)
    {
        // Hotel System #09.04.2020
        player.SetData("character_hotel", -1);
        player.SetData("character_hotel_left", 0);
        player.SetData("InsideHotelID", -1);
        player.SetData("NativeUi_Menu", false);

        player.SetData("clothes_neck", true);
        player.SetData("clothes_ears", true);
        player.SetData("clothes_watches", true);
        player.SetData("clothes_glasses", true);
        player.SetData("clothes_hats", true);
        player.SetData("clothes_shirt", true);
        player.SetData("clothes_armor", true);
        player.SetData("clothes_leg", true);
        player.SetData("clothes_feet", true);
        player.SetData("clothes_bag", true);

        DisplayRadar(player, false);
        // Update 4 januar
        //player.TriggerEvent("check_client_csharp");
        //player.TriggerEvent("check_client_csharp");
        Main_Job.LoadDefaultData(player);

        player.Name = player.SocialClubName;
        player.SetSharedData("SubTitle", " ");

        player.SetData("using_inventory", false);
        player.SetData("view_vehicle", false);

        NAPI.World.SetTime(DateTime.Now.Hour, DateTime.Now.Minute, 0);

        int index = players.IndexOf(item: null);
        if (index != -1)
        {
            players[index] = player;
            player.SetSharedData("remoteID", index);
        }
        if (NAPI.Player.GetPlayerName(player) != player.SocialClubName)
        {
            Main.DisplaySubtitle(player, "ERROR: ~w~Bitte passen Sie Ihren Display-Namen in den Einstellungen an.");
            player.Kick("Bitte passen Sie Ihren Display-Namen in den Einstellungen an!");

            NAPI.Task.Run(() =>
            {
                player.Kick("Deine Einlog Zeit ist abgelaufen!");
            }, delayTime: 20000);

            return;
        }

        Zulassung.OnPlayerConnected(player);
        JobCenter.OnPlayerConnected(player);
        LOrder.OnPlayerConnected(player);
        Schlüsseldienst.OnPlayerConnected(player);
        XMR.OnPlayerConnected(player);

        player.SetData("admin_duty", 0);
        player.SetSharedData("admin_shared_name", 0);

        player.ResetData("school_tutorial");
        player.SetData("food_delivery", 0);
        player.SetSharedData("emoteTimeout", 0);
        player.SetSharedData("falando", false);
        player.SetData("handsup", false);
        player.SetData("connectSeconds", 0);
        player.SetData("character_cellphone", 0);
        player.TriggerEvent("RemoveAllBlips");
        player.SetSharedData("emoteText", "");

        player.SetData("shirt_enable", true);
        player.SetData("legs_enable", true);
        player.SetData("shoes_enable", true);

        player.SetData("phone_enable", false);

        // Props
        player.TriggerEvent("enableInteriorProp", 247297, "weed_growthf_stage3");
        player.TriggerEvent("enableInteriorProp", 247297, "weed_growthi_stage2");
        player.TriggerEvent("enableInteriorProp", 247297, "weed_growthh_stage3");
        player.TriggerEvent("enableInteriorProp", 247297, "weed_growthd_stage3");
        player.TriggerEvent("enableInteriorProp", 247297, "weed_growthc_stage2");
        player.TriggerEvent("enableInteriorProp", 247297, "weed_growthb_stage1");
        player.TriggerEvent("enableInteriorProp", 247297, "weed_drying");
        player.TriggerEvent("enableInteriorProp", 247297, "weed_chairs");
        player.TriggerEvent("enableInteriorProp", 247297, "weed_upgrade_equip");
        player.TriggerEvent("enableInteriorProp", 247297, "weed_production");
        player.TriggerEvent("enableInteriorProp", 247297, "weed_hosef");

        player.TriggerEvent("enableInteriorProp", 247553, "coke_cut_05");
        player.TriggerEvent("enableInteriorProp", 247553, "coke_press_upgrade");
        player.TriggerEvent("enableInteriorProp", 247553, "equipment_upgrade");
        player.TriggerEvent("enableInteriorProp", 247553, "production_upgrade");
        player.TriggerEvent("enableInteriorProp", 247553, "security_high");
        player.TriggerEvent("enableInteriorProp", 247553, "set_up");
        player.TriggerEvent("enableInteriorProp", 247553, "table_equipment_upgrade");


        player.TriggerEvent("enableInteriorProp", 247041, "meth_lab_setup");
        player.TriggerEvent("enableInteriorProp", 247041, "meth_lab_production");
        player.TriggerEvent("enableInteriorProp", 247041, "meth_lab_security_high");
        player.TriggerEvent("enableInteriorProp", 247041, "meth_lab_upgrade");

        player.TriggerEvent("enableInteriorProp", 246529, "cash_large");
        player.TriggerEvent("enableInteriorProp", 246529, "coke_large");
        player.TriggerEvent("enableInteriorProp", 246529, "counterfeit_large");
        player.TriggerEvent("enableInteriorProp", 246529, "id_large");
        player.TriggerEvent("enableInteriorProp", 246529, "meth_large");
        player.TriggerEvent("enableInteriorProp", 246529, "weed_large");

        player.TriggerEvent("enableInteriorProp", 246273, "cash_stash3");
        player.TriggerEvent("enableInteriorProp", 246273, "coke_stash3");
        player.TriggerEvent("enableInteriorProp", 246273, "counterfeit_stash3");
        player.TriggerEvent("enableInteriorProp", 246273, "weed_stash3");
        player.TriggerEvent("enableInteriorProp", 246273, "id_stash3");
        player.TriggerEvent("enableInteriorProp", 246273, "meth_stash3");

        player.TriggerEvent("enableInteriorProp", 252673, "branded_style_set");
        player.TriggerEvent("enableInteriorProp", 252673, "car_floor_hatch");
        player.TriggerEvent("enableInteriorProp", 252673, "door_blocker");

        player.TriggerEvent("screenFadeIn", 1000);
        player.TriggerEvent("getPedOverlay");
        //player.TriggerEvent("getPedOverlay");
        player.SetData("SpeedLimit", false);
        player.SetData("SpeedLimitValue", 0);
        player.SetData("globalBrowser", false);
        player.SetData("displayMessage_Timer", -1);

        ResetSQLData(player);
        player.SetSharedData("DisableExitVehicle", false);
        player.SetSharedData("DisableVehicleMove", false);
        player.SetData("StartEngineStatus", false);

        for (int i = 0; i < MAX_PLAYERS; i++)
        {
            cellphoneSystem.contacts_data.Add(new cellphoneSystem.ContactEnum { id = i });

            displat_text_timer[i] = null;
        }

        for (int i = 0; i < 60; i++)
        {
            cellphoneSystem.contacts_data[getIdFromClient(player)].contact_name[i] = null;
            cellphoneSystem.contacts_data[getIdFromClient(player)].contact_number[i] = 0;
        }

        player.TriggerEvent("setResistStage", 0);
        player.SetData("shipment", false);

        PlayerVehicle.ResetPlayerVehicleData(player);
        Inventory.ResetInventoryVariables(player);
        //WeaponManage.ResetAllPlayerWeaponDataEx(player);

        player.SetData("status", false);
        player.SetSharedData("Injured", 0);
        player.SetData("player_in_turf", -1);
        player.SetData("StartingTurf", false);
        player.SetData("ViewScoreboardTurf", false);
        player.SetData("group_invite", -1);
        player.SetData("group_inviteBy", -1);
        player.SetData("firstJoinned", false);
        //NAPI.Util.ConsoleOutput(" >>>>>> -- onconnect -- 44");

        player.SetData("playerCuffed", 0);
        player.SetData("General_CEF", false);

        NAPI.Data.SetEntityData(player, "ShowTextForPlayer", -1);
        NAPI.Data.SetEntityData(player, "LastTransaction", -1);
        NAPI.Data.SetEntityData(player, "player_in_business", -1);
        NAPI.Data.SetEntityData(player, "MainProgressBar", false);
        NAPI.Data.SetEntityData(player, "MainProgressText", false);
        NAPI.Data.SetEntityData(player, "TurfProgressBar", false);
        NAPI.Data.SetEntityData(player, "Handsup", false);
        //NAPI.Util.ConsoleOutput(" >> CONNECT >> " + player.GetData("player_in_turf") + "");
        player.SetData("inHelp", false);
        player.SetData("IsAnyMenuOpen", false);

        player.SetData("jobDuty", 0);

        player.SetData("mechanic_color", 0);
        player.SetData("MechOfferBy", -1);
        player.SetData("MechOfferPrice", 0);
        player.SetData("repaingPendent", false);

        player.SetData("player_teleport", false);

        player.SetData("TaxiFee", 0);

        player.SetData("player_garbage_attach", false);

        //player.SetData("player_baustelle_attach", false);

        player.SetData("garbage_id", -1);

        //player.SetData("baustelle_id", -1);

        player.SetData("in_meth_area", false);

        player.SetData("curar_offerBy", -1);
        player.SetData("curar_offerPrice", 0);

        player.Dimension = (uint)getIdFromClient(player);

        OnPlayerFinishedDownloadHandler(player);

        CanineSystem.OnPlayerConnect(player);
        WeaponManage.OnPlayerConnect(player);
        ATMSystem.OnPlayerConnect(player);
        //DrillCrafting.OnPlayerConnect(player);
        PropylenCrafting.OnPlayerConnect(player);
        Apfel.OnPlayerConnect(player);
        Beer.OnPlayerConnect(player);
        Bergbau.OnPlayerConnect(player);
        Blutwaschen.OnPlayerConnect(player);
        Ecstasy.OnPlayerConnect(player);
        Holz.OnPlayerConnect(player);
        Pelz.OnPlayerConnect(player);
        Penicillin.OnPlayerConnect(player);
        Traube.OnPlayerConnect(player);
        Wodka.OnPlayerConnect(player);
        Metall.OnPlayerConnect(player);
        RobberyNPC.OnPlayerConnect(player);
        bankRobbery.OnPlayerConnect(player);
        Inventory.OnPlayerConnected(player);
        player.SetData("inEffect_weed", -1);
        player.SetData("inEffect_heroin", -1);
        player.SetData("Global_Browser", false);

        for (int i = 0; i < 10; i++)
        {
            player.SetData("animation_shortcut_dict_" + i, "");
            player.SetData("animation_shortcut_state_" + i, "");
            player.SetData("animation_shortcut_flag_" + i, 0);
        }

        player.SetData("Enable_K_Menu", false);
    }

    [ServerEvent(Event.PlayerDisconnected)]
    public void OnPlayerDisconnected(Client player, DisconnectionType type, string reason)
    {
        if (player.GetData("status") == true)
        {
            try
            {
                if (Fish.fishTimer[getIdFromClient(player)] != null)
                {
                    Fish.fishTimer[getIdFromClient(player)].Kill();
                    Fish.fishTimer[getIdFromClient(player)] = null;
                }
            }
            catch (Exception)
            {

            }
            //NAPI.Data.SetEntitySharedData(player, "VOICE_RANGE", "Weit");
            cellphoneSystem.FinishCall(player);
            PlayerVehicle.OnFlagVehicle(player);
            

            if (player.GetData("Refinando") == true)
            {
                if (Main_Job.job_timer[Main.getIdFromClient(player)] != null)
                {
                    Main_Job.job_timer[Main.getIdFromClient(player)].Kill();
                    Main_Job.job_timer[Main.getIdFromClient(player)] = null;
                }
                player.SetData("Refinando", false);
            }

            WeaponManage.SaveWeapons(player);

            if (player.HasData("startEditing") && player.HasData("startFurnitureEditing_house") && player.GetData("startEditing") == true)
            {
                HouseSystem.UpdateFurniture(player.GetData("startFurnitureEditing_house"));
                player.SetData("startFurnitureEditing", false);
            }
            try
            {
                Bus.onPlayerDissconnectedHandler(player, type, reason);
                Gopostal.onPlayerDisconnected(player, type, reason);
                Lawnmower.onPlayerDissconnectedHandler(player, type, reason);
                Farm.onPlayerDissconnectedHandler(player, type, reason);
                AccountManage.SaveCharacter(player);
                PlayerVehicle.AUTO_SAVE_Vehicle(player);
                PlayerVehicle.ResetPlayerVehicleData(player);
                CanineSystem.OnPlayerDisconnected(player);
                Inventory.OnPlayerDisconnect(player);
                Police.Call_OnDisconect(player);
                Services.Remove_Service(player);
            }
            catch (Exception e) { }

            // Update 4 januar
            //InteractMenu_New.Reset_ClientSide_Variable(player);
            player.ResetData("AnimationMenu");

            if (player.HasData("Refueling"))
            {
                player.ResetData("Refueling");
            }

            player.ResetSharedData("DisableExitVehicle");
            player.ResetSharedData("DisableVehicleMove");

            player.SetData("StartingTurf", false);
            NAPI.Data.SetEntityData(player, "player_in_business", -1);
            player.SetData("player_in_turf", -1);

            player.SetData("group_inviteBy", -1);
            player.SetData("group_invite", -1);

            player.SetData("status", false);
        }

        int index = players.IndexOf(player);
        if (index != -1)
        {
            players[players.IndexOf(player)] = null;
        }
    }

    public static string EMBED_WHITE = "<font color='#ffffff'>";
    public static string EMBED_GREY = "<font color='#999999'>";
    public static string EMBED_YELLOW = "<font color='#EDD415'>";
    public static string EMBED_ORANGE = "<font color='#FF9924'>";
    public static string EMBED_RED = "<font color='#FF0400'>";
    public static string EMBED_LIGHTRED = "<font color='#F55653'>";
    public static string EMBED_GREEN = "<font color='#1AC211'>";
    public static string EMBED_LIGHTGREEN = "<font color='#72DB4F'>";
    public static string EMBED_LIGHTBLUE = "<font color='#3973FA'>";
    public static string EMBED_BLUE = "<font color='#2F84FA'>";
    public static string EMBED_CYAN = "<font color='#05E7EB'>";
    public static string EMBED_PINK = "<font color='#FF6EE4'>";
    public static string EMBED_SERVER = "<font color='#009999'>";
    public static string EMBED_ROLEPLAY = "<font color='#C2A2DA'>";
    //public static string EMBED_VIP = "<font color='#E8F28A'>";

    // From SA-MP
    public static string EMBED_GROVE = "<font color='#00D000'>";
    public static string EMBED_BALLAS = "<font color='#00D000'>";
    public static string EMBED_VAGOS = "<font color='#FBDC04'>";
    public static string EMBED_AZTECAS = "<font color='#01FCFF'>";
    public static string EMBED_SANNEWS = "<font color='#E9B6B7'>";

    public static string EMBED_REPORT = "<font color='#ED8C37'>";
    public static string EMBED_CELLPHONE = "<font color='#E1EAED'>";
    public static string EMBED_CELLPHONE_2 = "<font color='#B0D4C1'>";


    public static string EMBED_NOOB_1 = "<font color='#009999'>";
    public static string EMBED_NOOB_2 = "<font color='#009966'>";



    [RemoteEvent("ServerChat")]
    public void OnChatMessage(Client player, string message)
    {
        if (player.GetData("status") == false)
        {
            return;
        }
        List<Client> proxPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(18, player);
        foreach (Client target in proxPlayers)
        {

            foreach (var call in cellphoneSystem.call_data)
            {
                if (call.active == 2)
                {
                    return;
                }
            }

            if (player.GetData("admin_duty") == 1)
            {
                NAPI.Notification.SendNotificationToPlayer(target, "~n~sagt: " + message + "");
            }
            else
            {
                if (UsefullyRP.mask[Main.getIdFromClient(player)])
                {
                    //NAPI.Notification.SendNotificationToPlayer(target, "<C>Maskiert: " + AccountManage.GetPlayerSQLID(player) + "</C> ~n~sagt: " + message + "");
                    //target.TriggerEvent("Send_ToChat", "", "Maskiert" + AccountManage.GetPlayerSQLID(player) + " " + EMBED_GREY + " sagt:" + EMBED_WHITE + "", message);
                }
                else
                {
                    bool can_pass = true;
                    for (int index = 0; index < Main.MAX_PLAYERS; index++)
                    {
                        if (target.GetSharedData("know_player_" + index) == AccountManage.GetPlayerSQLID(player))
                        {
                            can_pass = false;
                        }
                    }
                }
            }
        }
    }

    public static Vector3 GetPositionInFrontOfPlayer(Client client, int distance)
    {
        float direction = client.Rotation.Z;
        Vector3 position = client.Position;

        if (direction <= 22.5 || direction > 337.5)
        {
            //Norden
            position.Y += distance;
        }
        else if (direction <= 67.5 && direction > 22.5)
        {
            //Nordwesten
            position.X -= distance;
            position.Y += distance;
        }
        else if (direction <= 112.5 && direction > 67.5)
        {
            //Westen
            position.X -= distance;
        }
        else if (direction <= 157.5 && direction > 112.5)
        {
            //Südwesten
            position.X -= distance;
            position.Y -= distance;
        }
        else if (direction <= 202.5 && direction > 157.5)
        {
            //Süden
            position.Y -= distance;
        }
        else if (direction <= 247.5 && direction > 202.5)
        {
            //SüdOst
            position.X += distance;
            position.Y -= distance;
        }
        else if (direction <= 292.5 && direction > 247.5)
        {
            //Osten
            position.X += distance;
        }
        else if (direction <= 337.5 && direction > 292.5)
        {
            //NordOst
            position.X += distance;
            position.Y += distance;
        }
        return position;
    }

    public static void NotifyMessageSend(Client client, NotifyType type, NotifyPosition pos, string msg, int time)
    {
        Trigger.ClientEvent(client, "notify", type, pos, msg, time);
        //NAPI.Notification.SendNotificationToPlayer(player,"" + EMBED_LIGHTRED + "Hinweis" + EMBED_WHITE + " : " + message);
    }

    public static void SendMessageToPlayer(Client player, string message)
    {
        NAPI.Notification.SendNotificationToPlayer(player,message);
    }

    public static void SendMessageToAll(string message)
    {
        foreach (var player in NAPI.Pools.GetAllPlayers())
        {
            NAPI.Notification.SendNotificationToAll(message);
        }
    }

    public static void SendMessageWithTagToPlayer(Client player, string tag, string message)
    {
        NAPI.Notification.SendNotificationToPlayer(player,tag + EMBED_WHITE + " " + message);
    }

    public static void SendMessageWithTagToAll(string tag, string message)
    {
        foreach (var player in NAPI.Pools.GetAllPlayers())
        {
            NAPI.Notification.SendNotificationToPlayer(player,tag + EMBED_WHITE + " " + message);
        }
    }

    public static void SendInfoMessage2(Client player, string message, string msg)
    {
        NAPI.Notification.SendNotificationToPlayer(player, message);
        //NAPI.Notification.SendNotificationToPlayer(player,"" + EMBED_ORANGE + "Info" + EMBED_WHITE + " : " + message);
    }

    public static void SendInfoMessage(Client player, string message)
    {
        NAPI.Notification.SendNotificationToPlayer(player, message);
        //NAPI.Notification.SendNotificationToPlayer(player,"" + EMBED_ORANGE + "Info" + EMBED_WHITE + " : "+ message);
    }

    public static void SendWarningMessage(Client player, string message)
    {
        NAPI.Notification.SendNotificationToPlayer(player, message);
        //NAPI.Notification.SendNotificationToPlayer(player,"" + EMBED_LIGHTRED + "Hinweis" + EMBED_WHITE + " : " + message);
    }

    public static void SendSuccessMessage(Client player, string message)
    {
        NAPI.Notification.SendNotificationToPlayer(player, message);
        //NAPI.Notification.SendNotificationToPlayer(player,"" + EMBED_GREEN + "Erfolgreich" + EMBED_WHITE + " : " + message);
    }

    public static void SendErrorMessage(Client player, string message)
    {
        NAPI.Notification.SendNotificationToPlayer(player, message);
        //NAPI.Notification.SendNotificationToPlayer(player,"" + EMBED_RED + "Error" + EMBED_WHITE + " : "+  message);
    }

    [ServerEvent(Event.VehicleTrailerChange)]
    public void OnVehicleTrailerChange(Vehicle vehicle, Vehicle trailer)
    {
        Shipment.OnVehicleTrailerChangeHandler(vehicle, trailer);
        //Code
    }

    public static void AttachObjectToEntity(string objectName, int EntityId, int boneId)
    {
        NAPI.ClientEvent.TriggerClientEventForAll("Object.AttachTo", objectName, EntityId, boneId);
    }

    public static void DeleteAttachedObject(Client client)
    {
        NAPI.ClientEvent.TriggerClientEventForAll("Object.Delete", client.Value);
    }


    [ServerEvent(Event.VehicleDeath)]
    public void OnVehicleDeath(Vehicle vehicle)
    {
        foreach (var ls in LSCustom.ls_custom)
        {
            if (ls.in_use == true && ls.vehicle == vehicle)
            {
                LSCustom.ResetVehicle_Customization_Temp(vehicle);
                ls.in_use = false;
                ls.vehicle = null;
                ls.label_position.Text = Translation.ls_custom_label_free;
                vehicle.ResetData("lscustom_use");
            }
        }

        if (NAPI.Data.HasEntityData(vehicle, "shipment_business"))
        {
            var players = NAPI.Pools.GetAllPlayers();
            foreach (var player in players)
            {
                if (player.GetData("status") == true)
                {
                    try
                    {
                        if (Main_Job.job_vehicle[Main.getIdFromClient(player)] == vehicle)
                        {
                            player.TriggerEvent("blip_remove", "LKW Fahrer");
                            player.TriggerEvent("delete_marker");

                            player.SetData("shipment", false);

                            int business_id = NAPI.Data.GetEntityData(vehicle, "shipment_business");
                            if (Business.business_list[business_id].business_OrderState > 1)
                            {
                                Business.business_list[business_id].business_OrderState = 1;
                            }

                            Main_Job.job_vehicle[Main.getIdFromClient(player)] = null;
                        }
                    }
                    catch (Exception)
                    {
                        NAPI.Util.ConsoleOutput("Não encontrou veiculo de empresa.");
                    }
                }
            }
        }

        int faction_id = 0;
        foreach (var faction in FactionManage.faction_data)
        {
            for (int i = 0; i < FactionManage.MAX_FACTION_VEHICLES; i++)
            {
                if (FactionManage.faction_data[faction_id].faction_vehicle_name[i] != "Niemand")
                {
                    try
                    {
                        if (/*FactionManage.faction_data[faction_id].faction_vehicle_entity[i].Exists && */
                            FactionManage.faction_data[faction_id].faction_vehicle_entity[i] == vehicle)
                        {
                            FactionManage.faction_data[faction_id].faction_vehicle_name[i] = "Frei";
                            FactionManage.faction_data[faction_id].faction_vehicle_owned[i] = "Niemand";
                            FactionManage.faction_data[faction_id].faction_vehicle_entity[i] = null;
                        }
                    }
                    catch (Exception)
                    {
                        //NAPI.Util.ConsoleOutput("[EXCEPTION]: OnVehicle Death - Faction Vehicles");
                    }
                }
            }
            faction_id++;
        }

        VehicleInventory.RemoveVehicleInventory(vehicle);

        NAPI.Data.ResetEntityData(vehicle, "vehicle_colision");
        NAPI.Data.ResetEntityData(vehicle, "engine_status");

        for (int i = 0; i < RentVehicle.MAX_RENT_VEHICLES; i++)
        {
            if (RentVehicle.vehicle_rent_list[i].vehicle_free == true)
            {
                if (vehicle == RentVehicle.vehicle_rent_list[i].vehicle_entity)
                {
                    RentVehicle.vehicle_rent_list[i].vehicle_free = false;
                    RentVehicle.vehicle_rent_list[i].vehicle_ownedBy = -1;
                    NAPI.Data.SetEntityData(vehicle, "vehicle_entity", -1);
                }
            }
        }

        for (int i = 0; i < 20; i++)
        {
            if (vehicle == admin_vehicle[i])
            {
                admin_vehicle_spawned[i] = false;

            }
        }

        for (int index = 0; index < PlayerVehicle.MAX_PLAYER_VEHICLES; index++)
        {
            var players = NAPI.Pools.GetAllPlayers();
            foreach (var player in players)
            {
                if (player.GetData("status") == true)
                {
                    try
                    {
                        if (vehicle == PlayerVehicle.vehicle_data[Main.getIdFromClient(player)].handle[index])
                        {
                            PlayerVehicle.vehicle_data[Main.getIdFromClient(player)].state[index] = 0;
                            PlayerVehicle.SavePlayerVehicle(player, index);
                            Main.SendInfoMessage(player, "Dein " + EMBED_LIGHTGREEN + PlayerVehicle.vehicle_data[Main.getIdFromClient(player)].model[index] + EMBED_WHITE + " wurde zerstört und wird an den ACLS geschickt..");
                        }
                    }
                    catch (Exception)
                    {
                        //NAPI.Util.ConsoleOutput("[EXCEPTION]: OnVehicle Death - Player Vehicles");
                    }
                }
            }
        }

        if (NAPI.Data.GetEntityData(vehicle, "RESPAWNABLE") == true)
        {
            NAPI.Task.Run(() =>
            {
                var color1 = NAPI.Vehicle.GetVehiclePrimaryColor(vehicle);
                var color2 = NAPI.Vehicle.GetVehicleSecondaryColor(vehicle);
                var model = NAPI.Entity.GetEntityModel(vehicle);

                var spawnPos = NAPI.Data.GetEntityData(vehicle, "SPAWN_POS");
                var spawnH = NAPI.Data.GetEntityData(vehicle, "SPAWN_ROT");

                NAPI.Entity.DeleteEntity(vehicle);

                var respawnCar = NAPI.Vehicle.CreateVehicle((VehicleHash)model, spawnPos, new Vector3(0, 0, spawnH), color1, color2);
                NAPI.Vehicle.SetVehicleEngineStatus(respawnCar, false);
                // You can also add more things, like vehicle modifications, number plate, etc.	
                NAPI.Data.SetEntityData(respawnCar, "RESPAWNABLE", true);
                NAPI.Data.SetEntityData(respawnCar, "SPAWN_POS", spawnPos);
                NAPI.Data.SetEntityData(respawnCar, "SPAWN_ROT", spawnH);
            }, delayTime: 30000);

        }
        else
        {
            NAPI.Task.Run(() =>
            {
                NAPI.Entity.DeleteEntity(vehicle);
            }, delayTime: 30000);
        }
    }
    

    [ServerEvent(Event.PlayerEnterVehicle)]
    public void OnPlayerEnterVehicle(Client player, Vehicle vehicle, sbyte seatID)
    {
        DisplayRadar(player, true);
        //NAPI.Util.ConsoleOutput("OnPlayerEnterVehicle, " + seatID + "");
        if (vehicle.Class == 8)
        {
            Main.SendInfoMessage(player, "Drücke " + EMBED_LIGHTGREEN + "O" + EMBED_WHITE + " um den Helm aufsetzen.");
        }
        else if (vehicle.Class != 13)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Drücke O um dich anzuschnallen.");
            //Main.SendInfoMessage(player, "Benutze " + EMBED_LIGHTGREEN + "/cinto" + EMBED_WHITE + " um dich anzuschnallen.");
        }

        for (int index = 0; index < PlayerVehicle.MAX_PLAYER_VEHICLES; index++)
        {
            if (NAPI.Data.HasEntityData(player, "character_data_vehicle_" + index + "_handle") && NAPI.Data.HasEntityData(player, "character_data_vehicle_" + index + "_ticket"))
            {
                if (vehicle == NAPI.Data.GetEntityData(player, "character_data_vehicle_" + index + "_handle"))
                {
                    if (Convert.ToInt32(NAPI.Data.GetEntityData(player, "character_data_vehicle_" + index + "_ticket")) > 0)
                    {
                        NAPI.Notification.SendNotificationToPlayer(player, "Das ist dein ~y~" + NAPI.Data.GetEntityData(player, "character_data_vehicle_" + index + "_model") + "~w~ das wird bestraft ~g~$" + NAPI.Data.GetEntityData(player, "character_data_vehicle_" + index + "_ticket").ToString("N0") + "~w~,gehe zum ~b~DP~w~zahle es");
                    }
                }
            }
        }

        if (NAPI.Vehicle.GetVehicleEngineStatus(vehicle) == false)
        {
            DisplaySubtitle(player, "Der Motor dieses Fahrzeugs ist ausgeschaltet ~w~, drücken Sie( ~y~O~w~ ) ", 3);
        }
    }

    [ServerEvent(Event.PlayerEnterVehicleAttempt)]
    public void OnPlayerEnterVehicleAttempt(Client player, Vehicle vehicle, sbyte seatID)
    {
        //NAPI.Util.ConsoleOutput("OnPlayerEnterVehicleAttempt, " + seatID + "");
        // player.TriggerEvent("VehStream_PlayerEnterVehicleAttempt", vehicle);
    }

    [ServerEvent(Event.PlayerExitVehicle)]
    public void OnPlayerExitVehicleHandler(Client player, Vehicle vehicle)
    {
        DisplayRadar(player, false);
        Garbage.OnPlayerExitVehicleHandler(player, vehicle);
        if (player.HasData("ls_customs"))
        {
            for (int i = 0; i < 68; i++)
            {
                vehicle.SetMod(i, player.GetData("lscustom_mod_" + i));
            }

            vehicle.PrimaryColor = player.GetData("lscustom_color_1");
            vehicle.SecondaryColor = player.GetData("lscustom_color_2");
            vehicle.NeonColor = player.GetData("lscustom_neon_color");

            player.ResetData("ls_customs");
            player.ResetData("lscustom_neon_color");
            player.ResetData("lscustom_color_1");
            player.ResetData("lscustom_color_2");
            for (int i = 0; i < 68; i++)
            {
                player.ResetData("lscustom_mod_" + i);
            }
            Main.DisplaySubtitle(player, " ");

            player.TriggerEvent("freeze", false);
            player.TriggerEvent("freezeVehicle", false);
            player.SetSharedData("DisableVehicleMove", false);
        }
        // //NAPI.Util.ConsoleOutput("##################### 0");
        if (NAPI.Data.HasEntityData(vehicle, "TransportDuty") && NAPI.Data.GetEntityData(vehicle, "TransportDuty") == true)
        {
            //  //NAPI.Util.ConsoleOutput("##################### 1");
            if (player.VehicleSeat == -1)
            {
                NAPI.Notification.SendNotificationToPlayer(player,"~y~*~w~ Du hast das Taxi verlassen, du hast insgesamt~g~$" + NAPI.Data.GetEntityData(vehicle, "TransportFee").ToString("N0") + "~w~ für die Fahrt bezahlt.");
                //Main.GivePlayerMoney(player, NAPI.Data.GetEntityData(vehicle, "TransportFee"));

                // //NAPI.Util.ConsoleOutput("##################### 2");
                var players_in_vehicle = NAPI.Pools.GetAllPlayers();
                foreach (var i in players_in_vehicle)
                {
                    if (vehicle == i.Vehicle && i.GetData("TaxiFee") > 0)
                    {
                        Main.GivePlayerMoney(i, -i.GetData("TaxiFee"));
                        i.SetData("TaxiFee", 0);
                        i.SendChatMessage("~y~*~w~Der Taxifahrer hat das Taxi verlassen, Sie haben den Taxifahrer ~g~$" + i.GetData("TaxiFee").ToString("N0") + "~w~ bezahlt.");
                        i.TriggerEvent("update_taxi_fare", false, 0, 0, false);
                    }
                }

                NAPI.Data.SetEntityData(vehicle, "TransportDuty", false);
                NAPI.Data.SetEntityData(vehicle, "TransportPrice", 0);
                NAPI.Data.SetEntityData(vehicle, "TransportFee", 0);
                NAPI.Data.SetEntityData(vehicle, "TransportTime", 0);
                // //NAPI.Util.ConsoleOutput("##################### 3");

            }
            else
            {
                // //NAPI.Util.ConsoleOutput("##################### 4");
                if (player.GetData("TaxiFee") > 0)
                {
                    NAPI.Notification.SendNotificationToPlayer(player,"~y~*~w~ Sie haben das Taxi verlassen und bezahlen ~g~$" + player.GetData("TaxiFee").ToString("N0") + "~w~ den Taxifahrer.");
                    GivePlayerMoney(player, -player.GetData("TaxiFee"));

                    if (vehicle.HasData("TransportDriver"))
                    {
                        Client target = vehicle.GetData("TransportDriver");

                        if (API.Shared.IsPlayerConnected(target) && target.GetData("status") == true)
                        {
                            Main.GivePlayerMoney(target, player.GetData("TaxiFee"));
                            Main.SendSuccessMessage(target, "~y~*~w~ " + UsefullyRP.GetPlayerNameToTarget(player, target) + " hat das Taxi verlassen, Sie haben eine Zahlung von erhalten " + player.GetData("TaxiFee") + "nach Kilometer.");
                        }
                    }
                    // //NAPI.Util.ConsoleOutput("##################### 5");

                    player.TriggerEvent("update_taxi_fare", false, 0, 0, false);
                }
                else DisplayErrorMessage(player, "~w~Sie können es sich nicht leisten, dem Taxifahrer die Kosten für die Fahrt zu bezahlen~g~$" + NAPI.Data.GetEntityData(vehicle, "TransportPrice") + "~w~ jede 10/s.");
                player.SetData("TaxiFee", 0);
                // //NAPI.Util.ConsoleOutput("##################### 6");
            }
        }
        // //NAPI.Util.ConsoleOutput("##################### 7");
        if (NAPI.Data.HasEntityData(vehicle, "engine_status"))
        {
            NAPI.Data.ResetEntityData(vehicle, "engine_status");
        }
        // //NAPI.Util.ConsoleOutput("##################### 8");
        if (player.HasData("Refueling"))
        {
            player.ResetData("Refueling");
        }
    }
    //public void OnVehicleHealthChangeHandler(NetHandle entity, float oldValue)

    [ServerEvent(Event.PlayerExitVehicleAttempt)]
    public void OnPlayerExitVehicleAttempt(Client player, Vehicle vehicle)
    {
        //NAPI.Util.ConsoleOutput("OnPlayerExitVehicleAttempt(Vehicle " + vehicle + ")");
        player.TriggerEvent("VehStream_PlayerExitVehicleAttempt", vehicle);
        player.TriggerEvent("this ######## END HERE PlayerExitVehicleAttemptPlayerExitVehicleAttempt");
    }

    [ServerEvent(Event.VehicleDamage)]
    public void OnVehicleDamageHandler(Vehicle entity, float bodyHealthLoss, float engineHealthLoss)
    {
        if (NAPI.Vehicle.GetVehicleHealth(entity) < 950 && bodyHealthLoss < 95)
        {
            var players = NAPI.Pools.GetAllPlayers();
            foreach (var player in players)
            {
                if (player.IsInVehicle)
                {
                    if (player.Vehicle == entity)
                    {
                        if (player.VehicleSeat == -1)
                        {
                            NAPI.Notification.SendNotificationToPlayer(player, "Ruf den ACLS AN!!!!");
                            NAPI.Vehicle.SetVehicleEngineStatus(entity, false);
                        }
                    }
                }
            }
        }
        else if (NAPI.Vehicle.GetVehicleHealth(entity) > 900 && bodyHealthLoss > 90)
        {
            var players = NAPI.Pools.GetAllPlayers();
            foreach (var player in players)
            {
                if (player.IsInVehicle)
                {
                    if (player.Vehicle == entity)
                    {
                        if (player.VehicleSeat == -1)
                        {
                            if (!NAPI.Data.HasEntityData(player.Vehicle, "vehicle_colision"))
                            {
                                NAPI.Notification.SendNotificationToPlayer(player, "Dein Motor von dein  Fahrzeug ist schrott!!");

                                NAPI.Data.SetEntityData(entity, "vehicle_colision", true);
                                NAPI.Vehicle.SetVehicleEngineStatus(entity, false);
                                //NAPI.Vehicle.ExplodeVehicle(player.Vehicle);
                                Random rnd = new Random();
                                int random_timer = rnd.Next(8, 14);

                                NAPI.Task.Run(() =>
                                {
                                    NAPI.Data.ResetEntityData(entity, "vehicle_colision");
                                }, random_timer * 1000);
                            }
                        }
                    }
                }
            }
        }
    }


    [RemoteEvent("OnPlayerHealthChange")]
    public static void OnPlayerHealthChange(Client player, int new_health)
    {

        if (player.Armor > 0)
        {
            player.TriggerEvent("update_armor", player.Armor);
        }

        //update_armor
        player.TriggerEvent("update_health", player.Health - new_health);
    }

    [ServerEvent(Event.PlayerDeath)]
    public void OnPlayerDeath(Client player, Client entityKiller, uint weapon)
    {
        if (player.GetData("status") == true)
        {

            cellphoneSystem.FinishCall(player);
            player.TriggerEvent("death_screen_false");
            //player.TriggerEvent("death_screen_false");

            if (player.HasData("inVehicleInventory"))
            {
                if (player.GetData("inVehicleInventory") == true)
                {
                    player.SetData("inVehicleInventory", false);
                }
            }

            player.SetSharedData("DisableExitVehicle", false);
            player.SetSharedData("DisableVehicleMove", false);
            //Client killer = NAPI.Player.GetPlayerFromHandle(entityKiller);

            if (NAPI.Data.GetEntityData(player, "MainProgressText") == true)
            {
                DeleteTextProgressBar(player);
            }
            Vector3 old_position = player.Position;

            NAPI.Native.SendNativeToPlayer(player, Hash._RESET_LOCALPLAYER_STATE, player);
            NAPI.Native.SendNativeToPlayer(player, Hash.RESET_PLAYER_ARREST_STATE, player);
            NAPI.Native.SendNativeToPlayer(player, Hash.IGNORE_NEXT_RESTART, true);
            NAPI.Native.SendNativeToPlayer(player, Hash._DISABLE_AUTOMATIC_RESPAWN, true);
            NAPI.Native.SendNativeToPlayer(player, Hash.SET_FADE_IN_AFTER_DEATH_ARREST, true);
            NAPI.Native.SendNativeToPlayer(player, Hash.SET_FADE_OUT_AFTER_DEATH, false);
            NAPI.Native.SendNativeToPlayer(player, Hash.NETWORK_REQUEST_CONTROL_OF_ENTITY, player);
            NAPI.Native.SendNativeToPlayer(player, Hash.FREEZE_ENTITY_POSITION, player, false);
            NAPI.Native.SendNativeToPlayer(player, Hash.NETWORK_RESURRECT_LOCAL_PLAYER, player.Position.X, player.Position.Y, player.Position.Z, player.Rotation.Z, false, false);
            NAPI.Native.SendNativeToPlayer(player, Hash.RESURRECT_PED, player);
            NAPI.Native.SendNativeToPlayer(player, Hash.SET_PED_TO_RAGDOLL, player, true);

            player.Position = old_position;

            if (player.GetData("character_prison") > 0)
            {
                ShowColorShard(player, "~y~Willkommen zurück im Gefängnis!", "", 2, 10, 6500);
                sendBackToPrison(player);
                return;
            }
            if (player.GetData("character_ooc_prison_time") > 0)
            {
                ShowColorShard(player, "~y~Willkommen zurück im Gefängnis!", "", 2, 10, 6500);
                adminCommands.SendBackToPrison(player);
                return;
            }
            if (player.GetSharedData("Injured") == 1 && player.GetData("character_prison") == 0)
            {
                player.TriggerEvent("moveSkyCamera", player, "up", 1, false);
                NAPI.Task.Run(() =>
                {
                    player.TriggerEvent("moveSkyCamera", player, "down");
                }, delayTime: 2000);

                ShowColorShard(player, "Du warst schwer verletzt !!", "Sie wurden ins Krankenhaus gebracht..", 2, 10, 6500);
                sendToHospital(player, HOSPITAL_TIME_EXECUTE + player.GetSharedData("InjuredTime"));
                return;
            }
            if (player.GetData("character_prison") == 0)
            {
                if (player.GetData("player_in_turf") != -1)
                {
                    int zone;
                    if (entityKiller.Exists)
                    {
                        zone = entityKiller.GetData("player_in_turf");
                    }
                    else
                    {
                        zone = player.GetData("player_in_turf");
                    }

                    if (TurfWar.turf_war[zone].active_war == 1)
                    {
                        int
                            attackers = TurfWar.turf_war[zone].attemptid,
                            defenders = TurfWar.turf_war[zone].ownerid
                        ;

                        if (AccountManage.GetPlayerGroup(player) == attackers || AccountManage.GetPlayerGroup(player) == defenders)
                        {
                            if (AccountManage.GetPlayerGroup(entityKiller) == AccountManage.GetPlayerGroup(player))
                            {
                                FactionManage.SendFactionMessage(AccountManage.GetPlayerGroup(player), "[Territorialkriegs]:~w~ " + AccountManage.GetCharacterName(player) + "wurde im Territorium getötet" + TurfWar.turf_war[zone].name + ".");
                                FactionManage.SendFactionMessage(AccountManage.GetPlayerGroup(entityKiller), "[Territorialkriegs]:~w~ Ein Mitglied der ~g~" + FactionManage.faction_data[AccountManage.GetPlayerGroup(player)].faction_name + "~w~ wurde im Territorium getötet ~y~" + TurfWar.turf_war[zone].name + "~w~.");

                                if (AccountManage.GetPlayerGroup(entityKiller) == AccountManage.GetPlayerGroup(player) && AccountManage.GetPlayerGroup(entityKiller) == attackers)
                                {
                                    TurfWar.turf_war[zone].defend_point += 100;
                                    TurfWar.turf_war[zone].defend_kills += 1;
                                }
                                else if (AccountManage.GetPlayerGroup(entityKiller) == AccountManage.GetPlayerGroup(player) && AccountManage.GetPlayerGroup(entityKiller) == defenders)
                                {
                                    TurfWar.turf_war[zone].attack_points += 100;
                                    TurfWar.turf_war[zone].attack_kills += 1;
                                }
                            }
                            else
                            {
                                FactionManage.SendFactionMessage(AccountManage.GetPlayerGroup(player), "[Territorialkrieg]:~w~ " + AccountManage.GetCharacterName(player) + " wurde von einem Mitglied der " + AccountManage.GetCharacterName(entityKiller) + " in dem gebiet ~y~" + TurfWar.turf_war[zone].name + "~w~.");
                                FactionManage.SendFactionMessage(AccountManage.GetPlayerGroup(entityKiller), "[Territorialkrieg]:~w~ " + AccountManage.GetCharacterName(entityKiller) + "ein Mitglied getötet " + FactionManage.faction_data[AccountManage.GetPlayerGroup(player)].faction_name + " in dem gebiet~y~" + TurfWar.turf_war[zone].name + "~w~.");

                                if (AccountManage.GetPlayerGroup(entityKiller) == attackers)
                                {
                                    TurfWar.turf_war[zone].attack_points += 100;
                                    TurfWar.turf_war[zone].attack_kills += 1;
                                }
                                else if (AccountManage.GetPlayerGroup(entityKiller) == defenders)
                                {
                                    TurfWar.turf_war[zone].defend_point += 100;
                                    TurfWar.turf_war[zone].defend_kills += 1;
                                }
                            }
                        }
                    }
                }
                //Notify.Send(player, NotifyType.Alert, NotifyPosition.BottomCenter, $"Du wurdest ernsthaft verletzt. !", 65000);
                ShowColorShard(player, "~y~Du wurdest ernsthaft verletzt. !!", "Du bist bewusstlos.", 2, 10, 6500);
                NAPI.Player.PlayPlayerAnimation(player, 33, "random@crash_rescue@wounded@base", "base");

                player.TriggerEvent("freeze", true);
                player.TriggerEvent("freezeEx", true);
                player.SetSharedData("Injured", 1);
                player.SetSharedData("InjuredTime", 10 * 30);
                player.Health = 100;
                player.Armor = 0;
                player.TriggerEvent("update_health", player.Health);

                player.TriggerEvent("screenFadeOut", 1);
                NAPI.Task.Run(() =>
                {
                    player.TriggerEvent("screenFadeIn", 1500);
                    NAPI.Player.PlayPlayerAnimation(player, 33, "random@crash_rescue@wounded@base", "base");
                }, delayTime: 2500);
            }
        }
    }

    [ServerEvent(Event.PlayerSpawn)]
    public void OnPlayerSpawn(Client player)
    {
        NAPI.Blip.SetBlipSprite(player, 15);
    }

    public void SetPlayerSpawn(Client player)
    {
        //NAPI.Util.ConsoleOutput(" " + player.Name + " -- OnPlayerSpawn !!");
    }

    public static void sendBackToPrison(Client player)
    {
        UsefullyRP.RemoveMaskFromPlayer(player);

        player.Position = prison_spawns[player.GetData("character_prison_cell")].position;
        player.Rotation = prison_spawns[player.GetData("character_prison_cell")].rotation;
        //player.TriggerEvent("freeze", false);
        //player.TriggerEvent("freezeEx", false);
        //player.TriggerEvent("freeze", false);

        player.SetClothes(1, 0, 0);
        player.SetClothes(5, 0, 0);
        player.SetClothes(1, 0, 0);
        player.SetClothes(7, 0, 0);
        player.SetClothes(9, 0, 0);

        player.ClearAccessory(0);
        player.ClearAccessory(1);
        player.ClearAccessory(2);
        player.ClearAccessory(6);
        player.ClearAccessory(7);

        // prison clothes
        if (player.GetSharedData("CHARACTER_ONLINE_GENRE") == 0)
        {
            player.SetClothes(4, 3, 7);
            player.SetClothes(11, 5, 0);
            player.SetClothes(3, 5, 0);
            player.SetClothes(8, 0, 18);
            player.SetClothes(6, 8, 0);
        }
        else
        {
            player.SetClothes(4, 3, 7);
            player.SetClothes(11, 5, 0);
            player.SetClothes(3, 4, 0);
            player.SetClothes(8, 0, 18);
            player.SetClothes(6, 1, 0);
        }


        TimeSpan time = TimeSpan.FromSeconds(player.GetData("character_prison_time"));
        string str = time.ToString(@"hh\:mm\:ss");
    }

    public static void sendToHospital(Client player, int seconds = 60)
    {
        UsefullyRP.RemoveMaskFromPlayer(player);

        if (NAPI.Data.GetEntityData(player, "MainProgressText") == true)
        {
            DeleteTextProgressBar(player);
        }

        NAPI.Player.StopPlayerAnimation(player);
        player.SetSharedData("Injured", 2);
        player.SetSharedData("InjuredTime", seconds);

        //WeaponManage.RemoveAllWeaponEx(player);

        AccountManage.SetPlayerHunger(player, 75.0f);
        AccountManage.SetPlayerThirsty(player, 75.0f);

        player.SetSharedData("Injured", 2);
        player.SetSharedData("character_hospital", 1);
        NAPI.Notification.SendNotificationToPlayer(player, "Sie sind bewusstlos, Sie wurden sofort ins Krankenhaus gebracht");
        NAPI.Player.PlayPlayerAnimation(player, 33, "random@crash_rescue@wounded@base", "base");
        //player.TriggerEvent("DisplayCustomCamera", new Vector3(370.0917, -593.4966, 28.87214), new Vector3(0, 0, 59.12927));
        player.Position = new Vector3(370.0917, -593.4966, 28.87214);
        //player.TriggerEvent("freeze", true);
        player.TriggerEvent("freeze", true);

        WeaponManage.RemoveAllWeaponEx(player);

        TimeSpan time = TimeSpan.FromSeconds(player.GetSharedData("InjuredTime"));
        string time_left = time.ToString(@"mm\:ss");

        Inventory.ClearInventory(player);

        NAPI.Task.Run(() =>
        {
            NAPI.Player.StopPlayerAnimation(player);
        }, delayTime: 300000);

        if (GetPlayerMoney(player) > 0)
        {
            SetPlayerMoney(player, GetPlayerMoney(player) / 2);
        }
        else GivePlayerMoney(player, -500);
    }

    public static void CreateMySqlCommand(string myExecuteQuery)
    {
        using (MySqlConnection CustomConnection = new MySqlConnection(myConnectionString))
        {
            try
            {
                MultipleActiveResultSets = true;

                CustomConnection.Open();
                MySqlCommand myCommand = new MySqlCommand(myExecuteQuery, CustomConnection);
                myCommand.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                if (CustomConnection != null)
                {
                    NAPI.Util.ConsoleOutput("DATABASE: [ERROR] " + ex.Message);
                    CustomConnection.Dispose();
                    if (myExecuteQuery != null)
                    {
                        CustomConnection.ClearAllPoolsAsync();
                    }
                }
                throw;
            }
        }
    }

    private void OnPlayerFinishedDownloadHandler(Client player)
    {
        System.Threading.Tasks.Task.Run(() =>
        {
            NAPI.Task.Run(() =>
            {
                //NAPI.Util.ConsoleOutput("[Connect] " + player.Name + " mit dem Server verbunden.");
                //player.TriggerEvent("accountLoginForm");
                NAPI.ClientEvent.TriggerClientEvent(player, "accountLoginForm");
                player.Position = new Vector3(-1105.8652, -2742.502, -7.410133);
                player.Dimension = 150;

                //foreach (var turf in TurfWar.turf_war)
                //{
                //    if (turf.Position.X != 0 && turf.Position.Y != 0)
                //    {
                //        if (turf.ownerid == -1)
                //        {
                //            player.TriggerEvent("CreateZone", turf.Position.X, turf.Position.Y, turf.Position.Z, 45, turf.area_range, 175);
                //        }
                //        else player.TriggerEvent("CreateZone", turf.Position.X, turf.Position.Y, turf.Position.Z, FactionManage.faction_data[turf.ownerid].faction_turf_color, turf.area_range, 175);
                //    }
                //    else player.TriggerEvent("CreateZone", turf.Position.X, turf.Position.Y, turf.Position.Z, 0, 0, 0);
                //}

                // LS-PD Impount
                player.TriggerEvent("Sync_PedCreate", "lspdimpount", NAPI.Util.PedNameToModel("CopCutscene"), new Vector3(362.1734, -1591.075, 29.29206), 315.9276f, "", 0);

                // LS Job Center
                player.TriggerEvent("Sync_PedCreate", "jobcenter1", NAPI.Util.PedNameToModel("Bevhills03AFY"), new Vector3(246.8554, -1596.048, 31.53196), 262.3354f, "", 0);
                player.TriggerEvent("Sync_PedCreate", "jobcenter2", NAPI.Util.PedNameToModel("BankmanCutscene"), new Vector3(246.3486, -1598.66, 31.53195), 263.1926f, "", 0);

                // casino
                player.TriggerEvent("Sync_PedCreate", "casino1", NAPI.Util.PedNameToModel("Bevhills03AFY"), new Vector3(1145.692, 261.9064, -51.84083), 224.0993f, "", 0);
                player.TriggerEvent("Sync_PedCreate", "casino2", NAPI.Util.PedNameToModel("Bevhills03AFY"), new Vector3(1143.926, 263.6904, -51.84083), 38.21872f, "", 0);
                player.TriggerEvent("Sync_PedCreate", "casino3", NAPI.Util.PedNameToModel("Bevhills03AFY"), new Vector3(1149.459, 268.9999, -51.84085), 40.25985f, "", 0);
                player.TriggerEvent("Sync_PedCreate", "casino4", NAPI.Util.PedNameToModel("Bevhills03AFY"), new Vector3(1151.195, 267.3809, -51.84085), 215.7089f, "", 0);
                player.TriggerEvent("Sync_PedCreate", "casinoatm", NAPI.Util.PedNameToModel("BankmanCutscene"), new Vector3(1117.844, 220.0863, -49.43512), 93.61008f, "", 0);

                //bus job
                player.TriggerEvent("Sync_PedCreate", "cityhall", NAPI.Util.PedNameToModel("GenStreet02AMY"), new Vector3(-547.6739, -187.3867, 37.55759), 212.3513f, "", 0);

                // neue bitte noch das feature machen
                player.TriggerEvent("Sync_PedCreate", "feature", NAPI.Util.PedNameToModel("WareMechMale01"), new Vector3(290.1143, 2853.132, 43.64243), 43.62192f, "", 0);

                // LSPC
                player.TriggerEvent("Sync_PedCreate", "lspc", NAPI.Util.PedNameToModel("WareMechMale01"), new Vector3(-345.5088, -122.91604, 39.009655), -120.69314f, "", 0);
                // ped
                //player.TriggerEvent("Sync_PedCreate", "fish", NAPI.Util.PedNameToModel("Chef2"), new Vector3(-1038.499, -1396.846, 5.553194), 80.9303f, "", 0);
                player.TriggerEvent("Sync_PedCreate", "garbage", NAPI.Util.PedNameToModel("DockWork01SMY"), new Vector3(1382.225, -2078.733, 51.99856), 44.99533f, "", 0);
                //player.TriggerEvent("Sync_PedCreate", "baustelle", NAPI.Util.PedNameToModel("DockWork01SMY"), new Vector3(2341.124, 3126.402, 48.20874), 44.99533f, "", 0);
                player.TriggerEvent("Sync_PedCreate", "mechanic", NAPI.Util.PedNameToModel("WareMechMale01"), new Vector3(-1140.054, -2005.987, 13.18026), 69.61186f, "", 0);
                player.TriggerEvent("Sync_PedCreate", "shipment", NAPI.Util.PedNameToModel("DockWork01SMY"), new Vector3(-254.7194, -842.709, 31.42277), 61.27283f, "", 0);
                //player.TriggerEvent("Sync_PedCreate", "taxi", NAPI.Util.PedNameToModel("Busker01SMO"), new Vector3(902.5832, -172.6801, 74.07558), -121.4034f, "", 0);
                player.TriggerEvent("Sync_PedCreate", "sell_grain", NAPI.Util.PedNameToModel("UndercoverCopCutscene"), new Vector3(2886.25, 4386.166, 50.73577), 206.4246f, "", 0);
                player.TriggerEvent("Sync_PedCreate", "farm", NAPI.Util.PedNameToModel("Farmer01AMM"), new Vector3(2832.978, 4571.757, 46.95262), 196.6945f, "", 0);

                // 24/7 System Peds
                player.TriggerEvent("Sync_PedCreate", "24/4", NAPI.Util.PedNameToModel("Polynesian01AMY"), new Vector3(78.41674, -228.5437, 54.64209), 343.4777f, "", 0);
                player.TriggerEvent("Sync_PedCreate", "24/4", NAPI.Util.PedNameToModel("Polynesian01AMY"), new Vector3(372.5218, 326.593, 103.5664), 255.4434f, "", 0);
                player.TriggerEvent("Sync_PedCreate", "24/4", NAPI.Util.PedNameToModel("Patricia"), new Vector3(1727.95, 6415.558, 35.03722), 247.2372f, "", 0);
                player.TriggerEvent("Sync_PedCreate", "24/4", NAPI.Util.PedNameToModel("Ortega"), new Vector3(10.15536, 6510.786, 31.87786), 353.7303f, "", 0);
                player.TriggerEvent("Sync_PedCreate", "24/4", NAPI.Util.PedNameToModel("Oneil"), new Vector3(-327.9904, 6084.591, 31.45479), 189.3768f, "", 0);
                player.TriggerEvent("Sync_PedCreate", "24/4", NAPI.Util.PedNameToModel("Omega"), new Vector3(1959.919, 3740.149, 32.34375), 302.5924f, "", 0);
                player.TriggerEvent("Sync_PedCreate", "24/4", NAPI.Util.PedNameToModel("OldMan2"), new Vector3(1698.496, 4826.298, 42.06313), 60.80223f, "", 0);
                player.TriggerEvent("Sync_PedCreate", "24/4", NAPI.Util.PedNameToModel("OldMan1A"), new Vector3(2677.761, 3279.482, 55.24113), 337.7997f, "", 0);
                player.TriggerEvent("Sync_PedCreate", "24/4", NAPI.Util.PedNameToModel("Nigel"), new Vector3(-1107.03, 2712.589, 19.1078), 170.9754f, "", 0);
                player.TriggerEvent("Sync_PedCreate", "24/4", NAPI.Util.PedNameToModel("Natalia"), new Vector3(-1115.305, 2699.14, 18.55413), 174.004f, "", 0);
                player.TriggerEvent("Sync_PedCreate", "24/4", NAPI.Util.PedNameToModel("Miranda"), new Vector3(549.2136, 2671, 42.15649), 90.28946f, "", 0);
                player.TriggerEvent("Sync_PedCreate", "24/4", NAPI.Util.PedNameToModel("MilitaryBum"), new Vector3(1166.191, 2710.808, 38.15772), 178.497f, "", 0);
                player.TriggerEvent("Sync_PedCreate", "24/4", NAPI.Util.PedNameToModel("Michelle"), new Vector3(1194.11, 2715.547, 38.22265), 137.2764f, "", 0);
                player.TriggerEvent("Sync_PedCreate", "24/4", NAPI.Util.PedNameToModel("MethHead01AMY"), new Vector3(-3169.723, 1089.224, 20.83873), 198.239f, "", 0);
                player.TriggerEvent("Sync_PedCreate", "24/4", NAPI.Util.PedNameToModel("Maude"), new Vector3(-3176.811, 1039.236, 20.86321), 324.6835f, "", 0);
                player.TriggerEvent("Sync_PedCreate", "24/4", NAPI.Util.PedNameToModel("Maude"), new Vector3(-3242.549, 999.9102, 12.8307), 352.6658f, "", 0);
                player.TriggerEvent("Sync_PedCreate", "24/4", NAPI.Util.PedNameToModel("Markfost"), new Vector3(-2966.383, 390.7555, 15.0433), 87.02075f, "", 0);
                player.TriggerEvent("Sync_PedCreate", "24/4", NAPI.Util.PedNameToModel("Mani"), new Vector3(-1819.928, 794.0099, 138.0877), 130.6822f, "", 0);
                player.TriggerEvent("Sync_PedCreate", "24/4", NAPI.Util.PedNameToModel("Mani"), new Vector3(2556.755, 380.7259, 108.6229), 2.247727f, "", 0);
                player.TriggerEvent("Sync_PedCreate", "24/4", NAPI.Util.PedNameToModel("LSMetro01SMM"), new Vector3(2565.656, 295.759, 108.7349), 314.9252f, "", 0);
                player.TriggerEvent("Sync_PedCreate", "24/4", NAPI.Util.PedNameToModel("LifeInvad02"), new Vector3(-0.6991969, 0.4957197, 71.13163), 339.4209f, "", 0);
                player.TriggerEvent("Sync_PedCreate", "24/4", NAPI.Util.PedNameToModel("LifeInvad01"), new Vector3(250.1212, -51.63224, 69.94103), 23.65236f, "", 0);
                player.TriggerEvent("Sync_PedCreate", "24/4", NAPI.Util.PedNameToModel("LifeInvad01"), new Vector3(-35.41095, -154.9359, 57.07655), 307.483f, "", 0);
                player.TriggerEvent("Sync_PedCreate", "24/4", NAPI.Util.PedNameToModel("Lost02GMY"), new Vector3(119.8233, -228.1808, 54.55782), 320.7488f, "", 0);
                player.TriggerEvent("Sync_PedCreate", "24/4", NAPI.Util.PedNameToModel("LSMetro01SMM"), new Vector3(1164.823, -323.0862, 69.20506), 101.0579f, "", 0);
                player.TriggerEvent("Sync_PedCreate", "24/4", NAPI.Util.PedNameToModel("LifeInvad02"), new Vector3(1215.432, -475.2086, 66.20811), 47.40783f, "", 0);
                player.TriggerEvent("Sync_PedCreate", "24/4", NAPI.Util.PedNameToModel("LesterCrestCutscene"), new Vector3(430.8408, -798.9227, 29.49872), 134.6279f, "", 0);
                player.TriggerEvent("Sync_PedCreate", "24/4", NAPI.Util.PedNameToModel("LamarDavis"), new Vector3(-706.1161, -913.8936, 19.21561), 84.46125f, "", 0);
                player.TriggerEvent("Sync_PedCreate", "24/4", NAPI.Util.PedNameToModel("LaceyJones02"), new Vector3(-660.0546, -936.6238, 21.82921), 137.3138f, "", 0);
                player.TriggerEvent("Sync_PedCreate", "24/4", NAPI.Util.PedNameToModel("KTown02AMY"), new Vector3(-1222.133, -908.4273, 12.32634), 34.93617f, "", 0);
                player.TriggerEvent("Sync_PedCreate", "24/4", NAPI.Util.PedNameToModel("KTown02AFM"), new Vector3(1134.171, -982.3743, 46.4158), 271.9329f, "", 0);
                player.TriggerEvent("Sync_PedCreate", "24/4", NAPI.Util.PedNameToModel("KTown01AMY"), new Vector3(69.82995, -1400.382, 29.38219), 322.1201f, "", 0);
                player.TriggerEvent("Sync_PedCreate", "24/4", NAPI.Util.PedNameToModel("KTown01AFO"), new Vector3(-47.18978, -1758.474, 29.421), 57.22526f, "", 0);
                player.TriggerEvent("Sync_PedCreate", "24/4", NAPI.Util.PedNameToModel("KerryMcintosh"), new Vector3(-1336.617, -1276.563, 4.888288), 109.7159f, "", 0);
            }, delayTime: 1050); // delay time in ms
        });
    }

    [RemoteEvent("globalBrowser_status")]
    public void globalBrowser_status(Client player, bool value)
    {
        player.SetData("General_CEF", value);
    }

    [RemoteEvent("loginUser")]
    public void loginUserEvent(Client player, String username, String password)
    {

        if (player.HasData("waitLogando"))
        {
            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Warten Sie einige Sekunden ...", 5000);
            return;
        }
        
        player.SetData("waitLogando", true);
        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {

            Mainpipeline.Open();
            MySqlCommand query = Mainpipeline.CreateCommand();
            query.CommandType = CommandType.Text;
            query.CommandText = "SELECT * FROM `users` WHERE ( `Username` = '" + player.SocialClubName + "' ) and `Password` = '" + password + "'";
            query.ExecuteNonQuery();

            DataTable dt = new DataTable();
            using (MySqlDataAdapter da = new MySqlDataAdapter(query))
            {

                da.Fill(dt);

                int i = 0;
                i = Convert.ToInt32(dt.Rows.Count.ToString());
                if (i == 0)
                {
                    Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie haben ein falsches Passwort eingegeben!", 5000);
                    player.ResetData("waitLogando");
                }
                else
                {
                    NAPI.ClientEvent.TriggerClientEvent(player, "clearLoginWindow");
                    AccountManage.LoadAccount(player, player.SocialClubName);
                    player.ResetData("waitLogando");
                }
            }
        }
    }

    [RemoteEvent("registerUser")]
    public void registerUserEvent(Client player, String username, String password)
    {

        if (player.HasData("waitLogando"))
        {
            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Bitte warten Sie einige Sekunden.", 5000);
            return;
        }
        player.SetData("waitLogando", true);

        if (password.Length < 5 & password.Length > 30)
        {
            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Ihr Passwort muss zwischen 5 und 30 Zeichen lang sein", 5000);
            player.ResetData("waitLogando");
        }
        else
        {
            AccountManage.CreateAccount(player, username, password);
            player.ResetData("waitLogando");
            player.TriggerEvent("Display_Whitelist_Screen");
            //player.TriggerEvent("Display_Whitelist_Screen");
            player.Kick();
            return;
        }
    }

    [RemoteEvent("SetCruiseValue")]
    public void Event_SetCruiseValue(Client player, int value)
    {
        player.SetData("SpeedLimitValue", value);
    }

    [RemoteEvent("SetCruiseEnable")]
    public void Event_SetCruiseValue(Client player, bool value)
    {
        player.SetData("SpeedLimitValue", value);
    }


    [RemoteEvent("keypress:F1")]
    public void KeyPressF1(Client player)
    {
        if (player.GetData("status") == false)
        {
            return;
        }
        player.TriggerEvent("Display_Player_Help", AccountManage.GetPlayerJob(player), AccountManage.GetPlayerLeader(player), FactionManage.GetPlayerGroupType(player), AccountManage.GetPlayerRank(player));
    }

    [RemoteEvent("keypress:F4")]
    public void KeyPressF4(Client player)
    {
        if (player.GetData("status") == false)
        {
            return;
        }

        if (AccountManage.GetPlayerGroup(player) == 1)
        {
            List<dynamic> arr_player = new List<dynamic>();
            player.TriggerEvent("Display_LSPD_Akten", NAPI.Util.ToJson(arr_player));
        }
        else if (AccountManage.GetPlayerGroup(player) == 2)
        {
            List<dynamic> arr_player = new List<dynamic>();
            player.TriggerEvent("Display_LSFD_Akten", NAPI.Util.ToJson(arr_player));
        }
        else if (AccountManage.GetPlayerGroup(player) == 16)
        {
            List<dynamic> arr_player = new List<dynamic>();
            player.TriggerEvent("Display_DOJ_Akten", NAPI.Util.ToJson(arr_player));
        }
        else if (AccountManage.GetPlayerGroup(player) == 24)
        {
            List<dynamic> arr_player = new List<dynamic>();
            player.TriggerEvent("Display_DOJ_Akten", NAPI.Util.ToJson(arr_player));
        }
        else if (AccountManage.GetPlayerGroup(player) == 25)
        {
            List<dynamic> arr_player = new List<dynamic>();
            player.TriggerEvent("Display_LSPD_Akten", NAPI.Util.ToJson(arr_player));
        }
    }

    [RemoteEvent("keypress:F10")]
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

    [RemoteEvent("KeyPress:F6")]
    public void KeyPressF6(Client player)
    {
        if (player.GetData("status") == false)
        {
            return;
        }
        Services.DisplayCalls(player);
    }

    [RemoteEvent("KeyPress:F7")]
    public void KeyPressF7(Client player)
    {
        if (player.GetData("status") == false)
        {
            return;
        }
        Police.ShowMDC(player);
    }

    [RemoteEvent("keypress:H")]
    public void KeyPressH(Client player)
    {
        if (player.GetData("status") == false)
        {
            return;
        }
        if (!player.IsInVehicle && player.GetData("status") == true && CANINE_SYSTEM == true)
        {

            if (player.GetData("handsup") == true)
            {
                player.SetData("handsup", false);
                player.StopAnimation();
            }
            else
            {
                if ((int)NAPI.Data.GetEntitySharedData(player, "Injured") != 0 || player.GetData("handsup") == true || player.GetData("playerCuffed") != 0 || player.GetData("SendoArrastado") == true)
                {
                    return;
                }
                player.SetData("handsup", true);
                NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop | AnimationFlags.AllowPlayerControl | AnimationFlags.OnlyAnimateUpperBody), "mp_am_hold_up", "handsup_base");
            }
            //CanineSystem.KeyPressH(player);
        }
    }

    [RemoteEvent("keypress:L")]
    public void KeyPressL(Client player)
    {
        if (player.GetData("status") == false)
        {
            return;
        }
        if (player.IsInVehicle)
        {
            if (player.GetData("SpeedLimit") == false)
            {
                if (player.GetData("SpeedLimitValue") == 0)
                {
                    //player.TriggerEvent("speed_limiter");
                    Main.SendInfoMessage(player, "Benutze " + Main.EMBED_LIGHTGREEN + "O" + Main.EMBED_WHITE + " um den Tempomat zu aktivieren.");
                }
                else
                {
                    player.TriggerEvent("speed_limiter_command", player.GetData("SpeedLimitValue"));
                    Main.SendInfoMessage(player, "Tempolimit für Tempomat eingestellt auf " + Main.EMBED_LIGHTGREEN + "" + player.GetData("SpeedLimitValue") + " KM/H" + Main.EMBED_WHITE + ". " + Main.EMBED_LIGHTGREEN + "(Drücke ~y~L~c~ umschalten)");
                    player.SetData("SpeedLimit", true);
                }
            }
            else
            {
                player.SetData("SpeedLimit", false);
                player.TriggerEvent("speed_limiter_command", "off");
                Main.SendInfoMessage(player, "Tempolimitsbegrenzung " + EMBED_RED + "aus" + EMBED_WHITE + ".");
            }
        }
        else
        {
            if (FactionManage.GetPlayerGroupType(player) == 1 || AccountManage.GetPlayerGroup(player) == 25 || Inventory.GetPlayerItemFromInventory(player, 69) >= 1)
            {
                DoorLock.DoorLSPDInteract(player);
            }

            CanineSystem.KeyPressH(player);

            //code here
        }
    }

    [RemoteEvent("keypress:E")]
    public void KeyPressE(Client player)
    {
        if (player.GetData("status") == false)
        {
            return;
        }
        if (player.GetData("status") == false)
        {
            return;
        }
        Inventory.PlayerPressKeyE(player);
        Garbage.PlayerPressKeyE(player);
        //cellphoneSystem.PressKeyE(player);
        //Baustelle.PlayerPressKeyE(player);
        //DriverLicense.PlayerPressKeyE(player);
        GarageSys.PressKeyE(player);
        RobberyNPC.keyPressY(player);
        Carwash.PlayerPressKeyE(player);
        Main_Job.KeyPressE(player);

        if (AccountManage.GetPlayerGroup(player) == 1 && (IsInRangeOfPoint(player.Position, new Vector3(462.9306, -1014.615, 28.06764), 3) || IsInRangeOfPoint(player.Position, new Vector3(463.3755, -1019.973, 28.10607), 3) || IsInRangeOfPoint(player.Position, new Vector3(449.2292, -981.2446, 43.69167), 3)))
        {
            if (player.IsInVehicle)
            {
                for (int i = 0; i < FactionManage.MAX_FACTION_VEHICLES; i++)
                {
                    if (FactionManage.faction_data[AccountManage.GetPlayerGroup(player)].faction_vehicle_entity[i] == NAPI.Player.GetPlayerVehicle(player))
                    {
                        FactionManage.faction_data[AccountManage.GetPlayerGroup(player)].faction_vehicle_name[i] = "Frei";
                        FactionManage.faction_data[AccountManage.GetPlayerGroup(player)].faction_vehicle_owned[i] = "Niemand";
                        if (player.IsInVehicle) player.Vehicle.Delete();
                    }
                }
            }
        }
        else if (AccountManage.GetPlayerGroup(player) == 15 && (IsInRangeOfPoint(player.Position, new Vector3(-1121.292, -2008.041, 13.17998), 3)))
        {
            if (player.IsInVehicle)
            {
                for (int i = 0; i < FactionManage.MAX_FACTION_VEHICLES; i++)
                {
                    if (FactionManage.faction_data[AccountManage.GetPlayerGroup(player)].faction_vehicle_entity[i] == NAPI.Player.GetPlayerVehicle(player))
                    {
                        FactionManage.faction_data[AccountManage.GetPlayerGroup(player)].faction_vehicle_name[i] = "Frei";
                        FactionManage.faction_data[AccountManage.GetPlayerGroup(player)].faction_vehicle_owned[i] = "Niemand";
                        if (player.IsInVehicle) player.Vehicle.Delete();
                    }
                }
            }
        }
        else if (AccountManage.GetPlayerGroup(player) == 25 && (IsInRangeOfPoint(player.Position, new Vector3(128.8711, -721.9634, 32.76905), 3)))
        {
            if (player.IsInVehicle)
            {
                for (int i = 0; i < FactionManage.MAX_FACTION_VEHICLES; i++)
                {
                    if (FactionManage.faction_data[AccountManage.GetPlayerGroup(player)].faction_vehicle_entity[i] == NAPI.Player.GetPlayerVehicle(player))
                    {
                        FactionManage.faction_data[AccountManage.GetPlayerGroup(player)].faction_vehicle_name[i] = "Frei";
                        FactionManage.faction_data[AccountManage.GetPlayerGroup(player)].faction_vehicle_owned[i] = "Niemand";
                        if (player.IsInVehicle) player.Vehicle.Delete();
                    }
                }
            }
        }
        else if (AccountManage.GetPlayerGroup(player) == 26 && (IsInRangeOfPoint(player.Position, new Vector3(-1796.047, 2998.922, 32.80937), 3)))
        {
            if (player.IsInVehicle)
            {
                for (int i = 0; i < FactionManage.MAX_FACTION_VEHICLES; i++)
                {
                    if (FactionManage.faction_data[AccountManage.GetPlayerGroup(player)].faction_vehicle_entity[i] == NAPI.Player.GetPlayerVehicle(player))
                    {
                        FactionManage.faction_data[AccountManage.GetPlayerGroup(player)].faction_vehicle_name[i] = "Frei";
                        FactionManage.faction_data[AccountManage.GetPlayerGroup(player)].faction_vehicle_owned[i] = "Niemand";
                        if (player.IsInVehicle) player.Vehicle.Delete();
                    }

                }
            }
        }
        else if (AccountManage.GetPlayerGroup(player) == 2 && (IsInRangeOfPoint(player.Position, new Vector3(-241.0735, 6333.936, 31.98685), 3) || IsInRangeOfPoint(player.Position, new Vector3(339.3354, -623.9186, 28.85218), 3)))
        {
            if (player.IsInVehicle)
            {
                for (int i = 0; i < FactionManage.MAX_FACTION_VEHICLES; i++)
                {
                    if (FactionManage.faction_data[AccountManage.GetPlayerGroup(player)].faction_vehicle_entity[i] == NAPI.Player.GetPlayerVehicle(player))
                    {
                        FactionManage.faction_data[AccountManage.GetPlayerGroup(player)].faction_vehicle_name[i] = "Frei";
                        FactionManage.faction_data[AccountManage.GetPlayerGroup(player)].faction_vehicle_owned[i] = "Niemand";
                        if (player.IsInVehicle) player.Vehicle.Delete();
                    }

                }
            }
        }
        else if (AccountManage.GetPlayerGroup(player) == 3 && (IsInRangeOfPoint(player.Position, new Vector3(-355.8882, 6068.04, 31.49855), 3)))
        {
            if (player.IsInVehicle)
            {
                for (int i = 0; i < FactionManage.MAX_FACTION_VEHICLES; i++)
                {

                    if (FactionManage.faction_data[AccountManage.GetPlayerGroup(player)].faction_vehicle_entity[i] == NAPI.Player.GetPlayerVehicle(player))
                    {
                        FactionManage.faction_data[AccountManage.GetPlayerGroup(player)].faction_vehicle_name[i] = "Frei";
                        FactionManage.faction_data[AccountManage.GetPlayerGroup(player)].faction_vehicle_owned[i] = "Niemand";
                        if (player.IsInVehicle) player.Vehicle.Delete();
                    }

                }
            }

        }
        else if (AccountManage.GetPlayerGroup(player) == 1 && (IsInRangeOfPoint(player.Position, new Vector3(1868.748, 3695.093, 33.59127), 3)))
        {
            if (player.IsInVehicle)
            {
                for (int i = 0; i < FactionManage.MAX_FACTION_VEHICLES; i++)
                {

                    if (FactionManage.faction_data[AccountManage.GetPlayerGroup(player)].faction_vehicle_entity[i] == NAPI.Player.GetPlayerVehicle(player))
                    {
                        FactionManage.faction_data[AccountManage.GetPlayerGroup(player)].faction_vehicle_name[i] = "Frei";
                        FactionManage.faction_data[AccountManage.GetPlayerGroup(player)].faction_vehicle_owned[i] = "Niemand";
                        if (player.IsInVehicle) player.Vehicle.Delete();
                    }

                }
            }
        }

        if (player.IsInVehicle) LSCustom.PressKeyE(player);

        if (player.IsInVehicle) LostMCCustom.PressKeyE(player);

        if (player.IsInVehicle) Bennys.PressKeyE(player);

        if (IsInRangeOfPoint(player.Position, new Vector3(363.6198, -1589.367, 29.29205), 3))
        {
            PlayerVehicle.ShowPlayerVehiclesToRelease(player);
        }
        else if (AccountManage.GetPlayerGroup(player) == 1 && (IsInRangeOfPoint(player.Position, new Vector3(1868.748, 3695.093, 33.59127), 3))) //
        {

            if (player.GetData("duty") == 0) { NAPI.Notification.SendNotificationToPlayer(player, "ERROR:~w~ Du bist nicht in Ordnung."); return; }
            if (NAPI.Player.IsPlayerInAnyVehicle(player))
            {
                NAPI.Notification.SendNotificationToPlayer(player, "ERROR:~w~ Sie können nicht in einem Fahrzeug sein.");
            }
            else FactionManage.DisplayFactionVehicles(player);

        }
        else if (AccountManage.GetPlayerGroup(player) == 1 && (IsInRangeOfPoint(player.Position, new Vector3(442.0854, -1014.646, 28.64312), 3))) //
        {

            if (player.GetData("duty") == 0) { NAPI.Notification.SendNotificationToPlayer(player, "ERROR:~w~ Du bist nicht in Ordnung."); return; }
            if (NAPI.Player.IsPlayerInAnyVehicle(player))
            {
                NAPI.Notification.SendNotificationToPlayer(player, "ERROR:~w~ Sie können nicht in einem Fahrzeug sein.");
            }
            else FactionManage.DisplayFactionVehicles(player);

        }
        else if (AccountManage.GetPlayerGroup(player) == 25 && (IsInRangeOfPoint(player.Position, new Vector3(139.8818, -725.8235, 32.76768), 3))) //
        {

            if (player.GetData("duty") == 0) { NAPI.Notification.SendNotificationToPlayer(player, "ERROR:~w~ Du bist kein Agent!"); return; }
            if (NAPI.Player.IsPlayerInAnyVehicle(player))
            {
                NAPI.Notification.SendNotificationToPlayer(player, "ERROR:~w~ Fahrzeug konnte nicht aus der Garage gefahren werden!");
            }
            else FactionManage.DisplayFactionVehicles(player);

        }
        else if (AccountManage.GetPlayerGroup(player) == 15 && (IsInRangeOfPoint(player.Position, new Vector3(-1149.349, -2015.081, 13.18026), 3))) //
        {

            if (FactionManage.GetPlayerGroupType(player) == 15) { NAPI.Notification.SendNotificationToPlayer(player, "ERROR:~w~ Du bist kein Arbeiter von den ACLS!"); return; }
            if (NAPI.Player.IsPlayerInAnyVehicle(player))
            {
                NAPI.Notification.SendNotificationToPlayer(player, "ERROR:~w~ Fahrzeug konnte nicht aus der Garage gefahren werden!");
            }
            else FactionManage.DisplayFactionVehicles(player);

        }
        else if (AccountManage.GetPlayerGroup(player) == 21 && (IsInRangeOfPoint(player.Position, new Vector3(-334.353, -126.06683, 39.009655), 3))) //
        {

            if (FactionManage.GetPlayerGroupType(player) == 21) { NAPI.Notification.SendNotificationToPlayer(player, "ERROR:~w~ Du bist kein Arbeiter von den LSPC!"); return; }
            if (NAPI.Player.IsPlayerInAnyVehicle(player))
            {
                NAPI.Notification.SendNotificationToPlayer(player, "ERROR:~w~ Fahrzeug konnte nicht aus der Garage gefahren werden!");
            }
            else FactionManage.DisplayFactionVehicles(player);

        }
        else if (AccountManage.GetPlayerGroup(player) == 26 && (IsInRangeOfPoint(player.Position, new Vector3(-1781.192, 2997.922, 32.80978), 3))) //
        {

            if (player.GetData("duty") == 0) { NAPI.Notification.SendNotificationToPlayer(player, "ERROR:~w~ Du bist kein Noose Agent!"); return; }
            if (NAPI.Player.IsPlayerInAnyVehicle(player))
            {
                NAPI.Notification.SendNotificationToPlayer(player, "ERROR:~w~ Fahrzeug konnte nicht aus der Garage gefahren werden!");
            }
            else FactionManage.DisplayFactionVehicles(player);

        }
        else if (FactionManage.GetPlayerGroupType(player) == FactionManage.FACTION_TYPE_MEDIC && IsInRangeOfPoint(player.Position, new Vector3(334.5246, -560.1913, 28.74345), 3))
        {

            if (player.GetData("duty") == 0) { NAPI.Notification.SendNotificationToPlayer(player, "ERROR:~w~ Du bist nicht in Dienst."); return; }
            if (NAPI.Player.IsPlayerInAnyVehicle(player))
            {
                NAPI.Notification.SendNotificationToPlayer(player, "ERROR:~w~ Sie können nicht in einem Fahrzeug sein.");
            }
            else FactionManage.DisplayFactionVehicles(player);

        }
        else if (FactionManage.GetPlayerGroupType(player) == FactionManage.FACTION_TYPE_MEDIC && IsInRangeOfPoint(player.Position, new Vector3(-262.2234, 6336.558, 32.42102), 3))
        {

            if (player.GetData("duty") == 0) { NAPI.Notification.SendNotificationToPlayer(player, "ERROR:~w~ Du bist nicht in Dienst."); return; }
            if (NAPI.Player.IsPlayerInAnyVehicle(player))
            {
                NAPI.Notification.SendNotificationToPlayer(player, "ERROR:~w~ Sie können nicht in einem Fahrzeug sein.");
            }
            else FactionManage.DisplayFactionVehicles(player);

        }
        else if (AccountManage.GetPlayerGroup(player) == 3 && IsInRangeOfPoint(player.Position, new Vector3(-359.0479, 6061.942, 31.50011), 3))
        {

            if (player.GetData("duty") == 0) { NAPI.Notification.SendNotificationToPlayer(player, "ERROR:~w~Du bist nicht in Dienst."); return; }
            if (NAPI.Player.IsPlayerInAnyVehicle(player))
            {
                NAPI.Notification.SendNotificationToPlayer(player, "ERROR:~w~ Sie können nicht in einem Fahrzeug sein.");
            }
            else FactionManage.DisplayFactionVehicles(player);

        }
        else if (FactionManage.GetPlayerGroupType(player) == FactionManage.FACTION_TYPE_MEDIC && (IsInRangeOfPoint(player.Position, new Vector3(335.7118, -580.4397, 28.79148), 3)))
        {

            if (player.GetData("duty") == 0)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Du bist in den Dienst gegangen!");
                //NAPI.Notification.SendNotificationToPlayer(player, "Sie sind in Dienst~g~gegangn~w~ .");
                player.SetData("duty", 1);
                Outfits.SetUnisexOutfit(player, 1196);
                NAPI.Data.SetEntityData(player, "character_duty_outfit", 1196);
                SetPlayerToTeamColor(player);
            }
            else if (player.GetData("duty") == 1)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Du bist aus den Dienst gegangen!");
                //NAPI.Notification.SendNotificationToPlayer(player, "Sie sind noch im Dienst~w~.");
                player.SetData("duty", 0);
                Outfits.RemovePlayerDutyOutfit(player);
                UpdatePlayerClothes(player);
                SetPlayerToTeamColor(player);
            }
        }
        else if (FactionManage.GetPlayerGroupType(player) == FactionManage.FACTION_TYPE_MEDIC && (IsInRangeOfPoint(player.Position, new Vector3(-262.9533, 6312.083, 32.43641), 3)))
        {

            if (player.GetData("duty") == 0)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Du bist in den Dienst gegangen!");
                //NAPI.Notification.SendNotificationToPlayer(player, "Sie sind in Dienst~g~gegangn~w~ .");
                player.SetData("duty", 1);
                Outfits.SetUnisexOutfit(player, 1196);
                NAPI.Data.SetEntityData(player, "character_duty_outfit", 1196);
                SetPlayerToTeamColor(player);
            }
            else if (player.GetData("duty") == 1)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Du bist aus den Dienst gegangen!");
                //NAPI.Notification.SendNotificationToPlayer(player, "Sie sind noch im Dienst~w~.");
                player.SetData("duty", 0);
                Outfits.RemovePlayerDutyOutfit(player);
                UpdatePlayerClothes(player);
                SetPlayerToTeamColor(player);
            }
        }
        else if (FactionManage.GetPlayerGroupType(player) == FactionManage.FACTION_TYPE_MEDIC && (IsInRangeOfPoint(player.Position, new Vector3(1834.9865, 3693.3667, 34.27063), 3)))
        {

            if (player.GetData("duty") == 0)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Du bist in den Dienst gegangen!");
                //NAPI.Notification.SendNotificationToPlayer(player, "Sie sind in Dienst~g~gegangn~w~ .");
                player.SetData("duty", 1);
                Outfits.SetUnisexOutfit(player, 1196);
                NAPI.Data.SetEntityData(player, "character_duty_outfit", 1196);
                SetPlayerToTeamColor(player);
            }
            else if (player.GetData("duty") == 1)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Du bist aus den Dienst gegangen!");
                //NAPI.Notification.SendNotificationToPlayer(player, "Sie sind noch im Dienst~w~.");
                player.SetData("duty", 0);
                Outfits.RemovePlayerDutyOutfit(player);
                UpdatePlayerClothes(player);
                SetPlayerToTeamColor(player);
            }
        }
        else if (AccountManage.GetPlayerGroup(player) == 1 && IsInRangeOfPoint(player.Position, new Vector3(460.0612, -990.2727, 30.6896), 3))
        {
            if (player.GetData("duty") == 0)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Du bist in den Dienst gegangen!");
                player.SetData("duty", 1);
                Police.SetCopDefaultClothes(player);
                //NAPI.Util.ConsoleOutput("police");
                SetPlayerToTeamColor(player);
            }
            else if (player.GetData("duty") == 1)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Du bist aus den Dienst gegangen!");
                player.SetData("duty", 0);
                Outfits.RemovePlayerDutyOutfit(player);
                NAPI.Player.RemoveAllPlayerWeapons(player);
                WeaponManage.RemoveAllWeaponEx(player);
                UpdatePlayerClothes(player);
                SetPlayerToTeamColor(player);
            }
        }
        else if (AccountManage.GetPlayerGroup(player) == 21 && IsInRangeOfPoint(player.Position, new Vector3(-345.5088, -122.91604, 39.009655), 3))
        {
            if (player.GetData("duty") == 0)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Du bist in den Dienst gegangen!");
                player.SetData("duty", 1);
                SetPlayerToTeamColor(player);
            }
            else if (player.GetData("duty") == 1)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Du bist aus den Dienst gegangen!");
                player.SetData("duty", 0);
                SetPlayerToTeamColor(player);
            }
        }
        else if (AccountManage.GetPlayerGroup(player) == 24 && IsInRangeOfPoint(player.Position, new Vector3(-671.4221, 593.0613, 145.1697), 3))
        {
            if (player.GetData("duty") == 0)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Du bist in den Dienst gegangen!");
                player.SetData("duty", 1);
                Outfits.SetUnisexOutfit(player, 40);
                //NAPI.Util.ConsoleOutput("police");
                SetPlayerToTeamColor(player);
            }
            else if (player.GetData("duty") == 1)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Du bist aus den Dienst gegangen!");
                player.SetData("duty", 0);
                //Outfits.RemovePlayerDutyOutfit(player);
                NAPI.Player.RemoveAllPlayerWeapons(player);
                WeaponManage.RemoveAllWeaponEx(player);
                UpdatePlayerClothes(player);
                SetPlayerToTeamColor(player);
            }
        }
        else if (AccountManage.GetPlayerGroup(player) == 25 && IsInRangeOfPoint(player.Position, new Vector3(120.652, -727.4619, 242.1519), 3))
        {
            if (player.GetData("duty") == 0)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Du bist in den Dienst gegangen!");
                player.SetData("duty", 1);
                Outfits.SetUnisexOutfit(player, 658);
                //NAPI.Util.ConsoleOutput("police");
                SetPlayerToTeamColor(player);
            }
            else if (player.GetData("duty") == 1)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Du bist aus den Dienst gegangen!");
                player.SetData("duty", 0);
                //Outfits.RemovePlayerDutyOutfit(player);
                NAPI.Player.RemoveAllPlayerWeapons(player);
                WeaponManage.RemoveAllWeaponEx(player);
                UpdatePlayerClothes(player);
                SetPlayerToTeamColor(player);
            }
        }
        else if (AccountManage.GetPlayerGroup(player) == 26 && IsInRangeOfPoint(player.Position, new Vector3(-2353.141, 3257.135, 32.81075), 3))
        {
            if (player.GetData("duty") == 0)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Du bist in den Dienst gegangen!");
                player.SetData("duty", 1);
                Outfits.SetUnisexOutfit(player, 1301);
                //NAPI.Util.ConsoleOutput("police");
                SetPlayerToTeamColor(player);
            }
            else if (player.GetData("duty") == 1)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Du bist aus den Dienst gegangen!");
                player.SetData("duty", 0);
                Outfits.RemovePlayerDutyOutfit(player);
                NAPI.Player.RemoveAllPlayerWeapons(player);
                WeaponManage.RemoveAllWeaponEx(player);
                UpdatePlayerClothes(player);
                SetPlayerToTeamColor(player);
            }
        }
        else if (AccountManage.GetPlayerGroup(player) == 1 && IsInRangeOfPoint(player.Position, new Vector3(1852.207, 3689.865, 34.26708), 3))
        {
            if (player.GetData("duty") == 0)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Du bist in den Dienst gegangen!");
                player.SetData("duty", 1);
                Police.SetCopDefaultClothes(player);
                //NAPI.Util.ConsoleOutput("police");
                SetPlayerToTeamColor(player);
            }
            else if (player.GetData("duty") == 1)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Du bist aus den Dienst gegangen!");
                player.SetData("duty", 0);
                Outfits.RemovePlayerDutyOutfit(player);
                NAPI.Player.RemoveAllPlayerWeapons(player);
                WeaponManage.RemoveAllWeaponEx(player);
                UpdatePlayerClothes(player);
                SetPlayerToTeamColor(player);
            }
        }
        else if (AccountManage.GetPlayerGroup(player) == 1 && IsInRangeOfPoint(player.Position, new Vector3(-442.311, 6012.191, 31.71639), 3))
        {
            if (player.GetData("duty") == 0) { NAPI.Notification.SendNotificationToPlayer(player, "ERROR:~w~ Du bist außer Dienst.."); return; }
            Police.SetCopDefaultClothes(player);
            Police.DisplayCopUniforms(player);
            player.Rotation = new Vector3(0, 0, -2.309543);

        }
        else if (AccountManage.GetPlayerGroup(player) == 1 && IsInRangeOfPoint(player.Position, new Vector3(458.1619, -992.9954, 30.68959), 3))
        {
            if (player.GetData("duty") == 0) { NAPI.Notification.SendNotificationToPlayer(player, "ERROR:~w~ Du bist außer Dienst.."); return; }
            Police.SetCopDefaultClothes(player);
            Police.DisplayCopUniforms(player);
            player.Rotation = new Vector3(0, 0, -2.309543);

        }
        else if (AccountManage.GetPlayerGroup(player) == 1 && IsInRangeOfPoint(player.Position, new Vector3(451.6882, -993.0513, 30.68959), 3))
        {
            if (player.GetData("duty") == 0) { NAPI.Notification.SendNotificationToPlayer(player, "ERROR:~w~ Du bist außer Dienst.."); return; }
            Police.SetCopDefaultClothes(player);
            Police.DisplayCopUniforms(player);
            player.Rotation = new Vector3(0, 0, -1.24427);

        }
        else if (AccountManage.GetPlayerGroup(player) == 1 && IsInRangeOfPoint(player.Position, new Vector3(456.7283, -988.5403, 30.6896), 3))
        {
            if (player.GetData("duty") == 0) { NAPI.Notification.SendNotificationToPlayer(player, "ERROR:~w~ Du bist außer Dienst.."); return; }
            Police.SetCopDefaultClothes(player);
            Police.DisplayCopUniforms(player);
            player.Rotation = new Vector3(0, 0, -178.4332);

        }
        else if (AccountManage.GetPlayerGroup(player) == 1 && IsInRangeOfPoint(player.Position, new Vector3(1850.977, 3683.749, 34.26708), 3))
        {
            if (player.GetData("duty") == 0) { NAPI.Notification.SendNotificationToPlayer(player, "ERROR:~w~ Du bist außer Dienst.."); return; }
            Police.SetCopDefaultClothes(player);
            Police.DisplayCopUniforms(player);
            player.Rotation = new Vector3(0, 0, -178.4332);

        }
        else if (IsInRangeOfPoint(player.Position, new Vector3(-535.4819, -2846.199, 6.000383), 3f))
        {
            if (Main_Job.GetPlayerJob(player) == 10) Shipment.DisplayOrders(player);
            else InteractMenu_New.SendNotificationError(player, "Sie sind kein LKW-Fahrer, Sie können diesen Job im LS Job Center bekommen.");
        }
        else if (Main.IsInRangeOfPoint(player.Position, new Vector3(1031.024, -3203.098, -38.19354), 2.0f) || Main.IsInRangeOfPoint(player.Position, new Vector3(1017.242, -3198.394, -38.99321), 2.0f) || Main.IsInRangeOfPoint(player.Position, new Vector3(977.1298, -104.1134, 74.84519), 2.0f) || Main.IsInRangeOfPoint(player.Position, new Vector3(1096.997, -3192.923, -38.99346), 2.0f))
        {
            WerehouseManage.ShowHouseInventory(player);
        }
        else if (Main.IsInRangeOfPoint(player.Position, new Vector3(152.2726, -1001.37, -99), 2.0f) || Main.IsInRangeOfPoint(player.Position, new Vector3(350.7189, -993.5916, -99.19617), 2.0f) || Main.IsInRangeOfPoint(player.Position, new Vector3(-680.7666, 589.0926, 137.7698), 2.0f) || Main.IsInRangeOfPoint(player.Position, new Vector3(-765.5396, 330.8761, 196.086), 2.0f) || Main.IsInRangeOfPoint(player.Position, new Vector3(985.2975, 60.41732, 116.1642), 2.0f))
        {
            HouseSystem.ShowHouseInventory(player);
        }
        else
        {
            illegaleWaffen.PressKeyE(player);
            ATMSystem.ATMShow(player);
            Fish.PressKeyY(player);
            Farm.PressKeyY(player);
            Salt.PressKeyY(player);
            Apfel.PressKeyY(player);
            Beer.PressKeyY(player);
            Bergbau.PressKeyY(player);
            Blutwaschen.PressKeyY(player);
            Ecstasy.PressKeyY(player);
            Holz.PressKeyY(player);
            Pelz.PressKeyY(player);
            Penicillin.PressKeyY(player);
            Traube.PressKeyY(player);
            Wodka.PressKeyY(player);
            //DrillCrafting.PressKeyY(player);
            PropylenCrafting.PressKeyY(player);
            Schlüsseldienst.PressKeyE(player);
            Metall.PressKeyY(player);
            Weed.PressKeyY(player);
            Meth.PressKeyY(player);
            EntraceSystem.PressKeyY(player);
            SecreatsSystem.PressKeyY(player);
            HouseSystem.PressKeyY(player);
            //Fish.PressKeyY(player);
            DriverLicense.PressKeyY(player);
            bankRobbery.KeyPressY(player);
            BlackMarket.PressKeyY(player);
            PoliceStore.PressKeyY(player);
            LKWStore.PressKeyY(player);
            LSCCostumStore.PressKeyY(player);
            MedicSnackStore.PressKeyY(player);
            ACLSStore.PressKeyY(player);
            HouseStore.PressKeyY(player);
            CarDealerSnackStore.PressKeyY(player);
            MedicStore.PressKeyY(player);
            UsefullyRP.KeyPressY(player);
            HouseSystem.ShowHouseInventory(player);
            Hotel.KeyPressE(player);
            Zulassung.PlayerPressKeyE(player);
            JobCenter.PlayerPressKeyE(player);
            LOrder.PlayerPressKeyE(player);
            HouseSystem.ShowHouseInventory(player);

            int count = 0;

            int business_id = 0;
            foreach (var business in Business.business_list)
            {
                if (IsInRangeOfPoint(player.Position, business.business_clothes_shirt, 3))
                {
                    player.Rotation = new Vector3(0, 0, business.business_clothes_shirt_rotation);
                    if (player.GetData("CHARACTER_ONLINE_GENRE") == 1)
                    {

                        femaleClothes.ShowClothesMainMenu(player, 0, "MAINMENU_CLOTHES_SHIRT");

                    }
                    else
                    {
                        femaleClothes.ShowClothesMainMenu(player, 8, "MAINMENU_CLOTHES_SHIRT");
                    }
                }
                else if (IsInRangeOfPoint(player.Position, business.business_clothes_legs, 3))
                {
                    player.Rotation = new Vector3(0, 0, business.business_clothes_legs_rotation);

                    Barber.DisplayMenu(player);
                }
                else if (IsInRangeOfPoint(player.Position, new Vector3(business.business_store_buy_x, business.business_store_buy_y, business.business_store_buy_z), 3))
                {
                    GeneralStore.ShowGeneralStoreMenu(player);
                }
                else if (IsInRangeOfPoint(player.Position, new Vector3(business.business_freetimestore_buy_x, business.business_freetimestore_buy_y, business.business_freetimestore_buy_z), 3))
                {
                    FreeTimeStore.ShowFreeTimeStoreMenu(player);
                }
                else if (IsInRangeOfPoint(player.Position, new Vector3(business.business_juvestore_buy_x, business.business_juvestore_buy_y, business.business_juvestore_buy_z), 3))
                {
                    JuveStore.ShowJuveStoreMenu(player);
                }
                else if (IsInRangeOfPoint(player.Position, new Vector3(business.business_phonestore_buy_x, business.business_phonestore_buy_y, business.business_phonestore_buy_z), 3))
                {
                    PhoneStore.ShowPhoneStoreMenu(player);
                }
                else if (IsInRangeOfPoint(player.Position, business.business_object_MarkerID.Position + new Vector3(0, 0, 1.0), 0.85f))
                {
                    if ((business.business_Type == 4 || business.business_Type == 6 || business.business_Type == 7 || business.business_Type == 8 || business.business_Type == 9) && Business.GetPlayerBusinessKey(player) == business_id)
                    {
                        CarDealership.ShowDealershipManage(player);
                    }
                    else if (Business.GetPlayerBusinessKey(player) == business_id)
                    {
                        player.TriggerEvent("BusinessPlayerMenuHide");
                        Business.ShowBusinessMenu(player);
                    }
                }
                else if (IsInRangeOfPoint(player.Position, business.business_dealership_buy, 0.85f))
                {
                    CarDealership.ShowDealerShipVehicles(player);
                }
                else if (IsInRangeOfPoint(player.Position, business.ammunation_position, 0.85f))
                {
                    if (business.business_Inventory < 1)
                    {
                        DisplayErrorMessage(player, "Wir sind momentan nicht da. Komm später zurück ...");
                    }
                    else Menus.CreateMenu(player, 15);
                }
                else if (IsInRangeOfPoint(player.Position, business.business_clothes_acessories, 3))
                {
                    player.Rotation = new Vector3(0, 0, business.business_clothes_acessories_rotation);
                    if (player.GetData("CHARACTER_ONLINE_GENRE") == 1)
                    {
                        TattooShop.ShowClothesMainMenu(player, "MAINMENU_TATTOO_STUDIO");
                    }
                    else
                    {
                        TattooShop.ShowClothesMainMenu(player, "MAINMENU_TATTOO_STUDIO");
                    }
                }
                business_id++;
            }
            foreach (var faction in FactionManage.faction_data)
            {
                if (IsInRangeOfPoint(player.Position, new Vector3(faction.faction_armory_x, faction.faction_armory_y, faction.faction_armory_z), 1))
                {
                    if (AccountManage.GetPlayerGroup(player) != faction.faction_id)
                    {
                        NAPI.Notification.SendNotificationToPlayer(player, "ERROR: Dieser Schrank stammt nicht von Ihrer Organisation.", true);
                        return;
                    }
                    if (player.GetData("duty") == 0)
                    {
                        NAPI.Notification.SendNotificationToPlayer(player, "ERROR: Du musst erst im Dienst sein!", true);
                        return;
                    }
                    List<dynamic> menu_item_list = new List<dynamic>();
                    for (int i = 0; i < 20; i++)
                    {

                        if (faction.faction_armory_gun[i] == "0")
                        {
                            menu_item_list.Add(new { Type = 1, Name = "~w~" + i + ". ~c~Leer", Description = "", RightLabel = "" });
                        }
                        else
                        {
                            menu_item_list.Add(new { Type = 1, Name = "~w~" + i + ". ~y~" + faction.faction_armory_gun[i] + "", Description = "", RightLabel = "(Kosten:" + faction.faction_armory_price[i] + " Berufung)" });
                        }

                    }
                    InteractMenu.CreateMenu(player, "ARMORY_BUY_RESPONSE", "Armory", "~b~" + faction.faction_name + ":", true, JsonConvert.SerializeObject(menu_item_list), false);
                    return;
                }
            }

            foreach (var aluguel in RentVehicle.Aluguel_Positions)
            {
                if (Main.IsInRangeOfPoint(player.Position, aluguel.position, 2.0f) && !player.IsInVehicle)
                {
                    List<dynamic> menu_item_list = new List<dynamic>();
                    for (int i = 0; i < 5; i++)
                    {
                        menu_item_list.Add(new { Type = 1, Name = "" + RentVehicle.vehicle_rent_available_list[i].vehicle_name + "", Description = "", RightLabel = "~c~Preis: ~g~$~w~" + RentVehicle.vehicle_rent_available_list[i].vehicle_price + "" });
                    }
                    InteractMenu.CreateMenu(player, "RENT_VEHICLE_RESPONSE", "Aluguel", "Fahrrad Verleih - ~w~Fahrard Verleiher: ", true, JsonConvert.SerializeObject(menu_item_list), false);
                }
            }
            count = 0;
            foreach (var werehouse in WerehouseManage.WereHouseData)
            {
                if (IsInRangeOfPoint(player.Position, new Vector3(werehouse.exterior_x, werehouse.exterior_y, werehouse.exterior_z), 1))
                {
                    if (werehouse.lockStatus == true && werehouse.ownerid != AccountManage.GetPlayerGroup(player))
                    {
                        NAPI.Notification.SendNotificationToPlayer(player, "ERROR:~w~ Diese Tür ist verschlossen..");
                        return;
                    }

                    player.Position = new Vector3(werehouse.interior_x, werehouse.interior_y, werehouse.interior_z);
                    player.Rotation = new Vector3(0.0f, 0.0f, werehouse.interior_a);
                    player.Dimension = (uint)count + 500;
                }
                else if (IsInRangeOfPoint(player.Position, new Vector3(werehouse.interior_x, werehouse.interior_y, werehouse.interior_z), 1) && NAPI.Entity.GetEntityDimension(player) == count + 500)
                {
                    player.Position = new Vector3(werehouse.exterior_x, werehouse.exterior_y, werehouse.exterior_z);
                    player.Rotation = new Vector3(0.0f, 0.0f, werehouse.exterior_a);
                    player.Dimension = 0;
                }
                else if (IsInRangeOfPoint(player.Position, new Vector3(werehouse.menu_x, werehouse.menu_y, werehouse.menu_z), 1) && NAPI.Entity.GetEntityDimension(player) == count + 500)
                {
                    //NAPI.Util.ConsoleOutput("here11 :: " + (count + 500) + "");
                    WerehouseManage.ShowWarehouseMenu(player);
                    return;
                }
                count++;
            }
            count = 0;
            player.TriggerEvent("fetch_nearby_atms", true);
        }
    }


    [RemoteEvent("keypress:K")]
    public void KeyPressK(Client player)
    {
            if (player.GetData("status") == false)
            {
                return;
            }
            Fish.PressKeyK(player);
    }

    public static void CMD_VehLocked(Client player)
    {
        Vehicle vehicle = Utils.GetClosestVehicle(player, 5.0f);
        //if (!Main.IsInRangeOfPoint(player.Position, vehicle.Position, 5.0f))
        //{
        //    InteractMenu_New.SendNotificationError(player, "Sie sind zuweit vom Fahrzeug entfernt.");
        //    return;
        //}
        //else
        //{
        //Vehicle door_vehicle_handle = (Vehicle)Activator.CreateInstance(typeof(Vehicle), (System.Reflection.BindingFlags)0xFFFF, null, new object[] { this, vehicle }, null, null);
            int playerid = getIdFromClient(player);
        //if (Inventory.GetInventoryIndexFromName(player, "Fahrzeug Schlüssel"))
        //{
        for (int index = 0; index < PlayerVehicle.MAX_PLAYER_VEHICLES; index++)
        {
            if (PlayerVehicle.vehicle_data[playerid].state[index] == 1 && PlayerVehicle.vehicle_data[playerid].handle[index].Exists && vehicle == PlayerVehicle.vehicle_data[playerid].handle[index])
            {
                if (NAPI.Vehicle.GetVehicleLocked(vehicle) == true)
                {
                    NAPI.Vehicle.SetVehicleLocked(vehicle, false);
                    //player.TriggerEvent("createNewHeadNotificationAdvanced", "Du hast dein Fahrzeug ~g~aufgschlossen");
                    Notify.Send(player, NotifyType.Success, NotifyPosition.BottomCenter, $"Du hast dein Fahrzeug aufgeschlossen!", 5000);
                    //NAPI.Notification.SendNotificationToPlayer(player, "Du hast dein Fahrzeug ~g~aufgeschlossen");
                }
                else
                {
                    NAPI.Vehicle.SetVehicleLocked(vehicle, true);
                    //player.TriggerEvent("createNewHeadNotificationAdvanced", "Du hast dein Fahrzeug abgeschlossen");
                    Notify.Send(player, NotifyType.Success, NotifyPosition.BottomCenter, $"Du hast dein Fahrzeug abgeschlossen!", 5000);
                    //NAPI.Notification.SendNotificationToPlayer(player, "Du hast dein Fahrzeug abgeschlossen");
                }
                return;
            }
        }

        //for (int i = 0; i < FactionManage.MAX_FACTION_VEHICLES; i++)
        //{

        //    if (FactionManage.faction_data[AccountManage.GetPlayerGroup(player)].faction_vehicle_owned[i] != "Ninguem" && FactionManage.faction_data[AccountManage.GetPlayerGroup(player)].faction_vehicle_entity[i] == vehicle)
        //    {
        //        if (NAPI.Vehicle.GetVehicleLocked(vehicle) == true)
        //        {
        //            NAPI.Vehicle.SetVehicleLocked(vehicle, false);
        //            //player.TriggerEvent("createNewHeadNotificationAdvanced", "Du hast dein Fahrzeug ~g~aufgschlossen");
        //            NAPI.Notification.SendNotificationToPlayer(player, "Du hast dein Fahrzeug ~g~aufgeschlossen");
        //        }
        //        else
        //        {
        //            NAPI.Vehicle.SetVehicleLocked(vehicle, true);
        //            //player.TriggerEvent("createNewHeadNotificationAdvanced", "Du hast dein Fahrzeug abgeschlossen");
        //            NAPI.Notification.SendNotificationToPlayer(player, "Du hast dein Fahrzeug abgeschlossen");
        //        }
        //        return;
        //    }
        //}

        //for (int b = 0; b<RentVehicle.MAX_RENT_VEHICLES; b++)
        //        {
        //            if (RentVehicle.vehicle_rent_list[b].vehicle_free == true && RentVehicle.vehicle_rent_list[b].vehicle_ownedBy == AccountManage.GetPlayerSQLID(player) && RentVehicle.vehicle_rent_list[b].vehicle_entity == vehicle)
        //            {
        //                if (NAPI.Vehicle.GetVehicleLocked(vehicle) == true)
        //                {
        //                    NAPI.Vehicle.SetVehicleLocked(vehicle, false);
        //                //player.TriggerEvent("createNewHeadNotificationAdvanced", "Du hast dein Fahrzeug ~g~aufgschlossen");
        //                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du hast dein Fahrzeug ~g~aufgeschlossen");
        //                }
        //                else
        //                {
        //                    NAPI.Vehicle.SetVehicleLocked(vehicle, true);
        //                //player.TriggerEvent("createNewHeadNotificationAdvanced", "Du hast dein Fahrzeug abgeschlossen");
        //                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du hast dein Fahrzeug abgeschlossen");
        //                }
        //                return;
        //            }
        //        }
        //   return;
        //    //    Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du bist bei kein Fahrzeug!");
        ////}
    }    

    public static void VehicleEngineStarting(Client player)
    {
        ////API.Util.ConsoleOutput("OK THIS CALLED ! WHY DONT WORK");
        if (player.GetData("status") == false)
        {
            return;
        }
        if (player.IsInVehicle && player.VehicleSeat == -1)
        {

            if (NAPI.Vehicle.GetVehicleEngineStatus(player.Vehicle) == true)
            {
                //sendProxMessage(player, 15.0f, "C2A2DA", "** " + AccountManage.GetCharacterName(player) + " coloca a chave na ignição e desliga o motor do veículo.");

                NAPI.Vehicle.SetVehicleEngineStatus(player.Vehicle, false);
                NAPI.ClientEvent.TriggerClientEvent(player, "Notification.SendPictureNotification", "Fahrzeug", "Abschalten", $"Du hast den Motorabgeschaltet", "DIA_SECURITY", true);
            }
            else if (NAPI.Vehicle.GetVehicleEngineStatus(player.Vehicle) == false && player.GetData("StartEngineStatus") == false)
            {
                // Am WE wieder freigeben
                //if (Inventory.GetPlayerItemFromInventory(player, 157) < 1)
                //{
                //    NAPI.Notification.SendNotificationToPlayer(player, "Du hast kein Fahrzeug Schlüssel dabei!");
                //    return;
                //}

                if (player.HasData("Refueling"))
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "Sie können das Fahrzeug während des Tankens nicht einschalten.");
                    return;
                }
                if (player.Vehicle.Health <= 950)
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "Dein Fahrzeug ist zu sehr zerstört um es zu starten!");
                    return;
                }
                //player.TriggerEvent("createNewHeadNotificationAdvanced", "");
                player.SetData("StartEngineStatus", true);

                NAPI.Task.Run(() =>
                {
                    player.SetData("StartEngineStatus", false);
                    if (player.IsInVehicle && player.VehicleSeat == -1)
                    {
                        //if (Inventory.GetPlayerItemFromInventory(player, 157) < 1)
                        //{
                        //    NAPI.Notification.SendNotificationToPlayer(player, "Du hast kein Fahrzeug Schlüssel dabei!");
                        //    return;
                        //}

                        if (player.Vehicle.Health < 960)
                        {
                            //player.TriggerEvent("createNewHeadNotificationAdvanced", "Der Motor des Fahrzeugs ist im Leerlauf. Wenden Sie sich an einen Mechaniker, um das Problem zu beheben.");
                            NAPI.Notification.SendNotificationToPlayer(player, "Der Motor des Fahrzeugs ist im Leerlauf. Wenden Sie sich an den ACLS, um das Problem zu beheben");
                            return;
                        }

                        if (NAPI.Data.HasEntityData(player.Vehicle, "vehicle_colision"))
                        {
                            //player.TriggerEvent("createNewHeadNotificationAdvanced", "Der Fahrzeugmotor ist im Leerlauf. Versuchen Sie es erneut...");
                            NAPI.Notification.SendNotificationToPlayer(player, "Der Fahrzeugmotor ist im Leerlauf. Versuchen Sie es erneut...");
                            return;
                        }

                        if (GetVehicleFuel(player.Vehicle) <= 2)
                        {
                            //player.TriggerEvent("createNewHeadNotificationAdvanced", "Das Fahrzeug ist ohne Kraftstoff, man muss einen mechanischen Mechaniker rufen, um es zu befüllen.");
                            NAPI.Notification.SendNotificationToPlayer(player, "Das Fahrzeug ist ohne Kraftstoff, man muss einen von den ACLS rufen, um es zu befüllen");
                            return;
                        }

                        if (player.Vehicle.Health <= 950)
                        {
                            NAPI.Notification.SendNotificationToPlayer(player, "Dein Fahrzeug ist zu sehr zerstört um es zu starten!");
                            return;
                        }

                        NAPI.Vehicle.SetVehicleEngineStatus(player.Vehicle, true);
                        NAPI.ClientEvent.TriggerClientEvent(player, "Notification.SendPictureNotification", "Fahrzeug", "Einschalten", $"Sie haben den Fahrzeugmotor ~g~eingeschaltet", "DIA_SECURITY", true);
                    }
                }, delayTime: 100);
            }
            if (player.Vehicle.Health <= 950)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Dein Fahrzeug ist zu sehr zerstört um es zu starten!");
                return;
            }
            else
            {
                NAPI.Util.ConsoleOutput("[GET VEHICLE ENGINE STARTING] " + player.SocialClubName + " hat versucht das Fahrzeug zu starten! ");
                //none msg
            }
        }
    }

    [RemoteEvent("keypress:Y")]
    public void KeyPressY(Client player)
    {
        try
        {
            if (player.GetData("status") == false)
            {
                return;
            }
            if (AccountManage.GetPlayerGroup(player) == 1 || AccountManage.GetPlayerGroup(player) == 2 || AccountManage.GetPlayerGroup(player) == 5 || AccountManage.GetPlayerGroup(player) == 11 || AccountManage.GetPlayerGroup(player) == 15 || AccountManage.GetPlayerGroup(player) == 16 || AccountManage.GetPlayerGroup(player) == 17 || AccountManage.GetPlayerGroup(player) == 21 || AccountManage.GetPlayerGroup(player) == 25 || AccountManage.GetPlayerGroup(player) == 26)
            {
                int business_id = Business.GetPlayerInBusinessInType(player, 5);
                if (business_id != -1)
                {
                    int pump_id = FuelBusiness.GetClosestGasPump(player, business_id);
                    if (pump_id != -1)
                    {
                        FuelBusiness.CMD_tanken(player);
                    }
                }

                if (player.IsInVehicle && player.VehicleSeat == -1)
                {

                    if (NAPI.Vehicle.GetVehicleEngineStatus(player.Vehicle) == true)
                    {
                    //sendProxMessage(player, 15.0f, "C2A2DA", "** " + AccountManage.GetCharacterName(player) + " coloca a chave na ignição e desliga o motor do veículo.");

                        NAPI.Vehicle.SetVehicleEngineStatus(player.Vehicle, false);
                        NAPI.ClientEvent.TriggerClientEvent(player, "Notification.SendPictureNotification", "Fahrzeug", "Abschalten", $"Du hast den Motorabgeschaltet", "DIA_SECURITY", true);
                        PlayerVehicle.CMD_estacionar(player);
                    }
                    else if (NAPI.Vehicle.GetVehicleEngineStatus(player.Vehicle) == false && player.GetData("StartEngineStatus") == false)
                    {
                        if (player.HasData("Refueling"))
                        {
                            NAPI.Notification.SendNotificationToPlayer(player, "Sie können das Fahrzeug während des Tankens nicht einschalten.");
                            return;
                        }
                        if (player.Vehicle.Health <= 950)
                        {
                            NAPI.Notification.SendNotificationToPlayer(player, "Dein Fahrzeug ist zu sehr zerstört um es zu starten!");
                            return;
                        }
                    //player.TriggerEvent("createNewHeadNotificationAdvanced", "");
                        player.SetData("StartEngineStatus", true);

                        NAPI.Task.Run(() =>
                        {
                            player.SetData("StartEngineStatus", false);
                            if (player.IsInVehicle && player.VehicleSeat == -1)
                            {
                                // Am WE wieder freigeben
                                //if (Inventory.GetPlayerItemFromInventory(player, 157) < 1)
                                //{
                                //    NAPI.Notification.SendNotificationToPlayer(player, "Du hast kein Fahrzeug Schlüssel dabei!");
                                //    return;
                                //}

                                if (player.Vehicle.Health < 960)
                                {
                                //player.TriggerEvent("createNewHeadNotificationAdvanced", "Der Motor des Fahrzeugs ist im Leerlauf. Wenden Sie sich an einen Mechaniker, um das Problem zu beheben.");
                                    NAPI.Notification.SendNotificationToPlayer(player, "Der Motor des Fahrzeugs ist im Leerlauf. Wenden Sie sich an den ACLS, um das Problem zu beheben");
                                    return;
                                }

                                if (NAPI.Data.HasEntityData(player.Vehicle, "vehicle_colision"))
                                {
                                    //player.TriggerEvent("createNewHeadNotificationAdvanced", "Der Fahrzeugmotor ist im Leerlauf. Versuchen Sie es erneut...");
                                    NAPI.Notification.SendNotificationToPlayer(player, "Der Fahrzeugmotor ist im Leerlauf. Versuchen Sie es erneut...");
                                    return;
                                }

                                if (GetVehicleFuel(player.Vehicle) <= 2)
                                {
                                    //player.TriggerEvent("createNewHeadNotificationAdvanced", "Das Fahrzeug ist ohne Kraftstoff, man muss einen mechanischen Mechaniker rufen, um es zu befüllen.");
                                    NAPI.Notification.SendNotificationToPlayer(player, "Das Fahrzeug ist ohne Kraftstoff, man muss einen von den ACLS rufen, um es zu befüllen");
                                    return;
                                }

                                if (player.Vehicle.Health <= 950)
                                {
                                    NAPI.Notification.SendNotificationToPlayer(player, "Dein Fahrzeug ist zu sehr zerstört um es zu starten!");
                                    return;
                                }

                                NAPI.Vehicle.SetVehicleEngineStatus(player.Vehicle, true);
                                NAPI.ClientEvent.TriggerClientEvent(player, "Notification.SendPictureNotification", "Fahrzeug", "Einschalten", $"Sie haben den Fahrzeugmotor ~g~eingeschaltet", "DIA_SECURITY", true);
                            }
                        }, delayTime: 100);
                    }
                    if (player.Vehicle.Health <= 950)
                    {
                        NAPI.Notification.SendNotificationToPlayer(player, "Dein Fahrzeug ist zu sehr zerstört um es zu starten!");
                        return;
                    }
                    else
                    {
                        NAPI.Util.ConsoleOutput("[GET VEHICLE ENGINE STARTING] " + player.SocialClubName + " hat versucht das Fahrzeug zu starten! ");
                        //none msg
                    }  
                }
            }
        }
        catch (Exception e)
        {
            Log.Write("keypress:Y Event: " + e.Message, nLog.Type.Error);
        }
    }

    public static bool IsInRangeOfPoint(Vector3 playerPos, Vector3 target, float range)
    {
        var direct = new Vector3(target.X - playerPos.X, target.Y - playerPos.Y, target.Z - playerPos.Z);
        var len = direct.X * direct.X + direct.Y * direct.Y + direct.Z * direct.Z;
        return range * range > len;
    }

    public static void ShowTextForPlayer(Client player, string message, int timer)
    {
        NAPI.Data.SetEntityData(player, "ShowTextForPlayer", timer);
        player.TriggerEvent("show_text_for_player", message);
    }

    public void GlobalTime() // 1 sec
    {
        try
        {
            TimerEx.SetTimer(() =>
            {
                var players = NAPI.Pools.GetAllPlayers();
                foreach (var player in players)
                {

                    if (player.GetData("status") == true)
                    {
                        if (player.IsInVehicle)
                        {
                            if (player.GetData("DisplayRadar") == false)
                            {
                                DisplayRadar(player, false);
                            }
                        }
                        else
                        {
                            if (player.GetData("DisplayRadar") == true)
                            {
                                DisplayRadar(player, false);
                            }
                        }
                        player.TriggerEvent("update_health", player.Health);
                        player.TriggerEvent("update_armor", player.Armor);

                        player.SetData("connectSeconds", player.GetData("connectSeconds") + 1);

                        if (player.GetData("connectSeconds") > 180)
                        {
                            AccountManage.SaveCharacter(player);
                            player.SetData("connectSeconds", 0);
                        }

                        if (player.GetData("inEffect_weed") > 0)
                        {
                            player.SetData("inEffect_weed", player.GetData("inEffect_weed") - 1);

                            if (player.GetData("inEffect_weed") == 0)
                            {
                                //SendMessageWithTagToPlayer(player, "" + Main.EMBED_GREEN + "[Drogen]", "" + Main.EMBED_WHITE + "Der Marihuana - Effekt ist vorbei.");
                                player.TriggerEvent("stop_screen_effect", "DrugsMichaelAliensFight");
                                player.SetData("inEffect_weed", -1);
                            }
                        }

                        if (player.GetData("inEffect_heroin") > 0)
                        {
                            player.SetData("inEffect_heroin", player.GetData("inEffect_heroin") - 1);

                            if (player.GetData("inEffect_heroin") == 0)
                            {
                                player.TriggerEvent("setResistStage", 0);
                                //SendMessageWithTagToPlayer(player, "" + Main.EMBED_GREEN + "[Drogen]", "" + Main.EMBED_WHITE + "Der Kokain - Effekt ist vorbei.");
                                player.TriggerEvent("stop_screen_effect", "DrugsDrivingOut");
                                player.TriggerEvent("screen_cocaine_off");
                                player.SetData("inEffect_heroin", -1);
                            }
                        }

                        if (player.GetData("character_prison") == 1)
                        {

                            if (player.GetData("character_prison_time") > 0)
                            {
                                player.SetData("character_prison_time", player.GetData("character_prison_time") - 1);
                                player.TriggerEvent("JailTime", player.GetData("character_prison_time"));

                                if (!IsInRangeOfPoint(player.Position, prison_spawns[player.GetData("character_prison_cell")].position, 16155.25f))
                                {
                                    player.Position = prison_spawns[player.GetData("character_prison_cell")].position;
                                    player.Rotation = prison_spawns[player.GetData("character_prison_cell")].rotation;
                                }
                            }
                            else
                            {
                                player.TriggerEvent("JailTime", 0);
                                UpdatePlayerClothes(player);
                                player.SetData("character_prison", 0);
                                player.SetData("character_prison_time", 0);
                                NAPI.Notification.SendNotificationToPlayer(player, "Sie haben Ihre Schulden an die Gesellschaft bezahlt!");

                                player.Position = new Vector3(1848.225, 2607.912, 45.58563);
                                player.Rotation = new Vector3(0, 0, 265.342);
                                //player.TriggerEvent("freeze", false);
                                player.TriggerEvent("freeze", false);
                                if (NAPI.Data.GetEntityData(player, "MainProgressText") == true)
                                {
                                    DeleteTextProgressBar(player);
                                }
                            }
                        }

                        if (player.GetData("character_ooc_prison_time") > 0)
                        {
                            player.SetData("character_ooc_prison_time", player.GetData("character_ooc_prison_time") - 1);
                            player.TriggerEvent("JailTime", player.GetData("character_ooc_prison_time"));

                            if (!IsInRangeOfPoint(player.Position, new Vector3(1651.297, 2573.728, 45.56485), 17.25f))
                            {
                                player.Position = new Vector3(1651.297, 2573.728, 45.56485);
                                player.Rotation = new Vector3(0, 0, 181.6034);
                                player.Dimension = 255;
                            }

                            if (player.GetData("character_ooc_prison_time") == 0)
                            {
                                player.TriggerEvent("JailTime", 0);

                                NAPI.Notification.SendNotificationToPlayer(player, "~y~Sie haben Ihre Schulden bei der Gesellschaft bezahlt!");
                                NAPI.Notification.SendNotificationToPlayer(player, "TIPP: Befolgen Sie die Regeln des Servers ordnungsgemäß, oder Sie werden möglicherweise gesperrt.");

                                player.Position = new Vector3(1852.602, 2585.687, 45.67206);
                                player.Rotation = new Vector3(0, 0, 263.0871);
                                player.Dimension = 0;
                            }
                        }


                        if (player.GetSharedData("Injured") == 1 && player.GetData("character_prison") == 0)
                        {
                            player.SetSharedData("InjuredTime", player.GetSharedData("InjuredTime") - 1);
                            //NAPI.Player.PlayPlayerAnimation(player, 33, "dead", "dead_d");
                        }

                        if (player.GetSharedData("Injured") == 2 && player.GetData("character_prison") == 0)
                        {
                            player.SetSharedData("InjuredTime", player.GetSharedData("InjuredTime") - 1);

                            if (player.GetSharedData("InjuredTime") < 1)
                            {
                                player.SetSharedData("Injured", 0);
                                player.SetSharedData("InjuredTime", 0);

                                //player.TriggerEvent("DestroyCustomCamera");

                                Random rnd = new Random();
                                int random_spawn = rnd.Next(0, 1);
                                switch (random_spawn)
                                {
                                    case 0:
                                        {

                                            player.Position = new Vector3(-496.8302, -336.1777, 34.50175);
                                            player.Rotation = new Vector3(0, 0, 250.2939);
                                            break;
                                        }
                                    case 1:
                                        {
                                            player.Position = new Vector3(-496.8302, -336.1777, 34.50175);
                                            player.Rotation = new Vector3(0, 0, 250.2939);
                                            break;
                                        }
                                }
                                player.Dimension = 0;
                                //player.TriggerEvent("freeze", false);
                                player.TriggerEvent("freeze", false);
                                player.TriggerEvent("freezeEx", false);

                                NAPI.Notification.SendNotificationToPlayer(player, "Ihre Arztkosten im ~y~Krankenhaus~w~ betrugen ~g~$500~w~, diese wurden Ihnen abgezogen!");
                                GivePlayerMoney(player, -500);

                                AccountManage.SetPlayerHunger(player, 50.0f);
                                AccountManage.SetPlayerThirsty(player, 40.0f);

                                player.Health = 100;
                                player.TriggerEvent("update_health", player.Health);
                                player.Armor = 0;
                                player.SetSharedData("character_hospital", 0);
                            }
                        }

                        // Low Health Screen Effect
                        if (player.Health <= 39 && player.GetData("LowHealthEffect") == false)
                        {
                            player.SetData("LowHealthEffect", true);

                            Utils.SetScreenEffectToPlayer(player, "FocusIn", 2000);
                        }
                        else if (player.Health >= 40 && NAPI.Data.HasEntityData(player, "LowHealthEffect") == true)
                        {
                            player.SetData("LowHealthEffect", false);

                            Utils.StopScreenEffectToPlayer(player, "FocusIn");
                        }

                        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
                        {
                            Mainpipeline.Open();
                            MySqlCommand query = new MySqlCommand("SELECT * FROM `users` WHERE `username` = '" + player.SocialClubName + "';", Mainpipeline);
                            using (MySqlDataReader reader = query.ExecuteReader())
                            {

                                string data2txt = string.Empty;
                                string datatxt = string.Empty;

                                while (reader.Read())
                                {
                                    if (reader.GetInt32("banAces") == 0)
                                    {
                                        player.TriggerEvent("Display_Banned_Screen");
                                        //player.TriggerEvent("Display_Banned_Screen");
                                        player.Kick();
                                        return;
                                    }
                                }
                            }
                        }

                        if (player.GetData("admin_duty") == 0 && player.GetSharedData("Injured") == 0 && player.GetData("character_ooc_prison_time") == 0 && player.GetData("character_prison") == 0)
                        {
                            // Hunger and Thirsty System
                            player.SetData("HungerTimer", player.GetData("HungerTimer") + 1);

                            if (player.GetData("HungerTimer") >= 25)
                            {

                                player.SetData("HungerTimer", 0);

                                if (NAPI.Data.GetEntityData(player, "Hunger") < 1)
                                {
                                    player.SetData("Hunger", 0);
                                }
                                else if (NAPI.Data.GetEntityData(player, "character_prison") == 0) player.SetData("Hunger", NAPI.Data.GetEntityData(player, "Hunger") - 0.35);


                                if (NAPI.Data.GetEntityData(player, "Thirsty") < 1)
                                {
                                    player.SetData("Thirsty", 0);
                                }
                                else if (NAPI.Data.GetEntityData(player, "character_prison") == 0) player.SetData("Thirsty", NAPI.Data.GetEntityData(player, "Thirsty") - 0.40);

                                if (NAPI.Data.GetEntityData(player, "Hunger") == 0 && NAPI.Data.GetEntityData(player, "Thirsty") == 0)
                                {

                                    NAPI.Notification.SendNotificationToPlayer(player, "ACHTUNG: ~w~Sie sterben an Hunger und ~w~ an ~b~ Durst ~w~!");
                                }
                                else if (NAPI.Data.GetEntityData(player, "Hunger") == 0)
                                {
                                    NAPI.Notification.SendNotificationToPlayer(player, "ACHTUNG!:~w~ Du stirbst daran wenn du nichts ~y~essen~w~ wirst!");
                                }
                                else if (NAPI.Data.GetEntityData(player, "Thirsty") == 0)
                                {
                                    NAPI.Notification.SendNotificationToPlayer(player, "ACHTUNG!:~w~ Du stirbst daran wenn du nichts ~b~Trinkst~w~!");
                                }

                                NAPI.ClientEvent.TriggerClientEvent(player, "update_hunger_display", (int)player.GetData("Hunger"), (int)player.GetData("Thirsty"));
                                //RemoteEventManager.RegisterClientEvent("update_hunger_display", player.GetData("Hunger"));
                                //RemoteEventManager.RegisterClientEvent("update_hunger_display", player.GetData("Thirsty"));
                            }

                            if (NAPI.Data.GetEntityData(player, "Hunger") < 1)
                            {
                                if (player.Health > 0)
                                {
                                    player.Health--;
                                    player.TriggerEvent("update_health", player.Health);
                                }
                                else
                                {
                                    player.Health = -1;
                                }
                            }

                            if (NAPI.Data.GetEntityData(player, "Thirsty") < 1)
                            {
                                if (player.Health > 0)
                                {
                                    player.Health--;
                                    player.TriggerEvent("update_health", player.Health);
                                }
                                else
                                {
                                    player.Health = -1;
                                }
                            }

                            //if (NAPI.Data.GetEntityData(player, "ShowTextForPlayer") > 0)
                            //    {
                            //        int time = NAPI.Data.GetEntityData(player, "ShowTextForPlayer");
                            //        NAPI.Data.SetEntityData(player, "ShowTextForPlayer", --time);

                            //        if (NAPI.Data.GetEntityData(player, "ShowTextForPlayer") == 0)
                            //        {
                            //            NAPI.Data.SetEntityData(player, "ShowTextForPlayer", -1);
                            //            player.TriggerEvent("hide_text_for_player");
                            //        }
                            //    }
                        }
                        if (NAPI.Data.GetEntityData(player, "LastTransaction") > 0)
                        {
                            if (NAPI.Data.GetEntityData(player, "LastTransaction") > 0)
                            {
                                int time = NAPI.Data.GetEntityData(player, "LastTransaction");
                                NAPI.Data.SetEntityData(player, "LastTransaction", --time);

                                if (NAPI.Data.GetEntityData(player, "LastTransaction") == 0) NAPI.Data.SetEntityData(player, "LastTransaction", -1);
                            }
                        }
                        if (NAPI.Data.HasEntityData(player, "player_in_turf"))
                        {
                            if (player.GetData("player_in_turf") != -1 && player.Dimension == 0)
                            {
                                int tw = player.GetData("player_in_turf");
                                int iGroupID = AccountManage.GetPlayerGroup(player);

                                if (TurfWar.turf_war[tw].ownerid == -1)
                                {
                                    player.TriggerEvent("CurrentTurf", "~y~-~w~ " + TurfWar.turf_war[tw].name + " ~y~-~w~~n~~y~Gebiet: ~w~ Nicht besetzt");

                                }
                                else player.TriggerEvent("CurrentTurf", "~y~-~w~ " + TurfWar.turf_war[tw].name + " ~y~-~w~~n~~y~Gebiet:~w~ " + FactionManage.faction_data[TurfWar.turf_war[tw].ownerid].faction_name + "");

                                player.SetData("LastTurfID", tw);
                                if (TurfWar.turf_war[tw].active_war == 0 && TurfWar.turf_war[tw].vulnerable == 0 && TurfWar.turf_war[tw].ownerid != AccountManage.GetPlayerGroup(player) && !player.IsInVehicle && FactionManage.GetPlayerGroupType(player) == 4 && player.GetSharedData("Injured") == 0)
                                {
                                    int count = TurfWar.GetPlayersInTurf(tw, iGroupID);
                                    if (count >= TurfWar.TURF_NEED_PLAYERS_START)
                                    {
                                        TurfWar.turf_war[tw].time_left_start--;
                                        Main.DisplaySubtitle(player, "ANFANG KRIEG IN: " + TurfWar.turf_war[tw].time_left_start);
                                        if (TurfWar.turf_war[tw].time_left_start < 1) TurfWar.TakeoverTurfWarsZone(iGroupID, tw);
                                    }
                                    else
                                    {
                                        // reset data
                                    }
                                }
                                else
                                {
                                    // reset data
                                }

                                if (TurfWar.turf_war[tw].active_war == 1 && (iGroupID == TurfWar.turf_war[tw].ownerid || iGroupID == TurfWar.turf_war[tw].attemptid) && !player.IsInVehicle)
                                {
                                    TimeSpan time = TimeSpan.FromSeconds(TurfWar.turf_war[tw].time_left);
                                    string time_left = time.ToString(@"mm\:ss");

                                    player.TriggerEvent("UpdateTurfScoreBoard", TurfWar.turf_war[tw].name, TurfWar.turf_war[tw].time_left, FactionManage.faction_data[TurfWar.turf_war[tw].attemptid].faction_name, TurfWar.turf_war[tw].attack_kills, TurfWar.turf_war[tw].attack_points, FactionManage.faction_data[TurfWar.turf_war[tw].ownerid].faction_name, TurfWar.turf_war[tw].defend_kills, TurfWar.turf_war[tw].defend_point);



                                }
                                else
                                {
                                    player.TriggerEvent("HideTurfScoreBoard");
                                }
                            }
                            else
                            {
                                player.TriggerEvent("CurrentTurf", "");
                                player.TriggerEvent("HideTurfScoreBoard");

                                int tw = player.GetData("player_in_turf");
                                var x = NAPI.Pools.GetAllPlayers();

                                if (NAPI.Data.HasEntityData(player, "LastTurfID"))
                                {
                                    if (player.GetData("LastTurfID") != -1)
                                    {
                                        int count = 0;
                                        foreach (var i in x)
                                        {
                                            if (i.GetData("status") == true)
                                            {
                                                if (AccountManage.GetPlayerGroup(i) == AccountManage.GetPlayerGroup(player) && !i.IsInVehicle)
                                                {
                                                    if (i.GetData("player_in_turf") == player.GetData("LastTurfID"))
                                                    {
                                                        count++;
                                                    }
                                                }
                                            }
                                        }
                                        if (count < TurfWar.TURF_NEED_PLAYERS_START) TurfWar.turf_war[player.GetData("LastTurfID")].time_left_start = 30;
                                    }
                                }

                                foreach (Client target in NAPI.Pools.GetAllPlayers())
                                {
                                    if (player.GetData("player_turf_blip_" + Main.getIdFromClient(target) + "") == true)
                                    {
                                        player.TriggerEvent("blip_remove", "player_turf_" + Main.getIdFromClient(target));
                                        player.SetData("player_turf_blip_" + Main.getIdFromClient(target) + "", false);
                                    }
                                }

                                player.SetData("LastTurfID", -1);
                            }
                        }

                        if (player.HasData("inVehicleInventory"))
                        {
                            if (player.GetData("inVehicleInventory") == true)
                            {
                                if (player.HasData("vehicle_handle_inv"))
                                {
                                    Vehicle vehicle = Utils.GetClosestVehicle(player, 3);

                                    if (vehicle != null)
                                    {



                                        try
                                        {
                                            if (player.IsInVehicle)
                                            {
                                                VehicleInventory.HidePlayerVehicleInventory(player);
                                            }
                                            else if (NAPI.Vehicle.GetVehicleHealth(vehicle) < 1)
                                            {
                                                VehicleInventory.HidePlayerVehicleInventory(player);
                                            }

                                            if (vehicle != player.GetData("vehicle_handle_inv"))
                                            {
                                                VehicleInventory.HidePlayerVehicleInventory(player);
                                            }
                                        }
                                        catch
                                        {

                                        }
                                    }
                                }
                                else
                                {
                                    VehicleInventory.HidePlayerVehicleInventory(player);
                                }
                            }
                        }
                        //
                        if (player.GetData("shipment") == true && !player.IsInVehicle)
                        {
                            player.TriggerEvent("blip_remove", "Trucker");
                        }

                        //
                        if (player.GetData("displayMessage_Timer") >= 0)
                        {

                            player.SetData("displayMessage_Timer", player.GetData("displayMessage_Timer") - 1);
                            if (player.GetData("displayMessage_Timer") == 0)
                            {
                                player.SetData("displayMessage_Timer", -1);
                                NAPI.Task.Run(() =>
                                {
                                    player.TriggerEvent("displayMessage", " ");
                                }, delayTime: 1000);
                            }
                        }
                        //taxi
                        if (player.IsInVehicle && player.Vehicle.HasData("TransportDuty"))
                        {
                            if (player.Vehicle.GetData("TransportDuty") == true)
                            {
                                player.Vehicle.SetData("TransportTime", player.Vehicle.GetData("TransportTime") + 1);

                                if (player.VehicleSeat != -1 && GetPlayerMoney(player) < (player.GetData("TaxiFee") + player.Vehicle.GetData("TransportPrice")))
                                {
                                    NAPI.Player.WarpPlayerOutOfVehicle(player);
                                    player.TriggerEvent("update_taxi_fare", false, 0, 0, false);
                                }

                                if (player.Vehicle.GetData("TransportTime") > 20 && player.IsInVehicle && player.VehicleSeat != -1)
                                {
                                    player.Vehicle.SetData("TransportTime", 0);

                                    if (Main.GetPlayerMoney(player) < (player.GetData("TaxiFee") + player.Vehicle.GetData("TransportPrice")))
                                    {
                                        player.WarpOutOfVehicle();
                                        player.TriggerEvent("update_taxi_fare", false, 0, 0, false);
                                    }

                                    // client
                                    player.SetData("TaxiFee", player.GetData("TaxiFee") + player.Vehicle.GetData("TransportPrice"));

                                    // taxista
                                    player.Vehicle.SetData("TransportFee", player.Vehicle.GetData("TransportFee") + player.Vehicle.GetData("TransportPrice"));

                                    player.TriggerEvent("createNewHeadNotificationAdvanced", "~w~Taxi-Tarif ~y~-$" + player.Vehicle.GetData("TransportPrice") + "");
                                }


                                if (player.IsInVehicle && player.VehicleSeat == -1)
                                {
                                    player.TriggerEvent("update_taxi_fare", true, player.Vehicle.GetData("TransportPrice"), player.Vehicle.GetData("TransportFee"), false);
                                }
                                else if (player.IsInVehicle) player.TriggerEvent("update_taxi_fare", true, player.Vehicle.GetData("TransportPrice"), player.GetData("TaxiFee"), true);
                            }

                        }

                        if (player.IsInVehicle)
                        {
                            //actual_position

                            player.TriggerEvent("vehicleFuel", Convert.ToInt32(GetVehicleFuel(player.Vehicle)));

                            if (player.Vehicle.Health == 1000)
                            {
                                player.TriggerEvent("vehicleDistance", "1000.00");
                            }
                            else player.TriggerEvent("vehicleDistance", player.Vehicle.Health.ToString("#.##").Replace(",", "."));
                        }

                        if (UsefullyRP.seatbelt[Main.getIdFromClient(player)] == true && !player.IsInVehicle)
                        {
                            UsefullyRP.seatbelt[Main.getIdFromClient(player)] = false;
                            player.ClearAccessory(0);
                            Main.UpdatePlayerClothes(player);
                        }
                    }

                    NAPI.World.SetTime(DateTime.Now.Hour, DateTime.Now.Minute, 0);
                    DayNightPrepareText(player);


                }
            }, 1000, 0);
        }
        catch (Exception e)
        {
            Log.Write("GlobalTime: " + e.Message, nLog.Type.Error);
        }
    }

    public static async void GlobalPlayerBannedTime(object sender, ElapsedEventArgs e) // 1 sec
    {
        try
        {
            var players = NAPI.Pools.GetAllPlayers();
            foreach (var player in players)
            {

                if (player.GetData("status") == true)
                {
                    using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
                    {
                        Mainpipeline.Open();
                        MySqlCommand query = new MySqlCommand("SELECT * FROM `users` WHERE `username` = '" + player.SocialClubName + "';", Mainpipeline);
                        using (MySqlDataReader reader = query.ExecuteReader())
                        {

                            string data2txt = string.Empty;
                            string datatxt = string.Empty;

                            while (reader.Read())
                            {
                                if (reader.GetInt32("banAces") == 0)
                                {
                                    player.TriggerEvent("Display_Banned_Screen");
                                    //player.TriggerEvent("Display_Banned_Screen");
                                    player.Kick();
                                    return;
                                }
                            }
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Log.Write($"{ex}");
        }
    }

    public static async void GlobalPlayerPayCheckTime(object sender, ElapsedEventArgs e) // 1 sec
    {
        try
        {
            Console.WriteLine($"GlobalPlayerPayCheckTime - Thread = {Thread.CurrentThread.ManagedThreadId}");
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var players = NAPI.Pools.GetAllPlayers();
            foreach (var player in players)
            {
                if (player.GetData("status") == true)
                {
                    if (player.GetData("duty") == 1)
                    {
                        if (FactionManage.GetPlayerGroupType(player) == FactionManage.FACTION_TYPE_POLICE || FactionManage.GetPlayerGroupType(player) == FactionManage.FACTION_TYPE_MEDIC)
                        {
                            NAPI.Notification.SendNotificationToPlayer(player, "  ~w~Gehalt: ~g~$~y~" + FactionManage.faction_data[AccountManage.GetPlayerGroup(player)].faction_salary[AccountManage.GetPlayerRank(player)].ToString("N0") + "");
                            GivePlayerMoneyBank(player, FactionManage.faction_data[AccountManage.GetPlayerGroup(player)].faction_salary[AccountManage.GetPlayerRank(player)]);
                        }
                    }

                    if (player.GetData("duty") == 1)
                    {
                        if (FactionManage.GetPlayerGroupType(player) == FactionManage.FACTION_TYPE_LSC)
                        {
                            NAPI.Notification.SendNotificationToPlayer(player, "  ~w~Gehalt: ~g~$~y~1791");
                            GivePlayerMoneyBank(player, 1791);
                        }
                    }

                    if (FactionManage.GetPlayerGroupType(player) == FactionManage.FACTION_TYPE_DOJ || FactionManage.GetPlayerGroupType(player) == FactionManage.FACTION_TYPE_LSPRESIDENT || FactionManage.GetPlayerGroupType(player) == FactionManage.FACTION_TYPE_LSSECRETSERVICE)
                    {
                        NAPI.Notification.SendNotificationToPlayer(player, "  ~w~Gehalt: ~g~$~y~" + FactionManage.faction_data[AccountManage.GetPlayerGroup(player)].faction_salary[AccountManage.GetPlayerRank(player)].ToString("N0") + "");
                        GivePlayerMoneyBank(player, FactionManage.faction_data[AccountManage.GetPlayerGroup(player)].faction_salary[AccountManage.GetPlayerRank(player)]);
                    }

                    if (FactionManage.GetPlayerGroupType(player) == FactionManage.FACTION_TYPE_ACLS)
                    {
                        if (player.GetData("duty") == 1)
                        {
                            NAPI.Notification.SendNotificationToPlayer(player, "  ~w~Gehalt: ~g~$~y~" + FactionManage.faction_data[AccountManage.GetPlayerGroup(player)].faction_salary[AccountManage.GetPlayerRank(player)].ToString("N0") + "");
                            GivePlayerMoneyBank(player, FactionManage.faction_data[AccountManage.GetPlayerGroup(player)].faction_salary[AccountManage.GetPlayerRank(player)]);
                        }
                    }

                    if (FactionManage.GetPlayerGroupType(player) == FactionManage.FACTION_TYPE_LSGOPOSTAL)
                    {
                        NAPI.Notification.SendNotificationToPlayer(player, "  ~w~Gehalt: ~g~$~y~5791");
                        GivePlayerMoneyBank(player, 5791);
                    }

                    if (FactionManage.GetPlayerGroupType(player) == FactionManage.FACTION_TYPE_NOOSETEAM)
                    {
                        if (player.GetData("duty") == 1)
                        {
                            NAPI.Notification.SendNotificationToPlayer(player, "  ~w~Gehalt: ~g~$~y~" + FactionManage.faction_data[AccountManage.GetPlayerGroup(player)].faction_salary[AccountManage.GetPlayerRank(player)].ToString("N0") + "");
                            GivePlayerMoneyBank(player, FactionManage.faction_data[AccountManage.GetPlayerGroup(player)].faction_salary[AccountManage.GetPlayerRank(player)]);
                        }
                    }

                    if (FactionManage.GetPlayerGroupType(player) == FactionManage.FACTION_TYPE_NONE || FactionManage.GetPlayerGroupType(player) == FactionManage.FACTION_TYPE_GANGUE)
                    {
                        if (player.GetData("character_job_center_status") == 1)
                        {
                            //hartzv = 449;
                            NAPI.Notification.SendNotificationToPlayer(player, "  ~w~Hartz V: ~g~$~y~449");
                            GivePlayerMoneyBank(player, 449);

                            //krankenkasse = 145;
                            NAPI.Notification.SendNotificationToPlayer(player, "  ~w~Krankenkasse: ~g~$~y~145");
                            GivePlayerMoneyBank(player, -145);
                        }
                    }

                    //kfzversicherung = 93 * PlayerVehicle.GetPlayerVehicleCount(player);
                    NAPI.Notification.SendNotificationToPlayer(player, "  ~w~KFZ-Versicherung: ~g~$~y~" + 93 * PlayerVehicle.GetPlayerVehicleCount(player) + "");
                    GivePlayerMoneyBank(player, -93 * PlayerVehicle.GetPlayerVehicleCount(player));

                    Main.GivePlayerEXP(player, player.GetData("character_level") * Economy.XP_RATE * Economy.XP_RATE_HOURLY);

                    AccountManage.SaveCharacter(player);
                }
            }
            stopwatch.Stop();
            Console.WriteLine($"GlobalPlayerPayCheckTime: Player Foreach benötigte: {stopwatch.Elapsed}");
        }
        catch (Exception ex)
        {
            Log.Write($"{ex}");
        }
    }

    public void UpdateTime() // 15 Sec time
    {
        try
        {
            TimerEx.SetTimer(() =>
            {
                DoorLock.SetDoorState(749848321, new Vector3(453.0793, -983.1894, 30.83926), NAPI.Data.GetWorldData("v_ilev_arm_secdoor"), 0); // lspd_locker_room
                DoorLock.SetDoorState(1557126584, new Vector3(449.6888, -986.5193, 30.6896), NAPI.Data.GetWorldData("lspd_locker_room"), 0); // lspd_locker_room
                DoorLock.SetDoorState(185711165, new Vector3(444.2534, -989.4843, 30.6896), NAPI.Data.GetWorldData("main_to_cell"), 0); // main_to_cell_right
                DoorLock.SetDoorState(185711165, new Vector3(445.2322, -989.5842, 30.68959), NAPI.Data.GetWorldData("main_to_cell"), 0); // main_to_cell_left
                DoorLock.SetDoorState(-1320876379, new Vector3(447.1939, -979.9949, 30.68959), NAPI.Data.GetWorldData("lspd_captain_room"), 0); // lspd_captain_room
                DoorLock.SetDoorState(-1033001619, new Vector3(463.9265, -1003.572, 24.91487), NAPI.Data.GetWorldData("lspd_exit_cell"), 0); // lspd_exit_cell
                DoorLock.SetDoorState(-2023754432, new Vector3(468.0155, -1014.855, 26.38639), NAPI.Data.GetWorldData("lspd_to_garage"), 0); // lspd_to_garage
                DoorLock.SetDoorState(-2023754432, new Vector3(469.3621, -1014.649, 26.3864), NAPI.Data.GetWorldData("lspd_to_garage"), 0);
                DoorLock.SetDoorState(631614199, new Vector3(464.5701, -992.6641, 25.06443), NAPI.Data.GetWorldData("lspd_enter_cell_door"), 0); //lspd_enter_cell_door
                DoorLock.SetDoorState(631614199, new Vector3(461.8065, -994.4086, 25.06443), NAPI.Data.GetWorldData("lspd_cell_door_1"), 0); //lspd_cell_door_1
                DoorLock.SetDoorState(631614199, new Vector3(461.8065, -997.6583, 25.06443), NAPI.Data.GetWorldData("lspd_cell_door_2"), 0); //lspd_cell_door_2
                DoorLock.SetDoorState(631614199, new Vector3(461.8065, -1001.302, 25.06443), NAPI.Data.GetWorldData("lspd_cell_door_3"), 0); //lspd_cell_door_3
                DoorLock.SetDoorState(-340230128, new Vector3(464.3613, -984.678, 43.83443), NAPI.Data.GetWorldData("lspd_roof"), 0); //lspd_roof

                if (DateTime.Now.Hour >= 0 && DateTime.Now.Hour <= 23 && DateTime.Now.Minute == 0 && PAYDAY_READY == false)
                {
                    PAYDAY_READY = true;

                    foreach (var player in NAPI.Pools.GetAllPlayers())
                    {
                        if (player.GetData("status") == true)
                        {
                            if (player.GetData("duty") == 1)
                            {
                                if (FactionManage.GetPlayerGroupType(player) == FactionManage.FACTION_TYPE_POLICE || FactionManage.GetPlayerGroupType(player) == FactionManage.FACTION_TYPE_MEDIC)
                                {
                                    NAPI.Notification.SendNotificationToPlayer(player, "  ~w~Gehalt: ~g~$~y~" + FactionManage.faction_data[AccountManage.GetPlayerGroup(player)].faction_salary[AccountManage.GetPlayerRank(player)].ToString("N0") + "");
                                    GivePlayerMoneyBank(player, FactionManage.faction_data[AccountManage.GetPlayerGroup(player)].faction_salary[AccountManage.GetPlayerRank(player)]);
                                }
                            }

                            if (player.GetData("duty") == 1)
                            {
                                if (FactionManage.GetPlayerGroupType(player) == FactionManage.FACTION_TYPE_LSC)
                                {
                                    NAPI.Notification.SendNotificationToPlayer(player, "  ~w~Gehalt: ~g~$~y~1791");
                                    GivePlayerMoneyBank(player, 1791);
                                }
                            }

                            if (FactionManage.GetPlayerGroupType(player) == FactionManage.FACTION_TYPE_DOJ || FactionManage.GetPlayerGroupType(player) == FactionManage.FACTION_TYPE_LSPRESIDENT || FactionManage.GetPlayerGroupType(player) == FactionManage.FACTION_TYPE_ACLS || FactionManage.GetPlayerGroupType(player) == FactionManage.FACTION_TYPE_LSSECRETSERVICE)
                            {
                                NAPI.Notification.SendNotificationToPlayer(player, "  ~w~Gehalt: ~g~$~y~" + FactionManage.faction_data[AccountManage.GetPlayerGroup(player)].faction_salary[AccountManage.GetPlayerRank(player)].ToString("N0") + "");
                                GivePlayerMoneyBank(player, FactionManage.faction_data[AccountManage.GetPlayerGroup(player)].faction_salary[AccountManage.GetPlayerRank(player)]);
                            }

                            if (FactionManage.GetPlayerGroupType(player) == FactionManage.FACTION_TYPE_ACLS)
                            {
                                if (player.GetData("duty") == 1)
                                {
                                    NAPI.Notification.SendNotificationToPlayer(player, "  ~w~Gehalt: ~g~$~y~" + FactionManage.faction_data[AccountManage.GetPlayerGroup(player)].faction_salary[AccountManage.GetPlayerRank(player)].ToString("N0") + "");
                                    GivePlayerMoneyBank(player, FactionManage.faction_data[AccountManage.GetPlayerGroup(player)].faction_salary[AccountManage.GetPlayerRank(player)]);
                                }
                            }

                            if (FactionManage.GetPlayerGroupType(player) == FactionManage.FACTION_TYPE_LSGOPOSTAL)
                            {
                                NAPI.Notification.SendNotificationToPlayer(player, "  ~w~Gehalt: ~g~$~y~5791");
                                GivePlayerMoneyBank(player, 5791);
                            }

                            if (FactionManage.GetPlayerGroupType(player) == FactionManage.FACTION_TYPE_NOOSETEAM)
                            {
                                if (player.GetData("duty") == 1)
                                {
                                    NAPI.Notification.SendNotificationToPlayer(player, "  ~w~Gehalt: ~g~$~y~" + FactionManage.faction_data[AccountManage.GetPlayerGroup(player)].faction_salary[AccountManage.GetPlayerRank(player)].ToString("N0") + "");
                                    GivePlayerMoneyBank(player, FactionManage.faction_data[AccountManage.GetPlayerGroup(player)].faction_salary[AccountManage.GetPlayerRank(player)]);
                                }
                            }

                            if (FactionManage.GetPlayerGroupType(player) == FactionManage.FACTION_TYPE_NONE || FactionManage.GetPlayerGroupType(player) == FactionManage.FACTION_TYPE_GANGUE)
                            {
                                if (player.GetData("character_job_center_status") == 1)
                                {
                                    hartzv = 499;
                                    NAPI.Notification.SendNotificationToPlayer(player, "  ~w~Hartz V: ~g~$~y~" + hartzv + "");
                                    GivePlayerMoneyBank(player, hartzv);

                                    krankenkasse = 145;
                                    NAPI.Notification.SendNotificationToPlayer(player, "  ~w~Krankenkasse: ~g~$~y~" + krankenkasse + "");
                                    GivePlayerMoneyBank(player, -krankenkasse);
                                }
                            }

                            kfzversicherung = 93 * PlayerVehicle.GetPlayerVehicleCount(player);
                            NAPI.Notification.SendNotificationToPlayer(player, "  ~w~KFZ-Versicherung: ~g~$~y~" + kfzversicherung + "");
                            GivePlayerMoneyBank(player, -kfzversicherung);

                            Main.GivePlayerEXP(player, player.GetData("character_level") * Economy.XP_RATE * Economy.XP_RATE_HOURLY);

                            AccountManage.SaveCharacter(player);
                        }
                    }

                    //LottoSystem.PrepareLotto();

                    NAPI.Task.Run(() =>
                    {
                        PAYDAY_READY = false;
                    }, delayTime: 62000);
                }


                foreach (var veh in NAPI.Pools.GetAllVehicles())
                {
                    if (NAPI.Vehicle.GetVehicleEngineStatus(veh) == true)
                    {
                        SetVehicleFuel(veh, GetVehicleFuel(veh) - 0.3);
                        if (GetVehicleFuel(veh) <= 2.0)
                        {
                            SetVehicleFuel(veh, 0.0);
                            NAPI.Vehicle.SetVehicleEngineStatus(veh, false);
                        }
                    }

                    foreach (var ls in LSCustom.ls_custom)
                    {
                        if (ls.in_use == true && ls.vehicle == veh)
                        {
                            if (API.Shared.GetVehicleDriver(veh) == null || !Main.IsInRangeOfPoint(veh.Position, ls.position, 5.0f))
                            {
                                LSCustom.ResetVehicle_Customization_Temp(veh);
                                ls.in_use = false;
                                ls.vehicle = null;
                                ls.label_position.Text = Translation.ls_custom_label_free;
                                veh.ResetData("lscustom_use");
                            }
                        }
                    }
                }
            }, 7000, 0);
        }
        catch (Exception e)
        {
            Log.Write("UpdateTime: " + e.Message, nLog.Type.Error);
        }
    }

    public void SyncTime()
    {
        try
        {
            TimerEx.SetTimer(() =>
            {

                var players = NAPI.Pools.GetAllPlayers();
                foreach (var player in players)
                {
                    if (player.GetData("status") == true)
                    {
                        if (player.IsInVehicle && NAPI.Vehicle.GetVehicleEngineStatus(player.Vehicle) == false)
                        {
                            NAPI.Vehicle.SetVehicleEngineStatus(player.Vehicle, false);
                        }

                    }
                }
            }, 50, 0);
        }
        catch (Exception e)
        {
            Log.Write("SyncTime: " + e.Message, nLog.Type.Error);
        }
    }

    public void OneHour()
    {
        try
        {
            TimerEx.SetTimer(() =>
            {
                int index = 0, count = 0;
                foreach (var business in Business.business_list)
                {
                    if (Business.business_list[index].business_OrderState == 0 && Business.business_list[index].business_restock_manage_x != 0 && Business.business_list[index].business_restock_manage_y != 0 && (Business.business_list[index].business_Type == 1 || Business.business_list[index].business_Type == 2 || Business.business_list[index].business_Type == 3 || Business.business_list[index].business_Type == 5 || Business.business_list[index].business_Type == 11 || Business.business_list[index].business_Type == 12 || Business.business_list[index].business_Type == 13))
                    {
                        Business.business_list[index].business_OrderState = 1;
                        Business.business_list[index].business_OrderAmount = Business.business_list[index].business_InventoryCapacity;
                        count++;
                    }
                    index++;
                }

            }, 3600000, 0);
        }
        catch (Exception e)
        {
            Log.Write("OneHour: " + e.Message, nLog.Type.Error);
        }
    }

    public void UpdateVehicle() // 15 Sec time
    {
        TimerEx.SetTimer(() =>
        {
            if (DateTime.Now.Hour >= 0 && DateTime.Now.Hour <= 23 && DateTime.Now.Minute == 0 && PAYDAY_READY == false)
            {
                PAYDAY_READY = true;

                foreach (var player in NAPI.Pools.GetAllPlayers())
                {
                    if (player.GetData("status") == true)
                    {
                        bool engineOn = NAPI.Vehicle.GetVehicleEngineStatus(player.Vehicle);

                        if (player.IsInVehicle && engineOn == false)
                        {
                            engineOn = player.Vehicle.EngineStatus = false;
                            PlayerVehicle.AUTO_SAVE_Vehicle(player);
                        }
                    }
                }

                NAPI.Task.Run(() =>
                {
                    PAYDAY_READY = false;
                }, delayTime: 1000);
            }
        }, 7000, 0);
    }

    public static async void BusinessTime(object sender, ElapsedEventArgs e) // 15 Sec time
    {
        try
        {
            Console.WriteLine($"BusinessTime - Thread = {Thread.CurrentThread.ManagedThreadId}");
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            int index = 0, count = 0;
            foreach (var business in Business.business_list)
            {
                if (Business.business_list[index].business_OrderState == 0 && Business.business_list[index].business_restock_manage_x != 0 && Business.business_list[index].business_restock_manage_y != 0 && (Business.business_list[index].business_Type == 1 || Business.business_list[index].business_Type == 2 || Business.business_list[index].business_Type == 3 || Business.business_list[index].business_Type == 5 || Business.business_list[index].business_Type == 11 || Business.business_list[index].business_Type == 12 || Business.business_list[index].business_Type == 13))
                {
                    Business.business_list[index].business_OrderState = 1;
                    Business.business_list[index].business_OrderAmount = Business.business_list[index].business_InventoryCapacity;
                    count++;
                }
                index++;
            }

            stopwatch.Stop();
            Console.WriteLine($"BusinessTime: Player Foreach benötigte: {stopwatch.Elapsed}");
        }
        catch (Exception ex)
        {
            Log.Write($"{ex}");
        }
    }

    public static void DayNightPrepareText(Client player)
    {
        int hour = DateTime.Now.Hour;
        int minute = DateTime.Now.Minute;

        switch (hour)
        {
            //AM
            case 1: hour = 01; break;
            case 2: hour = 02; break;
            case 3: hour = 03; break;
            case 4: hour = 04; break;
            case 5: hour = 05; break;
            case 6: hour = 06; break;
            case 7: hour = 07; break;
            case 8: hour = 08; break;
            case 9: hour = 09; break;
            case 0: hour = 00; break;
        }

        switch (minute)
        {
            //AM
            case 1: minute = 01; break;
            case 2: minute = 02; break;
            case 3: minute = 03; break;
            case 4: minute = 04; break;
            case 5: minute = 05; break;
            case 6: minute = 06; break;
            case 7: minute = 07; break;
            case 8: minute = 08; break;
            case 9: minute = 09; break;
            case 0: minute = 00; break;
        }

        player.TriggerEvent("TimeOfDay", "" + hour + ":" + minute + "");
    }

    public static int GetPlayerMoney(Client player)
    {
        return Convert.ToInt32(NAPI.Data.GetEntityData(player, "character_money"));
    }

    public static int GetPlayerBank(Client player)
    {
        return Convert.ToInt32(NAPI.Data.GetEntityData(player, "character_bank"));
    }

    public static void GivePlayerMoney(Client player, int value)
    {
        NAPI.Data.SetEntityData(player, "character_money", (Convert.ToInt32(NAPI.Data.GetEntityData(player, "character_money")) + value));
        UpdateMoneyDisplay(player);
        AccountManage.SaveCharacter(player);
    }

    public static void GivePlayerMoneyBank(Client player, int value)
    {
        NAPI.Data.SetEntityData(player, "character_bank", (Convert.ToInt32(NAPI.Data.GetEntityData(player, "character_bank") + value)));
        UpdateMoneyDisplay(player);
        AccountManage.SaveCharacter(player);
    }

    public static void SetPlayerMoney(Client player, int value)
    {
        NAPI.Data.SetEntityData(player, "character_money", value);
        UpdateMoneyDisplay(player);
        AccountManage.SaveCharacter(player);
    }

    public static void SetPlayerMoneyBank(Client player, int value)
    {
        NAPI.Data.SetEntityData(player, "character_bank", value);
        UpdateMoneyDisplay(player);
        AccountManage.SaveCharacter(player);
    }

    public static void UpdateMoneyDisplay(Client player)
    {
        if (NAPI.Data.GetEntityData(player, "character_money") < 0)
        {
            player.TriggerEvent("update_money_display", "" + NAPI.Data.GetEntityData(player, "character_money"), NAPI.Data.GetEntityData(player, "character_bank"));
        }
        else player.TriggerEvent("update_money_display", NAPI.Data.GetEntityData(player, "character_money"), NAPI.Data.GetEntityData(player, "character_bank"));
    }

    public static void EmoteMessage(Client player, string message)
    {
        int playerid = getIdFromClient(player);

        if (emote_timer[playerid] != null)
        {
            emote_timer[playerid].Kill();
            emote_timer[playerid] = null;

        }
        player.SetSharedData("emoteTimeout", 7);
        player.SetSharedData("emoteText", message);
        emote_timer[playerid] = TimerEx.SetTimer(() =>
        {

            player.SetSharedData("emoteTimeout", player.GetSharedData("emoteTimeout") - 1);

            if (player.GetSharedData("emoteTimeout") == 0)
            {
                player.SetSharedData("emoteText", "");
                try
                {
                    emote_timer[playerid].Kill();
                }
                catch
                {

                }
                emote_timer[playerid] = null;
            }

        }, 1000, 0);
    }

    public static void g_mysql_create_character(Client player, string character_name, string customization)
    {
        using (MySqlConnection Mainpipeline = new MySqlConnection(myConnectionString))
        {

            Mainpipeline.Open();
            MySqlCommand query = Mainpipeline.CreateCommand();
            query.CommandType = CommandType.Text;
            query.CommandText = "SELECT * FROM `characters` WHERE `name` = '" + character_name + "'";
            query.ExecuteNonQuery();
            DataTable dt = new DataTable();
            using (MySqlDataAdapter da = new MySqlDataAdapter(query))
            {
                da.Fill(dt);
                int i = 0;
                i = Convert.ToInt32(dt.Rows.Count.ToString());
                if (i == 0)
                {
                    player.SetData("firstJoinned", true);

                    string character_query = "INSERT INTO `characters` (name, userid, money, bank, salary, CreateCharacter, LastLogin) VALUES (@name, @sqlid, 0, 0, 0, @timenow, @LastLogin);";

                    MySqlCommand CreatNewAccount = new MySqlCommand(character_query, Mainpipeline);

                    CreatNewAccount.Parameters.AddWithValue("@name", "" + character_name + "");
                    CreatNewAccount.Parameters.AddWithValue("@sqlid", NAPI.Data.GetEntityData(player, "player_sqlid"));
                    CreatNewAccount.Parameters.AddWithValue("@timenow", DateTime.Now);
                    CreatNewAccount.Parameters.AddWithValue("@LastLogin", DateTime.Now);

                    CreatNewAccount.ExecuteNonQuery();

                    long last_insert_id = CreatNewAccount.LastInsertedId;
                    player.SetData("character_sqlid", last_insert_id);

                    Main.CreateMySqlCommand("UPDATE `characters` SET `char` = '" + customization + "' WHERE name = '" + character_name + "';");

                    NAPI.Task.Run(() =>
                    {
                        AccountManage.LoadCharacter(player, (int)last_insert_id);

                        if (player.GetData("creator_outfit") == 0)
                        {
                            if (player.GetSharedData("CHARACTER_ONLINE_GENRE") == 0)
                            {
                                player.SetClothes(3, 15, 0);
                                player.SetClothes(4, 21, 0);
                                player.SetClothes(6, 34, 0);
                                player.SetClothes(8, 15, 0);
                                player.SetClothes(11, 15, 0);

                                player.SetSharedData("character_torso", 15);
                                player.SetSharedData("character_leg", 21);
                                player.SetSharedData("character_leg_texture", 0);
                                player.SetSharedData("character_feet", 34);
                                player.SetSharedData("character_feet_texture", 0);
                                player.SetSharedData("character_undershirt", 15);
                                player.SetSharedData("character_undershirt_texture", 0);
                                player.SetSharedData("character_shirt", 11);
                                player.SetSharedData("character_shirt_texture", 0);

                            }
                            else
                            {
                                player.SetSharedData("character_torso", 15);
                                player.SetSharedData("character_leg", 10);
                                player.SetSharedData("character_leg_texture", 0);
                                player.SetSharedData("character_feet", 35);
                                player.SetSharedData("character_feet_texture", 0);
                                player.SetSharedData("character_undershirt", 15);
                                player.SetSharedData("character_undershirt_texture", 0);
                                player.SetSharedData("character_shirt", 15);
                                player.SetSharedData("character_shirt_texture", 0);

                                player.SetClothes(3, 15, 0);
                                player.SetClothes(4, 10, 0);
                                player.SetClothes(6, 35, 0);
                                player.SetClothes(8, 15, 0);
                                player.SetClothes(11, 15, 0);
                            }
                        }
                        else
                        {
                            //API.Util.ConsoleOutput("$$$$$$$$$$$$$%%%%%%%%%%% OUTFIT !!");
                            player.SetData("character_outfit", player.GetData("creator_outfit"));
                            Outfits.SetUnisexOutfit(player, player.GetData("creator_outfit"), true);
                            //API.Util.ConsoleOutput("$$$$$$$$$$$$$%%%%%%%%%%% OUTFIT !!");
                        }
                    }, delayTime: 300);
                }
                else
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "Mit dem Namen wurde bereits ein Account erstellt~y~" + character_name + "~w~, Verwenden Sie einen anderen Namen.");
                }
            }
        }


    }


    public static int g_mysql_get_characters_created(Client player)
    {
        int i = 0;
        using (MySqlConnection Mainpipeline = new MySqlConnection(myConnectionString))
        {

            Mainpipeline.Open();
            MySqlCommand query = Mainpipeline.CreateCommand();
            query.CommandType = CommandType.Text;
            query.CommandText = "SELECT * FROM `characters` WHERE `userid` = '" + NAPI.Data.GetEntityData(player, "player_sqlid") + "'";
            query.ExecuteNonQuery();

            DataTable dt = new DataTable();
            using (MySqlDataAdapter da = new MySqlDataAdapter(query))
            {
                da.Fill(dt);
                i = Convert.ToInt32(dt.Rows.Count.ToString());
            }
        }
        return i;
    }


    //
    // commands
    //


    [ServerEvent(Event.PlayerWeaponSwitch)]
    public void OnPlayerWeaponSwitch(Client player, WeaponHash oldWeapon, WeaponHash newWeapon)
    {
        /* if (player.GetData("status") == true)
         {
             for (int i = 0; i < WeaponManage.MAX_PLAYER_WEAPONS; i++)
             {
                 if (player.GetData("character_weapon_" + i + "_id") != -1)
                 {
                     if (player.CurrentWeapon == NAPI.Util.WeaponNameToModel(player.GetData("character_weapon_" + i + "_weapon")))
                     {
                         foreach (var w in weapon_list)
                         {
                             if (player.CurrentWeapon == NAPI.Util.WeaponNameToModel(w.model))
                             {
                                 switch (w.classe)
                                 {
                                     case "Handguns":
                                         if (player.GetData("character_ammo_handguns") != 1) player.SetWeaponAmmo(player.CurrentWeapon, player.GetData("character_ammo_handguns"));
                                         break;
                                     case "Machine Guns":
                                         if (player.GetData("character_ammo_machineguns") != 1) player.SetWeaponAmmo(player.CurrentWeapon, player.GetData("character_ammo_machineguns"));
                                         break;
                                     case "Assault Rifles":
                                         if (player.GetData("character_ammo_assaultrifles") != 1) player.SetWeaponAmmo(player.CurrentWeapon, player.GetData("character_ammo_assaultrifles"));
                                         break;
                                     case "Sniper Rifles":
                                         if (player.GetData("character_ammo_sniperrifles") != 1) player.SetWeaponAmmo(player.CurrentWeapon, player.GetData("character_ammo_sniperrifles"));
                                         break;
                                     case "Shotguns":
                                         if (player.GetData("character_ammo_shotguns") != 1) player.SetWeaponAmmo(player.CurrentWeapon, player.GetData("character_ammo_shotguns"));
                                         break;

                                 }
                             }
                         }
                     }
                 }
             }
         }*/
    }


    private void OnPlayerWeaponAmmoChangeHandler(Client player, WeaponHash weapon, int oldAmmo)
    {
        /* foreach (var w in weapon_list)
         {
             if (weapon == NAPI.Util.WeaponNameToModel(w.model))
             {
                 switch (w.classe)
                 {
                     case "Handguns":
                         player.SetData("character_ammo_handguns", player.GetWeaponAmmo(weapon));
                         break;
                     case "Machine Guns":
                         player.SetData("character_ammo_machineguns", player.GetWeaponAmmo(weapon));
                         break;
                     case "Assault Rifles":
                         player.SetData("character_ammo_assaultrifles", player.GetWeaponAmmo(weapon));
                         break;
                     case "Sniper Rifles":
                         player.SetData("character_ammo_sniperrifles", player.GetWeaponAmmo(weapon));
                         break;
                     case "Shotguns":
                         player.SetData("character_ammo_shotguns", player.GetWeaponAmmo(weapon));
                         break;
                 }
             }
         }*/
    }

    [Command("camera")]
    public void fasfas(Client player, int type = 0, float x = 412.7418f, float y = -824.6332f, float z = 29.330f, int az = 90)
    {
        Vector3 playerPosGet = NAPI.Entity.GetEntityPosition(player);
        var pPosX = (playerPosGet.X.ToString().Replace(',', '.') + ", ");
        var pPosY = (playerPosGet.Y.ToString().Replace(',', '.') + ", ");
        var pPosZ = (playerPosGet.Z.ToString().Replace(',', '.'));
        Vector3 playerRotGet = NAPI.Entity.GetEntityRotation(player);
        var pRotX = (playerRotGet.X.ToString().Replace(',', '.') + ", ");
        var pRotY = (playerRotGet.Y.ToString().Replace(',', '.') + ", ");
        var pRotZ = (playerRotGet.Z.ToString().Replace(',', '.'));

        Main.SendInfoMessage2(player, "~c~Your camera position is: ~b~" + playerPosGet, "~w~Your rotation is: ~b~" + playerRotGet);

        Vector3 position = new Vector3(x, y, z);
        //player.TriggerEvent("DisplayCustomCamera", position, az);
        player.TriggerEvent("DisplayCustomCamera", new Vector3(371.8996, -588.7899, 28.87547 + 2.0), new Vector3(0, 0, 28.83585));
    }

    [Command("destr")]
    public void fasfs(Client player)
    {
        player.TriggerEvent("DestroyCustomCamera");
    }

    [Command("save")]
    public void coords(Client player, string coordName)
    {
        if (AccountManage.GetPlayerAdmin(player) < 1)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben keine Berechtigung, diesen Befehl zu verwenden.");
            return;
        }
        Vector3 playerPosGet = NAPI.Entity.GetEntityPosition(player);
        var pPosX = (playerPosGet.X.ToString().Replace(',', '.') + ", ");
        var pPosY = (playerPosGet.Y.ToString().Replace(',', '.') + ", ");
        var pPosZ = (playerPosGet.Z.ToString().Replace(',', '.'));
        Vector3 playerRotGet = NAPI.Entity.GetEntityRotation(player);
        var pRotX = (playerRotGet.X.ToString().Replace(',', '.') + ", ");
        var pRotY = (playerRotGet.Y.ToString().Replace(',', '.') + ", ");
        var pRotZ = (playerRotGet.Z.ToString().Replace(',', '.'));

        Main.SendInfoMessage2(player, "Your position is: ~y~" + playerPosGet, "~w~Your rotation is: ~y~" + playerRotGet);
        StreamWriter coordsFile;
        if (!File.Exists("SavedCoords.txt"))
        {
            coordsFile = new StreamWriter("SavedCoords.txt");
        }
        else
        {
            coordsFile = File.AppendText("SavedCoords.txt");
        }
        NAPI.Notification.SendNotificationToPlayer(player, "Koordinaten wurden gespeichert!");
        coordsFile.WriteLine("| " + coordName + " | " + "Saved Coordenates: " + pPosX + pPosY + pPosZ + " Saved Rotation: " + pRotX + pRotY + pRotZ);
        coordsFile.Close();
    }

    public static void ShowPlayerStats(Client player, Client target)
    {
        int new_level = (50 * (player.GetData("character_level")) * (player.GetData("character_level")) * (player.GetData("character_level")) - 150 * (player.GetData("character_level")) * (player.GetData("character_level")) + 600 * (player.GetData("character_level"))) / 5;

        NAPI.Notification.SendNotificationToPlayer(target, "~y~ ~w~Bürger Statistiken - ~g~" + AccountManage.GetCharacterName(player) + "~w~.");
        NAPI.Notification.SendNotificationToPlayer(target, "~g~Charakter~w~  |  ~w~Geld: ~g~$" + GetPlayerMoney(player).ToString("N0") + "~w~ | Bank: ~g~$" + GetPlayerBank(player).ToString("N0") + "");
        if (AccountManage.GetPlayerGroup(player) != 0) NAPI.Notification.SendNotificationToPlayer(target, "~g~Fraktion~w~  |  ~w~Name: ~b~" + FactionManage.faction_data[AccountManage.GetPlayerGroup(player)].faction_name + "~w~ | Position: ~b~" + FactionManage.faction_data[AccountManage.GetPlayerGroup(player)].faction_rank[AccountManage.GetPlayerRank(player)] + "");
        if (player.GetData("character_business_key") != -1)
        {
            int business = player.GetData("character_business_key");
            NAPI.Notification.SendNotificationToPlayer(target, "~g~Firma~w~  |  Firmenname: ~b~" + Business.business_list[business].business_Name + " (" + business + ")~w~ | Typ: ~b~" + Business.Business_Type(Business.business_list[business].business_Type) + "");
        }
        NAPI.Notification.SendNotificationToPlayer(target, "~g~Erfahrung~w~  |  Level aktuell: ~y~" + player.GetData("character_level") + "~w~  |  Erfahrung aktuell: ~y~" + player.GetData("character_exp") + "/" + new_level + "");
        NAPI.Notification.SendNotificationToPlayer(target, "~g~Fahrezeuge~w~  |  Ich besitze~y~" + PlayerVehicle.GetPlayerVehicleCount(player) + "~w~ Fahrezeuge");
    }

    public static void UpdatePlayerClothes(Client player)
    {
        if (player.GetData("duty") == 1 && player.GetData("character_duty_outfit") != -1)
        {
            Outfits.SetUnisexOutfit(player, player.GetData("character_duty_outfit"));
            return;
        }
        var mask = (int)NAPI.Data.GetEntitySharedData(player, "character_mask");
        var mask_texture = (int)NAPI.Data.GetEntitySharedData(player, "character_mask_texture");
        var torso = (int)NAPI.Data.GetEntitySharedData(player, "character_torso");
        var torso_texture = (int)NAPI.Data.GetEntitySharedData(player, "character_torso_texture");
        var undershirt = (int)NAPI.Data.GetEntitySharedData(player, "character_undershirt");
        var undershirt_texture = (int)NAPI.Data.GetEntitySharedData(player, "character_undershirt_texture");
        var leg = (int)NAPI.Data.GetEntitySharedData(player, "character_leg");
        var leg_texture = (int)NAPI.Data.GetEntitySharedData(player, "character_leg_texture");
        var feet = (int)NAPI.Data.GetEntitySharedData(player, "character_feet");
        var feet_texture = (int)NAPI.Data.GetEntitySharedData(player, "character_feet_texture");
        var shirt = (int)NAPI.Data.GetEntitySharedData(player, "character_shirt");
        var shirt_texture = (int)NAPI.Data.GetEntitySharedData(player, "character_shirt_texture");
        var armor = (int)NAPI.Data.GetEntitySharedData(player, "character_armor");
        var armor_texture = (int)NAPI.Data.GetEntitySharedData(player, "character_armor_texture");

        var ears = (int)NAPI.Data.GetEntitySharedData(player, "character_ears");
        var ears_texture = (int)NAPI.Data.GetEntitySharedData(player, "character_ears_texture");
        var watches = (int)NAPI.Data.GetEntitySharedData(player, "character_watches");
        var watches_texture = (int)NAPI.Data.GetEntitySharedData(player, "character_watches_texture");
        var bracelets = (int)NAPI.Data.GetEntitySharedData(player, "character_bracelets");
        var bracelets_texture = (int)NAPI.Data.GetEntitySharedData(player, "character_bracelets_texutre");

        var glasses = (int)NAPI.Data.GetEntitySharedData(player, "character_glasses");
        var glasses_texture = (int)NAPI.Data.GetEntitySharedData(player, "character_glasses_texture");
        var hats = (int)NAPI.Data.GetEntitySharedData(player, "character_hats");
        var hats_texture = (int)NAPI.Data.GetEntitySharedData(player, "character_hats_texture");
        var accessories = NAPI.Data.GetEntitySharedData(player, "character_accessories");
        var accessories_texture = NAPI.Data.GetEntitySharedData(player, "character_accessories_texture");
        //player.SetData("hats_enable", false);
        //player.SetData("glasses_enable", false);
        //player.SetData("shirt_enable", false);
        //player.SetData("watches_enable", false);
        //player.SetData("ears_enable", false);
        //player.SetData("backpack_enable", false);
        //player.SetData("primaryweapon_enable", false);
        //player.SetData("fpsync.update", false);
        player.SetAccessories(0, 0, 0);
        player.SetAccessories(1, 0, 0);
        player.ClearAccessory(0);
        player.ClearAccessory(1);
        player.ClearAccessory(2);
        player.ClearAccessory(6);
        player.ClearAccessory(7);

        if (player.GetData("clothes_ears") == false)
        {
            player.ClearAccessory(2);
        }
        else
        {
            if (ears != 0) player.SetAccessories(2, (int)NAPI.Data.GetEntitySharedData(player, "character_ears"), (int)NAPI.Data.GetEntitySharedData(player, "character_ears_texture"));
        }

        if (player.GetData("clothes_watches") == false)
        {
            player.ClearAccessory(6);
        }
        else
        {
            if (watches != 0) player.SetAccessories(6, (int)NAPI.Data.GetEntitySharedData(player, "character_watches"), (int)NAPI.Data.GetEntitySharedData(player, "character_watches_texture"));
        }


        if (player.GetData("clothes_glasses") == false)
        {
            player.ClearAccessory(1);
        }
        else
        {
            player.SetAccessories(1, glasses, glasses_texture);
        }

        if (player.GetData("clothes_hats") == false)
        {
            player.ClearAccessory(0);
        }
        else
        {
            player.SetAccessories(0, (int)NAPI.Data.GetEntitySharedData(player, "character_hats"), (int)NAPI.Data.GetEntitySharedData(player, "character_hats_texture"));
        }

        if (player.GetData("clothes_neck") == false)
        {
            NAPI.Player.SetPlayerClothes(player, 7, 0, 0);
        }
        else
        {
            NAPI.Player.SetPlayerClothes(player, 11, (int)accessories, (int)accessories_texture);
        }

        if (CharCreator.CharCreator.CustomPlayerData[player.Handle].Gender == 0)
        {
            if (player.GetData("clothes_shirt") == false)
            {
                NAPI.Player.SetPlayerClothes(player, 3, 15, 0);
                NAPI.Player.SetPlayerClothes(player, 11, 0, 20);
                NAPI.Player.SetPlayerClothes(player, 8, 0, 35);
            }
            else
            {
                NAPI.Player.SetPlayerClothes(player, 3, torso, torso_texture);
                NAPI.Player.SetPlayerClothes(player, 11, shirt, shirt_texture);
                NAPI.Player.SetPlayerClothes(player, 8, undershirt, undershirt_texture);
            }


            if (player.GetData("clothes_leg") == false)
            {
                NAPI.Player.SetPlayerClothes(player, 4, 21, 0);
            }
            else
            {
                NAPI.Player.SetPlayerClothes(player, 4, leg, leg_texture);
            }

            if (player.GetData("clothes_feet") == false)
            {
                NAPI.Player.SetPlayerClothes(player, 6, 16, 0);
            }
            else
            {
                NAPI.Player.SetPlayerClothes(player, 6, feet, feet_texture);
            }
        }
        else
        {
            if (player.GetData("clothes_shirt") == false)
            {
                NAPI.Player.SetPlayerClothes(player, 3, 15, 0);
                NAPI.Player.SetPlayerClothes(player, 11, 0, 20);
                NAPI.Player.SetPlayerClothes(player, 8, 0, 35);
            }
            else
            {
                NAPI.Player.SetPlayerClothes(player, 3, torso, torso_texture);
                NAPI.Player.SetPlayerClothes(player, 11, shirt, shirt_texture);
                NAPI.Player.SetPlayerClothes(player, 8, undershirt, undershirt_texture);
            }




            if (player.GetData("clothes_leg") == false)
            {
                NAPI.Player.SetPlayerClothes(player, 4, 56, 0);
            }
            else
            {
                NAPI.Player.SetPlayerClothes(player, 4, leg, leg_texture);
            }

            if (player.GetData("clothes_feet") == false)
            {
                NAPI.Player.SetPlayerClothes(player, 6, 5, 0);
            }
            else
            {
                NAPI.Player.SetPlayerClothes(player, 6, feet, feet_texture);
            }
        }

        var players = NAPI.Pools.GetAllPlayers();
        foreach (var target in players)
        {
            target.SetDecoration(new Decoration { Collection = NAPI.Util.GetHashKey((string)NAPI.Data.GetEntitySharedData(target, "character_tattoo_collection")), Overlay = NAPI.Util.GetHashKey((string)NAPI.Data.GetEntitySharedData(target, "character_tattoo_overlay")) });
        }

        player.SetDecoration(new Decoration { Collection = NAPI.Util.GetHashKey((string)NAPI.Data.GetEntitySharedData(player, "character_tattoo_collection")), Overlay = NAPI.Util.GetHashKey((string)NAPI.Data.GetEntitySharedData(player, "character_tattoo_overlay")) });


        if (UsefullyRP.mask[Main.getIdFromClient(player)] == false)
        {

            NAPI.Player.SetPlayerClothes(player, 1, 0, 0);
        }
        else
        {
            var temp_mask = NAPI.Data.GetEntitySharedData(player, "character_mask");
            var temp_mask_texture = NAPI.Data.GetEntitySharedData(player, "character_mask_texture");
            NAPI.Player.SetPlayerClothes(player, 1, (int)temp_mask, (int)temp_mask_texture);
        }
    }


    public static void SendNotificationBrowser(Client player, string title, string message, string colourf = "danger", string position = "top", string alig = "right")
    {
        player.TriggerEvent("SendUINotification", title, message, colourf, position, alig);
    }

    public static void DisplayErrorMessage(Client player, string message)
    {
        DisplaySubtitle(player, "ERROR:~s~ " + message);
    }

    public static void SendJobMessage(int jobid, string msg)
    {
        var players = NAPI.Pools.GetAllPlayers();
        foreach (var player in players)
        {
            if (player.GetData("status") == true)
            {
                if (AccountManage.GetPlayerJob(player) == jobid)
                {
                    NAPI.Notification.SendNotificationToPlayer(player, msg);
                }
            }
        }
    }

    public static void sendProxMessage(Client player, float radius, string color, string msg)
    {
        List<Client> proxPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(radius, player);
        foreach (Client target in proxPlayers)
        {
            target.SendChatMessage("<font color ='#" + color + "'>" + msg);
        }
        NAPI.Notification.SendNotificationToPlayer(player, "" + msg + "");
    }

    public static void Admin_Message(string color, string msg)
    {
        var players = NAPI.Pools.GetAllPlayers();
        foreach (var player in players)
        {
            if (player.GetData("status") == true && AccountManage.GetPlayerAdmin(player) > 0)
            {
                Main.SendInfoMessage2(player, color, msg);
            }
        }
    }
    public static bool IsPlayerLogged(Client player)
    {
        return player.GetData("status");
    }

    public static void CreateProgressBar(Client player, string name, float value, float size)
    {
        player.SetData("progressBar_value", value);
        player.SetData("progressBar_size", size);
        player.TriggerEvent("SetProgressBar", value, name);
    }

    public static void SetProgressBarValue(Client player, string name, float value)
    {
        player.SetData("progressBar_value", value + player.GetData("progressBar_value"));
        player.TriggerEvent("SetProgressBar", (GetProgressBarValue(player) * 100) / GetProgressBarSize(player), name);
    }

    public static float GetProgressBarValue(Client player)
    {
        return player.GetData("progressBar_value");
    }

    public static float GetProgressBarSize(Client player)
    {
        return player.GetData("progressBar_size");
    }

    public static void DestroyProgressBar(Client player)
    {
        player.SetData("progressBar_value", 0);
        player.SetData("progressBar_size", 0);
        player.TriggerEvent("DestroyProgressBar");
    }

    public static void CreateTextProgressBar(Client player, string name, string value)
    {
        NAPI.Data.SetEntityData(player, "MainProgressText", true);
        NAPI.ClientEvent.TriggerClientEvent(player, "CreateMainProgress", name, value);
    }

    public static void SetTextProgressBar(Client player, string value)
    {
        if (NAPI.Data.GetEntityData(player, "MainProgressText") == true)
        {
            NAPI.ClientEvent.TriggerClientEvent(player, "SetMainProgress", value);
        }
    }

    public static void DeleteTextProgressBar(Client player)
    {
        NAPI.Data.SetEntityData(player, "MainProgressText", false);
        NAPI.ClientEvent.TriggerClientEvent(player, "DeleteMainProgress");
    }

    public static void ShowColorShard(Client player, string title, string description, int bgColor, int titleColor, int timeout)
    {
        player.TriggerEvent("ShowShardMessage", title, description, bgColor, titleColor, timeout);
    }

    public static void ShowColorShardAll(Client player, string title, string description, int bgColor, int titleColor, int timeout)
    {
        player.TriggerEvent("ShowShardMessage", title, description, bgColor, titleColor, timeout);
    }

    public static void SetVehicleFuel(Vehicle vehicle, double fuel)
    {
        int VehicleFuel = 0;
        if (!vehicle.HasData("vehicle_fuel"))
        {
            vehicle.SetData("vehicle_fuel", VehicleFuel);
        }

        vehicle.SetData("vehicle_fuel", fuel);
    }

    public static double GetVehicleFuel(Vehicle vehicle)
    {
        int VehicleFuel = 0;
        if (!vehicle.HasData("vehicle_fuel"))
        {
            vehicle.SetData("vehicle_fuel", VehicleFuel);
        }
        return vehicle.GetData("vehicle_fuel");
    }

    public static TimerEx[] displat_text_timer { get; set; } = new TimerEx[Main.MAX_PLAYERS];
    public bool PAYDAY_READY = false;

    public static void DisplaySubtitle(Client player, string text, uint time = 5)
    {
        int playerid = Main.getIdFromClient(player);

        try
        {
            if (displat_text_timer[playerid] != null)
            {
                displat_text_timer[playerid].Kill();
            }
        }
        catch
        {

        }
        player.SetSharedData("SubTitle", text);

        displat_text_timer[playerid] = TimerEx.SetTimer(() =>
        {

            player.SetSharedData("SubTitle", " ");
            displat_text_timer[playerid] = null;

        }, time * 1000, 1);
    }

    public static void DisplayTextHelp(Client player, string text, int time)
    {
        player.TriggerEvent("displayTextHelp", text, time);
    }


    bool invalid = false;
    private int hartzv;
    private int krankenkasse;
    private dynamic kfzversicherung;
    private Client player;


    public bool IsValidEmail(string strIn)
    {
        invalid = false;
        if (String.IsNullOrEmpty(strIn))
            return false;

        // Use IdnMapping class to convert Unicode domain names.
        try
        {
            strIn = Regex.Replace(strIn, @"(@)(.+)$", this.DomainMapper,
                                  RegexOptions.None, TimeSpan.FromMilliseconds(200));
        }
        catch (RegexMatchTimeoutException)
        {
            return false;
        }

        if (invalid)
            return false;

        // Return true if strIn is in valid e-mail format.
        try
        {
            return Regex.IsMatch(strIn,
                  @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                  @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                  RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
        }
        catch (RegexMatchTimeoutException)
        {
            return false;
        }
    }

    private string DomainMapper(Match match)
    {
        // IdnMapping class with default property values.
        IdnMapping idn = new IdnMapping();

        string domainName = match.Groups[2].Value;
        try
        {
            domainName = idn.GetAscii(domainName);
        }
        catch (ArgumentException)
        {
            invalid = true;
        }
        return match.Groups[1].Value + domainName;
    }

    public static void SetPlayerToTeamColor(Client player)
    {
        if (AccountManage.GetPlayerGroup(player) != -1)
        {
            if (AccountManage.GetPlayerGroup(player) == FactionManage.FACTION_TYPE_POLICE)
            {
                //NAPI.Util.ConsoleOutput("Farbe Polizei-- " + player.Name + "");
                //NAPI.Player.SetPlayerNametagColor(player, 38, 65, 254);
                return;
            }
            else if (AccountManage.GetPlayerGroup(player) == FactionManage.FACTION_TYPE_MEDIC)
            {
                //NAPI.Util.ConsoleOutput("Farbe Medic-- " + player.Name + "");
                //NAPI.Player.SetPlayerNametagColor(player, 247, 128, 128);
                return;
            }
            else if (AccountManage.GetPlayerGroup(player) == FactionManage.FACTION_TYPE_REPORTER)
            {
                //NAPI.Util.ConsoleOutput("Farbe Reorter -- " + player.Name + "");
                //NAPI.Player.SetPlayerNametagColor(player, 135, 224, 127);
                return;
            }
        }
        //NAPI.Util.ConsoleOutput("weiße Zivilfarbe -- " + player.Name + "");
        //NAPI.Player.SetPlayerNametagColor(player, 255, 255, 255);
    }

    /// <summary>
    /// Find a player given a partial name or a ID
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="idOrName"></param>
    /// <returns>null or Client</returns>
    public static Client findPlayer(Client sender, string idOrName)
    {
        int id;

        // If idOrName is Numeric
        if (int.TryParse(idOrName, out id))
        {
            return getClientFromId(sender, id);
        }

        Client returnClient = null;
        int playersCount = 0;
        foreach (var player in players)
        {
            // Skip if list element is null
            if (player == null) continue;


            // If player name contains provided name
            if (player.Name.ToLower().Contains(idOrName.ToLower()))
            {
                // If player name == provided name
                if ((player.Name.Equals(idOrName, StringComparison.OrdinalIgnoreCase)))
                {
                    return player;
                }
                else
                {
                    playersCount++;
                    returnClient = player;
                }
            }
        }


        if (playersCount != 1)
        {
            if (playersCount > 0)
            {
                NAPI.Notification.SendNotificationToPlayer(sender, "ERROR: ~w~Mehrere Benutzer gefunden.");
            }
            else
            {
                NAPI.Notification.SendNotificationToPlayer(sender, "ERROR: ~w~Spielername nicht gefunden.");
            }
            return null;
        }

        return returnClient;
    }

    /// <summary>
    /// Gets the Client from a give ID
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="id"></param>
    /// <returns>null or Client</returns>
    public static Client getClientFromId(Client sender, int id)
    {
        if (id >= MAX_PLAYERS)
        {
            return null;
        }
        if (players[id] == null)
        {
            //NAPI.Notification.SendNotificationToPlayer(sender, "ERROR: ~w~Player ID not found.");
            return null;
        }

        return players[id];
    }

    /// <summary>
    /// Gets the ID from Client
    /// </summary>
    /// <param name="target"></param>
    /// <returns>id or -1 in case of don't find the player</returns>
    public static int getIdFromClient(Client target)
    {
        return players.IndexOf(target);
    }

    public void ResetSQLData(Client player)
    {
        NAPI.Data.SetEntityData(player, "character_money", 0);
        NAPI.Data.SetEntityData(player, "character_bank", 0);
        NAPI.Data.SetEntityData(player, "character_salary", 0);
        NAPI.Data.SetEntityData(player, "character_level", 0);
        NAPI.Data.SetEntityData(player, "character_exp", 0);
        NAPI.Data.SetEntityData(player, "character_leader", 0);
        NAPI.Data.SetEntityData(player, "character_group", 0);
        NAPI.Data.SetEntityData(player, "character_group_rank", 0);
        NAPI.Data.SetEntityData(player, "character_job", 0);
        NAPI.Data.SetEntityData(player, "character_wanted_level", 0);
        NAPI.Data.SetEntityData(player, "character_prison", 0);
        NAPI.Data.SetEntityData(player, "character_prison_cell", 0);
        NAPI.Data.SetEntityData(player, "character_prison_time", 0);
        NAPI.Data.SetEntitySharedData(player, "character_hospital", 0);
        /*"character_level"));
        myCommand.Parameters.AddWithValue("@exp", NAPI.Data.GetEntityData(player, "character_exp"));*/

        NAPI.Data.SetEntityData(player, "character_position_x", 0);
        NAPI.Data.SetEntityData(player, "character_position_y", 0);
        NAPI.Data.SetEntityData(player, "character_position_z", 0);
        NAPI.Data.SetEntityData(player, "character_rotation_z", 0);
        NAPI.Data.SetEntityData(player, "character_business_key", 0);

        player.SetSharedData("character_torso", 0);
        player.SetSharedData("character_undershirt", 0);
        player.SetSharedData("character_undershirt_texture", 0);
        player.SetSharedData("character_leg", 0);
        player.SetSharedData("character_leg_texture", 0);
        player.SetSharedData("character_feet", 0);
        player.SetSharedData("character_feet_texture", 0);
        player.SetSharedData("character_shirt", 0);
        player.SetSharedData("character_shirt_texture", 0);
        player.SetSharedData("character_mask", 0);
        player.SetSharedData("character_mask_texture", 0);
        player.SetSharedData("character_armor", 0);
        player.SetSharedData("character_armor_texture", 0);

        NAPI.Data.SetEntityData(player, "character_duty_outfit", -1);


        NAPI.Data.SetEntityData(player, "duty", 0);
        // Default player data
        player.SetData("Hunger", 100);
        player.SetData("Thirsty", 100);

        player.SetData("ThirstyTimer", 0);
        player.SetData("HungerTimer", 0);

        player.SetData("LowHealthEffect", false);
    }

    public static void ClientEvent(Client client, string eventName, params object[] args)
    {
        if (Thread.CurrentThread.Name == "Main")
        {
            NAPI.ClientEvent.TriggerClientEvent(client, eventName, args);
            return;
        }
        NAPI.Task.Run(() =>
        {
            if (client == null) return;
            NAPI.ClientEvent.TriggerClientEvent(client, eventName, args);
        });
    }
    public static void ClientEventInRange(Vector3 pos, float range, string eventName, params object[] args)
    {
        if (Thread.CurrentThread.Name == "Main")
        {
            NAPI.ClientEvent.TriggerClientEventInRange(pos, range, eventName, args);
            return;
        }
        NAPI.Task.Run(() =>
        {
            NAPI.ClientEvent.TriggerClientEventInRange(pos, range, eventName, args);
        });
    }
    public static void ClientEventInDimension(uint dim, string eventName, params object[] args)
    {
        if (Thread.CurrentThread.Name == "Main")
        {
            NAPI.ClientEvent.TriggerClientEventInDimension(dim, eventName, args);
            return;
        }
        NAPI.Task.Run(() =>
        {
            NAPI.ClientEvent.TriggerClientEventInDimension(dim, eventName, args);
        });
    }
    public static void ClientEventToPlayers(Client[] players, string eventName, params object[] args)
    {
        if (Thread.CurrentThread.Name == "Main")
        {
            NAPI.ClientEvent.TriggerClientEventToPlayers(players, eventName, args);
            return;
        }
        NAPI.Task.Run(() =>
        {
            NAPI.ClientEvent.TriggerClientEventToPlayers(players, eventName, args);
        });
    }

    public static bool IsNumeric(string input)
    {
        int test;
        return int.TryParse(input, out test);
    }


    public static void PlaySoundFrontend(Client client, string audioName, string audioLibrary) => client.TriggerEvent("PlaySoundFrontend", audioName, audioLibrary);
}

