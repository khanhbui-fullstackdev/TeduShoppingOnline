using System.Collections.Generic;
using System.Linq;
using TeduShopingOnline.Data.Infrastructures;
using TeduShopingOnline.Data.Repositories.Interfaces;
using TeduShopingOnline.Model.Models;

namespace TeduShopingOnline.Data.Repositories
{
    public class BrandRepository : RepositoryBase<Brand>, IBrandRepository
    {
        public BrandRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<Brand> GetTopBrand()
        {
            return DbContext.Brands.Where(x => x.TopBrand == true);
        }
    }
}
