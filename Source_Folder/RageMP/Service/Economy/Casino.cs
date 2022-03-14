using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;
using Newtonsoft.Json;
using DerStr1k3r.SDK;
using System.Linq;
using DerStr1k3r.GUI;

namespace DerStr1k3r.MoneySystem
{
    class Casino : Script
    {
        private static nLog Log = new nLog("Casino");
        private static Config config = new Config("Casino");

        private static readonly Random random = new Random();
        private static readonly byte[] webnums = new byte[37] { 0, 14, 31, 2, 33, 18, 27, 6, 21, 10, 19, 23, 4, 25, 12, 35, 16, 29, 8, 34, 13, 32, 9, 20, 17, 30, 1, 26, 5, 7, 22, 11, 36, 15, 28, 3, 24 }; // номера ячейки для каждого числа 0, 1, 2 и т.д.
        private static int[] rednums = new int[18] { 1, 3, 5, 7, 9, 12, 14, 16, 18, 19, 21, 23, 25, 27, 30, 32, 34, 36 }; // Все красные числа на рулетке
        private static int WinNum = -1; // Изначально не имеем заданного выигрышного номера
        private static string CasinoT = null; // Таймер Casino будет активен только тогда, когда в него будет играть ХОТЯ БЫ 1 человек, во всех других случаях таймер неактивен.
        private static byte CasinoState = 0; // Стартует Casino с первой фазы, о самих фазах в самом таймере.
        private static byte CTime = 45; // 45 секунд работает ожидание до старта рулетки + 10 в самом таймере накидывается на прокрутку самого колеса
        private static Dictionary<Client, (ushort, ushort, ushort)> PlayersList = new Dictionary<Client, (ushort, ushort, ushort)>();
        //RED. ZERO, BLACK

        private static float colRadius = 2;
        private static Vector3 colPosition = new Vector3
        (
            1147.143, 260.4728, -51.84084
        );
        public static dynamic money { get; set; }
        public static ushort Item1 { get; set; }
        public static ushort Item2 { get; set; }
        public static ushort Item3 { get; set; }

        private static ColShape colShape;
        private static Client player;

        #region Events
        public Casino()
        {
            Console.WriteLine(colPosition);

            colShape = NAPI.ColShape.CreateCylinderColShape(new Vector3(1147.143, 260.4728, -51.84084), 1, 2, 0);
            colShape.OnEntityEnterColShape += (ColShape shape, Client player) =>
            {
                Interact(player);
            };
            colShape.OnEntityExitColShape += (ColShape shape, Client player) =>
            {
                player.TriggerEvent("Casino_Destroy");
            };
            colShape.Position = colPosition;

            Console.WriteLine(colShape.Position);
            NAPI.Marker.CreateMarker(27, colPosition, new Vector3(), new Vector3(), 0.8f, new Color(255, 255, 255, 60));
            NAPI.TextLabel.CreateTextLabel("~y~Drücke E", colPosition + new Vector3(0, 0, 0.3), 5F, 0.3F, 0, new Color(255, 255, 255));
        }
        
        public void JobMenu_onEntityEnterColShape(ColShape shape, Client entity)
        {
            try
            {
                if (entity.GetData("status") == false)
                {
                    return;
                }


                Interact(entity);
            }
            catch (Exception ex) { }
        }

        [ServerEvent(Event.PlayerDeath)]
        public void OnPlayerDeath(Client player, Client killer, uint reason)
        {
                NAPI.ClientEvent.TriggerClientEvent(player, "rouletecfg", 5, 0, 0); // Обычно CaEnd работает после того как клиент его закроет изнутри, но при смерти нужно Schließen со стороны сервера
        }

        [RemoteEvent("PlacedBet")]
        public static void PlacedBet(Client player, ushort red, ushort zero, ushort black)
        {
            try
            {// Тут только добавляем к переменным действующие ставки, снимать со счёта будем в тот момент, когда ставки закроются, в CasinoState 1
                if(CasinoState == 0)
                {
                    
                    if (red + zero + black <= 50000)
                    { // Такая же проверка стоит и на клиенте, на 1 игру ставка максимум 50000 за одну игру
                        int mymoney = Main.GivePlayerMoney(player, Convert.ToInt32(System.Math.Ceiling(Convert.ToDouble(money) - red - zero - black)));
                        //if (mymoney >= 0)
                        //{ // Такая же проверка стоит и на клиенте, но лучше пусть 2 раза перепроверит, что у игрока достаточно денег в банке для игры
                        //    Main.getIdFromClient(player) = (red, zero, black);
                        //}
                    }
                }
            } catch(Exception e)
            {
                Log.Write("PlacedBet: " + e.ToString(), nLog.Type.Error);
            }
        }

        [RemoteEvent("End")]
        public static void CaEnd(Client player, byte type)
        { // Либо закрыл Casino сам, либо PlayerDeath, либо PlayerDisconnected
            if (PlayersList.ContainsKey(player))
            {
                if (CasinoState >= 1)
                { // Если ставки были закрыты
                    ushort cred = Item1;
                    ushort czero = Item2;
                    ushort cblack = Item3;
                    if (cred >= 1 || czero >= 1 || cblack >= 1)
                    { 
                        if (type >= 1)
                        {
                            int price = cred + czero + cblack;
                            Main.GivePlayerMoney(player, price);
                            NAPI.Notification.SendNotificationToPlayer(player, ""+(cred + czero + cblack)+"");
                        }
                    }
                }
                PlayersList.Remove(player);
                if (PlayersList.Count == 0 && CasinoT != null)
                {
                    Timers.Stop(CasinoT);
                    CTime = 45;
                    CasinoState = 0;
                }
            }
        }
        #endregion

        public static void Interact(Client player)
        {
            player.SetData("minBalance", 15000);
            int minBalance = 15000;
            if (Main.GetPlayerMoney(player) < minBalance)
                {
                    Notify.Send(player, NotifyType.Warning, NotifyPosition.BottomCenter, $"Für das Spiel muss man Mindestens {minBalance}$ haben!", 4000);
                    return;
                }

                CasinoT = Timers.StartTask("CasinoT", 5000, CasinoTick); // Если это первый игрок, то запускаем таймер Casino с задержкой в 5 секунд
            // Заменить переменную на ту, что держит кол-во денег в банке у player, Обновляем в UI количество реальных денег со счёта
            Trigger.ClientEvent(player, "startroulete", CTime, CasinoState, Main.GetPlayerMoney(player));
        }
        public static void Disconnect(Client client, DisconnectionType type)
        {
            CaEnd(client, (byte)type);
        }

        private static void CasinoTick()
        { // Один таймер для всего, чтобы у всех была 1 игра, а не у каждого своя.
            if (PlayersList.Count == 0) {
                Timers.Stop(CasinoT);
                CTime = 45;
                CasinoState = 0;
            } else {
                CTime -= 5;
                if (CTime == 5)
                {
                    if (CasinoState == 0)
                    { // Первая позиция, в которой идёт отсчёт до момента кручения рулетки, ставки доступны.
                        CasinoState = 1;
                        foreach (Client target in NAPI.Pools.GetAllPlayers())
                        {
                            Trigger.ClientEvent(target, "rouletecfg", 1, 0, -1);
                        }
                    }
                }
                else if (CTime == 0)
                {
                    if (CasinoState == 1)
                    { // Вторая позиция, в которой идёт отсчёт до момента кручения рулетки, ставки закрыты.
                        CasinoState = 2;
                        CTime = 10;
                        WinNum = random.Next(0, 37); // всего цифр на циферблате 37 (0 + 36), 37 цифр прокрутить это сделать ровно 1 оборот
                        int num = random.Next(1, 11); // от 1 до 10 кругов будет происходить оборот + до нужной цифры
                        lock(PlayersList)
                        {
                            foreach (Client target in NAPI.Pools.GetAllPlayers())
                            {
                                NAPI.Task.Run(() =>
                                {
                                    try
                                    {
                                        NAPI.ClientEvent.TriggerClientEvent(target, "rouletecfg", 0, ((num * 37) + webnums[WinNum]), 0);
                                        // Забираем со счёта все активные ставки
                                        ushort cred = Item1;
                                        ushort czero = Item2;
                                        ushort cblack = Item3;

                                        Main.GivePlayerMoney(target, -(cred + czero + cblack));

                                        target.TriggerEvent("Notification.SendPictureNotification", "Casino", "Bet", $"" + (cred + czero + cblack) + "", "DIA_MIC", true);
                                    } catch(Exception e)
                                    {
                                        Log.Write("CasinoTick: " + e.ToString(), nLog.Type.Error);
                                    }
                                });
                            }
                        }
                    }
                    else if (CasinoState == 2)
                    { // Третья позиция, в которой рулетка крутится, ставки открываются после того, как рулетка докрутится
                        if (WinNum == 0) CasinoWinLoseUpdate(0);
                        else
                        {
                            for (byte i = 0; i != 18; i++)
                            {
                                if (rednums[i] == WinNum)
                                { // RED
                                    CasinoWinLoseUpdate(1);
                                    break;
                                }
                                else if (i == 17) CasinoWinLoseUpdate(2); // BLACK
                            }
                        }
                        CTime = 45;
                        CasinoState = 0;
                    }
                }
                SendTimeAndState();
            }
        }

        private static void CasinoWinLoseUpdate(byte index)
        { // Выдаем деньги победителям
            int wonbet;
            lock(PlayersList)
            {
                foreach (Client target in NAPI.Pools.GetAllPlayers())
                {
                    wonbet = 0;
                    NAPI.Task.Run(() =>
                    {
                        try
                        {
                            if (index == 0)
                            {
                                wonbet = Item2;
                                if (wonbet >= 1)
                                {
                                    wonbet = wonbet * 14;
                                    Main.GivePlayerMoney(target, wonbet);
                                    target.TriggerEvent("Notification.SendPictureNotification", "Casino", "Wins & lose", $"" + (wonbet) + "", "DIA_MIC", true);
                                }
                            }
                            else if (index == 1)
                            {
                                wonbet = Item1;
                                if (wonbet >= 1)
                                {
                                    wonbet = wonbet * 2;
                                    Main.GivePlayerMoney(target, wonbet);
                                    target.TriggerEvent("Notification.SendPictureNotification", "Casino", "Wins & lose", $"" + (wonbet) + "", "DIA_MIC", true);
                                }
                            }
                            else if (index == 2)
                            {
                                wonbet = Item3;
                                if (wonbet >= 1)
                                {
                                    wonbet = wonbet * 2;
                                    Main.GivePlayerMoney(target, wonbet);
                                    target.TriggerEvent("Notification.SendPictureNotification", "Casino", "Wins & lose", $"" + (wonbet) + "", "DIA_MIC", true);
                                }
                            }
                            // Отсылаем всем игрокам их новые суммы в банке и данные об выигрыше в UI, если он есть.
                            NAPI.ClientEvent.TriggerClientEvent(target, "rouletecfg", 4, wonbet, Main.GetPlayerMoney(target));
                            // Аннулируем все активные ставки по серверу
                            PlayersList[target] = (0, 0, 0);

                            target.TriggerEvent("Notification.SendPictureNotification", "Casino", "Wins & lose", $"" + (wonbet) + "", "DIA_MIC", true);
                        }
                        catch(Exception e)
                        {
                            Log.Write("CasinoWinLoseUpdate: " + e.ToString(), nLog.Type.Error);
                        }
                    });
                }
            }
        }

        private static void SendTimeAndState()
        { // Каждые 5 секунд обновляем у игроков время и state в их UI 
            foreach (Client target in PlayersList.Keys)
            {
                //NAPI.ClientEvent.TriggerClientEvent(target, "rouletecfg", 2, CTime, CasinoState);
                Trigger.ClientEvent(target, "rouletecfg", 2, CTime, CasinoState);
            }
        }
    }
}
