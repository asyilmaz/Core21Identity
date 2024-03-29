﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core21Identity.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string UserName{ get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public int UserTypeId { get; set; }
        public int UserPlanDays { get; set; }
        public List<UserPlanType> UserPlanTypes { get; set; }
    }

}
