using Fruitkhhaa.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;

namespace Fruitkhhaa.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductManager _productManager;
        private readonly ICategoryManager _categoryManager;

        public ProductController(IProductManager productManager, ICategoryManager categoryManager)
        {
            _productManager = productManager;
            _categoryManager = categoryManager;
        }

        public IActionResult Index(int? id)
        {
            var products = _productManager.GetById(id.Value);
            ProductVM vm = new()
            {
                ProductSingle = products,
                
                Categories = _categoryManager.GetAll(),
                Products = _productManager.GetAll()
            };
            return View(vm);
        }
    }
}
