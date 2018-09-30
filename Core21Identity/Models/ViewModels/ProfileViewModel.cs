using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core21Identity.Models
{
    public class ProfileViewModel
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string Roles { get; set; }

        public DateTime? UserPlanStartDate { get; set; }

        public DateTime? UserPlanExpireDate { get; set; }

        public int UserTypeId { get; set; }

        public List<UserPlanType> UserPlanTypes { get; set; }
    }
}
