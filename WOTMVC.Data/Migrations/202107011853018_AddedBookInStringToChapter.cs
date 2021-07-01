namespace WOTMVC.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedBookInStringToChapter : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Chapter", "BookIn", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Chapter", "BookIn");
        }
    }
}
