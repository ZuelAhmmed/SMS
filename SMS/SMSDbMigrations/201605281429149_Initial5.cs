namespace SMS.SMSDbMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.StudentAccounts", "ConfirmDate", c => c.DateTime());
            AlterColumn("dbo.StudentAccounts", "PassingYear", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.StudentAccounts", "PassingYear", c => c.DateTime(nullable: false));
            AlterColumn("dbo.StudentAccounts", "ConfirmDate", c => c.DateTime(nullable: false));
        }
    }
}
