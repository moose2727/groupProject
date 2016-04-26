using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProjectStart.Models
{
    public class DriverReview
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public DateTime TimeCreated { get; set; }
        //Possibly going to use this to determine the reviews sentiment VIA Ayesha's API
        public decimal Sentiment { get; set; }
        public bool IsViewable { get; set; }
    }
}
