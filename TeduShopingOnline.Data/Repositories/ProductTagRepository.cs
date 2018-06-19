using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduShopingOnline.Data.Infrastructures;
using TeduShopingOnline.Data.Repositories.Interfaces;
using TeduShopingOnline.Model.Models;

namespace TeduShopingOnline.Data.Repositories
{
    public class ProductTagRepository : RepositoryBase<ProductTag>, IProductTagRepository
    {
        public ProductTagRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<ProductTag> GetTagsByProductId(int productId)
        {
            return DbContext.ProductTags.Where(x => x.ProductID == productId);
        }
    }
}
