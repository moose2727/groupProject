using GroupProjectStart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProjectStart.ViewModels
{
    public class UserVM
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Image { get; set; }
        public bool IsLoaner { get; set; }
        public bool IsAdmin { get; set; }
        public bool HasDamageInsurance { get; set; }
        public ICollection<Car> CarsToLoan { get; set; }
        public bool HasLicense { get; set; }
        public bool HasTheftInsurance { get; set; }
        public ICollection<RatingDriver> DriverRatings { get; set; }
        public decimal AverageRating { get; set; }
        public ICollection<DriverReview> Reviews { get; set; }
        public virtual string UserName { get; set; }
        public virtual string Email { get; set; }
    }
}
