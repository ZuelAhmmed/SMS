using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SMS.Models;

namespace SMS.PrimaryModels
{
    public static class CatAddress
    {
        public static List<string> GetCatagoryList() 
        {
            List<string> catagoryList = new List<string>(); 
            catagoryList.Add(Present);
            catagoryList.Add(Permanent);
            return catagoryList;
        }
 
        public const string Present = "Present Address";
        public const string Permanent = "Permanent Address";
    }
}