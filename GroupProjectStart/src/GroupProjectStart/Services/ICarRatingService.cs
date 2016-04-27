using System.Collections.Generic;
using GroupProjectStart.Models;

namespace GroupProjectStart.Services
{
    public interface ICarRatingService
    {
        void AddCarRating(int id, RatingCar carRating);
        void DeleteCarRating(int id);
        RatingCar GetCarRating(int id);
        List<RatingCar> GetCarRatings();
        void UpdateCarRating(RatingCar carRating);
    }
}