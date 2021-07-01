namespace WOTMVC.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GitRevertTakeTwo : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DisplayTable", "BookId", "dbo.Book");
            DropForeignKey("dbo.DisplayTable", "ChapterId", "dbo.Chapter");
            DropForeignKey("dbo.DisplayTable", "CharacterId", "dbo.Character");
            DropForeignKey("dbo.DisplayTable", "NationId", "dbo.Nation");
            DropIndex("dbo.DisplayTable", new[] { "NationId" });
            DropIndex("dbo.DisplayTable", new[] { "CharacterId" });
            DropIndex("dbo.DisplayTable", new[] { "ChapterId" });
            DropIndex("dbo.DisplayTable", new[] { "BookId" });
            AddColumn("dbo.Chapter", "BookId", c => c.Int());
            CreateIndex("dbo.Chapter", "BookId");
            AddForeignKey("dbo.Chapter", "BookId", "dbo.Book", "BookId");
            DropColumn("dbo.Chapter", "ChapName");
            DropColumn("dbo.Chapter", "Narrator");
            DropColumn("dbo.Chapter", "Location");
            DropColumn("dbo.Chapter", "BookIn");
            DropTable("dbo.DisplayTable");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.DisplayTable",
                c => new
                    {
                        DisplayId = c.Int(nullable: false, identity: true),
                        NationId = c.Int(nullable: false),
                        CharacterId = c.Int(nullable: false),
                        ChapterId = c.Int(nullable: false),
                        BookId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DisplayId);
            
            AddColumn("dbo.Chapter", "BookIn", c => c.String());
            AddColumn("dbo.Chapter", "Location", c => c.String());
            AddColumn("dbo.Chapter", "Narrator", c => c.String());
            AddColumn("dbo.Chapter", "ChapName", c => c.String(nullable: false));
            DropForeignKey("dbo.Chapter", "BookId", "dbo.Book");
            DropIndex("dbo.Chapter", new[] { "BookId" });
            DropColumn("dbo.Chapter", "BookId");
            CreateIndex("dbo.DisplayTable", "BookId");
            CreateIndex("dbo.DisplayTable", "ChapterId");
            CreateIndex("dbo.DisplayTable", "CharacterId");
            CreateIndex("dbo.DisplayTable", "NationId");
            AddForeignKey("dbo.DisplayTable", "NationId", "dbo.Nation", "NationId", cascadeDelete: true);
            AddForeignKey("dbo.DisplayTable", "CharacterId", "dbo.Character", "CharacterId", cascadeDelete: true);
            AddForeignKey("dbo.DisplayTable", "ChapterId", "dbo.Chapter", "ChapterId", cascadeDelete: true);
            AddForeignKey("dbo.DisplayTable", "BookId", "dbo.Book", "BookId", cascadeDelete: true);
        }
    }
}
