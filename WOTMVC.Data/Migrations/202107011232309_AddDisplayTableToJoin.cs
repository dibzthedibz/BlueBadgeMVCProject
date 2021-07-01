namespace WOTMVC.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDisplayTableToJoin : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Chapter", "BookId", "dbo.Book");
            DropIndex("dbo.Chapter", new[] { "BookId" });
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
                .PrimaryKey(t => t.DisplayId)
                .ForeignKey("dbo.Book", t => t.BookId, cascadeDelete: true)
                .ForeignKey("dbo.Chapter", t => t.ChapterId, cascadeDelete: true)
                .ForeignKey("dbo.Character", t => t.CharacterId, cascadeDelete: true)
                .ForeignKey("dbo.Nation", t => t.NationId, cascadeDelete: true)
                .Index(t => t.NationId)
                .Index(t => t.CharacterId)
                .Index(t => t.ChapterId)
                .Index(t => t.BookId);
            
            AddColumn("dbo.Chapter", "ChapName", c => c.String(nullable: false));
            AddColumn("dbo.Chapter", "Narrator", c => c.String());
            AddColumn("dbo.Chapter", "Location", c => c.String());
            AddColumn("dbo.Chapter", "BookIn", c => c.String());
            DropColumn("dbo.Chapter", "BookId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Chapter", "BookId", c => c.Int());
            DropForeignKey("dbo.DisplayTable", "NationId", "dbo.Nation");
            DropForeignKey("dbo.DisplayTable", "CharacterId", "dbo.Character");
            DropForeignKey("dbo.DisplayTable", "ChapterId", "dbo.Chapter");
            DropForeignKey("dbo.DisplayTable", "BookId", "dbo.Book");
            DropIndex("dbo.DisplayTable", new[] { "BookId" });
            DropIndex("dbo.DisplayTable", new[] { "ChapterId" });
            DropIndex("dbo.DisplayTable", new[] { "CharacterId" });
            DropIndex("dbo.DisplayTable", new[] { "NationId" });
            DropColumn("dbo.Chapter", "BookIn");
            DropColumn("dbo.Chapter", "Location");
            DropColumn("dbo.Chapter", "Narrator");
            DropColumn("dbo.Chapter", "ChapName");
            DropTable("dbo.DisplayTable");
            CreateIndex("dbo.Chapter", "BookId");
            AddForeignKey("dbo.Chapter", "BookId", "dbo.Book", "BookId");
        }
    }
}
