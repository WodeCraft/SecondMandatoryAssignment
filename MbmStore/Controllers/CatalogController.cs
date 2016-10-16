using MbmStore.Infrastructure;
using System.Web.Mvc;

namespace MbmStore.Controllers
{
    public class CatalogController : Controller
    {
        private Repository repo = new Repository();

        // GET: Catalog
        public ActionResult Index()
        {
            return View(repo.Products);
        }
    }
}