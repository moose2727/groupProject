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
        public int UserId { get; set; }
        //public Loaner Loaner { get; set; }
        public bool IsActive { get; set; }
        public ICollection<RatingCar> CarRatings { get; set; }



    }
}
//id, make, model, year, price, image, doors