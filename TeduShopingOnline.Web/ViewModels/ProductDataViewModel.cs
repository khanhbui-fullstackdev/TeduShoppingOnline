using System.Collections.Generic;
using TeduShopingOnline.Model.Models;

namespace TeduShopingOnline.Web.ViewModels
{
    public class ProductDataViewModel
    {
        public IEnumerable<Product> ProductsForMen;
        public IEnumerable<Product> ProductsForWomen;
        public IEnumerable<Product> Products;
    }
}