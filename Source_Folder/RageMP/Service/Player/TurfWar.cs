using System;
using System.Collections.Generic;
using GTANetworkAPI;
using MySql.Data.MySqlClient;


class TurfWar : Script
{
    public static int TURF_DEFAULT_VULNERABLE = Economy.TURF_WAR_VULNERABLE;
    public static int TURF_NEED_PLAYERS_START = Economy.PLAYER_TO_START_WAR;

    public class TurfEnum : IEquatable<TurfEnum>
    {
        public int id { get; set; }

        public string name { get; set; }

        public int ownerid { get; set; }
        public int vulnerable { get; set; }

        public int payment { get; set; }

        public string capturedBy { get; set; }
        public string capturingBy { get; set; }

        public int active_war { get; set; }
        public int attemptid { get; set; }
        public int attack_points { get; set; }
        public int defend_point { get; set; }
        public int attack_kills { get; set; }
        public int defend_kills { get; set; }
        public int time_left { get; set; }
        public int time_left_start { get; set; }

        public float area_range { get; set; }

        public Vector3 Position { get; set; }
        public Vector3 Position_pickup { get; set; }

        public ColShape areaid { get; set; }
        public Entity pickupid { get; set; }
        public Entity labelid { get; set; }
        public Entity blipid { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            TurfEnum objAsPart = obj as TurfEnum;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }
        public override int GetHashCode()
        {
            return id;
        }
        public bool Equals(TurfEnum other)
        {
            if (other == null) return false;
            return (this.id.Equals(other.id));
        }
    }
    public static List<TurfEnum> turf_war = new List<TurfEnum>();

    public static void TurfWarInit()
    {
        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {
            Mainpipeline.Open();
            MySqlCommand query = new MySqlCommand("SELECT * FROM `turfs`;", Mainpipeline);
            using (MySqlDataReader reader = query.ExecuteReader())
            {
                var index = 0;
                while (reader.Read())
                {
                    turf_war.Add(new TurfEnum()
                    {
                        id = reader.GetInt32("id"),
                        name = reader.GetString("name"),
                        ownerid = reader.GetInt32("ownerid"),
                        vulnerable = reader.GetInt32("vulnerable"),
                        capturedBy = reader.GetString("capturedBy"),

                        payment = reader.GetInt32("payment"),

                        Position = new Vector3(float.Parse(reader.GetString("position_x")), float.Parse(reader.GetString("position_y")), float.Parse(reader.GetString("position_z"))),
                        area_range = float.Parse(reader.GetString("range")),

                        time_left = 0,
                        time_left_start = 30,
                        attack_points = 0,
                        defend_point = 0,
                        attack_kills = 0,
                        defend_kills = 0,
                        active_war = 0,
                        attemptid = -1

                    });


                    turf_war[index].areaid = NAPI.ColShape.CreateSphereColShape(turf_war[index].Position, turf_war[index].area_range);
                    turf_war[index].blipid = NAPI.Blip.CreateBlip(turf_war[index].Position);
                    //NAPI.Blip.SetBlipScale(turf_war[index].blipid, 0.92f);

                    if (float.Parse(reader.GetString("position_x")) == 0 && float.Parse(reader.GetString("position_y")) == 0)
                    {
                        NAPI.Blip.SetBlipTransparency(turf_war[index].blipid, 0);
                    }
                    else
                    {
                        UpdateTurfProps(index);
                    }
                    index++;
                }
                //NAPI.Util.ConsoleOutput("[MySQL]: " + index + " Rasen aus der Datenbank hochgeladen.");
            }
        }
    }

    public static void SaveTurfWar(int index)
    {
        string query = "UPDATE `turfs` SET `name` = '" + turf_war[index].name + "', `ownerid` = '" + turf_war[index].ownerid + "', `vulnerable` = '" + turf_war[index].vulnerable + "', `capturedBy` = '" + turf_war[index].capturedBy + "', `position_x` = '" + turf_war[index].Position.X + "', `position_y` = '" + turf_war[index].Position.Y + "', `position_z` = '" + turf_war[index].Position.Z + "', `range` = '" + turf_war[index].area_range + "',  `payment` = '" + turf_war[index].payment + "' WHERE `id` = '" + index + "';";
        //NAPI.Util.ConsoleOutput(query);
        Main.CreateMySqlCommand(query);
        // debug
        //NAPI.Util.ConsoleOutput("[MySQL] turf " + index + " Erfolgreich gespeichert.");
    }

    public static void UpdateTurfProps(int index)
    {
        NAPI.Blip.SetBlipPosition(turf_war[index].blipid, turf_war[index].Position);
        NAPI.Blip.SetBlipName(turf_war[index].blipid, "Kriegszone");
        NAPI.Blip.SetBlipSprite(turf_war[index].blipid, 439);
        NAPI.Blip.SetBlipShortRange(turf_war[index].blipid, true);
        NAPI.Blip.SetBlipTransparency(turf_war[index].blipid, 255);
        NAPI.Blip.SetBlipScale(turf_war[index].blipid, 0.4f);
        //NAPI.Blip.SetBlipScale(turf_war[index].blipid, 0.6f);
        //NAPI.Blip.SetBlipColor(turf_war[index].blipid, 1);

        if (turf_war[index].active_war == 1)
        {
            NAPI.Blip.SetBlipColor(turf_war[index].blipid, 1);
        }
        else if (turf_war[index].ownerid != -1)
        {
            NAPI.Blip.SetBlipColor(turf_war[index].blipid, 28);
        }
        else
        {
            NAPI.Blip.SetBlipColor(turf_war[index].blipid, 25);
        }
    }

    [Command("criarturf")]
    public void CMD_createturf(Client player, int range)
    {
        if (AccountManage.GetPlayerAdmin(player) < adminCommands.COORDENADOR)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben keine Berechtigung, diesen Befehl zu verwenden.");
            return;
        }
        player.SetData("editingTurfRange", range);
        InteractMenu.User_Input(player, "input_create_turfwar", "Name des Gebiets", "");
        //player.TriggerEvent("GetUserInput", "Digite o nome da turf", "INPUT_CREATE_TURF", 70);
    }

    [Command("turfinfo", Alias = "territorio, tinfo")]
    public void CMD_turfinfo(Client player)
    {
        //NAPI.Util.ConsoleOutput(" 1");
        int index = player.GetData("player_in_turf");

        if (index == -1)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Sie befinden sich nicht in einem Gebiet.");
        }
        else
        {
            NAPI.Notification.SendNotificationToPlayer(player, "~g~[TURF]:~w~ Name: ~y~" + turf_war[index].name + " (" + index + ")");

            if (turf_war[index].ownerid == -1)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "~g~[TURF]:~w~ Besiter: ~c~Niemand");
            }
            else
            {
                NAPI.Notification.SendNotificationToPlayer(player, "~g~[TURF]:~w~ Besitzer: ~c~" + FactionManage.faction_data[turf_war[index].ownerid].faction_name + "");
            }

            TimeSpan time = TimeSpan.FromSeconds(turf_war[index].vulnerable);
            string string_vulnerable = time.ToString(@"hh\:mm\:ss");

            TimeSpan timeleft = TimeSpan.FromSeconds(turf_war[index].time_left);
            string string_time_left = timeleft.ToString(@"hh\:mm\:ss");

            if (turf_war[index].active_war == 0)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "~g~[TURF]:~w~ Status: ~b~Ist nicht im Krieg");

                if (turf_war[index].vulnerable > 0) NAPI.Notification.SendNotificationToPlayer(player, "~g~[TURF]:~w~ Gefährdet: Verfügbar in " + string_vulnerable + "");
                else NAPI.Notification.SendNotificationToPlayer(player, "~g~[TURF]:~w~ Verwundbar: Verfügbar für einen Krieg ");
            }
            else
            {
                NAPI.Notification.SendNotificationToPlayer(player, "~g~[TURF]:~w~ Status: Im Krieg");
                NAPI.Notification.SendNotificationToPlayer(player, "~g~[TURF]:~w~ Verbleibende Zeit: " + string_time_left + "");
                NAPI.Notification.SendNotificationToPlayer(player, "~g~[TURF]:~w~ Todesfälle: " + (turf_war[index].attack_kills + turf_war[index].defend_kills) + "");
            }
        }

    }

    [Command("editarturf", "/editarturf [turf id] [nome(nome/posicao/range/vulnerabilidade/pagamento)] [valor~c~(ifnecessary)~w~]")]
    public void CMD_timeleft(Client player, int index, string name, string value = "0")
    {
        if (AccountManage.GetPlayerAdmin(player) < adminCommands.COORDENADOR)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben keine Berechtigung, diesen Befehl zu verwenden.");
            return;
        }
        if (name == "nome")
        {
            player.SetData("EditingTurfID", index);
            InteractMenu.User_Input(player, "input_edit_turfwar", "Name des Gebiets", turf_war[index].name);
            //player.TriggerEvent("GetUserInput", "Digite o nome da turf", "INPUT_TURF_NAME", 70);
        }
        else if (name == "range")
        {
            if (Convert.ToInt32(value) < 20)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "[ERROR]~w~ O Die Reichweite kann nicht unter 20 liegen.");
                return;
            }
            turf_war[index].area_range = Convert.ToInt32(value);

            NAPI.ColShape.DeleteColShape(turf_war[index].areaid);
            turf_war[index].areaid = NAPI.ColShape.CreateSphereColShape(turf_war[index].Position, turf_war[index].area_range);
            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben den Bereich des Rasens bearbeitet " + index + " zu" + turf_war[index].area_range + ".");
            SaveTurfWar(index);
        }
        else if (name == "position")
        {

       
            turf_war[index].Position = player.Position;
            NAPI.ColShape.DeleteColShape(turf_war[index].areaid);
            turf_war[index].areaid = NAPI.ColShape.CreateSphereColShape(turf_war[index].Position, turf_war[index].area_range);
            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben die Rasenposition bearbeitet " + index + ".");

            var players = NAPI.Pools.GetAllPlayers();
            foreach (var p in players)
            {
                p.TriggerEvent("setZonePosition", index, turf_war[index].Position.X, turf_war[index].Position.Y, turf_war[index].Position.Z);
                UpdateZoneBlipForPlayer(p);
            }

        }
        else if (name == "vulnerabilidade")
        {
            turf_war[index].vulnerable = Convert.ToInt32(value);
            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben die Rasenposition bearbeitet " + index + ".");

        }
        else if (name == "pagamento")
        {
            turf_war[index].payment = Convert.ToInt32(value);
            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben die Rasenzahlung bearbeitet " + index + " para " + Convert.ToInt32(value) + ".");
        }

    }

    public static void OnInputResponse(Client player, String response, String inputtext)
    {
        if (response == "input_create_turfwar")
        {
            int index = 0;
            foreach (var turf in turf_war)
            {
                if (turf.name == "Zivilist")
                {
                    turf.name = inputtext;
                    turf.ownerid = -1;
                    turf.vulnerable = 0;

                    turf.Position = player.Position;
                    turf.area_range = player.GetData("editingTurfRange");

                    NAPI.ColShape.DeleteColShape(turf_war[index].areaid);
                    turf_war[index].areaid = NAPI.ColShape.CreateSphereColShape(TurfWar.turf_war[index].Position, TurfWar.turf_war[index].area_range);

                    UpdateTurfProps(index);
                    SaveTurfWar(index);
                    NAPI.Notification.SendNotificationToPlayer(player, "Sie haben einen Rasen angelegt(ID " + index + ") mit dem Namen von " + inputtext + ".");
                    return;
                }
                index++;
            }
        }
        else if (response == "input_edit_turfwar")
        {
            TurfWar.turf_war[player.GetData("EditingTurfID")].name = inputtext;
            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben den Namen des Rasens geändert" + player.GetData("EditingTurfID") + " zu " + inputtext + "");
            TurfWar.SaveTurfWar(player.GetData("EditingTurfID"));
        }
    }

    public static void TakeoverTurfWarsZone(int gangid, int zone)
    {
        if (turf_war[zone].ownerid == -1)
        {
            FactionManage.SendFactionMessage(gangid, "** Seine Bande beherrschte das unbesetzte Gebiet.");


            turf_war[zone].ownerid = gangid;

            turf_war[zone].vulnerable = 0;

            turf_war[zone].active_war = 0;
            turf_war[zone].time_left = 0;
            turf_war[zone].time_left_start = 30;
            turf_war[zone].attemptid = -1;
            UpdateTurfProps(zone);
            SaveTurfWar(zone);
            return;
        }

        turf_war[zone].active_war = 1;
        turf_war[zone].attemptid = gangid;

        turf_war[zone].time_left = 600;
        turf_war[zone].time_left_start = 30;

        turf_war[zone].vulnerable = 0;

        turf_war[zone].attack_kills = 0;
        turf_war[zone].defend_kills = 0;
        turf_war[zone].attack_points = 0;
        turf_war[zone].defend_point = 50;
        UpdateTurfProps(zone);
        UpdateZoneBlipForAll();

    }

    public static void CaptureTurfWarsZone(int zone, int attack_gang, int defend_gang)
    {
        int winner = -1;

        if (turf_war[zone].attack_points == turf_war[zone].defend_point)
        {
            if (GetPlayersInTurf(zone, attack_gang) <= GetPlayersInTurf(zone, defend_gang))
            {
                winner = attack_gang;
            }
            else if (GetPlayersInTurf(zone, attack_gang) > GetPlayersInTurf(zone, defend_gang))
            {
                winner = attack_gang;
            }
        }
        else if (turf_war[zone].attack_points < turf_war[zone].defend_point)
        {
            winner = defend_gang;
        }
        else if (turf_war[zone].attack_points > turf_war[zone].defend_point)
        {
            winner = attack_gang;
        }

        string attack_name = FactionManage.faction_data[attack_gang].faction_name;
        string defend_name = FactionManage.faction_data[defend_gang].faction_name;

        if (winner == defend_gang)
        {
            FactionManage.SendFactionMessage(defend_gang, "* Seine Bande verteidigte das Gebiet" + turf_war[zone].name + " der Bande " + attack_name + ".");
            FactionManage.SendFactionMessage(attack_gang, "* Seine Bande konnte das Territorium nicht dominieren." + turf_war[zone].name + " der Bande " + defend_name + ".");

            turf_war[zone].ownerid = defend_gang;
            turf_war[zone].vulnerable = TURF_DEFAULT_VULNERABLE;

            turf_war[zone].active_war = 0;
            turf_war[zone].time_left = 0;
            turf_war[zone].time_left_start = 30;
            turf_war[zone].attemptid = -1;

            UpdateTurfProps(zone);
            SaveTurfWar(zone);
            UpdateZoneBlipForAll();
        }
        else if (winner == attack_gang)
        {
            FactionManage.SendFactionMessage(attack_gang, "* Seine Bande beherrschte das Gebiet. " + turf_war[zone].name + " der Bande " + defend_name + ".");
            FactionManage.SendFactionMessage(defend_gang, "* Deine Bande hat ihr Territorium verloren. " + turf_war[zone].name + " zu der Gang " + attack_name + ".");

            turf_war[zone].ownerid = attack_gang;
            turf_war[zone].vulnerable = TURF_DEFAULT_VULNERABLE;

            turf_war[zone].active_war = 0;
            turf_war[zone].time_left = 0;
            turf_war[zone].time_left_start = 30;
            turf_war[zone].attemptid = -1;

            UpdateTurfProps(zone);
            SaveTurfWar(zone);
            UpdateZoneBlipForAll();
        }
    }

    public static int GetPlayersInTurf(int zoneid, int gangid)
    {
        int count = 0;
        var players = NAPI.Pools.GetAllPlayers();
        foreach (var i in players)
        {
            if (i.GetData("player_in_turf") == zoneid && AccountManage.GetPlayerGroup(i) == gangid && !i.IsInVehicle) count++;
        }
        return count;
    }

    public static void CreatezoneForPlayer(Client player)
    {
        int zone = 0;
        foreach (var turf in turf_war)
        {
            player.TriggerEvent("CreateZone", turf.Position.X, turf.Position.Y, turf.Position.Z, 45, turf.area_range, 0);
        }
        player.TriggerEvent("loadCapturezones");
    }

    public static void UpdateZoneBlipForPlayer(Client player)
    {
        int zone = 0;
        foreach (var turf in turf_war)
        {
            if (turf.Position.X != 0 && turf.Position.Y != 0)
            {
                player.TriggerEvent("setZoneAlpha", zone, 175);

                if (turf.ownerid != -1) {
                    player.TriggerEvent("setZoneColor", zone, FactionManage.faction_data[turf.ownerid].faction_turf_color);
                }
                else player.TriggerEvent("setZoneColor", zone, 45);

                if (turf.active_war == 1) {
                    player.TriggerEvent("setZoneFlash", zone, true);
                }
                else player.TriggerEvent("setZoneFlash", zone, false);
            }
            else player.TriggerEvent("setZoneAlpha", zone, 0);
            zone++;
        }
    }
    public static void UpdateZoneBlipForAll()
    {
        var players = NAPI.Pools.GetAllPlayers();
        foreach (var player in players)
        {
            UpdateZoneBlipForPlayer(player);
        }
        
    }

}