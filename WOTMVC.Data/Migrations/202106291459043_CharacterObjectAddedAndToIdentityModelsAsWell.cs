namespace WOTMVC.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CharacterObjectAddedAndToIdentityModelsAsWell : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Character",
                c => new
                    {
                        CharacterId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        FullName = c.String(),
                        Ability = c.String(),
                    })
                .PrimaryKey(t => t.CharacterId);
            
            AddColumn("dbo.Chapter", "Character_CharacterId", c => c.Int());
            CreateIndex("dbo.Chapter", "Character_CharacterId");
            AddForeignKey("dbo.Chapter", "Character_CharacterId", "dbo.Character", "CharacterId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Chapter", "Character_CharacterId", "dbo.Character");
            DropIndex("dbo.Chapter", new[] { "Character_CharacterId" });
            DropColumn("dbo.Chapter", "Character_CharacterId");
            DropTable("dbo.Character");
        }
    }
}
