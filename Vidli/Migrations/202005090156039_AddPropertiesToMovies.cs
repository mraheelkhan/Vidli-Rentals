namespace Vidli.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPropertiesToMovies : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.MovieModels", "Genre", c => c.String());
            AddColumn("dbo.MovieModels", "ReleaseDate", c => c.DateTime());
            AddColumn("dbo.MovieModels", "DateAdded", c => c.DateTime());
            AddColumn("dbo.MovieModels", "NumberInStock", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MovieModels", "NumberInStock");
            DropColumn("dbo.MovieModels", "DateAdded");
            DropColumn("dbo.MovieModels", "ReleaseDate");
            //DropColumn("dbo.MovieModels", "Genre");
        }
    }
}
