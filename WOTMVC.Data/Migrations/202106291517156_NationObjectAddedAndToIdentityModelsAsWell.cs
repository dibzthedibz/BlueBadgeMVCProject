namespace WOTMVC.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NationObjectAddedAndToIdentityModelsAsWell : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Nation",
                c => new
                    {
                        NationId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        NationName = c.String(nullable: false),
                        Terrain = c.String(nullable: false),
                        Trades = c.String(),
                    })
                .PrimaryKey(t => t.NationId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Nation");
        }
    }
}
