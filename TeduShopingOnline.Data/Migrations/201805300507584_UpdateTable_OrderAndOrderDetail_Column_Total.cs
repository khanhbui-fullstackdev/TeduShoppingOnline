namespace TeduShopingOnline.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTable_OrderAndOrderDetail_Column_Total : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderDetails", "Total", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Orders", "Total", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "Total");
            DropColumn("dbo.OrderDetails", "Total");
        }
    }
}
