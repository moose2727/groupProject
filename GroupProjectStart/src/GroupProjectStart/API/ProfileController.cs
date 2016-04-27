using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using GroupProjectStart.Services;
using GroupProjectStart.Models;
using GroupProjectStart.ViewModels;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace GroupProjectStart.API
{
    [Route("api/[controller]")]
    public class ProfileController : Controller
    {
        IProfileService _repo;
        public ProfileController(IProfileService repo)
        {
            this._repo = repo;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<ApplicationUser> Get()
        {
            return _repo.getUsers();
        }

        //[HttpGet("GetLoaners")]
        ////[Route("GetLoaners")]
        //public IEnumerable<LoanerViewModel> GetLoaners()
        //{
        //    return _repo.getLoaners();
        //}

        //[HttpGet]
        //[Route("isLoaner")]
        //public IEnumerable<Loaner> GetIsLoaners()
        //{
        //    return _repo.GetSpecifics();
        //}

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            return Ok(_repo.getUser(id));
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
