using CoderCamps;
using GroupProjectStart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;

namespace GroupProjectStart.Services
{
    public class UserCarsService : IUserCarsService
    {
        IGenericRepository _repo;
        public UserCarsService(IGenericRepository repo)
        {
            this._repo = repo;
        }

        public List<ApplicationUser> GetUserCars()
        {
            //var r1 = _repo.Query<SentimentInfo>().ToList();
            //var users = _repo.Query<ApplicationUser>().
            
            var cars = _repo.Query<ApplicationUser>().Include(u => u.CarsToLoan).Include(u => u.Reviews).ToList();

            return cars;
        }

        //public List<LoanerViewModel> getLoaners()
        //{
        //    var loaners = _repo.Query<Loaner>().Include(l => l.CarsToLoan).Select(
        //        l => new LoanerViewModel
        //        {
        //            //DisplayName = l.DisplayName,
        //            //FirstName = l.FirstName,
        //            //HasDamageInsurance = l.HasDamageInsurance,
        //            //LastName = l.LastName,
        //            //HasLicense = l.HasLicense,
        //            ////HasTheftInsurance = l.HasTheftInsurance,
        //            //Email = l.Email,
        //            CarsToLoan = l.CarsToLoan,
        //            //IsLoaner = l.IsLoaner,
        //            //Id = l.Id
        //        }).ToList();

        //    return loaners;
        //}

        public ApplicationUser getUserCar(string id)
        {
            //    var user =  _repo.Query<ApplicationUser>().Include(u => u.CarsToLoan).Include(u => u.Reviews.Select(r => r.SentimentEntities)).Where(u => u.Id == id).Select(r => new ApplicationUser() { Reviews = r.Reviews.Select(s => s.SentimentEntities) }).FirstOrDefault();

            var user = _repo.Query<ApplicationUser>().Include(u => u.CarsToLoan).Include(u => u.Reviews).ThenInclude(r => r.SentimentEntities).Where(u => u.Id == id).FirstOrDefault();
       
            return user;
        }

        //public Loaner getLoaner(string id) {
        //    return _repo.Query<Loaner>().Where(l => l.Id == id).Include(l => l.CarsToLoan).FirstOrDefault();
        //}
    }
}

