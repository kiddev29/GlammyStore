using AutoMapper;
using System.Web.Mvc;
using GlammyStore.Model.Models;
using GlammyStore.Service;
using GlammyStore.Web.Models;

namespace GlammyStore.Web.Controllers
{
    public class PageController : Controller
    {
        private IPageService _pageService;

        public PageController(IPageService pageService)
        {
            _pageService = pageService;
        }

        // GET: Page
        public ActionResult Index(string alias)
        {
            var page = _pageService.GetByAlias(alias);
            var model = Mapper.Map<Page, PageViewModel>(page);
            return View(model);
        }
    }
}