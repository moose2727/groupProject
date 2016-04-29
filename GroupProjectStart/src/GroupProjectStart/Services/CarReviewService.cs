using CoderCamps;
using GroupProjectStart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;

namespace GroupProjectStart.Services
{
    public class CarReviewService : ICarReviewService
    {
        IGenericRepository _repo;

        public CarReviewService(IGenericRepository repo)
        {
            this._repo = repo;
        }

        public List<CarReview> GetReviews()
        {
            var data = _repo.Query<CarReview>().ToList();
            return data;
        }

        public CarReview GetReview(int Id)
        {
            var data = _repo.Query<CarReview>().Where(m => m.Id == Id).FirstOrDefault();
            return data;
        }

        public void AddCarReview(int Id, CarReview review)
        {
            _repo.Add(review);
            var car = _repo.Query<Car>().Where(c => c.Id == Id).Include(c => c.Reviews).FirstOrDefault();
           review.TimeCreated = DateTime.Now;
            car.Reviews.Add(review);
            _repo.SaveChanges();
        }

     

        public void UpdateReview(CarReview review)
        {
            var originalReview = _repo.Query<CarReview>().Where(o => o.Id == review.Id).FirstOrDefault();
            originalReview.Message = review.Message;
            _repo.Update<CarReview>(originalReview);
        }

        public void DeleteReview(int id)
        {
            var data = _repo.Query<CarReview>().Where(r => r.Id == id).FirstOrDefault();
            _repo.Delete<CarReview>(data);
            _repo.SaveChanges();
        }
    }
}
