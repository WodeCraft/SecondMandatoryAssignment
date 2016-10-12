using MbmStore.Infrastructure;
using MbmStore.Models;
using System.Linq;
using System.Web.Mvc;

namespace MbmStore.Controllers
{
    public class CatalogController : Controller
    {
        private Repository repo = new Repository();

        // GET: Catalog
        public ActionResult Index()
        {

            // Fills the ViewBag with data from the repository
            ViewBag.Books = repo.Products.OfType<Book>().ToList();
            ViewBag.CDs = repo.Products.OfType<MusicCD>().ToList();
            ViewBag.Movies = repo.Products.OfType<Movie>().ToList();

            return View();
        }
    }
}