using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using GroupProjectStart.Models;
using GroupProjectStart.Services;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860
//hi cory

namespace GroupProjectStart.API
{
    [Route("api/[controller]")]
    public class CarsController : Controller
    {
        ICarService _repo;

        public CarsController(ICarService repo)
        {
            this._repo = repo;
        }

        //private ApplicationDbContext _db;

        //public CarsController(ApplicationDbContext db)
        //{
        //    this._db = db;
        //}

        // GET: api/values

        //[HttpGet("pagination/{page}")]
        //public IActionResult GetPage(int page)
        //{
        //    var data = _repo.GetCars(page);
        //    return Ok(data);
        //}

        [HttpGet]
        [Route("browse")]
        public IEnumerable<Car> getpage(int num)
        {
            //var cars = _db.Cars.Skip(4 * (num - 1)).Take(4).ToList();
            var cars = _repo.GetCarShortList(num);
            return cars;
        }

        [HttpGet]
        [Route("totalcount")]
        public IActionResult getpage()
        {
            //var cars = _db.Cars.Skip(4 * (num - 1)).Take(4).ToList();
            var cars = _repo.GetAllCars();
            return Ok(cars);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_repo.GetCar(id));
        }

        // POST api/values
        [HttpPost("{id}")]
        public IActionResult Post(string id, [FromBody]Car car)
        {
            if (ModelState.IsValid)
            { 
            if (car.Id == 0)
            {
                _repo.AddCar(id, car);
            }
            else
            {
                _repo.UpdateCar(car);
            }
            return Ok(car);
        }
        return HttpBadRequest(ModelState);
    }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repo.DeleteCar(id);
        }
    }
}
