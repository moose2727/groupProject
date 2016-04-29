using System.Collections.Generic;
using System.Threading.Tasks;
using GroupProjectStart.Models;

namespace GroupProjectStart.Services
{
    public interface IDriverReviewService1
    {
        void AddDriverReview(string Id, DriverReview review);
        void DeleteReview(int id);
        Task<List<Entity>> Get(string sampleText, string moreText);
        DriverReview GetReview(int Id);
        List<DriverReview> GetReviews();
        void UpdateReview(DriverReview review);
    }
}