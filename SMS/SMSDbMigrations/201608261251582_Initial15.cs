namespace SMS.SMSDbMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial15 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CourseContents", "Group", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CourseContents", "Group");
        }
    }
}
