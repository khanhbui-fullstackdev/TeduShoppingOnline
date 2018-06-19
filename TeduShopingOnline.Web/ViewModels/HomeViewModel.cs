using System.Collections.Generic;
using TeduShopingOnline.Model.Models;

namespace TeduShopingOnline.Web.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Product> LastestProductsViewModel { get; set; }
        public IEnumerable<Product> PopularProductsViewModel { get; set; }
        public IEnumerable<Product> LastestProductsForMenViewModel { get; set; }
        public IEnumerable<Product> LastestProductsForWomenViewModel { get; set; }
    }
}