namespace SMS.SMSDbMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.StudentApplications", "NidOrBirtgRegNo", c => c.String());
            AlterColumn("dbo.StudentApplications", "MobileNumber", c => c.String(maxLength: 11));
            AlterColumn("dbo.StudentApplications", "FirstName", c => c.String());
            AlterColumn("dbo.StudentApplications", "LasttName", c => c.String());
            AlterColumn("dbo.EmployeeAccounts", "NidOrBirtgRegNo", c => c.String());
            AlterColumn("dbo.EmployeeAccounts", "MobileNumber", c => c.String(maxLength: 11));
            AlterColumn("dbo.EmployeeAccounts", "FirstName", c => c.String());
            AlterColumn("dbo.EmployeeAccounts", "LasttName", c => c.String());
            AlterColumn("dbo.EmployeeApplications", "NidOrBirtgRegNo", c => c.String());
            AlterColumn("dbo.EmployeeApplications", "MobileNumber", c => c.String(maxLength: 11));
            AlterColumn("dbo.EmployeeApplications", "FirstName", c => c.String());
            AlterColumn("dbo.EmployeeApplications", "LasttName", c => c.String());
            AlterColumn("dbo.GuardianAccounts", "NidOrBirtgRegNo", c => c.String());
            AlterColumn("dbo.GuardianAccounts", "MobileNumber", c => c.String(maxLength: 11));
            AlterColumn("dbo.GuardianAccounts", "FirstName", c => c.String());
            AlterColumn("dbo.GuardianAccounts", "LasttName", c => c.String());
            AlterColumn("dbo.StudentAccounts", "NidOrBirtgRegNo", c => c.String());
            AlterColumn("dbo.StudentAccounts", "MobileNumber", c => c.String(maxLength: 11));
            AlterColumn("dbo.StudentAccounts", "FirstName", c => c.String());
            AlterColumn("dbo.StudentAccounts", "LasttName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.StudentAccounts", "LasttName", c => c.String(nullable: false));
            AlterColumn("dbo.StudentAccounts", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.StudentAccounts", "MobileNumber", c => c.String(nullable: false, maxLength: 11));
            AlterColumn("dbo.StudentAccounts", "NidOrBirtgRegNo", c => c.String(nullable: false));
            AlterColumn("dbo.GuardianAccounts", "LasttName", c => c.String(nullable: false));
            AlterColumn("dbo.GuardianAccounts", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.GuardianAccounts", "MobileNumber", c => c.String(nullable: false, maxLength: 11));
            AlterColumn("dbo.GuardianAccounts", "NidOrBirtgRegNo", c => c.String(nullable: false));
            AlterColumn("dbo.EmployeeApplications", "LasttName", c => c.String(nullable: false));
            AlterColumn("dbo.EmployeeApplications", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.EmployeeApplications", "MobileNumber", c => c.String(nullable: false, maxLength: 11));
            AlterColumn("dbo.EmployeeApplications", "NidOrBirtgRegNo", c => c.String(nullable: false));
            AlterColumn("dbo.EmployeeAccounts", "LasttName", c => c.String(nullable: false));
            AlterColumn("dbo.EmployeeAccounts", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.EmployeeAccounts", "MobileNumber", c => c.String(nullable: false, maxLength: 11));
            AlterColumn("dbo.EmployeeAccounts", "NidOrBirtgRegNo", c => c.String(nullable: false));
            AlterColumn("dbo.StudentApplications", "LasttName", c => c.String(nullable: false));
            AlterColumn("dbo.StudentApplications", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.StudentApplications", "MobileNumber", c => c.String(nullable: false, maxLength: 11));
            AlterColumn("dbo.StudentApplications", "NidOrBirtgRegNo", c => c.String(nullable: false));
        }
    }
}
