using System.Collections.Generic;
using GroupProjectStart.Models;

namespace GroupProjectStart.Services
{
    public interface IDriverRatingService
    {
        decimal AddDriverRating(string id, RatingDriver driverRating);
        void DeleteDriverRating(int id);
        RatingDriver GetDriverRating(int id);
        List<RatingDriver> GetDriverRatings();
        void UpdateDriverRating(RatingDriver driverRating);
    }
}