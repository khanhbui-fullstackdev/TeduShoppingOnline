using System.Collections.Generic;
using TeduShopingOnline.Data.Infrastructures;
using TeduShopingOnline.Model.Models;

namespace TeduShopingOnline.Data.Repositories.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> GetProducts();
        Product GetProductById(int productId);
        IEnumerable<Product> GetLastestProducts();
        IEnumerable<Product> GetPopularProducts();
        IEnumerable<Product> GetLastestProductsByGender(bool gender);
        IEnumerable<Product> GetProductsByGender(bool gender);
        IEnumerable<Product> GetProductsByCategory(int productCategoryId);
        IEnumerable<Product> GetProductsByBrand(int brandId, string brandName);
        IEnumerable<Product> GetProductsByTag(string tagId);
    }
}
