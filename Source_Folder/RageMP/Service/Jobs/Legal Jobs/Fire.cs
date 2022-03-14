
/*

using System;
using System.Collections.Generic;
using GTANetworkAPI;

public class Fire : Script
{
    public static ColShape recliclagem;
    public static int fire_count = 0;
    public class FireEnum : IEquatable<FireEnum>

    {
        public int fireID { get; set; }
        public int mainID { get; set; }
        public Vector3 position { get; set; }
        public int maxChilderen { get; set; }
        public bool gasPowerd { get; set; }
        public int active { get; set; }

        public override int GetHashCode()
        {
            return fireID;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            FireEnum objAsPart = obj as FireEnum;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }

        public bool Equals(FireEnum other)
        {
            if (other == null) return false;
            return (this.fireID.Equals(other.fireID));
        }
    }

    public static List<FireEnum> fire_list = new List<FireEnum>();
    private static int checkpointPayment = 10;

    public static void FireInit()
    {
        recliclagem = NAPI.ColShape.CreateCylinderColShape(new Vector3(201.8772, -1655.53, 29.80323), 2.0f, 2.0f);

        NAPI.TextLabel.CreateTextLabel("- Reabastecimento -", new Vector3(201.8772, -1655.53, 29.80323 + 1.2), 27, 1.0f, 0, new Color(255, 255, 255, 255));
        NAPI.Marker.CreateMarker(23, new Vector3(201.8772, -1655.53, 29.80323 - 0.4f), new Vector3(), new Vector3(), 4.0f, new Color(255, 0, 0, 80));


        NetHandle temp_blip = temp_blip = NAPI.Blip.CreateBlip(new Vector3(201.8772, -1655.53, 29.80323));
        NAPI.Blip.SetBlipName(temp_blip, "Bombeiros");
        NAPI.Blip.SetBlipSprite(temp_blip, 436);
        NAPI.Blip.SetBlipColor(temp_blip, 59);
        //NAPI.Blip.SetBlipScale(temp_blip, 0.67f);
        NAPI.Blip.SetBlipShortRange(temp_blip, true);


        Random randomNum = new Random();
        foreach (var houses in HouseSystem.HouseInfo)
        {
            if (houses.exterior.X != 0 && houses.exterior.Y != 0 && houses.exterior.Z != 0)
            {
                int gas = randomNum.Next(1, 3);
                bool gasPowerd = true;
                if (gas > 1) gasPowerd = true;
                else
                {
                    gasPowerd = false;
                }


                int maxChildren = randomNum.Next(10, 25);
                fire_list.Add(new FireEnum { fireID = fire_count, mainID = fire_count, position = houses.exterior, gasPowerd = gasPowerd, maxChilderen = maxChildren, active = 0 });
                fire_count++;
            }
        }


        TimerEx.SetTimer(() =>
        {
            GenerateFire();
        }, 5 * 60000, 0);
    }

    //
    //
    //
    public static void collectorCarsSpawner()
    {


        Main_VehicleManage.CreateVehicle(11, VehicleHash.FireTruck, new Vector3(177.9624, -1655.995, 29.87215), new Vector3(0.03392329, 0.07998605, 231.9433), 27, 27, "FIRE-30", "FIRE");
        Main_VehicleManage.CreateVehicle(11, VehicleHash.FireTruck, new Vector3(200.2828, -1679.657, 29.87214), new Vector3(0.04731994, 0.09174795, 233.1795), 27, 27, "FIRE-30", "FIRE");
        Main_VehicleManage.CreateVehicle(11, VehicleHash.FireTruck, new Vector3(192.7256, -1660.75, 29.87301), new Vector3(0.04297122, -0.06653985, 137.0382), 27, 27, "FIRE-30", "FIRE");
        Main_VehicleManage.CreateVehicle(11, VehicleHash.FireTruck, new Vector3(195.7383, -1663.379, 29.87235), new Vector3(0.1209649, 0.006008659, 140.6834), 27, 27, "FIRE-30", "FIRE");
        Main_VehicleManage.CreateVehicle(11, VehicleHash.FireTruck, new Vector3(198.8796, -1665.881, 29.87672), new Vector3(-0.00881296, -0.1032709, 139.77), 27, 27, "FIRE-30", "FIRE");
        //Main_VehicleManage.CreateVehicle(11, VehicleHash.FireTruck, new Vector3(201.3953, -1656.482, 29.87212), new Vector3(-0.05846138, 0.05668167, 320.1445), 27, 27, "FIRE-30", "FIRE");



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
            NAPI.Data.SetEntityData(veh, "TYPE", "FIRE");
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
            if (Main_Job.GetPlayerJob(player) == 11 &&
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
            if (NAPI.Data.GetEntityData(vehicle, "TYPE") == "FIRE" &&
            Main_Job.GetPlayerJob(player) == 11 &&
            NAPI.Data.GetEntityData(player, "ON_WORK") &&
            NAPI.Data.GetEntityData(player, "WORK") == vehicle)
            {
  
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
            if (NAPI.Data.GetEntityData(vehicle, "TYPE") != "FIRE" || player.VehicleSeat != -1) return;

            if (Main_Job.GetPlayerJob(player) == 11)
            {
                if (!NAPI.Data.GetEntityData(vehicle, "ON_WORK"))
                {
                    if (NAPI.Data.GetEntityData(player, "WORK") == null)
                    {
                        InteractMenu.ShowModal(player, "FIRE_RENT", "Trabalho de Bombeiro", "Você deseja iniciar o trabalho de bombeiro?", "Sim, eu gostaria", "Não, obrigado");
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
                Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"Você não trabalha como coletor de lixo. Você pode se juntar ao emprego na prefeitura", 5000);
                player.WarpOutOfVehicle();
            }
        }
        catch (Exception e) { API.Shared.ConsoleOutput("PlayerEnterVehicle: " + e.Message); }
    }

    public static void collectorRent(Client player)
    {
        if (NAPI.Player.IsPlayerInAnyVehicle(player) || player.VehicleSeat != -1 || player.Vehicle.GetData("TYPE") != "FIRE")
        {
            var way = 0;
            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Você começou a trabalhar como coletor de lixo, siga os pontos de verificação", 5000);
            var vehicle = player.Vehicle;
            NAPI.Data.SetEntityData(player, "WORK", vehicle);
            //Core.VehicleStreaming.SetEngineState(vehicle, true);
            NAPI.Data.SetEntityData(player, "ON_WORK", true);
            NAPI.Data.SetEntityData(player, "IN_WORK_CAR", true);
            NAPI.Data.SetEntityData(vehicle, "ON_WORK", true);
            NAPI.Data.SetEntityData(player, "WORKWAY", way);
            NAPI.Data.SetEntityData(player, "WORKCHECK", 0);
            NAPI.Data.SetEntityData(vehicle, "DRIVER", player);
            player.SetData("W_LASTPOS", player.Position);

            SetFireOnMap(player);


           // player.ResetData("garbage_inventory_full");
            //NAPI.Data.SetEntityData(vehicle, "garbage_inventory", 0);
            //Outfits.SetUnisexOutfit(player, 64);
            //Garbage.SetGarbageBlipOnMap(player);
        }
        else
        {
            Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"Você deve estar em transporte", 5000);
        }
    }

    //
    //
    //
    [Command("fire")]
    public static void CMD_GENERATIRE(Client player) { GenerateFire(); }

    public static void GenerateFire()
    {
        Random randomNum = new Random();
        for (int i = 0; i < 10; i++)
        {
            int random = randomNum.Next(0, fire_list.Count);
            if (fire_list[random].position.X != 0 && fire_list[random].position.Y != 0 && fire_list[random].position.Z != 0 && fire_list[random].active == 0)
            {
                fire_list[random].active = 1;
                foreach (var player in API.Shared.GetAllPlayers())
                {
                    player.TriggerEvent("StartFire", random, fire_list[random].position.X, fire_list[random].position.Y, fire_list[random].position.Z, fire_list[random].maxChilderen, fire_list[random].gasPowerd, random);
                    SetFireOnMap(player);
                }
            }
        }
    }


    public static void SetFireOnMap(Client player)
    {

        foreach (var fire in fire_list)
        {
            if (fire.position.X != 0 && fire.position.Y != 0)
            {
                player.TriggerEvent("blip_remove", "Fire #" + fire.fireID + "");
            }
        }

        foreach (var fire in fire_list)
        {
            if (fire.position.X != 0 && fire.position.Y != 0 && fire.position.Z != 0 && fire.active == 1)
            {
                if (player.GetData("ON_WORK") == true && Main_Job.GetPlayerJob(player) == 11)
                {
                    player.TriggerEvent("blip_create_ext", "Fire #" + fire.fireID + "", fire.position, 75, 0.80f, 436);
                }
            }
        }
    }

    [RemoteEvent("fireHasBeenPutOut")]
    public static void fireHasBeenPutOut(Client player, int mainid, int fireid)
    {

        foreach (var fire in fire_list)
        {
            if (fire.fireID == fireid && mainid ==fire.mainID && fire.active == 1)
            {
                fire.active = 0;


                var coef = Convert.ToInt32(player.Position.DistanceTo2D(player.GetData("W_LASTPOS")) / 100);
                var payment = Convert.ToInt32(coef * checkpointPayment * Main_Job.Vip_Payment[VIP.GetPlayerVIP(player)] * Main_Job.Payday_Job_Multipler);

                Main.SendSuccessMessage(player, $"Você apagou um fogo com sucesso e adquiriu ${payment}");
                player.SetData("W_LASTPOS", player.Position);

                SetFireOnMap(player);

                player.TriggerEvent("StopFireByID", fire.mainID);

                break;
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
}
                }
            }
        }
    }


    public static void OnLeaveDynamicArea(Client player, ColShape shape)
    {

    }

 
    public static void ModalConfirm(Client player, string response)
    {
        if (response == "FIRE_RENT") collectorRent(player);
    }

    public static void ModalCancel(Client player, string response)
    {
        if (response == "FIRE_RENT") if (player.IsInVehicle) player.WarpOutOfVehicle();
    }

}

*/