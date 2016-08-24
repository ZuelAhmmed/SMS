namespace SMS.SMSDbMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial11 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RoomInformations",
                c => new
                    {
                        RmRoomId = c.Long(nullable: false, identity: true),
                        RmRoomNo = c.String(),
                        RmFloorNo = c.String(),
                        RmCapacity = c.Int(),
                        RmDescription = c.String(),
                        RmCampus = c.Long(),
                    })
                .PrimaryKey(t => t.RmRoomId);
            
            CreateTable(
                "dbo.ScheduleInformations",
                c => new
                    {
                        ShScheduleId = c.Long(nullable: false, identity: true),
                        RmRoomId = c.Long(nullable: false),
                        ShClass = c.String(),
                        ShDay = c.String(),
                        ShFromTime = c.DateTime(),
                        ShToTime = c.DateTime(),
                        ShCourse = c.String(),
                        ShSection = c.String(),
                    })
                .PrimaryKey(t => t.ShScheduleId)
                .ForeignKey("dbo.RoomInformations", t => t.RmRoomId, cascadeDelete: true)
                .Index(t => t.RmRoomId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ScheduleInformations", "RmRoomId", "dbo.RoomInformations");
            DropIndex("dbo.ScheduleInformations", new[] { "RmRoomId" });
            DropTable("dbo.ScheduleInformations");
            DropTable("dbo.RoomInformations");
        }
    }
}
