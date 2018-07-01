using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<ProductCategory> GetAllProductCategory(int page, int pageSize, out int totalRow)
        {
            var productCategories = _productCategoryRepository.GetAll().OrderByDescending(x => x.CreatedDate);
            totalRow = productCategories.Count();
            // by default starting page  = 1
            // pageSize = 5
            // totalRow = 9
            return productCategories.Skip(page * pageSize).Take(pageSize);
        }

        public IEnumerable<ProductCategory> GetAllProductCategory(string keyword, int page, int pageSize, out int totalRow)
        {
            if (!string.IsNullOrEmpty(keyword))
            {
                var productCategories = _productCategoryRepository
                                        .GetMulti(x => x.Name.Contains(keyword) || x.Description.Contains(keyword))
                                        .OrderByDescending(x => x.CreatedDate);
                totalRow = productCategories.Count();
                return productCategories.Skip(page * pageSize).Take(pageSize);
            }
            else
            {
                var productCategories = _productCategoryRepository
                                            .GetAll()
                                            .OrderByDescending(x => x.CreatedDate);
                totalRow = productCategories.Count();
                return productCategories.Skip(page * pageSize).Take(pageSize);
            }

        }

        public ProductCategory GetProductCategoryById(int productCategoryId)
        {
            return _productCategoryRepository.GetSingleById(productCategoryId);
        }
    }
}
