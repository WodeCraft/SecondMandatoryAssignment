using MbmStore.Infrastructure;
using MbmStore.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace MbmStore.Controllers
{
    public class CatalogueController : Controller
    {
        private Repository repo = Repository.Instance;
        public int PageSize = 4;

        // GET: Catalogue
        public ActionResult Index(int page = 1)
        {

            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = repo.Products
                .OrderBy(p => p.ProductId)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = repo.Products.Count()
                }
            };

            return View(model);
        }
    }
}