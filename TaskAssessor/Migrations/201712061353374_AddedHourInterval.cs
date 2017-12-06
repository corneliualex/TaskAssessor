namespace TaskAssessor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedHourInterval : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HourIntervals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TimeStarted = c.Time(nullable: false, precision: 7),
                        TimeEnded = c.Time(nullable: false, precision: 7),
                        JobId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Jobs", t => t.JobId, cascadeDelete: true)
                .Index(t => t.JobId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HourIntervals", "JobId", "dbo.Jobs");
            DropIndex("dbo.HourIntervals", new[] { "JobId" });
            DropTable("dbo.HourIntervals");
        }
    }
}
