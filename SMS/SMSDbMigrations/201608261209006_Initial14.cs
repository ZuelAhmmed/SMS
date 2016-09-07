namespace SMS.SMSDbMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial14 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CourseGroups",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CourseId = c.String(maxLength: 128),
                        GroupId = c.String(),
                        TeacherId = c.String(maxLength: 128),
                        TeacherId1 = c.String(),
                        TeacherId2 = c.String(),
                        Capacity = c.Int(),
                        StudentCount = c.Int(),
                        ClassId = c.String(maxLength: 128),
                        SectionGroup = c.String(),
                        DayTimeSlot = c.String(),
                        Sex = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ClassOrYears", t => t.ClassId)
                .ForeignKey("dbo.CourseContents", t => t.CourseId)
                .ForeignKey("dbo.EmployeeAccounts", t => t.TeacherId)
                .Index(t => t.CourseId)
                .Index(t => t.TeacherId)
                .Index(t => t.ClassId);
            
            CreateTable(
                "dbo.CourseContents",
                c => new
                    {
                        CourseId = c.String(nullable: false, maxLength: 128),
                        CourseName = c.String(nullable: false),
                        CourseLevel = c.String(),
                        CourseType = c.Int(),
                        ClassId = c.String(),
                        CourseCatagory = c.String(),
                    })
                .PrimaryKey(t => t.CourseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseGroups", "TeacherId", "dbo.EmployeeAccounts");
            DropForeignKey("dbo.CourseGroups", "CourseId", "dbo.CourseContents");
            DropForeignKey("dbo.CourseGroups", "ClassId", "dbo.ClassOrYears");
            DropIndex("dbo.CourseGroups", new[] { "ClassId" });
            DropIndex("dbo.CourseGroups", new[] { "TeacherId" });
            DropIndex("dbo.CourseGroups", new[] { "CourseId" });
            DropTable("dbo.CourseContents");
            DropTable("dbo.CourseGroups");
        }
    }
}
