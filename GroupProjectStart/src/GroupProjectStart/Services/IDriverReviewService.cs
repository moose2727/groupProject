using System.Collections.Generic;
using GroupProjectStart.Models;

namespace GroupProjectStart.Services
{
    public interface IDriverReviewService
    {
        void AddDriverReview(string Id, DriverReview review);
        void DeleteReview(int id);
        DriverReview GetReview(int Id);
        List<DriverReview> GetReviews();
        void UpdateReview(DriverReview review);
    }
}