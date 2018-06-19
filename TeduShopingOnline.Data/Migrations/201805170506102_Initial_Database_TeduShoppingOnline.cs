namespace TeduShopingOnline.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial_Database_TeduShoppingOnline : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplicationGroups",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 250),
                        Description = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ApplicationRoleGroups",
                c => new
                    {
                        GroupId = c.Int(nullable: false),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.GroupId, t.RoleId })
                .ForeignKey("dbo.ApplicationGroups", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.ApplicationRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.GroupId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.ApplicationRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Description = c.String(maxLength: 250),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ApplicationUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.ApplicationRoles", t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id);
            
            CreateTable(
                "dbo.ApplicationUserGroups",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        GroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.GroupId })
                .ForeignKey("dbo.ApplicationGroups", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.ApplicationUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.GroupId);
            
            CreateTable(
                "dbo.ApplicationUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FullName = c.String(maxLength: 256),
                        Address = c.String(maxLength: 256),
                        BirthDay = c.DateTime(),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ApplicationUserClaims",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        Id = c.Int(nullable: false),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        UpdatedDate = c.DateTime(),
                        TopBrand = c.Boolean(),
                        CountStart = c.Int(nullable: false),
                        ProductCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductCategories", t => t.ProductCategoryId, cascadeDelete: true)
                .Index(t => t.ProductCategoryId);
            
            CreateTable(
                "dbo.ProductCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Alias = c.String(maxLength: 8000, unicode: false),
                        Description = c.String(maxLength: 4000),
                        ParentId = c.Int(),
                        HomeFlag = c.Boolean(),
                        DisplayOrder = c.Int(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(),
                        MetaKeywork = c.String(),
                        MetaDescription = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Alias = c.String(maxLength: 8000, unicode: false),
                        ProductCategoryId = c.Int(nullable: false),
                        Image = c.String(maxLength: 255, unicode: false),
                        MoreImage = c.String(storeType: "xml"),
                        Price = c.Decimal(precision: 18, scale: 2),
                        PromotionPrice = c.Decimal(precision: 18, scale: 2),
                        Warranty = c.Int(),
                        Description = c.String(maxLength: 255),
                        Content = c.String(maxLength: 4000),
                        HomeFlag = c.Boolean(),
                        HotFlag = c.Boolean(),
                        ViewCount = c.Int(),
                        TopSale = c.Boolean(),
                        Gender = c.Boolean(),
                        Quantity = c.Int(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(),
                        MetaKeywork = c.String(),
                        MetaDescription = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductCategories", t => t.ProductCategoryId, cascadeDelete: true)
                .Index(t => t.ProductCategoryId);
            
            CreateTable(
                "dbo.ContactDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Address = c.String(nullable: false, maxLength: 255),
                        PhoneNumber = c.String(nullable: false, maxLength: 20, unicode: false),
                        Email = c.String(nullable: false, maxLength: 50, unicode: false),
                        Website = c.String(maxLength: 255, unicode: false),
                        MoreDetail = c.String(maxLength: 500),
                        Latitude = c.Double(),
                        Longitude = c.Double(),
                        Status = c.Boolean(nullable: false),
                        Telephone = c.String(maxLength: 50, unicode: false),
                        Fax = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Errors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        StackTrace = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FeedBacks",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        Email = c.String(nullable: false, maxLength: 250, unicode: false),
                        Message = c.String(maxLength: 500),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Footers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 50),
                        Content = c.String(nullable: false, maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MenuGroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Url = c.String(maxLength: 255, unicode: false),
                        DisplayOrder = c.Int(),
                        GroupId = c.Int(nullable: false),
                        Target = c.String(maxLength: 255),
                        Status = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MenuGroups", t => t.GroupId, cascadeDelete: true)
                .Index(t => t.GroupId);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.OrderID, t.ProductID })
                .ForeignKey("dbo.Orders", t => t.OrderID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.OrderID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(nullable: false, maxLength: 255),
                        CustomerAddress = c.String(nullable: false, maxLength: 255),
                        CustomerEmail = c.String(nullable: false, maxLength: 255, unicode: false),
                        CustomerMobile = c.String(nullable: false, maxLength: 12, unicode: false),
                        CustomerMessage = c.String(nullable: false, maxLength: 255),
                        PaymentMethod = c.String(maxLength: 255, unicode: false),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        PaymentStatus = c.String(),
                        Status = c.Boolean(nullable: false),
                        CustomerId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Pages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Alias = c.String(nullable: false, maxLength: 255, unicode: false),
                        Content = c.String(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(),
                        MetaKeywork = c.String(),
                        MetaDescription = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PostCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Alias = c.String(),
                        Description = c.String(),
                        ParentId = c.Int(nullable: false),
                        DisplayOrder = c.Int(nullable: false),
                        Image = c.String(),
                        HomeFlag = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(),
                        MetaKeywork = c.String(),
                        MetaDescription = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        PostCategoryId = c.Int(nullable: false),
                        Image = c.String(maxLength: 8000, unicode: false),
                        Description = c.String(maxLength: 4000),
                        Content = c.String(maxLength: 4000),
                        HotFlag = c.Boolean(nullable: false),
                        HomeFlag = c.Boolean(nullable: false),
                        ViewCount = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(),
                        MetaKeywork = c.String(),
                        MetaDescription = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PostCategories", t => t.PostCategoryId, cascadeDelete: true)
                .Index(t => t.PostCategoryId);
            
            CreateTable(
                "dbo.PostTags",
                c => new
                    {
                        PostID = c.Int(nullable: false),
                        TagID = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => new { t.PostID, t.TagID })
                .ForeignKey("dbo.Posts", t => t.PostID, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.TagID, cascadeDelete: true)
                .Index(t => t.PostID)
                .Index(t => t.TagID);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 50, unicode: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Type = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ProductTags",
                c => new
                    {
                        ProductID = c.Int(nullable: false),
                        TagID = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => new { t.ProductID, t.TagID })
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.TagID, cascadeDelete: true)
                .Index(t => t.ProductID)
                .Index(t => t.TagID);
            
            CreateTable(
                "dbo.Slides",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        Description = c.String(maxLength: 256),
                        Image = c.String(maxLength: 256),
                        Url = c.String(maxLength: 256),
                        DisplayOrder = c.Int(),
                        Status = c.Boolean(nullable: false),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SupportOnlines",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Department = c.String(maxLength: 50),
                        Skype = c.String(maxLength: 50),
                        Mobile = c.String(maxLength: 50),
                        Email = c.String(maxLength: 50),
                        Yahoo = c.String(maxLength: 50),
                        Facebook = c.String(maxLength: 50),
                        Status = c.Boolean(nullable: false),
                        DisplayOrder = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SystemConfigs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 50, unicode: false),
                        ValueString = c.String(maxLength: 50),
                        ValueInt = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.VisitorStatistics",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        VisitedDate = c.DateTime(nullable: false),
                        IPAddress = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplicationUserRoles", "IdentityRole_Id", "dbo.ApplicationRoles");
            DropForeignKey("dbo.ProductTags", "TagID", "dbo.Tags");
            DropForeignKey("dbo.ProductTags", "ProductID", "dbo.Products");
            DropForeignKey("dbo.PostTags", "TagID", "dbo.Tags");
            DropForeignKey("dbo.PostTags", "PostID", "dbo.Posts");
            DropForeignKey("dbo.Posts", "PostCategoryId", "dbo.PostCategories");
            DropForeignKey("dbo.OrderDetails", "ProductID", "dbo.Products");
            DropForeignKey("dbo.OrderDetails", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.Menus", "GroupId", "dbo.MenuGroups");
            DropForeignKey("dbo.Products", "ProductCategoryId", "dbo.ProductCategories");
            DropForeignKey("dbo.Brands", "ProductCategoryId", "dbo.ProductCategories");
            DropForeignKey("dbo.ApplicationUserGroups", "UserId", "dbo.ApplicationUsers");
            DropForeignKey("dbo.ApplicationUserRoles", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.ApplicationUserLogins", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.ApplicationUserClaims", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.ApplicationUserGroups", "GroupId", "dbo.ApplicationGroups");
            DropForeignKey("dbo.ApplicationRoleGroups", "RoleId", "dbo.ApplicationRoles");
            DropForeignKey("dbo.ApplicationRoleGroups", "GroupId", "dbo.ApplicationGroups");
            DropIndex("dbo.ProductTags", new[] { "TagID" });
            DropIndex("dbo.ProductTags", new[] { "ProductID" });
            DropIndex("dbo.PostTags", new[] { "TagID" });
            DropIndex("dbo.PostTags", new[] { "PostID" });
            DropIndex("dbo.Posts", new[] { "PostCategoryId" });
            DropIndex("dbo.OrderDetails", new[] { "ProductID" });
            DropIndex("dbo.OrderDetails", new[] { "OrderID" });
            DropIndex("dbo.Menus", new[] { "GroupId" });
            DropIndex("dbo.Products", new[] { "ProductCategoryId" });
            DropIndex("dbo.Brands", new[] { "ProductCategoryId" });
            DropIndex("dbo.ApplicationUserLogins", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.ApplicationUserClaims", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.ApplicationUserGroups", new[] { "GroupId" });
            DropIndex("dbo.ApplicationUserGroups", new[] { "UserId" });
            DropIndex("dbo.ApplicationUserRoles", new[] { "IdentityRole_Id" });
            DropIndex("dbo.ApplicationUserRoles", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.ApplicationRoleGroups", new[] { "RoleId" });
            DropIndex("dbo.ApplicationRoleGroups", new[] { "GroupId" });
            DropTable("dbo.VisitorStatistics");
            DropTable("dbo.SystemConfigs");
            DropTable("dbo.SupportOnlines");
            DropTable("dbo.Slides");
            DropTable("dbo.ProductTags");
            DropTable("dbo.Tags");
            DropTable("dbo.PostTags");
            DropTable("dbo.Posts");
            DropTable("dbo.PostCategories");
            DropTable("dbo.Pages");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Menus");
            DropTable("dbo.MenuGroups");
            DropTable("dbo.Footers");
            DropTable("dbo.FeedBacks");
            DropTable("dbo.Errors");
            DropTable("dbo.ContactDetails");
            DropTable("dbo.Products");
            DropTable("dbo.ProductCategories");
            DropTable("dbo.Brands");
            DropTable("dbo.ApplicationUserLogins");
            DropTable("dbo.ApplicationUserClaims");
            DropTable("dbo.ApplicationUsers");
            DropTable("dbo.ApplicationUserGroups");
            DropTable("dbo.ApplicationUserRoles");
            DropTable("dbo.ApplicationRoles");
            DropTable("dbo.ApplicationRoleGroups");
            DropTable("dbo.ApplicationGroups");
        }
    }
}
