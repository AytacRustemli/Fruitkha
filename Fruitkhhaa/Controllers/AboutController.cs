using Fruitkhhaa.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;

namespace Fruitkhhaa.Controllers
{
    public class AboutController : Controller
    {
        
        private readonly IOrganicManager _organicManager;
        private readonly IFreeManager _freeManager;
        private readonly ISaleManager _saleManager;
        private readonly INewManager _newManager;
        private readonly IOwnerManager _ownerManager;
        private readonly IPhotoManager _photoManager;

        public AboutController(IOrganicManager organicManager, IFreeManager freeManager, ISaleManager saleManager, INewManager newManager, IOwnerManager ownerManager, IPhotoManager photoManager)
        {
            _organicManager = organicManager;
            _freeManager = freeManager;
            _saleManager = saleManager;
            _newManager = newManager;
            _ownerManager = ownerManager;
            _photoManager = photoManager;
        }


        public IActionResult Index()
        {
            HomeVM vm = new()
            {
                Organic = _organicManager.GetById(5),
                Frees = _freeManager.GetFreeAll(),
                Sales = _saleManager.GetAll(),
                News = _newManager.GetNewAll(),
                Owners = _ownerManager.GetAll(),
                Photos = _photoManager.GetAll()
            };
            return View(vm);
        }
    }
}
