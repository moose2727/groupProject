using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GroupProjectStart.Models
{


    public class SentimentData
    {
        public string status { get; set; }
        public string usage { get; set; }
        public string url { get; set; }
        public string totalTransactions { get; set; }
        public string language { get; set; }
        public List<Entity> entities { get; set; }
    }

    public class Sentiment
    {
        public string type { get; set; }
        public string score { get; set; }
    }

    public class Entity
    {       
        public string type { get; set; }
        public string relevance { get; set; }
        public Sentiment sentiment { get; set; }
        public string count { get; set; }
        public string text { get; set; }
    }

    public class SentimentInfo
    {
        public int Id { get; set; }
        public string EntityType { get; set; }
        public string Relevance { get; set; }
        public string SentimentType { get; set; }
        public string SentimentScore { get; set; }
        public string Count { get; set; }
        public string Text { get; set; }
    }
}
