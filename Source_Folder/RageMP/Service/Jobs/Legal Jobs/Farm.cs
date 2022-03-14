using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;
using DerStr1k3r.Core;
using DerStr1k3r.SDK;

public class Farm : Script
{


    public class FarmDataEnum : IEquatable<FarmDataEnum>
    {
        public int id { get; set; }
        public int owner_id { get; set; }
        public string owner { get; set; }

        public Vector3[] planta_position { get; set; } = new Vector3[10];
        public int[] planta_processo { get; set; } = new int[10];
        public int[] stage { get; set; } = new int[10];
        public Entity[] planta_handle { get; set; } = new Entity[10];
        public TextLabel[] planta_label { get; set; } = new TextLabel[10];
        public TimerEx[] planta_timer { get; set; } = new TimerEx[10];
        public ColShape[] planta_area { get; set; } = new ColShape[10];
        public TimerEx timeout { get; set; }


        public override int GetHashCode()
        {
            return id;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            FarmDataEnum objAsPart = obj as FarmDataEnum;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }

        public bool Equals(FarmDataEnum other)
        {
            if (other == null) return false;
            return (this.id.Equals(other.id));
        }
    }

    public static List<FarmDataEnum> farm_data = new List<FarmDataEnum>();
    public static List<dynamic> farm_positions = new List<dynamic>();
    //452618762
    public Farm()
    {

        #region plants
        /*| Planta:1 | */
        farm_positions.Add(new { id = 0, position = new Vector3(2819.285, 4590.81, 46.01157) });//0, 0, 13.81388
        farm_positions.Add(new { id = 0, position = new Vector3(2817.019, 4600.343, 45.86439) });//0, 0, 12.92601
        farm_positions.Add(new { id = 0, position = new Vector3(2814.621, 4609.897, 45.72063) });//0, 0, 0.227016
        farm_positions.Add(new { id = 0, position = new Vector3(2812.344, 4618.636, 45.52293) });//0, 0, 13.36939
        farm_positions.Add(new { id = 0, position = new Vector3(2810.872, 4624.638, 45.36023) });//0, 0, 1.094714
        farm_positions.Add(new { id = 0, position = new Vector3(2809.43, 4629.862, 45.25971) });//0, 0, 13.80371
        farm_positions.Add(new { id = 0, position = new Vector3(2807.834, 4635.706, 45.10812) });//0, 0, 15.27542
        farm_positions.Add(new { id = 0, position = new Vector3(2805.785, 4642.744, 44.99189) });//0, 0, 15.89695

        /*| Planta:2 | */
        farm_positions.Add(new { id = 1, position = new Vector3(2810.015, 4650.641, 45.58198) });  //Saved Rotation: 0, 0, 191.4806
                                                                                                   /*| Planta:2 | */
        farm_positions.Add(new { id = 1, position = new Vector3(2812.212, 4642.152, 45.35258) });  //Saved Rotation: 0, 0, 194.3143
                                                                                                   /*| Planta:2 | */
        farm_positions.Add(new { id = 1, position = new Vector3(2814.516, 4633.078, 45.65389) });  //Saved Rotation: 0, 0, 193.9836
                                                                                                   /*| Planta:2 | */
        farm_positions.Add(new { id = 1, position = new Vector3(2816.351, 4626.463, 45.88874) });  //Saved Rotation: 0, 0, 194.7011
                                                                                                   /*| Planta:2 | */
        farm_positions.Add(new { id = 1, position = new Vector3(2818.282, 4619.442, 46.17316) });  //Saved Rotation: 0, 0, 184.0391
                                                                                                   /*| Planta:2 | */
        farm_positions.Add(new { id = 1, position = new Vector3(2820.821, 4609.021, 46.33312) });  //Saved Rotation: 0, 0, 193.6635
                                                                                                   /*| Planta:2 | */
        farm_positions.Add(new { id = 1, position = new Vector3(2823.408, 4598.377, 46.39134) });  //Saved Rotation: 0, 0, 193.6467
                                                                                                   /*| Planta:2 | */
        farm_positions.Add(new { id = 1, position = new Vector3(2825.856, 4590.68, 46.59673) });  //Saved Rotation: 0, 0, 202.3448

        /*| Planta:3 | */
        farm_positions.Add(new { id = 2, position = new Vector3(2831.639, 4591.493, 46.68972) });  //Saved Rotation: 0, 0, 10.72754
                                                                                                   /*| Planta:2 | */
        farm_positions.Add(new { id = 2, position = new Vector3(2829.807, 4600.079, 46.55554) });  //Saved Rotation: 0, 0, 11.9936
                                                                                                   /*| Planta:3 | */
        farm_positions.Add(new { id = 2, position = new Vector3(2827.223, 4610.038, 46.61388) });  //Saved Rotation: 0, 0, 14.34238
                                                                                                   /*| Planta:3 | */
        farm_positions.Add(new { id = 2, position = new Vector3(2824.607, 4620.274, 46.62539) });  //Saved Rotation: 0, 0, 5.321707
                                                                                                   /*| Planta:3 | */
        farm_positions.Add(new { id = 2, position = new Vector3(2822.207, 4629.105, 46.26065) });  //Saved Rotation: 0, 0, 15.56785
                                                                                                   /*| Planta:3 | */
        farm_positions.Add(new { id = 2, position = new Vector3(2819.63, 4638.503, 45.6716) });  //Saved Rotation: 0, 0, 96.83367
                                                                                                 /*| Planta:3 | */
        farm_positions.Add(new { id = 2, position = new Vector3(2817.461, 4647.289, 45.37757) });  //Saved Rotation: 0, 0, 13.86616
                                                                                                   /*| Planta:3 | */
        farm_positions.Add(new { id = 2, position = new Vector3(2815.107, 4656.36, 45.72921) });  //Saved Rotation: 0, 0, 16.47417

        /*| Planta:4 | */
        farm_positions.Add(new { id = 3, position = new Vector3(2820.344, 4659.484, 46.57675) });  //Saved Rotation: 0, 0, 190.3192
                                                                                                   /*| Planta:4 | */
        farm_positions.Add(new { id = 3, position = new Vector3(2822.68, 4649.973, 46.07211) });  //Saved Rotation: 0, 0, 193.7063
                                                                                                  /*| Planta:4 | */
        farm_positions.Add(new { id = 3, position = new Vector3(2825.025, 4640.764, 46.0577) });  //Saved Rotation: 0, 0, 196.4094
                                                                                                  /*| Planta:4 | */
        farm_positions.Add(new { id = 3, position = new Vector3(2827.541, 4631.586, 46.45869) });  //Saved Rotation: 0, 0, 196.0007
                                                                                                   /*| Planta:4 | */
        farm_positions.Add(new { id = 3, position = new Vector3(2830.096, 4621.916, 46.84656) });  //Saved Rotation: 0, 0, 194.1313
                                                                                                   /*| Planta:4 | */
        farm_positions.Add(new { id = 3, position = new Vector3(2832.817, 4611.457, 47.02648) });  //Saved Rotation: 0, 0, 195.5886
                                                                                                   /*| Planta:4 | */
        farm_positions.Add(new { id = 3, position = new Vector3(2835.365, 4601.596, 47.09117) });  //Saved Rotation: 0, 0, 194.3467
                                                                                                   /*| Planta:4 | */
        farm_positions.Add(new { id = 3, position = new Vector3(2837.265, 4594.343, 47.25248) });  //Saved Rotation: 0, 0, 195.4834

        /*| Planta:5 | */
        farm_positions.Add(new { id = 4, position = new Vector3(2843.368, 4595.236, 47.68617) });  //Saved Rotation: 0, 0, 11.47363
                                                                                                   /*| Planta:5 | */
        farm_positions.Add(new { id = 4, position = new Vector3(2840.471, 4606.525, 47.64782) });  //Saved Rotation: 0, 0, 17.19021
                                                                                                   /*| Planta:5 | */
        farm_positions.Add(new { id = 4, position = new Vector3(2838.249, 4615.946, 47.75314) });  //Saved Rotation: 0, 0, 14.07311
                                                                                                   /*| Planta:5 | */
        farm_positions.Add(new { id = 4, position = new Vector3(2836.354, 4623.256, 47.73525) });  //Saved Rotation: 0, 0, 12.82846
                                                                                                   /*| Planta:5 | */
        farm_positions.Add(new { id = 4, position = new Vector3(2833.972, 4631.578, 47.39716) });  //Saved Rotation: 0, 0, 16.29397
                                                                                                   /*| Planta:5 | */
        farm_positions.Add(new { id = 4, position = new Vector3(2831.284, 4642.436, 46.70546) });  //Saved Rotation: 0, 0, 13.11125
                                                                                                   /*| Planta:5 | */
        farm_positions.Add(new { id = 4, position = new Vector3(2828.89, 4651.208, 46.50411) });  //Saved Rotation: 0, 0, 11.15384
                                                                                                  /*| Planta:5 | */
        farm_positions.Add(new { id = 4, position = new Vector3(2826.847, 4659.148, 46.79797) });  //Saved Rotation: 0, 0, 15.54745

        /*| Planta:6 | */
        farm_positions.Add(new { id = 5, position = new Vector3(2831.912, 4662.123, 46.97111) });  //Saved Rotation: 0, 0, 180.079
                                                                                                   /*| Planta:6 | */
        farm_positions.Add(new { id = 5, position = new Vector3(2833.837, 4653.99, 47.03828) });  //Saved Rotation: 0, 0, 195.0302
                                                                                                  /*| Planta:6 | */
        farm_positions.Add(new { id = 5, position = new Vector3(2836.333, 4644.899, 47.43225) });  //Saved Rotation: 0, 0, 195.4906
                                                                                                   /*| Planta:6 | */
        farm_positions.Add(new { id = 5, position = new Vector3(2839.148, 4634.309, 48.16465) });  //Saved Rotation: 0, 0, 195.129
                                                                                                   /*| Planta:6 | */
        farm_positions.Add(new { id = 5, position = new Vector3(2841.691, 4624.667, 48.5155) });  //Saved Rotation: 0, 0, 194.0527
                                                                                                  /*| Planta:6 | */
        farm_positions.Add(new { id = 5, position = new Vector3(2844.323, 4614.163, 48.18532) });  //Saved Rotation: 0, 0, 194.5265
                                                                                                   /*| Planta:6 | */
        farm_positions.Add(new { id = 5, position = new Vector3(2847.119, 4603.374, 47.87349) });  //Saved Rotation: 0, 0, 194.1947
                                                                                                   /*| Planta:6 | */
        farm_positions.Add(new { id = 5, position = new Vector3(2849.912, 4592.563, 47.54443) });  //Saved Rotation: 0, 0, 195.3149

        /*| Planta:7 | */
        farm_positions.Add(new { id = 6, position = new Vector3(2854.146, 4601.826, 47.99647) });  //Saved Rotation: 0, 0, 13.99804
                                                                                                   /*| Planta:7 | */
        farm_positions.Add(new { id = 6, position = new Vector3(2851.892, 4611.13, 48.24702) });  //Saved Rotation: 0, 0, 14.08366
                                                                                                  /*| Planta:7 | */
        farm_positions.Add(new { id = 6, position = new Vector3(2849.433, 4620.193, 48.81622) });  //Saved Rotation: 0, 0, 15.43792
                                                                                                   /*| Planta:7 | */
        farm_positions.Add(new { id = 6, position = new Vector3(2847.88, 4626.407, 48.98029) });  //Saved Rotation: 0, 0, 14.90803
                                                                                                  /*| Planta:7 | */
        farm_positions.Add(new { id = 6, position = new Vector3(2845.439, 4635.577, 48.81557) });  //Saved Rotation: 0, 0, 14.98005
                                                                                                   /*| Planta:7 | */
        farm_positions.Add(new { id = 6, position = new Vector3(2843.266, 4643.469, 48.36669) });  //Saved Rotation: 0, 0, 16.00194
                                                                                                   /*| Planta:7 | */
        farm_positions.Add(new { id = 6, position = new Vector3(2840.921, 4652.431, 47.76951) });  //Saved Rotation: 0, 0, 14.51354
                                                                                                   /*| Planta:7 | */
        farm_positions.Add(new { id = 6, position = new Vector3(2838.602, 4661.922, 47.31548) });  //Saved Rotation: 0, 0, 13.19778

        /*| Planta:8 | */
        farm_positions.Add(new { id = 7, position = new Vector3(2843.927, 4664.641, 47.60743) });  //Saved Rotation: 0, 0, 179.3434
                                                                                                   /*| Planta:8 | */
        farm_positions.Add(new { id = 7, position = new Vector3(2846.399, 4653.99, 48.20502) });  //Saved Rotation: 0, 0, 193.8186
                                                                                                  /*| Planta:8 | */
        farm_positions.Add(new { id = 7, position = new Vector3(2848.745, 4644.776, 48.60008) });  //Saved Rotation: 0, 0, 194.399
                                                                                                   /*| Planta:8 | */
        farm_positions.Add(new { id = 7, position = new Vector3(2850.92, 4636.945, 48.91176) });  //Saved Rotation: 0, 0, 196.0756
                                                                                                  /*| Planta:8 | */
        farm_positions.Add(new { id = 7, position = new Vector3(2853.375, 4627.451, 49.06425) });  //Saved Rotation: 0, 0, 194.1665
                                                                                                   /*| Planta:8 | */
        farm_positions.Add(new { id = 7, position = new Vector3(2856.518, 4614.938, 48.40223) });  //Saved Rotation: 0, 0, 194.0241
                                                                                                   /*| Planta:8 | */
        farm_positions.Add(new { id = 7, position = new Vector3(2858.673, 4606.853, 48.04885) });  //Saved Rotation: 0, 0, 195.5002
                                                                                                   /*| Planta:8 | */
        farm_positions.Add(new { id = 7, position = new Vector3(2861.367, 4596.712, 47.94931) });  //Saved Rotation: 0, 0, 197.8375

        /*| Planta:9 | */
        farm_positions.Add(new { id = 8, position = new Vector3(2867.983, 4597.36, 47.9773) });  //Saved Rotation: 0, 0, 12.82129
                                                                                                 /*| Planta:9 | */
        farm_positions.Add(new { id = 8, position = new Vector3(2865.696, 4607.472, 48.0582) });  //Saved Rotation: 0, 0, 12.84677
                                                                                                  /*| Planta:9 | */
        farm_positions.Add(new { id = 8, position = new Vector3(2863.428, 4615.568, 48.45422) });  //Saved Rotation: 0, 0, 16.10618
                                                                                                   /*| Planta:9 | */
        farm_positions.Add(new { id = 8, position = new Vector3(2861.038, 4624.397, 48.92719) });  //Saved Rotation: 0, 0, 14.98077
                                                                                                   /*| Planta:9 | */
        farm_positions.Add(new { id = 8, position = new Vector3(2857.357, 4638.428, 48.83183) });  //Saved Rotation: 0, 0, 14.39099
                                                                                                   /*| Planta:9 | */
        farm_positions.Add(new { id = 8, position = new Vector3(2855.205, 4646.672, 48.56289) });  //Saved Rotation: 0, 0, 14.95672
                                                                                                   /*| Planta:9 | */
        farm_positions.Add(new { id = 8, position = new Vector3(2852.747, 4655.928, 48.2637) });  //Saved Rotation: 0, 0, 14.9346
                                                                                                  /*| Planta:9 | */
        farm_positions.Add(new { id = 8, position = new Vector3(2850.668, 4664.969, 47.85279) });  //Saved Rotation: 0, 0, 12.58207

        /*| Planta:10 | */
        farm_positions.Add(new { id = 9, position = new Vector3(2856.259, 4666.769, 47.86635) });  //Saved Rotation: 0, 0, 178.5736
                                                                                                   /*| Planta:10 | */
        farm_positions.Add(new { id = 9, position = new Vector3(2858.5, 4657.759, 48.14755) });  //Saved Rotation: 0, 0, 193.2476
                                                                                                 /*| Planta:10 | */
        farm_positions.Add(new { id = 9, position = new Vector3(2861.027, 4648.212, 48.45236) });  //Saved Rotation: 0, 0, 195.5795
                                                                                                   /*| Planta:10 | */
        farm_positions.Add(new { id = 9, position = new Vector3(2863.571, 4638.669, 48.75502) });  //Saved Rotation: 0, 0, 194.3513
                                                                                                   /*| Planta:10 | */
        farm_positions.Add(new { id = 9, position = new Vector3(2865.743, 4630.312, 48.92551) });  //Saved Rotation: 0, 0, 193.016
                                                                                                   /*| Planta:10 | */
        farm_positions.Add(new { id = 9, position = new Vector3(2868.574, 4619.111, 48.60645) });  //Saved Rotation: 0, 0, 194.5177
                                                                                                   /*| Planta:10 | */
        farm_positions.Add(new { id = 9, position = new Vector3(2871.082, 4609.81, 48.12423) });  //Saved Rotation: 0, 0, 195.2078
                                                                                                  /*| Planta:10 | */
        farm_positions.Add(new { id = 9, position = new Vector3(2873.733, 4598.895, 48.01728) });  //Saved Rotation: 0, 0, 193.5372

        /*| Planta:11 | */
        farm_positions.Add(new { id = 10, position = new Vector3(2879.914, 4600.518, 48.08625) });  //Saved Rotation: 0, 0, 6.082585
                                                                                                    /*| Planta:11 | */
        farm_positions.Add(new { id = 10, position = new Vector3(2876.576, 4613.082, 48.29459) });  //Saved Rotation: 0, 0, 11.70603
                                                                                                    /*| Planta:11 | */
        farm_positions.Add(new { id = 10, position = new Vector3(2873.471, 4625.097, 48.9022) });  //Saved Rotation: 0, 0, 15.56739
                                                                                                   /*| Planta:11 | */
        farm_positions.Add(new { id = 10, position = new Vector3(2871.555, 4632.987, 48.88703) });  //Saved Rotation: 0, 0, 13.5301
                                                                                                    /*| Planta:11 | */
        farm_positions.Add(new { id = 10, position = new Vector3(2869.351, 4641.46, 48.69492) });  //Saved Rotation: 0, 0, 14.58195
        farm_positions.Add(new { id = 10, position = new Vector3(2866.255, 4653.323, 48.35918) });  //Saved Rotation: 0, 0, 15.45948
        farm_positions.Add(new { id = 10, position = new Vector3(2863.919, 4661.912, 48.10996) });  //Saved Rotation: 0, 0, 15.19718
        farm_positions.Add(new { id = 10, position = new Vector3(2862.045, 4669.472, 47.79199) });  //Saved Rotation: 0, 0, 13.59523

        /*| Planta:12 | */
        farm_positions.Add(new { id = 11, position = new Vector3(2867.894, 4670.633, 47.93945) });  //Saved Rotation: 0, 0, 179.4812
        farm_positions.Add(new { id = 11, position = new Vector3(2870.319, 4660.459, 48.2729) });  //Saved Rotation: 0, 0, 194.9905
        farm_positions.Add(new { id = 11, position = new Vector3(2872.626, 4651.233, 48.49558) });  //Saved Rotation: 0, 0, 194.285
        farm_positions.Add(new { id = 11, position = new Vector3(2875.041, 4642.545, 48.67566) });  //Saved Rotation: 0, 0, 195.99
        farm_positions.Add(new { id = 11, position = new Vector3(2877.108, 4634.233, 48.86248) });  //Saved Rotation: 0, 0, 193.3974
        farm_positions.Add(new { id = 11, position = new Vector3(2880.289, 4621.549, 48.68216) });  //Saved Rotation: 0, 0, 194.1708
        farm_positions.Add(new { id = 11, position = new Vector3(2882.482, 4613.036, 48.23039) });  //Saved Rotation: 0, 0, 194.6194
        farm_positions.Add(new { id = 11, position = new Vector3(2885.154, 4603.09, 48.06585) });  //Saved Rotation: 0, 0, 197.6813

        /*| Planta:13 | */
        farm_positions.Add(new { id = 12, position = new Vector3(2891.502, 4604.128, 48.07504) });  //Saved Rotation: 0, 0, 356.5722
        farm_positions.Add(new { id = 12, position = new Vector3(2888.556, 4615.474, 48.25878) });  //Saved Rotation: 0, 0, 12.98925
        farm_positions.Add(new { id = 12, position = new Vector3(2886.081, 4625.525, 48.80108) });  //Saved Rotation: 0, 0, 13.66723
        farm_positions.Add(new { id = 12, position = new Vector3(2883.525, 4634.82, 48.79961) });  //Saved Rotation: 0, 0, 15.20839
        farm_positions.Add(new { id = 12, position = new Vector3(2880.837, 4644.915, 48.65255) });  //Saved Rotation: 0, 0, 14.79565
        farm_positions.Add(new { id = 12, position = new Vector3(2878.336, 4654.7, 48.4843) });  //Saved Rotation: 0, 0, 14.41102
        farm_positions.Add(new { id = 12, position = new Vector3(2875.667, 4664.091, 48.29714) });  //Saved Rotation: 0, 0, 15.80697
        farm_positions.Add(new { id = 12, position = new Vector3(2873.959, 4671.856, 48.09782) });  //Saved Rotation: 0, 0, 11.53819

        /*| Planta:14 | */
        farm_positions.Add(new { id = 13, position = new Vector3(2879.854, 4672.056, 48.33785) });  //Saved Rotation: 0, 0, 193.6605
        farm_positions.Add(new { id = 13, position = new Vector3(2882.41, 4661.061, 48.53912) });  //Saved Rotation: 0, 0, 192.6854
        farm_positions.Add(new { id = 13, position = new Vector3(2885.059, 4651.066, 48.64046) });  //Saved Rotation: 0, 0, 195.383
        farm_positions.Add(new { id = 13, position = new Vector3(2886.883, 4644.773, 48.70081) });  //Saved Rotation: 0, 0, 196.4724
        farm_positions.Add(new { id = 13, position = new Vector3(2888.775, 4637.097, 48.80029) });  //Saved Rotation: 0, 0, 193.3773
        farm_positions.Add(new { id = 13, position = new Vector3(2891.565, 4626.231, 48.71928) });  //Saved Rotation: 0, 0, 194.9261
        farm_positions.Add(new { id = 13, position = new Vector3(2894.369, 4615.038, 48.16958) });  //Saved Rotation: 0, 0, 194.1225
        farm_positions.Add(new { id = 13, position = new Vector3(2897.545, 4602.767, 48.01132) });  //Saved Rotation: 0, 0, 194.6325
        #endregion plants

        //foreach()
        farm_data.Add(new FarmDataEnum { id = 0, owner_id = -1 });
        farm_data.Add(new FarmDataEnum { id = 1, owner_id = -1 });
        farm_data.Add(new FarmDataEnum { id = 2, owner_id = -1 });
        farm_data.Add(new FarmDataEnum { id = 3, owner_id = -1 });
        farm_data.Add(new FarmDataEnum { id = 4, owner_id = -1 });
        farm_data.Add(new FarmDataEnum { id = 5, owner_id = -1 });
        farm_data.Add(new FarmDataEnum { id = 6, owner_id = -1 });
        farm_data.Add(new FarmDataEnum { id = 7, owner_id = -1 });
        farm_data.Add(new FarmDataEnum { id = 8, owner_id = -1 });
        farm_data.Add(new FarmDataEnum { id = 9, owner_id = -1 });
        farm_data.Add(new FarmDataEnum { id = 10, owner_id = -1 });
        farm_data.Add(new FarmDataEnum { id = 11, owner_id = -1 });
        farm_data.Add(new FarmDataEnum { id = 12, owner_id = -1 });
        farm_data.Add(new FarmDataEnum { id = 13, owner_id = -1 });

        int index = 0;
        int plants_index = 0;
        foreach (var farm in farm_data)
        {
            foreach (var plants in farm_positions)
            {
                if (plants.id == index)
                {
                    farm.planta_processo[plants_index] = 0;
                    farm.planta_position[plants_index] = plants.position;
                    plants_index++;
                }
            }
            index++;
            plants_index = 0;
        }



        Entity temp_blip;
        temp_blip = NAPI.Blip.CreateBlip(new Vector3(2832.978, 4571.757, 46.95262));
        NAPI.Blip.SetBlipName(temp_blip, "Bauernhof");
        NAPI.Blip.SetBlipSprite(temp_blip, 409);
        NAPI.Blip.SetBlipScale(temp_blip, 1.2f);
        NAPI.Blip.SetBlipColor(temp_blip, 47);
        NAPI.Blip.SetBlipShortRange(temp_blip, true);

        temp_blip = NAPI.Blip.CreateBlip(new Vector3(2886.25, 4386.166, 50.73577));
        NAPI.Blip.SetBlipName(temp_blip, "Bauernhof");
        NAPI.Blip.SetBlipSprite(temp_blip, 374);
        NAPI.Blip.SetBlipScale(temp_blip, 1.0f);
        NAPI.Blip.SetBlipColor(temp_blip, 47);
        NAPI.Blip.SetBlipShortRange(temp_blip, true);

        NAPI.TextLabel.CreateTextLabel("~y~Drücke E", new Vector3(2886.25, 4386.166, 50.73577 + 1.5), 12, 0.350f, 4, new Color(255, 255, 255, 255));

        NAPI.TextLabel.CreateTextLabel("~y~Drücke E", new Vector3(2832.978, 4571.757, 46.95262 + 1.5), 12, 0.350f, 4, new Color(255, 255, 255, 255));

    }

    public static void OnEnterDynamicArea(Client player, ColShape area)
    {
        int index = 0;
        foreach (var farm in farm_data)
        {
            if (farm.owner_id == Main.getIdFromClient(player))
            {
                for (int i = 0; i < 8; i++)
                {
                    if (area == farm.planta_area[i] && player.IsInVehicle && farm.stage[i] != 4 && farm.stage[i] != 1 && farm.stage[i] != 5 && NAPI.Entity.GetEntityModel(player.Vehicle) == (uint)VehicleHash.Tractor2)
                    {
                        player.TriggerEvent("blip_color", "farm_" + i, 69);

                        farm.stage[i] = 4;
                        UpdateLabel(index, i);
                        return;
                    }
                }
            }
            index++;
        }
    }

    public static void UpdateLabel(int index, int i)
    {
        if (farm_data[index].stage[i] == 1)
        {
            farm_data[index].planta_label[i].Text = "~y~Farm Ground ~y~[Besitzer: " + farm_data[index].owner + "]";
        }
        else if (farm_data[index].stage[i] == 2)
        {
            farm_data[index].planta_label[i].Text = "~y~Farm Ground ~y~[Besitzer: " + farm_data[index].owner + "]~n~~w~Fortschritt [ ~g~" + farm_data[index].planta_processo[i] + "%~w~ ]";
        }
        else if (farm_data[index].stage[i] == 3)
        {
            farm_data[index].planta_label[i].Text = "~y~Farm Ground ~y~[Besitzer: " + farm_data[index].owner + "]~n~~w~Fortschritt [ ~g~" + farm_data[index].planta_processo[i] + "%~w~ ]";
        }
        else if (farm_data[index].stage[i] == 4)
        {
            farm_data[index].planta_label[i].Text = "~y~Farm Ground ~y~[Besitzer: " + farm_data[index].owner + "]~n~~w~Fortschritt [ ~g~" + farm_data[index].planta_processo[i] + "%~w~ ]";
        }
        else if (farm_data[index].stage[i] == 5)
        {
            farm_data[index].planta_label[i].Text = "~y~Farm Ground ~y~[Besitzer: " + farm_data[index].owner + "]~n~~w~Drücke ~y~E~w~";
        }
    }

    public static void collectorCarsSpawner()
    {
        Main_VehicleManage.CreateVehicle(9, VehicleHash.Tractor2, new Vector3(2866.143, 4568.597, 47.22054), new Vector3(4.038138, 1.470755, 20.47495), 89, 111, "FARM-30", "FARM");

        Main_VehicleManage.CreateVehicle(9, VehicleHash.Tractor2, new Vector3(2861.435, 4567.03, 47.30069), new Vector3(4.038138, 1.470755, 20.47495), 89, 111, "FARM-30", "FARM");
        Main_VehicleManage.CreateVehicle(9, VehicleHash.Tractor2, new Vector3(2856.933, 4566.28, 47.25106), new Vector3(4.038138, 1.470755, 20.47495), 89, 111, "FARM-30", "FARM");
        Main_VehicleManage.CreateVehicle(9, VehicleHash.Tractor2, new Vector3(2849.919, 4564.381, 47.09895), new Vector3(4.038138, 1.470755, 20.47495), 89, 111, "FARM-30", "FARM");
        Main_VehicleManage.CreateVehicle(9, VehicleHash.Tractor2, new Vector3(2870.864, 4570.599, 47.4136), new Vector3(4.038138, 1.470755, 20.47495), 89, 111, "FARM-30", "FARM");
        Main_VehicleManage.CreateVehicle(9, VehicleHash.Tractor2, new Vector3(2876.312, 4571.371, 47.45013), new Vector3(4.038138, 1.470755, 20.47495), 89, 111, "FARM-30", "FARM");
        Main_VehicleManage.CreateVehicle(9, VehicleHash.Tractor2, new Vector3(2883.64, 4573.192, 47.8042), new Vector3(4.038138, 1.470755, 20.47495), 89, 111, "FARM-30", "FARM");


    }

    public static void respawnCar(Vehicle veh)
    {
        try
        {
            int i = NAPI.Data.GetEntityData(veh, "NUMBER");
            NAPI.Entity.SetEntityPosition(veh, Main_VehicleManage.CarInfos[i].Position);
            NAPI.Entity.SetEntityRotation(veh, Main_VehicleManage.CarInfos[i].Rotation);
            veh.Repair();

            NAPI.Data.SetEntityData(veh, "ACCESS", "WORK");
            NAPI.Data.SetEntityData(veh, "WORK", 12);
            NAPI.Data.SetEntityData(veh, "TYPE", "FARM");
            NAPI.Data.SetEntityData(veh, "NUMBER", i);
            NAPI.Data.SetEntityData(veh, "ON_WORK", false);
            NAPI.Data.SetEntityData(veh, "DRIVER", null);

        }
        catch (Exception e) { API.Shared.ConsoleOutput("respawnCar: " + e.Message); }
    }


    public static void onPlayerDissconnectedHandler(Client player, DisconnectionType type, string reason)
    {
        try
        {
            if (!player.GetData("status")) return;
            try { if (!player.GetData("ON_WORK")) return; }
            catch { return; }
            if (Main_Job.GetPlayerJob(player) == 12 &&
                NAPI.Data.GetEntityData(player, "WORK") != null)
            {
                var vehicle = NAPI.Data.GetEntityData(player, "WORK");
                respawnCar(vehicle);
            }
        }
        catch (Exception e) { API.Shared.ConsoleOutput("PlayerDisconnected: " + e.Message); }
    }

    [ServerEvent(Event.PlayerExitVehicle)]
    public void onPlayerExitVehicleHandler(Client player, Vehicle vehicle)
    {
        try
        {
            //API.Shared.ConsoleOutput("WE ARE HERE");
            if (NAPI.Data.GetEntityData(vehicle, "TYPE") == "FARM" &&
            Main_Job.GetPlayerJob(player) == 12 &&
            NAPI.Data.GetEntityData(player, "ON_WORK") &&
            NAPI.Data.GetEntityData(player, "WORK") == vehicle)
            {
                //API.Shared.ConsoleOutput("WE ARE HERE2 ");
                Notify.Send(player, NotifyType.Warning, NotifyPosition.BottomCenter, $"Wenn Sie nach 5 Minuten nicht in das Fahrzeug einsteigen, dann endet der Arbeitstag.", 5000);
                NAPI.Data.SetEntityData(player, "IN_WORK_CAR", false);
                if (player.HasData("WORK_CAR_EXIT_TIMER"))
                {
                    //Main.StopT(NAPI.Data.GetEntityData(player, "WORK_CAR_EXIT_TIMER"), "timer_4");
                    //Timers.Stop(NAPI.Data.GetEntityData(player, "WORK_CAR_EXIT_TIMER"));
                    try
                    {
                        NAPI.Data.GetEntityData(player, "WORK_CAR_EXIT_TIMER").Kill();
                    }
                    catch
                    {
                    }
                }
                NAPI.Data.SetEntityData(player, "CAR_EXIT_TIMER_COUNT", 0);
                //NAPI.Data.SetEntityData(player, "WORK_CAR_EXIT_TIMER", Main.StartT(1000, 1000, (o) => timer_playerExitWorkVehicle(player, vehicle), "LAWNM_CAR_EXIT_TIMER"));
                //NAPI.Data.SetEntityData(player, "WORK_CAR_EXIT_TIMER", Timers.StartTask(1000, () => timer_playerExitWorkVehicle(player, vehicle)));

                player.SetData("WORK_CAR_EXIT_TIMER", TimerEx.SetTimer(() => timer_playerExitWorkVehicle(player, vehicle), 1000, 0));
            }
        }
        catch (Exception e) { API.Shared.ConsoleOutput("PlayerExitVehicle: " + e.Message); }
    }


    public static void timer_playerExitWorkVehicle(Client player, Vehicle vehicle)
    {
        NAPI.Task.Run(() =>
        {
            try
            {
                if (!player.HasData("WORK_CAR_EXIT_TIMER")) return;
                if (NAPI.Data.GetEntityData(player, "IN_WORK_CAR"))
                {
                    //Main.StopT(NAPI.Data.GetEntityData(player, "WORK_CAR_EXIT_TIMER"), "timer_5");
                    //Timers.Stop(NAPI.Data.GetEntityData(player, "WORK_CAR_EXIT_TIMER"));
                    try
                    {
                        NAPI.Data.GetEntityData(player, "WORK_CAR_EXIT_TIMER").Kill();
                    }
                    catch
                    {

                    }
                    NAPI.Data.ResetEntityData(player, "WORK_CAR_EXIT_TIMER");
                    return;
                }
                if (NAPI.Data.GetEntityData(player, "CAR_EXIT_TIMER_COUNT") > 5 * 60)
                {
                    respawnCar(vehicle);
                    NAPI.Data.SetEntityData(player, "ON_WORK", false);
                    NAPI.Data.SetEntityData(player, "WORK", null);
                    Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du hast den Arbeitstag beendet.", 5000);
                    Trigger.ClientEvent(player, "deleteCheckpoint", 4, 0);
                    //Main.StopT(NAPI.Data.GetEntityData(player, "WORK_CAR_EXIT_TIMER"), "timer_6");
                    //Timers.Stop(NAPI.Data.GetEntityData(player, "WORK_CAR_EXIT_TIMER"));
                    try
                    {
                        NAPI.Data.GetEntityData(player, "WORK_CAR_EXIT_TIMER").Kill();
                    }
                    catch
                    {

                    }


                    foreach (var old_farm in Farm.farm_data)
                    {
                        if (old_farm.owner_id == Main.getIdFromClient(player))
                        {
                            for (int i = 0; i < 8; i++)
                            {
                                try { old_farm.planta_label[i].Delete(); } catch (Exception) { }
                                try { old_farm.planta_handle[i].Delete(); } catch (Exception) { }
                                try { old_farm.planta_area[i].Delete(); } catch (Exception) { }

                                player.TriggerEvent("blip_remove", "farm_" + i);

                                old_farm.stage[i] = 0;
                                old_farm.planta_processo[i] = 0;
                            }
                            old_farm.owner_id = -1;
                            old_farm.owner = "";
                            try { old_farm.timeout.Kill(); } catch (Exception) { }

                        }
                    }



                    NAPI.Data.ResetEntityData(player, "WORK_CAR_EXIT_TIMER");
                    Main.UpdatePlayerClothes(player);
                    return;
                }
                NAPI.Data.SetEntityData(player, "CAR_EXIT_TIMER_COUNT", NAPI.Data.GetEntityData(player, "CAR_EXIT_TIMER_COUNT") + 1);
            }
            catch (Exception e) { API.Shared.ConsoleOutput("Timer_PlayerExitWorkVehicle_Lawnmower: " + e.Message); }
        });
    }

    [ServerEvent(Event.PlayerEnterVehicle)]
    public void onPlayerEnterVehicleHandler(Client player, Vehicle vehicle, sbyte seatid)
    {
        try
        {
            if (NAPI.Data.GetEntityData(vehicle, "TYPE") != "FARM" || player.VehicleSeat != -1) return;

            if (Main_Job.GetPlayerJob(player) == 12)
            {
                if (!NAPI.Data.GetEntityData(vehicle, "ON_WORK"))
                {
                    if (NAPI.Data.GetEntityData(player, "WORK") == null)
                    {
                        InteractMenu.ShowModal(player, "FARM_RENT", "Bauernhof", "Möchten Sie als Landwirt arbeiten?", "Ja", "Nein");
                    }
                    else if (NAPI.Data.GetEntityData(player, "WORK") == vehicle)
                    {
                        NAPI.Data.SetEntityData(player, "IN_WORK_CAR", true);


                    }
                }
                else
                {
                    if (NAPI.Data.GetEntityData(player, "WORK") != vehicle)
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"Es arbeitet bereits jemand mit diesem Fahrzeug. Bitte wählen Sie ein anderes aus.", 5000);
                        player.WarpOutOfVehicle();
                    }
                    else NAPI.Data.SetEntityData(player, "IN_WORK_CAR", true);
                }
            }
            else
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"Du arbeitest nicht als Bauer.", 5000);
                player.WarpOutOfVehicle();
            }
        }
        catch (Exception e) { API.Shared.ConsoleOutput("PlayerEnterVehicle: " + e.Message); }
    }

    public static void collectorRent(Client player)
    {
        if (NAPI.Player.IsPlayerInAnyVehicle(player) || player.VehicleSeat != -1 || player.Vehicle.GetData("TYPE") != "FARM")
        {




            //
            //
            //
            int playerid = Main.getIdFromClient(player);
            int index = 0;
            foreach (var farm in farm_data)
            {
                if (farm.owner_id == -1)
                {
                    farm.owner_id = playerid;
                    farm.owner = AccountManage.GetCharacterName(player);

                    for (int i = 0; i < 8; i++)
                    {
                        farm.stage[i] = 1;
                        farm.planta_label[i] = NAPI.TextLabel.CreateTextLabel("", farm.planta_position[i], 14.0f, 0.35f, 4, new Color(255, 255, 255, 255), false, 0);
                        farm.planta_handle[i] = API.Shared.CreateObject(452618762, new Vector3(farm.planta_position[i].X, farm.planta_position[i].Y, farm.planta_position[i].Z - 2.8f), new Vector3(), 255, 0);
                        NAPI.Entity.SetEntityModel(farm.planta_handle[i], 0);
                        farm.planta_area[i] = NAPI.ColShape.CreateCylinderColShape(farm.planta_position[i], 2.0f, 2.0f);
                        UpdateLabel(index, i);


                        player.TriggerEvent("blip_remove", "farm_" + i);
                        player.TriggerEvent("blip_create_ext", "farm_" + i, farm.planta_position[i], 33, 0.70f, 0, false, "Terreno");
                        player.TriggerEvent("blip_color", "farm_" + i, 33);
                    }
                    player.SetData("jobDuty", 1);

                    Main.SendInfoMessage(player, "Sie arbeiten jetzt als Landwirt. " + Main.EMBED_GREY + "Orte, an denen Sie pflanzen und kultivieren können, wurden Ihrer Minikarte hinzugefügt.");
                    Main.SendInfoMessage(player, "Pflanzen, kultivieren und ernten, um Getreide zu pflücken und an den Landwirt zu verkaufen.");


                    var way = 0;
                    //Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Você começou a trabalhar como coletor de lixo, siga os pontos de verificação", 5000);
                    var vehicle = player.Vehicle;
                    NAPI.Data.SetEntityData(player, "WORK", vehicle);
                    //Core.VehicleStreaming.SetEngineState(vehicle, true);
                    NAPI.Data.SetEntityData(player, "ON_WORK", true);
                    NAPI.Data.SetEntityData(player, "IN_WORK_CAR", true);
                    NAPI.Data.SetEntityData(vehicle, "ON_WORK", true);
                    NAPI.Data.SetEntityData(player, "WORKWAY", way);
                    NAPI.Data.SetEntityData(player, "WORKCHECK", 0);
                    NAPI.Data.SetEntityData(vehicle, "DRIVER", player);


                    farm.timeout = TimerEx.SetTimer(() =>
                    {
                        foreach (var old_farm in Farm.farm_data)
                        {
                            if (old_farm.owner_id == Main.getIdFromClient(player))
                            {
                                for (int i = 0; i < 8; i++)
                                {
                                    try { old_farm.planta_label[i].Delete(); } catch (Exception) { }
                                    try { old_farm.planta_handle[i].Delete(); } catch (Exception) { }
                                    try { old_farm.planta_area[i].Delete(); } catch (Exception) { }

                                    player.TriggerEvent("blip_remove", "farm_" + i);

                                    old_farm.stage[i] = 0;
                                    old_farm.planta_processo[i] = 0;
                                }
                                old_farm.owner_id = -1;
                                old_farm.owner = "";

                                player.SendChatMessage("* Der Job als Landwirt wurde abgesagt, die maximale Zeit bis zur Fertigstellung beträgt 20 Minuten.");
                            }
                        }

                    }, 15 * 60000, 1);
                    return;
                }
                index++;
            }
            Main.SendErrorMessage(player, "Derzeit haben wir keine offenen Stellen für einen Landwirt. Bitte versuchen Sie es später erneut.");


        }
        else
        {
            Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"Sie müssen im Transporter sein", 5000);
        }
    }

    public static void PressKeyY(Client player)
    {
        if (Main.IsInRangeOfPoint(player.Position, new Vector3(2886.25, 4386.166, 50.73577), 2.0f))
        {
            if (Inventory.GetPlayerItemFromInventory(player, 17) > 0)
            {
                InteractMenu.User_Input(player, "input_sell_grain", "Getreide verkaufen (Menge: " + Inventory.GetPlayerItemFromInventory(player, 17) + ")", Inventory.GetPlayerItemFromInventory(player, 17).ToString(), "", "number");
            }
        }
        else
        {


            int playerid = Main.getIdFromClient(player);
            int index = 0;
            foreach (var farm in farm_data)
            {
                if (farm.owner_id == playerid)
                {
                    for (int i = 0; i < 8; i++)
                    {
                        if (Main.IsInRangeOfPoint(player.Position, farm.planta_position[i], 1.0f))
                        {

                            if (farm.stage[i] == 5)
                            {
                                player.PlayScenario("WORLD_HUMAN_GARDENER_PLANT");
                                farm.stage[i] = 0;
                                NAPI.Task.Run(() =>
                                {

                                    farm.planta_label[i].Delete();
                                    farm.planta_handle[i].Delete();
                                    farm.planta_area[i].Delete();
                                    farm.planta_processo[i] = 0;
                                    player.TriggerEvent("blip_remove", "farm_" + i);

                                    int check_finish = 0;
                                    for (int b = 0; b < 8; b++)
                                    {
                                        if (farm.stage[b] == 0) check_finish++;
                                    }
                                    if (check_finish == 8)
                                    {
                                        farm.owner_id = -1;
                                        try { farm.timeout.Kill(); } catch (Exception) { }
                                    }
                                    player.StopAnimation();

                                    Inventory.GiveItemToInventory(player, 17, 1);

                                }, delayTime: 2800);
                            }
                            else if (farm.stage[i] == 1)
                            {
                                farm.stage[i] = 2;

                                player.PlayScenario("WORLD_HUMAN_GARDENER_PLANT");

                                NAPI.Task.Run(() =>
                                {
                                    player.TriggerEvent("blip_color", "farm_" + i, 51);
                                    UpdateLabel(index, i);
                                    player.StopAnimation();
                                }, delayTime: 2800);


                                //farm.planta_timer[i] = TimerEx.SetTimer(() =>
                                //{


                                //    if (farm_data[index].stage[i] == 4)
                                //    {

                                //        farm.planta_processo[i]++;
                                //        UpdateLabel(index, i);

                                //        switch (farm.planta_processo[i])
                                //        {
                                //            case 5: farm.planta_handle[i].MovePosition(new Vector3(farm.planta_position[i].X, farm.planta_position[i].Y, farm.planta_position[i].Z - 2.7f), 1000); break;
                                //            case 10: farm.planta_handle[i].MovePosition(new Vector3(farm.planta_position[i].X, farm.planta_position[i].Y, farm.planta_position[i].Z - 2.6f), 1000); break;
                                //            case 15: farm.planta_handle[i].MovePosition(new Vector3(farm.planta_position[i].X, farm.planta_position[i].Y, farm.planta_position[i].Z - 2.5f), 1000); break;
                                //            case 20: farm.planta_handle[i].MovePosition(new Vector3(farm.planta_position[i].X, farm.planta_position[i].Y, farm.planta_position[i].Z - 2.4f), 1000); break;
                                //            case 25: farm.planta_handle[i].MovePosition(new Vector3(farm.planta_position[i].X, farm.planta_position[i].Y, farm.planta_position[i].Z - 2.3f), 1000); break;
                                //            case 30: farm.planta_handle[i].MovePosition(new Vector3(farm.planta_position[i].X, farm.planta_position[i].Y, farm.planta_position[i].Z - 2.2f), 1000); break;
                                //            case 35: farm.planta_handle[i].MovePosition(new Vector3(farm.planta_position[i].X, farm.planta_position[i].Y, farm.planta_position[i].Z - 2.1f), 1000); break;
                                //            case 40: farm.planta_handle[i].MovePosition(new Vector3(farm.planta_position[i].X, farm.planta_position[i].Y, farm.planta_position[i].Z - 2.0f), 1000); break;
                                //            case 45: farm.planta_handle[i].MovePosition(new Vector3(farm.planta_position[i].X, farm.planta_position[i].Y, farm.planta_position[i].Z - 1.9f), 1000); break;
                                //            case 50: farm.planta_handle[i].MovePosition(new Vector3(farm.planta_position[i].X, farm.planta_position[i].Y, farm.planta_position[i].Z - 1.8f), 1000); break;
                                //            case 60: farm.planta_handle[i].MovePosition(new Vector3(farm.planta_position[i].X, farm.planta_position[i].Y, farm.planta_position[i].Z - 1.7f), 1000); break;
                                //            case 70: farm.planta_handle[i].MovePosition(new Vector3(farm.planta_position[i].X, farm.planta_position[i].Y, farm.planta_position[i].Z - 1.6f), 1000); break;
                                //            case 80: farm.planta_handle[i].MovePosition(new Vector3(farm.planta_position[i].X, farm.planta_position[i].Y, farm.planta_position[i].Z - 1.5f), 1000); break;
                                //            case 85: farm.planta_handle[i].MovePosition(new Vector3(farm.planta_position[i].X, farm.planta_position[i].Y, farm.planta_position[i].Z - 1.4f), 1000); break;
                                //            case 90: farm.planta_handle[i].MovePosition(new Vector3(farm.planta_position[i].X, farm.planta_position[i].Y, farm.planta_position[i].Z - 1.3f), 1000); break;
                                //            case 100: farm.planta_handle[i].MovePosition(new Vector3(farm.planta_position[i].X, farm.planta_position[i].Y, farm.planta_position[i].Z - 1.2f), 1000); break;
                                //        }

                                //        switch (farm.planta_processo[i])
                                //        {
                                //            case 5:  UpdateLabel(index, i); player.TriggerEvent("blip_color", "farm_" + i, 57); break;
                                //            case 10:  UpdateLabel(index, i); player.TriggerEvent("blip_color", "farm_" + i, 57); break;
                                //            case 15: farm_data[index].stage[i] = 3; UpdateLabel(index, i); player.TriggerEvent("blip_color", "farm_" + i, 57); break;
                                //            case 20:  UpdateLabel(index, i); player.TriggerEvent("blip_color", "farm_" + i, 57); break;
                                //            case 25:  UpdateLabel(index, i); player.TriggerEvent("blip_color", "farm_" + i, 57); break;
                                //            case 30:  UpdateLabel(index, i); player.TriggerEvent("blip_color", "farm_" + i, 57); break;
                                //            case 35: farm_data[index].stage[i] = 3; UpdateLabel(index, i); player.TriggerEvent("blip_color", "farm_" + i, 57); break;
                                //            case 40:  UpdateLabel(index, i); player.TriggerEvent("blip_color", "farm_" + i, 57); break;
                                //            case 45: UpdateLabel(index, i); player.TriggerEvent("blip_color", "farm_" + i, 57); break;
                                //            case 50:  UpdateLabel(index, i); player.TriggerEvent("blip_color", "farm_" + i, 57); break;
                                //            case 55: farm_data[index].stage[i] = 3; UpdateLabel(index, i); player.TriggerEvent("blip_color", "farm_" + i, 57); break;
                                //            case 60:  UpdateLabel(index, i); player.TriggerEvent("blip_color", "farm_" + i, 57); break;
                                //            case 65: UpdateLabel(index, i); player.TriggerEvent("blip_color", "farm_" + i, 57); break;
                                //            case 70:  UpdateLabel(index, i); player.TriggerEvent("blip_color", "farm_" + i, 57); break;
                                //            case 75: farm_data[index].stage[i] = 3; UpdateLabel(index, i); player.TriggerEvent("blip_color", "farm_" + i, 57); break;
                                //            case 80: UpdateLabel(index, i); player.TriggerEvent("blip_color", "farm_" + i, 57); break;
                                //            case 85:  UpdateLabel(index, i); player.TriggerEvent("blip_color", "farm_" + i, 57); break;
                                //            case 90:  UpdateLabel(index, i); player.TriggerEvent("blip_color", "farm_" + i, 57); break;
                                //            case 95: farm_data[index].stage[i] = 3; UpdateLabel(index, i); player.TriggerEvent("blip_color", "farm_" + i, 57); break;
                                //        }

                                //        if (farm.planta_processo[i] >= 99)
                                //        {
                                //            player.TriggerEvent("blip_color", "farm_" + i, 75);

                                //            farm.stage[i] = 5;
                                //            UpdateLabel(index, i);
                                //            farm.planta_timer[i].Kill();
                                //        }

                                //    }
                                //}, 1000, 0);
                            }
                            return;
                        }
                    }
                }
                index++;
            }
        }
    }
    public static void OnInputResponse(Client player, String response, String inputtext)
    {
        if (response == "input_sell_grain")
        {
            if (Inventory.GetPlayerItemFromInventory(player, 17) > 0)
            {

                if (!Main.IsNumeric(inputtext))
                {
                    Main.DisplayErrorMessage(player, "Der eingegebene Wert ist nicht numerisch, bitte geben Sie einen gültigen Wert ein.");
                    return;
                }

                int valor = Convert.ToInt32(inputtext);

                if (valor < 1)
                {
                    Main.DisplayErrorMessage(player, "Der eingegebene Wert darf nicht kleiner als 1 sein.");
                    return;
                }

                if (Inventory.GetPlayerItemFromInventory(player, 17) < valor)
                {
                    Main.DisplayErrorMessage(player, "Versuchen Sie zu verkaufen " + valor + " du hast aber nur " + Inventory.GetPlayerItemFromInventory(player, 17) + ".");
                    return;
                }

                int price = valor * 425;

                Main.GivePlayerMoney(player, price);
                Main.SendSuccessMessage(player, "Verkauft: " + Main.EMBED_BLUE + "" + valor + "" + Main.EMBED_WHITE + " für " + Main.EMBED_LIGHTGREEN + "$" + price.ToString("N0") + "" + Main.EMBED_WHITE + ".");
                Inventory.RemoveItemByType(player, 17, valor);
            }
        }
    }

    public static void ModalConfirm(Client player, string response)
    {
        if (response == "FARM_RENT") collectorRent(player);
    }

    public static void ModalCancel(Client player, string response)
    {
        if (response == "FARM_RENT") if (player.IsInVehicle) player.WarpOutOfVehicle();
    }
}

