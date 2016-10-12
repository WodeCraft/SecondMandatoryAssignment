using System.Web.Mvc;

namespace MbmStore.Controllers
{
    public class HomeController : Controller
    {
        // GET: Index
        public ActionResult Index()
        {
            // Only used for showing the default page with navigation
            return View();
        }
    }
}