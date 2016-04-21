using CoderCamps;
using GroupProjectStart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public void AddCarRating(RatingCar carRating)
        {
            _repo.Add(carRating);
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
