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

        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = GetCart(),
                ReturnUrl = returnUrl
            });
        }

        public RedirectToRouteResult AddToCart(int productId, string productType, string returnUrl)
        {
            // INFO Using the productId as a primary key only works as long as all products across all product types share the same ID range
            //      By adding a check for the types makes sure 2 products in the database can have the same id
            Product product = repository.Products.FirstOrDefault(p => p.ProductId == productId);// && p.GetType().ToString() == productType);

            if (product != null)
            {
                GetCart().AddItem(product, 1);
            }

            return RedirectToAction("Index", new { returnUrl = returnUrl.Substring(1) });
        }

        public RedirectToRouteResult RemoveFromCart(int productId, string productType, string returnUrl)
        {
            Product product = repository.Products.FirstOrDefault(p => p.ProductId == productId);// && p.GetType().ToString() == productType);

            if (product != null)
            {
                GetCart().RemoveItem(product);
            }

            return RedirectToAction("Index", new { returnUrl = returnUrl.Substring(1) });
        }

        private Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];

            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }

            return cart;
        }

    }
}