namespace WOTMVC.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FullDataLayerRefactor : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Chapter", name: "Character_CharacterId", newName: "CharacterId");
            RenameIndex(table: "dbo.Chapter", name: "IX_Character_CharacterId", newName: "IX_CharacterId");
            AddColumn("dbo.Chapter", "NationId", c => c.Int());
            AddColumn("dbo.Character", "NationId", c => c.Int());
            CreateIndex("dbo.Chapter", "NationId");
            CreateIndex("dbo.Character", "NationId");
            AddForeignKey("dbo.Chapter", "NationId", "dbo.Nation", "NationId");
            AddForeignKey("dbo.Character", "NationId", "dbo.Nation", "NationId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Character", "NationId", "dbo.Nation");
            DropForeignKey("dbo.Chapter", "NationId", "dbo.Nation");
            DropIndex("dbo.Character", new[] { "NationId" });
            DropIndex("dbo.Chapter", new[] { "NationId" });
            DropColumn("dbo.Character", "NationId");
            DropColumn("dbo.Chapter", "NationId");
            RenameIndex(table: "dbo.Chapter", name: "IX_CharacterId", newName: "IX_Character_CharacterId");
            RenameColumn(table: "dbo.Chapter", name: "CharacterId", newName: "Character_CharacterId");
        }
    }
}
