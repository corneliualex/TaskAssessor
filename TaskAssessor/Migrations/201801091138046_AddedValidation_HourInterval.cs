namespace TaskAssessor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedValidation_HourInterval : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.HourIntervals", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.HourIntervals", "Description", c => c.String());
        }
    }
}
