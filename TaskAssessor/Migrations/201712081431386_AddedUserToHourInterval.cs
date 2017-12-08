namespace TaskAssessor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUserToHourInterval : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HourIntervals", "ApplicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.HourIntervals", "ApplicationUserId");
            AddForeignKey("dbo.HourIntervals", "ApplicationUserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HourIntervals", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.HourIntervals", new[] { "ApplicationUserId" });
            DropColumn("dbo.HourIntervals", "ApplicationUserId");
        }
    }
}
