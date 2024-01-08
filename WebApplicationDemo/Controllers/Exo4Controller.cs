using Microsoft.AspNetCore.Mvc;

namespace WebApplicationDemo.Controllers
{
    public class Exo4Controller : Controller
    {
        public IActionResult GetRandom()
        {
            return View();
        }
    }
}
