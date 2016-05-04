using System.Collections.Generic;
using GroupProjectStart.Models;
using GroupProjectStart.ViewModels;

namespace GroupProjectStart.Services
{
    public interface ICarService
    {
        object Cars { get; set; }

        void AddCar(string id, Car car);
        void DeleteCar(int id);
        Car GetCar(int id);
        List<Car> GetCarShortList(int pagenum);
        List<Car> GetAllCars();
        int GetCarNumber(); 
        void UpdateCar(Car car);
    }
}