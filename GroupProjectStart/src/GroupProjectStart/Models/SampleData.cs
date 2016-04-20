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
            if (!db.Cars.Any())
            {
                db.Cars.AddRange(
                    new Car
                    {
                        Make = " Volvo",
                        Model = "XC90",
                        Year = 2015,
                        Image = "http://topcarsreleasedates.com/wp-content/uploads/2015/08/2016-volvo-xc90-.jpg",
                        Door = 4,
                        Price = 132m
                    },

                    new Car
                    {
                        Make = " Mazda",
                        Model = " MX-5 Miata",
                        Year = 2016,
                        Image = "http://2.bp.blogspot.com/-lndOWG_WqsE/Ug3fiHidR8I/AAAAAAAAH3o/-LOSoELV-6w/s1600/2015-MG-Roadster-52.jpg",
                        Door = 2,
                        Price = 124m
                    },

                    new Car
                    {
                        Make = "Chevrolet ",
                        Model = "Corvette",
                        Year = 2014,
                        Image = "http://s3.amazonaws.com/fzautomotive/dealers/55b6d6e755b30.png",
                        Door = 2,
                        Price = 155m
                    },

                    new Car
                    {
                        Make = "Honda ",
                        Model = "Pilot",
                        Year = 2014,
                        Image = "http://static4.consumerreportscdn.org/content/dam/cro/magazine-articles/2015/December/CR122K15-Honda_Pilot_16_2917_Right.jpg",
                        Door = 4,
                        Price = 130
                    }
                );
                db.SaveChanges();
            }


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
                    Email = "Stephen.Walther@CoderCamps.com"
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
                    Email = "Mike@CoderCamps.com"
                };
                await userManager.CreateAsync(mike, "Secret123!");
            }

            var scott = await userManager.FindByNameAsync("Scott@Something.com");
            if (scott == null)
            {
                // create user
                scott = new ApplicationUser
                {
                    UserName = "Scott@Something.com",
                    Email = "Scott@Something.com",
                    FirstName = "Scott",
                    LastName = "Stewart",
                    DisplayName = "ScottStew",
                    HasLicense = true,
                    HasDamageInsurance = true
                };
                await userManager.CreateAsync(scott, "Secret123!");

            }

            var ryan = await userManager.FindByNameAsync("Ryan@Something.com");
            if (ryan == null)
            {
                // create user
                ryan = new ApplicationUser
                {
                    UserName = "Ryan@Something.com",
                    Email = "Ryan@Something.com",
                    FirstName = "Ryan",
                    LastName = "Richardson",
                    DisplayName = "RyanR27",
                    HasLicense = true,
                    HasDamageInsurance = false,
                    
                };
                await userManager.CreateAsync(ryan, "Secret123!");

            }

            var Caleb = await userManager.FindByNameAsync("Caleb@Something.com");
            if (Caleb == null)
            {
                // create user
                Caleb = new Loaner
                {
                    UserName = "Caleb@Something.com",
                    Email = "Caleb@Something.com",
                    FirstName = "Caleb",
                    LastName = "Schwarzmiller",
                    DisplayName = "CSchwarz",
                    HasTheftInsurance = true,
                    HasDamageInsurance = true,
                    HasLicense = true,
                    IsLoaner = true,
                    CarsToLoan = new List<Car>
                    {
                        new Car {
                            Year = 2009,
                            Make = "Hyundai",
                            Model = "Santa Fe",
                            Price = 125m,
                            Door = 4,
                            Image = "http://static.cargurus.com/images/site/2008/09/03/14/38/2009_hyundai_santa_fe-pic-1544-640x480.jpeg"
                        }
                    }
                };
                await userManager.CreateAsync(Caleb, "Secret123!");

            }

            var John = await userManager.FindByNameAsync("John@Something.com");
            if (John == null)
            {
                // create user
                John = new Loaner
                {
                    UserName = "John@Something.com",
                    Email = "John@Something.com",
                    FirstName = "John",
                    LastName = "Doe",
                    DisplayName = "JDoe",
                    HasTheftInsurance = false,
                    HasDamageInsurance = false,
                    HasLicense = false,
                    IsLoaner = false,
                    CarsToLoan = new List<Car>
                    {
                        new Car
                        {
                            Year = 2005,
                            Make = "Honda",
                            Model = "Accord",
                            Price = 110m,
                            Door = 4,
                            Image = "http://s1.cdn.autoevolution.com/images/gallery/HONDAAccordSedanUS-4220_10.jpg"
                        }

                    }
                };
                await userManager.CreateAsync(John, "Secret123!");

            }

        }

    }
}
