using MbmStore.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MbmStore.Controllers
{
    public class NavController : Controller
    {
        Repository repo = Repository.Instance;

        // GET: Nav
        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;

            IEnumerable<string> categories = repo.Products
                .Select(p => p.Category)
                .Distinct()
                .OrderBy(p => p);

            return PartialView(categories);

        }
    }
}