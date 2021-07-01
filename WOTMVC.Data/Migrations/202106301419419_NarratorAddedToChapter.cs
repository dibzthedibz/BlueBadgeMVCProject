namespace WOTMVC.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NarratorAddedToChapter : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Chapter", "Narrator", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Chapter", "Narrator");
        }
    }
}
