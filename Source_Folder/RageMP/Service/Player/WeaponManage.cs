using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Data;
using System.IO;
using GTANetworkAPI;
using MySql.Data.MySqlClient;

public class WeaponManage : Script
{
    public static int MAX_PLAYER_WEAPONS = 10;

    public static void SetPlayerWeaponEx(Client player, string Weapon_Name, int ammo)
    {
        var index = 0;
        int weapon_id = -1;
        foreach (var gun in Main.weapon_list)
        {
            if (gun.model.Contains(Weapon_Name) == true)
            {
                weapon_id = index;
                break;
            }
            index++;
        }

        if (weapon_id == -1)
        {
            //NAPI.Util.ConsoleOutput("(DEBUG: " + Weapon_Name + ") Não foi possível encontrar esta arma em nosso banco de dados.");
            return;
        }

        WeaponHash hashcode = NAPI.Util.WeaponNameToModel(Main.weapon_list[weapon_id].model);

        if (Main.weapon_list[weapon_id].classe == "Primary")
        {
            if (player.GetData("primary_weapon") == 0)  // First login fix ;
            {
                player.SetData("primary_ammunation", ammo);
                player.SetData("primary_weapon", hashcode);
                NAPI.Player.GivePlayerWeapon(player, player.GetData("primary_weapon"), player.GetData("primary_ammunation"));
                NAPI.Player.SetPlayerCurrentWeapon(player, player.GetData("primary_weapon"));
                NAPI.Player.SetPlayerWeaponAmmo(player, player.GetData("primary_weapon"), player.GetData("primary_ammunation"));
                return;
            }

            player.SetData("primary_ammunation", ammo);

            if ((int)player.GetData("primary_weapon") != (int)hashcode)
            {
                try
                {
                   // API.Shared.RemovePlayerWeapon(player, player.GetData("primary_weapon"));
                }
                catch
                {
                    API.Shared.ConsoleOutput("[ERROR]: Rückzug unmöglich: " + player.GetData("primary_weapon") + "");
                }

                player.SetData("primary_weapon", hashcode);
                NAPI.Player.GivePlayerWeapon(player, player.GetData("primary_weapon"), player.GetData("primary_ammunation"));
            }


            NAPI.Player.SetPlayerCurrentWeapon(player, player.GetData("primary_weapon"));
            NAPI.Player.SetPlayerWeaponAmmo(player, player.GetData("primary_weapon"), player.GetData("primary_ammunation"));
        }
        else if (Main.weapon_list[weapon_id].classe == "Secundary")
        {

            if (player.GetData("secundary_weapon") == 0)  // First login fix ;
            {
                player.SetData("secundary_ammunation", ammo);
                player.SetData("secundary_weapon", hashcode);
                NAPI.Player.GivePlayerWeapon(player, player.GetData("secundary_weapon"), player.GetData("primary_ammunation"));
                NAPI.Player.SetPlayerCurrentWeapon(player, player.GetData("secundary_weapon"));
                NAPI.Player.SetPlayerWeaponAmmo(player, player.GetData("secundary_weapon"), player.GetData("primary_ammunation"));
                return;
            }

            player.SetData("primary_ammunation", ammo);

            if ((int)player.GetData("secundary_weapon") != (int)hashcode)
            {
                try
                {
                   // API.Shared.RemovePlayerWeapon(player, player.GetData("secundary_weapon"));
                }
                catch
                {
                    API.Shared.ConsoleOutput("[ERROR]: Rückzug unmöglich: " + player.GetData("secundary_weapon") + "");
                }

                player.SetData("secundary_weapon", hashcode);
                NAPI.Player.GivePlayerWeapon(player, player.GetData("secundary_weapon"), player.GetData("primary_ammunation"));
            }


            NAPI.Player.SetPlayerCurrentWeapon(player, player.GetData("secundary_weapon"));
            NAPI.Player.SetPlayerWeaponAmmo(player, player.GetData("secundary_weapon"), player.GetData("primary_ammunation"));

        }
        else if (Main.weapon_list[weapon_id].classe == "Melee")
        {
            if (player.GetData("weapon_meele") == 0)  // First login fix ;
            {
                player.SetData("weapon_meele", hashcode);
                NAPI.Player.GivePlayerWeapon(player, player.GetData("weapon_meele"), 0);
                return;
            }

            if ((int)player.GetData("weapon_meele") != (int)hashcode)
            {
                try
                {
                    //API.Shared.RemovePlayerWeapon(player, player.GetData("weapon_meele"));
                }
                catch
                {
                    API.Shared.ConsoleOutput("[ERROR]: Rückzug unmöglich: " + player.GetData("weapon_meele") + "");
                }

                player.SetData("weapon_meele", hashcode);
                NAPI.Player.GivePlayerWeapon(player, player.GetData("weapon_meele"), 0);
            }

            NAPI.Player.SetPlayerCurrentWeapon(player, player.GetData("weapon_meele"));
        }
    }

    public static void OnPlayerConnect(Client player)
    {
        player.SetData("primary_weapon", 0);
        player.SetData("primary_ammunation", 0);
        player.SetData("secundary_weapon", 0);
        player.SetData("secundary_ammunation", 0);
        player.SetData("weapon_meele", 0);
    }

   /* [RemoteEvent("playerReload")]
    public void playerReload(Client player, int current, int ammo)
    {
        ////NAPI.Util.ConsoleOutput("reloading "+current+" -- "+ammo+"");
        WeaponHash weapon = NAPI.Player.GetPlayerCurrentWeapon(player);
        if (player.GetData("primary_weapon") == weapon)
        {

        }
        else if (player.GetData("primary_secundary") == weapon)
        {

        }
    }*/

    public static void GivePlayerWeaponEx(Client player, string Weapon_Name, int ammo)
    {
        var index = 0;
        int weapon_id = -1;
        foreach (var gun in Main.weapon_list)
        {
            if (gun.model.Contains(Weapon_Name) == true)
            {
                weapon_id = index;
                break;
            }
            index++;
        }

        if (weapon_id == -1)
        {
            //Main.DisplayErrorMessage(player, "Não foi possível encontrar esta arma em nosso banco de dados.");
            //NAPI.Util.ConsoleOutput("(DEBUG: "+ Weapon_Name + ") Wir konnten diese Waffe nicht in unserer Datenbank finden.");
            return;
        }

        //API.Util.ConsoleOutput(" "+ammo + " ");

        WeaponHash hashcode = NAPI.Util.WeaponNameToModel(Main.weapon_list[weapon_id].model);

        

        if (Main.weapon_list[weapon_id].classe == "Primary")
        {


            player.SetData("primary_ammunation", ammo + player.GetData("primary_ammunation"));


            int new_ammo = player.GetData("primary_ammunation");
            if (new_ammo > 250)
            {
                new_ammo = 250;
                player.SetData("primary_ammunation", 250);
            }

            player.SetData("primary_weapon", hashcode);
            player.SetData("primary_ammunation", new_ammo);
            player.TriggerEvent("wgive", (int)hashcode, player.GetData("primary_ammunation"), true);
            NAPI.Player.GivePlayerWeapon(player, (WeaponHash)player.GetData("primary_weapon"), player.GetData("primary_ammunation"));
            NAPI.Player.SetPlayerCurrentWeapon(player, (WeaponHash)player.GetData("primary_weapon"));
            NAPI.Player.SetPlayerCurrentWeaponAmmo(player, player.GetData("primary_ammunation"));
            AccountManage.SaveCharacter(player);
        }
        else if (Main.weapon_list[weapon_id].classe == "Secundary")
        {

            player.SetData("secundary_ammunation", ammo + player.GetData("primary_ammunation"));
            int new_ammo = player.GetData("primary_ammunation");
            if (new_ammo > 250)
            {
                new_ammo = 250;
                player.SetData("secundary_ammunation", 250);
            }

            player.SetData("secundary_weapon", hashcode);
            player.SetData("secundary_ammunation", new_ammo);
            player.TriggerEvent("wgive", (int)hashcode, player.GetData("primary_ammunation"), true);
            NAPI.Player.GivePlayerWeapon(player, (WeaponHash)player.GetData("secundary_weapon"), player.GetData("primary_ammunation"));
            NAPI.Player.SetPlayerCurrentWeapon(player, (WeaponHash)player.GetData("secundary_weapon"));
            NAPI.Player.SetPlayerCurrentWeaponAmmo(player, player.GetData("primary_ammunation"));
            AccountManage.SaveCharacter(player);
        }
        else if (Main.weapon_list[weapon_id].classe == "Melee")
        {
            player.TriggerEvent("wgive", (int)hashcode, 0, false);
            player.SetData("weapon_meele", hashcode);
            NAPI.Player.GivePlayerWeapon(player, (WeaponHash)player.GetData("weapon_meele"), 0);
            NAPI.Player.SetPlayerCurrentWeapon(player, (WeaponHash)player.GetData("weapon_meele"));
            NAPI.Player.SetPlayerCurrentWeaponAmmo(player, 0);
            AccountManage.SaveCharacter(player);

        }
    }


    [RemoteEvent("playerTakeoffWeapon")]
    public void playerTakeoffWeapon(Client player, int weaponHash, int ammo)
    {
        if (player.IsInVehicle) return;
        if (weaponHash == -1569615261) return;
        var index = 0;
        int weapon_id = -1;
        foreach (var gun in Main.weapon_list)
        {
            if (Convert.ToInt32(gun.hash) == weaponHash)
            {
                weapon_id = index;
                break;
            }
            index++;
        }

        if (weapon_id == -1)
        {
            //NAPI.Util.ConsoleOutput("(DEBUG: " + weapon_id + ") Wir konnten diese Waffe nicht in unserer Datenbank finden.");
            ////player.TriggerEvent("removeAllWeapons");
            ////NAPI.Player.RemoveAllPlayerWeapons(player);
            Main.DisplayErrorMessage(player, "Wir konnten diese Waffe nicht in unserer Datenbank finden.");
            return;
        }

        WeaponHash hashcode = NAPI.Util.WeaponNameToModel(Main.weapon_list[weapon_id].model);
        
        if (Main.weapon_list[weapon_id].classe == "Primary")
        {
            player.SetData("primary_ammunation", ammo);
        }
        else if (Main.weapon_list[weapon_id].classe == "Secundary")
        {
            player.SetData("secundary_ammunation", ammo);
        }
        else if (Main.weapon_list[weapon_id].classe == "Melee")
        {
            //player.SetData("weapon_meele", (int)hashcode);
        }

        if (player.GetData("handsup") == true)
        {
            // WeaponHash weapon = NAPI.Player.GetPlayerCurrentWeapon(player);
            //player.TriggerEvent("removeWeapon", (int)weapon);
            //player.TriggerEvent("removeAllWeapons");


            NAPI.Task.Run(() =>
            {
                //NAPI.Player.RemoveAllPlayerWeapons(player);
            }, delayTime: 500);
        }
    }

     [RemoteEvent("changeweap")]
     public static void OnPlayerWeaponChange(Client player, int type)
     {
         switch (type)
         {
             case 1:
                 {
                     if(player.IsInVehicle && player.VehicleSeat == -1 && player.Vehicle.Class == 18)
                     {
                        // player.TriggerEvent("SetSiren", 1, player.Vehicle);
                         return;
                     }

                     if ((WeaponHash)player.GetData("primary_weapon") == 0)
                     {
                         //player.TriggerEvent("removeAllWeapons");

                         NAPI.Task.Run(() =>
                         {
                             //NAPI.Player.RemoveAllPlayerWeapons(player);
                         }, delayTime: 500);


                         player.TriggerEvent("createNewHeadNotificationAdvanced", "Ops !~w~ Du hast keine Hauptwaffe zum Ausrüsten.");
                     }
                     else
                     {
                         if (player.GetData("handsup") == true)
                         {
                             return;
                         }

                         WeaponHash weapon = NAPI.Player.GetPlayerCurrentWeapon(player);

                        if ((WeaponHash)player.GetData("primary_weapon") == weapon)
                         {
                            //Inventory.GiveItemToInventory(player, (int)weapon, 1);
                            player.TriggerEvent("removeWeapon", (int)weapon);

                            NAPI.Task.Run(() =>
                             {
                                 //NAPI.Player.RemoveAllPlayerWeapons(player);
                                 //WeaponManage.RemoveAllWeaponEx(player);
                             }, delayTime: 500);

                             //player.TriggerEvent("createNewHeadNotificationAdvanced", "Você guardou~w~ sua arma ~y~primaria~w~ com ~b~" + player.GetData("primary_ammunation") + "~w~ munições!");

                         }
                         else
                         {
                             player.TriggerEvent("removeWeapon", (int)weapon);
                             NAPI.Task.Run(() =>
                             {
                                 //NAPI.Player.RemoveAllPlayerWeapons(player);
                             }, delayTime: 200);

                             NAPI.Task.Run(() =>
                             {
                                 player.TriggerEvent("wgive", (WeaponHash)player.GetData("primary_weapon"), (WeaponHash)player.GetData("primary_ammunation"), false);
                                 NAPI.Player.GivePlayerWeapon(player, NAPI.Data.GetEntityData(player, "primary_weapon"), player.GetData("primary_ammunation"));
                                 NAPI.Player.SetPlayerCurrentWeapon(player, NAPI.Data.GetEntityData(player, "primary_weapon"));
                                 NAPI.Player.SetPlayerCurrentWeaponAmmo(player, player.GetData("primary_ammunation"));
                             }, delayTime: 250);

                             player.TriggerEvent("createNewHeadNotificationAdvanced", "Du hast dich ~g~ausgestattet~w~ mit deine Waffe ~y~primär~w~ mit ~b~" + player.GetData("primary_ammunation") + "~w~ munition!");
                         }
                     }
                     break;
                 }
             case 2:
                 {
                     if (player.IsInVehicle && player.VehicleSeat == -1 && player.Vehicle.Class == 18)
                     {
                         //player.TriggerEvent("SetSiren", 2, player.Vehicle);
                         return;
                     }

                     if (NAPI.Data.GetEntityData(player, "secundary_weapon") == 0)
                     {
                         //player.TriggerEvent("removeAllWeapons");
                         NAPI.Task.Run(() =>
                         {
                             //NAPI.Player.RemoveAllPlayerWeapons(player);
                         }, delayTime: 200);

                         player.TriggerEvent("createNewHeadNotificationAdvanced", "Ops !~w~ Du hast keine Sekundärwaffen zum Ausrüsten.");
                     }
                     else
                     {
                         if (player.GetData("handsup") == true)
                         {
                             return;
                         }
                         WeaponHash weapon = NAPI.Player.GetPlayerCurrentWeapon(player);

                        if (NAPI.Data.GetEntityData(player, "secundary_weapon") == weapon)
                         {
                            //Inventory.GiveItemToInventory(player, (int)weapon, 1);
                            player.TriggerEvent("removeWeapon", (int)weapon);
                             NAPI.Task.Run(() =>
                             {
                                 //NAPI.Player.RemoveAllPlayerWeapons(player);
                                 //WeaponManage.RemoveAllWeaponEx(player);
                             }, delayTime: 200);

                             //player.TriggerEvent("createNewHeadNotificationAdvanced", "Você guardou~w~ sua arma ~y~secundaria~w~ com ~b~" + player.GetData("primary_ammunation") + "~w~ munições!");
                         }
                         else
                         {
                             player.TriggerEvent("removeWeapon", (int)weapon);
                             NAPI.Task.Run(() =>
                             {
                                 //NAPI.Player.RemoveAllPlayerWeapons(player);
                             }, delayTime: 200);

                             NAPI.Task.Run(() =>
                             {
                                 player.TriggerEvent("wgive", NAPI.Data.GetEntityData(player, "secundary_weapon"), player.GetData("primary_ammunation"), false);
                                 NAPI.Player.GivePlayerWeapon(player, NAPI.Data.GetEntityData(player, "secundary_weapon"), player.GetData("primary_ammunation"));
                                 NAPI.Player.SetPlayerCurrentWeapon(player, NAPI.Data.GetEntityData(player, "secundary_weapon"));
                                 NAPI.Player.SetPlayerCurrentWeaponAmmo(player, player.GetData("primary_ammunation"));
                             }, delayTime: 250);

                             NAPI.Notification.SendNotificationToPlayer(player, "Du hast dich ~g~ausgestattet~w~ mit deine Waffe ~y~primär~w~ mit ~b~" + player.GetData("primary_ammunation") + "~w~ munition!");
                         }
                     }
                     break;
                 }
             case 3:
                 {
                     if (player.IsInVehicle && player.VehicleSeat == -1 && player.Vehicle.Class == 18)
                     {
                         //player.TriggerEvent("SetSiren", 3, player.Vehicle);
                         return;
                     }

                     if (player.GetData("handsup") == true)
                     {
                         return;
                     }
                     if (NAPI.Data.GetEntityData(player, "weapon_meele") == 0)
                     {
                         //player.TriggerEvent("removeAllWeapons");
                         NAPI.Task.Run(() =>
                         {
                             //NAPI.Player.RemoveAllPlayerWeapons(player);
                         }, delayTime: 200);

                         player.TriggerEvent("createNewHeadNotificationAdvanced", "Ops !~w~ Sie haben keine leichten Waffen..");
                     }
                     else
                     {
                        WeaponHash weapon = NAPI.Player.GetPlayerCurrentWeapon(player);


                        if (NAPI.Data.GetEntityData(player, "weapon_meele") == weapon)
                         {
                            //Inventory.GiveItemToInventory(player, (int)weapon, 1);
                            player.TriggerEvent("removeWeapon", (int)weapon);
                             NAPI.Task.Run(() =>
                             {
                                 //NAPI.Player.RemoveAllPlayerWeapons(player);
                                 //WeaponManage.RemoveAllWeaponEx(player);
                             }, delayTime: 200);

                             //player.TriggerEvent("createNewHeadNotificationAdvanced", "Você guardou~w~ sua arma branca !");
                         }
                         else
                         {
                             player.TriggerEvent("removeWeapon", (int)weapon);
                             //NAPI.Player.RemoveAllPlayerWeapons(player);

                             NAPI.Task.Run(() =>
                             {
                                 player.TriggerEvent("wgive", NAPI.Data.GetEntityData(player, "weapon_meele"), 0, false);
                                 NAPI.Player.GivePlayerWeapon(player, NAPI.Data.GetEntityData(player, "weapon_meele"), 0);
                                 NAPI.Player.SetPlayerCurrentWeapon(player, NAPI.Data.GetEntityData(player, "weapon_meele"));
                             }, delayTime: 250);

                             player.TriggerEvent("createNewHeadNotificationAdvanced", "Du hast dich  ~g~ausgestattet~w~ deine leichte Waffe !");
                         }
                     }
                     break;
                 }
         }
     }


    [Command("dararma", "/dararma [id/PartOfName] [modelo] [munição(limite 250)]")]
      public void CMD_dararma(Client player, string idOrName, string name, int ammo)
      {
         if (AccountManage.GetPlayerAdmin(player) < 2)
         {
             NAPI.Notification.SendNotificationToPlayer(player, "Sie haben keine Berechtigung, diesen Befehl zu verwenden");
             return;
         }
         Client target = Main.findPlayer(player, idOrName);

         if (target != null)
         {
             var index = 0;
             int weapon_id = -1;
             foreach (var gun in Main.weapon_list)
             {
                 if (gun.model.Contains(name) == true)
                 {
                     weapon_id = index;
                     break;
                 }
                 index++;
             }

             if (weapon_id == -1)
             {
                 Main.DisplayErrorMessage(player, "Wir konnten diese Waffe nicht in unserer Datenbank finden.");
                 return;
             }

             int new_ammo = 0;

             if(ammo > 250)
             {
                 new_ammo = 250;
             }
             else
             {
                 new_ammo = ammo;
             }

             WeaponHash hashcode = NAPI.Util.WeaponNameToModel(Main.weapon_list[weapon_id].model);
             GivePlayerWeaponEx(target, name, new_ammo);
             if (Main.weapon_list[weapon_id].classe == "Melee")
             {
                 target.TriggerEvent("createNewHeadNotificationAdvanced", "Du hast eine ~y~" + Main.weapon_list[weapon_id].model + "~w~ des Administrators !");
                 NAPI.Notification.SendNotificationToPlayer(player,"Du hast das gegeben" + AccountManage.GetCharacterName(target) + "eins " + hashcode + ".");
             }
             else
             {
                 target.TriggerEvent("createNewHeadNotificationAdvanced", "Du hast eine ~y~" + Main.weapon_list[weapon_id].model + "~w~ mit~c~" + new_ammo + "~w~ Munition des Administrators !");
                 NAPI.Notification.SendNotificationToPlayer(player,"Du hast das gegeben " + AccountManage.GetCharacterName(target) + " eine " + hashcode + " " + (int)hashcode + " (" + weapon_id + ") mit " + new_ammo + " munition.");
             }
         }
      }

     public static void LoadPlayerWeapons(Client player)
     {
         using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
         {
             Mainpipeline.Open();
             MySqlCommand query = new MySqlCommand("SELECT * FROM `characters` WHERE `id` = '" + AccountManage.GetPlayerSQLID(player) + "';", Mainpipeline);
             using (MySqlDataReader reader = query.ExecuteReader())
             {

                 string data2txt = string.Empty;
                 string datatxt = string.Empty;

                 var index = 0;
                 while (reader.Read())
                 {


                     player.SetData("primary_ammunation", reader.GetInt32("primary_ammunation"));
                     player.SetData("secundary_ammunation", reader.GetInt32("secundary_ammunation"));

                     WeaponHash weapon_primary = NAPI.Util.WeaponNameToModel(reader.GetString("primary_weapon"));
                     WeaponHash weapon_secundary = NAPI.Util.WeaponNameToModel(reader.GetString("secundary_weapon"));
                     WeaponHash weapon_melee = NAPI.Util.WeaponNameToModel(reader.GetString("melee"));


                     if (reader.GetString("primary_weapon") != "0")
                     {

                         if (reader.GetInt32("primary_ammunation") == 0)
                         {
                            GivePlayerWeaponEx(player, Convert.ToString(weapon_primary), 1);
                            NAPI.Player.SetPlayerCurrentWeapon(player, weapon_primary);
                            NAPI.Player.SetPlayerCurrentWeaponAmmo(player, 1);
                        }
                         else
                         {
                             GivePlayerWeaponEx(player, Convert.ToString(weapon_primary), reader.GetInt32("primary_ammunation"));


                             //NAPI.Player.SetPlayerCurrentWeapon(player, player.GetData("primary_weapon"));
                             NAPI.Player.SetPlayerCurrentWeaponAmmo(player, player.GetData("primary_ammunation"));

                             NAPI.Task.Run(() =>
                             {
                                 NAPI.Player.SetPlayerCurrentWeaponAmmo(player, player.GetData("primary_ammunation"));
                             }, delayTime: 250);
                         }
                     }
                     else
                     {
                         player.SetData("primary_weapon", 0);
                         player.SetData("primary_ammunation", 0);
                     }

  
                     if (reader.GetString("secundary_weapon") != "0")
                     {
                         if (reader.GetInt32("secundary_ammunation") == 0)
                         {
                            GivePlayerWeaponEx(player, Convert.ToString(weapon_secundary), 1);
                            NAPI.Player.SetPlayerCurrentWeapon(player, weapon_secundary);
                            NAPI.Player.SetPlayerCurrentWeaponAmmo(player, 1);
                        }
                         else
                         {
                             GivePlayerWeaponEx(player, Convert.ToString(weapon_secundary), reader.GetInt32("secundary_ammunation"));
                             //NAPI.Player.SetPlayerCurrentWeapon(player, NAPI.Data.GetEntityData(player, "secundary_weapon"));
                             NAPI.Player.SetPlayerCurrentWeaponAmmo(player, player.GetData("primary_ammunation"));

                             NAPI.Task.Run(() =>
                             {
                                 NAPI.Player.SetPlayerCurrentWeaponAmmo(player, player.GetData("primary_ammunation"));
                             }, delayTime: 250);
                         }
                     }
                     else
                     {
                         player.SetData("secundary_weapon", 0);
                         player.SetData("secundary_ammunation", 0);
                     }

   
                     if (reader.GetString("melee") != "0")
                     {
                         GivePlayerWeaponEx(player, Convert.ToString(weapon_melee), 0);
                     }
                     else
                     {
                         player.SetData("weapon_meele", 0);
                     }
                     index++;

                 }
             }
         }
     }

     public static void SaveWeapons(Client player)
     {
         Main.CreateMySqlCommand("UPDATE characters SET `primary_weapon` = '" + Convert.ToString(player.GetData("primary_weapon")) + "', `primary_ammunation` = '" + Convert.ToString(player.GetData("primary_ammunation")) + "', `secundary_weapon` = '" + Convert.ToString(player.GetData("secundary_weapon")) + "', `secundary_ammunation` = '" + Convert.ToString(player.GetData("primary_ammunation")) + "',  `melee` = '" + Convert.ToString(player.GetData("weapon_meele")) + "' WHERE `id` = '" + AccountManage.GetPlayerSQLID(player) + "';");
     }

     public static void RemoveAllWeaponEx(Client player)
     {
         player.SetData("primary_weapon", 0);
         player.SetData("primary_ammunation", 0);
         player.SetData("secundary_weapon", 0);
         player.SetData("secundary_ammunation", 0);
         player.SetData("weapon_meele", 0);

         //player.TriggerEvent("removeAllWeapons");
         //NAPI.Player.RemoveAllPlayerWeapons(player);
     }

     /*[Command("checkweapon")]
     public void CheckGun(Client player)
     {
         WeaponHash hashcode = NAPI.Player.GetPlayerCurrentWeapon(player);
         NAPI.Notification.SendNotificationToPlayer(player, "You have a weapon with hash code " + (int)hashcode + "!");
         NAPI.Notification.SendNotificationToPlayer(player, "The weapon name is " + hashcode + "!");
     }*/
}
