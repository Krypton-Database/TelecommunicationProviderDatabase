namespace TelecommunicationProvider.Models.MongoDbModels
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class Address
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }

        public int Number { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string ZipCode { get; set; }
    }
}