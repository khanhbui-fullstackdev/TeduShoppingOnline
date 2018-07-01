using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TeduShopingOnline.Common.Constants;
using TeduShopingOnline.Common.Helpers;
using TeduShopingOnline.Model.Models;
using TeduShopingOnline.Service.Interfaces;
using TeduShopingOnline.Web.Infrastructure.Cores;
using TeduShopingOnline.Web.ViewModels;

namespace TeduShopingOnline.Web.ApiControllers
{
    [RoutePrefix("api/product-category")]
    public class ProductCategoryController : ApiControllerBase
    {
        private IProductCategoryService _productCategoryService;
        //pageSize = 9 means the number of item displayed on page(so item dc hien thi tren 1 page)
        //private int pageSize = 5;
        //Maxpage = 5 only allow to display 5 pages only from 1 to 5
        private int maxPage = int.Parse(ConfigHelper.GetByKey(CommonConstants.MaxPage).ToString());

        public ProductCategoryController(
            IErrorService errorService,
            IProductCategoryService productCategoryService) : base(errorService)
        {
            this._productCategoryService = productCategoryService;
        }

        [Route("get-all-product-category")]
        public HttpResponseMessage GetAllProductCategory(HttpRequestMessage httpRequestMessage, string keyword, int page, int pageSize = 5)
        {
            return CreateHttpResponse(httpRequestMessage, () =>
            {
                int totalRow = 0; // totalRow = productCategories.Count(); 9
                var productCategoryModel = _productCategoryService.GetAllProductCategory(keyword, page, pageSize, out totalRow);
                int totalPage = (int)Math.Ceiling((double)totalRow / pageSize);

                var productCategoryViewModel = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(productCategoryModel);
                var paginationSet = new PaginationSet<ProductCategoryViewModel>()
                {
                    Items = productCategoryViewModel,
                    MaxPage = maxPage,
                    Page = page,
                    TotalCount = totalRow,//9
                    TotalPages = totalPage,//
                };

                var httpResponse = httpRequestMessage.CreateResponse(HttpStatusCode.OK, paginationSet);
                return httpResponse;
            });
        }
    }
}
