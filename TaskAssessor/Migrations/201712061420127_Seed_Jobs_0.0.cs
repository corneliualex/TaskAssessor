namespace TaskAssessor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Seed_Jobs_00 : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO Jobs(Name,DateAdded,AddedBy) VALUES('Task1','" + DateTime.Now + "','admin')");
            Sql(@"INSERT INTO Jobs(Name,DateAdded,AddedBy) VALUES('Task2','" + DateTime.Now.AddHours(-1) + "','admin')");
            Sql(@"INSERT INTO Jobs(Name,DateAdded,AddedBy) VALUES('Task3','" + DateTime.Now.AddHours(-2) + "','admin')");
        }

        public override void Down()
        {
        }
    }
}
