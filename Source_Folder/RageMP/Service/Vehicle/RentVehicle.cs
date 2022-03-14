using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTANetworkAPI;

class RentVehicle : Script
{
    public static int MAX_RENT_VEHICLES = 200;

    public class RentVehicleEnum : IEquatable<RentVehicleEnum>
    {
        public int id { get; set; }
        public int vehicle_ownedBy { get; set; }
        public bool vehicle_free { get; set; }
        public Vehicle vehicle_entity { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            RentVehicleEnum objAsPart = obj as RentVehicleEnum;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }
        public override int GetHashCode()
        {
            return id;
        }
        public bool Equals(RentVehicleEnum other)
        {
            if (other == null) return false;
            return (this.id.Equals(other.id));
        }
    }

    public static List<RentVehicleEnum> vehicle_rent_list = new List<RentVehicleEnum>();
    public static List<dynamic> vehicle_rent_available_list = new List<dynamic>();
    public static List<dynamic> Aluguel_Positions = new List<dynamic>();
    public static List<Vehicle> Aluguel_Vehicles = new List<Vehicle>();

    public static void RentVehicleInit()
    {
        for (int i = 0; i < MAX_RENT_VEHICLES; i++)
        {
            vehicle_rent_list.Add(new RentVehicleEnum() { vehicle_free = false, vehicle_ownedBy = -1 });

        }
        vehicle_rent_available_list.Add(new { vehicle_name = "Bmx", vehicle_price = 225 });
        vehicle_rent_available_list.Add(new { vehicle_name = "Cruiser", vehicle_price = 280 });
        vehicle_rent_available_list.Add(new { vehicle_name = "Fixter", vehicle_price = 330 });
        vehicle_rent_available_list.Add(new { vehicle_name = "TriBike", vehicle_price = 415 });
        vehicle_rent_available_list.Add(new { vehicle_name = "Scorcher", vehicle_price = 500 });

        Aluguel_Positions.Add(new { position = new Vector3(-1008.989, -2744.123, 13.75862), angle = 55.85358 });
        Aluguel_Positions.Add(new { position = new Vector3(-1056.915, -2716.998, 13.75665), angle = 72.63603 });
        Aluguel_Positions.Add(new { position = new Vector3(1750.467, 3290.738, 41.1074), angle = 55.02077 });
        Aluguel_Positions.Add(new { position = new Vector3(-683.1337, 5818.537, 17.33096), angle = 312.7073 });
        

        foreach (var aluguel in Aluguel_Positions)
        {
            NAPI.Marker.CreateMarker(27, aluguel.position - new Vector3(0, 0, 0.6f), new Vector3(), new Vector3(), 3.5f, new Color(110, 179, 70, 150));
            NAPI.Marker.CreateMarker(29, aluguel.position - new Vector3(0, 0, 0.5f), new Vector3(), new Vector3(), 1.0f, new Color(110, 179, 70, 150));
            NAPI.TextLabel.CreateTextLabel("- Fahrrad Verleih -", aluguel.position + new Vector3(0, 0, 0.2f), 15.0f, 0.9f, 4, new Color(110, 179, 70, 190));

            Blip temp_blip = NAPI.Blip.CreateBlip(aluguel.position);
            NAPI.Blip.SetBlipName(temp_blip, "Fahrrad Verleih");
            NAPI.Blip.SetBlipSprite(temp_blip, 153);
            NAPI.Blip.SetBlipColor(temp_blip, 25);
            NAPI.Blip.SetBlipScale(temp_blip, 0.6f);
            NAPI.Blip.SetBlipShortRange(temp_blip, true);
        }
    }

    public static String GetTimestamp(DateTime value)
    {
        return value.ToString("mmss");
    }

    public static void SelectMenuResponse(Client player, String callbackId, int selectedIndex, String objectName, String valueList)
    {
        if (callbackId == "RENT_VEHICLE_RESPONSE")
        {

            int item = selectedIndex;
            if (Main.GetPlayerMoney(player) < vehicle_rent_available_list[item].vehicle_price)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Sie haben nicht genug Geld, um dieses Fahrrad zu mieten.");
                return;
            }
            for (int b = 0; b < MAX_RENT_VEHICLES; b++)
            {
                if (vehicle_rent_list[b].vehicle_ownedBy == AccountManage.GetPlayerSQLID(player))
                {
                    if (vehicle_rent_list[b].vehicle_free == true)
                    {
                        vehicle_rent_list[b].vehicle_free = false;
                        vehicle_rent_list[b].vehicle_ownedBy = -1;
                        vehicle_rent_list[b].vehicle_entity.Delete();
                        vehicle_rent_list[b].vehicle_entity = null;
                    }
                }
            }

            for (int i = 0; i < MAX_RENT_VEHICLES; i++)
            {
                if (vehicle_rent_list[i].vehicle_free == false)
                {

                    vehicle_rent_list[i].vehicle_ownedBy = AccountManage.GetPlayerSQLID(player);
                    vehicle_rent_list[i].vehicle_free = true;

                    VehicleHash model = NAPI.Util.VehicleNameToModel(vehicle_rent_available_list[item].vehicle_name);

                    Vector3 position = new Vector3(-1008.989, -2744.123, 13.75862);
                    float heading = 59.61397f;

                    if (Main.IsInRangeOfPoint(player.Position, new Vector3(-1008.989, -2744.123, 13.75862), 100.0f))
                    {
                        Random rnd = new Random();
                        int random_spawns = rnd.Next(0, 2);

                        switch (random_spawns)
                        {
                            case 0: position = new Vector3(-1008.989, -2744.123, 13.75862); heading = 55.85358f; break;
                            case 1: position = new Vector3(-1008.989, -2744.123, 13.75862); heading = 55.85358f; break;
                            case 2: position = new Vector3(-1008.989, -2744.123, 13.75862); heading = 55.85358f; break;
                        }
                    }
                    else if (Main.IsInRangeOfPoint(player.Position, new Vector3(-1056.915, -2716.998, 13.75665), 100.0f))
                    {
                        Random rnd = new Random();
                        int random_spawns = rnd.Next(0, 3);

                        position = new Vector3(-1056.915, -2716.998, 13.75665);
                        heading = 336.9147f;

                        switch (random_spawns)
                        {
                            case 0: position = new Vector3(-1056.915, -2716.998, 13.75665); heading = 72.63603f; break;
                            case 1: position = new Vector3(-1056.915, -2716.998, 13.75665); heading = 72.63603f; break;
                            case 2: position = new Vector3(-1056.915, -2716.998, 13.75665); heading = 72.63603f; break;
                        }
                    }
                    else if (Main.IsInRangeOfPoint(player.Position, new Vector3(1750.467, 3290.738, 41.1074), 100.0f))
                    {
                        Random rnd = new Random();
                        int random_spawns = rnd.Next(0, 3);

                        position = new Vector3(1750.467, 3290.738, 41.1074);
                        heading = 55.02077f;

                        switch (random_spawns)
                        {
                            case 0: position = new Vector3(1750.467, 3290.738, 41.1074); heading = 55.02077f; break;
                            case 1: position = new Vector3(1750.467, 3290.738, 41.1074); heading = 55.02077f; break;
                            case 2: position = new Vector3(1750.467, 3290.738, 41.1074); heading = 55.02077f; break;
                        }
                    }
                    else if (Main.IsInRangeOfPoint(player.Position, new Vector3(-683.1337, 5818.537, 17.33096), 100.0f))
                    {
                        Random rnd = new Random();
                        int random_spawns = rnd.Next(0, 3);

                        position = new Vector3(-683.1337, 5818.537, 17.33096);
                        heading = 55.02077f;

                        switch (random_spawns)
                        {
                            case 0: position = new Vector3(-683.1337, 5818.537, 17.33096); heading = 312.7073f; break;
                            case 1: position = new Vector3(-683.1337, 5818.537, 17.33096); heading = 312.7073f; break;
                            case 2: position = new Vector3(-683.1337, 5818.537, 17.33096); heading = 312.7073f; break;
                        }
                    }

                    vehicle_rent_list[i].vehicle_entity = NAPI.Vehicle.CreateVehicle((uint)model, position, heading, 88, 88);
                    NAPI.Player.SetPlayerIntoVehicle(player, vehicle_rent_list[i].vehicle_entity, -1);

                    VehicleInventory.AddInventoryToVehicle(vehicle_rent_list[i].vehicle_entity, model);
                    Main.SetVehicleFuel(vehicle_rent_list[i].vehicle_entity, 100.0);
                    NAPI.Vehicle.SetVehicleEngineStatus(vehicle_rent_list[i].vehicle_entity, false);
                    NAPI.Vehicle.SetVehicleNumberPlate(vehicle_rent_list[i].vehicle_entity, "RENTED" + SecretService.GetTimestamp(DateTime.Now));
                    //NAPI.Vehicle.SetVehicleEnginePowerMultiplier(vehicle_rent_list[i].vehicle_entity, 10);

                    NAPI.Notification.SendNotificationToPlayer(player, "~g~[INFO]:~w~ Sie haben gemietet ein ~y~" + vehicle_rent_available_list[item].vehicle_name + "~w~ für ~g~$~g~" + vehicle_rent_available_list[item].vehicle_price + "~w~.");
                    Main.GivePlayerMoney(player, -vehicle_rent_available_list[item].vehicle_price);
                    return;
                }
            }
            NAPI.Notification.SendNotificationToPlayer(player, "Kein Fahrrad zu vermieten.");
        }
    }
}

