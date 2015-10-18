namespace TelecommunicationProvider.MongoDb
{
    using System.Collections.Generic;
    using MongoDB.Driver;
    using TelecommunicationProvider.Models.MongoDbModels;

    public class TelecommunicationProviderMongoDb : ITelecommunicationProviderMongoDb
    {
        private const string UserCollectionName = "Users";
        private const string AddressCollectionName = "Addresses";
        private const string TelephoneNumbersCollectionName = "TelephoneNumbers";

        private readonly ITelecommunicationProviderMongoDbContext databaseContext;

        public TelecommunicationProviderMongoDb(ITelecommunicationProviderMongoDbContext context)
        {
            this.databaseContext = context;
        }

        public MongoCollection<User> User
        {
            get
            {
                return this.databaseContext.GetCollection<User>(UserCollectionName);
            }
        }

        public MongoCollection<Address> Address
        {
            get
            {
                return this.databaseContext.GetCollection<Address>(AddressCollectionName);
            }
        }

        public MongoCollection<TelephoneNumber> TelephoneNumber
        {
            get
            {
                return this.databaseContext.GetCollection<TelephoneNumber>(TelephoneNumbersCollectionName);
            }
        }

        public void Save<TDefaultDocument>(string collectionName, List<TDefaultDocument> collection)
        {
            this.databaseContext.SaveToCollection(collectionName, collection);
        }

        public void Delete(string collectionName)
        {
            this.databaseContext.DropCollection(collectionName);
        }
    }
}