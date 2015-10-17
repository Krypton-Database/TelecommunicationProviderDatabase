namespace TelecommunicationProvider.Data.Migrations
{
    using System.Data.Entity.Migrations;

    using TelecommunicationProvider.Models;

    public sealed class Configuration : DbMigrationsConfiguration<TelecommunicationDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.ContextKey = "TelecommunicationProvider.Data.TelecommunicationDbContext";
        }

        protected override void Seed(TelecommunicationDbContext context)
        {
            context.Adresses
                .AddOrUpdate(
                a => a.Name,
                new Address
                    {
                        Name = "First seed address"
                    },
                    new Address
                        {
                            Name = "Second seed address"
                        });
        }
    }
}
