namespace Vidli.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenre : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres VALUES (1, 'Horror')");
            Sql("INSERT INTO Genres VALUES (2, 'Howdy')");
            Sql("INSERT INTO Genres VALUES (3, 'Comedy')");
        }
        
        public override void Down()
        {
        }
    }
}
