namespace TelecommunicationProvider.Data.Migrations
{
    using System;
    using System.Reflection;
    using System.Linq;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using TelecommunicationProvider.Models;


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
            context.SaveChanges();
            this.SeedPackages(context);
            context.SaveChanges();
            this.SeedUsers(context);
            context.SaveChanges();
            this.SeedTelephoneNumbers(context);
            context.SaveChanges();
            this.SeedContracts(context);
            context.SaveChanges();

        }

        private void SeedContracts(TelecommunicationDbContext context)
        {
            var rand = RandomGenerator.Instance;
            var contracts = new HashSet<Contract>();
            var packageIds = context.Packages.Select(p => p.Id).ToList();
            var numberIds = context.TelephoneNumbers.Select(t => t.Id).ToList();
            var randomDate = rand.GetRandomDate();

            for (int i = 0; i < 100; i++)
            {
                var contract = new Contract
                {
                    TelephoneNumberId = numberIds[rand.GetRandomNumber(0, numberIds.Count - 1)],
                    PackageId = packageIds[rand.GetRandomNumber(0, numberIds.Count - 1)],
                    StartDate = randomDate,
                    EndDate = rand.GetRandomDate(randomDate)
            };

                context.Contracts.AddOrUpdate(contract);
            }

            context.SaveChanges();
        }

        private void SeedTelephoneNumbers(TelecommunicationDbContext context)
        {
            var rand = RandomGenerator.Instance;
            var nums = new HashSet<TelephoneNumber>();
            var userIds = context.Users.Select(u => u.Id).ToList();

            for (int i = 0; i < 100; i++)
            {
                var num = new TelephoneNumber
                {
                    UserId = userIds[rand.GetRandomNumber(0, userIds.Count - 1)],
                    Number = "+359" + rand.GetRandomNumber(100000, 999999)
                };

                context.TelephoneNumbers.AddOrUpdate(num);
            }

            context.SaveChanges();
        }

        private void SeedUsers(TelecommunicationDbContext context)
        {
            var rand = RandomGenerator.Instance;
            var users = new HashSet<User>();
            var addressIds = context.Adresses.Select(a => a.Id).ToList();

            for (int i = 0; i < 100; i++)
            {
                var user = new User
                {
                    AddressId = addressIds[rand.GetRandomNumber(0, addressIds.Count - 1)],
                    FirstName = "User first name " + rand.GetRandomString(rand.GetRandomNumber(2, 15)),
                    LastName = "User last name " + rand.GetRandomString(rand.GetRandomNumber(2, 15)),
                    Ssn = rand.GetRandomString(10),
                    Type = rand.GetRandomString(rand.GetRandomNumber(2, 10))
                };

                context.Users.AddOrUpdate(user);
            }

            context.SaveChanges();
        }

        private void SeedPackages(TelecommunicationDbContext context)
        {
            var rand = RandomGenerator.Instance;
            var packages = new HashSet<Address>();

            for (int i = 0; i < 500; i++)
            {
                var package = new Package
                {
                    Name = rand.GetRandomString(rand.GetRandomNumber(2, 20)),
                    Price = rand.GetRandomNumber(1, 500000),
                    Type = rand.GetRandomString(rand.GetRandomNumber(2, 10))
                };

                context.Packages.AddOrUpdate(package);

                if (i % 100 == 0)
                {
                    context.SaveChanges();
                }
            }

            context.SaveChanges();
        }

        private void SeedAddresses(TelecommunicationDbContext context)
        {
            var addresses = new HashSet<Address>();

            for (int i = 0; i < 100; i++)
            {
                var address = new Address
                {
                    Name = Constants.CityNames[RandomGenerator.Instance.GetRandomNumber(0, Constants.CityNames.Count - 1)]
                };

                context.Adresses.AddOrUpdate(address);
            }

            context.SaveChanges();
        }
    }
}
