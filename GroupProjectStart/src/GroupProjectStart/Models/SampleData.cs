using System;
using System.Linq;
using Microsoft.Data.Entity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNet.Identity;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace GroupProjectStart.Models
{
    // sample comment from Ayesha.
    //create sample data for car model with the properties of make, model, year, price, doors, image

    public class SampleData
    {


        public async static Task Initialize(IServiceProvider serviceProvider)
        {
            var db = serviceProvider.GetService<ApplicationDbContext>();

            //USERS
            var context = serviceProvider.GetService<ApplicationDbContext>();
            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();
            context.Database.Migrate();

            // Ensure Stephen (IsAdmin)
            var stephen = await userManager.FindByNameAsync("Stephen.Walther@CoderCamps.com");
            if (stephen == null)
            {
                // create user
                stephen = new ApplicationUser
                {
                    UserName = "Stephen.Walther@CoderCamps.com",
                    Email = "Stephen.Walther@CoderCamps.com",
                    DisplayName = "SWalther",
                    FirstName = "Stephen",
                    LastName = "Walther",
                    IsAdmin = true
                };
                await userManager.CreateAsync(stephen, "Secret123!");

                // add claims
                await userManager.AddClaimAsync(stephen, new Claim("IsAdmin", "true"));
            }

            // Ensure Mike (not IsAdmin)
            var mike = await userManager.FindByNameAsync("Mike@CoderCamps.com");
            if (mike == null)
            {
                // create user
                mike = new ApplicationUser
                {
                    UserName = "Mike@CoderCamps.com",
                    Email = "Mike@CoderCamps.com",
                    DisplayName = "MM",
                    FirstName = "Mike",
                    LastName = "Miller",
                    Image = "http://static.eharmony.com/blog/wp-content/uploads/2010/04/eHarmony-Blog-profile-picture.jpg"
                };
                await userManager.CreateAsync(mike, "Secret123!");
            }


            var caleb = await userManager.FindByNameAsync("Caleb@Something.com");
            if (caleb == null)
            {
                // create user
                caleb = new ApplicationUser
                {
                    DriverRatings = new List<RatingDriver>
                        {
                            //new RatingDriver
                            //{
                            //     ConditionOfReturnedCar = 4,
                            //     PaymentExperience = 4,
                            //     ProfessionalismOfDriver = 3,
                            //     PromptReplies = 2,
                            //     SchedulingExperience = 3,
                            //     Trustworthiness = 5,
                            //     DeliveryExperience = 2
                            //},
                            //  new RatingDriver
                            //{
                            //     ConditionOfReturnedCar = 4,
                            //     PaymentExperience = 4,
                            //     ProfessionalismOfDriver = 3,
                            //     PromptReplies = 2,
                            //     SchedulingExperience = 3,
                            //     Trustworthiness = 5,
                            //     DeliveryExperience = 2
                            //},
                            //    new RatingDriver
                            //{
                            //     ConditionOfReturnedCar = 4,
                            //     PaymentExperience = 3,
                            //     ProfessionalismOfDriver = 4,
                            //     PromptReplies = 3,
                            //     SchedulingExperience = 4,
                            //     Trustworthiness = 4,
                            //     DeliveryExperience = 4
                            //},
                            //      new RatingDriver
                            //{
                            //     ConditionOfReturnedCar = 5,
                            //     PaymentExperience = 4,
                            //     ProfessionalismOfDriver = 3,
                            //     PromptReplies = 2,
                            //     SchedulingExperience = 4,
                            //     Trustworthiness = 5,
                            //     DeliveryExperience = 3
                            //},
                        },
                    Reviews = new List<DriverReview>
                        {
                           new DriverReview
                           {
                                Title = "Syrup Is tasty",
                                Message = "Someone I know recently combined Maple Syrup & buttered Popcorn thinking it would taste like caramel popcorn. It didn’t and they don’t recommend anyone else do it either.",
                                TimeCreated = DateTime.Now
                           },
                           new DriverReview
                           {
                                Title = "Shmeagle",
                                Message = " I was very proud of my nickname throughout high school but today- I couldn’t be any different to what my nickname was.",
                                TimeCreated = DateTime.Now
                           },
                           new DriverReview
                           {
                                Title = "Easter is weird",
                                Message = "If the Easter Bunny and the Tooth Fairy had babies would they take your teeth and leave chocolate for you?",
                                TimeCreated = DateTime.Now
                           },
                        },
                    UserName = "Caleb@Something.com",
                    Email = "Caleb@Something.com",
                    FirstName = "Caleb",
                    LastName = "Schwarzmiller",
                    DisplayName = "CSchwarz",
                    HasTheftInsurance = true,
                    HasDamageInsurance = true,
                    HasLicense = true,
                    IsLoaner = true,
                    Image = "https://www.filestackapi.com/api/file/RuTYywXlQughPk4vPpF9",
                    CarsToLoan = new List<Car>
                    {


                    new Car
                    {
                        Make = "Dodge",
                        Model = "Ram",
                        Year = 1992,
                        Image = "https://www.filestackapi.com/api/file/Ef6HlFyRMWHFSp7vccAe",
                        Door = 2,
                        Price = 40m,
                        IsActive = true,
                        Condition = "Okay",
                        CtyMpg = 19,
                        HwyMpg = 26,
                        DateAdded = DateTime.Now,
                        Miles = 215108,
                        Seats = 3,
                        Transmission = "Manual",
                        Description = "Lorem ipsum dolor sit amet, ei eam tempor eripuit, no nihil nonumy honestatis sit, eam at utroque luptatum reprehendunt. Te appareat consequat eum. Iisque facilisis eos an, te elitr cetero tacimates ius. Ut modus patrioque scribentur per, ei has erat populo essent, suas inimicus cum ut. Ad vocent audire phaedrum mea. Eos case doctus cudicam epicuri eum id.Vix scriptorem cotidieque inqui at dolore definitionem,facete voluptatum dissentiunt ad vel.Impedit officiis intellegam sea neet atqui aliquid fierent eos.Cu pri molestie definitionescu nec augue epicurei graeci principes pri ex.Doctus aeterno vim nesit an purto nullamea mel tollit sanctus."
                    },

                        new Car {

                            Year = 2009,
                            Make = "Hyundai",
                            Model = "Santa Fe",
                            Price = 125m,
                            Door = 4,
                            Image = "https://www.filestackapi.com/api/file/lngLZKwATVGc4nyN4MFV",
                            Miles = 65450,
                            Seats = 5,
                            HwyMpg = 31,
                            CtyMpg = 26,
                            Reviews = new List<CarReview>
                            {
                                new CarReview
                                {
                                    Title = "RANDOM",
                                    Message = "Some random stuff, this is mainly for testing so dont take it seriously. BLAH BLAH hehehe what the hell.",
                                     TimeCreated = DateTime.Now
                                },
                                new CarReview
                                {
                                    Title = "MORE",
                                    Message = "Some random stuff, this is mainly for testing so dont take it seriously. BLAH BLAH hehehe what the hell.",
                                     TimeCreated = DateTime.Now
                                },
                                new CarReview
                                {
                                    Title = "RANDOM",
                                    Message = "Some random stuff, this is mainly for testing so dont take it seriously. BLAH BLAH hehehe what the hell.",
                                     TimeCreated = DateTime.Now
                                },
                            },
                            Condition = "Great",
                            Transmission = "Automatic",
                            Description = "Some random stuff, this is mainly for testing so dont take it seriously. BLAH BLAH hehehe what the hell.",
                            CarRatings = new List<RatingCar>
                            {
                //                    new RatingCar
                //    {
                //        TireQuality = 2,
                //        OutsideCleanliness = 4,
                //        InsideCleanliness = 5,
                //        EngineOperation = 3,
                //        IndoorAirQuality = 3,
                //        SafetyFeatures = 5,
                //        ElectricalFunctions = 5,
                //        DeliveryExperience = 1,
                //        ProfessionalismOfOwner = 4,
                //        OverallRating = 4
                //    },

                //new RatingCar
                //{
                //    TireQuality = 3,
                //    OutsideCleanliness = 4,
                //    InsideCleanliness = 2,
                //    EngineOperation = 3,
                //    IndoorAirQuality = 2,
                //    SafetyFeatures = 4,
                //    ElectricalFunctions = 2,
                //    DeliveryExperience = 2,
                //    ProfessionalismOfOwner = 2,

                //},

                //new RatingCar
                //{
                //    TireQuality = 4,
                //    OutsideCleanliness = 5,
                //    InsideCleanliness = 2,
                //    EngineOperation = 3,
                //    IndoorAirQuality = 3,
                //    SafetyFeatures = 3,
                //    ElectricalFunctions = 4,
                //    DeliveryExperience = 3,
                //    ProfessionalismOfOwner = 3,

                //}
                }
                        },

                          new Car {

                            Year = 2016,
                            Make = "Toyota",
                            Model = "Corolla",
                            Price = 89m,
                            Door = 4,
                            Image = "https://www.filestackapi.com/api/file/j2hVGKZqQJvCdf0XqtfQ",
                            Miles = 2000,
                            Seats = 5,
                            HwyMpg = 31,
                            CtyMpg = 26,
                             Reviews = new List<CarReview>
                            {
                                new CarReview
                                {
                                    Title = "RANDOM",
                                    Message = "Some random stuff, this is mainly for testing so dont take it seriously. BLAH BLAH hehehe what the hell.",
                                     TimeCreated = DateTime.Now
                                },
                                new CarReview
                                {
                                    Title = "MORE",
                                    Message = "Some random stuff, this is mainly for testing so dont take it seriously. BLAH BLAH hehehe what the hell.",
                                     TimeCreated = DateTime.Now
                                },
                                new CarReview
                                {
                                    Title = "RANDOM",
                                    Message = "Some random stuff, this is mainly for testing so dont take it seriously. BLAH BLAH hehehe what the hell.",
                                     TimeCreated = DateTime.Now
                                },
                            },
                            Condition = "Excellent",
                            Transmission = "Automatic",
                            Description = "Some random stuff, this is mainly for testing so dont take it seriously. BLAH BLAH hehehe what the hell.",
                            CarRatings = new List<RatingCar>
                            {
                //                    new RatingCar
                //    {
                //        TireQuality = 2,
                //        OutsideCleanliness = 3,
                //        InsideCleanliness = 3,
                //        EngineOperation = 2,
                //        IndoorAirQuality = 3,
                //        SafetyFeatures = 5,
                //        ElectricalFunctions = 5,
                //        DeliveryExperience = 1,
                //        ProfessionalismOfOwner = 5,

                //    },

                //new RatingCar
                //{
                //    TireQuality = 3,
                //    OutsideCleanliness = 5,
                //    InsideCleanliness = 4,
                //    EngineOperation = 4,
                //    IndoorAirQuality = 2,
                //    SafetyFeatures = 3,
                //    ElectricalFunctions = 4,
                //    DeliveryExperience = 5,
                //    ProfessionalismOfOwner = 2,

                //},

                //new RatingCar
                //{
                //    TireQuality = 2,
                //    OutsideCleanliness = 4,
                //    InsideCleanliness = 5,
                //    EngineOperation = 4,
                //    IndoorAirQuality = 3,
                //    SafetyFeatures = 3,
                //    ElectricalFunctions = 4,
                //    DeliveryExperience = 5,
                //    ProfessionalismOfOwner = 3,

                //}
                }
                        },
                             new Car {

                            Year = 2012,
                            Make = "Hyundai",
                            Model = "Tiburon",
                            Price = 89m,
                            Door = 2,
                            Image = "https://www.filestackapi.com/api/file/BxLLo1oSM6QPZ0PpgrFQ",
                            Miles = 2000,
                            Seats = 4,
                            HwyMpg = 34,
                            CtyMpg = 27,

                            Condition = "Good",
                            Transmission = "Manual",
                            Description = "Some random stuff, this is mainly for testing so dont take it seriously. BLAH BLAH hehehe what the hell.",
                            Reviews = new List<CarReview>
                            {
                                 new CarReview
                                 {
                                      Title = "Decent",
                                       Message = "How nice!But I think it still can't beat spending time with rabbots who talk to the koalas!They are very hilarious!",
                                        TimeCreated = DateTime.Now
                                 },
                                     new CarReview
                                 {
                                      Title = "Decent",
                                       Message = "How nice!But I think it still can't beat spending time with rabbots who talk to the koalas!They are very hilarious!",
                                        TimeCreated = DateTime.Now
                                 },
                                         new CarReview
                                 {
                                      Title = "Decent",
                                       Message = "How nice!But I think it still can't beat spending time with rabbots who talk to the koalas!They are very hilarious!",
                                        TimeCreated = DateTime.Now
                                 },
                            },
                            CarRatings = new List<RatingCar>
                            {
                //                    new RatingCar
                //    {
                //        TireQuality = 2,
                //        OutsideCleanliness = 4,
                //        InsideCleanliness = 5,
                //        EngineOperation = 3,
                //        IndoorAirQuality = 3,
                //        SafetyFeatures = 5,
                //        ElectricalFunctions = 5,
                //        DeliveryExperience = 1,
                //        ProfessionalismOfOwner = 4,

                //    },

                //new RatingCar
                //{
                //    TireQuality = 3,
                //    OutsideCleanliness = 5,
                //    InsideCleanliness = 2,
                //    EngineOperation = 4,
                //    IndoorAirQuality = 2,
                //    SafetyFeatures = 4,
                //    ElectricalFunctions = 4,
                //    DeliveryExperience = 2,
                //    ProfessionalismOfOwner = 2,

                //},

                //new RatingCar
                //{
                //    TireQuality = 4,
                //    OutsideCleanliness = 5,
                //    InsideCleanliness = 1,
                //    EngineOperation = 3,
                //    IndoorAirQuality = 3,
                //    SafetyFeatures = 3,
                //    ElectricalFunctions = 4,
                //    DeliveryExperience = 5,
                //    ProfessionalismOfOwner = 5,

                //}
                }
                        }


                    },

                };
                await userManager.CreateAsync(caleb, "Secret123!");

                await userManager.AddClaimAsync(caleb, new Claim("IsLoaner", "true"));

            }

            var Cory = await userManager.FindByNameAsync("Cory@us.com");
            if (Cory == null)
            {
                // create user
                Cory = new ApplicationUser
                {
                    DriverRatings = new List<RatingDriver>
                        {
                            //new RatingDriver
                            //{
                            //     ConditionOfReturnedCar = 1,
                            //     PaymentExperience = 1,
                            //     ProfessionalismOfDriver = 1,
                            //     PromptReplies = 1,
                            //     SchedulingExperience = 1,
                            //     Trustworthiness = 1,
                            //     DeliveryExperience = 1
                            //},
                            //  new RatingDriver
                            //{
                            //     ConditionOfReturnedCar = 2,
                            //     PaymentExperience = 1,
                            //     ProfessionalismOfDriver =2,
                            //     PromptReplies = 1,
                            //     SchedulingExperience = 2,
                            //     Trustworthiness = 3,
                            //     DeliveryExperience = 2
                            //},
                            //    new RatingDriver
                            //{
                            //     ConditionOfReturnedCar = 2,
                            //     PaymentExperience = 3,
                            //     ProfessionalismOfDriver = 2,
                            //     PromptReplies = 3,
                            //     SchedulingExperience = 2,
                            //     Trustworthiness = 3,
                            //     DeliveryExperience = 3
                            //},
                            //      new RatingDriver
                            //{
                            //     ConditionOfReturnedCar = 2,
                            //     PaymentExperience = 3,
                            //     ProfessionalismOfDriver = 2,
                            //     PromptReplies = 2,
                            //     SchedulingExperience = 2,
                            //     Trustworthiness = 3,
                            //     DeliveryExperience = 2
                            //},
                        },
                    Reviews = new List<DriverReview>
                        {
                           new DriverReview
                           {
                                Title = "Syrup Is tasty",
                                Message = "Someone I know recently combined Maple Syrup & buttered Popcorn thinking it would taste like caramel popcorn. It didn’t and they don’t recommend anyone else do it either.",
                                TimeCreated = DateTime.Now
                           },
                           new DriverReview
                           {
                                Title = "Shmeagle",
                                Message = " I was very proud of my nickname throughout high school but today- I couldn’t be any different to what my nickname was.",
                                TimeCreated = DateTime.Now
                           },
                           new DriverReview
                           {
                                Title = "Easter is weird",
                                Message = "If the Easter Bunny and the Tooth Fairy had babies would they take your teeth and leave chocolate for you?",
                                TimeCreated = DateTime.Now
                           },
                        },
                    UserName = "cory@us.com",
                    Email = "cory@us.com",
                    FirstName = "Cory",
                    LastName = "Couty",
                    DisplayName = "Syncrose",
                    HasTheftInsurance = false,
                    HasDamageInsurance = false,
                    HasLicense = false,
                    IsLoaner = true,
                    Image = "https://plus.google.com/101603345753650624311/about?pid=5852505067492066914&oid=101603345753650624311",
                    CarsToLoan = new List<Car>
                    {

                        new Car {

                            Year = 2005,
                            Make = "Hyundai",
                            Model = "Tiburon",
                            Price = 45m,
                            Door = 2,
                            Image = "https://www.filestackapi.com/api/file/kOE3yg4nRsCuf8Qn0gAo",
                            Miles = 100157,
                            Seats = 4,
                            HwyMpg = 31,
                            CtyMpg = 25,
                            Reviews = new List<CarReview>
                            {
                                new CarReview
                                {
                                    Title = "RANDOM",
                                    Message = "Some random stuff, this is mainly for testing so dont take it seriously. BLAH BLAH hehehe what the hell.",
                                     TimeCreated = DateTime.Now
                                },
                                new CarReview
                                {
                                    Title = "MORE",
                                    Message = "Some random stuff, this is mainly for testing so dont take it seriously. BLAH BLAH hehehe what the hell.",
                                     TimeCreated = DateTime.Now
                                },
                                new CarReview
                                {
                                    Title = "RANDOM",
                                    Message = "Some random stuff, this is mainly for testing so dont take it seriously. BLAH BLAH hehehe what the hell.",
                                     TimeCreated = DateTime.Now
                                },
                            },
                            Condition = "Great",
                            Transmission = "Automatic",
                            Description = "Some random stuff, this is mainly for testing so dont take it seriously. BLAH BLAH hehehe what the hell.",
                            CarRatings = new List<RatingCar>
                            {
                //                    new RatingCar
                //    {
                //        TireQuality = 5,
                //        OutsideCleanliness = 3,
                //        InsideCleanliness = 1,
                //        EngineOperation = 4,
                //        IndoorAirQuality = 2,
                //        SafetyFeatures = 4,
                //        ElectricalFunctions = 3,
                //        DeliveryExperience = 1,
                //        ProfessionalismOfOwner = 1,

                //    },

                //new RatingCar
                //{
                //    TireQuality = 5,
                //    OutsideCleanliness = 2,
                //    InsideCleanliness = 1,
                //    EngineOperation = 3,
                //    IndoorAirQuality = 2,
                //    SafetyFeatures = 4,
                //    ElectricalFunctions = 2,
                //    DeliveryExperience = 2,
                //    ProfessionalismOfOwner = 2,

                //},

                //new RatingCar
                //{
                //    TireQuality = 4,
                //    OutsideCleanliness = 1,
                //    InsideCleanliness = 2,
                //    EngineOperation =4,
                //    IndoorAirQuality = 2,
                //    SafetyFeatures = 4,
                //    ElectricalFunctions = 2,
                //    DeliveryExperience = 1,
                //    ProfessionalismOfOwner = 1,

                //}
                }
                        },

                          new Car {

                            Year = 2014,
                            Make = "Toyota",
                            Model = "Corolla",
                            Price = 75m,
                            Door = 4,
                            Image = "https://www.filestackapi.com/api/file/agjE1iYzS5CrJN8ujCsG",
                            Miles = 6800,
                            Seats = 5,
                            HwyMpg = 28,
                            CtyMpg = 23,
                             Reviews = new List<CarReview>
                            {
                                new CarReview
                                {
                                    Title = "RANDOM",
                                    Message = "Some random stuff, this is mainly for testing so dont take it seriously. BLAH BLAH hehehe what the hell.",
                                     TimeCreated = DateTime.Now
                                },
                                new CarReview
                                {
                                    Title = "MORE",
                                    Message = "Some random stuff, this is mainly for testing so dont take it seriously. BLAH BLAH hehehe what the hell.",
                                     TimeCreated = DateTime.Now
                                },
                                new CarReview
                                {
                                    Title = "RANDOM",
                                    Message = "Some random stuff, this is mainly for testing so dont take it seriously. BLAH BLAH hehehe what the hell.",
                                     TimeCreated = DateTime.Now
                                },
                            },
                            Condition = "Excellent",
                            Transmission = "Automatic",
                            Description = "Some random stuff, this is mainly for testing so dont take it seriously. BLAH BLAH hehehe what the hell.",
                            CarRatings = new List<RatingCar>
                            {
                //                    new RatingCar
                //    {
                //        TireQuality = 4,
                //        OutsideCleanliness = 3,
                //        InsideCleanliness = 3,
                //        EngineOperation = 2,
                //        IndoorAirQuality = 3,
                //        SafetyFeatures = 5,
                //        ElectricalFunctions = 4,
                //        DeliveryExperience = 1,
                //        ProfessionalismOfOwner = 1,

                //    },

                //new RatingCar
                //{
                //    TireQuality = 4,
                //    OutsideCleanliness = 1,
                //    InsideCleanliness = 2,
                //    EngineOperation = 4,
                //    IndoorAirQuality = 2,
                //    SafetyFeatures = 3,
                //    ElectricalFunctions = 4,
                //    DeliveryExperience = 5,
                //    ProfessionalismOfOwner = 2,

                //},

                //new RatingCar
                //{
                //    TireQuality = 2,
                //    OutsideCleanliness = 4,
                //    InsideCleanliness = 5,
                //    EngineOperation = 4,
                //    IndoorAirQuality = 3,
                //    SafetyFeatures = 3,
                //    ElectricalFunctions = 4,
                //    DeliveryExperience = 5,
                //    ProfessionalismOfOwner = 3,

                //}
                }
                        },
                             new Car {

                            Year = 2016,
                            Make = "Chevrolet",
                            Model = "Corvette",
                            Price = 199.99m,
                            Door = 2,
                            Image = "https://www.filestackapi.com/api/file/0CqcMy0GTiu0u7Qw7u2N",
                            Miles = 1300,
                            Seats = 4,
                            HwyMpg = 21,
                            CtyMpg = 14,

                            Condition = "Good",
                            Transmission = "Manual",
                            Description = "Some random stuff, this is mainly for testing so dont take it seriously. BLAH BLAH hehehe what the hell.",
                            Reviews = new List<CarReview>
                            {
                                 new CarReview
                                 {
                                      Title = "Decent",
                                       Message = "How nice!But I think it still can't beat spending time with rabbots who talk to the koalas!They are very hilarious!",
                                        TimeCreated = DateTime.Now
                                 },
                                     new CarReview
                                 {
                                      Title = "Decent",
                                       Message = "How nice!But I think it still can't beat spending time with rabbots who talk to the koalas!They are very hilarious!",
                                        TimeCreated = DateTime.Now
                                 },
                                         new CarReview
                                 {
                                      Title = "Decent",
                                       Message = "How nice!But I think it still can't beat spending time with rabbots who talk to the koalas!They are very hilarious!",
                                        TimeCreated = DateTime.Now
                                 },
                            },
                            CarRatings = new List<RatingCar>
                            {
                //                    new RatingCar
                //    {
                //        TireQuality = 5,
                //        OutsideCleanliness = 5,
                //        InsideCleanliness = 5,
                //        EngineOperation = 5,
                //        IndoorAirQuality = 5,
                //        SafetyFeatures = 5,
                //        ElectricalFunctions = 5,
                //        DeliveryExperience = 1,
                //        ProfessionalismOfOwner = 2,

                //    },

                //new RatingCar
                //{
                //    TireQuality = 5,
                //    OutsideCleanliness = 5,
                //    InsideCleanliness = 5,
                //    EngineOperation = 5,
                //    IndoorAirQuality = 5,
                //    SafetyFeatures = 4,
                //    ElectricalFunctions = 4,
                //    DeliveryExperience = 2,
                //    ProfessionalismOfOwner = 2,

                //},

                //new RatingCar
                //{
                //    TireQuality = 5,
                //    OutsideCleanliness = 5,
                //    InsideCleanliness = 5,
                //    EngineOperation = 5,
                //    IndoorAirQuality = 3,
                //    SafetyFeatures = 2,
                //    ElectricalFunctions = 4,
                //    DeliveryExperience = 2,
                //    ProfessionalismOfOwner = 1,

                //}
                }
                        },

                              new Car {

                            Year = 2013,
                            Make = "Ford",
                            Model = "Mustang",
                            Price = 189.00m,
                            Door = 2,
                            Image = "http://blog.caranddriver.com/wp-content/uploads/2015/07/2015-Ford-Mustang-GT-Apollo-Edition-102-876x535.jpg",
                            Miles = 34000,
                            Seats = 4,
                            HwyMpg = 21,
                            CtyMpg = 15,

                            Condition = "Excellent",
                            Transmission = "Manual",
                            Description = "Some random stuff, this is mainly for testing so dont take it seriously. BLAH BLAH hehehe what the hell.",
                            Reviews = new List<CarReview>
                            {
                                 new CarReview
                                 {
                                      Title = "Decent",
                                       Message = "How nice!But I think it still can't beat spending time with rabbots who talk to the koalas!They are very hilarious!",
                                        TimeCreated = DateTime.Now
                                 },
                                     new CarReview
                                 {
                                      Title = "Decent",
                                       Message = "How nice!But I think it still can't beat spending time with rabbots who talk to the koalas!They are very hilarious!",
                                        TimeCreated = DateTime.Now
                                 },
                                         new CarReview
                                 {
                                      Title = "Decent",
                                       Message = "How nice!But I think it still can't beat spending time with rabbots who talk to the koalas!They are very hilarious!",
                                        TimeCreated = DateTime.Now
                                 },
                            },
                            CarRatings = new List<RatingCar>
                            {
                //                    new RatingCar
                //    {
                //        TireQuality = 5,
                //        OutsideCleanliness = 5,
                //        InsideCleanliness = 5,
                //        EngineOperation = 5,
                //        IndoorAirQuality = 5,
                //        SafetyFeatures = 5,
                //        ElectricalFunctions = 5,
                //        DeliveryExperience = 1,
                //        ProfessionalismOfOwner = 2,

                //    },

                //new RatingCar
                //{
                //    TireQuality = 5,
                //    OutsideCleanliness = 5,
                //    InsideCleanliness = 5,
                //    EngineOperation = 5,
                //    IndoorAirQuality = 5,
                //    SafetyFeatures = 4,
                //    ElectricalFunctions = 4,
                //    DeliveryExperience = 2,
                //    ProfessionalismOfOwner = 2,

                //},

                //new RatingCar
                //{
                //    TireQuality = 5,
                //    OutsideCleanliness = 5,
                //    InsideCleanliness = 5,
                //    EngineOperation = 5,
                //    IndoorAirQuality = 3,
                //    SafetyFeatures = 2,
                //    ElectricalFunctions = 4,
                //    DeliveryExperience = 2,
                //    ProfessionalismOfOwner = 1,

                //}
                }
                        }


                    },

                };
                await userManager.CreateAsync(Cory, "Secret123!");

                await userManager.AddClaimAsync(Cory, new Claim("IsLoaner", "true"));
                await userManager.AddClaimAsync(Cory, new Claim("IsAdmin", "true"));
            }


            var Morgan = await userManager.FindByNameAsync("Morgan@us.com");
            if (Morgan == null)
            {
                // create user
                Morgan = new ApplicationUser
                {
                    DriverRatings = new List<RatingDriver>
                        {
                            //new RatingDriver
                            //{
                            //     ConditionOfReturnedCar = 5,
                            //     PaymentExperience =4,
                            //     ProfessionalismOfDriver = 5,
                            //     PromptReplies = 5,
                            //     SchedulingExperience = 5,
                            //     Trustworthiness = 5,
                            //     DeliveryExperience = 4
                            //},
                            //  new RatingDriver
                            //{
                            //     ConditionOfReturnedCar = 5,
                            //     PaymentExperience = 4,
                            //     ProfessionalismOfDriver =5,
                            //     PromptReplies = 5,
                            //     SchedulingExperience = 5,
                            //     Trustworthiness = 5,
                            //     DeliveryExperience = 4
                            //},
                            //    new RatingDriver
                            //{
                            //     ConditionOfReturnedCar = 5,
                            //     PaymentExperience = 5,
                            //     ProfessionalismOfDriver = 5,
                            //     PromptReplies = 5,
                            //     SchedulingExperience = 5,
                            //     Trustworthiness = 4,
                            //     DeliveryExperience = 5
                            //},
                            //      new RatingDriver
                            //{
                            //     ConditionOfReturnedCar = 5,
                            //     PaymentExperience = 5,
                            //     ProfessionalismOfDriver = 5,
                            //     PromptReplies = 4,
                            //     SchedulingExperience = 4,
                            //     Trustworthiness = 4,
                            //     DeliveryExperience = 4
                            //},
                        },
                    Reviews = new List<DriverReview>
                        {
                           new DriverReview
                           {
                                Title = "Syrup Is tasty",
                                Message = "Someone I know recently combined Maple Syrup & buttered Popcorn thinking it would taste like caramel popcorn. It didn’t and they don’t recommend anyone else do it either.",
                                TimeCreated = DateTime.Now
                           },
                           new DriverReview
                           {
                                Title = "Shmeagle",
                                Message = " I was very proud of my nickname throughout high school but today- I couldn’t be any different to what my nickname was.",
                                TimeCreated = DateTime.Now
                           },
                           new DriverReview
                           {
                                Title = "Easter is weird",
                                Message = "If the Easter Bunny and the Tooth Fairy had babies would they take your teeth and leave chocolate for you?",
                                TimeCreated = DateTime.Now
                           },
                        },
                    UserName = "morgan@us.com",
                    Email = "morgan@us.com",
                    FirstName = "Morgan",
                    LastName = "Pylant",
                    DisplayName = "MPylant",
                    HasTheftInsurance = true,
                    HasDamageInsurance = true,
                    HasLicense = true,
                    IsLoaner = true,
                    Image = "https://pbs.twimg.com/profile_images/1777364406/profile.jpg",
                    CarsToLoan = new List<Car>
                    {
                                  new Car
                    {
                        Make = "Chevrolet ",
                        Model = "Corvette",
                        Year = 2014,
                        Image = "https://www.filestackapi.com/api/file/EdU1kfMaRhGz0OEs0RFT",
                        Door = 2,
                        Price = 155m,
                        IsActive = false
                    },

                    new Car
                    {
                        Make = "Honda ",
                        Model = "Pilot",
                        Year = 2014,
                        Image = "https://www.filestackapi.com/api/file/xJ8KjImR22slLbvyMlFw",
                        Door = 4,
                        Price = 130,
                        IsActive = true
                    },

                        new Car {

                            Year = 2015,
                            Make = "BMW",
                            Model = "M5",
                            Price = 165m,
                            Door = 4,
                            Image = "https://www.filestackapi.com/api/file/ilpklikMT5ilPp26ysjI",
                            Miles = 15000,
                            Seats = 5,
                            HwyMpg = 26,
                            CtyMpg = 21,
                            Reviews = new List<CarReview>
                            {
                                new CarReview
                                {
                                    Title = "RANDOM",
                                    Message = "Some random stuff, this is mainly for testing so dont take it seriously. BLAH BLAH hehehe what the hell.",
                                     TimeCreated = DateTime.Now
                                },
                                new CarReview
                                {
                                    Title = "MORE",
                                    Message = "Some random stuff, this is mainly for testing so dont take it seriously. BLAH BLAH hehehe what the hell.",
                                     TimeCreated = DateTime.Now
                                },
                                new CarReview
                                {
                                    Title = "RANDOM",
                                    Message = "Some random stuff, this is mainly for testing so dont take it seriously. BLAH BLAH hehehe what the hell.",
                                     TimeCreated = DateTime.Now
                                },
                            },
                            Condition = "Great",
                            Transmission = "Automatic",
                            Description = "Some random stuff, this is mainly for testing so dont take it seriously. BLAH BLAH hehehe what the hell.",
                            CarRatings = new List<RatingCar>
                            {
                //                    new RatingCar
                //    {
                //        TireQuality = 5,
                //        OutsideCleanliness = 5,
                //        InsideCleanliness = 4,
                //        EngineOperation = 5,
                //        IndoorAirQuality = 5,
                //        SafetyFeatures = 5,
                //        ElectricalFunctions = 4,
                //        DeliveryExperience = 4,
                //        ProfessionalismOfOwner = 5,

                //    },

                //new RatingCar
                //{
                //    TireQuality = 5,
                //    OutsideCleanliness = 4,
                //    InsideCleanliness = 4,
                //    EngineOperation = 5,
                //    IndoorAirQuality = 4,
                //    SafetyFeatures = 5,
                //    ElectricalFunctions = 5,
                //    DeliveryExperience = 5,
                //    ProfessionalismOfOwner = 5,

                //},

                //new RatingCar
                //{
                //    TireQuality = 4,
                //    OutsideCleanliness = 5,
                //    InsideCleanliness = 4,
                //    EngineOperation =4,
                //    IndoorAirQuality = 5,
                //    SafetyFeatures = 5,
                //    ElectricalFunctions = 4,
                //    DeliveryExperience = 4,
                //    ProfessionalismOfOwner = 4,

                //}
                }
                        },

                          new Car {

                            Year = 2014,
                            Make = "Mazda",
                            Model = "6",
                            Price = 95m,
                            Door = 4,
                            Image = "https://www.filestackapi.com/api/file/m3lUlQQTS4GcfVl4Bfvc",
                            Miles = 7500,
                            Seats = 5,
                            HwyMpg = 32,
                            CtyMpg = 28,
                             Reviews = new List<CarReview>
                            {
                                new CarReview
                                {
                                    Title = "RANDOM",
                                    Message = "Some random stuff, this is mainly for testing so dont take it seriously. BLAH BLAH hehehe what the hell.",
                                     TimeCreated = DateTime.Now
                                },
                                new CarReview
                                {
                                    Title = "MORE",
                                    Message = "Some random stuff, this is mainly for testing so dont take it seriously. BLAH BLAH hehehe what the hell.",
                                     TimeCreated = DateTime.Now
                                },
                                new CarReview
                                {
                                    Title = "RANDOM",
                                    Message = "Some random stuff, this is mainly for testing so dont take it seriously. BLAH BLAH hehehe what the hell.",
                                     TimeCreated = DateTime.Now
                                },
                            },
                            Condition = "Excellent",
                            Transmission = "Automatic",
                            Description = "Some random stuff, this is mainly for testing so dont take it seriously. BLAH BLAH hehehe what the hell.",
                            CarRatings = new List<RatingCar>
                            {
                //                    new RatingCar
                //    {
                //        TireQuality = 4,
                //        OutsideCleanliness = 4,
                //        InsideCleanliness = 4,
                //        EngineOperation = 4,
                //        IndoorAirQuality = 4,
                //        SafetyFeatures = 5,
                //        ElectricalFunctions = 3,
                //        DeliveryExperience = 4,
                //        ProfessionalismOfOwner = 5,

                //    },

                //new RatingCar
                //{
                //    TireQuality = 4,
                //    OutsideCleanliness = 4,
                //    InsideCleanliness = 4,
                //    EngineOperation = 4,
                //    IndoorAirQuality = 3,
                //    SafetyFeatures = 5,
                //    ElectricalFunctions = 4,
                //    DeliveryExperience = 5,
                //    ProfessionalismOfOwner = 4,

                //},

                //new RatingCar
                //{
                //    TireQuality = 4,
                //    OutsideCleanliness = 4,
                //    InsideCleanliness = 5,
                //    EngineOperation = 4,
                //    IndoorAirQuality = 4,
                //    SafetyFeatures = 4,
                //    ElectricalFunctions = 4,
                //    DeliveryExperience = 5,
                //    ProfessionalismOfOwner = 5,

                //}
                }
                        },
                             new Car {

                            Year = 2016,
                            Make = "Chevrolet",
                            Model = "Corvette",
                            Price = 199.99m,
                            Door = 2,
                            Image = "https://www.filestackapi.com/api/file/13qN0NoARJSKIOGzdZV8",
                            Miles = 1300,
                            Seats = 4,
                            HwyMpg = 21,
                            CtyMpg = 14,

                            Condition = "Good",
                            Transmission = "Manual",
                            Description = "Some random stuff, this is mainly for testing so dont take it seriously. BLAH BLAH hehehe what the hell.",
                            Reviews = new List<CarReview>
                            {
                                 new CarReview
                                 {
                                      Title = "Decent",
                                       Message = "How nice!But I think it still can't beat spending time with rabbots who talk to the koalas!They are very hilarious!",
                                        TimeCreated = DateTime.Now
                                 },
                                     new CarReview
                                 {
                                      Title = "Decent",
                                       Message = "How nice!But I think it still can't beat spending time with rabbots who talk to the koalas!They are very hilarious!",
                                        TimeCreated = DateTime.Now
                                 },
                                         new CarReview
                                 {
                                      Title = "Decent",
                                       Message = "How nice!But I think it still can't beat spending time with rabbots who talk to the koalas!They are very hilarious!",
                                        TimeCreated = DateTime.Now
                                 },
                            },
                            CarRatings = new List<RatingCar>
                            {
                //                    new RatingCar
                //    {
                //        TireQuality = 5,
                //        OutsideCleanliness = 5,
                //        InsideCleanliness = 5,
                //        EngineOperation = 5,
                //        IndoorAirQuality = 5,
                //        SafetyFeatures = 5,
                //        ElectricalFunctions = 5,
                //        DeliveryExperience = 1,
                //        ProfessionalismOfOwner = 2,

                //    },

                //new RatingCar
                //{
                //    TireQuality = 5,
                //    OutsideCleanliness = 5,
                //    InsideCleanliness = 5,
                //    EngineOperation = 5,
                //    IndoorAirQuality = 5,
                //    SafetyFeatures = 4,
                //    ElectricalFunctions = 4,
                //    DeliveryExperience = 4,
                //    ProfessionalismOfOwner = 5,

                //},

                //new RatingCar
                //{
                //    TireQuality = 5,
                //    OutsideCleanliness = 5,
                //    InsideCleanliness = 5,
                //    EngineOperation = 5,
                //    IndoorAirQuality = 3,
                //    SafetyFeatures = 2,
                //    ElectricalFunctions = 4,
                //    DeliveryExperience = 5,
                //    ProfessionalismOfOwner = 5,

                //}
                }
                        },

                           new Car {

                            Year = 2015,
                            Make = "Toyota",
                            Model = "Prius",
                            Price = 115.00m,
                            Door = 4,
                            Image = "http://blogs-images.forbes.com/tonybradley/files/2014/04/670px-toyota_prius_iii_20090710_front.jpg",
                            Miles = 23000,
                            Seats = 5,
                            HwyMpg = 57,
                            CtyMpg = 93,

                            Condition = "Great",
                            Transmission = "Automatic",
                            Description = "Some random stuff, this is mainly for testing so dont take it seriously. BLAH BLAH hehehe what the hell.",


                    },
                    }
                };
                await userManager.CreateAsync(Morgan, "Secret123!");

                await userManager.AddClaimAsync(Morgan, new Claim("IsLoaner", "true"));
                await userManager.AddClaimAsync(Morgan, new Claim("IsAdmin", "true"));
            }


            var Ayesha = await userManager.FindByNameAsync("Ayesha@us.com");
            if (Ayesha == null)
            {
                // create user
                Ayesha = new ApplicationUser
                {
                    DriverRatings = new List<RatingDriver>
                        {
                            //new RatingDriver
                            //{
                            //     ConditionOfReturnedCar = 5,
                            //     PaymentExperience =4,
                            //     ProfessionalismOfDriver = 5,
                            //     PromptReplies = 5,
                            //     SchedulingExperience = 5,
                            //     Trustworthiness = 5,
                            //     DeliveryExperience = 4
                            //},
                            //  new RatingDriver
                            //{
                            //     ConditionOfReturnedCar = 5,
                            //     PaymentExperience = 4,
                            //     ProfessionalismOfDriver =5,
                            //     PromptReplies = 5,
                            //     SchedulingExperience = 5,
                            //     Trustworthiness = 5,
                            //     DeliveryExperience = 4
                            //},
                            //    new RatingDriver
                            //{
                            //     ConditionOfReturnedCar = 5,
                            //     PaymentExperience = 5,
                            //     ProfessionalismOfDriver = 5,
                            //     PromptReplies = 5,
                            //     SchedulingExperience = 5,
                            //     Trustworthiness = 4,
                            //     DeliveryExperience = 5
                            //},
                            //      new RatingDriver
                            //{
                            //     ConditionOfReturnedCar = 5,
                            //     PaymentExperience = 5,
                            //     ProfessionalismOfDriver = 5,
                            //     PromptReplies = 4,
                            //     SchedulingExperience = 4,
                            //     Trustworthiness = 4,
                            //     DeliveryExperience = 4
                            //},
                        },
                    Reviews = new List<DriverReview>
                        {
                           new DriverReview
                           {
                                Title = "Syrup Is tasty",
                                Message = "Someone I know recently combined Maple Syrup & buttered Popcorn thinking it would taste like caramel popcorn. It didn’t and they don’t recommend anyone else do it either.",
                                TimeCreated = DateTime.Now
                           },
                           new DriverReview
                           {
                                Title = "Shmeagle",
                                Message = " I was very proud of my nickname throughout high school but today- I couldn’t be any different to what my nickname was.",
                                TimeCreated = DateTime.Now
                           },
                           new DriverReview
                           {
                                Title = "Easter is weird",
                                Message = "If the Easter Bunny and the Tooth Fairy had babies would they take your teeth and leave chocolate for you?",
                                TimeCreated = DateTime.Now
                           },
                        },
                    UserName = "ayesha@us.com",
                    Email = "ayesha@us.com",
                    FirstName = "Ayesha",
                    LastName = "Shaikh",
                    DisplayName = "AyeshaSH",
                    HasTheftInsurance = true,
                    HasDamageInsurance = true,
                    HasLicense = true,
                    IsLoaner = true,
                    Image = "https://pbs.twimg.com/profile_images/1777364406/profile.jpg",
                    CarsToLoan = new List<Car>
                    {

                        new Car {

                            Year = 2015,
                            Make = "BMW",
                            Model = "335I",
                            Price = 175m,
                            Door = 4,
                            Image = "https://www.filestackapi.com/api/file/lwkSy8JHTNyf9D5QgXsL",
                            Miles = 32000,
                            Seats = 5,
                            HwyMpg = 25,
                            CtyMpg = 20,
                            Reviews = new List<CarReview>
                            {
                                new CarReview
                                {
                                    Title = "RANDOM",
                                    Message = "Some random stuff, this is mainly for testing so dont take it seriously. BLAH BLAH hehehe what the hell.",
                                     TimeCreated = DateTime.Now
                                },
                                new CarReview
                                {
                                    Title = "MORE",
                                    Message = "Some random stuff, this is mainly for testing so dont take it seriously. BLAH BLAH hehehe what the hell.",
                                     TimeCreated = DateTime.Now
                                },
                                new CarReview
                                {
                                    Title = "RANDOM",
                                    Message = "Some random stuff, this is mainly for testing so dont take it seriously. BLAH BLAH hehehe what the hell.",
                                     TimeCreated = DateTime.Now
                                },
                            },
                            Condition = "Great",
                            Transmission = "Automatic",
                            Description = "Some random stuff, this is mainly for testing so dont take it seriously. BLAH BLAH hehehe what the hell.",
                            CarRatings = new List<RatingCar>
                            {
                //                    new RatingCar
                //    {
                //        TireQuality = 5,
                //        OutsideCleanliness = 5,
                //        InsideCleanliness = 4,
                //        EngineOperation = 5,
                //        IndoorAirQuality = 5,
                //        SafetyFeatures = 5,
                //        ElectricalFunctions = 4,
                //        DeliveryExperience = 4,
                //        ProfessionalismOfOwner = 5,

                //    },

                //new RatingCar
                //{
                //    TireQuality = 5,
                //    OutsideCleanliness = 4,
                //    InsideCleanliness = 4,
                //    EngineOperation = 4,
                //    IndoorAirQuality = 4,
                //    SafetyFeatures = 5,
                //    ElectricalFunctions = 5,
                //    DeliveryExperience = 4,
                //    ProfessionalismOfOwner = 5,

                //},

                //new RatingCar
                //{
                //    TireQuality = 4,
                //    OutsideCleanliness = 5,
                //    InsideCleanliness = 4,
                //    EngineOperation =4,
                //    IndoorAirQuality = 5,
                //    SafetyFeatures = 5,
                //    ElectricalFunctions = 5,
                //    DeliveryExperience = 4,
                //    ProfessionalismOfOwner = 5,

                //}
                }
                        },

                          new Car {

                            Year = 2012,
                            Make = "Maserati",
                            Model = "Granturismo",
                            Price = 95m,
                            Door = 4,
                            Image = "https://www.filestackapi.com/api/file/jXpehPlzQrKzcISOJkTi",
                            Miles = 47000,
                            Seats = 4,
                            HwyMpg = 22,
                            CtyMpg = 18,
                             Reviews = new List<CarReview>
                            {
                                new CarReview
                                {
                                    Title = "RANDOM",
                                    Message = "Some random stuff, this is mainly for testing so dont take it seriously. BLAH BLAH hehehe what the hell.",
                                     TimeCreated = DateTime.Now
                                },
                                new CarReview
                                {
                                    Title = "MORE",
                                    Message = "Some random stuff, this is mainly for testing so dont take it seriously. BLAH BLAH hehehe what the hell.",
                                     TimeCreated = DateTime.Now
                                },
                                new CarReview
                                {
                                    Title = "RANDOM",
                                    Message = "Some random stuff, this is mainly for testing so dont take it seriously. BLAH BLAH hehehe what the hell.",
                                     TimeCreated = DateTime.Now
                                },
                            },
                            Condition = "Excellent",
                            Transmission = "Automatic",
                            Description = "Some random stuff, this is mainly for testing so dont take it seriously. BLAH BLAH hehehe what the hell.",
                            CarRatings = new List<RatingCar>
                            {
                //                    new RatingCar
                //    {
                //        TireQuality = 4,
                //        OutsideCleanliness = 4,
                //        InsideCleanliness = 4,
                //        EngineOperation = 4,
                //        IndoorAirQuality = 4,
                //        SafetyFeatures = 5,
                //        ElectricalFunctions =5,
                //        DeliveryExperience = 4,
                //        ProfessionalismOfOwner = 4,

                //    },

                //new RatingCar
                //{
                //    TireQuality = 4,
                //    OutsideCleanliness = 4,
                //    InsideCleanliness = 4,
                //    EngineOperation = 4,
                //    IndoorAirQuality = 4,
                //    SafetyFeatures = 5,
                //    ElectricalFunctions = 5,
                //    DeliveryExperience = 5,
                //    ProfessionalismOfOwner = 4,

                //},

                //new RatingCar
                //{
                //    TireQuality = 4,
                //    OutsideCleanliness = 4,
                //    InsideCleanliness = 3,
                //    EngineOperation = 4,
                //    IndoorAirQuality = 4,
                //    SafetyFeatures = 4,
                //    ElectricalFunctions = 4,
                //    DeliveryExperience = 4,
                //    ProfessionalismOfOwner = 5,

                //}
                }
                        },
                             new Car {

                            Year = 2016,
                            Make = "Tesla",
                            Model = "Model X",
                            Price = 199.99m,
                            Door = 2,
                            Image = "https://www.filestackapi.com/api/file/zwbJN4URb2nznKSy9EWR",
                            Miles = 600,
                            Seats = 7,
                            HwyMpg = 0,
                            CtyMpg = 0,

                            Condition = "Good",
                            Transmission = "Manual",
                            Description = "Some random stuff, this is mainly for testing so dont take it seriously. BLAH BLAH hehehe what the hell.",
                            Reviews = new List<CarReview>
                            {
                                 new CarReview
                                 {
                                      Title = "Decent",
                                       Message = "How nice!But I think it still can't beat spending time with rabbots who talk to the koalas!They are very hilarious!",
                                        TimeCreated = DateTime.Now
                                 },
                                     new CarReview
                                 {
                                      Title = "Decent",
                                       Message = "How nice!But I think it still can't beat spending time with rabbots who talk to the koalas!They are very hilarious!",
                                        TimeCreated = DateTime.Now
                                 },
                                         new CarReview
                                 {
                                      Title = "Decent",
                                       Message = "How nice!But I think it still can't beat spending time with rabbots who talk to the koalas!They are very hilarious!",
                                        TimeCreated = DateTime.Now
                                 },
                            },
                            CarRatings = new List<RatingCar>
                            {
                //                    new RatingCar
                //    {
                //        TireQuality = 5,
                //        OutsideCleanliness = 5,
                //        InsideCleanliness = 5,
                //        EngineOperation = 5,
                //        IndoorAirQuality = 5,
                //        SafetyFeatures = 5,
                //        ElectricalFunctions = 5,
                //        DeliveryExperience = 5,
                //        ProfessionalismOfOwner = 5,

                //    },

                //new RatingCar
                //{
                //    TireQuality = 5,
                //    OutsideCleanliness = 5,
                //    InsideCleanliness = 5,
                //    EngineOperation = 5,
                //    IndoorAirQuality = 5,
                //    SafetyFeatures = 4,
                //    ElectricalFunctions = 4,
                //    DeliveryExperience = 4,
                //    ProfessionalismOfOwner = 5,

                //},

                //new RatingCar
                //{
                //    TireQuality = 5,
                //    OutsideCleanliness = 5,
                //    InsideCleanliness = 5,
                //    EngineOperation = 5,
                //    IndoorAirQuality = 5,
                //    SafetyFeatures = 5,
                //    ElectricalFunctions = 4,
                //    DeliveryExperience = 5,
                //    ProfessionalismOfOwner = 4,

                //}
                }
                        },
                              new Car {

                            Year = 2007,
                            Make = "Kia",
                            Model = "Optima",
                            Price = 75.50m,
                            Door = 4,
                            Image = "http://carphotos.cardomain.com/ride_images/3/3447/2761/33616380014_original.jpg",
                            Miles = 67500,
                            Seats = 5,
                            HwyMpg = 30,
                            CtyMpg = 26,

                            Condition = "Good",
                            Transmission = "Automatic",
                            Description = "Some random stuff, this is mainly for testing so dont take it seriously. BLAH BLAH hehehe what the hell.",
                              }


                    },

                };
                await userManager.CreateAsync(Ayesha, "Secret123!");

                await userManager.AddClaimAsync(Ayesha, new Claim("IsLoaner", "true"));
                await userManager.AddClaimAsync(Ayesha, new Claim("IsAdmin", "true"));
            }


            //var Jason = await userManager.FindByNameAsync("moose2727@hotmail.com");
            //if (Jason == null)
            //{
            //    // create user
            //    Jason = new ApplicationUser
            //    {
            //        UserName = "moose2727@hotmail.com",
            //        Email = "moose2727@hotmail.com",
            //        FirstName = "Jason",
            //        LastName = "deNevers",
            //        DisplayName = "Moose2727",
            //        HasTheftInsurance = true,
            //        HasDamageInsurance = true,
            //        HasLicense = true,
            //        IsLoaner = true,
            //        IsAdmin = true,
            //        CarsToLoan = new List<Car>
            //        {
            //            new Car
            //            {
            //                UserId = Jason.Id,
            //                Year = 2005,
            //                Make = "Honda",
            //                Model = "Accord",
            //                Price = 110m,
            //                Door = 4,
            //                Image = "http://s1.cdn.autoevolution.com/images/gallery/HONDAAccordSedanUS-4220_10.jpg"
            //            }
            //        }
            //    };
            //    await userManager.CreateAsync(Jason, "Secret123!");
            //    await userManager.AddClaimAsync(Jason, new Claim("IsAdmin", "true"));
            //    await userManager.AddClaimAsync(Jason, new Claim("IsLoaner", "true"));

            //},


            var Jason = await userManager.FindByNameAsync("Moose2727@hotmail.com");
            if (Jason == null)
            {
                // create user
                Jason = new ApplicationUser
                {
                    DriverRatings = new List<RatingDriver>
                        {
                            //new RatingDriver
                            //{
                            //     ConditionOfReturnedCar = 5,
                            //     PaymentExperience =4,
                            //     ProfessionalismOfDriver = 5,
                            //     PromptReplies = 5,
                            //     SchedulingExperience = 5,
                            //     Trustworthiness = 5,
                            //     DeliveryExperience = 4
                            //},
                            //  new RatingDriver
                            //{
                            //     ConditionOfReturnedCar = 5,
                            //     PaymentExperience = 4,
                            //     ProfessionalismOfDriver =5,
                            //     PromptReplies = 5,
                            //     SchedulingExperience = 5,
                            //     Trustworthiness = 5,
                            //     DeliveryExperience = 4
                            //},
                            //    new RatingDriver
                            //{
                            //     ConditionOfReturnedCar = 5,
                            //     PaymentExperience = 5,
                            //     ProfessionalismOfDriver = 5,
                            //     PromptReplies = 5,
                            //     SchedulingExperience = 5,
                            //     Trustworthiness = 4,
                            //     DeliveryExperience = 5
                            //},
                            //      new RatingDriver
                            //{
                            //     ConditionOfReturnedCar = 5,
                            //     PaymentExperience = 5,
                            //     ProfessionalismOfDriver = 5,
                            //     PromptReplies = 4,
                            //     SchedulingExperience = 4,
                            //     Trustworthiness = 4,
                            //     DeliveryExperience = 4
                            //},
                        },
                    Reviews = new List<DriverReview>
                        {
                           new DriverReview
                           {
                                Title = "Syrup Is tasty",
                                Message = "Someone I know recently combined Maple Syrup & buttered Popcorn thinking it would taste like caramel popcorn. It didn’t and they don’t recommend anyone else do it either.",
                                TimeCreated = DateTime.Now
                           },
                           new DriverReview
                           {
                                Title = "Shmeagle",
                                Message = " I was very proud of my nickname throughout high school but today- I couldn’t be any different to what my nickname was.",
                                TimeCreated = DateTime.Now
                           },
                           new DriverReview
                           {
                                Title = "Easter is weird",
                                Message = "If the Easter Bunny and the Tooth Fairy had babies would they take your teeth and leave chocolate for you?",
                                TimeCreated = DateTime.Now
                           },
                        },
                    UserName = "moose2727@hotmail.com",
                    Email = "moose2727@hotmail.com",
                    FirstName = "Jason",
                    LastName = "Denevers",
                    DisplayName = "Moose2727",
                    HasTheftInsurance = true,
                    HasDamageInsurance = true,
                    HasLicense = true,
                    IsLoaner = true,
                    Image = "https://pbs.twimg.com/profile_images/1777364406/profile.jpg",
                    CarsToLoan = new List<Car>
                    {

                        new Car {

                            Year = 2015,
                            Make = "Jeep",
                            Model = "Wrangler",
                            Price = 113m,
                            Door = 2,
                            Image = "https://www.filestackapi.com/api/file/u2TCZtdwQaGNTZrAD9Mo",
                            Miles = 46000,
                            Seats = 4,
                            HwyMpg = 21,
                            CtyMpg = 19,
                            Reviews = new List<CarReview>
                            {
                                new CarReview
                                {
                                    Title = "RANDOM",
                                    Message = "Some random stuff, this is mainly for testing so dont take it seriously. BLAH BLAH hehehe what the hell.",
                                     TimeCreated = DateTime.Now
                                },
                                new CarReview
                                {
                                    Title = "MORE",
                                    Message = "Some random stuff, this is mainly for testing so dont take it seriously. BLAH BLAH hehehe what the hell.",
                                     TimeCreated = DateTime.Now
                                },
                                new CarReview
                                {
                                    Title = "RANDOM",
                                    Message = "Some random stuff, this is mainly for testing so dont take it seriously. BLAH BLAH hehehe what the hell.",
                                     TimeCreated = DateTime.Now
                                },
                            },
                            Condition = "Excellent",
                            Transmission = "Manual",
                            Description = "Some random stuff, this is mainly for testing so dont take it seriously. BLAH BLAH hehehe what the hell.",
                            CarRatings = new List<RatingCar>
                            {
                //                    new RatingCar
                //    {
                //        TireQuality = 5,
                //        OutsideCleanliness = 5,
                //        InsideCleanliness = 4,
                //        EngineOperation = 5,
                //        IndoorAirQuality = 5,
                //        SafetyFeatures = 5,
                //        ElectricalFunctions = 4,
                //        DeliveryExperience = 4,
                //        ProfessionalismOfOwner = 5,

                //    },

                //new RatingCar
                //{
                //    TireQuality = 5,
                //    OutsideCleanliness = 4,
                //    InsideCleanliness = 4,
                //    EngineOperation = 3,
                //    IndoorAirQuality = 4,
                //    SafetyFeatures = 2,
                //    ElectricalFunctions = 5,
                //    DeliveryExperience = 4,
                //    ProfessionalismOfOwner = 5,

                //},

                //new RatingCar
                //{
                //    TireQuality = 4,
                //    OutsideCleanliness = 5,
                //    InsideCleanliness = 4,
                //    EngineOperation =4,
                //    IndoorAirQuality = 5,
                //    SafetyFeatures = 1,
                //    ElectricalFunctions = 5,
                //    DeliveryExperience = 4,
                //    ProfessionalismOfOwner = 5,

                //}
                }
                        },

                          new Car {

                            Year = 2013,
                            Make = "Honda",
                            Model = "Accord",
                            Price = 95m,
                            Door = 4,
                            Image = "https://www.filestackapi.com/api/file/jWKp4ClSYWpV6S2Ula56",
                            Miles = 23000,
                            Seats = 5,
                            HwyMpg = 35,
                            CtyMpg = 28,
                             Reviews = new List<CarReview>
                            {
                                new CarReview
                                {
                                    Title = "RANDOM",
                                    Message = "Some random stuff, this is mainly for testing so dont take it seriously. BLAH BLAH hehehe what the hell.",
                                     TimeCreated = DateTime.Now
                                },
                                new CarReview
                                {
                                    Title = "MORE",
                                    Message = "Some random stuff, this is mainly for testing so dont take it seriously. BLAH BLAH hehehe what the hell.",
                                     TimeCreated = DateTime.Now
                                },
                                new CarReview
                                {
                                    Title = "RANDOM",
                                    Message = "Some random stuff, this is mainly for testing so dont take it seriously. BLAH BLAH hehehe what the hell.",
                                     TimeCreated = DateTime.Now
                                },
                            },
                            Condition = "Excellent",
                            Transmission = "Automatic",
                            Description = "Some random stuff, this is mainly for testing so dont take it seriously. BLAH BLAH hehehe what the hell.",
                            CarRatings = new List<RatingCar>
                            {
                //                    new RatingCar
                //    {
                //        TireQuality = 4,
                //        OutsideCleanliness = 4,
                //        InsideCleanliness = 4,
                //        EngineOperation = 4,
                //        IndoorAirQuality = 4,
                //        SafetyFeatures = 5,
                //        ElectricalFunctions =5,
                //        DeliveryExperience = 4,
                //        ProfessionalismOfOwner = 4,

                //    },

                //new RatingCar
                //{
                //    TireQuality = 4,
                //    OutsideCleanliness = 4,
                //    InsideCleanliness = 4,
                //    EngineOperation = 4,
                //    IndoorAirQuality = 4,
                //    SafetyFeatures = 5,
                //    ElectricalFunctions = 5,
                //    DeliveryExperience = 5,
                //    ProfessionalismOfOwner = 4,

                //},

                //new RatingCar
                //{
                //    TireQuality = 4,
                //    OutsideCleanliness = 4,
                //    InsideCleanliness = 3,
                //    EngineOperation = 4,
                //    IndoorAirQuality = 4,
                //    SafetyFeatures = 4,
                //    ElectricalFunctions = 4,
                //    DeliveryExperience = 4,
                //    ProfessionalismOfOwner = 5,

                //}
                }
                        },
                             new Car {

                            Year = 2016,
                            Make = "Mazda",
                            Model = "MX-5 Miata",
                            Price = 199.99m,
                            Door = 2,
                            Image = "https://www.filestackapi.com/api/file/7oWVVomgRIqhjTVpBD3u",
                            Miles = 600,
                            Seats = 7,
                            HwyMpg = 25,
                            CtyMpg = 22,

                            Condition = "Good",
                            Transmission = "Manual",
                            Description = "Some random stuff, this is mainly for testing so dont take it seriously. BLAH BLAH hehehe what the hell.",
                            Reviews = new List<CarReview>
                            {
                                 new CarReview
                                 {
                                      Title = "Decent",
                                       Message = "How nice!But I think it still can't beat spending time with rabbots who talk to the koalas!They are very hilarious!",
                                        TimeCreated = DateTime.Now
                                 },
                                     new CarReview
                                 {
                                      Title = "Decent",
                                       Message = "How nice!But I think it still can't beat spending time with rabbots who talk to the koalas!They are very hilarious!",
                                        TimeCreated = DateTime.Now
                                 },
                                         new CarReview
                                 {
                                      Title = "Decent",
                                       Message = "How nice!But I think it still can't beat spending time with rabbots who talk to the koalas!They are very hilarious!",
                                        TimeCreated = DateTime.Now
                                 },
                            },
                            CarRatings = new List<RatingCar>
                            {
                //                    new RatingCar
                //    {
                //        TireQuality = 5,
                //        OutsideCleanliness = 5,
                //        InsideCleanliness = 5,
                //        EngineOperation = 5,
                //        IndoorAirQuality = 5,
                //        SafetyFeatures = 5,
                //        ElectricalFunctions = 5,
                //        DeliveryExperience = 5,
                //        ProfessionalismOfOwner = 5,

                //    },

                //new RatingCar
                //{
                //    TireQuality = 5,
                //    OutsideCleanliness = 5,
                //    InsideCleanliness = 5,
                //    EngineOperation = 5,
                //    IndoorAirQuality = 5,
                //    SafetyFeatures = 4,
                //    ElectricalFunctions = 4,
                //    DeliveryExperience = 4,
                //    ProfessionalismOfOwner = 5,

                //},

                //new RatingCar
                //{
                //    TireQuality = 5,
                //    OutsideCleanliness = 5,
                //    InsideCleanliness = 5,
                //    EngineOperation = 5,
                //    IndoorAirQuality = 5,
                //    SafetyFeatures = 5,
                //    ElectricalFunctions = 4,
                //    DeliveryExperience = 5,
                //    ProfessionalismOfOwner = 4,

                //}
                }
                        },

                             new Car {

                            Year = 2011,
                            Make = "Mercedes",
                            Model = "SLR Mclaren",
                            Price = 349.50m,
                            Door = 2,
                            Image = "http://www.motoringexposure.com/wp-content/gallery/wheelsandmore-mercedes-benz-slr-mclaren-707-edition/mercedes_felgen_slr_wheels_722.jpg",
                            Miles = 17000,
                            Seats = 2,
                            HwyMpg = 21,
                            CtyMpg = 18,

                            Condition = "Excellent",
                            Transmission = "Manual",
                            Description = "Some random stuff, this is mainly for testing so dont take it seriously. BLAH BLAH hehehe what the hell.",
                             }


                    },

                };
                await userManager.CreateAsync(Jason, "Secret123!");

                await userManager.AddClaimAsync(Jason, new Claim("IsLoaner", "true"));
                await userManager.AddClaimAsync(Jason, new Claim("IsAdmin", "true"));
            }

        }

    }
}
