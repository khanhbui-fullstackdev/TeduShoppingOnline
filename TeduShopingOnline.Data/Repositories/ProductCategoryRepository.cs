using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TeduShopingOnline.Data.Infrastructures;
using TeduShopingOnline.Data.Repositories.Interfaces;
using TeduShopingOnline.Model.Models;

namespace TeduShopingOnline.Data.Repositories
{
    public class ProductCategoryRepository : RepositoryBase<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<ProductCategory> GetAllProductCategoryWithBrand()
        {
            var query = this.DbContext.ProductCategories
                .Include(x => x.Brands)
                .Where(x => x.Status);
            return query.ToList();            
        }

        public ICollection<ProductCategory> GetAllProductCategory()
        {
            return this.DbContext.ProductCategories.ToList();
        }

        public IEnumerable<ProductCategory> GetByAlias(string alias)
        {
            return this.DbContext.ProductCategories.Where(item => item.Alias.Equals(alias));
        }
    }
}
