using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TeduShopingOnline.Model.Models;
using TeduShopingOnline.Service.Interfaces;
using TeduShopingOnline.Web.Infrastructure.Cores;
using TeduShopingOnline.Web.ViewModels;

namespace TeduShopingOnline.Web.ApiControllers
{
    [RoutePrefix("api/product-category")]
    public class ProductCategoryController : ApiControllerBase
    {
        IProductCategoryService _productCategoryService;

        public ProductCategoryController(
            IErrorService errorService,
            IProductCategoryService productCategoryService) : base(errorService)
        {
            this._productCategoryService = productCategoryService;
        }

        [Route("get-all-product-category")]
        public HttpResponseMessage GetAllProductCategory(HttpRequestMessage httpRequestMessage)
        {
            return CreateHttpResponse(httpRequestMessage, () =>
            {
                var productCategoryModel = _productCategoryService.GetAllProductCategory();
                var productCategoryViewModel = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(productCategoryModel);
                var httpResponse = httpRequestMessage.CreateResponse(HttpStatusCode.OK, productCategoryModel);
                return httpResponse;
            });
        }
    }
}
