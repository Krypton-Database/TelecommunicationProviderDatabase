// <copyright  file="ITelecommunicationProviderMongoDbContext.cs" company="Krypton">
// MIT License
// </copyright>
// <author>Aleksandra92, DragnevaPavlina, alexizvely, The.Bager, pepinho24, grukov</author>

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