namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'ac562dd1-f19c-4d7b-b743-67ce0e9517b0', N'CanManageMovies')
            ");
        }
        
        public override void Down()
        {
        }
    }
}
