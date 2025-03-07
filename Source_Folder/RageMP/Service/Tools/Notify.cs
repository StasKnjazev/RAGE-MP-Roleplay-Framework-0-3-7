﻿using GTANetworkAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace DerStr1k3r.SDK
{
    public enum NotifyType
    {
        Alert,
        Error,
        Success,
        Info,
        Warning
    }
    public enum NotifyPosition
    {
        Top,
        TopLeft,
        TopCenter,
        TopRight,
        Center,
        CenterLeft,
        CenterRight,
        Bottom,
        BottomLeft,
        BottomCenter,
        BottomRight
    }
    public static class Notify
    {
        public static void Send(Client client, NotifyType type, NotifyPosition pos, string msg, int time)
        {
            Trigger.ClientEvent(client, "notify", type, pos, msg, time);
            NAPI.Task.Run(() =>
            {
                client.TriggerEvent("Destroy_Phone_SMS_inc");
            }, delayTime: time);
        }
    }
}