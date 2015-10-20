// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataBaseCreator.cs" company="">
//   
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace TelecommunicationProvider.ConsoleClient.DataManipulators
{
    using System.Data.Entity.Migrations;

    using TelecommunicationProvider.Data;
    using TelecommunicationProvider.Models.SqlServerModels;

    internal class DataBaseCreator
    {
        public void CreateDatabase(TelecommunicationDbContext context)
        {
            context.Adresses.Add(
                new Address
                    {
                        Name = "Cvetna Gradina",
                        Number = 32,
                        City = "Sofiq",
                        Country = "Bulgaria",
                        ZipCode = "1000"
                    });

            context.Adresses.Add(
                new Address { Name = "Rakovska", Number = 32, City = "Sofiq", Country = "Bulgaria", ZipCode = "1000" });
            context.Adresses.Add(
                new Address { Name = "Aleksandar Malinov", Number = 32, City = "Sofiq", Country = "Bulgaria", ZipCode = "1000" });

            context.Adresses.Add(
                new Address { Name = "Bogatitsa", Number = 45, City = "Sofiq", Country = "Bulgaria", ZipCode = "1000" });

            context.Adresses.Add(
                new Address { Name = "Kliment Ohridski", Number = 62, City = "Sofiq", Country = "Bulgaria", ZipCode = "1000" });
            context.Adresses.Add(
                new Address { Name = "Cherny vryh", Number = 32, City = "Sofiq", Country = "Bulgaria", ZipCode = "1000" });

            context.Adresses.Add(
                new Address { Name = "Arsenalski blvd", Number = 32, City = "Sofiq", Country = "Bulgaria", ZipCode = "1000" });

            context.SaveChanges();
            context.Users.Add(
                new User
                    {
                        LastName = "Stoycheva",
                        FirstName = "Aleksandra",
                        AddressId = 1,
                        Ssn = "123467891236",
                        Type = "Gold User"
                    });
            context.Users.Add(
                new User
                    {
                        LastName = "Dragneva",
                        FirstName = "Pavlina",
                        AddressId = 2,
                        Ssn = "123467691236",
                        Type = "Gold User"
                    });
            context.Users.Add(new User
                {
                    LastName = "Madjarova",
                    FirstName = "Velimira",
                    AddressId = 3,
                    Ssn = "123467861236",
                    Type = "Gold User"
                });
            context.Users.Add(
               new User
               {
                   LastName = "Pesho",
                   FirstName = "Peshov",
                   AddressId = 1,
                   Ssn = "123467881236",
                   Type = "Gold User"
               });
            context.Users.Add(
                new User
                {
                    LastName = "Doncho",
                    FirstName = "Minkov",
                    AddressId = 4,
                    Ssn = "127467691236",
                    Type = "Gold User"
                });
            context.Users.Add(new User
            {
                LastName = "Niki",
                FirstName = "Kostov",
                AddressId = 3,
                Ssn = "123467879236",
                Type = "Gold User"
            });

            context.SaveChanges();
            context.Packages.Add(new Package { Name = "A++", Type = "Gold", Price = 32 });
            context.Packages.Add(new Package { Name = "B++", Type = "Gold", Price = 35 });
            context.Packages.Add(new Package { Name = "A", Type = "Silver", Price = 25 });
            context.Packages.Add(new Package { Name = "B", Type = "Silver+", Price = 28 });
            context.Packages.Add(new Package { Name = "C++", Type = "Gold", Price = 50 });
            context.Packages.Add(new Package { Name = "D++", Type = "Gold", Price = 35 });
            context.Packages.Add(new Package { Name = "X", Type = "Silver", Price = 25 });
            context.Packages.Add(new Package { Name = "M", Type = "Silver+", Price = 28 });
            context.SaveChanges();
            context.TelephoneNumbers.Add(new TelephoneNumber { UserId = 1, Number = "00359864576326" });
            context.TelephoneNumbers.Add(new TelephoneNumber { UserId = 2, Number = "00359864566466" });
            context.TelephoneNumbers.Add(new TelephoneNumber { UserId = 3, Number = "00359864571326" });
            context.TelephoneNumbers.Add(new TelephoneNumber { UserId = 4, Number = "00359774591326" });
            context.TelephoneNumbers.Add(new TelephoneNumber { UserId = 5, Number = "00359864556326" });
            context.TelephoneNumbers.Add(new TelephoneNumber { UserId = 6, Number = "00359864566466" });
            context.TelephoneNumbers.Add(new TelephoneNumber { UserId = 4, Number = "00359864544326" });
            context.TelephoneNumbers.Add(new TelephoneNumber { UserId = 1, Number = "00359774521326" });
            context.TelephoneNumbers.Add(new TelephoneNumber { UserId = 5, Number = "00359456123783" });
            context.TelephoneNumbers.Add(new TelephoneNumber { UserId = 6, Number = "00359456123782" });
            context.TelephoneNumbers.Add(new TelephoneNumber { UserId = 4, Number = "00359456123781" });
            context.TelephoneNumbers.Add(new TelephoneNumber { UserId = 1, Number = "00359456123789" });
            context.SaveChanges();
        }
    }
}