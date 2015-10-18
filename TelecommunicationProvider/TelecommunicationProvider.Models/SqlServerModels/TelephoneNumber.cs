namespace TelecommunicationProvider.Models.SqlServerModels
{
    using System.Collections.Generic;

    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class TelephoneNumber
    {
        private ICollection<Contract> contracts;

        public TelephoneNumber()
        {
            this.contracts = new HashSet<Contract>();
        }

        public int Id { get; set; }

        public string Number { get; set; }

        public int? UserId { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Contract> Contracts
        {
            get { return this.contracts; }
            set { this.contracts = value; }
        }
    }
}
