using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using GTANetworkAPI;
using MySql.Data.MySqlClient;

public class BanAPI : Script
{
    public class CallEnum : IEquatable<CallEnum>
    {
        public int id { get; set; }

        public Client player_one { get; set; }
        public Client player_two { get; set; }

        public int active { get; set; }
        public int time { get; set; }


        public override int GetHashCode()
        {
            return id;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            CallEnum objAsPart = obj as CallEnum;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }

        public bool Equals(CallEnum other)
        {
            if (other == null) return false;
            return (this.id.Equals(other.id));
        }
    }

    public static List<CallEnum> call_data = new List<CallEnum>();
}
