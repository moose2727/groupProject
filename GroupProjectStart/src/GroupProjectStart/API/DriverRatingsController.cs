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
    public class DriverRatingsController : Controller
    {
        IDriverRatingService _repo;

        public DriverRatingsController(IDriverRatingService repo)
        {
            this._repo = repo;
        }

        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repo.GetDriverRatings());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_repo.GetDriverRating(id));
        }

        // POST api/values
        [HttpPost("{id}")]
        public IActionResult Post(string id, [FromBody]RatingDriver driverRating)
        {
            if(driverRating.Id == 0)
            {
                _repo.AddDriverRating(id, driverRating);
            }
            else
            {
                _repo.UpdateDriverRating(driverRating);
            }
            return Ok(driverRating);
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
            _repo.DeleteDriverRating(id);
        }
    }
}
