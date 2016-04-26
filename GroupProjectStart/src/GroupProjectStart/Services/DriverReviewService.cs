using CoderCamps;
using GroupProjectStart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProjectStart.Services
{
    public class DriverReviewService : IDriverReviewService
    {
        IGenericRepository _repo;

        public DriverReviewService(IGenericRepository repo)
        {
            this._repo = repo;
        }

        public List<DriverReview> GetReviews()
        {
            var data = _repo.Query<DriverReview>().ToList();
            return data;
        }

        public DriverReview GetReview(int Id)
        {
            var data = _repo.Query<DriverReview>().Where(m => m.Id == Id).FirstOrDefault();
            return data;
        }

        public void AddDriverReview(string Id, DriverReview review)
        {
            _repo.Add(review);
            var user = _repo.Query<ApplicationUser>().Where(u => u.Id == Id).Include(u => u.Reviews).FirstOrDefault();
            review.TimeCreated = DateTime.Now;
            user.Reviews.Add(review);
            _repo.SaveChanges();
        }

        public void UpdateReview(DriverReview review)
        {
            var originalReview = _repo.Query<DriverReview>().Where(o => o.Id == review.Id).FirstOrDefault();
            originalReview.Message = review.Message;
            _repo.Update<DriverReview>(originalReview);
        }

        public void DeleteReview(int id)
        {
            var data = _repo.Query<DriverReview>().Where(r => r.Id == id).FirstOrDefault();
            _repo.Delete<DriverReview>(data);
            _repo.SaveChanges();
        }
    }
}
