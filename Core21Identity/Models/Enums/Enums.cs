using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core21Identity.Models.Enums
{
    public class Enums
    {
        public enum UserType
        {
            Free = 1,
            Premium = 2
        }

        public enum UserPlan
        {
            OneMonth = 1,
            ThreeMonth = 2,
            TwelveMonth = 3
        }
    }
}
