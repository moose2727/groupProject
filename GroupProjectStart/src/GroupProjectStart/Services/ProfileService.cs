using CoderCamps;
using GroupProjectStart.Models;
using GroupProjectStart.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;


namespace GroupProjectStart.Services
{
    public class ProfileService : IProfileService
    {
        IGenericRepository _repo;
        public ProfileService(IGenericRepository repo)
        {
            this._repo = repo;
        }


        /// <summary>
        /// 
        /// Gets a list of users
        /// 
        /// </summary>
        public List<UserVM> getUsers()
        {
            var users = _repo.Query<ApplicationUser>().Include(u => u.Reviews).ToList();
            var usersVM = new List<UserVM>();
            foreach (var user in users)
            {
                usersVM.Add(
                    new UserVM
                    {
                        Id = user.Id,
                        AverageRating = user.AverageRating,
                        CarsToLoan = user.CarsToLoan,
                        DisplayName = user.DisplayName,
                        DriverRatings = user.DriverRatings,
                        Email = user.Email,
                        FirstName = user.FirstName,
                        HasDamageInsurance = user.HasDamageInsurance,
                        HasLicense = user.HasLicense,
                        HasTheftInsurance = user.HasTheftInsurance,
                        Image = user.Image,
                        IsAdmin = user.IsAdmin,
                        IsLoaner = user.IsLoaner,
                        LastName = user.LastName,
                        Reviews = user.Reviews,
                        UserName = user.UserName
                    });
                
            }

            return usersVM;
        }


        /// <summary>
        /// 
        /// Gets a single user
        /// 
        /// </summary>
        public UserVM getUser(string id)
        {
            var user = _repo.Query<ApplicationUser>().Include(u => u.CarsToLoan).Include(u => u.Reviews).Where(u => u.Id == id).FirstOrDefault();
            var vm = new UserVM
            {
                Id = user.Id,
                AverageRating = user.AverageRating,
                CarsToLoan = user.CarsToLoan,
                DisplayName = user.DisplayName,
                DriverRatings = user.DriverRatings,
                Email = user.Email,
                FirstName = user.FirstName,
                HasDamageInsurance = user.HasDamageInsurance,
                HasLicense = user.HasLicense,
                HasTheftInsurance = user.HasTheftInsurance,
                Image = user.Image,
                IsAdmin = user.IsAdmin,
                IsLoaner = user.IsLoaner,
                LastName = user.LastName,
                Reviews = user.Reviews,
                UserName = user.UserName
            };
            return vm;
        }


        /// <summary>
        /// 
        /// Updates a users info
        /// 
        /// </summary>
        public void UpdateUser(UserVM user)
        {
            var originalUser = _repo.Query<ApplicationUser>().Where(u => u.Id == user.Id).FirstOrDefault();
            originalUser.FirstName = user.FirstName;
            originalUser.LastName = user.LastName;
            originalUser.DisplayName = user.DisplayName;
            originalUser.Email = user.Email;
            originalUser.HasLicense = user.HasLicense;
            originalUser.HasTheftInsurance = user.HasTheftInsurance;
            originalUser.HasDamageInsurance = user.HasDamageInsurance;
            originalUser.Image = user.Image;
            originalUser.IsLoaner = user.IsLoaner;
            originalUser.IsAdmin = user.IsAdmin;
            _repo.SaveChanges();


        }
    }
}
