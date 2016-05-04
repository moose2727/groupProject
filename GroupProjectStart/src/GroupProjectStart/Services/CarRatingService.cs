using CoderCamps;
using GroupProjectStart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;

namespace GroupProjectStart.Services
{
    public class CarRatingService : ICarRatingService
    {
        IGenericRepository _repo;

        public CarRatingService(IGenericRepository repo)
        {
            this._repo = repo;
        }

        public List<RatingCar> GetCarRatings()
        {
            var carRatings = _repo.Query<RatingCar>().ToList();
            return carRatings;
        }

        public RatingCar GetCarRating(int id)
        {
            var carRating = _repo.Query<RatingCar>().Where(c => c.Id == id).FirstOrDefault();
            return carRating;
        }

        public decimal AddCarRating(int Id, RatingCar carRating)
        {
            //_repo.Add(carRating);
            //_repo.SaveChanges();
            var car = _repo.Query<Car>().Where(c => c.Id == Id).Include(c => c.CarRatings).FirstOrDefault();
            car.CarRatings.Add(carRating);
            _repo.SaveChanges();
            //var total = ((carRating.IndoorAirQuality) + (carRating.InsideCleanliness) + (carRating.OutsideCleanliness) + (carRating.ProfessionalismOfOwner) + (carRating.SafetyFeatures) + (carRating.TireQuality) + (carRating.ElectricalFunctions) + (carRating.EngineOperation) + (carRating.DeliveryExperience)) / 9;
            //carRating.OverallRating = total;

            //car.AverageRating = (car.AverageRating * car.CarRatings.Count + total) / car.CarRatings.Count;
            this.CalculateCarRating(car, carRating);
            _repo.SaveChanges();

            return car.AverageRating;
        }


        public decimal CalculateCarRating(Car car, RatingCar carRating)
        {
            var total = ((carRating.IndoorAirQuality) + (carRating.InsideCleanliness) + (carRating.OutsideCleanliness) + (carRating.ProfessionalismOfOwner) + (carRating.SafetyFeatures) + (carRating.TireQuality) + (carRating.ElectricalFunctions) + (carRating.EngineOperation) + (carRating.DeliveryExperience)) / 9;
            carRating.OverallRating = total;


            car.AverageRating = (car.AverageRating * car.CarRatings.Count + total) / car.CarRatings.Count;

            return car.AverageRating;
        }


        public void DeleteCarRating(int id)
        {
            var carRating = _repo.Query<RatingCar>().Where(c => c.Id == id).FirstOrDefault();
            _repo.Delete<RatingCar>(carRating);
            _repo.SaveChanges();
        }

        public void UpdateCarRating(RatingCar carRating)
        {
            var originalCarRating = _repo.Query<RatingCar>().Where(c => c.Id == carRating.Id).FirstOrDefault();
            
            originalCarRating.DeliveryExperience = carRating.DeliveryExperience;
            originalCarRating.ElectricalFunctions = carRating.ElectricalFunctions;
            originalCarRating.IndoorAirQuality = carRating.IndoorAirQuality;
            originalCarRating.InsideCleanliness = carRating.InsideCleanliness;
            originalCarRating.OutsideCleanliness = carRating.OutsideCleanliness;
            originalCarRating.SafetyFeatures = carRating.SafetyFeatures;
            originalCarRating.TireQuality = carRating.TireQuality;
            originalCarRating.ProfessionalismOfOwner = carRating.ProfessionalismOfOwner;
           
            originalCarRating.OverallRating = carRating.OverallRating;

     
            _repo.Update<RatingCar>(originalCarRating);

        }

      
    }
}
