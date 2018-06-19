using AutoMapper;
using System.Collections.Generic;
using System.Web.Mvc;
using TeduShopingOnline.Model.Models;
using TeduShopingOnline.Service;
using TeduShopingOnline.Service.Interfaces;
using TeduShopingOnline.Web.ViewModels;

namespace TeduShopingOnline.Web.Controllers
{
    public class HomeController : Controller
    {
        IProductService _productService;
        IProductCategoryService _productCategoryService;
        IBrandService _brandService;
        ISlideService _slideService;

        public HomeController(
            IProductService productService,
            IProductCategoryService productCategoryService,
            IBrandService brandService,
            ISlideService slideService)
        {
            this._productService = productService;
            this._productCategoryService = productCategoryService;
            this._brandService = brandService;
            this._slideService = slideService;
        }

        public ActionResult Index()
        {
            HomeViewModel homeViewModel = new HomeViewModel();
            homeViewModel.LastestProductsViewModel = _productService.GetLastestProducts();
            homeViewModel.LastestProductsForMenViewModel = _productService.GetLastestProductsByGender(true);
            homeViewModel.LastestProductsForWomenViewModel = _productService.GetLastestProductsByGender(false);
            homeViewModel.PopularProductsViewModel = _productService.GetPopularProducts();
            return View(homeViewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        /// <summary>
        /// Header is name of the view 
        /// If Header is equals with Action Method. Ex: Action method = view name = Header
        /// we do not need to specific view name
        /// ChildActionOnly is an attribute that user cannot call directly on Url
        /// </summary>
        /// <returns></returns>
        [ChildActionOnly]
        public ActionResult Header()
        {
            return PartialView();
        }

        [ChildActionOnly]
        [OutputCache(
            Duration = 3600)]
        /// Catch attributes
        /// Location is stored in server side especially in RAM, because we want  all of users access have the same result (cached result)
        /// when access to this page
        /// Mostly, we use cache technique for the unchanged content or little changing of content
        public ActionResult Footer()
        {
            var productCategories = _productCategoryService.GetAllProductCategory();
            var brands = _brandService.GetTopBrand();
            var footerViewModel = new FooterViewModel();
            footerViewModel.BrandsViewModel = brands;
            footerViewModel.ProductCategoriesViewModel = productCategories;
            return PartialView(footerViewModel);
        }

        [ChildActionOnly]
        [OutputCache(Duration = 3600)]
        /// Catch attributes
        /// Location is stored in server side especially on RAM server
        /// Because we want all of the users accessing this page can help the same result (cached result)
        /// We can see that every user accesses this page, the content of Footer, Category, Slide is always being accessed
        public ActionResult Category()
        {
            var productCategories = _productCategoryService.GetAllProductCategoryWithBrand();
            //var productCategoriesViewModel = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(productCategories);
            return PartialView(productCategories);
        }

        [ChildActionOnly]
        [OutputCache(Duration = 3600)]
        /// Catch attributes
        /// Location is stored in server side especially on RAM server
        /// Because we want all of the users accessing this page can help the same result (cached result)
        public ActionResult Slide()
        {
            var slides = _slideService.GetAllSlides();
            var slidesViewModel = Mapper.Map<IEnumerable<Slide>, IEnumerable<SlideViewModel>>(slides);
            return PartialView(slidesViewModel);
        }
    }
}
