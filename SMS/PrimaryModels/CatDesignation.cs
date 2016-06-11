using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS.PrimaryModels
{
    public static class CatDesignation
    {
        public static List<string> GetCatagoryList()
        {
            List<string> catagoryList = new List<string>();
            catagoryList.Add(HeadMaster);
            catagoryList.Add(AssHeadMaster);
            catagoryList.Add(AssTeacher);
            catagoryList.Add(Librarian);
            catagoryList.Add(LabAssiant);
            catagoryList.Add(ThirdClass);
            catagoryList.Add(FourthClass);
            catagoryList.Add(HeadMaolana);
            catagoryList.Add(Atc);
            return catagoryList;
        } 
        public const string HeadMaster = "Headmaster";
        public const string AssHeadMaster = "Assistant Headmaster";
        public const string AssTeacher = "Assistant Teacher";
        public const string Librarian = "Librarian";
        public const string LabAssiant = "Laboratory Assiant";
        public const string ThirdClass = "Third Class";
        public const string FourthClass = "Fourth Class";
        public const string Atc = "ATC";
        public const string HeadMaolana = "Head Maolana";

    }
}