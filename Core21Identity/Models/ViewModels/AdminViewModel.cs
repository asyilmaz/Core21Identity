using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core21Identity.Models
{
    public class AdminViewModel
    {
        public IEnumerable<ApplicationRole> Roles { get; set; }
    }
}
