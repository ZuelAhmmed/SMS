namespace SMS.SMSDbMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial6 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.StudentApplications", "DateOfBirth", c => c.DateTime());
            AlterColumn("dbo.EmployeeAccounts", "DateOfBirth", c => c.DateTime());
            AlterColumn("dbo.EmployeeApplications", "DateOfBirth", c => c.DateTime());
            AlterColumn("dbo.GuardianAccounts", "DateOfBirth", c => c.DateTime());
            AlterColumn("dbo.StudentAccounts", "DateOfBirth", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.StudentAccounts", "DateOfBirth", c => c.DateTime(nullable: false));
            AlterColumn("dbo.GuardianAccounts", "DateOfBirth", c => c.DateTime(nullable: false));
            AlterColumn("dbo.EmployeeApplications", "DateOfBirth", c => c.DateTime(nullable: false));
            AlterColumn("dbo.EmployeeAccounts", "DateOfBirth", c => c.DateTime(nullable: false));
            AlterColumn("dbo.StudentApplications", "DateOfBirth", c => c.DateTime(nullable: false));
        }
    }
}
