﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core21Identity.Controllers
{
    [Authorize(Roles = "Free,Premium")]
    public class AAppsPubsPatsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}