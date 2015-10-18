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