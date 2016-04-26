using CoderCamps;
using GroupProjectStart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProjectStart.Services
{
    public class CarService : ICarService
    {
        IGenericRepository _repo;

        public CarService(IGenericRepository repo)
        {
            this._repo = repo;
        }

        public List<ApplicationUser> GetCars()
        {
            return _repo.Query<ApplicationUser>().ToList();
        }

        public Car GetCar(int id)
        {
            var car = _repo.Query<Car>().Where(c => c.Id == id).Include(c => c.Reviews).FirstOrDefault();
                       return car;
        }

        public void AddCar(Car car)
        {
            _repo.Add(car);    
        }

        public void DeleteCar(int id)
        {
            var car = _repo.Query<Car>().Where(c => c.Id == id).FirstOrDefault();
            _repo.Delete<Car>(car);
            _repo.SaveChanges();
        }

        public void UpdateCar(Car car)
        {
            var originalCar = _repo.Query<Car>().Where(c => c.Id == car.Id).FirstOrDefault();
            originalCar.Image = car.Image;
            originalCar.Door = car.Door;
            originalCar.Make = car.Make;
            originalCar.Model = car.Model;
            originalCar.Price = car.Price;
            originalCar.Year = car.Year;
            originalCar.Condition = car.Condition;
            originalCar.CtyMpg = car.CtyMpg;
            originalCar.Description = car.Description;
            originalCar.HwyMpg = car.HwyMpg;
            originalCar.CtyMpg = car.CtyMpg;
            originalCar.Seats = car.Seats;
            originalCar.Transmission = car.Transmission;
            originalCar.Miles = car.Miles;
            originalCar.IsActive = car.IsActive;

            _repo.Update<Car>(originalCar);

        }
    }
}
