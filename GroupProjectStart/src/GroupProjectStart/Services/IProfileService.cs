using System.Collections.Generic;
using GroupProjectStart.Models;
using GroupProjectStart.ViewModels;

namespace GroupProjectStart.Services
{
    public interface IProfileService
    {
        ApplicationUser getUser(string id);
        List<ApplicationUser> getUsers();
        //List<LoanerViewModel> getLoaners();
        //List<Loaner> GetSpecifics();
    }
}