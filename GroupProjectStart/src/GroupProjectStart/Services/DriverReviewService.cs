using CoderCamps;
using GroupProjectStart.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Data.Entity;

namespace GroupProjectStart.Services
{
    public class DriverReviewService : IDriverReviewService
    {
        IGenericRepository _repo;
        //ApplicationDbContext _db;
        public DriverReviewService(IGenericRepository repo)
        {
            this._repo = repo;
            //_db = db;
        }

        public List<DriverReview> GetReviews()
        {
            
            var data = _repo.Query<DriverReview>().ToList();
            return data;
        }

        public DriverReview GetReview(int Id)
        {
            var data = _repo.Query<DriverReview>().Where(m => m.Id == Id).Include(m => m.SentimentEntities).FirstOrDefault();
            return data;
        }

        public async void AddDriverReview(string Id, DriverReview review, IServiceProvider sp)
        {
            var _db = sp.GetService<ApplicationDbContext>();

            //Task<Task> t = null;
            //try
            //{
            // t = Task.WhenAny(Get(review.Title, review.Message), Task.Delay(5000));
            var result = await Get(review.Message);

            //}
            //catch
            //{

            //}

            //if (t.Status != TaskStatus.Canceled || t.Status == TaskStatus.RanToCompletion)
            //{
            //    var result = await t;

            //    // Convert result into SentinmentInfo object before you call save method.

            //    // call your save method, look at Associated entitites lesson in coder camps.

            //}
            review.SentimentEntities = new List<SentimentInfo>();
            foreach (var r in result)
            {
                var sent = new SentimentInfo()
                {
                    SentimentScore = r.sentiment.score,
                    SentimentType = r.sentiment.type

                };
                review.SentimentEntities.Add(sent);

            }


            // _repo.Add(review);
            //var user = _repo.Query<ApplicationUser>().Where(u => u.Id == Id).Include(u => u.Reviews).FirstOrDefault();
            review.TimeCreated = DateTime.Now;


            var user = _db.Users.Where(u => u.Id == Id).Include(u => u.Reviews).FirstOrDefault();
            user.Reviews.Add(review);
            _db.SaveChanges();
           

            //_repo.SaveChanges();
        }

        public void UpdateReview(DriverReview review)
        {
            var originalReview = _repo.Query<DriverReview>().Where(o => o.Id == review.Id).FirstOrDefault();
            originalReview.Message = review.Message;
            _repo.Update<DriverReview>(originalReview);
        }

        public void DeleteReview(int id)
        {
            var data = _repo.Query<DriverReview>().Where(r => r.Id == id).FirstOrDefault();
            _repo.Delete<DriverReview>(data);
            _repo.SaveChanges();
        }

        public async Task<List<Entity>> Get(string sampleText)
        {
            using (var client = new HttpClient())
            {
                var values = new Dictionary<string, string>
                    {
                       { "apikey", "20516fb6c289bac88bd5703e6ded4401ba95f983" },
                       { "text", sampleText},
                       { "outputMode", "json"},
                       { "sentiment", "1"},
                       { "disambiguate", "0"},
                       { "linkedData", "0"},
                       { "coreference", "0"},
                       { "quotations", "0"}
                    };

                var content = new FormUrlEncodedContent(values);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
                var response = await client.PostAsync("http://gateway-a.watsonplatform.net/calls/text/TextGetRankedNamedEntities", content);
                var responseString = await response.Content.ReadAsStringAsync();

                if (!string.IsNullOrEmpty(responseString))
                {
                    SentimentData sentimentData = JsonConvert.DeserializeObject<SentimentData>(responseString);
                    return sentimentData.entities;
                }


                return new List<Entity>();
            }

        }
    }
}
