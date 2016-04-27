using System.Collections.Generic;
using GroupProjectStart.Models;

namespace GroupProjectStart.Services
{
    public interface ICarReviewService
    {
        void AddCarReview(int Id, CarReview review);
        void DeleteReview(int id);
        CarReview GetReview(int Id);
        List<CarReview> GetReviews();
        void UpdateReview(CarReview review);
    }
}