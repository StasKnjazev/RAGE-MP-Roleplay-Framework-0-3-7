using System;
using System.Linq;
using System.Collections.Concurrent;
using GTANetworkAPI;

namespace DerStr1k3r.RemoteEventManager
{
    class RemoteEventManager : Script
    {
        static RemoteEventManager() { }
        public RemoteEventManager() { }

        public delegate void ServerEventTrigger(Client sender, params object[] arguments);
        private static ConcurrentDictionary<string, ServerEventTrigger> _ClientEvents = new ConcurrentDictionary<string, ServerEventTrigger>(StringComparer.InvariantCultureIgnoreCase);

        public static void RegisterClientEvent(string eventName, ServerEventTrigger serverFunction)
        {
            if (string.IsNullOrEmpty(eventName))
            {
                NAPI.Util.ConsoleOutput("[Error]: Eventname equals 'null'");
                return;
            }
            _ClientEvents[eventName] = serverFunction;
        }

        [RemoteEvent("RemoteEventTrigger")]
        public void RemoteEventTrigger(Client player, params object[] args)
        {
            if (args == null) return;

            var eventname = args[0].ToString();
            var arg_data = args.Skip(1).ToArray();

            if (!_ClientEvents.TryGetValue(eventname, out var handler))
            {
                NAPI.Util.ConsoleOutput("Unhandled ClientEvent: {0}", eventname);
                return;
            }
            handler.Invoke(player, arg_data);
        }
    }
}