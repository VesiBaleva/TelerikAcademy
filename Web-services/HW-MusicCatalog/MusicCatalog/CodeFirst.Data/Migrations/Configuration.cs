namespace CodeFirst.Data.Migrations
{
    using CodeFirst.Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<CodeFirst.Data.MusicCatalogContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(CodeFirst.Data.MusicCatalogContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var album = new Album { Title = "Thriller", Producer = "Quincy Jones", Year = 1982};

            context.Albums.AddOrUpdate(x=>x.Title,album);

            var artist=new Artist { Name = "Michael Jackson", Country = "USA", DateOfBirth = DateTime.Parse("1958-08-29"), AlbumId=album.Id};

            context.Artists.AddOrUpdate(x => x.Name, artist);

            context.Songs.AddOrUpdate(x => x.Title, new Song { Title = "The Girl Is Mine", Genre = "Pop", Year = 1997, ArtistId = artist.Id, AlbumId=album.Id});

            context.Songs.AddOrUpdate(x => x.Title, new Song { Title = "Billie Jean", Genre = "Pop", Year = 1998, ArtistId = artist.Id, AlbumId = album.Id });


        }
    }
}
