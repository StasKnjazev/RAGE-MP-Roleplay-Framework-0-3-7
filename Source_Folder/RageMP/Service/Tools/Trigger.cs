using System.Threading;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using GTANetworkAPI;

public class Trigger : Script
{
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
}