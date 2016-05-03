using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProjectStart.Models
{
    public class DriverReview
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Message is required")]
        public string Message { get; set; }
        public DateTime TimeCreated { get; set; }
        public ICollection<SentimentInfo> SentimentEntities { get; set; }       
        public bool IsViewable { get; set; }
    }
}
