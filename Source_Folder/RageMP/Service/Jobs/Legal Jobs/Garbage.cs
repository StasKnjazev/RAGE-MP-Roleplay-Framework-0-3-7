//232
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
using DerStr1k3r.SDK;

public class Garbage : Script
{
    static int PAYMENT_PER_PIN_BAG = 60;
    private static int LIMIT_GARBAGE_INVENTORY = 20;
    public static Entity pin_bag = NAPI.Object.CreateObject(-1998455445, new Vector3(), new Vector3());

    public static ColShape recliclagem;
    public class GarbageEnum : IEquatable<GarbageEnum>

    {
        public int trashID { get; set; }
        public Entity trashHandle { get; set; }
        public Vector3 trashPosition { get; set; }
        public Vector3 trashRotation { get; set; }
        public ColShape trashArea { get; set; }
        public int trashStatus { get; set; }


        public override int GetHashCode()
        {
            return trashID;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            GarbageEnum objAsPart = obj as GarbageEnum;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }

        public bool Equals(GarbageEnum other)
        {
            if (other == null) return false;
            return (this.trashID.Equals(other.trashID));
        }
    }

    public static List<GarbageEnum> trash_list = new List<GarbageEnum>();

    public static void GarbageInit()
    {
        int count = 0;
        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {
            Mainpipeline.Open();
            MySqlCommand query = new MySqlCommand("SELECT * FROM `garbages`;", Mainpipeline);

            using (MySqlDataReader reader = query.ExecuteReader())
            {
                while (reader.Read())
                {
                    trash_list.Add(new GarbageEnum() { trashID = reader.GetInt32("id"), trashPosition = new Vector3(float.Parse(reader.GetString("position_x").Replace(Translation.COORDS_FROM, Translation.COORDS_TO)), float.Parse(reader.GetString("position_y").Replace(Translation.COORDS_FROM, Translation.COORDS_TO)), float.Parse(reader.GetString("position_z").Replace(Translation.COORDS_FROM, Translation.COORDS_TO))), trashStatus = 0 });
                    count++;
                }

                NAPI.Util.ConsoleOutput("[MySQL Database]: " + count + " pin bags loaded.");
                foreach (var garbage in trash_list)
                {
                    garbage.trashHandle = NAPI.Object.CreateObject(-1998455445, new Vector3(garbage.trashPosition.X, garbage.trashPosition.Y, garbage.trashPosition.Z - 0.2f), new Vector3(), 0);
                    garbage.trashArea = NAPI.ColShape.CreateCylinderColShape(garbage.trashPosition, 1.0f, 1.0f);
                    garbage.trashStatus = 0;
                    //NAPI.Util.ConsoleOutput("[MySQL Database]: "+garbage.trashPosition.X + ", " + garbage.trashPosition.Y+", " + garbage.trashPosition.Z +"");
                }

                recliclagem = NAPI.ColShape.CreateCylinderColShape(new Vector3(1262.642, -1983.434, 43.34987), 2.0f, 2.0f);

                NAPI.TextLabel.CreateTextLabel("- Müll entladen -", new Vector3(1262.642, -1983.434, 43.34987 + 1.6), 27, 1.1f, 0, new Color(255, 255, 255, 255));
                NAPI.Marker.CreateMarker(23, new Vector3(1262.642, -1983.434, 43.34987), new Vector3(), new Vector3(), 7.0f, new Color(180, 22, 111, 255));
				
                Blip temp_blip = null;
                temp_blip = NAPI.Blip.CreateBlip(new Vector3(1262.642, -1983.434, 43.34987), 0);
                temp_blip.Sprite = 318;
                temp_blip.Name = "Trash Mine";
                temp_blip.Color = 1;
                temp_blip.ShortRange = true;
            }
        }
    }

    //
    //
    //
    public static void collectorCarsSpawner()
    {


        Main_VehicleManage.CreateVehicle(9, VehicleHash.Trash, new Vector3(1288.257, -1951.209, 43.28372), new Vector3(4.038138, 1.470755, 20.47495), 89, 111, "COLLECTOR-30", "TRASHCOLLECTOR");
        Main_VehicleManage.CreateVehicle(9, VehicleHash.Trash, new Vector3(1278.957, -1954.833, 43.23843), new Vector3(3.601945, 3.428418, 19.29663), 89, 111, "COLLECTOR-30", "TRASHCOLLECTOR");
        Main_VehicleManage.CreateVehicle(9, VehicleHash.Trash, new Vector3(1256.76, -1947.493, 42.97947), new Vector3(-0.2992753, 0.4740987, 297.8329), 89, 111, "COLLECTOR-30", "TRASHCOLLECTOR");
        Main_VehicleManage.CreateVehicle(9, VehicleHash.Trash, new Vector3(1320.49, -1924.349, 43.11915), new Vector3(-1.727101, 3.948452, 115.2172), 89, 111, "COLLECTOR-30", "TRASHCOLLECTOR");
        Main_VehicleManage.CreateVehicle(9, VehicleHash.Trash, new Vector3(1289.16, -1968.494, 43.4589), new Vector3(1.003069, 0.1387891, 206.4751), 89, 111, "COLLECTOR-30", "TRASHCOLLECTOR");
        Main_VehicleManage.CreateVehicle(9, VehicleHash.Trash, new Vector3(1259.628, -2015.047, 43.9184), new Vector3(4.743094, -2.240847, 289.654), 89, 111, "COLLECTOR-30", "TRASHCOLLECTOR");
        Main_VehicleManage.CreateVehicle(9, VehicleHash.Trash, new Vector3(1257.365, -1934.276, 42.97782), new Vector3(0.4317599, 0.1919272, 204.448), 89, 111, "COLLECTOR-30", "TRASHCOLLECTOR");
        Main_VehicleManage.CreateVehicle(9, VehicleHash.Trash, new Vector3(1298.289, -1919.924, 42.97672), new Vector3(0.3050196, 0.04404865, 190.2081), 89, 111, "COLLECTOR-30", "TRASHCOLLECTOR");


    }

    public static void respawnCar(Vehicle veh)
    {
        try
        {
            int i = NAPI.Data.GetEntityData(veh, "NUMBER");
            NAPI.Entity.SetEntityPosition(veh, Main_VehicleManage.CarInfos[i].Position);
            NAPI.Entity.SetEntityRotation(veh, Main_VehicleManage.CarInfos[i].Rotation);
            veh.Repair();

            NAPI.Data.SetEntityData(veh, "ACCESS", "WORK");
            NAPI.Data.SetEntityData(veh, "WORK", 5);
            NAPI.Data.SetEntityData(veh, "TYPE", "TRASHCOLLECTOR");
            NAPI.Data.SetEntityData(veh, "NUMBER", i);
            NAPI.Data.SetEntityData(veh, "ON_WORK", false);
            NAPI.Data.SetEntityData(veh, "DRIVER", null);

        }
        catch (Exception e) { API.Shared.ConsoleOutput("respawnCar: " + e.Message); }
    }

    public static void onPlayerDissconnectedHandler(Client player, DisconnectionType type, string reason)
    {
        try
        {
            if (!player.GetData("status")) return;
            try { if (!player.GetData("ON_WORK")) return; }
            catch { return; }
            if (Main_Job.GetPlayerJob(player) == 9 &&
                NAPI.Data.GetEntityData(player, "WORK") != null)
            {
                var vehicle = NAPI.Data.GetEntityData(player, "WORK");
                respawnCar(vehicle);
            }
        }
        catch (Exception e) { API.Shared.ConsoleOutput("PlayerDisconnected: " + e.Message); }
    }

    [ServerEvent(Event.PlayerExitVehicle)]
    public void onPlayerExitVehicleHandler(Client player, Vehicle vehicle)
    {
        try
        {
            //API.Shared.ConsoleOutput("WE ARE HERE");
            if (NAPI.Data.GetEntityData(vehicle, "TYPE") == "TRASHCOLLECTOR" &&
            Main_Job.GetPlayerJob(player) == 9 &&
            NAPI.Data.GetEntityData(player, "ON_WORK") &&
            NAPI.Data.GetEntityData(player, "WORK") == vehicle)
            {
                //API.Shared.ConsoleOutput("WE ARE HERE2 ");
                Notify.Send(player, NotifyType.Warning, NotifyPosition.BottomCenter, $"Wenn Sie nach 60 Sekunden nicht in das Fahrzeug einsteigen, endet der Arbeitstag.", 5000);
                NAPI.Data.SetEntityData(player, "IN_WORK_CAR", false);
                if (player.HasData("WORK_CAR_EXIT_TIMER"))
                {
                    //Main.StopT(NAPI.Data.GetEntityData(player, "WORK_CAR_EXIT_TIMER"), "timer_4");
                    //Timers.Stop(NAPI.Data.GetEntityData(player, "WORK_CAR_EXIT_TIMER"));
                    try
                    {
                        NAPI.Data.GetEntityData(player, "WORK_CAR_EXIT_TIMER").Kill();
                    }
                    catch
                    {
                    }
                }
                NAPI.Data.SetEntityData(player, "CAR_EXIT_TIMER_COUNT", 0);
                //NAPI.Data.SetEntityData(player, "WORK_CAR_EXIT_TIMER", Main.StartT(1000, 1000, (o) => timer_playerExitWorkVehicle(player, vehicle), "LAWNM_CAR_EXIT_TIMER"));
                //NAPI.Data.SetEntityData(player, "WORK_CAR_EXIT_TIMER", Timers.StartTask(1000, () => timer_playerExitWorkVehicle(player, vehicle)));

                player.SetData("WORK_CAR_EXIT_TIMER", TimerEx.SetTimer(() => timer_playerExitWorkVehicle(player, vehicle), 1000, 0));
            }
        }
        catch (Exception e) { API.Shared.ConsoleOutput("PlayerExitVehicle: " + e.Message); }
    }

    public static void timer_playerExitWorkVehicle(Client player, Vehicle vehicle)
    {
        NAPI.Task.Run(() =>
        {
            try
            {
                if (!player.HasData("WORK_CAR_EXIT_TIMER")) return;
                if (NAPI.Data.GetEntityData(player, "IN_WORK_CAR"))
                {
                    //Main.StopT(NAPI.Data.GetEntityData(player, "WORK_CAR_EXIT_TIMER"), "timer_5");
                    //Timers.Stop(NAPI.Data.GetEntityData(player, "WORK_CAR_EXIT_TIMER"));
                    try
                    {
                        NAPI.Data.GetEntityData(player, "WORK_CAR_EXIT_TIMER").Kill();
                    }
                    catch
                    {

                    }
                    NAPI.Data.ResetEntityData(player, "WORK_CAR_EXIT_TIMER");
                    return;
                }
                if (NAPI.Data.GetEntityData(player, "CAR_EXIT_TIMER_COUNT") > 60)
                {
                    respawnCar(vehicle);
                    NAPI.Data.SetEntityData(player, "ON_WORK", false);
                    NAPI.Data.SetEntityData(player, "WORK", null);
                    Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du hast den Arbeitstag beendet.", 5000);
                    Trigger.ClientEvent(player, "deleteCheckpoint", 4, 0);
                    //Main.StopT(NAPI.Data.GetEntityData(player, "WORK_CAR_EXIT_TIMER"), "timer_6");
                    //Timers.Stop(NAPI.Data.GetEntityData(player, "WORK_CAR_EXIT_TIMER"));
                    try
                    {
                        NAPI.Data.GetEntityData(player, "WORK_CAR_EXIT_TIMER").Kill();
                    }
                    catch
                    {

                    }

                    if (player.HasData("WORKOBJECT"))
                    {
                        BasicSync.DetachObject(player);
                        player.ResetData("WORKOBJECT");
                    }


                    foreach (var garbage in Garbage.trash_list)
                    {
                        if (garbage.trashPosition.X != 0 && garbage.trashPosition.Y != 0)
                        {
                            player.TriggerEvent("blip_remove", "Lixo #" + garbage.trashID + "");
                        }
                    }

                    NAPI.Data.ResetEntityData(player, "WORK_CAR_EXIT_TIMER");
                    Main.UpdatePlayerClothes(player);
                    return;
                }
                NAPI.Data.SetEntityData(player, "CAR_EXIT_TIMER_COUNT", NAPI.Data.GetEntityData(player, "CAR_EXIT_TIMER_COUNT") + 1);
            }
            catch (Exception e) { API.Shared.ConsoleOutput("Timer_PlayerExitWorkVehicle_Lawnmower: " + e.Message); }
        });
    }

    [ServerEvent(Event.PlayerEnterVehicle)]
    public void onPlayerEnterVehicleHandler(Client player, Vehicle vehicle, sbyte seatid)
    {
        try
        {
            if (NAPI.Data.GetEntityData(vehicle, "TYPE") != "TRASHCOLLECTOR" || player.VehicleSeat != -1) return;

            if (Main_Job.GetPlayerJob(player) == 9)
            {
                if (!NAPI.Data.GetEntityData(vehicle, "ON_WORK"))
                {
                    if (NAPI.Data.GetEntityData(player, "WORK") == null)
                    {
                        InteractMenu.ShowModal(player, "TRASHCOLLECT_RENT", "Müllsammlerarbeit", "Möchten Sie den Job starten?", "Ja", "Nein");
                    }
                    else if (NAPI.Data.GetEntityData(player, "WORK") == vehicle)
                    {
                        NAPI.Data.SetEntityData(player, "IN_WORK_CAR", true);


                    }
                }
                else
                {
                    if (NAPI.Data.GetEntityData(player, "WORK") != vehicle)
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"Es arbeitet bereits jemand mit diesem Fahrzeug. Bitte wählen Sie ein anderes aus.", 5000);
                        player.WarpOutOfVehicle();
                    }
                    else NAPI.Data.SetEntityData(player, "IN_WORK_CAR", true);
                }
            }
            else
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"Sie arbeiten nicht als Müllsammler.", 5000);
                player.WarpOutOfVehicle();
            }
        }
        catch (Exception e) { API.Shared.ConsoleOutput("PlayerEnterVehicle: " + e.Message); }
    }

    public static void collectorRent(Client player)
    {
        if (NAPI.Player.IsPlayerInAnyVehicle(player) || player.VehicleSeat != -1 || player.Vehicle.GetData("TYPE") != "TRASHCOLLECTOR")
        {
            var way = 0;
            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie haben angefangen, als Garbage Collector zu arbeiten. Befolgen Sie die Checkpoints.", 5000);
            var vehicle = player.Vehicle;
            NAPI.Data.SetEntityData(player, "WORK", vehicle);
            //Core.VehicleStreaming.SetEngineState(vehicle, true);
            NAPI.Data.SetEntityData(player, "ON_WORK", true);
            NAPI.Data.SetEntityData(player, "IN_WORK_CAR", true);
            NAPI.Data.SetEntityData(vehicle, "ON_WORK", true);
            NAPI.Data.SetEntityData(player, "WORKWAY", way);
            NAPI.Data.SetEntityData(player, "WORKCHECK", 0);
            NAPI.Data.SetEntityData(vehicle, "DRIVER", player);
            player.ResetData("garbage_inventory_full");
            NAPI.Data.SetEntityData(vehicle, "garbage_inventory", 0);
            Outfits.SetUnisexOutfit(player, 64);
            Garbage.SetGarbageBlipOnMap(player);
        }
        else
        {
            Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"Sie müssen im Transporter sein", 5000);
        }
    }

    //
    //
    //
    public static void SetGarbageBlipOnMap(Client player)
    {
        foreach (var garbage in trash_list)
        {
            if (garbage.trashPosition.X != 0 && garbage.trashPosition.Y != 0 && garbage.trashStatus == 0)
            {
                if (player.GetData("ON_WORK") == true && Main_Job.GetPlayerJob(player) == 9)
                {
                    player.TriggerEvent("blip_remove", "Lixo #" + garbage.trashID + "");
                    player.TriggerEvent("blip_create_ext", "Lixo #" + garbage.trashID + "", garbage.trashPosition, 2, 0.80f, 0);
                    //player.TriggerEvent("blip_range", "Lixo #" + garbage.trashID + "", true);
                }

            }
        }
    }
    [Command("salvarlixo")]
    public void CMD_salvarlixo(Client player)
    {
        if (AccountManage.GetPlayerAdmin(player) < 2)
        {
            Main.SendErrorMessage(player, "Sie dürfen diesen Befehl nicht verwenden.");
            return;
        }
        foreach (var garbage in trash_list)
        {
            if (garbage.trashPosition.X == 0 && garbage.trashPosition.Y == 0)
            {
                garbage.trashPosition.X = player.Position.X;
                garbage.trashPosition.Y = player.Position.Y;
                garbage.trashPosition.Z = player.Position.Z;

                garbage.trashHandle = NAPI.Object.CreateObject(-1998455445, new Vector3(garbage.trashPosition.X, garbage.trashPosition.Y, garbage.trashPosition.Z - 0.2f), new Vector3(), 0);
                garbage.trashArea = NAPI.ColShape.CreateCylinderColShape(garbage.trashPosition, 1.0f, 1.0f);
                garbage.trashStatus = 0;

                var players = NAPI.Pools.GetAllPlayers();
                foreach (var target in players)
                {
                    if (target.GetData("status") == true && target.GetData("ON_WORK") == true && AccountManage.GetPlayerJob(target) == 9)
                    {
                        target.TriggerEvent("blip_remove", "Lixo #" + garbage.trashID + "");
                        target.TriggerEvent("blip_create_ext", "Lixo #" + garbage.trashID + "", garbage.trashPosition, 2, 0.80f, 0);
                        //target.TriggerEvent("blip_range", "Lixo #" + garbage.trashID + "", true);
                    }
                }


                Main.CreateMySqlCommand("UPDATE garbages SET `position_x` = '" + garbage.trashPosition.X + "', `position_y` = '" + garbage.trashPosition.Y + "', `position_z` = '" + garbage.trashPosition.Z + "' WHERE id = '" + garbage.trashID + "';");
                return;
            }
        }
    }

    [Command("destruirlixo")]
    public void CMD_destruirlixo(Client player, int index)
    {
        if (AccountManage.GetPlayerAdmin(player) < 1)
        {
            Main.SendErrorMessage(player, "Sie dürfen diesen Befehl nicht verwenden.");
            return;
        }
        foreach (var garbage in trash_list)
        {
            if (Main.IsInRangeOfPoint(player.Position, garbage.trashPosition, 1.0f))
            {
                garbage.trashPosition.X = 0;
                garbage.trashPosition.Y = 0;
                garbage.trashPosition.Z = 0;

                garbage.trashHandle.Delete();

                NAPI.ColShape.DeleteColShape(garbage.trashArea);

                var players = NAPI.Pools.GetAllPlayers();
                foreach (var target in players)
                {
                    if (target.GetData("status") == true && target.GetData("ON_WORK") == true && AccountManage.GetPlayerJob(target) == 9)
                    {

                        target.TriggerEvent("blip_remove", "Lixo #" + garbage.trashID + "");
                    }
                }

                Main.DisplaySubtitle(player, "[ADMIN]:~y~ Lixo de ID ~w~" + garbage.trashID + "~y~ removido~y~ com sucesso.", 3);

                Main.CreateMySqlCommand("UPDATE garbages SET `position_x` = " + garbage.trashPosition.X + ", `position_y` = " + garbage.trashPosition.Y + ", `position_z` = " + garbage.trashPosition.Z + " WHERE id = " + garbage.trashID + ";");
            }
        }
    }

    public static void OnEnterDynamicArea(Client player, ColShape shape)
    {
        if (player.GetData("ON_WORK") == true && AccountManage.GetPlayerJob(player) == 9)
        {
            if (shape == recliclagem)
            {
                if (player.IsInVehicle && player.GetData("IN_WORK_CAR") == true)
                {
                    if (player == player.Vehicle.GetData("DRIVER"))
                    {
                        if (NAPI.Data.GetEntityData(player.Vehicle, "garbage_inventory") > 0)
                        {
                            int inventory = NAPI.Data.GetEntityData(player.Vehicle, "garbage_inventory");


                            var payment = Convert.ToInt32((NAPI.Data.GetEntityData(player.Vehicle, "garbage_inventory") * PAYMENT_PER_PIN_BAG) * Main_Job.Payday_Job_Multipler);

                            Main.GivePlayerMoney(player, payment);
                            Notify.Send(player, NotifyType.Success, NotifyPosition.BottomCenter, $"Sie haben $" + payment + " bekommen!", 5000);
                            player.ResetData("garbage_inventory_full");
                            NAPI.Data.SetEntityData(player.Vehicle, "garbage_inventory", 0);
                        }
                    }
                }
            }
            else
            {
                int index = 0;
                foreach (var garbage in trash_list)
                {
                    if (shape == garbage.trashArea)
                    {

                        player.TriggerEvent("Notify", "~b~Drücke ~c~[ ~b~E~c~ ]~w~");

                        player.SetData("garbage_id", index);
                        return;
                    }
                    index++;
                }
            }
        }
    }

    public static void OnPlayerExitVehicleHandler(Client player, Vehicle vehicle)
    {
        if (player.GetData("ON_WORK") == true && AccountManage.GetPlayerJob(player) == 9)
        {

            foreach (var garbage in trash_list)
            {
                if (Main.IsInRangeOfPoint(player.Position, garbage.trashPosition, 30.0f))
                {
                    player.TriggerEvent("Notify", "Nimm den ~y~ Müll ~w~ und lege ihn in deinen Truck.");
                    return;
                }
            }

        }
    }

    public static void OnLeaveDynamicArea(Client player, ColShape shape)
    {
        int index = 0;
        foreach (var garbage in trash_list)
        {
            if (shape == garbage.trashArea && player.GetData("ON_WORK") == true && AccountManage.GetPlayerJob(player) == 9)
            {
                player.SetData("garbage_id", -1);
                return;
            }
            index++;
        }
    }

    public static void PlayerPressKeyE(Client player)
    {
        if (player.GetData("player_garbage_attach") == true && player.GetData("ON_WORK") == true && AccountManage.GetPlayerJob(player) == 9)
        {
            Entity veh = Utils.GetClosestVehicle(player, 7.0f);

            if (NAPI.Entity.DoesEntityExist(veh))
            {
                if (NAPI.Data.HasEntityData(veh, "TYPE"))
                {
                    if (NAPI.Data.GetEntityData(veh, "TYPE") == "TRASHCOLLECTOR" && NAPI.Data.GetEntityData(veh, "DRIVER") == player && NAPI.Data.GetEntityData(veh, "garbage_inventory") < LIMIT_GARBAGE_INVENTORY)
                    {
                        if (player.HasData("WORKOBJECT"))
                        {
                            BasicSync.DetachObject(player);
                            player.ResetData("WORKOBJECT");
                        }

                        player.SetData("player_garbage_attach", false);
                        player.StopAnimation();

                        NAPI.Data.SetEntityData(veh, "garbage_inventory", NAPI.Data.GetEntityData(veh, "garbage_inventory") + 1);


                        player.TriggerEvent("Notify", "~b~Du legst ~y~" + NAPI.Data.GetEntityData(veh, "garbage_inventory")+ "/"+ LIMIT_GARBAGE_INVENTORY + "~w~ Müllsäcke in Ihrem LKW.");

                        if(NAPI.Data.GetEntityData(veh, "garbage_inventory") == LIMIT_GARBAGE_INVENTORY)
                        {
                            player.SetData("garbage_inventory_full", true);
                            Main.SendInfoMessage(player, "Ihr LKW ist voll. Bringen Sie den LKW zum Entladepunkt, um Ihre Zahlung zu erhalten.");
                            player.TriggerEvent("gps_set_loc", 1262.642f, -1983.434f);

                            player.TriggerEvent("Notify", "~b~Ihr LKW ist voll. Bringen Sie den LKW zum Entladepunkt, um Ihre Zahlung zu erhalten.");

                        }
                    }
                }
            }
            return;
        }

        if (player.GetData("garbage_id") != -1 && player.GetData("player_garbage_attach") == false && player.GetData("ON_WORK") ==true && AccountManage.GetPlayerJob(player) == 9)
        {

            int index = player.GetData("garbage_id");

            if (trash_list[index].trashStatus == 0)
            {

                if(player.HasData("garbage_inventory_full"))
                {
                    if(player.GetData("garbage_inventory_full") == true)
                    {
                        
                        return;
                    }
                }

                var players = NAPI.Pools.GetAllPlayers();
                foreach (var target in players)
                {
                    if (target.GetData("status") == true && target.GetData("ON_WORK") == true && AccountManage.GetPlayerJob(target) == 9)
                    {
                        target.TriggerEvent("blip_remove", "Lixo #" + trash_list[index].trashID + "");
                    }
                }

                NAPI.ColShape.DeleteColShape(trash_list[index].trashArea);
                NAPI.Entity.DeleteEntity(trash_list[index].trashHandle);

                //GTANetworkAPI.Object

                player.SetData("garbage_id", -1);

                trash_list[index].trashStatus = 1;


                NAPI.Player.PlayPlayerAnimation(player, (int)(Main.AnimationFlags.Loop | Main.AnimationFlags.OnlyAnimateUpperBody | Main.AnimationFlags.AllowPlayerControl), "missfbi4prepp1", "idle");

                player.SetData("player_garbage_attach", true);


                if (!player.HasData("WORKOBJECT"))
                {
                    BasicSync.AttachObjectToPlayer(player, NAPI.Util.GetHashKey("ng_proc_binbag_01a"), 28422, new Vector3(0, 0.05, -0.04), new Vector3(0, 8, 0));
                    player.SetData("WORKOBJECT", true);
                }


                Main.DisplaySubtitle(player, "Nehmen Sie es auf die Rückseite des Lastwagens und drücken Sie ~c~E ~w~, um es zu recyceln.", 3);

                TimerEx.SetTimer(() => {
                    if (trash_list[index].trashStatus != 0)
                    {


                        trash_list[index].trashHandle = NAPI.Object.CreateObject(-1998455445, new Vector3(trash_list[index].trashPosition.X, trash_list[index].trashPosition.Y, trash_list[index].trashPosition.Z - 0.2f), new Vector3(), 0);
                        trash_list[index].trashArea = NAPI.ColShape.CreateCylinderColShape(trash_list[index].trashPosition, 1.0f, 1.0f);
                        trash_list[index].trashStatus = 0;

                        var players_2 = NAPI.Pools.GetAllPlayers();
                        foreach (var target in players_2)
                        {
                            if (target.GetData("status") == true && target.GetData("ON_WORK") == true && AccountManage.GetPlayerJob(target) == 9)
                            {
                                target.TriggerEvent("blip_remove", "Lixo #" + trash_list[index].trashID + "");
                                target.TriggerEvent("blip_create_ext", "Lixo #" + trash_list[index].trashID + "", trash_list[index].trashPosition, 2, 0.80f, 0);
                                //target.TriggerEvent("blip_range", "Lixo #" + trash_list[index].trashID + "", true);
                            }
                        }
                    }

 
                }, 15 * 60000, 1);



                return;
            }
        }
    }

    public static void ModalConfirm(Client player, string response)
    {
        if (response == "TRASHCOLLECT_RENT") collectorRent(player);
    }

    public static void ModalCancel(Client player, string response)
    {
        if (response == "TRASHCOLLECT_RENT") if (player.IsInVehicle) player.WarpOutOfVehicle();
    }

}

