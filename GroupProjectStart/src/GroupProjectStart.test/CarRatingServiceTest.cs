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
    public class CarRatingServiceTest
    {
        private Car car = new Car
        {



            CarRatings = new List<RatingCar>
               {
                   new RatingCar
                   {

                         TireQuality = 3,
                      OutsideCleanliness = 3,
                      InsideCleanliness = 3,
                      EngineOperation = 3,
                      IndoorAirQuality = 3,
                      SafetyFeatures = 3,
                      ElectricalFunctions = 3,
                      DeliveryExperience = 3,
                      ProfessionalismOfOwner = 3,
                   },

               }
        };


        private List<Car> tests = new List<Car>
        {


            new Car
        {
            Id = 1,
            Condition = "good",
            Door = 4,
            Make = "Toyota",
            Model = "Corolla",
            //CarRatings = new List<RatingCar>
              ////{
              //    new RatingCar
              //    {
              //        TireQuality = 5,
              //        OutsideCleanliness = 4,
              //        InsideCleanliness = 4,
              //        EngineOperation = 3,
              //        IndoorAirQuality = 4,
              //        SafetyFeatures = 2,
              //        ElectricalFunctions = 5,
              //        DeliveryExperience = 4,
              //        ProfessionalismOfOwner = 5,

              //    },
              //}

            },
                      new Car
        {
            Id = 1,
            Condition = "good",
            Door = 4,
            Make = "Toyota",
            Model = "Corolla",
            //CarRatings = new List<RatingCar>
              ////{
              //    new RatingCar
              //    {
              //        TireQuality = 5,
              //        OutsideCleanliness = 4,
              //        InsideCleanliness = 4,
              //        EngineOperation = 3,
              //        IndoorAirQuality = 4,
              //        SafetyFeatures = 2,
              //        ElectricalFunctions = 5,
              //        DeliveryExperience = 4,
              //        ProfessionalismOfOwner = 5,

              //    },
              //}

            },
                                new Car
        {
            Id = 1,
            Condition = "good",
            Door = 4,
            Make = "Toyota",
            Model = "Corolla",
            //CarRatings = new List<RatingCar>
              ////{
              //    new RatingCar
              //    {
              //        TireQuality = 5,
              //        OutsideCleanliness = 4,
              //        InsideCleanliness = 4,
              //        EngineOperation = 3,
              //        IndoorAirQuality = 4,
              //        SafetyFeatures = 2,
              //        ElectricalFunctions = 5,
              //        DeliveryExperience = 4,
              //        ProfessionalismOfOwner = 5,

              //    },
              //}

            }

        };

        [Fact]
        public void TestAddCarRating()
        {
            //Arrange
            var mock = new Mock<IGenericRepository>();
            mock.Setup(x => x.Query<Car>()).Returns(tests.AsQueryable());
            var carRatingService = new CarRatingService(mock.Object);
            var ratingCarTest = new RatingCar()
            {
                TireQuality = 3,
                OutsideCleanliness = 3,
                InsideCleanliness = 3,
                EngineOperation = 3,
                IndoorAirQuality = 3,
                SafetyFeatures = 3,
                ElectricalFunctions = 3,
                DeliveryExperience = 3,
                ProfessionalismOfOwner = 3,
            };

            //Act
            var result = carRatingService.CalculateCarRating(this.car, ratingCarTest);
            //Assert
            Assert.Equal(result, 3);

        }

    }
}
