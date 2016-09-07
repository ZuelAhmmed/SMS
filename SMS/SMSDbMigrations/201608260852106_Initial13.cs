namespace SMS.SMSDbMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial13 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ScheduleInformations", "Year", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ScheduleInformations", "Year");
        }
    }
}
