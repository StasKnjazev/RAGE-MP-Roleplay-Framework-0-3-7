using System;
using System.Collections.Generic;
using GTANetworkAPI;
using DerStr1k3r.Core;
using DerStr1k3r.SDK;

class Meth : Script
{
    public class MethEnum : IEquatable<MethEnum>

    {
        public int id { get; set; }

        public Entity objectHandle { get; set; }
        public TextLabel textLabel { get; set; }
        public Vector3 position { get; set; }
        public TimerEx timer { get; set; }
        public int stage { get; set; }
        public int downtime { get; set; }
        public override int GetHashCode()
        {
            return id;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            MethEnum objAsPart = obj as MethEnum;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }

        public bool Equals(MethEnum other)
        {
            if (other == null) return false;
            return (this.id.Equals(other.id));
        }
    }

    public static List<MethEnum> MethList = new List<MethEnum>();

    public static void MethInit()
    {

      //Blip temp_blip = NAPI.Blip.CreateBlip(new Vector3(3392.58, 5499.587, 24.23199));
      //  NAPI.Blip.SetBlipName(temp_blip, "Opiumernte");
      //  NAPI.Blip.SetBlipSprite(temp_blip, 468);
      //  NAPI.Blip.SetBlipColor(temp_blip, 59);
      //  NAPI.Blip.SetBlipScale(temp_blip, 1.0f);
      //  NAPI.Blip.SetBlipShortRange(temp_blip, true);

        API.Shared.DeleteWorldProp(-596943609, new Vector3(3391.689, 5504.36, 23.9412), 40f); // tenda
        API.Shared.DeleteWorldProp(-1572018818, new Vector3(3391.689, 5504.36, 23.9412), 40f); // table

        MethList.Add(new MethEnum { position = new Vector3(3416.903, 5470.709, 20.87231), stage = 0 }); // 0, 0, 266.1345
        MethList.Add(new MethEnum { position = new Vector3(3429.267, 5463.163, 19.68628), stage = 0 }); // 0, 0, 248.2544
        MethList.Add(new MethEnum { position = new Vector3(3438.826, 5472.703, 20.32995), stage = 0 }); // 0, 0, 323.119
        MethList.Add(new MethEnum { position = new Vector3(3434.483, 5482.066, 22.80787), stage = 0 }); // 0, 0, 36.05629
        MethList.Add(new MethEnum { position = new Vector3(3423.469, 5487.26, 24.47433), stage = 0 }); // 0, 0, 70.98997
        MethList.Add(new MethEnum { position = new Vector3(3419.526, 5500.625, 23.79437), stage = 0 }); // 0, 0, 10.06372
        MethList.Add(new MethEnum { position = new Vector3(3433.822, 5504.37, 23.15698), stage = 0 }); // 0, 0, 279.5106
        MethList.Add(new MethEnum { position = new Vector3(3449.265, 5508.552, 19.82023), stage = 0 }); // 0, 0, 264.478
        MethList.Add(new MethEnum { position = new Vector3(3433.584, 5518.776, 19.95233), stage = 0 }); // 0, 0, 72.4735
        MethList.Add(new MethEnum { position = new Vector3(3415.21, 5518.925, 21.03789), stage = 0 }); // 0, 0, 109.7814
        MethList.Add(new MethEnum { position = new Vector3(3410.364, 5508.011, 23.54328), stage = 0 }); // 0, 0, 162.2165
        MethList.Add(new MethEnum { position = new Vector3(3404.417, 5502.065, 24.18033), stage = 0 }); // 0, 0, 120.3747
        MethList.Add(new MethEnum { position = new Vector3(3394.261, 5511.274, 23.23315), stage = 0 }); // 0, 0, 42.05631
        MethList.Add(new MethEnum { position = new Vector3(3379.939, 5508.705, 22.44706), stage = 0 }); // 0, 0, 108.2324
        MethList.Add(new MethEnum { position = new Vector3(3384.936, 5501.328, 23.84397), stage = 0 }); // 0, 0, 224.2606
        MethList.Add(new MethEnum { position = new Vector3(3377.716, 5524.121, 21.26247), stage = 0 }); // 0, 0, 36.17857
        MethList.Add(new MethEnum { position = new Vector3(3388.63, 5531.151, 18.53586), stage = 0 }); // 0, 0, 305.4675
        MethList.Add(new MethEnum { position = new Vector3(3399.502, 5532.924, 16.88271), stage = 0 }); // 0, 0, 264.2496
        MethList.Add(new MethEnum { position = new Vector3(3408.657, 5536.813, 15.08692), stage = 0 }); // 0, 0, 295.8766
        MethList.Add(new MethEnum { position = new Vector3(3419.742, 5532.726, 16.50706), stage = 0 }); // 0, 0, 246.5864
        MethList.Add(new MethEnum { position = new Vector3(3436.655, 5517.308, 20.10886), stage = 0 }); // 0, 0, 233.5347
        MethList.Add(new MethEnum { position = new Vector3(3451.692, 5514.224, 18.76247), stage = 0 }); // 0, 0, 268.9109
        MethList.Add(new MethEnum { position = new Vector3(3462.616, 5511.243, 17.67923), stage = 0 }); // 0, 0, 239.8521
        MethList.Add(new MethEnum { position = new Vector3(3463.126, 5494.436, 16.78993), stage = 0 }); //

        API.Shared.CreateObject(-1814952641, new Vector3(3391.689, 5504.36, 23.9412 - 1.2), new Vector3(0, 0, 0), 255, 0);

        foreach (var weed in MethList)
        {
            weed.downtime = 10 * 60;
            weed.timer = null;
            weed.objectHandle = API.Shared.CreateObject(-2093428068, new Vector3(weed.position.X, weed.position.Y, weed.position.Z - 1.2f), new Vector3(), 255, 0);
            weed.textLabel = API.Shared.CreateTextLabel("~h~~g~-~y~Drücke E", new Vector3(weed.position.X, weed.position.Y, weed.position.Z - 0.4f), 11.0f, 0.3f, 4, new Color(255, 255, 255, 255), false, 0);
        }

        ColShape opium = NAPI.ColShape.CreatCircleColShape(3392.58f, 5499.587f, 100, 0);
        opium.OnEntityEnterColShape += (s, ent) =>
        {
            Client player;
            
            if ((player = NAPI.Player.GetPlayerFromHandle(ent)) != null)
            {
                if (player.GetData("status") == false) return;
                int index = 0;
                foreach (var weed in MethList)
                {
                    if (weed.stage == 0)
                    {
                        player.TriggerEvent("blip_create_ext", "opium_" + index + "", weed.position, 59, 0.5f, 468, true, "Coca Blätter");
                    }
                    index++;
                }
                player.SetData("in_meth_area", true);
            }
        };

        opium.OnEntityExitColShape += (s, ent) =>
        {
            Client player;

            if ((player = NAPI.Player.GetPlayerFromHandle(ent)) != null)
            {
                if (player.GetData("status") == false) return;
                int index = 0;
                foreach (var weed in MethList)
                {
                    player.TriggerEvent("blip_remove", "opium_"+index+"");
                    index++;
                }
                player.SetData("in_meth_area", false);
            }
        };
    }



    public static void PressKeyY(Client player)
    {
        int index = 0;
        foreach (var weed in MethList)
        {
            if (Main.IsInRangeOfPoint(player.Position, weed.position, 1.0f) && weed.stage == 0)
            {

                if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 15, 1, Inventory.Max_Inventory_Weight(player)))
                {
                    return;
                }

                weed.stage = 1;

                Inventory.GiveItemToInventory(player, 15, 5);
                //player.TriggerEvent("createNewHeadNotificationAdvanced", "Voce colheu ~y~1~y~ folha de coca~w~ !");
                //Main.SendSuccessMessage(player, "Você colheu " + Main.EMBED_LIGHTGREEN + "1" + Main.EMBED_WHITE + " " + Main.EMBED_ORANGE + "folhas de coca" + Main.EMBED_WHITE + ".");
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"5x Kokainblätter gesammelt!", 5000);
                //Main.SendNotificationBrowser(player, "", "<string>+ 1</strong> Opium wurde Ihrem Inventar hinzugefügt!", "success");
                NAPI.Player.PlayPlayerAnimation(player, (int)(Main.AnimationFlags.Loop), "anim@mp_snowball", "pickup_snowball");
                NAPI.Task.Run(() =>
                {
                    player.StopAnimation();
                    weed.objectHandle.Position = new Vector3(weed.position.X, weed.position.Y, weed.position.Z - 2.8f);

                    foreach (var target in NAPI.Pools.GetAllPlayers()) if(target.GetData("status") == true && target.GetData("in_meth_area") == true) target.TriggerEvent("blip_remove", "opium_" + index + "");
                }, delayTime: 1500);


                //weed.timer = TimerEx.SetTimer(() => {
                //    weed.downtime--;

                //    weed.textLabel.Text = "~h~~g~-~y~ Folhas de Coca~g~ -~w~~n~~n~Bereit zum Sammeln in: ~y~" + weed.downtime;

                //    switch (weed.downtime)
                //    {
                //        case 590: weed.objectHandle.MovePosition(new Vector3(weed.position.X, weed.position.Y, weed.position.Z - 2.5f), 1000); break;
                //        case 550: weed.objectHandle.MovePosition(new Vector3(weed.position.X, weed.position.Y, weed.position.Z - 2.4f), 1000); break;
                //        case 500: weed.objectHandle.MovePosition(new Vector3(weed.position.X, weed.position.Y, weed.position.Z - 2.3f), 1000); break;
                //        case 450: weed.objectHandle.MovePosition(new Vector3(weed.position.X, weed.position.Y, weed.position.Z - 2.2f), 1000); break;
                //        case 400: weed.objectHandle.MovePosition(new Vector3(weed.position.X, weed.position.Y, weed.position.Z - 2.1f), 1000); break;
                //        case 350: weed.objectHandle.MovePosition(new Vector3(weed.position.X, weed.position.Y, weed.position.Z - 2.0f), 1000); break;
                //        case 300: weed.objectHandle.MovePosition(new Vector3(weed.position.X, weed.position.Y, weed.position.Z - 1.9f), 1000); break;
                //        case 250: weed.objectHandle.MovePosition(new Vector3(weed.position.X, weed.position.Y, weed.position.Z - 1.8f), 1000); break;
                //        case 200: weed.objectHandle.MovePosition(new Vector3(weed.position.X, weed.position.Y, weed.position.Z - 1.7f), 1000); break;
                //        case 150: weed.objectHandle.MovePosition(new Vector3(weed.position.X, weed.position.Y, weed.position.Z - 1.6f), 1000); break;
                //        case 100: weed.objectHandle.MovePosition(new Vector3(weed.position.X, weed.position.Y, weed.position.Z - 1.5f), 1000); break;
                //        case 50: weed.objectHandle.MovePosition(new Vector3(weed.position.X, weed.position.Y, weed.position.Z - 1.4f), 1000); break;
                //        case 30: weed.objectHandle.MovePosition(new Vector3(weed.position.X, weed.position.Y, weed.position.Z - 1.3f), 1000); break;
                //        case 20: weed.objectHandle.MovePosition(new Vector3(weed.position.X, weed.position.Y, weed.position.Z - 1.2f), 1000); break;
                //        case 10: weed.objectHandle.MovePosition(new Vector3(weed.position.X, weed.position.Y, weed.position.Z - 1.1f), 1000); break;
                //        case 0: weed.objectHandle.MovePosition(new Vector3(weed.position.X, weed.position.Y, weed.position.Z - 1.0f), 1000); break;
                //    }

                //    if (weed.downtime == 0)
                //    {
                //        weed.downtime = 10 * 60;
                //        weed.stage = 0;
                //        weed.textLabel.Text = "~h~~g~-~y~Drücke E";
                //        weed.timer.Kill();

                //        foreach (var target in NAPI.Pools.GetAllPlayers()) if (target.GetData("status") == true && target.GetData("in_meth_area") == true) target.TriggerEvent("blip_create_ext", "opium_" + index + "", weed.position, 59, 0.5f, 468, true, "Coca Blätter");
                //    }

                //}, 1000, 0);
                return;
            }
            index++;

        }
    }


}

