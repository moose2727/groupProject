using CoderCamps;
using GroupProjectStart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProjectStart.Services
{
    public class ReviewService
    {
        IGenericRepository _repo;

        public ReviewService(IGenericRepository repo)
        {
            this._repo = repo;
        }

        public List<Review> GetReviews()
        {
            var data = _repo.Query<Review>().ToList();
            return data;
        }

        public Review GetReview(int Id)
        {
            var data = _repo.Query<Review>().Where(m => m.Id == Id).FirstOrDefault();
            return data;
        }

        public void AddCarReview(int Id, Review review)
        {
            _repo.Add(review);
            var car = _repo.Query<Car>().Where(c => c.Id == Id).Include(c => c.Reviews).FirstOrDefault();
           review.TimeCreated = DateTime.Now;
            car.Reviews.Add(review);
            _repo.SaveChanges();
        }

        public void AddDriverReview(string Id, Review review)
        {
            _repo.Add(review);
            var user = _repo.Query<ApplicationUser>().Where(u => u.Id == Id).Include(u => u.Reviews).FirstOrDefault();
            review.TimeCreated = DateTime.Now;
            user.Reviews.Add(review);
            _repo.SaveChanges();
        }

        public void UpdateReview(Review review)
        {
            var originalReview = _repo.Query<Review>().Where(o => o.Id == review.Id).FirstOrDefault();
            originalReview.Message = review.Message;
            _repo.Update<Review>(originalReview);
        }

        public void DeleteReview(int id)
        {
            var data = _repo.Query<Review>().Where(r => r.Id == id).FirstOrDefault();
            _repo.Delete<Review>(data);
            _repo.SaveChanges();
        }
    }
}
