namespace TeduShopingOnline.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTable_Product : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "OriginalPrice", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "OriginalPrice");
        }
    }
}
