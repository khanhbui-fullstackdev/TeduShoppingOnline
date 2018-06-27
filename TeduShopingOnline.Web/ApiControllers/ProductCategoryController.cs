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

        private int pageSize = int.Parse(ConfigHelper.GetByKey(CommonConstants.PageSize).ToString());
        private int maxPage = int.Parse(ConfigHelper.GetByKey(CommonConstants.MaxPage).ToString());

        public ProductCategoryController(
            IErrorService errorService,
            IProductCategoryService productCategoryService) : base(errorService)
        {
            this._productCategoryService = productCategoryService;
        }

        [Route("get-all-product-category")]
        public HttpResponseMessage GetAllProductCategory(HttpRequestMessage httpRequestMessage, int page, int pageSize)
        {
            return CreateHttpResponse(httpRequestMessage, () =>
            {
                int totalRow = 0;
                var productCategoryModel = _productCategoryService.GetAllProductCategory(page, pageSize, out totalRow);
                int totalPage = (int)Math.Ceiling((double)totalRow / pageSize);

                var productCategoryViewModel = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(productCategoryModel);
                var paginationSet = new PaginationSet<ProductCategoryViewModel>()
                {
                    Items = productCategoryViewModel,
                    MaxPage = maxPage,
                    Page = page,
                    TotalCount = totalRow,
                    TotalPages = totalPage,
                };

                var httpResponse = httpRequestMessage.CreateResponse(HttpStatusCode.OK, paginationSet);
                return httpResponse;
            });
        }
    }
}
