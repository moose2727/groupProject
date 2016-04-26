using System.Collections.Generic;
using GroupProjectStart.Models;

namespace GroupProjectStart.Services
{
    public interface ICarService
    {
        void AddCar(string id, Car car);
        void DeleteCar(int id);
        Car GetCar(int id);
        List<ApplicationUser> GetCars();
        void UpdateCar(Car car);
    }
}