using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;

namespace Fruitkhhaa.Areas.admin.Controllers
{
    [Area("admin")]
    public class PhotoController : Controller
    {
        private readonly IPhotoManager _photoManager;
        private readonly IWebHostEnvironment _environment;

        public PhotoController(IPhotoManager photoManager, IWebHostEnvironment environment)
        {
            _photoManager = photoManager;
            _environment = environment;
        }

        // GET: PhotoController
        public IActionResult Index()
        {
            var photo = _photoManager.GetAll();
            return View(photo);
        }

        // GET: PhotoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PhotoController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PhotoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Photo photo, IFormFile Image, string OldPhoto)
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
                    photo.PhotoURL = path;
                }
                else
                {
                    photo.PhotoURL = OldPhoto;
                }
                _photoManager.Create(photo);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PhotoController/Edit/5
        public IActionResult Edit(int id)
        {
            var photo = _photoManager.GetById(id);
            return View(photo);
        }

        // POST: PhotoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Photo photo, IFormFile Image)
        {
            if (Image != null)
            {
                string path = "/files/" + Guid.NewGuid() + Image.FileName;
                using (var fileStream = new FileStream(_environment.WebRootPath + path, FileMode.Create))
                {
                    await Image.CopyToAsync(fileStream);
                }
                photo.PhotoURL = path;
            }
            try
            {
                _photoManager.Edit(photo);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PhotoController/Delete/5
        public IActionResult Delete(int id)
        {
            var photo = _photoManager.GetById(id);
            return View(photo);
        }

        // POST: PhotoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, Photo photo)
        {
            try
            {
                _photoManager.Delete(photo);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
