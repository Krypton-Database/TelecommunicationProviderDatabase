namespace TelecommunicationProvider.MongoDb
{
    using System.Collections.Generic;

    using MongoDB.Driver;

    public interface ITelecommunicationProviderMongoDbContext
    {
        MongoCollection<TDefaultDocument> GetCollection<TDefaultDocument>(string collectionName);

        void SaveToCollection<TDefaultDocument>(string collectionName, List<TDefaultDocument> collectionToInsert);

        void DropCollection(string collectionName);
    }
}
