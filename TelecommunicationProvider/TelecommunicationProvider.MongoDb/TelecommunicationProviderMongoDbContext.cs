// <copyright  file="TelecommunicationProviderMongoDbContext.cs" company="Krypton">
// MIT License
// </copyright>
// <author>Aleksandra92, DragnevaPavlina, alexizvely, The.Bager, pepinho24, grukov</author>

namespace TelecommunicationProvider.MongoDb
{
    using System.Collections.Generic;
    using MongoDB.Driver;

    public class TelecommunicationProviderMongoDbContext : ITelecommunicationProviderMongoDbContext
    {
        private const string MongoDataBaseHost = "mongodb://Krypton:123456@ds041154.mongolab.com:41154/telecommunicationprovider";
        private const string DatabaseName = "telecommunicationprovider";

        private readonly MongoDatabase database;

        public TelecommunicationProviderMongoDbContext()
        {
            this.database = this.ConnectToDatabase(DatabaseName);
        }

        public MongoCollection<TDefaultDocument> GetCollection<TDefaultDocument>(string collectionName)
        {
            return this.database.GetCollection<TDefaultDocument>(collectionName);
        }

        public void SaveToCollection<TDefaultDocument>(string collectionName, List<TDefaultDocument> collectionToInsert)
        {
            this.database.GetCollection<TDefaultDocument>(collectionName).InsertBatch(collectionToInsert);
        }

        public void DropCollection(string collectionName)
        {
            this.database.DropCollection(collectionName);
        }

        private MongoDatabase ConnectToDatabase(string dataBaseName)
        {
            var client = new MongoClient(MongoDataBaseHost);
            MongoServer server = client.GetServer();
            return server.GetDatabase(dataBaseName);
        }
    }
}