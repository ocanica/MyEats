using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using MyEats.Business.Helper;
using MyEats.Business.Services;
using MyEats.Commons.Constants;
using MyEats.Domain;
using MyEats.Domain.Entities;
using System;
using System.Linq;

namespace MyEats.Business.Middleware
{
    public static class DbBuilder
    {
        public static IApplicationBuilder DbSeeder(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<DataContext>());               
            }

            return app;
        }

        public static void SeedData(DataContext context)
        {
            Console.WriteLine("Applying Migrations...");

            context.Database.Migrate();

            if (context.Postcodes.Any())
            {
                Console.WriteLine("Data already exists - seeding not necessary...");
            } 
            else
            {
                Console.WriteLine("Seeding postcodes...");

                foreach (var postcode in PostcodeDictionary.Postcodes)
                {
                    context.Postcodes.Add
                        (
                            new PostcodeEntity { PostcodePrefix = postcode.Key, Town = postcode.Value }
                        );
                }

                context.SaveChanges();
            }

            if (context.Customers.Any())
            {
                Console.WriteLine("Data already exists - seeding not necessary...");
            }
            else
            {
                Console.WriteLine("Seeding data...");
                context.Customers.AddRange
                (
                    new UserEntity
                    {
                        CustomerId = Guid.NewGuid(),
                        FirstName = "Dacey",
                        LastName = "Anstis",
                        Email = "danstis0@prnewswire.com",
                        Password = "f6jBS8ez0",
                        PhoneNumber = UKPhoneNumberGenerator.Generate(),
                        StreetAddress = "389 Browning Hill",
                        Town = "Leytonstone",
                        City = "London",
                        Postcode = "E11 3NB",
                        DateRegistered = DateTime.Now
                    },
                    new UserEntity
                    {
                        CustomerId = Guid.NewGuid(),
                        FirstName = "Margarette",
                        LastName = "Greenhall",
                        Email = "mgreenhall0@cloudflare.com",
                        Password = "cLJko5",
                        PhoneNumber = UKPhoneNumberGenerator.Generate(),
                        StreetAddress = "318 Killdeer Parkway",
                        Town = "Straford",
                        City = "London",
                        Postcode = "E15 6QY",
                        DateRegistered = DateTime.Now
                    },
                    new UserEntity
                    {
                        CustomerId = Guid.NewGuid(),
                        FirstName = "Ronna",
                        LastName = "Houseman",
                        Email = "rhouseman1@glados.com",
                        Password = "98Frn6DfE2R6",
                        PhoneNumber = UKPhoneNumberGenerator.Generate(),
                        StreetAddress = "98 Red Cloud Avenue",
                        Town = "Neasdem",
                        City = "London",
                        Postcode = "NW2 4JX",
                        DateRegistered = DateTime.Now
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
