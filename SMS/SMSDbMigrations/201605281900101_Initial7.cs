namespace SMS.SMSDbMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial7 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EmployeeEducationalQualifications", "EducationLevelId", "dbo.EducationLevels");
            DropIndex("dbo.EmployeeEducationalQualifications", new[] { "EducationLevelId" });
            DropPrimaryKey("dbo.EmployeeEducationalQualifications");
            AddColumn("dbo.EmployeeEducationalQualifications", "ExamOrDegree", c => c.String());
            AlterColumn("dbo.EmployeeEducationalQualifications", "Id", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.EmployeeEducationalQualifications", "NidOrBirtgRegNo", c => c.String());
            AlterColumn("dbo.EmployeeEducationalQualifications", "EducationLevelId", c => c.String());
            AlterColumn("dbo.EmployeeEducationalQualifications", "BoardOrUniversity", c => c.String());
            AlterColumn("dbo.EmployeeEducationalQualifications", "MajorSubjectId", c => c.String());
            AlterColumn("dbo.EmployeeEducationalQualifications", "InstituteName", c => c.String());
            AlterColumn("dbo.EmployeeEducationalQualifications", "PassingYear", c => c.String());
            AlterColumn("dbo.EmployeeEducationalQualifications", "GpaOrDivison", c => c.String());
            AddPrimaryKey("dbo.EmployeeEducationalQualifications", "Id");
            DropColumn("dbo.EmployeeEducationalQualifications", "ExamOrDegreeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EmployeeEducationalQualifications", "ExamOrDegreeId", c => c.String(nullable: false));
            DropPrimaryKey("dbo.EmployeeEducationalQualifications");
            AlterColumn("dbo.EmployeeEducationalQualifications", "GpaOrDivison", c => c.String(nullable: false));
            AlterColumn("dbo.EmployeeEducationalQualifications", "PassingYear", c => c.String(nullable: false));
            AlterColumn("dbo.EmployeeEducationalQualifications", "InstituteName", c => c.String(nullable: false));
            AlterColumn("dbo.EmployeeEducationalQualifications", "MajorSubjectId", c => c.String(nullable: false));
            AlterColumn("dbo.EmployeeEducationalQualifications", "BoardOrUniversity", c => c.String(nullable: false));
            AlterColumn("dbo.EmployeeEducationalQualifications", "EducationLevelId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.EmployeeEducationalQualifications", "NidOrBirtgRegNo", c => c.String(nullable: false));
            AlterColumn("dbo.EmployeeEducationalQualifications", "Id", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.EmployeeEducationalQualifications", "ExamOrDegree");
            AddPrimaryKey("dbo.EmployeeEducationalQualifications", "Id");
            CreateIndex("dbo.EmployeeEducationalQualifications", "EducationLevelId");
            AddForeignKey("dbo.EmployeeEducationalQualifications", "EducationLevelId", "dbo.EducationLevels", "EducationLevelCode", cascadeDelete: true);
        }
    }
}
