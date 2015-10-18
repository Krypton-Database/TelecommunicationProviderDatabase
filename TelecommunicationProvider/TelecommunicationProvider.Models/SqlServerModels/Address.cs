namespace TelecommunicationProvider.Models.SqlServerModels
{
    using System.Collections;
    using System.Collections.Generic;

    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class Address
    {
        private ICollection<User> users;

        public Address()
        {
            this.users = new HashSet<User>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int Number { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string ZipCode { get; set; }

        public virtual ICollection<User> Users
        {
            get { return this.users; }
            set { this.users = value; }
        }
    }
}
