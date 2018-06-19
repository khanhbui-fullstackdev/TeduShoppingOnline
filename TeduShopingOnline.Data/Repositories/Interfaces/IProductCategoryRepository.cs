using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduShopingOnline.Data.Infrastructures;
using TeduShopingOnline.Model.Models;

namespace TeduShopingOnline.Data.Repositories.Interfaces
{
    /// <summary>
    /// To define some methods that purpose for building business logic
    /// Using this class aims to build some particular methods
    /// </summary>
    public interface IProductCategoryRepository : IRepository<ProductCategory>
    {
        // Building some methods that aim for business logic
        IEnumerable<ProductCategory> GetByAlias(string alias);
        IEnumerable<ProductCategory> GetAllProductCategoryWithBrand();
    }
}
