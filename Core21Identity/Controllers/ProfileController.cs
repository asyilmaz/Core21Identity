using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core21Identity.Data;
using Core21Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Stripe;

namespace Core21Identity.Controllers
{
    public class ProfileController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private ApplicationIdentityDbContext _dbContext;

        public ProfileController(UserManager<ApplicationUser> userManager, ApplicationIdentityDbContext dbContext)
        {
            _userManager = userManager;
            _dbContext = dbContext;
        }
        public async Task<IActionResult> Index()
        {
            ProfileViewModel model = new ProfileViewModel();

            ApplicationUser user = await _userManager.GetUserAsync(User);
            var roles = (await _userManager.GetRolesAsync(user)).ToArray();


            model.UserName = user.UserName;
            model.Email = user.Email;
            model.UserPlanStartDate = user.UserPlanStartDate;
            model.UserPlanExpireDate = user.UserPlanExpireDate;
            model.Roles = string.Join(",", roles);
            model.UserTypeId = user.UserTypeId;


            List<UserPlanType> userPlanTypes = _dbContext.UserPlanTypes.ToList();
            model.UserPlanTypes = userPlanTypes;

            return View(model);
        }

    }
}