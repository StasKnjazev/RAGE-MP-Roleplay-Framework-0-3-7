using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTANetworkAPI;
using System.Threading;
using System.Timers;

class FuelBusiness : Script
{
    float FUEL_PUMP_RATE = 0.1f;
    static float FUEL_PUMP_RATE2 = 0.1f;

    [Command("tanken")]
    public void CMD_aajuda(Client player)
    {
        if (player.HasData("Refueling"))
        {
            player.ResetData("Refueling");
        }
        else
        {
            int business_id = Business.GetPlayerInBusinessInType(player, 5);

            if (business_id == -1)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Du bist nicht an einer Tankstelle.");
                return;
            }

            int pump_id = GetClosestGasPump(player, business_id);
            float fPumpAmount2 = FUEL_PUMP_RATE / 4;

            //NAPI.Util.ConsoleOutput(" " + business_id + " ------ " + pump_id + "");
            if (pump_id == -1)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Du bist nicht in der Nähe einer Zapfhahn");
            }
            else if (!player.IsInVehicle)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Sie müssen sich in einem Fahrzeug befinden.");
            }
            //else if (player.VehicleSeat == -1)
            //{
            //    NAPI.Notification.SendNotificationToPlayer(player, "Sie müssen der Fahrer des Fahrzeugs sein..");
            //}
            else if (NAPI.Vehicle.GetVehicleEngineStatus(player.Vehicle) == true)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Bitte schalten Sie das Fahrzeug aus, um es zu füllen.");
            }
            else if (Main.GetVehicleFuel(player.Vehicle) >= 100.0)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Entschuldigung, Ihr Fahrzeug ist bereits voll mit dem Tank..");
            }
            else if (Main.GetPlayerMoney(player) < Math.Round(Business.business_list[business_id].business_pump_sale_price[pump_id]))
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Sie haben nicht genug Geld, um Benzin zu kaufen.");
            }
            else if (fPumpAmount2 > Business.business_list[business_id].business_pump_galons[pump_id])
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Diese Gaspumpe ist leer. Bitte versuchen Sie es mit einer anderen.");
            }
            else if (Business.business_list[business_id].business_pump_using[pump_id] == true)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Diese Benzinpumpe wird verwendet. Bitte warten Sie, oder versuchen Sie es mit einer anderen.");
            }
            else
            {
                Main.SendInfoMessage(player, "Ihre Betankung läuft , bitte warten Sie ...");
                //Main.SendInfoMessage(player, "Benutze O um zu tanken .");

                player.SetData("Refueling", player.Vehicle);
                Business.business_list[business_id].business_pump_vehicle[pump_id] = player.Vehicle;
                Business.business_list[business_id].business_pump_using[pump_id] = true;

                Business.business_list[business_id].business_pump_sale_galons[pump_id] = 0;
                Business.business_list[business_id].business_pump_sale_price[pump_id] = 0;

                Business.business_list[business_id].business_gas_refilling++;

                Business.business_list[business_id].business_pump_timer[pump_id] = TimerEx.SetTimer(() => {
                
                    int pump = pump_id;
                    float fPumpAmount = FUEL_PUMP_RATE / 4;
                    Vehicle iVehicleID = Business.business_list[business_id].business_pump_vehicle[pump_id];

                    if(Main.GetVehicleFuel(iVehicleID) >= 99.0)
                    {
                        Main.SetVehicleFuel(iVehicleID, 99.0);
                        StopRefill(player, business_id, pump);
                        NAPI.Notification.SendNotificationToPlayer(player, "Sie haben den Tank Ihres Fahrzeugs gefüllt.");
                        //player.TriggerEvent("createNewHeadNotificationAdvanced", "~g~Ops !~w~ Sie haben den Tank Ihres Fahrzeugs gefüllt.");
                        return;
                    }

                    if (!player.HasData("Refueling"))
                    {
                        StopRefill(player, business_id, pump);
                        player.TriggerEvent("createNewHeadNotificationAdvanced", "~c~Ops !~w~ Sie haben aufgehört zu tanken.");
                        return;
                    }

                    if (fPumpAmount > Business.business_list[business_id].business_pump_galons[pump])
                    {
                        StopRefill(player, business_id, pump);
                        player.TriggerEvent("createNewHeadNotificationAdvanced", "~c~Ops !~w~ Die Zapfsäule hat keinen Kraftstoff mehr.");
                        return;
                    }

                    if (Main.GetPlayerMoney(player) < Math.Round(Business.business_list[business_id].business_pump_sale_price[pump]))
                    {
                        StopRefill(player, business_id, pump);
                        player.TriggerEvent("createNewHeadNotificationAdvanced", "Ops !~w~ Sie haben kein Geld, für weiteres Benzin.");
                        return;
                    }

                    if (!Main.IsInRangeOfPoint(player.Position, Business.business_list[business_id].business_pump_position[pump], 5.0f))
                    {
                        StopRefill(player, business_id, pump);
                        player.TriggerEvent("createNewHeadNotificationAdvanced", "Ops !~w~ Sie sind in der Nähe der Zapfsäule stehen geblieben..");
                        return;
                    }

                    Business.business_list[business_id].business_pump_galons[pump] -= fPumpAmount;
                    Business.business_list[business_id].business_pump_sale_galons[pump] += fPumpAmount;
                    Business.business_list[business_id].business_pump_sale_price[pump] += fPumpAmount * Business.business_list[business_id].business_fuel_price;

                    Main.SetVehicleFuel(iVehicleID, Main.GetVehicleFuel(iVehicleID) + (Convert.ToDouble(fPumpAmount) * 10));

                    string text = "~y~Tankstelle~w~\nID: " + pump + "  (" + business_id + ")";
                        string label = "~s~Preis pro Liter: $" + Business.business_list[business_id].business_fuel_price + "\nDieser Verkauf: $" + Business.business_list[business_id].business_pump_sale_price[pump].ToString("0") + "\nLiter: " + Business.business_list[business_id].business_pump_sale_galons[pump].ToString("C2").Replace("$", "") + "";
                        Business.business_list[business_id].business_pump_textlabel[pump].Text = label;
                        Business.business_list[business_id].business_pump_textlabel_secundary[pump].Text = text;

                }, 200, 0);
            }
        }
    }

    public static void CMD_tanken(Client player)
    {
        if (player.HasData("Refueling"))
        {
            player.ResetData("Refueling");
        }
        else
        {
            int business_id = Business.GetPlayerInBusinessInType(player, 5);

            if (business_id == -1)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Du bist nicht an einer Tankstelle.");
                return;
            }

            int pump_id = GetClosestGasPump(player, business_id);
            float fPumpAmount2 = FUEL_PUMP_RATE2 / 4;

            if (pump_id == -1)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Du bist nicht in der Nähe einer Zapfhahn");
            }
            else if (!player.IsInVehicle)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Sie müssen sich in einem Fahrzeug befinden.");
            }
            //else if (player.VehicleSeat != -1)
            //{
            //    NAPI.Notification.SendNotificationToPlayer(player, "Sie müssen der Fahrer des Fahrzeugs sein..");
            //}
            else if (NAPI.Vehicle.GetVehicleEngineStatus(player.Vehicle) == true)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Bitte schalten Sie das Fahrzeug aus, um es zu füllen.");
            }
            else if (Main.GetVehicleFuel(player.Vehicle) >= 100.0)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Entschuldigung, Ihr Fahrzeug ist bereits voll mit dem Tank..");
            }
            else if (Main.GetPlayerMoney(player) < Math.Round(Business.business_list[business_id].business_pump_sale_price[pump_id]))
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Sie haben nicht genug Geld, um Benzin zu kaufen.");
            }
            else if (fPumpAmount2 > Business.business_list[business_id].business_pump_galons[pump_id])
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Diese Gaspumpe ist leer. Bitte versuchen Sie es mit einer anderen.");
            }
            else if (Business.business_list[business_id].business_pump_using[pump_id] == true)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "Diese Benzinpumpe wird verwendet. Bitte warten Sie, oder versuchen Sie es mit einer anderen.");
            }
            else
            {
                Main.SendInfoMessage(player, "Füllen Sie den Tank Ihres Fahrzeugs auf, bitte warten Sie ...");
                Main.SendInfoMessage(player, "Benutze O um zu tanken .");

                player.SetData("Refueling", player.Vehicle);
                Business.business_list[business_id].business_pump_vehicle[pump_id] = player.Vehicle;
                Business.business_list[business_id].business_pump_using[pump_id] = true;
                Business.business_list[business_id].business_pump_sale_galons[pump_id] = 0;
                Business.business_list[business_id].business_pump_sale_price[pump_id] = 0;
                Business.business_list[business_id].business_gas_refilling++;
                Business.business_list[business_id].business_pump_timer[pump_id] = TimerEx.SetTimer(() => {

                    int pump = pump_id;
                    float fPumpAmount = FUEL_PUMP_RATE2 / 4;
                    Vehicle iVehicleID = Business.business_list[business_id].business_pump_vehicle[pump_id];

                    if (Main.GetVehicleFuel(iVehicleID) >= 99.0)
                    {
                        Main.SetVehicleFuel(iVehicleID, 99.0);
                        StopRefill(player, business_id, pump);
                        player.TriggerEvent("createNewHeadNotificationAdvanced", "~g~Ops !~w~ Sie haben den Tank Ihres Fahrzeugs gefüllt.");
                        return;
                    }

                    if (!player.HasData("Refueling"))
                    {
                        StopRefill(player, business_id, pump);
                        player.TriggerEvent("createNewHeadNotificationAdvanced", "~c~Ops !~w~ Sie haben aufgehört zu tanken.");
                        return;
                    }

                    if (fPumpAmount > Business.business_list[business_id].business_pump_galons[pump])
                    {
                        StopRefill(player, business_id, pump);
                        player.TriggerEvent("createNewHeadNotificationAdvanced", "~c~Ops !~w~ Die Zapfsäule hat keinen Kraftstoff mehr.");
                        return;
                    }

                    if (Main.GetPlayerMoney(player) < Math.Round(Business.business_list[business_id].business_pump_sale_price[pump]))
                    {
                        StopRefill(player, business_id, pump);
                        player.TriggerEvent("createNewHeadNotificationAdvanced", "Ops !~w~ Sie haben kein Geld, für weiteres Benzin.");
                        return;
                    }

                    if (!Main.IsInRangeOfPoint(player.Position, Business.business_list[business_id].business_pump_position[pump], 5.0f))
                    {
                        StopRefill(player, business_id, pump);
                        player.TriggerEvent("createNewHeadNotificationAdvanced", "Ops !~w~ Sie sind in der Nähe der Zapfsäule stehen geblieben..");
                        return;
                    }

                    Business.business_list[business_id].business_pump_galons[pump] -= fPumpAmount;
                    Business.business_list[business_id].business_pump_sale_galons[pump] += fPumpAmount;
                    Business.business_list[business_id].business_pump_sale_price[pump] += fPumpAmount * Business.business_list[business_id].business_fuel_price;

                    Main.SetVehicleFuel(iVehicleID, Main.GetVehicleFuel(iVehicleID) + (Convert.ToDouble(fPumpAmount) * 10));

                    string text = "~y~Tankstelle~w~\nID: " + pump + "  (" + business_id + ")";
                    string label = "~s~Preis pro Liter: $" + Business.business_list[business_id].business_fuel_price + "\nDieser Verkauf: $" + Business.business_list[business_id].business_pump_sale_price[pump].ToString("0") + "\nLiter: " + Business.business_list[business_id].business_pump_sale_galons[pump].ToString("C2").Replace("$", "") + "";
                    Business.business_list[business_id].business_pump_textlabel[pump].Text = label;
                    Business.business_list[business_id].business_pump_textlabel_secundary[pump].Text = text;

                }, 200, 0);
            }
        }
    }

    public static void StopRefill(Client player, int business_id, int pump)
    {
        Business.business_list[business_id].business_pump_using[pump] = false;
        if (business_id != -1)
        {
            Business.business_list[business_id].business_gas_refilling--;
            int iCost = Convert.ToInt32(Business.business_list[business_id].business_pump_sale_price[pump].ToString("N0"));

            Business.business_list[business_id].business_pump_timer[pump].Kill();
            player.ResetData("Refueling");

            NAPI.Notification.SendNotificationToPlayer(player, "Ihr Fahrzeugtank wurde von betankt ~g~$" + iCost + "~w~.", true);
            Business.business_list[business_id].business_Safe += iCost;
            Main.GivePlayerMoney(player, -iCost);
        }
    }

    public static int GetClosestGasPump(Client player, int business_id)
    {
        float min_range = 5.0f;

        for(int i = 0; i < 9; i++)
        {
            if(Main.IsInRangeOfPoint(player.Position, Business.business_list[business_id].business_pump_position[i], min_range))
            {
                return i;
            }
        }
        return -1;
    }

    [Command("editarbomba", "/editarbomba [~c~nome(~w~litros/capacidade/deletar~c~)]~w~ [valor]")]
    public void command_editarbomba(Client player, string name, float valor)
    {
        if (AccountManage.GetPlayerAdmin(player) < adminCommands.COORDENADOR)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Sie haben keine Berechtigung, diesen Befehl zu verwenden.");
            return;
        }

        int business_id = Business.GetPlayerInBusinessInType(player, 5);

        if (business_id == -1)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Sie befinden sich nicht in einer Firma..");
            return;
        }

        int pump = GetClosestGasPump(player, business_id);

        if (pump == -1)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Du bist nicht in der Nähe einer Zapfsäule.");
            return;
        }

        if (name == "capacidade")
        {
            Business.business_list[business_id].business_pump_sale_galons[pump] = 0;
            Business.business_list[business_id].business_pump_sale_price[pump] = 0;

            Business.business_list[business_id].business_pump_capacity[pump] = valor;

            NAPI.Notification.SendNotificationToPlayer(player,"Sie haben die Kapazität der Tankstelle bearbeitet~c~(id: " + pump + ")~w~ para ~g~" + valor + "~w~.");

            string text = "~y~Tankstelle~w~\nID: " + pump + "  (" + business_id + ")";
            string label = "~s~Preis pro Liter: $" + Business.business_list[business_id].business_fuel_price + "\nDieser Verkauf: $" + Business.business_list[business_id].business_pump_sale_price[pump].ToString("0") + "\nLiter: " + Business.business_list[business_id].business_pump_sale_galons[pump].ToString("C2").Replace("$", "") + "";
            Business.business_list[business_id].business_pump_textlabel[pump].Text = label;
            Business.business_list[business_id].business_pump_textlabel_secundary[pump].Text = text;

            Business.SaveBusiness(business_id);
        }
        else if (name == "litros")
        {
            Business.business_list[business_id].business_pump_sale_galons[pump] = 0;
            Business.business_list[business_id].business_pump_sale_price[pump] = 0;

            Business.business_list[business_id].business_pump_galons[pump] = valor;

            NAPI.Notification.SendNotificationToPlayer(player,"Sie haben die Litermenge Benzin von der Gaspumpe bearbeitet ~c~(id: " + pump + ")~w~ para ~g~" + valor + "~w~.");

            string text = "~y~Tankstelle~w~\nID: " + pump + "  (" + business_id + ")";
            string label = "~s~Preis pro Liter: $" + Business.business_list[business_id].business_fuel_price + "\nDieser Verkauf: $" + Business.business_list[business_id].business_pump_sale_price[pump].ToString("0") + "\nLiter: " + Business.business_list[business_id].business_pump_sale_galons[pump].ToString("C2").Replace("$", "") + "";
            Business.business_list[business_id].business_pump_textlabel[pump].Text = label;
            Business.business_list[business_id].business_pump_textlabel_secundary[pump].Text = text;

            Business.SaveBusiness(business_id);
        }
        else if (name == "deletar")
        {
            Business.business_list[business_id].business_pump_position[pump] = new Vector3(0, 0, 0);
            Business.business_list[business_id].business_pump_galons[pump] = 0;
            Business.business_list[business_id].business_pump_capacity[pump] = 0;

            NAPI.Notification.SendNotificationToPlayer(player,"Você deletou~w~ a bomba de gasolina ~c~(id: " + pump + ")~w~.");

            string text = "~y~Tankstelle~w~\nID: " + pump + "  (" + business_id + ")";
            string label = "~s~Preis Pro Liter: $" + Business.business_list[business_id].business_fuel_price + "\nDieser Verkauf: $" + Business.business_list[business_id].business_pump_sale_price[pump].ToString("0") + "\nLiter: " + Business.business_list[business_id].business_pump_sale_galons[pump].ToString("C2").Replace("$", "") + "";
            Business.business_list[business_id].business_pump_textlabel[pump].Text = label;
            Business.business_list[business_id].business_pump_textlabel_secundary[pump].Text = text;

            Business.business_list[business_id].business_pump_textlabel[pump].Position = Business.business_list[business_id].business_pump_position[pump];
            Business.SaveBusiness(business_id);
        }
        else NAPI.Notification.SendNotificationToPlayer(player, "Ungültiger Name.");


    }
}