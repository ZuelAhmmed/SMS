namespace SMS.SMSDbMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.StudentApplications", "OccupationId", c => c.String());
            AlterColumn("dbo.EmployeeAccounts", "OccupationId", c => c.String());
            AlterColumn("dbo.EmployeeApplications", "OccupationId", c => c.String());
            AlterColumn("dbo.GuardianAccounts", "OccupationId", c => c.String());
            AlterColumn("dbo.StudentAccounts", "OccupationId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.StudentAccounts", "OccupationId", c => c.String(nullable: false));
            AlterColumn("dbo.GuardianAccounts", "OccupationId", c => c.String(nullable: false));
            AlterColumn("dbo.EmployeeApplications", "OccupationId", c => c.String(nullable: false));
            AlterColumn("dbo.EmployeeAccounts", "OccupationId", c => c.String(nullable: false));
            AlterColumn("dbo.StudentApplications", "OccupationId", c => c.String(nullable: false));
        }
    }
}
