namespace TeduShopingOnline.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_ProductCategory_Modify_Property_Alias : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProductCategories", "Alias", c => c.String(maxLength: 255, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProductCategories", "Alias", c => c.String(maxLength: 8000, unicode: false));
        }
    }
}
