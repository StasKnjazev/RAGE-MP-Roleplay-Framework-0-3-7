using GTANetworkAPI;
using System.Collections.Generic;
using System;
using DerStr1k3r.Core;
using DerStr1k3r.SDK;


class Gopostal : Script
{
    private static nLog Log = new nLog("GoPostal");

    [ServerEvent(Event.ResourceStart)]
    public void onResourceStart()
    {
        try
        {
            Cols.Add(0, NAPI.ColShape.CreateCylinderColShape(Coords[0], 1, 2, 0)); // start work
            Cols[0].OnEntityEnterColShape += gp_onEntityEnterColShape;
            Cols[0].OnEntityExitColShape += gp_onEntityExitColShape;
            Cols[0].SetData("INTERACT", 28);
            NAPI.TextLabel.CreateTextLabel("LS Go Postal", Coords[0] + new Vector3(0, 0, 0.3), 10F, 0.6F, 0, new Color(0, 180, 0));

            Cols.Add(1, NAPI.ColShape.CreateCylinderColShape(Coords[1], 1, 2, 0)); // get car
            Cols[1].OnEntityEnterColShape += gp_onEntityEnterColShape;
            Cols[1].OnEntityExitColShape += gp_onEntityExitColShape;
            Cols[1].SetData("INTERACT", 29);
            NAPI.TextLabel.CreateTextLabel("LS Go Postal - Vermietung", Coords[1] + new Vector3(0, 0, 0.3), 10F, 0.6F, 0, new Color(0, 180, 0));

        }
        catch (Exception e) { Log.Write("ResourceStart: " + e.Message, nLog.Type.Error); }
    }

    private static int checkpointPayment = 3;

    public static List<Vector3> Coords = new List<Vector3>()
        {
            new Vector3(-145.0985, -1429.909, 30.90878), // start work
            new Vector3(-149.0251, -1422.705, 30.88864), // get car
        };
    private static Dictionary<int, ColShape> Cols = new Dictionary<int, ColShape>();
    private static Dictionary<int, ColShape> gCols = new Dictionary<int, ColShape>();
    // Postal items (objects) //
    public static List<uint> GoPostalObjects = new List<uint>
        {
            NAPI.Util.GetHashKey("prop_drug_package_02"),
        };

    public static void onPlayerDisconnected(Client player, DisconnectionType type, string reason)
    {
        try
        {
            if (!player.GetData("status")) return;
            if (Main_Job.GetPlayerJob(player) != 3) return;
            if (player.GetData("WORK") != null) NAPI.Entity.DeleteEntity(player.GetData("WORK"));
        }
        catch (Exception e) { Log.Write("PlayerDisconnected: " + e.Message, nLog.Type.Error); }
    }
    [ServerEvent(Event.PlayerExitVehicle)]
    public void onPlayerExitVehicle(Client player, Vehicle vehicle)
    {
        try
        {
            if (!player.GetData("status")) return;
            if (Main_Job.GetPlayerJob(player) != 3) return;
            if (NAPI.Data.GetEntityData(player, "ON_WORK") && NAPI.Data.GetEntityData(player, "PACKAGES") != 0)
            {
                int x = Main_Job.rnd.Next(0, GoPostalObjects.Count);
                BasicSync.AttachObjectToPlayer(player, GoPostalObjects[x], 60309, new Vector3(0.03, 0, 0.02), new Vector3(0, 0, 50));
            }
        }
        catch (Exception e) { Log.Write("PlayerExitVehicle: " + e.Message, nLog.Type.Error); }
    }

    public static void Event_PlayerDeath(Client player, Client entityKiller, uint weapon)
    {
        try
        {
            if (!player.GetData("status")) return;
            if (Main_Job.GetPlayerJob(player) == 3 && NAPI.Data.GetEntityData(player, "ON_WORK"))
            {
                NAPI.Data.SetEntityData(player, "ON_WORK", false);
                Main.UpdatePlayerClothes(player);
            }
        }
        catch (Exception e) { Log.Write("PlayerDeath: " + e.Message, nLog.Type.Error); }
    }

    public static void GoPostal_onEntityEnterColShape(ColShape shape, Client player)
    {
        try
        {
            API.Shared.ConsoleOutput("called");
            if (!player.GetData("status")) return;
            if (HouseSystem.HouseInfo.Count == 0) return;
            if (Main_Job.GetPlayerJob(player) != 3 || !NAPI.Data.GetEntityData(player, "ON_WORK")) return;
            API.Shared.ConsoleOutput("PASSED -- " + NAPI.Data.GetEntityData(player, "NEXTHOUSE") + " -- "+ player.GetData("HOUSEID") + "");
            if (player.HasData("NEXTHOUSE") && player.HasData("HOUSEID") && NAPI.Data.GetEntityData(player, "NEXTHOUSE") == player.GetData("HOUSEID"))
            {
                API.Shared.ConsoleOutput("here");
                if (NAPI.Player.IsPlayerInAnyVehicle(player))
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"Você precisa estar fora do veículo para efetuar a entrega.", 5000);
                    return;
                }
                if (player.GetData("PACKAGES") == 0) return;
                else if (player.GetData("PACKAGES") > 1)
                {
                    API.Shared.ConsoleOutput("done");
                    player.SetData("PACKAGES", player.GetData("PACKAGES") - 1);
                    Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Você entregou o pacote, ainda restam {player.GetData("PACKAGES")} pacotes para ser entregues.", 5000);

                    var coef = Convert.ToInt32(player.Position.DistanceTo2D(player.GetData("W_LASTPOS")) / 100);
                    var payment = Convert.ToInt32(coef * checkpointPayment * Main_Job.Payday_Job_Multipler);

                    DateTime lastTime = player.GetData("W_LASTTIME");
                    if (DateTime.Now < lastTime.AddSeconds(coef * 2))
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, "O proprietário não está em casa, tente novamente mais tarde", 5000);
                        return;
                    }

                    //player.SetData("PAYMENT", player.GetData("PAYMENT") + payment);
                    Main.GivePlayerMoney(player, payment);
                    Notify.Send(player, NotifyType.Success, NotifyPosition.BottomCenter, $"Sie haben $" + payment + " bekommen!", 5000);
                    BasicSync.DetachObject(player);

                    var nextHouse = player.GetData("NEXTHOUSE");
                    List<int> house_ids = new List<int>();
                    int index = 0, count = 0;
                    foreach (var house in HouseSystem.HouseInfo)
                    {
                        if (house.exterior.X != 0 && house.exterior.Z != 0 && house.exterior.DistanceTo2D(player.Position) < 400 && nextHouse != index)
                        {
                            house_ids.Add(index);
                            count++;
                        }
                        index++;
                    }

                    Random rnd = new Random();
                    int next = house_ids[rnd.Next(0, count)];


                    player.SetData("W_LASTPOS", player.Position);
                    player.SetData("W_LASTTIME", DateTime.Now);
                    player.SetData("NEXTHOUSE", next);

                    Trigger.ClientEvent(player, "createCheckpoint", 1, 1, HouseSystem.HouseInfo[next].exterior, 1, 0, 255, 0, 0);
                    Trigger.ClientEvent(player, "createWaypoint", HouseSystem.HouseInfo[next].exterior.X, HouseSystem.HouseInfo[next].exterior.Y);
                    Trigger.ClientEvent(player, "createWorkBlip", HouseSystem.HouseInfo[next].exterior);
                    NAPI.Player.PlayPlayerAnimation(player, -1, "anim@heists@narcotics@trash", "drop_side");
                }
                else
                {
                    API.Shared.ConsoleOutput("here2");
                    var coef = Convert.ToInt32(player.Position.DistanceTo2D(player.GetData("W_LASTPOS")) / 100);
                    var payment = Convert.ToInt32(coef * Main_Job.Payday_Job_Multipler);

                    DateTime lastTime = player.GetData("W_LASTTIME");
                    if (DateTime.Now < lastTime.AddSeconds(coef * 2))
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, "O proprietário não está em casa, tente novamente mais tarde", 5000);
                        return;
                    }

                    Main.GivePlayerMoney(player, payment);

                    Trigger.ClientEvent(player, "deleteWorkBlip");
                    Trigger.ClientEvent(player, "createWaypoint", 105.4633f, -1568.843f);

                    BasicSync.DetachObject(player);

                    Trigger.ClientEvent(player, "deleteCheckpoint", 1, 0);
                    NAPI.Player.PlayPlayerAnimation(player, -1, "anim@heists@narcotics@trash", "drop_side");
                    player.SetData("PACKAGES", 0);
                    Notify.Send(player, NotifyType.Warning, NotifyPosition.BottomCenter, $"Você não tem mais pacotes, pegue novos pacotes na sede.", 5000);
                }
            }
        }
        catch (Exception e) { Log.Write("EXCEPTION AT \"GoPostal\":\n" + e.ToString(), nLog.Type.Error); }
    }
    private void gp_onEntityEnterColShape(ColShape shape, Client entity)
    {
        try
        {
            NAPI.Data.SetEntityData(entity, "INTERACTIONCHECK", shape.GetData("INTERACT"));
        }
        catch (Exception ex) { Log.Write("gp_onEntityEnterColShape: " + ex.Message, nLog.Type.Error); }
    }
    private void gp_onEntityExitColShape(ColShape shape, Client entity)
    {
        try
        {
            NAPI.Data.SetEntityData(entity, "INTERACTIONCHECK", 0);
        }
        catch (Exception ex) { Log.Write("gp_onEntityExitColShape: " + ex.Message, nLog.Type.Error); }
    }

    [ServerEvent(Event.PlayerEnterVehicle)]
    public void onPlayerEnterVehicle(Client player, Vehicle vehicle, sbyte seatid)
    {
        try
        {
            BasicSync.DetachObject(player);
        }
        catch (Exception e) { Log.Write("PlayerEnterVehicle: " + e.Message, nLog.Type.Error); }
    }

    public static void getGoPostalCar(Client player)
    {
        if (Main_Job.GetPlayerJob(player) !=3)
        {
            Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"Você não trabalha como Carteiro", 5000);
            return;
        }
        if (!player.GetData("ON_WORK"))
        {
            Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"Você tem que começar o seu dia de trabalho.", 5000);
            return;
        }
        if (player.GetData("WORK") != null)
        {
            NAPI.Entity.DeleteEntity(player.GetData("WORK"));
            player.SetData("WORK", null);
            return;
        }
        var veh = API.Shared.CreateVehicle(VehicleHash.Faggio, player.Position + new Vector3(0, 0, 1), player.Rotation.Z, 10, 10);
        player.SetData("WORK", veh);
        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Você recebeu um veículo de trabalho.", 5000);
        veh.SetData("ACCESS", "WORK");
        Main.SetVehicleFuel(veh, 100.0);
        NAPI.Vehicle.SetVehicleEngineStatus(veh, false);
        //Core.VehicleStreaming.SetEngineState(veh, true);
    }

    public static void openGoPostalStart(Client player)
    {
        /*   Menu menu = new Menu("gopostal", false, false);
           menu.Callback = callback_gpStartMenu;

           Menu.Item menuItem = new Menu.Item("header", Menu.MenuItem.Header);
           menuItem.Text = "Armazém";
           menu.Add(menuItem);

           menuItem = new Menu.Item("start", Menu.MenuItem.Button);
           menuItem.Text = "Começar";
           menu.Add(menuItem);

           menuItem = new Menu.Item("get", Menu.MenuItem.Button);
           menuItem.Text = "Pegar Pacotes";
           menu.Add(menuItem);

           menuItem = new Menu.Item("finish", Menu.MenuItem.Button);
           menuItem.Text = "Terminar o Trabalho";
           menu.Add(menuItem);

           menuItem = new Menu.Item("close", Menu.MenuItem.Button);
           menuItem.Text = "Fechar";
           menu.Add(menuItem);

           menu.Open(player);*/

        List<dynamic> menu_item_list = new List<dynamic>();
        menu_item_list.Add(new { Type = 1, Name = "Começar", Description = "", RightLabel = "" });
        menu_item_list.Add(new { Type = 1, Name = "Pegar Pacotes", Description = "", RightLabel = "" });
        menu_item_list.Add(new { Type = 1, Name = "Terminar Trabalho", Description = "", RightLabel = "" });
        InteractMenu.CreateMenu(player, "POSTAL_RESPONSE", "Correios", "", true, NAPI.Util.ToJson(menu_item_list), false);
    }

    public static void SelectMenuResponse(Client client, String callbackId, int selectedIndex, String objectName, String valueList)
    {

        if (callbackId == "POSTAL_RESPONSE")
        {
            switch (selectedIndex)
            {

                case 0:
                    if (Main_Job.GetPlayerJob(client) == 3)
                    {
                        if (!NAPI.Data.GetEntityData(client, "ON_WORK"))
                        {

                            List<int> house_ids = new List<int>();
                            int index = 0, count = 0;
                            foreach (var house in HouseSystem.HouseInfo)
                            {
                                if (house.exterior.X != 0 && house.exterior.Z != 0 && house.exterior.DistanceTo2D(client.Position) < 400)
                                {
                                    house_ids.Add(index);
                                    count++;
                                }
                                index++;
                            }

                            if(count < 2)
                            {
                                Main.SendErrorMessage(client, "Precisa ter pelo menos 2 casas criadas perto deste local.");
                                return;
                            }
                           
                            Random rnd = new Random();
                            int next = house_ids[rnd.Next(0, count)];


                            client.SetData("PACKAGES", 10);
                            Notify.Send(client, NotifyType.Info, NotifyPosition.BottomCenter, $"Você recebeu 10 pacotes, entregue os pacotes nas residencias.", 5000);
                            client.SetData("ON_WORK", true);

                            client.SetData("W_LASTPOS", client.Position);
                            client.SetData("W_LASTTIME", DateTime.Now);


                            client.SetData("NEXTHOUSE", next);
                            Trigger.ClientEvent(client, "createCheckpoint", 1, 1, HouseSystem.HouseInfo[next].exterior, 1, 0, 255, 0, 0);
                            Trigger.ClientEvent(client, "createWaypoint", HouseSystem.HouseInfo[next].exterior.X, HouseSystem.HouseInfo[next].exterior.Y);
                            Trigger.ClientEvent(client, "createWorkBlip", HouseSystem.HouseInfo[next].exterior);

                            var gender = client.GetData("IsMale");
                            CharCreator.CharCreator.ClearClothes(client, gender);
                            if (gender)
                            {

                                client.SetAccessories(0, 76, 10);
                                client.SetClothes(11, 38, 3);
                                client.SetClothes(4, 17, 0);
                                client.SetClothes(6, 1, 7);
                                client.SetClothes(3, CharCreator.CharCreator.CorrectTorso[gender][38], 0);
                            }
                            else
                            {

                                client.SetAccessories(0, 76, 10);
                                client.SetClothes(11, 0, 6);
                                client.SetClothes(4, 25, 2);
                                client.SetClothes(6, 1, 2);
                                client.SetClothes(3, CharCreator.CharCreator.CorrectTorso[gender][0], 0);
                            }

                            int x = Main_Job.rnd.Next(0, Gopostal.GoPostalObjects.Count);
                            BasicSync.AttachObjectToPlayer(client, GoPostalObjects[x], 60309, new Vector3(0.03, 0, 0.02), new Vector3(0, 0, 50));
                        }
                        else Notify.Send(client, NotifyType.Error, NotifyPosition.BottomCenter, $"Você já começou seu dia de trabalho.", 5000);
                    }
                    else Notify.Send(client, NotifyType.Error, NotifyPosition.BottomCenter, $"Você não é um Carteiro. Você pode se juntar ao emprego na prefeitura", 5000);
                    return;
                case 1:
                    {
                        if (Main_Job.GetPlayerJob(client)  != 3)
                        {
                            Notify.Send(client, NotifyType.Error, NotifyPosition.BottomCenter, $"Você não trabalha como carteiro", 5000);
                            return;
                        }
                        if (!client.GetData("ON_WORK"))
                        {
                            Notify.Send(client, NotifyType.Error, NotifyPosition.BottomCenter, $"Você não começou o dia de trabalho", 5000);
                            return;
                        }
                        if (client.GetData("PACKAGES") != 0)
                        {
                            Notify.Send(client, NotifyType.Error, NotifyPosition.BottomCenter, $"Você não entregou todos os pacotes. Você ainda tem {client.GetData("PACKAGES")} peças", 5000);
                            return;
                        }
                        if (HouseSystem.HouseInfo.Count == 0) return;
                        client.SetData("PACKAGES", 10);
                        Notify.Send(client, NotifyType.Info, NotifyPosition.BottomCenter, $"Você recebeu 10 pacotes. Entregue nas residencias.", 5000);

                        client.SetData("W_LASTPOS", client.Position);
                        client.SetData("W_LASTTIME", DateTime.Now);


                        List<int> house_ids = new List<int>();
                        int index = 0, count = 0;
                        foreach (var house in HouseSystem.HouseInfo)
                        {
                            if (house.exterior.X != 0 && house.exterior.Z != 0 && house.exterior.DistanceTo2D(client.Position) < 400)
                            {
                                house_ids.Add(index);
                                count++;
                            }
                            index++;
                        }

                        Random rnd = new Random();
                        int next = house_ids[rnd.Next(0, count)];


                        client.SetData("NEXTHOUSE", next);

                        Trigger.ClientEvent(client, "createCheckpoint", 1, 1, HouseSystem.HouseInfo[next].exterior, 1, 0, 255, 0, 0);
                        Trigger.ClientEvent(client, "createWaypoint", HouseSystem.HouseInfo[next].exterior.X, HouseSystem.HouseInfo[next].exterior.Y);
                        Trigger.ClientEvent(client, "createWorkBlip", HouseSystem.HouseInfo[next].exterior);

                        int y = Main_Job.rnd.Next(0, GoPostalObjects.Count);
                        BasicSync.AttachObjectToPlayer(client, GoPostalObjects[y], 60309, new Vector3(0.03, 0, 0.02), new Vector3(0, 0, 50));
                        return;
                    }
                case 2:
                    if (Main_Job.GetPlayerJob(client)  == 3)
                    {
                        if (NAPI.Data.GetEntityData(client, "ON_WORK"))
                        {
                            Trigger.ClientEvent(client, "deleteCheckpoint", 1, 0);
                            BasicSync.DetachObject(client);

                            Notify.Send(client, NotifyType.Info, NotifyPosition.BottomCenter, $"Du hast den Arbeitstag beendet.", 5000);
                            Trigger.ClientEvent(client, "deleteWorkBlip");

                            client.SetData("PAYMENT", 0);
                            Main.UpdatePlayerClothes(client);
                            if (client.HasData("HAND_MONEY")) client.SetClothes(5, 45, 0);
                            else if (client.HasData("HEIST_DRILL")) client.SetClothes(5, 41, 0);

                            client.SetData("PACKAGES", 0);
                            client.SetData("ON_WORK", false);

                            if (client.GetData("WORK") != null)
                            {
                                NAPI.Entity.DeleteEntity(client.GetData("WORK"));
                                client.SetData("WORK", null);
                            }
                        }
                        else Notify.Send(client, NotifyType.Error, NotifyPosition.BottomCenter, $"Você não trabalha", 5000);

                    }
                    else Notify.Send(client, NotifyType.Error, NotifyPosition.BottomCenter, $"Você não trabalha como carteiro", 5000);
                    return;
            }

        }
    }

}

