namespace TaskAssessor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Modify_Job_00 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Jobs", "DateModified", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Jobs", "DateModified", c => c.DateTime(nullable: false));
        }
    }
}
