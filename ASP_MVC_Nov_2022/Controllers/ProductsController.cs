using ASP_MVC_Nov_2022.Models;
using ASP_MVC_Nov_2022.Repos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASP_MVC_Nov_2022.Controllers
{
    public class ProductsController : Controller
    {
        private readonly MockProductRepo _productRepo = new MockProductRepo();
        private readonly MockVendorRepo _vendorRepo = new MockVendorRepo();

        // GET: ProductsController
        public ActionResult Index()
        {
            return View(_productRepo.GetAll());
        }

        public IEnumerable<string> GetProductsByVendorId(int id)
        {
            var res = _productRepo.GetAll()
                .Where(p => p.V_code == id)
                .Select(p => $"{p.P_descript}\t${p.P_Price} <br>");
            if (res == null || res.Count() == 0)
            {
                return new List<string> { "No Product found" };
            }

            return res;
        }


        // GET: ProductsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductsController/Create
        public ActionResult Create()
        {
            ViewBag.Vendors = new SelectList(_vendorRepo.GetAll(), "V_code", "V_name");
            return View();
        }

        // POST: ProductsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product collection)
        {
            try
            {
                _productRepo.Create(collection);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
