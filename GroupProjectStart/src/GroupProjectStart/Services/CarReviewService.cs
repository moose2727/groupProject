using CoderCamps;
using GroupProjectStart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace GroupProjectStart.Services
{
    public class CarReviewService : ICarReviewService
    {
        IGenericRepository _repo;

        public CarReviewService(IGenericRepository repo)
        {
            this._repo = repo;
        }

        public List<CarReview> GetReviews()
        {
            var data = _repo.Query<CarReview>().ToList();
            return data;
        }

        public CarReview GetReview(int Id)
        {
            var data = _repo.Query<CarReview>().Where(m => m.Id == Id).FirstOrDefault();
            return data;
        }

        public async void AddCarReview(int Id, CarReview review, IServiceProvider sp)
        {
            var _db = sp.GetService<ApplicationDbContext>();
            var result = await Get(review.Message);


            review.SentimentEntities = new List<SentimentInfo>();
            foreach(var r in result)
            {
                var sentiment = new SentimentInfo()
                {
                    SentimentScore = r.sentiment.score,
                    EntityType = r.sentiment.type

                };
                review.SentimentEntities.Add(sentiment);
            }
            // _repo.Add(review);
            // var car = _repo.Query<Car>().Where(c => c.Id == Id).Include(c => c.Reviews).FirstOrDefault();
            //review.TimeCreated = DateTime.Now;
            review.TimeCreated = DateTime.Now;

            var car = _db.Cars.Where(c => c.Id == Id).Include(u => u.Reviews).FirstOrDefault();
            car.Reviews.Add(review);
            _db.SaveChanges();
        }

     

        public void UpdateReview(CarReview review)
        {
            var originalReview = _repo.Query<CarReview>().Where(o => o.Id == review.Id).FirstOrDefault();
            originalReview.Message = review.Message;
            _repo.Update<CarReview>(originalReview);
        }

        public void DeleteReview(int id)
        {
            var data = _repo.Query<CarReview>().Where(r => r.Id == id).FirstOrDefault();
            _repo.Delete<CarReview>(data);
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
