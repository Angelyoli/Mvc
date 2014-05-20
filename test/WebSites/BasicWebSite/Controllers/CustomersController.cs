using Microsoft.AspNet.Mvc;
using System.Linq;

namespace BasicWebSite
{
    public class CustomersController : Controller
    {
        public ActionResult Index()
        {
            return View(Enumerable.Range(1, 10).Select(i => new Customer { Id = i, Name = "Customer " + i }));
        }

        public ActionResult Details(int id)
        {
            return View(new Customer { Id = 1, Name = "asdf" });
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Customer newCustomer)
        {
            if (!ModelState.IsValid)
            {
                return View(newCustomer);
            }
            else
            {
                return RedirectToAction("Details", new { id = newCustomer.Id });
            }
        }

        public ActionResult Edit(int id)
        {
            return View(new Customer { Id = 1, Name = "asdf" });
        }

        [HttpPost]
        public ActionResult Edit(int id, Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return View(customer);
            }
            else
            {
                return RedirectToAction("Details", new { id = customer.Id });
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(new Customer { Id = 3, Name = "asdf" });
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            return RedirectToAction("Index");
        }
    }
}