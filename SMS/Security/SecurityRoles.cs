using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace SMS.Security
{
    public static class SecurityRoles
    {
        public static List<string> GetRoleList()
        {
            List<string> roleList = new List<string>();
            roleList.Add(Developer);
            roleList.Add(Admin);
            roleList.Add(Teacher);
            roleList.Add(Librarian);
            roleList.Add(LabAssistant);
            roleList.Add(Guardian);
            roleList.Add(Student);
            roleList.Add(Support);
            return roleList;
        }

        public const string Developer = "Developer";
        public const string Admin = "Admin";
        public const string Support = "Support";
        public const string Teacher = "Teacher";
        public const string Librarian = "Librarian";
        public const string LabAssistant = "Lab Assistant";
        public const string ThirdClass = "Third Class";
        public const string FourthClass = "Fourth Class";
        public const string Guardian = "Guardian";
        public const string Student = "Student";
    }
}