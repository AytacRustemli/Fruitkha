using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;

namespace Fruitkhhaa.Areas.admin.Controllers
{
    [Area("admin")]
    public class SinceController : Controller
    {
        private readonly ISinceManager _sinceManager;

        public SinceController(ISinceManager sinceManager)
        {
            _sinceManager = sinceManager;
        }

        // GET: SinceController
        public IActionResult Index()
        {
            var since = _sinceManager.GetAll();
            return View(since);
        }

        // GET: SinceController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SinceController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SinceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Since since)
        {
            try
            {
                _sinceManager.Create(since);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SinceController/Edit/5
        public IActionResult Edit(int id)
        {
            var since = _sinceManager.GetById(id);
            return View(since);
        }

        // POST: SinceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Since since)
        {
            try
            {
                _sinceManager.Edit(since);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SinceController/Delete/5
        public IActionResult Delete(int id)
        {
            var since = _sinceManager.GetById(id);
            return View(since);
        }

        // POST: SinceController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, Since since)
        {
            try
            {
                _sinceManager.Delete(since);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
