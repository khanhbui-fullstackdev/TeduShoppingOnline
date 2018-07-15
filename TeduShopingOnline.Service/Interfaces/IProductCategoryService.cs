using System.Collections.Generic;
using TeduShopingOnline.Model.Models;

namespace TeduShopingOnline.Service.Interfaces
{
    public interface IProductCategoryService
    {
        IEnumerable<ProductCategory> GetAllProductCategoryWithBrand();
        IEnumerable<ProductCategory> GetAllProductCategory();
        IEnumerable<ProductCategory> GetAllProductCategory(int page, int pageSize, out int totalRow);
        IEnumerable<ProductCategory> GetAllProductCategory(string keyword, int page, int pageSize, out int totalRow);
        ProductCategory GetProductCategoryById(int productCategoryId);
        ProductCategory AddProductCategory(ProductCategory productCategory);
        void UpdateProductCategory(ProductCategory productCategory);
        void SaveChanges();
    }
}
