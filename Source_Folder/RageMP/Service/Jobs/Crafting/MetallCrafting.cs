using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;
using DerStr1k3r.SDK;
using DerStr1k3r.Core;

class Metall : Script
{
    private static nLog Log = new nLog("Metall Crafting");
    public static List<TimerEx> sal_timer = new List<TimerEx>();

    public static void MetallInit()
    {
        Blip temp_blip = null;
        temp_blip = NAPI.Blip.CreateBlip(new Vector3(2786.226, 1397.501, 24.65239), 0);
        temp_blip.Sprite = 515;
        temp_blip.Name = "Metallrecycling";
        temp_blip.Color = 40;
        temp_blip.ShortRange = true;

        temp_blip = NAPI.Blip.CreateBlip(new Vector3(-596.6303, 2090.271, 131.4127), 0);
        temp_blip.Sprite = 515;
        temp_blip.Name = "Mine";
        temp_blip.Color = 40;
        temp_blip.ShortRange = true;
    }

    [Command("ro2")]
    public void removeob2(Client player)
    {
        player.TriggerEvent("remoooo");
    }

    public static void OnPlayerConnect(Client player)
    {
        player.TriggerEvent("Sync_PedCreate", "comprador_de_metall", NAPI.Util.PedNameToModel("GenStreet02AMY"), new Vector3(2786.226, 1397.501, 24.65239), 83.95506f, "", 0);
    }

    public static void PressKeyY(Client player)
    {
        try
        {
            if (Main.IsInRangeOfPoint(player.Position, new Vector3(2786.226, 1397.501, 24.65239), 3.0f))
            {
                if (Inventory.GetPlayerItemFromInventory(player, 68) > 0)
                {
                    InteractMenu.User_Input(player, "input_sell_metall_block", " MetalBlock verkaufen", Inventory.GetPlayerItemFromInventory(player, 68).ToString(), "Sie haben derzeit " + Inventory.GetPlayerItemFromInventory(player, 68) + "", "number");
                }
                else
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "Du hast was dafür vergessen!");
                }
            }
        }
        catch (Exception e)
        {
            Log.Write("PressKeyY: " + e.Message, nLog.Type.Error);
        }
    }

    public static void OnInputResponse(Client player, string response, string inputtext)
    {
        try
        {
            if (response == "input_sell_metall_block")
            {
                if (Inventory.GetPlayerItemFromInventory(player, 68) > 0)
                {
                
                    if(!Main.IsNumeric(inputtext))
                    {
                        Main.DisplayErrorMessage(player, "Der eingegebene Wert ist nicht numerisch. Bitte geben Sie einen gültigen Wert ein.");
                        return;
                    }

                    int valor = Convert.ToInt32(inputtext);

                    if (valor < 1)
                    {
                        Main.DisplayErrorMessage(player, "Der eingegebene Wert darf nicht kleiner als 1 sein.");
                        return;
                    }

                    if(Inventory.GetPlayerItemFromInventory(player, 68) < valor)
                    {
                        Main.DisplayErrorMessage(player, "Sie versuchen MetalBlock zu verkaufen "+ valor + " doch Sie haben nur "+ Inventory.GetPlayerItemFromInventory(player, 41) + ".");
                        return;
                    }

                    Random rnd = new Random();
                    int price = valor * rnd.Next(75, 86);

                    Inventory.GiveItemToInventory(player, 158, +price);
                    NAPI.Notification.SendNotificationToPlayer(player, "Du hast " + Main.EMBED_BLUE+""+ valor + "x"+Main.EMBED_WHITE+ " MetalBlock für $"+ price.ToString("N0") + " verkauft.");
                    Inventory.RemoveItemByType(player, 68, valor);
                }
            }
        }
        catch (Exception e)
        {
            Log.Write("OnInputResponse: " + e.Message, nLog.Type.Error);
        }
    }
}

