﻿using Microsoft.AspNetCore.Mvc;

namespace WebApplicationDemo.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Error404()
        {
            return View();
        }
    }
}
