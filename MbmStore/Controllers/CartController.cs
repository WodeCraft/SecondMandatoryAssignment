using MbmStore.Infrastructure;
using MbmStore.Models;
using MbmStore.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace MbmStore.Controllers
{
    public class CartController : Controller
    {

        private Repository repository;


        public CartController()
        {
            repository = Repository.Instance;
        }

        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }

        public RedirectToRouteResult AddToCart(Cart cart, int productId, string productType, string returnUrl, int quantity)
        {
            // INFO Using the productId as a primary key only works as long as all products across all product types share the same ID range
            //      By adding a check for the types makes sure 2 products in the database can have the same id
            Product product = repository.Products.FirstOrDefault(p => p.ProductId == productId);// && p.GetType().ToString() == productType);

            if (product != null)
            {
                cart.AddItem(product, quantity);
            }

            return RedirectToAction("Index", new { controller = returnUrl.Substring(1) });
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int productId, string productType, string returnUrl)
        {
            Product product = repository.Products.FirstOrDefault(p => p.ProductId == productId);// && p.GetType().ToString() == productType);

            if (product != null)
            {
                cart.RemoveItem(product);
            }

            return RedirectToAction("Index", new { controller = returnUrl.Substring(1) });
        }

    }
}