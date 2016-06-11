using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS.PrimaryModels
{
    public static class CatConfirmation
    {
        public static List<string> GetCatagoryList()
        {
            List<string> catagoryList = new List<string>();
            catagoryList.Add(Yes);
            catagoryList.Add(No);
            catagoryList.Add(Pending);
            return catagoryList;
        }

        public const string Yes = "Yes";
        public const string No = "No";
        public const string Pending = "Pending";

    }
}