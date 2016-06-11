namespace SMS.SMSDbMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial9 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StudentEducationalQualifications", "Group", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.StudentEducationalQualifications", "Group");
        }
    }
}
