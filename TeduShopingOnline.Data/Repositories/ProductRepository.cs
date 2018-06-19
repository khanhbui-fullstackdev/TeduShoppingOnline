using System;
using System.Collections.Generic;
using System.Linq;
using TeduShopingOnline.Data.Infrastructures;
using TeduShopingOnline.Data.Repositories.Interfaces;
using TeduShopingOnline.Model.Models;

namespace TeduShopingOnline.Data.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<Product> GetLastestProducts()
        {
            return this.DbContext.Products
                .OrderByDescending(x => x.CreatedDate)
                .Where(x => x.Status == true).Take(6);
        }

        public IEnumerable<Product> GetLastestProductsByGender(bool gender)
        {
            return this.DbContext.Products
                .OrderByDescending(x => x.CreatedDate)
                .Where(x => x.Status == true && x.Gender == gender).Take(6);
        }

        public IEnumerable<Product> GetPopularProducts()
        {
            return this.DbContext.Products
                .Where(
                x => x.Status == true &&
                x.HotFlag == true &&
                x.HomeFlag == true &&
                x.TopSale == false);
        }

        public Product GetProductById(int productId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetProducts()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetProductsByBrand(int brandId,string brandName)
        {
            //var id = 1;
            //var query =
            //   from post in database.Posts
            //   join meta in database.Post_Metas on post.ID equals meta.Post_ID
            //   where post.ID == id
            //   select new { Post = post, Meta = meta };

            //var id = 1;
            //var query = database.Posts    // your starting point - table in the "from" statement
            //   .Join(database.Post_Metas, // the source table of the inner join
            //      post => post.ID,        // Select the primary key (the first part of the "on" clause in an sql "join" statement)
            //      meta => meta.Post_ID,   // Select the foreign key (the second part of the "on" clause)
            //      (post, meta) => new { Post = post, Meta = meta }) // selection
            //   .Where(postAndMeta => postAndMeta.Post.ID == id);    // where statement

            // This query return anonymous type so you cannot return
            //var queryLinqSyntax = from product in DbContext.Products
            //                      join brand in DbContext.Brands on
            //                      product.ProductCategoryId equals brand.ProductCategoryId
            //                      select  new
            //                      {
            //                          ProductId = product.Id,
            //                          ProductName = product.Name,
            //                          ProductPrice = product.Price,
            //                          ProductPromotionPrice = product.PromotionPrice,
            //                          ProductCategoryID = product.ProductCategoryId,
            //                          BrandId = brand.Id,
            //                          BrandName = brand.Name
            //                      };

            //var queryLamdaExpression = DbContext.Products.Join(DbContext.Brands,
            //    brand => brand.ProductCategoryId,
            //    product => product.ProductCategoryId,
            //    (product, brand) => new
            //    {
            //        ProductId = product.Id,
            //        ProductName = product.Name,
            //        ProductPrice = product.Price,
            //        ProductPromotionPrice = product.PromotionPrice,
            //        ProductCategoryID = product.ProductCategoryId,
            //        BrandId = brand.Id,
            //        BrandName = brand.Name
            //    });
          
            var products = from product in DbContext.Products
                           join brand in DbContext.Brands on
                           product.ProductCategoryId equals brand.ProductCategoryId
                           where brand.Id == brandId && brandId == brand.Id && product.Name.Contains(brandName)
                           select product;
            return products;
        }

        public IEnumerable<Product> GetProductsByCategory(int productCategoryId)
        {
            return this.DbContext.Products
                .Where(x => x.Status &&
                x.ProductCategoryId == productCategoryId);
        }

        public IEnumerable<Product> GetProductsByGender(bool gender)
        {
            return this.DbContext.Products
                .OrderBy(x => x.CreatedDate)
                .Where(
                x => x.Status == true &&
                x.Gender == gender);
        }

        public IEnumerable<Product> GetProductsByTag(string tagId)
        {
            // Using Linq expression to join table
            var products = from product in DbContext.Products
                           join productTag in DbContext.ProductTags on
                           product.Id equals productTag.ProductID
                           where product.Status == true && productTag.TagID.Equals(tagId)
                           select product;

            // Using Lamda expression to join table
            //var products1 = this.DbContext.Products.Join(DbContext.ProductTags,
            //    product => product.Id,
            //    productTag => productTag.ProductID,
            //    (product, productTag) => productTag)
            //    .Where(x => x.TagID.Equals(tagId))
            //    .Select(p=>new Product { Name = p.Product.Name });
            return products;
        }
    }
}
