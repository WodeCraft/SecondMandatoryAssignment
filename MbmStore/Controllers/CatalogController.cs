using MbmStore.Infrastructure;
using System.Web.Mvc;

namespace MbmStore.Controllers
{
    public class CatalogController : Controller
    {
        private Repository repo = Repository.Instance;

        // GET: Catalog
        public ActionResult Index()
        {
            return View(repo.Products);
        }
    }
}