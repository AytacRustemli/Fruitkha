using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;

namespace Fruitkha.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize]
    public class NewController : Controller
    {
        private readonly INewManager _newManager;
        private readonly IWebHostEnvironment _environment;
        private readonly UserManager<User> _userManager;

        public NewController(INewManager newManager, IWebHostEnvironment environment, UserManager<User> userManager)
        {
            _newManager = newManager;
            _environment = environment;
            _userManager = userManager;
        }

        // GET: NewController
        public IActionResult Index()
        {
           var news = _newManager.GetAll();
            return View(news);
        }

        // GET: NewController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: NewController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NewController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(New news,IFormFile Image)
        {

            string path = "/files/" + Guid.NewGuid() + Image.FileName;
            using (var fileStream = new FileStream(_environment.WebRootPath + path, FileMode.Create))
            {
                await Image.CopyToAsync(fileStream);
            }
            try
            {
                var userId = _userManager.GetUserId(HttpContext.User);
                news.PhotoURL = path;
                news.UserId = userId;
                _newManager.Create(news);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: NewController/Edit/5
        public IActionResult Edit(int id)
        {
            var news = _newManager.GetById(id);
            return View(news);
        }

        // POST: NewController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,New news,IFormFile Image)
        {
            string path = "/files/" + Guid.NewGuid() + Image.FileName;
            using (var fileStream = new FileStream(_environment.WebRootPath + path, FileMode.Create))
            {
                await Image.CopyToAsync(fileStream);
            }
            try
            {
                news.PhotoURL = path;
                _newManager.Edit(news);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: NewController/Delete/5
        public IActionResult Delete(int id)
        {
            var news = _newManager.GetById(id);
            return View(news);
        }

        // POST: NewController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, New news)
        {
            try
            {
                _newManager.Delete(news);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
