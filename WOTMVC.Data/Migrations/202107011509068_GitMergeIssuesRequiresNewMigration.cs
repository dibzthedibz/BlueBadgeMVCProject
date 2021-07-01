namespace WOTMVC.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GitMergeIssuesRequiresNewMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Chapter", "ChapName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Chapter", "ChapName");
        }
    }
}
