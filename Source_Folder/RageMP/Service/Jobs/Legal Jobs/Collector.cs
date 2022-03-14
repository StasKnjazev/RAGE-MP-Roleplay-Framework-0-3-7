using DerStr1k3r.Core;
using DerStr1k3r.SDK;
using GTANetworkAPI;
using System;
using System.Collections.Generic;
using System.Text;


class Collector : Script
{
    private static nLog Log = new nLog("Collector");
    private static int checkpointPayment = 7;

    private static Vector3 TakeMoneyPos = new Vector3(915.9069, -1265.255, 24.50912);


    public static Dictionary<int, ColShape> ATMCols = new Dictionary<int, ColShape>();

    #region ATMs List
    public static List<Vector3> ATMs = new List<Vector3>
        {
            new Vector3(-30.28312, -723.7054, 43.10828),
            new Vector3(-846.4784, -340.7381, 37.56028),
            new Vector3(-30.28312, -723.7054, 43.10828),
            new Vector3(-57.79301, -92.57375, 56.65908),
            new Vector3(-203.8796, -861.4044, 29.14762),
            new Vector3(-301.6998, -830.0975, 31.29726),
            new Vector3(-1315.741, -834.8119, 15.84172),
            new Vector3(-526.7958, -1222.796, 17.33497),
            new Vector3(-165.068, 232.6937, 93.80193),
            new Vector3(147.585, -1035.683, 28.22313),
            new Vector3(-2072.433, -317.1329, 12.19597),
            new Vector3(-2975.008, 380.1415, 13.87914),
            new Vector3(112.6747, -819.3305, 30.21771),
            new Vector3(111.1934, -775.319, 30.31857),
            new Vector3(-3043.924, 594.6759, 6.616974),
            new Vector3(-3241.165, 997.4967, 11.4304),
            new Vector3(-254.3221, -692.4096, 32.49045),
            new Vector3(-256.154, -716.0692, 32.39723),
            new Vector3(-258.849, -723.3128, 32.36183),
            new Vector3(-537.8723, -854.4181, 28.16625),
            new Vector3(-386.8388, 6046.073, 30.38172),
            new Vector3(155.811, 6642.846, 30.48126),
            new Vector3(-2958.9, 487.8209, 14.34391),
            new Vector3(-594.6927, -1161.374, 21.20427),
            new Vector3(-282.9406, 6226.058, 30.37295),
            new Vector3(-3144.312, 1127.521, 19.73535),
            new Vector3(1167.063, -456.2611, 65.6659),
            new Vector3(1138.276, -469.0832, 65.60734),
            new Vector3(-97.33072, 6455.452, 30.34733),
            new Vector3(-821.5346, -1081.945, 10.01243),
            new Vector3(527.2645, -161.3371, 55.95051),
            new Vector3(-1091.597, 2708.577, 17.82036),
            new Vector3(158.4433, 234.1823, 105.5114),
            new Vector3(1171.491, 2702.544, 37.05545),
            new Vector3(1174.94, 2706.804, 36.97408),
            new Vector3(-2294.625, 356.5286, 173.4816),
            new Vector3(-56.88515, -1752.214, 28.30102),
            new Vector3(2564.523, 2584.744, 36.96311),
            new Vector3(2558.747, 350.9788, 107.5015),
            new Vector3(33.25563, -1348.147, 28.37702),
            new Vector3(1822.76, 3683.133, 33.15678),
            new Vector3(1703.047, 4933.534, 40.94364),
            new Vector3(1686.842, 4815.943, 40.88822),
            new Vector3(89.62029, 2.412876, 67.18955),
            new Vector3(-1410.304, -98.57402, 51.31698),
            new Vector3(288.7548, -1282.287, 28.52028),
            new Vector3(-1212.692, -330.7367, 36.66656),
            new Vector3(-1205.556, -325.066, 36.73424),
            new Vector3(-611.844, -704.7563, 30.11593),
            new Vector3(-867.6541, -186.0634, 36.72196),
            new Vector3(289.0122, -1256.787, 28.32075),
            new Vector3(1968.167, 3743.618, 31.22374),
            new Vector3(-1305.292, -706.3788, 24.20243),
            new Vector3(-1570.267, -546.7006, 33.83642),
            new Vector3(1701.183, 6426.415, 31.64404),
            new Vector3(-1430.069, -211.1082, 45.37187),
            new Vector3(-1416.06, -212.0282, 45.38037),
            new Vector3(-1109.778, -1690.661, 3.255033),
            new Vector3(237.3561, 217.8394, 105.1667), // 58 в мэрии
        };
    #endregion ATMs List


    public static Vector3 GetNearestATM(Client player)
    {
        Vector3 nearesetATM = ATMs[0];
        foreach (var v in ATMs)
        {
            if (v == new Vector3(237.3785, 217.7914, 106.2868)) continue;
            if (player.Position.DistanceTo(v) < player.Position.DistanceTo(nearesetATM))
                nearesetATM = v;
        }
        return nearesetATM;
    }


    [ServerEvent(Event.ResourceStart)]
    public void Event_ResourceStart()
    {
        try
        {

            Log.Write("Loading ATMs...");
            for (int i = 0; i < ATMs.Count; i++)
            {
                if (i != 58) NAPI.Blip.CreateBlip(500, ATMs[i], 0.35f, 27, "ATM", shortRange: true, dimension: 0);
                ATMCols.Add(i, NAPI.ColShape.CreateCylinderColShape(ATMs[i], 1, 2, 0));
                ATMCols[i].SetData("NUMBER", i);
                ATMCols[i].OnEntityEnterColShape += (s, e) =>
                {
                    try
                    {
                        e.SetData("INTERACTIONCHECK", 13);
                        Collector.CollectorEnterATM(e, s);
                    }
                    catch (Exception ex) { Log.Write("ATMCols.OnEntityEnterColShape: " + ex.Message, nLog.Type.Error); }
                };
                ATMCols[i].OnEntityExitColShape += (s, e) =>
                {
                    try
                    {
                        e.SetData("INTERACTIONCHECK", 0);
                    }
                    catch (Exception ex) { Log.Write("ATMCols.OnEntityExitrColShape: " + ex.Message, nLog.Type.Error); }
                };
            }


            var col = NAPI.ColShape.CreateCylinderColShape(TakeMoneyPos, 1, 3, 0);
            col.OnEntityEnterColShape += (s, e) =>
            {
                try
                {
                    e.SetData("INTERACTIONCHECK", 45);
                }
                catch (Exception ex) { Log.Write("col.OnEntityEnterColShape: " + ex.Message, nLog.Type.Error); }
            };
            col.OnEntityExitColShape += (s, e) =>
            {
                try
                {
                    e.SetData("INTERACTIONCHECK", 0);
                }
                catch (Exception ex) { Log.Write("col.OnEntityExitColShape: " + ex.Message, nLog.Type.Error); }
            };
            NAPI.Marker.CreateMarker(1, TakeMoneyPos - new Vector3(0, 0, 0.7), new Vector3(), new Vector3(), 1, new Color(255, 255, 255, 220), false, 0);
            NAPI.TextLabel.CreateTextLabel("~g~Drücke E", TakeMoneyPos + new Vector3(0, 0, 0.3), 30f, 0.4f, 0, new Color(255, 255, 255), true, 0);
        }
        catch (Exception e) { Log.Write("ResourceStart: " + e.Message, nLog.Type.Error); }
    }


    public static void collectorCarsSpawner()
    {

        Main_VehicleManage.CreateVehicle(5, VehicleHash.Riot, new Vector3(46.34436, -659.0676, 31.28481), new Vector3(-0.03904254, -0.1468035, 69.08002), 1 ,111, "COLLECTOR-30", "COLLECTOR");
        Main_VehicleManage.CreateVehicle(5, VehicleHash.Riot, new Vector3(48.79223, -652.0869, 31.28405), new Vector3(0.003817022, -0.04563505, 70.56702), 1 ,111, "COLLECTOR-30", "COLLECTOR");
        Main_VehicleManage.CreateVehicle(5, VehicleHash.Riot, new Vector3(51.69525, -644.9403, 31.28491), new Vector3(0.06578649, -0.1677786, 69.01617), 1 ,111, "COLLECTOR-30", "COLLECTOR");
        Main_VehicleManage.CreateVehicle(5, VehicleHash.Riot, new Vector3(54.48402, -638.1829, 31.32303), new Vector3(-0.2784068, 0.5629021, 70.30219), 1 ,111, "COLLECTOR-30", "COLLECTOR");
        Main_VehicleManage.CreateVehicle(5, VehicleHash.Riot, new Vector3(27.48282, -593.3008, 31.28183), new Vector3(0.02321184, -0.006188876, 161.386), 1 ,111, "COLLECTOR-30", "COLLECTOR");
        Main_VehicleManage.CreateVehicle(5, VehicleHash.Riot, new Vector3(34.56824, -595.5771, 31.28432), new Vector3(0.3496795, 0.3242176, 159.6118), 1 ,111, "COLLECTOR-30", "COLLECTOR");
        Main_VehicleManage.CreateVehicle(5, VehicleHash.Riot, new Vector3(41.53753, -598.2595, 31.28321), new Vector3(0.09196534, -0.143261, 159.9869), 1 ,111, "COLLECTOR-30", "COLLECTOR");
        Main_VehicleManage.CreateVehicle(5, VehicleHash.Riot, new Vector3(48.44036, -600.9376, 31.28373), new Vector3(0.2313322, 0.08784432, 159.8286), 1 ,111, "COLLECTOR-30", "COLLECTOR");
        Main_VehicleManage.CreateVehicle(5, VehicleHash.Riot, new Vector3(69.51797, -596.3568, 31.283), new Vector3(-0.001108355, -0.07324918, 68.99048), 1 ,111, "COLLECTOR-30", "COLLECTOR");

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
            NAPI.Data.SetEntityData(veh, "WORK", 7);
            NAPI.Data.SetEntityData(veh, "TYPE", "COLLECTOR");
            NAPI.Data.SetEntityData(veh, "NUMBER", i);
            NAPI.Data.SetEntityData(veh, "ON_WORK", false);
            NAPI.Data.SetEntityData(veh, "DRIVER", null);
            //Core.VehicleStreaming.SetEngineState(veh, false);
            VehicleStreaming.SetLockStatus(veh, false);
            //veh.SetSharedData("PETROL", VehicleManager.VehicleTank[veh.Class]);
        }
        catch (Exception e) { Log.Write("respawnCar: " + e.Message, nLog.Type.Error); }
    }

    [ServerEvent(Event.PlayerEnterVehicle)]
    public void onPlayerEnterVehicleHandler(Client player, Vehicle vehicle, sbyte seatid)
    {
        try
        {
            if (NAPI.Data.GetEntityData(vehicle, "TYPE") != "COLLECTOR" || player.VehicleSeat != -1) return;
            if (Main_Job.GetPlayerJob(player) == 4)
            {
                if (player.HasData("WORKOBJECT"))
                {
                    BasicSync.DetachObject(player);
                    player.ResetData("WORKOBJECT");
                }
                if (!NAPI.Data.GetEntityData(vehicle, "ON_WORK"))
                {
                    if (NAPI.Data.GetEntityData(player, "WORK") == null)
                    {
                        if (Main.GetPlayerMoney(player) >= 100)
                        {

                            InteractMenu.ShowModal(player, "COLLECTOR_RENT", "Starke Autoarbeit", "Möchten Sie mit der Arbeit beginnen und einen Transport für 100 US-Dollar mieten?", "Ja", "Nein");


                        }
                        else
                        {
                            Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"Es fehlt " + (100 - Main.GetPlayerMoney(player)) + "$ für die Anmietung des Fahrzeugs", 5000);
                            //VehicleManager.WarpPlayerOutOfVehicle(player);
                            player.WarpOutOfVehicle();
                        }
                    }
                    else if (NAPI.Data.GetEntityData(player, "WORK") == vehicle)
                        NAPI.Data.SetEntityData(player, "IN_WORK_CAR", true);
                }
                else
                {
                    if (NAPI.Data.GetEntityData(player, "WORK") != vehicle)
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"Dieses Auto ist beschäftigt", 5000);
                        player.WarpOutOfVehicle();
                    }
                    else NAPI.Data.SetEntityData(player, "IN_WORK_CAR", true);
                }
            }
            else
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"Sie arbeiten nicht als Sammler. Sie können sich dem Job im Rathaus anschließen", 5000);
                player.WarpOutOfVehicle();
            }
        }
        catch (Exception e) { Log.Write("PlayerEnterVehicle: " + e.Message, nLog.Type.Error); }
    }

    [ServerEvent(Event.PlayerExitVehicle)]
    public void onPlayerExitVehicleHandler(Client player, Vehicle vehicle)
    {
        try
        {
            if (NAPI.Data.GetEntityData(vehicle, "TYPE") == "COLLECTOR" &&
            Main_Job.GetPlayerJob(player) == 4 &&
            NAPI.Data.GetEntityData(player, "ON_WORK") &&
            NAPI.Data.GetEntityData(player, "WORK") == vehicle)
            {
                if (!player.HasData("WORKOBJECT") && player.GetData("COLLECTOR_BAGS") > 0)
                {
                    BasicSync.AttachObjectToPlayer(player, NAPI.Util.GetHashKey("prop_money_bag_01"), 18905, new Vector3(0.55, 0.02, 0), new Vector3(0, -90, 0));
                    player.SetData("WORKOBJECT", true);
                }

   


                Notify.Send(player, NotifyType.Warning, NotifyPosition.BottomCenter, $"Wenn Sie nicht innerhalb von 3 Minuten ins Fahrzeug zurückkehren, dann endet der Arbeitstag.", 5000);
                NAPI.Data.SetEntityData(player, "IN_WORK_CAR", false);
                if (player.HasData("WORK_CAR_EXIT_TIMER"))
                {
                    //Main.StopT(NAPI.Data.GetEntityData(player, "WORK_CAR_EXIT_TIMER"), "timer_13");
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
                //NAPI.Data.SetEntityData(player, "WORK_CAR_EXIT_TIMER", Main.StartT(1000, 1000, (o) => timer_playerExitWorkVehicle(player, vehicle), "COL_EXIT_CAR_TIMER"));
                //NAPI.Data.SetEntityData(player, "WORK_CAR_EXIT_TIMER", Timers.StartTask(1000, () => timer_playerExitWorkVehicle(player, vehicle)));

                player.SetData("WORK_CAR_EXIT_TIMER", TimerEx.SetTimer(() => timer_playerExitWorkVehicle(player, vehicle), 1000, 0));

            }
        }
        catch (Exception e) { Log.Write("PlayerExitVehicle: " + e.Message, nLog.Type.Error); }
    }

    public static void Event_PlayerDeath(Client player, Client entityKiller, uint weapon)
    {
        try
        {
            if (!player.GetData("status")) return;
            if (Main_Job.GetPlayerJob(player) ==4 && player.GetData("ON_WORK"))
            {
                var vehicle = player.GetData("WORK");

                respawnCar(vehicle);

                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du hast den Arbeitstag beendet.", 5000);
                NAPI.Data.SetEntityData(player, "PAYMENT", 0);

                NAPI.Data.SetEntityData(player, "ON_WORK", false);
                NAPI.Data.SetEntityData(player, "WORK", null);
                Trigger.ClientEvent(player, "deleteCheckpoint", 16, 0);
                Trigger.ClientEvent(player, "deleteWorkBlip");
                Main.UpdatePlayerClothes(player);
                if (player.HasData("WORK_CAR_EXIT_TIMER"))
                {
                    //Main.StopT(NAPI.Data.GetEntityData(player, "WORK_CAR_EXIT_TIMER"), "timer_14");
                    //Timers.Stop(NAPI.Data.GetEntityData(player, "WORK_CAR_EXIT_TIMER"));
                    try
                    {
                        NAPI.Data.GetEntityData(player, "WORK_CAR_EXIT_TIMER").Kill();
                    }
                    catch
                    {

                    }
                    NAPI.Data.ResetEntityData(player, "WORK_CAR_EXIT_TIMER");
                }
            }
            if (player.HasData("WORKOBJECT"))
            {
                BasicSync.DetachObject(player);
                player.ResetData("WORKOBJECT");
            }
        }
        catch (Exception e) { Log.Write("PlayerDeath: " + e.Message, nLog.Type.Error); }
    }

    public static void Event_PlayerDisconnected(Client player, DisconnectionType type, string reason)
    {
        try
        {
            if (Main_Job.GetPlayerJob(player) == 4&& player.GetData("ON_WORK"))
            {
                var vehicle = player.GetData("WORK");

                respawnCar(vehicle);
            }
            if (player.HasData("WORKOBJECT"))
            {
                BasicSync.DetachObject(player);
                player.ResetData("WORKOBJECT");
            }
        }
        catch (Exception e) { Log.Write("PlayerDisconnected: " + e.Message, nLog.Type.Error); }
    }

    private void timer_playerExitWorkVehicle(Client player, Vehicle vehicle)
    {
        NAPI.Task.Run(() =>
        {
            try
            {
                if (!player.HasData("WORK_CAR_EXIT_TIMER")) return;
                if (NAPI.Data.GetEntityData(player, "IN_WORK_CAR"))
                {
                        //                    Main.StopT(NAPI.Data.GetEntityData(player, "WORK_CAR_EXIT_TIMER"), "timer_16");
                        //Timers.Stop(NAPI.Data.GetEntityData(player, "WORK_CAR_EXIT_TIMER"));
                        try
                    {
                        NAPI.Data.GetEntityData(player, "WORK_CAR_EXIT_TIMER").Kill();
                    }
                    catch
                    {

                    }
                    NAPI.Data.ResetEntityData(player, "WORK_CAR_EXIT_TIMER");
                    Log.Debug("Player exit work vehicle timer was stoped");
                    return;
                }
                if (NAPI.Data.GetEntityData(player, "CAR_EXIT_TIMER_COUNT") > 180)
                {
                    respawnCar(vehicle);

                    Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du hast den Arbeitstag beendet.", 5000);
                    NAPI.Data.SetEntityData(player, "PAYMENT", 0);

                    NAPI.Data.SetEntityData(player, "ON_WORK", false);
                    NAPI.Data.SetEntityData(player, "WORK", null);
                    NAPI.ClientEvent.TriggerClientEvent(player, "deleteCheckpoint", 16, 0);
                    NAPI.ClientEvent.TriggerClientEvent(player, "deleteWorkBlip");
                        //Main.StopT(NAPI.Data.GetEntityData(player, "WORK_CAR_EXIT_TIMER"), "timer_17");
                        //Timers.Stop(NAPI.Data.GetEntityData(player, "WORK_CAR_EXIT_TIMER"));
                        try
                    {
                        NAPI.Data.GetEntityData(player, "WORK_CAR_EXIT_TIMER").Kill();
                    }
                    catch
                    {

                    }
                    NAPI.Data.ResetEntityData(player, "WORK_CAR_EXIT_TIMER");
                    Main.UpdatePlayerClothes(player);

                    if (player.HasData("WORKOBJECT"))
                    {
                        BasicSync.DetachObject(player);
                        player.ResetData("WORKOBJECT");
                    }
                    return;
                }
                NAPI.Data.SetEntityData(player, "CAR_EXIT_TIMER_COUNT", NAPI.Data.GetEntityData(player, "CAR_EXIT_TIMER_COUNT") + 1);

            }
            catch (Exception e)
            {
                Log.Write("Timer_PlayerExitWorkVehicle_Collector:\n" + e.ToString(), nLog.Type.Error);
            }
        });
    }

    public static void rentCar(Client player)
    {
        if (!NAPI.Player.IsPlayerInAnyVehicle(player) || player.VehicleSeat != -1 || player.Vehicle.GetData("TYPE") != "COLLECTOR") return;

        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie haben angefangen, als Geldtransporter zu arbeiten.", 5000);
        Main.GivePlayerMoney(player, -100);

        var vehicle = player.Vehicle;
        NAPI.Data.SetEntityData(player, "WORK", vehicle);
        player.SetData("ON_WORK", true);
        //Core.VehicleStreaming.SetEngineState(vehicle, false);
        NAPI.Data.SetEntityData(player, "IN_WORK_CAR", true);
        NAPI.Data.SetEntityData(vehicle, "DRIVER", player);
        player.SetData("COLLECTOR_BAGS", 15);
        player.SetData("W_LASTPOS", player.Position);
        player.SetData("W_LASTTIME", DateTime.Now);

        var x = Main_Job.rnd.Next(0, ATMs.Count - 1); ;
        while (x == 36 || ATMs[x].DistanceTo2D(player.Position) < 200)
            x = Main_Job.rnd.Next(0, ATMs.Count - 1);
        player.SetData("WORKCHECK", x);
        //if (player.GetData("IsMale"))
        //{

        //    player.SetAccessories(0, 63, 9);
        //    player.SetClothes(11, 132, 0);
        //    player.SetClothes(4, 33, 0);
        //    player.SetClothes(6, 24, 0);
        //    player.SetClothes(9, 1, 1);
        //    player.SetClothes(8, 129, 0);
        //    player.SetClothes(3, CharCreator.CharCreator.CorrectTorso[true][132], 0);
        //}
        //else
        //{
        //    player.SetAccessories(0, 63, 9);
        //    player.SetClothes(11, 129, 0);
        //    player.SetClothes(4, 32, 0);
        //    player.SetClothes(6, 24, 0);
        //    player.SetClothes(9, 6, 1);
        //    player.SetClothes(8, 159, 0);
        //    player.SetClothes(3, CharCreator.CharCreator.CorrectTorso[false][129], 0);
        //}
        Trigger.ClientEvent(player, "createCheckpoint", 16, 29, ATMs[x] + new Vector3(0, 0, 1.12), 1, 0, 220, 220, 0);
        Trigger.ClientEvent(player, "createWaypoint", ATMs[x].X, ATMs[x].Y);
        Trigger.ClientEvent(player, "createWorkBlip", ATMs[x]);
    }

    public static void CollectorTakeMoney(Client player)
    {
        if (player.IsInVehicle || Main_Job.GetPlayerJob(player) != 4|| !player.GetData("ON_WORK")) return;
        if (player.GetData("COLLECTOR_BAGS") != 0)
        {
            Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"Du hast noch ein Geldbeutel ({player.GetData("COLLECTOR_BAGS")})", 5000);
            return;
        }
        else
        {
            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du hast nun ein neuen Geldbeutel bekommen.", 5000);
            player.SetData("COLLECTOR_BAGS", 15);

            var x = Main_Job.rnd.Next(0, ATMs.Count - 1);
            while (x == 36 || ATMs[x].DistanceTo2D(player.Position) < 200)
                x = Main_Job.rnd.Next(0, ATMs.Count - 1);

            player.SetData("W_LASTPOS", player.Position);
            player.SetData("W_LASTTIME", DateTime.Now);
            player.SetData("WORKCHECK", x);
            Trigger.ClientEvent(player, "createCheckpoint", 16, 29, ATMs[x] + new Vector3(0, 0, 1.12), 1, 0, 220, 220, 0);
            Trigger.ClientEvent(player, "createWaypoint", ATMs[x].X, ATMs[x].Y);
            Trigger.ClientEvent(player, "createWorkBlip", ATMs[x]);
        }
    }
    public static void CollectorEnterATM(Client player, ColShape shape)
    {
        try
        {
            if (player.IsInVehicle || Main_Job.GetPlayerJob(player) != 4 || !player.GetData("ON_WORK")
                || player.GetData("COLLECTOR_BAGS") == 0 || player.GetData("WORKCHECK") != shape.GetData("NUMBER")) return;
            player.SetData("COLLECTOR_BAGS", player.GetData("COLLECTOR_BAGS") - 1);

            var coef = Convert.ToInt32(player.Position.DistanceTo2D(player.GetData("W_LASTPOS")) / 100);
            var payment = Convert.ToInt32(coef * checkpointPayment * Main_Job.Payday_Job_Multipler);

            /*DateTime lastTime = player.GetData("W_LASTTIME");
            if (DateTime.Now < lastTime.AddSeconds(coef * 2))
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, "O caixa eletrônico ainda está cheio. Tente novamente mais tarde", 5000);
                return;
            }*/

            //player.SetData("PAYMENT", player.GetData("PAYMENT") + payment);
            player.SetData("W_LASTPOS", player.Position);
            player.SetData("W_LASTTIME", DateTime.Now);
            Main.GivePlayerMoney(player, payment);
            Notify.Send(player, NotifyType.Success, NotifyPosition.BottomCenter, $"Sie haben $" + payment + " bekommen!", 5000);
            if (player.HasData("WORKOBJECT"))
            {
                BasicSync.DetachObject(player);
                player.ResetData("WORKOBJECT");
            }

            if (player.GetData("COLLECTOR_BAGS") == 0)
            {
                Notify.Send(player, NotifyType.Alert, NotifyPosition.BottomCenter, "Geh zurück zur Basis, um einen neuen Geldbeutel zu bekommen", 5000);
                Trigger.ClientEvent(player, "deleteWorkBlip");
                Trigger.ClientEvent(player, "createWaypoint", TakeMoneyPos.X, TakeMoneyPos.Y);
                Trigger.ClientEvent(player, "deleteCheckpoint", 16);
                return;
            }
            else
            {
                var x = Main_Job.rnd.Next(0, ATMs.Count - 1); ;
                while (x == 36 || x == player.GetData("WORKCHECK") || ATMs[x].DistanceTo2D(player.Position) < 200)
                    x = Main_Job.rnd.Next(0, ATMs.Count - 1);
                player.SetData("WORKCHECK", x);
                Trigger.ClientEvent(player, "createCheckpoint", 16, 29, ATMs[x] + new Vector3(0, 0, 1.12), 1, 0, 220, 220, 0);
                Trigger.ClientEvent(player, "createWaypoint", ATMs[x].X, ATMs[x].Y);
                Trigger.ClientEvent(player, "createWorkBlip", ATMs[x]);
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Gehe zum nächsten Geldautomaten.", 5000);
            }
        }
        catch { }
    }

    public static void ModalConfirm(Client player, string response)
    {
        if(response == "COLLECTOR_RENT")
        {
            rentCar(player);
        }
    }
    public static void ModalCancel(Client player, string response)
    {
        if (response == "COLLECTOR_RENT")
        {
            player.WarpOutOfVehicle();
        }
    }
}