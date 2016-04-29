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

        // GET: api/values
        //[HttpGet("{sampletext}")]
        //public async Task<List<Entity>> Get(string sampletext)
        //{
        //    using (var client = new HttpClient())
        //    {
        //        var values = new Dictionary<string, string>
        //            {
        //               { "apikey", "20516fb6c289bac88bd5703e6ded4401ba95f983" },
        //               { "text", sampletext },
        //               { "outputMode", "json"},
        //               { "sentiment", "1"},
        //               { "disambiguate", "0"},
        //               { "linkedData", "0"},
        //               { "coreference", "0"},
        //               { "quotations", "0"}
        //            };

        //        var content = new FormUrlEncodedContent(values);
        //        content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
        //        var response = await client.PostAsync("http://gateway-a.watsonplatform.net/calls/text/TextGetRankedNamedEntities", content);
        //        var responseString = await response.Content.ReadAsStringAsync();

        //        if (!string.IsNullOrEmpty(responseString))
        //        {
        //            SentimentData sentimentData = JsonConvert.DeserializeObject<SentimentData>(responseString);
        //            return sentimentData.entities;
        //        }


        //        return new List<Entity>();
        //    }

        //}

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
            
            if(driverReview.Id == 0)
            {
                _repo.AddDriverReview(id, driverReview, HttpContext.ApplicationServices);
            }
            else
            {
                _repo.UpdateReview(driverReview);
            }
            return Ok(driverReview);
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
