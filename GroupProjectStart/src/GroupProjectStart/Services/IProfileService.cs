using System.Collections.Generic;
using GroupProjectStart.Models;

namespace GroupProjectStart.Services
{
    public interface IProfileService
    {
        ApplicationUser getUser(string id);
        List<ApplicationUser> getUsers();
        List<Loaner> getLoaners();
    }
}