﻿using GTANetworkAPI;
using System.Collections.Generic;
using System;
using DerStr1k3r.Core;
using DerStr1k3r.SDK;


class Electrician : Script
{
    private static int checkpointPayment = 7;

    [ServerEvent(Event.ResourceStart)]
    public void Event_ResourceStart()
    {
        try
        {
            Blip temp_blip = null;
            temp_blip = NAPI.Blip.CreateBlip(new Vector3(724.9625, 133.9959, 79.83643), 0);
            temp_blip.Sprite = 354;
            temp_blip.Name = "LS Go Electro";
            temp_blip.Color = 1;
            temp_blip.ShortRange = true;

            //NAPI.TextLabel.CreateTextLabel("~g~Ronny Bolls", new Vector3(724.8585, 134.1029, 81.95643), 30f, 0.3f, 0, new Color(255, 255, 255), true, NAPI.GlobalDimension);

   
            NAPI.World.DeleteWorldProp(1046551856, new Vector3(732.2359, 133.4224, 79.84549), 30f);
            NAPI.World.DeleteWorldProp(1046551856, new Vector3(722.1532, 139.4459, 79.84549), 30f);

            NAPI.World.DeleteWorldProp(-1767254195, new Vector3(707.9461, 165.5156, 79.75075), 30f);
            NAPI.World.DeleteWorldProp(-1767254195, new Vector3(706.5385, 161.6642, 79.75075), 30f);
            NAPI.World.DeleteWorldProp(-1767254195, new Vector3(705.1336, 157.7777, 79.75075), 30f);
            NAPI.World.DeleteWorldProp(-1767254195, new Vector3(703.7278, 153.9064, 79.75075), 30f);
            NAPI.World.DeleteWorldProp(-1767254195, new Vector3(702.3203, 150.0551, 79.75075), 30f);
            NAPI.World.DeleteWorldProp(-1767254195, new Vector3(700.8676, 146.1782, 79.75075), 30f);
            NAPI.World.DeleteWorldProp(-1767254195, new Vector3(699.4619, 142.3069, 79.75075), 30f);
            NAPI.World.DeleteWorldProp(-1767254195, new Vector3(698.0561, 138.4357, 79.75075), 30f);
            NAPI.World.DeleteWorldProp(-1767254195, new Vector3(696.6503, 134.5644, 79.75075), 30f);
            NAPI.World.DeleteWorldProp(-1767254195, new Vector3(695.2429, 130.7126, 79.75075), 30f);

            NAPI.World.DeleteWorldProp(-1767254195, new Vector3(691.3967, 132.1314, 79.75075), 30f);
            NAPI.World.DeleteWorldProp(-1767254195, new Vector3(687.5255, 133.5372, 79.75075), 30f);
            NAPI.World.DeleteWorldProp(-1767254195, new Vector3(683.6542, 134.9429, 79.75075), 30f);
            NAPI.World.DeleteWorldProp(-1767254195, new Vector3(679.7828, 136.3487, 79.75075), 30f);
            NAPI.World.DeleteWorldProp(733542368, new Vector3(679.8405, 136.3211, 80.88264), 30f);
            NAPI.World.DeleteWorldProp(-1767254195, new Vector3(672.0446, 139.1718, 79.75075), 30f);
            NAPI.World.DeleteWorldProp(-1767254195, new Vector3(668.1732, 140.5775, 79.75075), 30f);
            NAPI.World.DeleteWorldProp(-1767254195, new Vector3(664.3019, 141.9833, 79.75075), 30f);
            NAPI.World.DeleteWorldProp(-1767254195, new Vector3(660.4498, 143.3886, 79.75075), 30f);

            NAPI.World.DeleteWorldProp(-1767254195, new Vector3(681.2599, 89.09968, 79.75075), 30f);
            NAPI.World.DeleteWorldProp(-1767254195, new Vector3(682.6656, 92.97095, 79.75075), 30f);
            NAPI.World.DeleteWorldProp(-1767254195, new Vector3(684.0714, 96.84223, 79.75075), 30f);
            NAPI.World.DeleteWorldProp(-1767254195, new Vector3(685.4772, 100.7135, 79.75075), 30f);
            NAPI.World.DeleteWorldProp(-1767254195, new Vector3(686.9298, 104.5904, 79.75075), 30f);
            NAPI.World.DeleteWorldProp(733542368, new Vector3(689.8031, 112.401, 80.82464), 30f);
            NAPI.World.DeleteWorldProp(-1767254195, new Vector3(691.2355, 116.2422, 79.75075), 30f);
            NAPI.World.DeleteWorldProp(-1767254195, new Vector3(692.6412, 120.1135, 79.75075), 30f);
            NAPI.World.DeleteWorldProp(-1767254195, new Vector3(694.047, 123.9848, 79.75075), 30f);
            NAPI.World.DeleteWorldProp(-1767254195, new Vector3(695.4528, 127.8561, 79.75075), 30f);

            NAPI.World.DeleteWorldProp(-1767254195, new Vector3(691.5093, 129.2795, 79.75075), 30f);
            NAPI.World.DeleteWorldProp(-1767254195, new Vector3(687.6381, 130.6853, 79.75075), 30f);
            NAPI.World.DeleteWorldProp(-1767254195, new Vector3(683.7667, 132.091, 79.75075), 30f);
            NAPI.World.DeleteWorldProp(-1767254195, new Vector3(679.8954, 133.4968, 79.75075), 30f);
            NAPI.World.DeleteWorldProp(-1767254195, new Vector3(676.0283, 134.9141, 79.75075), 30f);
            NAPI.World.DeleteWorldProp(-1767254195, new Vector3(672.1571, 136.3199, 79.75075), 30f);
            NAPI.World.DeleteWorldProp(-1767254195, new Vector3(668.2858, 137.7256, 79.75075), 30f);
            NAPI.World.DeleteWorldProp(-1767254195, new Vector3(664.4144, 139.1314, 79.75075), 30f);
            NAPI.World.DeleteWorldProp(-1767254195, new Vector3(660.5624, 140.5368, 79.75075), 30f);

            NAPI.World.DeleteWorldProp(-1767254195, new Vector3(732.0546, 125.8921, 79.75075), 30f);
            NAPI.World.DeleteWorldProp(-1767254195, new Vector3(728.1832, 127.2978, 79.75075), 30f);
            NAPI.World.DeleteWorldProp(-1767254195, new Vector3(724.3121, 128.7036, 79.75075), 30f);
            NAPI.World.DeleteWorldProp(-1767254195, new Vector3(720.4269, 130.1242, 79.75075), 30f);
            NAPI.World.DeleteWorldProp(-1767254195, new Vector3(716.5555, 131.5299, 79.75075), 30f);
            NAPI.World.DeleteWorldProp(-1767254195, new Vector3(712.6843, 132.9357, 79.75075), 30f);
            NAPI.World.DeleteWorldProp(-1767254195, new Vector3(708.8131, 134.3415, 79.75075), 30f);

            NAPI.World.DeleteWorldProp(-1767254195, new Vector3(704.9441, 135.7489, 79.75075), 30f);
            NAPI.World.DeleteWorldProp(-1767254195, new Vector3(703.5383, 131.8776, 79.75075), 30f);
            NAPI.World.DeleteWorldProp(-1767254195, new Vector3(702.1326, 128.0063, 79.75075), 30f);
            NAPI.World.DeleteWorldProp(-1767254195, new Vector3(700.712, 124.1212, 79.75075), 30f);
            NAPI.World.DeleteWorldProp(-1767254195, new Vector3(699.3063, 120.2499, 79.75075), 30f);
            NAPI.World.DeleteWorldProp(-1767254195, new Vector3(697.9005, 116.3786, 79.75075), 30f);
            NAPI.World.DeleteWorldProp(-1767254195, new Vector3(696.4948, 112.5074, 79.75075), 30f);
            NAPI.World.DeleteWorldProp(733542368, new Vector3(695.0624, 108.561, 80.85213), 30f);
            NAPI.World.DeleteWorldProp(-1767254195, new Vector3(693.6404, 104.6123, 79.75075), 30f);
            NAPI.World.DeleteWorldProp(-1767254195, new Vector3(692.2346, 100.741, 79.75075), 30f);
            NAPI.World.DeleteWorldProp(-1767254195, new Vector3(690.8289, 96.86977, 79.75075), 30f);
            NAPI.World.DeleteWorldProp(-1767254195, new Vector3(689.3761, 92.99287, 79.75075), 30f);
    

            var col = NAPI.ColShape.CreateCylinderColShape(new Vector3(724.9625, 133.9959, 79.83643), 1, 2, 0);
            col.OnEntityEnterColShape += (shape, player) =>
            {
                try
                {
                    player.SetData("INTERACTIONCHECK", 8);
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
            NAPI.TextLabel.CreateTextLabel("Drücke ~y~E~w~", new Vector3(724.9625, 133.9959, 80.95643), 30f, 0.4f, 0, new Color(255, 255, 255), true, 0);
            NAPI.Marker.CreateMarker(1, new Vector3(724.9625, 133.9959, 79.83643) - new Vector3(0, 0, 0.7), new Vector3(), new Vector3(), 1, new Color(255, 255, 255, 220));

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
        if (Main_Job.GetPlayerJob(player) != 2)
        {
            Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, "Sie arbeiten nicht als Elektriker. Sie können sich dem Job im LS Job Center anschließen", 5000);
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
            //player.SetData("PAYMENT", 0);
            return;
        }
        else
        {

            if (player.GetSharedData("CHARACTER_ONLINE_GENRE") == 0)
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
            new Checkpoint(new Vector3(678.6784, 163.7561, 79.80791), 338.0567),
            new Checkpoint(new Vector3(697.9194, 158.3429, 79.8203), 162.1701),
            new Checkpoint(new Vector3(696.8144, 149.2776, 79.83644), 174.3819),
            new Checkpoint(new Vector3(701.6469, 110.9194, 79.81911), 163.4535),
            new Checkpoint(new Vector3(697.663, 104.4758, 79.63456), 162.01),
            new Checkpoint(new Vector3(658.8223, 114.3996, 79.80294), 346.9411),
            new Checkpoint(new Vector3(663.0648, 122.4777, 79.80295), 345.3615),
            new Checkpoint(new Vector3(671.8508, 145.1318, 79.80048), 345.2057),
        };

    private static void PlayerEnterCheckpoint(ColShape shape, Client player)
    {
        try
        {
            API.Shared.ConsoleOutput("1");
            if (!player.GetData("status")) return;
            API.Shared.ConsoleOutput("2");
            if (Main_Job.GetPlayerJob(player) != 2 || !player.GetData("ON_WORK") || shape.GetData("NUMBER") != player.GetData("WORKCHECK")) return;

            API.Shared.ConsoleOutput("3");
            //if (Checkpoints[(int)shape.GetData("NUMBER")].Position.DistanceTo(player.Position) > 3) return;

            //var payment = Convert.ToInt32(checkpointPayment * Group.GroupPayAdd[Main.Accounts[player].VipLvl] * Main.oldconfig.PaydayMultiplier);
            var payment = Convert.ToInt32(checkpointPayment * Main_Job.Payday_Job_Multipler);

            Main.GivePlayerMoney(player, payment);
            Notify.Send(player, NotifyType.Success, NotifyPosition.BottomCenter, $"Sie haben $" + payment + " bekommen!", 5000);
            NAPI.Entity.SetEntityPosition(player, Checkpoints[shape.GetData("NUMBER")].Position + new Vector3(0, 0, 1.2));
            NAPI.Entity.SetEntityRotation(player, new Vector3(0, 0, Checkpoints[shape.GetData("NUMBER")].Heading));
            //Main.OnAntiAnim(player);
            player.PlayAnimation("amb@prop_human_movie_studio_light@base", "base", 39);
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
                        Trigger.ClientEvent(player, "createCheckpoint", 15, 1, Checkpoints[nextCheck].Position, 1, 0, 255, 0, 0);
                        Trigger.ClientEvent(player, "createWorkBlip", Checkpoints[nextCheck].Position);
                    }
                }
                catch { }
            }, 4000);

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