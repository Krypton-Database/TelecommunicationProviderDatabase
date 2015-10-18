namespace TelecommunicationProvider.Models.SqlServerModels
{
    using System.Collections.Generic;

    public class Package
    {
        private ICollection<Contract> contracts;

        public Package()
        {
            this.contracts = new HashSet<Contract>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public decimal? Price { get; set; }

        public string Type { get; set; }

        public virtual ICollection<Contract> Contracts
        {
            get { return this.contracts; }
            set { this.contracts = value; }
        }
    }
}
