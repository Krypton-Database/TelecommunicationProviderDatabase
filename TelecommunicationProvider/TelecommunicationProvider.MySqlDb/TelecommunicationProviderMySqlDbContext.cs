// <copyright  file="TelecommunicationProviderMySqlDbContext.cs" company="Krypton">
// MIT License
// </copyright>
// <author>Aleksandra92, DragnevaPavlina, alexizvely, The.Bager, pepinho24, grukov</author>

namespace TelecommunicationProvider.MySqlDb
{
    using System.Data.Entity;
    using Models;   
    using Telerik.OpenAccess;
    using Telerik.OpenAccess.Metadata;

    public class TelecommunicationProviderMySqlDbContext : OpenAccessContext
    {
        private static readonly BackendConfiguration BackendConfig = GetBackEndConfig();

        private static readonly MetadataSource MetaDataConfig = new ModelConfiguration();

        public TelecommunicationProviderMySqlDbContext(string connectionString)
            : base(connectionString, BackendConfig, MetaDataConfig)
        {
        }

        private static BackendConfiguration GetBackEndConfig()
        {
            var config = new BackendConfiguration();

            config.Backend = "MySql";
            config.ProviderName = "MySql.Data.MySqlClient";

            return config;
        }

       // public DbSet<MonthlyNumberOfContracts> MonthlyNumberOfContracts { get; set; }
    }
}
