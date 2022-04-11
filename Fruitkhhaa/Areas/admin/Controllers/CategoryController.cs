using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;

namespace Fruitkhhaa.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly ICategoryManager _categoryManager;

        public CategoryController(ICategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
        }

        // GET: CategoryController
        public IActionResult Index()
        {
            var categories = _categoryManager.GetAll();
            return View(categories);
        }


        // GET: CategoryController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            try
            {
                _categoryManager.Create(category);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Edit/5
        public IActionResult Edit(int id)
        {
            var category = _categoryManager.GetById(id);
            return View(category);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Category category)
        {
            try
            {
                _categoryManager.Edit(category);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Delete/5
        public IActionResult Delete(int id)
        {
            var category = _categoryManager.GetById(id);
            return View(category);
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, Category category)
        {
            try
            {
                _categoryManager.Delete(category);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
