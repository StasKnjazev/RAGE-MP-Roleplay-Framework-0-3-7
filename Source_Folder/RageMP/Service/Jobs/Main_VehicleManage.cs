using GTANetworkAPI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using DerStr1k3r.SDK;


class Main_VehicleManage : Script
{
    public class CarInfoEnum : IEquatable<CarInfoEnum>
    {
        public int id { get; set; }
        public int job_id { get; set; }
        public string Number { get; set; }
        public VehicleHash Model { get; set; }
        public Vector3 Position { get; set; }
        public Vector3 Rotation { get; set; }
        public int Color1 { get; set; }
        public int Color2 { get; set; }
        public int Price { get; set; }

        public void ResetData()
        {
            id = 0;
            job_id = 0;
            Number = null;
            Position = new Vector3(0, 0, 0);
            Rotation = new Vector3(0, 0, 0);
            Color1 = 0;
            Color2 = 0;
            Price = 0;

        }

        public override int GetHashCode()
        {
            return id;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            CarInfoEnum objAsPart = obj as CarInfoEnum;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }

        public bool Equals(CarInfoEnum other)
        {
            if (other == null) return false;
            return (this.id.Equals(other.id));
        }
    }


    public static List<CarInfoEnum> CarInfos = new List<CarInfoEnum>();

    public Main_VehicleManage()
    {

    
        for(int i = 0; i < 100; i++)
        {
            CarInfos.Add(new CarInfoEnum());
            CarInfos[i].ResetData();
            CarInfos[i].id = i;

        }


        Lawnmower.mowerCarsSpawner();
        Bus.busCarsSpawner();
        Collector.collectorCarsSpawner();
        Garbage.collectorCarsSpawner();
        Farm.collectorCarsSpawner();

        //Fire.collectorCarsSpawner();
    }

    public static void CreateVehicle(int jobid, VehicleHash model, Vector3 position, Vector3 rotation, int color1, int color2, string numberplate, string type)
    {
        foreach (var vehicle in CarInfos)
        {
    
            if (vehicle.Position.X == 0 && vehicle.Position.Y == 0)
            {

                vehicle.Position = position;
                vehicle.Rotation = rotation;
                vehicle.Color1 = color1;
                vehicle.Color2 = color2;
                vehicle.Number = numberplate;
                var veh = NAPI.Vehicle.CreateVehicle(model, position, rotation.Z, color1, color2, numberplate);
                NAPI.Data.SetEntityData(veh, "ACCESS", "WORK");
                NAPI.Data.SetEntityData(veh, "WORK", jobid);
                NAPI.Data.SetEntityData(veh, "TYPE", type);
                NAPI.Data.SetEntityData(veh, "NUMBER", vehicle.id);
                NAPI.Data.SetEntityData(veh, "ON_WORK", false);
                NAPI.Data.SetEntityData(veh, "DRIVER", null);
                Main.SetVehicleFuel(veh, 100.0);
                veh.SetSharedData("INTERACT", veh.Type);
                NAPI.Vehicle.SetVehicleEngineStatus(veh, false);
                break;
            }
        }
    }


    public static void respawnCar(Vehicle veh)
    {
        try
        {
            int i = NAPI.Data.GetEntityData(veh, "NUMBER");

            NAPI.Entity.SetEntityPosition(veh, CarInfos[i].Position);
            NAPI.Entity.SetEntityRotation(veh, CarInfos[i].Rotation);
            veh.Repair();
            NAPI.Data.SetEntityData(veh, "ACCESS", "WORK");
            NAPI.Data.SetEntityData(veh, "WORK", 3);
            NAPI.Data.SetEntityData(veh, "TYPE", "TAXI");
            NAPI.Data.SetEntityData(veh, "NUMBER", i);
            NAPI.Data.SetEntityData(veh, "DRIVER", null);
            NAPI.Data.SetEntityData(veh, "ON_WORK", false);

        }
        catch (Exception e) { API.Shared.ConsoleOutput($"respawnCar: " + e.Message, nLog.Type.Error); }
    }

    [ServerEvent(Event.PlayerExitVehicle)]
    public void onPlayerExitVehicleHandler(Client player, Vehicle vehicle)
    {
        try
        {
  

        }
        catch (Exception e) { API.Shared.ConsoleOutput("PlayerExitVehicle: " + e.Message, nLog.Type.Error); }
    }

    [Command("rwork")]
    public static void respawnAllCars(Client player)
    {
        if (AccountManage.GetPlayerAdmin(player) < adminCommands.COORDENADOR)
        {
            Main.SendErrorMessage(player, "Sie haben keine Berechtigung, diesen Befehl zu verwenden.");
            return;
        }

        List<Vehicle> all_vehicles = NAPI.Pools.GetAllVehicles();


        foreach (Vehicle vehicle in all_vehicles)
        {
            if (vehicle.Occupants.Count >= 1) continue;

            if (vehicle.GetData("ACCESS") == "WORK")
            {
                RespawnWorkCar(vehicle);
            }
    
        }
    }

    public static void RespawnWorkCar(Vehicle vehicle)
    {
        if (vehicle.GetData("ON_WORK")) return;

        var type = vehicle.GetData("TYPE");
        switch (type)
        {
            case "MOWER":
                Lawnmower.respawnCar(vehicle);
                break;
            case "BUS":
                Bus.respawnBusCar(vehicle);
                break;
            case "COLLECTOR":
                Collector.respawnCar(vehicle);
                break;
            case "TRASHCOLLECTOR":
                Garbage.respawnCar(vehicle);
                break;
        }
    }


}