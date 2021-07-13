namespace WOTMVC.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedImagePropToBookObj : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Book", "Image", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Book", "Image");
        }
    }
}
