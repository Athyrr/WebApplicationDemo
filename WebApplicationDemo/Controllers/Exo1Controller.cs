using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Text.Json;
using WebApplicationDemo.Models;

namespace WebApplicationDemo.Controllers
{
    public class Exo1Controller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        //public string ApiTest()
        //{
        //    var mess = new Message() { Contenu = "aaaa" };
        //    return JsonSerializer.Serialize(mess);
        //}
        
        public IActionResult TestData()
        {
            TempData["TestKey"] = "Valeur du testKey";
            ViewBag.TestKey = "Valeur du ViewBag";
            return View();
        }

        public IActionResult TestData2()
        {
            TempData["TestKey"] = "Valeur du testKey 2";
            ViewBag.TestKey = "Valeur du ViewBag 2";
            return RedirectToAction("TestData");
        }

        public IActionResult TestData3()
        {
            TempData["TestKey"] = "Valeur du testKey 3";
            ViewBag.TestKey = "Valeur du ViewBag 3";
            return RedirectToAction("TestData2");
        }

        public IActionResult TestData4()
        {
            TempData["TestKey"] = "Valeur du testKey 4";
            ViewBag.TestKey = "Valeur du ViewBag 4";
            return View("TestData");
        }

    }
}
