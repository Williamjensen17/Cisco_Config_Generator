using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchConfigGenerator.Core
{


    // public class Port
    //{
    //
    //    public int ID { get; set; }
    //    public string? Description { get; set; }
    //
    //    public bool? IsEnabled { get; set; }
    //
    //    public Port(int id, string description, bool isenabled)
    //    {
    //        ID = id;
    //        Description = description;
    //        IsEnabled = isenabled;
    //    }
    //}


    public static class Variables
    {


        public static int? currentport = null;

        public static bool isLoading = false;


        //bool
        public static bool?[] portActive = new bool?[24];


        //string
        public static string?[] portDesc = new string?[24];








    }
}
