using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core21Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core21Identity.Controllers
{
    public class AdminController : Controller
    {
        private RoleManager<ApplicationRole> _roleManager;

        public AdminController(RoleManager<ApplicationRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            AdminViewModel adminViewModel = new AdminViewModel();
            adminViewModel.Roles = _roleManager.Roles;
            return View(adminViewModel);
        }
        public async Task<IActionResult> CreateRoles()
        {
            await _roleManager.CreateAsync(new ApplicationRole() { Name = "Free" });
            await _roleManager.CreateAsync(new ApplicationRole() { Name = "Premium" });
            return RedirectToAction("Index");
        }
    }
}