using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;

namespace Fruitkhhaa.Areas.admin.Controllers
{
    [Area("admin")]
    public class SaleController : Controller
    {
        private readonly ISaleManager _saleManager;

        public SaleController(ISaleManager saleManager)
        {
            _saleManager = saleManager;
        }

        // GET: SaleController
        public IActionResult Index()
        {
            var sale = _saleManager.GetAll();
            return View(sale);
        }

        // GET: SaleController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SaleController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SaleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Sale sale)
        {
            try
            {
                _saleManager.Create(sale);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SaleController/Edit/5
        public IActionResult Edit(int id)
        {
            var sale = _saleManager.GetById(id);
            return View(sale);
        }

        // POST: SaleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Sale sale)
        {
            try
            {
                _saleManager.Edit(sale);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SaleController/Delete/5
        public IActionResult Delete(int id)
        {
            var sale = _saleManager.GetById(id);
            return View(sale);
        }

        // POST: SaleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, Sale sale)
        {
            try
            {
                _saleManager.Delete(sale);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
