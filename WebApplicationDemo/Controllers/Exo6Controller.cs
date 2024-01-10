using Business;
using Business.Contracts;
using Entities;
using Microsoft.AspNetCore.Mvc;
using WebApplicationDemo.Models;

namespace WebApplicationDemo.Controllers
{
    public class Exo6Controller : Controller
    {
        public IMessageBusiness messageBusiness;

        public Exo6Controller(IMessageBusiness messageBusiness)
        {
            this.messageBusiness = messageBusiness;
        }


        [HttpGet]
        public async Task<IActionResult> GetMessages()
        {
            return View(await messageBusiness.GetMessagesAsync());
        }

        [HttpGet]
        public async Task<IActionResult> GetMessage(int id)
        {
            var mess = await messageBusiness.GetMessageAsync(id);
            return View(mess);
        }

        [HttpGet]
        public async Task<IActionResult> AddMessage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddMessage(Message message)
        {
            await messageBusiness.AddMessageAsync(message);
            return RedirectToAction("GetMessage", new { Id = message.Id });
        }

        //Delete
        [HttpGet]
        public async Task<IActionResult> DeleteMessage(int id)
        {
            await messageBusiness.DeleteMessageAsync(id);

            TempData["info"] = "Message supprimé";
            return RedirectToAction("GetMessages");
        }

        //Update
        [HttpGet]
        public async Task<IActionResult> EditMessage(int id)
        {
            Message mess = await messageBusiness.GetMessageAsync(id);
            return View(mess);

        }

        [HttpPost]
        public async Task<IActionResult> EditMessage(int id, string contenu)
        {

            Message mess = await messageBusiness.GetMessageAsync(id);
            mess.Contenu = contenu;

            TempData["info"] = "Message modifié";

            return RedirectToAction("GetMessage", new { Id = id });
        }


    }
}
