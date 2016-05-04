using System.Collections.Generic;
using GroupProjectStart.Models;
using GroupProjectStart.ViewModels;

namespace GroupProjectStart.Services
{
    public interface IProfileService
    {
        UserVM getUser(string id);
        List<UserVM> getUsers();
        void UpdateUser(UserVM user);
    }
}