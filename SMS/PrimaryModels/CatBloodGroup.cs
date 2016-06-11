using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS.PrimaryModels
{
    public class CatBloodGroup
    {
        public static List<string> GetCatagoryList()
        {
            List<string> catagoryList = new List<string>();
            catagoryList.Add(Op);
            catagoryList.Add(On);
            catagoryList.Add(Ap);
            catagoryList.Add(An);
            catagoryList.Add(Bp);
            catagoryList.Add(Bn);
            catagoryList.Add(ABp);
            catagoryList.Add(ABn);
            return catagoryList;
        }


        public const string Op = "O+";
        public const string On = "O-";
        public const string Ap = "A+";
        public const string An = "A-";
        public const string Bp = "B+";
        public const string Bn = "B-";
        public const string ABp = "AB+";
        public const string ABn = "AB-";
    }
}