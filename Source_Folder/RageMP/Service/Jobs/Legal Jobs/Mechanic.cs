/*using GTANetworkAPI;
using System.Collections.Generic;
using DerStr1k3r.GUI;
using System;
using DerStr1k3r.Core;
using DerStr1k3r.SDK;

namespace DerStr1k3r.Jobs
{
    class AutoMechanic : Script
    {
        public static List<CarInfo> CarInfos = new List<CarInfo>();
        public static void mechanicCarsSpawner()
        {
            for (int a = 0; a < CarInfos.Count; a++)
            {
                var veh = NAPI.Vehicle.CreateVehicle(CarInfos[a].Model, CarInfos[a].Position, CarInfos[a].Rotation.Z, CarInfos[a].Color1, CarInfos[a].Color2, CarInfos[a].Number);
                NAPI.Data.SetEntityData(veh, "ACCESS", "WORK");
                NAPI.Data.SetEntityData(veh, "WORK", 8);
                NAPI.Data.SetEntityData(veh, "TYPE", "MECHANIC");
                NAPI.Data.SetEntityData(veh, "NUMBER", a);
                NAPI.Data.SetEntityData(veh, "ON_WORK", false);
                NAPI.Data.SetEntityData(veh, "DRIVER", null);
                NAPI.Data.SetEntitySharedData(veh, "FUELTANK", 0);
                veh.SetSharedData("PETROL", VehicleManager.VehicleTank[veh.Class]);
                Core.VehicleStreaming.SetEngineState(veh, false);
                Core.VehicleStreaming.SetLockStatus(veh, false);
            }
        }
        private static nLog Log = new nLog("Mechanic");

        private static int mechanicRentCost = 100;
        private static Dictionary<Client, ColShape> orderCols = new Dictionary<Client, ColShape>();

        public static void mechanicRepair(Client player, Client target, int price)
        {
            if (Main.Players[player].WorkID != 8 || !player.GetData("ON_WORK"))
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"Você não é mecânico de automóveis", 5000);
                return;
            }
            if (!player.IsInVehicle || !player.Vehicle.HasData("TYPE") || player.Vehicle.GetData("TYPE") != "MECHANIC")
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"Você deve estar em um veículo em funcionamento", 5000);
                return;
            }
            if (!target.IsInVehicle)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"O jogador deve estar no veículo", 5000);
                return;
            }
            if (player.Vehicle.Position.DistanceTo(target.Vehicle.Position) > 5)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"O jogador está muito longe de você", 5000);
                return;
            }
            if (price < 50 || price > 300)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"Você pode definir o preço de 50$ até 300$", 5000);
                return;
            }
            if (Main.Players[target].Money < price)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"O jogador não tem dinheiro suficiente", 5000);
                return;
            }

            target.SetData("MECHANIC", player);
            target.SetData("MECHANIC_PRICE", price);
            Trigger.ClientEvent(target, "openDialog", "REPAIR_CAR", $"Jogador ({player.Value}) ofereceu para reparar seu transporte por ${price}");

            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Você sugeriu ao jogador ({target.Value}) reparar veículos por {price}$", 5000);
        }

        public static void mechanicRent(Client player)
        {
            if (!NAPI.Player.IsPlayerInAnyVehicle(player) || player.VehicleSeat != -1 || player.Vehicle.GetData("TYPE") != "MECHANIC") return;

            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Você alugou um veículo em funcionamento. Aguardar pedido", 5000);
            MoneySystem.Wallet.Change(player, -mechanicRentCost);
            GameLog.Money($"player({Main.Players[player].UUID})", $"server", mechanicRentCost, $"mechanicRent");
            var vehicle = player.Vehicle;
            NAPI.Data.SetEntityData(player, "WORK", vehicle);
            Core.VehicleStreaming.SetEngineState(vehicle, false);
            NAPI.Data.SetEntityData(player, "IN_WORK_CAR", true);
            NAPI.Data.SetEntityData(player, "ON_WORK", true);
            NAPI.Data.SetEntityData(vehicle, "DRIVER", player);
        }

        public static void mechanicPay(Client player)
        {
            if (!player.IsInVehicle)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"Você deve estar em um veículo", 5000);
                return;
            }

            var price = NAPI.Data.GetEntityData(player, "MECHANIC_PRICE");
            if (Main.Players[player].Money < price)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"Você não tem dinheiro suficiente", 5000);
                return;
            }

            VehicleManager.RepairCar(player.Vehicle);
            var driver = NAPI.Data.GetEntityData(player, "MECHANIC");
            MoneySystem.Wallet.Change(player, -price);
            MoneySystem.Wallet.Change(driver, price);
            GameLog.Money($"player({Main.Players[player].UUID})", $"player({Main.Players[driver].UUID})", price, $"mechanicRepair");
            Notify.Send(player, NotifyType.Success, NotifyPosition.BottomCenter, $"Você pagou pela reparação do seu veículo", 5000);
            Notify.Send(driver, NotifyType.Info, NotifyPosition.BottomCenter, $"Jogador ({player.Value}) pagou por reparos", 5000);
            Commands.RPChat("me", driver, $"consertou o carro");

            player.ResetData("MECHANIC_DRIVER");
            driver.ResetData("MECHANIC_CLIENT");
            try
            {
                NAPI.ColShape.DeleteColShape(orderCols[player]);
                orderCols.Remove(player);
            }
            catch { }
        }

        private static void order_onEntityExit(ColShape shape, Client player)
        {
            if (shape.GetData("MECHANIC_CLIENT") != player) return;

            if (player.HasData("MECHANIC_DRIVER"))
            {
                Player driver = player.GetData("MECHANIC_DRIVER");
                driver.ResetData("MECHANIC_CLIENT");
                player.ResetData("MECHANIC_DRIVER");
                player.SetData("IS_CALL_MECHANIC", false);
                Notify.Send(driver, NotifyType.Warning, NotifyPosition.BottomCenter, $"O cliente cancelou o pedido", 5000);
                Notify.Send(player, NotifyType.Warning, NotifyPosition.BottomCenter, $"Você deixou o local de chamada de um mecânico de automóveis", 5000);
                try
                {
                    NAPI.ColShape.DeleteColShape(orderCols[player]);
                    orderCols.Remove(player);
                }
                catch { }
            }
        }

        [ServerEvent(Event.PlayerEnterVehicle)]
        public void Event_onPlayerEnterVehicleHandler(Client player, Vehicle vehicle, sbyte seatid)
        {
            try
            {
                if (NAPI.Data.GetEntityData(vehicle, "TYPE") != "MECHANIC") return;
                if (seatid == -1)
                {
                    if (!Main.Players[player].Licenses[1])
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"Você não possui uma licença de categoria B", 5000);
                        VehicleManager.WarpPlayerOutOfVehicle(player);
                        return;
                    }
                    if (Main.Players[player].WorkID == 8)
                    {
                        if (NAPI.Data.GetEntityData(player, "WORK") == null)
                        {
                            if (vehicle.GetData("DRIVER") != null)
                            {
                                Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"Este transporte de trabalho já foi realizado.", 5000);
                                return;
                            }
                            if (Main.Players[player].Money >= mechanicRentCost)
                            {
                                Trigger.ClientEvent(player, "openDialog", "MECHANIC_RENT", $"Alugue um veículo em funcionamento por ${mechanicRentCost}?");
                            }
                            else
                            {
                                Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"Está faltando " + (mechanicRentCost - Main.Players[player].Money) + "$ para aluguel de veículos de trabalho", 5000);
                                VehicleManager.WarpPlayerOutOfVehicle(player);
                            }
                        }
                        else if (NAPI.Data.GetEntityData(player, "WORK") == vehicle) NAPI.Data.SetEntityData(player, "IN_WORK_CAR", true);
                        else Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"Voce já está trabalhando", 5000);
                    }
                    else
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"Você não trabalha como Mecânico de Automóveis. Você pode se juntar ao emprego na prefeitura", 5000);
                        VehicleManager.WarpPlayerOutOfVehicle(player);
                    }
                }
            }
            catch (Exception e) { Log.Write("PlayerEnterVehicle: " + e.Message, nLog.Type.Error); }
        }

        public static void respawnCar(Vehicle veh)
        {
            try
            {
                int i = NAPI.Data.GetEntityData(veh, "NUMBER");
                NAPI.Entity.SetEntityPosition(veh, CarInfos[i].Position);
                NAPI.Entity.SetEntityRotation(veh, CarInfos[i].Rotation);
                VehicleManager.RepairCar(veh);
                NAPI.Data.SetEntityData(veh, "ACCESS", "WORK");
                NAPI.Data.SetEntityData(veh, "WORK", 8);
                NAPI.Data.SetEntityData(veh, "TYPE", "MECHANIC");
                NAPI.Data.SetEntityData(veh, "NUMBER", i);
                NAPI.Data.SetEntityData(veh, "ON_WORK", false);
                NAPI.Data.SetEntityData(veh, "DRIVER", null);
                NAPI.Data.SetEntitySharedData(veh, "FUELTANK", 0);
                Core.VehicleStreaming.SetEngineState(veh, false);
                Core.VehicleStreaming.SetLockStatus(veh, false);
                veh.SetSharedData("PETROL", VehicleManager.VehicleTank[veh.Class]);
            }
            catch (Exception e) { Log.Write("RespawnCar: " + e.Message, nLog.Type.Error); }
        }

        public static void onPlayerDissconnectedHandler(Client player, DisconnectionType type, string reason)
        {
            try
            {
                if (!Main.Players.ContainsKey(player)) return;
                if (player.HasData("MECHANIC_DRIVER"))
                {
                    Player driver = player.GetData("MECHANIC_DRIVER");
                    driver.ResetData("MECHANIC_CLIENT");
                    Notify.Send(driver, NotifyType.Warning, NotifyPosition.BottomCenter, $"O cliente cancelou o pedido", 5000);
                    try
                    {
                        NAPI.ColShape.DeleteColShape(orderCols[player]);
                        orderCols.Remove(player);
                    }
                    catch { }
                }
                if ((Main.Players[player].WorkID == 8 && NAPI.Data.GetEntityData(player, "ON_WORK") && NAPI.Data.GetEntityData(player, "WORK") != null))
                {
                    var vehicle = NAPI.Data.GetEntityData(player, "WORK");
                    respawnCar(vehicle);
                    if (player.HasData("MECHANIC_CLIENT"))
                    {
                        Client client = player.GetData("MECHANIC_CLIENT");
                        client.ResetData("MECHANIC_DRIVER");
                        client.SetData("IS_CALL_MECHANIC", false);
                        Notify.Send(client, NotifyType.Warning, NotifyPosition.BottomCenter, $"O Mecânico de Automóveis saiu do local de trabalho, faça um novo pedido.", 5000);
                        try
                        {
                            NAPI.ColShape.DeleteColShape(orderCols[client]);
                            orderCols.Remove(client);
                        }
                        catch { }
                    }
                }
            }
            catch (Exception e) { Log.Write("PlayerDisconnected: " + e.Message, nLog.Type.Error); }
        }

        [ServerEvent(Event.PlayerExitVehicle)]
        public void Event_onPlayerExitVehicleHandler(Client player, Vehicle vehicle)
        {
            try
            {
                if (NAPI.Data.GetEntityData(vehicle, "ACCESS") == "WORK" &&
                Main.Players[player].WorkID == 8 &&
                NAPI.Data.GetEntityData(player, "WORK") == vehicle)
                {
                    Notify.Send(player, NotifyType.Warning, NotifyPosition.BottomCenter, $"Se você não entrar em transporte em 5 minutos, o dia útil terminará", 5000);
                    NAPI.Data.SetEntityData(player, "IN_WORK_CAR", false);
                    if (player.HasData("WORK_CAR_EXIT_TIMER"))
                        //Main.StopT(NAPI.Data.GetEntityData(player, "WORK_CAR_EXIT_TIMER"), "timer_1");
                        Timers.Stop(NAPI.Data.GetEntityData(player, "WORK_CAR_EXIT_TIMER"));
                    NAPI.Data.SetEntityData(player, "CAR_EXIT_TIMER_COUNT", 0);
                    //NAPI.Data.SetEntityData(player, "WORK_CAR_EXIT_TIMER", Main.StartT(1000, 1000, (o) => timer_playerExitWorkVehicle(player, vehicle), "AUM_EXIT_CAR_TIMER"));
                    NAPI.Data.SetEntityData(player, "WORK_CAR_EXIT_TIMER", Timers.Start(1000, () => timer_playerExitWorkVehicle(player, vehicle)));
                }
            }
            catch (Exception e) { Log.Write("PlayerExit: " + e.Message, nLog.Type.Error); }
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
                        //Main.StopT(NAPI.Data.GetEntityData(player, "WORK_CAR_EXIT_TIMER"), "timer_2");
                        Timers.Stop(NAPI.Data.GetEntityData(player, "WORK_CAR_EXIT_TIMER"));
                        NAPI.Data.ResetEntityData(player, "WORK_CAR_EXIT_TIMER");
                        return;
                    }
                    if (NAPI.Data.GetEntityData(player, "CAR_EXIT_TIMER_COUNT") > 300)
                    {
                        Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Du hast den Arbeitstag beendet.", 5000);
                        respawnCar(vehicle);
                        player.SetData("ON_WORK", false);
                        player.SetData("WORK", null);
                        //Main.StopT(NAPI.Data.GetEntityData(player, "WORK_CAR_EXIT_TIMER"), "timer_3");
                        Timers.Stop(NAPI.Data.GetEntityData(player, "WORK_CAR_EXIT_TIMER"));
                        NAPI.Data.ResetEntityData(player, "WORK_CAR_EXIT_TIMER");
                        if (player.HasData("MECHANIC_CLIENT"))
                        {
                            Client client = player.GetData("MECHANIC_CLIENT");
                            client.ResetData("MECHANIC_DRIVER");
                            client.SetData("IS_CALL_MECHANIC", false);
                            Notify.Send(player, NotifyType.Warning, NotifyPosition.BottomCenter, $"O Mecânico de Automóveis saiu do local de trabalho, faça um novo pedido.", 5000);
                            player.ResetData("MECHANIC_CLIENT");
                            try
                            {
                                NAPI.ColShape.DeleteColShape(orderCols[client]);
                                orderCols.Remove(client);
                            }
                            catch { }
                        }
                        return;
                    }
                    NAPI.Data.SetEntityData(player, "CAR_EXIT_TIMER_COUNT", NAPI.Data.GetEntityData(player, "CAR_EXIT_TIMER_COUNT") + 1);

                }
                catch (Exception e)
                {
                    Log.Write("Timer_PlayerExitWorkVehicle:\n" + e.ToString(), nLog.Type.Error);
                }
            });
        }

        public static void acceptMechanic(Client player, Client target)
        {
            if (Main.Players[player].WorkID == 8 && player.GetData("ON_WORK"))
            {
                if (player.HasData("MECHANIC_CLIENT"))
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"Você já fez um pedido", 5000);
                    return;
                }
                if (NAPI.Data.GetEntityData(target, "IS_CALL_MECHANIC") && !target.HasData("MECHANIC_DRIVER"))
                {
                    Notify.Send(target, NotifyType.Warning, NotifyPosition.BottomCenter, $"Jogador ({player.Value}) atendeu sua ligação. Fique no lugar", 5000);
                    Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Você aceitou o chamado do jogador ({target.Value})", 5000);
                    Trigger.ClientEvent(player, "createWaypoint", NAPI.Entity.GetEntityPosition(target).X, NAPI.Entity.GetEntityPosition(target).Y);

                    target.SetData("MECHANIC_DRIVER", player);
                    player.SetData("MECHANIC_CLIENT", target);

                    orderCols.Add(target, NAPI.ColShape.CreateCylinderColShape(target.Position, 10F, 10F, 0));
                    orderCols[target].SetData("MECHANIC_CLIENT", target);
                    orderCols[target].OnEntityExitColShape += order_onEntityExit;
                }
                else Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"O jogador não chamou um Mecânico de Automóveis", 5000);
            }
            else Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"No momento, você não está trabalhando como mecânico de automóveis", 5000);
        }

        public static void cancelMechanic(Client player)
        {
            if (player.HasData("MECHANIC_CLIENT"))
            {
                Client client = player.GetData("MECHANIC_CLIENT");
                client.ResetData("MECHANIC_DRIVER");
                client.SetData("IS_CALL_MECHANIC", false);
                player.ResetData("MECHANIC_CLIENT");
                Notify.Send(client, NotifyType.Warning, NotifyPosition.BottomCenter, $"O Mecânico de Automóveis saiu do local de trabalho, faça um novo pedido.", 5000);
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Você cancelou a finalização da compra para o cliente", 5000);
                try
                {
                    NAPI.ColShape.DeleteColShape(orderCols[client]);
                    orderCols.Remove(client);
                }
                catch { }
                return;
            }
            if (NAPI.Data.GetEntityData(player, "IS_CALL_MECHANIC"))
            {
                NAPI.Data.SetEntityData(player, "IS_CALL_MECHANIC", false);
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Você cancelou a chamada de um mecânico de automóveis", 5000);
                if (player.HasData("MECHANIC_DRIVER"))
                {
                    Player driver = player.GetData("MECHANIC_DRIVER");
                    driver.ResetData("MECHANIC_CLIENT");
                    player.ResetData("MECHANIC_DRIVER");
                    Notify.Send(driver, NotifyType.Warning, NotifyPosition.BottomCenter, $"O cliente cancelou o pedido", 5000);
                    try
                    {
                        NAPI.ColShape.DeleteColShape(orderCols[player]);
                        orderCols.Remove(player);
                    }
                    catch { }
                }
            }
            else Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"Você não ligou para um mecânico de automóveis.", 5000);
        }

        public static void callMechanic(Client player)
        {
            if (!NAPI.Data.GetEntityData(player, "IS_CALL_MECHANIC"))
            {
                List<Client> players = NAPI.Pools.GetAllPlayers();
                var i = 0;
                foreach (var p in players)
                {
                    if (p == null || !Main.Players.ContainsKey(p)) continue;
                    if (Main.Players[p].WorkID == 8 && NAPI.Data.GetEntityData(p, "ON_WORK"))
                    {
                        i++;
                        NAPI.Chat.SendChatMessageToPlayer(p, $"~g~[ДИСПЕТЧЕР]: ~w~Jogador ({player.Value}) está chamando mecânico de automóveis ~y~({player.Position.DistanceTo(p.Position)}м)~w~. Digite ~y~/ma ~b~[ID]~w~, para aceitar o chamado");
                    }
                }
                if (i > 0)
                {
                    NAPI.Data.SetEntityData(player, "IS_CALL_MECHANIC", true);
                    Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Espere uma ligação. Na sua área agora {i} mecânica de automóveis. Para cancelar a chamada, use /cmechanic", 5000);
                }
                else Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"Não há Mecânico de Automóveis em sua área no momento. Tente outra vez.", 5000);
            }
            else Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"Você já chamou um mecânico de automóveis. Para cancelar, escreva /cmechanic", 5000);
        }

        public static void buyFuel(Client player, int fuel)
        {
            if (!Main.Players.ContainsKey(player)) return;
            if (Main.Players[player].WorkID != 8 || !player.GetData("ON_WORK") || !player.IsInVehicle || player.GetData("WORK") != player.Vehicle)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"Você deve ser um mecânico de automóveis e estar em uma máquina funcionando", 5000);
                return;
            }
            if (player.GetData("BIZ_ID") == -1 || BusinessManager.BizList[player.GetData("BIZ_ID")].Type != 1)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"Você deve estar no posto de gasolina", 5000);
                return;
            }
            if (fuel <= 0)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"Digite os dados corretos", 5000);
                return;
            }
            Business biz = BusinessManager.BizList[player.GetData("BIZ_ID")];
            if (Main.Players[player].Money < biz.Products[0].Price * fuel)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"Dinheiro insuficiente", 5000);
                return;
            }
            if (player.Vehicle.GetSharedData("FUELTANK") + fuel > 1000)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"O tanque de gasolina está cheio", 5000);
                return;
            }
            if (!BusinessManager.takeProd(biz.ID, fuel, biz.Products[0].Name, biz.Products[0].Price * fuel))
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"Não há combustível suficiente no posto de gasolina", 5000);
                return;
            }
            MoneySystem.Wallet.Change(player, -biz.Products[0].Price * fuel);
            GameLog.Money($"player({Main.Players[player].UUID})", $"biz({biz.ID})", biz.Products[0].Price * fuel, $"mechanicBuyFuel");
            player.Vehicle.SetSharedData("FUELTANK", player.Vehicle.GetSharedData("FUELTANK") + fuel);
            Notify.Send(player, NotifyType.Success, NotifyPosition.BottomCenter, $"Você reabasteceu o tanque em sua máquina de trabalho por {player.Vehicle.GetSharedData("FUELTANK")}л", 5000);
        }

        public static void mechanicFuel(Client player, Client target, int fuel, int pricePerLitr)
        {
            if (Main.Players[player].WorkID != 8 || !player.GetData("ON_WORK"))
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"Você não é mecânico de automóveis", 5000);
                return;
            }
            if (!player.IsInVehicle || !player.Vehicle.HasData("TYPE") || player.Vehicle.GetData("TYPE") != "MECHANIC")
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"Você deve estar em um veículo em funcionamento", 5000);
                return;
            }
            if (!target.IsInVehicle)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"O jogador deve estar no veículo", 5000);
                return;
            }
            if (player.Vehicle.Position.DistanceTo(target.Vehicle.Position) > 5)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"Jogador está muito longe de você", 5000);
                return;
            }
            if (fuel < 1)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"Você não pode vender menos de um litro", 5000);
                return;
            }
            if (pricePerLitr < 2 || pricePerLitr > 10)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"Você pode definir o preço de 2$ até 10$ por litro", 5000);
                return;
            }
            if (Main.Players[target].Money < pricePerLitr * fuel)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"У Jogadorа недостаточно денег", 5000);
                return;
            }

            target.SetData("MECHANIC", player);
            target.SetData("MECHANIC_PRICE", pricePerLitr);
            target.SetData("MECHANIC_FEUL", fuel);
            Trigger.ClientEvent(target, "openDialog", "FUEL_CAR", $"Jogador ({player.Value}) ofereceu para reabastecer seu transporte {fuel}L por ${fuel * pricePerLitr}");

            Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Você sugeriu ao jogador ({target.Value}) reabastecer veículos em {fuel}L por {fuel * pricePerLitr}$.", 5000);
        }

        public static void mechanicPayFuel(Client player)
        {
            if (!player.IsInVehicle)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"Você deve estar em um veículo", 5000);
                return;
            }

            var price = NAPI.Data.GetEntityData(player, "MECHANIC_PRICE");
            var fuel = NAPI.Data.GetEntityData(player, "MECHANIC_FEUL");
            if (Main.Players[player].Money < price * fuel)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"Você não tem dinheiro suficiente", 5000);
                return;
            }

            Player driver = NAPI.Data.GetEntityData(player, "MECHANIC");

            if (!driver.IsInVehicle || !driver.Vehicle.HasData("TYPE") || driver.Vehicle.GetData("TYPE") != "MECHANIC")
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"O mecânico deve estar no veículo", 5000);
                return;
            }

            if (driver.Vehicle.GetSharedData("FUELTANK") < fuel)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"O Mecânico não tem combustível suficiente para abastecer seu veículo", 5000);
                return;
            }

            MoneySystem.Wallet.Change(player, -price * fuel);
            MoneySystem.Wallet.Change(driver, price * fuel);
            GameLog.Money($"player({Main.Players[player].UUID})", $"player({Main.Players[driver].UUID})", price * fuel, $"mechanicFuel");
            Notify.Send(player, NotifyType.Success, NotifyPosition.BottomCenter, $"Você pagou pelo reabastecimento de um veículo", 5000);
            Notify.Send(driver, NotifyType.Info, NotifyPosition.BottomCenter, $"Jogador ({player.Value}) pagou pelo transporte de reabastecimento", 5000);
            Commands.RPChat("me", driver, $"reabasteceu o veículo");

            var carFuel = (player.Vehicle.GetSharedData("PETROL") + fuel > player.Vehicle.GetSharedData("MAXPETROL")) ? player.Vehicle.GetSharedData("MAXPETROL") : player.Vehicle.GetSharedData("PETROL") + fuel;
            player.Vehicle.SetSharedData("PETROL", carFuel);
            driver.Vehicle.SetSharedData("FUELTANK", driver.Vehicle.GetSharedData("FUELTANK") - fuel);
            player.ResetData("MECHANIC_DRIVER");
            driver.ResetData("MECHANIC_CLIENT");
            try
            {
                NAPI.ColShape.DeleteColShape(orderCols[player]);
                orderCols.Remove(player);
            }
            catch { }
        }
    }
}
*/