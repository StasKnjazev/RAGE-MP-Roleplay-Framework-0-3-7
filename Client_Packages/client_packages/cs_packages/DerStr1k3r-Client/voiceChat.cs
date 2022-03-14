using System;
using System.Collections.Generic;

using RAGE;
using RAGE.Elements;

namespace script
{
    public class VoiceChat
        : Events.Script
    {
        public VoiceChat()
        {
            Events.Tick += VoiceProcess;
            Events.OnPlayerQuit += RemoveFromVoice;
        }

        public static long LatestProcess = 0;

        public static float MaxDistance = 10.0f;
        public static bool Voice3d = true;

        public static List<Player> ActivePlayers = new List<Player>();

        static private void Add(Player player)
        {
            player.SetData<bool>("IsListening", true);
            Events.CallRemote("add_voice_listener", player);

            ActivePlayers.Add(player);

            player.Voice3d = Voice3d;
        }

        static private void Remove(Player player, bool notify)
        {
            ActivePlayers.Remove(player);

            player.SetData<bool>("IsListening", false);

            if (notify)
            {
                Events.CallRemote("remove_voice_listener", player);
            }
        }

        static public void RemoveFromVoice(Player player)
        {
            Remove(player, false);
        }

        internal static bool LatestKeyState = false;

        static public void VoiceProcess(List<Events.TickNametagData> nametags)
        {


            long currentTime = Util.UnixTimeNow();

            if ((currentTime - LatestProcess) > 250)
            {
                LatestProcess = currentTime;

                Vector3 localPosition = Player.LocalPlayer.Position;

                foreach (var player in Entities.Players.Streamed)
                {
                    if (!player.GetData<bool>("IsListening"))
                    {
                        float dist = (localPosition.DistanceToSquared(player.Position));

                        if (dist < MaxDistance)
                        {
                            Add(player);
                        }
                    }
                }

                foreach (var player in ActivePlayers)
                {
                    if (player.Handle != 0)
                    {
                        float dist = (localPosition.DistanceToSquared(player.Position));

                        if (dist > MaxDistance)
                        {
                            Remove(player, true);
                        }
                        else
                        {
                            player.VoiceVolume = (1.0f - (dist / MaxDistance));
                        }
                    }
                    else
                    {
                        Remove(player, true);
                    }
                }
            }
        }
    }

    public class Util
    {
        static public long UnixTimeNow()
        {
            var timeSpan = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0));
            return (long)timeSpan.TotalSeconds;
        }
    }
}