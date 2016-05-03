using CoderCamps;
using GroupProjectStart.Models;
using GroupProjectStart.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace GroupProjectStart.test
{
    public class DriverRatingServiceTest
    {
        private ApplicationUser user = new ApplicationUser
     {
               Id = "abc123",
               UserName = "abc@hotmail.com",
               Email = "abc@hotmail.com",
               FirstName = "Jason",
               LastName = "Denevers",
               DisplayName = "Moose2727",
               HasTheftInsurance = true,
               HasDamageInsurance = true,
               HasLicense = true,
               IsLoaner = true,
               Image = "https://pbs.twimg.com/profile_images/1777364406/profile.jpg",
      

               DriverRatings = new List<RatingDriver>
               {
                   new RatingDriver
                   {
                        ConditionOfReturnedCar = 5,
                        PaymentExperience =5,
                        ProfessionalismOfDriver = 5,
                        PromptReplies = 5,
                        SchedulingExperience = 5,
                        Trustworthiness = 5,
                        DeliveryExperience = 5
                   },

               }
        };

        private List<ApplicationUser> users = new List<ApplicationUser>
        {
            new ApplicationUser {
               Id = "abc123",
               UserName = "abc@hotmail.com",
               Email = "abc@hotmail.com",
               FirstName = "Jason",
               LastName = "Denevers",
               DisplayName = "Moose2727",
               HasTheftInsurance = true,
               HasDamageInsurance = true,
               HasLicense = true,
               IsLoaner = true,
               Image = "https://pbs.twimg.com/profile_images/1777364406/profile.jpg",
            },
             new ApplicationUser {
               Id = "abc321",
               UserName = "123@hotmail.com",
               Email = "123@hotmail.com",
               FirstName = "Cory",
               LastName = "Couty",
               DisplayName = "syncrose",
               HasTheftInsurance = false,
               HasDamageInsurance = false,
               HasLicense = false,
               IsLoaner = true,
               Image = "https://pbs.twimg.com/profile_images/1777364406/profile.jpg",
            },
              new ApplicationUser {
               Id = "abc456",
               UserName = "bob@hotmail.com",
               Email = "bob@hotmail.com",
               FirstName = "bob",
               LastName = "smith",
               DisplayName = "bobert",
               HasTheftInsurance = true,
               HasDamageInsurance = false,
               HasLicense = true,
               IsLoaner = false,
               Image = "https://pbs.twimg.com/profile_images/1777364406/profile.jpg",
            }
        };


        [Fact]
        public void TestAddDriverRating()
        {
            //Arrange
            var mock = new Mock<IGenericRepository>();
            mock.Setup(x => x.Query<ApplicationUser>()).Returns(users.AsQueryable());
            var driverRatingService = new DriverRatingService(mock.Object);
            var ratingDriverTest = new RatingDriver()
            {
                ConditionOfReturnedCar = 4,
                DeliveryExperience = 3,
                PaymentExperience = 4,
                ProfessionalismOfDriver = 5,
                PromptReplies = 4,
                SchedulingExperience = 3,
                Trustworthiness = 5

            };

            //Act
            var result = driverRatingService.CalculateDriverRating(this.user, ratingDriverTest);

            //Assert
            Assert.Equal(result, 4m);
        }
    }
}
