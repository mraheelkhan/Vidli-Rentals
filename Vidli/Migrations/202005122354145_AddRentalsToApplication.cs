namespace Vidli.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRentalsToApplication : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RentalModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateRented = c.DateTime(nullable: false),
                        DateReturned = c.DateTime(),
                        Customer_Id = c.Int(nullable: false),
                        Movie_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CustomerModels", t => t.Customer_Id, cascadeDelete: true)
                .ForeignKey("dbo.MovieModels", t => t.Movie_Id, cascadeDelete: true)
                .Index(t => t.Customer_Id)
                .Index(t => t.Movie_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RentalModels", "Movie_Id", "dbo.MovieModels");
            DropForeignKey("dbo.RentalModels", "Customer_Id", "dbo.CustomerModels");
            DropIndex("dbo.RentalModels", new[] { "Movie_Id" });
            DropIndex("dbo.RentalModels", new[] { "Customer_Id" });
            DropTable("dbo.RentalModels");
        }
    }
}
