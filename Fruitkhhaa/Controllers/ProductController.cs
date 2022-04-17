using Fruitkhhaa.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;

namespace Fruitkhhaa.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductManager _productManager;
        private readonly ICategoryManager _categoryManager;
        private readonly IPhotoManager _photoManager;
        private readonly IOrganicManager _organicManager;

        public ProductController(IProductManager productManager, ICategoryManager categoryManager, IPhotoManager photoManager, IOrganicManager organicManager)
        {
            _productManager = productManager;
            _categoryManager = categoryManager;
            _photoManager = photoManager;
            _organicManager = organicManager;
        }

        public IActionResult Index(int? id)
        {
            var products = _productManager.GetById(id.Value);
            ProductVM vm = new()
            {
                ProductSingle = products,
                Categories = _categoryManager.GetAll(),
                Products = _productManager.GetAll(),
                Photos = _photoManager.GetAll(),
                Organic = _organicManager.GetById(8)
            };
            return View(vm);
        }
    }
}
