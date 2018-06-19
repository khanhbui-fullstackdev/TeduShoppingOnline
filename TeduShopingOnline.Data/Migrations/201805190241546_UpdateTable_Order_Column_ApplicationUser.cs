namespace TeduShopingOnline.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTable_Order_Column_ApplicationUser : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Orders", "CustomerId");
            AddForeignKey("dbo.Orders", "CustomerId", "dbo.ApplicationUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.ApplicationUsers");
            DropIndex("dbo.Orders", new[] { "CustomerId" });
        }
    }
}
