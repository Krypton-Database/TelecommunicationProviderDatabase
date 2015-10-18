namespace TelecommunicationProvider.Models.SqlServerModels
{
    using System.Collections.Generic;

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