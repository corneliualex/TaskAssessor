namespace TaskAssessor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedHourIntervalModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HourIntervals", "DateAdded", c => c.DateTime(nullable: false));
            AddColumn("dbo.HourIntervals", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.HourIntervals", "Description");
            DropColumn("dbo.HourIntervals", "DateAdded");
        }
    }
}
