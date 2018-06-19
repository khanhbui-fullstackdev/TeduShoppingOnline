using System.Collections.Generic;
using TeduShopingOnline.Data.Infrastructures;
using TeduShopingOnline.Data.Repositories.Interfaces;
using TeduShopingOnline.Model.Models;
using TeduShopingOnline.Service.Interfaces;

namespace TeduShopingOnline.Service
{
    public class ProductCategoryService : IProductCategoryService
    {
        IProductCategoryRepository _productCategoryRepository;
        IUnitOfWork _unitOfWork;

        public ProductCategoryService(IProductCategoryRepository productCategoryRepository, IUnitOfWork unitOfWork)
        {
            this._productCategoryRepository = productCategoryRepository;
            this._unitOfWork = unitOfWork;
        }

        public IEnumerable<ProductCategory> GetAllProductCategoryWithBrand()
        {
            return _productCategoryRepository.GetAllProductCategoryWithBrand();
        }

        public IEnumerable<ProductCategory> GetAllProductCategory()
        {
            return _productCategoryRepository.GetAll();
        }

        public ProductCategory GetProductCategoryById(int productCategoryId)
        {
            return _productCategoryRepository.GetSingleById(productCategoryId);
        }
    }
}
