using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core21Identity.Models
{
    public class ApplicationUser: IdentityUser<string>
    {
        public int UserTypeId { get; set; }
        public DateTime? UserPlanStartDate { get; set; }
        public DateTime? UserPlanExpireDate { get; set; }
    }
}
