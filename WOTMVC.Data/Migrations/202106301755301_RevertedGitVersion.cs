namespace WOTMVC.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RevertedGitVersion : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Chapter", "NationId", "dbo.Nation");
            DropIndex("dbo.Chapter", new[] { "NationId" });
            RenameColumn(table: "dbo.Chapter", name: "CharacterId", newName: "Character_CharacterId");
            RenameIndex(table: "dbo.Chapter", name: "IX_CharacterId", newName: "IX_Character_CharacterId");
            DropColumn("dbo.Chapter", "NationId");
            DropColumn("dbo.Chapter", "Narrator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Chapter", "Narrator", c => c.String());
            AddColumn("dbo.Chapter", "NationId", c => c.Int());
            RenameIndex(table: "dbo.Chapter", name: "IX_Character_CharacterId", newName: "IX_CharacterId");
            RenameColumn(table: "dbo.Chapter", name: "Character_CharacterId", newName: "CharacterId");
            CreateIndex("dbo.Chapter", "NationId");
            AddForeignKey("dbo.Chapter", "NationId", "dbo.Nation", "NationId");
        }
    }
}
