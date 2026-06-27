using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchConfigGenerator.Core
{
    public class Vlan
    {
        public int ID { get; set; }
        public string? Name { get; set; }

        public static List<Vlan> Vlans { get;} = new List<Vlan>();
        public static Vlan AddVlan(int id, string name)
        {
            var vlan = new Vlan { ID = id, Name = name };
            Vlans.Add(vlan);



            return (vlan);
        }

        public Vlan() { }

        public Vlan(int id, string? name = null)
        {
            ID = id;
            Name = name;
        }

        public override string ToString()
        {
            return $"{ID} - {Name}";
        }

    }
}
