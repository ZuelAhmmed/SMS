namespace SMS.SMSDbMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial02 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StudentAccounts", "StudentConfirmId", "dbo.ConfirmationCatagories");
            DropIndex("dbo.StudentAccounts", new[] { "StudentConfirmId" });
            AddColumn("dbo.StudentAccounts", "StudentConfirm", c => c.String());
            DropColumn("dbo.StudentAccounts", "StudentConfirmId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StudentAccounts", "StudentConfirmId", c => c.String(maxLength: 128));
            DropColumn("dbo.StudentAccounts", "StudentConfirm");
            CreateIndex("dbo.StudentAccounts", "StudentConfirmId");
            AddForeignKey("dbo.StudentAccounts", "StudentConfirmId", "dbo.ConfirmationCatagories", "Code");
        }
    }
}
