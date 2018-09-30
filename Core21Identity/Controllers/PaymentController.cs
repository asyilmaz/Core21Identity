using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core21Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Stripe;

namespace Core21Identity.Controllers
{
    public class PaymentController : Controller
    {
        private UserManager<ApplicationUser> _userManager;

        public PaymentController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Charge(string stripeEmail, string stripeToken, string stripeAmount, string days)
        {
            var customers = new StripeCustomerService();
            var charges = new StripeChargeService();

            //You can get an existing customer. 

            //Assume that customer doesn't exist.
            var customer = customers.Create(new StripeCustomerCreateOptions
            {
                Email = stripeEmail,
                SourceToken = stripeToken
            });
            try
            {
                var charge = charges.Create(new StripeChargeCreateOptions
                {
                    Amount = Convert.ToInt32(stripeAmount),
                    Description = "Sample Charge",
                    Currency = "usd",
                    CustomerId = customer.Id
                });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new { message = ex.Message});
            }

            //If charge is successfull
            ApplicationUser user = await _userManager.GetUserAsync(User);

            DateTime now = DateTime.Now.Date;

            user.UserPlanStartDate = now;
            user.UserPlanExpireDate = now.AddDays(Convert.ToInt32(days));
            user.UserTypeId = 2; //For Premium

            await _userManager.UpdateAsync(user);
            await _userManager.AddToRoleAsync(user, "Premium");
            await _userManager.RemoveFromRoleAsync(user, "Free");

            return View();
        }

        public IActionResult Error(string message)
        {
            ViewBag.Message = message;
            return View();
        }
    }
}