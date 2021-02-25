using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyEats.Business.Helper;
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
                SeedData(serviceScope.ServiceProvider.GetService<MyEatsDataContext>());               
            }

            return app;
        }

        public static void SeedData(MyEatsDataContext context)
        {
            Console.WriteLine("Applying Migrations...");

            context.Database.EnsureCreated();

            if (!context.Postcodes.Any())
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
            };

            Console.WriteLine("Postcode data already exists.");

            if (!context.Users.Any())
            {
                Console.WriteLine("Seeding user data...");

                context.Users.AddRange
                (
                    new UserEntity
                    {
                        UserId = Guid.NewGuid(),
                        FirstName = "Dacey",
                        LastName = "Anstis",
                        Email = "danstis0@prnewswire.com",
                        Password = "f6jBS8ez0",
                        PhoneNumber = UKPhoneNumberGenerator.Generate(),
                        StreetAddress = "389 Browning Hill",
                        Town = context.Postcodes.Where(x => x.PostcodePrefix.StartsWith("E11"))
                            .FirstOrDefault().Town,
                        City = "London",
                        Postcode = "E11 3NB",
                        PostcodeId = context.Postcodes.Where(x => x.PostcodePrefix.StartsWith("E11"))
                            .FirstOrDefault().PostcodeId,
                        DateRegistered = DateTime.Now
                    },
                    new UserEntity
                    {
                        UserId = Guid.NewGuid(),
                        FirstName = "Margarette",
                        LastName = "Greenhall",
                        Email = "mgreenhall0@cloudflare.com",
                        Password = "cLJko5",
                        PhoneNumber = UKPhoneNumberGenerator.Generate(),
                        StreetAddress = "318 Killdeer Parkway",
                        Town = context.Postcodes.Where(x => x.PostcodePrefix.StartsWith("E15"))
                            .FirstOrDefault().Town,
                        City = "London",
                        Postcode = "E15 6QY",
                        PostcodeId = context.Postcodes.Where(x => x.PostcodePrefix.StartsWith("E15"))
                            .FirstOrDefault().PostcodeId,
                        DateRegistered = DateTime.Now
                    },
                    new UserEntity
                    {
                        UserId = Guid.NewGuid(),
                        FirstName = "Ronna",
                        LastName = "Houseman",
                        Email = "rhouseman1@glados.com",
                        Password = "98Frn6DfE2R6",
                        PhoneNumber = UKPhoneNumberGenerator.Generate(),
                        StreetAddress = "98 Red Cloud Avenue",
                        Town = context.Postcodes.Where(x => x.PostcodePrefix.StartsWith("NW2"))
                            .FirstOrDefault().Town,
                        City = "London",
                        Postcode = "NW2 4JX",
                        PostcodeId = context.Postcodes.Where(x => x.PostcodePrefix.StartsWith("NW2"))
                            .FirstOrDefault().PostcodeId,
                        DateRegistered = DateTime.Now
                    }
                );;

                context.SaveChanges();
            }

            Console.WriteLine("User data already exists.");
        }
    }
}
