using System.Collections.Generic;
using System.Linq;
using TeduShopingOnline.Data.Infrastructures;
using TeduShopingOnline.Data.Repositories.Interfaces;
using TeduShopingOnline.Model.Models;
using TeduShopingOnline.Service.Interfaces;

namespace TeduShopingOnline.Service
{
    public class ProductTagService : IProductTagService
    {
        private IProductTagRepository _productTagRepository;
        private IUnitOfWork _unitOfWork;

        public ProductTagService(IProductTagRepository productTagRepository, IUnitOfWork unitOfWork)
        {
            this._productTagRepository = productTagRepository;
            this._unitOfWork = unitOfWork;
        }

        public IEnumerable<Tag> GetTagsByProductId(int productId)
        {
            return _productTagRepository
                .GetMulti(x => x.ProductID == productId, new string[] { "Tag" })
                .Select(y => y.Tag);
        }
    }
}
