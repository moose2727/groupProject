using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProjectStart.Models
{
    public class RatingDriver
    {
        public int Id { get; set; }
        public int SchedulingExperience { get; set; }
        public int PaymentExperience { get; set; }
        public int PromptReplies { get; set; }
        public int DeliveryExperience { get; set; }
        public int ConditionOfReturnedCar { get; set; }
        public int Trustworthiness { get; set; }
        public int ProfessionalismOfDriver { get; set; }
        public int OverallRating { get; set; }
    }
}
