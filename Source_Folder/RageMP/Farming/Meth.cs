using System;
using System.Collections.Generic;
using GTANetworkAPI;
using DerStr1k3r.SDK;

class Meth : Script
{
    private static nLog Log = new nLog("Meth");

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
        NAPI.World.DeleteWorldProp(-596943609, new Vector3(3391.689, 5504.36, 23.9412), 40f); // tenda
        NAPI.World.DeleteWorldProp(-1572018818, new Vector3(3391.689, 5504.36, 23.9412), 40f); // table

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
        MethList.Add(new MethEnum { position = new Vector3(-351.6084, 4232.208, 50.91739), stage = 0 }); //
        MethList.Add(new MethEnum { position = new Vector3(-346.4842, 4224.61, 52.80266), stage = 0 }); //
        MethList.Add(new MethEnum { position = new Vector3(-348.69, 4213.89, 55.83582), stage = 0 }); //
        MethList.Add(new MethEnum { position = new Vector3(-337.8751, 4221.808, 49.62888), stage = 0 }); //
        MethList.Add(new MethEnum { position = new Vector3(-340.0898, 4234.515, 46.56116), stage = 0 }); //

        NAPI.Object.CreateObject(-1814952641, new Vector3(3391.689, 5504.36, 23.9412 - 1.2), new Vector3(0, 0, 0), 255, 0);

        foreach (var weed in MethList)
        {
            weed.objectHandle = NAPI.Object.CreateObject(-2093428068, new Vector3(weed.position.X, weed.position.Y, weed.position.Z - 1.2f), new Vector3(), 255, 0);
        }
    }

    public static void OnPlayerConnect(Client player)
    {
        try
        {
            player.SetData("Meth_Refinando", false);
            player.SetData("Sal", 20);
            player.SetData("Meth_RefinandoTime", 0);
        }
        catch (Exception e)
        {
            Log.Write("ResourceStart: " + e.Message, nLog.Type.Error);
        }
    }

    public static void PressKeyY(Client player)
    {
        try
        {
            foreach (var weed in MethList)
            {
                if (Main.IsInRangeOfPoint(player.Position, weed.position, 1.0f) && player.GetData("Meth_Refinando") == false)
                {
                    if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 15, 1, Inventory.Max_Inventory_Weight(player)) == true)
                    {
                        return;
                    }

                    Random rnd = new Random();
                    int sammeln = rnd.Next(1, 2);

                    player.SetData("Meth_Refinando", true);
                    Inventory.GiveItemToInventory(player, 15, sammeln);
                    NAPI.Notification.SendNotificationToPlayer(player, "Sie haben ~c~"+ sammeln + "x ~b~Kokainblätter ~w~aufgehoben !");
                    player.PlayAnimation("anim@mp_snowball", "pickup_snowball", 1 << 0 | 1 << 5);
                    NAPI.Task.Run(() =>
                    {
                        player.SetData("Meth_Refinando", false);
                        player.StopAnimation();
                    }, delayTime: 8500);
                    return;
                }
            }
        }
        catch (Exception e)
        {
            Log.Write("ResourceStart: " + e.Message, nLog.Type.Error);
        }
    }
}

