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

            
            var cars = _repo.Query<ApplicationUser>().Include(u => u.CarsToLoan).ToList();

            return cars;
        }

        public List<ApplicationUser> GetPageCars(int pagenum)
        {
            var cars = _repo.Query<ApplicationUser>().Where(u => u.CarsToLoan.Count != 0).Skip(2 * (pagenum - 1)).Take(2).Include(u => u.CarsToLoan).ToList();
          
            return cars;
        }

        public List<ApplicationUser> getAllUsers()
        {
            var users = _repo.Query<ApplicationUser>().Where(u => u.CarsToLoan.Count != 0).ToList();
            return users;
        }



        public ApplicationUser getUserCar(string id)
        {
            var user = _repo.Query<ApplicationUser>().Include(u => u.CarsToLoan).Include(u => u.Reviews).ThenInclude(r => r.SentimentEntities).Where(u => u.Id == id).FirstOrDefault();
       
            return user;
        }

    }
}

