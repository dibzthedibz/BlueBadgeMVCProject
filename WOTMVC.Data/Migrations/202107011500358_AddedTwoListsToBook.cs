namespace WOTMVC.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTwoListsToBook : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Nation", "Book_BookId", c => c.Int());
            AddColumn("dbo.Character", "Book_BookId", c => c.Int());
            CreateIndex("dbo.Nation", "Book_BookId");
            CreateIndex("dbo.Character", "Book_BookId");
            AddForeignKey("dbo.Character", "Book_BookId", "dbo.Book", "BookId");
            AddForeignKey("dbo.Nation", "Book_BookId", "dbo.Book", "BookId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Nation", "Book_BookId", "dbo.Book");
            DropForeignKey("dbo.Character", "Book_BookId", "dbo.Book");
            DropIndex("dbo.Character", new[] { "Book_BookId" });
            DropIndex("dbo.Nation", new[] { "Book_BookId" });
            DropColumn("dbo.Character", "Book_BookId");
            DropColumn("dbo.Nation", "Book_BookId");
        }
    }
}
