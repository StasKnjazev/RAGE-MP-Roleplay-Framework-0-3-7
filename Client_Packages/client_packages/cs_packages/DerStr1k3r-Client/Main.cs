using System;
using System.Collections.Generic;
using RAGE;
using RAGE.Elements;
using Newtonsoft.Json;
using RAGE.NUI;

class Main : Events.Script
{

    public class RobberyNPCEnum : IEquatable<RobberyNPCEnum>
    {
        public int id { get; set; }

        public string name { get; set; }
        public RAGE.Elements.Ped ped { get; set; }
        public int state { get; set; }

        public override int GetHashCode()
        {
            return id;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            RobberyNPCEnum objAsPart = obj as RobberyNPCEnum;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }

        public bool Equals(RobberyNPCEnum other)
        {
            if (other == null) return false;
            return (this.id.Equals(other.id));
        }

        public void SetRoberyState(int arr_state)
        {
            state = arr_state;

            if(state == 1)
            {
                ped.TaskHandsUp(-1, ped.Handle, -1, true);
            }
            else
            {
                ped.ClearTasks();
            }
        }
    }
    public static List<RobberyNPCEnum> robbery_npc = new List<RobberyNPCEnum>();
	
    public Main()
    {
        Events.Add("CreateRobberyNPC", CreateRobberyNPC);
        Events.Add("SetRobberyState", SetRobberyState);
        Events.Add("Notify", Notify);

        Events.Add("Get_Mod_Menu", ModMenu);
 
        RAGE.Events.Tick += Tick;
    }

    public static void ModMenu(object[] args)
    {
        List<dynamic> menu_item_list = new List<dynamic>();

        for (int i = 0; i < Player.LocalPlayer.Vehicle.GetNumMods((int)args[0]); i++)
        {
            menu_item_list.Add(new { Label = RAGE.Game.Ui.GetLabelText(Player.LocalPlayer.Vehicle.GetModTextLabel((int)args[0], i)), modType = (int)args[0], modValue = i });

        }
        Events.CallRemote("Create_Submenu_Mod", JsonConvert.SerializeObject(menu_item_list), args[1].ToString());
    }

    public static void Notify(object[] args)
    {
        RAGE.Game.Ui.SetNotificationTextEntry("STRING");
        RAGE.Game.Ui.AddTextComponentSubstringPlayerName(args[0].ToString());
        RAGE.Game.Ui.DrawNotification(false, false);
    }

    public static void CreateRobberyNPC(object[] args)
    {
        uint freeroamHash = RAGE.Game.Misc.GetHashKey(args[1].ToString());
        RAGE.Elements.Ped temp_ped = new RAGE.Elements.Ped(freeroamHash, (RAGE.Vector3)args[2], heading: (float)args[3], dimension: 0);

        robbery_npc.Add(new RobberyNPCEnum { name = args[0].ToString(), ped = temp_ped, state = 0, id = (int)args[4] });
    }

    public static void SetRobberyState(object[] args)
    {
        foreach (var ped in robbery_npc)
        {
            if (ped.name == args[0].ToString())
            {
                ped.SetRoberyState((int)args[1]);
            }
        }
    }
    
    public static long LatestProcess = 0;


    public void Tick(System.Collections.Generic.List<RAGE.Events.TickNametagData> nametags)
    {
        
        int index = -1;
        foreach (var ped in robbery_npc)
        {
            if (RAGE.Game.Player.IsPlayerFreeAimingAtEntity(ped.ped.Handle) == true)
            {
                index = ped.id;
            }
        }

        if ((int)Player.LocalPlayer.GetSharedData("Player_Aiming_To") != index)
        {
            RAGE.Events.CallRemote("Players_Aiming_To", index);
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