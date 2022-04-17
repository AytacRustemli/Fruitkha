using Entities;
using Fruitkhhaa.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;

namespace Fruitkhhaa.Controllers
{
    public class ContactController : Controller
    {
        private readonly IOrganicManager _organicManager;
        private readonly IContactManager _contactManager;
        public ContactController(IOrganicManager organicManager, IContactManager contactManager)
        {
            _organicManager = organicManager;
            _contactManager = contactManager;
        }

        public IActionResult Index()
        {
            HomeVM vm = new()
            { 
                Organic = _organicManager.GetById(9),
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult Index(Contact contact)
        {
            _contactManager.Post(contact);
            return RedirectToAction("Index");
        }
    }
}
