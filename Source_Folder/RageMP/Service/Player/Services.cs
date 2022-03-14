using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;
using Newtonsoft.Json;
using DerStr1k3r.Core;
using DerStr1k3r.SDK;
class Services : Script
{
    public class ServiceEnum : IEquatable<ServiceEnum>
    {
        public int id { get; set; }
        public Client caller { get; set; }
        public int active { get; set; }
        public int faction { get; set; }
        public int job { get; set; }
        public DateTime dateTime { get; set; }
        public Vector3 position { get; set; }

        public override int GetHashCode()
        {
            return id;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            ServiceEnum objAsPart = obj as ServiceEnum;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }

        public bool Equals(ServiceEnum other)
        {
            if (other == null) return false;
            return (this.id.Equals(other.id));
        }
    }

    public static List<ServiceEnum> service_system = new List<ServiceEnum>();

    public Services()
    {
        for(int i = 0; i < 100; i++)
        {
            service_system.Add(new ServiceEnum { id = i, caller = null, active = 0, faction = 0, job = 0, position = new Vector3()});
        }
    }

    public static void Remove_Service(Client player)
    {
        foreach (var service in service_system)
        {
            if(service.active == 1 && service.caller == player)
            {
                service.active = 0;
                service.faction = 0;
                service.job = 0;
                service.position = new Vector3();
                service.caller = null;
            }
        }
    }

    public static void Call_Service(Client player, int number)
    {
        foreach(var service in service_system)
        {
            if(service.caller == null && service.active == 0)
            {
                player.TriggerEvent("service_accept", number);

                service.caller = player;
                service.active = 1;
                service.position = player.Position;
                service.dateTime = DateTime.Now;

                if (number == 911)
                {
                    service.job = 0;
                    service.faction = 1;
                    foreach (var police in NAPI.Pools.GetAllPlayers())
                    {
                        if (police.GetData("status") == true && FactionManage.GetPlayerGroupType(police) == 1)
                        {
                            police.TriggerEvent("Notification.SendPictureNotification", "Notruf", "Neuer Anruf", $"Tel:~g~ " + cellphoneSystem.GetPlayerNumber(player) + ".~n~~n~~c~(( F6 zu akzeptieren))");
                            police.TriggerEvent("blip_create_ext", "Neuer Anruf", player.Position, 73, 0.70f, 0);
                            NAPI.Notification.SendNotificationToPlayer(player, "Dein Dispatch wurde gesendet und du kannst nun auflegen.");
                            System.Threading.Tasks.Task.Run(() =>
                            {
                                NAPI.Task.Run(() =>
                                {
                                    police.TriggerEvent("blip_router_visible", "Neuer Anruf", true, 73);
                                    police.TriggerEvent("blip_remove", "Neuer Anruf");
                                }, delayTime: 300000); // delay time in ms
                            });
                        }
                    }
                }
                else if(number == 912)
                {
                    service.job = 0;
                    service.faction = 2;
                    foreach (var police in NAPI.Pools.GetAllPlayers())
                    {
                        if (police.GetData("status") == true && FactionManage.GetPlayerGroupType(police) == 2)
                        {
                            police.TriggerEvent("Notification.SendPictureNotification", "Notruf", "Neuer Anruf", $"Tel:~g~ " + cellphoneSystem.GetPlayerNumber(player) + ".~n~~n~~c~(( F6 zu akzeptieren))");
                            police.TriggerEvent("blip_create_ext", "Neuer Anruf", player.Position, 73, 0.70f, 0);
                            NAPI.Notification.SendNotificationToPlayer(player, "Dein Dispatch wurde gesendet und du kannst nun auflegen.");
                            System.Threading.Tasks.Task.Run(() =>
                            {
                                NAPI.Task.Run(() =>
                                {
                                    police.TriggerEvent("blip_router_visible", "Neuer Anruf", true, 73);
                                    police.TriggerEvent("blip_remove", "Neuer Anruf");
                                }, delayTime: 300000); // delay time in ms
                            });
                        }
                    }
                }
                else if (number == 913)
                {
                    service.faction = 8;
                    service.job = 0;
                    foreach (var police in NAPI.Pools.GetAllPlayers())
                    {
                        if (police.GetData("status") == true && FactionManage.GetPlayerGroupType(police) == 8)
                        {
                            police.TriggerEvent("Notification.SendPictureNotification", "Notruf", "Neuer Anruf", $"Tel:~g~ " + cellphoneSystem.GetPlayerNumber(player) + ".~n~~n~~c~(( F6 zu akzeptieren))");
                            police.TriggerEvent("blip_create_ext", "Neuer Anruf", player.Position, 73, 0.70f, 0);
                            NAPI.Notification.SendNotificationToPlayer(player, "Dein Dispatch wurde gesendet und du kannst nun auflegen.");
                            System.Threading.Tasks.Task.Run(() =>
                            {
                                NAPI.Task.Run(() =>
                                {
                                    police.TriggerEvent("blip_router_visible", "Neuer Anruf", true, 73);
                                    police.TriggerEvent("blip_remove", "Neuer Anruf");
                                }, delayTime: 300000); // delay time in ms
                            });
                        }
                    }
                }
                else if (number == 914)
                {
                    service.faction = 10;
                    service.job = 0;
                    foreach (var police in NAPI.Pools.GetAllPlayers())
                    {
                        if (police.GetData("status") == true && FactionManage.GetPlayerGroupType(police) == 10)
                        {
                            police.TriggerEvent("Notification.SendPictureNotification", "Notruf", "Neuer Anruf", $"Tel:~g~ " + cellphoneSystem.GetPlayerNumber(player) + ".~n~~n~~c~(( F6 zu akzeptieren))");
                            police.TriggerEvent("blip_create_ext", "Neuer Anruf", player.Position, 73, 0.70f, 0);
                            NAPI.Notification.SendNotificationToPlayer(player, "Dein Dispatch wurde gesendet und du kannst nun auflegen.");
                            System.Threading.Tasks.Task.Run(() =>
                            {
                                NAPI.Task.Run(() =>
                                {
                                    police.TriggerEvent("blip_router_visible", "Neuer Anruf", true, 73);
                                    police.TriggerEvent("blip_remove", "Neuer Anruf");
                                }, delayTime: 300000); // delay time in ms
                            });
                        }
                    }
                }
                else if (number == 915)
                {
                    service.faction = 9;
                    service.job = 0;
                    foreach (var police in NAPI.Pools.GetAllPlayers())
                    {
                        if (police.GetData("status") == true && FactionManage.GetPlayerGroupType(police) == 9)
                        {
                            police.TriggerEvent("Notification.SendPictureNotification", "Notruf", "Neuer Anruf", $"Tel:~g~ " + cellphoneSystem.GetPlayerNumber(player) + ".~n~~n~~c~(( F6 zu akzeptieren))");
                            police.TriggerEvent("blip_create_ext", "Neuer Anruf", player.Position, 73, 0.70f, 0);
                            NAPI.Notification.SendNotificationToPlayer(player, "Dein Dispatch wurde gesendet und du kannst nun auflegen.");
                            System.Threading.Tasks.Task.Run(() =>
                            {
                                NAPI.Task.Run(() =>
                                {
                                    police.TriggerEvent("blip_router_visible", "Neuer Anruf", true, 73);
                                    police.TriggerEvent("blip_remove", "Neuer Anruf");
                                }, delayTime: 300000); // delay time in ms
                            });
                        }
                    }
                }
                else if (number == 916)
                {
                    service.faction = 15;
                    service.job = 0;
                    foreach (var police in NAPI.Pools.GetAllPlayers())
                    {
                        if (police.GetData("status") == true && FactionManage.GetPlayerGroupType(police) == 15)
                        {
                            police.TriggerEvent("Notification.SendPictureNotification", "Notruf", "Neuer Anruf", $"Tel:~g~ " + cellphoneSystem.GetPlayerNumber(player) + ".~n~~n~~c~(( F6 zu akzeptieren))");
                            police.TriggerEvent("blip_create_ext", "Neuer Anruf", player.Position, 73, 0.70f, 0);
                            NAPI.Notification.SendNotificationToPlayer(player, "Dein Dispatch wurde gesendet und du kannst nun auflegen.");
                            System.Threading.Tasks.Task.Run(() =>
                            {
                                NAPI.Task.Run(() =>
                                {
                                    police.TriggerEvent("blip_router_visible", "Neuer Anruf", true, 73);
                                    police.TriggerEvent("blip_remove", "Neuer Anruf");
                                }, delayTime: 300000); // delay time in ms
                            });
                        }
                    }
                }
                return;
            }
        }
        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"ERROR: Sie sind bereits in einem Gespräch.", 5000);
        player.TriggerEvent("service_cancel");
    }

    public static void DisplayCalls(Client player)
    {
        if (FactionManage.GetPlayerGroupType(player) == 1)
        {
            List<dynamic> menu_item_list = new List<dynamic>();
            foreach (var service in service_system)
            {
                if (service.active == 1 && FactionManage.GetPlayerGroupType(player) == service.faction)
                {
                    menu_item_list.Add(new { index = service.id, name = AccountManage.GetCharacterName(service.caller), timeago = service.dateTime, location = "Zu " + service.position.DistanceTo(player.Position).ToString("#.##").Replace(",", ".") + " Meter von Ihnen entfernt" });
                }
            }
            player.TriggerEvent("Display_Calls", "LSPD & FIB von Los Santos - angerufen", JsonConvert.SerializeObject(menu_item_list));
        }
        else if (FactionManage.GetPlayerGroupType(player) == 2)
        {
            List<dynamic> menu_item_list = new List<dynamic>();
            foreach (var service in service_system)
            {
                if (service.active == 1 && FactionManage.GetPlayerGroupType(player) == service.faction)
                {
                    menu_item_list.Add(new { index = service.id, name = AccountManage.GetCharacterName(service.caller), timeago = service.dateTime, location = "Zu " + service.position.DistanceTo(player.Position).ToString("#.##").Replace(",", ".") + " Meter von Ihnen entfernt" });
                }
            }
            player.TriggerEvent("Display_Calls", "Hospital von Los Santos - angerufen", JsonConvert.SerializeObject(menu_item_list));
        }
        else if (FactionManage.GetPlayerGroupType(player) == 8)
        {
            List<dynamic> menu_item_list = new List<dynamic>();
            foreach (var service in service_system)
            {
                if (service.active == 1 && FactionManage.GetPlayerGroupType(player) == service.faction)
                {
                    menu_item_list.Add(new { index = service.id, name = AccountManage.GetCharacterName(service.caller), timeago = service.dateTime, location = "Zu " + service.position.DistanceTo(player.Position).ToString("#.##").Replace(",", ".") + " Meter von Ihnen entfernt" });
                }
            }
            player.TriggerEvent("Display_Calls", "ACLS von Los Santos - angerufen", JsonConvert.SerializeObject(menu_item_list));
        }
        else if (FactionManage.GetPlayerGroupType(player) == 10)
        {
            List<dynamic> menu_item_list = new List<dynamic>();
            foreach (var service in service_system)
            {
                if (service.active == 1 && FactionManage.GetPlayerGroupType(player) == service.faction)
                {
                    menu_item_list.Add(new { index = service.id, name = AccountManage.GetCharacterName(service.caller), timeago = service.dateTime, location = "Zu " + service.position.DistanceTo(player.Position).ToString("#.##").Replace(",", ".") + " Meter von Ihnen entfernt" });
                }
            }
            player.TriggerEvent("Display_Calls", "Taxi von Los Santos - angerufen", JsonConvert.SerializeObject(menu_item_list));
        }
        else if (FactionManage.GetPlayerGroupType(player) == 9)
        {
            List<dynamic> menu_item_list = new List<dynamic>();
            foreach (var service in service_system)
            {
                if (service.active == 1 && FactionManage.GetPlayerGroupType(player) == service.faction)
                {
                    menu_item_list.Add(new { index = service.id, name = AccountManage.GetCharacterName(service.caller), timeago = service.dateTime, location = "Zu " + service.position.DistanceTo(player.Position).ToString("#.##").Replace(",", ".") + " Meter von Ihnen entfernt" });
                }
            }
            player.TriggerEvent("Display_Calls", "Department of Justice - angerufen", JsonConvert.SerializeObject(menu_item_list));
        }
        else if (FactionManage.GetPlayerGroupType(player) == 15)
        {
            List<dynamic> menu_item_list = new List<dynamic>();
            foreach (var service in service_system)
            {
                if (service.active == 1 && FactionManage.GetPlayerGroupType(player) == service.faction)
                {
                    menu_item_list.Add(new { index = service.id, name = AccountManage.GetCharacterName(service.caller), timeago = service.dateTime, location = "Zu " + service.position.DistanceTo(player.Position).ToString("#.##").Replace(",", ".") + " Meter von Ihnen entfernt" });
                }
            }
            player.TriggerEvent("Display_Calls", "FIB - angerufen", JsonConvert.SerializeObject(menu_item_list));
        }
    }

    [RemoteEvent("Service_Track_Server")]
    public static void Service_Track_Server(Client player, int id)
    {
        if(service_system[id].active == 1)
        {
            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"GPS-Route Für den Anruf " + AccountManage.GetCharacterName(service_system[id].caller)+ " zu " + service_system[id].position.DistanceTo(player.Position).ToString("#.##").Replace(",", ".") + " Meter von Ihnen entfernt.", 5000);
            player.TriggerEvent("gps_set_loc", service_system[id].position.X, service_system[id].position.Y);
        }
    }

    [RemoteEvent("Service_Remove_Server")]
    public static void Service_Remove_Server(Client player, int id)
    {
        if (service_system[id].active == 1)
        {
            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Anruf-ID ~c~#" + id+ "~w~ erfolgreich entfernt", 5000);
            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Ihr Anruf wurde als erledigt markiert.", 5000);

            service_system[id].caller.TriggerEvent("service_cancel");

            service_system[id].job = 0;
            service_system[id].active = 0;
            service_system[id].faction = 0;
            service_system[id].position = new Vector3();
            
            service_system[id].caller = null;
            DisplayCalls(player);
        }
    }
}

