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

            Console.WriteLine("Seeding data / Applying migrations...");

            context.Database.EnsureCreated();


            // Postcodes
            if (context.Postcodes.Any())
            {
                Console.WriteLine("Postcode data already exists.");
            }else
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
            }



            // Users
            if (context.Users.Any())
            {
                Console.WriteLine("User data already exists.");
            }
            else
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
                        Town = context.Postcodes.Where(x => x.PostcodePrefix == "E11").FirstOrDefault().Town,
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
                        Town = context.Postcodes.Where(x => x.PostcodePrefix == "E15").FirstOrDefault().Town,
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
                        Town = context.Postcodes.Where(x => x.PostcodePrefix == "NW2").FirstOrDefault().Town,
                        City = "London",
                        Postcode = "NW2 4JX",
                        PostcodeId = context.Postcodes.Where(x => x.PostcodePrefix.StartsWith("NW2"))
                            .FirstOrDefault().PostcodeId,
                        DateRegistered = DateTime.Now
                    }
                );
                context.SaveChanges();
            }



            //Restaurants
            if (context.Restaurants.Any())
            {
                Console.WriteLine("Restaurant data already exists.");
            }else
            {
                Console.WriteLine("Seeding restaurant data...");

                var test = context.Postcodes.Where(x => x.PostcodePrefix.StartsWith("W12")).FirstOrDefault();

                context.Restaurants.AddRange
                (
                    new RestaurantEntity
                    {
                        RestaurantId = Guid.NewGuid(),
                        Name = "Peshwari Delight",
                        Email = "peshwari@yahoomail.com",
                        Password = "mypassword",
                        StreetAddress = "14 Boulevard Road",
                        Town = context.Postcodes.Where(x => x.PostcodePrefix == "W12").FirstOrDefault().Town,
                        City = "London",
                        Postcode = "W12 4YH",
                        PostcodeId = context.Postcodes.Where(x => x.PostcodePrefix.StartsWith("W12"))
                            .FirstOrDefault().PostcodeId,
                        PhoneNumber = UKPhoneNumberGenerator.Generate(),
                        DateRegistered = DateTime.Now
                    },
                    new RestaurantEntity
                    {
                        RestaurantId = Guid.NewGuid(),
                        Name = "Heaven's Ward",
                        Email = "admin@heavensward.uk",
                        Password = "admin123",
                        StreetAddress = "345 Twin Sisters Street",
                        Town = context.Postcodes.Where(x => x.PostcodePrefix == "SW3").FirstOrDefault().Town,
                        City = "London",
                        Postcode = "SW3 9XZ",
                        PostcodeId = context.Postcodes.Where(x => x.PostcodePrefix.StartsWith("SW3"))
                            .FirstOrDefault().PostcodeId,
                        PhoneNumber = UKPhoneNumberGenerator.Generate(),
                        DateRegistered = DateTime.Now
                    },
                    new RestaurantEntity
                    {
                        RestaurantId = Guid.NewGuid(),
                        Name = "The Cod Father",
                        Email = "thecodefather@storefront.com",
                        Password = "thecodefather",
                        StreetAddress = "16 Terrace Road",
                        Town = context.Postcodes.Where(x => x.PostcodePrefix == "E11").FirstOrDefault().Town,
                        City = "London",
                        Postcode = "E11 69Q",
                        PostcodeId = context.Postcodes.Where(x => x.PostcodePrefix.StartsWith("E11"))
                            .FirstOrDefault().PostcodeId,
                        PhoneNumber = UKPhoneNumberGenerator.Generate(),
                        DateRegistered = DateTime.Now
                    },
                    new RestaurantEntity
                    {
                        RestaurantId = Guid.NewGuid(),
                        Name = "Mr Chippy",
                        Email = "mr.chippy@gmail.com",
                        Password = "chippy01",
                        StreetAddress = "16 High Road",
                        Town = context.Postcodes.Where(x => x.PostcodePrefix == "E15").FirstOrDefault().Town,
                        City = "London",
                        Postcode = "E15 2TY",
                        PostcodeId = context.Postcodes.Where(x => x.PostcodePrefix.StartsWith("E15"))
                            .FirstOrDefault().PostcodeId,
                        PhoneNumber = UKPhoneNumberGenerator.Generate(),
                        DateRegistered = DateTime.Now
                    }
                );

                context.SaveChanges();
            }



            // DeliveryArea
            if (context.DeliveryAreas.Any())
            {
                Console.WriteLine("Delivery area data already exists.");

            }
            else
            {
                Console.WriteLine("Seeding delivery area data...");

                context.DeliveryAreas.AddRange
                (
                    new DeliveryArea
                    {
                        PostcodeID = context.Postcodes.Where(x => x.PostcodePrefix.StartsWith("W12"))
                            .FirstOrDefault().PostcodeId,
                        RestaurantId = context.Restaurants.Where(x => x.Name == "Peshwari Delight").FirstOrDefault().RestaurantId
                    },
                    new DeliveryArea
                    {
                        PostcodeID = context.Postcodes.Where(x => x.PostcodePrefix.StartsWith("W11"))
                            .FirstOrDefault().PostcodeId,
                        RestaurantId = context.Restaurants.Where(x => x.Name == "Peshwari Delight").FirstOrDefault().RestaurantId
                    },
                    new DeliveryArea
                    {
                        PostcodeID = context.Postcodes.Where(x => x.PostcodePrefix.StartsWith("W13"))
                            .FirstOrDefault().PostcodeId,
                        RestaurantId = context.Restaurants.Where(x => x.Name == "Peshwari Delight").FirstOrDefault().RestaurantId
                    },
                    new DeliveryArea
                    {
                        PostcodeID = context.Postcodes.Where(x => x.PostcodePrefix.StartsWith("SW3"))
                            .FirstOrDefault().PostcodeId,
                        RestaurantId = context.Restaurants.Where(x => x.Name == "Heaven's Ward").FirstOrDefault().RestaurantId
                    },
                    new DeliveryArea
                    {
                        PostcodeID = context.Postcodes.Where(x => x.PostcodePrefix.StartsWith("E10"))
                            .FirstOrDefault().PostcodeId,
                        RestaurantId = context.Restaurants.Where(x => x.Name == "The Cod Father").FirstOrDefault().RestaurantId
                    },
                    new DeliveryArea
                    {
                        PostcodeID = context.Postcodes.Where(x => x.PostcodePrefix.StartsWith("E11"))
                            .FirstOrDefault().PostcodeId,
                        RestaurantId = context.Restaurants.Where(x => x.Name == "The Cod Father").FirstOrDefault().RestaurantId
                    },
                    new DeliveryArea
                    {
                        PostcodeID = context.Postcodes.Where(x => x.PostcodePrefix.StartsWith("E12"))
                            .FirstOrDefault().PostcodeId,
                        RestaurantId = context.Restaurants.Where(x => x.Name == "The Cod Father").FirstOrDefault().RestaurantId
                    },
                    new DeliveryArea
                    {
                        PostcodeID = context.Postcodes.Where(x => x.PostcodePrefix.StartsWith("E13"))
                            .FirstOrDefault().PostcodeId,
                        RestaurantId = context.Restaurants.Where(x => x.Name == "The Cod Father").FirstOrDefault().RestaurantId
                    },
                    new DeliveryArea
                    {
                        PostcodeID = context.Postcodes.Where(x => x.PostcodePrefix.StartsWith("E12"))
                            .FirstOrDefault().PostcodeId,
                        RestaurantId = context.Restaurants.Where(x => x.Name == "Mr Chippy").FirstOrDefault().RestaurantId
                    },
                    new DeliveryArea
                    {
                        PostcodeID = context.Postcodes.Where(x => x.PostcodePrefix.StartsWith("E13"))
                            .FirstOrDefault().PostcodeId,
                        RestaurantId = context.Restaurants.Where(x => x.Name == "Mr Chippy").FirstOrDefault().RestaurantId
                    },
                    new DeliveryArea
                    {
                        PostcodeID = context.Postcodes.Where(x => x.PostcodePrefix.StartsWith("E14"))
                            .FirstOrDefault().PostcodeId,
                        RestaurantId = context.Restaurants.Where(x => x.Name == "Mr Chippy").FirstOrDefault().RestaurantId
                    },
                    new DeliveryArea
                    {
                        PostcodeID = context.Postcodes.Where(x => x.PostcodePrefix.StartsWith("E15"))
                            .FirstOrDefault().PostcodeId,
                        RestaurantId = context.Restaurants.Where(x => x.Name == "Mr Chippy").FirstOrDefault().RestaurantId
                    }
                );

                context.SaveChanges();
            }




            // Cuisines
            if (context.Cuisines.Any())
            {
                Console.WriteLine("Cuisine data already exists.");
            }else
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



            // RestaurantCuisines
            if (context.RestaurantCuisines.Any())
            {
                Console.WriteLine("Restaurant cuisine data already exists.");
            }
            else
            {
                Console.WriteLine("Seeding restaurant cuisine data...");

                context.RestaurantCuisines.AddRange
                (
                    new RestaurantCuisine
                    {
                        RestaurantId = context.Restaurants.Where(x => x.Name == "Peshwari Delight").FirstOrDefault().RestaurantId,
                        CuisineId = context.Cuisines.Where(x => x.Name == "Indian").FirstOrDefault().CuisineId,
                    },
                    new RestaurantCuisine
                    {
                        RestaurantId = context.Restaurants.Where(x => x.Name == "Peshwari Delight").FirstOrDefault().RestaurantId,
                        CuisineId = context.Cuisines.Where(x => x.Name == "Kebab").FirstOrDefault().CuisineId
                    },
                    new RestaurantCuisine
                    {
                        RestaurantId = context.Restaurants.Where(x => x.Name == "Heaven's Ward").FirstOrDefault().RestaurantId,
                        CuisineId = context.Cuisines.Where(x => x.Name == "Chinese").FirstOrDefault().CuisineId
                    }, new RestaurantCuisine
                    {
                        RestaurantId = context.Restaurants.Where(x => x.Name == "Heaven's Ward").FirstOrDefault().RestaurantId,
                        CuisineId = context.Cuisines.Where(x => x.Name == "Korean").FirstOrDefault().CuisineId
                    },
                    new RestaurantCuisine
                    {
                        RestaurantId = context.Restaurants.Where(x => x.Name == "The Cod Father").FirstOrDefault().RestaurantId,
                        CuisineId = context.Cuisines.Where(x => x.Name == "Kebab").FirstOrDefault().CuisineId
                    }, new RestaurantCuisine
                    {
                        RestaurantId = context.Restaurants.Where(x => x.Name == "The Cod Father").FirstOrDefault().RestaurantId,
                        CuisineId = context.Cuisines.Where(x => x.Name == "Fish and Chips").FirstOrDefault().CuisineId
                    },
                    new RestaurantCuisine
                    {
                        RestaurantId = context.Restaurants.Where(x => x.Name == "Mr Chippy").FirstOrDefault().RestaurantId,
                        CuisineId = context.Cuisines.Where(x => x.Name == "Kebab").FirstOrDefault().CuisineId
                    }, new RestaurantCuisine
                    {
                        RestaurantId = context.Restaurants.Where(x => x.Name == "Mr Chippy").FirstOrDefault().RestaurantId,
                        CuisineId = context.Cuisines.Where(x => x.Name == "American").FirstOrDefault().CuisineId
                    },
                    new RestaurantCuisine
                    {
                        RestaurantId = context.Restaurants.Where(x => x.Name == "Mr Chippy").FirstOrDefault().RestaurantId,
                        CuisineId = context.Cuisines.Where(x => x.Name == "Fish and Chips").FirstOrDefault().CuisineId
                    }
                );

                context.SaveChanges();
            }



            // Categories
            if (context.Categories.Any())
            {
                Console.WriteLine("Category data already exists.");
            }
            else
            {
                Console.WriteLine("Seeding category data...");

                context.Categories.AddRange
                (
                    new CategoryEntity
                    {
                        Name = "Starter"
                    },
                    new CategoryEntity
                    {
                        Name = "Main"
                    },
                    new CategoryEntity
                    {
                        Name = "Dessert"
                    },
                    new CategoryEntity
                    {
                        Name = "Side"
                    },
                    new CategoryEntity
                    {
                        Name = "Drink"
                    }
                );
                context.SaveChanges();
            }



            // MenuItems
            if (context.MenuItems.Any())
            {
                Console.WriteLine("Menu data already exists.");
            }
            else
            {
                Console.WriteLine("Seeding menu data...");

                context.MenuItems.AddRange
                (
                    new MenuItemEntity
                    {
                        MenuItemId = rand.Next(10000, 99999),
                        RestaurantId = context.Restaurants.Where(x => x.Name == "Peshwari Delight").FirstOrDefault().RestaurantId,
                        Name = "Peshwari Naan",
                        Price = 2.99M,
                        Description = @"Sweet naan bursting full of flavour with raisins, pistachios and desiccated coconut.",
                        Active = true
                    },
                    new MenuItemEntity
                    {
                        MenuItemId = rand.Next(10000, 99999),
                        RestaurantId = context.Restaurants.Where(x => x.Name == "Peshwari Delight").FirstOrDefault().RestaurantId,
                        Name = "Mango Lassi",
                        Price = 1.49M,
                        Description = @"Delicious blend of mango, yogurt and spices.",
                        Active = true
                    }
                );
                context.SaveChanges();
            }



            // MenuCategory
            if (context.MenuCategories.Any())
            {
                Console.WriteLine("Menu category data already exists.");
            }
            else
            {
                Console.WriteLine("Seeding menu category data...");

                context.MenuCategories.AddRange
                (
                    new MenuCategory
                    {
                        CategoryId = context.Categories.Where(x => x.Name == "Side").FirstOrDefault().CategoryId,
                        MenuItemId = context.MenuItems.Where(x => x.Name == "Peshwari Naan").FirstOrDefault().MenuItemId
                    },
                    new MenuCategory
                    {
                        CategoryId = context.Categories.Where(x => x.Name == "Drink").FirstOrDefault().CategoryId,
                        MenuItemId = context.MenuItems.Where(x => x.Name == "Mango Lassi").FirstOrDefault().MenuItemId
                    }
                );
                context.SaveChanges();
            }

            



            

            // Order
            if (context.Orders.Any())
            {
                Console.WriteLine("Order data already exists.");
            }
            else
            {
                Console.WriteLine("Seeding order data...");

                context.Orders.AddRange
                (
                    new OrderEntity
                    {
                        OrderId = 12345,
                        UserId = context.Users.Where(x => x.FirstName == "Ronna").FirstOrDefault().UserId,
                        RestaurantId = context.Restaurants.Where(x => x.Name == "Peshwari Delight").FirstOrDefault().RestaurantId,
                        InOrders = context.InOrders.Where(x => x.OrderId == 12345).ToList(),
                        TotalPrice = context.InOrders.Where(x => x.OrderId == 12345).Select(p => p.Price).Sum(),
                        Items = context.InOrders.Where(x => x.OrderId == 12345).Select(i => i.Quantity).Sum(),
                        DateOrdered = DateTime.UtcNow
                    }
                );
                context.SaveChanges();
            }



            // InOrder
            if (context.InOrders.Any())
            {
                Console.WriteLine("InOrder data already exists.");
            }
            else
            {
                Console.WriteLine("Seeding InOrder data...");

                context.InOrders.AddRange
                (
                    new InOrderEntity
                    {
                        InOrderId = rand.Next(10000, 99999),
                        OrderId = context.Orders.Where(x => x.OrderId == 12345).FirstOrDefault().OrderId,
                        MenuItemId = context.MenuItems.Where(x => x.Name == "Peshwari Naan").FirstOrDefault().MenuItemId,
                        Quantity = 2,
                        Price = context.MenuItems.Where(x => x.Name == "Peshwari Naan").FirstOrDefault().Price * 2
                    },
                    new InOrderEntity
                    {
                        InOrderId = rand.Next(10000, 99999),
                        OrderId = context.Orders.Where(x => x.OrderId == 12345).FirstOrDefault().OrderId,
                        MenuItemId = context.MenuItems.Where(x => x.Name == "Mango Lassi").FirstOrDefault().MenuItemId,
                        Quantity = 1,
                        Price = context.MenuItems.Where(x => x.Name == "Mango Lassi").FirstOrDefault().Price * 1
                    }
                );
                context.SaveChanges();
            }




            
        }
    }
}
