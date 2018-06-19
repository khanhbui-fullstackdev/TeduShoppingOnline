using System.Collections.Generic;
using TeduShopingOnline.Model.Models;

namespace TeduShopingOnline.Service.Interfaces
{
    public interface IProductCategoryService
    {
        IEnumerable<ProductCategory> GetAllProductCategoryWithBrand();
        IEnumerable<ProductCategory> GetAllProductCategory();
        ProductCategory GetProductCategoryById(int productCategoryId);
    }
}
