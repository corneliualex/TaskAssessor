namespace TaskAssessor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedHourInterval1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HourIntervals", "TotalTime", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.HourIntervals", "TotalTime");
        }
    }
}
