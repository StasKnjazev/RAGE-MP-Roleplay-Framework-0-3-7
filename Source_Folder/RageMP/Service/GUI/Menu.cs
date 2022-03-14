using GTANetworkAPI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using DerStr1k3r.Core;
using DerStr1k3r.SDK;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace DerStr1k3r.GUI
{
    class MenuManager : Script
    {
        public static Dictionary<Entity, Menu> Menus = new Dictionary<Entity, Menu>();
        private static nLog Log = new nLog("MenuControl");

        public static void Event_OnPlayerDisconnected(Client client, DisconnectionType type, string reason)
        {
            try
            {
                if (Menus.ContainsKey(client))
                    Menus.Remove(client);
            }
            catch (Exception e) { Log.Write("PlayerDisconnected: " + e.Message, nLog.Type.Error); }
        }
        #region Menu Open
        public static void Open(Client client, Menu menu, bool force = false)
        {
            try
            {
                if (Menus.ContainsKey(client))
                {
                    Log.Debug($"Player already have opened Menu! id:{Menus[client].ID}", nLog.Type.Warn);
                    if (!force) return;
                    Menus.Remove(client);
                }
                Menus.Add(client, menu);

                //string data = JsonConvert.SerializeObject(menu);
                string data = menu.getJsonStr();

                if (!client.HasData("Phone"))
                {
                    Trigger.ClientEvent(client, "phoneShow");
                    client.SetData("Phone", true);
                }
                Trigger.ClientEvent(client, "phoneOpen", data);
            }
            catch (Exception e)
            {
                Log.Write("EXCEPTION AT \"MENUCONTROL_OPEN\":\n" + e.ToString(), nLog.Type.Error);
            }
        }
        public static async Task OpenAsync(Client client, Menu menu, bool force = false)
        {
            try
            {
                lock (Menus)
                {
                    if (Menus.ContainsKey(client))
                    {
                        Log.Debug($"Player already have opened Menu! id:{Menus[client].ID}");
                        if (!force) return;
                        Menus.Remove(client);
                    }
                    Menus.Add(client, menu);
                }
                string data = await menu.getJsonStrAsync();

                if (!client.HasData("Phone"))
                {
                    Trigger.ClientEvent(client, "phoneShow");
                    client.SetData("Phone", true);
                }
                Trigger.ClientEvent(client, "phoneOpen", data);
            }
            catch (Exception e)
            {
                Log.Write("EXCEPTION AT \"MENUCONTROL_OPEN\":\n" + e.ToString(), nLog.Type.Error);
            }
        }
        #endregion
        #region Menu Close
        public static void Close(Client client, bool hidePhone = true)
        {
            try
            {
                if (Menus.ContainsKey(client))
                    Menus.Remove(client);
                if (hidePhone)
                {
                    Trigger.ClientEvent(client, "phoneHide");
                    client.ResetData("Phone");
                }
                Trigger.ClientEvent(client, "phoneClose");
            }
            catch (Exception e)
            {
                Log.Write("EXCEPTION AT \"MENUCONTROL_CLOSE\":\n" + e.ToString(), nLog.Type.Error);
            }
        }
        public static async Task CloseAsync(Client client, bool hidePhone = true)
        {
            try
            {
                lock (Menus)
                {
                    if (Menus.ContainsKey(client))
                        Menus.Remove(client);
                }

                if (hidePhone)
                {
                    Trigger.ClientEvent(client, "phoneHide");
                    client.ResetData("Phone");
                }
                Trigger.ClientEvent(client, "phoneClose");
            }
            catch (Exception e)
            {
                Log.Write("EXCEPTION AT \"MENUCONTROL_CLOSE\":\n" + e.ToString(), nLog.Type.Error);
            }
        }
        #endregion
    }
    class Menu
    {
        public delegate void MenuCallback(Client client, Menu menu, Item item, string eventName, dynamic data);
        public delegate void MenuBack(Client client, Menu menu);

        public string ID { get; internal set; }
        public List<Item> Items { get; internal set; }
        public bool canBack { get; internal set; }
        public bool canHome { get; internal set; }

        [JsonIgnore]
        public MenuCallback Callback { get; set; }
        [JsonIgnore]
        public MenuBack BackButton { get; set; }
        [JsonIgnore]
        private static nLog Log = new nLog("Menu");

        public Menu(string id, bool canback, bool canhome)
        {
            if (string.IsNullOrEmpty(id))
                ID = "";
            else
                ID = id;

            Items = new List<Item>();
            Callback = null;
            BackButton = null;
            canHome = canhome;
            canBack = canback;
        }
        public void Add(Item item)
        {
            Items.Add(item);
        }
        public void Open(Client client)
        {
            MenuManager.Open(client, this, true);
        }
        public async Task OpenAsync(Client client)
        {
            await MenuManager.OpenAsync(client, this, true);
        }
        public void Change(Client client, int index, Item newData)
        {
            string data = JsonConvert.SerializeObject(newData.getJsonArr());
            Trigger.ClientEvent(client, "phoneChange", index, data);
        }

        public string getJsonStr()
        {
            JArray items = new JArray();
            foreach (Item i in Items)
            {
                items.Add(i.getJsonArr());
            }
            JArray menuData = new JArray()
            {
                ID,
                items,
                canBack,
                canHome,
            };
            string data = JsonConvert.SerializeObject(menuData);
            //Log.Write(data, nLog.Type.Debug);
            return data;
        }
        public async Task<string> getJsonStrAsync()
        {
            JArray items = new JArray();
            foreach (Item i in Items)
            {
                items.Add(await i.getJsonArrAsync());
            }
            JArray menuData = new JArray()
            {
                ID,
                items,
                canBack,
                canHome,
            };
            string data = JsonConvert.SerializeObject(menuData);
            return data;
        }

        internal class Item
        {
            public string ID { get; internal set; }
            public string Text { get; internal set; }
            public MenuItem Type { get; internal set; }
            public MenuColor Color { get; set; }
            public int Column { get; set; }
            public int Scale { get; set; }
            public bool Checked { get; set; }
            public List<string> Elements { get; set; }

            public Item(string id, MenuItem type)
            {
                if (string.IsNullOrEmpty(id))
                    ID = "";
                else
                    ID = id;
                Type = type;
                Column = 1;
            }
            public JArray getJsonArr()
            {
                JArray elements = new JArray(Elements);
                JArray data = new JArray()
                {
                    ID,
                    Text,
                    Type,
                    Color,
                    Column,
                    Scale,
                    Checked,
                    elements
                };
                return data;
            }
            public async Task<JArray> getJsonArrAsync()
            {
                JArray elements = new JArray(Elements);
                JArray data = new JArray()
                {
                    ID,
                    Text,
                    Type,
                    Color,
                    Column,
                    Scale,
                    Checked,
                    elements
                };
                return data;
            }
        }
        #region Enums
        public enum MenuItem
        {
            Void,
            Header,
            Card,
            Button,
            Checkbox,
            Input,
            List,

            gpsBtn,
            contactBtn,
            servicesBtn,
            homeBtn,
            grupBtn,
            hotelBtn,
            ilanBtn,
            closeBtn,
            businessBtn,
            adminBtn,
            lockBtn,
            leaveBtn,
            onRadio,
            offRadio,
            promoBtn

        }
        public enum MenuColor
        {
            White,
            Red,
            Green,
            Blue,
            Yellow,
            Orange,
            Teal,
            Cyan,
            Lime
        }
        #endregion
    }
}
