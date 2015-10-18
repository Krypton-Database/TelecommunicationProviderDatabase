namespace TelecommunicationProvider.Models.SqlServerModels
{
    using System.Collections;
    using System.Collections.Generic;

    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class User
    {
        private ICollection<TelephoneNumber> telephoneNumber;

        public User()
        {
            this.telephoneNumber = new HashSet<TelephoneNumber>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Ssn { get; set; }

        public string Type { get; set; }

        public int AddressId { get; set; }

        public virtual Address Address { get; set; }

        public virtual ICollection<TelephoneNumber> TelephoneNumbers
        {
            get { return this.telephoneNumber; }
            set { this.telephoneNumber = value; }
        }
    }
}
