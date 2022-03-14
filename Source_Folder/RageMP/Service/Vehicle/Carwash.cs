using System;
using System.Collections.Generic;
using GTANetworkAPI;
using DerStr1k3r.Core;
using DerStr1k3r.SDK;

class Carwash : Script
{
    private static List<dynamic> wash = new List<dynamic>();
    private static int toPay = 5000;

    public Carwash()
    {
        NAPI.Util.ConsoleOutput("[Loading] Carwash Initialization...");
    }

    public static void CarwashInit()
    {
        Blip temp_blip = null;
        temp_blip = NAPI.Blip.CreateBlip(new Vector3(20.90365, -1391.978, 28.9), 0);
        temp_blip.Sprite = 225;
        temp_blip.Name = "Carwash";
        temp_blip.Color = 28;
        temp_blip.ShortRange = true;

        temp_blip = NAPI.Blip.CreateBlip(new Vector3(-699.8218, -934.9742, 18.5), 0);
        temp_blip.Sprite = 225;
        temp_blip.Name = "Carwash";
        temp_blip.Color = 28;
        temp_blip.ShortRange = true;

        wash.Add(new { position = new Vector3(20.90365, -1391.978, 28.9) });
        wash.Add(new { position = new Vector3(-699.8218, -934.9742, 18.5) });

        foreach (var Carwash in wash)
        {
            ColShape carwash = NAPI.ColShape.CreateSphereColShape(Carwash.position, 5f);
            NAPI.Marker.CreateMarker(27, Carwash.position - new Vector3(0, 0, 0.8f), new Vector3(), new Vector3(), 5.0f, new Color(255, 255, 255, 110), false, 0);
            NAPI.TextLabel.CreateTextLabel("Sie brauchen ein Carwash Ticket.", Carwash.position, 5f, 9f, 0, new Color(255, 255, 255, 100), false, 0);
        }
    }

    [Command("carwasched")]
    private static void OnClientEventTrigger(Client player)
    {   
            if (NAPI.Vehicle.GetVehicleEngineStatus(player.Vehicle))
            {
                player.Vehicle.Repair();
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Glückwunsch, dein Fahrzeug wurde für $5000 gewaschen!", 5000);
                Main.GivePlayerMoney(player, -toPay);
            }
            else
            {
                Notify.Send(player, NotifyType.Info, NotifyPosition.BottomCenter, $"Waschen mit laufendem Motor ist verboten!", 5000);
        }
    }

    public static void PlayerPressKeyE(Client player)
    {
        foreach (var Carwash in wash)
        {
            if (Main.IsInRangeOfPoint(player.Position, Carwash.position, 3.0f) && Inventory.GetPlayerItemFromInventory(player, 73) >= 1)
            {
                OnClientEventTrigger(player);
                //Inventory.RemoveItem(player, "Carwash Ticket", 1);
                Inventory.RemoveItemByType(player, 73, 1);
            }
        }
    }
}