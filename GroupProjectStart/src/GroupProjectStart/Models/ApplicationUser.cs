using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GroupProjectStart.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string DisplayName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Image { get; set; }
        public bool IsLoaner { get; set; }
        public bool HasDamageInsurance { get; set; }
        public bool HasLicense { get; set; }
        public ICollection<Car> CarsToLoan { get; set; }
        public bool HasTheftInsurance { get; set; }
    }
}
