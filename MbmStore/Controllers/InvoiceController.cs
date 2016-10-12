using MbmStore.Infrastructure;
using MbmStore.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MbmStore.Controllers
{
    public class InvoiceController : Controller
    {
        // Instantiate the repository
        private Repository repo = new Repository();
        List<SelectListItem> customers = new List<SelectListItem>();

        // GET: Invoice
        public ActionResult Index()
        {
            customers.Clear();
            customers.Add(new SelectListItem { Text = "All", Value = "-1" });
            foreach (Invoice invoice in repo.Invoices)
            {
                customers.Add(new SelectListItem { Text = invoice.Customer.Name, Value = invoice.Customer.CustomerId.ToString() });
            }

            customers = customers.GroupBy(x => x.Value).Select(y => y.First()).OrderBy(z => z.Text).ToList<SelectListItem>();

            // Add all invoices to the ViewBag
            //ViewBag.Invoices = repo.Invoices;
            ViewBag.CustomerId = customers;

            return View();
        }

        [HttpPost]
        public ActionResult Index(int? customerId)
        {
            customers.Clear();
            customers.Add(new SelectListItem { Text = "All", Value = "-1", Selected = customerId == -1 ? true : false });
            foreach (Invoice invoice in repo.Invoices)
            {
                if (customerId == invoice.Customer.CustomerId)
                {
                    customers.Add(new SelectListItem { Text = invoice.Customer.Name, Value = invoice.Customer.CustomerId.ToString(), Selected = true });
                }
                else
                {
                    customers.Add(new SelectListItem { Text = invoice.Customer.Name, Value = invoice.Customer.CustomerId.ToString() });
                }
            }
            customers = customers.GroupBy(x => x.Value).Select(y => y.First()).OrderBy(z => z.Text).ToList<SelectListItem>();

            List<Invoice> invoices = new List<Invoice>();
            if (customerId != null)
            {
                if (customerId == -1)
                {
                    invoices = repo.Invoices.ToList<Invoice>();
                }
                else
                {
                    invoices = repo.Invoices.Where(i => i.Customer.CustomerId == customerId).ToList<Invoice>();
                }
            }

            ViewBag.Invoices = invoices;
            ViewBag.CustomerId = customers;

            return View();
        }
    }
}