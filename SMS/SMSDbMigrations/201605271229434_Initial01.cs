namespace SMS.SMSDbMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial01 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "NidOrBirthRegNo", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "SecurityRole", c => c.String(nullable: false));
            DropColumn("dbo.StudentApplications", "UserName");
            DropColumn("dbo.StudentApplications", "Password");
            DropColumn("dbo.EmployeeAccounts", "UserName");
            DropColumn("dbo.EmployeeAccounts", "Password");
            DropColumn("dbo.EmployeeApplications", "UserName");
            DropColumn("dbo.EmployeeApplications", "Password");
            DropColumn("dbo.GuardianAccounts", "UserName");
            DropColumn("dbo.GuardianAccounts", "Password");
            DropColumn("dbo.StudentAccounts", "UserName");
            DropColumn("dbo.StudentAccounts", "Password");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StudentAccounts", "Password", c => c.String(nullable: false, maxLength: 15));
            AddColumn("dbo.StudentAccounts", "UserName", c => c.String(nullable: false, maxLength: 17));
            AddColumn("dbo.GuardianAccounts", "Password", c => c.String(nullable: false, maxLength: 15));
            AddColumn("dbo.GuardianAccounts", "UserName", c => c.String(nullable: false, maxLength: 17));
            AddColumn("dbo.EmployeeApplications", "Password", c => c.String(nullable: false, maxLength: 15));
            AddColumn("dbo.EmployeeApplications", "UserName", c => c.String(nullable: false, maxLength: 17));
            AddColumn("dbo.EmployeeAccounts", "Password", c => c.String(nullable: false, maxLength: 15));
            AddColumn("dbo.EmployeeAccounts", "UserName", c => c.String(nullable: false, maxLength: 17));
            AddColumn("dbo.StudentApplications", "Password", c => c.String(nullable: false, maxLength: 15));
            AddColumn("dbo.StudentApplications", "UserName", c => c.String(nullable: false, maxLength: 17));
            DropColumn("dbo.AspNetUsers", "SecurityRole");
            DropColumn("dbo.AspNetUsers", "NidOrBirthRegNo");
        }
    }
}
