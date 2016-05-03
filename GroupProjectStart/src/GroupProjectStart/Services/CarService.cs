using CoderCamps;
using GroupProjectStart.Models;
using GroupProjectStart.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;

namespace GroupProjectStart.Services
{
    public class CarService : ICarService
    {
        IGenericRepository _repo;

        public object Cars
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public CarService(IGenericRepository repo)
        {
            this._repo = repo;
        }

        //public PagingVM GetCars(int page)
        //{

        //    const int ITEMS_PER_PAGE = 4;

        //    var cars = _repo.Query<Car>()
        //        .OrderBy(c => c.Id)
        //        .Skip(page * ITEMS_PER_PAGE)
        //        .Take(ITEMS_PER_PAGE)
        //        .ToList();
        //    var numCars = _repo.Query<Car>().Count();
        //    var vm = new PagingVM
        //    {
        //        Cars = cars,
        //        TotalCount = numCars
        //    };
        //    return vm;
        //}

        public Car GetCar(int id)
        {
            var car = _repo.Query<Car>().Where(c => c.Id == id).Include(c => c.Reviews).ThenInclude(r => r.SentimentEntities).FirstOrDefault();
            return car;
        }

        public void AddCar(string id, Car car)
        {
            var user = _repo.Query<ApplicationUser>().Where(u => u.Id == id).Include(u => u.CarsToLoan).FirstOrDefault();
            car.DateAdded = DateTime.Now;
            user.CarsToLoan.Add(car);
            _repo.SaveChanges();
            //_repo.Add(car);    
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

        public List<Car> GetCarShortList(int pagenum)
        {
            var cars = _repo.Query<Car>().Skip(4 * (pagenum - 1)).Take(4).ToList();
            return cars;
        }

        public List<Car> GetAllCars()
        {
            var cars = _repo.Query<Car>().ToList();
            return cars;
        }

        public int GetCarNumber()
        {
            var list = _repo.Query<Car>().ToList();
            var num = list.Count;
            return num;
        }
    }
}
