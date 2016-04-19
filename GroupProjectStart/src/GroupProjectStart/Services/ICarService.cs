using System.Collections.Generic;
using GroupProjectStart.Models;

namespace GroupProjectStart.Services
{
    public interface ICarService
    {
        void AddCar(Car car);
        void DeleteCar(int id);
        Car GetCar(int id);
        List<Car> GetCars();
        void UpdateCar(Car car);
    }
}