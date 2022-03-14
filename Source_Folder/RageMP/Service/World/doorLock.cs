using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTANetworkAPI;
using DerStr1k3r.Core;

class DoorLock : Script
{

    public static int v_ilev_arm_secdoor, lspd_locker_room, main_to_cell_right, main_to_cell_left, lspd_captain_room, lspd_exit_cell, lspd_to_garage_right, lspd_to_garage_left, lspd_enter_cell_door, lspd_cell_door_1, lspd_cell_door_2, lspd_cell_door_3, lspd_roof, lspd_gate_door;
    public static int ls_custom_door;

    public static void DoorLockInit()
    {
        NAPI.Data.SetWorldData("prop_biolab_g_door", true);
        NAPI.Data.SetWorldData("lspd_locker_room", true);
        NAPI.Data.SetWorldData("main_to_cell", true);
        NAPI.Data.SetWorldData("lspd_captain_room", true);
        NAPI.Data.SetWorldData("lspd_exit_cell", true);
        NAPI.Data.SetWorldData("lspd_to_garage", true);
        NAPI.Data.SetWorldData("lspd_enter_cell_door", true);
        NAPI.Data.SetWorldData("lspd_cell_door_1", true);
        NAPI.Data.SetWorldData("lspd_cell_door_2", true);
        NAPI.Data.SetWorldData("lspd_cell_door_3", true);
        NAPI.Data.SetWorldData("lspd_roof", true);
        NAPI.Data.SetWorldData("DT1_19_Roofdoor_Dummy", true);
        //test
        NAPI.Data.SetWorldData("v_ilev_gtdoor", true);
        NAPI.Data.SetWorldData("v_ilev_ph_gendoor006", true);
        NAPI.Data.SetWorldData("V_ILev_PH_GenDoor002", true);
        NAPI.Data.SetWorldData("v_ilev_arm_secdoor", true);
        NAPI.Data.SetWorldData("slb2k11_glassdoor", true);
        NAPI.Data.SetWorldData("slb2k11_SECDOOR", true);
        //NAPI.Data.SetWorldData("DT1_19_Roofdoor_Dummy", true);

        SetDoorState(320433149, new Vector3(453.0793, -983.1894, 30.83926), false, 0); // lspd_locker_room
        NAPI.Data.SetWorldData("v_ilev_arm_secdoor", false);

        //SetDoorState(-1215222675, new Vector3(434.7479, -980.6184, 30.83926), false, 0); // lspd_locker_room
        //NAPI.Data.SetWorldData("prop_ch3_04_door_01r", false);

        SetDoorState(1557126584, new Vector3(-521.1828, -314.071686, 15.8747787), false, 0); // lspd_locker_room
        NAPI.Data.SetWorldData("prop_ch3_04_door_01r", false);

        SetDoorState(1557126584, new Vector3(-500.721924, -300.428009, 15.7205381), false, 0); // lspd_locker_room
        NAPI.Data.SetWorldData("ex_prop_door_arcad_roof_r", false);

        SetDoorState(1557126584, new Vector3(-498.339142, -299.401703, 15.7232008), false, 0); // lspd_locker_room
        NAPI.Data.SetWorldData("ex_prop_door_arcad_roof_r", false);

        SetDoorState(1557126584, new Vector3(-491.419403, -314.168884, 15.7061672), false, 0); // lspd_locker_room
        NAPI.Data.SetWorldData("ex_prop_door_arcad_roof_r", false);

        SetDoorState(1557126584, new Vector3(-491.019287, -317.899231, 15.7061672), false, 0); // lspd_locker_room
        NAPI.Data.SetWorldData("ex_prop_door_arcad_roof_r", false);

        SetDoorState(1557126584, new Vector3(-489.019073, -317.029114, 15.6951628), false, 0); // lspd_locker_room
        NAPI.Data.SetWorldData("ex_prop_door_arcad_roof_r", false);

        SetDoorState(1557126584, new Vector3(464.26660000, -984.02830000, 43.92001000), false, 0); // lspd_locker_room
        NAPI.Data.SetWorldData("DT1_19_Roofdoor_Dummy", false);

        // test
        SetDoorState(-1033001619, new Vector3(472.25, -996.65, 24.91), false, 0); // lspd_locker_room
        NAPI.Data.SetWorldData("v_ilev_gtdoor", false);

        SetDoorState(-1033001619, new Vector3(476.51, -996.65, 24.91), false, 0); // lspd_locker_room
        NAPI.Data.SetWorldData("v_ilev_gtdoor", false);

        SetDoorState(-1033001619, new Vector3(480.71, -996.65, 24.91), false, 0); // lspd_locker_room
        NAPI.Data.SetWorldData("v_ilev_gtdoor", false);

        SetDoorState(-1033001619, new Vector3(480.8, -1003.29, 24.91), false, 0); // lspd_locker_room
        NAPI.Data.SetWorldData("v_ilev_gtdoor", false);


        SetDoorState(-1033001619, new Vector3(476.33, -1003.29, 24.91), false, 0); // lspd_locker_room
        NAPI.Data.SetWorldData("v_ilev_gtdoor", false);

        SetDoorState(-1033001619, new Vector3(472.22, -1003.29, 24.91), false, 0); // lspd_locker_room
        NAPI.Data.SetWorldData("v_ilev_gtdoor", false);

        SetDoorState(-131296141, new Vector3(463.65, -981.33, 24.91), false, 0); // lspd_locker_room
        NAPI.Data.SetWorldData("v_ilev_ph_gendoor006", false);

        SetDoorState(-131296141, new Vector3(471.15, -985.32, 24.91), false, 0); // lspd_locker_room
        NAPI.Data.SetWorldData("v_ilev_ph_gendoor006", false);

        SetDoorState(-543497392, new Vector3(446.20, -986.94, 26.7), false, 0); //lspd_gate_door
        NAPI.Data.SetWorldData("v_ilev_ph_gendoor003", false);

        SetDoorState(-1033001619, new Vector3(446.21, -999.04, 30.7), false, 0); // lspd_locker_room
        NAPI.Data.SetWorldData("v_ilev_gtdoor", false);

        SetDoorState(-1033001619, new Vector3(445.56, -999.04, 30.7), false, 0); //lspd_gate_door
        NAPI.Data.SetWorldData("v_ilev_gtdoor", false);

        SetDoorState(-131296141, new Vector3(468.43, -978.15, 24.91), false, 0); //lspd_gate_door
        NAPI.Data.SetWorldData("v_ilev_ph_gendoor006", false);

        // LS Custom
        SetDoorState(-550347177, new Vector3(-356.0905, -134.7714, 40.01295), false, 0);

        // Discount Store
        SetDoorState(-1148826190, new Vector3(82.38156, -1390.476, 29.52609), false, 0);
        SetDoorState(868499217, new Vector3(82.38156, -1390.752, 29.52609), false, 0);


        // Premium Delux
        SetDoorState(1417577297, new Vector3(-37.33113, -1108.873, 26.7198), false, 0);
        SetDoorState(2059227086, new Vector3(-39.13366, -1108.218, 26.7198), false, 0);
        SetDoorState(1417577297, new Vector3(-60.54582, -1094.749, 26.88872), false, 0);
        SetDoorState(2059227086, new Vector3(-59.89302, -1092.952, 26.88362), false, 0);
        SetDoorState(-2051651622, new Vector3(-33.80989, -1107.579, 26.57225), false, 0);
        SetDoorState(-2051651622, new Vector3(-31.72353, -1101.847, 26.57225), false, 0);

        // LSPD Main door
        SetDoorState(320433149, new Vector3(434.7479, -983.2151, 30.83926), false, 0);
        SetDoorState(-1215222675, new Vector3(434.7479, -980.6184, 30.83926), false, 0);
    }
    [Command("door")]
    public void CMD_door(Client player)
    {
        if(FactionManage.GetPlayerGroupType(player) == 1 || AccountManage.GetPlayerGroup(player) == 25)
        {
            DoorLSPDInteract(player);
        }
        if (Inventory.GetPlayerItemFromInventory(player, 69) >= 1)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Das Türschloss wird gerade geknackt... Bitte warten...");
            NAPI.Task.Run(() =>
            {
                DoorLSPDInteract(player);
            }, delayTime: 10000);  
        }
    }

    public static void SetDoorState(int model, Vector3 position, bool locked, int handling)
    {
        foreach(var target in NAPI.Pools.GetAllPlayers())
        {
            if(target.GetData("status") == true)
            {
                target.TriggerEvent("doorLock", model, position, locked, handling);
            }
        }
    }

    public static void DoorLSPDInteract(Client player)
    {
       if (Main.IsInRangeOfPoint(player.Position, new Vector3(449.6888, -986.5193, 30.6896), 2.0f))
        {
            if (NAPI.Data.GetWorldData("lspd_locker_room") == true)
            {
                SetDoorState(1557126584, new Vector3(449.6888, -986.5193, 30.6896), false, 0); // lspd_locker_room
                NAPI.Data.SetWorldData("lspd_locker_room", false);
                NAPI.Notification.SendNotificationToPlayer(player, "Du hast die Tür ~g~geöffnet~w~.");
            }
            else
            {
                SetDoorState(1557126584, new Vector3(449.6888, -986.5193, 30.6896), true, 0);
                NAPI.Data.SetWorldData("lspd_locker_room", true);
                NAPI.Notification.SendNotificationToPlayer(player, "Du hast die Tür geschlossen~w~.");
            }
        }
        else if (Main.IsInRangeOfPoint(player.Position, new Vector3(444.2534, -989.4843, 30.6896), 2.0f))
        {
            if (NAPI.Data.GetWorldData("main_to_cell") == true)
            {
                SetDoorState(185711165, new Vector3(444.2534, -989.4843, 30.6896), false, 0); // main_to_cell_right
                SetDoorState(185711165, new Vector3(445.2322, -989.5842, 30.68959), false, 0); // main_to_cell_left
                NAPI.Data.SetWorldData("main_to_cell", false);
                NAPI.Notification.SendNotificationToPlayer(player, "Du hast die Tür ~g~geöffnet~w~.");
            }
            else
            {
                SetDoorState(185711165, new Vector3(444.2534, -989.4843, 30.6896), true, 0);
                SetDoorState(185711165, new Vector3(445.2322, -989.5842, 30.68959), true, 0);
                NAPI.Data.SetWorldData("main_to_cell", true);
                NAPI.Notification.SendNotificationToPlayer(player, "Du hast die Tür geschlossen~w~.");
            }
        }
        else if (Main.IsInRangeOfPoint(player.Position, new Vector3(447.1939, -979.9949, 30.68959), 2.0f))
        {
            if (NAPI.Data.GetWorldData("lspd_captain_room") == true)
            {
                SetDoorState(-1320876379, new Vector3(447.1939, -979.9949, 30.68959), false, 0); // lspd_captain_room
                //NAPI.Exported.doormanager.setDoorState(lspd_captain_room, false, 0);
                NAPI.Data.SetWorldData("lspd_captain_room", false);
                NAPI.Notification.SendNotificationToPlayer(player, "Du hast die Tür ~g~geöffnet~w~.");
            }
            else
            {
                //NAPI.Exported.doormanager.setDoorState(lspd_captain_room, true, 0); //lspd_captain_room
                SetDoorState(-1320876379, new Vector3(447.1939, -979.9949, 30.68959), true, 0);
                NAPI.Data.SetWorldData("lspd_captain_room", true);
                NAPI.Notification.SendNotificationToPlayer(player, "Du hast die Tür geschlossen~w~.");
            }
        }
        else if (Main.IsInRangeOfPoint(player.Position, new Vector3(453.0793, -983.1894, 30.83926), 2.0f))
        {
            if (NAPI.Data.GetWorldData("v_ilev_arm_secdoor") == true)
            {
                SetDoorState(749848321, new Vector3(453.0793, -983.1894, 30.83926), false, 0); // lspd_captain_room
                //NAPI.Exported.doormanager.setDoorState(lspd_captain_room, false, 0);
                NAPI.Data.SetWorldData("v_ilev_arm_secdoor", false);
                NAPI.Notification.SendNotificationToPlayer(player, "Du hast die Tür ~g~geöffnet~w~.");
            }
            else
            {
                //NAPI.Exported.doormanager.setDoorState(lspd_captain_room, true, 0); //lspd_captain_room
                SetDoorState(749848321, new Vector3(453.0793, -983.1894, 30.83926), true, 0);
                NAPI.Data.SetWorldData("v_ilev_arm_secdoor", true);
                NAPI.Notification.SendNotificationToPlayer(player, "Du hast die Tür geschlossen~w~.");
            }
        }
        else if (Main.IsInRangeOfPoint(player.Position, new Vector3(463.9265, -1003.572, 24.91487), 2.0f))
        {
            if (NAPI.Data.GetWorldData("lspd_exit_cell") == true)
            {
                SetDoorState(-1033001619, new Vector3(463.9265, -1003.572, 24.91487), false, 0); // lspd_exit_cell
                NAPI.Data.SetWorldData("lspd_exit_cell", false);
                NAPI.Notification.SendNotificationToPlayer(player, "Du hast die Tür ~g~geöffnet~w~.");
            }
            else
            {
                SetDoorState(-1033001619, new Vector3(463.9265, -1003.572, 24.91487), true, 0); 
                NAPI.Data.SetWorldData("lspd_exit_cell", true);
                NAPI.Notification.SendNotificationToPlayer(player, "Du hast die Tür geschlossen~w~.");
            }
        }
        else if (Main.IsInRangeOfPoint(player.Position, new Vector3(468.0155, -1014.855, 26.38639), 2.0f))
        {
            if (NAPI.Data.GetWorldData("lspd_to_garage") == true)
            {
                SetDoorState(-2023754432, new Vector3(468.0155, -1014.855, 26.38639), false, 0); // lspd_to_garage
                SetDoorState(-2023754432, new Vector3(469.3621, -1014.649, 26.3864), false, 0);
                NAPI.Data.SetWorldData("lspd_to_garage", false);
                NAPI.Notification.SendNotificationToPlayer(player, "Du hast die Tür ~g~geöffnet~w~.");
            }
            else
            {
                SetDoorState(-2023754432, new Vector3(468.0155, -1014.855, 26.38639), true, 0);
                SetDoorState(-2023754432, new Vector3(469.3621, -1014.649, 26.3864), true, 0);
                NAPI.Data.SetWorldData("lspd_to_garage", true);
                NAPI.Notification.SendNotificationToPlayer(player, "Du hast die Tür geschlossen~w~.");
            }
        }
        else if (Main.IsInRangeOfPoint(player.Position, new Vector3(464.5701, -992.6641, 25.06443), 2.0f))
        {
            if (NAPI.Data.GetWorldData("lspd_enter_cell_door") == true)
            {
                SetDoorState(631614199, new Vector3(464.5701, -992.6641, 25.06443), false, 0); //lspd_enter_cell_door
                NAPI.Data.SetWorldData("lspd_enter_cell_door", false);
                NAPI.Notification.SendNotificationToPlayer(player, "Du hast die Tür ~g~geöffnet~w~.");
            }
            else
            {
                SetDoorState(631614199, new Vector3(464.5701, -992.6641, 25.06443), true, 0); // lspd_enter_cell_door
                NAPI.Data.SetWorldData("lspd_enter_cell_door", true);
                NAPI.Notification.SendNotificationToPlayer(player, "Du hast die Tür geschlossen~w~.");
            }
        }
        else if (Main.IsInRangeOfPoint(player.Position, new Vector3(461.8065, -994.4086, 25.06443), 2.0f))
        {
            if (NAPI.Data.GetWorldData("lspd_cell_door_1") == true)
            {
                SetDoorState(631614199, new Vector3(461.8065, -994.4086, 25.06443), false, 0); //lspd_cell_door_1
                NAPI.Data.SetWorldData("lspd_cell_door_1", false);
                NAPI.Notification.SendNotificationToPlayer(player, "Du hast die Tür ~g~geöffnet~w~.");
            }
            else
            {
                SetDoorState(631614199, new Vector3(461.8065, -994.4086, 25.06443), true, 0); 
                NAPI.Data.SetWorldData("lspd_cell_door_1", true);
                NAPI.Notification.SendNotificationToPlayer(player, "Du hast die Tür geschlossen~w~.");
            }
        }
        else if (Main.IsInRangeOfPoint(player.Position, new Vector3(461.8065, -997.6583, 25.06443), 2.0f))
        {
            if (NAPI.Data.GetWorldData("lspd_cell_door_2") == true)
            {
                SetDoorState(631614199, new Vector3(461.8065, -997.6583, 25.06443), false, 0); //lspd_cell_door_2
                NAPI.Data.SetWorldData("lspd_cell_door_2", false);
                NAPI.Notification.SendNotificationToPlayer(player, "Du hast die Tür ~g~geöffnet~w~.");
            }
            else
            {
                SetDoorState(631614199, new Vector3(461.8065, -997.6583, 25.06443), true, 0);
                NAPI.Data.SetWorldData("lspd_cell_door_2", true);
                NAPI.Notification.SendNotificationToPlayer(player, "Du hast die Tür geschlossen~w~.");
            }
        }
        else if (Main.IsInRangeOfPoint(player.Position, new Vector3(461.8065, -1001.302, 25.06443), 2.0f))
        {
            if (NAPI.Data.GetWorldData("lspd_cell_door_3") == true)
            {
                SetDoorState(631614199, new Vector3(461.8065, -1001.302, 25.06443), false, 0); //lspd_cell_door_3
                NAPI.Data.SetWorldData("lspd_cell_door_3", false);
                NAPI.Notification.SendNotificationToPlayer(player, "Du hast die Tür ~g~geöffnet~w~.");
            }
            else
            {
                SetDoorState(631614199, new Vector3(461.8065, -1001.302, 25.06443), true, 0);
                NAPI.Data.SetWorldData("lspd_cell_door_3", true);
                NAPI.Notification.SendNotificationToPlayer(player, "Du hast die Tür geschlossen~w~.");
            }
        }
        else if (Main.IsInRangeOfPoint(player.Position, new Vector3(464.3613, -984.678, 43.83443), 2.0f))
        {
            if (NAPI.Data.GetWorldData("lspd_roof") == true)
            {
                SetDoorState(-340230128, new Vector3(464.3613, -984.678, 43.83443), false, 0); //lspd_roof
                NAPI.Data.SetWorldData("lspd_roof", false);
                NAPI.Notification.SendNotificationToPlayer(player, "Du hast die Tür ~g~geöffnet~w~.");
            }
            else
            {
                SetDoorState(-340230128, new Vector3(464.3613, -984.678, 43.83443), true, 0);
                NAPI.Data.SetWorldData("lspd_roof", true);
                NAPI.Notification.SendNotificationToPlayer(player, "Du hast die Tür geschlossen~w~.");
            }
        }
        else if (Main.IsInRangeOfPoint(player.Position, new Vector3(488.8923, -1011.67, 27.14583), 25.0f)) 
        {
            if (NAPI.Data.GetWorldData("lspd_gate_door") == true)
            {
                SetDoorState(-1603817716, new Vector3(488.8923, -1011.67, 27.14583), false, 0); //lspd_gate_door
                NAPI.Data.SetWorldData("lspd_gate_door", false);
                NAPI.Notification.SendNotificationToPlayer(player, "Du hast die Tür ~g~geöffnet~w~.");
            }
            else
            {
                SetDoorState(-1603817716, new Vector3(488.8923, -1011.67, 27.14583), true, 0);
                NAPI.Data.SetWorldData("lspd_gate_door", true);
                NAPI.Notification.SendNotificationToPlayer(player, "Du hast die Tür geschlossen~w~.");
            }
        }
        else if (Main.IsInRangeOfPoint(player.Position, new Vector3(464.26660000, -984.02830000, 43.92001000), 2.0f))
        {
            if (NAPI.Data.GetWorldData("DT1_19_Roofdoor_Dummy") == true)
            {
                SetDoorState(-1603817716, new Vector3(464.26660000, -984.02830000, 43.92001000), false, 0); //lspd_gate_door
                NAPI.Data.SetWorldData("DT1_19_Roofdoor_Dummy", false);
                NAPI.Notification.SendNotificationToPlayer(player, "Du hast die Tür ~g~geöffnet~w~.");
            }
            else
            {
                SetDoorState(-1603817716, new Vector3(464.26660000, -984.02830000, 43.92001000), true, 0);
                NAPI.Data.SetWorldData("DT1_19_Roofdoor_Dummy", true);
                NAPI.Notification.SendNotificationToPlayer(player, "Du hast die Tür geschlossen~w~.");
            }
        }
       //test
        else if (Main.IsInRangeOfPoint(player.Position, new Vector3(472.25, -996.65, 24.91), 2.0f))
        {
            if (NAPI.Data.GetWorldData("v_ilev_gtdoor") == true)
            {
                SetDoorState(-1033001619, new Vector3(472.25, -996.65, 24.91), false, 0); //lspd_gate_door
                NAPI.Data.SetWorldData("v_ilev_gtdoor", false);
                NAPI.Notification.SendNotificationToPlayer(player, "Du hast die Tür ~g~geöffnet~w~.");
            }
            else
            {
                SetDoorState(-1033001619, new Vector3(472.25, -996.65, 24.91), true, 0);
                NAPI.Data.SetWorldData("v_ilev_gtdoor", true);
                NAPI.Notification.SendNotificationToPlayer(player, "Du hast die Tür geschlossen~w~.");
            }
        }
        else if (Main.IsInRangeOfPoint(player.Position, new Vector3(476.51, -996.65, 24.91), 2.0f))
        {
            if (NAPI.Data.GetWorldData("v_ilev_gtdoor") == true)
            {
                SetDoorState(-1033001619, new Vector3(476.51, -996.65, 24.91), false, 0); //lspd_gate_door
                NAPI.Data.SetWorldData("v_ilev_gtdoor", false);
                NAPI.Notification.SendNotificationToPlayer(player, "Du hast die Tür ~g~geöffnet~w~.");
            }
            else
            {
                SetDoorState(-1033001619, new Vector3(476.51, -996.65, 24.91), true, 0);
                NAPI.Data.SetWorldData("v_ilev_gtdoor", true);
                NAPI.Notification.SendNotificationToPlayer(player, "Du hast die Tür geschlossen~w~.");
            }
        }
        else if (Main.IsInRangeOfPoint(player.Position, new Vector3(480.71, -996.65, 24.91), 2.0f))
        {
            if (NAPI.Data.GetWorldData("v_ilev_gtdoor") == true)
            {
                SetDoorState(-1033001619, new Vector3(480.71, -996.65, 24.91), false, 0); //lspd_gate_door
                NAPI.Data.SetWorldData("v_ilev_gtdoor", false);
                NAPI.Notification.SendNotificationToPlayer(player, "Du hast die Tür ~g~geöffnet~w~.");
            }
            else
            {
                SetDoorState(-1033001619, new Vector3(480.71, -996.65, 24.91), true, 0);
                NAPI.Data.SetWorldData("v_ilev_gtdoor", true);
                NAPI.Notification.SendNotificationToPlayer(player, "Du hast die Tür geschlossen~w~.");
            }
        }
        else if (Main.IsInRangeOfPoint(player.Position, new Vector3(480.8, -1003.29, 24.91), 2.0f))
        {
            if (NAPI.Data.GetWorldData("v_ilev_gtdoor") == true)
            {
                SetDoorState(-1033001619, new Vector3(480.8, -1003.29, 24.91), false, 0); //lspd_gate_door
                NAPI.Data.SetWorldData("v_ilev_gtdoor", false);
                NAPI.Notification.SendNotificationToPlayer(player, "Du hast die Tür ~g~geöffnet~w~.");
            }
            else
            {
                SetDoorState(-1033001619, new Vector3(480.8, -1003.29, 24.91), true, 0);
                NAPI.Data.SetWorldData("v_ilev_gtdoor", true);
                NAPI.Notification.SendNotificationToPlayer(player, "Du hast die Tür geschlossen~w~.");
            }
        }
        else if (Main.IsInRangeOfPoint(player.Position, new Vector3(476.33, -1003.29, 24.91), 2.0f))
        {
            if (NAPI.Data.GetWorldData("v_ilev_gtdoor") == true)
            {
                SetDoorState(-1033001619, new Vector3(476.33, -1003.29, 24.91), false, 0); //lspd_gate_door
                NAPI.Data.SetWorldData("v_ilev_gtdoor", false);
                NAPI.Notification.SendNotificationToPlayer(player, "Du hast die Tür ~g~geöffnet~w~.");
            }
            else
            {
                SetDoorState(-1033001619, new Vector3(476.33, -1003.29, 24.91), true, 0);
                NAPI.Data.SetWorldData("v_ilev_gtdoor", true);
                NAPI.Notification.SendNotificationToPlayer(player, "Du hast die Tür geschlossen~w~.");
            }
        }
        else if (Main.IsInRangeOfPoint(player.Position, new Vector3(472.22, -1003.29, 24.91), 2.0f))
        {
            if (NAPI.Data.GetWorldData("v_ilev_gtdoor") == true)
            {
                SetDoorState(-1033001619, new Vector3(472.22, -1003.29, 24.91), false, 0); //lspd_gate_door
                NAPI.Data.SetWorldData("v_ilev_gtdoor", false);
                NAPI.Notification.SendNotificationToPlayer(player, "Du hast die Tür ~g~geöffnet~w~.");
            }
            else
            {
                SetDoorState(-1033001619, new Vector3(472.22, -1003.29, 24.91), true, 0);
                NAPI.Data.SetWorldData("v_ilev_gtdoor", true);
                NAPI.Notification.SendNotificationToPlayer(player, "Du hast die Tür geschlossen~w~.");
            }
        }
        else if (Main.IsInRangeOfPoint(player.Position, new Vector3(467.81, -1003.29, 24.91), 2.0f))
        {
            if (NAPI.Data.GetWorldData("v_ilev_gtdoor") == true)
            {
                SetDoorState(-1033001619, new Vector3(467.81, -1003.29, 24.91), false, 0); //lspd_gate_door
                NAPI.Data.SetWorldData("v_ilev_gtdoor", false);
                NAPI.Notification.SendNotificationToPlayer(player, "Du hast die Tür ~g~geöffnet~w~.");
            }
            else
            {
                SetDoorState(-1033001619, new Vector3(467.81, -1003.29, 24.91), true, 0);
                NAPI.Data.SetWorldData("v_ilev_gtdoor", true);
                NAPI.Notification.SendNotificationToPlayer(player, "Du hast die Tür geschlossen~w~.");
            }
        }
        else if (Main.IsInRangeOfPoint(player.Position, new Vector3(463.65, -981.33, 24.91), 2.0f))
        {
            if (NAPI.Data.GetWorldData("v_ilev_ph_gendoor006") == true)
            {
                SetDoorState(-131296141, new Vector3(463.65, -981.33, 24.91), false, 0); //lspd_gate_door
                NAPI.Data.SetWorldData("v_ilev_ph_gendoor006", false);
                NAPI.Notification.SendNotificationToPlayer(player, "Du hast die Tür ~g~geöffnet~w~.");
            }
            else
            {
                SetDoorState(-131296141, new Vector3(463.65, -981.33, 24.91), true, 0);
                NAPI.Data.SetWorldData("v_ilev_ph_gendoor006", true);
                NAPI.Notification.SendNotificationToPlayer(player, "Du hast die Tür geschlossen~w~.");
            }
        }
        else if (Main.IsInRangeOfPoint(player.Position, new Vector3(471.15, -985.32, 24.91), 2.0f))
        {
            if (NAPI.Data.GetWorldData("v_ilev_ph_gendoor006") == true)
            {
                SetDoorState(-131296141, new Vector3(471.15, -985.32, 24.91), false, 0); //lspd_gate_door
                NAPI.Data.SetWorldData("v_ilev_ph_gendoor006", false);
                NAPI.Notification.SendNotificationToPlayer(player, "Du hast die Tür ~g~geöffnet~w~.");
            }
            else
            {
                SetDoorState(-131296141, new Vector3(471.15, -985.32, 24.91), true, 0);
                NAPI.Data.SetWorldData("v_ilev_ph_gendoor006", true);
                NAPI.Notification.SendNotificationToPlayer(player, "Du hast die Tür geschlossen~w~.");
            }
        }
        else if (Main.IsInRangeOfPoint(player.Position, new Vector3(446.20, -986.94, 26.7), 2.0f))
        {
            if (NAPI.Data.GetWorldData("v_ilev_ph_gendoor003") == true)
            {
                SetDoorState(-543497392, new Vector3(446.20, -986.94, 26.7), false, 0); //lspd_gate_door
                NAPI.Data.SetWorldData("v_ilev_ph_gendoor003", false);
                NAPI.Notification.SendNotificationToPlayer(player, "Du hast die Tür ~g~geöffnet~w~.");
            }
            else
            {
                SetDoorState(-543497392, new Vector3(446.20, -986.94, 26.7), true, 0);
                NAPI.Data.SetWorldData("v_ilev_ph_gendoor003", true);
                NAPI.Notification.SendNotificationToPlayer(player, "Du hast die Tür geschlossen~w~.");
            }
        }
        else if (Main.IsInRangeOfPoint(player.Position, new Vector3(446.21, -999.04, 30.7), 2.0f))
        {
            if (NAPI.Data.GetWorldData("v_ilev_gtdoor") == true)
            {
                SetDoorState(-1033001619, new Vector3(445.56, -999.04, 30.7), false, 0); //lspd_gate_door
                SetDoorState(-1033001619, new Vector3(446.21, -999.04, 30.7), false, 0); //lspd_gate_door
                NAPI.Data.SetWorldData("v_ilev_gtdoor", false);
                NAPI.Notification.SendNotificationToPlayer(player, "Du hast die Tür ~g~geöffnet~w~.");
            }
            else
            {
                SetDoorState(-1033001619, new Vector3(445.56, -999.04, 30.7), true, 0);
                SetDoorState(-1033001619, new Vector3(446.21, -999.04, 30.7), true, 0);
                NAPI.Data.SetWorldData("v_ilev_gtdoor", true);
                NAPI.Notification.SendNotificationToPlayer(player, "Du hast die Tür geschlossen~w~.");
            }
        }
        else if (Main.IsInRangeOfPoint(player.Position, new Vector3(468.43, -978.15, 24.91), 2.0f))
        {
            if (NAPI.Data.GetWorldData("v_ilev_ph_gendoor006") == true)
            {
                SetDoorState(-131296141, new Vector3(468.43, -978.15, 24.91), false, 0); //lspd_gate_door
                NAPI.Data.SetWorldData("v_ilev_ph_gendoor006", false);
                NAPI.Notification.SendNotificationToPlayer(player, "Du hast die Tür ~g~geöffnet~w~.");
            }
            else
            {
                SetDoorState(-1033001619, new Vector3(468.43, -978.15, 24.91), true, 0);
                NAPI.Data.SetWorldData("v_ilev_ph_gendoor006", true);
                NAPI.Notification.SendNotificationToPlayer(player, "Du hast die Tür geschlossen~w~.");
            }
        }
    }
}

