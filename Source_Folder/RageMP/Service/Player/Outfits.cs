using System;
using System.Collections.Generic;
using System.Xml;
using GTANetworkAPI;

class Outfits : Script
{
    public class Outfit
    {
        public Tuple<int, int>[] Components { get; set; }
        public Tuple<int, int>[] Props { get; set; }
    }


    const int MaxComponent = 12;
    const int MaxProp = 9;
    static List<Outfit> MaleOutfits = new List<Outfit>();
    static List<Outfit> FemaleOutfits = new List<Outfit>();

    public static void OutfitTester_Init()
    {
        if (!System.IO.File.Exists("scriptmetadata.meta"))
        {
            //NAPI.Util.ConsoleOutput("OutfitTester doesn't work without scriptmetadata.meta!");
            //NAPI.Util.ConsoleOutput("Export it from \"update\\update.rpf\\common\\data\" using OpenIV.");
            return;
        }

        XmlDocument doc = new XmlDocument();
        doc.Load("scriptmetadata.meta");

        // 200IQ code incoming
        foreach (XmlNode node in doc.SelectNodes("/CScriptMetadata/MPOutfits/*/MPOutfitsData/Item"))
        {
            Outfit newOutfit = new Outfit
            {
                Components = new Tuple<int, int>[MaxComponent],
                Props = new Tuple<int, int>[MaxProp]
            };

            // Load components
            XmlNode components = node.SelectSingleNode("ComponentDrawables");
            XmlNode componentTextures = node.SelectSingleNode("ComponentTextures");

            for (int compID = 0; compID < MaxComponent; compID++)
            {
                newOutfit.Components[compID] = new Tuple<int, int>(Convert.ToInt32(components.ChildNodes[compID].Attributes["value"].Value), Convert.ToInt32(componentTextures.ChildNodes[compID].Attributes["value"].Value));
            }

            // Load props
            XmlNode props = node.SelectSingleNode("PropIndices");
            XmlNode propTextures = node.SelectSingleNode("PropTextures");

            for (int propID = 0; propID < MaxProp; propID++)
            {
                newOutfit.Props[propID] = new Tuple<int, int>(Convert.ToInt32(props.ChildNodes[propID].Attributes["value"].Value), Convert.ToInt32(propTextures.ChildNodes[propID].Attributes["value"].Value));
            }

            switch (node.ParentNode.ParentNode.Name)
            {
                case "MPOutfitsDataMale":
                    MaleOutfits.Add(newOutfit);
                    break;

                case "MPOutfitsDataFemale":
                    FemaleOutfits.Add(newOutfit);
                    break;

                default:
                    //NAPI.Util.ConsoleOutput("WTF?");
                    break;
            }
        }

        //NAPI.Util.ConsoleOutput("Loaded {0} outfits for FreemodeMale01.", MaleOutfits.Count);
        //NAPI.Util.ConsoleOutput("Loaded {0} outfits for FreemodeFemale01.", FemaleOutfits.Count);
    }


    [Command("settraje", "/settraje [id/PartOfName] [id(0 a 1299)]")]
    public void command_settraje(Client player, string idOrName, int value)
    {
        if (AccountManage.GetPlayerAdmin(player) < 1)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben keine Berechtigung, diesen Befehl zu.");
            return;
        }
        Client target = Main.findPlayer(player, idOrName);

        if (target != null)
        {
            if (target.GetData("status") != true)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Dieser Bürger ist nicht online.");
                return;
            }

            if (player != target) NAPI.Notification.SendNotificationToPlayer(player, "Du hast das gegeben ~y~" + AccountManage.GetCharacterName(target) + " der Zahlanzug " + value+".");
            else Main.SendInfoMessage(player, "Du hast von bekommen ~y~" + AccountManage.GetCharacterName(target) + " der Zahlanzug " + value + ".");


            SetUnisexOutfit(target, value, true);
        }
    }


    [Command("traje")]
    public void CMD_Outfit(Client player, int ID)
    {
        if (AccountManage.GetPlayerAdmin(player) < 1)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben keine Berechtigung, diesen Befehl zu verwenden.");
            return;
        }
        switch ((PedHash)player.Model)
        {
            case PedHash.FreemodeMale01:
                if (ID < 0 || ID >= MaleOutfits.Count)
                {
                    NAPI.Notification.SendNotificationToPlayer(player,"Invalid outfit ID, valid IDs: 0 - " + (MaleOutfits.Count - 1) + ".");
                    return;
                }

                for (int i = 0; i < MaxComponent; i++)
                {
                    if (i == 0) continue;
                    if (i == 2) continue;
                    player.SetClothes(i, MaleOutfits[ID].Components[i].Item1, MaleOutfits[ID].Components[i].Item2);
                }

                for (int i = 0; i < MaxProp; i++)
                {
                    player.ClearAccessory(i);
                    player.SetAccessories(i, MaleOutfits[ID].Props[i].Item1, MaleOutfits[ID].Props[i].Item2);
                }
                AccountManage.SaveCharacter(player);
                break;

            case PedHash.FreemodeFemale01:
                if (ID < 0 || ID >= FemaleOutfits.Count)
                {

                    NAPI.Notification.SendNotificationToPlayer(player,"Invalid outfit ID, valid IDs: 0 - " + (FemaleOutfits.Count - 1) + ".");
                    return;
                }

                for (int i = 0; i < MaxComponent; i++)
                {
                    if (i == 0) continue;
                    if (i == 2) continue;
                    player.SetClothes(i, FemaleOutfits[ID].Components[i].Item1, FemaleOutfits[ID].Components[i].Item2);
                }

                for (int i = 0; i < MaxProp; i++)
                {
                    player.ClearAccessory(i);
                    player.SetAccessories(i, FemaleOutfits[ID].Props[i].Item1, FemaleOutfits[ID].Props[i].Item2);
                }

                AccountManage.SaveCharacter(player);
                break;

            default:
                NAPI.Notification.SendNotificationToPlayer(player,"This command only works with FreemodeMale01 and FreemodeFemale01.");
                break;
        }
    }

    public static void SetMaleOutfit(Client player, int ID)
    {
        if (ID < 0 || ID >= MaleOutfits.Count)
        {
            NAPI.Notification.SendNotificationToPlayer(player,"Invalid outfit ID, valid IDs: 0 - " + (MaleOutfits.Count - 1) + ".");
            return;
        }

        for (int i = 0; i < MaxComponent; i++)
        {
            if (i == 0) continue;
            if (i == 2) continue;
            player.SetClothes(i, MaleOutfits[ID].Components[i].Item1, MaleOutfits[ID].Components[i].Item2);
        }

        for (int i = 0; i < MaxProp; i++)
        {
            player.ClearAccessory(i);
            player.SetAccessories(i, MaleOutfits[ID].Props[i].Item1, MaleOutfits[ID].Props[i].Item2);
        }
    }

    public static void SetFemaleOutfit(Client player, int ID)
    {
        if (ID < 0 || ID >= FemaleOutfits.Count)
        {

            NAPI.Notification.SendNotificationToPlayer(player,"Invalid outfit ID, valid IDs: 0 - " + (FemaleOutfits.Count - 1) + ".");
            return;
        }

        for (int i = 0; i < MaxComponent; i++)
        {
            if (i == 0) continue;
            if (i == 2) continue;
            player.SetClothes(i, FemaleOutfits[ID].Components[i].Item1, FemaleOutfits[ID].Components[i].Item2);
        }

        for (int i = 0; i < MaxProp; i++)
        {
            player.ClearAccessory(i);
            player.SetAccessories(i, FemaleOutfits[ID].Props[i].Item1, FemaleOutfits[ID].Props[i].Item2);
        }
    }

    public static void SetUnisexOutfit(Client player, int ID, bool save = false)
    {
        switch ((PedHash)player.Model)
        {
            case PedHash.FreemodeMale01:
                if (ID < 0 || ID >= MaleOutfits.Count)
                {
                    NAPI.Notification.SendNotificationToPlayer(player,"Invalid outfit ID, valid IDs: 0 - " + (MaleOutfits.Count - 1) + ".");
                    return;
                }

                for (int i = 0; i < MaxComponent; i++)
                {
                    if (i == 0) continue;
                    if (i == 1)
                    {
                        player.SetClothes(i, 0, 0);
                        if(save == true)
                        {
                            player.SetSharedData("character_mask", MaleOutfits[ID].Components[i].Item1);
                            player.SetSharedData("character_mask_texture", MaleOutfits[ID].Components[i].Item2);
                        }
                        continue;
                    }
                    if (i == 2) continue;
                    if (save == true)
                    {

                        if (i == 1)
                        {
                            player.SetSharedData("character_mask", MaleOutfits[ID].Components[i].Item1);
                            player.SetSharedData("character_mask_texture", MaleOutfits[ID].Components[i].Item2);
                        }
                        else if (i == 3)
                        {
                            player.SetSharedData("character_torso", MaleOutfits[ID].Components[i].Item1);
                            player.SetSharedData("character_torso_texture", MaleOutfits[ID].Components[i].Item2);
                        }
                        else if (i == 4)
                        {
                            player.SetSharedData("character_leg", MaleOutfits[ID].Components[i].Item1);
                            player.SetSharedData("character_leg_texture", MaleOutfits[ID].Components[i].Item2);
                        }
                        else if (i == 6)
                        {
                            player.SetSharedData("character_feet", MaleOutfits[ID].Components[i].Item1);
                            player.SetSharedData("character_feet_texture", MaleOutfits[ID].Components[i].Item2);
                        }
                        else if (i == 8)
                        {
                            player.SetSharedData("character_undershirt", MaleOutfits[ID].Components[i].Item1);
                            player.SetSharedData("character_undershirt_texture", MaleOutfits[ID].Components[i].Item2);
                        }
                        else if (i == 9)
                        {
                            player.SetSharedData("character_armor", MaleOutfits[ID].Components[i].Item1);
                            player.SetSharedData("character_armor_texture", MaleOutfits[ID].Components[i].Item2);
                        }
                        else if (i == 11)
                        {
                            player.SetSharedData("character_shirt", MaleOutfits[ID].Components[i].Item1);
                            player.SetSharedData("character_shirt_texture", MaleOutfits[ID].Components[i].Item2);
                        }
                    }
                    player.SetClothes(i, MaleOutfits[ID].Components[i].Item1, MaleOutfits[ID].Components[i].Item2);
                }

                for (int i = 0; i < MaxProp; i++)
                {
                    if (save == true)
                    {
                        if (i == 0)
                        {
                            player.SetSharedData("character_hats", FemaleOutfits[ID].Props[i].Item1);
                            player.SetSharedData("character_hats_texture", FemaleOutfits[ID].Props[i].Item2);
                        }
                        else if (i == 1)
                        {
                            player.SetSharedData("character_glasses", FemaleOutfits[ID].Props[i].Item1);
                            player.SetSharedData("character_glasses_texture", FemaleOutfits[ID].Props[i].Item2);
                        }
                        else if (i == 2)
                        {
                            player.SetSharedData("character_ears", FemaleOutfits[ID].Props[i].Item1);
                            player.SetSharedData("character_ears_texture", FemaleOutfits[ID].Props[i].Item2);
                        }
                        else if (i == 6)
                        {
                            player.SetSharedData("character_watches", FemaleOutfits[ID].Props[i].Item1);
                            player.SetSharedData("character_watches_texture", FemaleOutfits[ID].Props[i].Item2);
                        }
                        else if (i == 7)
                        {
                            player.SetSharedData("character_bracelets", FemaleOutfits[ID].Props[i].Item1);
                            player.SetSharedData("character_bracelets_texture", FemaleOutfits[ID].Props[i].Item2);
                        }
                    }
                    player.ClearAccessory(i);
                    player.SetAccessories(i, MaleOutfits[ID].Props[i].Item1, MaleOutfits[ID].Props[i].Item2);
                }
                
                break;

            case PedHash.FreemodeFemale01:
                if (ID < 0 || ID >= FemaleOutfits.Count)
                {

                    NAPI.Notification.SendNotificationToPlayer(player,"Invalid outfit ID, valid IDs: 0 - " + (FemaleOutfits.Count - 1) + ".");
                    return;
                }

                for (int i = 0; i < MaxComponent; i++)
                {
                    if (i == 0) continue;
                    if (i == 1)
                    {
                        player.SetClothes(i,0, 0);
                        continue;
                    }
                    if (i == 2) continue;
                    if (save == true)
                    {

                        if (i == 1)
                        {
                            player.SetSharedData("character_mask", FemaleOutfits[ID].Components[i].Item1);
                            player.SetSharedData("character_mask_texture", FemaleOutfits[ID].Components[i].Item2);
                        }
                        else if (i == 3)
                        {
                            player.SetSharedData("character_torso", FemaleOutfits[ID].Components[i].Item1);
                            player.SetSharedData("character_torso_texture", FemaleOutfits[ID].Components[i].Item2);
                        }
                        else if (i == 4)
                        {
                            player.SetSharedData("character_leg", FemaleOutfits[ID].Components[i].Item1);
                            player.SetSharedData("character_leg_texture", FemaleOutfits[ID].Components[i].Item2);
                        }
                        else if (i == 6)
                        {
                            player.SetSharedData("character_feet", FemaleOutfits[ID].Components[i].Item1);
                            player.SetSharedData("character_feet_texture", FemaleOutfits[ID].Components[i].Item2);
                        }
                        else if (i == 8)
                        {
                            player.SetSharedData("character_undershirt", FemaleOutfits[ID].Components[i].Item1);
                            player.SetSharedData("character_undershirt_texture", FemaleOutfits[ID].Components[i].Item2);
                        }
                        else if (i == 9)
                        {
                            player.SetSharedData("character_armor", FemaleOutfits[ID].Components[i].Item1);
                            player.SetSharedData("character_armor_texture", FemaleOutfits[ID].Components[i].Item2);
                        }
                        else if (i == 11)
                        {
                            player.SetSharedData("character_shirt", FemaleOutfits[ID].Components[i].Item1);
                            player.SetSharedData("character_shirt_texture", FemaleOutfits[ID].Components[i].Item2);
                        }
                    }
                    player.SetClothes(i, FemaleOutfits[ID].Components[i].Item1, FemaleOutfits[ID].Components[i].Item2);
                }

                for (int i = 0; i < MaxProp; i++)
                {
                    if (save == true)
                    {
                        if(i == 0)
                        {
                            player.SetSharedData("character_hats", FemaleOutfits[ID].Props[i].Item1);
                            player.SetSharedData("character_hats_texture", FemaleOutfits[ID].Props[i].Item2);
                        }
                        else if(i == 1)
                        {
                            player.SetSharedData("character_glasses", FemaleOutfits[ID].Props[i].Item1);
                            player.SetSharedData("character_glasses_texture", FemaleOutfits[ID].Props[i].Item2);
                        }
                        else if(i == 2)
                        {
                            player.SetSharedData("character_ears", FemaleOutfits[ID].Props[i].Item1);
                            player.SetSharedData("character_ears_texture", FemaleOutfits[ID].Props[i].Item2);
                        }
                        else if(i == 6)
                        {
                            player.SetSharedData("character_watches", FemaleOutfits[ID].Props[i].Item1);
                            player.SetSharedData("character_watches_texture", FemaleOutfits[ID].Props[i].Item2);
                        }
                        else if(i == 7)
                        {
                            player.SetSharedData("character_bracelets", FemaleOutfits[ID].Props[i].Item1);
                            player.SetSharedData("character_bracelets_texture", FemaleOutfits[ID].Props[i].Item2);
                        }
                    }
                    player.ClearAccessory(i);
                    player.SetAccessories(i, FemaleOutfits[ID].Props[i].Item1, FemaleOutfits[ID].Props[i].Item2);
                }
                break;

            default:
                NAPI.Notification.SendNotificationToPlayer(player,"This command only works with FreemodeMale01 and FreemodeFemale01.");
                break;
        }
    }

    public static void RemovePlayerDutyOutfit(Client player)
    {
        NAPI.Data.SetEntityData(player, "character_duty_outfit", -1);
        Main.UpdatePlayerClothes(player);
    }
}
    