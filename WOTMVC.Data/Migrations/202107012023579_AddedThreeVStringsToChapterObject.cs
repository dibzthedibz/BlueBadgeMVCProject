namespace WOTMVC.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedThreeVStringsToChapterObject : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Chapter", "Narrator", c => c.String());
            AddColumn("dbo.Chapter", "Location", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Chapter", "Location");
            DropColumn("dbo.Chapter", "Narrator");
        }
    }
}
