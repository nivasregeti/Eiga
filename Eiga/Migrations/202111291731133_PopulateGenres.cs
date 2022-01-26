namespace Eiga.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id,GenreName) VALUES (1,'Adventure-Fiction')");
            Sql("INSERT INTO Genres (Id,GenreName) VALUES (2,'Sci-Fi')");
            Sql("INSERT INTO Genres (Id,GenreName) VALUES (3,'Sport-Drama')");
            Sql("INSERT INTO Genres (Id,GenreName) VALUES (4,'Comedy-Romance')");
        }
        
        public override void Down()
        {
        }
    }
}
