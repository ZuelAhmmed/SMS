using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS.PrimaryModels
{
    public static class CatGroup
    {
        public static List<string> GetCatagoryList()
        {
            List<string> catagoryList = new List<string>();
            catagoryList.Add(None);
            catagoryList.Add(All);
            catagoryList.Add(Humanities);
            catagoryList.Add(Commerce);
            catagoryList.Add(Science);
            catagoryList.Add(HomeEconomic);
            catagoryList.Add(IslamicStudy);
            return catagoryList;
        } 
        public const string None = "Node";
        public const string All = "All";
        public const string Humanities = "Humanities";
        public const string Commerce = "Business Studies";
        public const string Science = "Science";
        public const string HomeEconomic = "Home Economics";
        public const string IslamicStudy = "Islamic Studies";
    }
}