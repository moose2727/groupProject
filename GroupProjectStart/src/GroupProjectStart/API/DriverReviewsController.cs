using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using GroupProjectStart.Models;
using GroupProjectStart.Services;
using System.Net.Http;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using Microsoft.Data.Entity;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace GroupProjectStart.API
{
 
    [Route("api/[controller]")]
    public class DriverReviewsController : Controller
    {
        IDriverReviewService _repo;
        ApplicationDbContext _db;
        public DriverReviewsController(IDriverReviewService repo, ApplicationDbContext db)
        {
            this._db = db;
            this._repo = repo;
        }
        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
                return Ok(_repo.GetReviews());
           
            }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_repo.GetReview(id));
        }

        // POST api/values
        [HttpPost("{id}")]
        public IActionResult Post(string id, [FromBody]DriverReview driverReview)
        {
            if (ModelState.IsValid)
            {
                if (driverReview.Id == 0)
                {
                    _repo.AddDriverReview(id, driverReview, HttpContext.ApplicationServices);
                }
                else
                {
                    _repo.UpdateReview(driverReview);
                }
                return Ok(driverReview);
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

        }
    }
}
