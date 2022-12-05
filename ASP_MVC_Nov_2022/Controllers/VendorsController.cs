using ASP_MVC_Nov_2022.Models;
using ASP_MVC_Nov_2022.Repos;
using ASP_MVC_Nov_2022.Repos.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP_MVC_Nov_2022.Controllers
{
    public class VendorsController : Controller
    {
        private readonly IVendorRepo _vendorRepo;
        // private readonly MockVendorRepo _vendorRepo = new MockVendorRepo();

        public VendorsController(IVendorRepo vendorRepo)
        {
            _vendorRepo = vendorRepo;
        }


        // GET: VendorsController
        public ActionResult<IEnumerable<Vendor>> Index()
        {
            return View(_vendorRepo.GetAll());
        }

        // GET: VendorsController/Details/5
        public ActionResult Details(int id)
        {
            return View(_vendorRepo.GetById(id));
        }

        // GET: VendorsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VendorsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Vendor collection)
        {
            try
            {
                _vendorRepo.Create(collection);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VendorsController/Edit/5
        public ActionResult Edit(int id)
        {
            var vendorToEdit = _vendorRepo.GetById(id);
            return View(vendorToEdit);
        }

        // POST: VendorsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Vendor collection)
        {
            try
            {
                _vendorRepo.Update(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VendorsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_vendorRepo.GetById(id));
        }

        // POST: VendorsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _vendorRepo.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
