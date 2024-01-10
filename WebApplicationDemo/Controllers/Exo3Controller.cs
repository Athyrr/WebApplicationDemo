//using Entities;
using Entities;
using Microsoft.AspNetCore.Mvc;
using WebApplicationDemo.Models;

namespace WebApplicationDemo.Controllers
{
    public class Exo3Controller : Controller
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

        [HttpGet]
        public IActionResult GetMessagePV(int id)
        {
            var mess = messages.FirstOrDefault(m=>m.Id==id);
            return View(mess);
        }

        [HttpGet]
        public IActionResult GetMessageListPV()
        {
            return View(messages);
        }

        [HttpGet]  
        public IActionResult GetListInt()
        {
            return View();
        }


    }
}
