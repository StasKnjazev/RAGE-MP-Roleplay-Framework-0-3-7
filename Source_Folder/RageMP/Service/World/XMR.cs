using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;

class XMR : Script
{
    public class XmrEnum : IEquatable<XmrEnum>
    {
        public int id { get; set; }
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
        public string stream { get; set; }
        public dynamic carid { get; set; }
        public bool car { get; set; }


        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            XmrEnum objAsPart = obj as XmrEnum;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }
        public override int GetHashCode()
        {
            return id;
        }
        public bool Equals(XmrEnum other)
        {
            if (other == null) return false;
            return (this.id.Equals(other.id));
        }
    }

    public static int MAX_RADIOS = 50;
    public static List<XmrEnum> xmr_playing = new List<XmrEnum>();
    //public static List<dynamic> xmr_radios = new List<dynamic>();

    public XMR()
    {
        //http://yp.shoutcast.com/sbin/tunein-station.m3u?id=1357102
        // Genre Name 

       // xmr_radios.Add(new { Name = "Teste", Genre = "Teste", Stream = "http://tunein4.streamguys1.com/hhbeafree5" });

 
        for (int i = 0; i < MAX_RADIOS; i++)
        {
            xmr_playing.Add(new XmrEnum { id = i, x =  0, y = 0, z = 0, stream = null, carid = null, car = false});
        }

    }

    public static void OnPlayerConnected(Client player)
    {
       // player.TriggerEvent("LoadXMR", NAPI.Util.ToJson(xmr_playing));
    }

    [RemoteEvent("VehicleID")]
    public static void VehicleID(Vehicle vehicle, int vehicle_id)
    {
        vehicle.SetData("veh_id", vehicle_id);
    }

    [Command("setstation2")]
    public static void Command(Client player, string text)
    {
        PlayVehicleRadio(player, "http://listen.trancebase.fm/tunein-mp3-pls");

    }



    public static void UpdateRadio(Client player)
    {
        List<dynamic> xmr_radios = new List<dynamic>();
        for (int i = 0; i < MAX_RADIOS; i++)
        {
            if (xmr_playing[i].stream != null)
            {

                if(xmr_playing[i].car == true)
                {
                    xmr_radios.Add(new { id = i, x = player.Position.X, y = player.Position.Y, z = player.Position.Z, stream = xmr_playing[i].stream, carid = player.Vehicle.Handle });
                }
                else
                {
                    xmr_radios.Add(new { id = i, x = player.Position.X, y = player.Position.Y, z = player.Position.Z, stream = xmr_playing[i].stream, carid = "null" });
                }
            }
        }
        player.TriggerEvent("LoadXMR", NAPI.Util.ToJson(xmr_radios));

    }

    public static void PlayVehicleRadio(Client player, string stream)
    {
        if(player.IsInVehicle)
        {
            for(int i = 0; i < MAX_RADIOS; i++)
            {
                if (xmr_playing[i].stream == null)
                {
                    xmr_playing[i].stream = stream;
                    player.TriggerEvent("AddRadio", i, player.Position.X, player.Position.Y, player.Position.Z, stream, player.Vehicle.Handle);
                    xmr_playing.Add(new XmrEnum { id = i, x = player.Position.X, y = player.Position.Y, z = player.Position.Z, stream = stream, carid = player.Vehicle.Handle, car = true });
                    UpdateRadio(player);
                    return;
                }
            }
        }
        else
        {
            for (int i = 0; i < MAX_RADIOS; i++)
            {
                if (xmr_playing[i].stream == null)
                {
                    xmr_playing[i].stream = stream;
                    player.TriggerEvent("AddRadio", i, player.Position.X, player.Position.Y, player.Position.Z, stream, null);
                    xmr_playing.Add(new XmrEnum { id = i, x = player.Position.X, y = player.Position.Y, z = player.Position.Z, stream = stream, carid = null, car = false });
                    UpdateRadio(player);
                    return;
                }
            }
        }
    }

    [RemoteEvent("SelectionRadioStationByName")]
    public static void SelectionRadioStationByName(Client player, string text)
    {

        PlayVehicleRadio(player, "Teste");
    }
}

