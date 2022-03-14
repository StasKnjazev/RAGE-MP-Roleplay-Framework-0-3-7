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
using System.Timers;
using DerStr1k3r.Core;
using DerStr1k3r.SDK;

class cellphoneSystem : Script
{

    public class ContactEnum : IEquatable<ContactEnum>
    {
        public int id { get; set; }

        public string[] contact_name { get; set; } = new string[60];
        public int[] contact_number { get; set; } = new int[60];


        public override int GetHashCode()
        {
            return id;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            ContactEnum objAsPart = obj as ContactEnum;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }

        public bool Equals(ContactEnum other)
        {
            if (other == null) return false;
            return (this.id.Equals(other.id));
        }
    }
    public static List<ContactEnum> contacts_data = new List<ContactEnum>();


    public class CallEnum : IEquatable<CallEnum>
    {
        public int id { get; set; }

        public Client player_one { get; set; }
        public Client player_two { get; set; }

        public int active { get; set; }
        public int time { get; set; }


        public override int GetHashCode()
        {
            return id;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            CallEnum objAsPart = obj as CallEnum;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }

        public bool Equals(CallEnum other)
        {
            if (other == null) return false;
            return (this.id.Equals(other.id));
        }
    }

#pragma warning disable IDE1006 // Benennungsstile
    public static List<CallEnum> call_data = new List<CallEnum>();
#pragma warning restore IDE1006 // Benennungsstile
    public static List<TimerEx> ringtone_time = new List<TimerEx>();

    public static void LoadContacts(Client player)
    {
        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {

            Mainpipeline.Open();
            MySqlCommand query = new MySqlCommand("SELECT * FROM `contacts` WHERE `owner` = '" + AccountManage.GetPlayerSQLID(player) + "' LIMIT 60;", Mainpipeline);

            using (MySqlDataReader reader = query.ExecuteReader())
            {

                string data2txt = string.Empty;
                string datatxt = string.Empty;

                int count = 0;
                while (reader.Read())
                {
                    contacts_data[Main.getIdFromClient(player)].contact_name[count] = reader.GetString("name");
                    contacts_data[Main.getIdFromClient(player)].contact_number[count] = reader.GetInt32("number");
                    count++;
                }
            }
        }
    }

    public cellphoneSystem()
    {
        for (int i = 0; i < 100; i++)
        {
            call_data.Add(new CallEnum { id = i, active = 0, time = 0, player_one = null, player_two = null });
        }
    }

    public static void NewNumber(Client player)
    {
        Random rnd = new Random();
        int random_number = rnd.Next(555100000, 555999999);

        player.SetData("character_cellphone", random_number);

        NAPI.Notification.SendNotificationToPlayer(player, "Ihre neue Handynummer lautet: ~b~" + String.Format("{0:###-###}", random_number) + "");
        //player.SendChatMessage("Ihre neue Handynummer lautet: ~b~" + String.Format("{0:###-###}", random_number) + "~w~.");

        if (cellphoneSystem.GetPlayerNumber(player) != 0)
        {
            player.TriggerEvent("initPhone");
            player.TriggerEvent("setPhoneNumber", cellphoneSystem.GetPlayerNumber(player));
        }
    }

    public static int GetPlayerNumber(Client player)
    {
        return player.GetData("character_cellphone");
    }

    public static void DisplayNewContact(Client player)
    {
        List<dynamic> menu_item_list = new List<dynamic>();
        menu_item_list.Add(new { Type = 1, Name = "Name", Description = "", RightLabel = "" + player.GetData("contact_name") + "" });
        menu_item_list.Add(new { Type = 1, Name = "Nummer", Description = "", RightLabel = "" + player.GetData("contact_number") + "" });
        menu_item_list.Add(new { Type = 1, Name = "~g~Kontakt hinzufügen", Description = "", RightLabel = "" });
        //menu_item_list.Add(new { Type = 1, Name = "Telefonbuch", Description = "", RightLabel = "" });
        InteractMenu.CreateMenu(player, "CELLPHONE_ADD_CONTACT", "Mobiltelefon", "~b~Speichern - ~g~Neuer Kontakt", false, NAPI.Util.ToJson(menu_item_list), false);
        //player.TriggerEvent("menu_handler_create_menu_generic", "CELLPHONE_ADD_CONTACT", "Mobiltelefon", "~b~Speichern - ~g~Neuer Kontakt", false, NAPI.Util.ToJson(menu_item_list), "Seite", "Wechseln Sie zwischen den Seiten", 100);
    }

    //Leistellenort
    //public static void PressKeyE(Client player)
    //{
    //    if (Main.IsInRangeOfPoint(player.Position, new Vector3(457.66818, -992.59717, 35.931057), 1) || (Main.IsInRangeOfPoint(player.Position, new Vector3(320.94452, -571.31616, 28.791481), 1) || (Main.IsInRangeOfPoint(player.Position, new Vector3(-1173.2288, -1961.7523, 13.5822525), 1) || (Main.IsInRangeOfPoint(player.Position, new Vector3(896.0696, -164.2533, 74.16833), 1)))))
    //    {

    //        List<dynamic> menu_item_list = new List<dynamic>();
    //        menu_item_list.Add(new { Type = 1, Name = "Leitstelle an / abmelden", Description = "", RightLabel = "" });
    //        InteractMenu.CreateMenu(player, "copleitstelle", "Leitstelle", "Wähle aus", true, NAPI.Util.ToJson(menu_item_list), false);
    //    }
    //}

    public static void SelectMenuResponse(Client player, String callbackId, int selectedIndex, String objectName, String valueList)
    {
        if (callbackId == "copleitstelle")
        {
            if (selectedIndex == 0)
            {
                if (player.GetData("duty") == 0)
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "Sie sind nicht im Dienst.");
                }
                else if (player.GetData("duty") == 1)
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "Sie sind die Leitstelle.");
                    player.TriggerEvent("getLeitstelle");
                    //player.TriggerEvent("leitstelleToggle");

                }
            }
        }
        else if (callbackId == "CELLPHONE_RESPONSE")
        {
            int playerid = Main.getIdFromClient(player);
            switch (selectedIndex)
            {
                case 0:
                    {
                        InteractMenu.User_Input(player, "CALL_NUMBER", "Rufen Sie die Nummer an:", "0", "", "number");
                        break;
                    }
                case 1:
                    {
                        List<dynamic> menu_item_list = new List<dynamic>();
                        menu_item_list.Add(new { Type = 1, Name = "Kontakt hinzufügen", Description = "", RightLabel = "", BackgroundColor = new Color(47, 172, 189), FrontColor = new Color(47, 172, 189) });

                        int count = 0;
                        for (int i = 0; i < 60; i++)
                        {
                            if (cellphoneSystem.contacts_data[playerid].contact_number[i] != 0)
                            {
                                menu_item_list.Add(new { Type = 1, Name = "~s~" + i + ".~c~ " + cellphoneSystem.contacts_data[playerid].contact_name[i] + "", Description = "Telefonnummer: ~y~" + cellphoneSystem.contacts_data[playerid].contact_number[i] + "", RightLabel = "~s~>>", BackgroundColor = new Color(47, 172, 189), FrontColor = new Color(47, 172, 189) });

                                player.SetData("ListTrack_" + count + "", i);

                            }
                            count++;
                        }
                        InteractMenu.CreateMenu(player, "CELLPHONE_CONTACTS", "Mobiltelefon", "~b~Handynummer ~y~#" + String.Format("{0:###-###}", GetPlayerNumber(player)) + "~b~", false, NAPI.Util.ToJson(menu_item_list), false);
                        //player.TriggerEvent("menu_handler_create_menu_generic", "CELLPHONE_CONTACTS", "Mobiltelefon", "~b~Handynummer ~y~#" + String.Format("{0:###-###}", GetPlayerNumber(player)) + "~b~", false, NAPI.Util.ToJson(menu_item_list), "Seite", "Wechseln Sie zwischen den Seiten", 100);
                        break;
                    }
                case 2:
                    {
                        List<dynamic> menu_item_list = new List<dynamic>();
                        menu_item_list.Add(new { Type = 1, Name = "Doktor", Description = "" });
                        menu_item_list.Add(new { Type = 1, Name = "Polizei", Description = "" });
                        menu_item_list.Add(new { Type = 1, Name = "ACLS", Description = "" });
                        menu_item_list.Add(new { Type = 1, Name = "Taxi", Description = "" });
                        InteractMenu.CreateMenu(player, "CALL_SYSTEM_RESPONSE", "Mobiltelefon", "~b~Handynummer ~y~#" + String.Format("{0:###-###}", GetPlayerNumber(player)) + "~b~", false, NAPI.Util.ToJson(menu_item_list), false);
                        //player.TriggerEvent("menu_handler_create_menu_generic", "CALL_SYSTEM_RESPONSE", "Mobiltelefon", "~b~Handynummer ~y~#" + String.Format("{0:###-###}", GetPlayerNumber(player)) + "~b~", false, NAPI.Util.ToJson(menu_item_list), "Seite", "Wechseln Sie zwischen den Seiten", 8);
                        break;
                    }
                case 3:
                    {
                        InteractMenu.User_Input(player, "PUT_ANNOUNCE", "Geben Sie die Anzeige ein", "0");
                        break;
                    }

            }
        }
        else if (callbackId == "CELLPHONE_CONTACTS")
        {
            if (selectedIndex == 0)
            {
                player.SetData("contact_name", "");
                player.SetData("contact_number", 999999999);
                DisplayNewContact(player);
            }
            else
            {

                int i = player.GetData("ListTrack_" + (selectedIndex - 1) + "");
                int playerid = Main.getIdFromClient(player);

                player.SetData("contact_id", i);

                if (contacts_data[playerid].contact_number[i] == 0)
                {
                    return;
                }

                List<dynamic> menu_item_list = new List<dynamic>();
                menu_item_list.Add(new { Type = 1, Name = "Einschalten", Description = "", RightLabel = "", BackgroundColor = new Color(47, 172, 189), FrontColor = new Color(47, 172, 189) });
                menu_item_list.Add(new { Type = 1, Name = "Nachricht senden", Description = "", RightLabel = "" });
                menu_item_list.Add(new { Type = 1, Name = "Kontakt löschen", Description = "", RightLabel = "" });
                InteractMenu.CreateMenu(player, "CELLPHONE_CONTACT_RESPONSE", "Mobiltelefon", "~b~" + contacts_data[playerid].contact_name[i] + " - ~y~#" + String.Format("{0:###-###}", contacts_data[playerid].contact_number[i]) + "~b~:", false, NAPI.Util.ToJson(menu_item_list), false);
            }
        }
        else if (callbackId == "CELLPHONE_CONTACT_RESPONSE")
        {
            int i = player.GetData("contact_id");
            int playerid = Main.getIdFromClient(player);

            if (contacts_data[playerid].contact_number[i] == 0)
            {

                return;
            }
            if (selectedIndex == 0)
            {
                Call_Number(player, contacts_data[playerid].contact_number[i]);
            }
            else if (selectedIndex == 1)
            {
                foreach (var target in NAPI.Pools.GetAllPlayers())
                {
                    if (target.GetData("status") == true)
                    {
                        if (contacts_data[playerid].contact_number[i] == GetPlayerNumber(target))
                        {
                            InteractMenu.User_Input(player, "SEND_SMS", "Nachricht senden", "...");
                            player.SetData("handle_sms", target);
                            return;
                        }
                    }
                }
                Main.SendErrorMessage(player, "Diese Nummer konnte nicht gefunden werden.");
            }
            else if (selectedIndex == 2)
            {
                //player.SendChatMessage("* Sie haben gelöscht ~b~" + cellphoneSystem.contacts_data[playerid].contact_name[i] + " ~c~(Nummer #" + cellphoneSystem.contacts_data[playerid].contact_number[i] + "~w~ aus Ihrer Kontaktliste.");
                NAPI.Notification.SendNotificationToPlayer(player, "Sie haben gelöscht ~b~" + cellphoneSystem.contacts_data[playerid].contact_name[i] + " ~c~(Nummer #" + cellphoneSystem.contacts_data[playerid].contact_number[i] + "~w~ aus Ihrer Kontaktliste.");
                // DEL 1
                // Main.CreateMySqlCommand("DELETE FROM `contacts` WHERE `number` = '" + cellphoneSystem.contacts_data[playerid].contact_number[i] + "';");

                cellphoneSystem.contacts_data[playerid].contact_name[i] = null;
                cellphoneSystem.contacts_data[playerid].contact_number[i] = 0;
            }
        }
        else if (callbackId == "CELLPHONE_ADD_CONTACT")
        {
            int playerid = Main.getIdFromClient(player);
            switch (selectedIndex)
            {
                case 0:
                    {
                        InteractMenu.User_Input(player, "ADD_NAME", "Kontaktname", player.GetData("contact_name").ToString());
                        break;
                    }
                case 1:
                    {
                        InteractMenu.User_Input(player, "ADD_NUMBER", "Telefonnummer", player.GetData("contact_number").ToString());
                        break;
                    }
                case 2:
                    {
                        if (player.GetData("contact_name") == "")
                        {
                            NAPI.Notification.SendNotificationToPlayer(player, "Sie müssen einen Namen und eine Kontaktnummer definieren.");
                            DisplayNewContact(player);
                            return;
                        }

                        if (player.GetData("contact_number") == 999999999 || player.GetData("contact_number") == 0)
                        {
                            NAPI.Notification.SendNotificationToPlayer(player, "Sie müssen einen Namen und eine Kontaktnummer definieren.");
                            DisplayNewContact(player);
                            return;
                        }

                        for (int i = 0; i < 60; i++)
                        {
                            if (cellphoneSystem.contacts_data[playerid].contact_number[i] == player.GetData("contact_number"))
                            {
                                NAPI.Notification.SendNotificationToPlayer(player, "Sie haben diese Nummer bereits in Ihrer Kontaktliste.");
                                return;
                            }
                        }

                        for (int i = 0; i < 60; i++)
                        {
                            if (cellphoneSystem.contacts_data[playerid].contact_number[i] == 0)
                            {
                                cellphoneSystem.contacts_data[playerid].contact_name[i] = player.GetData("contact_name");
                                cellphoneSystem.contacts_data[playerid].contact_number[i] = player.GetData("contact_number");

                                NAPI.Notification.SendNotificationToPlayer(player, "Sie haben den Kontakt erfolgreich hinzugefügt ~b~" + player.GetData("contact_name") + " ~c~(Nummer #" + player.GetData("contact_number") + ")~w~ in Ihrer Kontaktliste.");
                                string query = "INSERT INTO `contacts` (owner, name, number) VALUES (" + AccountManage.GetPlayerSQLID(player) + ", '" + player.GetData("contact_name") + "', " + player.GetData("contact_number") + ");";
                                Main.CreateMySqlCommand(query);
                                return;
                            }
                        }
                        NAPI.Notification.SendNotificationToPlayer(player, "Diese Nummer konnte nicht zu Ihrer Kontaktliste hinzugefügt werden.");
                        break;
                    }
            }
        }
    }

    // [Command("leitstelle")]
    [RemoteEvent("leitstelleToggle")]
    public static void CMD_leitstelle(Client player)
    //public static void Event_leitstelle(Client player)
    {
        if (player.GetData("status") == false)
        {
            return;
        }

        if (player.GetSharedData("Injured") != 0)
        {
            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie können keine Leitstelle machen, während Sie bewusstlos sind.", 5000);
            return;
        }

        if (player.GetData("playerCuffed") != 0)
        {
            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie können keine Leitstelle mit Handschellen machen.", 5000);
            return;
        }

        if (player.GetData("character_prison") != 0)
        {
            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie können keine Leitstelle besetzen, wenn Sie sich im Gefängnis befinden..", 5000);
            return;
        }


        int faction_id = AccountManage.GetPlayerGroup(player);

        switch (faction_id)
        {

            case 1: // Cops
                if (player.GetSharedData("leitstelle110") != 0)
                {
                    player.SetSharedData("leitstelle110", 0);
                    Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du hast dich von der Leistelle abgemeldet!", 5000);
                    break;
                }

                var leitstelle110 = GetPlayerNumber(player);
                foreach (var target in NAPI.Pools.GetAllPlayers())
                {
                    if (target.GetSharedData("leitstelle110") != 0 && player != target)
                    {
                        target.SetSharedData("leitstelle110", 0);

                    }
                }
                player.SetSharedData("leitstelle110", leitstelle110);
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du bist jetzt die Leistelle!", 5000);

                break;

            case 2: // medic
                if (player.GetSharedData("leitstelle112") != 0)
                {
                    player.SetSharedData("leitstelle112", 0);
                    Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du hast dich von der Leistelle abgemeldet!", 5000);
                    break;
                }

                var leitstelle112 = GetPlayerNumber(player);
                foreach (var target in NAPI.Pools.GetAllPlayers())
                {
                    if (target.GetSharedData("leitstelle112") != 0 && player != target)
                    {
                        target.SetSharedData("leitstelle112", 0);
                        target.SendNotification("Du bist jetzt keine Leistelle mehr!");
                    }
                }
                player.SetSharedData("leitstelle112", leitstelle112);
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du bist jetzt die Leistelle!", 5000);

                break;

            case 15: // acls
                if (player.GetSharedData("leitstelle113") != 0)
                {
                    player.SetSharedData("leitstelle113", 0);
                    Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du hast dich von der Leistelle abgemeldet!", 5000);
                    break;
                }

                var leitstelle113 = GetPlayerNumber(player);
                foreach (var target in NAPI.Pools.GetAllPlayers())
                {
                    if (target.GetSharedData("leitstelle113") != 0 && player != target)
                    {
                        target.SetSharedData("leitstelle113", 0);
                        target.SendNotification("Du bist jetzt keine Leistelle mehr!");
                    }
                }
                player.SetSharedData("leitstelle113", leitstelle113);
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du bist jetzt die Leistelle!", 5000);

                break;

            case 17: // taxi

                if (player.GetSharedData("leitstelle114") != 0)
                {
                    player.SetSharedData("leitstelle114", 0);
                    Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du hast dich von der Leistelle abgemeldet!", 5000);
                    break;
                }

                var leitstelle114 = GetPlayerNumber(player);
                foreach (var target in NAPI.Pools.GetAllPlayers())
                {
                    if (target.GetSharedData("leitstelle114") != 0 && player != target)
                    {
                        target.SetSharedData("leitstelle114", 0);
                        target.SendNotification("Du bist jetzt keine Leistelle mehr!");
                    }
                }
                player.SetSharedData("leitstelle114", leitstelle114);
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du bist jetzt die Leistelle!", 5000);

                break;

            default: // Keine Fraktion

                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Keine Berechtigung!", 5000);

                break;
        }
    }

    public static void OnInputResponse(Client player, String response, String inputtext)
    {
        if (response == "CALL_NUMBER")
        {
            if (!Main.IsNumeric(inputtext))
            {
                Main.SendErrorMessage(player, "Dies ist keine Handynummer.");
                return;
            }

            int target_number = Convert.ToInt32(inputtext.Replace("-", ""));
            Call_Number(player, target_number);
        }
        else if (response == "SEND_SMS")
        {

            if (inputtext.Contains("-"))
            {
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Das - Zeichen ist nicht erlaubt!", 5000);
                return;
            }

            if (inputtext.Contains("+"))
            {
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Das + Zeichen ist nicht erlaubt!", 5000);
                return;
            }

            if (inputtext.Contains("*"))
            {
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Das * Zeichen ist nicht erlaubt!", 5000);
                return;
            }

            if (inputtext.Contains("'"))
            {
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Das ' Zeichen ist nicht erlaubt!", 5000);
                return;
            }

            if (inputtext.Contains("/"))
            {
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Das / Zeichen ist nicht erlaubt!", 5000);
                return;
            }

            if (inputtext.Contains("|"))
            {
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Das | Zeichen ist nicht erlaubt!", 5000);
                return;
            }

            if (inputtext.Contains(">"))
            {
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Das > Zeichen ist nicht erlaubt!", 5000);
                return;
            }

            if (inputtext.Contains("#"))
            {
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Das # Zeichen ist nicht erlaubt!", 5000);
                return;
            }

            if (inputtext.Contains("<"))
            {
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Das < Zeichen ist nicht erlaubt!", 5000);
                return;
            }

            if (inputtext.Contains(";"))
            {
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Das ; Zeichen ist nicht erlaubt!", 5000);
                return;
            }

            if (inputtext.Contains("&"))
            {
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Das & Zeichen ist nicht erlaubt!", 5000);
                return;
            }

            if (inputtext.Contains("$"))
            {
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Das $ Zeichen ist nicht erlaubt!", 5000);
                return;
            }

            if (inputtext.Contains("("))
            {
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Das ( Zeichen ist nicht erlaubt!", 5000);
                return;
            }

            if (inputtext.Contains(")"))
            {
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Das ) Zeichen ist nicht erlaubt!", 5000);
                return;
            }

            if (inputtext.Contains("["))
            {
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Das [ Zeichen ist nicht erlaubt!", 5000);
                return;
            }

            if (inputtext.Contains("]"))
            {
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Das ] Zeichen ist nicht erlaubt!", 5000);
                return;
            }

            if (inputtext.Contains("="))
            {
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Das = Zeichen ist nicht erlaubt!", 5000);
                return;
            }

            if (inputtext.Contains(":"))
            {
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Das : Zeichen ist nicht erlaubt!", 5000);
                return;
            }	
	
            string sms_text = inputtext;

            if (sms_text.Length < 5 || sms_text.Length > 120)
            {
                Main.SendErrorMessage(player, "Die Anzahl der Zeichen darf nicht weniger als 5 Zeichen oder mehr als 120 Zeichen betragen.");
                return;
            }

            Client sms_handle = NAPI.Data.GetEntityData(player, "handle_sms");

            if (!NAPI.Player.IsPlayerConnected(sms_handle))
            {
                Main.SendErrorMessage(player, "Dieser Bürger ist nicht angemeldet.");
                return;
            }

            if (sms_handle.GetData("status") == false)
            {
                Main.SendErrorMessage(player, "Dieser Bürger ist nicht angemeldet.");
                return;
            }

            sms_handle.TriggerEvent("BN_ShowWithPicture", "Nachricht erhalten", "de " + AccountManage.GetCharacterName(player) + " N# " + String.Format("{0:###-###}", GetPlayerNumber(player)) + "", inputtext, "CHAR_LIFEINVADER");
            //Main.sendme
            NAPI.Notification.SendNotificationToPlayer(player, "SMS erfolgreich an Nummer gesendet " + String.Format("{0:###-###}", GetPlayerNumber(player)) + ".");
            //Main.SendMessageWithTagToPlayer(player, "" + Main.EMBED_YELLOW + "*", "SMS erfolgreich an Nummer gesendet" + String.Format("{0:###-###}", GetPlayerNumber(player)) + ".");
            NAPI.Notification.SendNotificationToPlayer(sms_handle, "SMS erhalten von " + AccountManage.GetCharacterName(player) + " N# " + String.Format("{0:###-###}", GetPlayerNumber(player)) + "");
            //Main.SendMessageWithTagToPlayer(sms_handle, "" + Main.EMBED_YELLOW + "[SMS erhalten von " + AccountManage.GetCharacterName(player) + " N# " + String.Format("{0:###-###}", GetPlayerNumber(player)) + "]", "" + Main.EMBED_YELLOW + "" + inputtext + "");
        }
        else if (response == "ADD_NAME")
        {

            string name = inputtext;

            if (name.Length < 3 || name.Length > 24)
            {
                Main.SendErrorMessage(player, "Der Name darf nicht kleiner als 3 Zeichen oder länger als 24 Zeichen sein.");
                DisplayNewContact(player);
                return;
            }

            player.SetData("contact_name", name);
            DisplayNewContact(player);
        }
        else if (response == "ADD_NUMBER")
        {

            if (!Main.IsNumeric(inputtext))
            {
                Main.SendErrorMessage(player, "Der eingegebene Wert ist keine Telefonnummer.");
                DisplayNewContact(player);
                return;
            }

            if (inputtext.Length < 3 || inputtext.Length > 24)
            {
                Main.SendErrorMessage(player, "Der eingegebene Wert ist keine Telefonnummer.");
                DisplayNewContact(player);
                return;
            }

            int number = Convert.ToInt32(inputtext);

            player.SetData("contact_number", number);
            DisplayNewContact(player);
        }
        else if (response == "PUT_ANNOUNCE")
        {
            string annouce = inputtext;

            if (inputtext.Length < 4 || inputtext.Length > 128)
            {
                Main.SendErrorMessage(player, "Die Anzeige darf nicht kleiner als 3 oder mehr als 128 Zeichen sein.");
                return;
            }

            if (Main.GetPlayerMoney(player) < 5000)
            {
                Main.SendErrorMessage(player, "Sie haben nicht genug Geld, um eine Anzeige zu versenden. Der Wert für das Senden einer Anzeige beträgt 5.000 USD pro Anzeige.");
                return;
            }

            Main.GivePlayerMoney(player, -15000);

            //  Main.SendMessageWithTagToAll("" + Main.EMBED_GREEN + "[Werbung]", "" + Main.EMBED_GREEN + "" + annouce + ". Kontaktieren Sie uns: " + AccountManage.GetCharacterName(player) + ", Mobiltelefon: " + String.Format("{0:###-###}", GetPlayerNumber(player)) + "");
            NAPI.Notification.SendNotificationToPlayer(player, "" + Main.EMBED_GREEN + "[Werbung]" + Main.EMBED_GREEN + "" + annouce + ". Kontaktieren Sie uns: " + AccountManage.GetCharacterName(player) + ", Mobiltelefon: " + String.Format("{0:###-###}", GetPlayerNumber(player)) + "");
        }
        else if (response == "ADD_UI_NAME")
        {

            string name = inputtext;
            int playerid = Main.getIdFromClient(player);

            if (name.Length < 3 || name.Length > 24)
            {
                Main.SendErrorMessage(player, "Der Name darf nicht kleiner als 3 Zeichen oder länger als 24 Zeichen sein.");
                DisplayNewContact(player);
                return;
            }

            if (name == "")
            {
                Main.SendErrorMessage(player, "Sie müssen einen Namen und eine Kontaktnummer definieren.");
                DisplayNewContact(player);
                return;
            }

            if (player.GetData("contact_number") == 999999999 || player.GetData("contact_number") == 0)
            {
                Main.SendErrorMessage(player, "Sie müssen einen Namen und eine Kontaktnummer definieren.");
                DisplayNewContact(player);
                return;
            }

            for (int i = 0; i < 60; i++)
            {
                if (cellphoneSystem.contacts_data[playerid].contact_number[i] == player.GetData("contact_number"))
                {
                    Main.SendErrorMessage(player, "Sie haben diese Nummer bereits in Ihrer Kontaktliste.");
                    return;
                }
            }

            for (int i = 0; i < 60; i++)
            {
                if (cellphoneSystem.contacts_data[playerid].contact_number[i] == 0)
                {
                    cellphoneSystem.contacts_data[playerid].contact_name[i] = name;
                    cellphoneSystem.contacts_data[playerid].contact_number[i] = player.GetData("contact_number");

                    //player.SendChatMessage("*Sie haben den Kontakt erfolgreich hinzugefügt ~b~" + name + " ~c~(Nummer #" + player.GetData("contact_number") + ")~w~ in Ihrer Kontaktliste.");

                    string query = "INSERT INTO `contacts` (owner, name, number) VALUES (" + AccountManage.GetPlayerSQLID(player) + ", '" + name + "', " + player.GetData("contact_number") + ");";
                    Main.CreateMySqlCommand(query);
                    Update_Contacts(player);
                    return;
                }
            }
            Main.SendErrorMessage(player, "Diese Nummer konnte nicht zu Ihrer Kontaktliste hinzugefügt werden.");
        }

    }

    public static void Call_Number(Client player, int target_number)
    {


        if (target_number == 0)
        {
            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Error: Diese Telefonnummer existiert nicht..", 5000);
            player.TriggerEvent("denyCall");
            return;
        }

        foreach (var service in Services.service_system)
        {
            if (service.active == 1 && service.caller == player)
            {
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Error: Dieser Bürger ist bereits in einem Gespräch.", 5000);
                player.TriggerEvent("denyCall");
                return;
            }
        }

        if (target_number == 911)
        {
            Services.Call_Service(player, 911);
            return;
        }
        else if (target_number == 912)
        {
            Services.Call_Service(player, 912);
            return;
        }
        else if (target_number == 913)
        {
            Services.Call_Service(player, 913);
            return;
        }
        else if (target_number == 914)
        {
            Services.Call_Service(player, 914);
            return;
        }
        else if (target_number == 915)
        {
            Services.Call_Service(player, 915);
            return;
        }

        foreach (var target in NAPI.Pools.GetAllPlayers())
        {
            if (target.GetData("status") == true)
            {
                if (GetPlayerNumber(target) == target_number && player != target)
                {
                    foreach (var call in call_data)
                    {
                        if (call.active == 0)
                        {
                            call.active = 1;
                            call.player_one = player;
                            call.player_two = target;

                            //NAPI.Notification.SendNotificationToPlayer(player, "Ausgehender Anruf an: " + String.Format("{0:###-###}", player.GetData("character_cellphone")) + " an.");
                            //target.TriggerEvent("Notification.SendPictureNotification", "Telefon", "Call Service", $"Eingehender Anruf");

                            Notify.Send(player, NotifyType.Success, NotifyPosition.BottomCenter, $"Ausgehender Anruf an: " + String.Format("{0:###-###}", player.GetData("character_cellphone")) + " an.", 10000);
                            Notify.Send(target, NotifyType.Success, NotifyPosition.BottomCenter, $"Eingehender Anruf", 10000);


                            List<Client> proxPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(15, player);
                            foreach (Client alvo in proxPlayers)
                            {
                                //alvo.TriggerEvent("Send_ToChat", "", "<font color ='#C2A2DA'>* Das Handy " + UsefullyRP.GetPlayerNameToTarget(player, alvo) + " klingelt");
                                // alvo.TriggerEvent("playRingtone", Main.getIdFromClient(target));
                            }
                            //Main.EmoteMessage(target, "~y~** Handy klingelt.. **");

                            int targetid = Main.getIdFromClient(target);
                            ringtone_time[targetid] = TimerEx.SetTimer(() =>
                            {

                                target.TriggerEvent("Phone_Call_inc");

                                NAPI.Task.Run(() =>
                                {
                                    target.TriggerEvent("Destroy_Phone_Call_inc");
                                }, delayTime: 5100);

                            }, 4000, 30);

                            // TogglePhone(target, true);
                            //player.TriggerEvent("Calling_Type", 1, AccountManage.GetCharacterName(target), GetPlayerNumber(target));
                            //target.TriggerEvent("Calling_Type", 4, AccountManage.GetCharacterName(player), GetPlayerNumber(player));

                            target.TriggerEvent("incomingCall", player, GetPlayerNumber(player));
                            //player.TriggerEvent("incomingCall", target, GetPlayerNumber(target));
                            return;
                        }
                    }
                }
            }
        }
        //player.TriggerEvent("incomingCall", null, target_number);
        player.TriggerEvent("denyCall");
    }

    public static void FinishCall(Client player)
    {
        foreach (var call in cellphoneSystem.call_data)
        {
            if ((call.player_one != null && NAPI.Player.IsPlayerConnected(call.player_one)) || (call.player_one != null && NAPI.Player.IsPlayerConnected(call.player_two)))
            {
                if ((call.player_one.GetData("status") == true && call.player_one == player) || (call.player_two.GetData("status") == true && call.player_two == player))
                {

                    if (call.player_one == player)
                    {
                        NAPI.Notification.SendNotificationToPlayer(call.player_two, " Der Anruf wurde abgebrochen~w~");
                        //Main.SendMessageWithTagToPlayer(call.player_two, "" + Main.EMBED_YELLOW + "[Mobiltelefon]", "" + Main.EMBED_WHITE + "" + AccountManage.GetCharacterName(player) + " wurde getrennt, der Anruf wurde abgebrochen.");
                    }
                    else if (call.player_two == player)
                    {
                        NAPI.Notification.SendNotificationToPlayer(call.player_one, "Der Anruf wurde abgebrochen.~w~");
                        //Main.SendMessageWithTagToPlayer(call.player_one, "" + Main.EMBED_YELLOW + "[Mobiltelefon]", "" + Main.EMBED_WHITE + "" + AccountManage.GetCharacterName(player) + " wurde getrennt, der Anruf wurde abgebrochen.");
                    }

                    if (cellphoneSystem.ringtone_time[Main.getIdFromClient(call.player_one)] != null)
                    {
                        cellphoneSystem.ringtone_time[Main.getIdFromClient(call.player_one)].Kill();
                        cellphoneSystem.ringtone_time[Main.getIdFromClient(call.player_one)] = null;
                    }

                    if (cellphoneSystem.ringtone_time[Main.getIdFromClient(call.player_two)] != null)
                    {
                        cellphoneSystem.ringtone_time[Main.getIdFromClient(call.player_two)].Kill();
                        cellphoneSystem.ringtone_time[Main.getIdFromClient(call.player_two)] = null;
                    }

                    Main.EmoteMessage(player, "");


                    call.active = 0;
                    call.time = 0;
                    call.player_two = null;
                    call.player_one = null;
                }
            }
        }
    }

    [Command("at", Alias = "atender")]
    public static void CMD_atender(Client player)
    {
        if (player.GetData("status") == false)
        {
            return;
        }

        if (player.GetSharedData("Injured") != 0)
        {
            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie können einen Anruf nicht beantworten, während Sie bewusstlos sind.", 5000);
            return;
        }

        if (player.GetData("playerCuffed") != 0)
        {
            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie können einen Anruf nicht mit Handschellen beantworten.", 5000);
            return;
        }

        if (player.GetData("character_prison") != 0)
        {
            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie können einen Anruf nicht beantworten, wenn Sie sich im Gefängnis befinden..", 5000);
            return;
        }


        foreach (var call in call_data)
        {
            if (call.active != 0)
            {
                if (call.player_one != null && NAPI.Player.IsPlayerConnected(call.player_one))
                {
                    if (player.GetData("status") == true && call.player_two == player)
                    {
                        call.active = 2;

                        //  NAPI.Notification.SendNotificationToPlayer(call.player_two, "Haben Sie den Anruf von angenommen " + AccountManage.GetCharacterName(player) + ".");
                        NAPI.Notification.SendNotificationToPlayer(call.player_one, "Anruf entgegen genommen");
                        //Main.SendMessageWithTagToPlayer(call.player_two, "" + Main.EMBED_YELLOW + "[Mobiltelefon]", "" + Main.EMBED_YELLOW + "Haben Sie den Anruf von angenommen " + AccountManage.GetCharacterName(player) + ".");
                        //Main.SendMessageWithTagToPlayer(call.player_one, "" + Main.EMBED_YELLOW + "[Mobiltelefon]", "" + Main.EMBED_YELLOW + "" + AccountManage.GetCharacterName(player) + " beantwortete Ihren Anruf.");

                        //Main.SendMessageWithTagToPlayer(call.player_one, "" + Main.EMBED_YELLOW + "[Mobiltelefon]", "" + Main.EMBED_WHITE + "TIPP: Drücken  " + Main.EMBED_LIGHTGREEN + "T" + Main.EMBED_WHITE + " am Telefon zu sprechen und " + Main.EMBED_LIGHTGREEN + "(/des)ligar" + Main.EMBED_WHITE + " den Anruf auflegen.");
                        //Main.SendMessageWithTagToPlayer(call.player_two, "" + Main.EMBED_YELLOW + "[Mobiltelefon]", "" + Main.EMBED_WHITE + "TIPP: Drücken  " + Main.EMBED_LIGHTGREEN + "T" + Main.EMBED_WHITE + " am Telefon zu sprechen und" + Main.EMBED_LIGHTGREEN + "(/des)ligar" + Main.EMBED_WHITE + " den Anruf auflegen.");

                        //player.TriggerEvent("changeCallStatus", 1, "Mike Bishop");

                        //Main.EmoteMessage(player, "");

                        call.player_two.TriggerEvent("callAccepted", call.player_one, GetPlayerNumber(call.player_one));
                        call.player_one.TriggerEvent("callAccepted", call.player_two, GetPlayerNumber(call.player_two));

                        call.player_two.TriggerEvent("v_reload");
                        call.player_one.TriggerEvent("v_reload");

                        if (ringtone_time[Main.getIdFromClient(player)] != null)
                        {
                            ringtone_time[Main.getIdFromClient(player)].Kill();
                            ringtone_time[Main.getIdFromClient(player)] = null;
                        }

                    }
                }
            }
        }
    }

    [Command("des", Alias = "desligar")]
    public static void CMD_desligar(Client player)
    {
        Services.Remove_Service(player);

        // =====
        foreach (var call in call_data)
        {
            if (call.active != 0)
            {
                if (NAPI.Player.IsPlayerConnected(call.player_one) || NAPI.Player.IsPlayerConnected(call.player_two))
                {
                    if ((call.player_one.GetData("status") == true && call.player_one == player) || (call.player_two.GetData("status") == true && call.player_two == player))
                    {

                        if (call.player_one == player)
                        {
                            NAPI.Notification.SendNotificationToPlayer(call.player_one, "Sie haben den Anruf aufgelegt.");
                            NAPI.Notification.SendNotificationToPlayer(call.player_two, " Anruf unterbrochen.");
                            //Main.SendMessageWithTagToPlayer(call.player_one, "" + Main.EMBED_YELLOW + "[Mobiltelefon]", "" + Main.EMBED_WHITE + "Sie haben den Anruf aufgelegt.");
                            //Main.SendMessageWithTagToPlayer(call.player_two, "" + Main.EMBED_YELLOW + "[Mobiltelefon]", "" + Main.EMBED_WHITE + "" + AccountManage.GetCharacterName(player) + " Anruf unterbrochen.");
                        }
                        else if (call.player_two == player)
                        {
                            NAPI.Notification.SendNotificationToPlayer(call.player_two, "Sie haben den Anruf aufgelegt.");
                            NAPI.Notification.SendNotificationToPlayer(call.player_one, " Anruf unterbrochen.");
                            //Main.SendMessageWithTagToPlayer(call.player_two, "" + Main.EMBED_YELLOW + "[Mobiltelefon]", "" + Main.EMBED_WHITE + "Sie haben den Anruf aufgelegt..");
                            //Main.SendMessageWithTagToPlayer(call.player_one, "" + Main.EMBED_YELLOW + "[Mobiltelefon]", "" + Main.EMBED_WHITE + "" + AccountManage.GetCharacterName(player) + " Anruf unterbrochen.");
                        }

                        if (ringtone_time[Main.getIdFromClient(call.player_one)] != null)
                        {
                            ringtone_time[Main.getIdFromClient(call.player_one)].Kill();
                            ringtone_time[Main.getIdFromClient(call.player_one)] = null;
                        }

                        if (ringtone_time[Main.getIdFromClient(call.player_two)] != null)
                        {
                            ringtone_time[Main.getIdFromClient(call.player_two)].Kill();
                            ringtone_time[Main.getIdFromClient(call.player_two)] = null;
                        }

                        call.player_two.TriggerEvent("callEnded");
                        call.player_one.TriggerEvent("callEnded");

                        call.player_two.TriggerEvent("v_reload");
                        call.player_one.TriggerEvent("v_reload");

                        call.active = 0;
                        call.time = 0;
                        call.player_two = null;
                        call.player_one = null;
                        return;
                    }
                }
            }
        }
    }

    [RemoteEvent("keypress:ARROW_UP")]
    public static void DisplayPhone(Client player)
    {
        if (player.GetData("status") == false)
        {
            //NAPI.Util.ConsoleOutput("status");
            return;
        }

        if (GetPlayerNumber(player) == 0)
        {
            //NAPI.Util.ConsoleOutput("GetPlayerNumber");
            return;
        }

        if (player.GetData("startFurnitureEditing") == true || player.GetData("startEditing") == true)
        {
            //NAPI.Util.ConsoleOutput("startFurnitureEditing");
            return;
        }

        if (player.GetData("General_CEF") == true)
        {
            //NAPI.Util.ConsoleOutput("General_CEF");
            return;
        }

        if (player.GetData("playerCuffed") != 0)
        {
            Main.SendErrorMessage(player, "Sie können das Telefon nicht mit Handschellen öffnen.");
            return;
        }

        if (player.GetData("character_prison") != 0)
        {
            Main.SendErrorMessage(player, "Sie können das Handy nicht im Gefängnis öffnen..");
            return;
        }

        if (player.HasData("startFreemode"))
        {
            //NAPI.Util.ConsoleOutput("startFreemode");
            return;
        }

        if (player.HasData("ls_customs"))
        {
            //NAPI.Util.ConsoleOutput("ls_customs");
            return;
        }

        if (player.GetData("phone_enable") == true)
        {
            //NAPI.Util.ConsoleOutput("phone_enable_false");
            TogglePhone(player, false);
        }
        else
        {
            //NAPI.Util.ConsoleOutput("phone_enable_true");
            TogglePhone(player, true);
        }
        /* List<dynamic> menu_item_list = new List<dynamic>();
         menu_item_list.Add(new { Type = 1, Name = "Ligar", Description = "", RightLabel = "", BackgroundColor = new Color(47, 172, 189), FrontColor = new Color(47, 172, 189) });
         menu_item_list.Add(new { Type = 1, Name = "Lista de Contatos", Description = "", RightLabel = "" });
         menu_item_list.Add(new { Type = 1, Name = "Serviços", Description = "", RightLabel = "" });
         menu_item_list.Add(new { Type = 1, Name = "Anunciar", Description = "", RightLabel = "" });
         player.TriggerEvent("menu_handler_create_menu_generic", "CELLPHONE_RESPONSE", "Celular", "~b~Celular - Numero ~y~#" + String.Format("{0:###-###}", GetPlayerNumber(player)) + "~b~", false, NAPI.Util.ToJson(menu_item_list), "Pagina", "Alternar entre paginas", 100);
         */
    }
    //amb@orld_human_stand_mobile@male@standing@call@base, base, 49 --- friends@laf@ig_1@base, base, 49*/

    public static void TogglePhone(Client player, bool enable)
    {
        if (enable == true)
        {
            player.SetData("phone_enable", true);
            player.TriggerEvent("openPhone");
			
            if (!player.IsInVehicle)
            {
                Main.AttachObjectToEntity("p_amb_phone_01", player.Value, 28422);
                player.PlayAnimation("amb@code_human_wander_texting@female@base", "static", 1 << 0 | 1 << 4 | 1 << 5);
            }
            else
            {

            } 
        }
        else
        {
            player.SetData("phone_enable", false);
            Update_Contacts(player);
			
            if (!player.IsInVehicle)
            {
                player.StopAnimation();
                Main.DeleteAttachedObject(player);
            }
            else
            {

            }
            
            player.TriggerEvent("closePhone");
        }
    }

    public static void Update_Contacts(Client player)
    {
        int playerid = Main.getIdFromClient(player);
        List<dynamic> menu_item_list = new List<dynamic>();

        for (int i = 0; i < 60; i++)
        {
            if (cellphoneSystem.contacts_data[playerid].contact_number[i] != 0)
            {
                menu_item_list.Add(new { index = i, name = cellphoneSystem.contacts_data[playerid].contact_name[i], number = cellphoneSystem.contacts_data[playerid].contact_number[i] });

            }
        }
        player.TriggerEvent("Update_Contacts", NAPI.Util.ToJson(menu_item_list));
    }

    [RemoteEvent("Show_SMS")]
    public static void Show_SMS(Client player)
    {
        //API.Util.ConsoleOutput("send");
        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {
            Mainpipeline.Open();
            MySqlCommand query = new MySqlCommand("SELECT * FROM `sms` WHERE `send_from_id` = '" + GetPlayerNumber(player) + "' OR `send_to_id` = '" + GetPlayerNumber(player) + "' ORDER BY id DESC LIMIT 60;", Mainpipeline);

            List<dynamic> menu_item_list = new List<dynamic>();
            using (MySqlDataReader reader = query.ExecuteReader())
            {
                string data2txt = string.Empty;
                string datatxt = string.Empty;

                int count = 0;
                while (reader.Read())
                {
                    int can_pass = 0;
                    foreach (var data in menu_item_list)
                    {
                        if (data.number == reader.GetInt32("send_from_id") || data.number == reader.GetInt32("send_to_id"))
                        {
                            can_pass = 1;
                        }
                    }

                    // 

                    if (can_pass == 0)
                    {
                        if (GetPlayerNumber(player) != reader.GetInt32("send_to_id"))
                        {
                            menu_item_list.Add(new { number = reader.GetInt32("send_to_id"), name = reader.GetString("send_to_name"), text = reader.GetString("message") });
                        }
                        else if (GetPlayerNumber(player) != reader.GetInt32("send_from_id"))
                        {
                            menu_item_list.Add(new { number = reader.GetInt32("send_from_id"), name = reader.GetString("send_from_name"), text = reader.GetString("message") });
                        }
                    }
                    count++;
                }
            }

            player.TriggerEvent("Update_SMS_List", NAPI.Util.ToJson(menu_item_list));
        }
    }

    [RemoteEvent("Update_SMS")]
    public static void Update_SMS(Client player, int number)
    {
        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {
            Mainpipeline.Open();
            MySqlCommand query = new MySqlCommand("SELECT * FROM `sms` WHERE `send_from_id` = '" + number + "' AND `send_to_id` = '" + GetPlayerNumber(player) + "' OR `send_from_id` = '" + GetPlayerNumber(player) + "' AND `send_to_id` = '" + number + "'  LIMIT 60;", Mainpipeline);

            List<dynamic> menu_item_list = new List<dynamic>();
            using (MySqlDataReader reader = query.ExecuteReader())
            {
                string data2txt = string.Empty;
                string datatxt = string.Empty;

                int count = 0;
                while (reader.Read())
                {
                    if (reader.GetInt32("send_from_id") == GetPlayerNumber(player)) // you
                    {
                        menu_item_list.Add(new { text = reader.GetString("message"), by = "Du" });
                    }
                    else if (reader.GetInt32("send_to_id") == GetPlayerNumber(player)) // him
                    {
                        menu_item_list.Add(new { text = reader.GetString("message"), by = reader.GetString("send_from_name") });
                    }
                    count++;
                }
            }

            player.TriggerEvent("Update_SMS_Web", NAPI.Util.ToJson(menu_item_list));
        }
    }

    [RemoteEvent("Solicitar_Servico")]
    public static void Send_SMS2(Client player, int service)
    {
        switch (service)
        {
            case 1:
                {
                    CallSystem.SelectMenuResponse(player, "CALL_SYSTEM_RESPONSE", 1, "", "");
                    break;
                }
            case 2:
                {
                    CallSystem.SelectMenuResponse(player, "CALL_SYSTEM_RESPONSE", 0, "", "");
                    break;
                }
            case 3:
                {
                    CallSystem.SelectMenuResponse(player, "CALL_SYSTEM_RESPONSE", 3, "", "");
                    break;
                }
            case 4:
                {
                    CallSystem.SelectMenuResponse(player, "CALL_SYSTEM_RESPONSE", 2, "", "");
                    break;
                }
        }
    }

    [RemoteEvent("Send_SMS_SERVER")]
    public static void Send_SMS(Client player, string number, string texto)
    {
        string sms_text = texto;

        if (sms_text.Length < 5 || sms_text.Length > 128)
        {
            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Die Anzahl der Zeichen darf nicht weniger als 5 Zeichen oder mehr als 120 Zeichen betragen.", 5000);
            return;
        }

        if (!Main.IsNumeric(number))
        {
            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Die eingegebene Nummer ist keine Telefonnummer..", 5000);
            return;
        }

        int numero = Convert.ToInt32(number);

        foreach (var target in NAPI.Pools.GetAllPlayers())
        {
            if (target.GetData("status") == true)
            {
                if (GetPlayerNumber(target) == numero)
                {
                    if (!NAPI.Player.IsPlayerConnected(target))
                    {
                        Main.SendErrorMessage(player, "Dieser Spieler ist nicht angemeldet.");
                        return;
                    }

                    if (target.GetData("status") == false)
                    {
                        Main.SendErrorMessage(player, "Dieser Spieler ist nicht angemeldet.");
                        return;
                    }

                    if (player == target)
                    {
                        Main.SendErrorMessage(player, "Sie können keine Nachricht an sich selbst senden.");
                        return;
                    }

                    string query = "INSERT INTO `sms` (send_from_id, send_from_name, send_to_id, send_to_name, message) VALUES (" + GetPlayerNumber(player) + ", '" + AccountManage.GetCharacterName(player) + "', " + GetPlayerNumber(target) + ", '" + AccountManage.GetCharacterName(target) + "', '" + texto + "');";
                    Main.CreateMySqlCommand(query);
                    player.TriggerEvent("Phone_SMS_send");
                    NAPI.Notification.SendNotificationToPlayer(player, "SMS wurde erfolgreich an die Nummer " + String.Format("{0:###-###}", GetPlayerNumber(target)) + " gesendet.");
                    NAPI.ClientEvent.TriggerClientEvent(target, "Notification.SendPictureNotification", "Telefon", "SMS Service", $"SMS erhalten.");
                    target.TriggerEvent("Phone_SMS_inc");

                    NAPI.Task.Run(() =>
                    {
                            player.TriggerEvent("Destroy_Phone_SMS_send");
                    }, delayTime: 3500);

                    NAPI.Task.Run(() =>
                    {
                            target.TriggerEvent("Destroy_Phone_SMS_inc");
                    }, delayTime: 10100);
                    Update_SMS(player, GetPlayerNumber(target));
                    Update_SMS(target, GetPlayerNumber(player));
                    return;
                }
            }
        }
        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Wir können Ihre SMS nicht senden!", 5000);
    }

    [RemoteEvent("Add_Contact")]
    public static void Add_Contact(Client player, int number, string name)
    {
        int playerid = Main.getIdFromClient(player);

        if (name.Length < 3 || name.Length > 24)
        {
            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Der Name darf nicht kleiner als 3 Zeichen und nicht länger als 24 Zeichen sein.", 5000);
            return;
        }

        if (name == "")
        {
            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie müssen einen Namen und eine Kontaktnummer definieren.", 5000);
            return;
        }

        if (number == 999999999 || number == 0)
        {

            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie müssen einen Namen und eine Kontaktnummer definieren.", 5000);
            return;
        }

        for (int i = 0; i < 60; i++)
        {
            if (cellphoneSystem.contacts_data[playerid].contact_number[i] == number)
            {
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie haben diese Nummer bereits in Ihrer Kontaktliste.", 5000);
                return;
            }
        }

        for (int i = 0; i < 60; i++)
        {
            if (cellphoneSystem.contacts_data[playerid].contact_number[i] == 0)
            {
                cellphoneSystem.contacts_data[playerid].contact_name[i] = name;
                cellphoneSystem.contacts_data[playerid].contact_number[i] = number;

                NAPI.Notification.SendNotificationToPlayer(player, "Sie haben den Kontakt erfolgreich hinzugefügt~b~" + name + " ~c~(Nummer #" + number + ")~w~ in Ihrer Kontaktliste.");

                //player.SendChatMessage("* Sie haben den Kontakt erfolgreich hinzugefügt~b~" + name + " ~c~(Nummer #" + number + ")~w~ in Ihrer Kontaktliste.");

                string query = "INSERT INTO `contacts` (owner, name, number) VALUES (" + AccountManage.GetPlayerSQLID(player) + ", '" + name + "', " + number + ");";
                Main.CreateMySqlCommand(query);
                Update_Contacts(player);
                player.TriggerEvent("startApp", "contacts");
                return;
            }
        }
        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Diese Nummer konnte nicht zu Ihrer Kontaktliste hinzugefügt werden", 5000);
    }

    [RemoteEvent("onClientRequestContactList")]
    public static void onClientRequestContactList(Client player)
    {
        NAPI.Chat.SendChatMessageToAll("onClientRequestContactList");
        Update_Contacts(player);

    }

    [RemoteEvent("onClientRequestCallPlayer")]
    public static void onClientRequestCallPlayer(Client player, int number)
    {
        NAPI.Chat.SendChatMessageToAll("onClientRequestCallPlayer: " + number + "");
        Call_Number(player, number);

    }

    [RemoteEvent("onClientRequestRemovePlayerContact")]
    public static void onClientRequestRemovePlayerContact(Client player, int number)
    {
        NAPI.Notification.SendNotificationToPlayer(player, "Nummer gelöscht: " + number + "");

        int playerid = Main.getIdFromClient(player);
        for (int i = 0; i < 60; i++)
        {
            if (contacts_data[playerid].contact_number[i] == number)
            {

                player.SendChatMessage("* Sie haben gelöscht ~b~" + cellphoneSystem.contacts_data[playerid].contact_name[i] + " ~c~(Nummer #" + cellphoneSystem.contacts_data[playerid].contact_number[i] + ")~w~ aus Ihrer Kontaktliste.");
                // DEL 2
                Main.CreateMySqlCommand("DELETE FROM `contacts` WHERE `number` = '" + cellphoneSystem.contacts_data[playerid].contact_number[i] + "';");

                cellphoneSystem.contacts_data[playerid].contact_name[i] = null;
                cellphoneSystem.contacts_data[playerid].contact_number[i] = 0;

                Update_Contacts(player);
                return;
            }
        }
    }

    [RemoteEvent("onClientRequestAddPlayerContact")]
    public static void onClientRequestAddPlayerContact(Client player, int number)
    {
        InteractMenu.User_Input(player, "ADD_UI_NAME", "Kontaktname", "Geben Sie einen Namen ein");
        player.SetData("contact_number", number);
    }

    [RemoteEvent("onClientRejectedCall")]
    public static void onClientRejectedCall(Client player)
    {
        CMD_desligar(player);
    }

    [RemoteEvent("onClientAcceptCall")]
    public static void onClientAcceptCall(Client player)
    {
        CMD_atender(player);
    }

    [RemoteEvent("onClientHandyOff")]
    public static void onClientHandyOff(Client player, string username)
    {
    }

    [RemoteEvent("onClientRequestNews")]
    public static void onClientRequestNews(Client player)
    {
    }

    [RemoteEvent("onClientHandyOn")]
    public static void onClientHandyOn(Client player, string username)
    {
    }

    [RemoteEvent("onClientAddNews")]
    public static void onClientAddNews(Client player, string jsonData)
    {
        var data = NAPI.Util.FromJson(jsonData);
        //NAPI.Util.ConsoleOutput("" + data.ToString() + "");
    }

    [RemoteEvent("onClientAddAds")]
    public static void onClientAddAds(Client player, string jsonData)
    {
        var data = NAPI.Util.FromJson(jsonData);
        //NAPI.Util.ConsoleOutput("" + data.ToString() + "");
    }

    [RemoteEvent("onClientUpdateNews")]
    public static void onClientUpdateNews(Client player, string jsonData)
    {
        var data = NAPI.Util.FromJson(jsonData);
        //NAPI.Util.ConsoleOutput("" + data.ToString() + "");
    }

    [RemoteEvent("onClientUpdateAds")]
    public static void onClientUpdateAds(Client player, string jsonData)
    {
        var data = NAPI.Util.FromJson(jsonData);
        //NAPI.Util.ConsoleOutput("" + data.ToString() + "");
    }

    [RemoteEvent("onClientDeleteNews")]
    public static void onClientDeleteNews(Client player, int id)
    {
        NAPI.Chat.SendChatMessageToAll("onClientDeleteNews: " + id + "");
    }

    [RemoteEvent("onClientDeleteAds")]
    public static void onClientDeleteAds(Client player, int id)
    {
        NAPI.Chat.SendChatMessageToAll("onClientDeleteAds: " + id + "");
    }

    [RemoteEvent("callTaxiDriver")]
    public static void callTaxiDriver(Client player, string name)
    {

    }

    [RemoteEvent("requestTaxiDrivers")]
    public static void requestTaxiDrivers(Client player)
    {

    }

    [RemoteEvent("onClientSendPosition")]
    public static void onClientSendPosition(Client player)
    {

    }

    // New Phone
    [RemoteEvent("cancelCallingNumber")]
    public static void requestPlayerPhoneCalls(Client player)
    {
        CMD_desligar(player);
    }

    [RemoteEvent("acceptCall")]
    public static void acceptCall(Client player, int number)
    {
        CMD_atender(player);
    }

    [RemoteEvent("callNumber")]
    public static void callNumber(Client player, int number)
    {
    }

    [RemoteEvent("dialingNumber")]
    public static void dialingNumber(Client player, int number)
    {
        Call_Number(player, number);
    }
}
