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
    public class CarReviewsController : Controller
    {
        ICarReviewService _repo;


        public CarReviewsController(ICarReviewService repo)
        {
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
        //ADD CAR REVIEW
        public IActionResult Post(int id, [FromBody]CarReview review)
        {
            if(review.Id == 0)
            {
                _repo.AddCarReview(id, review);
            }
            else
            {
                _repo.UpdateReview(review);
            }
            return Ok(review);
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
