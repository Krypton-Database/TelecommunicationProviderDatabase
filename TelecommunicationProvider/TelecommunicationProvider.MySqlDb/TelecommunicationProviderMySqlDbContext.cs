// <copyright  file="TelecommunicationProviderMySqlDbContext.cs" company="Krypton">
// MIT License
// </copyright>
// <author>Aleksandra92, DragnevaPavlina, alexizvely, The.Bager, pepinho24, grukov</author>

namespace TelecommunicationProvider.MySqlDb
{
    using Telerik.OpenAccess;
    using Telerik.OpenAccess.Metadata;

    public class TelecommunicationProviderMySqlDbContext : OpenAccessContext
    {
        private static readonly BackendConfiguration backendConfig = GetBackEndConfig();

        private static readonly MetadataSource metaDataConfig = new ModelConfiguration();

        public TelecommunicationProviderMySqlDbContext(string connectionString)
            : base(connectionString, backendConfig, metaDataConfig)
        {
        }

        private static BackendConfiguration GetBackEndConfig()
        {
            var config = new BackendConfiguration();

            config.Backend = "MySql";
            config.ProviderName = "MySql.Data.MySqlClient";

            return config;
        }
    }
}
