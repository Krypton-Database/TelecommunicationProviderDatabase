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
            this.SeedPackages(context);
            this.SeedTelephoneNumbers(context);
        }

        //private void SeedContracts(TelecommunicationDbContext context)
        //{
        //    var rand = RandomGenerator.Instance;
        //    var contracts = new HashSet<Contract>();
        //    var packageIds = context.Packages.Select(p => p.Id).ToList();
        //    var numberIds = context.TelephoneNumbers.Select(t => t.Id).ToList();
        //    var randomDate = rand.GetRandomDate();

        //    for (int i = 0; i < 100; i++)
        //    {
        //        var contract = new Contract
        //        {
        //            TelephoneNumberId = numberIds[rand.GetRandomNumber(0, numberIds.Count - 1)],
        //            PackageId = packageIds[rand.GetRandomNumber(0, numberIds.Count - 1)],
        //            StartDate = randomDate,
        //            EndDate = rand.GetRandomDate(randomDate)
        //        };

        //        context.Contracts.AddOrUpdate(contract);
        //    }

        //    context.SaveChanges();
        //}

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
            //var rand = RandomGenerator.Instance;
            //var nums = new HashSet<TelephoneNumber>();
            //var userIds = context.Users.Select(u => u.Id).ToList();

            //for (int i = 0; i < 100; i++)
            //{
            //    var num = new TelephoneNumber
            //    {
            //        UserId = userIds[rand.GetRandomNumber(0, userIds.Count - 1)],
            //        Number = "+359" + rand.GetRandomNumber(100000, 999999)
            //    };

            //    context.TelephoneNumbers.AddOrUpdate(num);
            //}

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
            //var rand = RandomGenerator.Instance;
            //var users = new HashSet<User>();
            //var addressIds = context.Adresses.Select(a => a.Id).ToList();

            //for (int i = 0; i < 100; i++)
            //{
            //    var user = new User
            //    {
            //        AddressId = addressIds[rand.GetRandomNumber(0, addressIds.Count - 1)],
            //        FirstName = "User first name " + rand.GetRandomString(rand.GetRandomNumber(2, 15)),
            //        LastName = "User last name " + rand.GetRandomString(rand.GetRandomNumber(2, 15)),
            //        Ssn = rand.GetRandomString(10),
            //        Type = rand.GetRandomString(rand.GetRandomNumber(2, 10))
            //    };

            //    context.Users.AddOrUpdate(user);
            //}

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