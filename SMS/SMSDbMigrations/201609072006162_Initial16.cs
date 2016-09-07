namespace SMS.SMSDbMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial16 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EmployeeEducationalQualifications", "RegNumber", c => c.String());
            AddColumn("dbo.EmployeeEducationalQualifications", "RollNumber", c => c.String());
            AddColumn("dbo.EmployeeEducationalQualifications", "Group", c => c.String());
            DropColumn("dbo.EmployeeEducationalQualifications", "EducationLevelId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EmployeeEducationalQualifications", "EducationLevelId", c => c.String());
            DropColumn("dbo.EmployeeEducationalQualifications", "Group");
            DropColumn("dbo.EmployeeEducationalQualifications", "RollNumber");
            DropColumn("dbo.EmployeeEducationalQualifications", "RegNumber");
        }
    }
}
