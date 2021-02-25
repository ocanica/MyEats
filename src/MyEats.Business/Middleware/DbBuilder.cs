using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyEats.Business.Helper;
using MyEats.Commons.Constants;
using MyEats.Domain;
using MyEats.Domain.Entities;
using System;
using System.Collections.Generic;
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
            var rand = new Random();

            Console.WriteLine("Applying Migrations...");

            context.Database.EnsureCreated();

            // Postcodes
            if (!context.Postcodes.Any())
            {
                Console.WriteLine("Seeding postcode data...");

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

            // Users
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
                );

                context.SaveChanges();
            }

            Console.WriteLine("User data already exists.");

            // Cuisines
            if (!context.Cuisines.Any())
            {
                Console.WriteLine("Seeding cuisine data...");

                context.Cuisines.AddRange
                (
                    new CuisineEntity
                    {
                        Name = "Indian"
                    },
                    new CuisineEntity
                    {
                        Name = "Chinese"
                    },
                    new CuisineEntity
                    {
                        Name = "Kebab"
                    },
                    new CuisineEntity
                    {
                        Name = "American"
                    },
                    new CuisineEntity
                    {
                        Name = "Korean"
                    },
                    new CuisineEntity
                    {
                        Name = "Fish and Chips"
                    }
                );

                context.SaveChanges();
            }

            Console.WriteLine("Cuisine data already exists.");

            //Restaurants
            if (!context.Restaurants.Any())
            {
                Console.WriteLine("Seeding restaurant data...");

                var test = context.Postcodes.Where(x => x.PostcodePrefix.StartsWith("W12")).FirstOrDefault();

                context.Restaurants.AddRange
                (
                    new RestaurantEntity
                    {
                        RestaurantId = Guid.NewGuid(),
                        Name = "Peshwari Delight",
                        StreetAddress = "14 Boulevard Road",
                        Town = context.Postcodes.Where(x => x.PostcodePrefix.StartsWith("W12"))
                            .FirstOrDefault().Town,
                        City = "London",
                        Postcode = "W12 4YH",
                        PostcodeId = context.Postcodes.Where(x => x.PostcodePrefix.StartsWith("W12"))
                            .FirstOrDefault().PostcodeId,
                        PhoneNumber = UKPhoneNumberGenerator.Generate(),
                        Cuisine = new List<CuisineEntity>()
                        {
                            context.Cuisines.Where(x => x.Name == "Indian").FirstOrDefault(),
                            context.Cuisines.Where(x => x.Name == "Kebab").FirstOrDefault()
                        },
                        DeliverablePostcode = new List<PostcodeEntity>()
                        {
                            context.Postcodes.Where(x => x.PostcodePrefix.StartsWith("W12")).FirstOrDefault(),
                            context.Postcodes.Where(x => x.PostcodePrefix.StartsWith("W11")).FirstOrDefault(),
                            context.Postcodes.Where(x => x.PostcodePrefix.StartsWith("W13")).FirstOrDefault(),
                        },
                        DateRegistered = DateTime.Now
                    },
                    new RestaurantEntity
                    {
                        RestaurantId = Guid.NewGuid(),
                        Name = "Heaven's Ward",
                        StreetAddress = "345 Twin Sisters Street",
                        Town = context.Postcodes.Where(x => x.PostcodePrefix.StartsWith("SW3"))
                            .FirstOrDefault().Town,
                        City = "London",
                        Postcode = "SW3 9XZ",
                        PostcodeId = context.Postcodes.Where(x => x.PostcodePrefix.StartsWith("SW3"))
                            .FirstOrDefault().PostcodeId,
                        PhoneNumber = UKPhoneNumberGenerator.Generate(),
                        Cuisine = new List<CuisineEntity>()
                        {
                            context.Cuisines.Where(x => x.Name == "Chinese").FirstOrDefault(),
                            context.Cuisines.Where(x => x.Name == "Korean").FirstOrDefault()
                        },
                        DeliverablePostcode = new List<PostcodeEntity>()
                        {
                            context.Postcodes.Where(x => x.PostcodePrefix.StartsWith("SW3")).FirstOrDefault()
                        },
                        DateRegistered = DateTime.Now
                    },
                    new RestaurantEntity
                    {
                        RestaurantId = Guid.NewGuid(),
                        Name = "The Cod Father",
                        StreetAddress = "16 Terrace Road",
                        Town = context.Postcodes.Where(x => x.PostcodePrefix.StartsWith("E11"))
                            .FirstOrDefault().Town,
                        City = "London",
                        Postcode = "E11 69Q",
                        PostcodeId = context.Postcodes.Where(x => x.PostcodePrefix.StartsWith("E11"))
                            .FirstOrDefault().PostcodeId,
                        PhoneNumber = UKPhoneNumberGenerator.Generate(),
                        Cuisine = new List<CuisineEntity>()
                        {
                            context.Cuisines.Where(x => x.Name == "Kebab").FirstOrDefault(),
                            context.Cuisines.Where(x => x.Name == "Fish and Chips").FirstOrDefault()
                        },
                        DeliverablePostcode = new List<PostcodeEntity>()
                        {
                            context.Postcodes.Where(x => x.PostcodePrefix.StartsWith("E10")).FirstOrDefault(),
                            context.Postcodes.Where(x => x.PostcodePrefix.StartsWith("E11")).FirstOrDefault(),
                            context.Postcodes.Where(x => x.PostcodePrefix.StartsWith("E12")).FirstOrDefault(),
                            context.Postcodes.Where(x => x.PostcodePrefix.StartsWith("E13")).FirstOrDefault()
                        },
                        DateRegistered = DateTime.Now
                    },
                    new RestaurantEntity
                    {
                        RestaurantId = Guid.NewGuid(),
                        Name = "Mr Chippy",
                        StreetAddress = "16 High Road",
                        Town = context.Postcodes.Where(x => x.PostcodePrefix.StartsWith("E15"))
                            .FirstOrDefault().Town,
                        City = "London",
                        Postcode = "E15 2TY",
                        PostcodeId = context.Postcodes.Where(x => x.PostcodePrefix.StartsWith("E15"))
                            .FirstOrDefault().PostcodeId,
                        PhoneNumber = UKPhoneNumberGenerator.Generate(),
                        Cuisine = new List<CuisineEntity>()
                        {
                            context.Cuisines.Where(x => x.Name == "Kebab").FirstOrDefault(),
                            context.Cuisines.Where(x => x.Name == "American").FirstOrDefault(),
                            context.Cuisines.Where(x => x.Name == "Fish and Chips").FirstOrDefault()
                        },
                        DeliverablePostcode = new List<PostcodeEntity>()
                        {
                            context.Postcodes.Where(x => x.PostcodePrefix.StartsWith("E15")).FirstOrDefault(),
                            context.Postcodes.Where(x => x.PostcodePrefix.StartsWith("E14")).FirstOrDefault(),
                            context.Postcodes.Where(x => x.PostcodePrefix.StartsWith("E13")).FirstOrDefault(),
                            context.Postcodes.Where(x => x.PostcodePrefix.StartsWith("E12")).FirstOrDefault()
                        },
                        DateRegistered = DateTime.Now
                    }
                );

                context.SaveChanges();
            }

            Console.WriteLine("restaurant data already exists.");

            
        }
    }
}
