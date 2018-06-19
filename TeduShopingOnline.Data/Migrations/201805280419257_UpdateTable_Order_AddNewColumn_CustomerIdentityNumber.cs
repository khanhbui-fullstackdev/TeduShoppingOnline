namespace TeduShopingOnline.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTable_Order_AddNewColumn_CustomerIdentityNumber : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "CustomerIdentityNumber", c => c.String(maxLength: 256, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "CustomerIdentityNumber");
        }
    }
}
