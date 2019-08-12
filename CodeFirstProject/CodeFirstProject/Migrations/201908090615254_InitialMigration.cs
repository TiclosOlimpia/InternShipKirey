namespace CodeFirstProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Albums",
                c => new
                    {
                        IdAlbum = c.Int(nullable: false, identity: false),
                        NumeAlbum = c.String(),
                        IdArtist = c.Int(nullable: false),
                        IdGenMuzical = c.Int(nullable: false),
                        AnLansare = c.Int(nullable: false),
                        Numar = c.Int(nullable: false),
                        Pret = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.IdAlbum)
                .ForeignKey("dbo.Artists", t => t.IdArtist, cascadeDelete: true)
                .ForeignKey("dbo.GenMuzicals", t => t.IdGenMuzical, cascadeDelete: true)
                .Index(t => t.IdArtist)
                .Index(t => t.IdGenMuzical);

            Sql("INSERT into Albums values (1, 'pop', 21, 31, 1917, 5, 2.7)");
            Sql("INSERT into Albums values (2, 'rock', 22, 32, 1920, 7, 10.7)");
            Sql("INSERT into Albums values (3, 'pop', 21, 31, 2010, 10, 20.7)");
            Sql("INSERT into Albums values (4, 'dance', 23, 33, 2917, 100, 1000.7)");
            Sql("INSERT into Albums values (5, 'rock', 21, 32, 2017, 15, 180.23)");
            Sql("INSERT into Albums values (6, 'pop', 23, 31, 1998, 90, 190.7)");

            CreateTable(
                "dbo.Artists",
                c => new
                    {
                        IdArtist = c.Int(nullable: false, identity: false),
                        Nume = c.String(),
                        Prenume = c.String(),
                        NumeScena = c.String(),
                    })
                .PrimaryKey(t => t.IdArtist);

            Sql("INSERT into Artists values (21, 'Smiley', 'Andrei', 'ok')");
            Sql("INSERT into Artists values (22, 'Andra', 'Maruta', 'e bine')");
            Sql("INSERT into Artists values (23, 'Ion', 'Barbu', 'si ce')");
            Sql("INSERT into Artists values (24, 'Vasile', 'Costache', 'mama')");
            Sql("INSERT into Artists values (25, 'Miron', 'Costin', 'haha')");
            Sql("INSERT into Artists values (26, 'Fabian', 'Ghici', 'pop')");


            CreateTable(
                "dbo.GenMuzicals",
                c => new
                    {
                        IdGenMuzical = c.Int(nullable: false, identity: false),
                        Nume = c.String(),
                    })
                .PrimaryKey(t => t.IdGenMuzical);

            Sql("INSERT into GenMuzicals values (31, 'pop')");
            Sql("INSERT into GenMuzicals values (32, 'rock')");
            Sql("INSERT into GenMuzicals values (33, 'dance')");

        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Albums", "IdGenMuzical", "dbo.GenMuzicals");
            DropForeignKey("dbo.Albums", "IdArtist", "dbo.Artists");
            DropIndex("dbo.Albums", new[] { "IdGenMuzical" });
            DropIndex("dbo.Albums", new[] { "IdArtist" });
            DropTable("dbo.GenMuzicals");
            DropTable("dbo.Artists");
            DropTable("dbo.Albums");
        }
    }
}
