using CoderCamps;
using GroupProjectStart.Models;
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

        public List<Loaner> getLoaners()
        {
            var loaners = _repo.Query<Loaner>().Include(l => l.CarsToLoan).ToList();
            return loaners;
        }

        public ApplicationUser getUser(string id)
        {
            return _repo.Query<ApplicationUser>().Where(u => u.Id == id).FirstOrDefault();

        }

        public List<Loaner> GetSpecifics()
        {
            var someLoaners = _repo.Query<Loaner>().Where(l => l.IsLoaner == true).Include(l => l.CarsToLoan).ToList();
            return someLoaners;
        }
    }
}
