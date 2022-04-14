using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;

namespace Fruitkha.Areas.admin.Controllers
{
    [Area("admin")]

    public class DealController : Controller
    {
        private readonly IDealManager _dealServices;
        private readonly IWebHostEnvironment _environment;

        public DealController(IDealManager dealServices, IWebHostEnvironment environment)
        {
            _dealServices = dealServices;
            _environment = environment;
        }

        // GET: DealController
        public IActionResult Index()
        {
            var deal = _dealServices.GetAll();
            return View(deal);
        }


        // GET: DealController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DealController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Deal deal, IFormFile Image, string OldPhoto)
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
                    deal.PhotoURL = path;
                }
                else
                {
                    deal.PhotoURL = OldPhoto;
                }
                _dealServices.Create(deal);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DealController/Edit/5
        public IActionResult Edit(int id)
        {
            var deal = _dealServices.GetById(id);
            return View(deal);
        }

        // POST: DealController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Deal deal, IFormFile Image)
        {
            if (Image != null)
            {
                string path = "/files/" + Guid.NewGuid() + Image.FileName;
                using (var fileStream = new FileStream(_environment.WebRootPath + path, FileMode.Create))
                {
                    await Image.CopyToAsync(fileStream);
                }
                deal.PhotoURL = path;
            }
            try
            {
                _dealServices.Edit(deal);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DealController/Delete/5
        public IActionResult Delete(int id)
        {
            var deal = _dealServices.GetById(id);
            return View(deal);
        }

        // POST: DealController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, Deal deal)
        {
            try
            {
                _dealServices.Delete(deal);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
