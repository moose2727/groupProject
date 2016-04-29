using System.Collections.Generic;
using GroupProjectStart.Models;
using GroupProjectStart.ViewModels;

namespace GroupProjectStart.Services
{
    public interface ICarService
    {
        void AddCar(string id, Car car);
        void DeleteCar(int id);
        Car GetCar(int id);
        PagingVM GetCars(int page);
        void UpdateCar(Car car);
    }
}