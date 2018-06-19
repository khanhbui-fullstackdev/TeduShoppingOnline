using System;
using System.Collections.Generic;
using System.Linq;
using TeduShopingOnline.Data.Infrastructures;
using TeduShopingOnline.Data.Repositories.Interfaces;
using TeduShopingOnline.Model.Models;
using TeduShopingOnline.Service.Interfaces;

namespace TeduShopingOnline.Service
{
    public class ProductService : IProductService
    {
        IProductRepository _productRepository;
        IUnitOfWork _unitOfWork;

        public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            this._productRepository = productRepository;
            this._unitOfWork = unitOfWork;
        }

        public IEnumerable<Product> GetProductsByGender(bool gender)
        {
            return _productRepository.GetProductsByGender(gender);
        }

        public IEnumerable<Product> GetLastestProducts()
        {
            return _productRepository.GetLastestProducts();
        }

        public IEnumerable<Product> GetLastestProductsByGender(bool gender)
        {
            return _productRepository.GetLastestProductsByGender(gender);
        }

        public IEnumerable<Product> GetProductsByGender(bool gender, int page, int pageSize, string sort, out int totalRow)
        {
            var products = _productRepository.GetProductsByGender(gender);
            switch (sort)
            {
                case "new":
                    products = products.OrderByDescending(item => item.CreatedBy);
                    break;

                case "popular":
                    products = products.OrderByDescending(item => item.ViewCount);
                    break;

                case "discount":
                    products = products.OrderByDescending(item => item.PromotionPrice.HasValue);
                    break;

                case "price":
                    products = products.OrderBy(item => item.Price);
                    break;

                default:
                    break;               
            }
            totalRow = products.Count();
            return products.Skip((page - 1) * pageSize).Take(pageSize);
        }

        public IEnumerable<Product> GetPopularProducts()
        {
            return _productRepository.GetPopularProducts();
        }

        public IEnumerable<Product> GetProductsByBrand(int brandId, string brandName, int page, int pageSize, string sort, out int totalRow)
        {
            var products = _productRepository.GetProductsByBrand(brandId, brandName);
            switch (sort)
            {
                case "new":
                    products = products.OrderByDescending(item => item.CreatedBy);
                    break;

                case "popular":
                    products = products.OrderByDescending(item => item.ViewCount);
                    break;

                case "discount":
                    products = products.OrderByDescending(item => item.PromotionPrice.HasValue);
                    break;

                case "price":
                    products = products.OrderBy(item => item.Price);
                    break;

                default:
                    break;
            }
            totalRow = products.Count();
            return products.Skip((page - 1) * pageSize).Take(pageSize);
        }

        public IEnumerable<Product> GetProductsByCategory(int productCategoryId)
        {
            return _productRepository.GetProductsByCategory(productCategoryId).Take(10);
        }

        public Product GetTopSaleProduct()
        {
            return _productRepository.GetSingleByCondition(x => x.Status == true && x.TopSale == true);
        }

        public IEnumerable<Product> GetProductsByCategory(int productCategoryId, int page, int pageSize, string sort, out int totalRow)
        {
            var products = _productRepository
                .GetMulti
                (
                    item =>
                        item.Status &&
                        item.ProductCategoryId == productCategoryId &&
                        item.HomeFlag == false
                );

            switch (sort)
            {
                case "new":
                    products = products.OrderByDescending(item => item.CreatedDate);
                    break;

                case "popular":
                    products = products.OrderByDescending(item => item.ViewCount);
                    break;

                case "discount":
                    products = products.OrderByDescending(item => item.PromotionPrice.HasValue);
                    break;

                case "price":
                    products = products.OrderBy(item => item.Price);
                    break;

                default:
                    break;
            }
            totalRow = products.Count();
            return products.Skip((page - 1) * pageSize).Take(pageSize);//page = 1 --> bang ghi 0 (skip) lay 20(take)
        }

        public IEnumerable<Product> GetProducts(int page, int pageSize, string sort, out int totalRow)
        {
            var products = _productRepository.GetAll();
            switch (sort)
            {
                case "new":
                    products = products.OrderByDescending(item => item.CreatedDate);
                    break;

                case "popular":
                    products = products.OrderByDescending(item => item.ViewCount);
                    break;

                case "discount":
                    products = products.OrderByDescending(item => item.PromotionPrice.HasValue);
                    break;

                case "price":
                    products = products.OrderByDescending(item => item.Price);
                    break;

                default:
                    break;
            }
            totalRow = products.Count();
            return products.Skip((page - 1) * pageSize).Take(pageSize);// page = 1 default --> Skip( 0 * 3).Take(20);
        }

        public Product GetProductDetail(int productId)
        {
            return _productRepository.GetSingleById(productId);
        }

        public IEnumerable<string> GetProductsByName(string keyword)
        {
            return _productRepository.GetMulti(x => x.Name.Contains(keyword) && x.Status == true).Select(y => y.Name);
        }

        public IEnumerable<Product> GetProductsByName(string keyword, int page, int pageSize, string sort, out int totalRow)
        {
            var products = _productRepository.GetMulti(x => x.Name.Contains(keyword) && x.Status == true);                
            switch (sort)
            {
                case "new":
                    products = products.OrderByDescending(item => item.CreatedDate);
                    break;

                case "popular":
                    products = products.OrderByDescending(item => item.ViewCount);
                    break;

                case "discount":
                    products = products.OrderByDescending(item => item.PromotionPrice.HasValue);
                    break;

                case "price":
                    products = products.OrderByDescending(item => item.Price);
                    break;

                default:
                    break;
            }
            totalRow = products.Count();
            return products.Skip((page - 1) * pageSize).Take(pageSize);// page = 1 default --> Skip( 0 * 3).Take(20);
        }

        public void IncreaseView(int id)
        {
            var product = _productRepository.GetSingleById(id);
            if (product.ViewCount.HasValue)
            {
                product.ViewCount++;
            }
            else
            {
                product.ViewCount = 0;
            }
        }

        public IEnumerable<Product> GetProductsByTag(string tagId, int page, int pageSize, string sort, out int totalRow)
        {
            var products = _productRepository.GetProductsByTag(tagId);
            switch (sort)
            {
                case "new":
                    products = products.OrderByDescending(item => item.CreatedDate);
                    break;

                case "popular":
                    products = products.OrderByDescending(item => item.ViewCount);
                    break;

                case "discount":
                    products = products.OrderByDescending(item => item.PromotionPrice.HasValue);
                    break;

                case "price":
                    products = products.OrderByDescending(item => item.Price);
                    break;

                default:
                    break;
            }
            totalRow = products.Count();

            return products.Skip((page - 1) * pageSize).Take(pageSize);
        }
    }
}
