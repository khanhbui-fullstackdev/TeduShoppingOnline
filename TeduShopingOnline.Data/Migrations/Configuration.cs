namespace TeduShopingOnline.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Diagnostics;
    using System.Linq;
    using TeduShopingOnline.Model.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TeduShopingOnline.Data.TeduShoppingOnlineDbContext>
    {
        #region Configuration
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }
        #endregion

        #region Seed
        protected override void Seed(TeduShopingOnline.Data.TeduShoppingOnlineDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            CreateSampleUser(context);
            CreateSampleSlides(context);
            CreateSampleProductCategories(context);
            CreateSampleBrands(context);
            CreateSampleProducts(context);
            CreateSampleTags(context);
            CreateSampleProductTags(context);
            CreateSampleContactDetail(context);
        }
        #endregion

        #region Create Sample Slides
        private void CreateSampleSlides(TeduShoppingOnlineDbContext context)
        {
            if (context.Slides.Count() == 0)
            {
                // Create new list slides example
                List<Slide> slides = new List<Slide>()
                {
                    new Slide()
                    {
                        Name ="Slide 1",
                        DisplayOrder =1,
                        Status =true,
                        Url ="#",
                        Image ="/Assets/client/images/bag.jpg",
                        Content = @"<h2>FLAT 50% 0FF</h2><label>FOR ALL PURCHASE <b>VALUE</b></label><p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et</p><span class=""on-get"">GET NOW</span>"
                    },
                    new Slide()
                    {
                        Name ="Slide 2",
                        DisplayOrder =2,
                        Status =true,
                        Url ="#",
                        Image ="/Assets/client/images/bag1.jpg",
                        Content = @"<h2>FLAT 50% 0FF</h2><label>FOR ALL PURCHASE <b>VALUE</b></label><p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et </p><span class=""on-get"">GET NOW</span>"
                    },
                };
                context.Slides.AddRange(slides);
                context.SaveChanges();
            }
        }
        #endregion

        #region Create Sample Product Categories
        private void CreateSampleProductCategories(TeduShoppingOnlineDbContext context)
        {
            if (context.ProductCategories.Count() == 0)
            {
                // Create new list product categories example
                List<ProductCategory> productCategories = new List<ProductCategory>()
                {
                    new ProductCategory() { Id = 1, Name = "Laptop Computer", Alias = "laptop-computer", Status = true,CreatedDate=DateTime.Now,CreatedBy="khanhbui" },
                    new ProductCategory() { Id = 2, Name = "Smartphone", Alias = "smartphone", Status = true,CreatedDate=DateTime.Now,CreatedBy="khanhbui" },
                    new ProductCategory() { Id = 3, Name = "Perfume", Alias = "perfume", Status = true,CreatedDate=DateTime.Now,CreatedBy="khanhbui" },
                    new ProductCategory() { Id = 4, Name = "Accessories/Jewelry/Bags", Alias = "accessories-jewelry", Status = true,CreatedDate=DateTime.Now,CreatedBy="khanhbui" },
                    new ProductCategory() { Id = 5, Name = "Clothing", Alias = "clothing", Status = true,CreatedDate=DateTime.Now,CreatedBy="khanhbui" },
                    new ProductCategory() { Id = 6, Name = "Lingeries", Alias = "lingeries", Status = true,CreatedDate=DateTime.Now,CreatedBy="khanhbui" },
                    new ProductCategory() { Id = 7, Name = "Laptop accessories", Alias = "laptop-accessories", Status = true,CreatedDate=DateTime.Now,CreatedBy="khanhbui" },
                    new ProductCategory() { Id = 8, Name = "Watch", Alias = "watch", Status = true,CreatedDate=DateTime.Now,CreatedBy="khanhbui" },
                    new ProductCategory() { Id = 9, Name = "Shoes", Alias = "shoes", Status = true,CreatedDate=DateTime.Now,CreatedBy="khanhbui" },
                };
                context.ProductCategories.AddRange(productCategories);
                context.SaveChanges();
            }
        }
        #endregion

        #region Create Sample Brands
        private void CreateSampleBrands(TeduShoppingOnlineDbContext context)
        {
            if (context.Brands.Count() == 0)
            {
                // Create new list brands example
                List<Brand> brands = new List<Brand>()
                {
                    new Brand() { Name = "Asus",CreatedDate=DateTime.Now,CreatedBy="khanhbui", ProductCategoryId = 1,TopBrand=true},
                    new Brand() { Name = "Toshiba",CreatedDate=DateTime.Now,CreatedBy="khanhbui", ProductCategoryId = 1,TopBrand=false},
                    new Brand() { Name = "Acer",CreatedDate=DateTime.Now,CreatedBy="khanhbui", ProductCategoryId = 1,TopBrand=false},
                    new Brand() { Name = "Levono",CreatedDate=DateTime.Now,CreatedBy="khanhbui", ProductCategoryId = 1,TopBrand=true},
                    new Brand() { Name = "HP",CreatedDate=DateTime.Now,CreatedBy="khanhbui", ProductCategoryId = 1,TopBrand=true},
                    new Brand() { Name = "Samsung",CreatedDate=DateTime.Now,CreatedBy="khanhbui", ProductCategoryId = 2,TopBrand=true},
                    new Brand() { Name = "Apple",CreatedDate=DateTime.Now,CreatedBy="khanhbui", ProductCategoryId = 2,TopBrand=true},
                    new Brand() { Name = "LG",CreatedDate=DateTime.Now,CreatedBy="khanhbui", ProductCategoryId = 2,TopBrand=false},
                    new Brand() { Name = "Sony",CreatedDate=DateTime.Now,CreatedBy="khanhbui", ProductCategoryId = 2,TopBrand=false},
                    new Brand() { Name = "Nokia",CreatedDate=DateTime.Now,CreatedBy="khanhbui", ProductCategoryId = 2,TopBrand=false},
                    new Brand() { Name = "Vera",CreatedDate=DateTime.Now,CreatedBy="khanhbui", ProductCategoryId = 6,TopBrand=true},
                    new Brand() { Name = "Ibasic",CreatedDate=DateTime.Now,CreatedBy="khanhbui", ProductCategoryId = 6,TopBrand=false},
                    new Brand() { Name = "Calvin Klein",CreatedDate=DateTime.Now,CreatedBy="khanhbui", ProductCategoryId = 5,TopBrand=true},
                };
                context.Brands.AddRange(brands);
                context.SaveChanges();
            }
        }
        #endregion

        #region Create Sample Products
        private void CreateSampleProducts(TeduShoppingOnlineDbContext context)
        {
            if (context.Products.Count() == 0)
            {
                // Create new list products example
                List<Product> products = new List<Product>()
                {
                    new Product()
                    {
                        Id = 1,
                        Name = "Asus X441NA N4200(GA070T)",
                        Alias = "asus-x441na-n4200(ga070t)",
                        Price = 7490000,
                        CreatedBy = "khanhbui",
                        CreatedDate = DateTime.Now,
                        Status = true,
                        HomeFlag = false,
                        HotFlag = false,
                        ProductCategoryId = 1,
                        Image = "/Assets/client/images/asus-x441na-n4200-450.jpg"
                    },
                    new Product()
                    {
                        Id = 2,
                        Name = "Asus X541UA i3 6100U(XX272T)",
                        Alias = "asus-x541ua-i3-6100u(xx272t)",
                        Price = 9990000,
                        CreatedBy ="khanhbui",
                        CreatedDate = DateTime.Now,
                        Status = true,
                        HomeFlag = false,
                        HotFlag = false,
                        ProductCategoryId = 1,
                        Image = "/Assets/client/images/asus-a541ua-i3-6006u.jpg"
                    },
                    new Product()
                    {
                        Id = 3,
                        Name ="Asus A541UA i3 6006U(DM2135T)",
                        Alias ="asus-a541ua-i3-6006u(dm2135t)",
                        Price = 10790000,
                        CreatedBy = "khanhbui",
                        CreatedDate = DateTime.Now,
                        Status = true,
                        HomeFlag = true,
                        HotFlag = false,
                        ProductCategoryId = 1,
                        Image = "/Assets/client/images/asus-a541ua-i3-6006u.jpg"
                    },
                    new Product()
                    {
                        Id = 4,
                        Name ="Asus A541UA i3 7100U(DM1658T)",
                        Alias ="asus-a541ua-i3-7100u(dm1658t)",
                        Price = 10990000,
                        CreatedBy ="khanhbui",
                        CreatedDate =DateTime.Now,
                        Status =true,
                        HomeFlag =false,
                        HotFlag =false,
                        ProductCategoryId = 1,
                        Image = "/Assets/client/images/asus-a541ua-i3-7100u.jpg"
                    },
                    new Product()
                    {
                        Id = 5,
                        Name = "Asus X405UA i3 7100U(BV330T)",
                        Alias = "asus-x405ua-i3-7100u(bv330t)",
                        Price = 11490000,
                        CreatedBy ="khanhbui",
                        CreatedDate = DateTime.Now,
                        Status = true,
                        HomeFlag = false,
                        HotFlag = false,
                        ProductCategoryId = 1,
                        Image = "/Assets/client/images/asus-x405ua-i3-7100u.jpg"
                    },
                    new Product()
                    {
                        Id = 6,
                        Name = "Asus X405UA i3 7100U(EB785T)",
                        Alias = "asus-x405ua-i3-7100u(eb785t)",
                        Price = 11790000,
                        CreatedBy = "khanhbui",
                        CreatedDate = DateTime.Now,
                        Status = true,
                        HomeFlag = true,
                        HotFlag = false,
                        ProductCategoryId = 1,
                        Image = "/Assets/client/images/asus-x405ua-i3-7100u-eb785t.jpg"
                    },
                    new Product()
                    {
                        Id = 7,
                        Name ="Asus A540UP i3 7100U(DM094T)",
                        Alias ="asus-a540up-i3-7100u(dm094t)",
                        Price = 11990000,
                        CreatedBy ="khanhbui",
                        CreatedDate = DateTime.Now,
                        Status = true,
                        HomeFlag = true,
                        HotFlag = false,
                        ProductCategoryId = 1,
                        Image = "/Assets/client/images/asus-a540up-i3-7100u.jpg"
                    },
                    new Product()
                    {
                        Id = 8,
                        Name ="Asus X510UA i3 7100u(BR650T)",
                        Alias ="asus-x510ua-i3-7100u(br650t)",
                        Price = 11990000,
                        CreatedBy = "khanhbui",
                        CreatedDate = DateTime.Now,
                        Status = true,
                        HomeFlag = true,
                        HotFlag = false,
                        ProductCategoryId = 1,
                        Image = "/Assets/client/images/asus-x510ua-i3-7100u.jpg"
                    },
                    new Product()
                    {
                        Id = 9,
                        Name = "Bag Ba",
                        Alias = "Bag-Ba",
                        ProductCategoryId = 4,
                        Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et",
                        Image = "/Assets/client/images/ba.jpg",
                        Price = 450000,
                        PromotionPrice = 420000,
                        HomeFlag = false,
                        HotFlag = true,
                        Quantity = 500,
                        CreatedDate = DateTime.Now.Date,
                        CreatedBy = "khanhbui",
                        UpdatedDate = DateTime.Now.Date,
                        Status = true,
                        Gender = false
                    },
                    new Product()
                    {
                        Id = 10,
                        Name = "Bag Baa",
                        Alias = "Bag-Baa",
                        ProductCategoryId = 4,
                        Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et",
                        Image = "/Assets/client/images/baa.jpg",
                        Price = 400000,
                        PromotionPrice = 380000,
                        HomeFlag = false,
                        HotFlag = true,
                        Quantity = 500,
                        CreatedDate = DateTime.Now.Date,
                        CreatedBy = "khanhbui",
                        UpdatedDate = DateTime.Now.Date,
                        Status = true,
                        Gender = false
                    },
                    new Product()
                    {
                        Name = "Bag Bag",
                        Alias = "Bag-Bag",
                        ProductCategoryId = 4,
                        Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et",
                        Image = "/Assets/client/images/bag.jpg",
                        Price = 800000,
                        PromotionPrice = 650000,
                        HomeFlag = false,
                        HotFlag = false,
                        Quantity = 500,
                        CreatedDate = DateTime.Now.Date,
                        CreatedBy ="khanhbui",
                        UpdatedDate = DateTime.Now.Date,
                        Status = true,
                        Gender = false
                    },
                    new Product()
                    {
                        Name = "Bag Bag1",
                        Alias = "Bag-Bag1",
                        ProductCategoryId = 4,
                        Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et",
                        Image = "/Assets/client/images/bag1.jpg",
                        Price = 700000,
                        PromotionPrice = 650000,
                        HomeFlag = false,
                        HotFlag = false,
                        Quantity = 500,
                        CreatedDate = DateTime.Now.Date,
                        CreatedBy ="khanhbui",
                        UpdatedDate = DateTime.Now.Date,
                        Status = true,
                        Gender = false
                    },
                    new Product()
                    {
                        Name = "Bag Pic13",
                        Alias = "Bag-pic13",
                        ProductCategoryId = 4,
                        Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et",
                        Image = "/Assets/client/images/pic13.jpg",
                        Price = 650000,
                        PromotionPrice = 630000,
                        HomeFlag = false,
                        HotFlag = false,
                        Quantity = 500,
                        CreatedDate = DateTime.Now.Date,
                        CreatedBy ="khanhbui",
                        UpdatedDate = DateTime.Now.Date,
                        Status = true,
                        Gender = false
                    },
                    new Product()
                    {
                        Name = "Bag Pic",
                        Alias = "Bag-pic",
                        ProductCategoryId = 4,
                        Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et",
                        Image = "/Assets/client/images/pic.jpg",
                        Price = 420000,
                        PromotionPrice = 400000,
                        HomeFlag = false,
                        HotFlag = false,
                        Quantity = 500,
                        CreatedDate = DateTime.Now.Date,
                        CreatedBy ="khanhbui",
                        UpdatedDate = DateTime.Now.Date,
                        Status = true,
                        Gender = false
                    },
                    new Product()
                    {
                        Name = "DavidOff CoolWater",
                        Alias = "Perfume-DavidOff",
                        ProductCategoryId = 3,
                        Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et",
                        Image = "/Assets/client/images/bo.jpg",
                        Price = 350000,
                        PromotionPrice = 300000,
                        HomeFlag = false,
                        HotFlag = true,
                        Quantity = 500,
                        CreatedDate = DateTime.Now.Date,
                        CreatedBy ="khanhbui",
                        UpdatedDate = DateTime.Now.Date,
                        Status = true,
                        Gender = false
                    },
                    new Product()
                    {
                        Name = "Calvin Kein",
                        Alias = "Perfume-CalvinKein",
                        ProductCategoryId = 3,
                        Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et",
                        Image = "/Assets/client/images/bott.jpg",
                        Price = 900000,
                        PromotionPrice = 850000,
                        HomeFlag = false,
                        HotFlag = true,
                        Quantity = 500,
                        CreatedDate = DateTime.Now.Date,
                        CreatedBy ="khanhbui",
                        UpdatedDate = DateTime.Now.Date,
                        Status = true,
                        Gender = true
                    },
                    new Product
                    {
                        Name = "UDV For Men",
                        Alias = "Perume-UDVForMen",
                        ProductCategoryId = 3,
                        Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et",
                        Image = "/Assets/client/images/bottle.jpg",
                        Price = 2000000,
                        PromotionPrice = 1200000,
                        HomeFlag = false,
                        HotFlag = true,
                        Quantity = 500,
                        CreatedDate = DateTime.Now.Date,
                        CreatedBy ="khanhbui",
                        UpdatedDate = DateTime.Now.Date,
                        Status = true,
                        Gender = true
                    },
                    new Product
                    {
                        Name = "Perume Pic4",
                        Alias = "Perume-Pic4",
                        ProductCategoryId = 3,
                        Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et",
                        Image = "/Assets/client/images/pic4.jpg",
                        Price = 2000000,
                        PromotionPrice = 1500000,
                        HomeFlag = false,
                        HotFlag = false,
                        Quantity = 500,
                        CreatedDate = DateTime.Now.Date,
                        CreatedBy ="khanhbui",
                        UpdatedDate = DateTime.Now.Date,
                        Status = true,
                        Gender = false
                    },
                    new Product
                    {
                        Name = "Perume Pic10",
                        Alias = "Perume-Pic10",
                        ProductCategoryId = 3,
                        Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et",
                        Image = "/Assets/client/images/pic10.jpg",
                        Price = 2500000,
                        PromotionPrice = 2000000,
                        HomeFlag = false,
                        HotFlag = false,
                        Quantity = 500,
                        CreatedDate = DateTime.Now.Date,
                        CreatedBy ="khanhbui",
                        UpdatedDate = DateTime.Now.Date,
                        Status = true,
                        Gender = false
                    },
                    new Product
                    {
                        Name = "Jewelry Ch",
                        Alias = "jewelry-Ch",
                        ProductCategoryId = 4,
                        Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et",
                        Image = "/Assets/client/images/ch.jpg",
                        Price = 100000,
                        PromotionPrice = 80000,
                        HomeFlag = false,
                        HotFlag = true,
                        Quantity = 500,
                        CreatedDate = DateTime.Now.Date,
                        CreatedBy ="khanhbui",
                        UpdatedDate = DateTime.Now.Date,
                        Status = true,
                        Gender = false
                    },
                    new Product
                    {
                        Name = "Jewelry Pi",
                        Alias = "jewelry-Pi",
                        ProductCategoryId = 4,
                        Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et",
                        Image = "/Assets/client/images/pi.jpg",
                        Price = 300000,
                        PromotionPrice = 220000,
                        HomeFlag = false,
                        HotFlag = true,
                        Quantity = 500,
                        CreatedDate = DateTime.Now.Date,
                        CreatedBy ="khanhbui",
                        UpdatedDate = DateTime.Now.Date,
                        Status = true,
                        Gender = false
                    },
                    new Product
                    {
                        Name = "Jewelry Pi3",
                        Alias = "jewelry-Pi3",
                        ProductCategoryId = 4,
                        Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et",
                        Image = "/Assets/client/images/pi3.jpg",
                        Price = 100000,
                        PromotionPrice = 80000,
                        HomeFlag = false,
                        HotFlag = true,
                        Quantity = 500,
                        CreatedDate = DateTime.Now.Date,
                        CreatedBy ="khanhbui",
                        UpdatedDate = DateTime.Now.Date,
                        Status = true,
                        Gender = false
                    },
                    new Product
                    {
                        Name = "Jewelry Pic1",
                        Alias = "jewelry-Pic1",
                        ProductCategoryId = 4,
                        Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et",
                        Image = "/Assets/client/images/pic1.jpg",
                        Price = 100000,
                        PromotionPrice = 80000,
                        HomeFlag = false,
                        HotFlag = true,
                        Quantity = 500,
                        CreatedDate = DateTime.Now.Date,
                        CreatedBy ="khanhbui",
                        UpdatedDate = DateTime.Now.Date,
                        Status = true,
                        Gender = false
                    },
                    new Product
                    {
                        Name = "Jewelry Pic7",
                        Alias = "jewelry-Pic7",
                        ProductCategoryId = 4,
                        Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et",
                        Image = "/Assets/client/images/pic7.jpg",
                        Price = 100000,
                        PromotionPrice = 80000,
                        HomeFlag = false,
                        HotFlag = true,
                        Quantity = 500,
                        CreatedDate = DateTime.Now.Date,
                        CreatedBy ="khanhbui",
                        UpdatedDate = DateTime.Now.Date,
                        Status = true,
                        Gender = false
                    },
                    new Product
                    {
                        Name = "Jewelry Pic8",
                        Alias = "jewelry-Pic8",
                        ProductCategoryId = 4,
                        Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et",
                        Image = "/Assets/client/images/pic8.jpg",
                        Price = 100000,
                        PromotionPrice = 80000,
                        HomeFlag = false,
                        HotFlag = true,
                        Quantity = 500,
                        CreatedDate = DateTime.Now.Date,
                        CreatedBy ="khanhbui",
                        UpdatedDate = DateTime.Now.Date,
                        Status = true,
                        Gender = false
                    },
                    new Product
                    {
                        Name = "Watch pi2",
                        Alias = "watch-pi2",
                        ProductCategoryId = 8,
                        Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et",
                        Image = "/Assets/client/images/pi2.jpg",
                        Price = 250000,
                        PromotionPrice = 230000,
                        HomeFlag = false,
                        HotFlag = false,
                        Quantity = 500,
                        CreatedDate = DateTime.Now.Date,
                        CreatedBy ="khanhbui",
                        UpdatedDate = DateTime.Now.Date,
                        Status = true,
                        Gender = false
                    },
                    new Product
                    {
                        Name = "Watch pi4",
                        Alias = "watch-pi4",
                        ProductCategoryId = 8,
                        Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et",
                        Image = "/Assets/client/images/pi4.jpg",
                        Price = 350000,
                        PromotionPrice = 350000,
                        HomeFlag = false,
                        HotFlag = false,
                        Quantity = 500,
                        CreatedDate = DateTime.Now.Date,
                        CreatedBy ="khanhbui",
                        UpdatedDate = DateTime.Now.Date,
                        Status = true,
                        Gender = false
                    },
                    new Product
                    {
                        Name = "Watch pic2",
                        Alias = "watch-pic2",
                        ProductCategoryId = 8,
                        Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et",
                        Image = "/Assets/client/images/pic2.jpg",
                        Price = 550000,
                        PromotionPrice = 500000,
                        HomeFlag = false,
                        HotFlag = false,
                        Quantity = 500,
                        CreatedDate = DateTime.Now.Date,
                        CreatedBy ="khanhbui",
                        UpdatedDate = DateTime.Now.Date,
                        Status = true,
                        Gender = true
                    },
                    new Product()
                    {
                        Name = "Watch pic5",
                        Alias = "watch-pi5",
                        ProductCategoryId = 8,
                        Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et",
                        Image = "/Assets/client/images/pic5.jpg",
                        Price = 200000,
                        PromotionPrice = 200000,
                        HomeFlag = false,
                        HotFlag = false,
                        Quantity = 500,
                        CreatedDate = DateTime.Now.Date,
                        CreatedBy ="khanhbui",
                        UpdatedDate = DateTime.Now.Date,
                        Status = true,
                        Gender = false
                    }
                };

                Product watch05 = new Product()
                {
                    Name = "Watch pic11",
                    Alias = "watch-pic11",
                    ProductCategoryId = 8,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et",
                    Image = "/Assets/client/images/pic11.jpg",
                    Price = 650000,
                    PromotionPrice = 620000,
                    HomeFlag = false,
                    HotFlag = false,
                    Quantity = 500,
                    CreatedDate = DateTime.Now.Date,
                    CreatedBy = "khanhbui",
                    UpdatedDate = DateTime.Now.Date,
                    Status = true,
                    Gender = false
                };

                Product watch06 = new Product()
                {
                    Name = "Watch wa",
                    Alias = "watch-wa",
                    ProductCategoryId = 8,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et",
                    Image = "/Assets/client/images/wa.jpg",
                    Price = 850000,
                    PromotionPrice = 800000,
                    HomeFlag = true,
                    HotFlag = false,
                    Quantity = 500,
                    CreatedDate = DateTime.Now.Date,
                    CreatedBy = "khanhbui",
                    UpdatedDate = DateTime.Now.Date,
                    Status = true,
                    Gender = true
                };

                Product watch07 = new Product()
                {
                    Name = "Watch wat",
                    Alias = "watch-wat",
                    ProductCategoryId = 8,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et",
                    Image = "/Assets/client/images/wat.jpg",
                    Price = 850000,
                    PromotionPrice = 800000,
                    HomeFlag = true,
                    HotFlag = true,
                    Quantity = 500,
                    CreatedDate = DateTime.Now.Date,
                    CreatedBy = "khanhbui",
                    UpdatedDate = DateTime.Now.Date,
                    Status = true,
                    Gender = true
                };



                Product shoes1 = new Product()
                {
                    Name = "Shoes pic3",
                    Alias = "shoes-pic3",
                    ProductCategoryId = 9,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et",
                    Image = "/Assets/client/images/pic3.jpg",
                    Price = 250000,
                    PromotionPrice = 230000,
                    HomeFlag = false,
                    HotFlag = false,
                    Quantity = 500,
                    CreatedDate = DateTime.Now.Date,
                    CreatedBy = "khanhbui",
                    UpdatedDate = DateTime.Now.Date,
                    Status = true,
                    Gender = false
                };

                Product shoes2 = new Product()
                {
                    Name = "Shoes pic12",
                    Alias = "shoes-pic12",
                    ProductCategoryId = 9,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et",
                    Image = "/Assets/client/images/pic12.jpg",
                    Price = 450000,
                    PromotionPrice = 430000,
                    HomeFlag = false,
                    HotFlag = false,
                    Quantity = 500,
                    CreatedDate = DateTime.Now.Date,
                    CreatedBy = "khanhbui",
                    UpdatedDate = DateTime.Now.Date,
                    Status = true,
                    Gender = false
                };

                Product shoes3 = new Product()
                {
                    Name = "Shoes sh",
                    Alias = "shoes-sh",
                    ProductCategoryId = 9,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et",
                    Image = "/Assets/client/images/sh.jpg",
                    Price = 350000,
                    PromotionPrice = 320000,
                    HomeFlag = true,
                    HotFlag = false,
                    Quantity = 500,
                    CreatedDate = DateTime.Now.Date,
                    CreatedBy = "khanhbui",
                    UpdatedDate = DateTime.Now.Date,
                    Status = true,
                    Gender = true
                };
                List<Product> newProducts = new List<Product>
                {

                    shoes1,
                    shoes2,
                    shoes3,

                    watch05,
                    watch06,
                    watch07
                };
                products.AddRange(newProducts);
                context.Products.AddRange(products);
                context.SaveChanges();
            }
        }
        #endregion

        #region Create Sample Tags
        private void CreateSampleTags(TeduShoppingOnlineDbContext context)
        {
            if (context.Tags.Count() == 0)
            {
                List<Tag> tags = new List<Tag>();

                Tag laptopComputer = new Tag
                {
                    ID = "laptop-computer",
                    Name = "Laptop computer",
                    Type = "laptop-computer"
                };
                tags.Add(laptopComputer);

                Tag smartPhone = new Tag
                {
                    ID = "smart-phone",
                    Name = "Smart phone",
                    Type = "smart-phone"
                };
                tags.Add(smartPhone);

                Tag perfume = new Tag
                {
                    ID = "perfume",
                    Name = "Perfume",
                    Type = "perfume"
                };
                tags.Add(perfume);

                Tag accessory = new Tag
                {
                    ID = "accessory",
                    Name = "Accessory",
                    Type = "accessory"
                };
                tags.Add(accessory);

                Tag jewelry = new Tag
                {
                    ID = "jewlry",
                    Name = "Jewlry",
                    Type = "jewlry"
                };
                tags.Add(jewelry);

                Tag bag = new Tag
                {
                    ID = "bag",
                    Name = "Bag",
                    Type = "bag"
                };
                tags.Add(bag);

                Tag clothing = new Tag
                {
                    ID = "clothing",
                    Name = "Clothing",
                    Type = "clothing"
                };
                tags.Add(clothing);

                Tag lingerie = new Tag
                {
                    ID = "lingerie",
                    Name = "Lingerie",
                    Type = "lingerie"
                };
                tags.Add(lingerie);

                Tag laptopAccessories = new Tag
                {
                    ID = "laptop-accessories",
                    Name = "Laptop Accessories",
                    Type = "laptop-accessories"
                };
                tags.Add(laptopAccessories);

                Tag watch = new Tag
                {
                    ID = "watch",
                    Name = "Watch",
                    Type = "watch"
                };
                tags.Add(watch);

                Tag shoes = new Tag
                {
                    ID = "shoes",
                    Name = "Shoes",
                    Type = "shoes"
                };
                tags.Add(shoes);

                Tag men = new Tag
                {
                    ID = "men",
                    Name = "Men",
                    Type = "men"
                };
                tags.Add(men);

                Tag women = new Tag
                {
                    ID = "women",
                    Name = "Women",
                    Type = "women"
                };
                tags.Add(women);
                context.Tags.AddRange(tags);
                context.SaveChanges();
            }
        }
        #endregion

        #region Create Sample Product Tags
        private void CreateSampleProductTags(TeduShoppingOnlineDbContext context)
        {
            if (context.ProductTags.Count() == 0)
            {
                List<ProductTag> productTags = new List<ProductTag>()
                {
                    new ProductTag(){ ProductID=1,TagID="bag"},
                    new ProductTag(){ ProductID=1,TagID="women"},
                    new ProductTag(){ ProductID=2,TagID="bag"},
                    new ProductTag(){ ProductID=2,TagID="women"},
                    new ProductTag(){ ProductID=3,TagID="bag"},
                    new ProductTag(){ ProductID=3,TagID="women"},
                    new ProductTag(){ ProductID=4,TagID="bag"},
                    new ProductTag(){ ProductID=4,TagID="women"},
                    new ProductTag(){ ProductID=5,TagID="perfume"},
                    new ProductTag(){ ProductID=5,TagID="women"},

                    new ProductTag(){ ProductID=6,TagID="perfume"},
                    new ProductTag(){ ProductID=6,TagID="men"},
                    new ProductTag(){ ProductID=7,TagID="perfume"},
                    new ProductTag(){ ProductID=7,TagID="men"},

                    new ProductTag(){ ProductID=8,TagID="perfume"},
                    new ProductTag(){ ProductID=8,TagID="women"},
                    new ProductTag(){ ProductID=9,TagID="perfume"},
                    new ProductTag(){ ProductID=9,TagID="women"},

                    new ProductTag(){ ProductID=10,TagID="jewlry"},
                    new ProductTag(){ ProductID=10,TagID="women"},
                    new ProductTag(){ ProductID=11,TagID="jewlry"},
                    new ProductTag(){ ProductID=11,TagID="women"},
                    new ProductTag(){ ProductID=12,TagID="jewlry"},
                    new ProductTag(){ ProductID=12,TagID="women"},
                    new ProductTag(){ ProductID=13,TagID="jewlry"},
                    new ProductTag(){ ProductID=13,TagID="women"},
                    new ProductTag(){ ProductID=14,TagID="jewlry"},
                    new ProductTag(){ ProductID=14,TagID="women"},
                    new ProductTag(){ ProductID=15,TagID="jewlry"},
                    new ProductTag(){ ProductID=15,TagID="women"},
                    new ProductTag(){ ProductID=16,TagID="watch"},
                    new ProductTag(){ ProductID=16,TagID="women"},
                    new ProductTag(){ ProductID=17,TagID="watch"},
                    new ProductTag(){ ProductID=17,TagID="women"},

                    new ProductTag(){ ProductID=18,TagID="watch"},
                    new ProductTag(){ ProductID=18,TagID="men"},

                    new ProductTag(){ ProductID=19,TagID="watch"},
                    new ProductTag(){ ProductID=19,TagID="women"},
                    new ProductTag(){ ProductID=20,TagID="shoes"},
                    new ProductTag(){ ProductID=20,TagID="women"},
                    new ProductTag(){ ProductID=21,TagID="shoes"},
                    new ProductTag(){ ProductID=21,TagID="women"},

                    new ProductTag(){ ProductID=22,TagID="shoes"},
                    new ProductTag(){ ProductID=22,TagID="men"},

                    new ProductTag(){ ProductID=23,TagID="watch"},
                    new ProductTag(){ ProductID=23,TagID="women"},

                    new ProductTag(){ ProductID=24,TagID="watch"},
                    new ProductTag(){ ProductID=24,TagID="men"},
                    new ProductTag(){ ProductID=25,TagID="watch"},
                    new ProductTag(){ ProductID=25,TagID="men"},

                    new ProductTag(){ ProductID=26,TagID="laptop-computer"},
                    new ProductTag(){ ProductID=27,TagID="laptop-computer"},
                    new ProductTag(){ ProductID=28,TagID="laptop-computer"},
                    new ProductTag(){ ProductID=29,TagID="laptop-computer"},
                    new ProductTag(){ ProductID=30,TagID="laptop-computer"},
                    new ProductTag(){ ProductID=31,TagID="laptop-computer"},
                    new ProductTag(){ ProductID=32,TagID="laptop-computer"},
                    new ProductTag(){ ProductID=33,TagID="laptop-computer"},

                    new ProductTag(){ ProductID=34,TagID="bag"},
                    new ProductTag(){ ProductID=34,TagID="women"},
                    new ProductTag(){ ProductID=35,TagID="bag"},
                    new ProductTag(){ ProductID=35,TagID="women"},
                };
                context.ProductTags.AddRange(productTags);
                context.SaveChanges();
            }
        }
        #endregion

        #region Create Sample User
        private void CreateSampleUser(TeduShoppingOnlineDbContext context)
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new TeduShoppingOnlineDbContext()));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new TeduShoppingOnlineDbContext()));

            var user = new ApplicationUser()
            {
                UserName = "khanhbui",
                Email = "bvkhanh0502@gmail.com",
                EmailConfirmed = true,
                BirthDay = new DateTime(1992, 02, 05),
                FullName = "Khanh Vuong Bui",
                Address = "Ho Chi Minh city"
            };
            if (manager.Users.Count(x => x.UserName == "khanhbui") == 0)
            {
                manager.Create(user, "P@ssword123");

                if (!roleManager.Roles.Any())
                {
                    roleManager.Create(new IdentityRole { Name = "Admin" });
                    roleManager.Create(new IdentityRole { Name = "User" });
                }

                var adminUser = manager.FindByEmail("bvkhanh0502@gmail.com");

                manager.AddToRoles(adminUser.Id, new string[] { "Admin", "User" });
            }
        }
        #endregion

        #region Create Sample Page
        private void CreatePage(TeduShoppingOnlineDbContext context)
        {
            if (context.Pages.Count() == 0)
            {
                try
                {
                    var page = new Page()
                    {
                        Name = "Contact",
                        Alias = "contact",
                        Content = @"I am Senior Full Stack.NET Developer",
                        Status = true
                    };
                    context.Pages.Add(page);
                    context.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var eve in ex.EntityValidationErrors)
                    {
                        Trace.WriteLine($"Entity of type \"{eve.Entry.Entity.GetType().Name}\" in state \"{eve.Entry.State}\" has the following validation error.");
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Trace.WriteLine($"- Property: \"{ve.PropertyName}\", Error: \"{ve.ErrorMessage}\"");
                        }
                    }
                }

            }
        }
        #endregion

        #region Create Sample Contact Detail
        private void CreateSampleContactDetail(TeduShoppingOnlineDbContext context)
        {
            if (context.ContactDetails.Count() == 0)
            {
                //Số 23, Hiệp Bình Chánh, Thủ Đức, Hồ Chí Minh, Vietnam
                //Latitude: 10.828597 | Longitude: 106.726447

                //Amaris Việt Nam 285 Cách Mạng Tháng 8, Phường 12, Quận 10, Hồ Chí Minh, Vietnam
                //Latitude: 10.778267 | Longitude: 106.680082

                var contactDetail = new ContactDetail()
                {
                    Id = 1,
                    Name = "Shoping Online MVC",
                    Address = "Thu Duc, TpHCM city",
                    Email = "bvkhanh0502@gmail.com",
                    PhoneNumber = "093 617 6935",
                    Website = "https://www.linkedin.com/in/khanh-vuong-bui/",
                    Status = true,
                    Telephone = "+1 800 547 5478",
                    Fax = "+1 800 658 5784",
                    Latitude = 10.828597,
                    Longitude = 106.726447
                };
                context.ContactDetails.Add(contactDetail);
                context.SaveChanges();
            }
        }
        #endregion
    }
}
