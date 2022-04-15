using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;

namespace Fruitkhhaa.Areas.admin.Controllers
{
    [Area("admin")]
    public class OwnerController : Controller
    {
        private readonly IOwnerManager _ownerManager;
        private readonly IWebHostEnvironment _environment;

        public OwnerController(IOwnerManager ownerManager, IWebHostEnvironment environment)
        {
            _ownerManager = ownerManager;
            _environment = environment;
        }

        // GET: OwnerController
        public IActionResult Index()
        {
            var owner = _ownerManager.GetAll();
            return View(owner);
        }

        // GET: OwnerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OwnerController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OwnerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Owner owner, IFormFile Image, string OldPhoto)
        {
            try
            {
                if (Image != null)
                {
                    string path = "/files/" + Guid.NewGuid() + Image.FileName;
                    using (var fileStream = new FileStream(_environment.WebRootPath + path, FileMode.Create))
                    {
                        await Image.CopyToAsync(fileStream);
                    }
                    owner.PhotoURL = path;
                }
                else
                {
                    owner.PhotoURL = OldPhoto;
                }
                _ownerManager.Create(owner);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OwnerController/Edit/5
        public IActionResult Edit(int id)
        {
            var owner = _ownerManager.GetById(id);
            return View(owner);
        }

        // POST: OwnerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Owner owner, IFormFile Image)
        {
            if (Image != null)
            {
                string path = "/files/" + Guid.NewGuid() + Image.FileName;
                using (var fileStream = new FileStream(_environment.WebRootPath + path, FileMode.Create))
                {
                    await Image.CopyToAsync(fileStream);
                }
                owner.PhotoURL = path;
            }
            try
            {
                _ownerManager.Edit(owner);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OwnerController/Delete/5
        public IActionResult Delete(int id)
        {
            var owner = _ownerManager.GetById(id);
            return View(owner);
        }

        // POST: OwnerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, Owner owner)
        {
            try
            {
                _ownerManager.Delete(owner);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
