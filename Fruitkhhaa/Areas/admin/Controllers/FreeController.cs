using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;

namespace Fruitkha.Areas.admin.Controllers
{
    [Area("admin")]

    public class FreeController : Controller
    {
        private readonly IFreeManager _freeservices;

        public FreeController(IFreeManager freeservices)
        {
            _freeservices = freeservices;
        }

        // GET: FreeController
        public IActionResult Index()
        {
            var free = _freeservices.GetFreeAll();
            return View(free);
        }

        // GET: FreeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FreeController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FreeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Free free)
        {
            try
            {
                _freeservices.Create(free);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FreeController/Edit/5
        public IActionResult Edit(int id)
        {
            var free = _freeservices.GetById(id);
            return View(free);
        }

        // POST: FreeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Free free)
        {
            try
            {
                _freeservices.Edit(free);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FreeController/Delete/5
        public IActionResult Delete(int id)
        {
            var free = _freeservices.GetById(id);
            return View(free);
        }

        // POST: FreeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, Free free)
        {
            try
            {
                _freeservices.Delete(free);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}