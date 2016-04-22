using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProjectStart.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public int Door { get; set; }
        public string UserId { get; set; }
        //public ApplicationUser Loaner { get; set; } <----Jason------Don't do this stupid!--------from Jason
        public bool IsActive { get; set; }
        public string Condition { get; set; }
        public int Seats { get; set; }
        public int Miles { get; set; }
        public int HwyMpg { get; set; }
        public int CtyMpg { get; set; }
        public DateTime DateAdded { get; set; }
        public string Transmission { get; set; }
        public string Description { get; set; }
        public ICollection<RatingCar> CarRatings { get; set; }
        public decimal AverageRating { get; set; }


    }
}
//id, make, model, year, price, image, doors