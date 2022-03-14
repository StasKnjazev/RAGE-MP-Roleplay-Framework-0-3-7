using System;
using System.Collections.Generic;
using GTANetworkAPI;
using Newtonsoft.Json;

class Rathaus : Script
{
    private static List<dynamic> rathaus_zulassung = new List<dynamic>();
    public static int PRICE_KFZPLATE = 150;

    public Rathaus()
    {

    }

    public static void RathausInit()
    {
        rathaus_zulassung.Add(new { position = new Vector3(-72.87216, -816.4447, 243.38585) });

        foreach (var Rathaus in rathaus_zulassung)
        {
            ColShape rathaus_zulassung = NAPI.ColShape.CreateSphereColShape(Rathaus.position, 2f);
            NAPI.Marker.CreateMarker(27, Rathaus.position - new Vector3(0, 0, 0.8f), new Vector3(), new Vector3(), 2.0f, new Color(255, 255, 255, 110), false, 0);
        }
    }

    public static void PlayerPressKeyE(Player player)
    {
        if (Main.IsInRangeOfPoint(player.Position, new Vector3(-72.87216, -816.4447, 243.38585), 3.0f))
        {
            
            InteractMenu.User_Input(player, "input_manage_char_bday", "Ausweis beantragen", "Bitte wie folgt angeben: 01.02.1970", player.GetData<string>("character_bday"));
            //NAPI.Notification.SendNotificationToPlayer(player, "<C>Rarthaus:</C> ~n~Die Ausweis kosten betragen sich bei $" + Zulassung.PRICE_KFZPLATE.ToString() + ".");
        }
    }

    public static void OnInputResponse(Player player, String response, String inputtext)
    {
    
        if (response == "input_manage_char_bday")
        {
            
            //if (String.IsNullOrEmpty(name))
            //{
            //    NAPI.Notification.SendNotificationToPlayer(player, "Sie können keinen Nullnamen verwenden.");
            //    return;
            //}
            string datum = inputtext.ToString();
            if (API.Shared.IsPlayerConnected(player))
            {
                //NAPI.Data.SetEntityData(player, "character_bday", bday_datum);
                NAPI.Util.ConsoleOutput("DEBUG: Bday " + datum.ToString() + "");
                AccountManage.SetPlayerBday(player, datum.ToString());
                Main.GivePlayerMoney(player, -PRICE_KFZPLATE);
                // NAPI.Notification.SendNotificationToPlayer(player, "<C>Rathaus:</C> ~n~Sie haben Ihr Ausweis für $" + Zulassung.PRICE_KFZPLATE.ToString() + " beantragt und erhalten.");
            }
        }
    }
}