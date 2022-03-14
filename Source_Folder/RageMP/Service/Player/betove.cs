using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;
using Newtonsoft.Json;

class CanineSystem : Script
{

    public static int MAX_CANINE = 10;

    public class CanineEnum : IEquatable<CanineEnum>
    {
        public int id { get; set; }
        public bool in_use { get; set; }
        public string name { get; set; }
        public Client handle { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            CanineEnum objAsPart = obj as CanineEnum;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }
        public override int GetHashCode()
        {
            return id;
        }
        public bool Equals(CanineEnum other)
        {
            if (other == null) return false;
            return (this.id.Equals(other.id));
        }
    }

    public static List<CanineEnum> canineData = new List<CanineEnum>();
    public static List<dynamic> canine_animations = new List<dynamic>();

    public CanineSystem()
    {
        if (Main.CANINE_SYSTEM == true)
        {
            for (int i = 0; i < MAX_CANINE; i++)
            {
                canineData.Add(new CanineEnum
                {
                    id = i,
                    in_use = false,
                    name = null,
                    handle = null

                });
                /*canineData[i].id = i;
                canineData[i].in_use = false;
                canineData[i].name = null;
                canineData[i].handle = null;*/
            }

            canine_animations.Add(new { dictionary = "creatures@rottweiler@amb@sleep_in_kennel@", animation = "sleep_in_kennel", name = "Deitar", loop = true });
            canine_animations.Add(new { dictionary = "creatures@rottweiler@amb@world_dog_barking@idle_a", animation = "idle_a", name = "Latir", loop = true });
            canine_animations.Add(new { dictionary = "creatures@rottweiler@amb@world_dog_sitting@base", animation = "base", name = "Sentar", loop = true });
            canine_animations.Add(new { dictionary = "creatures@rottweiler@amb@world_dog_sitting@idle_a", animation = "idle_a", name = "Coceira", loop = false });
            //canine_animations.Add(new { dictionary = "creatures@rottweiler@indication@", animation = "indicate_high", name = "Chamar atenção", loop = true });
            //canine_animations.Add(new { dictionary = "creatures@rottweiler@melee@", animation = "dog_takedown_from_back", name = "Ataque",  });
            canine_animations.Add(new { dictionary = "creatures@rottweiler@melee@streamed_taunts@", animation = "taunt_02", name = "Provocar", loop = true });
            //canine_animations.Add(new { dictionary = "creatures@rottweiler@swim@", animation = "swim", name = "Nadar" });


           // NAPI.TextLabel.CreateTextLabel("- Polizist -~n~~n~~w~Drücke ~y~~h~E~h~~w~ fange / rette einen Polizeihund", new Vector3(469.9438, -985.1031, 30.6896 + 0.3), 12, 0.3500f, 4, new Color(74, 122, 255, 200));
           // NAPI.Marker.CreateMarker(27, new Vector3(469.9438, -985.1031, 30.6896 - 1.0), new Vector3(), new Vector3(), 0.8f, new Color(74, 122, 255, 200));

        }
    }

    //a_c_retriever / cachorro
    // a_c_pug / pug
    // a_c_shepherd / shepherd
    // a_c_husky / husky
    //a_c_cat_01 / cat

    [Command("guardaranimal")]
    public static void CMD_guardaranimal(Client player)
    {
        for (int i = 0; i < MAX_CANINE; i++)
        {
            if (canineData[i].handle != null && canineData[i].handle == player)
            {
                player.TriggerEvent("delete_canine", i);

                canineData[i].id = i;
                canineData[i].in_use = false;
                canineData[i].name = null;
                canineData[i].handle = null;

                Main.SendInfoMessage(player, "Du hast dein Haustier behalten.");
                return;
            }
        }
        NAPI.Notification.SendNotificationToPlayer(player, "Sie haben keine Haustiere bei sich.");
    }
    [Command("pegaranimal", "/pegaranimal [Tierart] ~c~(Tierart: ~w~retriever, pug, pastor, husky, cat~c~)")]
    public static void CMD_pegaranimal(Client player, string name)
    {

    /*    NAPI.Notification.SendNotificationToPlayer(player, "Sistema temporariamente desativado.");
        return;
        */
        if(player.GetData("character_cat") == 0)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben keinen Zugang zu Haustieren. Erfragen sie es beim Support. ");
            return;
        }
        for (int i = 0; i < MAX_CANINE; i++)
        {
            if (canineData[i].in_use == false)
            {
                if (name == "retriever")
                {
                    canineData[i].in_use = true;
                    canineData[i].name = "Retriever - " + AccountManage.GetCharacterName(player) + "";
                    canineData[i].handle = player;


                    var players = NAPI.Pools.GetAllPlayers();
                    foreach (var tagert in players)
                    {
                        tagert.TriggerEvent("create_canine", i, player, "a_c_retriever", player.Position, player);
                        tagert.TriggerEvent("create_canine_relationship_group");
                        tagert.TriggerEvent("update_canine_state", i, 1, canineData[i].handle);
                    }

                    Main.SendInfoMessage(player, "Sie haben Ihren Retriever gerufen, drücken Sie L, um ihn zu steuern. " + Main.EMBED_LIGHTGREEN + "Um es nach Hause zu schicken, verwenden Sie / guardaranimal.");
                }
                else if (name == "pug")
                {
                    canineData[i].in_use = true;
                    canineData[i].name = "Pug - " + AccountManage.GetCharacterName(player) + "";
                    canineData[i].handle = player;


                    var players = NAPI.Pools.GetAllPlayers();
                    foreach (var tagert in players)
                    {
                        tagert.TriggerEvent("create_canine", i, player, "a_c_pug", player.Position, player);
                        tagert.TriggerEvent("create_canine_relationship_group");
                        tagert.TriggerEvent("update_canine_state", i, 1, canineData[i].handle);
                    }

                    Main.SendInfoMessage(player, "Sie haben Ihren Mops gerufen, drücken Sie L, um ihn zu kontrollieren. " + Main.EMBED_LIGHTGREEN + "Um es nach Hause zu schicken, verwenden Sie / guardaranimal.");
                }
                else if (name == "pastor")
                {
                    canineData[i].in_use = true;
                    canineData[i].name = "Pastor - " + AccountManage.GetCharacterName(player) + "";
                    canineData[i].handle = player;


                    var players = NAPI.Pools.GetAllPlayers();
                    foreach (var tagert in players)
                    {
                        tagert.TriggerEvent("create_canine", i, player, "a_c_shepherd", player.Position, player);
                        tagert.TriggerEvent("create_canine_relationship_group");
                        tagert.TriggerEvent("update_canine_state", i, 1, canineData[i].handle);
                    }

                    Main.SendInfoMessage(player, "Sie haben Ihren Pastor gerufen, drücken Sie L, um ihn zu kontrollieren. " + Main.EMBED_LIGHTGREEN + "Um es nach Hause zu schicken, verwenden Sie / guardaranimal.");
                }
                else if (name == "husky")
                {
                    canineData[i].in_use = true;
                    canineData[i].name = "Husky - " + AccountManage.GetCharacterName(player) + "";
                    canineData[i].handle = player;


                    var players = NAPI.Pools.GetAllPlayers();
                    foreach (var tagert in players)
                    {
                        tagert.TriggerEvent("create_canine", i, player, "a_c_husky", player.Position, player);
                        tagert.TriggerEvent("create_canine_relationship_group");
                        tagert.TriggerEvent("update_canine_state", i, 1, canineData[i].handle);
                    }

                    Main.SendInfoMessage(player, "Sie haben Ihren Husky gerufen, drücken Sie L, um ihn zu kontrollieren.. " + Main.EMBED_LIGHTGREEN + "Um es nach Hause zu schicken, verwenden Sie / guardaranimal.");
                }
                else if (name == "cat")
                {
                    canineData[i].in_use = true;
                    canineData[i].name = "Cat - " + AccountManage.GetCharacterName(player) + "";
                    canineData[i].handle = player;


                    var players = NAPI.Pools.GetAllPlayers();
                    foreach (var tagert in players)
                    {
                        tagert.TriggerEvent("create_canine", i, player, "a_c_cat_01", player.Position, player);
                        tagert.TriggerEvent("create_canine_relationship_group");
                        tagert.TriggerEvent("update_canine_state", i, 1, canineData[i].handle);
                    }

                    Main.SendInfoMessage(player, "Sie haben Ihre Katze gerufen, drücken Sie L, um sie zu kontrollieren "+Main.EMBED_LIGHTGREEN + "Um es nach Hause zu schicken, verwenden Sie / guardaranimal.");

                }
                return;
            }
        }
    }

    public static void ShowCanineMenu(Client player, int index = 0)
    {
        int canine = 0;
        var can_pass = false;
        for (int i = 0; i < MAX_CANINE; i++)
        {
            if (canineData[i].handle != null && canineData[i].handle == player)
            {
                canine = i;
                can_pass = true;
            }
        }

        if (can_pass == false) return;

        player.SetData("listitem", index);
        List<string> actions = new List<string>();
        foreach (var animation in canine_animations)
        {
            actions.Add(animation.name);
        }


        List<dynamic> menu_item_list = new List<dynamic>();
        //menu_item_list.Add(new { Type = 6, Name = "Canine", Description = "", List = list, StartIndex = 0 });
        menu_item_list.Add(new { Type = 1, Name = "~c~1~s~ - Folge mir !", Description = "", RightLabel = "" });
        menu_item_list.Add(new { Type = 1, Name = "~c~2~s~ - Komm zu mir", Description = "", RightLabel = "" });
        menu_item_list.Add(new { Type = 1, Name = "~c~3~s~ - Bleib !", Description = "", RightLabel = "" });
        menu_item_list.Add(new { Type = 6, Name = "~c~4~s~ - Aktionen", Description = "", List = actions, StartIndex = player.GetData("listitem") });
        /*menu_item_list.Add(new { Type = 1, Name = "~c~5~s~ - Use /revistar [id ou parte do nome]", Description = "", RightLabel = "" });
        menu_item_list.Add(new { Type = 1, Name = "~c~6~s~ - Use /farejar [id ou parte do nome]", Description = "", RightLabel = "" });*/
        InteractMenu.CreateMenu(player, "Canine_Menu", "Animal", "~b~Kontrolliere dein " + canineData[canine].name + "", true, JsonConvert.SerializeObject(menu_item_list), false);
        //player.TriggerEvent("menu_handler_create_menu_generic", "Canine_Menu", "Animal", "~b~Kontrolliere dein " + canineData[canine].name + "", false, JsonConvert.SerializeObject(menu_item_list), "Seite", "Wechseln Sie zwischen den Seiten", 100);
    }



    public static void SelectMenuResponse(Client player, String callbackId, int selectedIndex, String objectName, String valueList)
    {
        if (callbackId == "Canine_Menu")
        {
            switch (selectedIndex)
            {
                case 0:
                    {
                        for (int i = 0; i < MAX_CANINE; i++)
                        {
                            if (canineData[i].handle != null && canineData[i].handle == player)
                            {

                                var players = NAPI.Pools.GetAllPlayers();
                                foreach (var tagert in players)
                                {


                                    tagert.TriggerEvent("update_canine_state", i, 1, canineData[i].handle);

                                }


                                ShowCanineMenu(player, player.GetData("listitem"));
                                return;
                            }
                        }

                        break;
                    }
                case 1:
                    {
                        for (int i = 0; i < MAX_CANINE; i++)
                        {
                            if (canineData[i].handle != null && canineData[i].handle == player)
                            {
                                //player.TriggerEvent("update_canine_state", i, 2, player);

                                var players = NAPI.Pools.GetAllPlayers();
                                foreach (var tagert in players)
                                {

                                    tagert.TriggerEvent("update_canine_state", i, 2, canineData[i].handle);

                                }

                                ShowCanineMenu(player, player.GetData("listitem"));
                                return;
                            }
                        }
                        break;
                    }
                case 2:
                    {
                        for (int i = 0; i < MAX_CANINE; i++)
                        {
                            if (canineData[i].handle != null && canineData[i].handle == player)
                            {
                                var players = NAPI.Pools.GetAllPlayers();
                                foreach (var tagert in players)
                                {

                                    tagert.TriggerEvent("update_canine_state", i, 0, canineData[i].handle);

                                }

                                ShowCanineMenu(player, player.GetData("listitem"));
                                return;
                            }
                        }
                        break;
                    }
                case 3:
                    {


                        for (int i = 0; i < MAX_CANINE; i++)
                        {
                            if (canineData[i].handle != null && canineData[i].handle == player)
                            {
                                //player.TriggerEvent("update_canine_state", i, 0, player.Position);

                                var players = NAPI.Pools.GetAllPlayers();
                                foreach (var tagert in players)
                                {

                                    tagert.TriggerEvent("play_canine_anim", i, canine_animations[player.GetData("listitem")].dictionary, canine_animations[player.GetData("listitem")].animation, canine_animations[player.GetData("listitem")].loop);

                                }


                                //NAPI.Notification.SendNotificationToPlayer(player,"oi " + canine_animations[player.GetData("listitem")].dictionary+", "+canine_animations[player.GetData("listitem")].name + "");
                                ShowCanineMenu(player, player.GetData("listitem"));
                                return;
                            }
                        }


                        break;
                    }
            }
        }
    }

    public static void ListItemMenuResponse(Client player, String callbackId, int selectedIndex, String objectName, String valueList, int valueIndex)
    {
        if (callbackId == "Canine_Menu")
        {
            if (selectedIndex == 3)
            {
                for (int i = 0; i < MAX_CANINE; i++)
                {
                    if (canineData[i].handle != null && canineData[i].handle == player)
                    {

                        var players = NAPI.Pools.GetAllPlayers();
                        foreach (var tagert in players)
                        {

                            tagert.TriggerEvent("play_canine_anim", i, canine_animations[valueIndex].dictionary, canine_animations[valueIndex].animation, canine_animations[valueIndex].loop);

                        }
                        return;
                    }
                }
            }
        }
    }

    public static void OnPlayerDisconnected(Client player)
    {
        for (int i = 0; i < MAX_CANINE; i++)
        {
            if (canineData[i].handle != null && canineData[i].handle == player)
            {
                //player.TriggerEvent("delete_canine", i);

                var players = NAPI.Pools.GetAllPlayers();
                foreach (var tagert in players)
                {
                    tagert.TriggerEvent("delete_canine", i);
                }

                canineData[i].id = i;
                canineData[i].in_use = false;
                canineData[i].name = null;
                canineData[i].handle = null;
            }
        }
    }

    [RemoteEvent("force_delete_canine")]
    public void ForceDeleteCanine(Client player, Client target)
    {
        for (int i = 0; i < MAX_CANINE; i++)
        {
            if (canineData[i].handle != null && canineData[i].handle == target)
            {
                var players = NAPI.Pools.GetAllPlayers();
                foreach (var tagert in players)
                {

                    tagert.TriggerEvent("delete_canine", i);

                }

                canineData[i].id = i;
                canineData[i].in_use = false;
                canineData[i].name = null;
                canineData[i].handle = null;
            }
        }
    }

    public static void KeyPressH(Client player)
    {
        ShowCanineMenu(player, 0);
    }

    public static void OnPlayerConnect(Client player)
    {
        for (int i = 0; i < MAX_CANINE; i++)
        {
            if (canineData[i].in_use == true)
            {

                var players = NAPI.Pools.GetAllPlayers();
                foreach (var tagert in players)
                {

                    tagert.TriggerEvent("create_canine", i, canineData[i].handle, "a_c_chop", canineData[i].handle.Position, canineData[i].handle);
                    tagert.TriggerEvent("create_canine_relationship_group");

                }

                return;
            }
        }
    }

    public static void OnPlayerDiscConnect(Client player)
    {
        for (int i = 0; i < MAX_CANINE; i++)
        {
            if (canineData[i].handle != null && canineData[i].handle == player)
            {
                var players = NAPI.Pools.GetAllPlayers();
                foreach (var tagert in players)
                {

                    player.TriggerEvent("delete_canine", i);

                }


                canineData[i].id = i;
                canineData[i].in_use = false;
                canineData[i].name = null;
                canineData[i].handle = null;

                Main.SendInfoMessage(player, "Sie haben Ihren ~g~Polizeihund~w~ erhalten.");
                return;
            }
        }
    }


    public static void PressKeyY(Client player)
    {
        if (FactionManage.GetPlayerGroupType(player) == 1)
        {
           /* NAPI.Notification.SendNotificationToPlayer(player, "Sistema temporariamente desativado.");
            return;*/
            for (int i = 0; i < MAX_CANINE; i++)
            {
                if (canineData[i].handle != null && canineData[i].handle == player)
                {
                    player.TriggerEvent("delete_canine", i);

                    canineData[i].id = i;
                    canineData[i].in_use = false;
                    canineData[i].name = null;
                    canineData[i].handle = null;

                    Main.SendInfoMessage(player, "Sie haben Ihren ~g~Polizeihund~w~ erhalten.");
                    return;
                }
            }

            for (int i = 0; i < MAX_CANINE; i++)
            {
                if (canineData[i].in_use == false)
                {
                    canineData[i].in_use = true;
                    canineData[i].name = "k9 - " + AccountManage.GetCharacterName(player) + "";
                    canineData[i].handle = player;

                    //player.TriggerEvent("create_canine", i, player, "a_c_chop", player.Position, player);
                    //player.TriggerEvent("create_canine_relationship_group");

                    var players = NAPI.Pools.GetAllPlayers();
                    foreach (var tagert in players)
                    {

                        //player.TriggerEvent("play_canine_anim", i, canine_animations[valueIndex].dictionary, canine_animations[valueIndex].animation, canine_animations[valueIndex].loop);
                        tagert.TriggerEvent("create_canine", i, player, "a_c_chop", player.Position, player);
                        tagert.TriggerEvent("create_canine_relationship_group");
                        tagert.TriggerEvent("update_canine_state", i, 1, canineData[i].handle);

                    }

                    Main.SendInfoMessage(player, "Sie haben einen ~g~Polizeihund~w~ abgeholt. Drücke ~y~L~w~ um ihn zu steuern.");

                    player.TriggerEvent("createNewHeadNotificationAdvanced", "Sie haben einen Polizeihund an die Leine genommen Drücke ~y~H~w~ um ihn zu steuern !");

                    return;
                }
            }
        }
        else Main.DisplaySubtitle(player, "ERROR: ~w~Sie sind nicht von einer Polizeiorganisation. !");
    }

}
