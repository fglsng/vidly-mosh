namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMovies : DbMigration
    {
        public override void Up()
        {
            var now = DateTime.Now;
            var then = new DateTime(1980, 1, 1);

            Sql(String.Format("INSERT INTO Movies (Name, ReleaseDate, DateAdded, Stock, GenreTypeId) VALUES ('Hangover', '{0}', '{1}', 5, 1)", then, now));
            Sql(String.Format("INSERT INTO Movies (Name, ReleaseDate, DateAdded, Stock, GenreTypeId) VALUES ('Die Hard', '{0}', '{1}', 3, 2)", then, now));
            Sql(String.Format("INSERT INTO Movies (Name, ReleaseDate, DateAdded, Stock, GenreTypeId) VALUES ('The Terminator', '{0}', '{1}', 8, 2)", then, now));
            Sql(String.Format("INSERT INTO Movies (Name, ReleaseDate, DateAdded, Stock, GenreTypeId) VALUES ('Toy Story', '{0}', '{1}', 2, 3)", then, now));
            Sql(String.Format("INSERT INTO Movies (Name, ReleaseDate, DateAdded, Stock, GenreTypeId) VALUES ('Titanic', '{0}', '{1}', 17, 4)", then, now));
        }
        
        public override void Down()
        {
        }
    }
}
