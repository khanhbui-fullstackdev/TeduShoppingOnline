namespace TeduShopingOnline.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTable_ApplicationUser_And_Audit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplicationUsers", "IdentityNumber", c => c.String(maxLength: 256, unicode: false));
            AlterColumn("dbo.ProductCategories", "CreatedBy", c => c.String(maxLength: 255, unicode: false));
            AlterColumn("dbo.ProductCategories", "UpdatedBy", c => c.String(maxLength: 255, unicode: false));
            AlterColumn("dbo.ProductCategories", "MetaKeywork", c => c.String(maxLength: 500, unicode: false));
            AlterColumn("dbo.ProductCategories", "MetaDescription", c => c.String(maxLength: 500, unicode: false));
            AlterColumn("dbo.Products", "CreatedBy", c => c.String(maxLength: 255, unicode: false));
            AlterColumn("dbo.Products", "UpdatedBy", c => c.String(maxLength: 255, unicode: false));
            AlterColumn("dbo.Products", "MetaKeywork", c => c.String(maxLength: 500, unicode: false));
            AlterColumn("dbo.Products", "MetaDescription", c => c.String(maxLength: 500, unicode: false));
            AlterColumn("dbo.Pages", "CreatedBy", c => c.String(maxLength: 255, unicode: false));
            AlterColumn("dbo.Pages", "UpdatedBy", c => c.String(maxLength: 255, unicode: false));
            AlterColumn("dbo.Pages", "MetaKeywork", c => c.String(maxLength: 500, unicode: false));
            AlterColumn("dbo.Pages", "MetaDescription", c => c.String(maxLength: 500, unicode: false));
            AlterColumn("dbo.PostCategories", "CreatedBy", c => c.String(maxLength: 255, unicode: false));
            AlterColumn("dbo.PostCategories", "UpdatedBy", c => c.String(maxLength: 255, unicode: false));
            AlterColumn("dbo.PostCategories", "MetaKeywork", c => c.String(maxLength: 500, unicode: false));
            AlterColumn("dbo.PostCategories", "MetaDescription", c => c.String(maxLength: 500, unicode: false));
            AlterColumn("dbo.Posts", "CreatedBy", c => c.String(maxLength: 255, unicode: false));
            AlterColumn("dbo.Posts", "UpdatedBy", c => c.String(maxLength: 255, unicode: false));
            AlterColumn("dbo.Posts", "MetaKeywork", c => c.String(maxLength: 500, unicode: false));
            AlterColumn("dbo.Posts", "MetaDescription", c => c.String(maxLength: 500, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Posts", "MetaDescription", c => c.String());
            AlterColumn("dbo.Posts", "MetaKeywork", c => c.String());
            AlterColumn("dbo.Posts", "UpdatedBy", c => c.String());
            AlterColumn("dbo.Posts", "CreatedBy", c => c.String());
            AlterColumn("dbo.PostCategories", "MetaDescription", c => c.String());
            AlterColumn("dbo.PostCategories", "MetaKeywork", c => c.String());
            AlterColumn("dbo.PostCategories", "UpdatedBy", c => c.String());
            AlterColumn("dbo.PostCategories", "CreatedBy", c => c.String());
            AlterColumn("dbo.Pages", "MetaDescription", c => c.String());
            AlterColumn("dbo.Pages", "MetaKeywork", c => c.String());
            AlterColumn("dbo.Pages", "UpdatedBy", c => c.String());
            AlterColumn("dbo.Pages", "CreatedBy", c => c.String());
            AlterColumn("dbo.Products", "MetaDescription", c => c.String());
            AlterColumn("dbo.Products", "MetaKeywork", c => c.String());
            AlterColumn("dbo.Products", "UpdatedBy", c => c.String());
            AlterColumn("dbo.Products", "CreatedBy", c => c.String());
            AlterColumn("dbo.ProductCategories", "MetaDescription", c => c.String());
            AlterColumn("dbo.ProductCategories", "MetaKeywork", c => c.String());
            AlterColumn("dbo.ProductCategories", "UpdatedBy", c => c.String());
            AlterColumn("dbo.ProductCategories", "CreatedBy", c => c.String());
            DropColumn("dbo.ApplicationUsers", "IdentityNumber");
        }
    }
}
