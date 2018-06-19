using System.Collections.Generic;
using TeduShopingOnline.Model.Models;

namespace TeduShopingOnline.Service.Interfaces
{
    public interface IProductService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="page">Page default: 1</param>
        /// <param name="pageSize">The number of item displayed on each page</param>
        /// <param name="sort"></param>
        /// <param name="totalRow">Total row = products.Count()</param>
        /// <returns></returns>
        IEnumerable<Product> GetProducts(int page, int pageSize, string sort, out int totalRow);
        IEnumerable<string>  GetProductsByName(string keyword);
        IEnumerable<Product> GetProductsByName(string keyword, int page, int pageSize, string sort, out int totalRow);
        IEnumerable<Product> GetProductsByCategory(int productCategoryId);
        IEnumerable<Product> GetProductsByCategory(int productCategoryId, int page, int pageSize, string sort, out int totalRow);
        IEnumerable<Product> GetProductsByBrand(int brandId, string brandName, int page, int pageSize, string sort, out int totalRow);
        IEnumerable<Product> GetLastestProducts();
        IEnumerable<Product> GetLastestProductsByGender(bool gender);
        IEnumerable<Product> GetPopularProducts();
        IEnumerable<Product> GetProductsByGender(bool gender);
        IEnumerable<Product> GetProductsByGender(bool gender, int page, int pageSize, string sort, out int totalRow);
        Product GetTopSaleProduct();
        Product GetProductDetail(int productId);
        void IncreaseView(int id);
        IEnumerable<Product> GetProductsByTag(string tagId, int page, int pageSize, string sort, out int totalRow);
    }
}
