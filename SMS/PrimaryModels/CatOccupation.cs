using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS.PrimaryModels
{
    public static class CatOccupation
    {
        public static List<string> GetCatagoryList()
        {
            List<string> catagoryList = new List<string>();
            catagoryList.Add(Teacher);
            catagoryList.Add(Farmer);
            catagoryList.Add(GovtService);
            catagoryList.Add(RetGovtService);
            catagoryList.Add(PvtService);
            catagoryList.Add(RetPvtService);
            catagoryList.Add(Businessman);
            catagoryList.Add(HouseWife);
            return catagoryList;
        } 

        public const string Teacher = "Teacher";
        public const string Farmer = "Farmer";
        public const string GovtService = "Govt Service";
        public const string RetGovtService = "Govt Service (Retired)";
        public const string PvtService = "Private Service";
        public const string RetPvtService = "Private Service (Retired)";
        public const string Businessman = "Businessman";
        public const string HouseWife = "HouseWife";
       
    }
}