using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using WebApplicationDemo.Models;

namespace WebApplicationDemo.Controllers
{
    public class Exo2Controller : Controller
    {
        static List<Message> messages = new()
        {
            new Message()
            {
                Id= 1,
                Contenu = "Contenu 1",
                Date = "01/01/2000",
                Emeteur="Emet 1"
            },new Message()
            {
                Id= 2,
                Contenu = "Contenu 2",
                Date = "02/02/2010",
                Emeteur="Emet 2"
            },new Message()
            {
                Id= 3,
                Contenu = "Contenu 3",
                Date = "03/03/2020",
                Emeteur="Emet 3"
            },
         };

        //Get
        [HttpGet]
        public IActionResult GetMessages()
        {
            return View(messages);
        }
        [HttpGet]
        public IActionResult GetMessage(int id)
        {
            var mess = messages.FirstOrDefault(m => m.Id == id);
            return View(mess);
        }


        //Add
        [HttpGet]
        public IActionResult AddMessage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddMessage(Message message)
        {
            message.Id = messages.Count + 1;


            messages.Add(message);

            return RedirectToAction("GetMessage", new { Id = message.Id });
        }

        //Delete
        [HttpGet]
        public IActionResult DeleteMessage(int messId)
        {
            messages.Remove(messages.FirstOrDefault(m => m.Id == messId));

            TempData["info"] = "Message supprimé";
            return RedirectToAction("GetMessages");
        }

        //Update
        [HttpGet]
        public IActionResult EditMessage(int messId)
        {
            Message mess = messages.FirstOrDefault(m => m.Id == messId);
            return View(mess);

        }

        [HttpPost]
        public IActionResult EditMessage(int id, string contenu)
        {
            TempData["info"] = "Message modifié";

            Message mess = messages.FirstOrDefault(m => m.Id == id);
            mess.Contenu = contenu;

            return RedirectToAction("GetMessage", new { Id = id });
        }


    }
}
