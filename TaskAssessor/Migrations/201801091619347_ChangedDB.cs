namespace TaskAssessor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedDB : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.HourIntervals", "Description", c => c.String(nullable: false, maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.HourIntervals", "Description", c => c.String());
        }
    }
}
