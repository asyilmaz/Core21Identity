using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core21Identity.Models.ViewModels
{
    public class ProfileViewModel
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string UserPlanStartDate { get; set; }

        public string UserPlanExpireDate { get; set; }
    }
}
