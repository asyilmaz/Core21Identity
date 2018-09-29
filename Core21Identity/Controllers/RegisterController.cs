using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core21Identity.Data;
using Core21Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core21Identity.Controllers
{
    public class RegisterController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<ApplicationRole> _roleManager;

        private ApplicationIdentityDbContext _dbContext;
        public RegisterController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, ApplicationIdentityDbContext dbContext)
        {
            _userManager = userManager;
            _dbContext = dbContext;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            List<UserPlanType> userPlanTypes = _dbContext.UserPlanTypes.ToList();
            RegisterViewModel model = new RegisterViewModel()
            {
                UserPlanTypes = userPlanTypes
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                string roleName = string.Empty;

                ApplicationUser user = new ApplicationUser();
                user.UserName = model.UserName;
                user.Email = model.Email;
                user.UserTypeId = model.UserTypeId;

                //1 = Free 
                if (model.UserTypeId == 1)
                {
                    user.UserPlanStartDate = null;
                    user.UserPlanExpireDate = null;
                    roleName = "Free";
                }
                //2 = Premium
                else if (model.UserTypeId == 2)
                {
                    DateTime now = DateTime.Now.Date;

                    user.UserPlanStartDate = now;
                    user.UserPlanExpireDate = now.AddDays(model.UserPlanDays);
                    
                    roleName = "Premium";
                }

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, roleName);
                    return RedirectToAction("Success");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            List<UserPlanType> userPlanTypes = _dbContext.UserPlanTypes.ToList();
            model.UserPlanTypes = userPlanTypes;
            return View(model);
        }

        public IActionResult Success()
        {
            return View();
        }

        public IActionResult Upgrade()
        {
            return View();
        }
    }
}