using System;
using System.Linq;
using Microsoft.Data.Entity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNet.Identity;
using System.Security.Claims;
using System.Threading.Tasks;

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
    new Car {Make = " Volvo   ", Model = "XC90", Year = 2015,Image = "http://topcarsreleasedates.com/wp-content/uploads/2015/08/2016-volvo-xc90-.jpg", Door = 4, Price = 132m},

    new Car {Make = " Mazda",Model = " MX-5 Miata", Year = 2016,Image = "http://2.bp.blogspot.com/-lndOWG_WqsE/Ug3fiHidR8I/AAAAAAAAH3o/-LOSoELV-6w/s1600/2015-MG-Roadster-52.jpg", Door = 2 , Price = 124m },

    new Car {Make = "Chevrolet ",Model = "Corvette",Year = 2014 , Image = "http://s3.amazonaws.com/fzautomotive/dealers/55b6d6e755b30.png", Door = 2, Price = 155m},

    new Car {Make = "Honda ", Model = "Pilot",Year = 2014,Image = "http://static4.consumerreportscdn.org/content/dam/cro/magazine-articles/2015/December/CR122K15-Honda_Pilot_16_2917_Right.jpg",Door = 4, Price =130}
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


        }

    }
}
