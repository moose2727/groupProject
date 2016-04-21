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
                        Make = "Volvo",
                        Model = "XC90",
                        Year = 2015,
                        Image = "http://topcarsreleasedates.com/wp-content/uploads/2015/08/2016-volvo-xc90-.jpg",
                        Door = 4,
                        Price = 132m,
                        IsActive = false,
                        
                    },

                    new Car
                    {
                        Make = "Mazda",
                        Model = " MX-5 Miata",
                        Year = 2016,
                        Image = "http://2.bp.blogspot.com/-lndOWG_WqsE/Ug3fiHidR8I/AAAAAAAAH3o/-LOSoELV-6w/s1600/2015-MG-Roadster-52.jpg",
                        Door = 2,
                        Price = 124m,
                        IsActive = true

                    },

                    new Car
                    {
                        Make = "Chevrolet ",
                        Model = "Corvette",
                        Year = 2014,
                        Image = "http://s3.amazonaws.com/fzautomotive/dealers/55b6d6e755b30.png",
                        Door = 2,
                        Price = 155m,
                        IsActive = false
                    },

                    new Car
                    {
                        Make = "Honda ",
                        Model = "Pilot",
                        Year = 2014,
                        Image = "http://static4.consumerreportscdn.org/content/dam/cro/magazine-articles/2015/December/CR122K15-Honda_Pilot_16_2917_Right.jpg",
                        Door = 4,
                        Price = 130,
                        IsActive = true
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
                    Image = "http://e2ua.com/WDF-1048495.html"
                    
                };
                await userManager.CreateAsync(ryan, "Secret123!");

            }

            var Caleb = await userManager.FindByNameAsync("Caleb@Something.com");
            if (Caleb == null)
            {
                // create user
                Caleb = new ApplicationUser
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
                       db.Cars.FirstOrDefault( c => c.Make == "Mazda")
                        //new Car {
                        //    UserId = Caleb.Id,
                        //    Year = 2009,
                        //    Make = "Hyundai",
                        //    Model = "Santa Fe",
                        //    Price = 125m,
                        //    Door = 4,
                        //    Image = "http://static.cargurus.com/images/site/2008/09/03/14/38/2009_hyundai_santa_fe-pic-1544-640x480.jpeg"
                        //}
                    }
                };
                await userManager.CreateAsync(Caleb, "Secret123!");

                await userManager.AddClaimAsync(Caleb, new Claim("IsLoaner", "true"));

            }


            var Jason = await userManager.FindByNameAsync("moose2727@hotmail.com");
            if (Jason == null)
            {
                // create user
                Jason = new ApplicationUser
                {
                    UserName = "moose2727@hotmail.com",
                    Email = "moose2727@hotmail.com",
                    FirstName = "Jason",
                    LastName = "deNevers",
                    DisplayName = "Moose2727",
                    HasTheftInsurance = true,
                    HasDamageInsurance = true,
                    HasLicense = true,
                    IsLoaner = true,
                    IsAdmin = true,
                    CarsToLoan = new List<Car>
                    {
                        //new Car
                        //{
                        //    UserId = Jason.Id,
                        //    Year = 2005,
                        //    Make = "Honda",
                        //    Model = "Accord",
                        //    Price = 110m,
                        //    Door = 4,
                        //    Image = "http://s1.cdn.autoevolution.com/images/gallery/HONDAAccordSedanUS-4220_10.jpg"
                        //}
                    }
                };
                await userManager.CreateAsync(Jason, "Secret123!");
                await userManager.AddClaimAsync(Jason, new Claim("IsAdmin", "true"));
                await userManager.AddClaimAsync(Jason, new Claim("IsLoaner", "true"));

            }

        }

    }
}
