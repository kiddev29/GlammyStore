using System.Web.Mvc;

namespace GlammyStore.Web.Controllers
{
    public class PostController : Controller
    {
        // GET: Post
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult _RecentPosts()
        {
            return PartialView();
        }
    }
}