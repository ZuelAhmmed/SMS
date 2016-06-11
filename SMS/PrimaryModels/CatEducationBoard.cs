using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS.PrimaryModels
{
    public static class CatEducationBoard
    {
        public static List<string> GetCatagoryList()
        {
            List<string> catagoryList = new List<string>();
            catagoryList.Add(Dhaka);
            catagoryList.Add(Chittagong);
            catagoryList.Add(Rajshahi);
            catagoryList.Add(Jessore);
            catagoryList.Add(Barishal);
            catagoryList.Add(Madrasah);
            catagoryList.Add(Technical);
            catagoryList.Add(Comilla);
            catagoryList.Add(Dinajpur);
            catagoryList.Add(Sylhet);
            catagoryList.Add(OpenUniv);
            return catagoryList;
        } 

        public const string Dhaka = "Dhaka";
        public const string Chittagong = "Chittagong";
        public const string Rajshahi = "Rajshahi";
        public const string Jessore = "Jessore";
        public const string Barishal = "Barishal";
        public const string Madrasah = "Madrasah";
        public const string Technical = "Technical";
        public const string Comilla = "Comilla";
        public const string Dinajpur = "Dinajpur";
        public const string Sylhet = "Sylhet";
        public const string OpenUniv = "Bangladesh Open University";
    }
}