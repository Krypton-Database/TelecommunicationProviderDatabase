namespace TelecommunicationProvider.Models
{
    using System.Collections;
    using System.Collections.Generic;

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

        public virtual ICollection<TelephoneNumber> TelephoneNunbers
        {
            get { return this.telephoneNumber; }
            set { this.telephoneNumber = value; }
        }
    }
}
