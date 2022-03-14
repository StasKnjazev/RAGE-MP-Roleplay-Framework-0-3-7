using System;
using RAGE.NUI;
using RAGE;
using System.Drawing;
using RAGE.Elements;


class VehicleFuelStatus : Events.Script
{
    public static TimerBarPool myPool = new TimerBarPool();
    public static BarTimerBar bar_vehicle_fuel = new BarTimerBar("");

    public static int ui_fuel = 0;
    public VehicleFuelStatus()
    {
        bar_vehicle_fuel.Percentage = 0.5f; // Half full
        bar_vehicle_fuel.BackgroundColor = Color.Azure;
        bar_vehicle_fuel.ForegroundColor = Color.IndianRed;

        myPool.Add(bar_vehicle_fuel);

        RAGE.Events.Tick += DrawVehicleFuelStatus;

        Events.Add("vehicleFuel", OnVehicleFuel);
    }

    public static void OnVehicleFuel(object[] args)
    {
        ui_fuel = (int)args[0];

    }

    public void DrawVehicleFuelStatus(System.Collections.Generic.List<RAGE.Events.TickNametagData> nametags)
    {
        if(Player.LocalPlayer.IsSittingInAnyVehicle())
        {
            Vehicle vehicle = Player.LocalPlayer.Vehicle;

            if(Player.LocalPlayer.Handle == vehicle.GetPedInSeat(-1, 0))
            {
                if(ui_fuel > 80)
                {
                    bar_vehicle_fuel.ForegroundColor = Color.Green;
                }
                else if (ui_fuel <= 80 && ui_fuel >= 50)
                {
                    bar_vehicle_fuel.ForegroundColor = Color.DarkGreen;
                }
                else if (ui_fuel <= 49 && ui_fuel >= 30)
                {
                    bar_vehicle_fuel.ForegroundColor = Color.DarkGoldenrod;
                }
                else if (ui_fuel <= 29 && ui_fuel >= 10)
                {
                    bar_vehicle_fuel.ForegroundColor = Color.IndianRed;
                }
                else if (ui_fuel <= 9)
                {
                    bar_vehicle_fuel.ForegroundColor = Color.Red;
                }
                else bar_vehicle_fuel.ForegroundColor = Color.DarkGreen;

                bar_vehicle_fuel.Percentage = Value_To_Progress(ui_fuel);

                myPool.Draw();
            }
        }
    }

    public static float Value_To_Progress(int value)
    {
        float new_value = 1.0f;
        switch (value)
        {
            case 0:
                new_value = 0.0f;
                break;
            case 1:
                new_value = 0.01f;
                break;
            case 2:
                new_value = 0.02f;
                break;
            case 3:
                new_value = 0.03f;
                break;
            case 4:
                new_value = 0.04f;
                break;
            case 5:
                new_value = 0.05f;
                break;
            case 6:
                new_value = 0.06f;
                break;
            case 7:
                new_value = 0.07f;
                break;
            case 8:
                new_value = 0.08f;
                break;
            case 9:
                new_value = 0.09f;
                break;
            case 10:
                new_value = 0.10f;
                break;
            case 11:
                new_value = 0.11f;
                break;
            case 12:
                new_value = 0.12f;
                break;
            case 13:
                new_value = 0.13f;
                break;
            case 14:
                new_value = 0.14f;
                break;
            case 15:
                new_value = 0.15f;
                break;
            case 16:
                new_value = 0.16f;
                break;
            case 17:
                new_value = 0.17f;
                break;
            case 18:
                new_value = 0.18f;
                break;
            case 19:
                new_value = 0.19f;
                break;
            case 20:
                new_value = 0.20f;
                break;
            case 21:
                new_value = 0.21f;
                break;
            case 22:
                new_value = 0.22f;
                break;
            case 23:
                new_value = 0.23f;
                break;
            case 24:
                new_value = 0.24f;
                break;
            case 25:
                new_value = 0.25f;
                break;
            case 26:
                new_value = 0.26f;
                break;
            case 27:
                new_value = 0.27f;
                break;
            case 28:
                new_value = 0.28f;
                break;
            case 29:
                new_value = 0.29f;
                break;
            case 30:
                new_value = 0.30f;
                break;
            case 31:
                new_value = 0.31f;
                break;
            case 32:
                new_value = 0.32f;
                break;
            case 33:
                new_value = 0.33f;
                break;
            case 34:
                new_value = 0.34f;
                break;
            case 35:
                new_value = 0.35f;
                break;
            case 36:
                new_value = 0.36f;
                break;
            case 37:
                new_value = 0.37f;
                break;
            case 38:
                new_value = 0.38f;
                break;
            case 39:
                new_value = 0.39f;
                break;
            case 40:
                new_value = 0.40f;
                break;
            case 41:
                new_value = 0.41f;
                break;
            case 42:
                new_value = 0.42f;
                break;
            case 43:
                new_value = 0.43f;
                break;
            case 44:
                new_value = 0.44f;
                break;
            case 45:
                new_value = 0.45f;
                break;
            case 46:
                new_value = 0.46f;
                break;
            case 47:
                new_value = 0.47f;
                break;
            case 48:
                new_value = 0.48f;
                break;
            case 49:
                new_value = 0.49f;
                break;
            case 50:
                new_value = 0.50f;
                break;
            case 51:
                new_value = 0.51f;
                break;
            case 52:
                new_value = 0.52f;
                break;
            case 53:
                new_value = 0.53f;
                break;
            case 54:
                new_value = 0.54f;
                break;
            case 55:
                new_value = 0.55f;
                break;
            case 56:
                new_value = 0.56f;
                break;
            case 57:
                new_value = 0.57f;
                break;
            case 58:
                new_value = 0.58f;
                break;
            case 59:
                new_value = 0.59f;
                break;
            case 60:
                new_value = 0.60f;
                break;
            case 61:
                new_value = 0.61f;
                break;
            case 62:
                new_value = 0.62f;
                break;
            case 63:
                new_value = 0.63f;
                break;
            case 64:
                new_value = 0.64f;
                break;
            case 65:
                new_value = 0.65f;
                break;
            case 66:
                new_value = 0.66f;
                break;
            case 67:
                new_value = 0.67f;
                break;
            case 68:
                new_value = 0.68f;
                break;
            case 69:
                new_value = 0.69f;
                break;
            case 70:
                new_value = 0.70f;
                break;
            case 71:
                new_value = 0.71f;
                break;
            case 72:
                new_value = 0.72f;
                break;
            case 73:
                new_value = 0.73f;
                break;
            case 74:
                new_value = 0.74f;
                break;
            case 75:
                new_value = 0.75f;
                break;
            case 76:
                new_value = 0.76f;
                break;
            case 77:
                new_value = 0.77f;
                break;
            case 78:
                new_value = 0.78f;
                break;
            case 79:
                new_value = 0.79f;
                break;
            case 80:
                new_value = 0.80f;
                break;
            case 81:
                new_value = 0.81f;
                break;
            case 82:
                new_value = 0.82f;
                break;
            case 83:
                new_value = 0.83f;
                break;
            case 84:
                new_value = 0.84f;
                break;
            case 85:
                new_value = 0.85f;
                break;
            case 86:
                new_value = 0.86f;
                break;
            case 87:
                new_value = 0.87f;
                break;
            case 88:
                new_value = 0.88f;
                break;
            case 89:
                new_value = 0.89f;
                break;
            case 90:
                new_value = 0.90f;
                break;
            case 91:
                new_value = 0.91f;
                break;
            case 92:
                new_value = 0.92f;
                break;
            case 93:
                new_value = 0.93f;
                break;
            case 94:
                new_value = 0.94f;
                break;
            case 95:
                new_value = 0.95f;
                break;
            case 96:
                new_value = 0.96f;
                break;
            case 97:
                new_value = 0.97f;
                break;
            case 98:
                new_value = 0.98f;
                break;
            case 99:
                new_value = 0.99f;
                break;
            case 100:
                new_value = 1.0f;
                break;
        }
        return new_value;
    }

}