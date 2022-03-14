using GTANetworkAPI;
using System.Collections.Generic;
using System;
using DerStr1k3r.Core;
using DerStr1k3r.SDK;


class LumberJack : Script
{
    private static int checkpointPayment = 12;

    [ServerEvent(Event.ResourceStart)]
    public void Event_ResourceStart()
    {
        try
        {
            Blip temp_blip = null;
            temp_blip = NAPI.Blip.CreateBlip(new Vector3(-567.4201, 5252.957, 71.48643), 0);
            temp_blip.Sprite = 385;
            temp_blip.Name = "Wald";
            temp_blip.Color = 1;
            temp_blip.ShortRange = true;

            //NAPI.TextLabel.CreateTextLabel("~g~Ronny Bolls", new Vector3(724.8585, 134.1029, 81.95643), 30f, 0.3f, 0, new Color(255, 255, 255), true, NAPI.GlobalDimension);




            var col = NAPI.ColShape.CreateCylinderColShape(new Vector3(-567.4201, 5252.957, 71.48643), 1, 2, 0);
            col.OnEntityEnterColShape += (shape, player) =>
            {
                try
                {
                    player.SetData("INTERACTIONCHECK", 34);
                }
                catch (Exception ex) { Console.WriteLine("col.OnEntityEnterColShape: " + ex.Message, nLog.Type.Error); }
            };
            col.OnEntityExitColShape += (shape, player) =>
            {
                try
                {
                    player.SetData("INTERACTIONCHECK", 0);
                }
                catch (Exception ex) { Console.WriteLine("col.OnEntityExitColShape: " + ex.Message, nLog.Type.Error); }
            };
            NAPI.TextLabel.CreateTextLabel("Drücke ~y~E~w~", new Vector3(-567.4201, 5252.957, 71.48643), 30f, 0.4f, 0, new Color(255, 255, 255), true, 0);
            //NAPI.Marker.CreateMarker(1, new Vector3(724.9625, 133.9959, 79.83643) - new Vector3(0, 0, 0.7), new Vector3(), new Vector3(), 1, new Color(255, 255, 255, 220));

            int i = 0;
            foreach (var Check in Checkpoints)
            {
                col = NAPI.ColShape.CreateCylinderColShape(Check.Position, 1, 2, 0);
                col.SetData("NUMBER", i);
                col.OnEntityEnterColShape += PlayerEnterCheckpoint;
                i++;
            }
        }
        catch (Exception e) { Console.WriteLine("ResourceStart: " + e.Message, nLog.Type.Error); }
    }

    public static void StartWorkDay(Client player)
    {
        API.Shared.ConsoleOutput("CALLED");
        if (Main_Job.GetPlayerJob(player) != 7)
        {
            Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, "Sie arbeiten nicht als Holzfäller. Sie können sich dem Job im LS Job Center anschließen.", 5000);
            return;
        }
        API.Shared.ConsoleOutput("CALLED 2");
        if (player.GetData("ON_WORK"))
        {
            Main.UpdatePlayerClothes(player);
            player.SetData("ON_WORK", false);
            Trigger.ClientEvent(player, "deleteCheckpoint", 15);
            Trigger.ClientEvent(player, "deleteWorkBlip");

            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du hast den Arbeitstag beendet.", 5000);

            if (player.HasData("WORKOBJECT"))
            {
                BasicSync.DetachObject(player);
                player.ResetData("WORKOBJECT");
            }
            //player.SetData("PAYMENT", 0);
            return;
        }
        else
        {

            /* if (player.GetSharedData("CHARACTER_ONLINE_GENRE") == 0)
             {
                 player.SetAccessories(1, 24, 2);
                 player.SetClothes(3, 16, 0);
                 player.SetClothes(11, 153, 10);
                 player.SetClothes(4, 0, 5);
                 player.SetClothes(6, 24, 0);
             }
             else
             {
                 player.SetAccessories(1, 26, 2);
                 player.SetClothes(3, 17, 0);
                 player.SetClothes(11, 150, 1);
                 player.SetClothes(4, 1, 5);
                 player.SetClothes(6, 52, 0);
             }*/

            if (!player.HasData("WORKOBJECT"))
            {
                BasicSync.AttachObjectToPlayer(player, NAPI.Util.GetHashKey("prop_tool_fireaxe"), 57005, new Vector3(0.1, -0.1, -0.02), new Vector3(80, 0, 170));
                player.SetData("WORKOBJECT", true);
            }
        
            var check = Main_Job.rnd.Next(0, Checkpoints.Count - 1);
            player.SetData("WORKCHECK", check);
            Trigger.ClientEvent(player, "createCheckpoint", 15, 1, Checkpoints[check].Position, 1, 0, 255, 0, 0);
            Trigger.ClientEvent(player, "createWorkBlip", Checkpoints[check].Position);

            player.SetData("ON_WORK", true);
            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, "Sie haben den Arbeitstag begonnen", 5000);
            return;
        }
    }

    private static List<Checkpoint> Checkpoints = new List<Checkpoint>()
        {
            new Checkpoint(new Vector3(-600.4562, 5174.39, 99.25591), 2.456106),
            new Checkpoint(new Vector3(-613.2936, 5158.16, 105.9637 ), 103.1168),
            new Checkpoint(new Vector3(-635.3933, 5170.464, 103.6556), 320.6604),
            new Checkpoint(new Vector3(-647.2247, 5190.413, 96.63339),340.5916 ),
            new Checkpoint(new Vector3(-621.2045, 5186.613, 94.31361),  351.6921),
            new Checkpoint(new Vector3( -618.2088, 5143.381, 111.7863),188.7871 ),
            new Checkpoint(new Vector3( -613.4686, 5156.347, 106.716), 25.51363 ),
            new Checkpoint(new Vector3(-647.5579, 5269.439, 74.1201 ), 263.274 ),
            new Checkpoint(new Vector3(-663.4601, 5276.796, 74.33523), 22.9545),
            new Checkpoint(new Vector3(-659.2092, 5292.325, 70.39141),  346.5061),
            new Checkpoint(new Vector3(-631.678, 5276.427, 68.35959),  129.8935),

        };

    private static void PlayerEnterCheckpoint(ColShape shape, Client player)
    {
        try
        {

            if (!player.GetData("status")) return;

            if (Main_Job.GetPlayerJob(player) != 7 || !player.GetData("ON_WORK") || shape.GetData("NUMBER") != player.GetData("WORKCHECK")) return;

            if (Checkpoints[(int)shape.GetData("NUMBER")].Position.DistanceTo(player.Position) > 3) return;

            //var payment = Convert.ToInt32(checkpointPayment * Group.GroupPayAdd[Main.Accounts[player].VipLvl] * Main.oldconfig.PaydayMultiplier);
            var payment = Convert.ToInt32(checkpointPayment * Main_Job.Payday_Job_Multipler);

            Main.GivePlayerMoney(player, payment);
            Notify.Send(player, NotifyType.Success, NotifyPosition.BottomCenter, $"Sie haben $" + payment + " bekommen!", 5000);
            NAPI.Entity.SetEntityPosition(player, Checkpoints[shape.GetData("NUMBER")].Position + new Vector3(0, 0, 1.2));
            NAPI.Entity.SetEntityRotation(player, new Vector3(0, 0, Checkpoints[shape.GetData("NUMBER")].Heading));
            //Main.OnAntiAnim(player);

            player.PlayAnimation("melee@large_wpn@streamed_core", "car_side_attack_a", 39);
            player.SetData("WORKCHECK", -1);
            NAPI.Task.Run(() =>
            {
                try
                {
                    if (player != null && player.GetData("status"))
                    {
                        player.StopAnimation();
                        //Main.OffAntiAnim(player);
                        var nextCheck = Main_Job.rnd.Next(0, Checkpoints.Count - 1);
                        while (nextCheck == shape.GetData("NUMBER")) nextCheck = Main_Job.rnd.Next(0, Checkpoints.Count - 1);
                        player.SetData("WORKCHECK", nextCheck);
                        Trigger.ClientEvent(player, "createCheckpoint", 15, 1, Checkpoints[nextCheck].Position - new Vector3(0,0,1), 1, 0, 255, 0, 0);
                        Trigger.ClientEvent(player, "createWorkBlip", Checkpoints[nextCheck].Position);
                    }
                }
                catch { }
            }, 5700);

        }
        catch (Exception e) { Console.WriteLine("PlayerEnterCheckpoint: " + e.Message, nLog.Type.Error); }
    }

    internal class Checkpoint
    {
        public Vector3 Position { get; }
        public double Heading { get; }

        public Checkpoint(Vector3 pos, double rot)
        {
            Position = pos;
            Heading = rot;
        }
    }
}