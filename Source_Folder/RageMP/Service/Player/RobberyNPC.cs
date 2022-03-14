using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;
using DerStr1k3r.Core;

class RobberyNPC : Script
{

    public static TimerEx[] player_robbery_timer { get; set; } = new TimerEx[Main.MAX_PLAYERS];

    public static int SETTINGS_COPS_NEEDED = 3;
    public static int MAX_ROBBERY_NPC = 0;
    public class RobberyNPCEnum : IEquatable<RobberyNPCEnum>
    {
        public int id { get; set; }
        public string model { get; set; }
        public Vector3 position { get; set; }
        public Vector3 caixa_1 { get; set; }
        public Vector3 caixa_2 { get; set; }
        public TextLabel textlabel { get; set; }
        public float heading { get; set; }
        public int robbery_state { get; set; }
        public int money { get; set; }
        //public Player owned { get; set; }
        public int time_remaining { get; set; }
        public DateTime time_vulnerable { get; set; }
        public int players_aiming { get; set; }
        public int cash_amount { get; set; }
        public override int GetHashCode()
        {
            return id;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            RobberyNPCEnum objAsPart = obj as RobberyNPCEnum;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }

        public bool Equals(RobberyNPCEnum other)
        {
            if (other == null) return false;
            return (this.id.Equals(other.id));
        }
    }
    public static List<RobberyNPCEnum> robbery_npc = new List<RobberyNPCEnum>();
    private static bool targetx;

    public static void CreateRobberyNPC(string model, Vector3 position, float heading, Vector3 caixa_1, Vector3 caixa_2)
    {
        robbery_npc.Add(new RobberyNPCEnum { id = MAX_ROBBERY_NPC, model = model, position = position, heading = heading, robbery_state = 0, players_aiming = 0, caixa_1 = caixa_1, caixa_2 = caixa_2, textlabel = NAPI.TextLabel.CreateTextLabel("[ ~b~Besitzer~w~ ]~n~~n~~y~((~w~ John ~y~))", position + new Vector3(0, 0, 1.15), 5.0f, 0.3f, 4, new Color(255, 255, 255, 255), false, 0) });

        MAX_ROBBERY_NPC++;
    }

    public RobberyNPC()
    {
        CreateRobberyNPC("ig_popov", new Vector3(24.47675, -1347.312, 29.49702), 266.0985f, new Vector3(24.47675, -1347.312, 29.49702), new Vector3(24.47675, -1347.312, 29.49702));

        OnRobberyTimer();
    }

    public static void OnPlayerConnect(Client player)
    {
        player.ResetData("store_rob");
        player.SetSharedData("Player_Aiming_To", -1);
        int index = 0;
        foreach (var robbery in robbery_npc)
        {
            player.TriggerEvent("CreateRobberyNPC", "robbery_npc_" + index, robbery.model, robbery.position, robbery.heading, index);
            index++;
        }
    }

    public void OnRobberyTimer()
    {
        TimerEx.SetTimer(() =>
        {
            int index = 0;
            foreach (var robbery in robbery_npc)
            {

                if (robbery.robbery_state == 1)
                {
                    if (robbery.time_remaining > 0)
                    {
                        robbery.time_remaining--;
                    }

                    if (robbery.time_remaining == 0)
                    {
                        robbery.robbery_state = 0;
                        robbery.time_remaining = 0;

                        robbery.time_vulnerable = DateTime.Now.AddMinutes(10);
                        robbery.textlabel.Text = "[ ~b~Besitzer 24-7~w~ ]~n~~n~~y~((~w~ Scott ~y~))";
                    }

                    int count = 0;
                    foreach (var player in NAPI.Pools.GetAllPlayers())
                    {
                        if (player.GetData("status") == true && Main.IsInRangeOfPoint(player.Position, robbery.position, 30.0f) && player.GetSharedData("Player_Aiming_To") == index)
                        {
                            count++;
                        }
                    }

                    if (count == 0)
                    {
                        UpdateRobberyState(index, 0);
                        robbery.textlabel.Text = "[ ~b~Besitzer 24-7~w~ ]~n~~n~~y~((~w~ Scott ~y~))";
                    }
                    else
                    {
                        UpdateRobberyState(index, 1);
                        robbery.textlabel.Text = "** Eingeschüchtert **~w~~n~~n~[ ~b~Besitzer 24-7~w~ ]~n~~n~~y~((~w~ Scott ~y~))";
                    }
                }
                index++;
            }
        }, 1000, 0);
    }

    public static void UpdateRobberyState(int index, int state)
    {
        foreach (var player in NAPI.Pools.GetAllPlayers())
        {
            if (player.GetData("status") == true && Main.IsInRangeOfPoint(player.Position, robbery_npc[index].position, 30.0f))
            {
                player.TriggerEvent("SetRobberyState", "robbery_npc_" + index, state);
            }
        }
    }

    public static void keyPressY(Client player)
    {
        foreach (var robbery in robbery_npc)
        {
            if (Main.IsInRangeOfPoint(player.Position, robbery.position, 3.0f) && robbery.robbery_state == 1)
            {
                if (player.HasData("store_rob"))
                {
                    player.StopAnimation();
                    player.ResetData("store_rob");

                    try
                    {
                        player_robbery_timer[Main.getIdFromClient(player)].Kill();
                    }
                    catch
                    {

                    }
                    return;
                }
                player.SetData("store_rob", true);
                player.PlayAnimation("oddjobs@shop_robbery@rob_till", "loop", 49);

                player_robbery_timer[Main.getIdFromClient(player)] = TimerEx.SetTimer(() =>
                {

                    if (robbery.cash_amount > 500)
                    {
                        int money = 0;
                        Random rnd = new Random();
                        money = rnd.Next(350, 500);
                        robbery.cash_amount -= money;
                        Inventory.GiveItemToInventory(player, 158, money);

                        player.TriggerEvent("createNewHeadNotificationAdvanced", "Sie haben ~b~$" + money + "~w~ von der Kasse bekommen!");
                    }
                    else
                    {
                        if (robbery.cash_amount > 0)
                        {

                            Inventory.GiveItemToInventory(player, 158, robbery.cash_amount);
                            robbery.cash_amount = 0;
                            player.TriggerEvent("createNewHeadNotificationAdvanced", "Sie haben ~b~$" + robbery.cash_amount + "~w~ von der Kasse bekommen!");
                        }

                        robbery.time_vulnerable = DateTime.Now.AddMinutes(10);

                        player.StopAnimation();

                        player_robbery_timer[Main.getIdFromClient(player)].Kill();

                        UpdateRobberyState(robbery.id, 0);
                        robbery.robbery_state = 0;
                        robbery.time_remaining = 0;

                        robbery.textlabel.Text = "[ ~b~Besitzer des 24-7~w~ ]~n~~n~~y~((~w~ Scott ~y~))";
                    }
                }, 25000, 0);
                return;
            }
        }
    }

    [RemoteEvent("Players_Aiming_To")]
    public static void startRobbery(Client player, int index)
    {
        if (index != -1)
        {
            if (Main.IsInRangeOfPoint(player.Position, robbery_npc[index].position, 10.0f))
            {
                if (robbery_npc[index].robbery_state == 0)
                {
                    if (DateTime.Now < robbery_npc[index].time_vulnerable)
                    {
                        NAPI.Notification.SendNotificationToPlayer(player, "Dieser Shop wurde in Kürze überfallen!");
                        return;
                    }

                    if ((WeaponHash)player.GetData("primary_weapon") == 0 && (WeaponHash)player.GetData("secundary_weapon") == 0)
                    {
                        Main.DisplaySubtitle(player, "Sie haben keine Waffe, da dies den Begleiter aus dem Laden einschüchtern wird. :(");
                        return;
                    }

                    int can_pass = 0;

                    if (NAPI.Player.GetPlayerCurrentWeapon(player) != WeaponHash.Unarmed)
                    {
                        can_pass = 1;
                    }
                    else if (NAPI.Player.GetPlayerCurrentWeapon(player) != WeaponHash.Unarmed)
                    {
                        can_pass = 1;
                    }

                    if (can_pass == 0)
                    {
                        Main.DisplaySubtitle(player, "Sie haben Ihre Waffe nicht in der Hand, da dies den Begleiter aus dem Laden einschüchtern wird. :(");
                        return;
                    }

                    //if (FactionManage.GetPlayerGroupType(player) != 0)
                    //{
                      //  Main.DisplaySubtitle(player, "Nur Bandenmitglieder können einen Einbruch einleiten.");
                        //return;
                    //}

                    int count = 0;
                    foreach (var target in NAPI.Pools.GetAllPlayers())
                    {
                        if (target.GetData("status") == true && AccountManage.GetPlayerGroup(target) == AccountManage.GetPlayerGroup(player) && Main.IsInRangeOfPoint(target.Position, player.Position, 20.0f))
                        {
                            count++;
                        }
                    }

                    //if (count == 0)
                    //{
                    //    Main.DisplaySubtitle(player, "Du brauchst mindestens ein weiteres Mitglied deiner Bande, um diesen Shop auszurauben.");
                    //    return;
                    //}

                    int faction_id = AccountManage.GetPlayerGroup(player);

                    if (player.GetData("status") == true && FactionManage.GetPlayerGroupType(player) == 1)
                    {
                        NAPI.Notification.SendNotificationToPlayer(player, "Der ~b~Super Markt Strawberry  ~w~wird gerade überfallen!");
                    }
                    //Main.SendMessageToAll(Main.EMBED_LIGHTRED + "[Diebstahl]:~w~ Ein ~b~SuperMarket ~w~wird gerade überfalln! " + Main.EMBED_LIGHTRED + "" + FactionManage.faction_data[faction_id].faction_name + "" + Main.EMBED_WHITE + ".");
                    NAPI.Notification.SendNotificationToPlayer(player,Main.EMBED_GREY + "Schauen Sie weiter in den Begleiter des Ladens, während Ihr Freund das Geld klaut.");

                    foreach (var target in NAPI.Pools.GetAllPlayers())
                    {
                        if (target.GetData("status") == true && AccountManage.GetPlayerGroup(target) == AccountManage.GetPlayerGroup(player) && Main.IsInRangeOfPoint(target.Position, player.Position, 20.0f))
                        {
                            Police.SetPlayerCrime(target, "24-7", "Unbekannt", 3);
                        }
                    }

                    foreach (var target in NAPI.Pools.GetAllPlayers())
                    {
                        if (target.GetData("status") == true && AccountManage.GetPlayerGroup(target) == 1)
                        {
                            NAPI.Notification.SendNotificationToPlayer(player, "Achtung alle Einheiten, der Super Markt Strawberry wird überfallen, stoppen Sie alles, was Sie gerade tun, und beantworten Sie diesen Anruf jetzt!");
                            target.TriggerEvent("gps_set_loc", player.Position.X, player.Position.Y);
                            //Main.SendMessageWithTagToPlayer(target, "" + Main.EMBED_BLUE + "[Central]", "" + Main.EMBED_BLUE + "Achtung alle Einheiten, die SuperMarkt wir überfalles, stoppen Sie alles, was Sie gerade tun, und beantworten Sie diesen Anruf jetzt!");
                        }
                    }

                    robbery_npc[index].time_remaining = 300;
                    robbery_npc[index].cash_amount = 1500;
                    robbery_npc[index].robbery_state = 1;
                    UpdateRobberyState(index, 1);
                }
            }
        }
        player.SetSharedData("Player_Aiming_To", index);
    }
}
