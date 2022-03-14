using GTANetworkAPI;
using DerStr1k3r.SDK;
using System;
using System.Collections.Generic;
using System.Text;

namespace DerStr1k3r.GUI
{
    class Docs : Script
    {
        private static nLog Log = new nLog("Docs");
        [RemoteEvent("passport")]
        public static void Event_Passport(Client player, params object[] arguments)
        {
            try
            {
                Client to = (Client)arguments[0];
                Log.Debug(to.Name.ToString());
                Passport(player, to);
            } catch(Exception e)
            {
                Log.Write("EXCEPTION AT \"EVENT_PASSPORT\":\n" + e.ToString(), nLog.Type.Error);
            }
        }
        [RemoteEvent("licenses")]
        public static void Event_Licenses(Client player, params object[] arguments)
        {
            try
            {
                Client to = (Client)arguments[0];
                Licenses(player, to);
            } catch (Exception e)
            {
                Log.Write("EXCEPTION AT \"EVENT_LICENSES\":\n" + e.ToString(), nLog.Type.Error);
            }
        }

        public static void Passport(Client from, Client to)
        {
            Vector3 pos = to.Position;
            if (from.Position.DistanceTo(pos) > 2)
            {
                Notify.Send(from, NotifyType.Error, NotifyPosition.BottomCenter, "Der Spieler ist zu weit weg", 5000);
                return;
            }
            to.SetData("REQUEST", "acceptPass");
            to.SetData("IS_REQUESTED", true);
            Notify.Send(to, NotifyType.Warning, NotifyPosition.BottomCenter, $"Der Bürger ({from.Value}) will einen Reisepass vorzeigen. J/N - akzeptieren/ablehnen", 5000);
            NAPI.Data.SetEntityData(to, "DOCFROM", from);
        }
        public static void Licenses(Client from, Client to)
        {
            Vector3 pos = to.Position;
            if (from.Position.DistanceTo(pos) > 2)
            {
                Notify.Send(from, NotifyType.Error, NotifyPosition.BottomCenter, "Der Spieler ist zu weit weg", 5000);
                return;
            }
            to.SetData("REQUEST", "acceptLics");
            to.SetData("IS_REQUESTED", true);
            Notify.Send(to, NotifyType.Warning, NotifyPosition.BottomCenter, $"Der Bürger ({from.Value}) will seine Lizenzen zeigen. J/N - akzeptieren/ablehnen", 5000);
            NAPI.Data.SetEntityData(to, "DOCFROM", from);
        }
    }
}
