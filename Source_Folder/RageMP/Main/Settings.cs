using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GTANetworkAPI;
using DerStr1k3r.SDK;

namespace DerStr1k3r.Settings
{
    public class Server
    {
        private static nLog Log = new nLog("Server Settings");

        public Server()
        {
            Console.WriteLine("Server Settings geladen...");
        }

        public static void Server_Version()
        {
            NAPI.Util.ConsoleOutput("/////////////////////////////////////////////////////");
            NAPI.Util.ConsoleOutput("// GTA5 RP Script V7.0");
            NAPI.Util.ConsoleOutput("/////////////////////////////////////////////////////");
            NAPI.Util.ConsoleOutput("// © 2019 - 2021 DerStr1k3r. All rights reserved.");
            NAPI.Util.ConsoleOutput("/////////////////////////////////////////////////////");
        }

        public static void Server_Blips()
        {
            Blip temp_blip = null;
            temp_blip = NAPI.Blip.CreateBlip(new Vector3(430.7088, -983.0495, 30.71043), 0);
            temp_blip.Sprite = 60;
            temp_blip.Name = "LS-PD";
            temp_blip.Color = 4;
            temp_blip.ShortRange = true;

            temp_blip = NAPI.Blip.CreateBlip(new Vector3(1853.288, 3686.897, 34.26708), 0);
            temp_blip.Sprite = 60;
            temp_blip.Name = "LS-SD";
            temp_blip.Color = 4;
            temp_blip.ShortRange = true;

            temp_blip = NAPI.Blip.CreateBlip(new Vector3(231.9941, 214.5453, 106.2801), 0);
            temp_blip.Sprite = 500;
            temp_blip.Name = "Bank von Los Santos";
            temp_blip.Color = 46;
            temp_blip.ShortRange = true;

            temp_blip = NAPI.Blip.CreateBlip(new Vector3(344.13, -586.23, 28.79), 0);
            temp_blip.Sprite = 489;
            temp_blip.Name = "Los Santos Medical Center State";
            temp_blip.Color = 6;
            temp_blip.ShortRange = true;

            temp_blip = NAPI.Blip.CreateBlip(new Vector3(-254.1596, 6332.582, 32.43636), 0);
            temp_blip.Sprite = 489;
            temp_blip.Name = "Los Santos Medical Center Paleto Bay";
            temp_blip.Color = 6;
            temp_blip.ShortRange = true;

            temp_blip = NAPI.Blip.CreateBlip(new Vector3(1831.917, 3681.9653, 34.271027), 0);
            temp_blip.Sprite = 489;
            temp_blip.Name = "Los Santos Medical Center Sandy Shore";
            temp_blip.Color = 6;
            temp_blip.ShortRange = true;

            temp_blip = NAPI.Blip.CreateBlip(new Vector3(-545.1009, -203.9025, 38.21515), 0);
            temp_blip.Sprite = 590;
            temp_blip.Name = "Rathaus";
            temp_blip.Color = 3;
            temp_blip.ShortRange = true;

            temp_blip = NAPI.Blip.CreateBlip(new Vector3(360.8557, -1602.078, 29.29205), 0);
            temp_blip.Sprite = 60;
            temp_blip.Name = "LS-PD Impound";
            temp_blip.Color = 56;
            temp_blip.ShortRange = true;

            temp_blip = NAPI.Blip.CreateBlip(new Vector3(-1140.054, -2005.987, 13.18026), 0);
            temp_blip.Sprite = 490;
            temp_blip.Name = "LS ACLS";
            temp_blip.Color = 45;
            temp_blip.ShortRange = true;

            temp_blip = NAPI.Blip.CreateBlip(new Vector3(903.7722, -173.3565, 74.07556), 0);
            temp_blip.Sprite = 198;
            temp_blip.Name = "Taxi Center";
            temp_blip.Color = 46;
            temp_blip.ShortRange = true;

            temp_blip = NAPI.Blip.CreateBlip(new Vector3(732.1028, -1089.363, 21.80265), 0);
            temp_blip.Sprite = 512;
            temp_blip.Name = "Lost MC Customs";
            temp_blip.Color = 46;
            temp_blip.ShortRange = true;

            temp_blip = NAPI.Blip.CreateBlip(new Vector3(-205.1028, -1309.793, 31.28942), 0);
            temp_blip.Sprite = 488;
            temp_blip.Name = "Bennys";
            temp_blip.Color = 46;
            temp_blip.ShortRange = true;

            temp_blip = NAPI.Blip.CreateBlip(new Vector3(-366.7836, -120.4633, 38.69604), 0);
            temp_blip.Sprite = 488;
            temp_blip.Name = "LS Customs";
            temp_blip.Color = 47;
            temp_blip.ShortRange = true;

            temp_blip = NAPI.Blip.CreateBlip(new Vector3(2749.514, 3470.527, 55.68787), 0);
            temp_blip.Sprite = 514;
            temp_blip.Name = "O.B.I.";
            temp_blip.Color = 47;
            temp_blip.ShortRange = true;

            temp_blip = NAPI.Blip.CreateBlip(new Vector3(146.8701, -716.3765, 33.13222), 0);
            temp_blip.Sprite = 487;
            temp_blip.Name = "LS FIB";
            temp_blip.Color = 4;
            temp_blip.ShortRange = true;

            temp_blip = NAPI.Blip.CreateBlip(new Vector3(485.4016, -1309.819, 29.24806), 0);
            temp_blip.Sprite = 147;
            temp_blip.Name = "Illegaler Tuner";
            temp_blip.Color = 4;
            temp_blip.ShortRange = true;

            temp_blip = NAPI.Blip.CreateBlip(new Vector3(1800.222, 2606.378, 45.56498), 0);
            temp_blip.Sprite = 188;
            temp_blip.Name = "LS Prison";
            temp_blip.Color = 49;
            temp_blip.ShortRange = true;

            temp_blip = NAPI.Blip.CreateBlip(new Vector3(-1726.55, -724.57, 10.86), 0);
            temp_blip.Sprite = 498;
            temp_blip.Name = "LS Handelskammer";
            temp_blip.Color = 37;
            temp_blip.ShortRange = true;

            temp_blip = NAPI.Blip.CreateBlip(new Vector3(-2348.78, 3267.35, 32.8108), 0);
            temp_blip.Sprite = 487;
            temp_blip.Name = "Army Fort Zancundo";
            temp_blip.Color = 76;
            temp_blip.ShortRange = true;

            temp_blip = NAPI.Blip.CreateBlip(new Vector3(2488.87, -383.925, 93.7355), 0);
            temp_blip.Sprite = 487;
            temp_blip.Name = "United States Navy";
            temp_blip.Color = 38;
            temp_blip.ShortRange = true;

            temp_blip = NAPI.Blip.CreateBlip(new Vector3(-941.8096, -3127.078, 13.7259), 0);
            temp_blip.Sprite = 315;
            temp_blip.Name = "LS Speedway";
            temp_blip.Color = 4;
            temp_blip.ShortRange = true;

            temp_blip = NAPI.Blip.CreateBlip(new Vector3(435.7797, 215.2411, 102.0459), 0);
            temp_blip.Sprite = 475;
            temp_blip.Name = "Port Motels";
            temp_blip.Color = 47;
            temp_blip.ShortRange = true;

            temp_blip = NAPI.Blip.CreateBlip(new Vector3(-1274.113, 315.5634, 64.39182), 0);
            temp_blip.Sprite = 475;
            temp_blip.Name = "Perrera Beach Motels";
            temp_blip.Color = 25;
            temp_blip.ShortRange = true;

            temp_blip = NAPI.Blip.CreateBlip(new Vector3(-877.9172, -2178.256, 8.689036), 0);
            temp_blip.Sprite = 475;
            temp_blip.Name = "Grown Jewels Motels";
            temp_blip.Color = 26;
            temp_blip.ShortRange = true;

            temp_blip = NAPI.Blip.CreateBlip(new Vector3(416.5617, -1108.615, 28.93262), 0);
            temp_blip.Sprite = 475;
            temp_blip.Name = "Yellow Motels";
            temp_blip.Color = 26;
            temp_blip.ShortRange = true;

            temp_blip = NAPI.Blip.CreateBlip(new Vector3(307.87268, -1550.5299, 29.329536), 0);
            temp_blip.Sprite = 255;
            temp_blip.Name = "Straßenverkehrsamt";
            temp_blip.Color = 28;
            temp_blip.ShortRange = true;

            temp_blip = NAPI.Blip.CreateBlip(new Vector3(332.63556, -1567.1102, 30.303411), 0);
            temp_blip.Sprite = 255;
            temp_blip.Name = "Schlüsseldienst";
            temp_blip.Color = 26;
            temp_blip.ShortRange = true;

            temp_blip = NAPI.Blip.CreateBlip(new Vector3(1241.0907, -356.5877, 69.028206), 0);
            temp_blip.Sprite = 306;
            temp_blip.Name = "Handelskammer Immobilie";
            temp_blip.Color = 29;
            temp_blip.ShortRange = true;

            temp_blip = NAPI.Blip.CreateBlip(new Vector3(-65.11523, 71.09959, 71.74913), 0);
            temp_blip.Sprite = 306;
            temp_blip.Name = "Handelskammer Immobilie";
            temp_blip.Color = 29;
            temp_blip.ShortRange = true;

            temp_blip = NAPI.Blip.CreateBlip(new Vector3(-2207.2, -385.9254, 13.32774), 0);
            temp_blip.Sprite = 306;
            temp_blip.Name = "Handelskammer Immobilie";
            temp_blip.Color = 29;
            temp_blip.ShortRange = true;

            temp_blip = NAPI.Blip.CreateBlip(new Vector3(378.4338, -828.1937, 29.30242), 0);
            temp_blip.Sprite = 306;
            temp_blip.Name = "Handelskammer Immobilie";
            temp_blip.Color = 29;
            temp_blip.ShortRange = true;

            temp_blip = NAPI.Blip.CreateBlip(new Vector3(236.9562, -408.11996, 47.924362), 0);
            temp_blip.Sprite = 498;
            temp_blip.Name = "Department of Justice";
            temp_blip.Color = 37;
            temp_blip.ShortRange = true;

            temp_blip = NAPI.Blip.CreateBlip(new Vector3(246.6974, -1597.109, 31.53195), 0);
            temp_blip.Sprite = 434;
            temp_blip.Name = "LS Job Center";
            temp_blip.Color = 46;
            temp_blip.ShortRange = true;

            temp_blip = NAPI.Blip.CreateBlip(new Vector3(-229.5177, -332.4742, 30.11302), 0);
            temp_blip.Sprite = 306;
            temp_blip.Name = "Handelskammer Immobilie";
            temp_blip.Color = 29;
            temp_blip.ShortRange = true;
        }

        public static void Server_Markers()
        {
            // Hotel System
            NAPI.TextLabel.CreateTextLabel("Yellow Motels", new Vector3(416.20956, -1108.3958, 30.05602 + 0.2), 12, 0.3500f, 0, new Color(255, 255, 255, 255));
            NAPI.TextLabel.CreateTextLabel("Grown Jewels Motel", new Vector3(-878.30664, -2178.9768, 9.809033 + 0.2), 12, 0.3500f, 0, new Color(255, 255, 255, 255));
            NAPI.TextLabel.CreateTextLabel("Port Motels", new Vector3(436.21335, 216.62991, 103.16568 + 0.2), 12, 0.3500f, 0, new Color(255, 255, 255, 255));
            NAPI.TextLabel.CreateTextLabel("Perrea Beach Motels", new Vector3(-1274.6196, 314.02087, 65.511856 + 0.2), 12, 0.3500f, 0, new Color(255, 255, 255, 255));
            NAPI.Marker.CreateMarker(27, new Vector3(416.20956, -1108.3958, 30.05602 - 0.5), new Vector3(), new Vector3(), 0.8f, new Color(255, 255, 255, 155));
            NAPI.Marker.CreateMarker(27, new Vector3(-878.30664, -2178.9768, 9.809033 - 0.5), new Vector3(), new Vector3(), 0.8f, new Color(255, 255, 255, 155));
            NAPI.Marker.CreateMarker(27, new Vector3(436.21335, 216.62991, 103.16568 - 0.5), new Vector3(), new Vector3(), 0.8f, new Color(255, 255, 255, 155));
            NAPI.Marker.CreateMarker(27, new Vector3(-1274.6196, 314.02087, 65.511856 - 0.5), new Vector3(), new Vector3(), 0.8f, new Color(255, 255, 255, 155));

            // Illegaler Tuner = Bitte noch entfernen!
            //NAPI.TextLabel.CreateTextLabel("- Nur eine Person kann das Illegale Tuning betreiben! - ", new Vector3(485.4016, -1309.819, 29.24806), 8.0f, 1.0f, 0, new Color(255, 255, 255, 255), false, 0);
            //NAPI.Marker.CreateMarker(27, new Vector3(485.4016, -1309.819, 29.24806 - 0.8), new Vector3(), new Vector3(), 4.5f, new Color(244, 217, 66, 150), false, 0);

            NAPI.TextLabel.CreateTextLabel("- Helikopter  - ", new Vector3(449.2292, -981.2446, 43.69167), 8.0f, 1.0f, 0, new Color(255, 255, 255, 255), false, 0);
            NAPI.Marker.CreateMarker(27, new Vector3(449.2292, -981.2446, 43.69167 - 0.8), new Vector3(), new Vector3(), 4.5f, new Color(244, 217, 66, 150), false, 0);

            NAPI.TextLabel.CreateTextLabel("- Helikopter - ", new Vector3(-450.1415, -306.9616, 78.16819), 8.0f, 1.0f, 0, new Color(255, 255, 255, 255), false, 0);
            NAPI.Marker.CreateMarker(27, new Vector3(-450.1415, -306.9616, 78.16819 - 0.8), new Vector3(), new Vector3(), 4.5f, new Color(244, 217, 66, 150), false, 0);

            NAPI.TextLabel.CreateTextLabel("~n~~b~Stempeluhr", new Vector3(460.0612, -990.2727, 30.6896 + 0.3), 12, 0.3500f, 4, new Color(255, 255, 255, 255));
            NAPI.Marker.CreateMarker(27, new Vector3(460.0612, -990.2727, 30.6896 - 1.0), new Vector3(), new Vector3(), 0.8f, new Color(255, 255, 255, 155));

            NAPI.TextLabel.CreateTextLabel("~n~~b~Stempeluhr", new Vector3(1852.207, 3689.865, 34.26708 + 0.3), 12, 0.3500f, 4, new Color(255, 255, 255, 255));
            NAPI.Marker.CreateMarker(27, new Vector3(1852.207, 3689.865, 34.26708 - 1.0), new Vector3(), new Vector3(), 0.8f, new Color(255, 255, 255, 155));

            NAPI.TextLabel.CreateTextLabel("~y~Kleiderschrank", new Vector3(-442.311, 6012.191, 31.71639 + 0.3), 12, 0.3500f, 4, new Color(255, 255, 255, 255));
            NAPI.Marker.CreateMarker(27, new Vector3(-442.311, 6012.191, 31.71639 - 1.0), new Vector3(), new Vector3(), 0.8f, new Color(255, 255, 255, 155));

            NAPI.TextLabel.CreateTextLabel("~y~Kleiderschrank", new Vector3(458.1619, -992.9954, 30.68959 + 0.3), 12, 0.3500f, 4, new Color(255, 255, 255, 255));
            NAPI.Marker.CreateMarker(27, new Vector3(458.1619, -992.9954, 30.68959 - 1.0), new Vector3(), new Vector3(), 0.8f, new Color(255, 255, 255, 155));

            NAPI.TextLabel.CreateTextLabel("~y~Kleiderschrank", new Vector3(451.6882, -993.0513, 30.68959 + 0.3), 12, 0.3500f, 4, new Color(255, 255, 255, 255));
            NAPI.Marker.CreateMarker(27, new Vector3(451.6882, -993.0513, 30.68959 - 1.0), new Vector3(), new Vector3(), 0.8f, new Color(255, 255, 255, 155));

            NAPI.TextLabel.CreateTextLabel("~y~Kleiderschrank", new Vector3(456.7283, -988.5403, 30.6896 + 0.3), 12, 0.3500f, 4, new Color(255, 255, 255, 255));
            NAPI.Marker.CreateMarker(27, new Vector3(456.7283, -988.5403, 30.6896 - 1.0), new Vector3(), new Vector3(), 0.8f, new Color(255, 255, 255, 155));

            NAPI.TextLabel.CreateTextLabel("~y~Kleiderschrank", new Vector3(1850.977, 3683.749, 34.26708 + 0.3), 12, 0.3500f, 4, new Color(255, 255, 255, 255));
            NAPI.Marker.CreateMarker(27, new Vector3(1850.977, 3683.749, 34.26708 - 1.0), new Vector3(), new Vector3(), 0.8f, new Color(255, 255, 255, 155));

            NAPI.TextLabel.CreateTextLabel("~g~~h~- Fahrzeug einparken", new Vector3(462.9306, -1014.615, 28.06764 + 0.3), 12, 0.3500f, 0, new Color(255, 255, 255, 255));
            NAPI.Marker.CreateMarker(27, new Vector3(462.9306, -1014.615, 28.06764 - 1.0), new Vector3(), new Vector3(), 0.8f, new Color(255, 255, 255, 155));

            // Faction Type 14
            NAPI.TextLabel.CreateTextLabel("~g~~h~- LS FIB - Fahrzeug Einparken", new Vector3(128.8711, -721.9634, 32.76905 + 0.3), 12, 0.3500f, 0, new Color(255, 255, 255, 255));
            NAPI.Marker.CreateMarker(27, new Vector3(128.8711, -721.9634, 32.76905 - 1.0), new Vector3(), new Vector3(), 0.8f, new Color(255, 255, 255, 155));

            NAPI.TextLabel.CreateTextLabel("~g~~h~- Fahrzeug einparken", new Vector3(-1796.047, 2998.922, 32.80937 + 0.3), 12, 0.3500f, 0, new Color(255, 255, 255, 255));
            NAPI.Marker.CreateMarker(27, new Vector3(-1796.047, 2998.922, 32.80937 - 1.0), new Vector3(), new Vector3(), 0.8f, new Color(255, 255, 255, 155));

            NAPI.TextLabel.CreateTextLabel("~g~~h~- Fahrzeug einparken", new Vector3(-1121.292, -2008.041, 13.17998 + 0.3), 12, 0.3500f, 0, new Color(255, 255, 255, 255));
            NAPI.Marker.CreateMarker(27, new Vector3(-1121.292, -2008.041, 13.17998 - 1.0), new Vector3(), new Vector3(), 0.8f, new Color(255, 255, 255, 155));

            NAPI.TextLabel.CreateTextLabel("~g~~h~- Fahrzeug einparken", new Vector3(463.3755, -1019.973, 28.10607 + 0.3), 12, 0.3500f, 0, new Color(255, 255, 255, 255));
            NAPI.Marker.CreateMarker(27, new Vector3(463.3755, -1019.973, 28.10607 - 1.0), new Vector3(), new Vector3(), 0.8f, new Color(255, 255, 255, 155));

            NAPI.TextLabel.CreateTextLabel("~g~~h~- Fahrzeug einparken", new Vector3(-355.8882, 6068.04, 31.49855 + 0.3), 12, 0.3500f, 0, new Color(255, 255, 255, 255));
            NAPI.Marker.CreateMarker(27, new Vector3(-355.8882, 6068.04, 31.49855 - 1.0), new Vector3(), new Vector3(), 0.8f, new Color(255, 255, 255, 155));

            NAPI.TextLabel.CreateTextLabel("~y~~h~- Garage des LS-SD", new Vector3(1868.748, 3695.093, 33.59127 + 0.3), 12, 0.650f, 0, new Color(255, 255, 255, 255));
            NAPI.Marker.CreateMarker(27, new Vector3(1868.748, 3695.093, 33.59127 - 1.0), new Vector3(), new Vector3(), 0.8f, new Color(255, 255, 255, 155));

            NAPI.TextLabel.CreateTextLabel("~y~~h~- Garage des LS-PD ", new Vector3(442.0854, -1014.646, 28.64312 + 0.3), 12, 0.650f, 0, new Color(255, 255, 255, 255));
            NAPI.Marker.CreateMarker(27, new Vector3(442.0854, -1014.646, 28.64312 - 1.0), new Vector3(), new Vector3(), 0.8f, new Color(255, 255, 255, 155));

            NAPI.TextLabel.CreateTextLabel("~y~~h~- Garage des LS FIB ", new Vector3(139.8818, -725.8235, 32.76768 + 0.3), 12, 0.650f, 0, new Color(255, 255, 255, 255));
            NAPI.Marker.CreateMarker(27, new Vector3(139.8818, -725.8235, 32.76768 - 1.0), new Vector3(), new Vector3(), 0.8f, new Color(255, 255, 255, 155));

            // Faction DB Type ID 15
            NAPI.TextLabel.CreateTextLabel("~y~~h~- Garage des LS ACLS ", new Vector3(-1149.349, -2015.081, 13.18026 + 0.3), 12, 0.650f, 0, new Color(255, 255, 255, 255));
            NAPI.Marker.CreateMarker(27, new Vector3(-1149.349, -2015.081, 13.18026 - 1.0), new Vector3(), new Vector3(), 0.8f, new Color(255, 255, 255, 155));
            // End

            // Faction DB Type ID 15
            NAPI.TextLabel.CreateTextLabel("~y~~h~- Garage der Army Fort Zancundo ", new Vector3(-1781.192, 2997.922, 32.80978 + 0.3), 12, 0.650f, 0, new Color(255, 255, 255, 255));
            NAPI.Marker.CreateMarker(27, new Vector3(-1781.192, 2997.922, 32.80978 - 1.0), new Vector3(), new Vector3(), 0.8f, new Color(255, 255, 255, 155));
            // End

            NAPI.TextLabel.CreateTextLabel("~y~~h~- Garage des LS-PD -", new Vector3(-359.3449, 6062.392, 31.50013 + 0.3), 12, 0.650f, 0, new Color(255, 255, 255, 255));
            NAPI.Marker.CreateMarker(27, new Vector3(-359.3449, 6062.392, 31.50013 - 1.0), new Vector3(), new Vector3(), 0.8f, new Color(255, 255, 255, 155));

            NAPI.TextLabel.CreateTextLabel("~y~~h~- Haftbereich", new Vector3(1690.666, 2592.404, 45.74735 + 0.3), 12, 0.3500f, 0, new Color(255, 255, 255, 255));
            NAPI.Marker.CreateMarker(27, new Vector3(1690.666, 2592.404, 45.74735 - 1.0), new Vector3(), new Vector3(), 0.8f, new Color(255, 255, 255, 155));

            NAPI.TextLabel.CreateTextLabel("~y~~h~- Haftbereich", new Vector3(-450.0119, 6016.234, 31.71639 + 0.3), 12, 0.3500f, 0, new Color(255, 255, 255, 255));
            NAPI.Marker.CreateMarker(27, new Vector3(1690.666, 2592.404, 45.74735 - 1.0), new Vector3(), new Vector3(), 0.8f, new Color(255, 255, 255, 155));
            //
            NAPI.Marker.CreateMarker(27, new Vector3(441.1094, -981.1485, 30.6896 - 1.0), new Vector3(), new Vector3(), 0.8f, new Color(255, 255, 255, 155));

            NAPI.TextLabel.CreateTextLabel("~y~~h~[ Garage ]", new Vector3(334.5246, -560.1913, 28.74345 + 0.3), 12, 0.3500f, 0, new Color(255, 255, 255, 255));
            NAPI.Marker.CreateMarker(27, new Vector3(334.5246, -560.1913, 28.74345 - 1.0), new Vector3(), new Vector3(), 0.8f, new Color(255, 255, 255, 155));

            // LSMC
            NAPI.TextLabel.CreateTextLabel("~y~~h~[ Garage ]", new Vector3(-262.2234, 6336.558, 32.42102 + 0.3), 12, 0.3500f, 0, new Color(255, 255, 255, 255));
            NAPI.Marker.CreateMarker(27, new Vector3(-262.2234, 6336.558, 32.42102 - 1.0), new Vector3(), new Vector3(), 0.8f, new Color(255, 255, 255, 155));

            NAPI.TextLabel.CreateTextLabel("~y~~h~[ Stempeluhr ]", new Vector3(1834.9865, 3693.3667, 34.27063 + 0.3), 12, 0.3500f, 0, new Color(255, 255, 255, 255));
            NAPI.Marker.CreateMarker(27, new Vector3(1834.9865, 3693.3667, 34.27063 - 1.0), new Vector3(), new Vector3(), 0.8f, new Color(255, 255, 255, 155));

            NAPI.TextLabel.CreateTextLabel("~y~~h~[ Stempeluhr ]", new Vector3(-262.9533, 6312.083, 32.43641 + 0.3), 12, 0.3500f, 0, new Color(255, 255, 255, 255));
            NAPI.Marker.CreateMarker(27, new Vector3(-262.9533, 6312.083, 32.43641 - 1.0), new Vector3(), new Vector3(), 0.8f, new Color(255, 255, 255, 155));

            NAPI.TextLabel.CreateTextLabel("~y~~h~[ Stempeluhr ]", new Vector3(335.7118, -580.4397, 28.79148 + 0.3), 12, 0.3500f, 0, new Color(255, 255, 255, 255));
            NAPI.Marker.CreateMarker(27, new Vector3(335.7118, -580.4397, 28.79148 - 1.0), new Vector3(), new Vector3(), 0.8f, new Color(255, 255, 255, 155));

            // Faction Type 14
            NAPI.TextLabel.CreateTextLabel("~y~~h~[ LS FIB - Dienst melden ]", new Vector3(120.652, -727.4619, 242.1519 + 0.3), 12, 0.3500f, 0, new Color(255, 255, 255, 255));
            NAPI.Marker.CreateMarker(27, new Vector3(120.652, -727.4619, 242.1519 - 1.0), new Vector3(), new Vector3(), 0.8f, new Color(255, 255, 255, 155));

            // Faction Type 24 - President
            //NAPI.TextLabel.CreateTextLabel("~y~~h~[ Dienst melden ]", new Vector3(-671.4221, 593.0613, 145.1697 + 0.3), 12, 0.3500f, 0, new Color(255, 255, 255, 255));
            //NAPI.Marker.CreateMarker(27, new Vector3(-671.4221, 593.0613, 145.1697 - 1.0), new Vector3(), new Vector3(), 0.8f, new Color(255, 255, 255, 155));

            // Noose Team
            NAPI.TextLabel.CreateTextLabel("~y~~h~[ Dienst melden ]", new Vector3(-2353.141, 3257.135, 32.81075 + 0.3), 12, 0.3500f, 0, new Color(255, 255, 255, 255));
            NAPI.Marker.CreateMarker(27, new Vector3(-2353.141, 3257.135, 32.81075 - 1.0), new Vector3(), new Vector3(), 0.8f, new Color(255, 255, 255, 155));

            NAPI.TextLabel.CreateTextLabel("~g~~h~- Rettungswagen Einparken -", new Vector3(-241.0735, 6333.936, 31.98685 + 0.3), 12, 0.3500f, 0, new Color(255, 255, 255, 255));
            NAPI.Marker.CreateMarker(27, new Vector3(-241.0735, 6333.936, 31.98685 - 1.0), new Vector3(), new Vector3(), 0.8f, new Color(255, 255, 255, 155));

            NAPI.TextLabel.CreateTextLabel("~g~~h~- Rettungswagen Einparken -", new Vector3(339.3354, -623.9186, 28.85218 + 0.3), 12, 0.3500f, 0, new Color(255, 255, 255, 255));
            NAPI.Marker.CreateMarker(27, new Vector3(339.3354, -623.9186, 28.85218 - 1.0), new Vector3(), new Vector3(), 0.8f, new Color(255, 255, 255, 155));

            NAPI.TextLabel.CreateTextLabel("~g~~h~- Rettungshelicopter Einparken -", new Vector3(313.381, -1465.326, 46.50916 + 0.3), 12, 0.3500f, 0, new Color(255, 255, 255, 255));
            NAPI.Marker.CreateMarker(27, new Vector3(313.381, -1465.326, 46.50916 - 1.0), new Vector3(), new Vector3(), 0.8f, new Color(255, 255, 255, 155));

            //NAPI.TextLabel.CreateTextLabel("~y~~h~- ACLS Garage -", new Vector3(401.5658, -1627.65, 29.29195 + 0.3), 12, 0.3500f, 0, new Color(255, 255, 255, 255));
            NAPI.Marker.CreateMarker(27, new Vector3(363.6198, -1589.367, 29.29205 - 1.0), new Vector3(), new Vector3(), 0.6f, new Color(255, 255, 255, 155));

            //NAPI.TextLabel.CreateTextLabel("~y~~h~- ACLS Garage -", new Vector3(396.3549, -1634.102, 29.29195 + 0.3), 12, 0.3500f, 0, new Color(255, 255, 255, 255));
            //NAPI.Marker.CreateMarker(27, new Vector3(396.3549, -1634.102, 29.29195 - 1.0), new Vector3(), new Vector3(), 0.6f, new Color(255, 255, 255, 155));

            NAPI.TextLabel.CreateTextLabel("~y~~h~- LSPC Garage -", new Vector3(-334.353, -126.06683, 39.009655 + 0.3), 12, 0.3500f, 0, new Color(255, 255, 255, 255));
            NAPI.Marker.CreateMarker(27, new Vector3(-334.353, -126.06683, 39.009655 - 1.0), new Vector3(), new Vector3(), 0.6f, new Color(255, 255, 255, 155));

            // Leitsellen System für die Fraktionen
            // Cops
            //NAPI.Marker.CreateMarker(27, new Vector3(457.66818, -992.59717, 35.931057 - 0.8), new Vector3(), new Vector3(), 1.0f, new Color(244, 217, 66, 150), false, 0);
            //// Medics
            //NAPI.Marker.CreateMarker(27, new Vector3(320.94452, -571.31616, 28.791481 - 0.8), new Vector3(), new Vector3(), 1.0f, new Color(244, 217, 66, 150), false, 0);
            //// ACLS
            //NAPI.Marker.CreateMarker(27, new Vector3(-1173.2288, -1961.7523, 13.5822525 - 0.8), new Vector3(), new Vector3(), 1.0f, new Color(244, 217, 66, 150), false, 0);
            ////Taxi
            //NAPI.Marker.CreateMarker(27, new Vector3(896.0696, -164.2533, 74.16833 - 0.8), new Vector3(), new Vector3(), 1.0f, new Color(244, 217, 66, 150), false, 0);

            // FIB & LSPD Crime Computer
            //NAPI.TextLabel.CreateTextLabel("LSPD Computer", new Vector3(441.2615, -978.7208, 30.6896 + 0.2), 12, 0.3500f, 0, new Color(255, 255, 255, 255));
            //NAPI.TextLabel.CreateTextLabel("FIB Computer", new Vector3(107.6871, -747.3194, 242.1521 + 0.2), 12, 0.3500f, 0, new Color(255, 255, 255, 255));
            //NAPI.TextLabel.CreateTextLabel("FIB Computer", new Vector3(109.9118, -743.1069, 242.1521 + 0.2), 12, 0.3500f, 0, new Color(255, 255, 255, 255));
            //NAPI.TextLabel.CreateTextLabel("FIB Computer", new Vector3(111.4035, -754.4329, 242.1523 + 0.2), 12, 0.3500f, 0, new Color(255, 255, 255, 255));
            //NAPI.TextLabel.CreateTextLabel("FIB Computer", new Vector3(109.7236, -750.8882, 242.1523 + 0.2), 12, 0.3500f, 0, new Color(255, 255, 255, 255));
        }

        public static void TunerColors()
        {
            Main.metalic_color_list.Add(new { color_id = 0, color_name = "Metallic Black" });
            Main.metalic_color_list.Add(new { color_id = 1, color_name = "Metallic Graphite Black" });
            Main.metalic_color_list.Add(new { color_id = 2, color_name = "Metallic Black Steal" });
            Main.metalic_color_list.Add(new { color_id = 3, color_name = "Metallic Dark Silver" });
            Main.metalic_color_list.Add(new { color_id = 4, color_name = "Metallic Silver" });
            Main.metalic_color_list.Add(new { color_id = 5, color_name = "Metallic Blue Silver" });
            Main.metalic_color_list.Add(new { color_id = 6, color_name = "Metallic Steel Gray" });
            Main.metalic_color_list.Add(new { color_id = 7, color_name = "Metallic Shadow Silver" });
            Main.metalic_color_list.Add(new { color_id = 8, color_name = "Metallic Stone Silver" });
            Main.metalic_color_list.Add(new { color_id = 9, color_name = "Metallic Midnight Silver" });
            Main.metalic_color_list.Add(new { color_id = 10, color_name = "Metallic Gun Metal" });
            Main.metalic_color_list.Add(new { color_id = 11, color_name = "Metallic Anthracite Grey" });
            Main.metalic_color_list.Add(new { color_id = 27, color_name = "Metallic Red" });
            Main.metalic_color_list.Add(new { color_id = 28, color_name = "Metallic Torino Red" });
            Main.metalic_color_list.Add(new { color_id = 29, color_name = "Metallic Formula Red" });
            Main.metalic_color_list.Add(new { color_id = 30, color_name = "Metallic Blaze Red" });
            Main.metalic_color_list.Add(new { color_id = 31, color_name = "Metallic Graceful Red" });
            Main.metalic_color_list.Add(new { color_id = 32, color_name = "Metallic Garnet Red" });
            Main.metalic_color_list.Add(new { color_id = 33, color_name = "Metallic Desert Red" });
            Main.metalic_color_list.Add(new { color_id = 34, color_name = "Metallic Cabernet Red" });
            Main.metalic_color_list.Add(new { color_id = 35, color_name = "Metallic Candy Red" });
            Main.metalic_color_list.Add(new { color_id = 36, color_name = "Metallic Sunrise Orange" });
            Main.metalic_color_list.Add(new { color_id = 37, color_name = "Metallic Classic Gold" });
            Main.metalic_color_list.Add(new { color_id = 38, color_name = "Metallic Orange" });
            Main.metalic_color_list.Add(new { color_id = 49, color_name = "Metallic Dark Green" });
            Main.metalic_color_list.Add(new { color_id = 50, color_name = "Metallic Racing Green" });
            Main.metalic_color_list.Add(new { color_id = 51, color_name = "Metallic Sea Green" });
            Main.metalic_color_list.Add(new { color_id = 52, color_name = "Metallic Olive Green" });
            Main.metalic_color_list.Add(new { color_id = 53, color_name = "Metallic Green" });
            Main.metalic_color_list.Add(new { color_id = 54, color_name = "Metallic Gasoline Blue Green" });
            Main.metalic_color_list.Add(new { color_id = 61, color_name = "Metallic Midnight Blue" });
            Main.metalic_color_list.Add(new { color_id = 62, color_name = "Metallic Dark Blue" });
            Main.metalic_color_list.Add(new { color_id = 63, color_name = "Metallic Saxony Blue" });
            Main.metalic_color_list.Add(new { color_id = 64, color_name = "Metallic Blue" });
            Main.metalic_color_list.Add(new { color_id = 65, color_name = "Metallic Mariner Blue" });
            Main.metalic_color_list.Add(new { color_id = 66, color_name = "Metallic Harbor Blue" });
            Main.metalic_color_list.Add(new { color_id = 67, color_name = "Metallic Diamond Blue" });
            Main.metalic_color_list.Add(new { color_id = 68, color_name = "Metallic Surf Blue" });
            Main.metalic_color_list.Add(new { color_id = 69, color_name = "Metallic Nautical Blue" });
            Main.metalic_color_list.Add(new { color_id = 70, color_name = "Metallic Bright Blue" });
            Main.metalic_color_list.Add(new { color_id = 71, color_name = "Metallic Purple Blue" });
            Main.metalic_color_list.Add(new { color_id = 72, color_name = "Metallic Spinnaker Blue" });
            Main.metalic_color_list.Add(new { color_id = 73, color_name = "Metallic Ultra Blue" });
            Main.metalic_color_list.Add(new { color_id = 74, color_name = "Metallic Bright Blue" });
            Main.metalic_color_list.Add(new { color_id = 88, color_name = "Metallic Taxi Yellow" });
            Main.metalic_color_list.Add(new { color_id = 89, color_name = "Metallic Race Yellow" });
            Main.metalic_color_list.Add(new { color_id = 90, color_name = "Metallic Bronze" });
            Main.metalic_color_list.Add(new { color_id = 91, color_name = "Metallic Yellow Bird" });
            Main.metalic_color_list.Add(new { color_id = 92, color_name = "Metallic Lime" });
            Main.metalic_color_list.Add(new { color_id = 93, color_name = "Metallic Champagne" });
            Main.metalic_color_list.Add(new { color_id = 94, color_name = "Metallic Pueblo Beige" });
            Main.metalic_color_list.Add(new { color_id = 95, color_name = "Metallic Dark Ivory" });
            Main.metalic_color_list.Add(new { color_id = 96, color_name = "Metallic Choco Brown" });
            Main.metalic_color_list.Add(new { color_id = 97, color_name = "Metallic Golden Brown" });
            Main.metalic_color_list.Add(new { color_id = 98, color_name = "Metallic Light Brown" });
            Main.metalic_color_list.Add(new { color_id = 99, color_name = "Metallic Straw Beige" });
            Main.metalic_color_list.Add(new { color_id = 100, color_name = "Metallic Moss Brown" });
            Main.metalic_color_list.Add(new { color_id = 101, color_name = "Metallic Biston Brown" });
            Main.metalic_color_list.Add(new { color_id = 102, color_name = "Metallic Beechwood" });
            Main.metalic_color_list.Add(new { color_id = 103, color_name = "Metallic Dark Beechwood" });
            Main.metalic_color_list.Add(new { color_id = 104, color_name = "Metallic Choco Orange" });
            Main.metalic_color_list.Add(new { color_id = 105, color_name = "Metallic Beach Sand" });
            Main.metalic_color_list.Add(new { color_id = 106, color_name = "Metallic Sun Bleeched Sand" });
            Main.metalic_color_list.Add(new { color_id = 107, color_name = "Metallic Cream" });
            Main.metalic_color_list.Add(new { color_id = 111, color_name = "Metallic White" });
            Main.metalic_color_list.Add(new { color_id = 112, color_name = "Metallic Frost White" });
            Main.metalic_color_list.Add(new { color_id = 125, color_name = "Metallic Securicor Green" });
            Main.metalic_color_list.Add(new { color_id = 137, color_name = "Metallic Vermillion Pink" });
            Main.metalic_color_list.Add(new { color_id = 142, color_name = "Metallic Black Purple" });
            Main.metalic_color_list.Add(new { color_id = 143, color_name = "Metallic Black Red" });
            Main.metalic_color_list.Add(new { color_id = 145, color_name = "Metallic Purple" });
            Main.metalic_color_list.Add(new { color_id = 146, color_name = "Metallic V Dark Blue" });
            Main.metalic_color_list.Add(new { color_id = 150, color_name = "Metallic Lava Red" });
        }

        public static void Weather()
        {
            Main.weather_list.Add(new { name = "EXTRASUNNY" });
            Main.weather_list.Add(new { name = "CLEAR" });
            Main.weather_list.Add(new { name = "CLOUDS" });
            Main.weather_list.Add(new { name = "SMOG" });
            Main.weather_list.Add(new { name = "FOGGY" });
            Main.weather_list.Add(new { name = "OVERCAST" });
            Main.weather_list.Add(new { name = "RAIN" });
            Main.weather_list.Add(new { name = "THUNDER" });
            Main.weather_list.Add(new { name = "CLEARING" });
            Main.weather_list.Add(new { name = "NEUTRAL" });
            Main.weather_list.Add(new { name = "SNOW" });
            Main.weather_list.Add(new { name = "BLIZZARD" });
            Main.weather_list.Add(new { name = "SNOWLIGHT" });
            Main.weather_list.Add(new { name = "XMAS" });
            Main.weather_list.Add(new { name = "HALLOWEEN" });
        }

        public static void Weapons()
        {
            Main.weapon_list.Add(new { model = "Knife", hash = -1716189206, classe = "Melee", type = "Branca" });
            Main.weapon_list.Add(new { model = "Nightstick", hash = 1737195953, classe = "Melee", type = "Branca" });
            Main.weapon_list.Add(new { model = "Hammer", hash = 1317494643, classe = "Melee", type = "Branca" });
            Main.weapon_list.Add(new { model = "Bat", hash = -1786099057, classe = "Melee", type = "Branca" });
            Main.weapon_list.Add(new { model = "Crowbar", hash = -2067956739, classe = "Melee", type = "Branca" });
            Main.weapon_list.Add(new { model = "GolfClub", hash = 1141786504, classe = "Melee", type = "Branca" });
            Main.weapon_list.Add(new { model = "Bottle", hash = -102323637, classe = "Melee", type = "Branca" });
            Main.weapon_list.Add(new { model = "Dagger", hash = -1834847097, classe = "Melee", type = "Branca" });
            Main.weapon_list.Add(new { model = "Hatchet", hash = -102973651, classe = "Melee", type = "Branca" });
            Main.weapon_list.Add(new { model = "KnuckleDuster", hash = -656458692, classe = "Melee", type = "Branca" });
            Main.weapon_list.Add(new { model = "Machete", hash = -581044007, classe = "Melee", type = "Branca" });
            Main.weapon_list.Add(new { model = "Flashlight", hash = -1951375401, classe = "Melee", type = "Branca" });
            Main.weapon_list.Add(new { model = "SwitchBlade", hash = -538741184, classe = "Melee", type = "Branca" });
            Main.weapon_list.Add(new { model = "PoolCue", hash = -1810795771, classe = "Melee", type = "Branca" });
            Main.weapon_list.Add(new { model = "Wrench", hash = 419712736, classe = "Melee", type = "Branca" });
            Main.weapon_list.Add(new { model = "BattleAxe", hash = -853065399, classe = "Melee", type = "Branca" });
            Main.weapon_list.Add(new { model = "WT_SHATCHET", hash = 940833800, classe = "Melee", type = "Branca" });
            Main.weapon_list.Add(new { model = "Pistol", hash = 453432689, classe = "Secundary", type = "Handguns" });
            Main.weapon_list.Add(new { model = "CombatPistol", hash = 1593441988, classe = "Secundary", type = "Handguns" });
            Main.weapon_list.Add(new { model = "Pistol50", hash = -1716589765, classe = "Secundary", type = "Handguns" });
            Main.weapon_list.Add(new { model = "SNSPistol", hash = -1076751822, classe = "Secundary", type = "Handguns" });
            Main.weapon_list.Add(new { model = "HeavyPistol", hash = -771403250, classe = "Secundary", type = "Handguns" });
            Main.weapon_list.Add(new { model = "VintagePistol", hash = 137902532, classe = "Secundary", type = "Handguns" });
            Main.weapon_list.Add(new { model = "MarksmanPistol", hash = -598887786, classe = "Secundary", type = "Handguns" });
            Main.weapon_list.Add(new { model = "Revolver", hash = -1045183535, classe = "Secundary", type = "Handguns" });
            Main.weapon_list.Add(new { model = "APPistol", hash = 584646201, classe = "Secundary", type = "Handguns" });
            Main.weapon_list.Add(new { model = "StunGun", hash = 911657153, classe = "Secundary", type = "Handguns" });
            Main.weapon_list.Add(new { model = "FlareGun", hash = 1198879012, classe = "Secundary", type = "Handguns" });
            Main.weapon_list.Add(new { model = "DoubleAction", hash = -1746263880, classe = "Secundary", type = "Handguns" });
            Main.weapon_list.Add(new { model = "PistolMk2", hash = -1075685676, classe = "Secundary", type = "Handguns" });
            Main.weapon_list.Add(new { model = "SNSPistolMk2", hash = -2009644972, classe = "Secundary", type = "Handguns" });
            Main.weapon_list.Add(new { model = "RevolverMk2", hash = -879347409, classe = "Secundary", type = "Handguns" });
            Main.weapon_list.Add(new { model = "MicroSMG", hash = 324215364, classe = "Secundary", type = "Machine Guns" });
            Main.weapon_list.Add(new { model = "MachinePistol", hash = -619010992, classe = "Secundary", type = "Machine Guns" });
            Main.weapon_list.Add(new { model = "SMG", hash = 736523883, classe = "Secundary", type = "Machine Guns" });
            Main.weapon_list.Add(new { model = "AssaultSMG", hash = -270015777, classe = "Secundary", type = "Machine Guns" });
            Main.weapon_list.Add(new { model = "CombatPDW", hash = 171789620, classe = "Secundary", type = "Machine Guns" });
            Main.weapon_list.Add(new { model = "MG", hash = -1660422300, classe = "Secundary", type = "Machine Guns" });
            Main.weapon_list.Add(new { model = "CombatMG", hash = 2144741730, classe = "Secundary", type = "Machine Guns" });
            Main.weapon_list.Add(new { model = "Gusenberg", hash = 1627465347, classe = "Secundary", type = "Machine Guns" });
            Main.weapon_list.Add(new { model = "MiniSMG", hash = -1121678507, classe = "Secundary", type = "Machine Guns" });
            Main.weapon_list.Add(new { model = "SMGMk2", hash = 2024373456, classe = "Secundary", type = "Machine Guns" });
            Main.weapon_list.Add(new { model = "CombatMGMk2", hash = -608341376, classe = "Secundary", type = "Machine Guns" });
            Main.weapon_list.Add(new { model = "PumpShotgun", hash = 487013001, classe = "Secundary", type = "Shotguns" });
            Main.weapon_list.Add(new { model = "SawnOffShotgun", hash = 2017895192, classe = "Secundary", type = "Shotguns" });
            Main.weapon_list.Add(new { model = "BullpupShotgun", hash = -1654528753, classe = "Secundary", type = "Shotguns" });
            Main.weapon_list.Add(new { model = "AssaultShotgun", hash = -494615257, classe = "Secundary", type = "Shotguns" });
            Main.weapon_list.Add(new { model = "Musket", hash = -1466123874, classe = "Secundary", type = "Shotguns" });
            Main.weapon_list.Add(new { model = "HeavyShotgun", hash = 984333226, classe = "Secundary", type = "Shotguns" });
            Main.weapon_list.Add(new { model = "DoubleBarrelShotgun", hash = -275439685, classe = "Secundary", type = "Shotguns" });
            Main.weapon_list.Add(new { model = "SweeperShotgun", hash = 317205821, classe = "Secundary", type = "Shotguns" });
            Main.weapon_list.Add(new { model = "PumpShotgunMk2", hash = 1432025498, classe = "Secundary", type = "Shotguns" });
            Main.weapon_list.Add(new { model = "AssaultRifle", hash = -1074790547, classe = "Primary", type = "Assault Rifles" });
            Main.weapon_list.Add(new { model = "CarbineRifle", hash = -2084633992, classe = "Primary", type = "Assault Rifles" });
            Main.weapon_list.Add(new { model = "AdvancedRifle", hash = -1357824103, classe = "Primary", type = "Assault Rifles" });
            Main.weapon_list.Add(new { model = "SpecialCarbine", hash = -1063057011, classe = "Primary", type = "Assault Rifles" });
            Main.weapon_list.Add(new { model = "BullpupRifle", hash = 2132975508, classe = "Primary", type = "Assault Rifles" });
            Main.weapon_list.Add(new { model = "CompactRifle", hash = 1649403952, classe = "Primary", type = "Assault Rifles" });
            Main.weapon_list.Add(new { model = "AssaultRifleMk2", hash = 961495388, classe = "Primary", type = "Assault Rifles" });
            Main.weapon_list.Add(new { model = "CarbineRifleMk2", hash = -86904375, classe = "Primary", type = "Assault Rifles" });
            Main.weapon_list.Add(new { model = "SpecialCarbineMk2", hash = -1768145561, classe = "Primary", type = "Assault Rifles" });
            Main.weapon_list.Add(new { model = "BullpupRifleMk2", hash = -2066285827, classe = "Primary", type = "Assault Rifles" });
            Main.weapon_list.Add(new { model = "SniperRifle", hash = 100416529, classe = "Primary", type = "Sniper Rifles" });
            Main.weapon_list.Add(new { model = "HeavySniper", hash = 205991906, classe = "Primary", type = "Sniper Rifles" });
            Main.weapon_list.Add(new { model = "MarksmanRifle", hash = -952879014, classe = "Primary", type = "Sniper Rifles" });
            Main.weapon_list.Add(new { model = "HeavySniperMk2", hash = 177293209, classe = "Primary", type = "Sniper Rifles" });
            Main.weapon_list.Add(new { model = "MarksmanRifleMk2", hash = 1785463520, classe = "Primary", type = "Sniper Rifles" });
        }

        public static void Client_IPLS()
        {
            NAPI.World.RemoveIpl("facelobbyfake");
            NAPI.World.RequestIpl("facelobby");
            NAPI.World.RemoveIpl("fakeint");
            NAPI.World.RemoveIpl("shutter_closed");
            NAPI.World.RequestIpl("shr_int");

            // Neue
            NAPI.World.RequestIpl("ex_dt1_02_office_02b");
            NAPI.World.RequestIpl("ex_dt1_02_office_02c");
            NAPI.World.RequestIpl("ex_dt1_02_office_02a");
            NAPI.World.RequestIpl("ex_dt1_02_office_01a");
            NAPI.World.RequestIpl("ex_dt1_11_office_02c");
            NAPI.World.RequestIpl("ex_dt1_11_office_02a");
            NAPI.World.RequestIpl("ex_dt1_11_office_01a");
            NAPI.World.RequestIpl("ex_dt1_11_office_01b");
            NAPI.World.RequestIpl("ex_dt1_11_office_01c");
            NAPI.World.RequestIpl("ex_dt1_11_office_03a");
            NAPI.World.RequestIpl("ex_dt1_11_office_03b");
            NAPI.World.RequestIpl("ex_dt1_11_office_03c");
            NAPI.World.RequestIpl("post_hiest_unload");

            //wherehouse
            NAPI.World.RequestIpl("bkr_biker_interior_placement_interior_0_biker_dlc_int_01_milo");
            NAPI.World.RequestIpl("bkr_biker_interior_placement_interior_1_biker_dlc_int_02_milo");
            NAPI.World.RequestIpl("bkr_biker_interior_placement_interior_2_biker_dlc_int_ware01_milo");
            NAPI.World.RequestIpl("bkr_biker_interior_placement_interior_3_biker_dlc_int_ware02_milo");
            NAPI.World.RequestIpl("bkr_biker_interior_placement_interior_4_biker_dlc_int_ware03_milo");
            NAPI.World.RequestIpl("bkr_biker_interior_placement_interior_5_biker_dlc_int_ware04_milo");
            NAPI.World.RequestIpl("bkr_biker_interior_placement_interior_6_biker_dlc_int_ware05_milo");
            NAPI.World.RequestIpl("ex_exec_warehouse_placement_interior_1_int_warehouse_s_dlc_milo");
            NAPI.World.RequestIpl("ex_exec_warehouse_placement_interior_0_int_warehouse_m_dlc_milo");
            NAPI.World.RequestIpl("ex_exec_warehouse_placement_interior_2_int_warehouse_l_dlc_milo");
            NAPI.World.RequestIpl("imp_impexp_interior_placement_interior_1_impexp_intwaremed_milo_");
            NAPI.World.RequestIpl("bkr_bi_hw1_13_int");

            // Fixed
            NAPI.World.RequestIpl("ba_int_placement_ba_interior_0_dlc_int_01_ba_milo_");
            NAPI.World.RequestIpl("FruitBB");
            NAPI.World.RequestIpl("sp1_10_real_interior");
            NAPI.World.RequestIpl("sp1_10_real_interior_lod");
            NAPI.World.RequestIpl("bh1_47_joshhse_unburnt");
            NAPI.World.RequestIpl("bh1_47_joshhse_unburnt_lod");
            NAPI.World.RequestIpl("FruitBB");
            NAPI.World.RequestIpl("coronertrash");
            NAPI.World.RequestIpl("Coroner_Int_On");

            // apartments
            NAPI.World.RequestIpl("apa_v_mp_h_01_a");
            NAPI.World.RequestIpl("apa_v_mp_h_01_c");
            NAPI.World.RequestIpl("apa_v_mp_h_01_b");
            NAPI.World.RequestIpl("apa_v_mp_h_02_a");
            NAPI.World.RequestIpl("apa_v_mp_h_02_c");
            NAPI.World.RequestIpl("apa_v_mp_h_02_b");
            NAPI.World.RequestIpl("apa_v_mp_h_03_a");
            NAPI.World.RequestIpl("apa_v_mp_h_03_c");
            NAPI.World.RequestIpl("apa_v_mp_h_03_b");
            NAPI.World.RequestIpl("apa_v_mp_h_04_a");
            NAPI.World.RequestIpl("apa_v_mp_h_04_c");
            NAPI.World.RequestIpl("apa_v_mp_h_04_b");
            NAPI.World.RequestIpl("apa_v_mp_h_05_a");
            NAPI.World.RequestIpl("apa_v_mp_h_05_c");
            NAPI.World.RequestIpl("apa_v_mp_h_05_b");
            NAPI.World.RequestIpl("apa_v_mp_h_06_a");
            NAPI.World.RequestIpl("apa_v_mp_h_06_c");
            NAPI.World.RequestIpl("apa_v_mp_h_06_b");
            NAPI.World.RequestIpl("apa_v_mp_h_07_a");
            NAPI.World.RequestIpl("apa_v_mp_h_07_c");
            NAPI.World.RequestIpl("apa_v_mp_h_07_b");
            NAPI.World.RequestIpl("apa_v_mp_h_08_a");
            NAPI.World.RequestIpl("apa_v_mp_h_08_c");
            NAPI.World.RequestIpl("apa_v_mp_h_08_b");

            // nightclub
            NAPI.World.RequestIpl("ba_barriers_case1");
            NAPI.World.RequestIpl("ba_case1_madonna");
            NAPI.World.RequestIpl("v_sheriff2");
            NAPI.World.RequestIpl("v_sheriff");
            NAPI.World.RequestIpl("post_hiest_unload");
            NAPI.World.RequestIpl("farm");
            NAPI.World.RequestIpl("farmint");
            NAPI.World.RequestIpl("farm_lod");
            NAPI.World.RequestIpl("farm_props");
            NAPI.World.RequestIpl("des_farmhouse");
            NAPI.World.RequestIpl("farm_int");

            // Gang Task
            NAPI.World.RequestIpl("fiblobby");
            NAPI.World.RequestIpl("fiblobby_lod");
            NAPI.World.RequestIpl("v_rockclub");
            NAPI.World.RequestIpl("hei_sm_16_interior_v_bahama_milo_");
            NAPI.World.RequestIpl("canyonrvrdeep");
            NAPI.World.RequestIpl("canyonrvrshallow");

            // Casino Position: new mp.Vector3(1100.000, 220.000, -50.000);﻿﻿﻿
            NAPI.World.RequestIpl("vw_casino_main");
            // Garage new mp.Vector3(1295.000, 230.000, -50.000);
            NAPI.World.RequestIpl("vw_casino_garage﻿﻿﻿﻿﻿");
            // Penthouse Position: new mp.Vector3(976.636, 70.295, 115.164);
            NAPI.World.RequestIpl("vw_casino_penthouse");
            // Car Park﻿﻿ Position: new mp.Vector3(1380.000, 200.000, -50.000);
            NAPI.World.RequestIpl("vw_casino_carpark");

            NAPI.World.DeleteWorldProp(NAPI.Util.GetHashKey("prop_vend_water_01"), new Vector3(-227.7738, -335.4879, 29.03523), 10.0f);
            NAPI.World.DeleteWorldProp(NAPI.Util.GetHashKey("prop_vend_water_01"), new Vector3(-228.5919, -326.7119, 30.90385), 10.0f);
            NAPI.World.DeleteWorldProp(NAPI.Util.GetHashKey("prop_mineshaft_door"), new Vector3(-596.277, 2088.949, 131.4127), 10.0f);
            NAPI.World.DeleteWorldProp(NAPI.Util.GetHashKey("v_ilev_arm_secdoor"), new Vector3(453.0793, -983.1894, 30.83926), 10.0f);
        }

        public static void Player_Crime_List()
        {
            Main.crime_list.Add(new { crime_name = "Diebstahl", crime_points = 5 });
            Main.crime_list.Add(new { crime_name = "Raub", crime_points = 6 });
            Main.crime_list.Add(new { crime_name = "Schwerer Raub", crime_points = 8 });
            Main.crime_list.Add(new { crime_name = "Erpressung", crime_points = 11 });
            Main.crime_list.Add(new { crime_name = "Schwerer Erpressung", crime_points = 16 });
            Main.crime_list.Add(new { crime_name = "Betrug", crime_points = 13 });
            Main.crime_list.Add(new { crime_name = "Schwerer Betrug", crime_points = 15 });
            Main.crime_list.Add(new { crime_name = "Körperverletzung", crime_points = 21 });
            Main.crime_list.Add(new { crime_name = "Fahrlässige Körperverletzung", crime_points = 24 });
            Main.crime_list.Add(new { crime_name = "Schwere Körperverletzung", crime_points = 27 });
            Main.crime_list.Add(new { crime_name = "Fahrlässige Schwere Körperverletzung", crime_points = 30 });
            Main.crime_list.Add(new { crime_name = "Hausfriedensbruch", crime_points = 10 });
            Main.crime_list.Add(new { crime_name = "Amtsanmaßung", crime_points = 30 });
            Main.crime_list.Add(new { crime_name = "Fahren ohne PKW Führerschein", crime_points = 10 });
            Main.crime_list.Add(new { crime_name = "Fahren ohne LKW Führerschein", crime_points = 10 });
            Main.crime_list.Add(new { crime_name = "Fahren ohne Taxi Führerschein", crime_points = 10 });
            Main.crime_list.Add(new { crime_name = "Fahren ohne Motorrad Führerschein", crime_points = 10 });
            Main.crime_list.Add(new { crime_name = "Widerstand gegen die Festnahme", crime_points = 10 });
            Main.crime_list.Add(new { crime_name = "Drogenkonsum in der Öffentlichkeit", crime_points = 8 });
            Main.crime_list.Add(new { crime_name = "Beleidigung", crime_points = 50 });
            Main.crime_list.Add(new { crime_name = "Beleidigung gegen ein Officer", crime_points = 50 });
            Main.crime_list.Add(new { crime_name = "Beleidigung gegen ein FiB Agent", crime_points = 50 });
            Main.crime_list.Add(new { crime_name = "Beleidigung gegen ein DOJ Agent", crime_points = 50 });
            Main.crime_list.Add(new { crime_name = "Beleidigung gegen den President", crime_points = 50 });
            Main.crime_list.Add(new { crime_name = "Fahrzeugdiebstahl", crime_points = 55 });
            Main.crime_list.Add(new { crime_name = "Auto Unfall", crime_points = 76 });
            Main.crime_list.Add(new { crime_name = "Entführung des President", crime_points = 79 });
            Main.crime_list.Add(new { crime_name = "Entführung eines Bürgers", crime_points = 79 });
            Main.crime_list.Add(new { crime_name = "Geschwindigkeitsüberschreitung", crime_points = 7 });
            Main.crime_list.Add(new { crime_name = "Schmuggel von illegalen Gütern", crime_points = 25 });
            Main.crime_list.Add(new { crime_name = "Waffenschmuggel", crime_points = 35 });
            Main.crime_list.Add(new { crime_name = "Drogenschmuggel", crime_points = 30 });
            Main.crime_list.Add(new { crime_name = "Versuchter Mord", crime_points = 86 });
            Main.crime_list.Add(new { crime_name = "Mord", crime_points = 128 });
            Main.crime_list.Add(new { crime_name = "Totschlag", crime_points = 120 });
            Main.crime_list.Add(new { crime_name = "Steuerhinterziehung", crime_points = 95 });
        }
    }
}
