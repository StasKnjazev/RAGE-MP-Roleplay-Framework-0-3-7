using GTANetworkAPI;
using System.Collections.Generic;
using System;
using DerStr1k3r.Core;
using DerStr1k3r.SDK;

namespace DerStr1k3r.Jobs
{
    class Taxi : Script
    {

        public static void taxiCarsSpawner()
        {

            Main_VehicleManage.CreateVehicle(1, VehicleHash.Taxi, new Vector3(), new Vector3(), 0, 0, "TAXI-30", "TAXI");

        }

        private static nLog Log = new nLog("Taxi");

        private static int taxiRentCost = 100;
        private static Dictionary<Client, ColShape> orderCols = new Dictionary<Client, ColShape>();

        public static void taxiRent(Client player)
        {
            if (NAPI.Player.IsPlayerInAnyVehicle(player) && player.VehicleSeat == -1 && player.Vehicle.GetData("TYPE") == "TAXI")
            {
                if (player.Vehicle.GetData("DRIVER") == null)
                {
                    var vehicle = player.Vehicle;
                    NAPI.Data.SetEntityData(player, "WORK", vehicle);
                    NAPI.Data.SetEntityData(player, "IN_WORK_CAR", true);

                    NAPI.Data.SetEntityData(vehicle, "DRIVER", player);
                    vehicle.SetData("ON_WORK", true);

                    if (Main.GetPlayerMoney(player) < taxiRentCost)
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"Dinheiro não é suficiente", 5000);
                        return;
                    }
                    Main.GivePlayerMoney(player, -taxiRentCost);
                    Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Sie haben ein Taxi gemietet. Um dem Spieler die Zahlung für die Reise anzubieten, schreiben Sie /tprice [ID] [preço]", 5000);
                    //Core.VehicleStreaming.SetEngineState(vehicle, false);
                }
            }
        }

        public static void taxiPay(Client player)
        {
            var seller = player.GetData("TAXI_SELLER");
            var price = player.GetData("TAXI_PAY");

            if (Main.GetPlayerMoney(player) < price)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"Dinheiro não é suficiente", 5000);
                return;
            }
            Main.GivePlayerMoney(player, -price);
            Main.GivePlayerMoney(seller, price);

            Notify.Send(player, NotifyType.Success, NotifyPosition.BottomCenter, $"Sie haben den Fahrpreis bezahlt", 5000);
            Notify.Send(seller, NotifyType.Info, NotifyPosition.BottomCenter, $"" + player.Name.Replace('_', ' ') + " hat für die Fahrt bezahlt", 5000);
        }

        private static void order_onEntityExit(ColShape shape, Client player)
        {
            try
            {
                if (shape.GetData("PASSAGER") != player) return;

                if (player.HasData("TAXI_DRIVER"))
                {
                    Client driver = player.GetData("TAXI_DRIVER");
                    driver.ResetData("PASSAGER");
                    player.ResetData("TAXI_DRIVER");
                    player.SetData("IS_CALL_TAXI", false);
                    Notify.Send(driver, NotifyType.Warning, NotifyPosition.BottomCenter, $"Passagier stornierte die Bestellung", 5000);
                    Notify.Send(player, NotifyType.Success, NotifyPosition.BottomCenter, $"Sie haben die Taxirufstelle verlassen", 5000);
                    try
                    {
                        NAPI.ColShape.DeleteColShape(orderCols[player]);
                        orderCols.Remove(player);
                    }
                    catch { }
                }
            }
            catch (Exception ex) { API.Shared.ConsoleOutput("order_onEntityExit: " + ex.Message, nLog.Type.Error); }
        }

        [ServerEvent(Event.PlayerEnterVehicle)]
        public void onPlayerEnterVehicleHandler(Client player, Vehicle vehicle, sbyte seatid)
        {
            try
            {
                if (NAPI.Data.GetEntityData(vehicle, "TYPE") != "TAXI") return;
                if (seatid == -1)
                {
                    if (player.GetData("character_car_lic") == 0)
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"Sie haben keine Lizenz dafür.", 5000);
                        // player.WarpOutOfVehicle();
                        player.WarpOutOfVehicle();
                        return;
                    }
                    if (Main_Job.GetPlayerJob(player) == 1)
                    {
                        if (NAPI.Data.GetEntityData(player, "WORK") == null)
                        {
                            if (vehicle.GetData("DRIVER") != null)
                            {
                                Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"Dieses Taxi wurde noch nie genommen", 5000);
                                return;
                            }
                            if (Main.GetPlayerMoney(player) >= taxiRentCost)
                            {
                                Trigger.ClientEvent(player, "openDialog", "TAXI_RENT", $"Mieten Sie ein Taxi von ${taxiRentCost}?");
                            }
                            else
                            {
                                Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"Es fehlt " + (taxiRentCost - Main.GetPlayerMoney(player)) + "$ für das Mieten des Taxis.", 5000);
                                // player.WarpOutOfVehicle();
                                player.WarpOutOfVehicle();
                            }
                        }
                        else if (NAPI.Data.GetEntityData(player, "WORK") == vehicle) NAPI.Data.SetEntityData(player, "IN_WORK_CAR", true);
                        else Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"Sie arbeiten bereits", 5000);
                    }
                    else
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"Sie arbeiten nicht als Taxi Fahrer.", 5000);
                        player.WarpOutOfVehicle();
                    }
                }
                else
                {
                    if (NAPI.Data.GetEntityData(vehicle, "DRIVER") != null)
                    {
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, "Wenn Sie Ihre Route an den Fahrer übertragen möchten, markieren Sie die Karte und klicken Sie auf Z.", 5000);
                        var driver = NAPI.Data.GetEntityData(vehicle, "DRIVER");
                        if (driver.HasData("PASSAGER") && driver.GetData("PASSAGER") == player)
                        {
                            driver.ResetData("PASSAGER");
                            player.SetData("IS_CALL_TAXI", false);
                            player.ResetData("TAXI_DRIVER");
                            try
                            {
                                NAPI.ColShape.DeleteColShape(orderCols[player]);
                                orderCols.Remove(player);
                            }
                            catch { }
                        }
                    }
                    else
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"Es ist jetzt kein Fahrer im Taxi", 5000);
                        player.WarpOutOfVehicle();
                    }
                }
            }
            catch (Exception e) { API.Shared.ConsoleOutput("PlayerEnterVehicle: " + e.Message, nLog.Type.Error); }
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
                NAPI.Data.SetEntityData(veh, "WORK", 3);
                NAPI.Data.SetEntityData(veh, "TYPE", "TAXI");
                NAPI.Data.SetEntityData(veh, "NUMBER", i);
                NAPI.Data.SetEntityData(veh, "DRIVER", null);
                NAPI.Data.SetEntityData(veh, "ON_WORK", false);

            }
            catch (Exception e) { API.Shared.ConsoleOutput($"respawnCar: " + e.Message, nLog.Type.Error); }
        }

        public static void onPlayerDissconnectedHandler(Client player, DisconnectionType type, string reason)
        {
            try
            {
                if (!player.GetData("status")) return;
                if (player.HasData("TAXI_DRIVER"))
                {
                    Client driver = player.GetData("TAXI_DRIVER");
                    driver.ResetData("PASSAGER");
                    Notify.Send(driver, NotifyType.Warning, NotifyPosition.BottomCenter, $"Passagier stornierte die Bestellung", 5000);
                    try
                    {
                        NAPI.ColShape.DeleteColShape(orderCols[player]);
                        orderCols.Remove(player);
                    }
                    catch { }
                }
                if (Main_Job.GetPlayerJob(player) == 1 && NAPI.Data.GetEntityData(player, "WORK") != null)
                {
                    var vehicle = NAPI.Data.GetEntityData(player, "WORK");
                    NAPI.Task.Run(() => { try { respawnCar(vehicle); } catch { } });
                    if (player.HasData("PASSAGER"))
                    {
                        Client passager = player.GetData("PASSAGER");
                        passager.ResetData("TAXI_DRIVER");
                        passager.SetData("IS_CALL_TAXI", false);
                        Notify.Send(passager, NotifyType.Warning, NotifyPosition.BottomCenter, $"Der Taxifahrer verließ den Arbeitsplatz und gab eine neue Bestellung auf", 5000);
                        NAPI.Task.Run(() => {
                            try
                            {
                                NAPI.ColShape.DeleteColShape(orderCols[passager]);
                                orderCols.Remove(passager);
                            }
                            catch { }
                        });
                    }
                }
            }
            catch (Exception e) { API.Shared.ConsoleOutput("PlayerDisconnected: " + e.Message, nLog.Type.Error); }
        }

        [ServerEvent(Event.PlayerExitVehicle)]
        public void onPlayerExitVehicleHandler(Client player, Vehicle vehicle)
        {
            try
            {
                if (NAPI.Data.GetEntityData(vehicle, "ACCESS") == "WORK" &&
                Main_Job.GetPlayerJob(player) == 1 &&
                NAPI.Data.GetEntityData(player, "WORK") == vehicle)
                {
                    Notify.Send(player, NotifyType.Warning, NotifyPosition.BottomCenter, $"Wenn Sie nicht innerhalb von 5 Minuten ins Fahrzeug gehen, dann endet der Arbeitstag.", 5000);
                    NAPI.Data.SetEntityData(player, "IN_WORK_CAR", false);
                    if (player.HasData("WORK_CAR_EXIT_TIMER"))
                    {
                        //Main.StopT(NAPI.Data.GetEntityData(player, "WORK_CAR_EXIT_TIMER"), "WORK_CAR_EXIT_TIMER_taxi_1");
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
                    //NAPI.Data.SetEntityData(player, "WORK_CAR_EXIT_TIMER", Main.StartT(1000, 1000, (o) => timer_playerExitWorkVehicle(player, vehicle), "TAXI_CAR_EXIT_TIMER"));
                    //NAPI.Data.SetEntityData(player, "WORK_CAR_EXIT_TIMER", Timers.StartTask(1000, () => timer_playerExitWorkVehicle(player, vehicle)));
                    player.SetData("BUS_TIMER", TimerEx.SetTimer(() => timer_playerExitWorkVehicle(player, vehicle), 1000, 0));
                }
            }
            catch (Exception e) { API.Shared.ConsoleOutput("PlayerExit: " + e.Message, nLog.Type.Error); }
        }

        private void timer_playerExitWorkVehicle(Client player, Vehicle vehicle)
        {
            NAPI.Task.Run(() =>
            {
                try
                {
                    if (!player.HasData("WORK_CAR_EXIT_TIMER")) return;
                    if (NAPI.Data.GetEntityData(player, "IN_WORK_CAR"))
                    {
                        //Main.StopT(NAPI.Data.GetEntityData(player, "WORK_CAR_EXIT_TIMER"), "WORK_CAR_EXIT_TIMER_taxi_2");
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
                    if (NAPI.Data.GetEntityData(player, "CAR_EXIT_TIMER_COUNT") > 300)
                    {
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du hast den Arbeitstag beendet.", 5000);
                        respawnCar(vehicle);
                        player.SetData("ON_WORK", false);
                        player.SetData("WORK", null);
                        //Main.StopT(NAPI.Data.GetEntityData(player, "WORK_CAR_EXIT_TIMER"), "WORK_CAR_EXIT_TIMER_taxi_3");
                        //Timers.Stop(NAPI.Data.GetEntityData(player, "WORK_CAR_EXIT_TIMER"));
                        try
                        {
                            dynamic dynamic = NAPI.Data.GetEntityData(player, "WORK_CAR_EXIT_TIMER").Kill();
                        }
                        catch
                        {

                        }
                        NAPI.Data.ResetEntityData(player, "WORK_CAR_EXIT_TIMER");
                        if (player.HasData("PASSAGER"))
                        {
                            Client passager = player.GetData("PASSAGER");
                            passager.ResetData("TAXI_DRIVER");
                            passager.SetData("IS_CALL_TAXI", false);
                            Notify.Send(player, NotifyType.Warning, NotifyPosition.BottomCenter, $"Der Taxifahrer verließ den Arbeitsplatz und gab eine neue Bestellung auf", 5000);
                            player.ResetData("PASSAGER");
                            try
                            {
                                NAPI.ColShape.DeleteColShape(orderCols[passager]);
                                orderCols.Remove(passager);
                            }
                            catch { }
                        }
                        return;
                    }
                    NAPI.Data.SetEntityData(player, "CAR_EXIT_TIMER_COUNT", NAPI.Data.GetEntityData(player, "CAR_EXIT_TIMER_COUNT") + 1);
                }
                catch (Exception e) { API.Shared.ConsoleOutput("taxi_exitVehicleTimer: " + e.Message); }
            });
        }

        public static void offerTaxiPay(Client player, Client target, int price)
        {
            if (Main_Job.GetPlayerJob(player) == 1)
            {
                if (NAPI.Data.GetEntityData(player, "WORK") != null)
                {
                    if (!target.IsInVehicle || player.Position.DistanceTo(target.Position) > 2) return;
                    if (!NAPI.Player.IsPlayerInAnyVehicle(player) || player.VehicleSeat != -1 || player.Vehicle != player.GetData("WORK") || player.Vehicle != target.Vehicle) return;
                    var vehicle = player.Vehicle;
                    if (NAPI.Data.GetEntityData(vehicle, "TYPE") == "TAXI")
                    {
                        if (price > 200 || price < 20)
                        {
                            Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"Sie können keinen höheren Preis als 200 USD oder weniger als 20 USD festlegen", 5000);
                            return;
                        }
                        if (Main.GetPlayerMoney(player) < price)
                        {
                            Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"Der Spieler hat nicht genug Geld", 5000);
                            return;
                        }

                        Trigger.ClientEvent(target, "openDialog", "TAXI_PAY", $"Bezahlen Sie für die Fahrt: ${price}?");
                        target.SetData("TAXI_SELLER", player);
                        target.SetData("TAXI_PAY", price);

                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du hast dem Spieler ({target.Value}) den Preis {price}$ vorgeschlagen.", 5000);
                    }
                }
                else Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"Sie arbeiten im Moment nicht", 5000);
            }
            else Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"Sie arbeiten nicht als Taxifahrer", 5000);
        }

        public static void acceptTaxi(Client player, Client target)
        {
            if (Main_Job.GetPlayerJob(player) == 1 && NAPI.Data.GetEntityData(player, "WORK") != null)
            {
                if (player.HasData("PASSAGER"))
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"Você já recebeu um pedido", 5000);
                    return;
                }
                if (NAPI.Data.GetEntityData(target, "IS_CALL_TAXI") && !target.HasData("TAXI_DRIVER"))
                {
                    Notify.Send(target, NotifyType.Warning, NotifyPosition.BottomCenter, $"Taxista ({player.Value}) aceitou sua chamada. Fique no lugar", 5000);
                    Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Você aceitou o chamado do jogador ({target.Value})", 5000);
                    Trigger.ClientEvent(player, "createWaypoint", NAPI.Entity.GetEntityPosition(target).X, NAPI.Entity.GetEntityPosition(target).Y);

                    target.SetData("TAXI_DRIVER", player);
                    player.SetData("PASSAGER", target);

                    orderCols.Add(target, NAPI.ColShape.CreateCylinderColShape(target.Position, 10F, 10F, 0));
                    orderCols[target].SetData("PASSAGER", target);
                    orderCols[target].OnEntityExitColShape += order_onEntityExit;
                }
                else Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"O jogador não chamou um táxi ou já foi aceito", 5000);
            }
            else Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"Você não está atualmente trabalhando como taxista", 5000);
        }

        public static void cancelTaxi(Client player)
        {
            if (player.HasData("PASSAGER"))
            {
                Client passager = player.GetData("PASSAGER");
                passager.ResetData("TAXI_DRIVER");
                passager.SetData("IS_CALL_TAXI", false);
                player.ResetData("PASSAGER");
                Notify.Send(passager, NotifyType.Warning, NotifyPosition.BottomCenter, $"O taxista saiu do local de trabalho, fez um novo pedido", 5000);
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Você cancelou o checkout para o cliente", 5000);
                NAPI.Task.Run(() =>
                {
                    try
                    {
                        NAPI.ColShape.DeleteColShape(orderCols[passager]);
                        orderCols.Remove(passager);
                    }
                    catch { }
                });

                return;
            }
            if (NAPI.Data.GetEntityData(player, "IS_CALL_TAXI"))
            {
                NAPI.Data.SetEntityData(player, "IS_CALL_TAXI", false);
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Você cancelou uma chamada de táxi", 5000);
                if (player.HasData("TAXI_DRIVER"))
                {
                    Client driver = player.GetData("TAXI_DRIVER");
                    driver.ResetData("PASSAGER");
                    player.ResetData("TAXI_DRIVER");
                    Notify.Send(driver, NotifyType.Warning, NotifyPosition.BottomCenter, $"Passageiro cancelou o pedido", 5000);
                    NAPI.Task.Run(() =>
                    {
                        try
                        {
                            NAPI.ColShape.DeleteColShape(orderCols[player]);
                            orderCols.Remove(player);
                        }
                        catch { }
                    });
                }
            }
            else Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"Você não ligou para um táxi.", 5000);
        }

        public static void callTaxi(Client player)
        {
            if (!NAPI.Data.GetEntityData(player, "IS_CALL_TAXI"))
            {
                List<Client> players = NAPI.Pools.GetAllPlayers();
                var i = 0;
                foreach (var p in players)
                {
                    if (p == null || !p.GetData("status")) continue;
                    if (Main_Job.GetPlayerJob(p) == 1 && NAPI.Data.GetEntityData(p, "WORK") != null)
                    {
                        i++;
                        NAPI.Chat.SendChatMessageToPlayer(p, $"~g~[DISPATCHER]: ~w~Jogador ({player.Value}) chamou um táxi ~y~({player.Position.DistanceTo(p.Position)}м)~w~. Digite ~y~/ta ~b~[ID]~w~, para aceitar o chamado");
                    }
                }
                if (i > 0)
                {
                    NAPI.Data.SetEntityData(player, "IS_CALL_TAXI", true);
                    Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Espere uma ligação. Na sua área agora {i} Taxistas. Para cancelar a chamada, use /ctaxi", 5000);
                }
                else Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"Não há taxistas em sua área no momento. Tente novamente.", 5000);
            }
            else Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"Você já chamou um táxi. Para cancelar, escreva /ctaxi", 5000);
        }
    }
}
