using System.Collections.Generic;
using GroupProjectStart.Models;

namespace GroupProjectStart.Services
{
    public interface IReviewService
    {
        void AddCarReview(int Id, Review review);
        void AddDriverReview(string Id, Review review);
        void DeleteReview(int id);
        Review GetReview(int Id);
        List<Review> GetReviews();
        void UpdateReview(Review review);
    }
}