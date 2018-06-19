using System;
using System.Collections.Generic;
using System.Web.Mvc;
using TeduShopingOnline.Common.Helpers;
using TeduShopingOnline.Common.Constants;
using TeduShopingOnline.Service.Interfaces;
using TeduShopingOnline.Web.ViewModels;
using AutoMapper;
using TeduShopingOnline.Model.Models;
using TeduShopingOnline.Web.Infrastructure.Cores;
using TeduShopingOnline.Service;

namespace TeduShopingOnline.Web.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService;
        private IProductCategoryService _productCategoryService;
        private IBrandService _brandService;
        private IProductTagService _productTagService;
        private ITagService _tagService;

        private int pageSize = int.Parse(ConfigHelper.GetByKey(CommonConstants.PageSize).ToString());
        private int maxPage = int.Parse(ConfigHelper.GetByKey(CommonConstants.MaxPage).ToString());

        public ProductController(
            IProductService productService,
            IProductCategoryService productCategoryService,
            IBrandService brandService,
            IProductTagService productTagService,
            ITagService tagService)
        {
            this._productService = productService; // Ioc Inversion of Control is the way to remove dependency in code
            this._productCategoryService = productCategoryService;
            this._brandService = brandService;
            this._productTagService = productTagService;
            this._tagService = tagService;
        }

        // GET: Product
        public ActionResult Index(int page = 1, string sort = "")
        {
            int totalRow = 0;
            var productsModel = _productService.GetProducts(page, pageSize, sort, out totalRow);
            int totalPage = (int)Math.Ceiling((double)totalRow / pageSize);

            var productsViewModel = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(productsModel);
            ViewBag.allProduct = "All Products";

            var paginationSet = new PaginationSet<ProductViewModel>()
            {
                Items = productsViewModel,
                MaxPage = maxPage,
                Page = page,
                TotalCount = totalRow,
                TotalPages = totalPage,
            };

            return View(paginationSet);
        }

        public ActionResult ProductsByProductCategory(int productCategoryId, int page = 1, string sort = "")
        {
            int totalRow = 0;
            var productModel = _productService.GetProductsByCategory(productCategoryId, page, pageSize, sort, out totalRow);
            int totalPage = (int)Math.Ceiling((double)totalRow / pageSize);

            var productViewModel = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(productModel);
            var productCategoryModel = _productCategoryService.GetProductCategoryById(productCategoryId);
            ViewBag.productCategoryViewModel = Mapper.Map<ProductCategory, ProductCategoryViewModel>(productCategoryModel);

            var paginationSet = new PaginationSet<ProductViewModel>()
            {
                Items = productViewModel,
                MaxPage = maxPage,
                Page = page,
                TotalCount = totalRow,
                TotalPages = totalPage,
            };
            return View(paginationSet);
        }

        public ActionResult ProductsByBrand(string brandName, int brandId, int page = 1, string sort = "")
        {
            int totalRow = 0;
            var productsModel = _productService.GetProductsByBrand(brandId, brandName, page, pageSize, sort, out totalRow);
            int totalPage = (int)Math.Ceiling((double)totalRow / pageSize);
            var productsViewModel = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(productsModel);


            var brandModel = _brandService.GetBrandById(brandId);
            // var brandViewModel = Mapper.Map<Brand, BrandViewModel>(brandModel);
            ViewBag.brandModel = brandModel;

            var paginationSet = new PaginationSet<ProductViewModel>()
            {
                Items = productsViewModel,
                MaxPage = maxPage,
                Page = page,
                TotalCount = totalRow,
                TotalPages = totalPage,
            };
            return View(paginationSet);
        }

        public ActionResult ProductsByGender(string gender, int page = 1, string sort = "")
        {
            int totalRow = 0;
            bool isMen = gender.ToLower().Equals("men") ? true : false;
            var productsModel = _productService.GetProductsByGender(isMen, page, pageSize, sort, out totalRow);
            int totalPage = (int)Math.Ceiling((double)totalRow / pageSize);

            var productsViewModel = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(productsModel);
            var paginationSet = new PaginationSet<ProductViewModel>()
            {
                Items = productsViewModel,
                MaxPage = maxPage,
                Page = page,
                TotalCount = totalRow,
                TotalPages = totalPage,
            };
            ViewBag.gender = gender;
            return View(paginationSet);
        }

        public ActionResult ProductDetail(int id)
        {
            Product productModel = _productService.GetProductDetail(id);
            var productsModel = _productService.GetProductsByCategory(productModel.ProductCategoryId);

            if (productModel != null)
            {
                ProductDetailViewModel productDetailViewModel = new ProductDetailViewModel();
                productDetailViewModel.Product = productModel;
                productDetailViewModel.Products = productsModel;
                productDetailViewModel.Tags = _productTagService.GetTagsByProductId(id);
                return View(productDetailViewModel);
            }
            else
            {
                CustomErrorViewModel customError = new CustomErrorViewModel
                {
                    Description = "Item doesn't exist. Please try again!"
                };
                return View(ViewUrls.ErrorView, customError);
            }
        }

        public ActionResult ProductsByTag(string tagId, int page = 1, string sort = "")
        {
            int totalRow = 0;
            var productsModel = _productService.GetProductsByTag(tagId.ToLower(), page, pageSize, sort, out totalRow);
            int totalPage = (int)Math.Ceiling((double)totalRow / pageSize);

            var productsViewModel = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(productsModel);
            var tagModel = _tagService.GetTagByTagId(tagId.ToLower());
            var tagViewModel = Mapper.Map<Tag, TagViewModel>(tagModel);
            ViewBag.TagViewModel = tagViewModel;

            var paginationSet = new PaginationSet<ProductViewModel>()
            {
                Items = productsViewModel,
                MaxPage = maxPage,
                Page = page,
                TotalCount = totalRow,
                TotalPages = totalPage,
            };
            return View(paginationSet);
        }

        public JsonResult GetProductsByName(string keyword)
        {
            var productsModel = _productService.GetProductsByName(keyword);
            object jsonData = new object();
            jsonData = productsModel;
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SearchResult(string keyword, int page = 1, string sort = "")
        {
            int totalRow = 0;
            var productsModel = _productService.GetProductsByName(keyword, page, pageSize, sort, out totalRow);
            int totalPage = (int)Math.Ceiling((double)totalRow / pageSize);

            var productsViewModel = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(productsModel);
            var paginationSet = new PaginationSet<ProductViewModel>()
            {
                Items = productsViewModel,
                MaxPage = maxPage,
                Page = page,
                TotalCount = totalRow,
                TotalPages = totalPage,
            };
            ViewBag.keyword = keyword;
            return View(paginationSet);
        }
    }
}
