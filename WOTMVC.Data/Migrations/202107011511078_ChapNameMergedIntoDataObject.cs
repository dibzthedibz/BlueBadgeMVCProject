namespace WOTMVC.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChapNameMergedIntoDataObject : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Chapter", "ChapName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Chapter", "ChapName", c => c.String(nullable: false));
        }
    }
}
