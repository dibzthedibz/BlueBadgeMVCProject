namespace WOTMVC.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedForeignKeysToChapter : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Chapter", name: "Character_CharacterId", newName: "CharacterId");
            RenameIndex(table: "dbo.Chapter", name: "IX_Character_CharacterId", newName: "IX_CharacterId");
            AddColumn("dbo.Chapter", "NationId", c => c.Int());
            CreateIndex("dbo.Chapter", "NationId");
            AddForeignKey("dbo.Chapter", "NationId", "dbo.Nation", "NationId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Chapter", "NationId", "dbo.Nation");
            DropIndex("dbo.Chapter", new[] { "NationId" });
            DropColumn("dbo.Chapter", "NationId");
            RenameIndex(table: "dbo.Chapter", name: "IX_CharacterId", newName: "IX_Character_CharacterId");
            RenameColumn(table: "dbo.Chapter", name: "CharacterId", newName: "Character_CharacterId");
        }
    }
}
