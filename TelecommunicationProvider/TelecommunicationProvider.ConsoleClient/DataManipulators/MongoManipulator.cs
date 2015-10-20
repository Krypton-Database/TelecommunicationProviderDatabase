namespace TelecommunicationProvider.ConsoleClient.DataManipulators
{
    using System;

    using TelecommunicationProvider.Data;
    using TelecommunicationProvider.Models.SqlServerModels;
    using TelecommunicationProvider.MongoDb;

    public class MongoManipulator
    {
        public void ImportDataFromMongo(TelecommunicationDbContext telecommunicationDbContext, ITelecommunicationProviderMongoDbContext telecommunicationMongoDbContext)
        {
            var mongoData = new TelecommunicationProviderMongoDb(telecommunicationMongoDbContext);

            var usersCollection = mongoData.User.FindAll();

            var telephonesCollection = mongoData.TelephoneNumber.FindAll();

            var addressCollection = mongoData.Address.FindAll();

            foreach (var item in usersCollection)
            {
                var user = new User
                {
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Ssn = item.Ssn,
                    Type = item.Type,
                    AddressId = item.AddressId
                };
                telecommunicationDbContext.Users.Add(user);
                telecommunicationDbContext.SaveChanges();
            }

            foreach (var item in telephonesCollection)
            {
                var phone = new TelephoneNumber
                {
                    Number = item.Number,
                    UserId = item.UserId
                };
                telecommunicationDbContext.TelephoneNumbers.Add(phone);
                telecommunicationDbContext.SaveChanges();
            }

            foreach (var item in addressCollection)
            {
                var address = new Address
                {
                    Name = item.Name,
                    Number = item.Number,
                    City = item.City,
                    Country = item.Country,
                    ZipCode = item.ZipCode
                };
                telecommunicationDbContext.Adresses.Add(address);
                telecommunicationDbContext.SaveChanges();
            }
            Console.WriteLine("Import from Mongo is ready");
        }
    }
}
