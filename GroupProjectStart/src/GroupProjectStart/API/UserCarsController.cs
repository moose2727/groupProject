using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using GroupProjectStart.Services;
using GroupProjectStart.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace GroupProjectStart.API
{
    [Route("api/[controller]")]
    public class UserCarsController : Controller
    {
        IUserCarsService _repo;

        public UserCarsController(IUserCarsService repo)
        {
            this._repo = repo;
        }

        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            var data = _repo.GetUserCars();
            return Ok(data);
        }

        [HttpGet]
        [Route("browse")]
        public IEnumerable<ApplicationUser> getPage(int page)
        {
            var cars = _repo.GetPageCars(page);
            return cars;
        }

        [HttpGet]
        [Route("totalcount")]
        public IActionResult getAll()
        {
            var cars = _repo.getAllUsers();
            return Ok(cars);
            
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            return Ok(_repo.getUserCar(id));
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
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
        }
    }
}
