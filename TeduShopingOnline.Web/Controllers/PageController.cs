using AutoMapper;
using System.Web.Mvc;
using TeduShopingOnline.Model.Models;
using TeduShopingOnline.Service.Interfaces;
using TeduShopingOnline.Web.ViewModels;

namespace TeduShopingOnline.Web.Controllers
{
    public class PageController : Controller
    {
        private IPageService _pageService;

        public PageController(IPageService pageService)
        {
            this._pageService = pageService;
        }

        // GET: Page
        public ActionResult Index(string alias)
        {
            var pageModel = _pageService.GetPageByAlias(alias);
            var pageViewModel = Mapper.Map<Page, PageViewModel>(pageModel);
            return View(pageViewModel);
        }
    }
}