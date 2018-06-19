using System.Collections.Generic;
using TeduShopingOnline.Model.Models;

namespace TeduShopingOnline.Web.ViewModels
{
    public class FooterViewModel
    {
        public IEnumerable<Brand> BrandsViewModel { get; set; }
        public IEnumerable<ProductCategory> ProductCategoriesViewModel { get; set; }
    }
}