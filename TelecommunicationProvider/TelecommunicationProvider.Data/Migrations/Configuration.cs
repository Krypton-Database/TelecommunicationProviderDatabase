namespace TelecommunicationProvider.Data.Migrations
{
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TelecommunicationProvider.Models.SqlServerModels;

    public sealed class Configuration : DbMigrationsConfiguration<TelecommunicationDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.ContextKey = "TelecommunicationProvider.Data.TelecommunicationDbContext";
        }

        protected override void Seed(TelecommunicationDbContext context)
        {
            this.SeedAddresses(context);
            this.SeedUsers(context);
            this.SeedPackages(context);
            this.SeedTelephoneNumbers(context);
        }

        private void SeedTelephoneNumbers(TelecommunicationDbContext context)
        {

            List<TelephoneNumber> phones = new List<TelephoneNumber>()
                                   {
                                       new TelephoneNumber
                                           {
                                            UserId = 1,
                                            Number = "00359864596326"
                                           },
                                           new TelephoneNumber
                                           {
                                            UserId = 2,
                                            Number = "00359864596466"
                                           },
                                           new TelephoneNumber
                                           {
                                            UserId = 3,
                                            Number = "00359864591326"
                                           },
                                           new TelephoneNumber
                                           {
                                            UserId = 3,
                                            Number = "00359774591326"
                                           },
                                   };
            foreach (var phone in phones)
            {
                context.TelephoneNumbers.AddOrUpdate(phone);
            }
          

           context.SaveChanges();
        }

        private void SeedUsers(TelecommunicationDbContext context)
        {
            List<User> users = new List<User>()
                                   {
                                       new User
                                           {
                                               LastName = "Stoycheva",
                                               FirstName = "Aleksandra",
                                               AddressId = 1,
                                               Ssn = "123467891236",
                                               Type = "Gold User"
                                           },
                                            new User
                                           {
                                               LastName = "Dragneva",
                                               FirstName = "Pavlina",
                                               AddressId = 2,
                                               Ssn = "123467691236",
                                               Type = "Gold User"
                                           },
                                           new User
                                               {
                                               LastName = "Madjarova",
                                               FirstName = "Velimira",
                                               AddressId = 3,
                                               Ssn = "123467861236",
                                                Type = "Gold User"
                                               }
                                   };
            foreach (var user in users)
            {
                context.Users.AddOrUpdate(user);
            }
            
            context.SaveChanges();
        }

        private void SeedPackages(TelecommunicationDbContext context)
        {
            List<Package> packages = new List<Package>()
                                   {
                                       new Package
                                           {
                                            Name = "A++",
                                            Type = "Gold",
                                            Price = 32,
                                            },
                                           new Package
                                           {
                                            Name = "B++",
                                            Type = "Gold",
                                            Price = 35,
                                            },
                                             new Package
                                           {
                                            Name = "A",
                                            Type = "Silver",
                                            Price = 25,
                                            },
                                             new Package
                                           {
                                            Name = "B",
                                            Type = "Silver+",
                                            Price = 28,
                                            },
                                   };
            foreach (var package in packages)
            {
                context.Packages.AddOrUpdate(package);
            }
            context.SaveChanges();
        }

        private void SeedAddresses(TelecommunicationDbContext context)
        {
            List<Address> addresses = new List<Address>()
                                   {
                                       new Address
                                           {
                                            Name = "Cvetna Gradina",
                                            Number = 32,
                                            City = "Sofiq",
                                            Country = "Bulgaria",
                                            ZipCode = "1000",
                                           },
                                          new Address
                                           {
                                            Name = "Aleksandar Malinov",
                                            Number = 32,
                                            City = "Sofiq",
                                            Country = "Bulgaria",
                                            ZipCode = "1000",
                                           },
                                            new Address
                                           {
                                            Name = "Bogatitsa",
                                            Number = 32,
                                            City = "Sofiq",
                                            Country = "Bulgaria",
                                            ZipCode = "1000",
                                           }
                                   };
            foreach (var address in addresses)
            {
                context.Adresses.AddOrUpdate(address);
            }

            //    var addresses = new HashSet<Address>();

            //    for (int i = 0; i < 100; i++)
            //    {
            //        var address = new Address
            //        {
            //            Name = Constants.CityNames[RandomGenerator.Instance.GetRandomNumber(0, Constants.CityNames.Count - 1)]
            //        };

            //        context.Adresses.AddOrUpdate(address);
            //    }

            context.SaveChanges();
        }
    }
}