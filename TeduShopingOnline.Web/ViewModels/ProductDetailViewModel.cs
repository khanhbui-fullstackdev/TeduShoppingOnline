using System.Collections.Generic;
using TeduShopingOnline.Model.Models;

namespace TeduShopingOnline.Web.ViewModels
{
    public class ProductDetailViewModel
    {
        public Product Product { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Tag> Tags { get; set; }
    }
}