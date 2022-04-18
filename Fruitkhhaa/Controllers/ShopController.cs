using Core.Helper;
using Fruitkhhaa.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;

namespace Fruitkhhaa.Controllers
{
    public class ShopController : Controller
    {
        private readonly IOrganicManager _organicManager;
        private readonly IProductManager _productManager;
        private readonly ICategoryManager _categoryManager;
        private readonly IPhotoManager _photoManager;
        public ShopController(IOrganicManager organicManager, IProductManager productManager, ICategoryManager categoryManager, IPhotoManager photoManager)
        {
            _organicManager = organicManager;
            _productManager = productManager;
            _categoryManager = categoryManager;
            _photoManager = photoManager;
        }


        public IActionResult Index(int? recordSize = 6, int? pageNo = 1)
        {
            HomeVM vm = new()
            {
                Organic = _organicManager.GetById(11),
                Categories = _categoryManager.GetAll(),
                Photos = _photoManager.GetAll(),
                Products = _productManager.GetAll(pageNo, recordSize.Value),
            };
            vm.Pager = new Pager(_productManager.GetAllCount(), pageNo, 2, 3);
            return View(vm);
        }
    }
}
