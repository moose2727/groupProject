using System.Collections.Generic;
using GroupProjectStart.Models;

namespace GroupProjectStart.Services
{
    public interface IUserCarsService
    {
        ApplicationUser getUserCar(string id);
        List<ApplicationUser> GetUserCars();
        List<ApplicationUser> GetPageCars(int pagenum);
            List<ApplicationUser> getAllUsers();
    }
}