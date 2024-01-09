//using Entities;
using Entities;
using Microsoft.AspNetCore.Mvc;
using WebApplicationDemo.Models;

namespace WebApplicationDemo.Controllers
{
    public class Exo5Controller : Controller
    {
        static List<Message> messages = [];
        [HttpGet]
        public IActionResult AddMessage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddMessage(Message message)
        {

            if (message.Emeteur == null)
            {
                TempData["EmetRequired"] = "Emetteur obligatoire";
            }
            else if (messages.Any(m => m.Emeteur == message.Emeteur))
            {
                TempData["UniqueError"] = "Emetteur doit être unique";
            }
            else if (message.Contenu.Length > 20)
            {
                TempData["LenghtMessage"] = "Contenu doit avoir 20 caractères max";
            }
            else
            {
                messages.Add(message);
                TempData["Added"] = "Message ajouté";
            }

            return View(message);
        }
    }
}
