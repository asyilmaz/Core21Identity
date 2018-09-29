using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core21Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core21Identity.Controllers
{
    public class RegisterController : Controller
    {
        private UserManager<ApplicationUser> userManager;

        public RegisterController(UserManager<ApplicationUser> _userManager)
        {
            userManager = _userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = model.UserName;
                user.Email = model.Email;
                
                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    RedirectToAction("Success");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }

            return View(model);
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}