using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS.PrimaryModels
{
    public class CatEducationLevel
    {
        public static List<string> GetCatagoryList()
        {
            List<string> catagoryList = new List<string>();
            catagoryList.Add(Primary);
            catagoryList.Add(Secondary);
            catagoryList.Add(HigherSecondary);
            catagoryList.Add(HonoursOrDegree);
            catagoryList.Add(Masters);
            catagoryList.Add(Phd);
            return catagoryList;
        } 


        public const string Primary = "Primary";
        public const string Secondary = "Secondary";
        public const string HigherSecondary = "Higher Secondary";
        public const string HonoursOrDegree = "Honour's/Degree";
        public const string Masters = "Masters";
        public const string Phd = "PHD";
    }
}