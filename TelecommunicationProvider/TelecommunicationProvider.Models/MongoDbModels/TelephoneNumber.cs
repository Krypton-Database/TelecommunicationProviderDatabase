// <copyright  file="TelephoneNumber.cs" company="Krypton">
// MIT License
// </copyright>
// <author>Aleksandra92, DragnevaPavlina, alexizvely, The.Bager, pepinho24, grukov</author>

namespace TelecommunicationProvider.Models.MongoDbModels
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class TelephoneNumber
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Number { get; set; }

        public int? UserId { get; set; }
    }
}