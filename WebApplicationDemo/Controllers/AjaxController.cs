using Business.Contracts;
using Entities;
using Microsoft.AspNetCore.Mvc;
using WebApplicationDemo.Models;

namespace WebApplicationDemo.Controllers
{


    public class AjaxController : Controller
    {
        public IMessageBusiness messageBusiness;

        public AjaxController(IMessageBusiness messageBusiness)
        {
            this.messageBusiness = messageBusiness;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> GetPerson(string name)
        {

            return Json(new { Name = name });
        }
        public async Task<IActionResult> GetRandomVC(int min, int max)
        {
            return ViewComponent("Random", new { min, max });
        }

        [HttpPost]
        public async Task<IActionResult> Search(string name)
        {
            var messages = await messageBusiness.GetMessagesAsync();

            var filteredMessages = messages.Where(m => m.Emeteur == name).ToList();
            

            //Mieux de creer un  VC qui organise l'affichage des messages
            //Là ça ne marchera pas
            //return Json si Api donc pas de vue
            return View("GetMessages",filteredMessages);

        }


    }
}
