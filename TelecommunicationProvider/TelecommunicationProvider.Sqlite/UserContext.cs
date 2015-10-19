namespace TelecommunicationProvider.Sqlite
{
    using System.Data.Entity;

    public class UserContext : DbContext
    {
        public UserContext()
            : base("UserContextSqlLiteDb")
        {
            this.Database.CreateIfNotExists();
        }

        public DbSet<User> User { get; set; }
    }
}
