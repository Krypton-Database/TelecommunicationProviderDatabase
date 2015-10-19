// <copyright  file="TelephoneNumber.cs" company="Krypton">
// MIT License
// </copyright>
// <author>Aleksandra92, DragnevaPavlina, alexizvely, The.Bager, pepinho24, grukov</author>

namespace TelecommunicationProvider.Models.SqlServerModels
{
    using System.Collections.Generic;

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