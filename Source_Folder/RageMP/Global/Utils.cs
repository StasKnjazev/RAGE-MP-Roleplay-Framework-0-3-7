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


class Utils : Script
{

    public static void ClearChat(Client player)
    {

    }


    public static Vehicle GetClosestVehicle(Client sender, float distance = 1000.0f)
    {
        Vehicle handleReturned = NAPI.Data.GetEntityData(sender, Convert.ToString(distance));
        foreach (var veh in NAPI.Pools.GetAllVehicles())
        {
            Vector3 vehPos = NAPI.Entity.GetEntityPosition(veh);
            float distanceVehicleToPlayer = sender.Position.DistanceTo(vehPos);
            if (distanceVehicleToPlayer < distance)
            {
                distance = distanceVehicleToPlayer;
                handleReturned = veh;

            }
        }
        return handleReturned;
    }

    public static void CreateVehicleEx(VehicleHash model, Vector3 pos, Vector3 rot, int color1, int color2, int dimension = 0, bool respawnable = false)
    {
        var heading = 0f; // Car heading
        var myVeh1 = NAPI.Vehicle.CreateVehicle((uint)model, pos, heading, 0, 0);
        NAPI.Data.SetEntityData(myVeh1, "RESPAWNABLE", respawnable);
        NAPI.Data.SetEntityData(myVeh1, "SPAWN_POS", pos);
        NAPI.Data.SetEntityData(myVeh1, "SPAWN_ROT", rot.Z);
    }

    public static void SetPlayerPosition(Client player, Vector3 position, float rotation, bool in_vehicle = false)
    {
        if (in_vehicle == true)
        {
            if (player.IsInVehicle)
            {
                if (player.VehicleSeat == -1)
                {
                    NAPI.Entity.SetEntityPosition(player.Vehicle, position);
                    NAPI.Entity.SetEntityRotation(player.Vehicle, new Vector3(0, 0, rotation));
                    NAPI.Player.SetPlayerIntoVehicle(player, player.Vehicle, -1);
                }
            }
            else
            {
                NAPI.Entity.SetEntityPosition(player, position);
                NAPI.Entity.SetEntityRotation(player, new Vector3(0, 0, rotation));
            }
        }
        else
        {
            NAPI.Entity.SetEntityPosition(player, position);
            NAPI.Entity.SetEntityRotation(player, new Vector3(0, 0, rotation));
        }
    }

    public static void SetScreenEffectToPlayer(Client player, string effectType, int time)
    {
        player.TriggerEvent("ApplyScreenEffect", effectType, time);
    }

    public static void StopScreenEffectToPlayer(Client player, string effectType)
    {
        player.TriggerEvent("StopScreenEffect", effectType);
    }

    public static bool isRoleplayName(string name)
    {
        string pattern = "^([A-Z][a-z]+_[A-Z][a-z]+)$";
        return System.Text.RegularExpressions.Regex.IsMatch(name, pattern);
    }

    public static string RandomWords(int tamanho)
    {
        var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        var random = new Random();
        var result = new string(Enumerable.Repeat(chars, tamanho).Select(s => s[random.Next(s.Length)]).ToArray());
        return result;
    }

    public static string RandomNumbers(int tamanho)
    {
        var chars = "0123456789";
        var random = new Random();
        var result = new string(Enumerable.Repeat(chars, tamanho).Select(s => s[random.Next(s.Length)]).ToArray());
        return result;
    }
}
