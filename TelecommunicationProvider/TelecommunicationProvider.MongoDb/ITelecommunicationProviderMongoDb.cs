// <copyright  file="ITelecommunicationProviderMongoDb.cs" company="Krypton">
// MIT License
// </copyright>
// <author>Aleksandra92, DragnevaPavlina, alexizvely, The.Bager, pepinho24, grukov</author>

namespace TelecommunicationProvider.MongoDb
{
    using System.Collections.Generic;
    using MongoDB.Driver;
    using TelecommunicationProvider.Models.MongoDbModels;

    public interface ITelecommunicationProviderMongoDb
    {
        MongoCollection<User> User { get; }

        MongoCollection<Address> Address { get; }

        MongoCollection<TelephoneNumber> TelephoneNumber { get; }

        void Save<TDefaultDocument>(string collectionName, List<TDefaultDocument> collection);
    }
}