﻿using Microsoft.AspNetCore.Mvc;

namespace Stelina.WebUI.Areas.Admin.Controllers
{
    public class ChatController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
