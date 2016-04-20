﻿using CoderCamps;
using GroupProjectStart.Models;
using GroupProjectStart.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProjectStart.Services
{
    public class ProfileService : IProfileService
    {
        IGenericRepository _repo;
        public ProfileService(IGenericRepository repo)
        {
            this._repo = repo;
        }

        public List<ApplicationUser> getUsers()
        {
            var users = _repo.Query<ApplicationUser>().ToList();
            return users;   
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

        public ApplicationUser getUser(string id)
        {
            return _repo.Query<ApplicationUser>().Where(u => u.Id == id).FirstOrDefault();

        }

        //public Loaner getLoaner(string id) {
        //    return _repo.Query<Loaner>().Where(l => l.Id == id).Include(l => l.CarsToLoan).FirstOrDefault();
        //}
    }
}
