using CoderCamps;
using GroupProjectStart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProjectStart.Services
{
    public class DriverRatingService : IDriverRatingService
    {
        IGenericRepository _repo;

        public DriverRatingService(IGenericRepository repo)
        {
            this._repo = repo;
        }

        public List<RatingDriver> GetDriverRatings()
        {
            var driverRatings = _repo.Query<RatingDriver>().ToList();
            return driverRatings;
        }

        public RatingDriver GetDriverRating(int id)
        {
            var driverRating = _repo.Query<RatingDriver>().Where(c => c.Id == id).FirstOrDefault();
            return driverRating;
        }

        public void AddDriverRating(RatingDriver driverRating)
        {
            _repo.Add(driverRating);
        }

        public void DeleteDriverRating(int id)
        {
            var driverRating = _repo.Query<RatingDriver>().Where(c => c.Id == id).FirstOrDefault();
            _repo.Delete<RatingDriver>(driverRating);
            _repo.SaveChanges();
        }

        public void UpdateDriverRating(RatingDriver driverRating)
        {
            var originalDriverRating = _repo.Query<RatingDriver>().Where(c => c.Id == driverRating.Id).FirstOrDefault();
            originalDriverRating.PaymentExperience = driverRating.PaymentExperience;
            originalDriverRating.ProfessionalismOfDriver = driverRating.ProfessionalismOfDriver;
            originalDriverRating.PromptReplies = driverRating.PromptReplies;
            originalDriverRating.SchedulingExperience = driverRating.SchedulingExperience;
            originalDriverRating.Trustworthiness = driverRating.Trustworthiness;
            originalDriverRating.OverallRating = driverRating.OverallRating;

            _repo.Update<RatingDriver>(originalDriverRating);

        }
    }
}
