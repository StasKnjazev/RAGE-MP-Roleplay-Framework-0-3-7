using System;
using System.IO;
using System.Collections.Generic;
using System.Data;
using GTANetworkAPI;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using DerStr1k3r.Core;
using DerStr1k3r.SDK;

namespace CharCreator
{
    #region ParentData
    public class ParentData
    {
        public int Father;
        public int Mother;
        public float Similarity;
        public float SkinSimilarity;

        public ParentData(int father, int mother, float similarity, float skinsimilarity)
        {
            Father = father;
            Mother = mother;
            Similarity = similarity;
            SkinSimilarity = skinsimilarity;
        }
    }
    #endregion

    #region AppearanceItem
    public class AppearanceItem
    {
        public int Value;
        public float Opacity;
        public int Color;

        public AppearanceItem(int value, float opacity, int color)
        {
            Value = value;
            Opacity = opacity;
            Color = color;
        }
    }
    #endregion

    #region HairData
    public class HairData
    {
        public int Hair;
        public int Color;
        public int HighlightColor;

        public HairData(int hair, int color, int highlightcolor)
        {
            Hair = hair;
            Color = color;
            HighlightColor = highlightcolor;
        }
    }
    #endregion

    public class ComponentItem
    {
        public int Variation;
        public int Texture;

        public ComponentItem(int variation, int texture)
        {
            Variation = variation;
            Texture = texture;
        }
    }


    public class ClothesData
    {
        public ComponentItem Mask { get; set; }
        public ComponentItem Gloves { get; set; }
        public ComponentItem Torso { get; set; }
        public ComponentItem Leg { get; set; }
        public ComponentItem Bag { get; set; }
        public ComponentItem Feet { get; set; }
        public ComponentItem Accessory { get; set; }
        public ComponentItem Undershit { get; set; }
        public ComponentItem Bodyarmor { get; set; }
        public ComponentItem Decals { get; set; }
        public ComponentItem Top { get; set; }

        public ClothesData()
        {
            Mask = new ComponentItem(0, 0);
            Gloves = new ComponentItem(0, 0);
            Torso = new ComponentItem(15, 0);
            Leg = new ComponentItem(21, 0);
            Bag = new ComponentItem(0, 0);
            Feet = new ComponentItem(34, 0);
            Accessory = new ComponentItem(0, 0);
            Undershit = new ComponentItem(15, 0);
            Bodyarmor = new ComponentItem(0, 0);
            Decals = new ComponentItem(0, 0);
            Top = new ComponentItem(15, 0);
        }
    }


    public class AccessoryData
    {
        public ComponentItem Hat { get; set; }
        public ComponentItem Glasses { get; set; }
        public ComponentItem Ear { get; set; }
        public ComponentItem Watches { get; set; }
        public ComponentItem Bracelets { get; set; }

        public AccessoryData()
        {
            Hat = new ComponentItem(-1, 0);
            Glasses = new ComponentItem(-1, 0);
            Ear = new ComponentItem(-1, 0);
            Watches = new ComponentItem(-1, 0);
            Bracelets = new ComponentItem(-1, 0);
        }
    }

    public class Clothes
    {
        public Clothes(int variation, List<int> colors, int price, int type = -1)
        {
            Variation = variation;
            Colors = colors;
            Price = price;
            Type = type;
        }

        public int Variation { get; }
        public List<int> Colors { get; }
        public int Price { get; }
        public int Type { get; }
    }


    #region Underwear Class
    public class Underwear
    {
        public Underwear(int top, int price, List<int> colors)
        {
            Top = top;
            Price = price;
            Colors = colors;
        }
        public Underwear(int top, int price, Dictionary<int, int> undershirtIDs, List<int> colors)
        {
            Top = top;
            UndershirtIDs = undershirtIDs;
            Price = price;
            Colors = colors;
        }

        public int Top { get; }
        public int Price { get; }
        public Dictionary<int, int> UndershirtIDs { get; } = new Dictionary<int, int>();
        public List<int> Colors { get; }
    }
    #endregion

    #region PlayerCustomization Class
    public class PlayerCustomization
    {
        // Player
        public int Gender;

        // Parents
        public ParentData Parents;

        // Features
        public float[] Features = new float[20];

        // Appearance
        public AppearanceItem[] Appearance = new AppearanceItem[13];

        // Hair & Colors
        public HairData Hair;

        public int EyebrowColor;
        public int BeardColor;
        public int EyeColor;
        public int BlushColor;
        public int LipstickColor;
        public int ChestHairColor;
        public string Tattoo;

        public PlayerCustomization()
        {
            Gender = 0;
            Parents = new ParentData(0, 0, 1.0f, 1.0f);
            for (int i = 0; i < Features.Length; i++) Features[i] = 0f;
            for (int i = 0; i < Appearance.Length; i++) Appearance[i] = new AppearanceItem(255, 1.0f, 0);
            Hair = new HairData(0, 0, 0);
        }
    }
    #endregion

    public class CharCreator : Script
    {
        public static string SAVE_DIRECTORY = "CustomCharacters";

        public static Dictionary<bool, Dictionary<int, int>> CorrectTorso = new Dictionary<bool, Dictionary<int, int>>()
        {
            {
                true, new Dictionary<int, int>()
                {
                        { 0, 0 },
                        { 1, 0 },
                        { 2, 2 },
                        { 3, 14 },
                        { 4, 14 },
                        { 5, 5 },
                        { 6, 14 },
                        { 7, 14 },
                        { 8, 8 },
                        { 9, 0 },
                        { 10, 14 },
                        { 11, 15 },
                        { 12, 12 },
                        { 13, 11 },
                        { 14, 12 },
                        { 15, 15 },
                        { 16, 0 },
                        { 17, 5 },
                        { 18, 0 },
                        { 19, 14 },
                        { 20, 14 },
                        { 21, 15 },
                        { 22, 0 },
                        { 23, 14 },
                        { 24, 14 },
                        { 25, 15 },
                        { 26, 11 },
                        { 27, 14 },
                        { 28, 14 },
                        { 29, 14 },
                        { 30, 14 },
                        { 31, 14 },
                        { 32, 14 },
                        { 33, 0 },
                        { 34, 0 },
                        { 35, 14 },
                        { 36, 5 },
                        { 37, 14 },
                        { 38, 8 },
                        { 39, 0 },
                        { 40, 15 },
                        { 41, 12 },
                        { 42, 11 },
                        { 43, 11 },
                        { 44, 0 },
                        { 45, 15 },
                        { 46, 14 },
                        { 47, 0 },
                        { 48, 1 },
                        { 49, 1 },
                        { 50, 1 },
                        { 51, 1 },
                        { 52, 2 },
                        { 53, 0 },
                        { 54, 1 },
                        { 55, 0 },
                        { 56, 0 },
                        { 57, 0 },
                        { 58, 14 },
                        { 59, 14 },
                        { 60, 15 },
                        { 61, 0 },
                        { 62, 14 },
                        { 63, 5 },
                        { 64, 14 },
                        { 65, 14 },
                        { 66, 15 },
                        { 67, 1 },
                        { 68, 14 },
                        { 69, 14 },
                        { 70, 14 },
                        { 71, 0 },
                        { 72, 14 },
                        { 73, 0 },
                        { 74, 14 },
                        { 75, 11 },
                        { 76, 14 },
                        { 77, 14 },
                        { 78, 14 },
                        { 79, 14 },
                        { 80, 0 },
                        { 81, 0 },
                        { 82, 0 },
                        { 83, 0 },
                        { 84, 1 },
                        { 85, 1 },
                        { 86, 1 },
                        { 87, 1 },
                        { 88, 14 },
                        { 89, 14 },
                        { 90, 14 },
                        { 91, 15 },
                        { 92, 6 },
                        { 93, 0 },
                        { 94, 0 },
                        { 95, 11 },
                        { 96, 11 },
                        { 97, 0 },
                        { 98, 0 },
                        { 99, 14 },
                        { 100, 14 },
                        { 101, 14 },
                        { 102, 14 },
                        { 103, 14 },
                        { 104, 14 },
                        { 105, 11 },
                        { 106, 14 },
                        { 107, 14 },
                        { 108, 14 },
                        { 109, 5 },
                        { 110, 1 },
                        { 111, 4 },
                        { 112, 14 },
                        { 113, 6 },
                        { 114, 14 },
                        { 115, 14 },
                        { 116, 14 },
                        { 117, 6 },
                        { 118, 14 },
                        { 119, 14 },
                        { 120, 6 },
                        { 121, 14 },
                        { 122, 14 },
                        { 123, 11 },
                        { 124, 14 },
                        { 125, 14 },
                        { 126, 1 },
                        { 127, 14 },
                        { 128, 0 },
                        { 129, 0 },
                        { 130, 14 },
                        { 131, 0 },
                        { 132, 0 },
                        { 133, 0 },
                        { 134, 0 },
                        { 135, 0 },
                        { 136, 14 },
                        { 137, 6 },
                        { 138, 14 },
                        { 139, 12 },
                        { 140, 14 },
                        { 141, 6 },
                        { 142, 14 },
                        { 143, 14 },
                        { 144, 6 },
                        { 145, 14 },
                        { 146, 0 },
                        { 147, 4 },
                        { 148, 4 },
                        { 149, 14 },
                        { 150, 14 },
                        { 151, 14 },
                        { 152, 14 },
                        { 153, 14 },
                        { 154, 14 },
                        { 155, 14 },
                        { 156, 14 },
                        { 157, 15 },
                        { 158, 15 },
                        { 159, 15 },
                        { 160, 15 },
                        { 161, 14 },
                        { 162, 15 },
                        { 163, 14 },
                        { 164, 0 },
                        { 165, 0 },
                        { 166, 14 },
                        { 167, 14 },
                        { 168, 14 },
                        { 169, 14 },
                        { 170, 15 },
                        { 171, 1 },
                        { 172, 14 },
                        { 173, 15 },
                        { 174, 14 },
                        { 175, 15 },
                        { 176, 15 },
                        { 177, 15 },
                        { 178, 1 },
                        { 179, 15 },
                        { 180, 15 },
                        { 181, 15 },
                        { 182, 1 },
                        { 183, 14 },
                        { 184, 14 },
                        { 185, 14 },
                        { 186, 14 },
                        { 187, 14 },
                        { 188, 14 },
                        { 189, 14 },
                        { 190, 14 },
                        { 191, 14 },
                        { 192, 14 },
                        { 193, 0 },
                        { 194, 1 },
                        { 195, 1 },
                        { 196, 1 },
                        { 197, 1 },
                        { 198, 1 },
                        { 199, 1 },
                        { 200, 1 },
                        { 201, 3 },
                        { 202, 4 },
                        { 203, 1 },
                        { 204, 6 },
                        { 205, 5 },
                        { 206, 5 },
                        { 207, 5 },
                        { 208, 0 },
                        { 209, 0 },
                        { 210, 0 },
                        { 211, 0 },
                        { 212, 14 },
                        { 213, 15 },
                        { 214, 14 },
                        { 215, 14 },
                        { 216, 15 },
                        { 217, 14 },
                        { 218, 14 },
                        { 219, 15 },
                        { 220, 14 },
                        { 221, 14 },
                        { 222, 11 },
                        { 223, 5 },
                        { 224, 1 },
                        { 225, 8 },
                        { 226, 0 },
                        { 227, 4 },
                        { 228, 4 },
                        { 229, 14 },
                        { 230, 14 },
                        { 231, 4 },
                        { 232, 14 },
                        { 233, 14 },
                        { 234, 11 },
                        { 235, 0 },
                        { 236, 0 },
                        { 237, 5 },
                        { 238, 2 },
                        { 239, 2 },
                        { 240, 14 },
                        { 241, 2 },
                        { 242, 2 },
                        { 243, 4 },
                        { 244, 6 },
                        { 245, 4 },
                        { 246, 3 },
                        { 247, 2 },
                        { 248, 6 },
                        { 249, 6 },
                        { 250, 0 },
                        { 251, 12 },
                }
            },
            {
                false, new Dictionary<int, int>()
                {
                    { 0, 0  },
                    { 1, 5  },
                    { 2, 2  },
                    { 3, 3  },
                    { 4, 4 },
                    { 5, 4 },
                    { 6, 5 },
                    { 7, 5 },
                    { 8, 5 },
                    { 9, 0 },
                    { 10, 5 },
                    { 11, 4 },
                    { 12, 12 },
                    { 13, 15 },
                    { 14, 14 },
                    { 15, 15 },
                    { 16, 15 },
                    { 17, 0 },
                    { 18, 15 },
                    { 19, 15 },
                    { 20, 5 },
                    { 21, 4 },
                    { 22, 4 },
                    { 23, 4 },
                    { 24, 5 },
                    { 25, 5 },
                    { 26, 12 },
                    { 27, 0 },
                    { 28, 15 },
                    { 29, 9 },
                    { 30, 2 },
                    { 31, 5 },
                    { 32, 4 },
                    { 33, 4 },
                    { 34, 6 },
                    { 35, 5 },
                    { 36, 4 },
                    { 37, 4 },
                    { 38, 2 },
                    { 39, 1 },
                    { 40, 2 },
                    { 41, 5 },
                    { 42, 5 },
                    { 43, 3 },
                    { 44, 3 },
                    { 45, 3 },
                    { 46, 3 },
                    { 47, 3 },
                    { 48, 14 },
                    { 49, 14 },
                    { 50, 14 },
                    { 51, 6 },
                    { 52, 6 },
                    { 53, 5 },
                    { 54, 5 },
                    { 55, 5 },
                    { 56, 14 },
                    { 57, 5 },
                    { 58, 5 },
                    { 59, 5 },
                    { 60, 14 },
                    { 61, 3 },
                    { 62, 5 },
                    { 63, 5 },
                    { 64, 5 },
                    { 65, 5 },
                    { 66, 6 },
                    { 67, 2 },
                    { 68, 0 },
                    { 69, 0 },
                    { 70, 0 },
                    { 71, 0 },
                    { 72, 0 },
                    { 73, 14 },
                    { 74, 15 },
                    { 75, 9 },
                    { 76, 9 },
                    { 77, 9 },
                    { 78, 9 },
                    { 79, 9 },
                    { 80, 9 },
                    { 81, 9 },
                    { 82, 15 },
                    { 83, 9 },
                    { 84, 14 },
                    { 85, 14 },
                    { 86, 9 },
                    { 87, 9 },
                    { 88, 0 },
                    { 89, 0 },
                    { 90, 6 },
                    { 91, 6 },
                    { 92, 5 },
                    { 93, 5 },
                    { 94, 5 },
                    { 95, 5 },
                    { 96, 4 },
                    { 97, 5 },
                    { 98, 5 },
                    { 99, 5 },
                    { 100, 0 },
                    { 101, 15 },
                    { 102, 3 },
                    { 103, 3 },
                    { 104, 5 },
                    { 105, 4 },
                    { 106, 6 },
                    { 107, 6 },
                    { 108, 6 },
                    { 109, 6 },
                    { 110, 6 },
                    { 111, 4 },
                    { 112, 4 },
                    { 113, 4 },
                    { 114, 4 },
                    { 115, 4 },
                    { 116, 4 },
                    { 117, 11 },
                    { 118, 11 },
                    { 119, 11 },
                    { 120, 6 },
                    { 121, 6 },
                    { 122, 2 },
                    { 123, 2 },
                    { 124, 0 },
                    { 125, 14 },
                    { 126, 14 },
                    { 127, 14 },
                    { 128, 14 },
                    { 129, 14 },
                    { 130, 0 },
                    { 131, 3 },
                    { 132, 2 },
                    { 133, 5 },
                    { 134, 0 },
                    { 135, 3 },
                    { 136, 3 },
                    { 137, 5 },
                    { 138, 6 },
                    { 139, 5 },
                    { 140, 5 },
                    { 141, 14 },
                    { 142, 9 },
                    { 143, 5 },
                    { 144, 3 },
                    { 145, 3 },
                    { 146, 7 },
                    { 147, 1 },
                    { 148, 5 },
                    { 149, 5 },
                    { 150, 0 },
                    { 151, 0 },
                    { 152, 7 },
                    { 153, 5 },
                    { 154, 15 },
                    { 155, 15 },
                    { 156, 15 },
                    { 157, 15 },
                    { 158, 15 },
                    { 159, 15 },
                    { 160, 15 },
                    { 161, 11 },
                    { 162, 0 },
                    { 163, 5 },
                    { 164, 5 },
                    { 165, 5 },
                    { 166, 5 },
                    { 167, 15 },
                    { 168, 15 },
                    { 169, 15 },
                    { 170, 15 },
                    { 171, 15 },
                    { 172, 14 },
                    { 173, 15 },
                    { 174, 15 },
                    { 175, 15 },
                    { 176, 15 },
                    { 177, 15 },
                    { 178, 15 },
                    { 179, 11 },
                    { 180, 3 },
                    { 181, 15 },
                    { 182, 15 },
                    { 183, 15 },
                    { 184, 14 },
                    { 185, 6 },
                    { 186, 6 },
                    { 187, 6 },
                    { 188, 6 },
                    { 189, 6 },
                    { 190, 6 },
                    { 191, 6 },
                    { 192, 5 },
                    { 193, 5 },
                    { 194, 4 },
                    { 195, 4 },
                    { 196, 1 },
                    { 197, 1 },
                    { 198, 1 },
                    { 199, 1 },
                    { 200, 1 },
                    { 201, 1 },
                    { 202, 2 },
                    { 203, 8 },
                    { 204, 4 },
                    { 205, 2 },
                    { 206, 1 },
                    { 207, 4 },
                    { 208, 11 },
                    { 209, 11 },
                    { 210, 11 },
                    { 211, 11 },
                    { 212, 0 },
                    { 213, 1 },
                    { 214, 1 },
                    { 215, 1 },
                    { 216, 5 },
                    { 217, 4 },
                    { 218, 0 },
                    { 219, 5 },
                    { 220, 15 },
                    { 221, 15 },
                    { 222, 15 },
                    { 223, 15 },
                    { 224, 14 },
                    { 225, 15 },
                    { 226, 11 },
                    { 227, 3 },
                    { 228, 3 },
                    { 229, 4 },
                    { 230, 0 },
                    { 231, 0 },
                    { 232, 0 },
                    { 233, 11 },
                    { 234, 6 },
                    { 235, 1 },
                    { 236, 14 },
                    { 237, 3 },
                    { 238, 3 },
                    { 239, 3 },
                    { 240, 5 },
                    { 241, 3 },
                    { 242, 6 },
                    { 243, 6 },
                    { 244, 9 },
                    { 245, 14 },
                    { 246, 14 },
                    { 247, 4 },
                    { 248, 5 },
                    { 249, 14 },
                }
            },
        };
        public static Dictionary<bool, Dictionary<int, int>> EmtptySlots = new Dictionary<bool, Dictionary<int, int>>()
        {
            { true, new Dictionary<int, int>() {
                { 1, 0 },
                { 3, 15 },
                { 4, 21 },
                { 5, 0 },
                { 6, 34 },
                { 7, 0 },
                { 8, 15 },
                { 9, 0 },
                { 10, 0 },
                { 11, 15 },
            }},
            { false, new Dictionary<int, int>() {
                { 1, 0 },
                { 3, 15 },
                { 4, 15 },
                { 5, 0 },
                { 6, 35 },
                { 7, 0 },
                { 8, 6 },
                { 9, 0 },
                { 10, 0 },
                { 11, 15 },
            }}
        };
        public static Dictionary<bool, Dictionary<int, Dictionary<int, int>>> CorrectGloves = new Dictionary<bool, Dictionary<int, Dictionary<int, int>>>()
        {
            { true, new Dictionary<int, Dictionary<int, int>>() {
                { 1, new Dictionary<int, int>() {
                    { 4, 16 },
                }},
                { 2, new Dictionary<int, int>() {
                    { 4, 17 },
                }},
                { 3, new Dictionary<int, int>() {
                    { 4, 18 },
                }},
                { 4, new Dictionary<int, int>() {
                    { 0, 19 },
                    { 1, 20 },
                    { 2, 21 },
                    { 4, 22 },
                    { 5, 23 },
                    { 6, 24 },
                    { 8, 25 },
                    { 11, 26 },
                    { 12, 27 },
                    { 14, 28 },
                    { 15, 29 },
                    { 112, 115 },
                    { 113, 122 },
                    { 114, 129 },
                }},
                { 5, new Dictionary<int, int>() {
                    { 0, 30 },
                    { 1, 31 },
                    { 2, 32 },
                    { 4, 33 },
                    { 5, 34 },
                    { 6, 35 },
                    { 8, 36 },
                    { 11, 37 },
                    { 12, 38 },
                    { 14, 39 },
                    { 15, 40 },
                    { 112, 116 },
                    { 113, 123 },
                    { 114, 130 },
                }},
                { 6, new Dictionary<int, int>() {
                    { 0, 41 },
                    { 1, 42 },
                    { 2, 43 },
                    { 4, 44 },
                    { 5, 45 },
                    { 6, 46 },
                    { 8, 47 },
                    { 11, 48 },
                    { 12, 49 },
                    { 14, 50 },
                    { 15, 51 },
                    { 112, 117 },
                    { 113, 124 },
                    { 114, 131 },
                }},
                { 7, new Dictionary<int, int>() {
                    { 0, 52 },
                    { 1, 53 },
                    { 2, 54 },
                    { 4, 55 },
                    { 5, 56 },
                    { 6, 57 },
                    { 8, 58 },
                    { 11, 59 },
                    { 12, 60 },
                    { 14, 61 },
                    { 15, 62 },
                    { 112, 118 },
                    { 113, 125 },
                    { 114, 132 },
                }},
                { 8, new Dictionary<int, int>() {
                    { 0, 63 },
                    { 1, 64 },
                    { 2, 65 },
                    { 4, 66 },
                    { 5, 67 },
                    { 6, 68 },
                    { 8, 69 },
                    { 11, 70 },
                    { 12, 71 },
                    { 14, 72 },
                    { 15, 73 },
                    { 112, 119 },
                    { 113, 126 },
                    { 114, 133 },
                }},
                { 9, new Dictionary<int, int>() {
                    { 0, 74 },
                    { 1, 75 },
                    { 2, 76 },
                    { 4, 77 },
                    { 5, 78 },
                    { 6, 79 },
                    { 8, 80 },
                    { 11, 81 },
                    { 12, 82 },
                    { 14, 83 },
                    { 15, 84 },
                    { 112, 120 },
                    { 113, 127 },
                    { 114, 134 },
                }},
                { 10, new Dictionary<int, int>() {
                    { 0, 85 },
                    { 1, 86 },
                    { 2, 87 },
                    { 4, 88 },
                    { 5, 89 },
                    { 6, 90 },
                    { 8, 91 },
                    { 11, 92 },
                    { 12, 93 },
                    { 14, 94 },
                    { 15, 95 },
                    { 112, 121 },
                    { 113, 128 },
                    { 114, 135 },
                }},
                { 11, new Dictionary<int, int>() {
                    { 4, 96 },
                }},
                { 12, new Dictionary<int, int>() {
                    { 4, 97 },
                }},
                { 13, new Dictionary<int, int>() {
                    { 0, 99 },
                    { 1, 100 },
                    { 2, 101 },
                    { 4, 102 },
                    { 5, 103 },
                    { 6, 104 },
                    { 8, 105 },
                    { 11, 106 },
                    { 12, 107 },
                    { 14, 108 },
                    { 15, 109 },
                }},
                { 14, new Dictionary<int, int>() {
                    { 4, 110 },
                }},
            }},
            { false, new Dictionary<int, Dictionary<int, int>>() {
                { 1, new Dictionary<int, int>(){
                    { 3, 17 },
                }},
                { 2, new Dictionary<int, int>(){
                    { 3, 18 },
                }},
                { 3, new Dictionary<int, int>(){
                    { 3, 19 },
                }},
                { 4, new Dictionary<int, int>(){
                    { 0, 20 },
                    { 1, 21 },
                    { 2, 22 },
                    { 3, 23 },
                    { 4, 24 },
                    { 5, 25 },
                    { 6, 26 },
                    { 7, 27 },
                    { 9, 28 },
                    { 11, 29 },
                    { 12, 30 },
                    { 14, 31 },
                    { 15, 32 },
                    { 129, 132 },
                    { 130, 139 },
                    { 131, 146 },
                    { 153, 154 },
                    { 161, 162 },
                }},
                { 5, new Dictionary<int, int>(){
                    { 0, 33 },
                    { 1, 34 },
                    { 2, 35 },
                    { 3, 36 },
                    { 4, 37 },
                    { 5, 38 },
                    { 6, 39 },
                    { 7, 40 },
                    { 9, 41 },
                    { 11, 42 },
                    { 12, 43 },
                    { 14, 44 },
                    { 15, 45 },
                    { 129, 133 },
                    { 130, 140 },
                    { 131, 147 },
                    { 153, 155 },
                    { 161, 163 },
                }},
                { 6, new Dictionary<int, int>(){
                    { 0, 46 },
                    { 1, 47 },
                    { 2, 48 },
                    { 3, 49 },
                    { 4, 50 },
                    { 5, 51 },
                    { 6, 52 },
                    { 7, 53 },
                    { 9, 54 },
                    { 11, 55 },
                    { 12, 56 },
                    { 14, 57 },
                    { 15, 58 },
                    { 129, 134 },
                    { 130, 141 },
                    { 131, 148 },
                    { 153, 156 },
                    { 161, 164 },
                }},
                { 7, new Dictionary<int, int>(){
                    { 0, 59 },
                    { 1, 60 },
                    { 2, 61 },
                    { 3, 62 },
                    { 4, 63 },
                    { 5, 64 },
                    { 6, 65 },
                    { 7, 66 },
                    { 9, 67 },
                    { 11, 68 },
                    { 12, 69 },
                    { 14, 70 },
                    { 15, 71 },
                    { 129, 135 },
                    { 130, 142 },
                    { 131, 149 },
                    { 153, 157 },
                    { 161, 165 },
                }},
                { 8, new Dictionary<int, int>(){
                    { 0, 72 },
                    { 1, 73 },
                    { 2, 74 },
                    { 3, 75 },
                    { 4, 76 },
                    { 5, 77 },
                    { 6, 78 },
                    { 7, 79 },
                    { 9, 80 },
                    { 11, 81 },
                    { 12, 82 },
                    { 14, 83 },
                    { 15, 84 },
                    { 129, 136 },
                    { 130, 143 },
                    { 131, 150 },
                    { 153, 158 },
                    { 161, 166 },
                }},
                { 9, new Dictionary<int, int>(){
                    { 0, 85 },
                    { 1, 86 },
                    { 2, 87 },
                    { 3, 88 },
                    { 4, 89 },
                    { 5, 90 },
                    { 6, 91 },
                    { 7, 92 },
                    { 9, 93 },
                    { 11, 94 },
                    { 12, 95 },
                    { 14, 96 },
                    { 15, 97 },
                    { 129, 137 },
                    { 130, 144 },
                    { 131, 151 },
                    { 153, 159 },
                    { 161, 167 },
                }},
                { 10, new Dictionary<int, int>(){
                    { 0, 98 },
                    { 1, 99 },
                    { 2, 100 },
                    { 3, 101 },
                    { 4, 102 },
                    { 5, 103 },
                    { 6, 104 },
                    { 7, 105 },
                    { 9, 106 },
                    { 11, 107 },
                    { 12, 108 },
                    { 14, 109 },
                    { 15, 110 },
                    { 129, 138 },
                    { 130, 145 },
                    { 131, 152 },
                    { 153, 160 },
                    { 161, 168 },
                }},
                { 11, new Dictionary<int, int>(){
                    { 3, 111 },
                }},
                { 12, new Dictionary<int, int>(){
                    { 0, 114 },
                    { 1, 115 },
                    { 2, 116 },
                    { 3, 117 },
                    { 4, 118 },
                    { 5, 119 },
                    { 6, 120 },
                    { 7, 121 },
                    { 9, 122 },
                    { 11, 123 },
                    { 12, 124 },
                    { 14, 125 },
                    { 15, 126 },
                }},
            }},
        };

        // словарь, в котором находятся соответствующие для key undershirts IDшники Underwears
        public static Dictionary<bool, Dictionary<int, int>> Undershirts = new Dictionary<bool, Dictionary<int, int>>()
        {
            { true, new Dictionary<int, int>(){
                { 0, 0 },
                { 2, 0 },
                { 1, 1 },
                { 14, 1 },
                { 5, 2 },
                { 8, 3 },
                { 9, 4 },
                { 12, 5 },
                { 29, 7 },
                { 30, 7 },
                { 16, 8 },
                { 18, 8 },
                { 17, 9 },
                { 23, 10 },
                { 24, 10 },
                { 27, 11 },
                { 37, 12 },
                { 39, 12 },
                { 38, 13 },
                { 44, 13 },
                { 40, 14 },
                { 41, 15 },
                { 42, 16 },
                { 43, 17 },
                { 47, 18 },
                { 48, 18 },
                { 53, 19 },
                { 54, 19 },
                { 67, 20 },
                { 68, 20 },
                { 65, 21 },
                { 66, 21 },
                { 101, 22 },
                { 102, 22 },
            }},
            { false, new Dictionary<int, int>(){
                { 0, 0 },
                { 1, 0 },
                { 5, 1 },
                { 11, 2 },
                { 13, 3 },
                { 16, 4 },
                { 22, 5 },
                { 20, 6 },
                { 21, 6 },
                { 23, 7 },
                { 26, 8 },
                { 27, 9 },
                { 28, 10 },
                { 29, 11 },
                { 30, 12 },
                { 31, 13 },
                { 51, 14 },
                { 49, 15 },
                { 50, 16 },
                { 45, 16 },
                { 57, 17 },
                { 59, 17 },
                { 60, 18 },
                { 61, 19 },
                { 63, 19 },
                { 67, 20 },
                { 68, 21 },
                { 71, 22 },
                { 74, 23 },
                { 80, 24 },
                { 82, 25 },
                { 83, 25 },
                { 111, 26 },
                { 108, 26 },
            }},
        };
        public static Dictionary<bool, Dictionary<int, Underwear>> Underwears = new Dictionary<bool, Dictionary<int, Underwear>>()
        {
            { true, new Dictionary<int, Underwear>(){
                { 0, new Underwear(0, 300, new Dictionary<int, int>(){ { 0, 0 }, { 1, 2 } }, new List<int>() { 0, 1, 2, 3, 4 }) },
                { 1, new Underwear(1, 320, new Dictionary<int, int>(){ { 0, 1 }, { 1, 14 } }, new List<int>() { 0, 1, 3, 4, 5, 6, 7, 8 }) },
                { 2, new Underwear(5, 280, new Dictionary<int, int>(){ { 0, 5 } }, new List<int>() { 0, 1, 2 }) },
                { 3, new Underwear(8, 300, new Dictionary<int, int>(){ { 0, 8 } }, new List<int>() { 0 }) },
                { 4, new Underwear(9, 300, new Dictionary<int, int>(){ { 0, 9 } }, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7}) },
                { 5, new Underwear(12, 700, new Dictionary<int, int>(){ { 0, 12 } }, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11}) },
                { 6, new Underwear(13, 700, new List<int>() { 0, 1, 2, 3}) },
                { 7, new Underwear(14, 700, new Dictionary<int, int>(){ { 0, 29 }, { 1, 30 } }, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15}) },
                { 8, new Underwear(16, 320, new Dictionary<int, int>(){ { 0, 16 }, { 1, 18 } }, new List<int>() { 0, 1, 2 }) },
                { 9, new Underwear(17, 320, new Dictionary<int, int>(){ { 0, 17 } }, new List<int>() { 0, 1, 2, 3, 4, 5 }) },
                { 10, new Underwear(22, 300, new Dictionary<int, int>(){ { 0, 23 }, { 1, 24 } }, new List<int>() { 0, 1, 2 }) },
                { 11, new Underwear(26, 1000, new Dictionary<int, int>(){ { 0, 27 }, { 1, 27 } }, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9}) },
                { 12, new Underwear(33, 300, new Dictionary<int, int>(){ { 0, 37 }, { 1, 39 } }, new List<int>() { 0 }) },
                { 13, new Underwear(34, 300, new Dictionary<int, int>(){ { 0, 38 }, { 1, 44 } }, new List<int>() { 0, 1}) },
                { 14, new Underwear(36, 300, new Dictionary<int, int>(){ { 0, 40 } }, new List<int>() { 0, 1, 2, 3, 4, 5}) },
                { 15, new Underwear(38, 700, new Dictionary<int, int>(){ { 0, 41 } }, new List<int>() { 0, 1, 2, 3, 4 }) },
                { 16, new Underwear(39, 500, new Dictionary<int, int>(){ { 0, 42 } }, new List<int>() { 0, 1}) },
                { 17, new Underwear(41, 700, new Dictionary<int, int>(){ { 0, 43 } }, new List<int>() { 0, 1, 2, }) },
                { 18, new Underwear(44, 300, new Dictionary<int, int>(){ { 0, 47 }, { 1, 48 } }, new List<int>() { 0, 1, 2, 3 }) },
                { 19, new Underwear(47, 300, new Dictionary<int, int>(){ { 0, 53 }, { 1, 54 } }, new List<int>() { 0, 1 }) },
                { 20, new Underwear(71, 5000, new Dictionary<int, int>(){ { 0, 67 }, { 1, 68 } }, new List<int>() { 0}) },
                { 21, new Underwear(73, 20000, new Dictionary<int, int>(){ { 0, 65 }, { 1, 66 } }, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15}) },
                { 22, new Underwear(208, 500, new Dictionary<int, int>(){ { 0, 101 }, { 1, 102 } }, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23 }) },
                { 23, new Underwear(81, 3000, new Dictionary<int, int>(){ }, new List<int>() { 0, 1, 2 }) },
                { 24, new Underwear(82, 20000, new Dictionary<int, int>(){ }, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 10, 11, 12, 13, 14, 15 }) },
                { 25, new Underwear(83, 3000, new Dictionary<int, int>(){ }, new List<int>() { 0, 1, 2, 3, 4 }) },
                { 26, new Underwear(92, 5000, new Dictionary<int, int>(){ }, new List<int>() { 0, 1, 2, 3, 4, 5, 6 }) },
                { 27, new Underwear(117, 2500, new Dictionary<int, int>(){ }, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }) },
                { 28, new Underwear(126, 3000, new Dictionary<int, int>(){ }, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 }) },
                { 29, new Underwear(128, 2500, new Dictionary<int, int>(){ }, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }) },
                { 30, new Underwear(135, 4000, new Dictionary<int, int>(){ }, new List<int>() { 0, 1, 2, 3, 4, 5, 6 }) },
                { 31, new Underwear(144, 7000, new Dictionary<int, int>(){ }, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 }) },
            }},
            { false, new Dictionary<int, Underwear>(){
                { 0, new Underwear(0, 300, new Dictionary<int, int>() { { 0, 0 }, { 1, 1 } }, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15}) },
                { 1, new Underwear(5, 300, new Dictionary<int, int>() { { 0, 5 }, { 1, 5 } }, new List<int>() { 0, 1, 7, 9}) },
                { 2, new Underwear(11, 300, new Dictionary<int, int>() { { 0, 11 }, { 1, 11 } }, new List<int>() { 0, 2, 10, 11, 15}) },
                { 3, new Underwear(13, 1000, new Dictionary<int, int>() { { 0, 13 }, { 1, 13 } }, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15}) },
                { 4, new Underwear(16, 350, new Dictionary<int, int>() { { 0, 16 }, { 1, 16 } }, new List<int>() { 0, 1, 2, 3, 4, 5, 6}) },
                { 5, new Underwear(22, 1000, new Dictionary<int, int>() { { 0, 22 }, { 1, 22 } }, new List<int>() { 0, 1, 2, 3, 4}) },
                { 6, new Underwear(23, 300, new Dictionary<int, int>() { { 0, 20 }, { 1, 21 } }, new List<int>() { 0, 1, 2}) },
                { 7, new Underwear(26, 1000, new Dictionary<int, int>() { { 0, 23 } }, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12}) },
                { 8, new Underwear(30, 300, new Dictionary<int, int>() { { 0, 26 } }, new List<int>() { 0, 1, 2}) },
                { 9, new Underwear(32, 700, new Dictionary<int, int>() { { 0, 27 }, { 1, 27 } }, new List<int>() { 0, 1, 2}) },
                { 10, new Underwear(33, 300, new Dictionary<int, int>() { { 0, 28 }, { 1, 28 } }, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8}) },
                { 11, new Underwear(36, 1000, new Dictionary<int, int>() { { 0, 29 }, { 1, 29 } }, new List<int>() { 0, 1, 2, 3, 4}) },
                { 12, new Underwear(38, 300, new Dictionary<int, int>() { { 0, 30 } }, new List<int>() { 0, 1, 2, 3}) },
                { 13, new Underwear(40, 1000, new Dictionary<int, int>() { { 0, 31 } }, new List<int>() { 0}) },
                { 14, new Underwear(49, 300, new Dictionary<int, int>() { { 0, 51 } }, new List<int>() { 0, 1}) },
                { 15, new Underwear(67, 300, new Dictionary<int, int>() { { 0, 49 } }, new List<int>() { 0}) },
                { 16, new Underwear(68, 5000, new Dictionary<int, int>() { { 0, 50 }, { 1, 45 } }, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19}) },
                { 17, new Underwear(73, 300, new Dictionary<int, int>() { { 0, 57 }, { 1, 59 } }, new List<int>() { 0, 1, 2}) },
                { 18, new Underwear(74, 300, new Dictionary<int, int>() { { 0, 60 }, { 1, 60 } }, new List<int>() { 0, 1, 2}) },
                { 19, new Underwear(75, 500, new Dictionary<int, int>() { { 0, 61 }, { 1, 63 } }, new List<int>() { 0, 1, 2, 3}) },
                { 20, new Underwear(103, 700, new Dictionary<int, int>() { { 1, 67 } }, new List<int>() { 0, 1, 2, 3, 4, 5}) },
                { 21, new Underwear(111, 5000, new Dictionary<int, int>() { { 0, 68 }, { 1, 68 } }, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11}) },
                { 22, new Underwear(117, 300, new Dictionary<int, int>() { { 0, 71 }, { 1, 71 } }, new List<int>() { 0, 1, 2}) },
                { 23, new Underwear(118, 300, new Dictionary<int, int>() { { 0, 74 }, { 1, 74 } }, new List<int>() { 0, 1, 2}) },
                { 24, new Underwear(141, 300, new Dictionary<int, int>() { { 0, 80 }, { 1, 80 } }, new List<int>() { 0, 1, 2, 3, 4, 5}) },
                { 25, new Underwear(149, 300, new Dictionary<int, int>() { { 0, 82 }, { 1, 83 } }, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15}) },
                { 26, new Underwear(208, 2000, new Dictionary<int, int>() { { 0, 111 }, { 1, 108 } }, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16}) },
                { 27, new Underwear(9, 2000, new Dictionary<int, int>() { }, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 }) },
                { 28, new Underwear(83, 4000, new Dictionary<int, int>() { }, new List<int>() { 0, 1, 2, 3, 4, 5, 6 }) },
                { 29, new Underwear(142, 7000, new Dictionary<int, int>() { }, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 }) },
                { 30, new Underwear(171, 2500, new Dictionary<int, int>() { }, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7 }) },
            }},
        };

        public static Dictionary<bool, List<Clothes>> Hats = new Dictionary<bool, List<Clothes>>()
        {
            { true, new List<Clothes>(){
                new Clothes(2, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7 }, 100),
                new Clothes(4, new List<int>() { 0, 1 }, 100),
                new Clothes(5, new List<int>() { 0, 1,}, 200),
                new Clothes(7, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7 }, 630),
                new Clothes(12, new List<int>() { 0, 1, 2, 4, 6, 7 }, 630),
                new Clothes(13, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7 }, 750),
                new Clothes(14, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7 }, 250),
                new Clothes(20, new List<int>() { 0, 1, 2, 3, 4, 5 }, 350),
                new Clothes(21, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7 }, 500),
                new Clothes(25, new List<int>() { 0, 1, 2 }, 200),
                new Clothes(26, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 }, 1000),
                new Clothes(27, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 }, 2000),
                new Clothes(28, new List<int>() { 0, 1, 2, 3, 4, 5 }, 500),
                new Clothes(29, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7 }, 500),
                new Clothes(30, new List<int>() { 0, 1 }, 300),
                new Clothes(31, new List<int>() { 0 }, 300),
                new Clothes(34, new List<int>() { 0 }, 300),
                new Clothes(36, new List<int>() { 0 }, 300),
                new Clothes(37, new List<int>() { 0, 1, 2, 3, 4, 5 }, 750),
                new Clothes(40, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7 }, 500),
                new Clothes(42, new List<int>() { 0, 1, 2, 3, 4 }, 600),
                new Clothes(44, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7 }, 500),
                new Clothes(45, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7 }, 500),
                new Clothes(109, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10}, 1200),
                new Clothes(132, new List<int>() { 0, 1, 2, 3 }, 600),
            }},
            { false, new List<Clothes>(){
                new Clothes(4, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7 }, 300),
                new Clothes(5, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7 }, 500),
                new Clothes(7, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7 }, 750),
                new Clothes(9, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7 }, 700),
                new Clothes(12, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7 }, 700),
                new Clothes(13, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7 }, 500),
                new Clothes(14, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7 }, 1000),
                new Clothes(22, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7 }, 800),
                new Clothes(25, new List<int>() { 0 }, 400),
                new Clothes(34, new List<int>() { 0 }, 250),
                new Clothes(35, new List<int>() { 0 }, 300),
                new Clothes(43, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7 }, 900),
                new Clothes(44, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7 }, 900),
            }},
        };
        public static Dictionary<bool, List<Clothes>> Legs = new Dictionary<bool, List<Clothes>>()
        {
            { true, new List<Clothes>(){
                new Clothes(0, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }, 500),
                new Clothes(1, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }, 500),
                new Clothes(3, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }, 500),
                new Clothes(4, new List<int>() { 0, 1, 2, 4 }, 1500),
                new Clothes(5, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }, 500),
                new Clothes(6, new List<int>() { 0, 1, 2, }, 500),
                new Clothes(7, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }, 800),
                new Clothes(8, new List<int>() { 0, 3, 4 }, 300),
                new Clothes(9, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }, 500),
                new Clothes(12, new List<int>() { 0 }, 500),
                new Clothes(13, new List<int>() { 0, 1, 2 }, 350),
                new Clothes(14, new List<int>() { 0, 1, 2 }, 300),
                new Clothes(15, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }, 500),
                new Clothes(16, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }, 500),
                new Clothes(17, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 500),
                new Clothes(18, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }, 750),
                new Clothes(19, new List<int>() { 0, 1 }, 500),
                new Clothes(20, new List<int>() { 0, 1, 2, 3 }, 1000),
                new Clothes(22, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 1000),
                new Clothes(23, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 1000),
                new Clothes(24, new List<int>() { 0, 1, 2, 3, 4, 5, 6 }, 750),
                new Clothes(25, new List<int>() { 0, 1, 2, 3, 4, 5, 6 }, 1000),
                new Clothes(26, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }, 1000),
                new Clothes(27, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }, 700),
                new Clothes(28, new List<int>() { 0, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 }, 1200),
                new Clothes(29, new List<int>() { 0, 1, 2 }, 750),
                new Clothes(32, new List<int>() { 0, 1, 2, 3 }, 900),
                new Clothes(37, new List<int>() { 0, 1, 2, 3 }, 900),
                new Clothes(42, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7 }, 1100),
                new Clothes(45, new List<int>() { 0, 1, 2, 3, 4, 5, 6 }, 1100),
                new Clothes(46, new List<int>() { 0, 1 }, 500),
                new Clothes(47, new List<int>() { 0, 1 }, 500),
                new Clothes(51, new List<int>() { 0 }, 950),
                new Clothes(54, new List<int>() { 0, 1, 2, 3, 4, 5, 6 }, 1000),
                new Clothes(61, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13}, 150),
                new Clothes(69, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18 }, 1750),
            }},
            { false, new List<Clothes>(){
                new Clothes(0, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }, 300),
                new Clothes(1, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }, 300),
                new Clothes(2, new List<int>() { 0, 1, 2 }, 300),
                new Clothes(3, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }, 500),
                new Clothes(4, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }, 500),
                new Clothes(6, new List<int>() { 0, 1, 2 }, 500),
                new Clothes(7, new List<int>() { 0, 1, 2 }, 1000),
                new Clothes(8, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 1200),
                new Clothes(9, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }, 630),
                new Clothes(10, new List<int>() { 0, 1, 2 }, 500),
                new Clothes(11, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7 }, 500),
                new Clothes(12, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 1000),
                new Clothes(14, new List<int>() { 0, 1 }, 400),
                new Clothes(16, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 700),
                new Clothes(17, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }, 700),
                new Clothes(19, new List<int>() { 0, 1, 2, 3, 4 }, 150),
                new Clothes(20, new List<int>() { 0, 1, 2 }, 600),
                new Clothes(23, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }, 630),
                new Clothes(24, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 1000),
                new Clothes(25, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 1000),
                new Clothes(27, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }, 1000),
                new Clothes(41, new List<int>() { 0, 1, 2, 3 }, 1000),
                new Clothes(43, new List<int>() { 0, 1, 2, 3, 4 }, 1200),
                new Clothes(44, new List<int>() { 0, 1, 2, 3, 4 }, 1200),
                new Clothes(53, new List<int>() { 0 }, 500),
                new Clothes(56, new List<int>() { 0, 1, 2, 3, 4, 5 }, 175),
                new Clothes(57, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7}, 450),
                new Clothes(60, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15}, 750),
                new Clothes(62, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11}, 250),
                new Clothes(63, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11}, 1350),
                new Clothes(102, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20}, 1800),
            }},
        };
        public static Dictionary<bool, List<Clothes>> Feets = new Dictionary<bool, List<Clothes>>()
        {
            { true, new List<Clothes>(){
                new Clothes(1, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }, 500),
                new Clothes(3, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }, 1000),
                new Clothes(4, new List<int>() { 0, 1, 2, 4,  }, 630),
                new Clothes(5, new List<int>() { 0, 1, 2, 3 }, 500),
                new Clothes(6, new List<int>() { 0, 1 }, 500),
                new Clothes(7, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }, 1000),
                new Clothes(8, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }, 500),
                new Clothes(9, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }, 500),
                new Clothes(12, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }, 2000),
                new Clothes(14, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }, 750),
                new Clothes(15, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }, 1000),
                new Clothes(16, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8 }, 300),
                new Clothes(20, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }, 2000),
                new Clothes(21, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }, 750),
                new Clothes(22, new List<int>() { 0, 1, 2, 3, 4, 5, 7, 8, 9, 10, 11 }, 1000),
                new Clothes(23, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }, 2000),
                new Clothes(26, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 11, 12, 13, 14, 15 }, 750),
                new Clothes(28, new List<int>() { 0, 1, 2, 3, 4, 5 }, 2000),
                new Clothes(32, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }, 1000),
                new Clothes(42, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 1000),
            }},
            { false, new List<Clothes>(){
                new Clothes(0, new List<int>() { 0, 1, 2, 3 }, 1000),
                new Clothes(1, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }, 1000),
                new Clothes(2, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }, 1000),
                new Clothes(3, new List<int>() { 0, 1, 2, 3, 4, 5 }, 750),
                new Clothes(6, new List<int>() { 0, 1, 2, 3 }, 750),
                new Clothes(7, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }, 1000),
                new Clothes(8, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }, 1000),
                new Clothes(14, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }, 800),
                new Clothes(15, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }, 750),
                new Clothes(9, new List<int>() { 0, 1, 2, 3 }, 1000),
                new Clothes(21, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7 }, 750),
                new Clothes(32, new List<int>() { 0, 1, 2, 3, 4 }, 1000),
                new Clothes(33, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7 }, 1000),
                new Clothes(4, new List<int>() { 0, 1, 2, 3 }, 1000),
                new Clothes(16, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 300),
            }},
        };
        public static Dictionary<bool, List<Clothes>> Tops = new Dictionary<bool, List<Clothes>>()
        {
            { true, new List<Clothes>(){
                new Clothes(3, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }, 500, 0),
                new Clothes(4, new List<int>() { 0, 2, 3, 11, 14 }, 2000, 0),
                new Clothes(7, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }, 700, 0),
                new Clothes(10, new List<int>() { 0, 1, 2 }, 1000, 0),
                new Clothes(20, new List<int>() { 0, 1, 2, 3 }, 1000, 0),
                new Clothes(23, new List<int>() { 0, 1, 2, 3}, 750, 0),
                new Clothes(24, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 750, 0),
                new Clothes(27, new List<int>() { 0, 1, 2 }, 1000, 0),
                new Clothes(28, new List<int>() { 0, 1, 2 }, 900, 0),
                new Clothes(35, new List<int>() { 0, 1, 2, 3, 4, 5, 6 }, 2000, 0),
                new Clothes(58, new List<int>() { 0 }, 750, 0),
                new Clothes(59, new List<int>() { 0, 1, 2, 3 }, 1000, 0),
                new Clothes(62, new List<int>() { 0 }, 8000, 0),
                new Clothes(70, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11}, 3000, 0),
                new Clothes(72, new List<int>() { 0, 1, 2, 3 }, 4000, 0),
                new Clothes(74, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 4000, 0),
                new Clothes(77, new List<int>() { 0, 1, 2, 3 }, 4000, 0),
                new Clothes(88, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11}, 1000, 0),
                new Clothes(106, new List<int>() { 0 }, 4000, 0),
                new Clothes(115, new List<int>() { 0 }, 4000, 0),
                new Clothes(118, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 750, 0),
                new Clothes(119, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }, 1000, 0),
                new Clothes(122, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 }, 1000, 0),
                new Clothes(124, new List<int>() { 0 }, 1000, 0),
                new Clothes(127, new List<int>() {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 }, 1000, 0),
                new Clothes(130, new List<int>() { 0 }, 1000, 0),
                new Clothes(136, new List<int>() { 0, 1, 2, 3, 4, 5, 6 }, 750, 0),
                new Clothes(142, new List<int>() { 0, 1, 2 }, 2000, 0),
                new Clothes(151, new List<int>() { 0, 1, 2, 3, 4, 5 }, 1000, 0),
                new Clothes(156, new List<int>() { 0, 1, 2, 3, 4, 5 }, 1000, 0),
                new Clothes(163, new List<int>() { 0 }, 500, 0),
                new Clothes(166, new List<int>() { 0, 1, 2, 3, 4, 5 }, 1000, 0),
                new Clothes(167, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }, 2000, 0),
                new Clothes(169, new List<int>() { 0, 1, 2, 3 }, 700, 0),
                new Clothes(172, new List<int>() { 0, 1, 2, 3 }, 1400, 0),
                new Clothes(181, new List<int>() { 0, 1, 2, 3, 4, 5 }, 1000, 0),
                new Clothes(185, new List<int>() { 0, 1, 2, 3 }, 1000, 0),
                new Clothes(189, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 1000, 0),
                new Clothes(191, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 }, 2000, 0),
                new Clothes(192, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }, 1000, 0),
                new Clothes(6, new List<int>() { 0, 1, 3, 4, 5, 6, 8, 9, 11 }, 1000, 1),
                new Clothes(37, new List<int>() { 0, 1, 2 }, 1500, 1),
                new Clothes(64, new List<int>() { 0 }, 1000, 1),
                new Clothes(68, new List<int>() { 0, 1, 2, 3, 4, 5 }, 1000, 1),
                new Clothes(69, new List<int>() { 0, 1, 2, 3, 4, 5 }, 1000, 1),
                new Clothes(76, new List<int>() { 0, 1, 2, 3, 4 }, 1000, 1),
                new Clothes(161, new List<int>() { 0, 1, 2, 3}, 500, 1),
                new Clothes(168, new List<int>() { 0, 1, 2 }, 500, 1),
                new Clothes(174, new List<int>() { 0, 1, 2, 3 }, 1000, 1),
                new Clothes(61, new List<int>() { 0, 1, 2, 3 }, 1000, 2),
                new Clothes(75, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 2000, 2),
                new Clothes(78, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }, 1000, 2),
                new Clothes(79, new List<int>() { 0 }, 1000, 2),
                new Clothes(84, new List<int>() { 0, 1, 2, 3, 4, 5 }, 1000, 2),
                new Clothes(86, new List<int>() { 0, 1, 2, 3, 4 }, 1000, 2),
                new Clothes(90, new List<int>() { 0 }, 1000, 2),
                new Clothes(96, new List<int>() { 0 }, 750, 2),
                new Clothes(107, new List<int>() { 0, 1, 2, 3, 4 }, 1000, 2),
                new Clothes(110, new List<int>() { 0 }, 1000, 2),
                new Clothes(113, new List<int>() { 0, 1, 2, 3 }, 500, 2),
                new Clothes(125, new List<int>() { 0 }, 1000, 2),
                new Clothes(129, new List<int>() { 0 }, 1000, 2),
                new Clothes(134, new List<int>() { 0, 1, 2 }, 7000, 2),
                new Clothes(138, new List<int>() { 0, 1, 2 }, 1000, 2),
                new Clothes(141, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 500, 2),
                new Clothes(143, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 1000, 2),
                new Clothes(147, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 1000, 2),
                new Clothes(148, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }, 630, 2),
                new Clothes(150, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }, 630, 2),
                new Clothes(152, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }, 1000, 2),
                new Clothes(153, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 }, 1000, 2),
                new Clothes(154, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7 }, 1000, 2),
                new Clothes(171, new List<int>() { 0, 1 }, 1000, 2),
                new Clothes(182, new List<int>() { 0, 1 }, 1000, 2),
                new Clothes(184, new List<int>() { 0, 1, 2, 3 }, 1000, 2),
                new Clothes(187, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12}, 2000, 2),
                new Clothes(188, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 2000, 2),
                new Clothes(200, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 }, 2000, 2),
                new Clothes(203, new List<int>() {  0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 }, 2000, 2),
                new Clothes(204, new List<int>() {  0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 1500, 2),
                new Clothes(85, new List<int>() { 0 }, 1000, 2),
                new Clothes(87, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }, 5000, 2),
                new Clothes(89, new List<int>() { 0, 1, 2, 3 }, 750, 2),
                new Clothes(190, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 }, 750, 2),
            }},
            { false, new List<Clothes>(){
                new Clothes(1, new List<int>() { 0, 1, 2, 4, 5, 6, 9, 11, 14 }, 700, 0),
                new Clothes(6, new List<int>() { 0, 1, 2, 4 }, 1000, 0),
                new Clothes(7, new List<int>() { 0, 1, 2, 8 }, 1000, 0),
                new Clothes(8, new List<int>() { 0, 1, 2, 12 }, 700, 0),
                new Clothes(24, new List<int>() {  0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }, 2000, 0),
                new Clothes(25, new List<int>() {  0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 750, 0),
                new Clothes(31, new List<int>() { 0, 1, 2, 3, 4, 5, 6 }, 700, 0),
                new Clothes(34, new List<int>() { 0 }, 4000, 0),
                new Clothes(35, new List<int>() {  0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }, 700, 0),
                new Clothes(53, new List<int>() { 0, 1, 2, 3}, 1000, 0),
                new Clothes(58, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8 }, 1000, 0),
                new Clothes(64, new List<int>() { 0, 1, 2, 3, 4 }, 2000, 0),
                new Clothes(65, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }, 7000, 0),
                new Clothes(90, new List<int>() { 0, 1, 2, 3, 4 }, 2000, 0),
                new Clothes(91, new List<int>() { 0, 1, 2, 3, 4 }, 2000, 0),
                new Clothes(92, new List<int>() { 0, 1, 2, 3 }, 750, 0),
                new Clothes(94, new List<int>() { 0 }, 4000, 0),
                new Clothes(97, new List<int>() { 0 }, 750, 0),
                new Clothes(107, new List<int>() { 0 }, 750, 0),
                new Clothes(120, new List<int>() {  0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 }, 1000, 0),
                new Clothes(148, new List<int>() { 0, 1, 2, 3, 4, 5 }, 1000, 0),
                new Clothes(153, new List<int>() { 0, 1, 2, 3, 4, 5 }, 1000, 0),
                new Clothes(160, new List<int>() { 0 }, 1000, 0),
                new Clothes(163, new List<int>() { 0, 1, 2, 3, 4, 5 }, 2000, 0),
                new Clothes(164, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }, 10000, 0),
                new Clothes(166, new List<int>() { 0, 1, 2, 3 }, 1000, 0),
                new Clothes(174, new List<int>() { 0, 1, 2, 3 }, 2000, 0),
                new Clothes(183, new List<int>() { 0, 1, 2, 3, 4, 5 }, 1000, 0),
                new Clothes(185, new List<int>() { 0, 1, 2, 3, 4, 5 }, 750, 0),
                new Clothes(187, new List<int>() { 0, 1, 2, 3 }, 1000, 0),
                new Clothes(191, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 1000, 0),
                new Clothes(193, new List<int>() {  0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 }, 3000, 0),
                new Clothes(194, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }, 5000, 0),
                new Clothes(133, new List<int>() { 0, 1, 2, 3, 4, 5, 6 }, 750, 0),
                new Clothes(139, new List<int>() { 0, 1, 2 }, 750, 0),
                new Clothes(10, new List<int>() { 0, 1, 2, 7, 10, 11, 13, 15 }, 500, 1),
                new Clothes(99, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 3000, 1),
                new Clothes(143, new List<int>() {  0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 }, 15000, 1),
                new Clothes(158, new List<int>() { 0, 1, 2, 3 }, 700, 1),
                new Clothes(176, new List<int>() { 0, 1, 2, 3 }, 1000, 1),
                new Clothes(3, new List<int>() { 0, 1, 2, 3, 4, 10, 11, 12, 13, 14 }, 500, 2),
                new Clothes(21, new List<int>() { 0, 1, 2, 3, 4, 5 }, 1500, 2),
                new Clothes(37, new List<int>() { 0, 1, 2, 3, 4, 5 }, 1000, 2),
                new Clothes(50, new List<int>() { 0 }, 500, 2),
                new Clothes(54, new List<int>() { 0, 1, 2, 3 }, 500, 2),
                new Clothes(55, new List<int>() { 0 }, 500, 2),
                new Clothes(62, new List<int>() { 0, 1, 2, 3, 4, 5 }, 500, 2),
                new Clothes(63, new List<int>() { 0, 1, 2, 3, 4, 5 }, 500, 2),
                new Clothes(66, new List<int>() { 0, 1, 2, 3 }, 750, 2),
                new Clothes(69, new List<int>() { 0 }, 1000, 2),
                new Clothes(70, new List<int>() { 0, 1, 2, 3, 4 }, 800, 2),
                new Clothes(72, new List<int>() { 0 }, 1000, 2),
                new Clothes(78, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7 }, 1000, 2),
                new Clothes(80, new List<int>() { 0 }, 1500, 2),
                new Clothes(81, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }, 2000, 2),
                new Clothes(87, new List<int>() { 0 }, 2000, 2),
                new Clothes(102, new List<int>() { 0 }, 1000, 2),
                new Clothes(103, new List<int>() { 0, 1, 2, 3, 4, 5 }, 1000, 2),
                new Clothes(105, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7 }, 1000, 2),
                new Clothes(110, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 1000, 2),
                new Clothes(113, new List<int>() { 0, 1, 2 }, 2000, 2),
                new Clothes(114, new List<int>() { 0, 1, 2 }, 750, 2),
                new Clothes(115, new List<int>() { 0, 1, 2 }, 750, 2),
                new Clothes(116, new List<int>() { 0, 1, 2 }, 750, 2),
                new Clothes(121, new List<int>() {  0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 }, 500, 2),
                new Clothes(122, new List<int>() { 0 }, 1000, 2),
                new Clothes(127, new List<int>() { 0 }, 500, 2),
                new Clothes(131, new List<int>() { 0, 1, 2 }, 1000, 2),
                new Clothes(135, new List<int>() { 0, 1, 2 }, 1000, 2),
                new Clothes(138, new List<int>() {  0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 1000, 2),
                new Clothes(140, new List<int>() {  0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 1000, 2),
                new Clothes(144, new List<int>() {  0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 1500, 2),
                new Clothes(145, new List<int>() {  0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }, 1000, 2),
                new Clothes(147, new List<int>() {  0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }, 8000, 2),
                new Clothes(149, new List<int>() {  0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }, 1000, 2),
                new Clothes(150, new List<int>() {  0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 }, 1000, 2),
                new Clothes(151, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7 }, 1500, 2),
                new Clothes(165, new List<int>() { 0, 1, 2 }, 1000, 2),
                new Clothes(172, new List<int>() { 0, 1 }, 500, 2),
                new Clothes(184, new List<int>() { 0, 1 }, 500, 2),
                new Clothes(186, new List<int>() { 0, 1, 2, 3 }, 500, 2),
                new Clothes(189, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 1000, 2),
                new Clothes(190, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 1000, 2),
                new Clothes(202, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 }, 2000, 2),
                new Clothes(205, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25}, 2000, 2),
                new Clothes(206, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 1000, 2),
                new Clothes(71, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }, 1000, 2),
                new Clothes(77, new List<int>() { 0 }, 2000, 2),
                new Clothes(106, new List<int>() { 0, 1, 2, 3 }, 2000, 2),
                new Clothes(123, new List<int>() { 0, 2, 3, 4, 1, 5, 6, 7, 8, 9, 10, 11 }, 2000, 2),
                new Clothes(162, new List<int>() { 0, 1, 2, 3, 4, 5, 6 }, 2000, 2),
                new Clothes(192, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 }, 2000, 2),
            }},
        };
        public static Dictionary<bool, List<Clothes>> Gloves = new Dictionary<bool, List<Clothes>>()
        {
            { true, new List<Clothes>(){
                new Clothes(4, new List<int>() { 0, 1 }, 4000),
                new Clothes(5, new List<int>() { 0, 1 }, 4200),
                new Clothes(6, new List<int>() { 0, 1 }, 4200),
                new Clothes(7, new List<int>() { 0, 1 }, 4200),
                new Clothes(9, new List<int>() { 0 }, 4200),
                new Clothes(10, new List<int>() { 0, 1 }, 3000),
                new Clothes(13, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 3000),
            }},
            { false, new List<Clothes>(){
                new Clothes(4, new List<int>() { 0, 1 }, 3000),
                new Clothes(5, new List<int>() { 0, 1 }, 3500),
                new Clothes(6, new List<int>() { 0 }, 3000),
                new Clothes(7, new List<int>() { 0, 1 }, 3000),
                new Clothes(8, new List<int>() { 0 }, 2550),
                new Clothes(9, new List<int>() { 0 }, 2000),
                new Clothes(10, new List<int>() { 0, 1 }, 11000),
                new Clothes(12, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7,8,9 }, 8000),
            }},
        };
        public static Dictionary<bool, List<Clothes>> Accessories = new Dictionary<bool, List<Clothes>>()
        {
            { true, new List<Clothes>(){
                new Clothes(0, new List<int>() { 0 }, 15000),
                new Clothes(1, new List<int>() { 0 }, 10000),
                new Clothes(3, new List<int>() { 0, 1, 2, 3 }, 8000),
                new Clothes(4, new List<int>() { 0, 1, 2, 3 }, 6000),
                new Clothes(5, new List<int>() { 0, 1, 2, 3 }, 12000),
                new Clothes(6, new List<int>() { 0, 1, 2 }, 80000),
                new Clothes(7, new List<int>() { 0, 1, 2 }, 50000),
                new Clothes(8, new List<int>() { 0, 1, 2 }, 80000),
                new Clothes(9, new List<int>() { 0, 1, 2 }, 70000),
                new Clothes(10, new List<int>() { 0, 1, 2 }, 30000),
                new Clothes(11, new List<int>() { 0, 1, 2 }, 40000),
                new Clothes(12, new List<int>() { 0, 1, 2 }, 6000),
                new Clothes(13, new List<int>() { 0, 1, 2 }, 6000),
                new Clothes(14, new List<int>() { 0, 1, 2 }, 6000),
                new Clothes(15, new List<int>() { 0, 1, 2 }, 40000),
                new Clothes(16, new List<int>() { 0, 1, 2 }, 33000),
                new Clothes(17, new List<int>() { 0, 1, 2 }, 30000),
                new Clothes(18, new List<int>() { 0, 1, 2 }, 9000),
                new Clothes(19, new List<int>() { 0, 1, 2 }, 110000),
                new Clothes(20, new List<int>() { 0, 1, 2 }, 70000),
                new Clothes(21, new List<int>() { 0, 1, 2 }, 7000),
                new Clothes(22, new List<int>() { 0 }, 6000),
                new Clothes(23, new List<int>() { 0 }, 6000),
                new Clothes(24, new List<int>() { 0 }, 8000),
                new Clothes(25, new List<int>() { 0 }, 9000),
                new Clothes(26, new List<int>() { 0 }, 7000),
                new Clothes(27, new List<int>() { 0 }, 6000),
                new Clothes(28, new List<int>() { 0 }, 3000),
                new Clothes(29, new List<int>() { 0, 1, 2, 3 }, 3000),
            }},
            { false, new List<Clothes>(){
                new Clothes(2, new List<int>() { 0, 1, 2, 3 }, 80000),
                new Clothes(3, new List<int>() { 0, 1, 2 }, 120000),
                new Clothes(4, new List<int>() { 0, 1, 2 }, 130000),
                new Clothes(5, new List<int>() { 0, 1, 2 }, 80000),
                new Clothes(6, new List<int>() { 0, 1, 2 }, 70000),
                new Clothes(7, new List<int>() { 0, 1, 2 }, 90000),
                new Clothes(8, new List<int>() { 0, 1, 2 }, 70000),
                new Clothes(9, new List<int>() { 0, 1, 2 }, 80000),
                new Clothes(10, new List<int>() { 0, 1, 2 }, 30000),
                new Clothes(11, new List<int>() { 0 }, 6000),
                new Clothes(12, new List<int>() { 0 }, 6000),
                new Clothes(13, new List<int>() { 0 }, 10000),
                new Clothes(14, new List<int>() { 0 }, 8000),
                new Clothes(15, new List<int>() { 0 }, 15000),
                new Clothes(16, new List<int>() { 0 }, 15000),
                new Clothes(17, new List<int>() { 0 }, 13000),
                new Clothes(18, new List<int>() { 0, 1, 2, 3 }, 15000),

            }},
        };
        public static Dictionary<bool, List<Clothes>> Glasses = new Dictionary<bool, List<Clothes>>()
        {
            { true, new List<Clothes>(){
                new Clothes(1, new List<int>() { 1 }, 630),
                new Clothes(2, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 2000),
                new Clothes(3, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 2700),
                new Clothes(4, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 3000),
                new Clothes(5, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 9000),
                new Clothes(7, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 2700),
                new Clothes(8, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 6000),
                new Clothes(9, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 7500),
                new Clothes(10, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 9300),
                new Clothes(12, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 9900),
                new Clothes(13, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 6900),
                new Clothes(15, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 7500),
                new Clothes(16, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 3000),
                new Clothes(17, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 10500),
                new Clothes(18, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 12000),
                new Clothes(19, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 9300),
                new Clothes(20, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 7500),
                new Clothes(23, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 6000),
            }},
            { false, new List<Clothes>(){
                new Clothes(0, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 630),
                new Clothes(1, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 2000),
                new Clothes(2, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 2800),
                new Clothes(3, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 3000),
                new Clothes(4, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 6000),
                new Clothes(6, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 5400),
                new Clothes(7, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 6300),
                new Clothes(8, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 7500),
                new Clothes(9, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 9000),
                new Clothes(10, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 4500),
                new Clothes(11, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7 }, 7500),
                new Clothes(14, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 9000),
                new Clothes(16, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 6000),
                new Clothes(17, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 9600),
                new Clothes(18, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7 }, 6000),
                new Clothes(19, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 6000),
                new Clothes(20, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7 }, 4500),
                new Clothes(21, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7 }, 7500),
                new Clothes(24, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 7500),
                new Clothes(25, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 7500),
            }},
        };
        public static Dictionary<bool, List<Clothes>> Jewerly = new Dictionary<bool, List<Clothes>>()
        {
            { true, new List<Clothes>(){
                new Clothes(17, new List<int>() { 0,1,2 }, 15000),
                new Clothes(49, new List<int>() { 0,1 }, 21000),
                new Clothes(50, new List<int>() { 0,1 }, 3000),
                new Clothes(51, new List<int>() { 0 }, 2000),
                new Clothes(52, new List<int>() { 0,1 }, 3000),
                new Clothes(53, new List<int>() { 0,1 }, 3100),
                new Clothes(54, new List<int>() { 0,1 }, 3400),
                new Clothes(55, new List<int>() { 0,1 }, 4800),
                new Clothes(85, new List<int>() { 0,1 }, 21000),
                new Clothes(86, new List<int>() { 0,1 }, 21000),
                new Clothes(87, new List<int>() { 0,1 }, 21600),
                new Clothes(88, new List<int>() { 0,1 }, 18000),
                new Clothes(89, new List<int>() { 0,1 }, 22000),
                new Clothes(90, new List<int>() { 0,1 }, 25000),
                new Clothes(91, new List<int>() { 0,1 }, 26000),
                new Clothes(92, new List<int>() { 0,1 }, 22500),
                new Clothes(93, new List<int>() { 0,1 }, 22500),
                new Clothes(94, new List<int>() { 0,1 }, 23000),
                new Clothes(111, new List<int>() { 0,1 }, 39000),
                new Clothes(123, new List<int>() { 0,1 }, 45000),
                new Clothes(120, new List<int>() { 0,1 }, 36000),
                new Clothes(122, new List<int>() { 0,1 }, 33000),
            }},
            { false, new List<Clothes>(){
                new Clothes(6, new List<int>() { 0,1,2,3,4,5, }, 30000),
                new Clothes(7, new List<int>() { 0,1 }, 28000),
                new Clothes(11, new List<int>() { 0,1,2,3 }, 29000),
                new Clothes(12, new List<int>() { 0,1,2 }, 15000),
                new Clothes(36, new List<int>() { 0,1 }, 33000),
                new Clothes(37, new List<int>() { 0,1 }, 36000),
                new Clothes(38, new List<int>() { 0 }, 36000),
                new Clothes(39, new List<int>() { 0,1 }, 39000),
                new Clothes(40, new List<int>() { 0,1 }, 36000),
                new Clothes(41, new List<int>() { 0,1 }, 36000),
                new Clothes(42, new List<int>() { 0,1 }, 38000),
                new Clothes(64, new List<int>() { 0,1 }, 21000),
                new Clothes(65, new List<int>() { 0,1 }, 22000),
                new Clothes(66, new List<int>() { 0,1 }, 23000),
                new Clothes(67, new List<int>() { 0,1 }, 25000),
                new Clothes(68, new List<int>() { 0,1 }, 22800),
                new Clothes(69, new List<int>() { 0,1 }, 25000),
                new Clothes(70, new List<int>() { 0,1 }, 25000),
                new Clothes(71, new List<int>() { 0,1 }, 21000),
                new Clothes(72, new List<int>() { 0,1 }, 21000),
                new Clothes(73, new List<int>() { 0,1 }, 25000),
                new Clothes(82, new List<int>() { 0,1 }, 36000),
                new Clothes(90, new List<int>() { 0,1 }, 36000),
                new Clothes(92, new List<int>() { 0,1 }, 38000),
                new Clothes(93, new List<int>() { 0,1 }, 38000),
            }},
        };
        public static List<Clothes> Masks = new List<Clothes>()
        {
            new Clothes(111, new List<int>() { 0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25 }, 3500),
            new Clothes(51, new List<int>() { 0,1,2,3,4,5,6,7,8,9 }, 3500),
            new Clothes(54, new List<int>() { 0,1,2,3,4,5,6,7,8,9,10 }, 4000),
            new Clothes(118, new List<int>() { 0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25 }, 3500),
            new Clothes(119, new List<int>() { 0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24 }, 3700),
            new Clothes(57, new List<int>() { 0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21 }, 3500),
            new Clothes(58, new List<int>() { 0,1,2,3,4,5,6,7,8,9 }, 4000),
            new Clothes(117, new List<int>() { 0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20 }, 3500),
            new Clothes(52, new List<int>() { 0,1,2,3,4,5,6,7,8,9,10 }, 4000),
            new Clothes(53, new List<int>() { 0,1,2,3,4,5,6,7,8 }, 4000),
            new Clothes(113, new List<int>() { 0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21 }, 4500),
        };

        public static Dictionary<int, Tuple<bool, bool, bool>> MaskTypes = new Dictionary<int, Tuple<bool, bool, bool>>()
        {
            { 111, new Tuple<bool, bool, bool>(false, false, false) },
            { 51, new Tuple<bool, bool, bool>(false, false, false) },
            { 54, new Tuple<bool, bool, bool>(true, true, true) },
            { 118, new Tuple<bool, bool, bool>(true, true, true) },
            { 119, new Tuple<bool, bool, bool>(true, true, true) },
            { 57, new Tuple<bool, bool, bool>(true, true, true) },
            { 58, new Tuple<bool, bool, bool>(true, true, true) },
            { 117, new Tuple<bool, bool, bool>(true, true, true) },
            { 52, new Tuple<bool, bool, bool>(true, true, false) },
            { 53, new Tuple<bool, bool, bool>(true, true, false) },
            { 113, new Tuple<bool, bool, bool>(true, true, false) },
        };

        public static Dictionary<bool, Dictionary<int, int>> AccessoryRHand = new Dictionary<bool, Dictionary<int, int>>()
        {
            { true, new Dictionary<int, int>(){
                { 22, 0 },
                { 23, 1 },
                { 24, 2 },
                { 25, 3 },
                { 26, 4 },
                { 27, 5 },
                { 28, 6 },
                { 29, 7 },
            }},
            { false, new Dictionary<int, int>(){
                { 11, 7 },
                { 12, 8 },
                { 13, 9 },
                { 14, 10 },
                { 15, 11 },
                { 16, 12 },
                { 17, 13 },
                { 18, 14 },
            }},
        };

        public static Dictionary<NetHandle, PlayerCustomization> CustomPlayerData = new Dictionary<NetHandle, PlayerCustomization>();

        public static Vector3 CreatorCharPos = new Vector3(402.8664, -996.4108, -99.00027);
        public static Vector3 CreatorPos = new Vector3(402.8664, -997.5515, -98.5);
        public static Vector3 CameraLookAtPos = new Vector3(402.8664, -996.4108, -98.5);
        public static float FacingAngle = -185.0f;
        public static int DimensionID = 1;

        public static List<string> hair_style_female = new List<string>();
        public static List<string> hair_style_male = new List<string>();
        public static List<string> eye_colors = new List<string>();
        public static List<string> dad = new List<string>();
        public static List<string> mom = new List<string>();
        public static List<string> shape_mix_list = new List<string>();
        public CharCreator()
        {

            dad.Add("Benjamin");
            dad.Add("Daniel");
            dad.Add("Joshua");
            dad.Add("Noah");
            dad.Add("Andrew");
            dad.Add("Juan");
            dad.Add("Alex");
            dad.Add("Isaac");
            dad.Add("Evan");
            dad.Add("Ethan");
            dad.Add("Vincent");
            dad.Add("Angel");
            dad.Add("Diego");
            dad.Add("Adrian");
            dad.Add("Gabriel");
            dad.Add("Michael");
            dad.Add("Santiago");
            dad.Add("Kevin");
            dad.Add("Louis");
            dad.Add("Samuel");
            dad.Add("Anthony");
            dad.Add("Claude");
            dad.Add("Niko");
            dad.Add("John");

            mom.Add("Hannah");
            mom.Add("Aubrey");
            mom.Add("Jasmine");
            mom.Add("Gisele");
            mom.Add("Amelia");
            mom.Add("Isabella");
            mom.Add("Zoe");
            mom.Add("Ava");
            mom.Add("Camila");
            mom.Add("Violet");
            mom.Add("Sophia");
            mom.Add("Evelyn");
            mom.Add("Nicole");
            mom.Add("Ashley");
            mom.Add("Gracie");
            mom.Add("Brianna");
            mom.Add("Natalie");
            mom.Add("Olivia");
            mom.Add("Elizabeth");
            mom.Add("Charlotte");
            mom.Add("Emma");
            mom.Add("Misty");

            shape_mix_list.Add("Mãe - ~b~I~w~IIIIIIII ~w~- ~y~Pai");
            shape_mix_list.Add("Mãe - ~b~II~w~IIIIIII ~w~- ~y~Pai");
            shape_mix_list.Add("Mãe - ~b~III~w~IIIIII ~w~- ~y~Pai");
            shape_mix_list.Add("Mãe - ~b~IIII~w~IIIII ~w~- ~y~Pai");
            shape_mix_list.Add("Mãe - ~b~IIIII~w~IIII ~w~- ~y~Pai");
            shape_mix_list.Add("Mãe - ~b~IIIIII~w~III ~w~- ~y~Pai");
            shape_mix_list.Add("Mãe - ~b~IIIIIII~w~II ~w~- ~y~Pai");
            shape_mix_list.Add("Mãe - ~b~IIIIIIII~w~I ~w~- ~y~Pai");
            shape_mix_list.Add("Mãe - ~b~IIIIIIIII ~w~- ~y~Pai");

            hair_style_male.Add("0");
            hair_style_male.Add("1");
            hair_style_male.Add("2");
            hair_style_male.Add("3");
            hair_style_male.Add("4");
            hair_style_male.Add("5");
            hair_style_male.Add("6");
            hair_style_male.Add("7");
            hair_style_male.Add("8");
            hair_style_male.Add("9");
            hair_style_male.Add("10");
            hair_style_male.Add("11");
            hair_style_male.Add("12");
            hair_style_male.Add("13");
            hair_style_male.Add("14");
            hair_style_male.Add("15");
            hair_style_male.Add("16");
            hair_style_male.Add("17");
            hair_style_male.Add("18");
            hair_style_male.Add("19");
            hair_style_male.Add("20");
            hair_style_male.Add("21");
            hair_style_male.Add("22");
            hair_style_male.Add("24");
            hair_style_male.Add("25");
            hair_style_male.Add("26");
            hair_style_male.Add("27");
            hair_style_male.Add("28");
            hair_style_male.Add("29");
            hair_style_male.Add("30");
            hair_style_male.Add("31");
            hair_style_male.Add("32");
            hair_style_male.Add("33");
            hair_style_male.Add("34");
            hair_style_male.Add("35");
            hair_style_male.Add("36");
            hair_style_male.Add("37");
            hair_style_male.Add("38");
            hair_style_male.Add("39");
            hair_style_male.Add("40");
            hair_style_male.Add("41");
            hair_style_male.Add("42");
            hair_style_male.Add("43");
            hair_style_male.Add("44");
            hair_style_male.Add("45");
            hair_style_male.Add("46");
            hair_style_male.Add("47");
            hair_style_male.Add("48");
            hair_style_male.Add("49");
            hair_style_male.Add("50");
            hair_style_male.Add("51");
            hair_style_male.Add("52");
            hair_style_male.Add("53");
            hair_style_male.Add("54");
            hair_style_male.Add("55");
            hair_style_male.Add("56");
            hair_style_male.Add("57");
            hair_style_male.Add("58");
            hair_style_male.Add("59");
            hair_style_male.Add("60");
            hair_style_male.Add("61");
            hair_style_male.Add("62");
            hair_style_male.Add("63");
            hair_style_male.Add("64");
            hair_style_male.Add("65");
            hair_style_male.Add("66");
            hair_style_male.Add("67");
            hair_style_male.Add("68");
            hair_style_male.Add("69");
            hair_style_male.Add("70");
            hair_style_male.Add("71");
            hair_style_male.Add("72");
            hair_style_male.Add("73");


            hair_style_female.Add("0");
            hair_style_female.Add("1");
            hair_style_female.Add("2");
            hair_style_female.Add("3");
            hair_style_female.Add("4");
            hair_style_female.Add("5");
            hair_style_female.Add("6");
            hair_style_female.Add("7");
            hair_style_female.Add("8");
            hair_style_female.Add("9");
            hair_style_female.Add("10");
            hair_style_female.Add("11");
            hair_style_female.Add("12");
            hair_style_female.Add("13");
            hair_style_female.Add("14");
            hair_style_female.Add("15");
            hair_style_female.Add("16");
            hair_style_female.Add("17");
            hair_style_female.Add("18");
            hair_style_female.Add("19");
            hair_style_female.Add("20");
            hair_style_female.Add("21");
            hair_style_female.Add("22");
            hair_style_female.Add("23");
            hair_style_female.Add("25");
            hair_style_female.Add("26");
            hair_style_female.Add("27");
            hair_style_female.Add("28");
            hair_style_female.Add("29");
            hair_style_female.Add("30");
            hair_style_female.Add("31");
            hair_style_female.Add("32");
            hair_style_female.Add("33");
            hair_style_female.Add("34");
            hair_style_female.Add("35");
            hair_style_female.Add("36");
            hair_style_female.Add("37");
            hair_style_female.Add("38");
            hair_style_female.Add("39");
            hair_style_female.Add("40");
            hair_style_female.Add("41");
            hair_style_female.Add("42");
            hair_style_female.Add("43");
            hair_style_female.Add("44");
            hair_style_female.Add("45");
            hair_style_female.Add("46");
            hair_style_female.Add("47");
            hair_style_female.Add("48");
            hair_style_female.Add("49");
            hair_style_female.Add("50");
            hair_style_female.Add("51");
            hair_style_female.Add("52");
            hair_style_female.Add("53");
            hair_style_female.Add("54");
            hair_style_female.Add("55");
            hair_style_female.Add("56");
            hair_style_female.Add("57");
            hair_style_female.Add("58");
            hair_style_female.Add("59");
            hair_style_female.Add("60");
            hair_style_female.Add("61");
            hair_style_female.Add("62");
            hair_style_female.Add("63");
            hair_style_female.Add("64");
            hair_style_female.Add("65");
            hair_style_female.Add("66");
            hair_style_female.Add("67");
            hair_style_female.Add("68");
            hair_style_female.Add("69");
            hair_style_female.Add("70");
            hair_style_female.Add("71");
            hair_style_female.Add("72");
            hair_style_female.Add("73");
            hair_style_female.Add("74");
            hair_style_female.Add("75");
            hair_style_female.Add("76");
            hair_style_female.Add("77");

            eye_colors.Add("Green");
            eye_colors.Add("Emerald");
            eye_colors.Add("Light Blue");
            eye_colors.Add("Ocean Blue");
            eye_colors.Add("Light Brown");
            eye_colors.Add("Dark Brown");
            eye_colors.Add("Hazel");
            eye_colors.Add("Dark Gray");
            eye_colors.Add("Light Gray");
            eye_colors.Add("Pink");
            eye_colors.Add("Yellow");
            eye_colors.Add("Blackout");
            eye_colors.Add("Shades of Gray");
            eye_colors.Add("Tequila Sunrise");
            eye_colors.Add("Atomic");
            eye_colors.Add("Warp");
            eye_colors.Add("ECola");
            eye_colors.Add("Space Ranger");
            eye_colors.Add("Ying Yang");
            eye_colors.Add("Bullseye");
            eye_colors.Add("Lizard");
            eye_colors.Add("Dragon");
            eye_colors.Add("Extra Terrestrial");
            eye_colors.Add("Goat");
            eye_colors.Add("Smiley");
            eye_colors.Add("Possessed");
            eye_colors.Add("Demon");
            eye_colors.Add("Infected");
            eye_colors.Add("Alien");
            eye_colors.Add("Undead");
            eye_colors.Add("Zombie");

            NAPI.Util.ConsoleOutput(">> " + SAVE_DIRECTORY + Path.DirectorySeparatorChar + "");
        }

        #region Methods
        public static void LoadCharacter(Client player, string character_name)
        {
            if (CustomPlayerData.ContainsKey(player)) CustomPlayerData.Remove(player);

            using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
            {

                Mainpipeline.Open();
                MySqlCommand query = new MySqlCommand("SELECT * FROM `characters` WHERE `name` = '" + character_name + "' LIMIT 1;", Mainpipeline);

                using (MySqlDataReader reader = query.ExecuteReader())
                {

                    string data2txt = string.Empty;
                    string datatxt = string.Empty;

                    while (reader.Read())
                    {
                        //NAPI.Util.ConsoleOutput("teste");
                        //NAPI.Util.ConsoleOutput(reader.GetString("char"));
                        var character = NAPI.Util.FromJson(reader.GetString("char"));
                        //var bday = reader.GetString("bday");
                        //NAPI.Util.ConsoleOutput("teste2");
                        CustomPlayerData.Add(player, new PlayerCustomization());

                        //API.Util.ConsoleOutput("" + (byte)character.Parents.Father + " -- " + (byte)character.Parents.Mother + " -- " + (byte)character.Parents.SkinSimilarity + "");
                        CustomPlayerData[player].Parents.Mother = (byte)character.Parents.Mother;
                        CustomPlayerData[player].Parents.Father = (byte)character.Parents.Father;
                        CustomPlayerData[player].Parents.Similarity = character.Parents.Similarity;
                        CustomPlayerData[player].Parents.SkinSimilarity = character.Parents.SkinSimilarity;
                        CustomPlayerData[player].Gender = character.Gender;

                        CustomPlayerData[player].Hair.Hair = character.Hair.Hair;
                        CustomPlayerData[player].Hair.Color = character.Hair.Color;
                        CustomPlayerData[player].Hair.HighlightColor = character.Hair.HighlightColor;

                        CustomPlayerData[player].EyebrowColor = character.EyebrowColor;
                        CustomPlayerData[player].BeardColor = character.BeardColor;
                        CustomPlayerData[player].EyeColor = character.EyeColor;
                        CustomPlayerData[player].BlushColor = character.BlushColor;
                        CustomPlayerData[player].LipstickColor = character.LipstickColor;
                        CustomPlayerData[player].ChestHairColor = character.ChestHairColor;

                        CustomPlayerData[player].ChestHairColor = character.ChestHairColor;
                        CustomPlayerData[player].Tattoo = character.Tattoo;

                        for (int i = 0; i < CustomPlayerData[player].Features.Length; i++) CustomPlayerData[player].Features[i] = character.Features[i];


                        for (int i = 0; i < CustomPlayerData[player].Appearance.Length; i++)
                        {

                            CustomPlayerData[player].Appearance[i].Value = (byte)character.Appearance[i].Value;
                            CustomPlayerData[player].Appearance[i].Color = (byte)character.Appearance[i].Color;
                            CustomPlayerData[player].Appearance[i].Opacity = character.Appearance[i].Opacity;

                        }

                        

                        ApplyCharacter(player);

                        //NAPI.Util.ConsoleOutput("# Character Creator Loaded from SQL >> " + CustomPlayerData[player].ToString());
                        return;
                    }
                }
            }

            CustomPlayerData.Add(player, new PlayerCustomization());
            ApplyCharacter(player);
        }

        public static void ApplyCharacterPreview(Client player)
        {
            if (!CustomPlayerData.ContainsKey(player)) return;

            player.SetSharedData("CHARACTER_ONLINE_GENRE", Convert.ToInt32(CustomPlayerData[player].Gender));

            HeadBlend heahblend = new HeadBlend();
            heahblend.ShapeFirst = (byte)CustomPlayerData[player].Parents.Mother;
            heahblend.ShapeSecond = (byte)CustomPlayerData[player].Parents.Father;
            heahblend.ShapeThird = 0;
            heahblend.SkinFirst = (byte)CustomPlayerData[player].Parents.Mother;
            heahblend.SkinSecond = (byte)CustomPlayerData[player].Parents.Father;
            heahblend.SkinThird = 0;
            heahblend.ShapeMix = CustomPlayerData[player].Parents.Similarity;
            heahblend.SkinMix = CustomPlayerData[player].Parents.SkinSimilarity;
            heahblend.ThirdMix = 0;
            NAPI.Player.SetPlayerHeadBlend(player, heahblend);

            //player.SetDefaultClothes();
            player.SetClothes(2, CustomPlayerData[player].Hair.Hair, 0);

            NAPI.Player.SetPlayerHairColor(player, (byte)CustomPlayerData[player].Hair.Color, (byte)CustomPlayerData[player].Hair.HighlightColor);
            NAPI.Player.SetPlayerEyeColor(player, (byte)CustomPlayerData[player].EyeColor);

            for (int i = 0; i < CustomPlayerData[player].Features.Length; i++) NAPI.Player.SetPlayerFaceFeature(player, i, CustomPlayerData[player].Features[i]);
            for (int i = 0; i < CustomPlayerData[player].Appearance.Length; i++)
            {
                HeadOverlay headoverlay2 = new HeadOverlay();
                headoverlay2.Index = (byte)CustomPlayerData[player].Appearance[i].Value;
                headoverlay2.Color = (byte)CustomPlayerData[player].Appearance[i].Color;
                headoverlay2.SecondaryColor = (byte)CustomPlayerData[player].Appearance[i].Color;
                headoverlay2.Opacity = CustomPlayerData[player].Appearance[i].Opacity;
                NAPI.Player.SetPlayerHeadOverlay(player, i, headoverlay2);
            }

            player.SetSharedData("CustomCharacter", NAPI.Util.ToJson(CustomPlayerData[player]));
        }

        public static void ApplyCharacter(Client player)
        {
            if (!CustomPlayerData.ContainsKey(player)) return;

            //NAPI.Util.ConsoleOutput("applyCharacter >> 1");

            player.SetSharedData("CHARACTER_ONLINE_GENRE", Convert.ToInt32(CustomPlayerData[player].Gender));

            HeadBlend heahblend = new HeadBlend();
            heahblend.ShapeFirst = (byte)CustomPlayerData[player].Parents.Mother;
            heahblend.ShapeSecond = (byte)CustomPlayerData[player].Parents.Father;
            heahblend.ShapeThird = 0;
            heahblend.SkinFirst = (byte)CustomPlayerData[player].Parents.Mother;
            heahblend.SkinSecond = (byte)CustomPlayerData[player].Parents.Father;
            heahblend.SkinThird = 0;
            heahblend.ShapeMix = CustomPlayerData[player].Parents.Similarity;
            heahblend.SkinMix = CustomPlayerData[player].Parents.SkinSimilarity;
            heahblend.ThirdMix = 0;
            NAPI.Player.SetPlayerHeadBlend(player, heahblend);

            player.SetSkin((CustomPlayerData[player].Gender == 0) ? PedHash.FreemodeMale01 : PedHash.FreemodeFemale01);
            //player.SetDefaultClothes();
            player.SetClothes(2, CustomPlayerData[player].Hair.Hair, 0);

            NAPI.Player.SetPlayerHairColor(player, (byte)CustomPlayerData[player].Hair.Color, (byte)CustomPlayerData[player].Hair.HighlightColor);
            NAPI.Player.SetPlayerEyeColor(player, (byte)CustomPlayerData[player].EyeColor);

            for (int i = 0; i < CustomPlayerData[player].Features.Length; i++) NAPI.Player.SetPlayerFaceFeature(player, i, CustomPlayerData[player].Features[i]);
            for (int i = 0; i < CustomPlayerData[player].Appearance.Length; i++)
            {
                HeadOverlay headoverlay2 = new HeadOverlay();
                headoverlay2.Index = (byte)CustomPlayerData[player].Appearance[i].Value;
                headoverlay2.Color = (byte)CustomPlayerData[player].Appearance[i].Color;
                headoverlay2.SecondaryColor = (byte)CustomPlayerData[player].Appearance[i].Color;
                headoverlay2.Opacity = CustomPlayerData[player].Appearance[i].Opacity;
                NAPI.Player.SetPlayerHeadOverlay(player, i, headoverlay2);
            }
            player.SetSharedData("CustomCharacter", JsonConvert.SerializeObject(CustomPlayerData[player]));
        }

        public static void UpdateCharacter(Client player)
        {
            if (!CustomPlayerData.ContainsKey(player)) return;

            //NAPI.Util.ConsoleOutput("applyCharacter >> 1");

            player.SetSharedData("CHARACTER_ONLINE_GENRE", Convert.ToInt32(CustomPlayerData[player].Gender));

            HeadBlend heahblend = new HeadBlend();
            heahblend.ShapeFirst = (byte)CustomPlayerData[player].Parents.Mother;
            heahblend.ShapeSecond = (byte)CustomPlayerData[player].Parents.Father;
            heahblend.ShapeThird = 0;
            heahblend.SkinFirst = (byte)CustomPlayerData[player].Parents.Mother;
            heahblend.SkinSecond = (byte)CustomPlayerData[player].Parents.Father;
            heahblend.SkinThird = 0;
            heahblend.ShapeMix = CustomPlayerData[player].Parents.Similarity;
            heahblend.SkinMix = CustomPlayerData[player].Parents.SkinSimilarity;
            heahblend.ThirdMix = 0;
            NAPI.Player.SetPlayerHeadBlend(player, heahblend);

            player.SetClothes(2, CustomPlayerData[player].Hair.Hair, 0);

            NAPI.Player.SetPlayerHairColor(player, (byte)CustomPlayerData[player].Hair.Color, (byte)CustomPlayerData[player].Hair.HighlightColor);
            NAPI.Player.SetPlayerEyeColor(player, (byte)CustomPlayerData[player].EyeColor);

            for (int i = 0; i < CustomPlayerData[player].Features.Length; i++) NAPI.Player.SetPlayerFaceFeature(player, i, CustomPlayerData[player].Features[i]);
            for (int i = 0; i < CustomPlayerData[player].Appearance.Length; i++)
            {
                HeadOverlay headoverlay2 = new HeadOverlay();
                headoverlay2.Index = (byte)CustomPlayerData[player].Appearance[i].Value;
                headoverlay2.Color = (byte)CustomPlayerData[player].Appearance[i].Color;
                headoverlay2.SecondaryColor = (byte)CustomPlayerData[player].Appearance[i].Color;
                headoverlay2.Opacity = CustomPlayerData[player].Appearance[i].Opacity;
                NAPI.Player.SetPlayerHeadOverlay(player, i, headoverlay2);
            }

        }

        public static void SaveChar(Client player)
        {
            if (player.GetData("status") == true)
            {
                Main.CreateMySqlCommand("UPDATE `characters` SET `char` = '" + NAPI.Util.ToJson(CustomPlayerData[player]) + "' WHERE name = '" + NAPI.Data.GetEntityData(player, "character_name") + "';");
            }
        }

        public static void SendToCreator(Client player)
        {
            //NAPI.Util.ConsoleOutput("CreatorCharPos 1");
            player.SetData("Creator_PrevPos", player.Position);
            Random rnd = new Random();
            int random_world = rnd.Next(5, 500);
            player.Dimension = (uint)random_world;

            if (CustomPlayerData.ContainsKey(player))
            {
                //player.SetDefaultClothes();
                SetCreatorClothes(player, CustomPlayerData[player].Gender);
                SetDefaultFeatures(player, 0, true);
            }
            else
            {
                //player.SetDefaultClothes();
                CustomPlayerData.Add(player, new PlayerCustomization());
                SetDefaultFeatures(player, 0, true);
            }
            player.SetData("creator_outfit", 0);
            player.TriggerEvent("ps_SetCamera", 0);
            ShowPlayerCreator(player, true);
            DimensionID++;
        }

        public static void SendBackToWorld(Client player)
        {
            player.Dimension = 0;
            player.Position = new Vector3(-536.447, -219.6322, 37.64978);
            player.Rotation = new Vector3(0, 0, 211.0624);
            player.TriggerEvent("freeze", false);
            player.TriggerEvent("freezeEx", false);

            //player.TriggerEvent("reset_camera");
            player.ResetData("Creator_PrevPos");
        }

        public static void SetDefaultFeatures(Client player, int gender, bool reset = false)
        {
            //NAPI.Util.ConsoleOutput("reseta aqui #1");
            if (reset)
            {
                CustomPlayerData[player] = new PlayerCustomization();
                CustomPlayerData[player].Gender = gender;
                CustomPlayerData[player].Parents.Father = 0;
                CustomPlayerData[player].Parents.Mother = 21;
                CustomPlayerData[player].Parents.Similarity = (gender == 0) ? 1.0f : 0.0f;
                CustomPlayerData[player].Parents.SkinSimilarity = (gender == 0) ? 1.0f : 0.0f;
                CustomPlayerData[player].Hair.Hair = 0;
                CustomPlayerData[player].Hair.HighlightColor = 0;
                CustomPlayerData[player].Hair.Color = 0;
                CustomPlayerData[player].EyebrowColor = 0;
                CustomPlayerData[player].BeardColor = 0;
                CustomPlayerData[player].EyeColor = 0;
                CustomPlayerData[player].BlushColor = 0;
                CustomPlayerData[player].LipstickColor = 0;
                CustomPlayerData[player].ChestHairColor = 0;

                for (int i = 0; i < CustomPlayerData[player].Appearance.Length; i++)
                {
                    HeadOverlay headoverlay2 = new HeadOverlay();
                    headoverlay2.Index = 255;
                    headoverlay2.Color = 0;
                    headoverlay2.SecondaryColor = 0;
                    headoverlay2.Opacity = 1.0f;
                    NAPI.Player.SetPlayerHeadOverlay(player, i, headoverlay2);
                }
            }
            ApplyCharacter(player);
            SetCreatorClothes(player, gender);
        }

        public static void SetCreatorClothes(Client player, int gender)
        {
            if (!CustomPlayerData.ContainsKey(player)) return;

            // clothes
            //player.SetDefaultClothes();
            for (int i = 0; i < 10; i++) player.ClearAccessory(i);

            if (gender == 0)
            {
                player.SetClothes(3, 15, 0);
                player.SetClothes(4, 21, 0);
                player.SetClothes(6, 34, 0);
                player.SetClothes(8, 15, 0);
                player.SetClothes(11, 15, 0);
            }
            else
            {
                player.SetClothes(3, 15, 0);
                player.SetClothes(4, 10, 0);
                player.SetClothes(6, 35, 0);
                player.SetClothes(8, 15, 0);
                player.SetClothes(11, 15, 0);
            }

            player.SetClothes(2, CustomPlayerData[player].Hair.Hair, 0);
        }
        #endregion

        public static void SetHat(Client player, int variation, int texture)
        {
            player.SetAccessories(0, variation, texture);
            //player.SetSharedData("HAT_DATA", JsonConvert.SerializeObject(new List<int>() { variation, texture }));
        }

        public static void ClearClothes(Client player, bool gender)
        {
            if (gender)
            {
                player.SetClothes(3, 15, 0);
                player.SetClothes(4, 21, 0);
                player.SetClothes(6, 34, 0);
                player.SetClothes(8, 15, 0);
                player.SetClothes(11, 15, 0);
            }
            else
            {
                player.SetClothes(3, 15, 0);
                player.SetClothes(4, 15, 0);
                player.SetClothes(6, 35, 0);
                player.SetClothes(8, 15, 0);
                player.SetClothes(11, 15, 0);
            }

            player.SetClothes(1, 0, 0);
            SetHat(player, -1, 0);
            for (int i = 0; i <= 3; i++) player.ClearAccessory(i);

        }

        #region Events
        [ServerEvent(Event.ResourceStart)]
        public void OnResourceStart()
        {
            SAVE_DIRECTORY = NAPI.Resource.GetResourceFolder(this) + Path.DirectorySeparatorChar + SAVE_DIRECTORY;
            if (!Directory.Exists(SAVE_DIRECTORY)) Directory.CreateDirectory(SAVE_DIRECTORY);
        }

        public static void SaveCharacterFromCreation(Client player, String name)
        {
            if (!CustomPlayerData.ContainsKey(player)) return;
            if (player.HasData("ChangedGender")) player.ResetData("ChangedGender");

            // Sky Camera #09.04.2020
            //player.TriggerEvent("screenFadeOut", 2000);
            player.TriggerEvent("moveSkyCamera", player, "up", 1, false);

            NAPI.Task.Run(() =>
            {
                ApplyCharacter(player);
                Main.g_mysql_create_character(player, name, Convert.ToString(NAPI.Util.ToJson(CustomPlayerData[player])));
                SendBackToWorld(player);

                AccountManage.SaveCharacter(player);
            }, delayTime: 3000);

        }

        public static void UpdateVariables(Client player)
        {
            OnClientOnRangeChange(player, "range_base", player.GetData("temp_base").ToString());
            OnClientOnRangeChange(player, "range_base2", player.GetData("temp_base2").ToString());
            OnClientOnRangeChange(player, "range_baseblend", player.GetData("temp_baseblend").ToString());
            OnClientOnRangeChange(player, "range_skin", player.GetData("temp_skin").ToString());
            OnClientOnRangeChange(player, "range_eyes", player.GetData("temp_eyes").ToString());
            OnClientOnRangeChange(player, "range_hair", player.GetData("temp_hair").ToString());
            OnClientOnRangeChange(player, "range_haircolor", player.GetData("temp_haircolor").ToString());
            OnClientOnRangeChange(player, "range_haircolor2", player.GetData("temp_hairhighlightcolor").ToString());
            OnClientOnRangeChange(player, "range_eyebrows", player.GetData("temp_eyebrows").ToString());
            OnClientOnRangeChange(player, "range_beard", player.GetData("temp_beard").ToString());

            for (int i = 0; i < 20; i++)
            {
                OnClientSetFaceFeature(player, i, player.GetData("temp_facefeature_" + i));
            }

            OnClientSetTraje(player, player.GetData("temp_traje"));
        }
        // Main UI
        public static void ShowPlayerCreator(Client player, bool reset_variable = false)
        {
            if (reset_variable == true)
            {
                player.SetData("temp_base", 0);
                player.SetData("temp_base2", 0);
                player.SetData("temp_baseblend", 5);
                player.SetData("temp_skin", 5);
                player.SetData("temp_eyes", 0);
                player.SetData("temp_hair", 0);
                player.SetData("temp_haircolor", 0);
                player.SetData("temp_hairhighlightcolor", 0);
                player.SetData("temp_eyebrows", 0);
                player.SetData("temp_beard", 0);

                player.SetData("temp_top", 0);
                player.SetData("temp_pants", 0);
                player.SetData("temp_shoes", 0);

                player.SetData("temp_sex", 0);
                player.SetData("temp_traje", 0);

                player.SetData("temp_name", "");
                player.SetData("temp_second_name", "");

                for (int i = 0; i <= 20; i++)
                {
                    player.SetData("temp_facefeature_" + i, 10);
                }

            }

            List<dynamic> temp_array = new List<dynamic>();

            temp_array.Add(new
            {
                Forename = player.GetData("temp_name"),
                Surname = player.GetData("temp_second_name"),
                Gender = player.GetData("temp_sex"),
                Base = player.GetData("temp_base"),
                Base2 = player.GetData("temp_base2"),
                BaseBlend = player.GetData("temp_baseblend"),
                Skin = player.GetData("temp_skin"),
                Eyes = player.GetData("temp_eyes"),
                Hair = player.GetData("temp_hair"),
                HairColor = player.GetData("temp_haircolor"),
                HairHighlightColor = player.GetData("temp_hairhighlightcolor"),
                Eyebrows = player.GetData("temp_eyebrows"),
                Beard = player.GetData("temp_beard")
            });


            player.TriggerEvent("Show_Char_Creator", NAPI.Util.ToJson(temp_array));
            UpdateVariables(player);
        }

        // Menu UI 2
        public static void ShowPlayerCreator_2(Client player)
        {

            List<dynamic> temp_array = new List<dynamic>();

            for (int i = 0; i <= 20; i++)
            {
                temp_array.Add(new { FaceFeatures = player.GetData("temp_facefeature_" + i) });
            }

            player.TriggerEvent("Show_Char_Creator_2", NAPI.Util.ToJson(temp_array));
            UpdateVariables(player);
        }

        // Menu UI 3
        public static void ShowPlayerCreator_3(Client player)
        {

            List<dynamic> temp_array = new List<dynamic>();

            temp_array.Add(new
            {
                Traje = player.GetData("temp_traje"),
                Top = player.GetData("temp_top"),
                Pants = player.GetData("temp_pants"),
                Shoes = player.GetData("temp_shoes")
            });

            player.TriggerEvent("Show_Char_Creator_3", NAPI.Util.ToJson(temp_array));

            UpdateVariables(player);
        }

        [RemoteEvent("Display_Creator_part2")] // Display Chracter Menu UI 2
        public static void Events_Creator_Part2(Client player, string name, string forname)
        {
            player.SetData("temp_name", name);
            player.SetData("temp_second_name", forname);

            player.TriggerEvent("Destroy_Character_Menu");
            ShowPlayerCreator_2(player);
        }

        [RemoteEvent("Display_Creator_part1")] // Back to Main Chracter Menu UI
        public static void Events_Creator_Part1(Client player)
        {
            player.TriggerEvent("Destroy_Character_Menu");

            ShowPlayerCreator(player, true);
        }

        [RemoteEvent("Display_Creator_part3")] // Display Character Menu UI 3
        public static void Events_Creator_Part3(Client player)
        {
            player.TriggerEvent("Destroy_Character_Menu");
            ShowPlayerCreator_3(player);
        }


        [RemoteEvent("ClientCharCreation3Back")] // Display Character Menu UI 2
        public static void ClientCharCreation3Back(Client player)
        {
            player.TriggerEvent("Destroy_Character_Menu");
            ShowPlayerCreator_2(player);
        }

        [RemoteEvent("cameraPointTo")] // Display Character Menu UI 2
        public static void cameraPointTo(Client player, int type)
        {
            if (type == 1)
            {
                player.TriggerEvent("ps_SetCamera", 1);
            }
            else
            {
                player.TriggerEvent("ps_SetCamera", 0);
            }
        }

        [RemoteEvent("ClientSetFaceFeature")]
        public static void OnClientSetFaceFeature(Client player, int type, int valueIndex)
        {
            float new_value = 0.0f;
            switch (valueIndex)
            {
                case 0: new_value = -1.0f; break;
                case 1: new_value = -0.9f; break;
                case 2: new_value = -0.8f; break;
                case 3: new_value = -0.7f; break;
                case 4: new_value = -0.6f; break;
                case 5: new_value = -0.5f; break;
                case 6: new_value = -0.4f; break;
                case 7: new_value = -0.3f; break;
                case 8: new_value = -0.2f; break;
                case 9: new_value = -0.1f; break;
                case 10: new_value = 0.0f; break;
                case 11: new_value = -0.1f; break;
                case 12: new_value = -0.2f; break;
                case 13: new_value = -0.3f; break;
                case 14: new_value = -0.4f; break;
                case 15: new_value = -0.5f; break;
                case 16: new_value = -0.6f; break;
                case 17: new_value = -0.7f; break;
                case 18: new_value = -0.8f; break;
                case 19: new_value = -0.9f; break;
            }
            CustomPlayerData[player].Features[type] = new_value;
            NAPI.Player.SetPlayerFaceFeature(player, type, CustomPlayerData[player].Features[type]);
            player.SetData("temp_facefeature_" + type, valueIndex);
        }


        [RemoteEvent("ClientOnRangeChange")]
        public static void OnClientOnRangeChange(Client player, string type, string valueIndex)
        {
            //NAPI.Util.ConsoleOutput(""+ type + " --- "+ valueIndex + "");

            if (type == "range_gender")
            {
                int value = Convert.ToInt32(valueIndex);
                if (!CustomPlayerData.ContainsKey(player))
                {
                    return;
                }

                int sex = 0;
                if (value == 0)
                {
                    player.SetSkin(PedHash.FreemodeFemale01);
                    player.SetSharedData("CHARACTER_ONLINE_GENRE", 1);
                    sex = 1;
                }
                else if (value == 1)
                {
                    player.SetSkin(PedHash.FreemodeMale01);
                    player.SetSharedData("CHARACTER_ONLINE_GENRE", 0);
                    sex = 0;
                }


                player.SetData("ChangedGender", true);
                SetDefaultFeatures(player, sex, true);
                player.SetData("temp_sex", value);

                UpdateVariables(player);
            }
            else if (type == "range_base")
            {
                int value = Convert.ToInt32(valueIndex);
                CustomPlayerData[player].Parents.Mother = value + 20;
                ApplyCharacterPreview(player);
                player.SetData("temp_base", value);
            }
            else if (type == "range_base2")
            {
                int value = Convert.ToInt32(valueIndex);
                CustomPlayerData[player].Parents.Father = value;
                ApplyCharacterPreview(player);
                player.SetData("temp_base2", value);
            }
            else if (type == "range_baseblend")
            {
                int value = Convert.ToInt32(valueIndex);
                float new_value = 0.0f;
                if (value > 9) return;
                switch (value)
                {
                    case 0: new_value = 0.0f; break;
                    case 1: new_value = 0.1f; break;
                    case 2: new_value = 0.2f; break;
                    case 3: new_value = 0.3f; break;
                    case 4: new_value = 0.4f; break;
                    case 5: new_value = 0.5f; break;
                    case 6: new_value = 0.6f; break;
                    case 7: new_value = 0.7f; break;
                    case 8: new_value = 0.8f; break;
                    case 9: new_value = 0.9f; break;
                }
                CustomPlayerData[player].Parents.Similarity = new_value;
                ApplyCharacterPreview(player);
                player.SetData("temp_baseblend", value);
            }
            else if (type == "range_skin")
            {
                int value = Convert.ToInt32(valueIndex);
                if (value > 9) return;
                float new_value = 0.0f;
                switch (value)
                {
                    case 0: new_value = 0.0f; break;
                    case 1: new_value = 0.1f; break;
                    case 2: new_value = 0.2f; break;
                    case 3: new_value = 0.3f; break;
                    case 4: new_value = 0.4f; break;
                    case 5: new_value = 0.5f; break;
                    case 6: new_value = 0.6f; break;
                    case 7: new_value = 0.7f; break;
                    case 8: new_value = 0.8f; break;
                    case 9: new_value = 0.9f; break;
                }
                CustomPlayerData[player].Parents.SkinSimilarity = new_value;
                ApplyCharacterPreview(player);
                player.SetData("temp_skin", value);
            }
            else if (type == "range_eyes")
            {
                int value = Convert.ToInt32(valueIndex);
                CustomPlayerData[player].EyeColor = (byte)value;
                NAPI.Player.SetPlayerEyeColor(player, (byte)CustomPlayerData[player].EyeColor);
                player.SetData("temp_eyes", value);
            }
            else if (type == "range_hair")
            {
                int value = Convert.ToInt32(valueIndex);
                if (value > 72) return;
                if (player.GetSharedData("CHARACTER_ONLINE_GENRE") == 0)
                {
                    CustomPlayerData[player].Hair.Hair = Convert.ToInt32(hair_style_male[value]);
                    player.SetClothes(2, CustomPlayerData[player].Hair.Hair, 0);
                }
                else
                {
                    CustomPlayerData[player].Hair.Hair = Convert.ToInt32(hair_style_female[value]);
                    player.SetClothes(2, CustomPlayerData[player].Hair.Hair, 0);
                }
                player.SetData("temp_hair", value);
            }
            else if (type == "range_haircolor")
            {
                int value = Convert.ToInt32(valueIndex);
                if (value > 30) return;
                CustomPlayerData[player].Hair.Color = value;
                NAPI.Player.SetPlayerHairColor(player, (byte)CustomPlayerData[player].Hair.Color, (byte)CustomPlayerData[player].Hair.HighlightColor);
                player.SetData("temp_haircolor", value);
            }
            else if (type == "range_haircolor2")
            {
                int value = Convert.ToInt32(valueIndex);
                CustomPlayerData[player].Hair.HighlightColor = value;
                NAPI.Player.SetPlayerHairColor(player, (byte)CustomPlayerData[player].Hair.Color, (byte)CustomPlayerData[player].Hair.HighlightColor);
                player.SetData("temp_hairhighlightcolor", value);
            }
            else if (type == "range_beard")
            {
                int value = Convert.ToInt32(valueIndex);
                HeadOverlay headoverlay2 = new HeadOverlay();
                int index = 1;
                if (value == 0) CustomPlayerData[player].Appearance[index].Value = 255;
                else CustomPlayerData[player].Appearance[index].Value = value - 1;
                headoverlay2.Index = (byte)CustomPlayerData[player].Appearance[index].Value;
                headoverlay2.Color = (byte)CustomPlayerData[player].Appearance[index].Color;
                headoverlay2.Opacity = CustomPlayerData[player].Appearance[index].Opacity;
                NAPI.Player.SetPlayerHeadOverlay(player, index, headoverlay2);
                player.SetData("temp_beard", value);
            }
            else if (type == "range_eyebrows")
            {
                int value = Convert.ToInt32(valueIndex);
                HeadOverlay headoverlay2 = new HeadOverlay();
                int index = 2;
                if (value == 0) CustomPlayerData[player].Appearance[index].Value = 255;
                else CustomPlayerData[player].Appearance[index].Value = value - 1;
                headoverlay2.Index = (byte)CustomPlayerData[player].Appearance[index].Value;
                headoverlay2.Color = (byte)CustomPlayerData[player].Appearance[index].Color;
                headoverlay2.Opacity = CustomPlayerData[player].Appearance[index].Opacity;
                NAPI.Player.SetPlayerHeadOverlay(player, index, headoverlay2);
                player.SetData("temp_eyebrows", value);
            }
            else if (type == "range_rotation")
            {
                int value = Convert.ToInt32(valueIndex);
                player.Rotation = new Vector3(0, 0, float.Parse(valueIndex));
            }
            else if (type == "range_elevation")
            {

            }
        }

        [RemoteEvent("ClientSetTraje")]
        public static void OnClientSetTraje(Client player, int valueIndex)
        {
            player.SetData("creator_outfit", valueIndex);
            player.SetData("temp_traje", valueIndex);
            switch (valueIndex)
            {
                case 0:
                    {
                        if (player.GetSharedData("CHARACTER_ONLINE_GENRE") == 0)
                        {
                            player.SetClothes(3, 15, 0);
                            player.SetClothes(4, 21, 0);
                            player.SetClothes(6, 34, 0);
                            player.SetClothes(8, 15, 0);
                            player.SetClothes(11, 15, 0);
                        }
                        else
                        {
                            player.SetClothes(3, 15, 0);
                            player.SetClothes(4, 10, 0);
                            player.SetClothes(6, 35, 0);
                            player.SetClothes(8, 15, 0);
                            player.SetClothes(11, 15, 0);
                        }
                        break;
                    }
                case 1:
                    Outfits.SetUnisexOutfit(player, 1, true);
                    break;
                case 2:
                    Outfits.SetUnisexOutfit(player, 2, true);
                    break;
                case 3:
                    Outfits.SetUnisexOutfit(player, 3, true);
                    break;
                case 4:
                    Outfits.SetUnisexOutfit(player, 4, true);
                    break;
                case 5:
                    Outfits.SetUnisexOutfit(player, 5, true);
                    break;
                case 6:
                    Outfits.SetUnisexOutfit(player, 6, true);
                    break;
                case 7:
                    Outfits.SetUnisexOutfit(player, 7, true);
                    break;
                case 8:
                    Outfits.SetUnisexOutfit(player, 8, true);
                    break;
                case 9:
                    Outfits.SetUnisexOutfit(player, 9, true);
                    break;
                case 10:
                    Outfits.SetUnisexOutfit(player, 10, true);
                    break;
                case 11:
                    Outfits.SetUnisexOutfit(player, 11, true);
                    break;
                case 12:
                    Outfits.SetUnisexOutfit(player, 12, true);
                    break;
            }
        }

        [RemoteEvent("ClientCharCreationBack")]
        public static void ClientCharCreationBack(Client player)
        {
            player.TriggerEvent("Destroy_Character_Menu");
            AccountManage.CharacterSelection(player);
        }

        [RemoteEvent("ClientCharCreation3Next")]
        public static void Proccess_Character(Client player)
        {

            string inputtext = player.GetData("temp_name") + "_" + player.GetData("temp_second_name");

            if (inputtext.Length > 24)
            {
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Der Name muss zwischen 6 und 24 Zeichen enthalten.", 5000);
                return;
            }

            if (inputtext.Contains(" "))
            {
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Der Name darf keinen Namensraum haben!", 5000);
                return;
            }

            if (Utils.isRoleplayName(inputtext) == true)
            {
                using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
                {
                    Mainpipeline.Open();
                    MySqlCommand query = Mainpipeline.CreateCommand();
                    query.CommandType = CommandType.Text;
                    query.CommandText = "SELECT * FROM `characters` WHERE `name` = '" + inputtext + "'";
                    query.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    using (MySqlDataAdapter da = new MySqlDataAdapter(query))
                    {
                        da.Fill(dt);
                        int i = 0;
                        i = Convert.ToInt32(dt.Rows.Count.ToString());
                        if (i == 0)
                        {
                            player.TriggerEvent("Destroy_Character_Menu");
                            SaveCharacterFromCreation(player, inputtext);
                        }
                        else
                        {
                            NAPI.Notification.SendNotificationToPlayer(player, "Dieses Konto ist bereits vorhanden.Wählen Sie einen anderen Namen.");
                        }
                    }
                }

            }
            else
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Sie müssen einen Rollenspielnamen auswählen, zum Beispiel: ~y~John_Connor");
            }
        }

        [ServerEvent(Event.PlayerDisconnected)]
        public void OnPlayerDisconnected(Client player, DisconnectionType type, string reason)
        {
            if (CustomPlayerData.ContainsKey(player)) CustomPlayerData.Remove(player);
            //NAPI.Util.ConsoleOutput("[SPIELER]: Der Benutzer " + player.GetData("player_username") + " hat sich mit dem Charakter abgemeldet.");
        }

        [ServerEvent(Event.ResourceStop)]
        public void OnResourceStop()
        {
            foreach (Client player in NAPI.Pools.GetAllPlayers())
            {
                if (player.HasData("Creator_PrevPos"))
                {
                    player.Dimension = 0;
                    player.Position = (Vector3)NAPI.Data.GetEntityData(player, "Creator_PrevPos");
                    player.TriggerEvent("DestroyCamera");
                    player.ResetData("Creator_PrevPos");
                }
            }

            CustomPlayerData.Clear();
        }
        #endregion
    }
}