using System.Collections.Generic;
using TeduShopingOnline.Model.Models;

namespace TeduShopingOnline.Service
{
    public interface IBrandService 
    {
        Brand GetBrandById(int brandId);
        IEnumerable<Brand> GetTopBrand();       
    }
}
