namespace TelecommunicationProvider.Sqlite
{
    using System.Data.Entity;

    public class TelecommunicationProviderDbContext : DbContext
    {
        public TelecommunicationProviderDbContext()
            : base("TelecommunicationProviderDb")
        {
            this.Database.CreateIfNotExists();
        }

        public DbSet<DifferentUserProviders> DifferentUserProviders { get; set; }
    }
}
