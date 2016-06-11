using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS.PrimaryModels
{
    public class CatClassOrYear
    {
        public static List<string> GetCatagoryList()
        {
            List<string> catagoryList = new List<string>();
            //catagoryList.Add(One);
            //catagoryList.Add(Two);
            //catagoryList.Add(Three);
            //catagoryList.Add(Four);
            //catagoryList.Add(Five);
            //catagoryList.Add(Psc);
            catagoryList.Add(Six);
            catagoryList.Add(Seven);
            catagoryList.Add(Eight);
            catagoryList.Add(Jsc);
            catagoryList.Add(Nine);
            catagoryList.Add(Ten);
            catagoryList.Add(Ssc);
            //catagoryList.Add(Eleven);
            //catagoryList.Add(Twelve);
            //catagoryList.Add(Hsc);
            return catagoryList;
        }

        public const string One = "One";
        public const string Two = "Two";
        public const string Three = "Three";
        public const string Four = "Four";
        public const string Five = "Five";
        public const string Psc = "PSC";
        public const string Six = "Six";
        public const string Seven = "Seven";
        public const string Eight = "Eight";
        public const string Jsc = "JSC";
        public const string Nine = "Nine";
        public const string Ten = "Ten";
        public const string Ssc = "SSC";
        public const string Eleven = "Eleven";
        public const string Twelve = "Twelve";
        public const string Hsc = "HSC";
    }
}