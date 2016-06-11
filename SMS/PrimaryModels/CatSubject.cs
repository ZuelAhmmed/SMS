using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS.PrimaryModels
{
    public static class CatSubject
    {
        public static List<string> GetCatagoryList()
        {
            List<string> catagoryList = new List<string>();
            catagoryList.Add(Compulsory);
            catagoryList.Add(Optional);
            return catagoryList;
        }

        public const string Compulsory = "Compulsory";
        public const string Optional = "Optional";
    }
}