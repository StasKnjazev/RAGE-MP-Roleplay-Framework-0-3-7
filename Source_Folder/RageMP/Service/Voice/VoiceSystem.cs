/*Old Version
 * 
 * using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;

public class VoiceSystem : Script
{
    public static float RANGE_VALUE = 10.0f;

    public class VoiceEnum : IEquatable<VoiceEnum>
    {
        public int id { get; set; }
        public bool isListening { get; set; }
        public Client handle { get; set; }

        public override int GetHashCode()
        {
            return id;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            VoiceEnum objAsPart = obj as VoiceEnum;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }

        public bool Equals(VoiceEnum other)
        {
            if (other == null) return false;
            return (this.id.Equals(other.id));
        }
    }

    public static List<VoiceEnum> voice_data = new List<VoiceEnum>();


    public static void VoiceSystemEx()
    {
        for (int i = 0; i < Main.MAX_PLAYERS; i++)
        {
            voice_data.Add(new VoiceEnum { id = i, isListening = false });
        }

        
    }

    public static void VoiceUpdate()
    {
        TimerEx.SetTimer(() =>
        {
            foreach (var player in NAPI.Pools.GetAllPlayers())
            {
                //
                // Detectar 
                //
                foreach (var target in NAPI.Pools.GetAllPlayers())
                {
                    if (Main.IsInRangeOfPoint(target.Position, player.Position, 10f) && voice_data[Main.getIdFromClient(target)].isListening == false)
                    {
                        target.EnableVoiceTo(player);
                        voice_data[Main.getIdFromClient(target)].isListening = true;
                        Main.SendMessageToAll("[VOICE DEBUG]: " + voice_data[Main.getIdFromClient(target)].handle.Name + " -- Conectou no voice.");
                    }
                }


                //
                //
                //
                foreach (var voice in voice_data)
                {
                    if (voice.isListening)
                    {
                        if (Main.IsInRangeOfPoint(voice.handle.Position, player.Position, 10f))
                        {
                            // volume , etc's...
                        }
                        else
                        {
                            voice.isListening = false;
                            voice.handle.DisableVoiceTo(player);
                            Main.SendMessageToAll("[VOICE DEBUG]: " + voice.handle.Name + " -- Desconectou do voice.");
                        }
                    }
                }

            }
        }, 500, 0);
    }

    [Command("debugs")]
    public static void CMD_DEBUG(Client player)
    {
        NAPI.Notification.SendNotificationToPlayer(player,"~c~-> ~y~Lista de Jogadores no voice:");
        foreach (var voice in voice_data)
        {
            if (voice.isListening)
            {
                NAPI.Notification.SendNotificationToPlayer(player,"~c~-> ~y~" + voice.handle.Name + "");
            }
        }
    }

    public static void OnPlayerConnect(Client player)
    {
        int playerid = Main.getIdFromClient(player);

        //reset
        voice_data[playerid].isListening = false;
        voice_data[playerid].handle = player;
    }
}

*/