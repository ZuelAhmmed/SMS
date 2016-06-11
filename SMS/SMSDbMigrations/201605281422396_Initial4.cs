namespace SMS.SMSDbMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.StudentApplications", "BloodGroup", c => c.String());
            AlterColumn("dbo.StudentApplications", "RegDateTime", c => c.DateTime());
            AlterColumn("dbo.StudentApplications", "LastLoginDateTime", c => c.DateTime());
            AlterColumn("dbo.EmployeeAccounts", "BloodGroup", c => c.String());
            AlterColumn("dbo.EmployeeAccounts", "RegDateTime", c => c.DateTime());
            AlterColumn("dbo.EmployeeAccounts", "LastLoginDateTime", c => c.DateTime());
            AlterColumn("dbo.EmployeeApplications", "BloodGroup", c => c.String());
            AlterColumn("dbo.EmployeeApplications", "RegDateTime", c => c.DateTime());
            AlterColumn("dbo.EmployeeApplications", "LastLoginDateTime", c => c.DateTime());
            AlterColumn("dbo.GuardianAccounts", "BloodGroup", c => c.String());
            AlterColumn("dbo.GuardianAccounts", "RegDateTime", c => c.DateTime());
            AlterColumn("dbo.GuardianAccounts", "LastLoginDateTime", c => c.DateTime());
            AlterColumn("dbo.StudentAccounts", "BloodGroup", c => c.String());
            AlterColumn("dbo.StudentAccounts", "RegDateTime", c => c.DateTime());
            AlterColumn("dbo.StudentAccounts", "LastLoginDateTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.StudentAccounts", "LastLoginDateTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.StudentAccounts", "RegDateTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.StudentAccounts", "BloodGroup", c => c.String(nullable: false));
            AlterColumn("dbo.GuardianAccounts", "LastLoginDateTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.GuardianAccounts", "RegDateTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.GuardianAccounts", "BloodGroup", c => c.String(nullable: false));
            AlterColumn("dbo.EmployeeApplications", "LastLoginDateTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.EmployeeApplications", "RegDateTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.EmployeeApplications", "BloodGroup", c => c.String(nullable: false));
            AlterColumn("dbo.EmployeeAccounts", "LastLoginDateTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.EmployeeAccounts", "RegDateTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.EmployeeAccounts", "BloodGroup", c => c.String(nullable: false));
            AlterColumn("dbo.StudentApplications", "LastLoginDateTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.StudentApplications", "RegDateTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.StudentApplications", "BloodGroup", c => c.String(nullable: false));
        }
    }
}
