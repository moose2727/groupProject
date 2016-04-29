using System.Collections.Generic;
using GroupProjectStart.Models;
using GroupProjectStart.ViewModels;

namespace GroupProjectStart.Services
{
    public interface IProfileService
    {
        ApplicationUser getUser(string id);
        List<ApplicationUser> getUsers();
        void UpdateUser(ApplicationUser user);
        //List<LoanerViewModel> getLoaners();
        //List<Loaner> GetSpecifics();
    }
}