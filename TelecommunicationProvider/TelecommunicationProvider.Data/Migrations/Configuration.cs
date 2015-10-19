// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Configuration.cs" company="">
//   
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace TelecommunicationProvider.Data.Migrations
{
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    using TelecommunicationProvider.Models.SqlServerModels;

    public sealed class Configuration : DbMigrationsConfiguration<TelecommunicationDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.ContextKey = "TelecommunicationProvider.Data.TelecommunicationDbContext";
        }

        protected override void Seed(TelecommunicationDbContext context)
        {
        }
    }
}