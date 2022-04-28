using Entities;
using Fruitkhhaa.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph;
using Services.Abstract;

namespace Fruitkhhaa.Controllers
{
    public class CheckOutController : Controller
    {
        private readonly IOrganicManager _organicManager;
        private readonly IPhotoManager _photoManager;
        private readonly IProductManager _productManager;
        private readonly ICategoryManager _categoryManager;
        private readonly ICheckOutManager _checkOutManager;
        public CheckOutController(IOrganicManager organicManager, IPhotoManager photoManager, IProductManager productManager, ICategoryManager categoryManager, ICheckOutManager checkOutManager)
        {
            _organicManager = organicManager;
            _photoManager = photoManager;
            _productManager = productManager;
            _categoryManager = categoryManager;
            _checkOutManager = checkOutManager;
        }

        public IActionResult Index(int? id)
        {
            var products = _productManager.GetById(id.Value);
            HomeVM vm = new()
            {
                ProductSingle = products,
                Organic = _organicManager.GetById(12),
                Photos = _photoManager.GetAll(),
                Products = _productManager.GetAll(),
                Categories = _categoryManager.GetAll(),
                
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult Index(Check check)
        {
            _checkOutManager.Post(check);
            return RedirectToAction("Index");
        }


    }
}
