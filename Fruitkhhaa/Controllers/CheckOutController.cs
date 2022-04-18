using Fruitkhhaa.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;

namespace Fruitkhhaa.Controllers
{
    public class CheckOutController : Controller
    {
        private readonly IOrganicManager _organicManager;
        private readonly IPhotoManager _photoManager;
        public CheckOutController(IOrganicManager organicManager, IPhotoManager photoManager)
        {
            _organicManager = organicManager;
            _photoManager = photoManager;
        }

        public IActionResult Index()
        {
            HomeVM vm = new()
            {
                Organic = _organicManager.GetById(12),
                Photos = _photoManager.GetAll()
            };
            return View(vm);
        }
    }
}
