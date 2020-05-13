namespace Vidli.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenre1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.MovieModels", "GenreId", c => c.Byte(nullable: false));
            CreateIndex("dbo.MovieModels", "GenreId");
            AddForeignKey("dbo.MovieModels", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
            //DropColumn("dbo.MovieModels", "Genre");
        }
        
        public override void Down()
        {
            //AddColumn("dbo.MovieModels", "Genre", c => c.String());
            DropForeignKey("dbo.MovieModels", "GenreId", "dbo.Genres");
            DropIndex("dbo.MovieModels", new[] { "GenreId" });
            DropColumn("dbo.MovieModels", "GenreId");
            DropTable("dbo.Genres");
        }
    }
}
