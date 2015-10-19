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
                new Address { Name = "Cvetna Gradina", Number = 32, City = "Sofiq", Country = "Bulgaria", ZipCode = "1000" });
            context.Adresses.Add(
                new Address { Name = "Aleksandar Malinov", Number = 32, City = "Sofiq", Country = "Bulgaria", ZipCode = "1000" });

            context.Adresses.Add(
                new Address { Name = "Bogatitsa", Number = 32, City = "Sofiq", Country = "Bulgaria", ZipCode = "1000" });
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
            context.SaveChanges();
            context.Packages.Add(new Package { Name = "A++", Type = "Gold", Price = 32 });
            context.Packages.Add(new Package { Name = "B++", Type = "Gold", Price = 35 });
            context.Packages.Add(new Package { Name = "A", Type = "Silver", Price = 25 });
            context.Packages.Add(new Package { Name = "B", Type = "Silver+", Price = 28 });
            context.SaveChanges();
            context.TelephoneNumbers.Add(new TelephoneNumber { UserId = 1, Number = "00359864596326" });
            context.TelephoneNumbers.Add(new TelephoneNumber { UserId = 1, Number = "00359864596466" });
            context.TelephoneNumbers.Add(new TelephoneNumber { UserId = 1, Number = "00359864591326" });
            context.TelephoneNumbers.Add(new TelephoneNumber { UserId = 1, Number = "00359774591326" });
            context.SaveChanges();
        }
    }
}