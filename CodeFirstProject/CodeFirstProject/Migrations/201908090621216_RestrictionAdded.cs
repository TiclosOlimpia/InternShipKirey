namespace CodeFirstProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RestrictionAdded : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Albums", "NumeAlbum", c => c.String(nullable: false));
            AlterColumn("dbo.Artists", "Nume", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Artists", "NumeScena", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Artists", "NumeScena", c => c.String());
            AlterColumn("dbo.Artists", "Nume", c => c.String());
            AlterColumn("dbo.Albums", "NumeAlbum", c => c.String());
        }
    }
}
