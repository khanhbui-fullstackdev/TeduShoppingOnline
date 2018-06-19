using AutoMapper;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TeduShopingOnline.Model.Models;
using TeduShopingOnline.Service.Interfaces;
using TeduShopingOnline.Web.Infrastructure.Cores;
using TeduShopingOnline.Web.Infrastructure.Extensions;
using TeduShopingOnline.Web.ViewModels;

namespace TeduShopingOnline.Web.ApiControllers
{
    [RoutePrefix("api/postcategory")]
    public class PostCategoryController : ApiControllerBase
    {
        IPostCategoryService _postCategoryService;
        IErrorService _errorService;

        public PostCategoryController(IErrorService errorService, IPostCategoryService postCategoryService) : base(errorService)
        {
            this._postCategoryService = postCategoryService;
            this._errorService = errorService;
        }

        [Route("create")]
        public HttpResponseMessage Create(HttpRequestMessage request, PostCategoryViewModel postCategoryViewModel)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadGateway, ModelState);
                }
                else
                {
                    PostCategory postCategoryModel = new PostCategory();
                    postCategoryModel.UpdatePostCategory(postCategoryViewModel);

                    var newPostCategory = _postCategoryService.AddPostCategory(postCategoryModel);
                    _postCategoryService.SavePostCategory();
                    response = request.CreateResponse(HttpStatusCode.Created, newPostCategory);
                }
                return response;
            });
        }

        [Route("update")]
        public HttpResponseMessage Update(HttpRequestMessage request, PostCategoryViewModel postCategoryViewModel)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadGateway, ModelState);
                }
                else
                {
                    var postCategoryModel = _postCategoryService.GetPostCategoryById(postCategoryViewModel.Id);
                    postCategoryModel.UpdatePostCategory(postCategoryViewModel);

                    _postCategoryService.UpdatePostCategory(postCategoryModel);
                    _postCategoryService.SavePostCategory();
                    response = request.CreateResponse(HttpStatusCode.OK, postCategoryModel);
                }
                return response;
            });
        }

        [Route("delete")]
        public HttpResponseMessage Delete(HttpRequestMessage request, int postCategoryId)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadGateway, ModelState);
                }
                else
                {
                    _postCategoryService.DeletePostCategory(postCategoryId);
                    _postCategoryService.SavePostCategory();
                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                return response;
            });
        }

        [Route("getall")]
        public HttpResponseMessage GetAllPostCategory(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var categories = _postCategoryService.GetAllPostCategory();
                var categoriesViewModel = Mapper.Map<List<PostCategoryViewModel>>(categories);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK);
                return response;
            });
        }
    }
}
