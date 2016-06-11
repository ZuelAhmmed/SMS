namespace SMS.SMSDbMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial8 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.EmployeeEducationalQualifications", newName: "StudentEducationalQualifications");
            CreateTable(
                "dbo.EmployeeEducationalQualifications",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        NidOrBirtgRegNo = c.String(),
                        EducationLevelId = c.String(),
                        ExamOrDegree = c.String(),
                        BoardOrUniversity = c.String(),
                        MajorSubjectId = c.String(),
                        InstituteName = c.String(),
                        CourseDuration = c.String(),
                        PassingYear = c.String(),
                        GpaOrDivison = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.StudentEducationalQualifications", "EducationLevelId");
            DropColumn("dbo.StudentEducationalQualifications", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StudentEducationalQualifications", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.StudentEducationalQualifications", "EducationLevelId", c => c.String());
            DropTable("dbo.EmployeeEducationalQualifications");
            RenameTable(name: "dbo.StudentEducationalQualifications", newName: "EmployeeEducationalQualifications");
        }
    }
}
