using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProjectStart.Models
{
    public class Renter : ApplicationUser
    {
        public bool HasDamageInsurance { get; set; }
        public bool HasLicense { get; set; }

    }
}
