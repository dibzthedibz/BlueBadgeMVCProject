namespace WOTMVC.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedImageToCharacter : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Character", "Image", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Character", "Image");
        }
    }
}
