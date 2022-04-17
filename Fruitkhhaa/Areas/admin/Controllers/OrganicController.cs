using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;

namespace Fruitkhhaa.Areas.admin.Controllers
{
    [Area("admin")]
    public class OrganicController : Controller
    {
        private readonly IOrganicManager _organicManager;

        public OrganicController(IOrganicManager organicManager)
        {
            _organicManager = organicManager;
        }

        // GET: OrganicController
        public IActionResult Index()
        {
            var organics = _organicManager.GetAll();
            return View(organics);
        }

        // GET: OrganicController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrganicController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OrganicController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Organic organic)
        {
            try
            {
                _organicManager.Create(organic);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrganicController/Edit/5
        public IActionResult Edit(int id)
        {
            var organic = _organicManager.GetById(id);
            return View(organic);
        }

        // POST: OrganicController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Organic organic)
        {
            try
            {
                _organicManager.Edit(organic);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrganicController/Delete/5
        public IActionResult Delete(int id)
        {
            var organic = _organicManager.GetById(id);
            return View(organic);
        }

        // POST: OrganicController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, Organic organic)
        {
            try
            {
                _organicManager.Delete(organic);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
