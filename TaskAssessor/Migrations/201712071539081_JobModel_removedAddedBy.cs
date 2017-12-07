namespace TaskAssessor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JobModel_removedAddedBy : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Jobs", "AddedBy");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Jobs", "AddedBy", c => c.String());
        }
    }
}
