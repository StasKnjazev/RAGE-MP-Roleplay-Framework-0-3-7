using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;
using DerStr1k3r.Core;
using DerStr1k3r.SDK;

public class Main_Job : Script
{

    public static Random rnd = new Random();

    public static Vehicle[] job_vehicle { get; set; } = new Vehicle[Main.MAX_PLAYERS];
    public static Vehicle[] job_vehicle_trailer { get; set; } = new Vehicle[Main.MAX_PLAYERS];

    public static List<TimerEx> job_timer = new List<TimerEx>();

    public static int Payday_Job_Multipler = 3;
    public static List<float> Vip_Payment = new List<float>()
        {
            1.0f,
            1.0f,
            1.15f,
            1.25f,
            1.35f,
        };


    public class JobEnum : IEquatable<JobEnum>
    {
        public int id { get; set; }
        public string job_name { get; set; }
        public int job_level { get; set; }
        public int job_payday_payment { get; set; }
        public Vector3 position { get; set; }


        public override int GetHashCode()
        {
            return id;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            JobEnum objAsPart = obj as JobEnum;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }

        public bool Equals(JobEnum other)
        {
            if (other == null) return false;
            return (this.id.Equals(other.id));
        }
    }

    public static List<JobEnum> job_data = new List<JobEnum>();

    public static ColShape teste;
    public Main_Job()
    {
        //
        // Create Jobs
        //
        job_data.Add(new JobEnum { id = 0, job_name = "Arbeitslos", job_level = 1, job_payday_payment = 0 }); // OK
        job_data.Add(new JobEnum { id = 1, job_name = "Taxifahrer", job_level = 4, job_payday_payment = 0, position = new Vector3(895.233, -179.3091, 74.70026) });  // Ok
        job_data.Add(new JobEnum { id = 2, job_name = "Elektriker", job_level = 1, job_payday_payment = 0, position = new Vector3(724.9625, 133.9959, 79.83643) }); // Ok Yeah
        job_data.Add(new JobEnum { id = 3, job_name = "Postbote", job_level = 2, job_payday_payment = 0, position = new Vector3(-145.0985, -1429.909, 30.90878) }); // Ok Yeah
        job_data.Add(new JobEnum { id = 4, job_name = "Geldtransporter", job_level = 3, job_payday_payment = 0, position = new Vector3(48.27299, -621.256, 31.62864) }); // OK Yerah
        job_data.Add(new JobEnum { id = 5, job_name = "Rasenmäher", job_level = 1, job_payday_payment = 0, position = new Vector3(-1331.475, 53.58579, 53.53268) }); // Ok Y yeah
        job_data.Add(new JobEnum { id = 6, job_name = "Mechaniker", job_level = 4, job_payday_payment = 0, position = new Vector3(473.9508, -1275.597, 29.60513) }); // OK
        job_data.Add(new JobEnum { id = 7, job_name = "Baumschneider", job_level = 1, job_payday_payment = 0, position = new Vector3(-567.4201, 5252.957, 71.48643) }); // Ook Y 
        job_data.Add(new JobEnum { id = 8, job_name = "Busfahrer", job_level = 3, job_payday_payment = 0, position = new Vector3(462.6476, -605.5295, 27.49518) }); // OK Yeah
        job_data.Add(new JobEnum { id = 9, job_name = "Müllsammler", job_level = 2, job_payday_payment = 0, position = new Vector3(1262.642, -1983.434, 43.34987) }); // OK Yeah
        job_data.Add(new JobEnum { id = 10, job_name = "LKW Fahrer", job_level = 3, job_payday_payment = 0, position = new Vector3(-536.6481, -2846.78, 6.000384) }); // OK Y
        job_data.Add(new JobEnum { id = 11, job_name = "Feuerwehrman", job_level = 3, job_payday_payment = 0, position = new Vector3(-536.6481, -2846.78, 6.000384) }); // OK Y
        job_data.Add(new JobEnum { id = 12, job_name = "Farmer", job_level = 5, job_payday_payment = 0, position = new Vector3(-536.6481, -2846.78, 6.000384) }); // OK Y

        NAPI.Blip.CreateBlip(408, new Vector3(-145.0985, -1429.909, 30.90878), 1, 63, "LS GO Postal", 255, 0, true, 0, 0);
        NAPI.Blip.CreateBlip(512, new Vector3(-1331.475, 53.58579, 53.53268), 1, 2, "Lawn mower", 255, 0, true, 0, 0);
        NAPI.Blip.CreateBlip(67, new Vector3(48.27299, -621.256, 31.62864), 1, 63, "Money Collector", 255, 0, true, 0, 0);
        NAPI.Blip.CreateBlip(446, new Vector3(473.9508, -1275.597, 29.60513), 1, 40, "LS ACLS", 255, 0, true, 0, 0);

        //NAPI.TextLabel.CreateTextLabel("~b~((~w~ LS Job Center ~b~))", new Vector3(248.2025, -1599.028, 31.53196 + 0.5), 10F, 0.3F, 0, new Color(255, 255, 255));
        NAPI.Marker.CreateMarker(27, new Vector3(248.2025, -1599.028, 31.53196) - new Vector3(0, 0, 1.0), new Vector3(), new Vector3(), 1f, new Color(255, 255, 255, 225));

        teste = NAPI.ColShape.CreateCylinderColShape(new Vector3(248.2025, -1599.028, 31.53196), 1, 2, 0);
        teste.OnEntityEnterColShape += JobMenu_onEntityEnterColShape; // job placement point handler

        for (var i = 0; i < Main.MAX_PLAYERS; i++)
        {
            job_timer.Add(null);
        }

        //
        //
        //
    }
    public void JobMenu_onEntityEnterColShape(ColShape shape, Client entity)
    {
        try
        {
           if(entity.GetData("status") == false)
            {
                return;
            }


            entity.TriggerEvent("Display_Player_Job");
        }
        catch (Exception ex) {  }
    }
    public static void SetPlayerJob(Client player, int jobid)
    {
        player.SetData("character_job", jobid);
    }

    public static int GetPlayerJob(Client player)
    {
       return player.GetData("character_job");
    }

    [Command("setjob", "SYNTAX: /setjob [player] [jobid]")]
    public static void CMD_SetPlayerJob(Client player, string idOrName, int jobid)
    {
        Client target = Main.findPlayer(player, idOrName);

        if (target == null)
        {
            Main.SendErrorMessage(player, "Dieser Player ist nicht verbunden.");
            return;
        }

        if (target.GetData("status") != true)
        {
            Main.SendErrorMessage(player, "Dieser Player ist nicht verbunden.");
            return;
        }


        SetPlayerJob(target, jobid);
        //Main.SendInfoMessage(target, "O administrador " + AccountManage.GetCharacterName(player) +" setou o seu emprego para "+job_data[jobid].job_name+".");
        Main.SendInfoMessage(player, "Sie nehmen den Job als "+job_data[jobid].job_name+" an.");
    }


    public static void KeyPressE(Client player)
    {
        switch (player.GetData("INTERACTIONCHECK"))
        {
            case 0:
                break;
            case 8:
                Electrician.StartWorkDay(player);
                break;
            case 28:
                Gopostal.openGoPostalStart(player);
                return;
            case 29:
                Gopostal.getGoPostalCar(player);
                return;
            case 45:
                Collector.CollectorTakeMoney(player);
                return;
            case 34:
                LumberJack.StartWorkDay(player);
                return; 
        }

    }

    [RemoteEvent("Get_Job")]
    public static void GetJob(Client player, int job)
    {

        if (GetPlayerJob(player) != 0)
        {
            Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"Verlassen Sie Ihren vorherigen Job, um zu einem anderen zu wechseln.", 5000);
            player.TriggerEvent("Destroy_Character_Menu");
            return;
        }
        if (NAPI.Data.GetEntityData(player, "ON_WORK") == true)
        {
            Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"Sie müssen zuerst Ihren aktuellen Job beenden.", 5000);
            player.TriggerEvent("Destroy_Character_Menu");
            return;
        }

        if (GetPlayerJob(player) == job)
            Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"Du Arbeitest schon als {job_data[job].job_name}.", 5000);
        else
        {
            if (player.GetData("character_level") < job_data[job].job_level)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"Du brauchst das Level {job_data[job].job_level} um den Job zu machen.", 5000);
                return;
            }
            SetPlayerJob(player, job);

            Notify.Send(player, NotifyType.Success, NotifyPosition.BottomCenter, $"Dein neuer Job lautet nun {job_data[job].job_name}. Auf der Karte wurde ein Kontrollpunkt definiert, an dem Sie arbeiten können.", 5000);
            Trigger.ClientEvent(player, "createWaypoint", job_data[job].position.X, job_data[job].position.Y);

            player.TriggerEvent("Destroy_Character_Menu");
        }
    }
    public static void LoadDefaultData(Client player)
    {
        NAPI.Data.SetEntityData(player, "ON_WORK", false);
        NAPI.Data.SetEntityData(player, "PAYMENT", 0);
        NAPI.Data.SetEntityData(player, "BUS_ONSTOP", false);
        NAPI.Data.SetEntityData(player, "IS_CALL_TAXI", false);
        NAPI.Data.SetEntityData(player, "IS_REQUESTED", false);
        NAPI.Data.SetEntityData(player, "IN_WORK_CAR", false);
        player.SetData("PACKAGES", 0);
        NAPI.Data.SetEntityData(player, "WORK", null);
        NAPI.Data.SetEntityData(player, "WORKWAY", -1);
        NAPI.Data.SetEntityData(player, "IS_PRICED", false);
        NAPI.Data.SetEntityData(player, "ON_DUTY", false);
        NAPI.Data.SetEntityData(player, "CUFFED", false);
        NAPI.Data.SetEntityData(player, "IN_CP_MODE", false);
        NAPI.Data.SetEntityData(player, "WANTED", 0);
        NAPI.Data.SetEntityData(player, "REQUEST", "null");
        player.SetData("IS_IN_ARREST_AREA", false);
        player.SetData("PAYMENT", 0);
        player.SetData("INTERACTIONCHECK", 0);
        player.SetData("IN_HOSPITAL", false);
        player.SetData("MEDKITS", 0);
        player.SetData("GANGPOINT", -1);
        player.SetData("CUFFED_BY_COP", false);
        player.SetData("CUFFED_BY_MAFIA", false);
        player.SetData("IS_CALL_MECHANIC", false);
        NAPI.Data.SetEntityData(player, "CARROOM_CAR", null);
    }




    public static void FinishallServices(Client player)
    {
        if (Main_Job.GetPlayerJob(player) == 3)
        {
            if (NAPI.Data.GetEntityData(player, "ON_WORK"))
            {
                Trigger.ClientEvent(player, "deleteCheckpoint", 1, 0);
                BasicSync.DetachObject(player);

                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du hast den Arbeitstag beendet.", 5000);

                Trigger.ClientEvent(player, "deleteWorkBlip");

                player.SetData("PAYMENT", 0);
                Main.UpdatePlayerClothes(player);
                if (player.HasData("HAND_MONEY")) player.SetClothes(5, 45, 0);
                else if (player.HasData("HEIST_DRILL")) player.SetClothes(5, 41, 0);

                player.SetData("PACKAGES", 0);
                player.SetData("ON_WORK", false);

                if (player.GetData("WORK") != null)
                {
                    NAPI.Entity.DeleteEntity(player.GetData("WORK"));
                    player.SetData("WORK", null);
                }
                return;
            }
        }
        else if (Main_Job.GetPlayerJob(player) == 8) // Money Collect
        {
            if (player.HasData("WORK_CAR_EXIT_TIMER"))
            {

                if (player.HasData("WORK"))
                {
                    Bus.respawnBusCar(player.GetData("WORK"));
                }


                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du hast den Arbeitstag beendet.", 5000);
                NAPI.Data.SetEntityData(player, "PAYMENT", 0);

                NAPI.Data.SetEntityData(player, "ON_WORK", false);
                NAPI.Data.SetEntityData(player, "WORK", null);
                Trigger.ClientEvent(player, "deleteCheckpoint", 3, 0);
                Trigger.ClientEvent(player, "deleteWorkBlip");
                //Main.StopT(NAPI.Data.GetEntityData(player, "WORK_CAR_EXIT_TIMER"), "timer_17");
                //Timers.Stop(NAPI.Data.GetEntityData(player, "WORK_CAR_EXIT_TIMER"));
                try
                {
                    NAPI.Data.GetEntityData(player, "WORK_CAR_EXIT_TIMER").Kill();
                }
                catch
                {

                }
                NAPI.Data.ResetEntityData(player, "WORK_CAR_EXIT_TIMER");
                Main.UpdatePlayerClothes(player);

                if (player.HasData("WORKOBJECT"))
                {
                    BasicSync.DetachObject(player);
                    player.ResetData("WORKOBJECT");
                }

               
                return;

            }
        }
        else if (Main_Job.GetPlayerJob(player) == 4) // Money Collect
        {
            if (player.HasData("WORK_CAR_EXIT_TIMER"))
            {

                if (player.HasData("WORK"))
                {
                    Collector.respawnCar(player.GetData("WORK"));
                }


                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du hast den Arbeitstag beendet.", 5000);
                NAPI.Data.SetEntityData(player, "PAYMENT", 0);

                NAPI.Data.SetEntityData(player, "ON_WORK", false);
                NAPI.Data.SetEntityData(player, "WORK", null);
                NAPI.ClientEvent.TriggerClientEvent(player, "deleteCheckpoint", 16, 0);
                NAPI.ClientEvent.TriggerClientEvent(player, "deleteWorkBlip");
                //Main.StopT(NAPI.Data.GetEntityData(player, "WORK_CAR_EXIT_TIMER"), "timer_17");
                //Timers.Stop(NAPI.Data.GetEntityData(player, "WORK_CAR_EXIT_TIMER"));
                try
                {
                    NAPI.Data.GetEntityData(player, "WORK_CAR_EXIT_TIMER").Kill();
                }
                catch
                {

                }
                NAPI.Data.ResetEntityData(player, "WORK_CAR_EXIT_TIMER");
                Main.UpdatePlayerClothes(player);

                if (player.HasData("WORKOBJECT"))
                {
                    BasicSync.DetachObject(player);
                    player.ResetData("WORKOBJECT");
                }
                return;

            }
        }
        else if (Main_Job.GetPlayerJob(player) == 2) // Eletric
        {
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
        }
        else if (Main_Job.GetPlayerJob(player) == 9) // Garbage
        {
            if (player.HasData("WORK_CAR_EXIT_TIMER"))
            {

                if (player.HasData("WORK")) Garbage.respawnCar(player.GetData("WORK"));
                NAPI.Data.SetEntityData(player, "ON_WORK", false);
                NAPI.Data.SetEntityData(player, "WORK", null);
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du hast den Arbeitstag beendet.", 5000);
                Trigger.ClientEvent(player, "deleteCheckpoint", 4, 0);

                try
                {
                    NAPI.Data.GetEntityData(player, "WORK_CAR_EXIT_TIMER").Kill();
                }
                catch
                {

                }

                if (player.HasData("WORKOBJECT"))
                {
                    BasicSync.DetachObject(player);
                    player.ResetData("WORKOBJECT");
                }


                foreach (var garbage in Garbage.trash_list)
                {
                    if (garbage.trashPosition.X != 0 && garbage.trashPosition.Y != 0)
                    {
                        player.TriggerEvent("blip_remove", "Lixo #" + garbage.trashID + "");
                    }
                }

                NAPI.Data.ResetEntityData(player, "WORK_CAR_EXIT_TIMER");
                Main.UpdatePlayerClothes(player);
                return;
            }
        }
        else if (Main_Job.GetPlayerJob(player) == 5) // Lawnmore
        {
            if (player.HasData("WORK_CAR_EXIT_TIMER"))
            {


                if (player.HasData("WORK")) Lawnmower.respawnCar(player.GetData("WORK"));
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
                NAPI.Data.ResetEntityData(player, "WORK_CAR_EXIT_TIMER");
                Main.UpdatePlayerClothes(player);
                return;

            }
        }
        else if (Main_Job.GetPlayerJob(player) == 7) // Lumberjack
        {
            Main.UpdatePlayerClothes(player);
            player.SetData("ON_WORK", false);
            Trigger.ClientEvent(player, "deleteCheckpoint", 15);
            Trigger.ClientEvent(player, "deleteWorkBlip");

            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du hast den Arbeitstag beendet.", 5000);

            if (player.HasData("WORKOBJECT"))
            {
                BasicSync.DetachObject(player);
                player.ResetData("WORKOBJECT");
            }
        }
        else
        {
            foreach (var veh in NAPI.Pools.GetAllVehicles())
            {
                if (NAPI.Data.HasEntityData(veh, "mechanic_vehicle"))
                {
                    if (player == NAPI.Data.GetEntityData(veh, "mechanic_vehicle"))
                    {
                        NAPI.Entity.DeleteEntity(veh);
                        try
                        {
                            NAPI.Data.SetEntityData(veh, "mechanic_vehicle", null);
                        }
                        catch
                        {

                        }
                    }
                }
            }


            player.TriggerEvent("blip_remove", "emprego");
            player.TriggerEvent("delete_marker", "emprego");


            player.SetData("shipment", false);

            try
            {
                Entity vehicleid = Main_Job.job_vehicle[Main.getIdFromClient(player)];

                if (NAPI.Data.HasEntityData(vehicleid, "shipment_business"))
                {
                    int business_id = NAPI.Data.GetEntityData(vehicleid, "shipment_business");

                    if (Business.business_list[business_id].business_OrderState > 1)
                    {
                        Business.business_list[business_id].business_OrderState = 1;
                    }


                }
            }
            catch (Exception)
            {

            }

            player.TriggerEvent("delete_marker", "shipment");
            player.TriggerEvent("blip_remove", "LS Go Trucker");

            try
            {
                if (NAPI.Data.HasEntityData(job_vehicle[Main.getIdFromClient(player)], "shipment_trailerBy"))
                {
                    NAPI.Entity.DeleteEntity(NAPI.Data.GetEntityData(job_vehicle[Main.getIdFromClient(player)], "shipment_trailerBy"));
                    NAPI.Data.SetEntityData(job_vehicle[Main.getIdFromClient(player)], "shipment_trailerBy", null);
                }
            }
            catch (Exception)
            {

            }

            try
            {
                if (job_vehicle[Main.getIdFromClient(player)] != null && job_vehicle[Main.getIdFromClient(player)].Exists)
                {
                    job_vehicle[Main.getIdFromClient(player)].Delete();
                    job_vehicle[Main.getIdFromClient(player)] = null;
                }
            }
            catch (Exception)
            {
                NAPI.Util.ConsoleOutput("Fahrzeug noch nicht erstellt.");
            }



            Main.UpdatePlayerClothes(player);

            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du hast den Arbeitstag beendet.", 5000);
        }
    }

    [Command("finalizarservico", Alias = "fs,cancelarentrega,killcheckpoints")]
    public static void CMD_cancelarentrega(Client player)
    {

        if (GetPlayerJob(player) == 0)
        {
            Main.SendErrorMessage(player, "Sie sind nicht in der Lage, die Arbeit von Heute zu beenden.");

            return;
        }
        if (player.IsInVehicle)
        {
            Main.SendErrorMessage(player, "Sie können diesen Befehl nicht für ein Fahrzeug verwenden.");
            return;
        }

        FinishallServices(player);
    }

    [Command("desempregar")]
    public static void CMD_desempregar(Client player)
    {

        if (GetPlayerJob(player) == 0)
        {
            Main.SendErrorMessage(player, "Sie sind nicht in der Lage, die Arbeit von Heute zu beenden.");

            return;
        }

        FinishallServices(player);
        SetPlayerJob(player, 0);
        Main.UpdatePlayerClothes(player);
        Main.SendSuccessMessage(player, "Sie haben Ihren aktuellen Job gekündigt.");
    }
}
