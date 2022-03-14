using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;
using DerStr1k3r.Core;

class bankRobbery : Script
{
    public static int SETTINGS_COPS_NEEDED = 4;
    public static int SETTINGS_MEMBERS_NEEDED = 0;

    public static int SETTINGS_CRATE_MONEY_MIN = 20000;
    public static int SETTINGS_CRATE_MONEY_MAX = 30000;


    public static int SETTINGS_TABLE_MONEY_MIN = 40000;
    public static int SETTINGS_TABLE_MONEY_MAX = 50000;

    public static int SETTINGS_TO_OPEN_BANK_AFTER_ROBBERY = 150000; // 150000 = 150 segundos
    public static int SETTINGS_EXPLODE_TIME_C4 = 15; // 15 = 15 seconds

    //
    public static Entity drill = null;
    public static TextLabel drill_label = null;
    public static int drill_timer = 0;
    public static int drill_stage = 0;

    public static Entity vault_door = null;
    public static TextLabel vault_label = null;
    public static int vault_timer = 0;
    public static int vault_stage = 0;
    public static Entity[] mines { get; set; } = new Entity[4];
    public static Entity[] money_crate { get; set; } = new Entity[4];
    public static TextLabel[] money_crate_label { get; set; } = new TextLabel[4];
    public static int[] money_crate_stage { get; set; } = new int[4];
    public static int[] money_crate_money { get; set; } = new int[4];

    public static Entity cash_prop = null;
    public static int cash_prop_stage = 0;
    public static TextLabel cash_prop_label = null;
    public static int cash_prop_money = 0;

    //
    // Door Pacific Standard
    //
    public static bool drill_door_lock_status = true;
    public static bool bank_door_lock = false;
    public static bool enable_bank_robbery = true;
    public static int main_robbery_bank_stage = 0;
    public static TimerEx timeout_bank_robbery = null;

    //mp_heists@keypad@   idle_a

    public bankRobbery()
    {
        Random rnd = new Random();

        // Remove Door
        NAPI.World.DeleteWorldProp(961976194, new Vector3(254.0934, 225.13, 101.875), 40f);

        // Money Crate (empty: -1823263496)
        money_crate[0] = NAPI.Object.CreateObject(-464691988, new Vector3(255.842f, 215.5436f, 100.6834f), new Vector3(0f, 0f, 160.9986f));
        money_crate[1] = NAPI.Object.CreateObject(-464691988, new Vector3(253.7108f, 216.2055f, 100.6834f), new Vector3(0f, 0f, -19.99997f));
        money_crate[2] = NAPI.Object.CreateObject(-464691988, new Vector3(254.8175f, 215.8692f, 100.6834f), new Vector3(0f, 0f, 160.0006f));
        money_crate[3] = NAPI.Object.CreateObject(-464691988, new Vector3(256.9454f, 218.621f, 100.6834f), new Vector3(0f, 0f, -19.99994f));

        // Prop cash (empty: 769923921)
        cash_prop = NAPI.Object.CreateObject(269934519, new Vector3(255.8385f, 219.0404f, 101.02f), new Vector3(0f, 0f, 159.9991f));
        
        // Envelope
        NAPI.Object.CreateObject(-293267906, new Vector3(264.0015f, 213.7646f, 101.55f), new Vector3(-86.00077f, 0.03051601f, -122.7f));

        // Maleta (empty: 359105829)
        NAPI.Object.CreateObject(-1787068858, new Vector3(264.3554f, 213.5008f, 101.55f), new Vector3(0f, 0f, 5.999181f));

        // Prop gold
        // Stage: 1 (-1802035584)
        // Stage: 2 (1240336683)
        // Stage: 3 (-1324034181)
        // Stage: 4 empty (-1479600188)
        NAPI.Object.CreateObject(1910485680, new Vector3(263.26f, 216.37f, 101.05f), new Vector3(0.250013f, 3.596521E-05f, -20.70002f));

        // relogio
        NAPI.Object.CreateObject(-569858002, new Vector3(264.8557f, 214.2736f, 101.5327f), new Vector3(0f, 0f, 106.9995f));

        //
        vault_door = NAPI.Object.CreateObject(961976194, new Vector3(255.23f, 224.01f, 102.4008f), new Vector3(0f, 0f, 160f));

        
        for(int i = 0; i < money_crate.Length; i++)
        {
            money_crate_money[i] = rnd.Next(SETTINGS_CRATE_MONEY_MIN, SETTINGS_CRATE_MONEY_MAX);
            money_crate_label[i] = NAPI.TextLabel.CreateTextLabel("~s~Kasse~n~~c~(Geld zur Verfügung ~s~$"+ money_crate_money[i].ToString("N0") + "~c~) ", new Vector3(money_crate[i].Position.X, money_crate[i].Position.Y, money_crate[i].Position.Z + 0.8), 10, 0.30f, 4, new Color(7, 163, 30, 190));
            money_crate_stage[i] = 0;
        }


        cash_prop_money = rnd.Next(SETTINGS_TABLE_MONEY_MIN, SETTINGS_TABLE_MONEY_MAX);
        cash_prop_label = NAPI.TextLabel.CreateTextLabel("~s~Cash Tabelle~n~~c~(Geld zur Verfügung: ~s~$"+ cash_prop_money.ToString("N0") + "~c~)", new Vector3(cash_prop.Position.X, cash_prop.Position.Y, cash_prop.Position.Z + 0.8), 10, 0.30f, 4, new Color(7, 163, 30, 190));

        drill_label = NAPI.TextLabel.CreateTextLabel("~y~Aufbohren~n~~n~~c~[Drücke ~w~O~c~]", new Vector3(257.4, 219.99, 106.75), 10, 0.30f, 4, new Color(7, 163, 30, 190));

        vault_label = NAPI.TextLabel.CreateTextLabel("~y~Platziere C4~n~~n~~c~[Drücke ~w~E~c~]", new Vector3(253.9785, 225.0538, 101.8757), 10, 0.30f, 4, new Color(7, 163, 30, 190));

        //
        OnRobberyTimer();
    }

    public static void ResetBankRobbery()
    {
        Random rnd = new Random();
        money_crate[0].Delete();
        money_crate[1].Delete();
        money_crate[2].Delete();
        money_crate[3].Delete();

        money_crate[0] = NAPI.Object.CreateObject(-464691988, new Vector3(255.842f, 215.5436f, 100.6834f), new Vector3(0f, 0f, 160.9986f));
        money_crate[1] = NAPI.Object.CreateObject(-464691988, new Vector3(253.7108f, 216.2055f, 100.6834f), new Vector3(0f, 0f, -19.99997f));
        money_crate[2] = NAPI.Object.CreateObject(-464691988, new Vector3(254.8175f, 215.8692f, 100.6834f), new Vector3(0f, 0f, 160.0006f));
        money_crate[3] = NAPI.Object.CreateObject(-464691988, new Vector3(256.9454f, 218.621f, 100.6834f), new Vector3(0f, 0f, -19.99994f));

        cash_prop.Delete();
        cash_prop = NAPI.Object.CreateObject(269934519, new Vector3(255.8385f, 219.0404f, 101.02f), new Vector3(0f, 0f, 159.9991f));

        vault_door.Position = new Vector3(255.23f, 224.01f, 102.4008f);
        vault_door.Rotation = new Vector3(0f, 0f, 160f);


        for (int i = 0; i < money_crate.Length; i++)
        {
            money_crate_money[i] = rnd.Next(SETTINGS_CRATE_MONEY_MIN, SETTINGS_CRATE_MONEY_MAX);
            money_crate_label[i].Text = "~s~Kasse~n~~c~(Geld zur Verfügung: ~s~$" + money_crate_money[i].ToString("N0") + "~c~)";
            money_crate_stage[i] = 0;
        }

        cash_prop_money = rnd.Next(SETTINGS_TABLE_MONEY_MIN, SETTINGS_TABLE_MONEY_MAX);
        cash_prop_label.Text = "~s~Cash-Tabelle~n~~c~(Geld zur Verfügung: ~s~$" + cash_prop_money.ToString("N0") + "~c~)";

        drill_label.Text = "~y~Aufbohren~n~~n~~c~[Drücke ~w~O~c~]";

        vault_label.Text = "~y~Platziere C4~n~~n~~c~[Drücke ~w~E~c~]";

        main_robbery_bank_stage = 0;
        enable_bank_robbery = false;
    }


    public static void KeyPressY(Client player)
    {
        
        if (Main.IsInRangeOfPoint(player.Position, new Vector3(257.4, 219.65, 106.4), 2.0f) && main_robbery_bank_stage == 1)
        {
            player.TriggerEvent("SetBlackoutState", true);

            if (Inventory.GetPlayerItemFromInventory(player, 20)  < 1)
            {
                player.TriggerEvent("SetBlackoutState", false);
                NAPI.Notification.SendNotificationToPlayer(player, "Du hast nicht alles dabei!");
                return;
            }

            Inventory.RemoveItemByType(player, 20, 1);

            player.PlayAnimation("weapons@first_person@aim_rng@generic@projectile@sticky_bomb@", "plant_vertical", (int)(Main.AnimationFlags.Loop));

            main_robbery_bank_stage = 2;
            TimerEx.SetTimer(() =>
            {
                player.StopAnimation();

                drill = NAPI.Object.CreateObject(-443429795, new Vector3(257.4, 219.65, 106.4), new Vector3(0f, 0f, 160.25f));
                drill_timer = 60;
                drill_stage = 1;
                main_robbery_bank_stage = 2;
            }, 1800, 1);

            
        }

        //NAPI.Util.ConsoleOutput(""+ vault_stage + " -- "+ main_robbery_bank_stage + "");
        if (Main.IsInRangeOfPoint(player.Position, new Vector3(253.9785, 225.0538, 101.8757), 1.0f) && vault_stage == 0 && main_robbery_bank_stage == 2)
        {
            player.TriggerEvent("SetBlackoutState", true);
            if (Inventory.GetPlayerItemFromInventory(player, 19) < 4)
            {
                player.TriggerEvent("SetBlackoutState", false);
                NAPI.Notification.SendNotificationToPlayer(player, "Du hast nicht alles dabei!");
                return;
            }

            Inventory.RemoveItemByType(player, 19, 1);

            mines[0] = NAPI.Object.CreateObject(-1266278729, new Vector3(254.6958f, 224.2552f, 102.2034f), new Vector3(0f, 0f, 162.9988f));
            mines[1] = NAPI.Object.CreateObject(-1266278729, new Vector3(252.9819f, 224.9136f, 102.0892f), new Vector3(0f, 0f, 159.9984f));
            mines[2] = NAPI.Object.CreateObject(-2033654589, new Vector3(253.789f, 224.6199f, 101.4626f), new Vector3(0f, 0f, 163.0002f));
            mines[3] = NAPI.Object.CreateObject(-2033654589, new Vector3(253.8049f, 224.6141f, 103.1451f), new Vector3(0f, 0f, 164.9989f));

            UsefullyRP.SendRoleplayAction(player, "platziert C4 an die sichere Tür.");
            //Main.EmoteMessage(player, "* platziert C4 an die sichere Tür *");
            NAPI.Notification.SendNotificationToPlayer(player, "* platziert C4 an die sichere Tür *");
            Main.DisplaySubtitle(player, "Die Bombe explodiert in ~y~10 sekunden~s~ hau ab!");

            vault_timer = SETTINGS_EXPLODE_TIME_C4;
            vault_stage = 1;

            main_robbery_bank_stage = 3;
            player.PlayAnimation("weapons@first_person@aim_rng@generic@projectile@sticky_bomb@", "plant_vertical", (int)(Main.AnimationFlags.Loop));
            TimerEx.SetTimer(() =>
            {
                player.StopAnimation();
            }, 1800, 1);

            NAPI.Task.Run(() =>
            {
                mines[0].Delete();
                mines[1].Delete();
                mines[2].Delete();
                mines[3].Delete();


                foreach (var target in NAPI.Pools.GetAllPlayers())
                {
                    if (target.GetData("status") == true && Main.IsInRangeOfPoint(target.Position, new Vector3(254.6958, 224.2552, 102.2034), 100f))
                    {
                        target.TriggerEvent("explode", new Vector3(254.6958, 224.2552, 102.2034), ExplosionType.StickyBomb, 3.0f, true, false, 7.0f);
                        target.TriggerEvent("explode", new Vector3(252.9819, 224.9136, 102.0892), ExplosionType.StickyBomb, 3.0f, true, false, 7.0f);
                        target.TriggerEvent("explode", new Vector3(253.789, 224.6199, 101.4626), ExplosionType.StickyBomb, 3.0f, true, false, 7.0f);
                        target.TriggerEvent("explode", new Vector3(253.8049, 224.6141, 103.1451), ExplosionType.StickyBomb, 3.0f, true, false, 7.0f);
                    }
                }

                Main.DisplaySubtitle(player, "~g~Geh zurück an den Safe und Schnapp dir soviel wie du kannst!");

                vault_door.Position = new Vector3(255.1254f, 224.3181f, 100.92f);
                vault_door.Rotation = new Vector3(-89.23032f, 1.514521f, 154.2677f);


            }, delayTime: SETTINGS_EXPLODE_TIME_C4 * 1000);
        }

        for (int i = 0; i < money_crate.Length; i++)
        {
            if(Main.IsInRangeOfPoint(player.Position, money_crate[i].Position, 1.5f) && money_crate_stage[i] != 2 && main_robbery_bank_stage == 3)
            {
                if (player.GetData("cash_crate") == true)
                {
                    player.SetData("cash_crate", false);
                    player.StopAnimation();
                }
                else
                {
                    player.SetData("cash_crate", true);
                    player.PlayAnimation("random@mugging1", "pickup_low", (int)(Main.AnimationFlags.Loop));
                }
                return;
            }
        }

        if (Main.IsInRangeOfPoint(player.Position, new Vector3(255.7437, 218.4138, 101.6834), 0.8f) && cash_prop_stage == 0 && main_robbery_bank_stage == 3)
        {
            if (player.GetData("cash_prop") == true)
            {
                player.SetData("cash_prop", false);
                player.StopAnimation();
            }
            else
            {
                player.SetData("cash_prop", true);
                player.PlayAnimation("oddjobs@shop_robbery@rob_till", "loop", (int)(Main.AnimationFlags.Loop));
            }
            
        }
        player.TriggerEvent("SetBlackoutState", false);
    }

    public static void OnPlayerConnect(Client player)
    {
        //player.TriggerEvent("doorLock", -222270721, new Vector3(256.31, 220.66, 106.43), drill_door_lock_status, 0);
    }


    public void OnRobberyTimer()
    {
        TimerEx.SetTimer(() =>
        {
            if(drill_stage == 1)
            {
                drill_timer--;
                drill_label.Text = "~y~Bohrer~n~~n~~c~[Restzeit: ~g~"+drill_timer+"~c~ Sekunden]";

                if (drill_timer == 0)
                {
                    drill_door_lock_status = false;

                    drill_stage = 4;
                    drill_label.Text = "~y~Bohren~n~~n~[Fertig]";
                    drill.Delete();
                }
            }

            if(vault_stage == 1)
            {
                vault_timer--;
                vault_label.Text = "~y~C4 platzieren ~g~Erfolgreich~w~ !~n~~n~~o~** Das C4 explodiert in ~w~"+ vault_timer + "~o~ Sekunden **";
                if (vault_timer == 0)
                {
                    vault_label.Text = " ";
                    vault_stage = 2;
                }
                
            }

            foreach (var player in NAPI.Pools.GetAllPlayers())
            {
                if (player.GetData("status") == true)
                {
                    if(Main.IsInRangeOfPoint(player.Position, new Vector3(256.31, 220.66, 106.43), 300.0f))
                    {
                        player.TriggerEvent("doorLock", -222270721, new Vector3(256.31, 220.66, 106.43), drill_door_lock_status, 0);

                        player.TriggerEvent("doorLock", 110411286, new Vector3(232.6054, 214.1584, 106.4049), bank_door_lock, 0);
                        player.TriggerEvent("doorLock", 110411286, new Vector3(231.5123, 216.5177, 106.4049), bank_door_lock, 0);
                        player.TriggerEvent("doorLock", 110411286, new Vector3(260.6432, 203.2052, 106.4049), bank_door_lock, 0);
                        player.TriggerEvent("doorLock", 110411286, new Vector3(258.2022, 204.1005, 106.4049), bank_door_lock, 0);
                    }

                    if (player.GetData("cash_prop") == true && Main.IsInRangeOfPoint(player.Position, new Vector3(255.7437, 218.4138, 101.6834), 0.8f) && cash_prop_stage == 0)
                    {
                        int money = 0;
                        if (cash_prop_money > 500)
                        {
                            Random rnd = new Random();
                            money = rnd.Next(100, 500);
                            cash_prop_money -= money;
                            Inventory.GiveItemToInventory(player, 158, money);
                            cash_prop_label.Text = "~g~Cash-Tabelle~n~~c~(Geld zur Verfügung: ~s~$" + cash_prop_money.ToString("N0") + "~c~)~n~~w~Drücke ~y~E~w~ um abzuheben";
                        }
                        else // random@atmrobberygen pickup_low
                        {
                            if (money > 0)
                            {
                                money = cash_prop_money;
                                Inventory.GiveItemToInventory(player, 158, cash_prop_money);
                            }
                            Vector3 position = cash_prop.Position;
                            Vector3 rotation = cash_prop.Rotation;
                            cash_prop.Delete();
                            cash_prop = NAPI.Object.CreateObject(769923921, position, rotation);
                            cash_prop_label.Text = "~s~Cash-Tabelle~n~~c~(leer)~n~~w~";
                            cash_prop_stage = 1;
                            player.SetData("cash_prop", false);
                            player.StopAnimation();
                        }

                    }
                    else
                    {
                        if (player.GetData("cash_prop") == true) player.SetData("cash_prop", false);
                    }

                    for (int i = 0; i < money_crate.Length; i++)
                    {
                        if (Main.IsInRangeOfPoint(player.Position, money_crate[i].Position, 1.5f) && money_crate_stage[i] != 2 && player.GetData("cash_crate") == true)
                        {
                            int money = 0;
                            if (money_crate_money[i] > 2000)
                            {
                                Random rnd = new Random();
                                money = rnd.Next(100, 500);
                                money_crate_money[i] -= money;
                                Inventory.GiveItemToInventory(player, 158, money);
                                money_crate_label[i].Text = "~s~Kasse~n~~c~(Geld zur Verfügung: ~s~$" + money_crate_money[i].ToString("N0") + "~c~)~n~~w~Drücke ~y~E~w~";

                                Vector3 position = money_crate[i].Position;
                                Vector3 rotation = money_crate[i].Rotation;

                                if (money_crate_stage[i] == (SETTINGS_CRATE_MONEY_MIN / 2) && money_crate_stage[i] == 0)
                                {
                                    money_crate_stage[i] = 1;
                                    money_crate[i].Delete();
                                    money_crate[i] = NAPI.Object.CreateObject(-748199017, position, rotation);
                                }
                                return;

                            }
                            else
                            {
                                if (money > 0)
                                {
                                    money = money_crate_money[i];
                                    Inventory.GiveItemToInventory(player, 158, money);
                                }
                                // reset 3d
                                Vector3 position = money_crate[i].Position;
                                Vector3 rotation = money_crate[i].Rotation;
                                money_crate_stage[i] = 2;
                                money_crate[i].Delete();
                                money_crate[i] = NAPI.Object.CreateObject(-1823263496, position, rotation);
                                money_crate_label[i].Text = "~s~Kasse~n~~c~(leer)~n~~w~";

                                // reset variable e animation
                                player.SetData("cash_crate", false);
                                player.StopAnimation();
                                return;
                            }
                        }
                    }
                }
            }
        }, 1000, 0);
    }
    //main_robbery_bank_stage
    [Command("ativarbanco")]
    public static void CMD_ativarbanco(Client player)
    {
        if (AccountManage.GetPlayerAdmin(player) == 0)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben keine Berechtigung, diesen Befehl zu verwenden");
            return;
        }
        if (enable_bank_robbery == false)
        {
            enable_bank_robbery = true;
            Main.SendInfoMessage(player, " Banküberfall ist"+Main.EMBED_GREEN+"aktiviert"+Main.EMBED_WHITE+".");
            foreach (var target in NAPI.Pools.GetAllPlayers())
            {
                Main.ShowColorShardAll(target, "~y~Staatsbank", "Sperrzone von 150m für 5 Minuten ausgerufen!", 2, 10, 6500);
            }
        }
        else
        {
            enable_bank_robbery = false;
            Main.SendInfoMessage(player, " Banküberfall ist" + Main.EMBED_RED + "nicht aktiviert" + Main.EMBED_WHITE + ".");
        }
    }

    [Command("roubarbanco")]
    public static void CMD_roubarbanco(Client player)
    {
        if(main_robbery_bank_stage != 0)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Diese Bank wird bereits Überfallen");
            return;
        }

        if (!Main.IsInRangeOfPoint(player.Position, new Vector3(247.1953, 222.6497, 106.2868), 15.0f))
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Sie schulden dies der Rezeption, die Bank ist ein Abzocker.");
            return;
        }

        int cops_online = 0, members_online = 0, c4 = 0, drill = 0;
        foreach(var target in NAPI.Pools.GetAllPlayers())
        {
            if (target.GetData("status") == true)
            {
                if (AccountManage.GetPlayerGroup(target) == 1)
                {
                    cops_online += 1;
                }

                if (AccountManage.GetPlayerGroup(player) == AccountManage.GetPlayerGroup(target) && Main.IsInRangeOfPoint(target.Position, new Vector3(247.1953, 222.6497, 106.2868), 15.0f))
                {
                    members_online++;

                    if(Inventory.GetPlayerItemFromInventory(player, 19) > 3)
                    {
                        c4 = 1;
                    }

                    if (Inventory.GetPlayerItemFromInventory(player, 20) > 0)
                    {
                        drill = 1;
                    }
                }
            }
        }

        if(c4 == 0 && drill == 0)
        {
            Main.SendInfoMessage(player, "Du hast nicht alles dabei!");
            return;
        }

        if (cops_online < 6)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Du brauchst wenigstens "+ SETTINGS_COPS_NEEDED + " Polizisten, um den Bankraub zu starten.");
            return;
        }

        if (members_online < SETTINGS_MEMBERS_NEEDED)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Du brauchst wenigstens " + SETTINGS_MEMBERS_NEEDED + " Polizisten, um den Bankraub zu starten.");
            return;
        }

        int faction_id = AccountManage.GetPlayerGroup(player);

        //Main.SendMessageWithTagToAll(""+Main.EMBED_LIGHTBLUE+"[Bank von Los Santos]", "Die Bank wird ausgeraubt von "+Main.EMBED_LIGHTRED+""+FactionManage.faction_data[faction_id].faction_name +""+Main.EMBED_WHITE+".");


        foreach (var target in NAPI.Pools.GetAllPlayers())
        {
            if (target.GetData("status") == true && AccountManage.GetPlayerGroup(target) == AccountManage.GetPlayerGroup(player) && Main.IsInRangeOfPoint(target.Position, new Vector3(247.1953, 222.6497, 106.2868), 15.0f))
            {
                
                Police.SetPlayerCrime(target, "Angriff auf die Bank von Los Santos "," Unbekannt", 12);
            }
        }
        main_robbery_bank_stage = 1;
        bank_door_lock = true;

        foreach (var target in NAPI.Pools.GetAllPlayers())
        {
            if (target.GetData("status") == true && AccountManage.GetPlayerGroup(target) == 1)
            {
                Main.SendMessageWithTagToPlayer(target, "" + Main.EMBED_BLUE + "[Central]", "" + Main.EMBED_BLUE + "Alle Einheiten, die Bank von Los Santos wird ausgeraubt, wir erwarten Sie an der Bank");
                Main.SendMessageWithTagToPlayer(target, "" + Main.EMBED_BLUE + "[Central]", "" + Main.EMBED_BLUE + "Die Türen zum Betreten des Sitzes sind geschlossen. Ein Team wurde geschickt, um es freizuschalten. Wir informieren Sie, wenn alles fertig ist.");
            }
        }

        NAPI.Task.Run(() =>
        {
            bank_door_lock = false;

            foreach (var target in NAPI.Pools.GetAllPlayers())
            {
                if (target.GetData("status") == true && AccountManage.GetPlayerGroup(target) == 1)
                {
                    Main.SendMessageWithTagToPlayer(target, "" + Main.EMBED_BLUE + "[Central]", "" + Main.EMBED_BLUE + "Das Team konnte die Türen der Bank aufschließen!");
                }
            }

        }, delayTime: SETTINGS_TO_OPEN_BANK_AFTER_ROBBERY);


        timeout_bank_robbery = TimerEx.SetTimer(() =>
        {
            ResetBankRobbery();
            timeout_bank_robbery.Kill();
            timeout_bank_robbery = null;
        }, 15 * 60000, 1);
    }
}