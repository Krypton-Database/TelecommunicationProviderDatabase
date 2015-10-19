// <copyright  file="TelecommunicationDbContext.cs" company="Krypton">
// MIT License
// </copyright>
// <author>Aleksandra92, DragnevaPavlina, alexizvely, The.Bager, pepinho24, grukov</author>

namespace TelecommunicationProvider.Data
{
    using System.Data.Entity;
    using TelecommunicationProvider.Models.SqlServerModels;

    public class TelecommunicationDbContext : DbContext
    {
        public TelecommunicationDbContext()
            : base("TelecommunicationProviderDb")
        {
        }

        public virtual IDbSet<Address> Adresses { get; set; }

        public virtual IDbSet<Contract> Contracts { get; set; }

        public virtual IDbSet<Package> Packages { get; set; }

        public virtual IDbSet<TelephoneNumber> TelephoneNumbers { get; set; }

        public virtual IDbSet<User> Users { get; set; }
    }
}